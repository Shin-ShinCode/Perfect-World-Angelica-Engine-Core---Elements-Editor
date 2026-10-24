using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ACE.Models.ECM;

public class SkeletonHook
{
	private string string_0;

	private int int_0;

	private Vector3f vector3f_0;

	private Vector3f vector3f_1;

	private Vector3f vector3f_2;

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public int BoneIndex
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

	public Vector3f Position
	{
		[CompilerGenerated]
		get
		{
			return vector3f_0;
		}
		[CompilerGenerated]
		set
		{
			vector3f_0 = value;
		}
	}

	public Vector3f Direction
	{
		[CompilerGenerated]
		get
		{
			return vector3f_1;
		}
		[CompilerGenerated]
		set
		{
			vector3f_1 = value;
		}
	}

	public Vector3f Up
	{
		[CompilerGenerated]
		get
		{
			return vector3f_2;
		}
		[CompilerGenerated]
		set
		{
			vector3f_2 = value;
		}
	}

	public static SkeletonHook Read(BinaryReader reader)
	{
		SkeletonHook skeletonHook = new SkeletonHook();
		long num = reader.BaseStream.Length - reader.BaseStream.Position;
		if (num < 4L)
		{
			throw new EndOfStreamException(Class16.smethod_0(1649123305));
		}
		int num2 = reader.ReadInt32();
		if (num2 > 0 && num2 < 256)
		{
			if (reader.BaseStream.Length - reader.BaseStream.Position < num2)
			{
				throw new EndOfStreamException(string.Format(Class16.smethod_0(1649122333), num2));
			}
			byte[] bytes = reader.ReadBytes(num2);
			skeletonHook.Name = Encoding.GetEncoding(936).GetString(bytes);
		}
		if (reader.BaseStream.Length - reader.BaseStream.Position < 40L)
		{
			throw new EndOfStreamException(Class16.smethod_0(1649122387));
		}
		skeletonHook.BoneIndex = reader.ReadInt32();
		skeletonHook.Position = Vector3f.Read(reader);
		skeletonHook.Direction = Vector3f.Read(reader);
		skeletonHook.Up = Vector3f.Read(reader);
		return skeletonHook;
	}
}
