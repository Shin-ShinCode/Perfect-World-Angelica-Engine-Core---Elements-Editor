using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

public class BtnText : UserControl
{
	private IContainer icontainer_0;

	private TextBox textBox_0;

	private Button button_0;

	public TextBox TextBox => textBox_0;

	public Button Btn => button_0;

	public BtnText()
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
		textBox_0 = new TextBox();
		button_0 = new Button();
		SuspendLayout();
		textBox_0.Dock = DockStyle.Left;
		textBox_0.Location = new Point(0, 0);
		textBox_0.Name = Class16.smethod_0(1648935530);
		textBox_0.Size = new Size(70, 20);
		textBox_0.TabIndex = 0;
		button_0.Dock = DockStyle.Fill;
		button_0.Location = new Point(70, 0);
		button_0.Name = Class16.smethod_0(1648935549);
		button_0.Size = new Size(730, 23);
		button_0.TabIndex = 1;
		button_0.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(button_0);
		base.Controls.Add(textBox_0);
		base.Name = Class16.smethod_0(1648935559);
		base.Size = new Size(800, 23);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
