using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ACE.NpcGen.Classes;

public static class KBDHook
{
	private enum Enum18
	{

	}

	private static class Class247
	{
		public static APINPCGen.HookProc hookProc_0;
	}

	private struct Struct69
	{
		public IntPtr intptr_0 = IntPtr.Zero;

		public Enum18 enum18_0 = (Enum18)0;

		public uint uint_0 = 0u;

		public uint uint_1 = 0u;

		public uint uint_2 = 0u;

		public Struct69()
		{
		}
	}

	public delegate void HookKeyPress(LLKHEventArgs llkheventArgs_0);

	private static IntPtr intptr_0 = IntPtr.Zero;

	private static IntPtr intptr_1 = IntPtr.Zero;

	private static APINPCGen.HookProc hookProc_0;

	private static bool bool_0 = false;

	private static bool bool_1 = true;

	private static HookKeyPress hookKeyPress_0;

	private static HookKeyPress hookKeyPress_1;

	public static bool IsHookInstalled
	{
		get
		{
			if (bool_0)
			{
				return intptr_0 != IntPtr.Zero;
			}
			return false;
		}
	}

	public static bool LocalHook
	{
		get
		{
			return bool_1;
		}
		set
		{
			if (value != bool_1)
			{
				if (IsHookInstalled)
				{
					throw new Win32Exception(Class16.smethod_0(1649115362));
				}
				bool_1 = value;
			}
		}
	}

	public static IntPtr ModuleHandle => intptr_1;

	public static event HookKeyPress KeyDown
	{
		[CompilerGenerated]
		add
		{
			HookKeyPress hookKeyPress = hookKeyPress_0;
			HookKeyPress hookKeyPress2;
			do
			{
				hookKeyPress2 = hookKeyPress;
				HookKeyPress value2 = (HookKeyPress)Delegate.Combine(hookKeyPress2, value);
				hookKeyPress = Interlocked.CompareExchange(ref hookKeyPress_0, value2, hookKeyPress2);
			}
			while ((object)hookKeyPress != hookKeyPress2);
		}
		[CompilerGenerated]
		remove
		{
			HookKeyPress hookKeyPress = hookKeyPress_0;
			HookKeyPress hookKeyPress2;
			do
			{
				hookKeyPress2 = hookKeyPress;
				HookKeyPress value2 = (HookKeyPress)Delegate.Remove(hookKeyPress2, value);
				hookKeyPress = Interlocked.CompareExchange(ref hookKeyPress_0, value2, hookKeyPress2);
			}
			while ((object)hookKeyPress != hookKeyPress2);
		}
	}

	public static event HookKeyPress KeyUp
	{
		[CompilerGenerated]
		add
		{
			HookKeyPress hookKeyPress = hookKeyPress_1;
			HookKeyPress hookKeyPress2;
			do
			{
				hookKeyPress2 = hookKeyPress;
				HookKeyPress value2 = (HookKeyPress)Delegate.Combine(hookKeyPress2, value);
				hookKeyPress = Interlocked.CompareExchange(ref hookKeyPress_1, value2, hookKeyPress2);
			}
			while ((object)hookKeyPress != hookKeyPress2);
		}
		[CompilerGenerated]
		remove
		{
			HookKeyPress hookKeyPress = hookKeyPress_1;
			HookKeyPress hookKeyPress2;
			do
			{
				hookKeyPress2 = hookKeyPress;
				HookKeyPress value2 = (HookKeyPress)Delegate.Remove(hookKeyPress2, value);
				hookKeyPress = Interlocked.CompareExchange(ref hookKeyPress_1, value2, hookKeyPress2);
			}
			while ((object)hookKeyPress != hookKeyPress2);
		}
	}

	public static void InstallHook()
	{
		if (!IsHookInstalled)
		{
			intptr_1 = Marshal.GetHINSTANCE(AppDomain.CurrentDomain.GetAssemblies()[0].GetModules()[0]);
			hookProc_0 = smethod_0;
			if (bool_1)
			{
				intptr_0 = APINPCGen.SetWindowsHookEx(APINPCGen.HookType.WH_KEYBOARD, hookProc_0, IntPtr.Zero, AppDomain.CurrentDomain.Id);
			}
			else
			{
				intptr_0 = APINPCGen.SetWindowsHookEx(APINPCGen.HookType.WH_KEYBOARD_LL, hookProc_0, intptr_1, 0);
			}
			if (intptr_0 != IntPtr.Zero)
			{
				bool_0 = true;
			}
		}
	}

	public static void UnInstallHook()
	{
		if (IsHookInstalled)
		{
			if (!APINPCGen.UnhookWindowsHookEx(intptr_0))
			{
				throw new Win32Exception(Class16.smethod_0(1649115411));
			}
			intptr_0 = IntPtr.Zero;
			intptr_1 = IntPtr.Zero;
			bool_0 = false;
		}
	}

	private static IntPtr smethod_0(int int_0, IntPtr intptr_2, [In] IntPtr intptr_3)
	{
		if (int_0 == 0)
		{
			LLKHEventArgs e = null;
			if (bool_1)
			{
				bool flag = false;
				if (intptr_3.ToInt32() >> 31 == 0)
				{
					flag = true;
				}
				Keys keys = (Keys)intptr_2.ToInt32();
				e = new LLKHEventArgs(keys, flag, 0u, 0u);
				if (flag)
				{
					hookKeyPress_0?.Invoke(e);
				}
				else
				{
					hookKeyPress_1?.Invoke(e);
				}
			}
			else
			{
				Struct69 @struct = (Struct69)Marshal.PtrToStructure(intptr_3, typeof(Struct69));
				bool flag2 = false;
				if (intptr_2.ToInt32() == 256 || intptr_2.ToInt32() == 260)
				{
					flag2 = true;
				}
				Keys uint_ = (Keys)@struct.uint_2;
				e = new LLKHEventArgs(uint_, flag2, @struct.uint_1, @struct.uint_0);
				if (flag2)
				{
					hookKeyPress_0?.Invoke(e);
				}
				else
				{
					hookKeyPress_1?.Invoke(e);
				}
			}
			if (e != null && e.Hooked)
			{
				return (IntPtr)1;
			}
		}
		return APINPCGen.CallNextHookEx(intptr_0, int_0, intptr_2, intptr_3);
	}
}
