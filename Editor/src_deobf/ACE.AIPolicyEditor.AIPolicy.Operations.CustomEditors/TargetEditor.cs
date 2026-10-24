using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

public class TargetEditor : UITypeEditor
{
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
		TargetParam param = (value as TargetParam) ?? new TargetParam();
		TargetEditorForm targetEditorForm = new TargetEditorForm(param);
		try
		{
			if (targetEditorForm.ShowDialog() == DialogResult.OK)
			{
				return targetEditorForm.Result;
			}
			return value;
		}
		finally
		{
			((IDisposable)targetEditorForm).Dispose();
		}
	}
}
