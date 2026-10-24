using System;
using System.IO;

namespace ACE.Pck.Package;

public class Package : IDisposable
{
	protected BufferedStream pck;

	protected BufferedStream pkx;

	protected BufferedStream pkx1;

	private string string_0 = string.Empty;

	public long Position;

	public Keys key = new Keys();

	public Package(string path, Keys key = null)
	{
		string_0 = path;
		if (key != null)
		{
			this.key = key;
		}
		pck = new BufferedStream(new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite), 33554432);
		if (File.Exists(path.Replace(Class16.smethod_0(1648909411), Class16.smethod_0(1648989712))) && System.IO.Path.GetExtension(path) != Class16.smethod_0(1649188968))
		{
			pkx = new BufferedStream(new FileStream(path.Replace(Class16.smethod_0(1648909411), Class16.smethod_0(1648989712)), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite), 33554432);
			if (File.Exists(path.Replace(Class16.smethod_0(1648909411), Class16.smethod_0(1648989723))) && System.IO.Path.GetExtension(path) != Class16.smethod_0(1649188968))
			{
				pkx1 = new BufferedStream(new FileStream(path.Replace(Class16.smethod_0(1648909411), Class16.smethod_0(1648989723)), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite), 33554432);
			}
		}
	}

	public void Seek(long offset, SeekOrigin origin)
	{
		switch (origin)
		{
		case SeekOrigin.Begin:
			Position = offset;
			break;
		case SeekOrigin.Current:
			Position += offset;
			break;
		case SeekOrigin.End:
			Position = GetLenght() + offset;
			break;
		}
		if (Position < pck.Length)
		{
			pck.Seek(Position, SeekOrigin.Begin);
		}
		else if (Position < pck.Length + pkx.Length)
		{
			pkx.Seek(Position - pck.Length, SeekOrigin.Begin);
		}
		else
		{
			pkx1.Seek(Position - (pck.Length + pkx.Length), SeekOrigin.Begin);
		}
	}

	public long GetLenght()
	{
		if (pkx1 != null)
		{
			return pck.Length + pkx.Length + pkx1.Length;
		}
		if (pkx != null)
		{
			return pck.Length + pkx.Length;
		}
		return pck.Length;
	}

	public static int GetFilesCount(Package package)
	{
		package.Seek(-8L, SeekOrigin.End);
		return package.ReadInt32();
	}

	public byte[] ReadBytes(int count)
	{
		byte[] array = new byte[count];
		int num = 0;
		if (Position < pck.Length)
		{
			num = pck.Read(array, 0, count);
			if (num < count && pkx != null)
			{
				pkx.Seek(0L, SeekOrigin.Begin);
				num += pkx.Read(array, num, count - num);
				if (num < count && pkx1 != null)
				{
					pkx1.Seek(0L, SeekOrigin.Begin);
					num += pkx1.Read(array, num, count - num);
				}
			}
		}
		else if (Position > pck.Length && pkx != null)
		{
			if (Position > pck.Length + pkx.Length && pkx1 != null)
			{
				num = pkx1.Read(array, 0, count);
			}
			else
			{
				num = pkx.Read(array, 0, count);
			}
		}
		Position += count;
		return array;
	}

	public void WriteBytes(byte[] array)
	{
		if (Position + array.Length < 2147483392L)
		{
			pck.Write(array, 0, array.Length);
		}
		else if (Position + array.Length > 4294966784L)
		{
			if (pkx1 == null)
			{
				pkx1 = new BufferedStream(new FileStream(string_0.Replace(Class16.smethod_0(1648909411), Class16.smethod_0(1648989723)), FileMode.Create, FileAccess.ReadWrite), 33554432);
			}
			if (Position > 4294966784L)
			{
				pkx1.Write(array, 0, array.Length);
			}
			else
			{
				if (pkx1 == null)
				{
					pkx1 = new BufferedStream(new FileStream(string_0.Replace(Class16.smethod_0(1648909411), Class16.smethod_0(1648989723)), FileMode.Create, FileAccess.ReadWrite), 33554432);
				}
				pkx.Write(array, 0, (int)(4294966784L - Position));
				pkx1.Write(array, (int)(4294966784L - Position), array.Length - (int)(4294966784L - Position));
			}
		}
		else if (Position + array.Length > 2147483392L)
		{
			if (pkx == null)
			{
				pkx = new BufferedStream(new FileStream(string_0.Replace(Class16.smethod_0(1648909411), Class16.smethod_0(1648989712)), FileMode.Create, FileAccess.ReadWrite), 33554432);
			}
			if (Position > 2147483392L)
			{
				pkx.Write(array, 0, array.Length);
			}
			else
			{
				if (pkx == null)
				{
					pkx = new BufferedStream(new FileStream(string_0.Replace(Class16.smethod_0(1648909411), Class16.smethod_0(1648989712)), FileMode.Create, FileAccess.ReadWrite), 33554432);
				}
				pck.Write(array, 0, (int)(2147483392L - Position));
				pkx.Write(array, (int)(2147483392L - Position), array.Length - (int)(2147483392L - Position));
			}
		}
		Position += array.Length;
	}

	public uint ReadUInt32()
	{
		return BitConverter.ToUInt32(ReadBytes(4), 0);
	}

	public int ReadInt32()
	{
		return BitConverter.ToInt32(ReadBytes(4), 0);
	}

	public long ReadInt64()
	{
		return BitConverter.ToInt64(ReadBytes(8), 0);
	}

	public void WriteInt16(short value)
	{
		WriteBytes(BitConverter.GetBytes(value));
	}

	public void WriteInt32(int value)
	{
		WriteBytes(BitConverter.GetBytes(value));
	}

	public void WriteUInt32(uint value)
	{
		WriteBytes(BitConverter.GetBytes(value));
	}

	public void WriteInt64(long value)
	{
		WriteBytes(BitConverter.GetBytes(value));
	}

	public void Dispose()
	{
		pck?.Close();
		pkx?.Close();
		pkx1?.Close();
	}
}
