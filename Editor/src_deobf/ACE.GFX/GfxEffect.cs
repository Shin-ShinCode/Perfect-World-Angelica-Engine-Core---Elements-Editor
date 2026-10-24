using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using ACE.Models.ECM;

namespace ACE.GFX;

public class GfxEffect
{
	private sealed class Class139 : IEnumerable, IEnumerable<string>, IEnumerator<string>, IEnumerator, IDisposable
	{
		private int int_0;

		private string string_0;

		private int int_1;

		public GfxEffect gfxEffect_0;

		private List<GfxElement>.Enumerator enumerator_0;

		string IEnumerator<string>.Current
		{
			[DebuggerHidden]
			get
			{
				return string_0;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return string_0;
			}
		}

		[DebuggerHidden]
		public Class139(int int_2)
		{
			int_0 = int_2;
			int_1 = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = int_0;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					method_0();
				}
			}
			enumerator_0 = default(List<GfxElement>.Enumerator);
			int_0 = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = int_0;
				GfxEffect gfxEffect = gfxEffect_0;
				switch (num)
				{
				default:
					return false;
				case 1:
					int_0 = -3;
					break;
				case 0:
					int_0 = -1;
					enumerator_0 = gfxEffect.Elements.GetEnumerator();
					int_0 = -3;
					break;
				}
				GfxElement current;
				do
				{
					if (enumerator_0.MoveNext())
					{
						current = enumerator_0.Current;
						continue;
					}
					method_0();
					enumerator_0 = default(List<GfxElement>.Enumerator);
					return false;
				}
				while (string.IsNullOrEmpty(current.TexturePath));
				string_0 = current.TexturePath;
				int_0 = 1;
				return true;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void method_0()
		{
			int_0 = -1;
			((IDisposable)enumerator_0/*cast due to constrained. prefix*/).Dispose();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			Class139 @class;
			if (int_0 == -2 && int_1 == Environment.CurrentManagedThreadId)
			{
				int_0 = 0;
				@class = this;
			}
			else
			{
				@class = new Class139(0);
				@class.gfxEffect_0 = gfxEffect_0;
			}
			return @class;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<string>)this).GetEnumerator();
		}
	}

	private sealed class Class140 : IEnumerable, IEnumerable<string>, IEnumerator<string>, IEnumerator, IDisposable
	{
		private int int_0;

		private string string_0;

		private int int_1;

		public GfxEffect gfxEffect_0;

		private List<GfxElement>.Enumerator enumerator_0;

		string IEnumerator<string>.Current
		{
			[DebuggerHidden]
			get
			{
				return string_0;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return string_0;
			}
		}

		[DebuggerHidden]
		public Class140(int int_2)
		{
			int_0 = int_2;
			int_1 = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = int_0;
			if (num == -3 || (uint)(num - 1) <= 1u)
			{
				try
				{
				}
				finally
				{
					method_0();
				}
			}
			enumerator_0 = default(List<GfxElement>.Enumerator);
			int_0 = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = int_0;
				GfxEffect gfxEffect = gfxEffect_0;
				switch (num)
				{
				default:
					return false;
				case 0:
					int_0 = -1;
					enumerator_0 = gfxEffect.Elements.GetEnumerator();
					int_0 = -3;
					break;
				case 1:
					int_0 = -3;
					break;
				case 2:
					int_0 = -3;
					break;
				}
				GfxECModelElement gfxECModelElement;
				do
				{
					if (enumerator_0.MoveNext())
					{
						GfxElement current = enumerator_0.Current;
						if (!(current is GfxModelElement gfxModelElement) || string.IsNullOrEmpty(gfxModelElement.ModelFile))
						{
							gfxECModelElement = current as GfxECModelElement;
							continue;
						}
						string_0 = gfxModelElement.ModelFile;
						int_0 = 1;
						return true;
					}
					method_0();
					enumerator_0 = default(List<GfxElement>.Enumerator);
					return false;
				}
				while (gfxECModelElement == null || string.IsNullOrEmpty(gfxECModelElement.ECModelFile));
				string_0 = gfxECModelElement.ECModelFile;
				int_0 = 2;
				return true;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void method_0()
		{
			int_0 = -1;
			((IDisposable)enumerator_0/*cast due to constrained. prefix*/).Dispose();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			Class140 @class;
			if (int_0 == -2 && int_1 == Environment.CurrentManagedThreadId)
			{
				int_0 = 0;
				@class = this;
			}
			else
			{
				@class = new Class140(0);
				@class.gfxEffect_0 = gfxEffect_0;
			}
			return @class;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<string>)this).GetEnumerator();
		}
	}

	private sealed class Class141 : IEnumerable, IEnumerable<string>, IEnumerator<string>, IEnumerator, IDisposable
	{
		private int int_0;

		private string string_0;

		private int int_1;

		public GfxEffect gfxEffect_0;

		private List<GfxElement>.Enumerator enumerator_0;

		string IEnumerator<string>.Current
		{
			[DebuggerHidden]
			get
			{
				return string_0;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return string_0;
			}
		}

		[DebuggerHidden]
		public Class141(int int_2)
		{
			int_0 = int_2;
			int_1 = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = int_0;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					method_0();
				}
			}
			enumerator_0 = default(List<GfxElement>.Enumerator);
			int_0 = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = int_0;
				GfxEffect gfxEffect = gfxEffect_0;
				switch (num)
				{
				default:
					return false;
				case 1:
					int_0 = -3;
					break;
				case 0:
					int_0 = -1;
					enumerator_0 = gfxEffect.Elements.GetEnumerator();
					int_0 = -3;
					break;
				}
				GfxContainerElement gfxContainerElement;
				do
				{
					if (enumerator_0.MoveNext())
					{
						GfxElement current = enumerator_0.Current;
						gfxContainerElement = current as GfxContainerElement;
						continue;
					}
					method_0();
					enumerator_0 = default(List<GfxElement>.Enumerator);
					return false;
				}
				while (gfxContainerElement == null || string.IsNullOrEmpty(gfxContainerElement.GfxFile));
				string_0 = gfxContainerElement.GfxFile;
				int_0 = 1;
				return true;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void method_0()
		{
			int_0 = -1;
			((IDisposable)enumerator_0/*cast due to constrained. prefix*/).Dispose();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			Class141 @class;
			if (int_0 == -2 && int_1 == Environment.CurrentManagedThreadId)
			{
				int_0 = 0;
				@class = this;
			}
			else
			{
				@class = new Class141(0);
				@class.gfxEffect_0 = gfxEffect_0;
			}
			return @class;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<string>)this).GetEnumerator();
		}
	}

	private sealed class Class142
	{
		public GfxElement gfxElement_0;

		internal bool method_0(GfxElement gfxElement_1)
		{
			return string.Equals(gfxElement_1.Name, gfxElement_0.BindElementName, StringComparison.OrdinalIgnoreCase);
		}
	}

	public const uint GFX_CUR_VERSION = 124u;

	private uint uint_0;

	private float float_0 = 1f;

	private float float_1 = 1f;

	private float float_2 = 1f;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private float float_3;

	private float float_4;

	public Vector3f AABBMins;

	public Vector3f AABBMaxs;

	private bool bool_3;

	private bool bool_4;

	private int int_0;

	private KPController kpcontroller_0;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private uint uint_1;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private List<GfxElement> list_0 = new List<GfxElement>();

	private float float_5 = 1f;

	private float float_6 = 1f;

	private float float_7 = 1f;

	private GfxState gfxState_0;

	private string string_0 = string.Empty;

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

	public float DefScale
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

	public float DefPlaySpeed
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

	public float DefAlpha
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

	public bool UseRaytrace
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

	public bool FaceToViewer
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

	public bool FadeByDist
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

	public float FadeStart
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

	public float FadeEnd
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

	public bool UseAABB
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

	public bool AccurateAABB
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

	public int ShakeType
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

	public KPController ShakeNoise
	{
		[CompilerGenerated]
		get
		{
			return kpcontroller_0;
		}
		[CompilerGenerated]
		set
		{
			kpcontroller_0 = value;
		}
	}

	public bool NoChangeDir
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

	public bool Is2DRender
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

	public bool Is2DBackLayer
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

	public uint SkipTime
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

	public bool IsAngelica3
	{
		[CompilerGenerated]
		get
		{
			return bool_8;
		}
		[CompilerGenerated]
		set
		{
			bool_8 = value;
		}
	}

	public bool MatchGround
	{
		[CompilerGenerated]
		get
		{
			return bool_9;
		}
		[CompilerGenerated]
		set
		{
			bool_9 = value;
		}
	}

	public bool PhysExists
	{
		[CompilerGenerated]
		get
		{
			return bool_10;
		}
		[CompilerGenerated]
		set
		{
			bool_10 = value;
		}
	}

	public List<GfxElement> Elements
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	public float PlaySpeed
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

	public float Scale
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

	public float Alpha
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

	public GfxState State
	{
		[CompilerGenerated]
		get
		{
			return gfxState_0;
		}
		[CompilerGenerated]
		set
		{
			gfxState_0 = value;
		}
	}

	public string FilePath
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

	public static GfxEffect LoadFromFile(string filePath)
	{
		if (!File.Exists(filePath))
		{
			return null;
		}
		try
		{
			string content = File.ReadAllText(filePath);
			return LoadFromContent(content, filePath);
		}
		catch
		{
			return null;
		}
	}

	public static GfxEffect LoadFromContent(string content, string filePath = "")
	{
		if (string.IsNullOrWhiteSpace(content))
		{
			return null;
		}
		try
		{
			GfxFileReader gfxFileReader_ = new GfxFileReader(content);
			GfxEffect gfxEffect = new GfxEffect
			{
				FilePath = filePath
			};
			gfxEffect.Load(gfxFileReader_);
			return gfxEffect;
		}
		catch
		{
			return null;
		}
	}

	public void Load(GfxFileReader gfxFileReader_0)
	{
		Version = (uint)gfxFileReader_0.ReadInt();
		if (Version >= 89)
		{
			IsAngelica3 = gfxFileReader_0.ReadBool();
			if (IsAngelica3)
			{
				return;
			}
		}
		if (Version >= 16)
		{
			DefScale = gfxFileReader_0.ReadFloat();
		}
		if (Version >= 17)
		{
			DefPlaySpeed = gfxFileReader_0.ReadFloat();
		}
		if (Version >= 18)
		{
			DefAlpha = gfxFileReader_0.ReadFloat();
		}
		if (Version >= 23)
		{
			UseRaytrace = gfxFileReader_0.ReadBool();
		}
		if (Version >= 38)
		{
			FaceToViewer = gfxFileReader_0.ReadBool();
		}
		if (Version >= 27)
		{
			FadeByDist = gfxFileReader_0.ReadBool();
			FadeStart = gfxFileReader_0.ReadFloat();
			FadeEnd = gfxFileReader_0.ReadFloat();
		}
		if (Version >= 25)
		{
			(float x, float y, float z) tuple = gfxFileReader_0.ReadVector3();
			float item = tuple.x;
			float item2 = tuple.y;
			float item3 = tuple.z;
			AABBMins = new Vector3f(item, item2, item3);
			(float x, float y, float z) tuple2 = gfxFileReader_0.ReadVector3();
			float item4 = tuple2.x;
			float item5 = tuple2.y;
			float item6 = tuple2.z;
			AABBMaxs = new Vector3f(item4, item5, item6);
		}
		if (Version >= 53)
		{
			UseAABB = gfxFileReader_0.ReadBool();
		}
		if (Version >= 84)
		{
			AccurateAABB = gfxFileReader_0.ReadBool();
		}
		if (Version >= 24)
		{
			ShakeType = gfxFileReader_0.ReadInt();
			if (ShakeType != 0)
			{
				ShakeNoise = KPController.LoadFromFile(gfxFileReader_0, Version);
				if (Version >= 90)
				{
					gfxFileReader_0.ReadInt();
					gfxFileReader_0.ReadInt();
					if (Version >= 97)
					{
						gfxFileReader_0.ReadLine();
						if (Version >= 98)
						{
							gfxFileReader_0.ReadFloat();
						}
						if (Version >= 124)
						{
							gfxFileReader_0.ReadFloat();
						}
					}
				}
			}
		}
		if (Version >= 82)
		{
			gfxFileReader_0.ReadInt();
		}
		if (Version >= 46)
		{
			NoChangeDir = gfxFileReader_0.ReadBool();
		}
		if (Version >= 50)
		{
			Is2DRender = gfxFileReader_0.ReadBool();
			Is2DBackLayer = gfxFileReader_0.ReadBool();
		}
		if (Version >= 112)
		{
			SkipTime = (uint)gfxFileReader_0.ReadInt();
		}
		if (Version >= 63)
		{
			PhysExists = gfxFileReader_0.ReadBool();
		}
		int num = gfxFileReader_0.ReadInt();
		for (int i = 0; i < num; i++)
		{
			GfxElement gfxElement = GfxElement.LoadFromFile(gfxFileReader_0, Version);
			if (gfxElement != null)
			{
				if (gfxElement.UseGroundNormal || gfxElement.UseGroundHeight)
				{
					MatchGround = true;
				}
				Elements.Add(gfxElement);
			}
		}
		PlaySpeed = DefPlaySpeed;
		Scale = DefScale;
		Alpha = DefAlpha;
		method_0();
	}

	private void method_0()
	{
		using List<GfxElement>.Enumerator enumerator = Elements.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class142 @class = new Class142();
			@class.gfxElement_0 = enumerator.Current;
			if (!string.IsNullOrEmpty(@class.gfxElement_0.BindElementName))
			{
				@class.gfxElement_0.BindTarget = Elements.FirstOrDefault(@class.method_0);
			}
		}
	}

	public IEnumerable<string> GetTexturePaths()
	{
		return new Class139(-2)
		{
			gfxEffect_0 = this
		};
	}

	public IEnumerable<string> GetSubGfxPaths()
	{
		return new Class141(-2)
		{
			gfxEffect_0 = this
		};
	}

	public IEnumerable<string> GetModelPaths()
	{
		return new Class140(-2)
		{
			gfxEffect_0 = this
		};
	}
}
