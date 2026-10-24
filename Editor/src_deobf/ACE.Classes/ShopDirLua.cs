using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ACE.GShop;
using ACE.RSGlobal;

namespace ACE.Classes;

public class ShopDirLua
{
	public string BeforeDirs;

	public string AfterDirs;

	public SHOP_CATEGORY_FW Root;

	public string fn;

	public bool FileChanged;

	public ShopDirLua(string fn)
	{
		FileChanged = false;
		Load(fn);
	}

	public void Load(string fn)
	{
		if (!File.Exists(fn))
		{
			GC.KeepAlive(this);
			return;
		}
		this.fn = fn;
		StreamReader streamReader = new StreamReader(fn);
		string text = streamReader.ReadToEnd();
		int num = text.IndexOf(Class16.smethod_0(1648901791)) - 2;
		BeforeDirs = text.Substring(0, num);
		int num2 = text.IndexOf(Class16.smethod_0(1648908124), num) + 1;
		int num3 = global::ACE.RSGlobal.RSGlobal.FindCloseSymbolIndex(text, Class16.smethod_0(1648908124), Class16.smethod_0(1648908132), num2);
		string sCategory = text.Substring(num2, num3 - num2);
		Root = new SHOP_CATEGORY_FW(sCategory);
		AfterDirs = text.Substring(num3 + 3);
		streamReader.Close();
		GC.KeepAlive(this);
	}

	public void Save()
	{
		File.Copy(fn, fn + Class16.smethod_0(1648898363), overwrite: true);
		StreamWriter streamWriter = new StreamWriter(fn, append: false, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
		streamWriter.Write(BeforeDirs);
		streamWriter.WriteLine();
		streamWriter.WriteLine(Class16.smethod_0(1648901807));
		streamWriter.WriteLine(Root.GetLua(1));
		streamWriter.WriteLine(Class16.smethod_0(1648908132));
		streamWriter.Write(AfterDirs);
		streamWriter.Close();
		FileChanged = false;
	}

	public List<ITEM_CATEGORY_POS> GetItemCategories(int id)
	{
		List<ITEM_CATEGORY_POS> list = new List<ITEM_CATEGORY_POS>();
		int num = 0;
		if (0 < Root.SubCategories.Count)
		{
			do
			{
				SHOP_CATEGORY_FW sHOP_CATEGORY_FW = Root.SubCategories[num];
				List<int> items = sHOP_CATEGORY_FW.Items;
				if (items != null)
				{
					int num2 = 0;
					if (0 < items.Count)
					{
						do
						{
							if (sHOP_CATEGORY_FW.Items[num2] == id)
							{
								list.Add(new ITEM_CATEGORY_POS(sHOP_CATEGORY_FW, num, -1, -1, num2));
							}
							num2++;
						}
						while (num2 < sHOP_CATEGORY_FW.Items.Count);
					}
				}
				int num3 = 0;
				if (0 < sHOP_CATEGORY_FW.SubCategories.Count)
				{
					do
					{
						SHOP_CATEGORY_FW sHOP_CATEGORY_FW2 = sHOP_CATEGORY_FW.SubCategories[num3];
						List<int> items2 = sHOP_CATEGORY_FW2.Items;
						if (items2 != null)
						{
							int num4 = 0;
							if (0 < items2.Count)
							{
								do
								{
									if (sHOP_CATEGORY_FW2.Items[num4] == id)
									{
										list.Add(new ITEM_CATEGORY_POS(sHOP_CATEGORY_FW2, num, num3, -1, num4));
									}
									num4++;
								}
								while (num4 < sHOP_CATEGORY_FW2.Items.Count);
							}
						}
						int num5 = 0;
						if (0 < sHOP_CATEGORY_FW2.SubCategories.Count)
						{
							do
							{
								SHOP_CATEGORY_FW sHOP_CATEGORY_FW3 = sHOP_CATEGORY_FW2.SubCategories[num5];
								List<int> items3 = sHOP_CATEGORY_FW3.Items;
								if (items3 != null)
								{
									int num6 = 0;
									if (0 < items3.Count)
									{
										do
										{
											if (sHOP_CATEGORY_FW3.Items[num6] == id)
											{
												list.Add(new ITEM_CATEGORY_POS(sHOP_CATEGORY_FW3, num, num3, num5, num6));
											}
											num6++;
										}
										while (num6 < sHOP_CATEGORY_FW3.Items.Count);
									}
								}
								num5++;
							}
							while (num5 < sHOP_CATEGORY_FW2.SubCategories.Count);
						}
						num3++;
					}
					while (num3 < sHOP_CATEGORY_FW.SubCategories.Count);
				}
				num++;
			}
			while (num < Root.SubCategories.Count);
		}
		GC.KeepAlive(this);
		return list;
	}

	public string GetSubCatName(ITEM_CATEGORY_POS CatPos, int deep)
	{
		if (deep <= CatPos.deep)
		{
			return GetSubCat(CatPos, deep).Name;
		}
		return string.Empty;
	}

	public SHOP_CATEGORY_FW GetSubCat(ITEM_CATEGORY_POS CatPos, int deep)
	{
		if (deep > CatPos.deep)
		{
			return null;
		}
		switch (deep)
		{
		default:
			GC.KeepAlive(this);
			return null;
		case 1:
		{
			SHOP_CATEGORY_FW result3 = Root.SubCategories[CatPos.pos1];
			GC.KeepAlive(this);
			return result3;
		}
		case 2:
		{
			int pos3 = CatPos.pos2;
			SHOP_CATEGORY_FW result2 = Root.SubCategories[CatPos.pos1].SubCategories[pos3];
			GC.KeepAlive(this);
			return result2;
		}
		case 3:
		{
			int pos = CatPos.pos3;
			int pos2 = CatPos.pos2;
			SHOP_CATEGORY_FW result = Root.SubCategories[CatPos.pos1].SubCategories[pos2].SubCategories[pos];
			GC.KeepAlive(this);
			return result;
		}
		}
	}

	public SHOP_CATEGORY_FW GetSubCat(ITEM_CATEGORY_POS CatPos)
	{
		return GetSubCat(CatPos, CatPos.deep);
	}
}
