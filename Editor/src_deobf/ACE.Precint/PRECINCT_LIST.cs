using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using ACE.RSGlobal;

namespace ACE.Precint;

public class PRECINCT_LIST
{
	public static Dictionary<string, PRECINCT> Precincts;

	public static bool FilesLoaded;

	public static void SetFiles(string[] Files)
	{
		if (Files != null && Files.Length != 0)
		{
			if (ACE.RSGlobal.RSGlobal.antirecurse_SetFiles_PRECINCT_LIST)
			{
				return;
			}
			ACE.RSGlobal.RSGlobal.antirecurse_SetFiles_PRECINCT_LIST = true;
			Precincts = new Dictionary<string, PRECINCT>(Files.Length);
			int num = 0;
			if (0 < (nint)Files.LongLength)
			{
				do
				{
					string text = Files[num];
					if (!string.IsNullOrWhiteSpace(text) && File.Exists(text))
					{
						string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(System.IO.Path.GetDirectoryName(text));
						if (!Precincts.ContainsKey(fileNameWithoutExtension))
						{
							PRECINCT pRECINCT = new PRECINCT(text);
							if (pRECINCT.FileLoaded)
							{
								pRECINCT.SortAreas();
								pRECINCT.MapTag = fileNameWithoutExtension;
								Precincts.Add(fileNameWithoutExtension, pRECINCT);
							}
						}
					}
					num++;
				}
				while (num < (nint)Files.LongLength);
			}
			FilesLoaded = Precincts.Count > 0;
			ACE.RSGlobal.RSGlobal.antirecurse_SetFiles_PRECINCT_LIST = false;
		}
		else
		{
			FilesLoaded = false;
			if (Precincts != null)
			{
				Precincts.Clear();
			}
			Precincts = null;
		}
	}

	public unsafe static string GetAreaName(string ClientMapTag, int instance_id, float[] vPos, bool* IsCementry)
	{
		if (string.IsNullOrWhiteSpace(ClientMapTag))
		{
			return string.Empty;
		}
		string text;
		if (Precincts != null && Precincts.ContainsKey(ClientMapTag))
		{
			PointF pointF = new PointF(vPos[0], vPos[2]);
			PointF point = pointF;
			text = Precincts[ClientMapTag].GetAreaNameByPoint(instance_id, point, IsCementry);
			if (text == null)
			{
				text = Class16.smethod_0(1649189037);
			}
		}
		else
		{
			text = Class16.smethod_0(1649189049);
		}
		return text;
	}

	public unsafe static PRECINCT_AREA GetArea(string ClientMapTag, int instance_id, float[] vPos, bool* IsCementry)
	{
		if (string.IsNullOrWhiteSpace(ClientMapTag))
		{
			return null;
		}
		PRECINCT_AREA pRECINCT_AREA = null;
		if (Precincts != null && Precincts.ContainsKey(ClientMapTag))
		{
			PointF pointF = new PointF(vPos[0], vPos[2]);
			PointF point = pointF;
			pRECINCT_AREA = Precincts[ClientMapTag].GetAreaByPoint(instance_id, point, IsCementry);
			if (pRECINCT_AREA == null)
			{
				pRECINCT_AREA = new PRECINCT_AREA(Class16.smethod_0(1649189037));
			}
		}
		return pRECINCT_AREA;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool GetAreaID(string ClientMapTag, int instance_id, float[] vPos)
	{
		if (string.IsNullOrWhiteSpace(ClientMapTag))
		{
			return false;
		}
		if (Precincts != null && Precincts.ContainsKey(ClientMapTag))
		{
			PointF pointF = new PointF(vPos[0], vPos[2]);
			PointF point = pointF;
			return Precincts[ClientMapTag].GetAreaIdByPoint(instance_id, point) != 0;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool IsPointVisible(string ClientMapTag, int area_id, float[] vPos)
	{
		if (string.IsNullOrWhiteSpace(ClientMapTag))
		{
			return false;
		}
		if (Precincts != null && Precincts.ContainsKey(ClientMapTag))
		{
			PointF pointF = new PointF(vPos[0], vPos[2]);
			PointF point = pointF;
			return Precincts[ClientMapTag].IsPointVisible(area_id, point);
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool IsPointVisibleS(string ClientMapTag, string area_name, float[] vPos, [MarshalAs(UnmanagedType.U1)] bool bCheckContains)
	{
		if (string.IsNullOrWhiteSpace(ClientMapTag))
		{
			return false;
		}
		if (Precincts != null && Precincts.ContainsKey(ClientMapTag))
		{
			PointF pointF = new PointF(vPos[0], vPos[2]);
			PointF point = pointF;
			return Precincts[ClientMapTag].IsPointVisibleS(area_name, point, bCheckContains);
		}
		return false;
	}
}
