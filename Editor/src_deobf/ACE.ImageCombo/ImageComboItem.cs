using System.Drawing;

namespace ACE.ImageCombo;

public class ImageComboItem
{
	private Color color_0 = Color.FromKnownColor(KnownColor.Transparent);

	private bool bool_0;

	private int int_0 = -1;

	private object object_0;

	private string string_0;

	public Color ForeColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	public int ImageIndex
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public bool Indicate
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public object Tag
	{
		get
		{
			return object_0;
		}
		set
		{
			object_0 = value;
		}
	}

	public string ItemText
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public ImageComboItem()
	{
	}

	public ImageComboItem(string Text)
	{
		string_0 = Text;
	}

	public ImageComboItem(string stText, int intImageIndex)
	{
		string_0 = stText;
		int_0 = intImageIndex;
	}

	public ImageComboItem(string stText, int intImageIndex, bool blnIndi)
	{
		string_0 = stText;
		int_0 = intImageIndex;
		bool_0 = blnIndi;
	}

	public ImageComboItem(string stText, int intImageIndex, bool blnIndi, Color clForeColor)
	{
		string_0 = stText;
		int_0 = intImageIndex;
		bool_0 = blnIndi;
		color_0 = clForeColor;
	}

	public ImageComboItem(string stText, int intImageIndex, bool blnIndi, Color clForeColor, object oTag)
	{
		string_0 = stText;
		int_0 = intImageIndex;
		bool_0 = blnIndi;
		color_0 = clForeColor;
		object_0 = oTag;
	}

	public override string ToString()
	{
		return string_0;
	}
}
