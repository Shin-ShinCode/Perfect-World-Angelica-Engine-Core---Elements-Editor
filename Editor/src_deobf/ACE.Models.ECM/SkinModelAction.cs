using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using ACE.Classes;

namespace ACE.Models.ECM;

public class SkinModelAction
{
	private string string_0;

	private string string_1;

	private float float_0;

	private float float_1;

	private int int_0 = 30;

	public string Name
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

	public string TrackFileName
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public float StartFrame
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	public float EndFrame
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
		[CompilerGenerated]
		set
		{
			float_1 = value;
		}
	}

	public int FrameRate
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

	public int FrameCount => (int)(EndFrame - StartFrame + 1f);

	public static SkinModelAction Read(BinaryReader reader, int version, string animPath, string basePath)
	{
		SkinModelAction skinModelAction = new SkinModelAction();
		try
		{
			int num = reader.ReadInt32();
			if (num > 0 && num < 1024)
			{
				byte[] bytes = reader.ReadBytes(num);
				skinModelAction.Name = Encoding.GetEncoding(936).GetString(bytes).TrimEnd(default(char));
			}
			else if (num >= 1024 || num < 0)
			{
				return skinModelAction;
			}
			if (version < 6)
			{
				reader.ReadInt32();
				int num2 = reader.ReadInt32();
				reader.ReadInt32();
				if (num2 < 0 || num2 > 256)
				{
					return skinModelAction;
				}
				for (int i = 0; i < num2; i++)
				{
					reader.ReadInt32();
					reader.ReadInt32();
					float startFrame = reader.ReadSingle();
					float endFrame = reader.ReadSingle();
					reader.ReadInt32();
					reader.ReadInt32();
					if (i == 0)
					{
						skinModelAction.StartFrame = startFrame;
						skinModelAction.EndFrame = endFrame;
					}
				}
			}
			else if (version < 9)
			{
				skinModelAction.StartFrame = reader.ReadSingle();
				skinModelAction.EndFrame = reader.ReadSingle();
			}
			else
			{
				skinModelAction.StartFrame = reader.ReadSingle();
				skinModelAction.EndFrame = reader.ReadSingle();
				skinModelAction.FrameRate = reader.ReadInt32();
			}
			if (version >= 7)
			{
				int num3 = reader.ReadInt32();
				if (num3 > 0 && num3 < 1024)
				{
					byte[] bytes2 = reader.ReadBytes(num3);
					skinModelAction.TrackFileName = Encoding.GetEncoding(936).GetString(bytes2).TrimEnd(default(char));
				}
			}
		}
		catch (EndOfStreamException)
		{
		}
		catch (Exception ex2)
		{
			SentryHelper.CaptureException(ex2, Class16.smethod_0(1649122446));
		}
		return skinModelAction;
	}
}
