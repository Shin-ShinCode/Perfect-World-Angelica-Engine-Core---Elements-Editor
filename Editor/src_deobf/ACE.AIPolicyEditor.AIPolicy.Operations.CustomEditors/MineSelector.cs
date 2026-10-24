using System;
using System.ComponentModel;
using System.Drawing.Design;
using ACE.Classes;

namespace ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

public class MineSelector : UITypeEditor
{
	public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
	{
		return UITypeEditorEditStyle.Modal;
	}

	public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
	{
		uint currentValue = ((value is MineID mineID) ? mineID.Value : 0u);
		if (AceSelectionHelper.TrySelectId(ItemType.PW_MINE_ESSENCE, currentValue, provider, out var selectedValue))
		{
			if (value is MineID mineID2)
			{
				mineID2.Value = selectedValue;
				return mineID2;
			}
			return new MineID
			{
				Value = selectedValue
			};
		}
		return value;
	}
}
