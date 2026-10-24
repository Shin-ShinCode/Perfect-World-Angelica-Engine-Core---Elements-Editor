using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using ACE.Classes;
using ACE.RSGlobal;

namespace ACE.Precint;

public class PRECINCT
{
	public string MapTag;

	public int MapIndex;

	public List<PRECINCT_AREA> Areas;

	public Dictionary<string, int> UniqueAreas;

	public string FileName;

	public bool FileLoaded;

	public int version;

	public int timestamp;

	public PRECINCT(string fn)
	{
		Load(fn);
	}

	public void Load(string fn)
	{
		if (!File.Exists(fn))
		{
			GC.KeepAlive(this);
			return;
		}
		EditorSessionTracker.LogFolderAccess(fn, Class16.smethod_0(1648903793), Class16.smethod_0(1649188979));
		FileName = fn;
		Areas = new List<PRECINCT_AREA>();
		UniqueAreas = new Dictionary<string, int>();
		StreamReader streamReader = null;
		try
		{
			streamReader = File.OpenText(fn);
			while (true)
			{
				string text = streamReader.ReadLine();
				if (text == null)
				{
					break;
				}
				if (string.IsNullOrWhiteSpace(text) || text[0] == '/')
				{
					continue;
				}
				if (text.Length > 2 && text[0] == '"')
				{
					PRECINCT_AREA pRECINCT_AREA = new PRECINCT_AREA(text.Substring(1, text.Length - 2).Trim(), streamReader, version);
					if (UniqueAreas.ContainsKey(pRECINCT_AREA.Name))
					{
						pRECINCT_AREA.areaIndex = UniqueAreas[pRECINCT_AREA.Name];
					}
					else
					{
						UniqueAreas.Add(pRECINCT_AREA.Name, pRECINCT_AREA.ID);
						pRECINCT_AREA.areaIndex = UniqueAreas.Count + 1;
					}
					if (pRECINCT_AREA.pointCount > 0)
					{
						Areas.Add(pRECINCT_AREA);
					}
				}
				else if (text.StartsWith(Class16.smethod_0(1649074689)))
				{
					int.TryParse(text.Replace(Class16.smethod_0(1649188994), string.Empty).Trim(), out version);
					int.TryParse(streamReader.ReadLine().Trim(), out timestamp);
				}
			}
			FileLoaded = true;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649189009));
			FileLoaded = false;
			string key = Class16.smethod_0(1648893578);
			ex.Data.Add(key, fn);
			ACE.RSGlobal.RSGlobal.ShowHandledException(ex);
		}
		finally
		{
			streamReader?.Close();
		}
		GC.KeepAlive(this);
	}

	public void SortAreas()
	{
		List<PRECINCT_AREA> list = new List<PRECINCT_AREA>(Areas.Count);
		int num = 0;
		if (0 < Areas.Count)
		{
			do
			{
				int index = -1;
				double num2 = double.MaxValue;
				int num3 = 0;
				if (0 < Areas.Count)
				{
					do
					{
						if (Areas[num3] != null && Areas[num3].area < num2)
						{
							num2 = Areas[num3].area;
							index = num3;
						}
						num3++;
					}
					while (num3 < Areas.Count);
				}
				list.Add(Areas[index]);
				Areas[index] = null;
				num++;
			}
			while (num < Areas.Count);
		}
		Areas = list;
	}

	public unsafe string GetAreaNameByPoint(int instance_id, PointF point, bool* IsCementry)
	{
		List<PRECINCT_AREA>.Enumerator enumerator = Areas.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				PRECINCT_AREA current = enumerator.Current;
				if ((instance_id <= 0 || current.instance_id == instance_id) && current.region.IsVisible(point))
				{
					if (current.ID == 1501 && current.area >= 1068363.0)
					{
						*IsCementry = true;
					}
					GC.KeepAlive(this);
					return current.Name;
				}
			}
			while (enumerator.MoveNext());
		}
		return null;
	}

	public unsafe PRECINCT_AREA GetAreaByPoint(int instance_id, PointF point, bool* IsCementry)
	{
		List<PRECINCT_AREA>.Enumerator enumerator = Areas.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				PRECINCT_AREA current = enumerator.Current;
				if ((instance_id <= 0 || current.instance_id == instance_id) && current.region.IsVisible(point))
				{
					if (current.ID == 1501 && current.area >= 1068363.0)
					{
						*IsCementry = true;
					}
					GC.KeepAlive(this);
					return current;
				}
			}
			while (enumerator.MoveNext());
		}
		return null;
	}

	public int GetAreaIdByPoint(int instance_id, PointF point)
	{
		List<PRECINCT_AREA>.Enumerator enumerator = Areas.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				PRECINCT_AREA current = enumerator.Current;
				if ((instance_id <= 0 || current.instance_id == instance_id) && current.region.IsVisible(point))
				{
					GC.KeepAlive(this);
					return current.ID;
				}
			}
			while (enumerator.MoveNext());
		}
		return 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsPointVisible(int area_id, PointF point)
	{
		List<PRECINCT_AREA>.Enumerator enumerator = Areas.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				PRECINCT_AREA current = enumerator.Current;
				if (current.ID == area_id)
				{
					bool result = current.region.IsVisible(point);
					GC.KeepAlive(this);
					return result;
				}
			}
			while (enumerator.MoveNext());
		}
		GC.KeepAlive(this);
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsPointVisibleS(string area_name, PointF point, [MarshalAs(UnmanagedType.U1)] bool bCheckContains)
	{
		bool result = false;
		List<PRECINCT_AREA>.Enumerator enumerator = Areas.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				PRECINCT_AREA current = enumerator.Current;
				if ((!bCheckContains) ? (current.Name == area_name) : current.Name.Contains(area_name))
				{
					result = current.region.IsVisible(point);
					break;
				}
			}
			while (enumerator.MoveNext());
		}
		GC.KeepAlive(this);
		return result;
	}
}
