using ACE.Classes.ACE;

namespace ACE.Classes;

public struct REFERENCE_TYPE_EX
{
	public DATA_FILES_ENUM DataFileType;

	public ReferenceType SectionType;

	public ReferenceSubType SubType;

	public int param1;

	public int param2;

	public REFERENCE_TYPE_EX(DATA_FILES_ENUM DataFileType, ReferenceType RefSectionType, ReferenceSubType RefSubType, int param1, int param2)
	{
		this.DataFileType = DataFileType;
		SectionType = RefSectionType;
		SubType = RefSubType;
		this.param1 = param1;
		this.param2 = param2;
	}

	public REFERENCE_TYPE_EX(DATA_FILES_ENUM DataFileType, ReferenceType RefSectionType, int param1, int param2)
	{
		SubType = ReferenceSubType.NONE;
		this.DataFileType = DataFileType;
		SectionType = RefSectionType;
		this.param1 = param1;
		this.param2 = param2;
	}

	public REFERENCE_TYPE_EX(DATA_FILES_ENUM DataFileType, ReferenceType RefSectionType, int param1)
	{
		SubType = ReferenceSubType.NONE;
		this.DataFileType = DataFileType;
		SectionType = RefSectionType;
		this.param1 = param1;
		param2 = 0;
	}

	public REFERENCE_TYPE_EX(DATA_FILES_ENUM DataFileType, ReferenceType RefSectionType, ReferenceSubType RefSubType)
	{
		param1 = 0;
		param2 = 0;
		this.DataFileType = DataFileType;
		SectionType = RefSectionType;
		SubType = RefSubType;
	}

	public int GetTypeHash()
	{
		DATA_FILES_ENUM dataFileType = DataFileType;
		int num = (int)dataFileType * 1000000;
		if (dataFileType != DATA_FILES_ENUM.ELEMENTS && dataFileType != DATA_FILES_ENUM.NPCGEN)
		{
			return (int)SubType * 1000 + num;
		}
		return param1 * 1000 + param2 + num;
	}

	public override int GetHashCode()
	{
		return GetTypeHash();
	}
}
