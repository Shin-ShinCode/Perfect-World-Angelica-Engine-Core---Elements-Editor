namespace ACE.Classes;

public class IMPORT_RESULT
{
	public IMPORT_RESULT_LIST ResultList;

	public int iAddedItems;

	public int iReplacedItems;

	public int iSkippedItems;

	public int iAddedSubitems;

	public bool bSomeSubitemsDupliacted;

	public int iTotalAddedItems => iAddedSubitems + iAddedItems;

	public int iTotalItems
	{
		get
		{
			int num = iSkippedItems;
			return iChangedItems + num;
		}
	}

	public int iChangedItems => iAddedSubitems + iReplacedItems + iAddedItems;
}
