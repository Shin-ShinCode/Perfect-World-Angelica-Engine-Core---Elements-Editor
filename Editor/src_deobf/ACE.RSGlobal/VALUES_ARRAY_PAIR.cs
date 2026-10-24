namespace ACE.RSGlobal;

public class VALUES_ARRAY_PAIR
{
	public decimal[] realvalues;

	public string[] decodedvalues;

	public VALUES_ARRAY_PAIR(string[] decodedvalues, decimal[] realvalues)
	{
		this.realvalues = realvalues;
		this.decodedvalues = decodedvalues;
	}

	public VALUES_ARRAY_PAIR(int count)
	{
		realvalues = new decimal[count];
		decodedvalues = new string[count];
	}
}
