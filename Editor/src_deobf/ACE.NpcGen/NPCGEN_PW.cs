using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using ACE.Classes;
using ACE.Classes.ACE;
using ACE.Models;
using ACE.RSGlobal;
using Sentry;

namespace ACE.NpcGen;

public class NPCGEN_PW
{
	public string MapTag;

	public int InstanceID;

	public string FileName;

	public bool FileLoaded;

	public bool FileChanged;

	public DateTime TimeChange;

	public int version;

	public int iNumAIGen;

	public int iNumResArea;

	public int iNumDynObj;

	public int iNumNPCCtrl;

	public AREA[] m_aAreas;

	public NPCGENFILERESAREA[] m_aResAreas;

	public List<NPCGEN_PW> SubNpcgens;

	public int NpcgenIndex = -1;

	public byte[] BytesAfterEndOfFile;

	public NPCGEN_PW(string fn)
	{
		Load(fn);
	}

	public int GetTotalCount(ref int MonsterCount, ref int NpcCount, ref int MineCount)
	{
		int num = (int)((nint)m_aAreas.LongLength - 1);
		if (num >= 0)
		{
			do
			{
				ref AREA reference = ref m_aAreas[num];
				if (reference.iNPCType == 0)
				{
					MonsterCount += reference.iNumGen;
				}
				else
				{
					NpcCount += reference.iNumGen;
				}
				num--;
			}
			while (num >= 0);
		}
		int num2 = (int)((nint)m_aResAreas.LongLength - 1);
		if (num2 >= 0)
		{
			do
			{
				MineCount += m_aResAreas[num2].iNumRes;
				num2--;
			}
			while (num2 >= 0);
		}
		return MonsterCount + NpcCount + MineCount;
	}

	public void Load(string fn)
	{
		if (!File.Exists(fn))
		{
			GC.KeepAlive(this);
			return;
		}
		EditorSessionTracker.LogFolderAccess(fn, Class16.smethod_0(1648903793), Class16.smethod_0(1648906400));
		FileName = fn;
		try
		{
			FileStream fileStream = new FileStream(fn, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
			try
			{
				BinaryReader binaryReader = new BinaryReader(fileStream);
				try
				{
					version = binaryReader.ReadInt32();
					iNumAIGen = binaryReader.ReadInt32();
					iNumResArea = binaryReader.ReadInt32();
					if (version >= 6)
					{
						iNumDynObj = binaryReader.ReadInt32();
					}
					if (version >= 7)
					{
						iNumNPCCtrl = binaryReader.ReadInt32();
					}
					m_aAreas = new AREA[iNumAIGen];
					for (int i = 0; i < iNumAIGen; i++)
					{
						AREA aREA = ReadAIGen(binaryReader);
						m_aAreas[i] = aREA;
					}
					m_aResAreas = new NPCGENFILERESAREA[iNumResArea];
					for (int j = 0; j < iNumResArea; j++)
					{
						NPCGENFILERESAREA nPCGENFILERESAREA = ReadResArea(binaryReader);
						m_aResAreas[j] = nPCGENFILERESAREA;
					}
					if (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
					{
						BinaryReader binaryReader2 = binaryReader;
						BytesAfterEndOfFile = binaryReader2.ReadBytes((int)(binaryReader2.BaseStream.Length - binaryReader.BaseStream.Position));
					}
					DateTime lastWriteTime = File.GetLastWriteTime(fn);
					TimeChange = lastWriteTime;
					FileLoaded = true;
				}
				finally
				{
					((IDisposable)binaryReader).Dispose();
				}
			}
			finally
			{
				((IDisposable)fileStream).Dispose();
			}
		}
		catch (EndOfStreamException)
		{
			SentryHelper.CaptureMessage(Class16.smethod_0(1649117382), (SentryLevel)2, Class16.smethod_0(1649117444));
		}
		catch (Exception ex2)
		{
			SentryHelper.CaptureException(ex2, Class16.smethod_0(1649117477));
		}
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFileChanged()
	{
		int num = ((FileLoaded && (FileChanged || IsFileOnDiscChanged())) ? 1 : 0);
		return (byte)num != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFileOnDiscChanged()
	{
		bool result = false;
		try
		{
			if (!string.IsNullOrWhiteSpace(FileName) && File.Exists(FileName))
			{
				DateTime lastWriteTime = File.GetLastWriteTime(FileName);
				result = !TimeChange.Equals(lastWriteTime);
			}
		}
		catch (UnauthorizedAccessException ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649117490));
		}
		catch (IOException ex2)
		{
			SentryHelper.CaptureException(ex2, Class16.smethod_0(1649117490));
		}
		GC.KeepAlive(this);
		return result;
	}

	public void Save()
	{
		if (string.IsNullOrWhiteSpace(FileName))
		{
			throw new InvalidOperationException(Class16.smethod_0(1649117534));
		}
		EditorSessionTracker.LogFolderAccess(FileName, Class16.smethod_0(1649006856), Class16.smethod_0(1648906400));
		string text = FileName + Class16.smethod_0(1648930786);
		try
		{
			FileStream fileStream = new FileStream(text, FileMode.Create, FileAccess.Write, FileShare.None);
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(fileStream);
				try
				{
					binaryWriter.Write(version);
					binaryWriter.Write(m_aAreas.Length);
					binaryWriter.Write(m_aResAreas.Length);
					if (version >= 6)
					{
						binaryWriter.Write(iNumDynObj);
					}
					if (version >= 7)
					{
						binaryWriter.Write(iNumNPCCtrl);
					}
					int num = 0;
					if (0 < (nint)m_aAreas.LongLength)
					{
						do
						{
							WriteAIGen(binaryWriter, m_aAreas[num]);
							num++;
						}
						while (num < (nint)m_aAreas.LongLength);
					}
					int num2 = 0;
					if (0 < (nint)m_aResAreas.LongLength)
					{
						do
						{
							WriteResArea(binaryWriter, m_aResAreas[num2]);
							num2++;
						}
						while (num2 < (nint)m_aResAreas.LongLength);
					}
					byte[] bytesAfterEndOfFile = BytesAfterEndOfFile;
					if (bytesAfterEndOfFile != null)
					{
						binaryWriter.Write(bytesAfterEndOfFile);
					}
				}
				finally
				{
					((IDisposable)binaryWriter).Dispose();
				}
			}
			finally
			{
				((IDisposable)fileStream).Dispose();
			}
			NpcGenFileHelper.ReplaceFileWithRetry(text, FileName);
			FileChanged = false;
			DateTime lastWriteTime = File.GetLastWriteTime(FileName);
			TimeChange = lastWriteTime;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649117583));
			try
			{
				if (File.Exists(text))
				{
					File.Delete(text);
				}
			}
			catch
			{
			}
			throw;
		}
		GC.KeepAlive(this);
	}

	public AREA ReadAIGen(BinaryReader br)
	{
		AREA result = default(AREA);
		result.iType = br.ReadInt32();
		result.iNumGen = br.ReadInt32();
		result.vPos = ReadFloat3(br);
		result.vDir = ReadFloat3(br);
		result.vExts = ReadFloat3(br);
		result.iNPCType = br.ReadInt32();
		result.iGroupType = br.ReadInt32();
		int count = ((version >= 7) ? 19 : 7);
		result.body = br.ReadBytes(count);
		result.m_aNPCGens = new NPCGENFILEAIGEN[result.iNumGen];
		byte[][] array = (result.m_aNPCGens_tail = new byte[result.iNumGen][]);
		int num = 0;
		int iNumGen = result.iNumGen;
		if (0 < iNumGen)
		{
			NPCGENFILEAIGEN[] aNPCGens = result.m_aNPCGens;
			do
			{
				NPCGENFILEAIGEN nPCGENFILEAIGEN = ACE.RSGlobal.RSGlobal.ReadStruct<NPCGENFILEAIGEN>(br);
				aNPCGens[num] = nPCGENFILEAIGEN;
				int count2 = ((version >= 11) ? 52 : 48);
				array[num] = br.ReadBytes(count2);
				num++;
			}
			while (num < iNumGen);
		}
		GC.KeepAlive(this);
		return result;
	}

	public float[] ReadFloat3(BinaryReader br)
	{
		float[] array = new float[3];
		int num = 0;
		do
		{
			array[num] = br.ReadSingle();
			num++;
		}
		while (num < 3);
		GC.KeepAlive(this);
		return array;
	}

	public void WriteAIGen(BinaryWriter bw, AREA area)
	{
		bw.Write(area.iType);
		bw.Write(area.iNumGen);
		WriteFloat3(bw, area.vPos);
		WriteFloat3(bw, area.vDir);
		WriteFloat3(bw, area.vExts);
		bw.Write(area.iNPCType);
		bw.Write(area.iGroupType);
		bw.Write(area.body);
		int num = 0;
		if (0 < area.iNumGen)
		{
			do
			{
				ACE.RSGlobal.RSGlobal.WriteStruct(bw, area.m_aNPCGens[num]);
				bw.Write(area.m_aNPCGens_tail[num]);
				num++;
			}
			while (num < area.iNumGen);
		}
		GC.KeepAlive(this);
	}

	public void WriteFloat3(BinaryWriter bw, float[] farr)
	{
		bw.Write(farr[0]);
		bw.Write(farr[1]);
		bw.Write(farr[2]);
		GC.KeepAlive(this);
	}

	public NPCGENFILERESAREA ReadResArea(BinaryReader br)
	{
		NPCGENFILERESAREA result = new NPCGENFILERESAREA
		{
			vPos = ReadFloat3(br),
			fExtX = br.ReadSingle(),
			fExtZ = br.ReadSingle(),
			iNumRes = br.ReadInt32()
		};
		int num = 7;
		int num2 = version;
		num = ((num2 >= 7) ? 18 : ((num2 >= 6) ? 10 : num));
		result.body = br.ReadBytes(num);
		NPCGENFILERES[] array = (result.m_aRes = new NPCGENFILERES[result.iNumRes]);
		int num3 = 0;
		int iNumRes = result.iNumRes;
		if (0 < iNumRes)
		{
			do
			{
				NPCGENFILERES nPCGENFILERES = ACE.RSGlobal.RSGlobal.ReadStruct<NPCGENFILERES>(br);
				array[num3] = nPCGENFILERES;
				num3++;
			}
			while (num3 < iNumRes);
		}
		GC.KeepAlive(this);
		return result;
	}

	public void WriteResArea(BinaryWriter bw, NPCGENFILERESAREA resArea)
	{
		WriteFloat3(bw, resArea.vPos);
		bw.Write(resArea.fExtX);
		bw.Write(resArea.fExtZ);
		bw.Write(resArea.iNumRes);
		bw.Write(resArea.body);
		int num = 0;
		if (0 < resArea.iNumRes)
		{
			do
			{
				ACE.RSGlobal.RSGlobal.WriteStruct(bw, resArea.m_aRes[num]);
				num++;
			}
			while (num < resArea.iNumRes);
		}
		GC.KeepAlive(this);
	}

	public void CreateReferences(ref ELEMENTS_REFERENCES References)
	{
		if (!FileLoaded)
		{
			return;
		}
		int num = (int)((nint)m_aAreas.LongLength - 1);
		if (num >= 0)
		{
			INDICES ind = default(INDICES);
			do
			{
				ref AREA reference = ref m_aAreas[num];
				ReferenceType key = ((reference.iNPCType == 0) ? ReferenceType.NPCGEN_MONSTERS : ReferenceType.NPCGEN_NPCS);
				ELEMENTS_IDS_REFERENCES eLEMENTS_IDS_REFERENCES = References.ReferencesExtra[key];
				int num2 = 0;
				NPCGENFILEAIGEN[] aNPCGens = reference.m_aNPCGens;
				if (0 < (nint)aNPCGens.LongLength)
				{
					do
					{
						ref NPCGENFILEAIGEN reference2 = ref aNPCGens[num2];
						ind.int_0 = num;
						ind.int_1 = num2;
						eLEMENTS_IDS_REFERENCES.AddRef(ReferenceSubType.NPCGEN, InstanceID, NpcgenIndex, reference2, ind, reference.vPos, num, reference2.dwID, reference2.dwNum, reference2.iRefresh);
						num2++;
						aNPCGens = reference.m_aNPCGens;
					}
					while (num2 < (nint)aNPCGens.LongLength);
				}
				num--;
			}
			while (num >= 0);
		}
		ELEMENTS_IDS_REFERENCES eLEMENTS_IDS_REFERENCES2 = References.ReferencesExtra[ReferenceType.NPCGEN_MINES];
		int num3 = (int)((nint)m_aResAreas.LongLength - 1);
		if (num3 >= 0)
		{
			INDICES ind2 = default(INDICES);
			do
			{
				ref NPCGENFILERESAREA reference3 = ref m_aResAreas[num3];
				int num4 = 0;
				NPCGENFILERES[] aRes = reference3.m_aRes;
				if (0 < (nint)aRes.LongLength)
				{
					do
					{
						ref NPCGENFILERES reference4 = ref aRes[num4];
						ind2.int_0 = num3;
						ind2.int_1 = num4;
						eLEMENTS_IDS_REFERENCES2.AddRef(ReferenceSubType.NPCGEN, InstanceID, NpcgenIndex, reference4, ind2, reference3.vPos, num3, reference4.idTemplate, reference4.dwNumber, reference4.dwRefreshTime);
						num4++;
						aRes = reference3.m_aRes;
					}
					while (num4 < (nint)aRes.LongLength);
				}
				num3--;
			}
			while (num3 >= 0);
		}
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool ChangeValueFromReference(REFERENCE_TYPE_EX RefType, ref REFERENCE_ENTRY reference, int new_id, string val1, string val2)
	{
		ref INDICES indices = ref reference.indices;
		object obj = null;
		object obj2 = null;
		if (val1 != null)
		{
			obj = int.Parse(val1);
		}
		if (val2 != null)
		{
			obj2 = int.Parse(val2);
		}
		switch (RefType.SectionType)
		{
		case ReferenceType.NPCGEN_MINES:
		{
			ref NPCGENFILERES reference3 = ref m_aResAreas[indices.int_0].m_aRes[indices.int_1];
			if (new_id > -1)
			{
				reference3.idTemplate = new_id;
			}
			if (obj != null)
			{
				reference3.dwNumber = (int)obj;
			}
			if (obj2 != null)
			{
				reference3.dwRefreshTime = (int)obj2;
			}
			break;
		}
		case ReferenceType.NPCGEN_NPCS:
		case ReferenceType.NPCGEN_MONSTERS:
		{
			ref NPCGENFILEAIGEN reference2 = ref m_aAreas[indices.int_0].m_aNPCGens[indices.int_1];
			if (new_id > -1)
			{
				reference2.dwID = new_id;
			}
			if (obj != null)
			{
				reference2.dwNum = (int)obj;
			}
			if (obj2 != null)
			{
				reference2.iRefresh = (int)obj2;
			}
			break;
		}
		}
		if (obj != null)
		{
			reference.extra_value1 = obj;
		}
		if (obj2 != null)
		{
			reference.extra_value2 = obj2;
		}
		FileChanged = true;
		return true;
	}
}
