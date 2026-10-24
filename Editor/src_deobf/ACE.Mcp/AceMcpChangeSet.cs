using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACE.Mcp;

internal sealed class AceMcpChangeSet
{
	private string string_0;

	private string string_1;

	private readonly List<IAceMcpChangeOperation> list_0 = new List<IAceMcpChangeOperation>();

	private readonly Dictionary<string, string> dictionary_0 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

	private readonly List<string> list_1 = new List<string>();

	private bool bool_0 = true;

	public string Id
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

	public string CreatedAtUtc
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

	public List<IAceMcpChangeOperation> Operations
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
	}

	public Dictionary<string, string> SourceFingerprints
	{
		[CompilerGenerated]
		get
		{
			return dictionary_0;
		}
	}

	public List<string> Warnings
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
	}

	public bool ExpiresOnReload
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
}
