using System;
using System.ComponentModel;
using System.Drawing.Design;
using ACE.Classes;

namespace ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

public class MobSelector : UITypeEditor
{
	public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
	{
		return UITypeEditorEditStyle.Modal;
	}

	public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
	{
		uint currentValue = ((value is MobID mobID) ? mobID.Value : 0u);
		if (AceSelectionHelper.TrySelectId(ItemType.PW_MONSTER_ESSENCE, currentValue, provider, out var selectedValue))
		{
			if (value is MobID mobID2)
			{
				mobID2.Value = selectedValue;
				return mobID2;
			}
			return new MobID
			{
				Value = selectedValue
			};
		}
		return value;
	}
}
