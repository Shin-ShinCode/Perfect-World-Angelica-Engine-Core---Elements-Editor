using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;

namespace ACE.Classes;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[TypeConverter(typeof(ExpandableObjectConverter))]
public class Time
{
	private int _iYear;

	private int _iMouth;

	private int _iWeek;

	private int _iDay;

	private int _iHours;

	private int _iMinutes;

	public Time(BinaryReader br)
	{
		_iYear = br.ReadInt32();
		_iMouth = br.ReadInt32();
		_iWeek = br.ReadInt32();
		_iDay = br.ReadInt32();
		_iHours = br.ReadInt32();
		_iMinutes = br.ReadInt32();
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(_iYear);
		bw.Write(_iMouth);
		bw.Write(_iWeek);
		bw.Write(_iDay);
		bw.Write(_iHours);
		bw.Write(_iMinutes);
	}

	public Time Clone()
	{
		return (Time)MemberwiseClone();
	}
}
