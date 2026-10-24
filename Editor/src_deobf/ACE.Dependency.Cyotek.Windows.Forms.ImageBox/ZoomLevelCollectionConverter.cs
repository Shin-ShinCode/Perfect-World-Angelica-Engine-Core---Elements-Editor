using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace ACE.Dependency.Cyotek.Windows.Forms.ImageBox;

public class ZoomLevelCollectionConverter : TypeConverter
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
		if (!(destinationType == typeof(InstanceDescriptor)))
		{
			return base.CanConvertTo(context, destinationType);
		}
		return true;
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		string text = value as string;
		ZoomLevelCollection zoomLevelCollection;
		if (!string.IsNullOrEmpty(text))
		{
			if (culture == null)
			{
				culture = CultureInfo.CurrentCulture;
			}
			zoomLevelCollection = new ZoomLevelCollection();
			char c = culture.TextInfo.ListSeparator[0];
			string[] array = text.Split(c);
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
			string[] array2 = array;
			foreach (string text2 in array2)
			{
				zoomLevelCollection.Add((int)converter.ConvertFromString(context, culture, text2));
			}
		}
		else
		{
			zoomLevelCollection = null;
		}
		return zoomLevelCollection;
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (destinationType == null)
		{
			throw new ArgumentNullException(Class16.smethod_0(1648892454));
		}
		object obj;
		if (value is ZoomLevelCollection)
		{
			if (destinationType == typeof(string))
			{
				ZoomLevelCollection zoomLevelCollection = (ZoomLevelCollection)value;
				if (culture == null)
				{
					culture = CultureInfo.CurrentCulture;
				}
				string value2 = culture.TextInfo.ListSeparator + Class16.smethod_0(1648942211);
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
				StringBuilder stringBuilder = new StringBuilder();
				foreach (int item in zoomLevelCollection)
				{
					if (stringBuilder.Length != 0)
					{
						stringBuilder.Append(value2);
					}
					stringBuilder.Append(converter.ConvertToString(context, culture, item));
				}
				obj = stringBuilder.ToString();
			}
			else if (destinationType == typeof(InstanceDescriptor))
			{
				ZoomLevelCollection zoomLevelCollection2 = (ZoomLevelCollection)value;
				ConstructorInfo constructor = typeof(ZoomLevelCollection).GetConstructor(new Type[1] { typeof(IList<int>) });
				obj = new InstanceDescriptor(constructor, new object[1] { zoomLevelCollection2.ToArray() });
			}
			else
			{
				obj = null;
			}
		}
		else
		{
			obj = null;
		}
		if (obj == null)
		{
			obj = base.ConvertTo(context, culture, value, destinationType);
		}
		return obj;
	}
}
