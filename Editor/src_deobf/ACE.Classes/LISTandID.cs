using System;
using System.Runtime.InteropServices;

namespace ACE.Classes;

[Serializable]
public struct LISTandID
{
	private int _l;

	private int _id;

	public int id
	{
		get
		{
			return _id;
		}
		set
		{
			_id = value;
		}
	}

	public int Int32_0
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

	public LISTandID(int ListIndex, int id)
	{
		_l = ListIndex;
		id = ((id > 1000000) ? 100000 : id);
		_id = id;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public override bool Equals(object obj)
	{
		LISTandID lISTandID = (LISTandID)obj;
		int num = ((_l == lISTandID._l && _id == lISTandID._id) ? 1 : 0);
		return (byte)num != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool operator ==(LISTandID left, LISTandID right)
	{
		if (left._l == right._l)
		{
			return left._id == right._id;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool operator !=(LISTandID left, LISTandID right)
	{
		return !(left == right);
	}

	public override int GetHashCode()
	{
		return _l * 1000000 + _id;
	}

	public int ToInt32()
	{
		return _l * 1000000 + _id;
	}
}
