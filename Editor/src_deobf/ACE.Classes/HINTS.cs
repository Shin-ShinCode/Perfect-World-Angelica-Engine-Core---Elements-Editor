using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using ACE.Elements;
using ACE.Elements.eListCollection;
using ACE.RSGlobal;
using ACE.Settings;
using ACE.sTASKedit.Classes;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.Classes;

public class HINTS
{
	public static CommonStorage CStorage;

	public static ItemsToolTip ToolTipWindow;

	public static int NotShowedHintsCounter;

	public static ITEMPOS RestoreItemPos;

	public static IntPtr RestoreOwner;

	public static TASKS Tasks => DataFiles.Tasks;

	public static eListCollection eLC => DataFiles.Elements;

	public static string GetElementToolTip(ITEMPOS ItemPos, [MarshalAs(UnmanagedType.U1)] bool IsShopPrice, [MarshalAs(UnmanagedType.U1)] bool bUnlimited, ITEMPOS HighlightItem)
	{
		if (ItemPos == null)
		{
			return null;
		}
		if (CStorage == null)
		{
			return null;
		}
		if (CStorage.IsElementsBusy)
		{
			return null;
		}
		eListCollection elements = DataFiles.Elements;
		if (elements != null && elements.Lists != null)
		{
			if (ItemPos.int_0 >= 0 && ItemPos.int_0 < elements.ListCount && ItemPos.int_1 >= 0)
			{
				if (elements.Lists[ItemPos.int_0] == null)
				{
					return TextStorage.TEXTS.GetText(Class16.smethod_0(1648902988));
				}
				if (!elements.IsItemExist(ItemPos))
				{
					return TextStorage.TEXTS.GetText(Class16.smethod_0(1648902988));
				}
				if (global::ACE.RSGlobal.RSGlobal.AntiRecurse_GetElementToolTip_HINTS)
				{
					return null;
				}
				global::ACE.RSGlobal.RSGlobal.AntiRecurse_GetElementToolTip_HINTS = true;
				string result = null;
				try
				{
					DESC_EX itemHTML = elements.GetItemHTML(ItemPos, IsShopPrice, bUnlimited, bOnlyRefines: false, HighlightItem);
					if (itemHTML == null)
					{
						return null;
					}
					StringBuilder stringBuilder = new StringBuilder(20480);
					stringBuilder.Append(Class16.smethod_0(1648903003));
					stringBuilder.Append(itemHTML.head);
					stringBuilder.Append(itemHTML.body);
					stringBuilder.Append(itemHTML.creator);
					stringBuilder.Append(itemHTML.suite);
					stringBuilder.Append(itemHTML.desc);
					stringBuilder.Append(itemHTML.proc);
					stringBuilder.Append(itemHTML.props);
					ADDITIONAL_PARAMS aParams = CommonStorage.AParams;
					if (aParams != null && aParams.IncludeQuestIntoItemHint)
					{
						List<ATaskTempl> list = elements.TryGetQuests(ItemPos, aParams.IncludeQuestFromSubitems);
						if (list != null)
						{
							stringBuilder.AppendLine(Class16.smethod_0(1648903120));
							Color lightGreen = Color.LightGreen;
							string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648903140));
							stringBuilder.AppendLine(Class16.smethod_0(1648903120) + HTML_HELPER.EchoTextColored(lightGreen, bBold: true, text));
							int num = itemHTML.GetLineCount();
							int num2 = 0;
							while (true)
							{
								int num3 = ((3 >= list.Count) ? list.Count : 3);
								if (num2 >= num3)
								{
									break;
								}
								string toolTipText = TASKS_HINT.GetToolTipText(list[num2], HighlightItem);
								if (toolTipText != null)
								{
									toolTipText = toolTipText.Replace(Class16.smethod_0(1648903120), Class16.smethod_0(1648903155));
									stringBuilder.AppendLine(Class16.smethod_0(1648903120) + toolTipText);
									num = global::ACE.RSGlobal.RSGlobal.CountWords(toolTipText, Class16.smethod_0(1648908417)) + num;
								}
								if (num > 23)
								{
									break;
								}
								num2++;
							}
							stringBuilder.AppendLine(Class16.smethod_0(1648903120));
						}
					}
					stringBuilder.Append(itemHTML.refs);
					stringBuilder.Append(itemHTML.errors);
					stringBuilder.Append(itemHTML.duplicates);
					stringBuilder.Append(itemHTML.watemark);
					stringBuilder.AppendLine(Class16.smethod_0(1648902161));
					result = stringBuilder.ToString();
				}
				catch (Exception ex)
				{
					string text2 = null;
					try
					{
						int int_ = ItemPos.int_1;
						int int_2 = ItemPos.int_0;
						string format = Class16.smethod_0(1648902183);
						string key = Class16.smethod_0(1648902204);
						ex.Data[key] = string.Format(format, int_2, int_);
						eListCollection eListCollection2 = elements;
						if (eListCollection2 != null)
						{
							text2 = eListCollection2.GetItemID(ItemPos);
							ex.Data[Class16.smethod_0(1648902211)] = text2;
						}
					}
					catch
					{
					}
					ToolTipWindow?.AnullItem();
					SentryHelper.CaptureException(ex, Class16.smethod_0(1648902225));
				}
				finally
				{
					global::ACE.RSGlobal.RSGlobal.AntiRecurse_GetElementToolTip_HINTS = false;
				}
				return result;
			}
			return TextStorage.TEXTS.GetText(Class16.smethod_0(1648902988));
		}
		return null;
	}

	public static void ShowElementToolTip(IntPtr OwnerHandle, ITEMPOS ItemPos, [MarshalAs(UnmanagedType.U1)] bool IsShopPrice, [MarshalAs(UnmanagedType.U1)] bool bUnlimited, ITEMPOS HighlightItem)
	{
		if (ItemPos == null || CStorage == null)
		{
			return;
		}
		ADDITIONAL_PARAMS aParams = CommonStorage.AParams;
		if (aParams != null && aParams.DisableAllHints)
		{
			RestoreOwner = OwnerHandle;
			if (RestoreItemPos == null || !ItemPos.Equals(RestoreItemPos))
			{
				RestoreItemPos = ItemPos;
				NotShowedHintsCounter++;
				if (NotShowedHintsCounter % 100 == 0)
				{
					string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648902263));
					string text2 = Class16.smethod_0(1648902286);
					ToolTipWindow.ShowToolTip(OwnerHandle, string.Concat(Class16.smethod_0(1648902302) + text, text2));
				}
			}
		}
		else if (ToolTipWindow != null && !ToolTipWindow.IsDisposed && !ToolTipWindow.Disposing)
		{
			string text3 = string.Empty;
			ITEMPOS showedItemPos = ToolTipWindow.ShowedItemPos;
			if (showedItemPos == null || !showedItemPos.Equals(ItemPos))
			{
				text3 = GetElementToolTip(ItemPos, IsShopPrice, bUnlimited, HighlightItem);
			}
			if (text3 != null)
			{
				ToolTipWindow.ShowItemToolTip(OwnerHandle, ItemPos, text3, IsShopPrice, bSmooth: false);
			}
		}
	}

	public static void RestoreHint()
	{
		NotShowedHintsCounter = 0;
		if (RestoreItemPos != null && DataFiles.Elements != null && DataFiles.Elements.IsItemExist(RestoreItemPos))
		{
			ShowElementToolTip(RestoreOwner, RestoreItemPos, IsShopPrice: false, bUnlimited: false, null);
		}
	}
}
