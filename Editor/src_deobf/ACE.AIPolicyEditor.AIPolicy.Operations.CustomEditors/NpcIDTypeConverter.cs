using System;
using System.ComponentModel;
using System.Globalization;

namespace ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

public class NpcIDTypeConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		if (!(sourceType == typeof(string)))
		{
			return base.CanConvertFrom(context, sourceType);
		}
		return true;
	}

	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (!(destinationType == typeof(string)))
		{
			return base.CanConvertTo(context, destinationType);
		}
		return true;
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value is string text)
		{
			string s = text.Split(' ')[0];
			if (uint.TryParse(s, out var result))
			{
				return new NpcID
				{
					Value = result
				};
			}
		}
		return base.ConvertFrom(context, culture, value);
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (value is NpcID npcID && destinationType == typeof(string))
		{
			return npcID.ToString();
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}
}
