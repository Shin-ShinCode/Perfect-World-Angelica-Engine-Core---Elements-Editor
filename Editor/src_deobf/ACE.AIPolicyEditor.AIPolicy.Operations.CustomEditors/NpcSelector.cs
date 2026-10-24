using System;
using System.ComponentModel;
using System.Drawing.Design;
using ACE.Classes;

namespace ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

public class NpcSelector : UITypeEditor
{
	public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
	{
		return UITypeEditorEditStyle.Modal;
	}

	public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
	{
		uint currentValue = ((value is NpcID npcID) ? npcID.Value : 0u);
		if (AceSelectionHelper.TrySelectId(ItemType.NpcOrMobOrMine, currentValue, provider, out var selectedValue))
		{
			if (value is NpcID npcID2)
			{
				npcID2.Value = selectedValue;
				return npcID2;
			}
			return new NpcID
			{
				Value = selectedValue
			};
		}
		return value;
	}
}
