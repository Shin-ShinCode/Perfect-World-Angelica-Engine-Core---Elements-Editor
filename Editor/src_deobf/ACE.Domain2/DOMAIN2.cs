using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using ACE.Classes;
using ACE.RSGlobal;
using ACE.Settings;

namespace ACE.Domain2;

public class DOMAIN2
{
	public class BattletimeServer
	{
		public int int_0;

		public int int_1;

		public int int_2;

		public BattletimeServer Clone()
		{
			return (BattletimeServer)MemberwiseClone();
		}
	}

	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class DOMAIN_POINT
	{
		private int _x;

		private int _y;

		public int Int32_0
		{
			get
			{
				return _y;
			}
			set
			{
				_y = value;
			}
		}

		public int Int32_1
		{
			get
			{
				return _x;
			}
			set
			{
				_x = value;
			}
		}

		public DOMAIN_POINT(BinaryReader br)
		{
			_x = br.ReadInt32();
			_y = br.ReadInt32();
		}

		public DOMAIN_POINT()
		{
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(_x);
			bw.Write(_y);
		}

		public DOMAIN_POINT Clone()
		{
			return (DOMAIN_POINT)MemberwiseClone();
		}

		public override string ToString()
		{
			int y = _y;
			int x = _x;
			string result = string.Format(Class16.smethod_0(1649009229), x, y);
			GC.KeepAlive(this);
			return result;
		}
	}

	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class DOMAIN_TRIANGLE
	{
		private int _id1;

		private int _id2;

		private int _id3;

		public int id3
		{
			get
			{
				return _id3;
			}
			set
			{
				_id3 = value;
			}
		}

		public int id2
		{
			get
			{
				return _id2;
			}
			set
			{
				_id2 = value;
			}
		}

		public int id1
		{
			get
			{
				return _id1;
			}
			set
			{
				_id1 = value;
			}
		}

		public DOMAIN_TRIANGLE(BinaryReader br)
		{
			_id1 = br.ReadInt32();
			_id2 = br.ReadInt32();
			_id3 = br.ReadInt32();
		}

		public DOMAIN_TRIANGLE()
		{
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(_id1);
			bw.Write(_id2);
			bw.Write(_id3);
		}

		public DOMAIN_TRIANGLE Clone()
		{
			return (DOMAIN_TRIANGLE)MemberwiseClone();
		}

		public override string ToString()
		{
			int num = _id3;
			int num2 = _id2;
			int num3 = _id1;
			string result = string.Format(Class16.smethod_0(1649009241), num3, num2, num);
			GC.KeepAlive(this);
			return result;
		}
	}

	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class DomainInfo
	{
		public byte[] name;

		private int _ID;

		private int _Point;

		private int _WarType;

		private int _CountryId;

		private int _IsCapital;

		private ObservableCollection<XYZ> _Coords;

		private int _BaseLogoX;

		private int _BaseLogoY;

		private ObservableCollection<DOMAIN_POINT> _Points;

		private ObservableCollection<DOMAIN_TRIANGLE> _Triangles;

		private ObservableCollection<int> _Neighbors;

		[Browsable(false)]
		public string Name
		{
			get
			{
				string result = ACE.RSGlobal.RSGlobal.Bytes2StringW(name);
				GC.KeepAlive(this);
				return result;
			}
			set
			{
				name = ACE.RSGlobal.RSGlobal.ToBytesW(value, 16);
				GC.KeepAlive(this);
			}
		}

		[LDisplayName("domain2Neighbors")]
		[LCategory("domain2CatNeighbors", 1)]
		public ObservableCollection<int> Neighbors
		{
			get
			{
				return _Neighbors;
			}
			set
			{
				_Neighbors = value;
			}
		}

		[LDisplayName("domain2Triangles")]
		public ObservableCollection<DOMAIN_TRIANGLE> Triangles
		{
			get
			{
				return _Triangles;
			}
			set
			{
				_Triangles = value;
			}
		}

		[LDisplayName("domain2Points")]
		public ObservableCollection<DOMAIN_POINT> Points
		{
			get
			{
				return _Points;
			}
			set
			{
				_Points = value;
			}
		}

		[LDisplayName("domain2BaseLogoY")]
		public int BaseLogoY
		{
			get
			{
				return _BaseLogoY;
			}
			set
			{
				_BaseLogoY = value;
			}
		}

		[LDisplayName("domain2BaseLogoX")]
		public int BaseLogoX
		{
			get
			{
				return _BaseLogoX;
			}
			set
			{
				_BaseLogoX = value;
			}
		}

		[Browsable(false)]
		public ObservableCollection<XYZ> Coords
		{
			get
			{
				return _Coords;
			}
			set
			{
				_Coords = value;
			}
		}

		[Browsable(false)]
		public int IsCapital
		{
			get
			{
				return _IsCapital;
			}
			set
			{
				_IsCapital = value;
			}
		}

		[Browsable(false)]
		public int CountryId
		{
			get
			{
				return _CountryId;
			}
			set
			{
				_CountryId = value;
			}
		}

		[Browsable(false)]
		public int WarType
		{
			get
			{
				return _WarType;
			}
			set
			{
				_WarType = value;
			}
		}

		[Browsable(false)]
		public int Point
		{
			get
			{
				return _Point;
			}
			set
			{
				_Point = value;
			}
		}

		[Browsable(false)]
		public int ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}

		public DomainInfo Clone()
		{
			DomainInfo domainInfo = (DomainInfo)MemberwiseClone();
			domainInfo.name = ACE.RSGlobal.RSGlobal.CloneArray(name);
			domainInfo._Coords = new ObservableCollection<XYZ>();
			int num = 0;
			do
			{
				ObservableCollection<XYZ> coords = _Coords;
				domainInfo._Coords.Add(coords[num].Clone());
				num++;
			}
			while (num < 4);
			domainInfo._Points = new ObservableCollection<DOMAIN_POINT>();
			int num2 = 0;
			ObservableCollection<DOMAIN_POINT> points = _Points;
			if (0 < points.Count)
			{
				ObservableCollection<DOMAIN_POINT> points3;
				do
				{
					ObservableCollection<DOMAIN_POINT> points2 = _Points;
					domainInfo._Points.Add(points2[num2].Clone());
					num2++;
					points3 = _Points;
				}
				while (num2 < points3.Count);
			}
			domainInfo._Triangles = new ObservableCollection<DOMAIN_TRIANGLE>();
			int num3 = 0;
			ObservableCollection<DOMAIN_TRIANGLE> triangles = _Triangles;
			if (0 < triangles.Count)
			{
				ObservableCollection<DOMAIN_TRIANGLE> triangles3;
				do
				{
					ObservableCollection<DOMAIN_TRIANGLE> triangles2 = _Triangles;
					domainInfo._Triangles.Add(triangles2[num3].Clone());
					num3++;
					triangles3 = _Triangles;
				}
				while (num3 < triangles3.Count);
			}
			ObservableCollection<int> neighbors = _Neighbors;
			domainInfo._Neighbors = new ObservableCollection<int>(neighbors);
			GC.KeepAlive(this);
			return domainInfo;
		}
	}

	public enum PW_DOMAIN2_VERSION
	{
		AUTO,
		PW_1_4_7,
		PW_1_5_1
	}

	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class XYZ
	{
		private float _x;

		private float _y;

		private float _z;

		public float Single_0
		{
			get
			{
				return _z;
			}
			set
			{
				_z = value;
			}
		}

		public float Single_1
		{
			get
			{
				return _y;
			}
			set
			{
				_y = value;
			}
		}

		public float Single_2
		{
			get
			{
				return _x;
			}
			set
			{
				_x = value;
			}
		}

		public XYZ(BinaryReader br)
		{
			float x = br.ReadSingle();
			_x = x;
			float y = br.ReadSingle();
			_y = y;
			float z = br.ReadSingle();
			_z = z;
		}

		public XYZ()
		{
		}

		public XYZ Clone()
		{
			return (XYZ)MemberwiseClone();
		}
	}

	public string fn;

	public bool FileLoaded;

	public bool bMagicExists;

	public byte[] Magic;

	public int TimeStamp;

	public float fUnknown;

	public DomainInfo[] Domains;

	public int TimeNum;

	public BattletimeServer[] Times;

	public int BattletimeMax;

	public byte[] BytesAfterEndOfFile;

	public PW_DOMAIN2_VERSION Version;

	public DOMAIN2(string fn)
	{
		FileLoaded = false;
		Load(fn);
	}

	public DOMAIN2()
	{
		FileLoaded = false;
	}

	public void Save()
	{
		EditorSessionTracker.LogFolderAccess(fn, Class16.smethod_0(1649009269), Class16.smethod_0(1648906386));
		File.Copy(fn, fn + Class16.smethod_0(1648898363), overwrite: true);
		FileStream fileStream = new FileStream(fn, FileMode.Create, FileAccess.Write);
		BinaryWriter binaryWriter = new BinaryWriter(fileStream);
		if (bMagicExists)
		{
			binaryWriter.Write(Magic);
		}
		if (Version >= PW_DOMAIN2_VERSION.PW_1_5_1)
		{
			binaryWriter.Write(TimeStamp);
		}
		binaryWriter.Write(fUnknown);
		binaryWriter.Write(Domains.Length);
		WriteDomains(binaryWriter);
		binaryWriter.Write(Times.Length);
		WriteTimes(binaryWriter);
		binaryWriter.Write(BattletimeMax);
		byte[] bytesAfterEndOfFile = BytesAfterEndOfFile;
		if (bytesAfterEndOfFile != null)
		{
			binaryWriter.Write(bytesAfterEndOfFile);
		}
		binaryWriter.Close();
		fileStream.Close();
		GC.KeepAlive(this);
	}

	public void ExportToSev(string fn)
	{
		EditorSessionTracker.LogFolderAccess(fn, Class16.smethod_0(1649009280), Class16.smethod_0(1648906386));
		FileStream fileStream = new FileStream(fn, FileMode.Create, FileAccess.Write);
		BinaryWriter binaryWriter = new BinaryWriter(fileStream);
		if (Version >= PW_DOMAIN2_VERSION.PW_1_5_1)
		{
			binaryWriter.Write(TimeStamp);
		}
		binaryWriter.Write(Domains.Length);
		WriteDomains_sev(binaryWriter);
		binaryWriter.Write(Times.Length);
		WriteTimes(binaryWriter);
		binaryWriter.Write(BattletimeMax);
		binaryWriter.Close();
		fileStream.Close();
		GC.KeepAlive(this);
	}

	public void WriteTimes(BinaryWriter bw)
	{
		int num = 0;
		BattletimeServer[] times = Times;
		if (0 < (nint)times.LongLength)
		{
			do
			{
				bw.Write(times[num].int_0);
				bw.Write(Times[num].int_1);
				bw.Write(Times[num].int_2);
				num++;
				times = Times;
			}
			while (num < (nint)times.LongLength);
		}
		GC.KeepAlive(this);
	}

	public void WriteDomains(BinaryWriter bw)
	{
		int num = 0;
		DomainInfo[] domains = Domains;
		if (0 < (nint)domains.LongLength)
		{
			do
			{
				bw.Write(CommonStorage.ValidateBytes(domains[num].name));
				bw.Write(Domains[num].ID);
				bw.Write(Domains[num].Point);
				bw.Write(Domains[num].WarType);
				bw.Write(Domains[num].CountryId);
				bw.Write(Domains[num].IsCapital);
				int num2 = 0;
				do
				{
					bw.Write(Domains[num].Coords[num2].Single_2);
					bw.Write(Domains[num].Coords[num2].Single_1);
					bw.Write(Domains[num].Coords[num2].Single_0);
					num2++;
				}
				while (num2 < 4);
				bw.Write(Domains[num].BaseLogoX);
				bw.Write(Domains[num].BaseLogoY);
				bw.Write(Domains[num].Points.Count);
				int num3 = 0;
				if (0 < Domains[num].Points.Count)
				{
					do
					{
						Domains[num].Points[num3].Write(bw);
						num3++;
					}
					while (num3 < Domains[num].Points.Count);
				}
				bw.Write(Domains[num].Triangles.Count);
				int num4 = 0;
				if (0 < Domains[num].Triangles.Count)
				{
					do
					{
						Domains[num].Triangles[num4].Write(bw);
						num4++;
					}
					while (num4 < Domains[num].Triangles.Count);
				}
				bw.Write(Domains[num].Neighbors.Count);
				int num5 = 0;
				if (0 < Domains[num].Neighbors.Count)
				{
					do
					{
						bw.Write(Domains[num].Neighbors[num5]);
						num5++;
					}
					while (num5 < Domains[num].Neighbors.Count);
				}
				num++;
				domains = Domains;
			}
			while (num < (nint)domains.LongLength);
		}
		GC.KeepAlive(this);
	}

	private static void smethod_0(BinaryReader binaryReader_0, int int_0, string string_0)
	{
		if (int_0 < 0)
		{
			throw new InvalidDataException(string.Format(Class16.smethod_0(1648921204), string_0, int_0));
		}
		long num = binaryReader_0.BaseStream.Length - binaryReader_0.BaseStream.Position;
		if (num < int_0)
		{
			throw new EndOfStreamException(string.Format(Class16.smethod_0(1648921238), string_0, int_0, num));
		}
	}

	private static byte[] smethod_1(BinaryReader binaryReader_0, int int_0, string string_0)
	{
		smethod_0(binaryReader_0, int_0, string_0);
		byte[] array = binaryReader_0.ReadBytes(int_0);
		if (array.Length != int_0)
		{
			throw new EndOfStreamException(string.Format(Class16.smethod_0(1648921300), string_0, int_0, array.Length));
		}
		return array;
	}

	private static int smethod_2(int int_0, string string_0)
	{
		if (int_0 < 0 || int_0 > 100000)
		{
			throw new InvalidDataException(string.Format(Class16.smethod_0(1648917887), string_0, int_0));
		}
		return int_0;
	}

	public void WriteDomains_sev(BinaryWriter bw)
	{
		int num = 0;
		DomainInfo[] domains = Domains;
		if (0 < (nint)domains.LongLength)
		{
			do
			{
				bw.Write(domains[num].ID);
				bw.Write(Domains[num].Point);
				bw.Write(Domains[num].WarType);
				bw.Write(Domains[num].CountryId);
				bw.Write(Domains[num].IsCapital);
				int num2 = 0;
				do
				{
					bw.Write(Domains[num].Coords[num2].Single_2);
					bw.Write(Domains[num].Coords[num2].Single_1);
					bw.Write(Domains[num].Coords[num2].Single_0);
					num2++;
				}
				while (num2 < 4);
				bw.Write(Domains[num].Neighbors.Count);
				int num3 = 0;
				if (0 < Domains[num].Neighbors.Count)
				{
					do
					{
						bw.Write(Domains[num].Neighbors[num3]);
						num3++;
					}
					while (num3 < Domains[num].Neighbors.Count);
				}
				int num4 = 0;
				if (0 < Domains[num].Neighbors.Count)
				{
					do
					{
						bw.Write(CommonStorage.AParams.Domain2TimeBetweenMaps);
						num4++;
					}
					while (num4 < Domains[num].Neighbors.Count);
				}
				num++;
				domains = Domains;
			}
			while (num < (nint)domains.LongLength);
		}
		GC.KeepAlive(this);
	}

	public void Load(string fn)
	{
		if (!File.Exists(fn))
		{
			GC.KeepAlive(this);
			return;
		}
		EditorSessionTracker.LogFolderAccess(fn, Class16.smethod_0(1649009306), Class16.smethod_0(1648906386));
		this.fn = fn;
		using FileStream input = File.OpenRead(fn);
		BinaryReader binaryReader = new BinaryReader(input);
		try
		{
			Version = DetectVersion(binaryReader);
			if (bMagicExists)
			{
				Magic = smethod_1(binaryReader, 4, Class16.smethod_0(1649009333));
			}
			if (Version >= PW_DOMAIN2_VERSION.PW_1_5_1)
			{
				smethod_0(binaryReader, 4, Class16.smethod_0(1649009345));
				TimeStamp = binaryReader.ReadInt32();
			}
			smethod_0(binaryReader, 8, Class16.smethod_0(1649009369));
			fUnknown = binaryReader.ReadSingle();
			int count = smethod_2(binaryReader.ReadInt32(), Class16.smethod_0(1649009842));
			ReadDomains(binaryReader, count);
			smethod_0(binaryReader, 8, Class16.smethod_0(1649009405));
			TimeNum = smethod_2(binaryReader.ReadInt32(), Class16.smethod_0(1649010007));
			ReadTimes(binaryReader);
			BattletimeMax = binaryReader.ReadInt32();
			if (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
			{
				BytesAfterEndOfFile = smethod_1(binaryReader, (int)(binaryReader.BaseStream.Length - binaryReader.BaseStream.Position), Class16.smethod_0(1649009431));
			}
			FileLoaded = true;
		}
		finally
		{
			((IDisposable)binaryReader).Dispose();
		}
	}

	public void ReadTimes(BinaryReader br)
	{
		int timeNum = TimeNum;
		Times = new BattletimeServer[timeNum];
		int num = 0;
		if (0 < timeNum)
		{
			do
			{
				Times[num] = new BattletimeServer();
				Times[num].int_0 = br.ReadInt32();
				Times[num].int_1 = br.ReadInt32();
				Times[num].int_2 = br.ReadInt32();
				num++;
			}
			while (num < TimeNum);
		}
		GC.KeepAlive(this);
	}

	public void ReadDomains(BinaryReader br, int count)
	{
		smethod_2(count, Class16.smethod_0(1649009842));
		DomainInfo[] array = (Domains = new DomainInfo[count]);
		int num = 0;
		if (0 < (nint)array.LongLength)
		{
			do
			{
				smethod_0(br, 56, string.Format(Class16.smethod_0(1649009460), num));
				ref DomainInfo reference = ref array[num];
				reference = new DomainInfo();
				reference.name = smethod_1(br, 32, string.Format(Class16.smethod_0(1649009495), num));
				reference.ID = br.ReadInt32();
				reference.Point = br.ReadInt32();
				reference.WarType = br.ReadInt32();
				reference.CountryId = br.ReadInt32();
				reference.IsCapital = br.ReadInt32();
				reference.Coords = new ObservableCollection<XYZ>();
				uint num2 = 4u;
				do
				{
					reference.Coords.Add(new XYZ(br));
					num2--;
				}
				while (num2 != 0);
				reference.BaseLogoX = br.ReadInt32();
				reference.BaseLogoY = br.ReadInt32();
				int num3 = smethod_2(br.ReadInt32(), string.Format(Class16.smethod_0(1649009525), num));
				reference.Points = new ObservableCollection<DOMAIN_POINT>();
				if (0 < num3)
				{
					int num4 = num3;
					do
					{
						reference.Points.Add(new DOMAIN_POINT(br));
						num4--;
					}
					while (num4 != 0);
				}
				int num5 = smethod_2(br.ReadInt32(), string.Format(Class16.smethod_0(1649009555), num));
				reference.Triangles = new ObservableCollection<DOMAIN_TRIANGLE>();
				if (0 < num5)
				{
					int num6 = num5;
					do
					{
						reference.Triangles.Add(new DOMAIN_TRIANGLE(br));
						num6--;
					}
					while (num6 != 0);
				}
				int num7 = smethod_2(br.ReadInt32(), string.Format(Class16.smethod_0(1649009604), num));
				reference.Neighbors = new ObservableCollection<int>();
				if (0 < num7)
				{
					int num8 = num7;
					do
					{
						reference.Neighbors.Add(br.ReadInt32());
						num8--;
					}
					while (num8 != 0);
				}
				num++;
			}
			while (num < (nint)array.LongLength);
		}
		GC.KeepAlive(this);
	}

	public void AddDomain()
	{
		Array.Resize(ref Domains, (int)((nint)Domains.LongLength + 1));
		int num = (int)((nint)Domains.LongLength - 1);
		Domains[num] = new DomainInfo();
		DomainInfo[] domains = Domains;
		domains[num].ID = domains.Length;
		Domains[num].Coords = new ObservableCollection<XYZ>();
		uint num2 = 4u;
		do
		{
			Domains[num].Coords.Add(new XYZ());
			num2--;
		}
		while (num2 != 0);
		Domains[num].Neighbors = new ObservableCollection<int>();
		GC.KeepAlive(this);
	}

	public void AddDomain(int Index)
	{
		Array.Resize(ref Domains, (int)((nint)Domains.LongLength + 1));
		DomainInfo[] domains = Domains;
		int num = (int)((nint)domains.LongLength - 1);
		domains[num] = Domains[Index].Clone();
		DomainInfo[] domains2 = Domains;
		int num2 = domains2.Length;
		domains2[num2 - 1].ID = num2;
		GC.KeepAlive(this);
	}

	public void DeleteDomain(int Index)
	{
		int num = 0;
		if (0 < (nint)Domains.LongLength)
		{
			do
			{
				DomainInfo domainInfo = Domains[Index];
				Domains[num].Neighbors.Remove(domainInfo.ID);
				num++;
			}
			while (num < (nint)Domains.LongLength);
		}
		DomainInfo[] domains = Domains;
		DomainInfo[] array = new DomainInfo[(nint)domains.LongLength - 1];
		Array.Copy(domains, 0, array, 0, Index);
		DomainInfo[] domains2 = Domains;
		Array.Copy(domains2, Index + 1, array, Index, (int)((nint)domains2.LongLength - Index - 1));
		Domains = array;
	}

	public void AddTime()
	{
		Array.Resize(ref Times, (int)((nint)Times.LongLength + 1));
		BattletimeServer[] times = Times;
		int num = (int)((nint)times.LongLength - 1);
		times[num] = new BattletimeServer();
		TimeNum++;
	}

	public void AddTime(int Index)
	{
		Array.Resize(ref Times, (int)((nint)Times.LongLength + 1));
		BattletimeServer[] times = Times;
		int num = (int)((nint)times.LongLength - 1);
		times[num] = Times[Index].Clone();
		TimeNum++;
	}

	public void DeleteTime(int Index)
	{
		BattletimeServer[] times = Times;
		BattletimeServer[] array = new BattletimeServer[(nint)times.LongLength - 1];
		Array.Copy(times, 0, array, 0, Index);
		BattletimeServer[] times2 = Times;
		Array.Copy(times2, Index + 1, array, Index, (int)((nint)times2.LongLength - Index - 1));
		Times = array;
		TimeNum--;
	}

	public PW_DOMAIN2_VERSION DetectVersion(BinaryReader br)
	{
		uint num = br.ReadUInt32();
		if (num == 1113083725)
		{
			bMagicExists = true;
			num = br.ReadUInt32();
		}
		PW_DOMAIN2_VERSION result = ((num == 1077936128 || num < 1278115200) ? PW_DOMAIN2_VERSION.PW_1_4_7 : PW_DOMAIN2_VERSION.PW_1_5_1);
		br.BaseStream.Position = 0L;
		GC.KeepAlive(this);
		return result;
	}
}
