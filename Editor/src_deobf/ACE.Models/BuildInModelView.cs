using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ACE.Classes;
using ACE.GFX;
using ACE.Models.ECM;
using ACE.Properties;
using ACE.RSGlobal;
using SharpDX;
using SharpDX.Direct3D9;
using SharpDX.Mathematics.Interop;
// TODO(recovered): disambiguation aliases (decompiled file mixes SharpDX + System.Drawing).
using Color = System.Drawing.Color;
using Point = System.Drawing.Point;
using Matrix = SharpDX.Matrix;
using Blend = SharpDX.Direct3D9.Blend;
using Font = System.Drawing.Font;

namespace ACE.Models;

public class BuildInModelView : Form
{
	private struct Struct65
	{
		public Vector3 vector3_0;

		public Vector3 vector3_1;

		public float float_0;

		public float float_1;

		public static readonly int int_0 = Marshal.SizeOf<Struct65>();
	}

	private sealed class Class238
	{
		public Vector3f[] vector3f_0;

		public Vector3f[] vector3f_1;

		public float[] float_0;

		public float[] float_1;

		public int[] int_0;

		public bool bool_0;
	}

	private sealed class Class239
	{
		public BuildInModelView buildInModelView_0;

		public SkinModelData skinModelData_0;

		internal void method_0(object sender, EventArgs e)
		{
			if (buildInModelView_0.comboBox_2.SelectedIndex >= 0)
			{
				SkinModelAction skinModelAction = skinModelData_0.Animations[buildInModelView_0.comboBox_2.SelectedIndex];
				if (buildInModelView_0.FilePath?.Animator != null && skinModelAction.FrameRate > 0)
				{
					float time = skinModelAction.StartFrame / (float)skinModelAction.FrameRate;
					buildInModelView_0.FilePath.Animator.SetTime(time);
				}
			}
		}
	}

	private struct Struct66
	{
		public Vector3 vector3_0;

		public int int_0;

		public static readonly int int_1 = Marshal.SizeOf<Struct66>();
	}

	private float float_0 = 15f;

	private Direct3D direct3D_0;

	private Device device_0;

	private VertexBuffer[] vertexBuffer_0;

	private IndexBuffer[] indexBuffer_0;

	private int[] int_0;

	private int[] int_1;

	private VertexDeclaration vertexDeclaration_0;

	private Class238[] class238_0;

	private bool bool_0;

	private Stopwatch stopwatch_0;

	private float float_1;

	private bool bool_1;

	private bool bool_2;

	private Point point_0;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	private Material material_0;

	private Texture[] texture_0;

	private Label label_0;

	public ModelClass FilePath;

	public IContainer components;

	private Timer timer_0;

	private ComboBox comboBox_0;

	private Button button_0;

	private TrackBar trackBar_0;

	private Label label_1;

	private bool bool_3;

	private pwMeshContainer pwMeshContainer_0;

	private bool bool_4;

	private bool bool_5;

	private int int_2;

	private static readonly VertexElement[] vertexElement_0 = (VertexElement[])(object)new VertexElement[4]
	{
		new VertexElement((short)0, (short)0, (DeclarationType)2, (DeclarationMethod)0, (DeclarationUsage)0, (byte)0),
		new VertexElement((short)0, (short)12, (DeclarationType)2, (DeclarationMethod)0, (DeclarationUsage)3, (byte)0),
		new VertexElement((short)0, (short)24, (DeclarationType)1, (DeclarationMethod)0, (DeclarationUsage)5, (byte)0),
		VertexElement.VertexDeclarationEnd
	};

	private GfxRenderer gfxRenderer_0;

	private readonly List<GfxRenderer.GfxEffectInstance> list_0 = new List<GfxRenderer.GfxEffectInstance>();

	private float float_6 = 15f;

	private float float_7 = 0.8f;

	private float float_8 = -0.3f;

	private Vector3 vector3_0 = Vector3.Zero;

	private float float_9 = (float)Math.PI / 4f;

	private bool bool_6;

	private bool bool_7;

	private Point point_1;

	private Point point_2;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	private bool bool_14;

	private int int_3;

	private float float_10;

	private float float_11;

	private int int_4;

	private bool bool_15;

	private float float_12 = 0.35f;

	private float float_13 = 1f;

	private float float_14 = 0.8f;

	private float float_15 = 25f;

	private Vector3 vector3_1 = new Vector3(0.5f, -0.5f, 1f);

	private Color color_0 = Color.FromArgb(65, 65, 70);

	private Color color_1 = Color.White;

	private Color color_2 = Color.FromArgb(211, 211, 211);

	private bool bool_16;

	private float float_16 = 30f;

	private float float_17 = 200f;

	private Color color_3 = Color.FromArgb(45, 45, 48);

	private Color color_4 = Color.FromArgb(45, 45, 48);

	private static readonly string[] string_0 = new string[8]
	{
		Class16.smethod_0(1649120131),
		Class16.smethod_0(1649120152),
		Class16.smethod_0(1649120182),
		Class16.smethod_0(1649120192),
		Class16.smethod_0(1649120221),
		Class16.smethod_0(1649120232),
		Class16.smethod_0(1649120249),
		Class16.smethod_0(1649119241)
	};

	private bool bool_17;

	private bool bool_18;

	private bool bool_19;

	private int int_5;

	private int int_6;

	private int int_7 = -1;

	private bool bool_20 = true;

	private bool bool_21 = true;

	private PresentParameters presentParameters_0;

	private bool bool_22;

	private VertexBuffer vertexBuffer_1;

	private int int_8;

	private bool bool_23;

	private Panel panel_0;

	private ComboBox comboBox_1;

	private ComboBox comboBox_2;

	private TrackBar trackBar_1;

	private TrackBar trackBar_2;

	private TrackBar trackBar_3;

	private TrackBar trackBar_4;

	private TrackBar trackBar_5;

	private TrackBar trackBar_6;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private CheckBox checkBox_2;

	private CheckBox checkBox_3;

	private CheckBox checkBox_4;

	private CheckBox checkBox_5;

	private Button button_1;

	private Button button_2;

	private Button button_3;

	private Label label_2;

	private Label label_3;

	private Label label_4;

	private Label label_5;

	private Label label_6;

	private Label label_7;

	private Timer timer_1;

	private bool bool_24;

	public BuildInModelView(ModelClass obj, string title)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		FilePath = obj;
		method_12();
		TDark.StoreOriginalColors(this);
		TDark.ApplyThemeToForm(this);
		TextStorage.TEXTS.SetFormLanguage(this, null);
		SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint, value: true);
		Text = title;
		base.Activated += BuildInModelView_Activated;
		stopwatch_0 = new Stopwatch();
		int_2 = Environment.TickCount;
		if (obj != null && obj.Type == ModelType.ECM)
		{
			if (obj.Animator != null)
			{
				bool_0 = true;
				method_5();
			}
			else
			{
				method_0(Class16.smethod_0(1649120093));
			}
		}
		method_50();
	}

	private void method_0(string string_1)
	{
		method_1();
		label_0 = new Label
		{
			Text = string_1,
			Location = new Point(10, base.ClientSize.Height - 30),
			Width = base.ClientSize.Width - 20,
			ForeColor = Color.Yellow,
			BackColor = Color.FromArgb(45, 45, 48)
		};
		base.Controls.Add(label_0);
	}

	private void method_1()
	{
		if (label_0 != null)
		{
			base.Controls.Remove(label_0);
			try
			{
				label_0.Dispose();
			}
			catch
			{
			}
			label_0 = null;
		}
	}

	private void method_2()
	{
		if (comboBox_0 != null)
		{
			base.Controls.Remove(comboBox_0);
			try
			{
				comboBox_0.Dispose();
			}
			catch
			{
			}
			comboBox_0 = null;
		}
		if (button_0 != null)
		{
			base.Controls.Remove(button_0);
			try
			{
				button_0.Dispose();
			}
			catch
			{
			}
			button_0 = null;
		}
		if (trackBar_0 != null)
		{
			base.Controls.Remove(trackBar_0);
			try
			{
				trackBar_0.Dispose();
			}
			catch
			{
			}
			trackBar_0 = null;
		}
		if (label_1 != null)
		{
			base.Controls.Remove(label_1);
			try
			{
				label_1.Dispose();
			}
			catch
			{
			}
			label_1 = null;
		}
	}

	private void method_3()
	{
		if (texture_0 != null)
		{
			Texture[] array = texture_0;
			foreach (Texture val in array)
			{
				try
				{
					if (val != null)
					{
						((DisposeBase)val).Dispose();
					}
				}
				catch
				{
				}
			}
			texture_0 = null;
		}
		if (indexBuffer_0 != null)
		{
			IndexBuffer[] array2 = indexBuffer_0;
			foreach (IndexBuffer val2 in array2)
			{
				try
				{
					if (val2 != null)
					{
						((DisposeBase)val2).Dispose();
					}
				}
				catch
				{
				}
			}
			indexBuffer_0 = null;
		}
		if (vertexBuffer_0 != null)
		{
			VertexBuffer[] array3 = vertexBuffer_0;
			foreach (VertexBuffer val3 in array3)
			{
				try
				{
					if (val3 != null)
					{
						((DisposeBase)val3).Dispose();
					}
				}
				catch
				{
				}
			}
			vertexBuffer_0 = null;
		}
		class238_0 = null;
		int_0 = null;
		int_1 = null;
	}

	private void method_4(ModelClass modelClass_0)
	{
		if (FilePath != null && FilePath != modelClass_0)
		{
			smethod_0(FilePath);
			FilePath = null;
			pwMeshContainer_0 = null;
		}
	}

	private static void smethod_0(ModelClass modelClass_0)
	{
		if (modelClass_0 != null)
		{
			modelClass_0.skyfile = Array.Empty<byte>();
			if (modelClass_0.DDSIMAGE != null)
			{
				modelClass_0.DDSIMAGE.Clear();
			}
			if (modelClass_0.Animations != null)
			{
				modelClass_0.Animations.Clear();
			}
			modelClass_0.Animator = null;
			modelClass_0.Skeleton = null;
			modelClass_0.ECM = null;
			modelClass_0.CurrentAnimationIndex = -1;
		}
	}

	private void method_5()
	{
		comboBox_0 = new ComboBox
		{
			Location = new Point(10, base.ClientSize.Height - 90),
			Width = 200,
			DropDownStyle = ComboBoxStyle.DropDownList
		};
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		comboBox_0.MouseWheel += comboBox_2_MouseWheel;
		base.Controls.Add(comboBox_0);
		button_0 = new Button
		{
			Text = Class16.smethod_0(1648942867),
			Location = new Point(220, base.ClientSize.Height - 90),
			Width = 40,
			Height = 25
		};
		button_0.Click += button_0_Click;
		button_0.MouseWheel += comboBox_2_MouseWheel;
		base.Controls.Add(button_0);
		trackBar_0 = new TrackBar
		{
			Location = new Point(10, base.ClientSize.Height - 55),
			Width = 350,
			Minimum = 0,
			Maximum = 1000,
			TickFrequency = 100
		};
		trackBar_0.Scroll += trackBar_0_Scroll;
		trackBar_0.MouseWheel += comboBox_2_MouseWheel;
		base.Controls.Add(trackBar_0);
		label_1 = new Label
		{
			Location = new Point(370, base.ClientSize.Height - 55),
			Width = 200,
			Text = Class16.smethod_0(1649119262),
			ForeColor = Color.White,
			BackColor = Color.FromArgb(45, 45, 48)
		};
		base.Controls.Add(label_1);
		if (FilePath?.Animations == null)
		{
			return;
		}
		List<SkinModelAction> list = FilePath.ECM?.SMD?.Animations;
		for (int i = 0; i < FilePath.Animations.Count; i++)
		{
			TrackSet trackSet = FilePath.Animations[i];
			string text = null;
			if (list != null && i < list.Count && !string.IsNullOrEmpty(list[i].Name))
			{
				text = list[i].Name;
			}
			if (string.IsNullOrEmpty(text))
			{
				text = System.IO.Path.GetFileNameWithoutExtension(trackSet.FilePath ?? string.Empty);
			}
			if (string.IsNullOrEmpty(text))
			{
				text = string.Format(Class16.smethod_0(1649119273), i);
			}
			comboBox_0.Items.Add(string.Format(Class16.smethod_0(1649119301), text, trackSet.TotalFrames, trackSet.AnimFPS));
		}
		if (comboBox_0.Items.Count > 0)
		{
			comboBox_0.SelectedIndex = 0;
		}
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (comboBox_0.SelectedIndex >= 0)
		{
			FilePath?.PlayAnimation(comboBox_0.SelectedIndex);
			stopwatch_0.Restart();
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		bool_3 = !bool_3;
		button_0.Text = (bool_3 ? Class16.smethod_0(1648942867) : Class16.smethod_0(1648942867));
		if (bool_3)
		{
			stopwatch_0.Stop();
		}
		else
		{
			stopwatch_0.Start();
		}
	}

	private void trackBar_0_Scroll(object sender, EventArgs e)
	{
		ModelClass filePath = FilePath;
		if (filePath?.Animator != null && filePath.Animator.Duration > 0f)
		{
			float time = (float)trackBar_0.Value / 1000f * filePath.Animator.Duration;
			filePath.Animator.SetTime(time);
		}
	}

	public void InitializeDevice()
	{
		if (base.IsDisposed)
		{
			return;
		}
		if (device_0 != null && !((DisposeBase)device_0).IsDisposed && bool_19)
		{
			if (bool_0 && stopwatch_0 != null && !bool_3 && !stopwatch_0.IsRunning)
			{
				stopwatch_0.Start();
			}
			if (!bool_17)
			{
				method_41();
			}
			return;
		}
		if (device_0 != null && !((DisposeBase)device_0).IsDisposed && base.IsHandleCreated)
		{
			method_26(bool_25: true);
		}
		else
		{
			method_32();
		}
		if (bool_19)
		{
			if (stopwatch_0 != null && !bool_3)
			{
				stopwatch_0.Start();
			}
			method_41();
		}
	}

	public void EnsureDeviceInitialized()
	{
		InitializeDevice();
	}

	public void LoadModel(ModelClass obj, string title, pwMeshContainer meshContainer)
	{
		if (obj == null || meshContainer == null)
		{
			return;
		}
		method_42();
		stopwatch_0?.Stop();
		method_3();
		method_4(obj);
		method_2();
		method_1();
		FilePath = obj;
		pwMeshContainer_0 = meshContainer;
		Text = title ?? Text;
		bool_0 = obj.Type == ModelType.ECM && obj.Animator != null;
		bool_3 = false;
		float_1 = 0f;
		if (bool_0)
		{
			method_5();
		}
		else if (obj.Type == ModelType.ECM)
		{
			method_0(Class16.smethod_0(1649120093));
		}
		EnsureDeviceInitialized();
		if (!bool_19 || device_0 == null || ((DisposeBase)device_0).IsDisposed)
		{
			if (base.IsHandleCreated)
			{
				method_26(bool_25: true);
			}
			if (!bool_19 || device_0 == null || ((DisposeBase)device_0).IsDisposed)
			{
				method_0(Class16.smethod_0(1649119326));
				return;
			}
		}
		MakePWModelx(meshContainer);
		method_22();
		LoadGfxEffects();
		stopwatch_0?.Restart();
		method_41();
	}

	public void InitializeKeyboard()
	{
	}

	public void CameraPositioning()
	{
		method_21();
		method_39();
	}

	public void MakePWModelx(pwMeshContainer pwMesh)
	{
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_0510: Unknown result type (might be due to invalid IL or missing references)
		//IL_0526: Unknown result type (might be due to invalid IL or missing references)
		//IL_053f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0542: Unknown result type (might be due to invalid IL or missing references)
		//IL_0544: Unknown result type (might be due to invalid IL or missing references)
		//IL_054a: Expected O, but got Unknown
		//IL_0592: Unknown result type (might be due to invalid IL or missing references)
		//IL_0598: Expected O, but got Unknown
		if (pwMesh == null || pwMesh.Objects == null || pwMesh.Objects.Length == 0 || device_0 == null || ((DisposeBase)device_0).IsDisposed)
		{
			return;
		}
		int num = pwMesh.Objects.Length;
		vertexBuffer_0 = (VertexBuffer[])(object)new VertexBuffer[num];
		indexBuffer_0 = (IndexBuffer[])(object)new IndexBuffer[num];
		int_0 = new int[num];
		int_1 = new int[num];
		texture_0 = (Texture[])(object)new Texture[num];
		class238_0 = new Class238[num];
		for (int i = 0; i < num; i++)
		{
			pwObject pwObject2 = pwMesh.Objects[i];
			if (pwObject2 == null || pwObject2.Faces == null || pwObject2.Faces.Length == 0 || pwObject2.Vertices == null || pwObject2.Vertices.Length == 0)
			{
				continue;
			}
			List<short> list = new List<short>();
			for (int j = 0; j < pwObject2.Faces.Length; j++)
			{
				list.Add(pwObject2.Faces[j].short_0);
				list.Add(pwObject2.Faces[j].short_1);
				list.Add(pwObject2.Faces[j].short_2);
			}
			short[] array = list.ToArray();
			int_0[i] = array.Length;
			int_1[i] = pwObject2.VertexCount;
			Class238 @class = new Class238();
			@class.vector3f_0 = new Vector3f[pwObject2.VertexCount];
			@class.vector3f_1 = new Vector3f[pwObject2.VertexCount];
			@class.float_0 = new float[pwObject2.VertexCount * 2];
			@class.bool_0 = pwObject2.Type == MeshType.Skin && pwObject2.VertexWeight != null && pwObject2.BoneIndex != null;
			if (@class.bool_0)
			{
				@class.float_1 = new float[pwObject2.VertexCount * 4];
				@class.int_0 = new int[pwObject2.VertexCount * 4];
			}
			Struct65[] array2 = new Struct65[pwObject2.VertexCount];
			for (int k = 0; k < pwObject2.VertexCount; k++)
			{
				@class.vector3f_0[k] = new Vector3f(pwObject2.Vertices[k].float_0, pwObject2.Vertices[k].float_1, pwObject2.Vertices[k].float_2);
				array2[k].vector3_0 = new Vector3(pwObject2.Vertices[k].float_0, pwObject2.Vertices[k].float_1, pwObject2.Vertices[k].float_2);
				if (pwObject2.Normals != null && k < pwObject2.Normals.Length)
				{
					@class.vector3f_1[k] = new Vector3f(pwObject2.Normals[k].float_0, pwObject2.Normals[k].float_1, pwObject2.Normals[k].float_2);
					array2[k].vector3_1 = new Vector3(pwObject2.Normals[k].float_0, pwObject2.Normals[k].float_1, pwObject2.Normals[k].float_2);
				}
				if (pwObject2.UVs != null && k < pwObject2.UVs.Length)
				{
					array2[k].float_0 = pwObject2.UVs[k].float_0;
					array2[k].float_1 = pwObject2.UVs[k].float_1;
					@class.float_0[k * 2] = pwObject2.UVs[k].float_0;
					@class.float_0[k * 2 + 1] = pwObject2.UVs[k].float_1;
				}
				if (@class.bool_0)
				{
					int num2 = k * 4;
					@class.float_1[num2] = pwObject2.VertexWeight[k].float_0;
					@class.float_1[num2 + 1] = pwObject2.VertexWeight[k].float_1;
					@class.float_1[num2 + 2] = pwObject2.VertexWeight[k].float_2;
					@class.float_1[num2 + 3] = 1f - pwObject2.VertexWeight[k].float_0 - pwObject2.VertexWeight[k].float_1 - pwObject2.VertexWeight[k].float_2;
					@class.int_0[num2] = pwMesh.GetRemappedBoneIndex(pwObject2.BoneIndex[k].byte_0);
					@class.int_0[num2 + 1] = pwMesh.GetRemappedBoneIndex(pwObject2.BoneIndex[k].byte_1);
					@class.int_0[num2 + 2] = pwMesh.GetRemappedBoneIndex(pwObject2.BoneIndex[k].byte_2);
					@class.int_0[num2 + 3] = pwMesh.GetRemappedBoneIndex(pwObject2.BoneIndex[k].byte_3);
				}
			}
			class238_0[i] = @class;
			Usage val = (Usage)((@class.bool_0 && bool_0) ? 520 : 0);
			Pool val2 = (Pool)((!@class.bool_0 || !bool_0) ? 1 : 0);
			vertexBuffer_0[i] = new VertexBuffer(device_0, array2.Length * Struct65.int_0, val, (VertexFormat)0, val2);
			DataStream val3 = vertexBuffer_0[i].Lock(0, 0, (LockFlags)0);
			try
			{
				val3.WriteRange<Struct65>(array2);
			}
			finally
			{
				((Stream)(object)val3).Dispose();
				vertexBuffer_0[i].Unlock();
			}
			indexBuffer_0[i] = new IndexBuffer(device_0, array.Length * 2, (Usage)0, (Pool)1, true);
			DataStream val4 = indexBuffer_0[i].Lock(0, 0, (LockFlags)0);
			try
			{
				val4.WriteRange<short>(array);
			}
			finally
			{
				((Stream)(object)val4).Dispose();
				indexBuffer_0[i].Unlock();
			}
			method_7(pwMesh, pwObject2, i);
		}
	}

	private void method_6()
	{
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		if (FilePath?.Animator == null || class238_0 == null || vertexBuffer_0 == null || int_1 == null)
		{
			return;
		}
		Matrix4x4[] finalBoneMatrices = FilePath.Animator.FinalBoneMatrices;
		if (finalBoneMatrices == null || finalBoneMatrices.Length == 0)
		{
			return;
		}
		int num = Math.Min(class238_0.Length, Math.Min(vertexBuffer_0.Length, int_1.Length));
		for (int i = 0; i < num; i++)
		{
			Class238 @class = class238_0[i];
			if (@class == null || !@class.bool_0 || vertexBuffer_0[i] == null || ((DisposeBase)vertexBuffer_0[i]).IsDisposed || @class.vector3f_0 == null || @class.vector3f_1 == null || @class.float_0 == null || @class.float_1 == null || @class.int_0 == null)
			{
				continue;
			}
			int val = int_1[i];
			val = Math.Min(val, Math.Min(@class.vector3f_0.Length, @class.vector3f_1.Length));
			val = Math.Min(val, @class.float_0.Length / 2);
			if (val <= 0)
			{
				continue;
			}
			Struct65[] array = new Struct65[val];
			for (int j = 0; j < val; j++)
			{
				Vector3f vector3f_ = @class.vector3f_0[j];
				Vector3f vector3f_2 = @class.vector3f_1[j];
				Vector3f vector3f = new Vector3f(0f, 0f, 0f);
				Vector3f vector3f2 = new Vector3f(0f, 0f, 0f);
				int num2 = j * 4;
				for (int k = 0; k < 4; k++)
				{
					float num3 = @class.float_1[num2 + k];
					if (!(num3 <= 0.0001f))
					{
						int num4 = @class.int_0[num2 + k];
						if (num4 >= 0 && num4 < finalBoneMatrices.Length)
						{
							Matrix4x4 matrix4x = finalBoneMatrices[num4];
							Vector3f vector3f3 = matrix4x.TransformPoint(vector3f_);
							vector3f += vector3f3 * num3;
							Vector3f vector3f4 = matrix4x.TransformVector(vector3f_2);
							vector3f2 += vector3f4 * num3;
						}
					}
				}
				array[j].vector3_0 = new Vector3(vector3f.float_0, vector3f.float_1, vector3f.float_2);
				array[j].vector3_1 = new Vector3(vector3f2.float_0, vector3f2.float_1, vector3f2.float_2);
				array[j].float_0 = @class.float_0[j * 2];
				array[j].float_1 = @class.float_0[j * 2 + 1];
			}
			try
			{
				DataStream val2 = vertexBuffer_0[i].Lock(0, 0, (LockFlags)8192);
				try
				{
					val2.WriteRange<Struct65>(array);
				}
				finally
				{
					((Stream)(object)val2).Dispose();
					vertexBuffer_0[i].Unlock();
				}
			}
			catch
			{
			}
		}
	}

	private void method_7(pwMeshContainer pwMeshContainer_1, pwObject pwObject_0, int int_9)
	{
		if (pwMeshContainer_1 == null || pwObject_0 == null || texture_0 == null || int_9 < 0 || int_9 >= texture_0.Length)
		{
			return;
		}
		if (device_0 != null && !((DisposeBase)device_0).IsDisposed)
		{
			try
			{
				int textureIndex = pwObject_0.TextureIndex;
				if (pwMeshContainer_1.Textures != null && textureIndex >= 0 && textureIndex < pwMeshContainer_1.Textures.Length)
				{
					pwTextures pwTextures2 = pwMeshContainer_1.Textures[textureIndex];
					if (pwTextures2 != null && pwTextures2.TexFileName != null && pwTextures2.TexFileName.Length != 0)
					{
						string text = Encoding.GetEncoding(936).GetString(pwTextures2.TexFileName);
						int num = text.IndexOf('\0');
						if (num >= 0)
						{
							text = text.Substring(0, num);
						}
						text = text.Trim().ToLower();
						if (!string.IsNullOrEmpty(text) && FilePath != null && FilePath.DDSIMAGE != null && FilePath.DDSIMAGE.TryGetValue(text, out var value) && value != null && value.Length != 0)
						{
							Texture obj = texture_0[int_9];
							if (obj != null)
							{
								((DisposeBase)obj).Dispose();
							}
							MemoryStream memoryStream = new MemoryStream(value, writable: false);
							try
							{
								texture_0[int_9] = Texture.FromStream(device_0, (Stream)memoryStream, 0, 0, 0, (Usage)0, (Format)0, (Pool)1, (Filter)524292, (Filter)524292, 0);
								return;
							}
							finally
							{
								((IDisposable)memoryStream).Dispose();
							}
						}
					}
				}
				return;
			}
			catch (SharpDXException)
			{
				texture_0[int_9] = null;
				return;
			}
			catch (IOException)
			{
				texture_0[int_9] = null;
				return;
			}
			catch (ArgumentException)
			{
				texture_0[int_9] = null;
				return;
			}
			catch (InvalidOperationException)
			{
				texture_0[int_9] = null;
				return;
			}
			catch (NotSupportedException)
			{
				texture_0[int_9] = null;
				return;
			}
			catch (Exception ex6)
			{
				if (ex6 is DllNotFoundException)
				{
					texture_0[int_9] = null;
				}
				else
				{
					SentryHelper.CaptureException(ex6, Class16.smethod_0(1649119370));
				}
				return;
			}
		}
		texture_0[int_9] = null;
	}

	private void method_8(object sender, EventArgs e)
	{
	}

	private void method_9()
	{
		method_45();
	}

	protected override void OnMouseDown(MouseEventArgs mouseEventArgs_0)
	{
		base.OnMouseDown(mouseEventArgs_0);
		Focus();
		point_1 = mouseEventArgs_0.Location;
		if (mouseEventArgs_0.Button == MouseButtons.Right)
		{
			bool_6 = true;
			point_2 = mouseEventArgs_0.Location;
			bool_8 = false;
		}
		else if (mouseEventArgs_0.Button == MouseButtons.Left)
		{
			bool_7 = true;
		}
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		base.OnMouseUp(mevent);
		if (mevent.Button == MouseButtons.Right)
		{
			bool_6 = false;
		}
		else if (mevent.Button == MouseButtons.Left)
		{
			bool_7 = false;
		}
	}

	protected override void OnMouseMove(MouseEventArgs mea)
	{
		base.OnMouseMove(mea);
		int num = mea.X - point_1.X;
		int num2 = mea.Y - point_1.Y;
		point_1 = mea.Location;
		if (bool_6)
		{
			if (!bool_8 && (Math.Abs(mea.X - point_2.X) > 3 || Math.Abs(mea.Y - point_2.Y) > 3))
			{
				bool_8 = true;
			}
			float num3 = (float)num * 0.012f;
			float num4 = (float)num2 * 0.009f;
			float_10 += (num3 - float_10) * 0.45f;
			float_11 += (num4 - float_11) * 0.45f;
			float_7 += float_10;
			float_8 += float_11;
			float_8 = Math.Max(-1.5f, Math.Min(1.5f, float_8));
		}
		else
		{
			float_10 = 0f;
			float_11 = 0f;
		}
		if (bool_7)
		{
			float num5 = Math.Max(0.005f, float_6 * 0.0018f);
			float num6 = (float)Math.Cos(float_7);
			float num7 = (float)Math.Sin(float_7);
			vector3_0.X += ((float)(-num) * num6 + (float)num2 * num7) * num5;
			vector3_0.Z += ((float)(-num) * num7 - (float)num2 * num6) * num5;
		}
	}

	protected override void OnMouseWheel(MouseEventArgs mouseEventArgs_0)
	{
		base.OnMouseWheel(mouseEventArgs_0);
		method_10(mouseEventArgs_0.Delta);
	}

	private void comboBox_2_MouseWheel(object sender, MouseEventArgs e)
	{
		method_10(e.Delta);
		((HandledMouseEventArgs)e).Handled = true;
	}

	private void method_10(int int_9)
	{
		float num = ((int_9 > 0) ? 0.9f : 1.1f);
		float_6 *= num;
		float_6 = Math.Max(0.5f, Math.Min(500f, float_6));
	}

	protected override void OnKeyDown(KeyEventArgs keyEventArgs_0)
	{
		base.OnKeyDown(keyEventArgs_0);
		if (!Focused)
		{
			return;
		}
		switch (keyEventArgs_0.KeyCode)
		{
		case Keys.Home:
			method_23();
			keyEventArgs_0.Handled = true;
			break;
		case Keys.Space:
			if (bool_0)
			{
				button_0_Click(null, null);
				keyEventArgs_0.Handled = true;
			}
			break;
		case Keys.Tab:
			method_52();
			keyEventArgs_0.Handled = true;
			break;
		default:
			method_24(keyEventArgs_0.KeyCode, bool_25: true);
			break;
		case Keys.L:
			if (checkBox_0 != null)
			{
				checkBox_0.Checked = !checkBox_0.Checked;
			}
			else
			{
				bool_15 = !bool_15;
			}
			keyEventArgs_0.Handled = true;
			break;
		case Keys.G:
			if (checkBox_1 != null)
			{
				checkBox_1.Checked = !checkBox_1.Checked;
			}
			else
			{
				bool_22 = !bool_22;
			}
			keyEventArgs_0.Handled = true;
			break;
		case Keys.F:
			if (checkBox_2 != null)
			{
				checkBox_2.Checked = !checkBox_2.Checked;
			}
			else
			{
				bool_16 = !bool_16;
			}
			keyEventArgs_0.Handled = true;
			break;
		}
	}

	protected override void OnKeyUp(KeyEventArgs keyEventArgs_0)
	{
		base.OnKeyUp(keyEventArgs_0);
		method_24(keyEventArgs_0.KeyCode, bool_25: false);
	}

	protected override bool IsInputKey(Keys keyData)
	{
		if (smethod_1(keyData & Keys.KeyCode))
		{
			return true;
		}
		return base.IsInputKey(keyData);
	}

	protected override void OnMouseEnter(EventArgs eventArgs_0)
	{
	}

	private void BuildInModelView_Load(object sender, EventArgs e)
	{
	}

	private void BuildInModelView_Paint(object sender, PaintEventArgs e)
	{
	}

	protected override void OnResize(EventArgs eventArgs_0)
	{
		base.OnResize(eventArgs_0);
		if (base.IsDisposed)
		{
			return;
		}
		if (base.WindowState == FormWindowState.Minimized)
		{
			bool_5 = true;
			method_53();
			method_11();
			return;
		}
		if (timer_1 == null)
		{
			timer_1 = new Timer
			{
				Interval = 100
			};
			timer_1.Tick += timer_1_Tick;
		}
		timer_1.Stop();
		timer_1.Start();
		method_53();
		method_11();
	}

	private void method_11()
	{
		if (comboBox_0 != null)
		{
			comboBox_0.Location = new Point(10, base.ClientSize.Height - 90);
		}
		if (button_0 != null)
		{
			button_0.Location = new Point(220, base.ClientSize.Height - 90);
		}
		if (trackBar_0 != null)
		{
			trackBar_0.Location = new Point(10, base.ClientSize.Height - 55);
		}
		if (label_1 != null)
		{
			label_1.Location = new Point(370, base.ClientSize.Height - 55);
		}
		if (label_0 != null)
		{
			label_0.Location = new Point(10, base.ClientSize.Height - 30);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			method_42();
			timer_0?.Stop();
			timer_0?.Dispose();
			stopwatch_0?.Stop();
			timer_1?.Stop();
			timer_1?.Dispose();
			method_16();
			method_3();
			method_4(null);
			method_36();
			method_62();
			method_2();
			method_1();
			method_25();
			try
			{
				VertexDeclaration obj = vertexDeclaration_0;
				if (obj != null)
				{
					((DisposeBase)obj).Dispose();
				}
			}
			catch
			{
			}
			try
			{
				Device obj3 = device_0;
				if (obj3 != null)
				{
					((DisposeBase)obj3).Dispose();
				}
			}
			catch
			{
			}
			try
			{
				Direct3D obj5 = direct3D_0;
				if (obj5 != null)
				{
					((DisposeBase)obj5).Dispose();
				}
			}
			catch
			{
			}
			try
			{
				components?.Dispose();
			}
			catch
			{
			}
		}
		base.Dispose(disposing);
	}

	private void method_12()
	{
		SuspendLayout();
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = SystemColors.WindowFrame;
		base.ClientSize = new Size(584, 561);
		base.Icon = Resources.edit;
		MinimumSize = new Size(520, 420);
		base.KeyPreview = true;
		base.Name = Class16.smethod_0(1649119409);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649119432);
		base.TopMost = false;
		base.Load += BuildInModelView_Load;
		base.Paint += BuildInModelView_Paint;
		ResumeLayout(performLayout: false);
	}

	private void method_13()
	{
		if (device_0 != null && !((DisposeBase)device_0).IsDisposed)
		{
			try
			{
				gfxRenderer_0?.Dispose();
				gfxRenderer_0 = new GfxRenderer(device_0);
			}
			catch (Exception)
			{
			}
		}
	}

	public void LoadGfxEffects(Func<string, byte[]> gfxFileLoader = null)
	{
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		if (gfxRenderer_0 == null || FilePath?.ECM == null)
		{
			return;
		}
		gfxRenderer_0.ClearEffects(releaseTextures: true);
		list_0.Clear();
		ECMModel eCM = FilePath.ECM;
		if (eCM.Events == null)
		{
			return;
		}
		foreach (EcmEvent @event in eCM.Events)
		{
			if (string.IsNullOrEmpty(@event.Path))
			{
				continue;
			}
			string text = @event.Path.Trim().ToLowerInvariant();
			if (!text.EndsWith(Class16.smethod_0(1649119451), StringComparison.OrdinalIgnoreCase))
			{
				continue;
			}
			try
			{
				GfxEffect gfxEffect = null;
				if (gfxFileLoader != null)
				{
					byte[] array = gfxFileLoader(text);
					if (array != null && array.Length != 0)
					{
						string content = Encoding.GetEncoding(936).GetString(array);
						GfxFileReader gfxFileReader_ = new GfxFileReader(content);
						gfxEffect = new GfxEffect
						{
							FilePath = text
						};
						gfxEffect.Load(gfxFileReader_);
					}
				}
				if (gfxEffect == null && !string.IsNullOrEmpty(eCM.FilePath))
				{
					string path = System.IO.Path.GetDirectoryName(eCM.FilePath) ?? string.Empty;
					string text2 = System.IO.Path.Combine(path, text);
					if (File.Exists(text2))
					{
						gfxEffect = GfxEffect.LoadFromFile(text2);
					}
				}
				if (gfxEffect != null)
				{
					if (gfxFileLoader != null)
					{
						method_14(gfxEffect, gfxFileLoader);
					}
					GfxRenderer.GfxEffectInstance item = gfxRenderer_0.AddEffect(gfxEffect, Vector3.Zero);
					list_0.Add(item);
				}
			}
			catch (Exception)
			{
			}
		}
	}

	private void method_14(GfxEffect gfxEffect_0, Func<string, byte[]> func_0)
	{
		if (gfxRenderer_0 == null || func_0 == null)
		{
			return;
		}
		foreach (string texturePath in gfxEffect_0.GetTexturePaths())
		{
			if (string.IsNullOrEmpty(texturePath) || gfxRenderer_0.GetTexture(texturePath) != null)
			{
				continue;
			}
			try
			{
				byte[] array = func_0(texturePath);
				if (array != null && array.Length != 0)
				{
					gfxRenderer_0.LoadTexture(texturePath, array);
				}
			}
			catch
			{
			}
		}
	}

	private void method_15()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		if (gfxRenderer_0 == null || list_0.Count == 0)
		{
			return;
		}
		try
		{
			Matrix viewMatrix = method_20();
			Matrix projMatrix = method_19();
			Vector3 cameraPos = method_18();
			Matrix val = Matrix.RotationYawPitchRoll(float_5, float_4, 0f);
			if (bool_0)
			{
				val = Matrix.RotationX(-(float)Math.PI / 2f) * val;
			}
			foreach (GfxRenderer.GfxEffectInstance item in list_0)
			{
				item.Transform = val;
			}
			gfxRenderer_0.RenderEffects(viewMatrix, projMatrix, cameraPos);
		}
		catch (Exception)
		{
		}
	}

	private void method_16()
	{
		try
		{
			gfxRenderer_0?.Dispose();
			gfxRenderer_0 = null;
			list_0.Clear();
		}
		catch
		{
		}
	}

	private void method_17()
	{
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_9 && !bool_10 && !bool_11 && !bool_12 && !bool_13 && !bool_14)
		{
			int_3 = Environment.TickCount;
			return;
		}
		int tickCount = Environment.TickCount;
		if (int_3 <= 0)
		{
			int_3 = tickCount;
			return;
		}
		int num = tickCount - int_3;
		if (num < 0)
		{
			num = 0;
		}
		float num2 = Math.Max(0f, Math.Min(0.07f, (float)num / 1000f));
		int_3 = tickCount;
		if (!(num2 <= 0f))
		{
			float num3 = 2f + float_6 * 0.5f;
			float num4 = (((Control.ModifierKeys & Keys.Shift) != Keys.None) ? (num3 * 3f) : num3);
			Vector3 val = default(Vector3);
			val = new Vector3((float)Math.Cos(float_7), 0f, (float)Math.Sin(float_7));
			if (val.LengthSquared() > 1E-06f)
			{
				val.Normalize();
			}
			Vector3 val2 = default(Vector3);
			val2 = new Vector3(val.Z, 0f, 0f - val.X);
			Vector3 val3 = Vector3.Zero;
			if (bool_9)
			{
				val3 -= val;
			}
			if (bool_10)
			{
				val3 += val;
			}
			if (bool_12)
			{
				val3 -= val2;
			}
			if (bool_11)
			{
				val3 += val2;
			}
			if (bool_13)
			{
				val3 += Vector3.UnitY;
			}
			if (bool_14)
			{
				val3 -= Vector3.UnitY;
			}
			if (!(val3.LengthSquared() <= 1E-06f))
			{
				val3.Normalize();
				vector3_0 += val3 * (num4 * num2);
			}
		}
	}

	private Vector3 method_18()
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		float num = (float)Math.Cos(float_8);
		float num2 = (float)Math.Sin(float_8);
		float num3 = (float)Math.Cos(float_7);
		float num4 = (float)Math.Sin(float_7);
		return new Vector3(vector3_0.X + float_6 * num * num3, vector3_0.Y + float_6 * num2, vector3_0.Z + float_6 * num * num4);
	}

	private Matrix method_19()
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		float num = ((base.ClientSize.Height == 0) ? 1f : ((float)base.ClientSize.Width / (float)base.ClientSize.Height));
		float num2 = Math.Max(0.05f, float_6 * 0.001f);
		float num3 = Math.Max(500f, float_6 * 20f);
		return Matrix.PerspectiveFovLH(float_9, num, num2, num3);
	}

	private Matrix method_20()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		return Matrix.LookAtLH(method_18(), vector3_0, Vector3.UnitY);
	}

	private void method_21()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		if (device_0 != null && !((DisposeBase)device_0).IsDisposed)
		{
			device_0.SetTransform((TransformState)3, (method_19()));
			device_0.SetTransform((TransformState)2, (method_20()));
		}
	}

	private void method_22()
	{
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		if (vertexBuffer_0 == null || class238_0 == null)
		{
			return;
		}
		Vector3 val = default(Vector3);
		val = new Vector3(float.MaxValue);
		Vector3 val2 = default(Vector3);
		val2 = new Vector3(float.MinValue);
		int num = 0;
		for (int i = 0; i < class238_0.Length; i++)
		{
			Class238 @class = class238_0[i];
			if (@class?.vector3f_0 != null)
			{
				for (int j = 0; j < @class.vector3f_0.Length; j++)
				{
					Vector3f vector3f = @class.vector3f_0[j];
					val.X = Math.Min(val.X, vector3f.float_0);
					val.Y = Math.Min(val.Y, vector3f.float_1);
					val.Z = Math.Min(val.Z, vector3f.float_2);
					val2.X = Math.Max(val2.X, vector3f.float_0);
					val2.Y = Math.Max(val2.Y, vector3f.float_1);
					val2.Z = Math.Max(val2.Z, vector3f.float_2);
					num++;
				}
			}
		}
		if (num != 0)
		{
			vector3_0 = (val + val2) * 0.5f;
			Vector3 val3 = val2 - val;
			float num2 = val3.Length() * 0.5f;
			float_6 = Math.Max(2f, num2 * 2.5f);
			float_7 = 0.8f;
			float_8 = -0.15f;
		}
	}

	private void method_23()
	{
		method_22();
		int_3 = Environment.TickCount;
	}

	private void method_24(Keys keys_0, bool bool_25)
	{
		switch (keys_0)
		{
		case Keys.ControlKey:
		case Keys.Down:
			bool_14 = bool_25;
			break;
		case Keys.A:
			bool_11 = bool_25;
			break;
		case Keys.D:
			bool_12 = bool_25;
			break;
		case Keys.Up:
		case Keys.E:
		case Keys.Q:
			bool_13 = bool_25;
			break;
		case Keys.W:
			bool_9 = bool_25;
			break;
		case Keys.S:
			bool_10 = bool_25;
			break;
		}
	}

	private static bool smethod_1(Keys keys_0)
	{
		if (keys_0 != Keys.W && keys_0 != Keys.A && keys_0 != Keys.S && keys_0 != Keys.D && keys_0 != Keys.Q && keys_0 != Keys.E && keys_0 != Keys.Up)
		{
			return keys_0 == Keys.Down;
		}
		return true;
	}

	private void method_25()
	{
		bool_14 = false;
		bool_13 = false;
		bool_12 = false;
		bool_11 = false;
		bool_10 = false;
		bool_9 = false;
	}

	private void method_26(bool bool_25)
	{
		if (bool_4 || base.IsDisposed || !base.IsHandleCreated)
		{
			return;
		}
		if (base.WindowState != FormWindowState.Minimized && base.ClientSize.Width > 0 && base.ClientSize.Height > 0)
		{
			int tickCount = Environment.TickCount;
			if (!bool_25)
			{
				int num = tickCount - int_2;
				if (num >= 0 && num < 60)
				{
					bool_5 = true;
					return;
				}
			}
			bool_4 = true;
			bool_5 = false;
			bool_19 = false;
			bool flag;
			if (flag = bool_17)
			{
				method_42();
			}
			try
			{
				bool flag2;
				if (!(flag2 = !bool_25 && method_27()))
				{
					flag2 = method_28();
				}
				bool_19 = flag2;
				if (bool_19)
				{
					int_2 = tickCount;
					int_3 = tickCount;
				}
				return;
			}
			finally
			{
				bool_4 = false;
				if (flag && bool_19 && !base.IsDisposed)
				{
					method_41();
				}
			}
		}
		bool_5 = true;
	}

	private bool method_27()
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		if (device_0 != null && !((DisposeBase)device_0).IsDisposed)
		{
			try
			{
				method_30();
				presentParameters_0.BackBufferWidth = Math.Max(1, base.ClientSize.Width);
				presentParameters_0.BackBufferHeight = Math.Max(1, base.ClientSize.Height);
				presentParameters_0.PresentationInterval = (PresentInterval)(bool_21 ? 1 : int.MinValue);
				device_0.Reset((PresentParameters[])(object)new PresentParameters[1] { presentParameters_0 });
				method_29();
				return true;
			}
			catch
			{
				return false;
			}
		}
		return false;
	}

	private bool method_28()
	{
		try
		{
			method_32();
			if (device_0 != null && !((DisposeBase)device_0).IsDisposed)
			{
				if (pwMeshContainer_0 != null)
				{
					method_3();
					MakePWModelx(pwMeshContainer_0);
					if (bool_0)
					{
						method_6();
					}
				}
				LoadGfxEffects();
				return true;
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	private void method_29()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		VertexDeclaration obj = vertexDeclaration_0;
		if (obj != null)
		{
			((DisposeBase)obj).Dispose();
		}
		vertexDeclaration_0 = new VertexDeclaration(device_0, vertexElement_0);
		method_33();
		method_34();
		method_31();
	}

	private void method_30()
	{
		if (class238_0 == null || vertexBuffer_0 == null)
		{
			return;
		}
		for (int i = 0; i < class238_0.Length; i++)
		{
			Class238 obj = class238_0[i];
			if (obj != null && obj.bool_0 && vertexBuffer_0[i] != null)
			{
				try
				{
					((DisposeBase)vertexBuffer_0[i]).Dispose();
				}
				catch
				{
				}
				vertexBuffer_0[i] = null;
			}
		}
	}

	private void method_31()
	{
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		if (device_0 == null || ((DisposeBase)device_0).IsDisposed || class238_0 == null || vertexBuffer_0 == null)
		{
			return;
		}
		int num = Math.Min(class238_0.Length, vertexBuffer_0.Length);
		for (int i = 0; i < num; i++)
		{
			Class238 @class = class238_0[i];
			if (@class == null || !@class.bool_0 || @class.vector3f_0 == null || @class.vector3f_1 == null || @class.float_0 == null)
			{
				continue;
			}
			int val = Math.Min(@class.vector3f_0.Length, @class.vector3f_1.Length);
			val = Math.Min(val, @class.float_0.Length / 2);
			if (val <= 0)
			{
				continue;
			}
			try
			{
				VertexBuffer obj = vertexBuffer_0[i];
				if (obj != null)
				{
					((DisposeBase)obj).Dispose();
				}
			}
			catch
			{
			}
			vertexBuffer_0[i] = new VertexBuffer(device_0, val * Struct65.int_0, (Usage)520, (VertexFormat)0, (Pool)0);
			Struct65[] array = new Struct65[val];
			for (int j = 0; j < val; j++)
			{
				array[j].vector3_0 = new Vector3(@class.vector3f_0[j].float_0, @class.vector3f_0[j].float_1, @class.vector3f_0[j].float_2);
				array[j].vector3_1 = new Vector3(@class.vector3f_1[j].float_0, @class.vector3f_1[j].float_1, @class.vector3f_1[j].float_2);
				array[j].float_0 = @class.float_0[j * 2];
				array[j].float_1 = @class.float_0[j * 2 + 1];
			}
			DataStream val2 = vertexBuffer_0[i].Lock(0, 0, (LockFlags)8192);
			try
			{
				val2.WriteRange<Struct65>(array);
			}
			finally
			{
				((Stream)(object)val2).Dispose();
				vertexBuffer_0[i].Unlock();
			}
		}
	}

	private void method_32()
	{
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		bool_19 = false;
		bool_5 = false;
		method_42();
		method_36();
		try
		{
			Device obj = device_0;
			if (obj != null)
			{
				((DisposeBase)obj).Dispose();
			}
		}
		catch
		{
		}
		try
		{
			Direct3D obj3 = direct3D_0;
			if (obj3 != null)
			{
				((DisposeBase)obj3).Dispose();
			}
		}
		catch
		{
		}
		device_0 = null;
		direct3D_0 = null;
		if (base.ClientSize.Width <= 0 || base.ClientSize.Height <= 0)
		{
			return;
		}
		direct3D_0 = new Direct3D();
		int num = smethod_2(direct3D_0);
		presentParameters_0 = new PresentParameters
		{
			Windowed = (true),
			SwapEffect = (SwapEffect)1,
			BackBufferFormat = (Format)22,
			BackBufferWidth = Math.Max(1, base.ClientSize.Width),
			BackBufferHeight = Math.Max(1, base.ClientSize.Height),
			EnableAutoDepthStencil = (true),
			AutoDepthStencilFormat = (Format)75,
			PresentationInterval = (PresentInterval)(bool_21 ? 1 : int.MinValue),
			DeviceWindowHandle = base.Handle,
			MultiSampleType = (MultisampleType)num,
			MultiSampleQuality = 0
		};
		try
		{
			device_0 = new Device(direct3D_0, 0, (DeviceType)1, base.Handle, (CreateFlags)68, (PresentParameters[])(object)new PresentParameters[1] { presentParameters_0 });
		}
		catch
		{
			try
			{
				device_0 = new Device(direct3D_0, 0, (DeviceType)1, base.Handle, (CreateFlags)36, (PresentParameters[])(object)new PresentParameters[1] { presentParameters_0 });
			}
			catch
			{
				return;
			}
		}
		device_0.SetRenderState<FillMode>((RenderState)8, (FillMode)3);
		device_0.SetRenderState((RenderState)26, true);
		device_0.SetRenderState((RenderState)176, true);
		device_0.SetRenderState((RenderState)161, num > 0);
		device_0.SetRenderState((RenderState)141, true);
		device_0.SetRenderState<ColorSource>((RenderState)145, (ColorSource)0);
		device_0.SetRenderState<ColorSource>((RenderState)147, (ColorSource)0);
		device_0.SetRenderState<ColorSource>((RenderState)146, (ColorSource)0);
		device_0.SetRenderState<ColorSource>((RenderState)148, (ColorSource)0);
		method_33();
		VertexDeclaration obj7 = vertexDeclaration_0;
		if (obj7 != null)
		{
			((DisposeBase)obj7).Dispose();
		}
		vertexDeclaration_0 = new VertexDeclaration(device_0, vertexElement_0);
		method_34();
		method_13();
		bool_19 = true;
	}

	private static int smethod_2(Direct3D direct3D_1)
	{
		int[] array = new int[3] { 8, 4, 2 };
		int result = default(int);
		foreach (int num in array)
		{
			try
			{
				if (direct3D_1.CheckDeviceMultisampleType(0, (DeviceType)1, (Format)22, true, (MultisampleType)num, out result) && direct3D_1.CheckDeviceMultisampleType(0, (DeviceType)1, (Format)75, true, (MultisampleType)num, out result))
				{
					result = num;
					return result;
				}
			}
			catch
			{
			}
		}
		return 0;
	}

	private void method_33()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if (device_0 == null || ((DisposeBase)device_0).IsDisposed)
		{
			return;
		}
		int num = 16;
		TextureFilter val = (TextureFilter)3;
		try
		{
			device_0.SetSamplerState(0, (SamplerState)10, num);
		}
		catch
		{
			num = 1;
			val = (TextureFilter)2;
		}
		for (int i = 0; i < 4; i++)
		{
			try
			{
				device_0.SetSamplerState(i, (SamplerState)6, val);
			}
			catch
			{
			}
			try
			{
				device_0.SetSamplerState(i, (SamplerState)5, val);
			}
			catch
			{
			}
			try
			{
				device_0.SetSamplerState(i, (SamplerState)7, (TextureFilter)2);
			}
			catch
			{
			}
			try
			{
				device_0.SetSamplerState(i, (SamplerState)10, num);
			}
			catch
			{
			}
			try
			{
				device_0.SetSamplerState(i, (SamplerState)1, (TextureAddress)1);
			}
			catch
			{
			}
			try
			{
				device_0.SetSamplerState(i, (SamplerState)2, (TextureAddress)1);
			}
			catch
			{
			}
			try
			{
				device_0.SetSamplerState(i, (SamplerState)11, 1);
			}
			catch
			{
			}
		}
		try
		{
			device_0.SetRenderState((RenderState)194, true);
		}
		catch
		{
		}
	}

	private void method_34()
	{
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected O, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		method_36();
		if (device_0 != null && !((DisposeBase)device_0).IsDisposed)
		{
			float num = Math.Max(10f, float_6 * 3f);
			float num2 = Math.Max(0.5f, num / 40f);
			int num3 = (int)(num / num2);
			float num4 = (float)num3 * num2 * 0.5f;
			int num5 = (num3 + 1) * 4;
			Struct66[] array = new Struct66[num5];
			int num6 = 0;
			int num7 = -11513771;
			int num8 = -13290184;
			int num9 = -7659488;
			int num10 = -14671733;
			for (int i = 0; i <= num3; i++)
			{
				float num11 = 0f - num4 + (float)i * num2;
				bool flag;
				int num12 = ((flag = Math.Abs(num11) < num2 * 0.1f) ? num10 : ((i % 5 == 0) ? num7 : num8));
				array[num6++] = new Struct66
				{
					vector3_0 = new Vector3(num11, 0f, 0f - num4),
					int_0 = num12
				};
				array[num6++] = new Struct66
				{
					vector3_0 = new Vector3(num11, 0f, num4),
					int_0 = num12
				};
				num12 = (flag ? num9 : ((i % 5 == 0) ? num7 : num8));
				array[num6++] = new Struct66
				{
					vector3_0 = new Vector3(0f - num4, 0f, num11),
					int_0 = num12
				};
				array[num6++] = new Struct66
				{
					vector3_0 = new Vector3(num4, 0f, num11),
					int_0 = num12
				};
			}
			int_8 = num6;
			vertexBuffer_1 = new VertexBuffer(device_0, int_8 * Struct66.int_1, (Usage)0, (VertexFormat)66, (Pool)1);
			DataStream val = vertexBuffer_1.Lock(0, 0, (LockFlags)0);
			try
			{
				val.WriteRange<Struct66>(array, 0, int_8);
			}
			finally
			{
				((Stream)(object)val).Dispose();
				vertexBuffer_1.Unlock();
			}
		}
	}

	private void method_35()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		if (device_0 != null && !((DisposeBase)device_0).IsDisposed && vertexBuffer_1 != null && !((DisposeBase)vertexBuffer_1).IsDisposed && int_8 >= 2)
		{
			device_0.SetTransform((TransformState)256, (Matrix.Identity));
			device_0.SetRenderState((RenderState)137, false);
			device_0.SetTexture(0, (BaseTexture)null);
			device_0.SetRenderState((RenderState)27, true);
			device_0.SetRenderState<Blend>((RenderState)19, (Blend)5);
			device_0.SetRenderState<Blend>((RenderState)20, (Blend)6);
			device_0.VertexFormat = (VertexFormat)66;
			device_0.SetTextureStageState(0, (TextureStage)1, (TextureOperation)2);
			device_0.SetTextureStageState(0, (TextureStage)2, (TextureArgument)0);
			device_0.SetTextureStageState(0, (TextureStage)4, (TextureOperation)2);
			device_0.SetTextureStageState(0, (TextureStage)5, (TextureArgument)0);
			device_0.SetTextureStageState(1, (TextureStage)1, (TextureOperation)1);
			device_0.SetStreamSource(0, vertexBuffer_1, 0, Struct66.int_1);
			device_0.DrawPrimitives((PrimitiveType)2, 0, int_8 / 2);
			device_0.SetRenderState((RenderState)27, false);
			if (bool_15)
			{
				device_0.SetRenderState((RenderState)137, true);
			}
		}
	}

	private void method_36()
	{
		try
		{
			VertexBuffer obj = vertexBuffer_1;
			if (obj != null)
			{
				((DisposeBase)obj).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_1 = null;
		int_8 = 0;
	}

	private void BuildInModelView_Activated(object sender, EventArgs e)
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_BuildInModelView != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this);
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_BuildInModelView = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}

	private void method_37(int int_9)
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		int_4 = int_9;
		switch (int_9)
		{
		case 0:
			method_38(Color.FromArgb(65, 65, 70), 0.35f, Color.White, 1f, Color.FromArgb(211, 211, 211), 0.8f, 25f, new Vector3(0.5f, -0.5f, 1f));
			break;
		case 1:
			method_38(Color.FromArgb(140, 150, 170), 0.5f, Color.FromArgb(255, 250, 230), 1.2f, Color.FromArgb(255, 255, 240), 1f, 30f, new Vector3(0.3f, -0.8f, 0.5f));
			break;
		case 2:
			method_38(Color.FromArgb(80, 50, 40), 0.3f, Color.FromArgb(255, 180, 100), 1f, Color.FromArgb(255, 200, 150), 0.6f, 20f, new Vector3(0.8f, -0.2f, 0.5f));
			break;
		case 3:
			method_38(Color.FromArgb(20, 25, 45), 0.25f, Color.FromArgb(150, 170, 230), 0.7f, Color.FromArgb(180, 190, 255), 0.5f, 35f, new Vector3(-0.3f, -0.9f, 0.3f));
			break;
		case 4:
			method_38(Color.FromArgb(25, 25, 30), 0.15f, Color.FromArgb(100, 100, 110), 0.5f, Color.FromArgb(60, 60, 70), 0.3f, 15f, new Vector3(0.5f, -0.5f, 1f));
			break;
		case 5:
			method_38(Color.FromArgb(90, 90, 95), 0.45f, Color.White, 1f, Color.White, 0.9f, 30f, new Vector3(0f, 0f, 1f));
			break;
		case 6:
			method_38(Color.FromArgb(30, 30, 35), 0.2f, Color.FromArgb(200, 210, 255), 0.8f, Color.White, 1.2f, 50f, new Vector3(-0.5f, -0.3f, -1f));
			break;
		}
	}

	private void method_38(Color color_5, float float_18, Color color_6, float float_19, Color color_7, float float_20, float float_21, Vector3 vector3_2)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		color_0 = color_5;
		float_12 = float_18;
		color_1 = color_6;
		float_13 = float_19;
		color_2 = color_7;
		float_14 = float_20;
		float_15 = float_21;
		vector3_1 = vector3_2;
	}

	private void method_39()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		if (device_0 == null || ((DisposeBase)device_0).IsDisposed)
		{
			return;
		}
		if (!bool_15)
		{
			device_0.SetRenderState((RenderState)137, false);
			return;
		}
		Vector3 val = vector3_1;
		if (val.LengthSquared() > 0.0001f)
		{
			val.Normalize();
		}
		Light val2 = new Light
		{
			Type = (LightType)3,
			Diffuse = smethod_3(color_1, float_13),
			Specular = smethod_3(color_2, float_14),
			Direction = (val)
		};
		device_0.SetLight(0, ref val2);
		device_0.EnableLight(0, (true));
		Light val3 = new Light
		{
			Type = (LightType)3,
			Diffuse = smethod_3(color_1, float_13 * 0.4f),
			Direction = (new Vector3(0f - val.X, val.Y * 0.5f, 0f - val.Z))
		};
		device_0.SetLight(1, ref val3);
		device_0.EnableLight(1, (true));
		Light val4 = new Light
		{
			Type = (LightType)3,
			Diffuse = smethod_3(color_1, float_13 * 0.3f),
			Direction = (new Vector3(0f, 0.3f, 0f - val.Z))
		};
		device_0.SetLight(2, ref val4);
		device_0.EnableLight(2, (true));
		device_0.SetRenderState((RenderState)137, true);
		device_0.SetRenderState((RenderState)29, float_14 > 0.01f);
		device_0.SetRenderState((RenderState)143, true);
		device_0.SetRenderState((RenderState)142, true);
		byte b = (byte)Math.Max(0, Math.Min(255, (int)((float)(int)color_0.R * float_12)));
		byte b2 = (byte)Math.Max(0, Math.Min(255, (int)((float)(int)color_0.G * float_12)));
		byte b3 = (byte)Math.Max(0, Math.Min(255, (int)((float)(int)color_0.B * float_12)));
		device_0.SetRenderState((RenderState)139, -16777216 | (b << 16) | (b2 << 8) | b3);
		material_0 = new Material
		{
			Diffuse = new RawColor4(1f, 1f, 1f, 1f),
			Specular = new RawColor4((float)(int)color_2.R / 255f, (float)(int)color_2.G / 255f, (float)(int)color_2.B / 255f, 1f),
			Ambient = new RawColor4(1f, 1f, 1f, 1f),
			Power = float_15
		};
		device_0.Material = material_0;
	}

	private static RawColor4 smethod_3(Color color_5, float float_18)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		return new RawColor4((float)(int)color_5.R / 255f * float_18, (float)(int)color_5.G / 255f * float_18, (float)(int)color_5.B / 255f * float_18, 1f);
	}

	private void method_40()
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		if (device_0 != null && !((DisposeBase)device_0).IsDisposed)
		{
			if (!bool_16)
			{
				device_0.SetRenderState((RenderState)28, false);
				return;
			}
			float num = Math.Max(1f, float_16);
			float value = Math.Max(num + 10f, float_17);
			device_0.SetRenderState((RenderState)28, true);
			Device obj = device_0;
			ColorBGRA val = new ColorBGRA(color_3.R, color_3.G, color_3.B, byte.MaxValue);
			obj.SetRenderState((RenderState)34, val.ToBgra());
			device_0.SetRenderState<FogMode>((RenderState)35, (FogMode)3);
			device_0.SetRenderState((RenderState)36, BitConverter.ToInt32(BitConverter.GetBytes(num), 0));
			device_0.SetRenderState((RenderState)37, BitConverter.ToInt32(BitConverter.GetBytes(value), 0));
		}
	}

	private void method_41()
	{
		if (!bool_17)
		{
			bool_17 = true;
			int_3 = Environment.TickCount;
			int_5 = 0;
			int_6 = Environment.TickCount;
			int_7 = -1;
			Application.Idle += method_43;
		}
	}

	private void method_42()
	{
		bool_17 = false;
		Application.Idle -= method_43;
	}

	private void method_43(object sender, EventArgs e)
	{
		if (!bool_17 || !bool_19 || bool_18 || bool_4 || device_0 == null || ((DisposeBase)device_0).IsDisposed || base.IsDisposed || !base.Visible || base.WindowState == FormWindowState.Minimized)
		{
			return;
		}
		bool_18 = true;
		try
		{
			if (bool_5)
			{
				method_26(bool_25: false);
				if (!bool_19)
				{
					return;
				}
			}
			method_17();
			method_44();
			method_45();
		}
		finally
		{
			bool_18 = false;
		}
	}

	private void method_44()
	{
		if (!bool_0 || bool_3 || FilePath?.Animator == null)
		{
			return;
		}
		float num = (float)stopwatch_0.ElapsedMilliseconds / 1000f;
		float deltaTime = num - float_1;
		float_1 = num;
		FilePath.UpdateAnimation(deltaTime);
		method_6();
		if (label_1 != null && FilePath.Animator.Duration > 0f)
		{
			label_1.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649119470), Class16.smethod_0(1649119485)), FilePath.Animator.AnimationTime, FilePath.Animator.Duration);
			if (trackBar_0 != null && !trackBar_0.Capture)
			{
				int val = (int)(FilePath.Animator.AnimationTime / FilePath.Animator.Duration * 1000f);
				trackBar_0.Value = Math.Max(0, Math.Min(1000, val));
			}
		}
	}

	private void method_45()
	{
		//IL_01f9: Expected O, but got Unknown
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		if (device_0 == null || ((DisposeBase)device_0).IsDisposed || !bool_19)
		{
			return;
		}
		try
		{
			device_0.TestCooperativeLevel();
		}
		catch (SharpDXException ex)
		{
			SharpDXException ex2 = ex;
			if (!(ex2.ResultCode == (ResultCode.DeviceLost)) && ex2.ResultCode == (ResultCode.DeviceNotReset))
			{
				method_26(bool_25: false);
			}
			return;
		}
		bool flag = false;
		try
		{
			device_0.Clear((ClearFlags)3, new RawColorBGRA(color_4.B, color_4.G, color_4.R, byte.MaxValue), 1f, 0);
			device_0.BeginScene();
			flag = true;
			method_21();
			method_39();
			method_40();
			if (bool_22 && vertexBuffer_1 != null && !((DisposeBase)vertexBuffer_1).IsDisposed)
			{
				method_35();
			}
			Matrix val = Matrix.RotationYawPitchRoll(float_5, float_4, 0f);
			if (bool_0)
			{
				val = Matrix.RotationX(-(float)Math.PI / 2f) * val;
			}
			device_0.SetTransform((TransformState)256, (val));
			device_0.SetRenderState<Cull>((RenderState)22, (Cull)1);
			device_0.SetRenderState((RenderState)7, true);
			device_0.SetRenderState((RenderState)14, true);
			device_0.SetRenderState<Compare>((RenderState)23, (Compare)4);
			device_0.SetRenderState<FillMode>((RenderState)8, (FillMode)(bool_23 ? 2 : 3));
			method_46();
			if (vertexDeclaration_0 != null && !((DisposeBase)vertexDeclaration_0).IsDisposed)
			{
				device_0.VertexDeclaration = vertexDeclaration_0;
			}
			method_47();
			if (bool_23)
			{
				device_0.SetRenderState<FillMode>((RenderState)8, (FillMode)3);
			}
			method_15();
			device_0.EndScene();
			flag = false;
			device_0.Present();
			method_48();
		}
		catch (SharpDXException ex3)
		{
			SharpDXException ex4 = ex3;
			if (!(ex4.ResultCode == (ResultCode.DeviceLost)) && ex4.ResultCode == (ResultCode.DeviceNotReset))
			{
				method_26(bool_25: false);
			}
		}
		catch
		{
		}
		finally
		{
			if (flag)
			{
				try
				{
					device_0.EndScene();
				}
				catch
				{
				}
			}
		}
	}

	private void method_46()
	{
		device_0.SetTextureStageState(0, (TextureStage)1, (TextureOperation)4);
		device_0.SetTextureStageState(0, (TextureStage)2, (TextureArgument)2);
		device_0.SetTextureStageState(0, (TextureStage)3, (TextureArgument)0);
		device_0.SetTextureStageState(0, (TextureStage)4, (TextureOperation)4);
		device_0.SetTextureStageState(0, (TextureStage)5, (TextureArgument)2);
		device_0.SetTextureStageState(0, (TextureStage)6, (TextureArgument)0);
	}

	private void method_47()
	{
		//IL_0178: Expected O, but got Unknown
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		if (vertexBuffer_0 == null || indexBuffer_0 == null || int_0 == null || int_1 == null)
		{
			return;
		}
		int val = Math.Min(vertexBuffer_0.Length, indexBuffer_0.Length);
		val = Math.Min(val, Math.Min(int_0.Length, int_1.Length));
		for (int i = 0; i < val; i++)
		{
			if (bool_4)
			{
				break;
			}
			if (device_0 == null)
			{
				break;
			}
			if (((DisposeBase)device_0).IsDisposed)
			{
				break;
			}
			if (vertexBuffer_0[i] == null || ((DisposeBase)vertexBuffer_0[i]).IsDisposed || indexBuffer_0[i] == null || ((DisposeBase)indexBuffer_0[i]).IsDisposed)
			{
				continue;
			}
			int num = int_0[i];
			int num2 = int_1[i];
			if (num < 3 || num2 <= 0)
			{
				continue;
			}
			int num3 = num / 3;
			if (num3 <= 0)
			{
				continue;
			}
			Texture val2 = ((texture_0 == null || i >= texture_0.Length) ? null : texture_0[i]);
			if (val2 != null && ((DisposeBase)val2).IsDisposed)
			{
				val2 = null;
			}
			try
			{
				device_0.SetTexture(0, (BaseTexture)(object)val2);
				device_0.SetStreamSource(0, vertexBuffer_0[i], 0, Struct65.int_0);
				device_0.Indices = indexBuffer_0[i];
				device_0.DrawIndexedPrimitive((PrimitiveType)4, 0, 0, num2, 0, num3);
			}
			catch (SharpDXException ex)
			{
				SharpDXException ex2 = ex;
				if (!(ex2.ResultCode == (ResultCode.DeviceLost)) && !(ex2.ResultCode == (ResultCode.DeviceNotReset)))
				{
					continue;
				}
				bool_5 = true;
				break;
			}
		}
	}

	private void method_48()
	{
		int tickCount = Environment.TickCount;
		int_5++;
		int num = tickCount - int_6;
		if (num >= 500)
		{
			int_7 = (int)Math.Round((double)int_5 * (1000.0 / (double)Math.Max(1, num)));
			int_5 = 0;
			int_6 = tickCount;
			method_49();
		}
	}

	private void method_49()
	{
		if (!base.InvokeRequired)
		{
			string text = Text;
			int num = text.IndexOf(Class16.smethod_0(1648961184), StringComparison.Ordinal);
			if (num >= 0)
			{
				text = text.Substring(0, num);
			}
			Text = ((!bool_20 || int_7 < 0) ? text : string.Format(Class16.smethod_0(1649119508), text, int_7));
		}
	}

	private void method_50()
	{
		button_3 = method_57(Class16.smethod_0(1649119520), 28);
		button_3.Click += button_3_Click;
		base.Controls.Add(button_3);
		button_2 = method_57(Class16.smethod_0(1649119529), 28);
		button_2.Click += button_2_Click;
		base.Controls.Add(button_2);
		panel_0 = new Panel
		{
			Size = new Size(220, 420),
			BackColor = Color.FromArgb(40, 40, 45),
			AutoScroll = true,
			Visible = false,
			BorderStyle = BorderStyle.FixedSingle
		};
		base.Controls.Add(panel_0);
		int int_ = 8;
		method_58(Class16.smethod_0(1649119538), 8, ref int_, 200, bool_25: true, bool_26: true);
		label_6 = method_58(Class16.smethod_0(1649119560), 8, ref int_, 60, bool_25: false, bool_26: false);
		comboBox_1 = new ComboBox
		{
			Location = new Point(70, label_6.Top - 2),
			Size = new Size(140, 22),
			DropDownStyle = ComboBoxStyle.DropDownList,
			BackColor = Color.FromArgb(55, 55, 60),
			ForeColor = Color.White,
			FlatStyle = FlatStyle.Flat
		};
		ComboBox.ObjectCollection items = comboBox_1.Items;
		object[] items2 = string_0;
		items.AddRange(items2);
		comboBox_1.SelectedIndex = 0;
		comboBox_1.SelectedIndexChanged += comboBox_1_SelectedIndexChanged;
		comboBox_1.MouseWheel += comboBox_2_MouseWheel;
		panel_0.Controls.Add(comboBox_1);
		int_ = comboBox_1.Bottom + 6;
		checkBox_0 = method_60(Class16.smethod_0(1649119576), ref int_, bool_25: false);
		checkBox_0.CheckedChanged += checkBox_0_CheckedChanged;
		label_2 = method_58(Class16.smethod_0(1649119606), 8, ref int_, 200, bool_25: false, bool_26: true);
		trackBar_1 = method_59(ref int_, 0, 100, 35, 8);
		trackBar_1.Scroll += trackBar_1_Scroll;
		label_3 = method_58(Class16.smethod_0(1649119617), 8, ref int_, 200, bool_25: false, bool_26: true);
		trackBar_2 = method_59(ref int_, 0, 150, 100, 8);
		trackBar_2.Scroll += trackBar_2_Scroll;
		label_4 = method_58(Class16.smethod_0(1649119645), 8, ref int_, 200, bool_25: false, bool_26: true);
		trackBar_3 = method_59(ref int_, 0, 150, 80, 8);
		trackBar_3.Scroll += trackBar_3_Scroll;
		label_5 = method_58(Class16.smethod_0(1649119657), 8, ref int_, 200, bool_25: false, bool_26: true);
		trackBar_4 = method_59(ref int_, 1, 100, 25, 8);
		trackBar_4.Scroll += trackBar_4_Scroll;
		method_61(ref int_);
		checkBox_1 = method_60(Class16.smethod_0(1649119686), ref int_, bool_25: false);
		checkBox_1.CheckedChanged += checkBox_1_CheckedChanged;
		checkBox_3 = method_60(Class16.smethod_0(1649119702), ref int_, bool_25: false);
		checkBox_3.CheckedChanged += checkBox_3_CheckedChanged;
		checkBox_2 = method_60(Class16.smethod_0(1649119718), ref int_, bool_25: false);
		checkBox_2.CheckedChanged += checkBox_2_CheckedChanged;
		label_7 = method_58(Class16.smethod_0(1649119735), 20, ref int_, 190, bool_25: false, bool_26: true);
		trackBar_5 = method_59(ref int_, 1, 200, 30, 20);
		trackBar_5.Enabled = false;
		trackBar_5.Scroll += trackBar_5_Scroll;
		trackBar_6 = method_59(ref int_, 10, 500, 200, 20);
		trackBar_6.Enabled = false;
		trackBar_6.Scroll += trackBar_6_Scroll;
		method_61(ref int_);
		checkBox_4 = method_60(Class16.smethod_0(1649122816), ref int_, bool_25: true);
		checkBox_4.CheckedChanged += checkBox_4_CheckedChanged;
		checkBox_5 = method_60(Class16.smethod_0(1649122836), ref int_, bool_25: true);
		checkBox_5.CheckedChanged += checkBox_5_CheckedChanged;
		button_1 = new Button
		{
			Text = Class16.smethod_0(1649122843),
			Location = new Point(8, int_),
			Size = new Size(200, 24),
			FlatStyle = FlatStyle.Flat,
			BackColor = Color.FromArgb(55, 55, 60),
			ForeColor = Color.White
		};
		button_1.FlatAppearance.BorderColor = Color.FromArgb(80, 80, 85);
		button_1.Click += button_1_Click;
		panel_0.Controls.Add(button_1);
		int_ += 30;
		method_51(ref int_);
		panel_0.Size = new Size(220, Math.Min(int_ + 10, 520));
		method_53();
	}

	private void method_51(ref int int_9)
	{
		Class239 @class = new Class239();
		@class.buildInModelView_0 = this;
		@class.skinModelData_0 = FilePath?.ECM?.SMD;
		if (@class.skinModelData_0?.Animations == null || @class.skinModelData_0.Animations.Count == 0)
		{
			return;
		}
		method_61(ref int_9);
		method_58(Class16.smethod_0(1649122877), 8, ref int_9, 200, bool_25: false, bool_26: true);
		comboBox_2 = new ComboBox
		{
			Location = new Point(8, int_9),
			Size = new Size(200, 22),
			DropDownStyle = ComboBoxStyle.DropDownList,
			BackColor = Color.FromArgb(55, 55, 60),
			ForeColor = Color.White,
			FlatStyle = FlatStyle.Flat
		};
		foreach (SkinModelAction animation in @class.skinModelData_0.Animations)
		{
			string text = (string.IsNullOrEmpty(animation.Name) ? Class16.smethod_0(1648936686) : animation.Name);
			comboBox_2.Items.Add(string.Format(Class16.smethod_0(1649122890), text, animation.StartFrame, animation.EndFrame, animation.FrameRate));
		}
		comboBox_2.SelectedIndexChanged += @class.method_0;
		comboBox_2.MouseWheel += comboBox_2_MouseWheel;
		panel_0.Controls.Add(comboBox_2);
		int_9 += 28;
	}

	private void method_52()
	{
		if (panel_0 != null)
		{
			panel_0.Visible = !panel_0.Visible;
			panel_0.BringToFront();
		}
	}

	private void method_53()
	{
		if (button_3 != null)
		{
			button_3.Location = new Point(base.ClientSize.Width - 34, 4);
		}
		if (button_2 != null)
		{
			button_2.Location = new Point(base.ClientSize.Width - 66, 4);
		}
		if (panel_0 != null)
		{
			panel_0.Location = new Point(base.ClientSize.Width - panel_0.Width - 4, 36);
		}
	}

	private void method_54()
	{
		if (trackBar_1 != null)
		{
			trackBar_1.Value = smethod_4((int)(float_12 * 100f), 0, 100);
			label_2.Text = string.Format(Class16.smethod_0(1649122932), trackBar_1.Value);
		}
		if (trackBar_2 != null)
		{
			trackBar_2.Value = smethod_4((int)(float_13 * 100f), 0, 150);
			label_3.Text = string.Format(Class16.smethod_0(1649122944), trackBar_2.Value);
		}
		if (trackBar_3 != null)
		{
			trackBar_3.Value = smethod_4((int)(float_14 * 100f), 0, 150);
			label_4.Text = string.Format(Class16.smethod_0(1649122972), trackBar_3.Value);
		}
		if (trackBar_4 != null)
		{
			trackBar_4.Value = smethod_4((int)float_15, 1, 100);
			label_5.Text = string.Format(Class16.smethod_0(1649122985), trackBar_4.Value);
		}
	}

	private void method_55()
	{
		if (comboBox_1 != null && comboBox_1.SelectedIndex != string_0.Length - 1)
		{
			bool_24 = true;
			comboBox_1.SelectedIndex = string_0.Length - 1;
			bool_24 = false;
		}
	}

	private void method_56()
	{
		bool_5 = true;
		method_26(bool_25: true);
		if (bool_19)
		{
			method_41();
		}
	}

	private static int smethod_4(int int_9, int int_10, int int_11)
	{
		if (int_9 >= int_10)
		{
			if (int_9 <= int_11)
			{
				return int_9;
			}
			return int_11;
		}
		return int_10;
	}

	private Button method_57(string string_1, int int_9)
	{
		Button button = new Button
		{
			Text = string_1,
			Size = new Size(int_9, int_9),
			FlatStyle = FlatStyle.Flat,
			Font = new Font(Class16.smethod_0(1648942905), 12f),
			BackColor = Color.FromArgb(55, 55, 60),
			ForeColor = Color.White,
			TabStop = false,
			Padding = new Padding(0),
			TextAlign = ContentAlignment.MiddleCenter
		};
		button.FlatAppearance.BorderSize = 0;
		button.MouseWheel += comboBox_2_MouseWheel;
		return button;
	}

	private Label method_58(string string_1, int int_9, ref int int_10, int int_11, bool bool_25, bool bool_26)
	{
		Label label = new Label
		{
			Text = string_1,
			Location = new Point(int_9, int_10),
			Size = new Size(int_11, 16),
			ForeColor = Color.FromArgb(190, 190, 195),
			Font = new Font(Class16.smethod_0(1648942905), 8f, bool_25 ? FontStyle.Bold : FontStyle.Regular)
		};
		panel_0.Controls.Add(label);
		if (bool_26)
		{
			int_10 += 18;
		}
		return label;
	}

	private TrackBar method_59(ref int int_9, int int_10, int int_11, int int_12, int int_13)
	{
		TrackBar trackBar = new TrackBar
		{
			Location = new Point(int_13, int_9),
			Size = new Size(190, 26),
			Minimum = int_10,
			Maximum = int_11,
			Value = int_12,
			TickFrequency = Math.Max(1, (int_11 - int_10) / 10),
			BackColor = Color.FromArgb(40, 40, 45)
		};
		trackBar.MouseWheel += comboBox_2_MouseWheel;
		panel_0.Controls.Add(trackBar);
		int_9 += 32;
		return trackBar;
	}

	private CheckBox method_60(string string_1, ref int int_9, bool bool_25)
	{
		CheckBox checkBox = new CheckBox
		{
			Text = string_1,
			Location = new Point(8, int_9),
			Size = new Size(200, 20),
			Checked = bool_25,
			ForeColor = Color.FromArgb(190, 190, 195),
			Font = new Font(Class16.smethod_0(1648942905), 8f),
			BackColor = Color.Transparent
		};
		checkBox.MouseWheel += comboBox_2_MouseWheel;
		panel_0.Controls.Add(checkBox);
		int_9 += 22;
		return checkBox;
	}

	private void method_61(ref int int_9)
	{
		panel_0.Controls.Add(new Label
		{
			Location = new Point(8, int_9),
			Size = new Size(200, 1),
			BackColor = Color.FromArgb(70, 70, 75)
		});
		int_9 += 8;
	}

	private void method_62()
	{
		smethod_5(panel_0);
		smethod_5(button_3);
		smethod_5(button_2);
		panel_0 = null;
		button_3 = null;
		button_2 = null;
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		timer_1.Stop();
		if (!base.IsDisposed && base.IsHandleCreated)
		{
			bool_5 = true;
			method_26(bool_25: false);
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		method_52();
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		method_23();
	}

	private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_24)
		{
			method_37(comboBox_1.SelectedIndex);
			method_54();
		}
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		bool_15 = checkBox_0.Checked;
	}

	private void trackBar_1_Scroll(object sender, EventArgs e)
	{
		float_12 = (float)trackBar_1.Value / 100f;
		label_2.Text = string.Format(Class16.smethod_0(1649122932), trackBar_1.Value);
		method_55();
	}

	private void trackBar_2_Scroll(object sender, EventArgs e)
	{
		float_13 = (float)trackBar_2.Value / 100f;
		label_3.Text = string.Format(Class16.smethod_0(1649122944), trackBar_2.Value);
		method_55();
	}

	private void trackBar_3_Scroll(object sender, EventArgs e)
	{
		float_14 = (float)trackBar_3.Value / 100f;
		label_4.Text = string.Format(Class16.smethod_0(1649122972), trackBar_3.Value);
		method_55();
	}

	private void trackBar_4_Scroll(object sender, EventArgs e)
	{
		float_15 = trackBar_4.Value;
		label_5.Text = string.Format(Class16.smethod_0(1649122985), trackBar_4.Value);
		method_55();
	}

	private void checkBox_1_CheckedChanged(object sender, EventArgs e)
	{
		bool_22 = checkBox_1.Checked;
	}

	private void checkBox_3_CheckedChanged(object sender, EventArgs e)
	{
		bool_23 = checkBox_3.Checked;
	}

	private void checkBox_2_CheckedChanged(object sender, EventArgs e)
	{
		bool_16 = checkBox_2.Checked;
		trackBar_5.Enabled = bool_16;
		trackBar_6.Enabled = bool_16;
	}

	private void trackBar_5_Scroll(object sender, EventArgs e)
	{
		float_16 = trackBar_5.Value;
		if (float_17 <= float_16)
		{
			float_17 = float_16 + 10f;
			trackBar_6.Value = (int)float_17;
		}
	}

	private void trackBar_6_Scroll(object sender, EventArgs e)
	{
		float_17 = trackBar_6.Value;
	}

	private void checkBox_4_CheckedChanged(object sender, EventArgs e)
	{
		bool_21 = checkBox_4.Checked;
		method_56();
	}

	private void checkBox_5_CheckedChanged(object sender, EventArgs e)
	{
		bool_20 = checkBox_5.Checked;
		if (!bool_20)
		{
			method_49();
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		using ColorDialog colorDialog = new ColorDialog
		{
			Color = color_4
		};
		if (colorDialog.ShowDialog() == DialogResult.OK)
		{
			color_4 = colorDialog.Color;
			if (bool_16)
			{
				color_3 = color_4;
			}
		}
	}

	[CompilerGenerated]
	internal static void smethod_5(IDisposable idisposable_0)
	{
		try
		{
			idisposable_0?.Dispose();
		}
		catch
		{
		}
	}
}
