using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace ACE.Bmd;

public sealed class BMD
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public sealed class AabbValue
	{
		private Vector3Value vector3Value_0 = new Vector3Value();

		private Vector3Value vector3Value_1 = new Vector3Value();

		private Vector3Value vector3Value_2 = new Vector3Value();

		private Vector3Value vector3Value_3 = new Vector3Value();

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public Vector3Value Center
		{
			[CompilerGenerated]
			get
			{
				return vector3Value_0;
			}
			[CompilerGenerated]
			set
			{
				vector3Value_0 = value;
			}
		}

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public Vector3Value Extents
		{
			[CompilerGenerated]
			get
			{
				return vector3Value_1;
			}
			[CompilerGenerated]
			set
			{
				vector3Value_1 = value;
			}
		}

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public Vector3Value Mins
		{
			[CompilerGenerated]
			get
			{
				return vector3Value_2;
			}
			[CompilerGenerated]
			set
			{
				vector3Value_2 = value;
			}
		}

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public Vector3Value Maxs
		{
			[CompilerGenerated]
			get
			{
				return vector3Value_3;
			}
			[CompilerGenerated]
			set
			{
				vector3Value_3 = value;
			}
		}
	}

	[TypeConverter(typeof(ExpandableObjectConverter))]
	public sealed class BmdMesh
	{
		private bool bool_0;

		private uint uint_0 = 268435462u;

		private bool bool_1;

		private bool bool_2;

		private string string_0 = string.Empty;

		private string string_1 = string.Empty;

		private bool bool_3;

		private byte byte_0;

		private bool bool_4;

		private bool bool_5;

		private bool bool_6;

		private bool bool_7;

		private readonly List<BmdVertex> list_0 = new List<BmdVertex>();

		private readonly List<FaceShort> list_1 = new List<FaceShort>();

		private readonly List<Vector3Value> list_2 = new List<Vector3Value>();

		private readonly List<FaceShort> list_3 = new List<FaceShort>();

		private readonly List<uint> list_4 = new List<uint>();

		private readonly List<uint> list_5 = new List<uint>();

		private readonly List<uint> list_6 = new List<uint>();

		private readonly List<uint> list_7 = new List<uint>();

		private readonly List<LightMapCoord> list_8 = new List<LightMapCoord>();

		private AabbValue aabbValue_0 = new AabbValue();

		private MaterialOld materialOld_0 = new MaterialOld();

		private MaterialV2 materialV2_0 = new MaterialV2();

		private ColorValue colorValue_0 = new ColorValue();

		private byte[] byte_1 = Array.Empty<byte>();

		[Category("General")]
		public bool IsNewFormat
		{
			[CompilerGenerated]
			get
			{
				return bool_0;
			}
			[CompilerGenerated]
			set
			{
				bool_0 = value;
			}
		}

		[Category("General")]
		public uint MeshVersion
		{
			[CompilerGenerated]
			get
			{
				return uint_0;
			}
			[CompilerGenerated]
			set
			{
				uint_0 = value;
			}
		}

		[Category("General")]
		public bool SupportLightMap
		{
			[CompilerGenerated]
			get
			{
				return bool_1;
			}
			[CompilerGenerated]
			set
			{
				bool_1 = value;
			}
		}

		[Category("General")]
		public bool UseLightMap
		{
			[CompilerGenerated]
			get
			{
				return bool_2;
			}
			[CompilerGenerated]
			set
			{
				bool_2 = value;
			}
		}

		[Category("General")]
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

		[Category("General")]
		public string TexturePath
		{
			[CompilerGenerated]
			get
			{
				return string_1;
			}
			[CompilerGenerated]
			set
			{
				string_1 = value;
			}
		}

		[Category("General")]
		public bool HasExtraColorsFlag
		{
			[CompilerGenerated]
			get
			{
				return bool_3;
			}
			[CompilerGenerated]
			set
			{
				bool_3 = value;
			}
		}

		[Category("General")]
		public byte ExtraColorsFlag
		{
			[CompilerGenerated]
			get
			{
				return byte_0;
			}
			[CompilerGenerated]
			set
			{
				byte_0 = value;
			}
		}

		[Category("General")]
		public bool HasFaceNormals
		{
			[CompilerGenerated]
			get
			{
				return bool_4;
			}
			[CompilerGenerated]
			set
			{
				bool_4 = value;
			}
		}

		[Category("General")]
		public bool HasUnknownColorV304
		{
			[CompilerGenerated]
			get
			{
				return bool_5;
			}
			[CompilerGenerated]
			set
			{
				bool_5 = value;
			}
		}

		[Category("General")]
		public bool HasMaterialOld
		{
			[CompilerGenerated]
			get
			{
				return bool_6;
			}
			[CompilerGenerated]
			set
			{
				bool_6 = value;
			}
		}

		[Category("General")]
		public bool HasMaterialV2
		{
			[CompilerGenerated]
			get
			{
				return bool_7;
			}
			[CompilerGenerated]
			set
			{
				bool_7 = value;
			}
		}

		[Category("Count")]
		public int VertexCount => Vertices.Count;

		[Category("Count")]
		public int FaceCount => Faces.Count;

		[Category("Count")]
		public int NormalCount => Normals.Count;

		[Category("Count")]
		public int FaceNormalCount => FaceNormals.Count;

		[Browsable(false)]
		public List<BmdVertex> Vertices
		{
			[CompilerGenerated]
			get
			{
				return list_0;
			}
		}

		[Browsable(false)]
		public List<FaceShort> Faces
		{
			[CompilerGenerated]
			get
			{
				return list_1;
			}
		}

		[Browsable(false)]
		public List<Vector3Value> Normals
		{
			[CompilerGenerated]
			get
			{
				return list_2;
			}
		}

		[Browsable(false)]
		public List<FaceShort> FaceNormals
		{
			[CompilerGenerated]
			get
			{
				return list_3;
			}
		}

		[Browsable(false)]
		public List<uint> DayColors
		{
			[CompilerGenerated]
			get
			{
				return list_4;
			}
		}

		[Browsable(false)]
		public List<uint> NightColors
		{
			[CompilerGenerated]
			get
			{
				return list_5;
			}
		}

		[Browsable(false)]
		public List<uint> DayColorsExtra
		{
			[CompilerGenerated]
			get
			{
				return list_6;
			}
		}

		[Browsable(false)]
		public List<uint> NightColorsExtra
		{
			[CompilerGenerated]
			get
			{
				return list_7;
			}
		}

		[Browsable(false)]
		public List<LightMapCoord> LightTexCoords
		{
			[CompilerGenerated]
			get
			{
				return list_8;
			}
		}

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public AabbValue Aabb
		{
			[CompilerGenerated]
			get
			{
				return aabbValue_0;
			}
			[CompilerGenerated]
			set
			{
				aabbValue_0 = value;
			}
		}

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public MaterialOld MaterialOld
		{
			[CompilerGenerated]
			get
			{
				return materialOld_0;
			}
			[CompilerGenerated]
			set
			{
				materialOld_0 = value;
			}
		}

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public MaterialV2 MaterialV2
		{
			[CompilerGenerated]
			get
			{
				return materialV2_0;
			}
			[CompilerGenerated]
			set
			{
				materialV2_0 = value;
			}
		}

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public ColorValue UnknownColorV304
		{
			[CompilerGenerated]
			get
			{
				return colorValue_0;
			}
			[CompilerGenerated]
			set
			{
				colorValue_0 = value;
			}
		}

		[Browsable(false)]
		public byte[] ExtraData
		{
			[CompilerGenerated]
			get
			{
				return byte_1;
			}
			[CompilerGenerated]
			set
			{
				byte_1 = value;
			}
		}

		public override string ToString()
		{
			string arg = (string.IsNullOrWhiteSpace(Name) ? Class16.smethod_0(1648918611) : Name);
			return string.Format(Class16.smethod_0(1648918624), arg, VertexCount, FaceCount);
		}
	}

	[TypeConverter(typeof(ExpandableObjectConverter))]
	public sealed class BmdVertex
	{
		private float float_0;

		private float float_1;

		private float float_2;

		private uint uint_0;

		private uint uint_1;

		private float float_3;

		private float float_4;

		private bool bool_0;

		public float Single_0
		{
			[CompilerGenerated]
			get
			{
				return float_0;
			}
			[CompilerGenerated]
			set
			{
				float_0 = value;
			}
		}

		public float Single_1
		{
			[CompilerGenerated]
			get
			{
				return float_1;
			}
			[CompilerGenerated]
			set
			{
				float_1 = value;
			}
		}

		public float Single_2
		{
			[CompilerGenerated]
			get
			{
				return float_2;
			}
			[CompilerGenerated]
			set
			{
				float_2 = value;
			}
		}

		public uint Diffuse
		{
			[CompilerGenerated]
			get
			{
				return uint_0;
			}
			[CompilerGenerated]
			set
			{
				uint_0 = value;
			}
		}

		public uint Specular
		{
			[CompilerGenerated]
			get
			{
				return uint_1;
			}
			[CompilerGenerated]
			set
			{
				uint_1 = value;
			}
		}

		public float Single_3
		{
			[CompilerGenerated]
			get
			{
				return float_3;
			}
			[CompilerGenerated]
			set
			{
				float_3 = value;
			}
		}

		public float Single_4
		{
			[CompilerGenerated]
			get
			{
				return float_4;
			}
			[CompilerGenerated]
			set
			{
				float_4 = value;
			}
		}

		public bool HasSpecular
		{
			[CompilerGenerated]
			get
			{
				return bool_0;
			}
			[CompilerGenerated]
			set
			{
				bool_0 = value;
			}
		}
	}

	[TypeConverter(typeof(ExpandableObjectConverter))]
	public sealed class CollisionBrush
	{
		private AabbValue aabbValue_0 = new AabbValue();

		private uint uint_0;

		private readonly List<CollisionSide> list_0 = new List<CollisionSide>();

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public AabbValue Aabb
		{
			[CompilerGenerated]
			get
			{
				return aabbValue_0;
			}
			[CompilerGenerated]
			set
			{
				aabbValue_0 = value;
			}
		}

		public uint Reserved
		{
			[CompilerGenerated]
			get
			{
				return uint_0;
			}
			[CompilerGenerated]
			set
			{
				uint_0 = value;
			}
		}

		[Browsable(false)]
		public List<CollisionSide> Sides
		{
			[CompilerGenerated]
			get
			{
				return list_0;
			}
		}

		public int SideCount => Sides.Count;

		public override string ToString()
		{
			return string.Format(Class16.smethod_0(1648918648), SideCount);
		}
	}

	[TypeConverter(typeof(ExpandableObjectConverter))]
	public sealed class CollisionSide
	{
		private Vector3Value vector3Value_0 = new Vector3Value();

		private float float_0;

		private byte byte_0;

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public Vector3Value Normal
		{
			[CompilerGenerated]
			get
			{
				return vector3Value_0;
			}
			[CompilerGenerated]
			set
			{
				vector3Value_0 = value;
			}
		}

		public float Distance
		{
			[CompilerGenerated]
			get
			{
				return float_0;
			}
			[CompilerGenerated]
			set
			{
				float_0 = value;
			}
		}

		public byte Bevel
		{
			[CompilerGenerated]
			get
			{
				return byte_0;
			}
			[CompilerGenerated]
			set
			{
				byte_0 = value;
			}
		}
	}

	[TypeConverter(typeof(ExpandableObjectConverter))]
	public sealed class ColorValue
	{
		private float float_0;

		private float float_1;

		private float float_2;

		private float float_3;

		public float Single_0
		{
			[CompilerGenerated]
			get
			{
				return float_0;
			}
			[CompilerGenerated]
			set
			{
				float_0 = value;
			}
		}

		public float Single_1
		{
			[CompilerGenerated]
			get
			{
				return float_1;
			}
			[CompilerGenerated]
			set
			{
				float_1 = value;
			}
		}

		public float Single_2
		{
			[CompilerGenerated]
			get
			{
				return float_2;
			}
			[CompilerGenerated]
			set
			{
				float_2 = value;
			}
		}

		public float Single_3
		{
			[CompilerGenerated]
			get
			{
				return float_3;
			}
			[CompilerGenerated]
			set
			{
				float_3 = value;
			}
		}
	}

	[TypeConverter(typeof(ExpandableObjectConverter))]
	public sealed class FaceShort
	{
		private short short_0;

		private short short_1;

		private short short_2;

		public short Int16_0
		{
			[CompilerGenerated]
			get
			{
				return short_0;
			}
			[CompilerGenerated]
			set
			{
				short_0 = value;
			}
		}

		public short Int16_1
		{
			[CompilerGenerated]
			get
			{
				return short_1;
			}
			[CompilerGenerated]
			set
			{
				short_1 = value;
			}
		}

		public short Int16_2
		{
			[CompilerGenerated]
			get
			{
				return short_2;
			}
			[CompilerGenerated]
			set
			{
				short_2 = value;
			}
		}
	}

	[TypeConverter(typeof(ExpandableObjectConverter))]
	public sealed class HullMesh
	{
		private readonly List<int> list_0 = new List<int>();

		[Browsable(false)]
		public List<int> MeshIds
		{
			[CompilerGenerated]
			get
			{
				return list_0;
			}
		}

		public int MeshIdCount => MeshIds.Count;

		public override string ToString()
		{
			return string.Format(Class16.smethod_0(1648918666), MeshIdCount);
		}
	}

	[TypeConverter(typeof(ExpandableObjectConverter))]
	public sealed class LightMapCoord
	{
		private float float_0;

		private float float_1;

		public float Single_0
		{
			[CompilerGenerated]
			get
			{
				return float_0;
			}
			[CompilerGenerated]
			set
			{
				float_0 = value;
			}
		}

		public float Single_1
		{
			[CompilerGenerated]
			get
			{
				return float_1;
			}
			[CompilerGenerated]
			set
			{
				float_1 = value;
			}
		}
	}

	[TypeConverter(typeof(ExpandableObjectConverter))]
	public sealed class LocationTransform
	{
		private float float_0 = 1f;

		private float float_1 = 1f;

		private float float_2 = 1f;

		private float float_3;

		private float float_4;

		private float float_5 = 1f;

		private float float_6;

		private float float_7 = 1f;

		private float float_8;

		private float float_9;

		private float float_10;

		private float float_11;

		public float ScaleX
		{
			[CompilerGenerated]
			get
			{
				return float_0;
			}
			[CompilerGenerated]
			set
			{
				float_0 = value;
			}
		}

		public float ScaleY
		{
			[CompilerGenerated]
			get
			{
				return float_1;
			}
			[CompilerGenerated]
			set
			{
				float_1 = value;
			}
		}

		public float ScaleZ
		{
			[CompilerGenerated]
			get
			{
				return float_2;
			}
			[CompilerGenerated]
			set
			{
				float_2 = value;
			}
		}

		public float DirectionX
		{
			[CompilerGenerated]
			get
			{
				return float_3;
			}
			[CompilerGenerated]
			set
			{
				float_3 = value;
			}
		}

		public float DirectionY
		{
			[CompilerGenerated]
			get
			{
				return float_4;
			}
			[CompilerGenerated]
			set
			{
				float_4 = value;
			}
		}

		public float DirectionZ
		{
			[CompilerGenerated]
			get
			{
				return float_5;
			}
			[CompilerGenerated]
			set
			{
				float_5 = value;
			}
		}

		public float UpX
		{
			[CompilerGenerated]
			get
			{
				return float_6;
			}
			[CompilerGenerated]
			set
			{
				float_6 = value;
			}
		}

		public float UpY
		{
			[CompilerGenerated]
			get
			{
				return float_7;
			}
			[CompilerGenerated]
			set
			{
				float_7 = value;
			}
		}

		public float UpZ
		{
			[CompilerGenerated]
			get
			{
				return float_8;
			}
			[CompilerGenerated]
			set
			{
				float_8 = value;
			}
		}

		public float PositionX
		{
			[CompilerGenerated]
			get
			{
				return float_9;
			}
			[CompilerGenerated]
			set
			{
				float_9 = value;
			}
		}

		public float PositionY
		{
			[CompilerGenerated]
			get
			{
				return float_10;
			}
			[CompilerGenerated]
			set
			{
				float_10 = value;
			}
		}

		public float PositionZ
		{
			[CompilerGenerated]
			get
			{
				return float_11;
			}
			[CompilerGenerated]
			set
			{
				float_11 = value;
			}
		}
	}

	[TypeConverter(typeof(ExpandableObjectConverter))]
	public sealed class MaterialOld
	{
		private ColorValue colorValue_0 = new ColorValue();

		private ColorValue colorValue_1 = new ColorValue();

		private ColorValue colorValue_2 = new ColorValue();

		private ColorValue colorValue_3 = new ColorValue();

		private float float_0;

		private byte byte_0;

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public ColorValue Diffuse
		{
			[CompilerGenerated]
			get
			{
				return colorValue_0;
			}
			[CompilerGenerated]
			set
			{
				colorValue_0 = value;
			}
		}

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public ColorValue Ambient
		{
			[CompilerGenerated]
			get
			{
				return colorValue_1;
			}
			[CompilerGenerated]
			set
			{
				colorValue_1 = value;
			}
		}

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public ColorValue Emissive
		{
			[CompilerGenerated]
			get
			{
				return colorValue_2;
			}
			[CompilerGenerated]
			set
			{
				colorValue_2 = value;
			}
		}

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public ColorValue Specular
		{
			[CompilerGenerated]
			get
			{
				return colorValue_3;
			}
			[CompilerGenerated]
			set
			{
				colorValue_3 = value;
			}
		}

		public float Power
		{
			[CompilerGenerated]
			get
			{
				return float_0;
			}
			[CompilerGenerated]
			set
			{
				float_0 = value;
			}
		}

		public byte TwoSided
		{
			[CompilerGenerated]
			get
			{
				return byte_0;
			}
			[CompilerGenerated]
			set
			{
				byte_0 = value;
			}
		}
	}

	[TypeConverter(typeof(ExpandableObjectConverter))]
	public sealed class MaterialV2
	{
		private byte[] byte_0 = new byte[11];

		private ColorValue colorValue_0 = new ColorValue();

		private ColorValue colorValue_1 = new ColorValue();

		private ColorValue colorValue_2 = new ColorValue();

		private ColorValue colorValue_3 = new ColorValue();

		private float float_0;

		private byte byte_1;

		[Browsable(false)]
		public byte[] HeaderBytes
		{
			[CompilerGenerated]
			get
			{
				return byte_0;
			}
			[CompilerGenerated]
			set
			{
				byte_0 = value;
			}
		}

		public string HeaderHex
		{
			get
			{
				byte[] array = HeaderBytes ?? Array.Empty<byte>();
				StringBuilder stringBuilder = new StringBuilder(array.Length * 2);
				for (int i = 0; i < array.Length; i++)
				{
					stringBuilder.Append(array[i].ToString(Class16.smethod_0(1648918695)));
				}
				return stringBuilder.ToString();
			}
			set
			{
				string text = Regex.Replace(value ?? string.Empty, Class16.smethod_0(1648918696), string.Empty);
				byte[] array = new byte[11];
				int num = Math.Min(11, text.Length / 2);
				for (int i = 0; i < num; i++)
				{
					string s = text.Substring(i * 2, 2);
					array[i] = byte.Parse(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
				}
				HeaderBytes = array;
			}
		}

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public ColorValue Ambient
		{
			[CompilerGenerated]
			get
			{
				return colorValue_0;
			}
			[CompilerGenerated]
			set
			{
				colorValue_0 = value;
			}
		}

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public ColorValue Diffuse
		{
			[CompilerGenerated]
			get
			{
				return colorValue_1;
			}
			[CompilerGenerated]
			set
			{
				colorValue_1 = value;
			}
		}

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public ColorValue Emissive
		{
			[CompilerGenerated]
			get
			{
				return colorValue_2;
			}
			[CompilerGenerated]
			set
			{
				colorValue_2 = value;
			}
		}

		[TypeConverter(typeof(ExpandableObjectConverter))]
		public ColorValue Specular
		{
			[CompilerGenerated]
			get
			{
				return colorValue_3;
			}
			[CompilerGenerated]
			set
			{
				colorValue_3 = value;
			}
		}

		public float Power
		{
			[CompilerGenerated]
			get
			{
				return float_0;
			}
			[CompilerGenerated]
			set
			{
				float_0 = value;
			}
		}

		public byte TwoSided
		{
			[CompilerGenerated]
			get
			{
				return byte_1;
			}
			[CompilerGenerated]
			set
			{
				byte_1 = value;
			}
		}
	}

	[TypeConverter(typeof(ExpandableObjectConverter))]
	public sealed class Vector3Value
	{
		private float float_0;

		private float float_1;

		private float float_2;

		public float Single_0
		{
			[CompilerGenerated]
			get
			{
				return float_0;
			}
			[CompilerGenerated]
			set
			{
				float_0 = value;
			}
		}

		public float Single_1
		{
			[CompilerGenerated]
			get
			{
				return float_1;
			}
			[CompilerGenerated]
			set
			{
				float_1 = value;
			}
		}

		public float Single_2
		{
			[CompilerGenerated]
			get
			{
				return float_2;
			}
			[CompilerGenerated]
			set
			{
				float_2 = value;
			}
		}

		public override string ToString()
		{
			return string.Format(Class16.smethod_0(1648918715), Single_0, Single_1, Single_2);
		}
	}

	public const string HeaderSignature = "MOXB";

	public const uint VersionWithCollideOnly = 2147483649u;

	public const uint LitModelVersionNewFormat = 268436224u;

	public const uint LitModelVersionFaceNormals = 268436226u;

	public const uint LitModelVersionUnknownColor = 268436228u;

	public const uint MeshVersionOldMin = 268435458u;

	public const uint MeshVersionOldMax = 268435462u;

	public string fn = string.Empty;

	public bool FileLoaded;

	public bool FileChanged;

	private string string_0 = Class16.smethod_0(1648918753);

	private uint uint_0 = 268436224u;

	private bool bool_0;

	private byte byte_0;

	private uint uint_1 = 268436224u;

	private LocationTransform locationTransform_0 = new LocationTransform();

	private bool bool_1;

	private uint uint_2;

	private bool bool_2;

	private bool bool_3;

	private string string_1 = string.Empty;

	private string string_2 = string.Empty;

	private bool bool_4;

	private float float_0;

	private byte[] byte_1 = Array.Empty<byte>();

	private byte[] byte_2 = Array.Empty<byte>();

	private readonly List<BmdMesh> list_0 = new List<BmdMesh>();

	private readonly List<HullMesh> list_1 = new List<HullMesh>();

	private readonly List<CollisionBrush> list_2 = new List<CollisionBrush>();

	[Category("Header")]
	public string Header
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

	[Category("Header")]
	public uint Version
	{
		[CompilerGenerated]
		get
		{
			return uint_0;
		}
		[CompilerGenerated]
		set
		{
			uint_0 = value;
		}
	}

	[Category("Header")]
	public bool HasCollideOnlyFlag
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	[Category("Header")]
	public byte CollideOnlyFlag
	{
		[CompilerGenerated]
		get
		{
			return byte_0;
		}
		[CompilerGenerated]
		set
		{
			byte_0 = value;
		}
	}

	[Category("Header")]
	public uint LitModelVersion
	{
		[CompilerGenerated]
		get
		{
			return uint_1;
		}
		[CompilerGenerated]
		set
		{
			uint_1 = value;
		}
	}

	[Category("Transform")]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public LocationTransform Location
	{
		[CompilerGenerated]
		get
		{
			return locationTransform_0;
		}
		[CompilerGenerated]
		set
		{
			locationTransform_0 = value;
		}
	}

	[Category("Transform")]
	public bool HasUnknownDword
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	[Category("Transform")]
	public uint UnknownDword
	{
		[CompilerGenerated]
		get
		{
			return uint_2;
		}
		[CompilerGenerated]
		set
		{
			uint_2 = value;
		}
	}

	[Category("Model")]
	public bool HasGlobalLightMap
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	[Category("Model")]
	public bool HasSharedData
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	[Category("Model")]
	public string DayLightMap
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	[Category("Model")]
	public string NightLightMap
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	[Category("Model")]
	public int MeshCount => Meshes.Count;

	[Category("Model")]
	public int HullMeshCount => HullMeshes.Count;

	[Category("Model")]
	public int CollisionBrushCount => CollisionBrushes.Count;

	[Category("Trailing")]
	public bool HasAdditionalExtent
	{
		[CompilerGenerated]
		get
		{
			return bool_4;
		}
		[CompilerGenerated]
		set
		{
			bool_4 = value;
		}
	}

	[Category("Trailing")]
	public float AdditionalExtent
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	[Browsable(false)]
	public byte[] ModelExtraData
	{
		[CompilerGenerated]
		get
		{
			return byte_1;
		}
		[CompilerGenerated]
		set
		{
			byte_1 = value;
		}
	}

	[Browsable(false)]
	public byte[] RemainingData
	{
		[CompilerGenerated]
		get
		{
			return byte_2;
		}
		[CompilerGenerated]
		set
		{
			byte_2 = value;
		}
	}

	[Browsable(false)]
	public List<BmdMesh> Meshes
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
	}

	[Browsable(false)]
	public List<HullMesh> HullMeshes
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
	}

	[Browsable(false)]
	public List<CollisionBrush> CollisionBrushes
	{
		[CompilerGenerated]
		get
		{
			return list_2;
		}
	}

	public BMD()
	{
	}

	public BMD(string fileName)
	{
		if (!string.IsNullOrWhiteSpace(fileName))
		{
			Load(fileName);
		}
	}

	public void Clear()
	{
		fn = string.Empty;
		FileLoaded = false;
		FileChanged = false;
		Header = Class16.smethod_0(1648918753);
		Version = 268436224u;
		HasCollideOnlyFlag = false;
		CollideOnlyFlag = 0;
		LitModelVersion = 268436224u;
		Location = new LocationTransform();
		HasUnknownDword = false;
		UnknownDword = 0u;
		HasGlobalLightMap = false;
		HasSharedData = false;
		DayLightMap = string.Empty;
		NightLightMap = string.Empty;
		ModelExtraData = Array.Empty<byte>();
		Meshes.Clear();
		HullMeshes.Clear();
		CollisionBrushes.Clear();
		HasAdditionalExtent = false;
		AdditionalExtent = 0f;
		RemainingData = Array.Empty<byte>();
	}

	public override string ToString()
	{
		return string.Format(Class16.smethod_0(1648918772), Header, LitModelVersion, Meshes.Count);
	}

	public void Load(string fileName)
	{
		if (string.IsNullOrWhiteSpace(fileName))
		{
			throw new InvalidDataException(Class16.smethod_0(1648918812));
		}
		if (!File.Exists(fileName))
		{
			throw new FileNotFoundException(Class16.smethod_0(1648918833), fileName);
		}
		Clear();
		using FileStream input = File.OpenRead(fileName);
		BinaryReader binaryReader = new BinaryReader(input);
		try
		{
			byte[] bytes = smethod_14(binaryReader, 4, Class16.smethod_0(1648918859));
			Header = Encoding.ASCII.GetString(bytes);
			uint num = (Version = smethod_15(binaryReader, Class16.smethod_0(1648942674)));
			if (num == 2147483649u)
			{
				HasCollideOnlyFlag = true;
				CollideOnlyFlag = smethod_19(binaryReader, Class16.smethod_0(1648918872));
				LitModelVersion = smethod_15(binaryReader, Class16.smethod_0(1648918902));
			}
			else
			{
				HasCollideOnlyFlag = false;
				CollideOnlyFlag = 0;
				binaryReader.BaseStream.Position -= 4L;
				LitModelVersion = smethod_15(binaryReader, Class16.smethod_0(1648918902));
			}
			Location = smethod_2(binaryReader);
			HasUnknownDword = LitModelVersion >= 268436228;
			if (HasUnknownDword)
			{
				UnknownDword = smethod_15(binaryReader, Class16.smethod_0(1648918924));
			}
			int num3 = smethod_16(binaryReader, Class16.smethod_0(1648918943));
			smethod_21(num3, 0, 250000, Class16.smethod_0(1648918943));
			if (LitModelVersion >= 268436224)
			{
				HasGlobalLightMap = smethod_19(binaryReader, Class16.smethod_0(1648918959)) != 0;
				HasSharedData = smethod_19(binaryReader, Class16.smethod_0(1648918980)) != 0;
			}
			else
			{
				HasGlobalLightMap = false;
				HasSharedData = false;
			}
			for (int i = 0; i < num3; i++)
			{
				BmdMesh item = ((LitModelVersion >= 268436224) ? method_4(binaryReader) : method_0(binaryReader));
				Meshes.Add(item);
			}
			if (LitModelVersion >= 268436224)
			{
				if (HasGlobalLightMap)
				{
					DayLightMap = smethod_10(binaryReader, Class16.smethod_0(1648918995));
					NightLightMap = smethod_10(binaryReader, Class16.smethod_0(1648919021));
				}
				uint num4 = smethod_15(binaryReader, Class16.smethod_0(1648919033));
				if (num4 != 0 && num4 >= 4)
				{
					int num5 = checked((int)num4 - 4);
					ModelExtraData = ((num5 > 0) ? smethod_14(binaryReader, num5, Class16.smethod_0(1648922134)) : Array.Empty<byte>());
				}
				else
				{
					ModelExtraData = Array.Empty<byte>();
				}
			}
			int num6 = smethod_16(binaryReader, Class16.smethod_0(1648922147));
			smethod_21(num6, 0, 100000, Class16.smethod_0(1648922147));
			for (int j = 0; j < num6; j++)
			{
				HullMeshes.Add(method_5(binaryReader));
			}
			for (int k = 0; k < num6; k++)
			{
				CollisionBrushes.Add(method_6(binaryReader));
			}
			long num7 = binaryReader.BaseStream.Length - binaryReader.BaseStream.Position;
			if (num7 == 4L)
			{
				HasAdditionalExtent = true;
				AdditionalExtent = smethod_18(binaryReader, Class16.smethod_0(1648922175));
			}
			else if (num7 > 0L)
			{
				HasAdditionalExtent = false;
				RemainingData = smethod_14(binaryReader, (int)num7, Class16.smethod_0(1648922198));
			}
			fn = fileName;
			FileLoaded = true;
			FileChanged = false;
		}
		finally
		{
			((IDisposable)binaryReader).Dispose();
		}
	}

	private BmdMesh method_0(BinaryReader binaryReader_0)
	{
		BmdMesh bmdMesh = new BmdMesh();
		bmdMesh.IsNewFormat = false;
		uint num = (bmdMesh.MeshVersion = smethod_15(binaryReader_0, Class16.smethod_0(1648922210)));
		if (num >= 268435458 && num <= 268435462)
		{
			bmdMesh.Name = smethod_11(smethod_14(binaryReader_0, 64, Class16.smethod_0(1648922273)));
			bmdMesh.TexturePath = smethod_11(smethod_14(binaryReader_0, 256, Class16.smethod_0(1648922288)));
			int num3 = smethod_16(binaryReader_0, Class16.smethod_0(1648922306));
			int num4 = smethod_16(binaryReader_0, Class16.smethod_0(1648922328));
			smethod_21(num3, 0, 2500000, Class16.smethod_0(1648922306));
			smethod_21(num4, 0, 2500000, Class16.smethod_0(1648922328));
			bmdMesh.HasExtraColorsFlag = num >= 268435462;
			if (bmdMesh.HasExtraColorsFlag)
			{
				bmdMesh.ExtraColorsFlag = smethod_19(binaryReader_0, Class16.smethod_0(1648922356));
			}
			bool flag = num <= 268435459;
			for (int i = 0; i < num3; i++)
			{
				BmdVertex bmdVertex = new BmdVertex();
				bmdVertex.Single_0 = smethod_18(binaryReader_0, Class16.smethod_0(1648922382));
				bmdVertex.Single_1 = smethod_18(binaryReader_0, Class16.smethod_0(1648922396));
				bmdVertex.Single_2 = smethod_18(binaryReader_0, Class16.smethod_0(1648922402));
				bmdVertex.Diffuse = smethod_15(binaryReader_0, Class16.smethod_0(1648922416));
				bmdVertex.HasSpecular = flag;
				if (flag)
				{
					bmdVertex.Specular = smethod_15(binaryReader_0, Class16.smethod_0(1648922444));
				}
				bmdVertex.Single_3 = smethod_18(binaryReader_0, Class16.smethod_0(1648922457));
				bmdVertex.Single_4 = smethod_18(binaryReader_0, Class16.smethod_0(1648922479));
				bmdMesh.Vertices.Add(bmdVertex);
			}
			for (int j = 0; j < num4; j++)
			{
				bmdMesh.Faces.Add(smethod_3(binaryReader_0));
			}
			for (int k = 0; k < num3; k++)
			{
				bmdMesh.Normals.Add(smethod_4(binaryReader_0));
			}
			if (num >= 268435459)
			{
				smethod_9(binaryReader_0, num3, bmdMesh.DayColors, Class16.smethod_0(1648922493));
				smethod_9(binaryReader_0, num3, bmdMesh.NightColors, Class16.smethod_0(1648922509));
			}
			if (num >= 268435462 && bmdMesh.ExtraColorsFlag == 1)
			{
				smethod_9(binaryReader_0, num3, bmdMesh.DayColorsExtra, Class16.smethod_0(1648922527));
				smethod_9(binaryReader_0, num3, bmdMesh.NightColorsExtra, Class16.smethod_0(1648922548));
			}
			bmdMesh.Aabb = smethod_1(binaryReader_0);
			bmdMesh.HasMaterialOld = num >= 268435461;
			if (bmdMesh.HasMaterialOld)
			{
				bmdMesh.MaterialOld = smethod_7(binaryReader_0);
			}
			return bmdMesh;
		}
		throw new InvalidDataException(string.Format(Class16.smethod_0(1648922236), num));
	}

	public void Save()
	{
		Save(fn);
	}

	public void Save(string fileName)
	{
		if (!string.IsNullOrWhiteSpace(fileName))
		{
			fn = fileName;
		}
		if (string.IsNullOrWhiteSpace(fn))
		{
			throw new InvalidDataException(Class16.smethod_0(1648918812));
		}
		using FileStream output = File.Open(fn, FileMode.Create, FileAccess.Write, FileShare.None);
		BinaryWriter binaryWriter = new BinaryWriter(output);
		try
		{
			method_1(binaryWriter);
			method_2(binaryWriter);
			smethod_0(binaryWriter, Location ?? new LocationTransform());
			if (LitModelVersion >= 268436228 || HasUnknownDword)
			{
				binaryWriter.Write(UnknownDword);
			}
			int value = Meshes?.Count ?? 0;
			binaryWriter.Write(value);
			bool flag;
			if (flag = LitModelVersion >= 268436224)
			{
				binaryWriter.Write(HasGlobalLightMap ? ((byte)1) : ((byte)0));
				binaryWriter.Write(HasSharedData ? ((byte)1) : ((byte)0));
			}
			if (Meshes != null)
			{
				for (int i = 0; i < Meshes.Count; i++)
				{
					if (flag)
					{
						method_7(binaryWriter, Meshes[i]);
					}
					else
					{
						method_3(binaryWriter, Meshes[i]);
					}
				}
			}
			if (flag)
			{
				if (HasGlobalLightMap)
				{
					smethod_29(binaryWriter, DayLightMap);
					smethod_29(binaryWriter, NightLightMap);
				}
				smethod_30(binaryWriter, ModelExtraData);
			}
			int num = Math.Max(HullMeshes?.Count ?? 0, CollisionBrushes?.Count ?? 0);
			binaryWriter.Write(num);
			for (int j = 0; j < num; j++)
			{
				HullMesh hullMesh_ = ((HullMeshes == null || j >= HullMeshes.Count) ? new HullMesh() : HullMeshes[j]);
				smethod_31(binaryWriter, hullMesh_);
			}
			for (int k = 0; k < num; k++)
			{
				CollisionBrush collisionBrush_ = ((CollisionBrushes == null || k >= CollisionBrushes.Count) ? new CollisionBrush() : CollisionBrushes[k]);
				smethod_32(binaryWriter, collisionBrush_);
			}
			if (HasAdditionalExtent)
			{
				binaryWriter.Write(AdditionalExtent);
			}
			else if (RemainingData != null && RemainingData.Length != 0)
			{
				binaryWriter.Write(RemainingData);
			}
			FileLoaded = true;
			FileChanged = false;
		}
		finally
		{
			((IDisposable)binaryWriter).Dispose();
		}
	}

	private void method_1(BinaryWriter binaryWriter_0)
	{
		string s = (string.IsNullOrWhiteSpace(Header) ? Class16.smethod_0(1648918753) : Header);
		byte[] bytes = Encoding.ASCII.GetBytes(s);
		byte[] array = new byte[4];
		int num = Math.Min(4, bytes.Length);
		Array.Copy(bytes, array, num);
		if (num < 4)
		{
			byte[] bytes2 = Encoding.ASCII.GetBytes(Class16.smethod_0(1648918753));
			for (int i = num; i < 4; i++)
			{
				array[i] = bytes2[i];
			}
		}
		binaryWriter_0.Write(array);
	}

	private void method_2(BinaryWriter binaryWriter_0)
	{
		if (HasCollideOnlyFlag || Version == 2147483649u)
		{
			binaryWriter_0.Write(2147483649u);
			binaryWriter_0.Write(CollideOnlyFlag);
			binaryWriter_0.Write(LitModelVersion);
		}
		else
		{
			uint value = (Version = LitModelVersion);
			binaryWriter_0.Write(value);
		}
	}

	private static void smethod_0(BinaryWriter binaryWriter_0, LocationTransform locationTransform_1)
	{
		binaryWriter_0.Write(locationTransform_1.ScaleX);
		binaryWriter_0.Write(locationTransform_1.ScaleY);
		binaryWriter_0.Write(locationTransform_1.ScaleZ);
		binaryWriter_0.Write(locationTransform_1.DirectionX);
		binaryWriter_0.Write(locationTransform_1.DirectionY);
		binaryWriter_0.Write(locationTransform_1.DirectionZ);
		binaryWriter_0.Write(locationTransform_1.UpX);
		binaryWriter_0.Write(locationTransform_1.UpY);
		binaryWriter_0.Write(locationTransform_1.UpZ);
		binaryWriter_0.Write(locationTransform_1.PositionX);
		binaryWriter_0.Write(locationTransform_1.PositionY);
		binaryWriter_0.Write(locationTransform_1.PositionZ);
	}

	private void method_3(BinaryWriter binaryWriter_0, BmdMesh bmdMesh_0)
	{
		uint num = bmdMesh_0.MeshVersion;
		if (num < 268435458 || num > 268435462)
		{
			num = 268435462u;
		}
		binaryWriter_0.Write(num);
		smethod_28(binaryWriter_0, bmdMesh_0.Name, 64);
		smethod_28(binaryWriter_0, bmdMesh_0.TexturePath, 256);
		int num2 = bmdMesh_0.Vertices?.Count ?? 0;
		int num3 = bmdMesh_0.Faces?.Count ?? 0;
		binaryWriter_0.Write(num2);
		binaryWriter_0.Write(num3);
		if (num >= 268435462)
		{
			binaryWriter_0.Write(bmdMesh_0.ExtraColorsFlag);
		}
		bool flag = num <= 268435459;
		for (int i = 0; i < num2; i++)
		{
			BmdVertex bmdVertex = bmdMesh_0.Vertices[i];
			binaryWriter_0.Write(bmdVertex.Single_0);
			binaryWriter_0.Write(bmdVertex.Single_1);
			binaryWriter_0.Write(bmdVertex.Single_2);
			binaryWriter_0.Write(bmdVertex.Diffuse);
			if (flag)
			{
				binaryWriter_0.Write(bmdVertex.Specular);
			}
			binaryWriter_0.Write(bmdVertex.Single_3);
			binaryWriter_0.Write(bmdVertex.Single_4);
		}
		for (int j = 0; j < num3; j++)
		{
			FaceShort faceShort = bmdMesh_0.Faces[j];
			binaryWriter_0.Write(faceShort.Int16_0);
			binaryWriter_0.Write(faceShort.Int16_1);
			binaryWriter_0.Write(faceShort.Int16_2);
		}
		for (int k = 0; k < num2; k++)
		{
			Vector3Value vector3Value = smethod_36(bmdMesh_0.Normals, k);
			binaryWriter_0.Write(vector3Value.Single_0);
			binaryWriter_0.Write(vector3Value.Single_1);
			binaryWriter_0.Write(vector3Value.Single_2);
		}
		if (num >= 268435459)
		{
			smethod_22(binaryWriter_0, bmdMesh_0.DayColors, num2);
			smethod_22(binaryWriter_0, bmdMesh_0.NightColors, num2);
		}
		if (num >= 268435462 && bmdMesh_0.ExtraColorsFlag == 1)
		{
			smethod_22(binaryWriter_0, bmdMesh_0.DayColorsExtra, num2);
			smethod_22(binaryWriter_0, bmdMesh_0.NightColorsExtra, num2);
		}
		smethod_23(binaryWriter_0, bmdMesh_0.Aabb);
		if (num >= 268435461)
		{
			smethod_25(binaryWriter_0, bmdMesh_0.MaterialOld);
		}
	}

	private BmdMesh method_4(BinaryReader binaryReader_0)
	{
		BmdMesh bmdMesh = new BmdMesh();
		bmdMesh.IsNewFormat = true;
		bmdMesh.SupportLightMap = smethod_19(binaryReader_0, Class16.smethod_0(1648922563)) != 0;
		bmdMesh.UseLightMap = smethod_19(binaryReader_0, Class16.smethod_0(1648922585)) != 0;
		bmdMesh.Name = smethod_10(binaryReader_0, Class16.smethod_0(1648922273));
		bmdMesh.TexturePath = smethod_10(binaryReader_0, Class16.smethod_0(1648922288));
		int num = smethod_16(binaryReader_0, Class16.smethod_0(1648922306));
		int num2 = smethod_16(binaryReader_0, Class16.smethod_0(1648922328));
		smethod_21(num, 0, 2500000, Class16.smethod_0(1648922306));
		smethod_21(num2, 0, 2500000, Class16.smethod_0(1648922328));
		for (int i = 0; i < num; i++)
		{
			BmdVertex bmdVertex = new BmdVertex();
			bmdVertex.Single_0 = smethod_18(binaryReader_0, Class16.smethod_0(1648922382));
			bmdVertex.Single_1 = smethod_18(binaryReader_0, Class16.smethod_0(1648922396));
			bmdVertex.Single_2 = smethod_18(binaryReader_0, Class16.smethod_0(1648922402));
			bmdVertex.Diffuse = smethod_15(binaryReader_0, Class16.smethod_0(1648922416));
			bmdVertex.Specular = 0u;
			bmdVertex.HasSpecular = false;
			bmdVertex.Single_3 = smethod_18(binaryReader_0, Class16.smethod_0(1648922457));
			bmdVertex.Single_4 = smethod_18(binaryReader_0, Class16.smethod_0(1648922479));
			bmdMesh.Vertices.Add(bmdVertex);
		}
		for (int j = 0; j < num2; j++)
		{
			bmdMesh.Faces.Add(smethod_3(binaryReader_0));
		}
		for (int k = 0; k < num; k++)
		{
			bmdMesh.Normals.Add(smethod_4(binaryReader_0));
		}
		bmdMesh.HasFaceNormals = LitModelVersion >= 268436226;
		if (bmdMesh.HasFaceNormals)
		{
			for (int l = 0; l < num2; l++)
			{
				bmdMesh.FaceNormals.Add(smethod_3(binaryReader_0));
			}
		}
		bmdMesh.HasUnknownColorV304 = LitModelVersion >= 268436228;
		if (bmdMesh.HasUnknownColorV304)
		{
			bmdMesh.UnknownColorV304 = smethod_5(binaryReader_0);
		}
		bmdMesh.HasMaterialV2 = true;
		bmdMesh.MaterialV2 = smethod_8(binaryReader_0);
		if (bmdMesh.SupportLightMap)
		{
			for (int m = 0; m < num; m++)
			{
				bmdMesh.LightTexCoords.Add(smethod_6(binaryReader_0));
			}
		}
		if (!bmdMesh.SupportLightMap || !bmdMesh.UseLightMap)
		{
			smethod_9(binaryReader_0, num, bmdMesh.DayColors, Class16.smethod_0(1648922493));
			smethod_9(binaryReader_0, num, bmdMesh.NightColors, Class16.smethod_0(1648922509));
		}
		bmdMesh.Aabb = smethod_1(binaryReader_0);
		uint num3 = smethod_15(binaryReader_0, Class16.smethod_0(1648922603));
		if (num3 < 4)
		{
			throw new InvalidDataException(string.Format(Class16.smethod_0(1648921607), num3));
		}
		int num4 = checked((int)num3 - 4);
		bmdMesh.ExtraData = ((num4 > 0) ? smethod_14(binaryReader_0, num4, Class16.smethod_0(1648921634)) : Array.Empty<byte>());
		return bmdMesh;
	}

	private HullMesh method_5(BinaryReader binaryReader_0)
	{
		HullMesh hullMesh = new HullMesh();
		int num = smethod_16(binaryReader_0, Class16.smethod_0(1648921662));
		smethod_21(num, 0, 250000, Class16.smethod_0(1648921662));
		for (int i = 0; i < num; i++)
		{
			hullMesh.MeshIds.Add(smethod_16(binaryReader_0, Class16.smethod_0(1648921684)));
		}
		return hullMesh;
	}

	private CollisionBrush method_6(BinaryReader binaryReader_0)
	{
		CollisionBrush collisionBrush = new CollisionBrush();
		collisionBrush.Aabb = smethod_1(binaryReader_0);
		collisionBrush.Reserved = smethod_15(binaryReader_0, Class16.smethod_0(1648921701));
		int num = smethod_16(binaryReader_0, Class16.smethod_0(1648921722));
		smethod_21(num, 0, 250000, Class16.smethod_0(1648921722));
		for (int i = 0; i < num; i++)
		{
			CollisionSide collisionSide = new CollisionSide();
			collisionSide.Normal = smethod_4(binaryReader_0);
			collisionSide.Distance = smethod_18(binaryReader_0, Class16.smethod_0(1648921747));
			collisionSide.Bevel = smethod_19(binaryReader_0, Class16.smethod_0(1648921783));
			collisionBrush.Sides.Add(collisionSide);
		}
		return collisionBrush;
	}

	private static AabbValue smethod_1(BinaryReader binaryReader_0)
	{
		AabbValue aabbValue = new AabbValue();
		aabbValue.Center = smethod_4(binaryReader_0);
		aabbValue.Extents = smethod_4(binaryReader_0);
		aabbValue.Mins = smethod_4(binaryReader_0);
		aabbValue.Maxs = smethod_4(binaryReader_0);
		return aabbValue;
	}

	private static LocationTransform smethod_2(BinaryReader binaryReader_0)
	{
		LocationTransform locationTransform = new LocationTransform();
		locationTransform.ScaleX = smethod_18(binaryReader_0, Class16.smethod_0(1648921800));
		locationTransform.ScaleY = smethod_18(binaryReader_0, Class16.smethod_0(1648921821));
		locationTransform.ScaleZ = smethod_18(binaryReader_0, Class16.smethod_0(1648921826));
		locationTransform.DirectionX = smethod_18(binaryReader_0, Class16.smethod_0(1648921847));
		locationTransform.DirectionY = smethod_18(binaryReader_0, Class16.smethod_0(1648921856));
		locationTransform.DirectionZ = smethod_18(binaryReader_0, Class16.smethod_0(1648921873));
		locationTransform.UpX = smethod_18(binaryReader_0, Class16.smethod_0(1648921890));
		locationTransform.UpY = smethod_18(binaryReader_0, Class16.smethod_0(1648921908));
		locationTransform.UpZ = smethod_18(binaryReader_0, Class16.smethod_0(1648921918));
		locationTransform.PositionX = smethod_18(binaryReader_0, Class16.smethod_0(1648921920));
		locationTransform.PositionY = smethod_18(binaryReader_0, Class16.smethod_0(1648921936));
		locationTransform.PositionZ = smethod_18(binaryReader_0, Class16.smethod_0(1648921952));
		return locationTransform;
	}

	private static FaceShort smethod_3(BinaryReader binaryReader_0)
	{
		FaceShort faceShort = new FaceShort();
		faceShort.Int16_0 = smethod_17(binaryReader_0, Class16.smethod_0(1648921968));
		faceShort.Int16_1 = smethod_17(binaryReader_0, Class16.smethod_0(1648921988));
		faceShort.Int16_2 = smethod_17(binaryReader_0, Class16.smethod_0(1648921992));
		return faceShort;
	}

	private static Vector3Value smethod_4(BinaryReader binaryReader_0)
	{
		Vector3Value vector3Value = new Vector3Value();
		vector3Value.Single_0 = smethod_18(binaryReader_0, Class16.smethod_0(1648922012));
		vector3Value.Single_1 = smethod_18(binaryReader_0, Class16.smethod_0(1648922018));
		vector3Value.Single_2 = smethod_18(binaryReader_0, Class16.smethod_0(1648922032));
		return vector3Value;
	}

	private static ColorValue smethod_5(BinaryReader binaryReader_0)
	{
		ColorValue colorValue = new ColorValue();
		colorValue.Single_0 = smethod_18(binaryReader_0, Class16.smethod_0(1648922054));
		colorValue.Single_1 = smethod_18(binaryReader_0, Class16.smethod_0(1648922059));
		colorValue.Single_2 = smethod_18(binaryReader_0, Class16.smethod_0(1648922072));
		colorValue.Single_3 = smethod_18(binaryReader_0, Class16.smethod_0(1648922093));
		return colorValue;
	}

	private static LightMapCoord smethod_6(BinaryReader binaryReader_0)
	{
		LightMapCoord lightMapCoord = new LightMapCoord();
		lightMapCoord.Single_0 = smethod_18(binaryReader_0, Class16.smethod_0(1648922098));
		lightMapCoord.Single_1 = smethod_18(binaryReader_0, Class16.smethod_0(1648921090));
		return lightMapCoord;
	}

	private static MaterialOld smethod_7(BinaryReader binaryReader_0)
	{
		MaterialOld materialOld = new MaterialOld();
		materialOld.Diffuse = smethod_5(binaryReader_0);
		materialOld.Ambient = smethod_5(binaryReader_0);
		materialOld.Emissive = smethod_5(binaryReader_0);
		materialOld.Specular = smethod_5(binaryReader_0);
		materialOld.Power = smethod_18(binaryReader_0, Class16.smethod_0(1648921106));
		materialOld.TwoSided = smethod_19(binaryReader_0, Class16.smethod_0(1648921134));
		return materialOld;
	}

	private static MaterialV2 smethod_8(BinaryReader binaryReader_0)
	{
		MaterialV2 materialV = new MaterialV2();
		materialV.HeaderBytes = smethod_14(binaryReader_0, 11, Class16.smethod_0(1648921157));
		materialV.Ambient = smethod_5(binaryReader_0);
		materialV.Diffuse = smethod_5(binaryReader_0);
		materialV.Emissive = smethod_5(binaryReader_0);
		materialV.Specular = smethod_5(binaryReader_0);
		materialV.Power = smethod_18(binaryReader_0, Class16.smethod_0(1648921106));
		materialV.TwoSided = smethod_19(binaryReader_0, Class16.smethod_0(1648921134));
		return materialV;
	}

	private static void smethod_9(BinaryReader binaryReader_0, int int_0, List<uint> list_3, string string_3)
	{
		list_3.Clear();
		for (int i = 0; i < int_0; i++)
		{
			list_3.Add(smethod_15(binaryReader_0, string_3));
		}
	}

	private static string smethod_10(BinaryReader binaryReader_0, string string_3)
	{
		int num = smethod_16(binaryReader_0, string_3 + Class16.smethod_0(1648921170));
		smethod_21(num, 0, 1048576, string_3 + Class16.smethod_0(1648921170));
		if (num == 0)
		{
			return string.Empty;
		}
		byte[] byte_ = smethod_14(binaryReader_0, num, string_3);
		return smethod_12(byte_).Trim(default(char));
	}

	private static string smethod_11(byte[] byte_3)
	{
		if (byte_3 != null && byte_3.Length != 0)
		{
			int i;
			for (i = 0; i < byte_3.Length && byte_3[i] != 0; i++)
			{
			}
			return smethod_13(byte_3, i).Trim();
		}
		return string.Empty;
	}

	private static string smethod_12(byte[] byte_3)
	{
		return smethod_13(byte_3, (byte_3 != null) ? byte_3.Length : 0);
	}

	private static string smethod_13(byte[] byte_3, int int_0)
	{
		if (byte_3 != null && int_0 > 0)
		{
			int count = Math.Min(int_0, byte_3.Length);
			try
			{
				return Encoding.GetEncoding(Class16.smethod_0(1648921191)).GetString(byte_3, 0, count);
			}
			catch
			{
				return Encoding.Default.GetString(byte_3, 0, count);
			}
		}
		return string.Empty;
	}

	private static byte[] smethod_14(BinaryReader binaryReader_0, int int_0, string string_3)
	{
		if (int_0 < 0)
		{
			throw new InvalidDataException(string.Format(Class16.smethod_0(1648921204), string_3, int_0));
		}
		long num = binaryReader_0.BaseStream.Length - binaryReader_0.BaseStream.Position;
		if (num < int_0)
		{
			throw new EndOfStreamException(string.Format(Class16.smethod_0(1648921238), string_3, int_0, num));
		}
		byte[] array = binaryReader_0.ReadBytes(int_0);
		if (array.Length != int_0)
		{
			throw new EndOfStreamException(string.Format(Class16.smethod_0(1648921300), string_3, int_0, array.Length));
		}
		return array;
	}

	private static uint smethod_15(BinaryReader binaryReader_0, string string_3)
	{
		smethod_20(binaryReader_0, 4, string_3);
		return binaryReader_0.ReadUInt32();
	}

	private static int smethod_16(BinaryReader binaryReader_0, string string_3)
	{
		smethod_20(binaryReader_0, 4, string_3);
		return binaryReader_0.ReadInt32();
	}

	private static short smethod_17(BinaryReader binaryReader_0, string string_3)
	{
		smethod_20(binaryReader_0, 2, string_3);
		return binaryReader_0.ReadInt16();
	}

	private static float smethod_18(BinaryReader binaryReader_0, string string_3)
	{
		smethod_20(binaryReader_0, 4, string_3);
		return binaryReader_0.ReadSingle();
	}

	private static byte smethod_19(BinaryReader binaryReader_0, string string_3)
	{
		smethod_20(binaryReader_0, 1, string_3);
		return binaryReader_0.ReadByte();
	}

	private static void smethod_20(BinaryReader binaryReader_0, int int_0, string string_3)
	{
		long num = binaryReader_0.BaseStream.Length - binaryReader_0.BaseStream.Position;
		if (num < int_0)
		{
			throw new EndOfStreamException(string.Format(Class16.smethod_0(1648921238), string_3, int_0, num));
		}
	}

	private static void smethod_21(int int_0, int int_1, int int_2, string string_3)
	{
		if (int_0 < int_1 || int_0 > int_2)
		{
			throw new InvalidDataException(string.Format(Class16.smethod_0(1648921359), string_3, int_0, int_1, int_2));
		}
	}

	private void method_7(BinaryWriter binaryWriter_0, BmdMesh bmdMesh_0)
	{
		binaryWriter_0.Write(bmdMesh_0.SupportLightMap ? ((byte)1) : ((byte)0));
		binaryWriter_0.Write(bmdMesh_0.UseLightMap ? ((byte)1) : ((byte)0));
		smethod_29(binaryWriter_0, bmdMesh_0.Name);
		smethod_29(binaryWriter_0, bmdMesh_0.TexturePath);
		int num = bmdMesh_0.Vertices?.Count ?? 0;
		int num2 = bmdMesh_0.Faces?.Count ?? 0;
		binaryWriter_0.Write(num);
		binaryWriter_0.Write(num2);
		for (int i = 0; i < num; i++)
		{
			BmdVertex bmdVertex = bmdMesh_0.Vertices[i];
			binaryWriter_0.Write(bmdVertex.Single_0);
			binaryWriter_0.Write(bmdVertex.Single_1);
			binaryWriter_0.Write(bmdVertex.Single_2);
			binaryWriter_0.Write(bmdVertex.Diffuse);
			binaryWriter_0.Write(bmdVertex.Single_3);
			binaryWriter_0.Write(bmdVertex.Single_4);
		}
		for (int j = 0; j < num2; j++)
		{
			FaceShort faceShort = bmdMesh_0.Faces[j];
			binaryWriter_0.Write(faceShort.Int16_0);
			binaryWriter_0.Write(faceShort.Int16_1);
			binaryWriter_0.Write(faceShort.Int16_2);
		}
		for (int k = 0; k < num; k++)
		{
			Vector3Value vector3Value = smethod_36(bmdMesh_0.Normals, k);
			binaryWriter_0.Write(vector3Value.Single_0);
			binaryWriter_0.Write(vector3Value.Single_1);
			binaryWriter_0.Write(vector3Value.Single_2);
		}
		if (LitModelVersion >= 268436226)
		{
			for (int l = 0; l < num2; l++)
			{
				FaceShort faceShort2 = smethod_35(bmdMesh_0.FaceNormals, l);
				binaryWriter_0.Write(faceShort2.Int16_0);
				binaryWriter_0.Write(faceShort2.Int16_1);
				binaryWriter_0.Write(faceShort2.Int16_2);
			}
		}
		if (LitModelVersion >= 268436228)
		{
			smethod_27(binaryWriter_0, bmdMesh_0.UnknownColorV304);
		}
		smethod_26(binaryWriter_0, bmdMesh_0.MaterialV2);
		if (bmdMesh_0.SupportLightMap)
		{
			for (int m = 0; m < num; m++)
			{
				LightMapCoord lightMapCoord = smethod_37(bmdMesh_0.LightTexCoords, m);
				binaryWriter_0.Write(lightMapCoord.Single_0);
				binaryWriter_0.Write(lightMapCoord.Single_1);
			}
		}
		if (!bmdMesh_0.SupportLightMap || !bmdMesh_0.UseLightMap)
		{
			smethod_22(binaryWriter_0, bmdMesh_0.DayColors, num);
			smethod_22(binaryWriter_0, bmdMesh_0.NightColors, num);
		}
		smethod_23(binaryWriter_0, bmdMesh_0.Aabb);
		smethod_30(binaryWriter_0, bmdMesh_0.ExtraData);
	}

	private static void smethod_22(BinaryWriter binaryWriter_0, List<uint> list_3, int int_0)
	{
		for (int i = 0; i < int_0; i++)
		{
			binaryWriter_0.Write(smethod_34(list_3, i));
		}
	}

	private static void smethod_23(BinaryWriter binaryWriter_0, AabbValue aabbValue_0)
	{
		if (aabbValue_0 == null)
		{
			aabbValue_0 = new AabbValue();
		}
		smethod_24(binaryWriter_0, aabbValue_0.Center);
		smethod_24(binaryWriter_0, aabbValue_0.Extents);
		smethod_24(binaryWriter_0, aabbValue_0.Mins);
		smethod_24(binaryWriter_0, aabbValue_0.Maxs);
	}

	private static void smethod_24(BinaryWriter binaryWriter_0, Vector3Value vector3Value_0)
	{
		if (vector3Value_0 == null)
		{
			vector3Value_0 = new Vector3Value();
		}
		binaryWriter_0.Write(vector3Value_0.Single_0);
		binaryWriter_0.Write(vector3Value_0.Single_1);
		binaryWriter_0.Write(vector3Value_0.Single_2);
	}

	private static void smethod_25(BinaryWriter binaryWriter_0, MaterialOld materialOld_0)
	{
		if (materialOld_0 == null)
		{
			materialOld_0 = new MaterialOld();
		}
		smethod_27(binaryWriter_0, materialOld_0.Diffuse);
		smethod_27(binaryWriter_0, materialOld_0.Ambient);
		smethod_27(binaryWriter_0, materialOld_0.Emissive);
		smethod_27(binaryWriter_0, materialOld_0.Specular);
		binaryWriter_0.Write(materialOld_0.Power);
		binaryWriter_0.Write(materialOld_0.TwoSided);
	}

	private static void smethod_26(BinaryWriter binaryWriter_0, MaterialV2 materialV2_0)
	{
		if (materialV2_0 == null)
		{
			materialV2_0 = new MaterialV2();
		}
		byte[] array = materialV2_0.HeaderBytes ?? Array.Empty<byte>();
		byte[] array2 = new byte[11];
		Array.Copy(array, array2, Math.Min(array.Length, array2.Length));
		binaryWriter_0.Write(array2);
		smethod_27(binaryWriter_0, materialV2_0.Ambient);
		smethod_27(binaryWriter_0, materialV2_0.Diffuse);
		smethod_27(binaryWriter_0, materialV2_0.Emissive);
		smethod_27(binaryWriter_0, materialV2_0.Specular);
		binaryWriter_0.Write(materialV2_0.Power);
		binaryWriter_0.Write(materialV2_0.TwoSided);
	}

	private static void smethod_27(BinaryWriter binaryWriter_0, ColorValue colorValue_0)
	{
		if (colorValue_0 == null)
		{
			colorValue_0 = new ColorValue();
		}
		binaryWriter_0.Write(colorValue_0.Single_0);
		binaryWriter_0.Write(colorValue_0.Single_1);
		binaryWriter_0.Write(colorValue_0.Single_2);
		binaryWriter_0.Write(colorValue_0.Single_3);
	}

	private static void smethod_28(BinaryWriter binaryWriter_0, string string_3, int int_0)
	{
		byte[] array = smethod_33(string_3);
		byte[] array2 = new byte[int_0];
		int length = Math.Min(int_0, array.Length);
		Array.Copy(array, array2, length);
		binaryWriter_0.Write(array2);
	}

	private static void smethod_29(BinaryWriter binaryWriter_0, string string_3)
	{
		byte[] array = smethod_33(string_3);
		binaryWriter_0.Write(array.Length);
		if (array.Length != 0)
		{
			binaryWriter_0.Write(array);
		}
	}

	private static void smethod_30(BinaryWriter binaryWriter_0, byte[] byte_3)
	{
		if (byte_3 == null)
		{
			byte_3 = Array.Empty<byte>();
		}
		int value = byte_3.Length + 4;
		binaryWriter_0.Write(value);
		if (byte_3.Length != 0)
		{
			binaryWriter_0.Write(byte_3);
		}
	}

	private static void smethod_31(BinaryWriter binaryWriter_0, HullMesh hullMesh_0)
	{
		if (hullMesh_0 == null)
		{
			hullMesh_0 = new HullMesh();
		}
		int num = hullMesh_0.MeshIds?.Count ?? 0;
		binaryWriter_0.Write(num);
		for (int i = 0; i < num; i++)
		{
			binaryWriter_0.Write(hullMesh_0.MeshIds[i]);
		}
	}

	private static void smethod_32(BinaryWriter binaryWriter_0, CollisionBrush collisionBrush_0)
	{
		if (collisionBrush_0 == null)
		{
			collisionBrush_0 = new CollisionBrush();
		}
		smethod_23(binaryWriter_0, collisionBrush_0.Aabb);
		binaryWriter_0.Write(collisionBrush_0.Reserved);
		int num = collisionBrush_0.Sides?.Count ?? 0;
		binaryWriter_0.Write(num);
		for (int i = 0; i < num; i++)
		{
			CollisionSide collisionSide = collisionBrush_0.Sides[i] ?? new CollisionSide();
			smethod_24(binaryWriter_0, collisionSide.Normal);
			binaryWriter_0.Write(collisionSide.Distance);
			binaryWriter_0.Write(collisionSide.Bevel);
		}
	}

	private static byte[] smethod_33(string string_3)
	{
		if (string.IsNullOrEmpty(string_3))
		{
			return Array.Empty<byte>();
		}
		try
		{
			return Encoding.GetEncoding(Class16.smethod_0(1648921191)).GetBytes(string_3);
		}
		catch
		{
			return Encoding.Default.GetBytes(string_3);
		}
	}

	private static uint smethod_34(List<uint> list_3, int int_0)
	{
		if (list_3 != null && int_0 >= 0 && int_0 < list_3.Count)
		{
			return list_3[int_0];
		}
		return 0u;
	}

	private static FaceShort smethod_35(List<FaceShort> list_3, int int_0)
	{
		if (list_3 != null && int_0 >= 0 && int_0 < list_3.Count && list_3[int_0] != null)
		{
			return list_3[int_0];
		}
		return new FaceShort();
	}

	private static Vector3Value smethod_36(List<Vector3Value> list_3, int int_0)
	{
		if (list_3 != null && int_0 >= 0 && int_0 < list_3.Count && list_3[int_0] != null)
		{
			return list_3[int_0];
		}
		return new Vector3Value();
	}

	private static LightMapCoord smethod_37(List<LightMapCoord> list_3, int int_0)
	{
		if (list_3 != null && int_0 >= 0 && int_0 < list_3.Count && list_3[int_0] != null)
		{
			return list_3[int_0];
		}
		return new LightMapCoord();
	}

	public BMD CreateUndoClone()
	{
		BMD bMD = new BMD
		{
			fn = fn,
			FileLoaded = FileLoaded,
			FileChanged = FileChanged,
			Header = Header,
			Version = Version,
			HasCollideOnlyFlag = HasCollideOnlyFlag,
			CollideOnlyFlag = CollideOnlyFlag,
			LitModelVersion = LitModelVersion,
			Location = smethod_39(Location),
			HasUnknownDword = HasUnknownDword,
			UnknownDword = UnknownDword,
			HasGlobalLightMap = HasGlobalLightMap,
			HasSharedData = HasSharedData,
			DayLightMap = DayLightMap,
			NightLightMap = NightLightMap,
			HasAdditionalExtent = HasAdditionalExtent,
			AdditionalExtent = AdditionalExtent,
			ModelExtraData = smethod_38(ModelExtraData),
			RemainingData = smethod_38(RemainingData)
		};
		foreach (BmdMesh mesh in Meshes)
		{
			bMD.Meshes.Add(smethod_48(mesh));
		}
		foreach (HullMesh hullMesh in HullMeshes)
		{
			bMD.HullMeshes.Add(smethod_49(hullMesh));
		}
		foreach (CollisionBrush collisionBrush in CollisionBrushes)
		{
			bMD.CollisionBrushes.Add(smethod_51(collisionBrush));
		}
		return bMD;
	}

	private static byte[] smethod_38(byte[] byte_3)
	{
		if (byte_3 != null)
		{
			return (byte[])byte_3.Clone();
		}
		return Array.Empty<byte>();
	}

	private static LocationTransform smethod_39(LocationTransform locationTransform_1)
	{
		if (locationTransform_1 == null)
		{
			locationTransform_1 = new LocationTransform();
		}
		return new LocationTransform
		{
			ScaleX = locationTransform_1.ScaleX,
			ScaleY = locationTransform_1.ScaleY,
			ScaleZ = locationTransform_1.ScaleZ,
			DirectionX = locationTransform_1.DirectionX,
			DirectionY = locationTransform_1.DirectionY,
			DirectionZ = locationTransform_1.DirectionZ,
			UpX = locationTransform_1.UpX,
			UpY = locationTransform_1.UpY,
			UpZ = locationTransform_1.UpZ,
			PositionX = locationTransform_1.PositionX,
			PositionY = locationTransform_1.PositionY,
			PositionZ = locationTransform_1.PositionZ
		};
	}

	private static Vector3Value smethod_40(Vector3Value vector3Value_0)
	{
		if (vector3Value_0 == null)
		{
			vector3Value_0 = new Vector3Value();
		}
		return new Vector3Value
		{
			Single_0 = vector3Value_0.Single_0,
			Single_1 = vector3Value_0.Single_1,
			Single_2 = vector3Value_0.Single_2
		};
	}

	private static AabbValue smethod_41(AabbValue aabbValue_0)
	{
		if (aabbValue_0 == null)
		{
			aabbValue_0 = new AabbValue();
		}
		return new AabbValue
		{
			Center = smethod_40(aabbValue_0.Center),
			Extents = smethod_40(aabbValue_0.Extents),
			Mins = smethod_40(aabbValue_0.Mins),
			Maxs = smethod_40(aabbValue_0.Maxs)
		};
	}

	private static ColorValue smethod_42(ColorValue colorValue_0)
	{
		if (colorValue_0 == null)
		{
			colorValue_0 = new ColorValue();
		}
		return new ColorValue
		{
			Single_0 = colorValue_0.Single_0,
			Single_1 = colorValue_0.Single_1,
			Single_2 = colorValue_0.Single_2,
			Single_3 = colorValue_0.Single_3
		};
	}

	private static MaterialOld smethod_43(MaterialOld materialOld_0)
	{
		if (materialOld_0 == null)
		{
			materialOld_0 = new MaterialOld();
		}
		return new MaterialOld
		{
			Diffuse = smethod_42(materialOld_0.Diffuse),
			Ambient = smethod_42(materialOld_0.Ambient),
			Emissive = smethod_42(materialOld_0.Emissive),
			Specular = smethod_42(materialOld_0.Specular),
			Power = materialOld_0.Power,
			TwoSided = materialOld_0.TwoSided
		};
	}

	private static MaterialV2 smethod_44(MaterialV2 materialV2_0)
	{
		if (materialV2_0 == null)
		{
			materialV2_0 = new MaterialV2();
		}
		return new MaterialV2
		{
			HeaderBytes = smethod_38(materialV2_0.HeaderBytes),
			Ambient = smethod_42(materialV2_0.Ambient),
			Diffuse = smethod_42(materialV2_0.Diffuse),
			Emissive = smethod_42(materialV2_0.Emissive),
			Specular = smethod_42(materialV2_0.Specular),
			Power = materialV2_0.Power,
			TwoSided = materialV2_0.TwoSided
		};
	}

	private static BmdVertex smethod_45(BmdVertex bmdVertex_0)
	{
		if (bmdVertex_0 == null)
		{
			bmdVertex_0 = new BmdVertex();
		}
		return new BmdVertex
		{
			Single_0 = bmdVertex_0.Single_0,
			Single_1 = bmdVertex_0.Single_1,
			Single_2 = bmdVertex_0.Single_2,
			Diffuse = bmdVertex_0.Diffuse,
			Specular = bmdVertex_0.Specular,
			Single_3 = bmdVertex_0.Single_3,
			Single_4 = bmdVertex_0.Single_4,
			HasSpecular = bmdVertex_0.HasSpecular
		};
	}

	private static FaceShort smethod_46(FaceShort faceShort_0)
	{
		if (faceShort_0 == null)
		{
			faceShort_0 = new FaceShort();
		}
		return new FaceShort
		{
			Int16_0 = faceShort_0.Int16_0,
			Int16_1 = faceShort_0.Int16_1,
			Int16_2 = faceShort_0.Int16_2
		};
	}

	private static LightMapCoord smethod_47(LightMapCoord lightMapCoord_0)
	{
		if (lightMapCoord_0 == null)
		{
			lightMapCoord_0 = new LightMapCoord();
		}
		return new LightMapCoord
		{
			Single_0 = lightMapCoord_0.Single_0,
			Single_1 = lightMapCoord_0.Single_1
		};
	}

	private static BmdMesh smethod_48(BmdMesh bmdMesh_0)
	{
		if (bmdMesh_0 == null)
		{
			bmdMesh_0 = new BmdMesh();
		}
		BmdMesh bmdMesh = new BmdMesh
		{
			IsNewFormat = bmdMesh_0.IsNewFormat,
			MeshVersion = bmdMesh_0.MeshVersion,
			SupportLightMap = bmdMesh_0.SupportLightMap,
			UseLightMap = bmdMesh_0.UseLightMap,
			Name = bmdMesh_0.Name,
			TexturePath = bmdMesh_0.TexturePath,
			HasExtraColorsFlag = bmdMesh_0.HasExtraColorsFlag,
			ExtraColorsFlag = bmdMesh_0.ExtraColorsFlag,
			HasFaceNormals = bmdMesh_0.HasFaceNormals,
			HasUnknownColorV304 = bmdMesh_0.HasUnknownColorV304,
			HasMaterialOld = bmdMesh_0.HasMaterialOld,
			HasMaterialV2 = bmdMesh_0.HasMaterialV2,
			Aabb = smethod_41(bmdMesh_0.Aabb),
			MaterialOld = smethod_43(bmdMesh_0.MaterialOld),
			MaterialV2 = smethod_44(bmdMesh_0.MaterialV2),
			UnknownColorV304 = smethod_42(bmdMesh_0.UnknownColorV304),
			ExtraData = smethod_38(bmdMesh_0.ExtraData)
		};
		foreach (BmdVertex vertex in bmdMesh_0.Vertices)
		{
			bmdMesh.Vertices.Add(smethod_45(vertex));
		}
		foreach (FaceShort face in bmdMesh_0.Faces)
		{
			bmdMesh.Faces.Add(smethod_46(face));
		}
		foreach (Vector3Value normal in bmdMesh_0.Normals)
		{
			bmdMesh.Normals.Add(smethod_40(normal));
		}
		foreach (FaceShort faceNormal in bmdMesh_0.FaceNormals)
		{
			bmdMesh.FaceNormals.Add(smethod_46(faceNormal));
		}
		bmdMesh.DayColors.AddRange(bmdMesh_0.DayColors);
		bmdMesh.NightColors.AddRange(bmdMesh_0.NightColors);
		bmdMesh.DayColorsExtra.AddRange(bmdMesh_0.DayColorsExtra);
		bmdMesh.NightColorsExtra.AddRange(bmdMesh_0.NightColorsExtra);
		foreach (LightMapCoord lightTexCoord in bmdMesh_0.LightTexCoords)
		{
			bmdMesh.LightTexCoords.Add(smethod_47(lightTexCoord));
		}
		return bmdMesh;
	}

	private static HullMesh smethod_49(HullMesh hullMesh_0)
	{
		if (hullMesh_0 == null)
		{
			hullMesh_0 = new HullMesh();
		}
		HullMesh hullMesh = new HullMesh();
		hullMesh.MeshIds.AddRange(hullMesh_0.MeshIds);
		return hullMesh;
	}

	private static CollisionSide smethod_50(CollisionSide collisionSide_0)
	{
		if (collisionSide_0 == null)
		{
			collisionSide_0 = new CollisionSide();
		}
		return new CollisionSide
		{
			Normal = smethod_40(collisionSide_0.Normal),
			Distance = collisionSide_0.Distance,
			Bevel = collisionSide_0.Bevel
		};
	}

	private static CollisionBrush smethod_51(CollisionBrush collisionBrush_0)
	{
		if (collisionBrush_0 == null)
		{
			collisionBrush_0 = new CollisionBrush();
		}
		CollisionBrush collisionBrush = new CollisionBrush
		{
			Aabb = smethod_41(collisionBrush_0.Aabb),
			Reserved = collisionBrush_0.Reserved
		};
		foreach (CollisionSide side in collisionBrush_0.Sides)
		{
			collisionBrush.Sides.Add(smethod_50(side));
		}
		return collisionBrush;
	}
}
