using System;
using System.ComponentModel;
using System.Globalization;

namespace ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

public class TargetParamTypeConverter : ExpandableObjectConverter
{
	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (destinationType == typeof(string))
		{
			return true;
		}
		return base.CanConvertTo(context, destinationType);
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (destinationType == typeof(string) && value is TargetParam targetParam)
		{
			return targetParam.ToString();
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}
}
