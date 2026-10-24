using System;
using System.IO;
using System.Runtime.InteropServices;
using ACE.Classes;
using ACE.RSGlobal;

namespace ACE.NpcGen;

[Serializable]
public class NPCCtrl
{
	private int _id;

	private int _iControllerID;

	public byte[] name;

	private bool _bActived;

	private int _iWaitTime;

	private int _iStopTime;

	private bool _bActiveTimeInvalid;

	private bool _bStopTimeInvalid;

	private Time _Time1;

	private Time _Time2;

	private int _iActiveTimeRange;

	private bool _bRepeatActived;

	private long _mZoneMask;

	public string Name
	{
		get
		{
			string result = ACE.RSGlobal.RSGlobal.ToStringGBK(name);
			GC.KeepAlive(this);
			return result;
		}
		set
		{
			name = ACE.RSGlobal.RSGlobal.ToBytesGBK(value, 128);
			GC.KeepAlive(this);
		}
	}

	public long mZoneMask
	{
		get
		{
			return _mZoneMask;
		}
		set
		{
			_mZoneMask = value;
		}
	}

	public bool bRepeatActived
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _bRepeatActived;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_bRepeatActived = value;
		}
	}

	public int iActiveTimeRange
	{
		get
		{
			return _iActiveTimeRange;
		}
		set
		{
			_iActiveTimeRange = value;
		}
	}

	public Time Time2
	{
		get
		{
			return _Time2;
		}
		set
		{
			_Time2 = value;
		}
	}

	public Time Time1
	{
		get
		{
			return _Time1;
		}
		set
		{
			_Time1 = value;
		}
	}

	public bool bStopTimeInvalid
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _bStopTimeInvalid;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_bStopTimeInvalid = value;
		}
	}

	public bool bActiveTimeInvalid
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _bActiveTimeInvalid;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_bActiveTimeInvalid = value;
		}
	}

	public int iStopTime
	{
		get
		{
			return _iStopTime;
		}
		set
		{
			_iStopTime = value;
		}
	}

	public int iWaitTime
	{
		get
		{
			return _iWaitTime;
		}
		set
		{
			_iWaitTime = value;
		}
	}

	public bool bActived
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _bActived;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_bActived = value;
		}
	}

	public int iControllerID
	{
		get
		{
			return _iControllerID;
		}
		set
		{
			_iControllerID = value;
		}
	}

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

	public void Write(BinaryWriter bw, int version)
	{
		bw.Write(_id);
		bw.Write(_iControllerID);
		bw.Write(name);
		bw.Write(_bActived);
		bw.Write(_iWaitTime);
		bw.Write(_iStopTime);
		bw.Write(_bActiveTimeInvalid);
		bw.Write(_bStopTimeInvalid);
		_Time1.Write(bw);
		_Time2.Write(bw);
		if (version >= 8)
		{
			bw.Write(_iActiveTimeRange);
		}
		if (version >= 11)
		{
			bw.Write(_bRepeatActived);
		}
		if (version >= 15)
		{
			bw.Write(_mZoneMask);
		}
		GC.KeepAlive(this);
	}

	public NPCCtrl Clone()
	{
		NPCCtrl nPCCtrl = (NPCCtrl)MemberwiseClone();
		nPCCtrl.name = ACE.RSGlobal.RSGlobal.CloneArray(name);
		Time time = _Time1;
		nPCCtrl._Time1 = time.Clone();
		Time time2 = _Time2;
		nPCCtrl._Time2 = time2.Clone();
		GC.KeepAlive(this);
		return nPCCtrl;
	}
}
