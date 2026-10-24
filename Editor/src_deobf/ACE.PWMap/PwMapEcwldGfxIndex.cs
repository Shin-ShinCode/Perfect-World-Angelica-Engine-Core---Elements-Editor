using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ACE.PWMap;

internal sealed class PwMapEcwldGfxIndex
{
	private sealed class Class295 : IEnumerable, IEnumerator, IDisposable, IEnumerable<GfxEntry>, IEnumerator<GfxEntry>
	{
		private int int_0;

		private GfxEntry gfxEntry_0;

		private int int_1;

		public PwMapEcwldGfxIndex pwMapEcwldGfxIndex_0;

		private List<GfxEntry>.Enumerator enumerator_0;

		GfxEntry IEnumerator<GfxEntry>.Current
		{
			[DebuggerHidden]
			get
			{
				return gfxEntry_0;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return gfxEntry_0;
			}
		}

		[DebuggerHidden]
		public Class295(int int_2)
		{
			int_0 = int_2;
			int_1 = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
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
			enumerator_0 = default(List<GfxEntry>.Enumerator);
			int_0 = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = int_0;
				PwMapEcwldGfxIndex pwMapEcwldGfxIndex = pwMapEcwldGfxIndex_0;
				switch (num)
				{
				default:
					return false;
				case 1:
					int_0 = -3;
					break;
				case 0:
					int_0 = -1;
					enumerator_0 = pwMapEcwldGfxIndex.list_0.GetEnumerator();
					int_0 = -3;
					break;
				}
				GfxEntry current;
				do
				{
					if (enumerator_0.MoveNext())
					{
						current = enumerator_0.Current;
						continue;
					}
					method_0();
					enumerator_0 = default(List<GfxEntry>.Enumerator);
					return false;
				}
				while (string.IsNullOrWhiteSpace(current.Path) || !current.Path.EndsWith(Class16.smethod_0(1649119451), StringComparison.OrdinalIgnoreCase));
				gfxEntry_0 = current;
				int_0 = 1;
				return true;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void method_0()
		{
			int_0 = -1;
			((IDisposable)enumerator_0/*cast due to constrained. prefix*/).Dispose();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<GfxEntry> IEnumerable<GfxEntry>.GetEnumerator()
		{
			Class295 @class;
			if (int_0 == -2 && int_1 == Environment.CurrentManagedThreadId)
			{
				int_0 = 0;
				@class = this;
			}
			else
			{
				@class = new Class295(0);
				@class.pwMapEcwldGfxIndex_0 = pwMapEcwldGfxIndex_0;
			}
			return @class;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<GfxEntry>)this).GetEnumerator();
		}
	}

	public struct GfxEntry
	{
		public int ExportId;

		public float Scale;

		public float PosX;

		public float PosY;

		public float PosZ;

		public float DirX;

		public float DirY;

		public float DirZ;

		public float UpX;

		public float UpY;

		public float UpZ;

		public float Speed;

		public int ValidTime;

		public float Alpha;

		public int Attenuation;

		public string Path;

		public int BlockIndex;
	}

	private readonly List<GfxEntry> list_0 = new List<GfxEntry>(512);

	public IReadOnlyList<GfxEntry> Entries => list_0;

	public static PwMapEcwldGfxIndex Build(string ecwldPath)
	{
		PwMapEcwldGfxIndex pwMapEcwldGfxIndex = new PwMapEcwldGfxIndex();
		if (!string.IsNullOrWhiteSpace(ecwldPath) && File.Exists(ecwldPath))
		{
			byte[] array;
			try
			{
				array = File.ReadAllBytes(ecwldPath);
			}
			catch
			{
				return pwMapEcwldGfxIndex;
			}
			if (array.Length < 128)
			{
				return pwMapEcwldGfxIndex;
			}
			int num = BitConverter.ToInt32(array, 4);
			if (num < 4)
			{
				return pwMapEcwldGfxIndex;
			}
			smethod_3(array, num, pwMapEcwldGfxIndex.list_0);
			return pwMapEcwldGfxIndex;
		}
		return pwMapEcwldGfxIndex;
	}

	private static int smethod_0(byte[] byte_0, int int_0)
	{
		if (int_0 >= 0 && int_0 + 4 <= byte_0.Length)
		{
			return BitConverter.ToInt32(byte_0, int_0);
		}
		return 0;
	}

	private static float smethod_1(byte[] byte_0, int int_0)
	{
		if (int_0 >= 0 && int_0 + 4 <= byte_0.Length)
		{
			return BitConverter.ToSingle(byte_0, int_0);
		}
		return 0f;
	}

	private static bool smethod_2(byte[] byte_0, int int_0, int int_1)
	{
		if (int_0 >= 0)
		{
			return int_0 + int_1 <= byte_0.Length;
		}
		return false;
	}

	private static void smethod_3(byte[] byte_0, int int_0, List<GfxEntry> list_1)
	{
		int num = BitConverter.ToInt32(byte_0, 24);
		int int_1 = BitConverter.ToInt32(byte_0, 36);
		int int_2 = BitConverter.ToInt32(byte_0, 40);
		if (num <= 0 || num > 100000)
		{
			return;
		}
		int num2 = 116;
		if (116 + num * 4 > byte_0.Length)
		{
			return;
		}
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = BitConverter.ToInt32(byte_0, num2 + i * 4);
		}
		Encoding encoding_;
		try
		{
			encoding_ = Encoding.GetEncoding(Class16.smethod_0(1648921191));
		}
		catch
		{
			encoding_ = Encoding.Default;
		}
		for (int j = 0; j < num; j++)
		{
			int num3 = array[j];
			if (num3 >= 0 && num3 < byte_0.Length)
			{
				long long_ = smethod_4(num3, array, int_1, int_2, byte_0.Length);
				smethod_5(byte_0, int_0, num3, long_, j, encoding_, list_1);
			}
		}
	}

	private static long smethod_4(int int_0, int[] int_1, int int_2, int int_3, int int_4)
	{
		long num = int_4;
		for (int i = 0; i < int_1.Length; i++)
		{
			if (int_1[i] > int_0 && int_1[i] < num)
			{
				num = int_1[i];
			}
		}
		if (int_2 > int_0 && int_2 < num)
		{
			num = int_2;
		}
		if (int_3 > int_0 && int_3 < num)
		{
			num = int_3;
		}
		return num;
	}

	private static void smethod_5(byte[] byte_0, int int_0, int int_1, long long_0, int int_2, Encoding encoding_0, List<GfxEntry> list_1)
	{
		if (long_0 - int_1 < 32L)
		{
			return;
		}
		int num = int_1 + 4;
		if (!smethod_2(byte_0, num, 20))
		{
			return;
		}
		int num2 = smethod_0(byte_0, num);
		num += 4;
		int num3 = smethod_0(byte_0, num);
		num += 4;
		int num4 = smethod_0(byte_0, num);
		num += 4;
		int num5 = smethod_0(byte_0, num);
		num += 4;
		int num6 = smethod_0(byte_0, num);
		num += 4;
		if (!smethod_6(num2, num3, num4, num5, num6))
		{
			return;
		}
		int num7 = 0;
		if (int_0 >= 4 && smethod_2(byte_0, num, 12))
		{
			num7 = smethod_0(byte_0, num);
			num += 4;
			num += 8;
		}
		if (num7 <= 0 || num7 > 50000)
		{
			return;
		}
		if (int_0 >= 7 && smethod_2(byte_0, num, 4))
		{
			num += 4;
		}
		if (int_0 >= 9 && smethod_2(byte_0, num, 4))
		{
			num += 4;
		}
		if (int_0 == 14 && smethod_2(byte_0, num, 8))
		{
			num += 8;
		}
		if (int_0 >= 16 && int_0 < 17 && smethod_2(byte_0, num, 4))
		{
			num += 4;
		}
		if (int_0 >= 17 && smethod_2(byte_0, num, 8))
		{
			num += 8;
		}
		long num8 = num2 * 16L + (num3 + num5 + num6 + num4) * 8L;
		long num9 = num + num8;
		if (num9 < 0L || num9 >= long_0)
		{
			long num10 = num + 4 + num8;
			if (num10 < 0L || num10 >= long_0)
			{
				return;
			}
			num9 = num10;
		}
		smethod_7(byte_0, int_0, (int)num9, long_0, int_2, num7, encoding_0, list_1);
	}

	private static bool smethod_6(int int_0, int int_1, int int_2, int int_3, int int_4)
	{
		if (int_0 >= 0 && int_0 < 100000 && int_1 >= 0 && int_1 < 100000 && int_2 >= 0 && int_2 < 100000 && int_3 >= 0 && int_3 < 100000 && int_4 >= 0)
		{
			return int_4 < 100000;
		}
		return false;
	}

	private static void smethod_7(byte[] byte_0, int int_0, int int_1, long long_0, int int_2, int int_3, Encoding encoding_0, List<GfxEntry> list_1)
	{
		int num = int_1;
		for (int i = 0; i < int_3; i++)
		{
			int int_4 = smethod_8(int_0);
			if (!smethod_2(byte_0, num, int_4))
			{
				break;
			}
			GfxEntry item = new GfxEntry
			{
				BlockIndex = int_2
			};
			item.ExportId = smethod_0(byte_0, num);
			num += 4;
			item.Scale = smethod_1(byte_0, num);
			num += 4;
			item.PosX = smethod_1(byte_0, num);
			num += 4;
			item.PosY = smethod_1(byte_0, num);
			num += 4;
			item.PosZ = smethod_1(byte_0, num);
			num += 4;
			item.DirX = smethod_1(byte_0, num);
			num += 4;
			item.DirY = smethod_1(byte_0, num);
			num += 4;
			item.DirZ = smethod_1(byte_0, num);
			num += 4;
			item.UpX = smethod_1(byte_0, num);
			num += 4;
			item.UpY = smethod_1(byte_0, num);
			num += 4;
			item.UpZ = smethod_1(byte_0, num);
			num += 4;
			if (int_0 >= 6)
			{
				item.Speed = smethod_1(byte_0, num);
				num += 4;
			}
			else
			{
				item.Speed = 1f;
			}
			if (int_0 >= 8)
			{
				item.ValidTime = smethod_0(byte_0, num);
				num += 4;
			}
			if (int_0 >= 12)
			{
				item.Alpha = smethod_1(byte_0, num);
				num += 4;
				item.Attenuation = smethod_0(byte_0, num);
				num += 4;
			}
			else
			{
				item.Alpha = 1f;
			}
			if (!smethod_2(byte_0, num, 4))
			{
				break;
			}
			int num2 = smethod_0(byte_0, num);
			num += 4;
			if (num2 > 0 && num2 <= 8192 && smethod_2(byte_0, num, num2))
			{
				item.Path = encoding_0.GetString(byte_0, num, num2).Replace('\\', '/').Trim('\0', ' ', '\t', '\r', '\n');
				num += num2;
				if (!string.IsNullOrWhiteSpace(item.Path) && item.ExportId > 0)
				{
					list_1.Add(item);
				}
			}
			else if (num2 > 0)
			{
				num += num2;
			}
		}
	}

	private static int smethod_8(int int_0)
	{
		int num = 44;
		if (int_0 >= 6)
		{
			num += 4;
		}
		if (int_0 >= 8)
		{
			num += 4;
		}
		if (int_0 >= 12)
		{
			num += 8;
		}
		return num + 4;
	}

	public IEnumerable<GfxEntry> GetGfxPaths()
	{
		return new Class295(-2)
		{
			pwMapEcwldGfxIndex_0 = this
		};
	}
}
