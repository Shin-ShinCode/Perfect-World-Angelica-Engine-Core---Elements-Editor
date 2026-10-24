using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eList;
using ACE.Elements.eListCollection;
using ACE.Path;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.Elements;

public class IconsWindow : Form
{
	public ICONS Icons;

	public CommonStorage CStorage;

	public int HIconsCount;

	public bool Sorted;

	public Point mousemove_prevpos;

	public int VIconsCount;

	public bool IsShopFWorJD;

	public bool IsShopPW;

	public PATH_DATA PathData;

	public ACE.Elements.eListCollection.eListCollection eLC;

	public string CurrentIconName;

	public bool IsScrollChanged;

	private PanelEx panelEx_0;

	private GroupBox groupBox_0;

	private PictureBox pictureBox_0;

	private PictureBox pictureBox_1;

	private PictureBox pictureBox_2;

	private PictureBox pictureBox_3;

	private PictureBox pictureBox_4;

	private PictureBox pictureBox_5;

	private PictureBox pictureBox_6;

	private PictureBox pictureBox_7;

	private Button button_0;

	private Button button_1;

	private PictureBox pictureBox_8;

	private ToolTip toolTip_0;

	private Timer timer_0;

	private IContainer icontainer_0;

	public IconsWindow(CommonStorage CStorage, ICONS Icons)
	{
		try
		{
			method_2();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			Sorted = false;
			VIconsCount = 20;
			this.CStorage = CStorage;
			this.Icons = Icons;
			IsShopFWorJD = false;
			IsShopPW = false;
			TextStorage.TEXTS.SetFormLanguage(this, null);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	public void RefreshSizes()
	{
		panelEx_0.scroll_step = (short)Icons.icon_height;
		pictureBox_8.Width = Icons.icon_width;
		pictureBox_4.Height = Icons.icon_height;
		pictureBox_2.Width = Icons.icon_width;
		pictureBox_3.Height = Icons.icon_height;
		pictureBox_1.Width = Icons.icon_width;
		GC.KeepAlive(this);
	}

	public void IconsLoaded()
	{
		ICONS icons = Icons;
		if (icons.MainImage != null)
		{
			int vIconsCount = ((icons.icon_height >= 48) ? 16 : 20);
			VIconsCount = vIconsCount;
			HIconsCount = icons.icons_per_line;
			pictureBox_0.Image = icons.MainImage;
			Size size = pictureBox_0.Image.Size;
			groupBox_0.Size = size;
			int num = Icons.icon_height * VIconsCount + SystemInformation.HorizontalScrollBarHeight + 1;
			int num2 = Icons.icon_width * VIconsCount;
			Size clientSize = new Size(num2 + SystemInformation.VerticalScrollBarWidth + 1, num);
			base.ClientSize = clientSize;
			RefreshSizes();
			base.FormBorderStyle = FormBorderStyle.Sizable;
			base.MaximizeBox = true;
		}
	}

	public void SortedIconsLoaded(int HIconsCount)
	{
		ICONS icons = Icons;
		if (icons.SortedImage != null)
		{
			this.HIconsCount = HIconsCount;
			pictureBox_0.Image = icons.SortedImage;
			Size size = pictureBox_0.Image.Size;
			groupBox_0.Size = size;
			ICONS icons2 = Icons;
			int num = icons2.icon_height * VIconsCount + 1;
			int num2 = icons2.icon_width * HIconsCount;
			Size clientSize = new Size(num2 + SystemInformation.VerticalScrollBarWidth + 1, num);
			base.ClientSize = clientSize;
			Sorted = true;
			RefreshSizes();
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.MaximizeBox = false;
		}
	}

	public void SetVIconsCount(int NewCount)
	{
		if (VIconsCount != NewCount)
		{
			VIconsCount = NewCount;
			if (Sorted)
			{
				ICONS icons = Icons;
				int num = icons.icon_height * NewCount + 1;
				int num2 = icons.icon_width * HIconsCount;
				Size clientSize = new Size(num2 + SystemInformation.VerticalScrollBarWidth + 1, num);
				base.ClientSize = clientSize;
			}
			else
			{
				int num3 = Icons.icon_height * NewCount + SystemInformation.HorizontalScrollBarHeight + 1;
				int num4 = Icons.icon_width * VIconsCount;
				Size clientSize2 = new Size(num4 + SystemInformation.VerticalScrollBarWidth + 1, num3);
				base.ClientSize = clientSize2;
			}
			GC.KeepAlive(this);
		}
	}

	private void pictureBox_0_MouseClick(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			Point location = e.Location;
			method_0(e.Location.X, location.Y);
			method_3();
		}
	}

	private void pictureBox_0_MouseMove(object sender, MouseEventArgs e)
	{
		if (!ACE.RSGlobal.RSGlobal.antirecurse_picIcons_MouseMove_IconsWindow && !IsScrollChanged)
		{
			ACE.RSGlobal.RSGlobal.antirecurse_picIcons_MouseMove_IconsWindow = true;
			Point location = e.Location;
			mousemove_prevpos = location;
			Point location2 = e.Location;
			method_0(e.Location.X, method_5(location2.Y));
			ACE.RSGlobal.RSGlobal.antirecurse_picIcons_MouseMove_IconsWindow = false;
			GC.KeepAlive(this);
		}
		else
		{
			Point location3 = e.Location;
			mousemove_prevpos = location3;
			GC.KeepAlive(this);
		}
	}

	private void IconsWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		Hide();
		if (!Sorted)
		{
			panelEx_0.VerticalScroll.Value = 0;
			panelEx_0.HorizontalScroll.Value = 0;
		}
		e.Cancel = true;
		GC.KeepAlive(this);
	}

	private void IconsWindow_Shown(object sender, EventArgs e)
	{
		panelEx_0.Focus();
		method_4();
		timer_0.Enabled = true;
		GC.KeepAlive(this);
	}

	private void method_0(int int_0, int int_1)
	{
		ICONS icons = Icons;
		int icon_width = icons.icon_width;
		int num = int_0 / icon_width * icon_width + 1;
		int icon_height = icons.icon_height;
		int int_2 = int_1 / icon_height * icon_height + 1;
		int_2 = method_6(int_2);
		if (pictureBox_2.Left != num || pictureBox_2.Top != int_2)
		{
			pictureBox_2.Left = num;
			pictureBox_2.Top = int_2;
			pictureBox_4.Left = num;
			pictureBox_4.Top = int_2;
			pictureBox_1.Left = num;
			int num2 = int_2 - pictureBox_1.Image.Height;
			pictureBox_1.Top = Icons.icon_height + num2;
			int num3 = num - pictureBox_3.Image.Width;
			pictureBox_3.Left = Icons.icon_width + num3;
			pictureBox_3.Top = int_2;
			method_7();
		}
		if (!pictureBox_2.Visible)
		{
			pictureBox_2.Visible = true;
			pictureBox_4.Visible = true;
			pictureBox_1.Visible = true;
			pictureBox_3.Visible = true;
		}
		GC.KeepAlive(this);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		method_3();
	}

	private void method_1()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_2()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(IconsWindow));
		panelEx_0 = new PanelEx();
		groupBox_0 = new GroupBox();
		pictureBox_8 = new PictureBox();
		pictureBox_5 = new PictureBox();
		pictureBox_6 = new PictureBox();
		pictureBox_2 = new PictureBox();
		pictureBox_7 = new PictureBox();
		pictureBox_3 = new PictureBox();
		pictureBox_4 = new PictureBox();
		pictureBox_1 = new PictureBox();
		pictureBox_0 = new PictureBox();
		button_0 = new Button();
		button_1 = new Button();
		toolTip_0 = new ToolTip(icontainer_0);
		timer_0 = new Timer(icontainer_0);
		panelEx_0.SuspendLayout();
		groupBox_0.SuspendLayout();
		((ISupportInitialize)pictureBox_8).BeginInit();
		((ISupportInitialize)pictureBox_5).BeginInit();
		((ISupportInitialize)pictureBox_6).BeginInit();
		((ISupportInitialize)pictureBox_2).BeginInit();
		((ISupportInitialize)pictureBox_7).BeginInit();
		((ISupportInitialize)pictureBox_3).BeginInit();
		((ISupportInitialize)pictureBox_4).BeginInit();
		((ISupportInitialize)pictureBox_1).BeginInit();
		((ISupportInitialize)pictureBox_0).BeginInit();
		SuspendLayout();
		panelEx_0.AutoScroll = true;
		panelEx_0.Controls.Add(groupBox_0);
		panelEx_0.Dock = DockStyle.Fill;
		panelEx_0.Location = new Point(0, 0);
		panelEx_0.Name = Class16.smethod_0(1648976924);
		panelEx_0.Size = new Size(786, 641);
		panelEx_0.TabIndex = 0;
		groupBox_0.Controls.Add(pictureBox_8);
		groupBox_0.Controls.Add(pictureBox_5);
		groupBox_0.Controls.Add(pictureBox_6);
		groupBox_0.Controls.Add(pictureBox_2);
		groupBox_0.Controls.Add(pictureBox_7);
		groupBox_0.Controls.Add(pictureBox_3);
		groupBox_0.Controls.Add(pictureBox_4);
		groupBox_0.Controls.Add(pictureBox_1);
		groupBox_0.Controls.Add(pictureBox_0);
		groupBox_0.Controls.Add(button_0);
		groupBox_0.Controls.Add(button_1);
		groupBox_0.FlatStyle = FlatStyle.Flat;
		groupBox_0.Location = new Point(0, 0);
		groupBox_0.Name = Class16.smethod_0(1648894106);
		groupBox_0.Size = new Size(678, 532);
		groupBox_0.TabIndex = 5;
		groupBox_0.TabStop = false;
		pictureBox_8.Image = Resources.highlighter;
		pictureBox_8.Location = new Point(422, 410);
		pictureBox_8.Name = Class16.smethod_0(1648976929);
		pictureBox_8.Size = new Size(32, 3);
		pictureBox_8.SizeMode = PictureBoxSizeMode.StretchImage;
		pictureBox_8.TabIndex = 14;
		pictureBox_8.TabStop = false;
		toolTip_0.SetToolTip(pictureBox_8, Class16.smethod_0(1648976947));
		pictureBox_5.BackColor = Color.Transparent;
		pictureBox_5.Cursor = Cursors.Hand;
		pictureBox_5.Image = Resources.pictureBox4;
		pictureBox_5.Location = new Point(534, 328);
		pictureBox_5.Name = Class16.smethod_0(1648976974);
		pictureBox_5.Size = new Size(32, 2);
		pictureBox_5.SizeMode = PictureBoxSizeMode.StretchImage;
		pictureBox_5.TabIndex = 11;
		pictureBox_5.TabStop = false;
		pictureBox_5.Visible = false;
		pictureBox_6.BackColor = Color.Transparent;
		pictureBox_6.Cursor = Cursors.Hand;
		pictureBox_6.Image = Resources.pictureBox3;
		pictureBox_6.Location = new Point(564, 328);
		pictureBox_6.Name = Class16.smethod_0(1648976984);
		pictureBox_6.Size = new Size(2, 32);
		pictureBox_6.SizeMode = PictureBoxSizeMode.StretchImage;
		pictureBox_6.TabIndex = 10;
		pictureBox_6.TabStop = false;
		pictureBox_6.Visible = false;
		pictureBox_2.BackColor = Color.Transparent;
		pictureBox_2.Cursor = Cursors.Hand;
		pictureBox_2.Image = Resources.htop;
		pictureBox_2.Location = new Point(534, 328);
		pictureBox_2.Name = Class16.smethod_0(1648977002);
		pictureBox_2.Size = new Size(32, 2);
		pictureBox_2.SizeMode = PictureBoxSizeMode.StretchImage;
		pictureBox_2.TabIndex = 11;
		pictureBox_2.TabStop = false;
		pictureBox_2.Visible = false;
		pictureBox_7.BackColor = Color.Transparent;
		pictureBox_7.Cursor = Cursors.Hand;
		pictureBox_7.Image = Resources.pictureBox2;
		pictureBox_7.Location = new Point(534, 328);
		pictureBox_7.Name = Class16.smethod_0(1648977021);
		pictureBox_7.Size = new Size(2, 32);
		pictureBox_7.SizeMode = PictureBoxSizeMode.StretchImage;
		pictureBox_7.TabIndex = 9;
		pictureBox_7.TabStop = false;
		pictureBox_7.Visible = false;
		pictureBox_3.BackColor = Color.Transparent;
		pictureBox_3.Cursor = Cursors.Hand;
		pictureBox_3.Image = Resources.hright;
		pictureBox_3.Location = new Point(564, 328);
		pictureBox_3.Name = Class16.smethod_0(1648977039);
		pictureBox_3.Size = new Size(2, 32);
		pictureBox_3.SizeMode = PictureBoxSizeMode.StretchImage;
		pictureBox_3.TabIndex = 10;
		pictureBox_3.TabStop = false;
		pictureBox_3.Visible = false;
		pictureBox_4.BackColor = Color.Transparent;
		pictureBox_4.Cursor = Cursors.Hand;
		pictureBox_4.Image = Resources.hleft;
		pictureBox_4.Location = new Point(534, 328);
		pictureBox_4.Name = Class16.smethod_0(1648977052);
		pictureBox_4.Size = new Size(2, 32);
		pictureBox_4.SizeMode = PictureBoxSizeMode.StretchImage;
		pictureBox_4.TabIndex = 9;
		pictureBox_4.TabStop = false;
		pictureBox_4.Visible = false;
		pictureBox_1.BackColor = Color.Transparent;
		pictureBox_1.Cursor = Cursors.Hand;
		pictureBox_1.Image = Resources.hbottom;
		pictureBox_1.Location = new Point(534, 358);
		pictureBox_1.Name = Class16.smethod_0(1648977056);
		pictureBox_1.Size = new Size(32, 2);
		pictureBox_1.SizeMode = PictureBoxSizeMode.StretchImage;
		pictureBox_1.TabIndex = 8;
		pictureBox_1.TabStop = false;
		pictureBox_1.Visible = false;
		pictureBox_0.Cursor = Cursors.Hand;
		pictureBox_0.Location = new Point(0, 0);
		pictureBox_0.Name = Class16.smethod_0(1648977078);
		pictureBox_0.Size = new Size(357, 233);
		pictureBox_0.SizeMode = PictureBoxSizeMode.AutoSize;
		pictureBox_0.TabIndex = 7;
		pictureBox_0.TabStop = false;
		pictureBox_0.MouseClick += pictureBox_0_MouseClick;
		pictureBox_0.MouseDown += pictureBox_0_MouseDown;
		pictureBox_0.MouseHover += pictureBox_0_MouseHover;
		pictureBox_0.MouseMove += pictureBox_0_MouseMove;
		button_0.AutoSize = true;
		button_0.DialogResult = DialogResult.Cancel;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 11f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.IconsWindow_cmdCancel;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(-271, -28);
		button_0.Name = Class16.smethod_0(1649000848);
		button_0.Size = new Size(285, 38);
		button_0.TabIndex = 13;
		button_0.TabStop = false;
		button_0.Text = Class16.smethod_0(1648941799);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_1.DialogResult = DialogResult.OK;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 11f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_1.Image = Resources.IconsWindow_cmdOK;
		button_1.ImageAlign = ContentAlignment.MiddleRight;
		button_1.Location = new Point(-563, -28);
		button_1.Margin = new Padding(3, 4, 3, 4);
		button_1.Name = Class16.smethod_0(1649000844);
		button_1.Size = new Size(287, 38);
		button_1.TabIndex = 12;
		button_1.Text = Class16.smethod_0(1648938905);
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		toolTip_0.AutoPopDelay = 10000;
		toolTip_0.InitialDelay = 100;
		toolTip_0.ReshowDelay = 100;
		timer_0.Interval = 30;
		timer_0.Tick += timer_0_Tick;
		base.AcceptButton = button_1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(32, 32, 32);
		base.CancelButton = button_0;
		base.ClientSize = new Size(786, 641);
		base.Controls.Add(panelEx_0);
		base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		base.Icon = Resources.IconsWindow_Icon;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648977093);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648977111);
		base.FormClosing += IconsWindow_FormClosing;
		base.Shown += IconsWindow_Shown;
		panelEx_0.ResumeLayout(performLayout: false);
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		((ISupportInitialize)pictureBox_8).EndInit();
		((ISupportInitialize)pictureBox_5).EndInit();
		((ISupportInitialize)pictureBox_6).EndInit();
		((ISupportInitialize)pictureBox_2).EndInit();
		((ISupportInitialize)pictureBox_7).EndInit();
		((ISupportInitialize)pictureBox_3).EndInit();
		((ISupportInitialize)pictureBox_4).EndInit();
		((ISupportInitialize)pictureBox_1).EndInit();
		((ISupportInitialize)pictureBox_0).EndInit();
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

	private void method_3()
	{
		if (Icons.icon_height >= 60)
		{
			if (IsShopFWorJD)
			{
				PictureBox pictureBox = pictureBox_2;
				PictureBox pictureBox2 = pictureBox_2;
				int hIconsCount = HIconsCount;
				string iconName = Icons.GetIconName(hIconsCount, pictureBox2.Left, pictureBox.Top);
				CommonStorage.iData = (int)PathData.GetPathID(iconName, bContains: false);
			}
			else
			{
				PictureBox pictureBox3 = pictureBox_2;
				PictureBox pictureBox4 = pictureBox_2;
				int hIconsCount2 = HIconsCount;
				CommonStorage.sData = Icons.GetIconName(hIconsCount2, pictureBox4.Left, pictureBox3.Top);
			}
		}
		else
		{
			PictureBox pictureBox5 = pictureBox_2;
			PictureBox pictureBox6 = pictureBox_2;
			int hIconsCount3 = HIconsCount;
			CommonStorage.sData = eLC.GetIconValue(hIconsCount3, pictureBox6.Left, pictureBox5.Top);
		}
		Hide();
		if (!Sorted)
		{
			panelEx_0.VerticalScroll.Value = 0;
			panelEx_0.HorizontalScroll.Value = 0;
		}
		GC.KeepAlive(this);
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		method_4();
		timer_0.Enabled = false;
		GC.KeepAlive(this);
	}

	private void method_4()
	{
		Point iconCoords = Icons.GetIconCoords(CurrentIconName, HIconsCount);
		pictureBox_8.Left = iconCoords.X;
		int top = Icons.icon_height - 3 + iconCoords.Y;
		pictureBox_8.Top = top;
		if (pictureBox_8.Top > 61 || pictureBox_8.Left > 31)
		{
			int num = panelEx_0.Width / 2 - panelEx_0.Width;
			int num2 = iconCoords.X + num;
			if (!Sorted && num2 > 0 && num2 < panelEx_0.HorizontalScroll.Maximum)
			{
				panelEx_0.HorizontalScroll.Value = num2;
			}
			int num3 = panelEx_0.Height / 2 - panelEx_0.Height;
			int num4 = Icons.icon_height + num3;
			int num5 = iconCoords.Y + num4;
			if (num5 > 0 && num5 < panelEx_0.VerticalScroll.Maximum)
			{
				panelEx_0.VerticalScroll.Value = num5;
			}
		}
		GC.KeepAlive(this);
	}

	private int method_5(int int_0)
	{
		if (int_0 < 0)
		{
			int_0 = 32767 - int_0;
		}
		return int_0;
	}

	private int method_6(int int_0)
	{
		if (int_0 > 65535)
		{
			CommonStorage.AParams.ExperimentalIcons = true;
			throw new InvalidOperationException(Class16.smethod_0(1648977168));
		}
		if (int_0 > 32767)
		{
			int_0 -= 65534;
		}
		GC.KeepAlive(this);
		return int_0;
	}

	private void method_7()
	{
		if (IsShopFWorJD || IsShopPW)
		{
			return;
		}
		int num = method_5(pictureBox_2.Top);
		if (pictureBox_2.Left != ACE.RSGlobal.RSGlobal.prev_x_RefreshToolTip_IconsWindow || num != ACE.RSGlobal.RSGlobal.prev_y_RefreshToolTip_IconsWindow)
		{
			ACE.RSGlobal.RSGlobal.antirecurse_RefreshToolTip_IconsWindow = false;
			ACE.RSGlobal.RSGlobal.prev_x_RefreshToolTip_IconsWindow = pictureBox_2.Left;
			ACE.RSGlobal.RSGlobal.prev_y_RefreshToolTip_IconsWindow = num;
			string text = null;
			int hIconsCount = HIconsCount;
			string iconName = Icons.GetIconName(hIconsCount, pictureBox_2.Left, num);
			int num2 = 0;
			int num3 = 0;
			ACE.Elements.eListCollection.eListCollection eListCollection2 = eLC;
			ACE.Elements.eList.eList[] lists = eListCollection2.Lists;
			if (0 < (nint)lists.LongLength)
			{
				do
				{
					if (lists[num3].IconFieldIndex >= 1)
					{
						int num4 = 0;
						if (0 < eListCollection2.GetItemsCount(num3))
						{
							do
							{
								if (!ACE.RSGlobal.RSGlobal.antirecurse_RefreshToolTip_IconsWindow)
								{
									if (eLC.GetIconNameStrict(num3, num4) == iconName)
									{
										num2++;
										if (num2 <= 3)
										{
											string text2 = eLC.GetParsedItemName(num3, num4, bRealAddonName: true);
											if (text2 == string.Empty)
											{
												text2 = eLC.GetItemID(num3, num4);
											}
											text = string.Concat(text, Class16.smethod_0(1648986192) + text2);
										}
									}
									Application.DoEvents();
									num4++;
									continue;
								}
								GC.KeepAlive(this);
								return;
							}
							while (num4 < eLC.GetItemsCount(num3));
						}
					}
					num3++;
					eListCollection2 = eLC;
					lists = eListCollection2.Lists;
				}
				while (num3 < (nint)lists.LongLength);
			}
			if (text != null)
			{
				text = text.Substring(2);
			}
			toolTip_0.ToolTipTitle = text;
			object[] vars = new object[3]
			{
				Icons.GetIconIndexInFile(iconName),
				iconName,
				num2
			};
			string caption = TextStorage.TEXTS.GetText(Class16.smethod_0(1648977257), vars);
			toolTip_0.SetToolTip(pictureBox_0, caption);
			ACE.RSGlobal.RSGlobal.antirecurse_RefreshToolTip_IconsWindow = true;
		}
		GC.KeepAlive(this);
	}

	private void pictureBox_0_MouseHover(object sender, EventArgs e)
	{
	}

	private void pictureBox_0_MouseDown(object sender, MouseEventArgs e)
	{
	}
}
