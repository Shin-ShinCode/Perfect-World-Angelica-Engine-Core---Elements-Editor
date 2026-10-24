using System.Drawing;
using System.Windows.Forms;

namespace ACE.NpcGen.LBLIBRARY.LBLIBRARY.Components;

public class MyMenuRenderer : ToolStripRenderer
{
	private Color color_0;

	private Color color_1;

	private Color color_2;

	private Color color_3;

	private Color color_4;

	private Color color_5;

	private Color color_6;

	public MyMenuRenderer(Color co, Color fc, Color sc, Color ls, Color mbc, Color bc, Color ic)
	{
		color_1 = co;
		color_2 = fc;
		color_6 = sc;
		color_3 = ls;
		color_4 = mbc;
		color_5 = bc;
		color_0 = ic;
	}

	protected override void OnRenderImageMargin(ToolStripRenderEventArgs toolStripRenderEventArgs_0)
	{
		base.OnRenderImageMargin(toolStripRenderEventArgs_0);
		Rectangle rect = new Rectangle(0, 0, toolStripRenderEventArgs_0.ToolStrip.Width, toolStripRenderEventArgs_0.ToolStrip.Height);
		toolStripRenderEventArgs_0.Graphics.FillRectangle(new SolidBrush(color_1), rect);
		SolidBrush brush = new SolidBrush(color_3);
		Rectangle rect2 = new Rectangle(0, 0, 26, toolStripRenderEventArgs_0.AffectedBounds.Height);
		toolStripRenderEventArgs_0.Graphics.FillRectangle(brush, rect2);
		Rectangle rect3 = new Rectangle(0, 0, toolStripRenderEventArgs_0.ToolStrip.Width - 1, toolStripRenderEventArgs_0.ToolStrip.Height - 1);
		toolStripRenderEventArgs_0.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black)), rect3);
	}

	protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs toolStripItemImageRenderEventArgs_0)
	{
		base.OnRenderItemCheck(toolStripItemImageRenderEventArgs_0);
		if (toolStripItemImageRenderEventArgs_0.Item.Selected)
		{
			Rectangle rect = new Rectangle(2, 0, 23, 23);
			Rectangle rect2 = new Rectangle(2, 0, 23, 23);
			SolidBrush brush = new SolidBrush(Color.Black);
			SolidBrush brush2 = new SolidBrush(color_0);
			toolStripItemImageRenderEventArgs_0.Graphics.FillRectangle(brush, rect);
			toolStripItemImageRenderEventArgs_0.Graphics.FillRectangle(brush2, rect2);
			toolStripItemImageRenderEventArgs_0.Graphics.DrawImage(toolStripItemImageRenderEventArgs_0.Image, new Point(5, 3));
		}
		else
		{
			Rectangle rect3 = new Rectangle(2, 0, 23, 23);
			Rectangle rect4 = new Rectangle(2, 0, 23, 23);
			SolidBrush brush3 = new SolidBrush(Color.White);
			SolidBrush brush4 = new SolidBrush(color_0);
			toolStripItemImageRenderEventArgs_0.Graphics.FillRectangle(brush3, rect3);
			toolStripItemImageRenderEventArgs_0.Graphics.FillRectangle(brush4, rect4);
			toolStripItemImageRenderEventArgs_0.Graphics.DrawImage(toolStripItemImageRenderEventArgs_0.Image, new Point(5, 3));
		}
	}

	protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs toolStripItemRenderEventArgs_0)
	{
		base.OnRenderMenuItemBackground(toolStripItemRenderEventArgs_0);
		if (toolStripItemRenderEventArgs_0.Item.Enabled)
		{
			if (!toolStripItemRenderEventArgs_0.Item.IsOnDropDown && toolStripItemRenderEventArgs_0.Item.Selected)
			{
				Rectangle rect = new Rectangle(0, 0, toolStripItemRenderEventArgs_0.Item.Width - 1, toolStripItemRenderEventArgs_0.Item.Height - 1);
				toolStripItemRenderEventArgs_0.Graphics.FillRectangle(new SolidBrush(color_4), rect);
				toolStripItemRenderEventArgs_0.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Blue)), rect);
				toolStripItemRenderEventArgs_0.Item.ForeColor = color_2;
			}
			else
			{
				toolStripItemRenderEventArgs_0.Item.ForeColor = color_2;
			}
			if (toolStripItemRenderEventArgs_0.Item.IsOnDropDown && toolStripItemRenderEventArgs_0.Item.Selected)
			{
				Rectangle rect2 = new Rectangle(0, 0, toolStripItemRenderEventArgs_0.Item.Width - 1, toolStripItemRenderEventArgs_0.Item.Height - 1);
				toolStripItemRenderEventArgs_0.Graphics.FillRectangle(new SolidBrush(color_4), rect2);
				toolStripItemRenderEventArgs_0.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.LightBlue)), rect2);
				toolStripItemRenderEventArgs_0.Item.ForeColor = color_2;
			}
			if ((toolStripItemRenderEventArgs_0.Item as ToolStripMenuItem).DropDown.Visible && !toolStripItemRenderEventArgs_0.Item.IsOnDropDown)
			{
				Rectangle rect3 = new Rectangle(0, 0, toolStripItemRenderEventArgs_0.Item.Width - 1, toolStripItemRenderEventArgs_0.Item.Height - 1);
				Rectangle rect4 = new Rectangle(0, 0, toolStripItemRenderEventArgs_0.Item.Width - 1, toolStripItemRenderEventArgs_0.Item.Height - 1);
				toolStripItemRenderEventArgs_0.Graphics.FillRectangle(new SolidBrush(color_1), rect3);
				toolStripItemRenderEventArgs_0.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black)), rect4);
				toolStripItemRenderEventArgs_0.Item.ForeColor = color_2;
			}
		}
	}

	protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs toolStripSeparatorRenderEventArgs_0)
	{
		base.OnRenderSeparator(toolStripSeparatorRenderEventArgs_0);
		SolidBrush brush = new SolidBrush(color_6);
		Rectangle rect = new Rectangle(30, 3, toolStripSeparatorRenderEventArgs_0.Item.Width - 30, 1);
		toolStripSeparatorRenderEventArgs_0.Graphics.FillRectangle(brush, rect);
	}
}
