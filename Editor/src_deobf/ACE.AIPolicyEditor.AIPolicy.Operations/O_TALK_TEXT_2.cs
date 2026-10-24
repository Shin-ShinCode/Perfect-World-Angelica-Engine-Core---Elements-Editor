using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_TALK_TEXT_2 : ICloneable, IOperation
{
	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private TargetParam targetParam_0;

	private string string_0;

	[Browsable(false)]
	public int FromVersion => 30;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value4")]
	public int iChannelID
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

	[LocalizedDisplayName("Value5")]
	[LocalizedCategory("OperationParam")]
	public int iChannelIDType
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value2")]
	public int iChannelKinds
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

	[LocalizedDisplayName("Value3")]
	[LocalizedCategory("OperationParam")]
	public int iChannelKindsType
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	[LocalizedDisplayName("Value1")]
	[LocalizedCategory("OperationParam")]
	public int Mask
	{
		[CompilerGenerated]
		get
		{
			return int_4;
		}
		[CompilerGenerated]
		set
		{
			int_4 = value;
		}
	}

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937181));

	[Browsable(false)]
	public int OperID => 53;

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

	public O_TALK_TEXT_2()
	{
		Text = string.Empty;
		Mask = 0;
		iChannelKinds = 0;
		iChannelKindsType = 0;
		iChannelID = 0;
		iChannelIDType = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_TALK_TEXT_2 o_TALK_TEXT_ = new O_TALK_TEXT_2();
		o_TALK_TEXT_.Text = Text;
		o_TALK_TEXT_.Mask = Mask;
		o_TALK_TEXT_.iChannelKinds = iChannelKinds;
		o_TALK_TEXT_.iChannelKindsType = iChannelKindsType;
		o_TALK_TEXT_.iChannelID = iChannelID;
		o_TALK_TEXT_.iChannelIDType = iChannelIDType;
		o_TALK_TEXT_.Target = Target.Clone() as TargetParam;
		return o_TALK_TEXT_;
	}

	public void Read(BinaryReader br)
	{
		int count = br.ReadInt32();
		Text = br.ReadBytes(count).ToUnicode();
		Mask = br.ReadInt32();
		iChannelKinds = br.ReadInt32();
		iChannelKindsType = br.ReadInt32();
		iChannelID = br.ReadInt32();
		iChannelIDType = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!Text.ToString().Contains(str) && !Mask.ToString().Contains(str) && !iChannelKinds.ToString().Contains(str) && !iChannelKindsType.ToString().Contains(str) && !iChannelID.ToString().Contains(str) && !iChannelIDType.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(Text);
		bytes = ((IEnumerable<byte>)bytes).Append((byte)0).ToArray();
		bytes = ((IEnumerable<byte>)bytes).Append((byte)0).ToArray();
		bw.Write(bytes.Length);
		bw.Write(bytes);
		bw.Write(Mask);
		bw.Write(iChannelKinds);
		bw.Write(iChannelKindsType);
		bw.Write(iChannelID);
		bw.Write(iChannelIDType);
		TargetStream.Save(bw, Target);
	}
}
