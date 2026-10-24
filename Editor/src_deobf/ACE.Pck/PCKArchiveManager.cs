using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ACE.Classes;
using ACE.Dependency.Ionic.Zlib;
using ACE.Protectors;
using Sentry;

namespace ACE.Pck;

public class PCKArchiveManager : IDisposable
{
	private sealed class Class324
	{
		public string string_0;

		public StringComparison stringComparison_0;

		internal bool method_0(string string_1)
		{
			return string_1.Contains(string_0, stringComparison_0);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct86 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder_0;

		public PCKArchiveManager pckarchiveManager_0;

		public CancellationToken cancellationToken_0;

		private TaskAwaiter<bool> taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PCKArchiveManager pCKArchiveManager = pckarchiveManager_0;
			bool result;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num == 0)
				{
					awaiter = taskAwaiter_0;
					taskAwaiter_0 = default(TaskAwaiter<bool>);
					num = -1;
					int_0 = -1;
					goto IL_0127;
				}
				Class330 @class = new Class330();
				@class.pckarchiveManager_0 = pckarchiveManager_0;
				@class.cancellationToken_0 = cancellationToken_0;
				if (!pCKArchiveManager.IsLoaded)
				{
					result = false;
				}
				else
				{
					@class.pck_0 = pCKArchiveManager.pck_0;
					if (@class.pck_0 != null && @class.pck_0.Pck?.FileTable != null)
					{
						@class.string_0 = pCKArchiveManager.FilePath;
						@class.int_0 = pCKArchiveManager.FileCount;
						awaiter = Task.Run((Func<bool>)@class.method_0, @class.cancellationToken_0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							int_0 = 0;
							taskAwaiter_0 = awaiter;
							asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_0127;
					}
					pCKArchiveManager.method_2(PckOperationStage.Error, 0, 0, 0L, 0L, pCKArchiveManager.FilePath ?? string.Empty, Class16.smethod_0(1649193496));
					result = false;
				}
				goto end_IL_000e;
				IL_0127:
				result = awaiter.GetResult();
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				int_0 = -2;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			asyncTaskMethodBuilder_0.SetResult(result);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private sealed class Class325
	{
		public PCKArchiveManager pckarchiveManager_0;

		public int int_0;

		public string string_0;

		public PCK pck_0;

		public CancellationToken cancellationToken_0;

		public Func<int, string> func_0;

		internal bool method_0()
		{
			try
			{
				pckarchiveManager_0.method_2(PckOperationStage.Defragmenting, 0, int_0, 0L, 0L, string.Empty, Class16.smethod_0(1649194155));
				string text = string_0 + Class16.smethod_0(1649194958);
				PCK_PROTECTION_SETTINGS settings = pck_0.settings;
				ArchiveVersion version = pckarchiveManager_0.Version;
				GAMES game = pck_0.Game;
				FileStream fileStream = new FileStream(text, FileMode.Create, FileAccess.Write);
				try
				{
					BinaryWriter binaryWriter = new BinaryWriter(fileStream);
					try
					{
						binaryWriter.Write(1305093103);
						if (version == ArchiveVersion.V3)
						{
							binaryWriter.Write(0L);
						}
						else
						{
							binaryWriter.Write(0);
						}
						binaryWriter.Write(1453361591);
						int num = 0;
						int num2 = int_0;
						List<int> list = Enumerable.Range(0, num2).OrderBy(method_1).ToList();
						foreach (int item in list)
						{
							if (!cancellationToken_0.IsCancellationRequested)
							{
								PCK.PCK_FILE_TABLE_ENTRY pCK_FILE_TABLE_ENTRY = pck_0.Pck.FileTable[item];
								string text2 = pCK_FILE_TABLE_ENTRY.FilePath ?? string.Empty;
								pckarchiveManager_0.method_2(PckOperationStage.Defragmenting, num, num2, 0L, 0L, text2, Class16.smethod_0(1649194239) + text2 + Class16.smethod_0(1648924410));
								byte[] fileContent = pck_0.Pck.GetFileContent(item);
								if (fileContent == null)
								{
									num++;
									continue;
								}
								byte[] array = Help.ZlibCompress(fileContent, (CompressionLevel)pckarchiveManager_0.CompressionLevel);
								byte[] array2 = ((array.Length < fileContent.Length) ? array : fileContent);
								pCK_FILE_TABLE_ENTRY.Position = fileStream.Position;
								pCK_FILE_TABLE_ENTRY.OriginalSize = (uint)fileContent.Length;
								pCK_FILE_TABLE_ENTRY.CompressedSize = (uint)array2.Length;
								pck_0.Pck.FileTable[item] = pCK_FILE_TABLE_ENTRY;
								binaryWriter.Write(array2);
								num++;
								continue;
							}
							binaryWriter.Close();
							fileStream.Close();
							File.Delete(text);
							pckarchiveManager_0.method_2(PckOperationStage.Cancelled, num, num2, 0L, 0L, string.Empty, Class16.smethod_0(1649194194));
							return false;
						}
						long position = fileStream.Position;
						PCK.PCK_FILE_TABLE_ENTRY[] fileTable = pck_0.Pck.FileTable;
						foreach (PCK.PCK_FILE_TABLE_ENTRY pCK_FILE_TABLE_ENTRY2 in fileTable)
						{
							byte[] bytes = pCK_FILE_TABLE_ENTRY2.GetBytes(bCompress: true, pckarchiveManager_0.CompressionLevel, version);
							int num3 = bytes.Length;
							binaryWriter.Write(settings.KEY_1 ^ num3);
							binaryWriter.Write(settings.KEY_2 ^ num3);
							binaryWriter.Write(bytes);
						}
						pckarchiveManager_0.method_0(binaryWriter, version, settings, position, int_0);
						long position2 = fileStream.Position;
						fileStream.Position = 4L;
						if (version == ArchiveVersion.V3)
						{
							binaryWriter.Write(position2);
						}
						else
						{
							binaryWriter.Write((int)position2);
						}
					}
					finally
					{
						((IDisposable)binaryWriter).Dispose();
					}
				}
				finally
				{
					((IDisposable)fileStream).Dispose();
				}
				pck_0.Close();
				pckarchiveManager_0.method_1(string_0);
				File.Move(text, string_0);
				pckarchiveManager_0.Open(string_0, game);
				pckarchiveManager_0.method_3(bool_3: false);
				pckarchiveManager_0.bool_1 = false;
				pckarchiveManager_0.method_2(PckOperationStage.Completed, int_0, int_0, 0L, 0L, string.Empty, Class16.smethod_0(1649194260));
				return true;
			}
			catch (IOException ioexception_) when (smethod_1(ioexception_))
			{
				pckarchiveManager_0.method_2(PckOperationStage.Error, 0, 0, 0L, 0L, string.Empty, Class16.smethod_0(1649194289));
				return false;
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649194368));
				pckarchiveManager_0.method_2(PckOperationStage.Error, 0, 0, 0L, 0L, string.Empty, Class16.smethod_0(1649194401) + ex.Message);
				return false;
			}
		}

		internal string method_1(int int_1)
		{
			return pck_0.Pck.FileTable[int_1].FilePath ?? string.Empty;
		}
	}

	private sealed class Class326
	{
		public IEnumerable<string> ienumerable_0;

		public PCKArchiveManager pckarchiveManager_0;

		public CancellationToken cancellationToken_0;

		public string string_0;

		internal bool method_0()
		{
			List<string> list = ienumerable_0.ToList();
			int count = list.Count;
			int num = 0;
			pckarchiveManager_0.method_2(PckOperationStage.Extracting, 0, count, 0L, 0L, string.Empty, Class16.smethod_0(1649194816));
			foreach (string item in list)
			{
				if (!cancellationToken_0.IsCancellationRequested)
				{
					string outputPath = System.IO.Path.Combine(string_0, item.Replace('/', '\\'));
					pckarchiveManager_0.method_2(PckOperationStage.Extracting, num, count, 0L, 0L, item, Class16.smethod_0(1649194872) + System.IO.Path.GetFileName(item) + Class16.smethod_0(1648924410));
					pckarchiveManager_0.ExtractFile(item, outputPath);
					num++;
					continue;
				}
				pckarchiveManager_0.method_2(PckOperationStage.Cancelled, num, count, 0L, 0L, string.Empty, Class16.smethod_0(1649194853));
				return false;
			}
			pckarchiveManager_0.method_2(PckOperationStage.Completed, count, count, 0L, 0L, string.Empty, string.Format(Class16.smethod_0(1649194890), count));
			return true;
		}
	}

	private sealed class Class327
	{
		public string string_0;

		internal bool method_0(string string_1)
		{
			return string_1.Contains(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class328
	{
		public Dictionary<string, string> dictionary_0;

		public PCKArchiveManager pckarchiveManager_0;

		public CancellationToken cancellationToken_0;

		internal int method_0()
		{
			int count = dictionary_0.Count;
			int num = 0;
			pckarchiveManager_0.method_2(PckOperationStage.Adding, 0, count, 0L, 0L, string.Empty, Class16.smethod_0(1649194444));
			foreach (KeyValuePair<string, string> item in dictionary_0)
			{
				if (!cancellationToken_0.IsCancellationRequested)
				{
					pckarchiveManager_0.method_2(PckOperationStage.Adding, num, count, 0L, 0L, item.Key, Class16.smethod_0(1649194492) + System.IO.Path.GetFileName(item.Value) + Class16.smethod_0(1648924410));
					if (pckarchiveManager_0.AddFile(item.Key, item.Value))
					{
						num++;
					}
					continue;
				}
				break;
			}
			pckarchiveManager_0.method_2(PckOperationStage.Completed, num, count, 0L, 0L, string.Empty, string.Format(Class16.smethod_0(1649193474), num));
			return num;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct87 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder_0;

		public IEnumerable<string> ienumerable_0;

		public PCKArchiveManager pckarchiveManager_0;

		public CancellationToken cancellationToken_0;

		public string string_0;

		private TaskAwaiter<bool> taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			bool result;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num != 0)
				{
					Class326 @class = new Class326();
					@class.ienumerable_0 = ienumerable_0;
					@class.pckarchiveManager_0 = pckarchiveManager_0;
					@class.cancellationToken_0 = cancellationToken_0;
					@class.string_0 = string_0;
					awaiter = Task.Run((Func<bool>)@class.method_0, @class.cancellationToken_0).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						int_0 = 0;
						taskAwaiter_0 = awaiter;
						asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = taskAwaiter_0;
					taskAwaiter_0 = default(TaskAwaiter<bool>);
					num = -1;
					int_0 = -1;
				}
				result = awaiter.GetResult();
			}
			catch (Exception exception)
			{
				int_0 = -2;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			asyncTaskMethodBuilder_0.SetResult(result);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct88 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder_0;

		public string string_0;

		public PCKArchiveManager pckarchiveManager_0;

		public string string_1;

		public CancellationToken cancellationToken_0;

		private TaskAwaiter<bool> taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PCKArchiveManager pCKArchiveManager = pckarchiveManager_0;
			bool result;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num == 0)
				{
					awaiter = taskAwaiter_0;
					taskAwaiter_0 = default(TaskAwaiter<bool>);
					num = -1;
					int_0 = -1;
					goto IL_00b5;
				}
				Class327 @class = new Class327();
				@class.string_0 = string_0;
				if (pCKArchiveManager.IsLoaded)
				{
					List<string> archivePaths = pCKArchiveManager.GetFilePaths().Where(@class.method_0).ToList();
					awaiter = pCKArchiveManager.ExtractFilesAsync(archivePaths, string_1, cancellationToken_0).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						int_0 = 0;
						taskAwaiter_0 = awaiter;
						asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_00b5;
				}
				result = false;
				goto end_IL_000e;
				IL_00b5:
				result = awaiter.GetResult();
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				int_0 = -2;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			asyncTaskMethodBuilder_0.SetResult(result);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct89 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder_0;

		public PCKArchiveManager pckarchiveManager_0;

		public string string_0;

		public CancellationToken cancellationToken_0;

		private TaskAwaiter<bool> taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PCKArchiveManager pCKArchiveManager = pckarchiveManager_0;
			bool result;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num == 0)
				{
					awaiter = taskAwaiter_0;
					taskAwaiter_0 = default(TaskAwaiter<bool>);
					num = -1;
					int_0 = -1;
					goto IL_0083;
				}
				if (pCKArchiveManager.IsLoaded)
				{
					awaiter = pCKArchiveManager.ExtractFilesAsync(pCKArchiveManager.GetFilePaths(), string_0, cancellationToken_0).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						int_0 = 0;
						taskAwaiter_0 = awaiter;
						asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_0083;
				}
				result = false;
				goto end_IL_000e;
				IL_0083:
				result = awaiter.GetResult();
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				int_0 = -2;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			asyncTaskMethodBuilder_0.SetResult(result);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private sealed class Class329
	{
		public bool bool_0;

		public string string_0;

		internal bool method_0(string string_1)
		{
			if (bool_0)
			{
				return string_1.StartsWith(string_0, StringComparison.OrdinalIgnoreCase);
			}
			if (!string_1.StartsWith(string_0, StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			string text = string_1.Substring(string_0.Length);
			return !text.Contains(Class16.smethod_0(1648927580));
		}
	}

	private sealed class Class330
	{
		public PCKArchiveManager pckarchiveManager_0;

		public int int_0;

		public string string_0;

		public PCK pck_0;

		public CancellationToken cancellationToken_0;

		public Func<int, long> func_0;

		internal bool method_0()
		{
			try
			{
				pckarchiveManager_0.method_2(PckOperationStage.Defragmenting, 0, int_0, 0L, 0L, string.Empty, Class16.smethod_0(1649194924));
				string text = string_0 + Class16.smethod_0(1649194958);
				PCK_PROTECTION_SETTINGS settings = pck_0.settings;
				ArchiveVersion version = pckarchiveManager_0.Version;
				GAMES game = pck_0.Game;
				FileStream fileStream = new FileStream(text, FileMode.Create, FileAccess.Write);
				try
				{
					BinaryWriter binaryWriter = new BinaryWriter(fileStream);
					try
					{
						binaryWriter.Write(1305093103);
						if (version == ArchiveVersion.V3)
						{
							binaryWriter.Write(0L);
						}
						else
						{
							binaryWriter.Write(0);
						}
						binaryWriter.Write(1453361591);
						int num = 0;
						int num2 = int_0;
						List<int> list = Enumerable.Range(0, num2).OrderBy(method_1).ToList();
						foreach (int item in list)
						{
							if (!cancellationToken_0.IsCancellationRequested)
							{
								PCK.PCK_FILE_TABLE_ENTRY pCK_FILE_TABLE_ENTRY = pck_0.Pck.FileTable[item];
								string filePath = pCK_FILE_TABLE_ENTRY.FilePath;
								pckarchiveManager_0.method_2(PckOperationStage.Defragmenting, num, num2, 0L, 0L, filePath, Class16.smethod_0(1649195004) + filePath + Class16.smethod_0(1648924410));
								pck_0.Pck.SetPosition(pCK_FILE_TABLE_ENTRY.Position);
								byte[] buffer = pck_0.Pck.ReadBytes(pCK_FILE_TABLE_ENTRY.CompressedSize);
								pCK_FILE_TABLE_ENTRY.Position = fileStream.Position;
								pck_0.Pck.FileTable[item] = pCK_FILE_TABLE_ENTRY;
								binaryWriter.Write(buffer);
								num++;
								continue;
							}
							binaryWriter.Close();
							fileStream.Close();
							File.Delete(text);
							pckarchiveManager_0.method_2(PckOperationStage.Cancelled, num, num2, 0L, 0L, string.Empty, Class16.smethod_0(1649194972));
							return false;
						}
						long position = fileStream.Position;
						PCK.PCK_FILE_TABLE_ENTRY[] fileTable = pck_0.Pck.FileTable;
						foreach (PCK.PCK_FILE_TABLE_ENTRY pCK_FILE_TABLE_ENTRY2 in fileTable)
						{
							byte[] bytes = pCK_FILE_TABLE_ENTRY2.GetBytes(bCompress: true, pckarchiveManager_0.CompressionLevel, version);
							int num3 = bytes.Length;
							binaryWriter.Write(settings.KEY_1 ^ num3);
							binaryWriter.Write(settings.KEY_2 ^ num3);
							binaryWriter.Write(bytes);
						}
						pckarchiveManager_0.method_0(binaryWriter, version, settings, position, int_0);
						long position2 = fileStream.Position;
						fileStream.Position = 4L;
						if (version == ArchiveVersion.V3)
						{
							binaryWriter.Write(position2);
						}
						else
						{
							binaryWriter.Write((int)position2);
						}
					}
					finally
					{
						((IDisposable)binaryWriter).Dispose();
					}
				}
				finally
				{
					((IDisposable)fileStream).Dispose();
				}
				pck_0.Close();
				pckarchiveManager_0.method_1(string_0);
				File.Move(text, string_0);
				pckarchiveManager_0.Open(string_0, game);
				pckarchiveManager_0.method_3(bool_3: false);
				pckarchiveManager_0.bool_1 = false;
				pckarchiveManager_0.method_2(PckOperationStage.Completed, int_0, int_0, 0L, 0L, string.Empty, Class16.smethod_0(1649193998));
				return true;
			}
			catch (IOException ioexception_) when (smethod_1(ioexception_))
			{
				pckarchiveManager_0.method_2(PckOperationStage.Error, 0, 0, 0L, 0L, string.Empty, Class16.smethod_0(1649194030));
				return false;
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649194096));
				pckarchiveManager_0.method_2(PckOperationStage.Error, 0, 0, 0L, 0L, string.Empty, Class16.smethod_0(1649194133) + ex.Message);
				return false;
			}
		}

		internal long method_1(int int_1)
		{
			return pck_0.Pck.FileTable[int_1].Position;
		}
	}

	private sealed class Class331
	{
		public string string_0;

		public PCKArchiveManager pckarchiveManager_0;

		public CancellationToken cancellationToken_0;

		public string string_1;

		internal int method_0()
		{
			string[] files = Directory.GetFiles(string_0, Class16.smethod_0(1648941528), SearchOption.AllDirectories);
			int int_ = files.Length;
			int num = 0;
			pckarchiveManager_0.method_2(PckOperationStage.Adding, 0, int_, 0L, 0L, string.Empty, Class16.smethod_0(1649194444));
			string[] array = files;
			foreach (string text in array)
			{
				if (!cancellationToken_0.IsCancellationRequested)
				{
					string text2 = text.Substring(string_0.Length).TrimStart('\\', '/');
					string archivePath = (string.IsNullOrEmpty(string_1) ? text2 : System.IO.Path.Combine(string_1, text2));
					pckarchiveManager_0.method_2(PckOperationStage.Adding, num, int_, 0L, 0L, text2, Class16.smethod_0(1649194492) + System.IO.Path.GetFileName(text) + Class16.smethod_0(1648924410));
					if (pckarchiveManager_0.AddFile(archivePath, text))
					{
						num++;
					}
					continue;
				}
				pckarchiveManager_0.method_2(PckOperationStage.Cancelled, num, int_, 0L, 0L, string.Empty, Class16.smethod_0(1649194458));
				break;
			}
			pckarchiveManager_0.method_2(PckOperationStage.Completed, num, int_, 0L, 0L, string.Empty, string.Format(Class16.smethod_0(1649193474), num));
			return num;
		}
	}

	private sealed class Class332
	{
		public string string_0;

		internal bool method_0(string string_1)
		{
			return string_1.EndsWith(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct90 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder<int> asyncTaskMethodBuilder_0;

		public Dictionary<string, string> dictionary_0;

		public PCKArchiveManager pckarchiveManager_0;

		public CancellationToken cancellationToken_0;

		private TaskAwaiter<int> taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PCKArchiveManager pCKArchiveManager = pckarchiveManager_0;
			int result;
			try
			{
				TaskAwaiter<int> awaiter;
				if (num == 0)
				{
					awaiter = taskAwaiter_0;
					taskAwaiter_0 = default(TaskAwaiter<int>);
					num = -1;
					int_0 = -1;
					goto IL_00b1;
				}
				Class328 @class = new Class328();
				@class.dictionary_0 = dictionary_0;
				@class.pckarchiveManager_0 = pckarchiveManager_0;
				@class.cancellationToken_0 = cancellationToken_0;
				if (pCKArchiveManager.IsLoaded)
				{
					awaiter = Task.Run((Func<int>)@class.method_0, @class.cancellationToken_0).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						int_0 = 0;
						taskAwaiter_0 = awaiter;
						asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_00b1;
				}
				result = 0;
				goto end_IL_000f;
				IL_00b1:
				int result2 = awaiter.GetResult();
				result = result2;
				end_IL_000f:;
			}
			catch (Exception exception)
			{
				int_0 = -2;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			asyncTaskMethodBuilder_0.SetResult(result);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct91 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder_0;

		public PCKArchiveManager pckarchiveManager_0;

		public CancellationToken cancellationToken_0;

		private TaskAwaiter<bool> taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PCKArchiveManager pCKArchiveManager = pckarchiveManager_0;
			bool result;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num == 0)
				{
					awaiter = taskAwaiter_0;
					taskAwaiter_0 = default(TaskAwaiter<bool>);
					num = -1;
					int_0 = -1;
					goto IL_0127;
				}
				Class325 @class = new Class325();
				@class.pckarchiveManager_0 = pckarchiveManager_0;
				@class.cancellationToken_0 = cancellationToken_0;
				if (!pCKArchiveManager.IsLoaded)
				{
					result = false;
				}
				else
				{
					@class.pck_0 = pCKArchiveManager.pck_0;
					if (@class.pck_0 != null && @class.pck_0.Pck?.FileTable != null)
					{
						@class.string_0 = pCKArchiveManager.FilePath;
						@class.int_0 = pCKArchiveManager.FileCount;
						awaiter = Task.Run((Func<bool>)@class.method_0, @class.cancellationToken_0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							int_0 = 0;
							taskAwaiter_0 = awaiter;
							asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_0127;
					}
					pCKArchiveManager.method_2(PckOperationStage.Error, 0, 0, 0L, 0L, pCKArchiveManager.FilePath ?? string.Empty, Class16.smethod_0(1649193559));
					result = false;
				}
				goto end_IL_000e;
				IL_0127:
				result = awaiter.GetResult();
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				int_0 = -2;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			asyncTaskMethodBuilder_0.SetResult(result);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct92 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder<int> asyncTaskMethodBuilder_0;

		public string string_0;

		public PCKArchiveManager pckarchiveManager_0;

		public CancellationToken cancellationToken_0;

		public string string_1;

		private TaskAwaiter<int> taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PCKArchiveManager pCKArchiveManager = pckarchiveManager_0;
			int result;
			try
			{
				TaskAwaiter<int> awaiter;
				if (num == 0)
				{
					awaiter = taskAwaiter_0;
					taskAwaiter_0 = default(TaskAwaiter<int>);
					num = -1;
					int_0 = -1;
					goto IL_00d1;
				}
				Class331 @class = new Class331();
				@class.string_0 = string_0;
				@class.pckarchiveManager_0 = pckarchiveManager_0;
				@class.cancellationToken_0 = cancellationToken_0;
				@class.string_1 = string_1;
				if (!pCKArchiveManager.IsLoaded)
				{
					result = 0;
				}
				else
				{
					if (Directory.Exists(@class.string_0))
					{
						awaiter = Task.Run((Func<int>)@class.method_0, @class.cancellationToken_0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							int_0 = 0;
							taskAwaiter_0 = awaiter;
							asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_00d1;
					}
					result = 0;
				}
				goto end_IL_000f;
				IL_00d1:
				int result2 = awaiter.GetResult();
				result = result2;
				end_IL_000f:;
			}
			catch (Exception exception)
			{
				int_0 = -2;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			asyncTaskMethodBuilder_0.SetResult(result);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private sealed class Class333
	{
		public int int_0;

		internal bool method_0(KeyValuePair<string, int> keyValuePair_0)
		{
			return keyValuePair_0.Value > int_0;
		}
	}

	[Serializable]
	private sealed class Class334
	{
		public static readonly Class334 class334_0 = new Class334();

		public static Func<KeyValuePair<string, int>, string> func_0;

		public static Func<int, bool> func_1;

		public static Func<int, int> func_2;

		internal string method_0(KeyValuePair<string, int> keyValuePair_0)
		{
			return keyValuePair_0.Key;
		}

		internal bool method_1(int int_0)
		{
			return int_0 >= 0;
		}

		internal int method_2(int int_0)
		{
			return int_0;
		}
	}

	private sealed class Class335
	{
		public string string_0;

		internal bool method_0(string string_1)
		{
			return string_1.Contains(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private PCK pck_0;

	private bool bool_0;

	private bool bool_1;

	private List<PendingOperation> list_0 = new List<PendingOperation>();

	public CancellationTokenSource _cancellationTokenSource;

	private PckOperationProgressHandler pckOperationProgressHandler_0;

	private int int_0 = 1;

	private bool bool_2;

	private byte[] byte_0;

	private int int_1;

	public PCK Pck => pck_0;

	public string FilePath => pck_0?.FileName;

	public string BaseName => pck_0?.BaseName;

	public bool IsLoaded => pck_0?.FileLoaded ?? false;

	public bool HasUnsavedChanges
	{
		get
		{
			if (!bool_1)
			{
				return list_0.Count > 0;
			}
			return true;
		}
	}

	public ArchiveVersion Version => pck_0?.Pck?.Version ?? ArchiveVersion.V2;

	public int FileCount => pck_0?.FileCount ?? 0;

	public long OriginalSize => pck_0?.OriginalSize ?? 0L;

	public long CompressedSize => pck_0?.CompressedSize ?? 0L;

	public double CompressionRatio
	{
		get
		{
			if (OriginalSize <= 0L)
			{
				return 1.0;
			}
			return (double)CompressedSize / (double)OriginalSize;
		}
	}

	public int CompressionLevel
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public bool RequiresDefrag
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
	}

	public byte[] Data
	{
		[CompilerGenerated]
		get
		{
			return byte_0;
		}
		[CompilerGenerated]
		set
		{
			byte_0 = value;
		}
	}

	public int Index
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public event PckOperationProgressHandler OnProgress
	{
		[CompilerGenerated]
		add
		{
			PckOperationProgressHandler pckOperationProgressHandler = pckOperationProgressHandler_0;
			PckOperationProgressHandler pckOperationProgressHandler2;
			do
			{
				pckOperationProgressHandler2 = pckOperationProgressHandler;
				PckOperationProgressHandler value2 = (PckOperationProgressHandler)Delegate.Combine(pckOperationProgressHandler2, value);
				pckOperationProgressHandler = Interlocked.CompareExchange(ref pckOperationProgressHandler_0, value2, pckOperationProgressHandler2);
			}
			while ((object)pckOperationProgressHandler != pckOperationProgressHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PckOperationProgressHandler pckOperationProgressHandler = pckOperationProgressHandler_0;
			PckOperationProgressHandler pckOperationProgressHandler2;
			do
			{
				pckOperationProgressHandler2 = pckOperationProgressHandler;
				PckOperationProgressHandler value2 = (PckOperationProgressHandler)Delegate.Remove(pckOperationProgressHandler2, value);
				pckOperationProgressHandler = Interlocked.CompareExchange(ref pckOperationProgressHandler_0, value2, pckOperationProgressHandler2);
			}
			while ((object)pckOperationProgressHandler != pckOperationProgressHandler2);
		}
	}

	public PCKArchiveManager()
	{
	}

	public PCKArchiveManager(string filePath, GAMES game = GAMES.UNKNOWN_GAME, PCK_PROTECTION_OPTIONS options = null)
	{
		Open(filePath, game, options);
	}

	public async Task<bool> ExtractFilesAsync(IEnumerable<string> archivePaths, string outputDirectory, CancellationToken cancellationToken = default(CancellationToken))
	{
		Class326 @class = new Class326();
		@class.ienumerable_0 = archivePaths;
		@class.pckarchiveManager_0 = this;
		@class.cancellationToken_0 = cancellationToken;
		@class.string_0 = outputDirectory;
		return await Task.Run((Func<bool>)@class.method_0, @class.cancellationToken_0);
	}

	public async Task<bool> ExtractAllAsync(string outputDirectory, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (!IsLoaded)
		{
			return false;
		}
		return await ExtractFilesAsync(GetFilePaths(), outputDirectory, cancellationToken);
	}

	public async Task<bool> ExtractByPatternAsync(string pattern, string outputDirectory, CancellationToken cancellationToken = default(CancellationToken))
	{
		Class327 @class = new Class327();
		@class.string_0 = pattern;
		if (!IsLoaded)
		{
			return false;
		}
		List<string> archivePaths = GetFilePaths().Where(@class.method_0).ToList();
		return await ExtractFilesAsync(archivePaths, outputDirectory, cancellationToken);
	}

	public bool AddFile(string archivePath, byte[] data)
	{
		if (!IsLoaded)
		{
			return false;
		}
		try
		{
			archivePath = archivePath.Replace('/', '\\');
			if (archivePath.StartsWith(Class16.smethod_0(1648927580)))
			{
				archivePath = archivePath.Substring(1);
			}
			byte[] array = Help.ZlibCompress(data, (CompressionLevel)CompressionLevel);
			byte[] array2 = ((array.Length < data.Length) ? array : data);
			int fileIndex = GetFileIndex(archivePath);
			if (fileIndex >= 0)
			{
				PCK.PCK_FILE_TABLE_ENTRY pCK_FILE_TABLE_ENTRY = pck_0.Pck.FileTable[fileIndex];
				if (array2.Length <= pCK_FILE_TABLE_ENTRY.CompressedSize)
				{
					pCK_FILE_TABLE_ENTRY.OriginalSize = (uint)data.Length;
					pCK_FILE_TABLE_ENTRY.CompressedSize = (uint)array2.Length;
					pck_0.Pck.SetPosition(pCK_FILE_TABLE_ENTRY.Position);
					pck_0.Pck.OpenWrite();
					pck_0.Pck.WriteBytes(array2);
					pck_0.Pck.FileTable[fileIndex] = pCK_FILE_TABLE_ENTRY;
				}
				else
				{
					pCK_FILE_TABLE_ENTRY.OriginalSize = (uint)data.Length;
					pCK_FILE_TABLE_ENTRY.CompressedSize = (uint)array2.Length;
					pCK_FILE_TABLE_ENTRY.Position = pck_0.Pck.MaxFilePosition;
					pck_0.Pck.OpenWrite();
					pck_0.Pck.SetPosition(pCK_FILE_TABLE_ENTRY.Position);
					pck_0.Pck.WriteBytes(array2);
					pck_0.Pck.MaxFilePosition = pck_0.Pck.Position;
					pck_0.Pck.LastFilePositionIndex = fileIndex;
					pck_0.Pck.FileTable[fileIndex] = pCK_FILE_TABLE_ENTRY;
					method_3(bool_3: true);
				}
			}
			else
			{
				pck_0.Pck.AddFile(archivePath, data);
				pck_0.FileTableIndices[PCK.FixPath(archivePath)] = pck_0.Pck.EntryCount - 1;
			}
			bool_1 = true;
			return true;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649193611));
			method_2(PckOperationStage.Error, 0, 0, 0L, 0L, archivePath, Class16.smethod_0(1649193644) + ex.Message);
			return false;
		}
	}

	public bool AddFile(string archivePath, string diskPath)
	{
		if (!File.Exists(diskPath))
		{
			return false;
		}
		return AddFile(archivePath, File.ReadAllBytes(diskPath));
	}

	public async Task<int> AddFilesFromDirectoryAsync(string sourceDirectory, string archiveBasePath = "", CancellationToken cancellationToken = default(CancellationToken))
	{
		Class331 @class = new Class331();
		@class.string_0 = sourceDirectory;
		@class.pckarchiveManager_0 = this;
		@class.cancellationToken_0 = cancellationToken;
		@class.string_1 = archiveBasePath;
		if (!IsLoaded)
		{
			return 0;
		}
		if (!Directory.Exists(@class.string_0))
		{
			return 0;
		}
		return await Task.Run((Func<int>)@class.method_0, @class.cancellationToken_0);
	}

	public async Task<int> AddFilesAsync(Dictionary<string, string> archivePathToDiskPath, CancellationToken cancellationToken = default(CancellationToken))
	{
		Class328 @class = new Class328();
		@class.dictionary_0 = archivePathToDiskPath;
		@class.pckarchiveManager_0 = this;
		@class.cancellationToken_0 = cancellationToken;
		if (!IsLoaded)
		{
			return 0;
		}
		return await Task.Run((Func<int>)@class.method_0, @class.cancellationToken_0);
	}

	public bool RemoveFile(string archivePath)
	{
		if (!IsLoaded)
		{
			return false;
		}
		int fileIndex = GetFileIndex(archivePath);
		if (fileIndex < 0)
		{
			return false;
		}
		return RemoveFileByIndex(fileIndex);
	}

	public bool RemoveFileByIndex(int index)
	{
		Class333 @class = new Class333();
		@class.int_0 = index;
		if (!IsLoaded)
		{
			return false;
		}
		if (@class.int_0 >= 0 && @class.int_0 < pck_0.Pck.EntryCount)
		{
			try
			{
				string filePath = pck_0.Pck.FileTable[@class.int_0].FilePath;
				string key = PCK.FixPath(filePath);
				PCK.RemoveArrayElement(ref pck_0.Pck.FileTable, @class.int_0);
				pck_0.Pck.EntryCount--;
				pck_0.FileTableIndices.Remove(key);
				List<string> list = pck_0.FileTableIndices.Where(@class.method_0).Select(Class334.class334_0.method_0).ToList();
				foreach (string item in list)
				{
					pck_0.FileTableIndices[item]--;
				}
				bool_1 = true;
				method_3(bool_3: true);
				return true;
			}
			catch
			{
				return false;
			}
		}
		return false;
	}

	public int RemoveFiles(IEnumerable<string> archivePaths)
	{
		int num = 0;
		List<int> list = archivePaths.Select(method_4).Where(Class334.class334_0.method_1).OrderByDescending(Class334.class334_0.method_2)
			.ToList();
		foreach (int item in list)
		{
			if (RemoveFileByIndex(item))
			{
				num++;
			}
		}
		return num;
	}

	public int RemoveByPattern(string pattern)
	{
		Class335 @class = new Class335();
		@class.string_0 = pattern;
		if (!IsLoaded)
		{
			return 0;
		}
		List<string> archivePaths = GetFilePaths().Where(@class.method_0).ToList();
		return RemoveFiles(archivePaths);
	}

	public void ClearAllFiles()
	{
		if (IsLoaded)
		{
			pck_0.Pck.FileTable = new PCK.PCK_FILE_TABLE_ENTRY[0];
			pck_0.Pck.EntryCount = 0;
			pck_0.Pck.MaxFilePosition = pck_0.Pck.Version.GetHeaderSize();
			pck_0.FileTableIndices.Clear();
			bool_1 = true;
			method_3(bool_3: true);
		}
	}

	public bool Save(bool truncateFile = true)
	{
		if (!IsLoaded)
		{
			return false;
		}
		EditorSessionTracker.LogFolderAccess(FilePath, Class16.smethod_0(1649006856), Class16.smethod_0(1649198241));
		try
		{
			method_2(PckOperationStage.Saving, 0, 1, 0L, 0L, FilePath, Class16.smethod_0(1649193670));
			bool result;
			if (result = pck_0.Save(truncateFile))
			{
				bool_1 = false;
				method_2(PckOperationStage.Completed, 1, 1, 0L, 0L, FilePath, Class16.smethod_0(1649193694));
			}
			else
			{
				method_2(PckOperationStage.Error, 0, 1, 0L, 0L, FilePath, Class16.smethod_0(1649193727));
			}
			return result;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649193756));
			method_2(PckOperationStage.Error, 0, 0, 0L, 0L, string.Empty, Class16.smethod_0(1649193770) + ex.Message);
			return false;
		}
	}

	public bool SaveAs(string newPath)
	{
		if (!IsLoaded)
		{
			return false;
		}
		EditorSessionTracker.LogFolderAccess(newPath, Class16.smethod_0(1649006856), Class16.smethod_0(1649198241));
		try
		{
			File.Copy(FilePath, newPath, overwrite: true);
			string text = FilePath.Replace(Class16.smethod_0(1648909411), Class16.smethod_0(1648989712));
			string destFileName = newPath.Replace(Class16.smethod_0(1648909411), Class16.smethod_0(1648989712));
			if (File.Exists(text))
			{
				File.Copy(text, destFileName, overwrite: true);
			}
			int num = 1;
			while (true)
			{
				string text2 = FilePath.Replace(Class16.smethod_0(1648909411), string.Format(Class16.smethod_0(1649193807), num));
				if (!File.Exists(text2))
				{
					break;
				}
				string destFileName2 = newPath.Replace(Class16.smethod_0(1648909411), string.Format(Class16.smethod_0(1649193807), num));
				File.Copy(text2, destFileName2, overwrite: true);
				num++;
			}
			GAMES game = pck_0.Game;
			Close();
			return Open(newPath, game);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649193821));
			method_2(PckOperationStage.Error, 0, 0, 0L, 0L, string.Empty, Class16.smethod_0(1649193845) + ex.Message);
			return false;
		}
	}

	public async Task<bool> DefragAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		Class330 @class = new Class330();
		@class.pckarchiveManager_0 = this;
		@class.cancellationToken_0 = cancellationToken;
		if (!IsLoaded)
		{
			return false;
		}
		@class.pck_0 = pck_0;
		if (@class.pck_0 != null && @class.pck_0.Pck?.FileTable != null)
		{
			@class.string_0 = FilePath;
			@class.int_0 = FileCount;
			return await Task.Run((Func<bool>)@class.method_0, @class.cancellationToken_0);
		}
		method_2(PckOperationStage.Error, 0, 0, 0L, 0L, FilePath ?? string.Empty, Class16.smethod_0(1649193496));
		return false;
	}

	public async Task<bool> FullDefragAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		Class325 @class = new Class325();
		@class.pckarchiveManager_0 = this;
		@class.cancellationToken_0 = cancellationToken;
		if (!IsLoaded)
		{
			return false;
		}
		@class.pck_0 = pck_0;
		if (@class.pck_0 != null && @class.pck_0.Pck?.FileTable != null)
		{
			@class.string_0 = FilePath;
			@class.int_0 = FileCount;
			return await Task.Run((Func<bool>)@class.method_0, @class.cancellationToken_0);
		}
		method_2(PckOperationStage.Error, 0, 0, 0L, 0L, FilePath ?? string.Empty, Class16.smethod_0(1649193559));
		return false;
	}

	public List<string> SearchFiles(string pattern, bool caseSensitive = false)
	{
		Class324 @class = new Class324();
		@class.string_0 = pattern;
		if (!IsLoaded)
		{
			return new List<string>();
		}
		@class.stringComparison_0 = (caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
		return GetFilePaths().Where(@class.method_0).ToList();
	}

	public List<string> SearchByExtension(string extension)
	{
		Class332 @class = new Class332();
		@class.string_0 = extension;
		if (!IsLoaded)
		{
			return new List<string>();
		}
		if (!@class.string_0.StartsWith(Class16.smethod_0(1648928036)))
		{
			@class.string_0 = Class16.smethod_0(1648928036) + @class.string_0;
		}
		return GetFilePaths().Where(@class.method_0).ToList();
	}

	public List<string> GetFilesInDirectory(string directory, bool recursive = true)
	{
		Class329 @class = new Class329();
		@class.bool_0 = recursive;
		@class.string_0 = directory;
		if (!IsLoaded)
		{
			return new List<string>();
		}
		@class.string_0 = PCK.FixPath(@class.string_0);
		if (!@class.string_0.EndsWith(Class16.smethod_0(1648927580)))
		{
			@class.string_0 += Class16.smethod_0(1648927580);
		}
		return GetFilePaths().Where(@class.method_0).ToList();
	}

	private void method_0(BinaryWriter binaryWriter_0, ArchiveVersion archiveVersion_0, PCK_PROTECTION_SETTINGS pck_PROTECTION_SETTINGS_0, long long_0, int int_2)
	{
		binaryWriter_0.Write(4261281518u);
		binaryWriter_0.Write((archiveVersion_0 == ArchiveVersion.V3) ? 131075u : 131074u);
		if (archiveVersion_0 == ArchiveVersion.V3)
		{
			binaryWriter_0.Write(long_0 ^ pck_PROTECTION_SETTINGS_0.KEY_1);
		}
		else
		{
			binaryWriter_0.Write((int)(long_0 ^ pck_PROTECTION_SETTINGS_0.KEY_1));
		}
		binaryWriter_0.Write(0);
		byte[] array = new byte[252];
		byte[] bytes = Encoding.ASCII.GetBytes(Class16.smethod_0(1649199549));
		Array.Copy(bytes, array, Math.Min(bytes.Length, 252));
		binaryWriter_0.Write(array);
		binaryWriter_0.Write(4027432687u);
		if (archiveVersion_0 == ArchiveVersion.V3)
		{
			binaryWriter_0.Write(0);
		}
		binaryWriter_0.Write(int_2);
		binaryWriter_0.Write((archiveVersion_0 == ArchiveVersion.V3) ? 131075u : 131074u);
	}

	private void method_1(string string_0)
	{
		if (File.Exists(string_0))
		{
			smethod_0(string_0, 8, 150);
		}
		string text = string_0.Replace(Class16.smethod_0(1648909411), Class16.smethod_0(1648989712));
		if (File.Exists(text))
		{
			smethod_0(text, 8, 150);
		}
		int num = 1;
		while (true)
		{
			string text2 = string_0.Replace(Class16.smethod_0(1648909411), string.Format(Class16.smethod_0(1649193807), num));
			if (File.Exists(text2))
			{
				smethod_0(text2, 8, 150);
				num++;
				continue;
			}
			break;
		}
	}

	private static void smethod_0(string string_0, int int_2, int int_3)
	{
		Exception innerException = null;
		for (int i = 0; i < int_2; i++)
		{
			try
			{
				File.Delete(string_0);
				if (!File.Exists(string_0))
				{
					return;
				}
			}
			catch (IOException ex)
			{
				innerException = ex;
			}
			catch (UnauthorizedAccessException ex2)
			{
				innerException = ex2;
			}
			Thread.Sleep(int_3);
		}
		throw new IOException(Class16.smethod_0(1649193869) + string_0 + Class16.smethod_0(1649193891), innerException);
	}

	private static bool smethod_1(IOException ioexception_0)
	{
		if (ioexception_0.HResult != -2147024864 && !ioexception_0.Message.Contains(Class16.smethod_0(1649193937), StringComparison.OrdinalIgnoreCase) && !ioexception_0.Message.Contains(Class16.smethod_0(1649193975), StringComparison.OrdinalIgnoreCase) && !ioexception_0.Message.Contains(Class16.smethod_0(1649192983), StringComparison.OrdinalIgnoreCase))
		{
			if (ioexception_0.InnerException is IOException ioexception_1)
			{
				return smethod_1(ioexception_1);
			}
			return false;
		}
		return true;
	}

	private void method_2(PckOperationStage pckOperationStage_0, int int_2, int int_3, long long_0, long long_1, string string_0, string string_1)
	{
		pckOperationProgressHandler_0?.Invoke(this, new PckOperationProgressEventArgs
		{
			Stage = pckOperationStage_0,
			CurrentIndex = int_2,
			TotalCount = int_3,
			ProcessedBytes = long_0,
			TotalBytes = long_1,
			CurrentFile = string_0,
			StatusMessage = string_1
		});
	}

	public void CancelOperation()
	{
		_cancellationTokenSource?.Cancel();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!bool_0)
		{
			if (disposing)
			{
				Close();
				_cancellationTokenSource?.Dispose();
			}
			bool_0 = true;
		}
	}

	~PCKArchiveManager()
	{
		Dispose(disposing: false);
	}

	private void method_3(bool bool_3)
	{
		bool_2 = bool_3;
	}

	public bool Open(string filePath, GAMES game = GAMES.UNKNOWN_GAME, PCK_PROTECTION_OPTIONS options = null)
	{
		try
		{
			method_2(PckOperationStage.Opening, 0, 1, 0L, 0L, filePath, Class16.smethod_0(1649193020));
			Close();
			if (!File.Exists(filePath))
			{
				throw new FileNotFoundException(Class16.smethod_0(1648993218), filePath);
			}
			pck_0 = new PCK(filePath, game, options);
			if (!pck_0.FileLoaded)
			{
				throw new InvalidDataException(Class16.smethod_0(1649193045));
			}
			pck_0.CreatePathsArray();
			bool_1 = false;
			method_3(bool_3: false);
			list_0.Clear();
			method_2(PckOperationStage.Completed, 1, 1, 0L, 0L, filePath, string.Format(Class16.smethod_0(1649193132), FileCount));
			return true;
		}
		catch (IOException ex)
		{
			Close();
			SentryHelper.CaptureMessage(Class16.smethod_0(1649193160) + ex.Message + Class16.smethod_0(1649198770) + filePath, (SentryLevel)2, Class16.smethod_0(1649193193));
			method_2(PckOperationStage.Error, 0, 0, 0L, 0L, filePath, Class16.smethod_0(1649193227) + ex.Message);
			return false;
		}
		catch (InvalidDataException ex2)
		{
			Close();
			SentryHelper.CaptureMessage(Class16.smethod_0(1649193276) + ex2.Message + Class16.smethod_0(1649198770) + filePath, (SentryLevel)2, Class16.smethod_0(1649193316));
			method_2(PckOperationStage.Error, 0, 0, 0L, 0L, filePath, Class16.smethod_0(1649193350) + ex2.Message);
			return false;
		}
		catch (Exception ex3)
		{
			Close();
			SentryHelper.CaptureException(ex3, Class16.smethod_0(1649193379));
			method_2(PckOperationStage.Error, 0, 0, 0L, 0L, string.Empty, Class16.smethod_0(1649193401) + ex3.Message);
			return false;
		}
	}

	public void Close()
	{
		if (pck_0 != null)
		{
			pck_0.Close();
			pck_0 = null;
		}
		bool_1 = false;
		list_0.Clear();
	}

	public bool CreateNew(string filePath, ArchiveVersion version = ArchiveVersion.V2, GAMES game = GAMES.PW)
	{
		try
		{
			method_2(PckOperationStage.Writing, 0, 1, 0L, 0L, filePath, Class16.smethod_0(1649193439));
			Close();
			PCK_PROTECTION_SETTINGS defaultKeys = PCK.GetDefaultKeys(game);
			FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(fileStream);
				try
				{
					binaryWriter.Write(1305093103);
					if (version == ArchiveVersion.V3)
					{
						binaryWriter.Write(0L);
					}
					else
					{
						binaryWriter.Write(0);
					}
					binaryWriter.Write(1453361591);
					long position = fileStream.Position;
					binaryWriter.Write(4261281518u);
					binaryWriter.Write((version == ArchiveVersion.V3) ? 131075u : 131074u);
					if (version == ArchiveVersion.V3)
					{
						binaryWriter.Write(position ^ defaultKeys.KEY_1);
					}
					else
					{
						binaryWriter.Write((int)(position ^ defaultKeys.KEY_1));
					}
					binaryWriter.Write(0);
					byte[] array = new byte[252];
					byte[] bytes = Encoding.ASCII.GetBytes(Class16.smethod_0(1649199549));
					Array.Copy(bytes, array, Math.Min(bytes.Length, 252));
					binaryWriter.Write(array);
					binaryWriter.Write(4027432687u);
					if (version == ArchiveVersion.V3)
					{
						binaryWriter.Write(0);
					}
					binaryWriter.Write(0);
					binaryWriter.Write((version == ArchiveVersion.V3) ? 131075u : 131074u);
					long position2 = fileStream.Position;
					fileStream.Position = 4L;
					if (version == ArchiveVersion.V3)
					{
						binaryWriter.Write(position2);
					}
					else
					{
						binaryWriter.Write((int)position2);
					}
				}
				finally
				{
					((IDisposable)binaryWriter).Dispose();
				}
			}
			finally
			{
				((IDisposable)fileStream).Dispose();
			}
			return Open(filePath, game);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649193469));
			method_2(PckOperationStage.Error, 0, 0, 0L, 0L, string.Empty, Class16.smethod_0(1649196560) + ex.Message);
			return false;
		}
	}

	public string[] GetFilePaths()
	{
		PCK pCK = pck_0;
		object obj;
		if (pCK == null)
		{
			obj = null;
		}
		else
		{
			obj = pCK.Paths;
			if (obj != null)
			{
				goto IL_001c;
			}
		}
		obj = new string[0];
		goto IL_001c;
		IL_001c:
		return (string[])obj;
	}

	public byte[] GetFile(string path)
	{
		return pck_0?.GetFileB(path);
	}

	public byte[] GetFile(int index)
	{
		return pck_0?.GetFileB(index);
	}

	public bool FileExists(string path)
	{
		return pck_0?.IsFileExist(path) ?? false;
	}

	public PCK.PCK_FILE_TABLE_ENTRY? GetFileEntry(int index)
	{
		if (pck_0?.Pck?.FileTable != null && index >= 0 && index < pck_0.Pck.FileTable.Length)
		{
			return pck_0.Pck.FileTable[index];
		}
		return null;
	}

	public int GetFileIndex(string path)
	{
		if (pck_0?.FileTableIndices != null)
		{
			string key = PCK.FixPath(path);
			if (pck_0.FileTableIndices.TryGetValue(key, out var value))
			{
				return value;
			}
		}
		return -1;
	}

	public bool ExtractFile(string archivePath, string outputPath)
	{
		try
		{
			byte[] file = GetFile(archivePath);
			if (file == null)
			{
				return false;
			}
			string directoryName = System.IO.Path.GetDirectoryName(outputPath);
			if (!string.IsNullOrEmpty(directoryName) && !Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			File.WriteAllBytes(outputPath, file);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public bool RenameFile(string oldPath, string newPath)
	{
		if (!IsLoaded)
		{
			return false;
		}
		try
		{
			oldPath = oldPath.Replace('/', '\\');
			newPath = newPath.Replace('/', '\\');
			if (oldPath.StartsWith(Class16.smethod_0(1648927580)))
			{
				oldPath = oldPath.Substring(1);
			}
			if (newPath.StartsWith(Class16.smethod_0(1648927580)))
			{
				newPath = newPath.Substring(1);
			}
			int fileIndex = GetFileIndex(oldPath);
			if (fileIndex < 0)
			{
				return false;
			}
			string key = PCK.FixPath(oldPath);
			string key2 = PCK.FixPath(newPath);
			if (pck_0.FileTableIndices.ContainsKey(key2))
			{
				return false;
			}
			PCK.PCK_FILE_TABLE_ENTRY pCK_FILE_TABLE_ENTRY = pck_0.Pck.FileTable[fileIndex];
			pCK_FILE_TABLE_ENTRY.FilePath = newPath;
			pck_0.Pck.FileTable[fileIndex] = pCK_FILE_TABLE_ENTRY;
			pck_0.FileTableIndices.Remove(key);
			pck_0.FileTableIndices[key2] = fileIndex;
			bool_1 = true;
			return true;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649196599));
			return false;
		}
	}

	public bool RenameFolder(string oldFolderPath, string newFolderPath)
	{
		if (!IsLoaded)
		{
			return false;
		}
		try
		{
			oldFolderPath = oldFolderPath.Replace('/', '\\').TrimEnd('\\') + Class16.smethod_0(1648927580);
			newFolderPath = newFolderPath.Replace('/', '\\').TrimEnd('\\') + Class16.smethod_0(1648927580);
			if (oldFolderPath.StartsWith(Class16.smethod_0(1648927580)))
			{
				oldFolderPath = oldFolderPath.Substring(1);
			}
			if (newFolderPath.StartsWith(Class16.smethod_0(1648927580)))
			{
				newFolderPath = newFolderPath.Substring(1);
			}
			bool flag = false;
			for (int i = 0; i < pck_0.Pck.EntryCount; i++)
			{
				PCK.PCK_FILE_TABLE_ENTRY pCK_FILE_TABLE_ENTRY = pck_0.Pck.FileTable[i];
				string text = pCK_FILE_TABLE_ENTRY.FilePath.Replace('/', '\\');
				if (text.StartsWith(Class16.smethod_0(1648927580)))
				{
					text = text.Substring(1);
				}
				if (text.StartsWith(oldFolderPath, StringComparison.OrdinalIgnoreCase))
				{
					string key = PCK.FixPath(pCK_FILE_TABLE_ENTRY.FilePath);
					string text2 = newFolderPath + text.Substring(oldFolderPath.Length);
					string key2 = PCK.FixPath(text2);
					pCK_FILE_TABLE_ENTRY.FilePath = text2;
					pck_0.Pck.FileTable[i] = pCK_FILE_TABLE_ENTRY;
					pck_0.FileTableIndices.Remove(key);
					pck_0.FileTableIndices[key2] = i;
					flag = true;
				}
			}
			if (flag)
			{
				bool_1 = true;
			}
			return flag;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649196619));
			return false;
		}
	}

	public void SetArchiveKeys(int key1, int key2, int ftoKey)
	{
		if (IsLoaded && pck_0?.Pck != null)
		{
			pck_0.settings.KEY_1 = key1;
			pck_0.settings.KEY_2 = key2;
			pck_0.settings.FTO_KEY = ftoKey;
			bool_1 = true;
		}
	}

	public (int KEY_1, int KEY_2, int FTO_KEY) GetArchiveKeys()
	{
		if (!IsLoaded)
		{
			return (KEY_1: 0, KEY_2: 0, FTO_KEY: 0);
		}
		return (KEY_1: pck_0.settings.KEY_1, KEY_2: pck_0.settings.KEY_2, FTO_KEY: pck_0.settings.FTO_KEY);
	}

	private int method_4(string string_0)
	{
		return GetFileIndex(string_0);
	}
}
