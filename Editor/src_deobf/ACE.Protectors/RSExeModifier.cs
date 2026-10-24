using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ACE.Classes;
using ACE.RSGlobal;
using Sentry;

namespace ACE.Protectors;

public class RSExeModifier
{
	public static CommonStorage CStorage;

	public string FileName;

	public bool FileLoaded;

	public string AllText;

	public byte[] AllBytes;

	public FileStream fs;

	public BinaryWriter bw;

	public RSExeModifier(string FileName)
	{
		this.FileName = FileName;
		FileLoaded = Open();
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool Open()
	{
		return method_0(0);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	private bool method_0(int int_0)
	{
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		Close();
		try
		{
			if (!File.Exists(FileName))
			{
				string message = Class16.smethod_0(1649170891) + FileName;
				SentryHelper.AddBreadcrumb(message, Class16.smethod_0(1649170941), (BreadcrumbLevel)1);
				return false;
			}
			fs = new FileStream(FileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
			if (fs.Length > 2147483647L)
			{
				throw new IOException(Class16.smethod_0(1649165846) + FileName);
			}
			AllBytes = new byte[(int)fs.Length];
			int i;
			int num;
			for (i = 0; i < AllBytes.Length; i += num)
			{
				num = fs.Read(AllBytes, i, AllBytes.Length - i);
				if (num <= 0)
				{
					break;
				}
			}
			if (i != AllBytes.Length)
			{
				throw new EndOfStreamException(string.Format(Class16.smethod_0(1649165875), AllBytes.Length, i));
			}
			bw = new BinaryWriter(fs);
			fs.Position = 0L;
			return true;
		}
		catch (IOException ioexception_) when (smethod_0(ioexception_) && int_0 + 1 < 3)
		{
			Thread.Sleep(300);
			return method_0(int_0 + 1);
		}
		catch (IOException ex)
		{
			Close();
			string message2 = Class16.smethod_0(1649165966) + ex.Message + Class16.smethod_0(1649198770) + FileName;
			BreadcrumbLevel level = (BreadcrumbLevel)(!smethod_0(ex) ? 1 : 0);
			SentryHelper.AddBreadcrumb(message2, Class16.smethod_0(1649170941), level);
			object[] vars = new object[2] { ex.Message, FileName };
			if (TextStorage.TEXTS.ShowMessage(631, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, vars) == DialogResult.Retry)
			{
				Thread.Sleep(300);
				return method_0(0);
			}
			return false;
		}
		catch (Exception ex2)
		{
			Close();
			SentryHelper.CaptureException(ex2, Class16.smethod_0(1649170941));
			object[] vars2 = new object[2] { ex2.Message, FileName };
			if (TextStorage.TEXTS.ShowMessage(631, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, vars2) == DialogResult.Retry)
			{
				return method_0(0);
			}
			return false;
		}
	}

	public void Close()
	{
		bw?.Close();
		fs?.Close();
		bw = null;
		fs = null;
		AllText = null;
		AllBytes = null;
	}

	private static bool smethod_0(IOException ioexception_0)
	{
		int num = ioexception_0.HResult & 0xFFFF;
		if (num != 32)
		{
			return num == 33;
		}
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SeekToMarker(byte[] marker, int position, [MarshalAs(UnmanagedType.U1)] bool IsMask, byte MaskChar)
	{
		int num = BinarySearch(AllBytes, marker, position, IsMask, MaskChar);
		if (num > -1)
		{
			fs.Seek((nint)marker.LongLength + num, SeekOrigin.Begin);
			GC.KeepAlive(this);
			return true;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SeekToMarker(byte[] marker, int position, [MarshalAs(UnmanagedType.U1)] bool IsMask)
	{
		return SeekToMarker(marker, position, IsMask, 173);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SeekToMarker(byte[] marker, [MarshalAs(UnmanagedType.U1)] bool IsMask)
	{
		return SeekToMarker(marker, 0, IsMask, 173);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SeekToMarker(byte[] marker, int position)
	{
		return SeekToMarker(marker, position, IsMask: false, 0);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SeekToMarker(byte[] marker)
	{
		return SeekToMarker(marker, 0, IsMask: false, 0);
	}

	public int BinarySearch(byte[] arr, byte[] needle, int start_index, [MarshalAs(UnmanagedType.U1)] bool IsMask, byte MaskChar)
	{
		int num = arr.Length;
		int num2 = num;
		int num3 = needle.Length;
		int num4 = start_index;
		int num5 = num;
		if (start_index < num5)
		{
			byte b = needle[0];
			do
			{
				if (arr[num4] == b || (IsMask && b == MaskChar))
				{
					int num6 = 1;
					if (1 < num3)
					{
						while (num4 + num6 < num2)
						{
							byte b2 = needle[num6];
							if (arr[num4 + num6] != b2 && (!IsMask || b2 != MaskChar))
							{
								break;
							}
							num6++;
							if (num6 >= num3)
							{
								break;
							}
						}
					}
					if (num6 == num3)
					{
						return num4;
					}
				}
				num4++;
			}
			while (num4 < num5);
		}
		return -1;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool Write(byte[] marker, int value)
	{
		if (SeekToMarker(marker, 0, IsMask: false, 0))
		{
			bw.Write(value);
			GC.KeepAlive(this);
			return true;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool ReplaceASCII(string oldValue, string newValue)
	{
		bool flag = false;
		bool result = false;
		while (true)
		{
			byte[] bytes = Encoding.ASCII.GetBytes(oldValue);
			byte[] buffer = ((newValue.Length >= oldValue.Length) ? Encoding.ASCII.GetBytes(newValue) : ACE.RSGlobal.RSGlobal.ToBytesA(newValue, oldValue.Length));
			fs.Position = 0L;
			int position = (int)fs.Position;
			if (!SeekToMarker(bytes, position, IsMask: false, 0))
			{
				if (flag)
				{
					break;
				}
				flag = true;
				oldValue = ACE.RSGlobal.RSGlobal.WithCapitalLetter(oldValue);
				continue;
			}
			result = true;
			int position3;
			do
			{
				long num = bytes.LongLength;
				long position2 = fs.Position - num;
				fs.Position = position2;
				bw.Write(buffer);
				position3 = (int)fs.Position;
			}
			while (SeekToMarker(bytes, position3, IsMask: false, 0));
			break;
		}
		GC.KeepAlive(this);
		return result;
	}

	public byte[] ReadBytes(int count)
	{
		if (AllBytes == null)
		{
			throw new InvalidOperationException(Class16.smethod_0(1649165994));
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException(Class16.smethod_0(1649166033));
		}
		byte[] array = new byte[count];
		int num = (int)fs.Position;
		if (num < 0 || num > AllBytes.Length || num + count > AllBytes.Length)
		{
			throw new EndOfStreamException(string.Format(Class16.smethod_0(1649166052), count, num, AllBytes.Length));
		}
		Array.Copy(AllBytes, num, array, 0, count);
		GC.KeepAlive(this);
		return array;
	}
}
