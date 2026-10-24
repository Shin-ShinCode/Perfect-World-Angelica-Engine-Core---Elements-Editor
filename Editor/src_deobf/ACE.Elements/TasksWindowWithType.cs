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

public class TasksWindowWithType : Form
{
	public QUEST_INFO[] CachedTasks;

	public TASKS Tasks;

	public CommonStorage CStorage;

	private Button button_0;

	private ColumnHeader columnHeader_0;

	private ToolTip toolTip_0;

	private Label label_0;

	private ListViewEx listViewEx_0;

	private ColumnHeader columnHeader_1;

	private ColumnHeader columnHeader_2;

	private IContainer icontainer_0;

	public TasksWindowWithType(TASKS ref_Tasks, CommonStorage ref_CStorage)
	{
		try
		{
			method_1();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			TextStorage.TEXTS.SetFormLanguage(this, null);
			CStorage = ref_CStorage;
			Tasks = ref_Tasks;
			QUEST_INFO[] array = (CachedTasks = ref_Tasks.GetTasksInfo());
			listViewEx_0.VirtualListSize = array.Length;
			GC.KeepAlive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void listViewEx_0_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
	{
		ListViewItem listViewItem = new ListViewItem();
		listViewItem.UseItemStyleForSubItems = false;
		try
		{
			int itemIndex = e.ItemIndex;
			if (CachedTasks == null || itemIndex < 0 || itemIndex >= CachedTasks.Length || CachedTasks[itemIndex] == null)
			{
				e.Item = listViewItem;
				return;
			}
			string name = CachedTasks[itemIndex].name;
			listViewItem.SubItems[0].Text = name;
			int id = CachedTasks[itemIndex].id;
			listViewItem.SubItems.Add(id.ToString());
			Color silver = Color.Silver;
			listViewItem.SubItems[1].ForeColor = silver;
			QUEST_INFO qUEST_INFO = CachedTasks[itemIndex];
			listViewItem.SubItems[0].ForeColor = qUEST_INFO.color;
			if (Tasks?.quests == null || !Tasks.quests.ContainsKey(CachedTasks[itemIndex].id))
			{
				e.Item = listViewItem;
				return;
			}
			int ulType = Tasks.quests[CachedTasks[itemIndex].id].m_ulType;
			string text2;
			if (TASKS.TaskTypes.ContainsKey(ulType))
			{
				string text = Class16.smethod_0(1648924347);
				text2 = string.Concat(string.Concat(Class16.smethod_0(1648924364) + ulType, text), TASKS.TaskTypes[ulType]);
			}
			else
			{
				string text3 = Class16.smethod_0(1648965868);
				text2 = string.Concat(Class16.smethod_0(1648924364) + ulType, text3);
			}
			listViewItem.SubItems.Add(text2);
			e.Item = listViewItem;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648965885));
			e.Item = listViewItem;
		}
		GC.KeepAlive(this);
	}

	private void method_0()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_1()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(TasksWindowWithType));
		label_0 = new Label();
		listViewEx_0 = new ListViewEx();
		columnHeader_2 = new ColumnHeader();
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
		listViewEx_0.AllowColumnReorder = true;
		listViewEx_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		listViewEx_0.BackColor = Color.FromArgb(32, 32, 32);
		listViewEx_0.BorderStyle = BorderStyle.FixedSingle;
		listViewEx_0.Columns.AddRange(new ColumnHeader[3] { columnHeader_2, columnHeader_1, columnHeader_0 });
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
		listViewEx_0.Size = new Size(507, 747);
		listViewEx_0.TabIndex = 0;
		listViewEx_0.Tag = Class16.smethod_0(1648919381);
		toolTip_0.SetToolTip(listViewEx_0, Class16.smethod_0(1648919390));
		listViewEx_0.UseCompatibleStateImageBehavior = false;
		listViewEx_0.View = View.Details;
		listViewEx_0.VirtualMode = true;
		listViewEx_0.RetrieveVirtualItem += listViewEx_0_RetrieveVirtualItem;
		columnHeader_2.DisplayIndex = 1;
		columnHeader_2.Tag = Class16.smethod_0(1649012442);
		columnHeader_2.Text = Class16.smethod_0(1648936731);
		columnHeader_2.Width = 261;
		columnHeader_1.DisplayIndex = 0;
		columnHeader_1.Tag = Class16.smethod_0(1648929955);
		columnHeader_1.Text = Class16.smethod_0(1648941057);
		columnHeader_1.TextAlign = HorizontalAlignment.Center;
		columnHeader_1.Width = 57;
		columnHeader_0.Text = Class16.smethod_0(1649014090);
		columnHeader_0.Width = 160;
		toolTip_0.AutomaticDelay = 1500;
		toolTip_0.AutoPopDelay = 1500;
		toolTip_0.InitialDelay = 1500;
		toolTip_0.ReshowDelay = 1000;
		button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		button_0.AutoSize = true;
		button_0.DialogResult = DialogResult.Cancel;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.TasksWindowWithType_cmdCancel;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(4, 752);
		button_0.Name = Class16.smethod_0(1649000848);
		button_0.Size = new Size(507, 38);
		button_0.TabIndex = 6;
		button_0.TabStop = false;
		button_0.Text = Class16.smethod_0(1649014457);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		AutoSize = true;
		BackColor = Color.FromArgb(239, 244, 250);
		base.CancelButton = button_0;
		base.ClientSize = new Size(515, 792);
		base.Controls.Add(button_0);
		base.Controls.Add(listViewEx_0);
		base.Controls.Add(label_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.TasksWindowWithType_Icon;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648965929);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1648965793);
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
}
