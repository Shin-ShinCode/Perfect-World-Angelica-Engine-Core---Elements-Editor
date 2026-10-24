using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ACE.Models.ECM;
using SharpDX;
using SharpDX.Direct3D9;

namespace ACE.GFX;

public class GfxRenderer : IDisposable
{
	private struct Struct58(Vector3 vector3_1, int int_2, float float_2, float float_3)
	{
		public Vector3 vector3_0 = vector3_1;

		public int int_0 = int_2;

		public float float_0 = float_2;

		public float float_1 = float_3;

		public static readonly int int_1 = Marshal.SizeOf<Struct58>();
	}

	public class GfxEffectInstance
	{
		private GfxEffect gfxEffect_0;

		private Vector3 vector3_0 = Vector3.Zero;

		private Matrix matrix_0 = Matrix.Identity;

		private float float_0 = 1f;

		private float float_1 = 1f;

		private float float_2;

		private bool bool_0 = true;

		private List<ParticleState> list_0;

		public GfxEffect Effect
		{
			[CompilerGenerated]
			get
			{
				return gfxEffect_0;
			}
			[CompilerGenerated]
			set
			{
				gfxEffect_0 = value;
			}
		}

		public Vector3 Position
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return vector3_0;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				vector3_0 = value;
			}
		}

		public Matrix Transform
		{
			[CompilerGenerated]
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return matrix_0;
			}
			[CompilerGenerated]
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				matrix_0 = value;
			}
		}

		public float Scale
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

		public float Alpha
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

		public float Time
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

		public bool IsPlaying
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

		public List<ParticleState> Particles
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
	}

	public struct ParticleState
	{
		public Vector3 Position;

		public Vector3 Velocity;

		public float Life;

		public float MaxLife;

		public float Scale;

		public float Rotation;

		public int Color;
	}

	private Device device_0;

	private VertexBuffer vertexBuffer_0;

	private VertexDeclaration vertexDeclaration_0;

	private readonly Dictionary<string, Texture> dictionary_0 = new Dictionary<string, Texture>(StringComparer.OrdinalIgnoreCase);

	private readonly List<GfxEffectInstance> list_0 = new List<GfxEffectInstance>();

	private float float_0;

	private DateTime dateTime_0 = DateTime.UtcNow;

	private static readonly Random random_0 = new Random();

	private IndexBuffer indexBuffer_0;

	private static readonly VertexElement[] vertexElement_0 = (VertexElement[])(object)new VertexElement[4]
	{
		new VertexElement((short)0, (short)0, (DeclarationType)2, (DeclarationMethod)0, (DeclarationUsage)0, (byte)0),
		new VertexElement((short)0, (short)12, (DeclarationType)4, (DeclarationMethod)0, (DeclarationUsage)10, (byte)0),
		new VertexElement((short)0, (short)16, (DeclarationType)1, (DeclarationMethod)0, (DeclarationUsage)5, (byte)0),
		VertexElement.VertexDeclarationEnd
	};

	private bool bool_0;

	private bool bool_1;

	private int int_0;

	private int int_1;

	private int int_2;

	public GfxRenderer(Device device)
	{
		device_0 = device;
		method_0();
	}

	private void method_0()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		vertexDeclaration_0 = new VertexDeclaration(device_0, vertexElement_0);
		vertexBuffer_0 = new VertexBuffer(device_0, 196608, (Usage)520, (VertexFormat)0, (Pool)0);
		indexBuffer_0 = new IndexBuffer(device_0, 24576, (Usage)8, (Pool)0, true);
		DataStream val = indexBuffer_0.Lock(0, 0, (LockFlags)0);
		try
		{
			for (int i = 0; i < 2048; i++)
			{
				int num = i * 4;
				val.Write<short>((short)num);
				val.Write<short>((short)(num + 1));
				val.Write<short>((short)(num + 2));
				val.Write<short>((short)(num + 2));
				val.Write<short>((short)(num + 3));
				val.Write<short>((short)num);
			}
		}
		finally
		{
			((Stream)(object)val).Dispose();
			indexBuffer_0.Unlock();
		}
	}

	public GfxEffectInstance AddEffect(GfxEffect effect, Vector3 position, float scale = 1f)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		GfxEffectInstance gfxEffectInstance = new GfxEffectInstance
		{
			Effect = effect,
			Position = position,
			Scale = scale,
			Alpha = effect.DefAlpha,
			Time = 0f
		};
		list_0.Add(gfxEffectInstance);
		return gfxEffectInstance;
	}

	public void RemoveEffect(GfxEffectInstance instance)
	{
		list_0.Remove(instance);
	}

	public void ClearEffects(bool releaseTextures = false)
	{
		list_0.Clear();
		if (!releaseTextures)
		{
			return;
		}
		foreach (Texture value in dictionary_0.Values)
		{
			try
			{
				if (value != null)
				{
					((DisposeBase)value).Dispose();
				}
			}
			catch
			{
			}
		}
		dictionary_0.Clear();
	}

	public Texture LoadTexture(string name, byte[] ddsData)
	{
		if (dictionary_0.TryGetValue(name, out var value))
		{
			return value;
		}
		try
		{
			MemoryStream memoryStream = new MemoryStream(ddsData);
			try
			{
				Texture val = Texture.FromStream(device_0, (Stream)memoryStream, 0, 0, 0, (Usage)0, (Format)0, (Pool)1, (Filter)524292, (Filter)524292, 0);
				dictionary_0[name] = val;
				return val;
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
		}
		catch
		{
			return null;
		}
	}

	public Texture GetTexture(string path)
	{
		if (!dictionary_0.TryGetValue(path, out var value))
		{
			return null;
		}
		return value;
	}

	public void RenderEffects(Matrix viewMatrix, Matrix projMatrix, Vector3 cameraPos)
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		if (list_0.Count == 0)
		{
			return;
		}
		DateTime utcNow = DateTime.UtcNow;
		float val = (float)(utcNow - dateTime_0).TotalSeconds;
		dateTime_0 = utcNow;
		val = Math.Min(Math.Max(val, 0f), 0.1f);
		method_14();
		method_15();
		device_0.VertexDeclaration = vertexDeclaration_0;
		foreach (GfxEffectInstance item in list_0)
		{
			if (item.IsPlaying)
			{
				item.Time += val * item.Effect.PlaySpeed;
				method_1(item, viewMatrix, projMatrix, cameraPos, val);
			}
		}
		method_16();
	}

	private void method_1(GfxEffectInstance gfxEffectInstance_0, Matrix matrix_0, Matrix matrix_1, Vector3 vector3_0, float float_1)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		GfxEffect effect = gfxEffectInstance_0.Effect;
		foreach (GfxElement element in effect.Elements)
		{
			if (element.IsDummy)
			{
				continue;
			}
			Matrix matrix_2 = Matrix.Scaling(gfxEffectInstance_0.Scale * effect.DefScale) * gfxEffectInstance_0.Transform * Matrix.Translation(gfxEffectInstance_0.Position);
			if (element.KeyPointSet != null)
			{
				element.KeyPointSet.TickAnimation((uint)(float_1 * 1000f));
			}
			if (!(element is GfxDecalElement gfxDecalElement_))
			{
				if (!(element is GfxParticleElement gfxParticleElement_))
				{
					if (!(element is GfxTrailElement gfxTrailElement_))
					{
						if (!(element is GfxRingElement gfxRingElement_))
						{
							if (!(element is GfxRibbonElement gfxRibbonElement_))
							{
								if (element is GfxLightningElement gfxLightningElement_)
								{
									method_7(gfxLightningElement_, matrix_2, matrix_0, matrix_1, gfxEffectInstance_0);
								}
							}
							else
							{
								method_6(gfxRibbonElement_, matrix_2, matrix_0, matrix_1, vector3_0, gfxEffectInstance_0);
							}
						}
						else
						{
							method_5(gfxRingElement_, matrix_2, matrix_0, matrix_1, vector3_0, gfxEffectInstance_0);
						}
					}
					else
					{
						method_4(gfxTrailElement_, matrix_2, matrix_0, matrix_1, vector3_0, gfxEffectInstance_0);
					}
				}
				else
				{
					method_3(gfxParticleElement_, matrix_2, matrix_0, matrix_1, vector3_0, gfxEffectInstance_0, float_1);
				}
			}
			else
			{
				method_2(gfxDecalElement_, matrix_2, matrix_0, matrix_1, vector3_0, gfxEffectInstance_0);
			}
		}
	}

	private void method_2(GfxDecalElement gfxDecalElement_0, Matrix matrix_0, Matrix matrix_1, Matrix matrix_2, Vector3 vector3_0, GfxEffectInstance gfxEffectInstance_0)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = method_9(gfxDecalElement_0);
		Vector3 val2 = Vector3.TransformCoordinate(val, matrix_0);
		method_13(gfxDecalElement_0.Shader);
		Texture texture = GetTexture(gfxDecalElement_0.TexturePath);
		device_0.SetTexture(0, (BaseTexture)(object)texture);
		float num = gfxDecalElement_0.Width * gfxEffectInstance_0.Scale;
		float num2 = gfxDecalElement_0.Height * gfxEffectInstance_0.Scale;
		Vector3 val3 = Vector3.Normalize(vector3_0 - val2);
		Vector3 val4 = default(Vector3);
		val4 = new Vector3(0f, 1f, 0f);
		Vector3 val5 = Vector3.Normalize(Vector3.Cross(val4, val3));
		val4 = Vector3.Cross(val3, val5);
		float num3 = method_10(gfxDecalElement_0);
		if (num3 != 0f)
		{
			Matrix val6 = Matrix.RotationAxis(val3, num3);
			val5 = Vector3.TransformNormal(val5, val6);
			val4 = Vector3.TransformNormal(val4, val6);
		}
		int num4 = method_11(gfxDecalElement_0, gfxEffectInstance_0.Alpha);
		float float_ = 0f;
		float float_2 = 0f;
		float float_3 = 1f;
		float float_4 = 1f;
		method_12(gfxDecalElement_0, gfxEffectInstance_0.Time, ref float_, ref float_2, ref float_3, ref float_4);
		float num5 = num * 0.5f;
		float num6 = num2 * 0.5f;
		float num7 = (0.5f - gfxDecalElement_0.OrgPtWidth) * num;
		float num8 = (0.5f - gfxDecalElement_0.OrgPtHeight) * num2;
		val2 += val5 * num7 + val4 * num8;
		method_8(new Struct58[4]
		{
			new Struct58(val2 - val5 * num5 - val4 * num6, num4, float_, float_4),
			new Struct58(val2 - val5 * num5 + val4 * num6, num4, float_, float_2),
			new Struct58(val2 + val5 * num5 + val4 * num6, num4, float_3, float_2),
			new Struct58(val2 + val5 * num5 - val4 * num6, num4, float_3, float_4)
		}, 1);
	}

	private void method_3(GfxParticleElement gfxParticleElement_0, Matrix matrix_0, Matrix matrix_1, Matrix matrix_2, Vector3 vector3_0, GfxEffectInstance gfxEffectInstance_0, float float_1)
	{
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Unknown result type (might be due to invalid IL or missing references)
		//IL_0406: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		//IL_043f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		//IL_0446: Unknown result type (might be due to invalid IL or missing references)
		//IL_044b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0466: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Unknown result type (might be due to invalid IL or missing references)
		//IL_046b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0470: Unknown result type (might be due to invalid IL or missing references)
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_0477: Unknown result type (might be due to invalid IL or missing references)
		//IL_047c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0497: Unknown result type (might be due to invalid IL or missing references)
		//IL_0499: Unknown result type (might be due to invalid IL or missing references)
		//IL_049c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Unknown result type (might be due to invalid IL or missing references)
		method_13(gfxParticleElement_0.Shader);
		Texture texture = GetTexture(gfxParticleElement_0.TexturePath);
		device_0.SetTexture(0, (BaseTexture)(object)texture);
		if (gfxEffectInstance_0.Particles == null)
		{
			gfxEffectInstance_0.Particles = new List<ParticleState>(gfxParticleElement_0.Quota);
		}
		GfxEmitterData emitter = gfxParticleElement_0.Emitter;
		float emissionRate = emitter.EmissionRate;
		int num = (int)(emissionRate * float_1);
		Vector3 val = default(Vector3);
		for (int i = 0; i < num; i++)
		{
			if (gfxEffectInstance_0.Particles.Count >= gfxParticleElement_0.Quota)
			{
				break;
			}
			float speed = emitter.Speed;
			float num2 = emitter.Angle * (float)Math.PI / 180f;
			float num3 = (float)random_0.NextDouble() * 2f * (float)Math.PI;
			float num4 = (float)random_0.NextDouble() * num2;
			float num5 = (float)Math.Sin(num4);
			val = new Vector3(num5 * (float)Math.Cos(num3), (float)Math.Cos(num4), num5 * (float)Math.Sin(num3));
			float maxLife = ((emitter.TTL > 0f) ? emitter.TTL : 2f);
			float scale = emitter.ScaleMin + (float)random_0.NextDouble() * (emitter.ScaleMax - emitter.ScaleMin);
			ParticleState item = new ParticleState
			{
				Position = method_9(gfxParticleElement_0),
				Velocity = val * speed,
				Life = 0f,
				MaxLife = maxLife,
				Scale = scale,
				Rotation = emitter.RotMin + (float)random_0.NextDouble() * (emitter.RotMax - emitter.RotMin),
				Color = smethod_1(emitter.ColorMin, emitter.ColorMax, (float)random_0.NextDouble())
			};
			gfxEffectInstance_0.Particles.Add(item);
		}
		Struct58[] array = new Struct58[gfxEffectInstance_0.Particles.Count * 4];
		int num6 = 0;
		Vector3 val5 = default(Vector3);
		for (int num7 = gfxEffectInstance_0.Particles.Count - 1; num7 >= 0; num7--)
		{
			ParticleState value = gfxEffectInstance_0.Particles[num7];
			value.Life += float_1;
			if (value.Life >= value.MaxLife)
			{
				gfxEffectInstance_0.Particles.RemoveAt(num7);
			}
			else
			{
				Vector3 val2 = new Vector3(emitter.AccDir.float_0, emitter.AccDir.float_1, emitter.AccDir.float_2) * emitter.Acc;
				ref Vector3 velocity = ref value.Velocity;
				velocity += val2 * float_1;
				ref Vector3 position = ref value.Position;
				position += new Vector3(value.Velocity.X * float_1, value.Velocity.Y * float_1, value.Velocity.Z * float_1);
				gfxEffectInstance_0.Particles[num7] = value;
				float num8 = value.Life / value.MaxLife;
				float num9 = value.Scale * gfxParticleElement_0.ParticleWidth * gfxEffectInstance_0.Scale;
				Vector3 val3 = Vector3.TransformCoordinate(value.Position, matrix_0);
				Vector3 val4 = Vector3.Normalize(vector3_0 - val3);
				val5 = new Vector3(0f, 1f, 0f);
				Vector3 val6 = Vector3.Normalize(Vector3.Cross(val5, val4));
				val5 = Vector3.Cross(val4, val6);
				if (value.Rotation != 0f)
				{
					Matrix val7 = Matrix.RotationAxis(val4, value.Rotation * num8);
					val6 = Vector3.TransformNormal(val6, val7);
					val5 = Vector3.TransformNormal(val5, val7);
				}
				float num10 = num9 * 0.5f;
				int num11 = smethod_2(value.Color, 1f - num8, gfxEffectInstance_0.Alpha);
				float float_2 = 0f;
				float float_3 = 0f;
				float float_4 = 1f;
				float float_5 = 1f;
				method_12(gfxParticleElement_0, gfxEffectInstance_0.Time, ref float_2, ref float_3, ref float_4, ref float_5);
				int num12 = num6 * 4;
				if (num12 + 3 >= array.Length)
				{
					break;
				}
				array[num12] = new Struct58(val3 - val6 * num10 - val5 * num10, num11, float_2, float_5);
				array[num12 + 1] = new Struct58(val3 - val6 * num10 + val5 * num10, num11, float_2, float_3);
				array[num12 + 2] = new Struct58(val3 + val6 * num10 + val5 * num10, num11, float_4, float_3);
				array[num12 + 3] = new Struct58(val3 + val6 * num10 - val5 * num10, num11, float_4, float_5);
				num6++;
			}
		}
		if (num6 > 0)
		{
			method_8(array, num6);
		}
	}

	private void method_4(GfxTrailElement gfxTrailElement_0, Matrix matrix_0, Matrix matrix_1, Matrix matrix_2, Vector3 vector3_0, GfxEffectInstance gfxEffectInstance_0)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		method_13(gfxTrailElement_0.Shader);
		Texture texture = GetTexture(gfxTrailElement_0.TexturePath);
		device_0.SetTexture(0, (BaseTexture)(object)texture);
		Vector3 val = default(Vector3);
		val = new Vector3(gfxTrailElement_0.OrgPos0.float_0, gfxTrailElement_0.OrgPos0.float_1, gfxTrailElement_0.OrgPos0.float_2);
		Vector3 val2 = default(Vector3);
		val2 = new Vector3(gfxTrailElement_0.OrgPos1.float_0, gfxTrailElement_0.OrgPos1.float_1, gfxTrailElement_0.OrgPos1.float_2);
		val = Vector3.TransformCoordinate(val, matrix_0);
		val2 = Vector3.TransformCoordinate(val2, matrix_0);
		Vector3 val3 = val2 - val;
		if (!(val3.LengthSquared() < 0.0001f))
		{
			val3 = Vector3.Normalize(val3);
			Vector3 val4 = Vector3.Normalize(vector3_0 - (val + val2) * 0.5f);
			Vector3 val5 = Vector3.Normalize(Vector3.Cross(val3, val4));
			float num = 0.1f * gfxEffectInstance_0.Scale;
			int num2 = method_11(gfxTrailElement_0, gfxEffectInstance_0.Alpha);
			method_8(new Struct58[4]
			{
				new Struct58(val - val5 * num, num2, 0f, 0f),
				new Struct58(val + val5 * num, num2, 1f, 0f),
				new Struct58(val2 + val5 * num, num2, 1f, 1f),
				new Struct58(val2 - val5 * num, num2, 0f, 1f)
			}, 1);
		}
	}

	private void method_5(GfxRingElement gfxRingElement_0, Matrix matrix_0, Matrix matrix_1, Matrix matrix_2, Vector3 vector3_0, GfxEffectInstance gfxEffectInstance_0)
	{
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		method_13(gfxRingElement_0.Shader);
		Texture texture = GetTexture(gfxRingElement_0.TexturePath);
		device_0.SetTexture(0, (BaseTexture)(object)texture);
		int num = Math.Max(8, gfxRingElement_0.SegmentCount);
		float num2 = gfxRingElement_0.Radius * gfxEffectInstance_0.Scale;
		float num3 = gfxRingElement_0.Height * gfxEffectInstance_0.Scale;
		int num4 = method_11(gfxRingElement_0, gfxEffectInstance_0.Alpha);
		int num5 = num;
		Struct58[] array = new Struct58[num5 * 4];
		for (int i = 0; i < num; i++)
		{
			float num6 = (float)i / (float)num * 2f * (float)Math.PI;
			float num7 = (float)(i + 1) / (float)num * 2f * (float)Math.PI;
			float num8 = (float)Math.Cos(num6) * num2;
			float num9 = (float)Math.Sin(num6) * num2;
			float num10 = (float)Math.Cos(num7) * num2;
			float num11 = (float)Math.Sin(num7) * num2;
			float float_ = (float)i / (float)num;
			float float_2 = (float)(i + 1) / (float)num;
			Vector3 vector3_1 = Vector3.TransformCoordinate(new Vector3(num8, (0f - num3) * 0.5f, num9), matrix_0);
			Vector3 vector3_2 = Vector3.TransformCoordinate(new Vector3(num8, num3 * 0.5f, num9), matrix_0);
			Vector3 vector3_3 = Vector3.TransformCoordinate(new Vector3(num10, (0f - num3) * 0.5f, num11), matrix_0);
			Vector3 vector3_4 = Vector3.TransformCoordinate(new Vector3(num10, num3 * 0.5f, num11), matrix_0);
			int num12 = i * 4;
			array[num12] = new Struct58(vector3_1, num4, float_, 1f);
			array[num12 + 1] = new Struct58(vector3_2, num4, float_, 0f);
			array[num12 + 2] = new Struct58(vector3_4, num4, float_2, 0f);
			array[num12 + 3] = new Struct58(vector3_3, num4, float_2, 1f);
		}
		method_8(array, num5);
	}

	private void method_6(GfxRibbonElement gfxRibbonElement_0, Matrix matrix_0, Matrix matrix_1, Matrix matrix_2, Vector3 vector3_0, GfxEffectInstance gfxEffectInstance_0)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		method_13(gfxRibbonElement_0.Shader);
		Texture texture = GetTexture(gfxRibbonElement_0.TexturePath);
		device_0.SetTexture(0, (BaseTexture)(object)texture);
		Vector3 val = method_9(gfxRibbonElement_0);
		Vector3 val2 = Vector3.TransformCoordinate(val, matrix_0);
		float num = gfxRibbonElement_0.Width * 0.5f * gfxEffectInstance_0.Scale;
		int num2 = method_11(gfxRibbonElement_0, gfxEffectInstance_0.Alpha);
		method_8(new Struct58[4]
		{
			new Struct58(val2 + new Vector3(0f - num, 0f, 0f), num2, 0f, 0f),
			new Struct58(val2 + new Vector3(0f - num, num * 2f, 0f), num2, 0f, 1f),
			new Struct58(val2 + new Vector3(num, num * 2f, 0f), num2, 1f, 1f),
			new Struct58(val2 + new Vector3(num, 0f, 0f), num2, 1f, 0f)
		}, 1);
	}

	private void method_7(GfxLightningElement gfxLightningElement_0, Matrix matrix_0, Matrix matrix_1, Matrix matrix_2, GfxEffectInstance gfxEffectInstance_0)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		method_13(gfxLightningElement_0.Shader);
		Texture texture = GetTexture(gfxLightningElement_0.TexturePath);
		device_0.SetTexture(0, (BaseTexture)(object)texture);
		int num = Math.Max(2, gfxLightningElement_0.NumPoints);
		float num2 = gfxLightningElement_0.Amplitude * gfxEffectInstance_0.Scale;
		Vector3 val = method_9(gfxLightningElement_0);
		Vector3 val2 = Vector3.TransformCoordinate(val, matrix_0);
		Vector3 val3 = val2 + new Vector3(0f, 2f * gfxEffectInstance_0.Scale, 0f);
		Vector3[] array = (Vector3[])(object)new Vector3[num];
		array[0] = val2;
		array[num - 1] = val3;
		for (int i = 1; i < num - 1; i++)
		{
			float num3 = (float)i / (float)(num - 1);
			Vector3 val4 = Vector3.Lerp(val2, val3, num3);
			val4.X += ((float)random_0.NextDouble() - 0.5f) * 2f * num2;
			val4.Z += ((float)random_0.NextDouble() - 0.5f) * 2f * num2;
			array[i] = val4;
		}
		int num4 = num - 1;
		Struct58[] array2 = new Struct58[num4 * 4];
		int num5 = method_11(gfxLightningElement_0, gfxEffectInstance_0.Alpha);
		for (int j = 0; j < num4; j++)
		{
			float num6 = (gfxLightningElement_0.StartWidth + (gfxLightningElement_0.EndWidth - gfxLightningElement_0.StartWidth) * ((float)j / (float)num4)) * gfxEffectInstance_0.Scale;
			Vector3 val5 = Vector3.Normalize(array[j + 1] - array[j]);
			Vector3 val6 = Vector3.Normalize(Vector3.Cross(val5, Vector3.UnitY));
			if (val6.LengthSquared() < 0.01f)
			{
				val6 = Vector3.Normalize(Vector3.Cross(val5, Vector3.UnitX));
			}
			float num7 = num6 * 0.5f;
			float float_ = (float)j / (float)num4;
			float float_2 = (float)(j + 1) / (float)num4;
			int num8 = j * 4;
			array2[num8] = new Struct58(array[j] - val6 * num7, num5, float_, 0f);
			array2[num8 + 1] = new Struct58(array[j] + val6 * num7, num5, float_, 1f);
			array2[num8 + 2] = new Struct58(array[j + 1] + val6 * num7, num5, float_2, 1f);
			array2[num8 + 3] = new Struct58(array[j + 1] - val6 * num7, num5, float_2, 0f);
		}
		method_8(array2, num4);
	}

	private void method_8(Struct58[] struct58_0, int int_3)
	{
		if (int_3 <= 0 || int_3 > 2048)
		{
			return;
		}
		int num = int_3 * 4;
		DataStream val = vertexBuffer_0.Lock(0, num * 24, (LockFlags)8192);
		try
		{
			for (int i = 0; i < num; i++)
			{
				val.Write<Struct58>(struct58_0[i]);
			}
		}
		finally
		{
			((Stream)(object)val).Dispose();
			vertexBuffer_0.Unlock();
		}
		device_0.SetStreamSource(0, vertexBuffer_0, 0, 24);
		device_0.Indices = indexBuffer_0;
		device_0.DrawIndexedPrimitive((PrimitiveType)4, 0, 0, num, 0, int_3 * 2);
	}

	private Vector3 method_9(GfxElement gfxElement_0)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		if (gfxElement_0.KeyPointSet != null)
		{
			Vector3f position = gfxElement_0.KeyPointSet.ProcData.Position;
			return new Vector3(position.float_0, position.float_1, position.float_2);
		}
		return Vector3.Zero;
	}

	private float method_10(GfxElement gfxElement_0)
	{
		return 0f;
	}

	private int method_11(GfxElement gfxElement_0, float float_1)
	{
		byte b = (byte)(Math.Min(Math.Max(float_1, 0f), 1f) * 255f);
		return (b << 24) | 0xFFFFFF;
	}

	private void method_12(GfxElement gfxElement_0, float float_1, ref float float_2, ref float float_3, ref float float_4, ref float float_5)
	{
		if (gfxElement_0.TexRows > 1 || gfxElement_0.TexCols > 1)
		{
			int num = (int)Math.Max(1u, gfxElement_0.TexRows);
			int num2 = (int)Math.Max(1u, gfxElement_0.TexCols);
			int num3 = num * num2;
			float num4 = ((gfxElement_0.TexInterval != 0) ? ((float)gfxElement_0.TexInterval / 1000f) : 0.1f);
			int num5 = (int)(float_1 / num4) % num3;
			int num6 = num5 / num2;
			int num7 = num5 % num2;
			float_2 = (float)num7 / (float)num2;
			float_3 = (float)num6 / (float)num;
			float_4 = (float)(num7 + 1) / (float)num2;
			float_5 = (float)(num6 + 1) / (float)num;
		}
	}

	private void method_13(GfxShader gfxShader_0)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		device_0.SetRenderState((RenderState)27, true);
		device_0.SetRenderState<Blend>((RenderState)19, smethod_0(gfxShader_0.SrcBlend));
		device_0.SetRenderState<Blend>((RenderState)20, smethod_0(gfxShader_0.DestBlend));
	}

	private static Blend smethod_0(int int_3)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		return (Blend)(int_3 switch
		{
			1 => 1, 
			2 => 2, 
			3 => 3, 
			4 => 4, 
			5 => 5, 
			6 => 6, 
			7 => 7, 
			8 => 8, 
			9 => 9, 
			10 => 10, 
			_ => 2, 
		});
	}

	private static int smethod_1(uint uint_0, uint uint_1, float float_1)
	{
		int num = (int)((float)((uint_0 >> 24) & 0xFF) + (float)(((uint_1 >> 24) & 0xFF) - ((uint_0 >> 24) & 0xFF)) * float_1);
		int num2 = (int)((float)((uint_0 >> 16) & 0xFF) + (float)(((uint_1 >> 16) & 0xFF) - ((uint_0 >> 16) & 0xFF)) * float_1);
		int num3 = (int)((float)((uint_0 >> 8) & 0xFF) + (float)(((uint_1 >> 8) & 0xFF) - ((uint_0 >> 8) & 0xFF)) * float_1);
		int num4 = (int)((float)(uint_0 & 0xFF) + (float)((uint_1 & 0xFF) - (uint_0 & 0xFF)) * float_1);
		return (num << 24) | (num2 << 16) | (num3 << 8) | num4;
	}

	private static int smethod_2(int int_3, float float_1, float float_2)
	{
		int num = (int_3 >> 24) & 0xFF;
		num = (int)((float)num * float_1 * float_2);
		num = Math.Min(Math.Max(num, 0), 255);
		return (num << 24) | (int_3 & 0xFFFFFF);
	}

	private void method_14()
	{
		bool_0 = device_0.GetRenderState<bool>((RenderState)27);
		bool_1 = device_0.GetRenderState<bool>((RenderState)14);
		int_0 = device_0.GetRenderState<int>((RenderState)19);
		int_1 = device_0.GetRenderState<int>((RenderState)20);
		int_2 = device_0.GetRenderState<int>((RenderState)22);
	}

	private void method_15()
	{
		device_0.SetRenderState((RenderState)27, true);
		device_0.SetRenderState((RenderState)14, false);
		device_0.SetRenderState<Cull>((RenderState)22, (Cull)1);
		device_0.SetRenderState((RenderState)137, false);
		device_0.SetTextureStageState(0, (TextureStage)1, (TextureOperation)4);
		device_0.SetTextureStageState(0, (TextureStage)2, (TextureArgument)2);
		device_0.SetTextureStageState(0, (TextureStage)3, (TextureArgument)0);
		device_0.SetTextureStageState(0, (TextureStage)4, (TextureOperation)4);
		device_0.SetTextureStageState(0, (TextureStage)5, (TextureArgument)2);
		device_0.SetTextureStageState(0, (TextureStage)6, (TextureArgument)0);
	}

	private void method_16()
	{
		device_0.SetRenderState((RenderState)27, bool_0);
		device_0.SetRenderState((RenderState)14, bool_1);
		device_0.SetRenderState((RenderState)19, int_0);
		device_0.SetRenderState((RenderState)20, int_1);
		device_0.SetRenderState((RenderState)22, int_2);
		device_0.SetRenderState((RenderState)137, true);
	}

	public void Dispose()
	{
		foreach (Texture value in dictionary_0.Values)
		{
			if (value != null)
			{
				((DisposeBase)value).Dispose();
			}
		}
		dictionary_0.Clear();
		VertexBuffer obj = vertexBuffer_0;
		if (obj != null)
		{
			((DisposeBase)obj).Dispose();
		}
		IndexBuffer obj2 = indexBuffer_0;
		if (obj2 != null)
		{
			((DisposeBase)obj2).Dispose();
		}
		VertexDeclaration obj3 = vertexDeclaration_0;
		if (obj3 != null)
		{
			((DisposeBase)obj3).Dispose();
		}
		list_0.Clear();
	}
}
