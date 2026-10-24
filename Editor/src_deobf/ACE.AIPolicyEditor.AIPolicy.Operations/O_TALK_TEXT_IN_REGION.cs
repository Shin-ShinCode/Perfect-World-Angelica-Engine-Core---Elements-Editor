using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_TALK_TEXT_IN_REGION : ICloneable, IOperation
{
	private ChatChannels2 chatChannels2_0;

	private string string_0;

	private TargetParam targetParam_0;

	private TalkTextAppendDataMask talkTextAppendDataMask_0;

	private int int_0;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("ChatChannel")]
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
	public int FromVersion => 33;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937191));

	[Browsable(false)]
	public int OperID => 72;

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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("uAppendDataMask")]
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("uSize")]
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("zvMax_X")]
	public float zvMax_X
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("zvMax_Y")]
	public float zvMax_Y
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
		[CompilerGenerated]
		set
		{
			float_1 = value;
		}
	}

	[LocalizedDisplayName("zvMax_Z")]
	[LocalizedCategory("OperationParam")]
	public float zvMax_Z
	{
		[CompilerGenerated]
		get
		{
			return float_2;
		}
		[CompilerGenerated]
		set
		{
			float_2 = value;
		}
	}

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("zvMin_X")]
	public float zvMin_X
	{
		[CompilerGenerated]
		get
		{
			return float_3;
		}
		[CompilerGenerated]
		set
		{
			float_3 = value;
		}
	}

	[LocalizedDisplayName("zvMin_Y")]
	[LocalizedCategory("OperationParam")]
	public float zvMin_Y
	{
		[CompilerGenerated]
		get
		{
			return float_4;
		}
		[CompilerGenerated]
		set
		{
			float_4 = value;
		}
	}

	[LocalizedDisplayName("zvMin_Z")]
	[LocalizedCategory("OperationParam")]
	public float zvMin_Z
	{
		[CompilerGenerated]
		get
		{
			return float_5;
		}
		[CompilerGenerated]
		set
		{
			float_5 = value;
		}
	}

	public O_TALK_TEXT_IN_REGION()
	{
		szData = string.Empty;
		uSize = 0;
		ChatChannel = ChatChannels2.Normal;
		uAppendDataMask = TalkTextAppendDataMask.None;
		zvMin_X = 0f;
		zvMin_Y = 0f;
		zvMin_Z = 0f;
		zvMax_X = 0f;
		zvMax_Y = 0f;
		zvMax_Z = 0f;
		Target = new TargetParam();
	}

	public object Clone()
	{
		O_TALK_TEXT_IN_REGION o_TALK_TEXT_IN_REGION = new O_TALK_TEXT_IN_REGION();
		o_TALK_TEXT_IN_REGION.szData = szData;
		o_TALK_TEXT_IN_REGION.ChatChannel = ChatChannel;
		o_TALK_TEXT_IN_REGION.uAppendDataMask = uAppendDataMask;
		o_TALK_TEXT_IN_REGION.zvMin_X = zvMin_X;
		o_TALK_TEXT_IN_REGION.zvMin_Y = zvMin_Y;
		o_TALK_TEXT_IN_REGION.zvMin_Z = zvMin_Z;
		o_TALK_TEXT_IN_REGION.zvMax_X = zvMax_X;
		o_TALK_TEXT_IN_REGION.zvMax_Y = zvMax_Y;
		o_TALK_TEXT_IN_REGION.zvMax_Z = zvMax_Z;
		o_TALK_TEXT_IN_REGION.Target = Target.Clone() as TargetParam;
		return o_TALK_TEXT_IN_REGION;
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
		zvMin_X = br.ReadSingle();
		zvMin_Y = br.ReadSingle();
		zvMin_Z = br.ReadSingle();
		zvMax_X = br.ReadSingle();
		zvMax_Y = br.ReadSingle();
		zvMax_Z = br.ReadSingle();
		Target = TargetStream.Read(br);
	}

	public bool Search(string str)
	{
		if (!szData.ToString().Contains(str) && !uAppendDataMask.ToString().Contains(str))
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
		bytes = ((IEnumerable<byte>)bytes).Append((byte)0).ToArray();
		bytes = ((IEnumerable<byte>)bytes).Append((byte)0).ToArray();
		bw.Write(bytes.Length);
		bw.Write(bytes);
		bw.Write(Convert.ToUInt32(uAppendDataMask));
		bw.Write(zvMin_X);
		bw.Write(zvMin_Y);
		bw.Write(zvMin_Z);
		bw.Write(zvMax_X);
		bw.Write(zvMax_Y);
		bw.Write(zvMax_Z);
		TargetStream.Save(bw, Target);
	}
}
