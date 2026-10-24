using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.PWMap;

public sealed class PwMapFileLayout
{
	private string string_0 = string.Empty;

	private string string_1 = string.Empty;

	private string string_2 = string.Empty;

	private string string_3 = string.Empty;

	private string string_4 = string.Empty;

	private string string_5 = string.Empty;

	private string string_6 = string.Empty;

	private string string_7 = string.Empty;

	private string string_8 = string.Empty;

	private string string_9 = string.Empty;

	private string string_10 = string.Empty;

	private string string_11 = string.Empty;

	private string string_12 = string.Empty;

	private List<string> list_0 = new List<string>();

	public string MapRootPath
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

	public string MapName
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

	public string RegionFile
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

	public string PrecinctFile
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

	public string PathDataFile
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

	public string DynamicObjectsFile
	{
		[CompilerGenerated]
		get
		{
			return string_5;
		}
		[CompilerGenerated]
		set
		{
			string_5 = value;
		}
	}

	public string Domain2File
	{
		[CompilerGenerated]
		get
		{
			return string_6;
		}
		[CompilerGenerated]
		set
		{
			string_6 = value;
		}
	}

	public string WorldFile
	{
		[CompilerGenerated]
		get
		{
			return string_7;
		}
		[CompilerGenerated]
		set
		{
			string_7 = value;
		}
	}

	public string Trn2File
	{
		[CompilerGenerated]
		get
		{
			return string_8;
		}
		[CompilerGenerated]
		set
		{
			string_8 = value;
		}
	}

	public string EcwldFile
	{
		[CompilerGenerated]
		get
		{
			return string_9;
		}
		[CompilerGenerated]
		set
		{
			string_9 = value;
		}
	}

	public string EcbsdFile
	{
		[CompilerGenerated]
		get
		{
			return string_10;
		}
		[CompilerGenerated]
		set
		{
			string_10 = value;
		}
	}

	public string LitmodelsFolder
	{
		[CompilerGenerated]
		get
		{
			return string_11;
		}
		[CompilerGenerated]
		set
		{
			string_11 = value;
		}
	}

	public string BsdataFolder
	{
		[CompilerGenerated]
		get
		{
			return string_12;
		}
		[CompilerGenerated]
		set
		{
			string_12 = value;
		}
	}

	public List<string> TextureFiles
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

	public bool HasMapRoot
	{
		get
		{
			if (!string.IsNullOrWhiteSpace(MapRootPath))
			{
				return Directory.Exists(MapRootPath);
			}
			return false;
		}
	}
}
