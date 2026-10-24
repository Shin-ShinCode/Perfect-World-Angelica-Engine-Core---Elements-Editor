using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eList;
using ACE.Elements.eListCollection;
using ACE.Models;
using ACE.Properties;
using ACE.RSGlobal;
using ACE.Settings;

namespace ACE.Elements;

public class ItemsWindow : Form
{
	public static MODEL_VIEWER ModelViewer;

	public IntPtr OwnerHandle = IntPtr.Zero;

	public IntPtr CallbackHandle = IntPtr.Zero;

	public SID_FLAGS Flags;

	public bool bUseMapping;

	public bool bClassJD;

	public int iResult;

	public bool IsShared;

	public bool norefresh;

	public bool bMultiSelect;

	public List<ITEMINFO> Shortcuts;

	public ACE.Elements.eListCollection.eListCollection eLC;

	public CommonStorage CStorage;

	public ItemsToolTip ItemsToolTip1;

	public int itemindex;

	public int itemlist;

	public int newitemindex;

	public int newitemlist;

	private int[] int_0;

	public int[] newlistsindices;

	private int int_1;

	private bool bool_0;

	private int int_2 = -65535;

	private Button button_0;

	private Button button_1;

	private TextBox textBox_0;

	private Button button_2;

	private ToolTip toolTip_0;

	private ListBox listBox_0;

	private Label label_0;

	private Button button_3;

	private NumericUpDown numericUpDown_0;

	private ListViewEx listViewEx_0;

	private ColumnHeader columnHeader_0;

	private ColumnHeader columnHeader_1;

	private IContainer icontainer_0;

	public ItemsWindow(CommonStorage CStorage, ICONS Icons, IntPtr OwnerHandle, ItemsToolTip ItemsToolTip1)
	{
		try
		{
			this.OwnerHandle = OwnerHandle;
			norefresh = false;
			this.ItemsToolTip1 = ItemsToolTip1;
			method_1();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			this.CStorage = CStorage;
			ToolTip toolTip = toolTip_0;
			TextStorage.TEXTS.SetFormLanguage(this, toolTip);
			int_1 = -1;
			itemlist = -1;
			newitemlist = -1;
			itemindex = -1;
			listViewEx_0.SmallImageList = Icons.imageList;
			bool_0 = false;
			bMultiSelect = false;
			IsShared = false;
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	public void selectlist(int int_3)
	{
		int num = int_3;
		string value = Class16.smethod_0(1648924112);
		string text = num.ToString().PadLeft(3, Convert.ToChar(value));
		int num2 = 0;
		if (0 < listBox_0.Items.Count)
		{
			do
			{
				if (listBox_0.Items[num2].ToString().Substring(0, 3) == text)
				{
					listBox_0.ClearSelected();
					listBox_0.SelectedIndex = num2;
				}
				num2++;
			}
			while (num2 < listBox_0.Items.Count);
		}
		GC.KeepAlive(this);
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		method_2();
	}

	private void listBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (norefresh)
		{
			return;
		}
		int num = (int_1 = method_3());
		if (num == int_2)
		{
			List<ITEMINFO> shortcuts = Shortcuts;
			if (shortcuts != null)
			{
				if (shortcuts.Count != listViewEx_0.VirtualListSize)
				{
					listViewEx_0.VirtualListSize = Shortcuts.Count;
				}
				else
				{
					listViewEx_0.Refresh();
				}
			}
			else
			{
				listViewEx_0.VirtualListSize = 0;
			}
		}
		else if (eLC.GetItemsCount(num) != listViewEx_0.VirtualListSize)
		{
			listViewEx_0.VirtualListSize = eLC.GetItemsCount(num);
		}
		else
		{
			listViewEx_0.Refresh();
		}
		if (listViewEx_0.VirtualListSize > 0)
		{
			listViewEx_0.Items[0].EnsureVisible();
		}
		if (listViewEx_0.SelectedIndices.Count != 0 && listViewEx_0.SelectedIndices[0] > -1)
		{
			object[] vars = new object[3]
			{
				listViewEx_0.SelectedIndices[0],
				listViewEx_0.SelectedIndices.Count,
				listViewEx_0.VirtualListSize
			};
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648978629), vars);
			columnHeader_1.Text = text;
		}
		else
		{
			object[] vars2 = new object[3] { 0, 0, 0 };
			string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648978629), vars2);
			columnHeader_1.Text = text2;
		}
		byte b = ((listViewEx_0.SelectedIndices.Count > 0) ? ((byte)1) : ((byte)0));
		button_3.Enabled = b != 0;
		GC.KeepAlive(this);
	}

	private void listViewEx_0_DoubleClick(object sender, EventArgs e)
	{
		method_2();
	}

	private void method_0()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_1()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(ItemsWindow));
		listBox_0 = new ListBox();
		label_0 = new Label();
		button_3 = new Button();
		numericUpDown_0 = new NumericUpDown();
		listViewEx_0 = new ListViewEx();
		columnHeader_1 = new ColumnHeader();
		columnHeader_0 = new ColumnHeader();
		toolTip_0 = new ToolTip(icontainer_0);
		button_1 = new Button();
		textBox_0 = new TextBox();
		button_0 = new Button();
		button_2 = new Button();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		SuspendLayout();
		listBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		listBox_0.BackColor = Color.FromArgb(32, 32, 32);
		listBox_0.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		listBox_0.ForeColor = Color.LemonChiffon;
		listBox_0.FormattingEnabled = true;
		listBox_0.ItemHeight = 17;
		listBox_0.Location = new Point(3, 4);
		listBox_0.Margin = new Padding(3, 4, 3, 4);
		listBox_0.Name = Class16.smethod_0(1648978652);
		listBox_0.Size = new Size(232, 565);
		listBox_0.TabIndex = 3;
		listBox_0.SelectedIndexChanged += listBox_0_SelectedIndexChanged;
		listBox_0.MouseMove += listBox_0_MouseMove;
		label_0.AutoSize = true;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_0.Location = new Point(-282, 490);
		label_0.Name = Class16.smethod_0(1648919238);
		label_0.Size = new Size(127, 20);
		label_0.TabIndex = 2;
		label_0.Text = Class16.smethod_0(1648919243);
		label_0.Visible = false;
		button_3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		button_3.AutoSize = true;
		button_3.DialogResult = DialogResult.OK;
		button_3.Enabled = false;
		button_3.Font = new Font(Class16.smethod_0(1648942905), 12f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_3.Image = Resources.ItemsWindow_cmdok;
		button_3.ImageAlign = ContentAlignment.MiddleRight;
		button_3.Location = new Point(3, 573);
		button_3.Name = Class16.smethod_0(1648925748);
		button_3.Size = new Size(342, 41);
		button_3.TabIndex = 1;
		button_3.TabStop = false;
		button_3.Text = Class16.smethod_0(1648919277);
		button_3.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		numericUpDown_0.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_0.Location = new Point(-88, 491);
		numericUpDown_0.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		numericUpDown_0.Name = Class16.smethod_0(1648932143);
		numericUpDown_0.Size = new Size(100, 25);
		numericUpDown_0.TabIndex = 5;
		numericUpDown_0.TextAlign = HorizontalAlignment.Center;
		numericUpDown_0.Value = new decimal(new int[4] { 123, 0, 0, 0 });
		numericUpDown_0.Visible = false;
		listViewEx_0.AllowColumnReorder = true;
		listViewEx_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		listViewEx_0.BackColor = Color.FromArgb(32, 32, 32);
		listViewEx_0.BorderStyle = BorderStyle.FixedSingle;
		listViewEx_0.Columns.AddRange(new ColumnHeader[2] { columnHeader_1, columnHeader_0 });
		listViewEx_0.Cursor = Cursors.Default;
		listViewEx_0.Font = new Font(Class16.smethod_0(1648929920), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		listViewEx_0.ForeColor = Color.White;
		listViewEx_0.FullRowSelect = true;
		listViewEx_0.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		listViewEx_0.HideSelection = false;
		listViewEx_0.LabelWrap = false;
		listViewEx_0.Location = new Point(269, 30);
		listViewEx_0.Name = Class16.smethod_0(1648978656);
		listViewEx_0.ShowGroups = false;
		listViewEx_0.Size = new Size(422, 539);
		listViewEx_0.TabIndex = 0;
		listViewEx_0.Tag = Class16.smethod_0(1648919381);
		listViewEx_0.UseCompatibleStateImageBehavior = false;
		listViewEx_0.View = View.Details;
		listViewEx_0.VirtualMode = true;
		listViewEx_0.ItemMouseHover += listViewEx_0_ItemMouseHover;
		listViewEx_0.RetrieveVirtualItem += listViewEx_0_RetrieveVirtualItem;
		listViewEx_0.SelectedIndexChanged += listViewEx_0_SelectedIndexChanged;
		listViewEx_0.VirtualItemsSelectionRangeChanged += listViewEx_0_VirtualItemsSelectionRangeChanged;
		listViewEx_0.DoubleClick += listViewEx_0_DoubleClick;
		listViewEx_0.MouseDown += listViewEx_0_MouseDown;
		listViewEx_0.MouseHover += listViewEx_0_MouseHover;
		listViewEx_0.MouseMove += listViewEx_0_MouseMove;
		columnHeader_1.Text = Class16.smethod_0(1648936731);
		columnHeader_1.Width = 338;
		columnHeader_0.Text = Class16.smethod_0(1648941057);
		columnHeader_0.TextAlign = HorizontalAlignment.Center;
		columnHeader_0.Width = 57;
		toolTip_0.AutomaticDelay = 1500;
		toolTip_0.AutoPopDelay = 1500;
		toolTip_0.InitialDelay = 1500;
		toolTip_0.ReshowDelay = 1000;
		button_1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		button_1.AutoSize = true;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 12f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_1.Image = Resources.ItemsWindow_cmdselectlast;
		button_1.Location = new Point(236, 4);
		button_1.Name = Class16.smethod_0(1648978676);
		button_1.Size = new Size(31, 565);
		button_1.TabIndex = 7;
		button_1.TabStop = false;
		button_1.TextAlign = ContentAlignment.BottomCenter;
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_0.SetToolTip(button_1, Class16.smethod_0(1648978688));
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		textBox_0.BackColor = Color.FromArgb(220, 255, 255);
		textBox_0.Location = new Point(269, 4);
		textBox_0.Name = Class16.smethod_0(1648978721);
		textBox_0.Size = new Size(335, 22);
		textBox_0.TabIndex = 8;
		textBox_0.TextAlign = HorizontalAlignment.Center;
		toolTip_0.SetToolTip(textBox_0, Class16.smethod_0(1648978743));
		textBox_0.TextChanged += textBox_0_TextChanged;
		textBox_0.Enter += textBox_0_Enter;
		textBox_0.Leave += textBox_0_Leave;
		button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		button_0.AutoSize = true;
		button_0.DialogResult = DialogResult.Cancel;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 12f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.ItemsWindow_cmdcancel;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(351, 573);
		button_0.Name = Class16.smethod_0(1648925752);
		button_0.Size = new Size(340, 41);
		button_0.TabIndex = 6;
		button_0.TabStop = false;
		button_0.Text = Class16.smethod_0(1648989215);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_2.Image = Resources.findnext;
		button_2.ImageAlign = ContentAlignment.MiddleRight;
		button_2.Location = new Point(610, 3);
		button_2.Name = Class16.smethod_0(1648978792);
		button_2.Size = new Size(81, 23);
		button_2.TabIndex = 9;
		button_2.Text = Class16.smethod_0(1648978815);
		button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		base.AcceptButton = button_3;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		AutoSize = true;
		BackColor = Color.FromArgb(239, 244, 250);
		base.CancelButton = button_0;
		base.ClientSize = new Size(694, 618);
		base.Controls.Add(button_2);
		base.Controls.Add(textBox_0);
		base.Controls.Add(button_3);
		base.Controls.Add(button_1);
		base.Controls.Add(button_0);
		base.Controls.Add(listViewEx_0);
		base.Controls.Add(numericUpDown_0);
		base.Controls.Add(label_0);
		base.Controls.Add(listBox_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.ItemsWindow_Icon;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648978818);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648978844);
		base.FormClosing += ItemsWindow_FormClosing;
		base.Load += ItemsWindow_Load;
		base.Shown += ItemsWindow_Shown;
		((ISupportInitialize)numericUpDown_0).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
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
		int[] array = null;
		if (listViewEx_0.SelectedIndices.Count > 0)
		{
			int num = method_3();
			if (bUseMapping)
			{
				array = new int[listViewEx_0.SelectedIndices.Count];
				if (num != int_2)
				{
					itemlist = num;
					itemindex = listViewEx_0.SelectedIndices[0];
					int num2 = 0;
					if (0 < (nint)array.LongLength)
					{
						do
						{
							int num3 = listViewEx_0.SelectedIndices[num2];
							array[num2] = eLC.getid(num, num3);
							num2++;
						}
						while (num2 < (nint)array.LongLength);
					}
				}
				else
				{
					List<ITEMINFO> shortcuts = Shortcuts;
					itemlist = shortcuts[listViewEx_0.SelectedIndices[0]].pos.int_0;
					List<ITEMINFO> shortcuts2 = Shortcuts;
					itemindex = shortcuts2[listViewEx_0.SelectedIndices[0]].pos.int_1;
					int num4 = 0;
					if (0 < (nint)array.LongLength)
					{
						do
						{
							int id = Shortcuts[listViewEx_0.SelectedIndices[num4]].id;
							array[num4] = id;
							num4++;
						}
						while (num4 < (nint)array.LongLength);
					}
				}
			}
			else
			{
				CommonStorage.sarr1 = new string[listViewEx_0.SelectedIndices.Count];
				List<int> list = new List<int>();
				if (num != int_2)
				{
					itemlist = num;
					itemindex = listViewEx_0.SelectedIndices[0];
					int num5 = 0;
					if (0 < (nint)CommonStorage.sarr1.LongLength)
					{
						do
						{
							int num6 = listViewEx_0.SelectedIndices[num5];
							string itemID = eLC.GetItemID(num, num6);
							CommonStorage.sarr1[num5] = itemID;
							num5++;
						}
						while (num5 < (nint)CommonStorage.sarr1.LongLength);
					}
					list.Add(num);
				}
				else
				{
					List<ITEMINFO> shortcuts3 = Shortcuts;
					itemlist = shortcuts3[listViewEx_0.SelectedIndices[0]].pos.int_0;
					List<ITEMINFO> shortcuts4 = Shortcuts;
					itemindex = shortcuts4[listViewEx_0.SelectedIndices[0]].pos.int_1;
					int num7 = 0;
					if (0 < (nint)CommonStorage.sarr1.LongLength)
					{
						do
						{
							string iD = Shortcuts[listViewEx_0.SelectedIndices[num7]].ID;
							CommonStorage.sarr1[num7] = iD;
							int item = Shortcuts[listViewEx_0.SelectedIndices[num7]].pos.int_0;
							if (!list.Contains(item))
							{
								list.Add(item);
							}
							num7++;
						}
						while (num7 < (nint)CommonStorage.sarr1.LongLength);
					}
				}
				CommonStorage.sData = CommonStorage.sarr1[0];
				CommonStorage.iarr1 = list.ToArray();
			}
			iResult = eLC.getid(itemlist, itemindex);
		}
		IntPtr intPtr = ((!(CallbackHandle != IntPtr.Zero)) ? OwnerHandle : CallbackHandle);
		if (intPtr != IntPtr.Zero)
		{
			if (MODEL_VIEWER.SKIPreview != null && !MODEL_VIEWER.SKIPreview.IsDisposed)
			{
				MODEL_VIEWER.SKIPreview.Hide();
			}
			if (array != null)
			{
				if (bClassJD)
				{
					int num8 = 0;
					if (0 < (nint)array.LongLength)
					{
						do
						{
							array[num8] = eLC.GetClassIdByClassItem(array[num8]);
							num8++;
						}
						while (num8 < (nint)array.LongLength);
					}
				}
				if (bUseMapping)
				{
					MemoryMappedViewStream memoryMappedViewStream = MemoryMappedFile.CreateOrOpen(Class16.smethod_0(1648978907) + base.Handle, 20012L).CreateViewStream();
					BinaryWriter binaryWriter = new BinaryWriter(memoryMappedViewStream);
					binaryWriter.Write(0);
					binaryWriter.Write(itemlist);
					binaryWriter.Write(array.Length);
					int num9 = 0;
					if (0 < (nint)array.LongLength)
					{
						do
						{
							binaryWriter.Write(array[num9]);
							num9++;
						}
						while (num9 < (nint)array.LongLength);
					}
					binaryWriter.Seek(0, SeekOrigin.Begin);
					binaryWriter.Write(1);
					binaryWriter.Close();
					memoryMappedViewStream.Close();
				}
			}
			if (bClassJD)
			{
				int num10 = iResult;
				if (num10 > 0)
				{
					iResult = eLC.GetClassIdByClassItem(num10);
				}
			}
			ACE.RSGlobal.RSGlobal.SendMessage(intPtr, ACE.RSGlobal.RSGlobal.WM_ACE_SID_ITEMSELECTED, iResult, 0);
			bClassJD = false;
		}
		base.DialogResult = DialogResult.OK;
		Hide();
	}

	private int method_3()
	{
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648978922));
		if (listBox_0.Text == text)
		{
			GC.KeepAlive(this);
			return int_2;
		}
		if (listBox_0.Text.Length > 3 && int.TryParse(listBox_0.Text.Substring(0, 3), out var result))
		{
			GC.KeepAlive(this);
			return result;
		}
		GC.KeepAlive(this);
		return -1;
	}

	private void ItemsWindow_Load(object sender, EventArgs e)
	{
	}

	private void ItemsWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (e.CloseReason == CloseReason.UserClosing)
		{
			Hide();
			if (OwnerHandle != IntPtr.Zero)
			{
				ACE.RSGlobal.RSGlobal.SendMessage(OwnerHandle, ACE.RSGlobal.RSGlobal.WM_ACE_SID_ITEMSELECTED, 0, 0);
			}
			e.Cancel = true;
		}
		Form mainWindowForm = CStorage.MainWindowForm;
		ModelViewer?.SetOwner(mainWindowForm);
		GC.KeepAlive(this);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		Hide();
		if (OwnerHandle != IntPtr.Zero)
		{
			ACE.RSGlobal.RSGlobal.SendMessage(OwnerHandle, ACE.RSGlobal.RSGlobal.WM_ACE_SID_ITEMSELECTED, 0, 0);
		}
		GC.KeepAlive(this);
	}

	private void listViewEx_0_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
	{
		ListViewItem listViewItem = new ListViewItem();
		try
		{
			int num = method_3();
			if (num == -1)
			{
				listViewEx_0.VirtualListSize = 0;
				e.Item = listViewItem;
				return;
			}
			if (num == int_2)
			{
				int num2 = Shortcuts?.Count ?? 0;
				if (listViewEx_0.VirtualListSize != num2)
				{
					listViewEx_0.VirtualListSize = num2;
					e.Item = listViewItem;
				}
				else if (Shortcuts != null && e.ItemIndex >= 0 && e.ItemIndex < Shortcuts.Count)
				{
					List<ITEMINFO> shortcuts = Shortcuts;
					ACE.Elements.eListCollection.eListCollection eListCollection2 = eLC;
					if (eListCollection2 != null && shortcuts[e.ItemIndex] != null)
					{
						e.Item = eListCollection2.CreateListViewItem(shortcuts[e.ItemIndex], NameIsFirst: true) ?? listViewItem;
					}
					else
					{
						e.Item = listViewItem;
					}
				}
				else
				{
					e.Item = listViewItem;
				}
			}
			else
			{
				ACE.Elements.eListCollection.eListCollection eListCollection3 = eLC;
				int num3 = int_1;
				if (eListCollection3 != null && num3 >= 0 && num3 < eListCollection3.ListCount && e.ItemIndex >= 0 && e.ItemIndex < eLC.GetItemsCount(num3))
				{
					int listIndex = num3;
					int itemIndex = e.ItemIndex;
					ACE.Elements.eListCollection.eListCollection eListCollection4 = eLC;
					ITEMINFO itemInfo = eListCollection4.GetItemInfo(new ITEMPOS(listIndex, itemIndex), bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
					ListViewItem item = ((itemInfo != null) ? (eListCollection4.CreateListViewItem(itemInfo, NameIsFirst: true) ?? listViewItem) : listViewItem);
					e.Item = item;
				}
				else
				{
					if (eListCollection3 != null && eListCollection3.ListCount > 0)
					{
						ITEMINFO itemInfo2 = eListCollection3.GetItemInfo(new ITEMPOS(0, 0), bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
						ListViewItem item2 = ((itemInfo2 != null) ? (eListCollection3.CreateListViewItem(itemInfo2, NameIsFirst: true) ?? listViewItem) : listViewItem);
						e.Item = item2;
					}
					else
					{
						e.Item = listViewItem;
					}
					listViewEx_0.Clear();
				}
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648977921));
			e.Item = listViewItem;
		}
		GC.KeepAlive(this);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		int num = listViewEx_0.VirtualListSize - 1;
		if (num < 0)
		{
			GC.KeepAlive(this);
			return;
		}
		method_5();
		listViewEx_0.Items[num].Selected = true;
		listViewEx_0.Items[num].Focused = true;
		listViewEx_0.Items[num].EnsureVisible();
		listViewEx_0.Focus();
		GC.KeepAlive(this);
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		method_9(bool_1: true);
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		method_9(bool_1: false);
	}

	private void textBox_0_Enter(object sender, EventArgs e)
	{
	}

	private void textBox_0_Leave(object sender, EventArgs e)
	{
	}

	private void listViewEx_0_MouseMove(object sender, MouseEventArgs e)
	{
		if (!textBox_0.Focused)
		{
			IntPtr handle = base.Handle;
			if (ACE.RSGlobal.RSGlobal.GetForegroundWindow() == handle && !((Control)sender).Focused)
			{
				((Control)sender).Focus();
			}
		}
		Point mousePosition = Control.MousePosition;
		Point point = listViewEx_0.PointToClient(mousePosition);
		ListViewItem itemAt = listViewEx_0.GetItemAt(point.X, point.Y);
		if (itemAt == null)
		{
			GC.KeepAlive(this);
			return;
		}
		if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)
		{
			itemAt.Selected = true;
		}
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	private bool method_4(int int_3)
	{
		bool result = eLC.GetFieldsCount(int_3) > 2;
		GC.KeepAlive(this);
		return result;
	}

	private void listViewEx_0_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			bool_0 = false;
		}
		if (e.Button == MouseButtons.Right)
		{
			if (!bool_0)
			{
				int[] array = new int[listViewEx_0.SelectedIndices.Count];
				listViewEx_0.SelectedIndices.CopyTo(array, 0);
				int num = 0;
				if (0 < (nint)array.LongLength)
				{
					do
					{
						int index = array[num];
						listViewEx_0.Items[index].Selected = false;
						num++;
					}
					while (num < (nint)array.LongLength);
				}
				bool_0 = true;
			}
			ListViewItem itemAt = listViewEx_0.GetItemAt(e.X, e.Y);
			if (itemAt == null)
			{
				GC.KeepAlive(this);
				return;
			}
			itemAt.Selected = true;
		}
		GC.KeepAlive(this);
	}

	private void method_5()
	{
		listViewEx_0.VirtualListSize = 0;
		int num = int_1;
		int virtualListSize = ((num > -1) ? eLC.GetItemsCount(num) : (Shortcuts?.Count ?? 0));
		listViewEx_0.VirtualListSize = virtualListSize;
		GC.KeepAlive(this);
	}

	private void listBox_0_MouseMove(object sender, MouseEventArgs e)
	{
	}

	private void listViewEx_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (listViewEx_0.SelectedIndices.Count != 0 && listViewEx_0.SelectedIndices[0] > -1)
		{
			object[] vars = new object[3]
			{
				listViewEx_0.SelectedIndices[0],
				listViewEx_0.SelectedIndices.Count,
				listViewEx_0.VirtualListSize
			};
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648978629), vars);
			columnHeader_1.Text = text;
			if (CommonStorage.License.Special.ModelPreview && CommonStorage.Params.ShowModelPreview)
			{
				ModelViewer.ShowModelPreview(method_6());
			}
		}
		else
		{
			object[] vars2 = new object[3] { 0, 0, 0 };
			string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648978629), vars2);
			columnHeader_1.Text = text2;
		}
		byte b = ((listViewEx_0.SelectedIndices.Count > 0) ? ((byte)1) : ((byte)0));
		button_3.Enabled = b != 0;
		GC.KeepAlive(this);
	}

	private ITEMPOS method_6()
	{
		ITEMPOS iTEMPOS = null;
		if (listViewEx_0.SelectedIndices.Count != 0 && listViewEx_0.SelectedIndices[0] > -1)
		{
			int num = method_3();
			int itemIndex;
			if (num != int_2)
			{
				itemIndex = listViewEx_0.SelectedIndices[0];
			}
			else
			{
				if (Shortcuts == null || listViewEx_0.SelectedIndices[0] >= Shortcuts.Count || Shortcuts[listViewEx_0.SelectedIndices[0]]?.pos == null)
				{
					GC.KeepAlive(this);
					return null;
				}
				num = Shortcuts[listViewEx_0.SelectedIndices[0]].pos.int_0;
				itemIndex = Shortcuts[listViewEx_0.SelectedIndices[0]].pos.int_1;
			}
			iTEMPOS = new ITEMPOS(num, itemIndex);
			if (!eLC.IsItemExist(iTEMPOS))
			{
				iTEMPOS = null;
			}
		}
		GC.KeepAlive(this);
		return iTEMPOS;
	}

	private void listViewEx_0_VirtualItemsSelectionRangeChanged(object sender, ListViewVirtualItemsSelectionRangeChangedEventArgs e)
	{
		if (listViewEx_0.SelectedIndices.Count != 0 && listViewEx_0.SelectedIndices[0] > -1)
		{
			object[] vars = new object[3]
			{
				listViewEx_0.SelectedIndices[0],
				listViewEx_0.SelectedIndices.Count,
				listViewEx_0.VirtualListSize
			};
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648978629), vars);
			columnHeader_1.Text = text;
			if (CommonStorage.License.Special.ModelPreview && CommonStorage.Params.ShowModelPreview)
			{
				ModelViewer.ShowModelPreview(method_6());
			}
			button_3.Enabled = true;
		}
		GC.KeepAlive(this);
	}

	protected override void WndProc(ref Message message_0)
	{
		if (IsShared && (message_0.Msg == ACE.RSGlobal.RSGlobal.WM_ACE_SID_SHOW_BYID || message_0.Msg == ACE.RSGlobal.RSGlobal.WM_ACE_SID_SHOW_BYID_MULTI))
		{
			if (message_0.Msg == ACE.RSGlobal.RSGlobal.WM_ACE_SID_SHOW_BYID_MULTI)
			{
				bUseMapping = true;
			}
			ItemType itemType = (ItemType)(int)message_0.WParam;
			int num = (int)message_0.LParam;
			if (itemType == ItemType.EXTRA_CLASS_JD)
			{
				bClassJD = true;
				itemType = ItemType.JD_CHARACTER_CLASS_CONFIG;
				num = eLC.GetClassItemIdByClassId(num);
			}
			ACE.Elements.eListCollection.eListCollection eListCollection2 = eLC;
			ITEMPOS iTEMPOS = eListCollection2.FindItemPos(eListCollection2.GetLists(itemType), num);
			if (iTEMPOS != null)
			{
				newitemlist = iTEMPOS.int_0;
				newitemindex = iTEMPOS.int_1;
			}
			else
			{
				newitemlist = -1;
				newitemindex = -1;
			}
			if ((newlistsindices = ACE.RSGlobal.RSGlobal.CloneArray(eLC.GetLists(itemType)))[0] >= eLC.ListCount)
			{
				IntPtr result = (IntPtr)(-1);
				message_0.Result = result;
				GC.KeepAlive(this);
				return;
			}
			int num2 = ((message_0.Msg == ACE.RSGlobal.RSGlobal.WM_ACE_SID_SHOW_BYID_MULTI) ? 1 : 0);
			bMultiSelect = (byte)num2 != 0;
			ACE.RSGlobal.RSGlobal.ShowWindow(this);
			if (ACE.RSGlobal.RSGlobal.bShown_WndProc_ItemsWindow)
			{
				method_7();
			}
			ACE.RSGlobal.RSGlobal.bShown_WndProc_ItemsWindow = true;
			IntPtr result2 = (IntPtr)1;
			message_0.Result = result2;
		}
		else if (IsShared && message_0.Msg == ACE.RSGlobal.RSGlobal.WM_ACE_SID_SHOW_BYLIST)
		{
			int num3 = (int)message_0.WParam;
			int id = (int)message_0.LParam;
			ACE.Elements.eListCollection.eListCollection eListCollection3 = eLC;
			if (num3 >= eListCollection3.ListCount)
			{
				IntPtr result3 = (IntPtr)(-1);
				message_0.Result = result3;
				GC.KeepAlive(this);
				return;
			}
			ITEMPOS iTEMPOS2 = null;
			int num4 = eListCollection3.FindItemIndexByID(num3, id);
			if (num4 > -1)
			{
				iTEMPOS2 = new ITEMPOS(num3, num4);
			}
			if (iTEMPOS2 != null)
			{
				newitemlist = iTEMPOS2.int_0;
				newitemindex = iTEMPOS2.int_1;
			}
			else
			{
				newitemlist = -1;
				newitemindex = -1;
			}
			newlistsindices = new int[1] { num3 };
			bMultiSelect = false;
			ACE.RSGlobal.RSGlobal.ShowWindow(this);
			if (ACE.RSGlobal.RSGlobal.bShown_WndProc_ItemsWindow)
			{
				method_7();
			}
			ACE.RSGlobal.RSGlobal.bShown_WndProc_ItemsWindow = true;
			IntPtr result4 = (IntPtr)1;
			message_0.Result = result4;
		}
		else
		{
			base.WndProc(ref message_0);
		}
	}

	private void method_7()
	{
		listViewEx_0.MultiSelect = bMultiSelect;
		int[] array = method_8();
		if (newlistsindices == null || !ACE.RSGlobal.RSGlobal.IsArraysEquals(newlistsindices, array))
		{
			newlistsindices = array;
		}
		int[] array2 = int_0;
		if (array2 == null || !ACE.RSGlobal.RSGlobal.IsArraysEquals(array2, array))
		{
			itemlist = -1;
			int_0 = ACE.RSGlobal.RSGlobal.CloneArray(array);
			listViewEx_0.VirtualListSize = 0;
			listBox_0.Items.Clear();
			if (array.Length > 2)
			{
				string item = TextStorage.TEXTS.GetText(Class16.smethod_0(1648978922));
				listBox_0.Items.Add(item);
			}
			int[] array3 = int_0;
			int num = 0;
			if (0 < (nint)array3.LongLength)
			{
				do
				{
					int num2 = array3[num];
					ACE.Elements.eList.eList eList2 = eLC.Lists[num2];
					string text = ((!ACE.RSGlobal.RSGlobal.SHOW_UNIVERSAL_NAMES) ? eList2.ListName : eList2.uListName);
					string text2 = num2.ToString(Class16.smethod_0(1648902328));
					listBox_0.Items.Add(string.Concat(text2 + Class16.smethod_0(1648908709), text));
					num++;
				}
				while (num < (nint)array3.LongLength);
			}
		}
		if (array.Length == 0 && (Shortcuts == null || Shortcuts.Count == 0))
		{
			itemlist = -1;
			itemindex = -1;
			listViewEx_0.VirtualListSize = 0;
			GC.KeepAlive(this);
			return;
		}
		int num3 = newitemlist;
		if (num3 > -1 && itemlist != num3)
		{
			itemlist = num3;
			itemindex = -1;
			newitemlist = -1;
		}
		int num4 = newitemindex;
		if (num4 > -1)
		{
			itemindex = num4;
			newitemindex = -1;
		}
		int num5 = -1;
		List<ITEMINFO> shortcuts = Shortcuts;
		if (shortcuts != null && shortcuts.Count != 0)
		{
			for (int i = 0; i < shortcuts.Count; i++)
			{
				ITEMPOS iTEMPOS = shortcuts[i]?.pos;
				if (iTEMPOS != null && iTEMPOS.int_0 == itemlist && iTEMPOS.int_1 == itemindex)
				{
					num5 = i;
					break;
				}
			}
		}
		if (num5 > -1)
		{
			if (listBox_0.Items.Count > 0 && listBox_0.SelectedIndex != 0)
			{
				listBox_0.SelectedIndex = 0;
			}
		}
		else if (itemlist > -1)
		{
			bool flag = false;
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j] == itemlist)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				selectlist(itemlist);
				int itemsCount = eLC.GetItemsCount(itemlist);
				if (itemsCount <= 0)
				{
					itemindex = -1;
				}
				else if (itemindex >= itemsCount)
				{
					itemindex = 0;
				}
			}
			else
			{
				itemlist = -1;
				itemindex = -1;
			}
		}
		if (listBox_0.SelectedIndex == -1 && listBox_0.Items.Count > 0)
		{
			listBox_0.SelectedIndex = 0;
		}
		int num6 = method_3();
		if (num6 == int_2)
		{
			int num7 = Shortcuts?.Count ?? 0;
			if (num7 == 0)
			{
				listViewEx_0.VirtualListSize = 0;
				GC.KeepAlive(this);
				return;
			}
			if (num7 != listViewEx_0.VirtualListSize)
			{
				listViewEx_0.VirtualListSize = num7;
			}
			else
			{
				listViewEx_0.Refresh();
			}
			if (num5 > -1 && num5 < listViewEx_0.VirtualListSize)
			{
				listViewEx_0.Focus();
				listViewEx_0.Items[num5].Selected = true;
				listViewEx_0.Items[num5].EnsureVisible();
			}
			GC.KeepAlive(this);
		}
		else
		{
			int num8 = ((num6 >= 0 && num6 < eLC.ListCount) ? eLC.GetItemsCount(num6) : 0);
			if (num8 != listViewEx_0.VirtualListSize)
			{
				listViewEx_0.VirtualListSize = num8;
			}
			else
			{
				listViewEx_0.Refresh();
			}
			if (itemindex > -1 && num6 == itemlist && itemindex < listViewEx_0.VirtualListSize)
			{
				listViewEx_0.Items[itemindex].Selected = true;
				listViewEx_0.Items[itemindex].EnsureVisible();
			}
			listViewEx_0.Focus();
			GC.KeepAlive(this);
		}
	}

	private int[] method_8()
	{
		if (newlistsindices != null && newlistsindices.Length != 0 && eLC != null)
		{
			List<int> list = new List<int>(newlistsindices.Length);
			HashSet<int> hashSet = new HashSet<int>();
			int num = 0;
			if (0 < (nint)newlistsindices.LongLength)
			{
				do
				{
					int num2 = newlistsindices[num];
					if (num2 >= 0 && num2 < eLC.ListCount && hashSet.Add(num2))
					{
						list.Add(num2);
					}
					num++;
				}
				while (num < (nint)newlistsindices.LongLength);
			}
			list.Sort();
			return list.ToArray();
		}
		return Array.Empty<int>();
	}

	private void ItemsWindow_Shown(object sender, EventArgs e)
	{
		if (int_1 >= eLC.ListCount)
		{
			int_1 = -1;
		}
		ModelViewer.SetOwner(this);
		method_7();
	}

	private void listViewEx_0_MouseHover(object sender, EventArgs e)
	{
	}

	private void listViewEx_0_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
	{
		if (!textBox_0.Focused)
		{
			IntPtr handle = base.Handle;
			if (ACE.RSGlobal.RSGlobal.GetForegroundWindow() == handle && !((Control)sender).Focused)
			{
				((Control)sender).Focus();
			}
		}
		if (e.Item == null)
		{
			GC.KeepAlive(this);
			return;
		}
		int num = method_3();
		int index = e.Item.Index;
		ITEMPOS itemPos = ((num == int_2) ? Shortcuts[index].pos : new ITEMPOS(num, index));
		if (HINTS.ToolTipWindow != null)
		{
			HINTS.ShowElementToolTip(((Control)sender).Handle, itemPos, IsShopPrice: false, bUnlimited: false, null);
		}
		GC.KeepAlive(this);
	}

	public void SetIcons(ICONS icons)
	{
		if (icons?.imageList != null)
		{
			listViewEx_0.SmallImageList = icons.imageList;
		}
		GC.KeepAlive(this);
	}

	private void method_9([MarshalAs(UnmanagedType.U1)] bool bool_1)
	{
		string text = textBox_0.Text.ToLowerInvariant();
		if (text == string.Empty)
		{
			GC.KeepAlive(this);
		}
		else if (int_0 != null && eLC != null)
		{
			int result = 0;
			int.TryParse(text, out result);
			if (bool_1)
			{
				List<ITEMINFO> shortcuts = Shortcuts;
				if (shortcuts != null && shortcuts.Count != 0 && (nint)int_0.LongLength > 2)
				{
					int num = 0;
					if (0 < Shortcuts.Count)
					{
						do
						{
							if (result > 0)
							{
								if (Shortcuts[num].id == result)
								{
									listBox_0.SelectedIndex = 0;
									method_5();
									listViewEx_0.Items[num].Selected = true;
									listViewEx_0.Items[num].EnsureVisible();
									Color backColor = Color.FromArgb(220, 255, 255);
									textBox_0.BackColor = backColor;
									return;
								}
							}
							else if (ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(Shortcuts[num].name, text))
							{
								listBox_0.SelectedIndex = 0;
								method_5();
								listViewEx_0.Items[num].Selected = true;
								listViewEx_0.Items[num].EnsureVisible();
								Color backColor2 = Color.FromArgb(220, 255, 255);
								textBox_0.BackColor = backColor2;
								return;
							}
							num++;
						}
						while (num < Shortcuts.Count);
					}
				}
			}
			int num2 = 0;
			int num3 = 0;
			if (!bool_1)
			{
				num2 = listBox_0.SelectedIndex;
				if ((nint)int_0.LongLength > 2)
				{
					num2--;
				}
				num2 = ((num2 >= 0) ? num2 : 0);
				if (listViewEx_0.SelectedIndices.Count != 0)
				{
					num3 = listViewEx_0.SelectedIndices[0];
				}
				num3++;
			}
			int num4 = num2;
			int[] array = int_0;
			if (num2 < (nint)array.LongLength)
			{
				do
				{
					int int_ = array[num4];
					int num5 = num3;
					if (num3 < eLC.GetItemsCount(int_))
					{
						do
						{
							if (result > 0)
							{
								if (eLC.getid(int_, num5) == result)
								{
									selectlist(int_);
									method_5();
									listViewEx_0.Items[num5].Selected = true;
									listViewEx_0.Items[num5].EnsureVisible();
									Color backColor3 = Color.FromArgb(220, 255, 255);
									textBox_0.BackColor = backColor3;
									GC.KeepAlive(this);
									return;
								}
							}
							else if (ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(eLC.GetRealItemName(int_, num5), text))
							{
								selectlist(int_);
								method_5();
								listViewEx_0.Items[num5].Selected = true;
								listViewEx_0.Items[num5].EnsureVisible();
								Color backColor4 = Color.FromArgb(220, 255, 255);
								textBox_0.BackColor = backColor4;
								GC.KeepAlive(this);
								return;
							}
							num5++;
						}
						while (num5 < eLC.GetItemsCount(int_));
					}
					num3 = 0;
					num4++;
					array = int_0;
				}
				while (num4 < (nint)array.LongLength);
			}
			if (!bool_1)
			{
				method_9(bool_1: true);
				return;
			}
			Color backColor5 = Color.FromArgb(255, 100, 100);
			textBox_0.BackColor = backColor5;
			GC.KeepAlive(this);
		}
		else
		{
			GC.KeepAlive(this);
		}
	}
}
