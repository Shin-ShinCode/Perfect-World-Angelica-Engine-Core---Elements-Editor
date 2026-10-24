using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ACE.NpcGen.LBLIBRARY.LBLIBRARY.Components;

public class ToolStripEx : ToolStrip
{
	private Color color_0;

	private bool bool_0;

	private Color color_1;

	private Color color_2;

	private Color color_3;

	private Color color_4;

	private Color color_5;

	private Color color_6;

	private Color color_7;

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
				color_2 = Color.FromArgb(20, 20, 20);
				color_3 = Color.FromArgb(225, 225, 225);
				base.BackColor = Color.FromArgb(20, 20, 20);
				color_7 = Color.FromArgb(60, 60, 60);
				color_4 = Color.FromArgb(25, 25, 25);
				color_5 = Color.FromArgb(35, 35, 35);
				color_6 = Color.Black;
				color_1 = Color.FromArgb(70, 70, 70);
				color_0 = Color.FromArgb(125, 125, 125);
			}
			else
			{
				color_2 = Color.White;
				color_3 = Color.Black;
				base.BackColor = Color.FromArgb(255, 245, 245, 245);
				color_7 = Color.FromArgb(150, 150, 150);
				color_4 = Color.FromArgb(242, 242, 242);
				color_5 = Color.FromArgb(255, 195, 234, 246);
				color_6 = Color.Blue;
				color_1 = Color.LightSkyBlue;
				color_0 = SystemColors.ControlText;
			}
			base.Renderer = new MyToolStripRenderer(color_2, color_3, color_7, color_4, color_5, color_6, color_1, color_0);
		}
	}
}
