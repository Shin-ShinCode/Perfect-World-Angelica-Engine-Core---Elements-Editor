using System.IO;
using ACE.RSGlobal;

namespace ACE.NpcGen;

public class ResArea
{
	public float[] vPos;

	public float fExtX;

	public float fExtZ;

	public int iNumRes;

	public byte bInitGen;

	public byte bAutoRevive;

	public byte bValidOnce;

	public int dwGenID;

	public byte[] dir;

	public byte rad;

	public int idCtrl;

	public int iMaxNum;

	public int dwExportID;

	public int iAttachNum;

	public int iType;

	public float fExtY;

	public float fRadius;

	public ResEntry[] Reses;

	public int[] Attach;

	public void Write(BinaryWriter bw, int version)
	{
		ACE.RSGlobal.RSGlobal.WriteFloat3(bw, vPos);
		bw.Write(fExtX);
		bw.Write(fExtZ);
		bw.Write(Reses.Length);
		bw.Write(bInitGen);
		bw.Write(bAutoRevive);
		bw.Write(bValidOnce);
		bw.Write(dwGenID);
		if (version >= 6)
		{
			bw.Write(dir);
			bw.Write(rad);
		}
		if (version >= 7)
		{
			bw.Write(idCtrl);
			bw.Write(iMaxNum);
		}
		if (version >= 12)
		{
			bw.Write(dwExportID);
			bw.Write(iAttachNum);
		}
		if (version >= 17)
		{
			bw.Write(iType);
			bw.Write(fExtY);
			bw.Write(fRadius);
		}
		ResEntry[] reses = Reses;
		int num = 0;
		if (0 < (nint)reses.LongLength)
		{
			do
			{
				ACE.RSGlobal.RSGlobal.WriteStruct(bw, reses[num]);
				num++;
			}
			while (num < (nint)reses.LongLength);
		}
		if (iAttachNum <= 0)
		{
			return;
		}
		int[] attach = Attach;
		int num2 = 0;
		if (0 < (nint)attach.LongLength)
		{
			do
			{
				bw.Write(attach[num2]);
				num2++;
			}
			while (num2 < (nint)attach.LongLength);
		}
	}
}
