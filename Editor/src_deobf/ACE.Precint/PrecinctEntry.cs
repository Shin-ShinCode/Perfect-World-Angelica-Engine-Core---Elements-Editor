using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ACE.Precint;

public class PrecinctEntry
{
	[Serializable]
	private sealed class Class352
	{
		public static readonly Class352 class352_0 = new Class352();

		public static Func<string, bool> func_0;

		internal bool method_0(string string_0)
		{
			if (!string.IsNullOrWhiteSpace(string_0))
			{
				if (!string_0.TrimStart().StartsWith(Class16.smethod_0(1649191117), StringComparison.OrdinalIgnoreCase))
				{
					return string_0.TrimStart().StartsWith(Class16.smethod_0(1649191122), StringComparison.OrdinalIgnoreCase);
				}
				return true;
			}
			return false;
		}
	}

	private int int_0;

	private string string_0 = string.Empty;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private byte byte_0;

	private PrecinctVector3 precinctVector3_0 = new PrecinctVector3();

	private List<PrecinctVector3> list_0 = new List<PrecinctVector3>();

	private List<PrecinctNPC> list_1 = new List<PrecinctNPC>();

	private List<string> list_2 = new List<string>();

	public int ID
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public string name
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public int iNumPoint => m_aPoints?.Count ?? 0;

	public int iNumMark
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public int m_iPriority
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public int m_idDstIns
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	public int iNumMusic => music?.Count(Class352.class352_0.method_0) ?? 0;

	public int m_iMusicInter
	{
		[CompilerGenerated]
		get
		{
			return int_4;
		}
		[CompilerGenerated]
		set
		{
			int_4 = value;
		}
	}

	public int m_iMusicLoop
	{
		[CompilerGenerated]
		get
		{
			return int_5;
		}
		[CompilerGenerated]
		set
		{
			int_5 = value;
		}
	}

	public int m_idSrcInst
	{
		[CompilerGenerated]
		get
		{
			return int_6;
		}
		[CompilerGenerated]
		set
		{
			int_6 = value;
		}
	}

	public int m_idDomain
	{
		[CompilerGenerated]
		get
		{
			return int_7;
		}
		[CompilerGenerated]
		set
		{
			int_7 = value;
		}
	}

	public byte m_bPKProtect
	{
		[CompilerGenerated]
		get
		{
			return byte_0;
		}
		[CompilerGenerated]
		set
		{
			byte_0 = value;
		}
	}

	public PrecinctVector3 m_vCityPos
	{
		[CompilerGenerated]
		get
		{
			return precinctVector3_0;
		}
		[CompilerGenerated]
		set
		{
			precinctVector3_0 = value;
		}
	}

	public List<PrecinctVector3> m_aPoints
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	public List<PrecinctNPC> Npcs
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
		[CompilerGenerated]
		set
		{
			list_1 = value;
		}
	}

	public List<string> music
	{
		[CompilerGenerated]
		get
		{
			return list_2;
		}
		[CompilerGenerated]
		set
		{
			list_2 = value;
		}
	}

	public PrecinctEntry Clone()
	{
		PrecinctEntry precinctEntry = new PrecinctEntry();
		precinctEntry.ID = ID;
		precinctEntry.name = name + Class16.smethod_0(1649191143);
		precinctEntry.iNumMark = iNumMark;
		precinctEntry.m_iPriority = m_iPriority;
		precinctEntry.m_idDstIns = m_idDstIns;
		precinctEntry.m_iMusicInter = m_iMusicInter;
		precinctEntry.m_iMusicLoop = m_iMusicLoop;
		precinctEntry.m_idSrcInst = m_idSrcInst;
		precinctEntry.m_idDomain = m_idDomain;
		precinctEntry.m_bPKProtect = m_bPKProtect;
		precinctEntry.m_vCityPos = m_vCityPos.Clone();
		precinctEntry.m_aPoints = new List<PrecinctVector3>();
		foreach (PrecinctVector3 aPoint in m_aPoints)
		{
			precinctEntry.m_aPoints.Add(aPoint.Clone());
		}
		precinctEntry.Npcs = new List<PrecinctNPC>();
		foreach (PrecinctNPC npc in Npcs)
		{
			precinctEntry.Npcs.Add(npc.Clone());
		}
		precinctEntry.music = new List<string>(music);
		return precinctEntry;
	}
}
