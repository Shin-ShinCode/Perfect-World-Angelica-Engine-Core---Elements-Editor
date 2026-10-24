#nullable enable annotations
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACE.Classes.ACE;

public class ExportedList
{
	private string string_0;

	private int int_0;

	private bool bool_0;

	private string? string_1;

	private string? string_2;

	private List<ExportedItem> list_0;

	private Dictionary<string, string> dictionary_0;

	public string name
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

	public int index
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

	public bool isMatter
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

	public string? typesList
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

	public string? subtypesList
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

	public List<ExportedItem> items
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

	public Dictionary<string, string> fieldsTranslation
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

	public ExportedList(string name, int index, bool isMatter, string? typesList, string? subtypesList, List<ExportedItem> items, Dictionary<string, string> fieldsTranslation)
	{
		this.name = name;
		this.index = index;
		this.isMatter = isMatter;
		this.typesList = typesList;
		this.subtypesList = subtypesList;
		this.items = items;
		this.fieldsTranslation = fieldsTranslation;
	}

	public void SaveToJsonFile(string fileName)
	{
		throw new NotSupportedException();
	}
}
