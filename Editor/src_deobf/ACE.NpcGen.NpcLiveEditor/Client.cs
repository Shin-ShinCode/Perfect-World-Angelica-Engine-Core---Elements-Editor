using System;
using System.Diagnostics;
using ACE.Classes;

namespace ACE.NpcGen.NpcLiveEditor;

public class Client
{
	private readonly MemoryManager memoryManager_0;

	private readonly Process process_0;

	public Client(Process process)
	{
		if (process == null)
		{
			throw new ArgumentNullException(Class16.smethod_0(1649096802));
		}
		process_0 = process;
		memoryManager_0 = new MemoryManager(MemoryManager.OpenProcess(process.Id));
	}

	private Offsets method_0()
	{
		return OffsetManager.SelectedOffsets;
	}

	private long method_1()
	{
		return memoryManager_0.ReadInt64(method_0().baseChain[0]);
	}

	private long method_2()
	{
		return memoryManager_0.ReadInt64(method_1() + method_0().baseChain[1]);
	}

	private long method_3()
	{
		return memoryManager_0.ReadInt64(method_2() + method_0().baseChain[2]);
	}

	private float method_4()
	{
		return memoryManager_0.ReadFloat(method_3() + method_0().posX);
	}

	private float method_5()
	{
		return memoryManager_0.ReadFloat(method_3() + method_0().posY);
	}

	private float method_6()
	{
		return memoryManager_0.ReadFloat(method_3() + method_0().posZ);
	}

	private float method_7()
	{
		return memoryManager_0.ReadFloat(method_3() + method_0().dirX);
	}

	private float method_8()
	{
		return memoryManager_0.ReadFloat(method_3() + method_0().dirY);
	}

	private float method_9()
	{
		return memoryManager_0.ReadFloat(method_3() + method_0().dirZ);
	}

	private long method_10()
	{
		return memoryManager_0.ReadInt64(method_2() + method_0().World);
	}

	private long method_11()
	{
		return memoryManager_0.ReadInt64(method_10() + method_0().NPCMan);
	}

	private long method_12()
	{
		return memoryManager_0.ReadInt64(method_11() + method_0().NPCListPtr);
	}

	private int method_13()
	{
		return (int)memoryManager_0.ReadInt64(method_11() + method_0().NPCCount);
	}

	private float method_14(long long_0)
	{
		return memoryManager_0.ReadFloat(long_0 + method_0().posX);
	}

	private float method_15(long long_0)
	{
		return memoryManager_0.ReadFloat(long_0 + method_0().posY);
	}

	private float method_16(long long_0)
	{
		return memoryManager_0.ReadFloat(long_0 + method_0().posZ);
	}

	private long method_17(int int_0)
	{
		return memoryManager_0.ReadInt64(method_12() + int_0 * 8);
	}

	private int method_18(int int_0)
	{
		return (int)memoryManager_0.ReadInt64(method_17(int_0) + method_0().NpcUId);
	}

	private int method_19(int int_0)
	{
		return (int)memoryManager_0.ReadInt64(method_17(int_0) + method_0().NpcElementId);
	}

	private string method_20(int int_0)
	{
		return memoryManager_0.ReadUnicode(memoryManager_0.ReadInt64(method_17(int_0) + method_0().NpcName));
	}

	private long method_21(int int_0)
	{
		return memoryManager_0.ReadInt64(method_17(int_0) + method_0().NPCModelDefaultPolicy);
	}

	private long method_22(int int_0)
	{
		return memoryManager_0.ReadInt64(method_21(int_0) + method_0().NPCModel);
	}

	private long method_23(int int_0)
	{
		return memoryManager_0.ReadInt64(method_22(int_0) + method_0().SkinModel);
	}

	private float method_24(int int_0, int int_1)
	{
		return memoryManager_0.ReadFloat(method_23(int_0) + method_0().SkinMatrix + int_1 * 4);
	}

	public int GetNPCCount()
	{
		try
		{
			int num = method_13();
			return (num >= 0 && num <= 100000) ? num : 0;
		}
		catch
		{
			return 0;
		}
	}

	public int GetNpcUid(int npcIndex)
	{
		try
		{
			return method_18(npcIndex);
		}
		catch
		{
			return 0;
		}
	}

	public string GetNpcName(int npcIndex)
	{
		try
		{
			return method_20(npcIndex);
		}
		catch
		{
			return string.Empty;
		}
	}

	public int GetNpcElementId(int npcIndex)
	{
		try
		{
			return method_19(npcIndex);
		}
		catch
		{
			return 0;
		}
	}

	public string GetProcessName()
	{
		Process process = process_0;
		object obj;
		if (process == null)
		{
			obj = null;
		}
		else
		{
			obj = process.ProcessName;
			if (obj != null)
			{
				goto IL_0020;
			}
		}
		obj = Class16.smethod_0(1648936686);
		goto IL_0020;
		IL_0020:
		return (string)obj;
	}

	public string GetDebugInfo()
	{
		try
		{
			if (process_0 == null)
			{
				return Class16.smethod_0(1649096821);
			}
			try
			{
				if (process_0.HasExited)
				{
					return Class16.smethod_0(1649096853);
				}
			}
			catch
			{
				return Class16.smethod_0(1649096887);
			}
			long num = 0L;
			try
			{
				num = process_0.MainModule?.BaseAddress.ToInt64() ?? 0L;
			}
			catch
			{
			}
			long num2 = method_1();
			long num3 = 0L;
			long num4 = 0L;
			long num5 = 0L;
			long num6 = 0L;
			long num7 = 0L;
			int num8 = 0;
			try
			{
				num3 = method_2();
			}
			catch
			{
			}
			try
			{
				num4 = method_3();
			}
			catch
			{
			}
			try
			{
				num5 = method_10();
			}
			catch
			{
			}
			try
			{
				num6 = method_11();
			}
			catch
			{
			}
			try
			{
				num7 = method_12();
			}
			catch
			{
			}
			try
			{
				num8 = method_13();
			}
			catch
			{
			}
			return Class16.smethod_0(1649096915) + method_0().VersionName + Class16.smethod_0(1648941987) + string.Format(Class16.smethod_0(1649096931), num) + string.Format(Class16.smethod_0(1649096975), method_0().baseChain[0]) + string.Format(Class16.smethod_0(1649097012), method_0().baseChain[1]) + string.Format(Class16.smethod_0(1649097041), method_0().baseChain[2]) + string.Format(Class16.smethod_0(1649097086), method_0().World) + string.Format(Class16.smethod_0(1649097116), method_0().NPCMan) + string.Format(Class16.smethod_0(1649097139), method_0().NPCListPtr) + string.Format(Class16.smethod_0(1649097182), method_0().NPCCount) + Class16.smethod_0(1649097215) + string.Format(Class16.smethod_0(1649092098), num2) + string.Format(Class16.smethod_0(1649092134), num3) + string.Format(Class16.smethod_0(1649092154), num4) + string.Format(Class16.smethod_0(1649092196), num5) + string.Format(Class16.smethod_0(1649092217), num6) + string.Format(Class16.smethod_0(1649092255), num7) + string.Format(Class16.smethod_0(1649092286), num8);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649092298));
			return Class16.smethod_0(1649092332) + ex.Message;
		}
	}

	private void method_25(int int_0, int int_1, float float_0)
	{
		long address = method_23(int_0) + method_0().SkinMatrix + int_1 * 4;
		memoryManager_0.WriteFloat(address, float_0);
	}

	public float[] GetSkinMatrix(int npcIndex)
	{
		try
		{
			float[] array = new float[16];
			for (int i = 0; i < 16; i++)
			{
				array[i] = method_24(npcIndex, i);
			}
			return array;
		}
		catch
		{
			return new float[16]
			{
				1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f,
				1f, 0f, 0f, 0f, 0f, 1f
			};
		}
	}

	public float[] RotateNPC(int npcIndex, float angle)
	{
		try
		{
			float num = angle * (float)Math.PI / 180f;
			float float_ = (float)Math.Cos(num);
			float num2 = (float)Math.Sin(num);
			method_25(npcIndex, 0, float_);
			method_25(npcIndex, 2, num2);
			method_25(npcIndex, 8, 0f - num2);
			method_25(npcIndex, 10, float_);
			return GetSkinMatrix(npcIndex);
		}
		catch
		{
			return GetSkinMatrix(npcIndex);
		}
	}

	public void RotateNPC(int npcIndex, float float_0, float float_1)
	{
		try
		{
			method_25(npcIndex, 2, float_0);
			method_25(npcIndex, 8, float_1);
		}
		catch
		{
		}
	}

	private void method_26(long long_0, float float_0)
	{
		memoryManager_0.WriteFloat(long_0 + method_0().posX, float_0);
	}

	private void method_27(long long_0, float float_0)
	{
		memoryManager_0.WriteFloat(long_0 + method_0().posY, float_0);
	}

	private void method_28(long long_0, float float_0)
	{
		memoryManager_0.WriteFloat(long_0 + method_0().posZ, float_0);
	}

	public (float x, float y, float z) GetNPCPosition(int npcIndex)
	{
		try
		{
			long long_ = method_17(npcIndex);
			return (x: method_14(long_), y: method_15(long_), z: method_16(long_));
		}
		catch
		{
			return (x: 0f, y: 0f, z: 0f);
		}
	}

	public (float x, float y, float z) GetHostPlayerPosition()
	{
		try
		{
			return (x: method_4(), y: method_5(), z: method_6());
		}
		catch
		{
			return (x: 0f, y: 0f, z: 0f);
		}
	}

	public (float x, float y, float z) GetHostPlayerDirection()
	{
		try
		{
			return (x: method_7(), y: method_8(), z: method_9());
		}
		catch
		{
			return (x: 0f, y: 0f, z: 1f);
		}
	}

	public void UpdateNPCPosition(int npcIndex, float float_0, float float_1, float float_2)
	{
		try
		{
			long long_ = method_17(npcIndex);
			method_26(long_, float_0);
			method_27(long_, float_1);
			method_28(long_, float_2);
		}
		catch
		{
		}
	}
}
