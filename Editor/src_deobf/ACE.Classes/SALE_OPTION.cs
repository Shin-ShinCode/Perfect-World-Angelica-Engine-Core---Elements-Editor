namespace ACE.Classes;

public class SALE_OPTION
{
	public uint Price;

	public uint ExpireDate;

	public uint Duration;

	public uint StartDate;

	public int ControlType;

	public uint Day;

	public uint Status;

	public uint Flags;

	public uint MinVipLevel;

	public SALE_OPTION Clone()
	{
		return new SALE_OPTION
		{
			Price = Price,
			ExpireDate = ExpireDate,
			Duration = Duration,
			StartDate = StartDate,
			ControlType = ControlType,
			Day = Day,
			Status = Status,
			Flags = Flags,
			MinVipLevel = MinVipLevel
		};
	}
}
