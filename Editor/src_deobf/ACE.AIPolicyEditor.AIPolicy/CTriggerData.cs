using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.AIPolicyEditor.AIPolicy;

public class CTriggerData : ICloneable
{
	private static int int_0;

	private bool bool_0;

	private bool bool_1;

	private int int_1;

	private string string_0;

	private ObservableCollection<IOperation> observableCollection_0;

	private Condition condition_0;

	private bool bool_2;

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

	public bool Active
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public bool AttackValid
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

	public string Name
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

	public ObservableCollection<IOperation> Operations
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

	public Condition RootConditon
	{
		[CompilerGenerated]
		get
		{
			return condition_0;
		}
		[CompilerGenerated]
		set
		{
			condition_0 = value;
		}
	}

	public bool Run
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
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

	public string DisplayText => string.Format(Class16.smethod_0(1648942820), ID, Name);

	public CTriggerData()
	{
		Version = 0;
		Name = Class16.smethod_0(1648942794);
		Active = false;
		Run = false;
		AttackValid = false;
		ID = 1;
		RootConditon = new Condition();
		Operations = new ObservableCollection<IOperation>();
	}

	public object Clone()
	{
		CTriggerData cTriggerData = new CTriggerData();
		cTriggerData.Version = Version;
		cTriggerData.ID = ID;
		cTriggerData.Active = Active;
		cTriggerData.Run = Run;
		cTriggerData.AttackValid = AttackValid;
		cTriggerData.Name = Name;
		cTriggerData.RootConditon = (RootConditon?.Clone() as Condition) ?? new Condition();
		CTriggerData cTriggerData2 = cTriggerData;
		foreach (IOperation operation in Operations)
		{
			if (operation is ICloneable cloneable)
			{
				cTriggerData2.Operations.Add(cloneable.Clone() as IOperation);
			}
		}
		return cTriggerData2;
	}

	public void Read(BinaryReader br)
	{
		Version = br.ReadInt32();
		if (MaxVersion < Version)
		{
			MaxVersion = Version;
		}
		ID = br.ReadInt32();
		Active = br.ReadBoolean();
		Run = br.ReadBoolean();
		AttackValid = br.ReadBoolean();
		Name = br.ReadBytes(128).ToGBK();
		RootConditon = new Condition();
		RootConditon.Read(br);
		int num = br.ReadInt32();
		Operations = new ObservableCollection<IOperation>();
		for (int i = 0; i < num; i++)
		{
			int id = br.ReadInt32();
			IOperation item = Operation.Read(br, Version, id);
			Operations.Add(item);
		}
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(Version);
		bw.Write(ID);
		bw.Write(Active);
		bw.Write(Run);
		bw.Write(AttackValid);
		bw.Write(Name.FromGBK(128));
		RootConditon.Save(bw);
		bw.Write(Operations.Count);
		for (int i = 0; i < Operations.Count; i++)
		{
			bw.Write(Operations[i].OperID);
			Operations[i].Write(bw);
		}
	}

	public override string ToString()
	{
		return DisplayText;
	}
}
