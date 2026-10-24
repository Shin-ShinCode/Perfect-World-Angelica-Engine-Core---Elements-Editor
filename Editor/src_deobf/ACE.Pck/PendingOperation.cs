using System.Runtime.CompilerServices;

namespace ACE.Pck;

internal class PendingOperation
{
	public enum OperationType
	{
		Add,
		Remove,
		Update
	}

	private OperationType operationType_0;

	private string string_0;

	public OperationType Type
	{
		[CompilerGenerated]
		get
		{
			return operationType_0;
		}
		[CompilerGenerated]
		set
		{
			operationType_0 = value;
		}
	}

	public string Path
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
}
