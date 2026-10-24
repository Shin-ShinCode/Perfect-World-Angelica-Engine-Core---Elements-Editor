using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ACE.UIEdit.Models;

internal sealed class UiControlModel
{
	private string string_0 = string.Empty;

	private string string_1 = string.Empty;

	private UiControlType uiControlType_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private bool bool_0;

	private bool bool_1;

	private int int_4;

	private int int_5;

	private int int_6;

	private string string_2 = string.Empty;

	private string string_3 = string.Empty;

	private string string_4 = string.Empty;

	private string string_5 = string.Empty;

	private int int_7;

	private bool bool_2;

	private bool bool_3;

	private string string_6 = string.Empty;

	private string string_7 = string.Empty;

	private string string_8 = string.Empty;

	private string string_9 = string.Empty;

	private int int_8;

	[Browsable(false)]
	public string XmlNodeName
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

	[Category("Identity")]
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

	[Category("Identity")]
	public UiControlType Type
	{
		[CompilerGenerated]
		get
		{
			return uiControlType_0;
		}
		[CompilerGenerated]
		set
		{
			uiControlType_0 = value;
		}
	}

	[Category("Layout")]
	public int Int32_0
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

	[Category("Layout")]
	public int Int32_1
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	[Category("Layout")]
	public int Width
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	[Category("Layout")]
	public int Height
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	[Browsable(false)]
	public bool HasExplicitWidth
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

	[Browsable(false)]
	public bool HasExplicitHeight
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	[Category("Layout")]
	public int Align
	{
		[CompilerGenerated]
		get
		{
			return int_4;
		}
		[CompilerGenerated]
		set
		{
			int_4 = value;
		}
	}

	[Category("Layout")]
	public int TextOffsetX
	{
		[CompilerGenerated]
		get
		{
			return int_5;
		}
		[CompilerGenerated]
		set
		{
			int_5 = value;
		}
	}

	[Category("Layout")]
	public int TextOffsetY
	{
		[CompilerGenerated]
		get
		{
			return int_6;
		}
		[CompilerGenerated]
		set
		{
			int_6 = value;
		}
	}

	[Category("Layout")]
	public string DialogFile
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

	[Category("Text")]
	public string Text
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

	[Category("Text")]
	public string Hint
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

	[Category("Text")]
	public string Color
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

	[Category("Text")]
	public int FontSize
	{
		[CompilerGenerated]
		get
		{
			return int_7;
		}
		[CompilerGenerated]
		set
		{
			int_7 = value;
		}
	}

	[Category("Text")]
	public bool Bold
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	[Category("Text")]
	public bool Outline
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	[Category("Text")]
	public string OutlineColor
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

	[Category("Resources")]
	public string PrimaryImagePath
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

	[Category("Resources")]
	public string SecondaryImagePath
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

	[Category("Resources")]
	public string TertiaryImagePath
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

	[Category("Order")]
	public int Layer
	{
		[CompilerGenerated]
		get
		{
			return int_8;
		}
		[CompilerGenerated]
		set
		{
			int_8 = value;
		}
	}
}
