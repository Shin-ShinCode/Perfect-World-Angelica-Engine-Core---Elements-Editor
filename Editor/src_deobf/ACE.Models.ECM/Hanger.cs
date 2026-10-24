using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ACE.Models.ECM;

public class Hanger
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

	public static Hanger Read(BinaryReader reader)
	{
		Hanger hanger = new Hanger();
		int num = reader.ReadInt32();
		if (num > 0 && num < 256)
		{
			byte[] bytes = reader.ReadBytes(num);
			hanger.Name = Encoding.GetEncoding(936).GetString(bytes).TrimEnd(default(char));
		}
		hanger.BoneIndex = reader.ReadInt32();
		hanger.Position = Vector3f.Read(reader);
		hanger.Direction = Vector3f.Read(reader);
		hanger.Up = Vector3f.Read(reader);
		return hanger;
	}
}
