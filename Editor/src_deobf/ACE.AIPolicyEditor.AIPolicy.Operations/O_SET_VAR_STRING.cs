using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class O_SET_VAR_STRING : ICloneable, IOperation
{
	private int int_0;

	private ChatChannels2 chatChannels2_0;

	private string string_0;

	private TalkTextAppendDataMask talkTextAppendDataMask_0;

	private TargetParam targetParam_0;

	[Browsable(false)]
	public int FromVersion => 100;

	[Browsable(false)]
	public int OperID => 202;

	[Browsable(false)]
	public string Name => MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648937043));

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("iKey")]
	public int iKey
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

	[LocalizedCategory("OperationParam")]
	[LocalizedDisplayName("AppendDataMask")]
	public TalkTextAppendDataMask AppendDataMask
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

	[LocalizedDisplayName("Target")]
	[LocalizedCategory("TargetParam")]
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

	public O_SET_VAR_STRING()
	{
		iKey = 0;
		ChatChannel = ChatChannels2.Normal;
		Text = string.Empty;
		AppendDataMask = TalkTextAppendDataMask.None;
		Target = new TargetParam();
	}

	public void Read(BinaryReader br)
	{
		iKey = br.ReadInt32();
		int count = br.ReadInt32();
		Text = br.ReadBytes(count).ToUnicode();
		if (Text.StartsWith(Class16.smethod_0(1648938114)))
		{
			string text = Text.Substring(0, 2);
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
									goto IL_016e;
								}
								ChatChannel = ChatChannels2.Faction;
							}
							else
							{
								if (!(text == Class16.smethod_0(1648938157)))
								{
									goto IL_016e;
								}
								ChatChannel = ChatChannels2.Broadcast;
							}
						}
						else
						{
							if (!(text == Class16.smethod_0(1648938148)))
							{
								goto IL_016e;
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
								goto IL_016e;
							}
							ChatChannel = ChatChannels2.System;
						}
						else
						{
							if (!(text == Class16.smethod_0(1648938166)))
							{
								goto IL_016e;
							}
							ChatChannel = ChatChannels2.Instance;
						}
					}
					else if (c != 'W')
					{
						if (c != 'X' || !(text == Class16.smethod_0(1648938175)))
						{
							goto IL_016e;
						}
						ChatChannel = ChatChannels2.InstanceCenterScreen;
					}
					else
					{
						if (!(text == Class16.smethod_0(1648938176)))
						{
							goto IL_016e;
						}
						ChatChannel = ChatChannels2.Whisper;
					}
					goto IL_017e;
				}
			}
			goto IL_016e;
		}
		ChatChannel = ChatChannels2.Normal;
		goto IL_017e;
		IL_016e:
		ChatChannel = ChatChannels2.Normal;
		goto IL_017e;
		IL_017e:
		if (ChatChannel != ChatChannels2.Normal)
		{
			Text = Text.Remove(0, 2);
		}
		AppendDataMask = (TalkTextAppendDataMask)br.ReadUInt32();
		Target = TargetStream.Read(br);
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(iKey);
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
		byte[] bytes = Encoding.Unicode.GetBytes(text + Text + Class16.smethod_0(1648938185));
		bw.Write(bytes.Length);
		bw.Write(bytes);
		bw.Write(Convert.ToUInt32(AppendDataMask));
		TargetStream.Save(bw, Target);
	}

	public bool Search(string str)
	{
		if (!Text.Contains(str) && !AppendDataMask.ToString().Contains(str) && !iKey.ToString().Contains(str))
		{
			return false;
		}
		return true;
	}

	public object Clone()
	{
		O_SET_VAR_STRING o_SET_VAR_STRING = new O_SET_VAR_STRING();
		o_SET_VAR_STRING.iKey = iKey;
		o_SET_VAR_STRING.Text = Text;
		o_SET_VAR_STRING.AppendDataMask = AppendDataMask;
		o_SET_VAR_STRING.Target = Target.Clone() as TargetParam;
		return o_SET_VAR_STRING;
	}
}
