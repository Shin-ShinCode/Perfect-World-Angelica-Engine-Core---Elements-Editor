#nullable enable annotations
using System.Runtime.CompilerServices;

namespace ACE.Classes.ACE;

public class ExportedTask
{
	private int int_0;

	private string string_0;

	public int taskId
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

	public string html
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

	public ExportedTask(int id, string name, string? color, int image, bool isSubQuest, string html, string file)
	{
		this.html = html;
	}
}
