using System.ComponentModel;
using ACE.Classes;

namespace ACE.Settings;

public class LCategory : CategoryAttribute
{
	public static TextStorage Texts;

	public string CatName;

	public int CatPos;

	public int CharCount;

	public sbyte NonPrintableChar = 9;

	public LCategory(string CatName, int CatPos)
		: base(CatName)
	{
		this.CatPos = CatPos;
		this.CatName = CatName;
		switch (CatPos)
		{
		case -2:
			CharCount = 0;
			break;
		case -1:
			CharCount = 0;
			break;
		default:
			CharCount = 2;
			break;
		case 1:
			CharCount = 3;
			break;
		}
	}

	public LCategory(string CatName)
		: base(CatName)
	{
		this.CatName = CatName;
		CharCount = 1;
	}
}
