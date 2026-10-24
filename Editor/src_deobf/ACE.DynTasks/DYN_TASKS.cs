using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ACE.Classes;

namespace ACE.DynTasks;

public sealed class DYN_TASKS
{
	[Serializable]
	private sealed class Class108
	{
		public static readonly Class108 class108_0 = new Class108();

		public static Func<DynTaskTmpl, DynTaskTmpl> func_0;

		public static Func<DynTaskTmpl, DynTaskTmpl> func_1;

		internal DynTaskTmpl method_0(DynTaskTmpl dynTaskTmpl_0)
		{
			return dynTaskTmpl_0.Clone();
		}

		internal DynTaskTmpl method_1(DynTaskTmpl dynTaskTmpl_0)
		{
			return dynTaskTmpl_0.Clone();
		}
	}

	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class AwardData
	{
		public int Mask { get; set; }

		public uint GoldNum { get; set; }

		public uint Exp { get; set; }

		public uint SP { get; set; }

		public uint Reputation { get; set; }

		public ObservableCollection<AwardItemsCand> CandItems { get; set; } = new ObservableCollection<AwardItemsCand>();

		public ObservableCollection<AwardMonstersSummoned> SummonedMonsters { get; set; } = new ObservableCollection<AwardMonstersSummoned>();

		public ObservableCollection<AwardPQRanking> PQRankingAwards { get; set; } = new ObservableCollection<AwardPQRanking>();

		public AwardData()
		{
		}

		public AwardData(BinaryReader binaryReader_0)
		{
			Mask = binaryReader_0.ReadInt32();
			if ((Mask & 1) != 0)
			{
				GoldNum = binaryReader_0.ReadUInt32();
			}
			if ((Mask & 2) != 0)
			{
				Exp = binaryReader_0.ReadUInt32();
			}
			if ((Mask & 4) != 0)
			{
				SP = binaryReader_0.ReadUInt32();
			}
			if ((Mask & 8) != 0)
			{
				Reputation = binaryReader_0.ReadUInt32();
			}
			if ((Mask & 0x10) != 0)
			{
				byte b = binaryReader_0.ReadByte();
				CandItems = new ObservableCollection<AwardItemsCand>();
				for (int i = 0; i < b; i++)
				{
					CandItems.Add(new AwardItemsCand(binaryReader_0));
				}
			}
			if ((Mask & 0x20) != 0)
			{
				byte b2 = binaryReader_0.ReadByte();
				SummonedMonsters = new ObservableCollection<AwardMonstersSummoned>();
				if (b2 > 0)
				{
					for (int j = 0; j < b2; j++)
					{
						uint count = binaryReader_0.ReadUInt32();
						SummonedMonsters.Add(new AwardMonstersSummoned(binaryReader_0, count));
					}
				}
			}
			if ((Mask & 0x40) == 0)
			{
				return;
			}
			byte b3 = binaryReader_0.ReadByte();
			PQRankingAwards = new ObservableCollection<AwardPQRanking>();
			if (b3 > 0)
			{
				for (int k = 0; k < b3; k++)
				{
					uint count2 = binaryReader_0.ReadUInt32();
					PQRankingAwards.Add(new AwardPQRanking(binaryReader_0, count2));
				}
			}
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(Mask);
			if ((Mask & 1) != 0)
			{
				bw.Write(GoldNum);
			}
			if ((Mask & 2) != 0)
			{
				bw.Write(Exp);
			}
			if ((Mask & 4) != 0)
			{
				bw.Write(SP);
			}
			if ((Mask & 8) != 0)
			{
				bw.Write(Reputation);
			}
			if ((Mask & 0x10) != 0)
			{
				bw.Write((byte)CandItems.Count);
				foreach (AwardItemsCand candItem in CandItems)
				{
					candItem.Write(bw);
				}
			}
			if ((Mask & 0x20) != 0)
			{
				bw.Write((byte)SummonedMonsters.Count);
				foreach (AwardMonstersSummoned summonedMonster in SummonedMonsters)
				{
					bw.Write((uint)summonedMonster.Monsters.Count);
					summonedMonster.Write(bw);
				}
			}
			if ((Mask & 0x40) == 0)
			{
				return;
			}
			bw.Write((byte)PQRankingAwards.Count);
			foreach (AwardPQRanking pQRankingAward in PQRankingAwards)
			{
				bw.Write((uint)pQRankingAward.RankingAwards.Count);
				pQRankingAward.Write(bw);
			}
		}

		public AwardData Clone()
		{
			AwardData awardData = new AwardData
			{
				Mask = Mask,
				GoldNum = GoldNum,
				Exp = Exp,
				SP = SP,
				Reputation = Reputation
			};
			foreach (AwardItemsCand candItem in CandItems)
			{
				awardData.CandItems.Add(candItem.Clone());
			}
			foreach (AwardMonstersSummoned summonedMonster in SummonedMonsters)
			{
				awardData.SummonedMonsters.Add(summonedMonster.Clone());
			}
			foreach (AwardPQRanking pQRankingAward in PQRankingAwards)
			{
				awardData.PQRankingAwards.Add(pQRankingAward.Clone());
			}
			return awardData;
		}

		public override string ToString()
		{
			return Mask switch
			{
				8 => string.Format(Class16.smethod_0(1649007676), Reputation), 
				1 => string.Format(Class16.smethod_0(1649007631), GoldNum), 
				2 => string.Format(Class16.smethod_0(1649007647), Exp), 
				4 => string.Format(Class16.smethod_0(1649007662), SP), 
				64 => string.Format(Class16.smethod_0(1649007748), PQRankingAwards.Count), 
				32 => string.Format(Class16.smethod_0(1649007714), SummonedMonsters.Count), 
				16 => string.Format(Class16.smethod_0(1649007690), CandItems.Count), 
				_ => string.Format(Class16.smethod_0(1649007770), Mask), 
			};
		}
	}

	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class AwardItemsCand
	{
		public byte RandChoose { get; set; }

		public ObservableCollection<ItemWanted> AwardItems { get; set; } = new ObservableCollection<ItemWanted>();

		public AwardItemsCand()
		{
		}

		public AwardItemsCand(BinaryReader br)
		{
			RandChoose = br.ReadByte();
			byte b = br.ReadByte();
			AwardItems = new ObservableCollection<ItemWanted>();
			for (int i = 0; i < b; i++)
			{
				AwardItems.Add(new ItemWanted(br));
			}
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(RandChoose);
			bw.Write((byte)AwardItems.Count);
			foreach (ItemWanted awardItem in AwardItems)
			{
				awardItem.Write(bw);
			}
		}

		public AwardItemsCand Clone()
		{
			AwardItemsCand awardItemsCand = new AwardItemsCand
			{
				RandChoose = RandChoose
			};
			foreach (ItemWanted awardItem in AwardItems)
			{
				awardItemsCand.AwardItems.Add(awardItem.Clone());
			}
			return awardItemsCand;
		}
	}

	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class AwardMonstersSummoned
	{
		public byte RandChoose { get; set; }

		public uint SummonRadius { get; set; }

		public byte DeathDisappear { get; set; }

		public ObservableCollection<MonstersSummoned> Monsters { get; set; } = new ObservableCollection<MonstersSummoned>();

		public AwardMonstersSummoned()
		{
		}

		public AwardMonstersSummoned(BinaryReader br, uint count)
		{
			RandChoose = br.ReadByte();
			SummonRadius = br.ReadUInt32();
			DeathDisappear = br.ReadByte();
			Monsters = new ObservableCollection<MonstersSummoned>();
			for (int i = 0; i < count; i++)
			{
				Monsters.Add(new MonstersSummoned(br));
			}
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(RandChoose);
			bw.Write(SummonRadius);
			bw.Write(DeathDisappear);
			foreach (MonstersSummoned monster in Monsters)
			{
				monster.Write(bw);
			}
		}

		public AwardMonstersSummoned Clone()
		{
			AwardMonstersSummoned awardMonstersSummoned = new AwardMonstersSummoned
			{
				RandChoose = RandChoose,
				SummonRadius = SummonRadius,
				DeathDisappear = DeathDisappear
			};
			foreach (MonstersSummoned monster in Monsters)
			{
				awardMonstersSummoned.Monsters.Add(monster.Clone());
			}
			return awardMonstersSummoned;
		}
	}

	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class AwardPQRanking
	{
		public byte AwardByProf { get; set; }

		public ObservableCollection<RankingAward> RankingAwards { get; set; } = new ObservableCollection<RankingAward>();

		public AwardPQRanking()
		{
		}

		public AwardPQRanking(BinaryReader br, uint count)
		{
			AwardByProf = br.ReadByte();
			RankingAwards = new ObservableCollection<RankingAward>();
			for (int i = 0; i < count; i++)
			{
				RankingAwards.Add(new RankingAward(br));
			}
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(AwardByProf);
			foreach (RankingAward rankingAward in RankingAwards)
			{
				rankingAward.Write(bw);
			}
		}

		public AwardPQRanking Clone()
		{
			AwardPQRanking awardPQRanking = new AwardPQRanking
			{
				AwardByProf = AwardByProf
			};
			foreach (RankingAward rankingAward in RankingAwards)
			{
				awardPQRanking.RankingAwards.Add(rankingAward.Clone());
			}
			return awardPQRanking;
		}
	}

	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class DynTaskTmpl
	{
		public int TokenMask1 { get; set; }

		public int TokenMask2 { get; set; }

		public byte DynTaskType { get; set; }

		public int SpecialAward { get; set; }

		public uint ID { get; set; }

		public string Name { get; set; } = string.Empty;

		public byte ChooseOne { get; set; }

		public byte RandOne { get; set; }

		public byte ExeChildInOrder { get; set; }

		public byte ParentAlsoFail { get; set; }

		public byte ParentAlsoSucc { get; set; }

		public byte CanGiveUp { get; set; }

		public byte CanRedo { get; set; }

		public byte CanRedoAfterFailure { get; set; }

		public byte ClearAsGiveUp { get; set; }

		public byte NeedRecord { get; set; }

		public byte FailAsPlayerDie { get; set; }

		public byte AutoDeliver { get; set; }

		public byte DeathTrig { get; set; }

		public byte ClearAcquired { get; set; }

		public byte Premise_Spouse { get; set; }

		public byte Teamwork { get; set; }

		public byte ShowDirection { get; set; }

		public byte Premise_Lev_Min { get; set; }

		public byte Premise_Lev_Max { get; set; }

		public uint TimeLimit { get; set; }

		public int Premise_Reputation { get; set; }

		public uint Premise_Period { get; set; }

		public ObservableCollection<ItemWanted> PremItems { get; set; } = new ObservableCollection<ItemWanted>();

		public byte DelvInZone { get; set; }

		public uint DelvWorld { get; set; }

		public ObservableCollection<TaskRegion> DelvRegions { get; set; } = new ObservableCollection<TaskRegion>();

		public byte TransTo { get; set; }

		public uint TransWldId { get; set; }

		public ZONE_VERT TransPt { get; set; } = new ZONE_VERT();

		public uint GivenCmnCount { get; set; }

		public uint GivenTskCount { get; set; }

		public ObservableCollection<ItemWanted> GivenItems { get; set; } = new ObservableCollection<ItemWanted>();

		public uint Premise_Deposit { get; set; }

		public uint Premise_Task_Least_Num { get; set; }

		public uint[] Premise_Tasks { get; set; } = new uint[20];

		public uint Gender { get; set; }

		public uint[] Occupations { get; set; } = new uint[17];

		public uint[] MutexTasks { get; set; } = new uint[20];

		public string TmType { get; set; } = string.Empty;

		public ObservableCollection<Timetable> Timetables { get; set; } = new ObservableCollection<Timetable>();

		public byte Unk2 { get; set; }

		public byte Unk3 { get; set; }

		public byte EnumMethod { get; set; }

		public ObservableCollection<MonsterWanted> MonsterWanted { get; set; } = new ObservableCollection<MonsterWanted>();

		public ObservableCollection<ItemWanted> ItemsWanted { get; set; } = new ObservableCollection<ItemWanted>();

		public uint GoldWanted { get; set; }

		public int FactionContribWanted { get; set; }

		public int FactionExpContribWanted { get; set; }

		public uint ReachSiteId { get; set; }

		public ObservableCollection<TaskRegion> ReachSites { get; set; } = new ObservableCollection<TaskRegion>();

		public uint LeaveSiteId { get; set; }

		public ObservableCollection<TaskRegion> LeaveSites { get; set; } = new ObservableCollection<TaskRegion>();

		public uint WaitTime { get; set; }

		public byte EnumFinishType { get; set; }

		public byte Unk { get; set; }

		public AwardData Award_S { get; set; } = new AwardData();

		public string Description { get; set; } = string.Empty;

		public string OkText { get; set; } = string.Empty;

		public string NoText { get; set; } = string.Empty;

		public TalkProc DelvTaskTalk { get; set; } = new TalkProc();

		public TalkProc UnqualifiedTaskTalk { get; set; } = new TalkProc();

		public TalkProc DelvItemTalk { get; set; } = new TalkProc();

		public TalkProc ExeTalk { get; set; } = new TalkProc();

		public TalkProc AwardTalk { get; set; } = new TalkProc();

		public int SubCount { get; set; }

		public ObservableCollection<DynTaskTmpl> SubTasks { get; set; } = new ObservableCollection<DynTaskTmpl>();

		public DynTaskTmpl()
		{
		}

		public DynTaskTmpl(BinaryReader br)
		{
			Read(br);
		}

		public void Read(BinaryReader br)
		{
			long num = br.BaseStream.Length - br.BaseStream.Position;
			if (num < 30L)
			{
				throw new EndOfStreamException(string.Format(Class16.smethod_0(1649007786), num));
			}
			TokenMask1 = br.ReadInt32();
			TokenMask2 = br.ReadInt32();
			DynTaskType = br.ReadByte();
			SpecialAward = br.ReadInt32();
			ID = br.ReadUInt32();
			byte b = br.ReadByte();
			if (b > 0)
			{
				byte[] array = br.ReadBytes(b * 2);
				if (array.Length != b * 2)
				{
					throw new EndOfStreamException(Class16.smethod_0(1649007860));
				}
				Name = Encoding.Unicode.GetString(array);
			}
			ChooseOne = br.ReadByte();
			RandOne = br.ReadByte();
			ExeChildInOrder = br.ReadByte();
			ParentAlsoFail = br.ReadByte();
			ParentAlsoSucc = br.ReadByte();
			CanGiveUp = br.ReadByte();
			CanRedo = br.ReadByte();
			CanRedoAfterFailure = br.ReadByte();
			ClearAsGiveUp = br.ReadByte();
			NeedRecord = br.ReadByte();
			FailAsPlayerDie = br.ReadByte();
			AutoDeliver = br.ReadByte();
			DeathTrig = br.ReadByte();
			ClearAcquired = br.ReadByte();
			Premise_Spouse = br.ReadByte();
			Teamwork = br.ReadByte();
			ShowDirection = br.ReadByte();
			Premise_Lev_Min = br.ReadByte();
			Premise_Lev_Max = br.ReadByte();
			if ((TokenMask1 & 1) != 0)
			{
				TimeLimit = br.ReadUInt32();
			}
			if ((TokenMask1 & 2) != 0)
			{
				Premise_Reputation = br.ReadInt32();
			}
			if ((TokenMask1 & 4) != 0)
			{
				Premise_Period = br.ReadUInt32();
			}
			if ((TokenMask1 & 8) != 0)
			{
				uint num2 = br.ReadUInt32();
				if (num2 > 50000)
				{
					throw new InvalidDataException(string.Format(Class16.smethod_0(1649007898), num2));
				}
				PremItems = new ObservableCollection<ItemWanted>();
				for (int i = 0; i < num2; i++)
				{
					PremItems.Add(new ItemWanted(br));
				}
			}
			if ((TokenMask1 & 0x10) != 0)
			{
				DelvInZone = br.ReadByte();
				DelvWorld = br.ReadUInt32();
				uint num3 = br.ReadUInt32();
				if (num3 > 50000)
				{
					throw new InvalidDataException(string.Format(Class16.smethod_0(1649007941), num3));
				}
				DelvRegions = new ObservableCollection<TaskRegion>();
				for (int j = 0; j < num3; j++)
				{
					DelvRegions.Add(new TaskRegion(br));
				}
			}
			if ((TokenMask1 & 0x20) != 0)
			{
				TransTo = br.ReadByte();
				TransWldId = br.ReadUInt32();
				TransPt = new ZONE_VERT(br);
			}
			if ((TokenMask1 & 0x40) != 0)
			{
				uint num4 = br.ReadUInt32();
				if (num4 > 50000)
				{
					throw new InvalidDataException(string.Format(Class16.smethod_0(1649007970), num4));
				}
				GivenCmnCount = br.ReadUInt32();
				GivenTskCount = br.ReadUInt32();
				GivenItems = new ObservableCollection<ItemWanted>();
				for (int k = 0; k < num4; k++)
				{
					GivenItems.Add(new ItemWanted(br));
				}
			}
			if ((TokenMask1 & 0x80) != 0)
			{
				Premise_Deposit = br.ReadUInt32();
			}
			if ((TokenMask1 & 0x100) != 0)
			{
				uint num5 = br.ReadUInt32();
				if (num5 > 50000)
				{
					throw new InvalidDataException(string.Format(Class16.smethod_0(1649008014), num5));
				}
				Premise_Task_Least_Num = br.ReadUInt32();
				Premise_Tasks = new uint[20];
				for (int l = 0; l < num5; l++)
				{
					uint num6 = br.ReadUInt32();
					if (l < Premise_Tasks.Length)
					{
						Premise_Tasks[l] = num6;
					}
				}
			}
			if ((TokenMask1 & 0x200) != 0)
			{
				Gender = br.ReadUInt32();
			}
			if ((TokenMask1 & 0x400) != 0)
			{
				uint num7 = br.ReadUInt32();
				if (num7 > 50000)
				{
					throw new InvalidDataException(string.Format(Class16.smethod_0(1649008053), num7));
				}
				Occupations = new uint[17];
				for (int m = 0; m < num7; m++)
				{
					uint num8 = br.ReadUInt32();
					if (m < Occupations.Length)
					{
						Occupations[m] = num8;
					}
				}
			}
			if ((TokenMask1 & 0x800) != 0)
			{
				uint num9 = br.ReadUInt32();
				if (num9 > 50000)
				{
					throw new InvalidDataException(string.Format(Class16.smethod_0(1649008082), num9));
				}
				MutexTasks = new uint[20];
				for (int n = 0; n < num9; n++)
				{
					uint num10 = br.ReadUInt32();
					if (n < MutexTasks.Length)
					{
						MutexTasks[n] = num10;
					}
				}
			}
			if ((TokenMask1 & 0x1000) != 0)
			{
				uint num11 = br.ReadUInt32();
				if (num11 > 50000)
				{
					throw new InvalidDataException(string.Format(Class16.smethod_0(1649008126), num11));
				}
				byte[] array2 = br.ReadBytes(24);
				if (array2.Length != 24)
				{
					throw new EndOfStreamException(Class16.smethod_0(1649007130));
				}
				TmType = Encoding.ASCII.GetString(array2).TrimEnd(default(char));
				Timetables = new ObservableCollection<Timetable>();
				for (int num12 = 0; num12 < num11; num12++)
				{
					Timetables.Add(new Timetable(br));
				}
			}
			Unk2 = br.ReadByte();
			Unk3 = br.ReadByte();
			EnumMethod = br.ReadByte();
			if (EnumMethod == 1)
			{
				uint num13 = br.ReadUInt32();
				MonsterWanted = new ObservableCollection<MonsterWanted>();
				for (int num14 = 0; num14 < num13; num14++)
				{
					MonsterWanted.Add(new MonsterWanted(br));
				}
			}
			else if (EnumMethod == 2)
			{
				uint num15 = br.ReadUInt32();
				ItemsWanted = new ObservableCollection<ItemWanted>();
				for (int num16 = 0; num16 < num15; num16++)
				{
					ItemsWanted.Add(new ItemWanted(br));
				}
				GoldWanted = br.ReadUInt32();
				FactionContribWanted = br.ReadInt32();
				FactionExpContribWanted = br.ReadInt32();
			}
			else if (EnumMethod == 4)
			{
				ReachSiteId = br.ReadUInt32();
				uint num17 = br.ReadUInt32();
				ReachSites = new ObservableCollection<TaskRegion>();
				for (int num18 = 0; num18 < num17; num18++)
				{
					ReachSites.Add(new TaskRegion(br));
				}
			}
			else if (EnumMethod == 11)
			{
				LeaveSiteId = br.ReadUInt32();
				uint num19 = br.ReadUInt32();
				LeaveSites = new ObservableCollection<TaskRegion>();
				for (int num20 = 0; num20 < num19; num20++)
				{
					LeaveSites.Add(new TaskRegion(br));
				}
			}
			else if (EnumMethod == 5)
			{
				WaitTime = br.ReadUInt32();
			}
			EnumFinishType = br.ReadByte();
			Unk = br.ReadByte();
			Award_S = new AwardData(br);
			int num21 = br.ReadInt32();
			if (num21 > 0)
			{
				if (num21 > 65536)
				{
					throw new InvalidDataException(string.Format(Class16.smethod_0(1649007189), num21));
				}
				byte[] array3 = br.ReadBytes(num21 * 2);
				if (array3.Length != num21 * 2)
				{
					throw new EndOfStreamException(Class16.smethod_0(1649007219));
				}
				Description = Encoding.Unicode.GetString(array3);
			}
			int num22 = br.ReadInt32();
			if (num22 > 0)
			{
				if (num22 > 65536)
				{
					throw new InvalidDataException(string.Format(Class16.smethod_0(1649007267), num22));
				}
				byte[] array4 = br.ReadBytes(num22 * 2);
				if (array4.Length != num22 * 2)
				{
					throw new EndOfStreamException(Class16.smethod_0(1649007309));
				}
				OkText = Encoding.Unicode.GetString(array4);
			}
			int num23 = br.ReadInt32();
			if (num23 > 0)
			{
				if (num23 > 65536)
				{
					throw new InvalidDataException(string.Format(Class16.smethod_0(1649007345), num23));
				}
				byte[] array5 = br.ReadBytes(num23 * 2);
				if (array5.Length != num23 * 2)
				{
					throw new EndOfStreamException(Class16.smethod_0(1649007379));
				}
				NoText = Encoding.Unicode.GetString(array5);
			}
			DelvTaskTalk = new TalkProc(br);
			UnqualifiedTaskTalk = new TalkProc(br);
			DelvItemTalk = new TalkProc(br);
			ExeTalk = new TalkProc(br);
			AwardTalk = new TalkProc(br);
			SubCount = br.ReadInt32();
			SubTasks = new ObservableCollection<DynTaskTmpl>();
			if (SubCount >= 0 && SubCount <= 50000)
			{
				for (int num24 = 0; num24 < SubCount; num24++)
				{
					SubTasks.Add(new DynTaskTmpl(br));
				}
				return;
			}
			throw new InvalidDataException(string.Format(Class16.smethod_0(1649007431), SubCount));
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(TokenMask1);
			bw.Write(TokenMask2);
			bw.Write(DynTaskType);
			bw.Write(SpecialAward);
			bw.Write(ID);
			string text = Name ?? string.Empty;
			if (text.Length > 1024)
			{
				text = text.Substring(0, 1024);
			}
			if (text.Length > 255)
			{
				text = text.Substring(0, 255);
			}
			byte[] bytes = Encoding.Unicode.GetBytes(text);
			bw.Write((byte)text.Length);
			bw.Write(bytes);
			bw.Write(ChooseOne);
			bw.Write(RandOne);
			bw.Write(ExeChildInOrder);
			bw.Write(ParentAlsoFail);
			bw.Write(ParentAlsoSucc);
			bw.Write(CanGiveUp);
			bw.Write(CanRedo);
			bw.Write(CanRedoAfterFailure);
			bw.Write(ClearAsGiveUp);
			bw.Write(NeedRecord);
			bw.Write(FailAsPlayerDie);
			bw.Write(AutoDeliver);
			bw.Write(DeathTrig);
			bw.Write(ClearAcquired);
			bw.Write(Premise_Spouse);
			bw.Write(Teamwork);
			bw.Write(ShowDirection);
			bw.Write(Premise_Lev_Min);
			bw.Write(Premise_Lev_Max);
			if ((TokenMask1 & 1) != 0)
			{
				bw.Write(TimeLimit);
			}
			if ((TokenMask1 & 2) != 0)
			{
				bw.Write(Premise_Reputation);
			}
			if ((TokenMask1 & 4) != 0)
			{
				bw.Write(Premise_Period);
			}
			if ((TokenMask1 & 8) != 0)
			{
				bw.Write((uint)PremItems.Count);
				foreach (ItemWanted premItem in PremItems)
				{
					premItem.Write(bw);
				}
			}
			if ((TokenMask1 & 0x10) != 0)
			{
				bw.Write(DelvInZone);
				bw.Write(DelvWorld);
				bw.Write((uint)DelvRegions.Count);
				foreach (TaskRegion delvRegion in DelvRegions)
				{
					delvRegion.Write(bw);
				}
			}
			if ((TokenMask1 & 0x20) != 0)
			{
				bw.Write(TransTo);
				bw.Write(TransWldId);
				TransPt.Write(bw);
			}
			if ((TokenMask1 & 0x40) != 0)
			{
				bw.Write((uint)GivenItems.Count);
				bw.Write(GivenCmnCount);
				bw.Write(GivenTskCount);
				foreach (ItemWanted givenItem in GivenItems)
				{
					givenItem.Write(bw);
				}
			}
			if ((TokenMask1 & 0x80) != 0)
			{
				bw.Write(Premise_Deposit);
			}
			if ((TokenMask1 & 0x100) != 0)
			{
				uint[] premise_Tasks = Premise_Tasks;
				int num = ((premise_Tasks != null) ? premise_Tasks.Length : 0);
				bw.Write((uint)num);
				bw.Write(Premise_Task_Least_Num);
				for (int i = 0; i < num; i++)
				{
					bw.Write(Premise_Tasks[i]);
				}
			}
			if ((TokenMask1 & 0x200) != 0)
			{
				bw.Write(Gender);
			}
			if ((TokenMask1 & 0x400) != 0)
			{
				uint[] occupations = Occupations;
				int num2 = ((occupations != null) ? occupations.Length : 0);
				bw.Write((uint)num2);
				for (int j = 0; j < num2; j++)
				{
					bw.Write(Occupations[j]);
				}
			}
			if ((TokenMask1 & 0x800) != 0)
			{
				uint[] mutexTasks = MutexTasks;
				int num3 = ((mutexTasks != null) ? mutexTasks.Length : 0);
				bw.Write((uint)num3);
				for (int k = 0; k < num3; k++)
				{
					bw.Write(MutexTasks[k]);
				}
			}
			if ((TokenMask1 & 0x1000) != 0)
			{
				bw.Write((uint)Timetables.Count);
				byte[] array = new byte[24];
				byte[] bytes2 = Encoding.ASCII.GetBytes(TmType ?? string.Empty);
				Array.Copy(bytes2, array, Math.Min(bytes2.Length, 24));
				bw.Write(array);
				foreach (Timetable timetable in Timetables)
				{
					timetable.Write(bw);
				}
			}
			bw.Write(Unk2);
			bw.Write(Unk3);
			bw.Write(EnumMethod);
			if (EnumMethod == 1)
			{
				bw.Write((uint)MonsterWanted.Count);
				foreach (MonsterWanted item in MonsterWanted)
				{
					item.Write(bw);
				}
			}
			else if (EnumMethod == 2)
			{
				bw.Write((uint)ItemsWanted.Count);
				foreach (ItemWanted item2 in ItemsWanted)
				{
					item2.Write(bw);
				}
				bw.Write(GoldWanted);
				bw.Write(FactionContribWanted);
				bw.Write(FactionExpContribWanted);
			}
			else if (EnumMethod == 4)
			{
				bw.Write(ReachSiteId);
				bw.Write((uint)ReachSites.Count);
				foreach (TaskRegion reachSite in ReachSites)
				{
					reachSite.Write(bw);
				}
			}
			else if (EnumMethod == 11)
			{
				bw.Write(LeaveSiteId);
				bw.Write((uint)LeaveSites.Count);
				foreach (TaskRegion leaveSite in LeaveSites)
				{
					leaveSite.Write(bw);
				}
			}
			else if (EnumMethod == 5)
			{
				bw.Write(WaitTime);
			}
			bw.Write(EnumFinishType);
			bw.Write(Unk);
			Award_S.Write(bw);
			string text2 = Description ?? string.Empty;
			if (text2.Length > 65536)
			{
				text2 = text2.Substring(0, 65536);
			}
			byte[] bytes3 = Encoding.Unicode.GetBytes(text2);
			bw.Write(bytes3.Length / 2);
			bw.Write(bytes3);
			string text3 = OkText ?? string.Empty;
			if (text3.Length > 65536)
			{
				text3 = text3.Substring(0, 65536);
			}
			byte[] bytes4 = Encoding.Unicode.GetBytes(text3);
			bw.Write(bytes4.Length / 2);
			bw.Write(bytes4);
			string text4 = NoText ?? string.Empty;
			if (text4.Length > 65536)
			{
				text4 = text4.Substring(0, 65536);
			}
			byte[] bytes5 = Encoding.Unicode.GetBytes(text4);
			bw.Write(bytes5.Length / 2);
			bw.Write(bytes5);
			DelvTaskTalk.Write(bw);
			UnqualifiedTaskTalk.Write(bw);
			DelvItemTalk.Write(bw);
			ExeTalk.Write(bw);
			AwardTalk.Write(bw);
			SubCount = SubTasks?.Count ?? 0;
			bw.Write(SubCount);
			if (SubTasks == null)
			{
				return;
			}
			foreach (DynTaskTmpl subTask in SubTasks)
			{
				subTask.Write(bw);
			}
		}

		public DynTaskTmpl Clone()
		{
			DynTaskTmpl dynTaskTmpl = new DynTaskTmpl
			{
				TokenMask1 = TokenMask1,
				TokenMask2 = TokenMask2,
				DynTaskType = DynTaskType,
				SpecialAward = SpecialAward,
				ID = ID,
				Name = Name,
				ChooseOne = ChooseOne,
				RandOne = RandOne,
				ExeChildInOrder = ExeChildInOrder,
				ParentAlsoFail = ParentAlsoFail,
				ParentAlsoSucc = ParentAlsoSucc,
				CanGiveUp = CanGiveUp,
				CanRedo = CanRedo,
				CanRedoAfterFailure = CanRedoAfterFailure,
				ClearAsGiveUp = ClearAsGiveUp,
				NeedRecord = NeedRecord,
				FailAsPlayerDie = FailAsPlayerDie,
				AutoDeliver = AutoDeliver,
				DeathTrig = DeathTrig,
				ClearAcquired = ClearAcquired,
				Premise_Spouse = Premise_Spouse,
				Teamwork = Teamwork,
				ShowDirection = ShowDirection,
				Premise_Lev_Min = Premise_Lev_Min,
				Premise_Lev_Max = Premise_Lev_Max,
				TimeLimit = TimeLimit,
				Premise_Reputation = Premise_Reputation,
				Premise_Period = Premise_Period,
				DelvInZone = DelvInZone,
				DelvWorld = DelvWorld,
				TransTo = TransTo,
				TransWldId = TransWldId,
				TransPt = TransPt.Clone(),
				GivenCmnCount = GivenCmnCount,
				GivenTskCount = GivenTskCount,
				Premise_Deposit = Premise_Deposit,
				Premise_Task_Least_Num = Premise_Task_Least_Num,
				Premise_Tasks = (uint[])Premise_Tasks.Clone(),
				Gender = Gender,
				Occupations = (uint[])Occupations.Clone(),
				MutexTasks = (uint[])MutexTasks.Clone(),
				TmType = TmType,
				Unk2 = Unk2,
				Unk3 = Unk3,
				EnumMethod = EnumMethod,
				GoldWanted = GoldWanted,
				FactionContribWanted = FactionContribWanted,
				FactionExpContribWanted = FactionExpContribWanted,
				ReachSiteId = ReachSiteId,
				LeaveSiteId = LeaveSiteId,
				WaitTime = WaitTime,
				EnumFinishType = EnumFinishType,
				Unk = Unk,
				Award_S = Award_S.Clone(),
				Description = Description,
				OkText = OkText,
				NoText = NoText,
				DelvTaskTalk = DelvTaskTalk.Clone(),
				UnqualifiedTaskTalk = UnqualifiedTaskTalk.Clone(),
				DelvItemTalk = DelvItemTalk.Clone(),
				ExeTalk = ExeTalk.Clone(),
				AwardTalk = AwardTalk.Clone(),
				SubCount = SubCount
			};
			foreach (ItemWanted premItem in PremItems)
			{
				dynTaskTmpl.PremItems.Add(premItem.Clone());
			}
			foreach (TaskRegion delvRegion in DelvRegions)
			{
				dynTaskTmpl.DelvRegions.Add(delvRegion.Clone());
			}
			foreach (ItemWanted givenItem in GivenItems)
			{
				dynTaskTmpl.GivenItems.Add(givenItem.Clone());
			}
			foreach (Timetable timetable in Timetables)
			{
				dynTaskTmpl.Timetables.Add(timetable.Clone());
			}
			foreach (MonsterWanted item in MonsterWanted)
			{
				dynTaskTmpl.MonsterWanted.Add(item.Clone());
			}
			foreach (ItemWanted item2 in ItemsWanted)
			{
				dynTaskTmpl.ItemsWanted.Add(item2.Clone());
			}
			foreach (TaskRegion reachSite in ReachSites)
			{
				dynTaskTmpl.ReachSites.Add(reachSite.Clone());
			}
			foreach (TaskRegion leaveSite in LeaveSites)
			{
				dynTaskTmpl.LeaveSites.Add(leaveSite.Clone());
			}
			foreach (DynTaskTmpl subTask in SubTasks)
			{
				dynTaskTmpl.SubTasks.Add(subTask.Clone());
			}
			return dynTaskTmpl;
		}

		public override string ToString()
		{
			return string.Format(Class16.smethod_0(1648942820), ID, Name);
		}
	}

	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class ItemWanted
	{
		public int ItemTemplId { get; set; }

		public byte CommonItem { get; set; }

		public int ItemNum { get; set; }

		public float Prob { get; set; }

		public uint Period { get; set; }

		public uint ServerLimit { get; set; }

		public ItemWanted()
		{
		}

		public ItemWanted(BinaryReader br)
		{
			ItemTemplId = br.ReadInt32();
			CommonItem = br.ReadByte();
			ItemNum = br.ReadInt32();
			Prob = br.ReadSingle();
			Period = br.ReadUInt32();
			ServerLimit = br.ReadUInt32();
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(ItemTemplId);
			bw.Write(CommonItem);
			bw.Write(ItemNum);
			bw.Write(Prob);
			bw.Write(Period);
			bw.Write(ServerLimit);
		}

		public ItemWanted Clone()
		{
			return (ItemWanted)MemberwiseClone();
		}

		public override string ToString()
		{
			return string.Format(Class16.smethod_0(1649007457), ItemTemplId, ItemNum);
		}
	}

	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class MonsterWanted
	{
		public uint MonsterTemplId { get; set; }

		public uint MonsterNum { get; set; }

		public uint DropItemId { get; set; }

		public uint DropItemCount { get; set; }

		public byte DropCmnItem { get; set; }

		public float DropProb { get; set; }

		public byte KillerLev { get; set; }

		public int DPH { get; set; }

		public int DPS { get; set; }

		public int WorldLevel { get; set; }

		public MonsterWanted()
		{
		}

		public MonsterWanted(BinaryReader br)
		{
			MonsterTemplId = br.ReadUInt32();
			MonsterNum = br.ReadUInt32();
			DropItemId = br.ReadUInt32();
			DropItemCount = br.ReadUInt32();
			DropCmnItem = br.ReadByte();
			DropProb = br.ReadSingle();
			KillerLev = br.ReadByte();
			DPH = br.ReadInt32();
			DPS = br.ReadInt32();
			WorldLevel = br.ReadInt32();
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(MonsterTemplId);
			bw.Write(MonsterNum);
			bw.Write(DropItemId);
			bw.Write(DropItemCount);
			bw.Write(DropCmnItem);
			bw.Write(DropProb);
			bw.Write(KillerLev);
			bw.Write(DPH);
			bw.Write(DPS);
			bw.Write(WorldLevel);
		}

		public MonsterWanted Clone()
		{
			return (MonsterWanted)MemberwiseClone();
		}

		public override string ToString()
		{
			return string.Format(Class16.smethod_0(1649007486), MonsterTemplId, MonsterNum);
		}
	}

	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class MonstersSummoned
	{
		public uint MonsterTemplId { get; set; }

		public uint MonsterNum { get; set; }

		public float SummonProb { get; set; }

		public int Period { get; set; }

		public MonstersSummoned()
		{
		}

		public MonstersSummoned(BinaryReader br)
		{
			MonsterTemplId = br.ReadUInt32();
			MonsterNum = br.ReadUInt32();
			SummonProb = br.ReadSingle();
			Period = br.ReadInt32();
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(MonsterTemplId);
			bw.Write(MonsterNum);
			bw.Write(SummonProb);
			bw.Write(Period);
		}

		public MonstersSummoned Clone()
		{
			return (MonstersSummoned)MemberwiseClone();
		}

		public override string ToString()
		{
			return string.Format(Class16.smethod_0(1649007510), MonsterTemplId, MonsterNum);
		}
	}

	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class RankingAward
	{
		public uint RankingStart { get; set; }

		public uint RankingEnd { get; set; }

		public byte CommonItem { get; set; }

		public uint AwardItemId { get; set; }

		public uint AwardItemNum { get; set; }

		public int Period { get; set; }

		public RankingAward()
		{
		}

		public RankingAward(BinaryReader br)
		{
			RankingStart = br.ReadUInt32();
			RankingEnd = br.ReadUInt32();
			CommonItem = br.ReadByte();
			AwardItemId = br.ReadUInt32();
			AwardItemNum = br.ReadUInt32();
			Period = br.ReadInt32();
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(RankingStart);
			bw.Write(RankingEnd);
			bw.Write(CommonItem);
			bw.Write(AwardItemId);
			bw.Write(AwardItemNum);
			bw.Write(Period);
		}

		public RankingAward Clone()
		{
			return (RankingAward)MemberwiseClone();
		}
	}

	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class TalkOption
	{
		public int Param { get; set; }

		public int Id { get; set; }

		public string Text { get; set; } = string.Empty;

		public TalkOption()
		{
		}

		public TalkOption(BinaryReader br)
		{
			Param = br.ReadInt32();
			Id = br.ReadInt32();
			int num = br.ReadInt32();
			if (num > 0)
			{
				byte[] bytes = br.ReadBytes(num);
				Text = Encoding.Unicode.GetString(bytes);
			}
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(Param);
			bw.Write(Id);
			byte[] bytes = Encoding.Unicode.GetBytes(Text ?? string.Empty);
			bw.Write(bytes.Length);
			bw.Write(bytes);
		}

		public TalkOption Clone()
		{
			return new TalkOption
			{
				Param = Param,
				Id = Id,
				Text = Text
			};
		}

		public override string ToString()
		{
			return string.Format(Class16.smethod_0(1648942820), Id, Text);
		}
	}

	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class TalkProc
	{
		public int IdTalk { get; set; }

		public ObservableCollection<TalkWindow> Windows { get; set; } = new ObservableCollection<TalkWindow>();

		public TalkProc()
		{
		}

		public TalkProc(BinaryReader br)
		{
			IdTalk = br.ReadInt32();
			byte b = br.ReadByte();
			Windows = new ObservableCollection<TalkWindow>();
			for (int i = 0; i < b; i++)
			{
				Windows.Add(new TalkWindow(br));
			}
		}

		public void Write(BinaryWriter binaryWriter_0)
		{
			binaryWriter_0.Write(IdTalk);
			binaryWriter_0.Write((byte)Windows.Count);
			foreach (TalkWindow window in Windows)
			{
				window.Write(binaryWriter_0);
			}
		}

		public TalkProc Clone()
		{
			TalkProc talkProc = new TalkProc
			{
				IdTalk = IdTalk
			};
			foreach (TalkWindow window in Windows)
			{
				talkProc.Windows.Add(window.Clone());
			}
			return talkProc;
		}

		public override string ToString()
		{
			return string.Format(Class16.smethod_0(1649007533), IdTalk, Windows.Count);
		}
	}

	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class TalkWindow
	{
		public byte Id { get; set; }

		public byte IdParent { get; set; }

		public string TalkText { get; set; } = string.Empty;

		public ObservableCollection<TalkOption> Options { get; set; } = new ObservableCollection<TalkOption>();

		public TalkWindow()
		{
		}

		public TalkWindow(BinaryReader br)
		{
			Id = br.ReadByte();
			IdParent = br.ReadByte();
			int num = br.ReadInt32();
			if (num > 0)
			{
				byte[] bytes = br.ReadBytes(num * 2);
				method_1(Encoding.Unicode.GetString(bytes));
			}
			byte b = br.ReadByte();
			Options = new ObservableCollection<TalkOption>();
			for (int i = 0; i < b; i++)
			{
				Options.Add(new TalkOption(br));
			}
		}

		private string method_0()
		{
			return TalkText;
		}

		private void method_1(string string_0)
		{
			TalkText = string_0;
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(Id);
			bw.Write(IdParent);
			byte[] bytes = Encoding.Unicode.GetBytes(TalkText ?? string.Empty);
			bw.Write(bytes.Length / 2);
			bw.Write(bytes);
			bw.Write((byte)Options.Count);
			foreach (TalkOption option in Options)
			{
				option.Write(bw);
			}
		}

		public TalkWindow Clone()
		{
			TalkWindow talkWindow = new TalkWindow
			{
				Id = Id,
				IdParent = IdParent,
				TalkText = TalkText
			};
			foreach (TalkOption option in Options)
			{
				talkWindow.Options.Add(option.Clone());
			}
			return talkWindow;
		}

		public override string ToString()
		{
			return string.Format(Class16.smethod_0(1649007553), Id, TalkText?.Substring(0, Math.Min(30, TalkText?.Length ?? 0)));
		}
	}

	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class TaskRegion
	{
		public ZONE_VERT Min { get; set; } = new ZONE_VERT();

		public ZONE_VERT Max { get; set; } = new ZONE_VERT();

		public TaskRegion()
		{
		}

		public TaskRegion(BinaryReader br)
		{
			Min = new ZONE_VERT(br);
			Max = new ZONE_VERT(br);
		}

		public void Write(BinaryWriter bw)
		{
			Min.Write(bw);
			Max.Write(bw);
		}

		public TaskRegion Clone()
		{
			return new TaskRegion
			{
				Min = Min.Clone(),
				Max = Max.Clone()
			};
		}

		public override string ToString()
		{
			return string.Format(Class16.smethod_0(1649007578), Min, Max);
		}
	}

	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class TaskTime
	{
		public int Year { get; set; }

		public int Month { get; set; }

		public int Day { get; set; }

		public int Hour { get; set; }

		public int Min { get; set; }

		public int WDay { get; set; }

		public TaskTime()
		{
		}

		public TaskTime(BinaryReader br)
		{
			Year = br.ReadInt32();
			Month = br.ReadInt32();
			Day = br.ReadInt32();
			Hour = br.ReadInt32();
			Min = br.ReadInt32();
			WDay = br.ReadInt32();
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(Year);
			bw.Write(Month);
			bw.Write(Day);
			bw.Write(Hour);
			bw.Write(Min);
			bw.Write(WDay);
		}

		public TaskTime Clone()
		{
			return (TaskTime)MemberwiseClone();
		}

		public override string ToString()
		{
			return string.Format(Class16.smethod_0(1649007612), Year, Month, Day, Hour, Min, WDay);
		}
	}

	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class Timetable
	{
		public TaskTime Start { get; set; } = new TaskTime();

		public TaskTime End { get; set; } = new TaskTime();

		public Timetable()
		{
		}

		public Timetable(BinaryReader br)
		{
			Start = new TaskTime(br);
			End = new TaskTime(br);
		}

		public void Write(BinaryWriter bw)
		{
			Start.Write(bw);
			End.Write(bw);
		}

		public Timetable Clone()
		{
			return new Timetable
			{
				Start = Start.Clone(),
				End = End.Clone()
			};
		}
	}

	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class ZONE_VERT
	{
		public float Single_0 { get; set; }

		public float Single_1 { get; set; }

		public float Single_2 { get; set; }

		public ZONE_VERT()
		{
		}

		public ZONE_VERT(BinaryReader br)
		{
			Single_0 = br.ReadSingle();
			Single_1 = br.ReadSingle();
			Single_2 = br.ReadSingle();
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(Single_0);
			bw.Write(Single_1);
			bw.Write(Single_2);
		}

		public ZONE_VERT Clone()
		{
			return (ZONE_VERT)MemberwiseClone();
		}

		public override string ToString()
		{
			return string.Format(Class16.smethod_0(1649006623), Single_0, Single_1, Single_2);
		}
	}

	private string string_0 = string.Empty;

	private bool bool_0;

	private bool bool_1;

	private uint uint_0;

	private uint uint_1;

	private short short_0;

	private ObservableCollection<DynTaskTmpl> observableCollection_0 = new ObservableCollection<DynTaskTmpl>();

	public string FileName
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public bool FileLoaded
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
	}

	public bool FileChanged
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public uint DataSize
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

	public uint TimeMark
	{
		[CompilerGenerated]
		get
		{
			return uint_1;
		}
		[CompilerGenerated]
		set
		{
			uint_1 = value;
		}
	}

	public short Version
	{
		[CompilerGenerated]
		get
		{
			return short_0;
		}
		[CompilerGenerated]
		set
		{
			short_0 = value;
		}
	}

	public ObservableCollection<DynTaskTmpl> Tasks
	{
		[CompilerGenerated]
		get
		{
			return observableCollection_0;
		}
		[CompilerGenerated]
		set
		{
			observableCollection_0 = value;
		}
	}

	public DYN_TASKS()
	{
		method_0(bool_2: false);
		FileChanged = false;
		Tasks = new ObservableCollection<DynTaskTmpl>();
	}

	public DYN_TASKS(string fileName)
		: this()
	{
		if (!string.IsNullOrWhiteSpace(fileName))
		{
			Load(fileName);
		}
	}

	private void method_0(bool bool_2)
	{
		bool_0 = bool_2;
	}

	public void Load(string fileName)
	{
		if (string.IsNullOrWhiteSpace(fileName))
		{
			throw new InvalidDataException(Class16.smethod_0(1648918812));
		}
		if (!File.Exists(fileName))
		{
			throw new FileNotFoundException(Class16.smethod_0(1649006654), fileName);
		}
		EditorSessionTracker.LogFolderAccess(fileName, Class16.smethod_0(1648903793), Class16.smethod_0(1649006676));
		FileName = fileName;
		using FileStream fileStream = File.OpenRead(fileName);
		BinaryReader binaryReader = new BinaryReader(fileStream);
		try
		{
			if (fileStream.Length < 12L)
			{
				throw new EndOfStreamException(Class16.smethod_0(1649006692));
			}
			DataSize = binaryReader.ReadUInt32();
			TimeMark = binaryReader.ReadUInt32();
			Version = binaryReader.ReadInt16();
			short num = binaryReader.ReadInt16();
			if (DataSize > (uint)fileStream.Length)
			{
				throw new EndOfStreamException(string.Format(Class16.smethod_0(1649006721), DataSize, fileStream.Length));
			}
			if (num >= 0 && num <= short.MaxValue)
			{
				Tasks = new ObservableCollection<DynTaskTmpl>();
				for (int i = 0; i < num; i++)
				{
					try
					{
						Tasks.Add(new DynTaskTmpl(binaryReader));
					}
					catch (EndOfStreamException ex)
					{
						throw new EndOfStreamException(string.Format(Class16.smethod_0(1649006830), i, ex.Message), ex);
					}
					catch (InvalidDataException ex2)
					{
						throw new InvalidDataException(string.Format(Class16.smethod_0(1649006830), i, ex2.Message), ex2);
					}
					catch (Exception ex3)
					{
						throw new InvalidDataException(string.Format(Class16.smethod_0(1649006830), i, ex3.Message), ex3);
					}
				}
				method_0(bool_2: true);
				FileChanged = false;
				return;
			}
			throw new InvalidDataException(string.Format(Class16.smethod_0(1649006792), num));
		}
		finally
		{
			((IDisposable)binaryReader).Dispose();
		}
	}

	public void Save()
	{
		if (string.IsNullOrWhiteSpace(FileName))
		{
			throw new InvalidDataException(Class16.smethod_0(1648918812));
		}
		EditorSessionTracker.LogFolderAccess(FileName, Class16.smethod_0(1649006856), Class16.smethod_0(1649006676));
		if (File.Exists(FileName))
		{
			File.Copy(FileName, FileName + Class16.smethod_0(1648898363), overwrite: true);
		}
		using FileStream fileStream = File.Open(FileName, FileMode.Create, FileAccess.Write, FileShare.None);
		BinaryWriter binaryWriter = new BinaryWriter(fileStream);
		try
		{
			long position = fileStream.Position;
			binaryWriter.Write(DataSize);
			binaryWriter.Write(TimeMark);
			binaryWriter.Write(Version);
			binaryWriter.Write((short)Tasks.Count);
			foreach (DynTaskTmpl task in Tasks)
			{
				task.Write(binaryWriter);
			}
			uint value = (uint)(fileStream.Position - 4L);
			fileStream.Position = position;
			binaryWriter.Write(value);
			FileChanged = false;
		}
		finally
		{
			((IDisposable)binaryWriter).Dispose();
		}
	}

	public void SaveAs(string fileName)
	{
		EditorSessionTracker.LogFolderAccess(fileName, Class16.smethod_0(1649006856), Class16.smethod_0(1649006676));
		string fileName2 = FileName;
		FileName = fileName;
		try
		{
			using FileStream fileStream = File.Open(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
			BinaryWriter binaryWriter = new BinaryWriter(fileStream);
			try
			{
				long position = fileStream.Position;
				binaryWriter.Write(DataSize);
				binaryWriter.Write(TimeMark);
				binaryWriter.Write(Version);
				binaryWriter.Write((short)Tasks.Count);
				foreach (DynTaskTmpl task in Tasks)
				{
					task.Write(binaryWriter);
				}
				uint value = (uint)(fileStream.Position - 4L);
				fileStream.Position = position;
				binaryWriter.Write(value);
				FileChanged = false;
			}
			finally
			{
				((IDisposable)binaryWriter).Dispose();
			}
		}
		catch
		{
			FileName = fileName2;
			throw;
		}
	}

	public void AddTask()
	{
		DynTaskTmpl item = new DynTaskTmpl
		{
			ID = GetNextId(),
			Name = Class16.smethod_0(1649006867)
		};
		Tasks.Add(item);
		FileChanged = true;
	}

	public void AddTask(int sourceIndex)
	{
		if (sourceIndex >= 0 && sourceIndex < Tasks.Count)
		{
			DynTaskTmpl dynTaskTmpl = Tasks[sourceIndex].Clone();
			dynTaskTmpl.ID = GetNextId();
			dynTaskTmpl.Name += Class16.smethod_0(1649006882);
			Tasks.Add(dynTaskTmpl);
			FileChanged = true;
		}
	}

	public void DeleteTask(int index)
	{
		if (index >= 0 && index < Tasks.Count)
		{
			Tasks.RemoveAt(index);
			FileChanged = true;
		}
	}

	public uint GetNextId()
	{
		uint num = 0u;
		foreach (DynTaskTmpl task in Tasks)
		{
			if (task.ID > num)
			{
				num = task.ID;
			}
		}
		return num + 1;
	}

	public bool IsIdUsed(uint id, int excludeIndex = -1)
	{
		int num = 0;
		while (true)
		{
			if (num < Tasks.Count)
			{
				if (num != excludeIndex && Tasks[num].ID == id)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public static string GetTimestampText(uint timestamp)
	{
		try
		{
			return DateTimeOffset.FromUnixTimeSeconds(timestamp).LocalDateTime.ToString(Class16.smethod_0(1649006896));
		}
		catch
		{
			return timestamp.ToString();
		}
	}

	public static string GetMethodName(byte method)
	{
		return method switch
		{
			11 => Class16.smethod_0(1649007007), 
			1 => Class16.smethod_0(1649006922), 
			2 => Class16.smethod_0(1649006950), 
			4 => Class16.smethod_0(1649006962), 
			5 => Class16.smethod_0(1649006991), 
			_ => string.Format(Class16.smethod_0(1649007028), method), 
		};
	}

	public static string GetFinishTypeName(byte finishType)
	{
		return finishType switch
		{
			0 => Class16.smethod_0(1648924120), 
			1 => Class16.smethod_0(1649007040), 
			2 => Class16.smethod_0(1649007050), 
			_ => string.Format(Class16.smethod_0(1649007028), finishType), 
		};
	}

	public static string GetTaskTypeName(byte taskType)
	{
		return taskType switch
		{
			0 => Class16.smethod_0(1649007069), 
			1 => Class16.smethod_0(1649007074), 
			2 => Class16.smethod_0(1649007094), 
			3 => Class16.smethod_0(1649007099), 
			_ => string.Format(Class16.smethod_0(1649007028), taskType), 
		};
	}

	public DynTasksSnapshot CreateUndoSnapshot()
	{
		return new DynTasksSnapshot
		{
			FileName = FileName,
			FileLoaded = FileLoaded,
			FileChanged = FileChanged,
			DataSize = DataSize,
			TimeMark = TimeMark,
			Version = Version,
			Tasks = Tasks.Select(Class108.class108_0.method_0).ToList()
		};
	}

	public void RestoreUndoSnapshot(DynTasksSnapshot snapshot)
	{
		if (snapshot != null)
		{
			FileName = snapshot.FileName ?? string.Empty;
			method_0(snapshot.FileLoaded);
			FileChanged = snapshot.FileChanged;
			DataSize = snapshot.DataSize;
			TimeMark = snapshot.TimeMark;
			Version = snapshot.Version;
			Tasks = new ObservableCollection<DynTaskTmpl>(snapshot.Tasks.Select(Class108.class108_0.method_1));
		}
	}
}
