using System.Runtime.CompilerServices;

namespace ACE.PWMap;

public abstract class PwMapChangeItem
{
	private readonly string string_0;

	public string Description
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
	}

	protected PwMapChangeItem(string description)
	{
		string_0 = description ?? Class16.smethod_0(1648970834);
	}

	public abstract void Apply();

	public abstract void Revert();
}
