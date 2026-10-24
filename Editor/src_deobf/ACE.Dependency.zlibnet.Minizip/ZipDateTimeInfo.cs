using System;

namespace ACE.Dependency.zlibnet.Minizip;

internal struct ZipDateTimeInfo
{
	public uint Seconds;

	public uint Minutes;

	public uint Hours;

	public uint Day;

	public uint Month;

	public uint Year;

	public static implicit operator ZipDateTimeInfo(DateTime date)
	{
		ZipDateTimeInfo result = default(ZipDateTimeInfo);
		result.Seconds = (uint)date.Second;
		result.Minutes = (uint)date.Minute;
		result.Hours = (uint)date.Hour;
		result.Day = (uint)date.Day;
		result.Month = (uint)(date.Month - 1);
		result.Year = (uint)date.Year;
		return result;
	}

	public static implicit operator DateTime(ZipDateTimeInfo date)
	{
		return new DateTime((int)date.Year, (int)(date.Month + 1), (int)date.Day, (int)date.Hours, (int)date.Minutes, (int)date.Seconds);
	}
}
