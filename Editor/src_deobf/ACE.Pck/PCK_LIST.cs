using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using ACE.Classes;
using ACE.Protectors;
using ACE.RSGlobal;

namespace ACE.Pck;

public class PCK_LIST
{
	private sealed class Class347
	{
		public PCK pck_0;

		internal PCK method_0(string string_0, PCK pck_1)
		{
			return pck_0;
		}
	}

	private sealed class Class348
	{
		public PCK pck_0;

		internal PCK method_0(string string_0, PCK pck_1)
		{
			return pck_0;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct106 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder<int> asyncTaskMethodBuilder_0;

		public string[] string_0;

		public PCK_LIST pck_LIST_0;

		public CancellationToken cancellationToken_0;

		private int int_1;

		private ConfiguredTaskAwaitable<bool[]>.ConfiguredTaskAwaiter configuredTaskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PCK_LIST pCK_LIST = pck_LIST_0;
			int result;
			try
			{
				ConfiguredTaskAwaitable<bool[]>.ConfiguredTaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = configuredTaskAwaiter_0;
					configuredTaskAwaiter_0 = default(ConfiguredTaskAwaitable<bool[]>.ConfiguredTaskAwaiter);
					num = -1;
					int_0 = -1;
					goto IL_00d3;
				}
				if (string_0 != null && string_0.Length != 0)
				{
					int_1 = 0;
					List<Task<bool>> list = new List<Task<bool>>();
					string[] array = string_0;
					foreach (string pck_name in array)
					{
						list.Add(pCK_LIST.LoadPckAsync(pck_name, cancellationToken_0));
					}
					awaiter = Task.WhenAll(list).ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						int_0 = 0;
						configuredTaskAwaiter_0 = awaiter;
						asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_00d3;
				}
				result = 0;
				goto end_IL_000e;
				IL_00d3:
				bool[] result2 = awaiter.GetResult();
				bool[] array2 = result2;
				bool[] array3 = array2;
				for (int j = 0; j < array3.Length; j++)
				{
					if (array3[j])
					{
						int_1++;
					}
				}
				result = int_1;
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
	private struct Struct107 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder_0;

		public PCK_LIST pck_LIST_0;

		public string string_0;

		public CancellationToken cancellationToken_0;

		private Class349 class349_0;

		private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter configuredTaskAwaiter_0;

		private ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter configuredTaskAwaiter_1;

		private void MoveNext()
		{
			int num = int_0;
			PCK_LIST pCK_LIST = pck_LIST_0;
			bool result;
			try
			{
				ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = configuredTaskAwaiter_0;
					configuredTaskAwaiter_0 = default(ConfiguredTaskAwaitable.ConfiguredTaskAwaiter);
					num = -1;
					int_0 = -1;
					goto IL_0139;
				}
				if (num == 1)
				{
					goto IL_0141;
				}
				class349_0 = new Class349();
				class349_0.pck_LIST_0 = pck_LIST_0;
				class349_0.string_1 = string_0;
				PCK value;
				if (pCK_LIST.FileNames != null && pCK_LIST.PCKs != null)
				{
					if (pCK_LIST.PCKs.TryGetValue(class349_0.string_1, out value) && value != null && value.FileLoaded)
					{
						result = true;
					}
					else if (!pCK_LIST.FileNames.TryGetValue(class349_0.string_1, out class349_0.string_0))
					{
						result = false;
					}
					else
					{
						if (File.Exists(class349_0.string_0))
						{
							awaiter = pCK_LIST.semaphoreSlim_0.WaitAsync(cancellationToken_0).ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = 0;
								int_0 = 0;
								configuredTaskAwaiter_0 = awaiter;
								asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
								return;
							}
							goto IL_0139;
						}
						result = false;
					}
				}
				else
				{
					result = false;
				}
				goto end_IL_000e;
				IL_0139:
				awaiter.GetResult();
				goto IL_0141;
				IL_0141:
				try
				{
					ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter awaiter2;
					if (num == 1)
					{
						awaiter2 = configuredTaskAwaiter_1;
						configuredTaskAwaiter_1 = default(ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter);
						num = -1;
						int_0 = -1;
						goto IL_01e8;
					}
					if (!pCK_LIST.PCKs.TryGetValue(class349_0.string_1, out value) || value == null || !value.FileLoaded)
					{
						awaiter2 = Task.Run((Func<bool>)class349_0.method_0, cancellationToken_0).ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = 1;
							int_0 = 1;
							configuredTaskAwaiter_1 = awaiter2;
							asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
							return;
						}
						goto IL_01e8;
					}
					result = true;
					goto end_IL_0141;
					IL_01e8:
					result = awaiter2.GetResult();
					end_IL_0141:;
				}
				finally
				{
					if (num < 0)
					{
						pCK_LIST.semaphoreSlim_0.Release();
					}
				}
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				int_0 = -2;
				class349_0 = null;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			class349_0 = null;
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

	private sealed class Class349
	{
		public string string_0;

		public PCK_LIST pck_LIST_0;

		public string string_1;

		internal bool method_0()
		{
			Class348 @class = new Class348();
			GAMES game = CommonStorage.Params.Game;
			@class.pck_0 = new PCK(string_0, game, PCK_PROTECTION_OPTIONS.ImportFromParams(CommonStorage.Params));
			if (@class.pck_0 != null && @class.pck_0.FileLoaded)
			{
				pck_LIST_0.PCKs.AddOrUpdate(string_1, @class.pck_0, @class.method_0);
				GC.KeepAlive(pck_LIST_0);
				return true;
			}
			return false;
		}
	}

	private sealed class Class350
	{
		public PCK pck_0;

		internal PCK method_0(string string_0, PCK pck_1)
		{
			return pck_0;
		}
	}

	public static CommonStorage CStorage;

	public ConcurrentDictionary<string, PCK> PCKs;

	public ConcurrentDictionary<string, string> FileNames;

	private readonly object object_0 = new object();

	private readonly SemaphoreSlim semaphoreSlim_0 = new SemaphoreSlim(1, 1);

	public PCK Textures => this[Class16.smethod_0(1649121484)];

	public PCK Sfx => this[Class16.smethod_0(1649141703)];

	public PCK Gfx => this[Class16.smethod_0(1649141675)];

	public PCK Surfaces => this[Class16.smethod_0(1649067915)];

	public PCK Configs => this[Class16.smethod_0(1648991932)];

	public PCK Models
	{
		get
		{
			PCK result = this[CommonStorage.AParams.ModelsPckBaseName];
			GC.KeepAlive(this);
			return result;
		}
	}

	public PCK this[string pck_name]
	{
		get
		{
			Class347 @class = new Class347();
			@class.pck_0 = null;
			if (PCKs != null && FileNames != null && FileNames.TryGetValue(pck_name, out var value) && (!PCKs.TryGetValue(pck_name, out @class.pck_0) || @class.pck_0 == null || !@class.pck_0.FileLoaded) && File.Exists(value))
			{
				GAMES game = CommonStorage.Params.Game;
				@class.pck_0 = new PCK(value, game, PCK_PROTECTION_OPTIONS.ImportFromParams(CommonStorage.Params));
				PCKs.AddOrUpdate(pck_name, @class.pck_0, @class.method_0);
			}
			GC.KeepAlive(this);
			return @class.pck_0;
		}
	}

	public PCK_LIST(string[] PckFiles)
	{
		SetPcksList(PckFiles);
	}

	public PCK_LIST()
	{
	}

	public void SetPcksList(string[] PckFiles)
	{
		if (PckFiles != null && PckFiles.Length != 0)
		{
			FileNames = new ConcurrentDictionary<string, string>(Environment.ProcessorCount, PckFiles.Length);
			foreach (string text in PckFiles)
			{
				if (!string.IsNullOrWhiteSpace(text) && File.Exists(text))
				{
					string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(text);
					FileNames.TryAdd(fileNameWithoutExtension, text);
				}
			}
			PCKs = new ConcurrentDictionary<string, PCK>(Environment.ProcessorCount, FileNames.Count);
			GC.KeepAlive(this);
		}
		else
		{
			FileNames = null;
			PCKs?.Clear();
			PCKs = null;
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool LoadPck(string pck_name)
	{
		if (FileNames != null && PCKs != null)
		{
			if (PCKs.TryGetValue(pck_name, out var value) && value != null && value.FileLoaded)
			{
				return true;
			}
			if (!FileNames.TryGetValue(pck_name, out var value2))
			{
				return false;
			}
			if (!File.Exists(value2))
			{
				return false;
			}
			lock (object_0)
			{
				Class350 @class = new Class350();
				if (PCKs.TryGetValue(pck_name, out value) && value != null && value.FileLoaded)
				{
					return true;
				}
				GAMES game = CommonStorage.Params.Game;
				@class.pck_0 = new PCK(value2, game, PCK_PROTECTION_OPTIONS.ImportFromParams(CommonStorage.Params));
				if (@class.pck_0 != null && @class.pck_0.FileLoaded)
				{
					PCKs.AddOrUpdate(pck_name, @class.pck_0, @class.method_0);
					GC.KeepAlive(this);
					return true;
				}
			}
			GC.KeepAlive(this);
			return false;
		}
		return false;
	}

	public async Task<bool> LoadPckAsync(string pck_name, CancellationToken cancellationToken = default(CancellationToken))
	{
		Class349 @class = new Class349
		{
			pck_LIST_0 = this,
			string_1 = pck_name
		};
		if (FileNames != null && PCKs != null)
		{
			if (PCKs.TryGetValue(@class.string_1, out var value) && value != null && value.FileLoaded)
			{
				return true;
			}
			if (!FileNames.TryGetValue(@class.string_1, out @class.string_0))
			{
				return false;
			}
			if (!File.Exists(@class.string_0))
			{
				return false;
			}
			await semaphoreSlim_0.WaitAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			try
			{
				if (PCKs.TryGetValue(@class.string_1, out value) && value != null && value.FileLoaded)
				{
					return true;
				}
				return await Task.Run((Func<bool>)@class.method_0, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			finally
			{
				semaphoreSlim_0.Release();
			}
		}
		return false;
	}

	public async Task<int> LoadMultiplePcksAsync(string[] pck_names, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (pck_names != null && pck_names.Length != 0)
		{
			int num = 0;
			List<Task<bool>> list = new List<Task<bool>>();
			foreach (string pck_name in pck_names)
			{
				list.Add(LoadPckAsync(pck_name, cancellationToken));
			}
			bool[] array = await Task.WhenAll(list).ConfigureAwait(continueOnCapturedContext: false);
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j])
				{
					num++;
				}
			}
			return num;
		}
		return 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe bool IsFileExist(string path)
	{
		string text = null;
		string pathRoot = ACE.RSGlobal.RSGlobal.GetPathRoot(path);
		if (pathRoot == null)
		{
			GC.KeepAlive(this);
			return false;
		}
		pathRoot = pathRoot.ToLowerInvariant();
		PCK pCK = this[pathRoot];
		bool result = false;
		if (pCK != null && LoadIfNotLoaded(pathRoot))
		{
			text = path;
			int num = -1;
			result = pCK.TryGetFileIndex(ref text, &num);
		}
		GC.KeepAlive(this);
		return result;
	}

	public byte[] GetFileB(string path)
	{
		if (!CommonStorage.Params.UsePck)
		{
			return null;
		}
		string pathRoot = ACE.RSGlobal.RSGlobal.GetPathRoot(path);
		if (pathRoot == null)
		{
			GC.KeepAlive(this);
			return null;
		}
		pathRoot = pathRoot.ToLowerInvariant();
		PCK pCK = this[pathRoot];
		byte[] result = null;
		if (pCK != null && LoadIfNotLoaded(pathRoot))
		{
			result = pCK.GetFileB(path);
		}
		GC.KeepAlive(this);
		return result;
	}

	public string[] GetPckNames()
	{
		if (FileNames == null)
		{
			return Array.Empty<string>();
		}
		string[] result = FileNames.Keys.ToArray();
		GC.KeepAlive(this);
		return result;
	}

	public void Reset()
	{
		if (PCKs != null)
		{
			foreach (KeyValuePair<string, PCK> pCK in PCKs)
			{
				pCK.Value?.Close();
			}
			PCKs.Clear();
		}
		PCKs = null;
		FileNames = null;
	}

	public void CloseAllFiles()
	{
		if (PCKs != null)
		{
			foreach (KeyValuePair<string, PCK> pCK in PCKs)
			{
				pCK.Value?.Close();
			}
		}
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool LoadIfNotLoaded(string pck_name)
	{
		return this[pck_name]?.FileLoaded ?? false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsPckLoaded(string pck_name)
	{
		if (PCKs == null)
		{
			return false;
		}
		PCK value;
		bool result = PCKs.TryGetValue(pck_name, out value) && value != null && value.FileLoaded;
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsPckExist(string pck_name)
	{
		if (pck_name != null && FileNames != null)
		{
			string value;
			bool result = FileNames.TryGetValue(pck_name, out value) && File.Exists(value);
			GC.KeepAlive(this);
			return result;
		}
		return false;
	}

	private void method_0(PCK pck_0, ref List<string> list_0)
	{
		if (pck_0 != null && pck_0.FileLoaded)
		{
			list_0.Add(pck_0.BaseName);
		}
		GC.KeepAlive(this);
	}
}
