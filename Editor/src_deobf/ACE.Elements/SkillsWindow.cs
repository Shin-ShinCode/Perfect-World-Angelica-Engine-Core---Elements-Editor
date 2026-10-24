using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eListCollection;
using ACE.Properties;
using ACE.RSGlobal;
using ACE.sTASKedit.Classes;

namespace ACE.Elements;

public class SkillsWindow : Form
{
	private struct Struct53
	{
		public int int_0;

		public int int_1;
	}

	private ACE.Elements.eListCollection.eListCollection eListCollection_0;

	private CommonStorage commonStorage_0;

	private SkillInfo[] skillInfo_0;

	private SkillsBase skillsBase_0;

	private int int_0;

	private int int_1;

	private Struct53[] struct53_0;

	private Button button_0;

	private TextBox textBox_0;

	private List<int> list_0;

	private Button button_1;

	private ListViewEx listViewEx_0;

	private ColumnHeader columnHeader_0;

	private ColumnHeader columnHeader_1;

	private ListViewEx listViewEx_1;

	private ColumnHeader columnHeader_2;

	private WebBrowser webBrowser_0;

	private ToolTip toolTip_0;

	private Label label_0;

	private Button button_2;

	private NumericUpDown numericUpDown_0;

	private ListViewEx listViewEx_2;

	private ColumnHeader columnHeader_3;

	private ColumnHeader columnHeader_4;

	private IContainer icontainer_0;

	public SkillsWindow(int ref_currentid, int int_2, SkillsBase ref_SkillsDB, ACE.Elements.eListCollection.eListCollection ref_eLC, CommonStorage ref_CStorage)
	{
		try
		{
			method_4();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			int_0 = int_2;
			eListCollection_0 = ref_eLC;
			commonStorage_0 = ref_CStorage;
			skillsBase_0 = ref_SkillsDB;
			int_1 = ref_currentid;
			ToolTip toolTip = toolTip_0;
			TextStorage.TEXTS.SetFormLanguage(this, toolTip);
			if (ref_eLC != null)
			{
				SkillsBase skillsBase = skillsBase_0;
				if (skillsBase != null && skillsBase.Skills != null)
				{
					list_0 = eListCollection_0.GetFieldsWithSkills(int_0);
					int virtualListSize = eListCollection_0.GetItemsCount(int_0) + 1;
					listViewEx_0.VirtualListSize = virtualListSize;
					GC.KeepAlive(this);
				}
				else
				{
					TextStorage.TEXTS.ShowErrorMessage(450);
					GC.KeepAlive(this);
				}
			}
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		method_0();
	}

	private void listViewEx_2_DoubleClick(object sender, EventArgs e)
	{
		method_0();
	}

	private void method_0()
	{
		if (listViewEx_2.SelectedIndices.Count > 0)
		{
			int id = skillInfo_0[listViewEx_2.SelectedIndices[0]].id;
			CommonStorage.sData = id.ToString();
		}
		base.Visible = false;
	}

	private void SkillsWindow_Load(object sender, EventArgs e)
	{
		if (listViewEx_0.VirtualListSize == 0)
		{
			Close();
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void listViewEx_2_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
	{
		int itemIndex = e.ItemIndex;
		ListViewItem listViewItem = new ListViewItem();
		listViewItem.UseItemStyleForSubItems = false;
		string name = skillInfo_0[itemIndex].Name;
		listViewItem.SubItems[0].Text = name;
		int id = skillInfo_0[itemIndex].id;
		listViewItem.SubItems.Add(id.ToString());
		Color silver = Color.Silver;
		listViewItem.SubItems[1].ForeColor = silver;
		e.Item = listViewItem;
		GC.KeepAlive(this);
	}

	private void method_1(int int_2)
	{
		listViewEx_0.Items[int_2].Selected = true;
		listViewEx_0.Items[int_2].Focused = true;
		listViewEx_0.Items[int_2].EnsureVisible();
		GC.KeepAlive(this);
	}

	private void method_2(int int_2)
	{
		listViewEx_2.Items[int_2].Selected = true;
		listViewEx_2.Items[int_2].Focused = true;
		listViewEx_2.Items[int_2].EnsureVisible();
		GC.KeepAlive(this);
	}

	private void SkillsWindow_Shown(object sender, EventArgs e)
	{
		webBrowser_0.Document.BackColor = SpecialColors.ItemDark;
		Color white = Color.White;
		webBrowser_0.Document.ForeColor = white;
		method_1(0);
		int num = int_1;
		if (num <= 0)
		{
			return;
		}
		int num2 = 0;
		SkillInfo[] array = skillInfo_0;
		int num3 = array.Length;
		if (0 >= num3)
		{
			return;
		}
		while (array[num2].id != num)
		{
			num2++;
			if (num2 >= num3)
			{
				return;
			}
		}
		method_2(num2);
	}

	private void method_3()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_4()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(SkillsWindow));
		label_0 = new Label();
		button_2 = new Button();
		numericUpDown_0 = new NumericUpDown();
		listViewEx_2 = new ListViewEx();
		columnHeader_4 = new ColumnHeader();
		columnHeader_3 = new ColumnHeader();
		toolTip_0 = new ToolTip(icontainer_0);
		listViewEx_0 = new ListViewEx();
		columnHeader_0 = new ColumnHeader();
		columnHeader_1 = new ColumnHeader();
		listViewEx_1 = new ListViewEx();
		columnHeader_2 = new ColumnHeader();
		button_0 = new Button();
		button_1 = new Button();
		webBrowser_0 = new WebBrowser();
		textBox_0 = new TextBox();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		SuspendLayout();
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
		button_2.Image = Resources.SkillsWindow_cmdOk;
		button_2.ImageAlign = ContentAlignment.MiddleRight;
		button_2.Location = new Point(3, 539);
		button_2.Name = Class16.smethod_0(1648973834);
		button_2.Size = new Size(444, 41);
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
		listViewEx_2.AllowColumnReorder = true;
		listViewEx_2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		listViewEx_2.BackColor = Color.FromArgb(32, 32, 32);
		listViewEx_2.BorderStyle = BorderStyle.FixedSingle;
		listViewEx_2.Columns.AddRange(new ColumnHeader[2] { columnHeader_4, columnHeader_3 });
		listViewEx_2.Cursor = Cursors.Default;
		listViewEx_2.Font = new Font(Class16.smethod_0(1648929920), 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
		listViewEx_2.ForeColor = Color.Gold;
		listViewEx_2.FullRowSelect = true;
		listViewEx_2.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		listViewEx_2.HideSelection = false;
		listViewEx_2.LabelWrap = false;
		listViewEx_2.Location = new Point(263, 30);
		listViewEx_2.MultiSelect = false;
		listViewEx_2.Name = Class16.smethod_0(1648966261);
		listViewEx_2.Size = new Size(357, 396);
		listViewEx_2.TabIndex = 0;
		listViewEx_2.Tag = Class16.smethod_0(1648919381);
		toolTip_0.SetToolTip(listViewEx_2, Class16.smethod_0(1648966266));
		listViewEx_2.UseCompatibleStateImageBehavior = false;
		listViewEx_2.View = View.Details;
		listViewEx_2.VirtualMode = true;
		listViewEx_2.RetrieveVirtualItem += listViewEx_2_RetrieveVirtualItem;
		listViewEx_2.SelectedIndexChanged += listViewEx_2_SelectedIndexChanged;
		listViewEx_2.DoubleClick += listViewEx_2_DoubleClick;
		listViewEx_2.Enter += listViewEx_2_Enter;
		listViewEx_2.MouseMove += listViewEx_2_MouseMove;
		columnHeader_4.Tag = Class16.smethod_0(1649012442);
		columnHeader_4.Text = Class16.smethod_0(1648936731);
		columnHeader_4.Width = 277;
		columnHeader_3.Tag = Class16.smethod_0(1648966305);
		columnHeader_3.Text = Class16.smethod_0(1648941057);
		columnHeader_3.TextAlign = HorizontalAlignment.Center;
		columnHeader_3.Width = 58;
		toolTip_0.AutomaticDelay = 1500;
		toolTip_0.AutoPopDelay = 1500;
		toolTip_0.InitialDelay = 1500;
		toolTip_0.ReshowDelay = 3000;
		listViewEx_0.AllowColumnReorder = true;
		listViewEx_0.BackColor = Color.FromArgb(32, 32, 32);
		listViewEx_0.BorderStyle = BorderStyle.FixedSingle;
		listViewEx_0.Columns.AddRange(new ColumnHeader[2] { columnHeader_0, columnHeader_1 });
		listViewEx_0.Cursor = Cursors.Default;
		listViewEx_0.Font = new Font(Class16.smethod_0(1648929920), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		listViewEx_0.ForeColor = Color.White;
		listViewEx_0.FullRowSelect = true;
		listViewEx_0.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		listViewEx_0.HideSelection = false;
		listViewEx_0.LabelWrap = false;
		listViewEx_0.Location = new Point(3, 7);
		listViewEx_0.MultiSelect = false;
		listViewEx_0.Name = Class16.smethod_0(1648966326);
		listViewEx_0.Size = new Size(254, 419);
		listViewEx_0.TabIndex = 8;
		listViewEx_0.Tag = Class16.smethod_0(1648919381);
		toolTip_0.SetToolTip(listViewEx_0, Class16.smethod_0(1648966343));
		listViewEx_0.UseCompatibleStateImageBehavior = false;
		listViewEx_0.View = View.Details;
		listViewEx_0.VirtualMode = true;
		listViewEx_0.RetrieveVirtualItem += listViewEx_0_RetrieveVirtualItem;
		listViewEx_0.SelectedIndexChanged += listViewEx_0_SelectedIndexChanged;
		listViewEx_0.MouseMove += listViewEx_0_MouseMove;
		columnHeader_0.DisplayIndex = 1;
		columnHeader_0.Tag = Class16.smethod_0(1648966403);
		columnHeader_0.Text = Class16.smethod_0(1648966419);
		columnHeader_0.Width = 182;
		columnHeader_1.DisplayIndex = 0;
		columnHeader_1.Tag = Class16.smethod_0(1648929955);
		columnHeader_1.Text = Class16.smethod_0(1648941057);
		columnHeader_1.TextAlign = HorizontalAlignment.Center;
		columnHeader_1.Width = 48;
		listViewEx_1.AllowColumnReorder = true;
		listViewEx_1.BackColor = Color.FromArgb(32, 32, 32);
		listViewEx_1.BorderStyle = BorderStyle.FixedSingle;
		listViewEx_1.Columns.AddRange(new ColumnHeader[1] { columnHeader_2 });
		listViewEx_1.Cursor = Cursors.Default;
		listViewEx_1.Font = new Font(Class16.smethod_0(1648929920), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		listViewEx_1.ForeColor = Color.White;
		listViewEx_1.FullRowSelect = true;
		listViewEx_1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		listViewEx_1.HideSelection = false;
		listViewEx_1.LabelWrap = false;
		listViewEx_1.Location = new Point(626, 7);
		listViewEx_1.MultiSelect = false;
		listViewEx_1.Name = Class16.smethod_0(1648966454);
		listViewEx_1.Size = new Size(257, 419);
		listViewEx_1.TabIndex = 9;
		listViewEx_1.Tag = Class16.smethod_0(1648919381);
		toolTip_0.SetToolTip(listViewEx_1, Class16.smethod_0(1648966459));
		listViewEx_1.UseCompatibleStateImageBehavior = false;
		listViewEx_1.View = View.Details;
		listViewEx_1.VirtualMode = true;
		listViewEx_1.RetrieveVirtualItem += listViewEx_1_RetrieveVirtualItem;
		listViewEx_1.DoubleClick += listViewEx_1_DoubleClick;
		listViewEx_1.MouseMove += listViewEx_1_MouseMove;
		columnHeader_2.Tag = Class16.smethod_0(1648966516);
		columnHeader_2.Text = Class16.smethod_0(1648966532);
		columnHeader_2.Width = 236;
		button_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_0.Image = Resources.SkillsWindow_cmdFind;
		button_0.Location = new Point(591, 7);
		button_0.Name = Class16.smethod_0(1648919443);
		button_0.Size = new Size(30, 23);
		button_0.TabIndex = 12;
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_0.SetToolTip(button_0, Class16.smethod_0(1648997028));
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		button_1.AutoSize = true;
		button_1.DialogResult = DialogResult.Cancel;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 12f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_1.Image = Resources.SkillsWindow_cmdCancel;
		button_1.ImageAlign = ContentAlignment.MiddleRight;
		button_1.Location = new Point(453, 539);
		button_1.Name = Class16.smethod_0(1649000848);
		button_1.Size = new Size(431, 41);
		button_1.TabIndex = 6;
		button_1.TabStop = false;
		button_1.Text = Class16.smethod_0(1648989215);
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		webBrowser_0.AllowNavigation = false;
		webBrowser_0.Location = new Point(3, 432);
		webBrowser_0.MinimumSize = new Size(20, 20);
		webBrowser_0.Name = Class16.smethod_0(1648976300);
		webBrowser_0.Size = new Size(880, 101);
		webBrowser_0.TabIndex = 10;
		webBrowser_0.Url = new Uri(Class16.smethod_0(1648976309), UriKind.Absolute);
		webBrowser_0.WebBrowserShortcutsEnabled = false;
		textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_0.BackColor = Color.White;
		textBox_0.Location = new Point(263, 7);
		textBox_0.Name = Class16.smethod_0(1648919457);
		textBox_0.Size = new Size(326, 22);
		textBox_0.TabIndex = 11;
		textBox_0.TextAlign = HorizontalAlignment.Center;
		textBox_0.TextChanged += textBox_0_TextChanged;
		textBox_0.Enter += textBox_0_Enter;
		base.AcceptButton = button_2;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		AutoSize = true;
		BackColor = Color.FromArgb(239, 244, 250);
		base.CancelButton = button_1;
		base.ClientSize = new Size(887, 584);
		base.Controls.Add(button_0);
		base.Controls.Add(textBox_0);
		base.Controls.Add(webBrowser_0);
		base.Controls.Add(listViewEx_1);
		base.Controls.Add(listViewEx_0);
		base.Controls.Add(button_2);
		base.Controls.Add(button_1);
		base.Controls.Add(listViewEx_2);
		base.Controls.Add(numericUpDown_0);
		base.Controls.Add(label_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.SkillsWindow_Icon;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648966550);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648966561);
		base.Load += SkillsWindow_Load;
		base.Shown += SkillsWindow_Shown;
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
				method_3();
				return;
			}
			finally
			{
				base.Dispose(true);
			}
		}
		base.Dispose(false);
	}

	private void listViewEx_2_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (listViewEx_2.SelectedIndices != null && listViewEx_2.SelectedIndices.Count != 0 && listViewEx_2.SelectedIndices[0] != -1)
		{
			int num = listViewEx_2.SelectedIndices[0];
			string value = skillInfo_0[num].Desciption;
			if (string.IsNullOrWhiteSpace(value))
			{
				value = skillInfo_0[num].Name;
			}
			string innerHtml = ACE.RSGlobal.RSGlobal.ToHTML(value, bCutLine: false);
			webBrowser_0.Document.Body.InnerHtml = innerHtml;
			ref int id = ref skillInfo_0[num].id;
			int num2 = 0;
			int num3 = eListCollection_0.GetItemsCount(int_0) - 1;
			if (num3 >= 0)
			{
				int num4 = -1;
				do
				{
					List<int>.Enumerator enumerator = list_0.GetEnumerator();
					if (enumerator.MoveNext())
					{
						do
						{
							int current = enumerator.Current;
							int num5 = int_0;
							FIELDTYPE fieldType = eListCollection_0.GetFieldType(num5, num3, current);
							int num6 = ((fieldType == FIELDTYPE.monster_skills || fieldType == FIELDTYPE.potion_skills || fieldType == FIELDTYPE.scrolls_skills || fieldType == FIELDTYPE.skills_pw || fieldType == FIELDTYPE.ft_dyn_skills || fieldType == FIELDTYPE.ft_skills) ? 1 : 0);
							if ((byte)num6 == 0)
							{
								continue;
							}
							int num7 = id;
							if (eListCollection_0.GetIDinField(int_0, num3, current) == num7)
							{
								num2++;
								num4++;
								Array.Resize(ref struct53_0, num2);
								struct53_0[num4].int_0 = num3;
								int num8 = int_0;
								ACE.Elements.eListCollection.eListCollection eListCollection2 = eListCollection_0;
								FIELD_DATA_TYPE_ENUM data_type = eListCollection2.Lists[num8].FieldDataTypes[current + 1].data_type;
								if (data_type != FIELD_DATA_TYPE_ENUM.Int && data_type != FIELD_DATA_TYPE_ENUM.UInt)
								{
									struct53_0[num4].int_1 = 1;
								}
								else
								{
									struct53_0[num4].int_1 = eListCollection2.GetValueI(num8, num3, current + 1);
								}
								break;
							}
						}
						while (enumerator.MoveNext());
					}
					num3--;
				}
				while (num3 >= 0);
			}
			listViewEx_1.VirtualListSize = num2;
			listViewEx_1.Refresh();
			GC.KeepAlive(this);
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	private void listViewEx_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		SkillInfo skillInfo = null;
		if (listViewEx_0.SelectedIndices != null && listViewEx_0.SelectedIndices.Count != 0 && listViewEx_0.SelectedIndices[0] != -1)
		{
			int num = listViewEx_0.SelectedIndices[0];
			listViewEx_2.VirtualListSize = 0;
			if (num == 0)
			{
				SkillsBase skillsBase = skillsBase_0;
				if (skillsBase != null)
				{
					skillInfo_0 = skillsBase.GetSkillArray();
				}
			}
			else
			{
				SkillsBase skillsBase2 = new SkillsBase();
				int num2 = eListCollection_0.GetItemsCount(int_0) - num;
				List<int>.Enumerator enumerator = list_0.GetEnumerator();
				if (enumerator.MoveNext())
				{
					do
					{
						int current = enumerator.Current;
						int iDinField = eListCollection_0.GetIDinField(int_0, num2, current);
						if (iDinField <= 0)
						{
							continue;
						}
						int num3 = int_0;
						FIELDTYPE fieldType = eListCollection_0.GetFieldType(num3, num2, current);
						int num4 = ((fieldType == FIELDTYPE.monster_skills || fieldType == FIELDTYPE.potion_skills || fieldType == FIELDTYPE.scrolls_skills || fieldType == FIELDTYPE.skills_pw || fieldType == FIELDTYPE.ft_dyn_skills || fieldType == FIELDTYPE.ft_skills) ? 1 : 0);
						if ((byte)num4 != 0)
						{
							skillInfo = null;
							if (!skillsBase2.Skills.ContainsKey(iDinField) && skillsBase_0.Skills.TryGetValue(iDinField, out skillInfo))
							{
								skillsBase2.Skills.Add(iDinField, skillInfo);
							}
						}
					}
					while (enumerator.MoveNext());
				}
				skillInfo_0 = skillsBase2.GetSkillArray();
			}
			SkillInfo[] array = skillInfo_0;
			if (array != null)
			{
				listViewEx_2.VirtualListSize = array.Length;
				string empty = string.Empty;
				webBrowser_0.Document.Body.InnerHtml = empty;
				listViewEx_1.VirtualListSize = 0;
			}
			GC.KeepAlive(this);
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	private void listViewEx_0_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
	{
		int itemIndex = e.ItemIndex;
		ListViewItem listViewItem = new ListViewItem();
		if (itemIndex == 0)
		{
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648966624));
			listViewItem.Text = text;
			listViewItem.Font = new Font(listViewItem.Font, FontStyle.Bold);
			Color aqua = Color.Aqua;
			listViewItem.ForeColor = aqua;
			string text2 = Class16.smethod_0(1648966655);
			listViewItem.SubItems.Add(text2);
			e.Item = listViewItem;
		}
		else
		{
			try
			{
				int itemsCount = eListCollection_0.GetItemsCount(int_0);
				int num = itemsCount - itemIndex;
				if (num < 0 || num >= itemsCount || int_0 < 0 || int_0 >= eListCollection_0.ListCount)
				{
					e.Item = listViewItem;
					return;
				}
				int listIndex = int_0;
				ACE.Elements.eListCollection.eListCollection eListCollection2 = eListCollection_0;
				if (eListCollection2 == null)
				{
					e.Item = listViewItem;
					return;
				}
				ITEMINFO itemInfo = eListCollection2.GetItemInfo(new ITEMPOS(listIndex, num), bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
				ListViewItem item = ((itemInfo == null) ? listViewItem : (eListCollection2.CreateListViewItem(itemInfo, NameIsFirst: true) ?? listViewItem));
				e.Item = item;
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648965632));
				e.Item = listViewItem;
			}
		}
		GC.KeepAlive(this);
	}

	private void listViewEx_1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
	{
		ListViewItem listViewItem = new ListViewItem();
		try
		{
			if (e.ItemIndex < 0 || e.ItemIndex >= struct53_0.Length)
			{
				e.Item = listViewItem;
				return;
			}
			int num = struct53_0[e.ItemIndex].int_0;
			int num2 = int_0;
			if (num2 < 0 || num2 >= eListCollection_0.ListCount || num < 0)
			{
				e.Item = listViewItem;
				return;
			}
			ACE.Elements.eListCollection.eListCollection eListCollection2 = eListCollection_0;
			if (eListCollection2 == null)
			{
				e.Item = listViewItem;
				return;
			}
			ITEMINFO itemInfo = eListCollection2.GetItemInfo(new ITEMPOS(num2, num), bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
			listViewItem = ((itemInfo == null) ? listViewItem : (eListCollection2.CreateListViewItem(itemInfo, NameIsFirst: true) ?? listViewItem));
			listViewItem.SubItems.RemoveAt(1);
			object[] array = new object[1];
			int num3 = struct53_0[e.ItemIndex].int_1;
			array[0] = num3;
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648965682), array);
			listViewItem.Text += text;
			e.Item = listViewItem;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648965705));
			e.Item = listViewItem;
		}
		GC.KeepAlive(this);
	}

	private void listViewEx_1_DoubleClick(object sender, EventArgs e)
	{
		if (listViewEx_1.SelectedIndices.Count != 0)
		{
			ListView listView = listViewEx_1;
			CommonStorage.oData = listViewEx_1.Items[listView.SelectedIndices[0]].Tag;
			base.Visible = false;
		}
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
		GC.KeepAlive(this);
	}

	private void listViewEx_2_MouseMove(object sender, MouseEventArgs e)
	{
		if (!textBox_0.Focused)
		{
			IntPtr handle = base.Handle;
			if (ACE.RSGlobal.RSGlobal.GetForegroundWindow() == handle && !((Control)sender).Focused)
			{
				((Control)sender).Focus();
			}
		}
		GC.KeepAlive(this);
	}

	private void listViewEx_1_MouseMove(object sender, MouseEventArgs e)
	{
		if (!textBox_0.Focused)
		{
			IntPtr handle = base.Handle;
			if (ACE.RSGlobal.RSGlobal.GetForegroundWindow() == handle && !((Control)sender).Focused)
			{
				((Control)sender).Focus();
			}
		}
		GC.KeepAlive(this);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (listViewEx_0.SelectedIndices != null && listViewEx_0.SelectedIndices.Count != 0 && listViewEx_0.SelectedIndices[0] != -1)
		{
			if (listViewEx_0.SelectedIndices[0] != 0)
			{
				method_1(0);
			}
			string text = textBox_0.Text;
			listViewEx_2.VirtualListSize = 0;
			SkillInfo[] array = (skillInfo_0 = skillsBase_0.GetSkillArray(text));
			listViewEx_2.VirtualListSize = array.Length;
			string empty = string.Empty;
			webBrowser_0.Document.Body.InnerHtml = empty;
			listViewEx_1.VirtualListSize = 0;
			GC.KeepAlive(this);
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		if (textBox_0.TextLength == 0 || textBox_0.TextLength >= 3)
		{
			button_0_Click(null, null);
		}
	}

	private void listViewEx_2_Enter(object sender, EventArgs e)
	{
		base.AcceptButton = button_2;
	}

	private void textBox_0_Enter(object sender, EventArgs e)
	{
		base.AcceptButton = button_0;
	}
}
