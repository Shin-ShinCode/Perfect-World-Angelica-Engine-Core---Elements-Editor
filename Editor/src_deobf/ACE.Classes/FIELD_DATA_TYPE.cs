namespace ACE.Classes;

public struct FIELD_DATA_TYPE(FIELD_DATA_TYPE_ENUM data_type, int size)
{
	public FIELD_DATA_TYPE_ENUM data_type = data_type;

	public int size = size;
}
