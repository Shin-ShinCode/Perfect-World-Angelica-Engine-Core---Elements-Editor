using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACE.Mcp;

internal sealed class AceMcpCommandResult
{
	private object object_0;

	private readonly List<string> list_0 = new List<string>();

	private readonly List<IAceMcpChangeOperation> list_1 = new List<IAceMcpChangeOperation>();

	private string string_0;

	public object Data
	{
		[CompilerGenerated]
		get
		{
			return object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	public List<string> Warnings
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
	}

	public List<IAceMcpChangeOperation> Operations
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
	}

	public string PreferredDomain
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

	public bool HasOperations => Operations.Count > 0;
}
