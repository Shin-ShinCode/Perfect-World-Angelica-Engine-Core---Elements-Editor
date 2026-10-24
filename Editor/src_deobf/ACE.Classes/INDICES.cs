namespace ACE.Classes;

public struct INDICES
{
	public int int_0;

	public int int_1;

	public int int_2;

	public INDICES(int int_3, int int_4, int int_5)
	{
		int_0 = int_3;
		int_1 = int_4;
		int_2 = int_5;
	}

	public INDICES(int int_3, int int_4)
	{
		int_2 = 0;
		int_0 = int_3;
		int_1 = int_4;
	}

	public INDICES(int int_3)
	{
		int_1 = 0;
		int_2 = 0;
		int_0 = int_3;
	}
}
