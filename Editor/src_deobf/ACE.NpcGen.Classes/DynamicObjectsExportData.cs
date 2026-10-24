using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACE.NpcGen.Classes;

public class DynamicObjectsExportData
{
	private string string_0;

	private string string_1;

	private DateTime dateTime_0;

	private List<ClassDynamicObject> list_0;

	public string Type
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

	public string Version
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

	public DateTime ExportDate
	{
		[CompilerGenerated]
		get
		{
			return dateTime_0;
		}
		[CompilerGenerated]
		set
		{
			dateTime_0 = value;
		}
	}

	public List<ClassDynamicObject> Data
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
}
