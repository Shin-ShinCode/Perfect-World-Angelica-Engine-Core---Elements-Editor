using System.Drawing;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.Classes;

public class DGW_Element_Row
{
	private string string_0;

	private Image image_0;

	private string string_1;

	public string Id
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

	public Image Icon
	{
		[CompilerGenerated]
		get
		{
			return image_0;
		}
		[CompilerGenerated]
		set
		{
			image_0 = value;
		}
	}

	public string Name
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

	public DGW_Element_Row(string id, Image icon, string name)
	{
		Id = id;
		Icon = icon;
		Name = name;
	}
}
