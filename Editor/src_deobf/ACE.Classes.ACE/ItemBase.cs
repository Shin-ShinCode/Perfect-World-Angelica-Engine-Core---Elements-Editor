using System.Runtime.CompilerServices;

namespace ACE.Classes.ACE;

public class ItemBase
{
	private int int_0;

	private string string_0;

	private string string_1;

	public int id
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

	public string color
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

	public ItemBase(int id, string name, string color)
	{
		this.id = id;
		this.name = name;
		this.color = color;
	}
}
