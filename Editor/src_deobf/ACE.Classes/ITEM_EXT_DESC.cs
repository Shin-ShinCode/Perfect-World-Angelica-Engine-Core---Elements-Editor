using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ACE.RSGlobal;

namespace ACE.Classes;

public class ITEM_EXT_DESC
{
	public static CommonStorage CStorage;

	public IDictionary<int, string> Descriptions;

	public bool FileChanged;

	public bool FileLoaded;

	public string fn;

	public bool bLua;

	public ITEM_EXT_DESC(byte[] FileContent)
	{
		FileLoaded = false;
		FileChanged = false;
		if (FileContent != null)
		{
			Load(Encoding.Unicode.GetString(FileContent));
		}
		GC.KeepAlive(this);
	}

	public ITEM_EXT_DESC(string fn)
	{
		this.fn = fn;
		FileLoaded = false;
		FileChanged = false;
		if (fn.EndsWith(Class16.smethod_0(1648904996)))
		{
			bLua = true;
		}
		if (File.Exists(fn))
		{
			// TODO(recovered): File.ReadAllText can throw on locks/permissions/encoding even after File.Exists passes.
			// Guard it so a failure degrades gracefully (file simply not loaded) instead of throwing out of the constructor.
			try
			{
				Load(File.ReadAllText(fn));
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, "ITEM_EXT_DESC read failed for " + fn);
				FileLoaded = false;
			}
		}
		GC.KeepAlive(this);
	}

	public void Load(string FileContent)
	{
		if (string.IsNullOrWhiteSpace(FileContent))
		{
			GC.KeepAlive(this);
		}
		else if (bLua)
		{
			FileLoaded = LoadFromLua(FileContent);
		}
		else
		{
			FileLoaded = LoadFromText(FileContent);
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool LoadFromLua(string FileContent)
	{
		MatchCollection matchCollection = Regex.Matches(FileContent, Class16.smethod_0(1648904391));
		if (matchCollection.Count == 0)
		{
			GC.KeepAlive(this);
			return false;
		}
		Descriptions = new Dictionary<int, string>(matchCollection.Count);
		foreach (Match item in matchCollection)
		{
			int result = 0;
			string groupname = Class16.smethod_0(1648932143);
			if (!int.TryParse(item.Groups[groupname].Value, out result))
			{
				continue;
			}
			string groupname2 = Class16.smethod_0(1648904434);
			string value = item.Groups[groupname2].Value;
			if (!string.IsNullOrEmpty(value))
			{
				if (Descriptions.ContainsKey(result))
				{
					Descriptions[result] = value;
				}
				else
				{
					Descriptions.Add(result, value);
				}
			}
		}
		GC.KeepAlive(this);
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool LoadFromText(string FileContent)
	{
		Descriptions = new Dictionary<int, string>();
		int i = 0;
		try
		{
			char[] anyOf = new char[2] { '\n', '\r' };
			int length = FileContent.Length;
			for (i = 0; i < length; i++)
			{
				char c = FileContent[i];
				int num = c;
				if (num != 35 && num != 47)
				{
					if ((uint)(ushort)(c + 65488) > 9u)
					{
						continue;
					}
					int num2 = i;
					int num3 = FileContent.IndexOf('"', i);
					num3 = ((num3 == -1) ? length : num3);
					for (i = num3 - 1; i > num2; i--)
					{
						char c2 = FileContent[i];
						if (c2 != ' ' && c2 != '\t')
						{
							break;
						}
					}
					int key = global::ACE.RSGlobal.RSGlobal.UIntParseFast(FileContent.Substring(num2, i - num2 + 1));
					int num4 = num3;
					bool flag = false;
					while (!flag)
					{
						num4 = FileContent.IndexOf('"', num4 + 1);
						if (num4 > -1)
						{
							int num5 = num4 + 1;
							if (num5 < length)
							{
								char c3 = FileContent[num5];
								if (c3 != '\r' && c3 != '\n')
								{
									int num6 = FileContent.IndexOfAny(anyOf, num5);
									if (num6 > 0)
									{
										string value = Class16.smethod_0(1648904453);
										if (FileContent.Substring(num5, num6 - num4).Contains(value))
										{
											num4 = num6 - 1;
										}
									}
								}
								flag = true;
							}
							else
							{
								flag = true;
							}
						}
						else
						{
							num4 = length;
							flag = true;
						}
					}
					string value2 = FileContent.Substring(num3 + 1, num4 - num3 - 1);
					Descriptions[key] = value2;
					i = num4;
				}
				else
				{
					i = FileContent.IndexOfAny(anyOf, i);
				}
			}
			FileLoaded = true;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648904461));
			int num7 = -1;
			if (i > 0)
			{
				num7 = global::ACE.RSGlobal.RSGlobal.CountWords(FileContent.Substring(0, i), Class16.smethod_0(1648941987));
			}
			object[] vars = new object[3]
			{
				num7,
				string.Empty,
				ex.Message
			};
			TextStorage.TEXTS.ShowMessage(615, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
			FileLoaded = false;
			Descriptions = null;
		}
		return FileLoaded;
	}

	public void Save(string fn, [MarshalAs(UnmanagedType.U1)] bool IsSaveAs)
	{
		if (string.IsNullOrWhiteSpace(fn))
		{
			return;
		}
		IDictionary<int, string> descriptions = Descriptions;
		if (descriptions != null && descriptions.Count != 0 && (FileChanged || IsSaveAs))
		{
			File.WriteAllBytes(fn, GetBytes());
			if (!IsSaveAs)
			{
				FileChanged = false;
			}
		}
	}

	public void Save()
	{
		Save(fn, IsSaveAs: false);
	}

	public byte[] GetBytes()
	{
		MemoryStream memoryStream = new MemoryStream();
		Encoding encoding = ((!bLua) ? Encoding.Unicode : Encoding.UTF8);
		StreamWriter streamWriter = new StreamWriter(memoryStream, encoding);
		if (bLua)
		{
			streamWriter.NewLine = Class16.smethod_0(1648941987);
			streamWriter.WriteLine(Class16.smethod_0(1648904494));
			foreach (KeyValuePair<int, string> description in Descriptions)
			{
				ValueType valueType = description;
				string value = ((KeyValuePair<int, string>)(object)valueType).Value;
				if (!string.IsNullOrEmpty(((KeyValuePair<int, string>)(object)valueType).Value))
				{
					streamWriter.WriteLine(Class16.smethod_0(1648904567), ((KeyValuePair<int, string>)(object)valueType).Key, value);
				}
			}
			streamWriter.WriteLine();
			streamWriter.WriteLine(Class16.smethod_0(1648904592));
			streamWriter.WriteLine();
		}
		else
		{
			streamWriter.WriteLine(Class16.smethod_0(1648899587));
			streamWriter.WriteLine(string.Empty);
			streamWriter.WriteLine(Class16.smethod_0(1648899639));
			streamWriter.WriteLine(Class16.smethod_0(1648899653));
			foreach (KeyValuePair<int, string> description2 in Descriptions)
			{
				ValueType valueType2 = description2;
				string value2 = ((KeyValuePair<int, string>)(object)valueType2).Value;
				if (!string.IsNullOrWhiteSpace(((KeyValuePair<int, string>)(object)valueType2).Value))
				{
					streamWriter.WriteLine(Class16.smethod_0(1648899659), ((KeyValuePair<int, string>)(object)valueType2).Key, value2);
				}
			}
		}
		streamWriter.Close();
		byte[] result = memoryStream.ToArray();
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool Change(int id, string desc)
	{
		if (Descriptions == null)
		{
			Descriptions = new Dictionary<int, string>();
		}
		if (id <= 0)
		{
			GC.KeepAlive(this);
			return false;
		}
		desc = global::ACE.RSGlobal.RSGlobal.CrLF2rn(desc);
		if (Descriptions.ContainsKey(id))
		{
			Descriptions[id] = desc;
		}
		else if (desc != null)
		{
			Descriptions.Add(id, desc);
		}
		FileChanged = true;
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool Change(int[] IDs, string desc)
	{
		bool result = false;
		int num = 0;
		if (0 < (nint)IDs.LongLength)
		{
			do
			{
				int id = IDs[num];
				result = Change(id, desc);
				num++;
			}
			while (num < (nint)IDs.LongLength);
		}
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool Delete(int id)
	{
		if (Descriptions != null && Descriptions.Count != 0)
		{
			if (Descriptions.ContainsKey(id))
			{
				Descriptions.Remove(id);
			}
			FileChanged = true;
			return true;
		}
		GC.KeepAlive(this);
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SetClean(int id, string desc)
	{
		if (Descriptions == null)
		{
			Descriptions = new Dictionary<int, string>();
		}
		if (id <= 0)
		{
			GC.KeepAlive(this);
			return false;
		}
		if (Descriptions.ContainsKey(id))
		{
			Descriptions[id] = desc;
		}
		else
		{
			Descriptions.Add(id, desc);
		}
		FileChanged = true;
		return true;
	}

	public string GetClean(int id)
	{
		if (Descriptions == null)
		{
			GC.KeepAlive(this);
			return null;
		}
		string value = null;
		if (!Descriptions.TryGetValue(id, out value))
		{
			value = null;
		}
		GC.KeepAlive(this);
		return value;
	}

	public string Get(int id)
	{
		IDictionary<int, string> descriptions = Descriptions;
		if (descriptions == null)
		{
			return string.Empty;
		}
		string value = null;
		if (descriptions.TryGetValue(id, out value) && value != null)
		{
			value = global::ACE.RSGlobal.RSGlobal.rn2CrLF(value);
			value = value.Replace('\t', ' ');
			GC.KeepAlive(this);
			return value;
		}
		GC.KeepAlive(this);
		return string.Empty;
	}
}
