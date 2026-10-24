using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ACE.Classes;
using Sentry;

namespace ACE.NpcGen.Classes;

internal class NpcGen
{
	public List<ClassDynamicObject> DynamicsList = new List<ClassDynamicObject>();

	public int DynobjectAmount;

	public int File_version;

	public List<ClassDefaultMonsters> NpcMobList = new List<ClassDefaultMonsters>();

	public int NpcMobsAmount;

	public int ResourcesAmount;

	public List<ClassDefaultResources> ResourcesList = new List<ClassDefaultResources>();

	public int TriggersAmount;

	public List<ClassTrigger> TriggersList = new List<ClassTrigger>();

	public void ExportDynamics(string Path, List<int> SelectedDynamics)
	{
		EditorSessionTracker.LogFolderAccess(Path, Class16.smethod_0(1649006856), Class16.smethod_0(1648906400));
		BinaryWriter binaryWriter = new BinaryWriter(File.Create(Path));
		binaryWriter.Write(Class16.smethod_0(1649115458));
		binaryWriter.Write(SelectedDynamics.Count);
		foreach (int SelectedDynamic in SelectedDynamics)
		{
			WriteDynamic(binaryWriter, 15, SelectedDynamic);
		}
		binaryWriter.Close();
	}

	public void ExportExistence(string Path, List<int> SelectedExistence)
	{
		EditorSessionTracker.LogFolderAccess(Path, Class16.smethod_0(1649006856), Class16.smethod_0(1648906400));
		BinaryWriter binaryWriter = new BinaryWriter(File.Create(Path));
		binaryWriter.Write(Class16.smethod_0(1649115489));
		binaryWriter.Write(SelectedExistence.Count);
		foreach (int item in SelectedExistence)
		{
			WriteExistence(binaryWriter, 15, item);
		}
		binaryWriter.Close();
	}

	public void ExportResource(string Path, List<int> SelectedResources)
	{
		EditorSessionTracker.LogFolderAccess(Path, Class16.smethod_0(1649006856), Class16.smethod_0(1648906400));
		BinaryWriter binaryWriter = new BinaryWriter(File.Create(Path));
		binaryWriter.Write(Class16.smethod_0(1649115520));
		binaryWriter.Write(SelectedResources.Count);
		foreach (int SelectedResource in SelectedResources)
		{
			WriteResource(binaryWriter, 15, SelectedResource);
		}
		binaryWriter.Close();
	}

	public void ExportTriggers(string Path, List<int> SelectedTriggers)
	{
		EditorSessionTracker.LogFolderAccess(Path, Class16.smethod_0(1649006856), Class16.smethod_0(1648906400));
		BinaryWriter binaryWriter = new BinaryWriter(File.Create(Path));
		binaryWriter.Write(Class16.smethod_0(1649115559));
		binaryWriter.Write(SelectedTriggers.Count);
		foreach (int SelectedTrigger in SelectedTriggers)
		{
			WriteTrigger(binaryWriter, 15, SelectedTrigger);
		}
		binaryWriter.Close();
	}

	public byte[] GetBytes(string Name, int NameLength, Encoding encoding_0)
	{
		Name = Name.Split(default(char))[0];
		byte[] array = new byte[NameLength];
		if (encoding_0.GetByteCount(Name) > NameLength)
		{
			Array.Copy(encoding_0.GetBytes(Name), 0, array, 0, NameLength);
		}
		else
		{
			Array.Copy(encoding_0.GetBytes(Name), array, encoding_0.GetByteCount(Name));
		}
		return array;
	}

	public ClassDynamicObject ReadDynObjects(BinaryReader br, int Version)
	{
		ClassDynamicObject classDynamicObject = new ClassDynamicObject();
		classDynamicObject.Id = br.ReadInt32();
		classDynamicObject.X_position = br.ReadSingle();
		classDynamicObject.Y_position = br.ReadSingle();
		classDynamicObject.Z_position = br.ReadSingle();
		classDynamicObject.InCline1 = br.ReadByte();
		classDynamicObject.InCline2 = br.ReadByte();
		classDynamicObject.Rotation = br.ReadByte();
		classDynamicObject.TriggerId = br.ReadInt32();
		classDynamicObject.Scale = br.ReadByte();
		return classDynamicObject;
	}

	public ClassDefaultMonsters ReadExistence(BinaryReader br, int Version)
	{
		ClassDefaultMonsters classDefaultMonsters = new ClassDefaultMonsters();
		classDefaultMonsters.Location = br.ReadInt32();
		classDefaultMonsters.Amount_in_group = br.ReadInt32();
		classDefaultMonsters.X_position = br.ReadSingle();
		classDefaultMonsters.Y_position = br.ReadSingle();
		classDefaultMonsters.Z_position = br.ReadSingle();
		classDefaultMonsters.X_direction = br.ReadSingle();
		classDefaultMonsters.Y_direction = br.ReadSingle();
		classDefaultMonsters.Z_direction = br.ReadSingle();
		classDefaultMonsters.X_random = br.ReadSingle();
		classDefaultMonsters.Y_random = br.ReadSingle();
		classDefaultMonsters.Z_random = br.ReadSingle();
		classDefaultMonsters.Type = br.ReadInt32();
		classDefaultMonsters.iGroupType = br.ReadInt32();
		classDefaultMonsters.BInitGen = br.ReadByte();
		classDefaultMonsters.bAutoRevive = br.ReadByte();
		classDefaultMonsters.BValicOnce = br.ReadByte();
		classDefaultMonsters.dwGenId = br.ReadInt32();
		if (Version > 6)
		{
			classDefaultMonsters.Trigger_id = br.ReadInt32();
			classDefaultMonsters.Life_time = br.ReadInt32();
			classDefaultMonsters.MaxRespawnTime = br.ReadInt32();
		}
		classDefaultMonsters.MobDops = new List<ClassExtraMonsters>(Math.Max(0, classDefaultMonsters.Amount_in_group));
		for (int i = 0; i < classDefaultMonsters.Amount_in_group; i++)
		{
			ClassExtraMonsters classExtraMonsters = new ClassExtraMonsters();
			classExtraMonsters.Id = br.ReadInt32();
			classExtraMonsters.Amount = br.ReadInt32();
			classExtraMonsters.Respawn = br.ReadInt32();
			classExtraMonsters.Dead_amount = br.ReadInt32();
			classExtraMonsters.Agression = br.ReadInt32();
			classExtraMonsters.fOffsetWater = br.ReadSingle();
			classExtraMonsters.fOffsetTrn = br.ReadSingle();
			classExtraMonsters.Group = br.ReadInt32();
			classExtraMonsters.Group_help_sender = br.ReadInt32();
			classExtraMonsters.Group_help_Needer = br.ReadInt32();
			classExtraMonsters.bNeedHelp = br.ReadByte();
			classExtraMonsters.bFaction = br.ReadByte();
			classExtraMonsters.bFac_Helper = br.ReadByte();
			classExtraMonsters.bFac_Accept = br.ReadByte();
			classExtraMonsters.Path = br.ReadInt32();
			classExtraMonsters.Path_type = br.ReadInt32();
			classExtraMonsters.Speed = br.ReadInt32();
			classExtraMonsters.Dead_time = br.ReadInt32();
			if (Version >= 11)
			{
				classExtraMonsters.RefreshLower = br.ReadInt32();
			}
			classDefaultMonsters.MobDops.Add(classExtraMonsters);
		}
		return classDefaultMonsters;
	}

	public void ReadNpcgen(BinaryReader br)
	{
		try
		{
			File_version = br.ReadInt32();
			NpcMobsAmount = br.ReadInt32();
			ResourcesAmount = br.ReadInt32();
			DynobjectAmount = br.ReadInt32();
			if (File_version > 6)
			{
				TriggersAmount = br.ReadInt32();
			}
			for (int i = 0; i < NpcMobsAmount; i++)
			{
				NpcMobList.Add(ReadExistence(br, File_version));
			}
			for (int j = 0; j < ResourcesAmount; j++)
			{
				ResourcesList.Add(ReadResource(br, File_version));
			}
			for (int k = 0; k < DynobjectAmount; k++)
			{
				DynamicsList.Add(ReadDynObjects(br, File_version));
			}
			if (File_version > 6)
			{
				for (int l = 0; l < TriggersAmount; l++)
				{
					TriggersList.Add(ReadTrigger(br, File_version));
				}
			}
		}
		catch (EndOfStreamException ex)
		{
			DKBox.Show(Class16.smethod_0(1649115590) + ex.Message, Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		catch (ArgumentOutOfRangeException ex2)
		{
			SentryHelper.CaptureMessage(Class16.smethod_0(1649115640) + ex2.Message, (SentryLevel)2, Class16.smethod_0(1649118764));
			DKBox.Show(Class16.smethod_0(1649118792) + ex2.Message, Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public ClassDefaultResources ReadResource(BinaryReader br, int Version)
	{
		ClassDefaultResources classDefaultResources = new ClassDefaultResources();
		classDefaultResources.X_position = br.ReadSingle();
		classDefaultResources.Y_position = br.ReadSingle();
		classDefaultResources.Z_position = br.ReadSingle();
		classDefaultResources.X_Random = br.ReadSingle();
		classDefaultResources.Z_Random = br.ReadSingle();
		classDefaultResources.Amount_in_group = br.ReadInt32();
		classDefaultResources.bInitGen = br.ReadByte();
		classDefaultResources.bAutoRevive = br.ReadByte();
		classDefaultResources.bValidOnce = br.ReadByte();
		classDefaultResources.dwGenID = br.ReadInt32();
		classDefaultResources.InCline1 = br.ReadByte();
		classDefaultResources.InCline2 = br.ReadByte();
		classDefaultResources.Rotation = br.ReadByte();
		classDefaultResources.Trigger_id = br.ReadInt32();
		classDefaultResources.IMaxNum = br.ReadInt32();
		classDefaultResources.ResExtra = new List<ClassExtraResources>();
		for (int i = 0; i < classDefaultResources.Amount_in_group; i++)
		{
			ClassExtraResources classExtraResources = new ClassExtraResources();
			classExtraResources.ResourceType = br.ReadInt32();
			classExtraResources.Id = br.ReadInt32();
			classExtraResources.Respawntime = br.ReadInt32();
			classExtraResources.Amount = br.ReadInt32();
			classExtraResources.fHeiOff = br.ReadSingle();
			classDefaultResources.ResExtra.Add(classExtraResources);
		}
		return classDefaultResources;
	}

	public ClassTrigger ReadTrigger(BinaryReader br, int Version)
	{
		ClassTrigger classTrigger = new ClassTrigger();
		classTrigger.Id = br.ReadInt32();
		classTrigger.GmID = br.ReadInt32();
		classTrigger.TriggerName = Encoding.GetEncoding(936).GetString(br.ReadBytes(128)).TrimEnd(default(char));
		classTrigger.AutoStart = br.ReadByte();
		classTrigger.WaitWhileStart = br.ReadInt32();
		classTrigger.WaitWhileStop = br.ReadInt32();
		classTrigger.DontStartOnSchedule = br.ReadByte();
		if (classTrigger.DontStartOnSchedule == 0)
		{
			classTrigger.DontStartOnSchedule = 1;
		}
		else if (classTrigger.DontStartOnSchedule == 1)
		{
			classTrigger.DontStartOnSchedule = 0;
		}
		classTrigger.DontStopOnSchedule = br.ReadByte();
		if (classTrigger.DontStopOnSchedule == 1)
		{
			classTrigger.DontStopOnSchedule = 0;
		}
		else if (classTrigger.DontStopOnSchedule == 0)
		{
			classTrigger.DontStopOnSchedule = 1;
		}
		classTrigger.StartYear = br.ReadInt32();
		classTrigger.StartMonth = br.ReadInt32();
		classTrigger.StartWeekDay = br.ReadInt32();
		classTrigger.StartDay = br.ReadInt32();
		classTrigger.StartHour = br.ReadInt32();
		classTrigger.StartMinute = br.ReadInt32();
		classTrigger.StopYear = br.ReadInt32();
		classTrigger.StopMonth = br.ReadInt32();
		classTrigger.StopWeekDay = br.ReadInt32();
		classTrigger.StopDay = br.ReadInt32();
		classTrigger.StopHour = br.ReadInt32();
		classTrigger.StopMinute = br.ReadInt32();
		if (File_version > 7)
		{
			classTrigger.Duration = br.ReadInt32();
		}
		return classTrigger;
	}

	public void WriteDynamic(BinaryWriter bw, int Version, int int_0)
	{
		bw.Write(DynamicsList[int_0].Id);
		bw.Write(DynamicsList[int_0].X_position);
		bw.Write(DynamicsList[int_0].Y_position);
		bw.Write(DynamicsList[int_0].Z_position);
		bw.Write(DynamicsList[int_0].InCline1);
		bw.Write(DynamicsList[int_0].InCline2);
		bw.Write(DynamicsList[int_0].Rotation);
		bw.Write(DynamicsList[int_0].TriggerId);
		bw.Write(DynamicsList[int_0].Scale);
	}

	public void WriteExistence(BinaryWriter bw, int Version, int int_0)
	{
		bw.Write(NpcMobList[int_0].Location);
		bw.Write(NpcMobList[int_0].Amount_in_group);
		bw.Write(NpcMobList[int_0].X_position);
		bw.Write(NpcMobList[int_0].Y_position);
		bw.Write(NpcMobList[int_0].Z_position);
		bw.Write(NpcMobList[int_0].X_direction);
		bw.Write(NpcMobList[int_0].Y_direction);
		bw.Write(NpcMobList[int_0].Z_direction);
		bw.Write(NpcMobList[int_0].X_random);
		bw.Write(NpcMobList[int_0].Y_random);
		bw.Write(NpcMobList[int_0].Z_random);
		bw.Write(NpcMobList[int_0].Type);
		bw.Write(NpcMobList[int_0].iGroupType);
		bw.Write(NpcMobList[int_0].BInitGen);
		bw.Write(NpcMobList[int_0].bAutoRevive);
		bw.Write(NpcMobList[int_0].BValicOnce);
		bw.Write(NpcMobList[int_0].dwGenId);
		if (Version > 6)
		{
			bw.Write(NpcMobList[int_0].Trigger_id);
			bw.Write(NpcMobList[int_0].Life_time);
			bw.Write(NpcMobList[int_0].MaxRespawnTime);
		}
		for (int i = 0; i < NpcMobList[int_0].Amount_in_group; i++)
		{
			bw.Write(NpcMobList[int_0].MobDops[i].Id);
			bw.Write(NpcMobList[int_0].MobDops[i].Amount);
			bw.Write(NpcMobList[int_0].MobDops[i].Respawn);
			bw.Write(NpcMobList[int_0].MobDops[i].Dead_amount);
			bw.Write(NpcMobList[int_0].MobDops[i].Agression);
			bw.Write(NpcMobList[int_0].MobDops[i].fOffsetWater);
			bw.Write(NpcMobList[int_0].MobDops[i].fOffsetTrn);
			bw.Write(NpcMobList[int_0].MobDops[i].Group);
			bw.Write(NpcMobList[int_0].MobDops[i].Group_help_sender);
			bw.Write(NpcMobList[int_0].MobDops[i].Group_help_Needer);
			bw.Write(NpcMobList[int_0].MobDops[i].bNeedHelp);
			bw.Write(NpcMobList[int_0].MobDops[i].bFaction);
			bw.Write(NpcMobList[int_0].MobDops[i].bFac_Helper);
			bw.Write(NpcMobList[int_0].MobDops[i].bFac_Accept);
			bw.Write(NpcMobList[int_0].MobDops[i].Path);
			bw.Write(NpcMobList[int_0].MobDops[i].Path_type);
			bw.Write(NpcMobList[int_0].MobDops[i].Speed);
			bw.Write(NpcMobList[int_0].MobDops[i].Dead_time);
			if (Version >= 11)
			{
				bw.Write(NpcMobList[int_0].MobDops[i].RefreshLower);
			}
		}
	}

	public void WriteNpcgen(BinaryWriter bw, int Version)
	{
		bw.Write(Version);
		bw.Write(NpcMobsAmount);
		bw.Write(ResourcesAmount);
		bw.Write(DynobjectAmount);
		if (Version > 6)
		{
			bw.Write(TriggersAmount);
		}
		for (int i = 0; i < NpcMobsAmount; i++)
		{
			WriteExistence(bw, Version, i);
		}
		for (int j = 0; j < ResourcesAmount; j++)
		{
			WriteResource(bw, Version, j);
		}
		for (int k = 0; k < DynobjectAmount; k++)
		{
			WriteDynamic(bw, Version, k);
		}
		if (Version > 6)
		{
			for (int l = 0; l < TriggersAmount; l++)
			{
				WriteTrigger(bw, Version, l);
			}
		}
	}

	public void WriteResource(BinaryWriter bw, int Version, int int_0)
	{
		bw.Write(ResourcesList[int_0].X_position);
		bw.Write(ResourcesList[int_0].Y_position);
		bw.Write(ResourcesList[int_0].Z_position);
		bw.Write(ResourcesList[int_0].X_Random);
		bw.Write(ResourcesList[int_0].Z_Random);
		bw.Write(ResourcesList[int_0].Amount_in_group);
		bw.Write(ResourcesList[int_0].bInitGen);
		bw.Write(ResourcesList[int_0].bAutoRevive);
		bw.Write(ResourcesList[int_0].bValidOnce);
		bw.Write(ResourcesList[int_0].dwGenID);
		bw.Write(ResourcesList[int_0].InCline1);
		bw.Write(ResourcesList[int_0].InCline2);
		bw.Write(ResourcesList[int_0].Rotation);
		bw.Write(ResourcesList[int_0].Trigger_id);
		bw.Write(ResourcesList[int_0].IMaxNum);
		for (int i = 0; i < ResourcesList[int_0].Amount_in_group; i++)
		{
			bw.Write(ResourcesList[int_0].ResExtra[i].ResourceType);
			bw.Write(ResourcesList[int_0].ResExtra[i].Id);
			bw.Write(ResourcesList[int_0].ResExtra[i].Respawntime);
			bw.Write(ResourcesList[int_0].ResExtra[i].Amount);
			bw.Write(ResourcesList[int_0].ResExtra[i].fHeiOff);
		}
	}

	public void WriteTrigger(BinaryWriter bw, int Version, int int_0)
	{
		bw.Write(TriggersList[int_0].Id);
		bw.Write(TriggersList[int_0].GmID);
		bw.Write(GetBytes(TriggersList[int_0].TriggerName, 128, Encoding.GetEncoding(936)));
		bw.Write(TriggersList[int_0].AutoStart);
		bw.Write(TriggersList[int_0].WaitWhileStart);
		bw.Write(TriggersList[int_0].WaitWhileStop);
		if (TriggersList[int_0].DontStartOnSchedule == 1)
		{
			bw.Write((byte)0);
		}
		else
		{
			bw.Write((byte)1);
		}
		if (TriggersList[int_0].DontStopOnSchedule == 1)
		{
			bw.Write((byte)0);
		}
		else
		{
			bw.Write((byte)1);
		}
		bw.Write(TriggersList[int_0].StartYear);
		bw.Write(TriggersList[int_0].StartMonth);
		bw.Write(TriggersList[int_0].StartWeekDay);
		bw.Write(TriggersList[int_0].StartDay);
		bw.Write(TriggersList[int_0].StartHour);
		bw.Write(TriggersList[int_0].StartMinute);
		bw.Write(TriggersList[int_0].StopYear);
		bw.Write(TriggersList[int_0].StopMonth);
		bw.Write(TriggersList[int_0].StopWeekDay);
		bw.Write(TriggersList[int_0].StopDay);
		bw.Write(TriggersList[int_0].StopHour);
		bw.Write(TriggersList[int_0].StopMinute);
		if (Version > 7)
		{
			bw.Write(TriggersList[int_0].Duration);
		}
	}
}
