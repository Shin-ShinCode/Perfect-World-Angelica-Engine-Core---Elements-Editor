using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eList;
using ACE.Elements.eListCollection;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.Elements;

public class JoinWindow : Form
{
	private enum Enum8
	{

	}

	private ACE.Elements.eListCollection.eListCollection eListCollection_0;

	private CommonStorage commonStorage_0;

	private bool bool_0;

	private bool bool_1;

	private GAMES games_0;

	private List<string> list_0 = new List<string>();

	private int int_0 = -1;

	private CheckBox checkBox_0;

	private ToolTip toolTip_0;

	private TextBox textBox_0;

	private ComboBox comboBox_0;

	private GroupBox groupBox_0;

	private CheckBox checkBox_1;

	private Button button_0;

	private TextBox textBox_1;

	private CheckBox checkBox_2;

	private Label label_0;

	private TextBox textBox_2;

	private Button button_1;

	private Button button_2;

	private Button button_3;

	private RadioButton radioButton_0;

	private RadioButton radioButton_1;

	private RadioButton radioButton_2;

	private CheckBox checkBox_3;

	private GroupBox groupBox_1;

	private GroupBox groupBox_2;

	private NumericUpDown numericUpDown_0;

	private NumericUpDown numericUpDown_1;

	private Label label_1;

	private Label label_2;

	private RadioButton radioButton_3;

	private ProgressBar progressBar_0;

	private ProgressBar progressBar_1;

	private RadioButton radioButton_4;

	private CheckedListBox checkedListBox_0;

	private Button button_4;

	private Label label_3;

	private Button button_5;

	private Button button_6;

	private IContainer icontainer_0;

	public JoinWindow(ACE.Elements.eListCollection.eListCollection ref_eLC, CommonStorage CStorage, int SelectedList, [MarshalAs(UnmanagedType.U1)] bool ref_IsLocalization)
	{
		try
		{
			method_2();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			eListCollection_0 = ref_eLC;
			commonStorage_0 = CStorage;
			ToolTip toolTip = toolTip_0;
			TextStorage.TEXTS.SetFormLanguage(this, toolTip);
			if (SelectedList > -1)
			{
				ACE.Elements.eList.eList eList2 = eListCollection_0.Lists[SelectedList];
				string text = ((!ACE.RSGlobal.RSGlobal.SHOW_UNIVERSAL_NAMES) ? eList2.ListName : eList2.uListName);
				textBox_0.Text = text;
			}
			comboBox_0.SelectedIndex = 0;
			bool_1 = ref_IsLocalization;
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		if (bool_1)
		{
			string title = TextStorage.TEXTS.GetText(Class16.smethod_0(1648977973));
			openFileDialog.Title = title;
		}
		else
		{
			string title2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648977996));
			openFileDialog.Title = title2;
		}
		openFileDialog.Filter = Class16.smethod_0(1648978011);
		if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			textBox_2.Text = openFileDialog.FileName;
		}
		GC.KeepAlive(this);
	}

	private void method_0(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void method_1()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_2()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(JoinWindow));
		label_0 = new Label();
		textBox_2 = new TextBox();
		button_1 = new Button();
		button_2 = new Button();
		button_3 = new Button();
		radioButton_0 = new RadioButton();
		radioButton_1 = new RadioButton();
		radioButton_2 = new RadioButton();
		checkBox_3 = new CheckBox();
		groupBox_1 = new GroupBox();
		comboBox_0 = new ComboBox();
		textBox_0 = new TextBox();
		groupBox_2 = new GroupBox();
		radioButton_3 = new RadioButton();
		numericUpDown_0 = new NumericUpDown();
		numericUpDown_1 = new NumericUpDown();
		label_1 = new Label();
		label_2 = new Label();
		groupBox_0 = new GroupBox();
		checkBox_2 = new CheckBox();
		checkBox_1 = new CheckBox();
		button_0 = new Button();
		textBox_1 = new TextBox();
		checkBox_0 = new CheckBox();
		radioButton_4 = new RadioButton();
		checkedListBox_0 = new CheckedListBox();
		button_4 = new Button();
		label_3 = new Label();
		button_5 = new Button();
		button_6 = new Button();
		progressBar_0 = new ProgressBar();
		progressBar_1 = new ProgressBar();
		toolTip_0 = new ToolTip(icontainer_0);
		groupBox_1.SuspendLayout();
		groupBox_2.SuspendLayout();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		((ISupportInitialize)numericUpDown_1).BeginInit();
		groupBox_0.SuspendLayout();
		SuspendLayout();
		label_0.Location = new Point(8, 11);
		label_0.Name = Class16.smethod_0(1648919238);
		label_0.Size = new Size(148, 16);
		label_0.TabIndex = 0;
		label_0.Text = Class16.smethod_0(1648978055);
		label_0.TextAlign = ContentAlignment.MiddleRight;
		textBox_2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_2.Location = new Point(162, 9);
		textBox_2.Margin = new Padding(3, 4, 3, 4);
		textBox_2.Name = Class16.smethod_0(1648978076);
		textBox_2.Size = new Size(323, 22);
		textBox_2.TabIndex = 5;
		button_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_1.Image = Resources.JoinWindow_cmdBrowse;
		button_1.ImageAlign = ContentAlignment.MiddleRight;
		button_1.Location = new Point(493, 9);
		button_1.Margin = new Padding(3, 4, 3, 4);
		button_1.Name = Class16.smethod_0(1648893030);
		button_1.Size = new Size(88, 22);
		button_1.TabIndex = 6;
		button_1.Text = Class16.smethod_0(1648978102);
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		button_2.AutoSize = true;
		button_2.DialogResult = DialogResult.Cancel;
		button_2.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_2.Image = Resources.JoinWindow_cmdcancel;
		button_2.ImageAlign = ContentAlignment.MiddleRight;
		button_2.Location = new Point(299, 520);
		button_2.Name = Class16.smethod_0(1648925752);
		button_2.Size = new Size(282, 32);
		button_2.TabIndex = 33;
		button_2.TabStop = false;
		button_2.Text = Class16.smethod_0(1648978118);
		button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		button_3.AutoSize = true;
		button_3.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_3.Image = Resources.JoinWindow_cmdok;
		button_3.ImageAlign = ContentAlignment.MiddleRight;
		button_3.Location = new Point(8, 520);
		button_3.Name = Class16.smethod_0(1648925748);
		button_3.Size = new Size(285, 32);
		button_3.TabIndex = 32;
		button_3.TabStop = false;
		button_3.Text = Class16.smethod_0(1648978128);
		button_3.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		radioButton_0.AutoSize = true;
		radioButton_0.Location = new Point(8, 48);
		radioButton_0.Name = Class16.smethod_0(1648978156);
		radioButton_0.Size = new Size(183, 17);
		radioButton_0.TabIndex = 34;
		radioButton_0.Text = Class16.smethod_0(1648978170);
		radioButton_0.UseVisualStyleBackColor = true;
		radioButton_0.CheckedChanged += radioButton_0_CheckedChanged;
		radioButton_1.AutoSize = true;
		radioButton_1.Location = new Point(6, 133);
		radioButton_1.Name = Class16.smethod_0(1648978210);
		radioButton_1.Size = new Size(167, 17);
		radioButton_1.TabIndex = 35;
		radioButton_1.Text = Class16.smethod_0(1648978234);
		radioButton_1.UseVisualStyleBackColor = true;
		radioButton_2.AutoSize = true;
		radioButton_2.Checked = true;
		radioButton_2.Location = new Point(8, 22);
		radioButton_2.Name = Class16.smethod_0(1648978278);
		radioButton_2.Size = new Size(197, 17);
		radioButton_2.TabIndex = 36;
		radioButton_2.TabStop = true;
		radioButton_2.Text = Class16.smethod_0(1648978289);
		radioButton_2.UseVisualStyleBackColor = true;
		checkBox_3.AutoSize = true;
		checkBox_3.Location = new Point(5, 58);
		checkBox_3.Name = Class16.smethod_0(1648978340);
		checkBox_3.Size = new Size(230, 17);
		checkBox_3.TabIndex = 37;
		checkBox_3.Text = Class16.smethod_0(1648978353);
		checkBox_3.UseVisualStyleBackColor = true;
		groupBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_1.Controls.Add(comboBox_0);
		groupBox_1.Controls.Add(textBox_0);
		groupBox_1.Controls.Add(groupBox_2);
		groupBox_1.Controls.Add(checkBox_3);
		groupBox_1.Location = new Point(8, 41);
		groupBox_1.Name = Class16.smethod_0(1648978400);
		groupBox_1.Size = new Size(573, 434);
		groupBox_1.TabIndex = 38;
		groupBox_1.TabStop = false;
		groupBox_1.Text = Class16.smethod_0(1648978424);
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Items.AddRange(new object[3]
		{
			Class16.smethod_0(1648973331),
			Class16.smethod_0(1648973354),
			Class16.smethod_0(1648973379)
		});
		comboBox_0.Location = new Point(5, 22);
		comboBox_0.Name = Class16.smethod_0(1648973409);
		comboBox_0.Size = new Size(243, 21);
		comboBox_0.TabIndex = 41;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		textBox_0.BackColor = Color.PaleGreen;
		textBox_0.Enabled = false;
		textBox_0.Location = new Point(254, 21);
		textBox_0.Name = Class16.smethod_0(1648929153);
		textBox_0.Size = new Size(311, 22);
		textBox_0.TabIndex = 47;
		toolTip_0.SetToolTip(textBox_0, Class16.smethod_0(1648973424));
		textBox_0.DoubleClick += textBox_0_DoubleClick;
		groupBox_2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_2.Controls.Add(radioButton_3);
		groupBox_2.Controls.Add(numericUpDown_0);
		groupBox_2.Controls.Add(numericUpDown_1);
		groupBox_2.Controls.Add(label_1);
		groupBox_2.Controls.Add(label_2);
		groupBox_2.Controls.Add(radioButton_2);
		groupBox_2.Controls.Add(radioButton_1);
		groupBox_2.Controls.Add(radioButton_0);
		groupBox_2.Controls.Add(groupBox_0);
		groupBox_2.Controls.Add(radioButton_4);
		groupBox_2.Controls.Add(checkedListBox_0);
		groupBox_2.Controls.Add(button_4);
		groupBox_2.Controls.Add(label_3);
		groupBox_2.Controls.Add(button_5);
		groupBox_2.Controls.Add(button_6);
		groupBox_2.Location = new Point(8, 82);
		groupBox_2.Name = Class16.smethod_0(1648973589);
		groupBox_2.Size = new Size(557, 346);
		groupBox_2.TabIndex = 46;
		groupBox_2.TabStop = false;
		groupBox_2.Text = Class16.smethod_0(1648973623);
		radioButton_3.AutoSize = true;
		radioButton_3.Location = new Point(6, 162);
		radioButton_3.Name = Class16.smethod_0(1648973648);
		radioButton_3.Size = new Size(332, 17);
		radioButton_3.TabIndex = 46;
		radioButton_3.Text = Class16.smethod_0(1648973679);
		radioButton_3.UseVisualStyleBackColor = true;
		numericUpDown_0.Location = new Point(472, 133);
		numericUpDown_0.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_0.Maximum = new decimal(new int[4] { 9999, 0, 0, 0 });
		numericUpDown_0.Name = Class16.smethod_0(1648973738);
		numericUpDown_0.Size = new Size(63, 22);
		numericUpDown_0.TabIndex = 45;
		numericUpDown_0.TextAlign = HorizontalAlignment.Center;
		numericUpDown_1.Location = new Point(372, 133);
		numericUpDown_1.Margin = new Padding(3, 4, 3, 4);
		numericUpDown_1.Maximum = new decimal(new int[4] { 9999, 0, 0, 0 });
		numericUpDown_1.Name = Class16.smethod_0(1648973767);
		numericUpDown_1.Size = new Size(63, 22);
		numericUpDown_1.TabIndex = 44;
		numericUpDown_1.TextAlign = HorizontalAlignment.Center;
		label_1.AutoSize = true;
		label_1.Location = new Point(441, 135);
		label_1.Name = Class16.smethod_0(1648912145);
		label_1.Size = new Size(21, 13);
		label_1.TabIndex = 43;
		label_1.Text = Class16.smethod_0(1648930211);
		label_2.Location = new Point(292, 135);
		label_2.Name = Class16.smethod_0(1648912083);
		label_2.Size = new Size(78, 16);
		label_2.TabIndex = 42;
		label_2.Text = Class16.smethod_0(1648973789);
		label_2.TextAlign = ContentAlignment.MiddleRight;
		groupBox_0.Controls.Add(checkBox_2);
		groupBox_0.Controls.Add(checkBox_1);
		groupBox_0.Controls.Add(button_0);
		groupBox_0.Controls.Add(textBox_1);
		groupBox_0.Controls.Add(checkBox_0);
		groupBox_0.Enabled = false;
		groupBox_0.Location = new Point(6, 50);
		groupBox_0.Name = Class16.smethod_0(1648973812);
		groupBox_0.Size = new Size(545, 77);
		groupBox_0.TabIndex = 48;
		groupBox_0.TabStop = false;
		groupBox_0.Text = Class16.smethod_0(1648929126);
		checkBox_2.AutoSize = true;
		checkBox_2.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_2.Location = new Point(289, 21);
		checkBox_2.Name = Class16.smethod_0(1648972802);
		checkBox_2.Size = new Size(113, 17);
		checkBox_2.TabIndex = 51;
		checkBox_2.Text = Class16.smethod_0(1648972831);
		checkBox_2.UseVisualStyleBackColor = true;
		checkBox_1.AutoSize = true;
		checkBox_1.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_1.Location = new Point(6, 49);
		checkBox_1.Name = Class16.smethod_0(1648972854);
		checkBox_1.Size = new Size(180, 17);
		checkBox_1.TabIndex = 50;
		checkBox_1.Text = Class16.smethod_0(1648972878);
		checkBox_1.UseVisualStyleBackColor = true;
		checkBox_1.CheckedChanged += checkBox_1_CheckedChanged;
		button_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_0.Enabled = false;
		button_0.Image = Resources.cmdBrowseElements3;
		button_0.Location = new Point(506, 45);
		button_0.Margin = new Padding(3, 4, 3, 4);
		button_0.Name = Class16.smethod_0(1648972905);
		button_0.Size = new Size(27, 22);
		button_0.TabIndex = 49;
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		textBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_1.Enabled = false;
		textBox_1.Location = new Point(264, 44);
		textBox_1.Margin = new Padding(3, 4, 3, 4);
		textBox_1.Name = Class16.smethod_0(1648972930);
		textBox_1.Size = new Size(239, 22);
		textBox_1.TabIndex = 48;
		checkBox_0.AutoSize = true;
		checkBox_0.Checked = true;
		checkBox_0.CheckState = CheckState.Checked;
		checkBox_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		checkBox_0.Location = new Point(6, 24);
		checkBox_0.Name = Class16.smethod_0(1648972957);
		checkBox_0.Size = new Size(278, 17);
		checkBox_0.TabIndex = 47;
		checkBox_0.Text = Class16.smethod_0(1648972981);
		checkBox_0.UseVisualStyleBackColor = true;
		radioButton_4.AutoSize = true;
		radioButton_4.Location = new Point(6, 185);
		radioButton_4.Name = Class16.smethod_0(1648973024);
		radioButton_4.Size = new Size(209, 17);
		radioButton_4.TabIndex = 49;
		radioButton_4.Text = Class16.smethod_0(1648973048);
		radioButton_4.UseVisualStyleBackColor = true;
		radioButton_4.CheckedChanged += radioButton_4_CheckedChanged;
		checkedListBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		checkedListBox_0.CheckOnClick = true;
		checkedListBox_0.Enabled = false;
		checkedListBox_0.Location = new Point(8, 233);
		checkedListBox_0.Name = Class16.smethod_0(1648973091);
		checkedListBox_0.Size = new Size(543, 89);
		checkedListBox_0.TabIndex = 50;
		button_4.Enabled = false;
		button_4.Location = new Point(292, 183);
		button_4.Name = Class16.smethod_0(1648973107);
		button_4.Size = new Size(120, 23);
		button_4.TabIndex = 51;
		button_4.Text = Class16.smethod_0(1648973135);
		button_4.UseVisualStyleBackColor = true;
		button_4.Click += button_4_Click;
		label_3.AutoSize = true;
		label_3.Location = new Point(9, 210);
		label_3.Name = Class16.smethod_0(1648973145);
		label_3.Size = new Size(464, 13);
		label_3.TabIndex = 52;
		label_3.Text = Class16.smethod_0(1648973173);
		label_3.Visible = false;
		button_5.Enabled = false;
		button_5.Location = new Point(8, 330);
		button_5.Name = Class16.smethod_0(1648973265);
		button_5.Size = new Size(120, 23);
		button_5.TabIndex = 53;
		button_5.Text = Class16.smethod_0(1648973290);
		button_5.UseVisualStyleBackColor = true;
		button_5.Click += button_5_Click;
		button_6.Enabled = false;
		button_6.Location = new Point(134, 330);
		button_6.Name = Class16.smethod_0(1648973307);
		button_6.Size = new Size(120, 23);
		button_6.TabIndex = 54;
		button_6.Text = Class16.smethod_0(1648972318);
		button_6.UseVisualStyleBackColor = true;
		button_6.Click += button_6_Click;
		progressBar_0.Location = new Point(8, 479);
		progressBar_0.Name = Class16.smethod_0(1648972329);
		progressBar_0.Size = new Size(573, 23);
		progressBar_0.TabIndex = 39;
		progressBar_1.Location = new Point(8, 504);
		progressBar_1.Name = Class16.smethod_0(1648972356);
		progressBar_1.Size = new Size(573, 13);
		progressBar_1.TabIndex = 40;
		base.AcceptButton = button_3;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.CancelButton = button_2;
		base.ClientSize = new Size(590, 556);
		base.Controls.Add(progressBar_1);
		base.Controls.Add(progressBar_0);
		base.Controls.Add(groupBox_1);
		base.Controls.Add(button_2);
		base.Controls.Add(button_3);
		base.Controls.Add(button_1);
		base.Controls.Add(textBox_2);
		base.Controls.Add(label_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.JoinWindow_Icon;
		base.Margin = new Padding(3, 4, 3, 4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648972375);
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648972384);
		// English help is the default; the PT-BR form catalog replaces it when selected.
		toolTip_0.AutoPopDelay = 12000;
		toolTip_0.SetToolTip(textBox_2, "Source elements.data file. Selected data is read from this file and imported into the file currently open in the editor.");
		toolTip_0.SetToolTip(button_1, "Choose the source elements.data file to import.");
		toolTip_0.SetToolTip(comboBox_0, "Choose whether to import all lists, selected lists, or NPC dialogs only.");
		toolTip_0.SetToolTip(checkBox_3, "Add source elements whose IDs do not exist in the corresponding list of the current file.");
		toolTip_0.SetToolTip(radioButton_2, "Replace every field of existing elements with matching IDs using values from the source file.");
		toolTip_0.SetToolTip(radioButton_0, "Import only localizable text fields of existing elements, preserving other data.");
		toolTip_0.SetToolTip(radioButton_1, "Import only the fields within the specified index range for elements with matching IDs.");
		toolTip_0.SetToolTip(numericUpDown_1, "First field index to import from the selected list.");
		toolTip_0.SetToolTip(numericUpDown_0, "Last field index to import. This index is included.");
		toolTip_0.SetToolTip(radioButton_3, "Do not change fields of existing elements. Enable adding missing elements to import only new IDs.");
		toolTip_0.SetToolTip(radioButton_4, "Choose fields by name instead of index. Select a list and load its fields first.");
		toolTip_0.SetToolTip(button_4, "Load field names for the chosen list from the source file.");
		toolTip_0.SetToolTip(checkedListBox_0, "Check the fields to import for elements with matching IDs.");
		toolTip_0.SetToolTip(button_5, "Check all loaded fields.");
		toolTip_0.SetToolTip(button_6, "Uncheck all loaded fields.");
		toolTip_0.SetToolTip(checkBox_0, "Preserve models and icons when importing localized text.");
		toolTip_0.SetToolTip(checkBox_2, "Keep NPC dialogs from the current file while importing text.");
		toolTip_0.SetToolTip(checkBox_1, "Compare values against a third file and change only matching values.");
		toolTip_0.SetToolTip(textBox_1, "Reference file used to compare existing values before importing new ones.");
		toolTip_0.SetToolTip(button_0, "Choose the reference file for value comparison.");
		toolTip_0.SetToolTip(button_3, "Start importing with the selected settings. Check the source file and list scope first.");
		toolTip_0.SetToolTip(button_2, "Close this window without starting an import.");
		base.FormClosing += JoinWindow_FormClosing;
		base.Shown += JoinWindow_Shown;
		groupBox_1.ResumeLayout(performLayout: false);
		groupBox_1.PerformLayout();
		groupBox_2.ResumeLayout(performLayout: false);
		groupBox_2.PerformLayout();
		((ISupportInitialize)numericUpDown_0).EndInit();
		((ISupportInitialize)numericUpDown_1).EndInit();
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
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

	private void button_3_Click(object sender, EventArgs e)
	{
		if (!File.Exists(textBox_2.Text))
		{
			TextStorage.TEXTS.ShowErrorMessage(454);
			GC.KeepAlive(this);
			return;
		}
		if (radioButton_4.Checked && checkedListBox_0.CheckedItems.Count == 0)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648972416), Class16.smethod_0(1648972458)), Class16.smethod_0(1648972516), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			GC.KeepAlive(this);
			return;
		}
		button_3.Enabled = false;
		if (radioButton_0.Checked && checkBox_0.Checked)
		{
			bool_1 = true;
		}
		Cursor = Cursors.WaitCursor;
		progressBar_0.Value = 1;
		ACE.Elements.eListCollection.eListCollection eListCollection2 = new ACE.Elements.eListCollection.eListCollection(textBox_2.Text, bMultithread: false);
		if (eListCollection2.Lists == null)
		{
			GC.KeepAlive(this);
			return;
		}
		ACE.Elements.eListCollection.eListCollection eListCollection3 = eListCollection_0;
		games_0 = eListCollection3.Game;
		if (eListCollection3.Game != eListCollection2.Game)
		{
			if (TextStorage.TEXTS.ShowQuestionMessage(455) == DialogResult.No)
			{
				Cursor = Cursors.Default;
				button_3.Enabled = true;
				progressBar_0.Value = 0;
				GC.KeepAlive(this);
				return;
			}
			games_0 = GAMES.UNKNOWN_GAME;
		}
		ACE.Elements.eListCollection.eListCollection eListCollection4 = null;
		int num = ((radioButton_0.Checked && checkBox_1 != null && File.Exists(textBox_1.Text)) ? 1 : 0);
		byte b = (byte)num;
		bool flag = b != 0;
		if (b != 0)
		{
			eListCollection4 = new ACE.Elements.eListCollection.eListCollection(textBox_1.Text, bMultithread: false);
		}
		progressBar_0.Value = 10;
		Enum8 selectedIndex = (Enum8)comboBox_0.SelectedIndex;
		bool flag2 = selectedIndex == (Enum8)0;
		int[] array = new int[0];
		if (flag2)
		{
			array = eListCollection_0.AllListsAndCoversations;
		}
		else if (selectedIndex == (Enum8)1)
		{
			array = eListCollection_0.ParseLists(textBox_0.Text);
			if (array == null)
			{
				TextStorage.TEXTS.ShowErrorMessage(883);
				Cursor = Cursors.Default;
				button_3.Enabled = true;
				progressBar_0.Value = 0;
				GC.KeepAlive(this);
				return;
			}
		}
		eListCollection3 = eListCollection_0;
		ACE.Elements.eListCollection.eListCollection eListCollection5 = eListCollection3;
		num = eListCollection5.GetItemsCount(eListCollection5.addons_l) - 1;
		eListCollection3 = eListCollection_0;
		ACE.Elements.eListCollection.eListCollection eListCollection6 = eListCollection3;
		int num2 = eListCollection6.getid(eListCollection6.addons_l, num);
		num2 = ((num2 < 2000) ? 2000 : num2);
		eListCollection3 = eListCollection_0;
		eListCollection3.Lists[eListCollection3.addons_l].UpdateIDsHashSet();
		bool flag3 = bool_1 && radioButton_0.Checked;
		bool flag4;
		object[] vars;
		if (flag4 = radioButton_2.Checked)
		{
			if (flag2)
			{
				eListCollection_0.ActionsHistory.stChangeElements(141);
			}
			else
			{
				vars = new object[0];
				eListCollection_0.ActionsHistory.stChangeLists(array, 141, vars);
			}
		}
		else if (!flag3)
		{
			vars = new object[0];
			eListCollection_0.ActionsHistory.SubStagesBegin(-1, null, 141, vars);
		}
		int num3 = 0;
		int num4 = 0;
		List<string> list = new List<string>();
		vars = new object[2] { eListCollection2.FileName, eListCollection_0.FileName };
		string item = TextStorage.TEXTS.GetText(Class16.smethod_0(1648972541), vars);
		list.Add(item);
		int num5 = 0;
		int num6 = 0;
		string text7;
		if (0 < (nint)array.LongLength)
		{
			do
			{
				int num7 = array[num6];
				item = eListCollection_0.Lists[num7].uListName;
				int num8 = eListCollection2.get_LI(item);
				if (num8 != -1)
				{
					ACE.Elements.eList.eList eList2 = eListCollection2[item];
					if (eList2 != null)
					{
						eListCollection3 = eListCollection_0;
						if (num7 != eListCollection3.ConversationListIndex)
						{
							vars = new object[1];
							ACE.Elements.eList.eList eList3 = eListCollection3.Lists[num7];
							string text = ((!ACE.RSGlobal.RSGlobal.SHOW_UNIVERSAL_NAMES) ? eList3.ListName : eList3.uListName);
							string text2 = Class16.smethod_0(1648924347);
							vars[0] = string.Concat(string.Concat(Class16.smethod_0(1648924364) + num7, text2), text);
							text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648972564), vars);
							list.Add(text2);
							if (item == Class16.smethod_0(1648972579) && games_0 == GAMES.PW)
							{
								short version = eListCollection_0.Version;
								if (version == 27 || version == 28 || version == 29)
								{
									goto IL_038a;
								}
							}
							int num9 = array.Length;
							if (num5 <= 0)
							{
								num9 = 0;
							}
							else if (num9 <= 0)
							{
								num9 = 100;
							}
							else
							{
								num9 = 1 - (int)((double)num5 / (double)num9 * -99.0);
								num9 = ((num9 > 100) ? 100 : num9);
							}
							progressBar_0.Value = num9;
							num5++;
							progressBar_1.Value = 0;
							num9 = 0;
							if (0 < eList2.ItemCount)
							{
								do
								{
									num = (int)((double)(float)num9 / (double)(float)eListCollection2[item].ItemCount * 100.0);
									if (progressBar_1.Value != num)
									{
										progressBar_1.Value = num;
										Application.DoEvents();
									}
									ACE.Elements.eListCollection.eListCollection eListCollection7 = eListCollection_0;
									vars = method_3(eListCollection2[item], eListCollection7[item], num9);
									if (!bool_1 && games_0 == GAMES.PW && item == Class16.smethod_0(1648923286))
									{
										if (((!(vars[11].GetType() == typeof(int))) ? ((int)(uint)vars[11]) : ((int)vars[11])) > num2)
										{
											vars[11] = 672;
										}
										if (((!(vars[12].GetType() == typeof(int))) ? ((int)(uint)vars[12]) : ((int)vars[12])) > num2)
										{
											vars[12] = 673;
										}
									}
									bool flag5 = false;
									text2 = eListCollection2.GetItemID(num8, num9);
									int num10 = eListCollection_0.FindItemIndexByID(num7, text2);
									bool flag6 = false;
									if (num10 > -1)
									{
										if (!radioButton_3.Checked)
										{
											if (!flag4)
											{
												if (!flag3)
												{
													int[] itemsindices = new int[1] { num10 };
													eListCollection_0.ActionsHistory.stChangeItems(num7, itemsindices, null, null, -1);
													flag6 = true;
												}
												goto IL_056a;
											}
										}
										else if (!flag4)
										{
											goto IL_056a;
										}
										if (games_0 == GAMES.PW && flag2 && item == Class16.smethod_0(1648972702))
										{
											eListCollection3 = eListCollection_0;
											if (eListCollection2.Version < eListCollection3.Version)
											{
												eList3 = eListCollection3.Lists[num7];
												int nameFieldIndex = eList3.NameFieldIndex;
												eList3.elementValues[num10][nameFieldIndex] = vars[nameFieldIndex];
												goto IL_0beb;
											}
										}
										vars.CopyTo(eListCollection_0.Lists[num7].elementValues[num10], 0);
										goto IL_0beb;
									}
									if (checkBox_3.Checked)
									{
										if (!flag4 && !flag3)
										{
											int[] selecteditems_before = new int[1];
											int itemsCount = eListCollection_0.GetItemsCount(num7);
											int[] itemsindices2 = new int[1] { itemsCount };
											eListCollection_0.ActionsHistory.stAddItems(num7, itemsindices2, selecteditems_before, -1);
											flag6 = true;
										}
										int num11 = (int)((nint)vars.LongLength - 1);
										vars[num11] = new object();
										eListCollection_0.AddItem(num7, vars);
										num4++;
										int num12 = (int)vars[0];
										string text3 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648972648));
										object obj = vars[eListCollection_0.Lists[num7].NameFieldIndex];
										string text4 = Class16.smethod_0(1648942211);
										string text5 = Class16.smethod_0(1648902346);
										string text6 = Class16.smethod_0(1648904383);
										text7 = Class16.smethod_0(1648929947);
										list.Add(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(text7 + num4, text6), text3), text5), num12.ToString()), text4), ACE.RSGlobal.RSGlobal.ToStringW((byte[])obj)));
										goto IL_0bcc;
									}
									goto IL_0cb9;
									IL_0bcc:
									if (flag6 && !flag3)
									{
										eListCollection_0.ActionsHistory.Complete();
									}
									if (flag5)
									{
										goto IL_0beb;
									}
									goto IL_0cb9;
									IL_0cb9:
									num9++;
									continue;
									IL_056a:
									if (radioButton_0.Checked)
									{
										object[] array2 = null;
										int num13;
										if (flag)
										{
											num13 = eListCollection4.get_LI(item);
											num13 = eListCollection4.FindItemIndexByID(num13, text2);
											if (num13 > -1)
											{
												eListCollection7 = eListCollection_0;
												array2 = method_3(eListCollection4[item], eListCollection7[item], num13);
											}
										}
										num13 = 1;
										if (1 < eListCollection_0.GetFieldsCount(num7))
										{
											while (num13 <= (nint)vars.LongLength - 1 && num13 <= (nint)eListCollection2[item].elementTypes.LongLength - 1)
											{
												if (eListCollection_0.Lists[num7].elementTypes[num13].Contains(Class16.smethod_0(1648902792)) && vars[num13].GetType() == typeof(byte[]))
												{
													if (!bool_1)
													{
														goto IL_0672;
													}
													if (eListCollection_0.IsLocalizableField(num7, num13))
													{
														string text8 = Class16.smethod_0(1648972610);
														if (!(eListCollection2.GetRealItemName(num8, num9) == text8))
														{
															goto IL_0672;
														}
													}
												}
												goto IL_078c;
												IL_0672:
												object[] array3 = eListCollection_0.Lists[num7].elementValues[num10];
												if (num7 != 0 && flag && array2 != null)
												{
													string text9 = ACE.RSGlobal.RSGlobal.ToStringW((byte[])array3[num13]);
													string text10 = ACE.RSGlobal.RSGlobal.ToStringW((byte[])array2[num13]);
													if (text9 != text10)
													{
														array3 = new object[3] { text2, num13, text9 };
														text10 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648972625), array3);
														list.Add(text10);
														goto IL_078c;
													}
												}
												object obj2 = array3[num13];
												object obj3 = vars[num13];
												if ((nint)((byte[])obj3).LongLength == (nint)((byte[])obj2).LongLength)
												{
													array3[num13] = (byte[])obj3;
												}
												else
												{
													int length = (((nint)((byte[])obj3).LongLength >= (nint)((byte[])obj2).LongLength) ? ((byte[])obj2).Length : ((byte[])obj3).Length);
													array3[num13] = new byte[(nint)((byte[])obj2).LongLength];
													Array.Copy((byte[])vars[num13], (byte[])array3[num13], length);
												}
												flag5 = true;
												goto IL_078c;
												IL_078c:
												num13++;
												if (num13 >= eListCollection_0.GetFieldsCount(num7))
												{
													break;
												}
											}
										}
									}
									else if (radioButton_1.Checked)
									{
										int num14 = (int)numericUpDown_1.Value;
										decimal value = numericUpDown_0.Value;
										if (num14 <= (int)value)
										{
											while (num14 <= eListCollection_0.GetFieldsCount(num7) - 1 && num14 <= (nint)vars.LongLength - 1)
											{
												eListCollection_0.Lists[num7].elementValues[num10][num14] = vars[num14];
												flag5 = true;
												num14++;
												value = numericUpDown_0.Value;
												if (num14 > (int)value)
												{
													break;
												}
											}
										}
									}
									else if (radioButton_4.Checked)
									{
										List<string> list2 = method_4();
										if (list2.Count > 0)
										{
											ACE.Elements.eList.eList eList4 = eListCollection2[item];
											ACE.Elements.eList.eList eList5 = eListCollection_0.Lists[num7];
											object[] array4 = eList4.elementValues[num9];
											foreach (string item2 in list2)
											{
												int num15 = method_5(eList4, item2);
												int num16 = method_5(eList5, item2);
												if (num15 < 0 || num16 < 0 || num15 >= array4.Length || num16 >= eListCollection_0.Lists[num7].elementValues[num10].Length)
												{
													continue;
												}
												object obj4 = array4[num15];
												string text11 = eList4.elementTypes[num15];
												string text12 = eList5.elementTypes[num16];
												if (text11 == text12)
												{
													eListCollection_0.Lists[num7].elementValues[num10][num16] = obj4;
												}
												else if (text11.Contains(Class16.smethod_0(1648902792)) && text12.Contains(Class16.smethod_0(1648902792)))
												{
													if (obj4 is byte[] array5)
													{
														byte[] array6 = new byte[array5.Length];
														Array.Copy(array5, array6, array5.Length);
														eListCollection_0.Lists[num7].elementValues[num10][num16] = array6;
													}
													else
													{
														eListCollection_0.Lists[num7].elementValues[num10][num16] = obj4;
													}
												}
												else
												{
													eListCollection_0.Lists[num7].elementValues[num10][num16] = obj4;
												}
												flag5 = true;
											}
										}
									}
									goto IL_0bcc;
									IL_0beb:
									eListCollection_0.ItemChanged(num7, num10);
									num3++;
									if (!flag)
									{
										int num17 = (int)vars[0];
										text7 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648972679));
										object obj5 = vars[eListCollection_0.Lists[num7].NameFieldIndex];
										string text13 = Class16.smethod_0(1648942211);
										string text14 = Class16.smethod_0(1648902346);
										string text15 = Class16.smethod_0(1648904383);
										list.Add(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(Class16.smethod_0(1648929947) + num3, text15), text7), text14), num17.ToString()), text13), ACE.RSGlobal.RSGlobal.ToStringW((byte[])obj5)));
									}
									goto IL_0cb9;
								}
								while (num9 < eList2.ItemCount);
							}
							eListCollection_0.ItemsCache[num7] = null;
						}
					}
				}
				goto IL_038a;
				IL_038a:
				num6++;
			}
			while (num6 < (nint)array.LongLength);
		}
		if (!checkBox_2.Checked && eListCollection_0.ConversationListIndex != 999 && eListCollection2.ConversationListIndex != 999 && (selectedIndex == (Enum8)2 || ((radioButton_2.Checked || radioButton_0.Checked) && selectedIndex == (Enum8)0)))
		{
			eListCollection3 = eListCollection_0;
			int conversationListIndex = eListCollection3.ConversationListIndex;
			int conversationListIndex2 = eListCollection2.ConversationListIndex;
			eListCollection3.Lists[conversationListIndex].elementTypes = eListCollection2.Lists[conversationListIndex2].elementTypes;
			eListCollection_0.Lists[conversationListIndex].elementValues = eListCollection2.Lists[conversationListIndex2].elementValues;
			num3++;
			text7 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648972679));
			string listName = eListCollection_0.Lists[conversationListIndex].ListName;
			string text16 = Class16.smethod_0(1648902346);
			string text17 = Class16.smethod_0(1648904383);
			list.Add(string.Concat(string.Concat(string.Concat(string.Concat(Class16.smethod_0(1648929947) + num3, text17), text7), text16), listName));
		}
		if (flag4)
		{
			eListCollection_0.ActionsHistory.Complete();
		}
		else if (!flag3)
		{
			eListCollection_0.ActionsHistory.SubStagesComplete(-1, null);
		}
		object[] vars2;
		if (bool_1)
		{
			text7 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648972726));
		}
		else
		{
			vars2 = new object[2] { num3, num4 };
			text7 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648972749), vars2);
		}
		vars2 = new object[1] { text7 };
		if (TextStorage.TEXTS.ShowMessage(458, MessageBoxButtons.YesNo, MessageBoxIcon.Question, vars2) == DialogResult.Yes)
		{
			vars2 = new object[2] { num3, num4 };
			text7 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648972772), vars2);
			list.Add(text7);
			text7 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648972787));
			list.Add(text7);
			text7 = Class16.smethod_0(1648971786);
			text7 = System.IO.Path.GetTempPath() + text7;
			File.WriteAllLines(text7, list, Encoding.UTF8);
			if (File.Exists(text7))
			{
				string text18 = Class16.smethod_0(1648904453);
				text7 = string.Concat(text18 + text7, text18);
				ACE.RSGlobal.RSGlobal.ShellP(Class16.smethod_0(1648971820), text7, waitForExit: false);
			}
		}
		list.Clear();
		eListCollection2.Close(bCollectGarbage: true, bSafetyCleaning: true);
		bool_1 = false;
		eListCollection_0.Addons?.Refresh();
		bool_0 = true;
		progressBar_0.Value = 0;
		progressBar_1.Value = 0;
		Cursor = Cursors.Default;
		button_3.Enabled = true;
		GC.KeepAlive(this);
	}

	private object[] method_3(ACE.Elements.eList.eList eList_0, ACE.Elements.eList.eList eList_1, int int_1)
	{
		ACE.Elements.eList.eList eList2 = eListCollection_0.Lists[0];
		object[] item = eList_0.elementValues[int_1];
		object[] result = ACE.Elements.eListCollection.eListCollection.ConvertItem(eList_0, eList_1, item, eList2.IDsHashSet);
		GC.KeepAlive(this);
		return result;
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void JoinWindow_Shown(object sender, EventArgs e)
	{
		if (bool_1)
		{
			radioButton_0.Checked = true;
			checkBox_0.Checked = true;
			button_1_Click(null, null);
			if (File.Exists(textBox_2.Text))
			{
				button_3_Click(null, null);
			}
		}
	}

	private void radioButton_0_CheckedChanged(object sender, EventArgs e)
	{
		groupBox_0.Enabled = radioButton_0.Checked;
		GC.KeepAlive(this);
	}

	private void JoinWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (bool_0)
		{
			base.DialogResult = DialogResult.OK;
		}
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		byte b = ((comboBox_0.SelectedIndex == 1) ? ((byte)1) : ((byte)0));
		textBox_0.Enabled = b != 0;
		byte b2 = ((comboBox_0.SelectedIndex != 2) ? ((byte)1) : ((byte)0));
		groupBox_2.Enabled = b2 != 0;
		GC.KeepAlive(this);
	}

	private void checkBox_1_CheckedChanged(object sender, EventArgs e)
	{
		textBox_1.Enabled = checkBox_1.Checked;
		button_0.Enabled = checkBox_1.Checked;
		GC.KeepAlive(this);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1648978011);
		if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			textBox_1.Text = openFileDialog.FileName;
		}
		GC.KeepAlive(this);
	}

	private void textBox_0_DoubleClick(object sender, EventArgs e)
	{
		commonStorage_0.ResetBuffer();
		CommonStorage.iarr1 = eListCollection_0.ParseLists(textBox_0.Text);
		Size maxWSize = new Size(900, 900);
		if (ListBoxWindow.ShowSelectListDialog(this, maxWSize, eListCollection_0.GetListNames(bIncludeConversations: true), 0, bMultiplieSelection: true) == DialogResult.OK)
		{
			int[] allListsAndCoversations = eListCollection_0.AllListsAndCoversations;
			List<string> list = new List<string>(CommonStorage.iarr1.Length);
			int[] iarr = CommonStorage.iarr1;
			int num = 0;
			if (0 < (nint)iarr.LongLength)
			{
				do
				{
					ACE.Elements.eList.eList eList2 = eListCollection_0.Lists[allListsAndCoversations[iarr[num]]];
					string item = ((!ACE.RSGlobal.RSGlobal.SHOW_UNIVERSAL_NAMES) ? eList2.ListName : eList2.uListName);
					list.Add(item);
					num++;
				}
				while (num < (nint)iarr.LongLength);
			}
			textBox_0.Text = string.Join(Class16.smethod_0(1648898262), list);
		}
		GC.KeepAlive(this);
	}

	private void radioButton_4_CheckedChanged(object sender, EventArgs e)
	{
		bool flag = radioButton_4.Checked;
		button_4.Enabled = flag;
		checkedListBox_0.Enabled = flag;
		label_3.Visible = flag;
		button_5.Enabled = flag && checkedListBox_0.Items.Count > 0;
		button_6.Enabled = flag && checkedListBox_0.Items.Count > 0;
		GC.KeepAlive(this);
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		try
		{
			checkedListBox_0.Items.Clear();
			list_0.Clear();
			int_0 = -1;
			if (!File.Exists(textBox_2.Text))
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648971838), Class16.smethod_0(1648971875)), Class16.smethod_0(1648971940), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			string text = textBox_0.Text.Trim();
			if (string.IsNullOrEmpty(text))
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648971953), Class16.smethod_0(1648971995)), Class16.smethod_0(1648972070), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			string[] array = text.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length == 0)
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648972094), Class16.smethod_0(1648972129)), Class16.smethod_0(1648972169), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			string text2 = array[0].Trim();
			Cursor = Cursors.WaitCursor;
			ACE.Elements.eListCollection.eListCollection eListCollection2 = new ACE.Elements.eListCollection.eListCollection(textBox_2.Text, bMultithread: false);
			if (eListCollection2.Lists == null)
			{
				Cursor = Cursors.Default;
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648972196), Class16.smethod_0(1648972234)), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			int num = eListCollection2.get_LI(text2);
			if (num == -1)
			{
				if (int.TryParse(text2, out var result) && result >= 0 && result < eListCollection2.Lists.Length)
				{
					num = result;
				}
				else
				{
					for (int i = 0; i < eListCollection2.Lists.Length; i++)
					{
						if (eListCollection2.Lists[i].ListName.Equals(text2, StringComparison.OrdinalIgnoreCase) || eListCollection2.Lists[i].uListName.Equals(text2, StringComparison.OrdinalIgnoreCase))
						{
							num = i;
							break;
						}
					}
					if (num == -1)
					{
						eListCollection2.Close(bCollectGarbage: false, bSafetyCleaning: false);
						Cursor = Cursors.Default;
						DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648972285), Class16.smethod_0(1648975397)), text2), Class16.smethod_0(1648975518), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
				}
			}
			int_0 = num;
			ACE.Elements.eList.eList eList2 = eListCollection2.Lists[num];
			int fieldsCount = eListCollection2.GetFieldsCount(num);
			if (fieldsCount > 1)
			{
				for (int j = 1; j < fieldsCount; j++)
				{
					string fieldName = eList2.GetFieldName(j);
					string text3 = ((j < eList2.elementTypes.Length) ? eList2.elementTypes[j] : Class16.smethod_0(1648908791));
					checkedListBox_0.Items.Add(fieldName + Class16.smethod_0(1648899468) + text3 + Class16.smethod_0(1648942897), isChecked: false);
				}
				button_5.Enabled = true;
				button_6.Enabled = true;
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648975531), Class16.smethod_0(1648975581)), checkedListBox_0.Items.Count, eList2.ListName), Class16.smethod_0(1648975727), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648975739), Class16.smethod_0(1648975778)), eList2.ListName), Class16.smethod_0(1648975823), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			eListCollection2.Close(bCollectGarbage: false, bSafetyCleaning: false);
			Cursor = Cursors.Default;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648975839));
			Cursor = Cursors.Default;
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648974855), Class16.smethod_0(1648974883)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		GC.KeepAlive(this);
	}

	private List<string> method_4()
	{
		List<string> list = new List<string>();
		try
		{
			foreach (object checkedItem in checkedListBox_0.CheckedItems)
			{
				string text = checkedItem.ToString();
				int num = text.IndexOf('(');
				if (num > 0)
				{
					string text2 = text.Substring(0, num).Trim();
					if (!string.IsNullOrEmpty(text2))
					{
						list.Add(text2);
					}
				}
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648974915));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648974954), Class16.smethod_0(1648975012)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return list;
	}

	private int method_5(ACE.Elements.eList.eList eList_0, string string_0)
	{
		try
		{
			string[] elementTypes = eList_0.elementTypes;
			int num = ((elementTypes != null) ? elementTypes.Length : 0);
			if (num > 0)
			{
				for (int i = 0; i < num; i++)
				{
					string fieldName = eList_0.GetFieldName(i);
					if (fieldName == string_0)
					{
						return i;
					}
				}
			}
		}
		catch
		{
		}
		return -1;
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		try
		{
			for (int i = 0; i < checkedListBox_0.Items.Count; i++)
			{
				checkedListBox_0.SetItemChecked(i, value: true);
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648975050));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648975088), Class16.smethod_0(1648975130)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		GC.KeepAlive(this);
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		try
		{
			for (int i = 0; i < checkedListBox_0.Items.Count; i++)
			{
				checkedListBox_0.SetItemChecked(i, value: false);
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648975050));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648975168), Class16.smethod_0(1648975220)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		GC.KeepAlive(this);
	}
}
