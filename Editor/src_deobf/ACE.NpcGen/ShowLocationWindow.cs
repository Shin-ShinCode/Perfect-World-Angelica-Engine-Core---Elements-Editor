using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Dependency.Cyotek.Windows.Forms.ImageBox;
using ACE.NpcGen.NPCGenEditorForm;
using ACE.Properties;

namespace ACE.NpcGen;

public class ShowLocationWindow : Form
{
	private IContainer icontainer_0;

	private ContextMenuStrip contextMenuStrip_0;

	private ACE.NpcGen.NPCGenEditorForm.NPCGenEditorForm npcgenEditorForm_0;

	private Bitmap bitmap_0;

	private ImageBox imageBox_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	public ShowLocationWindow(ACE.NpcGen.NPCGenEditorForm.NPCGenEditorForm fm, Bitmap fff)
	{
		npcgenEditorForm_0 = fm;
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this, null);
		bitmap_0 = fff;
		imageBox_0.Image = fff;
	}

	public void GetCoordinates(List<PointF> ls)
	{
		imageBox_0.Zoom = 100;
		Graphics graphics = Graphics.FromImage(imageBox_0.Image);
		int num = 1;
		if (imageBox_0.Image.Size != new Size(8192, 11264))
		{
			num = 2;
		}
		foreach (PointF l in ls)
		{
			float num2 = l.X / (float)num + (float)(imageBox_0.Image.Width / 2) - 10f;
			float num3 = Math.Abs(l.Y / (float)num - (float)(imageBox_0.Image.Height / 2)) - 8f;
			if (num2 <= (float)imageBox_0.Image.Width && num3 <= (float)imageBox_0.Image.Height)
			{
				graphics.DrawImage(Resources.NpcGenEditorForm_arrow, num2, num3);
			}
		}
		imageBox_0.ScrollTo(Convert.ToInt32(ls[ls.Count - 1].X + (float)(imageBox_0.Image.Width / 2)) - imageBox_0.DisplayRectangle.Width / 2, Convert.ToInt32(Math.Abs(ls[ls.Count - 1].Y - (float)(imageBox_0.Image.Height / 2))) - imageBox_0.DisplayRectangle.Height / 2);
		imageBox_0.Refresh();
	}

	public void SetPicture(Bitmap bmz)
	{
		imageBox_0.Image = bmz;
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
		new ComponentResourceManager(typeof(ShowLocationWindow));
		imageBox_0 = new ImageBox();
		contextMenuStrip_0 = new ContextMenuStrip(icontainer_0);
		toolStripMenuItem_0 = new ToolStripMenuItem();
		contextMenuStrip_0.SuspendLayout();
		SuspendLayout();
		imageBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		imageBox_0.BackColor = SystemColors.Control;
		imageBox_0.GridDisplayMode = ImageBoxGridDisplayMode.None;
		imageBox_0.Location = new Point(-1, 1);
		imageBox_0.Name = Class16.smethod_0(1648976327);
		imageBox_0.Size = new Size(535, 611);
		imageBox_0.TabIndex = 0;
		imageBox_0.TabStop = false;
		contextMenuStrip_0.Items.AddRange(new ToolStripItem[1] { toolStripMenuItem_0 });
		contextMenuStrip_0.Name = Class16.smethod_0(1649090926);
		contextMenuStrip_0.Size = new Size(95, 26);
		contextMenuStrip_0.Text = Class16.smethod_0(1649090950);
		toolStripMenuItem_0.Checked = true;
		toolStripMenuItem_0.CheckState = CheckState.Checked;
		toolStripMenuItem_0.Name = Class16.smethod_0(1649012245);
		toolStripMenuItem_0.Size = new Size(94, 22);
		toolStripMenuItem_0.Text = Class16.smethod_0(1648932164);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = SystemColors.Control;
		base.ClientSize = new Size(534, 611);
		base.Controls.Add(imageBox_0);
		base.Icon = Resources.edit;
		base.Name = Class16.smethod_0(1649090961);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1649008172);
		contextMenuStrip_0.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}
}
