using System.Runtime.CompilerServices;

namespace ACE.GFX;

public class GfxGridDecalElement : GfxElement
{
	private float float_2 = 1f;

	private float float_3 = 1f;

	private int int_3 = 4;

	private int int_4 = 4;

	public float Width
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

	public float Height
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

	public int GridRows
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

	public int GridCols
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

	public GfxGridDecalElement(GfxElementType type)
	{
		base.ElementType = type;
	}

	public override void LoadSpecific(GfxFileReader gfxFileReader_0, uint version)
	{
		if (version >= 108)
		{
			int num = gfxFileReader_0.ReadInt();
			int num2 = gfxFileReader_0.ReadInt();
			int num3 = num * num2;
			for (int i = 0; i < num3; i++)
			{
				gfxFileReader_0.ReadVector3();
				gfxFileReader_0.ReadHexColor();
			}
			float num4 = gfxFileReader_0.ReadFloat();
			gfxFileReader_0.ReadFloat();
			int num5 = gfxFileReader_0.ReadInt();
			for (int j = 0; j < num5; j++)
			{
				int num6 = gfxFileReader_0.ReadInt();
				for (int k = 0; k < num6; k++)
				{
					gfxFileReader_0.ReadLine();
				}
			}
			gfxFileReader_0.ReadBool();
			gfxFileReader_0.ReadBool();
			gfxFileReader_0.ReadFloat();
			gfxFileReader_0.ReadBool();
			Width = (float)num * num4;
			Height = (float)num2 * num4;
			GridRows = num2;
			GridCols = num;
		}
		else
		{
			Width = gfxFileReader_0.ReadFloat();
			Height = gfxFileReader_0.ReadFloat();
			GridRows = gfxFileReader_0.ReadInt();
			GridCols = gfxFileReader_0.ReadInt();
			if (version >= 42)
			{
				gfxFileReader_0.ReadFloat();
			}
			if (version >= 106)
			{
				gfxFileReader_0.ReadBool();
			}
			if (version >= 107)
			{
				gfxFileReader_0.ReadBool();
			}
		}
	}
}
