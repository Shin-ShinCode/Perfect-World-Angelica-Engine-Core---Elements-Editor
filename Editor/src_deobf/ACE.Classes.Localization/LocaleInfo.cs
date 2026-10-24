using System;
using System.Runtime.CompilerServices;

namespace ACE.Classes.Localization;

public class LocaleInfo
{
	private int int_0;

	private string string_0 = Class16.smethod_0(1648931959);

	private string string_1 = Class16.smethod_0(1648899236);

	private string string_2 = Class16.smethod_0(1648931959);

	private string[] string_3 = Array.Empty<string>();

	public int Index
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

	public string DisplayName
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

	public string Fallback
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	public string[] LegacyPrefixes
	{
		[CompilerGenerated]
		get
		{
			return string_3;
		}
		[CompilerGenerated]
		set
		{
			string_3 = value;
		}
	}
}
