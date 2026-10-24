using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using ACE.Classes;
using ACE.Elements.eList;
using ACE.Elements.eListCollection;
using ACE.Path;
using ACE.Pck;

namespace ACE.NMD;

public class NmdExporter
{
	private sealed class Class241
	{
		public int int_0;

		public Class243 class243_0;
	}

	private sealed class Class242
	{
		public string string_0 = string.Empty;

		public int int_0;

		public int int_1;

		public int int_2;

		public List<Struct67> list_0 = new List<Struct67>();

		public List<Class246> list_1 = new List<Class246>();

		public bool method_0()
		{
			if (list_0.Count != 0)
			{
				return list_1.Count == 0;
			}
			return true;
		}

		public void method_1()
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i] = list_0[i].method_0();
			}
			foreach (Class246 item in list_1)
			{
				item.struct67_0 = item.struct67_0.method_0();
				foreach (Class241 item2 in item.list_0)
				{
					item2.class243_0.struct67_0 = item2.class243_0.struct67_0.method_0();
				}
				foreach (Class243 item3 in item.list_1)
				{
					item3.struct67_0 = item3.struct67_0.method_0();
				}
			}
		}

		public void method_2(BinaryWriter binaryWriter_0)
		{
			byte[] array = new byte[41];
			byte[] bytes = Encoding.ASCII.GetBytes(string_0 ?? string.Empty);
			Array.Copy(bytes, array, Math.Min(bytes.Length, array.Length));
			binaryWriter_0.Write(array);
			if (int_0 >= 1)
			{
				binaryWriter_0.Write(int_1);
			}
			binaryWriter_0.Write(int_2);
			binaryWriter_0.Write(list_0.Count);
			foreach (Struct67 item in list_0)
			{
				binaryWriter_0.Write(item.float_0);
				binaryWriter_0.Write(item.float_1);
				binaryWriter_0.Write(item.float_2);
			}
			binaryWriter_0.Write(list_1.Count);
			foreach (Class246 item2 in list_1)
			{
				binaryWriter_0.Write(item2.struct67_0.float_0);
				binaryWriter_0.Write(item2.struct67_0.float_1);
				binaryWriter_0.Write(item2.struct67_0.float_2);
				binaryWriter_0.Write(item2.float_0);
				binaryWriter_0.Write(item2.list_0.Count);
				foreach (Class241 item3 in item2.list_0)
				{
					binaryWriter_0.Write(item3.int_0);
					binaryWriter_0.Write(item3.class243_0.struct67_0.float_0);
					binaryWriter_0.Write(item3.class243_0.struct67_0.float_1);
					binaryWriter_0.Write(item3.class243_0.struct67_0.float_2);
					binaryWriter_0.Write(item3.class243_0.float_0);
				}
				if (int_0 <= 1)
				{
					continue;
				}
				binaryWriter_0.Write(item2.list_1.Count);
				foreach (Class243 item4 in item2.list_1)
				{
					binaryWriter_0.Write(item4.struct67_0.float_0);
					binaryWriter_0.Write(item4.struct67_0.float_1);
					binaryWriter_0.Write(item4.struct67_0.float_2);
					binaryWriter_0.Write(item4.float_0);
				}
			}
		}
	}

	private sealed class Class243
	{
		public Struct67 struct67_0;

		public float float_0;
	}

	private struct Struct67(float float_3, float float_4, float float_5)
	{
		public float float_0 = float_3;

		public float float_1 = float_4;

		public float float_2 = float_5;

		public Struct67 method_0()
		{
			return new Struct67(0f - float_0, float_1, 0f - float_2);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	// TODO(recovered): bumped private->internal to match the ref-param method that exposes it.
	internal struct Struct68
	{
		public string string_0;
	}

	private sealed class Class244 : IEnumerable, IEnumerator, IDisposable, IEnumerable<byte[]>, IEnumerator<byte[]>
	{
		private int int_0;

		private byte[] byte_0;

		private int int_1;

		public NmdExporter nmdExporter_0;

		private Struct68 struct68_0;

		byte[] IEnumerator<byte[]>.Current
		{
			[DebuggerHidden]
			get
			{
				return byte_0;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return byte_0;
			}
		}

		[DebuggerHidden]
		public Class244(int int_2)
		{
			int_0 = int_2;
			int_1 = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			struct68_0 = default(Struct68);
			int_0 = -2;
		}

		private bool MoveNext()
		{
			int num = int_0;
			NmdExporter nmdExporter = nmdExporter_0;
			string path;
			string path2;
			switch (num)
			{
			default:
				return false;
			case 0:
				int_0 = -1;
				struct68_0.string_0 = nmdExporter.paramsClass_0.ClientPath;
				if (string.IsNullOrWhiteSpace(struct68_0.string_0) && !string.IsNullOrWhiteSpace(nmdExporter.paramsClass_0.ElementsPath))
				{
					string directoryName = System.IO.Path.GetDirectoryName(nmdExporter.paramsClass_0.ElementsPath);
					if (!string.IsNullOrWhiteSpace(directoryName))
					{
						struct68_0.string_0 = System.IO.Path.GetFullPath(System.IO.Path.Combine(directoryName, Class16.smethod_0(1649116051)));
					}
				}
				if (nmdExporter.paramsClass_0.UsePck && nmdExporter.pck_LIST_0 != null)
				{
					byte_0 = nmdExporter.pck_LIST_0.GetFileB(Class16.smethod_0(1649116068));
					int_0 = 1;
					return true;
				}
				goto IL_0115;
			case 1:
				int_0 = -1;
				byte_0 = nmdExporter.pck_LIST_0.GetFileB(Class16.smethod_0(1649116102));
				int_0 = 2;
				return true;
			case 2:
				int_0 = -1;
				goto IL_0115;
			case 3:
				int_0 = -1;
				goto IL_015f;
			case 4:
				int_0 = -1;
				goto IL_01a8;
			case 5:
				{
					int_0 = -1;
					break;
				}
				IL_015f:
				path = smethod_4(System.IO.Path.Combine(Class16.smethod_0(1648991932), Class16.smethod_0(1648997579)), ref struct68_0);
				if (File.Exists(path))
				{
					byte_0 = File.ReadAllBytes(path);
					int_0 = 4;
					return true;
				}
				goto IL_01a8;
				IL_0115:
				if (!string.IsNullOrWhiteSpace(nmdExporter.paramsClass_0.PathDataPath) && File.Exists(nmdExporter.paramsClass_0.PathDataPath))
				{
					byte_0 = File.ReadAllBytes(nmdExporter.paramsClass_0.PathDataPath);
					int_0 = 3;
					return true;
				}
				goto IL_015f;
				IL_01a8:
				path2 = smethod_4(System.IO.Path.Combine(Class16.smethod_0(1649145044), Class16.smethod_0(1648908925)), ref struct68_0);
				if (File.Exists(path2))
				{
					byte_0 = File.ReadAllBytes(path2);
					int_0 = 5;
					return true;
				}
				break;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<byte[]> IEnumerable<byte[]>.GetEnumerator()
		{
			Class244 @class;
			if (int_0 == -2 && int_1 == Environment.CurrentManagedThreadId)
			{
				int_0 = 0;
				@class = this;
			}
			else
			{
				@class = new Class244(0);
				@class.nmdExporter_0 = nmdExporter_0;
			}
			return @class;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<byte[]>)this).GetEnumerator();
		}
	}

	[Serializable]
	private sealed class Class245
	{
		public static readonly Class245 class245_0 = new Class245();

		public static Func<KeyValuePair<int, List<Class242>>, int> func_0;

		internal int method_0(KeyValuePair<int, List<Class242>> keyValuePair_0)
		{
			return keyValuePair_0.Key;
		}
	}

	private sealed class Class246
	{
		public Struct67 struct67_0;

		public float float_0;

		public List<Class241> list_0 = new List<Class241>();

		public List<Class243> list_1 = new List<Class243>();
	}

	private readonly eListCollection eListCollection_0;

	private readonly PCK_LIST pck_LIST_0;

	private readonly ParamsClass paramsClass_0;

	private readonly PATH_DATA path_DATA_0;

	private static readonly Encoding encoding_0 = Encoding.GetEncoding(Class16.smethod_0(1648985403));

	public NmdExporter(eListCollection data, PCK_LIST pcks, ParamsClass @params, PATH_DATA pathData)
	{
		eListCollection_0 = data ?? throw new ArgumentNullException(Class16.smethod_0(1649116115));
		pck_LIST_0 = pcks;
		paramsClass_0 = @params ?? throw new ArgumentNullException(Class16.smethod_0(1649116134));
		path_DATA_0 = pathData;
	}

	public NmdExportResult Export(string outputPath)
	{
		if (string.IsNullOrWhiteSpace(outputPath))
		{
			throw new ArgumentNullException(Class16.smethod_0(1649116137));
		}
		NmdExportResult nmdExportResult = new NmdExportResult();
		Dictionary<int, List<Class242>> dictionary = method_0(nmdExportResult);
		Dictionary<int, List<Class242>> dictionary2 = method_2(nmdExportResult);
		if (dictionary.Count == 0 && dictionary2.Count == 0)
		{
			nmdExportResult.ErrorMessage = Class16.smethod_0(1649116156);
			return nmdExportResult;
		}
		string directoryName = System.IO.Path.GetDirectoryName(outputPath);
		if (!string.IsNullOrEmpty(directoryName) && !Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
		method_9(outputPath, dictionary, dictionary2);
		nmdExportResult.Success = true;
		nmdExportResult.OutputPath = outputPath;
		nmdExportResult.NpcMineCount = dictionary.Count;
		nmdExportResult.DynamicCount = dictionary2.Count;
		return nmdExportResult;
	}

	private Dictionary<int, List<Class242>> method_0(NmdExportResult nmdExportResult_0)
	{
		Dictionary<int, List<Class242>> dictionary = new Dictionary<int, List<Class242>>();
		method_1(Class16.smethod_0(1648960167), dictionary, nmdExportResult_0.FailedNpcMine, nmdExportResult_0);
		method_1(Class16.smethod_0(1648963535), dictionary, nmdExportResult_0.FailedNpcMine, nmdExportResult_0);
		return dictionary;
	}

	private void method_1(string string_0, Dictionary<int, List<Class242>> dictionary_0, List<int> list_0, NmdExportResult nmdExportResult_0)
	{
		int num = eListCollection_0.get_LI(string_0);
		if (num < 0)
		{
			return;
		}
		eList eList2 = eListCollection_0[num];
		if (eList2 == null || eList2.elementValues == null || eList2.IDs == null)
		{
			return;
		}
		int num2 = eList2.get_fields(Class16.smethod_0(1649078528));
		if (num2 < 0)
		{
			return;
		}
		for (int i = 0; i < eList2.ItemCount; i++)
		{
			int num3 = eList2.IDs[i];
			object object_ = eList2.elementValues[i][num2];
			string text = method_8(object_, num3, string_0);
			if (string.IsNullOrWhiteSpace(text))
			{
				continue;
			}
			if (!method_5(text, num3, out var list_1, out var string_1))
			{
				list_0?.Add(num3);
				if (nmdExportResult_0 != null && !string.IsNullOrEmpty(string_1))
				{
					nmdExportResult_0.Errors.Add(string_1);
				}
			}
			else if (list_1 != null && list_1.Count > 0)
			{
				dictionary_0[num3] = list_1;
			}
		}
	}

	private Dictionary<int, List<Class242>> method_2(NmdExportResult nmdExportResult_0)
	{
		Dictionary<uint, string> dictionary = method_3();
		Dictionary<int, List<Class242>> dictionary2 = new Dictionary<int, List<Class242>>();
		foreach (KeyValuePair<uint, string> item in dictionary)
		{
			string value = item.Value;
			if (string.IsNullOrWhiteSpace(value))
			{
				continue;
			}
			if (!method_5(value, (int)item.Key, out var list_, out var string_))
			{
				nmdExportResult_0.FailedDynamic.Add((int)item.Key);
				if (!string.IsNullOrEmpty(string_))
				{
					nmdExportResult_0.Errors.Add(string_);
				}
			}
			else if (list_ != null && list_.Count > 0)
			{
				dictionary2[(int)item.Key] = list_;
			}
		}
		return dictionary2;
	}

	private Dictionary<uint, string> method_3()
	{
		if (path_DATA_0 != null && path_DATA_0.Paths != null && path_DATA_0.Paths.Count > 0)
		{
			return new Dictionary<uint, string>(path_DATA_0.Paths);
		}
		foreach (byte[] item in method_4())
		{
			if (item != null && item.Length >= 8 && smethod_0(item, out var dictionary_) && dictionary_.Count > 0)
			{
				return dictionary_;
			}
		}
		return new Dictionary<uint, string>();
	}

	private IEnumerable<byte[]> method_4()
	{
		return new Class244(-2)
		{
			nmdExporter_0 = this
		};
	}

	private static bool smethod_0(byte[] byte_0, out Dictionary<uint, string> dictionary_0)
	{
		return PATH_DATA.TryRead(byte_0, out dictionary_0);
	}

	private bool method_5(string string_0, int int_0, out List<Class242> list_0, out string string_1)
	{
		list_0 = null;
		string_1 = null;
		if (!smethod_1(string_0, out var string_2))
		{
			string_1 = string.Format(Class16.smethod_0(1649115162), int_0, string_0);
			return false;
		}
		byte[] array = method_6(string_2);
		if (array != null && array.Length != 0)
		{
			if (!method_7(array, out list_0, out string_1))
			{
				return false;
			}
			if (list_0 != null && list_0.Count != 0)
			{
				return true;
			}
			string_1 = string.Format(Class16.smethod_0(1649115201), int_0, string_2);
			return false;
		}
		return false;
	}

	private byte[] method_6(string string_0)
	{
		string text = string_0.Replace('/', '\\');
		if (paramsClass_0.UsePck && pck_LIST_0 != null)
		{
			byte[] fileB = pck_LIST_0.GetFileB(text);
			if (fileB == null)
			{
				string path = text.Replace('\\', '/');
				fileB = pck_LIST_0.GetFileB(path);
			}
			if (fileB != null)
			{
				return fileB;
			}
		}
		string path2 = text;
		if (!System.IO.Path.IsPathRooted(path2))
		{
			string text2 = paramsClass_0.ClientPath;
			if (string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(paramsClass_0.ElementsPath))
			{
				string directoryName = System.IO.Path.GetDirectoryName(paramsClass_0.ElementsPath);
				if (!string.IsNullOrWhiteSpace(directoryName))
				{
					text2 = System.IO.Path.GetFullPath(System.IO.Path.Combine(directoryName, Class16.smethod_0(1649116051)));
				}
			}
			if (!string.IsNullOrWhiteSpace(text2))
			{
				path2 = System.IO.Path.Combine(text2, text);
			}
		}
		if (!File.Exists(path2))
		{
			return null;
		}
		return File.ReadAllBytes(path2);
	}

	private static bool smethod_1(string string_0, out string string_1)
	{
		string_1 = null;
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return false;
		}
		string text = string_0.Trim().Replace('/', '\\').ToLowerInvariant();
		if (!text.StartsWith(Class16.smethod_0(1649116763), StringComparison.Ordinal))
		{
			return false;
		}
		if (!text.EndsWith(Class16.smethod_0(1648906325), StringComparison.Ordinal))
		{
			return false;
		}
		string text2 = text.Substring(7, text.Length - 7 - 4);
		string_1 = Class16.smethod_0(1649115262) + text2 + Class16.smethod_0(1649115281);
		return true;
	}

	private bool method_7(byte[] byte_0, out List<Class242> list_0, out string string_0)
	{
		list_0 = null;
		string_0 = null;
		try
		{
			MemoryStream memoryStream = new MemoryStream(byte_0);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.ASCII, leaveOpen: false);
				try
				{
					uint num = binaryReader.ReadUInt32();
					binaryReader.ReadUInt32();
					uint num2 = binaryReader.ReadUInt32();
					binaryReader.ReadBytes(260);
					binaryReader.ReadInt32();
					uint num3 = binaryReader.ReadUInt32();
					if (num2 == 1 && num == 1113083725)
					{
						List<Class242> list = new List<Class242>((int)num3);
						for (uint num4 = 0u; num4 < num3; num4++)
						{
							Class242 @class = smethod_2(binaryReader);
							if (@class != null && !@class.method_0())
							{
								@class.method_1();
								list.Add(@class);
							}
						}
						list_0 = list;
						return true;
					}
					string_0 = string.Format(Class16.smethod_0(1649115300), num2);
					return false;
				}
				finally
				{
					((IDisposable)binaryReader).Dispose();
				}
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649115340));
			string_0 = ex.Message;
			return false;
		}
	}

	private string method_8(object object_0, int int_0, string string_0)
	{
		if (object_0 == null)
		{
			return null;
		}
		if (object_0 is string text)
		{
			string text2 = text.Trim();
			if (!string.IsNullOrEmpty(text2) && !(text2 == Class16.smethod_0(1648924112)))
			{
				return text2;
			}
			return null;
		}
		if (object_0 is byte[] bytes)
		{
			string text3 = encoding_0.GetString(bytes).Trim('\0', ' ');
			if (!string.IsNullOrEmpty(text3) && !(text3 == Class16.smethod_0(1648924112)))
			{
				return text3;
			}
			return null;
		}
		return null;
	}

	private static Class242 smethod_2(BinaryReader binaryReader_0)
	{
		byte[] array = binaryReader_0.ReadBytes(41);
		if (array.Length < 41)
		{
			return null;
		}
		string text = Encoding.ASCII.GetString(array).TrimEnd(default(char));
		int num = 0;
		if (text.Length > 3 && text[3] == '2')
		{
			num = 2;
		}
		else if (text.Length > 3 && text[3] == '1')
		{
			num = 1;
		}
		int int_ = 0;
		if (num >= 1)
		{
			int_ = binaryReader_0.ReadInt32();
		}
		Class242 @class = new Class242
		{
			string_0 = text,
			int_0 = num,
			int_1 = int_,
			int_2 = binaryReader_0.ReadInt32()
		};
		int num2 = binaryReader_0.ReadInt32();
		for (int i = 0; i < num2; i++)
		{
			float float_ = binaryReader_0.ReadSingle();
			float float_2 = binaryReader_0.ReadSingle();
			float float_3 = binaryReader_0.ReadSingle();
			@class.list_0.Add(new Struct67(float_, float_2, float_3));
		}
		int num3 = binaryReader_0.ReadInt32();
		for (int j = 0; j < num3; j++)
		{
			Class246 class2 = new Class246
			{
				struct67_0 = new Struct67(binaryReader_0.ReadSingle(), binaryReader_0.ReadSingle(), binaryReader_0.ReadSingle()),
				float_0 = binaryReader_0.ReadSingle()
			};
			int num4 = binaryReader_0.ReadInt32();
			for (int k = 0; k < num4; k++)
			{
				Class241 item = new Class241
				{
					int_0 = binaryReader_0.ReadInt32(),
					class243_0 = new Class243
					{
						struct67_0 = new Struct67(binaryReader_0.ReadSingle(), binaryReader_0.ReadSingle(), binaryReader_0.ReadSingle()),
						float_0 = binaryReader_0.ReadSingle()
					}
				};
				class2.list_0.Add(item);
			}
			if (num > 1)
			{
				int num5 = binaryReader_0.ReadInt32();
				for (int l = 0; l < num5; l++)
				{
					Class243 item2 = new Class243
					{
						struct67_0 = new Struct67(binaryReader_0.ReadSingle(), binaryReader_0.ReadSingle(), binaryReader_0.ReadSingle()),
						float_0 = binaryReader_0.ReadSingle()
					};
					class2.list_1.Add(item2);
				}
			}
			@class.list_1.Add(class2);
		}
		return @class;
	}

	private void method_9(string string_0, Dictionary<int, List<Class242>> dictionary_0, Dictionary<int, List<Class242>> dictionary_1)
	{
		using FileStream output = File.Open(string_0, FileMode.Create, FileAccess.Write, FileShare.None);
		BinaryWriter binaryWriter = new BinaryWriter(output, Encoding.ASCII, leaveOpen: false);
		try
		{
			binaryWriter.Write(1852662886u);
			binaryWriter.Write(1u);
			binaryWriter.Write(0u);
			binaryWriter.Write((uint)eListCollection_0.Version);
			smethod_3(binaryWriter, dictionary_0);
			smethod_3(binaryWriter, dictionary_1);
			binaryWriter.Flush();
		}
		finally
		{
			((IDisposable)binaryWriter).Dispose();
		}
	}

	private static void smethod_3(BinaryWriter binaryWriter_0, Dictionary<int, List<Class242>> dictionary_0)
	{
		binaryWriter_0.Write(dictionary_0.Count);
		foreach (KeyValuePair<int, List<Class242>> item in dictionary_0.OrderBy(Class245.class245_0.method_0))
		{
			binaryWriter_0.Write(item.Key);
			binaryWriter_0.Write(item.Value.Count);
			foreach (Class242 item2 in item.Value)
			{
				item2.method_2(binaryWriter_0);
			}
		}
	}

	[CompilerGenerated]
	internal static string smethod_4(string relative, ref Struct68 A_1)
	{
		if (!string.IsNullOrWhiteSpace(A_1.string_0))
		{
			return System.IO.Path.Combine(A_1.string_0, relative);
		}
		return relative;
	}
}
