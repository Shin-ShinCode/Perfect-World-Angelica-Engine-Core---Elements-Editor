using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eListCollection;
using ACE.License;
using ACE.Properties;

namespace ACE.Protectors;

public class ElementsPermissionsEditor : Form
{
	private eListCollection eListCollection_0;

	private GroupBox groupBox_0;

	private RadioButton radioButton_0;

	private RadioButton radioButton_1;

	private TextBox textBox_0;

	private GroupBox groupBox_1;

	private GroupBox groupBox_2;

	private Button button_0;

	private Button button_1;

	private DataGridView dataGridView_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private GroupBox groupBox_3;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private CommonStorage commonStorage_0;

	private Button button_2;

	private Button button_3;

	public Container components;

	public ElementsPermissionsEditor(eListCollection eLC, CommonStorage CStorage)
	{
		try
		{
			method_1();
			commonStorage_0 = CStorage;
			eListCollection_0 = eLC;
			TextStorage.TEXTS.SetFormLanguage(this, null);
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			if (base.IsHandleCreated)
			{
				TDark.ApplyImmersiveDarkMode(base.Handle, TDark.IsDarkMode);
			}
			TDark.ApplyNativeDarkThemeRecursive(this);
			if (!CommonStorage.License.Special.ElProtectionByLogin)
			{
				eLC.ProtectionStatus = ELEMENTS_PROTECTION_STATUS.UNPROTECTED;
			}
			byte b = ((eLC.ProtectionStatus == ELEMENTS_PROTECTION_STATUS.PROTECTED_BY_LOGIN) ? ((byte)1) : ((byte)0));
			radioButton_0.Checked = b != 0;
			if (eLC.AllowedLogins != null)
			{
				string staticUserName = CommonStorage.License.GetStaticUserName();
				string[] allowedLogins = eLC.AllowedLogins;
				if (allowedLogins != null && allowedLogins.Length != 0 && Array.IndexOf(allowedLogins, staticUserName) > -1)
				{
					goto IL_00d5;
				}
			}
			if (CommonStorage.License.Licenses.IgnoreElProtectionByLogin)
			{
				goto IL_00d5;
			}
			textBox_0.Text = CommonStorage.License.GetStaticUserName();
			goto IL_0153;
			IL_0153:
			if (CommonStorage.License.Licenses.IgnoreElProtectionByLogin)
			{
				textBox_0.ReadOnly = false;
			}
			GC.KeepAlive(this);
			return;
			IL_00d5:
			textBox_0.Text = ((eLC.AllowedLogins == null || eLC.AllowedLogins.Length == 0) ? CommonStorage.License.GetStaticUserName() : eLC.AllowedLogins[0]);
			if (eLC.AllowedLogins != null)
			{
				int num = 1;
				if (1 < (nint)eLC.AllowedLogins.LongLength)
				{
					do
					{
						object[] values = new object[1] { eLC.AllowedLogins[num] };
						dataGridView_0.Rows.Add(values);
						num++;
					}
					while (num < (nint)eLC.AllowedLogins.LongLength);
				}
			}
			goto IL_0153;
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void ElementsPermissionsEditor_Shown(object sender, EventArgs e)
	{
	}

	private void radioButton_0_CheckedChanged(object sender, EventArgs e)
	{
		byte b;
		if (radioButton_0.Checked)
		{
			if (CommonStorage.License.Special.ElProtectionByLogin)
			{
				groupBox_3.Enabled = true;
				checkBox_1.Checked = eListCollection_0.IsUsersCanEditPermissions;
				eListCollection eListCollection2 = eListCollection_0;
				if (!eListCollection2.IsUsersCanEditPermissions)
				{
					string[] allowedLogins = eListCollection2.AllowedLogins;
					if (allowedLogins != null && (nint)allowedLogins.LongLength >= 2 && !(eListCollection_0.AllowedLogins[0] == CommonStorage.License.GetStaticUserName()))
					{
						b = 0;
						goto IL_008b;
					}
				}
				b = 1;
				goto IL_008b;
			}
			radioButton_1.Checked = true;
		}
		goto IL_010f;
		IL_008b:
		groupBox_2.Enabled = b != 0;
		checkBox_1.Enabled = groupBox_2.Enabled;
		byte b2 = (byte)((CommonStorage.License.Special.PW.ElCorruption && eListCollection_0.IsElementsEncrypted) ? 1u : 0u);
		checkBox_0.Checked = b2 != 0;
		if (checkBox_0.Checked)
		{
			checkBox_0.Enabled = true;
		}
		goto IL_010f;
		IL_010f:
		GC.KeepAlive(this);
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		if (CommonStorage.License.Special.ElProtectionByLogin)
		{
			if (radioButton_1.Checked)
			{
				eListCollection_0.ProtectionStatus = ELEMENTS_PROTECTION_STATUS.UNPROTECTED;
			}
			else if (radioButton_0.Checked)
			{
				eListCollection_0.ProtectionStatus = ELEMENTS_PROTECTION_STATUS.PROTECTED_BY_LOGIN;
			}
			List<string> list = new List<string>();
			int num = 0;
			if (0 < dataGridView_0.RowCount)
			{
				do
				{
					string text = (string)dataGridView_0.Rows[num].Cells[0].Value;
					if (!string.IsNullOrEmpty(text))
					{
						list.Add(LICENSE_INFO.GetStaticUserName(text));
					}
					num++;
				}
				while (num < dataGridView_0.RowCount);
			}
			int num2 = list.Count + 1;
			eListCollection_0.AllowedLogins = new string[num2];
			eListCollection_0.AllowedLogins[0] = textBox_0.Text;
			string[] allowedLogins = eListCollection_0.AllowedLogins;
			Array.Copy(list.ToArray(), 0, allowedLogins, 1, list.Count);
			eListCollection_0.IsElementsEncrypted = checkBox_0.Checked;
			eListCollection_0.IsUsersCanEditPermissions = checkBox_1.Checked;
			base.DialogResult = DialogResult.OK;
		}
		Close();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		dataGridView_0.Rows.Add();
		GC.KeepAlive(this);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		try
		{
			if (dataGridView_0.SelectedRows.Count > 0 && dataGridView_0.RowCount > 1)
			{
				DataGridView dataGridView = dataGridView_0;
				dataGridView_0.Rows.RemoveAt(dataGridView.SelectedRows[0].Index);
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649175136));
		}
		GC.KeepAlive(this);
	}

	private void radioButton_1_CheckedChanged(object sender, EventArgs e)
	{
		if (radioButton_1.Checked)
		{
			groupBox_2.Enabled = false;
			groupBox_3.Enabled = false;
		}
		GC.KeepAlive(this);
	}

	private void radioButton_0_Click(object sender, EventArgs e)
	{
	}

	private void method_0()
	{
		((IDisposable)components)?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_1()
	{
		new ComponentResourceManager(typeof(ElementsPermissionsEditor));
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		button_2 = new Button();
		button_3 = new Button();
		groupBox_0 = new GroupBox();
		textBox_0 = new TextBox();
		radioButton_0 = new RadioButton();
		radioButton_1 = new RadioButton();
		groupBox_1 = new GroupBox();
		groupBox_3 = new GroupBox();
		checkBox_0 = new CheckBox();
		checkBox_1 = new CheckBox();
		groupBox_2 = new GroupBox();
		button_0 = new Button();
		button_1 = new Button();
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		groupBox_0.SuspendLayout();
		groupBox_1.SuspendLayout();
		groupBox_3.SuspendLayout();
		groupBox_2.SuspendLayout();
		((ISupportInitialize)dataGridView_0).BeginInit();
		SuspendLayout();
		button_2.AutoSize = true;
		button_2.DialogResult = DialogResult.Cancel;
		button_2.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_2.Image = Resources.ElementsPermissionsEditor_cmdcancel;
		button_2.ImageAlign = ContentAlignment.MiddleRight;
		Point location = new Point(149, 482);
		button_2.Location = location;
		button_2.Name = Class16.smethod_0(1648925752);
		Size size = new Size(134, 25);
		button_2.Size = size;
		button_2.TabIndex = 35;
		button_2.TabStop = false;
		button_2.Text = Class16.smethod_0(1648941799);
		button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		button_3.AutoSize = true;
		button_3.DialogResult = DialogResult.OK;
		button_3.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_3.Image = Resources.cmdApply;
		button_3.ImageAlign = ContentAlignment.MiddleRight;
		Point location2 = new Point(9, 482);
		button_3.Location = location2;
		button_3.Name = Class16.smethod_0(1649188556);
		Size size2 = new Size(134, 25);
		button_3.Size = size2;
		button_3.TabIndex = 34;
		button_3.TabStop = false;
		button_3.Text = Class16.smethod_0(1648996201);
		button_3.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		TextBox value = textBox_0;
		groupBox_0.Controls.Add(value);
		groupBox_0.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location3 = new Point(6, 7);
		groupBox_0.Location = location3;
		groupBox_0.Name = Class16.smethod_0(1649175200);
		Size size3 = new Size(268, 44);
		groupBox_0.Size = size3;
		groupBox_0.TabIndex = 37;
		groupBox_0.TabStop = false;
		groupBox_0.Text = Class16.smethod_0(1649175223);
		textBox_0.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
		Point location4 = new Point(5, 15);
		textBox_0.Location = location4;
		textBox_0.Name = Class16.smethod_0(1649175227);
		textBox_0.ReadOnly = true;
		Size size4 = new Size(258, 23);
		textBox_0.Size = size4;
		textBox_0.TabIndex = 41;
		textBox_0.TextAlign = HorizontalAlignment.Center;
		radioButton_0.Appearance = Appearance.Button;
		radioButton_0.AutoSize = true;
		radioButton_0.Image = Resources.radProtect;
		Point location5 = new Point(3, 335);
		radioButton_0.Location = location5;
		radioButton_0.Name = Class16.smethod_0(1649173724);
		Size size5 = new Size(134, 134);
		radioButton_0.Size = size5;
		radioButton_0.TabIndex = 38;
		radioButton_0.UseVisualStyleBackColor = true;
		radioButton_0.CheckedChanged += radioButton_0_CheckedChanged;
		radioButton_0.Click += radioButton_0_Click;
		radioButton_1.Appearance = Appearance.Button;
		radioButton_1.AutoSize = true;
		radioButton_1.Checked = true;
		radioButton_1.Image = Resources.radUnprotect;
		Point location6 = new Point(143, 335);
		radioButton_1.Location = location6;
		radioButton_1.Name = Class16.smethod_0(1649173741);
		Size size6 = new Size(134, 134);
		radioButton_1.Size = size6;
		radioButton_1.TabIndex = 39;
		radioButton_1.TabStop = true;
		radioButton_1.UseVisualStyleBackColor = true;
		radioButton_1.CheckedChanged += radioButton_1_CheckedChanged;
		GroupBox value2 = groupBox_3;
		groupBox_1.Controls.Add(value2);
		GroupBox value3 = groupBox_2;
		groupBox_1.Controls.Add(value3);
		RadioButton value4 = radioButton_1;
		groupBox_1.Controls.Add(value4);
		GroupBox value5 = groupBox_0;
		groupBox_1.Controls.Add(value5);
		RadioButton value6 = radioButton_0;
		groupBox_1.Controls.Add(value6);
		Point location7 = new Point(6, 0);
		groupBox_1.Location = location7;
		groupBox_1.Name = Class16.smethod_0(1648929126);
		Size size7 = new Size(280, 476);
		groupBox_1.Size = size7;
		groupBox_1.TabIndex = 40;
		groupBox_1.TabStop = false;
		CheckBox value7 = checkBox_0;
		groupBox_3.Controls.Add(value7);
		CheckBox value8 = checkBox_1;
		groupBox_3.Controls.Add(value8);
		groupBox_3.Enabled = false;
		Point location8 = new Point(6, 277);
		groupBox_3.Location = location8;
		groupBox_3.Name = Class16.smethod_0(1648995906);
		Size size8 = new Size(268, 53);
		groupBox_3.Size = size8;
		groupBox_3.TabIndex = 41;
		groupBox_3.TabStop = false;
		groupBox_3.Text = Class16.smethod_0(1649175243);
		checkBox_0.AutoSize = true;
		checkBox_0.Enabled = false;
		Point location9 = new Point(3, 34);
		checkBox_0.Location = location9;
		checkBox_0.Name = Class16.smethod_0(1649175257);
		Size size9 = new Size(180, 17);
		checkBox_0.Size = size9;
		checkBox_0.TabIndex = 1;
		checkBox_0.Text = Class16.smethod_0(1649175282);
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_1.AutoSize = true;
		Point location10 = new Point(3, 16);
		checkBox_1.Location = location10;
		checkBox_1.Name = Class16.smethod_0(1649175315);
		Size size10 = new Size(243, 17);
		checkBox_1.Size = size10;
		checkBox_1.TabIndex = 0;
		checkBox_1.Text = Class16.smethod_0(1649175359);
		checkBox_1.UseVisualStyleBackColor = true;
		Button value9 = button_0;
		groupBox_2.Controls.Add(value9);
		Button value10 = button_1;
		groupBox_2.Controls.Add(value10);
		DataGridView value11 = dataGridView_0;
		groupBox_2.Controls.Add(value11);
		groupBox_2.Enabled = false;
		groupBox_2.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Point location11 = new Point(6, 53);
		groupBox_2.Location = location11;
		groupBox_2.Name = Class16.smethod_0(1649175396);
		Size size11 = new Size(268, 222);
		groupBox_2.Size = size11;
		groupBox_2.TabIndex = 40;
		groupBox_2.TabStop = false;
		groupBox_2.Text = Class16.smethod_0(1649175422);
		button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 8f);
		button_0.Image = Resources.cmdDelete;
		Point location12 = new Point(137, 194);
		button_0.Location = location12;
		button_0.Name = Class16.smethod_0(1649003416);
		Size size12 = new Size(125, 24);
		button_0.Size = size12;
		button_0.TabIndex = 143;
		button_0.Text = Class16.smethod_0(1648925718);
		button_0.TextAlign = ContentAlignment.MiddleRight;
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 8f);
		button_1.Image = Resources.cmdAdd;
		Point location13 = new Point(6, 194);
		button_1.Location = location13;
		button_1.Name = Class16.smethod_0(1648926646);
		Size size13 = new Size(125, 24);
		button_1.Size = size13;
		button_1.TabIndex = 142;
		button_1.Text = Class16.smethod_0(1648931361);
		button_1.TextAlign = ContentAlignment.MiddleRight;
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		dataGridView_0.AllowUserToResizeColumns = false;
		dataGridView_0.AllowUserToResizeRows = false;
		dataGridView_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Color white = Color.White;
		dataGridView_0.BackgroundColor = white;
		dataGridView_0.BorderStyle = BorderStyle.Fixed3D;
		dataGridView_0.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
		dataGridView_0.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		dataGridView_0.ColumnHeadersVisible = false;
		DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[1] { dataGridViewTextBoxColumn_0 };
		dataGridView_0.Columns.AddRange(dataGridViewColumns);
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		Color white2 = Color.White;
		dataGridViewCellStyle.BackColor = white2;
		dataGridViewCellStyle.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Color black = Color.Black;
		dataGridViewCellStyle.ForeColor = black;
		Color highlight = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionBackColor = highlight;
		Color white3 = Color.White;
		dataGridViewCellStyle.SelectionForeColor = white3;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		dataGridView_0.DefaultCellStyle = dataGridViewCellStyle;
		Color silver = Color.Silver;
		dataGridView_0.GridColor = silver;
		Point location14 = new Point(6, 17);
		dataGridView_0.Location = location14;
		Padding margin = new Padding(3, 4, 3, 4);
		dataGridView_0.Margin = margin;
		dataGridView_0.MultiSelect = false;
		dataGridView_0.Name = Class16.smethod_0(1649175443);
		dataGridView_0.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		Color control = SystemColors.Control;
		dataGridViewCellStyle2.BackColor = control;
		dataGridViewCellStyle2.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		Color windowText = SystemColors.WindowText;
		dataGridViewCellStyle2.ForeColor = windowText;
		Color highlight2 = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionBackColor = highlight2;
		Color highlightText = SystemColors.HighlightText;
		dataGridViewCellStyle2.SelectionForeColor = highlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		dataGridView_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridViewCellStyle3.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_0.RowsDefaultCellStyle = dataGridViewCellStyle3;
		string familyName = Class16.smethod_0(1648942905);
		dataGridView_0.RowTemplate.DefaultCellStyle.Font = new Font(familyName, 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridView_0.RowTemplate.Height = 18;
		dataGridView_0.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.ShowCellToolTips = false;
		Size size14 = new Size(256, 172);
		dataGridView_0.Size = size14;
		dataGridView_0.TabIndex = 141;
		dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter;
		dataGridViewTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle4;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1649175459);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1649175478);
		dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		SizeF sizeF = new SizeF(6f, 13f);
		base.AutoScaleDimensions = sizeF;
		base.AutoScaleMode = AutoScaleMode.Font;
		Color backColor = Color.FromArgb(239, 244, 250);
		BackColor = backColor;
		base.CancelButton = button_2;
		Size clientSize = new Size(292, 512);
		base.ClientSize = clientSize;
		Button value12 = button_2;
		base.Controls.Add(value12);
		Button value13 = button_3;
		base.Controls.Add(value13);
		GroupBox value14 = groupBox_1;
		base.Controls.Add(value14);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.ElementsPermissionsEditor_Icon;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1649175488);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1649175520);
		base.TopMost = true;
		base.Shown += ElementsPermissionsEditor_Shown;
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		groupBox_1.ResumeLayout(performLayout: false);
		groupBox_1.PerformLayout();
		groupBox_3.ResumeLayout(performLayout: false);
		groupBox_3.PerformLayout();
		groupBox_2.ResumeLayout(performLayout: false);
		((ISupportInitialize)dataGridView_0).EndInit();
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
