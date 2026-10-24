using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.WorldTargetsEditor;

internal class WorldTargetsFile
{
	public int TeleportAmount;

	public List<FileStructure> TeleportList;

	public void ReadSevFile(BinaryReader binaryReader_0)
	{
		TeleportList = new List<FileStructure>();
		TeleportAmount = binaryReader_0.ReadInt32();
		for (int i = 0; i < TeleportAmount; i++)
		{
			FileStructure fileStructure = new FileStructure();
			fileStructure.ID = binaryReader_0.ReadInt32();
			fileStructure.MapId = binaryReader_0.ReadInt32();
			fileStructure.X_position = binaryReader_0.ReadSingle();
			fileStructure.Y_position = binaryReader_0.ReadSingle();
			fileStructure.Z_position = binaryReader_0.ReadSingle();
			fileStructure.GroupId = binaryReader_0.ReadInt32();
			TeleportList.Add(fileStructure);
		}
		binaryReader_0.Close();
	}

	public void ReadTxtFile(StreamReader streamReader_0)
	{
		TeleportList = new List<FileStructure>();
		try
		{
			Regex regex = new Regex(Class16.smethod_0(1649273455));
			string text;
			while ((text = streamReader_0.ReadLine()) != null)
			{
				if (string.IsNullOrWhiteSpace(text))
				{
					continue;
				}
				MatchCollection matchCollection = regex.Matches(text);
				List<string> list = new List<string>();
				foreach (Match item in matchCollection)
				{
					list.Add(item.Value);
				}
				if (list.Count >= 4)
				{
					FileStructure fileStructure = new FileStructure();
					int.TryParse(list[0], out fileStructure.ID);
					fileStructure.MapName = list[1].Trim('"', ' ');
					int.TryParse(list[2], out fileStructure.MapId);
					string text2 = list[3].Trim('"', ' ');
					string[] array = text2.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
					if (array.Length >= 3)
					{
						float.TryParse(array[0], NumberStyles.Any, CultureInfo.InvariantCulture, out fileStructure.X_position);
						float.TryParse(array[1], NumberStyles.Any, CultureInfo.InvariantCulture, out fileStructure.Y_position);
						float.TryParse(array[2], NumberStyles.Any, CultureInfo.InvariantCulture, out fileStructure.Z_position);
					}
					if (list.Count > 4)
					{
						int.TryParse(list[4], out fileStructure.GroupId);
					}
					TeleportList.Add(fileStructure);
					TeleportAmount++;
				}
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649273477));
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649273504)) + Class16.smethod_0(1648941987) + ex.Message, TextStorage.Msg(Class16.smethod_0(1649190371), Class16.smethod_0(1649141664)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		streamReader_0.Close();
	}

	public void WriteSevFile(BinaryWriter binaryWriter_0)
	{
		binaryWriter_0.Write(TeleportAmount);
		for (int i = 0; i < TeleportAmount; i++)
		{
			binaryWriter_0.Write(TeleportList[i].ID);
			binaryWriter_0.Write(TeleportList[i].MapId);
			binaryWriter_0.Write(TeleportList[i].X_position);
			binaryWriter_0.Write(TeleportList[i].Y_position);
			binaryWriter_0.Write(TeleportList[i].Z_position);
			binaryWriter_0.Write(TeleportList[i].GroupId);
		}
		binaryWriter_0.Close();
	}

	public void WriteTxtFile(StreamWriter streamWriter_0)
	{
		for (int i = 0; i < TeleportAmount; i++)
		{
			string text = TeleportList[i].X_position.ToString().Replace(',', '.');
			string text2 = TeleportList[i].Y_position.ToString().Replace(',', '.');
			string text3 = TeleportList[i].Z_position.ToString().Replace(',', '.');
			streamWriter_0.WriteLine(string.Format(Class16.smethod_0(1649273548), TeleportList[i].ID, TeleportList[i].MapName, TeleportList[i].MapId, text, text2, text3, TeleportList[i].GroupId));
		}
	}
}
