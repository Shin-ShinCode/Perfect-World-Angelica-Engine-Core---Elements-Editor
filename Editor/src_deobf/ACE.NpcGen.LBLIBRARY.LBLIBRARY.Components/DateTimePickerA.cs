using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ACE.NpcGen.LBLIBRARY.LBLIBRARY.Components;

public class DateTimePickerA : DateTimePicker
{
	private Color color_0;

	private Color color_1 = Color.FromArgb(229, 241, 251);

	private Brush brush_0 = Brushes.Black;

	private Brush brush_1 = Brushes.LightBlue;

	private Graphics graphics_0;

	private bool bool_0;

	private Color color_2;

	private Color color_3;

	[Category("OwnProperties")]
	[Browsable(true)]
	public override Color BackColor
	{
		get
		{
			return base.BackColor;
		}
		set
		{
			base.BackColor = value;
		}
	}

	[Category("OwnProperties")]
	public Color BackDisabledColor
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

	[Category("OwnProperties")]
	public Color SetBorderColor
	{
		get
		{
			return color_2;
		}
		set
		{
			color_2 = value;
		}
	}

	[Category("OwnProperties")]
	public Color SetColor
	{
		get
		{
			return color_3;
		}
		set
		{
			color_3 = value;
		}
	}

	[Category("OwnProperties")]
	public bool SetColorBlack
	{
		get
		{
			return bool_0;
		}
		set
		{
			if (value)
			{
				bool_0 = true;
				BackColor = Color.FromArgb(20, 20, 20);
				color_2 = Color.FromArgb(120, 120, 120);
				color_3 = Color.FromArgb(235, 235, 235);
				color_1 = Color.FromArgb(20, 20, 20);
				brush_0 = new SolidBrush(Color.FromArgb(235, 235, 235));
				brush_1 = new SolidBrush(Color.FromArgb(50, 50, 50));
			}
			else
			{
				bool_0 = false;
				BackColor = Color.White;
				color_2 = Color.FromArgb(150, 150, 150);
				color_3 = SystemColors.ControlText;
				color_1 = Color.FromArgb(229, 241, 251);
				brush_0 = new SolidBrush(Color.FromArgb(70, 70, 70));
				brush_1 = new SolidBrush(Color.LightBlue);
			}
			Invalidate();
		}
	}

	public DateTimePickerA()
	{
		SetStyle(ControlStyles.UserPaint, value: true);
		color_0 = Color.FromKnownColor(KnownColor.Control);
	}

	protected override void OnMouseMove(MouseEventArgs mea)
	{
		Rectangle rect = new Rectangle(base.ClientRectangle.Width - 17, 1, 17, 19);
		base.OnMouseMove(mea);
		if (mea.X >= base.ClientRectangle.Width - 17 && mea.X < base.ClientRectangle.Width - 1)
		{
			graphics_0.FillRectangle(brush_1, rect);
			graphics_0.DrawString(Class16.smethod_0(1649117811), new Font(Class16.smethod_0(1649117828), 14f, FontStyle.Regular), brush_0, new PointF(rect.X, rect.Y + 1));
		}
		else
		{
			graphics_0.FillRectangle(new SolidBrush(color_1), rect);
			graphics_0.DrawString(Class16.smethod_0(1649117811), new Font(Class16.smethod_0(1649117828), 14f, FontStyle.Regular), brush_0, new PointF(rect.X, rect.Y + 1));
		}
	}

	protected override void OnPaint(PaintEventArgs paintEventArgs_0)
	{
		graphics_0 = CreateGraphics();
		Rectangle rectangle = new Rectangle(base.ClientRectangle.Width - 17, 0, 17, 20);
		Brush brush;
		ComboBoxState comboBoxState;
		if (base.Enabled)
		{
			brush = new SolidBrush(BackColor);
			comboBoxState = ComboBoxState.Hot;
		}
		else
		{
			brush = new SolidBrush(color_0);
			comboBoxState = ComboBoxState.Disabled;
		}
		graphics_0.FillRectangle(brush, 0, 0, base.ClientRectangle.Width, base.ClientRectangle.Height);
		graphics_0.DrawString(Text, Font, new SolidBrush(color_3), 0f, 2f);
		ComboBoxRenderer.DrawDropDownButton(graphics_0, rectangle, comboBoxState);
		graphics_0.FillRectangle(new SolidBrush(color_1), rectangle);
		graphics_0.DrawRectangle(new Pen(color_2), 0, 0, base.Width - 1, base.Height - 1);
		graphics_0.DrawString(Class16.smethod_0(1649117811), new Font(Class16.smethod_0(1649117828), 14f, FontStyle.Regular), brush_0, new PointF(rectangle.X, rectangle.Y + 1));
		brush.Dispose();
	}
}
