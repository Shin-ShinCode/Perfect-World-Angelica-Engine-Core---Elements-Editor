using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.Classes;

public class TranslationSettings
{
	private TranslationProvider translationProvider_0;

	private string string_0 = Class16.smethod_0(1649252021);

	private string string_1 = string.Empty;

	private string string_2 = Class16.smethod_0(1648897915);

	private string string_3 = Class16.smethod_0(1649156964);

	private bool bool_0;

	public TranslationProvider Provider
	{
		[CompilerGenerated]
		get
		{
			return translationProvider_0;
		}
		[CompilerGenerated]
		set
		{
			translationProvider_0 = value;
		}
	}

	public string LibreTranslateEndpoint
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

	public string DeepLApiKey
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

	public string SourceLanguage
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

	public string TargetLanguage
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

	public bool EnableAutoTranslation
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}
}
