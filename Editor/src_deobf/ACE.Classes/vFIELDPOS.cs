using System;

namespace ACE.Classes;

[Serializable]
public struct vFIELDPOS
{
	public int int_0;

	public int int_1;

	public int int_2;

	public vFIELDPOS(ITEMPOS ItemPos, int FieldIndex)
	{
		int_0 = ItemPos.int_0;
		int_1 = ItemPos.int_1;
		int_2 = FieldIndex;
	}

	public vFIELDPOS(int ListIndex, int FieldIndex)
	{
		int_1 = 0;
		int_0 = ListIndex;
		int_2 = FieldIndex;
	}

	public vFIELDPOS(int ListIndex, int ItemIndex, int FieldIndex)
	{
		int_0 = ListIndex;
		int_1 = ItemIndex;
		int_2 = FieldIndex;
	}

	public FIELDPOS ToRef()
	{
		return new FIELDPOS(int_0, int_1, int_2);
	}
}
