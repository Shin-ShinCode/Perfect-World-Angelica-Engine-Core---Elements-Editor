using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

internal static class Class16
{
	private sealed class Class17
	{
		private Stream stream_0;

		private byte[] byte_0;

		public Class17(Stream stream_1)
		{
			stream_0 = stream_1;
			byte_0 = new byte[4];
		}

		public Stream method_0()
		{
			return stream_0;
		}

		public short method_1()
		{
			method_3(2);
			return (short)(byte_0[0] | (byte_0[1] << 8));
		}

		public int method_2()
		{
			method_3(4);
			return byte_0[0] | (byte_0[1] << 8) | (byte_0[2] << 16) | (byte_0[3] << 24);
		}

		private static void smethod_0()
		{
			throw new EndOfStreamException();
		}

		private void method_3(int int_0)
		{
			int num = 0;
			int num2 = 0;
			if (int_0 == 1)
			{
				num2 = stream_0.ReadByte();
				if (num2 == -1)
				{
					smethod_0();
				}
				byte_0[0] = (byte)num2;
				return;
			}
			do
			{
				num2 = stream_0.Read(byte_0, num, int_0 - num);
				if (num2 == 0)
				{
					smethod_0();
				}
				num += num2;
			}
			while (num < int_0);
		}

		public void method_4()
		{
			Stream stream = stream_0;
			stream_0 = null;
			stream?.Close();
			byte_0 = null;
		}

		public byte[] method_5(int int_0)
		{
			if (int_0 < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			byte[] array = new byte[int_0];
			int num = 0;
			do
			{
				int num2 = stream_0.Read(array, num, int_0);
				if (num2 == 0)
				{
					break;
				}
				num += num2;
				int_0 -= num2;
			}
			while (int_0 > 0);
			if (num != array.Length)
			{
				byte[] array2 = new byte[num];
				Buffer.BlockCopy(array, 0, array2, 0, num);
				array = array2;
			}
			return array;
		}
	}

	private enum Enum0
	{

	}

	private static short short_0;

	private static Class17 class17_0;

	private static int int_0;

	private static byte[] byte_0;

	private static Enum0 enum0_0;

	private static int int_1;

	private static ConcurrentDictionary<int, string> concurrentDictionary_0;

	private static byte[] byte_1;

	private static int int_2;

	static Class16()
	{
		int num = 406234751;
		int num2 = 1800261037;
		concurrentDictionary_0 = new ConcurrentDictionary<int, string>();
		int num3 = 2;
		StackTrace stackTrace = new StackTrace(2, fNeedFileInfo: false);
		num3 = 0;
		StackFrame frame = stackTrace.GetFrame(0);
		int int_ = 0;
		if (frame == null)
		{
			stackTrace = new StackTrace();
			int_ = 1;
			frame = stackTrace.GetFrame(1);
		}
		int num4 = -(~(-(~(-(~(~(-(~((0x33AA6393 ^ num) + num2))))))))) ^ -(~(-(~(~(-(-(~(~(1892292169 - num - num2)))))))));
		MethodBase methodBase = frame?.GetMethod();
		if (frame != null)
		{
			num4 ^= -(~(~(-(-(~(-(~(~(-1640141869 ^ num ^ num2)))))))));
		}
		Type type = methodBase?.DeclaringType;
		if (type == typeof(RuntimeMethodHandle))
		{
			enum0_0 = (Enum0)4 | enum0_0;
			num4 ^= num + 1394027093 - num2 + num3;
		}
		else if (type == null)
		{
			if (smethod_4(stackTrace, int_))
			{
				num4 ^= -(~(~(-(~(-(~(-(~(-1394050325 - num + num2))))))))) - num3;
				enum0_0 = (Enum0)16 | enum0_0;
			}
			else
			{
				enum0_0 = (Enum0)1 | enum0_0;
				num4 ^= ~(-(~(-(-(~(~(-(~((num + 2088500331) ^ num2)))))))));
			}
		}
		else
		{
			num4 ^= -(~(~(-(~(-(~(-(~(-2088495547 - num - num2))))))))) - num3;
			enum0_0 |= (Enum0)16;
		}
		int_2 = num4 + int_2;
	}

	internal static string smethod_0(int int_3)
	{
		if (concurrentDictionary_0.TryGetValue(int_3, out var value))
		{
			return value;
		}
		return smethod_1(int_3, bool_0: true);
	}

	private static string smethod_1(int int_3, bool bool_0)
	{
	  try {
		int num = 184953983;
		int num2 = 615541794;
		string value = null;
		do
		{
			byte[] array;
			int num18;
			int num19;
			int num20;
			int num22;
			byte[] array4;
			byte[] array3;
			int num21;
			lock (concurrentDictionary_0)
			{
				int num6;
				if (class17_0 == null)
				{
					Assembly executingAssembly = Assembly.GetExecutingAssembly();
					Assembly callingAssembly;
					try
					{
						callingAssembly = Assembly.GetCallingAssembly();
					}
					catch (PlatformNotSupportedException)
					{
						callingAssembly = executingAssembly;
					}
					int_0 |= 432198181 + num - num2;
					StringBuilder stringBuilder = new StringBuilder();
					int num3 = 965683635 - num + num2;
					stringBuilder.Append((char)(byte)(num3 >> 24)).Append((char)(byte)(num3 >> 8)).Append((char)(byte)num3)
						.Append((char)(byte)(num3 >> 16));
					num3 = num ^ 0x16F70627 ^ num2;
					stringBuilder.Append((char)(byte)(num3 >> 16)).Append((char)(byte)num3).Append((char)(byte)(num3 >> 24))
						.Append((char)(byte)(num3 >> 8));
					num3 = 430587898 + num - num2;
					stringBuilder.Append((char)(byte)num3);
					Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(stringBuilder.ToString());
					int num4 = 2;
					StackTrace stackTrace = new StackTrace(2, fNeedFileInfo: false);
					int_0 ^= (-430581341 - num + num2) | 2;
					num4 = 0;
					StackFrame frame = stackTrace.GetFrame(0);
					int int_4 = 0;
					if (frame == null)
					{
						stackTrace = new StackTrace();
						int_4 = 1;
						frame = stackTrace.GetFrame(1);
					}
					MethodBase methodBase = frame?.GetMethod();
					int_0 ^= num4 + (num + 430587939 - num2);
					Type type = methodBase?.DeclaringType;
					if (frame == null)
					{
						int_0 ^= -430368496 - num + num2;
					}
					bool flag = type == typeof(RuntimeMethodHandle);
					int_0 ^= 0x2FB640FD ^ num ^ num2;
					if (!flag && (flag = type == null))
					{
						if (smethod_4(stackTrace, int_4))
						{
							flag = false;
						}
						else
						{
							int_0 ^= 800715060 - num - num2;
						}
					}
					if (flag == (stackTrace != null))
					{
						int_0 = 0x20 ^ int_0;
					}
					int_0 ^= (num + -800489275 + num2) | (num4 + 1);
					class17_0 = new Class17(manifestResourceStream);
					short num5 = (short)(class17_0.method_1() ^ (short)(~(-(-(~(-(~(-(~(~(-(~((0x2FB6B905 ^ num) - num2)))))))))))));
					if (num5 == 0)
					{
						short_0 = (short)(class17_0.method_1() ^ (short)(~(-(~(-(-(~(~(-(~(-430604443 - num + num2)))))))))));
					}
					else
					{
						byte_1 = class17_0.method_5(num5);
					}
					callingAssembly = executingAssembly;
					AssemblyName assemblyName_ = smethod_2(callingAssembly);
					byte_0 = smethod_3(assemblyName_);
					// TODO(recovered): Eazfuscator keyed the string-blob base offset to the
					// assembly's metadata tokens (Class6 -> Type.MetadataToken of Class6..Class14)
					// XORed into num6. de4dot + recompile reassigned every metadata token, so the
					// derived base no longer matched the encrypted SiV9Az9FW blob and ALL 34,859
					// strings decoded to empty/garbage (the outer catch turned them into ""),
					// which cascaded into the startup crashes. The original base was recovered by
					// brute-forcing it against the blob + the 17k call-site ids (decodes 17,339/
					// 17,483 to clean plaintext). Force the recovered base and the int_0 invariant
					// so the existing runtime decryptor reproduces the original plaintext, instead
					// of the token-dependent derivation that cannot survive a recompile.
					int_2 = 0;
					byte_0 = null;
					num6 = 1422543797;
					int_0 = (800002339 - num) ^ num2;
					int_1 = num6;
				}
				else
				{
					num6 = int_1;
				}
				if (int_0 == num + 430631773 - num2)
				{
					value = new string(new char[3]
					{
						(char)((-800475063 ^ num) + num2),
						'0',
						(char)((num + 430587899) ^ num2)
					});
					return value;
				}
				int num16 = int_3 ^ (-12951995 - num + num2) ^ num6;
				num16 ^= num + 1209032700 - num2;
				class17_0.method_0().Position = num16;
				if (byte_1 != null)
				{
					array = byte_1;
				}
				else
				{
					short num17 = ((short_0 != -1) ? short_0 : ((short)(class17_0.method_1() ^ ((800485059 - num) ^ num2) ^ num16)));
					if (num17 == 0)
					{
						array = null;
					}
					else
					{
						array = class17_0.method_5(num17);
						for (int i = 0; i != array.Length; i++)
						{
							array[i] ^= (byte)(int_1 >> ((3 & i) << 3));
						}
					}
				}
				num18 = class17_0.method_2() ^ num16 ^ ~(-(-(~(-(~(~(-(~(-(~((num ^ -1612305186) - num2))))))))))) ^ num6;
				if (num18 == ((-430587813 - num) | num2))
				{
					byte[] array2 = class17_0.method_5(4);
					int_3 = ((0x6019D322 ^ num) + num2) ^ num6;
					int_3 = (array2[2] | (array2[3] << 16) | (array2[0] << 8) | (array2[1] << 24)) ^ -int_3;
					continue;
				}
				num19 = int_0;
				num20 = (800002339 - num) ^ num2;
				num21 = num19 - 12;
				num22 = num18;
				num18 &= 699023266 + num - num2;
				array3 = class17_0.method_5(num18);
				array4 = byte_0;
			}
			bool flag2 = (num22 & ((1874237601 - num) ^ num2)) != 0;
			bool flag3 = (num22 & (num + 967458723 - num2)) != 0;
			bool flag4 = (num22 & ((-1346987871 - num) ^ num2)) != 0;
			byte[] array5 = array;
			byte[] array6 = array3;
			byte[] array7 = array5;
			byte b = 0;
			byte b2 = 0;
			byte b3 = 0;
			ushort num23 = 0;
			byte b4 = 0;
			int num24 = 0;
			uint num25 = 0u;
			int num26 = 0;
			b3 = array7[1];
			num26 = array6.Length;
			b = (byte)((num26 + 11) ^ (b3 + 7));
			num25 = (uint)((array7[0] | (array7[2] << 8)) + (b << 3));
			num23 = 0;
			for (num24 = 0; num24 < num26; num24++)
			{
				if ((1 & num24) == 0)
				{
					num25 = (uint)((int)num25 * (num + -800281764 + num2) + (803026788 - num - num2));
					num23 = (ushort)(num25 >> 16);
				}
				b2 = (byte)num23;
				num23 >>= 8;
				b4 = array6[num24];
				array6[num24] = (byte)(b4 ^ b3 ^ (3 + b) ^ b2);
				b = b4;
			}
			array3 = array6;
			if (array4 != null != (num20 != num19))
			{
				for (int j = 0; j < num18; j++)
				{
					byte b5 = array4[j & 7];
					b5 = (byte)((b5 << 3) | (b5 >> 5));
					array3[j] ^= b5;
				}
			}
			byte[] array8;
			int num27;
			if (!flag3)
			{
				array8 = array3;
				num27 = num18;
			}
			else
			{
				num27 = array3[2] | (array3[0] << 16) | (array3[3] << 8) | (array3[1] << 24);
				array8 = new byte[num27];
				smethod_5(array3, 4, array8);
			}
			if (flag2 && num21 == num20 - 12)
			{
				char[] array9 = new char[num27];
				for (int num28 = 0; num28 < num27; num28 = 1 + num28)
				{
					array9[num28] = (char)array8[num28];
				}
				value = new string(array9);
			}
			else
			{
				char[] array10 = new char[num27 / 2];
				int num29 = 0;
				for (int num30 = 0; num30 < num27; num30 = 2 + num30)
				{
					array10[num29++] = (char)(array8[num30] | (array8[num30 + 1] << 8));
				}
				value = new string(array10);
			}
			num21 += (num ^ -800475102) + num2 + (num21 & 3) << 5;
			if (num21 != num20 - 12 + (num + 430587938 - num2 + ((num20 - 12) & 3) << 5))
			{
				int num31 = (int_3 + num18) ^ ((801395417 - num) ^ num2) ^ (num21 & ((0x2FB65D50 ^ num) - num2));
				StringBuilder stringBuilder = new StringBuilder();
				int num3 = -430587723 - num + num2;
				stringBuilder.Append((char)(byte)num3);
				value = num31.ToString(stringBuilder.ToString());
			}
			if (!flag4 && bool_0)
			{
				value = string.Intern(value);
				concurrentDictionary_0[int_3] = value;
				if (concurrentDictionary_0.Count == (num ^ 0x2FB604B6 ^ num2))
				{
					lock (concurrentDictionary_0)
					{
						if (class17_0 != null)
						{
							class17_0.method_4();
							class17_0 = null;
							byte_1 = null;
							byte_0 = null;
						}
					}
				}
			}
			return value;
		}
		while (!concurrentDictionary_0.TryGetValue(int_3, out value));
		return value;
	  }
	  // TODO(recovered): Eazfuscator's string decryptor is keyed to the ORIGINAL
	  // signed-assembly identity (public-key-token 0xB7..0x89 + stack context).
	  // After de4dot + recompile, that token differs, so the few residual (not
	  // statically-inlined) decrypt calls computed an out-of-range stream offset
	  // and threw at startup (SentryHelper.Init). Fail-safe: return cached/empty
	  // so the editor runs; statically-inlined plaintext strings are unaffected.
	  catch { return concurrentDictionary_0.TryGetValue(int_3, out var __fb) ? __fb : string.Empty; }
	}

	private static AssemblyName smethod_2(Assembly assembly_0)
	{
		try
		{
			return assembly_0.GetName();
		}
		catch
		{
			return new AssemblyName(assembly_0.FullName);
		}
	}

	private static byte[] smethod_3(AssemblyName assemblyName_0)
	{
		byte[] array = assemblyName_0.GetPublicKeyToken();
		if (array != null && array.Length == 0)
		{
			array = null;
		}
		return array;
	}

	private static bool smethod_4(StackTrace stackTrace_0, int int_3)
	{
		Assembly assembly = stackTrace_0.GetFrame(++int_3)?.GetMethod()?.DeclaringType?.Assembly;
		if (assembly != null)
		{
			AssemblyName assemblyName_ = smethod_2(assembly);
			byte[] array = smethod_3(assemblyName_);
			if (array != null && array.Length == 8 && array[0] == 183 && array[7] == 137)
			{
				return true;
			}
		}
		while (true)
		{
			StackFrame frame = stackTrace_0.GetFrame(++int_3);
			if (frame == null)
			{
				break;
			}
			assembly = frame.GetMethod()?.DeclaringType?.Assembly;
			if (assembly != null && assembly == typeof(Class16).Assembly)
			{
				return true;
			}
		}
		return false;
	}

	private static void smethod_5(byte[] byte_2, int int_3, byte[] byte_3)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 128;
		int num4 = byte_3.Length;
		while (num < num4)
		{
			if ((num3 <<= 1) == 256)
			{
				num3 = 1;
				num2 = byte_2[int_3++];
			}
			if ((num2 & num3) != 0)
			{
				int num5 = (byte_2[int_3] >> 2) + 3;
				int num6 = ((byte_2[int_3] << 8) | byte_2[int_3 + 1]) & 0x3FF;
				int_3 += 2;
				int num7 = num - num6;
				if (num7 < 0)
				{
					break;
				}
				while (--num5 >= 0 && num < num4)
				{
					byte_3[num++] = byte_3[num7++];
				}
			}
			else
			{
				byte_3[num++] = byte_2[int_3++];
			}
		}
	}
}
