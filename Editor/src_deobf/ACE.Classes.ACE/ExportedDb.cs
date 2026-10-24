using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACE.Classes.ACE;

public class ExportedDb
{
	private List<ExportedList> list_0;

	private Dictionary<string, string> dictionary_0;

	public List<ExportedList> lists
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

	public ExportedDb(List<ExportedList> lists, Dictionary<string, string> listsTranslation)
	{
		this.lists = lists;
		this.listsTranslation = listsTranslation;
	}

	public void SaveToJsonFile(string fileName)
	{
		throw new NotSupportedException();
	}

	public void SaveToJsonFiles(string path)
	{
		throw new NotSupportedException();
	}

	public void SaveToSqlFile(string fileName)
	{
		throw new NotImplementedException();
	}
}
