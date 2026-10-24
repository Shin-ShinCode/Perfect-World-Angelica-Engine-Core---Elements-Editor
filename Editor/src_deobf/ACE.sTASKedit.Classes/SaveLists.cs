using System.IO;
using ACE.sTASKedit.tasks;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Classes;

internal class SaveLists
{
	public static void save_CreatureBuilder(ATaskTempl task, StreamWriter sw)
	{
		string text = string.Empty;
		if (task.m_lMonsCtrl > 0 || task.m_Award_S.m_lMonsCtrl > 0 || task.m_Award_F.m_lMonsCtrl > 0)
		{
			text = text + task.m_ID + Class16.smethod_0(1648904383) + GlobalFunctions.ColorClean(task.Name);
			text = ((task.m_lMonsCtrl <= 0) ? (text + Class16.smethod_0(1649254432)) : (text + Class16.smethod_0(1648904383) + task.m_lMonsCtrl));
			text = ((task.m_Award_S.m_lMonsCtrl <= 0) ? (text + Class16.smethod_0(1649254432)) : (text + Class16.smethod_0(1648904383) + task.m_Award_S.m_lMonsCtrl));
			text = ((task.m_Award_F.m_lMonsCtrl <= 0) ? (text + Class16.smethod_0(1649254432)) : (text + Class16.smethod_0(1648904383) + task.m_Award_F.m_lMonsCtrl));
		}
		if (text != string.Empty)
		{
			sw.WriteLine(text);
		}
		for (int i = 0; i < task.pSub.Length; i++)
		{
			save_CreatureBuilder(task.pSub[i], sw);
		}
	}

	public static void save_SkillList(ATaskTempl task, StreamWriter sw)
	{
		string text = string.Empty;
		if (task.m_iDeliveredSkillID > 0 || task.m_Award_S.m_iAwardSkillID > 0 || task.m_Award_F.m_iAwardSkillID > 0)
		{
			text = text + task.m_ID + Class16.smethod_0(1648904383) + GlobalFunctions.ColorClean(task.Name);
			text = ((task.m_iDeliveredSkillID <= 0) ? (text + Class16.smethod_0(1649254432)) : (text + Class16.smethod_0(1648904383) + task.m_iDeliveredSkillID));
			text = ((task.m_Award_S.m_iAwardSkillID <= 0) ? (text + Class16.smethod_0(1649254432)) : (text + Class16.smethod_0(1648904383) + task.m_Award_S.m_iAwardSkillID));
			text = ((task.m_Award_F.m_iAwardSkillID <= 0) ? (text + Class16.smethod_0(1649254432)) : (text + Class16.smethod_0(1648904383) + task.m_Award_F.m_iAwardSkillID));
		}
		if (text != string.Empty)
		{
			sw.WriteLine(text);
		}
		for (int i = 0; i < task.pSub.Length; i++)
		{
			save_SkillList(task.pSub[i], sw);
		}
	}

	public static void save_Test(ATaskTempl task, StreamWriter sw)
	{
		string text = string.Empty;
		if (task.m_usZoneMapID > 1)
		{
			text = text + task.m_ID + Class16.smethod_0(1648904383) + GlobalFunctions.ColorClean(task.Name);
			text = text + Class16.smethod_0(1648904383) + task.m_usZoneMapID;
		}
		if (task.m_ulTMReachArenaWinCount != 0)
		{
			text = text + task.m_ID + Class16.smethod_0(1648904383) + GlobalFunctions.ColorClean(task.Name);
			text = text + Class16.smethod_0(1648904383) + task.m_ulTMReachArenaWinCount;
		}
		if (text != string.Empty)
		{
			sw.WriteLine(text);
		}
		for (int i = 0; i < task.pSub.Length; i++)
		{
			save_Test(task.pSub[i], sw);
		}
	}
}
