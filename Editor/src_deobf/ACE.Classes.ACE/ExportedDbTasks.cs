using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.Classes.ACE;

public class ExportedDbTasks
{
	private List<ExportedTask> list_0;

	public List<ExportedTask> tasks
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

	public ExportedDbTasks(List<ExportedTask> tasks)
	{
		this.tasks = tasks;
	}

	public void SaveToJsonFiles(string path, IDictionary<int, ATaskTempl> datas)
	{
		throw new NotSupportedException();
	}
}
