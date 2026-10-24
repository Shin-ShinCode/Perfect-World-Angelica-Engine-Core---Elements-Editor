using System;
using System.Drawing;
using System.IO;
using ACE.Classes;
using ACE.RSGlobal;

namespace ACE.NpcGen;

public class NPCGen_FW
{
	public string fn;

	public bool FileLoaded;

	public int version;

	public int iNumAIGen;

	public int iNumResArea;

	public int iNumDynObj;

	public int iNumNPCCtrl;

	public int iNumFlyArea;

	public int iNumMineralCube;

	public int iNumMineralSphere;

	public int export_time;

	public short export_vss_name;

	public short export_computer_name;

	public byte[] unknown1;

	public ExportInfo exportInfo;

	public NpcsArea[] AIGens;

	public ResArea[] ResAreas;

	public DynObj[] DynObjs;

	public NPCCtrl[] Triggers;

	public FlyArea[] FlyAreas;

	public uint m_nCopy;

	public uint m_nFlyCopy;

	public byte[] BytesAfterEndOfFile;

	public NPCGen_FW(string fn)
	{
		FileLoaded = false;
		Load(fn);
	}

	public NPCGen_FW()
	{
		FileLoaded = false;
	}

	public void Save()
	{
		if (string.IsNullOrWhiteSpace(fn))
		{
			throw new InvalidOperationException("O caminho do arquivo NPCGen não está definido.");
		}
		if (AIGens == null || ResAreas == null || DynObjs == null || Triggers == null || FlyAreas == null)
		{
			throw new InvalidDataException("Os dados NPCGen não foram carregados completamente; o arquivo não foi salvo.");
		}
		File.Copy(fn, fn + Class16.smethod_0(1648898363), overwrite: true);
		string fullPath = System.IO.Path.GetFullPath(fn);
		string temporaryFileName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(fullPath), System.IO.Path.GetFileName(fullPath) + "." + Guid.NewGuid().ToString("N") + ".tmp");
		try
		{
			using (FileStream fileStream = new FileStream(temporaryFileName, FileMode.CreateNew, FileAccess.Write, FileShare.None))
			using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
			{
				binaryWriter.Write(CommonStorage.ValidateValue(version));
				binaryWriter.Write(CommonStorage.ValidateValue(AIGens.Length));
				binaryWriter.Write(ResAreas.Length);
				if (version >= 6)
				{
					binaryWriter.Write(DynObjs.Length);
				}
				if (version >= 7)
				{
					binaryWriter.Write(Triggers.Length);
				}
				if (version >= 16)
				{
					binaryWriter.Write(FlyAreas.Length);
				}
				if (version == 16)
				{
					binaryWriter.Write(iNumMineralCube);
					binaryWriter.Write(iNumMineralSphere);
				}
				if (version == 22 || version >= 23)
				{
					ACE.RSGlobal.RSGlobal.WriteStruct(binaryWriter, exportInfo);
					if (version >= 23)
					{
						ACE.RSGlobal.RSGlobal.WriteStruct(binaryWriter, exportInfo);
					}
				}
				if (version >= 20)
				{
					binaryWriter.Write(m_nCopy);
					binaryWriter.Write(m_nFlyCopy);
				}
				WriteNpcsAndMonsters(binaryWriter);
				WriteResourses(binaryWriter);
				WriteDynobjects(binaryWriter);
				WriteControllers(binaryWriter);
				WriteFlyAreas(binaryWriter);
				if (BytesAfterEndOfFile != null)
				{
					binaryWriter.Write(BytesAfterEndOfFile);
				}
				binaryWriter.Flush();
				fileStream.Flush(true);
			}

			NPCGen_FW validation = new NPCGen_FW();
			validation.Load(temporaryFileName);
			if (!validation.FileLoaded || validation.version != version || validation.AIGens.Length != AIGens.Length || validation.ResAreas.Length != ResAreas.Length || validation.DynObjs.Length != DynObjs.Length || validation.Triggers.Length != Triggers.Length || validation.FlyAreas.Length != FlyAreas.Length)
			{
				throw new InvalidDataException("A validação após salvar o arquivo NPCGen não corresponde aos dados em memória.");
			}

			if (File.Exists(fullPath))
			{
				File.Replace(temporaryFileName, fullPath, null);
			}
			else
			{
				File.Move(temporaryFileName, fullPath);
			}
			GC.KeepAlive(this);
		}
		catch
		{
			try
			{
				if (File.Exists(temporaryFileName))
				{
					File.Delete(temporaryFileName);
				}
			}
			catch
			{
			}
			throw;
		}
	}

	public void WriteFlyAreas(BinaryWriter bw)
	{
		FlyArea[] flyAreas = FlyAreas;
		int num = 0;
		if (0 < (nint)flyAreas.LongLength)
		{
			do
			{
				flyAreas[num].Write(bw);
				num++;
			}
			while (num < (nint)flyAreas.LongLength);
		}
		GC.KeepAlive(this);
	}

	public void WriteControllers(BinaryWriter bw)
	{
		int num = 0;
		NPCCtrl[] triggers = Triggers;
		if (0 < (nint)triggers.LongLength)
		{
			do
			{
				triggers[num].Write(bw, version);
				num++;
				triggers = Triggers;
			}
			while (num < (nint)triggers.LongLength);
		}
		GC.KeepAlive(this);
	}

	public void WriteDynobjects(BinaryWriter bw)
	{
		int num = 0;
		DynObj[] dynObjs = DynObjs;
		if (0 < (nint)dynObjs.LongLength)
		{
			do
			{
				dynObjs[num].Write(bw, version);
				num++;
				dynObjs = DynObjs;
			}
			while (num < (nint)dynObjs.LongLength);
		}
		GC.KeepAlive(this);
	}

	public void WriteResourses(BinaryWriter bw)
	{
		int num = 0;
		ResArea[] resAreas = ResAreas;
		if (0 < (nint)resAreas.LongLength)
		{
			do
			{
				resAreas[num].Write(bw, version);
				num++;
				resAreas = ResAreas;
			}
			while (num < (nint)resAreas.LongLength);
		}
		GC.KeepAlive(this);
	}

	public void WriteNpcsAndMonsters(BinaryWriter bw)
	{
		int num = 0;
		NpcsArea[] aIGens = AIGens;
		if (0 < (nint)aIGens.LongLength)
		{
			do
			{
				bw.Write(aIGens[num].iType);
				bw.Write(CommonStorage.ValidateValue(AIGens[num].Gens.Length));
				ACE.RSGlobal.RSGlobal.WriteFloat3(bw, AIGens[num].vPos);
				ACE.RSGlobal.RSGlobal.WriteFloat3(bw, AIGens[num].vDir);
				ACE.RSGlobal.RSGlobal.WriteFloat3(bw, AIGens[num].vExts);
				bw.Write(AIGens[num].iNPCType);
				bw.Write(AIGens[num].iGroupType);
				bw.Write(AIGens[num].bInitGen);
				bw.Write(AIGens[num].bAutoRevive);
				bw.Write(AIGens[num].bValidOnce);
				bw.Write(AIGens[num].dwGenID);
				if (version >= 7)
				{
					bw.Write(AIGens[num].idCtrl);
					bw.Write(AIGens[num].iLifeTime);
					bw.Write(AIGens[num].iMaxNum);
				}
				if (version >= 12)
				{
					bw.Write(AIGens[num].dwExportID);
					bw.Write(AIGens[num].iAttachNum);
				}
				if (version >= 13)
				{
					bw.Write(AIGens[num].idBufRegion);
				}
				WriteGens(bw, AIGens[num].Gens);
				int num2 = 0;
				NpcsArea npcsArea = AIGens[num];
				if (0 < npcsArea.iAttachNum)
				{
					do
					{
						bw.Write(npcsArea.Attach[num2]);
						num2++;
						npcsArea = AIGens[num];
					}
					while (num2 < npcsArea.iAttachNum);
				}
				num++;
				aIGens = AIGens;
			}
			while (num < (nint)aIGens.LongLength);
		}
		GC.KeepAlive(this);
	}

	public void WriteGens(BinaryWriter bw, NpcGenEntry[] Gens)
	{
		int num = 0;
		if (0 < (nint)Gens.LongLength)
		{
			do
			{
				bw.Write(Gens[num].dwID);
				bw.Write(Gens[num].dwNum);
				bw.Write(Gens[num].dwRefresh);
				bw.Write(Gens[num].dwDiedTimes);
				bw.Write(Gens[num].dwAggressive);
				bw.Write(Gens[num].fOffsetWater);
				bw.Write(Gens[num].fOffsetTrn);
				bw.Write(Gens[num].dwFaction);
				bw.Write(Gens[num].dwFacHelper);
				bw.Write(Gens[num].dwFacAccept);
				bw.Write(Gens[num].bNeedHelp);
				bw.Write(Gens[num].bDefFaction);
				bw.Write(Gens[num].bDefFacHelper);
				bw.Write(Gens[num].bDefFacAccept);
				bw.Write(Gens[num].iPathID);
				bw.Write(Gens[num].iLoopType);
				bw.Write(Gens[num].iSpeedFlag);
				bw.Write(Gens[num].iDeadTime);
				num++;
			}
			while (num < (nint)Gens.LongLength);
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
		this.fn = fn;
		using (FileStream fileStream = File.OpenRead(fn))
		using (BinaryReader binaryReader = new BinaryReader(fileStream))
		{
			version = binaryReader.ReadInt32();
			if (version < 0)
			{
				throw new InvalidDataException("A versão do arquivo NPCGen não pode ser negativa.");
			}
			iNumAIGen = ReadValidatedCount(binaryReader, "áreas de NPC/monstros", 59);
			iNumResArea = ReadValidatedCount(binaryReader, "áreas de recursos", 31);
			if (version >= 6)
			{
				iNumDynObj = ReadValidatedCount(binaryReader, "objetos dinâmicos", 19);
			}
			if (version >= 7)
			{
				iNumNPCCtrl = ReadValidatedCount(binaryReader, "controladores de NPC", 195);
			}
			if (version >= 16)
			{
				iNumFlyArea = ReadValidatedCount(binaryReader, "áreas de voo", 12);
			}
			if (version == 16)
			{
				iNumMineralCube = ReadValidatedCount(binaryReader, "cubos minerais", 1);
				iNumMineralSphere = ReadValidatedCount(binaryReader, "esferas minerais", 1);
			}
			if (version == 22)
			{
				exportInfo = ACE.RSGlobal.RSGlobal.ReadStruct<ExportInfo>(binaryReader);
			}
			else if (version >= 23)
			{
				exportInfo = ACE.RSGlobal.RSGlobal.ReadStruct<ExportInfo>(binaryReader);
				exportInfo = ACE.RSGlobal.RSGlobal.ReadStruct<ExportInfo>(binaryReader);
			}
			if (version >= 20)
			{
				m_nCopy = binaryReader.ReadUInt32();
				m_nFlyCopy = binaryReader.ReadUInt32();
			}
			ValidateTopLevelCounts(binaryReader, iNumAIGen, iNumResArea, iNumDynObj, iNumNPCCtrl, iNumFlyArea, version);

			AIGens = new NpcsArea[iNumAIGen];
			for (int i = 0; i < iNumAIGen; i++)
			{
				AIGens[i] = ReadAIGen(binaryReader);
			}
			ResAreas = new ResArea[iNumResArea];
			for (int i = 0; i < iNumResArea; i++)
			{
				ResAreas[i] = ReadResArea(binaryReader);
			}
			DynObjs = new DynObj[iNumDynObj];
			for (int i = 0; i < iNumDynObj; i++)
			{
				DynObjs[i] = ReadDynObj(binaryReader);
			}
			Triggers = new NPCCtrl[iNumNPCCtrl];
			for (int i = 0; i < iNumNPCCtrl; i++)
			{
				Triggers[i] = ReadNPCCtrl(binaryReader);
			}
			FlyAreas = new FlyArea[iNumFlyArea];
			for (int i = 0; i < iNumFlyArea; i++)
			{
				FlyAreas[i] = ReadFlyArea(binaryReader);
			}
			if (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
			{
				BytesAfterEndOfFile = binaryReader.ReadBytes((int)(binaryReader.BaseStream.Length - binaryReader.BaseStream.Position));
			}
		}
		FileLoaded = true;
	}

	private static int ReadValidatedCount(BinaryReader reader, string sectionName, int minimumRecordSize)
	{
		int count = reader.ReadInt32();
		long minimumBytes = (long)count * minimumRecordSize;
		long remainingBytes = reader.BaseStream.Length - reader.BaseStream.Position;
		if (count < 0 || minimumRecordSize <= 0 || minimumBytes > remainingBytes)
		{
			throw new InvalidDataException(string.Format("A contagem '{0}' é inválida para o tamanho restante do arquivo.", sectionName));
		}
		return count;
	}

	private static void ValidateTopLevelCounts(BinaryReader reader, int npcCount, int resourceCount, int dynamicCount, int controllerCount, int flyAreaCount, int formatVersion)
	{
		long minimumNpcBytes = 59L + (formatVersion >= 7 ? 12L : 0L) + (formatVersion >= 12 ? 8L : 0L) + (formatVersion >= 13 ? 4L : 0L);
		long minimumResourceBytes = 31L + (formatVersion >= 6 ? 3L : 0L) + (formatVersion >= 7 ? 8L : 0L) + (formatVersion >= 12 ? 8L : 0L) + (formatVersion >= 17 ? 12L : 0L);
		long minimumDynamicBytes = 19L + (formatVersion >= 9 ? 1L : 0L) + (formatVersion >= 10 ? 4L : 0L) + (formatVersion >= 14 ? 1L : 0L) + (formatVersion >= 24 ? 4L : 0L);
		long minimumControllerBytes = 195L + (formatVersion >= 8 ? 4L : 0L) + (formatVersion >= 11 ? 1L : 0L) + (formatVersion >= 15 ? 8L : 0L);
		long requiredBytes = npcCount * minimumNpcBytes + resourceCount * minimumResourceBytes + dynamicCount * minimumDynamicBytes + controllerCount * minimumControllerBytes + flyAreaCount * 12L;
		long remainingBytes = reader.BaseStream.Length - reader.BaseStream.Position;
		if (requiredBytes > remainingBytes)
		{
			throw new InvalidDataException("As contagens das seções NPCGen excedem o conteúdo disponível no arquivo.");
		}
	}

	public void AddAIGen(int SourceIndex)
	{
		Array.Resize(ref AIGens, (int)((nint)AIGens.LongLength + 1));
		NpcsArea[] aIGens = AIGens;
		int num = (int)((nint)aIGens.LongLength - 1);
		aIGens[num] = AIGens[SourceIndex].Clone();
		GC.KeepAlive(this);
	}

	public void AddAIGen()
	{
		Array.Resize(ref AIGens, (int)((nint)AIGens.LongLength + 1));
		NpcsArea[] aIGens = AIGens;
		int num = (int)((nint)aIGens.LongLength - 1);
		aIGens[num] = new NpcsArea();
		NpcsArea[] aIGens2 = AIGens;
		aIGens2[(nint)aIGens2.LongLength - 1].vPos = new float[3];
		NpcsArea[] aIGens3 = AIGens;
		aIGens3[(nint)aIGens3.LongLength - 1].vDir = new float[3];
		NpcsArea[] aIGens4 = AIGens;
		aIGens4[(nint)aIGens4.LongLength - 1].vExts = new float[3];
		NpcsArea[] aIGens5 = AIGens;
		aIGens5[(nint)aIGens5.LongLength - 1].Attach = new int[0];
		NpcsArea[] aIGens6 = AIGens;
		aIGens6[(nint)aIGens6.LongLength - 1].Gens = new NpcGenEntry[1];
		NpcsArea[] aIGens7 = AIGens;
		aIGens7[(nint)aIGens7.LongLength - 1].Gens[0] = new NpcGenEntry();
	}

	public void DeleteAIGen(int Index)
	{
		NpcsArea[] aIGens = AIGens;
		NpcsArea[] array = new NpcsArea[(nint)aIGens.LongLength - 1];
		Array.Copy(aIGens, 0, array, 0, Index);
		NpcsArea[] aIGens2 = AIGens;
		Array.Copy(aIGens2, Index + 1, array, Index, (int)((nint)aIGens2.LongLength - Index - 1));
		AIGens = array;
	}

	public NpcsArea ReadAIGen(BinaryReader br)
	{
		NpcsArea npcsArea = new NpcsArea();
		npcsArea.iType = br.ReadInt32();
		npcsArea.iNumGen = ReadValidatedCount(br, "geradores em área de NPC", 60);
		npcsArea.vPos = ACE.RSGlobal.RSGlobal.ReadFloat3(br);
		npcsArea.vDir = ACE.RSGlobal.RSGlobal.ReadFloat3(br);
		npcsArea.vExts = ACE.RSGlobal.RSGlobal.ReadFloat3(br);
		npcsArea.iNPCType = br.ReadInt32();
		npcsArea.iGroupType = br.ReadInt32();
		npcsArea.bInitGen = br.ReadByte();
		npcsArea.bAutoRevive = br.ReadByte();
		npcsArea.bValidOnce = br.ReadByte();
		npcsArea.dwGenID = br.ReadInt32();
		if (version >= 7)
		{
			npcsArea.idCtrl = br.ReadInt32();
			npcsArea.iLifeTime = br.ReadInt32();
			npcsArea.iMaxNum = br.ReadInt32();
		}
		if (version >= 12)
		{
			npcsArea.dwExportID = br.ReadInt32();
			npcsArea.iAttachNum = ReadValidatedCount(br, "vínculos da área de NPC", 4);
		}
		if (version >= 13)
		{
			npcsArea.idBufRegion = br.ReadInt32();
		}
		int iNumGen = npcsArea.iNumGen;
		npcsArea.Gens = new NpcGenEntry[iNumGen];
		int num = 0;
		if (0 < iNumGen)
		{
			do
			{
				npcsArea.Gens[num] = ReadGen(br);
				num++;
			}
			while (num < npcsArea.iNumGen);
		}
		int iAttachNum = npcsArea.iAttachNum;
		int num2 = ((iAttachNum > -1) ? iAttachNum : 0);
		npcsArea.Attach = new int[num2];
		int num3 = 0;
		if (0 < iAttachNum)
		{
			do
			{
				npcsArea.Attach[num3] = br.ReadInt32();
				num3++;
			}
			while (num3 < npcsArea.iAttachNum);
		}
		GC.KeepAlive(this);
		return npcsArea;
	}

	public NpcGenEntry ReadGen(BinaryReader br)
	{
		NpcGenEntry npcGenEntry = new NpcGenEntry();
		npcGenEntry.dwID = br.ReadInt32();
		npcGenEntry.dwNum = br.ReadInt32();
		npcGenEntry.dwRefresh = br.ReadInt32();
		npcGenEntry.dwDiedTimes = br.ReadInt32();
		npcGenEntry.dwAggressive = br.ReadInt32();
		npcGenEntry.fOffsetWater = br.ReadSingle();
		npcGenEntry.fOffsetTrn = br.ReadSingle();
		npcGenEntry.dwFaction = br.ReadInt32();
		npcGenEntry.dwFacHelper = br.ReadInt32();
		npcGenEntry.dwFacAccept = br.ReadInt32();
		npcGenEntry.bNeedHelp = br.ReadByte();
		npcGenEntry.bDefFaction = br.ReadByte();
		npcGenEntry.bDefFacHelper = br.ReadByte();
		npcGenEntry.bDefFacAccept = br.ReadByte();
		npcGenEntry.iPathID = br.ReadInt32();
		npcGenEntry.iLoopType = br.ReadInt32();
		npcGenEntry.iSpeedFlag = br.ReadInt32();
		npcGenEntry.iDeadTime = br.ReadInt32();
		GC.KeepAlive(this);
		return npcGenEntry;
	}

	public ResArea ReadResArea(BinaryReader br)
	{
		ResArea resArea = new ResArea();
		resArea.vPos = ACE.RSGlobal.RSGlobal.ReadFloat3(br);
		resArea.fExtX = br.ReadSingle();
		resArea.fExtZ = br.ReadSingle();
		resArea.iNumRes = ReadValidatedCount(br, "recursos da área", 20);
		resArea.bInitGen = br.ReadByte();
		resArea.bAutoRevive = br.ReadByte();
		resArea.bValidOnce = br.ReadByte();
		resArea.dwGenID = br.ReadInt32();
		if (version >= 6)
		{
			resArea.dir = br.ReadBytes(2);
			resArea.rad = br.ReadByte();
		}
		if (version >= 7)
		{
			resArea.idCtrl = br.ReadInt32();
			resArea.iMaxNum = br.ReadInt32();
		}
		if (version >= 12)
		{
			resArea.dwExportID = br.ReadInt32();
			resArea.iAttachNum = ReadValidatedCount(br, "vínculos da área de recursos", 4);
		}
		if (version >= 17)
		{
			resArea.iType = br.ReadInt32();
			resArea.fExtY = br.ReadSingle();
			resArea.fRadius = br.ReadSingle();
		}
		int iNumRes = resArea.iNumRes;
		resArea.Reses = new ResEntry[iNumRes];
		int num = 0;
		if (0 < iNumRes)
		{
			do
			{
				resArea.Reses[num] = ReadRes(br);
				num++;
			}
			while (num < resArea.iNumRes);
		}
		int iAttachNum = resArea.iAttachNum;
		int num2 = ((iAttachNum > -1) ? iAttachNum : 0);
		resArea.Attach = new int[num2];
		int num3 = 0;
		if (0 < iAttachNum)
		{
			do
			{
				resArea.Attach[num3] = br.ReadInt32();
				num3++;
			}
			while (num3 < resArea.iAttachNum);
		}
		GC.KeepAlive(this);
		return resArea;
	}

	public ResEntry ReadRes(BinaryReader br)
	{
		ResEntry resEntry = new ResEntry();
		resEntry.iResType = br.ReadInt32();
		resEntry.idTemplate = br.ReadInt32();
		resEntry.dwRefreshTime = br.ReadInt32();
		resEntry.dwNumber = br.ReadInt32();
		resEntry.fHeiOff = br.ReadSingle();
		GC.KeepAlive(this);
		return resEntry;
	}

	public DynObj ReadDynObj(BinaryReader br)
	{
		DynObj dynObj = new DynObj();
		dynObj.dwDynObjID = br.ReadInt32();
		dynObj.vPos = ACE.RSGlobal.RSGlobal.ReadFloat3(br);
		dynObj.dir = br.ReadBytes(2);
		dynObj.rad = br.ReadByte();
		if (version >= 9)
		{
			dynObj.scale = br.ReadByte();
		}
		if (version >= 10)
		{
			dynObj.idController = br.ReadUInt32();
		}
		if (version >= 14)
		{
			dynObj.bBroadcast = br.ReadByte();
		}
		if (version >= 24)
		{
			dynObj.export_id = br.ReadUInt32();
		}
		GC.KeepAlive(this);
		return dynObj;
	}

	public NPCCtrl ReadNPCCtrl(BinaryReader br)
	{
		NPCCtrl nPCCtrl = new NPCCtrl();
		nPCCtrl.id = br.ReadInt32();
		nPCCtrl.iControllerID = br.ReadInt32();
		nPCCtrl.name = br.ReadBytes(128);
		byte b = ((br.ReadByte() != 0) ? ((byte)1) : ((byte)0));
		nPCCtrl.bActived = b != 0;
		nPCCtrl.iWaitTime = br.ReadInt32();
		nPCCtrl.iStopTime = br.ReadInt32();
		byte b2 = ((br.ReadByte() != 0) ? ((byte)1) : ((byte)0));
		nPCCtrl.bActiveTimeInvalid = b2 != 0;
		byte b3 = ((br.ReadByte() != 0) ? ((byte)1) : ((byte)0));
		nPCCtrl.bStopTimeInvalid = b3 != 0;
		nPCCtrl.Time1 = new Time(br);
		nPCCtrl.Time2 = new Time(br);
		if (version >= 8)
		{
			nPCCtrl.iActiveTimeRange = br.ReadInt32();
		}
		if (version >= 11)
		{
			byte b4 = ((br.ReadByte() != 0) ? ((byte)1) : ((byte)0));
			nPCCtrl.bRepeatActived = b4 != 0;
		}
		if (version >= 15)
		{
			nPCCtrl.mZoneMask = br.ReadInt64();
		}
		GC.KeepAlive(this);
		return nPCCtrl;
	}

	public FlyArea ReadFlyArea(BinaryReader br)
	{
		FlyArea flyArea = new FlyArea();
		int pointCount = br.ReadInt32();
		long remainingBytes = br.BaseStream.Length - br.BaseStream.Position;
		if (pointCount < 0 || remainingBytes < 8L || (long)pointCount * 8L > remainingBytes - 8L)
		{
			throw new InvalidDataException("A quantidade de pontos da área de voo é inválida para o conteúdo restante do arquivo.");
		}
		int num = (flyArea.iPointNum = pointCount);
		flyArea.Points = new PointF[num];
		int num2 = 0;
		if (0 < num)
		{
			do
			{
				flyArea.Points[num2].X = br.ReadSingle();
				flyArea.Points[num2].Y = br.ReadSingle();
				num2++;
			}
			while (num2 < flyArea.iPointNum);
		}
		flyArea.fHeight = br.ReadSingle();
		flyArea.iRequireLevel = br.ReadInt32();
		GC.KeepAlive(this);
		return flyArea;
	}

	public int AddTrigger(int SourceIndex)
	{
		NPCCtrl[] triggers = Triggers;
		int num = triggers[(nint)triggers.LongLength - 1].id;
		while (true)
		{
			num++;
			NPCCtrl[] triggers2 = Triggers;
			int num2 = 0;
			if (0 >= (nint)triggers2.LongLength)
			{
				break;
			}
			while (triggers2[num2].id != num)
			{
				num2++;
				if (num2 >= (nint)triggers2.LongLength)
				{
					goto end_IL_0034;
				}
			}
			continue;
			end_IL_0034:
			break;
		}
		Array.Resize(ref Triggers, (int)((nint)Triggers.LongLength + 1));
		NPCCtrl[] triggers3 = Triggers;
		int num3 = (int)((nint)triggers3.LongLength - 1);
		Triggers[num3] = triggers3[SourceIndex].Clone();
		Triggers[num3].id = num;
		GC.KeepAlive(this);
		return num3;
	}

	public void DeleteTrigger(int Index)
	{
		NPCCtrl[] triggers = Triggers;
		NPCCtrl[] array = new NPCCtrl[(nint)triggers.LongLength - 1];
		Array.Copy(triggers, 0, array, 0, Index);
		NPCCtrl[] triggers2 = Triggers;
		Array.Copy(triggers2, Index + 1, array, Index, (int)((nint)triggers2.LongLength - Index - 1));
		Triggers = array;
	}
}
