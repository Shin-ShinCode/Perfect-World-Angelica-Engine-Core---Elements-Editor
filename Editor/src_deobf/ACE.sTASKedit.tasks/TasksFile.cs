using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ACE.Classes;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.tasks;

public class TasksFile
{
	private sealed class Class422
	{
		public int[] int_0;

		public BinaryReader binaryReader_0;

		public int int_1;

		public bool bool_0;

		public ATaskTempl[] results;

		public TasksFile tasksFile_0;

		public IProgress<int> iprogress_0;

		internal void method_0(int int_2)
        {
            try
            {
                byte[] data;
                lock (binaryReader_0)
                    data = TaskRecordReader.ReadBytes(binaryReader_0, int_0, int_2);
                results[int_2] = TaskRecordReader.Parse(tasksFile_0.Header.version, data);
            }
            catch (Exception error) when (bool_0 && (error is InvalidDataException || error is EndOfStreamException || error is ArgumentOutOfRangeException))
            {
                Interlocked.Increment(ref tasksFile_0.skippedTaskCount);
                SentryHelper.CaptureException(error, "Skipped invalid task record");
            }
            finally
            {
                int completed = Interlocked.Increment(ref int_1);
                if (completed % 100 == 0) iprogress_0?.Report(completed / 2);
            }
        }
	}

	private sealed class Class423
	{
		public BinaryReader binaryReader_0;

		internal int method_0(int int_0)
		{
			return binaryReader_0.ReadInt32();
		}
	}

	[Serializable]
	private sealed class Class424
	{
		public static readonly Class424 class424_0 = new Class424();

		public static Func<ATaskTempl, int> func_0;

		public static Func<ATaskTempl, int> func_1;

		public static Func<ATaskTempl, ATaskTempl, (ATaskTempl, ATaskTempl)> func_2;

		public static Func<ATaskTempl, int> func_3;

		public static Func<ATaskTempl, int> func_4;

		internal int method_0(ATaskTempl ataskTempl_0)
		{
			return ataskTempl_0.ID;
		}

		internal int method_1(ATaskTempl ataskTempl_0)
		{
			return ataskTempl_0.ID;
		}

		internal (ATaskTempl, ATaskTempl) method_2(ATaskTempl ataskTempl_0, ATaskTempl ataskTempl_1)
		{
			return (ataskTempl_1, ataskTempl_0);
		}

		internal int method_3(ATaskTempl ataskTempl_0)
		{
			return ataskTempl_0.ID;
		}

		internal int method_4(ATaskTempl ataskTempl_0)
		{
			return ataskTempl_0.ID;
		}
	}

	private List<ATaskTempl> list_0;
    private int skippedTaskCount;
    public int SkippedTaskCount => skippedTaskCount;

	private TASK_PACK_HEADER task_PACK_HEADER_0;

	public List<ATaskTempl> Tasks
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
	}

	public TASK_PACK_HEADER Header
	{
		[CompilerGenerated]
		get
		{
			return task_PACK_HEADER_0;
		}
	}

	public TasksFile(string fileName, bool loadParallel = true, bool skipBrokenTasks = false, IProgress<int> progress = null)
	{
		Class423 @class = new Class423();
		if (!File.Exists(fileName))
		{
			throw new FileNotFoundException(fileName);
		}
		EditorSessionTracker.LogFolderAccess(fileName, Class16.smethod_0(1648903793), Class16.smethod_0(1648906421));
		using FileStream input = File.OpenRead(fileName);
		@class.binaryReader_0 = new BinaryReader(input);
		try
		{
			method_1(new TASK_PACK_HEADER(@class.binaryReader_0));
			if (Header.magic != -1819966623 && Header.magic != 0)
			{
				throw new NotSupportedException(string.Format(Class16.smethod_0(1649403743), Header.magic));
			}
			if (!GlobalData.Versions.Contains(Header.version))
			{
				throw new NotSupportedException(string.Format(Class16.smethod_0(1649403769), Header.version));
			}
			if (Header.version > GlobalData.GetMaxAllowedTaskVersion())
			{
				throw new NotSupportedException(string.Format(Class16.smethod_0(1649403813), Header.version, GlobalData.GetMaxAllowedTaskVersion()));
			}
			if (Header.version >= 223)
			{
				GlobalData.data_size = @class.binaryReader_0.ReadInt32();
			}
			if (Header.item_count < 0 || (long)Header.item_count * 4 > input.Length - input.Position)
                throw new InvalidDataException("Invalid task offset count.");
            int[] int_ = Enumerable.Repeat(0, Header.item_count).Select(@class.method_0).ToArray();
			long dataStart = input.Position;
            for (int i = 0; i < int_.Length; i++)
                if (int_[i] < dataStart || int_[i] >= input.Length || (i > 0 && int_[i] <= int_[i - 1]))
                    throw new InvalidDataException("Invalid or unordered task offsets at index " + i);
            method_0(method_3(skipBrokenTasks, progress, @class.binaryReader_0, int_, loadParallel ? Math.Min(2, Environment.ProcessorCount) : 1));
		}
		finally
		{
			if (@class.binaryReader_0 != null)
			{
				((IDisposable)@class.binaryReader_0).Dispose();
			}
		}
	}

	

	private void method_0(List<ATaskTempl> list_1)
	{
		list_0 = list_1;
	}

	private void method_1(TASK_PACK_HEADER task_PACK_HEADER_1)
	{
		task_PACK_HEADER_0 = task_PACK_HEADER_1;
	}

	

	private List<ATaskTempl> method_3(bool bool_0, IProgress<int> iprogress_0, BinaryReader binaryReader_0, int[] int_0, int workers)
	{
		Class422 @class = new Class422();
		@class.int_0 = int_0;
		@class.binaryReader_0 = binaryReader_0;
		@class.bool_0 = bool_0;
		@class.tasksFile_0 = this;
		@class.iprogress_0 = iprogress_0;
		@class.int_1 = 0;
		@class.results = new ATaskTempl[Header.item_count];
        if (workers == 1)
            for (int i = 0; i < Header.item_count; i++) @class.method_0(i);
        else
            Parallel.For(0, Header.item_count, new ParallelOptions { MaxDegreeOfParallelism = workers }, @class.method_0);
        return @class.results.Where(task => task != null).ToList();
	}

	public static void JoinTasks(IEnumerable<ATaskTempl> fromTasks, IEnumerable<ATaskTempl> toTasks, Action<(ATaskTempl from, ATaskTempl to)> mutation)
	{
		toTasks.AsParallel().GetAllTasks().Join(fromTasks.AsParallel().GetAllTasks(), Class424.class424_0.method_0, Class424.class424_0.method_1, Class424.class424_0.method_2)
			.ForAll<(ATaskTempl, ATaskTempl)>(mutation);
	}

	public static List<int> GetNotIntersectTasks(IEnumerable<ATaskTempl> source, IEnumerable<ATaskTempl> compareWith)
	{
		return source.AsParallel().GetAllTasks().Select(Class424.class424_0.method_3)
			.Except(compareWith.AsParallel().GetAllTasks().Select(Class424.class424_0.method_4))
			.ToList();
	}
}
