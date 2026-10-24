using System;

namespace ACE.AIPolicyEditor.AIPolicy;

[Flags]
public enum TalkTextAppendDataMask : uint
{
	None = 0u,
	Name = 1u,
	LocalVar0 = 2u,
	LocalVar1 = 4u,
	LocalVar2 = 8u,
	TalkingName = 0x10u,
	IdIcon = 0x20u,
	FactionName = 0x200u,
	Interface = 0x400u,
	Num = 0x401u
}
