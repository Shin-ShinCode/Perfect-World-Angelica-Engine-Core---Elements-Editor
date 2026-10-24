using System.Drawing;
using System.IO;

namespace ACE.NpcGen;

public class FlyArea
{
	public int iPointNum;

	public PointF[] Points;

	public float fHeight;

	public int iRequireLevel;

	public void Write(BinaryWriter bw)
	{
		bw.Write(iPointNum);
		int num = 0;
		if (0 < iPointNum)
		{
			do
			{
				bw.Write(Points[num].X);
				bw.Write(Points[num].Y);
				num++;
			}
			while (num < iPointNum);
		}
		bw.Write(fHeight);
		bw.Write(iRequireLevel);
	}
}
