using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

public class ComboboxText : UserControl
{
	private IContainer icontainer_0;

	private ComboBox comboBox_0;

	private Button button_0;

	public ComboBox CBox => comboBox_0;

	public Button Btn => button_0;

	public ComboboxText()
	{
		method_0();
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
		comboBox_0 = new ComboBox();
		button_0 = new Button();
		SuspendLayout();
		comboBox_0.Dock = DockStyle.Left;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Location = new Point(0, 0);
		comboBox_0.Name = Class16.smethod_0(1648935573);
		comboBox_0.Size = new Size(200, 21);
		comboBox_0.TabIndex = 0;
		button_0.Dock = DockStyle.Fill;
		button_0.Location = new Point(200, 0);
		button_0.Name = Class16.smethod_0(1648935549);
		button_0.Size = new Size(600, 23);
		button_0.TabIndex = 1;
		button_0.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(button_0);
		base.Controls.Add(comboBox_0);
		base.Name = Class16.smethod_0(1648935576);
		base.Size = new Size(800, 23);
		ResumeLayout(performLayout: false);
	}
}
