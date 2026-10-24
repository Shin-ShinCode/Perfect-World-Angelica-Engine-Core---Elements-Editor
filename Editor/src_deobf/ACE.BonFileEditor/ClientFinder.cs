using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ACE.BonFileEditor;

public class ClientFinder
{
	private sealed class Class52 : IEnumerable, IEnumerable<ClientWindow>, IEnumerator<ClientWindow>, IEnumerator, IDisposable
	{
		private int int_0;

		private ClientWindow clientWindow_0;

		private int int_1;

		public ClientFinder clientFinder_0;

		private IntPtr intptr_0;

		ClientWindow IEnumerator<ClientWindow>.Current
		{
			[DebuggerHidden]
			get
			{
				return clientWindow_0;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return clientWindow_0;
			}
		}

		[DebuggerHidden]
		public Class52(int int_2)
		{
			int_0 = int_2;
			int_1 = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int_0 = -2;
		}

		private bool MoveNext()
		{
			int num = int_0;
			ClientFinder clientFinder = clientFinder_0;
			switch (num)
			{
			default:
				return false;
			case 0:
				int_0 = -1;
				intptr_0 = IntPtr.Zero;
				break;
			case 1:
				int_0 = -1;
				break;
			case 2:
				int_0 = -1;
				break;
			}
			intptr_0 = WinApi.FindWindowEx(IntPtr.Zero, intptr_0, Class16.smethod_0(1648912872), null);
			if (!(intptr_0 == IntPtr.Zero))
			{
				WinApi.GetWindowThreadProcessId(intptr_0, out var lpdwProcessId);
				MemoryManager memoryManager = new MemoryManager(MemFunctions.OpenProcess(lpdwProcessId));
				string text = memoryManager.ChainReadString_Unicode64(clientFinder.method_0(), 32, clientFinder.method_2(), clientFinder.method_4(), clientFinder.method_6(), 0);
				if (text != string.Empty)
				{
					string name = string.Format(Class16.smethod_0(1648912699), text);
					clientWindow_0 = new ClientWindow(name, lpdwProcessId);
					int_0 = 1;
					return true;
				}
				clientWindow_0 = new ClientWindow(WinApi.GetWindowText(intptr_0), lpdwProcessId);
				int_0 = 2;
				return true;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<ClientWindow> IEnumerable<ClientWindow>.GetEnumerator()
		{
			Class52 @class;
			if (int_0 == -2 && int_1 == Environment.CurrentManagedThreadId)
			{
				int_0 = 0;
				@class = this;
			}
			else
			{
				@class = new Class52(0);
				@class.clientFinder_0 = clientFinder_0;
			}
			return @class;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ClientWindow>)this).GetEnumerator();
		}
	}

	private long long_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	public IEnumerable<ClientWindow> ClientWindows
	{
		get
		{
			Class52 @class = new Class52(-2);
			@class.clientFinder_0 = this;
			return @class;
		}
	}

	public ClientFinder(long base_address, int game_struct_offset, int host_player_struct_offset, int host_player_name_offset)
	{
		method_1(base_address);
		method_3(game_struct_offset);
		method_5(host_player_struct_offset);
		method_7(host_player_name_offset);
	}

	private long method_0()
	{
		return long_0;
	}

	private void method_1(long long_1)
	{
		long_0 = long_1;
	}

	private int method_2()
	{
		return int_0;
	}

	private void method_3(int int_4)
	{
		int_0 = int_4;
	}

	private int method_4()
	{
		return int_1;
	}

	private void method_5(int int_4)
	{
		int_1 = int_4;
	}

	private int method_6()
	{
		return int_2;
	}

	private void method_7(int int_4)
	{
		int_2 = int_4;
	}

	private int method_8()
	{
		return int_3;
	}

	private void method_9(int int_4)
	{
		int_3 = int_4;
	}

	public bool IsProcessExist(int process_id)
	{
		IntPtr intPtr = IntPtr.Zero;
		while (true)
		{
			intPtr = WinApi.FindWindowEx(IntPtr.Zero, intPtr, Class16.smethod_0(1648912872), null);
			if (intPtr == IntPtr.Zero)
			{
				break;
			}
			WinApi.GetWindowThreadProcessId(intPtr, out var lpdwProcessId);
			if (lpdwProcessId == process_id)
			{
				return true;
			}
		}
		return false;
	}
}
