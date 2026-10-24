namespace ACE.Classes;

public class PARTINFO
{
	public PARTTYPE type;

	public int index;

	public PARTINFO(PARTTYPE type, int index)
	{
		this.type = type;
		this.index = index;
	}

	public PARTINFO()
	{
	}
}
