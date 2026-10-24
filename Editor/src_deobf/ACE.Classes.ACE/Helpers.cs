using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ACE.Classes.ACE;

public static class Helpers
{
	private sealed class Class53
	{
		public int int_0;

		internal string method_0(Match match_0)
		{
			return Class16.smethod_0(1648908124) + int_0++ + Class16.smethod_0(1648908132);
		}

		internal string method_1(Match match_0)
		{
			return Class16.smethod_0(1648908124) + int_0++ + Class16.smethod_0(1648908140) + match_0.Groups[1]?.ToString() + Class16.smethod_0(1648908132);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct39 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		public TimeSpan timeSpan_0;

		public Action action_0;

		private TaskAwaiter taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			try
			{
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						awaiter = Task.Delay(timeSpan_0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							int_0 = 0;
							taskAwaiter_0 = awaiter;
							asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
					}
					else
					{
						awaiter = taskAwaiter_0;
						taskAwaiter_0 = default(TaskAwaiter);
						num = -1;
						int_0 = -1;
					}
					awaiter.GetResult();
					action_0();
				}
				catch (Exception ex)
				{
					SentryHelper.CaptureException(ex, Class16.smethod_0(1648908149));
				}
			}
			catch (Exception exception)
			{
				int_0 = -2;
				asyncVoidMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			asyncVoidMethodBuilder_0.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	public static async void WithDelay(Action action, TimeSpan delay)
	{
		try
		{
			await Task.Delay(delay);
			action();
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648908149));
		}
	}

	public static string ConvertCStringToCompositeFormatting(string string_0, out int _valCount)
	{
		Class53 @class = new Class53();
		string text = string_0.Replace(Class16.smethod_0(1648908173), Class16.smethod_0(1648923229));
		@class.int_0 = 0;
		if (text.Contains(Class16.smethod_0(1648908182)))
		{
			text = Regex.Replace(text, Class16.smethod_0(1648908182), @class.method_0);
		}
		if (text.Contains(Class16.smethod_0(1648908191)))
		{
			text = Regex.Replace(text, Class16.smethod_0(1648908192), @class.method_1);
		}
		_valCount = @class.int_0;
		return text;
	}

	public static byte[] Hex2Bytes(this string hexString)
	{
		if (hexString.Length % 2 == 1)
		{
			throw new Exception(Class16.smethod_0(1648908208));
		}
		byte[] array = new byte[hexString.Length >> 1];
		for (int i = 0; i < hexString.Length >> 1; i++)
		{
			array[i] = (byte)((smethod_0(hexString[i << 1]) << 4) + smethod_0(hexString[(i << 1) + 1]));
		}
		return array;
	}

	[CompilerGenerated]
	internal static int smethod_0(char hex)
	{
		return hex - ((hex < ':') ? 48 : 55);
	}
}
