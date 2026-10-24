using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ACE.NpcGen.LBLIBRARY.LBLIBRARY.Components;

public class MenuStripA : MenuStrip
{
	private bool bool_0;

	private Color color_0;

	private Color color_1;

	private Color color_2;

	private Color color_3;

	private Color color_4;

	private Color color_5;

	private Color color_6;

	[Category("Appearance")]
	public bool SetColorBlack
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			if (value)
			{
				color_1 = Color.FromArgb(20, 20, 20);
				color_2 = Color.FromArgb(225, 225, 225);
				base.BackColor = Color.FromArgb(20, 20, 20);
				color_6 = Color.FromArgb(60, 60, 60);
				color_3 = Color.FromArgb(35, 35, 35);
				color_4 = Color.FromArgb(45, 45, 45);
				color_5 = Color.Black;
				color_0 = Color.FromArgb(70, 70, 70);
			}
			else
			{
				color_1 = Color.White;
				color_2 = Color.Black;
				base.BackColor = Color.FromArgb(255, 245, 245, 245);
				color_6 = Color.FromArgb(150, 150, 150);
				color_3 = Color.FromArgb(242, 242, 242);
				color_4 = Color.FromArgb(255, 195, 234, 246);
				color_5 = Color.Blue;
				color_0 = Color.LightSkyBlue;
			}
			base.Renderer = new MyMenuRenderer(color_1, color_2, color_6, color_3, color_4, color_5, color_0);
		}
	}
}
