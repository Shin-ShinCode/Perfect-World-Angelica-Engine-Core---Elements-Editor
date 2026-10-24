using System.Runtime.CompilerServices;

namespace ACE.GFX;

public class GfxSoundElement : GfxElement
{
	private string string_6 = string.Empty;

	private bool bool_14;

	private bool bool_15;

	private int int_3 = 100;

	private float float_2 = 1f;

	private float float_3 = 100f;

	public string SoundFile
	{
		[CompilerGenerated]
		get
		{
			return string_6;
		}
		[CompilerGenerated]
		set
		{
			string_6 = value;
		}
	}

	public bool Force2D
	{
		[CompilerGenerated]
		get
		{
			return bool_14;
		}
		[CompilerGenerated]
		set
		{
			bool_14 = value;
		}
	}

	public bool IsLoop
	{
		[CompilerGenerated]
		get
		{
			return bool_15;
		}
		[CompilerGenerated]
		set
		{
			bool_15 = value;
		}
	}

	public int Volume
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

	public float MinDist
	{
		[CompilerGenerated]
		get
		{
			return float_2;
		}
		[CompilerGenerated]
		set
		{
			float_2 = value;
		}
	}

	public float MaxDist
	{
		[CompilerGenerated]
		get
		{
			return float_3;
		}
		[CompilerGenerated]
		set
		{
			float_3 = value;
		}
	}

	public GfxSoundElement()
	{
		base.ElementType = GfxElementType.Sound;
	}

	public override void LoadSpecific(GfxFileReader gfxFileReader_0, uint version)
	{
		if (version >= 56)
		{
			int num = gfxFileReader_0.ReadInt();
			SoundFile = gfxFileReader_0.ReadString();
			if (num >= 1)
			{
				Force2D = gfxFileReader_0.ReadBool();
				IsLoop = gfxFileReader_0.ReadBool();
				Volume = gfxFileReader_0.ReadInt();
				MinDist = gfxFileReader_0.ReadFloat();
				MaxDist = gfxFileReader_0.ReadFloat();
			}
		}
		else
		{
			SoundFile = gfxFileReader_0.ReadString();
			if (version >= 39)
			{
				Force2D = gfxFileReader_0.ReadBool();
				IsLoop = gfxFileReader_0.ReadBool();
			}
		}
	}
}
