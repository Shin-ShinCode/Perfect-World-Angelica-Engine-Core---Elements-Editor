using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.NpcGen.NpcLiveEditor;

public static class OffsetManager
{
	public static List<Offsets> OffsetsList = new List<Offsets>();

	public static Offsets SelectedOffsets;

	public static void LoadOffsets()
	{
		OffsetsList.Clear();
		string path = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1649114280));
		if (!File.Exists(path))
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649090808)), string.Empty);
			return;
		}
		StreamReader streamReader = new StreamReader(path);
		try
		{
			while (!streamReader.EndOfStream)
			{
				string text = streamReader.ReadLine();
				if (!string.IsNullOrWhiteSpace(text) && !text.StartsWith(Class16.smethod_0(1648929947)) && text.StartsWith(Class16.smethod_0(1648936731)))
				{
					try
					{
					Offsets offsets = new Offsets();
					offsets.VersionName = text.Replace(Class16.smethod_0(1649114298), string.Empty).Trim();
					string[] array = streamReader.ReadLine().Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
					offsets.baseChain = new long[3]
					{
						long.Parse(array[0], NumberStyles.HexNumber),
						long.Parse(array[1], NumberStyles.HexNumber),
						long.Parse(array[2], NumberStyles.HexNumber)
					};
					offsets.dirX = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
					offsets.dirY = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
					offsets.dirZ = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
					offsets.posX = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
					offsets.posY = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
					offsets.posZ = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
					offsets.World = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
					offsets.NPCMan = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
					offsets.NPCListPtr = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
					offsets.NPCCount = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
					offsets.NPCModelDefaultPolicy = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
					offsets.NPCModel = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
					offsets.SkinModel = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
					offsets.SkinMatrix = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
					offsets.NpcName = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
					offsets.NpcUId = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
					offsets.NpcElementId = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
					OffsetsList.Add(offsets);
					}
					catch
					{
					}
				}
			}
		}
		finally
		{
			((IDisposable)streamReader).Dispose();
		}
	}

	public static void SelectOffsets(int index)
	{
		if (index >= 0 && index < OffsetsList.Count)
		{
			SelectedOffsets = OffsetsList[index];
		}
		else
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649090852)) + Class16.smethod_0(1648908709) + index, string.Empty);
		}
	}

	public static void SelectOffsets(string versionName)
	{
		foreach (Offsets offsets in OffsetsList)
		{
			if (offsets.VersionName.Equals(versionName, StringComparison.OrdinalIgnoreCase))
			{
				SelectedOffsets = offsets;
				return;
			}
		}
		DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649090887)) + Class16.smethod_0(1648908709) + versionName, string.Empty);
	}
}
