using System;
using System.Drawing;
using System.Windows.Forms;
using ACE.sTASKedit.Classes.Extensions;
using ACE.sTASKedit.Classes.GlobalProgramData;
using ACE.sTASKedit.MainEditor;
using ACE.sTASKedit.tasks;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Forms;

public class LootSimulatorForm : LootSimulatorFormBase
{
	private readonly AWARD_ITEMS_CAND[] award_ITEMS_CAND_0;

	protected override string SourceLabelText => Class16.smethod_0(1649250724);

	public LootSimulatorForm(AWARD_ITEMS_CAND[] candItems)
	{
		award_ITEMS_CAND_0 = candItems ?? Array.Empty<AWARD_ITEMS_CAND>();
		InitializeBase();
	}

	protected override void PopulateSourceList()
	{
		comboBox_Source.Items.Clear();
		for (int i = 0; i < award_ITEMS_CAND_0.Length; i++)
		{
			AWARD_ITEMS_CAND aWARD_ITEMS_CAND = award_ITEMS_CAND_0[i];
			if (aWARD_ITEMS_CAND != null && aWARD_ITEMS_CAND.m_AwardItems != null && aWARD_ITEMS_CAND.m_AwardItems.Length != 0)
			{
				string arg = (aWARD_ITEMS_CAND.m_bRandChoose ? Class16.smethod_0(1649250764) : Class16.smethod_0(1648973883));
				comboBox_Source.Items.Add(string.Format(Class16.smethod_0(1649250775), i, arg, aWARD_ITEMS_CAND.m_AwardItems.Length));
			}
			else
			{
				comboBox_Source.Items.Add(string.Format(Class16.smethod_0(1649250741), i));
			}
		}
		if (comboBox_Source.Items.Count > 0)
		{
			comboBox_Source.SelectedIndex = 0;
		}
	}

	protected override void OnSimulate(int openCount)
	{
		int selectedIndex = comboBox_Source.SelectedIndex;
		if (selectedIndex < 0 || selectedIndex >= award_ITEMS_CAND_0.Length)
		{
			return;
		}
		AWARD_ITEMS_CAND aWARD_ITEMS_CAND = award_ITEMS_CAND_0[selectedIndex];
		if (aWARD_ITEMS_CAND?.m_AwardItems == null || aWARD_ITEMS_CAND.m_AwardItems.Length == 0)
		{
			return;
		}
		Cursor = Cursors.WaitCursor;
		try
		{
			if (aWARD_ITEMS_CAND.m_bRandChoose)
			{
				method_8(aWARD_ITEMS_CAND.m_AwardItems, openCount);
			}
			else
			{
				method_9(aWARD_ITEMS_CAND.m_AwardItems, openCount);
			}
			inventoryGridPanel.RefreshGrid();
		}
		finally
		{
			Cursor = Cursors.Default;
		}
	}

	private void method_8(ITEM_WANTED[] item_WANTED_0, int int_0)
	{
		float num = 0f;
		for (int i = 0; i < item_WANTED_0.Length; i++)
		{
			if (item_WANTED_0[i] != null)
			{
				num += item_WANTED_0[i].m_fProb;
			}
		}
		for (int j = 0; j < int_0; j++)
		{
			double num2 = _rng.NextDouble() * (double)num;
			double num3 = 0.0;
			for (int k = 0; k < item_WANTED_0.Length; k++)
			{
				if (item_WANTED_0[k] != null)
				{
					num3 += (double)item_WANTED_0[k].m_fProb;
					if (!(num2 >= num3))
					{
						method_10(item_WANTED_0[k]);
						break;
					}
				}
			}
		}
	}

	private void method_9(ITEM_WANTED[] item_WANTED_0, int int_0)
	{
		for (int i = 0; i < int_0; i++)
		{
			for (int j = 0; j < item_WANTED_0.Length; j++)
			{
				if (item_WANTED_0[j] != null)
				{
					double num = _rng.NextDouble();
					if (num < (double)item_WANTED_0[j].m_fProb)
					{
						method_10(item_WANTED_0[j]);
					}
				}
			}
		}
	}

	private void method_10(ITEM_WANTED item_WANTED_0)
	{
		int ulItemTemplId = item_WANTED_0.m_ulItemTemplId;
		int count = ((item_WANTED_0.m_ulItemNum <= 0) ? 1 : item_WANTED_0.m_ulItemNum);
		string itemName = GProD.GetItemName(ulItemTemplId);
		Image itemIcon = GProD.GetItemIcon(ulItemTemplId);
		inventoryGridPanel.AddItem(ulItemTemplId, itemName, itemIcon, count);
	}

	protected override void ShowItemTooltip(Control owner, int itemId)
	{
		if (ACE.sTASKedit.MainEditor.MainEditor.LoadedElements)
		{
			string text = GlobalFunctions.ColorClean(GProD.GetItemName(itemId));
			string text2 = GlobalFunctions.ColorClean(GProD.GetItemProps(itemId, 0u));
			string text3 = GlobalFunctions.ColorClean(GProD.GetItemDesc(itemId));
			if (text3.Length > 0)
			{
				text2 = text2 + Class16.smethod_0(1648941987) + text3;
			}
			if (text.Length > 0 || text2.Length > 0)
			{
				owner.GetType().GetProperty(Class16.smethod_0(1648986409))?.SetValue(owner, false);
				toolTip_Item.ToolTipTitle = text;
				Point point = Extensions.SetToolTipPos(owner);
				toolTip_Item.Show(text2, owner, point.X, point.Y);
			}
		}
	}
}
