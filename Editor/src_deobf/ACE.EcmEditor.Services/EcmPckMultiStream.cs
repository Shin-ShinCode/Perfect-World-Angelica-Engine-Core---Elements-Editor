using System;
using System.IO;

namespace ACE.EcmEditor.Services;

internal class EcmPckMultiStream : IDisposable
{
	private BufferedStream bufferedStream_0;

	private BufferedStream bufferedStream_1;

	private BufferedStream bufferedStream_2;

	private BufferedStream bufferedStream_3;

	private readonly string string_0;

	private long long_0;

	public bool HasPkxFiles => bufferedStream_1 != null;

	public long Length
	{
		get
		{
			long num = bufferedStream_0?.Length ?? 0L;
			if (bufferedStream_1 != null)
			{
				num += bufferedStream_1.Length;
			}
			if (bufferedStream_2 != null)
			{
				num += bufferedStream_2.Length;
			}
			if (bufferedStream_3 != null)
			{
				num += bufferedStream_3.Length;
			}
			return num;
		}
	}

	public EcmPckMultiStream(string path)
	{
		string_0 = path;
	}

	public void Open()
	{
		Close();
		bufferedStream_0 = method_0(string_0);
		string text = System.IO.Path.ChangeExtension(string_0, Class16.smethod_0(1648989712));
		if (File.Exists(text))
		{
			bufferedStream_1 = method_0(text);
			string text2 = smethod_0(string_0, Class16.smethod_0(1648909411), Class16.smethod_0(1648989723));
			if (File.Exists(text2))
			{
				bufferedStream_2 = method_0(text2);
				string text3 = smethod_0(string_0, Class16.smethod_0(1648909411), Class16.smethod_0(1648989743));
				if (File.Exists(text3))
				{
					bufferedStream_3 = method_0(text3);
				}
			}
		}
		long_0 = 0L;
	}

	private BufferedStream method_0(string string_1)
	{
		return new BufferedStream(new FileStream(string_1, FileMode.Open, FileAccess.Read, FileShare.Read), 16777216);
	}

	public void Seek(long offset, SeekOrigin origin)
	{
		if (bufferedStream_0 != null)
		{
			switch (origin)
			{
			case SeekOrigin.Begin:
				long_0 = offset;
				break;
			case SeekOrigin.Current:
				long_0 += offset;
				break;
			case SeekOrigin.End:
				long_0 = Length + offset;
				break;
			}
			if (long_0 < 0L)
			{
				long_0 = 0L;
			}
			long length = bufferedStream_0.Length;
			long num = bufferedStream_1?.Length ?? 0L;
			long num2 = bufferedStream_2?.Length ?? 0L;
			if (long_0 <= length)
			{
				bufferedStream_0.Seek(long_0, SeekOrigin.Begin);
			}
			else if (bufferedStream_1 != null && long_0 <= length + num)
			{
				bufferedStream_1.Seek(long_0 - length, SeekOrigin.Begin);
			}
			else if (bufferedStream_2 != null && long_0 <= length + num + num2)
			{
				bufferedStream_2.Seek(long_0 - length - num, SeekOrigin.Begin);
			}
			else if (bufferedStream_3 != null)
			{
				bufferedStream_3.Seek(long_0 - length - num - num2, SeekOrigin.Begin);
			}
		}
	}

	public byte[] ReadBytes(int count)
	{
		if (count > 0 && bufferedStream_0 != null)
		{
			byte[] array = new byte[count];
			int num = 0;
			long length = bufferedStream_0.Length;
			long num2 = bufferedStream_1?.Length ?? 0L;
			long num3 = bufferedStream_2?.Length ?? 0L;
			if (long_0 < length)
			{
				num = bufferedStream_0.Read(array, 0, count);
				if (num < count && bufferedStream_1 != null)
				{
					bufferedStream_1.Seek(0L, SeekOrigin.Begin);
					num += bufferedStream_1.Read(array, num, count - num);
				}
				if (num < count && bufferedStream_2 != null)
				{
					bufferedStream_2.Seek(0L, SeekOrigin.Begin);
					num += bufferedStream_2.Read(array, num, count - num);
				}
				if (num < count && bufferedStream_3 != null)
				{
					bufferedStream_3.Seek(0L, SeekOrigin.Begin);
					num += bufferedStream_3.Read(array, num, count - num);
				}
			}
			else if (bufferedStream_1 != null && long_0 < length + num2)
			{
				num = bufferedStream_1.Read(array, 0, count);
				if (num < count && bufferedStream_2 != null)
				{
					bufferedStream_2.Seek(0L, SeekOrigin.Begin);
					num += bufferedStream_2.Read(array, num, count - num);
				}
				if (num < count && bufferedStream_3 != null)
				{
					bufferedStream_3.Seek(0L, SeekOrigin.Begin);
					num += bufferedStream_3.Read(array, num, count - num);
				}
			}
			else if (bufferedStream_2 != null && long_0 < length + num2 + num3)
			{
				num = bufferedStream_2.Read(array, 0, count);
				if (num < count && bufferedStream_3 != null)
				{
					bufferedStream_3.Seek(0L, SeekOrigin.Begin);
					num += bufferedStream_3.Read(array, num, count - num);
				}
			}
			else if (bufferedStream_3 != null)
			{
				num = bufferedStream_3.Read(array, 0, count);
			}
			long_0 += num;
			if (num < count)
			{
				byte[] array2 = new byte[num];
				Array.Copy(array, array2, num);
				return array2;
			}
			return array;
		}
		return Array.Empty<byte>();
	}

	public short ReadInt16()
	{
		return BitConverter.ToInt16(ReadBytes(2), 0);
	}

	public int ReadInt32()
	{
		return BitConverter.ToInt32(ReadBytes(4), 0);
	}

	public uint ReadUInt32()
	{
		return BitConverter.ToUInt32(ReadBytes(4), 0);
	}

	public long ReadInt64()
	{
		return BitConverter.ToInt64(ReadBytes(8), 0);
	}

	public void Close()
	{
		try
		{
			bufferedStream_0?.Close();
		}
		catch
		{
		}
		try
		{
			bufferedStream_1?.Close();
		}
		catch
		{
		}
		try
		{
			bufferedStream_2?.Close();
		}
		catch
		{
		}
		try
		{
			bufferedStream_3?.Close();
		}
		catch
		{
		}
		bufferedStream_0 = null;
		bufferedStream_1 = null;
		bufferedStream_2 = null;
		bufferedStream_3 = null;
	}

	public void Dispose()
	{
		Close();
	}

	private static string smethod_0(string string_1, string string_2, string string_3)
	{
		int num = string_1.IndexOf(string_2, StringComparison.OrdinalIgnoreCase);
		if (num < 0)
		{
			return string_1;
		}
		return string_1.Substring(0, num) + string_3 + string_1.Substring(num + string_2.Length);
	}
}
