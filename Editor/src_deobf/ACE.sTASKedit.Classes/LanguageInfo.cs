using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.Classes;

public class LanguageInfo
{
	private string string_0;

	private string string_1;

	public string Code
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

	public string Name
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

	public LanguageInfo(string code, string name)
	{
		Code = code;
		Name = name;
	}

	public override string ToString()
	{
		return Name + Class16.smethod_0(1648899468) + Code + Class16.smethod_0(1648942897);
	}
}
