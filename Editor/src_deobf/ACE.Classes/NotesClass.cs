using System;
using System.Windows.Forms;

namespace ACE.Classes;

public class NotesClass
{
	private SettingsClass settingsClass_0;

	public NotesClass()
	{
		string text = Class16.smethod_0(1648899435);
		settingsClass_0 = new SettingsClass(Application.StartupPath + text);
		GC.KeepAlive(this);
	}

	public void SetGame(string GamePrefix)
	{
		settingsClass_0.DefaultSection = GamePrefix;
	}

	public string GetNote(int int_0, int id)
	{
		int num = id;
		int num2 = int_0;
		string text = Class16.smethod_0(1648941518);
		string setting = settingsClass_0.GetSetting(string.Concat(string.Concat(Class16.smethod_0(1648899460) + num2, text), num.ToString()));
		GC.KeepAlive(this);
		return setting;
	}

	public void SetNote(int int_0, int id, string NoteText)
	{
		int num = id;
		int num2 = int_0;
		string text = Class16.smethod_0(1648941518);
		string settingName = string.Concat(string.Concat(Class16.smethod_0(1648899460) + num2, text), num.ToString());
		SettingsClass settingsClass = settingsClass_0;
		settingsClass.SaveSetting(settingsClass.DefaultSection, settingName, NoteText);
		GC.KeepAlive(this);
	}

	public void IDChanged(int int_0, int old_id, int new_id)
	{
		int num = old_id;
		int num2 = int_0;
		string text = Class16.smethod_0(1648941518);
		string setting = settingsClass_0.GetSetting(string.Concat(string.Concat(Class16.smethod_0(1648899460) + num2, text), num.ToString()));
		if (setting != string.Empty)
		{
			int num3 = new_id;
			int num4 = int_0;
			string text2 = Class16.smethod_0(1648941518);
			string settingName = string.Concat(string.Concat(Class16.smethod_0(1648899460) + num4, text2), num3.ToString());
			SettingsClass settingsClass = settingsClass_0;
			settingsClass.SaveSetting(settingsClass.DefaultSection, settingName, setting);
		}
		int num5 = old_id;
		int num6 = int_0;
		string text3 = Class16.smethod_0(1648941518);
		string settingName2 = string.Concat(string.Concat(Class16.smethod_0(1648899460) + num6, text3), num5.ToString());
		SettingsClass settingsClass2 = settingsClass_0;
		settingsClass2.DeleteSetting(settingsClass2.DefaultSection, settingName2);
		GC.KeepAlive(this);
	}
}
