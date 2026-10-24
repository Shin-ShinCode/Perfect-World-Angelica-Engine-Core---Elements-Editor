using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements;
using ACE.Elements.eListCollection;

namespace ACE.AIPolicyEditor.AIPolicy;

public class TooltipForm : Form
{
	private readonly eListCollection eListCollection_0;

	private readonly ItemsToolTip itemsToolTip_0;

	private IContainer icontainer_0;

	private DataGridView dataGridView_0;

	public TooltipForm(eListCollection eLC, ItemsToolTip itemsToolTip)
	{
		eListCollection_0 = eLC;
		itemsToolTip_0 = itemsToolTip;
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this, null);
	}

	public void DataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		int rowIndex = e.RowIndex;
		if (e.ColumnIndex <= 1 && rowIndex > -1 && dataGridView_0.Rows[rowIndex].Tag != null)
		{
			ITEMPOS iTEMPOS = (ITEMPOS)dataGridView_0.Rows[rowIndex].Tag;
			if (eListCollection_0.IsItemExist(iTEMPOS))
			{
				if (HINTS.ToolTipWindow != null)
				{
					HINTS.ShowElementToolTip(((Control)sender).Handle, iTEMPOS, IsShopPrice: false, bUnlimited: false, null);
				}
				else if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && itemsToolTip_0.Visible)
				{
					HINTS.ToolTipWindow.SmoothHide();
				}
			}
		}
		else if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && itemsToolTip_0.Visible)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
		GC.KeepAlive(this);
	}

	public void DataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		if (HINTS.ToolTipWindow != null && !HINTS.ToolTipWindow.bHiding && itemsToolTip_0.Visible)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
		GC.KeepAlive(this);
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
		dataGridView_0 = new DataGridView();
		((ISupportInitialize)dataGridView_0).BeginInit();
		SuspendLayout();
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView_0.Dock = DockStyle.Fill;
		dataGridView_0.Location = new Point(0, 0);
		dataGridView_0.Name = Class16.smethod_0(1648937429);
		dataGridView_0.Size = new Size(800, 450);
		dataGridView_0.TabIndex = 0;
		dataGridView_0.CellMouseEnter += DataGridView_CellMouseEnter;
		dataGridView_0.CellMouseLeave += DataGridView_CellMouseLeave;
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(800, 450);
		base.Controls.Add(dataGridView_0);
		base.Name = Class16.smethod_0(1648937440);
		((ISupportInitialize)dataGridView_0).EndInit();
		ResumeLayout(performLayout: false);
	}
}
