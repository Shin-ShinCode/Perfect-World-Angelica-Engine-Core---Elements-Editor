using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACE.DynTasks;

public sealed class DynTasksSnapshot
{
	private string string_0 = string.Empty;

	private bool bool_0;

	private bool bool_1;

	private uint uint_0;

	private uint uint_1;

	private short short_0;

	private List<DYN_TASKS.DynTaskTmpl> list_0 = new List<DYN_TASKS.DynTaskTmpl>();

	public string FileName
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public bool FileLoaded
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public bool FileChanged
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public uint DataSize
	{
		[CompilerGenerated]
		get
		{
			return uint_0;
		}
		[CompilerGenerated]
		set
		{
			uint_0 = value;
		}
	}

	public uint TimeMark
	{
		[CompilerGenerated]
		get
		{
			return uint_1;
		}
		[CompilerGenerated]
		set
		{
			uint_1 = value;
		}
	}

	public short Version
	{
		[CompilerGenerated]
		get
		{
			return short_0;
		}
		[CompilerGenerated]
		set
		{
			short_0 = value;
		}
	}

	public List<DYN_TASKS.DynTaskTmpl> Tasks
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}
}
