using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;

namespace ACE.RSGlobal;

internal class EnumDescriptionConverter : EnumConverter
{
	private Type type_0;

	public EnumDescriptionConverter(Type type)
		: base(type)
	{
		type_0 = type;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
	{
		bool result = destType == typeof(string);
		GC.KeepAlive(this);
		return result;
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
	{
		string text = value.ToString().Replace('_', ' ');
		if (text == Class16.smethod_0(1648902775))
		{
			text = Class16.smethod_0(1649167136);
		}
		GC.KeepAlive(this);
		return text;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type srcType)
	{
		bool result = srcType == typeof(string);
		GC.KeepAlive(this);
		return result;
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		string text = ((string)value).Replace(' ', '_').Replace(Class16.smethod_0(1649167147), Class16.smethod_0(1648942920));
		if (text == Class16.smethod_0(1649167136))
		{
			text = Class16.smethod_0(1648902775);
		}
		object result = Enum.Parse(type_0, text);
		GC.KeepAlive(this);
		return result;
	}
}
