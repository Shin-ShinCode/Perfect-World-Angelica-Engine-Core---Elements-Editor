using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class AWARD_ITEMS_CAND
{
	private bool bool_0;

	private int int_0;

	private ITEM_WANTED[] item_WANTED_0 = new ITEM_WANTED[0];

	public bool m_bRandChoose
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public int m_ulAwardItems
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

	public ITEM_WANTED[] m_AwardItems
	{
		[CompilerGenerated]
		get
		{
			return item_WANTED_0;
		}
		[CompilerGenerated]
		set
		{
			item_WANTED_0 = value;
		}
	}

	internal static void Read(int version, BinaryReader br, AWARD_ITEMS_CAND AC)
	{
		AC.m_bRandChoose = br.ReadBoolean();
		AC.m_ulAwardItems = br.ReadInt32();
		AC.m_AwardItems = new ITEM_WANTED[AC.m_ulAwardItems];
		for (int i = 0; i < AC.m_ulAwardItems; i++)
		{
			AC.m_AwardItems[i] = new ITEM_WANTED();
			ITEM_WANTED.Read(version, br, AC.m_AwardItems[i]);
		}
	}

	internal static void Write(int version, BinaryWriter bw, AWARD_ITEMS_CAND AC)
	{
		if (AC == null)
		{
			bw.Write(value: false);
			bw.Write(0);
			return;
		}
		ITEM_WANTED[] array = AC.m_AwardItems ?? Array.Empty<ITEM_WANTED>();
		AC.m_ulAwardItems = array.Length;
		bw.Write(AC.m_bRandChoose);
		bw.Write(AC.m_ulAwardItems);
		for (int i = 0; i < AC.m_ulAwardItems; i++)
		{
			ITEM_WANTED.Write(version, bw, array[i] ?? new ITEM_WANTED());
		}
	}
}
