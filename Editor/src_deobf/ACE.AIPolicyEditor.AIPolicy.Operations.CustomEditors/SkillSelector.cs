using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

public class SkillSelector : UITypeEditor
{
	private sealed class Class32
	{
		public int int_0;

		internal void method_0(int int_1)
		{
			int_0 = int_1;
		}
	}

	public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
	{
		return UITypeEditorEditStyle.Modal;
	}

	public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
	{
		if (provider == null)
		{
			return value;
		}
		IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
		if (windowsFormsEditorService == null)
		{
			return value;
		}
		uint int_ = 0u;
		if (value is SkillID skillID)
		{
			int_ = skillID.Value;
		}
		CustomDataSelectorForm customDataSelectorForm = new CustomDataSelectorForm(CustomData.Skills);
		try
		{
			Class32 @class = new Class32();
			@class.int_0 = (int)int_;
			customDataSelectorForm.ChangeValue += @class.method_0;
			if (customDataSelectorForm.ShowDialog() == DialogResult.OK)
			{
				if (value is SkillID skillID2)
				{
					skillID2.Value = (uint)@class.int_0;
					return skillID2;
				}
				return new SkillID
				{
					Value = (uint)@class.int_0
				};
			}
			return value;
		}
		finally
		{
			((IDisposable)customDataSelectorForm).Dispose();
		}
	}
}
