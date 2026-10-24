using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACE.Classes.ACE;

public class ExportedDbSeparated
{
	private List<string> list_0;

	private Dictionary<string, string> dictionary_0;

	public List<string> listsFiles
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

	public Dictionary<string, string> listsTranslation
	{
		[CompilerGenerated]
		get
		{
			return dictionary_0;
		}
		[CompilerGenerated]
		set
		{
			dictionary_0 = value;
		}
	}

	public ExportedDbSeparated(List<string> listsFiles, Dictionary<string, string> listsTranslation)
	{
		this.listsFiles = listsFiles;
		this.listsTranslation = listsTranslation;
	}
}
