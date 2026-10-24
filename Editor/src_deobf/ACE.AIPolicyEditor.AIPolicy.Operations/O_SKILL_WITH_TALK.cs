using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_SKILL_WITH_TALK : IOperation
{
	private int int_0;

	private TargetParam targetParam_0;

	private string string_0;

	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	[Browsable(false)]
	public int FromVersion => 24;

	[LocalizedDisplayName("Mask")]
	[LocalizedCategory("OperationParam")]
	public int Mask
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

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937062));

	[Browsable(false)]
	public int OperID => 36;

	[LocalizedCategory("TargetParam")]
	[LocalizedDisplayName("Target")]
	public TargetParam Target
	{
		[CompilerGenerated]
		get
		{
			return targetParam_0;
		}
		[CompilerGenerated]
		set
		{
			targetParam_0 = value;
		}
	}

	[LocalizedDisplayName("Text")]
	[LocalizedCategory("OperationParam")]
	public string Text
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

	[LocalizedDisplayName("uLevel")]
	[LocalizedCategory("OperationParam")]
	public uint uLevel
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value3")]
	public uint uLevelType
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

	[LocalizedDisplayName("uSkill")]
	[LocalizedCategory("OperationParam")]
	public uint uSkill
	{
		[CompilerGenerated]
		get
		{
			return uint_2;
		}
		[CompilerGenerated]
		set
		{
			uint_2 = value;
		}
	}

	[LocalizedDisplayName("uSkillType")]
	[LocalizedCategory("OperationParam")]
	public uint uSkillType
	{
		[CompilerGenerated]
		get
		{
			return uint_3;
		}
		[CompilerGenerated]
		set
		{
			uint_3 = value;
		}
	}

	public O_SKILL_WITH_TALK()
	{
		uSkill = 0u;
		uSkillType = 0u;
		uLevel = 0u;
		uLevelType = 0u;
		Text = string.Empty;
		Mask = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_SKILL_WITH_TALK o_SKILL_WITH_TALK = new O_SKILL_WITH_TALK();
		o_SKILL_WITH_TALK.uSkill = uSkill;
		o_SKILL_WITH_TALK.uSkillType = uSkillType;
		o_SKILL_WITH_TALK.uLevel = uLevel;
		o_SKILL_WITH_TALK.uLevelType = uLevelType;
		o_SKILL_WITH_TALK.Text = Text;
		o_SKILL_WITH_TALK.Mask = Mask;
		o_SKILL_WITH_TALK.Target = Target.Clone() as TargetParam;
		return o_SKILL_WITH_TALK;
	}

	public void Read(BinaryReader br)
	{
		uSkill = br.ReadUInt32();
		uSkillType = br.ReadUInt32();
		uLevel = br.ReadUInt32();
		uLevelType = br.ReadUInt32();
		int count = br.ReadInt32();
		Text = br.ReadBytes(count).ToUnicode();
		Mask = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!Text.ToString().Contains(str) && !uSkill.ToString().Contains(str) && !uSkillType.ToString().Contains(str) && !uLevel.ToString().Contains(str) && !uLevelType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(uSkill);
		bw.Write(uSkillType);
		bw.Write(uLevel);
		bw.Write(uLevelType);
		byte[] bytes = Encoding.Unicode.GetBytes(Text);
		bytes = ((IEnumerable<byte>)bytes).Append((byte)0).ToArray();
		bytes = ((IEnumerable<byte>)bytes).Append((byte)0).ToArray();
		bw.Write(bytes.Length);
		bw.Write(bytes);
		bw.Write(Mask);
		TargetStream.Save(bw, Target);
	}
}
