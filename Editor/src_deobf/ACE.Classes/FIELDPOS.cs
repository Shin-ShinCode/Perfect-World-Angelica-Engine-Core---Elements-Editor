using System;
using System.Runtime.InteropServices;

namespace ACE.Classes;

public class FIELDPOS
{
	public int int_0;

	public int int_1;

	public int int_2;

	public FIELDPOS(ITEMPOS ItemPos, int FieldIndex)
	{
		int_0 = ItemPos.int_0;
		int_1 = ItemPos.int_1;
		int_2 = FieldIndex;
	}

	public FIELDPOS(int ListIndex, int ItemIndex, int FieldIndex)
	{
		int_0 = ListIndex;
		int_1 = ItemIndex;
		int_2 = FieldIndex;
	}

	public FIELDPOS()
	{
	}

	public FIELDPOS Clone()
	{
		return new FIELDPOS(int_0, int_1, int_2);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public override bool Equals(object obj)
	{
		if (!(obj is FIELDPOS fIELDPOS))
		{
			return false;
		}
		if (int_0 == fIELDPOS.int_0 && int_1 == fIELDPOS.int_1)
		{
			return int_2 == fIELDPOS.int_2;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine<int, int, int>(int_0, int_1, int_2);
	}
}
