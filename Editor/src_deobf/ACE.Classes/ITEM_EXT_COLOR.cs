using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ACE.RSGlobal;

namespace ACE.Classes;

public class ITEM_EXT_COLOR
{
	public static CommonStorage CStorage;

	public IDictionary<int, int> Colors;

	public bool FileChanged;

	public bool FileLoaded;

	private Regex regex_0 = new Regex(Class16.smethod_0(1648904256), RegexOptions.Compiled);

	public ITEM_EXT_COLOR(byte[] FileContent)
	{
		FileLoaded = false;
		FileChanged = false;
		if (FileContent != null)
		{
			Load(new StreamReader(new MemoryStream(FileContent)));
		}
	}

	public ITEM_EXT_COLOR(string fn)
	{
		FileLoaded = false;
		Load(fn);
		FileChanged = false;
	}

	public void Load(StreamReader sr)
	{
		Colors = new Dictionary<int, int>();
		int num = -1;
		string text = null;
		try
		{
			while (!sr.EndOfStream)
			{
				text = sr.ReadLine();
				num++;
				if (string.IsNullOrWhiteSpace(text) || text.StartsWith(Class16.smethod_0(1648904229)) || text.StartsWith(Class16.smethod_0(1648929947)))
				{
					continue;
				}
				Match match = regex_0.Match(text);
				if (match.Groups.Count != 3)
				{
					object[] vars = new object[3]
					{
						num,
						text,
						Class16.smethod_0(1648904287)
					};
					TextStorage.TEXTS.ShowMessage(617, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
					continue;
				}
				uint result = 0u;
				if (!global::ACE.RSGlobal.RSGlobal.TryParseUIntFast(match.Groups[1].Value, ref result))
				{
					object[] array = new object[3] { num, text, null };
					string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648904311));
					array[2] = text2;
					TextStorage.TEXTS.ShowMessage(617, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, array);
					continue;
				}
				int result2 = 0;
				if (!global::ACE.RSGlobal.RSGlobal.TryParseUIntFastAsInt(match.Groups[2].Value, ref result2))
				{
					object[] array2 = new object[3] { num, text, null };
					string text3 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648904334));
					array2[2] = text3;
					TextStorage.TEXTS.ShowMessage(617, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, array2);
				}
				else if (result2 >= 1)
				{
					if (Colors.ContainsKey((int)result))
					{
						Colors[(int)result] = result2;
					}
					else
					{
						Colors.Add((int)result, result2);
					}
				}
			}
			FileLoaded = true;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648904357));
			object[] vars2 = new object[3] { num, text, ex.Message };
			TextStorage.TEXTS.ShowMessage(617, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars2);
			FileLoaded = false;
			Colors = null;
		}
		finally
		{
			sr.Close();
		}
		GC.KeepAlive(this);
	}

	public void Load(string fn)
	{
		if (!File.Exists(fn))
		{
			GC.KeepAlive(this);
			return;
		}
		// TODO(recovered): File.Exists can pass for a file that is then unreadable (locks/permissions/race). Guard the
		// StreamReader open so a failure degrades gracefully (empty color set) instead of throwing out of the loader.
		StreamReader sr;
		try
		{
			sr = new StreamReader(fn);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, "ITEM_EXT_COLOR.Load open failed for " + fn);
			Colors = new Dictionary<int, int>();
			FileLoaded = false;
			GC.KeepAlive(this);
			return;
		}
		Load(sr);
	}

	public void Save(string fn, [MarshalAs(UnmanagedType.U1)] bool IsSaveAs)
	{
		if (!(fn == string.Empty) && Colors.Count != 0 && (FileChanged || IsSaveAs))
		{
			File.WriteAllBytes(fn, GetBytes());
			if (!IsSaveAs)
			{
				FileChanged = false;
			}
		}
	}

	public byte[] GetBytes()
	{
		MemoryStream memoryStream = new MemoryStream();
		StreamWriter streamWriter = new StreamWriter(memoryStream, Encoding.ASCII);
		foreach (KeyValuePair<int, int> color in Colors)
		{
			ValueType valueType = color;
			if (((KeyValuePair<int, int>)(object)valueType).Value > 0)
			{
				int value = ((KeyValuePair<int, int>)(object)valueType).Value;
				int key = ((KeyValuePair<int, int>)(object)valueType).Key;
				string text = Class16.smethod_0(1648904383);
				streamWriter.WriteLine(string.Concat(key + text, value.ToString()));
			}
		}
		streamWriter.Close();
		byte[] result = memoryStream.ToArray();
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool Change(int id, int color)
	{
		if (Colors.Count == 0)
		{
			GC.KeepAlive(this);
			return false;
		}
		if (Colors.ContainsKey(id))
		{
			Colors[id] = color;
		}
		else
		{
			Colors.Add(id, color);
		}
		FileChanged = true;
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool Change(int[] IDs, int color)
	{
		bool result = false;
		int num = 0;
		if (0 < (nint)IDs.LongLength)
		{
			do
			{
				int id = IDs[num];
				result = Change(id, color);
				num++;
			}
			while (num < (nint)IDs.LongLength);
		}
		return result;
	}

	public int Get(int id)
	{
		int result = 0;
		if (Colors.ContainsKey(id))
		{
			result = Colors[id];
		}
		GC.KeepAlive(this);
		return result;
	}
}
