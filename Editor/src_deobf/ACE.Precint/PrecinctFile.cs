using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using ACE.Classes;

namespace ACE.Precint;

public class PrecinctFile
{
	[StructLayout(LayoutKind.Auto)]
	// TODO(recovered): bumped private->internal to match the ref-param method that exposes it.
	internal struct Struct108
	{
		public string string_0;
	}

	[StructLayout(LayoutKind.Auto)]
	// TODO(recovered): bumped private->internal to match the ref-param method that exposes it.
	internal struct Struct109
	{
		public StreamReader streamReader_0;
	}

	private uint uint_0 = 7u;

	private int int_0;

	private Encoding encoding_0;

	private List<PrecinctEntry> list_0 = new List<PrecinctEntry>();

	public uint dwVersion
	{
		[CompilerGenerated]
		get
		{
			return uint_0;
		}
		[CompilerGenerated]
		set
		{
			uint_0 = value;
		}
	}

	public int dwTimeStamp
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

	public Encoding encoding
	{
		[CompilerGenerated]
		get
		{
			return encoding_0;
		}
		[CompilerGenerated]
		set
		{
			encoding_0 = value;
		}
	}

	public List<PrecinctEntry> zones
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

	public bool SaveFile(string path, bool both = true, bool PutToData = true)
	{
		try
		{
			if (!Directory.Exists(System.IO.Path.GetDirectoryName(path)))
			{
				Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));
			}
			string directoryName = System.IO.Path.GetDirectoryName(path);
			string fileName = System.IO.Path.GetFileName(directoryName);
			string fileName2 = System.IO.Path.GetFileName(path);
			string empty = string.Empty;
			if (PutToData)
			{
				string path2 = directoryName.Replace(Class16.smethod_0(1649093268) + fileName, string.Empty);
				empty = System.IO.Path.Combine(path2, Class16.smethod_0(1648909668) + fileName + System.IO.Path.DirectorySeparatorChar + fileName2);
			}
			else
			{
				empty = System.IO.Path.Combine(directoryName, fileName2);
			}
			if (!Directory.Exists(System.IO.Path.GetDirectoryName(empty)))
			{
				Directory.CreateDirectory(System.IO.Path.GetDirectoryName(empty));
			}
			string text = empty.Replace(Class16.smethod_0(1649191156), Class16.smethod_0(1649191167));
			MemoryStream memoryStream = new MemoryStream();
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				try
				{
					binaryWriter.Write(dwVersion);
					binaryWriter.Write(zones.Count);
					if (dwVersion >= 5)
					{
						binaryWriter.Write(dwTimeStamp);
					}
					foreach (PrecinctEntry zone in zones)
					{
						binaryWriter.Write(zone.iNumPoint);
						binaryWriter.Write(zone.m_iPriority);
						binaryWriter.Write(zone.m_idDstIns);
						if (dwVersion >= 4)
						{
							binaryWriter.Write(zone.m_idSrcInst);
						}
						if (dwVersion >= 6)
						{
							binaryWriter.Write(zone.m_idDomain);
						}
						if (dwVersion >= 7)
						{
							binaryWriter.Write(zone.m_bPKProtect);
						}
						zone.m_vCityPos.Write(binaryWriter);
						for (int i = 0; i < zone.iNumPoint; i++)
						{
							zone.m_aPoints[i].Write(binaryWriter);
						}
					}
					EditorSessionTracker.LogFolderAccess(text, Class16.smethod_0(1649006856), Class16.smethod_0(1649188979));
					File.WriteAllBytes(text, memoryStream.ToArray());
				}
				finally
				{
					((IDisposable)binaryWriter).Dispose();
				}
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
			if (!both)
			{
				return true;
			}
			StringBuilder stringBuilder = new StringBuilder(Class16.smethod_0(1649191170));
			stringBuilder.AppendLine();
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(Class16.smethod_0(1649191219) + dwVersion);
			stringBuilder.AppendLine(dwTimeStamp.ToString());
			stringBuilder.AppendLine();
			foreach (PrecinctEntry zone2 in zones)
			{
				stringBuilder.AppendLine(Class16.smethod_0(1648904453) + zone2.name + Class16.smethod_0(1648904453));
				zone2.iNumMark = zone2.Npcs?.Count ?? 0;
				string text2 = zone2.ID + Class16.smethod_0(1649043292);
				text2 = text2 + zone2.iNumPoint + Class16.smethod_0(1649043292);
				text2 = text2 + zone2.iNumMark + Class16.smethod_0(1649043292);
				text2 = text2 + zone2.m_iPriority + Class16.smethod_0(1649043292);
				text2 = text2 + zone2.m_idDstIns + Class16.smethod_0(1649043292);
				text2 = text2 + zone2.iNumMusic + Class16.smethod_0(1649043292);
				text2 = text2 + zone2.m_iMusicInter + Class16.smethod_0(1649043292);
				text2 = text2 + zone2.m_iMusicLoop + Class16.smethod_0(1649043292);
				text2 = text2 + zone2.m_idSrcInst + Class16.smethod_0(1649043292);
				if (dwVersion >= 6 && dwVersion < 7)
				{
					text2 += zone2.m_idDomain;
				}
				else if (dwVersion >= 7)
				{
					text2 = text2 + zone2.m_idDomain + Class16.smethod_0(1649043292);
					text2 += zone2.m_bPKProtect;
				}
				stringBuilder.AppendLine(text2);
				stringBuilder.AppendLine(zone2.m_vCityPos.ToStringComma());
				for (int j = 0; j < zone2.iNumPoint; j++)
				{
					stringBuilder.AppendLine(zone2.m_aPoints[j].ToStringSpaced());
				}
				stringBuilder.AppendLine();
				if (zone2.Npcs.Count == 0)
				{
					stringBuilder.AppendLine();
				}
				else
				{
					for (int k = 0; k < zone2.Npcs.Count; k++)
					{
						stringBuilder.AppendLine(zone2.Npcs[k].ToLine());
					}
					stringBuilder.AppendLine();
				}
				for (int l = 0; l < zone2.music.Count; l++)
				{
					string text3 = zone2.music[l]?.Trim();
					if (!string.IsNullOrWhiteSpace(text3))
					{
						stringBuilder.AppendLine(Class16.smethod_0(1648904453) + text3 + Class16.smethod_0(1648904453));
					}
				}
				stringBuilder.AppendLine();
			}
			if (encoding == null)
			{
				encoding = Encoding.UTF8;
			}
			EditorSessionTracker.LogFolderAccess(path, Class16.smethod_0(1649006856), Class16.smethod_0(1649188979));
			File.WriteAllText(path, stringBuilder.ToString(), encoding);
			return true;
		}
		catch
		{
			return false;
		}
	}

	private string method_0(string string_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return Class16.smethod_0(1648924112);
		}
		string text = string.Empty;
		for (int i = 0; i < string_0.Length; i++)
		{
			char c = string_0[i];
			if (char.IsDigit(c) || c == '-' || c == '.')
			{
				text += c;
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			return text;
		}
		return Class16.smethod_0(1648924112);
	}

	private string method_1(string string_0, string string_1, string string_2)
	{
		int num = string_0.IndexOf(string_1);
		if (num < 0)
		{
			return string.Empty;
		}
		num += string_1.Length;
		int num2 = string_0.IndexOf(string_2, num);
		if (num2 < 0)
		{
			return string.Empty;
		}
		return string_0.Substring(num, num2 - num);
	}

	public bool ReadFile(string path)
	{
		try
		{
			EditorSessionTracker.LogFolderAccess(path, Class16.smethod_0(1648903793), Class16.smethod_0(1649188979));
			zones = new List<PrecinctEntry>();
			using (FileStream stream = File.OpenRead(path))
			{
				Struct109 A_ = default(Struct109);
				A_.streamReader_0 = new StreamReader(stream);
				try
				{
					Struct108 A_2 = default(Struct108);
					A_2.string_0 = null;
					string text;
					while ((text = smethod_0(ref A_, ref A_2)) != null)
					{
						if (text.Contains(Class16.smethod_0(1649074689)) && !text.StartsWith(Class16.smethod_0(1648904229)))
						{
							encoding = A_.streamReader_0.CurrentEncoding;
							dwVersion = uint.Parse(method_0(text));
							dwTimeStamp = int.Parse(method_0(A_.streamReader_0.ReadLine()));
						}
						if (!text.Contains(Class16.smethod_0(1648904453)) || text.StartsWith(Class16.smethod_0(1648904229)) || text.Contains(Class16.smethod_0(1649074689)))
						{
							continue;
						}
						PrecinctEntry precinctEntry = new PrecinctEntry();
						precinctEntry.name = text.Replace(Class16.smethod_0(1648904453), string.Empty).Trim();
						string text2 = smethod_0(ref A_, ref A_2);
						if (text2 == null)
						{
							break;
						}
						string[] array = text2.Split(new char[2] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
						int num = 0;
						num = 1;
						precinctEntry.ID = int.Parse(method_0(array[0]));
						num = 2;
						int num2 = int.Parse(method_0(array[1]));
						num = 3;
						precinctEntry.iNumMark = int.Parse(method_0(array[2]));
						num = 4;
						precinctEntry.m_iPriority = int.Parse(method_0(array[3]));
						num = 5;
						precinctEntry.m_idDstIns = int.Parse(method_0(array[4]));
						num = 6;
						num = 7;
						precinctEntry.m_iMusicInter = int.Parse(method_0(array[6]));
						num = 8;
						precinctEntry.m_iMusicLoop = int.Parse(method_0(array[7]));
						num = 9;
						precinctEntry.m_idSrcInst = int.Parse(method_0(array[8]));
						if (dwVersion >= 6 && num < array.Length)
						{
							precinctEntry.m_idDomain = int.Parse(method_0(array[num++]));
						}
						if (dwVersion >= 7 && num < array.Length)
						{
							precinctEntry.m_bPKProtect = byte.Parse(method_0(array[num++]));
						}
						string text3 = smethod_0(ref A_, ref A_2);
						if (text3 == null)
						{
							break;
						}
						precinctEntry.m_vCityPos = new PrecinctVector3(text3, ',');
						precinctEntry.m_aPoints = new List<PrecinctVector3>();
						for (int i = 0; i < num2; i++)
						{
							string text4 = smethod_0(ref A_, ref A_2);
							if (text4 == null || string.IsNullOrWhiteSpace(text4))
							{
								break;
							}
							precinctEntry.m_aPoints.Add(new PrecinctVector3(text4));
						}
						precinctEntry.Npcs = new List<PrecinctNPC>();
						precinctEntry.music = new List<string>();
						string text5 = smethod_0(ref A_, ref A_2);
						while (text5 != null && string.IsNullOrWhiteSpace(text5))
						{
							text5 = smethod_0(ref A_, ref A_2);
						}
						for (int j = 0; j < precinctEntry.iNumMark; j++)
						{
							while (text5 != null && string.IsNullOrWhiteSpace(text5))
							{
								text5 = smethod_0(ref A_, ref A_2);
							}
							if (text5 == null || !smethod_2(text5))
							{
								break;
							}
							string name = method_1(text5, Class16.smethod_0(1648904453), Class16.smethod_0(1648904453));
							PrecinctNPC precinctNPC = new PrecinctNPC();
							precinctNPC.Name = name;
							string line = text5.Split('"')[2].Trim();
							precinctNPC.position = new PrecinctVector3(line);
							precinctEntry.Npcs.Add(precinctNPC);
							text5 = smethod_0(ref A_, ref A_2);
						}
						if (text5 != null && !string.IsNullOrWhiteSpace(text5) && !smethod_2(text5))
						{
							smethod_1(text5, ref A_2);
						}
						text5 = smethod_0(ref A_, ref A_2);
						while (text5 != null && string.IsNullOrWhiteSpace(text5))
						{
							text5 = smethod_0(ref A_, ref A_2);
						}
						while (text5 != null && !string.IsNullOrWhiteSpace(text5) && text5.Contains(Class16.smethod_0(1648904453)) && !text5.StartsWith(Class16.smethod_0(1648904229)))
						{
							string text6 = text5.Replace(Class16.smethod_0(1648904453), string.Empty).Trim();
							if (!string.IsNullOrWhiteSpace(text6))
							{
								precinctEntry.music.Add(text6);
							}
							text5 = smethod_0(ref A_, ref A_2);
						}
						if (text5 != null && !string.IsNullOrWhiteSpace(text5))
						{
							smethod_1(text5, ref A_2);
						}
						zones.Add(precinctEntry);
					}
				}
				finally
				{
					if (A_.streamReader_0 != null)
					{
						((IDisposable)A_.streamReader_0).Dispose();
					}
				}
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	[CompilerGenerated]
	internal static string smethod_0(ref Struct109 A_0, ref Struct108 A_1)
	{
		if (A_1.string_0 != null)
		{
			string string_ = A_1.string_0;
			A_1.string_0 = null;
			return string_;
		}
		return A_0.streamReader_0.ReadLine();
	}

	[CompilerGenerated]
	internal static void smethod_1(string lineToPush, ref Struct108 A_1)
	{
		if (A_1.string_0 != null)
		{
			throw new InvalidOperationException(Class16.smethod_0(1649191235));
		}
		A_1.string_0 = lineToPush;
	}

	[CompilerGenerated]
	internal static bool smethod_2(string npcLine)
	{
		if (string.IsNullOrWhiteSpace(npcLine))
		{
			return false;
		}
		if (!npcLine.Contains(Class16.smethod_0(1648904453)))
		{
			return false;
		}
		string[] array = npcLine.Split('"');
		if (array.Length < 3)
		{
			return false;
		}
		string text = array[2].Trim();
		if (string.IsNullOrWhiteSpace(text))
		{
			return false;
		}
		string[] array2 = text.Split(new char[2] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
		if (array2.Length < 3)
		{
			return false;
		}
		if (float.TryParse(array2[0], NumberStyles.Float, CultureInfo.InvariantCulture, out var result) && float.TryParse(array2[1], NumberStyles.Float, CultureInfo.InvariantCulture, out result))
		{
			return float.TryParse(array2[2], NumberStyles.Float, CultureInfo.InvariantCulture, out result);
		}
		return false;
	}
}
