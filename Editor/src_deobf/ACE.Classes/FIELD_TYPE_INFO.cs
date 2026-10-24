using System.Runtime.InteropServices;

namespace ACE.Classes;

public struct FIELD_TYPE_INFO(string Type, [MarshalAs(UnmanagedType.U1)] bool bRegex, [MarshalAs(UnmanagedType.U1)] bool bUserType)
{
	public string Type = Type;

	public bool bRegex = bRegex;

	public bool bUserType = bUserType;

	public FIELD_TYPE_INFO Clone()
	{
		return (FIELD_TYPE_INFO)MemberwiseClone();
	}
}
