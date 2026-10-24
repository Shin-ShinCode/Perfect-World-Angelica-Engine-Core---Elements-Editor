using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACE.EcmEditor.Services;

public class EcmPckOpenResult
{
	private bool bool_0;

	private EcmPckKey ecmPckKey_0;

	private EcmPckPathFormat ecmPckPathFormat_0 = EcmPckPathFormat.Standard256;

	private string string_0 = string.Empty;

	private List<string> list_0 = new List<string>();

	private bool bool_1;

	public bool Success
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

	public EcmPckKey DetectedKey
	{
		[CompilerGenerated]
		get
		{
			return ecmPckKey_0;
		}
		[CompilerGenerated]
		set
		{
			ecmPckKey_0 = value;
		}
	}

	public EcmPckPathFormat PathFormat
	{
		[CompilerGenerated]
		get
		{
			return ecmPckPathFormat_0;
		}
		[CompilerGenerated]
		set
		{
			ecmPckPathFormat_0 = value;
		}
	}

	public string ErrorMessage
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

	public List<string> TriedKeys
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

	public bool HasPkxFiles
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}
}
