using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;
using ACE.sTASKedit.Classes;
using ACE.sTASKedit.Classes.Extensions;
using ACE.sTASKedit.Classes.GlobalProgramData;
using ACE.sTASKedit.MainEditor;
using ACE.sTASKedit.tasks;

namespace ACE.sTASKedit.Forms;

public class ProbabilityEditorWindow : Form
{
	public ElementProbability[] Elements;

	private int int_0;

	private int int_1;

	private float float_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private IContainer icontainer_0;

	private DataGridView dataGridView_0;

	private NumericUpDown numericUpDown_0;

	private TrackBar trackBar_0;

	private Button button_0;

	private Button button_1;

	private Button button_2;

	private ToolTip toolTip_0;

	private NumericUpDown numericUpDown_1;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private GroupBox groupBox_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewImageColumn dataGridViewImageColumn_0;

	private DataGridViewButtonColumn dataGridViewButtonColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewImageColumn dataGridViewImageColumn_1;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

	public ProbabilityEditorWindow(ElementProbability[] elements, int element_type)
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		if (ACE.sTASKedit.MainEditor.MainEditor.W_ProbabilityEditorSize.Width > 0 || ACE.sTASKedit.MainEditor.MainEditor.W_ProbabilityEditorSize.Height > 0)
		{
			base.Size = ACE.sTASKedit.MainEditor.MainEditor.W_ProbabilityEditorSize;
		}
		Elements = elements;
		int_0 = element_type;
		SetLocalization();
		float num = 0f;
		for (int i = 0; i < Elements.Length; i++)
		{
			if (Elements[i].Probability != 1f)
			{
				num += Elements[i].Probability;
			}
		}
		if (num > 1f)
		{
			float num2 = num - 1f;
			num -= num2;
		}
		if (num != 1f && num != 0f)
		{
			float_0 = 1f - num;
			checkBox_0.Checked = true;
		}
		if (ACE.sTASKedit.Classes.Settings.Fields.EnableShowPercents)
		{
			numericUpDown_0.Maximum = new decimal(new int[4] { 100, 0, 0, 0 });
			numericUpDown_0.Increment = new decimal(new int[4] { 1, 0, 0, 0 });
			numericUpDown_0.DecimalPlaces = 4;
			numericUpDown_1.Maximum = new decimal(new int[4] { 100, 0, 0, 0 });
			numericUpDown_1.Increment = new decimal(new int[4] { 1, 0, 0, 0 });
			numericUpDown_1.DecimalPlaces = 4;
		}
		if (ACE.sTASKedit.Classes.Settings.Fields.EnableShowPercents)
		{
			numericUpDown_1.Value = Convert.ToDecimal(float_0 * 100f);
		}
		else
		{
			numericUpDown_1.Value = Convert.ToDecimal(float_0);
		}
	}

	private void ProbabilityEditorWindow_Load(object sender, EventArgs e)
	{
		switch (int_0)
		{
		case 1:
		{
			dataGridView_0.Columns[1].Visible = false;
			for (int j = 0; j < Elements.Length; j++)
			{
				dataGridView_0.Rows.Add(Elements[j].Id, null, GProD.GetMonsterNPCMineName(Elements[j].Id), Elements[j].Probability.ToString(GProD.ProbValueFormat), null, false);
				dataGridView_0.Rows[j].HeaderCell.Value = (j + 1).ToString();
			}
			dataGridView_0_SizeChanged(null, null);
			break;
		}
		case 0:
		{
			dataGridView_0.Columns[1].Width = GProD.ElementIconWidth + 1;
			dataGridView_0.RowTemplate.Height = GProD.ElementIconHeight + 1;
			dataGridView_0.Columns[1].Visible = true;
			for (int i = 0; i < Elements.Length; i++)
			{
				dataGridView_0.Rows.Add(Elements[i].Id, GProD.GetItemIcon(Elements[i].Id), GProD.GetItemName(Elements[i].Id), Elements[i].Probability.ToString(GProD.ProbValueFormat), null, false);
				dataGridView_0.Rows[i].HeaderCell.Value = (i + 1).ToString();
			}
			dataGridView_0_SizeChanged(null, null);
			break;
		}
		}
		bool_1 = true;
		bool_2 = true;
		bool_3 = true;
		bool_4 = true;
		bool_0 = true;
		dataGridView_0_SelectionChanged(null, null);
	}

	private void dataGridView_0_SelectionChanged(object sender, EventArgs e)
	{
		if (dataGridView_0.CurrentRow == null || dataGridView_0.CurrentRow.Index < 0 || !bool_0)
		{
			return;
		}
		int index = dataGridView_0.CurrentRow.Index;
		if (index < Elements.Length)
		{
			bool_1 = false;
			bool_2 = false;
			bool_3 = false;
			bool_4 = false;
			try
			{
				decimal val = (ACE.sTASKedit.Classes.Settings.Fields.EnableShowPercents ? Convert.ToDecimal(Elements[index].Probability * 100f) : Convert.ToDecimal(Elements[index].Probability));
				numericUpDown_0.Value = Math.Max(numericUpDown_0.Minimum, Math.Min(numericUpDown_0.Maximum, val));
				int val2 = Convert.ToInt32(Elements[index].Probability * 100f);
				trackBar_0.Value = Math.Max(trackBar_0.Minimum, Math.Min(trackBar_0.Maximum, val2));
			}
			catch (Exception)
			{
			}
			bool_1 = true;
			bool_2 = true;
			bool_3 = true;
			bool_4 = true;
		}
	}

	private void dataGridView_0_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		if (bool_4 && bool_0 && e.RowIndex >= 0 && e.RowIndex < Elements.Length && e.ColumnIndex >= 0 && dataGridView_0.CurrentCell != null && dataGridView_0.CurrentRow != null && dataGridView_0.CurrentRow.Index >= 0 && dataGridView_0.CurrentRow.Index < Elements.Length)
		{
			bool_4 = false;
			int columnIndex = e.ColumnIndex;
			if (columnIndex == 3)
			{
				Elements[e.RowIndex].Probability = mConvert.PercentNumberToSingle(dataGridView_0.Rows[e.RowIndex].Cells[3].Value, ACE.sTASKedit.Classes.Settings.Fields.EnableShowPercents);
				dataGridView_0_SizeChanged(null, null);
			}
			bool_4 = true;
		}
	}

	private void trackBar_0_ValueChanged(object sender, EventArgs e)
	{
		if (bool_1 && dataGridView_0.CurrentRow != null && dataGridView_0.CurrentRow.Index >= 0 && dataGridView_0.CurrentRow.Index < Elements.Length)
		{
			bool_1 = false;
			bool_2 = false;
			bool_3 = false;
			bool_4 = false;
			method_1();
			if (ACE.sTASKedit.Classes.Settings.Fields.EnableShowPercents)
			{
				numericUpDown_0.Value = Convert.ToDecimal(Elements[dataGridView_0.CurrentRow.Index].Probability * 100f);
			}
			else
			{
				numericUpDown_0.Value = Convert.ToDecimal(Elements[dataGridView_0.CurrentRow.Index].Probability);
			}
			dataGridView_0_SizeChanged(null, null);
			bool_1 = true;
			bool_2 = true;
			bool_3 = true;
			bool_4 = true;
		}
	}

	private void numericUpDown_0_ValueChanged(object sender, EventArgs e)
	{
		if (bool_2 && dataGridView_0.CurrentRow != null && dataGridView_0.CurrentRow.Index >= 0 && dataGridView_0.CurrentRow.Index < Elements.Length)
		{
			bool_2 = false;
			if (ACE.sTASKedit.Classes.Settings.Fields.EnableShowPercents)
			{
				trackBar_0.Value = Convert.ToInt32(numericUpDown_0.Value);
			}
			else
			{
				trackBar_0.Value = Convert.ToInt32(numericUpDown_0.Value * 100m);
			}
			bool_2 = true;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_0()
	{
		icontainer_0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		new ComponentResourceManager(typeof(ProbabilityEditorWindow));
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewImageColumn_0 = new DataGridViewImageColumn();
		dataGridViewButtonColumn_0 = new DataGridViewButtonColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		dataGridViewImageColumn_1 = new DataGridViewImageColumn();
		dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
		numericUpDown_0 = new NumericUpDown();
		trackBar_0 = new TrackBar();
		button_0 = new Button();
		button_1 = new Button();
		button_2 = new Button();
		toolTip_0 = new ToolTip(icontainer_0);
		numericUpDown_1 = new NumericUpDown();
		checkBox_0 = new CheckBox();
		checkBox_1 = new CheckBox();
		groupBox_0 = new GroupBox();
		((ISupportInitialize)dataGridView_0).BeginInit();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		((ISupportInitialize)trackBar_0).BeginInit();
		((ISupportInitialize)numericUpDown_1).BeginInit();
		groupBox_0.SuspendLayout();
		SuspendLayout();
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
		dataGridView_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dataGridView_0.BackgroundColor = SystemColors.Window;
		dataGridView_0.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 134);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dataGridView_0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewImageColumn_0, dataGridViewButtonColumn_0, dataGridViewTextBoxColumn_1, dataGridViewImageColumn_1, dataGridViewCheckBoxColumn_0);
		dataGridView_0.Location = new Point(12, 12);
		dataGridView_0.MultiSelect = false;
		dataGridView_0.Name = Class16.smethod_0(1649253659);
		dataGridView_0.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font(Class16.smethod_0(1648929920), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 134);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		dataGridView_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dataGridView_0.RowHeadersWidth = 52;
		dataGridView_0.RowTemplate.Resizable = DataGridViewTriState.False;
		dataGridView_0.Size = new Size(560, 250);
		dataGridView_0.TabIndex = 0;
		dataGridView_0.CellMouseEnter += dataGridView_0_CellMouseEnter;
		dataGridView_0.CellMouseLeave += dataGridView_0_CellMouseLeave;
		dataGridView_0.CellMouseMove += dataGridView_0_CellMouseMove;
		dataGridView_0.CellValueChanged += dataGridView_0_CellValueChanged;
		dataGridView_0.Scroll += dataGridView_0_Scroll;
		dataGridView_0.SelectionChanged += dataGridView_0_SelectionChanged;
		dataGridView_0.SizeChanged += dataGridView_0_SizeChanged;
		dataGridView_0.MouseMove += dataGridView_0_MouseMove;
		dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle3;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1648941057);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1649253695);
		dataGridViewTextBoxColumn_0.ReadOnly = true;
		dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_0.Width = 24;
		dataGridViewImageColumn_0.HeaderText = string.Empty;
		dataGridViewImageColumn_0.Name = Class16.smethod_0(1649253711);
		dataGridViewImageColumn_0.Width = 33;
		dataGridViewButtonColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		dataGridViewButtonColumn_0.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewButtonColumn_0.Name = Class16.smethod_0(1649253721);
		dataGridViewButtonColumn_0.ReadOnly = true;
		dataGridViewButtonColumn_0.Width = 41;
		dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewTextBoxColumn_1.DefaultCellStyle = dataGridViewCellStyle4;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648941080);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1649253739);
		dataGridViewTextBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_1.Width = 61;
		dataGridViewImageColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewImageColumn_1.HeaderText = string.Empty;
		dataGridViewImageColumn_1.Name = Class16.smethod_0(1649253772);
		dataGridViewCheckBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		dataGridViewCheckBoxColumn_0.HeaderText = Class16.smethod_0(1649253786);
		dataGridViewCheckBoxColumn_0.Name = Class16.smethod_0(1649253806);
		dataGridViewCheckBoxColumn_0.Width = 38;
		numericUpDown_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		numericUpDown_0.DecimalPlaces = 6;
		numericUpDown_0.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
		numericUpDown_0.Location = new Point(12, 316);
		numericUpDown_0.Maximum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_0.Name = Class16.smethod_0(1649253817);
		numericUpDown_0.Size = new Size(70, 20);
		numericUpDown_0.TabIndex = 1;
		numericUpDown_0.ValueChanged += numericUpDown_0_ValueChanged;
		trackBar_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		trackBar_0.LargeChange = 1;
		trackBar_0.Location = new Point(89, 314);
		trackBar_0.Maximum = 100;
		trackBar_0.Name = Class16.smethod_0(1649253849);
		trackBar_0.Size = new Size(418, 45);
		trackBar_0.TabIndex = 2;
		trackBar_0.TickStyle = TickStyle.None;
		trackBar_0.ValueChanged += trackBar_0_ValueChanged;
		button_0.Anchor = AnchorStyles.Bottom;
		button_0.Location = new Point(11, 343);
		button_0.Name = Class16.smethod_0(1649253385);
		button_0.Size = new Size(274, 23);
		button_0.TabIndex = 3;
		button_0.Text = Class16.smethod_0(1649253884);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Bottom;
		button_1.Location = new Point(299, 343);
		button_1.Name = Class16.smethod_0(1649262492);
		button_1.Size = new Size(274, 23);
		button_1.TabIndex = 4;
		button_1.Text = Class16.smethod_0(1648941799);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		button_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_2.Location = new Point(513, 315);
		button_2.Name = Class16.smethod_0(1648991094);
		button_2.Size = new Size(60, 23);
		button_2.TabIndex = 5;
		button_2.Text = Class16.smethod_0(1648920478);
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		toolTip_0.AutoPopDelay = 90000;
		toolTip_0.InitialDelay = 500;
		toolTip_0.ReshowDelay = 100;
		toolTip_0.UseAnimation = false;
		toolTip_0.UseFading = false;
		numericUpDown_1.DecimalPlaces = 6;
		numericUpDown_1.Enabled = false;
		numericUpDown_1.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
		numericUpDown_1.Location = new Point(9, 15);
		numericUpDown_1.Maximum = new decimal(new int[4] { 1, 0, 0, 0 });
		numericUpDown_1.Name = Class16.smethod_0(1649252869);
		numericUpDown_1.Size = new Size(70, 20);
		numericUpDown_1.TabIndex = 6;
		numericUpDown_1.ValueChanged += numericUpDown_1_ValueChanged;
		checkBox_0.AutoSize = true;
		checkBox_0.Location = new Point(9, -1);
		checkBox_0.Name = Class16.smethod_0(1649252900);
		checkBox_0.Size = new Size(133, 17);
		checkBox_0.TabIndex = 7;
		checkBox_0.Text = Class16.smethod_0(1649252921);
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_0.CheckedChanged += checkBox_0_CheckedChanged;
		checkBox_1.AutoSize = true;
		checkBox_1.Enabled = false;
		checkBox_1.Location = new Point(85, 18);
		checkBox_1.Name = Class16.smethod_0(1649252959);
		checkBox_1.Size = new Size(139, 17);
		checkBox_1.TabIndex = 8;
		checkBox_1.Text = Class16.smethod_0(1649252990);
		checkBox_1.UseVisualStyleBackColor = true;
		groupBox_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_0.Controls.Add(numericUpDown_1);
		groupBox_0.Controls.Add(checkBox_1);
		groupBox_0.Controls.Add(checkBox_0);
		groupBox_0.Location = new Point(12, 264);
		groupBox_0.Name = Class16.smethod_0(1649253022);
		groupBox_0.Size = new Size(560, 44);
		groupBox_0.TabIndex = 9;
		groupBox_0.TabStop = false;
		groupBox_0.Text = Class16.smethod_0(1649253040);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = SystemColors.Window;
		base.ClientSize = new Size(584, 377);
		base.Controls.Add(groupBox_0);
		base.Controls.Add(button_2);
		base.Controls.Add(button_1);
		base.Controls.Add(button_0);
		base.Controls.Add(trackBar_0);
		base.Controls.Add(numericUpDown_0);
		base.Controls.Add(dataGridView_0);
		base.Icon = Resources.edit;
		MinimumSize = new Size(600, 416);
		base.Name = Class16.smethod_0(1649253066);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = SizeGripStyle.Show;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649253066);
		base.Load += ProbabilityEditorWindow_Load;
		((ISupportInitialize)dataGridView_0).EndInit();
		((ISupportInitialize)numericUpDown_0).EndInit();
		((ISupportInitialize)trackBar_0).EndInit();
		((ISupportInitialize)numericUpDown_1).EndInit();
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void method_1()
	{
		if (Elements == null || Elements.Length == 0 || dataGridView_0.RowCount == 0 || dataGridView_0.CurrentRow == null)
		{
			return;
		}
		int index = dataGridView_0.CurrentRow.Index;
		if (index < 0 || index >= Elements.Length)
		{
			return;
		}
		float num = (float)trackBar_0.Value / 100f;
		if (num < 1E-06f)
		{
			num = 0f;
		}
		else if (num > 1f)
		{
			num = 1f;
		}
		List<int> list = new List<int>();
		for (int i = 0; i < Elements.Length; i++)
		{
			if (Elements[i].Probability == 1f && i != index)
			{
				list.Add(i);
			}
		}
		float num2 = 1f;
		float num3 = 0f;
		int num4 = 0;
		float num5 = 0f;
		for (int j = 0; j < Elements.Length; j++)
		{
			if (j != index && !method_2(list, j))
			{
				num5 += Elements[j].Probability;
				if (Convert.ToBoolean(dataGridView_0[5, j].Value ?? ((object)false)))
				{
					num2 -= Elements[j].Probability;
					num4++;
				}
				else
				{
					num3 += Elements[j].Probability;
				}
			}
		}
		if (checkBox_0.Checked)
		{
			num5 += float_0;
			if (checkBox_1.Checked)
			{
				num2 -= float_0;
				num4++;
			}
			else
			{
				num3 += float_0;
			}
		}
		if (!((double)Math.Abs(1f - num5) < 5E-07) || !((double)Elements[index].Probability > 5E-07))
		{
			if (num2 - num < 0f && num3 > 0f)
			{
				num = Elements[index].Probability + num3;
			}
			num2 -= num;
			if (checkBox_0.Checked)
			{
				if (num2 < 0f || (num3 == 0f && num4 >= Elements.Length))
				{
					trackBar_0.Value = Convert.ToInt32(Elements[index].Probability * 100f);
					return;
				}
			}
			else if (num2 < 0f || (num3 == 0f && num4 >= Elements.Length - 1))
			{
				trackBar_0.Value = Convert.ToInt32(Elements[index].Probability * 100f);
				return;
			}
			Elements[index].Probability = num;
			dataGridView_0[3, index].Value = Elements[index].Probability.ToString(GProD.ProbValueFormat);
			for (int k = 0; k < Elements.Length; k++)
			{
				if (!Convert.ToBoolean(dataGridView_0[5, k].Value ?? ((object)false)) && k != index && !method_2(list, k))
				{
					float num6 = ((num3 > 0f) ? (Elements[k].Probability / num3) : ((!checkBox_0.Checked) ? (1f / (float)Elements.Length) : (1f / (float)(Elements.Length + 1))));
					if (num2 <= 0f)
					{
						num6 = 0f;
					}
					Elements[k].Probability = num2 * num6;
					dataGridView_0[3, k].Value = Elements[k].Probability.ToString(GProD.ProbValueFormat);
				}
			}
			if (checkBox_0.Checked && !checkBox_1.Checked)
			{
				float num7 = ((!(num3 > 0f)) ? (1f / (float)(Elements.Length + 1)) : (float_0 / num3));
				if (num2 <= 0f)
				{
					num7 = 0f;
				}
				float_0 = num2 * num7;
				if (ACE.sTASKedit.Classes.Settings.Fields.EnableShowPercents)
				{
					numericUpDown_1.Value = Convert.ToDecimal(float_0 * 100f);
				}
				else
				{
					numericUpDown_1.Value = Convert.ToDecimal(float_0);
				}
			}
			num5 = 0f;
			for (int l = 0; l < Elements.Length; l++)
			{
				if (!method_2(list, l))
				{
					num5 += Elements[l].Probability;
				}
			}
			if (checkBox_0.Checked)
			{
				num5 += float_0;
			}
		}
		if (num5 == 1f)
		{
			return;
		}
		int num8 = method_3(Elements, list);
		if (checkBox_0.Checked)
		{
			int num9 = -1;
			float num10 = 0f;
			num10 = float_0;
			for (int m = 0; m < Elements.Length; m++)
			{
				if (!method_2(list, m) && Elements[m].Probability > num10)
				{
					num9 = m;
					num10 = Elements[m].Probability;
				}
			}
			if (num9 == -1)
			{
				float num11 = float_0;
				num11 += 1f - num5;
				if (num11 < 0f)
				{
					num11 = 0f;
				}
				if (ACE.sTASKedit.Classes.Settings.Fields.EnableShowPercents)
				{
					numericUpDown_1.Value = Convert.ToDecimal(num11 * 100f);
				}
				else
				{
					numericUpDown_1.Value = Convert.ToDecimal(num11);
				}
			}
			else
			{
				Elements[num8].Probability += 1f - num5;
				if (Elements[num8].Probability < 0f)
				{
					Elements[num8].Probability = 0f;
				}
				dataGridView_0[3, num8].Value = Elements[num8].Probability.ToString(GProD.ProbValueFormat);
			}
		}
		else
		{
			Elements[num8].Probability += 1f - num5;
			if (Elements[num8].Probability < 0f)
			{
				Elements[num8].Probability = 0f;
			}
			dataGridView_0[3, num8].Value = Elements[num8].Probability.ToString(GProD.ProbValueFormat);
		}
	}

	private void numericUpDown_1_ValueChanged(object sender, EventArgs e)
	{
		if (!bool_3)
		{
			return;
		}
		bool_1 = false;
		bool_2 = false;
		bool_3 = false;
		bool_4 = false;
		if (dataGridView_0.RowCount == 0)
		{
			return;
		}
		int num = -1;
		float num2 = 0f;
		if (ACE.sTASKedit.Classes.Settings.Fields.EnableShowPercents)
		{
			num2 = (float)numericUpDown_1.Value / 1000f;
			num2 *= 10f;
		}
		else
		{
			num2 = (float)numericUpDown_1.Value;
		}
		if (num2 < 1E-06f)
		{
			num2 = 0f;
		}
		else if (num2 > 1f)
		{
			num2 = 1f;
		}
		List<int> list = new List<int>();
		for (int i = 0; i < Elements.Length; i++)
		{
			if (Elements[i].Probability == 1f && i != num)
			{
				list.Add(i);
			}
		}
		float num3 = 1f;
		float num4 = 0f;
		int num5 = 0;
		float num6 = 0f;
		for (int j = 0; j < Elements.Length; j++)
		{
			if (j != num && !method_2(list, j))
			{
				num6 += Elements[j].Probability;
				if ((bool)dataGridView_0[5, j].Value)
				{
					num3 -= Elements[j].Probability;
					num5++;
				}
				else
				{
					num4 += Elements[j].Probability;
				}
			}
		}
		if (!((double)Math.Abs(1f - num6) < 5E-07) || !((double)float_0 > 5E-07))
		{
			if (num3 - num2 < 0f && num4 > 0f)
			{
				num2 = float_0 + num4;
			}
			num3 -= num2;
			if (num3 < 0f || (num4 == 0f && num5 >= Elements.Length))
			{
				if (ACE.sTASKedit.Classes.Settings.Fields.EnableShowPercents)
				{
					numericUpDown_1.Value = Convert.ToDecimal(float_0 * 100f);
				}
				else
				{
					numericUpDown_1.Value = Convert.ToDecimal(float_0);
				}
				return;
			}
			float_0 = num2;
			if (ACE.sTASKedit.Classes.Settings.Fields.EnableShowPercents)
			{
				numericUpDown_1.Value = Convert.ToDecimal(float_0 * 100f);
			}
			else
			{
				numericUpDown_1.Value = Convert.ToDecimal(float_0);
			}
			for (int k = 0; k < Elements.Length; k++)
			{
				if (!(bool)dataGridView_0[5, k].Value && k != num && !method_2(list, k))
				{
					float num7 = ((num4 > 0f) ? (Elements[k].Probability / num4) : ((!checkBox_0.Checked) ? (1f / (float)Elements.Length) : (1f / (float)(Elements.Length + 1))));
					if (num3 <= 0f)
					{
						num7 = 0f;
					}
					Elements[k].Probability = num3 * num7;
					dataGridView_0[3, k].Value = Elements[k].Probability.ToString(GProD.ProbValueFormat);
				}
			}
			num6 = 0f;
			for (int l = 0; l < Elements.Length; l++)
			{
				if (!method_2(list, l))
				{
					num6 += Elements[l].Probability;
				}
			}
			if (checkBox_0.Checked)
			{
				num6 += float_0;
			}
		}
		if (num6 != 1f)
		{
			int num8 = method_3(Elements, list);
			if (checkBox_0.Checked)
			{
				int num9 = -1;
				float num10 = 0f;
				num10 = float_0;
				for (int m = 0; m < Elements.Length; m++)
				{
					if (!method_2(list, m) && Elements[m].Probability > num10)
					{
						num9 = m;
						num10 = Elements[m].Probability;
					}
				}
				if (num9 == -1)
				{
					float num11 = float_0;
					num11 += 1f - num6;
					if (num11 < 0f)
					{
						num11 = 0f;
					}
					if (ACE.sTASKedit.Classes.Settings.Fields.EnableShowPercents)
					{
						numericUpDown_1.Value = Convert.ToDecimal(num11 * 100f);
					}
					else
					{
						numericUpDown_1.Value = Convert.ToDecimal(num11);
					}
				}
				else
				{
					Elements[num8].Probability += 1f - num6;
					if (Elements[num8].Probability < 0f)
					{
						Elements[num8].Probability = 0f;
					}
					dataGridView_0[3, num8].Value = Elements[num8].Probability.ToString(GProD.ProbValueFormat);
				}
			}
			else
			{
				Elements[num8].Probability += 1f - num6;
				if (Elements[num8].Probability < 0f)
				{
					Elements[num8].Probability = 0f;
				}
				dataGridView_0[3, num8].Value = Elements[num8].Probability.ToString(GProD.ProbValueFormat);
			}
		}
		bool_1 = true;
		bool_2 = true;
		bool_3 = true;
		bool_4 = true;
	}

	private bool method_2(List<int> list_0, int int_2)
	{
		int num = 0;
		while (true)
		{
			if (num < list_0.Count)
			{
				if (int_2 == list_0[num])
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private int method_3(ElementProbability[] elementProbability_0, List<int> list_0)
	{
		int result = 0;
		float num = 0f;
		for (int i = 0; i < elementProbability_0.Length; i++)
		{
			if (!method_2(list_0, i) && elementProbability_0[i].Probability > num)
			{
				result = i;
				num = elementProbability_0[i].Probability;
			}
		}
		return result;
	}

	private void dataGridView_0_SizeChanged(object sender, EventArgs e)
	{
		bool_4 = false;
		for (int i = 0; i < dataGridView_0.Rows.Count; i++)
		{
			dataGridView_0.Rows[i].Cells[4].Value = method_4(Elements[i].Probability, dataGridView_0.Columns[4].Width, dataGridView_0.Rows[0].Height + 1);
		}
		ACE.sTASKedit.MainEditor.MainEditor.W_ProbabilityEditorSize = base.Size;
		bool_4 = true;
	}

	private Image method_4(float float_1, int int_2, int int_3)
	{
		int_3 -= 2;
		Image image = new Bitmap(int_2, int_3);
		Graphics graphics = Graphics.FromImage(image);
		if (float_1 < 0f)
		{
			float_1 = 0f;
		}
		else if (float_1 > 1f)
		{
			float_1 = 1f;
		}
		graphics.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, int_2, int_3);
		graphics.DrawRectangle(new Pen(Color.LightGray, 2f), 0, 0, int_2, int_3);
		if (float_1 > 1E-06f)
		{
			int num = (int)(float_1 * (float)int_2);
			if (num < 1)
			{
				num = 1;
			}
			graphics.FillRectangle(new SolidBrush(Color.DarkGreen), 0, 0, num, int_3);
		}
		return image;
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		int num = 0;
		for (int i = 0; i < Elements.Length; i++)
		{
			if (!(bool)dataGridView_0.Rows[i].Cells[5].Value)
			{
				num++;
			}
		}
		if (checkBox_0.Checked && !checkBox_1.Checked)
		{
			num++;
		}
		float probability = 1f / (float)num;
		for (int j = 0; j < Elements.Length; j++)
		{
			if (!(bool)dataGridView_0.Rows[j].Cells[5].Value)
			{
				Elements[j].Probability = probability;
				dataGridView_0.Rows[j].Cells[3].Value = Elements[j].Probability.ToString(GProD.ProbValueFormat);
			}
		}
		if (checkBox_0.Checked && !checkBox_1.Checked)
		{
			float_0 = probability;
			if (ACE.sTASKedit.Classes.Settings.Fields.EnableShowPercents)
			{
				numericUpDown_1.Value = Convert.ToDecimal(float_0 * 100f);
			}
			else
			{
				numericUpDown_1.Value = Convert.ToDecimal(float_0);
			}
		}
		dataGridView_0_SelectionChanged(null, null);
		dataGridView_0_SizeChanged(null, null);
	}

	private void dataGridView_0_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (!bool_5 && e.ColumnIndex >= 0 && e.ColumnIndex < 3 && e.RowIndex > -1 && ACE.sTASKedit.Classes.Settings.Fields.EnableShowInfo)
		{
			try
			{
				int num = Convert.ToInt32(((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value);
				if (num > 0)
				{
					string text = string.Empty;
					((DataGridView)sender).ShowCellToolTips = false;
					if (ACE.sTASKedit.MainEditor.MainEditor.LoadedElements)
					{
						switch (int_0)
						{
						case 1:
							text = GlobalFunctions.ColorClean(GProD.GetMonsterNPCMineProps(num)) + Class16.smethod_0(1648941987);
							toolTip_0.ToolTipTitle = GlobalFunctions.ColorClean(GProD.GetMonsterNPCMineName(num));
							break;
						case 0:
							text = GlobalFunctions.ColorClean(GProD.GetItemProps(num, 0u));
							toolTip_0.ToolTipTitle = GlobalFunctions.ColorClean(GProD.GetItemName(num));
							break;
						}
					}
					if (int_0 == 0)
					{
						text = text + GlobalFunctions.ColorClean(GProD.GetItemDesc(num)) + Class16.smethod_0(1648941987);
					}
					Point point = Extensions.SetToolTipPos((Control)sender);
					toolTip_0.Show(text, (Control)sender, point.X, point.Y);
				}
				return;
			}
			catch
			{
				((DataGridView)sender).ShowCellToolTips = true;
				return;
			}
		}
		((DataGridView)sender).ShowCellToolTips = true;
	}

	private void dataGridView_0_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		toolTip_0.Hide((Control)sender);
		if (Control.ModifierKeys == Keys.Alt && Control.MouseButtons == MouseButtons.Right)
		{
			int_1 = e.RowIndex;
		}
	}

	private void dataGridView_0_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (HINTS.ToolTipWindow != null && e.RowIndex >= 0 && e.ColumnIndex == 0)
		{
			object value = ((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value;
			if (value != null && int.TryParse(value.ToString(), out var result) && result > 0)
			{
				ItemType item_type = ((int_0 == 0) ? ItemType.Matter : ItemType.NpcOrMobOrMine);
				HINTS.ToolTipWindow.SetOwnerHandle(((Control)sender).Handle);
				HINTS.ToolTipWindow.ShowItemToolTip(result, item_type);
			}
		}
	}

	private void dataGridView_0_MouseMove(object sender, MouseEventArgs e)
	{
		if (bool_5)
		{
			bool_5 = false;
		}
	}

	private void dataGridView_0_Scroll(object sender, ScrollEventArgs e)
	{
		bool_5 = true;
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox_0.Checked)
		{
			numericUpDown_1.Enabled = true;
			checkBox_1.Enabled = true;
		}
		else
		{
			numericUpDown_1.Enabled = false;
			checkBox_1.Enabled = false;
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	public void SetLocalization()
	{
		Text = GProD.TX(6134);
		dataGridViewTextBoxColumn_0.HeaderText = GProD.TX(6135);
		dataGridViewButtonColumn_0.HeaderText = GProD.TX(6136);
		dataGridViewTextBoxColumn_1.HeaderText = GProD.TX(6137);
		dataGridViewCheckBoxColumn_0.HeaderText = GProD.TX(6138);
		checkBox_0.Text = GProD.TX(6139);
		checkBox_1.Text = GProD.TX(6140);
		button_0.Text = GProD.TX(6001);
		button_1.Text = GProD.TX(6002);
	}
}
