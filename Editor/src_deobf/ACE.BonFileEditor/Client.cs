using System;
using System.Diagnostics;

namespace ACE.BonFileEditor;

public class Client
{
	public static int version = 0;

	private readonly MemoryManager memoryManager_0;

	public static long base_address_174 = 5393008864L;

	public static int name_174 = 3200;

	public static long base_address_176 = 5394203968L;

	public static int name_176 = 3304;

	public static long base_address_178 = 5394501184L;

	public static int name_178 = 3304;

	public static long base_address = ((version == 174) ? base_address_174 : ((version == 176) ? base_address_176 : ((version == 178) ? base_address_178 : 0L)));

	public static int game_struct = 56;

	public static int char_ptr = 96;

	public static int name = ((version == 174) ? name_174 : ((version == 176) ? name_176 : ((version == 178) ? name_178 : 0)));

	public long TextureRotation_174 => memoryManager_0.ReadInt64(memoryManager_0.ReadInt64(memoryManager_0.ReadInt64(memoryManager_0.ReadInt64(memoryManager_0.ReadInt64(5393040832L) + 112L))) + 240L) + 88L;

	public long TextureRotation_176 => memoryManager_0.ReadInt64(memoryManager_0.ReadInt64(memoryManager_0.ReadInt64(memoryManager_0.ReadInt64(memoryManager_0.ReadInt64(memoryManager_0.ReadInt64(5394252576L) + 112L))) + 184L) + 16L) + 88L;

	public long TextureRotation_178 => memoryManager_0.ReadInt64(memoryManager_0.ReadInt64(memoryManager_0.ReadInt64(memoryManager_0.ReadInt64(memoryManager_0.ReadInt64(memoryManager_0.ReadInt64(5394550000L) + 112L))) + 184L) + 16L) + 88L;

	public long Base_Address => memoryManager_0.ReadInt64((version == 174) ? base_address_174 : ((version == 176) ? base_address_176 : ((version == 178) ? base_address_178 : 0L)));

	public long TextureRotation
	{
		get
		{
			if (version != 174)
			{
				if (version != 176)
				{
					if (version != 178)
					{
						return 0L;
					}
					return TextureRotation_178;
				}
				return TextureRotation_176;
			}
			return TextureRotation_174;
		}
	}

	public Client(IntPtr pHandle)
	{
		memoryManager_0 = new MemoryManager(pHandle);
	}

	public Client(Process process_0)
		: this(MemFunctions.OpenProcess(process_0.Id))
	{
	}

	private long method_0()
	{
		return memoryManager_0.ReadInt64(Base_Address + game_struct);
	}

	private long method_1()
	{
		return memoryManager_0.ReadInt64(method_0() + char_ptr);
	}

	public void Rotation1(float value)
	{
		memoryManager_0.Write64(TextureRotation, value);
	}

	public void Rotation2(float value)
	{
		memoryManager_0.Write64(TextureRotation + 4L, value);
	}

	public void Rotation3(float value)
	{
		memoryManager_0.Write64(TextureRotation + 8L, value);
	}

	public void Rotation4(float value)
	{
		memoryManager_0.Write64(TextureRotation + 12L, value);
	}

	public void Rotation5(float value)
	{
		memoryManager_0.Write64(TextureRotation + 16L, value);
	}

	public void Rotation6(float value)
	{
		memoryManager_0.Write64(TextureRotation + 20L, value);
	}

	public void Rotation7(float value)
	{
		memoryManager_0.Write64(TextureRotation + 24L, value);
	}

	public void Rotation8(float value)
	{
		memoryManager_0.Write64(TextureRotation + 28L, value);
	}

	public void Rotation9(float value)
	{
		memoryManager_0.Write64(TextureRotation + 32L, value);
	}

	public void Rotation10(float value)
	{
		memoryManager_0.Write64(TextureRotation + 36L, value);
	}

	public void Rotation11(float value)
	{
		memoryManager_0.Write64(TextureRotation + 40L, value);
	}

	public void Rotation12(float value)
	{
		memoryManager_0.Write64(TextureRotation + 44L, value);
	}

	public void Rotation13(float value)
	{
		memoryManager_0.Write64(TextureRotation + 48L, value);
	}

	public void Rotation14(float value)
	{
		memoryManager_0.Write64(TextureRotation + 52L, value);
	}

	public void Rotation15(float value)
	{
		memoryManager_0.Write64(TextureRotation + 56L, value);
	}

	public void Rotation16(float value)
	{
		memoryManager_0.Write64(TextureRotation + 60L, value);
	}
}
