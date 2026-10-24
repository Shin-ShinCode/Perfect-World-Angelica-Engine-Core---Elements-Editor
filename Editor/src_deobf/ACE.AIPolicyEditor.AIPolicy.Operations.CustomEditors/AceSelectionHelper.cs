using System;
using System.Linq;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements;
using ACE.Elements.eListCollection;

namespace ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

internal static class AceSelectionHelper
{
	public static bool TrySelectId(ItemType itemType, uint currentValue, IServiceProvider provider, out uint selectedValue)
	{
		selectedValue = currentValue;
		MainForm mainForm = smethod_0(provider);
		if (mainForm == null)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648935440)), Class16.smethod_0(1648935474), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return false;
		}
		eListCollection elements = mainForm.Elements;
		ItemsWindow itemsWindow = mainForm.ItemsWindow1;
		CommonStorage cStorage = mainForm.CStorage;
		if (elements != null && itemsWindow != null && cStorage != null)
		{
			Form form = smethod_1(provider);
			int[] lists = elements.GetLists(itemType);
			ITEMPOS iTEMPOS = elements.FindItemPos(lists, (int)currentValue);
			if (iTEMPOS != null)
			{
				itemsWindow.newitemlist = iTEMPOS.int_0;
				itemsWindow.newitemindex = iTEMPOS.int_1;
			}
			itemsWindow.newlistsindices = lists;
			itemsWindow.bMultiSelect = false;
			itemsWindow.eLC = elements;
			cStorage.ResetBuffer();
			DialogResult dialogResult = ((form != null) ? itemsWindow.ShowDialog(form) : itemsWindow.ShowDialog());
			if (dialogResult == DialogResult.OK && uint.TryParse(CommonStorage.sData, out var result) && result != 0)
			{
				selectedValue = result;
				return true;
			}
			return false;
		}
		DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648935503)), Class16.smethod_0(1648935474), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		return false;
	}

	private static MainForm smethod_0(IServiceProvider iserviceProvider_0)
	{
		Form form = smethod_1(iserviceProvider_0);
		if (form is MainForm result)
		{
			return result;
		}
		return Application.OpenForms.OfType<MainForm>().FirstOrDefault();
	}

	private static Form smethod_1(IServiceProvider iserviceProvider_0)
	{
		if (iserviceProvider_0?.GetService(typeof(IWin32Window)) is IWin32Window win32Window)
		{
			return (Control.FromHandle(win32Window.Handle) as Form) ?? Form.ActiveForm;
		}
		return Form.ActiveForm ?? Application.OpenForms.Cast<Form>().FirstOrDefault();
	}
}
