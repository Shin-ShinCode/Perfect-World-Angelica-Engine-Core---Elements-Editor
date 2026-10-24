using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ACE.Models;

public class SMD
{
	private static Encoding encoding_0 = Encoding.GetEncoding(Class16.smethod_0(1648985403));

	public byte[] Signature;

	public int Version;

	public int unknown;

	public byte[] zeros;

	public byte[] BonFile;

	public byte[] SkiFile;

	public byte[] PhyFile;

	public byte[] TckPath;

	private AnimatedJointAct[] animatedJointAct_0;

	public SMD(string fn)
	{
		FileStream fileStream = File.OpenRead(fn);
		Load(fileStream, bLoadAll: true);
		fileStream.Close();
	}

	public SMD()
	{
	}

	private static void smethod_0(BinaryReader binaryReader_0, int int_0, string string_0)
	{
		if (int_0 < 0)
		{
			throw new InvalidDataException(string.Format(Class16.smethod_0(1648921204), string_0, int_0));
		}
		long num = binaryReader_0.BaseStream.Length - binaryReader_0.BaseStream.Position;
		if (num < int_0)
		{
			throw new EndOfStreamException(string.Format(Class16.smethod_0(1648921238), string_0, int_0, num));
		}
	}

	private static byte[] smethod_1(BinaryReader binaryReader_0, int int_0, string string_0)
	{
		smethod_0(binaryReader_0, int_0, string_0);
		byte[] array = binaryReader_0.ReadBytes(int_0);
		if (array.Length != int_0)
		{
			throw new EndOfStreamException(string.Format(Class16.smethod_0(1648921300), string_0, int_0, array.Length));
		}
		return array;
	}

	private static int smethod_2(BinaryReader binaryReader_0, string string_0, int int_0)
	{
		int num = binaryReader_0.ReadInt32();
		if (num < 0 || num > int_0)
		{
			throw new InvalidDataException(string.Format(Class16.smethod_0(1649115695), string_0, num));
		}
		return num;
	}

	private static byte[] smethod_3(BinaryReader binaryReader_0, string string_0, int int_0)
	{
		int int_1 = smethod_2(binaryReader_0, string_0, int_0);
		return smethod_1(binaryReader_0, int_1, string_0);
	}

	public static string GetSkiName(byte[] smd_bytes)
	{
		SMD sMD = new SMD();
		MemoryStream memoryStream = new MemoryStream(smd_bytes);
		sMD.Load(memoryStream, bLoadAll: false);
		memoryStream.Close();
		byte[] skiFile = sMD.SkiFile;
		return encoding_0.GetString(skiFile).Trim().ToLowerInvariant();
	}

	public static string GetSkiName(string fn)
	{
		SMD sMD = new SMD();
		FileStream fileStream = File.OpenRead(fn);
		sMD.Load(fileStream, bLoadAll: false);
		fileStream.Close();
		byte[] skiFile = sMD.SkiFile;
		return encoding_0.GetString(skiFile).Trim().ToLowerInvariant();
	}

	public void Load(Stream stream, [MarshalAs(UnmanagedType.U1)] bool bLoadAll)
	{
		BinaryReader binaryReader = new BinaryReader(stream);
		smethod_0(binaryReader, 88, Class16.smethod_0(1649115725));
		Signature = smethod_1(binaryReader, 8, Class16.smethod_0(1649115742));
		Version = binaryReader.ReadInt32();
		unknown = binaryReader.ReadInt32();
		int num = smethod_2(binaryReader, Class16.smethod_0(1649115754), 100000);
		zeros = smethod_1(binaryReader, 68, Class16.smethod_0(1649115791));
		BonFile = smethod_3(binaryReader, Class16.smethod_0(1649115809), 16777216);
		SkiFile = smethod_3(binaryReader, Class16.smethod_0(1649115827), 16777216);
		if (bLoadAll)
		{
			if (unknown > 0)
			{
				PhyFile = smethod_3(binaryReader, Class16.smethod_0(1649115853), 16777216);
			}
			if (Version > 6)
			{
				TckPath = smethod_3(binaryReader, Class16.smethod_0(1649115871), 16777216);
			}
			AnimatedJointAct[] array = (animatedJointAct_0 = new AnimatedJointAct[num]);
			int num2 = 0;
			if (0 < (nint)array.LongLength)
			{
				do
				{
					if (Version == 5)
					{
						animatedJointAct_0[num2] = new AnimatedJointAct5();
						ref byte[] actName = ref ((AnimatedJointAct5)animatedJointAct_0[num2]).ActName;
						actName = smethod_3(binaryReader, string.Format(Class16.smethod_0(1649115881), num2), 16777216);
						ref int seperator = ref ((AnimatedJointAct5)animatedJointAct_0[num2]).seperator;
						seperator = binaryReader.ReadInt32();
						int num3 = smethod_2(binaryReader, string.Format(Class16.smethod_0(1649115904), num2), 100000);
						ref int reference = ref ((AnimatedJointAct5)animatedJointAct_0[num2]).unknown;
						reference = binaryReader.ReadInt32();
						((AnimatedJointAct5)animatedJointAct_0[num2]).AnimatedJointActSubBlocks = new AnimatedJointAct5SubBlock[num3];
						int num4 = 0;
						if (0 < (nint)((AnimatedJointAct5)animatedJointAct_0[num2]).AnimatedJointActSubBlocks.LongLength)
						{
							do
							{
								((AnimatedJointAct5)animatedJointAct_0[num2]).AnimatedJointActSubBlocks[num4] = new AnimatedJointAct5SubBlock();
								((AnimatedJointAct5)animatedJointAct_0[num2]).AnimatedJointActSubBlocks[num4].JointID = binaryReader.ReadInt32();
								((AnimatedJointAct5)animatedJointAct_0[num2]).AnimatedJointActSubBlocks[num4].StartSample = binaryReader.ReadSingle();
								((AnimatedJointAct5)animatedJointAct_0[num2]).AnimatedJointActSubBlocks[num4].EndSample = binaryReader.ReadSingle();
								((AnimatedJointAct5)animatedJointAct_0[num2]).AnimatedJointActSubBlocks[num4].unknown1 = binaryReader.ReadInt32();
								((AnimatedJointAct5)animatedJointAct_0[num2]).AnimatedJointActSubBlocks[num4].unknown2 = binaryReader.ReadSingle();
								num4++;
							}
							while (num4 < (nint)((AnimatedJointAct5)animatedJointAct_0[num2]).AnimatedJointActSubBlocks.LongLength);
						}
					}
					if (Version == 6)
					{
						animatedJointAct_0[num2] = new AnimatedJointAct6();
						ref byte[] actName2 = ref ((AnimatedJointAct6)animatedJointAct_0[num2]).ActName;
						actName2 = smethod_3(binaryReader, string.Format(Class16.smethod_0(1649115881), num2), 16777216);
						ref float startSample = ref ((AnimatedJointAct6)animatedJointAct_0[num2]).StartSample;
						startSample = binaryReader.ReadSingle();
						ref float endSample = ref ((AnimatedJointAct6)animatedJointAct_0[num2]).EndSample;
						endSample = binaryReader.ReadSingle();
					}
					if (Version >= 8)
					{
						animatedJointAct_0[num2] = new AnimatedJointAct8();
						ref byte[] actName3 = ref ((AnimatedJointAct8)animatedJointAct_0[num2]).ActName;
						actName3 = smethod_3(binaryReader, string.Format(Class16.smethod_0(1649115881), num2), 16777216);
						ref float startSample2 = ref ((AnimatedJointAct8)animatedJointAct_0[num2]).StartSample;
						startSample2 = binaryReader.ReadSingle();
						ref float endSample2 = ref ((AnimatedJointAct8)animatedJointAct_0[num2]).EndSample;
						endSample2 = binaryReader.ReadSingle();
						if (Version >= 9)
						{
							ref int iFrameRate = ref ((AnimatedJointAct8)animatedJointAct_0[num2]).iFrameRate;
							iFrameRate = binaryReader.ReadInt32();
						}
						ref byte[] stckFile = ref ((AnimatedJointAct8)animatedJointAct_0[num2]).StckFile;
						stckFile = smethod_3(binaryReader, string.Format(Class16.smethod_0(1649115943), num2), 16777216);
					}
					num2++;
				}
				while (num2 < (nint)animatedJointAct_0.LongLength);
			}
		}
		binaryReader.Close();
	}

	public void Load(byte[] bytes, [MarshalAs(UnmanagedType.U1)] bool bLoadAll)
	{
		MemoryStream memoryStream = new MemoryStream(bytes);
		Load(memoryStream, bLoadAll);
		memoryStream.Close();
	}

	public void Load(string File, [MarshalAs(UnmanagedType.U1)] bool bLoadAll)
	{
		FileStream fileStream = System.IO.File.OpenRead(File);
		Load(fileStream, bLoadAll);
		fileStream.Close();
	}

	public void Save(string File)
	{
		FileStream fileStream = new FileStream(File, FileMode.Create, FileAccess.Write);
		BinaryWriter binaryWriter = new BinaryWriter(fileStream);
		binaryWriter.Write(Signature);
		binaryWriter.Write(Version);
		binaryWriter.Write(unknown);
		binaryWriter.Write(animatedJointAct_0.Length);
		binaryWriter.Write(zeros);
		binaryWriter.Write(BonFile.Length);
		binaryWriter.Write(BonFile);
		binaryWriter.Write(SkiFile.Length);
		binaryWriter.Write(SkiFile);
		if (unknown > 0)
		{
			binaryWriter.Write(PhyFile.Length);
			binaryWriter.Write(PhyFile);
		}
		if (Version > 6)
		{
			binaryWriter.Write(TckPath.Length);
			binaryWriter.Write(TckPath);
		}
		int num = 0;
		AnimatedJointAct[] array = animatedJointAct_0;
		if (0 < (nint)array.LongLength)
		{
			do
			{
				if (Version == 5)
				{
					binaryWriter.Write(((AnimatedJointAct5)array[num]).ActName.Length);
					binaryWriter.Write(((AnimatedJointAct5)animatedJointAct_0[num]).ActName);
					binaryWriter.Write(((AnimatedJointAct5)animatedJointAct_0[num]).seperator);
					binaryWriter.Write(((AnimatedJointAct5)animatedJointAct_0[num]).AnimatedJointActSubBlocks.Length);
					binaryWriter.Write(((AnimatedJointAct5)animatedJointAct_0[num]).unknown);
					int num2 = 0;
					AnimatedJointAct animatedJointAct = animatedJointAct_0[num];
					if (0 < (nint)((AnimatedJointAct5)animatedJointAct).AnimatedJointActSubBlocks.LongLength)
					{
						do
						{
							binaryWriter.Write(((AnimatedJointAct5)animatedJointAct).AnimatedJointActSubBlocks[num2].JointID);
							binaryWriter.Write(((AnimatedJointAct5)animatedJointAct_0[num]).AnimatedJointActSubBlocks[num2].StartSample);
							binaryWriter.Write(((AnimatedJointAct5)animatedJointAct_0[num]).AnimatedJointActSubBlocks[num2].EndSample);
							binaryWriter.Write(((AnimatedJointAct5)animatedJointAct_0[num]).AnimatedJointActSubBlocks[num2].unknown1);
							binaryWriter.Write(((AnimatedJointAct5)animatedJointAct_0[num]).AnimatedJointActSubBlocks[num2].unknown2);
							num2++;
							animatedJointAct = animatedJointAct_0[num];
						}
						while (num2 < (nint)((AnimatedJointAct5)animatedJointAct).AnimatedJointActSubBlocks.LongLength);
					}
				}
				if (Version == 6)
				{
					binaryWriter.Write(((AnimatedJointAct6)animatedJointAct_0[num]).ActName.Length);
					binaryWriter.Write(((AnimatedJointAct6)animatedJointAct_0[num]).ActName);
					binaryWriter.Write(((AnimatedJointAct6)animatedJointAct_0[num]).StartSample);
					binaryWriter.Write(((AnimatedJointAct6)animatedJointAct_0[num]).EndSample);
				}
				if (Version >= 8)
				{
					binaryWriter.Write(((AnimatedJointAct8)animatedJointAct_0[num]).ActName.Length);
					binaryWriter.Write(((AnimatedJointAct8)animatedJointAct_0[num]).ActName);
					binaryWriter.Write(((AnimatedJointAct8)animatedJointAct_0[num]).StartSample);
					binaryWriter.Write(((AnimatedJointAct8)animatedJointAct_0[num]).EndSample);
					if (Version >= 9)
					{
						binaryWriter.Write(((AnimatedJointAct8)animatedJointAct_0[num]).iFrameRate);
					}
					binaryWriter.Write(((AnimatedJointAct8)animatedJointAct_0[num]).StckFile.Length);
					binaryWriter.Write(((AnimatedJointAct8)animatedJointAct_0[num]).StckFile);
				}
				num++;
				array = animatedJointAct_0;
			}
			while (num < (nint)array.LongLength);
		}
		binaryWriter.Close();
		fileStream.Close();
	}

	public int GetAnimatedJointActCount()
	{
		return animatedJointAct_0.Length;
	}

	public string GetActName(int ActIndex)
	{
		byte[] actName = animatedJointAct_0[ActIndex].ActName;
		string result = encoding_0.GetString(actName);
		GC.KeepAlive(this);
		return result;
	}

	public string GetStckFile(int ActIndex)
	{
		if (Version >= 8)
		{
			byte[] stckFile = ((AnimatedJointAct8)animatedJointAct_0[ActIndex]).StckFile;
			string text = Class16.smethod_0(1648927580);
			byte[] tckPath = TckPath;
			string result = string.Concat(encoding_0.GetString(tckPath) + text, encoding_0.GetString(stckFile));
			GC.KeepAlive(this);
			return result;
		}
		return string.Empty;
	}

	public float GetStartSample(int ActIndex)
	{
		int version = Version;
		if (version == 5)
		{
			float num = float.MaxValue;
			int num2 = 0;
			AnimatedJointAct animatedJointAct = animatedJointAct_0[ActIndex];
			if (0 < (nint)((AnimatedJointAct5)animatedJointAct).AnimatedJointActSubBlocks.LongLength)
			{
				do
				{
					if ((double)num > (double)((AnimatedJointAct5)animatedJointAct).AnimatedJointActSubBlocks[num2].StartSample)
					{
						num = ((AnimatedJointAct5)animatedJointAct).AnimatedJointActSubBlocks[num2].StartSample;
					}
					num2++;
				}
				while (num2 < (nint)((AnimatedJointAct5)animatedJointAct).AnimatedJointActSubBlocks.LongLength);
			}
			return num;
		}
		if (version == 6)
		{
			return ((AnimatedJointAct6)animatedJointAct_0[ActIndex]).StartSample;
		}
		if (version >= 8)
		{
			return ((AnimatedJointAct8)animatedJointAct_0[ActIndex]).StartSample;
		}
		return -1f;
	}

	public float GetEndSample(int ActIndex)
	{
		int version = Version;
		if (version == 5)
		{
			float num = float.MinValue;
			int num2 = 0;
			AnimatedJointAct animatedJointAct = animatedJointAct_0[ActIndex];
			if (0 < (nint)((AnimatedJointAct5)animatedJointAct).AnimatedJointActSubBlocks.LongLength)
			{
				do
				{
					if ((double)num < (double)((AnimatedJointAct5)animatedJointAct).AnimatedJointActSubBlocks[num2].EndSample)
					{
						num = ((AnimatedJointAct5)animatedJointAct).AnimatedJointActSubBlocks[num2].EndSample;
					}
					num2++;
				}
				while (num2 < (nint)((AnimatedJointAct5)animatedJointAct).AnimatedJointActSubBlocks.LongLength);
			}
			return num;
		}
		if (version == 6)
		{
			return ((AnimatedJointAct6)animatedJointAct_0[ActIndex]).EndSample;
		}
		if (version >= 8)
		{
			return ((AnimatedJointAct8)animatedJointAct_0[ActIndex]).EndSample;
		}
		return -1f;
	}

	public void SetSample(int ActIndex, float StartSample, float EndSample)
	{
		if (Version == 5)
		{
			int num = ActIndex;
			if (ActIndex < (nint)animatedJointAct_0.LongLength)
			{
				do
				{
					float num2;
					float endSample;
					if (num == ActIndex)
					{
						num2 = GetStartSample(num);
						endSample = (float)((double)EndSample - (double)StartSample + (double)num2);
					}
					else
					{
						double num3 = GetEndSample(num);
						float num4 = (float)(num3 - (double)GetStartSample(num));
						num2 = GetEndSample(num - 1) + 1f;
						endSample = (float)((double)num4 + (double)num2);
					}
					int num5 = 0;
					AnimatedJointAct animatedJointAct = animatedJointAct_0[num];
					if (0 < (nint)((AnimatedJointAct5)animatedJointAct).AnimatedJointActSubBlocks.LongLength)
					{
						do
						{
							((AnimatedJointAct5)animatedJointAct).AnimatedJointActSubBlocks[num5].StartSample = num2;
							((AnimatedJointAct5)animatedJointAct_0[num]).AnimatedJointActSubBlocks[num5].EndSample = endSample;
							num5++;
							animatedJointAct = animatedJointAct_0[num];
						}
						while (num5 < (nint)((AnimatedJointAct5)animatedJointAct).AnimatedJointActSubBlocks.LongLength);
					}
					num++;
				}
				while (num < (nint)animatedJointAct_0.LongLength);
			}
		}
		if (Version == 6)
		{
			int num6 = ActIndex;
			if (ActIndex < (nint)animatedJointAct_0.LongLength)
			{
				do
				{
					if (num6 == ActIndex)
					{
						float endSample2 = (float)((double)GetStartSample(num6) + ((double)EndSample - (double)StartSample));
						((AnimatedJointAct6)animatedJointAct_0[num6]).EndSample = endSample2;
					}
					else
					{
						double num7 = GetEndSample(num6);
						float num8 = (float)(num7 - (double)GetStartSample(num6));
						float startSample = GetEndSample(num6 - 1) + 1f;
						((AnimatedJointAct6)animatedJointAct_0[num6]).StartSample = startSample;
						float endSample3 = (float)((double)GetStartSample(num6) + (double)num8);
						((AnimatedJointAct6)animatedJointAct_0[num6]).EndSample = endSample3;
					}
					num6++;
				}
				while (num6 < (nint)animatedJointAct_0.LongLength);
			}
		}
		if (Version >= 8)
		{
			((AnimatedJointAct8)animatedJointAct_0[ActIndex]).StartSample = StartSample;
			((AnimatedJointAct8)animatedJointAct_0[ActIndex]).EndSample = EndSample;
		}
	}
}
