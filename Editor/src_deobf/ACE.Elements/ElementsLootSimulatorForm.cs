using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eListCollection;
using ACE.sTASKedit.Forms;
using ACE.sTASKedit.tasks;

namespace ACE.Elements;

public class ElementsLootSimulatorForm : LootSimulatorFormBase
{
	public static ACE.Elements.eListCollection.eListCollection eLC;

	private readonly List<PROB_SUITE_EXTENDED> list_0;

	private readonly List<string> list_1;

	private readonly ITEMPOS itempos_0;

	protected override string SourceLabelText => Class16.smethod_0(1648986332);

	public ElementsLootSimulatorForm(ITEMPOS itemPos)
	{
		itempos_0 = itemPos;
		list_0 = eLC.ProbSuitesGetAllItemValues(itemPos) ?? new List<PROB_SUITE_EXTENDED>();
		list_1 = ((eLC.ProbSuitesNames == null || itemPos.int_0 < 0 || itemPos.int_0 >= eLC.ProbSuitesNames.Count) ? new List<string>() : eLC.ProbSuitesNames[itemPos.int_0]);
		InitializeBase();
	}

	protected override void PopulateSourceList()
	{
		comboBox_Source.Items.Clear();
		for (int i = 0; i < list_0.Count; i++)
		{
			PROB_SUITE_EXTENDED pROB_SUITE_EXTENDED = list_0[i];
			string arg = ((i < list_1.Count) ? list_1[i] : string.Format(Class16.smethod_0(1648986337), i));
			int probCount = pROB_SUITE_EXTENDED.ProbCount;
			comboBox_Source.Items.Add(string.Format(Class16.smethod_0(1648986353), arg, probCount));
		}
		if (comboBox_Source.Items.Count > 0)
		{
			comboBox_Source.SelectedIndex = 0;
		}
	}

	private PROB_SUITE_EXTENDED method_8()
	{
		int selectedIndex = comboBox_Source.SelectedIndex;
		if (selectedIndex >= 0 && selectedIndex < list_0.Count)
		{
			return list_0[selectedIndex];
		}
		return null;
	}

	protected override void OnSimulate(int openCount)
	{
		PROB_SUITE_EXTENDED pROB_SUITE_EXTENDED = method_8();
		if (pROB_SUITE_EXTENDED == null || pROB_SUITE_EXTENDED.ProbCount == 0)
		{
			return;
		}
		Cursor = Cursors.WaitCursor;
		try
		{
			List<PROB_VALUES> valuesList = pROB_SUITE_EXTENDED.ValuesList;
			if (valuesList == null || valuesList.Count == 0)
			{
				return;
			}
			float num = 0f;
			for (int i = 0; i < valuesList.Count; i++)
			{
				num += valuesList[i].prob;
			}
			for (int j = 0; j < openCount; j++)
			{
				double num2 = _rng.NextDouble() * (double)num;
				double num3 = 0.0;
				for (int k = 0; k < valuesList.Count; k++)
				{
					if (!(valuesList[k].prob <= 0f))
					{
						num3 += (double)valuesList[k].prob;
						if (!(num2 >= num3))
						{
							method_9(pROB_SUITE_EXTENDED, valuesList[k]);
							break;
						}
					}
				}
			}
			inventoryGridPanel.RefreshGrid();
		}
		finally
		{
			Cursor = Cursors.Default;
		}
	}

	private void method_9(PROB_SUITE_EXTENDED prob_SUITE_EXTENDED_0, PROB_VALUES prob_VALUES_0)
	{
		int id = prob_VALUES_0.id;
		int count = smethod_0(prob_VALUES_0);
		if (id <= 0)
		{
			return;
		}
		string text = null;
		Image image = null;
		if (prob_SUITE_EXTENDED_0.IsItemPresent && id > 0)
		{
			int[] availableLists = prob_SUITE_EXTENDED_0.AvailableLists;
			ITEMPOS itemPos = eLC.FindItemPos(availableLists, id);
			ITEMINFO itemInfo = eLC.GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
			if (itemInfo != null)
			{
				text = itemInfo.name;
				image = eLC.GetIcon(itemInfo, 32);
			}
			else
			{
				text = string.Format(Class16.smethod_0(1648986383), id);
				image = ICONS.NopeIcon;
			}
		}
		else
		{
			text = string.Format(Class16.smethod_0(1648986395), id);
		}
		inventoryGridPanel.AddItem(id, text, image, count);
	}

	private static int smethod_0(PROB_VALUES prob_VALUES_0)
	{
		if (!string.IsNullOrWhiteSpace(prob_VALUES_0.val1) && int.TryParse(prob_VALUES_0.val1, out var result) && result > 0)
		{
			return result;
		}
		return 1;
	}

	protected override void ShowItemTooltip(Control owner, int itemId)
	{
		PROB_SUITE_EXTENDED pROB_SUITE_EXTENDED = method_8();
		if (pROB_SUITE_EXTENDED == null)
		{
			return;
		}
		ITEMPOS iTEMPOS = eLC.FindItemPos(pROB_SUITE_EXTENDED.AvailableLists, itemId);
		if (iTEMPOS == null)
		{
			return;
		}
		ITEMINFO itemInfo = eLC.GetItemInfo(iTEMPOS, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
		if (itemInfo != null)
		{
			string text = GlobalFunctions.ColorClean(itemInfo.name ?? string.Empty);
			string text2 = string.Format(Class16.smethod_0(1648986395), itemId);
			if (text.Length > 0)
			{
				owner.GetType().GetProperty(Class16.smethod_0(1648986409))?.SetValue(owner, false);
				toolTip_Item.ToolTipTitle = text;
				toolTip_Item.Show(text2, owner, 0, -60);
			}
		}
	}
}
