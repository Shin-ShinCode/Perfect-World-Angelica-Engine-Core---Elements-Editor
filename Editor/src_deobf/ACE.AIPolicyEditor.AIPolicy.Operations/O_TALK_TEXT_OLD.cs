using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_TALK_TEXT_OLD : ICloneable, IOperation
{
	private TargetParam targetParam_0;

	private string string_0;

	[Browsable(false)]
	public int FromVersion => 1;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937172));

	[Browsable(false)]
	public int OperID => 2;

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

	public O_TALK_TEXT_OLD()
	{
		Text = string.Empty;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_TALK_TEXT_OLD o_TALK_TEXT_OLD = new O_TALK_TEXT_OLD();
		o_TALK_TEXT_OLD.Text = Text;
		o_TALK_TEXT_OLD.Target = Target.Clone() as TargetParam;
		return o_TALK_TEXT_OLD;
	}

	public void Read(BinaryReader br)
	{
		int count = br.ReadInt32();
		Text = br.ReadBytes(count).ToUnicode();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (Text.Contains(str))
		{
			return true;
		}
		return false;
	}

	public void Write(BinaryWriter bw)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(Text + Class16.smethod_0(1648938185));
		bw.Write(bytes.Length);
		bw.Write(bytes);
		TargetStream.Save(bw, Target);
	}
}
