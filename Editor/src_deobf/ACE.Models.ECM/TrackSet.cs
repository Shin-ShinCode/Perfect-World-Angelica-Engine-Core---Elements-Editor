using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.Models.ECM;

public class TrackSet
{
	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private List<BoneTrack> list_0 = new List<BoneTrack>();

	private string string_0;

	public int Version
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int AnimStartFrame
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public int AnimEndFrame
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public int AnimFPS
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	public int NumBoneTracks
	{
		[CompilerGenerated]
		get
		{
			return int_4;
		}
		[CompilerGenerated]
		set
		{
			int_4 = value;
		}
	}

	public List<BoneTrack> BoneTracks
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	public string FilePath
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public int TotalFrames => AnimEndFrame - AnimStartFrame + 1;

	public float Duration => (float)TotalFrames / (float)AnimFPS;

	public static TrackSet Load(byte[] data, string filePath = null)
	{
		if (data != null && data.Length >= 8)
		{
			MemoryStream memoryStream = new MemoryStream(data);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					return Load(binaryReader, filePath);
				}
				finally
				{
					((IDisposable)binaryReader).Dispose();
				}
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
		}
		return null;
	}

	public static TrackSet Load(BinaryReader reader, string filePath = null)
	{
		TrackSet trackSet = new TrackSet();
		trackSet.FilePath = filePath;
		reader.ReadBytes(8);
		trackSet.Version = reader.ReadInt32();
		trackSet.NumBoneTracks = reader.ReadInt32();
		trackSet.AnimStartFrame = reader.ReadInt32();
		trackSet.AnimEndFrame = reader.ReadInt32();
		trackSet.AnimFPS = reader.ReadInt32();
		for (int i = 0; i < trackSet.NumBoneTracks; i++)
		{
			BoneTrack boneTrack = new BoneTrack();
			if (trackSet.Version >= 1)
			{
				boneTrack.BoneIndex = reader.ReadInt32();
			}
			else
			{
				boneTrack.BoneIndex = i;
			}
			boneTrack.NumPositionKeyframes = reader.ReadInt32();
			int num = reader.ReadInt32();
			reader.ReadInt32();
			for (int j = 0; j < boneTrack.NumPositionKeyframes; j++)
			{
				boneTrack.PositionTrack.Add(Vector3f.Read(reader));
			}
			if (trackSet.Version < 2)
			{
				for (int k = 0; k < num; k++)
				{
					reader.ReadInt32();
					reader.ReadInt32();
					reader.ReadInt32();
					reader.ReadInt32();
				}
			}
			boneTrack.NumRotationKeyframes = reader.ReadInt32();
			int num2 = reader.ReadInt32();
			reader.ReadInt32();
			if (trackSet.Version >= 2)
			{
				if (reader.ReadInt32() == 0)
				{
					for (int l = 0; l < boneTrack.NumRotationKeyframes; l++)
					{
						boneTrack.RotationTrack.Add(Quaternion.Read(reader));
					}
				}
				else
				{
					for (int m = 0; m < boneTrack.NumRotationKeyframes; m++)
					{
						boneTrack.RotationTrack.Add(Quaternion.ReadCompressed(reader));
					}
				}
			}
			else
			{
				for (int n = 0; n < boneTrack.NumRotationKeyframes; n++)
				{
					boneTrack.RotationTrack.Add(Quaternion.Read(reader));
				}
				for (int num3 = 0; num3 < num2; num3++)
				{
					reader.ReadInt32();
					reader.ReadInt32();
					reader.ReadInt32();
					reader.ReadInt32();
				}
			}
			trackSet.BoneTracks.Add(boneTrack);
		}
		return trackSet;
	}

	public BoneTrack GetTrack(int boneIndex)
	{
		foreach (BoneTrack boneTrack in BoneTracks)
		{
			if (boneTrack.BoneIndex == boneIndex)
			{
				return boneTrack;
			}
		}
		return null;
	}
}
