using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACE.AIPolicyEditor.AIPolicy;

public class OperationImportResult
{
	private int int_0;

	private List<IOperation> list_0;

	public int TriggerVersion
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

	public List<IOperation> Operations
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
