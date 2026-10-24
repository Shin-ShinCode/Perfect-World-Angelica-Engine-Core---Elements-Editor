using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class Camera
{
	private CameraPos cameraPos_0 = new CameraPos();

	private CameraQuat cameraQuat_0 = new CameraQuat();

	public int CameraRotateAxis;

	public float CameraRotateAngle;

	public float CameraTakeSeconds;

	public CameraPos pos
	{
		[CompilerGenerated]
		get
		{
			return cameraPos_0;
		}
		[CompilerGenerated]
		set
		{
			cameraPos_0 = value;
		}
	}

	public CameraQuat quat
	{
		[CompilerGenerated]
		get
		{
			return cameraQuat_0;
		}
		[CompilerGenerated]
		set
		{
			cameraQuat_0 = value;
		}
	}

	internal static void Read(int version, BinaryReader br, Camera Camera)
	{
		CameraPos.Read(version, br, Camera.pos);
		CameraQuat.Read(version, br, Camera.quat);
		Camera.CameraRotateAxis = br.ReadInt32();
		Camera.CameraRotateAngle = br.ReadSingle();
		Camera.CameraTakeSeconds = br.ReadSingle();
	}

	internal static void Write(int version, BinaryWriter bw, Camera Camera)
	{
		CameraPos.Write(version, bw, Camera.pos);
		CameraQuat.Write(version, bw, Camera.quat);
		bw.Write(Camera.CameraRotateAxis);
		bw.Write(Camera.CameraRotateAngle);
		bw.Write(Camera.CameraTakeSeconds);
	}
}
