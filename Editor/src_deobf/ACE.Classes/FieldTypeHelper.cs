using System.Runtime.InteropServices;

namespace ACE.Classes;

public class FieldTypeHelper
{
	[return: MarshalAs(UnmanagedType.U1)]
	public static bool IsAnyList(FIELDTYPE ftype)
	{
		int num = (((ftype >= FIELDTYPE.matters && ftype <= FIELDTYPE.any_list) || ftype == FIELDTYPE.equip_addon || ftype == FIELDTYPE.refine_addon_pw) ? 1 : 0);
		return (byte)num != 0;
	}
}
