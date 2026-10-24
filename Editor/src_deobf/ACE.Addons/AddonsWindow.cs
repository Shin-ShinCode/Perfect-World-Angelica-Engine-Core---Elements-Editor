using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eList;
using ACE.Elements.eListCollection;
using ACE.Models;
using ACE.Properties;
using ACE.RSGlobal;
using ACE.sTASKedit.Classes;

namespace ACE.Addons;

public class AddonsWindow : Form
{
	private bool bool_0;

	private eListCollection eListCollection_0;

	private CommonStorage commonStorage_0;

	private PARTINFO[] partinfo_0;

	private PARTINFO partinfo_1;

	private int int_0;

	private int int_1;

	private List<AddonsParts> list_0;

	private List<AddonsParts> list_1;

	private AddonsParts addonsParts_0;

	private AddonsParts addonsParts_1;

	private List<int> list_2 = new List<int>();

	private int int_2;

	private List<AddonsParts> list_3;

	private HashSet<int> hashSet_0;

	public int addons_l;

	private Button button_0;

	private Button button_1;

	private TextBox textBox_0;

	private ToolTip toolTip_0;

	private ListBox listBox_0;

	private Label label_0;

	private Button button_2;

	private NumericUpDown numericUpDown_0;

	private ListViewEx listViewEx_0;

	private ColumnHeader columnHeader_0;

	private ColumnHeader columnHeader_1;

	private IContainer icontainer_0;

	public AddonsWindow(int currentlist, string currentid, string typeofaddon, eListCollection ref_eLC, CommonStorage ref_CStorage)
	{
		try
		{
			method_1();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			commonStorage_0 = ref_CStorage;
			eListCollection_0 = ref_eLC;
			int_2 = currentlist;
			bool flag = false;
			TextStorage.TEXTS.SetFormLanguage(this, null);
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648919885));
			columnHeader_1.Text = text;
			int_0 = 0;
			int_1 = 0;
			eListCollection eListCollection2 = eListCollection_0;
			int num = eListCollection2.addons_l;
			partinfo_0 = new PARTINFO[1];
			if (CommonStorage.Params.UseAddonsFilter)
			{
				int num2 = int_2;
				if (num2 > 0)
				{
					AddonsCollection addons = eListCollection2.Addons;
					if (addons != null)
					{
						Dictionary<int, List<AddonsParts>> fEquipAddons = addons.fEquipAddons;
						if (fEquipAddons != null && fEquipAddons.TryGetValue(num2, out list_3))
						{
							hashSet_0 = new HashSet<int>();
							List<AddonsParts>.Enumerator enumerator = list_3.GetEnumerator();
							if (enumerator.MoveNext())
							{
								do
								{
									AddonsParts current = enumerator.Current;
									hashSet_0.UnionWith(current.IdsHashes);
								}
								while (enumerator.MoveNext());
							}
						}
					}
				}
			}
			eListCollection eListCollection3 = eListCollection_0;
			if (eListCollection3.Game == GAMES.PW)
			{
				addonsParts_1 = eListCollection3.Addons.OtherAddons;
				if (eListCollection3.Params.UseAddonsFilter && eListCollection3.Addons.fEquipAddons.ContainsKey(currentlist))
				{
					list_1 = eListCollection_0.Addons.fEquipAddons[currentlist];
				}
				else
				{
					list_1 = eListCollection_0.Addons.EquipAddons;
				}
				if (currentlist == 3 || currentlist == 6 || currentlist == 9)
				{
					if (eListCollection_0.Addons.fRefineAddons.ContainsKey(currentlist))
					{
						list_0 = eListCollection_0.Addons.fRefineAddons[currentlist];
					}
					else
					{
						list_0 = null;
					}
				}
				addonsParts_0 = eListCollection_0.Addons.Abilities;
				if (typeofaddon == Class16.smethod_0(1648922963))
				{
					if (list_0 == null)
					{
						DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648919908), Class16.smethod_0(1648919939)), string.Empty);
						GC.KeepAlive(this);
						return;
					}
					string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648919990));
					Text = text2;
					int num3 = list_0.Count + 1;
					partinfo_0 = new PARTINFO[num3];
					int num4 = 0;
					if (0 < list_0.Count)
					{
						do
						{
							string caption = list_0[num4].Caption;
							listBox_0.Items.Add(caption);
							partinfo_0[num4] = new PARTINFO();
							partinfo_0[num4].index = num4;
							partinfo_0[num4].type = PARTTYPE.RefineAddon;
							int num5 = 0;
							if (0 < (nint)list_0[num4].IDs.LongLength)
							{
								while (!(currentid == Class16.smethod_0(1648924112)) && !flag)
								{
									if (!(list_0[num4].IDs[num5] == currentid))
									{
										num5++;
										if (num5 >= (nint)list_0[num4].IDs.LongLength)
										{
											break;
										}
										continue;
									}
									int_0 = num4;
									int_1 = num5;
									flag = true;
									break;
								}
							}
							num4++;
						}
						while (num4 < list_0.Count);
					}
				}
				else if (typeofaddon == Class16.smethod_0(1648919556))
				{
					List<AddonsParts> list = list_1;
					if (list == null)
					{
						DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648920013), Class16.smethod_0(1648920040)), string.Empty);
						GC.KeepAlive(this);
						return;
					}
					int num6 = list.Count + 1;
					partinfo_0 = new PARTINFO[num6];
					int num7 = 0;
					if (0 < list_1.Count)
					{
						do
						{
							string caption2 = list_1[num7].Caption;
							listBox_0.Items.Add(caption2);
							partinfo_0[num7] = new PARTINFO();
							partinfo_0[num7].index = num7;
							partinfo_0[num7].type = PARTTYPE.EquipAddon;
							int num8 = 0;
							if (0 < (nint)list_1[num7].IDs.LongLength)
							{
								while (!(currentid == Class16.smethod_0(1648924112)) && !flag)
								{
									if (!(list_1[num7].IDs[num8] == currentid))
									{
										num8++;
										if (num8 >= (nint)list_1[num7].IDs.LongLength)
										{
											break;
										}
										continue;
									}
									int_0 = num7;
									int_1 = num8;
									flag = true;
									break;
								}
							}
							num7++;
						}
						while (num7 < list_1.Count);
					}
					if (addonsParts_0 == null)
					{
						DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648919053), Class16.smethod_0(1648919083)), string.Empty);
						GC.KeepAlive(this);
						return;
					}
					Array.Resize(ref partinfo_0, (int)((nint)partinfo_0.LongLength + 1));
					string caption3 = addonsParts_0.Caption;
					listBox_0.Items.Add(caption3);
					PARTINFO[] array = partinfo_0;
					int num9 = (int)((nint)array.LongLength - 2);
					array[num9] = new PARTINFO();
					PARTINFO[] array2 = partinfo_0;
					array2[(nint)array2.LongLength - 2].type = PARTTYPE.Ability;
					if (flag)
					{
						return;
					}
					int num10 = 0;
					if (0 < (nint)addonsParts_0.IDs.LongLength)
					{
						while (!(currentid == Class16.smethod_0(1648924112)))
						{
							if (!(addonsParts_0.IDs[num10] == currentid))
							{
								num10++;
								if (num10 >= (nint)addonsParts_0.IDs.LongLength)
								{
									break;
								}
								continue;
							}
							int_0 = listBox_0.Items.Count - 1;
							int_1 = num10;
							flag = true;
							break;
						}
					}
				}
			}
			if (!(typeofaddon != Class16.smethod_0(1648922963)))
			{
				return;
			}
			eList eList2 = eListCollection_0.Lists[num];
			string item = ((!ACE.RSGlobal.RSGlobal.SHOW_UNIVERSAL_NAMES) ? eList2.ListName : eList2.uListName);
			listBox_0.Items.Add(item);
			PARTINFO[] array3 = partinfo_0;
			int num11 = (int)((nint)array3.LongLength - 1);
			array3[num11] = new PARTINFO(PARTTYPE.ItemID, 0);
			if (flag)
			{
				return;
			}
			int num12 = ACE.RSGlobal.RSGlobal.UIntParseFast(currentid);
			int num13 = 0;
			eList eList3 = eListCollection_0.Lists[num];
			if (0 >= eList3.ItemCount)
			{
				return;
			}
			while (num12 > 0)
			{
				if (eListCollection_0.getid(num, num13) != num12)
				{
					num13++;
					eList eList4 = eListCollection_0.Lists[num];
					if (num13 >= eList4.ItemCount)
					{
						break;
					}
					continue;
				}
				int_0 = listBox_0.Items.Count - 1;
				int_1 = num13;
				break;
			}
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void method_0()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_1()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(AddonsWindow));
		ListViewGroup listViewGroup = new ListViewGroup(Class16.smethod_0(1648919115), HorizontalAlignment.Left);
		ListViewGroup listViewGroup2 = new ListViewGroup(Class16.smethod_0(1648919141), HorizontalAlignment.Left);
		ListViewGroup listViewGroup3 = new ListViewGroup(Class16.smethod_0(1648919157), HorizontalAlignment.Left);
		ListViewGroup listViewGroup4 = new ListViewGroup(Class16.smethod_0(1648919169), HorizontalAlignment.Left);
		ListViewGroup listViewGroup5 = new ListViewGroup(Class16.smethod_0(1648919196), HorizontalAlignment.Left);
		listBox_0 = new ListBox();
		label_0 = new Label();
		button_2 = new Button();
		numericUpDown_0 = new NumericUpDown();
		listViewEx_0 = new ListViewEx();
		columnHeader_1 = new ColumnHeader();
		columnHeader_0 = new ColumnHeader();
		toolTip_0 = new ToolTip(icontainer_0);
		button_0 = new Button();
		button_1 = new Button();
		textBox_0 = new TextBox();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		SuspendLayout();
		listBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		listBox_0.BackColor = Color.FromArgb(32, 32, 32);
		listBox_0.Font = new Font(Class16.smethod_0(1648942905), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		listBox_0.ForeColor = Color.Gold;
		listBox_0.FormattingEnabled = true;
		listBox_0.IntegralHeight = false;
		listBox_0.ItemHeight = 20;
		listBox_0.Location = new Point(3, 4);
		listBox_0.Margin = new Padding(3, 4, 3, 4);
		listBox_0.Name = Class16.smethod_0(1648919218);
		listBox_0.Size = new Size(276, 531);
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
		button_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		button_2.AutoSize = true;
		button_2.DialogResult = DialogResult.OK;
		button_2.Font = new Font(Class16.smethod_0(1648942905), 12f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_2.Image = Resources.AddonsWindow_cmdok;
		button_2.ImageAlign = ContentAlignment.MiddleRight;
		button_2.Location = new Point(3, 539);
		button_2.Name = Class16.smethod_0(1648925748);
		button_2.Size = new Size(421, 41);
		button_2.TabIndex = 1;
		button_2.TabStop = false;
		button_2.Text = Class16.smethod_0(1648919277);
		button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
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
		listViewEx_0.Font = new Font(Class16.smethod_0(1648942905), 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
		listViewEx_0.ForeColor = Color.FromArgb(114, 114, 240);
		listViewEx_0.FullRowSelect = true;
		listViewGroup.Header = Class16.smethod_0(1648919115);
		listViewGroup.Name = Class16.smethod_0(1648919290);
		listViewGroup2.Header = Class16.smethod_0(1648919141);
		listViewGroup2.Name = Class16.smethod_0(1648919306);
		listViewGroup3.Header = Class16.smethod_0(1648919157);
		listViewGroup3.Name = Class16.smethod_0(1648919321);
		listViewGroup4.Header = Class16.smethod_0(1648919169);
		listViewGroup4.Name = Class16.smethod_0(1648919339);
		listViewGroup5.Header = Class16.smethod_0(1648919196);
		listViewGroup5.Name = Class16.smethod_0(1648919367);
		listViewEx_0.Groups.AddRange(new ListViewGroup[5] { listViewGroup, listViewGroup2, listViewGroup3, listViewGroup4, listViewGroup5 });
		listViewEx_0.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		listViewEx_0.HideSelection = false;
		listViewEx_0.LabelWrap = false;
		listViewEx_0.Location = new Point(285, 32);
		listViewEx_0.MultiSelect = false;
		listViewEx_0.Name = Class16.smethod_0(1648922824);
		listViewEx_0.ShowItemToolTips = true;
		listViewEx_0.Size = new Size(577, 503);
		listViewEx_0.TabIndex = 0;
		listViewEx_0.Tag = Class16.smethod_0(1648919381);
		toolTip_0.SetToolTip(listViewEx_0, Class16.smethod_0(1648919390));
		listViewEx_0.UseCompatibleStateImageBehavior = false;
		listViewEx_0.View = View.Details;
		listViewEx_0.VirtualMode = true;
		listViewEx_0.RetrieveVirtualItem += listViewEx_0_RetrieveVirtualItem;
		listViewEx_0.DoubleClick += listViewEx_0_DoubleClick;
		listViewEx_0.Enter += listViewEx_0_Enter;
		listViewEx_0.MouseMove += listViewEx_0_MouseMove;
		columnHeader_1.Text = Class16.smethod_0(1648919420);
		columnHeader_1.Width = 493;
		columnHeader_0.Text = Class16.smethod_0(1648941057);
		columnHeader_0.TextAlign = HorizontalAlignment.Center;
		columnHeader_0.Width = 57;
		toolTip_0.AutomaticDelay = 1500;
		toolTip_0.AutoPopDelay = 1500;
		toolTip_0.InitialDelay = 1500;
		toolTip_0.ReshowDelay = 1000;
		button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		button_0.AutoSize = true;
		button_0.DialogResult = DialogResult.Cancel;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 12f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.AddonsWindow_cmdcancel;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(430, 539);
		button_0.Name = Class16.smethod_0(1648925752);
		button_0.Size = new Size(432, 41);
		button_0.TabIndex = 6;
		button_0.TabStop = false;
		button_0.Text = Class16.smethod_0(1648919424);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_1.Image = Resources.cmdFind;
		button_1.Location = new Point(832, 4);
		button_1.Name = Class16.smethod_0(1648919443);
		button_1.Size = new Size(30, 23);
		button_1.TabIndex = 14;
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_0.BackColor = Color.White;
		textBox_0.Location = new Point(285, 4);
		textBox_0.Name = Class16.smethod_0(1648919457);
		textBox_0.Size = new Size(541, 22);
		textBox_0.TabIndex = 13;
		textBox_0.TextAlign = HorizontalAlignment.Center;
		textBox_0.TextChanged += textBox_0_TextChanged;
		textBox_0.Enter += textBox_0_Enter;
		base.AcceptButton = button_2;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		AutoSize = true;
		BackColor = Color.FromArgb(239, 244, 250);
		base.CancelButton = button_0;
		base.ClientSize = new Size(865, 584);
		base.Controls.Add(button_1);
		base.Controls.Add(textBox_0);
		base.Controls.Add(button_2);
		base.Controls.Add(button_0);
		base.Controls.Add(listViewEx_0);
		base.Controls.Add(numericUpDown_0);
		base.Controls.Add(label_0);
		base.Controls.Add(listBox_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.AddonsWindow_Icon;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648919479);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648919490);
		base.Load += AddonsWindow_Load;
		base.Shown += AddonsWindow_Shown;
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

	private void button_2_Click(object sender, EventArgs e)
	{
		method_2();
	}

	private void listBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			PARTINFO pARTINFO = (partinfo_1 = partinfo_0[listBox_0.SelectedIndex]);
			int num = 0;
			switch (pARTINFO.type)
			{
			case PARTTYPE.RefineAddon:
				num = list_0[pARTINFO.index].IDs.Length;
				break;
			case PARTTYPE.EquipAddon:
				num = list_1[pARTINFO.index].IDs.Length;
				break;
			case PARTTYPE.Ability:
				num = addonsParts_0.IDs.Length;
				break;
			case PARTTYPE.ItemID:
				num = eListCollection_0.Lists[addons_l].ItemCount;
				break;
			}
			if (listViewEx_0.VirtualListSize != num)
			{
				listViewEx_0.VirtualListSize = num;
			}
			else
			{
				listViewEx_0.Refresh();
			}
			if (listViewEx_0.VirtualListSize > 0)
			{
				listViewEx_0.Items[0].EnsureVisible();
			}
			GC.KeepAlive(this);
		}
	}

	private void listViewEx_0_DoubleClick(object sender, EventArgs e)
	{
		method_2();
	}

	private void method_2()
	{
		if (listViewEx_0.SelectedIndices.Count > 0)
		{
			int num = listViewEx_0.SelectedIndices[0];
			string sData = null;
			PARTINFO pARTINFO = partinfo_1;
			switch (pARTINFO.type)
			{
			case PARTTYPE.RefineAddon:
				sData = list_0[pARTINFO.index].IDs[num];
				break;
			case PARTTYPE.EquipAddon:
				sData = list_1[pARTINFO.index].IDs[num];
				break;
			case PARTTYPE.Ability:
				sData = addonsParts_0.IDs[num];
				break;
			case PARTTYPE.ItemID:
				sData = eListCollection_0.GetItemID(addons_l, num);
				break;
			case PARTTYPE.ItemIndex:
			{
				int num2 = list_2[num];
				sData = eListCollection_0.GetItemID(addons_l, num2);
				break;
			}
			}
			base.DialogResult = DialogResult.OK;
			CommonStorage.sData = sData;
		}
		base.Visible = false;
	}

	private void AddonsWindow_Load(object sender, EventArgs e)
	{
		if (listBox_0.Items.Count == 0)
		{
			Close();
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void listViewEx_0_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
	{
		if (e != null && e.ItemIndex >= 0)
		{
			int itemIndex = e.ItemIndex;
			string text = null;
			PARTINFO pARTINFO = partinfo_1;
			try
			{
				switch (pARTINFO.type)
				{
				case PARTTYPE.RefineAddon:
					if (list_0 != null && pARTINFO.index >= 0 && pARTINFO.index < list_0.Count && list_0[pARTINFO.index].IDs != null && itemIndex < list_0[pARTINFO.index].IDs.Length)
					{
						text = list_0[pARTINFO.index].IDs[itemIndex];
						goto default;
					}
					e.Item = new ListViewItem();
					return;
				case PARTTYPE.EquipAddon:
					if (list_1 != null && pARTINFO.index >= 0 && pARTINFO.index < list_1.Count && list_1[pARTINFO.index].IDs != null && itemIndex < list_1[pARTINFO.index].IDs.Length)
					{
						text = list_1[pARTINFO.index].IDs[itemIndex];
						goto default;
					}
					e.Item = new ListViewItem();
					return;
				case PARTTYPE.Ability:
					if (addonsParts_0?.IDs != null && itemIndex < addonsParts_0.IDs.Length)
					{
						text = addonsParts_0.IDs[itemIndex];
						goto default;
					}
					e.Item = new ListViewItem();
					return;
				case PARTTYPE.ItemID:
					text = eListCollection_0.GetItemID(addons_l, itemIndex);
					goto default;
				case PARTTYPE.ItemIndex:
				{
					if (list_2 == null || itemIndex >= list_2.Count)
					{
						break;
					}
					int num = list_2[itemIndex];
					text = eListCollection_0.GetItemID(addons_l, num);
					goto default;
				}
				default:
				{
					if (string.IsNullOrWhiteSpace(text))
					{
						e.Item = new ListViewItem();
						return;
					}
					int id = ACE.RSGlobal.RSGlobal.UIntParseFast(text);
					int listIndex = addons_l;
					eListCollection eListCollection2 = eListCollection_0;
					ITEMPOS pos = null;
					int num2 = eListCollection2.FindItemIndexByID(listIndex, id);
					if (num2 > -1)
					{
						pos = new ITEMPOS(listIndex, num2);
					}
					string parsedItemName = eListCollection_0.GetParsedItemName(pos);
					ListViewItem listViewItem = new ListViewItem();
					listViewItem.UseItemStyleForSubItems = false;
					listViewItem.SubItems[0].Text = parsedItemName;
					listViewItem.SubItems.Add(text);
					Color silver = Color.Silver;
					listViewItem.SubItems[1].ForeColor = silver;
					AddonsCollection addons = eListCollection_0.Addons;
					if (addons != null && addons.IsAbility(text))
					{
						listViewItem.SubItems[0].ForeColor = SpecialColors.AddonSkillColorPW;
					}
					e.Item = listViewItem;
					goto end_IL_0022;
				}
				}
				e.Item = new ListViewItem();
				return;
				end_IL_0022:;
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648918541));
				e.Item = new ListViewItem();
			}
			GC.KeepAlive(this);
		}
		else
		{
			e.Item = new ListViewItem();
		}
	}

	private void method_3(int int_3)
	{
		listViewEx_0.Items[int_3].Selected = true;
		listViewEx_0.Items[int_3].Focused = true;
		listViewEx_0.Items[int_3].EnsureVisible();
		GC.KeepAlive(this);
	}

	private void AddonsWindow_Shown(object sender, EventArgs e)
	{
		listBox_0.SelectedIndex = int_0;
		method_3(int_1);
		textBox_0.Focus();
		GC.KeepAlive(this);
	}

	private void listBox_0_MouseMove(object sender, MouseEventArgs e)
	{
	}

	private void listViewEx_0_MouseMove(object sender, MouseEventArgs e)
	{
		if (listBox_0.Focused)
		{
			IntPtr handle = base.Handle;
			if (ACE.RSGlobal.RSGlobal.GetForegroundWindow() == handle && !((Control)sender).Focused)
			{
				((Control)sender).Focus();
			}
		}
		GC.KeepAlive(this);
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		button_1_Click(null, null);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		if (bool_0 || ACE.RSGlobal.RSGlobal.antiRecurse_CmdFind_Click_AddonsWindow)
		{
			return;
		}
		try
		{
			ACE.RSGlobal.RSGlobal.antiRecurse_CmdFind_Click_AddonsWindow = true;
			list_2.Clear();
			string value = textBox_0.Text;
			if (string.IsNullOrWhiteSpace(value))
			{
				listBox_0.SelectedIndex = 0;
				Color white = Color.White;
				textBox_0.BackColor = white;
				return;
			}
			bool_0 = true;
			listBox_0.SelectedIndex = -1;
			bool_0 = false;
			int num = 0;
			while (true)
			{
				int num2 = addons_l;
				eList eList2 = eListCollection_0.Lists[num2];
				if (num >= eList2.ItemCount)
				{
					break;
				}
				int item = eListCollection_0.getid(addons_l, num);
				int num3 = addons_l;
				string parsedItemName = eListCollection_0.GetParsedItemName(num3, num, bRealAddonName: true);
				if (ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(parsedItemName, value))
				{
					HashSet<int> hashSet = hashSet_0;
					if (hashSet == null || hashSet.Contains(item))
					{
						list_2.Add(num);
					}
				}
				num++;
			}
			partinfo_1 = new PARTINFO(PARTTYPE.ItemIndex, 0);
			int count = list_2.Count;
			if (listViewEx_0.VirtualListSize != count)
			{
				listViewEx_0.VirtualListSize = count;
			}
			else
			{
				listViewEx_0.Refresh();
			}
			if (listViewEx_0.VirtualListSize > 0)
			{
				listViewEx_0.Items[0].EnsureVisible();
			}
			Color backColor = ((list_2.Count <= 0) ? Color.FromArgb(255, 100, 100) : Color.FromArgb(220, 255, 255));
			textBox_0.BackColor = backColor;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648918578));
			ACE.RSGlobal.RSGlobal.ShowHandledException(ex);
		}
		finally
		{
			ACE.RSGlobal.RSGlobal.antiRecurse_CmdFind_Click_AddonsWindow = false;
		}
		GC.KeepAlive(this);
	}

	private void textBox_0_Enter(object sender, EventArgs e)
	{
		base.AcceptButton = button_1;
	}

	private void listViewEx_0_Enter(object sender, EventArgs e)
	{
		base.AcceptButton = button_2;
	}
}
