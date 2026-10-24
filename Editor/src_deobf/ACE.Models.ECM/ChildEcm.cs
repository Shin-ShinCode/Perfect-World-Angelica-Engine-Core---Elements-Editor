using System.Runtime.CompilerServices;

namespace ACE.Models.ECM;

public class ChildEcm
{
	private string string_0;

	private string string_1;

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

	public string HookName
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
}
