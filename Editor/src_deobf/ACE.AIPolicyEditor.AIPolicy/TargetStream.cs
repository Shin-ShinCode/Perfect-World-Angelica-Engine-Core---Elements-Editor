using System.Collections.Generic;
using System.IO;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy;

public static class TargetStream
{
	public static List<string> GetTargetList()
	{
		List<string> list = new List<string>();
		EnumTarget enumTarget = EnumTarget.t_num;
		for (int i = 0; i < (int)enumTarget; i++)
		{
			EnumTarget enumTarget2 = (EnumTarget)i;
			list.Add(enumTarget2.ToString());
		}
		return list;
	}

	public static TargetParam Read(BinaryReader br)
	{
		EnumTarget enumTarget = (EnumTarget)br.ReadUInt32();
		uint occupations = 0u;
		uint players = 0u;
		uint unk = 0u;
		uint unk2 = 0u;
		uint unk3 = 0u;
		if (enumTarget == EnumTarget.occupation_list)
		{
			occupations = br.ReadUInt32();
		}
		if (enumTarget == EnumTarget.t_random_in_range)
		{
			players = br.ReadUInt32();
		}
		if (enumTarget == EnumTarget.t_nearest_in_range)
		{
			players = br.ReadUInt32();
		}
		if (enumTarget == EnumTarget.t_farthest_in_range)
		{
			players = br.ReadUInt32();
		}
		if (enumTarget == EnumTarget.unk_18)
		{
			players = br.ReadUInt32();
			unk = br.ReadUInt32();
			unk2 = br.ReadUInt32();
		}
		if (enumTarget == EnumTarget.unk_20)
		{
			players = br.ReadUInt32();
			unk = br.ReadUInt32();
			unk2 = br.ReadUInt32();
			unk3 = br.ReadUInt32();
		}
		return new TargetParam
		{
			Target = enumTarget,
			Occupations = occupations,
			Players = players,
			Unk2 = unk,
			Unk3 = unk2,
			Unk4 = unk3
		};
	}

	public static void Save(BinaryWriter bw, TargetParam param)
	{
		bw.Write((uint)param.Target);
		if (param.Target == EnumTarget.occupation_list)
		{
			bw.Write(param.Occupations);
		}
		if (param.Target == EnumTarget.t_random_in_range)
		{
			bw.Write(param.Players);
		}
		if (param.Target == EnumTarget.t_nearest_in_range)
		{
			bw.Write(param.Players);
		}
		if (param.Target == EnumTarget.t_farthest_in_range)
		{
			bw.Write(param.Players);
		}
		if (param.Target == EnumTarget.unk_18)
		{
			bw.Write(param.Players);
			bw.Write(param.Unk2);
			bw.Write(param.Unk3);
		}
		if (param.Target == EnumTarget.unk_20)
		{
			bw.Write(param.Players);
			bw.Write(param.Unk2);
			bw.Write(param.Unk3);
			bw.Write(param.Unk4);
		}
	}
}
