using System;

namespace ACE.GShop;

public class Category
{
	public string name;

	public uint SubCatsCount;

	public string[] SubCats;

	public void AddSubCat(int SubCatIndex, string SubCatName)
	{
		Array.Resize(ref SubCats, SubCatIndex + 1);
		int num = (int)SubCatsCount;
		if (num < (nint)SubCats.LongLength)
		{
			do
			{
				SubCats[num] = SubCatName;
				num++;
			}
			while (num < (nint)SubCats.LongLength);
		}
		SubCatsCount = (uint)SubCats.Length;
	}
}
