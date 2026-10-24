using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ACE.Classes;
using ACE.Elements.eListCollection;
using ACE.Pck;
using ACE.RSGlobal;

namespace ACE.Models;

public class ModelExporter
{
	[Serializable]
	private sealed class Class240
	{
		public static readonly Class240 class240_0 = new Class240();

		public static Func<string, bool> func_0;

		internal bool method_0(string string_0)
		{
			if (!string.IsNullOrWhiteSpace(string_0))
			{
				return string_0.Contains('.');
			}
			return false;
		}
	}

	private PCK_LIST pck_LIST_0;

	private eListCollection eListCollection_0;

	private MODEL_VIEWER model_VIEWER_0;

	public ModelExporter(PCK_LIST pcks, eListCollection elc, MODEL_VIEWER modelViewer)
	{
		pck_LIST_0 = pcks;
		eListCollection_0 = elc;
		model_VIEWER_0 = modelViewer;
	}

	public List<ModelExportItem> BuildExportList(int[] selectedIndices, int listIndex)
	{
		List<ModelExportItem> list = new List<ModelExportItem>();
		ItemType listType = eListCollection_0.Lists[listIndex].ListType;
		foreach (int num in selectedIndices)
		{
			ModelExportItem modelExportItem = new ModelExportItem();
			modelExportItem.Id = (int)eListCollection_0.Lists[listIndex].elementValues[num][0];
			modelExportItem.Name = eListCollection_0.GetParsedItemName(new ITEMPOS(listIndex, num));
			modelExportItem.ListType = listType;
			modelExportItem.ListIndex = listIndex;
			modelExportItem.ElementIndex = num;
			int itemModelIndex = eListCollection_0.GetItemModelIndex(listIndex, num);
			if (itemModelIndex > 0)
			{
				modelExportItem.ModelPath = eListCollection_0.GetItemModelPath(listIndex, num);
			}
			list.Add(modelExportItem);
		}
		return list;
	}

	public void CollectFiles(ModelExportItem item)
	{
		if (string.IsNullOrWhiteSpace(item.ModelPath))
		{
			return;
		}
		string text = PCK.FixPath(item.ModelPath);
		if (!string.IsNullOrWhiteSpace(text))
		{
			if ((item.ListType == ItemType.PW_FASHION_ESSENCE || item.ListType == ItemType.PW_FASHION2_ESSENCE) && !text.Contains(Class16.smethod_0(1648927580)))
			{
				method_0(item, text);
			}
			else if (text.EndsWith(Class16.smethod_0(1648906325)))
			{
				method_2(item, text);
			}
			else
			{
				method_6(item, text);
			}
			item.CollectedFiles = item.CollectedFiles.Where(Class240.class240_0.method_0).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
		}
	}

	private void method_0(ModelExportItem modelExportItem_0, string string_0)
	{
		string[] array = new string[2]
		{
			Class16.smethod_0(1648994632),
			Class16.smethod_0(1648994641)
		};
		string[][] array2 = new string[2][]
		{
			new string[2]
			{
				Class16.smethod_0(1649121691),
				Class16.smethod_0(1649122519)
			},
			new string[2]
			{
				Class16.smethod_0(1649121704),
				Class16.smethod_0(1648995192)
			}
		};
		string[] array3 = new string[3]
		{
			Class16.smethod_0(1649121832),
			Class16.smethod_0(1649121725),
			Class16.smethod_0(1649121728)
		};
		string text = CommonStorage.AParams.ModelsPckBaseName;
		if (string.IsNullOrWhiteSpace(text))
		{
			text = Class16.smethod_0(1649138031);
		}
		for (int i = 0; i < array.Length; i++)
		{
			string text2 = text + Class16.smethod_0(1649121739) + array[i] + Class16.smethod_0(1648927580) + string_0;
			string[] array4 = array2[i];
			foreach (string text3 in array4)
			{
				string[] array5 = array3;
				foreach (string text4 in array5)
				{
					string text5 = text2 + Class16.smethod_0(1648927580) + text3 + string_0 + text4 + Class16.smethod_0(1648906306);
					modelExportItem_0.CollectedFiles.Add(text5);
					method_1(modelExportItem_0, text5, text2);
				}
			}
		}
	}

	private void method_1(ModelExportItem modelExportItem_0, string string_0, string string_1)
	{
		byte[] array = method_7(string_0);
		if (array == null || array.Length < 48)
		{
			return;
		}
		SKI sKI = new SKI(array);
		if (sKI.Textures == null)
		{
			return;
		}
		Encoding encoding = Encoding.GetEncoding(Class16.smethod_0(1648985403));
		byte[][] textures = sKI.Textures;
		foreach (byte[] bytes in textures)
		{
			string text = encoding.GetString(bytes).Trim(default(char)).ToLowerInvariant();
			if (!string.IsNullOrWhiteSpace(text))
			{
				modelExportItem_0.CollectedFiles.Add(string_1 + Class16.smethod_0(1649121904) + text);
				if (text.StartsWith(Class16.smethod_0(1649121770)))
				{
					modelExportItem_0.CollectedFiles.Add(string_1 + Class16.smethod_0(1649121788) + text);
				}
			}
		}
	}

	private void method_2(ModelExportItem modelExportItem_0, string string_0)
	{
		byte[] array = method_7(string_0);
		if (array == null || array.Length == 0)
		{
			return;
		}
		modelExportItem_0.CollectedFiles.Add(string_0);
		string text = Encoding.GetEncoding(936).GetString(array);
		List<string> list = text.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
		string directoryName = System.IO.Path.GetDirectoryName(string_0);
		object obj;
		if (directoryName == null)
		{
			obj = null;
		}
		else
		{
			obj = directoryName.Replace('/', '\\');
			if (obj != null)
			{
				goto IL_0071;
			}
		}
		obj = string.Empty;
		goto IL_0071;
		IL_0071:
		string text2 = (string)obj;
		string text3 = null;
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		List<string> list4 = new List<string>();
		List<string> list5 = new List<string>();
		foreach (string item in list)
		{
			string text4 = item.Trim();
			if (text4.StartsWith(Class16.smethod_0(1649121851)))
			{
				text3 = text4.Substring(14).Trim().ToLowerInvariant();
				if (!text3.Contains(Class16.smethod_0(1648927580)))
				{
					text3 = text2 + Class16.smethod_0(1648927580) + text3;
				}
			}
			else if (text4.StartsWith(Class16.smethod_0(1649121872)))
			{
				string text5 = text4.Substring(13).Trim().ToLowerInvariant();
				if (!string.IsNullOrWhiteSpace(text5))
				{
					list2.Add(text5);
				}
			}
			else if (text4.StartsWith(Class16.smethod_0(1649116680)))
			{
				string text6 = text4.Substring(10).Trim().ToLowerInvariant();
				if (!string.IsNullOrWhiteSpace(text6))
				{
					list3.Add(text6);
				}
			}
			else if (text4.StartsWith(Class16.smethod_0(1649116697)) && text4.EndsWith(Class16.smethod_0(1649119451)))
			{
				string text7 = text4.Substring(text4.IndexOf(':') + 1).Trim().ToLowerInvariant();
				if (!string.IsNullOrWhiteSpace(text7))
				{
					list4.Add(Class16.smethod_0(1649116714) + text7);
				}
			}
			else if (text4.StartsWith(Class16.smethod_0(1649116733)))
			{
				string text8 = text4.Substring(8).Trim().ToLowerInvariant();
				if (!string.IsNullOrWhiteSpace(text8))
				{
					list5.Add(Class16.smethod_0(1649116748) + text8);
				}
			}
		}
		if (!string.IsNullOrWhiteSpace(text3))
		{
			modelExportItem_0.CollectedFiles.Add(text3);
			method_3(modelExportItem_0, text3);
		}
		string text9 = string_0.Replace(Class16.smethod_0(1648906325), Class16.smethod_0(1648906306));
		modelExportItem_0.CollectedFiles.Add(text9);
		method_1(modelExportItem_0, text9, text2);
		modelExportItem_0.CollectedFiles.Add(string_0.Replace(Class16.smethod_0(1648906325), Class16.smethod_0(1649121921)));
		using (List<string>.Enumerator enumerator2 = list2.GetEnumerator())
		{
			string text10;
			object obj2;
			string string_1;
			for (; enumerator2.MoveNext(); string_1 = (string)obj2, method_4(modelExportItem_0, text10, string_1))
			{
				string current2 = enumerator2.Current;
				text10 = (current2.StartsWith(Class16.smethod_0(1649138031)) ? current2 : (Class16.smethod_0(1649116763) + current2));
				modelExportItem_0.CollectedFiles.Add(text10);
				string directoryName2 = System.IO.Path.GetDirectoryName(text10);
				if (directoryName2 == null)
				{
					obj2 = null;
				}
				else
				{
					obj2 = directoryName2.Replace('/', '\\');
					if (obj2 != null)
					{
						continue;
					}
				}
				obj2 = string.Empty;
			}
		}
		foreach (string item2 in list4)
		{
			method_5(modelExportItem_0, item2);
		}
		foreach (string item3 in list5)
		{
			modelExportItem_0.CollectedFiles.Add(item3);
		}
		foreach (string item4 in list3)
		{
			modelExportItem_0.CollectedFiles.Add(item4);
			method_2(modelExportItem_0, item4);
		}
	}

	private void method_3(ModelExportItem modelExportItem_0, string string_0)
	{
		byte[] array = method_7(string_0);
		if (array == null || array.Length == 0)
		{
			return;
		}
		string directoryName = System.IO.Path.GetDirectoryName(string_0);
		object obj;
		if (directoryName == null)
		{
			obj = null;
		}
		else
		{
			obj = directoryName.Replace('/', '\\');
			if (obj != null)
			{
				goto IL_0034;
			}
		}
		obj = string.Empty;
		goto IL_0034;
		IL_0034:
		string text = (string)obj;
		SMD sMD = new SMD();
		try
		{
			sMD.Load(new MemoryStream(array), bLoadAll: false);
		}
		catch
		{
			return;
		}
		Encoding encoding = Encoding.GetEncoding(Class16.smethod_0(1648985403));
		if (sMD.BonFile != null && sMD.BonFile.Length != 0)
		{
			string text2 = encoding.GetString(sMD.BonFile).Trim(default(char)).ToLowerInvariant();
			if (!string.IsNullOrWhiteSpace(text2))
			{
				modelExportItem_0.CollectedFiles.Add(text + Class16.smethod_0(1648927580) + text2);
			}
		}
		if (sMD.SkiFile != null && sMD.SkiFile.Length != 0)
		{
			string text3 = encoding.GetString(sMD.SkiFile).Trim(default(char)).ToLowerInvariant();
			if (!string.IsNullOrWhiteSpace(text3))
			{
				string text4 = text + Class16.smethod_0(1648927580) + text3;
				modelExportItem_0.CollectedFiles.Add(text4);
				method_4(modelExportItem_0, text4, text);
			}
		}
	}

	private void method_4(ModelExportItem modelExportItem_0, string string_0, string string_1)
	{
		byte[] array = method_7(string_0);
		if (array == null || array.Length < 48)
		{
			return;
		}
		SKI sKI = new SKI(array);
		if (sKI.Textures == null)
		{
			return;
		}
		Encoding encoding = Encoding.GetEncoding(Class16.smethod_0(1648985403));
		string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(string_0);
		string text = string_1 + Class16.smethod_0(1649121900) + fileNameWithoutExtension + Class16.smethod_0(1648927580);
		string text2 = string_1 + Class16.smethod_0(1649121904);
		byte[][] textures = sKI.Textures;
		foreach (byte[] bytes in textures)
		{
			string text3 = encoding.GetString(bytes).Trim(default(char)).ToLowerInvariant();
			if (!string.IsNullOrWhiteSpace(text3))
			{
				if (method_8(text + text3))
				{
					modelExportItem_0.CollectedFiles.Add(text + text3);
				}
				else
				{
					modelExportItem_0.CollectedFiles.Add(text2 + text3);
				}
			}
		}
	}

	private void method_5(ModelExportItem modelExportItem_0, string string_0)
	{
		byte[] array = method_7(string_0);
		if (array == null || array.Length == 0)
		{
			return;
		}
		modelExportItem_0.CollectedFiles.Add(string_0);
		string text = Encoding.GetEncoding(936).GetString(array);
		string[] array2 = text.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
		string[] array3 = array2;
		foreach (string text2 in array3)
		{
			string text3 = text2.Trim();
			if (text3.StartsWith(Class16.smethod_0(1649116777)))
			{
				string text4 = text3.Substring(8).Trim().ToLowerInvariant();
				if (!string.IsNullOrWhiteSpace(text4))
				{
					modelExportItem_0.CollectedFiles.Add(Class16.smethod_0(1649116792) + text4);
				}
			}
			else if (text3.StartsWith(Class16.smethod_0(1649116820)) && text3 != Class16.smethod_0(1649116837))
			{
				string text5 = text3.Substring(10).Trim().ToLowerInvariant();
				if (!string.IsNullOrWhiteSpace(text5))
				{
					modelExportItem_0.CollectedFiles.Add(Class16.smethod_0(1649116792) + text5);
				}
			}
			else if (text3.StartsWith(Class16.smethod_0(1649116855)))
			{
				string text6 = text3.Substring(8).Trim().ToLowerInvariant();
				if (!string.IsNullOrWhiteSpace(text6))
				{
					method_5(modelExportItem_0, Class16.smethod_0(1649116714) + text6);
				}
			}
			else if (text3.StartsWith(Class16.smethod_0(1649116870)))
			{
				string text7 = text3.Substring(10).Trim().ToLowerInvariant();
				if (!string.IsNullOrWhiteSpace(text7))
				{
					modelExportItem_0.CollectedFiles.Add(Class16.smethod_0(1649116887) + text7);
				}
			}
			else if (text3.StartsWith(Class16.smethod_0(1649116897)))
			{
				string text8 = text3.Substring(5).Trim().ToLowerInvariant();
				if (!string.IsNullOrWhiteSpace(text8))
				{
					modelExportItem_0.CollectedFiles.Add(Class16.smethod_0(1649116917) + text8);
				}
			}
			else if (text3.ToLower().StartsWith(Class16.smethod_0(1649116920)))
			{
				string text9 = text3.Substring(11).Trim().ToLowerInvariant();
				if (!string.IsNullOrWhiteSpace(text9))
				{
					modelExportItem_0.CollectedFiles.Add(Class16.smethod_0(1649116938) + text9);
				}
			}
		}
	}

	private void method_6(ModelExportItem modelExportItem_0, string string_0)
	{
		string_0 = PCK.FixPath(string_0);
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return;
		}
		object obj;
		if (string_0.EndsWith(Class16.smethod_0(1648906306)))
		{
			modelExportItem_0.CollectedFiles.Add(string_0);
			string directoryName = System.IO.Path.GetDirectoryName(string_0);
			if (directoryName == null)
			{
				obj = null;
			}
			else
			{
				obj = directoryName.Replace('/', '\\');
				if (obj != null)
				{
					goto IL_004e;
				}
			}
			obj = string.Empty;
			goto IL_004e;
		}
		modelExportItem_0.CollectedFiles.Add(string_0);
		string directoryName2 = System.IO.Path.GetDirectoryName(string_0);
		object obj2;
		if (directoryName2 == null)
		{
			obj2 = null;
		}
		else
		{
			obj2 = directoryName2.Replace('/', '\\');
			if (obj2 != null)
			{
				goto IL_0084;
			}
		}
		obj2 = string.Empty;
		goto IL_0084;
		IL_004e:
		string string_1 = (string)obj;
		method_4(modelExportItem_0, string_0, string_1);
		return;
		IL_0084:
		string text = (string)obj2;
		string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(string_0);
		string text2 = text + Class16.smethod_0(1648927580) + fileNameWithoutExtension + Class16.smethod_0(1648906306);
		modelExportItem_0.CollectedFiles.Add(text2);
		method_4(modelExportItem_0, text2, text);
	}

	private byte[] method_7(string string_0)
	{
		if (pck_LIST_0 != null && !string.IsNullOrWhiteSpace(string_0))
		{
			return pck_LIST_0.GetFileB(string_0);
		}
		return null;
	}

	private bool method_8(string string_0)
	{
		if (pck_LIST_0 != null && !string.IsNullOrWhiteSpace(string_0))
		{
			return pck_LIST_0.IsFileExist(string_0);
		}
		return false;
	}

	public int ExportToFolder(List<ModelExportItem> items, string destFolder, bool separateFolders)
	{
		int num = 0;
		foreach (ModelExportItem item in items)
		{
			CollectFiles(item);
			if (item.CollectedFiles.Count == 0)
			{
				continue;
			}
			string path = destFolder;
			if (separateFolders)
			{
				string path2 = smethod_0(item.Name ?? item.Id.ToString());
				path = System.IO.Path.Combine(destFolder, path2);
			}
			foreach (string collectedFile in item.CollectedFiles)
			{
				byte[] array = method_7(collectedFile);
				if (array != null && array.Length != 0)
				{
					string path3 = System.IO.Path.Combine(path, collectedFile);
					string directoryName = System.IO.Path.GetDirectoryName(path3);
					if (!string.IsNullOrWhiteSpace(directoryName) && !Directory.Exists(directoryName))
					{
						Directory.CreateDirectory(directoryName);
					}
					File.WriteAllBytes(path3, array);
					num++;
				}
			}
		}
		return num;
	}

	public int ExportDirModel(int listIndex, int elementIndex, string destFolder)
	{
		string text = CommonStorage.AParams.ModelsPckBaseName;
		if (string.IsNullOrWhiteSpace(text))
		{
			text = Class16.smethod_0(1649138031);
		}
		string itemModelPath = eListCollection_0.GetItemModelPath(listIndex, elementIndex);
		if (string.IsNullOrWhiteSpace(itemModelPath))
		{
			return 0;
		}
		itemModelPath = PCK.FixPath(itemModelPath);
		string text2 = ACE.RSGlobal.RSGlobal.GetPathRoot(itemModelPath);
		if (string.IsNullOrWhiteSpace(text2))
		{
			text2 = text;
		}
		PCK pCK = pck_LIST_0[text2];
		if (pCK == null)
		{
			return 0;
		}
		string text3 = System.IO.Path.GetDirectoryName(itemModelPath)?.Replace('/', '\\');
		if (string.IsNullOrWhiteSpace(text3))
		{
			return 0;
		}
		int num = 0;
		string text4 = PCK.FixPath(text3);
		if (!text4.EndsWith(Class16.smethod_0(1648927580)))
		{
			text4 += Class16.smethod_0(1648927580);
		}
		if (pCK.FileTableIndices == null)
		{
			return 0;
		}
		foreach (KeyValuePair<string, int> fileTableIndex in pCK.FileTableIndices)
		{
			if (!fileTableIndex.Key.StartsWith(text4))
			{
				continue;
			}
			byte[] fileB = pCK.GetFileB(fileTableIndex.Value);
			if (fileB != null && fileB.Length != 0)
			{
				string key = fileTableIndex.Key;
				string path = System.IO.Path.Combine(destFolder, key);
				string directoryName = System.IO.Path.GetDirectoryName(path);
				if (!string.IsNullOrWhiteSpace(directoryName) && !Directory.Exists(directoryName))
				{
					Directory.CreateDirectory(directoryName);
				}
				File.WriteAllBytes(path, fileB);
				num++;
			}
		}
		return num;
	}

	private static string smethod_0(string string_0)
	{
		char[] invalidPathChars = System.IO.Path.GetInvalidPathChars();
		char[] array = invalidPathChars;
		foreach (char oldChar in array)
		{
			string_0 = string_0.Replace(oldChar, '_');
		}
		char[] array2 = new char[7] { '<', '>', ':', '"', '|', '?', '*' };
		char[] array3 = array2;
		foreach (char oldChar2 in array3)
		{
			string_0 = string_0.Replace(oldChar2, '_');
		}
		if (string_0.Length > 100)
		{
			string_0 = string_0.Substring(0, 100);
		}
		return string_0.Trim();
	}
}
