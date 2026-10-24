using System;
using ACE.Protectors;

namespace ACE.Pck;

public class PckExtractorProgressEventArgs : EventArgs
{
	public PckExtractorStage Stage;

	public int CurrentIndex;

	public int TotalCount;

	public long PassedSize;

	public long TotalSize;

	public string CurrentDir;

	public long PrevSize;

	public int TotalSizeMB => (int)(TotalSize / 1048576L);

	public int PassedSizeMB => (int)(PassedSize / 1048576L);

	public PckExtractorProgressEventArgs(int TotalCount, long TotalSize)
	{
		this.TotalCount = TotalCount;
		this.TotalSize = TotalSize;
	}

	public PckExtractorProgressEventArgs()
	{
	}
}
