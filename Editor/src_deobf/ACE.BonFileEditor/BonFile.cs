using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ACE.BonFileEditor;

public class BonFile
{
	private static readonly Encoding encoding_0 = Encoding.GetEncoding(936);

	public long Header;

	public int Version;

	public int count;

	public int count2;

	public int count3;

	public int unknown0;

	public int spacecontrol;

	public int unknown;

	public byte[] Empty;

	public List<FirstStage> FirstStages = new List<FirstStage>();

	public byte[] Empty2;

	public List<SecondStage> SecondStages = new List<SecondStage>();

	public List<SecondStageAlt> SecondStagesAlt = new List<SecondStageAlt>();

	public List<FinalStage> GfxAnimations = new List<FinalStage>();

	public BonFile(string file)
	{
		BinaryReader binaryReader = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read, FileShare.Read));
		try
		{
			EnsureRemaining(binaryReader, 36, Class16.smethod_0(1648917728));
			Header = binaryReader.ReadInt64();
			Version = binaryReader.ReadInt32();
			count = ReadBoundedCount(binaryReader, Class16.smethod_0(1648917745), 100000);
			count2 = ReadBoundedCount(binaryReader, Class16.smethod_0(1648917769), 100000);
			count3 = ReadBoundedCount(binaryReader, Class16.smethod_0(1648917794), 100000);
			unknown0 = binaryReader.ReadInt32();
			spacecontrol = binaryReader.ReadInt32();
			unknown = binaryReader.ReadInt32();
			Empty = ReadBytesExact(binaryReader, 64, Class16.smethod_0(1648917818));
			for (int i = 0; i < count; i++)
			{
				FirstStages.Add(new FirstStage(binaryReader, Version));
			}
			checked
			{
				if (Version == 6)
				{
					Empty2 = ReadBytesExact(binaryReader, count2 * 4, Class16.smethod_0(1648917852));
				}
				if (spacecontrol > 7)
				{
					Empty2 = ReadBytesExact(binaryReader, count2 * 4, Class16.smethod_0(1648917852));
				}
			}
			for (int j = 0; j < count2; j++)
			{
				if (Version == 5)
				{
					SecondStages.Add(new SecondStage(binaryReader, Version));
				}
				else
				{
					SecondStagesAlt.Add(new SecondStageAlt(binaryReader, Version));
				}
			}
			for (int k = 0; k < count3; k++)
			{
				GfxAnimations.Add(new FinalStage(binaryReader, Version));
			}
		}
		finally
		{
			((IDisposable)binaryReader).Dispose();
		}
	}

	internal static void EnsureRemaining(BinaryReader reader, int byteCount, string label)
	{
		if (byteCount < 0)
		{
			throw new InvalidDataException(string.Format(Class16.smethod_0(1648921204), label, byteCount));
		}
		long num = reader.BaseStream.Length - reader.BaseStream.Position;
		if (num < byteCount)
		{
			throw new EndOfStreamException(string.Format(Class16.smethod_0(1648921238), label, byteCount, num));
		}
	}

	internal static int ReadBoundedCount(BinaryReader reader, string label, int maxValue)
	{
		int num = reader.ReadInt32();
		if (num < 0 || num > maxValue)
		{
			throw new InvalidDataException(string.Format(Class16.smethod_0(1648917887), label, num));
		}
		return num;
	}

	internal static byte[] ReadBytesExact(BinaryReader reader, int byteCount, string label)
	{
		EnsureRemaining(reader, byteCount, label);
		byte[] array = reader.ReadBytes(byteCount);
		if (array.Length != byteCount)
		{
			throw new EndOfStreamException(string.Format(Class16.smethod_0(1648921300), label, byteCount, array.Length));
		}
		return array;
	}

	internal static string ReadEncodedString(BinaryReader reader, string label)
	{
		int num = ReadBoundedCount(reader, label + Class16.smethod_0(1648917910), 8192);
		if (num == 0)
		{
			return string.Empty;
		}
		return encoding_0.GetString(ReadBytesExact(reader, num, label));
	}

	public void Save(string path, int vers)
	{
		BinaryWriter binaryWriter = new BinaryWriter(File.Create(path));
		binaryWriter.Write(Header);
		binaryWriter.Write(Version);
		binaryWriter.Write(FirstStages.Count);
		binaryWriter.Write(count2);
		binaryWriter.Write(count3);
		binaryWriter.Write(unknown0);
		binaryWriter.Write(spacecontrol);
		binaryWriter.Write(unknown);
		binaryWriter.Write(Empty);
		for (int i = 0; i < FirstStages.Count; i++)
		{
			FirstStages[i].Save(binaryWriter, vers);
		}
		if (vers == 6)
		{
			binaryWriter.Write(Empty2);
		}
		if (spacecontrol > 7)
		{
			binaryWriter.Write(Empty2);
		}
		for (int j = 0; j < count2; j++)
		{
			if (vers == 5)
			{
				SecondStages[j].Save(binaryWriter, vers);
			}
			else
			{
				SecondStagesAlt[j].Save(binaryWriter);
			}
		}
		for (int k = 0; k < count3; k++)
		{
			GfxAnimations[k].Save(binaryWriter);
		}
		binaryWriter.Close();
	}
}
