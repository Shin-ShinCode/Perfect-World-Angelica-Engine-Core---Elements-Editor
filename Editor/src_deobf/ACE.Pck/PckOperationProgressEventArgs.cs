using System;
using System.Runtime.CompilerServices;

namespace ACE.Pck;

public class PckOperationProgressEventArgs : EventArgs
{
	private PckOperationStage pckOperationStage_0;

	private int int_0;

	private int int_1;

	private long long_0;

	private long long_1;

	private string string_0 = string.Empty;

	private string string_1 = string.Empty;

	private bool bool_0;

	public PckOperationStage Stage
	{
		[CompilerGenerated]
		get
		{
			return pckOperationStage_0;
		}
		[CompilerGenerated]
		set
		{
			pckOperationStage_0 = value;
		}
	}

	public int CurrentIndex
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int TotalCount
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public long ProcessedBytes
	{
		[CompilerGenerated]
		get
		{
			return long_0;
		}
		[CompilerGenerated]
		set
		{
			long_0 = value;
		}
	}

	public long TotalBytes
	{
		[CompilerGenerated]
		get
		{
			return long_1;
		}
		[CompilerGenerated]
		set
		{
			long_1 = value;
		}
	}

	public string CurrentFile
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

	public string StatusMessage
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public bool IsCancellationRequested
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

	public double ProgressPercentage
	{
		get
		{
			if (TotalCount <= 0)
			{
				return 0.0;
			}
			return (double)CurrentIndex / (double)TotalCount * 100.0;
		}
	}

	public int ProcessedMB => (int)(ProcessedBytes / 1048576L);

	public int TotalMB => (int)(TotalBytes / 1048576L);
}
