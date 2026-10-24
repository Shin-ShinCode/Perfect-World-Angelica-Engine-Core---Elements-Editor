using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Classes.ACE;
using ACE.Precint;
using ACE.RSGlobal;
using ACE.Settings;

namespace ACE.NpcGen;

public class NPCGEN_LIST
{
	private static class Class254
	{
		public static Comparison<string> comparison_0;
	}

	public static CommonStorage CStorage;

	public Dictionary<string, NPCGEN_PW> NpcGens;

	public bool FilesLoaded;

	public NPCGEN_LIST(string[] Files)
	{
		SetFiles(Files);
	}

	public void SetFiles(string[] Files)
	{
		FilesLoaded = false;
		if (Files != null && Files.Length != 0)
		{
			if (INSTANCE_LIST.Instances == null)
			{
				string text = ((LANG_INFO.CurrentLang == null) ? Class16.smethod_0(1648931959) : LANG_INFO.CurrentLang.Prefix);
				string text2 = Class16.smethod_0(1648997294);
				string text3 = Class16.smethod_0(1649117242);
				string text4 = string.Concat(string.Concat(Application.StartupPath + text3, text), text2);
				string text5 = string.Concat(string.Concat(Application.StartupPath + text3, Class16.smethod_0(1648931959)), text2);
				string fn = (File.Exists(text4) ? text4 : text5);
				INSTANCE_LIST.Load(fn);
			}
			int num = 1;
			if (1 < (nint)Files.LongLength)
			{
				do
				{
					if (Files[num].EndsWith(Class16.smethod_0(1649117279)))
					{
						string text6 = Files[num];
						Files[num] = Files[0];
						Files[0] = text6;
					}
					num++;
				}
				while (num < (nint)Files.LongLength);
			}
			NpcGens = new Dictionary<string, NPCGEN_PW>(Files.Length);
			int num2 = 0;
			if (0 < (nint)Files.LongLength)
			{
				do
				{
					AddFile(Files[num2]);
					num2++;
				}
				while (num2 < (nint)Files.LongLength);
			}
			Dictionary<string, NPCGEN_PW> npcGens = NpcGens;
			int num3 = ((npcGens != null && npcGens.Count > 0) ? 1 : 0);
			FilesLoaded = (byte)num3 != 0;
			GC.KeepAlive(this);
		}
		else
		{
			NpcGens?.Clear();
			NpcGens = null;
		}
	}

	public void AddFile(string path)
	{
		if (!string.IsNullOrWhiteSpace(path) && File.Exists(path) && ACE.RSGlobal.RSGlobal.GetFileSize(path) >= 20L)
		{
			string directoryName = System.IO.Path.GetDirectoryName(path);
			string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(directoryName);
			if (!NpcGens.ContainsKey(fileNameWithoutExtension))
			{
				NPCGEN_PW nPCGEN_PW = new NPCGEN_PW(path);
				if (nPCGEN_PW.FileLoaded)
				{
					int num = INSTANCE_LIST.GetIdByServerTag(fileNameWithoutExtension);
					if (num == 0)
					{
						num = INSTANCE_LIST.AddInstance(fileNameWithoutExtension);
					}
					nPCGEN_PW.MapTag = fileNameWithoutExtension;
					nPCGEN_PW.InstanceID = num;
					string text = directoryName + Class16.smethod_0(1649117296);
					if (Directory.Exists(text) && File.Exists(text + Class16.smethod_0(1649117318)))
					{
						string[] files = Directory.GetFiles(text, Class16.smethod_0(1649117331), SearchOption.TopDirectoryOnly);
						Array.Sort(files, ACE.RSGlobal.RSGlobal.StrCmpLogicalW);
						nPCGEN_PW.SubNpcgens = new List<NPCGEN_PW>(files.Length);
						int num2 = 0;
						if (0 < (nint)files.LongLength)
						{
							do
							{
								ref string reference = ref files[num2];
								if (ACE.RSGlobal.RSGlobal.GetFileSize(path) >= 20L)
								{
									NPCGEN_PW nPCGEN_PW2 = new NPCGEN_PW(reference);
									if (nPCGEN_PW2.FileLoaded)
									{
										nPCGEN_PW2.MapTag = fileNameWithoutExtension;
										nPCGEN_PW2.InstanceID = num;
										nPCGEN_PW2.NpcgenIndex = nPCGEN_PW.SubNpcgens.Count;
										nPCGEN_PW.SubNpcgens.Add(nPCGEN_PW2);
									}
								}
								num2++;
							}
							while (num2 < (nint)files.LongLength);
						}
					}
					NpcGens.Add(fileNameWithoutExtension, nPCGEN_PW);
				}
			}
		}
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool TrySaveSomething()
	{
		bool result = false;
		if (FilesLoaded)
		{
			Dictionary<string, NPCGEN_PW>.Enumerator enumerator = NpcGens.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					NPCGEN_PW value = ((KeyValuePair<string, NPCGEN_PW>)(object)enumerator.Current).Value;
					if (value.FileChanged)
					{
						value.Save();
						result = true;
					}
					List<NPCGEN_PW> subNpcgens = value.SubNpcgens;
					if (subNpcgens == null)
					{
						continue;
					}
					List<NPCGEN_PW>.Enumerator enumerator2 = subNpcgens.GetEnumerator();
					if (!enumerator2.MoveNext())
					{
						continue;
					}
					do
					{
						NPCGEN_PW current = enumerator2.Current;
						if (current.FileChanged)
						{
							current.Save();
							result = true;
						}
					}
					while (enumerator2.MoveNext());
				}
				while (enumerator.MoveNext());
			}
		}
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFilesChanged()
	{
		if (!FilesLoaded)
		{
			return false;
		}
		Dictionary<string, NPCGEN_PW>.Enumerator enumerator = NpcGens.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				NPCGEN_PW value = ((KeyValuePair<string, NPCGEN_PW>)(object)enumerator.Current).Value;
				if (!value.IsFileChanged())
				{
					List<NPCGEN_PW> subNpcgens = value.SubNpcgens;
					if (subNpcgens == null)
					{
						continue;
					}
					List<NPCGEN_PW>.Enumerator enumerator2 = subNpcgens.GetEnumerator();
					if (!enumerator2.MoveNext())
					{
						continue;
					}
					do
					{
						if (enumerator2.Current.IsFileChanged())
						{
							GC.KeepAlive(this);
							return true;
						}
					}
					while (enumerator2.MoveNext());
					continue;
				}
				GC.KeepAlive(this);
				return true;
			}
			while (enumerator.MoveNext());
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFilesNotSaved()
	{
		if (FilesLoaded)
		{
			Dictionary<string, NPCGEN_PW> npcGens = NpcGens;
			if (npcGens != null)
			{
				Dictionary<string, NPCGEN_PW>.Enumerator enumerator = npcGens.GetEnumerator();
				if (enumerator.MoveNext())
				{
					do
					{
						NPCGEN_PW value = ((KeyValuePair<string, NPCGEN_PW>)(object)enumerator.Current).Value;
						if (!value.FileChanged)
						{
							List<NPCGEN_PW> subNpcgens = value.SubNpcgens;
							if (subNpcgens == null)
							{
								continue;
							}
							List<NPCGEN_PW>.Enumerator enumerator2 = subNpcgens.GetEnumerator();
							if (!enumerator2.MoveNext())
							{
								continue;
							}
							do
							{
								if (enumerator2.Current.FileChanged)
								{
									GC.KeepAlive(this);
									return true;
								}
							}
							while (enumerator2.MoveNext());
							continue;
						}
						GC.KeepAlive(this);
						return true;
					}
					while (enumerator.MoveNext());
				}
				return false;
			}
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFilesOnDiscChanged()
	{
		if (FilesLoaded)
		{
			Dictionary<string, NPCGEN_PW>.Enumerator enumerator = NpcGens.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					NPCGEN_PW value = ((KeyValuePair<string, NPCGEN_PW>)(object)enumerator.Current).Value;
					if (!value.IsFileOnDiscChanged())
					{
						List<NPCGEN_PW> subNpcgens = value.SubNpcgens;
						if (subNpcgens == null)
						{
							continue;
						}
						List<NPCGEN_PW>.Enumerator enumerator2 = subNpcgens.GetEnumerator();
						if (!enumerator2.MoveNext())
						{
							continue;
						}
						do
						{
							if (enumerator2.Current.IsFileOnDiscChanged())
							{
								GC.KeepAlive(this);
								return true;
							}
						}
						while (enumerator2.MoveNext());
						continue;
					}
					GC.KeepAlive(this);
					return true;
				}
				while (enumerator.MoveNext());
			}
		}
		return false;
	}

	public static string GetInstanceName(int ID)
	{
		return INSTANCE_LIST.GetNameByID(ID);
	}

	public static string GetInstanceName(string MapTag)
	{
		return INSTANCE_LIST.GetNameByServerTag(MapTag);
	}

	public unsafe static string GetAreaName(NPCGEN_PW npcgen, REFERENCE_ENTRY reference)
	{
		if (npcgen != null && reference != null)
		{
			bool flag = false;
			string text = string.Empty;
			if (npcgen.NpcgenIndex > -1)
			{
				string text2 = Class16.smethod_0(1649078775);
				text = System.IO.Path.GetFileNameWithoutExtension(npcgen.FileName) + text2;
			}
			float[] vPos = (float[])reference.oSpecial;
			int instanceID = npcgen.InstanceID;
			text += PRECINCT_LIST.GetAreaName(INSTANCE_LIST.GetClientTagByID(instanceID), instanceID, vPos, &flag);
			if (flag)
			{
				if (((LANG_INFO.CurrentLang == null) ? Class16.smethod_0(1648931959) : LANG_INFO.CurrentLang.Prefix) == Class16.smethod_0(1648932072))
				{
					text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649117359));
				}
				else
				{
					string text3 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649117359));
					text += text3;
				}
			}
			return text;
		}
		return null;
	}

	public string GetAreaName(int instance_id, int SubNpcgenIndex, REFERENCE_ENTRY reference)
	{
		string areaName = GetAreaName(GetNpcGenByInstanceID(instance_id, SubNpcgenIndex), reference);
		GC.KeepAlive(this);
		return areaName;
	}

	public void CreateReferences(ELEMENTS_REFERENCES References)
	{
		References.NewRefs(ReferenceType.NPCGEN_MONSTERS);
		References.NewRefs(ReferenceType.NPCGEN_NPCS);
		References.NewRefs(ReferenceType.NPCGEN_MINES);
		Dictionary<string, NPCGEN_PW> npcGens = NpcGens;
		if (npcGens != null && npcGens.Count != 0)
		{
			Dictionary<string, NPCGEN_PW>.ValueCollection.Enumerator enumerator = NpcGens.Values.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					NPCGEN_PW current = enumerator.Current;
					current.CreateReferences(ref References);
					List<NPCGEN_PW> subNpcgens = current.SubNpcgens;
					if (subNpcgens == null)
					{
						continue;
					}
					List<NPCGEN_PW>.Enumerator enumerator2 = subNpcgens.GetEnumerator();
					if (enumerator2.MoveNext())
					{
						do
						{
							enumerator2.Current.CreateReferences(ref References);
						}
						while (enumerator2.MoveNext());
					}
				}
				while (enumerator.MoveNext());
			}
			GC.KeepAlive(this);
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	public NPCGEN_PW GetNpcGenByInstanceID(int instance_id, int SubNpcgenIndex)
	{
		Dictionary<string, NPCGEN_PW> npcGens = NpcGens;
		if (npcGens != null && npcGens.Count != 0)
		{
			Dictionary<string, NPCGEN_PW>.Enumerator enumerator = NpcGens.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					NPCGEN_PW value = ((KeyValuePair<string, NPCGEN_PW>)(object)enumerator.Current).Value;
					if (value == null || value.InstanceID != instance_id)
					{
						continue;
					}
					if (SubNpcgenIndex > -1)
					{
						List<NPCGEN_PW> subNpcgens = value.SubNpcgens;
						if (subNpcgens != null && SubNpcgenIndex < subNpcgens.Count)
						{
							NPCGEN_PW result = value.SubNpcgens[SubNpcgenIndex];
							GC.KeepAlive(this);
							return result;
						}
					}
					GC.KeepAlive(this);
					return value;
				}
				while (enumerator.MoveNext());
			}
			return null;
		}
		GC.KeepAlive(this);
		return null;
	}
}
