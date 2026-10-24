using System;
using System.Runtime.InteropServices;

namespace ACE.Classes;

[Serializable]
public struct vITEMPOS
{
	private int _l;

	private int _e;

	public int Int32_0
	{
		get
		{
			return _e;
		}
		set
		{
			_e = value;
		}
	}

	public int Int32_1
	{
		get
		{
			return _l;
		}
		set
		{
			_l = value;
		}
	}

	public vITEMPOS(ITEMPOS ItemPos)
	{
		_l = ItemPos.int_0;
		_e = ItemPos.int_1;
	}

	public vITEMPOS(int ListIndex, int ItemIndex)
	{
		_l = ListIndex;
		_e = ItemIndex;
	}

	public ITEMPOS ToRef()
	{
		int e = _e;
		return new ITEMPOS(_l, e);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsValid()
	{
		int num = ((_l > -1 && _e > -1) ? 1 : 0);
		return (byte)num != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public override bool Equals(object obj)
	{
		vITEMPOS vITEMPOS2 = (vITEMPOS)obj;
		int num = ((_l == vITEMPOS2._l && _e == vITEMPOS2._e) ? 1 : 0);
		return (byte)num != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool operator ==(vITEMPOS left, vITEMPOS right)
	{
		if (left._l == right._l)
		{
			return left._e == right._e;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool operator !=(vITEMPOS left, vITEMPOS right)
	{
		return !(left == right);
	}

	public override int GetHashCode()
	{
		return _l * 1000000 + _e;
	}
}
