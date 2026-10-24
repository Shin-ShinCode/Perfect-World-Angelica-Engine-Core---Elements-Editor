using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ACE.RSGlobal;
using Sentry;

namespace ACE.Classes;

public class SettingsClass
{
	private sealed class Class87 : IDisposable
	{
		private SettingsClass settingsClass_0;

		public Class87(SettingsClass settingsClass_1)
		{
			settingsClass_0 = settingsClass_1;
		}

		public void Dispose()
		{
			Interlocked.Exchange(ref settingsClass_0, null)?.method_3();
		}
	}

	private XmlDocument xmlDocument_0;

	public static string ProfilesDirectory;

	public static string DefaultFileName;

	public static string LegacyDefaultFileName;

	public static string LegacyRoamingProfilesDirectory;

	public static string LegacyRoamingDefaultFileName;

	public string FileName;

	public string DefaultSection;

	public string EncryptedSection;

	public static byte[] EncryptionConstant;

	public static RSCrypt Crypter;

	public bool IsNewProfile;

	private readonly object object_0 = new object();

	private int int_0;

	private bool bool_0;

	private static readonly object object_1;

	private static readonly HashSet<string> hashSet_0;

	private static readonly HashSet<string> hashSet_1;

	public SettingsClass(string ProfilePath)
	{
		IsNewProfile = false;
		FileName = smethod_4(ProfilePath);
		DefaultSection = Class16.smethod_0(1648898876);
		EncryptedSection = Class16.smethod_0(1648898887);
		xmlDocument_0 = new XmlDocument();
		if (File.Exists(FileName))
		{
			try
			{
				FileStream fileStream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
				try
				{
					xmlDocument_0.Load(fileStream);
				}
				finally
				{
					((IDisposable)fileStream).Dispose();
				}
			}
			catch (XmlException ex)
			{
				xmlDocument_0 = new XmlDocument();
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648898903));
			}
			catch (UnauthorizedAccessException ex2)
			{
				xmlDocument_0 = new XmlDocument();
				SentryHelper.CaptureMessage(Class16.smethod_0(1648898941) + ex2.Message, (SentryLevel)2, Class16.smethod_0(1648898978));
			}
			catch (IOException ex3)
			{
				xmlDocument_0 = new XmlDocument();
				SentryHelper.CaptureMessage(Class16.smethod_0(1648899025) + ex3.Message, (SentryLevel)2, Class16.smethod_0(1648898061));
			}
			catch (Exception ex4)
			{
				SentryHelper.CaptureException(ex4, Class16.smethod_0(1648898090));
			}
		}
		GC.KeepAlive(this);
	}

	static SettingsClass()
	{
		object_1 = new object();
		hashSet_0 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		hashSet_1 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		string text = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		if (string.IsNullOrWhiteSpace(text))
		{
			text = Application.StartupPath;
		}
		ProfilesDirectory = System.IO.Path.Combine(text, Class16.smethod_0(1648898132), Class16.smethod_0(1648898157));
		DefaultFileName = System.IO.Path.Combine(ProfilesDirectory, Class16.smethod_0(1648898172));
		LegacyDefaultFileName = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648898172));
		LegacyRoamingProfilesDirectory = (string.IsNullOrWhiteSpace(folderPath) ? null : System.IO.Path.Combine(folderPath, Class16.smethod_0(1648898197), Class16.smethod_0(1648898209)));
		LegacyRoamingDefaultFileName = (string.IsNullOrWhiteSpace(LegacyRoamingProfilesDirectory) ? null : System.IO.Path.Combine(LegacyRoamingProfilesDirectory, Class16.smethod_0(1648898172)));
	}

	public static void SetEncryptionConstant(byte[] key)
	{
		EncryptionConstant = key;
		Crypter = new RSCrypt(key);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsDefaultProfile()
	{
		bool result = IsDefaultProfilePath(FileName);
		GC.KeepAlive(this);
		return result;
	}

	public string GetSetting(string Section, string SettingName, string Default)
	{
		lock (object_0)
		{
			XmlElement xmlElement = smethod_0(xmlDocument_0.DocumentElement, Section);
			if (xmlElement == null)
			{
				GC.KeepAlive(this);
				return Default;
			}
			XmlElement xmlElement2 = smethod_0(xmlElement, SettingName);
			if (xmlElement2 == null)
			{
				GC.KeepAlive(this);
				return Default;
			}
			string innerText = xmlElement2.InnerText;
			GC.KeepAlive(this);
			return innerText;
		}
	}

	public string GetSetting(string Section, string SettingName)
	{
		return GetSetting(Section, SettingName, string.Empty);
	}

	public int GetSetting(string Section, string SettingName, int Default, int min, int max)
	{
		string setting = GetSetting(Section, SettingName);
		int result = 0;
		if (!int.TryParse(setting, out result))
		{
			GC.KeepAlive(this);
			return Default;
		}
		if (result < min)
		{
			return min;
		}
		if (result <= max)
		{
			return result;
		}
		return max;
	}

	public int GetSetting(string Section, string SettingName, int Default)
	{
		string setting = GetSetting(Section, SettingName);
		int result = 0;
		if (!int.TryParse(setting, out result))
		{
			GC.KeepAlive(this);
			return Default;
		}
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool GetSetting(string Section, string SettingName, [MarshalAs(UnmanagedType.U1)] bool Default)
	{
		string setting = GetSetting(Section, SettingName);
		if (setting.Length > 0)
		{
			bool result = Convert.ToBoolean(setting);
			GC.KeepAlive(this);
			return result;
		}
		GC.KeepAlive(this);
		return Default;
	}

	public string GetSetting(string SettingName)
	{
		string defaultSection = DefaultSection;
		return GetSetting(defaultSection, SettingName, string.Empty);
	}

	public Point GetSetting(string SettingName, Point Default)
	{
		string setting = GetSetting(SettingName + Class16.smethod_0(1648898244));
		string setting2 = GetSetting(SettingName + Class16.smethod_0(1648898253));
		int result = Default.X;
		int result2 = Default.Y;
		if (int.TryParse(setting, out result) && int.TryParse(setting2, out result2) && result > 0 && result2 > 0)
		{
			Rectangle virtualScreen = SystemInformation.VirtualScreen;
			if (result < virtualScreen.Width)
			{
				Rectangle virtualScreen2 = SystemInformation.VirtualScreen;
				if (result2 < virtualScreen2.Height)
				{
					Point result3 = new Point(result, result2);
					GC.KeepAlive(this);
					return result3;
				}
			}
		}
		GC.KeepAlive(this);
		return Default;
	}

	public int GetSetting(string SettingName, int Default, int min, int max)
	{
		string setting = GetSetting(SettingName);
		int result = 0;
		if (!int.TryParse(setting, out result))
		{
			GC.KeepAlive(this);
			return Default;
		}
		if (result < min)
		{
			return min;
		}
		if (result <= max)
		{
			return result;
		}
		return max;
	}

	public int GetSetting(string SettingName, int Default)
	{
		string setting = GetSetting(SettingName);
		int result = 0;
		if (!int.TryParse(setting, out result))
		{
			GC.KeepAlive(this);
			return Default;
		}
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool GetSetting(string SettingName, [MarshalAs(UnmanagedType.U1)] bool Default)
	{
		string setting = GetSetting(SettingName);
		if (setting.Length > 0)
		{
			bool result = Convert.ToBoolean(setting);
			GC.KeepAlive(this);
			return result;
		}
		GC.KeepAlive(this);
		return Default;
	}

	public string[] GetSetting(string SettingName, string[] Default)
	{
		string setting = GetSetting(SettingName);
		if (setting.Length > 0)
		{
			string[] result = setting.Split(';');
			GC.KeepAlive(this);
			return result;
		}
		GC.KeepAlive(this);
		return Default;
	}

	public string GetEncryptedSetting(string SettingName, string Default)
	{
		string setting = GetSetting(EncryptedSection, SettingName, null);
		if (!string.IsNullOrWhiteSpace(setting))
		{
			string result = Crypter.DecryptString(Convert.FromBase64String(setting));
			GC.KeepAlive(this);
			return result;
		}
		GC.KeepAlive(this);
		return Default;
	}

	public void SaveEncryptedSetting(string SettingName, string Value)
	{
		if (!string.IsNullOrWhiteSpace(Value))
		{
			string value = Convert.ToBase64String(Crypter.EncryptString(Value, bBase64: true));
			SaveSetting(EncryptedSection, SettingName, value);
		}
		else
		{
			SaveSetting(EncryptedSection, SettingName, string.Empty);
		}
	}

	public IDisposable BeginBatchUpdate()
	{
		lock (object_0)
		{
			int_0++;
		}
		return new Class87(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool FlushPendingChanges()
	{
		return SaveXml(0);
	}

	public void SaveSetting(string Section, string SettingName, object Value)
	{
		if (Value == null)
		{
			return;
		}
		string string_ = Value.ToString();
		bool flag;
		lock (object_0)
		{
			XmlElement xmlElement_ = method_4(Section);
			if (!smethod_1(xmlElement_, SettingName, string_))
			{
				GC.KeepAlive(this);
				return;
			}
			bool_0 = true;
			flag = int_0 == 0;
		}
		if (flag)
		{
			SaveXml(0);
		}
	}

	public void SaveSetting(string SettingName, object Value)
	{
		SaveSetting(DefaultSection, SettingName, Value);
	}

	public void SaveSetting(string SettingName, string[] sa)
	{
		string defaultSection = DefaultSection;
		SaveSetting(defaultSection, SettingName, string.Join(Class16.smethod_0(1648898262), sa));
		GC.KeepAlive(this);
	}

	public void SaveSetting(string SettingName, Point point_0)
	{
		using (BeginBatchUpdate())
		{
			string defaultSection = DefaultSection;
			SaveSetting(defaultSection, SettingName + Class16.smethod_0(1648898244), point_0.X);
			string defaultSection2 = DefaultSection;
			SaveSetting(defaultSection2, SettingName + Class16.smethod_0(1648898253), point_0.Y);
		}
		GC.KeepAlive(this);
	}

	public void DeleteSetting(string Section, string SettingName)
	{
		bool flag;
		lock (object_0)
		{
			if (!method_5(Section, SettingName))
			{
				GC.KeepAlive(this);
				return;
			}
			bool_0 = true;
			flag = int_0 == 0;
		}
		if (flag)
		{
			SaveXml(0);
		}
	}

	public void DeleteSetting(string SettingName)
	{
		DeleteSetting(DefaultSection, SettingName);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SaveXml(int attempt)
	{
		Exception ex = null;
		int num = Math.Max(attempt, 0);
		for (int i = num; i < 10; i++)
		{
			string text = null;
			try
			{
				lock (object_0)
				{
					if (!bool_0)
					{
						GC.KeepAlive(this);
						return true;
					}
					method_2();
					string directoryName = System.IO.Path.GetDirectoryName(FileName);
					if (!string.IsNullOrWhiteSpace(directoryName) && !Directory.Exists(directoryName))
					{
						Directory.CreateDirectory(directoryName);
					}
					text = method_7();
					if (File.Exists(text))
					{
						File.Delete(text);
					}
					xmlDocument_0.Save(text);
					method_8(text);
					bool_0 = false;
				}
				GC.KeepAlive(this);
				return true;
			}
			catch (IOException ex2)
			{
				ex = ex2;
			}
			catch (UnauthorizedAccessException ex3)
			{
				ex = ex3;
				if (method_0())
				{
					continue;
				}
			}
			catch (Exception ex4)
			{
				ex = ex4;
				break;
			}
			finally
			{
				try
				{
					if (!string.IsNullOrWhiteSpace(text) && File.Exists(text))
					{
						File.Delete(text);
					}
				}
				catch
				{
				}
			}
			if (i + 1 < 10)
			{
				Thread.Sleep(100);
			}
		}
		if (ex != null)
		{
			bool flag = ex is UnauthorizedAccessException || ex is IOException;
			string item = NormalizeProfilePath(FileName) ?? FileName;
			bool flag2;
			lock (object_1)
			{
				flag2 = !hashSet_1.Add(item);
			}
			if (!flag2 && !flag)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648898270));
			}
			method_9(ex);
		}
		return false;
	}

	private bool method_0()
	{
		lock (object_0)
		{
			if (!string.IsNullOrWhiteSpace(DefaultFileName) && !ArePathsEqual(FileName, DefaultFileName))
			{
				try
				{
					string directoryName = System.IO.Path.GetDirectoryName(DefaultFileName);
					if (!string.IsNullOrWhiteSpace(directoryName) && !Directory.Exists(directoryName))
					{
						Directory.CreateDirectory(directoryName);
					}
					FileName = DefaultFileName;
					return true;
				}
				catch
				{
					return false;
				}
			}
			return false;
		}
	}

	public void DeleteSection(string Section)
	{
		bool flag;
		lock (object_0)
		{
			if (!method_6(Section))
			{
				GC.KeepAlive(this);
				return;
			}
			bool_0 = true;
			flag = int_0 == 0;
		}
		if (flag)
		{
			SaveXml(0);
		}
	}

	private void method_1()
	{
		lock (object_0)
		{
			method_2();
		}
		GC.KeepAlive(this);
	}

	private void method_2()
	{
		XmlElement documentElement = xmlDocument_0.DocumentElement;
		if (documentElement == null || !(documentElement.Name == Class16.smethod_0(1648898290)))
		{
			xmlDocument_0.RemoveAll();
			XmlDeclaration newChild = xmlDocument_0.CreateXmlDeclaration(Class16.smethod_0(1648898309), Class16.smethod_0(1648898319), Class16.smethod_0(1648898323));
			xmlDocument_0.AppendChild(newChild);
			XmlElement xmlElement = xmlDocument_0.CreateElement(Class16.smethod_0(1648898290));
			xmlElement.SetAttribute(Class16.smethod_0(1648898341), Class16.smethod_0(1648898209));
			xmlDocument_0.AppendChild(xmlElement);
		}
	}

	private void method_3()
	{
		bool flag = false;
		lock (object_0)
		{
			if (int_0 > 0)
			{
				int_0--;
			}
			flag = int_0 == 0 && bool_0;
		}
		if (flag)
		{
			SaveXml(0);
		}
	}

	private static XmlElement smethod_0(XmlNode xmlNode_0, string string_0)
	{
		if (xmlNode_0 != null && !string.IsNullOrWhiteSpace(string_0))
		{
			foreach (XmlNode childNode in xmlNode_0.ChildNodes)
			{
				if (childNode is XmlElement result && childNode.Name == string_0)
				{
					return result;
				}
			}
			return null;
		}
		return null;
	}

	private XmlElement method_4(string string_0)
	{
		method_2();
		XmlElement documentElement = xmlDocument_0.DocumentElement;
		XmlElement xmlElement = smethod_0(documentElement, string_0);
		if (xmlElement != null)
		{
			return xmlElement;
		}
		XmlElement xmlElement2 = xmlDocument_0.CreateElement(string_0);
		documentElement.AppendChild(xmlElement2);
		return xmlElement2;
	}

	private static bool smethod_1(XmlElement xmlElement_0, string string_0, string string_1)
	{
		XmlElement xmlElement = smethod_0(xmlElement_0, string_0);
		if (xmlElement != null)
		{
			if (string.Equals(xmlElement.InnerText, string_1, StringComparison.Ordinal))
			{
				return false;
			}
			xmlElement.InnerText = string_1;
			return true;
		}
		XmlElement xmlElement2 = xmlElement_0.OwnerDocument.CreateElement(string_0);
		xmlElement2.InnerText = string_1;
		xmlElement_0.AppendChild(xmlElement2);
		return true;
	}

	private bool method_5(string string_0, string string_1)
	{
		method_2();
		XmlElement xmlElement = smethod_0(xmlDocument_0.DocumentElement, string_0);
		if (xmlElement == null)
		{
			return false;
		}
		XmlElement xmlElement2 = smethod_0(xmlElement, string_1);
		if (xmlElement2 == null)
		{
			return false;
		}
		xmlElement.RemoveChild(xmlElement2);
		return true;
	}

	private bool method_6(string string_0)
	{
		method_2();
		XmlElement documentElement = xmlDocument_0.DocumentElement;
		XmlElement xmlElement = smethod_0(documentElement, string_0);
		if (xmlElement == null)
		{
			return false;
		}
		documentElement.RemoveChild(xmlElement);
		return true;
	}

	private string method_7()
	{
		return FileName + Class16.smethod_0(1648898359) + Process.GetCurrentProcess().Id + Class16.smethod_0(1648928036) + Guid.NewGuid().ToString(Class16.smethod_0(1648930778));
	}

	private void method_8(string string_0)
	{
		if (!File.Exists(FileName))
		{
			File.Move(string_0, FileName);
			return;
		}
		smethod_3(FileName);
		try
		{
			File.Replace(string_0, FileName, null, ignoreMetadataErrors: true);
		}
		catch (UnauthorizedAccessException) when (smethod_2(string_0, FileName))
		{
		}
		catch (IOException) when (smethod_2(string_0, FileName))
		{
		}
	}

	private static bool smethod_2(string string_0, string string_1)
	{
		try
		{
			smethod_3(string_1);
			FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
			try
			{
				FileStream fileStream2 = new FileStream(string_1, FileMode.Create, FileAccess.Write, FileShare.ReadWrite | FileShare.Delete);
				try
				{
					fileStream.CopyTo(fileStream2);
					fileStream2.Flush();
					return true;
				}
				finally
				{
					((IDisposable)fileStream2).Dispose();
				}
			}
			finally
			{
				((IDisposable)fileStream).Dispose();
			}
		}
		catch
		{
			try
			{
				string text = string_1 + Class16.smethod_0(1648898363);
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				File.Move(string_1, text);
				File.Move(string_0, string_1);
				try
				{
					File.Delete(text);
				}
				catch
				{
				}
				return true;
			}
			catch
			{
				return false;
			}
		}
	}

	private static void smethod_3(string string_0)
	{
		if (File.Exists(string_0))
		{
			FileAttributes attributes = File.GetAttributes(string_0);
			if ((attributes & FileAttributes.ReadOnly) != 0)
			{
				File.SetAttributes(string_0, attributes & ~FileAttributes.ReadOnly);
			}
		}
	}

	private void method_9(Exception exception_0)
	{
		string item = NormalizeProfilePath(FileName) ?? FileName;
		bool flag;
		lock (object_1)
		{
			flag = hashSet_0.Add(item);
		}
		if (!flag)
		{
			return;
		}
		try
		{
			string caption = Class16.smethod_0(1648898382);
			string text = Class16.smethod_0(1648898402) + FileName + Class16.smethod_0(1648898460) + exception_0.Message + Class16.smethod_0(1648898471);
			DKBox.Show(text, caption);
		}
		catch
		{
		}
	}

	private static string smethod_4(string string_0)
	{
		if (!string.IsNullOrWhiteSpace(string_0) && !IsDefaultProfilePath(string_0))
		{
			string string_1 = NormalizeProfilePath(string_0);
			return smethod_5(string_1) ?? DefaultFileName;
		}
		return DefaultFileName;
	}

	private static string smethod_5(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return null;
		}
		if (!smethod_7(string_0, LegacyRoamingProfilesDirectory))
		{
			return string_0;
		}
		string text = System.IO.Path.Combine(ProfilesDirectory, System.IO.Path.GetFileName(string_0));
		smethod_6(string_0, text, Class16.smethod_0(1648898551));
		return text;
	}

	public static string NormalizeProfilePath(string profilePath)
	{
		if (string.IsNullOrWhiteSpace(profilePath))
		{
			return null;
		}
		try
		{
			return System.IO.Path.GetFullPath(profilePath.Trim());
		}
		catch
		{
			return profilePath.Trim();
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool ArePathsEqual(string leftPath, string rightPath)
	{
		if (!string.IsNullOrWhiteSpace(leftPath) && !string.IsNullOrWhiteSpace(rightPath))
		{
			return string.Equals(NormalizeProfilePath(leftPath), NormalizeProfilePath(rightPath), StringComparison.OrdinalIgnoreCase);
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool IsDefaultProfilePath(string profilePath)
	{
		if (string.IsNullOrWhiteSpace(profilePath))
		{
			return false;
		}
		if (!ArePathsEqual(profilePath, DefaultFileName) && !ArePathsEqual(profilePath, LegacyDefaultFileName))
		{
			return ArePathsEqual(profilePath, LegacyRoamingDefaultFileName);
		}
		return true;
	}

	public static string GetAutoProfilePath(string profileName)
	{
		Directory.CreateDirectory(ProfilesDirectory);
		return System.IO.Path.Combine(ProfilesDirectory, smethod_9(profileName) + Class16.smethod_0(1648906288));
	}

	public static void EnsureDefaultProfileLocationMigrated()
	{
		smethod_6(LegacyDefaultFileName, DefaultFileName, Class16.smethod_0(1648901668));
		smethod_6(LegacyRoamingDefaultFileName, DefaultFileName, Class16.smethod_0(1648901724));
	}

	private static void smethod_6(string string_0, string string_1, string string_2)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(string_0) || string.IsNullOrWhiteSpace(string_1) || ArePathsEqual(string_0, string_1))
			{
				return;
			}
			Directory.CreateDirectory(ProfilesDirectory);
			if (File.Exists(string_1) || !File.Exists(string_0))
			{
				return;
			}
			smethod_3(string_0);
			smethod_3(string_1);
			File.Copy(string_0, string_1, overwrite: false);
			try
			{
				smethod_3(string_0);
				File.Delete(string_0);
			}
			catch
			{
			}
		}
		catch (UnauthorizedAccessException)
		{
		}
		catch (IOException)
		{
		}
		catch (Exception ex3)
		{
			SentryHelper.CaptureException(ex3, string_2);
		}
	}

	private static bool smethod_7(string string_0, string string_1)
	{
		if (!string.IsNullOrWhiteSpace(string_0) && !string.IsNullOrWhiteSpace(string_1))
		{
			string text = NormalizeProfilePath(string_0);
			string value = smethod_8(string_1);
			if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(value))
			{
				return text.StartsWith(value, StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}
		return false;
	}

	private static string smethod_8(string string_0)
	{
		string text = NormalizeProfilePath(string_0);
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		return text.TrimEnd(System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar) + System.IO.Path.DirectorySeparatorChar;
	}

	private static string smethod_9(string string_0)
	{
		string text = (string.IsNullOrWhiteSpace(string_0) ? string.Empty : string_0.Trim());
		if (text.EndsWith(Class16.smethod_0(1648906288), StringComparison.OrdinalIgnoreCase) || text.EndsWith(Class16.smethod_0(1648901780), StringComparison.OrdinalIgnoreCase))
		{
			text = System.IO.Path.GetFileNameWithoutExtension(text);
		}
		char[] invalidFileNameChars = System.IO.Path.GetInvalidFileNameChars();
		if (!string.IsNullOrEmpty(text))
		{
			StringBuilder stringBuilder = new StringBuilder(text.Length);
			string text2 = text;
			foreach (char value in text2)
			{
				if (Array.IndexOf(invalidFileNameChars, value) == -1)
				{
					stringBuilder.Append(value);
				}
			}
			text = stringBuilder.ToString().Trim();
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			text = DateTime.Now.ToString(Class16.smethod_0(1648906450));
		}
		return text;
	}
}
