using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ACE.NpcGen.LBLIBRARY.LBLIBRARY.Components;

public class ComboBoxA : ComboBox
{
	public enum MyEnum
	{
		True,
		False,
		None
	}

	private Color color_0;

	private MyEnum myEnum_0;

	private Font font_0 = new Font(Class16.smethod_0(1649117804), 9f, FontStyle.Regular);

	private Color color_1;

	private DrawMode drawMode_0;

	private Color color_2;

	public Color ArrowColor
	{
		[CompilerGenerated]
		get
		{
			return color_1;
		}
		[CompilerGenerated]
		set
		{
			color_1 = value;
		}
	}

	public new DrawMode DrawMode
	{
		[CompilerGenerated]
		get
		{
			return drawMode_0;
		}
		[CompilerGenerated]
		set
		{
			drawMode_0 = value;
		}
	}

	public Color SelectionColor
	{
		[CompilerGenerated]
		get
		{
			return color_2;
		}
		[CompilerGenerated]
		set
		{
			color_2 = value;
		}
	}

	public MyEnum SetColorBlack
	{
		get
		{
			return myEnum_0;
		}
		set
		{
			switch (value)
			{
			default:
				myEnum_0 = MyEnum.None;
				break;
			case MyEnum.False:
				BackColor = SystemColors.Window;
				ArrowColor = Color.FromArgb(70, 70, 70);
				SelectionColor = Color.FromArgb(128, 128, 255);
				ForeColor = SystemColors.WindowText;
				color_0 = Color.FromArgb(70, 70, 70);
				myEnum_0 = MyEnum.False;
				break;
			case MyEnum.True:
				BackColor = Color.FromArgb(20, 20, 20);
				ArrowColor = Color.Silver;
				SelectionColor = Color.Green;
				ForeColor = Color.FromArgb(235, 235, 235);
				color_0 = Color.FromArgb(80, 80, 80);
				myEnum_0 = MyEnum.True;
				break;
			}
			Invalidate();
		}
	}

	public Font SetFont
	{
		get
		{
			return font_0;
		}
		set
		{
			font_0 = value;
		}
	}

	public ComboBoxA()
	{
		base.DrawMode = DrawMode.OwnerDrawFixed;
		base.FlatStyle = FlatStyle.Flat;
		base.DropDownStyle = ComboBoxStyle.DropDownList;
		SelectionColor = Color.Red;
		color_0 = Color.Black;
		ArrowColor = Color.Black;
		SetStyle(ControlStyles.UserPaint, value: true);
		base.DrawItem += ComboBoxA_DrawItem;
	}

	protected override void OnPaint(PaintEventArgs paintEventArgs_0)
	{
		base.OnPaint(paintEventArgs_0);
		int verticalScrollBarWidth = SystemInformation.VerticalScrollBarWidth;
		Color controlLightLight = SystemColors.ControlLightLight;
		Color controlDark = SystemColors.ControlDark;
		LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Rectangle(base.Width, 0, verticalScrollBarWidth, base.Height), controlLightLight, controlDark, LinearGradientMode.Vertical);
		paintEventArgs_0.Graphics.FillRectangle(linearGradientBrush, new Rectangle(base.Width, 0, verticalScrollBarWidth, base.Height));
		linearGradientBrush.Dispose();
		Pen pen = new Pen(SystemColors.ButtonShadow, 1f);
		paintEventArgs_0.Graphics.DrawRectangle(pen, new Rectangle(base.Width, 0, verticalScrollBarWidth, base.Height).X, new Rectangle(base.Width, 0, verticalScrollBarWidth, base.Height).Y, new Rectangle(base.Width, 0, verticalScrollBarWidth, base.Height).Width - 2, new Rectangle(base.Width, 0, verticalScrollBarWidth, base.Height).Height - 2);
		pen.Dispose();
		SolidBrush solidBrush = new SolidBrush(ArrowColor);
		Point[] points = new Point[3]
		{
			new Point(base.Width - 15, base.Height / 2 - 2),
			new Point(base.Width - 4, base.Height / 2 - 2),
			new Point(base.Width - 10, base.Height / 2 + 4)
		};
		paintEventArgs_0.Graphics.FillPolygon(solidBrush, points);
		solidBrush.Dispose();
		if (base.SelectedItem != null)
		{
			paintEventArgs_0.Graphics.DrawString(Text, font_0, new SolidBrush(ForeColor), 1f, 2f);
		}
		paintEventArgs_0.Graphics.DrawRectangle(new Pen(color_0, 2f), 0f, 0f, base.Width, base.Height);
	}

	private void ComboBoxA_DrawItem(object sender, DrawItemEventArgs e)
	{
		if (e.Index >= 0)
		{
			ComboBox comboBox = sender as ComboBox;
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				e.Graphics.FillRectangle(new SolidBrush(SelectionColor), e.Bounds);
			}
			else
			{
				e.Graphics.FillRectangle(new SolidBrush(comboBox.BackColor), e.Bounds);
			}
			e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), font_0, new SolidBrush(comboBox.ForeColor), new Point(1, e.Bounds.Y - 1));
			e.DrawFocusRectangle();
		}
	}
}
