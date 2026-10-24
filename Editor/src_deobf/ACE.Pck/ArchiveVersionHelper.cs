namespace ACE.Pck;

public static class ArchiveVersionHelper
{
	public static int GetEntrySize(this ArchiveVersion version)
	{
		if (version != ArchiveVersion.V3)
		{
			return 276;
		}
		return 288;
	}

	public static int GetFooterSize(this ArchiveVersion version)
	{
		if (version != ArchiveVersion.V3)
		{
			return 280;
		}
		return 288;
	}

	public static int GetEntryOffsetPosition(this ArchiveVersion version)
	{
		if (version != ArchiveVersion.V3)
		{
			return 272;
		}
		return 280;
	}

	public static int GetHeaderSize(this ArchiveVersion version)
	{
		if (version != ArchiveVersion.V3)
		{
			return 12;
		}
		return 16;
	}

	public static uint GetVersionValue(this ArchiveVersion version)
	{
		if (version != ArchiveVersion.V3)
		{
			return 131074u;
		}
		return 131075u;
	}

	public static ArchiveVersion FromVersionValue(uint versionValue)
	{
		int num = (int)(versionValue & 0xFFFF);
		if (num != 3)
		{
			return ArchiveVersion.V2;
		}
		return ArchiveVersion.V3;
	}
}
