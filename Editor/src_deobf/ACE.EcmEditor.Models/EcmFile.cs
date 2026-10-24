using System.Runtime.CompilerServices;

namespace ACE.EcmEditor.Models;

public class EcmFile
{
	private string string_0 = string.Empty;

	private string string_1 = string.Empty;

	private string string_2 = string.Empty;

	private EcmGender ecmGender_0 = EcmGender.Unisex;

	private EcmScriptData ecmScriptData_0;

	private string string_3 = string.Empty;

	private string string_4 = string.Empty;

	public string FilePath
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

	public string FileName
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

	public string ClassName
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

	public EcmGender Gender
	{
		[CompilerGenerated]
		get
		{
			return ecmGender_0;
		}
		[CompilerGenerated]
		set
		{
			ecmGender_0 = value;
		}
	}

	public EcmScriptData ScriptData
	{
		[CompilerGenerated]
		get
		{
			return ecmScriptData_0;
		}
		[CompilerGenerated]
		set
		{
			ecmScriptData_0 = value;
		}
	}

	public string OriginalContent
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

	public string CurrentContent
	{
		[CompilerGenerated]
		get
		{
			return string_4;
		}
		[CompilerGenerated]
		set
		{
			string_4 = value;
		}
	}

	public string DisplayName
	{
		get
		{
			string text = Gender switch
			{
				EcmGender.Female => Class16.smethod_0(1648995835), 
				EcmGender.Male => Class16.smethod_0(1648995827), 
				_ => string.Empty, 
			};
			if (string.IsNullOrEmpty(text))
			{
				return FileName + Class16.smethod_0(1648942627) + ClassName;
			}
			return FileName + Class16.smethod_0(1648942627) + ClassName + Class16.smethod_0(1648899468) + text + Class16.smethod_0(1648942897);
		}
	}

	public bool IsModified => OriginalContent != CurrentContent;

	public override string ToString()
	{
		return DisplayName;
	}
}
