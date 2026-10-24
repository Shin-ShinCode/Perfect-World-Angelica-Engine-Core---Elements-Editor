using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace ACE.Classes.ACE;

[Serializable]
public class ELEMENTS_ITEM
{
	public int ID;

	public string Name;

	public Color ItemColor;

	public Image ItemIcon;

	public int RefCount;

	public bool bOcupiedID;

	public bool bHasErrors;

	public string CategoryName;

	public Color CategoryColor;

	public bool bCustomItem;

	public byte[] ToBytes()
	{
		MemoryStream memoryStream = new MemoryStream();
		try
		{
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			try
			{
				binaryWriter.Write(ID);
				binaryWriter.Write(ItemColor.ToArgb());
				binaryWriter.Write(Name.Length);
				binaryWriter.Write(Encoding.Unicode.GetBytes(Name));
				ItemIcon?.Save(memoryStream, ImageFormat.Png);
				return memoryStream.ToArray();
			}
			finally
			{
				((IDisposable)binaryWriter).Dispose();
			}
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}
}
