using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.AIPolicyEditor.AIPolicy;

public class CPolicyData : ICloneable
{
	private static int int_0;

	private int int_1;

	private ObservableCollection<CTriggerData> observableCollection_0;

	private int int_2;

	public static int MaxVersion
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

	public int ID
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public ObservableCollection<CTriggerData> Triggers
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

	public int Version
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public CPolicyData()
	{
		Version = 0;
		ID = 0;
		Triggers = new ObservableCollection<CTriggerData>();
	}

	public object Clone()
	{
		CPolicyData cPolicyData = new CPolicyData
		{
			Version = Version,
			ID = ID
		};
		foreach (CTriggerData trigger in Triggers)
		{
			cPolicyData.Triggers.Add(trigger.Clone() as CTriggerData);
		}
		return cPolicyData;
	}

	public void Read(BinaryReader br)
	{
		Version = br.ReadInt32();
		if (MaxVersion < Version)
		{
			MaxVersion = Version;
		}
		ID = br.ReadInt32();
		int num = br.ReadInt32();
		Triggers = new ObservableCollection<CTriggerData>();
		for (int i = 0; i < num; i++)
		{
			CTriggerData cTriggerData = new CTriggerData();
			cTriggerData.Read(br);
			Triggers.Add(cTriggerData);
		}
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(Version);
		bw.Write(ID);
		bw.Write(Triggers.Count);
		for (int i = 0; i < Triggers.Count; i++)
		{
			Triggers[i].Write(bw);
		}
	}

	public override string ToString()
	{
		return ID.ToString();
	}
}
