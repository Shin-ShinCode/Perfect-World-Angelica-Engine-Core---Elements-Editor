using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ACE.NpcGen.LBLIBRARY.LBLIBRARY.Components;

public class NumericUpDownEx : Panel
{
	private int int_0;

	private bool bool_0 = true;

	private ButtonC buttonC_0 = new ButtonC
	{
		BackColor = Color.Transparent,
		BorderColor = Color.Transparent,
		BorderWidth = 1,
		ButtonShape = ButtonC.ButtonsShapes.Rect,
		ButtonText = Class16.smethod_0(1649117811),
		EndColor = Color.MidnightBlue,
		FlatStyle = FlatStyle.Flat,
		Font = new Font(Class16.smethod_0(1648934511), 8.5f, FontStyle.Bold),
		ForeColor = Color.Black,
		GradientAngle = 90,
		MouseClickColor1 = Color.Turquoise,
		MouseClickColor2 = Color.Turquoise,
		MouseHoverColor1 = Color.Turquoise,
		MouseHoverColor2 = Color.DarkSlateGray,
		Name = Class16.smethod_0(1649117835),
		ShowButtontext = true,
		Size = new Size(13, 9),
		StartColor = Color.DodgerBlue,
		TabIndex = 4,
		Text = Class16.smethod_0(1648941518),
		TextLocation_X = -1,
		TextLocation_Y = -3,
		Transparent1 = 250,
		Transparent2 = 250,
		UseVisualStyleBackColor = true,
		Location = new Point(142, 10),
		Anchor = (AnchorStyles.Top | AnchorStyles.Right)
	};

	private ButtonC buttonC_1 = new ButtonC
	{
		BackColor = Color.Transparent,
		BorderColor = Color.Transparent,
		BorderWidth = 1,
		ButtonShape = ButtonC.ButtonsShapes.Rect,
		ButtonText = Class16.smethod_0(1649117850),
		StartColor = Color.DodgerBlue,
		EndColor = Color.MidnightBlue,
		FlatStyle = FlatStyle.Flat,
		Font = new Font(Class16.smethod_0(1648934511), 8.5f, FontStyle.Bold),
		ForeColor = Color.Black,
		GradientAngle = 90,
		MouseClickColor1 = Color.Turquoise,
		MouseClickColor2 = Color.Turquoise,
		MouseHoverColor1 = Color.Turquoise,
		MouseHoverColor2 = Color.DarkSlateGray,
		Name = Class16.smethod_0(1648991094),
		ShowButtontext = true,
		Size = new Size(13, 9),
		TabIndex = 1,
		Text = Class16.smethod_0(1648941518),
		TextLocation_X = -1,
		TextLocation_Y = -5,
		Transparent1 = 250,
		Transparent2 = 250,
		UseVisualStyleBackColor = true,
		Location = new Point(142, 1),
		Anchor = (AnchorStyles.Top | AnchorStyles.Right)
	};

	private TextBoxEx textBoxEx_0 = new TextBoxEx
	{
		Multiline = true,
		BorderStyle = BorderStyle.None,
		Location = new Point(0, 0),
		Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right),
		ForeColor = Color.Wheat,
		Size = new Size(142, 28),
		Font = new Font(Class16.smethod_0(1649117804), 12f, FontStyle.Regular),
		Text = Class16.smethod_0(1648924112),
		BackColor = Color.Black,
		Name = Class16.smethod_0(1649117859)
	};

	private bool bool_1;

	private int int_1;

	public int Increment
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

	public decimal MaximalValue
	{
		get
		{
			return textBoxEx_0.MaximalValue;
		}
		set
		{
			textBoxEx_0.MaximalValue = value;
		}
	}

	public decimal MinimalValue
	{
		get
		{
			return textBoxEx_0.MinimalValue;
		}
		set
		{
			textBoxEx_0.MinimalValue = value;
		}
	}

	public bool SetBlack
	{
		get
		{
			return bool_0;
		}
		set
		{
			if (value)
			{
				BackColor = Color.FromArgb(35, 35, 35);
				textBoxEx_0.BackColor = Color.Black;
				textBoxEx_0.ForeColor = Color.FromArgb(192, 255, 255);
				buttonC_0.ForeColor = Color.Silver;
				buttonC_1.ForeColor = Color.Silver;
				buttonC_0.StartColor = Color.FromArgb(20, 20, 20);
				buttonC_0.EndColor = Color.FromArgb(20, 20, 20);
				buttonC_1.StartColor = Color.FromArgb(20, 20, 20);
				buttonC_1.EndColor = Color.FromArgb(20, 20, 20);
				buttonC_1.BorderColor = Color.FromArgb(20, 20, 80);
				buttonC_0.BorderColor = Color.FromArgb(20, 20, 20);
			}
			else
			{
				BackColor = Color.White;
				textBoxEx_0.BackColor = SystemColors.Window;
				textBoxEx_0.ForeColor = SystemColors.ControlText;
				buttonC_0.ForeColor = SystemColors.ControlText;
				buttonC_1.ForeColor = SystemColors.ControlText;
				buttonC_0.StartColor = Color.FromArgb(220, 220, 220);
				buttonC_1.StartColor = Color.FromArgb(220, 220, 220);
				buttonC_0.EndColor = Color.FromArgb(220, 220, 220);
				buttonC_1.EndColor = Color.FromArgb(220, 220, 220);
				buttonC_1.BorderColor = Color.Gray;
				buttonC_0.BorderColor = Color.Gray;
			}
			bool_0 = value;
		}
	}

	public int SetDecimalPlaces
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			textBoxEx_0.SetDecimalPlaces = value;
		}
	}

	public bool SetThousandsSeparator
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
			textBoxEx_0.ThousandsSeparator = value;
		}
	}

	public Color TextBoxBackGroundColor
	{
		get
		{
			return textBoxEx_0.BackColor;
		}
		set
		{
			textBoxEx_0.BackColor = value;
		}
	}

	public Font TextBoxFont
	{
		get
		{
			return textBoxEx_0.Font;
		}
		set
		{
			textBoxEx_0.Font = value;
			TextRenderer.MeasureText(Class16.smethod_0(1648934925), Font);
		}
	}

	public Color TextBoxForeColor
	{
		get
		{
			return textBoxEx_0.ForeColor;
		}
		set
		{
			textBoxEx_0.ForeColor = value;
		}
	}

	public string TextBoxName
	{
		get
		{
			return textBoxEx_0.Name;
		}
		set
		{
			textBoxEx_0.Name = value;
		}
	}

	public decimal Value
	{
		get
		{
			if (textBoxEx_0.DecimalPlaces > 0)
			{
				if (textBoxEx_0.Text.Contains(Class16.smethod_0(1648928028)))
				{
					string[] array = textBoxEx_0.Text.Split(',');
					return Convert.ToDecimal(array[0] + Class16.smethod_0(1648928028) + array[1]);
				}
				return Convert.ToDecimal(textBoxEx_0.Text);
			}
			return Convert.ToDecimal(textBoxEx_0.Text);
		}
		set
		{
			textBoxEx_0.Text = value.ToString();
			textBoxEx_0.FormatValue();
		}
	}

	[Category("OwnEvents")]
	public event EventHandler TextBoxDoubleClick
	{
		add
		{
			textBoxEx_0.DoubleClick += value;
		}
		remove
		{
			textBoxEx_0.DoubleClick += null;
		}
	}

	[Category("OwnEvents")]
	public event EventHandler TextBoxEnter
	{
		add
		{
			textBoxEx_0.Enter += value;
		}
		remove
		{
			textBoxEx_0.Enter += null;
		}
	}

	[Category("OwnEvents")]
	public event KeyEventHandler TextBoxKeyDown
	{
		add
		{
			textBoxEx_0.KeyDown += value;
		}
		remove
		{
			textBoxEx_0.KeyDown += null;
		}
	}

	[Category("OwnEvents")]
	public event EventHandler TextBoxLeave
	{
		add
		{
			textBoxEx_0.Leave += value;
		}
		remove
		{
			textBoxEx_0.Leave += null;
		}
	}

	[Category("OwnEvents")]
	public event EventHandler TextBoxTextChanged
	{
		add
		{
			textBoxEx_0.TextChanged += value;
		}
		remove
		{
			textBoxEx_0.TextChanged += null;
		}
	}

	public NumericUpDownEx()
	{
		base.BorderStyle = BorderStyle.FixedSingle;
		BackColor = Color.White;
		base.Size = new Size(158, 21);
		base.Controls.Add(textBoxEx_0);
		base.Controls.Add(buttonC_1);
		base.Controls.Add(buttonC_0);
		buttonC_1.Click += buttonC_1_Click;
		buttonC_0.Click += buttonC_0_Click;
		textBoxEx_0.SetButtonsNames(buttonC_1.Name, buttonC_0.Name);
		Increment = 1;
	}

	private void buttonC_0_Click(object sender, EventArgs e)
	{
		textBoxEx_0.Focus();
		textBoxEx_0.SelectionLength = 0;
		try
		{
			textBoxEx_0.Text = (Convert.ToDecimal(textBoxEx_0.Text) - (decimal)Increment).ToString();
		}
		catch
		{
			textBoxEx_0.Text = (textBoxEx_0.LastValue - (decimal)Increment).ToString();
		}
		if (int_0 != 0 && bool_1)
		{
			textBoxEx_0.Text = string.Format(textBoxEx_0.FormatedText, double.Parse(textBoxEx_0.Text.Replace(Class16.smethod_0(1649117873), string.Empty)));
		}
		try
		{
			if (Convert.ToDecimal(textBoxEx_0.Text) < MinimalValue)
			{
				textBoxEx_0.Text = MinimalValue.ToString();
			}
		}
		catch
		{
		}
	}

	private void buttonC_1_Click(object sender, EventArgs e)
	{
		textBoxEx_0.Focus();
		textBoxEx_0.SelectionLength = 0;
		try
		{
			textBoxEx_0.Text = (Convert.ToDecimal(textBoxEx_0.Text) + (decimal)Increment).ToString();
		}
		catch
		{
			textBoxEx_0.Text = (textBoxEx_0.LastValue + (decimal)Increment).ToString();
		}
		if (int_0 != 0 && bool_1)
		{
			textBoxEx_0.Text = string.Format(textBoxEx_0.FormatedText, double.Parse(textBoxEx_0.Text.Replace(Class16.smethod_0(1649117873), string.Empty)));
		}
	}
}
