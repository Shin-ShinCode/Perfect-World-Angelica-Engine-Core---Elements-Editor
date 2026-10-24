using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ACE.FastImageSelector;

public class ImageSelectorConfig
{
	private Size size_0;

	private readonly int int_0;

	private int? nullable_0;

	private int? nullable_1;

	private Func<int, Image> func_0;

	public Size ImageSize
	{
		[CompilerGenerated]
		get
		{
			return size_0;
		}
		[CompilerGenerated]
		set
		{
			size_0 = value;
		}
	}

	public int TotalImageCount
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
	}

	public int? HImageCount
	{
		[CompilerGenerated]
		get
		{
			return nullable_0;
		}
		[CompilerGenerated]
		set
		{
			nullable_0 = value;
		}
	}

	public int? VImageCount
	{
		[CompilerGenerated]
		get
		{
			return nullable_1;
		}
		[CompilerGenerated]
		set
		{
			nullable_1 = value;
		}
	}

	public Func<int, Image> ImageGetter
	{
		[CompilerGenerated]
		get
		{
			return func_0;
		}
		[CompilerGenerated]
		set
		{
			func_0 = value;
		}
	}

	public ImageSelectorConfig(Size imageSize, int totalImageCount, int? hImageCount, int? vImageCount, Func<int, Image> imageGetter)
	{
		ImageSize = imageSize;
		int_0 = totalImageCount;
		HImageCount = hImageCount;
		VImageCount = vImageCount;
		ImageGetter = imageGetter;
	}
}
