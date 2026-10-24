using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes.ACE;
using ACE.License;
using ACE.MainWindow;
using ACE.RSGlobal;
using ACE.Settings;
using ACE.sTASKedit;
using ACE.sTASKedit.MainEditor;
using ACE.sTASKedit.tasks;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.Classes;

public class CommonStorage
{
	private sealed class Class56
	{
		public MainEditor mainEditor_0;

		public CommonStorage commonStorage_0;

		public int int_0;

		public MultiSelectTreeView multiSelectTreeView_0;

		internal void method_0()
		{
			if (!mainEditor_0.IsDisposed && !mainEditor_0.Disposing && !multiSelectTreeView_0.IsDisposed && !multiSelectTreeView_0.Disposing && multiSelectTreeView_0.Nodes.Count > 0)
			{
				commonStorage_0.method_1(multiSelectTreeView_0, int_0);
			}
		}
	}

	[Serializable]
	private sealed class Class57
	{
		public static readonly Class57 class57_0 = new Class57();

		public static Func<string, DateTime> func_0;

		internal DateTime method_0(string string_0)
		{
			return File.GetCreationTime(string_0);
		}
	}

	public const string WebsiteBaseUrl = "https://angelicacore.com";

	public const string UpdatesFeedUrl = "https://angelicacore.com/updates/updates.txt";

	public const string InstallerDownloadUrl = "https://angelicacore.com/download/installer";

	public static RSCrypt SecretEncoder = new RSCrypt(bGenerateKey: true);

	public static RSCrypt SecretDecoder = new RSCrypt(bGenerateKey: false);

	public static LICENSE_INFO License;

	public static SettingsClass DefaultProfile;

	public static SettingsClass Profile;

	public static TextStorage Texts;

	public static int LangIndex;

	public static Cursor PWCursor1;

	public static ParamsClass Params;

	public static ADDITIONAL_PARAMS AParams;

	public static COMMAND_LINE_FLAGS CmdFlags = default(COMMAND_LINE_FLAGS);

	public static string CmdLine;

	public static ITEMPOS CurrentItemPos;

	public static int[] SelectedElItems;

	public static List<vITEMPOS> SelectedElItemsSmart;

	public bool IsElementsBusy;

	public short elVersion;

	public static object oData;

	public static string sData;

	public static bool bData;

	public static int iData;

	public string[] Shortcuts;

	public static int[] iarr1;

	public static int[] iarr2;

	public static string[] sarr1;

	public global::ACE.MainWindow.MainWindow MainWindowForm;

	public static RSWindow TasksWindow_apfilipp = new RSWindow(string.Empty, Class16.smethod_0(1648906795));

	public static RSWindow TasksWindow_JoLan = new RSWindow(Class16.smethod_0(1648906818), null);

	public static RSWindow TasksWindow_Rey = new RSWindow(string.Empty, Class16.smethod_0(1648906854));

	public static FolderBrowserDialog folderBrowserDialog;

	public static string UpdaterExePath => System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648906864));

	public static string UpdateFN
	{
		get
		{
			string text = Class16.smethod_0(1648906882);
			return Application.StartupPath + text;
		}
	}

	public CommonStorage(string[] args)
	{
		SettingsClass.EnsureDefaultProfileLocationMigrated();
		DefaultProfile = new SettingsClass(null);
		string text = DefaultProfile.GetSetting(Class16.smethod_0(1648907680));
		if (SettingsClass.IsDefaultProfilePath(text))
		{
			text = SettingsClass.DefaultFileName;
		}
		else if (!string.IsNullOrWhiteSpace(text))
		{
			text = SettingsClass.NormalizeProfilePath(text) ?? text;
		}
		if (!string.IsNullOrEmpty(text) && File.Exists(text))
		{
			Profile = new SettingsClass(text);
		}
		else
		{
			Profile = DefaultProfile;
		}
		CmdFlags.LangIndex = -1;
		ParseCmdLine(args);
		if (CmdFlags.ACEProject)
		{
			Profile = new SettingsClass(CmdFlags.profileFN);
		}
		string twoLetterISOLanguageName = CultureInfo.InstalledUICulture.TwoLetterISOLanguageName;
		int num;
		if (twoLetterISOLanguageName != null)
		{
			int length = twoLetterISOLanguageName.Length;
			if (length == 2)
			{
				switch (twoLetterISOLanguageName[0])
				{
				case 'm':
					if (!(twoLetterISOLanguageName == Class16.smethod_0(1648907719)))
					{
						break;
					}
					goto IL_0111;
				case 'i':
					if (!(twoLetterISOLanguageName == Class16.smethod_0(1648932143)))
					{
						break;
					}
					goto IL_0111;
				case 'z':
					if (!(twoLetterISOLanguageName == Class16.smethod_0(1648932081)))
					{
						break;
					}
					num = 2;
					goto IL_01b2;
				case 'p':
					if (!(twoLetterISOLanguageName == Class16.smethod_0(1648932116)))
					{
						break;
					}
					num = 3;
					goto IL_01b2;
				case 'r':
					if (!(twoLetterISOLanguageName == Class16.smethod_0(1648932072)))
					{
						break;
					}
					goto IL_0196;
				case 'u':
					if (!(twoLetterISOLanguageName == Class16.smethod_0(1648907710)))
					{
						break;
					}
					goto IL_0196;
				case 'v':
					{
						if (!(twoLetterISOLanguageName == Class16.smethod_0(1648932134)))
						{
							break;
						}
						num = 4;
						goto IL_01b2;
					}
					IL_0196:
					num = 0;
					goto IL_01b2;
					IL_0111:
					num = 5;
					goto IL_01b2;
				}
			}
		}
		num = 1;
		goto IL_01b2;
		IL_01b2:
		int num2 = 2; // Simplified Chinese default; retain explicit saved/user selection.
		LangIndex = DefaultProfile.GetSetting(Class16.smethod_0(1648907720), num2, int.MinValue, int.MaxValue);
		int langIndex = CmdFlags.LangIndex;
		if (langIndex > -1)
		{
			LangIndex = langIndex;
		}
		Texts = new TextStorage(LangIndex);
		TextStorage.TEXTS = Texts;
		LCategory.Texts = Texts;
		LDisplayName.Texts = Texts;
		LDescription.Texts = Texts;
		Params = new ParamsClass();
		string setting = Profile.GetSetting(Class16.smethod_0(1648907743), Class16.smethod_0(1648907764), string.Empty);
		Params.OutEditorsPath.TasksEditor = setting;
		string setting2 = Profile.GetSetting(Class16.smethod_0(1648907743), Class16.smethod_0(1648906758), string.Empty);
		Params.OutEditorsPath.NPCGenEditor = setting2;
		Params.EnableCustomCursors = Profile.GetSetting(Class16.smethod_0(1648906769), Default: true);
		PWCursor1 = global::ACE.RSGlobal.RSGlobal.LoadPWCursor();
		bData = false;
		License = new LICENSE_INFO(bFastCheck: true);
		GC.KeepAlive(this);
	}

	public void ParseCmdLine(string[] args)
	{
		string text = null;
		string text2 = null;
		string text3 = null;
		if (args == null || args.Length == 0)
		{
			return;
		}
		CmdLine = string.Join(string.Empty, args);
		if (File.Exists(CmdLine))
		{
			CmdFlags.FN = CmdLine;
		}
		CmdFlags.bRestarted = GetParam(args, Class16.smethod_0(1648906909));
		CmdFlags.bSecondCopy = GetParam(args, Class16.smethod_0(1648906926));
		CmdFlags.bCrashed = GetParam(args, Class16.smethod_0(1648906940));
		CmdFlags.bInstalled = GetParam(args, Class16.smethod_0(1648906947));
		CmdFlags.bTrial = GetParam(args, Class16.smethod_0(1648906972));
		CmdFlags.Elements = GetParam(args, Class16.smethod_0(1648906977), ref CmdFlags.elementsFN);
		CmdFlags.GShop = GetParam(args, Class16.smethod_0(1648906993), ref CmdFlags.gshopFN);
		CmdFlags.NpcGen = GetParam(args, Class16.smethod_0(1648907014), ref CmdFlags.npcgenFN);
		CmdFlags.Domain2 = GetParam(args, Class16.smethod_0(1648907028), ref CmdFlags.domain2FN);
		CmdFlags.Tasks = GetParam(args, Class16.smethod_0(1648907035), ref CmdFlags.tasksFN);
		CmdFlags.AI = GetParam(args, Class16.smethod_0(1648907048), ref CmdFlags.aipolicyFN);
		CmdFlags.ACEProject = GetParam(args, Class16.smethod_0(1648907064), ref CmdFlags.profileFN);
		CmdFlags.ImportItems = GetParam(args, Class16.smethod_0(1648907087), ref CmdFlags.importFN);
		GetParam(args, Class16.smethod_0(1648907101), ref CmdFlags.ListName);
		text3 = null;
		if (GetParam(args, Class16.smethod_0(1648907105), ref text3) && global::ACE.RSGlobal.RSGlobal.IsUIntFast(text3))
		{
			CmdFlags.ItemIndex = global::ACE.RSGlobal.RSGlobal.UIntParseFast(text3);
			GC.KeepAlive(this);
		}
		text2 = null;
		if (GetParam(args, Class16.smethod_0(1648907122), ref text2) && global::ACE.RSGlobal.RSGlobal.IsUIntFast(text2))
		{
			CmdFlags.ItemId = global::ACE.RSGlobal.RSGlobal.UIntParseFast(text2);
			GC.KeepAlive(this);
		}
		CmdFlags.Api = GetParam(args, Class16.smethod_0(1648907142));
		CmdFlags.Minimized = GetParam(args, Class16.smethod_0(1648907145));
		CmdFlags.Hidden = GetParam(args, Class16.smethod_0(1648907162));
		CmdFlags.ExportToTable = GetParam(args, Class16.smethod_0(1648907176));
		CmdFlags.PCKProtection = GetParam(args, Class16.smethod_0(1648907205), ref CmdFlags.pckFN);
		CmdFlags.ProtectPCK = GetParam(args, Class16.smethod_0(1648907208), ref CmdFlags.pckFN);
		CmdFlags.UnprotectPCK = GetParam(args, Class16.smethod_0(1648907228), ref CmdFlags.pckFN);
		CmdFlags.ProtectCPK = GetParam(args, Class16.smethod_0(1648907232), ref CmdFlags.cpkFN);
		CmdFlags.UnprotectCPK = GetParam(args, Class16.smethod_0(1648907252), ref CmdFlags.cpkFN);
		CmdFlags.EcmEditor = GetParam(args, Class16.smethod_0(1648907256), ref CmdFlags.ecmEditorFN);
		text = null;
		if (GetParam(args, Class16.smethod_0(1648906249), ref text) && global::ACE.RSGlobal.RSGlobal.IsUIntFast(text))
		{
			IntPtr ownerHandle = (IntPtr)global::ACE.RSGlobal.RSGlobal.UIntParseFast(text);
			CmdFlags.OwnerHandle = ownerHandle;
		}
		if (GetParam(args, Class16.smethod_0(1648906270), ref text))
		{
			string text4 = Class16.smethod_0(1648906274);
			if (text.ToLowerInvariant() == text4)
			{
				CmdFlags.LangIndex = 0;
			}
			else
			{
				CmdFlags.LangIndex = 1;
			}
		}
		ref string fN = ref CmdFlags.FN;
		string text5 = fN;
		if (text5 != null)
		{
			string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(text5);
			if (!fN.EndsWith(Class16.smethod_0(1648906288)) && !fN.EndsWith(Class16.smethod_0(1648906288)) && !fN.EndsWith(Class16.smethod_0(1648906288)))
			{
				if (!fN.EndsWith(Class16.smethod_0(1648906306)) && !fN.EndsWith(Class16.smethod_0(1648906325)))
				{
					if (!fN.EndsWith(Class16.smethod_0(1648906328)) && !fN.EndsWith(Class16.smethod_0(1648906328)) && !fN.EndsWith(Class16.smethod_0(1648906344)))
					{
						if (global::ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(fileNameWithoutExtension, Class16.smethod_0(1648906367)))
						{
							CmdFlags.elementsFN = fN;
							CmdFlags.Elements = true;
						}
						else if (global::ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(fileNameWithoutExtension, Class16.smethod_0(1648906382)))
						{
							CmdFlags.gshopFN = fN;
							CmdFlags.GShop = true;
						}
						else if (global::ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(fileNameWithoutExtension, Class16.smethod_0(1648906386)))
						{
							CmdFlags.domain2FN = fN;
							CmdFlags.Domain2 = true;
						}
						else if (global::ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(fileNameWithoutExtension, Class16.smethod_0(1648906400)))
						{
							CmdFlags.npcgenFN = fN;
							CmdFlags.NpcGen = true;
						}
						else if (global::ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(fileNameWithoutExtension, Class16.smethod_0(1648906421)))
						{
							CmdFlags.tasksFN = fN;
							CmdFlags.Tasks = true;
						}
						else if (global::ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(fileNameWithoutExtension, Class16.smethod_0(1648942729)))
						{
							CmdFlags.aipolicyFN = fN;
							CmdFlags.AI = true;
						}
						else if (global::ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(fileNameWithoutExtension, Class16.smethod_0(1648906425)))
						{
							CmdFlags.pathFN = fN;
							CmdFlags.PathData = true;
						}
						else
						{
							CmdFlags.elementsFN = fN;
							CmdFlags.Elements = true;
						}
					}
					else
					{
						CmdFlags.importFN = fN;
					}
				}
				else
				{
					CmdFlags.SkiOrEcmFN = fN;
				}
			}
			else
			{
				CmdFlags.profileFN = fN;
				CmdFlags.ACEProject = true;
			}
		}
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool GetParam(string[] args, string sParam, ref string ref_String)
	{
		bool result = false;
		if (args != null && args.Length != 0 && Array.IndexOf(args, sParam) > -1)
		{
			result = true;
			int num = Array.IndexOf(args, sParam) + 1;
			if (num < (nint)args.LongLength && !args[num].StartsWith(Class16.smethod_0(1648941518)))
			{
				ref_String = args[num];
			}
		}
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool GetParam(string[] args, string sParam, ref int ref_int)
	{
		string ref_String = null;
		if (GetParam(args, sParam, ref ref_String) && global::ACE.RSGlobal.RSGlobal.IsUIntFast(ref_String))
		{
			ref_int = global::ACE.RSGlobal.RSGlobal.UIntParseFast(ref_String);
			GC.KeepAlive(this);
			return true;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool GetParam(string[] args, string sParam)
	{
		byte b = (byte)((args != null && args.Length != 0 && Array.IndexOf(args, sParam) > -1) ? 1 : 0);
		GC.KeepAlive(this);
		return b != 0;
	}

	public void SetLanguage(int LangIndex)
	{
		CommonStorage.LangIndex = LangIndex;
		Texts.SetLanguage(LangIndex);
		GC.KeepAlive(this);
	}

	public void ResetBuffer()
	{
		oData = null;
		sData = null;
		bData = false;
		iarr1 = null;
		iarr2 = null;
		sarr1 = null;
		iData = 0;
	}

	public string CreateBackup(string FileName, string dir)
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		if (File.Exists(FileName) && Params.MaxBackupsCount >= 1)
		{
			string fileBaseName = global::ACE.RSGlobal.RSGlobal.GetFileBaseName(FileName);
			if (string.IsNullOrWhiteSpace(dir))
			{
				dir = System.IO.Path.GetDirectoryName(FileName);
			}
			if (!Directory.Exists(dir))
			{
				Directory.CreateDirectory(dir);
			}
			dir = System.IO.Path.Combine(dir, Class16.smethod_0(1648906444) + fileBaseName);
			if (!Directory.Exists(dir))
			{
				Directory.CreateDirectory(dir);
			}
			string text = DateTime.Now.ToString(Class16.smethod_0(1648906450));
			string text2 = System.IO.Path.Combine(dir, text + Class16.smethod_0(1648923968) + fileBaseName + Class16.smethod_0(1648906484));
			try
			{
				if (File.Exists(text2))
				{
					File.Delete(text2);
				}
				FileStream fileStream = new FileStream(text2, FileMode.Create);
				try
				{
					ZipArchive val = new ZipArchive((Stream)fileStream, (ZipArchiveMode)1);
					try
					{
						ZipArchiveEntry val2 = val.CreateEntry(System.IO.Path.GetFileName(FileName), CompressionLevel.Fastest);
						using Stream destination = val2.Open();
						FileStream fileStream2 = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
						try
						{
							fileStream2.CopyTo(destination);
						}
						finally
						{
							((IDisposable)fileStream2).Dispose();
						}
					}
					finally
					{
						((IDisposable)val).Dispose();
					}
				}
				finally
				{
					((IDisposable)fileStream).Dispose();
				}
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648906495));
				GC.KeepAlive(this);
				return null;
			}
			try
			{
				string[] files = Directory.GetFiles(dir, Class16.smethod_0(1648906520));
				if (files.Length > Params.MaxBackupsCount)
				{
					IEnumerable<string> enumerable = files.OrderByDescending(Class57.class57_0.method_0).Skip(Params.MaxBackupsCount);
					foreach (string item in enumerable)
					{
						File.Delete(item);
					}
				}
			}
			catch
			{
			}
			GC.KeepAlive(this);
			return text2;
		}
		GC.KeepAlive(this);
		return null;
	}

	public string CreateBackup(string FileName)
	{
		string result = CreateBackup(FileName, System.IO.Path.GetDirectoryName(FileName));
		GC.KeepAlive(this);
		return result;
	}

	public static byte[] ValidateBytes(byte[] bytes)
	{
		byte[] input = SecretEncoder.EncryptBytes(bytes, bBase64: false);
		return SecretDecoder.DecryptBytes(input, bBase64: false);
	}

	public static byte[] ValidateValue(int value)
	{
		byte[] input = SecretEncoder.EncryptBytes(BitConverter.GetBytes(value), bBase64: false);
		return SecretDecoder.DecryptBytes(input, bBase64: false);
	}

	public static string NumberToString(int number, int str_index)
	{
		if (number > 0)
		{
			if (((LANG_INFO.CurrentLang == null) ? Class16.smethod_0(1648931959) : LANG_INFO.CurrentLang.Prefix) == Class16.smethod_0(1648932072))
			{
				string text = Convert.ToString(number);
				string s = text.Substring(text.Length - 1);
				int result = 0;
				int.TryParse(s, out result);
				int num = result;
				if (text.Length >= 2)
				{
					string s2 = text.Substring(text.Length - 2);
					int result2 = 0;
					int.TryParse(s2, out result2);
					num = result2;
				}
				if (result != 0 && (num <= 9 || num >= 21) && (result < 5 || result > 9))
				{
					if (result == 1)
					{
						object[] vars = new object[1] { number };
						return TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(str_index, 0), vars);
					}
					object[] vars2 = new object[1] { number };
					return TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(str_index, 1), vars2);
				}
				object[] vars3 = new object[1] { number };
				return TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(str_index, 2), vars3);
			}
			if (number == 1)
			{
				object[] vars4 = new object[1] { 1 };
				return TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(str_index, 0), vars4);
			}
			object[] vars5 = new object[1] { number };
			return TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(str_index, 1), vars5);
		}
		return Class16.smethod_0(1648924112);
	}

	public static string SecondsToString(uint time, [MarshalAs(UnmanagedType.U1)] bool bShowSeconds, [MarshalAs(UnmanagedType.U1)] bool bZeroIsNotForever)
	{
		if (time == 0)
		{
			if (bZeroIsNotForever)
			{
				return Class16.smethod_0(1648924112);
			}
			return TextStorage.TEXTS.GetText(Class16.smethod_0(1648906540));
		}
		uint num = time / 86400;
		time = (uint)((int)num * -86400) + time;
		uint num2 = time / 3600;
		time = (uint)((int)num2 * -3600) + time;
		uint num3 = time / 60;
		uint num4 = time - num3 * 60;
		if (num != 0 || num2 != 0)
		{
			bShowSeconds = false;
		}
		if (num3 < 2)
		{
			if (!bShowSeconds)
			{
				bShowSeconds = true;
			}
		}
		else if (!bShowSeconds && num4 > 30)
		{
			num3++;
		}
		string text = string.Empty;
		if (num != 0)
		{
			text = NumberToString((int)num, 227);
		}
		if (num2 != 0)
		{
			if (text != string.Empty)
			{
				text += Class16.smethod_0(1648942211);
			}
			text += NumberToString((int)num2, 228);
		}
		if (num3 != 0)
		{
			if (text != string.Empty)
			{
				text += Class16.smethod_0(1648942211);
			}
			text += NumberToString((int)num3, 229);
		}
		if (num4 != 0 && bShowSeconds)
		{
			if (text != string.Empty)
			{
				text += Class16.smethod_0(1648942211);
			}
			text += NumberToString((int)num4, 230);
		}
		return text;
	}

	public static string SecondsToString(uint time)
	{
		return SecondsToString(time, bShowSeconds: true, bZeroIsNotForever: false);
	}

	public static string SecondsToString(int time)
	{
		if (time < 0)
		{
			int num = time;
			return num.ToString();
		}
		return SecondsToString((uint)time, bShowSeconds: true, bZeroIsNotForever: true);
	}

	public static string Timestamp2String(uint timestamp, [MarshalAs(UnmanagedType.U1)] bool ShowSeconds)
	{
		DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timestamp).ToLocalTime();
		if (!(Texts.Lang.Prefix == Class16.smethod_0(1648932072)))
		{
			string text = ((!ShowSeconds) ? string.Empty : (Class16.smethod_0(1648924402) + dateTimeOffset.Second));
			return dateTimeOffset.ToString(Class16.smethod_0(1648906555)) + text;
		}
		string text2 = ((!ShowSeconds) ? string.Empty : Class16.smethod_0(1648906563));
		return dateTimeOffset.ToString(Class16.smethod_0(1648906580) + text2);
	}

	public static string Date2String(DateTime date)
	{
		if (Texts.Lang.Prefix == Class16.smethod_0(1648932072))
		{
			return date.ToLocalTime().ToString(Class16.smethod_0(1648906595));
		}
		return date.ToLocalTime().ToString(Class16.smethod_0(1648906620));
	}

	public static uint StringToSeconds(string time)
	{
		try
		{
			time = time.ToLowerInvariant();
			time = time.Replace(Class16.smethod_0(1648942211), string.Empty);
			time = time.Replace(Class16.smethod_0(1648928036), string.Empty);
			time = time.Replace(Class16.smethod_0(1648928028), string.Empty);
			string[] textsByPrefix = TextStorage.TEXTS.GetTextsByPrefix(Class16.smethod_0(1648906628));
			for (int i = 0; i < (nint)textsByPrefix.LongLength; i++)
			{
				string oldValue = textsByPrefix[i];
				time = time.Replace(oldValue, Class16.smethod_0(1648906641));
			}
			string[] textsByPrefix2 = TextStorage.TEXTS.GetTextsByPrefix(Class16.smethod_0(1648906661));
			for (int j = 0; j < (nint)textsByPrefix2.LongLength; j++)
			{
				string oldValue2 = textsByPrefix2[j];
				time = time.Replace(oldValue2, Class16.smethod_0(1648906674));
			}
			string[] textsByPrefix3 = TextStorage.TEXTS.GetTextsByPrefix(Class16.smethod_0(1648906692));
			for (int k = 0; k < (nint)textsByPrefix3.LongLength; k++)
			{
				string oldValue3 = textsByPrefix3[k];
				time = time.Replace(oldValue3, Class16.smethod_0(1648906705));
			}
			string[] textsByPrefix4 = TextStorage.TEXTS.GetTextsByPrefix(Class16.smethod_0(1648906724));
			for (int l = 0; l < (nint)textsByPrefix4.LongLength; l++)
			{
				string oldValue4 = textsByPrefix4[l];
				time = time.Replace(oldValue4, Class16.smethod_0(1648906737));
			}
			string[] textsByPrefix5 = TextStorage.TEXTS.GetTextsByPrefix(Class16.smethod_0(1648906747));
			for (int m = 0; m < (nint)textsByPrefix5.LongLength; m++)
			{
				string oldValue5 = textsByPrefix5[m];
				time = time.Replace(oldValue5, Class16.smethod_0(1648909840));
			}
			string text = null;
			string text2 = null;
			string text3 = null;
			string text4 = null;
			string text5 = null;
			text = global::ACE.RSGlobal.RSGlobal.RegEx_FilterValue(time, Class16.smethod_0(1648909850));
			text2 = global::ACE.RSGlobal.RSGlobal.RegEx_FilterValue(time, Class16.smethod_0(1648909867));
			text3 = global::ACE.RSGlobal.RSGlobal.RegEx_FilterValue(time, Class16.smethod_0(1648909882));
			text4 = global::ACE.RSGlobal.RSGlobal.RegEx_FilterValue(time, Class16.smethod_0(1648909898));
			text5 = global::ACE.RSGlobal.RSGlobal.RegEx_FilterValue(time, Class16.smethod_0(1648909913));
			if (text == string.Empty)
			{
				text = Class16.smethod_0(1648924112);
			}
			if (text2 == string.Empty)
			{
				text2 = Class16.smethod_0(1648924112);
			}
			if (text3 == string.Empty)
			{
				text3 = Class16.smethod_0(1648924112);
			}
			if (text4 == string.Empty)
			{
				text4 = Class16.smethod_0(1648924112);
			}
			if (text5 == string.Empty)
			{
				text5 = Class16.smethod_0(1648924112);
			}
			uint num = Convert.ToUInt32(text) * 30;
			uint num2 = (Convert.ToUInt32(text2) + num) * 24;
			uint num3 = (Convert.ToUInt32(text3) + num2) * 60;
			uint num4 = (Convert.ToUInt32(text4) + num3) * 60;
			return Convert.ToUInt32(text5) + num4;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648909928));
		}
		return 0u;
	}

	public static string GetPieces(int val)
	{
		object[] array = new object[1];
		int num = val;
		array[0] = num.ToString(Class16.smethod_0(1648909972));
		int index = ((val > 1) ? 1 : 0);
		return TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(713, index), array);
	}

	public static string PWColor2String(int color)
	{
		if (Texts.LangIndex == 0)
		{
			switch (color)
			{
			case 0:
				return Class16.smethod_0(1648909981);
			case 1:
				return Class16.smethod_0(1648909987);
			case 2:
				return Class16.smethod_0(1648910006);
			case 3:
				return Class16.smethod_0(1648910009);
			case 4:
				return Class16.smethod_0(1648910030);
			case 5:
				return Class16.smethod_0(1648910035);
			case 6:
				return Class16.smethod_0(1648910055);
			case 7:
				return Class16.smethod_0(1648910058);
			case 8:
				return Class16.smethod_0(1648910078);
			case 9:
				return Class16.smethod_0(1648910080);
			case 10:
				return Class16.smethod_0(1648910100);
			}
		}
		else
		{
			switch (color)
			{
			case 0:
				return Class16.smethod_0(1648909981);
			case 1:
				return Class16.smethod_0(1648909987);
			case 2:
				return Class16.smethod_0(1648910006);
			case 3:
				return Class16.smethod_0(1648910009);
			case 4:
				return Class16.smethod_0(1648910030);
			case 5:
				return Class16.smethod_0(1648910035);
			case 6:
				return Class16.smethod_0(1648910055);
			case 7:
				return Class16.smethod_0(1648910058);
			case 8:
				return Class16.smethod_0(1648910078);
			case 9:
				return Class16.smethod_0(1648910080);
			case 10:
				return Class16.smethod_0(1648910100);
			}
		}
		int num = color;
		return num.ToString();
	}

	public void GoToTask(int TaskID, ReferenceSubType ref_type)
	{
		MainEditor mainEditor = null;
		foreach (Form openForm in Application.OpenForms)
		{
			if (openForm is MainEditor mainEditor2)
			{
				mainEditor = mainEditor2;
				break;
			}
		}
		if (mainEditor != null)
		{
			if (!mainEditor.Visible)
			{
				mainEditor.Show();
			}
			mainEditor.WindowState = FormWindowState.Normal;
			mainEditor.BringToFront();
			mainEditor.Activate();
			method_0(mainEditor, TaskID);
		}
		else
		{
			ShowTasksEditor(TaskID);
		}
	}

	public void ShowTasksEditor(int TaskID)
	{
		try
		{
			foreach (Form openForm in Application.OpenForms)
			{
				if (openForm is MainEditor mainEditor)
				{
					mainEditor.WindowState = FormWindowState.Normal;
					mainEditor.BringToFront();
					mainEditor.Activate();
					if (TaskID > 0)
					{
						method_0(mainEditor, TaskID);
					}
					return;
				}
			}
			string tasksPath = Params.TasksPath;
			if (!string.IsNullOrEmpty(tasksPath) && File.Exists(tasksPath))
			{
				global::ACE.MainWindow.MainWindow mainWindowForm = MainWindowForm;
				if (mainWindowForm == null)
				{
					throw new InvalidOperationException(Class16.smethod_0(1648910106));
				}
				MainEditor mainEditor_ = mainWindowForm.OpenTasksEditor(tasksPath, 0, TaskID);
				if (TaskID > 0)
				{
					method_0(mainEditor_, TaskID);
				}
			}
			else
			{
				object[] vars = new object[1] { tasksPath ?? Class16.smethod_0(1648910178) };
				TextStorage.TEXTS.ShowMessage(410, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648910195));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648910239), Class16.smethod_0(1648910267)), ex.Message), Class16.smethod_0(1648910318), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		GC.KeepAlive(this);
	}

	private void method_0(MainEditor mainEditor_0, int int_0)
	{
		Class56 @class = new Class56();
		@class.mainEditor_0 = mainEditor_0;
		@class.commonStorage_0 = this;
		@class.int_0 = int_0;
		try
		{
			if (@class.int_0 <= 0 || @class.mainEditor_0 == null || @class.mainEditor_0.IsDisposed || @class.mainEditor_0.Disposing)
			{
				return;
			}
			@class.multiSelectTreeView_0 = @class.mainEditor_0.treeView_tasks;
			if (@class.multiSelectTreeView_0 != null && !@class.multiSelectTreeView_0.IsDisposed && !@class.multiSelectTreeView_0.Disposing)
			{
				if (!@class.multiSelectTreeView_0.InvokeRequired && @class.multiSelectTreeView_0.IsHandleCreated)
				{
					@class.method_0();
				}
				else
				{
					@class.multiSelectTreeView_0.BeginInvokeSafe(@class.method_0);
				}
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648910321));
		}
	}

	private void method_1(TreeView treeView_0, int int_0)
	{
		foreach (TreeNode node in treeView_0.Nodes)
		{
			if (method_2(node, int_0))
			{
				break;
			}
		}
	}

	private bool method_2(TreeNode treeNode_0, int int_0)
	{
		if (treeNode_0 == null)
		{
			return false;
		}
		if (treeNode_0.Tag is ATaskTempl aTaskTempl && aTaskTempl.ID == int_0)
		{
			TreeView treeView = treeNode_0.TreeView;
			if (treeView != null && !treeView.IsDisposed && !treeView.Disposing)
			{
				if (treeView.SelectedNode == treeNode_0)
				{
					treeView.SelectedNode = null;
				}
				treeView.SelectedNode = treeNode_0;
				treeNode_0.EnsureVisible();
				treeView.Focus();
				return true;
			}
			return false;
		}
		foreach (TreeNode node in treeNode_0.Nodes)
		{
			if (method_2(node, int_0))
			{
				return true;
			}
		}
		return false;
	}

	public int GetGamePricePW(int shop_price)
	{
		if (AParams.DisableShopPriceTaxCalculation)
		{
			GC.KeepAlive(this);
			return shop_price;
		}
		double num = shop_price;
		double num2 = num * 0.05;
		num2 = ((shop_price < 10) ? Math.Round(num2) : Math.Round(num2, MidpointRounding.AwayFromZero));
		double num3 = num + num2;
		if (num3 >= 100.0 && num3 < 1000.0)
		{
			num3 = Math.Ceiling(num3 * 0.1) * 10.0;
		}
		if (num3 >= 1000.0)
		{
			num3 = Math.Ceiling(num3 * 0.01) * 100.0;
		}
		int result;
		if (!(num3 < -2147483648.0) && !(num3 > 2147483647.0))
		{
			int num4 = Convert.ToInt32(num3);
			result = num4;
			if (num4 >= 0 && num4 != int.MaxValue)
			{
				goto IL_00c7;
			}
		}
		result = 0;
		goto IL_00c7;
		IL_00c7:
		GC.KeepAlive(this);
		return result;
	}

	public int GetElementPricePW(int price)
	{
		if (AParams.DisableShopPriceTaxCalculation)
		{
			GC.KeepAlive(this);
			return price;
		}
		int result = (int)Math.Floor((double)price * (20.0 / 21.0));
		GC.KeepAlive(this);
		return result;
	}

	public static GlobalData.TASKELEMENTS_TYPE GetTaskElementType(ReferenceSubType RefSubType)
	{
		string name = Enum.GetName(typeof(ReferenceSubType), RefSubType);
		GlobalData.TASKELEMENTS_TYPE result = GlobalData.TASKELEMENTS_TYPE.TASKS_DELV_NPC;
		Enum.TryParse<GlobalData.TASKELEMENTS_TYPE>(name, ignoreCase: true, out result);
		return result;
	}

	private static double smethod_0()
	{
		IntPtr dC = global::ACE.RSGlobal.RSGlobal.GetDC(IntPtr.Zero);
		int deviceCaps = global::ACE.RSGlobal.RSGlobal.GetDeviceCaps(dC, 8);
		int deviceCaps2 = global::ACE.RSGlobal.RSGlobal.GetDeviceCaps(dC, 118);
		global::ACE.RSGlobal.RSGlobal.ReleaseDC(IntPtr.Zero, dC);
		return (double)deviceCaps2 / (double)deviceCaps;
	}

	public static double GetWindowsScaling(IntPtr windowHandle)
	{
		IntPtr hMonitor = global::ACE.RSGlobal.RSGlobal.MonitorFromWindow(windowHandle, 1u);
		MONITORINFO lpmi = new MONITORINFO
		{
			cbSize = 40u
		};
		if (global::ACE.RSGlobal.RSGlobal.GetMonitorInfoW(hMonitor, ref lpmi))
		{
			DEVMODE lpDevMode = default(DEVMODE);
			if (global::ACE.RSGlobal.RSGlobal.EnumDisplaySettingsW(null, uint.MaxValue, ref lpDevMode))
			{
				return (double)lpDevMode.dmPelsWidth / (double)(lpmi.rcMonitor.right - lpmi.rcMonitor.left);
			}
		}
		return smethod_0();
	}

	public static void GetWindowDisplayLogicalResolution(IntPtr windowHandle, ref int width, ref int height)
	{
		IntPtr hMonitor = global::ACE.RSGlobal.RSGlobal.MonitorFromWindow(windowHandle, 2u);
		MONITORINFO lpmi = new MONITORINFO
		{
			cbSize = 40u
		};
		if (global::ACE.RSGlobal.RSGlobal.GetMonitorInfoW(hMonitor, ref lpmi))
		{
			width = lpmi.rcMonitor.right - lpmi.rcMonitor.left;
			height = lpmi.rcMonitor.bottom - lpmi.rcMonitor.top;
		}
	}

	public static void GetWindowDisplayPhysicalResolution(IntPtr windowHandle, ref int width, ref int height)
	{
		IntPtr hMonitor = global::ACE.RSGlobal.RSGlobal.MonitorFromWindow(windowHandle, 2u);
		MONITORINFO lpmi = new MONITORINFO
		{
			cbSize = 40u
		};
		if (global::ACE.RSGlobal.RSGlobal.GetMonitorInfoW(hMonitor, ref lpmi))
		{
			DEVMODE lpDevMode = default(DEVMODE);
			if (global::ACE.RSGlobal.RSGlobal.EnumDisplaySettingsW(null, uint.MaxValue, ref lpDevMode))
			{
				width = lpDevMode.dmPelsWidth;
				height = lpDevMode.dmPelsHeight;
			}
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool IsScreenScaled(IntPtr windowHandle)
	{
		return GetWindowsScaling(windowHandle) != 1.0;
	}

	public static string OpenDirectory(IntPtr windowHandle, string Title, string DefaultPath)
	{
		string text = null;
		if (folderBrowserDialog == null)
		{
			folderBrowserDialog = new FolderBrowserDialog();
		}
		folderBrowserDialog.Description = Title;
		if (!string.IsNullOrEmpty(DefaultPath))
		{
			folderBrowserDialog.SelectedPath = DefaultPath;
		}
		if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
		{
			text = folderBrowserDialog.SelectedPath;
			AParams.DialogInitialDirectory = text;
		}
		return text;
	}

	public static string OpenDirectory(IntPtr windowHandle, int title_id, string DefaultPath)
	{
		string text = TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(title_id, 0), null);
		return OpenDirectory(windowHandle, text, DefaultPath);
	}

	public static string OpenDirectory(IntPtr windowHandle, int title_id)
	{
		string text = TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(title_id, 0), null);
		return OpenDirectory(windowHandle, text, null);
	}

	public List<string> GeneratePcks(string path)
	{
		if (!string.IsNullOrWhiteSpace(path) && Directory.Exists(path))
		{
			if (Directory.Exists(path + Class16.smethod_0(1648909336)))
			{
				path += Class16.smethod_0(1648909359);
			}
			if (Directory.Exists(path + Class16.smethod_0(1648909375)))
			{
				path += Class16.smethod_0(1648909375);
			}
			else if (Directory.Exists(path + Class16.smethod_0(1648909384)))
			{
				path += Class16.smethod_0(1648909384);
			}
			string[] files = Directory.GetFiles(path, Class16.smethod_0(1648909407));
			List<string> list = new List<string>(files.Length);
			int num = 0;
			if (0 < (nint)files.LongLength)
			{
				do
				{
					string text = files[num];
					if (text.EndsWith(Class16.smethod_0(1648909411)))
					{
						list.Add(text);
					}
					num++;
				}
				while (num < (nint)files.LongLength);
			}
			GC.KeepAlive(this);
			return list;
		}
		return null;
	}

	public List<string> GenerateNpcgens(string path)
	{
		if (string.IsNullOrWhiteSpace(path))
		{
			GC.KeepAlive(this);
			return new List<string>();
		}
		if (path.EndsWith(Class16.smethod_0(1648909430)) && File.Exists(path))
		{
			string[] collection = new string[1] { path };
			GC.KeepAlive(this);
			return new List<string>(collection);
		}
		if (path.EndsWith(Class16.smethod_0(1648927580)))
		{
			path = path.Substring(0, path.Length - 1);
		}
		if (!path.EndsWith(Class16.smethod_0(1648909434)) && File.Exists(path + Class16.smethod_0(1648909448)))
		{
			path += Class16.smethod_0(1648909434);
		}
		string[] directories = Directory.GetDirectories(path);
		List<string> list = new List<string>(directories.Length);
		int num = 0;
		if (0 < (nint)directories.LongLength)
		{
			do
			{
				string text = directories[num] + Class16.smethod_0(1648909480);
				if (File.Exists(text))
				{
					list.Add(text);
				}
				num++;
			}
			while (num < (nint)directories.LongLength);
		}
		GC.KeepAlive(this);
		return list;
	}

	public List<string> GeneratePrecincts(string ClientPath)
	{
		if (ClientPath.EndsWith(Class16.smethod_0(1648927580)))
		{
			ClientPath = ClientPath.Substring(0, ClientPath.Length - 1);
		}
		if (!ClientPath.EndsWith(Class16.smethod_0(1648909499)) && Directory.Exists(ClientPath + Class16.smethod_0(1648909336)) && Directory.Exists(ClientPath + Class16.smethod_0(1648909513)))
		{
			ClientPath += Class16.smethod_0(1648909336);
		}
		if (!ClientPath.EndsWith(Class16.smethod_0(1648909541)) && File.Exists(ClientPath + Class16.smethod_0(1648909545)))
		{
			ClientPath += Class16.smethod_0(1648909541);
		}
		string[] directories = Directory.GetDirectories(ClientPath);
		List<string> list = new List<string>(directories.Length);
		int num = 0;
		if (0 < (nint)directories.LongLength)
		{
			do
			{
				string text = directories[num] + Class16.smethod_0(1648909576);
				if (File.Exists(text))
				{
					list.Add(text);
				}
				num++;
			}
			while (num < (nint)directories.LongLength);
		}
		GC.KeepAlive(this);
		return list;
	}

	public void SetDefaultPaths(ref ParamsClass Params, ref ADDITIONAL_PARAMS AParams, string ClientPath, [MarshalAs(UnmanagedType.U1)] bool bSetPcksAndPrecincts)
	{
		if (!string.IsNullOrWhiteSpace(ClientPath))
		{
			if (ClientPath.EndsWith(Class16.smethod_0(1648927580)))
			{
				ClientPath = ClientPath.Substring(0, ClientPath.Length - 1);
			}
			if (!ClientPath.EndsWith(Class16.smethod_0(1648909604)) && Directory.Exists(ClientPath + Class16.smethod_0(1648909611)))
			{
				ClientPath += Class16.smethod_0(1648909611);
			}
			if (!ClientPath.EndsWith(Class16.smethod_0(1648909499)) && Directory.Exists(ClientPath + Class16.smethod_0(1648909336)) && Directory.Exists(ClientPath + Class16.smethod_0(1648909513)))
			{
				ClientPath += Class16.smethod_0(1648909336);
			}
			if (ClientPath.EndsWith(Class16.smethod_0(1648909627)) && File.Exists(ClientPath + Class16.smethod_0(1648909647)))
			{
				ClientPath = ClientPath.Substring(0, ClientPath.Length - 5);
			}
			Params.ClientPath = ClientPath;
			if (!ClientPath.EndsWith(Class16.smethod_0(1648927580)))
			{
				ClientPath += Class16.smethod_0(1648927580);
			}
			string text = ClientPath + Class16.smethod_0(1648909668);
			Params.ElementsPath = text + Class16.smethod_0(1648909672);
			Params.GShopPath = text + Class16.smethod_0(1648909700);
			Params.GShop1Path = text + Class16.smethod_0(1648909717);
			Params.GShop2Path = text + Class16.smethod_0(1648909735);
			Params.GShop3Path = text + Class16.smethod_0(1648909745);
			Params.GShopSevPath = text + Class16.smethod_0(1648909763);
			Params.GShopSev1Path = text + Class16.smethod_0(1648909791);
			Params.GShopSev2Path = text + Class16.smethod_0(1648909812);
			Params.GShopSev3Path = text + Class16.smethod_0(1648908801);
			Params.AIPolicyPath = text + Class16.smethod_0(1648908830);
			Params.NPCGenPath = text + Class16.smethod_0(1648908842);
			Params.DomainSevPath = text + Class16.smethod_0(1648908868);
			Params.Domain2SevPath = text + Class16.smethod_0(1648908885);
			Params.ExtraDropSevPath = text + Class16.smethod_0(1648908903);
			Params.TasksPath = text + Class16.smethod_0(1648910178);
			Params.PathDataPath = text + Class16.smethod_0(1648908925);
			if (Directory.Exists(ClientPath + Class16.smethod_0(1648908941)))
			{
				ClientPath += Class16.smethod_0(1648908957);
			}
			else if (Directory.Exists(ClientPath + Class16.smethod_0(1648908974)))
			{
				ClientPath += Class16.smethod_0(1648908988);
			}
			Params.ConfigsPckPath = ClientPath + Class16.smethod_0(1648908995);
			Params.SurfacesPckPath = ClientPath + Class16.smethod_0(1648909021);
			Params.ModelsPckPath = ClientPath + Class16.smethod_0(1648909032);
			AParams.WorldTargetsPath = ClientPath + Class16.smethod_0(1648909049);
			if (bSetPcksAndPrecincts)
			{
				Params.UsePck = true;
				List<string> list = GeneratePcks(ClientPath);
				if (list != null)
				{
					Params.PckFiles = list.ToArray();
				}
				List<string> list2 = GeneratePrecincts(ClientPath);
				if (list2 != null)
				{
					AParams.PreinctPaths = list2.ToArray();
				}
			}
		}
		GC.KeepAlive(this);
	}

	public void OpenApi(string args)
	{
		string text = Application.StartupPath + Class16.smethod_0(1648909093);
		if (File.Exists(Application.StartupPath + Class16.smethod_0(1648909112)))
		{
			text = Application.StartupPath + Class16.smethod_0(1648909145);
		}
		if (File.Exists(text))
		{
			global::ACE.RSGlobal.RSGlobal.ShellP(text, args, waitForExit: false);
		}
		else
		{
			object[] vars = new object[1] { text };
			TextStorage.TEXTS.ShowMessage(251, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
		}
		GC.KeepAlive(this);
	}

	public void Alert(int str_id, params object[] vars)
	{
		global::ACE.MainWindow.MainWindow.ShowBackgroundMessageOutside(Texts.GetText(Texts.ResolveLegacyMessageKey(str_id, 0), vars), IsAlert: true, 5000);
		GC.KeepAlive(this);
	}

	public static double GetMemoryUsageMb()
	{
		return (double)Process.GetCurrentProcess().WorkingSet64 * 0.0009765625 * 0.0009765625;
	}

	private static void smethod_1(ref int int_0, ref int int_1)
	{
		IntPtr dC = global::ACE.RSGlobal.RSGlobal.GetDC(IntPtr.Zero);
		int_0 = global::ACE.RSGlobal.RSGlobal.GetDeviceCaps(dC, 8);
		int_1 = global::ACE.RSGlobal.RSGlobal.GetDeviceCaps(dC, 10);
		global::ACE.RSGlobal.RSGlobal.ReleaseDC(IntPtr.Zero, dC);
	}

	private static void smethod_2(ref int int_0, ref int int_1)
	{
		IntPtr dC = global::ACE.RSGlobal.RSGlobal.GetDC(IntPtr.Zero);
		int_0 = global::ACE.RSGlobal.RSGlobal.GetDeviceCaps(dC, 118);
		int_1 = global::ACE.RSGlobal.RSGlobal.GetDeviceCaps(dC, 117);
		global::ACE.RSGlobal.RSGlobal.ReleaseDC(IntPtr.Zero, dC);
	}
}
