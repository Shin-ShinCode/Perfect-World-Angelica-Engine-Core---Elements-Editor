using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACE.Classes;
using SharpDX;
// TODO(recovered): disambiguation aliases (decompiled file mixes SharpDX + System.Drawing).
using Color = System.Drawing.Color;
using Point = System.Drawing.Point;

namespace ACE.PWMap;

public sealed class PwMapAddObjectDialog : Form
{
	[StructLayout(LayoutKind.Auto)]
	private struct Struct70 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		public PwMapAddObjectDialog pwMapAddObjectDialog_0;

		private bool bool_0;

		private TaskAwaiter<(List<string>, List<(string, List<string>)>)> taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PwMapAddObjectDialog pwMapAddObjectDialog = pwMapAddObjectDialog_0;
			try
			{
				if (num == 0)
				{
					goto IL_0066;
				}
				if (!pwMapAddObjectDialog.bool_0)
				{
					pwMapAddObjectDialog.bool_0 = true;
					pwMapAddObjectDialog.label_0.Text = TextStorage.Msg(Class16.smethod_0(1649091018), Class16.smethod_0(1649091051));
					pwMapAddObjectDialog.treeView_0.Nodes.Clear();
					pwMapAddObjectDialog.button_0.Enabled = false;
					goto IL_0066;
				}
				goto end_IL_000e;
				IL_0066:
				try
				{
					List<string> list;
					List<(string, List<string>)> list2;
					TaskAwaiter<(List<string>, List<(string, List<string>)>)> awaiter;
					if (num != 0)
					{
						object object_ = object_0;
						bool lockTaken = false;
						try
						{
							Monitor.Enter(object_, ref lockTaken);
							bool_0 = list_1 != null && list_2 != null;
							list = (bool_0 ? list_1 : null);
							list2 = (bool_0 ? list_2 : null);
						}
						finally
						{
							if (num < 0 && lockTaken)
							{
								Monitor.Exit(object_);
							}
						}
						if (bool_0)
						{
							goto IL_0199;
						}
						awaiter = Task.Run((Func<(List<string>, List<(string, List<string>)>)>)Class293.class293_0.method_1).GetAwaiter();
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
						taskAwaiter_0 = default(TaskAwaiter<(List<string>, List<(string, List<string>)>)>);
						num = -1;
						int_0 = -1;
					}
					(List<string>, List<(string, List<string>)>) result = awaiter.GetResult();
					(List<string>, List<(string, List<string>)>) tuple = result;
					list = tuple.Item1;
					list2 = tuple.Item2;
					object object_2 = object_0;
					bool lockTaken2 = false;
					try
					{
						Monitor.Enter(object_2, ref lockTaken2);
						list_1 = list;
						list_2 = list2;
					}
					finally
					{
						if (num < 0 && lockTaken2)
						{
							Monitor.Exit(object_2);
						}
					}
					goto IL_0199;
					IL_0199:
					if (!pwMapAddObjectDialog.IsDisposed)
					{
						pwMapAddObjectDialog.list_0 = list;
						pwMapAddObjectDialog.treeView_0.BeginUpdate();
						try
						{
							List<(string, List<string>)>.Enumerator enumerator = list2.GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									var (string_, list_) = enumerator.Current;
									pwMapAddObjectDialog.method_14(string_, list_);
								}
							}
							finally
							{
								if (num < 0)
								{
									((IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
								}
							}
							if (pwMapAddObjectDialog.treeView_0.Nodes.Count == 0)
							{
								pwMapAddObjectDialog.treeView_0.Nodes.Add(Class16.smethod_0(1649094153));
							}
						}
						finally
						{
							if (num < 0)
							{
								pwMapAddObjectDialog.treeView_0.EndUpdate();
							}
						}
						pwMapAddObjectDialog.label_0.Text = (bool_0 ? string.Format(Class16.smethod_0(1649094218), pwMapAddObjectDialog.list_0.Count) : string.Format(Class16.smethod_0(1649094184), pwMapAddObjectDialog.list_0.Count));
					}
				}
				catch (Exception ex)
				{
					SentryHelper.CaptureException(ex, Class16.smethod_0(1649094243));
					if (!pwMapAddObjectDialog.IsDisposed)
					{
						pwMapAddObjectDialog.label_0.Text = TextStorage.Msg(Class16.smethod_0(1649094307), Class16.smethod_0(1648935998)) + ex.Message;
					}
				}
				finally
				{
					if (num < 0)
					{
						pwMapAddObjectDialog.bool_0 = false;
						if (!pwMapAddObjectDialog.IsDisposed)
						{
							pwMapAddObjectDialog.button_0.Enabled = true;
						}
					}
				}
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

	[Serializable]
	private sealed class Class293
	{
		public static readonly Class293 class293_0 = new Class293();

		public static Func<PwMapBmdSceneFile.Mesh, int> func_0;

		public static Func<(List<string>, List<(string, List<string>)>)> func_1;

		internal int method_0(PwMapBmdSceneFile.Mesh mesh_0)
		{
			return mesh_0.Vertices.Length;
		}

		internal (List<string>, List<(string, List<string>)>) method_1()
		{
			return smethod_5();
		}
	}

	private TreeView treeView_0;

	private TextBox textBox_0;

	private ListView listView_0;

	private Panel panel_0;

	private Button button_0;

	private Button button_1;

	private Button button_2;

	private Label label_0;

	private Label label_1;

	private Label label_2;

	private Label label_3;

	private bool bool_0;

	private string string_0;

	private List<string> list_0;

	private static List<string> list_1;

	private static List<(string, List<string>)> list_2;

	private static readonly object object_0 = new object();

	private PwMapBmdSceneFile pwMapBmdSceneFile_0;

	private float float_0;

	private float float_1 = -0.35f;

	private Point point_0;

	private bool bool_1;

	public string SelectedResource
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
	}

	public PwMapAddObjectDialog()
	{
		Text = Class16.smethod_0(1649094333);
		base.Size = new Size(920, 680);
		base.StartPosition = FormStartPosition.CenterParent;
		base.MinimizeBox = false;
		base.MaximizeBox = true;
		base.ShowInTaskbar = false;
		base.KeyPreview = true;
		method_5();
		method_1();
		TextStorage.TEXTS.SetFormLanguage(this, null);
	}

	private void method_0(string string_1)
	{
		string_0 = string_1;
	}

	public static void InvalidateCache()
	{
		lock (object_0)
		{
			list_1 = null;
			list_2 = null;
		}
	}

	public static void EnsureCacheLoaded()
	{
		lock (object_0)
		{
			if (list_1 != null && list_2 != null)
			{
				return;
			}
		}
		(List<string>, List<(string, List<string>)>) tuple = smethod_5();
		lock (object_0)
		{
			(list_1, list_2) = tuple;
		}
	}

	private void method_1()
	{
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		if (base.IsHandleCreated)
		{
			TDark.ApplyImmersiveDarkMode(base.Handle, TDark.IsDarkMode);
		}
		TDark.ApplyNativeDarkThemeRecursive(this);
	}

	protected override void OnShown(EventArgs eventArgs_0)
	{
		base.OnShown(eventArgs_0);
		method_6();
		if (treeView_0.Nodes.Count > 0 && !bool_0)
		{
			button_0.Enabled = true;
			label_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649094350), Class16.smethod_0(1649094218)), list_0?.Count ?? 0);
		}
		else
		{
			method_13();
		}
	}

	private string method_2()
	{
		if (string.IsNullOrEmpty(SelectedResource))
		{
			return null;
		}
		return System.IO.Path.GetExtension(SelectedResource)?.ToLowerInvariant();
	}

	private static Color smethod_0(string string_1)
	{
		if (!(string_1 == Class16.smethod_0(1649142694)))
		{
			if (!(string_1 == Class16.smethod_0(1649094375)))
			{
				if (!(string_1 == Class16.smethod_0(1648906325)))
				{
					if (!(string_1 == Class16.smethod_0(1649119451)))
					{
						return Color.FromArgb(180, 180, 180);
					}
					return Color.FromArgb(255, 120, 80);
				}
				return Color.FromArgb(220, 180, 80);
			}
			return Color.FromArgb(100, 220, 100);
		}
		return Color.FromArgb(100, 180, 255);
	}

	private static string smethod_1(string string_1)
	{
		if (!(string_1 == Class16.smethod_0(1649142694)))
		{
			if (!(string_1 == Class16.smethod_0(1649094375)))
			{
				if (!(string_1 == Class16.smethod_0(1648906325)))
				{
					if (!(string_1 == Class16.smethod_0(1649119451)))
					{
						return Class16.smethod_0(1648936686);
					}
					return Class16.smethod_0(1649094449);
				}
				return Class16.smethod_0(1649094437);
			}
			return Class16.smethod_0(1649094407);
		}
		return Class16.smethod_0(1649094378);
	}

	private void treeView_0_AfterSelect(object sender, TreeViewEventArgs e)
	{
		if (e.Node?.Tag is string string_)
		{
			method_0(string_);
			method_3(string_);
		}
		else
		{
			method_0(null);
			method_4();
		}
	}

	private void method_3(string string_1)
	{
		string extension = System.IO.Path.GetExtension(string_1);
		object obj;
		if (extension == null)
		{
			obj = null;
		}
		else
		{
			obj = extension.ToLowerInvariant();
			if (obj != null)
			{
				goto IL_001b;
			}
		}
		obj = string.Empty;
		goto IL_001b;
		IL_001b:
		string string_2 = (string)obj;
		label_1.Text = smethod_1(string_2);
		label_1.ForeColor = smethod_0(string_2);
		label_2.Text = string_1;
		long num = smethod_2(string_1);
		label_3.Text = ((num > 0L) ? string.Format(Class16.smethod_0(1649094503), (double)num / 1024.0) : Class16.smethod_0(1649094466));
		method_7(string_1);
		if (pwMapBmdSceneFile_0 != null && pwMapBmdSceneFile_0.IsSharedData)
		{
			label_1.Text = smethod_1(string_2) + Class16.smethod_0(1649094525);
			label_3.Text += string.Format(Class16.smethod_0(1649094538), pwMapBmdSceneFile_0.Meshes.Count);
		}
		else if (pwMapBmdSceneFile_0 != null)
		{
			label_3.Text += string.Format(Class16.smethod_0(1649094561), pwMapBmdSceneFile_0.Meshes.Count, ((IEnumerable<PwMapBmdSceneFile.Mesh>)pwMapBmdSceneFile_0.Meshes).Sum((Func<PwMapBmdSceneFile.Mesh, int>)Class293.class293_0.method_0));
		}
	}

	private void method_4()
	{
		label_1.Text = string.Empty;
		label_2.Text = TextStorage.Msg(Class16.smethod_0(1649094604), Class16.smethod_0(1649094631));
		label_3.Text = string.Empty;
		pwMapBmdSceneFile_0 = null;
		panel_0.Invalidate();
	}

	private static long smethod_2(string string_1)
	{
		try
		{
			byte[] array = PwMapAssetProvider.ReadFileOrPckBytes(string_1);
			return (array != null) ? array.Length : 0;
		}
		catch
		{
			return 0L;
		}
	}

	private void treeView_0_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
	{
		if (e.Node?.Tag is string)
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(SelectedResource))
		{
			return;
		}
		foreach (ListViewItem item in listView_0.Items)
		{
			if (item.Text == SelectedResource)
			{
				return;
			}
		}
		listView_0.Items.Add(SelectedResource);
	}

	private void listView_0_DoubleClick(object sender, EventArgs e)
	{
		if (listView_0.SelectedItems.Count != 0)
		{
			method_0(listView_0.SelectedItems[0].Text);
			method_3(SelectedResource);
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	private void method_5()
	{
		SplitContainer splitContainer = new SplitContainer
		{
			Dock = DockStyle.Fill,
			Orientation = Orientation.Vertical,
			SplitterDistance = 500,
			BackColor = Color.FromArgb(30, 30, 35)
		};
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 2,
			RowCount = 3
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		textBox_0 = new TextBox
		{
			Dock = DockStyle.Fill,
			Text = Class16.smethod_0(1649094654),
			ForeColor = Color.Gray
		};
		textBox_0.Enter += textBox_0_Enter;
		textBox_0.Leave += textBox_0_Leave;
		textBox_0.TextChanged += textBox_0_TextChanged;
		tableLayoutPanel.Controls.Add(textBox_0, 0, 0);
		button_2 = new Button
		{
			Text = Class16.smethod_0(1649093646),
			Dock = DockStyle.Fill
		};
		button_2.Click += button_2_Click;
		tableLayoutPanel.Controls.Add(button_2, 1, 0);
		treeView_0 = new TreeView
		{
			Dock = DockStyle.Fill,
			HideSelection = false,
			ShowLines = true,
			ShowRootLines = true,
			ShowNodeToolTips = true,
			PathSeparator = Class16.smethod_0(1648927580),
			Font = new Font(Class16.smethod_0(1648942905), 9f)
		};
		treeView_0.AfterSelect += treeView_0_AfterSelect;
		treeView_0.NodeMouseDoubleClick += treeView_0_NodeMouseDoubleClick;
		tableLayoutPanel.SetColumnSpan(treeView_0, 2);
		tableLayoutPanel.Controls.Add(treeView_0, 0, 1);
		label_0 = new Label
		{
			Dock = DockStyle.Fill,
			AutoEllipsis = true,
			Text = Class16.smethod_0(1649093663),
			ForeColor = Color.FromArgb(160, 160, 160),
			Font = new Font(Class16.smethod_0(1648942905), 7.5f)
		};
		tableLayoutPanel.SetColumnSpan(label_0, 2);
		tableLayoutPanel.Controls.Add(label_0, 0, 2);
		splitContainer.Panel1.Controls.Add(tableLayoutPanel);
		TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 1,
			RowCount = 4
		};
		tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 60f));
		tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 100f));
		tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 40f));
		tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 36f));
		panel_0 = new Panel
		{
			Dock = DockStyle.Fill,
			BorderStyle = BorderStyle.FixedSingle,
			BackColor = Color.FromArgb(25, 25, 30)
		};
		tableLayoutPanel2.Controls.Add(panel_0, 0, 0);
		Panel panel = new Panel
		{
			Dock = DockStyle.Fill,
			BackColor = Color.FromArgb(35, 35, 40)
		};
		label_1 = new Label
		{
			AutoSize = false,
			Dock = DockStyle.Top,
			Height = 22,
			Text = string.Empty,
			ForeColor = Color.FromArgb(100, 200, 255),
			Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold),
			Padding = new Padding(4, 2, 0, 0)
		};
		label_2 = new Label
		{
			AutoSize = false,
			Dock = DockStyle.Top,
			Height = 40,
			Text = Class16.smethod_0(1649094631),
			ForeColor = Color.FromArgb(200, 200, 200),
			Cursor = Cursors.Hand,
			Padding = new Padding(4, 2, 0, 0),
			Font = new Font(Class16.smethod_0(1648942905), 8f)
		};
		label_2.Click += label_2_Click;
		label_3 = new Label
		{
			AutoSize = false,
			Dock = DockStyle.Top,
			Height = 20,
			Text = string.Empty,
			ForeColor = Color.FromArgb(160, 160, 160),
			Font = new Font(Class16.smethod_0(1648942905), 7.5f),
			Padding = new Padding(4, 2, 0, 0)
		};
		panel.Controls.Add(label_3);
		panel.Controls.Add(label_2);
		panel.Controls.Add(label_1);
		tableLayoutPanel2.Controls.Add(panel, 0, 1);
		listView_0 = new ListView
		{
			Dock = DockStyle.Fill,
			View = View.List,
			FullRowSelect = true,
			HideSelection = false
		};
		listView_0.DoubleClick += listView_0_DoubleClick;
		tableLayoutPanel2.Controls.Add(listView_0, 0, 2);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			Dock = DockStyle.Fill,
			FlowDirection = FlowDirection.RightToLeft,
			WrapContents = false
		};
		button_1 = new Button
		{
			Text = Class16.smethod_0(1648941799),
			DialogResult = DialogResult.Cancel,
			Width = 80
		};
		button_0 = new Button
		{
			Text = Class16.smethod_0(1648931361),
			DialogResult = DialogResult.OK,
			Width = 80
		};
		flowLayoutPanel.Controls.Add(button_1);
		flowLayoutPanel.Controls.Add(button_0);
		tableLayoutPanel2.Controls.Add(flowLayoutPanel, 0, 3);
		splitContainer.Panel2.Controls.Add(tableLayoutPanel2);
		base.AcceptButton = button_0;
		base.CancelButton = button_1;
		base.Controls.Add(splitContainer);
	}

	private void method_6()
	{
		panel_0.Paint += panel_0_Paint;
		panel_0.MouseDown += panel_0_MouseDown;
		panel_0.MouseMove += panel_0_MouseMove;
		panel_0.MouseUp += panel_0_MouseUp;
		panel_0.MouseWheel += panel_0_MouseWheel;
		panel_0.DoubleBuffered();
	}

	private void method_7(string string_1)
	{
		pwMapBmdSceneFile_0 = null;
		string extension = System.IO.Path.GetExtension(string_1);
		object obj;
		if (extension == null)
		{
			obj = null;
		}
		else
		{
			obj = extension.ToLowerInvariant();
			if (obj != null)
			{
				goto IL_0022;
			}
		}
		obj = string.Empty;
		goto IL_0022;
		IL_0022:
		string text = (string)obj;
		if (text == Class16.smethod_0(1649142694) || text == Class16.smethod_0(1648906325))
		{
			try
			{
				pwMapBmdSceneFile_0 = PwMapBmdSceneFile.Load(string_1);
			}
			catch
			{
			}
		}
		float_0 = 0.7f;
		float_1 = -0.35f;
		panel_0.Invalidate();
	}

	private void panel_0_Paint(object sender, PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		int int_ = panel_0.ClientSize.Width;
		int int_2 = panel_0.ClientSize.Height;
		graphics.SmoothingMode = SmoothingMode.AntiAlias;
		if (pwMapBmdSceneFile_0 != null && pwMapBmdSceneFile_0.Meshes.Count > 0 && pwMapBmdSceneFile_0.HasBounds)
		{
			method_10(graphics, int_, int_2);
		}
		else if (pwMapBmdSceneFile_0 != null && pwMapBmdSceneFile_0.IsSharedData)
		{
			method_8(graphics, int_, int_2);
		}
		else
		{
			method_9(graphics, int_, int_2);
		}
	}

	private void method_8(Graphics graphics_0, int int_0, int int_1)
	{
		Color color = Color.FromArgb(100, 180, 255);
		smethod_3(graphics_0, Class16.smethod_0(1649142694), int_0, int_1, color);
		Font font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold);
		try
		{
			Font font2 = new Font(Class16.smethod_0(1648942905), 8f);
			try
			{
				SolidBrush solidBrush = new SolidBrush(color);
				try
				{
					SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(140, 140, 140));
					try
					{
						StringFormat format = new StringFormat
						{
							Alignment = StringAlignment.Center
						};
						graphics_0.DrawString(Class16.smethod_0(1649093672), font, solidBrush, (float)int_0 / 2f, int_1 - 48, format);
						graphics_0.DrawString(Class16.smethod_0(1649093696), font2, solidBrush2, (float)int_0 / 2f, int_1 - 28, format);
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
			finally
			{
				((IDisposable)font2).Dispose();
			}
		}
		finally
		{
			((IDisposable)font).Dispose();
		}
	}

	private void method_9(Graphics graphics_0, int int_0, int int_1)
	{
		string text = method_2();
		if (string.IsNullOrEmpty(text))
		{
			Font font = new Font(Class16.smethod_0(1648942905), 10f);
			try
			{
				SolidBrush solidBrush = new SolidBrush(Color.FromArgb(80, 80, 80));
				try
				{
					graphics_0.DrawString(Class16.smethod_0(1649093731), font, solidBrush, (float)int_0 / 2f - 80f, (float)int_1 / 2f - 8f);
					return;
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
		Color color = smethod_0(text);
		smethod_3(graphics_0, text, int_0, int_1, color);
		string s = text.TrimStart('.').ToUpperInvariant();
		Font font2 = new Font(Class16.smethod_0(1648942905), 11f, FontStyle.Bold);
		try
		{
			SolidBrush solidBrush2 = new SolidBrush(color);
			try
			{
				StringFormat format = new StringFormat
				{
					Alignment = StringAlignment.Center
				};
				graphics_0.DrawString(s, font2, solidBrush2, (float)int_0 / 2f, int_1 - 30, format);
			}
			finally
			{
				((IDisposable)solidBrush2).Dispose();
			}
		}
		finally
		{
			((IDisposable)font2).Dispose();
		}
	}

	private static void smethod_3(Graphics graphics_0, string string_1, int int_0, int int_1, Color color_0)
	{
		Pen pen = new Pen(Color.FromArgb(180, color_0), 2f);
		try
		{
			int num = int_0 / 2;
			int num2 = int_1 / 2 - 10;
			int num3 = Math.Min(int_0, int_1) / 4;
			if (!(string_1 == Class16.smethod_0(1649142694)) && !(string_1 == Class16.smethod_0(1648906325)))
			{
				if (string_1 == Class16.smethod_0(1649094375))
				{
					graphics_0.DrawLine(pen, num, num2 + num3, num, num2 - num3 + 4);
					graphics_0.DrawEllipse(pen, num - num3 + 4, num2 - num3, (num3 - 4) * 2, num3 + 4);
				}
				else if (string_1 == Class16.smethod_0(1649119451))
				{
					for (int i = 0; i < 8; i++)
					{
						double num4 = (double)i * Math.PI / 4.0;
						int x = num + (int)((double)num3 * 0.9 * Math.Cos(num4));
						int y = num2 + (int)((double)num3 * 0.9 * Math.Sin(num4));
						graphics_0.DrawLine(pen, num, num2, x, y);
					}
					graphics_0.DrawEllipse(pen, num - 6, num2 - 6, 12, 12);
				}
			}
			else
			{
				Point[] points = new Point[4]
				{
					new Point(num, num2 - num3),
					new Point(num + num3, num2),
					new Point(num, num2 + num3),
					new Point(num - num3, num2)
				};
				graphics_0.DrawPolygon(pen, points);
				graphics_0.DrawLine(pen, num, num2 - num3, num, num2 + num3);
				graphics_0.DrawLine(pen, num - num3, num2, num + num3, num2);
			}
		}
		finally
		{
			((IDisposable)pen).Dispose();
		}
	}

	private void panel_0_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
		{
			bool_1 = true;
			point_0 = e.Location;
			panel_0.Focus();
		}
	}

	private void panel_0_MouseMove(object sender, MouseEventArgs e)
	{
		if (bool_1)
		{
			int num = e.X - point_0.X;
			int num2 = e.Y - point_0.Y;
			point_0 = e.Location;
			float_0 += (float)num * 0.01f;
			float_1 += (float)num2 * 0.008f;
			float_1 = Math.Max(-1.4f, Math.Min(1.4f, float_1));
			panel_0.Invalidate();
		}
	}

	private void panel_0_MouseUp(object sender, MouseEventArgs e)
	{
		bool_1 = false;
	}

	private void panel_0_MouseWheel(object sender, MouseEventArgs e)
	{
		panel_0.Invalidate();
	}

	private void method_10(Graphics graphics_0, int int_0, int int_1)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		Vector3 boundsMin = pwMapBmdSceneFile_0.BoundsMin;
		Vector3 boundsMax = pwMapBmdSceneFile_0.BoundsMax;
		Vector3 val = (boundsMin + boundsMax) * 0.5f;
		float num = Math.Max(1f, Vector3.Distance(boundsMin, boundsMax) * 0.5f);
		float num2 = (float)Math.Cos(float_1);
		float num3 = (float)Math.Sin(float_1);
		float num4 = (float)Math.Cos(float_0);
		float num5 = (float)Math.Sin(float_0);
		float num6 = num * 2.2f;
		Vector3 val2 = val + new Vector3(num2 * num4 * num6, num3 * num6, num2 * num5 * num6);
		Vector3 val3 = Vector3.Normalize(val - val2);
		Vector3 val4 = Vector3.Normalize(Vector3.Cross(val3, Vector3.UnitY));
		Vector3 val5 = Vector3.Cross(val4, val3);
		_ = (float)int_0 / (float)Math.Max(1, int_1);
		float num7 = (float)int_0 * 0.45f / (float)Math.Tan(0.39269909262657166) / num;
		Pen pen = new Pen(Color.FromArgb(140, 120, 180, 255), 1f);
		Pen pen2 = new Pen(Color.FromArgb(50, 80, 120, 200), 0.5f);
		method_11(graphics_0, val, num, val2, val3, val4, val5, num7, int_0, int_1);
		foreach (PwMapBmdSceneFile.Mesh mesh in pwMapBmdSceneFile_0.Meshes)
		{
			if (mesh.Indices.Length < 3 || mesh.Vertices.Length < 3)
			{
				continue;
			}
			PointF[] array = new PointF[mesh.Vertices.Length];
			float[] array2 = new float[mesh.Vertices.Length];
			for (int i = 0; i < mesh.Vertices.Length; i++)
			{
				Vector3 val6 = mesh.Vertices[i] - val2;
				float num8 = Vector3.Dot(val6, val3);
				float num9 = Vector3.Dot(val6, val4);
				float num10 = Vector3.Dot(val6, val5);
				float num11 = ((num8 > 0.01f) ? (num7 / num8) : (num7 / 0.01f));
				array[i] = new PointF((float)int_0 * 0.5f + num9 * num11, (float)int_1 * 0.5f - num10 * num11);
				array2[i] = num8;
			}
			for (int j = 0; j + 2 < mesh.Indices.Length; j += 3)
			{
				int num12 = mesh.Indices[j];
				int num13 = mesh.Indices[j + 1];
				int num14 = mesh.Indices[j + 2];
				if (num12 >= 0 && num12 < array.Length && num13 >= 0 && num13 < array.Length && num14 >= 0 && num14 < array.Length && (!(array2[num12] < 0.1f) || !(array2[num13] < 0.1f) || !(array2[num14] < 0.1f)))
				{
					graphics_0.DrawLine(pen, array[num12], array[num13]);
					graphics_0.DrawLine(pen, array[num13], array[num14]);
					graphics_0.DrawLine(pen, array[num14], array[num12]);
				}
			}
		}
		pen.Dispose();
		pen2.Dispose();
		method_12(graphics_0, boundsMin, boundsMax, val2, val3, val4, val5, num7, int_0, int_1);
	}

	private void method_11(Graphics graphics_0, Vector3 vector3_0, float float_2, Vector3 vector3_1, Vector3 vector3_2, Vector3 vector3_3, Vector3 vector3_4, float float_3, int int_0, int int_1)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		float num = float_2 * 0.3f;
		Vector3[] array = (Vector3[])(object)new Vector3[3] { vector3_0, vector3_0, vector3_0 };
		Vector3[] array2 = (Vector3[])(object)new Vector3[3]
		{
			vector3_0 + new Vector3(num, 0f, 0f),
			vector3_0 + new Vector3(0f, num, 0f),
			vector3_0 + new Vector3(0f, 0f, num)
		};
		Color[] array3 = new Color[3]
		{
			Color.FromArgb(200, 255, 60, 60),
			Color.FromArgb(200, 60, 255, 60),
			Color.FromArgb(200, 80, 120, 255)
		};
		for (int i = 0; i < 3; i++)
		{
			PointF pt = smethod_4(array[i], vector3_1, vector3_2, vector3_3, vector3_4, float_3, int_0, int_1);
			PointF pt2 = smethod_4(array2[i], vector3_1, vector3_2, vector3_3, vector3_4, float_3, int_0, int_1);
			Pen pen = new Pen(array3[i], 2f);
			try
			{
				graphics_0.DrawLine(pen, pt, pt2);
			}
			finally
			{
				((IDisposable)pen).Dispose();
			}
		}
	}

	private void method_12(Graphics graphics_0, Vector3 vector3_0, Vector3 vector3_1, Vector3 vector3_2, Vector3 vector3_3, Vector3 vector3_4, Vector3 vector3_5, float float_2, int int_0, int int_1)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		Vector3[] array = (Vector3[])(object)new Vector3[8]
		{
			new Vector3(vector3_0.X, vector3_0.Y, vector3_0.Z),
			new Vector3(vector3_1.X, vector3_0.Y, vector3_0.Z),
			new Vector3(vector3_1.X, vector3_1.Y, vector3_0.Z),
			new Vector3(vector3_0.X, vector3_1.Y, vector3_0.Z),
			new Vector3(vector3_0.X, vector3_0.Y, vector3_1.Z),
			new Vector3(vector3_1.X, vector3_0.Y, vector3_1.Z),
			new Vector3(vector3_1.X, vector3_1.Y, vector3_1.Z),
			new Vector3(vector3_0.X, vector3_1.Y, vector3_1.Z)
		};
		int[,] array2 = new int[12, 2]
		{
			{ 0, 1 },
			{ 1, 2 },
			{ 2, 3 },
			{ 3, 0 },
			{ 4, 5 },
			{ 5, 6 },
			{ 6, 7 },
			{ 7, 4 },
			{ 0, 4 },
			{ 1, 5 },
			{ 2, 6 },
			{ 3, 7 }
		};
		Pen pen = new Pen(Color.FromArgb(60, 255, 255, 100), 1f);
		try
		{
			pen.DashStyle = DashStyle.Dot;
			for (int i = 0; i < 12; i++)
			{
				PointF pt = smethod_4(array[array2[i, 0]], vector3_2, vector3_3, vector3_4, vector3_5, float_2, int_0, int_1);
				PointF pt2 = smethod_4(array[array2[i, 1]], vector3_2, vector3_3, vector3_4, vector3_5, float_2, int_0, int_1);
				graphics_0.DrawLine(pen, pt, pt2);
			}
		}
		finally
		{
			((IDisposable)pen).Dispose();
		}
	}

	private static PointF smethod_4(Vector3 vector3_0, Vector3 vector3_1, Vector3 vector3_2, Vector3 vector3_3, Vector3 vector3_4, float float_2, int int_0, int int_1)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = vector3_0 - vector3_1;
		float num = Vector3.Dot(val, vector3_2);
		float num2 = Vector3.Dot(val, vector3_3);
		float num3 = Vector3.Dot(val, vector3_4);
		float num4 = ((num > 0.01f) ? (float_2 / num) : (float_2 / 0.01f));
		return new PointF((float)int_0 * 0.5f + num2 * num4, (float)int_1 * 0.5f - num3 * num4);
	}

	private async void method_13()
	{
		if (bool_0)
		{
			return;
		}
		bool_0 = true;
		label_0.Text = TextStorage.Msg(Class16.smethod_0(1649091018), Class16.smethod_0(1649091051));
		treeView_0.Nodes.Clear();
		button_0.Enabled = false;
		try
		{
			bool flag;
			List<string> list;
			List<(string, List<string>)> list2;
			lock (object_0)
			{
				flag = list_1 != null && list_2 != null;
				list = (flag ? list_1 : null);
				list2 = (flag ? list_2 : null);
			}
			if (!flag)
			{
				(list, list2) = await Task.Run((Func<(List<string>, List<(string, List<string>)>)>)Class293.class293_0.method_1);
				lock (object_0)
				{
					list_1 = list;
					list_2 = list2;
				}
			}
			if (base.IsDisposed)
			{
				return;
			}
			list_0 = list;
			treeView_0.BeginUpdate();
			try
			{
				foreach (var (string_, list_) in list2)
				{
					method_14(string_, list_);
				}
				if (treeView_0.Nodes.Count == 0)
				{
					treeView_0.Nodes.Add(Class16.smethod_0(1649094153));
				}
			}
			finally
			{
				treeView_0.EndUpdate();
			}
			label_0.Text = (flag ? string.Format(Class16.smethod_0(1649094218), list_0.Count) : string.Format(Class16.smethod_0(1649094184), list_0.Count));
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649094243));
			if (!base.IsDisposed)
			{
				label_0.Text = TextStorage.Msg(Class16.smethod_0(1649094307), Class16.smethod_0(1648935998)) + ex.Message;
			}
		}
		finally
		{
			bool_0 = false;
			if (!base.IsDisposed)
			{
				button_0.Enabled = true;
			}
		}
	}

	private static (List<string>, List<(string, List<string>)>) smethod_5()
	{
		(string, string[], string, string)[] array = new(string, string[], string, string)[4]
		{
			(Class16.smethod_0(1649093763), new string[2]
			{
				Class16.smethod_0(1649093786),
				Class16.smethod_0(1649138031)
			}, string.Empty, Class16.smethod_0(1649142694)),
			(Class16.smethod_0(1649093802), new string[1] { Class16.smethod_0(1649093829) }, string.Empty, Class16.smethod_0(1649094375)),
			(Class16.smethod_0(1649093833), new string[2]
			{
				Class16.smethod_0(1649138031),
				Class16.smethod_0(1649093786)
			}, string.Empty, Class16.smethod_0(1648906325)),
			(Class16.smethod_0(1649093863), new string[1] { Class16.smethod_0(1649141675) }, string.Empty, Class16.smethod_0(1649119451))
		};
		List<string> list = new List<string>(4096);
		List<(string, List<string>)> list2 = new List<(string, List<string>)>();
		(string, string[], string, string)[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			(string, string[], string, string) tuple = array2[i];
			string item = tuple.Item1;
			string[] item2 = tuple.Item2;
			string item3 = tuple.Item3;
			string item4 = tuple.Item4;
			HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			List<string> list3 = new List<string>(1024);
			for (int j = 0; j < item2.Length; j++)
			{
				IReadOnlyList<string> readOnlyList = PwMapAssetProvider.EnumeratePckFiles(item2[j], item3, item4);
				if (readOnlyList == null)
				{
					continue;
				}
				for (int k = 0; k < readOnlyList.Count; k++)
				{
					if (hashSet.Add(readOnlyList[k]))
					{
						list3.Add(readOnlyList[k].Replace('/', '\\'));
					}
				}
			}
			list3.Sort(StringComparer.OrdinalIgnoreCase);
			if (list3.Count > 0)
			{
				list2.Add((item, list3));
			}
			list.AddRange(list3);
		}
		return (list, list2);
	}

	private void method_14(string string_1, List<string> list_3)
	{
		TreeNode treeNode = new TreeNode(string_1 + string.Format(Class16.smethod_0(1649093872), list_3.Count))
		{
			ForeColor = Color.FromArgb(180, 220, 255)
		};
		treeView_0.Nodes.Add(treeNode);
		Dictionary<string, TreeNode> dictionary = new Dictionary<string, TreeNode>(StringComparer.OrdinalIgnoreCase);
		for (int i = 0; i < list_3.Count; i++)
		{
			string text = list_3[i];
			string[] array = text.Split('\\');
			TreeNodeCollection nodes = treeNode.Nodes;
			string text2 = string.Empty;
			for (int j = 0; j < array.Length - 1; j++)
			{
				text2 = ((text2.Length > 0) ? (text2 + Class16.smethod_0(1648927580) + array[j]) : array[j]);
				string key = string_1 + Class16.smethod_0(1648905535) + text2;
				if (dictionary.TryGetValue(key, out var value))
				{
					nodes = value.Nodes;
					continue;
				}
				TreeNode treeNode2 = null;
				foreach (TreeNode item in nodes)
				{
					if (string.Equals(item.Text, array[j], StringComparison.OrdinalIgnoreCase))
					{
						treeNode2 = item;
						break;
					}
				}
				if (treeNode2 == null)
				{
					treeNode2 = new TreeNode(array[j]);
					nodes.Add(treeNode2);
				}
				dictionary[key] = treeNode2;
				nodes = treeNode2.Nodes;
			}
			string text3 = array[array.Length - 1];
			TreeNode node = new TreeNode(text3)
			{
				Tag = text
			};
			nodes.Add(node);
		}
	}

	private void method_15()
	{
		string obj = textBox_0.Text;
		object obj2;
		if (obj == null)
		{
			obj2 = null;
		}
		else
		{
			obj2 = obj.Trim();
			if (obj2 != null)
			{
				goto IL_0020;
			}
		}
		obj2 = string.Empty;
		goto IL_0020;
		IL_0020:
		string text = (string)obj2;
		if (text.Length == 0 && !bool_0)
		{
			method_13();
		}
		else
		{
			if (text.Length < 2)
			{
				return;
			}
			treeView_0.BeginUpdate();
			treeView_0.Nodes.Clear();
			int num = 0;
			if (list_0 != null)
			{
				TreeNode treeNode = new TreeNode(Class16.smethod_0(1649093893) + text + Class16.smethod_0(1648904453))
				{
					ForeColor = Color.FromArgb(255, 220, 120)
				};
				treeView_0.Nodes.Add(treeNode);
				for (int i = 0; i < list_0.Count; i++)
				{
					if (num >= 500)
					{
						break;
					}
					if (list_0[i].IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0)
					{
						string text2 = list_0[i];
						TreeNode node = new TreeNode(System.IO.Path.GetFileName(text2))
						{
							Tag = text2,
							ToolTipText = text2
						};
						treeNode.Nodes.Add(node);
						num++;
					}
				}
				treeNode.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649093909), Class16.smethod_0(1649093928)), text, num);
				treeNode.Expand();
			}
			label_0.Text = ((num >= 500) ? string.Format(Class16.smethod_0(1649093988), num, 500) : string.Format(Class16.smethod_0(1649093962), num));
			treeView_0.EndUpdate();
		}
	}

	public void PopulateFromEntries(IEnumerable<string> entryPaths)
	{
		treeView_0.Nodes.Clear();
		if (entryPaths == null)
		{
			return;
		}
		foreach (string entryPath in entryPaths)
		{
			string[] array = entryPath.Replace('\\', '/').Split('/');
			TreeNodeCollection nodes = treeView_0.Nodes;
			for (int i = 0; i < array.Length; i++)
			{
				string b = array[i];
				TreeNode treeNode = null;
				foreach (TreeNode item in nodes)
				{
					if (string.Equals(item.Text, b, StringComparison.OrdinalIgnoreCase))
					{
						treeNode = item;
						break;
					}
				}
				if (treeNode == null)
				{
					treeNode = new TreeNode(b);
					if (i == array.Length - 1)
					{
						treeNode.Tag = entryPath;
					}
					nodes.Add(treeNode);
				}
				nodes = treeNode.Nodes;
			}
		}
	}

	private void textBox_0_Enter(object sender, EventArgs e)
	{
		if (textBox_0.ForeColor == Color.Gray)
		{
			textBox_0.Text = string.Empty;
			textBox_0.ForeColor = Color.White;
		}
	}

	private void textBox_0_Leave(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(textBox_0.Text))
		{
			textBox_0.ForeColor = Color.Gray;
			textBox_0.Text = TextStorage.Msg(Class16.smethod_0(1649094011), Class16.smethod_0(1649094654));
		}
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		if (textBox_0.ForeColor != Color.Gray)
		{
			method_15();
		}
	}

	private void label_2_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(SelectedResource))
		{
			Clipboard.SetText(SelectedResource);
		}
	}
}
