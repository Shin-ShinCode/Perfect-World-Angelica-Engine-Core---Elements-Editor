using System;
using System.IO;
using System.IO.Pipes;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using ACE.Classes;

namespace ACE.Mcp;

public static class McpBridgeServer
{
	private static class Class236
	{
		public static ThreadStart threadStart_0;
	}

	private sealed class Class237
	{
		public NamedPipeServerStream namedPipeServerStream_0;

		internal void method_0()
		{
			smethod_2(namedPipeServerStream_0);
		}
	}

	private static CancellationTokenSource cancellationTokenSource_0;

	private static Thread thread_0;

	private static volatile bool bool_0;

	public static bool IsRunning => bool_0;

	public static void Start()
	{
		if (!bool_0)
		{
			cancellationTokenSource_0 = new CancellationTokenSource();
			bool_0 = true;
			thread_0 = new Thread(smethod_1)
			{
				IsBackground = true,
				Name = Class16.smethod_0(1649121141)
			};
			thread_0.Start();
		}
	}

	public static void Stop()
	{
		if (bool_0)
		{
			bool_0 = false;
			cancellationTokenSource_0?.Cancel();
			cancellationTokenSource_0?.Dispose();
			cancellationTokenSource_0 = null;
		}
	}

	private static NamedPipeServerStream smethod_0()
	{
		PipeSecurity pipeSecurity = new PipeSecurity();
		pipeSecurity.AddAccessRule(new PipeAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), PipeAccessRights.ReadWrite, AccessControlType.Allow));
		pipeSecurity.AddAccessRule(new PipeAccessRule(WindowsIdentity.GetCurrent().Owner, PipeAccessRights.FullControl, AccessControlType.Allow));
		return new NamedPipeServerStream(Class16.smethod_0(1649121155), PipeDirection.InOut, -1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous, 0, 0, pipeSecurity);
	}

	private static void smethod_1()
	{
		CancellationToken token = cancellationTokenSource_0.Token;
		while (bool_0 && !token.IsCancellationRequested)
		{
			NamedPipeServerStream namedPipeServerStream = null;
			try
			{
				Class237 @class = new Class237();
				namedPipeServerStream = smethod_0();
				IAsyncResult asyncResult = namedPipeServerStream.BeginWaitForConnection(null, null);
				while (!asyncResult.AsyncWaitHandle.WaitOne(500))
				{
					if (token.IsCancellationRequested)
					{
						namedPipeServerStream.Dispose();
						return;
					}
				}
				namedPipeServerStream.EndWaitForConnection(asyncResult);
				@class.namedPipeServerStream_0 = namedPipeServerStream;
				namedPipeServerStream = null;
				Thread thread = new Thread(@class.method_0)
				{
					IsBackground = true,
					Name = Class16.smethod_0(1649121176)
				};
				thread.Start();
			}
			catch (OperationCanceledException)
			{
				break;
			}
			catch (Exception ex2)
			{
				SentryHelper.CaptureException(ex2, Class16.smethod_0(1649121206));
				Thread.Sleep(1000);
			}
			finally
			{
				namedPipeServerStream?.Dispose();
			}
		}
	}

	private static void smethod_2(NamedPipeServerStream namedPipeServerStream_0)
	{
		try
		{
			using (namedPipeServerStream_0)
			{
				StreamReader streamReader = new StreamReader(namedPipeServerStream_0, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
				try
				{
					using StreamWriter streamWriter = new StreamWriter(namedPipeServerStream_0, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false))
					{
						AutoFlush = true
					};
					string text;
					while ((text = streamReader.ReadLine()) != null)
					{
						if (!string.IsNullOrWhiteSpace(text))
						{
							string value = McpRequestHandler.HandleRequest(text);
							streamWriter.WriteLine(value);
						}
					}
				}
				finally
				{
					((IDisposable)streamReader).Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649121239));
		}
	}
}
