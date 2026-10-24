using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.Domain2;

public class Domain2MapEditor : Form
{
	private enum Enum6
	{

	}

	private sealed class Class103
	{
		private DOMAIN2.DomainInfo[] domainInfo_0 = Array.Empty<DOMAIN2.DomainInfo>();

		private int int_0;

		public DOMAIN2.DomainInfo[] method_0()
		{
			return domainInfo_0;
		}

		public void method_1(DOMAIN2.DomainInfo[] domainInfo_1)
		{
			domainInfo_0 = domainInfo_1;
		}

		public int method_2()
		{
			return int_0;
		}

		public void method_3(int int_1)
		{
			int_0 = int_1;
		}
	}

	private sealed class Class104
	{
		private int int_0;

		private string string_0;

		private int int_1;

		public int method_0()
		{
			return int_0;
		}

		public void method_1(int int_2)
		{
			int_0 = int_2;
		}

		public string method_2()
		{
			return string_0;
		}

		public void method_3(string string_1)
		{
			string_0 = string_1;
		}

		public int method_4()
		{
			return int_1;
		}

		public void method_5(int int_2)
		{
			int_1 = int_2;
		}

		public override string ToString()
		{
			return string.Format(Class16.smethod_0(1648942820), method_4(), method_2());
		}
	}

	private enum Enum7
	{

	}

	private sealed class Class105
	{
		public int int_0;

		public Domain2MapEditor domain2MapEditor_0;

		public DOMAIN2.DomainInfo domainInfo_0;

		public ContextMenuStrip contextMenuStrip_0;

		internal void method_0(object sender, EventArgs e)
		{
			if (int_0 >= 0 && int_0 < domain2MapEditor_0.listBox_0.Items.Count)
			{
				domain2MapEditor_0.listBox_0.SelectedIndex = int_0;
			}
		}

		internal void method_1(object sender, EventArgs e)
		{
			if (domain2MapEditor_0.method_12((Enum6)2, domain2MapEditor_0.method_23(), domainInfo_0, out var string_))
			{
				domain2MapEditor_0.propertyGrid_0.Refresh();
				domain2MapEditor_0.pictureBox_0.Invalidate();
			}
			domain2MapEditor_0.method_21(string_);
		}

		internal void method_2(object sender, EventArgs e)
		{
			if (domain2MapEditor_0.method_12((Enum6)3, domain2MapEditor_0.method_23(), domainInfo_0, out var string_))
			{
				domain2MapEditor_0.propertyGrid_0.Refresh();
				domain2MapEditor_0.pictureBox_0.Invalidate();
			}
			domain2MapEditor_0.method_21(string_);
		}

		internal void method_3(object sender, EventArgs e)
		{
			if (domain2MapEditor_0.method_12((Enum6)4, domain2MapEditor_0.method_23(), domainInfo_0, out var string_))
			{
				domain2MapEditor_0.propertyGrid_0.Refresh();
				domain2MapEditor_0.pictureBox_0.Invalidate();
			}
			domain2MapEditor_0.method_21(string_);
		}

		internal void method_4(object sender, EventArgs e)
		{
			if (domain2MapEditor_0.method_13(int_0, out var string_))
			{
				domain2MapEditor_0.propertyGrid_0.Refresh();
				domain2MapEditor_0.pictureBox_0.Invalidate();
			}
			domain2MapEditor_0.method_21(string_);
		}

		internal void method_5(object sender, ToolStripDropDownClosedEventArgs e)
		{
			contextMenuStrip_0.Dispose();
		}
	}

	private sealed class Class106
	{
		public Domain2MapEditor domain2MapEditor_0;

		public ContextMenuStrip contextMenuStrip_0;

		internal void method_0(object sender, EventArgs e)
		{
			domain2MapEditor_0.method_4();
		}

		internal void method_1(object sender, EventArgs e)
		{
			if (domain2MapEditor_0.list_0.Count > 0)
			{
				domain2MapEditor_0.list_0.RemoveAt(domain2MapEditor_0.list_0.Count - 1);
				domain2MapEditor_0.method_26();
				domain2MapEditor_0.pictureBox_0.Invalidate();
				domain2MapEditor_0.method_21(Class16.smethod_0(1649010721));
			}
		}

		internal void method_2(object sender, EventArgs e)
		{
			domain2MapEditor_0.method_3();
		}

		internal void method_3(object sender, ToolStripDropDownClosedEventArgs e)
		{
			contextMenuStrip_0.Dispose();
		}
	}

	private readonly DOMAIN2 domain2_0;

	private int int_0 = -1;

	private bool bool_0;

	private Enum6 enum6_0;

	private readonly List<PointF> list_0 = new List<PointF>();

	private int int_1 = -1;

	private bool bool_1;

	private bool bool_2;

	private PointF pointF_0;

	private PointF pointF_1;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private Point point_0;

	private Point point_1;

	private float float_0 = 1f;

	private PointF pointF_2 = PointF.Empty;

	private SizeF sizeF_0 = new SizeF(1024f, 768f);

	private Image image_0;

	private string string_0;

	private string string_1;

	private int int_2;

	private bool bool_6;

	private readonly Stack<Class103> stack_0 = new Stack<Class103>();

	private readonly Stack<Class103> stack_1 = new Stack<Class103>();

	private bool bool_7;

	private bool bool_8;

	private IContainer icontainer_0;

	private PictureBox pictureBox_0;

	private Panel panel_0;

	private Button button_0;

	private Button button_1;

	private Button button_2;

	private Button button_3;

	private Button button_4;

	private Button button_5;

	private Button button_6;

	private Button button_7;

	private Button button_8;

	private Button button_9;

	private Label label_0;

	private ListBox listBox_0;

	private PropertyGrid propertyGrid_0;

	private Label label_1;

	private ComboBox comboBox_0;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private CheckBox checkBox_2;

	private CheckBox checkBox_3;

	private CheckBox checkBox_4;

	private ToolTip toolTip_0;

	private Panel panel_1;

	private Panel panel_2;

	public bool HasChanges
	{
		[CompilerGenerated]
		get
		{
			return bool_8;
		}
	}

	public Domain2MapEditor(DOMAIN2 domain2, int selectedDomainIndex = -1)
	{
		domain2_0 = domain2 ?? throw new ArgumentNullException(Class16.smethod_0(1649010756));
		int_0 = selectedDomainIndex;
		method_2();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this, null);
		smethod_0(pictureBox_0);
		smethod_0(panel_0);
		pictureBox_0.MouseDoubleClick += pictureBox_0_MouseDoubleClick;
		panel_0.MouseEnter += panel_0_MouseEnter;
		panel_0.Resize += panel_0_Resize;
		base.KeyPreview = true;
		bool_6 = true;
		if (comboBox_0.Items.Count > 0)
		{
			comboBox_0.SelectedIndex = 0;
		}
		bool_6 = false;
		int_2 = 0;
		method_1();
		method_42();
		method_27();
		method_28();
		method_26();
		method_21(Class16.smethod_0(1649010767));
	}

	private void method_0(bool bool_9)
	{
		bool_8 = bool_9;
	}

	protected override void OnShown(EventArgs eventArgs_0)
	{
		base.OnShown(eventArgs_0);
		pictureBox_0.Focus();
	}

	protected override void OnFormClosed(FormClosedEventArgs formClosedEventArgs_0)
	{
		if (image_0 != null)
		{
			image_0.Dispose();
			image_0 = null;
		}
		base.OnFormClosed(formClosedEventArgs_0);
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		switch (keyData)
		{
		case Keys.Z | Keys.Control:
			if (enum6_0 == (Enum6)1 && list_0.Count > 0)
			{
				list_0.RemoveAt(list_0.Count - 1);
				method_26();
				pictureBox_0.Invalidate();
				method_21(Class16.smethod_0(1649010721));
			}
			else
			{
				method_39();
			}
			return true;
		case Keys.Y | Keys.Control:
			method_40();
			return true;
		case Keys.Return:
			if (enum6_0 == (Enum6)1)
			{
				method_4();
				return true;
			}
			break;
		}
		if (keyData == Keys.Escape)
		{
			method_3();
			return true;
		}
		return base.ProcessCmdKey(ref msg, keyData);
	}

	private static void smethod_0(Control control_0)
	{
		if (control_0 != null)
		{
			typeof(Control).GetProperty(Class16.smethod_0(1648901323), BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(control_0, true, null);
		}
	}

	private void method_1()
	{
		bool_0 = true;
		listBox_0.Items.Clear();
		if (domain2_0.Domains != null)
		{
			for (int i = 0; i < domain2_0.Domains.Length; i++)
			{
				ListBox.ObjectCollection items = listBox_0.Items;
				Class104 @class = new Class104();
				@class.method_1(i);
				@class.method_3(domain2_0.Domains[i].Name);
				@class.method_5(domain2_0.Domains[i].ID);
				items.Add(@class);
			}
		}
		if (listBox_0.Items.Count == 0)
		{
			int_0 = -1;
			propertyGrid_0.SelectedObject = null;
		}
		else
		{
			if (int_0 < 0 || int_0 >= listBox_0.Items.Count)
			{
				int_0 = 0;
			}
			listBox_0.SelectedIndex = int_0;
			propertyGrid_0.SelectedObject = domain2_0.Domains[int_0];
		}
		bool_0 = false;
	}

	private void listBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			if (listBox_0.SelectedItem is Class104 @class)
			{
				int_0 = @class.method_0();
				propertyGrid_0.SelectedObject = domain2_0.Domains[int_0];
				method_26();
				pictureBox_0.Invalidate();
			}
			else
			{
				int_0 = -1;
				propertyGrid_0.SelectedObject = null;
				method_26();
				pictureBox_0.Invalidate();
			}
		}
	}

	private void method_2()
	{
		icontainer_0 = new Container();
		pictureBox_0 = new PictureBox();
		panel_0 = new Panel();
		button_0 = new Button();
		button_1 = new Button();
		button_2 = new Button();
		button_3 = new Button();
		button_4 = new Button();
		button_6 = new Button();
		button_5 = new Button();
		button_7 = new Button();
		button_8 = new Button();
		button_9 = new Button();
		label_1 = new Label();
		comboBox_0 = new ComboBox();
		checkBox_0 = new CheckBox();
		checkBox_1 = new CheckBox();
		checkBox_2 = new CheckBox();
		checkBox_3 = new CheckBox();
		checkBox_4 = new CheckBox();
		label_0 = new Label();
		listBox_0 = new ListBox();
		propertyGrid_0 = new PropertyGrid();
		toolTip_0 = new ToolTip(icontainer_0);
		panel_1 = new Panel();
		panel_2 = new Panel();
		((ISupportInitialize)pictureBox_0).BeginInit();
		panel_0.SuspendLayout();
		panel_1.SuspendLayout();
		panel_2.SuspendLayout();
		SuspendLayout();
		pictureBox_0.BackColor = Color.White;
		pictureBox_0.Location = new Point(0, 0);
		pictureBox_0.Name = Class16.smethod_0(1649010797);
		pictureBox_0.Size = new Size(1024, 768);
		pictureBox_0.SizeMode = PictureBoxSizeMode.AutoSize;
		pictureBox_0.TabIndex = 0;
		pictureBox_0.TabStop = false;
		pictureBox_0.Paint += pictureBox_0_Paint;
		pictureBox_0.MouseDown += pictureBox_0_MouseDown;
		pictureBox_0.MouseMove += pictureBox_0_MouseMove;
		pictureBox_0.MouseUp += pictureBox_0_MouseUp;
		pictureBox_0.MouseWheel += panel_0_MouseWheel;
		panel_0.AutoScroll = true;
		panel_0.BackColor = Color.FromArgb(32, 32, 32);
		panel_0.Controls.Add(pictureBox_0);
		panel_0.Dock = DockStyle.Fill;
		panel_0.Location = new Point(242, 0);
		panel_0.Name = Class16.smethod_0(1649010810);
		panel_0.Size = new Size(888, 875);
		panel_0.TabIndex = 1;
		panel_0.MouseWheel += panel_0_MouseWheel;
		button_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_0.Location = new Point(10, 10);
		button_0.Name = Class16.smethod_0(1649010826);
		button_0.Size = new Size(220, 30);
		button_0.TabIndex = 0;
		button_0.Text = Class16.smethod_0(1649010853);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_1.Location = new Point(10, 46);
		button_1.Name = Class16.smethod_0(1649010869);
		button_1.Size = new Size(220, 30);
		button_1.TabIndex = 1;
		button_1.Text = Class16.smethod_0(1649010883);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		button_2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_2.Location = new Point(10, 82);
		button_2.Name = Class16.smethod_0(1649010910);
		button_2.Size = new Size(220, 30);
		button_2.TabIndex = 2;
		button_2.Text = Class16.smethod_0(1649010935);
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		button_3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_3.Location = new Point(10, 118);
		button_3.Name = Class16.smethod_0(1649010957);
		button_3.Size = new Size(220, 30);
		button_3.TabIndex = 3;
		button_3.Text = Class16.smethod_0(1649010970);
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		button_4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_4.Location = new Point(10, 154);
		button_4.Name = Class16.smethod_0(1649010996);
		button_4.Size = new Size(220, 30);
		button_4.TabIndex = 4;
		button_4.Text = Class16.smethod_0(1649011015);
		button_4.UseVisualStyleBackColor = true;
		button_4.Click += button_4_Click;
		button_6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_6.BackColor = Color.LightGreen;
		button_6.Enabled = false;
		button_6.Location = new Point(10, 190);
		button_6.Name = Class16.smethod_0(1649011031);
		button_6.Size = new Size(220, 30);
		button_6.TabIndex = 5;
		button_6.Text = Class16.smethod_0(1649011055);
		button_6.UseVisualStyleBackColor = false;
		button_6.Click += button_6_Click;
		button_5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_5.BackColor = Color.LightCoral;
		button_5.Enabled = false;
		button_5.Location = new Point(10, 226);
		button_5.Name = Class16.smethod_0(1649011067);
		button_5.Size = new Size(220, 30);
		button_5.TabIndex = 6;
		button_5.Text = Class16.smethod_0(1649011090);
		button_5.UseVisualStyleBackColor = false;
		button_5.Click += button_5_Click;
		button_7.Enabled = false;
		button_7.Location = new Point(10, 262);
		button_7.Name = Class16.smethod_0(1649011118);
		button_7.Size = new Size(108, 30);
		button_7.TabIndex = 7;
		button_7.Image = Resources.GShopEditor_PW_mbUndo;
		button_7.ImageAlign = ContentAlignment.MiddleLeft;
		button_7.Text = Class16.smethod_0(1648903487);
		button_7.TextAlign = ContentAlignment.MiddleRight;
		button_7.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_7.UseVisualStyleBackColor = true;
		button_7.Click += button_7_Click;
		button_8.Enabled = false;
		button_8.Location = new Point(122, 262);
		button_8.Name = Class16.smethod_0(1649011133);
		button_8.Size = new Size(108, 30);
		button_8.TabIndex = 8;
		button_8.Image = Resources.GShopEditor_PW_mbRedo;
		button_8.ImageAlign = ContentAlignment.MiddleLeft;
		button_8.Text = Class16.smethod_0(1648903490);
		button_8.TextAlign = ContentAlignment.MiddleRight;
		button_8.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_8.UseVisualStyleBackColor = true;
		button_8.Click += button_8_Click;
		button_9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		button_9.Location = new Point(10, 298);
		button_9.Name = Class16.smethod_0(1649011148);
		button_9.Size = new Size(220, 30);
		button_9.TabIndex = 9;
		button_9.Text = Class16.smethod_0(1649011160);
		button_9.UseVisualStyleBackColor = true;
		button_9.Click += button_9_Click;
		label_1.AutoSize = true;
		label_1.Location = new Point(10, 337);
		label_1.Name = Class16.smethod_0(1649011177);
		label_1.Size = new Size(68, 13);
		label_1.TabIndex = 10;
		label_1.Text = Class16.smethod_0(1649006085);
		comboBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Items.AddRange(new object[3]
		{
			Class16.smethod_0(1649006103),
			Class16.smethod_0(1649006107),
			Class16.smethod_0(1649006120)
		});
		comboBox_0.Location = new Point(10, 354);
		comboBox_0.Name = Class16.smethod_0(1649006136);
		comboBox_0.Size = new Size(220, 21);
		comboBox_0.TabIndex = 11;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		checkBox_0.AutoSize = true;
		checkBox_0.Checked = true;
		checkBox_0.CheckState = CheckState.Checked;
		checkBox_0.Location = new Point(10, 385);
		checkBox_0.Name = Class16.smethod_0(1649006164);
		checkBox_0.Size = new Size(106, 17);
		checkBox_0.TabIndex = 12;
		checkBox_0.Text = Class16.smethod_0(1649006188);
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_0.CheckedChanged += checkBox_4_CheckedChanged;
		checkBox_1.AutoSize = true;
		checkBox_1.Checked = true;
		checkBox_1.CheckState = CheckState.Checked;
		checkBox_1.Location = new Point(10, 409);
		checkBox_1.Name = Class16.smethod_0(1649006201);
		checkBox_1.Size = new Size(86, 17);
		checkBox_1.TabIndex = 13;
		checkBox_1.Text = Class16.smethod_0(1649006231);
		checkBox_1.UseVisualStyleBackColor = true;
		checkBox_1.CheckedChanged += checkBox_4_CheckedChanged;
		checkBox_2.AutoSize = true;
		checkBox_2.Checked = true;
		checkBox_2.CheckState = CheckState.Checked;
		checkBox_2.Location = new Point(10, 433);
		checkBox_2.Name = Class16.smethod_0(1649006242);
		checkBox_2.Size = new Size(66, 17);
		checkBox_2.TabIndex = 14;
		checkBox_2.Text = Class16.smethod_0(1649006268);
		checkBox_2.UseVisualStyleBackColor = true;
		checkBox_2.CheckedChanged += checkBox_4_CheckedChanged;
		checkBox_3.AutoSize = true;
		checkBox_3.Checked = true;
		checkBox_3.CheckState = CheckState.Checked;
		checkBox_3.Location = new Point(10, 457);
		checkBox_3.Name = Class16.smethod_0(1649006274);
		checkBox_3.Size = new Size(90, 17);
		checkBox_3.TabIndex = 15;
		checkBox_3.Text = Class16.smethod_0(1649006302);
		checkBox_3.UseVisualStyleBackColor = true;
		checkBox_3.CheckedChanged += checkBox_4_CheckedChanged;
		checkBox_4.AutoSize = true;
		checkBox_4.Location = new Point(10, 481);
		checkBox_4.Name = Class16.smethod_0(1649006318);
		checkBox_4.Size = new Size(98, 17);
		checkBox_4.TabIndex = 16;
		checkBox_4.Text = Class16.smethod_0(1649006343);
		checkBox_4.UseVisualStyleBackColor = true;
		checkBox_4.CheckedChanged += checkBox_4_CheckedChanged;
		label_0.BackColor = Color.FromArgb(220, 220, 220);
		label_0.Dock = DockStyle.Bottom;
		label_0.Location = new Point(0, 875);
		label_0.Name = Class16.smethod_0(1649006365);
		label_0.Padding = new Padding(10, 0, 0, 0);
		label_0.Size = new Size(1480, 25);
		label_0.TabIndex = 4;
		label_0.Text = Class16.smethod_0(1649006382);
		label_0.TextAlign = ContentAlignment.MiddleLeft;
		listBox_0.Dock = DockStyle.Top;
		listBox_0.FormattingEnabled = true;
		listBox_0.Location = new Point(0, 0);
		listBox_0.Name = Class16.smethod_0(1649006403);
		listBox_0.Size = new Size(350, 251);
		listBox_0.TabIndex = 0;
		listBox_0.SelectedIndexChanged += listBox_0_SelectedIndexChanged;
		propertyGrid_0.Dock = DockStyle.Fill;
		propertyGrid_0.Location = new Point(0, 251);
		propertyGrid_0.Name = Class16.smethod_0(1649006429);
		propertyGrid_0.Size = new Size(350, 624);
		propertyGrid_0.TabIndex = 1;
		propertyGrid_0.PropertyValueChanged += propertyGrid_0_PropertyValueChanged;
		panel_1.BackColor = Color.FromArgb(245, 245, 245);
		panel_1.Controls.Add(button_0);
		panel_1.Controls.Add(button_1);
		panel_1.Controls.Add(button_2);
		panel_1.Controls.Add(button_3);
		panel_1.Controls.Add(button_4);
		panel_1.Controls.Add(button_6);
		panel_1.Controls.Add(button_5);
		panel_1.Controls.Add(button_7);
		panel_1.Controls.Add(button_8);
		panel_1.Controls.Add(button_9);
		panel_1.Controls.Add(label_1);
		panel_1.Controls.Add(comboBox_0);
		panel_1.Controls.Add(checkBox_0);
		panel_1.Controls.Add(checkBox_1);
		panel_1.Controls.Add(checkBox_2);
		panel_1.Controls.Add(checkBox_3);
		panel_1.Controls.Add(checkBox_4);
		panel_1.Dock = DockStyle.Left;
		panel_1.Location = new Point(0, 0);
		panel_1.Name = Class16.smethod_0(1649006441);
		panel_1.Size = new Size(242, 875);
		panel_1.TabIndex = 0;
		panel_2.Controls.Add(propertyGrid_0);
		panel_2.Controls.Add(listBox_0);
		panel_2.Dock = DockStyle.Right;
		panel_2.Location = new Point(1130, 0);
		panel_2.Name = Class16.smethod_0(1649006457);
		panel_2.Size = new Size(350, 875);
		panel_2.TabIndex = 2;
		base.ClientSize = new Size(1480, 900);
		base.Controls.Add(panel_0);
		base.Controls.Add(panel_1);
		base.Controls.Add(panel_2);
		base.Controls.Add(label_0);
		base.Icon = Resources.Domain2Editor_Icon;
		MinimumSize = new Size(1200, 700);
		base.Name = Class16.smethod_0(1649006474);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649006497);
		base.Activated += Domain2MapEditor_Activated;
		((ISupportInitialize)pictureBox_0).EndInit();
		panel_0.ResumeLayout(performLayout: false);
		panel_0.PerformLayout();
		panel_1.ResumeLayout(performLayout: false);
		panel_1.PerformLayout();
		panel_2.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (!method_22())
		{
			return;
		}
		enum6_0 = (Enum6)1;
		list_0.Clear();
		DOMAIN2.DomainInfo domainInfo = method_23();
		if (domainInfo?.Points != null)
		{
			foreach (DOMAIN2.DOMAIN_POINT point in domainInfo.Points)
			{
				list_0.Add(method_33(point));
			}
		}
		method_26();
		pictureBox_0.Invalidate();
		method_21(Class16.smethod_0(1649006522));
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		if (method_22())
		{
			enum6_0 = (Enum6)2;
			method_26();
			method_21(Class16.smethod_0(1649005588));
		}
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		if (method_22())
		{
			enum6_0 = (Enum6)3;
			method_26();
			method_21(Class16.smethod_0(1649005664));
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		if (method_22())
		{
			enum6_0 = (Enum6)4;
			method_26();
			method_21(Class16.smethod_0(1649005715));
		}
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		if (method_22())
		{
			DOMAIN2.DomainInfo domainInfo = method_23();
			if (domainInfo?.Points != null && domainInfo.Points.Count >= 3)
			{
				enum6_0 = (Enum6)5;
				method_26();
				method_21(Class16.smethod_0(1649005817));
			}
			else
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649005787)), TextStorage.Msg(Class16.smethod_0(1648943005)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		method_4();
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		method_3();
	}

	private void button_7_Click(object sender, EventArgs e)
	{
		if (enum6_0 == (Enum6)1 && list_0.Count > 0)
		{
			list_0.RemoveAt(list_0.Count - 1);
			method_26();
			pictureBox_0.Invalidate();
			method_21(Class16.smethod_0(1649010721));
		}
		else
		{
			method_39();
		}
	}

	private void button_8_Click(object sender, EventArgs e)
	{
		method_40();
	}

	private void button_9_Click(object sender, EventArgs e)
	{
		method_35();
	}

	private void method_3()
	{
		enum6_0 = (Enum6)0;
		list_0.Clear();
		int_1 = -1;
		bool_1 = false;
		bool_2 = false;
		bool_3 = false;
		bool_4 = false;
		pictureBox_0.Cursor = Cursors.Default;
		method_26();
		pictureBox_0.Invalidate();
		method_21(Class16.smethod_0(1649005899));
	}

	private void method_4()
	{
		if (enum6_0 == (Enum6)1 && method_22() && method_5(bool_9: true, bool_10: true))
		{
			DOMAIN2.DomainInfo domainInfo = method_23();
			enum6_0 = (Enum6)0;
			list_0.Clear();
			int_1 = -1;
			bool_1 = false;
			method_26();
			pictureBox_0.Invalidate();
			method_21(string.Format(Class16.smethod_0(1649005922), domainInfo.Name, domainInfo.Points.Count, domainInfo.Triangles.Count));
		}
	}

	private bool method_5(bool bool_9, bool bool_10)
	{
		List<PointF> list = smethod_8(list_0);
		if (list.Count < 3)
		{
			if (bool_9)
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649005977)), TextStorage.Msg(Class16.smethod_0(1648943005)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			return false;
		}
		List<int> list2 = smethod_9(list);
		if (list2 != null && list2.Count != 0 && list2.Count % 3 == 0)
		{
			if (bool_10)
			{
				method_37();
			}
			DOMAIN2.DomainInfo domainInfo = method_23();
			domainInfo.Points = new ObservableCollection<DOMAIN2.DOMAIN_POINT>();
			domainInfo.Triangles = new ObservableCollection<DOMAIN2.DOMAIN_TRIANGLE>();
			foreach (PointF item in list)
			{
				PointF pointF = method_31(item);
				domainInfo.Points.Add(new DOMAIN2.DOMAIN_POINT
				{
					Int32_1 = (int)Math.Round(pointF.X),
					Int32_0 = (int)Math.Round(pointF.Y)
				});
			}
			for (int i = 0; i < list2.Count; i += 3)
			{
				domainInfo.Triangles.Add(new DOMAIN2.DOMAIN_TRIANGLE
				{
					id1 = list2[i],
					id2 = list2[i + 1],
					id3 = list2[i + 2]
				});
			}
			propertyGrid_0.Refresh();
			method_27();
			method_28();
			if (bool_10)
			{
				method_38();
			}
			return true;
		}
		if (bool_9)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649006002)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return false;
	}

	private void method_6(Point point_2)
	{
		Class106 @class = new Class106();
		@class.domain2MapEditor_0 = this;
		@class.contextMenuStrip_0 = new ContextMenuStrip();
		ToolStripItem toolStripItem = @class.contextMenuStrip_0.Items.Add(TextStorage.Msg(Class16.smethod_0(1649006032)));
		toolStripItem.Enabled = list_0.Count >= 3;
		toolStripItem.Click += @class.method_0;
		ToolStripItem toolStripItem2 = @class.contextMenuStrip_0.Items.Add(TextStorage.Msg(Class16.smethod_0(1649006068)));
		toolStripItem2.Enabled = list_0.Count > 0;
		toolStripItem2.Click += @class.method_1;
		ToolStripItem toolStripItem3 = @class.contextMenuStrip_0.Items.Add(TextStorage.Msg(Class16.smethod_0(1649005070), Class16.smethod_0(1648941799)));
		toolStripItem3.Click += @class.method_2;
		@class.contextMenuStrip_0.Closed += @class.method_3;
		@class.contextMenuStrip_0.Show(pictureBox_0, point_2);
	}

	private void method_7(int int_3, Point point_2)
	{
		Class105 @class = new Class105();
		@class.int_0 = int_3;
		@class.domain2MapEditor_0 = this;
		if (@class.int_0 >= 0 && @class.int_0 < domain2_0.Domains.Length)
		{
			@class.contextMenuStrip_0 = new ContextMenuStrip();
			@class.domainInfo_0 = domain2_0.Domains[@class.int_0];
			ToolStripItem toolStripItem = @class.contextMenuStrip_0.Items.Add(string.Format(Class16.smethod_0(1649005082), @class.domainInfo_0.ID, @class.domainInfo_0.Name));
			toolStripItem.Click += @class.method_0;
			if (method_22() && @class.int_0 != int_0)
			{
				@class.contextMenuStrip_0.Items.Add(new ToolStripSeparator());
				ToolStripItem toolStripItem2 = @class.contextMenuStrip_0.Items.Add(TextStorage.Msg(Class16.smethod_0(1649005105)));
				toolStripItem2.Click += @class.method_1;
				ToolStripItem toolStripItem3 = @class.contextMenuStrip_0.Items.Add(TextStorage.Msg(Class16.smethod_0(1649005140)));
				toolStripItem3.Click += @class.method_2;
				ToolStripItem toolStripItem4 = @class.contextMenuStrip_0.Items.Add(TextStorage.Msg(Class16.smethod_0(1649005162)));
				toolStripItem4.Enabled = @class.domainInfo_0.IsCapital != 0;
				toolStripItem4.Click += @class.method_3;
			}
			@class.contextMenuStrip_0.Items.Add(new ToolStripSeparator());
			ToolStripItem toolStripItem5 = @class.contextMenuStrip_0.Items.Add((@class.domainInfo_0.IsCapital == 0) ? Class16.smethod_0(1649005217) : Class16.smethod_0(1649005192));
			toolStripItem5.Click += @class.method_4;
			@class.contextMenuStrip_0.Closed += @class.method_5;
			@class.contextMenuStrip_0.Show(pictureBox_0, point_2);
		}
	}

	private void pictureBox_0_MouseDown(object sender, MouseEventArgs e)
	{
		pictureBox_0.Focus();
		if (e.Button == MouseButtons.Right)
		{
			pointF_0 = method_30(e.Location);
			if (enum6_0 == (Enum6)1)
			{
				method_6(e.Location);
				return;
			}
			int num = method_8(pointF_0);
			if (num >= 0)
			{
				method_7(num, e.Location);
			}
		}
		else if (e.Button == MouseButtons.Middle)
		{
			bool_5 = true;
			point_0 = e.Location;
			point_1 = new Point(-panel_0.AutoScrollPosition.X, -panel_0.AutoScrollPosition.Y);
			pictureBox_0.Cursor = Cursors.Hand;
		}
		else
		{
			if (e.Button != MouseButtons.Left)
			{
				return;
			}
			pointF_0 = method_30(e.Location);
			if (enum6_0 == (Enum6)1)
			{
				if (method_9(pointF_0, out var int_))
				{
					int_1 = int_;
					bool_1 = true;
					pictureBox_0.Cursor = Cursors.SizeAll;
				}
				else if (list_0.Count >= 3 && smethod_7(list_0[0], pointF_0) <= 6f)
				{
					method_4();
				}
				else
				{
					list_0.Add(pointF_0);
					method_26();
					pictureBox_0.Invalidate();
				}
			}
			else if (enum6_0 == (Enum6)5 && method_22())
			{
				int num2 = method_8(pointF_0);
				if (num2 == int_0)
				{
					bool_2 = true;
					pointF_1 = pointF_0;
					bool_3 = false;
					bool_4 = false;
					pictureBox_0.Cursor = Cursors.SizeAll;
				}
			}
			else if (enum6_0 != (Enum6)2 && enum6_0 != (Enum6)3 && enum6_0 != (Enum6)4)
			{
				int num3 = method_8(pointF_0);
				if (num3 >= 0 && num3 < listBox_0.Items.Count)
				{
					listBox_0.SelectedIndex = num3;
				}
			}
			else
			{
				int num4 = method_8(pointF_0);
				if (num4 >= 0)
				{
					method_11(num4);
				}
			}
		}
	}

	private void pictureBox_0_MouseMove(object sender, MouseEventArgs e)
	{
		if (bool_5)
		{
			Point point = new Point(e.X - point_0.X, e.Y - point_0.Y);
			int num = Math.Max(0, point_1.X - point.X);
			int num2 = Math.Max(0, point_1.Y - point.Y);
			panel_0.AutoScrollPosition = new Point(num, num2);
			return;
		}
		pointF_0 = method_30(e.Location);
		if (enum6_0 == (Enum6)1 && bool_1 && int_1 >= 0 && int_1 < list_0.Count)
		{
			list_0[int_1] = pointF_0;
			pictureBox_0.Invalidate();
		}
		else if (enum6_0 == (Enum6)5 && bool_2 && method_22())
		{
			int num3 = (int)Math.Round(pointF_0.X - pointF_1.X);
			int num4 = (int)Math.Round(pointF_0.Y - pointF_1.Y);
			if (num3 != 0 || num4 != 0)
			{
				if (!bool_3)
				{
					method_37();
					bool_3 = true;
				}
				if (method_10(num3, num4))
				{
					bool_4 = true;
					pictureBox_0.Invalidate();
				}
				pointF_1 = pointF_0;
			}
		}
		else if (enum6_0 == (Enum6)1)
		{
			pictureBox_0.Invalidate();
		}
		int num5 = method_8(pointF_0);
		if (num5 >= 0)
		{
			DOMAIN2.DomainInfo domainInfo = domain2_0.Domains[num5];
			toolTip_0.SetToolTip(pictureBox_0, string.Format(Class16.smethod_0(1649005240), domainInfo.Name, domainInfo.ID));
			if (enum6_0 == (Enum6)0)
			{
				pictureBox_0.Cursor = Cursors.Hand;
			}
		}
		else
		{
			toolTip_0.SetToolTip(pictureBox_0, string.Empty);
			if (!bool_1 && !bool_2 && !bool_5)
			{
				pictureBox_0.Cursor = Cursors.Default;
			}
		}
	}

	private void pictureBox_0_MouseUp(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Middle)
		{
			bool_5 = false;
			pictureBox_0.Cursor = Cursors.Default;
		}
		else
		{
			if (e.Button != MouseButtons.Left)
			{
				return;
			}
			if (bool_1)
			{
				bool_1 = false;
				int_1 = -1;
				pictureBox_0.Cursor = Cursors.Default;
				method_26();
				method_21(Class16.smethod_0(1649005268));
			}
			else if (bool_2)
			{
				bool_2 = false;
				enum6_0 = (Enum6)0;
				pictureBox_0.Cursor = Cursors.Default;
				method_27();
				method_28();
				propertyGrid_0.Refresh();
				method_26();
				if (bool_4)
				{
					method_38();
					method_21(Class16.smethod_0(1649005341));
				}
				else
				{
					method_21(Class16.smethod_0(1649005359));
				}
				bool_3 = false;
				bool_4 = false;
			}
		}
	}

	private void pictureBox_0_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left && enum6_0 == (Enum6)1 && list_0.Count >= 3)
		{
			method_4();
		}
	}

	private void panel_0_MouseWheel(object sender, MouseEventArgs e)
	{
		Point point_ = e.Location;
		if (sender == panel_0)
		{
			Point p = panel_0.PointToScreen(e.Location);
			point_ = pictureBox_0.PointToClient(p);
		}
		float float_ = ((e.Delta > 0) ? (float_0 * 1.15f) : (float_0 / 1.15f));
		method_34(float_, point_);
	}

	private int method_8(PointF pointF_3)
	{
		if (domain2_0.Domains == null)
		{
			return -1;
		}
		int num = domain2_0.Domains.Length - 1;
		while (true)
		{
			if (num >= 0)
			{
				DOMAIN2.DomainInfo domainInfo = domain2_0.Domains[num];
				if (domainInfo?.Points != null && domainInfo.Points.Count >= 3)
				{
					PointF[] pointF_4 = domainInfo.Points.Select(method_33).ToArray();
					if (smethod_1(pointF_3, pointF_4))
					{
						break;
					}
				}
				num--;
				continue;
			}
			return -1;
		}
		return num;
	}

	private static bool smethod_1(PointF pointF_3, PointF[] pointF_4)
	{
		bool flag = false;
		int num = pointF_4.Length - 1;
		for (int i = 0; i < pointF_4.Length; i++)
		{
			if (pointF_4[i].Y > pointF_3.Y != pointF_4[num].Y > pointF_3.Y && pointF_3.X < (pointF_4[num].X - pointF_4[i].X) * (pointF_3.Y - pointF_4[i].Y) / (pointF_4[num].Y - pointF_4[i].Y) + pointF_4[i].X)
			{
				flag = !flag;
			}
			num = i;
		}
		return flag;
	}

	private bool method_9(PointF pointF_3, out int int_3)
	{
		int num = 0;
		while (true)
		{
			if (num < list_0.Count)
			{
				if (!(smethod_7(list_0[num], pointF_3) > 6f))
				{
					break;
				}
				num++;
				continue;
			}
			int_3 = -1;
			return false;
		}
		int_3 = num;
		return true;
	}

	private bool method_10(int int_3, int int_4)
	{
		DOMAIN2.DomainInfo domainInfo = method_23();
		if (domainInfo?.Points != null && domainInfo.Points.Count != 0)
		{
			if (int_3 == 0 && int_4 == 0)
			{
				return false;
			}
			foreach (DOMAIN2.DOMAIN_POINT point in domainInfo.Points)
			{
				point.Int32_1 += int_3;
				point.Int32_0 += int_4;
			}
			return true;
		}
		return false;
	}

	private void method_11(int int_3)
	{
		if (method_22() && int_3 >= 0 && int_3 < domain2_0.Domains.Length)
		{
			DOMAIN2.DomainInfo domainInfo_ = method_23();
			DOMAIN2.DomainInfo domainInfo_2 = domain2_0.Domains[int_3];
			if (method_12(enum6_0, domainInfo_, domainInfo_2, out var string_))
			{
				enum6_0 = (Enum6)0;
				propertyGrid_0.Refresh();
			}
			method_26();
			pictureBox_0.Invalidate();
			method_21(string_);
		}
	}

	private bool method_12(Enum6 enum6_1, DOMAIN2.DomainInfo domainInfo_0, DOMAIN2.DomainInfo domainInfo_1, out string string_2)
	{
		string_2 = Class16.smethod_0(1649005380);
		if (domainInfo_0 != null && domainInfo_1 != null)
		{
			switch (enum6_1)
			{
			default:
				return false;
			case (Enum6)2:
			{
				if (domainInfo_0.ID == domainInfo_1.ID)
				{
					string_2 = Class16.smethod_0(1649005406);
					return false;
				}
				bool flag = domainInfo_0.Neighbors != null && domainInfo_0.Neighbors.Contains(domainInfo_1.ID);
				bool flag2 = domainInfo_1.Neighbors != null && domainInfo_1.Neighbors.Contains(domainInfo_0.ID);
				if (flag && flag2)
				{
					string_2 = domainInfo_1.Name + Class16.smethod_0(1649005437);
					return false;
				}
				method_37();
				smethod_3(domainInfo_0, domainInfo_1);
				method_38();
				string_2 = Class16.smethod_0(1649005459) + domainInfo_1.Name + Class16.smethod_0(1648928036);
				return true;
			}
			case (Enum6)3:
				if (domainInfo_0.ID == domainInfo_1.ID)
				{
					string_2 = Class16.smethod_0(1649005406);
					return false;
				}
				if ((domainInfo_0.Neighbors == null || !domainInfo_0.Neighbors.Contains(domainInfo_1.ID)) && (domainInfo_1.Neighbors == null || !domainInfo_1.Neighbors.Contains(domainInfo_0.ID)))
				{
					string_2 = domainInfo_1.Name + Class16.smethod_0(1649005482);
					return false;
				}
				method_37();
				smethod_4(domainInfo_0, domainInfo_1);
				method_38();
				string_2 = Class16.smethod_0(1649005516) + domainInfo_1.Name + Class16.smethod_0(1648928036);
				return true;
			case (Enum6)4:
				if (domainInfo_1.IsCapital == 0)
				{
					string_2 = Class16.smethod_0(1649005541);
					return false;
				}
				if (domainInfo_0.CountryId == domainInfo_1.CountryId)
				{
					string_2 = string.Format(Class16.smethod_0(1649004564), domainInfo_0.Name, domainInfo_1.CountryId);
					return false;
				}
				method_37();
				domainInfo_0.CountryId = domainInfo_1.CountryId;
				method_38();
				string_2 = string.Format(Class16.smethod_0(1649004595), domainInfo_1.Name, domainInfo_0.Name, domainInfo_1.CountryId);
				return true;
			}
		}
		return false;
	}

	private bool method_13(int int_3, out string string_2)
	{
		string_2 = Class16.smethod_0(1649005380);
		if (domain2_0.Domains != null && int_3 >= 0 && int_3 < domain2_0.Domains.Length)
		{
			DOMAIN2.DomainInfo domainInfo = domain2_0.Domains[int_3];
			int num = ((domainInfo.IsCapital == 0) ? 1 : 0);
			if (domainInfo.IsCapital == num)
			{
				return false;
			}
			method_37();
			domainInfo.IsCapital = num;
			method_38();
			string_2 = ((num == 0) ? (Class16.smethod_0(1649004678) + domainInfo.Name + Class16.smethod_0(1648928036)) : (Class16.smethod_0(1649004653) + domainInfo.Name + Class16.smethod_0(1648928036)));
			return true;
		}
		return false;
	}

	private static void smethod_2(DOMAIN2.DomainInfo domainInfo_0)
	{
		if (domainInfo_0.Neighbors == null)
		{
			domainInfo_0.Neighbors = new ObservableCollection<int>();
		}
	}

	private static bool smethod_3(DOMAIN2.DomainInfo domainInfo_0, DOMAIN2.DomainInfo domainInfo_1)
	{
		if (domainInfo_0 != null && domainInfo_1 != null && domainInfo_0.ID != domainInfo_1.ID)
		{
			smethod_2(domainInfo_0);
			smethod_2(domainInfo_1);
			bool result = false;
			if (!domainInfo_0.Neighbors.Contains(domainInfo_1.ID))
			{
				domainInfo_0.Neighbors.Add(domainInfo_1.ID);
				result = true;
			}
			if (!domainInfo_1.Neighbors.Contains(domainInfo_0.ID))
			{
				domainInfo_1.Neighbors.Add(domainInfo_0.ID);
				result = true;
			}
			return result;
		}
		return false;
	}

	private static bool smethod_4(DOMAIN2.DomainInfo domainInfo_0, DOMAIN2.DomainInfo domainInfo_1)
	{
		if (domainInfo_0 != null && domainInfo_1 != null && domainInfo_0.Neighbors != null && domainInfo_1.Neighbors != null)
		{
			bool result = false;
			while (domainInfo_0.Neighbors.Contains(domainInfo_1.ID))
			{
				domainInfo_0.Neighbors.Remove(domainInfo_1.ID);
				result = true;
			}
			while (domainInfo_1.Neighbors.Contains(domainInfo_0.ID))
			{
				domainInfo_1.Neighbors.Remove(domainInfo_0.ID);
				result = true;
			}
			return result;
		}
		return false;
	}

	private void pictureBox_0_Paint(object sender, PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		graphics.SmoothingMode = SmoothingMode.AntiAlias;
		graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
		graphics.Clear(Color.FromArgb(26, 26, 26));
		graphics.ScaleTransform(float_0, float_0);
		method_14(graphics);
		method_15(graphics);
		method_16(graphics);
		method_20(graphics);
	}

	private void method_14(Graphics graphics_0)
	{
		if (image_0 != null)
		{
			PointF pointF = method_32(0f, 0f);
			graphics_0.DrawImage(image_0, pointF.X, pointF.Y, image_0.Width, image_0.Height);
		}
	}

	private void method_15(Graphics graphics_0)
	{
		Pen pen = new Pen(Color.FromArgb(35, 255, 255, 255), 1f);
		try
		{
			for (float num = 0f; num <= sizeF_0.Width; num += 100f)
			{
				graphics_0.DrawLine(pen, num, 0f, num, sizeF_0.Height);
			}
			for (float num2 = 0f; num2 <= sizeF_0.Height; num2 += 100f)
			{
				graphics_0.DrawLine(pen, 0f, num2, sizeF_0.Width, num2);
			}
		}
		finally
		{
			((IDisposable)pen).Dispose();
		}
	}

	private void method_16(Graphics graphics_0)
	{
		if (domain2_0.Domains != null && domain2_0.Domains.Length != 0)
		{
			List<int> list = Enumerable.Range(0, domain2_0.Domains.Length).ToList();
			list.Sort(method_47);
			{
				foreach (int item in list)
				{
					method_18(graphics_0, domain2_0.Domains[item], item);
				}
				return;
			}
		}
		Font font = new Font(Class16.smethod_0(1648942905), 13f, FontStyle.Bold);
		try
		{
			Brush brush = new SolidBrush(Color.Gainsboro);
			try
			{
				graphics_0.DrawString(Class16.smethod_0(1649004699), font, brush, 30f, 30f);
			}
			finally
			{
				((IDisposable)brush).Dispose();
			}
		}
		finally
		{
			((IDisposable)font).Dispose();
		}
	}

	private int method_17(int int_3)
	{
		if (int_3 == int_0)
		{
			return 3;
		}
		Enum7 @enum = method_19(int_3);
		if (@enum == (Enum7)3)
		{
			return 1;
		}
		return 2;
	}

	private void method_18(Graphics graphics_0, DOMAIN2.DomainInfo domainInfo_0, int int_3)
	{
		if (domainInfo_0?.Points == null || domainInfo_0.Points.Count < 3)
		{
			return;
		}
		PointF[] array = domainInfo_0.Points.Select(method_33).ToArray();
		Enum7 enum7_ = method_19(int_3);
		Color color = smethod_5(enum7_, domainInfo_0.CountryId);
		Color color2 = ((int_3 == int_0) ? Color.Red : Color.Black);
		SolidBrush solidBrush = new SolidBrush(color);
		try
		{
			if (domainInfo_0.Triangles != null && domainInfo_0.Triangles.Count > 0)
			{
				foreach (DOMAIN2.DOMAIN_TRIANGLE triangle in domainInfo_0.Triangles)
				{
					if (triangle.id1 >= 0 && triangle.id2 >= 0 && triangle.id3 >= 0 && triangle.id1 < array.Length && triangle.id2 < array.Length && triangle.id3 < array.Length)
					{
						PointF[] points = new PointF[3]
						{
							array[triangle.id1],
							array[triangle.id2],
							array[triangle.id3]
						};
						graphics_0.FillPolygon(solidBrush, points);
					}
				}
			}
			else
			{
				graphics_0.FillPolygon(solidBrush, array);
			}
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
		using (Pen pen = new Pen(color2, (int_3 == int_0) ? 2.4f : 1f))
		{
			graphics_0.DrawPolygon(pen, array);
		}
		if (checkBox_4.Checked && domainInfo_0.Triangles != null)
		{
			Pen pen2 = new Pen(Color.FromArgb(220, 255, 70, 70), 1.2f);
			try
			{
				foreach (DOMAIN2.DOMAIN_TRIANGLE triangle2 in domainInfo_0.Triangles)
				{
					if (triangle2.id1 >= 0 && triangle2.id2 >= 0 && triangle2.id3 >= 0 && triangle2.id1 < array.Length && triangle2.id2 < array.Length && triangle2.id3 < array.Length)
					{
						graphics_0.DrawLine(pen2, array[triangle2.id1], array[triangle2.id2]);
						graphics_0.DrawLine(pen2, array[triangle2.id1], array[triangle2.id3]);
						graphics_0.DrawLine(pen2, array[triangle2.id2], array[triangle2.id3]);
					}
				}
			}
			finally
			{
				((IDisposable)pen2).Dispose();
			}
		}
		if (checkBox_1.Checked && domainInfo_0.IsCapital != 0)
		{
			PointF pointF = smethod_6(array);
			Pen pen3 = new Pen(Color.Gold, 2f);
			try
			{
				Brush brush = new SolidBrush(Color.Gold);
				try
				{
					graphics_0.DrawEllipse(pen3, pointF.X - 8f, pointF.Y - 8f, 16f, 16f);
					graphics_0.FillEllipse(brush, pointF.X - 3f, pointF.Y - 3f, 6f, 6f);
				}
				finally
				{
					((IDisposable)brush).Dispose();
				}
			}
			finally
			{
				((IDisposable)pen3).Dispose();
			}
		}
		if (int_3 == int_0 && float_0 > 0.35f)
		{
			Brush brush2 = new SolidBrush(Color.White);
			try
			{
				PointF[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					PointF pointF2 = array2[i];
					graphics_0.FillEllipse(brush2, pointF2.X - 2f, pointF2.Y - 2f, 4f, 4f);
				}
			}
			finally
			{
				((IDisposable)brush2).Dispose();
			}
		}
		if (!(float_0 >= 0.5f))
		{
			return;
		}
		List<string> list = new List<string>();
		if (checkBox_2.Checked)
		{
			list.Add(string.Format(Class16.smethod_0(1649004723), domainInfo_0.ID));
		}
		if (checkBox_3.Checked && !string.IsNullOrWhiteSpace(domainInfo_0.Name))
		{
			list.Add(domainInfo_0.Name);
		}
		string text = string.Join(Class16.smethod_0(1648942211), list);
		if (string.IsNullOrWhiteSpace(text))
		{
			return;
		}
		PointF pointF3 = smethod_6(array);
		Font font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		try
		{
			SizeF sizeF = graphics_0.MeasureString(text, font);
			RectangleF rect = new RectangleF(pointF3.X - sizeF.Width / 2f - 2f, pointF3.Y - sizeF.Height / 2f, sizeF.Width + 4f, sizeF.Height);
			Brush brush3 = new SolidBrush(Color.FromArgb(150, 255, 255, 255));
			try
			{
				Brush brush4 = new SolidBrush(Color.Black);
				try
				{
					graphics_0.FillRectangle(brush3, rect);
					graphics_0.DrawString(text, font, brush4, rect.X + 2f, rect.Y);
				}
				finally
				{
					((IDisposable)brush4).Dispose();
				}
			}
			finally
			{
				((IDisposable)brush3).Dispose();
			}
		}
		finally
		{
			((IDisposable)font).Dispose();
		}
	}

	private Enum7 method_19(int int_3)
	{
		if (method_22() && int_3 >= 0 && int_3 < domain2_0.Domains.Length)
		{
			if (int_3 == int_0)
			{
				return (Enum7)0;
			}
			DOMAIN2.DomainInfo domainInfo = method_23();
			DOMAIN2.DomainInfo domainInfo2 = domain2_0.Domains[int_3];
			if (checkBox_0.Checked && domainInfo?.Neighbors != null && domainInfo.Neighbors.Contains(domainInfo2.ID))
			{
				return (Enum7)1;
			}
			if (checkBox_1.Checked && domainInfo2.IsCapital != 0)
			{
				return (Enum7)2;
			}
			return (Enum7)3;
		}
		return (Enum7)3;
	}

	private static Color smethod_5(Enum7 enum7_0, int int_3)
	{
		Color color = int_3 switch
		{
			1 => Color.FromArgb(120, 255, 200, 200), 
			2 => Color.FromArgb(120, 200, 220, 255), 
			3 => Color.FromArgb(120, 255, 255, 170), 
			4 => Color.FromArgb(120, 200, 255, 200), 
			_ => Color.FromArgb(110, 224, 224, 224), 
		};
		return enum7_0 switch
		{
			(Enum7)0 => Color.FromArgb(190, 255, 90, 90), 
			(Enum7)1 => Color.FromArgb(150, 110, 220, 120), 
			(Enum7)2 => Color.FromArgb(170, 160, 160, 160), 
			_ => color, 
		};
	}

	private void method_20(Graphics graphics_0)
	{
		if (enum6_0 != (Enum6)1 || list_0.Count == 0)
		{
			return;
		}
		Pen pen = new Pen(Color.FromArgb(230, 255, 70, 70), 1.5f);
		try
		{
			using Pen pen2 = new Pen(Color.FromArgb(190, 200, 200, 200), 1f)
			{
				DashStyle = DashStyle.Dash
			};
			Brush brush = new SolidBrush(Color.FromArgb(55, 130, 200, 255));
			try
			{
				Brush brush2 = new SolidBrush(Color.White);
				try
				{
					Brush brush3 = new SolidBrush(Color.Red);
					try
					{
						Brush brush4 = new SolidBrush(Color.DeepSkyBlue);
						try
						{
							for (int i = 0; i < list_0.Count - 1; i++)
							{
								graphics_0.DrawLine(pen, list_0[i], list_0[i + 1]);
							}
							if (list_0.Count >= 3)
							{
								graphics_0.FillPolygon(brush, list_0.ToArray());
								graphics_0.DrawPolygon(pen, list_0.ToArray());
							}
							for (int j = 0; j < list_0.Count; j++)
							{
								Brush brush5 = brush2;
								if (j == 0)
								{
									brush5 = brush3;
								}
								else if (j == list_0.Count - 1)
								{
									brush5 = brush4;
								}
								PointF pointF = list_0[j];
								graphics_0.FillEllipse(brush5, pointF.X - 3.5f, pointF.Y - 3.5f, 7f, 7f);
							}
							if (list_0.Count > 0)
							{
								graphics_0.DrawLine(pen2, list_0[list_0.Count - 1], pointF_0);
							}
						}
						finally
						{
							((IDisposable)brush4).Dispose();
						}
					}
					finally
					{
						((IDisposable)brush3).Dispose();
					}
				}
				finally
				{
					((IDisposable)brush2).Dispose();
				}
			}
			finally
			{
				((IDisposable)brush).Dispose();
			}
		}
		finally
		{
			((IDisposable)pen).Dispose();
		}
	}

	private static PointF smethod_6(PointF[] pointF_3)
	{
		float num = 0f;
		float num2 = 0f;
		for (int i = 0; i < pointF_3.Length; i++)
		{
			PointF pointF = pointF_3[i];
			num += pointF.X;
			num2 += pointF.Y;
		}
		return new PointF(num / (float)pointF_3.Length, num2 / (float)pointF_3.Length);
	}

	private static float smethod_7(PointF pointF_3, PointF pointF_4)
	{
		float num = pointF_3.X - pointF_4.X;
		float num2 = pointF_3.Y - pointF_4.Y;
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	private static List<PointF> smethod_8(IEnumerable<PointF> ienumerable_0)
	{
		List<PointF> list = new List<PointF>();
		PointF? pointF = null;
		foreach (PointF item in ienumerable_0)
		{
			if (!pointF.HasValue || !(smethod_7(pointF.Value, item) < 0.5f))
			{
				list.Add(item);
				pointF = item;
			}
		}
		if (list.Count > 1 && smethod_7(list[0], list[list.Count - 1]) < 0.5f)
		{
			list.RemoveAt(list.Count - 1);
		}
		return list;
	}

	private static List<int> smethod_9(IList<PointF> ilist_0)
	{
		int count = ilist_0.Count;
		if (count < 3)
		{
			return null;
		}
		List<int> list = new List<int>();
		int[] array = new int[count];
		if (smethod_10(ilist_0) > 0.0)
		{
			for (int i = 0; i < count; i++)
			{
				array[i] = i;
			}
		}
		else
		{
			for (int j = 0; j < count; j++)
			{
				array[j] = count - 1 - j;
			}
		}
		int num = count;
		int num2 = 2 * num;
		int num3 = num - 1;
		while (true)
		{
			if (num > 2)
			{
				if (num2-- <= 0)
				{
					break;
				}
				int num4 = num3;
				if (num4 >= num)
				{
					num4 = 0;
				}
				num3 = num4 + 1;
				if (num3 >= num)
				{
					num3 = 0;
				}
				int num5 = num3 + 1;
				if (num5 >= num)
				{
					num5 = 0;
				}
				if (smethod_11(ilist_0, num4, num3, num5, num, array, 1E-10))
				{
					list.Add(array[num4]);
					list.Add(array[num3]);
					list.Add(array[num5]);
					for (int k = num3; k < num - 1; k++)
					{
						array[k] = array[k + 1];
					}
					num--;
					num2 = 2 * num;
				}
				continue;
			}
			return list;
		}
		return null;
	}

	private static double smethod_10(IList<PointF> ilist_0)
	{
		int count = ilist_0.Count;
		double num = 0.0;
		int index = count - 1;
		for (int i = 0; i < count; i++)
		{
			num += (double)(ilist_0[index].X * ilist_0[i].Y - ilist_0[i].X * ilist_0[index].Y);
			index = i;
		}
		return num * 0.5;
	}

	private static bool smethod_11(IList<PointF> ilist_0, int int_3, int int_4, int int_5, int int_6, int[] int_7, double double_0)
	{
		double num = ilist_0[int_7[int_3]].X;
		double num2 = ilist_0[int_7[int_3]].Y;
		double num3 = ilist_0[int_7[int_4]].X;
		double num4 = ilist_0[int_7[int_4]].Y;
		double num5 = ilist_0[int_7[int_5]].X;
		double num6 = ilist_0[int_7[int_5]].Y;
		if ((num3 - num) * (num6 - num2) - (num4 - num2) * (num5 - num) <= double_0)
		{
			return false;
		}
		int num7 = 0;
		while (true)
		{
			if (num7 < int_6)
			{
				if (num7 != int_3 && num7 != int_4 && num7 != int_5)
				{
					double double_1 = ilist_0[int_7[num7]].X;
					double double_2 = ilist_0[int_7[num7]].Y;
					if (smethod_12(num, num2, num3, num4, num5, num6, double_1, double_2, double_0))
					{
						break;
					}
				}
				num7++;
				continue;
			}
			return true;
		}
		return false;
	}

	private static bool smethod_12(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7, double double_8)
	{
		double num = double_4 - double_2;
		double num2 = double_5 - double_3;
		double num3 = double_0 - double_4;
		double num4 = double_1 - double_5;
		double num5 = double_2 - double_0;
		double num6 = double_3 - double_1;
		double num7 = double_6 - double_0;
		double num8 = double_7 - double_1;
		double num9 = double_6 - double_2;
		double num10 = double_7 - double_3;
		double num11 = double_6 - double_4;
		double num12 = double_7 - double_5;
		double num13 = num * num10 - num2 * num9;
		double num14 = num5 * num8 - num6 * num7;
		double num15 = num3 * num12 - num4 * num11;
		if (num13 >= 0.0 - double_8 && num14 >= 0.0 - double_8)
		{
			return num15 >= 0.0 - double_8;
		}
		return false;
	}

	private void propertyGrid_0_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
	{
		if (!bool_7)
		{
			method_38();
		}
		method_1();
		method_27();
		method_28();
		pictureBox_0.Invalidate();
	}

	private void method_21(string string_2)
	{
		label_0.Text = string_2;
	}

	private bool method_22()
	{
		if (domain2_0.Domains != null && int_0 >= 0)
		{
			return int_0 < domain2_0.Domains.Length;
		}
		return false;
	}

	private DOMAIN2.DomainInfo method_23()
	{
		if (!method_22())
		{
			return null;
		}
		return domain2_0.Domains[int_0];
	}

	private bool method_24()
	{
		return stack_0.Count > 0;
	}

	private bool method_25()
	{
		return stack_1.Count > 0;
	}

	private void method_26()
	{
		bool flag = method_22();
		bool flag2 = enum6_0 != (Enum6)0;
		bool flag4;
		bool flag3 = (flag4 = enum6_0 == (Enum6)1) && list_0.Count > 0;
		button_0.Enabled = flag && !flag2;
		button_1.Enabled = flag && !flag2;
		button_2.Enabled = flag && !flag2;
		button_3.Enabled = flag && !flag2;
		button_4.Enabled = flag && !flag2;
		button_6.Visible = flag4;
		button_6.Enabled = flag4;
		button_7.Enabled = flag3 || method_24();
		button_7.Text = (flag3 ? Class16.smethod_0(1649004743) : Class16.smethod_0(1648903487));
		button_8.Enabled = method_25();
		button_5.Enabled = flag2;
	}

	private void method_27()
	{
		float num = float.MaxValue;
		float num2 = float.MaxValue;
		float num3 = float.MinValue;
		float num4 = float.MinValue;
		bool flag = false;
		if (domain2_0.Domains != null)
		{
			DOMAIN2.DomainInfo[] domains = domain2_0.Domains;
			foreach (DOMAIN2.DomainInfo domainInfo in domains)
			{
				if (domainInfo?.Points == null || domainInfo.Points.Count == 0)
				{
					continue;
				}
				foreach (DOMAIN2.DOMAIN_POINT point in domainInfo.Points)
				{
					flag = true;
					num = Math.Min(num, point.Int32_1);
					num2 = Math.Min(num2, point.Int32_0);
					num3 = Math.Max(num3, point.Int32_1);
					num4 = Math.Max(num4, point.Int32_0);
				}
			}
		}
		float val = (flag ? (num - 24f) : 0f);
		float val2 = (flag ? (num2 - 24f) : 0f);
		float num5 = (flag ? (num3 + 24f) : 1024f);
		float num6 = (flag ? (num4 + 24f) : 768f);
		val = Math.Min(val, 0f);
		val2 = Math.Min(val2, 0f);
		if (image_0 != null)
		{
			num5 = Math.Max(num5, image_0.Width);
			num6 = Math.Max(num6, image_0.Height);
		}
		if (num5 - val < 400f)
		{
			num5 = val + 400f;
		}
		if (num6 - val2 < 300f)
		{
			num6 = val2 + 300f;
		}
		pointF_2 = new PointF(val, val2);
		sizeF_0 = new SizeF(num5 - val, num6 - val2);
	}

	private void method_28()
	{
		int num = Math.Max(1, (int)Math.Ceiling(sizeF_0.Width * float_0));
		int num2 = Math.Max(1, (int)Math.Ceiling(sizeF_0.Height * float_0));
		if (pictureBox_0.Width != num || pictureBox_0.Height != num2)
		{
			pictureBox_0.Size = new Size(num, num2);
		}
		panel_0.AutoScrollMinSize = pictureBox_0.Size;
		method_29();
		pictureBox_0.Invalidate();
	}

	private void method_29()
	{
		if (panel_0.ClientSize.Width > 0 && panel_0.ClientSize.Height > 0)
		{
			int num = ((pictureBox_0.Width < panel_0.ClientSize.Width) ? ((panel_0.ClientSize.Width - pictureBox_0.Width) / 2) : 0);
			int num2 = ((pictureBox_0.Height < panel_0.ClientSize.Height) ? ((panel_0.ClientSize.Height - pictureBox_0.Height) / 2) : 0);
			if (pictureBox_0.Location.X != num || pictureBox_0.Location.Y != num2)
			{
				pictureBox_0.Location = new Point(num, num2);
			}
		}
	}

	private void panel_0_Resize(object sender, EventArgs e)
	{
		method_29();
	}

	private PointF method_30(Point point_2)
	{
		return new PointF((float)point_2.X / float_0, (float)point_2.Y / float_0);
	}

	private PointF method_31(PointF pointF_3)
	{
		return new PointF(pointF_3.X + pointF_2.X, pointF_3.Y + pointF_2.Y);
	}

	private PointF method_32(float float_1, float float_2)
	{
		return new PointF(float_1 - pointF_2.X, float_2 - pointF_2.Y);
	}

	private PointF method_33(DOMAIN2.DOMAIN_POINT domain_POINT_0)
	{
		return method_32(domain_POINT_0.Int32_1, domain_POINT_0.Int32_0);
	}

	private void method_34(float float_1, Point point_2)
	{
		float_1 = Math.Max(0.2f, Math.Min(8f, float_1));
		if (!(Math.Abs(float_1 - float_0) < 0.0001f))
		{
			float num = float_0;
			PointF pointF = new PointF((float)point_2.X / num, (float)point_2.Y / num);
			float_0 = float_1;
			method_28();
			int val = (int)Math.Round(pointF.X * float_0 - (float)point_2.X);
			int val2 = (int)Math.Round(pointF.Y * float_0 - (float)point_2.Y);
			val = Math.Max(0, val);
			val2 = Math.Max(0, val2);
			panel_0.AutoScrollPosition = new Point(val, val2);
			method_21(string.Format(Class16.smethod_0(1649004753), float_0 * 100f));
		}
	}

	private void panel_0_MouseEnter(object sender, EventArgs e)
	{
		pictureBox_0.Focus();
	}

	private void method_35()
	{
		float_0 = 1f;
		method_27();
		method_28();
		panel_0.AutoScrollPosition = new Point(0, 0);
		method_21(Class16.smethod_0(1649004780));
	}

	private static DOMAIN2.DomainInfo[] smethod_13(DOMAIN2.DomainInfo[] domainInfo_0)
	{
		if (domainInfo_0 == null)
		{
			return Array.Empty<DOMAIN2.DomainInfo>();
		}
		DOMAIN2.DomainInfo[] array = new DOMAIN2.DomainInfo[domainInfo_0.Length];
		for (int i = 0; i < domainInfo_0.Length; i++)
		{
			array[i] = domainInfo_0[i]?.Clone();
		}
		return array;
	}

	private static Class103 smethod_14(Class103 class103_0)
	{
		if (class103_0 == null)
		{
			return null;
		}
		Class103 @class = new Class103();
		@class.method_1(smethod_13(class103_0.method_0()));
		@class.method_3(class103_0.method_2());
		return @class;
	}

	private Class103 method_36()
	{
		Class103 @class = new Class103();
		@class.method_1(smethod_13(domain2_0.Domains));
		@class.method_3(int_0);
		return @class;
	}

	private void method_37()
	{
		if (!bool_7)
		{
			stack_0.Push(method_36());
			stack_1.Clear();
			method_26();
		}
	}

	private void method_38()
	{
		method_0(bool_9: true);
	}

	private void method_39()
	{
		if (method_24())
		{
			stack_1.Push(method_36());
			Class103 class103_ = stack_0.Pop();
			method_41(class103_);
			method_21(Class16.smethod_0(1649004798));
		}
	}

	private void method_40()
	{
		if (method_25())
		{
			stack_0.Push(method_36());
			Class103 class103_ = stack_1.Pop();
			method_41(class103_);
			method_21(Class16.smethod_0(1649004810));
		}
	}

	private void method_41(Class103 class103_0)
	{
		if (class103_0 == null)
		{
			return;
		}
		bool_7 = true;
		try
		{
			domain2_0.Domains = smethod_13(class103_0.method_0());
			int_0 = class103_0.method_2();
			method_1();
			method_27();
			method_28();
			pictureBox_0.Invalidate();
		}
		finally
		{
			bool_7 = false;
			method_26();
		}
	}

	private void method_42()
	{
		if (method_45(Class16.smethod_0(1649004838), bool_9: false))
		{
			method_43(0);
			int_2 = 0;
		}
		else if (method_45(Class16.smethod_0(1649004842), bool_9: false))
		{
			method_43(1);
			int_2 = 1;
		}
		else
		{
			method_43(0);
			method_21(Class16.smethod_0(1649004863));
		}
	}

	private void method_43(int int_3)
	{
		bool_6 = true;
		comboBox_0.SelectedIndex = int_3;
		bool_6 = false;
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (bool_6)
		{
			return;
		}
		switch (comboBox_0.SelectedIndex)
		{
		case 0:
			if (method_45(Class16.smethod_0(1649004838), bool_9: true))
			{
				int_2 = 0;
			}
			else
			{
				method_43(int_2);
			}
			break;
		case 1:
			if (method_45(Class16.smethod_0(1649004842), bool_9: true))
			{
				int_2 = 1;
			}
			else
			{
				method_43(int_2);
			}
			break;
		case 2:
			if (method_44())
			{
				int_2 = 2;
			}
			else
			{
				method_43(int_2);
			}
			break;
		}
	}

	private bool method_44()
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Filter = Class16.smethod_0(1649004914),
			Title = Class16.smethod_0(1649004977)
		};
		if (openFileDialog.ShowDialog(this) != DialogResult.OK)
		{
			return false;
		}
		if (!method_46(openFileDialog.FileName, bool_9: true))
		{
			return false;
		}
		string_1 = openFileDialog.FileName;
		method_21(Class16.smethod_0(1649005001) + System.IO.Path.GetFileName(string_1));
		return true;
	}

	private bool method_45(string string_2, bool bool_9)
	{
		string text = smethod_15(string_2);
		if (string.IsNullOrWhiteSpace(text))
		{
			if (bool_9)
			{
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649005027), Class16.smethod_0(1649008140)), string_2), Class16.smethod_0(1649008172), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			return false;
		}
		if (!method_46(text, bool_9))
		{
			return false;
		}
		method_21(Class16.smethod_0(1649008182) + System.IO.Path.GetFileName(text));
		return true;
	}

	private bool method_46(string string_2, bool bool_9)
	{
		if (!File.Exists(string_2))
		{
			return false;
		}
		try
		{
			FileStream fileStream = new FileStream(string_2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			try
			{
				using Image original = Image.FromStream(fileStream);
				Image image = new Bitmap(original);
				if (image_0 != null)
				{
					image_0.Dispose();
				}
				image_0 = image;
				string_0 = string_2;
				method_27();
				method_28();
				pictureBox_0.Invalidate();
				return true;
			}
			finally
			{
				((IDisposable)fileStream).Dispose();
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649008193));
			if (bool_9)
			{
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649008237), Class16.smethod_0(1649008270)), ex.Message), Class16.smethod_0(1649008172), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return false;
		}
	}

	private static string smethod_15(string string_2)
	{
		string[] array = new string[4]
		{
			Class16.smethod_0(1649008300),
			Class16.smethod_0(1649008311),
			Class16.smethod_0(1649008314),
			Class16.smethod_0(1648904847)
		};
		string[] array2 = new string[2]
		{
			AppContext.BaseDirectory,
			Directory.GetCurrentDirectory()
		};
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		string[] array3 = array2;
		foreach (string text in array3)
		{
			string text2 = text;
			for (int j = 0; j < 8; j++)
			{
				if (string.IsNullOrWhiteSpace(text2))
				{
					break;
				}
				string[] array4 = array;
				foreach (string text3 in array4)
				{
					string[] array5 = new string[4]
					{
						System.IO.Path.Combine(Class16.smethod_0(1649008333), Class16.smethod_0(1649008339), string_2 + text3),
						System.IO.Path.Combine(Class16.smethod_0(1649008339), string_2 + text3),
						System.IO.Path.Combine(Class16.smethod_0(1649008358), Class16.smethod_0(1649008339), string_2 + text3),
						System.IO.Path.Combine(Class16.smethod_0(1649008374), Class16.smethod_0(1649008339), string_2 + text3)
					};
					string[] array6 = array5;
					foreach (string path in array6)
					{
						string fullPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(text2, path));
						if (hashSet.Add(fullPath) && File.Exists(fullPath))
						{
							return fullPath;
						}
					}
				}
				text2 = Directory.GetParent(text2)?.FullName;
			}
		}
		return null;
	}

	private void checkBox_4_CheckedChanged(object sender, EventArgs e)
	{
		pictureBox_0.Invalidate();
	}

	private void Domain2MapEditor_Activated(object sender, EventArgs e)
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_Domain2MapEditor != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this);
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_Domain2MapEditor = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}

	private int method_47(int int_3, int int_4)
	{
		return method_17(int_3).CompareTo(method_17(int_4));
	}
}
