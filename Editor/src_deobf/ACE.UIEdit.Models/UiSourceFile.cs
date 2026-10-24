using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.UIEdit.Models;

internal sealed class UiSourceFile
{
	private string string_0 = string.Empty;

	private string string_1 = string.Empty;

	private bool bool_0;

	private string string_2 = Class16.smethod_0(1648898319);

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

	public string RootPath
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

	public bool HasBom
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

	public string EncodingName
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

	public string FileName => System.IO.Path.GetFileName(FilePath);

	public string RelativeDirectory
	{
		get
		{
			if (string.IsNullOrWhiteSpace(RootPath))
			{
				string directoryName = System.IO.Path.GetDirectoryName(FilePath);
				if (string.IsNullOrWhiteSpace(directoryName))
				{
					return Class16.smethod_0(1648927580);
				}
				return Class16.smethod_0(1648927580) + directoryName.Replace('/', '\\').TrimStart('\\');
			}
			string directoryName2 = System.IO.Path.GetDirectoryName(FilePath);
			if (string.IsNullOrWhiteSpace(directoryName2))
			{
				return Class16.smethod_0(1648927580);
			}
			if (!directoryName2.StartsWith(RootPath, StringComparison.OrdinalIgnoreCase))
			{
				return Class16.smethod_0(1648927580);
			}
			string text = directoryName2.Substring(RootPath.Length).TrimStart('\\', '/');
			if (text.Length != 0)
			{
				return Class16.smethod_0(1648927580) + text.Replace('/', '\\');
			}
			return Class16.smethod_0(1648927580);
		}
	}

	public string DisplayPath
	{
		get
		{
			if (RelativeDirectory == Class16.smethod_0(1648927580))
			{
				return FileName;
			}
			string text = RelativeDirectory.TrimStart('\\');
			return text + Class16.smethod_0(1648927580) + FileName;
		}
	}

	public override string ToString()
	{
		return DisplayPath;
	}
}
