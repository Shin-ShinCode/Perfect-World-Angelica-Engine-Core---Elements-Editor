using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Domain2;
using ACE.DynamicObjects;
using ACE.GFX;
using ACE.IconEditor;
using ACE.Path;
using ACE.Precint;
using ACE.Properties;
using ACE.RSGlobal;
using ACE.Region;
using SharpDX;
using SharpDX.Direct3D9;
using SharpDX.Mathematics.Interop;
// TODO(recovered): disambiguation aliases (decompiled file mixes SharpDX + System.Drawing).
using Color = System.Drawing.Color;
using Point = System.Drawing.Point;
using Matrix = SharpDX.Matrix;
using Blend = SharpDX.Direct3D9.Blend;
using Font = System.Drawing.Font;
using FillMode = SharpDX.Direct3D9.FillMode;
using Rectangle = System.Drawing.Rectangle;

namespace ACE.PWMap;

public class PwMapSharpDxEditorForm : Form, IPwMapChangeLogListener
{
	[StructLayout(LayoutKind.Auto)]
	private struct Struct73 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		public PwMapSharpDxEditorForm pwMapSharpDxEditorForm_0;

		private TaskAwaiter taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PwMapSharpDxEditorForm pwMapSharpDxEditorForm = pwMapSharpDxEditorForm_0;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = pwMapSharpDxEditorForm.method_122().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						int_0 = 0;
						taskAwaiter_0 = awaiter;
						asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = taskAwaiter_0;
					taskAwaiter_0 = default(TaskAwaiter);
					num = -1;
					int_0 = -1;
				}
				awaiter.GetResult();
			}
			catch (Exception exception)
			{
				int_0 = -2;
				asyncVoidMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			asyncVoidMethodBuilder_0.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private struct Struct74
	{
		public Vector3 vector3_0;

		public int int_0;

		public static readonly int int_1 = Marshal.SizeOf<Struct74>();
	}

	private sealed class Class300
	{
		public string string_0;

		public PwMapSharpDxEditorForm pwMapSharpDxEditorForm_0;

		internal void method_0(object sender, EventArgs e)
		{
			pwMapSharpDxEditorForm_0.toolStripDropDownButton_0.Text = string_0;
		}
	}

	private sealed class Class301
	{
		public Enum20 enum20_0;

		public int int_0;

		public string string_0 = string.Empty;

		public Vector3[] vector3_0 = Array.Empty<Vector3>();

		public Vector3 vector3_1;

		public Vector3 vector3_2;

		public Vector3 vector3_3;

		public float float_0;

		public string string_1 = string.Empty;

		public Class314 class314_0;
	}

	private sealed class Class302
	{
		private readonly string string_0;

		public Class302(string string_1)
		{
			string_0 = string_1 ?? string.Empty;
		}

		public string method_0()
		{
			return string_0;
		}

		public override string ToString()
		{
			return System.IO.Path.GetFileName(method_0());
		}
	}

	private enum Enum20
	{
		None,
		RegionPolygon,
		PrecinctPolygon,
		TransportBox,
		CityMarker,
		NpcMarker,
		LitModelObject,
		WaterArea,
		FloraMarker,
		LightMarker,
		GfxMarker
	}

	private sealed class Class303 : ISceneObjectList
	{
		private readonly List<Class314> list_0;

		public Class303(List<Class314> list_1)
		{
			list_0 = list_1;
		}

		public void AddFromSnapshot(SceneObjectSnapshot snap)
		{
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			list_0.Add(new Class314
			{
				string_0 = snap.Label,
				string_1 = snap.ResourcePath,
				vector3_0 = snap.Center,
				vector3_1 = snap.Extents,
				vector3_2 = snap.Rotation,
				vector3_3 = snap.Scale
			});
		}

		public void RemoveBySnapshot(SceneObjectSnapshot snap)
		{
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			int num = list_0.Count - 1;
			while (true)
			{
				if (num >= 0)
				{
					if (string.Equals(list_0[num].string_0, snap.Label, StringComparison.OrdinalIgnoreCase) && !(Vector3.DistanceSquared(list_0[num].vector3_0, snap.Center) >= 1f))
					{
						break;
					}
					num--;
					continue;
				}
				return;
			}
			list_0.RemoveAt(num);
		}
	}

	private struct Struct75
	{
		public bool bool_0;

		public string string_0;

		public float float_0;

		public float float_1;

		public float float_2;

		public int int_0;

		public int int_1;

		public int int_2;

		public float float_3;

		public float float_4;

		public float float_5;

		public bool bool_1;

		public int int_3;

		public int int_4;

		public static Struct75 smethod_0()
		{
			return new Struct75
			{
				bool_0 = false,
				string_0 = string.Empty,
				float_0 = 2f,
				float_1 = 2f,
				float_2 = 2f,
				int_0 = -1,
				int_1 = 1,
				int_2 = 1,
				float_3 = 0f,
				int_3 = 5,
				int_4 = 6
			};
		}

		public bool method_0()
		{
			if (int_1 <= 1 && int_2 <= 1)
			{
				return bool_1;
			}
			return true;
		}

		public bool method_1()
		{
			return int_4 == 2;
		}
	}

	private sealed class Class304
	{
		public bool bool_0;

		public PwMapSharpDxEditorForm pwMapSharpDxEditorForm_0;

		public string string_0;

		public PwMapTrn2File pwMapTrn2File_0;

		public bool bool_1;

		public RegionFile regionFile_0;

		public bool bool_2;

		public PrecinctFile precinctFile_0;

		public bool bool_3;

		public bool bool_4;

		public bool bool_5;

		public string string_1;

		public string string_2;

		public string string_3;

		public bool bool_6;

		public bool bool_7;

		public bool bool_8;

		public bool bool_9;

		internal Class310 method_0()
		{
			Class310 @class = new Class310();
			if (bool_0)
			{
				pwMapSharpDxEditorForm_0.method_158(10, Class16.smethod_0(1649084041));
				@class.int_0 = pwMapSharpDxEditorForm_0.method_159(string_0, pwMapTrn2File_0, out var int_);
				@class.int_1 = int_;
			}
			if (bool_1)
			{
				pwMapSharpDxEditorForm_0.method_158(25, Class16.smethod_0(1649084079));
				@class.bool_0 = smethod_17(string_0, regionFile_0);
			}
			if (bool_2)
			{
				pwMapSharpDxEditorForm_0.method_158(35, Class16.smethod_0(1649084097));
				@class.bool_1 = smethod_18(string_0, precinctFile_0);
			}
			if (bool_3)
			{
				pwMapSharpDxEditorForm_0.method_158(42, Class16.smethod_0(1649084133));
				@class.bool_2 = pwMapSharpDxEditorForm_0.method_160(string_0, pwMapTrn2File_0);
			}
			if (bool_4)
			{
				pwMapSharpDxEditorForm_0.method_158(50, Class16.smethod_0(1649084165));
				@class.int_2 = pwMapSharpDxEditorForm_0.method_151(string_0, pwMapTrn2File_0, out var int_2);
				@class.int_3 = int_2;
			}
			if (bool_5)
			{
				pwMapSharpDxEditorForm_0.method_158(60, Class16.smethod_0(1649084190));
				PwMapCollisionExportResolver pwMapCollisionExportResolver_ = PwMapCollisionExportResolver.Create(pwMapTrn2File_0, string_1, string_2, string_3);
				@class.string_0 = pwMapSharpDxEditorForm_0.method_154(string_0, pwMapTrn2File_0, pwMapCollisionExportResolver_);
				if (bool_6)
				{
					pwMapSharpDxEditorForm_0.method_158(75, Class16.smethod_0(1649084213));
					(@class.int_4, @class.int_5, @class.int_6) = pwMapSharpDxEditorForm_0.method_155(string_0, pwMapTrn2File_0, pwMapCollisionExportResolver_);
				}
			}
			else if (bool_6)
			{
				pwMapSharpDxEditorForm_0.method_158(75, Class16.smethod_0(1649084213));
				PwMapCollisionExportResolver pwMapCollisionExportResolver_2 = PwMapCollisionExportResolver.Create(pwMapTrn2File_0, string_1, string_2, string_3);
				(@class.int_4, @class.int_5, @class.int_6) = pwMapSharpDxEditorForm_0.method_155(string_0, pwMapTrn2File_0, pwMapCollisionExportResolver_2);
			}
			if (bool_7)
			{
				pwMapSharpDxEditorForm_0.method_158(85, Class16.smethod_0(1649084232));
				(@class.int_7, @class.int_8) = pwMapSharpDxEditorForm_0.method_148(string_0, pwMapTrn2File_0, bool_8);
			}
			if (bool_9)
			{
				pwMapSharpDxEditorForm_0.method_158(93, Class16.smethod_0(1649084268));
				int int_3 = (bool_8 ? pwMapSharpDxEditorForm_0.method_150(pwMapTrn2File_0) : 0);
				(@class.int_9, @class.int_10) = smethod_12(string_0, pwMapTrn2File_0, string_2, bool_8, int_3);
			}
			pwMapSharpDxEditorForm_0.method_158(100, Class16.smethod_0(1649084303));
			return @class;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct76 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		public PwMapSharpDxEditorForm pwMapSharpDxEditorForm_0;

		private TaskAwaiter taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PwMapSharpDxEditorForm pwMapSharpDxEditorForm = pwMapSharpDxEditorForm_0;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = taskAwaiter_0;
					taskAwaiter_0 = default(TaskAwaiter);
					num = -1;
					int_0 = -1;
					goto IL_00db;
				}
				if (pwMapSharpDxEditorForm.pwMapTrn2File_0 != null && pwMapSharpDxEditorForm.pwMapPassMapProfile_0 != null)
				{
					int num2 = pwMapSharpDxEditorForm.method_150(pwMapSharpDxEditorForm.pwMapTrn2File_0);
					if (num2 >= 0 && num2 < pwMapSharpDxEditorForm.pwMapTrn2File_0.TotalSectors)
					{
						awaiter = pwMapSharpDxEditorForm.method_187(num2, num2 + 1, string.Format(Class16.smethod_0(1649083122), num2)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							int_0 = 0;
							taskAwaiter_0 = awaiter;
							asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_00db;
					}
					pwMapSharpDxEditorForm.label_12.Text = TextStorage.Msg(Class16.smethod_0(1649083069), Class16.smethod_0(1649083102));
				}
				goto end_IL_000e;
				IL_00db:
				awaiter.GetResult();
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				int_0 = -2;
				asyncVoidMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			asyncVoidMethodBuilder_0.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private sealed class Class305
	{
		public string string_0;

		public int int_0;

		public PwMapSharpDxEditorForm pwMapSharpDxEditorForm_0;

		public int int_1;

		public int int_2;

		public int int_3;

		public PwMapTrn2File pwMapTrn2File_0;

		public PwMapPassMapProfile pwMapPassMapProfile_0;

		public int int_4;

		public int int_5;

		public int int_6;

		internal void method_0()
		{
			Directory.CreateDirectory(string_0);
			for (int i = int_0; i < int_6; i++)
			{
				pwMapSharpDxEditorForm_0.method_188(i, int_1, int_2, int_3, pwMapTrn2File_0, pwMapPassMapProfile_0, string_0);
				int_4++;
				int int_ = ((int_5 > 0) ? (int_4 * 100 / int_5) : 100);
				pwMapSharpDxEditorForm_0.method_158(int_, string.Format(Class16.smethod_0(1649084326), i + 1, int_4, int_5));
			}
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct77 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		public PwMapSharpDxEditorForm pwMapSharpDxEditorForm_0;

		private TaskAwaiter taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PwMapSharpDxEditorForm pwMapSharpDxEditorForm = pwMapSharpDxEditorForm_0;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = pwMapSharpDxEditorForm.method_122().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						int_0 = 0;
						taskAwaiter_0 = awaiter;
						asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = taskAwaiter_0;
					taskAwaiter_0 = default(TaskAwaiter);
					num = -1;
					int_0 = -1;
				}
				awaiter.GetResult();
			}
			catch (Exception exception)
			{
				int_0 = -2;
				asyncVoidMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			asyncVoidMethodBuilder_0.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private sealed class Class306
	{
		public PwMapSharpDxEditorForm pwMapSharpDxEditorForm_0;

		public int int_0;

		public string string_0;

		internal void method_0()
		{
			pwMapSharpDxEditorForm_0.method_87(int_0, bool_37: true);
			pwMapSharpDxEditorForm_0.method_120(string_0, null);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct78 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		public PwMapSharpDxEditorForm pwMapSharpDxEditorForm_0;

		public string string_0;

		public Action action_0;

		private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter configuredTaskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PwMapSharpDxEditorForm pwMapSharpDxEditorForm = pwMapSharpDxEditorForm_0;
			try
			{
				ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter;
				if (num != 0)
				{
					pwMapSharpDxEditorForm.method_179(string_0);
					awaiter = Task.Delay(10).ConfigureAwait(continueOnCapturedContext: true).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						int_0 = 0;
						configuredTaskAwaiter_0 = awaiter;
						asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = configuredTaskAwaiter_0;
					configuredTaskAwaiter_0 = default(ConfiguredTaskAwaitable.ConfiguredTaskAwaiter);
					num = -1;
					int_0 = -1;
				}
				awaiter.GetResult();
				Application.DoEvents();
				try
				{
					action_0?.Invoke();
				}
				catch (Exception ex)
				{
					SentryHelper.CaptureException(ex, Class16.smethod_0(1649082720));
					pwMapSharpDxEditorForm.method_120(Class16.smethod_0(1649082788) + ex.Message, null);
				}
			}
			catch (Exception exception)
			{
				int_0 = -2;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			asyncTaskMethodBuilder_0.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private sealed class Class307
	{
		public PwMapSharpDxEditorForm pwMapSharpDxEditorForm_0;

		public float float_0;

		public float float_1;

		public float float_2;

		internal void method_0()
		{
			pwMapSharpDxEditorForm_0.UpdateTerrainCursorInfo(float_0, float_1, float_2);
		}
	}

	private struct Struct79
	{
		public Vector3 vector3_0;

		public int int_0;

		public float float_0;

		public float float_1;

		public static readonly int int_1 = Marshal.SizeOf<Struct79>();
	}

	private sealed class Class308
	{
		public ToolStripMenuItem toolStripMenuItem_0;

		public PwMapSharpDxEditorForm pwMapSharpDxEditorForm_0;

		internal void method_0(object sender, EventArgs e)
		{
			pwMapSharpDxEditorForm_0.bool_7 = toolStripMenuItem_0.Checked;
			pwMapSharpDxEditorForm_0.method_120(pwMapSharpDxEditorForm_0.bool_7 ? Class16.smethod_0(1649084396) : Class16.smethod_0(1649084354), null);
		}
	}

	private static class Class309
	{
		public static Func<char, bool> func_0;
	}

	private sealed class Class310
	{
		public int int_0;

		public int int_1;

		public int int_2;

		public int int_3;

		public bool bool_0;

		public bool bool_1;

		public bool bool_2;

		public string string_0 = string.Empty;

		public int int_4;

		public int int_5;

		public int int_6;

		public int int_7;

		public int int_8;

		public int int_9;

		public int int_10;
	}

	private readonly struct Struct80(Vector3 vector3_1, float float_3, float float_4, float float_5)
	{
		public readonly Vector3 vector3_0 = vector3_1;

		public readonly float float_0 = float_3;

		public readonly float float_1 = float_4;

		public readonly float float_2 = float_5;

		public readonly bool bool_0 = true;
	}

	private sealed class Class311
	{
		public Panel panel_0;

		public PwMapSharpDxEditorForm pwMapSharpDxEditorForm_0;

		internal void method_0(object sender, EventArgs e)
		{
			using ColorDialog colorDialog = new ColorDialog
			{
				Color = panel_0.BackColor
			};
			if (colorDialog.ShowDialog(pwMapSharpDxEditorForm_0) == DialogResult.OK)
			{
				panel_0.BackColor = colorDialog.Color;
			}
		}
	}

	private sealed class Class312
	{
		public Panel panel_0;

		public PwMapSharpDxEditorForm pwMapSharpDxEditorForm_0;

		internal void method_0(object sender, EventArgs e)
		{
			using ColorDialog colorDialog = new ColorDialog
			{
				Color = panel_0.BackColor
			};
			if (colorDialog.ShowDialog(pwMapSharpDxEditorForm_0) == DialogResult.OK)
			{
				panel_0.BackColor = colorDialog.Color;
			}
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct81 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		public PwMapSharpDxEditorForm pwMapSharpDxEditorForm_0;

		private TaskAwaiter<PwMapFileLayout> taskAwaiter_0;

		private TaskAwaiter taskAwaiter_1;

		private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter configuredTaskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PwMapSharpDxEditorForm pwMapSharpDxEditorForm = pwMapSharpDxEditorForm_0;
			try
			{
				if ((uint)num <= 5u)
				{
					goto IL_005e;
				}
				if (!pwMapSharpDxEditorForm.bool_9)
				{
					pwMapSharpDxEditorForm.bool_9 = true;
					pwMapSharpDxEditorForm.pwMapDebugLogger_0?.Dispose();
					pwMapSharpDxEditorForm.pwMapDebugLogger_0 = null;
					PwMapAssetProvider.BeginLoadingSession();
					pwMapSharpDxEditorForm.method_178(Class16.smethod_0(1649083139), Class16.smethod_0(1649083165));
					goto IL_005e;
				}
				goto end_IL_000e;
				IL_005e:
				try
				{
					TaskAwaiter<PwMapFileLayout> awaiter6;
					TaskAwaiter awaiter5;
					TaskAwaiter awaiter4;
					ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter3;
					TaskAwaiter awaiter2;
					TaskAwaiter awaiter;
					PwMapFileLayout result;
					PwMapFileLayout pwMapFileLayout;
					switch (num)
					{
					default:
					{
						Class319 @class = new Class319();
						@class.string_0 = pwMapSharpDxEditorForm.method_118();
						pwMapSharpDxEditorForm.pwMapDebugLogger_0 = PwMapDebugLogger.Create(System.IO.Path.GetFileName(@class.string_0));
						pwMapSharpDxEditorForm.pwMapDebugLogger_0.BeginPhase(Class16.smethod_0(1649083185));
						pwMapSharpDxEditorForm.pwMapDebugLogger_0.Log(Class16.smethod_0(1649083214) + @class.string_0);
						awaiter6 = Task.Run((Func<PwMapFileLayout>)@class.method_0).GetAwaiter();
						if (!awaiter6.IsCompleted)
						{
							num = 0;
							int_0 = 0;
							taskAwaiter_0 = awaiter6;
							asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter6, ref this);
							return;
						}
						goto IL_013b;
					}
					case 0:
						awaiter6 = taskAwaiter_0;
						taskAwaiter_0 = default(TaskAwaiter<PwMapFileLayout>);
						num = -1;
						int_0 = -1;
						goto IL_013b;
					case 1:
						awaiter5 = taskAwaiter_1;
						taskAwaiter_1 = default(TaskAwaiter);
						num = -1;
						int_0 = -1;
						goto IL_0203;
					case 2:
						awaiter4 = taskAwaiter_1;
						taskAwaiter_1 = default(TaskAwaiter);
						num = -1;
						int_0 = -1;
						goto IL_0297;
					case 3:
						awaiter3 = configuredTaskAwaiter_0;
						configuredTaskAwaiter_0 = default(ConfiguredTaskAwaitable.ConfiguredTaskAwaiter);
						num = -1;
						int_0 = -1;
						goto IL_035f;
					case 4:
						awaiter2 = taskAwaiter_1;
						taskAwaiter_1 = default(TaskAwaiter);
						num = -1;
						int_0 = -1;
						goto IL_0405;
					case 5:
						{
							awaiter = taskAwaiter_1;
							taskAwaiter_1 = default(TaskAwaiter);
							num = -1;
							int_0 = -1;
							break;
						}
						IL_0203:
						awaiter5.GetResult();
						pwMapSharpDxEditorForm.pwMapDebugLogger_0.EndPhase();
						pwMapSharpDxEditorForm.pwMapDebugLogger_0.BeginPhase(Class16.smethod_0(1649083281));
						awaiter4 = pwMapSharpDxEditorForm.method_123(Class16.smethod_0(1649083308), pwMapSharpDxEditorForm.method_351).GetAwaiter();
						if (!awaiter4.IsCompleted)
						{
							num = 2;
							int_0 = 2;
							taskAwaiter_1 = awaiter4;
							asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter4, ref this);
							return;
						}
						goto IL_0297;
						IL_013b:
						result = awaiter6.GetResult();
						pwMapFileLayout = result;
						pwMapSharpDxEditorForm.pwMapFileLayout_0 = pwMapFileLayout ?? new PwMapFileLayout();
						pwMapSharpDxEditorForm.pwMapDebugLogger_0.LogDiscovery(pwMapSharpDxEditorForm.pwMapFileLayout_0);
						pwMapSharpDxEditorForm.pwMapDebugLogger_0.EndPhase();
						pwMapSharpDxEditorForm.method_124();
						pwMapSharpDxEditorForm.method_119();
						pwMapSharpDxEditorForm.pwMapDebugLogger_0.BeginPhase(Class16.smethod_0(1649083226));
						awaiter5 = pwMapSharpDxEditorForm.method_123(Class16.smethod_0(1649083248), pwMapSharpDxEditorForm.method_31).GetAwaiter();
						if (!awaiter5.IsCompleted)
						{
							num = 1;
							int_0 = 1;
							taskAwaiter_1 = awaiter5;
							asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter5, ref this);
							return;
						}
						goto IL_0203;
						IL_0297:
						awaiter4.GetResult();
						if (pwMapSharpDxEditorForm.pwMapTrn2File_0 != null)
						{
							pwMapSharpDxEditorForm.pwMapDebugLogger_0.LogTerrainInfo(pwMapSharpDxEditorForm.pwMapTrn2File_0);
						}
						else
						{
							pwMapSharpDxEditorForm.pwMapDebugLogger_0.LogWarning(Class16.smethod_0(1649083330));
						}
						pwMapSharpDxEditorForm.pwMapDebugLogger_0.EndPhase();
						pwMapSharpDxEditorForm.pwMapDebugLogger_0.BeginPhase(Class16.smethod_0(1649083385));
						pwMapSharpDxEditorForm.method_179(Class16.smethod_0(1649082384));
						awaiter3 = Task.Delay(5).ConfigureAwait(continueOnCapturedContext: true).GetAwaiter();
						if (!awaiter3.IsCompleted)
						{
							num = 3;
							int_0 = 3;
							configuredTaskAwaiter_0 = awaiter3;
							asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter3, ref this);
							return;
						}
						goto IL_035f;
						IL_035f:
						awaiter3.GetResult();
						pwMapSharpDxEditorForm.method_353();
						pwMapSharpDxEditorForm.method_365();
						pwMapSharpDxEditorForm.method_64();
						pwMapSharpDxEditorForm.pwMapDebugLogger_0.EndPhase();
						pwMapSharpDxEditorForm.pwMapDebugLogger_0.BeginPhase(Class16.smethod_0(1649082419));
						awaiter2 = pwMapSharpDxEditorForm.method_123(Class16.smethod_0(1649082442), pwMapSharpDxEditorForm.method_260).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = 4;
							int_0 = 4;
							taskAwaiter_1 = awaiter2;
							asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
							return;
						}
						goto IL_0405;
						IL_0405:
						awaiter2.GetResult();
						pwMapSharpDxEditorForm.pwMapDebugLogger_0.EndPhase();
						pwMapSharpDxEditorForm.pwMapDebugLogger_0.BeginPhase(Class16.smethod_0(1649082472));
						awaiter = pwMapSharpDxEditorForm.method_123(Class16.smethod_0(1649082488), pwMapSharpDxEditorForm.method_343).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 5;
							int_0 = 5;
							taskAwaiter_1 = awaiter;
							asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						break;
					}
					awaiter.GetResult();
					pwMapSharpDxEditorForm.pwMapDebugLogger_0.EndPhase();
					_ = Task.Run((Action)Class317.class317_0.method_6);
					pwMapSharpDxEditorForm.method_126();
					pwMapSharpDxEditorForm.method_49();
					pwMapSharpDxEditorForm.method_84();
					pwMapSharpDxEditorForm.pwMapDebugLogger_0.LogFinalSummary(pwMapSharpDxEditorForm.list_4.Count, pwMapSharpDxEditorForm.list_5.Count, pwMapSharpDxEditorForm.list_6.Count, pwMapSharpDxEditorForm.list_7.Count, pwMapSharpDxEditorForm.list_8.Count);
					pwMapSharpDxEditorForm.pwMapDebugLogger_0.Flush();
					if (pwMapSharpDxEditorForm.pwMapFileLayout_0.HasMapRoot)
					{
						pwMapSharpDxEditorForm.textBox_81.Text = pwMapSharpDxEditorForm.pwMapFileLayout_0.MapRootPath;
						if (!string.IsNullOrWhiteSpace(pwMapSharpDxEditorForm.pwMapFileLayout_0.MapName))
						{
							pwMapSharpDxEditorForm.textBox_80.Text = pwMapSharpDxEditorForm.pwMapFileLayout_0.MapName;
						}
						pwMapSharpDxEditorForm.method_120(Class16.smethod_0(1649082515), Class16.smethod_0(1649083522) + pwMapSharpDxEditorForm.pwMapFileLayout_0.MapName);
					}
					else
					{
						pwMapSharpDxEditorForm.method_120(Class16.smethod_0(1649082542), Class16.smethod_0(1649082562));
					}
				}
				catch (Exception ex)
				{
					pwMapSharpDxEditorForm.pwMapDebugLogger_0?.LogError(Class16.smethod_0(1649082588), ex);
					pwMapSharpDxEditorForm.pwMapDebugLogger_0?.Flush();
					SentryHelper.CaptureException(ex, Class16.smethod_0(1649082623));
					pwMapSharpDxEditorForm.method_120(Class16.smethod_0(1649082685) + ex.Message, Class16.smethod_0(1649082709));
				}
				finally
				{
					if (num < 0)
					{
						PwMapAssetProvider.EndLoadingSession();
						pwMapSharpDxEditorForm.method_183();
						pwMapSharpDxEditorForm.bool_9 = false;
					}
				}
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				int_0 = -2;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			asyncTaskMethodBuilder_0.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private sealed class Class313
	{
		public VertexBuffer vertexBuffer_0;

		public int int_0;

		public Texture texture_0;

		public bool bool_0;

		public Vector3 vector3_0;

		public float float_0;

		public int int_1;

		public int int_2;

		public float float_1;

		public float float_2;

		public float float_3;

		public int int_3;

		public int int_4;

		public bool method_0()
		{
			if (int_1 <= 1 && int_2 <= 1 && float_2 == 0f)
			{
				return float_3 != 0f;
			}
			return true;
		}
	}

	private sealed class Class314
	{
		public string string_0 = string.Empty;

		public string string_1 = string.Empty;

		public Vector3 vector3_0;

		public Vector3 vector3_1;

		public Vector3 vector3_2;

		public Vector3 vector3_3 = new Vector3(1f, 1f, 1f);

		public SceneObjectSnapshot method_0()
		{
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			return new SceneObjectSnapshot
			{
				Label = string_0,
				ResourcePath = string_1,
				Center = vector3_0,
				Extents = vector3_1,
				Rotation = vector3_2,
				Scale = vector3_3
			};
		}
	}

	private sealed class Class315
	{
		public string string_0;

		public int int_0;

		public PwMapSharpDxEditorForm pwMapSharpDxEditorForm_0;

		internal void method_0(object sender, EventArgs e)
		{
			pwMapSharpDxEditorForm_0.toolStripDropDownButton_0.Text = string_0;
			PrecinctEntry precinctEntry = pwMapSharpDxEditorForm_0.precinctFile_0.zones[int_0];
			if (precinctEntry?.m_vCityPos != null)
			{
				float single_ = precinctEntry.m_vCityPos.Single_0;
				float float_ = precinctEntry.m_vCityPos.Single_1 + 20f;
				float float_2 = 0f - precinctEntry.m_vCityPos.Single_2;
				pwMapSharpDxEditorForm_0.method_86(single_, float_, float_2);
				pwMapSharpDxEditorForm_0.method_120(Class16.smethod_0(1649084028) + string_0, null);
			}
		}
	}

	private sealed class Class316
	{
		public string[] string_0;

		public int int_0;

		public Func<string, bool> func_0;

		internal bool method_0(string string_1)
		{
			return string.Equals(System.IO.Path.GetFileNameWithoutExtension(string_1), string_0[int_0], StringComparison.OrdinalIgnoreCase);
		}
	}

	[Serializable]
	private sealed class Class317
	{
		public static readonly Class317 class317_0 = new Class317();

		public static EventHandler eventHandler_0;

		public static EventHandler eventHandler_1;

		public static EventHandler eventHandler_2;

		public static EventHandler eventHandler_3;

		public static Func<(float, float), float> func_0;

		public static Func<(float, float), float> func_1;

		public static Action action_0;

		public static Func<string, string> func_2;

		public static Func<(float, float), float> func_3;

		public static Func<(float, float), float> func_4;

		public static Func<(float, float), float> func_5;

		public static Func<(float, float), float> func_6;

		internal void method_0(object sender, EventArgs e)
		{
		}

		internal void method_1(object sender, EventArgs e)
		{
		}

		internal void method_2(object sender, EventArgs e)
		{
		}

		internal void method_3(object sender, EventArgs e)
		{
		}

		internal float method_4((float, float) valueTuple_0)
		{
			return valueTuple_0.Item1;
		}

		internal float method_5((float, float) valueTuple_0)
		{
			return valueTuple_0.Item2;
		}

		internal void method_6()
		{
			PwMapAddObjectDialog.EnsureCacheLoaded();
		}

		internal string method_7(string string_0)
		{
			return (string_0 ?? string.Empty).Trim();
		}

		internal float method_8((float, float) valueTuple_0)
		{
			return valueTuple_0.Item1;
		}

		internal float method_9((float, float) valueTuple_0)
		{
			return valueTuple_0.Item2;
		}

		internal float method_10((float, float) valueTuple_0)
		{
			return valueTuple_0.Item1;
		}

		internal float method_11((float, float) valueTuple_0)
		{
			return valueTuple_0.Item2;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct82 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		public int int_1;

		public PwMapSharpDxEditorForm pwMapSharpDxEditorForm_0;

		public int int_2;

		public string string_0;

		private Class305 class305_0;

		private TaskAwaiter taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PwMapSharpDxEditorForm pwMapSharpDxEditorForm = pwMapSharpDxEditorForm_0;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = taskAwaiter_0;
					taskAwaiter_0 = default(TaskAwaiter);
					num = -1;
					int_0 = -1;
					goto IL_0224;
				}
				class305_0 = new Class305();
				class305_0.int_0 = int_1;
				class305_0.pwMapSharpDxEditorForm_0 = pwMapSharpDxEditorForm_0;
				class305_0.int_6 = int_2;
				class305_0.pwMapTrn2File_0 = pwMapSharpDxEditorForm.pwMapTrn2File_0;
				if (class305_0.pwMapTrn2File_0 != null)
				{
					class305_0.pwMapPassMapProfile_0 = pwMapSharpDxEditorForm.pwMapPassMapProfile_0;
					if (class305_0.pwMapPassMapProfile_0 != null)
					{
						pwMapSharpDxEditorForm.button_14.Enabled = false;
						pwMapSharpDxEditorForm.button_15.Enabled = false;
						pwMapSharpDxEditorForm.label_12.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649083899), Class16.smethod_0(1649082898)), string_0);
						pwMapSharpDxEditorForm.method_87(0, bool_37: true);
						string path = pwMapSharpDxEditorForm.method_147();
						class305_0.string_0 = System.IO.Path.Combine(pwMapSharpDxEditorForm.method_146(), path, Class16.smethod_0(1649082922));
						class305_0.int_1 = smethod_11(class305_0.pwMapTrn2File_0);
						class305_0.int_2 = Math.Max(1, (int)(class305_0.pwMapTrn2File_0.Width / (float)class305_0.pwMapTrn2File_0.SectorsWide));
						class305_0.int_3 = Math.Max(1, (int)(class305_0.pwMapTrn2File_0.Height / (float)class305_0.pwMapTrn2File_0.SectorsHigh));
						class305_0.int_5 = class305_0.int_6 - class305_0.int_0;
						class305_0.int_4 = 0;
						awaiter = Task.Run((Action)class305_0.method_0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							int_0 = 0;
							taskAwaiter_0 = awaiter;
							asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_0224;
					}
				}
				goto end_IL_000e;
				IL_0224:
				awaiter.GetResult();
				pwMapSharpDxEditorForm.button_14.Enabled = true;
				pwMapSharpDxEditorForm.button_15.Enabled = true;
				pwMapSharpDxEditorForm.method_87(0, bool_37: false);
				pwMapSharpDxEditorForm.label_12.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649082936), Class16.smethod_0(1649082982)), string_0, class305_0.int_5, class305_0.string_0);
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				int_0 = -2;
				class305_0 = null;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			class305_0 = null;
			asyncTaskMethodBuilder_0.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private sealed class Class318
	{
		public Panel panel_0;

		internal void method_0(object sender, EventArgs e)
		{
			using ColorDialog colorDialog = new ColorDialog
			{
				Color = panel_0.BackColor,
				FullOpen = true
			};
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				panel_0.BackColor = colorDialog.Color;
			}
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct83 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		public PwMapSharpDxEditorForm pwMapSharpDxEditorForm_0;

		private TaskAwaiter taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PwMapSharpDxEditorForm pwMapSharpDxEditorForm = pwMapSharpDxEditorForm_0;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = taskAwaiter_0;
					taskAwaiter_0 = default(TaskAwaiter);
					num = -1;
					int_0 = -1;
					goto IL_008a;
				}
				if (pwMapSharpDxEditorForm.pwMapTrn2File_0 != null && pwMapSharpDxEditorForm.pwMapPassMapProfile_0 != null)
				{
					awaiter = pwMapSharpDxEditorForm.method_187(0, pwMapSharpDxEditorForm.pwMapTrn2File_0.TotalSectors, Class16.smethod_0(1649083882)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						int_0 = 0;
						taskAwaiter_0 = awaiter;
						asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_008a;
				}
				goto end_IL_000e;
				IL_008a:
				awaiter.GetResult();
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				int_0 = -2;
				asyncVoidMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			asyncVoidMethodBuilder_0.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private sealed class Class319
	{
		public string string_0;

		internal PwMapFileLayout method_0()
		{
			return PwMapFileDiscoveryService.Discover(string_0);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct84 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		public PwMapSharpDxEditorForm pwMapSharpDxEditorForm_0;

		private Class304 class304_0;

		private PwMapExportServerDialog pwMapExportServerDialog_0;

		private TaskAwaiter<Class310> taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PwMapSharpDxEditorForm pwMapSharpDxEditorForm = pwMapSharpDxEditorForm_0;
			try
			{
				if (num == 0)
				{
					goto IL_005f;
				}
				class304_0 = new Class304();
				class304_0.pwMapSharpDxEditorForm_0 = pwMapSharpDxEditorForm_0;
				if (!pwMapSharpDxEditorForm.bool_10)
				{
					if (pwMapSharpDxEditorForm.pwMapTrn2File_0 == null)
					{
						pwMapSharpDxEditorForm.method_350();
					}
					if (pwMapSharpDxEditorForm.pwMapTrn2File_0 != null)
					{
						pwMapExportServerDialog_0 = new PwMapExportServerDialog();
						goto IL_005f;
					}
					DKBox.Show(pwMapSharpDxEditorForm, Class16.smethod_0(1649083405), Class16.smethod_0(1649083454), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				goto end_IL_000e;
				IL_005f:
				try
				{
					TaskAwaiter<Class310> awaiter;
					if (num == 0)
					{
						awaiter = taskAwaiter_0;
						taskAwaiter_0 = default(TaskAwaiter<Class310>);
						num = -1;
						int_0 = -1;
						goto IL_02e1;
					}
					if (pwMapExportServerDialog_0.ShowDialog(pwMapSharpDxEditorForm) == DialogResult.OK)
					{
						class304_0.string_1 = pwMapSharpDxEditorForm.method_147();
						string text = pwMapSharpDxEditorForm.method_146();
						class304_0.string_0 = System.IO.Path.Combine(text, Class16.smethod_0(1649137666), Class16.smethod_0(1649083466), Class16.smethod_0(1649083486), class304_0.string_1);
						Directory.CreateDirectory(class304_0.string_0);
						pwMapSharpDxEditorForm.bool_10 = true;
						pwMapSharpDxEditorForm.method_87(0, bool_37: true);
						pwMapSharpDxEditorForm.method_120(Class16.smethod_0(1649083491), Class16.smethod_0(1649083522) + class304_0.string_1);
						class304_0.pwMapTrn2File_0 = pwMapSharpDxEditorForm.pwMapTrn2File_0;
						class304_0.regionFile_0 = pwMapSharpDxEditorForm.regionFile_0;
						class304_0.precinctFile_0 = pwMapSharpDxEditorForm.precinctFile_0;
						class304_0.string_3 = (pwMapSharpDxEditorForm.textBox_78.Text ?? string.Empty).Trim();
						class304_0.string_2 = class304_0.pwMapTrn2File_0.MapRootPath;
						class304_0.bool_7 = pwMapExportServerDialog_0.ExportPassmap;
						class304_0.bool_8 = pwMapExportServerDialog_0.ExportCurrentSectorOnly;
						class304_0.bool_0 = pwMapExportServerDialog_0.ExportHmap;
						class304_0.bool_4 = pwMapExportServerDialog_0.ExportWmap;
						class304_0.bool_5 = pwMapExportServerDialog_0.ExportBht;
						class304_0.bool_6 = pwMapExportServerDialog_0.ExportAirmap;
						class304_0.bool_1 = pwMapExportServerDialog_0.ExportRegion;
						class304_0.bool_2 = pwMapExportServerDialog_0.ExportPrecinct;
						class304_0.bool_3 = pwMapExportServerDialog_0.ExportWaterConf;
						class304_0.bool_9 = pwMapExportServerDialog_0.ExportDhmap;
						awaiter = Task.Run((Func<Class310>)class304_0.method_0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							int_0 = 0;
							taskAwaiter_0 = awaiter;
							asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_02e1;
					}
					goto end_IL_005f;
					IL_02e1:
					Class310 result = awaiter.GetResult();
					Class310 @class = result;
					pwMapSharpDxEditorForm.bool_10 = false;
					pwMapSharpDxEditorForm.method_87(0, bool_37: false);
					pwMapSharpDxEditorForm.method_120(Class16.smethod_0(1649083542), Class16.smethod_0(1649083522) + class304_0.string_1);
					StringBuilder stringBuilder = new StringBuilder(Class16.smethod_0(1649083573));
					stringBuilder.AppendLine();
					stringBuilder.AppendLine(Class16.smethod_0(1649083595) + class304_0.string_0);
					if (class304_0.bool_0)
					{
						stringBuilder.AppendLine(string.Format(Class16.smethod_0(1649083608), @class.int_0, @class.int_1));
					}
					if (class304_0.bool_4)
					{
						stringBuilder.AppendLine(string.Format(Class16.smethod_0(1649083646), @class.int_2, @class.int_3));
					}
					if (class304_0.bool_5)
					{
						stringBuilder.AppendLine(Class16.smethod_0(1649083676) + @class.string_0);
					}
					if (class304_0.bool_6)
					{
						stringBuilder.AppendLine(string.Format(Class16.smethod_0(1649083680), @class.int_4, @class.int_5, @class.int_6));
					}
					if (class304_0.bool_1)
					{
						stringBuilder.AppendLine(Class16.smethod_0(1649083732) + (@class.bool_0 ? Class16.smethod_0(1649019761) : Class16.smethod_0(1649083751)));
					}
					if (class304_0.bool_2)
					{
						stringBuilder.AppendLine(Class16.smethod_0(1649083767) + (@class.bool_1 ? Class16.smethod_0(1649019761) : Class16.smethod_0(1649083751)));
					}
					if (class304_0.bool_3)
					{
						stringBuilder.AppendLine(Class16.smethod_0(1649083788) + (@class.bool_2 ? Class16.smethod_0(1649019761) : Class16.smethod_0(1649083802)));
					}
					if (class304_0.bool_7)
					{
						stringBuilder.AppendLine(string.Format(Class16.smethod_0(1649083821), @class.int_7, @class.int_8));
					}
					if (class304_0.bool_9)
					{
						stringBuilder.AppendLine(string.Format(Class16.smethod_0(1649083854), @class.int_9, @class.int_10));
					}
					DKBox.Show(pwMapSharpDxEditorForm, stringBuilder.ToString(), Class16.smethod_0(1649083454), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					end_IL_005f:;
				}
				finally
				{
					if (num < 0 && pwMapExportServerDialog_0 != null)
					{
						((IDisposable)pwMapExportServerDialog_0).Dispose();
					}
				}
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				int_0 = -2;
				class304_0 = null;
				pwMapExportServerDialog_0 = null;
				asyncVoidMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			class304_0 = null;
			pwMapExportServerDialog_0 = null;
			asyncVoidMethodBuilder_0.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	public interface ISceneObjectList
	{
		void AddFromSnapshot(SceneObjectSnapshot snap);

		void RemoveBySnapshot(SceneObjectSnapshot snap);
	}

	public struct SceneObjectSnapshot
	{
		public string Label;

		public string ResourcePath;

		public Vector3 Center;

		public Vector3 Extents;

		public Vector3 Rotation;

		public Vector3 Scale;
	}

	private readonly Struct80[] struct80_0 = new Struct80[9];

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private CheckBox checkBox_2;

	private CheckBox checkBox_3;

	private CheckBox checkBox_4;

	private CheckBox checkBox_5;

	private CheckBox checkBox_6;

	private CheckBox checkBox_7;

	private CheckBox checkBox_8;

	private CheckBox checkBox_9;

	private CheckBox checkBox_10;

	private CheckBox checkBox_11;

	private CheckBox checkBox_12;

	private CheckBox checkBox_13;

	private CheckBox checkBox_14;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private float float_0 = (float)Math.PI / 4f;

	private TrackBar trackBar_0;

	private TrackBar trackBar_1;

	private TrackBar trackBar_2;

	private TrackBar trackBar_3;

	private Label label_0;

	private Panel panel_0;

	private PictureBox pictureBox_0;

	private Label label_1;

	private Label label_2;

	private bool bool_3;

	private Panel panel_1;

	private Label label_3;

	private TrackBar trackBar_4;

	private Label label_4;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private TextBox textBox_3;

	private TextBox textBox_4;

	private TextBox textBox_5;

	private TextBox textBox_6;

	private TextBox textBox_7;

	private TextBox textBox_8;

	private ComboBox comboBox_0;

	private Button button_0;

	private Panel panel_2;

	private Label label_5;

	private TrackBar trackBar_5;

	private Label label_6;

	private TextBox textBox_9;

	private TextBox textBox_10;

	private TextBox textBox_11;

	private TextBox textBox_12;

	private TextBox textBox_13;

	private TextBox textBox_14;

	private TextBox textBox_15;

	private TextBox textBox_16;

	private TextBox textBox_17;

	private ComboBox comboBox_1;

	private TextBox textBox_18;

	private TextBox textBox_19;

	private TextBox textBox_20;

	private CheckBox checkBox_15;

	private Button button_1;

	private TabPage tabPage_0;

	private CheckBox checkBox_16;

	private CheckBox checkBox_17;

	private CheckBox checkBox_18;

	private TrackBar trackBar_6;

	private TrackBar trackBar_7;

	private Label label_7;

	private Label label_8;

	private ListView listView_0;

	private Button button_2;

	private Button button_3;

	private Panel panel_3;

	private Panel panel_4;

	private TextBox textBox_21;

	private RadioButton radioButton_0;

	private RadioButton radioButton_1;

	private RadioButton radioButton_2;

	private TextBox textBox_22;

	private TextBox textBox_23;

	private TextBox textBox_24;

	private Panel panel_5;

	private TextBox textBox_25;

	private TextBox textBox_26;

	private TextBox textBox_27;

	private Button button_4;

	private Button button_5;

	private Button button_6;

	private Panel panel_6;

	private Label label_9;

	private TrackBar trackBar_8;

	private Label label_10;

	private TabControl tabControl_0;

	private TextBox textBox_28;

	private TextBox textBox_29;

	private TextBox textBox_30;

	private TextBox textBox_31;

	private TextBox textBox_32;

	private TextBox textBox_33;

	private TextBox textBox_34;

	private TextBox textBox_35;

	private TextBox textBox_36;

	private ListView listView_1;

	private PictureBox pictureBox_1;

	private Button button_7;

	private Panel panel_7;

	private Panel panel_8;

	private Panel panel_9;

	private Panel panel_10;

	private CheckBox checkBox_19;

	private CheckBox checkBox_20;

	private Button button_8;

	private ListView listView_2;

	private Button button_9;

	private Button button_10;

	private Button button_11;

	private RegionFile regionFile_0;

	private PrecinctFile precinctFile_0;

	private string string_0 = string.Empty;

	private bool bool_4;

	private Vector3 vector3_0;

	private Vector3 vector3_1;

	private PictureBox pictureBox_2;

	private Bitmap bitmap_0;

	private Bitmap bitmap_1;

	private Bitmap bitmap_2;

	private TabPage tabPage_1;

	private ComboBox comboBox_2;

	private Button button_12;

	private Button button_13;

	private CheckBox checkBox_21;

	private TrackBar trackBar_9;

	private Label label_11;

	private ComboBox comboBox_3;

	private Button button_14;

	private Button button_15;

	private Label label_12;

	private Panel panel_11;

	private PwMapPassMapProfile pwMapPassMapProfile_0;

	private TabControl tabControl_1;

	private ListView listView_3;

	private ListView listView_4;

	private Button button_16;

	private Button button_17;

	private Button button_18;

	private ListView listView_5;

	private TextBox textBox_37;

	private TextBox textBox_38;

	private TextBox textBox_39;

	private ComboBox comboBox_4;

	private ComboBox comboBox_5;

	private CheckBox checkBox_22;

	private ListView listView_6;

	private Button button_19;

	private Button button_20;

	private Button button_21;

	private Button button_22;

	private ListView listView_7;

	private TextBox textBox_40;

	private TextBox textBox_41;

	private TextBox textBox_42;

	private TextBox textBox_43;

	private TextBox textBox_44;

	private CheckBox checkBox_23;

	private TextBox textBox_45;

	private TextBox textBox_46;

	private TextBox textBox_47;

	private TextBox textBox_48;

	private TextBox textBox_49;

	private TextBox textBox_50;

	private TextBox textBox_51;

	private ListView listView_8;

	private Button button_23;

	private Button button_24;

	private Button button_25;

	private Button button_26;

	private ListView listView_9;

	private TextBox textBox_52;

	private ComboBox comboBox_6;

	private ListView listView_10;

	private Button button_27;

	private Button button_28;

	private Button button_29;

	private Button button_30;

	private TabPage tabPage_2;

	private TabControl tabControl_2;

	private TabPage tabPage_3;

	private TextBox textBox_53;

	private CheckBox checkBox_24;

	private CheckBox checkBox_25;

	private CheckBox checkBox_26;

	private CheckBox checkBox_27;

	private ListView listView_11;

	private GroupBox groupBox_0;

	private Label label_13;

	private TextBox textBox_54;

	private TextBox textBox_55;

	private TextBox textBox_56;

	private TextBox textBox_57;

	private TextBox textBox_58;

	private TextBox textBox_59;

	private TextBox textBox_60;

	private TextBox textBox_61;

	private TextBox textBox_62;

	private Button button_31;

	private bool bool_5;

	private GroupBox groupBox_1;

	private ListView listView_12;

	private Button button_32;

	private Button button_33;

	private Panel panel_12;

	private Panel panel_13;

	private Label label_14;

	private ToolStripStatusLabel toolStripStatusLabel_0;

	private ToolStripStatusLabel toolStripStatusLabel_1;

	private ToolStripStatusLabel toolStripStatusLabel_2;

	private ToolStripButton toolStripButton_0;

	private ToolStripDropDownButton toolStripDropDownButton_0;

	private ToolStripProgressBar toolStripProgressBar_0;

	private ToolStripStatusLabel toolStripStatusLabel_3;

	private ToolStripStatusLabel toolStripStatusLabel_4;

	private ToolStripStatusLabel toolStripStatusLabel_5;

	private int int_0;

	private DateTime dateTime_0 = DateTime.UtcNow;

	private int int_1;

	private TabPage tabPage_4;

	private TabControl tabControl_3;

	private TabPage tabPage_5;

	private TabPage tabPage_6;

	private TabPage tabPage_7;

	private GroupBox groupBox_2;

	private ComboBox comboBox_7;

	private TrackBar trackBar_10;

	private TrackBar trackBar_11;

	private TrackBar trackBar_12;

	private Label label_15;

	private Label label_16;

	private Label label_17;

	private Panel panel_14;

	private Panel panel_15;

	private Panel panel_16;

	private RadioButton radioButton_3;

	private RadioButton radioButton_4;

	private RadioButton radioButton_5;

	private Label label_18;

	private Label label_19;

	private Button button_34;

	private Label label_20;

	private ListView listView_13;

	private PictureBox pictureBox_3;

	private PictureBox pictureBox_4;

	private ComboBox comboBox_8;

	private ListView listView_14;

	private PictureBox pictureBox_5;

	private ComboBox comboBox_9;

	private TextBox textBox_63;

	private TextBox textBox_64;

	private ToolStripButton toolStripButton_1;

	private ToolStripButton toolStripButton_2;

	private ToolStripButton toolStripButton_3;

	private ToolStripButton toolStripButton_4;

	private ToolStripButton toolStripButton_5;

	private ToolStripButton toolStripButton_6;

	private ToolStripSeparator toolStripSeparator_0;

	private string string_1 = Class16.smethod_0(1649113514);

	private Panel panel_17;

	private Label label_21;

	private TextBox textBox_65;

	private TextBox textBox_66;

	private TextBox textBox_67;

	private TextBox textBox_68;

	private TextBox textBox_69;

	private TextBox textBox_70;

	private TextBox textBox_71;

	private Button button_35;

	private PwMapChangeLog pwMapChangeLog_0;

	private TabPage tabPage_8;

	private ListView listView_15;

	private TextBox textBox_72;

	private Label label_22;

	private Label label_23;

	private Label label_24;

	private TextBox textBox_73;

	private TextBox textBox_74;

	private TextBox textBox_75;

	private TextBox textBox_76;

	private Panel panel_18;

	private Button button_36;

	private Button button_37;

	private List<PwMapBsdataFile.WaterBlockEntry> list_0;

	private readonly TextBox textBox_77 = new TextBox();

	private readonly TextBox textBox_78 = new TextBox();

	private readonly TextBox textBox_79 = new TextBox();

	private readonly TextBox textBox_80 = new TextBox();

	private readonly TextBox textBox_81 = new TextBox();

	private readonly CheckBox checkBox_28 = new CheckBox
	{
		Checked = true
	};

	private readonly CheckBox checkBox_29 = new CheckBox
	{
		Checked = true
	};

	private readonly CheckBox checkBox_30 = new CheckBox
	{
		Checked = true
	};

	private readonly CheckBox checkBox_31 = new CheckBox
	{
		Checked = true
	};

	private readonly CheckBox checkBox_32 = new CheckBox
	{
		Checked = true
	};

	private readonly CheckBox checkBox_33 = new CheckBox
	{
		Checked = true
	};

	private readonly CheckBox checkBox_34 = new CheckBox
	{
		Checked = true
	};

	private readonly Button button_38 = new Button();

	private readonly Button button_39 = new Button();

	private readonly Button button_40 = new Button();

	private readonly Button button_41 = new Button();

	private readonly Button button_42 = new Button();

	private readonly Button button_43 = new Button();

	private readonly Button button_44 = new Button();

	private readonly ToolStripButton toolStripButton_7 = new ToolStripButton
	{
		CheckOnClick = true,
		Checked = true
	};

	private readonly ToolStripButton toolStripButton_8 = new ToolStripButton
	{
		CheckOnClick = true,
		Checked = true
	};

	private readonly ToolStripButton toolStripButton_9 = new ToolStripButton
	{
		CheckOnClick = true,
		Checked = true
	};

	private readonly ToolStripButton toolStripButton_10 = new ToolStripButton
	{
		CheckOnClick = true,
		Checked = true
	};

	private readonly ToolStripButton toolStripButton_11 = new ToolStripButton
	{
		CheckOnClick = true,
		Checked = true
	};

	private readonly ToolStripButton toolStripButton_12 = new ToolStripButton
	{
		CheckOnClick = true,
		Checked = true
	};

	private readonly ToolStripButton toolStripButton_13 = new ToolStripButton
	{
		CheckOnClick = true,
		Checked = true
	};

	private TabControl tabControl_4;

	private ListView listView_16;

	private ListBox listBox_0;

	private PictureBox pictureBox_6;

	private string string_2;

	private readonly Dictionary<string, TabPage> dictionary_0 = new Dictionary<string, TabPage>();

	private readonly CommonStorage commonStorage_0;

	private readonly PwMapPreferencesStore pwMapPreferencesStore_0;

	private PwMapFileLayout pwMapFileLayout_0 = new PwMapFileLayout();

	private PwMapDebugLogger pwMapDebugLogger_0;

	private PathEditor pathEditor_0;

	private DynamicObjectsEditorForm dynamicObjectsEditorForm_0;

	private Bitmap bitmap_3;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private IContainer icontainer_0;

	private MenuStrip menuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripSeparator toolStripSeparator_1;

	private ToolStripMenuItem toolStripMenuItem_2;

	private ToolStripSeparator toolStripSeparator_2;

	private ToolStripMenuItem toolStripMenuItem_3;

	private ToolStripMenuItem toolStripMenuItem_4;

	private ToolStripMenuItem toolStripMenuItem_5;

	private ToolStripMenuItem toolStripMenuItem_6;

	private ToolStripMenuItem toolStripMenuItem_7;

	private ToolStripMenuItem toolStripMenuItem_8;

	private ToolStripMenuItem toolStripMenuItem_9;

	private ToolStripMenuItem toolStripMenuItem_10;

	private ToolStripSeparator toolStripSeparator_3;

	private ToolStripMenuItem toolStripMenuItem_11;

	private ToolStripSeparator toolStripSeparator_4;

	private ToolStripMenuItem toolStripMenuItem_12;

	private ToolStripSeparator toolStripSeparator_5;

	private ToolStripMenuItem toolStripMenuItem_13;

	private ToolStripMenuItem toolStripMenuItem_14;

	private ToolStripMenuItem toolStripMenuItem_15;

	private ToolStripMenuItem toolStripMenuItem_16;

	private ToolStripMenuItem toolStripMenuItem_17;

	private ToolStripMenuItem toolStripMenuItem_18;

	private ToolStripMenuItem toolStripMenuItem_19;

	private ToolStripMenuItem toolStripMenuItem_20;

	private ToolStripSeparator toolStripSeparator_6;

	private ToolStripMenuItem toolStripMenuItem_21;

	private ToolStripMenuItem toolStripMenuItem_22;

	private ToolStripSeparator toolStripSeparator_7;

	private ToolStripMenuItem toolStripMenuItem_23;

	private ToolStripMenuItem toolStripMenuItem_24;

	private ToolStripMenuItem toolStripMenuItem_25;

	private ToolStripMenuItem toolStripMenuItem_26;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_14;

	private ToolStripSeparator toolStripSeparator_8;

	private ToolStripButton toolStripButton_15;

	private ToolStripButton toolStripButton_16;

	private ToolStripSeparator toolStripSeparator_9;

	private ToolStripButton toolStripButton_17;

	private ToolStripButton toolStripButton_18;

	private ToolStripButton toolStripButton_19;

	private ToolStripButton toolStripButton_20;

	private ToolStripButton toolStripButton_21;

	private ToolStripButton toolStripButton_22;

	private ToolStripButton toolStripButton_23;

	private ToolStripSeparator toolStripSeparator_10;

	private ToolStripButton toolStripButton_24;

	private ToolStripButton toolStripButton_25;

	private ToolStripButton toolStripButton_26;

	private ToolStripButton toolStripButton_27;

	private ToolStripButton toolStripButton_28;

	private ToolStripButton toolStripButton_29;

	private ToolStripButton toolStripButton_30;

	private SplitContainer splitContainer_0;

	private SplitContainer splitContainer_1;

	private Panel panel_19;

	private Panel panel_20;

	private GroupBox groupBox_3;

	private CheckBox checkBox_35;

	private CheckBox checkBox_36;

	private CheckBox checkBox_37;

	private CheckBox checkBox_38;

	private CheckBox checkBox_39;

	private CheckBox checkBox_40;

	private GroupBox groupBox_4;

	private Label label_25;

	private RadioButton radioButton_6;

	private RadioButton radioButton_7;

	private Label label_26;

	private Label label_27;

	private TrackBar trackBar_13;

	private GroupBox groupBox_5;

	private Label label_28;

	private TrackBar trackBar_14;

	private Label label_29;

	private TrackBar trackBar_15;

	private Label label_30;

	private TrackBar trackBar_16;

	private TabControl tabControl_5;

	private TabPage tabPage_9;

	private TabPage tabPage_10;

	private TabPage tabPage_11;

	private PictureBox pictureBox_7;

	private PictureBox pictureBox_8;

	private PictureBox pictureBox_9;

	private Button button_45;

	private Button button_46;

	private Panel panel_21;

	private Label label_31;

	private Panel panel_22;

	private Label label_32;

	private StatusStrip statusStrip_0;

	private ToolStripStatusLabel toolStripStatusLabel_6;

	private ToolStripStatusLabel toolStripStatusLabel_7;

	private bool bool_10;

	private bool bool_11;

	private Panel panel_23;

	private Panel panel_24;

	private Label label_33;

	private Label label_34;

	private ProgressBar progressBar_0;

	private int int_2;

	private bool bool_12;

	private int int_3 = -12686016;

	private int int_4 = -3390396;

	private int int_5 = -12285731;

	private int int_6 = -12272828;

	private int int_7 = -2250189;

	private int int_8 = -154;

	private int int_9 = -10048973;

	private Direct3D direct3D_0;

	private Device device_0;

	private PresentParameters presentParameters_0;

	private VertexBuffer vertexBuffer_0;

	private int int_10;

	private VertexBuffer vertexBuffer_1;

	private int int_11;

	private bool bool_13;

	private float float_1 = 500f;

	private float float_2 = 0.82f;

	private float float_3 = -0.65f;

	private Vector3 vector3_2 = Vector3.Zero;

	private bool bool_14;

	private bool bool_15;

	private Point point_0;

	private Point point_1;

	private bool bool_16;

	private bool bool_17;

	private bool bool_18;

	private bool bool_19;

	private bool bool_20;

	private bool bool_21;

	private bool bool_22;

	private int int_12;

	private ContextMenuStrip contextMenuStrip_0;

	private Class301 class301_0;

	private VertexBuffer vertexBuffer_2;

	private int int_13;

	private int int_14;

	private int int_15;

	private int int_16 = -1;

	private int int_17;

	private Timer timer_0;

	private Plane[] plane_0;

	private int int_18;

	private float float_4 = 0.25f;

	private float float_5;

	private float float_6;

	private bool bool_23 = true;

	private bool bool_24;

	private float float_7;

	private bool bool_25;

	private bool bool_26;

	private bool bool_27;

	private bool bool_28;

	private PwMapBrushCollisionService pwMapBrushCollisionService_0;

	private float float_8;

	private VertexBuffer vertexBuffer_3;

	private int int_19;

	private VertexBuffer vertexBuffer_4;

	private int int_20;

	private VertexBuffer vertexBuffer_5;

	private int int_21;

	private VertexBuffer vertexBuffer_6;

	private int int_22;

	private VertexBuffer vertexBuffer_7;

	private int int_23;

	private VertexBuffer vertexBuffer_8;

	private int int_24;

	private readonly List<Class313> list_1 = new List<Class313>();

	private readonly List<Class313> list_2 = new List<Class313>();

	private readonly List<Class313> list_3 = new List<Class313>();

	private readonly Dictionary<string, Texture> dictionary_1 = new Dictionary<string, Texture>(StringComparer.OrdinalIgnoreCase);

	private readonly Dictionary<string, string> dictionary_2 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

	private readonly Dictionary<string, string> dictionary_3 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

	private readonly List<Class314> list_4 = new List<Class314>(4096);

	private readonly List<Class314> list_5 = new List<Class314>(2048);

	private readonly List<Class314> list_6 = new List<Class314>(8192);

	private readonly List<Class314> list_7 = new List<Class314>(2048);

	private readonly List<Class314> list_8 = new List<Class314>(512);

	private PwMapSceneLightFile.SceneLightCollection sceneLightCollection_0;

	private bool bool_29;

	private int int_25;

	private readonly Dictionary<string, string> dictionary_4 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

	private VertexBuffer vertexBuffer_9;

	private int int_26;

	private Texture texture_0;

	private Texture texture_1;

	private Texture texture_2;

	private Texture texture_3;

	private Texture texture_4;

	private Texture texture_5;

	private string string_3 = string.Empty;

	private string string_4 = string.Empty;

	private string string_5 = string.Empty;

	private int int_27;

	private int int_28;

	private int int_29;

	private int int_30;

	private VertexBuffer vertexBuffer_10;

	private int int_31;

	private Texture texture_6;

	private float float_9;

	private CheckBox checkBox_41;

	private CheckBox checkBox_42;

	private CheckBox checkBox_43;

	private CheckBox checkBox_44;

	private CheckBox checkBox_45;

	private CheckBox checkBox_46;

	private bool bool_30;

	private readonly List<Class301> list_9 = new List<Class301>();

	private Class301 class301_1;

	private readonly List<Class301> list_10 = new List<Class301>();

	private VertexBuffer vertexBuffer_11;

	private int int_32;

	private Vector3 vector3_3;

	private bool bool_31;

	private Point point_2;

	private bool bool_32;

	private int int_33;

	private TabPage tabPage_12;

	private ListView listView_17;

	private TabControl tabControl_6;

	private TabPage tabPage_13;

	private TabPage tabPage_14;

	private TabPage tabPage_15;

	private TabPage tabPage_16;

	private List<PwMapBoxArea> list_11;

	private PwMapBoxArea pwMapBoxArea_0;

	private bool bool_33;

	private TabPage tabPage_17;

	private TrackBar trackBar_17;

	private TrackBar trackBar_18;

	private TrackBar trackBar_19;

	private TrackBar trackBar_20;

	private ComboBox comboBox_10;

	private Label label_35;

	private Label label_36;

	private Label label_37;

	private Label label_38;

	private float float_10 = 1f;

	private float float_11 = 1f;

	private float float_12 = 1f;

	private float float_13 = 1f;

	private int int_34;

	private TextBox textBox_82;

	private TextBox textBox_83;

	private TextBox textBox_84;

	private TextBox textBox_85;

	private TextBox textBox_86;

	private TextBox textBox_87;

	private Panel panel_25;

	private Panel panel_26;

	private TextBox textBox_88;

	private TextBox textBox_89;

	private TextBox textBox_90;

	private TextBox textBox_91;

	private TextBox textBox_92;

	private TextBox textBox_93;

	private Panel panel_27;

	private Panel panel_28;

	private CheckBox checkBox_47;

	private CheckBox checkBox_48;

	private CheckBox checkBox_49;

	private CheckBox checkBox_50;

	private CheckBox checkBox_51;

	private CheckBox checkBox_52;

	private TextBox textBox_94;

	private TextBox textBox_95;

	private TextBox textBox_96;

	private TextBox textBox_97;

	private TextBox textBox_98;

	private TextBox textBox_99;

	private TextBox textBox_100;

	private TextBox textBox_101;

	private TextBox textBox_102;

	private TextBox textBox_103;

	private TextBox textBox_104;

	private TextBox textBox_105;

	private TextBox textBox_106;

	private TextBox textBox_107;

	private TextBox textBox_108;

	private TextBox textBox_109;

	private TextBox textBox_110;

	private TextBox textBox_111;

	private TextBox textBox_112;

	private TextBox textBox_113;

	private TextBox textBox_114;

	private TextBox textBox_115;

	private TextBox textBox_116;

	private TextBox textBox_117;

	private TextBox textBox_118;

	private GroupBox groupBox_6;

	private GroupBox groupBox_7;

	private Panel panel_29;

	private Panel panel_30;

	private TextBox textBox_119;

	private TextBox textBox_120;

	private TextBox textBox_121;

	private Panel panel_31;

	private Panel panel_32;

	private Panel panel_33;

	private Panel panel_34;

	private Panel panel_35;

	private Panel panel_36;

	private Panel panel_37;

	private Panel panel_38;

	private TextBox textBox_122;

	private TextBox textBox_123;

	private TextBox textBox_124;

	private TextBox textBox_125;

	private TextBox textBox_126;

	private TextBox textBox_127;

	private TextBox textBox_128;

	private TextBox textBox_129;

	private TextBox textBox_130;

	private PictureBox pictureBox_10;

	private PictureBox pictureBox_11;

	private PictureBox pictureBox_12;

	private PictureBox pictureBox_13;

	private PictureBox pictureBox_14;

	private PictureBox pictureBox_15;

	private TabPage tabPage_18;

	private Panel panel_39;

	private Panel panel_40;

	private TextBox textBox_131;

	private TextBox textBox_132;

	private TextBox textBox_133;

	private TextBox textBox_134;

	private VertexBuffer vertexBuffer_12;

	private int int_35;

	private VertexBuffer vertexBuffer_13;

	private int int_36;

	private readonly List<Class313> list_12 = new List<Class313>();

	private readonly Dictionary<string, Texture> dictionary_5 = new Dictionary<string, Texture>(StringComparer.OrdinalIgnoreCase);

	private PwMapTrn2File pwMapTrn2File_0;

	private readonly Dictionary<int, PwMapT2bkFile> dictionary_6 = new Dictionary<int, PwMapT2bkFile>();

	private readonly HashSet<int> hashSet_0 = new HashSet<int>();

	private VertexBuffer vertexBuffer_14;

	private int int_37;

	private VertexBuffer vertexBuffer_15;

	private int int_38;

	private bool bool_34;

	private CheckBox checkBox_53;

	private bool bool_35;

	private Vector3 vector3_4;

	private bool bool_36;

	private VertexBuffer vertexBuffer_16;

	private int int_39;

	public PwMapSharpDxEditorForm(CommonStorage storage)
	{
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		commonStorage_0 = storage;
		pwMapPreferencesStore_0 = new PwMapPreferencesStore();
		method_121();
		method_114();
		method_293();
		method_330();
		method_91();
		method_22();
		method_104();
		method_72();
		method_54();
		method_2();
		method_10();
		method_71();
		method_83();
		method_101();
		method_7();
		method_41();
		method_81();
		method_45();
		method_96();
		base.KeyPreview = true;
		base.KeyDown += PwMapSharpDxEditorForm_KeyDown;
		base.KeyUp += PwMapSharpDxEditorForm_KeyUp;
		panel_21.TabStop = true;
		panel_21.PreviewKeyDown += panel_21_PreviewKeyDown;
		panel_21.KeyDown += PwMapSharpDxEditorForm_KeyDown;
		panel_21.KeyUp += PwMapSharpDxEditorForm_KeyUp;
		panel_21.Leave += panel_21_Leave;
		base.Deactivate += PwMapSharpDxEditorForm_Deactivate;
		base.Shown += PwMapSharpDxEditorForm_Shown;
		base.FormClosing += PwMapSharpDxEditorForm_FormClosing;
		panel_21.Resize += panel_21_Resize;
		panel_21.MouseDown += panel_21_MouseDown;
		panel_21.MouseMove += panel_21_MouseMove;
		panel_21.MouseUp += panel_21_MouseUp;
		panel_21.MouseWheel += panel_21_MouseWheel;
		button_39.Click += button_39_Click;
		button_38.Click += button_38_Click;
		button_40.Click += button_40_Click;
		button_41.Click += button_41_Click;
		button_42.Click += button_42_Click;
		button_43.Click += button_43_Click;
		button_44.Click += button_44_Click;
		checkBox_33.CheckedChanged += checkBox_33_CheckedChanged;
		checkBox_34.CheckedChanged += checkBox_34_CheckedChanged;
		checkBox_28.CheckedChanged += checkBox_28_CheckedChanged;
		checkBox_29.CheckedChanged += checkBox_29_CheckedChanged;
		checkBox_30.CheckedChanged += checkBox_30_CheckedChanged;
		checkBox_31.CheckedChanged += checkBox_31_CheckedChanged;
		checkBox_32.CheckedChanged += checkBox_32_CheckedChanged;
		toolStripButton_8.Click += toolStripButton_8_Click;
		toolStripButton_9.Click += toolStripButton_9_Click;
		toolStripButton_7.Click += toolStripButton_7_Click;
		toolStripButton_10.Click += toolStripButton_10_Click;
		toolStripButton_11.Click += toolStripButton_11_Click;
		toolStripButton_12.Click += toolStripButton_12_Click;
		toolStripButton_13.Click += toolStripButton_13_Click;
		listBox_0.SelectedIndexChanged += listBox_0_SelectedIndexChanged;
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		if (base.IsHandleCreated)
		{
			TDark.ApplyImmersiveDarkMode(base.Handle, TDark.IsDarkMode);
		}
		TDark.ApplyNativeDarkThemeRecursive(this);
		TextStorage.TEXTS.SetFormLanguage(this, null);
		checkBox_33.Checked = true;
		checkBox_34.Checked = true;
		method_131();
		label_31.Visible = pwMapPreferencesStore_0.CameraSettings.ShowRenderInfo;
		method_124();
		method_119();
		method_120(Class16.smethod_0(1649082800), null);
	}

	private void method_0(int int_40)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		if (int_40 >= 0 && int_40 < struct80_0.Length)
		{
			struct80_0[int_40] = new Struct80(vector3_2, float_2, float_3, float_1);
			method_120(string.Format(Class16.smethod_0(1649082856), int_40 + 1), null);
		}
	}

	private void method_1(int int_40)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		if (int_40 >= 0 && int_40 < struct80_0.Length)
		{
			Struct80 @struct = struct80_0[int_40];
			if (!@struct.bool_0)
			{
				method_120(string.Format(Class16.smethod_0(1649085961), int_40 + 1, int_40 + 1), null);
				return;
			}
			vector3_2 = @struct.vector3_0;
			float_2 = @struct.float_0;
			float_3 = @struct.float_1;
			float_1 = @struct.float_2;
			method_120(string.Format(Class16.smethod_0(1649086020), int_40 + 1), null);
		}
	}

	private void method_2()
	{
		checkBox_0 = checkBox_36;
		checkBox_1 = checkBox_38;
		checkBox_2 = checkBox_37;
		checkBox_3 = checkBox_35;
		checkBox_4 = checkBox_39;
		checkBox_5 = checkBox_40;
		trackBar_0 = trackBar_14;
		trackBar_1 = trackBar_15;
		trackBar_2 = trackBar_13;
		checkBox_6 = new CheckBox
		{
			AutoSize = true,
			Text = Class16.smethod_0(1649086048),
			Font = new Font(Class16.smethod_0(1648942905), 8.25f),
			ForeColor = SystemColors.ControlText,
			Checked = true
		};
		checkBox_7 = new CheckBox
		{
			AutoSize = true,
			Text = Class16.smethod_0(1649086074),
			Font = new Font(Class16.smethod_0(1648942905), 8.25f),
			ForeColor = SystemColors.ControlText,
			Checked = true
		};
		checkBox_8 = new CheckBox
		{
			AutoSize = true,
			Text = Class16.smethod_0(1649086101),
			Font = new Font(Class16.smethod_0(1648942905), 8.25f),
			ForeColor = SystemColors.ControlText,
			Checked = false
		};
		checkBox_9 = new CheckBox
		{
			AutoSize = true,
			Text = Class16.smethod_0(1649086124),
			Font = new Font(Class16.smethod_0(1648942905), 8.25f),
			ForeColor = SystemColors.ControlText,
			Checked = true
		};
		checkBox_10 = new CheckBox
		{
			AutoSize = true,
			Text = Class16.smethod_0(1649086158),
			Font = new Font(Class16.smethod_0(1648942905), 8.25f),
			ForeColor = SystemColors.ControlText,
			Checked = false
		};
		checkBox_53 = new CheckBox
		{
			AutoSize = true,
			Text = Class16.smethod_0(1649086171),
			Font = new Font(Class16.smethod_0(1648942905), 8.25f),
			ForeColor = SystemColors.ControlText,
			Checked = false
		};
		checkBox_11 = new CheckBox
		{
			AutoSize = true,
			Text = Class16.smethod_0(1649086194),
			Font = new Font(Class16.smethod_0(1648942905), 8.25f),
			ForeColor = SystemColors.ControlText,
			Checked = false
		};
		checkBox_12 = new CheckBox
		{
			AutoSize = true,
			Text = Class16.smethod_0(1649086224),
			Font = new Font(Class16.smethod_0(1648942905), 8.25f),
			ForeColor = SystemColors.ControlText,
			Checked = false
		};
		int num = checkBox_40.Bottom + 2;
		checkBox_6.Location = new Point(10, num);
		checkBox_7.Location = new Point(10, num + 24);
		checkBox_8.Location = new Point(10, num + 48);
		checkBox_9.Location = new Point(10, num + 72);
		checkBox_11.Location = new Point(10, num + 96);
		checkBox_12.Location = new Point(10, num + 120);
		checkBox_10.Location = new Point(10, num + 144);
		checkBox_53.Location = new Point(10, num + 168);
		checkBox_13 = new CheckBox
		{
			AutoSize = true,
			Text = Class16.smethod_0(1649086257),
			Font = new Font(Class16.smethod_0(1648942905), 8.25f),
			ForeColor = SystemColors.ControlText,
			Checked = false
		};
		checkBox_13.Location = new Point(10, num + 192);
		checkBox_14 = new CheckBox
		{
			AutoSize = true,
			Text = Class16.smethod_0(1649086288),
			Font = new Font(Class16.smethod_0(1648942905), 8.25f),
			ForeColor = SystemColors.ControlText,
			Checked = false
		};
		checkBox_14.Location = new Point(10, num + 216);
		Label label = new Label
		{
			Text = Class16.smethod_0(1649086315),
			AutoSize = true,
			Font = new Font(Class16.smethod_0(1648942905), 8.25f),
			ForeColor = SystemColors.ControlText
		};
		label.Location = new Point(10, num + 244);
		trackBar_3 = new TrackBar
		{
			Minimum = 30,
			Maximum = 120,
			Value = 45,
			Width = 140,
			TickFrequency = 15,
			SmallChange = 5,
			LargeChange = 15
		};
		trackBar_3.Location = new Point(40, num + 240);
		label_0 = new Label
		{
			Text = Class16.smethod_0(1649086333),
			AutoSize = true,
			Font = new Font(Class16.smethod_0(1648942905), 8.25f),
			ForeColor = SystemColors.ControlText
		};
		label_0.Location = new Point(185, num + 244);
		groupBox_3.Controls.Add(checkBox_6);
		groupBox_3.Controls.Add(checkBox_7);
		groupBox_3.Controls.Add(checkBox_8);
		groupBox_3.Controls.Add(checkBox_9);
		groupBox_3.Controls.Add(checkBox_11);
		groupBox_3.Controls.Add(checkBox_12);
		groupBox_3.Controls.Add(checkBox_10);
		groupBox_3.Controls.Add(checkBox_53);
		groupBox_3.Controls.Add(checkBox_13);
		groupBox_3.Controls.Add(checkBox_14);
		groupBox_3.Controls.Add(label);
		groupBox_3.Controls.Add(trackBar_3);
		groupBox_3.Controls.Add(label_0);
		groupBox_3.Height = trackBar_3.Bottom + 8;
		method_6();
		method_3();
		method_4();
	}

	private void method_3()
	{
		checkBox_6.CheckedChanged += checkBox_6_CheckedChanged;
		checkBox_7.CheckedChanged += checkBox_7_CheckedChanged;
		checkBox_8.CheckedChanged += checkBox_8_CheckedChanged;
		checkBox_9.CheckedChanged += checkBox_9_CheckedChanged;
		checkBox_11.CheckedChanged += checkBox_11_CheckedChanged;
		checkBox_12.CheckedChanged += checkBox_12_CheckedChanged;
		checkBox_10.CheckedChanged += Class317.class317_0.method_0;
		checkBox_53.CheckedChanged += checkBox_53_CheckedChanged;
		checkBox_13.CheckedChanged += checkBox_13_CheckedChanged;
		checkBox_14.CheckedChanged += checkBox_14_CheckedChanged;
		trackBar_3.ValueChanged += trackBar_3_ValueChanged;
		checkBox_0.CheckedChanged += checkBox_0_CheckedChanged;
		checkBox_1.CheckedChanged += checkBox_1_CheckedChanged;
		checkBox_2.CheckedChanged += Class317.class317_0.method_1;
		checkBox_3.CheckedChanged += checkBox_3_CheckedChanged;
		checkBox_4.CheckedChanged += Class317.class317_0.method_2;
		checkBox_5.CheckedChanged += Class317.class317_0.method_3;
		trackBar_16.ValueChanged += trackBar_16_ValueChanged;
		radioButton_6.CheckedChanged += radioButton_6_CheckedChanged;
		radioButton_7.CheckedChanged += radioButton_7_CheckedChanged;
	}

	private void method_4()
	{
		PwMapCameraSettings cameraSettings = pwMapPreferencesStore_0.CameraSettings;
		if (checkBox_2 != null)
		{
			checkBox_2.Checked = cameraSettings.ShowModelBackside;
		}
		if (checkBox_3 != null)
		{
			checkBox_3.Checked = cameraSettings.ShowCollideOnly;
		}
		if (checkBox_4 != null)
		{
			checkBox_4.Checked = cameraSettings.EnableFog;
		}
		if (checkBox_5 != null)
		{
			checkBox_5.Checked = cameraSettings.TopView;
		}
		if (checkBox_6 != null)
		{
			checkBox_6.Checked = cameraSettings.ShowBoundingBoxes;
		}
		if (checkBox_7 != null)
		{
			checkBox_7.Checked = cameraSettings.ShowCompass;
		}
		if (checkBox_8 != null)
		{
			checkBox_8.Checked = cameraSettings.ShowRenderInfo;
		}
		if (checkBox_9 != null)
		{
			checkBox_9.Checked = cameraSettings.PlayerCollision;
			bool_27 = cameraSettings.PlayerCollision;
		}
		if (checkBox_11 != null)
		{
			checkBox_11.Checked = cameraSettings.FreeCameraCollision;
			bool_0 = cameraSettings.FreeCameraCollision;
		}
		if (checkBox_10 != null)
		{
			checkBox_10.Checked = cameraSettings.EnableSceneLighting;
		}
		if (checkBox_12 != null)
		{
			checkBox_12.Checked = cameraSettings.EnterBuildings;
			bool_28 = cameraSettings.EnterBuildings;
		}
		if (checkBox_0 != null)
		{
			checkBox_0.Checked = cameraSettings.ShowTerrainWire;
			bool_7 = cameraSettings.ShowTerrainWire;
		}
		if (checkBox_1 != null)
		{
			checkBox_1.Checked = cameraSettings.ShowObjectsWire;
			bool_8 = cameraSettings.ShowObjectsWire;
		}
		if (cameraSettings.ShadowMode == 0)
		{
			radioButton_7.Checked = true;
		}
		else
		{
			radioButton_6.Checked = true;
		}
		if (trackBar_0 != null)
		{
			trackBar_0.Value = Math.Max(trackBar_0.Minimum, Math.Min(trackBar_0.Maximum, cameraSettings.CameraSpeed));
		}
		if (trackBar_1 != null)
		{
			int val = (int)(cameraSettings.CameraRotateSpeed * 100f);
			trackBar_1.Value = Math.Max(trackBar_1.Minimum, Math.Min(trackBar_1.Maximum, val));
		}
		if (trackBar_2 != null)
		{
			int val2 = (int)(cameraSettings.DayNightFactor * 100f);
			trackBar_2.Value = Math.Max(0, Math.Min(100, val2));
		}
		trackBar_16.Value = Math.Max(trackBar_16.Minimum, Math.Min(trackBar_16.Maximum, pwMapPreferencesStore_0.RenderOptions.RenderBlockDistance));
	}

	private void method_5()
	{
		PwMapCameraSettings cameraSettings = pwMapPreferencesStore_0.CameraSettings;
		if (checkBox_2 != null)
		{
			cameraSettings.ShowModelBackside = checkBox_2.Checked;
		}
		if (checkBox_3 != null)
		{
			cameraSettings.ShowCollideOnly = checkBox_3.Checked;
		}
		if (checkBox_4 != null)
		{
			cameraSettings.EnableFog = checkBox_4.Checked;
		}
		if (checkBox_5 != null)
		{
			cameraSettings.TopView = checkBox_5.Checked;
		}
		if (checkBox_6 != null)
		{
			cameraSettings.ShowBoundingBoxes = checkBox_6.Checked;
		}
		if (checkBox_7 != null)
		{
			cameraSettings.ShowCompass = checkBox_7.Checked;
		}
		if (checkBox_8 != null)
		{
			cameraSettings.ShowRenderInfo = checkBox_8.Checked;
		}
		if (checkBox_9 != null)
		{
			cameraSettings.PlayerCollision = checkBox_9.Checked;
		}
		if (checkBox_11 != null)
		{
			cameraSettings.FreeCameraCollision = checkBox_11.Checked;
		}
		if (checkBox_12 != null)
		{
			cameraSettings.EnterBuildings = checkBox_12.Checked;
		}
		if (checkBox_10 != null)
		{
			cameraSettings.EnableSceneLighting = checkBox_10.Checked;
		}
		cameraSettings.ShadowMode = ((!radioButton_7.Checked) ? 1 : 0);
		if (trackBar_0 != null)
		{
			cameraSettings.CameraSpeed = trackBar_0.Value;
		}
		if (trackBar_1 != null)
		{
			cameraSettings.CameraRotateSpeed = (float)trackBar_1.Value / 100f;
		}
		if (trackBar_2 != null)
		{
			cameraSettings.DayNightFactor = (float)trackBar_2.Value / 100f;
		}
		cameraSettings.ShowTerrainWire = bool_7;
		cameraSettings.ShowObjectsWire = bool_8;
		pwMapPreferencesStore_0.RenderOptions.RenderBlockDistance = trackBar_16.Value;
	}

	private void method_6()
	{
		if (groupBox_3 != null && groupBox_4 != null && groupBox_5 != null)
		{
			int num = groupBox_3.Bottom + 4;
			groupBox_4.Location = new Point(4, num);
			num = groupBox_4.Bottom + 4;
			groupBox_5.Location = new Point(4, num);
			num = groupBox_5.Bottom + 4;
			if (tabControl_5 != null)
			{
				tabControl_5.Location = new Point(4, num);
				num = tabControl_5.Bottom + 4;
			}
			if (button_45 != null)
			{
				button_45.Location = new Point(4, num);
			}
			if (button_46 != null)
			{
				Button button = button_46;
				Button button2 = button_45;
				button.Location = new Point((button2 != null) ? (button2.Right + 4) : 140, num);
			}
			int num2 = (button_45?.Bottom ?? num) + 20;
			if (panel_20 != null && panel_20.Height < num2)
			{
				panel_20.Height = num2;
			}
		}
	}

	private void method_7()
	{
		panel_0 = new Panel
		{
			Size = new Size(84, 84),
			BackColor = Color.FromArgb(180, 20, 20, 20),
			BorderStyle = BorderStyle.FixedSingle,
			Anchor = (AnchorStyles.Bottom | AnchorStyles.Left)
		};
		pictureBox_0 = new PictureBox
		{
			Dock = DockStyle.Fill,
			BackColor = Color.Transparent,
			SizeMode = PictureBoxSizeMode.Normal
		};
		pictureBox_0.Paint += pictureBox_0_Paint;
		panel_0.Controls.Add(pictureBox_0);
		label_1 = new Label
		{
			Text = Class16.smethod_0(1648930778),
			AutoSize = true,
			ForeColor = Color.White,
			BackColor = Color.Transparent,
			Font = new Font(Class16.smethod_0(1648942905), 7f, FontStyle.Bold)
		};
		label_2 = new Label
		{
			Text = Class16.smethod_0(1649105845),
			AutoSize = true,
			ForeColor = Color.White,
			BackColor = Color.Transparent,
			Font = new Font(Class16.smethod_0(1648942905), 7f, FontStyle.Bold)
		};
		panel_0.Controls.Add(label_1);
		panel_0.Controls.Add(label_2);
		label_1.BringToFront();
		label_2.BringToFront();
		panel_21.Controls.Add(panel_0);
		method_8();
		panel_0.BringToFront();
		panel_21.Resize += panel_21_Resize_1;
	}

	private void method_8()
	{
		if (panel_0 != null && panel_21 != null)
		{
			int val = panel_21.ClientSize.Height - panel_0.Height - 8;
			panel_0.Location = new Point(8, Math.Max(8, val));
		}
	}

	private void pictureBox_0_Paint(object sender, PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		graphics.SmoothingMode = SmoothingMode.AntiAlias;
		int num = pictureBox_0.Width / 2;
		int num2 = pictureBox_0.Height / 2;
		float num3 = Math.Min(num, num2) - 8;
		SolidBrush solidBrush = new SolidBrush(Color.FromArgb(100, 40, 40, 40));
		try
		{
			graphics.FillEllipse(solidBrush, (float)num - num3, (float)num2 - num3, num3 * 2f, num3 * 2f);
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
		Pen pen = new Pen(Color.FromArgb(160, 180, 180, 180), 1f);
		try
		{
			graphics.DrawEllipse(pen, (float)num - num3, (float)num2 - num3, num3 * 2f, num3 * 2f);
		}
		finally
		{
			((IDisposable)pen).Dispose();
		}
		float num4 = float_2;
		smethod_0(graphics, num, num2, num3 * 0.85f, num4, Color.Red, Class16.smethod_0(1648916453));
		smethod_0(graphics, num, num2, num3 * 0.85f, num4 - (float)Math.PI / 2f, Color.RoyalBlue, Class16.smethod_0(1648915467));
		SolidBrush solidBrush2 = new SolidBrush(Color.LimeGreen);
		try
		{
			graphics.FillEllipse(solidBrush2, num - 3, num2 - 3, 6, 6);
		}
		finally
		{
			((IDisposable)solidBrush2).Dispose();
		}
		float num5 = num4;
		float num6 = num4 - (float)Math.PI / 2f;
		float num7 = num3 + 2f;
		label_1.Location = new Point(num + (int)(Math.Sin(num5) * (double)num7) - 4 + panel_0.Padding.Left, num2 - (int)(Math.Cos(num5) * (double)num7) - 6 + panel_0.Padding.Top);
		label_2.Location = new Point(num + (int)(Math.Sin(num6) * (double)num7) - 4 + panel_0.Padding.Left, num2 - (int)(Math.Cos(num6) * (double)num7) - 6 + panel_0.Padding.Top);
	}

	private static void smethod_0(Graphics graphics_0, int int_40, int int_41, float float_14, float float_15, Color color_0, string string_6)
	{
		float x = (float)int_40 + (float)Math.Sin(float_15) * float_14;
		float y = (float)int_41 - (float)Math.Cos(float_15) * float_14;
		Pen pen = new Pen(color_0, 2f);
		try
		{
			pen.EndCap = LineCap.ArrowAnchor;
			graphics_0.DrawLine(pen, int_40, int_41, x, y);
		}
		finally
		{
			((IDisposable)pen).Dispose();
		}
	}

	private void method_9()
	{
		pictureBox_0?.Invalidate();
	}

	private void method_10()
	{
		if (!bool_3 && groupBox_0 != null)
		{
			bool_3 = true;
			method_24();
			method_16();
			method_19();
			method_23();
			method_99();
			groupBox_0.Controls.Add(panel_6);
			groupBox_0.Controls.Add(panel_1);
			groupBox_0.Controls.Add(panel_2);
			groupBox_0.Controls.Add(panel_3);
			groupBox_0.Controls.Add(panel_17);
		}
	}

	private void method_11(string string_6)
	{
		if (!bool_3)
		{
			return;
		}
		panel_6.Visible = false;
		panel_1.Visible = false;
		panel_2.Visible = false;
		panel_3.Visible = false;
		panel_17.Visible = false;
		string text = string_6?.ToUpperInvariant();
		if (text == null)
		{
			return;
		}
		switch (text.Length)
		{
		default:
			return;
		case 3:
		{
			char c = text[0];
			if ((uint)c <= 69u)
			{
				if (c != 'B')
				{
					if (c != 'E' || !(text == Class16.smethod_0(1649086370)))
					{
						return;
					}
					goto IL_015e;
				}
				if (!(text == Class16.smethod_0(1648921454)))
				{
					return;
				}
			}
			else
			{
				switch (c)
				{
				default:
					return;
				case 'S':
					if (!(text == Class16.smethod_0(1649086360)))
					{
						return;
					}
					break;
				case 'L':
					if (!(text == Class16.smethod_0(1649086358)))
					{
						return;
					}
					break;
				case 'G':
					if (text == Class16.smethod_0(1649141693))
					{
						panel_2.Visible = true;
					}
					return;
				}
			}
			goto IL_017e;
		}
		case 4:
			if (!(text == Class16.smethod_0(1649086411)))
			{
				return;
			}
			goto IL_019e;
		case 5:
			if (!(text == Class16.smethod_0(1648901148)))
			{
				return;
			}
			break;
		case 7:
			if (!(text == Class16.smethod_0(1649086388)))
			{
				return;
			}
			goto IL_015e;
		case 8:
			if (!(text == Class16.smethod_0(1649086343)))
			{
				return;
			}
			goto IL_017e;
		case 9:
			if (!(text == Class16.smethod_0(1649086430)))
			{
				return;
			}
			goto IL_019e;
		case 10:
			if (!(text == Class16.smethod_0(1649086394)))
			{
				return;
			}
			break;
		case 6:
			return;
			IL_019e:
			panel_17.Visible = true;
			return;
			IL_017e:
			panel_6.Visible = true;
			return;
			IL_015e:
			panel_1.Visible = true;
			return;
		}
		panel_3.Visible = true;
	}

	private void method_12(string string_6, float float_14, float float_15, float float_16, float float_17, float float_18, float float_19, float float_20, float float_21, float float_22)
	{
		if (label_9 != null)
		{
			label_9.Text = TextStorage.Msg(Class16.smethod_0(1649086446), Class16.smethod_0(1649086459)) + (string_6 ?? Class16.smethod_0(1648966655));
			textBox_28.Text = float_14.ToString(Class16.smethod_0(1648964192));
			textBox_29.Text = float_15.ToString(Class16.smethod_0(1648964192));
			textBox_30.Text = float_16.ToString(Class16.smethod_0(1648964192));
			textBox_31.Text = float_17.ToString(Class16.smethod_0(1648964192));
			textBox_32.Text = float_18.ToString(Class16.smethod_0(1648964192));
			textBox_33.Text = float_19.ToString(Class16.smethod_0(1648964192));
			textBox_34.Text = float_20.ToString(Class16.smethod_0(1648964192));
			textBox_35.Text = float_21.ToString(Class16.smethod_0(1648964192));
			textBox_36.Text = float_22.ToString(Class16.smethod_0(1648964192));
		}
	}

	private void method_13(string string_6, float float_14, float float_15, float float_16, float float_17, float float_18, float float_19, float float_20, float float_21, float float_22)
	{
		if (label_3 != null)
		{
			label_3.Text = TextStorage.Msg(Class16.smethod_0(1649085460), Class16.smethod_0(1649086459)) + (string_6 ?? Class16.smethod_0(1648966655));
			textBox_0.Text = float_14.ToString(Class16.smethod_0(1648964192));
			textBox_1.Text = float_15.ToString(Class16.smethod_0(1648964192));
			textBox_2.Text = float_16.ToString(Class16.smethod_0(1648964192));
			textBox_3.Text = float_17.ToString(Class16.smethod_0(1648964192));
			textBox_4.Text = float_18.ToString(Class16.smethod_0(1648964192));
			textBox_5.Text = float_19.ToString(Class16.smethod_0(1648964192));
			textBox_6.Text = float_20.ToString(Class16.smethod_0(1648964192));
			textBox_7.Text = float_21.ToString(Class16.smethod_0(1648964192));
			textBox_8.Text = float_22.ToString(Class16.smethod_0(1648964192));
		}
	}

	private void method_14(string string_6, float float_14, float float_15, float float_16, float float_17, float float_18, float float_19, int int_40, bool bool_37)
	{
		if (label_5 != null)
		{
			label_5.Text = TextStorage.Msg(Class16.smethod_0(1649085475), Class16.smethod_0(1649086459)) + (string_6 ?? Class16.smethod_0(1648966655));
			textBox_9.Text = float_14.ToString(Class16.smethod_0(1648964192));
			textBox_10.Text = float_15.ToString(Class16.smethod_0(1648964192));
			textBox_11.Text = float_16.ToString(Class16.smethod_0(1648964192));
			textBox_18.Text = float_17.ToString(Class16.smethod_0(1648964192));
			textBox_19.Text = float_18.ToString(Class16.smethod_0(1648964192));
			textBox_20.Text = float_19.ToString(Class16.smethod_0(1648964192));
			comboBox_1.SelectedIndex = Math.Max(0, Math.Min(2, int_40));
			checkBox_15.Checked = bool_37;
		}
	}

	private void method_15(Color color_0, float float_14, int int_40, float float_15, float float_16, float float_17, float float_18, float float_19, float float_20)
	{
		if (panel_4 != null)
		{
			panel_4.BackColor = color_0;
			textBox_21.Text = float_14.ToString(Class16.smethod_0(1648922976));
			radioButton_0.Checked = int_40 == 0;
			radioButton_1.Checked = int_40 == 1;
			radioButton_2.Checked = int_40 == 2;
			textBox_22.Text = float_15.ToString(Class16.smethod_0(1649090699));
			textBox_23.Text = float_16.ToString(Class16.smethod_0(1649090699));
			textBox_24.Text = float_17.ToString(Class16.smethod_0(1649090699));
			if (textBox_25 != null)
			{
				textBox_25.Text = float_18.ToString(Class16.smethod_0(1648964192));
				textBox_26.Text = float_19.ToString(Class16.smethod_0(1648964192));
				textBox_27.Text = float_20.ToString(Class16.smethod_0(1648964192));
			}
			panel_5?.Invalidate();
		}
	}

	private void method_16()
	{
		panel_1 = new Panel
		{
			Dock = DockStyle.Fill,
			Visible = false
		};
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 1,
			RowCount = 3,
			Padding = new Padding(4)
		};
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 44f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		label_3 = new Label
		{
			Text = Class16.smethod_0(1649085498),
			Dock = DockStyle.Fill,
			AutoEllipsis = true,
			Cursor = Cursors.Hand
		};
		label_3.Click += label_3_Click;
		tableLayoutPanel.Controls.Add(label_3, 0, 0);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			AutoSize = true,
			Dock = DockStyle.Fill,
			WrapContents = false
		};
		flowLayoutPanel.Controls.Add(new Label
		{
			Text = Class16.smethod_0(1649085535),
			AutoSize = true
		});
		trackBar_4 = new TrackBar
		{
			Minimum = 0,
			Maximum = 200,
			Value = 0,
			TickFrequency = 20,
			Width = 180
		};
		label_4 = new Label
		{
			Text = Class16.smethod_0(1648924112),
			AutoSize = true
		};
		trackBar_4.ValueChanged += trackBar_4_ValueChanged;
		flowLayoutPanel.Controls.Add(trackBar_4);
		flowLayoutPanel.Controls.Add(label_4);
		tableLayoutPanel.Controls.Add(flowLayoutPanel, 0, 1);
		TabControl tabControl = new TabControl
		{
			Dock = DockStyle.Fill
		};
		tabControl.TabPages.Add(method_17());
		tabControl.TabPages.Add(method_18());
		tableLayoutPanel.Controls.Add(tabControl, 0, 2);
		panel_1.Controls.Add(tableLayoutPanel);
	}

	private TabPage method_17()
	{
		TabPage tabPage = new TabPage(Class16.smethod_0(1649085549));
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Top,
			AutoSize = true,
			ColumnCount = 4,
			Padding = new Padding(4)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34f));
		tableLayoutPanel.Controls.Add(new Label
		{
			Text = string.Empty,
			AutoSize = true
		}, 0, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648916453)), 1, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648916476)), 2, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648915467)), 3, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648893587)), 0, 1);
		textBox_0 = method_26();
		tableLayoutPanel.Controls.Add(textBox_0, 1, 1);
		textBox_1 = method_26();
		tableLayoutPanel.Controls.Add(textBox_1, 2, 1);
		textBox_2 = method_26();
		tableLayoutPanel.Controls.Add(textBox_2, 3, 1);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649085565)), 0, 2);
		textBox_3 = method_26();
		tableLayoutPanel.Controls.Add(textBox_3, 1, 2);
		textBox_4 = method_26();
		tableLayoutPanel.Controls.Add(textBox_4, 2, 2);
		textBox_5 = method_26();
		tableLayoutPanel.Controls.Add(textBox_5, 3, 2);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649103810)), 0, 3);
		textBox_6 = method_26();
		tableLayoutPanel.Controls.Add(textBox_6, 1, 3);
		textBox_7 = method_26();
		tableLayoutPanel.Controls.Add(textBox_7, 2, 3);
		textBox_8 = method_26();
		tableLayoutPanel.Controls.Add(textBox_8, 3, 3);
		button_0 = new Button
		{
			Text = Class16.smethod_0(1648996201),
			AutoSize = true,
			Dock = DockStyle.Left,
			FlatStyle = FlatStyle.Flat
		};
		button_0.Click += button_0_Click;
		tableLayoutPanel.SetColumnSpan(button_0, 4);
		tableLayoutPanel.Controls.Add(button_0, 0, 4);
		TextBox[] array = new TextBox[9] { textBox_0, textBox_1, textBox_2, textBox_3, textBox_4, textBox_5, textBox_6, textBox_7, textBox_8 };
		foreach (TextBox textBox in array)
		{
			textBox.KeyDown += method_377;
		}
		tabPage.Controls.Add(tableLayoutPanel);
		return tabPage;
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		if (class301_1?.class314_0 != null)
		{
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			if (float.TryParse(textBox_0.Text, NumberStyles.Float, invariantCulture, out var result) && float.TryParse(textBox_1.Text, NumberStyles.Float, invariantCulture, out var result2) && float.TryParse(textBox_2.Text, NumberStyles.Float, invariantCulture, out var result3))
			{
				class301_1.class314_0.vector3_0 = new Vector3(result, result2, result3);
				class301_1.vector3_1 = class301_1.class314_0.vector3_0;
				method_261();
				method_77();
				method_140();
				method_120(Class16.smethod_0(1649085581) + class301_1.string_0, null);
			}
		}
	}

	private TabPage method_18()
	{
		TabPage tabPage = new TabPage(Class16.smethod_0(1649085600));
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Top,
			AutoSize = true,
			ColumnCount = 2,
			Padding = new Padding(4)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649085600)), 0, 0);
		comboBox_0 = new ComboBox
		{
			Dock = DockStyle.Fill,
			DropDownStyle = ComboBoxStyle.DropDownList
		};
		tableLayoutPanel.Controls.Add(comboBox_0, 1, 0);
		tabPage.Controls.Add(tableLayoutPanel);
		return tabPage;
	}

	private void method_19()
	{
		panel_2 = new Panel
		{
			Dock = DockStyle.Fill,
			Visible = false
		};
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 1,
			RowCount = 3,
			Padding = new Padding(4)
		};
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 44f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		label_5 = new Label
		{
			Text = Class16.smethod_0(1649085498),
			Dock = DockStyle.Fill,
			AutoEllipsis = true,
			Cursor = Cursors.Hand
		};
		label_5.Click += label_5_Click;
		tableLayoutPanel.Controls.Add(label_5, 0, 0);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			AutoSize = true,
			Dock = DockStyle.Fill,
			WrapContents = false
		};
		flowLayoutPanel.Controls.Add(new Label
		{
			Text = Class16.smethod_0(1649085535),
			AutoSize = true
		});
		trackBar_5 = new TrackBar
		{
			Minimum = 0,
			Maximum = 200,
			Value = 0,
			TickFrequency = 20,
			Width = 180
		};
		label_6 = new Label
		{
			Text = Class16.smethod_0(1648924112),
			AutoSize = true
		};
		trackBar_5.ValueChanged += trackBar_5_ValueChanged;
		flowLayoutPanel.Controls.Add(trackBar_5);
		flowLayoutPanel.Controls.Add(label_6);
		tableLayoutPanel.Controls.Add(flowLayoutPanel, 0, 1);
		TabControl tabControl = new TabControl
		{
			Dock = DockStyle.Fill
		};
		tabControl.TabPages.Add(method_20());
		tabControl.TabPages.Add(method_21());
		tableLayoutPanel.Controls.Add(tabControl, 0, 2);
		panel_2.Controls.Add(tableLayoutPanel);
	}

	private TabPage method_20()
	{
		TabPage tabPage = new TabPage(Class16.smethod_0(1649085549));
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Top,
			AutoSize = true,
			ColumnCount = 4,
			Padding = new Padding(4)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34f));
		tableLayoutPanel.Controls.Add(new Label
		{
			Text = string.Empty,
			AutoSize = true
		}, 0, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648916453)), 1, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648916476)), 2, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648915467)), 3, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648893587)), 0, 1);
		textBox_9 = method_26();
		tableLayoutPanel.Controls.Add(textBox_9, 1, 1);
		textBox_10 = method_26();
		tableLayoutPanel.Controls.Add(textBox_10, 2, 1);
		textBox_11 = method_26();
		tableLayoutPanel.Controls.Add(textBox_11, 3, 1);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649085565)), 0, 2);
		textBox_12 = method_26();
		tableLayoutPanel.Controls.Add(textBox_12, 1, 2);
		textBox_13 = method_26();
		tableLayoutPanel.Controls.Add(textBox_13, 2, 2);
		textBox_14 = method_26();
		tableLayoutPanel.Controls.Add(textBox_14, 3, 2);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649103810)), 0, 3);
		textBox_15 = method_26();
		tableLayoutPanel.Controls.Add(textBox_15, 1, 3);
		textBox_16 = method_26();
		tableLayoutPanel.Controls.Add(textBox_16, 2, 3);
		textBox_17 = method_26();
		tableLayoutPanel.Controls.Add(textBox_17, 3, 3);
		button_1 = new Button
		{
			Text = Class16.smethod_0(1648996201),
			AutoSize = true,
			Dock = DockStyle.Left,
			FlatStyle = FlatStyle.Flat
		};
		button_1.Click += button_1_Click;
		tableLayoutPanel.SetColumnSpan(button_1, 4);
		tableLayoutPanel.Controls.Add(button_1, 0, 4);
		TextBox[] array = new TextBox[9] { textBox_9, textBox_10, textBox_11, textBox_12, textBox_13, textBox_14, textBox_15, textBox_16, textBox_17 };
		foreach (TextBox textBox in array)
		{
			textBox.KeyDown += method_378;
		}
		tabPage.Controls.Add(tableLayoutPanel);
		return tabPage;
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		if (class301_1?.class314_0 != null)
		{
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			if (float.TryParse(textBox_9.Text, NumberStyles.Float, invariantCulture, out var result) && float.TryParse(textBox_10.Text, NumberStyles.Float, invariantCulture, out var result2) && float.TryParse(textBox_11.Text, NumberStyles.Float, invariantCulture, out var result3))
			{
				class301_1.class314_0.vector3_0 = new Vector3(result, result2, result3);
				class301_1.vector3_1 = class301_1.class314_0.vector3_0;
				method_261();
				method_77();
				method_140();
				method_120(Class16.smethod_0(1649085581) + class301_1.string_0, null);
			}
		}
	}

	private TabPage method_21()
	{
		TabPage tabPage = new TabPage(Class16.smethod_0(1649050557));
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Top,
			AutoSize = true,
			ColumnCount = 2,
			Padding = new Padding(4)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649085616)), 0, 0);
		comboBox_1 = new ComboBox
		{
			Dock = DockStyle.Fill,
			DropDownStyle = ComboBoxStyle.DropDownList
		};
		comboBox_1.Items.AddRange(new object[3]
		{
			Class16.smethod_0(1649085633),
			Class16.smethod_0(1648915231),
			Class16.smethod_0(1649085648)
		});
		comboBox_1.SelectedIndex = 2;
		tableLayoutPanel.Controls.Add(comboBox_1, 1, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649085669)), 0, 1);
		textBox_18 = method_26();
		textBox_18.Text = Class16.smethod_0(1648898309);
		tableLayoutPanel.Controls.Add(textBox_18, 1, 1);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649085673)), 0, 2);
		textBox_19 = method_26();
		textBox_19.Text = Class16.smethod_0(1648898309);
		tableLayoutPanel.Controls.Add(textBox_19, 1, 2);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649085693)), 0, 3);
		textBox_20 = method_26();
		textBox_20.Text = Class16.smethod_0(1648898309);
		tableLayoutPanel.Controls.Add(textBox_20, 1, 3);
		checkBox_15 = new CheckBox
		{
			Text = Class16.smethod_0(1649085697),
			AutoSize = true
		};
		tableLayoutPanel.SetColumnSpan(checkBox_15, 2);
		tableLayoutPanel.Controls.Add(checkBox_15, 0, 4);
		tabPage.Controls.Add(tableLayoutPanel);
		return tabPage;
	}

	private void method_22()
	{
		tabPage_0 = new TabPage(Class16.smethod_0(1648977873))
		{
			UseVisualStyleBackColor = true
		};
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 1,
			RowCount = 3,
			Padding = new Padding(4)
		};
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 120f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 36f));
		GroupBox groupBox = new GroupBox
		{
			Text = Class16.smethod_0(1649085720),
			Dock = DockStyle.Fill
		};
		TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 2,
			AutoSize = true
		};
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110f));
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			AutoSize = true,
			WrapContents = true
		};
		checkBox_16 = new CheckBox
		{
			Text = Class16.smethod_0(1649085748),
			AutoSize = true
		};
		checkBox_17 = new CheckBox
		{
			Text = Class16.smethod_0(1649085765),
			AutoSize = true,
			Checked = true
		};
		checkBox_18 = new CheckBox
		{
			Text = Class16.smethod_0(1649085780),
			AutoSize = true
		};
		flowLayoutPanel.Controls.AddRange(new Control[3] { checkBox_16, checkBox_17, checkBox_18 });
		tableLayoutPanel2.SetColumnSpan(flowLayoutPanel, 2);
		tableLayoutPanel2.Controls.Add(flowLayoutPanel, 0, 0);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1649085796)), 0, 1);
		FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill,
			WrapContents = false
		};
		trackBar_6 = new TrackBar
		{
			Minimum = 1,
			Maximum = 100,
			Value = 50,
			Width = 160,
			TickFrequency = 10
		};
		label_7 = new Label
		{
			Text = Class16.smethod_0(1648914308),
			AutoSize = true,
			Margin = new Padding(2, 6, 0, 0)
		};
		trackBar_6.ValueChanged += trackBar_6_ValueChanged;
		flowLayoutPanel2.Controls.AddRange(new Control[2] { trackBar_6, label_7 });
		tableLayoutPanel2.Controls.Add(flowLayoutPanel2, 1, 1);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1649085801)), 0, 2);
		FlowLayoutPanel flowLayoutPanel3 = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill,
			WrapContents = false
		};
		trackBar_7 = new TrackBar
		{
			Minimum = 1,
			Maximum = 100,
			Value = 50,
			Width = 160,
			TickFrequency = 10
		};
		label_8 = new Label
		{
			Text = Class16.smethod_0(1649055691),
			AutoSize = true,
			Margin = new Padding(2, 6, 0, 0)
		};
		trackBar_7.ValueChanged += trackBar_7_ValueChanged;
		flowLayoutPanel3.Controls.AddRange(new Control[2] { trackBar_7, label_8 });
		tableLayoutPanel2.Controls.Add(flowLayoutPanel3, 1, 2);
		groupBox.Controls.Add(tableLayoutPanel2);
		tableLayoutPanel.Controls.Add(groupBox, 0, 0);
		listView_0 = new ListView
		{
			Dock = DockStyle.Fill,
			View = View.Details,
			FullRowSelect = true,
			HideSelection = false,
			GridLines = true
		};
		listView_0.Columns.Add(Class16.smethod_0(1649085819), 120);
		listView_0.Columns.Add(Class16.smethod_0(1648980967), 50);
		listView_0.Columns.Add(Class16.smethod_0(1649085833), 60);
		listView_0.Columns.Add(Class16.smethod_0(1649085849), 60);
		listView_0.Columns.Add(Class16.smethod_0(1649085864), 50);
		tableLayoutPanel.Controls.Add(listView_0, 0, 1);
		FlowLayoutPanel flowLayoutPanel4 = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill,
			WrapContents = false
		};
		button_2 = new Button
		{
			Text = Class16.smethod_0(1648980145),
			Width = 80
		};
		button_3 = new Button
		{
			Text = Class16.smethod_0(1648980165),
			Width = 80
		};
		flowLayoutPanel4.Controls.AddRange(new Control[2] { button_2, button_3 });
		tableLayoutPanel.Controls.Add(flowLayoutPanel4, 0, 2);
		tabPage_0.Controls.Add(tableLayoutPanel);
		tabControl_4.TabPages.Add(tabPage_0);
		method_116(Class16.smethod_0(1648977873), tabPage_0);
	}

	private void method_23()
	{
		panel_3 = new Panel
		{
			Dock = DockStyle.Fill,
			Visible = false
		};
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 1,
			RowCount = 5,
			Padding = new Padding(4)
		};
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 80f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 130f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 110f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		GroupBox groupBox = new GroupBox
		{
			Text = Class16.smethod_0(1648900812),
			Dock = DockStyle.Fill
		};
		TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 2,
			AutoSize = true
		};
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80f));
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1649085884)), 0, 0);
		panel_4 = new Panel
		{
			Width = 60,
			Height = 24,
			BorderStyle = BorderStyle.FixedSingle,
			BackColor = Color.White,
			Cursor = Cursors.Hand
		};
		panel_4.Click += panel_4_Click;
		tableLayoutPanel2.Controls.Add(panel_4, 1, 0);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1649085864)), 0, 1);
		textBox_21 = method_26();
		textBox_21.Text = Class16.smethod_0(1649085888);
		textBox_21.TextChanged += textBox_21_TextChanged;
		tableLayoutPanel2.Controls.Add(textBox_21, 1, 1);
		groupBox.Controls.Add(tableLayoutPanel2);
		tableLayoutPanel.Controls.Add(groupBox, 0, 0);
		GroupBox groupBox2 = new GroupBox
		{
			Text = Class16.smethod_0(1648893587),
			Dock = DockStyle.Fill
		};
		TableLayoutPanel tableLayoutPanel3 = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 4,
			AutoSize = true
		};
		tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30f));
		tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
		tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
		tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34f));
		tableLayoutPanel3.Controls.Add(smethod_75(Class16.smethod_0(1648916453)), 1, 0);
		tableLayoutPanel3.Controls.Add(smethod_75(Class16.smethod_0(1648916476)), 2, 0);
		tableLayoutPanel3.Controls.Add(smethod_75(Class16.smethod_0(1648915467)), 3, 0);
		tableLayoutPanel3.Controls.Add(smethod_75(Class16.smethod_0(1649085899)), 0, 1);
		textBox_25 = method_26();
		tableLayoutPanel3.Controls.Add(textBox_25, 1, 1);
		textBox_26 = method_26();
		tableLayoutPanel3.Controls.Add(textBox_26, 2, 1);
		textBox_27 = method_26();
		tableLayoutPanel3.Controls.Add(textBox_27, 3, 1);
		button_4 = new Button
		{
			Text = Class16.smethod_0(1648996201),
			AutoSize = true,
			FlatStyle = FlatStyle.Flat
		};
		button_4.Click += button_4_Click;
		button_5 = new Button
		{
			Text = Class16.smethod_0(1648925718),
			AutoSize = true,
			FlatStyle = FlatStyle.Flat
		};
		button_5.Click += button_5_Click;
		button_6 = new Button
		{
			Text = Class16.smethod_0(1649085917),
			AutoSize = true,
			FlatStyle = FlatStyle.Flat
		};
		button_6.Click += button_6_Click;
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			AutoSize = true,
			WrapContents = false,
			Dock = DockStyle.Left
		};
		flowLayoutPanel.Controls.AddRange(new Control[3] { button_4, button_5, button_6 });
		tableLayoutPanel3.SetColumnSpan(flowLayoutPanel, 4);
		tableLayoutPanel3.Controls.Add(flowLayoutPanel, 0, 2);
		TextBox[] array = new TextBox[3] { textBox_25, textBox_26, textBox_27 };
		foreach (TextBox textBox in array)
		{
			textBox.KeyDown += method_379;
		}
		groupBox2.Controls.Add(tableLayoutPanel3);
		tableLayoutPanel.Controls.Add(groupBox2, 0, 1);
		GroupBox groupBox3 = new GroupBox
		{
			Text = Class16.smethod_0(1649085935),
			Dock = DockStyle.Fill
		};
		FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill,
			WrapContents = false
		};
		radioButton_0 = new RadioButton
		{
			Text = Class16.smethod_0(1648941238),
			AutoSize = true
		};
		radioButton_1 = new RadioButton
		{
			Text = Class16.smethod_0(1648915231),
			AutoSize = true
		};
		radioButton_2 = new RadioButton
		{
			Text = Class16.smethod_0(1649084009),
			AutoSize = true,
			Checked = true
		};
		flowLayoutPanel2.Controls.Add(radioButton_0);
		flowLayoutPanel2.Controls.Add(radioButton_1);
		flowLayoutPanel2.Controls.Add(radioButton_2);
		groupBox3.Controls.Add(flowLayoutPanel2);
		tableLayoutPanel.Controls.Add(groupBox3, 0, 2);
		GroupBox groupBox4 = new GroupBox
		{
			Text = Class16.smethod_0(1649085938),
			Dock = DockStyle.Fill
		};
		TableLayoutPanel tableLayoutPanel4 = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 2,
			AutoSize = true
		};
		tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80f));
		tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel4.Controls.Add(smethod_75(Class16.smethod_0(1649084940)), 0, 0);
		textBox_22 = method_26();
		textBox_22.Text = Class16.smethod_0(1648898309);
		textBox_22.TextChanged += textBox_22_TextChanged;
		tableLayoutPanel4.Controls.Add(textBox_22, 1, 0);
		tableLayoutPanel4.Controls.Add(smethod_75(Class16.smethod_0(1649084947)), 0, 1);
		textBox_23 = method_26();
		textBox_23.Text = Class16.smethod_0(1649084960);
		textBox_23.TextChanged += textBox_23_TextChanged;
		tableLayoutPanel4.Controls.Add(textBox_23, 1, 1);
		tableLayoutPanel4.Controls.Add(smethod_75(Class16.smethod_0(1649084970)), 0, 2);
		textBox_24 = method_26();
		textBox_24.Text = Class16.smethod_0(1649084960);
		textBox_24.TextChanged += textBox_24_TextChanged;
		tableLayoutPanel4.Controls.Add(textBox_24, 1, 2);
		groupBox4.Controls.Add(tableLayoutPanel4);
		tableLayoutPanel.Controls.Add(groupBox4, 0, 3);
		panel_5 = new Panel
		{
			Dock = DockStyle.Fill,
			BackColor = Color.FromArgb(25, 25, 30),
			BorderStyle = BorderStyle.FixedSingle
		};
		panel_5.Paint += panel_5_Paint;
		tableLayoutPanel.Controls.Add(panel_5, 0, 4);
		panel_3.Controls.Add(tableLayoutPanel);
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		if (class301_1 == null)
		{
			return;
		}
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		if (!float.TryParse(textBox_25.Text, NumberStyles.Float, invariantCulture, out var result) || !float.TryParse(textBox_26.Text, NumberStyles.Float, invariantCulture, out var result2) || !float.TryParse(textBox_27.Text, NumberStyles.Float, invariantCulture, out var result3))
		{
			return;
		}
		if (class301_1.class314_0 != null)
		{
			class301_1.class314_0.vector3_0 = new Vector3(result, result2, result3);
			class301_1.vector3_1 = class301_1.class314_0.vector3_0;
		}
		if (sceneLightCollection_0 != null && class301_1.enum20_0 == Enum20.LightMarker && class301_1.int_0 >= 0 && class301_1.int_0 < sceneLightCollection_0.Lights.Count)
		{
			PwMapSceneLightFile.SceneLight sceneLight = sceneLightCollection_0.Lights[class301_1.int_0];
			sceneLight.Location = new Vector3(result, result2, 0f - result3);
			Color backColor = panel_4.BackColor;
			sceneLight.Diffuse = new Vector4((float)(int)backColor.R / 255f, (float)(int)backColor.G / 255f, (float)(int)backColor.B / 255f, 1f);
			if (float.TryParse(textBox_21.Text, NumberStyles.Float, invariantCulture, out var result4))
			{
				sceneLight.Range = result4;
			}
			if (radioButton_0.Checked)
			{
				sceneLight.Flags = 0;
			}
			else if (radioButton_1.Checked)
			{
				sceneLight.Flags = 1;
			}
			else
			{
				sceneLight.Flags = 2;
			}
			if (float.TryParse(textBox_22.Text, NumberStyles.Float, invariantCulture, out var result5))
			{
				sceneLight.Attenuation = result5;
			}
			if (float.TryParse(textBox_23.Text, NumberStyles.Float, invariantCulture, out var result6))
			{
				sceneLight.Attenuation2 = result6;
			}
			if (float.TryParse(textBox_24.Text, NumberStyles.Float, invariantCulture, out var result7))
			{
				sceneLight.Attenuation3 = result7;
			}
			class301_1.string_0 = string.Format(Class16.smethod_0(1649084986), class301_1.int_0 + 1, sceneLight.ModeLabel, sceneLight.Range);
		}
		method_276();
		method_261();
		method_321();
		method_77();
		method_140();
		method_120(Class16.smethod_0(1649085018) + class301_1.string_0, null);
	}

	private void panel_5_Paint(object sender, PaintEventArgs e)
	{
		if (panel_5 == null)
		{
			return;
		}
		float.TryParse(textBox_22?.Text, out var result);
		float.TryParse(textBox_23?.Text, out var result2);
		float.TryParse(textBox_24?.Text, out var result3);
		int num = panel_5.ClientSize.Width;
		int num2 = panel_5.ClientSize.Height;
		if (num < 10 || num2 < 10)
		{
			return;
		}
		Graphics graphics = e.Graphics;
		graphics.SmoothingMode = SmoothingMode.AntiAlias;
		Pen pen = new Pen(Color.DimGray, 1f);
		try
		{
			graphics.DrawLine(pen, 0, num2 - 1, num, num2 - 1);
			graphics.DrawLine(pen, 0, 0, 0, num2);
		}
		finally
		{
			((IDisposable)pen).Dispose();
		}
		float result4 = 1f;
		float.TryParse(textBox_21?.Text, out result4);
		if (result4 < 0.01f)
		{
			result4 = 1f;
		}
		Pen pen2 = new Pen(Color.LimeGreen, 2f);
		try
		{
			int y = num2;
			for (int i = 0; i < num; i++)
			{
				float num3 = (float)i / (float)num * result4;
				float num4 = result + result2 * num3 + result3 * num3 * num3;
				float val = ((num4 > 0.001f) ? (1f / num4) : 1f);
				val = Math.Max(0f, Math.Min(1f, val));
				int num5 = num2 - (int)(val * (float)(num2 - 4));
				if (i > 0)
				{
					graphics.DrawLine(pen2, i - 1, y, i, num5);
				}
				y = num5;
			}
		}
		finally
		{
			((IDisposable)pen2).Dispose();
		}
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		if (class301_1 != null && class301_1.enum20_0 == Enum20.LightMarker && sceneLightCollection_0 != null)
		{
			int num = class301_1.int_0;
			if (num >= 0 && num < sceneLightCollection_0.Lights.Count)
			{
				sceneLightCollection_0.Lights.RemoveAt(num);
				method_319(bool_37: false);
				method_276();
				method_261();
				method_120(string.Format(Class16.smethod_0(1649085061), num + 1), null);
			}
		}
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		if (sceneLightCollection_0 != null && sceneLightCollection_0.Lights.Count != 0)
		{
			string text = method_147();
			if (!string.IsNullOrWhiteSpace(text) && pwMapTrn2File_0 != null)
			{
				string mapRootPath = pwMapTrn2File_0.MapRootPath;
				if (string.IsNullOrWhiteSpace(mapRootPath))
				{
					return;
				}
				string text2 = System.IO.Path.Combine(mapRootPath, Class16.smethod_0(1649094124), text, text + Class16.smethod_0(1649085145));
				try
				{
					string directoryName = System.IO.Path.GetDirectoryName(text2);
					if (!Directory.Exists(directoryName))
					{
						Directory.CreateDirectory(directoryName);
					}
					PwMapSceneLightFile.Save(sceneLightCollection_0, text2);
					method_120(string.Format(Class16.smethod_0(1649085162), sceneLightCollection_0.Lights.Count, text2), null);
					return;
				}
				catch (Exception ex)
				{
					MessageBox.Show(Class16.smethod_0(1649085192) + ex.Message, Class16.smethod_0(1649003931), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
			}
			method_120(Class16.smethod_0(1649085111), null);
		}
		else
		{
			method_120(Class16.smethod_0(1649085086), null);
		}
	}

	private void method_24()
	{
		panel_6 = new Panel
		{
			Dock = DockStyle.Fill,
			Visible = false
		};
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 1,
			RowCount = 3,
			Padding = new Padding(4)
		};
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 44f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		label_9 = new Label
		{
			Text = Class16.smethod_0(1649085498),
			Dock = DockStyle.Fill,
			AutoEllipsis = true,
			Cursor = Cursors.Hand
		};
		label_9.Click += label_9_Click;
		tableLayoutPanel.Controls.Add(label_9, 0, 0);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			AutoSize = true,
			Dock = DockStyle.Fill,
			WrapContents = false
		};
		flowLayoutPanel.Controls.Add(new Label
		{
			Text = Class16.smethod_0(1649085535),
			AutoSize = true
		});
		trackBar_8 = new TrackBar
		{
			Minimum = 0,
			Maximum = 200,
			Value = 0,
			TickFrequency = 20,
			Width = 180
		};
		label_10 = new Label
		{
			Text = Class16.smethod_0(1648924112),
			AutoSize = true
		};
		trackBar_8.ValueChanged += trackBar_8_ValueChanged;
		flowLayoutPanel.Controls.Add(trackBar_8);
		flowLayoutPanel.Controls.Add(label_10);
		tableLayoutPanel.Controls.Add(flowLayoutPanel, 0, 1);
		tabControl_0 = new TabControl
		{
			Dock = DockStyle.Fill
		};
		tabControl_0.TabPages.Add(method_25());
		tabControl_0.TabPages.Add(method_28());
		tabControl_0.TabPages.Add(method_29());
		tabControl_0.TabPages.Add(method_30());
		tableLayoutPanel.Controls.Add(tabControl_0, 0, 2);
		panel_6.Controls.Add(tableLayoutPanel);
	}

	private TabPage method_25()
	{
		TabPage tabPage = new TabPage(Class16.smethod_0(1649085549));
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Top,
			AutoSize = true,
			ColumnCount = 4,
			Padding = new Padding(4)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34f));
		tableLayoutPanel.Controls.Add(new Label
		{
			Text = string.Empty,
			AutoSize = true
		}, 0, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648916453)), 1, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648916476)), 2, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648915467)), 3, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648893587)), 0, 1);
		textBox_28 = method_26();
		tableLayoutPanel.Controls.Add(textBox_28, 1, 1);
		textBox_29 = method_26();
		tableLayoutPanel.Controls.Add(textBox_29, 2, 1);
		textBox_30 = method_26();
		tableLayoutPanel.Controls.Add(textBox_30, 3, 1);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649085565)), 0, 2);
		textBox_31 = method_26();
		tableLayoutPanel.Controls.Add(textBox_31, 1, 2);
		textBox_32 = method_26();
		tableLayoutPanel.Controls.Add(textBox_32, 2, 2);
		textBox_33 = method_26();
		tableLayoutPanel.Controls.Add(textBox_33, 3, 2);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649103810)), 0, 3);
		textBox_34 = method_26();
		tableLayoutPanel.Controls.Add(textBox_34, 1, 3);
		textBox_35 = method_26();
		tableLayoutPanel.Controls.Add(textBox_35, 2, 3);
		textBox_36 = method_26();
		tableLayoutPanel.Controls.Add(textBox_36, 3, 3);
		button_11 = new Button
		{
			Text = Class16.smethod_0(1648996201),
			AutoSize = true,
			Dock = DockStyle.Left,
			FlatStyle = FlatStyle.Flat
		};
		button_11.Click += button_11_Click;
		tableLayoutPanel.SetColumnSpan(button_11, 4);
		tableLayoutPanel.Controls.Add(button_11, 0, 4);
		TextBox[] array = new TextBox[9] { textBox_28, textBox_29, textBox_30, textBox_31, textBox_32, textBox_33, textBox_34, textBox_35, textBox_36 };
		foreach (TextBox textBox in array)
		{
			textBox.KeyDown += method_380;
		}
		tabPage.Controls.Add(tableLayoutPanel);
		return tabPage;
	}

	private TextBox method_26()
	{
		return new TextBox
		{
			Dock = DockStyle.Fill,
			Font = new Font(Class16.smethod_0(1648929975), 8.25f),
			TextAlign = HorizontalAlignment.Right
		};
	}

	private void button_11_Click(object sender, EventArgs e)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		if (class301_1?.class314_0 != null)
		{
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			if (float.TryParse(textBox_28.Text, NumberStyles.Float, invariantCulture, out var result) && float.TryParse(textBox_29.Text, NumberStyles.Float, invariantCulture, out var result2) && float.TryParse(textBox_30.Text, NumberStyles.Float, invariantCulture, out var result3))
			{
				class301_1.class314_0.vector3_0 = new Vector3(result, result2, result3);
				class301_1.vector3_1 = class301_1.class314_0.vector3_0;
				method_261();
				method_77();
				method_140();
				method_120(Class16.smethod_0(1649085581) + class301_1.string_0, null);
			}
		}
	}

	private Panel method_27()
	{
		Class311 @class = new Class311();
		@class.pwMapSharpDxEditorForm_0 = this;
		@class.panel_0 = new Panel
		{
			Width = 60,
			Height = 24,
			BorderStyle = BorderStyle.FixedSingle,
			BackColor = Color.Gray,
			Cursor = Cursors.Hand
		};
		@class.panel_0.Click += @class.method_0;
		return @class.panel_0;
	}

	private TabPage method_28()
	{
		TabPage tabPage = new TabPage(Class16.smethod_0(1648916263));
		SplitContainer splitContainer = new SplitContainer
		{
			Dock = DockStyle.Fill,
			Orientation = Orientation.Horizontal,
			SplitterDistance = 120
		};
		listView_1 = new ListView
		{
			Dock = DockStyle.Fill,
			View = View.Details,
			FullRowSelect = true,
			GridLines = true
		};
		listView_1.Columns.Add(Class16.smethod_0(1648916345), 100);
		listView_1.Columns.Add(Class16.smethod_0(1649085819), 200);
		splitContainer.Panel1.Controls.Add(listView_1);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill,
			FlowDirection = FlowDirection.LeftToRight
		};
		pictureBox_1 = new PictureBox
		{
			Width = 100,
			Height = 100,
			SizeMode = PictureBoxSizeMode.Zoom,
			BorderStyle = BorderStyle.FixedSingle
		};
		button_7 = new Button
		{
			Text = Class16.smethod_0(1649085228),
			AutoSize = true
		};
		flowLayoutPanel.Controls.Add(pictureBox_1);
		flowLayoutPanel.Controls.Add(button_7);
		splitContainer.Panel2.Controls.Add(flowLayoutPanel);
		tabPage.Controls.Add(splitContainer);
		return tabPage;
	}

	private TabPage method_29()
	{
		TabPage tabPage = new TabPage(Class16.smethod_0(1649085247));
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Top,
			AutoSize = true,
			ColumnCount = 3,
			Padding = new Padding(4)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel.Controls.Add(smethod_75(string.Empty), 0, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648941238)), 1, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648915231)), 2, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649085262)), 0, 1);
		panel_7 = method_27();
		tableLayoutPanel.Controls.Add(panel_7, 1, 1);
		panel_8 = method_27();
		tableLayoutPanel.Controls.Add(panel_8, 2, 1);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648915490)), 0, 2);
		panel_9 = method_27();
		tableLayoutPanel.Controls.Add(panel_9, 1, 2);
		panel_10 = method_27();
		tableLayoutPanel.Controls.Add(panel_10, 2, 2);
		checkBox_19 = new CheckBox
		{
			Text = Class16.smethod_0(1649085276),
			AutoSize = true
		};
		tableLayoutPanel.SetColumnSpan(checkBox_19, 3);
		tableLayoutPanel.Controls.Add(checkBox_19, 0, 3);
		checkBox_20 = new CheckBox
		{
			Text = Class16.smethod_0(1649085289),
			AutoSize = true
		};
		tableLayoutPanel.SetColumnSpan(checkBox_20, 3);
		tableLayoutPanel.Controls.Add(checkBox_20, 0, 4);
		button_8 = new Button
		{
			Text = Class16.smethod_0(1649085324),
			AutoSize = true
		};
		tableLayoutPanel.SetColumnSpan(button_8, 3);
		tableLayoutPanel.Controls.Add(button_8, 0, 5);
		tabPage.Controls.Add(tableLayoutPanel);
		return tabPage;
	}

	private TabPage method_30()
	{
		TabPage tabPage = new TabPage(Class16.smethod_0(1648914501));
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 1,
			RowCount = 2
		};
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 36f));
		listView_2 = new ListView
		{
			Dock = DockStyle.Fill,
			View = View.Details,
			FullRowSelect = true,
			CheckBoxes = true,
			GridLines = true
		};
		listView_2.Columns.Add(Class16.smethod_0(1649085339), 120);
		listView_2.Columns.Add(Class16.smethod_0(1649085359), 70);
		tableLayoutPanel.Controls.Add(listView_2, 0, 0);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill,
			WrapContents = false
		};
		button_9 = new Button
		{
			Text = Class16.smethod_0(1649085765),
			AutoSize = true
		};
		button_10 = new Button
		{
			Text = Class16.smethod_0(1649085373),
			AutoSize = true
		};
		button_9.Click += button_9_Click;
		button_10.Click += button_10_Click;
		flowLayoutPanel.Controls.Add(button_9);
		flowLayoutPanel.Controls.Add(button_10);
		tableLayoutPanel.Controls.Add(flowLayoutPanel, 0, 1);
		tabPage.Controls.Add(tableLayoutPanel);
		return tabPage;
	}

	private void method_31()
	{
		regionFile_0 = null;
		precinctFile_0 = null;
		if (File.Exists(pwMapFileLayout_0.RegionFile))
		{
			try
			{
				RegionFile regionFile = new RegionFile();
				if (regionFile.ReadFile(pwMapFileLayout_0.RegionFile))
				{
					regionFile_0 = regionFile;
				}
			}
			catch
			{
			}
		}
		if (File.Exists(pwMapFileLayout_0.PrecinctFile))
		{
			try
			{
				PrecinctFile precinctFile = new PrecinctFile();
				if (precinctFile.ReadFile(pwMapFileLayout_0.PrecinctFile))
				{
					precinctFile_0 = precinctFile;
				}
			}
			catch
			{
			}
		}
		method_325();
		method_319(bool_37: false);
		method_32();
		method_34();
	}

	private void method_32()
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		if (device_0 == null)
		{
			return;
		}
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
		int_11 = 0;
		List<Struct74> list = method_33();
		if (list.Count <= 1)
		{
			method_321();
			return;
		}
		int_11 = list.Count;
		vertexBuffer_1 = new VertexBuffer(device_0, int_11 * Struct74.int_1, (Usage)8, (VertexFormat)0, (Pool)1);
		DataStream val = vertexBuffer_1.Lock(0, 0, (LockFlags)0);
		val.WriteRange<Struct74>(list.ToArray());
		vertexBuffer_1.Unlock();
		method_321();
	}

	private List<Struct74> method_33()
	{
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		List<Struct74> list = new List<Struct74>(1024);
		bool_4 = false;
		if (checkBox_29.Checked && regionFile_0?.regions != null)
		{
			for (int i = 0; i < regionFile_0.regions.Count; i++)
			{
				RegionEntry regionEntry = regionFile_0.regions[i];
				method_35(list, regionEntry?.Zones, smethod_1(regionEntry?.Type ?? 0));
			}
		}
		if (checkBox_31.Checked && regionFile_0?.teleports != null)
		{
			for (int j = 0; j < regionFile_0.teleports.Count; j++)
			{
				method_37(list, regionFile_0.teleports[j]);
			}
		}
		if (checkBox_30.Checked && precinctFile_0?.zones != null)
		{
			for (int k = 0; k < precinctFile_0.zones.Count; k++)
			{
				method_36(list, precinctFile_0.zones[k]?.m_aPoints, -12801793);
			}
		}
		if (checkBox_32.Checked && precinctFile_0?.zones != null)
		{
			for (int l = 0; l < precinctFile_0.zones.Count; l++)
			{
				PrecinctEntry precinctEntry = precinctFile_0.zones[l];
				method_38(list, smethod_3(precinctEntry.m_vCityPos), 4f, -154);
				if (precinctEntry.Npcs != null)
				{
					for (int m = 0; m < precinctEntry.Npcs.Count; m++)
					{
						method_38(list, smethod_3(precinctEntry.Npcs[m].position), 2f, -39169);
					}
				}
			}
		}
		return list;
	}

	private static int smethod_1(int int_40)
	{
		return int_40 switch
		{
			0 => -41892, 
			1 => -9707152, 
			2 => -10962689, 
			3 => -6324481, 
			4 => -25284, 
			5 => -16722232, 
			6 => -6582, 
			7 => -1419009, 
			8 => -1, 
			_ => -4737097, 
		};
	}

	private void method_34()
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_4)
		{
			return;
		}
		PwMapFileLayout pwMapFileLayout = pwMapFileLayout_0;
		object obj;
		if (pwMapFileLayout == null)
		{
			obj = null;
		}
		else
		{
			obj = pwMapFileLayout.MapName;
			if (obj != null)
			{
				goto IL_0024;
			}
		}
		obj = string.Empty;
		goto IL_0024;
		IL_0024:
		string b = (string)obj;
		if (!string.Equals(string_0, b, StringComparison.OrdinalIgnoreCase))
		{
			string_0 = b;
			Vector3 val = (vector3_0 + vector3_1) * 0.5f;
			Vector3 val2 = vector3_1 - vector3_0;
			float num = Math.Max(32f, Math.Max(val2.X, Math.Max(val2.Y, val2.Z)) * 0.5f);
			vector3_2 = val;
			float_1 = Math.Max(120f, num * 2.1f);
		}
	}

	private void method_35(List<Struct74> list_13, List<RegionVector3> list_14, int int_40)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		if (list_14 != null && list_14.Count >= 2)
		{
			for (int i = 0; i < list_14.Count - 1; i++)
			{
				method_39(list_13, smethod_2(list_14[i]), smethod_2(list_14[i + 1]), int_40);
			}
			Vector3 val = smethod_2(list_14[0]);
			Vector3 val2 = smethod_2(list_14[list_14.Count - 1]);
			Vector3 val3 = val - val2;
			if (val3.LengthSquared() > 0.01f)
			{
				method_39(list_13, val2, val, int_40);
			}
		}
	}

	private void method_36(List<Struct74> list_13, List<PrecinctVector3> list_14, int int_40)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		if (list_14 != null && list_14.Count >= 2)
		{
			for (int i = 0; i < list_14.Count - 1; i++)
			{
				method_39(list_13, smethod_3(list_14[i]), smethod_3(list_14[i + 1]), int_40);
			}
			Vector3 val = smethod_3(list_14[0]);
			Vector3 val2 = smethod_3(list_14[list_14.Count - 1]);
			Vector3 val3 = val - val2;
			if (val3.LengthSquared() > 0.01f)
			{
				method_39(list_13, val2, val, int_40);
			}
		}
	}

	private void method_37(List<Struct74> list_13, CELTransportBox celtransportBox_0)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		if (celtransportBox_0 != null)
		{
			Vector3 val = smethod_2(celtransportBox_0.tm_vPos);
			Vector3 val2 = default(Vector3);
			val2 = new Vector3(Math.Abs(celtransportBox_0.m_vExts.Single_0), Math.Abs(celtransportBox_0.m_vExts.Single_1), Math.Abs(celtransportBox_0.m_vExts.Single_2));
			Vector3[] array = (Vector3[])(object)new Vector3[8]
			{
				val + new Vector3(0f - val2.X, 0f - val2.Y, 0f - val2.Z),
				val + new Vector3(val2.X, 0f - val2.Y, 0f - val2.Z),
				val + new Vector3(val2.X, 0f - val2.Y, val2.Z),
				val + new Vector3(0f - val2.X, 0f - val2.Y, val2.Z),
				val + new Vector3(0f - val2.X, val2.Y, 0f - val2.Z),
				val + new Vector3(val2.X, val2.Y, 0f - val2.Z),
				val + new Vector3(val2.X, val2.Y, val2.Z),
				val + new Vector3(0f - val2.X, val2.Y, val2.Z)
			};
			int int_ = -19641;
			int[] array2 = new int[24]
			{
				0, 1, 1, 2, 2, 3, 3, 0, 4, 5,
				5, 6, 6, 7, 7, 4, 0, 4, 1, 5,
				2, 6, 3, 7
			};
			for (int i = 0; i < array2.Length; i += 2)
			{
				method_39(list_13, array[array2[i]], array[array2[i + 1]], int_);
			}
			Vector3 val3 = smethod_2(celtransportBox_0.m_vTarge);
			method_39(list_13, val, val3, -9571585);
			method_38(list_13, val3, 2.2f, -9571585);
		}
	}

	private void method_38(List<Struct74> list_13, Vector3 vector3_5, float float_14, int int_40)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		method_39(list_13, vector3_5 + new Vector3(0f - float_14, 0f, 0f), vector3_5 + new Vector3(float_14, 0f, 0f), int_40);
		method_39(list_13, vector3_5 + new Vector3(0f, 0f - float_14, 0f), vector3_5 + new Vector3(0f, float_14, 0f), int_40);
		method_39(list_13, vector3_5 + new Vector3(0f, 0f, 0f - float_14), vector3_5 + new Vector3(0f, 0f, float_14), int_40);
	}

	private void method_39(List<Struct74> list_13, Vector3 vector3_5, Vector3 vector3_6, int int_40)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		if (list_13.Count + 2 <= 1000000)
		{
			list_13.Add(new Struct74
			{
				vector3_0 = vector3_5,
				int_0 = int_40
			});
			list_13.Add(new Struct74
			{
				vector3_0 = vector3_6,
				int_0 = int_40
			});
			method_40(vector3_5);
			method_40(vector3_6);
		}
	}

	private void method_40(Vector3 vector3_5)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_4)
		{
			bool_4 = true;
			vector3_0 = vector3_5;
			vector3_1 = vector3_5;
			return;
		}
		vector3_0.X = Math.Min(vector3_0.X, vector3_5.X);
		vector3_0.Y = Math.Min(vector3_0.Y, vector3_5.Y);
		vector3_0.Z = Math.Min(vector3_0.Z, vector3_5.Z);
		vector3_1.X = Math.Max(vector3_1.X, vector3_5.X);
		vector3_1.Y = Math.Max(vector3_1.Y, vector3_5.Y);
		vector3_1.Z = Math.Max(vector3_1.Z, vector3_5.Z);
	}

	private static Vector3 smethod_2(RegionVector3 regionVector3_0)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		return new Vector3(regionVector3_0.Single_0, regionVector3_0.Single_1, 0f - regionVector3_0.Single_2);
	}

	private static Vector3 smethod_3(PrecinctVector3 precinctVector3_0)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		return new Vector3(precinctVector3_0.Single_0, precinctVector3_0.Single_1, 0f - precinctVector3_0.Single_2);
	}

	private void method_41()
	{
		toolStripMenuItem_1.Click += toolStripMenuItem_1_Click;
		toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
		toolStripMenuItem_3.Click += toolStripMenuItem_3_Click;
		toolStripMenuItem_4.Click += toolStripMenuItem_4_Click;
		toolStripMenuItem_16.Click += toolStripMenuItem_16_Click;
		toolStripMenuItem_17.Click += toolStripMenuItem_17_Click;
		toolStripMenuItem_19.Click += toolStripMenuItem_19_Click;
		toolStripMenuItem_20.Click += toolStripMenuItem_20_Click;
		toolStripMenuItem_21.Click += toolStripMenuItem_21_Click;
		toolStripMenuItem_23.Click += toolStripMenuItem_23_Click;
		toolStripMenuItem_26.Click += toolStripMenuItem_26_Click;
		toolStripMenuItem_25.Click += toolStripMenuItem_25_Click;
		toolStripMenuItem_6.CheckedChanged += toolStripMenuItem_6_CheckedChanged;
		toolStripMenuItem_7.CheckedChanged += toolStripMenuItem_7_CheckedChanged;
		toolStripMenuItem_8.CheckedChanged += toolStripMenuItem_8_CheckedChanged;
		toolStripMenuItem_9.CheckedChanged += toolStripMenuItem_9_CheckedChanged;
		toolStripMenuItem_10.CheckedChanged += toolStripMenuItem_10_CheckedChanged;
		toolStripMenuItem_11.CheckedChanged += toolStripMenuItem_11_CheckedChanged;
		toolStripMenuItem_12.Click += toolStripMenuItem_12_Click;
		toolStripMenuItem_13.CheckedChanged += toolStripMenuItem_13_CheckedChanged;
		toolStripMenuItem_14.Click += toolStripMenuItem_14_Click;
		toolStripButton_14.Click += toolStripButton_14_Click;
		button_45.Click += button_45_Click;
	}

	private void method_42()
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		StringBuilder stringBuilder = new StringBuilder(Class16.smethod_0(1649085388));
		stringBuilder.AppendLine();
		stringBuilder.AppendLine();
		for (int i = 0; i < 9; i++)
		{
			Struct80 @struct = struct80_0[i];
			if (@struct.float_2 > 0.01f)
			{
				stringBuilder.AppendLine(string.Format(Class16.smethod_0(1649084422), i + 1, @struct.vector3_0.X, @struct.vector3_0.Y, @struct.vector3_0.Z, @struct.float_2));
			}
			else
			{
				stringBuilder.AppendLine(string.Format(Class16.smethod_0(1649084479), i + 1));
			}
		}
		MessageBox.Show(this, stringBuilder.ToString(), Class16.smethod_0(1649084502), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		PwMapMapOpenDialog pwMapMapOpenDialog = new PwMapMapOpenDialog();
		try
		{
			List<string> list = new List<string>();
			string mapsBasePath = pwMapPreferencesStore_0.MapsBasePath;
			if (!string.IsNullOrWhiteSpace(mapsBasePath))
			{
				list.Add(mapsBasePath);
			}
			string text = (string.IsNullOrWhiteSpace(pwMapPreferencesStore_0.Settings.WorkingPath) ? string.Empty : System.IO.Path.Combine(pwMapPreferencesStore_0.Settings.WorkingPath, Class16.smethod_0(1649094124)));
			if (!string.IsNullOrWhiteSpace(text))
			{
				list.Add(text);
			}
			if (list.Count == 0)
			{
				string text2 = (textBox_81.Text ?? string.Empty).Trim();
				if (!string.IsNullOrEmpty(text2))
				{
					list.Add(text2);
				}
			}
			pwMapMapOpenDialog.InitializeFromPreferences(list.ToArray());
			string text3 = (textBox_80.Text ?? string.Empty).Trim();
			if (!string.IsNullOrEmpty(text3))
			{
				pwMapMapOpenDialog.SelectMap(text3);
			}
			if (pwMapMapOpenDialog.ShowDialog(this) == DialogResult.OK)
			{
				string selectedMapPath = pwMapMapOpenDialog.SelectedMapPath;
				if (!string.IsNullOrEmpty(selectedMapPath))
				{
					string text4 = System.IO.Path.GetDirectoryName(selectedMapPath) ?? string.Empty;
					textBox_81.Text = text4;
					textBox_80.Text = pwMapMapOpenDialog.SelectedMapName;
					method_120(Class16.smethod_0(1649084525) + pwMapMapOpenDialog.SelectedMapName, null);
					_ = method_122();
				}
			}
		}
		finally
		{
			((IDisposable)pwMapMapOpenDialog).Dispose();
		}
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		method_132();
		PwMapPreferencesDialog pwMapPreferencesDialog = new PwMapPreferencesDialog(pwMapPreferencesStore_0);
		try
		{
			pwMapPreferencesDialog.ShowDialog(this);
			if (pwMapPreferencesDialog.WasSaved)
			{
				method_131();
				method_120(Class16.smethod_0(1649084538), null);
			}
		}
		finally
		{
			((IDisposable)pwMapPreferencesDialog).Dispose();
		}
	}

	private void method_43()
	{
		method_157();
	}

	private void method_44()
	{
		PwMapExportClientDialog pwMapExportClientDialog = new PwMapExportClientDialog();
		try
		{
			if (pwMapExportClientDialog.ShowDialog(this) == DialogResult.OK)
			{
				method_141();
			}
		}
		finally
		{
			((IDisposable)pwMapExportClientDialog).Dispose();
		}
	}

	private void method_45()
	{
		pictureBox_2 = pictureBox_7;
		pictureBox_2.Paint += pictureBox_2_Paint;
		pictureBox_2.MouseDown += pictureBox_9_MouseDown;
		pictureBox_8.Paint += pictureBox_8_Paint;
		pictureBox_8.MouseDown += pictureBox_9_MouseDown;
		pictureBox_9.Paint += pictureBox_9_Paint;
		pictureBox_9.MouseDown += pictureBox_9_MouseDown;
		button_46.Click += button_46_Click;
	}

	private void pictureBox_9_MouseDown(object sender, MouseEventArgs e)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		if (pwMapTrn2File_0 == null)
		{
			return;
		}
		float num = pwMapTrn2File_0.Width;
		float num2 = pwMapTrn2File_0.Height;
		if (!(num <= 0f) && num2 > 0f)
		{
			int num3 = pictureBox_2.Width;
			int num4 = pictureBox_2.Height;
			if (num3 > 0 && num4 > 0)
			{
				float num5 = (float)e.X / (float)num3 - 0.5f;
				float num6 = (float)e.Y / (float)num4 - 0.5f;
				float num7 = num5 * num;
				float num8 = num6 * num2;
				vector3_2 = new Vector3(num7, vector3_2.Y, num8);
				pictureBox_2.Invalidate();
			}
		}
	}

	private void pictureBox_2_Paint(object sender, PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
		graphics.SmoothingMode = SmoothingMode.AntiAlias;
		int int_ = pictureBox_2.Width;
		int int_2 = pictureBox_2.Height;
		if (bitmap_0 != null)
		{
			graphics.DrawImage(bitmap_0, 0, 0, int_, int_2);
		}
		else
		{
			method_46(graphics, int_, int_2);
		}
		method_47(graphics, int_, int_2);
	}

	private void method_46(Graphics graphics_0, int int_40, int int_41)
	{
		int num = pwMapTrn2File_0?.SectorsWide ?? 1;
		int num2 = pwMapTrn2File_0?.SectorsHigh ?? 1;
		if (num < 1)
		{
			num = 1;
		}
		if (num2 < 1)
		{
			num2 = 1;
		}
		float num3 = (float)int_40 / (float)num;
		float num4 = (float)int_41 / (float)num2;
		Pen pen = new Pen(Color.FromArgb(60, 80, 80, 80), 1f);
		try
		{
			for (int i = 0; i <= num; i++)
			{
				graphics_0.DrawLine(pen, (float)i * num3, 0f, (float)i * num3, int_41);
			}
			for (int j = 0; j <= num2; j++)
			{
				graphics_0.DrawLine(pen, 0f, (float)j * num4, int_40, (float)j * num4);
			}
			string s = string.Format(Class16.smethod_0(1649084563), num, num2, pwMapTrn2File_0?.TotalSectors ?? 0);
			Font font = new Font(Class16.smethod_0(1648942905), 7f);
			try
			{
				SolidBrush solidBrush = new SolidBrush(Color.FromArgb(120, 200, 200, 200));
				try
				{
					graphics_0.DrawString(s, font, solidBrush, 4f, 4f);
				}
				finally
				{
					((IDisposable)solidBrush).Dispose();
				}
			}
			finally
			{
				((IDisposable)font).Dispose();
			}
		}
		finally
		{
			((IDisposable)pen).Dispose();
		}
	}

	private void method_47(Graphics graphics_0, int int_40, int int_41)
	{
		if (pwMapTrn2File_0 == null)
		{
			return;
		}
		float num = pwMapTrn2File_0.Width;
		float num2 = pwMapTrn2File_0.Height;
		if (num <= 0f || !(num2 > 0f))
		{
			return;
		}
		float num3 = (vector3_2.X / num + 0.5f) * (float)int_40;
		float num4 = (vector3_2.Z / num2 + 0.5f) * (float)int_41;
		SolidBrush solidBrush = new SolidBrush(Color.Yellow);
		try
		{
			graphics_0.FillEllipse(solidBrush, num3 - 3f, num4 - 3f, 6f, 6f);
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
		Pen pen = new Pen(Color.FromArgb(180, 255, 200, 0), 1f);
		try
		{
			graphics_0.DrawEllipse(pen, num3 - 6f, num4 - 6f, 12f, 12f);
		}
		finally
		{
			((IDisposable)pen).Dispose();
		}
		float num5 = (float)Math.Sin(float_2) * 12f;
		float num6 = (0f - (float)Math.Cos(float_2)) * 12f;
		Pen pen2 = new Pen(Color.Orange, 1.5f);
		try
		{
			pen2.EndCap = LineCap.ArrowAnchor;
			graphics_0.DrawLine(pen2, num3, num4, num3 + num5, num4 + num6);
		}
		finally
		{
			((IDisposable)pen2).Dispose();
		}
	}

	private void method_48()
	{
		method_49();
		method_52();
		pictureBox_2?.Invalidate();
		pictureBox_8?.Invalidate();
		pictureBox_9?.Invalidate();
		method_120(Class16.smethod_0(1649084599), null);
	}

	private void method_49()
	{
		bitmap_0?.Dispose();
		bitmap_0 = null;
		if (pwMapTrn2File_0 == null || pwMapTrn2File_0.TotalSectors <= 0)
		{
			return;
		}
		int sectorsWide = pwMapTrn2File_0.SectorsWide;
		int sectorsHigh = pwMapTrn2File_0.SectorsHigh;
		if (sectorsWide <= 0 || sectorsHigh <= 0)
		{
			return;
		}
		int int_ = Math.Max(1, (int)(pwMapTrn2File_0.Width / (float)sectorsWide));
		int int_2 = Math.Max(1, (int)(pwMapTrn2File_0.Height / (float)sectorsHigh));
		int int_3 = 32;
		int int_4 = sectorsWide * 32;
		int num = sectorsHigh * 32;
		Bitmap bitmap = new Bitmap(int_4, num, PixelFormat.Format32bppArgb);
		float num2 = float.MaxValue;
		float num3 = float.MinValue;
		for (int i = 0; i < pwMapTrn2File_0.SectorHeights.Count; i++)
		{
			(float, float) tuple = pwMapTrn2File_0.SectorHeights[i];
			if (tuple.Item1 < num2)
			{
				(num2, _) = tuple;
			}
			if (tuple.Item2 > num3)
			{
				num3 = tuple.Item2;
			}
		}
		float num4 = num3 - num2;
		if (num4 < 1f)
		{
			num4 = 1f;
		}
		BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, int_4, num), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
		try
		{
			for (int j = 0; j < pwMapTrn2File_0.TotalSectors; j++)
			{
				int int_5 = j / sectorsWide;
				int int_6 = j % sectorsWide;
				PwMapT2bkFile pwMapT2bkFile = method_363(j, int_, int_2);
				if (pwMapT2bkFile != null)
				{
					method_51(bitmapData, int_4, int_6, int_5, int_3, pwMapT2bkFile, num2, num4);
				}
				else
				{
					method_50(bitmapData, int_4, int_6, int_5, int_3, j, num2, num4);
				}
			}
		}
		finally
		{
			bitmap.UnlockBits(bitmapData);
		}
		bitmap_0 = bitmap;
	}

	private unsafe void method_50(BitmapData bitmapData_0, int int_40, int int_41, int int_42, int int_43, int int_44, float float_14, float float_15)
	{
		float num = method_364(int_44);
		float float_16 = Math.Max(0f, Math.Min(1f, (num - float_14) / float_15));
		int num2 = smethod_4(float_16).ToArgb();
		int num3 = int_41 * int_43;
		int num4 = int_42 * int_43;
		for (int i = 0; i < int_43; i++)
		{
			int* ptr = (int*)((byte*)(void*)bitmapData_0.Scan0 + (num4 + i) * bitmapData_0.Stride) + num3;
			for (int j = 0; j < int_43; j++)
			{
				ptr[j] = num2;
			}
		}
	}

	private unsafe void method_51(BitmapData bitmapData_0, int int_40, int int_41, int int_42, int int_43, PwMapT2bkFile pwMapT2bkFile_0, float float_14, float float_15)
	{
		float[] array = pwMapT2bkFile_0.BuildSectorHeightMap();
		if (array == null || array.Length == 0)
		{
			return;
		}
		int num = (int)Math.Sqrt(array.Length);
		if (num <= 0)
		{
			num = 1;
		}
		int num2 = int_41 * int_43;
		int num3 = int_42 * int_43;
		for (int i = 0; i < int_43; i++)
		{
			int* ptr = (int*)((byte*)(void*)bitmapData_0.Scan0 + (num3 + i) * bitmapData_0.Stride) + num2;
			for (int j = 0; j < int_43; j++)
			{
				int num4 = Math.Min(j * num / int_43, num - 1);
				int num5 = Math.Min(i * num / int_43, num - 1);
				int num6 = Math.Min(num5 * num + num4, array.Length - 1);
				float float_16 = Math.Max(0f, Math.Min(1f, (array[num6] - float_14) / float_15));
				ptr[j] = smethod_4(float_16).ToArgb();
			}
		}
	}

	private static Color smethod_4(float float_14)
	{
		int val;
		int val2;
		int val3;
		if (float_14 < 0.05f)
		{
			val = 40;
			val2 = 60;
			val3 = 120;
		}
		else if (float_14 < 0.15f)
		{
			float num = (float_14 - 0.05f) / 0.1f;
			val = (int)(40f + 30f * num);
			val2 = (int)(60f + 70f * num);
			val3 = (int)(120f - 50f * num);
		}
		else if (float_14 < 0.35f)
		{
			float num2 = (float_14 - 0.15f) / 0.2f;
			val = (int)(70f + 30f * num2);
			val2 = (int)(130f + 40f * num2);
			val3 = (int)(70f - 30f * num2);
		}
		else if (float_14 < 0.55f)
		{
			float num3 = (float_14 - 0.35f) / 0.2f;
			val = (int)(100f + 50f * num3);
			val2 = (int)(170f - 30f * num3);
			val3 = (int)(40f + 10f * num3);
		}
		else if (float_14 < 0.75f)
		{
			float num4 = (float_14 - 0.55f) / 0.2f;
			val = (int)(150f + 50f * num4);
			val2 = (int)(140f - 20f * num4);
			val3 = (int)(50f + 10f * num4);
		}
		else
		{
			float num5 = (float_14 - 0.75f) / 0.25f;
			val = (int)(200f + 50f * num5);
			val2 = (int)(120f + 100f * num5);
			val3 = (int)(60f + 160f * num5);
		}
		return Color.FromArgb(255, Math.Max(0, Math.Min(255, val)), Math.Max(0, Math.Min(255, val2)), Math.Max(0, Math.Min(255, val3)));
	}

	private void pictureBox_8_Paint(object sender, PaintEventArgs e)
	{
		if (sender is PictureBox pictureBox)
		{
			Graphics graphics = e.Graphics;
			graphics.InterpolationMode = InterpolationMode.Bilinear;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			int int_ = pictureBox.Width;
			int int_2 = pictureBox.Height;
			if (bitmap_1 != null)
			{
				graphics.DrawImage(bitmap_1, 0, 0, int_, int_2);
			}
			else
			{
				smethod_5(graphics, int_, int_2, Class16.smethod_0(1649084638), Color.FromArgb(40, 40, 40));
			}
			method_47(graphics, int_, int_2);
		}
	}

	private void pictureBox_9_Paint(object sender, PaintEventArgs e)
	{
		if (sender is PictureBox pictureBox)
		{
			Graphics graphics = e.Graphics;
			graphics.InterpolationMode = InterpolationMode.Bilinear;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			int int_ = pictureBox.Width;
			int int_2 = pictureBox.Height;
			if (bitmap_2 != null)
			{
				graphics.DrawImage(bitmap_2, 0, 0, int_, int_2);
			}
			else
			{
				smethod_5(graphics, int_, int_2, Class16.smethod_0(1649084655), Color.FromArgb(15, 15, 30));
			}
			method_47(graphics, int_, int_2);
		}
	}

	private static void smethod_5(Graphics graphics_0, int int_40, int int_41, string string_6, Color color_0)
	{
		SolidBrush solidBrush = new SolidBrush(color_0);
		try
		{
			graphics_0.FillRectangle(solidBrush, 0, 0, int_40, int_41);
			Font font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Italic);
			try
			{
				SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(100, 200, 200, 200));
				try
				{
					StringFormat format = new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					};
					graphics_0.DrawString(string_6 + Class16.smethod_0(1649084666), font, solidBrush2, (float)int_40 / 2f, (float)int_41 / 2f, format);
				}
				finally
				{
					((IDisposable)solidBrush2).Dispose();
				}
			}
			finally
			{
				((IDisposable)font).Dispose();
			}
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
	}

	private void method_52()
	{
		bitmap_1?.Dispose();
		bitmap_1 = null;
		bitmap_2?.Dispose();
		bitmap_2 = null;
		if (pwMapTrn2File_0 == null || pwMapTrn2File_0.TotalSectors <= 0)
		{
			return;
		}
		int sectorsWide = pwMapTrn2File_0.SectorsWide;
		int sectorsHigh = pwMapTrn2File_0.SectorsHigh;
		if (sectorsWide <= 0 || sectorsHigh <= 0)
		{
			return;
		}
		int int_ = Math.Max(1, (int)(pwMapTrn2File_0.Width / (float)sectorsWide));
		int int_2 = Math.Max(1, (int)(pwMapTrn2File_0.Height / (float)sectorsHigh));
		int int_3 = 32;
		int num = sectorsWide * 32;
		int num2 = sectorsHigh * 32;
		bitmap_1 = new Bitmap(num, num2, PixelFormat.Format32bppArgb);
		bitmap_2 = new Bitmap(num, num2, PixelFormat.Format32bppArgb);
		float num3 = float.MaxValue;
		float num4 = float.MinValue;
		for (int i = 0; i < pwMapTrn2File_0.SectorHeights.Count; i++)
		{
			(float, float) tuple = pwMapTrn2File_0.SectorHeights[i];
			if (tuple.Item1 < num3)
			{
				(num3, _) = tuple;
			}
			if (tuple.Item2 > num4)
			{
				num4 = tuple.Item2;
			}
		}
		float num5 = num4 - num3;
		if (num5 < 1f)
		{
			num5 = 1f;
		}
		BitmapData bitmapData = bitmap_1.LockBits(new Rectangle(0, 0, num, num2), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
		BitmapData bitmapData2 = bitmap_2.LockBits(new Rectangle(0, 0, num, num2), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
		try
		{
			for (int j = 0; j < pwMapTrn2File_0.TotalSectors; j++)
			{
				int int_4 = j / sectorsWide;
				int int_5 = j % sectorsWide;
				PwMapT2bkFile pwMapT2bkFile_ = method_363(j, int_, int_2);
				method_53(bitmapData, bitmapData2, int_5, int_4, int_3, pwMapT2bkFile_, j, num3, num5);
			}
		}
		finally
		{
			bitmap_1.UnlockBits(bitmapData);
			bitmap_2.UnlockBits(bitmapData2);
		}
	}

	private unsafe void method_53(BitmapData bitmapData_0, BitmapData bitmapData_1, int int_40, int int_41, int int_42, PwMapT2bkFile pwMapT2bkFile_0, int int_43, float float_14, float float_15)
	{
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		float[] array = pwMapT2bkFile_0?.BuildSectorHeightMap();
		int num = ((array != null) ? ((int)Math.Sqrt(array.Length)) : 0);
		if (num <= 0)
		{
			num = 1;
		}
		int num2 = int_40 * int_42;
		int num3 = int_41 * int_42;
		Vector3 val = default(Vector3);
		val = new Vector3(0.42f, 0.75f, 0.51f);
		val.Normalize();
		Vector3 val2 = default(Vector3);
		val2 = new Vector3(-0.3f, 0.6f, -0.4f);
		val2.Normalize();
		for (int i = 0; i < int_42; i++)
		{
			int* ptr = (int*)((byte*)(void*)bitmapData_0.Scan0 + (num3 + i) * bitmapData_0.Stride) + num2;
			int* ptr2 = (int*)((byte*)(void*)bitmapData_1.Scan0 + (num3 + i) * bitmapData_1.Stride) + num2;
			for (int j = 0; j < int_42; j++)
			{
				float num4 = 0f;
				float num5 = 0f;
				float num8;
				if (array != null && array.Length > 1)
				{
					int num6 = Math.Min(j * num / int_42, num - 1);
					int num7 = Math.Min(i * num / int_42, num - 1);
					int val3 = num7 * num + num6;
					num8 = array[Math.Min(val3, array.Length - 1)];
					int num9 = Math.Min(num6 + 1, num - 1);
					int num10 = Math.Min(num7 + 1, num - 1);
					float num11 = array[Math.Min(num7 * num + num9, array.Length - 1)];
					float num12 = array[Math.Min(num10 * num + num6, array.Length - 1)];
					num4 = num8 - num11;
					num5 = num8 - num12;
				}
				else
				{
					num8 = method_364(int_43);
				}
				float num13 = (float)Math.Sqrt(num4 * num4 + 1f + num5 * num5);
				float num14 = num4 / num13;
				float num15 = 1f / num13;
				float num16 = num5 / num13;
				float num17 = Math.Max(0f, num14 * val.X + num15 * val.Y + num16 * val.Z);
				float num18 = Math.Max(0f, num14 * val2.X + num15 * val2.Y + num16 * val2.Z);
				float num19 = Math.Max(0f, Math.Min(1f, (num8 - float_14) / float_15));
				float num20 = 0.3f + 0.7f * num19;
				float num21 = Math.Max(0.15f, num20 * (0.3f + 0.7f * num17));
				int int_44 = (int)(200f * num21);
				int int_45 = (int)(190f * num21);
				int int_46 = (int)(160f * num21);
				ptr[j] = -16777216 | (smethod_6(int_44) << 16) | (smethod_6(int_45) << 8) | smethod_6(int_46);
				float num22 = Math.Max(0.05f, num20 * (0.15f + 0.5f * num18));
				int int_47 = (int)(40f * num22);
				int int_48 = (int)(50f * num22);
				int int_49 = (int)(100f * num22);
				ptr2[j] = -16777216 | (smethod_6(int_47) << 16) | (smethod_6(int_48) << 8) | smethod_6(int_49);
			}
		}
	}

	private static int smethod_6(int int_40)
	{
		if (int_40 >= 0)
		{
			if (int_40 <= 255)
			{
				return int_40;
			}
			return 255;
		}
		return 0;
	}

	private void panel_11_Paint(object sender, PaintEventArgs e)
	{
		if (pwMapTrn2File_0 == null || pwMapPassMapProfile_0 == null)
		{
			return;
		}
		int sectorsWide = pwMapTrn2File_0.SectorsWide;
		int sectorsHigh = pwMapTrn2File_0.SectorsHigh;
		if (sectorsWide <= 0 || sectorsHigh <= 0)
		{
			return;
		}
		int num = panel_11.ClientSize.Width;
		int num2 = panel_11.ClientSize.Height;
		float num3 = (float)num / (float)sectorsWide;
		float num4 = (float)num2 / (float)sectorsHigh;
		Graphics graphics = e.Graphics;
		SolidBrush solidBrush = new SolidBrush(Color.FromArgb(80, 0, 200, 0));
		try
		{
			SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(80, 200, 0, 0));
			try
			{
				Pen pen = new Pen(Color.FromArgb(100, 100, 100, 100));
				try
				{
					Font font = new Font(Class16.smethod_0(1648942905), 7f);
					try
					{
						SolidBrush solidBrush3 = new SolidBrush(Color.FromArgb(200, 200, 200));
						try
						{
							for (int i = 0; i < sectorsHigh; i++)
							{
								for (int j = 0; j < sectorsWide; j++)
								{
									int num5 = i * sectorsWide + j;
									if (num5 >= pwMapPassMapProfile_0.Sectors.Count)
									{
										break;
									}
									float num6 = (float)j * num3;
									float num7 = (float)i * num4;
									bool dungeon = pwMapPassMapProfile_0.Sectors[num5].Dungeon;
									graphics.FillRectangle(dungeon ? solidBrush2 : solidBrush, num6, num7, num3, num4);
									graphics.DrawRectangle(pen, num6, num7, num3, num4);
									string arg = (dungeon ? Class16.smethod_0(1649105837) : Class16.smethod_0(1649105893));
									graphics.DrawString(string.Format(Class16.smethod_0(1649084689), num5, arg), font, solidBrush3, num6 + 2f, num7 + 2f);
								}
							}
						}
						finally
						{
							((IDisposable)solidBrush3).Dispose();
						}
					}
					finally
					{
						((IDisposable)font).Dispose();
					}
				}
				finally
				{
					((IDisposable)pen).Dispose();
				}
			}
			finally
			{
				((IDisposable)solidBrush2).Dispose();
			}
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
	}

	private void panel_11_MouseClick(object sender, MouseEventArgs e)
	{
		if (pwMapTrn2File_0 == null || pwMapPassMapProfile_0 == null)
		{
			return;
		}
		int sectorsWide = pwMapTrn2File_0.SectorsWide;
		int sectorsHigh = pwMapTrn2File_0.SectorsHigh;
		if (sectorsWide <= 0 || sectorsHigh <= 0)
		{
			return;
		}
		float num = (float)panel_11.ClientSize.Width / (float)sectorsWide;
		float num2 = (float)panel_11.ClientSize.Height / (float)sectorsHigh;
		int num3 = (int)((float)e.X / num);
		int num4 = (int)((float)e.Y / num2);
		if (num3 < 0 || num3 >= sectorsWide || num4 < 0 || num4 >= sectorsHigh)
		{
			return;
		}
		int num5 = num4 * sectorsWide + num3;
		if (num5 < pwMapPassMapProfile_0.Sectors.Count)
		{
			pwMapPassMapProfile_0.Sectors[num5].Dungeon = !pwMapPassMapProfile_0.Sectors[num5].Dungeon;
			panel_11.Invalidate();
			if (bool_34)
			{
				method_359();
			}
		}
	}

	private void method_54()
	{
		tabPage_1 = new TabPage(Class16.smethod_0(1649084711))
		{
			UseVisualStyleBackColor = true
		};
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 1,
			RowCount = 3,
			Padding = new Padding(4)
		};
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 190f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
		tableLayoutPanel.Controls.Add(method_55(), 0, 0);
		tableLayoutPanel.Controls.Add(method_56(), 0, 1);
		label_12 = new Label
		{
			Dock = DockStyle.Fill,
			Text = Class16.smethod_0(1648920624),
			TextAlign = ContentAlignment.MiddleLeft,
			Margin = new Padding(4, 0, 4, 0)
		};
		tableLayoutPanel.Controls.Add(label_12, 0, 2);
		tabPage_1.Controls.Add(tableLayoutPanel);
		tabControl_4.TabPages.Add(tabPage_1);
		method_116(Class16.smethod_0(1649084711), tabPage_1);
		method_59();
	}

	private GroupBox method_55()
	{
		GroupBox groupBox = new GroupBox
		{
			Text = Class16.smethod_0(1649084725),
			Dock = DockStyle.Fill
		};
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 2,
			AutoSize = true
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649034885)), 0, 0);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill,
			WrapContents = false
		};
		comboBox_2 = new ComboBox
		{
			Width = 120,
			DropDownStyle = ComboBoxStyle.DropDownList
		};
		comboBox_2.Items.Add(Class16.smethod_0(1649089211));
		comboBox_2.SelectedIndex = 0;
		button_12 = new Button
		{
			Text = Class16.smethod_0(1648904254),
			Width = 45
		};
		button_13 = new Button
		{
			Text = Class16.smethod_0(1648941761),
			Width = 45
		};
		flowLayoutPanel.Controls.AddRange(new Control[3] { comboBox_2, button_12, button_13 });
		tableLayoutPanel.Controls.Add(flowLayoutPanel, 1, 0);
		checkBox_21 = new CheckBox
		{
			Text = Class16.smethod_0(1649084739),
			AutoSize = true
		};
		tableLayoutPanel.SetColumnSpan(checkBox_21, 2);
		tableLayoutPanel.Controls.Add(checkBox_21, 0, 1);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649084763)), 0, 2);
		FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill,
			WrapContents = false
		};
		trackBar_9 = new TrackBar
		{
			Minimum = 0,
			Maximum = 90,
			Value = 45,
			Width = 140,
			TickFrequency = 15
		};
		label_11 = new Label
		{
			Text = Class16.smethod_0(1649086333),
			AutoSize = true,
			Margin = new Padding(2, 6, 0, 0)
		};
		trackBar_9.ValueChanged += trackBar_9_ValueChanged;
		flowLayoutPanel2.Controls.AddRange(new Control[2] { trackBar_9, label_11 });
		tableLayoutPanel.Controls.Add(flowLayoutPanel2, 1, 2);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649084788)), 0, 3);
		comboBox_3 = new ComboBox
		{
			Width = 80,
			DropDownStyle = ComboBoxStyle.DropDownList
		};
		comboBox_3.Items.AddRange(new object[6]
		{
			Class16.smethod_0(1648934925),
			Class16.smethod_0(1648911557),
			Class16.smethod_0(1648911820),
			Class16.smethod_0(1648910977),
			Class16.smethod_0(1648911318),
			Class16.smethod_0(1648911285)
		});
		comboBox_3.SelectedIndex = 1;
		tableLayoutPanel.Controls.Add(comboBox_3, 1, 3);
		FlowLayoutPanel flowLayoutPanel3 = new FlowLayoutPanel
		{
			AutoSize = true
		};
		button_14 = new Button
		{
			Text = Class16.smethod_0(1649084804),
			AutoSize = true
		};
		button_15 = new Button
		{
			Text = Class16.smethod_0(1649084830),
			AutoSize = true
		};
		flowLayoutPanel3.Controls.AddRange(new Control[2] { button_14, button_15 });
		tableLayoutPanel.SetColumnSpan(flowLayoutPanel3, 2);
		tableLayoutPanel.Controls.Add(flowLayoutPanel3, 0, 4);
		groupBox.Controls.Add(tableLayoutPanel);
		return groupBox;
	}

	private TabControl method_56()
	{
		tabControl_1 = new TabControl
		{
			Dock = DockStyle.Fill
		};
		TabPage tabPage = new TabPage(Class16.smethod_0(1649084852));
		panel_11 = new Panel
		{
			Dock = DockStyle.Fill,
			BackColor = Color.FromArgb(30, 30, 30)
		};
		panel_11.Paint += panel_11_Paint;
		panel_11.MouseClick += panel_11_MouseClick;
		tabPage.Controls.Add(panel_11);
		TabPage tabPage2 = new TabPage(Class16.smethod_0(1649084857));
		method_57(tabPage2);
		TabPage tabPage3 = new TabPage(Class16.smethod_0(1649084877));
		method_58(tabPage3);
		tabControl_1.TabPages.AddRange(new TabPage[3] { tabPage, tabPage2, tabPage3 });
		return tabControl_1;
	}

	private void method_57(TabPage tabPage_19)
	{
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 1,
			RowCount = 2
		};
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f));
		listView_3 = new ListView
		{
			Dock = DockStyle.Fill,
			View = View.Details,
			FullRowSelect = true,
			GridLines = true,
			HideSelection = false
		};
		listView_3.Columns.Add(Class16.smethod_0(1649084880), 110);
		listView_3.Columns.Add(Class16.smethod_0(1648893587), 90);
		listView_3.Columns.Add(Class16.smethod_0(1648886228), 50);
		listView_3.Columns.Add(Class16.smethod_0(1648930017), 60);
		tableLayoutPanel.Controls.Add(listView_3, 0, 0);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill,
			WrapContents = false
		};
		button_16 = new Button
		{
			Text = Class16.smethod_0(1648980145),
			Width = 60
		};
		button_17 = new Button
		{
			Text = Class16.smethod_0(1648980165),
			Width = 70
		};
		button_16.Click += button_16_Click;
		button_17.Click += button_17_Click;
		flowLayoutPanel.Controls.AddRange(new Control[2] { button_16, button_17 });
		tableLayoutPanel.Controls.Add(flowLayoutPanel, 0, 1);
		tabPage_19.Controls.Add(tableLayoutPanel);
	}

	private void method_58(TabPage tabPage_19)
	{
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 1,
			RowCount = 2
		};
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f));
		listView_4 = new ListView
		{
			Dock = DockStyle.Fill,
			View = View.Details,
			FullRowSelect = true,
			GridLines = true,
			HideSelection = false
		};
		listView_4.Columns.Add(Class16.smethod_0(1648916453), 60);
		listView_4.Columns.Add(Class16.smethod_0(1648915467), 60);
		listView_4.Columns.Add(Class16.smethod_0(1648980967), 50);
		listView_4.Columns.Add(Class16.smethod_0(1649084900), 50);
		tableLayoutPanel.Controls.Add(listView_4, 0, 0);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill,
			WrapContents = false
		};
		button_18 = new Button
		{
			Text = Class16.smethod_0(1648980165),
			Width = 70
		};
		button_18.Click += button_18_Click;
		flowLayoutPanel.Controls.Add(button_18);
		tableLayoutPanel.Controls.Add(flowLayoutPanel, 0, 1);
		tabPage_19.Controls.Add(tableLayoutPanel);
	}

	private void method_59()
	{
		button_14.Click += button_14_Click;
		button_15.Click += button_15_Click;
		button_13.Click += button_13_Click;
	}

	private void method_60()
	{
		PwMapPassMapExceptionDialog pwMapPassMapExceptionDialog = new PwMapPassMapExceptionDialog();
		try
		{
			if (pwMapPassMapExceptionDialog.ShowDialog(this) == DialogResult.OK)
			{
				string text = (pwMapPassMapExceptionDialog.AnyModel ? Class16.smethod_0(1649084914) : (pwMapPassMapExceptionDialog.AnyMesh ? Class16.smethod_0(1649089035) : Class16.smethod_0(1649084911)));
				string text2 = (pwMapPassMapExceptionDialog.Omit ? Class16.smethod_0(1649089158) : (pwMapPassMapExceptionDialog.Force ? Class16.smethod_0(1649089161) : Class16.smethod_0(1648924120)));
				string text3 = (pwMapPassMapExceptionDialog.AllLevels ? Class16.smethod_0(1648973883) : Class16.smethod_0(1649210884));
				ListViewItem listViewItem = new ListViewItem(text);
				listViewItem.SubItems.Add(pwMapPassMapExceptionDialog.AllPositions ? Class16.smethod_0(1648973883) : Class16.smethod_0(1649210884));
				listViewItem.SubItems.Add(text3);
				listViewItem.SubItems.Add(text2);
				listView_3.Items.Add(listViewItem);
			}
		}
		finally
		{
			((IDisposable)pwMapPassMapExceptionDialog).Dispose();
		}
	}

	private void method_61()
	{
		if (listView_3.SelectedItems.Count != 0)
		{
			listView_3.Items.Remove(listView_3.SelectedItems[0]);
		}
	}

	private void method_62()
	{
		if (listView_4.SelectedItems.Count != 0)
		{
			listView_4.Items.Remove(listView_4.SelectedItems[0]);
		}
	}

	private void method_63()
	{
		if (pwMapPassMapProfile_0 != null && pwMapTrn2File_0 != null)
		{
			string path = method_147();
			string path2 = method_146();
			string text = System.IO.Path.Combine(path2, path, Class16.smethod_0(1649082922), (pwMapPassMapProfile_0.Name ?? Class16.smethod_0(1649089211)) + Class16.smethod_0(1648899122));
			pwMapPassMapProfile_0.ClipAngle = trackBar_9?.Value ?? 45;
			pwMapPassMapProfile_0.SaveImages = checkBox_21?.Checked ?? false;
			pwMapPassMapProfile_0.Save(text);
			label_12.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649210891), Class16.smethod_0(1649210917)), text);
		}
	}

	private void method_64()
	{
		if (pwMapTrn2File_0 != null)
		{
			if (pwMapPassMapProfile_0 == null)
			{
				pwMapPassMapProfile_0 = new PwMapPassMapProfile();
			}
			pwMapPassMapProfile_0.EnsureSectorCount(pwMapTrn2File_0.TotalSectors);
			panel_11?.Invalidate();
		}
	}

	private TabPage method_65()
	{
		TabPage tabPage = new TabPage(Class16.smethod_0(1649210934));
		SplitContainer splitContainer = new SplitContainer
		{
			Dock = DockStyle.Fill,
			Orientation = Orientation.Horizontal,
			SplitterDistance = 130
		};
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 1,
			RowCount = 2
		};
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f));
		listView_5 = new ListView
		{
			Dock = DockStyle.Fill,
			View = View.Details,
			FullRowSelect = true,
			HideSelection = false,
			GridLines = true
		};
		listView_5.Columns.Add(Class16.smethod_0(1648941057), 50);
		listView_5.Columns.Add(Class16.smethod_0(1649210938), 70);
		listView_5.Columns.Add(Class16.smethod_0(1649013300), 60);
		listView_5.SelectedIndexChanged += listView_5_SelectedIndexChanged;
		tableLayoutPanel.Controls.Add(listView_5, 0, 0);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill,
			WrapContents = false
		};
		button_19 = new Button
		{
			Text = Class16.smethod_0(1648931361),
			AutoSize = true
		};
		button_20 = new Button
		{
			Text = Class16.smethod_0(1648925718),
			AutoSize = true
		};
		flowLayoutPanel.Controls.Add(button_19);
		flowLayoutPanel.Controls.Add(button_20);
		tableLayoutPanel.Controls.Add(flowLayoutPanel, 0, 1);
		splitContainer.Panel1.Controls.Add(tableLayoutPanel);
		Panel panel = new Panel
		{
			Dock = DockStyle.Fill,
			AutoScroll = true
		};
		TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 2,
			RowCount = 7,
			Padding = new Padding(4)
		};
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80f));
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
		tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
		tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
		tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
		tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
		tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f));
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1649210954)), 0, 0);
		textBox_37 = smethod_76();
		tableLayoutPanel2.Controls.Add(textBox_37, 1, 0);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1649210938)), 0, 1);
		textBox_38 = smethod_76();
		tableLayoutPanel2.Controls.Add(textBox_38, 1, 1);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1649210968)), 0, 2);
		textBox_39 = smethod_76();
		tableLayoutPanel2.Controls.Add(textBox_39, 1, 2);
		FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel
		{
			AutoSize = true,
			Dock = DockStyle.Fill,
			WrapContents = true
		};
		flowLayoutPanel2.Controls.Add(new Label
		{
			Text = Class16.smethod_0(1649210991),
			AutoSize = true
		});
		comboBox_4 = new ComboBox
		{
			DropDownStyle = ComboBoxStyle.DropDownList,
			Width = 70
		};
		comboBox_4.Items.AddRange(new object[3]
		{
			Class16.smethod_0(1648924120),
			Class16.smethod_0(1649210995),
			Class16.smethod_0(1649211014)
		});
		comboBox_4.SelectedIndex = 0;
		flowLayoutPanel2.Controls.Add(comboBox_4);
		flowLayoutPanel2.Controls.Add(new Label
		{
			Text = Class16.smethod_0(1649211029),
			AutoSize = true
		});
		comboBox_5 = new ComboBox
		{
			DropDownStyle = ComboBoxStyle.DropDownList,
			Width = 70
		};
		comboBox_5.Items.AddRange(new object[2]
		{
			Class16.smethod_0(1649084947),
			Class16.smethod_0(1649211035)
		});
		comboBox_5.SelectedIndex = 0;
		flowLayoutPanel2.Controls.Add(comboBox_5);
		checkBox_22 = new CheckBox
		{
			Text = Class16.smethod_0(1649211048),
			AutoSize = true
		};
		flowLayoutPanel2.Controls.Add(checkBox_22);
		tableLayoutPanel2.SetColumnSpan(flowLayoutPanel2, 2);
		tableLayoutPanel2.Controls.Add(flowLayoutPanel2, 0, 3);
		Label control = smethod_75(Class16.smethod_0(1649013300));
		tableLayoutPanel2.SetColumnSpan(control, 2);
		tableLayoutPanel2.Controls.Add(control, 0, 4);
		listView_6 = new ListView
		{
			Dock = DockStyle.Fill,
			View = View.Details,
			FullRowSelect = true,
			GridLines = true
		};
		listView_6.Columns.Add(Class16.smethod_0(1648929947), 30);
		listView_6.Columns.Add(Class16.smethod_0(1648916453), 70);
		listView_6.Columns.Add(Class16.smethod_0(1648916476), 70);
		listView_6.Columns.Add(Class16.smethod_0(1648915467), 70);
		tableLayoutPanel2.SetColumnSpan(listView_6, 2);
		tableLayoutPanel2.Controls.Add(listView_6, 0, 5);
		FlowLayoutPanel flowLayoutPanel3 = new FlowLayoutPanel
		{
			AutoSize = true,
			WrapContents = false
		};
		button_21 = new Button
		{
			Text = Class16.smethod_0(1649211070),
			AutoSize = true
		};
		button_22 = new Button
		{
			Text = Class16.smethod_0(1648925718),
			AutoSize = true
		};
		flowLayoutPanel3.Controls.Add(button_21);
		flowLayoutPanel3.Controls.Add(button_22);
		tableLayoutPanel2.SetColumnSpan(flowLayoutPanel3, 2);
		tableLayoutPanel2.Controls.Add(flowLayoutPanel3, 0, 6);
		panel.Controls.Add(tableLayoutPanel2);
		splitContainer.Panel2.Controls.Add(panel);
		tabPage.Controls.Add(splitContainer);
		return tabPage;
	}

	private void method_66()
	{
	}

	private TabPage method_67()
	{
		TabPage tabPage = new TabPage(Class16.smethod_0(1649211086));
		SplitContainer splitContainer = new SplitContainer
		{
			Dock = DockStyle.Fill,
			Orientation = Orientation.Horizontal,
			SplitterDistance = 160
		};
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 1,
			RowCount = 2
		};
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f));
		listView_7 = new ListView
		{
			Dock = DockStyle.Fill,
			View = View.Details,
			FullRowSelect = true,
			HideSelection = false,
			GridLines = true
		};
		listView_7.Columns.Add(Class16.smethod_0(1648941057), 50);
		listView_7.Columns.Add(Class16.smethod_0(1648936731), 140);
		listView_7.Columns.Add(Class16.smethod_0(1649211101), 60);
		listView_7.SelectedIndexChanged += listView_7_SelectedIndexChanged;
		tableLayoutPanel.Controls.Add(listView_7, 0, 0);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill,
			WrapContents = false
		};
		button_23 = new Button
		{
			Text = Class16.smethod_0(1648931361),
			AutoSize = true
		};
		button_24 = new Button
		{
			Text = Class16.smethod_0(1648925718),
			AutoSize = true
		};
		flowLayoutPanel.Controls.Add(button_23);
		flowLayoutPanel.Controls.Add(button_24);
		tableLayoutPanel.Controls.Add(flowLayoutPanel, 0, 1);
		splitContainer.Panel1.Controls.Add(tableLayoutPanel);
		Panel panel = new Panel
		{
			Dock = DockStyle.Fill,
			AutoScroll = true
		};
		TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel
		{
			Dock = DockStyle.Top,
			AutoSize = true,
			ColumnCount = 4,
			Padding = new Padding(4)
		};
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80f));
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34f));
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1648936731)), 0, 0);
		textBox_40 = smethod_76();
		tableLayoutPanel2.SetColumnSpan(textBox_40, 3);
		tableLayoutPanel2.Controls.Add(textBox_40, 1, 0);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1648941057)), 0, 1);
		textBox_41 = smethod_76();
		tableLayoutPanel2.Controls.Add(textBox_41, 1, 1);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1649211101)), 2, 1);
		textBox_42 = smethod_76();
		tableLayoutPanel2.Controls.Add(textBox_42, 3, 1);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1649211116)), 0, 2);
		textBox_43 = smethod_76();
		tableLayoutPanel2.Controls.Add(textBox_43, 1, 2);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1649210995)), 2, 2);
		textBox_44 = smethod_76();
		tableLayoutPanel2.Controls.Add(textBox_44, 3, 2);
		checkBox_23 = new CheckBox
		{
			Text = Class16.smethod_0(1649211133),
			AutoSize = true
		};
		tableLayoutPanel2.SetColumnSpan(checkBox_23, 4);
		tableLayoutPanel2.Controls.Add(checkBox_23, 0, 3);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1649211150)), 0, 4);
		textBox_45 = smethod_76();
		tableLayoutPanel2.Controls.Add(textBox_45, 1, 4);
		textBox_46 = smethod_76();
		tableLayoutPanel2.Controls.Add(textBox_46, 2, 4);
		textBox_47 = smethod_76();
		tableLayoutPanel2.Controls.Add(textBox_47, 3, 4);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1649211165)), 0, 5);
		textBox_48 = smethod_76();
		tableLayoutPanel2.Controls.Add(textBox_48, 1, 5);
		textBox_49 = smethod_76();
		tableLayoutPanel2.Controls.Add(textBox_49, 2, 5);
		textBox_50 = smethod_76();
		tableLayoutPanel2.Controls.Add(textBox_50, 3, 5);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1649211170)), 0, 6);
		textBox_51 = smethod_76();
		tableLayoutPanel2.SetColumnSpan(textBox_51, 3);
		tableLayoutPanel2.Controls.Add(textBox_51, 1, 6);
		Label control = smethod_75(Class16.smethod_0(1649211187));
		tableLayoutPanel2.SetColumnSpan(control, 4);
		tableLayoutPanel2.Controls.Add(control, 0, 7);
		listView_8 = new ListView
		{
			Height = 100,
			Dock = DockStyle.Fill,
			View = View.Details,
			FullRowSelect = true,
			GridLines = true
		};
		listView_8.Columns.Add(Class16.smethod_0(1648916453), 70);
		listView_8.Columns.Add(Class16.smethod_0(1648916476), 70);
		listView_8.Columns.Add(Class16.smethod_0(1648915467), 70);
		tableLayoutPanel2.SetColumnSpan(listView_8, 4);
		tableLayoutPanel2.Controls.Add(listView_8, 0, 8);
		FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel
		{
			AutoSize = true,
			WrapContents = false
		};
		button_25 = new Button
		{
			Text = Class16.smethod_0(1649211207),
			AutoSize = true
		};
		button_26 = new Button
		{
			Text = Class16.smethod_0(1649211222),
			AutoSize = true
		};
		flowLayoutPanel2.Controls.Add(button_25);
		flowLayoutPanel2.Controls.Add(button_26);
		tableLayoutPanel2.SetColumnSpan(flowLayoutPanel2, 4);
		tableLayoutPanel2.Controls.Add(flowLayoutPanel2, 0, 9);
		panel.Controls.Add(tableLayoutPanel2);
		splitContainer.Panel2.Controls.Add(panel);
		tabPage.Controls.Add(splitContainer);
		return tabPage;
	}

	private void method_68()
	{
	}

	private TabPage method_69()
	{
		TabPage tabPage = new TabPage(Class16.smethod_0(1649211232));
		SplitContainer splitContainer = new SplitContainer
		{
			Dock = DockStyle.Fill,
			Orientation = Orientation.Horizontal,
			SplitterDistance = 140
		};
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 1,
			RowCount = 2
		};
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f));
		listView_9 = new ListView
		{
			Dock = DockStyle.Fill,
			View = View.Details,
			FullRowSelect = true,
			HideSelection = false,
			GridLines = true
		};
		listView_9.Columns.Add(Class16.smethod_0(1648941057), 40);
		listView_9.Columns.Add(Class16.smethod_0(1648936731), 120);
		listView_9.Columns.Add(Class16.smethod_0(1648936875), 80);
		listView_9.SelectedIndexChanged += listView_9_SelectedIndexChanged;
		tableLayoutPanel.Controls.Add(listView_9, 0, 0);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill,
			WrapContents = false
		};
		button_27 = new Button
		{
			Text = Class16.smethod_0(1648931361),
			AutoSize = true
		};
		button_28 = new Button
		{
			Text = Class16.smethod_0(1648925718),
			AutoSize = true
		};
		flowLayoutPanel.Controls.Add(button_27);
		flowLayoutPanel.Controls.Add(button_28);
		tableLayoutPanel.Controls.Add(flowLayoutPanel, 0, 1);
		splitContainer.Panel1.Controls.Add(tableLayoutPanel);
		Panel panel = new Panel
		{
			Dock = DockStyle.Fill,
			AutoScroll = true
		};
		TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 2,
			RowCount = 5,
			Padding = new Padding(4)
		};
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80f));
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
		tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
		tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
		tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f));
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1648936731)), 0, 0);
		textBox_52 = smethod_76();
		tableLayoutPanel2.Controls.Add(textBox_52, 1, 0);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1648936875)), 0, 1);
		comboBox_6 = new ComboBox
		{
			Dock = DockStyle.Fill,
			DropDownStyle = ComboBoxStyle.DropDownList
		};
		comboBox_6.Items.AddRange(new object[4]
		{
			Class16.smethod_0(1649007069),
			Class16.smethod_0(1649211253),
			Class16.smethod_0(1649211259),
			Class16.smethod_0(1649211275)
		});
		comboBox_6.SelectedIndex = 0;
		tableLayoutPanel2.Controls.Add(comboBox_6, 1, 1);
		Label control = smethod_75(Class16.smethod_0(1649211290));
		tableLayoutPanel2.SetColumnSpan(control, 2);
		tableLayoutPanel2.Controls.Add(control, 0, 2);
		listView_10 = new ListView
		{
			Dock = DockStyle.Fill,
			View = View.Details,
			FullRowSelect = true,
			GridLines = true
		};
		listView_10.Columns.Add(Class16.smethod_0(1649211307), 120);
		listView_10.Columns.Add(Class16.smethod_0(1649211321), 120);
		listView_10.Columns.Add(Class16.smethod_0(1649211275), 60);
		tableLayoutPanel2.SetColumnSpan(listView_10, 2);
		tableLayoutPanel2.Controls.Add(listView_10, 0, 3);
		FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel
		{
			AutoSize = true,
			WrapContents = false
		};
		button_29 = new Button
		{
			Text = Class16.smethod_0(1649211336),
			AutoSize = true
		};
		button_30 = new Button
		{
			Text = Class16.smethod_0(1648925718),
			AutoSize = true
		};
		flowLayoutPanel2.Controls.Add(button_29);
		flowLayoutPanel2.Controls.Add(button_30);
		tableLayoutPanel2.SetColumnSpan(flowLayoutPanel2, 2);
		tableLayoutPanel2.Controls.Add(flowLayoutPanel2, 0, 4);
		panel.Controls.Add(tableLayoutPanel2);
		splitContainer.Panel2.Controls.Add(panel);
		tabPage.Controls.Add(splitContainer);
		return tabPage;
	}

	private void method_70()
	{
	}

	private void method_71()
	{
		tabPage_2 = new TabPage(Class16.smethod_0(1649210934))
		{
			UseVisualStyleBackColor = true
		};
		tabControl_2 = new TabControl
		{
			Dock = DockStyle.Fill
		};
		tabControl_2.TabPages.Add(method_67());
		tabControl_2.TabPages.Add(method_69());
		tabControl_2.TabPages.Add(method_65());
		tabPage_2.Controls.Add(tabControl_2);
		tabControl_4.TabPages.Add(tabPage_2);
		method_116(Class16.smethod_0(1649210934), tabPage_2);
	}

	private void method_72()
	{
		tabPage_3 = new TabPage(Class16.smethod_0(1649211364))
		{
			UseVisualStyleBackColor = true
		};
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 1,
			RowCount = 3,
			Padding = new Padding(4)
		};
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 45f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 55f));
		tableLayoutPanel.Controls.Add(method_73(), 0, 0);
		tableLayoutPanel.Controls.Add(method_74(), 0, 1);
		tableLayoutPanel.Controls.Add(method_75(), 0, 2);
		tabPage_3.Controls.Add(tableLayoutPanel);
		tabControl_4.TabPages.Add(tabPage_3);
		method_116(Class16.smethod_0(1649211364), tabPage_3);
	}

	private GroupBox method_73()
	{
		GroupBox groupBox = new GroupBox
		{
			Text = Class16.smethod_0(1649211380),
			Dock = DockStyle.Fill
		};
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 2,
			AutoSize = true
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649210380)), 0, 0);
		textBox_53 = smethod_76();
		textBox_53.Text = Class16.smethod_0(1649027725);
		tableLayoutPanel.Controls.Add(textBox_53, 1, 0);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			AutoSize = true,
			WrapContents = true
		};
		checkBox_24 = new CheckBox
		{
			Text = Class16.smethod_0(1649210396),
			AutoSize = true
		};
		checkBox_25 = new CheckBox
		{
			Text = Class16.smethod_0(1649085359),
			AutoSize = true
		};
		checkBox_26 = new CheckBox
		{
			Text = Class16.smethod_0(1649085565),
			AutoSize = true
		};
		checkBox_27 = new CheckBox
		{
			Text = Class16.smethod_0(1649210402),
			AutoSize = true
		};
		checkBox_24.CheckedChanged += checkBox_24_CheckedChanged;
		checkBox_26.CheckedChanged += checkBox_26_CheckedChanged;
		checkBox_27.CheckedChanged += checkBox_27_CheckedChanged;
		flowLayoutPanel.Controls.AddRange(new Control[4] { checkBox_24, checkBox_25, checkBox_26, checkBox_27 });
		tableLayoutPanel.SetColumnSpan(flowLayoutPanel, 2);
		tableLayoutPanel.Controls.Add(flowLayoutPanel, 0, 1);
		groupBox.Controls.Add(tableLayoutPanel);
		return groupBox;
	}

	private ListView method_74()
	{
		listView_11 = new ListView
		{
			Dock = DockStyle.Fill,
			View = View.Details,
			FullRowSelect = true,
			HideSelection = false,
			GridLines = true
		};
		listView_11.Columns.Add(Class16.smethod_0(1649084880), 140);
		listView_11.Columns.Add(Class16.smethod_0(1648893587), 170);
		listView_11.SelectedIndexChanged += listView_11_SelectedIndexChanged;
		return listView_11;
	}

	private GroupBox method_75()
	{
		groupBox_0 = new GroupBox
		{
			Text = Class16.smethod_0(1649050557),
			Dock = DockStyle.Fill
		};
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Top,
			AutoSize = true,
			ColumnCount = 4,
			Padding = new Padding(4)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34f));
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648936875)), 0, 0);
		label_13 = new Label
		{
			Text = Class16.smethod_0(1648966655),
			AutoSize = true,
			Anchor = AnchorStyles.Left
		};
		tableLayoutPanel.SetColumnSpan(label_13, 3);
		tableLayoutPanel.Controls.Add(label_13, 1, 0);
		tableLayoutPanel.Controls.Add(new Label
		{
			Text = string.Empty,
			AutoSize = true
		}, 0, 1);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648916453)), 1, 1);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648916476)), 2, 1);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648915467)), 3, 1);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648893587)), 0, 2);
		textBox_54 = method_76();
		tableLayoutPanel.Controls.Add(textBox_54, 1, 2);
		textBox_55 = method_76();
		tableLayoutPanel.Controls.Add(textBox_55, 2, 2);
		textBox_56 = method_76();
		tableLayoutPanel.Controls.Add(textBox_56, 3, 2);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649210418)), 0, 3);
		textBox_57 = method_76();
		tableLayoutPanel.Controls.Add(textBox_57, 1, 3);
		textBox_58 = method_76();
		tableLayoutPanel.Controls.Add(textBox_58, 2, 3);
		textBox_59 = method_76();
		tableLayoutPanel.Controls.Add(textBox_59, 3, 3);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649085669)), 0, 4);
		textBox_60 = method_76();
		tableLayoutPanel.Controls.Add(textBox_60, 1, 4);
		textBox_61 = method_76();
		tableLayoutPanel.Controls.Add(textBox_61, 2, 4);
		textBox_62 = method_76();
		tableLayoutPanel.Controls.Add(textBox_62, 3, 4);
		button_31 = new Button
		{
			Text = Class16.smethod_0(1649210433),
			AutoSize = true,
			Dock = DockStyle.Left,
			Enabled = false,
			FlatStyle = FlatStyle.Flat
		};
		button_31.Click += button_31_Click;
		tableLayoutPanel.SetColumnSpan(button_31, 4);
		tableLayoutPanel.Controls.Add(button_31, 0, 5);
		TextBox[] array = new TextBox[9] { textBox_54, textBox_55, textBox_56, textBox_57, textBox_58, textBox_59, textBox_60, textBox_61, textBox_62 };
		foreach (TextBox textBox in array)
		{
			textBox.KeyDown += method_381;
			textBox.TextChanged += method_382;
		}
		groupBox_0.Controls.Add(tableLayoutPanel);
		return groupBox_0;
	}

	private TextBox method_76()
	{
		return new TextBox
		{
			Dock = DockStyle.Fill,
			Font = new Font(Class16.smethod_0(1648929975), 8.25f),
			TextAlign = HorizontalAlignment.Right,
			Text = Class16.smethod_0(1648966655)
		};
	}

	private void button_31_Click(object sender, EventArgs e)
	{
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		if (class301_1?.class314_0 != null)
		{
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			if (float.TryParse(textBox_54.Text, NumberStyles.Float, invariantCulture, out var result) && float.TryParse(textBox_55.Text, NumberStyles.Float, invariantCulture, out var result2) && float.TryParse(textBox_56.Text, NumberStyles.Float, invariantCulture, out var result3) && float.TryParse(textBox_57.Text, NumberStyles.Float, invariantCulture, out var result4) && float.TryParse(textBox_58.Text, NumberStyles.Float, invariantCulture, out var result5) && float.TryParse(textBox_59.Text, NumberStyles.Float, invariantCulture, out var result6) && float.TryParse(textBox_60.Text, NumberStyles.Float, invariantCulture, out var result7) && float.TryParse(textBox_61.Text, NumberStyles.Float, invariantCulture, out var result8) && float.TryParse(textBox_62.Text, NumberStyles.Float, invariantCulture, out var result9))
			{
				class301_1.class314_0.method_0();
				class301_1.class314_0.vector3_0 = new Vector3(result, result2, result3);
				class301_1.class314_0.vector3_2 = new Vector3(result4, result5, result6);
				class301_1.class314_0.vector3_3 = new Vector3(result7, result8, result9);
				class301_1.vector3_1 = class301_1.class314_0.vector3_0;
				class301_1.vector3_3 = class301_1.class314_0.vector3_2;
				class301_1.vector3_2 = class301_1.class314_0.vector3_3;
				method_261();
				method_140();
				button_31.Enabled = false;
				method_120(Class16.smethod_0(1649210463) + class301_1.string_0, null);
			}
		}
	}

	private void listView_11_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (listView_11.SelectedItems.Count == 0)
		{
			method_78();
			return;
		}
		ListViewItem listViewItem = listView_11.SelectedItems[0];
		if (listViewItem.Tag is Class301 @class)
		{
			bool_5 = true;
			label_13.Text = @class.enum20_0.ToString();
			textBox_54.Text = @class.vector3_1.X.ToString(Class16.smethod_0(1648922976));
			textBox_55.Text = @class.vector3_1.Y.ToString(Class16.smethod_0(1648922976));
			textBox_56.Text = @class.vector3_1.Z.ToString(Class16.smethod_0(1648922976));
			textBox_57.Text = @class.vector3_3.X.ToString(Class16.smethod_0(1648979502));
			textBox_58.Text = @class.vector3_3.Y.ToString(Class16.smethod_0(1648979502));
			textBox_59.Text = @class.vector3_3.Z.ToString(Class16.smethod_0(1648979502));
			Math.Max(@class.vector3_2.X, Math.Max(@class.vector3_2.Y, @class.vector3_2.Z));
			if (@class.class314_0 != null)
			{
				textBox_60.Text = @class.class314_0.vector3_3.X.ToString(Class16.smethod_0(1648922976));
				textBox_61.Text = @class.class314_0.vector3_3.Y.ToString(Class16.smethod_0(1648922976));
				textBox_62.Text = @class.class314_0.vector3_3.Z.ToString(Class16.smethod_0(1648922976));
			}
			else
			{
				textBox_60.Text = Class16.smethod_0(1649210483);
				textBox_61.Text = Class16.smethod_0(1649210483);
				textBox_62.Text = Class16.smethod_0(1649210483);
			}
			button_31.Enabled = false;
			bool_5 = false;
		}
		else
		{
			label_13.Text = listViewItem.Text;
			method_79();
		}
	}

	private void method_77()
	{
		if (class301_1 == null)
		{
			method_78();
			return;
		}
		bool_5 = true;
		label_13.Text = class301_1.enum20_0.ToString();
		textBox_54.Text = class301_1.vector3_1.X.ToString(Class16.smethod_0(1648922976));
		textBox_55.Text = class301_1.vector3_1.Y.ToString(Class16.smethod_0(1648922976));
		textBox_56.Text = class301_1.vector3_1.Z.ToString(Class16.smethod_0(1648922976));
		textBox_57.Text = class301_1.vector3_3.X.ToString(Class16.smethod_0(1648979502));
		textBox_58.Text = class301_1.vector3_3.Y.ToString(Class16.smethod_0(1648979502));
		textBox_59.Text = class301_1.vector3_3.Z.ToString(Class16.smethod_0(1648979502));
		if (class301_1.class314_0 != null)
		{
			textBox_60.Text = class301_1.class314_0.vector3_3.X.ToString(Class16.smethod_0(1648922976));
			textBox_61.Text = class301_1.class314_0.vector3_3.Y.ToString(Class16.smethod_0(1648922976));
			textBox_62.Text = class301_1.class314_0.vector3_3.Z.ToString(Class16.smethod_0(1648922976));
		}
		else
		{
			textBox_60.Text = Class16.smethod_0(1649210483);
			textBox_61.Text = Class16.smethod_0(1649210483);
			textBox_62.Text = Class16.smethod_0(1649210483);
		}
		button_31.Enabled = false;
		bool_5 = false;
	}

	private void method_78()
	{
		bool_5 = true;
		label_13.Text = Class16.smethod_0(1648966655);
		textBox_54.Text = Class16.smethod_0(1648966655);
		textBox_55.Text = Class16.smethod_0(1648966655);
		textBox_56.Text = Class16.smethod_0(1648966655);
		method_79();
		bool_5 = false;
	}

	private void method_79()
	{
		bool_5 = true;
		textBox_57.Text = Class16.smethod_0(1648966655);
		textBox_58.Text = Class16.smethod_0(1648966655);
		textBox_59.Text = Class16.smethod_0(1648966655);
		textBox_60.Text = Class16.smethod_0(1648966655);
		textBox_61.Text = Class16.smethod_0(1648966655);
		textBox_62.Text = Class16.smethod_0(1648966655);
		button_31.Enabled = false;
		bool_5 = false;
	}

	private float method_80()
	{
		if (float.TryParse(textBox_53?.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
		{
			return Math.Max(0.01f, result);
		}
		return 0.5f;
	}

	private void method_81()
	{
		groupBox_1 = new GroupBox
		{
			Text = Class16.smethod_0(1649210502),
			Dock = DockStyle.Bottom,
			Height = 200,
			Padding = new Padding(4)
		};
		listView_12 = new ListView
		{
			Dock = DockStyle.Fill,
			View = View.Details,
			FullRowSelect = true,
			HideSelection = false,
			GridLines = true,
			MultiSelect = false
		};
		listView_12.Columns.Add(Class16.smethod_0(1648941057), 40);
		listView_12.Columns.Add(Class16.smethod_0(1649013300), 55);
		listView_12.Columns.Add(Class16.smethod_0(1649210518), 75);
		listView_12.Columns.Add(Class16.smethod_0(1649210534), 75);
		listView_12.SelectedIndexChanged += listView_12_SelectedIndexChanged;
		groupBox_1.Controls.Add(listView_12);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			Dock = DockStyle.Bottom,
			Height = 56,
			FlowDirection = FlowDirection.LeftToRight,
			Padding = new Padding(2),
			AutoSize = false
		};
		button_32 = new Button
		{
			Text = Class16.smethod_0(1648931361),
			Width = 60
		};
		button_32.Click += button_32_Click;
		button_33 = new Button
		{
			Text = Class16.smethod_0(1648931371),
			Width = 60,
			Enabled = false
		};
		button_33.Click += button_33_Click;
		Label label = new Label
		{
			Text = Class16.smethod_0(1649016188),
			AutoSize = true,
			Margin = new Padding(8, 6, 2, 0)
		};
		panel_12 = method_82(Color.FromArgb(80, 160, 200));
		Label label2 = new Label
		{
			Text = Class16.smethod_0(1649210544),
			AutoSize = true,
			Margin = new Padding(8, 6, 2, 0)
		};
		panel_13 = method_82(Color.FromArgb(30, 60, 100));
		label_14 = new Label
		{
			Text = Class16.smethod_0(1649210565),
			AutoSize = true,
			Margin = new Padding(10, 6, 0, 0)
		};
		flowLayoutPanel.Controls.AddRange(new Control[7] { button_32, button_33, label, panel_12, label2, panel_13, label_14 });
		groupBox_1.Controls.Add(flowLayoutPanel);
		flowLayoutPanel.BringToFront();
		tabPage_8.Controls.Add(groupBox_1);
		groupBox_1.BringToFront();
	}

	private Panel method_82(Color color_0)
	{
		Class312 @class = new Class312();
		@class.pwMapSharpDxEditorForm_0 = this;
		@class.panel_0 = new Panel
		{
			Width = 28,
			Height = 22,
			BackColor = color_0,
			BorderStyle = BorderStyle.FixedSingle,
			Cursor = Cursors.Hand,
			Margin = new Padding(2, 4, 2, 0)
		};
		@class.panel_0.Click += @class.method_0;
		return @class.panel_0;
	}

	private void listView_12_SelectedIndexChanged(object sender, EventArgs e)
	{
		bool flag = listView_12.SelectedItems.Count > 0;
		button_33.Enabled = flag;
		if (flag)
		{
			ListViewItem listViewItem = listView_12.SelectedItems[0];
			label_14.Text = TextStorage.Msg(Class16.smethod_0(1649210570), Class16.smethod_0(1649210586)) + listViewItem.SubItems[1].Text;
		}
	}

	private void button_32_Click(object sender, EventArgs e)
	{
		int num = listView_12.Items.Count + 1;
		ListViewItem listViewItem = new ListViewItem(num.ToString());
		listViewItem.SubItems.Add(Class16.smethod_0(1648911557));
		listViewItem.SubItems.Add(smethod_7(panel_12.BackColor));
		listViewItem.SubItems.Add(smethod_7(panel_13.BackColor));
		listView_12.Items.Add(listViewItem);
		method_120(string.Format(Class16.smethod_0(1649210606), num), null);
	}

	private void button_33_Click(object sender, EventArgs e)
	{
		if (listView_12.SelectedItems.Count != 0)
		{
			listView_12.Items.Remove(listView_12.SelectedItems[0]);
			method_120(Class16.smethod_0(1649210653), null);
		}
	}

	private static string smethod_7(Color color_0)
	{
		return string.Format(Class16.smethod_0(1649210678), color_0.R, color_0.G, color_0.B);
	}

	private void method_83()
	{
		if (statusStrip_0 != null)
		{
			ToolStripStatusLabel value = new ToolStripStatusLabel(Class16.smethod_0(1649091494))
			{
				BorderSides = ToolStripStatusLabelBorderSides.Right,
				BorderStyle = Border3DStyle.Etched
			};
			statusStrip_0.Items.Add(value);
			toolStripStatusLabel_0 = new ToolStripStatusLabel(Class16.smethod_0(1649084960))
			{
				AutoSize = false,
				Size = new Size(75, 20),
				TextAlign = ContentAlignment.MiddleCenter,
				ToolTipText = Class16.smethod_0(1649210696)
			};
			toolStripStatusLabel_0.DoubleClick += toolStripStatusLabel_2_DoubleClick;
			statusStrip_0.Items.Add(toolStripStatusLabel_0);
			toolStripStatusLabel_1 = new ToolStripStatusLabel(Class16.smethod_0(1649084960))
			{
				AutoSize = false,
				Size = new Size(75, 20),
				TextAlign = ContentAlignment.MiddleCenter,
				ToolTipText = Class16.smethod_0(1649210742)
			};
			toolStripStatusLabel_1.DoubleClick += toolStripStatusLabel_2_DoubleClick;
			statusStrip_0.Items.Add(toolStripStatusLabel_1);
			toolStripStatusLabel_2 = new ToolStripStatusLabel(Class16.smethod_0(1649084960))
			{
				AutoSize = false,
				Size = new Size(75, 20),
				TextAlign = ContentAlignment.MiddleCenter,
				ToolTipText = Class16.smethod_0(1649210780)
			};
			toolStripStatusLabel_2.DoubleClick += toolStripStatusLabel_2_DoubleClick;
			statusStrip_0.Items.Add(toolStripStatusLabel_2);
			toolStripDropDownButton_0 = new ToolStripDropDownButton(Class16.smethod_0(1649089857))
			{
				AutoSize = false,
				Size = new Size(200, 20),
				ToolTipText = Class16.smethod_0(1649210810),
				TextAlign = ContentAlignment.MiddleLeft
			};
			statusStrip_0.Items.Add(toolStripDropDownButton_0);
			toolStripButton_0 = new ToolStripButton(TextStorage.Msg(Class16.smethod_0(1649210851), Class16.smethod_0(1649210866)))
			{
				ToolTipText = Class16.smethod_0(1649210875),
				AutoSize = false,
				Size = new Size(40, 20)
			};
			toolStripButton_0.Click += toolStripButton_0_Click;
			statusStrip_0.Items.Add(toolStripButton_0);
			ToolStripStatusLabel value2 = new ToolStripStatusLabel
			{
				Spring = true
			};
			statusStrip_0.Items.Add(value2);
			toolStripProgressBar_0 = new ToolStripProgressBar
			{
				Size = new Size(100, 16),
				Visible = false
			};
			statusStrip_0.Items.Add(toolStripProgressBar_0);
			toolStripStatusLabel_3 = new ToolStripStatusLabel(Class16.smethod_0(1649209888))
			{
				AutoSize = false,
				Size = new Size(90, 20),
				TextAlign = ContentAlignment.MiddleRight,
				BorderSides = ToolStripStatusLabelBorderSides.Left,
				BorderStyle = Border3DStyle.Etched
			};
			statusStrip_0.Items.Add(toolStripStatusLabel_3);
			toolStripStatusLabel_4 = new ToolStripStatusLabel(Class16.smethod_0(1649209905))
			{
				AutoSize = false,
				Size = new Size(65, 20),
				TextAlign = ContentAlignment.MiddleRight,
				BorderSides = ToolStripStatusLabelBorderSides.Left,
				BorderStyle = Border3DStyle.Etched
			};
			statusStrip_0.Items.Add(toolStripStatusLabel_4);
			toolStripStatusLabel_5 = new ToolStripStatusLabel(Class16.smethod_0(1649209927))
			{
				AutoSize = false,
				Size = new Size(90, 20),
				TextAlign = ContentAlignment.MiddleRight,
				BorderSides = ToolStripStatusLabelBorderSides.Left,
				BorderStyle = Border3DStyle.Etched
			};
			statusStrip_0.Items.Add(toolStripStatusLabel_5);
		}
	}

	private void toolStripStatusLabel_2_DoubleClick(object sender, EventArgs e)
	{
		toolStripButton_0_Click(sender, e);
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		float result = 0f;
		float result2 = 0f;
		float result3 = 0f;
		ToolStripStatusLabel toolStripStatusLabel = toolStripStatusLabel_0;
		object obj;
		if (toolStripStatusLabel == null)
		{
			obj = null;
		}
		else
		{
			obj = toolStripStatusLabel.Text;
			if (obj != null)
			{
				goto IL_0035;
			}
		}
		obj = Class16.smethod_0(1648924112);
		goto IL_0035;
		IL_0067:
		object obj2;
		float.TryParse((string)obj2, NumberStyles.Float, CultureInfo.InvariantCulture, out result2);
		ToolStripStatusLabel toolStripStatusLabel2 = toolStripStatusLabel_2;
		object obj3;
		if (toolStripStatusLabel2 == null)
		{
			obj3 = null;
		}
		else
		{
			obj3 = toolStripStatusLabel2.Text;
			if (obj3 != null)
			{
				goto IL_0099;
			}
		}
		obj3 = Class16.smethod_0(1648924112);
		goto IL_0099;
		IL_0099:
		float.TryParse((string)obj3, NumberStyles.Float, CultureInfo.InvariantCulture, out result3);
		using (Form form = new Form
		{
			Text = Class16.smethod_0(1649209941),
			FormBorderStyle = FormBorderStyle.FixedDialog,
			StartPosition = FormStartPosition.CenterParent,
			ClientSize = new Size(320, 140),
			MaximizeBox = false,
			MinimizeBox = false
		})
		{
			Label label = new Label
			{
				Text = Class16.smethod_0(1649013968),
				Location = new Point(10, 20),
				AutoSize = true
			};
			Label label2 = new Label
			{
				Text = Class16.smethod_0(1649013950),
				Location = new Point(10, 55),
				AutoSize = true
			};
			Label label3 = new Label
			{
				Text = Class16.smethod_0(1649111438),
				Location = new Point(10, 90),
				AutoSize = true
			};
			TextBox textBox = new TextBox
			{
				Text = result.ToString(Class16.smethod_0(1648979502)),
				Location = new Point(40, 17),
				Width = 80
			};
			TextBox textBox2 = new TextBox
			{
				Text = result2.ToString(Class16.smethod_0(1648979502)),
				Location = new Point(40, 52),
				Width = 80
			};
			TextBox textBox3 = new TextBox
			{
				Text = result3.ToString(Class16.smethod_0(1648979502)),
				Location = new Point(40, 87),
				Width = 80
			};
			Button button = new Button
			{
				Text = Class16.smethod_0(1649210866),
				DialogResult = DialogResult.OK,
				Location = new Point(200, 50),
				Size = new Size(100, 35)
			};
			form.Controls.AddRange(new Control[7] { label, label2, label3, textBox, textBox2, textBox3, button });
			form.AcceptButton = button;
			if (form.ShowDialog(this) == DialogResult.OK && float.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var result4) && float.TryParse(textBox2.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var result5) && float.TryParse(textBox3.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var result6))
			{
				method_86(result4, result5, 0f - result6);
				method_120(string.Format(Class16.smethod_0(1649209954), result4, result5, result6), null);
			}
			return;
		}
		IL_0035:
		float.TryParse((string)obj, NumberStyles.Float, CultureInfo.InvariantCulture, out result);
		ToolStripStatusLabel toolStripStatusLabel3 = toolStripStatusLabel_1;
		if (toolStripStatusLabel3 == null)
		{
			obj2 = null;
		}
		else
		{
			obj2 = toolStripStatusLabel3.Text;
			if (obj2 != null)
			{
				goto IL_0067;
			}
		}
		obj2 = Class16.smethod_0(1648924112);
		goto IL_0067;
	}

	private void method_84()
	{
		if (toolStripDropDownButton_0 == null)
		{
			return;
		}
		toolStripDropDownButton_0.DropDownItems.Clear();
		ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649210001), Class16.smethod_0(1649089857)));
		toolStripMenuItem.Click += method_383;
		toolStripDropDownButton_0.DropDownItems.Add(toolStripMenuItem);
		if (precinctFile_0?.zones == null)
		{
			return;
		}
		for (int i = 0; i < precinctFile_0.zones.Count; i++)
		{
			Class315 @class = new Class315();
			@class.pwMapSharpDxEditorForm_0 = this;
			PrecinctEntry precinctEntry = precinctFile_0.zones[i];
			if (precinctEntry != null)
			{
				@class.string_0 = (string.IsNullOrWhiteSpace(precinctEntry.name) ? string.Format(Class16.smethod_0(1649210018), i + 1) : precinctEntry.name.Trim());
				@class.int_0 = i;
				ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem(@class.string_0);
				toolStripMenuItem2.Click += @class.method_0;
				toolStripDropDownButton_0.DropDownItems.Add(toolStripMenuItem2);
			}
		}
	}

	private void method_85(IEnumerable<string> ienumerable_0)
	{
		if (toolStripDropDownButton_0 == null)
		{
			return;
		}
		toolStripDropDownButton_0.DropDownItems.Clear();
		ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649210046), Class16.smethod_0(1649089857)));
		toolStripMenuItem.Click += method_384;
		toolStripDropDownButton_0.DropDownItems.Add(toolStripMenuItem);
		if (ienumerable_0 != null)
		{
			using IEnumerator<string> enumerator = ienumerable_0.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Class300 @class = new Class300();
				@class.pwMapSharpDxEditorForm_0 = this;
				@class.string_0 = enumerator.Current;
				ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem(@class.string_0);
				toolStripMenuItem2.Click += @class.method_0;
				toolStripDropDownButton_0.DropDownItems.Add(toolStripMenuItem2);
			}
		}
		toolStripDropDownButton_0.Text = TextStorage.Msg(Class16.smethod_0(1649210046), Class16.smethod_0(1649089857));
	}

	private void method_86(float float_14, float float_15, float float_16)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		vector3_2 = new Vector3(float_14, float_15, float_16);
	}

	private void method_87(int int_40, bool bool_37)
	{
		if (toolStripProgressBar_0 != null)
		{
			toolStripProgressBar_0.Visible = bool_37;
			toolStripProgressBar_0.Value = Math.Max(0, Math.Min(100, int_40));
		}
	}

	private void method_88(float float_14, float float_15, float float_16)
	{
		if (toolStripStatusLabel_0 == null || base.IsDisposed)
		{
			return;
		}
		toolStripStatusLabel_0.Text = float_14.ToString(Class16.smethod_0(1648979502));
		toolStripStatusLabel_1.Text = float_15.ToString(Class16.smethod_0(1648979502));
		toolStripStatusLabel_2.Text = float_16.ToString(Class16.smethod_0(1648979502));
		int_0++;
		DateTime utcNow = DateTime.UtcNow;
		if ((utcNow - dateTime_0).TotalSeconds >= 1.0)
		{
			int_1 = int_0;
			int_0 = 0;
			dateTime_0 = utcNow;
			if (toolStripStatusLabel_4 != null)
			{
				toolStripStatusLabel_4.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649210070), Class16.smethod_0(1649210086)), int_1);
			}
			if (toolStripStatusLabel_5 != null)
			{
				long num = Process.GetCurrentProcess().PrivateMemorySize64 / 1048576L;
				toolStripStatusLabel_5.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649210101), Class16.smethod_0(1649210112)), num);
			}
			if (toolStripStatusLabel_3 != null)
			{
				int num2 = list_4.Count + list_5.Count + list_6.Count + list_8.Count;
				toolStripStatusLabel_3.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649210130), Class16.smethod_0(1649210146)), num2);
			}
			pictureBox_2?.Invalidate();
		}
	}

	private void method_89()
	{
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Top,
			AutoSize = true,
			ColumnCount = 2,
			Padding = new Padding(4)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649085935)), 0, 0);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			AutoSize = true,
			WrapContents = false
		};
		radioButton_3 = new RadioButton
		{
			Text = Class16.smethod_0(1649210161),
			AutoSize = true,
			Checked = true
		};
		radioButton_4 = new RadioButton
		{
			Text = Class16.smethod_0(1649210179),
			AutoSize = true
		};
		radioButton_5 = new RadioButton
		{
			Text = Class16.smethod_0(1649210192),
			AutoSize = true
		};
		flowLayoutPanel.Controls.AddRange(new Control[3] { radioButton_3, radioButton_4, radioButton_5 });
		tableLayoutPanel.Controls.Add(flowLayoutPanel, 1, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649210214)), 0, 1);
		label_18 = new Label
		{
			Text = Class16.smethod_0(1648966655),
			AutoSize = true,
			Anchor = AnchorStyles.Left
		};
		tableLayoutPanel.Controls.Add(label_18, 1, 1);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649210231)), 0, 2);
		label_19 = new Label
		{
			Text = Class16.smethod_0(1648966655),
			AutoSize = true,
			Anchor = AnchorStyles.Left
		};
		tableLayoutPanel.Controls.Add(label_19, 1, 2);
		Label control = new Label
		{
			Text = Class16.smethod_0(1649210246),
			AutoSize = true,
			Margin = new Padding(4, 8, 4, 4)
		};
		tableLayoutPanel.SetColumnSpan(control, 2);
		tableLayoutPanel.Controls.Add(control, 0, 3);
		button_34 = new Button
		{
			Text = Class16.smethod_0(1649209405),
			AutoSize = true,
			Margin = new Padding(4, 8, 4, 4)
		};
		button_34.Click += button_34_Click;
		tableLayoutPanel.SetColumnSpan(button_34, 2);
		tableLayoutPanel.Controls.Add(button_34, 0, 4);
		tabPage_5.Controls.Add(tableLayoutPanel);
	}

	private void button_34_Click(object sender, EventArgs e)
	{
		if (pwMapTrn2File_0 == null)
		{
			MessageBox.Show(Class16.smethod_0(1649209431), Class16.smethod_0(1649090346), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		using OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Title = Class16.smethod_0(1649209448),
			Filter = Class16.smethod_0(1649209485)
		};
		if (openFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		try
		{
			method_90(openFileDialog.FileName);
			method_353();
			if (bool_34)
			{
				method_359();
			}
			method_120(Class16.smethod_0(1649209564) + System.IO.Path.GetFileName(openFileDialog.FileName), null);
		}
		catch (Exception ex)
		{
			MessageBox.Show(Class16.smethod_0(1649209587) + ex.Message, Class16.smethod_0(1649017275), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_90(string string_6)
	{
		string text = System.IO.Path.GetExtension(string_6)?.ToLowerInvariant();
		int num;
		int num2;
		float[] array;
		if (!(text == Class16.smethod_0(1649089551)) && !(text == Class16.smethod_0(1649209629)))
		{
			Bitmap bitmap = new Bitmap(string_6);
			try
			{
				num = bitmap.Width;
				num2 = bitmap.Height;
				array = new float[num * num2];
				for (int i = 0; i < num2; i++)
				{
					for (int j = 0; j < num; j++)
					{
						array[i * num + j] = (float)(int)bitmap.GetPixel(j, i).R / 255f;
					}
				}
			}
			finally
			{
				((IDisposable)bitmap).Dispose();
			}
		}
		else
		{
			byte[] array2 = File.ReadAllBytes(string_6);
			int num3 = array2.Length / 2;
			int num4 = (int)Math.Sqrt(num3);
			num = num4;
			num2 = num4;
			array = new float[num3];
			for (int k = 0; k < num3; k++)
			{
				ushort num5 = BitConverter.ToUInt16(array2, k * 2);
				array[k] = (float)(int)num5 / 65535f;
			}
		}
		int sectorsWide = pwMapTrn2File_0.SectorsWide;
		int sectorsHigh = pwMapTrn2File_0.SectorsHigh;
		float num6 = pwMapTrn2File_0.Width;
		float num7 = pwMapTrn2File_0.Height;
		float num8 = num6 / (float)sectorsWide;
		float num9 = num7 / (float)sectorsHigh;
		float num10 = 0f;
		float num11 = 200f;
		if (pwMapTrn2File_0.SectorHeights.Count > 0)
		{
			num10 = ((IEnumerable<(float, float)>)pwMapTrn2File_0.SectorHeights).Min((Func<(float, float), float>)Class317.class317_0.method_4);
			num11 = ((IEnumerable<(float, float)>)pwMapTrn2File_0.SectorHeights).Max((Func<(float, float), float>)Class317.class317_0.method_5);
			if (num11 - num10 < 1f)
			{
				num10 = 0f;
				num11 = 200f;
			}
		}
		for (int l = 0; l < pwMapTrn2File_0.TotalSectors; l++)
		{
			PwMapT2bkFile pwMapT2bkFile = method_363(l, (int)num8, (int)num9);
			if (pwMapT2bkFile == null)
			{
				continue;
			}
			int num12 = l / sectorsWide;
			int num13 = l % sectorsWide;
			float num14 = (0f - num6) * 0.5f + (float)num13 * num8 + num8 * 0.5f;
			float num15 = num7 * 0.5f - (float)num12 * num9 - num9 * 0.5f;
			List<float[]> subTerrains = pwMapT2bkFile.GetSubTerrains();
			int tileSize = pwMapT2bkFile.TileSize;
			int gridSpacing = pwMapT2bkFile.GridSpacing;
			int blocksWide = pwMapT2bkFile.BlocksWide;
			int num16 = tileSize / gridSpacing + 1;
			float num17 = num8 * 0.5f;
			float num18 = num9 * 0.5f;
			for (int m = 0; m < subTerrains.Count; m++)
			{
				float[] array3 = subTerrains[m];
				if (array3 == null || array3.Length < 4)
				{
					continue;
				}
				int num19 = m / blocksWide;
				int num20 = m % blocksWide;
				for (int n = 0; n < num16; n++)
				{
					for (int num21 = 0; num21 < num16; num21++)
					{
						int num22 = n * num16 + num21;
						if (num22 < array3.Length)
						{
							float num23 = (float)(num20 * tileSize + num21 * gridSpacing) - num17;
							float num24 = num18 - (float)(num19 * tileSize + n * gridSpacing);
							float num25 = num14 + num23;
							float num26 = num15 + num24;
							float num27 = (num25 + num6 * 0.5f) / num6;
							float num28 = (num7 * 0.5f - num26) / num7;
							int num29 = Math.Max(0, Math.Min((int)(num27 * (float)num), num - 1));
							int num30 = Math.Max(0, Math.Min((int)(num28 * (float)num2), num2 - 1));
							float num31 = array[num30 * num + num29];
							array3[num22] = num10 + num31 * (num11 - num10);
						}
					}
				}
			}
		}
	}

	internal void UpdateTerrainCursorInfo(float float_14, float float_15, float float_16)
	{
		Class307 @class = new Class307();
		@class.pwMapSharpDxEditorForm_0 = this;
		@class.float_0 = float_14;
		@class.float_1 = float_15;
		@class.float_2 = float_16;
		if (label_18 != null)
		{
			if (base.InvokeRequired)
			{
				BeginInvoke(new Action(@class.method_0));
			}
			else
			{
				label_18.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649209632), Class16.smethod_0(1649209650)), @class.float_0, @class.float_1, @class.float_2);
			}
		}
	}

	private void method_91()
	{
		tabPage_4 = new TabPage(Class16.smethod_0(1649209693))
		{
			UseVisualStyleBackColor = true
		};
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 1,
			RowCount = 3,
			Padding = new Padding(2)
		};
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 210f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 60f));
		method_92();
		tableLayoutPanel.Controls.Add(groupBox_2, 0, 0);
		tabControl_3 = new TabControl
		{
			Dock = DockStyle.Fill
		};
		tabPage_5 = new TabPage(Class16.smethod_0(1649209699));
		tabPage_6 = new TabPage(Class16.smethod_0(1649209715));
		tabPage_7 = new TabPage(Class16.smethod_0(1649209728));
		tabPage_5.AutoScroll = true;
		tabPage_6.AutoScroll = true;
		tabPage_7.AutoScroll = true;
		tabControl_3.TabPages.AddRange(new TabPage[3] { tabPage_5, tabPage_6, tabPage_7 });
		tableLayoutPanel.Controls.Add(tabControl_3, 0, 1);
		method_89();
		method_94();
		method_95();
		label_20 = new Label
		{
			Dock = DockStyle.Fill,
			AutoSize = false,
			TextAlign = ContentAlignment.MiddleLeft,
			Text = Class16.smethod_0(1649209747)
		};
		tableLayoutPanel.Controls.Add(label_20, 0, 2);
		tabPage_4.Controls.Add(tableLayoutPanel);
		tabControl_4.TabPages.Add(tabPage_4);
		method_116(Class16.smethod_0(1649209693), tabPage_4);
	}

	private void method_92()
	{
		groupBox_2 = new GroupBox
		{
			Text = Class16.smethod_0(1649085339),
			Dock = DockStyle.Fill,
			Padding = new Padding(4)
		};
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 2,
			AutoSize = true
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648936875)), 0, 0);
		comboBox_7 = new ComboBox
		{
			Dock = DockStyle.Fill,
			DropDownStyle = ComboBoxStyle.DropDownList
		};
		comboBox_7.Items.AddRange(new object[2]
		{
			Class16.smethod_0(1649209777),
			Class16.smethod_0(1649119241)
		});
		comboBox_7.SelectedIndex = 0;
		tableLayoutPanel.Controls.Add(comboBox_7, 1, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648941182)), 0, 1);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill,
			WrapContents = false
		};
		trackBar_10 = new TrackBar
		{
			Minimum = 1,
			Maximum = 50,
			Value = 10,
			Width = 180,
			TickFrequency = 5
		};
		label_15 = new Label
		{
			Text = Class16.smethod_0(1649085888),
			AutoSize = true,
			Margin = new Padding(2, 6, 0, 0)
		};
		trackBar_10.ValueChanged += trackBar_10_ValueChanged;
		flowLayoutPanel.Controls.AddRange(new Control[2] { trackBar_10, label_15 });
		tableLayoutPanel.Controls.Add(flowLayoutPanel, 1, 1);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649209798)), 0, 2);
		FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill,
			WrapContents = false
		};
		trackBar_11 = new TrackBar
		{
			Minimum = 1,
			Maximum = 100,
			Value = 40,
			Width = 180,
			TickFrequency = 10
		};
		label_16 = new Label
		{
			Text = Class16.smethod_0(1649055709),
			AutoSize = true,
			Margin = new Padding(2, 6, 0, 0)
		};
		trackBar_11.ValueChanged += trackBar_11_ValueChanged;
		flowLayoutPanel2.Controls.AddRange(new Control[2] { trackBar_11, label_16 });
		tableLayoutPanel.Controls.Add(flowLayoutPanel2, 1, 2);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648980946)), 0, 3);
		FlowLayoutPanel flowLayoutPanel3 = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill,
			WrapContents = false
		};
		trackBar_12 = new TrackBar
		{
			Minimum = 1,
			Maximum = 90,
			Value = 20,
			Width = 180,
			TickFrequency = 10
		};
		label_17 = new Label
		{
			Text = Class16.smethod_0(1649209813),
			AutoSize = true,
			Margin = new Padding(2, 6, 0, 0)
		};
		trackBar_12.ValueChanged += trackBar_12_ValueChanged;
		flowLayoutPanel3.Controls.AddRange(new Control[2] { trackBar_12, label_17 });
		tableLayoutPanel.Controls.Add(flowLayoutPanel3, 1, 3);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649209816)), 0, 4);
		FlowLayoutPanel flowLayoutPanel4 = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill,
			WrapContents = false
		};
		panel_14 = method_93(Color.FromArgb(76, 230, 26), Class16.smethod_0(1649209837));
		panel_15 = method_93(Color.FromArgb(230, 26, 230), Class16.smethod_0(1649209841));
		panel_16 = method_93(Color.FromArgb(230, 26, 76), Class16.smethod_0(1649212933));
		flowLayoutPanel4.Controls.AddRange(new Control[3] { panel_14, panel_15, panel_16 });
		tableLayoutPanel.Controls.Add(flowLayoutPanel4, 1, 4);
		groupBox_2.Controls.Add(tableLayoutPanel);
	}

	private Panel method_93(Color color_0, string string_6)
	{
		Class318 @class = new Class318();
		@class.panel_0 = new Panel
		{
			Size = new Size(30, 22),
			BackColor = color_0,
			BorderStyle = BorderStyle.FixedSingle,
			Cursor = Cursors.Hand,
			Margin = new Padding(2)
		};
		ToolTip toolTip = new ToolTip();
		toolTip.SetToolTip(@class.panel_0, string_6);
		@class.panel_0.Click += @class.method_0;
		return @class.panel_0;
	}

	private void method_94()
	{
		SplitContainer splitContainer = new SplitContainer
		{
			Dock = DockStyle.Fill,
			Orientation = Orientation.Horizontal,
			SplitterDistance = 150,
			FixedPanel = FixedPanel.Panel2
		};
		listView_13 = new ListView
		{
			Dock = DockStyle.Fill,
			View = View.Details,
			FullRowSelect = true,
			HideSelection = false,
			GridLines = true
		};
		listView_13.Columns.Add(Class16.smethod_0(1649212937), 50);
		listView_13.Columns.Add(Class16.smethod_0(1649212957), 50);
		listView_13.Columns.Add(Class16.smethod_0(1648921800), 65);
		listView_13.Columns.Add(Class16.smethod_0(1648921821), 65);
		splitContainer.Panel1.Controls.Add(listView_13);
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 3,
			RowCount = 2
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648930017)), 0, 0);
		comboBox_8 = new ComboBox
		{
			Dock = DockStyle.Fill,
			DropDownStyle = ComboBoxStyle.DropDownList
		};
		comboBox_8.Items.AddRange(new object[2]
		{
			Class16.smethod_0(1649209837),
			Class16.smethod_0(1649212933)
		});
		comboBox_8.SelectedIndex = 0;
		tableLayoutPanel.Controls.Add(comboBox_8, 1, 0);
		pictureBox_3 = new PictureBox
		{
			Size = new Size(80, 80),
			SizeMode = PictureBoxSizeMode.StretchImage,
			BorderStyle = BorderStyle.FixedSingle
		};
		pictureBox_4 = new PictureBox
		{
			Size = new Size(80, 80),
			SizeMode = PictureBoxSizeMode.StretchImage,
			BorderStyle = BorderStyle.FixedSingle
		};
		tableLayoutPanel.Controls.Add(pictureBox_3, 1, 1);
		tableLayoutPanel.Controls.Add(pictureBox_4, 2, 1);
		splitContainer.Panel2.Controls.Add(tableLayoutPanel);
		tabPage_6.Controls.Add(splitContainer);
	}

	private void method_95()
	{
		SplitContainer splitContainer = new SplitContainer
		{
			Dock = DockStyle.Fill,
			Orientation = Orientation.Horizontal,
			SplitterDistance = 150,
			FixedPanel = FixedPanel.Panel2
		};
		listView_14 = new ListView
		{
			Dock = DockStyle.Fill,
			View = View.Details,
			FullRowSelect = true,
			HideSelection = false,
			GridLines = true
		};
		listView_14.Columns.Add(Class16.smethod_0(1648929947), 40);
		listView_14.Columns.Add(Class16.smethod_0(1649085819), 200);
		splitContainer.Panel1.Controls.Add(listView_14);
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 2,
			AutoSize = true
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		pictureBox_5 = new PictureBox
		{
			Size = new Size(75, 75),
			SizeMode = PictureBoxSizeMode.StretchImage,
			BorderStyle = BorderStyle.FixedSingle
		};
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648992688)), 0, 0);
		tableLayoutPanel.Controls.Add(pictureBox_5, 1, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649212957)), 0, 1);
		comboBox_9 = new ComboBox
		{
			Dock = DockStyle.Fill,
			DropDownStyle = ComboBoxStyle.DropDownList
		};
		comboBox_9.Items.AddRange(new object[3]
		{
			Class16.smethod_0(1649212960),
			Class16.smethod_0(1649212969),
			Class16.smethod_0(1649212978)
		});
		comboBox_9.SelectedIndex = 1;
		tableLayoutPanel.Controls.Add(comboBox_9, 1, 1);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649212987)), 0, 2);
		textBox_63 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_63, 1, 2);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649213001)), 0, 3);
		textBox_64 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_64, 1, 3);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			AutoSize = true
		};
		Button button = new Button
		{
			Text = Class16.smethod_0(1648931361),
			Width = 65
		};
		Button button2 = new Button
		{
			Text = Class16.smethod_0(1648931371),
			Width = 65
		};
		flowLayoutPanel.Controls.AddRange(new Control[2] { button, button2 });
		tableLayoutPanel.SetColumnSpan(flowLayoutPanel, 2);
		tableLayoutPanel.Controls.Add(flowLayoutPanel, 0, 4);
		splitContainer.Panel2.Controls.Add(tableLayoutPanel);
		tabPage_7.Controls.Add(splitContainer);
	}

	private void method_96()
	{
		toolStripSeparator_0 = new ToolStripSeparator();
		toolStrip_0.Items.Add(toolStripSeparator_0);
		toolStripButton_1 = new ToolStripButton
		{
			Text = Class16.smethod_0(1649113514),
			DisplayStyle = ToolStripItemDisplayStyle.Text,
			CheckOnClick = true,
			Checked = true,
			ToolTipText = Class16.smethod_0(1649213023)
		};
		toolStripButton_1.Click += toolStripButton_1_Click;
		toolStrip_0.Items.Add(toolStripButton_1);
		toolStripButton_2 = new ToolStripButton
		{
			Text = Class16.smethod_0(1649213054),
			DisplayStyle = ToolStripItemDisplayStyle.Text,
			CheckOnClick = true,
			ToolTipText = Class16.smethod_0(1649213059)
		};
		toolStripButton_2.Click += toolStripButton_2_Click;
		toolStrip_0.Items.Add(toolStripButton_2);
		toolStripButton_3 = new ToolStripButton
		{
			Text = Class16.smethod_0(1649085669),
			DisplayStyle = ToolStripItemDisplayStyle.Text,
			CheckOnClick = true,
			ToolTipText = Class16.smethod_0(1649213100)
		};
		toolStripButton_3.Click += toolStripButton_3_Click;
		toolStrip_0.Items.Add(toolStripButton_3);
		ToolStripSeparator value = new ToolStripSeparator();
		toolStrip_0.Items.Add(value);
		toolStripButton_4 = new ToolStripButton
		{
			Text = Class16.smethod_0(1649213132),
			DisplayStyle = ToolStripItemDisplayStyle.Text,
			ToolTipText = Class16.smethod_0(1649213143)
		};
		toolStripButton_4.Click += toolStripButton_4_Click;
		toolStrip_0.Items.Add(toolStripButton_4);
		ToolStripSeparator value2 = new ToolStripSeparator();
		toolStrip_0.Items.Add(value2);
		toolStripButton_5 = new ToolStripButton
		{
			Text = Class16.smethod_0(1649213175),
			DisplayStyle = ToolStripItemDisplayStyle.Text,
			CheckOnClick = true,
			ToolTipText = Class16.smethod_0(1649213192)
		};
		toolStripButton_5.CheckedChanged += toolStripButton_5_CheckedChanged;
		toolStrip_0.Items.Add(toolStripButton_5);
		ToolStripSeparator value3 = new ToolStripSeparator();
		toolStrip_0.Items.Add(value3);
		toolStripButton_6 = new ToolStripButton
		{
			Text = Class16.smethod_0(1649213255),
			DisplayStyle = ToolStripItemDisplayStyle.Text,
			ToolTipText = Class16.smethod_0(1649213272)
		};
		toolStripButton_6.Click += toolStripButton_6_Click;
		toolStrip_0.Items.Add(toolStripButton_6);
	}

	private void method_97(string string_6)
	{
		string_1 = string_6;
		toolStripButton_1.Checked = string_6 == Class16.smethod_0(1649113514);
		toolStripButton_2.Checked = string_6 == Class16.smethod_0(1649213054);
		toolStripButton_3.Checked = string_6 == Class16.smethod_0(1649085669);
		method_120(Class16.smethod_0(1649213318) + string_6, null);
	}

	private void toolStripButton_4_Click(object sender, EventArgs e)
	{
		method_135();
	}

	private bool method_98(Keys keys_0)
	{
		switch (keys_0)
		{
		case Keys.E:
			method_97(Class16.smethod_0(1649213054));
			return true;
		case Keys.Insert:
			toolStripButton_4_Click(this, EventArgs.Empty);
			return true;
		case Keys.W:
			method_97(Class16.smethod_0(1649113514));
			return true;
		default:
			return false;
		case Keys.R:
			method_97(Class16.smethod_0(1649085669));
			return true;
		}
	}

	private void method_99()
	{
		panel_17 = new Panel
		{
			Dock = DockStyle.Fill,
			Visible = false
		};
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 1,
			RowCount = 2,
			Padding = new Padding(4)
		};
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		label_21 = new Label
		{
			Text = Class16.smethod_0(1649085498),
			Dock = DockStyle.Fill,
			AutoEllipsis = true,
			Cursor = Cursors.Hand
		};
		label_21.Click += label_21_Click;
		tableLayoutPanel.Controls.Add(label_21, 0, 0);
		TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel
		{
			Dock = DockStyle.Top,
			AutoSize = true,
			ColumnCount = 4,
			Padding = new Padding(4)
		};
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60f));
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
		tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34f));
		tableLayoutPanel2.Controls.Add(new Label
		{
			Text = string.Empty,
			AutoSize = true
		}, 0, 0);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1648916453)), 1, 0);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1648916476)), 2, 0);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1648915467)), 3, 0);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1648893587)), 0, 1);
		textBox_65 = method_26();
		tableLayoutPanel2.Controls.Add(textBox_65, 1, 1);
		textBox_66 = method_26();
		tableLayoutPanel2.Controls.Add(textBox_66, 2, 1);
		textBox_67 = method_26();
		tableLayoutPanel2.Controls.Add(textBox_67, 3, 1);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1649085669)), 0, 2);
		textBox_68 = method_26();
		tableLayoutPanel2.Controls.Add(textBox_68, 1, 2);
		textBox_69 = method_26();
		tableLayoutPanel2.Controls.Add(textBox_69, 2, 2);
		textBox_70 = method_26();
		tableLayoutPanel2.Controls.Add(textBox_70, 3, 2);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1649210418)), 0, 3);
		textBox_71 = method_26();
		tableLayoutPanel2.SetColumnSpan(textBox_71, 3);
		tableLayoutPanel2.Controls.Add(textBox_71, 1, 3);
		button_35 = new Button
		{
			Text = Class16.smethod_0(1648996201),
			AutoSize = true,
			Dock = DockStyle.Left,
			FlatStyle = FlatStyle.Flat
		};
		button_35.Click += button_35_Click;
		tableLayoutPanel2.SetColumnSpan(button_35, 4);
		tableLayoutPanel2.Controls.Add(button_35, 0, 4);
		TextBox[] array = new TextBox[7] { textBox_65, textBox_66, textBox_67, textBox_68, textBox_69, textBox_70, textBox_71 };
		foreach (TextBox textBox in array)
		{
			textBox.KeyDown += method_385;
		}
		tableLayoutPanel.Controls.Add(tableLayoutPanel2, 0, 1);
		panel_17.Controls.Add(tableLayoutPanel);
	}

	private void button_35_Click(object sender, EventArgs e)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		if (class301_1?.class314_0 == null)
		{
			return;
		}
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		if (float.TryParse(textBox_65.Text, NumberStyles.Float, invariantCulture, out var result) && float.TryParse(textBox_66.Text, NumberStyles.Float, invariantCulture, out var result2) && float.TryParse(textBox_67.Text, NumberStyles.Float, invariantCulture, out var result3))
		{
			class301_1.class314_0.vector3_0 = new Vector3(result, result2, result3);
			class301_1.vector3_1 = class301_1.class314_0.vector3_0;
			if (float.TryParse(textBox_68.Text, NumberStyles.Float, invariantCulture, out var result4) && float.TryParse(textBox_69.Text, NumberStyles.Float, invariantCulture, out var result5) && float.TryParse(textBox_70.Text, NumberStyles.Float, invariantCulture, out var result6))
			{
				class301_1.class314_0.vector3_3 = new Vector3(result4, result5, result6);
			}
			method_261();
			method_77();
			method_140();
			method_120(Class16.smethod_0(1649210463) + class301_1.string_0, null);
		}
	}

	private void method_100(string string_6, float float_14, float float_15, float float_16, float float_17, float float_18, float float_19, float float_20)
	{
		if (label_21 != null)
		{
			label_21.Text = TextStorage.Msg(Class16.smethod_0(1649213323), Class16.smethod_0(1649086459)) + (string_6 ?? Class16.smethod_0(1648966655));
			textBox_65.Text = float_14.ToString(Class16.smethod_0(1648964192));
			textBox_66.Text = float_15.ToString(Class16.smethod_0(1648964192));
			textBox_67.Text = float_16.ToString(Class16.smethod_0(1648964192));
			textBox_68.Text = float_17.ToString(Class16.smethod_0(1648964192));
			textBox_69.Text = float_18.ToString(Class16.smethod_0(1648964192));
			textBox_70.Text = float_19.ToString(Class16.smethod_0(1648964192));
			textBox_71.Text = float_20.ToString(Class16.smethod_0(1648964192));
		}
	}

	private void method_101()
	{
		pwMapChangeLog_0 = new PwMapChangeLog();
		pwMapChangeLog_0.AddListener(this);
		toolStripButton_15.Click += toolStripButton_15_Click;
		toolStripButton_16.Click += toolStripButton_16_Click;
		method_103();
	}

	private void toolStripButton_15_Click(object sender, EventArgs e)
	{
		if (pwMapChangeLog_0 != null && pwMapChangeLog_0.CanUndo)
		{
			pwMapChangeLog_0.Undo();
			method_120(Class16.smethod_0(1649213346) + (pwMapChangeLog_0.CanUndo ? pwMapChangeLog_0.UndoDescription : Class16.smethod_0(1649213367)), null);
		}
	}

	private void toolStripButton_16_Click(object sender, EventArgs e)
	{
		if (pwMapChangeLog_0 != null && pwMapChangeLog_0.CanRedo)
		{
			pwMapChangeLog_0.Redo();
			method_120(Class16.smethod_0(1649213388) + (pwMapChangeLog_0.CanRedo ? pwMapChangeLog_0.RedoDescription : Class16.smethod_0(1649213367)), null);
		}
	}

	private bool method_102(Keys keys_0)
	{
		switch (keys_0)
		{
		case Keys.Z | Keys.Control:
			toolStripButton_15_Click(this, EventArgs.Empty);
			return true;
		case Keys.Y | Keys.Control:
			toolStripButton_16_Click(this, EventArgs.Empty);
			return true;
		default:
			return false;
		}
	}

	void IPwMapChangeLogListener.OnChangeLogUpdated(PwMapChangeLog log)
	{
		method_103();
	}

	private void method_103()
	{
		if (toolStripButton_15 != null && toolStripButton_16 != null)
		{
			bool flag = pwMapChangeLog_0?.CanUndo ?? false;
			bool flag2 = pwMapChangeLog_0?.CanRedo ?? false;
			toolStripButton_15.Enabled = flag;
			toolStripButton_16.Enabled = flag2;
			toolStripButton_15.ToolTipText = (flag ? (Class16.smethod_0(1649213346) + pwMapChangeLog_0.UndoDescription) : Class16.smethod_0(1649213393));
			toolStripButton_16.ToolTipText = (flag2 ? (Class16.smethod_0(1649213388) + pwMapChangeLog_0.RedoDescription) : Class16.smethod_0(1649213423));
			if (toolStripMenuItem_19 != null)
			{
				toolStripMenuItem_19.Enabled = flag;
			}
			if (toolStripMenuItem_20 != null)
			{
				toolStripMenuItem_20.Enabled = flag2;
			}
		}
	}

	private void method_104()
	{
		tabPage_8 = new TabPage(Class16.smethod_0(1648976466))
		{
			UseVisualStyleBackColor = true
		};
		SplitContainer splitContainer = new SplitContainer
		{
			Dock = DockStyle.Fill,
			Orientation = Orientation.Horizontal,
			SplitterDistance = 180,
			FixedPanel = FixedPanel.Panel1
		};
		listView_15 = new ListView
		{
			Dock = DockStyle.Fill,
			View = View.Details,
			FullRowSelect = true,
			HideSelection = false,
			GridLines = true
		};
		listView_15.Columns.Add(Class16.smethod_0(1648941057), 40);
		listView_15.Columns.Add(Class16.smethod_0(1648893587), 130);
		listView_15.Columns.Add(Class16.smethod_0(1649055458), 60);
		listView_15.Columns.Add(Class16.smethod_0(1648980967), 60);
		splitContainer.Panel1.Controls.Add(listView_15);
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Top,
			AutoSize = true,
			ColumnCount = 4,
			Padding = new Padding(4)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34f));
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649210380)), 0, 0);
		textBox_72 = smethod_76();
		textBox_72.Text = Class16.smethod_0(1649027725);
		tableLayoutPanel.Controls.Add(textBox_72, 1, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648893587)), 0, 1);
		label_22 = new Label
		{
			Text = Class16.smethod_0(1648966655),
			AutoSize = true
		};
		label_23 = new Label
		{
			Text = Class16.smethod_0(1648966655),
			AutoSize = true
		};
		label_24 = new Label
		{
			Text = Class16.smethod_0(1648966655),
			AutoSize = true
		};
		tableLayoutPanel.Controls.Add(label_22, 1, 1);
		tableLayoutPanel.Controls.Add(label_23, 2, 1);
		tableLayoutPanel.Controls.Add(label_24, 3, 1);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649212421)), 0, 2);
		textBox_73 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_73, 1, 2);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649212437)), 0, 3);
		textBox_74 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_74, 1, 3);
		textBox_75 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_75, 2, 3);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649212452)), 0, 4);
		textBox_76 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_76, 1, 4);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649085884)), 0, 5);
		panel_18 = method_340();
		tableLayoutPanel.Controls.Add(panel_18, 1, 5);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			AutoSize = true
		};
		button_36 = new Button
		{
			Text = Class16.smethod_0(1649212468),
			Width = 80
		};
		button_37 = new Button
		{
			Text = Class16.smethod_0(1648925718),
			Width = 80
		};
		flowLayoutPanel.Controls.AddRange(new Control[2] { button_36, button_37 });
		tableLayoutPanel.SetColumnSpan(flowLayoutPanel, 4);
		tableLayoutPanel.Controls.Add(flowLayoutPanel, 0, 6);
		splitContainer.Panel2.Controls.Add(tableLayoutPanel);
		tabPage_8.Controls.Add(splitContainer);
		tabControl_4.TabPages.Add(tabPage_8);
		method_116(Class16.smethod_0(1648976466), tabPage_8);
	}

	private void method_105()
	{
		listView_15.BeginUpdate();
		listView_15.Items.Clear();
		if (list_0 != null)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				PwMapBsdataFile.WaterBlockEntry waterBlockEntry = list_0[i];
				ListViewItem listViewItem = new ListViewItem(waterBlockEntry.AreaId.ToString());
				listViewItem.SubItems.Add(string.Format(Class16.smethod_0(1649094136), waterBlockEntry.WorldX, waterBlockEntry.WorldY, waterBlockEntry.WorldZ));
				listViewItem.SubItems.Add(waterBlockEntry.WaterHeight.ToString(Class16.smethod_0(1648922976)));
				listViewItem.SubItems.Add(string.Format(Class16.smethod_0(1649212473), waterBlockEntry.Width, waterBlockEntry.Height));
				listView_15.Items.Add(listViewItem);
			}
		}
		listView_15.EndUpdate();
	}

	private ToolStripMenuItem method_106()
	{
		return toolStripMenuItem_6;
	}

	private ToolStripMenuItem method_107()
	{
		return toolStripMenuItem_7;
	}

	private ToolStripMenuItem method_108()
	{
		return toolStripMenuItem_8;
	}

	private ToolStripMenuItem method_109()
	{
		return toolStripMenuItem_9;
	}

	private ToolStripMenuItem method_110()
	{
		return toolStripMenuItem_10;
	}

	private ToolStripMenuItem method_111()
	{
		return toolStripMenuItem_12;
	}

	private ToolStripMenuItem method_112()
	{
		return toolStripMenuItem_11;
	}

	private SplitContainer method_113()
	{
		return splitContainer_0;
	}

	private void method_114()
	{
		tabControl_4 = new TabControl
		{
			Dock = DockStyle.Fill,
			Name = Class16.smethod_0(1649212495),
			Appearance = TabAppearance.FlatButtons,
			ItemSize = new Size(0, 1),
			SizeMode = TabSizeMode.Fixed
		};
		panel_22.Controls.Clear();
		panel_22.Controls.Add(tabControl_4);
		TabPage tabPage = new TabPage(Class16.smethod_0(1649141664))
		{
			Name = Class16.smethod_0(1649212506),
			Padding = new Padding(4)
		};
		SplitContainer splitContainer = new SplitContainer
		{
			Dock = DockStyle.Fill,
			Orientation = Orientation.Horizontal,
			SplitterDistance = 200,
			Name = Class16.smethod_0(1649212520)
		};
		listView_16 = new ListView
		{
			Dock = DockStyle.Fill,
			View = View.Details,
			FullRowSelect = true,
			GridLines = true,
			HeaderStyle = ColumnHeaderStyle.Nonclickable,
			Name = Class16.smethod_0(1649212536)
		};
		listView_16.Columns.Add(Class16.smethod_0(1649212566), 120);
		listView_16.Columns.Add(Class16.smethod_0(1648893060), 300);
		SplitContainer splitContainer2 = new SplitContainer
		{
			Dock = DockStyle.Fill,
			Orientation = Orientation.Horizontal,
			SplitterDistance = 120,
			Name = Class16.smethod_0(1649212571)
		};
		listBox_0 = new ListBox
		{
			Dock = DockStyle.Fill,
			IntegralHeight = false,
			Name = Class16.smethod_0(1649212599)
		};
		pictureBox_6 = new PictureBox
		{
			Dock = DockStyle.Fill,
			SizeMode = PictureBoxSizeMode.Zoom,
			BackColor = SystemColors.Control,
			Name = Class16.smethod_0(1649212609)
		};
		splitContainer2.Panel1.Controls.Add(listBox_0);
		splitContainer2.Panel2.Controls.Add(pictureBox_6);
		splitContainer.Panel1.Controls.Add(listView_16);
		splitContainer.Panel2.Controls.Add(splitContainer2);
		tabPage.Controls.Add(splitContainer);
		tabControl_4.TabPages.Add(tabPage);
		method_115();
	}

	private void method_115()
	{
		toolStripButton_24.Click += toolStripButton_24_Click;
		toolStripButton_25.Click += toolStripButton_25_Click;
		toolStripButton_26.Click += toolStripButton_26_Click;
		toolStripButton_27.Click += toolStripButton_27_Click;
		toolStripButton_28.Click += toolStripButton_28_Click;
		toolStripButton_29.Click += toolStripButton_29_Click;
		toolStripButton_30.Click += toolStripButton_30_Click;
	}

	private void method_116(string string_6, TabPage tabPage_19)
	{
		dictionary_0[string_6] = tabPage_19;
	}

	private void method_117(string string_6)
	{
		if (!(string_2 == string_6))
		{
			string_2 = string_6;
			toolStripButton_24.Checked = string_6 == Class16.smethod_0(1649211364);
			toolStripButton_25.Checked = string_6 == Class16.smethod_0(1649209693);
			toolStripButton_26.Checked = string_6 == Class16.smethod_0(1649084711);
			toolStripButton_27.Checked = string_6 == Class16.smethod_0(1649212626);
			toolStripButton_28.Checked = string_6 == Class16.smethod_0(1648977873);
			toolStripButton_29.Checked = string_6 == Class16.smethod_0(1648976466);
			toolStripButton_30.Checked = string_6 == Class16.smethod_0(1649210934);
			if (dictionary_0.TryGetValue(string_6, out var value))
			{
				tabControl_4.SelectedTab = value;
			}
			method_120(Class16.smethod_0(1649213318) + string_6, null);
		}
	}

	private string method_118()
	{
		string text = (textBox_81.Text ?? string.Empty).Trim();
		if (Directory.Exists(text))
		{
			return text;
		}
		string text2 = (textBox_77.Text ?? string.Empty).Trim();
		string text3 = (textBox_80.Text ?? string.Empty).Trim();
		if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3))
		{
			string text4 = System.IO.Path.Combine(text2, text3);
			if (Directory.Exists(text4))
			{
				return text4;
			}
		}
		return text;
	}

	private void method_119()
	{
		button_40.Enabled = File.Exists(pwMapFileLayout_0.RegionFile);
		button_41.Enabled = File.Exists(pwMapFileLayout_0.PrecinctFile);
		button_42.Enabled = File.Exists(pwMapFileLayout_0.PathDataFile);
		button_43.Enabled = File.Exists(pwMapFileLayout_0.DynamicObjectsFile);
		button_44.Enabled = commonStorage_0 != null;
	}

	private void method_120(string string_6, string string_7)
	{
		toolStripStatusLabel_6.Text = (string.IsNullOrWhiteSpace(string_6) ? Class16.smethod_0(1648920624) : string_6);
		if (!string.IsNullOrWhiteSpace(string_7))
		{
			toolStripStatusLabel_7.Text = string_7;
		}
		else if (pwMapFileLayout_0 != null && !string.IsNullOrWhiteSpace(pwMapFileLayout_0.MapName))
		{
			toolStripStatusLabel_7.Text = TextStorage.Msg(Class16.smethod_0(1649212647), Class16.smethod_0(1649083522)) + pwMapFileLayout_0.MapName;
		}
		else
		{
			toolStripStatusLabel_7.Text = TextStorage.Msg(Class16.smethod_0(1649212663), Class16.smethod_0(1649082562));
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_121()
	{
		icontainer_0 = new Container();
		menuStrip_0 = new MenuStrip();
		toolStripMenuItem_0 = new ToolStripMenuItem();
		toolStripMenuItem_1 = new ToolStripMenuItem();
		toolStripSeparator_1 = new ToolStripSeparator();
		toolStripMenuItem_2 = new ToolStripMenuItem();
		toolStripSeparator_2 = new ToolStripSeparator();
		toolStripMenuItem_3 = new ToolStripMenuItem();
		toolStripMenuItem_4 = new ToolStripMenuItem();
		toolStripMenuItem_5 = new ToolStripMenuItem();
		toolStripMenuItem_6 = new ToolStripMenuItem();
		toolStripMenuItem_7 = new ToolStripMenuItem();
		toolStripMenuItem_8 = new ToolStripMenuItem();
		toolStripMenuItem_9 = new ToolStripMenuItem();
		toolStripMenuItem_10 = new ToolStripMenuItem();
		toolStripSeparator_3 = new ToolStripSeparator();
		toolStripMenuItem_11 = new ToolStripMenuItem();
		toolStripSeparator_4 = new ToolStripSeparator();
		toolStripMenuItem_12 = new ToolStripMenuItem();
		toolStripSeparator_5 = new ToolStripSeparator();
		toolStripMenuItem_13 = new ToolStripMenuItem();
		toolStripMenuItem_14 = new ToolStripMenuItem();
		toolStripMenuItem_15 = new ToolStripMenuItem();
		toolStripMenuItem_16 = new ToolStripMenuItem();
		toolStripMenuItem_17 = new ToolStripMenuItem();
		toolStripMenuItem_18 = new ToolStripMenuItem();
		toolStripMenuItem_19 = new ToolStripMenuItem();
		toolStripMenuItem_20 = new ToolStripMenuItem();
		toolStripSeparator_6 = new ToolStripSeparator();
		toolStripMenuItem_21 = new ToolStripMenuItem();
		toolStripMenuItem_22 = new ToolStripMenuItem();
		toolStripSeparator_7 = new ToolStripSeparator();
		toolStripMenuItem_23 = new ToolStripMenuItem();
		toolStripMenuItem_24 = new ToolStripMenuItem();
		toolStripMenuItem_26 = new ToolStripMenuItem();
		toolStripMenuItem_25 = new ToolStripMenuItem();
		toolStrip_0 = new ToolStrip();
		toolStripButton_14 = new ToolStripButton();
		toolStripSeparator_8 = new ToolStripSeparator();
		toolStripButton_15 = new ToolStripButton();
		toolStripButton_16 = new ToolStripButton();
		toolStripSeparator_9 = new ToolStripSeparator();
		toolStripButton_17 = new ToolStripButton();
		toolStripButton_18 = new ToolStripButton();
		toolStripButton_19 = new ToolStripButton();
		toolStripButton_20 = new ToolStripButton();
		toolStripButton_21 = new ToolStripButton();
		toolStripButton_22 = new ToolStripButton();
		toolStripButton_23 = new ToolStripButton();
		toolStripSeparator_10 = new ToolStripSeparator();
		toolStripButton_24 = new ToolStripButton();
		toolStripButton_25 = new ToolStripButton();
		toolStripButton_26 = new ToolStripButton();
		toolStripButton_27 = new ToolStripButton();
		toolStripButton_28 = new ToolStripButton();
		toolStripButton_29 = new ToolStripButton();
		toolStripButton_30 = new ToolStripButton();
		splitContainer_0 = new SplitContainer();
		splitContainer_1 = new SplitContainer();
		panel_19 = new Panel();
		panel_20 = new Panel();
		groupBox_3 = new GroupBox();
		checkBox_35 = new CheckBox();
		checkBox_36 = new CheckBox();
		checkBox_37 = new CheckBox();
		checkBox_38 = new CheckBox();
		checkBox_39 = new CheckBox();
		checkBox_40 = new CheckBox();
		groupBox_4 = new GroupBox();
		label_25 = new Label();
		radioButton_6 = new RadioButton();
		radioButton_7 = new RadioButton();
		label_26 = new Label();
		label_27 = new Label();
		trackBar_13 = new TrackBar();
		groupBox_5 = new GroupBox();
		label_28 = new Label();
		trackBar_14 = new TrackBar();
		label_29 = new Label();
		trackBar_15 = new TrackBar();
		label_30 = new Label();
		trackBar_16 = new TrackBar();
		tabControl_5 = new TabControl();
		tabPage_9 = new TabPage();
		tabPage_10 = new TabPage();
		tabPage_11 = new TabPage();
		pictureBox_7 = new PictureBox();
		pictureBox_8 = new PictureBox();
		pictureBox_9 = new PictureBox();
		button_45 = new Button();
		button_46 = new Button();
		panel_21 = new Panel();
		label_31 = new Label();
		panel_22 = new Panel();
		label_32 = new Label();
		statusStrip_0 = new StatusStrip();
		toolStripStatusLabel_6 = new ToolStripStatusLabel();
		toolStripStatusLabel_7 = new ToolStripStatusLabel();
		menuStrip_0.SuspendLayout();
		toolStrip_0.SuspendLayout();
		((ISupportInitialize)splitContainer_0).BeginInit();
		splitContainer_0.Panel1.SuspendLayout();
		splitContainer_0.Panel2.SuspendLayout();
		splitContainer_0.SuspendLayout();
		((ISupportInitialize)splitContainer_1).BeginInit();
		splitContainer_1.Panel1.SuspendLayout();
		splitContainer_1.Panel2.SuspendLayout();
		splitContainer_1.SuspendLayout();
		panel_19.SuspendLayout();
		panel_20.SuspendLayout();
		groupBox_3.SuspendLayout();
		groupBox_4.SuspendLayout();
		groupBox_5.SuspendLayout();
		((ISupportInitialize)trackBar_13).BeginInit();
		((ISupportInitialize)trackBar_14).BeginInit();
		((ISupportInitialize)trackBar_15).BeginInit();
		((ISupportInitialize)trackBar_16).BeginInit();
		tabControl_5.SuspendLayout();
		tabPage_9.SuspendLayout();
		tabPage_10.SuspendLayout();
		tabPage_11.SuspendLayout();
		((ISupportInitialize)pictureBox_7).BeginInit();
		((ISupportInitialize)pictureBox_8).BeginInit();
		((ISupportInitialize)pictureBox_9).BeginInit();
		panel_21.SuspendLayout();
		panel_22.SuspendLayout();
		statusStrip_0.SuspendLayout();
		SuspendLayout();
		menuStrip_0.ImageScalingSize = new Size(20, 20);
		menuStrip_0.Items.AddRange(new ToolStripItem[5] { toolStripMenuItem_0, toolStripMenuItem_18, toolStripMenuItem_5, toolStripMenuItem_24, toolStripMenuItem_15 });
		menuStrip_0.Location = new Point(0, 0);
		menuStrip_0.Name = Class16.smethod_0(1649078164);
		menuStrip_0.Padding = new Padding(6, 2, 0, 2);
		menuStrip_0.Size = new Size(1600, 28);
		menuStrip_0.TabIndex = 0;
		toolStripMenuItem_0.DropDownItems.AddRange(new ToolStripItem[6] { toolStripMenuItem_1, toolStripSeparator_1, toolStripMenuItem_2, toolStripSeparator_2, toolStripMenuItem_3, toolStripMenuItem_4 });
		toolStripMenuItem_0.Name = Class16.smethod_0(1648920842);
		toolStripMenuItem_0.Size = new Size(46, 24);
		toolStripMenuItem_0.Text = Class16.smethod_0(1649000202);
		toolStripMenuItem_1.Name = Class16.smethod_0(1649212684);
		toolStripMenuItem_1.ShortcutKeys = Keys.O | Keys.Control;
		toolStripMenuItem_1.Size = new Size(220, 26);
		toolStripMenuItem_1.Text = Class16.smethod_0(1649212701);
		toolStripSeparator_1.Name = Class16.smethod_0(1649000308);
		toolStripSeparator_1.Size = new Size(217, 6);
		toolStripMenuItem_2.Name = Class16.smethod_0(1649212719);
		toolStripMenuItem_2.Size = new Size(220, 26);
		toolStripMenuItem_2.Text = Class16.smethod_0(1649212740);
		toolStripSeparator_2.Name = Class16.smethod_0(1649000385);
		toolStripSeparator_2.Size = new Size(217, 6);
		toolStripMenuItem_3.Name = Class16.smethod_0(1649035049);
		toolStripMenuItem_3.ShortcutKeys = Keys.S | Keys.Control;
		toolStripMenuItem_3.Size = new Size(220, 26);
		toolStripMenuItem_3.Text = Class16.smethod_0(1648999133);
		toolStripMenuItem_4.Name = Class16.smethod_0(1648920908);
		toolStripMenuItem_4.ShortcutKeys = Keys.F4 | Keys.Alt;
		toolStripMenuItem_4.Size = new Size(220, 26);
		toolStripMenuItem_4.Text = Class16.smethod_0(1648920914);
		toolStripMenuItem_18.DropDownItems.AddRange(new ToolStripItem[7] { toolStripMenuItem_19, toolStripMenuItem_20, toolStripSeparator_6, toolStripMenuItem_21, toolStripMenuItem_22, toolStripSeparator_7, toolStripMenuItem_23 });
		toolStripMenuItem_18.Name = Class16.smethod_0(1649000435);
		toolStripMenuItem_18.Size = new Size(46, 24);
		toolStripMenuItem_18.Text = Class16.smethod_0(1648999425);
		toolStripMenuItem_19.Name = Class16.smethod_0(1648999445);
		toolStripMenuItem_19.ShortcutKeys = Keys.Z | Keys.Control;
		toolStripMenuItem_19.Size = new Size(240, 26);
		toolStripMenuItem_19.Text = Class16.smethod_0(1648999463);
		toolStripMenuItem_20.Name = Class16.smethod_0(1648999467);
		toolStripMenuItem_20.ShortcutKeys = Keys.Y | Keys.Control;
		toolStripMenuItem_20.Size = new Size(240, 26);
		toolStripMenuItem_20.Text = Class16.smethod_0(1648999493);
		toolStripSeparator_6.Name = Class16.smethod_0(1648999497);
		toolStripSeparator_6.Size = new Size(237, 6);
		toolStripMenuItem_21.Name = Class16.smethod_0(1649212753);
		toolStripMenuItem_21.ShortcutKeys = Keys.F | Keys.Control;
		toolStripMenuItem_21.Size = new Size(240, 26);
		toolStripMenuItem_21.Text = Class16.smethod_0(1649212781);
		toolStripMenuItem_22.Name = Class16.smethod_0(1649212806);
		toolStripMenuItem_22.ShortcutKeys = Keys.A | Keys.Control;
		toolStripMenuItem_22.Size = new Size(240, 26);
		toolStripMenuItem_22.Text = Class16.smethod_0(1648999844);
		toolStripMenuItem_22.Enabled = false;
		toolStripSeparator_7.Name = Class16.smethod_0(1648999644);
		toolStripSeparator_7.Size = new Size(237, 6);
		toolStripMenuItem_23.Name = Class16.smethod_0(1649212829);
		toolStripMenuItem_23.Size = new Size(240, 26);
		toolStripMenuItem_23.Text = Class16.smethod_0(1649212854);
		toolStripMenuItem_24.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem_26, toolStripMenuItem_25 });
		toolStripMenuItem_24.Name = Class16.smethod_0(1649036553);
		toolStripMenuItem_24.Size = new Size(56, 24);
		toolStripMenuItem_24.Text = Class16.smethod_0(1649212887);
		toolStripMenuItem_26.Name = Class16.smethod_0(1649212900);
		toolStripMenuItem_26.ShortcutKeys = Keys.G | Keys.Control;
		toolStripMenuItem_26.Size = new Size(240, 26);
		toolStripMenuItem_26.Text = Class16.smethod_0(1649212919);
		toolStripMenuItem_25.Name = Class16.smethod_0(1649211912);
		toolStripMenuItem_25.Size = new Size(240, 26);
		toolStripMenuItem_25.Text = Class16.smethod_0(1649211936);
		toolStripMenuItem_5.DropDownItems.AddRange(new ToolStripItem[12]
		{
			toolStripMenuItem_6, toolStripMenuItem_7, toolStripMenuItem_8, toolStripMenuItem_9, toolStripMenuItem_10, toolStripSeparator_3, toolStripMenuItem_11, toolStripSeparator_4, toolStripMenuItem_12, toolStripSeparator_5,
			toolStripMenuItem_13, toolStripMenuItem_14
		});
		toolStripMenuItem_5.Name = Class16.smethod_0(1649070054);
		toolStripMenuItem_5.Size = new Size(53, 24);
		toolStripMenuItem_5.Text = Class16.smethod_0(1649211963);
		toolStripMenuItem_6.CheckOnClick = true;
		toolStripMenuItem_6.Checked = true;
		toolStripMenuItem_6.CheckState = CheckState.Checked;
		toolStripMenuItem_6.Name = Class16.smethod_0(1649211983);
		toolStripMenuItem_6.Size = new Size(200, 26);
		toolStripMenuItem_6.Text = Class16.smethod_0(1649212006);
		toolStripMenuItem_7.CheckOnClick = true;
		toolStripMenuItem_7.Checked = true;
		toolStripMenuItem_7.CheckState = CheckState.Checked;
		toolStripMenuItem_7.Name = Class16.smethod_0(1649212028);
		toolStripMenuItem_7.Size = new Size(200, 26);
		toolStripMenuItem_7.Text = Class16.smethod_0(1649212047);
		toolStripMenuItem_8.CheckOnClick = true;
		toolStripMenuItem_8.Checked = true;
		toolStripMenuItem_8.CheckState = CheckState.Checked;
		toolStripMenuItem_8.Name = Class16.smethod_0(1649212057);
		toolStripMenuItem_8.Size = new Size(200, 26);
		toolStripMenuItem_8.Text = Class16.smethod_0(1649212084);
		toolStripMenuItem_9.CheckOnClick = true;
		toolStripMenuItem_9.Checked = true;
		toolStripMenuItem_9.CheckState = CheckState.Checked;
		toolStripMenuItem_9.Name = Class16.smethod_0(1649212102);
		toolStripMenuItem_9.Size = new Size(200, 26);
		toolStripMenuItem_9.Text = Class16.smethod_0(1649212124);
		toolStripMenuItem_10.CheckOnClick = true;
		toolStripMenuItem_10.Checked = true;
		toolStripMenuItem_10.CheckState = CheckState.Checked;
		toolStripMenuItem_10.Name = Class16.smethod_0(1649212137);
		toolStripMenuItem_10.Size = new Size(200, 26);
		toolStripMenuItem_10.Text = Class16.smethod_0(1649212160);
		toolStripSeparator_3.Name = Class16.smethod_0(1649212185);
		toolStripSeparator_3.Size = new Size(197, 6);
		toolStripMenuItem_11.CheckOnClick = true;
		toolStripMenuItem_11.Checked = true;
		toolStripMenuItem_11.CheckState = CheckState.Checked;
		toolStripMenuItem_11.Name = Class16.smethod_0(1649212203);
		toolStripMenuItem_11.Size = new Size(200, 26);
		toolStripMenuItem_11.Text = Class16.smethod_0(1649212230);
		toolStripSeparator_4.Name = Class16.smethod_0(1649212235);
		toolStripSeparator_4.Size = new Size(197, 6);
		toolStripMenuItem_12.Name = Class16.smethod_0(1649212261);
		toolStripMenuItem_12.ShortcutKeys = Keys.F5;
		toolStripMenuItem_12.Size = new Size(200, 26);
		toolStripMenuItem_12.Text = Class16.smethod_0(1649212287);
		toolStripSeparator_5.Name = Class16.smethod_0(1649212308);
		toolStripSeparator_5.Size = new Size(197, 6);
		toolStripMenuItem_13.CheckOnClick = true;
		toolStripMenuItem_13.Name = Class16.smethod_0(1649212326);
		toolStripMenuItem_13.Size = new Size(200, 26);
		toolStripMenuItem_13.Text = Class16.smethod_0(1649212350);
		toolStripMenuItem_14.Name = Class16.smethod_0(1649212373);
		toolStripMenuItem_14.ShortcutKeys = Keys.F1;
		toolStripMenuItem_14.Size = new Size(200, 26);
		toolStripMenuItem_14.Text = Class16.smethod_0(1649212396);
		toolStripMenuItem_15.DropDownItems.AddRange(new ToolStripItem[2] { toolStripMenuItem_16, toolStripMenuItem_17 });
		toolStripMenuItem_15.Name = Class16.smethod_0(1648996987);
		toolStripMenuItem_15.Size = new Size(64, 24);
		toolStripMenuItem_15.Text = Class16.smethod_0(1649211393);
		toolStripMenuItem_16.Name = Class16.smethod_0(1649211415);
		toolStripMenuItem_16.Size = new Size(200, 26);
		toolStripMenuItem_16.Text = Class16.smethod_0(1649211437);
		toolStripMenuItem_17.Name = Class16.smethod_0(1649211461);
		toolStripMenuItem_17.Size = new Size(200, 26);
		toolStripMenuItem_17.Text = Class16.smethod_0(1649211475);
		toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
		toolStrip_0.ImageScalingSize = new Size(20, 20);
		toolStrip_0.Items.AddRange(new ToolStripItem[20]
		{
			toolStripButton_14, toolStripSeparator_8, toolStripButton_15, toolStripButton_16, toolStripSeparator_9, toolStripButton_17, toolStripButton_18, toolStripButton_19, toolStripButton_20, toolStripButton_21,
			toolStripButton_22, toolStripButton_23, toolStripSeparator_10, toolStripButton_24, toolStripButton_25, toolStripButton_26, toolStripButton_27, toolStripButton_28, toolStripButton_29, toolStripButton_30
		});
		toolStrip_0.Location = new Point(0, 28);
		toolStrip_0.Name = Class16.smethod_0(1648920933);
		toolStrip_0.Padding = new Padding(4, 0, 4, 0);
		toolStrip_0.Size = new Size(1600, 31);
		toolStrip_0.TabIndex = 1;
		toolStripButton_14.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_14.Name = Class16.smethod_0(1649211499);
		toolStripButton_14.Size = new Size(44, 28);
		toolStripButton_14.Text = Class16.smethod_0(1648941761);
		toolStripButton_14.ToolTipText = Class16.smethod_0(1649211526);
		toolStripButton_15.DisplayStyle = ToolStripItemDisplayStyle.Image;
		toolStripButton_15.Enabled = false;
		toolStripButton_15.Image = Resources.GShopEditor_PW_mbUndo;
		toolStripButton_15.ImageTransparentColor = Color.Magenta;
		toolStripButton_15.Name = Class16.smethod_0(1649211550);
		toolStripButton_15.Size = new Size(23, 28);
		toolStripButton_15.Text = Class16.smethod_0(1648903487);
		toolStripButton_15.ToolTipText = Class16.smethod_0(1648933841);
		toolStripButton_16.DisplayStyle = ToolStripItemDisplayStyle.Image;
		toolStripButton_16.Enabled = false;
		toolStripButton_16.Image = Resources.GShopEditor_PW_mbRedo;
		toolStripButton_16.ImageTransparentColor = Color.Magenta;
		toolStripButton_16.Name = Class16.smethod_0(1649211564);
		toolStripButton_16.Size = new Size(23, 28);
		toolStripButton_16.Text = Class16.smethod_0(1648903490);
		toolStripButton_16.ToolTipText = Class16.smethod_0(1648933869);
		toolStripButton_17.CheckOnClick = true;
		toolStripButton_17.Checked = true;
		toolStripButton_17.CheckState = CheckState.Checked;
		toolStripButton_17.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_17.Name = Class16.smethod_0(1649211570);
		toolStripButton_17.Size = new Size(28, 28);
		toolStripButton_17.Text = Class16.smethod_0(1649211595);
		toolStripButton_17.ToolTipText = Class16.smethod_0(1649211620);
		toolStripButton_18.CheckOnClick = true;
		toolStripButton_18.Checked = true;
		toolStripButton_18.CheckState = CheckState.Checked;
		toolStripButton_18.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_18.Name = Class16.smethod_0(1649211654);
		toolStripButton_18.Size = new Size(28, 28);
		toolStripButton_18.Text = Class16.smethod_0(1649211667);
		toolStripButton_18.ToolTipText = Class16.smethod_0(1649211692);
		toolStripButton_19.CheckOnClick = true;
		toolStripButton_19.Checked = true;
		toolStripButton_19.CheckState = CheckState.Checked;
		toolStripButton_19.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_19.Name = Class16.smethod_0(1649211719);
		toolStripButton_19.Size = new Size(28, 28);
		toolStripButton_19.Text = Class16.smethod_0(1649211740);
		toolStripButton_19.ToolTipText = Class16.smethod_0(1649211757);
		toolStripButton_20.CheckOnClick = true;
		toolStripButton_20.Checked = true;
		toolStripButton_20.CheckState = CheckState.Checked;
		toolStripButton_20.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_20.Name = Class16.smethod_0(1649211768);
		toolStripButton_20.Size = new Size(28, 28);
		toolStripButton_20.Text = Class16.smethod_0(1649211797);
		toolStripButton_20.ToolTipText = Class16.smethod_0(1649211814);
		toolStripButton_21.CheckOnClick = true;
		toolStripButton_21.Checked = true;
		toolStripButton_21.CheckState = CheckState.Checked;
		toolStripButton_21.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_21.Name = Class16.smethod_0(1649211825);
		toolStripButton_21.Size = new Size(28, 28);
		toolStripButton_21.Text = Class16.smethod_0(1649211852);
		toolStripButton_21.ToolTipText = Class16.smethod_0(1649211859);
		toolStripButton_22.CheckOnClick = true;
		toolStripButton_22.Checked = true;
		toolStripButton_22.CheckState = CheckState.Checked;
		toolStripButton_22.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_22.Name = Class16.smethod_0(1649211880);
		toolStripButton_22.Size = new Size(28, 28);
		toolStripButton_22.Text = Class16.smethod_0(1649211899);
		toolStripButton_22.ToolTipText = Class16.smethod_0(1649206804);
		toolStripButton_23.CheckOnClick = true;
		toolStripButton_23.Checked = true;
		toolStripButton_23.CheckState = CheckState.Checked;
		toolStripButton_23.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_23.Name = Class16.smethod_0(1649206829);
		toolStripButton_23.Size = new Size(28, 28);
		toolStripButton_23.Text = Class16.smethod_0(1649206843);
		toolStripButton_23.ToolTipText = Class16.smethod_0(1649206868);
		toolStripButton_24.CheckOnClick = true;
		toolStripButton_24.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_24.Name = Class16.smethod_0(1649206880);
		toolStripButton_24.Size = new Size(70, 28);
		toolStripButton_24.Text = Class16.smethod_0(1649211364);
		toolStripButton_24.ToolTipText = Class16.smethod_0(1649206911);
		toolStripButton_25.CheckOnClick = true;
		toolStripButton_25.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_25.Name = Class16.smethod_0(1649206928);
		toolStripButton_25.Size = new Size(70, 28);
		toolStripButton_25.Text = Class16.smethod_0(1649209693);
		toolStripButton_25.ToolTipText = Class16.smethod_0(1649206957);
		toolStripButton_26.CheckOnClick = true;
		toolStripButton_26.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_26.Name = Class16.smethod_0(1649206971);
		toolStripButton_26.Size = new Size(70, 28);
		toolStripButton_26.Text = Class16.smethod_0(1649084711);
		toolStripButton_26.ToolTipText = Class16.smethod_0(1649206992);
		toolStripButton_27.CheckOnClick = true;
		toolStripButton_27.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_27.Name = Class16.smethod_0(1649207022);
		toolStripButton_27.Size = new Size(70, 28);
		toolStripButton_27.Text = Class16.smethod_0(1649212626);
		toolStripButton_27.ToolTipText = Class16.smethod_0(1649207034);
		toolStripButton_28.CheckOnClick = true;
		toolStripButton_28.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_28.Name = Class16.smethod_0(1649207058);
		toolStripButton_28.Size = new Size(70, 28);
		toolStripButton_28.Text = Class16.smethod_0(1648977873);
		toolStripButton_28.ToolTipText = Class16.smethod_0(1649207085);
		toolStripButton_29.CheckOnClick = true;
		toolStripButton_29.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_29.Name = Class16.smethod_0(1649207097);
		toolStripButton_29.Size = new Size(70, 28);
		toolStripButton_29.Text = Class16.smethod_0(1648976466);
		toolStripButton_29.ToolTipText = Class16.smethod_0(1649207124);
		toolStripButton_30.CheckOnClick = true;
		toolStripButton_30.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton_30.Name = Class16.smethod_0(1649207136);
		toolStripButton_30.Size = new Size(70, 28);
		toolStripButton_30.Text = Class16.smethod_0(1649210934);
		toolStripButton_30.ToolTipText = Class16.smethod_0(1649207155);
		splitContainer_0.Dock = DockStyle.Fill;
		splitContainer_0.FixedPanel = FixedPanel.Panel1;
		splitContainer_0.Location = new Point(0, 59);
		splitContainer_0.Name = Class16.smethod_0(1649207186);
		splitContainer_0.Panel1.Controls.Add(panel_19);
		splitContainer_0.Panel2.Controls.Add(splitContainer_1);
		splitContainer_0.Size = new Size(1600, 686);
		splitContainer_0.SplitterDistance = 280;
		splitContainer_0.SplitterWidth = 5;
		splitContainer_0.TabIndex = 2;
		splitContainer_1.Dock = DockStyle.Fill;
		splitContainer_1.FixedPanel = FixedPanel.Panel2;
		splitContainer_1.Name = Class16.smethod_0(1649207203);
		splitContainer_1.Panel1.Controls.Add(panel_21);
		splitContainer_1.Panel2.Controls.Add(panel_22);
		splitContainer_1.Size = new Size(1335, 686);
		splitContainer_1.SplitterDistance = 1024;
		splitContainer_1.SplitterWidth = 5;
		splitContainer_1.TabIndex = 0;
		panel_19.AutoScroll = true;
		panel_19.BackColor = SystemColors.Control;
		panel_19.Controls.Add(panel_20);
		panel_19.Dock = DockStyle.Fill;
		panel_19.Name = Class16.smethod_0(1649207226);
		panel_19.Size = new Size(280, 686);
		panel_19.TabIndex = 0;
		panel_20.AutoSize = true;
		panel_20.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		panel_20.BackColor = SystemColors.Control;
		panel_20.Controls.Add(groupBox_3);
		panel_20.Controls.Add(groupBox_4);
		panel_20.Controls.Add(groupBox_5);
		panel_20.Controls.Add(tabControl_5);
		panel_20.Controls.Add(button_45);
		panel_20.Controls.Add(button_46);
		panel_20.Dock = DockStyle.Top;
		panel_20.Name = Class16.smethod_0(1649207240);
		panel_20.Padding = new Padding(2, 4, 2, 4);
		panel_20.Size = new Size(280, 820);
		panel_20.TabIndex = 0;
		groupBox_3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_3.Controls.Add(checkBox_35);
		groupBox_3.Controls.Add(checkBox_36);
		groupBox_3.Controls.Add(checkBox_37);
		groupBox_3.Controls.Add(checkBox_38);
		groupBox_3.Controls.Add(checkBox_39);
		groupBox_3.Controls.Add(checkBox_40);
		groupBox_3.ForeColor = SystemColors.ControlText;
		groupBox_3.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Bold);
		groupBox_3.Location = new Point(4, 6);
		groupBox_3.Name = Class16.smethod_0(1649207268);
		groupBox_3.Size = new Size(270, 168);
		groupBox_3.TabIndex = 0;
		groupBox_3.TabStop = false;
		groupBox_3.Text = Class16.smethod_0(1649207283);
		checkBox_35.AutoSize = true;
		checkBox_35.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular);
		checkBox_35.ForeColor = SystemColors.ControlText;
		checkBox_35.Location = new Point(10, 22);
		checkBox_35.Name = Class16.smethod_0(1649206280);
		checkBox_35.Size = new Size(131, 19);
		checkBox_35.TabIndex = 0;
		checkBox_35.Text = Class16.smethod_0(1649206309);
		checkBox_35.UseVisualStyleBackColor = true;
		checkBox_36.AutoSize = true;
		checkBox_36.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular);
		checkBox_36.ForeColor = SystemColors.ControlText;
		checkBox_36.Location = new Point(10, 46);
		checkBox_36.Name = Class16.smethod_0(1649206333);
		checkBox_36.Size = new Size(138, 19);
		checkBox_36.TabIndex = 1;
		checkBox_36.Text = Class16.smethod_0(1649206346);
		checkBox_36.UseVisualStyleBackColor = true;
		checkBox_37.AutoSize = true;
		checkBox_37.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular);
		checkBox_37.ForeColor = SystemColors.ControlText;
		checkBox_37.Location = new Point(10, 70);
		checkBox_37.Name = Class16.smethod_0(1649206370);
		checkBox_37.Size = new Size(127, 19);
		checkBox_37.TabIndex = 2;
		checkBox_37.Text = Class16.smethod_0(1649206397);
		checkBox_37.UseVisualStyleBackColor = true;
		checkBox_38.AutoSize = true;
		checkBox_38.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular);
		checkBox_38.ForeColor = SystemColors.ControlText;
		checkBox_38.Location = new Point(10, 94);
		checkBox_38.Name = Class16.smethod_0(1649206411);
		checkBox_38.Size = new Size(139, 19);
		checkBox_38.TabIndex = 3;
		checkBox_38.Text = Class16.smethod_0(1649206432);
		checkBox_38.UseVisualStyleBackColor = true;
		checkBox_39.AutoSize = true;
		checkBox_39.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular);
		checkBox_39.ForeColor = SystemColors.ControlText;
		checkBox_39.Location = new Point(10, 118);
		checkBox_39.Name = Class16.smethod_0(1649206456);
		checkBox_39.Size = new Size(97, 19);
		checkBox_39.TabIndex = 4;
		checkBox_39.Text = Class16.smethod_0(1649206475);
		checkBox_39.UseVisualStyleBackColor = true;
		checkBox_40.AutoSize = true;
		checkBox_40.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular);
		checkBox_40.ForeColor = SystemColors.ControlText;
		checkBox_40.Location = new Point(10, 142);
		checkBox_40.Name = Class16.smethod_0(1649206500);
		checkBox_40.Size = new Size(85, 19);
		checkBox_40.TabIndex = 5;
		checkBox_40.Text = Class16.smethod_0(1649206517);
		checkBox_40.UseVisualStyleBackColor = true;
		groupBox_4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_4.Controls.Add(label_25);
		groupBox_4.Controls.Add(radioButton_6);
		groupBox_4.Controls.Add(radioButton_7);
		groupBox_4.Controls.Add(label_26);
		groupBox_4.Controls.Add(label_27);
		groupBox_4.Controls.Add(trackBar_13);
		groupBox_4.ForeColor = SystemColors.ControlText;
		groupBox_4.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Bold);
		groupBox_4.Location = new Point(4, 180);
		groupBox_4.Name = Class16.smethod_0(1649206532);
		groupBox_4.Size = new Size(270, 108);
		groupBox_4.TabIndex = 1;
		groupBox_4.TabStop = false;
		groupBox_4.Text = Class16.smethod_0(1649085247);
		label_25.AutoSize = true;
		label_25.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular);
		label_25.ForeColor = SystemColors.ControlText;
		label_25.Location = new Point(8, 20);
		label_25.Name = Class16.smethod_0(1649206550);
		label_25.Size = new Size(93, 15);
		label_25.TabIndex = 6;
		label_25.Text = Class16.smethod_0(1649206562);
		radioButton_6.AutoSize = true;
		radioButton_6.Checked = true;
		radioButton_6.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular);
		radioButton_6.ForeColor = SystemColors.ControlText;
		radioButton_6.Location = new Point(8, 38);
		radioButton_6.Name = Class16.smethod_0(1649206589);
		radioButton_6.Size = new Size(60, 19);
		radioButton_6.TabIndex = 7;
		radioButton_6.TabStop = true;
		radioButton_6.Text = Class16.smethod_0(1649206601);
		radioButton_6.UseVisualStyleBackColor = true;
		radioButton_7.AutoSize = true;
		radioButton_7.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular);
		radioButton_7.ForeColor = SystemColors.ControlText;
		radioButton_7.Location = new Point(80, 38);
		radioButton_7.Name = Class16.smethod_0(1649206620);
		radioButton_7.Size = new Size(57, 19);
		radioButton_7.TabIndex = 8;
		radioButton_7.Text = Class16.smethod_0(1648924120);
		radioButton_7.UseVisualStyleBackColor = true;
		label_26.AutoSize = true;
		label_26.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular);
		label_26.ForeColor = SystemColors.ControlText;
		label_26.Location = new Point(8, 62);
		label_26.Name = Class16.smethod_0(1649206632);
		label_26.Size = new Size(28, 15);
		label_26.TabIndex = 9;
		label_26.Text = Class16.smethod_0(1648941238);
		label_27.AutoSize = true;
		label_27.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular);
		label_27.ForeColor = SystemColors.ControlText;
		label_27.Location = new Point(222, 62);
		label_27.Name = Class16.smethod_0(1649206650);
		label_27.Size = new Size(40, 15);
		label_27.TabIndex = 10;
		label_27.Text = Class16.smethod_0(1648915231);
		trackBar_13.Location = new Point(6, 78);
		trackBar_13.Maximum = 100;
		trackBar_13.Name = Class16.smethod_0(1649206678);
		trackBar_13.Size = new Size(256, 25);
		trackBar_13.TabIndex = 11;
		trackBar_13.TickFrequency = 10;
		trackBar_13.TickStyle = TickStyle.None;
		groupBox_5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_5.Controls.Add(label_28);
		groupBox_5.Controls.Add(trackBar_14);
		groupBox_5.Controls.Add(label_29);
		groupBox_5.Controls.Add(trackBar_15);
		groupBox_5.Controls.Add(label_30);
		groupBox_5.Controls.Add(trackBar_16);
		groupBox_5.ForeColor = SystemColors.ControlText;
		groupBox_5.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Bold);
		groupBox_5.Location = new Point(4, 294);
		groupBox_5.Name = Class16.smethod_0(1649206688);
		groupBox_5.Size = new Size(270, 178);
		groupBox_5.TabIndex = 2;
		groupBox_5.TabStop = false;
		groupBox_5.Text = Class16.smethod_0(1649206704);
		label_28.AutoSize = true;
		label_28.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular);
		label_28.ForeColor = SystemColors.ControlText;
		label_28.Location = new Point(8, 20);
		label_28.Name = Class16.smethod_0(1649206728);
		label_28.Size = new Size(87, 15);
		label_28.TabIndex = 12;
		label_28.Text = Class16.smethod_0(1649206757);
		trackBar_14.Location = new Point(6, 36);
		trackBar_14.Maximum = 100;
		trackBar_14.Minimum = 1;
		trackBar_14.Name = Class16.smethod_0(1649206768);
		trackBar_14.Size = new Size(256, 25);
		trackBar_14.TabIndex = 13;
		trackBar_14.TickFrequency = 10;
		trackBar_14.TickStyle = TickStyle.None;
		trackBar_14.Value = 20;
		label_29.AutoSize = true;
		label_29.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular);
		label_29.ForeColor = SystemColors.ControlText;
		label_29.Location = new Point(8, 66);
		label_29.Name = Class16.smethod_0(1649205773);
		label_29.Size = new Size(82, 15);
		label_29.TabIndex = 14;
		label_29.Text = Class16.smethod_0(1649205786);
		trackBar_15.Location = new Point(6, 82);
		trackBar_15.Maximum = 14;
		trackBar_15.Minimum = 1;
		trackBar_15.Name = Class16.smethod_0(1649205813);
		trackBar_15.Size = new Size(256, 25);
		trackBar_15.TabIndex = 15;
		trackBar_15.TickFrequency = 1;
		trackBar_15.TickStyle = TickStyle.None;
		trackBar_15.Value = 4;
		label_30.AutoSize = true;
		label_30.Font = new Font(Class16.smethod_0(1648942905), 8.25f, FontStyle.Regular);
		label_30.ForeColor = SystemColors.ControlText;
		label_30.Location = new Point(8, 112);
		label_30.Name = Class16.smethod_0(1649205826);
		label_30.Size = new Size(98, 15);
		label_30.TabIndex = 16;
		label_30.Text = Class16.smethod_0(1649205850);
		trackBar_16.Location = new Point(6, 128);
		trackBar_16.Maximum = 19;
		trackBar_16.Minimum = 1;
		trackBar_16.Name = Class16.smethod_0(1649205872);
		trackBar_16.Size = new Size(256, 25);
		trackBar_16.TabIndex = 17;
		trackBar_16.TickFrequency = 2;
		trackBar_16.TickStyle = TickStyle.None;
		trackBar_16.Value = 8;
		tabControl_5.Controls.Add(tabPage_9);
		tabControl_5.Controls.Add(tabPage_10);
		tabControl_5.Controls.Add(tabPage_11);
		tabControl_5.Location = new Point(4, 478);
		tabControl_5.Name = Class16.smethod_0(1649205896);
		tabControl_5.SelectedIndex = 0;
		tabControl_5.Size = new Size(270, 236);
		tabControl_5.TabIndex = 18;
		tabPage_9.Controls.Add(pictureBox_7);
		tabPage_9.Name = Class16.smethod_0(1649205913);
		tabPage_9.Padding = new Padding(0);
		tabPage_9.Size = new Size(262, 207);
		tabPage_9.TabIndex = 0;
		tabPage_9.Text = Class16.smethod_0(1649205935);
		tabPage_9.UseVisualStyleBackColor = true;
		tabPage_10.Controls.Add(pictureBox_8);
		tabPage_10.Name = Class16.smethod_0(1649205938);
		tabPage_10.Padding = new Padding(0);
		tabPage_10.Size = new Size(262, 207);
		tabPage_10.TabIndex = 1;
		tabPage_10.Text = Class16.smethod_0(1649084638);
		tabPage_10.UseVisualStyleBackColor = true;
		tabPage_11.Controls.Add(pictureBox_9);
		tabPage_11.Name = Class16.smethod_0(1649205965);
		tabPage_11.Padding = new Padding(0);
		tabPage_11.Size = new Size(262, 207);
		tabPage_11.TabIndex = 2;
		tabPage_11.Text = Class16.smethod_0(1649084655);
		tabPage_11.UseVisualStyleBackColor = true;
		pictureBox_7.BackColor = Color.FromArgb(70, 70, 70);
		pictureBox_7.Dock = DockStyle.Fill;
		pictureBox_7.Name = Class16.smethod_0(1649205978);
		pictureBox_7.Size = new Size(262, 207);
		pictureBox_7.SizeMode = PictureBoxSizeMode.Zoom;
		pictureBox_7.TabIndex = 0;
		pictureBox_7.TabStop = false;
		pictureBox_8.BackColor = SystemColors.Control;
		pictureBox_8.Dock = DockStyle.Fill;
		pictureBox_8.Name = Class16.smethod_0(1649205995);
		pictureBox_8.Size = new Size(262, 207);
		pictureBox_8.SizeMode = PictureBoxSizeMode.Zoom;
		pictureBox_8.TabIndex = 0;
		pictureBox_8.TabStop = false;
		pictureBox_9.BackColor = SystemColors.Control;
		pictureBox_9.Dock = DockStyle.Fill;
		pictureBox_9.Name = Class16.smethod_0(1649206022);
		pictureBox_9.Size = new Size(262, 207);
		pictureBox_9.SizeMode = PictureBoxSizeMode.Zoom;
		pictureBox_9.TabIndex = 0;
		pictureBox_9.TabStop = false;
		button_45.FlatStyle = FlatStyle.Flat;
		button_45.ForeColor = SystemColors.ControlText;
		button_45.Location = new Point(4, 720);
		button_45.Name = Class16.smethod_0(1649206035);
		button_45.Size = new Size(132, 30);
		button_45.TabIndex = 19;
		button_45.Text = Class16.smethod_0(1648999133);
		button_45.UseVisualStyleBackColor = true;
		button_46.FlatStyle = FlatStyle.Flat;
		button_46.ForeColor = SystemColors.ControlText;
		button_46.Location = new Point(140, 720);
		button_46.Name = Class16.smethod_0(1649206056);
		button_46.Size = new Size(132, 30);
		button_46.TabIndex = 20;
		button_46.Text = Class16.smethod_0(1648991736);
		button_46.UseVisualStyleBackColor = true;
		panel_21.BackColor = Color.FromArgb(30, 30, 30);
		panel_21.Controls.Add(label_31);
		panel_21.Dock = DockStyle.Fill;
		panel_21.Name = Class16.smethod_0(1649206073);
		panel_21.Size = new Size(1024, 686);
		panel_21.TabIndex = 0;
		label_31.AutoSize = true;
		label_31.ForeColor = Color.Gainsboro;
		label_31.Location = new Point(12, 8);
		label_31.Name = Class16.smethod_0(1649206103);
		label_31.Size = new Size(98, 15);
		label_31.TabIndex = 0;
		label_31.Text = Class16.smethod_0(1649206115);
		panel_22.AutoScroll = true;
		panel_22.BackColor = SystemColors.Control;
		panel_22.Controls.Add(label_32);
		panel_22.Dock = DockStyle.Fill;
		panel_22.MinimumSize = new Size(280, 0);
		panel_22.Name = Class16.smethod_0(1649206137);
		panel_22.Size = new Size(306, 686);
		panel_22.TabIndex = 0;
		label_32.Dock = DockStyle.Fill;
		label_32.ForeColor = Color.DarkGray;
		label_32.Name = Class16.smethod_0(1649206152);
		label_32.Size = new Size(306, 686);
		label_32.TabIndex = 0;
		label_32.Text = Class16.smethod_0(1649206183);
		label_32.TextAlign = ContentAlignment.MiddleCenter;
		statusStrip_0.ImageScalingSize = new Size(20, 20);
		statusStrip_0.Items.AddRange(new ToolStripItem[2] { toolStripStatusLabel_6, toolStripStatusLabel_7 });
		statusStrip_0.Location = new Point(0, 745);
		statusStrip_0.Name = Class16.smethod_0(1649014497);
		statusStrip_0.Padding = new Padding(2, 0, 14, 0);
		statusStrip_0.Size = new Size(1600, 25);
		statusStrip_0.SizingGrip = true;
		statusStrip_0.TabIndex = 3;
		toolStripStatusLabel_6.Name = Class16.smethod_0(1648916149);
		toolStripStatusLabel_6.Size = new Size(52, 20);
		toolStripStatusLabel_6.Text = Class16.smethod_0(1648920624);
		toolStripStatusLabel_7.Name = Class16.smethod_0(1649206240);
		toolStripStatusLabel_7.Size = new Size(1530, 20);
		toolStripStatusLabel_7.Spring = true;
		toolStripStatusLabel_7.Text = Class16.smethod_0(1649082562);
		toolStripStatusLabel_7.TextAlign = ContentAlignment.MiddleRight;
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = SystemColors.Control;
		base.ClientSize = new Size(1600, 770);
		base.Controls.Add(splitContainer_0);
		base.Controls.Add(toolStrip_0);
		base.Controls.Add(menuStrip_0);
		base.Controls.Add(statusStrip_0);
		base.MainMenuStrip = menuStrip_0;
		MinimumSize = new Size(1024, 600);
		base.Name = Class16.smethod_0(1649206257);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1649129402);
		base.Activated += PwMapSharpDxEditorForm_Activated;
		menuStrip_0.ResumeLayout(performLayout: false);
		menuStrip_0.PerformLayout();
		toolStrip_0.ResumeLayout(performLayout: false);
		toolStrip_0.PerformLayout();
		splitContainer_0.Panel1.ResumeLayout(performLayout: false);
		splitContainer_0.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)splitContainer_0).EndInit();
		splitContainer_0.ResumeLayout(performLayout: false);
		splitContainer_1.Panel1.ResumeLayout(performLayout: false);
		splitContainer_1.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)splitContainer_1).EndInit();
		splitContainer_1.ResumeLayout(performLayout: false);
		panel_19.ResumeLayout(performLayout: false);
		panel_19.PerformLayout();
		panel_20.ResumeLayout(performLayout: false);
		panel_20.PerformLayout();
		groupBox_3.ResumeLayout(performLayout: false);
		groupBox_3.PerformLayout();
		groupBox_4.ResumeLayout(performLayout: false);
		groupBox_4.PerformLayout();
		groupBox_5.ResumeLayout(performLayout: false);
		groupBox_5.PerformLayout();
		((ISupportInitialize)trackBar_13).EndInit();
		((ISupportInitialize)trackBar_14).EndInit();
		((ISupportInitialize)trackBar_15).EndInit();
		((ISupportInitialize)trackBar_16).EndInit();
		tabControl_5.ResumeLayout(performLayout: false);
		tabPage_9.ResumeLayout(performLayout: false);
		tabPage_10.ResumeLayout(performLayout: false);
		tabPage_11.ResumeLayout(performLayout: false);
		((ISupportInitialize)pictureBox_7).EndInit();
		((ISupportInitialize)pictureBox_8).EndInit();
		((ISupportInitialize)pictureBox_9).EndInit();
		panel_21.ResumeLayout(performLayout: false);
		panel_21.PerformLayout();
		panel_22.ResumeLayout(performLayout: false);
		statusStrip_0.ResumeLayout(performLayout: false);
		statusStrip_0.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private async Task method_122()
	{
		if (bool_9)
		{
			return;
		}
		bool_9 = true;
		pwMapDebugLogger_0?.Dispose();
		pwMapDebugLogger_0 = null;
		PwMapAssetProvider.BeginLoadingSession();
		method_178(Class16.smethod_0(1649083139), Class16.smethod_0(1649083165));
		try
		{
			Class319 @class = new Class319();
			@class.string_0 = method_118();
			pwMapDebugLogger_0 = PwMapDebugLogger.Create(System.IO.Path.GetFileName(@class.string_0));
			pwMapDebugLogger_0.BeginPhase(Class16.smethod_0(1649083185));
			pwMapDebugLogger_0.Log(Class16.smethod_0(1649083214) + @class.string_0);
			pwMapFileLayout_0 = (await Task.Run((Func<PwMapFileLayout>)@class.method_0)) ?? new PwMapFileLayout();
			pwMapDebugLogger_0.LogDiscovery(pwMapFileLayout_0);
			pwMapDebugLogger_0.EndPhase();
			method_124();
			method_119();
			pwMapDebugLogger_0.BeginPhase(Class16.smethod_0(1649083226));
			await method_123(Class16.smethod_0(1649083248), method_31);
			pwMapDebugLogger_0.EndPhase();
			pwMapDebugLogger_0.BeginPhase(Class16.smethod_0(1649083281));
			await method_123(Class16.smethod_0(1649083308), method_351);
			if (pwMapTrn2File_0 != null)
			{
				pwMapDebugLogger_0.LogTerrainInfo(pwMapTrn2File_0);
			}
			else
			{
				pwMapDebugLogger_0.LogWarning(Class16.smethod_0(1649083330));
			}
			pwMapDebugLogger_0.EndPhase();
			pwMapDebugLogger_0.BeginPhase(Class16.smethod_0(1649083385));
			method_179(Class16.smethod_0(1649082384));
			await Task.Delay(5).ConfigureAwait(continueOnCapturedContext: true);
			method_353();
			method_365();
			method_64();
			pwMapDebugLogger_0.EndPhase();
			pwMapDebugLogger_0.BeginPhase(Class16.smethod_0(1649082419));
			await method_123(Class16.smethod_0(1649082442), method_260);
			pwMapDebugLogger_0.EndPhase();
			pwMapDebugLogger_0.BeginPhase(Class16.smethod_0(1649082472));
			await method_123(Class16.smethod_0(1649082488), method_343);
			pwMapDebugLogger_0.EndPhase();
			_ = Task.Run((Action)Class317.class317_0.method_6);
			method_126();
			method_49();
			method_84();
			pwMapDebugLogger_0.LogFinalSummary(list_4.Count, list_5.Count, list_6.Count, list_7.Count, list_8.Count);
			pwMapDebugLogger_0.Flush();
			if (pwMapFileLayout_0.HasMapRoot)
			{
				textBox_81.Text = pwMapFileLayout_0.MapRootPath;
				if (!string.IsNullOrWhiteSpace(pwMapFileLayout_0.MapName))
				{
					textBox_80.Text = pwMapFileLayout_0.MapName;
				}
				method_120(Class16.smethod_0(1649082515), Class16.smethod_0(1649083522) + pwMapFileLayout_0.MapName);
			}
			else
			{
				method_120(Class16.smethod_0(1649082542), Class16.smethod_0(1649082562));
			}
		}
		catch (Exception ex)
		{
			pwMapDebugLogger_0?.LogError(Class16.smethod_0(1649082588), ex);
			pwMapDebugLogger_0?.Flush();
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649082623));
			method_120(Class16.smethod_0(1649082685) + ex.Message, Class16.smethod_0(1649082709));
		}
		finally
		{
			PwMapAssetProvider.EndLoadingSession();
			method_183();
			bool_9 = false;
		}
	}

	private async Task method_123(string string_6, Action action_0)
	{
		method_179(string_6);
		await Task.Delay(10).ConfigureAwait(continueOnCapturedContext: true);
		Application.DoEvents();
		try
		{
			action_0?.Invoke();
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649082720));
			method_120(Class16.smethod_0(1649082788) + ex.Message, null);
		}
	}

	private void method_124()
	{
		listView_16.BeginUpdate();
		try
		{
			listView_16.Items.Clear();
			string text = pwMapFileLayout_0.LitmodelsFolder;
			if (string.IsNullOrWhiteSpace(text) && CommonStorage.Params != null && CommonStorage.Params.UsePck)
			{
				string text2 = string.Empty;
				string[] pckFiles = CommonStorage.Params.PckFiles;
				if (pckFiles != null)
				{
					foreach (string text3 in pckFiles)
					{
						if (!string.IsNullOrWhiteSpace(text3) && string.Equals(System.IO.Path.GetFileName(text3), Class16.smethod_0(1649205270), StringComparison.OrdinalIgnoreCase) && File.Exists(text3))
						{
							text2 = text3;
							break;
						}
					}
				}
				if (string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(CommonStorage.Params.ModelsPckPath) && File.Exists(CommonStorage.Params.ModelsPckPath))
				{
					text2 = CommonStorage.Params.ModelsPckPath;
				}
				if (!string.IsNullOrWhiteSpace(text2))
				{
					text = text2 + Class16.smethod_0(1649205282);
				}
			}
			method_125(Class16.smethod_0(1649090247), pwMapFileLayout_0.RegionFile);
			method_125(Class16.smethod_0(1649090256), pwMapFileLayout_0.PrecinctFile);
			method_125(Class16.smethod_0(1648908925), pwMapFileLayout_0.PathDataFile);
			method_125(Class16.smethod_0(1648997579), pwMapFileLayout_0.DynamicObjectsFile);
			method_125(Class16.smethod_0(1648906386), pwMapFileLayout_0.Domain2File);
			method_125(Class16.smethod_0(1649205303), pwMapFileLayout_0.WorldFile);
			method_125(Class16.smethod_0(1649205312), pwMapFileLayout_0.Trn2File);
			method_125(Class16.smethod_0(1649205323), pwMapFileLayout_0.EcwldFile);
			method_125(Class16.smethod_0(1649205343), pwMapFileLayout_0.EcbsdFile);
			method_125(Class16.smethod_0(1649093786), text);
			method_125(Class16.smethod_0(1649090275), pwMapFileLayout_0.BsdataFolder);
		}
		finally
		{
			listView_16.EndUpdate();
		}
	}

	private void method_125(string string_6, string string_7)
	{
		ListViewItem listViewItem = new ListViewItem(string_6 ?? string.Empty);
		listViewItem.SubItems.Add(string.IsNullOrWhiteSpace(string_7) ? Class16.smethod_0(1649088100) : string_7);
		listView_16.Items.Add(listViewItem);
	}

	private void method_126()
	{
		listBox_0.BeginUpdate();
		try
		{
			listBox_0.Items.Clear();
			if (!method_306())
			{
				method_173(null);
				return;
			}
			HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			if (pwMapFileLayout_0.TextureFiles != null)
			{
				for (int i = 0; i < pwMapFileLayout_0.TextureFiles.Count; i++)
				{
					string text = pwMapFileLayout_0.TextureFiles[i];
					if (!string.IsNullOrWhiteSpace(text) && hashSet.Add(text))
					{
						listBox_0.Items.Add(new Class302(text));
					}
				}
			}
			if (pwMapTrn2File_0?.DdsFiles == null)
			{
				return;
			}
			for (int j = 0; j < pwMapTrn2File_0.DdsFiles.Count; j++)
			{
				string text2 = method_288(pwMapTrn2File_0.DdsFiles[j], string.Empty);
				if (!string.IsNullOrWhiteSpace(text2) && hashSet.Add(text2))
				{
					listBox_0.Items.Add(new Class302(text2));
				}
			}
		}
		finally
		{
			listBox_0.EndUpdate();
		}
	}

	private void method_127()
	{
		if (!File.Exists(pwMapFileLayout_0.RegionFile))
		{
			DKBox.Show(this, Class16.smethod_0(1649205347), Class16.smethod_0(1649008172), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		RegionEditorForm regionEditorForm = new RegionEditorForm();
		regionEditorForm.LoadRegionFile(pwMapFileLayout_0.RegionFile);
		regionEditorForm.Show(this);
	}

	private void method_128()
	{
		if (!File.Exists(pwMapFileLayout_0.PrecinctFile))
		{
			DKBox.Show(this, Class16.smethod_0(1649205399), Class16.smethod_0(1649008172), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		PrecinctEditorForm precinctEditorForm = new PrecinctEditorForm();
		precinctEditorForm.LoadPrecinctFile(pwMapFileLayout_0.PrecinctFile);
		precinctEditorForm.Show(this);
	}

	private void method_129()
	{
		if (!File.Exists(pwMapFileLayout_0.PathDataFile))
		{
			DKBox.Show(this, Class16.smethod_0(1649205445), Class16.smethod_0(1649008172), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		try
		{
			if (pathEditor_0 == null)
			{
				pathEditor_0 = new PathEditor(commonStorage_0);
			}
			pathEditor_0.PathData = new PATH_DATA(pwMapFileLayout_0.PathDataFile);
			pathEditor_0.currentID = -1;
			if (pathEditor_0.Visible)
			{
				pathEditor_0.BringToFront();
			}
			else
			{
				pathEditor_0.Show(this);
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649205480));
			DKBox.Show(this, ex.Message, Class16.smethod_0(1649205543), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_130()
	{
		if (!File.Exists(pwMapFileLayout_0.DynamicObjectsFile))
		{
			DKBox.Show(this, Class16.smethod_0(1649205553), Class16.smethod_0(1649008172), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		if (dynamicObjectsEditorForm_0 == null)
		{
			dynamicObjectsEditorForm_0 = new DynamicObjectsEditorForm(commonStorage_0);
		}
		dynamicObjectsEditorForm_0.OpenFile(pwMapFileLayout_0.DynamicObjectsFile);
		if (dynamicObjectsEditorForm_0.Visible)
		{
			dynamicObjectsEditorForm_0.BringToFront();
		}
		else
		{
			dynamicObjectsEditorForm_0.Show(this);
		}
	}

	private void method_131()
	{
		bool_6 = true;
		try
		{
			pwMapPreferencesStore_0.Load();
			PwMapGeneralSettings settings = pwMapPreferencesStore_0.Settings;
			PwMapCameraSettings cameraSettings = pwMapPreferencesStore_0.CameraSettings;
			textBox_77.Text = settings.WorkingPath ?? string.Empty;
			textBox_78.Text = settings.ElementPath ?? string.Empty;
			textBox_79.Text = settings.ServerPath ?? string.Empty;
			textBox_80.Text = settings.CurrentMap ?? string.Empty;
			string text = method_118();
			textBox_81.Text = text;
			if (settings.Width > 0 && settings.Height > 0)
			{
				base.Size = new Size(settings.Width, settings.Height);
			}
			if (settings.PositionX >= 0 && settings.PositionY >= 0)
			{
				base.StartPosition = FormStartPosition.Manual;
				base.Location = new Point(settings.PositionX, settings.PositionY);
			}
			if (settings.LeftSplit > 0.05f && settings.LeftSplit < 0.95f)
			{
				method_113().SplitterDistance = (int)((float)method_113().Width * settings.LeftSplit);
			}
			checkBox_33.Checked = cameraSettings.ShowGrid;
			checkBox_34.Checked = cameraSettings.ShowAxes;
			checkBox_28.Checked = cameraSettings.ShowTerrainLayer;
			checkBox_29.Checked = cameraSettings.ShowRegionLayer;
			checkBox_30.Checked = cameraSettings.ShowPrecinctLayer;
			checkBox_31.Checked = cameraSettings.ShowTransportLayer;
			checkBox_32.Checked = cameraSettings.ShowNpcLayer;
			bool_7 = cameraSettings.ShowTerrainWire;
			bool_8 = cameraSettings.ShowObjectsWire;
			method_297(cameraSettings);
			method_201(cameraSettings);
		}
		finally
		{
			bool_6 = false;
		}
		method_172();
	}

	private bool method_132()
	{
		PwMapGeneralSettings settings = pwMapPreferencesStore_0.Settings;
		PwMapCameraSettings cameraSettings = pwMapPreferencesStore_0.CameraSettings;
		settings.WorkingPath = (textBox_77.Text ?? string.Empty).Trim();
		settings.ElementPath = (textBox_78.Text ?? string.Empty).Trim();
		settings.ServerPath = (textBox_79.Text ?? string.Empty).Trim();
		settings.CurrentMap = (textBox_80.Text ?? string.Empty).Trim();
		settings.LeftSplit = ((method_113().Width <= 0) ? settings.LeftSplit : ((float)method_113().SplitterDistance / (float)method_113().Width));
		settings.Width = base.Width;
		settings.Height = base.Height;
		settings.PositionX = base.Left;
		settings.PositionY = base.Top;
		cameraSettings.ShowGrid = checkBox_33.Checked;
		cameraSettings.ShowAxes = checkBox_34.Checked;
		cameraSettings.ShowTerrainLayer = checkBox_28.Checked;
		cameraSettings.ShowRegionLayer = checkBox_29.Checked;
		cameraSettings.ShowPrecinctLayer = checkBox_30.Checked;
		cameraSettings.ShowTransportLayer = checkBox_31.Checked;
		cameraSettings.ShowNpcLayer = checkBox_32.Checked;
		cameraSettings.ShowTerrainWire = bool_7;
		cameraSettings.ShowObjectsWire = bool_8;
		method_298(cameraSettings);
		method_202(cameraSettings);
		method_5();
		bool flag = pwMapPreferencesStore_0.Save();
		method_120(flag ? Class16.smethod_0(1649084538) : Class16.smethod_0(1649205614), null);
		return flag;
	}

	private void PwMapSharpDxEditorForm_Activated(object sender, EventArgs e)
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_PwMapSharpDxEditorForm != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this);
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_PwMapSharpDxEditorForm = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}

	private List<Class314> method_133(Enum20 enum20_0)
	{
		return enum20_0 switch
		{
			Enum20.WaterArea => list_5, 
			Enum20.FloraMarker => list_6, 
			Enum20.LightMarker => list_8, 
			Enum20.GfxMarker => list_7, 
			_ => list_4, 
		};
	}

	private bool method_134(Class301 class301_2)
	{
		if (class301_2 == null)
		{
			return false;
		}
		if (class301_2.enum20_0 != Enum20.LitModelObject && class301_2.enum20_0 != Enum20.FloraMarker && class301_2.enum20_0 != Enum20.WaterArea && class301_2.enum20_0 != Enum20.LightMarker)
		{
			return class301_2.enum20_0 == Enum20.GfxMarker;
		}
		return true;
	}

	private void method_135()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		PwMapAddObjectDialog pwMapAddObjectDialog = new PwMapAddObjectDialog();
		try
		{
			if (pwMapAddObjectDialog.ShowDialog(this) == DialogResult.OK && !string.IsNullOrWhiteSpace(pwMapAddObjectDialog.SelectedResource))
			{
				string selectedResource = pwMapAddObjectDialog.SelectedResource;
				Vector3 val = vector3_2;
				Class314 @class = new Class314
				{
					string_0 = System.IO.Path.GetFileNameWithoutExtension(selectedResource),
					string_1 = selectedResource,
					vector3_0 = val,
					vector3_1 = new Vector3(2f, 2f, 2f)
				};
				SceneObjectSnapshot snapshot = @class.method_0();
				List<ISceneObjectList> targetLists = new List<ISceneObjectList>
				{
					new Class303(list_4)
				};
				list_4.Add(@class);
				method_139();
				pwMapChangeLog_0?.Push(new PwMapAddObjectChange(targetLists, snapshot, method_139));
				method_120(Class16.smethod_0(1649205640) + @class.string_0, null);
			}
		}
		finally
		{
			((IDisposable)pwMapAddObjectDialog).Dispose();
		}
	}

	private void method_136()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = vector3_2 + new Vector3(0f, 8f, 0f);
		if (sceneLightCollection_0 == null)
		{
			sceneLightCollection_0 = new PwMapSceneLightFile.SceneLightCollection();
		}
		PwMapSceneLightFile.SceneLight item = new PwMapSceneLightFile.SceneLight
		{
			Location = new Vector3(val.X, val.Y, 0f - val.Z),
			Range = 15f,
			Attenuation = 1f,
			Attenuation2 = 0.02f,
			Attenuation3 = 0f,
			Diffuse = new Vector4(1f, 1f, 0.85f, 1f),
			Ambient = new Vector4(0.1f, 0.1f, 0.1f, 1f),
			Flags = 2,
			Type = 1,
			Version = sceneLightCollection_0.Version
		};
		sceneLightCollection_0.Lights.Add(item);
		method_276();
		method_261();
		method_120(Class16.smethod_0(1649205662) + val.X.ToString(Class16.smethod_0(1648952888)) + Class16.smethod_0(1648928028) + val.Y.ToString(Class16.smethod_0(1648952888)) + Class16.smethod_0(1648928028) + val.Z.ToString(Class16.smethod_0(1648952888)), null);
	}

	private void method_137()
	{
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		if (list_10.Count == 0 && class301_1 != null)
		{
			list_10.Add(class301_1);
		}
		if (list_10.Count == 0)
		{
			return;
		}
		Vector3 val = default(Vector3);
		val = new Vector3(2f, 0f, 2f);
		List<SceneObjectSnapshot> list = new List<SceneObjectSnapshot>();
		List<ISceneObjectList> list2 = new List<ISceneObjectList>();
		HashSet<List<Class314>> hashSet = new HashSet<List<Class314>>();
		for (int i = 0; i < list_10.Count; i++)
		{
			Class301 @class = list_10[i];
			if (method_134(@class))
			{
				List<Class314> list3 = method_133(@class.enum20_0);
				Class314 class2 = new Class314
				{
					string_0 = @class.string_0 + Class16.smethod_0(1649205684),
					string_1 = (@class.string_1 ?? string.Empty),
					vector3_0 = @class.vector3_1 + val,
					vector3_1 = @class.vector3_2,
					vector3_2 = (@class.class314_0?.vector3_2 ?? Vector3.Zero),
					vector3_3 = (Vector3)(((Vector3?)@class.class314_0?.vector3_3) ?? new Vector3(1f, 1f, 1f))
				};
				list3.Add(class2);
				list.Add(class2.method_0());
				if (hashSet.Add(list3))
				{
					list2.Add(new Class303(list3));
				}
			}
		}
		if (list.Count != 0)
		{
			method_139();
			pwMapChangeLog_0?.Push(new PwMapCloneObjectChange(list2, list.ToArray(), method_139));
			method_120(Class16.smethod_0(1649205689) + list.Count + Class16.smethod_0(1649093154), null);
		}
	}

	private void method_138()
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		if (list_10.Count == 0 && class301_1 != null)
		{
			list_10.Add(class301_1);
		}
		if (list_10.Count == 0)
		{
			return;
		}
		List<SceneObjectSnapshot> list = new List<SceneObjectSnapshot>();
		List<ISceneObjectList> list2 = new List<ISceneObjectList>();
		HashSet<List<Class314>> hashSet = new HashSet<List<Class314>>();
		foreach (Class301 item in list_10)
		{
			if (!method_134(item))
			{
				continue;
			}
			List<Class314> list3 = method_133(item.enum20_0);
			int num = list3.Count - 1;
			while (num >= 0)
			{
				Class314 @class = list3[num];
				if (!string.Equals(@class.string_0, item.string_0, StringComparison.OrdinalIgnoreCase) || Vector3.DistanceSquared(@class.vector3_0, item.vector3_1) >= 1f)
				{
					num--;
					continue;
				}
				list.Add(@class.method_0());
				list3.RemoveAt(num);
				if (hashSet.Add(list3))
				{
					list2.Add(new Class303(list3));
				}
				break;
			}
		}
		method_319(bool_37: false);
		method_139();
		if (list.Count > 0)
		{
			pwMapChangeLog_0?.Push(new PwMapDeleteObjectChange(list2, list.ToArray(), method_139));
		}
		method_120(Class16.smethod_0(1649205711) + list.Count + Class16.smethod_0(1649093154), null);
	}

	private void method_139()
	{
		method_261();
		method_140();
	}

	private void method_140()
	{
		if (listView_11 == null)
		{
			return;
		}
		listView_11.BeginUpdate();
		listView_11.Items.Clear();
		foreach (Class301 item in list_10)
		{
			ListViewItem listViewItem = new ListViewItem(item.string_0);
			listViewItem.SubItems.Add(string.Format(Class16.smethod_0(1649094136), item.vector3_1.X, item.vector3_1.Y, item.vector3_1.Z));
			listViewItem.Tag = item;
			listView_11.Items.Add(listViewItem);
		}
		listView_11.EndUpdate();
	}

	private void method_141()
	{
		string text = method_147();
		string text2 = method_146();
		string text3 = System.IO.Path.Combine(text2, Class16.smethod_0(1649205726), Class16.smethod_0(1649094124), text);
		Directory.CreateDirectory(text3);
		int num = 0;
		int int_ = 0;
		num = 0 + smethod_9(pwMapFileLayout_0.WorldFile, text3, ref int_);
		num += smethod_9(pwMapFileLayout_0.PathDataFile, text3, ref int_);
		num += smethod_9(pwMapFileLayout_0.DynamicObjectsFile, text3, ref int_);
		num += smethod_9(pwMapFileLayout_0.Domain2File, text3, ref int_);
		if (pwMapTrn2File_0 != null && pwMapTrn2File_0.MapSectors.Count > 0)
		{
			for (int i = 0; i < pwMapTrn2File_0.MapSectors.Count; i++)
			{
				string text4 = pwMapTrn2File_0.MapSectors[i];
				if (!string.IsNullOrWhiteSpace(text4))
				{
					string string_ = System.IO.Path.Combine(pwMapTrn2File_0.MapRootPath, text4 + Class16.smethod_0(1649205731));
					string string_2 = System.IO.Path.Combine(pwMapTrn2File_0.MapRootPath, text4 + Class16.smethod_0(1649205751));
					string string_3 = System.IO.Path.Combine(pwMapTrn2File_0.MapRootPath, text4 + Class16.smethod_0(1649205755));
					string string_4 = System.IO.Path.Combine(pwMapTrn2File_0.MapRootPath, text4 + Class16.smethod_0(1649208847));
					num += smethod_9(string_, text3, ref int_);
					num += smethod_9(string_2, text3, ref int_);
					num += smethod_9(string_3, text3, ref int_);
					num += smethod_9(string_4, text3, ref int_);
				}
			}
			string string_5 = System.IO.Path.Combine(pwMapTrn2File_0.MapRootPath, text + Class16.smethod_0(1649093324));
			string string_6 = System.IO.Path.Combine(pwMapTrn2File_0.MapRootPath, text + Class16.smethod_0(1649093329));
			num += smethod_9(string_5, text3, ref int_);
			num += smethod_9(string_6, text3, ref int_);
		}
		if (regionFile_0 != null)
		{
			regionFile_0.SaveFile(System.IO.Path.Combine(text3, Class16.smethod_0(1649090247)), both: true, PutToData: false);
		}
		else
		{
			num += smethod_9(pwMapFileLayout_0.RegionFile, text3, ref int_);
		}
		if (precinctFile_0 != null)
		{
			precinctFile_0.SaveFile(System.IO.Path.Combine(text3, Class16.smethod_0(1649090256)), both: true, PutToData: false);
		}
		else
		{
			num += smethod_9(pwMapFileLayout_0.PrecinctFile, text3, ref int_);
		}
		int num2 = method_142(text2);
		var (num3, num4) = method_144(text2, text);
		method_120(Class16.smethod_0(1649208860), Class16.smethod_0(1649083522) + text);
		DKBox.Show(this, Class16.smethod_0(1649208883) + text3 + Class16.smethod_0(1648924428) + string.Format(Class16.smethod_0(1649208921), num) + string.Format(Class16.smethod_0(1649208959), num2) + string.Format(Class16.smethod_0(1649208989), num3) + string.Format(Class16.smethod_0(1649209012), num4) + string.Format(Class16.smethod_0(1649209038), int_), Class16.smethod_0(1649209064), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private int method_142(string string_6)
	{
		if (pwMapTrn2File_0 != null && pwMapTrn2File_0.DdsFiles.Count != 0)
		{
			int num = 0;
			for (int i = 0; i < pwMapTrn2File_0.DdsFiles.Count; i++)
			{
				string text = (pwMapTrn2File_0.DdsFiles[i] ?? string.Empty).Replace('\\', '/').Trim();
				if (!string.IsNullOrWhiteSpace(text))
				{
					string text2 = method_143(text);
					if (!string.IsNullOrWhiteSpace(text2) && File.Exists(text2))
					{
						string text3 = System.IO.Path.Combine(string_6, Class16.smethod_0(1649205726), text.Replace('/', System.IO.Path.DirectorySeparatorChar));
						Directory.CreateDirectory(System.IO.Path.GetDirectoryName(text3) ?? string.Empty);
						File.Copy(text2, text3, overwrite: true);
						num++;
					}
				}
			}
			return num;
		}
		return 0;
	}

	private string method_143(string string_6)
	{
		if (System.IO.Path.IsPathRooted(string_6) && File.Exists(string_6))
		{
			return string_6;
		}
		string text = string_6.Replace('/', System.IO.Path.DirectorySeparatorChar);
		string[] array = new string[3]
		{
			System.IO.Path.Combine(pwMapFileLayout_0.MapRootPath ?? string.Empty, text),
			System.IO.Path.Combine((textBox_78.Text ?? string.Empty).Trim(), text),
			System.IO.Path.Combine((textBox_78.Text ?? string.Empty).Trim(), Class16.smethod_0(1649094124), method_147(), text)
		};
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				if (File.Exists(array[num]))
				{
					break;
				}
				num++;
				continue;
			}
			return string.Empty;
		}
		return array[num];
	}

	private (int, int) method_144(string string_6, string string_7)
	{
		int num = 0;
		int num2 = 0;
		string path = System.IO.Path.Combine(string_6, Class16.smethod_0(1649205726));
		List<string> list = method_145();
		for (int i = 0; i < list.Count; i++)
		{
			string text = System.IO.Path.Combine(list[i], Class16.smethod_0(1649093786), string_7);
			if (Directory.Exists(text))
			{
				string string_8 = System.IO.Path.Combine(path, Class16.smethod_0(1649093786), string_7);
				num = smethod_8(text, string_8);
				if (num > 0)
				{
					break;
				}
			}
		}
		if (pwMapTrn2File_0 != null && Directory.Exists(pwMapTrn2File_0.MapRootPath))
		{
			string text2 = System.IO.Path.Combine(pwMapTrn2File_0.MapRootPath, Class16.smethod_0(1649090275));
			if (Directory.Exists(text2))
			{
				string string_9 = System.IO.Path.Combine(path, Class16.smethod_0(1649094124), string_7, Class16.smethod_0(1649090275));
				num2 += smethod_8(text2, string_9);
			}
		}
		return (num, num2);
	}

	private List<string> method_145()
	{
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		if (!string.IsNullOrWhiteSpace(pwMapFileLayout_0?.MapRootPath) && Directory.Exists(pwMapFileLayout_0.MapRootPath))
		{
			hashSet.Add(pwMapFileLayout_0.MapRootPath);
			DirectoryInfo directoryInfo = new DirectoryInfo(pwMapFileLayout_0.MapRootPath);
			if (string.Equals(directoryInfo.Parent?.Name, Class16.smethod_0(1649094124), StringComparison.OrdinalIgnoreCase) && directoryInfo.Parent?.Parent != null)
			{
				hashSet.Add(directoryInfo.Parent.Parent.FullName);
			}
		}
		string text = (textBox_78.Text ?? string.Empty).Trim();
		if (!string.IsNullOrWhiteSpace(text) && Directory.Exists(text))
		{
			hashSet.Add(text);
		}
		return hashSet.ToList();
	}

	private static int smethod_8(string string_6, string string_7)
	{
		if (!string.IsNullOrWhiteSpace(string_6) && !string.IsNullOrWhiteSpace(string_7) && Directory.Exists(string_6))
		{
			int num = 0;
			{
				foreach (string item in Directory.EnumerateFiles(string_6, Class16.smethod_0(1648889151), SearchOption.AllDirectories))
				{
					string path = item.Substring(string_6.Length).TrimStart('\\', '/');
					string text = System.IO.Path.Combine(string_7, path);
					Directory.CreateDirectory(System.IO.Path.GetDirectoryName(text) ?? string.Empty);
					File.Copy(item, text, overwrite: true);
					num++;
				}
				return num;
			}
		}
		return 0;
	}

	private static int smethod_9(string string_6, string string_7, ref int int_40)
	{
		if (string.IsNullOrWhiteSpace(string_6))
		{
			return 0;
		}
		try
		{
			if (!File.Exists(string_6))
			{
				int_40++;
				return 0;
			}
			Directory.CreateDirectory(string_7);
			string destFileName = System.IO.Path.Combine(string_7, System.IO.Path.GetFileName(string_6));
			File.Copy(string_6, destFileName, overwrite: true);
			return 1;
		}
		catch
		{
			int_40++;
			return 0;
		}
	}

	private string method_146()
	{
		string text = (textBox_77.Text ?? string.Empty).Trim();
		if (string.IsNullOrWhiteSpace(text))
		{
			text = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1649209092));
		}
		Directory.CreateDirectory(text);
		return text;
	}

	private string method_147()
	{
		string text = (textBox_80.Text ?? string.Empty).Trim();
		object obj;
		if (string.IsNullOrWhiteSpace(text))
		{
			PwMapTrn2File pwMapTrn2File = pwMapTrn2File_0;
			if (pwMapTrn2File == null)
			{
				obj = null;
			}
			else
			{
				obj = pwMapTrn2File.MapName;
				if (obj != null)
				{
					goto IL_003d;
				}
			}
			obj = string.Empty;
			goto IL_003d;
		}
		goto IL_0043;
		IL_0043:
		object obj2;
		if (string.IsNullOrWhiteSpace(text))
		{
			PwMapFileLayout pwMapFileLayout = pwMapFileLayout_0;
			if (pwMapFileLayout == null)
			{
				obj2 = null;
			}
			else
			{
				obj2 = pwMapFileLayout.MapName;
				if (obj2 != null)
				{
					goto IL_0066;
				}
			}
			obj2 = string.Empty;
			goto IL_0066;
		}
		goto IL_006c;
		IL_0066:
		text = ((string)obj2).Trim();
		goto IL_006c;
		IL_003d:
		text = ((string)obj).Trim();
		goto IL_0043;
		IL_006c:
		if (string.IsNullOrWhiteSpace(text))
		{
			text = Class16.smethod_0(1649209111);
		}
		return text;
	}

	private (int, int) method_148(string string_6, PwMapTrn2File pwMapTrn2File_1, bool bool_37)
	{
		if (pwMapTrn2File_1 != null && pwMapTrn2File_1.TotalSectors > 0)
		{
			string text = System.IO.Path.Combine(string_6, Class16.smethod_0(1649082922));
			Directory.CreateDirectory(text);
			string string_7 = System.IO.Path.Combine(method_146(), method_147(), Class16.smethod_0(1649082922));
			int int_ = smethod_11(pwMapTrn2File_1);
			int int_2 = Math.Max(1, (int)(pwMapTrn2File_1.Width / (float)pwMapTrn2File_1.SectorsWide));
			int int_3 = Math.Max(1, (int)(pwMapTrn2File_1.Height / (float)pwMapTrn2File_1.SectorsHigh));
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = pwMapTrn2File_1.TotalSectors;
			if (bool_37)
			{
				int num5 = method_150(pwMapTrn2File_1);
				if (num5 >= 0 && num5 < pwMapTrn2File_1.TotalSectors)
				{
					num3 = num5;
					num4 = num5 + 1;
				}
			}
			for (int i = num3; i < num4; i++)
			{
				try
				{
					method_149(i, int_, int_2, int_3, pwMapTrn2File_1, text, string_7);
					num++;
				}
				catch
				{
					num2++;
				}
			}
			smethod_10(text, pwMapTrn2File_1);
			return (num, num2);
		}
		return (0, 0);
	}

	private static void smethod_10(string string_6, PwMapTrn2File pwMapTrn2File_1)
	{
		string path = System.IO.Path.Combine(string_6, Class16.smethod_0(1649209121));
		int num = Math.Max(1, (int)(pwMapTrn2File_1.Width / (float)pwMapTrn2File_1.SectorsWide));
		int num2 = Math.Max(1, (int)(pwMapTrn2File_1.Height / (float)pwMapTrn2File_1.SectorsHigh));
		StreamWriter streamWriter = new StreamWriter(path, append: false, Encoding.ASCII);
		try
		{
			streamWriter.WriteLine(Class16.smethod_0(1649209148) + pwMapTrn2File_1.SectorsWide);
			streamWriter.WriteLine(Class16.smethod_0(1649209167) + pwMapTrn2File_1.SectorsHigh);
			streamWriter.WriteLine(Class16.smethod_0(1649209179) + num);
			streamWriter.WriteLine(Class16.smethod_0(1649209201) + num2);
			streamWriter.WriteLine(Class16.smethod_0(1649209224));
		}
		finally
		{
			((IDisposable)streamWriter).Dispose();
		}
	}

	private void method_149(int int_40, int int_41, int int_42, int int_43, PwMapTrn2File pwMapTrn2File_1, string string_6, string string_7)
	{
		string text = (int_40 + 1).ToString();
		string destFileName = System.IO.Path.Combine(string_6, text + Class16.smethod_0(1649209255));
		string destFileName2 = System.IO.Path.Combine(string_6, text + Class16.smethod_0(1649090203));
		string text2 = System.IO.Path.Combine(string_7, text + Class16.smethod_0(1649209255));
		string text3 = System.IO.Path.Combine(string_7, text + Class16.smethod_0(1649090203));
		if (File.Exists(text2) && File.Exists(text3))
		{
			File.Copy(text2, destFileName, overwrite: true);
			File.Copy(text3, destFileName2, overwrite: true);
		}
		else
		{
			PwMapPassMapProfile pwMapPassMapProfile_ = pwMapPassMapProfile_0 ?? new PwMapPassMapProfile();
			method_188(int_40, int_41, int_42, int_43, pwMapTrn2File_1, pwMapPassMapProfile_, string_6);
		}
	}

	private static int smethod_11(PwMapTrn2File pwMapTrn2File_1)
	{
		return pwMapTrn2File_1.SubTrnGrid * (int)pwMapTrn2File_1.GridSize;
	}

	private int method_150(PwMapTrn2File pwMapTrn2File_1)
	{
		if (pwMapTrn2File_1 != null && pwMapTrn2File_1.SectorsWide > 0 && pwMapTrn2File_1.SectorsHigh > 0)
		{
			float num = pwMapTrn2File_1.Width / (float)pwMapTrn2File_1.SectorsWide;
			float num2 = pwMapTrn2File_1.Height / (float)pwMapTrn2File_1.SectorsHigh;
			float num3 = vector3_2.X + pwMapTrn2File_1.Width * 0.5f;
			float num4 = pwMapTrn2File_1.Height * 0.5f - vector3_2.Z;
			int num5 = Math.Max(0, Math.Min(pwMapTrn2File_1.SectorsWide - 1, (int)(num3 / num)));
			int num6 = Math.Max(0, Math.Min(pwMapTrn2File_1.SectorsHigh - 1, (int)(num4 / num2)));
			return num6 * pwMapTrn2File_1.SectorsWide + num5;
		}
		return 0;
	}

	private static (int, int) smethod_12(string string_6, PwMapTrn2File pwMapTrn2File_1, string string_7, bool bool_37, int int_40)
	{
		if (pwMapTrn2File_1 != null && pwMapTrn2File_1.TotalSectors > 0)
		{
			string text = System.IO.Path.Combine(string_6, Class16.smethod_0(1649209268));
			Directory.CreateDirectory(text);
			string text2 = System.IO.Path.Combine(string_7, Class16.smethod_0(1649082922));
			if (!Directory.Exists(text2))
			{
				string path = System.IO.Path.GetDirectoryName(string_7) ?? string_7;
				text2 = System.IO.Path.Combine(path, Class16.smethod_0(1649082922));
			}
			string string_8 = System.IO.Path.Combine(string_6, Class16.smethod_0(1649082922));
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = pwMapTrn2File_1.TotalSectors;
			if (bool_37)
			{
				num3 = Math.Max(0, Math.Min(pwMapTrn2File_1.TotalSectors - 1, int_40));
				num4 = num3 + 1;
			}
			for (int i = num3; i < num4; i++)
			{
				string text3 = (i + 1).ToString();
				string destFileName = System.IO.Path.Combine(text, text3 + Class16.smethod_0(1649209255));
				string destFileName2 = System.IO.Path.Combine(text, text3 + Class16.smethod_0(1649090203));
				try
				{
					bool flag = false;
					string text4 = smethod_13(text2, string_8, text3 + Class16.smethod_0(1649209255));
					string text5 = smethod_13(text2, string_8, text3 + Class16.smethod_0(1649090203));
					if (text4 != null)
					{
						File.Copy(text4, destFileName, overwrite: true);
						flag = true;
					}
					if (text5 != null)
					{
						File.Copy(text5, destFileName2, overwrite: true);
						flag = true;
					}
					if (flag)
					{
						num++;
					}
					else
					{
						num2++;
					}
				}
				catch
				{
					num2++;
				}
			}
			return (num, num2);
		}
		return (0, 0);
	}

	private static string smethod_13(string string_6, string string_7, string string_8)
	{
		string text = System.IO.Path.Combine(string_6, string_8);
		if (File.Exists(text))
		{
			return text;
		}
		text = System.IO.Path.Combine(string_7, string_8);
		if (File.Exists(text))
		{
			return text;
		}
		return null;
	}

	private int method_151(string string_6, PwMapTrn2File pwMapTrn2File_1, out int int_40)
	{
		int_40 = 0;
		if (pwMapTrn2File_1 != null && pwMapTrn2File_1.TotalSectors > 0 && pwMapTrn2File_1.SectorsWide > 0 && pwMapTrn2File_1.SectorsHigh > 0)
		{
			string text = System.IO.Path.Combine(string_6, Class16.smethod_0(1649209272));
			Directory.CreateDirectory(text);
			Dictionary<int, string> dictionary_ = method_153(pwMapTrn2File_1);
			float num = pwMapTrn2File_1.Width / (float)pwMapTrn2File_1.SectorsWide;
			float length = pwMapTrn2File_1.Height / (float)pwMapTrn2File_1.SectorsHigh;
			int num2 = 0;
			for (int i = 0; i < pwMapTrn2File_1.TotalSectors; i++)
			{
				try
				{
					List<PwMapWmapFile.WaterArea> areas = method_152(i, pwMapTrn2File_1, dictionary_);
					string filePath = System.IO.Path.Combine(text, i + 1 + Class16.smethod_0(1649090199));
					PwMapWmapFile.Save(filePath, num, length, areas);
					num2++;
				}
				catch
				{
					int_40++;
				}
			}
			return num2;
		}
		return 0;
	}

	private List<PwMapWmapFile.WaterArea> method_152(int int_40, PwMapTrn2File pwMapTrn2File_1, Dictionary<int, string> dictionary_7)
	{
		List<PwMapWmapFile.WaterArea> list = new List<PwMapWmapFile.WaterArea>();
		if (dictionary_7.TryGetValue(int_40, out var value) && File.Exists(value))
		{
			PwMapBsdataFile pwMapBsdataFile = PwMapBsdataFile.Load(value);
			if (pwMapBsdataFile?.WaterBlocks != null && pwMapBsdataFile.WaterBlocks.Count != 0)
			{
				smethod_16(pwMapTrn2File_1, int_40, out var float_, out var float_2);
				for (int i = 0; i < pwMapBsdataFile.WaterBlocks.Count; i++)
				{
					PwMapBsdataFile.WaterBlockEntry waterBlockEntry = pwMapBsdataFile.WaterBlocks[i];
					list.Add(new PwMapWmapFile.WaterArea
					{
						CenterX = waterBlockEntry.WorldX - float_,
						CenterZ = waterBlockEntry.WorldZ - float_2,
						ExtentX = Math.Max(0f, (float)waterBlockEntry.Width * waterBlockEntry.GridSize * 0.5f),
						ExtentZ = Math.Max(0f, (float)waterBlockEntry.Height * waterBlockEntry.GridSize * 0.5f),
						Height = waterBlockEntry.WorldY
					});
				}
				return list;
			}
			return list;
		}
		return list;
	}

	private Dictionary<int, string> method_153(PwMapTrn2File pwMapTrn2File_1)
	{
		Class316 @class = new Class316();
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		List<string> list = smethod_14(pwMapTrn2File_1.MapRootPath);
		if (list.Count == 0)
		{
			return dictionary;
		}
		@class.string_0 = pwMapTrn2File_1.MapSectors.Select(Class317.class317_0.method_7).ToArray();
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		@class.int_0 = 0;
		while (@class.int_0 < @class.string_0.Length)
		{
			if (!string.IsNullOrWhiteSpace(@class.string_0[@class.int_0]))
			{
				string text = list.FirstOrDefault(@class.method_0);
				if (!string.IsNullOrWhiteSpace(text))
				{
					dictionary[@class.int_0] = text;
					hashSet.Add(text);
				}
			}
			@class.int_0++;
		}
		for (int i = 0; i < list.Count; i++)
		{
			string text2 = list[i];
			if (!hashSet.Contains(text2) && smethod_15(text2, pwMapTrn2File_1.TotalSectors, out var int_) && !dictionary.ContainsKey(int_))
			{
				dictionary[int_] = text2;
				hashSet.Add(text2);
			}
		}
		List<int> list2 = new List<int>();
		for (int j = 0; j < pwMapTrn2File_1.TotalSectors; j++)
		{
			if (!dictionary.ContainsKey(j))
			{
				list2.Add(j);
			}
		}
		foreach (string item in list)
		{
			if (list2.Count != 0 && !hashSet.Contains(item))
			{
				int key = list2[0];
				list2.RemoveAt(0);
				dictionary[key] = item;
				hashSet.Add(item);
			}
		}
		return dictionary;
	}

	private static List<string> smethod_14(string string_6)
	{
		List<string> list = new List<string>();
		if (!string.IsNullOrWhiteSpace(string_6) && Directory.Exists(string_6))
		{
			string path = System.IO.Path.Combine(string_6, Class16.smethod_0(1649090275));
			if (!Directory.Exists(path))
			{
				path = Directory.EnumerateDirectories(string_6, Class16.smethod_0(1649090275), SearchOption.AllDirectories).FirstOrDefault() ?? string.Empty;
			}
			if (!Directory.Exists(path))
			{
				return list;
			}
			try
			{
				list.AddRange(Directory.EnumerateFiles(path, Class16.smethod_0(1649209295), SearchOption.AllDirectories));
			}
			catch
			{
			}
			list.Sort(StringComparer.OrdinalIgnoreCase);
			return list;
		}
		return list;
	}

	private static bool smethod_15(string string_6, int int_40, out int int_41)
	{
		int_41 = -1;
		string source = System.IO.Path.GetFileNameWithoutExtension(string_6) ?? string.Empty;
		string s = new string(source.Where(char.IsDigit).ToArray());
		if (!int.TryParse(s, out var result))
		{
			return false;
		}
		if (result >= 1 && result <= int_40)
		{
			int_41 = result - 1;
			return true;
		}
		if (result >= 0 && result < int_40)
		{
			int_41 = result;
			return true;
		}
		return false;
	}

	private string method_154(string string_6, PwMapTrn2File pwMapTrn2File_1, PwMapCollisionExportResolver pwMapCollisionExportResolver_0)
	{
		string text = System.IO.Path.Combine(string_6, Class16.smethod_0(1649209299));
		if (method_156(pwMapTrn2File_1.MapName, Class16.smethod_0(1649209299), text))
		{
			return Class16.smethod_0(1649209313);
		}
		try
		{
			object obj;
			if (pwMapCollisionExportResolver_0 == null)
			{
				obj = null;
			}
			else
			{
				obj = pwMapCollisionExportResolver_0.LoadAllBrushes();
				if (obj != null)
				{
					goto IL_004b;
				}
			}
			obj = new List<PwMapCollisionBrush>();
			goto IL_004b;
			IL_004b:
			List<PwMapCollisionBrush> list = (List<PwMapCollisionBrush>)obj;
			if (list.Count <= 0)
			{
				PwMapBhtFile.SaveEmpty(text, pwMapTrn2File_1.Width, pwMapTrn2File_1.Height);
				return Class16.smethod_0(1649209334);
			}
			PwMapBhtFile.Save(text, pwMapTrn2File_1.Width, pwMapTrn2File_1.Height, list);
			return string.Format(Class16.smethod_0(1649208331), list.Count);
		}
		catch
		{
			return Class16.smethod_0(1649208361);
		}
	}

	private (int, int, int) method_155(string string_6, PwMapTrn2File pwMapTrn2File_1, PwMapCollisionExportResolver pwMapCollisionExportResolver_0)
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		string text = System.IO.Path.Combine(string_6, Class16.smethod_0(1649208382));
		Directory.CreateDirectory(text);
		string mapName = pwMapTrn2File_1.MapName;
		for (int i = 0; i < pwMapTrn2File_1.TotalSectors; i++)
		{
			int octreeId = i + 1;
			string path = octreeId + Class16.smethod_0(1649208387);
			string text2 = System.IO.Path.Combine(text, path);
			if (method_156(mapName, System.IO.Path.Combine(Class16.smethod_0(1649208382), path), text2))
			{
				num++;
				continue;
			}
			try
			{
				object obj;
				if (pwMapCollisionExportResolver_0 == null)
				{
					obj = null;
				}
				else
				{
					obj = pwMapCollisionExportResolver_0.LoadSectorBrushes(i);
					if (obj != null)
					{
						goto IL_009c;
					}
				}
				obj = new List<PwMapCollisionBrush>();
				goto IL_009c;
				IL_009c:
				List<PwMapCollisionBrush> brushes = (List<PwMapCollisionBrush>)obj;
				smethod_16(pwMapTrn2File_1, i, out var float_, out var float_2);
				PwMapSpacePassableOctreeBuilder.OctreeData octreeData = PwMapSpacePassableOctreeBuilder.Build(octreeId, new Vector3(float_, 512f, float_2), 512, 2, brushes);
				PwMapCompactOctreeFile.Save(text2, octreeData.OctreeId, octreeData.CenterX, octreeData.CenterY, octreeData.CenterZ, octreeData.HalfSize, octreeData.LeafNodeSize, octreeData.Nodes);
				num2++;
			}
			catch
			{
				num3++;
			}
		}
		return (num, num2, num3);
	}

	private bool method_156(string string_6, string string_7, string string_8)
	{
		string text = (textBox_79.Text ?? string.Empty).Trim();
		if (string.IsNullOrWhiteSpace(text))
		{
			return false;
		}
		string[] array = new string[2]
		{
			System.IO.Path.Combine(text, Class16.smethod_0(1649083486), string_6, string_7),
			System.IO.Path.Combine(text, Class16.smethod_0(1649083466), Class16.smethod_0(1649083486), string_6, string_7)
		};
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				if (File.Exists(array[num]))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		Directory.CreateDirectory(System.IO.Path.GetDirectoryName(string_8) ?? string.Empty);
		File.Copy(array[num], string_8, overwrite: true);
		return true;
	}

	private static void smethod_16(PwMapTrn2File pwMapTrn2File_1, int int_40, out float float_14, out float float_15)
	{
		float num = (0f - pwMapTrn2File_1.Width) * 0.5f;
		float num2 = pwMapTrn2File_1.Height * 0.5f;
		float num3 = pwMapTrn2File_1.Width / (float)pwMapTrn2File_1.SectorsWide;
		float num4 = pwMapTrn2File_1.Height / (float)pwMapTrn2File_1.SectorsHigh;
		int num5 = int_40 / pwMapTrn2File_1.SectorsWide;
		int num6 = int_40 % pwMapTrn2File_1.SectorsWide;
		float_14 = num + (float)num6 * num3 + num3 * 0.5f;
		float_15 = num2 - (float)num5 * num4 - num4 * 0.5f;
	}

	private async void method_157()
	{
		Class304 @class = new Class304
		{
			pwMapSharpDxEditorForm_0 = this
		};
		if (bool_10)
		{
			return;
		}
		if (pwMapTrn2File_0 == null)
		{
			method_350();
		}
		if (pwMapTrn2File_0 != null)
		{
			using (PwMapExportServerDialog pwMapExportServerDialog = new PwMapExportServerDialog())
			{
				if (pwMapExportServerDialog.ShowDialog(this) == DialogResult.OK)
				{
					@class.string_1 = method_147();
					string text = method_146();
					@class.string_0 = System.IO.Path.Combine(text, Class16.smethod_0(1649137666), Class16.smethod_0(1649083466), Class16.smethod_0(1649083486), @class.string_1);
					Directory.CreateDirectory(@class.string_0);
					bool_10 = true;
					method_87(0, bool_37: true);
					method_120(Class16.smethod_0(1649083491), Class16.smethod_0(1649083522) + @class.string_1);
					@class.pwMapTrn2File_0 = pwMapTrn2File_0;
					@class.regionFile_0 = regionFile_0;
					@class.precinctFile_0 = precinctFile_0;
					@class.string_3 = (textBox_78.Text ?? string.Empty).Trim();
					@class.string_2 = @class.pwMapTrn2File_0.MapRootPath;
					@class.bool_7 = pwMapExportServerDialog.ExportPassmap;
					@class.bool_8 = pwMapExportServerDialog.ExportCurrentSectorOnly;
					@class.bool_0 = pwMapExportServerDialog.ExportHmap;
					@class.bool_4 = pwMapExportServerDialog.ExportWmap;
					@class.bool_5 = pwMapExportServerDialog.ExportBht;
					@class.bool_6 = pwMapExportServerDialog.ExportAirmap;
					@class.bool_1 = pwMapExportServerDialog.ExportRegion;
					@class.bool_2 = pwMapExportServerDialog.ExportPrecinct;
					@class.bool_3 = pwMapExportServerDialog.ExportWaterConf;
					@class.bool_9 = pwMapExportServerDialog.ExportDhmap;
					Class310 class2 = await Task.Run((Func<Class310>)@class.method_0);
					bool_10 = false;
					method_87(0, bool_37: false);
					method_120(Class16.smethod_0(1649083542), Class16.smethod_0(1649083522) + @class.string_1);
					StringBuilder stringBuilder = new StringBuilder(Class16.smethod_0(1649083573));
					stringBuilder.AppendLine();
					stringBuilder.AppendLine(Class16.smethod_0(1649083595) + @class.string_0);
					if (@class.bool_0)
					{
						stringBuilder.AppendLine(string.Format(Class16.smethod_0(1649083608), class2.int_0, class2.int_1));
					}
					if (@class.bool_4)
					{
						stringBuilder.AppendLine(string.Format(Class16.smethod_0(1649083646), class2.int_2, class2.int_3));
					}
					if (@class.bool_5)
					{
						stringBuilder.AppendLine(Class16.smethod_0(1649083676) + class2.string_0);
					}
					if (@class.bool_6)
					{
						stringBuilder.AppendLine(string.Format(Class16.smethod_0(1649083680), class2.int_4, class2.int_5, class2.int_6));
					}
					if (@class.bool_1)
					{
						stringBuilder.AppendLine(Class16.smethod_0(1649083732) + (class2.bool_0 ? Class16.smethod_0(1649019761) : Class16.smethod_0(1649083751)));
					}
					if (@class.bool_2)
					{
						stringBuilder.AppendLine(Class16.smethod_0(1649083767) + (class2.bool_1 ? Class16.smethod_0(1649019761) : Class16.smethod_0(1649083751)));
					}
					if (@class.bool_3)
					{
						stringBuilder.AppendLine(Class16.smethod_0(1649083788) + (class2.bool_2 ? Class16.smethod_0(1649019761) : Class16.smethod_0(1649083802)));
					}
					if (@class.bool_7)
					{
						stringBuilder.AppendLine(string.Format(Class16.smethod_0(1649083821), class2.int_7, class2.int_8));
					}
					if (@class.bool_9)
					{
						stringBuilder.AppendLine(string.Format(Class16.smethod_0(1649083854), class2.int_9, class2.int_10));
					}
					DKBox.Show(this, stringBuilder.ToString(), Class16.smethod_0(1649083454), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				return;
			}
		}
		DKBox.Show(this, Class16.smethod_0(1649083405), Class16.smethod_0(1649083454), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	private void method_158(int int_40, string string_6)
	{
		Class306 @class = new Class306();
		@class.pwMapSharpDxEditorForm_0 = this;
		@class.int_0 = int_40;
		@class.string_0 = string_6;
		if (!base.IsDisposed && !base.Disposing)
		{
			try
			{
				BeginInvoke(new Action(@class.method_0));
			}
			catch
			{
			}
		}
	}

	private static bool smethod_17(string string_6, RegionFile regionFile_1)
	{
		try
		{
			if (regionFile_1 == null)
			{
				return false;
			}
			string path = System.IO.Path.Combine(string_6, Class16.smethod_0(1649090247));
			return regionFile_1.SaveFile(path, both: false, PutToData: false);
		}
		catch
		{
			return false;
		}
	}

	private static bool smethod_18(string string_6, PrecinctFile precinctFile_1)
	{
		try
		{
			if (precinctFile_1 == null)
			{
				return false;
			}
			string path = System.IO.Path.Combine(string_6, Class16.smethod_0(1649090256));
			return precinctFile_1.SaveFile(path, both: false, PutToData: false);
		}
		catch
		{
			return false;
		}
	}

	private int method_159(string string_6, PwMapTrn2File pwMapTrn2File_1, out int int_40)
	{
		int_40 = 0;
		if (pwMapTrn2File_1 != null && pwMapTrn2File_1.TotalSectors > 0 && pwMapTrn2File_1.SectorsWide > 0 && pwMapTrn2File_1.SectorsHigh > 0)
		{
			int int_41 = Math.Max(1, (int)(pwMapTrn2File_1.Width / (float)pwMapTrn2File_1.SectorsWide));
			int int_42 = Math.Max(1, (int)(pwMapTrn2File_1.Height / (float)pwMapTrn2File_1.SectorsHigh));
			string text = System.IO.Path.Combine(string_6, Class16.smethod_0(1649208407));
			Directory.CreateDirectory(text);
			int num = 0;
			for (int i = 0; i < pwMapTrn2File_1.TotalSectors; i++)
			{
				try
				{
					PwMapT2bkFile pwMapT2bkFile = method_363(i, int_41, int_42);
					if (pwMapT2bkFile == null)
					{
						int_40++;
						continue;
					}
					float[] array = pwMapT2bkFile.BuildSectorHeightMap();
					if (array != null && array.Length != 0)
					{
						float num2 = 0f;
						if (i >= 0 && i < pwMapTrn2File_1.SectorHeights.Count)
						{
							num2 = Math.Abs(pwMapTrn2File_1.SectorHeights[i].Max);
						}
						if (num2 <= 0.0001f)
						{
							for (int j = 0; j < array.Length; j++)
							{
								float num3 = Math.Abs(array[j]);
								if (num3 > num2)
								{
									num2 = num3;
								}
							}
						}
						if (num2 <= 0.0001f)
						{
							num2 = 1f;
						}
						string string_7 = System.IO.Path.Combine(text, i + 1 + Class16.smethod_0(1649208409));
						smethod_19(string_7, array, num2);
						num++;
					}
					else
					{
						int_40++;
					}
				}
				catch
				{
					int_40++;
				}
			}
			return num;
		}
		return 0;
	}

	private static void smethod_19(string string_6, float[] float_14, float float_15)
	{
		Directory.CreateDirectory(System.IO.Path.GetDirectoryName(string_6) ?? string.Empty);
		FileStream fileStream = new FileStream(string_6, FileMode.Create, FileAccess.Write, FileShare.Read);
		try
		{
			BinaryWriter binaryWriter = new BinaryWriter(fileStream);
			try
			{
				float num = ((float_15 <= 0.0001f) ? 0f : (1f / float_15));
				for (int i = 0; i < float_14.Length; i++)
				{
					binaryWriter.Write(float_14[i] * num);
				}
			}
			finally
			{
				((IDisposable)binaryWriter).Dispose();
			}
		}
		finally
		{
			((IDisposable)fileStream).Dispose();
		}
	}

	private bool method_160(string string_6, PwMapTrn2File pwMapTrn2File_1)
	{
		try
		{
			string text = System.IO.Path.Combine(string_6, Class16.smethod_0(1649209272));
			Directory.CreateDirectory(text);
			string path = System.IO.Path.Combine(text, Class16.smethod_0(1649090050));
			StreamWriter streamWriter = new StreamWriter(path, append: false, Encoding.ASCII);
			try
			{
				streamWriter.WriteLine(Class16.smethod_0(1649209148) + pwMapTrn2File_1.SectorsWide);
				streamWriter.WriteLine(Class16.smethod_0(1649209167) + pwMapTrn2File_1.SectorsHigh);
				streamWriter.WriteLine(Class16.smethod_0(1649209179) + (pwMapTrn2File_1.Width / (float)pwMapTrn2File_1.SectorsWide).ToString(Class16.smethod_0(1648979502), CultureInfo.InvariantCulture));
				streamWriter.WriteLine(Class16.smethod_0(1649209201) + (pwMapTrn2File_1.Height / (float)pwMapTrn2File_1.SectorsHigh).ToString(Class16.smethod_0(1648979502), CultureInfo.InvariantCulture));
				return true;
			}
			finally
			{
				((IDisposable)streamWriter).Dispose();
			}
		}
		catch
		{
			return false;
		}
	}

	private bool method_161(string string_6)
	{
		return smethod_17(string_6, regionFile_0);
	}

	private bool method_162(string string_6)
	{
		return smethod_18(string_6, precinctFile_0);
	}

	private void method_163(object sender, EventArgs e)
	{
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
		try
		{
			folderBrowserDialog.Description = TextStorage.Msg(Class16.smethod_0(1649208429), Class16.smethod_0(1649208456));
			folderBrowserDialog.SelectedPath = (Directory.Exists(textBox_81.Text) ? textBox_81.Text : Application.StartupPath);
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				textBox_81.Text = folderBrowserDialog.SelectedPath;
				textBox_80.Text = new DirectoryInfo(folderBrowserDialog.SelectedPath).Name;
				method_120(Class16.smethod_0(1649208493), null);
			}
		}
		finally
		{
			((IDisposable)folderBrowserDialog).Dispose();
		}
	}

	private async void button_38_Click(object sender, EventArgs e)
	{
		await method_122();
	}

	private void method_164(object sender, EventArgs e)
	{
		method_132();
	}

	private void method_165(object sender, EventArgs e)
	{
		method_214();
	}

	private void method_166(object sender, EventArgs e)
	{
		Close();
	}

	private void method_167(object sender, EventArgs e)
	{
		method_175(textBox_77, Class16.smethod_0(1649208544));
	}

	private void method_168(object sender, EventArgs e)
	{
		method_175(textBox_78, Class16.smethod_0(1649208570));
	}

	private void method_169(object sender, EventArgs e)
	{
		method_175(textBox_79, Class16.smethod_0(1649208604));
	}

	private void method_170(object sender, EventArgs e)
	{
		method_175(textBox_81, Class16.smethod_0(1649208629));
	}

	private async void button_39_Click(object sender, EventArgs e)
	{
		await method_122();
	}

	private void button_40_Click(object sender, EventArgs e)
	{
		method_127();
	}

	private void button_41_Click(object sender, EventArgs e)
	{
		method_128();
	}

	private void button_42_Click(object sender, EventArgs e)
	{
		method_129();
	}

	private void button_43_Click(object sender, EventArgs e)
	{
		method_130();
	}

	private void button_44_Click(object sender, EventArgs e)
	{
		if (commonStorage_0 == null)
		{
			DKBox.Show(this, Class16.smethod_0(1649208643), Class16.smethod_0(1649008333), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		if (File.Exists(pwMapFileLayout_0.Domain2File))
		{
			CommonStorage.CmdFlags.domain2FN = pwMapFileLayout_0.Domain2File;
		}
		new Domain2Editor(commonStorage_0).Show(this);
	}

	private void toolStripButton_8_Click(object sender, EventArgs e)
	{
		method_171();
		if (!bool_6)
		{
			method_225();
		}
	}

	private void toolStripButton_7_Click(object sender, EventArgs e)
	{
		method_171();
		if (!bool_6)
		{
			method_353();
		}
	}

	private void toolStripButton_9_Click(object sender, EventArgs e)
	{
		method_171();
		if (!bool_6)
		{
			method_225();
		}
	}

	private void toolStripButton_10_Click(object sender, EventArgs e)
	{
		method_171();
		if (!bool_6)
		{
			method_32();
		}
	}

	private void toolStripButton_11_Click(object sender, EventArgs e)
	{
		method_171();
		if (!bool_6)
		{
			method_32();
		}
	}

	private void toolStripButton_12_Click(object sender, EventArgs e)
	{
		method_171();
		if (!bool_6)
		{
			method_32();
		}
	}

	private void toolStripButton_13_Click(object sender, EventArgs e)
	{
		method_171();
		if (!bool_6)
		{
			method_32();
		}
	}

	private void checkBox_33_CheckedChanged(object sender, EventArgs e)
	{
		method_172();
		if (!bool_6)
		{
			method_225();
		}
	}

	private void checkBox_28_CheckedChanged(object sender, EventArgs e)
	{
		method_172();
		if (!bool_6)
		{
			method_353();
		}
	}

	private void checkBox_34_CheckedChanged(object sender, EventArgs e)
	{
		method_172();
		if (!bool_6)
		{
			method_225();
		}
	}

	private void checkBox_29_CheckedChanged(object sender, EventArgs e)
	{
		method_172();
		if (!bool_6)
		{
			method_32();
		}
	}

	private void checkBox_30_CheckedChanged(object sender, EventArgs e)
	{
		method_172();
		if (!bool_6)
		{
			method_32();
		}
	}

	private void checkBox_31_CheckedChanged(object sender, EventArgs e)
	{
		method_172();
		if (!bool_6)
		{
			method_32();
		}
	}

	private void checkBox_32_CheckedChanged(object sender, EventArgs e)
	{
		method_172();
		if (!bool_6)
		{
			method_32();
		}
	}

	private void method_171()
	{
		if (bool_11)
		{
			return;
		}
		bool_11 = true;
		try
		{
			checkBox_28.Checked = toolStripButton_7.Checked;
			checkBox_33.Checked = toolStripButton_8.Checked;
			checkBox_34.Checked = toolStripButton_9.Checked;
			checkBox_29.Checked = toolStripButton_10.Checked;
			checkBox_30.Checked = toolStripButton_11.Checked;
			checkBox_31.Checked = toolStripButton_12.Checked;
			checkBox_32.Checked = toolStripButton_13.Checked;
		}
		finally
		{
			bool_11 = false;
		}
	}

	private void method_172()
	{
		if (bool_11)
		{
			return;
		}
		bool_11 = true;
		try
		{
			toolStripButton_7.Checked = checkBox_28.Checked;
			toolStripButton_8.Checked = checkBox_33.Checked;
			toolStripButton_9.Checked = checkBox_34.Checked;
			toolStripButton_10.Checked = checkBox_29.Checked;
			toolStripButton_11.Checked = checkBox_30.Checked;
			toolStripButton_12.Checked = checkBox_31.Checked;
			toolStripButton_13.Checked = checkBox_32.Checked;
		}
		finally
		{
			bool_11 = false;
		}
	}

	private void listBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (listBox_0.SelectedItem is Class302 @class && !string.IsNullOrWhiteSpace(@class.method_0()))
		{
			method_173(@class.method_0());
		}
		else
		{
			method_173(null);
		}
	}

	private void method_173(string string_6)
	{
		method_174();
		if (string.IsNullOrWhiteSpace(string_6))
		{
			pictureBox_6.Image = null;
			return;
		}
		try
		{
			string text = System.IO.Path.GetExtension(string_6).ToLowerInvariant();
			if (!File.Exists(string_6))
			{
				byte[] array = PwMapAssetProvider.ReadPckBytes(string_6);
				if (array != null && array.Length != 0)
				{
					if (text == Class16.smethod_0(1648904847))
					{
						DDSImage dDSImage = new DDSImage(array);
						try
						{
							if (dDSImage.IsValid && dDSImage.BitmapImage != null)
							{
								bitmap_3 = new Bitmap(dDSImage.BitmapImage);
							}
						}
						finally
						{
							((IDisposable)dDSImage).Dispose();
						}
					}
					else
					{
						MemoryStream memoryStream = new MemoryStream(array, writable: false);
						try
						{
							using Image original = Image.FromStream(memoryStream, useEmbeddedColorManagement: false, validateImageData: false);
							bitmap_3 = new Bitmap(original);
						}
						finally
						{
							((IDisposable)memoryStream).Dispose();
						}
					}
					pictureBox_6.Image = bitmap_3;
				}
				else
				{
					pictureBox_6.Image = null;
				}
				return;
			}
			if (text == Class16.smethod_0(1648904847))
			{
				bitmap_3 = DdsLoader.Load(string_6);
			}
			else
			{
				FileStream fileStream = new FileStream(string_6, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				try
				{
					using Image original2 = Image.FromStream(fileStream, useEmbeddedColorManagement: false, validateImageData: false);
					bitmap_3 = new Bitmap(original2);
				}
				finally
				{
					((IDisposable)fileStream).Dispose();
				}
			}
			pictureBox_6.Image = bitmap_3;
		}
		catch
		{
			pictureBox_6.Image = null;
		}
	}

	private void method_174()
	{
		if (bitmap_3 != null)
		{
			pictureBox_6.Image = null;
			bitmap_3.Dispose();
			bitmap_3 = null;
		}
	}

	private void method_175(TextBox textBox_135, string string_6)
	{
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
		try
		{
			folderBrowserDialog.Description = string_6;
			folderBrowserDialog.SelectedPath = (Directory.Exists(textBox_135.Text) ? textBox_135.Text : Application.StartupPath);
			if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				textBox_135.Text = folderBrowserDialog.SelectedPath;
			}
		}
		finally
		{
			((IDisposable)folderBrowserDialog).Dispose();
		}
	}

	private void PwMapSharpDxEditorForm_Shown(object sender, EventArgs e)
	{
		method_172();
		method_212();
	}

	private void PwMapSharpDxEditorForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		method_132();
		method_219();
		method_174();
		method_315();
		if (pathEditor_0 != null && !pathEditor_0.IsDisposed)
		{
			try
			{
				pathEditor_0.Dispose();
			}
			catch
			{
			}
		}
		if (dynamicObjectsEditorForm_0 != null && !dynamicObjectsEditorForm_0.IsDisposed)
		{
			try
			{
				dynamicObjectsEditorForm_0.Dispose();
			}
			catch
			{
			}
		}
	}

	private void method_176()
	{
		if (panel_23 == null && panel_21 != null && !panel_21.IsDisposed)
		{
			panel_23 = new Panel
			{
				Dock = DockStyle.Fill,
				BackColor = Color.FromArgb(38, 38, 42),
				Visible = false
			};
			panel_24 = new Panel
			{
				Size = new Size(360, 110),
				BackColor = Color.FromArgb(28, 28, 31),
				BorderStyle = BorderStyle.FixedSingle
			};
			label_33 = new Label
			{
				AutoSize = false,
				Location = new Point(14, 12),
				Size = new Size(330, 24),
				Text = Class16.smethod_0(1649083139),
				TextAlign = ContentAlignment.MiddleLeft
			};
			label_34 = new Label
			{
				AutoSize = false,
				Location = new Point(14, 40),
				Size = new Size(330, 24),
				Text = Class16.smethod_0(1649208681),
				TextAlign = ContentAlignment.MiddleLeft
			};
			progressBar_0 = new ProgressBar
			{
				Location = new Point(14, 72),
				Size = new Size(330, 20),
				Style = ProgressBarStyle.Marquee,
				MarqueeAnimationSpeed = 28
			};
			panel_24.Controls.Add(label_33);
			panel_24.Controls.Add(label_34);
			panel_24.Controls.Add(progressBar_0);
			panel_23.Controls.Add(panel_24);
			panel_23.Resize += panel_23_Resize;
			panel_21.Controls.Add(panel_23);
			method_177();
		}
	}

	private void method_177()
	{
		if (panel_23 != null && panel_24 != null)
		{
			int num = Math.Max(12, (panel_23.ClientSize.Width - panel_24.Width) / 2);
			int num2 = Math.Max(12, (panel_23.ClientSize.Height - panel_24.Height) / 2);
			panel_24.Location = new Point(num, num2);
		}
	}

	private void method_178(string string_6, string string_7)
	{
		if (base.IsDisposed)
		{
			return;
		}
		method_176();
		int_2++;
		method_180(string_6, string_7);
		if (int_2 <= 1 && panel_23 != null)
		{
			panel_23.Visible = true;
			panel_23.BringToFront();
			base.UseWaitCursor = true;
			if (button_39 != null)
			{
				button_39.Enabled = false;
			}
			if (button_38 != null)
			{
				button_38.Enabled = false;
			}
			panel_23.Refresh();
			Application.DoEvents();
		}
	}

	private void method_179(string string_6)
	{
		method_180(null, string_6);
	}

	private void method_180(string string_6, string string_7)
	{
		if (panel_23 != null)
		{
			if (!string.IsNullOrWhiteSpace(string_6))
			{
				label_33.Text = string_6;
			}
			if (!string.IsNullOrWhiteSpace(string_7))
			{
				label_34.Text = string_7;
			}
		}
	}

	private void method_181(int int_40, int int_41)
	{
		if (progressBar_0 != null)
		{
			if (progressBar_0.Style != ProgressBarStyle.Blocks)
			{
				progressBar_0.Style = ProgressBarStyle.Blocks;
				progressBar_0.MarqueeAnimationSpeed = 0;
			}
			progressBar_0.Maximum = Math.Max(1, int_41);
			progressBar_0.Value = Math.Min(Math.Max(0, int_40), progressBar_0.Maximum);
		}
	}

	private void method_182()
	{
		if (progressBar_0 != null)
		{
			progressBar_0.Style = ProgressBarStyle.Marquee;
			progressBar_0.MarqueeAnimationSpeed = 28;
		}
	}

	private void method_183()
	{
		if (int_2 <= 0)
		{
			return;
		}
		int_2--;
		if (int_2 <= 0)
		{
			if (panel_23 != null)
			{
				panel_23.Visible = false;
			}
			base.UseWaitCursor = false;
			if (button_39 != null)
			{
				button_39.Enabled = true;
			}
			if (button_38 != null)
			{
				button_38.Enabled = true;
			}
		}
	}

	private void method_184()
	{
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		List<(string, int, string, float, float, float)> list = new List<(string, int, string, float, float, float)>();
		for (int i = 0; i < list_9.Count; i++)
		{
			Class301 @class = list_9[i];
			string item = @class.enum20_0 switch
			{
				Enum20.RegionPolygon => Class16.smethod_0(1649211232), 
				Enum20.PrecinctPolygon => Class16.smethod_0(1649211086), 
				Enum20.TransportBox => Class16.smethod_0(1649208735), 
				Enum20.CityMarker => Class16.smethod_0(1649208751), 
				Enum20.NpcMarker => Class16.smethod_0(1649007040), 
				Enum20.LitModelObject => Class16.smethod_0(1649208708), 
				Enum20.WaterArea => Class16.smethod_0(1648976466), 
				Enum20.FloraMarker => Class16.smethod_0(1649208715), 
				Enum20.LightMarker => Class16.smethod_0(1648900812), 
				_ => Class16.smethod_0(1649030255), 
			};
			list.Add((@class.string_0, i, item, @class.vector3_1.X, @class.vector3_1.Y, @class.vector3_1.Z));
		}
		PwMapObjectSearchDialog pwMapObjectSearchDialog = new PwMapObjectSearchDialog(list);
		try
		{
			if (pwMapObjectSearchDialog.ShowDialog(this) == DialogResult.OK)
			{
				int selectedObjectIndex = pwMapObjectSearchDialog.SelectedObjectIndex;
				if (selectedObjectIndex >= 0 && selectedObjectIndex < list_9.Count)
				{
					Class301 class2 = list_9[selectedObjectIndex];
					method_319(bool_37: false);
					class301_1 = class2;
					list_10.Add(class2);
					vector3_2 = class2.vector3_1;
					float num = Math.Max(class2.vector3_2.X, Math.Max(class2.vector3_2.Y, class2.vector3_2.Z));
					float_1 = Math.Max(20f, num * 4f);
					method_321();
					method_77();
					method_140();
					method_120(Class16.smethod_0(1649208754) + class2.string_0, null);
				}
			}
		}
		finally
		{
			((IDisposable)pwMapObjectSearchDialog).Dispose();
		}
	}

	private async void method_185()
	{
		if (pwMapTrn2File_0 != null && pwMapPassMapProfile_0 != null)
		{
			await method_187(0, pwMapTrn2File_0.TotalSectors, Class16.smethod_0(1649083882));
		}
	}

	private async void method_186()
	{
		if (pwMapTrn2File_0 != null && pwMapPassMapProfile_0 != null)
		{
			int num = method_150(pwMapTrn2File_0);
			if (num < 0 || num >= pwMapTrn2File_0.TotalSectors)
			{
				label_12.Text = TextStorage.Msg(Class16.smethod_0(1649083069), Class16.smethod_0(1649083102));
			}
			else
			{
				await method_187(num, num + 1, string.Format(Class16.smethod_0(1649083122), num));
			}
		}
	}

	private async Task method_187(int int_40, int int_41, string string_6)
	{
		Class305 @class = new Class305
		{
			int_0 = int_40,
			pwMapSharpDxEditorForm_0 = this,
			int_6 = int_41,
			pwMapTrn2File_0 = pwMapTrn2File_0
		};
		if (@class.pwMapTrn2File_0 != null)
		{
			@class.pwMapPassMapProfile_0 = pwMapPassMapProfile_0;
			if (@class.pwMapPassMapProfile_0 != null)
			{
				button_14.Enabled = false;
				button_15.Enabled = false;
				label_12.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649083899), Class16.smethod_0(1649082898)), string_6);
				method_87(0, bool_37: true);
				string path = method_147();
				@class.string_0 = System.IO.Path.Combine(method_146(), path, Class16.smethod_0(1649082922));
				@class.int_1 = smethod_11(@class.pwMapTrn2File_0);
				@class.int_2 = Math.Max(1, (int)(@class.pwMapTrn2File_0.Width / (float)@class.pwMapTrn2File_0.SectorsWide));
				@class.int_3 = Math.Max(1, (int)(@class.pwMapTrn2File_0.Height / (float)@class.pwMapTrn2File_0.SectorsHigh));
				@class.int_5 = @class.int_6 - @class.int_0;
				@class.int_4 = 0;
				await Task.Run((Action)@class.method_0);
				button_14.Enabled = true;
				button_15.Enabled = true;
				method_87(0, bool_37: false);
				label_12.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649082936), Class16.smethod_0(1649082982)), string_6, @class.int_5, @class.string_0);
			}
		}
	}

	private void method_188(int int_40, int int_41, int int_42, int int_43, PwMapTrn2File pwMapTrn2File_1, PwMapPassMapProfile pwMapPassMapProfile_1, string string_6)
	{
		bool flag = int_40 < pwMapPassMapProfile_1.Sectors.Count && pwMapPassMapProfile_1.Sectors[int_40].Dungeon;
		PwMapDhmapFile pwMapDhmapFile = new PwMapDhmapFile(int_41, int_41);
		PwMapRmapFile pwMapRmapFile = new PwMapRmapFile(1, int_41, int_41);
		PwMapT2bkFile pwMapT2bkFile = method_363(int_40, int_42, int_43);
		if (pwMapT2bkFile != null)
		{
			float[] float_ = pwMapT2bkFile.BuildSectorHeightMap();
			smethod_20(pwMapDhmapFile, pwMapRmapFile, float_, int_41, flag, pwMapPassMapProfile_1.ClipAngle);
		}
		else if (!flag)
		{
			for (int i = 0; i < pwMapRmapFile.ImageData.Length; i++)
			{
				pwMapRmapFile.ImageData[i] = byte.MaxValue;
			}
		}
		string text = (int_40 + 1).ToString();
		pwMapDhmapFile.Save(System.IO.Path.Combine(string_6, text + Class16.smethod_0(1649209255)));
		pwMapRmapFile.Save(System.IO.Path.Combine(string_6, text + Class16.smethod_0(1649090203)));
	}

	private void method_189(PwMapRmapFile pwMapRmapFile_0, int int_40, int int_41, PwMapTrn2File pwMapTrn2File_1)
	{
		if (listView_4 == null || pwMapTrn2File_1 == null)
		{
			return;
		}
		int sectorsWide = pwMapTrn2File_1.SectorsWide;
		int num = ((sectorsWide > 0) ? (int_40 % sectorsWide) : 0);
		int num2 = ((sectorsWide > 0) ? (int_40 / sectorsWide) : 0);
		float num3 = pwMapTrn2File_1.Width / (float)Math.Max(1, sectorsWide);
		float num4 = pwMapTrn2File_1.Height / (float)Math.Max(1, pwMapTrn2File_1.SectorsHigh);
		float num5 = (float)num * num3 - pwMapTrn2File_1.Width * 0.5f;
		float num6 = pwMapTrn2File_1.Height * 0.5f - (float)(num2 + 1) * num4;
		foreach (ListViewItem item in listView_4.Items)
		{
			if (item.SubItems.Count < 4 || !float.TryParse(item.SubItems[0].Text, out var result) || !float.TryParse(item.SubItems[1].Text, out var result2) || !int.TryParse(item.SubItems[2].Text, out var result3))
			{
				continue;
			}
			bool passable = item.SubItems[3].Text == Class16.smethod_0(1648934925) || item.SubItems[3].Text.Equals(Class16.smethod_0(1648901259), StringComparison.OrdinalIgnoreCase);
			float num7 = result - num5;
			float num8 = result2 - num6;
			int num9 = (int)(num7 / num3 * (float)int_41);
			int num10 = (int)(num8 / num4 * (float)int_41);
			int num11 = result3 / 2;
			for (int i = -num11; i <= num11; i++)
			{
				for (int j = -num11; j <= num11; j++)
				{
					pwMapRmapFile_0.SetPixel(num9 + j, num10 + i, passable);
				}
			}
		}
	}

	private static void smethod_20(PwMapDhmapFile pwMapDhmapFile_0, PwMapRmapFile pwMapRmapFile_0, float[] float_14, int int_40, bool bool_37, float float_15)
	{
		if (float_14 == null || float_14.Length == 0)
		{
			return;
		}
		int num = (int)Math.Sqrt(float_14.Length);
		if (num <= 0)
		{
			num = 1;
		}
		float num2 = (float)Math.Cos((double)float_15 * Math.PI / 180.0);
		for (int i = 0; i < int_40; i++)
		{
			for (int j = 0; j < int_40; j++)
			{
				int num3 = Math.Min(j * num / int_40, num - 1);
				int num4 = Math.Min(i * num / int_40, num - 1);
				smethod_21(float_14, num3, num4, num);
				float num5 = smethod_21(float_14, num3 - 1, num4, num);
				float num6 = smethod_21(float_14, num3 + 1, num4, num);
				float num7 = smethod_21(float_14, num3, num4 - 1, num);
				float num8 = smethod_21(float_14, num3, num4 + 1, num);
				float num9 = num5 - num6;
				float num10 = num8 - num7;
				float num11 = 2f;
				float num12 = (float)Math.Sqrt(num9 * num9 + 4f + num10 * num10);
				float value = ((num12 > 0.0001f) ? (num11 / num12) : 1f);
				bool passable = !bool_37 && Math.Abs(value) >= num2;
				pwMapRmapFile_0.SetPixel(j, i, passable);
			}
		}
	}

	private static float smethod_21(float[] float_14, int int_40, int int_41, int int_42)
	{
		int_40 = Math.Max(0, Math.Min(int_42 - 1, int_40));
		int_41 = Math.Max(0, Math.Min(int_42 - 1, int_41));
		return float_14[int_41 * int_42 + int_40];
	}

	private void method_190()
	{
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_17 && !bool_18 && !bool_19 && !bool_20 && !bool_21 && !bool_22)
		{
			int_12 = Environment.TickCount;
			return;
		}
		int tickCount = Environment.TickCount;
		if (int_12 <= 0)
		{
			int_12 = tickCount;
			return;
		}
		int num = tickCount - int_12;
		if (num < 0)
		{
			num = 0;
		}
		float val = (float)num / 1000f;
		int_12 = tickCount;
		val = Math.Max(0f, Math.Min(0.07f, val));
		if (val <= 0f)
		{
			return;
		}
		int num2 = trackBar_0?.Value ?? 50;
		float num3 = 0.1f * (float)num2 * (float)num2 + 5f;
		float num4 = (((Control.ModifierKeys & Keys.Shift) != Keys.None) ? (num3 * 3f) : num3);
		Vector3 val2 = default(Vector3);
		val2 = new Vector3((float)Math.Cos(float_2), 0f, (float)Math.Sin(float_2));
		if (val2.LengthSquared() > 1E-06f)
		{
			val2.Normalize();
		}
		Vector3 val3 = default(Vector3);
		val3 = new Vector3(val2.Z, 0f, 0f - val2.X);
		Vector3 val4 = Vector3.Zero;
		if (bool_17)
		{
			val4 -= val2;
		}
		if (bool_18)
		{
			val4 += val2;
		}
		if (bool_20)
		{
			val4 -= val3;
		}
		if (bool_19)
		{
			val4 += val3;
		}
		if (bool_21)
		{
			val4 += Vector3.UnitY;
		}
		if (bool_22)
		{
			val4 -= Vector3.UnitY;
		}
		if (val4.LengthSquared() <= 1E-06f)
		{
			return;
		}
		val4.Normalize();
		Vector3 val5 = vector3_2 + val4 * (num4 * val);
		if (bool_0 && !bool_24)
		{
			float num5 = method_235(val5.X, 0f - val5.Z);
			float val6 = method_238(val5, 2f);
			float num6 = Math.Max(num5 + 2f, val6);
			if (val5.Y < num6)
			{
				val5.Y = num6;
			}
			if (pwMapBrushCollisionService_0 != null && pwMapBrushCollisionService_0.BrushCount > 0)
			{
				Vector3 halfExtents = default(Vector3);
				halfExtents = new Vector3(0.4f, 1f, 0.4f);
				Vector3 val7 = val5 - vector3_2;
				if (pwMapBrushCollisionService_0.TraceAABB(vector3_2, val7, halfExtents, out var fraction, out var _) && fraction < 1f)
				{
					val5 = vector3_2 + val7 * Math.Max(0f, fraction - 0.01f);
				}
			}
		}
		if (bool_1 && !bool_24)
		{
			float num7 = method_235(val5.X, 0f - val5.Z);
			float num8 = Math.Max(3f, float_1 * 0.15f);
			val5.Y = num7 + num8;
		}
		vector3_2 = val5;
	}

	private void method_191()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		Matrix val = method_193();
		Matrix val2 = method_195();
		device_0.SetTransform((TransformState)3, (val));
		device_0.SetTransform((TransformState)2, (val2));
		device_0.SetTransform((TransformState)256, (Matrix.Identity));
		label_31.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649208768), Class16.smethod_0(1649208805)), float_2, float_3, vector3_2.X, vector3_2.Y, vector3_2.Z);
		method_88(vector3_2.X, vector3_2.Y, 0f - vector3_2.Z);
		pictureBox_2?.Invalidate();
		method_9();
	}

	private Vector3 method_192()
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		float num = (float)Math.Cos(float_3);
		float num2 = (float)Math.Sin(float_3);
		float num3 = (float)Math.Cos(float_2);
		float num4 = (float)Math.Sin(float_2);
		return new Vector3(vector3_2.X + float_1 * num * num3, vector3_2.Y + float_1 * num2, vector3_2.Z + float_1 * num * num4);
	}

	private Matrix method_193()
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		float num = ((panel_21.ClientSize.Height == 0) ? 1f : ((float)panel_21.ClientSize.Width / (float)panel_21.ClientSize.Height));
		if (checkBox_5 != null && checkBox_5.Checked)
		{
			float num2 = Math.Max(50f, float_1 * 0.5f);
			return Matrix.OrthoLH(num2 * 2f * num, num2 * 2f, 0.1f, method_194());
		}
		float num3 = Math.Max(0.2f, Math.Min(2f, float_1 * 0.00025f));
		float num4 = method_194();
		return Matrix.PerspectiveFovLH(float_0, num, num3, num4);
	}

	private float method_194()
	{
		int num = trackBar_16?.Value ?? 8;
		float num2 = (float)num * 64f;
		float num3 = 0f;
		if (pwMapTrn2File_0 != null)
		{
			num3 = Math.Max(pwMapTrn2File_0.Width, pwMapTrn2File_0.Height);
		}
		float val = Math.Max(14000f, num3 * 5.5f);
		float val2 = Math.Max(14000f, float_1 * 8f);
		float val3 = Math.Max(14000f, num2 * 20f);
		float val4 = Math.Max(val3, Math.Max(val, val2));
		return Math.Max(14000f, Math.Min(240000f, val4));
	}

	private Matrix method_195()
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		if (checkBox_5 != null && checkBox_5.Checked)
		{
			Vector3 val = default(Vector3);
			val = new Vector3(vector3_2.X, 800f, vector3_2.Z);
			return Matrix.LookAtLH(val, vector3_2, new Vector3(0f, 0f, -1f));
		}
		if (bool_24)
		{
			return Matrix.LookAtLH(method_236(), method_237(), Vector3.UnitY);
		}
		return Matrix.LookAtLH(method_192(), vector3_2, Vector3.UnitY);
	}

	private void method_196()
	{
		bool_12 = !bool_12;
		method_120(bool_12 ? Class16.smethod_0(1649207858) : Class16.smethod_0(1649207839), null);
	}

	private void method_197(int int_40)
	{
		if (bool_12 && device_0 != null)
		{
			device_0.SetTexture(0, (BaseTexture)null);
			device_0.SetRenderState((RenderState)60, int_40);
			device_0.VertexFormat = (VertexFormat)66;
			device_0.SetTextureStageState(0, (TextureStage)1, (TextureOperation)2);
			device_0.SetTextureStageState(0, (TextureStage)2, (TextureArgument)3);
			device_0.SetTextureStageState(0, (TextureStage)4, (TextureOperation)2);
			device_0.SetTextureStageState(0, (TextureStage)5, (TextureArgument)3);
			device_0.SetTextureStageState(1, (TextureStage)1, (TextureOperation)1);
		}
	}

	private void method_198(int int_40)
	{
		if (device_0 != null)
		{
			device_0.SetRenderState((RenderState)60, int_40);
			device_0.VertexFormat = (VertexFormat)66;
			device_0.SetTextureStageState(0, (TextureStage)1, (TextureOperation)4);
			device_0.SetTextureStageState(0, (TextureStage)2, (TextureArgument)0);
			device_0.SetTextureStageState(0, (TextureStage)3, (TextureArgument)3);
			device_0.SetTextureStageState(0, (TextureStage)4, (TextureOperation)2);
			device_0.SetTextureStageState(0, (TextureStage)5, (TextureArgument)0);
			device_0.SetTextureStageState(1, (TextureStage)1, (TextureOperation)1);
		}
	}

	private void method_199(VertexBuffer vertexBuffer_17, int int_40, int int_41)
	{
		if (device_0 != null && vertexBuffer_17 != null && int_40 > 2)
		{
			method_197(int_41);
			device_0.SetStreamSource(0, vertexBuffer_17, 0, Struct74.int_1);
			device_0.DrawPrimitives((PrimitiveType)4, 0, int_40 / 3);
		}
	}

	private void method_200(IReadOnlyList<Class313> ireadOnlyList_0, int int_40)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		if (device_0 == null || ireadOnlyList_0 == null || ireadOnlyList_0.Count == 0)
		{
			return;
		}
		method_197(int_40);
		for (int i = 0; i < ireadOnlyList_0.Count; i++)
		{
			Class313 @class = ireadOnlyList_0[i];
			if (@class?.vertexBuffer_0 != null && @class.int_0 > 2 && (!(@class.float_0 > 0f) || method_209(@class.vector3_0, @class.float_0)))
			{
				device_0.SetStreamSource(0, @class.vertexBuffer_0, 0, Struct79.int_1);
				device_0.VertexFormat = (VertexFormat)322;
				device_0.DrawPrimitives((PrimitiveType)4, 0, @class.int_0 / 3);
			}
		}
	}

	private void method_201(PwMapCameraSettings pwMapCameraSettings_0)
	{
		bool_12 = pwMapCameraSettings_0.ColorModeEnabled;
		int_3 = pwMapCameraSettings_0.ColorModeTerrain;
		int_4 = pwMapCameraSettings_0.ColorModeLitModel;
		int_5 = pwMapCameraSettings_0.ColorModeWater;
		int_6 = pwMapCameraSettings_0.ColorModeFlora;
		int_7 = pwMapCameraSettings_0.ColorModeGfx;
		int_8 = pwMapCameraSettings_0.ColorModeLight;
		int_9 = pwMapCameraSettings_0.ColorModeGrass;
		bool_24 = pwMapCameraSettings_0.PlayerMode;
	}

	private void method_202(PwMapCameraSettings pwMapCameraSettings_0)
	{
		pwMapCameraSettings_0.ColorModeEnabled = bool_12;
		pwMapCameraSettings_0.ColorModeTerrain = int_3;
		pwMapCameraSettings_0.ColorModeLitModel = int_4;
		pwMapCameraSettings_0.ColorModeWater = int_5;
		pwMapCameraSettings_0.ColorModeFlora = int_6;
		pwMapCameraSettings_0.ColorModeGfx = int_7;
		pwMapCameraSettings_0.ColorModeLight = int_8;
		pwMapCameraSettings_0.ColorModeGrass = int_9;
		pwMapCameraSettings_0.PlayerMode = bool_24;
	}

	private void method_203(Point point_3)
	{
		if (!panel_21.Visible || panel_21.IsDisposed || base.IsDisposed || base.Disposing)
		{
			return;
		}
		try
		{
			Class308 @class = new Class308();
			@class.pwMapSharpDxEditorForm_0 = this;
			method_204();
			if (contextMenuStrip_0 == null || contextMenuStrip_0.IsDisposed)
			{
				return;
			}
			contextMenuStrip_0.Items.Clear();
			bool flag;
			bool enabled = (flag = class301_1 != null) && method_134(class301_1);
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649207892)));
			toolStripMenuItem.Enabled = true;
			toolStripMenuItem.Click += method_386;
			contextMenuStrip_0.Items.Add(toolStripMenuItem);
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649207907)));
			toolStripMenuItem2.Enabled = true;
			toolStripMenuItem2.Click += method_387;
			contextMenuStrip_0.Items.Add(toolStripMenuItem2);
			ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1648941875), Class16.smethod_0(1648931357)));
			toolStripMenuItem3.Enabled = enabled;
			toolStripMenuItem3.Click += method_388;
			contextMenuStrip_0.Items.Add(toolStripMenuItem3);
			ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649207929), Class16.smethod_0(1648925718)));
			toolStripMenuItem4.Enabled = enabled;
			toolStripMenuItem4.Click += method_389;
			contextMenuStrip_0.Items.Add(toolStripMenuItem4);
			ToolStripMenuItem toolStripMenuItem5 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649207964)));
			toolStripMenuItem5.Enabled = enabled;
			toolStripMenuItem5.Click += method_390;
			contextMenuStrip_0.Items.Add(toolStripMenuItem5);
			contextMenuStrip_0.Items.Add(new ToolStripSeparator());
			ToolStripMenuItem toolStripMenuItem6 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649207989)));
			toolStripMenuItem6.Click += method_391;
			contextMenuStrip_0.Items.Add(toolStripMenuItem6);
			if (flag)
			{
				ToolStripMenuItem toolStripMenuItem7 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649208008)));
				toolStripMenuItem7.Click += method_392;
				contextMenuStrip_0.Items.Add(toolStripMenuItem7);
				ToolStripMenuItem toolStripMenuItem8 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649208033)));
				toolStripMenuItem8.Click += method_393;
				contextMenuStrip_0.Items.Add(toolStripMenuItem8);
				if (!string.IsNullOrWhiteSpace(class301_1.string_1))
				{
					ToolStripMenuItem toolStripMenuItem9 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649208063)));
					toolStripMenuItem9.Click += method_394;
					contextMenuStrip_0.Items.Add(toolStripMenuItem9);
					ToolStripMenuItem toolStripMenuItem10 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649208094)));
					toolStripMenuItem10.Click += method_395;
					contextMenuStrip_0.Items.Add(toolStripMenuItem10);
				}
				contextMenuStrip_0.Items.Add(new ToolStripSeparator());
			}
			ToolStripMenuItem toolStripMenuItem11 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649208112)));
			toolStripMenuItem11.Click += method_396;
			contextMenuStrip_0.Items.Add(toolStripMenuItem11);
			@class.toolStripMenuItem_0 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649208138)))
			{
				CheckOnClick = true,
				Checked = bool_7
			};
			@class.toolStripMenuItem_0.CheckedChanged += @class.method_0;
			contextMenuStrip_0.Items.Add(@class.toolStripMenuItem_0);
			TDark.ApplyTheme(contextMenuStrip_0);
			if (contextMenuStrip_0.Visible)
			{
				try
				{
					contextMenuStrip_0.Close();
				}
				catch
				{
				}
			}
			contextMenuStrip_0.Show(panel_21, point_3);
		}
		catch (ObjectDisposedException)
		{
			contextMenuStrip_0 = null;
		}
	}

	private void method_204()
	{
		if (contextMenuStrip_0 == null || contextMenuStrip_0.IsDisposed)
		{
			contextMenuStrip_0 = new ContextMenuStrip();
			TDark.StoreOriginalColors(contextMenuStrip_0);
			TDark.ApplyTheme(contextMenuStrip_0);
			TDark.ApplyNativeDarkThemeRecursive(contextMenuStrip_0);
		}
	}

	private void method_205(Class301 class301_2)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		if (class301_2 != null)
		{
			vector3_2 = class301_2.vector3_1;
			float num = Math.Max(4f, Math.Max(class301_2.vector3_2.X, Math.Max(class301_2.vector3_2.Y, class301_2.vector3_2.Z)));
			if (class301_2.float_0 > 0f)
			{
				num = Math.Max(num, class301_2.float_0);
			}
			float_1 = Math.Max(16f, Math.Min(25000f, num * 6f));
			method_120(Class16.smethod_0(1649208173) + class301_2.string_0, null);
		}
	}

	private static void smethod_22(string string_6)
	{
		if (string.IsNullOrWhiteSpace(string_6))
		{
			return;
		}
		try
		{
			Clipboard.SetText(string_6);
		}
		catch
		{
		}
	}

	private static void smethod_23(string string_6)
	{
		if (!string.IsNullOrWhiteSpace(string_6) && File.Exists(string_6))
		{
			try
			{
				Process.Start(Class16.smethod_0(1649049928), Class16.smethod_0(1649208189) + string_6 + Class16.smethod_0(1648904453));
			}
			catch
			{
			}
		}
	}

	private void method_206()
	{
		ContextMenuStrip contextMenuStrip = contextMenuStrip_0;
		contextMenuStrip_0 = null;
		if (contextMenuStrip == null)
		{
			return;
		}
		try
		{
			contextMenuStrip.Items.Clear();
			contextMenuStrip.Dispose();
		}
		catch
		{
		}
	}

	private void method_207(object sender, EventArgs e)
	{
		if (bool_13 && device_0 != null && !base.IsDisposed)
		{
			if (bool_24)
			{
				method_234();
			}
			else
			{
				method_190();
			}
			method_239();
		}
	}

	private void method_208()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		if (device_0 == null)
		{
			return;
		}
		Matrix val = (device_0.GetTransform((TransformState)2));
		Matrix val2 = (device_0.GetTransform((TransformState)3));
		Matrix val3 = Matrix.Multiply(val, val2);
		plane_0 = (Plane[])(object)new Plane[6];
		plane_0[0] = new Plane(val3.M14 + val3.M11, val3.M24 + val3.M21, val3.M34 + val3.M31, val3.M44 + val3.M41);
		plane_0[1] = new Plane(val3.M14 - val3.M11, val3.M24 - val3.M21, val3.M34 - val3.M31, val3.M44 - val3.M41);
		plane_0[2] = new Plane(val3.M14 + val3.M12, val3.M24 + val3.M22, val3.M34 + val3.M32, val3.M44 + val3.M42);
		plane_0[3] = new Plane(val3.M14 - val3.M12, val3.M24 - val3.M22, val3.M34 - val3.M32, val3.M44 - val3.M42);
		plane_0[4] = new Plane(val3.M13, val3.M23, val3.M33, val3.M43);
		plane_0[5] = new Plane(val3.M14 - val3.M13, val3.M24 - val3.M23, val3.M34 - val3.M33, val3.M44 - val3.M43);
		for (int i = 0; i < 6; i++)
		{
			float num = (float)Math.Sqrt(plane_0[i].Normal.X * plane_0[i].Normal.X + plane_0[i].Normal.Y * plane_0[i].Normal.Y + plane_0[i].Normal.Z * plane_0[i].Normal.Z);
			if (num > 1E-05f)
			{
				plane_0[i] = new Plane(plane_0[i].Normal / num, plane_0[i].D / num);
			}
		}
	}

	private bool method_209(Vector3 vector3_5, float float_14)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		if (plane_0 == null)
		{
			return true;
		}
		int num = 0;
		while (true)
		{
			if (num < 6)
			{
				float num2 = Plane.DotCoordinate(plane_0[num], vector3_5);
				if (!(num2 >= 0f - float_14))
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	private void method_210(IReadOnlyList<Class313> ireadOnlyList_0, bool bool_37)
	{
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		if (device_0 == null || ireadOnlyList_0 == null || ireadOnlyList_0.Count == 0)
		{
			return;
		}
		device_0.VertexFormat = (VertexFormat)322;
		device_0.SetTextureStageState(0, (TextureStage)1, (TextureOperation)4);
		device_0.SetTextureStageState(0, (TextureStage)2, (TextureArgument)2);
		device_0.SetTextureStageState(0, (TextureStage)3, (TextureArgument)0);
		device_0.SetTextureStageState(0, (TextureStage)4, (TextureOperation)4);
		device_0.SetTextureStageState(0, (TextureStage)5, (TextureArgument)2);
		device_0.SetTextureStageState(0, (TextureStage)6, (TextureArgument)0);
		device_0.SetTextureStageState(1, (TextureStage)1, (TextureOperation)4);
		device_0.SetTextureStageState(1, (TextureStage)2, (TextureArgument)1);
		device_0.SetTextureStageState(1, (TextureStage)3, (TextureArgument)3);
		device_0.SetTextureStageState(1, (TextureStage)4, (TextureOperation)2);
		device_0.SetTextureStageState(1, (TextureStage)5, (TextureArgument)1);
		device_0.SetTextureStageState(2, (TextureStage)1, (TextureOperation)1);
		device_0.SetRenderState((RenderState)27, bool_37);
		device_0.SetRenderState((RenderState)15, bool_37);
		if (bool_37)
		{
			device_0.SetRenderState<Blend>((RenderState)19, (Blend)5);
			device_0.SetRenderState<Blend>((RenderState)20, (Blend)6);
			device_0.SetRenderState((RenderState)24, 20);
			device_0.SetRenderState<Compare>((RenderState)25, (Compare)7);
			device_0.SetRenderState((RenderState)14, false);
		}
		for (int i = 0; i < ireadOnlyList_0.Count; i++)
		{
			Class313 @class = ireadOnlyList_0[i];
			if (@class?.vertexBuffer_0 != null && @class.texture_0 != null && @class.int_0 > 2 && (!(@class.float_0 > 0f) || method_209(@class.vector3_0, @class.float_0)))
			{
				device_0.SetTexture(0, (BaseTexture)(object)@class.texture_0);
				device_0.SetStreamSource(0, @class.vertexBuffer_0, 0, Struct79.int_1);
				device_0.DrawPrimitives((PrimitiveType)4, 0, @class.int_0 / 3);
			}
		}
		device_0.SetTexture(0, (BaseTexture)null);
		device_0.SetTextureStageState(1, (TextureStage)1, (TextureOperation)1);
		device_0.SetRenderState((RenderState)27, false);
		device_0.SetRenderState((RenderState)15, false);
		device_0.SetRenderState((RenderState)14, true);
		device_0.VertexFormat = (VertexFormat)66;
		device_0.SetTextureStageState(0, (TextureStage)1, (TextureOperation)4);
		device_0.SetTextureStageState(0, (TextureStage)2, (TextureArgument)0);
		device_0.SetTextureStageState(0, (TextureStage)3, (TextureArgument)3);
		device_0.SetTextureStageState(0, (TextureStage)4, (TextureOperation)2);
		device_0.SetTextureStageState(0, (TextureStage)5, (TextureArgument)0);
	}

	private void method_211()
	{
		int tickCount = Environment.TickCount;
		if (int_15 <= 0)
		{
			int_15 = tickCount;
			int_14 = 0;
		}
		int_14++;
		int num = tickCount - int_15;
		if (num >= 500)
		{
			int_16 = (int)Math.Round((double)int_14 * (1000.0 / (double)Math.Max(1, num)));
			int_14 = 0;
			int_15 = tickCount;
		}
		int num2 = tickCount - int_17;
		if (int_17 == 0 || num2 >= 500)
		{
			int_17 = tickCount;
			method_313(int_16);
		}
	}

	private void method_212()
	{
		if (device_0 == null && !panel_21.IsDisposed && panel_21.IsHandleCreated)
		{
			method_213();
		}
	}

	private void method_213()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		method_219();
		if (panel_21.ClientSize.Width > 0 && panel_21.ClientSize.Height > 0)
		{
			direct3D_0 = new Direct3D();
			int num = smethod_24(direct3D_0);
			presentParameters_0 = new PresentParameters
			{
				Windowed = (true),
				SwapEffect = (SwapEffect)((num > 0) ? 1 : 1),
				BackBufferFormat = (Format)22,
				BackBufferWidth = Math.Max(1, panel_21.ClientSize.Width),
				BackBufferHeight = Math.Max(1, panel_21.ClientSize.Height),
				EnableAutoDepthStencil = (true),
				AutoDepthStencilFormat = (Format)75,
				PresentationInterval = method_216(),
				DeviceWindowHandle = panel_21.Handle,
				MultiSampleType = (MultisampleType)num,
				MultiSampleQuality = 0
			};
			device_0 = smethod_25(direct3D_0, presentParameters_0);
			if (device_0 == null)
			{
				method_120(Class16.smethod_0(1649208205), null);
				return;
			}
			device_0.SetRenderState((RenderState)137, false);
			device_0.SetRenderState<Cull>((RenderState)22, (Cull)1);
			device_0.SetRenderState((RenderState)7, true);
			device_0.SetRenderState((RenderState)14, true);
			device_0.SetRenderState((RenderState)176, true);
			device_0.SetRenderState((RenderState)161, num > 0);
			device_0.SetRenderState((RenderState)15, false);
			device_0.SetRenderState((RenderState)26, true);
			device_0.SetRenderState((RenderState)29, false);
			device_0.SetRenderState((RenderState)143, false);
			method_217();
			bool_13 = true;
			Application.Idle += method_207;
			int_12 = Environment.TickCount;
			int_14 = 0;
			int_15 = Environment.TickCount;
			int_16 = -1;
			int_17 = 0;
			method_313(-1);
			method_353();
			method_225();
			method_32();
			method_261();
			method_120(Class16.smethod_0(1649208242), null);
		}
	}

	private static int smethod_24(Direct3D direct3D_1)
	{
		int[] array = new int[3] { 8, 4, 2 };
		int[] array2 = array;
		int result = default(int);
		int num2 = default(int);
		foreach (int num in array2)
		{
			try
			{
				if (direct3D_1.CheckDeviceMultisampleType(0, (DeviceType)1, (Format)22, true, (MultisampleType)num, out result) && direct3D_1.CheckDeviceMultisampleType(0, (DeviceType)1, (Format)75, true, (MultisampleType)num, out num2))
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

	private static Device smethod_25(Direct3D direct3D_1, PresentParameters presentParameters_1)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		Device val = null;
		try
		{
			val = new Device(direct3D_1, 0, (DeviceType)1, presentParameters_1.DeviceWindowHandle, (CreateFlags)68, (PresentParameters[])(object)new PresentParameters[1] { presentParameters_1 });
		}
		catch
		{
		}
		if (val != null)
		{
			return val;
		}
		try
		{
			val = new Device(direct3D_1, 0, (DeviceType)1, presentParameters_1.DeviceWindowHandle, (CreateFlags)36, (PresentParameters[])(object)new PresentParameters[1] { presentParameters_1 });
		}
		catch
		{
		}
		return val;
	}

	private void method_214()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		float_1 = 500f;
		float_2 = 0.82f;
		float_3 = -0.65f;
		vector3_2 = Vector3.Zero;
		int_12 = Environment.TickCount;
		if (bool_24)
		{
			bool_24 = false;
			if (toolStripButton_5 != null)
			{
				toolStripButton_5.Checked = false;
			}
			if (toolStripMenuItem_13 != null)
			{
				toolStripMenuItem_13.Checked = false;
			}
		}
		method_120(Class16.smethod_0(1649208286), null);
	}

	private void method_215()
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		if (device_0 == null || panel_21.IsDisposed || !panel_21.IsHandleCreated)
		{
			return;
		}
		bool flag;
		if (flag = bool_13)
		{
			bool_13 = false;
		}
		try
		{
			presentParameters_0.BackBufferWidth = Math.Max(1, panel_21.ClientSize.Width);
			presentParameters_0.BackBufferHeight = Math.Max(1, panel_21.ClientSize.Height);
			presentParameters_0.PresentationInterval = method_216();
			device_0.Reset((PresentParameters[])(object)new PresentParameters[1] { presentParameters_0 });
			device_0.SetRenderState((RenderState)137, false);
			device_0.SetRenderState<Cull>((RenderState)22, (Cull)1);
			device_0.SetRenderState((RenderState)7, true);
			device_0.SetRenderState((RenderState)14, true);
			device_0.SetRenderState((RenderState)176, true);
			device_0.SetRenderState((RenderState)161, true);
			device_0.SetRenderState((RenderState)15, false);
			device_0.SetRenderState((RenderState)26, true);
			method_217();
			method_353();
			method_225();
			method_32();
			method_261();
			method_321();
		}
		catch
		{
			try
			{
				method_213();
			}
			catch
			{
			}
		}
		finally
		{
			if (flag)
			{
				bool_13 = true;
			}
		}
	}

	private PresentInterval method_216()
	{
		if (method_312())
		{
			return (PresentInterval)1;
		}
		return (PresentInterval)int.MinValue;
	}

	private void method_217()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		if (device_0 == null)
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

	private void method_218()
	{
		if (device_0 == null)
		{
			return;
		}
		method_178(Class16.smethod_0(1649207302), Class16.smethod_0(1649207317));
		try
		{
			method_213();
			method_120(method_312() ? Class16.smethod_0(1649207355) : Class16.smethod_0(1649207341), null);
		}
		finally
		{
			method_183();
		}
	}

	private void method_219()
	{
		method_228();
		method_206();
		bool_13 = false;
		Application.Idle -= method_207;
		int_14 = 0;
		int_15 = 0;
		int_16 = -1;
		int_17 = 0;
		method_313(-1);
		try
		{
			VertexBuffer obj = vertexBuffer_0;
			if (obj != null)
			{
				((DisposeBase)obj).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_0 = null;
		try
		{
			VertexBuffer obj3 = vertexBuffer_12;
			if (obj3 != null)
			{
				((DisposeBase)obj3).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_12 = null;
		int_35 = 0;
		try
		{
			VertexBuffer obj5 = vertexBuffer_13;
			if (obj5 != null)
			{
				((DisposeBase)obj5).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_13 = null;
		int_36 = 0;
		method_368(bool_37: true);
		try
		{
			VertexBuffer obj7 = vertexBuffer_1;
			if (obj7 != null)
			{
				((DisposeBase)obj7).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_1 = null;
		int_11 = 0;
		try
		{
			VertexBuffer obj9 = vertexBuffer_11;
			if (obj9 != null)
			{
				((DisposeBase)obj9).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_11 = null;
		int_32 = 0;
		try
		{
			VertexBuffer obj11 = vertexBuffer_2;
			if (obj11 != null)
			{
				((DisposeBase)obj11).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_2 = null;
		int_13 = 0;
		method_263(bool_37: true);
		try
		{
			Device obj13 = device_0;
			if (obj13 != null)
			{
				((DisposeBase)obj13).Dispose();
			}
		}
		catch
		{
		}
		device_0 = null;
		try
		{
			Direct3D obj15 = direct3D_0;
			if (obj15 != null)
			{
				((DisposeBase)obj15).Dispose();
			}
		}
		catch
		{
		}
		direct3D_0 = null;
	}

	private void method_220(IReadOnlyList<Class313> ireadOnlyList_0)
	{
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		if (device_0 == null || ireadOnlyList_0 == null || ireadOnlyList_0.Count == 0)
		{
			return;
		}
		if (int_18 == 0)
		{
			int_18 = Environment.TickCount;
		}
		float float_ = (float)(Environment.TickCount - int_18) / 1000f;
		device_0.VertexFormat = (VertexFormat)322;
		method_221();
		method_222();
		for (int i = 0; i < ireadOnlyList_0.Count; i++)
		{
			Class313 @class = ireadOnlyList_0[i];
			if (@class?.vertexBuffer_0 != null && @class.texture_0 != null && @class.int_0 > 2 && (!(@class.float_0 > 0f) || method_209(@class.vector3_0, @class.float_0)))
			{
				method_223(float_, i, @class.vector3_0);
				device_0.SetTexture(0, (BaseTexture)(object)@class.texture_0);
				device_0.SetStreamSource(0, @class.vertexBuffer_0, 0, Struct79.int_1);
				device_0.DrawPrimitives((PrimitiveType)4, 0, @class.int_0 / 3);
			}
		}
		method_224();
	}

	private void method_221()
	{
		device_0.SetTextureStageState(0, (TextureStage)1, (TextureOperation)4);
		device_0.SetTextureStageState(0, (TextureStage)2, (TextureArgument)2);
		device_0.SetTextureStageState(0, (TextureStage)3, (TextureArgument)0);
		device_0.SetTextureStageState(0, (TextureStage)4, (TextureOperation)4);
		device_0.SetTextureStageState(0, (TextureStage)5, (TextureArgument)2);
		device_0.SetTextureStageState(0, (TextureStage)6, (TextureArgument)0);
		device_0.SetTextureStageState(1, (TextureStage)1, (TextureOperation)4);
		device_0.SetTextureStageState(1, (TextureStage)2, (TextureArgument)1);
		device_0.SetTextureStageState(1, (TextureStage)3, (TextureArgument)3);
		device_0.SetTextureStageState(1, (TextureStage)4, (TextureOperation)2);
		device_0.SetTextureStageState(1, (TextureStage)5, (TextureArgument)1);
		device_0.SetTextureStageState(2, (TextureStage)1, (TextureOperation)1);
	}

	private void method_222()
	{
		device_0.SetRenderState((RenderState)27, true);
		device_0.SetRenderState((RenderState)15, true);
		device_0.SetRenderState<Blend>((RenderState)19, (Blend)5);
		device_0.SetRenderState<Blend>((RenderState)20, (Blend)6);
		device_0.SetRenderState((RenderState)24, 20);
		device_0.SetRenderState<Compare>((RenderState)25, (Compare)7);
		device_0.SetRenderState((RenderState)14, false);
		device_0.SetSamplerState(0, (SamplerState)1, (TextureAddress)3);
		device_0.SetSamplerState(0, (SamplerState)2, (TextureAddress)3);
	}

	private void method_223(float float_14, int int_40, Vector3 vector3_5)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		float num = (float)int_40 * 1.37f + vector3_5.X * 0.01f + vector3_5.Z * 0.013f;
		float num2 = 1.8f * float_4 * 4f;
		float num3 = float_4 * 0.12f;
		float num4 = num3 * (float)Math.Sin(float_14 * num2 + num);
		float num5 = num3 * (float)Math.Sin(float_14 * num2 * 0.7f + num * 1.3f);
		float num6 = 1f + 0.3f * (float)Math.Sin(float_14 * 0.5f + num * 0.2f);
		num4 *= num6;
		num5 *= num6;
		Matrix identity = Matrix.Identity;
		identity.M31 = num4;
		identity.M33 = 1f + num5 * 0.1f;
		identity.M41 = vector3_5.X * num4 * 0.002f;
		identity.M43 = vector3_5.Z * num5 * 0.002f;
		device_0.SetTransform((TransformState)256, (identity));
	}

	private void method_224()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		device_0.SetTransform((TransformState)256, (Matrix.Identity));
		device_0.SetTextureStageState(0, (TextureStage)24, 0);
		device_0.SetTexture(0, (BaseTexture)null);
		device_0.SetTextureStageState(1, (TextureStage)1, (TextureOperation)1);
		device_0.SetRenderState((RenderState)27, false);
		device_0.SetRenderState((RenderState)15, false);
		device_0.SetRenderState((RenderState)14, true);
		device_0.SetSamplerState(0, (SamplerState)1, (TextureAddress)1);
		device_0.SetSamplerState(0, (SamplerState)2, (TextureAddress)1);
		device_0.VertexFormat = (VertexFormat)66;
		device_0.SetTextureStageState(0, (TextureStage)1, (TextureOperation)4);
		device_0.SetTextureStageState(0, (TextureStage)2, (TextureArgument)0);
		device_0.SetTextureStageState(0, (TextureStage)3, (TextureArgument)3);
		device_0.SetTextureStageState(0, (TextureStage)4, (TextureOperation)2);
		device_0.SetTextureStageState(0, (TextureStage)5, (TextureArgument)0);
	}

	private void method_225()
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		if (device_0 == null)
		{
			return;
		}
		try
		{
			VertexBuffer obj = vertexBuffer_0;
			if (obj != null)
			{
				((DisposeBase)obj).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_0 = null;
		int_10 = 0;
		List<Struct74> list = method_226();
		if (list.Count != 0)
		{
			int_10 = list.Count;
			vertexBuffer_0 = new VertexBuffer(device_0, int_10 * Struct74.int_1, (Usage)8, (VertexFormat)0, (Pool)1);
			DataStream val = vertexBuffer_0.Lock(0, 0, (LockFlags)0);
			val.WriteRange<Struct74>(list.ToArray());
			vertexBuffer_0.Unlock();
		}
	}

	private List<Struct74> method_226()
	{
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		List<Struct74> list = new List<Struct74>();
		if (checkBox_33.Checked)
		{
			float num = 360f;
			for (int i = -36; i <= 36; i++)
			{
				float num2 = (float)i * 10f;
				int num3 = ((i == 0) ? (-11908534) : (-13948117));
				list.Add(new Struct74
				{
					vector3_0 = new Vector3(num2, 0f, 0f - num),
					int_0 = num3
				});
				list.Add(new Struct74
				{
					vector3_0 = new Vector3(num2, 0f, num),
					int_0 = num3
				});
				list.Add(new Struct74
				{
					vector3_0 = new Vector3(0f - num, 0f, num2),
					int_0 = num3
				});
				list.Add(new Struct74
				{
					vector3_0 = new Vector3(num, 0f, num2),
					int_0 = num3
				});
			}
		}
		if (checkBox_34.Checked)
		{
			list.Add(new Struct74
			{
				vector3_0 = Vector3.Zero,
				int_0 = -49088
			});
			list.Add(new Struct74
			{
				vector3_0 = new Vector3(180f, 0f, 0f),
				int_0 = -49088
			});
			list.Add(new Struct74
			{
				vector3_0 = Vector3.Zero,
				int_0 = -12517568
			});
			list.Add(new Struct74
			{
				vector3_0 = new Vector3(0f, 180f, 0f),
				int_0 = -12517568
			});
			list.Add(new Struct74
			{
				vector3_0 = Vector3.Zero,
				int_0 = -12545793
			});
			list.Add(new Struct74
			{
				vector3_0 = new Vector3(0f, 0f, 180f),
				int_0 = -12545793
			});
		}
		return list;
	}

	private void panel_21_Resize(object sender, EventArgs e)
	{
		if (timer_0 == null)
		{
			timer_0 = new Timer
			{
				Interval = 100
			};
			timer_0.Tick += timer_0_Tick;
		}
		timer_0.Stop();
		timer_0.Start();
	}

	private void panel_21_MouseDown(object sender, MouseEventArgs e)
	{
		panel_21.Focus();
		point_0 = e.Location;
		if (e.Button == MouseButtons.Right)
		{
			bool_14 = true;
			point_1 = e.Location;
			bool_16 = false;
		}
		if (e.Button == MouseButtons.Left)
		{
			if (string_2 == Class16.smethod_0(1649209693) && !bool_24)
			{
				bool_35 = true;
				method_373(e.Location, (Control.ModifierKeys & Keys.Alt) != 0);
			}
			else
			{
				bool_15 = true;
				point_2 = e.Location;
				bool_32 = false;
			}
		}
	}

	private void panel_21_MouseMove(object sender, MouseEventArgs e)
	{
		int num = e.X - point_0.X;
		int num2 = e.Y - point_0.Y;
		point_0 = e.Location;
		if (bool_35 && e.Button == MouseButtons.Left)
		{
			method_373(e.Location, (Control.ModifierKeys & Keys.Alt) != 0);
			return;
		}
		if (string_2 == Class16.smethod_0(1649209693) && !bool_14 && !bool_15)
		{
			method_374(e.Location);
		}
		if (bool_14)
		{
			if (!bool_16 && (Math.Abs(e.X - point_1.X) > 3 || Math.Abs(e.Y - point_1.Y) > 3))
			{
				bool_16 = true;
			}
			if (checkBox_5 == null || !checkBox_5.Checked)
			{
				float num3 = (float)(trackBar_1?.Value ?? 20) / 100f;
				float num4 = (float)num * num3 * 0.012f;
				float num5 = (float)num2 * num3 * 0.009f;
				float_5 += (num4 - float_5) * 0.45f;
				float_6 += (num5 - float_6) * 0.45f;
				float_2 += float_5;
				float_3 += float_6;
				float_3 = Math.Max(-1.5f, Math.Min(1.5f, float_3));
			}
		}
		else
		{
			float_5 = 0f;
			float_6 = 0f;
		}
		if (bool_15 && !bool_24)
		{
			if (!bool_32 && (Math.Abs(e.X - point_2.X) > 3 || Math.Abs(e.Y - point_2.Y) > 3))
			{
				bool_32 = true;
			}
			float num6 = Math.Max(0.03f, float_1 * 0.0018f);
			float num7 = (float)Math.Cos(float_2);
			float num8 = (float)Math.Sin(float_2);
			vector3_2.X += ((float)(-num) * num7 + (float)num2 * num8) * num6;
			vector3_2.Z += ((float)(-num) * num8 - (float)num2 * num7) * num6;
		}
		if (!bool_14 && !bool_15)
		{
			method_322(e.Location);
		}
	}

	private void panel_21_MouseUp(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			bool_14 = false;
			if (!bool_16)
			{
				method_320(e.Location);
				method_203(e.Location);
			}
		}
		if (e.Button != MouseButtons.Left)
		{
			return;
		}
		if (bool_35)
		{
			bool_35 = false;
			return;
		}
		bool_15 = false;
		if (!bool_32)
		{
			method_320(e.Location);
		}
	}

	private void panel_21_MouseWheel(object sender, MouseEventArgs e)
	{
		if (!bool_24)
		{
			float num = ((e.Delta > 0) ? 0.9f : 1.1f);
			float_1 *= num;
			float_1 = Math.Max(8f, Math.Min(25000f, float_1));
		}
	}

	private void panel_21_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
	{
		if (smethod_26(e.KeyCode))
		{
			e.IsInputKey = true;
		}
	}

	private void PwMapSharpDxEditorForm_KeyDown(object sender, KeyEventArgs e)
	{
		if (method_102(e.KeyData))
		{
			e.Handled = true;
			e.SuppressKeyPress = true;
			return;
		}
		if (e.Modifiers == Keys.Control && e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9)
		{
			method_0((int)(e.KeyCode - 49));
			e.Handled = true;
			e.SuppressKeyPress = true;
			return;
		}
		if (e.Modifiers == Keys.Alt && e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9)
		{
			method_1((int)(e.KeyCode - 49));
			e.Handled = true;
			e.SuppressKeyPress = true;
			return;
		}
		if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control)
		{
			method_184();
			e.Handled = true;
			e.SuppressKeyPress = true;
			return;
		}
		if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.None)
		{
			PwMapShortcutHelpDialog pwMapShortcutHelpDialog = new PwMapShortcutHelpDialog();
			try
			{
				pwMapShortcutHelpDialog.ShowDialog(this);
				e.Handled = true;
				e.SuppressKeyPress = true;
				return;
			}
			finally
			{
				((IDisposable)pwMapShortcutHelpDialog).Dispose();
			}
		}
		if (e.KeyCode == Keys.F5 && e.Modifiers == Keys.None)
		{
			method_261();
			method_353();
			method_120(Class16.smethod_0(1649207376), null);
			e.Handled = true;
			e.SuppressKeyPress = true;
		}
		else if (e.KeyCode == Keys.Home && e.Modifiers == Keys.None)
		{
			method_214();
			e.Handled = true;
			e.SuppressKeyPress = true;
		}
		else if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.None)
		{
			method_138();
			e.Handled = true;
			e.SuppressKeyPress = true;
		}
		else if (e.KeyCode == Keys.Insert && e.Modifiers == Keys.None)
		{
			method_135();
			e.Handled = true;
			e.SuppressKeyPress = true;
		}
		else if (e.KeyCode == Keys.P && e.Modifiers == Keys.None)
		{
			method_231();
			e.Handled = true;
			e.SuppressKeyPress = true;
		}
		else if (e.KeyCode == Keys.F && e.Modifiers == Keys.None && bool_24)
		{
			method_232();
			e.Handled = true;
			e.SuppressKeyPress = true;
		}
		else if (e.KeyCode == Keys.C && e.Modifiers == Keys.None)
		{
			method_196();
			e.Handled = true;
			e.SuppressKeyPress = true;
		}
		else if (e.KeyCode == Keys.T && e.Modifiers == Keys.None)
		{
			method_349();
			e.Handled = true;
			e.SuppressKeyPress = true;
		}
		else if (e.KeyCode == Keys.N && e.Modifiers == Keys.None && bool_24)
		{
			bool_2 = !bool_2;
			if (checkBox_14 != null)
			{
				checkBox_14.Checked = bool_2;
			}
			method_120(bool_2 ? Class16.smethod_0(1649207419) : Class16.smethod_0(1649207405), null);
			e.Handled = true;
			e.SuppressKeyPress = true;
		}
		else if (e.KeyCode == Keys.G && e.Modifiers == Keys.None && !bool_24)
		{
			bool_1 = !bool_1;
			if (checkBox_13 != null)
			{
				checkBox_13.Checked = bool_1;
			}
			method_120(bool_1 ? Class16.smethod_0(1649207477) : Class16.smethod_0(1649207440), null);
			e.Handled = true;
			e.SuppressKeyPress = true;
		}
		else
		{
			method_227(e.KeyCode, bool_37: true);
		}
	}

	private void PwMapSharpDxEditorForm_KeyUp(object sender, KeyEventArgs e)
	{
		method_227(e.KeyCode, bool_37: false);
	}

	private void method_227(Keys keys_0, bool bool_37)
	{
		switch (keys_0)
		{
		case Keys.A:
			bool_19 = bool_37;
			break;
		case Keys.D:
			bool_20 = bool_37;
			break;
		case Keys.Left:
			bool_19 = bool_37;
			break;
		case Keys.Right:
			bool_20 = bool_37;
			break;
		case Keys.ControlKey:
		case Keys.Down:
			bool_22 = bool_37;
			break;
		case Keys.W:
			bool_17 = bool_37;
			break;
		case Keys.S:
			bool_18 = bool_37;
			break;
		case Keys.Space:
		case Keys.Up:
		case Keys.E:
		case Keys.Q:
			bool_21 = bool_37;
			break;
		}
	}

	private static bool smethod_26(Keys keys_0)
	{
		if (keys_0 != Keys.W && keys_0 != Keys.A && keys_0 != Keys.S && keys_0 != Keys.D && keys_0 != Keys.Q && keys_0 != Keys.E && keys_0 != Keys.Space && keys_0 != Keys.ControlKey && keys_0 != Keys.Up && keys_0 != Keys.Down && keys_0 != Keys.Left)
		{
			return keys_0 == Keys.Right;
		}
		return true;
	}

	private void method_228()
	{
		bool_17 = false;
		bool_18 = false;
		bool_19 = false;
		bool_20 = false;
		bool_21 = false;
		bool_22 = false;
	}

	private void method_229()
	{
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		if (device_0 == null)
		{
			return;
		}
		if (checkBox_10 == null || !checkBox_10.Checked)
		{
			device_0.SetRenderState((RenderState)137, false);
			return;
		}
		float num = (float)(trackBar_2?.Value ?? 0) / 100f;
		PwMapBoxArea pwMapBoxArea = pwMapBoxArea_0;
		Vector3 val = default(Vector3);
		Color4 color4_ = default(Color4);
		Color4 val2 = default(Color4);
		if (pwMapBoxArea != null)
		{
			val = new Vector3(pwMapBoxArea.LightDirX, pwMapBoxArea.LightDirY, pwMapBoxArea.LightDirZ);
			if (val.LengthSquared() < 0.0001f)
			{
				val = new Vector3(1f, -1f, 1f);
			}
			else
			{
				val.Normalize();
			}
			color4_ = smethod_27(pwMapBoxArea.Ambient, pwMapBoxArea.AmbientNight, num);
			val2 = smethod_27(pwMapBoxArea.DirLtCol, pwMapBoxArea.DirLtColNight, num);
			float num2 = Math.Max(0f, Math.Min(2.5f, pwMapBoxArea.SunPower * (1f - num) + pwMapBoxArea.SunPowerNight * num));
			val2 = new Color4(val2.Alpha, Math.Min(1f, val2.Red * num2), Math.Min(1f, val2.Green * num2), Math.Min(1f, val2.Blue * num2));
		}
		else
		{
			val = new Vector3(1f, -1f, 1f);
			val.Normalize();
			float num3 = 1f - num;
			color4_ = new Color4(1f, 0.5f * num3 + 0.25f * num, 0.5f * num3 + 0.25f * num, 0.5f * num3 + 0.25f * num);
			val2 = new Color4(1f, num3 + 0.2f * num, num3 + 0.2f * num, num3 + 0.2f * num);
		}
		Light val3 = new Light
		{
			Type = (LightType)3,
			Diffuse = (val2),
			Specular = (new Color4(0f, 0f, 0f, 0f)),
			Ambient = (new Color4(0f, 0f, 0f, 0f)),
			Direction = (val)
		};
		device_0.SetLight(0, ref val3);
		device_0.EnableLight(0, (true));
		device_0.SetRenderState((RenderState)137, true);
		device_0.SetRenderState((RenderState)139, smethod_28(color4_));
		device_0.SetRenderState((RenderState)143, true);
		Material material = new Material
		{
			Diffuse = (new Color4(1f, 1f, 1f, 1f)),
			Ambient = (new Color4(1f, 1f, 1f, 1f))
		};
		device_0.Material = material;
		device_0.SetRenderState<ColorSource>((RenderState)145, (ColorSource)0);
		device_0.SetRenderState<ColorSource>((RenderState)147, (ColorSource)0);
		bool_23 = false;
	}

	private void method_230()
	{
		if (device_0 != null)
		{
			device_0.SetRenderState((RenderState)137, false);
		}
	}

	private static Color4 smethod_27(int int_40, int int_41, float float_14)
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		float num = (float)((int_40 >> 16) & 0xFF) / 255f;
		float num2 = (float)((int_40 >> 8) & 0xFF) / 255f;
		float num3 = (float)(int_40 & 0xFF) / 255f;
		float num4 = (float)((int_41 >> 16) & 0xFF) / 255f;
		float num5 = (float)((int_41 >> 8) & 0xFF) / 255f;
		float num6 = (float)(int_41 & 0xFF) / 255f;
		return new Color4(1f, num * (1f - float_14) + num4 * float_14, num2 * (1f - float_14) + num5 * float_14, num3 * (1f - float_14) + num6 * float_14);
	}

	private static int smethod_28(Color4 color4_0)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		byte b = (byte)Math.Max(0, Math.Min(255, (int)(color4_0.Red * 255f)));
		byte b2 = (byte)Math.Max(0, Math.Min(255, (int)(color4_0.Green * 255f)));
		byte b3 = (byte)Math.Max(0, Math.Min(255, (int)(color4_0.Blue * 255f)));
		return -16777216 | (b << 16) | (b2 << 8) | b3;
	}

	private void method_231()
	{
		bool_24 = !bool_24;
		if (bool_24)
		{
			float_7 = 0f;
			bool_25 = false;
			method_233();
		}
		if (toolStripButton_5 != null && toolStripButton_5.Checked != bool_24)
		{
			toolStripButton_5.Checked = bool_24;
		}
		if (toolStripMenuItem_13 != null && toolStripMenuItem_13.Checked != bool_24)
		{
			toolStripMenuItem_13.Checked = bool_24;
		}
		method_120(bool_24 ? Class16.smethod_0(1649207522) : Class16.smethod_0(1649207497), null);
	}

	private void method_232()
	{
		if (bool_24)
		{
			bool_26 = !bool_26;
			if (bool_26)
			{
				float_7 = 0f;
			}
			method_120(bool_26 ? Class16.smethod_0(1649207631) : Class16.smethod_0(1649207586), null);
		}
	}

	private void method_233()
	{
		float num = method_235(vector3_2.X, 0f - vector3_2.Z);
		float num2 = num + 3.2f;
		if (vector3_2.Y < num2)
		{
			vector3_2.Y = num2;
			float_7 = 0f;
			bool_25 = true;
		}
	}

	private void method_234()
	{
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_24)
		{
			return;
		}
		int tickCount = Environment.TickCount;
		if (int_12 <= 0)
		{
			int_12 = tickCount;
			return;
		}
		int num = tickCount - int_12;
		if (num < 0)
		{
			num = 0;
		}
		float num2 = Math.Max(0f, Math.Min(0.07f, (float)num / 1000f));
		int_12 = tickCount;
		if (num2 <= 0f)
		{
			return;
		}
		bool flag = (Control.ModifierKeys & Keys.Shift) != 0;
		if (bool_2)
		{
			float num3 = (flag ? 160f : 60f);
			float num4 = (float)Math.Cos(float_3);
			float num5 = (float)Math.Sin(float_3);
			float num6 = (float)Math.Cos(float_2);
			float num7 = (float)Math.Sin(float_2);
			Vector3 val = default(Vector3);
			val = new Vector3(num4 * num6, 0f - num5, num4 * num7);
			Vector3 val2 = default(Vector3);
			val2 = new Vector3(num7, 0f, 0f - num6);
			Vector3 val3 = Vector3.Zero;
			if (bool_17)
			{
				val3 += val;
			}
			if (bool_18)
			{
				val3 -= val;
			}
			if (bool_20)
			{
				val3 += val2;
			}
			if (bool_19)
			{
				val3 -= val2;
			}
			if (bool_21)
			{
				val3 += Vector3.UnitY;
			}
			if (bool_22)
			{
				val3 -= Vector3.UnitY;
			}
			if (val3.LengthSquared() > 1E-06f)
			{
				val3.Normalize();
				vector3_2 += val3 * num3 * num2;
			}
			return;
		}
		float num8 = (flag ? 120f : 40f);
		float num9 = (float)Math.Cos(float_2);
		float num10 = (float)Math.Sin(float_2);
		Vector3 val4 = default(Vector3);
		val4 = new Vector3(num9, 0f, num10);
		Vector3 val5 = default(Vector3);
		val5 = new Vector3(val4.Z, 0f, 0f - val4.X);
		Vector3 val6 = Vector3.Zero;
		if (bool_17)
		{
			val6 += val4;
		}
		if (bool_18)
		{
			val6 -= val4;
		}
		if (bool_20)
		{
			val6 += val5;
		}
		if (bool_19)
		{
			val6 -= val5;
		}
		if (val6.LengthSquared() > 1E-06f)
		{
			val6.Normalize();
			vector3_2.X += val6.X * num8 * num2;
			vector3_2.Z += val6.Z * num8 * num2;
		}
		if (bool_26)
		{
			float num11 = (flag ? 75f : 25f);
			if (bool_21)
			{
				vector3_2.Y += num11 * num2;
			}
			if (bool_22)
			{
				vector3_2.Y -= num11 * num2;
			}
			return;
		}
		if (bool_21)
		{
			float_7 = Math.Max(float_7, 18f);
			bool_25 = false;
		}
		if (bool_22 && !bool_25)
		{
			float_7 = Math.Min(float_7, -18f);
		}
		float_7 += -30f * num2;
		if (float_7 < -80f)
		{
			float_7 = -80f;
		}
		vector3_2.Y += float_7 * num2;
		float num12 = method_235(vector3_2.X, 0f - vector3_2.Z);
		float num13 = num12 + 3.2f;
		if (bool_27)
		{
			num13 = Math.Max(num13, method_238(vector3_2, 3.2f));
		}
		if (vector3_2.Y <= num13)
		{
			vector3_2.Y = num13;
			float_7 = 0f;
			bool_25 = true;
		}
		else
		{
			bool_25 = false;
		}
	}

	private float method_235(float float_14, float float_15)
	{
		if (pwMapTrn2File_0 == null)
		{
			return 0f;
		}
		float num = pwMapTrn2File_0.Width;
		float num2 = pwMapTrn2File_0.Height;
		int sectorsWide = pwMapTrn2File_0.SectorsWide;
		int sectorsHigh = pwMapTrn2File_0.SectorsHigh;
		if (sectorsWide > 0 && sectorsHigh > 0)
		{
			float num3 = num / (float)sectorsWide;
			float num4 = num2 / (float)sectorsHigh;
			float num5 = (0f - num) * 0.5f;
			float num6 = num2 * 0.5f;
			int val = (int)Math.Floor((float_14 - num5) / num3);
			int val2 = (int)Math.Floor((num6 - float_15) / num4);
			val = Math.Max(0, Math.Min(sectorsWide - 1, val));
			val2 = Math.Max(0, Math.Min(sectorsHigh - 1, val2));
			int int_ = val2 * sectorsWide + val;
			float num7 = num5 + (float)val * num3 + num3 * 0.5f;
			float num8 = num6 - (float)val2 * num4 - num4 * 0.5f;
			return method_363(int_, (int)num3, (int)num4)?.GetHeightAtSectorPos(float_14 - num7, float_15 - num8) ?? method_364(int_);
		}
		return 0f;
	}

	private Vector3 method_236()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return vector3_2;
	}

	private Vector3 method_237()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		float num = (float)Math.Cos(float_3);
		float num2 = (float)Math.Sin(float_3);
		float num3 = (float)Math.Cos(float_2);
		float num4 = (float)Math.Sin(float_2);
		return vector3_2 + new Vector3(num * num3, 0f - num2, num * num4);
	}

	private float method_238(Vector3 vector3_5, float float_14)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		if (pwMapBrushCollisionService_0 != null && pwMapBrushCollisionService_0.BrushCount > 0)
		{
			return pwMapBrushCollisionService_0.SampleFloorHeight(vector3_5, float_14, bool_28);
		}
		if (bool_28)
		{
			return float.MinValue;
		}
		float num = float.MinValue;
		for (int i = 0; i < list_4.Count; i++)
		{
			Class314 @class = list_4[i];
			Vector3 val = @class.vector3_0;
			Vector3 val2 = @class.vector3_1;
			float num2 = val.X - val2.X;
			float num3 = val.X + val2.X;
			float num4 = val.Z - val2.Z;
			float num5 = val.Z + val2.Z;
			if (vector3_5.X < num2 || vector3_5.X > num3 || vector3_5.Z < num4 || vector3_5.Z > num5)
			{
				continue;
			}
			float num6 = val.Y + val2.Y;
			float num7 = val.Y - val2.Y;
			if (vector3_5.Y - float_14 < num6 && vector3_5.Y > num7)
			{
				float num8 = num6 + float_14;
				if (num8 > num)
				{
					num = num8;
				}
			}
		}
		return num;
	}

	private void method_239()
	{
		//IL_0619: Expected O, but got Unknown
		//IL_061b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0625: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0635: Unknown result type (might be due to invalid IL or missing references)
		//IL_063f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		if (device_0 == null || base.IsDisposed || !base.Visible)
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
				method_215();
			}
			return;
		}
		bool flag = false;
		try
		{
			float num = (float)(trackBar_2?.Value ?? 0) / 100f;
			float num2 = 1f - num;
			byte b = (byte)(180f * num2 + 8f * num);
			byte b2 = (byte)(200f * num2 + 10f * num);
			byte b3 = (byte)(220f * num2 + 20f * num);
			bool flag2;
			ColorBGRA val = ((flag2 = checkBox_4 != null && checkBox_4.Checked) ? new ColorBGRA(b, b2, b3, byte.MaxValue) : new ColorBGRA((byte)(32f * num2 + 8f * num), (byte)(32f * num2 + 8f * num), (byte)(35f * num2 + 12f * num), byte.MaxValue));
			device_0.Clear((ClearFlags)3, (val), 1f, 0);
			device_0.BeginScene();
			flag = true;
			bool flag3 = checkBox_2 != null && checkBox_2.Checked;
			device_0.SetRenderState<Cull>((RenderState)22, (Cull)(flag3 ? 1 : 3));
			if (flag2)
			{
				float num3 = method_194();
				float num4;
				float num5;
				byte b4;
				byte b5;
				byte b6;
				if (pwMapBoxArea_0 != null && (pwMapBoxArea_0.FogEnd > 0.1f || pwMapBoxArea_0.FogEndNight > 0.1f))
				{
					num4 = pwMapBoxArea_0.FogStart * num2 + pwMapBoxArea_0.FogStartNight * num;
					num5 = pwMapBoxArea_0.FogEnd * num2 + pwMapBoxArea_0.FogEndNight * num;
					int fogColor = pwMapBoxArea_0.FogColor;
					int fogColorNight = pwMapBoxArea_0.FogColorNight;
					b4 = (byte)((float)((fogColor >> 16) & 0xFF) * num2 + (float)((fogColorNight >> 16) & 0xFF) * num);
					b5 = (byte)((float)((fogColor >> 8) & 0xFF) * num2 + (float)((fogColorNight >> 8) & 0xFF) * num);
					b6 = (byte)((float)(fogColor & 0xFF) * num2 + (float)(fogColorNight & 0xFF) * num);
				}
				else
				{
					num4 = num3 * (0.15f * num2 + 0.02f * num);
					num5 = num3 * (0.85f * num2 + 0.35f * num);
					b4 = b;
					b5 = b2;
					b6 = b3;
				}
				if (num5 <= num4)
				{
					num5 = num4 + 100f;
				}
				device_0.SetRenderState((RenderState)28, true);
				Device obj = device_0;
				ColorBGRA val2 = new ColorBGRA(b4, b5, b6, byte.MaxValue);
				obj.SetRenderState((RenderState)34, val2.ToBgra());
				device_0.SetRenderState<FogMode>((RenderState)35, (FogMode)3);
				device_0.SetRenderState((RenderState)36, BitConverter.ToInt32(BitConverter.GetBytes(num4), 0));
				device_0.SetRenderState((RenderState)37, BitConverter.ToInt32(BitConverter.GetBytes(num5), 0));
			}
			else
			{
				device_0.SetRenderState((RenderState)28, false);
			}
			int num6;
			if (checkBox_10 != null && checkBox_10.Checked)
			{
				num6 = -1;
			}
			else
			{
				byte b7 = (byte)(255f * num2 + 40f * num);
				byte b8 = (byte)(255f * num2 + 45f * num);
				byte b9 = (byte)(255f * num2 + 60f * num);
				num6 = -16777216 | (b7 << 16) | (b8 << 8) | b9;
			}
			device_0.SetRenderState((RenderState)60, num6);
			method_191();
			method_208();
			method_229();
			device_0.VertexFormat = (VertexFormat)66;
			device_0.SetTexture(0, (BaseTexture)null);
			device_0.SetRenderState((RenderState)27, false);
			device_0.SetRenderState((RenderState)15, false);
			device_0.SetRenderState((RenderState)14, true);
			device_0.SetTextureStageState(0, (TextureStage)1, (TextureOperation)4);
			device_0.SetTextureStageState(0, (TextureStage)2, (TextureArgument)0);
			device_0.SetTextureStageState(0, (TextureStage)3, (TextureArgument)3);
			device_0.SetTextureStageState(0, (TextureStage)4, (TextureOperation)2);
			device_0.SetTextureStageState(0, (TextureStage)5, (TextureArgument)0);
			device_0.SetTextureStageState(1, (TextureStage)1, (TextureOperation)1);
			if (method_244())
			{
				method_242(num);
				device_0.VertexFormat = (VertexFormat)66;
				device_0.SetTexture(0, (BaseTexture)null);
				device_0.SetRenderState((RenderState)27, false);
				device_0.SetRenderState((RenderState)15, false);
				device_0.SetRenderState((RenderState)14, true);
				device_0.SetTextureStageState(0, (TextureStage)1, (TextureOperation)4);
				device_0.SetTextureStageState(0, (TextureStage)2, (TextureArgument)0);
				device_0.SetTextureStageState(0, (TextureStage)3, (TextureArgument)3);
				device_0.SetTextureStageState(0, (TextureStage)4, (TextureOperation)2);
				device_0.SetTextureStageState(0, (TextureStage)5, (TextureArgument)0);
				device_0.SetTextureStageState(1, (TextureStage)1, (TextureOperation)1);
			}
			if (pwMapTrn2File_0 != null)
			{
				if (bool_7)
				{
					device_0.SetRenderState<FillMode>((RenderState)8, (FillMode)2);
				}
				if (bool_12)
				{
					if (list_12.Count > 0)
					{
						method_200(list_12, int_3);
					}
					else
					{
						method_199(vertexBuffer_13, int_36, int_3);
					}
					method_198(num6);
				}
				else if (method_306() && list_12.Count > 0)
				{
					method_210(list_12, bool_37: false);
				}
				else if (vertexBuffer_13 != null && int_36 > 2)
				{
					device_0.SetStreamSource(0, vertexBuffer_13, 0, Struct74.int_1);
					device_0.DrawPrimitives((PrimitiveType)4, 0, int_36 / 3);
				}
				if (bool_7)
				{
					device_0.SetRenderState<FillMode>((RenderState)8, (FillMode)3);
				}
			}
			method_240(num6, flag3);
			device_0.EndScene();
			flag = false;
			device_0.Present();
			method_211();
		}
		catch (SharpDXException ex3)
		{
			SharpDXException ex4 = ex3;
			if (!(ex4.ResultCode == (ResultCode.DeviceLost)) && ex4.ResultCode == (ResultCode.DeviceNotReset))
			{
				method_215();
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

	private void method_240(int int_40, bool bool_37)
	{
		if (method_299())
		{
			if (bool_8)
			{
				device_0.SetRenderState<FillMode>((RenderState)8, (FillMode)2);
			}
			device_0.SetRenderState<Cull>((RenderState)22, (Cull)(bool_37 ? 1 : 3));
			if (bool_12)
			{
				method_200(list_1, int_4);
				method_199(vertexBuffer_3, int_19, int_4);
				method_198(int_40);
			}
			else
			{
				method_210(list_1, bool_37: false);
				if (vertexBuffer_3 != null && int_19 > 2)
				{
					device_0.VertexFormat = (VertexFormat)66;
					device_0.SetTexture(0, (BaseTexture)null);
					device_0.SetStreamSource(0, vertexBuffer_3, 0, Struct74.int_1);
					device_0.DrawPrimitives((PrimitiveType)4, 0, int_19 / 3);
				}
			}
			if (bool_8)
			{
				device_0.SetRenderState<FillMode>((RenderState)8, (FillMode)3);
			}
			if (bool_8 && vertexBuffer_4 != null && int_20 > 1)
			{
				device_0.VertexFormat = (VertexFormat)66;
				device_0.SetTexture(0, (BaseTexture)null);
				device_0.SetStreamSource(0, vertexBuffer_4, 0, Struct74.int_1);
				device_0.DrawPrimitives((PrimitiveType)2, 0, int_20 / 2);
			}
		}
		if (method_301())
		{
			if (bool_8)
			{
				device_0.SetRenderState<FillMode>((RenderState)8, (FillMode)2);
			}
			if (vertexBuffer_10 != null && int_31 > 2 && !bool_12)
			{
				method_245(int_40);
			}
			else if (vertexBuffer_5 != null && int_21 > 2)
			{
				device_0.VertexFormat = (VertexFormat)66;
				device_0.SetTexture(0, (BaseTexture)null);
				device_0.SetRenderState<Cull>((RenderState)22, (Cull)1);
				device_0.SetRenderState((RenderState)27, true);
				device_0.SetRenderState<Blend>((RenderState)19, (Blend)5);
				device_0.SetRenderState<Blend>((RenderState)20, (Blend)6);
				device_0.SetRenderState((RenderState)14, false);
				if (bool_12)
				{
					method_197(int_5);
				}
				device_0.SetStreamSource(0, vertexBuffer_5, 0, Struct74.int_1);
				device_0.DrawPrimitives((PrimitiveType)4, 0, int_21 / 3);
				device_0.SetRenderState((RenderState)14, true);
				device_0.SetRenderState((RenderState)27, false);
				if (bool_12)
				{
					method_198(int_40);
				}
			}
			if (bool_8)
			{
				device_0.SetRenderState<FillMode>((RenderState)8, (FillMode)3);
			}
		}
		if (method_300())
		{
			if (bool_8)
			{
				device_0.SetRenderState<FillMode>((RenderState)8, (FillMode)2);
			}
			device_0.SetRenderState<Cull>((RenderState)22, (Cull)1);
			if (bool_12)
			{
				method_200(list_2, int_6);
				method_198(int_40);
			}
			else
			{
				method_220(list_2);
			}
			if (vertexBuffer_6 != null && int_22 > 1)
			{
				device_0.VertexFormat = (VertexFormat)66;
				device_0.SetTexture(0, (BaseTexture)null);
				if (bool_12)
				{
					method_197(int_6);
				}
				device_0.SetStreamSource(0, vertexBuffer_6, 0, Struct74.int_1);
				device_0.DrawPrimitives((PrimitiveType)2, 0, int_22 / 2);
				if (bool_12)
				{
					method_198(int_40);
				}
			}
			if (bool_8)
			{
				device_0.SetRenderState<FillMode>((RenderState)8, (FillMode)3);
			}
		}
		if (method_304())
		{
			if (bool_8)
			{
				device_0.SetRenderState<FillMode>((RenderState)8, (FillMode)2);
			}
			device_0.SetRenderState<Cull>((RenderState)22, (Cull)1);
			if (bool_12)
			{
				method_200(list_3, int_7);
				method_198(int_40);
			}
			else
			{
				method_269(list_3);
			}
			if (vertexBuffer_7 != null && int_23 > 1)
			{
				device_0.VertexFormat = (VertexFormat)66;
				device_0.SetTexture(0, (BaseTexture)null);
				if (bool_12)
				{
					method_197(int_7);
				}
				device_0.SetStreamSource(0, vertexBuffer_7, 0, Struct74.int_1);
				device_0.DrawPrimitives((PrimitiveType)2, 0, int_23 / 2);
				if (bool_12)
				{
					method_198(int_40);
				}
			}
			if (bool_8)
			{
				device_0.SetRenderState<FillMode>((RenderState)8, (FillMode)3);
			}
		}
		if (method_305() && vertexBuffer_8 != null && int_24 > 1)
		{
			method_230();
			device_0.VertexFormat = (VertexFormat)66;
			device_0.SetTexture(0, (BaseTexture)null);
			device_0.SetRenderState<Cull>((RenderState)22, (Cull)1);
			device_0.SetRenderState((RenderState)27, true);
			device_0.SetRenderState<Blend>((RenderState)19, (Blend)5);
			device_0.SetRenderState<Blend>((RenderState)20, (Blend)6);
			if (bool_12)
			{
				method_197(int_8);
			}
			device_0.SetStreamSource(0, vertexBuffer_8, 0, Struct74.int_1);
			device_0.DrawPrimitives((PrimitiveType)2, 0, int_24 / 2);
			device_0.SetRenderState((RenderState)27, false);
			if (bool_12)
			{
				method_198(int_40);
			}
		}
		if (bool_7 && vertexBuffer_12 != null && int_35 > 1)
		{
			device_0.VertexFormat = (VertexFormat)66;
			device_0.SetTexture(0, (BaseTexture)null);
			device_0.SetStreamSource(0, vertexBuffer_12, 0, Struct74.int_1);
			device_0.DrawPrimitives((PrimitiveType)2, 0, int_35 / 2);
		}
		method_241();
	}

	private void method_241()
	{
		if (bool_34 && vertexBuffer_14 != null && int_37 > 2)
		{
			device_0.VertexFormat = (VertexFormat)66;
			device_0.SetTexture(0, (BaseTexture)null);
			device_0.SetRenderState<Cull>((RenderState)22, (Cull)1);
			device_0.SetRenderState((RenderState)27, true);
			device_0.SetRenderState<Blend>((RenderState)19, (Blend)5);
			device_0.SetRenderState<Blend>((RenderState)20, (Blend)6);
			device_0.SetRenderState((RenderState)14, false);
			device_0.SetStreamSource(0, vertexBuffer_14, 0, Struct74.int_1);
			device_0.DrawPrimitives((PrimitiveType)4, 0, int_37 / 3);
			device_0.SetRenderState((RenderState)14, true);
			device_0.SetRenderState<Cull>((RenderState)22, (Cull)3);
		}
		if (bool_34 && vertexBuffer_15 != null && int_38 > 1)
		{
			device_0.VertexFormat = (VertexFormat)66;
			device_0.SetTexture(0, (BaseTexture)null);
			device_0.SetRenderState((RenderState)27, true);
			device_0.SetRenderState<Blend>((RenderState)19, (Blend)5);
			device_0.SetRenderState<Blend>((RenderState)20, (Blend)6);
			device_0.SetStreamSource(0, vertexBuffer_15, 0, Struct74.int_1);
			device_0.DrawPrimitives((PrimitiveType)2, 0, int_38 / 2);
			device_0.SetRenderState((RenderState)27, false);
		}
		if (vertexBuffer_16 != null && int_39 > 1)
		{
			device_0.VertexFormat = (VertexFormat)66;
			device_0.SetTexture(0, (BaseTexture)null);
			device_0.SetStreamSource(0, vertexBuffer_16, 0, Struct74.int_1);
			device_0.DrawPrimitives((PrimitiveType)2, 0, int_39 / 2);
		}
		if (vertexBuffer_0 != null && int_10 > 1)
		{
			device_0.VertexFormat = (VertexFormat)66;
			device_0.SetTexture(0, (BaseTexture)null);
			device_0.SetRenderState<Cull>((RenderState)22, (Cull)1);
			device_0.SetStreamSource(0, vertexBuffer_0, 0, Struct74.int_1);
			device_0.DrawPrimitives((PrimitiveType)2, 0, int_10 / 2);
		}
		if (vertexBuffer_1 != null && int_11 > 1)
		{
			device_0.VertexFormat = (VertexFormat)66;
			device_0.SetTexture(0, (BaseTexture)null);
			device_0.SetStreamSource(0, vertexBuffer_1, 0, Struct74.int_1);
			device_0.DrawPrimitives((PrimitiveType)2, 0, int_11 / 2);
		}
		if (vertexBuffer_2 != null && int_13 > 1)
		{
			device_0.VertexFormat = (VertexFormat)66;
			device_0.SetTexture(0, (BaseTexture)null);
			device_0.SetRenderState((RenderState)27, true);
			device_0.SetRenderState<Blend>((RenderState)19, (Blend)5);
			device_0.SetRenderState<Blend>((RenderState)20, (Blend)6);
			device_0.SetStreamSource(0, vertexBuffer_2, 0, Struct74.int_1);
			device_0.DrawPrimitives((PrimitiveType)2, 0, int_13 / 2);
			device_0.SetRenderState((RenderState)27, false);
		}
		if (vertexBuffer_11 != null && int_32 > 1)
		{
			device_0.VertexFormat = (VertexFormat)66;
			device_0.SetTexture(0, (BaseTexture)null);
			device_0.SetStreamSource(0, vertexBuffer_11, 0, Struct74.int_1);
			device_0.DrawPrimitives((PrimitiveType)2, 0, int_32 / 2);
		}
	}

	private void method_242(float float_14)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		if (vertexBuffer_9 != null && int_26 >= 3 && pwMapBoxArea_0 != null)
		{
			Vector3 val = method_192();
			Matrix val2 = Matrix.Translation(val);
			device_0.SetTransform((TransformState)256, (val2));
			device_0.SetRenderState((RenderState)7, false);
			device_0.SetRenderState((RenderState)14, false);
			device_0.SetRenderState((RenderState)28, false);
			device_0.SetRenderState((RenderState)137, false);
			device_0.SetRenderState<Cull>((RenderState)22, (Cull)1);
			device_0.SetRenderState((RenderState)27, true);
			device_0.SetRenderState<Blend>((RenderState)19, (Blend)5);
			device_0.SetRenderState<Blend>((RenderState)20, (Blend)6);
			device_0.VertexFormat = (VertexFormat)322;
			device_0.SetTextureStageState(0, (TextureStage)1, (TextureOperation)4);
			device_0.SetTextureStageState(0, (TextureStage)2, (TextureArgument)2);
			device_0.SetTextureStageState(0, (TextureStage)3, (TextureArgument)0);
			device_0.SetTextureStageState(0, (TextureStage)4, (TextureOperation)4);
			device_0.SetTextureStageState(0, (TextureStage)5, (TextureArgument)2);
			device_0.SetTextureStageState(0, (TextureStage)6, (TextureArgument)0);
			device_0.SetTextureStageState(1, (TextureStage)1, (TextureOperation)1);
			device_0.SetSamplerState(0, (SamplerState)1, (TextureAddress)1);
			device_0.SetSamplerState(0, (SamplerState)2, (TextureAddress)1);
			device_0.SetStreamSource(0, vertexBuffer_9, 0, Struct79.int_1);
			float_8 += 0.016f;
			float float_15 = pwMapBoxArea_0.CapTileSpeed * float_8 * 0.01f * float_12;
			float float_16 = pwMapBoxArea_0.CapRotSpeed * float_8 * 0.01f * float_12;
			method_243(0, 6, texture_0, texture_1, float_14, float_15, float_16);
			float float_17 = pwMapBoxArea_0.SkySpeedX * float_8 * 0.005f * float_12;
			float float_18 = pwMapBoxArea_0.SkySpeedY * float_8 * 0.005f * float_12;
			if (int_30 >= 3)
			{
				method_243(int_29, int_30, texture_4, texture_5, float_14, float_17, float_18);
			}
			if (int_28 >= 3)
			{
				method_243(int_27, int_28, texture_2, texture_3, float_14, float_17, float_18);
			}
			device_0.SetTexture(0, (BaseTexture)null);
			device_0.SetRenderState((RenderState)27, false);
			device_0.SetRenderState((RenderState)7, true);
			device_0.SetRenderState((RenderState)14, true);
			device_0.SetRenderState((RenderState)28, checkBox_4 != null && checkBox_4.Checked);
			device_0.SetTransform((TransformState)256, (Matrix.Identity));
		}
	}

	private void method_243(int int_40, int int_41, Texture texture_7, Texture texture_8, float float_14, float float_15, float float_16)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		Texture val = ((float_14 < 0.5f) ? texture_7 : texture_8);
		if (val == null)
		{
			val = texture_7 ?? texture_8;
		}
		if (val != null && int_41 >= 3)
		{
			Matrix val2 = Matrix.Translation(float_15, float_16, 0f);
			device_0.SetTransform((TransformState)16, (val2));
			device_0.SetTextureStageState(0, (TextureStage)11, 0);
			device_0.SetTextureStageState(0, (TextureStage)24, (TextureTransform)2);
			int val3 = (int)(255f * (1f - Math.Abs(float_14 * 2f - 1f) * 0.3f) * float_11);
			val3 = Math.Max(0, Math.Min(255, val3));
			device_0.SetRenderState((RenderState)60, (val3 << 24) | 0xFFFFFF);
			device_0.SetTexture(0, (BaseTexture)(object)val);
			device_0.DrawPrimitives((PrimitiveType)4, int_40, int_41 / 3);
			device_0.SetTextureStageState(0, (TextureStage)24, (TextureTransform)0);
			device_0.SetTransform((TransformState)16, (Matrix.Identity));
		}
	}

	private bool method_244()
	{
		if (pwMapBoxArea_0 != null && vertexBuffer_9 != null)
		{
			return int_26 > 2;
		}
		return false;
	}

	private void method_245(int int_40)
	{
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		if (vertexBuffer_10 != null && int_31 >= 3)
		{
			float_9 += 0.016f;
			device_0.SetRenderState<Cull>((RenderState)22, (Cull)1);
			device_0.SetRenderState((RenderState)27, true);
			device_0.SetRenderState<Blend>((RenderState)19, (Blend)5);
			device_0.SetRenderState<Blend>((RenderState)20, (Blend)6);
			device_0.SetRenderState((RenderState)14, false);
			device_0.VertexFormat = (VertexFormat)322;
			device_0.SetTextureStageState(0, (TextureStage)1, (TextureOperation)4);
			device_0.SetTextureStageState(0, (TextureStage)2, (TextureArgument)2);
			device_0.SetTextureStageState(0, (TextureStage)3, (TextureArgument)0);
			device_0.SetTextureStageState(0, (TextureStage)4, (TextureOperation)4);
			device_0.SetTextureStageState(0, (TextureStage)5, (TextureArgument)2);
			device_0.SetTextureStageState(0, (TextureStage)6, (TextureArgument)0);
			device_0.SetTextureStageState(1, (TextureStage)1, (TextureOperation)4);
			device_0.SetTextureStageState(1, (TextureStage)2, (TextureArgument)1);
			device_0.SetTextureStageState(1, (TextureStage)3, (TextureArgument)3);
			device_0.SetTextureStageState(1, (TextureStage)4, (TextureOperation)2);
			device_0.SetTextureStageState(1, (TextureStage)5, (TextureArgument)1);
			device_0.SetTextureStageState(2, (TextureStage)1, (TextureOperation)1);
			device_0.SetSamplerState(0, (SamplerState)1, (TextureAddress)1);
			device_0.SetSamplerState(0, (SamplerState)2, (TextureAddress)1);
			if (texture_6 == null)
			{
				texture_6 = method_246();
			}
			device_0.SetTexture(0, (BaseTexture)(object)texture_6);
			float num = (float)Math.Sin(float_9 * 0.8f) * 0.15f + float_9 * 0.02f;
			float num2 = (float)Math.Cos(float_9 * 0.6f) * 0.12f + float_9 * 0.015f;
			Matrix val = Matrix.Translation(num, num2, 0f);
			device_0.SetTransform((TransformState)16, (val));
			device_0.SetTextureStageState(0, (TextureStage)11, 0);
			device_0.SetTextureStageState(0, (TextureStage)24, (TextureTransform)2);
			device_0.SetStreamSource(0, vertexBuffer_10, 0, Struct79.int_1);
			device_0.DrawPrimitives((PrimitiveType)4, 0, int_31 / 3);
			device_0.SetTextureStageState(0, (TextureStage)24, (TextureTransform)0);
			device_0.SetTransform((TransformState)16, (Matrix.Identity));
			float num3 = (float)Math.Sin(float_9 * 0.5f + 1.7f) * 0.2f - float_9 * 0.018f;
			float num4 = (float)Math.Cos(float_9 * 0.7f + 2.3f) * 0.18f + float_9 * 0.012f;
			Matrix val2 = Matrix.Translation(num3, num4, 0f);
			device_0.SetTransform((TransformState)16, (val2));
			device_0.SetTextureStageState(0, (TextureStage)24, (TextureTransform)2);
			device_0.DrawPrimitives((PrimitiveType)4, 0, int_31 / 3);
			device_0.SetTextureStageState(0, (TextureStage)24, (TextureTransform)0);
			device_0.SetTransform((TransformState)16, (Matrix.Identity));
			device_0.SetTexture(0, (BaseTexture)null);
			device_0.SetRenderState((RenderState)14, true);
			device_0.SetRenderState((RenderState)27, false);
			device_0.SetTextureStageState(1, (TextureStage)1, (TextureOperation)1);
			device_0.VertexFormat = (VertexFormat)66;
			device_0.SetTextureStageState(0, (TextureStage)1, (TextureOperation)4);
			device_0.SetTextureStageState(0, (TextureStage)2, (TextureArgument)0);
			device_0.SetTextureStageState(0, (TextureStage)3, (TextureArgument)3);
			device_0.SetTextureStageState(0, (TextureStage)4, (TextureOperation)2);
			device_0.SetTextureStageState(0, (TextureStage)5, (TextureArgument)0);
		}
	}

	private unsafe Texture method_246()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		Texture val = new Texture(device_0, 64, 64, 1, (Usage)0, (Format)21, (Pool)1);
		DataRectangle val2 = val.LockRectangle(0, (LockFlags)0);
		byte* ptr = (byte*)(void*)val2.DataPointer;
		for (int i = 0; i < 64; i++)
		{
			for (int j = 0; j < 64; j++)
			{
				float num = (float)j / 64f * 6.28f;
				float num2 = (float)i / 64f * 6.28f;
				float num3 = (float)(Math.Sin(num * 3f + num2 * 2f) * 0.3 + Math.Sin(num + num2 * 4f) * 0.2 + 0.5);
				byte b = (byte)(180f + num3 * 75f);
				byte b2 = (byte)(200f + num3 * 55f);
				byte b3 = (byte)(220f + num3 * 35f);
				byte b4 = (byte)(140f + num3 * 60f);
				int num4 = i * val2.Pitch + j * 4;
				ptr[num4] = b;
				ptr[num4 + 1] = b2;
				ptr[num4 + 2] = b3;
				ptr[num4 + 3] = b4;
			}
		}
		val.UnlockRectangle(0);
		return val;
	}

	private static List<string> smethod_29(string string_6)
	{
		List<string> list = new List<string>(8);
		if (!string.IsNullOrWhiteSpace(string_6) && File.Exists(string_6))
		{
			string text = System.IO.Path.GetDirectoryName(string_6) ?? string.Empty;
			if (Directory.Exists(text))
			{
				list.Add(text);
				DirectoryInfo directoryInfo = new DirectoryInfo(text);
				for (int i = 0; i < 3; i++)
				{
					if (directoryInfo.Parent == null)
					{
						break;
					}
					directoryInfo = directoryInfo.Parent;
					list.Add(directoryInfo.FullName);
				}
			}
			return list;
		}
		return list;
	}

	private static string smethod_30(string string_6)
	{
		string text = (string_6 ?? string.Empty).Replace('/', System.IO.Path.DirectorySeparatorChar).Replace('\\', System.IO.Path.DirectorySeparatorChar).Trim();
		while (text.StartsWith(Class16.smethod_0(1648928036) + System.IO.Path.DirectorySeparatorChar, StringComparison.Ordinal))
		{
			text = text.Substring(2);
		}
		return text.TrimStart(System.IO.Path.DirectorySeparatorChar);
	}

	private static bool smethod_31(string string_6)
	{
		if (!string.IsNullOrEmpty(string_6))
		{
			return string_6.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0;
		}
		return false;
	}

	private static string[] smethod_32(string string_6)
	{
		string text = smethod_30(string_6);
		if (string.IsNullOrWhiteSpace(text))
		{
			return Array.Empty<string>();
		}
		string extension = System.IO.Path.GetExtension(text);
		if (!string.IsNullOrWhiteSpace(extension))
		{
			string text2 = System.IO.Path.ChangeExtension(text, null) ?? text;
			return new string[6]
			{
				text,
				text2 + Class16.smethod_0(1648904847),
				text2 + Class16.smethod_0(1649008314),
				text2 + Class16.smethod_0(1648904836),
				text2 + Class16.smethod_0(1649008311),
				text2 + Class16.smethod_0(1649008300)
			}.Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
		}
		return new string[6]
		{
			text + Class16.smethod_0(1648904847),
			text + Class16.smethod_0(1649008314),
			text + Class16.smethod_0(1648904836),
			text + Class16.smethod_0(1649008311),
			text + Class16.smethod_0(1649008300),
			text
		};
	}

	private IEnumerable<string> method_247()
	{
		List<string> list = new List<string>(12);
		HashSet<string> hashSet_ = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		List<string> list2 = new List<string>(5);
		PwMapTrn2File pwMapTrn2File = pwMapTrn2File_0;
		object obj;
		if (pwMapTrn2File == null)
		{
			obj = null;
		}
		else
		{
			obj = pwMapTrn2File.MapRootPath;
			if (obj != null)
			{
				goto IL_0035;
			}
		}
		obj = string.Empty;
		goto IL_0035;
		IL_0035:
		string text = (string)obj;
		if (Directory.Exists(text))
		{
			list2.Add(text);
			DirectoryInfo directoryInfo = new DirectoryInfo(text);
			if (string.Equals(directoryInfo.Parent?.Name, Class16.smethod_0(1649094124), StringComparison.OrdinalIgnoreCase) && directoryInfo.Parent?.Parent != null)
			{
				list2.Add(directoryInfo.Parent.Parent.FullName);
			}
			if (directoryInfo.Parent != null)
			{
				list2.Add(directoryInfo.Parent.FullName);
			}
		}
		List<string> list3 = new List<string>(3);
		string text2 = (textBox_78.Text ?? string.Empty).Trim();
		if (Directory.Exists(text2))
		{
			list3.Add(text2);
			DirectoryInfo directoryInfo2 = new DirectoryInfo(text2);
			if (directoryInfo2.Parent != null)
			{
				list3.Add(directoryInfo2.Parent.FullName);
			}
		}
		if (method_307())
		{
			smethod_33(list, hashSet_, list2);
			smethod_33(list, hashSet_, list3);
		}
		else
		{
			smethod_33(list, hashSet_, list3);
			smethod_33(list, hashSet_, list2);
		}
		return list;
	}

	private static void smethod_33(List<string> list_13, HashSet<string> hashSet_1, IEnumerable<string> ienumerable_0)
	{
		foreach (string item in ienumerable_0)
		{
			if (!string.IsNullOrWhiteSpace(item) && Directory.Exists(item))
			{
				string fullPath;
				try
				{
					fullPath = System.IO.Path.GetFullPath(item);
				}
				catch
				{
					continue;
				}
				if (hashSet_1.Add(fullPath))
				{
					list_13.Add(fullPath);
				}
			}
		}
	}

	private IReadOnlyList<string> method_248()
	{
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		string text = method_252();
		if (!string.IsNullOrWhiteSpace(text) && File.Exists(text))
		{
			IReadOnlyList<string> readOnlyList = PwMapEcbsdFile.LoadBsdataPaths(text);
			for (int i = 0; i < readOnlyList.Count; i++)
			{
				string text2 = method_249(readOnlyList[i]);
				if (!string.IsNullOrWhiteSpace(text2) && File.Exists(text2))
				{
					hashSet.Add(text2);
				}
			}
		}
		List<string> list = smethod_14(pwMapTrn2File_0.MapRootPath);
		for (int j = 0; j < list.Count; j++)
		{
			hashSet.Add(list[j]);
		}
		return hashSet.ToList();
	}

	private string method_249(string string_6)
	{
		if (string.IsNullOrWhiteSpace(string_6))
		{
			return string.Empty;
		}
		string text = smethod_30(string_6);
		if (System.IO.Path.IsPathRooted(text) && File.Exists(text))
		{
			return text;
		}
		string text2 = method_147();
		foreach (string item in method_247())
		{
			string[] array = new string[3]
			{
				System.IO.Path.Combine(item, text),
				System.IO.Path.Combine(item, Class16.smethod_0(1649094124), text2, text),
				System.IO.Path.Combine(item, text2, text)
			};
			for (int i = 0; i < array.Length; i++)
			{
				if (File.Exists(array[i]))
				{
					return array[i];
				}
			}
		}
		if (!string.IsNullOrWhiteSpace(pwMapTrn2File_0?.MapRootPath))
		{
			string mapRootPath = pwMapTrn2File_0.MapRootPath;
			string fileName = System.IO.Path.GetFileName(text);
			try
			{
				string text3 = Directory.EnumerateFiles(mapRootPath, fileName, SearchOption.AllDirectories).FirstOrDefault();
				if (!string.IsNullOrWhiteSpace(text3))
				{
					return text3;
				}
			}
			catch
			{
			}
		}
		string text4 = method_250(text, text2);
		if (!string.IsNullOrWhiteSpace(text4))
		{
			return text4;
		}
		return string.Empty;
	}

	private string method_250(string string_6, string string_7)
	{
		if (string.IsNullOrWhiteSpace(string_6))
		{
			return string.Empty;
		}
		string text = PwMapAssetProvider.NormalizePckPath(string_6);
		string fileName = System.IO.Path.GetFileName(text);
		List<string> list = new List<string>(16);
		list.Add(text);
		list.Add(Class16.smethod_0(1649116763) + text);
		list.Add(Class16.smethod_0(1649207654) + text);
		if (!string.IsNullOrWhiteSpace(string_7))
		{
			list.Add(Class16.smethod_0(1649093224) + string_7 + Class16.smethod_0(1648927580) + text);
			list.Add(Class16.smethod_0(1649116763) + string_7 + Class16.smethod_0(1648927580) + text);
			list.Add(Class16.smethod_0(1649093268) + string_7 + Class16.smethod_0(1648927580) + text);
			list.Add(Class16.smethod_0(1649093224) + string_7 + Class16.smethod_0(1649207668) + text);
			list.Add(Class16.smethod_0(1649093268) + string_7 + Class16.smethod_0(1649207668) + text);
		}
		if (!string.IsNullOrWhiteSpace(fileName))
		{
			if (!string.IsNullOrWhiteSpace(string_7))
			{
				list.Add(Class16.smethod_0(1649093224) + string_7 + Class16.smethod_0(1649207668) + fileName);
				list.Add(Class16.smethod_0(1649093268) + string_7 + Class16.smethod_0(1649207668) + fileName);
			}
			list.Add(Class16.smethod_0(1649207675) + fileName);
			list.Add(Class16.smethod_0(1649207654) + fileName);
		}
		return PwMapAssetProvider.ResolveFirstExistingPckPath(list);
	}

	private string method_251()
	{
		if (pwMapTrn2File_0 != null && !string.IsNullOrWhiteSpace(pwMapTrn2File_0.MapRootPath) && Directory.Exists(pwMapTrn2File_0.MapRootPath))
		{
			string text = method_147();
			string text2 = System.IO.Path.Combine(pwMapTrn2File_0.MapRootPath, text + Class16.smethod_0(1649093324));
			if (File.Exists(text2))
			{
				return text2;
			}
			try
			{
				return Directory.EnumerateFiles(pwMapTrn2File_0.MapRootPath, Class16.smethod_0(1649093350), SearchOption.AllDirectories).FirstOrDefault() ?? string.Empty;
			}
			catch
			{
				return string.Empty;
			}
		}
		return string.Empty;
	}

	private string method_252()
	{
		if (pwMapTrn2File_0 != null && !string.IsNullOrWhiteSpace(pwMapTrn2File_0.MapRootPath) && Directory.Exists(pwMapTrn2File_0.MapRootPath))
		{
			string text = method_147();
			string text2 = System.IO.Path.Combine(pwMapTrn2File_0.MapRootPath, text + Class16.smethod_0(1649093329));
			if (File.Exists(text2))
			{
				return text2;
			}
			try
			{
				return Directory.EnumerateFiles(pwMapTrn2File_0.MapRootPath, Class16.smethod_0(1649093364), SearchOption.AllDirectories).FirstOrDefault() ?? string.Empty;
			}
			catch
			{
				return string.Empty;
			}
		}
		return string.Empty;
	}

	private void method_253(List<Struct74> list_13, ref VertexBuffer vertexBuffer_17, ref int int_40)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		try
		{
			VertexBuffer obj = vertexBuffer_17;
			if (obj != null)
			{
				((DisposeBase)obj).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_17 = null;
		int_40 = 0;
		if (device_0 != null && list_13 != null && list_13.Count > 1)
		{
			int_40 = list_13.Count;
			vertexBuffer_17 = new VertexBuffer(device_0, int_40 * Struct74.int_1, (Usage)8, (VertexFormat)0, (Pool)1);
			DataStream val = vertexBuffer_17.Lock(0, 0, (LockFlags)0);
			val.WriteRange<Struct74>(list_13.ToArray());
			vertexBuffer_17.Unlock();
		}
	}

	private void method_254(List<Class313> list_13, Dictionary<string, List<Struct79>> dictionary_7, bool bool_37)
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		for (int i = 0; i < list_13.Count; i++)
		{
			try
			{
				VertexBuffer obj = list_13[i].vertexBuffer_0;
				if (obj != null)
				{
					((DisposeBase)obj).Dispose();
				}
			}
			catch
			{
			}
		}
		list_13.Clear();
		if (device_0 == null || dictionary_7.Count == 0)
		{
			return;
		}
		foreach (KeyValuePair<string, List<Struct79>> item in dictionary_7)
		{
			Texture val = method_286(item.Key);
			List<Struct79> value = item.Value;
			if (val != null && value != null && value.Count > 2)
			{
				smethod_34(value, out var vector3_, out var float_);
				Class313 @class = new Class313
				{
					texture_0 = val,
					int_0 = value.Count,
					bool_0 = bool_37,
					vector3_0 = vector3_,
					float_0 = float_,
					vertexBuffer_0 = new VertexBuffer(device_0, value.Count * Struct79.int_1, (Usage)8, (VertexFormat)0, (Pool)1)
				};
				DataStream val2 = @class.vertexBuffer_0.Lock(0, 0, (LockFlags)0);
				val2.WriteRange<Struct79>(value.ToArray());
				@class.vertexBuffer_0.Unlock();
				list_13.Add(@class);
			}
		}
	}

	private static void smethod_34(List<Struct79> list_13, out Vector3 vector3_5, out float float_14)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = default(Vector3);
		val = new Vector3(float.MaxValue);
		Vector3 val2 = default(Vector3);
		val2 = new Vector3(float.MinValue);
		for (int i = 0; i < list_13.Count; i++)
		{
			Vector3 val3 = list_13[i].vector3_0;
			if (val3.X < val.X)
			{
				val.X = val3.X;
			}
			if (val3.Y < val.Y)
			{
				val.Y = val3.Y;
			}
			if (val3.Z < val.Z)
			{
				val.Z = val3.Z;
			}
			if (val3.X > val2.X)
			{
				val2.X = val3.X;
			}
			if (val3.Y > val2.Y)
			{
				val2.Y = val3.Y;
			}
			if (val3.Z > val2.Z)
			{
				val2.Z = val3.Z;
			}
		}
		vector3_5 = (val + val2) * 0.5f;
		float_14 = Vector3.Distance(vector3_5, val2);
	}

	private IReadOnlyList<Class314> method_255()
	{
		return list_4;
	}

	private IReadOnlyList<Class314> method_256()
	{
		return list_5;
	}

	private IReadOnlyList<Class314> method_257()
	{
		return list_6;
	}

	private IReadOnlyList<Class314> method_258()
	{
		return list_7;
	}

	private IReadOnlyList<Class314> method_259()
	{
		return list_8;
	}

	private void method_260()
	{
		method_261();
	}

	private void method_261()
	{
		if (device_0 != null && pwMapTrn2File_0 != null)
		{
			if (bool_29)
			{
				return;
			}
			bool_29 = true;
			try
			{
				method_262();
				if (method_299())
				{
					pwMapDebugLogger_0?.BeginPhase(Class16.smethod_0(1649207696));
					method_278();
					pwMapDebugLogger_0?.EndPhase();
				}
				if (method_301())
				{
					pwMapDebugLogger_0?.BeginPhase(Class16.smethod_0(1648976466));
					method_179(Class16.smethod_0(1649207712));
					Application.DoEvents();
					method_264();
					method_290();
					pwMapDebugLogger_0?.EndPhase();
				}
				if (method_300())
				{
					pwMapDebugLogger_0?.BeginPhase(Class16.smethod_0(1649208715));
					method_179(Class16.smethod_0(1649207745));
					Application.DoEvents();
					method_265();
					pwMapDebugLogger_0?.EndPhase();
				}
				if (method_304())
				{
					pwMapDebugLogger_0?.BeginPhase(Class16.smethod_0(1649141693));
					method_179(Class16.smethod_0(1649207778));
					Application.DoEvents();
					method_271();
					pwMapDebugLogger_0?.EndPhase();
				}
				if (method_305())
				{
					pwMapDebugLogger_0?.BeginPhase(Class16.smethod_0(1649202689));
					method_179(Class16.smethod_0(1649202710));
					Application.DoEvents();
					method_276();
					pwMapDebugLogger_0?.EndPhase();
				}
				method_179(Class16.smethod_0(1649202743));
				Application.DoEvents();
				method_280();
				method_325();
				method_321();
				return;
			}
			finally
			{
				bool_29 = false;
			}
		}
		method_262();
	}

	private void method_262()
	{
		method_263(bool_37: false);
	}

	private void method_263(bool bool_37)
	{
		try
		{
			VertexBuffer obj = vertexBuffer_3;
			if (obj != null)
			{
				((DisposeBase)obj).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_3 = null;
		int_19 = 0;
		try
		{
			VertexBuffer obj3 = vertexBuffer_4;
			if (obj3 != null)
			{
				((DisposeBase)obj3).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_4 = null;
		int_20 = 0;
		try
		{
			VertexBuffer obj5 = vertexBuffer_5;
			if (obj5 != null)
			{
				((DisposeBase)obj5).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_5 = null;
		int_21 = 0;
		try
		{
			VertexBuffer obj7 = vertexBuffer_6;
			if (obj7 != null)
			{
				((DisposeBase)obj7).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_6 = null;
		int_22 = 0;
		try
		{
			VertexBuffer obj9 = vertexBuffer_7;
			if (obj9 != null)
			{
				((DisposeBase)obj9).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_7 = null;
		int_23 = 0;
		try
		{
			VertexBuffer obj11 = vertexBuffer_8;
			if (obj11 != null)
			{
				((DisposeBase)obj11).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_8 = null;
		int_24 = 0;
		method_285();
		method_292();
		try
		{
			Texture obj13 = texture_6;
			if (obj13 != null)
			{
				((DisposeBase)obj13).Dispose();
			}
		}
		catch
		{
		}
		texture_6 = null;
		for (int i = 0; i < list_1.Count; i++)
		{
			try
			{
				VertexBuffer obj15 = list_1[i].vertexBuffer_0;
				if (obj15 != null)
				{
					((DisposeBase)obj15).Dispose();
				}
			}
			catch
			{
			}
		}
		list_1.Clear();
		for (int j = 0; j < list_2.Count; j++)
		{
			try
			{
				VertexBuffer obj17 = list_2[j].vertexBuffer_0;
				if (obj17 != null)
				{
					((DisposeBase)obj17).Dispose();
				}
			}
			catch
			{
			}
		}
		list_2.Clear();
		for (int k = 0; k < list_3.Count; k++)
		{
			try
			{
				VertexBuffer obj19 = list_3[k].vertexBuffer_0;
				if (obj19 != null)
				{
					((DisposeBase)obj19).Dispose();
				}
			}
			catch
			{
			}
		}
		list_3.Clear();
		if (bool_37)
		{
			foreach (Texture value in dictionary_1.Values)
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
			dictionary_1.Clear();
			dictionary_2.Clear();
			dictionary_3.Clear();
			dictionary_4.Clear();
		}
		list_4.Clear();
		list_5.Clear();
		list_6.Clear();
		list_7.Clear();
		list_8.Clear();
	}

	private void method_264()
	{
		list_5.Clear();
		List<Struct74> list = new List<Struct74>(131072);
		IReadOnlyList<string> readOnlyList = method_248();
		pwMapDebugLogger_0?.Log(string.Format(Class16.smethod_0(1649202761), readOnlyList.Count));
		int num = 0;
		for (int i = 0; i < readOnlyList.Count; i++)
		{
			PwMapBsdataFile pwMapBsdataFile = PwMapBsdataFile.Load(readOnlyList[i]);
			if (pwMapBsdataFile?.WaterBlocks == null)
			{
				pwMapDebugLogger_0?.LogDetail(string.Format(Class16.smethod_0(1649202799), i, readOnlyList[i]));
				continue;
			}
			pwMapDebugLogger_0?.LogDetail(string.Format(Class16.smethod_0(1649202860), i, readOnlyList[i], pwMapBsdataFile.WaterBlocks.Count));
			num += pwMapBsdataFile.WaterBlocks.Count;
			for (int j = 0; j < pwMapBsdataFile.WaterBlocks.Count; j++)
			{
				PwMapBsdataFile.WaterBlockEntry waterBlockEntry_ = pwMapBsdataFile.WaterBlocks[j];
				method_267(list, waterBlockEntry_);
			}
		}
		method_253(list, ref vertexBuffer_5, ref int_21);
		pwMapDebugLogger_0?.LogWaterSummary(readOnlyList.Count, num, list.Count);
	}

	private void method_265()
	{
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		list_6.Clear();
		Dictionary<string, List<Struct79>> dictionary = new Dictionary<string, List<Struct79>>(StringComparer.OrdinalIgnoreCase);
		List<Struct74> list = new List<Struct74>(65536);
		string text = method_251();
		if (string.IsNullOrWhiteSpace(text))
		{
			pwMapDebugLogger_0?.Log(Class16.smethod_0(1649202915));
			method_253(list, ref vertexBuffer_6, ref int_22);
			return;
		}
		PwMapEcwldTreeFile.SceneData sceneData = PwMapEcwldTreeFile.LoadSceneData(text);
		if (sceneData.TreeInstances.Count == 0)
		{
			pwMapDebugLogger_0?.Log(Class16.smethod_0(1649202998));
			method_253(list, ref vertexBuffer_6, ref int_22);
			return;
		}
		pwMapDebugLogger_0?.Log(string.Format(Class16.smethod_0(1649087033), sceneData.TreeTypes.Count, sceneData.TreeInstances.Count));
		Dictionary<int, string> dictionary2 = new Dictionary<int, string>();
		int num = 0;
		for (int i = 0; i < sceneData.TreeTypes.Count; i++)
		{
			PwMapEcwldTreeFile.TreeTypeInfo treeTypeInfo = sceneData.TreeTypes[i];
			string text2 = method_287(treeTypeInfo);
			if (method_286(text2) != null)
			{
				dictionary2[treeTypeInfo.Index] = text2;
			}
		}
		for (int j = 0; j < sceneData.TreeInstances.Count; j++)
		{
			PwMapEcwldTreeFile.TreeInstance treeInstance = sceneData.TreeInstances[j];
			Vector3 position = treeInstance.Position;
			list_6.Add(new Class314
			{
				string_0 = string.Format(Class16.smethod_0(1649203037), j + 1, treeInstance.Type),
				vector3_0 = position,
				vector3_1 = new Vector3(2.2f, 3.5f, 2.2f),
				string_1 = (dictionary2.TryGetValue(treeInstance.Type, out var value) ? value : string.Empty)
			});
			if (dictionary2.TryGetValue(treeInstance.Type, out var value2))
			{
				if (!dictionary.TryGetValue(value2, out var value3))
				{
					value3 = (dictionary[value2] = new List<Struct79>(65536));
				}
				smethod_37(value3, position, 2.2f, 6.8f, -1);
				num++;
			}
			else
			{
				smethod_39(list, position, -11677588);
			}
		}
		method_254(list_2, dictionary, bool_37: true);
		method_253(list, ref vertexBuffer_6, ref int_22);
		pwMapDebugLogger_0?.LogFloraSummary(sceneData.TreeTypes.Count, sceneData.TreeInstances.Count, num, list.Count / 6);
	}

	private void method_266()
	{
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		List<Struct74> list_ = new List<Struct74>(16384);
		if (pwMapTrn2File_0 != null && pwMapTrn2File_0.TotalSectors > 0 && pwMapTrn2File_0.SectorsWide > 0 && pwMapTrn2File_0.SectorsHigh > 0)
		{
			string text = method_251();
			string text2 = method_252();
			if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2))
			{
				PwMapEcwldCollisionIndex pwMapEcwldCollisionIndex = PwMapEcwldCollisionIndex.Build(text, text2, pwMapTrn2File_0);
				float num = pwMapTrn2File_0.Width / (float)pwMapTrn2File_0.SectorsWide;
				float num2 = pwMapTrn2File_0.Height / (float)pwMapTrn2File_0.SectorsHigh;
				float num3 = (0f - pwMapTrn2File_0.Width) * 0.5f;
				float num4 = pwMapTrn2File_0.Height * 0.5f;
				Math.Max(3f, Math.Min(num, num2) * 0.06f);
				for (int i = 0; i < pwMapTrn2File_0.TotalSectors; i++)
				{
					bool flag = false;
					using (IEnumerator<int> enumerator = pwMapEcwldCollisionIndex.GetSectorExportIds(i).GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							_ = enumerator.Current;
							flag = true;
						}
					}
					if (flag)
					{
						int num5 = i / pwMapTrn2File_0.SectorsWide;
						int num6 = i % pwMapTrn2File_0.SectorsWide;
						float num7 = num3 + (float)num6 * num + num * 0.5f;
						float num8 = num4 - (float)num5 * num2 - num2 * 0.5f;
						float num9 = method_364(i) + 0.5f;
						smethod_39(list_, new Vector3(num7, num9, 0f - num8), -9775617);
					}
				}
				method_253(list_, ref vertexBuffer_7, ref int_23);
			}
			else
			{
				method_253(list_, ref vertexBuffer_7, ref int_23);
			}
		}
		else
		{
			method_253(list_, ref vertexBuffer_7, ref int_23);
		}
	}

	private void method_267(List<Struct74> list_13, PwMapBsdataFile.WaterBlockEntry waterBlockEntry_0)
	{
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		if (waterBlockEntry_0 == null || waterBlockEntry_0.Width <= 0 || waterBlockEntry_0.Height <= 0 || !(waterBlockEntry_0.GridSize > 0f))
		{
			return;
		}
		float num = Math.Max(0f, (float)waterBlockEntry_0.Width * waterBlockEntry_0.GridSize * 0.5f);
		float num2 = Math.Max(0f, (float)waterBlockEntry_0.Height * waterBlockEntry_0.GridSize * 0.5f);
		if (num <= 0.01f || !(num2 > 0.01f))
		{
			return;
		}
		float num3 = ((Math.Abs(waterBlockEntry_0.WaterHeight) > 0.0001f) ? waterBlockEntry_0.WaterHeight : waterBlockEntry_0.WorldY) + 0.08f;
		list_5.Add(new Class314
		{
			string_0 = string.Format(Class16.smethod_0(1649203062), waterBlockEntry_0.AreaId),
			vector3_0 = new Vector3(waterBlockEntry_0.WorldX, num3, 0f - waterBlockEntry_0.WorldZ),
			vector3_1 = smethod_49(new Vector3(num, 1.2f, num2), 1f)
		});
		int int_ = (waterBlockEntry_0.WaterColor & 0xFFFFFF) | -2013265920;
		float num4 = waterBlockEntry_0.WorldX - num;
		float num5 = waterBlockEntry_0.WorldZ - num2;
		if (waterBlockEntry_0.AboveGround != null && waterBlockEntry_0.AboveGround.Length == waterBlockEntry_0.Width * waterBlockEntry_0.Height)
		{
			for (int i = 0; i < waterBlockEntry_0.Height; i++)
			{
				for (int j = 0; j < waterBlockEntry_0.Width; j++)
				{
					int num6 = i * waterBlockEntry_0.Width + j;
					if (waterBlockEntry_0.AboveGround[waterBlockEntry_0.AboveGround.Length - 1 - num6] == 1)
					{
						float float_ = num4 + (float)j * waterBlockEntry_0.GridSize;
						float float_2 = num5 + (float)i * waterBlockEntry_0.GridSize;
						smethod_35(list_13, float_, num3, float_2, waterBlockEntry_0.GridSize, int_);
						if (list_13.Count > 1500000)
						{
							return;
						}
					}
				}
			}
		}
		else
		{
			smethod_36(list_13, num4, num3, num5, (float)waterBlockEntry_0.Width * waterBlockEntry_0.GridSize, (float)waterBlockEntry_0.Height * waterBlockEntry_0.GridSize, int_);
		}
	}

	private static void smethod_35(List<Struct74> list_13, float float_14, float float_15, float float_16, float float_17, int int_40)
	{
		smethod_36(list_13, float_14, float_15, float_16, float_17, float_17, int_40);
	}

	private static void smethod_36(List<Struct74> list_13, float float_14, float float_15, float float_16, float float_17, float float_18, int int_40)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = default(Vector3);
		val = new Vector3(float_14, float_15, 0f - float_16);
		Vector3 val2 = default(Vector3);
		val2 = new Vector3(float_14 + float_17, float_15, 0f - float_16);
		Vector3 val3 = default(Vector3);
		val3 = new Vector3(float_14 + float_17, float_15, 0f - (float_16 + float_18));
		Vector3 val4 = default(Vector3);
		val4 = new Vector3(float_14, float_15, 0f - (float_16 + float_18));
		list_13.Add(new Struct74
		{
			vector3_0 = val,
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val2,
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val3,
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val,
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val3,
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val4,
			int_0 = int_40
		});
	}

	private static void smethod_37(List<Struct79> list_13, Vector3 vector3_5, float float_14, float float_15, int int_40)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = vector3_5 + new Vector3(0f, float_15, 0f);
		smethod_38(list_13, new Vector3(vector3_5.X - float_14, vector3_5.Y, vector3_5.Z), new Vector3(vector3_5.X + float_14, vector3_5.Y, vector3_5.Z), new Vector3(val.X - float_14, val.Y, val.Z), new Vector3(val.X + float_14, val.Y, val.Z), int_40);
		smethod_38(list_13, new Vector3(vector3_5.X, vector3_5.Y, vector3_5.Z - float_14), new Vector3(vector3_5.X, vector3_5.Y, vector3_5.Z + float_14), new Vector3(val.X, val.Y, val.Z - float_14), new Vector3(val.X, val.Y, val.Z + float_14), int_40);
	}

	private static void smethod_38(List<Struct79> list_13, Vector3 vector3_5, Vector3 vector3_6, Vector3 vector3_7, Vector3 vector3_8, int int_40)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		smethod_50(list_13, vector3_5, new Vector2(0f, 1f), int_40);
		smethod_50(list_13, vector3_7, new Vector2(0f, 0f), int_40);
		smethod_50(list_13, vector3_8, new Vector2(1f, 0f), int_40);
		smethod_50(list_13, vector3_5, new Vector2(0f, 1f), int_40);
		smethod_50(list_13, vector3_8, new Vector2(1f, 0f), int_40);
		smethod_50(list_13, vector3_6, new Vector2(1f, 1f), int_40);
	}

	private static void smethod_39(List<Struct74> list_13, Vector3 vector3_5, int int_40)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		float num = 1.8f;
		list_13.Add(new Struct74
		{
			vector3_0 = vector3_5 + new Vector3(-1.8f, 0f, 0f),
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = vector3_5 + new Vector3(num, 0f, 0f),
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = vector3_5 + new Vector3(0f, 0f, -1.8f),
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = vector3_5 + new Vector3(0f, 0f, num),
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = vector3_5,
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = vector3_5 + new Vector3(0f, 4.2f, 0f),
			int_0 = int_40
		});
	}

	private void method_268(List<Class313> list_13, Dictionary<string, List<Struct79>> dictionary_7, Dictionary<string, Struct75> dictionary_8)
	{
		List<string> list = new List<string>(dictionary_7.Keys);
		int num = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (num >= list_13.Count)
			{
				break;
			}
			string key = list[i];
			if (!dictionary_8.TryGetValue(key, out var value))
			{
				num++;
				continue;
			}
			if (num < list_13.Count)
			{
				Class313 @class = list_13[num];
				@class.int_1 = value.int_1;
				@class.int_2 = value.int_2;
				@class.float_1 = value.float_3;
				@class.float_2 = (value.bool_1 ? value.float_4 : 0f);
				@class.float_3 = (value.bool_1 ? value.float_5 : 0f);
				@class.int_3 = value.int_3;
				@class.int_4 = value.int_4;
			}
			num++;
		}
		int_25 = Environment.TickCount;
	}

	private void method_269(IReadOnlyList<Class313> ireadOnlyList_0)
	{
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		if (device_0 == null || ireadOnlyList_0 == null || ireadOnlyList_0.Count == 0)
		{
			return;
		}
		if (int_25 == 0)
		{
			int_25 = Environment.TickCount;
		}
		float num = (float)(Environment.TickCount - int_25) / 1000f;
		float num2 = 0.85f + 0.15f * (float)Math.Sin(num * 2f);
		byte b = (byte)(int)(num2 * 255f);
		int num3 = -16777216 | (b << 16) | (b << 8) | b;
		device_0.VertexFormat = (VertexFormat)322;
		device_0.SetTextureStageState(0, (TextureStage)1, (TextureOperation)4);
		device_0.SetTextureStageState(0, (TextureStage)2, (TextureArgument)2);
		device_0.SetTextureStageState(0, (TextureStage)3, (TextureArgument)0);
		device_0.SetTextureStageState(0, (TextureStage)4, (TextureOperation)4);
		device_0.SetTextureStageState(0, (TextureStage)5, (TextureArgument)2);
		device_0.SetTextureStageState(0, (TextureStage)6, (TextureArgument)0);
		device_0.SetTextureStageState(1, (TextureStage)1, (TextureOperation)4);
		device_0.SetTextureStageState(1, (TextureStage)2, (TextureArgument)1);
		device_0.SetTextureStageState(1, (TextureStage)3, (TextureArgument)3);
		device_0.SetTextureStageState(1, (TextureStage)4, (TextureOperation)2);
		device_0.SetTextureStageState(1, (TextureStage)5, (TextureArgument)1);
		device_0.SetTextureStageState(2, (TextureStage)1, (TextureOperation)1);
		device_0.SetRenderState((RenderState)60, num3);
		device_0.SetRenderState((RenderState)27, true);
		device_0.SetRenderState((RenderState)15, true);
		device_0.SetRenderState<Blend>((RenderState)19, (Blend)5);
		device_0.SetRenderState<Blend>((RenderState)20, (Blend)6);
		device_0.SetRenderState((RenderState)24, 20);
		device_0.SetRenderState<Compare>((RenderState)25, (Compare)7);
		device_0.SetRenderState((RenderState)14, false);
		device_0.SetSamplerState(0, (SamplerState)1, (TextureAddress)1);
		device_0.SetSamplerState(0, (SamplerState)2, (TextureAddress)1);
		for (int i = 0; i < ireadOnlyList_0.Count; i++)
		{
			Class313 @class = ireadOnlyList_0[i];
			if (@class?.vertexBuffer_0 != null && @class.texture_0 != null && @class.int_0 > 2 && (!(@class.float_0 > 0f) || method_209(@class.vector3_0, @class.float_0)))
			{
				Blend val = smethod_40(@class.int_3, (Blend)5);
				Blend val2 = smethod_40(@class.int_4, (Blend)6);
				device_0.SetRenderState<Blend>((RenderState)19, val);
				device_0.SetRenderState<Blend>((RenderState)20, val2);
				if (@class.method_0())
				{
					method_270(@class, num);
				}
				else
				{
					device_0.SetTextureStageState(0, (TextureStage)24, 0);
				}
				device_0.SetTexture(0, (BaseTexture)(object)@class.texture_0);
				device_0.SetStreamSource(0, @class.vertexBuffer_0, 0, Struct79.int_1);
				device_0.DrawPrimitives((PrimitiveType)4, 0, @class.int_0 / 3);
			}
		}
		device_0.SetTextureStageState(0, (TextureStage)24, 0);
		device_0.SetTexture(0, (BaseTexture)null);
		device_0.SetTextureStageState(1, (TextureStage)1, (TextureOperation)1);
		device_0.SetRenderState((RenderState)27, false);
		device_0.SetRenderState((RenderState)15, false);
		device_0.SetRenderState((RenderState)14, true);
		device_0.VertexFormat = (VertexFormat)66;
		device_0.SetTextureStageState(0, (TextureStage)1, (TextureOperation)4);
		device_0.SetTextureStageState(0, (TextureStage)2, (TextureArgument)0);
		device_0.SetTextureStageState(0, (TextureStage)3, (TextureArgument)3);
		device_0.SetTextureStageState(0, (TextureStage)4, (TextureOperation)2);
		device_0.SetTextureStageState(0, (TextureStage)5, (TextureArgument)0);
	}

	private void method_270(Class313 class313_0, float float_14)
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		int num = Math.Max(1, class313_0.int_1);
		int num2 = Math.Max(1, class313_0.int_2);
		float num3 = 0f;
		float num4 = 0f;
		if (num > 1 || num2 > 1)
		{
			float num5 = ((class313_0.float_1 > 0f) ? class313_0.float_1 : 0.1f);
			int num6 = num * num2;
			int num7 = (int)(float_14 / num5) % num6;
			int num8 = num7 % num2;
			int num9 = num7 / num2;
			num3 = (float)num8 / (float)num2;
			num4 = (float)num9 / (float)num;
		}
		if (class313_0.float_2 != 0f)
		{
			num3 += float_14 * class313_0.float_2;
		}
		if (class313_0.float_3 != 0f)
		{
			num4 += float_14 * class313_0.float_3;
		}
		Matrix identity = Matrix.Identity;
		identity.M31 = num3;
		identity.M32 = num4;
		device_0.SetTransform((TransformState)16, (identity));
		device_0.SetTextureStageState(0, (TextureStage)24, 2);
	}

	private static Blend smethod_40(int int_40, Blend blend_0)
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
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		return (Blend)(int_40 switch
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
			// TODO(recovered): cast to int so the switch's best-common-type is int (the Blend
			// default arm otherwise forced int arms to Blend); outer (Blend) cast then applies.
			_ => (int)blend_0,
		});
	}

	private void method_271()
	{
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0503: Unknown result type (might be due to invalid IL or missing references)
		list_7.Clear();
		Dictionary<string, List<Struct79>> dictionary_ = new Dictionary<string, List<Struct79>>(StringComparer.OrdinalIgnoreCase);
		Dictionary<string, Struct75> dictionary_2 = new Dictionary<string, Struct75>(StringComparer.OrdinalIgnoreCase);
		List<Struct74> list = new List<Struct74>(16384);
		if (pwMapTrn2File_0 != null && pwMapTrn2File_0.TotalSectors > 0 && pwMapTrn2File_0.SectorsWide > 0 && pwMapTrn2File_0.SectorsHigh > 0)
		{
			string text = method_251();
			if (string.IsNullOrWhiteSpace(text))
			{
				method_253(list, ref vertexBuffer_7, ref int_23);
				return;
			}
			Dictionary<string, GfxEffect> dictionary = new Dictionary<string, GfxEffect>(StringComparer.OrdinalIgnoreCase);
			Dictionary<string, Struct75> dictionary2 = new Dictionary<string, Struct75>(StringComparer.OrdinalIgnoreCase);
			pwMapDebugLogger_0?.Log(Class16.smethod_0(1649203075) + text);
			PwMapEcwldGfxIndex pwMapEcwldGfxIndex = PwMapEcwldGfxIndex.Build(text);
			List<PwMapEcwldGfxIndex.GfxEntry> list2 = new List<PwMapEcwldGfxIndex.GfxEntry>(pwMapEcwldGfxIndex.GetGfxPaths());
			List<KeyValuePair<int, string>> list3 = new List<KeyValuePair<int, string>>();
			string text2 = method_252();
			PwMapEcwldCollisionIndex pwMapEcwldCollisionIndex = null;
			if (!string.IsNullOrWhiteSpace(text2))
			{
				pwMapEcwldCollisionIndex = PwMapEcwldCollisionIndex.Build(text, text2, pwMapTrn2File_0);
				if (pwMapEcwldCollisionIndex != null)
				{
					foreach (KeyValuePair<int, string> item in pwMapEcwldCollisionIndex.OrnamentPathByExportId)
					{
						if (item.Value.EndsWith(Class16.smethod_0(1649119451), StringComparison.OrdinalIgnoreCase))
						{
							list3.Add(item);
						}
					}
				}
			}
			int num = list2.Count + list3.Count;
			int num2 = 0;
			int num3 = 0;
			pwMapDebugLogger_0?.Log(string.Format(Class16.smethod_0(1649087804), list2.Count));
			pwMapDebugLogger_0?.Log(string.Format(Class16.smethod_0(1649087825), list3.Count));
			pwMapDebugLogger_0?.Log(string.Format(Class16.smethod_0(1649203101), num));
			if (num > 0)
			{
				method_179(string.Format(Class16.smethod_0(1649203133), num));
				method_181(0, num);
				Application.DoEvents();
			}
			Vector3 vector3_ = default(Vector3);
			for (int i = 0; i < list2.Count; i++)
			{
				PwMapEcwldGfxIndex.GfxEntry gfxEntry = list2[i];
				vector3_ = new Vector3(gfxEntry.PosX, gfxEntry.PosY, 0f - gfxEntry.PosZ);
				float num4 = Math.Max(0.01f, gfxEntry.Scale);
				if (num4 < 0.001f)
				{
					num4 = 1f;
				}
				string text3 = method_274(gfxEntry.Path);
				Struct75 value = Struct75.smethod_0();
				if (!string.IsNullOrWhiteSpace(text3) && !dictionary2.TryGetValue(text3, out value))
				{
					GfxEffect gfxEffect_ = smethod_48(dictionary, text3);
					value = (dictionary2[text3] = smethod_47(gfxEffect_));
				}
				float num5 = Math.Max(1.5f, value.float_2 * num4);
				num2++;
				if (!string.IsNullOrWhiteSpace(text3))
				{
					num3++;
				}
				pwMapDebugLogger_0?.LogGfxEntry(num2, gfxEntry.Path, text3, (dictionary.TryGetValue(text3 ?? string.Empty, out var value2) && value2 != null) ? value2.Elements.Count : 0, num5, value.bool_0);
				method_272(gfxEntry.Path, vector3_, num5, num4, num2);
				method_273(dictionary_, dictionary_2, list, value, text3, vector3_, num4, num5, -9775617);
				if (num2 % 4 == 0)
				{
					method_179(string.Format(Class16.smethod_0(1649203162), num2, num));
					method_181(num2, num);
					Application.DoEvents();
				}
			}
			Vector3 vector3_2 = default(Vector3);
			for (int j = 0; j < list3.Count; j++)
			{
				KeyValuePair<int, string> keyValuePair = list3[j];
				string value3 = keyValuePair.Value;
				if (!pwMapEcwldCollisionIndex.OrnamentTransformByExportId.TryGetValue(keyValuePair.Key, out var value4))
				{
					num2++;
					continue;
				}
				vector3_2 = new Vector3(value4.PosX, value4.PosY, 0f - value4.PosZ);
				float num6 = Math.Max(0.01f, Math.Max(value4.ScaleX, Math.Max(value4.ScaleY, value4.ScaleZ)));
				if (num6 < 0.001f)
				{
					num6 = 1f;
				}
				string text4 = method_274(value3);
				Struct75 value5 = Struct75.smethod_0();
				if (!string.IsNullOrWhiteSpace(text4) && !dictionary2.TryGetValue(text4, out value5))
				{
					GfxEffect gfxEffect_2 = smethod_48(dictionary, text4);
					value5 = (dictionary2[text4] = smethod_47(gfxEffect_2));
				}
				float num7 = Math.Max(1.5f, value5.float_2 * num6);
				num2++;
				if (!string.IsNullOrWhiteSpace(text4))
				{
					num3++;
				}
				pwMapDebugLogger_0?.LogGfxEntry(num2, value3, text4, (dictionary.TryGetValue(text4 ?? string.Empty, out var value6) && value6 != null) ? value6.Elements.Count : 0, num7, value5.bool_0);
				method_272(value3, vector3_2, num7, num6, num2);
				method_273(dictionary_, dictionary_2, list, value5, text4, vector3_2, num6, num7, -9775617);
				if (num2 % 4 == 0)
				{
					method_179(string.Format(Class16.smethod_0(1649203162), num2, num));
					method_181(num2, num);
					Application.DoEvents();
				}
			}
			if (num > 0)
			{
				method_179(string.Format(Class16.smethod_0(1649202177), num));
				method_181(num, num);
				Application.DoEvents();
			}
			method_254(list_3, dictionary_, bool_37: true);
			method_268(list_3, dictionary_, dictionary_2);
			method_253(list, ref vertexBuffer_7, ref int_23);
			pwMapDebugLogger_0?.LogGfxSummary(list2.Count, list3.Count, num3, list.Count);
			method_182();
		}
		else
		{
			method_253(list, ref vertexBuffer_7, ref int_23);
		}
	}

	private void method_272(string string_6, Vector3 vector3_5, float float_14, float float_15, int int_40)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		list_7.Add(new Class314
		{
			string_0 = string.Format(Class16.smethod_0(1649202230), int_40, System.IO.Path.GetFileName(string_6)),
			string_1 = string_6,
			vector3_0 = vector3_5,
			vector3_1 = new Vector3(float_14, float_14, float_14),
			vector3_3 = new Vector3(float_15, float_15, float_15)
		});
	}

	private void method_273(Dictionary<string, List<Struct79>> dictionary_7, Dictionary<string, Struct75> dictionary_8, List<Struct74> list_13, Struct75 struct75_0, string string_6, Vector3 vector3_5, float float_14, float float_15, int int_40)
	{
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		if (struct75_0.bool_0)
		{
			string text = method_275(struct75_0.string_0, string_6);
			if (!string.IsNullOrWhiteSpace(text) && method_286(text) != null)
			{
				if (!dictionary_7.TryGetValue(text, out var value))
				{
					value = (dictionary_7[text] = new List<Struct79>(4096));
				}
				if (!dictionary_8.ContainsKey(text))
				{
					dictionary_8[text] = struct75_0;
				}
				float num = struct75_0.float_0 * float_14 * 0.5f;
				float num2 = struct75_0.float_1 * float_14;
				if (num < 0.3f)
				{
					num = 0.3f;
				}
				if (num2 < 0.6f)
				{
					num2 = 0.6f;
				}
				if (struct75_0.method_0())
				{
					smethod_43(value, vector3_5, num, num2, struct75_0);
				}
				else
				{
					smethod_41(value, vector3_5, num, num2, struct75_0.int_0);
				}
				return;
			}
		}
		smethod_45(list_13, vector3_5, float_15, int_40);
	}

	private static void smethod_41(List<Struct79> list_13, Vector3 vector3_5, float float_14, float float_15, int int_40)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = vector3_5 + new Vector3(0f, float_15, 0f);
		smethod_42(list_13, new Vector3(vector3_5.X - float_14, vector3_5.Y, vector3_5.Z), new Vector3(vector3_5.X + float_14, vector3_5.Y, vector3_5.Z), new Vector3(val.X - float_14, val.Y, val.Z), new Vector3(val.X + float_14, val.Y, val.Z), int_40);
		smethod_42(list_13, new Vector3(vector3_5.X, vector3_5.Y, vector3_5.Z - float_14), new Vector3(vector3_5.X, vector3_5.Y, vector3_5.Z + float_14), new Vector3(val.X, val.Y, val.Z - float_14), new Vector3(val.X, val.Y, val.Z + float_14), int_40);
	}

	private static void smethod_42(List<Struct79> list_13, Vector3 vector3_5, Vector3 vector3_6, Vector3 vector3_7, Vector3 vector3_8, int int_40)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		smethod_50(list_13, vector3_5, new Vector2(0f, 1f), int_40);
		smethod_50(list_13, vector3_7, new Vector2(0f, 0f), int_40);
		smethod_50(list_13, vector3_8, new Vector2(1f, 0f), int_40);
		smethod_50(list_13, vector3_5, new Vector2(0f, 1f), int_40);
		smethod_50(list_13, vector3_8, new Vector2(1f, 0f), int_40);
		smethod_50(list_13, vector3_6, new Vector2(1f, 1f), int_40);
	}

	private static void smethod_43(List<Struct79> list_13, Vector3 vector3_5, float float_14, float float_15, Struct75 struct75_0)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		int num = Math.Max(1, struct75_0.int_1);
		int num2 = Math.Max(1, struct75_0.int_2);
		float float_16 = 0f;
		float float_17 = 0f;
		float float_18 = 1f / (float)num2;
		float float_19 = 1f / (float)num;
		int int_ = struct75_0.int_0;
		Vector3 val = vector3_5 + new Vector3(0f, float_15, 0f);
		smethod_44(list_13, new Vector3(vector3_5.X - float_14, vector3_5.Y, vector3_5.Z), new Vector3(vector3_5.X + float_14, vector3_5.Y, vector3_5.Z), new Vector3(val.X - float_14, val.Y, val.Z), new Vector3(val.X + float_14, val.Y, val.Z), float_16, float_17, float_18, float_19, int_);
		smethod_44(list_13, new Vector3(vector3_5.X, vector3_5.Y, vector3_5.Z - float_14), new Vector3(vector3_5.X, vector3_5.Y, vector3_5.Z + float_14), new Vector3(val.X, val.Y, val.Z - float_14), new Vector3(val.X, val.Y, val.Z + float_14), float_16, float_17, float_18, float_19, int_);
	}

	private static void smethod_44(List<Struct79> list_13, Vector3 vector3_5, Vector3 vector3_6, Vector3 vector3_7, Vector3 vector3_8, float float_14, float float_15, float float_16, float float_17, int int_40)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		smethod_50(list_13, vector3_5, new Vector2(float_14, float_17), int_40);
		smethod_50(list_13, vector3_7, new Vector2(float_14, float_15), int_40);
		smethod_50(list_13, vector3_8, new Vector2(float_16, float_15), int_40);
		smethod_50(list_13, vector3_5, new Vector2(float_14, float_17), int_40);
		smethod_50(list_13, vector3_8, new Vector2(float_16, float_15), int_40);
		smethod_50(list_13, vector3_6, new Vector2(float_16, float_17), int_40);
	}

	private static void smethod_45(List<Struct74> list_13, Vector3 vector3_5, float float_14, int int_40)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		float num = Math.Max(1f, float_14 * 0.25f);
		float num2 = Math.Max(2f, float_14 * 0.6f);
		list_13.Add(new Struct74
		{
			vector3_0 = vector3_5 + new Vector3(0f - num, 0f, 0f),
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = vector3_5 + new Vector3(num, 0f, 0f),
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = vector3_5 + new Vector3(0f, 0f, 0f - num),
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = vector3_5 + new Vector3(0f, 0f, num),
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = vector3_5,
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = vector3_5 + new Vector3(0f, num2, 0f),
			int_0 = int_40
		});
		Vector3 val = vector3_5 + new Vector3(0f, num2, 0f);
		float num3 = num * 0.5f;
		list_13.Add(new Struct74
		{
			vector3_0 = val + new Vector3(0f - num3, 0f, 0f),
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val + new Vector3(num3, 0f, 0f),
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val + new Vector3(0f, 0f, 0f - num3),
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val + new Vector3(0f, 0f, num3),
			int_0 = int_40
		});
	}

	private string method_274(string string_6)
	{
		if (string.IsNullOrWhiteSpace(string_6))
		{
			return string.Empty;
		}
		if (dictionary_4.TryGetValue(string_6, out var value))
		{
			return value;
		}
		string text = smethod_30(string_6);
		if (!string.IsNullOrWhiteSpace(text) && !smethod_31(text))
		{
			if (System.IO.Path.IsPathRooted(text) && File.Exists(text))
			{
				dictionary_4[string_6] = text;
				return text;
			}
			foreach (string item in method_247())
			{
				string[] array = new string[4]
				{
					System.IO.Path.Combine(item, text),
					System.IO.Path.Combine(item, Class16.smethod_0(1649141675), text),
					System.IO.Path.Combine(item, Class16.smethod_0(1649138031), text),
					System.IO.Path.Combine(item, Class16.smethod_0(1649141675), System.IO.Path.GetFileName(text))
				};
				for (int i = 0; i < array.Length; i++)
				{
					if (File.Exists(array[i]))
					{
						dictionary_4[string_6] = array[i];
						return array[i];
					}
				}
			}
			string text2 = smethod_46(text);
			if (!string.IsNullOrWhiteSpace(text2))
			{
				dictionary_4[string_6] = text2;
				return text2;
			}
			dictionary_4[string_6] = string.Empty;
			return string.Empty;
		}
		dictionary_4[string_6] = string.Empty;
		return string.Empty;
	}

	private static string smethod_46(string string_6)
	{
		if (string.IsNullOrWhiteSpace(string_6))
		{
			return string.Empty;
		}
		if (smethod_31(string_6))
		{
			return string.Empty;
		}
		string text = PwMapAssetProvider.NormalizePckPath(string_6);
		string fileName = System.IO.Path.GetFileName(text);
		List<string> candidates = new List<string>(16)
		{
			text,
			Class16.smethod_0(1649116714) + text,
			Class16.smethod_0(1649116714) + fileName,
			Class16.smethod_0(1649116763) + text
		};
		return PwMapAssetProvider.ResolveFirstExistingPckPath(candidates);
	}

	private string method_275(string string_6, string string_7)
	{
		if (string.IsNullOrWhiteSpace(string_6))
		{
			return string.Empty;
		}
		string text = method_288(string_6, string_7);
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		text = method_288(Class16.smethod_0(1649202242) + string_6, string.Empty);
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		text = method_288(Class16.smethod_0(1649202270) + string_6, string.Empty);
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		string fileName = System.IO.Path.GetFileName(string_6);
		if (!string.IsNullOrWhiteSpace(fileName))
		{
			text = method_288(Class16.smethod_0(1649202242) + fileName, string.Empty);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return text;
			}
		}
		return method_288(string_6, string.Empty);
	}

	private static Struct75 smethod_47(GfxEffect gfxEffect_0)
	{
		Struct75 result = Struct75.smethod_0();
		if (gfxEffect_0 != null && gfxEffect_0.Elements != null && gfxEffect_0.Elements.Count != 0)
		{
			float num = Math.Max(0.1f, gfxEffect_0.DefScale);
			foreach (GfxElement element in gfxEffect_0.Elements)
			{
				if (!element.IsDummy && !string.IsNullOrWhiteSpace(element.TexturePath))
				{
					result.bool_0 = true;
					result.string_0 = element.TexturePath;
					if (element is GfxDecalElement gfxDecalElement)
					{
						result.float_0 = gfxDecalElement.Width * num;
						result.float_1 = gfxDecalElement.Height * num;
						result.float_2 = Math.Max(result.float_0, result.float_1);
					}
					else if (element is GfxParticleElement gfxParticleElement)
					{
						result.float_0 = gfxParticleElement.ParticleWidth * num;
						result.float_1 = gfxParticleElement.ParticleHeight * num;
						result.float_2 = Math.Max(result.float_0, result.float_1) * 1.5f;
					}
					else if (element is GfxRingElement gfxRingElement)
					{
						result.float_0 = gfxRingElement.Radius * 2f * num;
						result.float_1 = gfxRingElement.Radius * 2f * num;
						result.float_2 = gfxRingElement.Radius * 2f * num;
					}
					else if (element is GfxRibbonElement gfxRibbonElement)
					{
						result.float_0 = gfxRibbonElement.Width * num;
						result.float_1 = gfxRibbonElement.Width * num;
						result.float_2 = gfxRibbonElement.Width * num;
					}
					else
					{
						result.float_0 = 2f * num;
						result.float_1 = 2f * num;
						result.float_2 = 2f * num;
					}
					result.float_0 = Math.Min(result.float_0, 40f);
					result.float_1 = Math.Min(result.float_1, 40f);
					result.float_2 = Math.Min(result.float_2, 40f);
					result.int_1 = Math.Max(1, (int)element.TexRows);
					result.int_2 = Math.Max(1, (int)element.TexCols);
					result.float_3 = ((element.TexInterval != 0) ? ((float)element.TexInterval / 1000f) : 0.1f);
					result.bool_1 = element.TileMode;
					result.float_4 = element.UOffsetSpeed;
					result.float_5 = element.VOffsetSpeed;
					result.int_3 = ((element.Shader.SrcBlend > 0) ? element.Shader.SrcBlend : 5);
					result.int_4 = ((element.Shader.DestBlend > 0) ? element.Shader.DestBlend : 6);
					break;
				}
			}
			if (!result.bool_0)
			{
				foreach (GfxElement element2 in gfxEffect_0.Elements)
				{
					if (!element2.IsDummy)
					{
						if (element2 is GfxDecalElement gfxDecalElement2)
						{
							result.float_2 = Math.Max(gfxDecalElement2.Width, gfxDecalElement2.Height) * num;
						}
						else if (element2 is GfxParticleElement gfxParticleElement2)
						{
							result.float_2 = Math.Max(gfxParticleElement2.ParticleWidth, gfxParticleElement2.ParticleHeight) * num * 1.5f;
						}
						result.float_2 = Math.Min(result.float_2, 40f);
						break;
					}
				}
			}
			return result;
		}
		return result;
	}

	private static GfxEffect smethod_48(Dictionary<string, GfxEffect> dictionary_7, string string_6)
	{
		if (string.IsNullOrWhiteSpace(string_6))
		{
			return null;
		}
		if (dictionary_7.TryGetValue(string_6, out var value))
		{
			return value;
		}
		GfxEffect gfxEffect = GfxEffect.LoadFromFile(string_6);
		if (gfxEffect == null)
		{
			byte[] array = PwMapAssetProvider.ReadPckBytes(string_6);
			if (array != null && array.Length != 0)
			{
				string content = Encoding.Default.GetString(array);
				gfxEffect = GfxEffect.LoadFromContent(content, string_6);
			}
		}
		dictionary_7[string_6] = gfxEffect;
		return gfxEffect;
	}

	private static Vector3 smethod_49(Vector3 vector3_5, float float_14)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		float val = Math.Max(0.01f, float_14);
		return new Vector3(Math.Max(val, Math.Abs(vector3_5.X)), Math.Max(val, Math.Abs(vector3_5.Y)), Math.Max(val, Math.Abs(vector3_5.Z)));
	}

	private static void smethod_50(List<Struct79> list_13, Vector3 vector3_5, Vector2 vector2_0, int int_40)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		list_13.Add(new Struct79
		{
			vector3_0 = vector3_5,
			int_0 = int_40,
			float_0 = vector2_0.X,
			float_1 = vector2_0.Y
		});
	}

	private static Vector3 smethod_51(Vector3 vector3_5, Vector3 vector3_6, Vector3 vector3_7)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		Vector3 result = Vector3.Cross(vector3_6 - vector3_5, vector3_7 - vector3_5);
		if (result.LengthSquared() > 1E-05f)
		{
			result.Normalize();
		}
		else
		{
			result = Vector3.UnitY;
		}
		return result;
	}

	private static float smethod_52(Vector3[] vector3_5, Vector3 vector3_6, int int_40)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = vector3_6;
		if (vector3_5 != null && int_40 >= 0 && int_40 < vector3_5.Length)
		{
			val = vector3_5[int_40];
			if (val.LengthSquared() > 1E-05f)
			{
				val.Normalize();
			}
			else
			{
				val = vector3_6;
			}
		}
		Vector3 val2 = default(Vector3);
		val2 = new Vector3(0.42f, 0.75f, 0.51f);
		val2.Normalize();
		return Math.Max(0f, Vector3.Dot(val, val2));
	}

	private static int smethod_53(int[] int_40, int int_41)
	{
		if (int_40 != null && int_41 >= 0 && int_41 < int_40.Length)
		{
			int num = int_40[int_41];
			if ((num & 0xFFFFFF) != 0)
			{
				return num;
			}
		}
		return -4934476;
	}

	private static Vector2 smethod_54(Vector2[] vector2_0, int int_40)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		if (vector2_0 != null && int_40 >= 0 && int_40 < vector2_0.Length)
		{
			return vector2_0[int_40];
		}
		return new Vector2(0f, 0f);
	}

	private static int smethod_55(int int_40, float float_14)
	{
		float num = 0.58f + float_14 * 0.42f;
		byte b = (byte)(int_40 >> 24);
		if (b == 0)
		{
			b = byte.MaxValue;
		}
		byte b2 = (byte)(int_40 >> 16);
		byte b3 = (byte)(int_40 >> 8);
		byte b4 = (byte)int_40;
		byte b5 = (byte)Math.Max(0, Math.Min(255, (int)Math.Round((float)(int)b2 * num)));
		byte b6 = (byte)Math.Max(0, Math.Min(255, (int)Math.Round((float)(int)b3 * num)));
		byte b7 = (byte)Math.Max(0, Math.Min(255, (int)Math.Round((float)(int)b4 * num)));
		return (b << 24) | (b5 << 16) | (b6 << 8) | b7;
	}

	private void method_276()
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		list_8.Clear();
		List<Struct74> list_ = new List<Struct74>(4096);
		if (sceneLightCollection_0 == null)
		{
			method_277();
		}
		if (sceneLightCollection_0 != null && sceneLightCollection_0.Lights.Count != 0)
		{
			pwMapDebugLogger_0?.Log(string.Format(Class16.smethod_0(1649202310), sceneLightCollection_0.Lights.Count));
			for (int i = 0; i < sceneLightCollection_0.Lights.Count; i++)
			{
				PwMapSceneLightFile.SceneLight sceneLight = sceneLightCollection_0.Lights[i];
				Vector3 location = sceneLight.Location;
				float num = Math.Max(sceneLight.Range, 1f);
				int int_ = Color.FromArgb(255, (int)Math.Min(255f, sceneLight.Diffuse.X * 255f), (int)Math.Min(255f, sceneLight.Diffuse.Y * 255f), (int)Math.Min(255f, sceneLight.Diffuse.Z * 255f)).ToArgb();
				list_8.Add(new Class314
				{
					string_0 = string.Format(Class16.smethod_0(1649084986), i + 1, sceneLight.ModeLabel, num),
					string_1 = string.Empty,
					vector3_0 = location,
					vector3_1 = new Vector3(num * 0.3f, num * 0.3f, num * 0.3f)
				});
				smethod_56(list_, location, int_, num);
			}
			method_253(list_, ref vertexBuffer_8, ref int_24);
			pwMapDebugLogger_0?.LogLightSummary(sceneLightCollection_0.Lights.Count);
		}
		else
		{
			pwMapDebugLogger_0?.Log(Class16.smethod_0(1649202273));
			method_253(list_, ref vertexBuffer_8, ref int_24);
		}
	}

	private void method_277()
	{
		string text = method_147();
		if (string.IsNullOrWhiteSpace(text) || pwMapTrn2File_0 == null)
		{
			return;
		}
		string mapRootPath = pwMapTrn2File_0.MapRootPath;
		if (string.IsNullOrWhiteSpace(mapRootPath))
		{
			return;
		}
		string text2 = System.IO.Path.Combine(mapRootPath, Class16.smethod_0(1649094124), text, text + Class16.smethod_0(1649085145));
		if (File.Exists(text2))
		{
			sceneLightCollection_0 = PwMapSceneLightFile.LoadFromPath(text2);
			return;
		}
		string text3 = (textBox_78.Text ?? string.Empty).Trim();
		if (!string.IsNullOrWhiteSpace(text3))
		{
			string text4 = System.IO.Path.Combine(text3, Class16.smethod_0(1649094124), text, text + Class16.smethod_0(1649085145));
			if (File.Exists(text4))
			{
				sceneLightCollection_0 = PwMapSceneLightFile.LoadFromPath(text4);
				return;
			}
		}
		sceneLightCollection_0 = new PwMapSceneLightFile.SceneLightCollection();
	}

	private static void smethod_56(List<Struct74> list_13, Vector3 vector3_5, int int_40, float float_14)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0442: Unknown result type (might be due to invalid IL or missing references)
		//IL_044e: Unknown result type (might be due to invalid IL or missing references)
		//IL_045a: Unknown result type (might be due to invalid IL or missing references)
		float num = Math.Max(0.8f, float_14 * 0.15f);
		float num2 = num * 0.5f;
		int num3 = (int_40 & 0xFFFFFF) | 0x40000000;
		Vector3 val = vector3_5 + new Vector3(0f, num, 0f);
		Vector3 val2 = vector3_5 - new Vector3(0f, num2, 0f);
		Vector3 val3 = vector3_5 + new Vector3(0f, 0f, num2);
		Vector3 val4 = vector3_5 - new Vector3(0f, 0f, num2);
		Vector3 val5 = vector3_5 + new Vector3(num2, 0f, 0f);
		Vector3 val6 = vector3_5 - new Vector3(num2, 0f, 0f);
		list_13.Add(new Struct74
		{
			vector3_0 = vector3_5,
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val,
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = vector3_5,
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val2,
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = vector3_5,
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val3,
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = vector3_5,
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val4,
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = vector3_5,
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val5,
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = vector3_5,
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val6,
			int_0 = int_40
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val,
			int_0 = num3
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val3,
			int_0 = num3
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val,
			int_0 = num3
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val4,
			int_0 = num3
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val,
			int_0 = num3
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val5,
			int_0 = num3
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val,
			int_0 = num3
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val6,
			int_0 = num3
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val3,
			int_0 = num3
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val5,
			int_0 = num3
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val5,
			int_0 = num3
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val4,
			int_0 = num3
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val4,
			int_0 = num3
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val6,
			int_0 = num3
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val6,
			int_0 = num3
		});
		list_13.Add(new Struct74
		{
			vector3_0 = val3,
			int_0 = num3
		});
		int int_41 = (int_40 & 0xFFFFFF) | 0x18000000;
		smethod_57(list_13, vector3_5, float_14, 0, int_41);
		smethod_57(list_13, vector3_5, float_14, 1, int_41);
		smethod_57(list_13, vector3_5, float_14, 2, int_41);
	}

	private static void smethod_57(List<Struct74> list_13, Vector3 vector3_5, float float_14, int int_40, int int_41)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < 24; i++)
		{
			double num = (double)i * 2.0 * Math.PI / 24.0;
			double num2 = (double)(i + 1) * 2.0 * Math.PI / 24.0;
			Vector3 val;
			Vector3 val2;
			switch (int_40)
			{
			case 0:
				val = vector3_5 + new Vector3(0f, (float)((double)float_14 * Math.Sin(num)), (float)((double)float_14 * Math.Cos(num)));
				val2 = vector3_5 + new Vector3(0f, (float)((double)float_14 * Math.Sin(num2)), (float)((double)float_14 * Math.Cos(num2)));
				break;
			case 1:
				val = vector3_5 + new Vector3((float)((double)float_14 * Math.Cos(num)), 0f, (float)((double)float_14 * Math.Sin(num)));
				val2 = vector3_5 + new Vector3((float)((double)float_14 * Math.Cos(num2)), 0f, (float)((double)float_14 * Math.Sin(num2)));
				break;
			default:
				val = vector3_5 + new Vector3((float)((double)float_14 * Math.Cos(num)), (float)((double)float_14 * Math.Sin(num)), 0f);
				val2 = vector3_5 + new Vector3((float)((double)float_14 * Math.Cos(num2)), (float)((double)float_14 * Math.Sin(num2)), 0f);
				break;
			}
			list_13.Add(new Struct74
			{
				vector3_0 = val,
				int_0 = int_41
			});
			list_13.Add(new Struct74
			{
				vector3_0 = val2,
				int_0 = int_41
			});
		}
	}

	private void method_278()
	{
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		list_4.Clear();
		List<Struct74> list = new List<Struct74>(131072);
		bool flag;
		List<Struct74> list2 = ((flag = bool_8) ? new List<Struct74>(131072) : null);
		Dictionary<string, List<Struct79>> dictionary = new Dictionary<string, List<Struct79>>(StringComparer.OrdinalIgnoreCase);
		string text = method_147();
		pwMapDebugLogger_0?.Log(Class16.smethod_0(1649202334) + text);
		pwMapDebugLogger_0?.Log(Class16.smethod_0(1649083214) + pwMapTrn2File_0?.MapRootPath);
		pwMapDebugLogger_0?.Log(Class16.smethod_0(1649202355) + (textBox_78.Text ?? string.Empty).Trim());
		method_179(Class16.smethod_0(1649202383));
		Application.DoEvents();
		PwMapCollisionExportResolver pwMapCollisionExportResolver = PwMapCollisionExportResolver.Create(pwMapTrn2File_0, text, pwMapTrn2File_0.MapRootPath, (textBox_78.Text ?? string.Empty).Trim());
		List<string> list3 = new List<string>(pwMapCollisionExportResolver.GetAllModelPaths());
		int count = list3.Count;
		int num = 0;
		int num2 = 0;
		pwMapDebugLogger_0?.LogResolverResult((pwMapCollisionExportResolver.TotalModelFiles > 0) ? Class16.smethod_0(1649202424) : Class16.smethod_0(1649202412), count, 0);
		pwMapDebugLogger_0?.LogSeparator(Class16.smethod_0(1649202452));
		for (int i = 0; i < list3.Count; i++)
		{
			bool flag2 = !File.Exists(list3[i]);
			pwMapDebugLogger_0?.LogDetail(string.Format(Class16.smethod_0(1649202465), i, flag2 ? Class16.smethod_0(1649202498) : Class16.smethod_0(1649202493), list3[i]));
		}
		pwMapDebugLogger_0?.LogSeparator(Class16.smethod_0(1649202518));
		if (count > 0)
		{
			method_179(string.Format(Class16.smethod_0(1649202531), count));
			method_181(0, count);
			Application.DoEvents();
		}
		for (int j = 0; j < list3.Count; j++)
		{
			string text2 = list3[j];
			PwMapBmdSceneFile pwMapBmdSceneFile = PwMapBmdSceneFile.Load(text2);
			if (pwMapBmdSceneFile != null && pwMapBmdSceneFile.Meshes.Count != 0)
			{
				int num3 = 0;
				for (int k = 0; k < pwMapBmdSceneFile.Meshes.Count; k++)
				{
					int num4 = num3;
					Vector3[] vertices = pwMapBmdSceneFile.Meshes[k].Vertices;
					num3 = num4 + ((vertices != null) ? vertices.Length : 0);
				}
				bool fromPck = !File.Exists(text2);
				pwMapDebugLogger_0?.LogModelEntry(j, text2, pwMapBmdSceneFile.Meshes.Count, num3, fromPck);
				if (pwMapBmdSceneFile.HasBounds)
				{
					list_4.Add(new Class314
					{
						string_0 = string.Format(Class16.smethod_0(1649202653), num + 1, System.IO.Path.GetFileName(text2)),
						string_1 = text2,
						vector3_0 = (pwMapBmdSceneFile.BoundsMin + pwMapBmdSceneFile.BoundsMax) * 0.5f,
						vector3_1 = smethod_49((pwMapBmdSceneFile.BoundsMax - pwMapBmdSceneFile.BoundsMin) * 0.5f, 1.6f)
					});
				}
				num++;
				for (int l = 0; l < pwMapBmdSceneFile.Meshes.Count; l++)
				{
					PwMapBmdSceneFile.Mesh mesh = pwMapBmdSceneFile.Meshes[l];
					if (mesh.Vertices == null || mesh.Indices == null || mesh.Indices.Length < 3)
					{
						continue;
					}
					string text3 = method_288(mesh.TexturePath, text2);
					Texture val = method_286(text3);
					if (val != null)
					{
						if (!dictionary.TryGetValue(text3, out var value))
						{
							value = (dictionary[text3] = new List<Struct79>(65536));
						}
						smethod_58(value, mesh.Vertices, mesh.Normals, mesh.TexCoords, mesh.DiffuseColors, mesh.Indices);
					}
					else
					{
						smethod_59(list, mesh.Vertices, mesh.Normals, mesh.DiffuseColors, mesh.Indices);
					}
					if (flag)
					{
						smethod_60(list2, mesh.Vertices, mesh.Indices);
					}
					int num5 = list2?.Count ?? 0;
					if (list.Count >= 3000000 || num5 >= 2400000)
					{
						pwMapDebugLogger_0?.LogWarning(string.Format(Class16.smethod_0(1649202677), j, list.Count, num5));
						break;
					}
				}
				if (num % 8 == 0 || num == count)
				{
					method_179(string.Format(Class16.smethod_0(1649202615), num, count));
					method_181(num, count);
					Application.DoEvents();
				}
				int num6 = list2?.Count ?? 0;
				if (list.Count >= 3000000 || num6 >= 2400000)
				{
					pwMapDebugLogger_0?.LogWarning(string.Format(Class16.smethod_0(1649201707), list.Count, num6));
					break;
				}
			}
			else
			{
				num2++;
				pwMapDebugLogger_0?.LogModelSkipped(j, text2, (pwMapBmdSceneFile == null) ? Class16.smethod_0(1649202590) : Class16.smethod_0(1649202575));
				num++;
				if (num % 8 == 0)
				{
					method_179(string.Format(Class16.smethod_0(1649202615), num, count));
					method_181(num, count);
					Application.DoEvents();
				}
			}
		}
		pwMapDebugLogger_0?.LogModelSummary(num - num2, num2, list.Count, list2?.Count ?? 0, dictionary.Count);
		if (count > 0)
		{
			method_179(string.Format(Class16.smethod_0(1649201767), count));
			method_181(count, count);
			Application.DoEvents();
		}
		method_254(list_1, dictionary, bool_37: false);
		method_253(list, ref vertexBuffer_3, ref int_19);
		method_253(list2 ?? new List<Struct74>(), ref vertexBuffer_4, ref int_20);
		method_279(pwMapCollisionExportResolver);
		method_182();
	}

	private void method_279(PwMapCollisionExportResolver pwMapCollisionExportResolver_0)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		if (pwMapBrushCollisionService_0 == null)
		{
			pwMapBrushCollisionService_0 = new PwMapBrushCollisionService();
		}
		List<PwMapBrushCollisionService.AABBObject> list = new List<PwMapBrushCollisionService.AABBObject>(list_4.Count);
		for (int i = 0; i < list_4.Count; i++)
		{
			Class314 @class = list_4[i];
			list.Add(new PwMapBrushCollisionService.AABBObject(@class.vector3_0, @class.vector3_1));
		}
		pwMapBrushCollisionService_0.SetAABBObjects(list);
		pwMapBrushCollisionService_0.SetBrushes(pwMapCollisionExportResolver_0.LoadAllBrushes());
	}

	private static void smethod_58(List<Struct79> list_13, Vector3[] vector3_5, Vector3[] vector3_6, Vector2[] vector2_0, int[] int_40, short[] short_0)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i + 2 < short_0.Length; i += 3)
		{
			int num = short_0[i];
			int num2 = short_0[i + 1];
			int num3 = short_0[i + 2];
			if (num >= 0 && num2 >= 0 && num3 >= 0 && num < vector3_5.Length && num2 < vector3_5.Length && num3 < vector3_5.Length)
			{
				Vector3 vector3_7 = vector3_5[num];
				Vector3 val = vector3_5[num2];
				Vector3 val2 = vector3_5[num3];
				Vector3 vector3_8 = smethod_51(vector3_7, val, val2);
				float float_ = smethod_52(vector3_6, vector3_8, num);
				float float_2 = smethod_52(vector3_6, vector3_8, num2);
				float float_3 = smethod_52(vector3_6, vector3_8, num3);
				smethod_50(list_13, vector3_7, smethod_54(vector2_0, num), smethod_55(smethod_53(int_40, num), float_));
				smethod_50(list_13, val, smethod_54(vector2_0, num2), smethod_55(smethod_53(int_40, num2), float_2));
				smethod_50(list_13, val2, smethod_54(vector2_0, num3), smethod_55(smethod_53(int_40, num3), float_3));
			}
		}
	}

	private static void smethod_59(List<Struct74> list_13, Vector3[] vector3_5, Vector3[] vector3_6, int[] int_40, short[] short_0)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i + 2 < short_0.Length; i += 3)
		{
			int num = short_0[i];
			int num2 = short_0[i + 1];
			int num3 = short_0[i + 2];
			if (num >= 0 && num2 >= 0 && num3 >= 0 && num < vector3_5.Length && num2 < vector3_5.Length && num3 < vector3_5.Length)
			{
				Vector3 vector3_7 = vector3_5[num];
				Vector3 vector3_8 = vector3_5[num2];
				Vector3 vector3_9 = vector3_5[num3];
				Vector3 vector3_10 = smethod_51(vector3_7, vector3_8, vector3_9);
				float float_ = smethod_52(vector3_6, vector3_10, num);
				float float_2 = smethod_52(vector3_6, vector3_10, num2);
				float float_3 = smethod_52(vector3_6, vector3_10, num3);
				list_13.Add(new Struct74
				{
					vector3_0 = vector3_7,
					int_0 = smethod_55(smethod_53(int_40, num), float_)
				});
				list_13.Add(new Struct74
				{
					vector3_0 = vector3_8,
					int_0 = smethod_55(smethod_53(int_40, num2), float_2)
				});
				list_13.Add(new Struct74
				{
					vector3_0 = vector3_9,
					int_0 = smethod_55(smethod_53(int_40, num3), float_3)
				});
			}
		}
	}

	private static void smethod_60(List<Struct74> list_13, Vector3[] vector3_5, short[] short_0)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i + 2 < short_0.Length; i += 3)
		{
			int num = short_0[i];
			int num2 = short_0[i + 1];
			int num3 = short_0[i + 2];
			if (num >= 0 && num2 >= 0 && num3 >= 0 && num < vector3_5.Length && num2 < vector3_5.Length && num3 < vector3_5.Length)
			{
				Vector3 val = vector3_5[num];
				Vector3 val2 = vector3_5[num2];
				Vector3 val3 = vector3_5[num3];
				list_13.Add(new Struct74
				{
					vector3_0 = val,
					int_0 = -14671840
				});
				list_13.Add(new Struct74
				{
					vector3_0 = val2,
					int_0 = -14671840
				});
				list_13.Add(new Struct74
				{
					vector3_0 = val2,
					int_0 = -14671840
				});
				list_13.Add(new Struct74
				{
					vector3_0 = val3,
					int_0 = -14671840
				});
				list_13.Add(new Struct74
				{
					vector3_0 = val3,
					int_0 = -14671840
				});
				list_13.Add(new Struct74
				{
					vector3_0 = val,
					int_0 = -14671840
				});
			}
		}
	}

	private void method_280()
	{
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		method_285();
		if (device_0 != null && pwMapBoxArea_0 != null)
		{
			List<Struct79> list = new List<Struct79>(512);
			method_281(list);
			int_29 = list.Count;
			method_282(list, bool_37: false);
			int_30 = list.Count - int_29;
			int_27 = list.Count;
			method_282(list, bool_37: true);
			int_28 = list.Count - int_27;
			if (list.Count >= 3)
			{
				int_26 = list.Count;
				vertexBuffer_9 = new VertexBuffer(device_0, int_26 * Struct79.int_1, (Usage)8, (VertexFormat)0, (Pool)1);
				DataStream val = vertexBuffer_9.Lock(0, 0, (LockFlags)0);
				val.WriteRange<Struct79>(list.ToArray());
				vertexBuffer_9.Unlock();
				method_283(pwMapBoxArea_0);
			}
		}
	}

	private void method_281(List<Struct79> list_13)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		float num = Math.Max(0.25f, float_13);
		float num2 = 600f * num;
		float num3 = 440f;
		smethod_50(list_13, new Vector3(0f - num2, num3, 0f - num2), new Vector2(0f, 0f), -1);
		smethod_50(list_13, new Vector3(num2, num3, 0f - num2), new Vector2(1f, 0f), -1);
		smethod_50(list_13, new Vector3(num2, num3, num2), new Vector2(1f, 1f), -1);
		smethod_50(list_13, new Vector3(0f - num2, num3, 0f - num2), new Vector2(0f, 0f), -1);
		smethod_50(list_13, new Vector3(num2, num3, num2), new Vector2(1f, 1f), -1);
		smethod_50(list_13, new Vector3(0f - num2, num3, num2), new Vector2(0f, 1f), -1);
	}

	private void method_282(List<Struct79> list_13, bool bool_37)
	{
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		float num = (float)Math.PI / 8f;
		float num2 = (float)Math.PI / 9f;
		Vector3[,] array = new Vector3[4, 5];
		Vector2[,] array2 = new Vector2[4, 5];
		for (int i = 0; i < 4; i++)
		{
			float num3 = (float)(3 - i) * num2;
			float num4 = 800f * (float)Math.Cos(num3);
			float num5 = 800f * (float)Math.Sin(num3);
			for (int j = 0; j < 5; j++)
			{
				float num6 = (float)j * num;
				if (bool_37)
				{
					num6 += (float)Math.PI;
				}
				float num7 = 0f - (float)(800.0 * Math.Sin(num6));
				float num8 = 0f - (float)(800.0 * Math.Cos(num6));
				array[i, j] = new Vector3(num7 * (num4 / 800f), num5, num8 * (num4 / 800f));
				array2[i, j] = new Vector2((float)j / 4f, bool_37 ? (1f - 0.5f * (float)i / 3f) : (0.5f * (float)i / 3f));
			}
		}
		for (int k = 0; k < 3; k++)
		{
			for (int l = 0; l < 4; l++)
			{
				int num9 = ((k == 0) ? 16777215 : (-1));
				int num10 = ((k + 1 == 0) ? 16777215 : (-1));
				int int_ = num9;
				int int_2 = num10;
				smethod_50(list_13, array[k, l], array2[k, l], num9);
				smethod_50(list_13, array[k, l + 1], array2[k, l + 1], int_);
				smethod_50(list_13, array[k + 1, l], array2[k + 1, l], num10);
				smethod_50(list_13, array[k, l + 1], array2[k, l + 1], int_);
				smethod_50(list_13, array[k + 1, l + 1], array2[k + 1, l + 1], int_2);
				smethod_50(list_13, array[k + 1, l], array2[k + 1, l], num10);
			}
		}
	}

	private void method_283(PwMapBoxArea pwMapBoxArea_1)
	{
		texture_0 = method_284(pwMapBoxArea_1.SkyFile0, ref string_3);
		texture_1 = method_284(pwMapBoxArea_1.SkyFile0Night, ref string_3);
		texture_2 = method_284(pwMapBoxArea_1.SkyFile1, ref string_4);
		texture_3 = method_284(pwMapBoxArea_1.SkyFile1Night, ref string_4);
		texture_4 = method_284(pwMapBoxArea_1.SkyFile2, ref string_5);
		texture_5 = method_284(pwMapBoxArea_1.SkyFile2Night, ref string_5);
	}

	private Texture method_284(string string_6, ref string string_7)
	{
		if (string.IsNullOrWhiteSpace(string_6))
		{
			return null;
		}
		string text = method_288(Class16.smethod_0(1649201803) + string_6, string.Empty);
		if (string.IsNullOrWhiteSpace(text))
		{
			text = method_288(Class16.smethod_0(1649201831) + string_6, string.Empty);
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		string_7 = text;
		return method_286(text);
	}

	private void method_285()
	{
		try
		{
			VertexBuffer obj = vertexBuffer_9;
			if (obj != null)
			{
				((DisposeBase)obj).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_9 = null;
		int_26 = 0;
		texture_0 = null;
		texture_1 = null;
		texture_2 = null;
		texture_3 = null;
		texture_4 = null;
		texture_5 = null;
	}

	private Texture method_286(string string_6)
	{
		if (method_306() && device_0 != null && !string.IsNullOrWhiteSpace(string_6))
		{
			if (dictionary_1.TryGetValue(string_6, out var value))
			{
				if (value != null && !((DisposeBase)value).IsDisposed)
				{
					return value;
				}
				dictionary_1.Remove(string_6);
			}
			try
			{
				Texture val = null;
				if (File.Exists(string_6))
				{
					val = Texture.FromFile(device_0, string_6);
				}
				else
				{
					byte[] array = PwMapAssetProvider.ReadPckBytes(string_6);
					if (array != null && array.Length != 0)
					{
						val = Texture.FromMemory(device_0, array);
					}
				}
				if (val == null)
				{
					return null;
				}
				dictionary_1[string_6] = val;
				return val;
			}
			catch
			{
				return null;
			}
		}
		return null;
	}

	private string method_287(PwMapEcwldTreeFile.TreeTypeInfo treeTypeInfo_0)
	{
		object obj;
		if (treeTypeInfo_0 == null)
		{
			obj = null;
		}
		else
		{
			obj = treeTypeInfo_0.DdsFile;
			if (obj != null)
			{
				goto IL_0016;
			}
		}
		obj = string.Empty;
		goto IL_0016;
		IL_0016:
		string text = method_288((string)obj, string.Empty);
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		if (!string.IsNullOrWhiteSpace(treeTypeInfo_0?.SptFile))
		{
			string text2 = System.IO.Path.ChangeExtension(treeTypeInfo_0.SptFile, null) ?? string.Empty;
			if (!string.IsNullOrWhiteSpace(text2))
			{
				string text3 = method_288(text2 + Class16.smethod_0(1648904847), string.Empty);
				if (!string.IsNullOrWhiteSpace(text3))
				{
					return text3;
				}
			}
		}
		return string.Empty;
	}

	private string method_288(string string_6, string string_7)
	{
		if (string.IsNullOrWhiteSpace(string_6))
		{
			return string.Empty;
		}
		string key = (string.IsNullOrWhiteSpace(string_7) ? string_6 : (string_6 + Class16.smethod_0(1648905535) + string_7));
		if (dictionary_2.TryGetValue(key, out var value))
		{
			return value;
		}
		string text = smethod_30(string_6);
		if (string.IsNullOrWhiteSpace(text))
		{
			dictionary_2[key] = string.Empty;
			return string.Empty;
		}
		if (System.IO.Path.IsPathRooted(text) && File.Exists(text))
		{
			dictionary_2[key] = text;
			return text;
		}
		string text2 = method_147();
		string[] array = smethod_32(text);
		List<string> list = smethod_29(string_7);
		List<string> list2 = new List<string>(96);
		foreach (string text3 in array)
		{
			if (string.IsNullOrWhiteSpace(text3))
			{
				continue;
			}
			for (int j = 0; j < list.Count; j++)
			{
				list2.Add(System.IO.Path.Combine(list[j], text3));
			}
			foreach (string item in method_247())
			{
				list2.Add(System.IO.Path.Combine(item, text3));
				list2.Add(System.IO.Path.Combine(item, Class16.smethod_0(1649094038), text3));
				list2.Add(System.IO.Path.Combine(item, Class16.smethod_0(1649121484), text3));
				list2.Add(System.IO.Path.Combine(item, Class16.smethod_0(1649094124), text2, text3));
				list2.Add(System.IO.Path.Combine(item, Class16.smethod_0(1649094124), text2, Class16.smethod_0(1649121484), text3));
				list2.Add(System.IO.Path.Combine(item, Class16.smethod_0(1649093786), text2, text3));
				list2.Add(System.IO.Path.Combine(item, Class16.smethod_0(1649093786), text3));
			}
		}
		int num = 0;
		string text4;
		while (true)
		{
			if (num < list2.Count)
			{
				text4 = list2[num];
				if (File.Exists(text4))
				{
					break;
				}
				num++;
				continue;
			}
			string text5 = method_289(array, text2, string_7);
			if (!string.IsNullOrWhiteSpace(text5))
			{
				dictionary_2[key] = text5;
				return text5;
			}
			string fileName = System.IO.Path.GetFileName(text);
			if (!string.IsNullOrWhiteSpace(fileName))
			{
				if (dictionary_3.TryGetValue(fileName, out var value2) && File.Exists(value2))
				{
					dictionary_2[key] = value2;
					return value2;
				}
				foreach (string item2 in method_247())
				{
					try
					{
						string text6 = Directory.EnumerateFiles(item2, fileName, SearchOption.AllDirectories).FirstOrDefault();
						if (!string.IsNullOrWhiteSpace(text6))
						{
							dictionary_3[fileName] = text6;
							dictionary_2[key] = text6;
							return text6;
						}
					}
					catch
					{
					}
				}
			}
			dictionary_2[key] = string.Empty;
			return string.Empty;
		}
		dictionary_2[key] = text4;
		return text4;
	}

	private string method_289(IReadOnlyList<string> ireadOnlyList_0, string string_6, string string_7)
	{
		if (ireadOnlyList_0 != null && ireadOnlyList_0.Count != 0)
		{
			List<string> list = new List<string>(64);
			string text = smethod_63(string_7);
			for (int i = 0; i < ireadOnlyList_0.Count; i++)
			{
				string text2 = ireadOnlyList_0[i];
				if (string.IsNullOrWhiteSpace(text2))
				{
					continue;
				}
				string text3 = PwMapAssetProvider.NormalizePckPath(text2);
				if (string.IsNullOrWhiteSpace(text3))
				{
					continue;
				}
				if (!text3.StartsWith(Class16.smethod_0(1649116763), StringComparison.OrdinalIgnoreCase) && !text3.StartsWith(Class16.smethod_0(1649201843), StringComparison.OrdinalIgnoreCase) && !text3.StartsWith(Class16.smethod_0(1649093215), StringComparison.OrdinalIgnoreCase) && !text3.StartsWith(Class16.smethod_0(1649201858), StringComparison.OrdinalIgnoreCase) && !text3.StartsWith(Class16.smethod_0(1648904820), StringComparison.OrdinalIgnoreCase) && !text3.StartsWith(Class16.smethod_0(1649201874), StringComparison.OrdinalIgnoreCase) && !text3.StartsWith(Class16.smethod_0(1649116714), StringComparison.OrdinalIgnoreCase) && !text3.StartsWith(Class16.smethod_0(1649201890), StringComparison.OrdinalIgnoreCase) && !text3.StartsWith(Class16.smethod_0(1649201905), StringComparison.OrdinalIgnoreCase) && !text3.StartsWith(Class16.smethod_0(1649201926), StringComparison.OrdinalIgnoreCase) && !text3.StartsWith(Class16.smethod_0(1649201941), StringComparison.OrdinalIgnoreCase) && !text3.StartsWith(Class16.smethod_0(1649201959), StringComparison.OrdinalIgnoreCase) && !text3.StartsWith(Class16.smethod_0(1649116938), StringComparison.OrdinalIgnoreCase) && !text3.StartsWith(Class16.smethod_0(1648985387), StringComparison.OrdinalIgnoreCase))
				{
					smethod_61(list, text3, string_6);
				}
				else
				{
					list.Add(text3);
					int num = text3.IndexOf('\\');
					if (num > 0 && num + 1 < text3.Length)
					{
						list.Add(text3.Substring(num + 1));
					}
				}
				if (!string.IsNullOrWhiteSpace(text))
				{
					list.Add(text + Class16.smethod_0(1648927580) + text3);
					string fileName = System.IO.Path.GetFileName(text3);
					if (!string.IsNullOrWhiteSpace(fileName))
					{
						list.Add(text + Class16.smethod_0(1648927580) + fileName);
					}
				}
			}
			string text4 = PwMapAssetProvider.ResolveFirstExistingPckPath(list);
			if (!string.IsNullOrWhiteSpace(text4))
			{
				return text4;
			}
			return smethod_62(ireadOnlyList_0, string_6);
		}
		return string.Empty;
	}

	private static void smethod_61(List<string> list_13, string string_6, string string_7)
	{
		list_13.Add(string_6);
		list_13.Add(Class16.smethod_0(1648904820) + string_6);
		list_13.Add(Class16.smethod_0(1649201972) + string_6);
		list_13.Add(Class16.smethod_0(1649201874) + string_6);
		list_13.Add(Class16.smethod_0(1649116763) + string_6);
		list_13.Add(Class16.smethod_0(1649201843) + string_6);
		list_13.Add(Class16.smethod_0(1649093215) + string_6);
		list_13.Add(Class16.smethod_0(1649201858) + string_6);
		list_13.Add(Class16.smethod_0(1649116714) + string_6);
		list_13.Add(Class16.smethod_0(1649116792) + string_6);
		list_13.Add(Class16.smethod_0(1649201890) + string_6);
		list_13.Add(Class16.smethod_0(1649201905) + string_6);
		if (!string.IsNullOrWhiteSpace(string_7))
		{
			list_13.Add(Class16.smethod_0(1649093191) + string_7 + Class16.smethod_0(1648927580) + string_6);
			list_13.Add(Class16.smethod_0(1649093215) + string_7 + Class16.smethod_0(1648927580) + string_6);
			list_13.Add(Class16.smethod_0(1649093224) + string_7 + Class16.smethod_0(1648927580) + string_6);
			list_13.Add(Class16.smethod_0(1649093268) + string_7 + Class16.smethod_0(1648927580) + string_6);
			list_13.Add(Class16.smethod_0(1649093224) + string_7 + Class16.smethod_0(1649093298) + string_6);
			list_13.Add(Class16.smethod_0(1649093268) + string_7 + Class16.smethod_0(1649093298) + string_6);
		}
		list_13.Add(Class16.smethod_0(1649093191) + string_6);
	}

	private static string smethod_62(IReadOnlyList<string> ireadOnlyList_0, string string_6)
	{
		int num = 0;
		string text5;
		while (true)
		{
			if (num < ireadOnlyList_0.Count)
			{
				string fileName = System.IO.Path.GetFileName(ireadOnlyList_0[num]);
				if (!string.IsNullOrWhiteSpace(fileName))
				{
					string text = PwMapAssetProvider.ResolveFromPckByFileName(Class16.smethod_0(1649067915), fileName, string_6);
					if (!string.IsNullOrWhiteSpace(text))
					{
						return text;
					}
					string text2 = PwMapAssetProvider.ResolveFromPckByFileName(Class16.smethod_0(1649141675), fileName, Class16.smethod_0(1649201874));
					if (!string.IsNullOrWhiteSpace(text2))
					{
						return text2;
					}
					text2 = PwMapAssetProvider.ResolveFromPckByFileName(Class16.smethod_0(1649141675), fileName, Class16.smethod_0(1649116792));
					if (!string.IsNullOrWhiteSpace(text2))
					{
						return text2;
					}
					text = PwMapAssetProvider.ResolveFromPckByFileName(Class16.smethod_0(1649067915), fileName, Class16.smethod_0(1649201874));
					if (!string.IsNullOrWhiteSpace(text))
					{
						return text;
					}
					string text3 = PwMapAssetProvider.ResolveFromPckByFileName(Class16.smethod_0(1649094038), fileName, Class16.smethod_0(1649201874));
					if (!string.IsNullOrWhiteSpace(text3))
					{
						return text3;
					}
					string text4 = PwMapAssetProvider.ResolveFromPckByFileName(Class16.smethod_0(1649093786), fileName, Class16.smethod_0(1649093215) + string_6);
					if (!string.IsNullOrWhiteSpace(text4))
					{
						return text4;
					}
					text4 = PwMapAssetProvider.ResolveFromPckByFileName(Class16.smethod_0(1649093786), fileName, Class16.smethod_0(1649093215));
					if (!string.IsNullOrWhiteSpace(text4))
					{
						return text4;
					}
					text5 = PwMapAssetProvider.ResolveFromPckByFileName(Class16.smethod_0(1649138031), fileName, Class16.smethod_0(1649093215));
					if (!string.IsNullOrWhiteSpace(text5))
					{
						return text5;
					}
					if (!string.IsNullOrWhiteSpace(string_6))
					{
						text5 = PwMapAssetProvider.ResolveFromPckByFileName(Class16.smethod_0(1649138031), fileName, Class16.smethod_0(1649093215) + string_6);
						if (!string.IsNullOrWhiteSpace(text5))
						{
							return text5;
						}
						text5 = PwMapAssetProvider.ResolveFromPckByFileName(Class16.smethod_0(1649138031), fileName, Class16.smethod_0(1649093268) + string_6 + Class16.smethod_0(1649093243));
						if (!string.IsNullOrWhiteSpace(text5))
						{
							break;
						}
					}
				}
				num++;
				continue;
			}
			return string.Empty;
		}
		return text5;
	}

	private static string smethod_63(string string_6)
	{
		if (string.IsNullOrWhiteSpace(string_6))
		{
			return string.Empty;
		}
		string text = PwMapAssetProvider.NormalizePckPath(string_6);
		int num = text.LastIndexOf('\\');
		if (num <= 0)
		{
			return string.Empty;
		}
		string result = text.Substring(0, num);
		if (!PwMapAssetProvider.ExistsInPck(string_6))
		{
			return string.Empty;
		}
		return result;
	}

	private void method_290()
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		method_292();
		list_5.Clear();
		List<Struct79> list = new List<Struct79>(131072);
		IReadOnlyList<string> readOnlyList = method_248();
		for (int i = 0; i < readOnlyList.Count; i++)
		{
			PwMapBsdataFile pwMapBsdataFile = PwMapBsdataFile.Load(readOnlyList[i]);
			if (pwMapBsdataFile?.WaterBlocks != null)
			{
				for (int j = 0; j < pwMapBsdataFile.WaterBlocks.Count; j++)
				{
					method_291(list, pwMapBsdataFile.WaterBlocks[j]);
				}
			}
		}
		if (list.Count >= 3)
		{
			int_31 = list.Count;
			vertexBuffer_10 = new VertexBuffer(device_0, list.Count * Struct79.int_1, (Usage)8, (VertexFormat)0, (Pool)1);
			DataStream val = vertexBuffer_10.Lock(0, 0, (LockFlags)0);
			val.WriteRange<Struct79>(list.ToArray());
			vertexBuffer_10.Unlock();
		}
	}

	private void method_291(List<Struct79> list_13, PwMapBsdataFile.WaterBlockEntry waterBlockEntry_0)
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		if (waterBlockEntry_0 == null || waterBlockEntry_0.Width <= 0 || waterBlockEntry_0.Height <= 0 || !(waterBlockEntry_0.GridSize > 0f))
		{
			return;
		}
		float num = (float)waterBlockEntry_0.Width * waterBlockEntry_0.GridSize * 0.5f;
		float num2 = (float)waterBlockEntry_0.Height * waterBlockEntry_0.GridSize * 0.5f;
		if (num <= 0.01f || !(num2 > 0.01f))
		{
			return;
		}
		float num3 = ((Math.Abs(waterBlockEntry_0.WaterHeight) > 0.0001f) ? waterBlockEntry_0.WaterHeight : waterBlockEntry_0.WorldY) + 0.08f;
		list_5.Add(new Class314
		{
			string_0 = string.Format(Class16.smethod_0(1649203062), waterBlockEntry_0.AreaId),
			vector3_0 = new Vector3(waterBlockEntry_0.WorldX, num3, 0f - waterBlockEntry_0.WorldZ),
			vector3_1 = smethod_49(new Vector3(num, 1.2f, num2), 1f)
		});
		int int_ = (waterBlockEntry_0.WaterColor & 0xFFFFFF) | -1442840576;
		float num4 = waterBlockEntry_0.WorldX - num;
		float num5 = waterBlockEntry_0.WorldZ - num2;
		float float_ = 1f / 32f;
		if (waterBlockEntry_0.AboveGround != null && waterBlockEntry_0.AboveGround.Length == waterBlockEntry_0.Width * waterBlockEntry_0.Height)
		{
			for (int i = 0; i < waterBlockEntry_0.Height; i++)
			{
				for (int j = 0; j < waterBlockEntry_0.Width; j++)
				{
					int num6 = i * waterBlockEntry_0.Width + j;
					if (waterBlockEntry_0.AboveGround[waterBlockEntry_0.AboveGround.Length - 1 - num6] == 1)
					{
						float float_2 = num4 + (float)j * waterBlockEntry_0.GridSize;
						float float_3 = num5 + (float)i * waterBlockEntry_0.GridSize;
						smethod_64(list_13, float_2, num3, float_3, waterBlockEntry_0.GridSize, waterBlockEntry_0.GridSize, int_, float_);
						if (list_13.Count > 1500000)
						{
							return;
						}
					}
				}
			}
		}
		else
		{
			smethod_64(list_13, num4, num3, num5, (float)waterBlockEntry_0.Width * waterBlockEntry_0.GridSize, (float)waterBlockEntry_0.Height * waterBlockEntry_0.GridSize, int_, float_);
		}
	}

	private static void smethod_64(List<Struct79> list_13, float float_14, float float_15, float float_16, float float_17, float float_18, int int_40, float float_19)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		Vector3 vector3_ = default(Vector3);
		vector3_ = new Vector3(float_14, float_15, 0f - float_16);
		Vector3 vector3_2 = default(Vector3);
		vector3_2 = new Vector3(float_14 + float_17, float_15, 0f - float_16);
		Vector3 vector3_3 = default(Vector3);
		vector3_3 = new Vector3(float_14 + float_17, float_15, 0f - (float_16 + float_18));
		Vector3 vector3_4 = default(Vector3);
		vector3_4 = new Vector3(float_14, float_15, 0f - (float_16 + float_18));
		float num = float_14 * float_19;
		float num2 = float_16 * float_19;
		float num3 = (float_14 + float_17) * float_19;
		float num4 = (float_16 + float_18) * float_19;
		smethod_50(list_13, vector3_, new Vector2(num, num2), int_40);
		smethod_50(list_13, vector3_2, new Vector2(num3, num2), int_40);
		smethod_50(list_13, vector3_3, new Vector2(num3, num4), int_40);
		smethod_50(list_13, vector3_, new Vector2(num, num2), int_40);
		smethod_50(list_13, vector3_3, new Vector2(num3, num4), int_40);
		smethod_50(list_13, vector3_4, new Vector2(num, num4), int_40);
	}

	private void method_292()
	{
		try
		{
			VertexBuffer obj = vertexBuffer_10;
			if (obj != null)
			{
				((DisposeBase)obj).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_10 = null;
		int_31 = 0;
	}

	private void method_293()
	{
		method_294();
		method_176();
		method_309();
		method_314();
	}

	private void method_294()
	{
		if (checkBox_41 == null)
		{
			checkBox_41 = method_295(Class16.smethod_0(1649201997));
			checkBox_42 = method_295(Class16.smethod_0(1649202030));
			checkBox_43 = method_295(Class16.smethod_0(1649202063));
			checkBox_44 = method_295(Class16.smethod_0(1649202087));
			checkBox_45 = method_295(Class16.smethod_0(1649202116));
			checkBox_46 = method_295(Class16.smethod_0(1649122816));
			checkBox_46.CheckedChanged -= method_296;
			checkBox_46.CheckedChanged += checkBox_46_CheckedChanged;
		}
	}

	private CheckBox method_295(string string_6)
	{
		CheckBox checkBox = new CheckBox
		{
			AutoSize = true,
			Text = string_6,
			Dock = DockStyle.Fill,
			Checked = true
		};
		checkBox.CheckedChanged += method_296;
		return checkBox;
	}

	private void method_296(object sender, EventArgs e)
	{
		if (!bool_6 && !bool_30)
		{
			method_309();
			method_308();
		}
	}

	private void method_297(PwMapCameraSettings pwMapCameraSettings_0)
	{
		checkBox_41.Checked = pwMapCameraSettings_0.LoadLitModels;
		checkBox_42.Checked = pwMapCameraSettings_0.LoadFlora;
		checkBox_43.Checked = pwMapCameraSettings_0.LoadWater;
		checkBox_44.Checked = pwMapCameraSettings_0.LoadTerrainTextures;
		checkBox_45.Checked = pwMapCameraSettings_0.PreferMapAssets;
		checkBox_46.Checked = pwMapCameraSettings_0.UseVSync;
		method_309();
	}

	private void method_298(PwMapCameraSettings pwMapCameraSettings_0)
	{
		pwMapCameraSettings_0.LoadLitModels = checkBox_41?.Checked ?? true;
		pwMapCameraSettings_0.LoadFlora = checkBox_42?.Checked ?? true;
		pwMapCameraSettings_0.LoadWater = checkBox_43?.Checked ?? true;
		pwMapCameraSettings_0.LoadTerrainTextures = checkBox_44?.Checked ?? true;
		pwMapCameraSettings_0.PreferMapAssets = checkBox_45?.Checked ?? true;
		pwMapCameraSettings_0.UseVSync = checkBox_46?.Checked ?? true;
	}

	private bool method_299()
	{
		CheckBox checkBox = checkBox_41;
		if (checkBox == null || checkBox.Checked)
		{
			return toolStripButton_17?.Checked ?? true;
		}
		return false;
	}

	private bool method_300()
	{
		CheckBox checkBox = checkBox_42;
		if (checkBox == null || checkBox.Checked)
		{
			return toolStripButton_18?.Checked ?? true;
		}
		return false;
	}

	private bool method_301()
	{
		CheckBox checkBox = checkBox_43;
		if (checkBox == null || checkBox.Checked)
		{
			return toolStripButton_19?.Checked ?? true;
		}
		return false;
	}

	private bool method_302()
	{
		return toolStripButton_20?.Checked ?? true;
	}

	private bool method_303()
	{
		return toolStripButton_21?.Checked ?? true;
	}

	private bool method_304()
	{
		return toolStripButton_22?.Checked ?? true;
	}

	private bool method_305()
	{
		return toolStripButton_23?.Checked ?? true;
	}

	private bool method_306()
	{
		return checkBox_44?.Checked ?? true;
	}

	private bool method_307()
	{
		return checkBox_45?.Checked ?? true;
	}

	private void method_308()
	{
		method_263(bool_37: true);
		method_368(bool_37: true);
		method_126();
		method_353();
		method_261();
		method_120(Class16.smethod_0(1649202150), null);
	}

	private void method_309()
	{
		if (bool_30)
		{
			return;
		}
		bool_30 = true;
		try
		{
			if (method_106() != null)
			{
				method_106().Checked = checkBox_41?.Checked ?? true;
			}
			if (method_107() != null)
			{
				method_107().Checked = checkBox_42?.Checked ?? true;
			}
			if (method_108() != null)
			{
				method_108().Checked = checkBox_43?.Checked ?? true;
			}
			if (method_109() != null)
			{
				method_109().Checked = checkBox_44?.Checked ?? true;
			}
			if (method_110() != null)
			{
				method_110().Checked = checkBox_45?.Checked ?? true;
			}
			if (method_112() != null)
			{
				method_112().Checked = checkBox_46?.Checked ?? true;
			}
		}
		finally
		{
			bool_30 = false;
		}
	}

	private void method_310()
	{
		if (bool_30)
		{
			return;
		}
		bool_30 = true;
		try
		{
			if (checkBox_41 != null && method_106() != null)
			{
				checkBox_41.Checked = method_106().Checked;
			}
			if (checkBox_42 != null && method_107() != null)
			{
				checkBox_42.Checked = method_107().Checked;
			}
			if (checkBox_43 != null && method_108() != null)
			{
				checkBox_43.Checked = method_108().Checked;
			}
			if (checkBox_44 != null && method_109() != null)
			{
				checkBox_44.Checked = method_109().Checked;
			}
			if (checkBox_45 != null && method_110() != null)
			{
				checkBox_45.Checked = method_110().Checked;
			}
			if (checkBox_46 != null && method_112() != null)
			{
				checkBox_46.Checked = method_112().Checked;
			}
		}
		finally
		{
			bool_30 = false;
		}
	}

	private void toolStripMenuItem_6_CheckedChanged(object sender, EventArgs e)
	{
		if (!bool_6 && !bool_30)
		{
			method_310();
			method_308();
		}
	}

	private void toolStripMenuItem_7_CheckedChanged(object sender, EventArgs e)
	{
		toolStripMenuItem_6_CheckedChanged(sender, e);
	}

	private void toolStripMenuItem_8_CheckedChanged(object sender, EventArgs e)
	{
		toolStripMenuItem_6_CheckedChanged(sender, e);
	}

	private void toolStripMenuItem_9_CheckedChanged(object sender, EventArgs e)
	{
		toolStripMenuItem_6_CheckedChanged(sender, e);
	}

	private void toolStripMenuItem_10_CheckedChanged(object sender, EventArgs e)
	{
		toolStripMenuItem_6_CheckedChanged(sender, e);
	}

	private void toolStripMenuItem_12_Click(object sender, EventArgs e)
	{
		method_308();
	}

	private void method_311(object sender, EventArgs e)
	{
		if (!bool_6 && !bool_30)
		{
			method_310();
			method_218();
		}
	}

	private void checkBox_46_CheckedChanged(object sender, EventArgs e)
	{
		if (!bool_6 && !bool_30)
		{
			method_309();
			method_218();
		}
	}

	private bool method_312()
	{
		return checkBox_46?.Checked ?? true;
	}

	private void method_313(int int_40)
	{
	}

	private void method_314()
	{
		if (toolStripButton_17 != null)
		{
			toolStripButton_17.CheckedChanged += toolStripButton_23_CheckedChanged;
		}
		if (toolStripButton_18 != null)
		{
			toolStripButton_18.CheckedChanged += toolStripButton_23_CheckedChanged;
		}
		if (toolStripButton_19 != null)
		{
			toolStripButton_19.CheckedChanged += toolStripButton_23_CheckedChanged;
		}
		if (toolStripButton_20 != null)
		{
			toolStripButton_20.CheckedChanged += toolStripButton_23_CheckedChanged;
		}
		if (toolStripButton_21 != null)
		{
			toolStripButton_21.CheckedChanged += toolStripButton_23_CheckedChanged;
		}
		if (toolStripButton_22 != null)
		{
			toolStripButton_22.CheckedChanged += toolStripButton_23_CheckedChanged;
		}
		if (toolStripButton_23 != null)
		{
			toolStripButton_23.CheckedChanged += toolStripButton_23_CheckedChanged;
		}
	}

	private void toolStripButton_23_CheckedChanged(object sender, EventArgs e)
	{
		if (!bool_6)
		{
			method_261();
		}
	}

	private void method_315()
	{
	}

	private void method_316(Class301 class301_2)
	{
		if (class301_2 == null)
		{
			return;
		}
		switch (class301_2.enum20_0)
		{
		default:
			method_11(null);
			break;
		case Enum20.LitModelObject:
		{
			string text = System.IO.Path.GetExtension(class301_2.string_1 ?? string.Empty)?.ToLowerInvariant();
			if (text == Class16.smethod_0(1648906325))
			{
				method_11(Class16.smethod_0(1649086370));
				method_13(class301_2.string_1, class301_2.vector3_1.X, class301_2.vector3_1.Y, class301_2.vector3_1.Z, class301_2.vector3_3.X, class301_2.vector3_3.Y, class301_2.vector3_3.Z, 0f, 1f, 0f);
			}
			else if (text == Class16.smethod_0(1649094375))
			{
				method_11(Class16.smethod_0(1649086411));
				method_100(class301_2.string_1, class301_2.vector3_1.X, class301_2.vector3_1.Y, class301_2.vector3_1.Z, class301_2.class314_0?.vector3_3.X ?? 1f, class301_2.class314_0?.vector3_3.Y ?? 1f, class301_2.class314_0?.vector3_3.Z ?? 1f, class301_2.class314_0?.vector3_2.Y ?? 0f);
			}
			else
			{
				method_11(Class16.smethod_0(1649086343));
				method_12(class301_2.string_1, class301_2.vector3_1.X, class301_2.vector3_1.Y, class301_2.vector3_1.Z, class301_2.vector3_3.X, class301_2.vector3_3.Y, class301_2.vector3_3.Z, 0f, 1f, 0f);
			}
			break;
		}
		case Enum20.WaterArea:
			method_11(null);
			break;
		case Enum20.FloraMarker:
			method_11(Class16.smethod_0(1649086411));
			method_100(class301_2.string_1, class301_2.vector3_1.X, class301_2.vector3_1.Y, class301_2.vector3_1.Z, class301_2.class314_0?.vector3_3.X ?? 1f, class301_2.class314_0?.vector3_3.Y ?? 1f, class301_2.class314_0?.vector3_3.Z ?? 1f, class301_2.class314_0?.vector3_2.Y ?? 0f);
			break;
		case Enum20.LightMarker:
			method_11(Class16.smethod_0(1648901148));
			if (sceneLightCollection_0 != null && class301_2.int_0 >= 0 && class301_2.int_0 < sceneLightCollection_0.Lights.Count)
			{
				PwMapSceneLightFile.SceneLight sceneLight = sceneLightCollection_0.Lights[class301_2.int_0];
				method_15(Color.FromArgb((int)Math.Min(255f, sceneLight.Diffuse.X * 255f), (int)Math.Min(255f, sceneLight.Diffuse.Y * 255f), (int)Math.Min(255f, sceneLight.Diffuse.Z * 255f)), sceneLight.Range, sceneLight.Flags, sceneLight.Attenuation, sceneLight.Attenuation2, sceneLight.Attenuation3, class301_2.vector3_1.X, class301_2.vector3_1.Y, class301_2.vector3_1.Z);
			}
			break;
		case Enum20.GfxMarker:
			method_11(Class16.smethod_0(1649141693));
			method_14(class301_2.string_1, class301_2.vector3_1.X, class301_2.vector3_1.Y, class301_2.vector3_1.Z, (class301_2.vector3_2.X > 0.01f) ? class301_2.vector3_2.X : 1f, 1f, 1f, 0, bool_37: false);
			break;
		}
	}

	private bool method_317(Class301 class301_2)
	{
		return class301_2.enum20_0 switch
		{
			Enum20.RegionPolygon => checkBox_29.Checked, 
			Enum20.PrecinctPolygon => checkBox_30.Checked, 
			Enum20.TransportBox => checkBox_31.Checked, 
			Enum20.CityMarker => checkBox_32.Checked, 
			Enum20.NpcMarker => checkBox_32.Checked, 
			Enum20.LitModelObject => method_299(), 
			Enum20.WaterArea => method_301(), 
			Enum20.FloraMarker => method_300(), 
			Enum20.LightMarker => method_305(), 
			Enum20.GfxMarker => method_304(), 
			_ => false, 
		};
	}

	private bool method_318(Point point_3, out Vector3 vector3_5, out Vector3 vector3_6)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		vector3_5 = Vector3.Zero;
		vector3_6 = Vector3.UnitZ;
		int num = Math.Max(1, panel_21.ClientSize.Width);
		int num2 = Math.Max(1, panel_21.ClientSize.Height);
		if (point_3.X >= 0 && point_3.Y >= 0 && point_3.X <= num && point_3.Y <= num2)
		{
			Matrix val = method_195() * method_193();
			Matrix val2;
			try
			{
				val2 = Matrix.Invert(val);
			}
			catch
			{
				return false;
			}
			float num3 = 2f * (float)point_3.X / (float)num - 1f;
			float num4 = 1f - 2f * (float)point_3.Y / (float)num2;
			Vector3 val3 = default(Vector3);
			val3 = new Vector3(num3, num4, 0f);
			Vector3 val4 = default(Vector3);
			val4 = new Vector3(num3, num4, 1f);
			Vector3 val5 = Vector3.TransformCoordinate(val3, val2);
			Vector3 val6 = Vector3.TransformCoordinate(val4, val2);
			Vector3 val7 = val6 - val5;
			if (val7.LengthSquared() <= 1E-06f)
			{
				return false;
			}
			vector3_5 = val5;
			vector3_6 = Vector3.Normalize(val7);
			return true;
		}
		return false;
	}

	private void method_319(bool bool_37)
	{
		class301_1 = null;
		list_10.Clear();
		bool_31 = false;
		method_321();
		method_324();
		if (bool_37)
		{
			method_120(Class16.smethod_0(1649202171), null);
		}
	}

	private void method_320(Point point_3)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		bool flag = (Control.ModifierKeys & Keys.Control) != 0;
		if (!method_318(point_3, out var vector3_, out var vector3_2))
		{
			return;
		}
		Class301 @class = null;
		Vector3 val = Vector3.Zero;
		float num = float.MaxValue;
		for (int i = 0; i < list_9.Count; i++)
		{
			Class301 class2 = list_9[i];
			if (method_317(class2))
			{
				bool flag2;
				float float_;
				Vector3 vector3_3;
				switch (class2.enum20_0)
				{
				default:
					flag2 = false;
					float_ = float.MaxValue;
					vector3_3 = Vector3.Zero;
					break;
				case Enum20.RegionPolygon:
				case Enum20.PrecinctPolygon:
					flag2 = smethod_69(vector3_, vector3_2, class2.vector3_0, out float_, out vector3_3);
					break;
				case Enum20.CityMarker:
				case Enum20.NpcMarker:
				case Enum20.FloraMarker:
					flag2 = smethod_71(vector3_, vector3_2, class2.vector3_1, Math.Max(1f, class2.float_0), out float_);
					vector3_3 = vector3_ + vector3_2 * float_;
					break;
				case Enum20.TransportBox:
				case Enum20.LitModelObject:
				case Enum20.WaterArea:
				case Enum20.LightMarker:
				case Enum20.GfxMarker:
					flag2 = smethod_72(vector3_, vector3_2, class2.vector3_1 - class2.vector3_2, class2.vector3_1 + class2.vector3_2, out float_);
					vector3_3 = vector3_ + vector3_2 * float_;
					break;
				}
				if (flag2 && !(float_ < 0f) && !(float_ >= num))
				{
					@class = class2;
					num = float_;
					val = vector3_3;
				}
			}
		}
		if (@class == null)
		{
			if (!flag)
			{
				method_319(bool_37: true);
			}
			return;
		}
		if (flag)
		{
			if (list_10.Contains(@class))
			{
				list_10.Remove(@class);
			}
			else
			{
				list_10.Add(@class);
			}
			class301_1 = ((list_10.Count > 0) ? list_10[list_10.Count - 1] : null);
		}
		else
		{
			list_10.Clear();
			list_10.Add(@class);
			class301_1 = @class;
		}
		bool_31 = true;
		this.vector3_3 = val;
		method_321();
		method_324();
		method_120((list_10.Count > 1) ? string.Format(Class16.smethod_0(1649201180), list_10.Count) : (Class16.smethod_0(1649089891) + @class.string_0), null);
		method_316(@class);
		method_140();
		method_77();
	}

	private void method_321()
	{
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Expected O, but got Unknown
		try
		{
			VertexBuffer obj = vertexBuffer_11;
			if (obj != null)
			{
				((DisposeBase)obj).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_11 = null;
		int_32 = 0;
		if (device_0 == null || list_10.Count == 0 || (checkBox_6 != null && !checkBox_6.Checked))
		{
			return;
		}
		List<Struct74> list = new List<Struct74>(256);
		for (int i = 0; i < list_10.Count; i++)
		{
			Class301 @class = list_10[i];
			if (method_317(@class))
			{
				switch (@class.enum20_0)
				{
				case Enum20.RegionPolygon:
				case Enum20.PrecinctPolygon:
					smethod_65(list, @class.vector3_0, -8085);
					break;
				case Enum20.TransportBox:
					smethod_66(list, @class.vector3_1, @class.vector3_2, -20665);
					smethod_68(list, @class.vector3_1, @class.vector3_3, -9571585);
					smethod_67(list, @class.vector3_3, 3f, -9571585);
					break;
				case Enum20.CityMarker:
					smethod_67(list, @class.vector3_1, 5f, -154);
					break;
				case Enum20.NpcMarker:
					smethod_67(list, @class.vector3_1, 3.4f, -39169);
					break;
				case Enum20.LitModelObject:
					smethod_66(list, @class.vector3_1, @class.vector3_2, -7416577);
					break;
				case Enum20.WaterArea:
					smethod_66(list, @class.vector3_1, @class.vector3_2, -10037505);
					smethod_67(list, @class.vector3_1, 2.2f, -10037505);
					break;
				case Enum20.FloraMarker:
					smethod_67(list, @class.vector3_1, 2.8f, -7405702);
					break;
				case Enum20.GfxMarker:
					smethod_66(list, @class.vector3_1, @class.vector3_2, -9775617);
					smethod_67(list, @class.vector3_1, 2f, -9775617);
					break;
				}
			}
		}
		if (bool_31)
		{
			smethod_67(list, vector3_3, 2.4f, -1);
		}
		if (list.Count > 1)
		{
			int_32 = list.Count;
			vertexBuffer_11 = new VertexBuffer(device_0, int_32 * Struct74.int_1, (Usage)8, (VertexFormat)0, (Pool)1);
			DataStream val = vertexBuffer_11.Lock(0, 0, (LockFlags)0);
			val.WriteRange<Struct74>(list.ToArray());
			vertexBuffer_11.Unlock();
		}
	}

	private static void smethod_65(List<Struct74> list_13, Vector3[] vector3_5, int int_40)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		if (vector3_5 != null && vector3_5.Length >= 2)
		{
			for (int i = 0; i < vector3_5.Length - 1; i++)
			{
				smethod_68(list_13, vector3_5[i], vector3_5[i + 1], int_40);
			}
			smethod_68(list_13, vector3_5[vector3_5.Length - 1], vector3_5[0], int_40);
		}
	}

	private static void smethod_66(List<Struct74> list_13, Vector3 vector3_5, Vector3 vector3_6, int int_40)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		Vector3[] array = (Vector3[])(object)new Vector3[8]
		{
			vector3_5 + new Vector3(0f - vector3_6.X, 0f - vector3_6.Y, 0f - vector3_6.Z),
			vector3_5 + new Vector3(vector3_6.X, 0f - vector3_6.Y, 0f - vector3_6.Z),
			vector3_5 + new Vector3(vector3_6.X, 0f - vector3_6.Y, vector3_6.Z),
			vector3_5 + new Vector3(0f - vector3_6.X, 0f - vector3_6.Y, vector3_6.Z),
			vector3_5 + new Vector3(0f - vector3_6.X, vector3_6.Y, 0f - vector3_6.Z),
			vector3_5 + new Vector3(vector3_6.X, vector3_6.Y, 0f - vector3_6.Z),
			vector3_5 + new Vector3(vector3_6.X, vector3_6.Y, vector3_6.Z),
			vector3_5 + new Vector3(0f - vector3_6.X, vector3_6.Y, vector3_6.Z)
		};
		int[] array2 = new int[24]
		{
			0, 1, 1, 2, 2, 3, 3, 0, 4, 5,
			5, 6, 6, 7, 7, 4, 0, 4, 1, 5,
			2, 6, 3, 7
		};
		for (int i = 0; i < array2.Length; i += 2)
		{
			smethod_68(list_13, array[array2[i]], array[array2[i + 1]], int_40);
		}
	}

	private static void smethod_67(List<Struct74> list_13, Vector3 vector3_5, float float_14, int int_40)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		smethod_68(list_13, vector3_5 + new Vector3(0f - float_14, 0f, 0f), vector3_5 + new Vector3(float_14, 0f, 0f), int_40);
		smethod_68(list_13, vector3_5 + new Vector3(0f, 0f - float_14, 0f), vector3_5 + new Vector3(0f, float_14, 0f), int_40);
		smethod_68(list_13, vector3_5 + new Vector3(0f, 0f, 0f - float_14), vector3_5 + new Vector3(0f, 0f, float_14), int_40);
	}

	private static void smethod_68(List<Struct74> list_13, Vector3 vector3_5, Vector3 vector3_6, int int_40)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		if (list_13.Count + 2 <= 8192)
		{
			list_13.Add(new Struct74
			{
				vector3_0 = vector3_5,
				int_0 = int_40
			});
			list_13.Add(new Struct74
			{
				vector3_0 = vector3_6,
				int_0 = int_40
			});
		}
	}

	private void method_322(Point point_3)
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		int tickCount = Environment.TickCount;
		if (tickCount - int_33 < 50)
		{
			return;
		}
		int_33 = tickCount;
		if (!method_318(point_3, out var vector3_, out var vector3_2))
		{
			method_323();
			return;
		}
		Class301 @class = null;
		float num = float.MaxValue;
		for (int i = 0; i < list_9.Count; i++)
		{
			Class301 class2 = list_9[i];
			if (method_317(class2))
			{
				bool flag;
				float float_;
				switch (class2.enum20_0)
				{
				default:
					flag = false;
					float_ = float.MaxValue;
					break;
				case Enum20.RegionPolygon:
				case Enum20.PrecinctPolygon:
				{
					flag = smethod_69(vector3_, vector3_2, class2.vector3_0, out float_, out var _);
					break;
				}
				case Enum20.CityMarker:
				case Enum20.NpcMarker:
				case Enum20.FloraMarker:
					flag = smethod_71(vector3_, vector3_2, class2.vector3_1, Math.Max(1f, class2.float_0), out float_);
					break;
				case Enum20.TransportBox:
				case Enum20.LitModelObject:
				case Enum20.WaterArea:
				case Enum20.LightMarker:
				case Enum20.GfxMarker:
					flag = smethod_72(vector3_, vector3_2, class2.vector3_1 - class2.vector3_2, class2.vector3_1 + class2.vector3_2, out float_);
					break;
				}
				if (flag && !(float_ < 0f) && !(float_ >= num))
				{
					@class = class2;
					num = float_;
				}
			}
		}
		if (@class != class301_0)
		{
			class301_0 = @class;
			method_324();
		}
	}

	private void method_323()
	{
		if (class301_0 != null)
		{
			class301_0 = null;
			method_324();
		}
	}

	private void method_324()
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		try
		{
			VertexBuffer obj = vertexBuffer_2;
			if (obj != null)
			{
				((DisposeBase)obj).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_2 = null;
		int_13 = 0;
		if (device_0 != null && class301_0 != null && !list_10.Contains(class301_0))
		{
			List<Struct74> list = new List<Struct74>(64);
			int int_ = -1862270977;
			switch (class301_0.enum20_0)
			{
			case Enum20.RegionPolygon:
			case Enum20.PrecinctPolygon:
				smethod_65(list, class301_0.vector3_0, int_);
				break;
			case Enum20.CityMarker:
			case Enum20.NpcMarker:
			case Enum20.FloraMarker:
			{
				float float_ = Math.Max(2f, class301_0.float_0);
				smethod_67(list, class301_0.vector3_1, float_, int_);
				break;
			}
			case Enum20.TransportBox:
			case Enum20.LitModelObject:
			case Enum20.WaterArea:
			case Enum20.LightMarker:
			case Enum20.GfxMarker:
				smethod_66(list, class301_0.vector3_1, class301_0.vector3_2, int_);
				break;
			}
			if (list.Count > 1)
			{
				int_13 = list.Count;
				vertexBuffer_2 = new VertexBuffer(device_0, int_13 * Struct74.int_1, (Usage)8, (VertexFormat)0, (Pool)1);
				DataStream val = vertexBuffer_2.Lock(0, 0, (LockFlags)0);
				val.WriteRange<Struct74>(list.ToArray());
				vertexBuffer_2.Unlock();
			}
		}
	}

	private static bool smethod_69(Vector3 vector3_5, Vector3 vector3_6, Vector3[] vector3_7, out float float_14, out Vector3 vector3_8)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		float_14 = float.MaxValue;
		vector3_8 = Vector3.Zero;
		if (vector3_7 != null && vector3_7.Length >= 3)
		{
			bool result = false;
			Vector3 vector3_9 = vector3_7[0];
			for (int i = 1; i < vector3_7.Length - 1; i++)
			{
				if (smethod_70(vector3_5, vector3_6, vector3_9, vector3_7[i], vector3_7[i + 1], out var float_15) && float_15 < float_14)
				{
					float_14 = float_15;
					vector3_8 = vector3_5 + vector3_6 * float_15;
					result = true;
				}
			}
			return result;
		}
		return false;
	}

	private static bool smethod_70(Vector3 vector3_5, Vector3 vector3_6, Vector3 vector3_7, Vector3 vector3_8, Vector3 vector3_9, out float float_14)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		float_14 = 0f;
		Vector3 val = vector3_8 - vector3_7;
		Vector3 val2 = vector3_9 - vector3_7;
		Vector3 val3 = Vector3.Cross(vector3_6, val2);
		float num = Vector3.Dot(val, val3);
		if (Math.Abs(num) < 1E-06f)
		{
			return false;
		}
		float num2 = 1f / num;
		Vector3 val4 = vector3_5 - vector3_7;
		float num3 = Vector3.Dot(val4, val3) * num2;
		if (!(num3 < 0f) && num3 <= 1f)
		{
			Vector3 val5 = Vector3.Cross(val4, val);
			float num4 = Vector3.Dot(vector3_6, val5) * num2;
			if (!(num4 < 0f) && num3 + num4 <= 1f)
			{
				float num5 = Vector3.Dot(val2, val5) * num2;
				if (num5 < 1E-06f)
				{
					return false;
				}
				float_14 = num5;
				return true;
			}
			return false;
		}
		return false;
	}

	private static bool smethod_71(Vector3 vector3_5, Vector3 vector3_6, Vector3 vector3_7, float float_14, out float float_15)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		float_15 = 0f;
		Vector3 val = vector3_5 - vector3_7;
		float num = Vector3.Dot(val, vector3_6);
		float num2 = Vector3.Dot(val, val) - float_14 * float_14;
		if (num2 > 0f && num > 0f)
		{
			return false;
		}
		float num3 = num * num - num2;
		if (num3 < 0f)
		{
			return false;
		}
		float num4 = 0f - num - (float)Math.Sqrt(num3);
		if (num4 < 0f)
		{
			num4 = 0f;
		}
		float_15 = num4;
		return true;
	}

	private static bool smethod_72(Vector3 vector3_5, Vector3 vector3_6, Vector3 vector3_7, Vector3 vector3_8, out float float_14)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		float_14 = 0f;
		float float_15 = 0f;
		float float_16 = float.MaxValue;
		if (smethod_73(vector3_5.X, vector3_6.X, vector3_7.X, vector3_8.X, ref float_15, ref float_16) && smethod_73(vector3_5.Y, vector3_6.Y, vector3_7.Y, vector3_8.Y, ref float_15, ref float_16) && smethod_73(vector3_5.Z, vector3_6.Z, vector3_7.Z, vector3_8.Z, ref float_15, ref float_16))
		{
			float_14 = ((float_15 >= 0f) ? float_15 : float_16);
			return float_14 >= 0f;
		}
		return false;
	}

	private static bool smethod_73(float float_14, float float_15, float float_16, float float_17, ref float float_18, ref float float_19)
	{
		if (Math.Abs(float_15) < 1E-06f)
		{
			if (float_14 >= float_16)
			{
				return float_14 <= float_17;
			}
			return false;
		}
		float num = 1f / float_15;
		float num2 = (float_16 - float_14) * num;
		float num3 = (float_17 - float_14) * num;
		if (num2 > num3)
		{
			float num4 = num2;
			num2 = num3;
			num3 = num4;
		}
		float_18 = Math.Max(float_18, num2);
		float_19 = Math.Min(float_19, num3);
		return float_18 <= float_19;
	}

	private void method_325()
	{
		list_9.Clear();
		method_326();
		method_327();
		method_328();
		method_329();
	}

	private void method_326()
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		if (regionFile_0?.regions == null)
		{
			return;
		}
		for (int i = 0; i < regionFile_0.regions.Count; i++)
		{
			RegionEntry regionEntry = regionFile_0.regions[i];
			if (regionEntry?.Zones != null && regionEntry.Zones.Count >= 3)
			{
				Vector3[] array = (Vector3[])(object)new Vector3[regionEntry.Zones.Count];
				for (int j = 0; j < regionEntry.Zones.Count; j++)
				{
					array[j] = smethod_2(regionEntry.Zones[j]);
				}
				string arg = (Enum.IsDefined(typeof(RegionType), regionEntry.Type) ? ((RegionType)regionEntry.Type/*cast due to constrained. prefix*/).ToString() : Class16.smethod_0(1648936686));
				string arg2 = (string.IsNullOrWhiteSpace(regionEntry.name) ? Class16.smethod_0(1649201200) : regionEntry.name.Trim());
				list_9.Add(new Class301
				{
					enum20_0 = Enum20.RegionPolygon,
					int_0 = i,
					string_0 = string.Format(Class16.smethod_0(1649201216), i + 1, arg, arg2),
					vector3_0 = array
				});
			}
		}
	}

	private void method_327()
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		if (regionFile_0?.teleports == null)
		{
			return;
		}
		for (int i = 0; i < regionFile_0.teleports.Count; i++)
		{
			CELTransportBox cELTransportBox = regionFile_0.teleports[i];
			if (cELTransportBox != null)
			{
				list_9.Add(new Class301
				{
					enum20_0 = Enum20.TransportBox,
					int_0 = i,
					string_0 = string.Format(Class16.smethod_0(1649201252), i + 1, cELTransportBox.m_idInst),
					vector3_1 = smethod_2(cELTransportBox.tm_vPos),
					vector3_2 = new Vector3(Math.Abs(cELTransportBox.m_vExts.Single_0), Math.Abs(cELTransportBox.m_vExts.Single_1), Math.Abs(cELTransportBox.m_vExts.Single_2)),
					vector3_3 = smethod_2(cELTransportBox.m_vTarge),
					float_0 = 2.5f
				});
			}
		}
	}

	private void method_328()
	{
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		if (precinctFile_0?.zones == null)
		{
			return;
		}
		for (int i = 0; i < precinctFile_0.zones.Count; i++)
		{
			PrecinctEntry precinctEntry = precinctFile_0.zones[i];
			if (precinctEntry == null)
			{
				continue;
			}
			if (precinctEntry.m_aPoints != null && precinctEntry.m_aPoints.Count >= 3)
			{
				Vector3[] array = (Vector3[])(object)new Vector3[precinctEntry.m_aPoints.Count];
				for (int j = 0; j < precinctEntry.m_aPoints.Count; j++)
				{
					array[j] = smethod_3(precinctEntry.m_aPoints[j]);
				}
				string arg = (string.IsNullOrWhiteSpace(precinctEntry.name) ? Class16.smethod_0(1649201200) : precinctEntry.name.Trim());
				list_9.Add(new Class301
				{
					enum20_0 = Enum20.PrecinctPolygon,
					int_0 = i,
					string_0 = string.Format(Class16.smethod_0(1649201274), i + 1, precinctEntry.ID, arg),
					vector3_0 = array
				});
			}
			list_9.Add(new Class301
			{
				enum20_0 = Enum20.CityMarker,
				int_0 = i,
				string_0 = string.Format(Class16.smethod_0(1649201305), i + 1),
				vector3_1 = smethod_3(precinctEntry.m_vCityPos),
				float_0 = 4.8f
			});
			if (precinctEntry.Npcs == null)
			{
				continue;
			}
			for (int k = 0; k < precinctEntry.Npcs.Count; k++)
			{
				PrecinctNPC precinctNPC = precinctEntry.Npcs[k];
				if (precinctNPC != null)
				{
					string text = (string.IsNullOrWhiteSpace(precinctNPC.Name) ? Class16.smethod_0(1649201328) : precinctNPC.Name.Trim());
					list_9.Add(new Class301
					{
						enum20_0 = Enum20.NpcMarker,
						int_0 = i * 100000 + k,
						string_0 = Class16.smethod_0(1649201348) + text,
						vector3_1 = smethod_3(precinctNPC.position),
						float_0 = 3.2f
					});
				}
			}
		}
	}

	private void method_329()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		IReadOnlyList<Class314> readOnlyList = method_255();
		for (int i = 0; i < readOnlyList.Count; i++)
		{
			Class314 @class = readOnlyList[i];
			list_9.Add(new Class301
			{
				enum20_0 = Enum20.LitModelObject,
				int_0 = i,
				string_0 = @class.string_0,
				vector3_1 = @class.vector3_0,
				vector3_2 = @class.vector3_1,
				string_1 = @class.string_1,
				class314_0 = @class
			});
		}
		IReadOnlyList<Class314> readOnlyList2 = method_256();
		for (int j = 0; j < readOnlyList2.Count; j++)
		{
			Class314 class2 = readOnlyList2[j];
			list_9.Add(new Class301
			{
				enum20_0 = Enum20.WaterArea,
				int_0 = j,
				string_0 = class2.string_0,
				vector3_1 = class2.vector3_0,
				vector3_2 = class2.vector3_1,
				class314_0 = class2
			});
		}
		IReadOnlyList<Class314> readOnlyList3 = method_257();
		for (int k = 0; k < readOnlyList3.Count; k++)
		{
			Class314 class3 = readOnlyList3[k];
			float num = Math.Max(1.5f, Math.Max(class3.vector3_1.X, Math.Max(class3.vector3_1.Y, class3.vector3_1.Z)));
			list_9.Add(new Class301
			{
				enum20_0 = Enum20.FloraMarker,
				int_0 = k,
				string_0 = class3.string_0,
				vector3_1 = class3.vector3_0,
				vector3_2 = class3.vector3_1,
				float_0 = num,
				string_1 = class3.string_1,
				class314_0 = class3
			});
		}
		IReadOnlyList<Class314> readOnlyList4 = method_259();
		for (int l = 0; l < readOnlyList4.Count; l++)
		{
			Class314 class4 = readOnlyList4[l];
			list_9.Add(new Class301
			{
				enum20_0 = Enum20.LightMarker,
				int_0 = l,
				string_0 = class4.string_0,
				vector3_1 = class4.vector3_0,
				vector3_2 = class4.vector3_1,
				class314_0 = class4
			});
		}
		IReadOnlyList<Class314> readOnlyList5 = method_258();
		for (int m = 0; m < readOnlyList5.Count; m++)
		{
			Class314 class5 = readOnlyList5[m];
			float num2 = Math.Max(1.5f, Math.Max(class5.vector3_1.X, Math.Max(class5.vector3_1.Y, class5.vector3_1.Z)));
			list_9.Add(new Class301
			{
				enum20_0 = Enum20.GfxMarker,
				int_0 = m,
				string_0 = class5.string_0,
				vector3_1 = class5.vector3_0,
				vector3_2 = class5.vector3_1,
				float_0 = num2,
				string_1 = class5.string_1,
				class314_0 = class5
			});
		}
	}

	private void method_330()
	{
		tabPage_12 = new TabPage(Class16.smethod_0(1649201359));
		tabPage_12.UseVisualStyleBackColor = true;
		SplitContainer splitContainer = new SplitContainer
		{
			Dock = DockStyle.Fill,
			Orientation = Orientation.Horizontal,
			SplitterDistance = 160,
			FixedPanel = FixedPanel.Panel1
		};
		listView_17 = new ListView
		{
			Dock = DockStyle.Fill,
			View = View.Details,
			FullRowSelect = true,
			HideSelection = false,
			MultiSelect = false,
			GridLines = true
		};
		listView_17.Columns.Add(Class16.smethod_0(1648941057), 40);
		listView_17.Columns.Add(Class16.smethod_0(1648893587), 140);
		listView_17.Columns.Add(Class16.smethod_0(1649201361), 120);
		listView_17.SelectedIndexChanged += listView_17_SelectedIndexChanged;
		splitContainer.Panel1.Controls.Add(listView_17);
		tabControl_6 = new TabControl
		{
			Dock = DockStyle.Fill
		};
		tabPage_13 = new TabPage(Class16.smethod_0(1649089262));
		tabPage_14 = new TabPage(Class16.smethod_0(1649201383));
		tabPage_15 = new TabPage(Class16.smethod_0(1649085247));
		tabPage_16 = new TabPage(Class16.smethod_0(1649201396));
		tabPage_13.AutoScroll = true;
		tabPage_14.AutoScroll = true;
		tabPage_15.AutoScroll = true;
		tabPage_16.AutoScroll = true;
		tabControl_6.TabPages.AddRange(new TabPage[4] { tabPage_13, tabPage_14, tabPage_15, tabPage_16 });
		splitContainer.Panel2.Controls.Add(tabControl_6);
		tabPage_12.Controls.Add(splitContainer);
		tabControl_4.TabPages.Add(tabPage_12);
		method_116(Class16.smethod_0(1649212626), tabPage_12);
		method_336();
		method_338();
		method_334();
		method_344();
		method_347();
		method_333();
	}

	private void listView_17_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (listView_17.SelectedItems.Count == 0)
		{
			pwMapBoxArea_0 = null;
			return;
		}
		int index = listView_17.SelectedItems[0].Index;
		if (list_11 != null && index >= 0 && index < list_11.Count)
		{
			pwMapBoxArea_0 = list_11[index];
			method_332();
		}
	}

	private void method_331(List<PwMapBoxArea> list_13)
	{
		list_11 = list_13;
		listView_17.BeginUpdate();
		listView_17.Items.Clear();
		if (list_13 != null)
		{
			for (int i = 0; i < list_13.Count; i++)
			{
				PwMapBoxArea pwMapBoxArea = list_13[i];
				ListViewItem listViewItem = new ListViewItem(pwMapBoxArea.ExportId.ToString());
				listViewItem.SubItems.Add(pwMapBoxArea.FormatPosition());
				listViewItem.SubItems.Add(pwMapBoxArea.FormatExtents());
				listView_17.Items.Add(listViewItem);
				if (pwMapBoxArea.DefaultArea == 1 && listView_17.SelectedItems.Count == 0)
				{
					listViewItem.Selected = true;
				}
			}
		}
		listView_17.EndUpdate();
	}

	private void method_332()
	{
		bool_33 = true;
		try
		{
			method_337();
			method_339();
			method_335();
			method_346();
			method_348();
		}
		finally
		{
			bool_33 = false;
		}
	}

	private void method_333()
	{
		tabPage_17 = new TabPage(Class16.smethod_0(1649201406))
		{
			AutoScroll = true
		};
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Top,
			AutoSize = true,
			ColumnCount = 3,
			Padding = new Padding(4)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40f));
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648936875)), 0, 0);
		comboBox_10 = new ComboBox
		{
			DropDownStyle = ComboBoxStyle.DropDownList,
			Dock = DockStyle.Fill
		};
		comboBox_10.Items.AddRange(new object[6]
		{
			Class16.smethod_0(1649201411),
			Class16.smethod_0(1649201445),
			Class16.smethod_0(1649201459),
			Class16.smethod_0(1649201485),
			Class16.smethod_0(1649201501),
			Class16.smethod_0(1649201516)
		});
		comboBox_10.SelectedIndex = 0;
		comboBox_10.SelectedIndexChanged += comboBox_10_SelectedIndexChanged;
		tableLayoutPanel.SetColumnSpan(comboBox_10, 2);
		tableLayoutPanel.Controls.Add(comboBox_10, 1, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649201520)), 0, 1);
		trackBar_17 = smethod_74(10, 200, 100);
		label_35 = smethod_75(Class16.smethod_0(1648898309));
		tableLayoutPanel.Controls.Add(trackBar_17, 1, 1);
		tableLayoutPanel.Controls.Add(label_35, 2, 1);
		trackBar_17.ValueChanged += trackBar_17_ValueChanged;
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649201542)), 0, 2);
		trackBar_18 = smethod_74(0, 100, 100);
		label_36 = smethod_75(Class16.smethod_0(1648898309));
		tableLayoutPanel.Controls.Add(trackBar_18, 1, 2);
		tableLayoutPanel.Controls.Add(label_36, 2, 2);
		trackBar_18.ValueChanged += trackBar_18_ValueChanged;
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649085673)), 0, 3);
		trackBar_19 = smethod_74(0, 300, 100);
		label_37 = smethod_75(Class16.smethod_0(1648898309));
		tableLayoutPanel.Controls.Add(trackBar_19, 1, 3);
		tableLayoutPanel.Controls.Add(label_37, 2, 3);
		trackBar_19.ValueChanged += trackBar_19_ValueChanged;
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649085669)), 0, 4);
		trackBar_20 = smethod_74(25, 400, 100);
		label_38 = smethod_75(Class16.smethod_0(1648898309));
		tableLayoutPanel.Controls.Add(trackBar_20, 1, 4);
		tableLayoutPanel.Controls.Add(label_38, 2, 4);
		trackBar_20.ValueChanged += trackBar_20_ValueChanged;
		tabPage_17.Controls.Add(tableLayoutPanel);
		tabControl_6.TabPages.Add(tabPage_17);
	}

	private static TrackBar smethod_74(int int_40, int int_41, int int_42)
	{
		return new TrackBar
		{
			Minimum = int_40,
			Maximum = int_41,
			Value = Math.Max(int_40, Math.Min(int_41, int_42)),
			TickFrequency = (int_41 - int_40) / 10,
			Dock = DockStyle.Fill,
			AutoSize = false,
			Height = 30
		};
	}

	private void method_334()
	{
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Top,
			AutoSize = true,
			ColumnCount = 3,
			Padding = new Padding(4)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel.Controls.Add(smethod_75(string.Empty), 0, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648941238)), 1, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648915231)), 2, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649201556)), 0, 1);
		textBox_82 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_82, 1, 1);
		textBox_83 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_83, 2, 1);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649201572)), 0, 2);
		textBox_84 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_84, 1, 2);
		textBox_85 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_85, 2, 2);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649201578)), 0, 3);
		textBox_86 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_86, 1, 3);
		textBox_87 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_87, 2, 3);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649201604)), 0, 4);
		panel_25 = method_340();
		tableLayoutPanel.Controls.Add(panel_25, 1, 4);
		panel_26 = method_340();
		tableLayoutPanel.Controls.Add(panel_26, 2, 4);
		Label control = new Label
		{
			Text = Class16.smethod_0(1649201620),
			AutoSize = true,
			Font = new Font(Font.FontFamily, 8f, FontStyle.Bold)
		};
		tableLayoutPanel.SetColumnSpan(control, 3);
		tableLayoutPanel.Controls.Add(control, 0, 5);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649201637)), 0, 6);
		textBox_88 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_88, 1, 6);
		textBox_89 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_89, 2, 6);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649201652)), 0, 7);
		textBox_90 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_90, 1, 7);
		textBox_91 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_91, 2, 7);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649201657)), 0, 8);
		textBox_92 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_92, 1, 8);
		textBox_93 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_93, 2, 8);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649204746)), 0, 9);
		panel_27 = method_340();
		tableLayoutPanel.Controls.Add(panel_27, 1, 9);
		panel_28 = method_340();
		tableLayoutPanel.Controls.Add(panel_28, 2, 9);
		tabPage_16.Controls.Add(tableLayoutPanel);
	}

	private void method_335()
	{
		PwMapBoxArea pwMapBoxArea = pwMapBoxArea_0;
		if (pwMapBoxArea != null)
		{
			textBox_82.Text = pwMapBoxArea.FogStart.ToString(Class16.smethod_0(1648922976));
			textBox_83.Text = pwMapBoxArea.FogStartNight.ToString(Class16.smethod_0(1648922976));
			textBox_84.Text = pwMapBoxArea.FogEnd.ToString(Class16.smethod_0(1648922976));
			textBox_85.Text = pwMapBoxArea.FogEndNight.ToString(Class16.smethod_0(1648922976));
			textBox_86.Text = pwMapBoxArea.FogDensity.ToString(Class16.smethod_0(1649090699));
			textBox_87.Text = pwMapBoxArea.FogDensityNight.ToString(Class16.smethod_0(1649090699));
			panel_25.BackColor = PwMapBoxArea.ArgbIntToColor(pwMapBoxArea.FogColor);
			panel_26.BackColor = PwMapBoxArea.ArgbIntToColor(pwMapBoxArea.FogColorNight);
			textBox_88.Text = pwMapBoxArea.UwFogStart.ToString(Class16.smethod_0(1648922976));
			textBox_89.Text = pwMapBoxArea.UwFogStartNight.ToString(Class16.smethod_0(1648922976));
			textBox_90.Text = pwMapBoxArea.UwFogEnd.ToString(Class16.smethod_0(1648922976));
			textBox_91.Text = pwMapBoxArea.UwFogEndNight.ToString(Class16.smethod_0(1648922976));
			textBox_92.Text = pwMapBoxArea.UwFogDensity.ToString(Class16.smethod_0(1649090699));
			textBox_93.Text = pwMapBoxArea.UwFogDensityNight.ToString(Class16.smethod_0(1649090699));
			panel_27.BackColor = PwMapBoxArea.ArgbIntToColor(pwMapBoxArea.UwFogColor);
			panel_28.BackColor = PwMapBoxArea.ArgbIntToColor(pwMapBoxArea.UwFogColorNight);
			bool visible = pwMapBoxArea.Version >= 6;
			textBox_83.Visible = visible;
			textBox_85.Visible = visible;
			textBox_87.Visible = visible;
			panel_26.Visible = visible;
			bool visible2 = pwMapBoxArea.Version >= 11;
			textBox_89.Visible = visible2;
			textBox_91.Visible = visible2;
			textBox_93.Visible = visible2;
			panel_28.Visible = visible2;
		}
	}

	private void method_336()
	{
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Top,
			AutoSize = true,
			ColumnCount = 4,
			Padding = new Padding(4)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34f));
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			AutoSize = true,
			WrapContents = true
		};
		checkBox_47 = new CheckBox
		{
			Text = Class16.smethod_0(1648929202),
			AutoSize = true
		};
		checkBox_48 = new CheckBox
		{
			Text = Class16.smethod_0(1649204761),
			AutoSize = true
		};
		checkBox_49 = new CheckBox
		{
			Text = Class16.smethod_0(1649204776),
			AutoSize = true
		};
		checkBox_50 = new CheckBox
		{
			Text = Class16.smethod_0(1649204787),
			AutoSize = true
		};
		checkBox_51 = new CheckBox
		{
			Text = Class16.smethod_0(1649204806),
			AutoSize = true
		};
		checkBox_52 = new CheckBox
		{
			Text = Class16.smethod_0(1649012652),
			AutoSize = true
		};
		flowLayoutPanel.Controls.AddRange(new Control[6] { checkBox_47, checkBox_48, checkBox_49, checkBox_50, checkBox_51, checkBox_52 });
		tableLayoutPanel.SetColumnSpan(flowLayoutPanel, 4);
		tableLayoutPanel.Controls.Add(flowLayoutPanel, 0, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648893587)), 0, 1);
		textBox_94 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_94, 1, 1);
		textBox_95 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_95, 2, 1);
		textBox_96 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_96, 3, 1);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649201361)), 0, 2);
		textBox_97 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_97, 1, 2);
		textBox_98 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_98, 2, 2);
		textBox_99 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_99, 3, 2);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649204808)), 0, 3);
		textBox_100 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_100, 1, 3);
		textBox_101 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_101, 2, 3);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649204824)), 0, 4);
		textBox_102 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_102, 1, 4);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649204842)), 2, 4);
		textBox_103 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_103, 3, 4);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649204859)), 0, 5);
		textBox_116 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_116, 1, 5);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649204875)), 2, 5);
		textBox_117 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_117, 3, 5);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649211101)), 0, 6);
		textBox_118 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_118, 1, 6);
		groupBox_6 = new GroupBox
		{
			Text = Class16.smethod_0(1649204891),
			Dock = DockStyle.Top,
			Height = 55,
			Padding = new Padding(2)
		};
		TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 6,
			RowCount = 2
		};
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1648916476)), 0, 0);
		textBox_104 = smethod_76();
		tableLayoutPanel2.Controls.Add(textBox_104, 0, 1);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1649204907)), 1, 0);
		textBox_105 = smethod_76();
		tableLayoutPanel2.Controls.Add(textBox_105, 1, 1);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1649104909)), 2, 0);
		textBox_106 = smethod_76();
		tableLayoutPanel2.Controls.Add(textBox_106, 2, 1);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1649105837)), 3, 0);
		textBox_107 = smethod_76();
		tableLayoutPanel2.Controls.Add(textBox_107, 3, 1);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1649105861)), 4, 0);
		textBox_108 = smethod_76();
		tableLayoutPanel2.Controls.Add(textBox_108, 4, 1);
		tableLayoutPanel2.Controls.Add(smethod_75(Class16.smethod_0(1649204924)), 5, 0);
		textBox_109 = smethod_76();
		tableLayoutPanel2.Controls.Add(textBox_109, 5, 1);
		groupBox_6.Controls.Add(tableLayoutPanel2);
		tableLayoutPanel.SetColumnSpan(groupBox_6, 4);
		tableLayoutPanel.Controls.Add(groupBox_6, 0, 7);
		groupBox_7 = new GroupBox
		{
			Text = Class16.smethod_0(1649204933),
			Dock = DockStyle.Top,
			Height = 55,
			Padding = new Padding(2)
		};
		TableLayoutPanel tableLayoutPanel3 = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 6,
			RowCount = 2
		};
		tableLayoutPanel3.Controls.Add(smethod_75(Class16.smethod_0(1648916476)), 0, 0);
		textBox_110 = smethod_76();
		tableLayoutPanel3.Controls.Add(textBox_110, 0, 1);
		tableLayoutPanel3.Controls.Add(smethod_75(Class16.smethod_0(1649204907)), 1, 0);
		textBox_111 = smethod_76();
		tableLayoutPanel3.Controls.Add(textBox_111, 1, 1);
		tableLayoutPanel3.Controls.Add(smethod_75(Class16.smethod_0(1649104909)), 2, 0);
		textBox_112 = smethod_76();
		tableLayoutPanel3.Controls.Add(textBox_112, 2, 1);
		tableLayoutPanel3.Controls.Add(smethod_75(Class16.smethod_0(1649105837)), 3, 0);
		textBox_113 = smethod_76();
		tableLayoutPanel3.Controls.Add(textBox_113, 3, 1);
		tableLayoutPanel3.Controls.Add(smethod_75(Class16.smethod_0(1649105861)), 4, 0);
		textBox_114 = smethod_76();
		tableLayoutPanel3.Controls.Add(textBox_114, 4, 1);
		tableLayoutPanel3.Controls.Add(smethod_75(Class16.smethod_0(1649204924)), 5, 0);
		textBox_115 = smethod_76();
		tableLayoutPanel3.Controls.Add(textBox_115, 5, 1);
		groupBox_7.Controls.Add(tableLayoutPanel3);
		tableLayoutPanel.SetColumnSpan(groupBox_7, 4);
		tableLayoutPanel.Controls.Add(groupBox_7, 0, 8);
		tabPage_13.Controls.Add(tableLayoutPanel);
	}

	private void method_337()
	{
		PwMapBoxArea pwMapBoxArea = pwMapBoxArea_0;
		if (pwMapBoxArea != null)
		{
			checkBox_47.Checked = pwMapBoxArea.DefaultArea == 1;
			checkBox_48.Checked = pwMapBoxArea.HasFlag(1);
			checkBox_49.Checked = pwMapBoxArea.HasFlag(2);
			checkBox_50.Checked = pwMapBoxArea.HasFlag(4);
			checkBox_51.Checked = pwMapBoxArea.HasFlag(8);
			checkBox_52.Checked = pwMapBoxArea.HasFlag(16);
			bool flag = pwMapBoxArea.DefaultArea == 1;
			textBox_94.Text = pwMapBoxArea.PosX.ToString(Class16.smethod_0(1648922976));
			textBox_94.Enabled = !flag;
			textBox_95.Text = pwMapBoxArea.PosY.ToString(Class16.smethod_0(1648922976));
			textBox_95.Enabled = !flag;
			textBox_96.Text = pwMapBoxArea.PosZ.ToString(Class16.smethod_0(1648922976));
			textBox_96.Enabled = !flag;
			textBox_97.Text = pwMapBoxArea.HalfExtentX.ToString(Class16.smethod_0(1648922976));
			textBox_97.Enabled = !flag;
			textBox_98.Text = pwMapBoxArea.HalfExtentY.ToString(Class16.smethod_0(1648922976));
			textBox_98.Enabled = !flag;
			textBox_99.Text = pwMapBoxArea.HalfExtentZ.ToString(Class16.smethod_0(1648922976));
			textBox_99.Enabled = !flag;
			textBox_100.Text = pwMapBoxArea.SkySpeedX.ToString(Class16.smethod_0(1649090699));
			textBox_101.Text = pwMapBoxArea.SkySpeedY.ToString(Class16.smethod_0(1649090699));
			textBox_102.Text = pwMapBoxArea.TrnLtScale.ToString();
			textBox_103.Text = pwMapBoxArea.TransTime.ToString();
			textBox_116.Text = pwMapBoxArea.CapTileSpeed.ToString(Class16.smethod_0(1649090699));
			textBox_117.Text = pwMapBoxArea.CapRotSpeed.ToString(Class16.smethod_0(1649090699));
			textBox_118.Text = pwMapBoxArea.Priority.ToString();
			bool flag2 = pwMapBoxArea.Version >= 14;
			groupBox_6.Visible = flag2;
			groupBox_7.Visible = flag2;
			if (flag2)
			{
				textBox_104.Text = pwMapBoxArea.TmBornYear.ToString();
				textBox_105.Text = pwMapBoxArea.TmBornMonth.ToString();
				textBox_106.Text = pwMapBoxArea.TmBornWeek.ToString();
				textBox_107.Text = pwMapBoxArea.TmBornDay.ToString();
				textBox_108.Text = pwMapBoxArea.TmBornHour.ToString();
				textBox_109.Text = pwMapBoxArea.TmBornMinute.ToString();
				textBox_110.Text = pwMapBoxArea.TmDieYear.ToString();
				textBox_111.Text = pwMapBoxArea.TmDieMonth.ToString();
				textBox_112.Text = pwMapBoxArea.TmDieWeek.ToString();
				textBox_113.Text = pwMapBoxArea.TmDieDay.ToString();
				textBox_114.Text = pwMapBoxArea.TmDieHour.ToString();
				textBox_115.Text = pwMapBoxArea.TmDieMinute.ToString();
			}
		}
	}

	private void method_338()
	{
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Top,
			AutoSize = true,
			ColumnCount = 3,
			Padding = new Padding(4)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel.Controls.Add(smethod_75(string.Empty), 0, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648941238)), 1, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648915231)), 2, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649204948)), 0, 1);
		textBox_119 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_119, 1, 1);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649204966)), 0, 2);
		textBox_120 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_120, 1, 2);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649204976)), 0, 3);
		textBox_121 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_121, 1, 3);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649085262)), 0, 4);
		panel_31 = method_340();
		tableLayoutPanel.Controls.Add(panel_31, 1, 4);
		panel_32 = method_340();
		tableLayoutPanel.Controls.Add(panel_32, 2, 4);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649204994)), 0, 5);
		panel_33 = method_340();
		tableLayoutPanel.Controls.Add(panel_33, 1, 5);
		panel_34 = method_340();
		tableLayoutPanel.Controls.Add(panel_34, 2, 5);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649205010)), 0, 6);
		panel_35 = method_340();
		tableLayoutPanel.Controls.Add(panel_35, 1, 6);
		panel_36 = method_340();
		tableLayoutPanel.Controls.Add(panel_36, 2, 6);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649205026)), 0, 7);
		panel_37 = method_340();
		tableLayoutPanel.Controls.Add(panel_37, 1, 7);
		panel_38 = method_340();
		tableLayoutPanel.Controls.Add(panel_38, 2, 7);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649205042)), 0, 8);
		textBox_122 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_122, 1, 8);
		textBox_123 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_123, 2, 8);
		tabPage_15.Controls.Add(tableLayoutPanel);
	}

	private void method_339()
	{
		PwMapBoxArea pwMapBoxArea = pwMapBoxArea_0;
		if (pwMapBoxArea != null)
		{
			textBox_119.Text = pwMapBoxArea.LightDirX.ToString(Class16.smethod_0(1649090699));
			textBox_120.Text = pwMapBoxArea.LightDirY.ToString(Class16.smethod_0(1649090699));
			textBox_121.Text = pwMapBoxArea.LightDirZ.ToString(Class16.smethod_0(1649090699));
			panel_31.BackColor = PwMapBoxArea.ArgbIntToColor(pwMapBoxArea.Ambient);
			panel_32.BackColor = PwMapBoxArea.ArgbIntToColor(pwMapBoxArea.AmbientNight);
			panel_33.BackColor = PwMapBoxArea.ArgbIntToColor(pwMapBoxArea.DirLtCol);
			panel_34.BackColor = PwMapBoxArea.ArgbIntToColor(pwMapBoxArea.DirLtColNight);
			panel_35.BackColor = PwMapBoxArea.ArgbIntToColor(pwMapBoxArea.CloudAmb);
			panel_36.BackColor = PwMapBoxArea.ArgbIntToColor(pwMapBoxArea.CloudAmbNight);
			panel_37.BackColor = PwMapBoxArea.ArgbIntToColor(pwMapBoxArea.CloudDir);
			panel_38.BackColor = PwMapBoxArea.ArgbIntToColor(pwMapBoxArea.CloudDirNight);
			textBox_122.Text = pwMapBoxArea.SunPower.ToString(Class16.smethod_0(1649090699));
			textBox_123.Text = pwMapBoxArea.SunPowerNight.ToString(Class16.smethod_0(1649090699));
		}
	}

	private Panel method_340()
	{
		Panel panel = new Panel
		{
			Size = new Size(40, 24),
			BorderStyle = BorderStyle.FixedSingle,
			Cursor = Cursors.Hand,
			Margin = new Padding(2)
		};
		panel.Click += method_341;
		return panel;
	}

	private void method_341(object sender, EventArgs e)
	{
		if (bool_33 || pwMapBoxArea_0 == null)
		{
			return;
		}
		Panel panel = (Panel)sender;
		using ColorDialog colorDialog = new ColorDialog
		{
			Color = panel.BackColor,
			FullOpen = true
		};
		if (colorDialog.ShowDialog() == DialogResult.OK)
		{
			panel.BackColor = colorDialog.Color;
			method_342(panel, colorDialog.Color);
		}
	}

	private void method_342(Panel panel_41, Color color_0)
	{
		PwMapBoxArea pwMapBoxArea = pwMapBoxArea_0;
		if (pwMapBoxArea != null)
		{
			int num = PwMapBoxArea.ColorToArgbInt(color_0);
			if (panel_41 == panel_31)
			{
				pwMapBoxArea.Ambient = num;
			}
			else if (panel_41 == panel_32)
			{
				pwMapBoxArea.AmbientNight = num;
			}
			else if (panel_41 == panel_33)
			{
				pwMapBoxArea.DirLtCol = num;
			}
			else if (panel_41 == panel_34)
			{
				pwMapBoxArea.DirLtColNight = num;
			}
			else if (panel_41 == panel_35)
			{
				pwMapBoxArea.CloudAmb = num;
			}
			else if (panel_41 == panel_36)
			{
				pwMapBoxArea.CloudAmbNight = num;
			}
			else if (panel_41 == panel_37)
			{
				pwMapBoxArea.CloudDir = num;
			}
			else if (panel_41 == panel_38)
			{
				pwMapBoxArea.CloudDirNight = num;
			}
			else if (panel_41 == panel_25)
			{
				pwMapBoxArea.FogColor = num;
			}
			else if (panel_41 == panel_26)
			{
				pwMapBoxArea.FogColorNight = num;
			}
			else if (panel_41 == panel_27)
			{
				pwMapBoxArea.UwFogColor = num;
			}
			else if (panel_41 == panel_28)
			{
				pwMapBoxArea.UwFogColorNight = num;
			}
			else if (panel_41 == panel_39)
			{
				pwMapBoxArea.RainColor = num;
			}
			else if (panel_41 == panel_40)
			{
				pwMapBoxArea.SnowColor = num;
			}
		}
	}

	private void method_343()
	{
		if (pwMapTrn2File_0 != null && pwMapFileLayout_0.HasMapRoot)
		{
			string text = method_251();
			string text2 = method_252();
			if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2))
			{
				List<PwMapBoxArea> list_ = PwMapBoxAreaLoader.Load(text, text2);
				method_331(list_);
			}
		}
	}

	private void method_344()
	{
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Top,
			AutoSize = true,
			ColumnCount = 3,
			Padding = new Padding(4)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel.Controls.Add(smethod_75(string.Empty), 0, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648941238)), 1, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648915231)), 2, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649205058)), 0, 1);
		Panel control = method_345(out pictureBox_10, out textBox_124);
		tableLayoutPanel.Controls.Add(control, 1, 1);
		Panel control2 = method_345(out pictureBox_13, out textBox_125);
		tableLayoutPanel.Controls.Add(control2, 2, 1);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649205076)), 0, 2);
		Panel control3 = method_345(out pictureBox_11, out textBox_126);
		tableLayoutPanel.Controls.Add(control3, 1, 2);
		Panel control4 = method_345(out pictureBox_14, out textBox_127);
		tableLayoutPanel.Controls.Add(control4, 2, 2);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648987343)), 0, 3);
		Panel control5 = method_345(out pictureBox_12, out textBox_128);
		tableLayoutPanel.Controls.Add(control5, 1, 3);
		Panel control6 = method_345(out pictureBox_15, out textBox_129);
		tableLayoutPanel.Controls.Add(control6, 2, 3);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649205080)), 0, 4);
		textBox_130 = smethod_76();
		textBox_130.ReadOnly = true;
		tableLayoutPanel.SetColumnSpan(textBox_130, 2);
		tableLayoutPanel.Controls.Add(textBox_130, 1, 4);
		tabPage_14.Controls.Add(tableLayoutPanel);
	}

	private Panel method_345(out PictureBox pictureBox_16, out TextBox textBox_135)
	{
		Panel panel = new Panel
		{
			Height = 100,
			Dock = DockStyle.Fill
		};
		pictureBox_16 = new PictureBox
		{
			Size = new Size(80, 80),
			SizeMode = PictureBoxSizeMode.StretchImage,
			BorderStyle = BorderStyle.FixedSingle,
			Location = new Point(2, 2)
		};
		textBox_135 = new TextBox
		{
			ReadOnly = true,
			Location = new Point(2, 84),
			Width = 120,
			Font = new Font(Class16.smethod_0(1648942905), 7f)
		};
		panel.Controls.Add(pictureBox_16);
		panel.Controls.Add(textBox_135);
		return panel;
	}

	private void method_346()
	{
		PwMapBoxArea pwMapBoxArea = pwMapBoxArea_0;
		if (pwMapBoxArea != null)
		{
			textBox_124.Text = pwMapBoxArea.SkyFile0;
			textBox_125.Text = pwMapBoxArea.SkyFile0Night;
			textBox_126.Text = pwMapBoxArea.SkyFile1;
			textBox_127.Text = pwMapBoxArea.SkyFile1Night;
			textBox_128.Text = pwMapBoxArea.SkyFile2;
			textBox_129.Text = pwMapBoxArea.SkyFile2Night;
			textBox_130.Text = pwMapBoxArea.MusicFile;
			pictureBox_10.Image = null;
			pictureBox_13.Image = null;
			pictureBox_11.Image = null;
			pictureBox_14.Image = null;
			pictureBox_12.Image = null;
			pictureBox_15.Image = null;
		}
	}

	private static Label smethod_75(string string_6)
	{
		return new Label
		{
			Text = string_6,
			AutoSize = true,
			Anchor = AnchorStyles.Left,
			Margin = new Padding(2)
		};
	}

	private static TextBox smethod_76()
	{
		return new TextBox
		{
			Dock = DockStyle.Fill,
			Margin = new Padding(2)
		};
	}

	private void method_347()
	{
		tabPage_18 = new TabPage(Class16.smethod_0(1649205100))
		{
			AutoScroll = true
		};
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Top,
			AutoSize = true,
			ColumnCount = 3,
			Padding = new Padding(4)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		tableLayoutPanel.Controls.Add(smethod_75(string.Empty), 0, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649204776)), 1, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649204787)), 2, 0);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649085884)), 0, 1);
		panel_39 = method_340();
		tableLayoutPanel.Controls.Add(panel_39, 1, 1);
		panel_40 = method_340();
		tableLayoutPanel.Controls.Add(panel_40, 2, 1);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1648980967)), 0, 2);
		textBox_131 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_131, 1, 2);
		textBox_132 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_132, 2, 2);
		tableLayoutPanel.Controls.Add(smethod_75(Class16.smethod_0(1649085673)), 0, 3);
		textBox_133 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_133, 1, 3);
		textBox_134 = smethod_76();
		tableLayoutPanel.Controls.Add(textBox_134, 2, 3);
		Label control = new Label
		{
			Text = Class16.smethod_0(1649205106),
			AutoSize = true,
			Margin = new Padding(4, 12, 4, 4)
		};
		tableLayoutPanel.SetColumnSpan(control, 3);
		tableLayoutPanel.Controls.Add(control, 0, 4);
		tabPage_18.Controls.Add(tableLayoutPanel);
		tabControl_6.TabPages.Add(tabPage_18);
	}

	private void method_348()
	{
		PwMapBoxArea pwMapBoxArea = pwMapBoxArea_0;
		if (pwMapBoxArea != null)
		{
			panel_39.BackColor = PwMapBoxArea.ArgbIntToColor(pwMapBoxArea.RainColor);
			panel_40.BackColor = PwMapBoxArea.ArgbIntToColor(pwMapBoxArea.SnowColor);
			textBox_131.Text = pwMapBoxArea.RainSize.ToString(Class16.smethod_0(1648922976));
			textBox_132.Text = pwMapBoxArea.SnowSize.ToString(Class16.smethod_0(1648922976));
			textBox_133.Text = pwMapBoxArea.RainSpeed.ToString();
			textBox_134.Text = pwMapBoxArea.SnowSpeed.ToString();
		}
	}

	private void method_349()
	{
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		if (list_10.Count == 0 && class301_1 != null)
		{
			list_10.Add(class301_1);
		}
		if (list_10.Count == 0)
		{
			method_120(Class16.smethod_0(1649205211), null);
			return;
		}
		if (pwMapTrn2File_0 == null)
		{
			method_120(Class16.smethod_0(1649204230), null);
			return;
		}
		int num = 0;
		foreach (Class301 item in list_10)
		{
			float num2 = method_235(item.vector3_1.X, item.vector3_1.Z);
			if (float.IsNaN(num2))
			{
				continue;
			}
			int num3 = list_4.Count - 1;
			while (num3 >= 0)
			{
				Class314 @class = list_4[num3];
				if (!string.Equals(@class.string_0, item.string_0, StringComparison.OrdinalIgnoreCase) || Vector3.DistanceSquared(@class.vector3_0, item.vector3_1) >= 1f)
				{
					num3--;
					continue;
				}
				@class.vector3_0 = new Vector3(@class.vector3_0.X, num2, @class.vector3_0.Z);
				item.vector3_1 = @class.vector3_0;
				num++;
				break;
			}
		}
		if (num > 0)
		{
			method_139();
			method_120(string.Format(Class16.smethod_0(1649204268), num), null);
		}
		else
		{
			method_120(Class16.smethod_0(1649204308), null);
		}
	}

	private void method_350()
	{
		pwMapTrn2File_0 = null;
		dictionary_6.Clear();
		hashSet_0.Clear();
		method_368(bool_37: true);
		string text = method_352();
		if (!string.IsNullOrWhiteSpace(text))
		{
			try
			{
				pwMapTrn2File_0 = PwMapTrn2File.Load(text);
			}
			catch
			{
				pwMapTrn2File_0 = null;
			}
		}
		bool flag = pwMapTrn2File_0 != null;
		checkBox_28.Enabled = flag;
		toolStripButton_7.Enabled = flag;
		if (!flag)
		{
			checkBox_28.Checked = false;
		}
		method_126();
		method_353();
		method_365();
		method_64();
	}

	private void method_351()
	{
		pwMapTrn2File_0 = null;
		dictionary_6.Clear();
		hashSet_0.Clear();
		method_368(bool_37: true);
		string text = method_352();
		if (!string.IsNullOrWhiteSpace(text))
		{
			try
			{
				pwMapTrn2File_0 = PwMapTrn2File.Load(text);
			}
			catch
			{
				pwMapTrn2File_0 = null;
			}
		}
		bool flag = pwMapTrn2File_0 != null;
		checkBox_28.Enabled = flag;
		toolStripButton_7.Enabled = flag;
		if (!flag)
		{
			checkBox_28.Checked = false;
		}
		method_126();
	}

	private string method_352()
	{
		if (!string.IsNullOrWhiteSpace(pwMapFileLayout_0?.WorldFile) && string.Equals(System.IO.Path.GetExtension(pwMapFileLayout_0.WorldFile), Class16.smethod_0(1649090223), StringComparison.OrdinalIgnoreCase) && File.Exists(pwMapFileLayout_0.WorldFile))
		{
			return pwMapFileLayout_0.WorldFile;
		}
		if (!string.IsNullOrWhiteSpace(pwMapFileLayout_0?.MapRootPath) && Directory.Exists(pwMapFileLayout_0.MapRootPath))
		{
			try
			{
				using IEnumerator<string> enumerator = Directory.EnumerateFiles(pwMapFileLayout_0.MapRootPath, Class16.smethod_0(1649089744), SearchOption.AllDirectories).GetEnumerator();
				if (enumerator.MoveNext())
				{
					return enumerator.Current;
				}
			}
			catch
			{
			}
			return string.Empty;
		}
		return string.Empty;
	}

	private void method_353()
	{
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		if (device_0 == null)
		{
			return;
		}
		try
		{
			VertexBuffer obj = vertexBuffer_12;
			if (obj != null)
			{
				((DisposeBase)obj).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_12 = null;
		int_35 = 0;
		try
		{
			VertexBuffer obj3 = vertexBuffer_13;
			if (obj3 != null)
			{
				((DisposeBase)obj3).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_13 = null;
		int_36 = 0;
		method_368(bool_37: false);
		if (pwMapTrn2File_0 != null)
		{
			var (list, list2, dictionary_) = method_354();
			method_366(dictionary_);
			if (list_12.Count == 0 && list2.Count > 2)
			{
				int_36 = list2.Count;
				vertexBuffer_13 = new VertexBuffer(device_0, int_36 * Struct74.int_1, (Usage)8, (VertexFormat)0, (Pool)1);
				DataStream val = vertexBuffer_13.Lock(0, 0, (LockFlags)0);
				val.WriteRange<Struct74>(list2.ToArray());
				vertexBuffer_13.Unlock();
			}
			if (list.Count > 1)
			{
				int_35 = list.Count;
				vertexBuffer_12 = new VertexBuffer(device_0, int_35 * Struct74.int_1, (Usage)8, (VertexFormat)0, (Pool)1);
				DataStream val2 = vertexBuffer_12.Lock(0, 0, (LockFlags)0);
				val2.WriteRange<Struct74>(list.ToArray());
				vertexBuffer_12.Unlock();
			}
		}
	}

	private (List<Struct74>, List<Struct74>, Dictionary<string, List<Struct79>>) method_354()
	{
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		List<Struct74> list = new List<Struct74>(65536);
		List<Struct74> list2 = new List<Struct74>(65536);
		Dictionary<string, List<Struct79>> dictionary = new Dictionary<string, List<Struct79>>(StringComparer.OrdinalIgnoreCase);
		if (pwMapTrn2File_0 != null && pwMapTrn2File_0.TotalSectors > 0 && pwMapTrn2File_0.SectorsWide > 0 && pwMapTrn2File_0.SectorsHigh > 0)
		{
			bool flag = checkBox_28.Checked || bool_7;
			method_356(out var float_, out var float_2);
			float num = pwMapTrn2File_0.Width / (float)pwMapTrn2File_0.SectorsWide;
			float num2 = pwMapTrn2File_0.Height / (float)pwMapTrn2File_0.SectorsHigh;
			float num3 = (0f - pwMapTrn2File_0.Width) * 0.5f;
			float num4 = pwMapTrn2File_0.Height * 0.5f;
			float float_3 = pwMapTrn2File_0.Width * 0.5f;
			float float_4 = pwMapTrn2File_0.Height * 0.5f;
			float float_5 = Math.Max(1f, pwMapTrn2File_0.BlockSize);
			IReadOnlyList<string> readOnlyList = method_355();
			float float_6 = Math.Max(0.75f, pwMapTrn2File_0.GridSize);
			float num5 = smethod_77(float_6, num, num2, pwMapTrn2File_0.TotalSectors);
			int num6 = Math.Max(4, (int)Math.Ceiling(num / num5));
			int num7 = Math.Max(4, (int)Math.Ceiling(num2 / num5));
			int num8 = num6 + 1;
			int num9 = num7 + 1;
			for (int i = 0; i < pwMapTrn2File_0.TotalSectors; i++)
			{
				List<Struct79> value = null;
				if (readOnlyList.Count > 0)
				{
					string text = readOnlyList[Math.Abs(i) % readOnlyList.Count];
					if (!string.IsNullOrWhiteSpace(text) && !dictionary.TryGetValue(text, out value))
					{
						value = (dictionary[text] = new List<Struct79>(65536));
					}
				}
				int num10 = i / pwMapTrn2File_0.SectorsWide;
				int num11 = i % pwMapTrn2File_0.SectorsWide;
				float num12 = num3 + (float)num11 * num;
				float num13 = num4 - (float)num10 * num2;
				float num14 = num12 + num * 0.5f;
				float num15 = num13 - num2 * 0.5f;
				PwMapT2bkFile pwMapT2bkFile = method_363(i, (int)num, (int)num2);
				float num16 = method_364(i);
				Vector3[,] array = new Vector3[num9, num8];
				for (int j = 0; j < num9; j++)
				{
					float num17 = ((num7 == 0) ? 0f : ((float)j / (float)num7 * num2));
					float num18 = num13 - num17;
					for (int k = 0; k < num8; k++)
					{
						float num19 = ((num6 == 0) ? 0f : ((float)k / (float)num6 * num));
						float num20 = num12 + num19;
						float num21 = num16;
						if (pwMapT2bkFile != null)
						{
							num21 = pwMapT2bkFile.GetHeightAtSectorPos(num20 - num14, num18 - num15);
						}
						array[j, k] = new Vector3(num20, num21, 0f - num18);
					}
				}
				if (flag)
				{
					for (int l = 0; l < num9; l++)
					{
						for (int m = 0; m < num8 - 1; m++)
						{
							method_357(list, array[l, m], array[l, m + 1], -12686016);
						}
					}
					for (int n = 0; n < num9 - 1; n++)
					{
						for (int num22 = 0; num22 < num8; num22++)
						{
							method_357(list, array[n, num22], array[n + 1, num22], -12686016);
						}
					}
				}
				for (int num23 = 0; num23 < num9 - 1; num23++)
				{
					for (int num24 = 0; num24 < num8 - 1; num24++)
					{
						Vector3 vector3_ = array[num23, num24];
						Vector3 val = array[num23, num24 + 1];
						Vector3 vector3_2 = array[num23 + 1, num24];
						Vector3 vector3_3 = array[num23 + 1, num24 + 1];
						if (value != null)
						{
							smethod_78(value, vector3_, val, vector3_2, float_, float_2, float_3, float_4, float_5);
							smethod_78(value, val, vector3_3, vector3_2, float_, float_2, float_3, float_4, float_5);
						}
						else
						{
							method_358(list2, vector3_, val, vector3_2, float_, float_2);
							method_358(list2, val, vector3_3, vector3_2, float_, float_2);
						}
					}
				}
			}
			return (list, list2, dictionary);
		}
		return (list, list2, dictionary);
	}

	private IReadOnlyList<string> method_355()
	{
		List<string> list = new List<string>();
		if (pwMapTrn2File_0?.DdsFiles != null && pwMapTrn2File_0.DdsFiles.Count != 0 && method_306())
		{
			HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			for (int i = 0; i < pwMapTrn2File_0.DdsFiles.Count; i++)
			{
				string text = method_288(pwMapTrn2File_0.DdsFiles[i], string.Empty);
				if (!string.IsNullOrWhiteSpace(text) && hashSet.Add(text))
				{
					list.Add(text);
				}
			}
			return list;
		}
		return list;
	}

	private static float smethod_77(float float_14, float float_15, float float_16, int int_40)
	{
		float num = Math.Max(0.75f, float_14);
		if (!(float_15 <= 0f) && !(float_16 <= 0f) && int_40 > 0)
		{
			float num2 = Math.Max(float_15, float_16);
			while (num < num2)
			{
				int num3 = Math.Max(4, (int)Math.Ceiling(float_15 / num));
				int num4 = Math.Max(4, (int)Math.Ceiling(float_16 / num));
				long num5 = (long)num3 * (long)num4 * 6L * int_40;
				long num6 = (num3 * (num4 + 1L) + num4 * (num3 + 1L)) * 2L * int_40;
				if (num5 <= 4800000L && num6 <= 2400000L)
				{
					break;
				}
				num *= 1.25f;
			}
			return num;
		}
		return num;
	}

	private void method_356(out float float_14, out float float_15)
	{
		float_14 = 0f;
		float_15 = 1f;
		if (pwMapTrn2File_0?.SectorHeights != null && pwMapTrn2File_0.SectorHeights.Count != 0)
		{
			float_14 = ((IEnumerable<(float, float)>)pwMapTrn2File_0.SectorHeights).Min((Func<(float, float), float>)Class317.class317_0.method_8);
			float_15 = ((IEnumerable<(float, float)>)pwMapTrn2File_0.SectorHeights).Max((Func<(float, float), float>)Class317.class317_0.method_9);
			if (float_15 - float_14 < 0.0001f)
			{
				float_15 = float_14 + 1f;
			}
		}
	}

	private void method_357(List<Struct74> list_13, Vector3 vector3_5, Vector3 vector3_6, int int_40)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		if (list_13.Count + 2 <= 2400000)
		{
			list_13.Add(new Struct74
			{
				vector3_0 = vector3_5,
				int_0 = int_40
			});
			list_13.Add(new Struct74
			{
				vector3_0 = vector3_6,
				int_0 = int_40
			});
		}
	}

	private void method_358(List<Struct74> list_13, Vector3 vector3_5, Vector3 vector3_6, Vector3 vector3_7, float float_14, float float_15)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		if (list_13.Count + 3 <= 4800000)
		{
			Vector3 val = Vector3.Cross(vector3_6 - vector3_5, vector3_7 - vector3_5);
			if (val.LengthSquared() > 1E-05f)
			{
				val.Normalize();
			}
			else
			{
				val = Vector3.UnitY;
			}
			if (val.Y < 0f)
			{
				val = -val;
			}
			list_13.Add(new Struct74
			{
				vector3_0 = vector3_5,
				int_0 = smethod_80(val, vector3_5.Y, float_14, float_15)
			});
			list_13.Add(new Struct74
			{
				vector3_0 = vector3_6,
				int_0 = smethod_80(val, vector3_6.Y, float_14, float_15)
			});
			list_13.Add(new Struct74
			{
				vector3_0 = vector3_7,
				int_0 = smethod_80(val, vector3_7.Y, float_14, float_15)
			});
		}
	}

	private static void smethod_78(List<Struct79> list_13, Vector3 vector3_5, Vector3 vector3_6, Vector3 vector3_7, float float_14, float float_15, float float_16, float float_17, float float_18)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		if (list_13.Count + 3 <= 4800000)
		{
			Vector3 val = Vector3.Cross(vector3_6 - vector3_5, vector3_7 - vector3_5);
			if (val.LengthSquared() > 1E-05f)
			{
				val.Normalize();
			}
			else
			{
				val = Vector3.UnitY;
			}
			if (val.Y < 0f)
			{
				val = -val;
			}
			smethod_79(list_13, vector3_5, smethod_80(val, vector3_5.Y, float_14, float_15), float_16, float_17, float_18);
			smethod_79(list_13, vector3_6, smethod_80(val, vector3_6.Y, float_14, float_15), float_16, float_17, float_18);
			smethod_79(list_13, vector3_7, smethod_80(val, vector3_7.Y, float_14, float_15), float_16, float_17, float_18);
		}
	}

	private static void smethod_79(List<Struct79> list_13, Vector3 vector3_5, int int_40, float float_14, float float_15, float float_16)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		float num = (vector3_5.X + float_14) / float_16;
		float num2 = (0f - vector3_5.Z + float_15) / float_16;
		list_13.Add(new Struct79
		{
			vector3_0 = vector3_5,
			int_0 = int_40,
			float_0 = num,
			float_1 = num2
		});
	}

	private static int smethod_80(Vector3 vector3_5, float float_14, float float_15, float float_16)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = default(Vector3);
		val = new Vector3(-0.35f, 0.82f, 0.45f);
		val.Normalize();
		float num = Math.Max(0f, Vector3.Dot(vector3_5, val));
		float num2 = 1f - Math.Max(0f, Math.Min(1f, vector3_5.Y));
		float val2 = (float_14 - float_15) / Math.Max(0.0001f, float_16 - float_15);
		val2 = Math.Max(0f, Math.Min(1f, val2));
		float num3 = 0.38f + num * 0.62f;
		float num4 = 1f - num2 * 0.35f;
		float num5 = 0.92f + val2 * 0.22f;
		float num6 = 78f * num3 * num4 * num5;
		float num7 = 112f * num3 * num4 * num5;
		float num8 = 71f * num3 * num4 * (0.9f + val2 * 0.18f);
		byte b = (byte)Math.Max(0, Math.Min(255, (int)Math.Round(num6)));
		byte b2 = (byte)Math.Max(0, Math.Min(255, (int)Math.Round(num7)));
		byte b3 = (byte)Math.Max(0, Math.Min(255, (int)Math.Round(num8)));
		return -16777216 | (b << 16) | (b2 << 8) | b3;
	}

	private void method_359()
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		method_360();
		if (pwMapTrn2File_0 == null || device_0 == null)
		{
			return;
		}
		int sectorsWide = pwMapTrn2File_0.SectorsWide;
		int sectorsHigh = pwMapTrn2File_0.SectorsHigh;
		if (sectorsWide > 0 && sectorsHigh > 0)
		{
			float num = pwMapTrn2File_0.Width;
			float num2 = pwMapTrn2File_0.Height;
			float float_ = num / (float)sectorsWide;
			float float_2 = num2 / (float)sectorsHigh;
			float float_3 = (0f - num) * 0.5f;
			float float_4 = num2 * 0.5f;
			List<Struct74> list = new List<Struct74>(sectorsWide * sectorsHigh * 8 * 8 * 6);
			List<Struct74> list2 = new List<Struct74>(4096);
			for (int i = 0; i < sectorsWide * sectorsHigh; i++)
			{
				int int_ = i / sectorsWide;
				int int_2 = i % sectorsWide;
				int int_3 = ((pwMapPassMapProfile_0 != null && i < pwMapPassMapProfile_0.Sectors.Count && pwMapPassMapProfile_0.Sectors[i].Dungeon) ? 1355284480 : 1342228480);
				method_361(list, int_2, int_, float_, float_2, float_3, float_4, 8, int_3);
			}
			method_362(list2, sectorsWide, sectorsHigh, float_, float_2, float_3, float_4, -1056964609);
			if (list.Count >= 3)
			{
				int_37 = list.Count;
				vertexBuffer_14 = new VertexBuffer(device_0, int_37 * Struct74.int_1, (Usage)8, (VertexFormat)0, (Pool)1);
				DataStream val = vertexBuffer_14.Lock(0, 0, (LockFlags)0);
				val.WriteRange<Struct74>(list.ToArray());
				vertexBuffer_14.Unlock();
			}
			if (list2.Count >= 2)
			{
				int_38 = list2.Count;
				vertexBuffer_15 = new VertexBuffer(device_0, int_38 * Struct74.int_1, (Usage)8, (VertexFormat)0, (Pool)1);
				DataStream val2 = vertexBuffer_15.Lock(0, 0, (LockFlags)0);
				val2.WriteRange<Struct74>(list2.ToArray());
				vertexBuffer_15.Unlock();
			}
		}
	}

	private void method_360()
	{
		try
		{
			VertexBuffer obj = vertexBuffer_14;
			if (obj != null)
			{
				((DisposeBase)obj).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_14 = null;
		int_37 = 0;
		try
		{
			VertexBuffer obj3 = vertexBuffer_15;
			if (obj3 != null)
			{
				((DisposeBase)obj3).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_15 = null;
		int_38 = 0;
	}

	private void method_361(List<Struct74> list_13, int int_40, int int_41, float float_14, float float_15, float float_16, float float_17, int int_42, int int_43)
	{
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		float num = float_14 / (float)int_42;
		float num2 = float_15 / (float)int_42;
		float num3 = float_16 + (float)int_40 * float_14;
		float num4 = float_17 - (float)int_41 * float_15;
		Vector3 val = default(Vector3);
		Vector3 val2 = default(Vector3);
		Vector3 val3 = default(Vector3);
		Vector3 val4 = default(Vector3);
		for (int i = 0; i < int_42; i++)
		{
			for (int j = 0; j < int_42; j++)
			{
				float num5 = num3 + (float)j * num;
				float num6 = num5 + num;
				float num7 = num4 - (float)i * num2;
				float num8 = num7 - num2;
				float num9 = 0.2f;
				val = new Vector3(num5, method_235(num5, num7) + num9, 0f - num7);
				val2 = new Vector3(num6, method_235(num6, num7) + num9, 0f - num7);
				val3 = new Vector3(num5, method_235(num5, num8) + num9, 0f - num8);
				val4 = new Vector3(num6, method_235(num6, num8) + num9, 0f - num8);
				list_13.Add(new Struct74
				{
					vector3_0 = val,
					int_0 = int_43
				});
				list_13.Add(new Struct74
				{
					vector3_0 = val2,
					int_0 = int_43
				});
				list_13.Add(new Struct74
				{
					vector3_0 = val3,
					int_0 = int_43
				});
				list_13.Add(new Struct74
				{
					vector3_0 = val2,
					int_0 = int_43
				});
				list_13.Add(new Struct74
				{
					vector3_0 = val4,
					int_0 = int_43
				});
				list_13.Add(new Struct74
				{
					vector3_0 = val3,
					int_0 = int_43
				});
			}
		}
	}

	private void method_362(List<Struct74> list_13, int int_40, int int_41, float float_14, float float_15, float float_16, float float_17, int int_42)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i <= int_41; i++)
		{
			float num = float_17 - (float)i * float_15;
			for (int j = 0; j < int_40 * 12; j++)
			{
				float num2 = float_16 + (float)j / 12f * float_14;
				float num3 = float_16 + (float)(j + 1) / 12f * float_14;
				float num4 = method_235(num2, num) + 0.4f;
				float num5 = method_235(num3, num) + 0.4f;
				list_13.Add(new Struct74
				{
					vector3_0 = new Vector3(num2, num4, 0f - num),
					int_0 = int_42
				});
				list_13.Add(new Struct74
				{
					vector3_0 = new Vector3(num3, num5, 0f - num),
					int_0 = int_42
				});
			}
		}
		for (int k = 0; k <= int_40; k++)
		{
			float num6 = float_16 + (float)k * float_14;
			for (int l = 0; l < int_41 * 12; l++)
			{
				float num7 = float_17 - (float)l / 12f * float_15;
				float num8 = float_17 - (float)(l + 1) / 12f * float_15;
				float num9 = method_235(num6, num7) + 0.4f;
				float num10 = method_235(num6, num8) + 0.4f;
				list_13.Add(new Struct74
				{
					vector3_0 = new Vector3(num6, num9, 0f - num7),
					int_0 = int_42
				});
				list_13.Add(new Struct74
				{
					vector3_0 = new Vector3(num6, num10, 0f - num8),
					int_0 = int_42
				});
			}
		}
	}

	private PwMapT2bkFile method_363(int int_40, int int_41, int int_42)
	{
		if (dictionary_6.TryGetValue(int_40, out var value))
		{
			return value;
		}
		if (hashSet_0.Contains(int_40))
		{
			return null;
		}
		string text = ((int_40 < 0 || int_40 >= pwMapTrn2File_0.MapSectors.Count) ? string.Empty : pwMapTrn2File_0.MapSectors[int_40]);
		if (string.IsNullOrWhiteSpace(text))
		{
			hashSet_0.Add(int_40);
			return null;
		}
		string text2 = System.IO.Path.Combine(pwMapTrn2File_0.MapRootPath, text + Class16.smethod_0(1649205731));
		if (!File.Exists(text2))
		{
			hashSet_0.Add(int_40);
			return null;
		}
		try
		{
			PwMapT2bkFile pwMapT2bkFile = PwMapT2bkFile.Load(text2, int_41, int_42, (int)pwMapTrn2File_0.BlockSize, (int)pwMapTrn2File_0.GridSize);
			if (pwMapT2bkFile != null)
			{
				dictionary_6[int_40] = pwMapT2bkFile;
				return pwMapT2bkFile;
			}
		}
		catch
		{
		}
		hashSet_0.Add(int_40);
		return null;
	}

	private float method_364(int int_40)
	{
		if (int_40 >= 0 && int_40 < pwMapTrn2File_0.SectorHeights.Count)
		{
			var (num, num2) = pwMapTrn2File_0.SectorHeights[int_40];
			return (num + num2) * 0.5f;
		}
		return 0f;
	}

	private void method_365()
	{
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		if (pwMapTrn2File_0 != null && !bool_4)
		{
			float num = 0f;
			float num2 = 0f;
			if (pwMapTrn2File_0.SectorHeights.Count > 0)
			{
				num = ((IEnumerable<(float, float)>)pwMapTrn2File_0.SectorHeights).Min((Func<(float, float), float>)Class317.class317_0.method_10);
				num2 = ((IEnumerable<(float, float)>)pwMapTrn2File_0.SectorHeights).Max((Func<(float, float), float>)Class317.class317_0.method_11);
			}
			bool_4 = true;
			vector3_0 = new Vector3((0f - pwMapTrn2File_0.Width) * 0.5f, num, (0f - pwMapTrn2File_0.Height) * 0.5f);
			vector3_1 = new Vector3(pwMapTrn2File_0.Width * 0.5f, num2, pwMapTrn2File_0.Height * 0.5f);
			method_34();
		}
	}

	private void method_366(Dictionary<string, List<Struct79>> dictionary_7)
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		if (device_0 == null || dictionary_7 == null || dictionary_7.Count == 0)
		{
			return;
		}
		foreach (KeyValuePair<string, List<Struct79>> item in dictionary_7)
		{
			Texture val = method_367(item.Key);
			List<Struct79> value = item.Value;
			if (val != null && value != null && value.Count > 2)
			{
				Class313 @class = new Class313
				{
					texture_0 = val,
					int_0 = value.Count,
					bool_0 = false,
					vertexBuffer_0 = new VertexBuffer(device_0, value.Count * Struct79.int_1, (Usage)8, (VertexFormat)0, (Pool)1)
				};
				DataStream val2 = @class.vertexBuffer_0.Lock(0, 0, (LockFlags)0);
				val2.WriteRange<Struct79>(value.ToArray());
				@class.vertexBuffer_0.Unlock();
				list_12.Add(@class);
			}
		}
	}

	private Texture method_367(string string_6)
	{
		if (method_306() && device_0 != null && !string.IsNullOrWhiteSpace(string_6))
		{
			if (dictionary_5.TryGetValue(string_6, out var value))
			{
				if (value != null && !((DisposeBase)value).IsDisposed)
				{
					return value;
				}
				dictionary_5.Remove(string_6);
			}
			try
			{
				Texture val = null;
				if (File.Exists(string_6))
				{
					val = Texture.FromFile(device_0, string_6);
				}
				else
				{
					byte[] array = PwMapAssetProvider.ReadPckBytes(string_6);
					if (array != null && array.Length != 0)
					{
						val = Texture.FromMemory(device_0, array);
					}
				}
				if (val == null)
				{
					return null;
				}
				dictionary_5[string_6] = val;
				return val;
			}
			catch
			{
				return null;
			}
		}
		return null;
	}

	private void method_368(bool bool_37)
	{
		for (int i = 0; i < list_12.Count; i++)
		{
			try
			{
				VertexBuffer obj = list_12[i].vertexBuffer_0;
				if (obj != null)
				{
					((DisposeBase)obj).Dispose();
				}
			}
			catch
			{
			}
		}
		list_12.Clear();
		if (!bool_37)
		{
			return;
		}
		foreach (Texture value in dictionary_5.Values)
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
		dictionary_5.Clear();
	}

	private void method_369(Vector3 vector3_5, bool bool_37)
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		if (pwMapTrn2File_0 == null)
		{
			return;
		}
		float num = ((float?)trackBar_10?.Value) ?? 10f;
		float num2 = (float)(trackBar_11?.Value ?? 40) / 100f;
		float float_ = num2 * 0.5f;
		int sectorsWide = pwMapTrn2File_0.SectorsWide;
		int sectorsHigh = pwMapTrn2File_0.SectorsHigh;
		float num3 = pwMapTrn2File_0.Width;
		float num4 = pwMapTrn2File_0.Height;
		float num5 = num3 / (float)sectorsWide;
		float num6 = num4 / (float)sectorsHigh;
		float num7 = (0f - num3) * 0.5f;
		float num8 = num4 * 0.5f;
		float num9 = vector3_5.X - num;
		float num10 = vector3_5.X + num;
		float num11 = 0f - vector3_5.Z - num;
		float num12 = 0f - vector3_5.Z + num;
		int num13 = Math.Max(0, (int)Math.Floor((num9 - num7) / num5));
		int num14 = Math.Min(sectorsWide - 1, (int)Math.Floor((num10 - num7) / num5));
		int num15 = Math.Max(0, (int)Math.Floor((num8 - num12) / num6));
		int num16 = Math.Min(sectorsHigh - 1, (int)Math.Floor((num8 - num11) / num6));
		bool flag = false;
		for (int i = num15; i <= num16; i++)
		{
			for (int j = num13; j <= num14; j++)
			{
				int num17 = i * sectorsWide + j;
				PwMapT2bkFile pwMapT2bkFile = method_363(num17, (int)num5, (int)num6);
				if (pwMapT2bkFile != null)
				{
					float float_2 = num7 + (float)j * num5 + num5 * 0.5f;
					float float_3 = num8 - (float)i * num6 - num6 * 0.5f;
					float[] oldHeights = pwMapT2bkFile.BuildSectorHeightMap();
					if (method_370(pwMapT2bkFile, vector3_5, num, float_, bool_37, float_2, float_3, num5, num6))
					{
						float[] newHeights = pwMapT2bkFile.BuildSectorHeightMap();
						pwMapChangeLog_0?.Push(new LandscapeChange(num17, oldHeights, newHeights, method_371));
						flag = true;
					}
				}
			}
		}
		if (flag)
		{
			method_353();
			if (bool_34)
			{
				method_359();
			}
		}
	}

	private bool method_370(PwMapT2bkFile pwMapT2bkFile_0, Vector3 vector3_5, float float_14, float float_15, bool bool_37, float float_16, float float_17, float float_18, float float_19)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		float num = vector3_5.X;
		float num2 = 0f - vector3_5.Z;
		List<float[]> subTerrains = pwMapT2bkFile_0.GetSubTerrains();
		int tileSize = pwMapT2bkFile_0.TileSize;
		int gridSpacing = pwMapT2bkFile_0.GridSpacing;
		int blocksWide = pwMapT2bkFile_0.BlocksWide;
		int num3 = tileSize / gridSpacing + 1;
		float num4 = float_18 * 0.5f;
		float num5 = float_19 * 0.5f;
		for (int i = 0; i < subTerrains.Count; i++)
		{
			float[] array = subTerrains[i];
			if (array == null || array.Length < 4)
			{
				continue;
			}
			int num6 = i / blocksWide;
			int num7 = i % blocksWide;
			for (int j = 0; j < num3; j++)
			{
				for (int k = 0; k < num3; k++)
				{
					int num8 = j * num3 + k;
					if (num8 >= array.Length)
					{
						continue;
					}
					float num9 = (float)(num7 * tileSize + k * gridSpacing) - num4;
					float num10 = num5 - (float)(num6 * tileSize + j * gridSpacing);
					float num11 = float_16 + num9;
					float num12 = float_17 + num10;
					float num13 = num11 - num;
					float num14 = num12 - num2;
					float num15 = (float)Math.Sqrt(num13 * num13 + num14 * num14);
					if (num15 > float_14)
					{
						continue;
					}
					float num16 = 1f - num15 / float_14;
					num16 *= num16;
					float num17 = float_15 * num16;
					if (radioButton_3 != null && radioButton_3.Checked)
					{
						array[num8] += (bool_37 ? (0f - num17) : num17);
						result = true;
					}
					else if (radioButton_4 != null && radioButton_4.Checked)
					{
						float num18 = array[num8];
						int num19 = 1;
						if (k > 0 && num8 - 1 < array.Length)
						{
							num18 += array[num8 - 1];
							num19++;
						}
						if (k < num3 - 1 && num8 + 1 < array.Length)
						{
							num18 += array[num8 + 1];
							num19++;
						}
						if (j > 0 && num8 - num3 >= 0)
						{
							num18 += array[num8 - num3];
							num19++;
						}
						if (j < num3 - 1 && num8 + num3 < array.Length)
						{
							num18 += array[num8 + num3];
							num19++;
						}
						num18 /= (float)num19;
						array[num8] += (num18 - array[num8]) * num16 * float_15;
						result = true;
					}
					else if (radioButton_5 != null && radioButton_5.Checked)
					{
						float num20 = method_235(num, num2);
						array[num8] += (num20 - array[num8]) * num16 * float_15;
						result = true;
					}
				}
			}
		}
		return result;
	}

	private void method_371(int int_40, float[] float_14)
	{
		if (pwMapTrn2File_0 != null)
		{
			int sectorsWide = pwMapTrn2File_0.SectorsWide;
			float num = pwMapTrn2File_0.Width / (float)sectorsWide;
			float num2 = pwMapTrn2File_0.Height / (float)pwMapTrn2File_0.SectorsHigh;
			PwMapT2bkFile pwMapT2bkFile = method_363(int_40, (int)num, (int)num2);
			if (pwMapT2bkFile != null)
			{
				pwMapT2bkFile.ApplySectorHeightMap(float_14);
				method_353();
			}
		}
	}

	private bool method_372(Vector3 vector3_5, Vector3 vector3_6, out Vector3 vector3_7)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		vector3_7 = Vector3.Zero;
		if (pwMapTrn2File_0 == null)
		{
			return false;
		}
		float num = Math.Min(10000f, method_194());
		float num2 = Math.Max(0.5f, pwMapTrn2File_0.GridSize * 0.5f);
		float num3 = 0f;
		bool flag = true;
		while (true)
		{
			if (num3 < num)
			{
				Vector3 val = vector3_5 + vector3_6 * num3;
				float num4 = method_235(val.X, 0f - val.Z);
				if (val.Y <= num4)
				{
					if (flag)
					{
						break;
					}
				}
				else
				{
					flag = true;
				}
				num3 += num2;
				continue;
			}
			return false;
		}
		float num5 = Math.Max(0f, num3 - num2);
		float num6 = num3;
		for (int i = 0; i < 12; i++)
		{
			float num7 = (num5 + num6) * 0.5f;
			Vector3 val2 = vector3_5 + vector3_6 * num7;
			float num8 = method_235(val2.X, 0f - val2.Z);
			if (val2.Y <= num8)
			{
				num6 = num7;
			}
			else
			{
				num5 = num7;
			}
		}
		vector3_7 = vector3_5 + vector3_6 * ((num5 + num6) * 0.5f);
		return true;
	}

	private void method_373(Point point_3, bool bool_37)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		if (method_318(point_3, out var vector3_, out var vector3_2) && method_372(vector3_, vector3_2, out var vector3_3))
		{
			vector3_4 = vector3_3;
			bool_36 = true;
			float float_ = ((float?)trackBar_10?.Value) ?? 10f;
			method_375(vector3_3, float_);
			UpdateTerrainCursorInfo(vector3_3.X, vector3_3.Y, 0f - vector3_3.Z);
			if (label_19 != null)
			{
				label_19.Text = method_235(vector3_3.X, 0f - vector3_3.Z).ToString(Class16.smethod_0(1648922976));
			}
			method_369(vector3_3, bool_37);
		}
	}

	private void method_374(Point point_3)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		if (!method_318(point_3, out var vector3_, out var vector3_2))
		{
			return;
		}
		if (!method_372(vector3_, vector3_2, out var vector3_3))
		{
			bool_36 = false;
			try
			{
				VertexBuffer obj = vertexBuffer_16;
				if (obj != null)
				{
					((DisposeBase)obj).Dispose();
				}
			}
			catch
			{
			}
			vertexBuffer_16 = null;
			int_39 = 0;
		}
		else
		{
			vector3_4 = vector3_3;
			bool_36 = true;
			float float_ = ((float?)trackBar_10?.Value) ?? 10f;
			method_375(vector3_3, float_);
			UpdateTerrainCursorInfo(vector3_3.X, vector3_3.Y, 0f - vector3_3.Z);
			if (label_19 != null)
			{
				label_19.Text = method_235(vector3_3.X, 0f - vector3_3.Z).ToString(Class16.smethod_0(1648922976));
			}
		}
	}

	private void method_375(Vector3 vector3_5, float float_14)
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected O, but got Unknown
		try
		{
			VertexBuffer obj = vertexBuffer_16;
			if (obj != null)
			{
				((DisposeBase)obj).Dispose();
			}
		}
		catch
		{
		}
		vertexBuffer_16 = null;
		int_39 = 0;
		if (device_0 != null)
		{
			int num = panel_14?.BackColor.ToArgb() ?? (-11737574);
			num |= -16777216;
			List<Struct74> list = new List<Struct74>(96);
			for (int i = 0; i < 48; i++)
			{
				double num2 = (double)i * 2.0 * Math.PI / 48.0;
				double num3 = (double)(i + 1) * 2.0 * Math.PI / 48.0;
				float num4 = vector3_5.X + float_14 * (float)Math.Cos(num2);
				float num5 = 0f - vector3_5.Z + float_14 * (float)Math.Sin(num2);
				float num6 = vector3_5.X + float_14 * (float)Math.Cos(num3);
				float num7 = 0f - vector3_5.Z + float_14 * (float)Math.Sin(num3);
				float num8 = method_235(num4, num5) + 0.4f;
				float num9 = method_235(num6, num7) + 0.4f;
				list.Add(new Struct74
				{
					vector3_0 = new Vector3(num4, num8, 0f - num5),
					int_0 = num
				});
				list.Add(new Struct74
				{
					vector3_0 = new Vector3(num6, num9, 0f - num7),
					int_0 = num
				});
			}
			if (list.Count >= 2)
			{
				int_39 = list.Count;
				vertexBuffer_16 = new VertexBuffer(device_0, int_39 * Struct74.int_1, (Usage)8, (VertexFormat)0, (Pool)1);
				DataStream val = vertexBuffer_16.Lock(0, 0, (LockFlags)0);
				val.WriteRange<Struct74>(list.ToArray());
				vertexBuffer_16.Unlock();
			}
		}
	}

	private void checkBox_6_CheckedChanged(object sender, EventArgs e)
	{
		method_321();
	}

	private void checkBox_7_CheckedChanged(object sender, EventArgs e)
	{
		if (panel_0 != null)
		{
			panel_0.Visible = checkBox_7.Checked;
		}
	}

	private void checkBox_8_CheckedChanged(object sender, EventArgs e)
	{
		label_31.Visible = checkBox_8.Checked;
	}

	private void checkBox_9_CheckedChanged(object sender, EventArgs e)
	{
		bool_27 = checkBox_9.Checked;
	}

	private void checkBox_11_CheckedChanged(object sender, EventArgs e)
	{
		bool_0 = checkBox_11.Checked;
	}

	private void checkBox_12_CheckedChanged(object sender, EventArgs e)
	{
		bool_28 = checkBox_12.Checked;
	}

	private void checkBox_53_CheckedChanged(object sender, EventArgs e)
	{
		bool_34 = checkBox_53.Checked;
		if (bool_34 && vertexBuffer_14 == null)
		{
			method_359();
		}
	}

	private void checkBox_13_CheckedChanged(object sender, EventArgs e)
	{
		bool_1 = checkBox_13.Checked;
	}

	private void checkBox_14_CheckedChanged(object sender, EventArgs e)
	{
		bool_2 = checkBox_14.Checked;
	}

	private void trackBar_3_ValueChanged(object sender, EventArgs e)
	{
		float_0 = (float)trackBar_3.Value * (float)Math.PI / 180f;
		label_0.Text = trackBar_3.Value + Class16.smethod_0(1649204346);
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		bool_7 = checkBox_0.Checked;
		method_353();
	}

	private void checkBox_1_CheckedChanged(object sender, EventArgs e)
	{
		bool_8 = checkBox_1.Checked;
	}

	private void checkBox_3_CheckedChanged(object sender, EventArgs e)
	{
		if (!bool_6)
		{
			if (!base.IsHandleCreated)
			{
				method_261();
				return;
			}
			checkBox_3.Enabled = false;
			Cursor = Cursors.WaitCursor;
			method_120(Class16.smethod_0(1649204354), null);
			BeginInvoke(new Action(method_376));
		}
	}

	private void method_376()
	{
		try
		{
			method_261();
		}
		finally
		{
			checkBox_3.Enabled = true;
			Cursor = Cursors.Default;
			method_120(Class16.smethod_0(1649204412), null);
		}
	}

	private void trackBar_16_ValueChanged(object sender, EventArgs e)
	{
		pwMapPreferencesStore_0.RenderOptions.RenderBlockDistance = trackBar_16.Value;
		method_261();
	}

	private void radioButton_6_CheckedChanged(object sender, EventArgs e)
	{
		if (!bool_6)
		{
			method_353();
		}
	}

	private void radioButton_7_CheckedChanged(object sender, EventArgs e)
	{
		if (!bool_6)
		{
			method_353();
		}
	}

	private void panel_21_Resize_1(object sender, EventArgs e)
	{
		method_8();
	}

	private void label_3_Click(object sender, EventArgs e)
	{
		string text = label_3.Text.Replace(Class16.smethod_0(1649086459), string.Empty);
		if (!string.IsNullOrEmpty(text) && text != Class16.smethod_0(1648966655))
		{
			Clipboard.SetText(text);
		}
	}

	private void trackBar_4_ValueChanged(object sender, EventArgs e)
	{
		label_4.Text = trackBar_4.Value.ToString();
	}

	private void method_377(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			button_0_Click(button_0, EventArgs.Empty);
			e.SuppressKeyPress = true;
		}
	}

	private void label_5_Click(object sender, EventArgs e)
	{
		string text = label_5.Text.Replace(Class16.smethod_0(1649086459), string.Empty);
		if (!string.IsNullOrEmpty(text) && text != Class16.smethod_0(1648966655))
		{
			Clipboard.SetText(text);
		}
	}

	private void trackBar_5_ValueChanged(object sender, EventArgs e)
	{
		label_6.Text = trackBar_5.Value.ToString();
	}

	private void method_378(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			button_1_Click(button_1, EventArgs.Empty);
			e.SuppressKeyPress = true;
		}
	}

	private void trackBar_6_ValueChanged(object sender, EventArgs e)
	{
		label_7.Text = trackBar_6.Value.ToString();
	}

	private void trackBar_7_ValueChanged(object sender, EventArgs e)
	{
		label_8.Text = trackBar_7.Value + Class16.smethod_0(1648923229);
	}

	private void panel_4_Click(object sender, EventArgs e)
	{
		using ColorDialog colorDialog = new ColorDialog
		{
			Color = panel_4.BackColor
		};
		if (colorDialog.ShowDialog(this) == DialogResult.OK)
		{
			panel_4.BackColor = colorDialog.Color;
		}
	}

	private void textBox_21_TextChanged(object sender, EventArgs e)
	{
		panel_5?.Invalidate();
	}

	private void method_379(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			button_4_Click(button_4, EventArgs.Empty);
			e.SuppressKeyPress = true;
		}
	}

	private void textBox_22_TextChanged(object sender, EventArgs e)
	{
		panel_5?.Invalidate();
	}

	private void textBox_23_TextChanged(object sender, EventArgs e)
	{
		panel_5?.Invalidate();
	}

	private void textBox_24_TextChanged(object sender, EventArgs e)
	{
		panel_5?.Invalidate();
	}

	private void label_9_Click(object sender, EventArgs e)
	{
		string text = label_9.Text.Replace(Class16.smethod_0(1649086459), string.Empty);
		if (!string.IsNullOrEmpty(text) && text != Class16.smethod_0(1648966655))
		{
			Clipboard.SetText(text);
		}
	}

	private void trackBar_8_ValueChanged(object sender, EventArgs e)
	{
		label_10.Text = trackBar_8.Value.ToString();
	}

	private void method_380(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			button_11_Click(button_11, EventArgs.Empty);
			e.SuppressKeyPress = true;
		}
	}

	private void button_9_Click(object sender, EventArgs e)
	{
		foreach (ListViewItem item in listView_2.Items)
		{
			item.Checked = true;
		}
	}

	private void button_10_Click(object sender, EventArgs e)
	{
		foreach (ListViewItem item in listView_2.Items)
		{
			item.Checked = false;
		}
	}

	private void toolStripMenuItem_3_Click(object sender, EventArgs e)
	{
		method_132();
	}

	private void toolStripMenuItem_4_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void toolStripMenuItem_16_Click(object sender, EventArgs e)
	{
		method_43();
	}

	private void toolStripMenuItem_17_Click(object sender, EventArgs e)
	{
		method_44();
	}

	private void toolStripMenuItem_19_Click(object sender, EventArgs e)
	{
		toolStripButton_15_Click(sender, e);
	}

	private void toolStripMenuItem_20_Click(object sender, EventArgs e)
	{
		toolStripButton_16_Click(sender, e);
	}

	private void toolStripMenuItem_21_Click(object sender, EventArgs e)
	{
		method_184();
	}

	private void toolStripMenuItem_23_Click(object sender, EventArgs e)
	{
		method_349();
	}

	private void toolStripMenuItem_26_Click(object sender, EventArgs e)
	{
		toolStripButton_0_Click(sender, e);
	}

	private void toolStripMenuItem_25_Click(object sender, EventArgs e)
	{
		method_42();
	}

	private void toolStripMenuItem_11_CheckedChanged(object sender, EventArgs e)
	{
		method_311(sender, e);
	}

	private void toolStripMenuItem_13_CheckedChanged(object sender, EventArgs e)
	{
		if (toolStripMenuItem_13.Checked != bool_24)
		{
			method_231();
		}
	}

	private void toolStripMenuItem_14_Click(object sender, EventArgs e)
	{
		PwMapShortcutHelpDialog pwMapShortcutHelpDialog = new PwMapShortcutHelpDialog();
		try
		{
			pwMapShortcutHelpDialog.ShowDialog(this);
		}
		finally
		{
			((IDisposable)pwMapShortcutHelpDialog).Dispose();
		}
	}

	private void toolStripButton_14_Click(object sender, EventArgs e)
	{
		method_132();
	}

	private void button_45_Click(object sender, EventArgs e)
	{
		method_132();
	}

	private void button_46_Click(object sender, EventArgs e)
	{
		method_48();
	}

	private void trackBar_9_ValueChanged(object sender, EventArgs e)
	{
		label_11.Text = trackBar_9.Value + Class16.smethod_0(1649204346);
	}

	private void button_16_Click(object sender, EventArgs e)
	{
		method_60();
	}

	private void button_17_Click(object sender, EventArgs e)
	{
		method_61();
	}

	private void button_18_Click(object sender, EventArgs e)
	{
		method_62();
	}

	private void button_14_Click(object sender, EventArgs e)
	{
		method_185();
	}

	private void button_15_Click(object sender, EventArgs e)
	{
		method_186();
	}

	private void button_13_Click(object sender, EventArgs e)
	{
		method_63();
	}

	private void listView_5_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_66();
	}

	private void listView_7_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_68();
	}

	private void listView_9_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_70();
	}

	private void checkBox_24_CheckedChanged(object sender, EventArgs e)
	{
		method_261();
	}

	private void checkBox_26_CheckedChanged(object sender, EventArgs e)
	{
		method_321();
	}

	private void checkBox_27_CheckedChanged(object sender, EventArgs e)
	{
		method_321();
	}

	private void method_381(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			button_31_Click(button_31, EventArgs.Empty);
			e.SuppressKeyPress = true;
		}
	}

	private void method_382(object sender, EventArgs e)
	{
		if (!bool_5 && class301_1 != null)
		{
			button_31.Enabled = true;
		}
	}

	private void method_383(object sender, EventArgs e)
	{
		toolStripDropDownButton_0.Text = TextStorage.Msg(Class16.smethod_0(1649204417), Class16.smethod_0(1649089857));
	}

	private void method_384(object sender, EventArgs e)
	{
		toolStripDropDownButton_0.Text = TextStorage.Msg(Class16.smethod_0(1649210046), Class16.smethod_0(1649089857));
	}

	private void trackBar_10_ValueChanged(object sender, EventArgs e)
	{
		label_15.Text = trackBar_10.Value.ToString(Class16.smethod_0(1648979502));
	}

	private void trackBar_11_ValueChanged(object sender, EventArgs e)
	{
		label_16.Text = trackBar_11.Value + Class16.smethod_0(1648923229);
	}

	private void trackBar_12_ValueChanged(object sender, EventArgs e)
	{
		label_17.Text = ((float)trackBar_12.Value / 100f).ToString(Class16.smethod_0(1648922976));
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		method_97(Class16.smethod_0(1649113514));
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		method_97(Class16.smethod_0(1649213054));
	}

	private void toolStripButton_3_Click(object sender, EventArgs e)
	{
		method_97(Class16.smethod_0(1649085669));
	}

	private void toolStripButton_5_CheckedChanged(object sender, EventArgs e)
	{
		if (toolStripButton_5.Checked != bool_24)
		{
			method_231();
		}
	}

	private void toolStripButton_6_Click(object sender, EventArgs e)
	{
		method_184();
	}

	private void label_21_Click(object sender, EventArgs e)
	{
		string text = label_21.Text.Replace(Class16.smethod_0(1649086459), string.Empty);
		if (!string.IsNullOrEmpty(text) && text != Class16.smethod_0(1648966655))
		{
			Clipboard.SetText(text);
		}
	}

	private void method_385(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			button_35_Click(button_35, EventArgs.Empty);
			e.SuppressKeyPress = true;
		}
	}

	private void toolStripButton_24_Click(object sender, EventArgs e)
	{
		method_117(Class16.smethod_0(1649211364));
	}

	private void toolStripButton_25_Click(object sender, EventArgs e)
	{
		method_117(Class16.smethod_0(1649209693));
	}

	private void toolStripButton_26_Click(object sender, EventArgs e)
	{
		method_117(Class16.smethod_0(1649084711));
	}

	private void toolStripButton_27_Click(object sender, EventArgs e)
	{
		method_117(Class16.smethod_0(1649212626));
	}

	private void toolStripButton_28_Click(object sender, EventArgs e)
	{
		method_117(Class16.smethod_0(1648977873));
	}

	private void toolStripButton_29_Click(object sender, EventArgs e)
	{
		method_117(Class16.smethod_0(1648976466));
	}

	private void toolStripButton_30_Click(object sender, EventArgs e)
	{
		method_117(Class16.smethod_0(1649210934));
	}

	private void panel_21_Leave(object sender, EventArgs e)
	{
		method_228();
	}

	private void PwMapSharpDxEditorForm_Deactivate(object sender, EventArgs e)
	{
		method_228();
	}

	private void panel_23_Resize(object sender, EventArgs e)
	{
		method_177();
	}

	private void method_386(object sender, EventArgs e)
	{
		method_135();
	}

	private void method_387(object sender, EventArgs e)
	{
		method_136();
	}

	private void method_388(object sender, EventArgs e)
	{
		method_137();
	}

	private void method_389(object sender, EventArgs e)
	{
		method_138();
	}

	private void method_390(object sender, EventArgs e)
	{
		method_349();
	}

	private void method_391(object sender, EventArgs e)
	{
		method_184();
	}

	private void method_392(object sender, EventArgs e)
	{
		method_205(class301_1);
	}

	private void method_393(object sender, EventArgs e)
	{
		smethod_22(class301_1.string_0);
	}

	private void method_394(object sender, EventArgs e)
	{
		smethod_22(class301_1.string_1);
	}

	private void method_395(object sender, EventArgs e)
	{
		smethod_23(class301_1.string_1);
	}

	private void method_396(object sender, EventArgs e)
	{
		method_261();
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		timer_0.Stop();
		method_215();
	}

	private void comboBox_10_SelectedIndexChanged(object sender, EventArgs e)
	{
		int_34 = comboBox_10.SelectedIndex;
		method_280();
	}

	private void trackBar_17_ValueChanged(object sender, EventArgs e)
	{
		float_10 = (float)trackBar_17.Value / 100f;
		label_35.Text = float_10.ToString(Class16.smethod_0(1648922976));
	}

	private void trackBar_18_ValueChanged(object sender, EventArgs e)
	{
		float_11 = (float)trackBar_18.Value / 100f;
		label_36.Text = float_11.ToString(Class16.smethod_0(1648922976));
	}

	private void trackBar_19_ValueChanged(object sender, EventArgs e)
	{
		float_12 = (float)trackBar_19.Value / 100f;
		label_37.Text = float_12.ToString(Class16.smethod_0(1648922976));
	}

	private void trackBar_20_ValueChanged(object sender, EventArgs e)
	{
		float_13 = (float)trackBar_20.Value / 100f;
		label_38.Text = float_13.ToString(Class16.smethod_0(1648922976));
	}
}
