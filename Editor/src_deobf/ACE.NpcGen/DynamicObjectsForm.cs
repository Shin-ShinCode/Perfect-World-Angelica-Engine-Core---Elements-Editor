using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ACE.Classes;
using ACE.NpcGen.Classes;
using ACE.NpcGen.NPCGenEditorForm;
using ACE.Properties;

namespace ACE.NpcGen;

public class DynamicObjectsForm : Form
{
	private Button button_0;

	private Button button_1;

	private IContainer icontainer_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridView dataGridView_0;

	private PictureBox pictureBox_0;

	private List<DefaultInformation> list_0;

	private ACE.NpcGen.NPCGenEditorForm.NPCGenEditorForm npcgenEditorForm_0;

	private int int_0;

	public int SetWindow
	{
		set
		{
			int_0 = value;
		}
	}

	public DynamicObjectsForm(List<DefaultInformation> Default, ACE.NpcGen.NPCGenEditorForm.NPCGenEditorForm fm)
	{
		list_0 = Default;
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this, null);
		SortDynamics();
		npcgenEditorForm_0 = fm;
	}

	private static void smethod_0(PictureBox pictureBox_1, Image image_0)
	{
		if (pictureBox_1 == null)
		{
			image_0?.Dispose();
			return;
		}
		Image image = pictureBox_1.Image;
		pictureBox_1.Image = image_0;
		if (image == null || image == image_0)
		{
			return;
		}
		try
		{
			image.Dispose();
		}
		catch
		{
		}
	}

	public Image Image_resize(Image image_0, int Width, int Height)
	{
		Bitmap bitmap = new Bitmap(Width, Height);
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.DrawImage(image_0, 0, 0, Width, Height);
		return bitmap;
	}

	public void LanguageChange(int Language)
	{
		switch (Language)
		{
		case 2:
			button_0.Text = TextStorage.Msg(Class16.smethod_0(1649118834), Class16.smethod_0(1649118862));
			button_1.Text = TextStorage.Msg(Class16.smethod_0(1649005070), Class16.smethod_0(1648941799));
			break;
		case 1:
			button_0.Text = TextStorage.Msg(Class16.smethod_0(1649118834), Class16.smethod_0(1649118862));
			button_1.Text = TextStorage.Msg(Class16.smethod_0(1649005070), Class16.smethod_0(1648941799));
			break;
		}
	}

	public void SetColor(int Color)
	{
		if (Color == 2)
		{
			BackColor = System.Drawing.Color.FromArgb(58, 58, 58);
			pictureBox_0.BackColor = System.Drawing.Color.FromArgb(58, 58, 58);
		}
		else
		{
			BackColor = System.Drawing.Color.WhiteSmoke;
			pictureBox_0.BackColor = System.Drawing.Color.WhiteSmoke;
		}
	}

	public void SortDynamics()
	{
		dataGridView_0.Rows.Clear();
		for (int i = 0; i < list_0.Count; i++)
		{
			dataGridView_0.Rows.Add(i + 1, list_0[i].Id, list_0[i].Name);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && pictureBox_0?.Image != null)
		{
			try
			{
				Image image = pictureBox_0.Image;
				pictureBox_0.Image = null;
				image.Dispose();
			}
			catch
			{
			}
		}
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (dataGridView_0.CurrentRow != null && dataGridView_0.CurrentRow.Index != -1)
		{
			npcgenEditorForm_0.SetId(Convert.ToInt32(dataGridView_0.CurrentRow.Cells[1].Value), 3, int_0);
			Hide();
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		Hide();
	}

	private void dataGridView_0_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		npcgenEditorForm_0.SetId(Convert.ToInt32(dataGridView_0.CurrentRow.Cells[1].Value), 3, int_0);
		Hide();
	}

	private void dataGridView_0_CurrentCellChanged(object sender, EventArgs e)
	{
		if (dataGridView_0.CurrentRow == null || dataGridView_0.CurrentRow.Index == -1)
		{
			return;
		}
		string text = string.Format(Class16.smethod_0(1649118867), Application.StartupPath, dataGridView_0.Rows[dataGridView_0.CurrentRow.Index].Cells[1].Value);
		if (File.Exists(text))
		{
			using (Image image_ = Image.FromFile(text))
			{
				smethod_0(pictureBox_0, Image_resize(image_, 456, 257));
				return;
			}
		}
		smethod_0(pictureBox_0, null);
	}

	private void method_0()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		new ComponentResourceManager(typeof(DynamicObjectsForm));
		dataGridView_0 = new DataGridView();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		button_1 = new Button();
		button_0 = new Button();
		pictureBox_0 = new PictureBox();
		((ISupportInitialize)dataGridView_0).BeginInit();
		((ISupportInitialize)pictureBox_0).BeginInit();
		SuspendLayout();
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
		dataGridView_0.AllowUserToResizeRows = false;
		dataGridView_0.Anchor = AnchorStyles.None;
		dataGridView_0.BackgroundColor = Color.FromArgb(15, 15, 15);
		dataGridView_0.CellBorderStyle = DataGridViewCellBorderStyle.None;
		dataGridView_0.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_0.Columns.AddRange(dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1, dataGridViewTextBoxColumn_2);
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(15, 15, 15);
		dataGridViewCellStyle.Font = new Font(Class16.smethod_0(1648929920), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle.ForeColor = Color.FromArgb(224, 224, 224);
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		dataGridView_0.DefaultCellStyle = dataGridViewCellStyle;
		dataGridView_0.EnableHeadersVisualStyles = false;
		dataGridView_0.Location = new Point(1, 0);
		dataGridView_0.MultiSelect = false;
		dataGridView_0.Name = Class16.smethod_0(1649118916);
		dataGridView_0.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.ScrollBars = ScrollBars.Vertical;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.ShowCellErrors = false;
		dataGridView_0.ShowCellToolTips = false;
		dataGridView_0.ShowEditingIcon = false;
		dataGridView_0.ShowRowErrors = false;
		dataGridView_0.Size = new Size(303, 335);
		dataGridView_0.TabIndex = 18;
		dataGridView_0.CellMouseDoubleClick += dataGridView_0_CellMouseDoubleClick;
		dataGridView_0.CurrentCellChanged += dataGridView_0_CurrentCellChanged;
		dataGridViewCellStyle2.Font = new Font(Class16.smethod_0(1648929920), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle2;
		dataGridViewTextBoxColumn_0.FillWeight = 6.912442f;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1648929947);
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1649029397);
		dataGridViewTextBoxColumn_0.ReadOnly = true;
		dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_0.Width = 45;
		dataGridViewCellStyle3.Font = new Font(Class16.smethod_0(1648929920), 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle3.ForeColor = Color.FromArgb(77, 255, 143);
		dataGridViewTextBoxColumn_1.DefaultCellStyle = dataGridViewCellStyle3;
		dataGridViewTextBoxColumn_1.FillWeight = 44.7233f;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1649118934);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1649029431);
		dataGridViewTextBoxColumn_1.ReadOnly = true;
		dataGridViewTextBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_1.Width = 60;
		dataGridViewCellStyle4.ForeColor = Color.White;
		dataGridViewTextBoxColumn_2.DefaultCellStyle = dataGridViewCellStyle4;
		dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1649029457);
		dataGridViewTextBoxColumn_2.ReadOnly = true;
		dataGridViewTextBoxColumn_2.SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewTextBoxColumn_2.Width = 195;
		button_1.Font = new Font(Class16.smethod_0(1648929920), 15.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_1.Image = Resources.CancelDynamic;
		button_1.Location = new Point(535, 263);
		button_1.Name = Class16.smethod_0(1648941799);
		button_1.Size = new Size(228, 72);
		button_1.TabIndex = 21;
		button_1.Text = Class16.smethod_0(1648941799);
		button_1.TextAlign = ContentAlignment.MiddleRight;
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		button_0.Font = new Font(Class16.smethod_0(1648929920), 15.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.DynamicAccept;
		button_0.Location = new Point(307, 263);
		button_0.Name = Class16.smethod_0(1649118862);
		button_0.Size = new Size(228, 72);
		button_0.TabIndex = 20;
		button_0.Text = Class16.smethod_0(1649118862);
		button_0.TextAlign = ContentAlignment.MiddleRight;
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		pictureBox_0.BackColor = Color.WhiteSmoke;
		pictureBox_0.Location = new Point(307, 0);
		pictureBox_0.Name = Class16.smethod_0(1649118937);
		pictureBox_0.Size = new Size(456, 257);
		pictureBox_0.TabIndex = 19;
		pictureBox_0.TabStop = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(765, 336);
		base.Controls.Add(button_1);
		base.Controls.Add(button_0);
		base.Controls.Add(pictureBox_0);
		base.Controls.Add(dataGridView_0);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.edit;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1649118961);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1649118986);
		((ISupportInitialize)dataGridView_0).EndInit();
		((ISupportInitialize)pictureBox_0).EndInit();
		ResumeLayout(performLayout: false);
	}
}
