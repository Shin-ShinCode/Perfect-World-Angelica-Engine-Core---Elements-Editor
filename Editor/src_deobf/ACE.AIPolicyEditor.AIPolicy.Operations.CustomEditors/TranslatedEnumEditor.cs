using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

public class TranslatedEnumEditor : UITypeEditor
{
	private sealed class Class34
	{
		private object object_0;

		private string string_0;

		public object method_0()
		{
			return object_0;
		}

		public void method_1(object object_1)
		{
			object_0 = object_1;
		}

		public string method_2()
		{
			return string_0;
		}

		public void method_3(string string_1)
		{
			string_0 = string_1;
		}

		public override string ToString()
		{
			return method_2();
		}
	}

	private sealed class Class35
	{
		public IWindowsFormsEditorService iwindowsFormsEditorService_0;

		internal void method_0(object sender, EventArgs e)
		{
			iwindowsFormsEditorService_0.CloseDropDown();
		}
	}

	public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
	{
		return UITypeEditorEditStyle.DropDown;
	}

	public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
	{
		Class35 @class = new Class35();
		if (provider == null)
		{
			return value;
		}
		@class.iwindowsFormsEditorService_0 = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
		if (@class.iwindowsFormsEditorService_0 == null)
		{
			return value;
		}
		Type type = value?.GetType();
		if (!(type == null) && type.IsEnum)
		{
			ListBox listBox = new ListBox();
			listBox.BorderStyle = BorderStyle.None;
			Array values = Enum.GetValues(type);
			string[] names = Enum.GetNames(type);
			List<Class34> list = new List<Class34>();
			int num = values.Length - 1;
			for (int i = 0; i < num; i++)
			{
				object value2 = values.GetValue(i);
				string text = names[i];
				string string_ = MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648938914) + text) ?? text;
				Class34 class2 = new Class34();
				class2.method_1(value2);
				class2.method_3(string_);
				Class34 item = class2;
				list.Add(item);
				listBox.Items.Add(item);
				if (value2.Equals(value))
				{
					listBox.SelectedIndex = i;
				}
			}
			listBox.Height = Math.Min(listBox.Items.Count * listBox.ItemHeight + 4, 200);
			listBox.SelectedIndexChanged += @class.method_0;
			@class.iwindowsFormsEditorService_0.DropDownControl(listBox);
			if (listBox.SelectedItem is Class34 class3)
			{
				return class3.method_0();
			}
			return value;
		}
		return value;
	}
}
