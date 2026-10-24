using System.Runtime.InteropServices;

namespace ACE.Classes;

public class ITEMPOS
{
	public int int_0;

	public int int_1;

	public ITEMPOS(int ListIndex, int ItemIndex)
	{
		int_0 = ListIndex;
		int_1 = ItemIndex;
	}

	public ITEMPOS()
	{
		int_0 = -1;
		int_1 = -1;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsValid()
	{
		int num = ((int_0 > -1 && int_1 > -1) ? 1 : 0);
		return (byte)num != 0;
	}

	public ITEMPOS Clone()
	{
		return new ITEMPOS(int_0, int_1);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public override bool Equals(object obj)
	{
		if (obj is ITEMPOS iTEMPOS && int_0 == iTEMPOS.int_0 && int_1 == iTEMPOS.int_1)
		{
			return true;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool operator ==(ITEMPOS left, ITEMPOS right)
	{
		if ((object)left == null && (object)right == null)
		{
			return true;
		}
		if ((object)left != null && (object)right != null)
		{
			if (left.int_0 == right.int_0)
			{
				return left.int_1 == right.int_1;
			}
			return false;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool operator !=(ITEMPOS left, ITEMPOS right)
	{
		return !(left == right);
	}

	public override int GetHashCode()
	{
		return int_0 * 1000000 + int_1;
	}
}
