using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_106 : ICloneable, IOperation
{
	private ChatChannels2 chatChannels2_0;

	private string string_0;

	private TargetParam targetParam_0;

	private TalkTextAppendDataMask talkTextAppendDataMask_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9;

	private int int_10;

	private int int_11;

	private int int_12;

	private int int_13;

	[LocalizedDisplayName("ChatChannel")]
	[LocalizedCategory("OperationParam")]
	public ChatChannels2 ChatChannel
	{
		[CompilerGenerated]
		get
		{
			return chatChannels2_0;
		}
		[CompilerGenerated]
		set
		{
			chatChannels2_0 = value;
		}
	}

	[Browsable(false)]
	public int FromVersion => 40;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648938111));

	[Browsable(false)]
	public int OperID => 106;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("szData")]
	public string szData
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

	[LocalizedDisplayName("uAppendDataMask")]
	[LocalizedCategory("OperationParam")]
	public TalkTextAppendDataMask uAppendDataMask
	{
		[CompilerGenerated]
		get
		{
			return talkTextAppendDataMask_0;
		}
		[CompilerGenerated]
		set
		{
			talkTextAppendDataMask_0 = value;
		}
	}

	[LocalizedDisplayName("uSize")]
	[LocalizedCategory("OperationParam")]
	public int uSize
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

	[LocalizedDisplayName("Value1")]
	[LocalizedCategory("OperationParam")]
	public int Value1
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

	[LocalizedDisplayName("Value10")]
	[LocalizedCategory("OperationParam")]
	public int Value10
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value11")]
	public int Value11
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

	[LocalizedDisplayName("Value12")]
	[LocalizedCategory("OperationParam")]
	public int Value12
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value13")]
	public int Value13
	{
		[CompilerGenerated]
		get
		{
			return int_5;
		}
		[CompilerGenerated]
		set
		{
			int_5 = value;
		}
	}

	[LocalizedDisplayName("Value2")]
	[LocalizedCategory("OperationParam")]
	public int Value2
	{
		[CompilerGenerated]
		get
		{
			return int_6;
		}
		[CompilerGenerated]
		set
		{
			int_6 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value3")]
	public int Value3
	{
		[CompilerGenerated]
		get
		{
			return int_7;
		}
		[CompilerGenerated]
		set
		{
			int_7 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("Value4")]
	public int Value4
	{
		[CompilerGenerated]
		get
		{
			return int_8;
		}
		[CompilerGenerated]
		set
		{
			int_8 = value;
		}
	}

	[LocalizedDisplayName("Value5")]
	[LocalizedCategory("OperationParam")]
	public int Value5
	{
		[CompilerGenerated]
		get
		{
			return int_9;
		}
		[CompilerGenerated]
		set
		{
			int_9 = value;
		}
	}

	[LocalizedDisplayName("Value6")]
	[LocalizedCategory("OperationParam")]
	public int Value6
	{
		[CompilerGenerated]
		get
		{
			return int_10;
		}
		[CompilerGenerated]
		set
		{
			int_10 = value;
		}
	}

	[LocalizedDisplayName("Value7")]
	[LocalizedCategory("OperationParam")]
	public int Value7
	{
		[CompilerGenerated]
		get
		{
			return int_11;
		}
		[CompilerGenerated]
		set
		{
			int_11 = value;
		}
	}

	[LocalizedDisplayName("Value8")]
	[LocalizedCategory("OperationParam")]
	public int Value8
	{
		[CompilerGenerated]
		get
		{
			return int_12;
		}
		[CompilerGenerated]
		set
		{
			int_12 = value;
		}
	}

	[LocalizedDisplayName("Value9")]
	[LocalizedCategory("OperationParam")]
	public int Value9
	{
		[CompilerGenerated]
		get
		{
			return int_13;
		}
		[CompilerGenerated]
		set
		{
			int_13 = value;
		}
	}

	public O_106()
	{
		szData = string.Empty;
		uSize = 0;
		ChatChannel = ChatChannels2.Normal;
		uAppendDataMask = TalkTextAppendDataMask.None;
		Value1 = 0;
		Value2 = 0;
		Value3 = 0;
		Value4 = 0;
		Value5 = 0;
		Value6 = 0;
		Value7 = 0;
		Value8 = 0;
		Value9 = 0;
		Value10 = 0;
		Value11 = 0;
		Value12 = 0;
		Value13 = 0;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_106 o_ = new O_106();
		o_.szData = szData;
		o_.uAppendDataMask = uAppendDataMask;
		o_.Value1 = Value1;
		o_.Value2 = Value2;
		o_.Value3 = Value3;
		o_.Value4 = Value4;
		o_.Value5 = Value5;
		o_.Value6 = Value6;
		o_.Value7 = Value7;
		o_.Value8 = Value8;
		o_.Value9 = Value9;
		o_.Value10 = Value10;
		o_.Value11 = Value11;
		o_.Value12 = Value12;
		o_.Value13 = Value13;
		o_.Target = Target.Clone() as TargetParam;
		return o_;
	}

	public void Read(BinaryReader br)
	{
		int count = br.ReadInt32();
		szData = br.ReadBytes(count).ToUnicode();
		if (szData.StartsWith(Class16.smethod_0(1648938114)))
		{
			string text = szData.Substring(0, 2);
			if (text != null)
			{
				int length = text.Length;
				if (length == 2)
				{
					char c = text[1];
					if ((uint)c <= 70u)
					{
						if (c != 'A')
						{
							if (c != 'B')
							{
								if (c != 'F' || !(text == Class16.smethod_0(1648938122)))
								{
									goto IL_0162;
								}
								ChatChannel = ChatChannels2.Faction;
							}
							else
							{
								if (!(text == Class16.smethod_0(1648938157)))
								{
									goto IL_0162;
								}
								ChatChannel = ChatChannels2.Broadcast;
							}
						}
						else
						{
							if (!(text == Class16.smethod_0(1648938148)))
							{
								goto IL_0162;
							}
							ChatChannel = ChatChannels2.Anonymous;
						}
					}
					else if ((uint)c <= 83u)
					{
						if (c != 'I')
						{
							if (c != 'S' || !(text == Class16.smethod_0(1648938131)))
							{
								goto IL_0162;
							}
							ChatChannel = ChatChannels2.System;
						}
						else
						{
							if (!(text == Class16.smethod_0(1648938166)))
							{
								goto IL_0162;
							}
							ChatChannel = ChatChannels2.Instance;
						}
					}
					else if (c != 'W')
					{
						if (c != 'X' || !(text == Class16.smethod_0(1648938175)))
						{
							goto IL_0162;
						}
						ChatChannel = ChatChannels2.InstanceCenterScreen;
					}
					else
					{
						if (!(text == Class16.smethod_0(1648938176)))
						{
							goto IL_0162;
						}
						ChatChannel = ChatChannels2.Whisper;
					}
					goto IL_0172;
				}
			}
			goto IL_0162;
		}
		ChatChannel = ChatChannels2.Normal;
		goto IL_0172;
		IL_0162:
		ChatChannel = ChatChannels2.Normal;
		goto IL_0172;
		IL_0172:
		if (ChatChannel != ChatChannels2.Normal)
		{
			szData = szData.Remove(0, 2);
		}
		uAppendDataMask = (TalkTextAppendDataMask)br.ReadInt32();
		Value1 = br.ReadInt32();
		Value2 = br.ReadInt32();
		Value3 = br.ReadInt32();
		Value4 = br.ReadInt32();
		Value5 = br.ReadInt32();
		Value6 = br.ReadInt32();
		Value7 = br.ReadInt32();
		Value8 = br.ReadInt32();
		Value9 = br.ReadInt32();
		Value10 = br.ReadInt32();
		Value11 = br.ReadInt32();
		Value12 = br.ReadInt32();
		Value13 = br.ReadInt32();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!Value1.ToString().Contains(str) && !Value2.ToString().Contains(str) && !Value3.ToString().Contains(str) && !Value4.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public void Write(BinaryWriter bw)
	{
		string text = string.Empty;
		switch (ChatChannel)
		{
		case ChatChannels2.Faction:
			text = Class16.smethod_0(1648938122);
			break;
		case ChatChannels2.Anonymous:
			text = Class16.smethod_0(1648938148);
			break;
		case ChatChannels2.Broadcast:
			text = Class16.smethod_0(1648938157);
			break;
		case ChatChannels2.Instance:
			text = Class16.smethod_0(1648938166);
			break;
		case ChatChannels2.System:
			text = Class16.smethod_0(1648938131);
			break;
		case ChatChannels2.InstanceCenterScreen:
			text = Class16.smethod_0(1648938175);
			break;
		case ChatChannels2.Whisper:
			text = Class16.smethod_0(1648938176);
			break;
		}
		byte[] bytes = Encoding.Unicode.GetBytes(text + szData + Class16.smethod_0(1648938185));
		bw.Write(bytes.Length);
		bw.Write(bytes);
		bw.Write(Convert.ToUInt32(uAppendDataMask));
		bw.Write(Value1);
		bw.Write(Value2);
		bw.Write(Value3);
		bw.Write(Value4);
		bw.Write(Value5);
		bw.Write(Value6);
		bw.Write(Value7);
		bw.Write(Value8);
		bw.Write(Value9);
		bw.Write(Value10);
		bw.Write(Value11);
		bw.Write(Value12);
		bw.Write(Value13);
		TargetStream.Save(bw, Target);
	}
}
