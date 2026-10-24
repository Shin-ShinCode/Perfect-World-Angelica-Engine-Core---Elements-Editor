using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;
using ACE.sTASKedit.Classes.Extensions;
using ACE.sTASKedit.Classes.GlobalProgramData;
using ACE.sTASKedit.tasks;

namespace ACE.sTASKedit.Forms;

public class SaveAsWindow : Form
{
	private IContainer icontainer_0;

	private Label label_0;

	private Button button_0;

	private Button button_1;

	public ComboBox comboBox_SaveVersion;

	public CheckBox checkBox_MakeBackup;

	public SaveAsWindow(int version)
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		int maxAllowedTaskVersion = GlobalData.GetMaxAllowedTaskVersion();
		for (int i = 0; i < GlobalData.Versions.Count - 1; i++)
		{
			int num = (int)GlobalData.Versions[i];
			if (num <= maxAllowedTaskVersion)
			{
				comboBox_SaveVersion.Items.Add(num);
			}
		}
		comboBox_SaveVersion.Text = version.ToString();
		SetLocalization();
	}

	private void comboBox_SaveVersion_DrawItem(object sender, DrawItemEventArgs e)
	{
		if (e.Index < 0 || e.Index >= comboBox_SaveVersion.Items.Count)
		{
			return;
		}
		int version = (int)comboBox_SaveVersion.Items[e.Index];
		SolidBrush brush = new SolidBrush(Extensions.GetVersionColor(version));
		if (TDark.IsDarkMode)
		{
			Color color = (((e.State & DrawItemState.Selected) == DrawItemState.Selected) ? TDark.DarkSelectionBack : TDark.DarkControlBack);
			SolidBrush solidBrush = new SolidBrush(color);
			try
			{
				e.Graphics.FillRectangle(solidBrush, e.Bounds);
			}
			finally
			{
				((IDisposable)solidBrush).Dispose();
			}
		}
		else
		{
			e.DrawBackground();
		}
		e.Graphics.DrawString(version.ToString(), e.Font, brush, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
		e.DrawFocusRectangle();
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
		Text = GProD.TX(6044);
		label_0.Text = GProD.TX(6045, appendsymbols: true);
		checkBox_MakeBackup.Text = GProD.TX(6046);
		button_0.Text = GProD.TX(6001);
		button_1.Text = GProD.TX(6002);
	}

	private void SaveAsWindow_Shown(object sender, EventArgs e)
	{
		label_0.Focus();
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
		new ComponentResourceManager(typeof(SaveAsWindow));
		label_0 = new Label();
		comboBox_SaveVersion = new ComboBox();
		checkBox_MakeBackup = new CheckBox();
		button_0 = new Button();
		button_1 = new Button();
		SuspendLayout();
		label_0.AutoSize = true;
		label_0.Location = new Point(9, 16);
		label_0.Name = Class16.smethod_0(1649247579);
		label_0.Size = new Size(73, 13);
		label_0.TabIndex = 0;
		label_0.Text = Class16.smethod_0(1649247603);
		comboBox_SaveVersion.BackColor = SystemColors.Window;
		comboBox_SaveVersion.DrawMode = DrawMode.OwnerDrawFixed;
		comboBox_SaveVersion.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_SaveVersion.FormattingEnabled = true;
		comboBox_SaveVersion.Location = new Point(101, 12);
		comboBox_SaveVersion.Name = Class16.smethod_0(1649247631);
		comboBox_SaveVersion.Size = new Size(73, 21);
		comboBox_SaveVersion.TabIndex = 1;
		comboBox_SaveVersion.DrawItem += comboBox_SaveVersion_DrawItem;
		checkBox_MakeBackup.AutoSize = true;
		checkBox_MakeBackup.Location = new Point(12, 41);
		checkBox_MakeBackup.Name = Class16.smethod_0(1649247650);
		checkBox_MakeBackup.Size = new Size(93, 17);
		checkBox_MakeBackup.TabIndex = 2;
		checkBox_MakeBackup.Text = Class16.smethod_0(1649247684);
		checkBox_MakeBackup.UseVisualStyleBackColor = true;
		button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_0.Location = new Point(11, 64);
		button_0.Name = Class16.smethod_0(1649253385);
		button_0.Size = new Size(75, 23);
		button_0.TabIndex = 3;
		button_0.Text = Class16.smethod_0(1649253884);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_1.Location = new Point(100, 64);
		button_1.Name = Class16.smethod_0(1649262492);
		button_1.Size = new Size(75, 23);
		button_1.TabIndex = 4;
		button_1.Text = Class16.smethod_0(1648941799);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = SystemColors.Window;
		base.ClientSize = new Size(186, 98);
		base.Controls.Add(button_1);
		base.Controls.Add(button_0);
		base.Controls.Add(checkBox_MakeBackup);
		base.Controls.Add(comboBox_SaveVersion);
		base.Controls.Add(label_0);
		base.Icon = Resources.edit;
		base.MaximizeBox = false;
		MaximumSize = new Size(202, 137);
		base.MinimizeBox = false;
		MinimumSize = new Size(202, 137);
		base.Name = Class16.smethod_0(1649247702);
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649247702);
		base.Shown += SaveAsWindow_Shown;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
