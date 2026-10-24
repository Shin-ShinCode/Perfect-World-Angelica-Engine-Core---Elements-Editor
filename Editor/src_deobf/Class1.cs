using System;
using System.Diagnostics;
using System.Threading;

internal static class Class1
{
	internal sealed class Class2 : Interface2<int>, Interface4<int>, Interface0, Interface1, Interface3
	{
		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		public int int_4;

		private int int_5;

		private Interface4<int> interface4_0;

		[DebuggerHidden]
		public Class2(int int_6)
		{
			int_0 = int_6;
			int_2 = Thread.CurrentThread.ManagedThreadId;
		}

		[DebuggerHidden]
		void Interface1.imethod_0()
		{
			int num = int_0;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					method_0();
				}
			}
			interface4_0 = null;
			int_0 = -2;
		}

		private bool imethod_1()
		{
			bool result;
			try
			{
				switch (int_0)
				{
				default:
					result = false;
					goto end_IL_0000;
				case 1:
					int_0 = -3;
					if (int_5 != 0)
					{
						break;
					}
					result = false;
					method_0();
					goto end_IL_0000;
				case 0:
				{
					int_0 = -1;
					int_5 = 7;
					int num = int_3;
					interface4_0 = ((Interface2<int>)new Class3(-2)
					{
						int_4 = num
					}).GetEnumerator();
					int_0 = -3;
					break;
				}
				}
				if (!interface4_0.imethod_1())
				{
					method_0();
					interface4_0 = null;
					result = false;
				}
				else
				{
					int num2 = interface4_0.imethod_3() ^ int_3;
					if ((num2 & 3) == 0)
					{
						num2 ^= 0x778BF18C;
					}
					int num3 = int_5 - 1;
					int_5 = num3;
					if ((num2 & 0xF) == 0)
					{
						num2 ^= -1189707964;
					}
					int_1 = num2;
					int_0 = 1;
					result = true;
				}
				end_IL_0000:;
			}
			catch
			{
				//try-fault
				((Interface1)this).imethod_0();
				throw;
			}
			return result;
		}

		bool Interface3.imethod_1()
		{
			//ILSpy generated this explicit interface implementation from .override directive in imethod_1
			return this.imethod_1();
		}

		private void method_0()
		{
			int_0 = -1;
			if (interface4_0 != null)
			{
				((Interface1)interface4_0).imethod_0();
			}
		}

		[DebuggerHidden]
		int Interface4<int>.imethod_3()
		{
			return int_1;
		}

		[DebuggerHidden]
		void Interface3.imethod_2()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		object Interface3.imethod_0()
		{
			return int_1;
		}

		[DebuggerHidden]
		Interface4<int> Interface2<int>.GetEnumerator()
		{
			Class2 @class;
			if (int_0 == -2 && int_2 == Thread.CurrentThread.ManagedThreadId)
			{
				int_0 = 0;
				@class = this;
			}
			else
			{
				@class = new Class2(0);
			}
			@class.int_3 = int_4;
			return @class;
		}

		[DebuggerHidden]
		Interface3 Interface0.imethod_0()
		{
			return ((Interface2<int>)this).GetEnumerator();
		}
	}

	internal sealed class Class3 : Interface2<int>, Interface4<int>, Interface0, Interface1, Interface3
	{
		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		public int int_4;

		private int int_5;

		private int int_6;

		private Interface4<int> interface4_0;

		private int int_7;

		[DebuggerHidden]
		public Class3(int int_8)
		{
			int_0 = int_8;
			int_2 = Thread.CurrentThread.ManagedThreadId;
		}

		[DebuggerHidden]
		void Interface1.imethod_0()
		{
			int num = int_0;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					method_0();
				}
			}
			interface4_0 = null;
			int_0 = -2;
		}

		private bool imethod_1()
		{
			bool result;
			try
			{
				switch (int_0)
				{
				default:
					result = false;
					goto end_IL_0000;
				case 1:
					int_0 = -3;
					int_3--;
					if (int_3 != 0)
					{
						int num = int_6;
						int_6 = (num + int_5 + int_3) ^ (-1358275320 + int_7);
						int_5 = num;
						break;
					}
					result = false;
					method_0();
					goto end_IL_0000;
				case 0:
					int_0 = -1;
					int_5 = 0;
					int_6 = 1;
					interface4_0 = ((Interface2<int>)new Class4(-2)).GetEnumerator();
					int_0 = -3;
					break;
				}
				if (!interface4_0.imethod_1())
				{
					method_0();
					interface4_0 = null;
					result = false;
				}
				else
				{
					int_7 = interface4_0.imethod_3();
					int_1 = int_6;
					int_0 = 1;
					result = true;
				}
				end_IL_0000:;
			}
			catch
			{
				//try-fault
				((Interface1)this).imethod_0();
				throw;
			}
			return result;
		}

		bool Interface3.imethod_1()
		{
			//ILSpy generated this explicit interface implementation from .override directive in imethod_1
			return this.imethod_1();
		}

		private void method_0()
		{
			int_0 = -1;
			if (interface4_0 != null)
			{
				((Interface1)interface4_0).imethod_0();
			}
		}

		[DebuggerHidden]
		int Interface4<int>.imethod_3()
		{
			return int_1;
		}

		[DebuggerHidden]
		void Interface3.imethod_2()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		object Interface3.imethod_0()
		{
			return int_1;
		}

		[DebuggerHidden]
		Interface4<int> Interface2<int>.GetEnumerator()
		{
			Class3 @class;
			if (int_0 == -2 && int_2 == Thread.CurrentThread.ManagedThreadId)
			{
				int_0 = 0;
				@class = this;
			}
			else
			{
				@class = new Class3(0);
			}
			@class.int_3 = int_4;
			return @class;
		}

		[DebuggerHidden]
		Interface3 Interface0.imethod_0()
		{
			return ((Interface2<int>)this).GetEnumerator();
		}
	}

	internal sealed class Class4 : Interface2<int>, Interface4<int>, Interface0, Interface1, Interface3
	{
		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		[DebuggerHidden]
		public Class4(int int_4)
		{
			int_0 = int_4;
			int_2 = Thread.CurrentThread.ManagedThreadId;
		}

		[DebuggerHidden]
		void Interface1.imethod_0()
		{
			int_0 = -2;
		}

		private bool imethod_1()
		{
			switch (int_0)
			{
			default:
				return false;
			case 1:
				int_0 = -1;
				int_3 += int_3;
				if (int_3 == 64)
				{
					int_3 = 5;
				}
				break;
			case 0:
				int_0 = -1;
				int_3 = 1;
				break;
			}
			int_1 = int_3;
			int_0 = 1;
			return true;
		}

		bool Interface3.imethod_1()
		{
			//ILSpy generated this explicit interface implementation from .override directive in imethod_1
			return this.imethod_1();
		}

		[DebuggerHidden]
		int Interface4<int>.imethod_3()
		{
			return int_1;
		}

		[DebuggerHidden]
		void Interface3.imethod_2()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		object Interface3.imethod_0()
		{
			return int_1;
		}

		[DebuggerHidden]
		Interface4<int> Interface2<int>.GetEnumerator()
		{
			if (int_0 == -2 && int_2 == Thread.CurrentThread.ManagedThreadId)
			{
				int_0 = 0;
				return this;
			}
			return new Class4(0);
		}

		[DebuggerHidden]
		Interface3 Interface0.imethod_0()
		{
			return ((Interface2<int>)this).GetEnumerator();
		}
	}
}
