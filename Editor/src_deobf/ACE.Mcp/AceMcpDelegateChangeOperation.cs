using System;
using System.Runtime.CompilerServices;

namespace ACE.Mcp;

internal sealed class AceMcpDelegateChangeOperation : IAceMcpChangeOperation
{
	private readonly Action action_0;

	private readonly object object_0;

	private readonly string string_0;

	private readonly string string_1;

	public string Domain
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
	}

	public string OperationType
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
	}

	public AceMcpDelegateChangeOperation(string domain, string operationType, object preview, Action apply)
	{
		string_0 = domain;
		string_1 = operationType;
		object_0 = preview;
		action_0 = apply;
	}

	public object Describe()
	{
		return object_0;
	}

	public void Apply()
	{
		action_0();
	}
}
