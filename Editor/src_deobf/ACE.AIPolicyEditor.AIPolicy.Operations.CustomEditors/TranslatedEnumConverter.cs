using System;
using System.ComponentModel;
using System.Globalization;

namespace ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

public class TranslatedEnumConverter : EnumConverter
{
	public TranslatedEnumConverter(Type type)
		: base(type)
	{
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (destinationType == typeof(string) && value != null)
		{
			string text = value.ToString();
			string localizedString = MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648938914) + text);
			return localizedString ?? text;
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value is string text)
		{
			foreach (object value2 in Enum.GetValues(base.EnumType))
			{
				string text2 = value2.ToString();
				string text3 = MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648938914) + text2) ?? text2;
				if (text3 == text || text2 == text)
				{
					return value2;
				}
			}
		}
		return base.ConvertFrom(context, culture, value);
	}
}
