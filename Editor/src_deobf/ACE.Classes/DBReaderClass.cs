using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ACE.Classes.Localization;
using ACE.RSGlobal;
using Sentry;

namespace ACE.Classes;

public class DBReaderClass
{
	private static readonly HashSet<string> hashSet_0 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

	public CommonStorage CStorage;

	public GAMES Game;

	public string LangPrefix;

	public string GamePrefix;

	public ushort file_version;

	public bool bChina;

	public DBReaderClass(CommonStorage CStorage, string LangPrefix, GAMES Game, string GamePrefix, ushort file_version)
	{
		this.CStorage = CStorage;
		this.LangPrefix = LangPrefix;
		this.Game = Game;
		this.GamePrefix = GamePrefix;
		this.file_version = file_version;
	}

	public string[] Read(string BaseName, [MarshalAs(UnmanagedType.U1)] bool bVersion2, ref string fn)
	{
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		if (BaseName == string.Empty)
		{
			GC.KeepAlive(this);
			return null;
		}
		ushort num = file_version;
		string text = ((!bVersion2) ? string.Empty : Class16.smethod_0(1648934967));
		string[] lookupTokens = DatabaseLocaleResolver.GetLookupTokens(LangPrefix);
		List<string> list = new List<string>(8);
		string text2 = null;
		string text3 = null;
		while ((uint)num >= 6u)
		{
			list.Add(num.ToString(CultureInfo.InvariantCulture));
			foreach (string path in lookupTokens)
			{
				string fmt = Class16.smethod_0(1648909222);
				string text4 = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648909207), path, string.Format(fmt, GamePrefix, BaseName, num, text));
				text3 = text4;
				if (File.Exists(text4))
				{
					text2 = text4;
					break;
				}
				// TODO(recovered): the recompiled format string resolves to ".acedb", but the licensed
				// editor (DBReaderClass: "...\\" + ... + ".udedb") and the shipped deployment use the
				// legacy ".udedb" extension (PW_addons63.udedb / PW_refine63.udedb / PW_abilities63.udedb).
				// Without this fallback the addon/refine/abilities DBs never load, so Equipment Addon
				// fields show raw config values (e.g. "A_A11") with no enum name and no reference.
				string altFmt = fmt.Replace(".acedb", ".udedb");
				if (altFmt != fmt)
				{
					string text4b = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648909207), path, string.Format(altFmt, GamePrefix, BaseName, num, text));
					text3 = text4b;
					if (File.Exists(text4b))
					{
						text2 = text4b;
						break;
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(text2))
			{
				break;
			}
			num += 65535;
			num = (ushort)((num != 52) ? num : 33);
		}
		fn = text2 ?? text3;
		if (!File.Exists(fn))
		{
			string item = BaseName + Class16.smethod_0(1648923968) + GamePrefix + Class16.smethod_0(1648923968) + LangPrefix;
			if (hashSet_0.Add(item))
			{
				string text5 = string.Join(Class16.smethod_0(1648928028), lookupTokens);
				string text6 = string.Join(Class16.smethod_0(1648928028), list);
				string message = string.Format(Class16.smethod_0(1648909240), BaseName, GamePrefix, LangPrefix, text5, text6, bVersion2);
				SentryLevel level = (SentryLevel)(smethod_0(BaseName) ? 1 : 2);
				SentryHelper.CaptureMessage(message, level, Class16.smethod_0(1648908340));
			}
			GC.KeepAlive(this);
			return null;
		}
		string[] result;
		if (bVersion2)
		{
			result = File.ReadAllLines(fn, Encoding.Unicode);
		}
		else
		{
			string input = File.ReadAllText(fn, Encoding.UTF8);
			input = RSCommon.RemoveComments(input);
			if (input.Contains(Class16.smethod_0(1648908367)))
			{
				do
				{
					input = input.Replace(Class16.smethod_0(1648908367), Class16.smethod_0(1648941987));
				}
				while (input.Contains(Class16.smethod_0(1648908367)));
			}
			if (input.StartsWith(Class16.smethod_0(1648941987)))
			{
				input = input.Substring(1);
			}
			result = input.Split('\n');
		}
		GC.KeepAlive(this);
		return result;
	}

	private static bool smethod_0(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return false;
		}
		if (!string.Equals(string_0, Class16.smethod_0(1648908368), StringComparison.OrdinalIgnoreCase) && !string.Equals(string_0, Class16.smethod_0(1648922824), StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(string_0, Class16.smethod_0(1648922785), StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	public string[] Read(string BaseName)
	{
		string fn = null;
		return Read(BaseName, bVersion2: false, ref fn);
	}
}
