using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ACE.UIEdit.Models;

internal sealed class UiDialogModel
{
	private string string_0 = Class16.smethod_0(1649150397);

	private int int_0 = 800;

	private int int_1 = 600;

	private string string_1 = string.Empty;

	private readonly List<UiControlModel> list_0 = new List<UiControlModel>();

	[Category("Dialog")]
	public string Name
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

	[Category("Dialog")]
	public int Width
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

	[Category("Dialog")]
	public int Height
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

	[Category("Resources")]
	public string BackgroundImagePath
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

	[Browsable(false)]
	public List<UiControlModel> Controls
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
	}
}
