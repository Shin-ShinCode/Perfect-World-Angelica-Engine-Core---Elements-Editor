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

public class CategorySelector_FW : Form
{
	public int FocusedCatDeep;

	public int[] IDs;

	public ShopDirLua Categories;

	public ITEM_CATEGORY_POS CatPos;

	public ITEM_CATEGORY_POS NewCatPos;

	public SHOP_CATEGORY_FW Cat1;

	public SHOP_CATEGORY_FW Cat2;

	public SHOP_CATEGORY_FW Cat3;

	public SHOP_CATEGORY_FW SelectedCat;

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

	private ListBox listBox_2;

	private ListBox listBox_3;

	private IContainer icontainer_0;

	public CategorySelector_FW(CommonStorage CStorage, ShopDirLua Categories, ITEM_CATEGORY_POS CatPos, int[] IDs)
	{
		try
		{
			method_2();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			TextStorage.TEXTS.SetFormLanguage(this, null);
			this.Categories = Categories;
			this.CatPos = CatPos;
			this.IDs = IDs;
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void listBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		string[] subCategories = (Cat1 = Categories.Root.SubCategories[listBox_0.SelectedIndex]).GetSubCategories();
		listBox_1.Items.Clear();
		if ((nint)subCategories.LongLength > 0)
		{
			ListBox.ObjectCollection items = listBox_1.Items;
			object[] items2 = subCategories;
			items.AddRange(items2);
			listBox_1.SelectedIndex = 0;
			if (!listBox_1.Visible)
			{
				listBox_1.Visible = true;
				int num = listBox_1.Width;
				base.Width += num;
			}
		}
		else
		{
			Cat2 = null;
			Cat3 = null;
			listBox_1.Items.Clear();
			listBox_2.Items.Clear();
			method_0(Cat1);
		}
	}

	private void method_0(SHOP_CATEGORY_FW shop_CATEGORY_FW_0)
	{
		listBox_3.Items.Clear();
		int num = 0;
		if (0 < shop_CATEGORY_FW_0.Items.Count)
		{
			do
			{
				int num2 = num + 1;
				int num3 = num2;
				listBox_3.Items.Add(num3.ToString());
				num = num2;
			}
			while (num < shop_CATEGORY_FW_0.Items.Count);
		}
		ITEM_CATEGORY_POS catPos = CatPos;
		if (catPos != null && shop_CATEGORY_FW_0 == catPos.Category)
		{
			listBox_3.SelectedIndex = catPos.item_pos;
		}
		else
		{
			int num4 = shop_CATEGORY_FW_0.Items.Count + 1;
			listBox_3.Items.Add(num4.ToString());
			int selectedIndex = listBox_3.Items.Count - 1;
			listBox_3.SelectedIndex = selectedIndex;
		}
		SelectedCat = shop_CATEGORY_FW_0;
	}

	private void listBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		string[] subCategories = (Cat2 = Cat1.SubCategories[listBox_1.SelectedIndex]).GetSubCategories();
		listBox_2.Items.Clear();
		if ((nint)subCategories.LongLength > 0)
		{
			ListBox.ObjectCollection items = listBox_2.Items;
			object[] items2 = subCategories;
			items.AddRange(items2);
			listBox_2.SelectedIndex = 0;
			if (!listBox_2.Visible)
			{
				listBox_2.Visible = true;
				int num = listBox_2.Width;
				base.Width += num;
			}
		}
		else
		{
			Cat3 = null;
			listBox_2.Items.Clear();
			method_0(Cat2);
		}
	}

	private void listBox_2_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			method_0(Cat3 = Cat2.SubCategories[listBox_2.SelectedIndex]);
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (Cat3 != null)
		{
			ListBox listBox = listBox_3;
			ListBox listBox2 = listBox_2;
			ListBox listBox3 = listBox_1;
			ListBox listBox4 = listBox_0;
			SHOP_CATEGORY_FW selectedCat = SelectedCat;
			NewCatPos = new ITEM_CATEGORY_POS(selectedCat, listBox4.SelectedIndex, listBox3.SelectedIndex, listBox2.SelectedIndex, listBox.SelectedIndex);
		}
		else if (Cat2 != null)
		{
			ListBox listBox5 = listBox_3;
			ListBox listBox6 = listBox_1;
			ListBox listBox7 = listBox_0;
			SHOP_CATEGORY_FW selectedCat2 = SelectedCat;
			NewCatPos = new ITEM_CATEGORY_POS(selectedCat2, listBox7.SelectedIndex, listBox6.SelectedIndex, -1, listBox5.SelectedIndex);
		}
		else
		{
			ListBox listBox8 = listBox_3;
			ListBox listBox9 = listBox_0;
			SHOP_CATEGORY_FW selectedCat3 = SelectedCat;
			NewCatPos = new ITEM_CATEGORY_POS(selectedCat3, listBox9.SelectedIndex, -1, -1, listBox8.SelectedIndex);
		}
		ITEM_CATEGORY_POS catPos = CatPos;
		if (catPos != null)
		{
			ITEM_CATEGORY_POS newCatPos = NewCatPos;
			SHOP_CATEGORY_FW category = catPos.Category;
			if (category == newCatPos.Category)
			{
				category.ChangeItemPos(catPos.item_pos, newCatPos.item_pos);
				goto IL_0177;
			}
		}
		if (catPos != null)
		{
			SHOP_CATEGORY_FW category2 = catPos.Category;
			if (category2 != null && category2.Items != null)
			{
				category2.DeleteItem(catPos.item_pos);
			}
		}
		int[] iDs = IDs;
		int num = 0;
		if (0 < (nint)iDs.LongLength)
		{
			do
			{
				ITEM_CATEGORY_POS newCatPos2 = NewCatPos;
				newCatPos2.Category.AddItem(iDs[num], newCatPos2.item_pos);
				num++;
			}
			while (num < (nint)iDs.LongLength);
		}
		goto IL_0177;
		IL_0177:
		Categories.FileChanged = true;
	}

	private void method_1()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_2()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(CategorySelector_FW));
		button_0 = new Button();
		listBox_0 = new ListBox();
		contextMenuStrip_0 = new ContextMenuStrip(icontainer_0);
		toolStripMenuItem_0 = new ToolStripMenuItem();
		toolStripMenuItem_1 = new ToolStripMenuItem();
		toolStripSeparator_0 = new ToolStripSeparator();
		toolStripMenuItem_2 = new ToolStripMenuItem();
		listBox_1 = new ListBox();
		listBox_2 = new ListBox();
		listBox_3 = new ListBox();
		toolTip_0 = new ToolTip(icontainer_0);
		groupBox_0 = new GroupBox();
		textBox_0 = new TextBox();
		contextMenuStrip_0.SuspendLayout();
		groupBox_0.SuspendLayout();
		SuspendLayout();
		button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		button_0.DialogResult = DialogResult.OK;
		button_0.Image = Resources.CategorySelector_FW_cmdOk;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		Point location = new Point(3, 178);
		button_0.Location = location;
		button_0.Name = Class16.smethod_0(1648973834);
		Size size = new Size(554, 23);
		button_0.Size = size;
		button_0.TabIndex = 109;
		button_0.Text = Class16.smethod_0(1648938905);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		listBox_0.ContextMenuStrip = contextMenuStrip_0;
		listBox_0.FormattingEnabled = true;
		Point location2 = new Point(5, 13);
		listBox_0.Location = location2;
		listBox_0.Name = Class16.smethod_0(1649072050);
		Size size2 = new Size(159, 160);
		listBox_0.Size = size2;
		listBox_0.TabIndex = 110;
		listBox_0.SelectedIndexChanged += listBox_0_SelectedIndexChanged;
		listBox_0.DoubleClick += listBox_0_DoubleClick;
		listBox_0.MouseUp += listBox_0_MouseUp;
		contextMenuStrip_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		ToolStripItem[] toolStripItems = new ToolStripItem[4] { toolStripMenuItem_0, toolStripMenuItem_1, toolStripSeparator_0, toolStripMenuItem_2 };
		contextMenuStrip_0.Items.AddRange(toolStripItems);
		contextMenuStrip_0.Name = Class16.smethod_0(1649003266);
		Size size3 = new Size(127, 76);
		contextMenuStrip_0.Size = size3;
		contextMenuStrip_0.Opening += contextMenuStrip_0_Opening;
		toolStripMenuItem_0.Image = Resources.mnuChangeName;
		toolStripMenuItem_0.Name = Class16.smethod_0(1649072064);
		Size size4 = new Size(126, 22);
		toolStripMenuItem_0.Size = size4;
		toolStripMenuItem_0.Text = Class16.smethod_0(1648970834);
		toolStripMenuItem_0.Click += toolStripMenuItem_0_Click;
		Color red = Color.Red;
		toolStripMenuItem_1.ForeColor = red;
		toolStripMenuItem_1.Image = Resources.mnuDelete;
		toolStripMenuItem_1.Name = Class16.smethod_0(1649003348);
		Size size5 = new Size(126, 22);
		toolStripMenuItem_1.Size = size5;
		toolStripMenuItem_1.Text = Class16.smethod_0(1648925718);
		toolStripMenuItem_1.Click += toolStripMenuItem_1_Click;
		toolStripSeparator_0.Name = Class16.smethod_0(1649072092);
		Size size6 = new Size(123, 6);
		toolStripSeparator_0.Size = size6;
		toolStripMenuItem_2.Font = new Font(Class16.smethod_0(1648942905), 9f);
		toolStripMenuItem_2.Image = Resources.mnuAdd;
		toolStripMenuItem_2.Name = Class16.smethod_0(1649003303);
		Size size7 = new Size(126, 22);
		toolStripMenuItem_2.Size = size7;
		toolStripMenuItem_2.Text = Class16.smethod_0(1648931361);
		toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
		listBox_1.ContextMenuStrip = contextMenuStrip_0;
		listBox_1.FormattingEnabled = true;
		Point location3 = new Point(170, 13);
		listBox_1.Location = location3;
		listBox_1.Name = Class16.smethod_0(1649072096);
		Size size8 = new Size(159, 160);
		listBox_1.Size = size8;
		listBox_1.TabIndex = 111;
		listBox_1.SelectedIndexChanged += listBox_1_SelectedIndexChanged;
		listBox_1.DoubleClick += listBox_1_DoubleClick;
		listBox_1.MouseUp += listBox_1_MouseUp;
		listBox_2.ContextMenuStrip = contextMenuStrip_0;
		listBox_2.FormattingEnabled = true;
		Point location4 = new Point(335, 13);
		listBox_2.Location = location4;
		listBox_2.Name = Class16.smethod_0(1649072118);
		Size size9 = new Size(159, 160);
		listBox_2.Size = size9;
		listBox_2.TabIndex = 112;
		listBox_2.SelectedIndexChanged += listBox_2_SelectedIndexChanged;
		listBox_2.DoubleClick += listBox_2_DoubleClick;
		listBox_2.MouseUp += listBox_2_MouseUp;
		listBox_3.FormattingEnabled = true;
		Point location5 = new Point(500, 13);
		listBox_3.Location = location5;
		listBox_3.Name = Class16.smethod_0(1649071108);
		Size size10 = new Size(49, 160);
		listBox_3.Size = size10;
		listBox_3.TabIndex = 113;
		toolTip_0.SetToolTip(listBox_3, Class16.smethod_0(1649071125));
		TextBox value = textBox_0;
		groupBox_0.Controls.Add(value);
		ListBox value2 = listBox_2;
		groupBox_0.Controls.Add(value2);
		ListBox value3 = listBox_0;
		groupBox_0.Controls.Add(value3);
		ListBox value4 = listBox_1;
		groupBox_0.Controls.Add(value4);
		ListBox value5 = listBox_3;
		groupBox_0.Controls.Add(value5);
		Point location6 = new Point(3, -4);
		groupBox_0.Location = location6;
		groupBox_0.Name = Class16.smethod_0(1648929126);
		Size size11 = new Size(554, 180);
		groupBox_0.Size = size11;
		groupBox_0.TabIndex = 114;
		groupBox_0.TabStop = false;
		Point location7 = new Point(155, 122);
		textBox_0.Location = location7;
		textBox_0.MaxLength = 32;
		textBox_0.Name = Class16.smethod_0(1649071144);
		Size size12 = new Size(124, 22);
		textBox_0.Size = size12;
		textBox_0.TabIndex = 0;
		textBox_0.TextAlign = HorizontalAlignment.Center;
		textBox_0.Visible = false;
		textBox_0.KeyUp += textBox_0_KeyUp;
		textBox_0.Leave += textBox_0_Leave;
		SizeF sizeF = new SizeF(6f, 13f);
		base.AutoScaleDimensions = sizeF;
		base.AutoScaleMode = AutoScaleMode.Font;
		Color backColor = Color.FromArgb(239, 244, 250);
		BackColor = backColor;
		Size clientSize = new Size(561, 205);
		base.ClientSize = clientSize;
		Button value6 = button_0;
		base.Controls.Add(value6);
		GroupBox value7 = groupBox_0;
		base.Controls.Add(value7);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		Padding margin = new Padding(3, 4, 3, 4);
		base.Margin = margin;
		base.Name = Class16.smethod_0(1649071161);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.Manual;
		Text = Class16.smethod_0(1649071187);
		base.Load += CategorySelector_FW_Load;
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
				method_1();
				return;
			}
			finally
			{
				base.Dispose(true);
			}
		}
		base.Dispose(false);
	}

	private void CategorySelector_FW_Load(object sender, EventArgs e)
	{
		ShopDirLua categories = Categories;
		if (categories != null)
		{
			SHOP_CATEGORY_FW root = categories.Root;
			if (root != null)
			{
				ListBox.ObjectCollection items = listBox_0.Items;
				object[] subCategories = root.GetSubCategories();
				items.AddRange(subCategories);
				ITEM_CATEGORY_POS catPos = CatPos;
				if (catPos != null)
				{
					listBox_0.SelectedIndex = catPos.pos1;
					int pos = CatPos.pos2;
					if (pos > -1)
					{
						listBox_1.SelectedIndex = pos;
					}
					int pos2 = CatPos.pos3;
					if (pos2 > -1)
					{
						listBox_2.SelectedIndex = pos2;
					}
					method_0(CatPos.Category);
					listBox_3.SelectedIndex = CatPos.item_pos;
				}
				else
				{
					listBox_0.SelectedIndex = 0;
				}
				_ = Cursor;
				Point position = Cursor.Position;
				int num = base.Width / 2;
				base.Left = position.X - num;
				_ = Cursor;
				Point position2 = Cursor.Position;
				int num2 = base.Height / 2;
				base.Top = position2.Y - num2;
				return;
			}
		}
		TextStorage.TEXTS.ShowErrorMessage(903);
		Close();
	}

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		switch (FocusedCatDeep)
		{
		case 1:
		{
			if (Categories.Root.SubCategories.Count == 1)
			{
				ACE.RSGlobal.RSGlobal.msgbox(Class16.smethod_0(1649071211));
				GC.KeepAlive(this);
				return;
			}
			Categories.Root.DeleteCategory(listBox_0.SelectedIndex);
			listBox_0.Items.Clear();
			SHOP_CATEGORY_FW root = Categories.Root;
			ListBox.ObjectCollection items = listBox_0.Items;
			object[] subCategories = root.GetSubCategories();
			items.AddRange(subCategories);
			listBox_0.SelectedIndex = 0;
			break;
		}
		case 2:
			Cat1.DeleteCategory(listBox_1.SelectedIndex);
			listBox_0_SelectedIndexChanged(null, null);
			break;
		case 3:
			Cat2.DeleteCategory(listBox_2.SelectedIndex);
			listBox_1_SelectedIndexChanged(null, null);
			break;
		}
		Categories.FileChanged = true;
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		string text = Class16.smethod_0(1648904254);
		switch (FocusedCatDeep)
		{
		case 1:
		{
			Categories.Root.AddCategory(text);
			listBox_0.Items.Add(text);
			int selectedIndex2 = Categories.Root.SubCategories.Count - 1;
			listBox_0.SelectedIndex = selectedIndex2;
			goto default;
		}
		case 2:
		{
			SHOP_CATEGORY_FW cat2 = Cat1;
			if (cat2 != null)
			{
				cat2.AddCategory(text);
				listBox_1.Items.Add(text);
				int selectedIndex3 = Cat1.SubCategories.Count - 1;
				listBox_1.SelectedIndex = selectedIndex3;
				goto default;
			}
			break;
		}
		case 3:
		{
			SHOP_CATEGORY_FW cat = Cat2;
			if (cat != null)
			{
				cat.AddCategory(text);
				listBox_2.Items.Add(text);
				int selectedIndex = Cat2.SubCategories.Count - 1;
				listBox_2.SelectedIndex = selectedIndex;
				goto default;
			}
			break;
		}
		default:
			Categories.FileChanged = true;
			break;
		}
	}

	private void toolStripMenuItem_0_Click(object sender, EventArgs e)
	{
		method_3();
	}

	private void contextMenuStrip_0_Opening(object sender, CancelEventArgs e)
	{
		if (listBox_0.Focused)
		{
			FocusedCatDeep = 1;
		}
		else if (listBox_1.Focused)
		{
			FocusedCatDeep = 2;
		}
		if (listBox_2.Focused)
		{
			FocusedCatDeep = 3;
		}
	}

	private void listBox_1_MouseUp(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			FocusedCatDeep = 2;
		}
	}

	private void listBox_0_MouseUp(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			FocusedCatDeep = 1;
		}
	}

	private void listBox_2_MouseUp(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			FocusedCatDeep = 3;
		}
	}

	private void textBox_0_Leave(object sender, EventArgs e)
	{
		textBox_0.Visible = false;
		bool_0 = true;
		switch (FocusedCatDeep)
		{
		case 1:
		{
			Cat1.Name = textBox_0.Text;
			TextBox textBox3 = textBox_0;
			ListBox listBox3 = listBox_0;
			listBox_0.Items[listBox3.SelectedIndex] = textBox3.Text;
			break;
		}
		case 2:
		{
			Cat2.Name = textBox_0.Text;
			TextBox textBox2 = textBox_0;
			ListBox listBox2 = listBox_1;
			listBox_1.Items[listBox2.SelectedIndex] = textBox2.Text;
			break;
		}
		case 3:
		{
			Cat3.Name = textBox_0.Text;
			TextBox textBox = textBox_0;
			ListBox listBox = listBox_2;
			listBox_2.Items[listBox.SelectedIndex] = textBox.Text;
			break;
		}
		}
		bool_0 = false;
		GC.KeepAlive(this);
	}

	private void listBox_0_DoubleClick(object sender, EventArgs e)
	{
		FocusedCatDeep = 1;
		method_3();
	}

	private void listBox_1_DoubleClick(object sender, EventArgs e)
	{
		FocusedCatDeep = 2;
		method_3();
	}

	private void listBox_2_DoubleClick(object sender, EventArgs e)
	{
		FocusedCatDeep = 3;
		method_3();
	}

	private void method_3()
	{
		_ = Cursor;
		Point position = Cursor.Position;
		int left = -20 - base.Left + position.X;
		textBox_0.Left = left;
		_ = Cursor;
		Point position2 = Cursor.Position;
		int top = -5 - base.Top - SystemInformation.ToolWindowCaptionHeight + position2.Y;
		textBox_0.Top = top;
		switch (FocusedCatDeep)
		{
		case 1:
		{
			SHOP_CATEGORY_FW cat2 = Cat1;
			if (cat2 != null)
			{
				textBox_0.Text = cat2.Name;
				goto default;
			}
			break;
		}
		case 2:
		{
			SHOP_CATEGORY_FW cat3 = Cat2;
			if (cat3 != null)
			{
				textBox_0.Text = cat3.Name;
				goto default;
			}
			break;
		}
		case 3:
		{
			SHOP_CATEGORY_FW cat = Cat3;
			if (cat != null)
			{
				textBox_0.Text = cat.Name;
				goto default;
			}
			break;
		}
		default:
			textBox_0.Visible = true;
			textBox_0.Focus();
			textBox_0.SelectAll();
			Categories.FileChanged = true;
			break;
		}
	}

	private void textBox_0_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			textBox_0_Leave(null, null);
		}
	}
}
