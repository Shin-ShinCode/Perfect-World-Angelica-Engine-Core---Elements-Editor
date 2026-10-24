using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.Classes;

internal class DGW_Prop_Row
{
	private string string_0;

	private string string_1;

	public string Prop
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

	public string Val
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

	public DGW_Prop_Row(string prop, string val)
	{
		Prop = prop;
		Val = val;
	}
}
