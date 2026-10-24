namespace ACE.Classes;

public class ITEMPOS_f
{
	public ITEMPOS ItemPos;

	public int int_0;

	public ITEMPOS_f(ITEMPOS ItemPos, int int_1)
	{
		this.ItemPos = ItemPos;
		int_0 = int_1;
	}

	public ITEMPOS_f()
	{
	}

	public ITEMPOS_f Clone()
	{
		ITEMPOS_f iTEMPOS_f = new ITEMPOS_f();
		ITEMPOS itemPos = ItemPos;
		if (itemPos != null)
		{
			ITEMPOS iTEMPOS = itemPos;
			iTEMPOS_f.ItemPos = new ITEMPOS(iTEMPOS.int_0, iTEMPOS.int_1);
		}
		iTEMPOS_f.int_0 = int_0;
		return iTEMPOS_f;
	}
}
