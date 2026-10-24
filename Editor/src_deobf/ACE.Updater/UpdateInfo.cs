using System;
using System.Runtime.CompilerServices;

namespace ACE.Updater;

internal sealed class UpdateInfo
{
	private readonly Version version_0;

	private readonly string string_0;

	private readonly string string_1;

	private readonly string string_2;

	private readonly string string_3;

	private readonly string string_4;

	private readonly long long_0;

	public Version RemoteVersion
	{
		[CompilerGenerated]
		get
		{
			return version_0;
		}
	}

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
	}

	public string Url
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
	}

	public string Flags
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
	}

	public string Description
	{
		[CompilerGenerated]
		get
		{
			return string_3;
		}
	}

	public string Md5
	{
		[CompilerGenerated]
		get
		{
			return string_4;
		}
	}

	public long Size
	{
		[CompilerGenerated]
		get
		{
			return long_0;
		}
	}

	public UpdateInfo(Version remoteVersion, string name, string url, string flags, string description, string md5, long size)
	{
		version_0 = remoteVersion;
		string_0 = name ?? string.Empty;
		string_1 = url ?? string.Empty;
		string_2 = flags ?? string.Empty;
		string_3 = description ?? string.Empty;
		string_4 = md5 ?? string.Empty;
		long_0 = size;
	}
}
