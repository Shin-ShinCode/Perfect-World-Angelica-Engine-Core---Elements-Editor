using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Cpk;
using ACE.Properties;
using ACE.RSGlobal;
using ACE.sTASKedit.Classes;

namespace ACE.Elements;

public class TasksWindow : Form
{
	public QUEST_INFO[] CachedTasks;

	public TASKS Tasks;

	public CommonStorage CStorage;

	public int currentid;

	public int taskindex;

	private Button button_0;

	private ToolTip toolTip_0;

	private Label label_0;

	private Button button_1;

	private ListViewEx listViewEx_0;

	private ColumnHeader columnHeader_0;

	private ColumnHeader columnHeader_1;

	private IContainer icontainer_0;

	public TasksWindow(TASKS ref_Tasks, CommonStorage ref_CStorage, string current_id)
	{
		try
		{
			method_2();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			CStorage = ref_CStorage;
			Tasks = ref_Tasks;
			object obj;
			if (ref_Tasks == null)
			{
				obj = null;
			}
			else
			{
				obj = ref_Tasks.GetTasksInfo();
				if (obj != null)
				{
					goto IL_003c;
				}
			}
			obj = Array.Empty<QUEST_INFO>();
			goto IL_003c;
			IL_003c:
			CachedTasks = (QUEST_INFO[])obj;
			listViewEx_0.SmallImageList = TASKS.QuestImageList;
			TextStorage.TEXTS.SetFormLanguage(this, null);
			taskindex = 0;
			if (!int.TryParse(current_id, out currentid))
			{
				currentid = 0;
			}
			int num = currentid;
			int num2 = 0;
			QUEST_INFO[] cachedTasks = CachedTasks;
			int num3 = cachedTasks.Length;
			if (0 < num3)
			{
				do
				{
					QUEST_INFO qUEST_INFO = cachedTasks[num2];
					if (qUEST_INFO == null || qUEST_INFO.id != num)
					{
						num2++;
						continue;
					}
					taskindex = num2;
					break;
				}
				while (num2 < num3);
			}
			listViewEx_0.VirtualListSize = cachedTasks.Length;
			GC.KeepAlive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		method_0();
	}

	private void listViewEx_0_DoubleClick(object sender, EventArgs e)
	{
		method_0();
	}

	private void method_0()
	{
		if (CachedTasks != null && listViewEx_0.SelectedIndices.Count > 0)
		{
			CommonStorage.sarr1 = new string[listViewEx_0.SelectedIndices.Count];
			int num = 0;
			if (0 < (nint)CommonStorage.sarr1.LongLength)
			{
				do
				{
					int num2 = listViewEx_0.SelectedIndices[num];
					if (num2 < 0 || num2 >= CachedTasks.Length || CachedTasks[num2] == null)
					{
						num++;
						continue;
					}
					int id = CachedTasks[num2].id;
					ref string reference = ref CommonStorage.sarr1[num];
					reference = id.ToString();
					num++;
				}
				while (num < (nint)CommonStorage.sarr1.LongLength);
			}
			if (CommonStorage.sarr1.Length != 0 && !string.IsNullOrWhiteSpace(CommonStorage.sarr1[0]))
			{
				CommonStorage.sData = CommonStorage.sarr1[0];
				base.DialogResult = DialogResult.OK;
			}
		}
		Close();
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		Hide();
	}

	private void listViewEx_0_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
	{
		int itemIndex = e.ItemIndex;
		ListViewItem listViewItem = new ListViewItem();
		listViewItem.UseItemStyleForSubItems = false;
		if (CachedTasks != null && itemIndex >= 0 && itemIndex < CachedTasks.Length && CachedTasks[itemIndex] != null)
		{
			string name = CachedTasks[itemIndex].name;
			listViewItem.SubItems[0].Text = name;
			int id = CachedTasks[itemIndex].id;
			listViewItem.SubItems.Add(id.ToString());
			Color silver = Color.Silver;
			listViewItem.SubItems[1].ForeColor = silver;
			QUEST_INFO qUEST_INFO = CachedTasks[itemIndex];
			listViewItem.SubItems[0].ForeColor = qUEST_INFO.color;
			listViewItem.ImageIndex = CachedTasks[itemIndex].ImageIndex;
			e.Item = listViewItem;
			GC.KeepAlive(this);
		}
		else
		{
			listViewItem.SubItems[0].Text = Class16.smethod_0(1648942867);
			e.Item = listViewItem;
		}
	}

	private void TasksWindow_Shown(object sender, EventArgs e)
	{
		if (CachedTasks != null && CachedTasks.Length != 0 && listViewEx_0.VirtualListSize > 0)
		{
			int num = taskindex;
			if (num < 0 || num >= listViewEx_0.VirtualListSize)
			{
				num = 0;
			}
			try
			{
				listViewEx_0.SelectedIndices.Clear();
				listViewEx_0.SelectedIndices.Add(num);
				listViewEx_0.EnsureVisible(num);
				listViewEx_0.Focus();
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648965759));
			}
			GC.KeepAlive(this);
		}
	}

	private void TasksWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult != DialogResult.OK)
		{
			e.Cancel = true;
			Hide();
		}
	}

	private void listViewEx_0_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
	{
		if (e?.Item != null && e.Item.SubItems.Count >= 2 && int.TryParse(e.Item.SubItems[1].Text, out var result))
		{
			if (result > 0)
			{
				TASKS_HINT.ShowTaskToolTip(listViewEx_0, result, CommonStorage.CurrentItemPos);
			}
			else
			{
				TASKS_HINT.ToolTipWindow.Hide();
			}
			GC.KeepAlive(this);
		}
		else
		{
			TASKS_HINT.ToolTipWindow.Hide();
		}
	}

	private void method_1()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_2()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(TasksWindow));
		label_0 = new Label();
		button_1 = new Button();
		listViewEx_0 = new ListViewEx();
		columnHeader_1 = new ColumnHeader();
		columnHeader_0 = new ColumnHeader();
		toolTip_0 = new ToolTip(icontainer_0);
		button_0 = new Button();
		SuspendLayout();
		label_0.AutoSize = true;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_0.Location = new Point(-282, 490);
		label_0.Name = Class16.smethod_0(1648919238);
		label_0.Size = new Size(127, 20);
		label_0.TabIndex = 2;
		label_0.Text = Class16.smethod_0(1648919243);
		label_0.Visible = false;
		button_1.AutoSize = true;
		button_1.DialogResult = DialogResult.OK;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_1.Image = Resources.TasksWindow_cmdOk;
		button_1.ImageAlign = ContentAlignment.MiddleRight;
		button_1.Location = new Point(4, 567);
		button_1.Name = Class16.smethod_0(1648973834);
		button_1.Size = new Size(169, 38);
		button_1.TabIndex = 1;
		button_1.TabStop = false;
		button_1.Text = Class16.smethod_0(1648919277);
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		listViewEx_0.AllowColumnReorder = true;
		listViewEx_0.BackColor = Color.FromArgb(32, 32, 32);
		listViewEx_0.BorderStyle = BorderStyle.FixedSingle;
		listViewEx_0.Columns.AddRange(new ColumnHeader[2] { columnHeader_1, columnHeader_0 });
		listViewEx_0.Cursor = Cursors.Default;
		listViewEx_0.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		listViewEx_0.ForeColor = Color.White;
		listViewEx_0.FullRowSelect = true;
		listViewEx_0.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		listViewEx_0.HideSelection = false;
		listViewEx_0.LabelWrap = false;
		listViewEx_0.Location = new Point(4, 2);
		listViewEx_0.Name = Class16.smethod_0(1648978656);
		listViewEx_0.ShowGroups = false;
		listViewEx_0.Size = new Size(340, 562);
		listViewEx_0.TabIndex = 0;
		listViewEx_0.Tag = Class16.smethod_0(1648919381);
		toolTip_0.SetToolTip(listViewEx_0, Class16.smethod_0(1648919390));
		listViewEx_0.UseCompatibleStateImageBehavior = false;
		listViewEx_0.View = View.Details;
		listViewEx_0.VirtualMode = true;
		listViewEx_0.ItemMouseHover += listViewEx_0_ItemMouseHover;
		listViewEx_0.RetrieveVirtualItem += listViewEx_0_RetrieveVirtualItem;
		listViewEx_0.DoubleClick += listViewEx_0_DoubleClick;
		columnHeader_1.DisplayIndex = 1;
		columnHeader_1.Tag = Class16.smethod_0(1649012442);
		columnHeader_1.Text = Class16.smethod_0(1648936731);
		columnHeader_1.Width = 261;
		columnHeader_0.DisplayIndex = 0;
		columnHeader_0.Tag = Class16.smethod_0(1648929955);
		columnHeader_0.Text = Class16.smethod_0(1648941057);
		columnHeader_0.TextAlign = HorizontalAlignment.Center;
		columnHeader_0.Width = 57;
		toolTip_0.AutomaticDelay = 1500;
		toolTip_0.AutoPopDelay = 1500;
		toolTip_0.InitialDelay = 1500;
		toolTip_0.ReshowDelay = 1000;
		button_0.AutoSize = true;
		button_0.DialogResult = DialogResult.Cancel;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.TasksWindow_cmdCancel;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(177, 567);
		button_0.Name = Class16.smethod_0(1649000848);
		button_0.Size = new Size(167, 38);
		button_0.TabIndex = 6;
		button_0.TabStop = false;
		button_0.Text = Class16.smethod_0(1648989215);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		base.AcceptButton = button_1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		AutoSize = true;
		BackColor = Color.FromArgb(239, 244, 250);
		base.CancelButton = button_0;
		base.ClientSize = new Size(348, 607);
		base.Controls.Add(button_1);
		base.Controls.Add(button_0);
		base.Controls.Add(listViewEx_0);
		base.Controls.Add(label_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.TasksWindow_Icon;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648965783);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648965793);
		base.FormClosing += TasksWindow_FormClosing;
		base.Shown += TasksWindow_Shown;
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
}
