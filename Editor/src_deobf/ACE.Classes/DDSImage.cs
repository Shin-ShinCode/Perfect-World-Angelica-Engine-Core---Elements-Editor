using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ACE.Classes;

public class DDSImage : IDisposable
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	private struct Struct40
	{
		public ushort ushort_0;

		public ushort ushort_1;

		public ushort ushort_2;
	}

	private enum Enum1
	{

	}

	private struct Struct41
	{
		public byte byte_0;

		public byte byte_1;

		public byte byte_2;

		public byte byte_3;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	private struct Struct42
	{
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct Struct43
		{
			public uint uint_0;

			public uint uint_1;

			public uint uint_2;

			public uint uint_3;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct Struct44
		{
			public uint uint_0;

			public uint uint_1;

			public uint uint_2;

			public uint uint_3;

			public uint uint_4;

			public uint uint_5;

			public uint uint_6;

			public uint uint_7;
		}

		public uint uint_0;

		public uint uint_1;

		public uint uint_2;

		public uint uint_3;

		public uint uint_4;

		public uint uint_5;

		public uint uint_6;

		public uint uint_7;

		public uint[] uint_8;

		public Struct44 struct44_0;

		public Struct43 struct43_0;

		public uint uint_9;
	}

	private bool bool_0;

	private Bitmap bitmap_0;

	public Bitmap BitmapImage => bitmap_0;

	public bool IsValid => bool_0;

	public DDSImage(byte[] ddsImage)
	{
		if (ddsImage == null || ddsImage.Length == 0)
		{
			return;
		}
		MemoryStream memoryStream = new MemoryStream(ddsImage.Length);
		try
		{
			memoryStream.Write(ddsImage, 0, ddsImage.Length);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			try
			{
				method_0(binaryReader);
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

	public DDSImage(Stream ddsImage)
	{
		if (ddsImage != null && ddsImage.CanRead)
		{
			BinaryReader binaryReader = new BinaryReader(ddsImage);
			try
			{
				method_0(binaryReader);
			}
			finally
			{
				((IDisposable)binaryReader).Dispose();
			}
		}
	}

	private DDSImage(Bitmap bitmap_1)
	{
		bitmap_0 = bitmap_1;
	}

	private void method_0(BinaryReader binaryReader_0)
	{
		Struct42 struct42_ = default(Struct42);
		Enum1 @enum = (Enum1)19;
		byte[] array = null;
		if (method_3(binaryReader_0, ref struct42_))
		{
			bool_0 = true;
			if (struct42_.uint_5 == 0)
			{
				struct42_.uint_5 = 1u;
			}
			uint uint_ = 0u;
			@enum = method_4(struct42_, ref uint_);
			if (@enum == (Enum1)19)
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648908391)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				bool_0 = false;
			}
			array = method_1(binaryReader_0, struct42_);
			if (array != null)
			{
				byte[] byte_ = method_19(struct42_, array, @enum);
				bitmap_0 = method_2((int)struct42_.uint_3, (int)struct42_.uint_2, byte_);
			}
		}
	}

	private byte[] method_1(BinaryReader binaryReader_0, Struct42 struct42_0)
	{
		byte[] array = null;
		if ((struct42_0.uint_1 & 0x80000) > 1)
		{
			array = binaryReader_0.ReadBytes((int)struct42_0.uint_4);
		}
		else
		{
			uint num = struct42_0.uint_3;
			if (struct42_0.struct44_0.uint_3 != 0)
			{
				num = num * struct42_0.struct44_0.uint_3 / 8;
			}
			uint num2 = num * struct42_0.uint_2 * struct42_0.uint_5;
			array = new byte[num2];
			MemoryStream memoryStream = new MemoryStream((int)num2);
			for (int i = 0; i < struct42_0.uint_5; i++)
			{
				for (int j = 0; j < struct42_0.uint_2; j++)
				{
					byte[] array2 = binaryReader_0.ReadBytes((int)num);
					memoryStream.Write(array2, 0, array2.Length);
				}
			}
			memoryStream.Seek(0L, SeekOrigin.Begin);
			memoryStream.Read(array, 0, array.Length);
			memoryStream.Close();
		}
		return array;
	}

	private unsafe Bitmap method_2(int int_0, int int_1, byte[] byte_0)
	{
		Bitmap bitmap = new Bitmap(int_0, int_1, PixelFormat.Format32bppArgb);
		BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
		IntPtr scan = bitmapData.Scan0;
		int num = bitmap.Width * bitmap.Height * 4;
		byte* ptr = (byte*)(void*)scan;
		for (int i = 0; i < num; i += 4)
		{
			ptr[i] = byte_0[i + 2];
			ptr[i + 1] = byte_0[i + 1];
			ptr[i + 2] = byte_0[i];
			ptr[i + 3] = byte_0[i + 3];
		}
		bitmap.UnlockBits(bitmapData);
		return bitmap;
	}

	private bool method_3(BinaryReader binaryReader_0, ref Struct42 struct42_0)
	{
		byte[] array = binaryReader_0.ReadBytes(4);
		if (array[0] == 68 && array[1] == 68 && array[2] == 83 && array[3] == 32)
		{
			struct42_0.uint_0 = binaryReader_0.ReadUInt32();
			if (struct42_0.uint_0 != 124)
			{
				return false;
			}
			struct42_0.uint_1 = binaryReader_0.ReadUInt32();
			struct42_0.uint_2 = binaryReader_0.ReadUInt32();
			struct42_0.uint_3 = binaryReader_0.ReadUInt32();
			struct42_0.uint_4 = binaryReader_0.ReadUInt32();
			struct42_0.uint_5 = binaryReader_0.ReadUInt32();
			struct42_0.uint_6 = binaryReader_0.ReadUInt32();
			struct42_0.uint_7 = binaryReader_0.ReadUInt32();
			struct42_0.uint_8 = new uint[10];
			for (int i = 0; i < 10; i++)
			{
				struct42_0.uint_8[i] = binaryReader_0.ReadUInt32();
			}
			struct42_0.struct44_0.uint_0 = binaryReader_0.ReadUInt32();
			struct42_0.struct44_0.uint_1 = binaryReader_0.ReadUInt32();
			struct42_0.struct44_0.uint_2 = binaryReader_0.ReadUInt32();
			struct42_0.struct44_0.uint_3 = binaryReader_0.ReadUInt32();
			struct42_0.struct44_0.uint_4 = binaryReader_0.ReadUInt32();
			struct42_0.struct44_0.uint_5 = binaryReader_0.ReadUInt32();
			struct42_0.struct44_0.uint_6 = binaryReader_0.ReadUInt32();
			struct42_0.struct44_0.uint_7 = binaryReader_0.ReadUInt32();
			struct42_0.struct43_0.uint_0 = binaryReader_0.ReadUInt32();
			struct42_0.struct43_0.uint_1 = binaryReader_0.ReadUInt32();
			struct42_0.struct43_0.uint_2 = binaryReader_0.ReadUInt32();
			struct42_0.struct43_0.uint_3 = binaryReader_0.ReadUInt32();
			struct42_0.uint_9 = binaryReader_0.ReadUInt32();
			return true;
		}
		return false;
	}

	private Enum1 method_4(Struct42 struct42_0, ref uint uint_0)
	{
		Enum1 @enum = (Enum1)19;
		if ((struct42_0.struct44_0.uint_1 & 4) == 4)
		{
			uint_0 = (struct42_0.uint_3 + 3) / 4 * ((struct42_0.uint_2 + 3) / 4) * struct42_0.uint_5;
			switch (struct42_0.struct44_0.uint_2)
			{
			case 111u:
				@enum = (Enum1)13;
				uint_0 = struct42_0.uint_3 * struct42_0.uint_2 * struct42_0.uint_5 * 2;
				break;
			case 112u:
				@enum = (Enum1)14;
				uint_0 = struct42_0.uint_3 * struct42_0.uint_2 * struct42_0.uint_5 * 4;
				break;
			case 113u:
				@enum = (Enum1)15;
				uint_0 = struct42_0.uint_3 * struct42_0.uint_2 * struct42_0.uint_5 * 8;
				break;
			case 114u:
				@enum = (Enum1)16;
				uint_0 = struct42_0.uint_3 * struct42_0.uint_2 * struct42_0.uint_5 * 4;
				break;
			case 115u:
				@enum = (Enum1)17;
				uint_0 = struct42_0.uint_3 * struct42_0.uint_2 * struct42_0.uint_5 * 8;
				break;
			case 116u:
				@enum = (Enum1)18;
				uint_0 = struct42_0.uint_3 * struct42_0.uint_2 * struct42_0.uint_5 * 16;
				break;
			case 36u:
				@enum = (Enum1)12;
				uint_0 = struct42_0.uint_3 * struct42_0.uint_2 * struct42_0.uint_5 * 8;
				break;
			case 843666497u:
				@enum = (Enum1)7;
				uint_0 *= 16u;
				break;
			case 827611204u:
				@enum = (Enum1)2;
				uint_0 *= 8u;
				break;
			case 826889281u:
				@enum = (Enum1)8;
				uint_0 *= 8u;
				break;
			case 861165636u:
				@enum = (Enum1)4;
				uint_0 *= 16u;
				break;
			case 844388420u:
				@enum = (Enum1)3;
				uint_0 *= 16u;
				break;
			default:
				@enum = (Enum1)19;
				uint_0 *= 16u;
				break;
			case 1111971922u:
				@enum = (Enum1)11;
				uint_0 *= 16u;
				break;
			case 894720068u:
				@enum = (Enum1)6;
				uint_0 *= 16u;
				break;
			case 877942852u:
				@enum = (Enum1)5;
				uint_0 *= 16u;
				break;
			}
		}
		else
		{
			@enum = (((struct42_0.struct44_0.uint_1 & 0x20000) != 131072) ? (((struct42_0.struct44_0.uint_1 & 1) != 1) ? ((Enum1)1) : ((Enum1)0)) : (((struct42_0.struct44_0.uint_1 & 1) != 1) ? ((Enum1)9) : ((Enum1)10)));
			uint_0 = struct42_0.uint_3 * struct42_0.uint_2 * struct42_0.uint_5 * (struct42_0.struct44_0.uint_3 >> 3);
		}
		return @enum;
	}

	private uint method_5(Enum1 enum1_0, uint uint_0)
	{
		switch (enum1_0)
		{
		case (Enum1)8:
			return 1u;
		case (Enum1)0:
		case (Enum1)1:
		case (Enum1)9:
		case (Enum1)10:
			return uint_0 / 8;
		case (Enum1)7:
		case (Enum1)11:
			return 3u;
		case (Enum1)13:
			return 2u;
		default:
			return 4u;
		case (Enum1)12:
		case (Enum1)15:
		case (Enum1)17:
			return 8u;
		case (Enum1)18:
			return 16u;
		}
	}

	private uint method_6(Enum1 enum1_0)
	{
		switch (enum1_0)
		{
		default:
			return 1u;
		case (Enum1)12:
			return 2u;
		case (Enum1)13:
		case (Enum1)14:
		case (Enum1)15:
			return 4u;
		case (Enum1)16:
		case (Enum1)17:
		case (Enum1)18:
			return 4u;
		}
	}

	private bool method_7(Struct42 struct42_0)
	{
		if (struct42_0.struct44_0.uint_3 != 32)
		{
			return false;
		}
		if (struct42_0.struct44_0.uint_4 == 1072693248 && struct42_0.struct44_0.uint_5 == 1047552 && struct42_0.struct44_0.uint_6 == 1023 && struct42_0.struct44_0.uint_7 == 3221225472u)
		{
			return true;
		}
		if (struct42_0.struct44_0.uint_4 == 1023 && struct42_0.struct44_0.uint_5 == 1047552 && struct42_0.struct44_0.uint_6 == 1072693248 && struct42_0.struct44_0.uint_7 == 3221225472u)
		{
			return true;
		}
		return false;
	}

	private void method_8(uint uint_0, ref byte[] byte_0)
	{
		for (uint num = 0u; num < uint_0; num++)
		{
			byte b = byte_0[num + 3];
			if (b != 0)
			{
				int num2 = (byte_0[num] << 8) / b;
				int num3 = (byte_0[num + 1] << 8) / b;
				int num4 = (byte_0[num + 2] << 8) / b;
				byte_0[num] = (byte)num2;
				byte_0[num + 1] = (byte)num3;
				byte_0[num + 2] = (byte)num4;
			}
		}
	}

	private void method_9(uint uint_0, ref int int_0, ref int int_1, ref int int_2)
	{
		int_0 = 0;
		int_1 = 1;
		int_2 = 0;
		while ((uint_0 & 1) == 0)
		{
			uint_0 >>= 1;
			int_0++;
		}
		uint num;
		for (num = 0u; (uint_0 & (1 << (int)num)) != 0L; num++)
		{
		}
		while (uint_0 * int_1 < 255L)
		{
			int_1 = (int_1 << (int)num) + 1;
		}
		uint_0 *= (uint)int_1;
		while ((uint_0 & -256L) != 0L)
		{
			uint_0 >>= 1;
			int_2++;
		}
	}

	private unsafe void method_10(byte* pByte_0, ref Struct41[] struct41_0)
	{
		byte b = (byte)(*pByte_0 & 0x1F);
		byte b2 = (byte)(((*pByte_0 & 0xE0) >> 5) | ((pByte_0[1] & 7) << 3));
		byte b3 = (byte)((pByte_0[1] & 0xF8) >> 3);
		byte b4 = (byte)(pByte_0[2] & 0x1F);
		byte b5 = (byte)(((pByte_0[2] & 0xE0) >> 5) | ((pByte_0[3] & 7) << 3));
		byte b6 = (byte)((pByte_0[3] & 0xF8) >> 3);
		struct41_0[0].byte_0 = (byte)((b3 << 3) | (b3 >> 2));
		struct41_0[0].byte_1 = (byte)((b2 << 2) | (b2 >> 3));
		struct41_0[0].byte_2 = (byte)((b << 3) | (b >> 2));
		struct41_0[1].byte_0 = (byte)((b6 << 3) | (b6 >> 2));
		struct41_0[1].byte_1 = (byte)((b5 << 2) | (b5 >> 3));
		struct41_0[1].byte_2 = (byte)((b4 << 3) | (b4 >> 2));
	}

	private void method_11(ushort ushort_0, ref Struct41 struct41_0)
	{
		byte b = (byte)(ushort_0 & 0x1F);
		byte b2 = (byte)((ushort_0 & 0x7E0) >> 5);
		byte b3 = (byte)((ushort_0 & 0xF800) >> 11);
		struct41_0.byte_0 = (byte)((b3 << 3) | (b3 >> 2));
		struct41_0.byte_1 = (byte)((b2 << 2) | (b2 >> 3));
		struct41_0.byte_2 = (byte)((b << 3) | (b3 >> 2));
	}

	private unsafe void method_12(byte* pByte_0, ref Struct40 struct40_0, ref Struct40 struct40_1)
	{
		struct40_0.ushort_0 = (byte)(*pByte_0 & 0x1F);
		struct40_0.ushort_1 = (byte)(((*pByte_0 & 0xE0) >> 5) | ((pByte_0[1] & 7) << 3));
		struct40_0.ushort_2 = (byte)((pByte_0[1] & 0xF8) >> 3);
		struct40_0.ushort_0 = (byte)(pByte_0[2] & 0x1F);
		struct40_0.ushort_1 = (byte)(((pByte_0[2] & 0xE0) >> 5) | ((pByte_0[3] & 7) << 3));
		struct40_0.ushort_2 = (byte)((pByte_0[3] & 0xF8) >> 3);
	}

	private void method_13(uint uint_0, ref uint uint_1, ref uint uint_2)
	{
		if (uint_0 == 0)
		{
			uint_2 = 0u;
			uint_1 = 0u;
			return;
		}
		uint num = uint_0;
		uint num2 = 0u;
		while (num2 < 32 && (num & 1) == 0)
		{
			num2++;
			num >>= 1;
		}
		uint_2 = num2;
		num2 = 0u;
		while (num2 < 8 && (num & 1) != 0)
		{
			num2++;
			num >>= 1;
		}
		uint_1 = 8 - num2;
	}

	private uint method_14(uint uint_0)
	{
		uint num = 1u;
		uint num2 = 0u;
		bool flag = false;
		uint num3 = 0u;
		while (true)
		{
			if (num3 < 32)
			{
				if ((uint_0 & num) != 0)
				{
					if (!flag)
					{
						flag = true;
					}
					num2++;
				}
				else if (flag)
				{
					break;
				}
				num3++;
				num <<= 1;
				continue;
			}
			return num2;
		}
		return num2;
	}

	private uint method_15(ushort ushort_0)
	{
		int num = (ushort_0 >> 15) & 1;
		int num2 = (ushort_0 >> 10) & 0x1F;
		int num3 = ushort_0 & 0x3FF;
		switch (num2)
		{
		case 31:
			if (num3 == 0)
			{
				return (uint)((num << 31) | 0x7F800000);
			}
			return (uint)((num << 31) | 0x7F800000 | (num3 << 13));
		case 0:
			if (num3 == 0)
			{
				return (uint)(num << 31);
			}
			while ((num3 & 0x400) == 0)
			{
				num3 <<= 1;
				num2--;
			}
			num2++;
			num3 &= -1025;
			break;
		}
		num2 += 112;
		num3 <<= 13;
		return (uint)((num << 31) | (num2 << 23) | num3);
	}

	private unsafe void method_16(uint* pUint_0, ushort* pUshort_0, uint uint_0)
	{
		uint num = 0u;
		while (num < uint_0)
		{
			*pUint_0 = method_15(*pUshort_0);
			num++;
			pUint_0++;
			pUshort_0++;
		}
	}

	private unsafe void method_17(uint* pUint_0, ushort* pUshort_0, uint uint_0)
	{
		for (uint num = 0u; num < uint_0; num += 3)
		{
			*(pUint_0++) = method_15(*(pUshort_0++));
			*(pUint_0++) = method_15(*(pUshort_0++));
			*(float*)pUint_0++ = 1f;
		}
	}

	private unsafe void method_18(uint* pUint_0, ushort* pUshort_0, uint uint_0)
	{
		for (uint num = 0u; num < uint_0; num += 3)
		{
			*(pUint_0++) = method_15(*(pUshort_0++));
			*(float*)pUint_0++ = 1f;
			*(float*)pUint_0++ = 1f;
		}
	}

	private byte[] method_19(Struct42 struct42_0, byte[] byte_0, Enum1 enum1_0)
	{
		switch (enum1_0)
		{
		case (Enum1)0:
			return method_26(struct42_0, byte_0, enum1_0);
		case (Enum1)1:
			return method_25(struct42_0, byte_0, enum1_0);
		case (Enum1)2:
			return method_20(struct42_0, byte_0, enum1_0);
		case (Enum1)3:
			return method_21(struct42_0, byte_0, enum1_0);
		case (Enum1)4:
			return method_22(struct42_0, byte_0, enum1_0);
		case (Enum1)5:
			return method_23(struct42_0, byte_0, enum1_0);
		case (Enum1)6:
			return method_24(struct42_0, byte_0, enum1_0);
		case (Enum1)7:
			return method_27(struct42_0, byte_0, enum1_0);
		case (Enum1)8:
			return method_28(struct42_0, byte_0, enum1_0);
		case (Enum1)9:
		case (Enum1)10:
			return method_29(struct42_0, byte_0, enum1_0);
		case (Enum1)11:
			return method_30(struct42_0, byte_0, enum1_0);
		default:
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648908391)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return null;
		case (Enum1)13:
		case (Enum1)14:
		case (Enum1)15:
		case (Enum1)16:
		case (Enum1)17:
		case (Enum1)18:
			return method_31(struct42_0, byte_0, enum1_0);
		}
	}

	private unsafe byte[] method_20(Struct42 struct42_0, byte[] byte_0, Enum1 enum1_0)
	{
		int num = (int)method_5(enum1_0, struct42_0.struct44_0.uint_3);
		int num2 = (int)(struct42_0.uint_3 * num * method_6(enum1_0));
		int num3 = (int)(num2 * struct42_0.uint_2);
		int uint_ = (int)struct42_0.uint_3;
		int uint_2 = (int)struct42_0.uint_2;
		int uint_3 = (int)struct42_0.uint_5;
		byte[] array = new byte[uint_3 * num3 + uint_2 * num2 + uint_ * num];
		Struct41[] array2 = new Struct41[4];
		array2[0].byte_3 = byte.MaxValue;
		array2[1].byte_3 = byte.MaxValue;
		array2[2].byte_3 = byte.MaxValue;
		fixed (byte* ptr = byte_0)
		{
			byte* ptr2 = ptr;
			for (int i = 0; i < uint_3; i++)
			{
				for (int j = 0; j < uint_2; j += 4)
				{
					for (int k = 0; k < uint_; k += 4)
					{
						ushort num4 = *(ushort*)ptr2;
						ushort num5 = ((ushort*)ptr2)[1];
						method_11(num4, ref array2[0]);
						method_11(num5, ref array2[1]);
						uint num6 = ((uint*)ptr2)[1];
						ptr2 += 8;
						if (num4 > num5)
						{
							array2[2].byte_2 = (byte)((2 * array2[0].byte_2 + array2[1].byte_2 + 1) / 3);
							array2[2].byte_1 = (byte)((2 * array2[0].byte_1 + array2[1].byte_1 + 1) / 3);
							array2[2].byte_0 = (byte)((2 * array2[0].byte_0 + array2[1].byte_0 + 1) / 3);
							array2[3].byte_2 = (byte)((array2[0].byte_2 + 2 * array2[1].byte_2 + 1) / 3);
							array2[3].byte_1 = (byte)((array2[0].byte_1 + 2 * array2[1].byte_1 + 1) / 3);
							array2[3].byte_0 = (byte)((array2[0].byte_0 + 2 * array2[1].byte_0 + 1) / 3);
							array2[3].byte_3 = byte.MaxValue;
						}
						else
						{
							array2[2].byte_2 = (byte)((array2[0].byte_2 + array2[1].byte_2) / 2);
							array2[2].byte_1 = (byte)((array2[0].byte_1 + array2[1].byte_1) / 2);
							array2[2].byte_0 = (byte)((array2[0].byte_0 + array2[1].byte_0) / 2);
							array2[3].byte_2 = (byte)((array2[0].byte_2 + 2 * array2[1].byte_2 + 1) / 3);
							array2[3].byte_1 = (byte)((array2[0].byte_1 + 2 * array2[1].byte_1 + 1) / 3);
							array2[3].byte_0 = (byte)((array2[0].byte_0 + 2 * array2[1].byte_0 + 1) / 3);
							array2[3].byte_3 = 0;
						}
						int l = 0;
						int num7 = 0;
						for (; l < 4; l++)
						{
							int num8 = 0;
							while (num8 < 4)
							{
								int num9 = (int)((num6 & (3 << num7 * 2)) >> num7 * 2);
								Struct41 @struct = array2[num9];
								if (k + num8 < uint_ && j + l < uint_2)
								{
									uint num10 = (uint)(i * num3 + (j + l) * num2 + (k + num8) * num);
									array[num10] = @struct.byte_0;
									array[num10 + 1] = @struct.byte_1;
									array[num10 + 2] = @struct.byte_2;
									array[num10 + 3] = @struct.byte_3;
								}
								num8++;
								num7++;
							}
						}
					}
				}
			}
		}
		return array;
	}

	private byte[] method_21(Struct42 struct42_0, byte[] byte_0, Enum1 enum1_0)
	{
		int uint_ = (int)struct42_0.uint_3;
		int uint_2 = (int)struct42_0.uint_2;
		int uint_3 = (int)struct42_0.uint_5;
		byte[] byte_1 = method_22(struct42_0, byte_0, enum1_0);
		method_8((uint)(uint_ * uint_2 * uint_3), ref byte_1);
		return byte_1;
	}

	private unsafe byte[] method_22(Struct42 struct42_0, byte[] byte_0, Enum1 enum1_0)
	{
		int num = (int)method_5(enum1_0, struct42_0.struct44_0.uint_3);
		int num2 = (int)(struct42_0.uint_3 * num * method_6(enum1_0));
		int num3 = (int)(num2 * struct42_0.uint_2);
		int uint_ = (int)struct42_0.uint_3;
		int uint_2 = (int)struct42_0.uint_2;
		int uint_3 = (int)struct42_0.uint_5;
		byte[] array = new byte[uint_3 * num3 + uint_2 * num2 + uint_ * num];
		Struct41[] struct41_ = new Struct41[4];
		fixed (byte* ptr = byte_0)
		{
			byte* ptr2 = ptr;
			for (int i = 0; i < uint_3; i++)
			{
				for (int j = 0; j < uint_2; j += 4)
				{
					for (int k = 0; k < uint_; k += 4)
					{
						byte* ptr3 = ptr2;
						ptr2 += 8;
						method_10(ptr2, ref struct41_);
						ptr2 += 4;
						uint num4 = *(uint*)ptr2;
						ptr2 += 4;
						struct41_[2].byte_2 = (byte)((2 * struct41_[0].byte_2 + struct41_[1].byte_2 + 1) / 3);
						struct41_[2].byte_1 = (byte)((2 * struct41_[0].byte_1 + struct41_[1].byte_1 + 1) / 3);
						struct41_[2].byte_0 = (byte)((2 * struct41_[0].byte_0 + struct41_[1].byte_0 + 1) / 3);
						struct41_[3].byte_2 = (byte)((struct41_[0].byte_2 + 2 * struct41_[1].byte_2 + 1) / 3);
						struct41_[3].byte_1 = (byte)((struct41_[0].byte_1 + 2 * struct41_[1].byte_1 + 1) / 3);
						struct41_[3].byte_0 = (byte)((struct41_[0].byte_0 + 2 * struct41_[1].byte_0 + 1) / 3);
						int l = 0;
						int num5 = 0;
						for (; l < 4; l++)
						{
							for (int m = 0; m < 4; m++)
							{
								int num6 = (int)((num4 & (3 << num5 * 2)) >> num5 * 2);
								if (k + m < uint_ && j + l < uint_2)
								{
									uint num7 = (uint)(i * num3 + (j + l) * num2 + (k + m) * num);
									array[num7] = struct41_[num6].byte_0;
									array[num7 + 1] = struct41_[num6].byte_1;
									array[num7 + 2] = struct41_[num6].byte_2;
								}
								num5++;
							}
						}
						for (int n = 0; n < 4; n++)
						{
							ushort num8 = (ushort)(ptr3[2 * n] | (ptr3[2 * n + 1] << 8));
							for (int num9 = 0; num9 < 4; num9++)
							{
								if (k + num9 < uint_ && j + n < uint_2)
								{
									uint num10 = (uint)(i * num3 + (j + n) * num2 + (k + num9) * num + 3);
									array[num10] = (byte)(num8 & 0xF);
									array[num10] = (byte)(array[num10] | (array[num10] << 4));
								}
								num8 >>= 4;
							}
						}
					}
				}
			}
		}
		return array;
	}

	private byte[] method_23(Struct42 struct42_0, byte[] byte_0, Enum1 enum1_0)
	{
		int uint_ = (int)struct42_0.uint_3;
		int uint_2 = (int)struct42_0.uint_2;
		int uint_3 = (int)struct42_0.uint_5;
		byte[] byte_1 = method_24(struct42_0, byte_0, enum1_0);
		method_8((uint)(uint_ * uint_2 * uint_3), ref byte_1);
		return byte_1;
	}

	private unsafe byte[] method_24(Struct42 struct42_0, byte[] byte_0, Enum1 enum1_0)
	{
		int num = (int)method_5(enum1_0, struct42_0.struct44_0.uint_3);
		int num2 = (int)(struct42_0.uint_3 * num * method_6(enum1_0));
		int num3 = (int)(num2 * struct42_0.uint_2);
		int uint_ = (int)struct42_0.uint_3;
		int uint_2 = (int)struct42_0.uint_2;
		int uint_3 = (int)struct42_0.uint_5;
		byte[] array = new byte[uint_3 * num3 + uint_2 * num2 + uint_ * num];
		Struct41[] struct41_ = new Struct41[4];
		ushort[] array2 = new ushort[8];
		fixed (byte* ptr = byte_0)
		{
			byte* ptr2 = ptr;
			for (int i = 0; i < uint_3; i++)
			{
				for (int j = 0; j < uint_2; j += 4)
				{
					for (int k = 0; k < uint_; k += 4)
					{
						if (j >= uint_2)
						{
							break;
						}
						if (k >= uint_)
						{
							break;
						}
						array2[0] = *ptr2;
						array2[1] = ptr2[1];
						byte* ptr3 = ptr2 + 2;
						ptr2 += 8;
						method_10(ptr2, ref struct41_);
						uint num4 = ((uint*)ptr2)[1];
						ptr2 += 8;
						struct41_[2].byte_2 = (byte)((2 * struct41_[0].byte_2 + struct41_[1].byte_2 + 1) / 3);
						struct41_[2].byte_1 = (byte)((2 * struct41_[0].byte_1 + struct41_[1].byte_1 + 1) / 3);
						struct41_[2].byte_0 = (byte)((2 * struct41_[0].byte_0 + struct41_[1].byte_0 + 1) / 3);
						struct41_[3].byte_2 = (byte)((struct41_[0].byte_2 + 2 * struct41_[1].byte_2 + 1) / 3);
						struct41_[3].byte_1 = (byte)((struct41_[0].byte_1 + 2 * struct41_[1].byte_1 + 1) / 3);
						struct41_[3].byte_0 = (byte)((struct41_[0].byte_0 + 2 * struct41_[1].byte_0 + 1) / 3);
						int num5 = 0;
						for (int l = 0; l < 4; l++)
						{
							for (int m = 0; m < 4; m++)
							{
								int num6 = (int)((num4 & (3 << num5 * 2)) >> num5 * 2);
								Struct41 @struct = struct41_[num6];
								if (k + m < uint_ && j + l < uint_2)
								{
									uint num7 = (uint)(i * num3 + (j + l) * num2 + (k + m) * num);
									array[num7] = @struct.byte_0;
									array[num7 + 1] = @struct.byte_1;
									array[num7 + 2] = @struct.byte_2;
								}
								num5++;
							}
						}
						if (array2[0] > array2[1])
						{
							array2[2] = (ushort)((6 * array2[0] + array2[1] + 3) / 7);
							array2[3] = (ushort)((5 * array2[0] + 2 * array2[1] + 3) / 7);
							array2[4] = (ushort)((4 * array2[0] + 3 * array2[1] + 3) / 7);
							array2[5] = (ushort)((3 * array2[0] + 4 * array2[1] + 3) / 7);
							array2[6] = (ushort)((2 * array2[0] + 5 * array2[1] + 3) / 7);
							array2[7] = (ushort)((array2[0] + 6 * array2[1] + 3) / 7);
						}
						else
						{
							array2[2] = (ushort)((4 * array2[0] + array2[1] + 2) / 5);
							array2[3] = (ushort)((3 * array2[0] + 2 * array2[1] + 2) / 5);
							array2[4] = (ushort)((2 * array2[0] + 3 * array2[1] + 2) / 5);
							array2[5] = (ushort)((array2[0] + 4 * array2[1] + 2) / 5);
							array2[6] = 0;
							array2[7] = 255;
						}
						uint num8 = (uint)(*ptr3 | (ptr3[1] << 8) | (ptr3[2] << 16));
						for (int n = 0; n < 2; n++)
						{
							for (int num9 = 0; num9 < 4; num9++)
							{
								if (k + num9 < uint_ && j + n < uint_2)
								{
									uint num10 = (uint)(i * num3 + (j + n) * num2 + (k + num9) * num + 3);
									array[num10] = (byte)array2[num8 & 7];
								}
								num8 >>= 3;
							}
						}
						num8 = (uint)(ptr3[3] | (ptr3[4] << 8) | (ptr3[5] << 16));
						for (int num11 = 2; num11 < 4; num11++)
						{
							for (int num12 = 0; num12 < 4; num12++)
							{
								if (k + num12 < uint_ && j + num11 < uint_2)
								{
									uint num13 = (uint)(i * num3 + (j + num11) * num2 + (k + num12) * num + 3);
									array[num13] = (byte)array2[num8 & 7];
								}
								num8 >>= 3;
							}
						}
					}
				}
			}
		}
		return array;
	}

	private unsafe byte[] method_25(Struct42 struct42_0, byte[] byte_0, Enum1 enum1_0)
	{
		int num = (int)method_5(enum1_0, struct42_0.struct44_0.uint_3);
		int num2 = (int)(struct42_0.uint_3 * num * method_6(enum1_0));
		int num3 = (int)(num2 * struct42_0.uint_2);
		int uint_ = (int)struct42_0.uint_3;
		int uint_2 = (int)struct42_0.uint_2;
		int uint_3 = (int)struct42_0.uint_5;
		byte[] array = new byte[uint_3 * num3 + uint_2 * num2 + uint_ * num];
		uint num4 = ((struct42_0.struct44_0.uint_3 == 32) ? uint.MaxValue : ((uint)((1 << (int)struct42_0.struct44_0.uint_3) - 1)));
		uint num5 = (uint)((int)(struct42_0.struct44_0.uint_3 + 7) / 8);
		int int_ = 0;
		int int_2 = 0;
		int int_3 = 0;
		method_9(struct42_0.struct44_0.uint_4, ref int_, ref int_2, ref int_3);
		int int_4 = 0;
		int int_5 = 0;
		int int_6 = 0;
		method_9(struct42_0.struct44_0.uint_5, ref int_4, ref int_5, ref int_6);
		int int_7 = 0;
		int int_8 = 0;
		int int_9 = 0;
		method_9(struct42_0.struct44_0.uint_6, ref int_7, ref int_8, ref int_9);
		int num6 = 0;
		int num7 = uint_ * uint_2 * uint_3;
		fixed (byte* ptr = byte_0)
		{
			byte* ptr2 = ptr;
			while (num7-- > 0)
			{
				uint num8 = *(uint*)ptr2 & num4;
				ptr2 += num5;
				uint num9 = num8 & struct42_0.struct44_0.uint_4;
				array[num6] = (byte)((num9 >> int_) * int_2 >> int_3);
				num9 = num8 & struct42_0.struct44_0.uint_5;
				array[num6 + 1] = (byte)((num9 >> int_4) * int_5 >> int_6);
				num9 = num8 & struct42_0.struct44_0.uint_6;
				array[num6 + 2] = (byte)((num9 >> int_7) * int_8 >> int_9);
				array[num6 + 3] = byte.MaxValue;
				num6 += 4;
			}
		}
		return array;
	}

	private unsafe byte[] method_26(Struct42 struct42_0, byte[] byte_0, Enum1 enum1_0)
	{
		int num = (int)method_5(enum1_0, struct42_0.struct44_0.uint_3);
		int num2 = (int)(struct42_0.uint_3 * num * method_6(enum1_0));
		int num3 = (int)(num2 * struct42_0.uint_2);
		int uint_ = (int)struct42_0.uint_3;
		int uint_2 = (int)struct42_0.uint_2;
		int uint_3 = (int)struct42_0.uint_5;
		byte[] array = new byte[uint_3 * num3 + uint_2 * num2 + uint_ * num];
		uint num4 = ((struct42_0.struct44_0.uint_3 == 32) ? uint.MaxValue : ((uint)((1 << (int)struct42_0.struct44_0.uint_3) - 1)));
		uint num5 = (struct42_0.struct44_0.uint_3 + 7) / 8;
		int int_ = 0;
		int int_2 = 0;
		int int_3 = 0;
		method_9(struct42_0.struct44_0.uint_4, ref int_, ref int_2, ref int_3);
		int int_4 = 0;
		int int_5 = 0;
		int int_6 = 0;
		method_9(struct42_0.struct44_0.uint_5, ref int_4, ref int_5, ref int_6);
		int int_7 = 0;
		int int_8 = 0;
		int int_9 = 0;
		method_9(struct42_0.struct44_0.uint_6, ref int_7, ref int_8, ref int_9);
		int int_10 = 0;
		int int_11 = 0;
		int int_12 = 0;
		method_9(struct42_0.struct44_0.uint_7, ref int_10, ref int_11, ref int_12);
		int num6 = 0;
		int num7 = uint_ * uint_2 * uint_3;
		fixed (byte* ptr = byte_0)
		{
			byte* ptr2 = ptr;
			while (num7-- > 0)
			{
				uint num8 = *(uint*)ptr2 & num4;
				ptr2 += num5;
				uint num9 = num8 & struct42_0.struct44_0.uint_4;
				array[num6] = (byte)((num9 >> int_) * int_2 >> int_3);
				num9 = num8 & struct42_0.struct44_0.uint_5;
				array[num6 + 1] = (byte)((num9 >> int_4) * int_5 >> int_6);
				num9 = num8 & struct42_0.struct44_0.uint_6;
				array[num6 + 2] = (byte)((num9 >> int_7) * int_8 >> int_9);
				num9 = num8 & struct42_0.struct44_0.uint_7;
				array[num6 + 3] = (byte)((num9 >> int_10) * int_11 >> int_12);
				num6 += 4;
			}
		}
		return array;
	}

	private unsafe byte[] method_27(Struct42 struct42_0, byte[] byte_0, Enum1 enum1_0)
	{
		int num = (int)method_5(enum1_0, struct42_0.struct44_0.uint_3);
		int num2 = (int)(struct42_0.uint_3 * num * method_6(enum1_0));
		int num3 = (int)(num2 * struct42_0.uint_2);
		int uint_ = (int)struct42_0.uint_3;
		int uint_2 = (int)struct42_0.uint_2;
		int uint_3 = (int)struct42_0.uint_5;
		byte[] array = new byte[uint_3 * num3 + uint_2 * num2 + uint_ * num];
		byte[] array2 = new byte[8];
		byte[] array3 = new byte[8];
		int num4 = 0;
		fixed (byte* ptr = byte_0)
		{
			byte* ptr2 = ptr;
			for (int i = 0; i < uint_3; i++)
			{
				for (int j = 0; j < uint_2; j += 4)
				{
					for (int k = 0; k < uint_; k += 4)
					{
						byte* ptr3 = ptr2 + 8;
						int num5 = (array2[0] = *ptr2);
						int num6 = (array2[1] = ptr2[1]);
						ptr2 += 2;
						if (num5 > num6)
						{
							for (int l = 2; l < 8; l++)
							{
								array2[l] = (byte)(num5 + (num6 - num5) * (l - 1) / 7);
							}
						}
						else
						{
							for (int m = 2; m < 6; m++)
							{
								array2[m] = (byte)(num5 + (num6 - num5) * (m - 1) / 5);
							}
							array2[6] = 0;
							array2[7] = byte.MaxValue;
						}
						num5 = (array3[0] = *ptr3);
						num6 = (array3[1] = ptr3[1]);
						ptr3 += 2;
						if (num5 > num6)
						{
							for (int n = 2; n < 8; n++)
							{
								array3[n] = (byte)(num5 + (num6 - num5) * (n - 1) / 7);
							}
						}
						else
						{
							for (int num7 = 2; num7 < 6; num7++)
							{
								array3[num7] = (byte)(num5 + (num6 - num5) * (num7 - 1) / 5);
							}
							array3[6] = 0;
							array3[7] = byte.MaxValue;
						}
						int num8 = num4;
						for (int num9 = 0; num9 < 4; num9 += 2)
						{
							uint num10 = (uint)(*ptr2 | (ptr2[1] << 8) | (ptr2[2] << 16));
							uint num11 = (uint)(*ptr3 | (ptr3[1] << 8) | (ptr3[2] << 16));
							for (int num12 = 0; num12 < 2; num12++)
							{
								if (j + num9 + num12 >= uint_2)
								{
									continue;
								}
								for (int num13 = 0; num13 < 4; num13++)
								{
									if (k + num13 < uint_)
									{
										num5 = num8 + (k + num13) * 3;
										byte b = (array[num5 + 1] = array2[num10 & 7]);
										byte b2 = (array[num5] = array3[num11 & 7]);
										int num14 = 16256 - (b2 - 127) * (b2 - 128) - (b - 127) * (b - 128);
										if (num14 > 0)
										{
											array[num5 + 2] = (byte)(Math.Sqrt(num14) + 128.0);
										}
										else
										{
											array[num5 + 2] = 127;
										}
									}
									num10 >>= 3;
									num11 >>= 3;
								}
								num8 += num2;
							}
							ptr2 += 3;
							ptr3 += 3;
						}
						ptr2 += 8;
					}
					num4 += num2 * 4;
				}
			}
		}
		return array;
	}

	private unsafe byte[] method_28(Struct42 struct42_0, byte[] byte_0, Enum1 enum1_0)
	{
		int num = (int)method_5(enum1_0, struct42_0.struct44_0.uint_3);
		int num2 = (int)(struct42_0.uint_3 * num * method_6(enum1_0));
		int num3 = (int)(num2 * struct42_0.uint_2);
		int uint_ = (int)struct42_0.uint_3;
		int uint_2 = (int)struct42_0.uint_2;
		int uint_3 = (int)struct42_0.uint_5;
		byte[] array = new byte[uint_3 * num3 + uint_2 * num2 + uint_ * num];
		byte[] array2 = new byte[8];
		uint num4 = 0u;
		fixed (byte* ptr = byte_0)
		{
			byte* ptr2 = ptr;
			for (int i = 0; i < uint_3; i++)
			{
				for (int j = 0; j < uint_2; j += 4)
				{
					for (int k = 0; k < uint_; k += 4)
					{
						int num5 = (array2[0] = *ptr2);
						int num6 = (array2[1] = ptr2[1]);
						ptr2 += 2;
						if (num5 > num6)
						{
							for (int l = 2; l < 8; l++)
							{
								array2[l] = (byte)(num5 + (num6 - num5) * (l - 1) / 7);
							}
						}
						else
						{
							for (int m = 2; m < 6; m++)
							{
								array2[m] = (byte)(num5 + (num6 - num5) * (m - 1) / 5);
							}
							array2[6] = 0;
							array2[7] = byte.MaxValue;
						}
						uint num7 = num4;
						for (int n = 0; n < 4; n += 2)
						{
							uint num8 = (uint)(*ptr2 | (ptr2[1] << 8) | (ptr2[2] << 16));
							for (int num9 = 0; num9 < 2; num9++)
							{
								if (j + n + num9 >= uint_2)
								{
									continue;
								}
								for (int num10 = 0; num10 < 4; num10++)
								{
									if (k + num10 < uint_)
									{
										num5 = (int)(num7 + (k + num10));
										array[num5] = array2[num8 & 7];
									}
									num8 >>= 3;
								}
								num7 += (uint)num2;
							}
							ptr2 += 3;
						}
					}
					num4 += (uint)(num2 * 4);
				}
			}
		}
		return array;
	}

	private unsafe byte[] method_29(Struct42 struct42_0, byte[] byte_0, Enum1 enum1_0)
	{
		int num = (int)method_5(enum1_0, struct42_0.struct44_0.uint_3);
		int num2 = (int)(struct42_0.uint_3 * num * method_6(enum1_0));
		int num3 = (int)(num2 * struct42_0.uint_2);
		int uint_ = (int)struct42_0.uint_3;
		int uint_2 = (int)struct42_0.uint_2;
		int uint_3 = (int)struct42_0.uint_5;
		byte[] array = new byte[uint_3 * num3 + uint_2 * num2 + uint_ * num];
		int int_ = 0;
		int int_2 = 0;
		int int_3 = 0;
		method_9(struct42_0.struct44_0.uint_4, ref int_, ref int_2, ref int_3);
		int num4 = 0;
		int num5 = uint_ * uint_2 * uint_3;
		fixed (byte* ptr = byte_0)
		{
			byte* ptr2 = ptr;
			while (num5-- > 0)
			{
				byte b = *(ptr2++);
				array[num4] = (byte)((b >> int_) * int_2 >> int_3);
				array[num4 + 1] = (byte)((b >> int_) * int_2 >> int_3);
				array[num4 + 2] = (byte)((b >> int_) * int_2 >> int_3);
				array[num4 + 3] = (byte)((b >> int_) * int_2 >> int_3);
				num4 += 4;
			}
		}
		return array;
	}

	private unsafe byte[] method_30(Struct42 struct42_0, byte[] byte_0, Enum1 enum1_0)
	{
		int num = (int)method_5(enum1_0, struct42_0.struct44_0.uint_3);
		int num2 = (int)(struct42_0.uint_3 * num * method_6(enum1_0));
		int num3 = (int)(num2 * struct42_0.uint_2);
		int uint_ = (int)struct42_0.uint_3;
		int uint_2 = (int)struct42_0.uint_2;
		int uint_3 = (int)struct42_0.uint_5;
		byte[] array = new byte[uint_3 * num3 + uint_2 * num2 + uint_ * num];
		Struct40 struct40_ = default(Struct40);
		Struct40 struct40_2 = default(Struct40);
		Struct41[] array2 = new Struct41[4];
		byte[] array3 = new byte[8];
		fixed (byte* ptr = byte_0)
		{
			byte* ptr2 = ptr;
			for (int i = 0; i < uint_3; i++)
			{
				for (int j = 0; j < uint_2; j += 4)
				{
					for (int k = 0; k < uint_; k += 4)
					{
						if (j >= uint_2)
						{
							break;
						}
						if (k >= uint_)
						{
							break;
						}
						array3[0] = *ptr2;
						array3[1] = ptr2[1];
						byte* ptr3 = ptr2 + 2;
						ptr2 += 8;
						method_12(ptr2, ref struct40_, ref struct40_2);
						ptr2 += 4;
						uint num4 = ((uint*)ptr2)[1];
						ptr2 += 4;
						array2[0].byte_0 = (byte)(struct40_.ushort_2 << 3);
						array2[0].byte_1 = (byte)(struct40_.ushort_1 << 2);
						array2[0].byte_2 = (byte)(struct40_.ushort_0 << 3);
						array2[0].byte_3 = byte.MaxValue;
						array2[1].byte_0 = (byte)(struct40_2.ushort_2 << 3);
						array2[1].byte_1 = (byte)(struct40_2.ushort_1 << 2);
						array2[1].byte_2 = (byte)(struct40_2.ushort_0 << 3);
						array2[1].byte_3 = byte.MaxValue;
						array2[2].byte_2 = (byte)((2 * array2[0].byte_2 + array2[1].byte_2 + 1) / 3);
						array2[2].byte_1 = (byte)((2 * array2[0].byte_1 + array2[1].byte_1 + 1) / 3);
						array2[2].byte_0 = (byte)((2 * array2[0].byte_0 + array2[1].byte_0 + 1) / 3);
						array2[2].byte_3 = byte.MaxValue;
						array2[3].byte_2 = (byte)((array2[0].byte_2 + 2 * array2[1].byte_2 + 1) / 3);
						array2[3].byte_1 = (byte)((array2[0].byte_1 + 2 * array2[1].byte_1 + 1) / 3);
						array2[3].byte_0 = (byte)((array2[0].byte_0 + 2 * array2[1].byte_0 + 1) / 3);
						array2[3].byte_3 = byte.MaxValue;
						int num5 = 0;
						for (int l = 0; l < 4; l++)
						{
							int num6 = 0;
							while (num6 < 4)
							{
								int num7 = (int)((num4 & (3 << num5 * 2)) >> num5 * 2);
								Struct41 @struct = array2[num7];
								if (k + num6 < uint_ && j + l < uint_2)
								{
									uint num8 = (uint)(i * num3 + (j + l) * num2 + (k + num6) * num);
									array[num8] = @struct.byte_0;
									array[num8 + 1] = @struct.byte_1;
									array[num8 + 2] = @struct.byte_2;
								}
								num6++;
								num5++;
							}
						}
						if (array3[0] > array3[1])
						{
							array3[2] = (byte)((6 * array3[0] + array3[1] + 3) / 7);
							array3[3] = (byte)((5 * array3[0] + 2 * array3[1] + 3) / 7);
							array3[4] = (byte)((4 * array3[0] + 3 * array3[1] + 3) / 7);
							array3[5] = (byte)((3 * array3[0] + 4 * array3[1] + 3) / 7);
							array3[6] = (byte)((2 * array3[0] + 5 * array3[1] + 3) / 7);
							array3[7] = (byte)((array3[0] + 6 * array3[1] + 3) / 7);
						}
						else
						{
							array3[2] = (byte)((4 * array3[0] + array3[1] + 2) / 5);
							array3[3] = (byte)((3 * array3[0] + 2 * array3[1] + 2) / 5);
							array3[4] = (byte)((2 * array3[0] + 3 * array3[1] + 2) / 5);
							array3[5] = (byte)((array3[0] + 4 * array3[1] + 2) / 5);
							array3[6] = 0;
							array3[7] = byte.MaxValue;
						}
						uint num9 = *(uint*)ptr3;
						for (int m = 0; m < 2; m++)
						{
							for (int n = 0; n < 4; n++)
							{
								if (k + n < uint_ && j + m < uint_2)
								{
									uint num10 = (uint)(i * num3 + (j + m) * num2 + (k + n) * num + 3);
									array[num10] = array3[num9 & 7];
								}
								num9 >>= 3;
							}
						}
						num9 = *(uint*)(ptr3 + 3);
						for (int num11 = 2; num11 < 4; num11++)
						{
							for (int num12 = 0; num12 < 4; num12++)
							{
								if (k + num12 < uint_ && j + num11 < uint_2)
								{
									uint num13 = (uint)(i * num3 + (j + num11) * num2 + (k + num12) * num + 3);
									array[num13] = array3[num9 & 7];
								}
								num9 >>= 3;
							}
						}
					}
				}
			}
		}
		return array;
	}

	private unsafe byte[] method_31(Struct42 struct42_0, byte[] byte_0, Enum1 enum1_0)
	{
		int num = (int)method_5(enum1_0, struct42_0.struct44_0.uint_3);
		int num2 = (int)(struct42_0.uint_3 * num * method_6(enum1_0));
		int num3 = (int)(num2 * struct42_0.uint_2);
		int uint_ = (int)struct42_0.uint_3;
		int uint_2 = (int)struct42_0.uint_2;
		int uint_3 = (int)struct42_0.uint_5;
		byte[] array = new byte[uint_3 * num3 + uint_2 * num2 + uint_ * num];
		int num4 = 0;
		fixed (byte* ptr = byte_0)
		{
			byte* ptr2 = ptr;
			fixed (byte* ptr3 = array)
			{
				byte* ptr4 = ptr3;
				switch (enum1_0)
				{
				case (Enum1)13:
					num4 = uint_ * uint_2 * uint_3 * num;
					method_18((uint*)ptr4, (ushort*)ptr2, (uint)num4);
					break;
				case (Enum1)14:
					num4 = uint_ * uint_2 * uint_3 * num;
					method_17((uint*)ptr4, (ushort*)ptr2, (uint)num4);
					break;
				case (Enum1)15:
					num4 = uint_ * uint_2 * uint_3 * num;
					method_16((uint*)ptr4, (ushort*)ptr2, (uint)num4);
					break;
				case (Enum1)16:
				{
					num4 = uint_ * uint_2 * uint_3 * 3;
					int num7 = 0;
					int num8 = 0;
					while (num7 < num4)
					{
						((float*)ptr4)[num7] = ((float*)ptr2)[num8];
						((float*)ptr4)[num7 + 1] = 1f;
						((float*)ptr4)[num7 + 2] = 1f;
						num7 += 3;
						num8++;
					}
					break;
				}
				case (Enum1)17:
				{
					num4 = uint_ * uint_2 * uint_3 * 3;
					int num5 = 0;
					int num6 = 0;
					while (num5 < num4)
					{
						((float*)ptr4)[num5] = ((float*)ptr2)[num6];
						((float*)ptr4)[num5 + 1] = ((float*)ptr2)[num6 + 1];
						((float*)ptr4)[num5 + 2] = 1f;
						num5 += 3;
						num6 += 2;
					}
					break;
				}
				case (Enum1)18:
					Array.Copy(byte_0, array, byte_0.Length);
					break;
				}
			}
		}
		return array;
	}

	private unsafe byte[] method_32(Struct42 struct42_0, byte[] byte_0, Enum1 enum1_0)
	{
		int num = (int)method_5(enum1_0, struct42_0.struct44_0.uint_3);
		int num2 = (int)(struct42_0.uint_3 * num * method_6(enum1_0));
		int num3 = (int)(num2 * struct42_0.uint_2);
		int uint_ = (int)struct42_0.uint_3;
		int uint_2 = (int)struct42_0.uint_2;
		int uint_3 = (int)struct42_0.uint_5;
		if (method_7(struct42_0))
		{
			return method_33(struct42_0, byte_0, enum1_0);
		}
		int num4 = (int)(struct42_0.uint_3 * struct42_0.struct44_0.uint_3 / 8 * struct42_0.uint_2 * struct42_0.uint_5);
		byte[] array = new byte[uint_3 * num3 + uint_2 * num2 + uint_ * num];
		if (enum1_0 == (Enum1)9 && struct42_0.struct44_0.uint_3 == 16 && struct42_0.struct44_0.uint_4 == 65535)
		{
			Array.Copy(byte_0, array, byte_0.Length);
			return array;
		}
		uint num5 = 0u;
		uint uint_4 = 0u;
		uint uint_5 = 0u;
		uint uint_6 = 0u;
		uint uint_7 = 0u;
		uint uint_8 = 0u;
		uint uint_9 = 0u;
		uint uint_10 = 0u;
		uint uint_11 = 0u;
		method_13(struct42_0.struct44_0.uint_4, ref uint_4, ref uint_5);
		method_13(struct42_0.struct44_0.uint_5, ref uint_6, ref uint_7);
		method_13(struct42_0.struct44_0.uint_6, ref uint_8, ref uint_9);
		method_13(struct42_0.struct44_0.uint_7, ref uint_10, ref uint_11);
		uint num6 = struct42_0.struct44_0.uint_3 / 8;
		fixed (byte* ptr = byte_0)
		{
			byte* ptr2 = ptr;
			for (int i = 0; i < num4; i += num)
			{
				if (num4 - i < 4)
				{
					switch (num6)
					{
					case 1u:
						num5 = *ptr2;
						break;
					case 2u:
						num5 = (uint)(*ptr2 | (ptr2[1] << 8));
						break;
					case 3u:
						num5 = (uint)(*ptr2 | (ptr2[1] << 8) | (ptr2[2] << 16));
						break;
					}
				}
				else
				{
					num5 = (uint)(*ptr2 | (ptr2[1] << 8) | (ptr2[2] << 16) | (ptr2[3] << 24));
				}
				ptr2 += num6;
				array[i] = (byte)((int)(num5 & struct42_0.struct44_0.uint_4) >> (int)uint_5 << (int)uint_4);
				if (num >= 3)
				{
					array[i + 1] = (byte)((int)(num5 & struct42_0.struct44_0.uint_5) >> (int)uint_7 << (int)uint_6);
					array[i + 2] = (byte)(((int)num5 & struct42_0.struct44_0.uint_6) >> (int)uint_9 << (int)uint_8);
					if (num == 4)
					{
						array[i + 3] = (byte)((int)(num5 & struct42_0.struct44_0.uint_7) >> (int)uint_11 << (int)uint_10);
						switch (uint_10)
						{
						default:
							array[i + 3] = (byte)((array[i + 3] != 0) ? 255u : 0u);
							break;
						case 4u:
						case 5u:
						case 6u:
							array[i + 3] = (byte)(array[i + 3] | (array[i + 3] >> 4));
							break;
						case 0u:
						case 1u:
						case 2u:
						case 3u:
							break;
						}
					}
				}
				else if (num == 2)
				{
					array[i + 1] = (byte)((int)(num5 & struct42_0.struct44_0.uint_7) >> (int)uint_11 << (int)uint_10);
					switch (uint_10)
					{
					default:
						array[i + 1] = (byte)((array[i + 1] != 0) ? 255u : 0u);
						break;
					case 4u:
					case 5u:
					case 6u:
						array[i + 1] = (byte)(array[i + 1] | (array[i + 3] >> 4));
						break;
					case 0u:
					case 1u:
					case 2u:
					case 3u:
						break;
					}
				}
			}
		}
		return array;
	}

	private unsafe byte[] method_33(Struct42 struct42_0, byte[] byte_0, Enum1 enum1_0)
	{
		int num = (int)method_5(enum1_0, struct42_0.struct44_0.uint_3);
		int num2 = (int)(struct42_0.uint_3 * num * method_6(enum1_0));
		int num3 = (int)(num2 * struct42_0.uint_2);
		int uint_ = (int)struct42_0.uint_3;
		int uint_2 = (int)struct42_0.uint_2;
		uint uint_3 = struct42_0.uint_5;
		int num4 = (int)(struct42_0.uint_3 * struct42_0.struct44_0.uint_3 / 8 * struct42_0.uint_2 * struct42_0.uint_5);
		byte[] array = new byte[(int)uint_3 * num3 + uint_2 * num2 + uint_ * num];
		uint num5 = 0u;
		uint num6 = 0u;
		uint uint_4 = 0u;
		uint uint_5 = 0u;
		uint uint_6 = 0u;
		uint uint_7 = 0u;
		uint uint_8 = 0u;
		uint uint_9 = 0u;
		uint uint_10 = 0u;
		uint uint_11 = 0u;
		uint num7 = 0u;
		uint num8 = 0u;
		uint num9 = 0u;
		uint num10 = 0u;
		method_13(struct42_0.struct44_0.uint_4, ref uint_4, ref uint_5);
		method_13(struct42_0.struct44_0.uint_5, ref uint_6, ref uint_7);
		method_13(struct42_0.struct44_0.uint_6, ref uint_8, ref uint_9);
		method_13(struct42_0.struct44_0.uint_7, ref uint_10, ref uint_11);
		num7 = 16 - method_14(struct42_0.struct44_0.uint_4);
		num8 = 16 - method_14(struct42_0.struct44_0.uint_5);
		num9 = 16 - method_14(struct42_0.struct44_0.uint_6);
		num10 = 16 - method_14(struct42_0.struct44_0.uint_7);
		uint_4 += num7;
		uint_6 += num8;
		uint_8 += num9;
		uint_10 += num10;
		num6 = struct42_0.struct44_0.uint_3 / 8;
		fixed (byte* ptr = byte_0)
		{
			byte* ptr2 = ptr;
			fixed (byte* ptr3 = array)
			{
				byte* ptr4 = ptr3;
				for (int i = 0; i < num4 / 2; i += num)
				{
					if (num4 - i < 4)
					{
						switch (num6)
						{
						case 1u:
							num5 = *ptr2;
							break;
						case 2u:
							num5 = (uint)(*ptr2 | (ptr2[1] << 8));
							break;
						case 3u:
							num5 = (uint)(*ptr2 | (ptr2[1] << 8) | (ptr2[2] << 16));
							break;
						}
					}
					else
					{
						num5 = (uint)(*ptr2 | (ptr2[1] << 8) | (ptr2[2] << 16) | (ptr2[3] << 24));
					}
					ptr2 += num6;
					((short*)ptr4)[i + 2] = (short)(ushort)((int)(num5 & struct42_0.struct44_0.uint_4) >> (int)uint_5 << (int)uint_4);
					if (num >= 3)
					{
						((short*)ptr4)[i + 1] = (short)(ushort)((int)(num5 & struct42_0.struct44_0.uint_5) >> (int)uint_7 << (int)uint_6);
						((short*)ptr4)[i] = (short)(ushort)((int)(num5 & struct42_0.struct44_0.uint_6) >> (int)uint_9 << (int)uint_8);
						if (num == 4)
						{
							((short*)ptr4)[i + 3] = (short)(ushort)((int)(num5 & struct42_0.struct44_0.uint_7) >> (int)uint_11 << (int)uint_10);
							switch (uint_10)
							{
							default:
								((short*)ptr4)[i + 3] = (short)(ushort)((((ushort*)ptr4)[i + 3] != 0) ? 255 : 0);
								break;
							case 4u:
							case 5u:
							case 6u:
								((short*)ptr4)[i + 3] = (short)(ushort)(((ushort*)ptr4)[i + 3] | (((ushort*)ptr4)[i + 3] >> 4));
								break;
							case 0u:
							case 1u:
							case 2u:
							case 3u:
								break;
							}
						}
					}
					else if (num == 2)
					{
						((short*)ptr4)[i + 1] = (short)(ushort)((int)(num5 & struct42_0.struct44_0.uint_7) >> (int)uint_11 << (int)uint_10);
						switch (uint_10)
						{
						default:
							((short*)ptr4)[i + 1] = (short)(ushort)((((ushort*)ptr4)[i + 1] != 0) ? 255 : 0);
							break;
						case 4u:
						case 5u:
						case 6u:
							((short*)ptr4)[i + 1] = (short)(ushort)(((ushort*)ptr4)[i + 1] | (array[i + 3] >> 4));
							break;
						case 0u:
						case 1u:
						case 2u:
						case 3u:
							break;
						}
					}
				}
			}
		}
		return array;
	}

	public void Dispose()
	{
		if (bitmap_0 != null)
		{
			bitmap_0.Dispose();
			bitmap_0 = null;
		}
	}

	public static implicit operator DDSImage(Bitmap value)
	{
		return new DDSImage(value);
	}

	public static explicit operator Bitmap(DDSImage value)
	{
		return value.BitmapImage;
	}
}
