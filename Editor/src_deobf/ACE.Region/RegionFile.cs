using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ACE.Region;

public class RegionFile
{
	private uint uint_0 = 7u;

	private int int_0;

	private Encoding encoding_0;

	private List<CELTransportBox> list_0 = new List<CELTransportBox>();

	private List<RegionEntry> list_1 = new List<RegionEntry>();

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

	public List<CELTransportBox> teleports
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

	public List<RegionEntry> regions
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
		[CompilerGenerated]
		set
		{
			list_1 = value;
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

	public bool ReadFile(string path)
	{
		try
		{
			teleports = new List<CELTransportBox>();
			regions = new List<RegionEntry>();
			string empty = string.Empty;
			using (FileStream stream = File.OpenRead(path))
			{
				StreamReader streamReader = new StreamReader(stream);
				try
				{
					while ((empty = streamReader.ReadLine()) != null)
					{
						if (empty.Contains(Class16.smethod_0(1649074689)) && !empty.StartsWith(Class16.smethod_0(1648904229)))
						{
							encoding = streamReader.CurrentEncoding;
							dwVersion = uint.Parse(method_0(empty));
							dwTimeStamp = int.Parse(method_0(streamReader.ReadLine()));
						}
						if (empty.Contains(Class16.smethod_0(1649157232)) && !empty.StartsWith(Class16.smethod_0(1648904229)))
						{
							CELTransportBox cELTransportBox = new CELTransportBox();
							string[] array = streamReader.ReadLine().Split(new char[2] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
							int num = 0;
							cELTransportBox.m_idInst = int.Parse(method_0(array[0]));
							num = 1;
							if (dwVersion >= 3 && num < array.Length)
							{
								cELTransportBox.m_idSrcInst = int.Parse(method_0(array[num]));
								num++;
							}
							if (dwVersion >= 5 && num < array.Length)
							{
								cELTransportBox.m_iLevelLmt = int.Parse(method_0(array[num]));
								num++;
							}
							cELTransportBox.tm_vPos = new RegionVector3(streamReader.ReadLine(), ',');
							cELTransportBox.m_vExts = new RegionVector3(streamReader.ReadLine(), ',');
							cELTransportBox.m_vTarge = new RegionVector3(streamReader.ReadLine(), ',');
							teleports.Add(cELTransportBox);
						}
						if (empty.Contains(Class16.smethod_0(1649157254)) && !empty.StartsWith(Class16.smethod_0(1648904229)))
						{
							RegionEntry regionEntry = new RegionEntry();
							string name = streamReader.ReadLine().Replace('"', ' ').Trim();
							string[] array2 = streamReader.ReadLine().Split(new char[2] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
							regionEntry.name = name;
							regionEntry.Type = int.Parse(method_0(array2[0]));
							int num2 = int.Parse(method_0(array2[1]));
							regionEntry.Zones = new List<RegionVector3>();
							if (dwVersion > 5)
							{
								regionEntry.Strategy = int.Parse(method_0(streamReader.ReadLine()));
							}
							for (int i = 0; i < num2; i++)
							{
								regionEntry.Zones.Add(new RegionVector3(streamReader.ReadLine()));
							}
							regions.Add(regionEntry);
						}
					}
				}
				finally
				{
					((IDisposable)streamReader).Dispose();
				}
			}
			return true;
		}
		catch
		{
			return false;
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
			string path3 = empty.Replace(Class16.smethod_0(1649191156), Class16.smethod_0(1649191167));
			MemoryStream memoryStream = new MemoryStream();
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				try
				{
					binaryWriter.Write(dwVersion);
					binaryWriter.Write(regions.Count);
					if (dwVersion >= 2)
					{
						binaryWriter.Write(teleports.Count);
					}
					if (dwVersion >= 4)
					{
						binaryWriter.Write(dwTimeStamp);
					}
					foreach (RegionEntry region in regions)
					{
						binaryWriter.Write(region.Type);
						binaryWriter.Write(region.ZoneCount);
						for (int i = 0; i < region.ZoneCount; i++)
						{
							region.Zones[i].Write(binaryWriter);
						}
					}
					foreach (CELTransportBox teleport in teleports)
					{
						binaryWriter.Write(teleport.m_iType);
						binaryWriter.Write(teleport.m_idInst);
						if (dwVersion >= 3)
						{
							binaryWriter.Write(teleport.m_idSrcInst);
						}
						if (dwVersion >= 5)
						{
							binaryWriter.Write(teleport.m_iLevelLmt);
						}
						teleport.tm_vPos.Write(binaryWriter);
						teleport.m_vExts.Write(binaryWriter);
						teleport.m_vTarge.Write(binaryWriter);
					}
					File.WriteAllBytes(path3, memoryStream.ToArray());
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
			StringBuilder stringBuilder = new StringBuilder(Class16.smethod_0(1649157269));
			stringBuilder.AppendLine();
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(Class16.smethod_0(1649191219) + dwVersion);
			stringBuilder.AppendLine(dwTimeStamp.ToString());
			stringBuilder.AppendLine();
			foreach (RegionEntry region2 in regions)
			{
				stringBuilder.AppendLine(Class16.smethod_0(1649157254));
				stringBuilder.AppendLine(Class16.smethod_0(1648904453) + region2.name + Class16.smethod_0(1648904453));
				stringBuilder.AppendLine(region2.Type + Class16.smethod_0(1649043292) + region2.ZoneCount);
				if (dwVersion > 5)
				{
					stringBuilder.AppendLine(region2.Strategy.ToString());
				}
				for (int j = 0; j < region2.ZoneCount; j++)
				{
					stringBuilder.AppendLine(region2.Zones[j].ToStringSpaced());
				}
				stringBuilder.AppendLine();
			}
			foreach (CELTransportBox teleport2 in teleports)
			{
				stringBuilder.AppendLine(Class16.smethod_0(1649157232));
				stringBuilder.AppendLine(teleport2.m_idInst + Class16.smethod_0(1649043292) + teleport2.m_idSrcInst + Class16.smethod_0(1649043292) + teleport2.m_iLevelLmt);
				stringBuilder.AppendLine(teleport2.tm_vPos.ToStringComma());
				stringBuilder.AppendLine(teleport2.m_vExts.ToStringComma());
				stringBuilder.AppendLine(teleport2.m_vTarge.ToStringComma());
				stringBuilder.AppendLine();
			}
			stringBuilder.AppendLine();
			if (encoding == null)
			{
				encoding = Encoding.UTF8;
			}
			File.WriteAllText(path, stringBuilder.ToString(), encoding);
			return true;
		}
		catch
		{
			return false;
		}
	}
}
