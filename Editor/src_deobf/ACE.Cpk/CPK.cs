using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ACE.Classes;
using ACE.RSGlobal;

namespace ACE.Cpk;

public class CPK
{
	public class CPK_STRUCT
	{
		public int Sign;

		public int Version;

		public int TableOffset;

		public int unk1;

		public int unk2;

		public PROTECTION_VERSION_CPK prot_ver;

		public int unk4;

		public int unk5;

		public int TablesCapacity;

		public int unk6;

		public int FileSize;

		public byte[] unk_80;

		public List<byte[]> Data;

		public byte[] FileTables;
	}

	public static CommonStorage CStorage;

	public static int STATIC_KEY = -137127505;

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool ProtectCPK(string fn, [MarshalAs(UnmanagedType.U1)] bool bAddTrash, int ProtectionKey, string UserName)
	{
		bool result = false;
		CPK_STRUCT cPK_STRUCT = new CPK_STRUCT();
		FileStream fileStream = null;
		BinaryReader binaryReader = null;
		BinaryWriter binaryWriter = null;
		try
		{
			fileStream = File.OpenRead(fn);
			binaryReader = new BinaryReader(fileStream);
			int num = (cPK_STRUCT.Sign = binaryReader.ReadInt32());
			if (num != 441733970)
			{
				throw new ApplicationException(string.Format(TextStorage.Msg(Class16.smethod_0(1648893464), Class16.smethod_0(1648893501)), num));
			}
			cPK_STRUCT.Version = binaryReader.ReadInt32();
			cPK_STRUCT.TableOffset = binaryReader.ReadInt32();
			cPK_STRUCT.unk1 = binaryReader.ReadInt32();
			cPK_STRUCT.unk2 = binaryReader.ReadInt32();
			if ((cPK_STRUCT.prot_ver = (PROTECTION_VERSION_CPK)binaryReader.ReadUInt32()) == (PROTECTION_VERSION_CPK)2147483649u)
			{
				throw new ApplicationException(TextStorage.TEXTS.GetText(Class16.smethod_0(1648893534)));
			}
			cPK_STRUCT.unk4 = binaryReader.ReadInt32();
			cPK_STRUCT.unk5 = binaryReader.ReadInt32();
			cPK_STRUCT.TablesCapacity = binaryReader.ReadInt32();
			cPK_STRUCT.unk6 = binaryReader.ReadInt32();
			cPK_STRUCT.FileSize = binaryReader.ReadInt32();
			cPK_STRUCT.unk_80 = binaryReader.ReadBytes(80);
			long offset = cPK_STRUCT.TableOffset;
			binaryReader.BaseStream.Seek(offset, SeekOrigin.Begin);
			cPK_STRUCT.FileTables = binaryReader.ReadBytes(cPK_STRUCT.TablesCapacity * 28);
			binaryReader.Close();
			binaryReader = null;
			fileStream.Close();
			fileStream = File.OpenWrite(fn);
			binaryWriter = new BinaryWriter(fileStream);
			long offset2 = cPK_STRUCT.TableOffset;
			binaryWriter.BaseStream.Seek(offset2, SeekOrigin.Begin);
			if (bAddTrash)
			{
				int num2 = 0;
				num2 = ((cPK_STRUCT.prot_ver != PROTECTION_VERSION_CPK.None || binaryWriter.BaseStream.Length <= 104857600L) ? RND.GenerateRnd(1024, 102400) : RND.GenerateRnd(52428800, 104857600));
				byte[] array = new byte[num2];
				for (int i = 0; i < num2; i++)
				{
					byte b = (byte)RND.GenerateRnd(0, 255);
					array[i] = b;
				}
				binaryWriter.Write(array);
			}
			int num3 = (int)binaryWriter.BaseStream.Position;
			binaryWriter.Write(cPK_STRUCT.FileTables);
			byte[] array2 = RSCrypt.STATIC2().EncryptString(UserName, bBase64: true);
			binaryWriter.Write(array2.Length);
			binaryWriter.Write(array2);
			string s = Class16.smethod_0(1648893557);
			byte[] bytes = Encoding.ASCII.GetBytes(s);
			binaryWriter.Write(new byte[1024]);
			binaryWriter.Write(bytes);
			binaryWriter.Write(new byte[16]);
			binaryWriter.Write(GenerateVerifyBytes(ProtectionKey));
			binaryWriter.Write(cPK_STRUCT.TableOffset ^ ProtectionKey);
			int value = num3 ^ ProtectionKey;
			binaryWriter.Write(value);
			int value2 = (int)binaryWriter.BaseStream.Position;
			binaryWriter.BaseStream.Seek(8L, SeekOrigin.Begin);
			binaryWriter.Write(value);
			binaryWriter.BaseStream.Seek(20L, SeekOrigin.Begin);
			binaryWriter.Write(2147483649u);
			binaryWriter.BaseStream.Seek(40L, SeekOrigin.Begin);
			binaryWriter.Write(value2);
			binaryWriter.Close();
			fileStream.Close();
			result = true;
		}
		catch (Exception ex)
		{
			string key = Class16.smethod_0(1648893578);
			ex.Data.Add(key, fn);
			if (fileStream != null)
			{
				IntPtr intPtr = fileStream.SafeFileHandle.DangerousGetHandle();
				if (intPtr != IntPtr.Zero)
				{
					string key2 = Class16.smethod_0(1648893587);
					ex.Data.Add(key2, fileStream.Position);
				}
			}
			string key3 = Class16.smethod_0(1648893602);
			ex.Data.Add(key3, true);
			if (!(ex.GetType() == typeof(ApplicationException)))
			{
				throw;
			}
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648893621));
			object[] vars = new object[1] { ex.Message };
			TextStorage.TEXTS.ShowMessage(5, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
		}
		finally
		{
			binaryReader?.Close();
			binaryWriter?.Close();
			fileStream?.Close();
		}
		return result;
	}

	public static byte[] GenerateVerifyBytes(int ProtectionKey)
	{
		int num = STATIC_KEY ^ ProtectionKey;
		string text = Class16.smethod_0(1648893634);
		return RSMD5.GetBytes(Encoding.ASCII.GetBytes(text + num));
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool UnprotectCPK(string fn, int ProtectionKey, [MarshalAs(UnmanagedType.U1)] bool bIngnoreProtectionKeyChecking)
	{
		bool result = false;
		CPK_STRUCT cPK_STRUCT = new CPK_STRUCT();
		FileStream fileStream = null;
		BinaryReader binaryReader = null;
		BinaryWriter binaryWriter = null;
		try
		{
			fileStream = File.OpenRead(fn);
			binaryReader = new BinaryReader(fileStream);
			int num = (cPK_STRUCT.Sign = binaryReader.ReadInt32());
			if (num != 441733970)
			{
				throw new ApplicationException(string.Format(TextStorage.Msg(Class16.smethod_0(1648893464), Class16.smethod_0(1648893501)), num));
			}
			cPK_STRUCT.Version = binaryReader.ReadInt32();
			cPK_STRUCT.TableOffset = binaryReader.ReadInt32();
			cPK_STRUCT.unk1 = binaryReader.ReadInt32();
			cPK_STRUCT.unk2 = binaryReader.ReadInt32();
			cPK_STRUCT.prot_ver = (PROTECTION_VERSION_CPK)binaryReader.ReadUInt32();
			cPK_STRUCT.unk4 = binaryReader.ReadInt32();
			cPK_STRUCT.unk5 = binaryReader.ReadInt32();
			cPK_STRUCT.TablesCapacity = binaryReader.ReadInt32();
			cPK_STRUCT.unk6 = binaryReader.ReadInt32();
			cPK_STRUCT.FileSize = binaryReader.ReadInt32();
			cPK_STRUCT.unk_80 = binaryReader.ReadBytes(80);
			if (cPK_STRUCT.prot_ver != (PROTECTION_VERSION_CPK)2147483649u)
			{
				throw new ApplicationException(TextStorage.TEXTS.GetText(Class16.smethod_0(1648893650)));
			}
			binaryReader.BaseStream.Seek(-24L, SeekOrigin.End);
			bool flag = ACE.RSGlobal.RSGlobal.IsArraysEquals(binaryReader.ReadBytes(16), GenerateVerifyBytes(ProtectionKey));
			int num2 = ((bIngnoreProtectionKeyChecking || flag) ? 1 : 0);
			bool flag2 = (byte)num2 != 0;
			if ((cPK_STRUCT.TableOffset ^= ProtectionKey) <= 124)
			{
				goto IL_01c5;
			}
			int num3 = (int)fileStream.Length;
			int tableOffset = cPK_STRUCT.TableOffset;
			if (tableOffset >= num3 || !flag2)
			{
				goto IL_01c5;
			}
			int num4 = tableOffset;
			if (flag)
			{
				int num5 = binaryReader.ReadInt32();
				num5 ^= ProtectionKey;
				uint num6 = binaryReader.ReadUInt32() ^ (uint)ProtectionKey;
				tableOffset = cPK_STRUCT.TableOffset;
				num5 = ((tableOffset != (int)num6) ? tableOffset : num5);
			}
			binaryReader.BaseStream.Seek(tableOffset, SeekOrigin.Begin);
			cPK_STRUCT.FileTables = binaryReader.ReadBytes(cPK_STRUCT.TablesCapacity * 28);
			binaryReader.Close();
			binaryReader = null;
			fileStream.Close();
			fileStream = File.OpenWrite(fn);
			binaryWriter = new BinaryWriter(fileStream);
			binaryWriter.BaseStream.Seek(num4, SeekOrigin.Begin);
			binaryWriter.Write(cPK_STRUCT.FileTables);
			int num7 = (int)binaryWriter.BaseStream.Position;
			binaryWriter.BaseStream.Seek(8L, SeekOrigin.Begin);
			binaryWriter.Write(num4);
			binaryWriter.BaseStream.Seek(40L, SeekOrigin.Begin);
			binaryWriter.Write(num7);
			binaryWriter.BaseStream.Seek(20L, SeekOrigin.Begin);
			binaryWriter.Write(1u);
			binaryWriter.BaseStream.SetLength(num7);
			binaryWriter.Close();
			fileStream.Close();
			result = true;
			goto end_IL_000f;
			IL_01c5:
			throw new ApplicationException(TextStorage.TEXTS.GetText(Class16.smethod_0(1648893673)));
			end_IL_000f:;
		}
		catch (Exception ex)
		{
			string key = Class16.smethod_0(1648893578);
			ex.Data.Add(key, fn);
			if (fileStream != null)
			{
				IntPtr intPtr = fileStream.SafeFileHandle.DangerousGetHandle();
				if (intPtr != IntPtr.Zero)
				{
					string key2 = Class16.smethod_0(1648893587);
					ex.Data.Add(key2, fileStream.Position);
				}
			}
			string key3 = Class16.smethod_0(1648893602);
			ex.Data.Add(key3, true);
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648893696));
			if (!(ex.GetType() == typeof(ApplicationException)))
			{
				throw;
			}
			object[] vars = new object[1] { ex.Message };
			TextStorage.TEXTS.ShowMessage(5, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
		}
		finally
		{
			binaryReader?.Close();
			binaryWriter?.Close();
			fileStream?.Close();
		}
		return result;
	}
}
