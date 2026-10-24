using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.GShop;

public class CategorySelector_PW : Form
{
	public CommonStorage CStorage;

	public GSHOP GShop;

	public int FocusedCatDeep;

	public int Cat1;

	public int Cat2;

	private static bool bool_0;

	private TextBox textBox_0;

	private ToolTip toolTip_0;

	private GroupBox groupBox_0;

	private ContextMenuStrip contextMenuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripMenuItem toolStripMenuItem_2;

	private Button button_0;

	private ListBox listBox_0;

	private ListBox listBox_1;

	private IContainer icontainer_0;

	public CategorySelector_PW(CommonStorage CStorage, GSHOP GShop, int Cat1, int Cat2)
	{
		try
		{
			method_1();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			TextStorage.TEXTS.SetFormLanguage(this, null);
			this.CStorage = CStorage;
			this.Cat1 = Cat1;
			this.Cat2 = Cat2;
			this.GShop = GShop;
			string[] array = new string[8];
			if (GShop != null)
			{
				int num = 0;
				do
				{
					array[num] = GShop.Categories[num].name;
					num++;
				}
				while (num < 8);
				ListBox.ObjectCollection items = listBox_0.Items;
				object[] items2 = array;
				items.AddRange(items2);
				if (Cat1 < 0)
				{
					Cat1 = 0;
				}
				else if (Cat1 <= -1)
				{
					goto IL_00b9;
				}
				listBox_0.SelectedIndex = Cat1;
				if (Cat2 > -1 && Cat2 < listBox_1.Items.Count)
				{
					listBox_1.SelectedIndex = Cat2;
				}
			}
			goto IL_00b9;
			IL_00b9:
			_ = Cursor;
			Point position = Cursor.Position;
			int num2 = base.Width / 2;
			base.Left = position.X - num2;
			_ = Cursor;
			Point position2 = Cursor.Position;
			int num3 = base.Height / 2;
			base.Top = position2.Y - num3;
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void listBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			int num = (Cat1 = listBox_0.SelectedIndex);
			string[] subCats = GShop.Categories[num].SubCats;
			listBox_1.Items.Clear();
			if ((nint)subCats.LongLength > 0)
			{
				ListBox.ObjectCollection items = listBox_1.Items;
				object[] items2 = subCats;
				items.AddRange(items2);
				listBox_1.SelectedIndex = 0;
			}
			else
			{
				Cat2 = -1;
			}
		}
	}

	private void listBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			Cat2 = listBox_1.SelectedIndex;
			GC.KeepAlive(this);
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		int cat = Cat1;
		if (cat > -1)
		{
			int cat2 = Cat2;
			if (cat2 > -1)
			{
				CommonStorage.iarr1 = ACE.RSGlobal.RSGlobal.iarr(cat, cat2);
				base.DialogResult = DialogResult.OK;
				Close();
				goto IL_0041;
			}
		}
		TextStorage.TEXTS.ShowErrorMessage(245);
		goto IL_0041;
		IL_0041:
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		GShop.DeleteSubCat((uint)Cat1, (uint)Cat2);
		listBox_0_SelectedIndexChanged(null, null);
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649071255));
		Category category = GShop.Categories[Cat1];
		if ((nint)category.SubCats.LongLength < 8)
		{
			ACE.RSGlobal.RSGlobal.AddElementToArray(ref category.SubCats, text);
			listBox_1.Items.Add(text);
			Category category2 = GShop.Categories[Cat1];
			category2.SubCatsCount = (uint)category2.SubCats.Length;
			listBox_1.SelectedIndex = (int)(GShop.Categories[Cat1].SubCatsCount - 1);
		}
		else
		{
			TextStorage.TEXTS.ShowMessage(232, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
		}
		GC.KeepAlive(this);
	}

	private void toolStripMenuItem_0_Click(object sender, EventArgs e)
	{
		method_2();
	}

	private void contextMenuStrip_0_Opening(object sender, CancelEventArgs e)
	{
		byte b = (((FocusedCatDeep = (listBox_0.Focused ? 1 : 2)) == 2) ? ((byte)1) : ((byte)0));
		toolStripSeparator_0.Visible = b != 0;
		byte b2 = ((FocusedCatDeep == 2) ? ((byte)1) : ((byte)0));
		toolStripMenuItem_2.Visible = b2 != 0;
		byte b3 = ((FocusedCatDeep == 2) ? ((byte)1) : ((byte)0));
		toolStripMenuItem_1.Visible = b3 != 0;
		GC.KeepAlive(this);
	}

	private void listBox_1_MouseUp(object sender, MouseEventArgs e)
	{
		FocusedCatDeep = 2;
	}

	private void listBox_0_MouseUp(object sender, MouseEventArgs e)
	{
		FocusedCatDeep = 1;
	}

	private void textBox_0_Leave(object sender, EventArgs e)
	{
		textBox_0.Visible = false;
		bool_0 = true;
		if (FocusedCatDeep == 1)
		{
			string name = textBox_0.Text;
			GShop.Categories[Cat1].name = name;
			TextBox textBox = textBox_0;
			int cat = Cat1;
			listBox_0.Items[cat] = textBox.Text;
		}
		else
		{
			int cat2 = Cat2;
			GShop.Categories[Cat1].SubCats[cat2] = textBox_0.Text;
			TextBox textBox2 = textBox_0;
			int cat3 = Cat2;
			listBox_1.Items[cat3] = textBox2.Text;
		}
		bool_0 = false;
		GC.KeepAlive(this);
	}

	private void listBox_0_DoubleClick(object sender, EventArgs e)
	{
		method_2();
	}

	private void listBox_1_DoubleClick(object sender, EventArgs e)
	{
		button_0_Click(null, null);
	}

	private void method_0()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_1()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(CategorySelector_PW));
		button_0 = new Button();
		listBox_0 = new ListBox();
		contextMenuStrip_0 = new ContextMenuStrip(icontainer_0);
		toolStripMenuItem_0 = new ToolStripMenuItem();
		toolStripMenuItem_1 = new ToolStripMenuItem();
		toolStripSeparator_0 = new ToolStripSeparator();
		toolStripMenuItem_2 = new ToolStripMenuItem();
		listBox_1 = new ListBox();
		toolTip_0 = new ToolTip(icontainer_0);
		groupBox_0 = new GroupBox();
		textBox_0 = new TextBox();
		contextMenuStrip_0.SuspendLayout();
		groupBox_0.SuspendLayout();
		SuspendLayout();
		button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		button_0.Image = Resources.CategorySelector_PW_cmdOk;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		Point location = new Point(3, 200);
		button_0.Location = location;
		button_0.Name = Class16.smethod_0(1648973834);
		Size size = new Size(334, 23);
		button_0.Size = size;
		button_0.TabIndex = 109;
		button_0.Text = Class16.smethod_0(1648938905);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		listBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		listBox_0.ContextMenuStrip = contextMenuStrip_0;
		listBox_0.Font = new Font(Class16.smethod_0(1648942905), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		listBox_0.FormattingEnabled = true;
		listBox_0.ItemHeight = 20;
		Point location2 = new Point(5, 13);
		listBox_0.Location = location2;
		listBox_0.Name = Class16.smethod_0(1649072050);
		Size size2 = new Size(159, 184);
		listBox_0.Size = size2;
		listBox_0.TabIndex = 110;
		listBox_0.SelectedIndexChanged += listBox_0_SelectedIndexChanged;
		listBox_0.DoubleClick += listBox_0_DoubleClick;
		listBox_0.MouseDown += listBox_0_MouseDown;
		listBox_0.MouseUp += listBox_0_MouseUp;
		contextMenuStrip_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		ToolStripItem[] toolStripItems = new ToolStripItem[4] { toolStripMenuItem_0, toolStripMenuItem_1, toolStripSeparator_0, toolStripMenuItem_2 };
		contextMenuStrip_0.Items.AddRange(toolStripItems);
		contextMenuStrip_0.Name = Class16.smethod_0(1649003266);
		Size size3 = new Size(167, 76);
		contextMenuStrip_0.Size = size3;
		contextMenuStrip_0.Opening += contextMenuStrip_0_Opening;
		toolStripMenuItem_0.Image = Resources.mnuChangeName;
		toolStripMenuItem_0.Name = Class16.smethod_0(1649072064);
		Size size4 = new Size(166, 22);
		toolStripMenuItem_0.Size = size4;
		toolStripMenuItem_0.Text = Class16.smethod_0(1649071278);
		toolStripMenuItem_0.Click += toolStripMenuItem_0_Click;
		Color red = Color.Red;
		toolStripMenuItem_1.ForeColor = red;
		toolStripMenuItem_1.Image = Resources.mnuDelete;
		toolStripMenuItem_1.Name = Class16.smethod_0(1649003348);
		Size size5 = new Size(166, 22);
		toolStripMenuItem_1.Size = size5;
		toolStripMenuItem_1.Text = Class16.smethod_0(1648925718);
		toolStripMenuItem_1.Click += toolStripMenuItem_1_Click;
		toolStripSeparator_0.Name = Class16.smethod_0(1649072092);
		Size size6 = new Size(163, 6);
		toolStripSeparator_0.Size = size6;
		toolStripMenuItem_2.Font = new Font(Class16.smethod_0(1648942905), 9f);
		toolStripMenuItem_2.Image = Resources.mnuAdd;
		toolStripMenuItem_2.Name = Class16.smethod_0(1649003303);
		Size size7 = new Size(166, 22);
		toolStripMenuItem_2.Size = size7;
		toolStripMenuItem_2.Text = Class16.smethod_0(1648931361);
		toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
		listBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		listBox_1.ContextMenuStrip = contextMenuStrip_0;
		listBox_1.Font = new Font(Class16.smethod_0(1648942905), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		listBox_1.FormattingEnabled = true;
		listBox_1.ItemHeight = 20;
		Point location3 = new Point(170, 13);
		listBox_1.Location = location3;
		listBox_1.Name = Class16.smethod_0(1649072096);
		Size size8 = new Size(159, 184);
		listBox_1.Size = size8;
		listBox_1.TabIndex = 111;
		listBox_1.SelectedIndexChanged += listBox_1_SelectedIndexChanged;
		listBox_1.DoubleClick += listBox_1_DoubleClick;
		listBox_1.MouseDown += listBox_1_MouseDown;
		listBox_1.MouseUp += listBox_1_MouseUp;
		TextBox value = textBox_0;
		groupBox_0.Controls.Add(value);
		ListBox value2 = listBox_0;
		groupBox_0.Controls.Add(value2);
		ListBox value3 = listBox_1;
		groupBox_0.Controls.Add(value3);
		Point location4 = new Point(3, -4);
		groupBox_0.Location = location4;
		groupBox_0.Name = Class16.smethod_0(1648929126);
		Size size9 = new Size(335, 202);
		groupBox_0.Size = size9;
		groupBox_0.TabIndex = 114;
		groupBox_0.TabStop = false;
		Point location5 = new Point(155, 122);
		textBox_0.Location = location5;
		textBox_0.MaxLength = 10;
		textBox_0.Name = Class16.smethod_0(1649071144);
		Size size10 = new Size(124, 22);
		textBox_0.Size = size10;
		textBox_0.TabIndex = 0;
		textBox_0.TextAlign = HorizontalAlignment.Center;
		textBox_0.Visible = false;
		textBox_0.KeyUp += textBox_0_KeyUp;
		textBox_0.Leave += textBox_0_Leave;
		SizeF sizeF = new SizeF(7f, 16f);
		base.AutoScaleDimensions = sizeF;
		base.AutoScaleMode = AutoScaleMode.Font;
		Color backColor = Color.FromArgb(239, 244, 250);
		BackColor = backColor;
		Size clientSize = new Size(341, 227);
		base.ClientSize = clientSize;
		Button value4 = button_0;
		base.Controls.Add(value4);
		GroupBox value5 = groupBox_0;
		base.Controls.Add(value5);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.CategorySelector_PW_Icon;
		Padding margin = new Padding(3, 4, 3, 4);
		base.Margin = margin;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1649071288);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.Manual;
		Text = Class16.smethod_0(1649071187);
		contextMenuStrip_0.ResumeLayout(performLayout: false);
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[HandleProcessCorruptedStateExceptions]
	protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			try
			{
				method_0();
				return;
			}
			finally
			{
				base.Dispose(true);
			}
		}
		base.Dispose(false);
	}

	private void method_2()
	{
		_ = Cursor;
		Point position = Cursor.Position;
		int left = -20 - base.Left + position.X;
		textBox_0.Left = left;
		_ = Cursor;
		Point position2 = Cursor.Position;
		int top = -5 - base.Top - SystemInformation.CaptionHeight + position2.Y;
		textBox_0.Top = top;
		if (FocusedCatDeep == 1)
		{
			textBox_0.Text = GShop.Categories[Cat1].name;
		}
		else
		{
			textBox_0.Text = GShop.Categories[Cat1].SubCats[Cat2];
		}
		textBox_0.Visible = true;
		textBox_0.Focus();
		textBox_0.SelectAll();
		GC.KeepAlive(this);
	}

	private void textBox_0_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			textBox_0_Leave(null, null);
		}
	}

	private void listBox_0_MouseDown(object sender, MouseEventArgs e)
	{
		listBox_0.Focus();
		GC.KeepAlive(this);
	}

	private void listBox_1_MouseDown(object sender, MouseEventArgs e)
	{
		listBox_1.Focus();
		GC.KeepAlive(this);
	}
}
