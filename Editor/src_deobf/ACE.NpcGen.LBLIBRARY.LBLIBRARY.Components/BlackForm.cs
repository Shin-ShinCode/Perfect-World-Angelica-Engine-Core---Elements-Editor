using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.NpcGen.LBLIBRARY.LBLIBRARY.Components;

public class BlackForm : Form
{
	protected ButtonB _CloseButton;

	protected ButtonD _MaxButton;

	protected ButtonB _MinButton;

	protected Panel BottomPanel;

	protected Panel LeftBottomPanel_1;

	protected Panel LeftBottomPanel_2;

	protected Panel LeftPanel;

	protected Panel LeftTopPanel_1;

	protected Panel LeftTopPanel_2;

	protected Panel RightBottomPanel_1;

	protected Panel RightBottomPanel_2;

	protected Panel RightPanel;

	protected Panel RightTopPanel_1;

	protected Panel RightTopPanel_2;

	protected ToolTip toolTip1;

	protected Panel TopBorderPanel;

	protected Panel TopPanel;

	protected Label WindowTextLabel;

	private Point point_0 = Point.Empty;

	private Size size_0;

	private IContainer icontainer_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private Point point_1;

	private bool bool_10 = true;

	[Category("Own")]
	public bool EnableResizeAndFold
	{
		get
		{
			return bool_10;
		}
		set
		{
			bool_10 = value;
			if (bool_10)
			{
				_MinButton.Visible = true;
				_MaxButton.Visible = true;
			}
			else
			{
				_MinButton.Visible = false;
				_MaxButton.Visible = false;
			}
		}
	}

	public BlackForm()
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyThemeToForm(this);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void _CloseButton_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void _MaxButton_Click(object sender, EventArgs e)
	{
		if (bool_9)
		{
			base.Location = point_0;
			base.Size = size_0;
			toolTip1.SetToolTip(_MaxButton, Class16.smethod_0(1649118331));
			_MaxButton.CFormState = ButtonD.CustomFormState.Normal;
			bool_9 = false;
		}
		else
		{
			size_0 = base.Size;
			point_0 = base.Location;
			Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
			base.Location = new Point(0, 0);
			base.Size = new Size(workingArea.Width, workingArea.Height);
			toolTip1.SetToolTip(_MaxButton, Class16.smethod_0(1649118346));
			_MaxButton.CFormState = ButtonD.CustomFormState.Maximize;
			bool_9 = true;
		}
	}

	private void _MinButton_Click(object sender, EventArgs e)
	{
		base.WindowState = FormWindowState.Minimized;
	}

	private void BlackForm_Resize(object sender, EventArgs e)
	{
		WindowTextLabel.Location = new Point(base.Width / 2 - TextRenderer.MeasureText(WindowTextLabel.Text, WindowTextLabel.Font).Width / 2, WindowTextLabel.Location.Y);
	}

	private void BottomPanel_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			bool_0 = true;
		}
		else
		{
			bool_0 = false;
		}
	}

	private void BottomPanel_MouseMove(object sender, MouseEventArgs e)
	{
		if (bool_0)
		{
			if (base.Height < 50)
			{
				base.Height = 50;
				bool_0 = false;
			}
			else
			{
				base.Height += e.Y;
			}
		}
	}

	private void BottomPanel_MouseUp(object sender, MouseEventArgs e)
	{
		bool_0 = false;
	}

	private void method_0()
	{
		icontainer_0 = new Container();
		TopBorderPanel = new Panel();
		RightPanel = new Panel();
		LeftPanel = new Panel();
		BottomPanel = new Panel();
		TopPanel = new Panel();
		WindowTextLabel = new Label();
		RightBottomPanel_1 = new Panel();
		toolTip1 = new ToolTip(icontainer_0);
		RightBottomPanel_2 = new Panel();
		LeftBottomPanel_1 = new Panel();
		LeftBottomPanel_2 = new Panel();
		RightTopPanel_1 = new Panel();
		RightTopPanel_2 = new Panel();
		LeftTopPanel_1 = new Panel();
		LeftTopPanel_2 = new Panel();
		_MinButton = new ButtonB();
		_MaxButton = new ButtonD();
		_CloseButton = new ButtonB();
		TopPanel.SuspendLayout();
		SuspendLayout();
		TopBorderPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TopBorderPanel.BackColor = Color.Black;
		TopBorderPanel.Cursor = Cursors.SizeNS;
		TopBorderPanel.Location = new Point(20, 0);
		TopBorderPanel.Name = Class16.smethod_0(1649118373);
		TopBorderPanel.Size = new Size(690, 2);
		TopBorderPanel.TabIndex = 0;
		TopBorderPanel.MouseDown += TopBorderPanel_MouseDown;
		TopBorderPanel.MouseMove += TopBorderPanel_MouseMove;
		TopBorderPanel.MouseUp += TopBorderPanel_MouseUp;
		RightPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		RightPanel.BackColor = Color.Black;
		RightPanel.Cursor = Cursors.SizeWE;
		RightPanel.Location = new Point(728, 22);
		RightPanel.Name = Class16.smethod_0(1649118386);
		RightPanel.Size = new Size(2, 430);
		RightPanel.TabIndex = 1;
		RightPanel.MouseDown += RightPanel_MouseDown;
		RightPanel.MouseMove += RightPanel_MouseMove;
		RightPanel.MouseUp += RightPanel_MouseUp;
		LeftPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		LeftPanel.BackColor = Color.Black;
		LeftPanel.Cursor = Cursors.SizeWE;
		LeftPanel.Location = new Point(0, 20);
		LeftPanel.Name = Class16.smethod_0(1649118403);
		LeftPanel.Size = new Size(2, 430);
		LeftPanel.TabIndex = 2;
		LeftPanel.MouseDown += LeftPanel_MouseDown;
		LeftPanel.MouseMove += LeftPanel_MouseMove;
		LeftPanel.MouseUp += LeftPanel_MouseUp;
		BottomPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		BottomPanel.BackColor = Color.Black;
		BottomPanel.Cursor = Cursors.SizeNS;
		BottomPanel.Location = new Point(15, 471);
		BottomPanel.Name = Class16.smethod_0(1649118419);
		BottomPanel.Size = new Size(692, 2);
		BottomPanel.TabIndex = 3;
		BottomPanel.MouseDown += BottomPanel_MouseDown;
		BottomPanel.MouseMove += BottomPanel_MouseMove;
		BottomPanel.MouseUp += BottomPanel_MouseUp;
		TopPanel.BackColor = Color.FromArgb(30, 30, 30);
		TopPanel.Controls.Add(_MinButton);
		TopPanel.Controls.Add(_MaxButton);
		TopPanel.Controls.Add(WindowTextLabel);
		TopPanel.Controls.Add(_CloseButton);
		TopPanel.Dock = DockStyle.Top;
		TopPanel.Location = new Point(0, 0);
		TopPanel.Name = Class16.smethod_0(1649118445);
		TopPanel.Size = new Size(730, 76);
		TopPanel.TabIndex = 4;
		TopPanel.MouseDown += TopPanel_MouseDown;
		TopPanel.MouseMove += TopPanel_MouseMove;
		TopPanel.MouseUp += TopPanel_MouseUp;
		WindowTextLabel.AutoSize = true;
		WindowTextLabel.Font = new Font(Class16.smethod_0(1648929920), 26.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		WindowTextLabel.ForeColor = Color.White;
		WindowTextLabel.Location = new Point(3, 0);
		WindowTextLabel.Name = Class16.smethod_0(1649118460);
		WindowTextLabel.Size = new Size(134, 39);
		WindowTextLabel.TabIndex = 1;
		WindowTextLabel.Text = TextStorage.Msg(Class16.smethod_0(1649118474), Class16.smethod_0(1649118502));
		WindowTextLabel.MouseDown += WindowTextLabel_MouseDown;
		WindowTextLabel.MouseMove += WindowTextLabel_MouseMove;
		WindowTextLabel.MouseUp += WindowTextLabel_MouseUp;
		RightBottomPanel_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		RightBottomPanel_1.BackColor = Color.Black;
		RightBottomPanel_1.Cursor = Cursors.SizeNWSE;
		RightBottomPanel_1.Location = new Point(710, 471);
		RightBottomPanel_1.Name = Class16.smethod_0(1649118507);
		RightBottomPanel_1.Size = new Size(19, 2);
		RightBottomPanel_1.TabIndex = 5;
		RightBottomPanel_1.MouseDown += RightBottomPanel_1_MouseDown;
		RightBottomPanel_1.MouseMove += RightBottomPanel_1_MouseMove;
		RightBottomPanel_1.MouseUp += RightBottomPanel_1_MouseUp;
		RightBottomPanel_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		RightBottomPanel_2.BackColor = Color.Black;
		RightBottomPanel_2.Cursor = Cursors.SizeNWSE;
		RightBottomPanel_2.Location = new Point(728, 452);
		RightBottomPanel_2.Name = Class16.smethod_0(1649118540);
		RightBottomPanel_2.Size = new Size(2, 19);
		RightBottomPanel_2.TabIndex = 9;
		RightBottomPanel_2.MouseDown += RightBottomPanel_2_MouseDown;
		RightBottomPanel_2.MouseMove += RightBottomPanel_2_MouseMove;
		RightBottomPanel_2.MouseUp += RightBottomPanel_2_MouseUp;
		LeftBottomPanel_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LeftBottomPanel_1.BackColor = Color.Black;
		LeftBottomPanel_1.Cursor = Cursors.SizeNESW;
		LeftBottomPanel_1.Location = new Point(0, 471);
		LeftBottomPanel_1.Name = Class16.smethod_0(1649118565);
		LeftBottomPanel_1.Size = new Size(15, 2);
		LeftBottomPanel_1.TabIndex = 10;
		LeftBottomPanel_1.MouseDown += LeftBottomPanel_1_MouseDown;
		LeftBottomPanel_1.MouseMove += LeftBottomPanel_1_MouseMove;
		LeftBottomPanel_1.MouseUp += LeftBottomPanel_1_MouseUp;
		LeftBottomPanel_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LeftBottomPanel_2.BackColor = Color.Black;
		LeftBottomPanel_2.Cursor = Cursors.SizeNESW;
		LeftBottomPanel_2.Location = new Point(0, 453);
		LeftBottomPanel_2.Name = Class16.smethod_0(1649118589);
		LeftBottomPanel_2.Size = new Size(2, 19);
		LeftBottomPanel_2.TabIndex = 11;
		LeftBottomPanel_2.MouseDown += LeftBottomPanel_2_MouseDown;
		LeftBottomPanel_2.MouseMove += LeftBottomPanel_2_MouseMove;
		LeftBottomPanel_2.MouseUp += LeftBottomPanel_2_MouseUp;
		RightTopPanel_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		RightTopPanel_1.BackColor = Color.Black;
		RightTopPanel_1.Cursor = Cursors.SizeNESW;
		RightTopPanel_1.Location = new Point(728, 2);
		RightTopPanel_1.Name = Class16.smethod_0(1649118613);
		RightTopPanel_1.Size = new Size(2, 20);
		RightTopPanel_1.TabIndex = 12;
		RightTopPanel_1.MouseDown += RightTopPanel_1_MouseDown;
		RightTopPanel_1.MouseMove += RightTopPanel_1_MouseMove;
		RightTopPanel_1.MouseUp += RightTopPanel_1_MouseUp;
		RightTopPanel_2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		RightTopPanel_2.BackColor = Color.Black;
		RightTopPanel_2.Cursor = Cursors.SizeNESW;
		RightTopPanel_2.Location = new Point(710, 0);
		RightTopPanel_2.Name = Class16.smethod_0(1649118627);
		RightTopPanel_2.Size = new Size(20, 2);
		RightTopPanel_2.TabIndex = 13;
		RightTopPanel_2.MouseDown += RightTopPanel_2_MouseDown;
		RightTopPanel_2.MouseMove += RightTopPanel_2_MouseMove;
		RightTopPanel_2.MouseUp += RightTopPanel_2_MouseUp;
		LeftTopPanel_1.BackColor = Color.Black;
		LeftTopPanel_1.Cursor = Cursors.SizeNWSE;
		LeftTopPanel_1.Location = new Point(0, 0);
		LeftTopPanel_1.Name = Class16.smethod_0(1649118649);
		LeftTopPanel_1.Size = new Size(20, 2);
		LeftTopPanel_1.TabIndex = 14;
		LeftTopPanel_1.MouseDown += LeftTopPanel_1_MouseDown;
		LeftTopPanel_1.MouseMove += LeftTopPanel_1_MouseMove;
		LeftTopPanel_1.MouseUp += LeftTopPanel_1_MouseUp;
		LeftTopPanel_2.BackColor = Color.Black;
		LeftTopPanel_2.Cursor = Cursors.SizeNWSE;
		LeftTopPanel_2.Location = new Point(0, 0);
		LeftTopPanel_2.Name = Class16.smethod_0(1649118678);
		LeftTopPanel_2.Size = new Size(2, 20);
		LeftTopPanel_2.TabIndex = 15;
		LeftTopPanel_2.MouseDown += LeftTopPanel_2_MouseDown;
		LeftTopPanel_2.MouseMove += LeftTopPanel_2_MouseMove;
		LeftTopPanel_2.MouseUp += LeftTopPanel_2_MouseUp;
		_MinButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		_MinButton.BZBackColor = Color.FromArgb(30, 30, 30);
		_MinButton.DisplayText = Class16.smethod_0(1648923968);
		_MinButton.FlatStyle = FlatStyle.Flat;
		_MinButton.Font = new Font(Class16.smethod_0(1649118691), 20.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		_MinButton.ForeColor = Color.White;
		_MinButton.Image = null;
		_MinButton.Image_Location = new Point(0, 0);
		_MinButton.ImageToHeight = false;
		_MinButton.Location = new Point(632, 6);
		_MinButton.MouseClickColor1 = Color.FromArgb(60, 60, 160);
		_MinButton.MouseHoverColor = Color.FromArgb(50, 50, 50);
		_MinButton.Name = Class16.smethod_0(1649117700);
		_MinButton.Size = new Size(31, 24);
		_MinButton.TabIndex = 4;
		_MinButton.Text = Class16.smethod_0(1648923968);
		_MinButton.TextLocation_X = 6;
		_MinButton.TextLocation_Y = -20;
		toolTip1.SetToolTip(_MinButton, Class16.smethod_0(1649117717));
		_MinButton.UseVisualStyleBackColor = true;
		_MinButton.Click += _MinButton_Click;
		_MaxButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		_MaxButton.BZBackColor = Color.FromArgb(30, 30, 30);
		_MaxButton.CFormState = ButtonD.CustomFormState.Normal;
		_MaxButton.DisplayText = Class16.smethod_0(1648923968);
		_MaxButton.FlatStyle = FlatStyle.Flat;
		_MaxButton.ForeColor = Color.White;
		_MaxButton.Location = new Point(663, 6);
		_MaxButton.MouseClickColor1 = Color.FromArgb(60, 60, 160);
		_MaxButton.MouseHoverColor = Color.FromArgb(50, 50, 50);
		_MaxButton.Name = Class16.smethod_0(1649117732);
		_MaxButton.Size = new Size(31, 24);
		_MaxButton.TabIndex = 2;
		_MaxButton.Text = Class16.smethod_0(1649117749);
		_MaxButton.TextLocation_X = 8;
		_MaxButton.TextLocation_Y = 6;
		toolTip1.SetToolTip(_MaxButton, Class16.smethod_0(1649118331));
		_MaxButton.UseVisualStyleBackColor = true;
		_MaxButton.Click += _MaxButton_Click;
		_CloseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		_CloseButton.BZBackColor = Color.FromArgb(30, 30, 30);
		_CloseButton.DisplayText = Class16.smethod_0(1648916453);
		_CloseButton.FlatStyle = FlatStyle.Flat;
		_CloseButton.Font = new Font(Class16.smethod_0(1649118691), 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		_CloseButton.ForeColor = Color.White;
		_CloseButton.Image = null;
		_CloseButton.Image_Location = new Point(0, 0);
		_CloseButton.ImageToHeight = false;
		_CloseButton.Location = new Point(694, 6);
		_CloseButton.MouseClickColor1 = Color.FromArgb(60, 60, 160);
		_CloseButton.MouseHoverColor = Color.FromArgb(50, 50, 50);
		_CloseButton.Name = Class16.smethod_0(1649117761);
		_CloseButton.Size = new Size(31, 24);
		_CloseButton.TabIndex = 0;
		_CloseButton.Text = Class16.smethod_0(1648916453);
		_CloseButton.TextLocation_X = 6;
		_CloseButton.TextLocation_Y = 1;
		toolTip1.SetToolTip(_CloseButton, Class16.smethod_0(1649014457));
		_CloseButton.UseVisualStyleBackColor = true;
		_CloseButton.Click += _CloseButton_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(60, 60, 60);
		base.ClientSize = new Size(730, 473);
		base.Controls.Add(LeftTopPanel_2);
		base.Controls.Add(LeftTopPanel_1);
		base.Controls.Add(RightTopPanel_2);
		base.Controls.Add(RightTopPanel_1);
		base.Controls.Add(LeftBottomPanel_2);
		base.Controls.Add(LeftBottomPanel_1);
		base.Controls.Add(RightBottomPanel_2);
		base.Controls.Add(RightBottomPanel_1);
		base.Controls.Add(BottomPanel);
		base.Controls.Add(LeftPanel);
		base.Controls.Add(RightPanel);
		base.Controls.Add(TopBorderPanel);
		base.Controls.Add(TopPanel);
		base.FormBorderStyle = FormBorderStyle.None;
		base.Name = Class16.smethod_0(1649117788);
		Text = Class16.smethod_0(1649118502);
		base.Resize += BlackForm_Resize;
		TopPanel.ResumeLayout(performLayout: false);
		TopPanel.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	private void LeftBottomPanel_1_MouseDown(object sender, MouseEventArgs e)
	{
		bool_1 = true;
	}

	private void LeftBottomPanel_1_MouseMove(object sender, MouseEventArgs e)
	{
		if (e.X < base.Location.X && (bool_1 || base.Height < 50))
		{
			if (base.Width < 100)
			{
				base.Width = 100;
				base.Height = 50;
				bool_1 = false;
			}
			else
			{
				base.Location = new Point(base.Location.X + e.X, base.Location.Y);
				base.Width -= e.X;
				base.Height += e.Y;
			}
		}
	}

	private void LeftBottomPanel_1_MouseUp(object sender, MouseEventArgs e)
	{
		bool_1 = false;
	}

	private void LeftBottomPanel_2_MouseDown(object sender, MouseEventArgs e)
	{
		LeftBottomPanel_1_MouseDown(sender, e);
	}

	private void LeftBottomPanel_2_MouseMove(object sender, MouseEventArgs e)
	{
		LeftBottomPanel_1_MouseMove(sender, e);
	}

	private void LeftBottomPanel_2_MouseUp(object sender, MouseEventArgs e)
	{
		LeftBottomPanel_1_MouseUp(sender, e);
	}

	private void LeftPanel_MouseDown(object sender, MouseEventArgs e)
	{
		if (base.Location.X > 0 && e.X >= 0)
		{
			if (e.Button == MouseButtons.Left)
			{
				bool_2 = true;
			}
			else
			{
				bool_2 = false;
			}
		}
		else
		{
			bool_2 = false;
			base.Location = new Point(10, base.Location.Y);
		}
	}

	private void LeftPanel_MouseMove(object sender, MouseEventArgs e)
	{
		if (e.X < base.Location.X && bool_2)
		{
			if (base.Width < 100)
			{
				base.Width = 100;
				bool_2 = false;
			}
			else
			{
				base.Location = new Point(base.Location.X + e.X, base.Location.Y);
				base.Width -= e.X;
			}
		}
	}

	private void LeftPanel_MouseUp(object sender, MouseEventArgs e)
	{
		bool_2 = false;
	}

	private void LeftTopPanel_1_MouseDown(object sender, MouseEventArgs e)
	{
		bool_3 = true;
	}

	private void LeftTopPanel_1_MouseMove(object sender, MouseEventArgs e)
	{
		if ((e.X < base.Location.X || e.Y < base.Location.Y) && bool_3)
		{
			if (base.Width >= 100 && base.Height >= 50)
			{
				base.Location = new Point(base.Location.X + e.X, base.Location.Y);
				base.Width -= e.X;
				base.Location = new Point(base.Location.X, base.Location.Y + e.Y);
				base.Height -= e.Y;
			}
			else
			{
				base.Width = 100;
				base.Height = 100;
				bool_3 = false;
			}
		}
	}

	private void LeftTopPanel_1_MouseUp(object sender, MouseEventArgs e)
	{
		bool_3 = false;
	}

	private void LeftTopPanel_2_MouseDown(object sender, MouseEventArgs e)
	{
		LeftTopPanel_1_MouseDown(sender, e);
	}

	private void LeftTopPanel_2_MouseMove(object sender, MouseEventArgs e)
	{
		LeftTopPanel_1_MouseMove(sender, e);
	}

	private void LeftTopPanel_2_MouseUp(object sender, MouseEventArgs e)
	{
		LeftTopPanel_1_MouseUp(sender, e);
	}

	private void RightBottomPanel_1_MouseDown(object sender, MouseEventArgs e)
	{
		bool_4 = true;
	}

	private void RightBottomPanel_1_MouseMove(object sender, MouseEventArgs e)
	{
		if (bool_4)
		{
			if (base.Width >= 100 && base.Height >= 50)
			{
				base.Width += e.X;
				base.Height += e.Y;
			}
			else
			{
				base.Width = 100;
				base.Height = 50;
				bool_4 = false;
			}
		}
	}

	private void RightBottomPanel_1_MouseUp(object sender, MouseEventArgs e)
	{
		bool_4 = false;
	}

	private void RightBottomPanel_2_MouseDown(object sender, MouseEventArgs e)
	{
		RightBottomPanel_1_MouseDown(sender, e);
	}

	private void RightBottomPanel_2_MouseMove(object sender, MouseEventArgs e)
	{
		RightBottomPanel_1_MouseMove(sender, e);
	}

	private void RightBottomPanel_2_MouseUp(object sender, MouseEventArgs e)
	{
		RightBottomPanel_1_MouseUp(sender, e);
	}

	private void RightPanel_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			bool_5 = true;
		}
		else
		{
			bool_5 = false;
		}
	}

	private void RightPanel_MouseMove(object sender, MouseEventArgs e)
	{
		if (bool_5)
		{
			if (base.Width < 100)
			{
				base.Width = 100;
				bool_5 = false;
			}
			else
			{
				base.Width += e.X;
			}
		}
	}

	private void RightPanel_MouseUp(object sender, MouseEventArgs e)
	{
		bool_5 = false;
	}

	private void RightTopPanel_1_MouseDown(object sender, MouseEventArgs e)
	{
		bool_6 = true;
	}

	private void RightTopPanel_1_MouseMove(object sender, MouseEventArgs e)
	{
		if ((e.Y < base.Location.Y || e.X < base.Location.X) && bool_6)
		{
			if (base.Height >= 50 && base.Width >= 100)
			{
				base.Location = new Point(base.Location.X, base.Location.Y + e.Y);
				base.Height -= e.Y;
				base.Width += e.X;
			}
			else
			{
				base.Height = 50;
				base.Width = 100;
				bool_6 = false;
			}
		}
	}

	private void RightTopPanel_1_MouseUp(object sender, MouseEventArgs e)
	{
		bool_6 = false;
	}

	private void RightTopPanel_2_MouseDown(object sender, MouseEventArgs e)
	{
		RightTopPanel_1_MouseDown(sender, e);
	}

	private void RightTopPanel_2_MouseMove(object sender, MouseEventArgs e)
	{
		RightTopPanel_1_MouseMove(sender, e);
	}

	private void RightTopPanel_2_MouseUp(object sender, MouseEventArgs e)
	{
		RightTopPanel_1_MouseUp(sender, e);
	}

	private void TopBorderPanel_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			bool_7 = true;
		}
		else
		{
			bool_7 = false;
		}
	}

	private void TopBorderPanel_MouseMove(object sender, MouseEventArgs e)
	{
		if (e.Y < base.Location.Y && bool_7)
		{
			if (base.Height < 50)
			{
				base.Height = 50;
				bool_7 = false;
			}
			else
			{
				base.Location = new Point(base.Location.X, base.Location.Y + e.Y);
				base.Height -= e.Y;
			}
		}
	}

	private void TopBorderPanel_MouseUp(object sender, MouseEventArgs e)
	{
		bool_7 = false;
	}

	private void TopPanel_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			bool_8 = true;
			Point point = PointToScreen(new Point(e.X, e.Y));
			point_1 = default(Point);
			point_1.X = base.Location.X - point.X;
			point_1.Y = base.Location.Y - point.Y;
		}
		else
		{
			bool_8 = false;
		}
		if (e.Clicks == 2)
		{
			bool_8 = false;
			_MaxButton_Click(sender, e);
		}
	}

	private void TopPanel_MouseMove(object sender, MouseEventArgs e)
	{
		if (bool_8)
		{
			Point location = TopPanel.PointToScreen(new Point(e.X, e.Y));
			location.Offset(point_1);
			base.Location = location;
			if ((base.Location.X > 2 || base.Location.Y > 2) && base.WindowState == FormWindowState.Maximized)
			{
				base.Location = point_0;
				base.Size = size_0;
				toolTip1.SetToolTip(_MaxButton, Class16.smethod_0(1649118331));
				_MaxButton.CFormState = ButtonD.CustomFormState.Normal;
				bool_9 = false;
			}
		}
	}

	private void TopPanel_MouseUp(object sender, MouseEventArgs e)
	{
		bool_8 = false;
		if (base.Location.Y <= 5 && !bool_9)
		{
			size_0 = base.Size;
			point_0 = base.Location;
			Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
			base.Location = new Point(0, 0);
			base.Size = new Size(workingArea.Width, workingArea.Height);
			toolTip1.SetToolTip(_MaxButton, Class16.smethod_0(1649118346));
			_MaxButton.CFormState = ButtonD.CustomFormState.Maximize;
			bool_9 = true;
		}
	}

	private void WindowTextLabel_MouseDown(object sender, MouseEventArgs e)
	{
		TopPanel_MouseDown(sender, e);
	}

	private void WindowTextLabel_MouseMove(object sender, MouseEventArgs e)
	{
		TopPanel_MouseMove(sender, e);
	}

	private void WindowTextLabel_MouseUp(object sender, MouseEventArgs e)
	{
		TopPanel_MouseUp(sender, e);
	}
}
