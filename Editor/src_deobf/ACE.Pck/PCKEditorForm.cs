using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;
using ACE.Protectors;
using ACE.RSGlobal;

namespace ACE.Pck;

public class PCKEditorForm : Form
{
	[StructLayout(LayoutKind.Auto)]
	private struct Struct93 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		public PCKEditorForm pckeditorForm_0;

		private TaskAwaiter taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PCKEditorForm pCKEditorForm = pckeditorForm_0;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = pCKEditorForm.method_14().GetAwaiter();
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

	[StructLayout(LayoutKind.Auto)]
	private struct Struct94 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		public DragEventArgs dragEventArgs_0;

		public PCKEditorForm pckeditorForm_0;

		private TaskAwaiter taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PCKEditorForm pCKEditorForm = pckeditorForm_0;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = taskAwaiter_0;
					taskAwaiter_0 = default(TaskAwaiter);
					num = -1;
					int_0 = -1;
					goto IL_00cc;
				}
				string[] array = (string[])dragEventArgs_0.Data.GetData(DataFormats.FileDrop);
				if (array != null && array.Length != 0)
				{
					string text = System.IO.Path.GetExtension(array[0]).ToLower();
					if (text == Class16.smethod_0(1648909411))
					{
						pCKEditorForm.method_3(array[0]);
					}
					else
					{
						PCKArchiveManager pckarchiveManager_ = pCKEditorForm.pckarchiveManager_0;
						if (pckarchiveManager_ != null && pckarchiveManager_.IsLoaded)
						{
							awaiter = pCKEditorForm.method_17(array, null).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = 0;
								int_0 = 0;
								taskAwaiter_0 = awaiter;
								asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
								return;
							}
							goto IL_00cc;
						}
					}
				}
				goto end_IL_000e;
				IL_00cc:
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

	[StructLayout(LayoutKind.Auto)]
	private struct Struct95 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		public PCKEditorForm pckeditorForm_0;

		private FolderBrowserDialog folderBrowserDialog_0;

		private List<string> list_0;

		private TaskAwaiter<bool> taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PCKEditorForm pCKEditorForm = pckeditorForm_0;
			try
			{
				if (num != 0)
				{
					folderBrowserDialog_0 = new FolderBrowserDialog();
				}
				try
				{
					if (num == 0)
					{
						goto IL_0054;
					}
					folderBrowserDialog_0.Description = TextStorage.Msg(Class16.smethod_0(1649196059));
					if (folderBrowserDialog_0.ShowDialog() == DialogResult.OK)
					{
						pCKEditorForm.method_28(bool_1: false);
						goto IL_0054;
					}
					goto end_IL_001d;
					IL_0054:
					try
					{
						TaskAwaiter<bool> awaiter;
						if (num != 0)
						{
							list_0 = pCKEditorForm.method_26();
							pCKEditorForm.cancellationTokenSource_0 = new CancellationTokenSource();
							awaiter = pCKEditorForm.pckarchiveManager_0.ExtractFilesAsync(list_0, folderBrowserDialog_0.SelectedPath, pCKEditorForm.cancellationTokenSource_0.Token).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = 0;
								int_0 = 0;
								taskAwaiter_0 = awaiter;
								asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
								return;
							}
						}
						else
						{
							awaiter = taskAwaiter_0;
							taskAwaiter_0 = default(TaskAwaiter<bool>);
							num = -1;
							int_0 = -1;
						}
						awaiter.GetResult();
						DKBox.Show(string.Format(Class16.smethod_0(1648932366), TextStorage.Msg(Class16.smethod_0(1649196089)), list_0.Count), TextStorage.Msg(Class16.smethod_0(1649020587)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						list_0 = null;
					}
					catch (Exception ex)
					{
						SentryHelper.CaptureException(ex, Class16.smethod_0(1649196172));
						DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649196148)) + Class16.smethod_0(1648908709) + ex.Message, TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					finally
					{
						if (num < 0)
						{
							pCKEditorForm.method_28(bool_1: true);
						}
					}
					end_IL_001d:;
				}
				finally
				{
					if (num < 0 && folderBrowserDialog_0 != null)
					{
						((IDisposable)folderBrowserDialog_0).Dispose();
					}
				}
				folderBrowserDialog_0 = null;
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

	[StructLayout(LayoutKind.Auto)]
	private struct Struct96 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		public PCKEditorForm pckeditorForm_0;

		private TaskAwaiter taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PCKEditorForm pCKEditorForm = pckeditorForm_0;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = pCKEditorForm.method_18().GetAwaiter();
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

	[StructLayout(LayoutKind.Auto)]
	private struct Struct97 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		public PCKEditorForm pckeditorForm_0;

		private TaskAwaiter taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PCKEditorForm pCKEditorForm = pckeditorForm_0;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = pCKEditorForm.method_15().GetAwaiter();
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

	[StructLayout(LayoutKind.Auto)]
	private struct Struct98 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		public PCKEditorForm pckeditorForm_0;

		private OpenFileDialog openFileDialog_0;

		private TaskAwaiter taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PCKEditorForm pCKEditorForm = pckeditorForm_0;
			try
			{
				if (num != 0)
				{
					openFileDialog_0 = new OpenFileDialog();
				}
				try
				{
					TaskAwaiter awaiter;
					if (num == 0)
					{
						awaiter = taskAwaiter_0;
						taskAwaiter_0 = default(TaskAwaiter);
						num = -1;
						int_0 = -1;
						goto IL_00ca;
					}
					openFileDialog_0.Multiselect = true;
					openFileDialog_0.Title = TextStorage.Msg(Class16.smethod_0(1649196721));
					openFileDialog_0.Filter = Class16.smethod_0(1649137838);
					if (openFileDialog_0.ShowDialog() == DialogResult.OK)
					{
						awaiter = pCKEditorForm.method_17(openFileDialog_0.FileNames, null).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							int_0 = 0;
							taskAwaiter_0 = awaiter;
							asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_00ca;
					}
					goto end_IL_001d;
					IL_00ca:
					awaiter.GetResult();
					end_IL_001d:;
				}
				finally
				{
					if (num < 0 && openFileDialog_0 != null)
					{
						((IDisposable)openFileDialog_0).Dispose();
					}
				}
				openFileDialog_0 = null;
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

	[StructLayout(LayoutKind.Auto)]
	private struct Struct99 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		public string[] string_0;

		public PCKEditorForm pckeditorForm_0;

		public string string_1;

		private Class338 class338_0;

		private TaskAwaiter taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PCKEditorForm pCKEditorForm = pckeditorForm_0;
			try
			{
				if (num == 0)
				{
					goto IL_0073;
				}
				class338_0 = new Class338();
				class338_0.string_0 = string_0;
				class338_0.pckeditorForm_0 = pckeditorForm_0;
				class338_0.string_1 = string_1;
				if (pCKEditorForm.pckarchiveManager_0 != null && pCKEditorForm.pckarchiveManager_0.IsLoaded)
				{
					pCKEditorForm.method_28(bool_1: false);
					goto IL_0073;
				}
				goto end_IL_000e;
				IL_0073:
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						pCKEditorForm.cancellationTokenSource_0 = new CancellationTokenSource();
						class338_0.int_0 = 0;
						class338_0.int_1 = class338_0.string_0.Length;
						awaiter = Task.Run((Action)class338_0.method_0).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							int_0 = 0;
							taskAwaiter_0 = awaiter;
							asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
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
					pCKEditorForm.method_7();
					pCKEditorForm.method_8();
					DKBox.Show(string.Format(Class16.smethod_0(1648889430), class338_0.int_0, TextStorage.Msg(Class16.smethod_0(1649196744))), TextStorage.Msg(Class16.smethod_0(1649020587)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				catch (Exception ex)
				{
					SentryHelper.CaptureException(ex, Class16.smethod_0(1649196774));
					DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649196812)) + Class16.smethod_0(1648908709) + ex.Message, TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				finally
				{
					if (num < 0)
					{
						pCKEditorForm.method_28(bool_1: true);
					}
				}
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				int_0 = -2;
				class338_0 = null;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			class338_0 = null;
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

	[StructLayout(LayoutKind.Auto)]
	private struct Struct100 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		public PCKEditorForm pckeditorForm_0;

		private TaskAwaiter<bool> taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PCKEditorForm pCKEditorForm = pckeditorForm_0;
			try
			{
				if (num == 0)
				{
					goto IL_0072;
				}
				if (pCKEditorForm.pckarchiveManager_0 != null && pCKEditorForm.pckarchiveManager_0.IsLoaded)
				{
					DialogResult dialogResult = DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649196965)), TextStorage.Msg(Class16.smethod_0(1649196987)), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (dialogResult == DialogResult.Yes)
					{
						pCKEditorForm.cancellationTokenSource_0 = new CancellationTokenSource();
						pCKEditorForm.method_28(bool_1: false);
						goto IL_0072;
					}
				}
				goto end_IL_000e;
				IL_0072:
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num != 0)
					{
						awaiter = pCKEditorForm.pckarchiveManager_0.FullDefragAsync(pCKEditorForm.cancellationTokenSource_0.Token).GetAwaiter();
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
						taskAwaiter_0 = default(TaskAwaiter<bool>);
						num = -1;
						int_0 = -1;
					}
					if (awaiter.GetResult())
					{
						pCKEditorForm.method_7();
						pCKEditorForm.method_8();
						DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649196848)), TextStorage.Msg(Class16.smethod_0(1649020587)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				catch (Exception ex)
				{
					SentryHelper.CaptureException(ex, Class16.smethod_0(1649197023));
					DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649196039)) + Class16.smethod_0(1648908709) + ex.Message, TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				finally
				{
					if (num < 0)
					{
						pCKEditorForm.method_28(bool_1: true);
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

	private sealed class Class336
	{
		public ComboBox comboBox_0;

		public TextBox textBox_0;

		public TextBox textBox_1;

		public TextBox textBox_2;

		internal void method_0(object sender, EventArgs e)
		{
			PCK_PROTECTION_SETTINGS? pCK_PROTECTION_SETTINGS = comboBox_0.SelectedIndex switch
			{
				1 => PCK.GetDefaultKeys(GAMES.PW), 
				2 => PCK.GetDefaultKeys(GAMES.FW), 
				3 => PCK.GetDefaultKeys(GAMES.ESO), 
				4 => PCK.GetDefaultKeys(GAMES.RWPD), 
				_ => null, 
			};
			if (pCK_PROTECTION_SETTINGS.HasValue)
			{
				textBox_0.Text = pCK_PROTECTION_SETTINGS.Value.KEY_1.ToString();
				textBox_1.Text = pCK_PROTECTION_SETTINGS.Value.KEY_2.ToString();
				textBox_2.Text = pCK_PROTECTION_SETTINGS.Value.FTO_KEY.ToString();
			}
		}
	}

	private sealed class Class337 : ToolStripProfessionalRenderer
	{
		protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs toolStripItemRenderEventArgs_0)
		{
			Rectangle rect = new Rectangle(Point.Empty, toolStripItemRenderEventArgs_0.Item.Size);
			Color color = ((!toolStripItemRenderEventArgs_0.Item.Selected || !toolStripItemRenderEventArgs_0.Item.Enabled) ? Color.FromArgb(45, 45, 48) : Color.FromArgb(62, 62, 64));
			SolidBrush solidBrush = new SolidBrush(color);
			try
			{
				toolStripItemRenderEventArgs_0.Graphics.FillRectangle(solidBrush, rect);
			}
			finally
			{
				((IDisposable)solidBrush).Dispose();
			}
		}

		protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs toolStripSeparatorRenderEventArgs_0)
		{
			int num = toolStripSeparatorRenderEventArgs_0.Item.Height / 2;
			Pen pen = new Pen(Color.FromArgb(70, 70, 71));
			try
			{
				toolStripSeparatorRenderEventArgs_0.Graphics.DrawLine(pen, 28, num, toolStripSeparatorRenderEventArgs_0.Item.Width - 4, num);
			}
			finally
			{
				((IDisposable)pen).Dispose();
			}
		}

		protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs toolStripRenderEventArgs_0)
		{
			SolidBrush solidBrush = new SolidBrush(Color.FromArgb(45, 45, 48));
			try
			{
				toolStripRenderEventArgs_0.Graphics.FillRectangle(solidBrush, toolStripRenderEventArgs_0.AffectedBounds);
			}
			finally
			{
				((IDisposable)solidBrush).Dispose();
			}
		}

		protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs toolStripRenderEventArgs_0)
		{
			Pen pen = new Pen(Color.FromArgb(70, 70, 71));
			try
			{
				toolStripRenderEventArgs_0.Graphics.DrawRectangle(pen, 0, 0, toolStripRenderEventArgs_0.AffectedBounds.Width - 1, toolStripRenderEventArgs_0.AffectedBounds.Height - 1);
			}
			finally
			{
				((IDisposable)pen).Dispose();
			}
		}

		protected override void OnRenderImageMargin(ToolStripRenderEventArgs toolStripRenderEventArgs_0)
		{
			SolidBrush solidBrush = new SolidBrush(Color.FromArgb(45, 45, 48));
			try
			{
				toolStripRenderEventArgs_0.Graphics.FillRectangle(solidBrush, toolStripRenderEventArgs_0.AffectedBounds);
			}
			finally
			{
				((IDisposable)solidBrush).Dispose();
			}
		}
	}

	private sealed class Class338
	{
		public string[] string_0;

		public PCKEditorForm pckeditorForm_0;

		public string string_1;

		public int int_0;

		public int int_1;

		internal void method_0()
		{
			string[] array = string_0;
			for (int i = 0; i < array.Length; i++)
			{
				Class339 @class = new Class339();
				@class.class338_0 = this;
				@class.string_0 = array[i];
				if (pckeditorForm_0.cancellationTokenSource_0.Token.IsCancellationRequested)
				{
					break;
				}
				string text;
				if (string_1 != null)
				{
					text = @class.string_0.Substring(string_1.Length).TrimStart('\\', '/');
					text = pckeditorForm_0.string_0.TrimEnd('\\') + Class16.smethod_0(1648927580) + text;
				}
				else
				{
					text = pckeditorForm_0.string_0.TrimEnd('\\') + Class16.smethod_0(1648927580) + System.IO.Path.GetFileName(@class.string_0);
				}
				text = text.TrimStart('\\');
				if (pckeditorForm_0.pckarchiveManager_0.AddFile(text, @class.string_0))
				{
					int_0++;
				}
				if (pckeditorForm_0.method_6())
				{
					try
					{
						pckeditorForm_0.BeginInvoke(new Action(@class.method_0));
					}
					catch (ObjectDisposedException)
					{
					}
					catch (InvalidOperationException)
					{
					}
				}
			}
		}
	}

	private sealed class Class339
	{
		public string string_0;

		public Class338 class338_0;

		internal void method_0()
		{
			if (class338_0.pckeditorForm_0.method_6())
			{
				class338_0.pckeditorForm_0.method_12(new PckOperationProgressEventArgs
				{
					Stage = PckOperationStage.Adding,
					CurrentIndex = class338_0.int_0,
					TotalCount = class338_0.int_1,
					StatusMessage = Class16.smethod_0(1649194492) + System.IO.Path.GetFileName(string_0) + Class16.smethod_0(1648924410)
				});
			}
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct101 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		public PCKEditorForm pckeditorForm_0;

		private TaskAwaiter taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PCKEditorForm pCKEditorForm = pckeditorForm_0;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = pCKEditorForm.method_16().GetAwaiter();
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

	private sealed class Class340
	{
		private string string_0;

		private string string_1;

		private uint uint_0;

		private uint uint_1;

		private int int_0;

		public string method_0()
		{
			return string_0;
		}

		public void method_1(string string_2)
		{
			string_0 = string_2;
		}

		public string method_2()
		{
			return string_1;
		}

		public void method_3(string string_2)
		{
			string_1 = string_2;
		}

		public uint method_4()
		{
			return uint_0;
		}

		public void method_5(uint uint_2)
		{
			uint_0 = uint_2;
		}

		public uint method_6()
		{
			return uint_1;
		}

		public void method_7(uint uint_2)
		{
			uint_1 = uint_2;
		}

		public int method_8()
		{
			return int_0;
		}

		public void method_9(int int_1)
		{
			int_0 = int_1;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct102 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		public PCKEditorForm pckeditorForm_0;

		private FolderBrowserDialog folderBrowserDialog_0;

		private TaskAwaiter taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PCKEditorForm pCKEditorForm = pckeditorForm_0;
			try
			{
				if (num != 0)
				{
					folderBrowserDialog_0 = new FolderBrowserDialog();
				}
				try
				{
					TaskAwaiter awaiter;
					if (num == 0)
					{
						awaiter = taskAwaiter_0;
						taskAwaiter_0 = default(TaskAwaiter);
						num = -1;
						int_0 = -1;
						goto IL_00c8;
					}
					folderBrowserDialog_0.Description = TextStorage.Msg(Class16.smethod_0(1649196824));
					if (folderBrowserDialog_0.ShowDialog() == DialogResult.OK)
					{
						string[] files = Directory.GetFiles(folderBrowserDialog_0.SelectedPath, Class16.smethod_0(1648941528), SearchOption.AllDirectories);
						awaiter = pCKEditorForm.method_17(files, folderBrowserDialog_0.SelectedPath).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							int_0 = 0;
							taskAwaiter_0 = awaiter;
							asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_00c8;
					}
					goto end_IL_001d;
					IL_00c8:
					awaiter.GetResult();
					end_IL_001d:;
				}
				finally
				{
					if (num < 0 && folderBrowserDialog_0 != null)
					{
						((IDisposable)folderBrowserDialog_0).Dispose();
					}
				}
				folderBrowserDialog_0 = null;
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

	private sealed class Class341
	{
		public PCKEditorForm pckeditorForm_0;

		public PckOperationProgressEventArgs pckOperationProgressEventArgs_0;

		internal void method_0()
		{
			pckeditorForm_0.method_12(pckOperationProgressEventArgs_0);
		}
	}

	private sealed class Class342
	{
		public PCKEditorForm pckeditorForm_0;

		public int int_0;

		public int int_1;

		internal void method_0()
		{
			if (int_0 >= 0 && int_0 < pckeditorForm_0.dataGridView_0.Rows.Count)
			{
				pckeditorForm_0.dataGridView_0.Rows[int_0].Cells[int_1].Value = smethod_4();
			}
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct103 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		public PCKEditorForm pckeditorForm_0;

		private FolderBrowserDialog folderBrowserDialog_0;

		private List<string> list_0;

		private TaskAwaiter<bool> taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PCKEditorForm pCKEditorForm = pckeditorForm_0;
			try
			{
				if (num == 0)
				{
					goto IL_0039;
				}
				if (pCKEditorForm.pckarchiveManager_0 != null && pCKEditorForm.pckarchiveManager_0.IsLoaded)
				{
					folderBrowserDialog_0 = new FolderBrowserDialog();
					goto IL_0039;
				}
				goto end_IL_000e;
				IL_0039:
				try
				{
					if (num == 0)
					{
						goto IL_0070;
					}
					folderBrowserDialog_0.Description = TextStorage.Msg(Class16.smethod_0(1649196059));
					if (folderBrowserDialog_0.ShowDialog() == DialogResult.OK)
					{
						pCKEditorForm.method_28(bool_1: false);
						goto IL_0070;
					}
					goto end_IL_0039;
					IL_0070:
					try
					{
						TaskAwaiter<bool> awaiter;
						if (num != 0)
						{
							pCKEditorForm.cancellationTokenSource_0 = new CancellationTokenSource();
							list_0 = new List<string>();
							Dictionary<string, List<Class340>>.Enumerator enumerator = pCKEditorForm.dictionary_1.GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									List<Class340>.Enumerator enumerator2 = enumerator.Current.Value.GetEnumerator();
									try
									{
										while (enumerator2.MoveNext())
										{
											Class340 current = enumerator2.Current;
											list_0.Add(current.method_0().TrimStart('\\'));
										}
									}
									finally
									{
										if (num < 0)
										{
											((IDisposable)enumerator2/*cast due to constrained. prefix*/).Dispose();
										}
									}
								}
							}
							finally
							{
								if (num < 0)
								{
									((IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
								}
							}
							awaiter = pCKEditorForm.pckarchiveManager_0.ExtractFilesAsync(list_0, folderBrowserDialog_0.SelectedPath, pCKEditorForm.cancellationTokenSource_0.Token).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = 0;
								int_0 = 0;
								taskAwaiter_0 = awaiter;
								asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
								return;
							}
						}
						else
						{
							awaiter = taskAwaiter_0;
							taskAwaiter_0 = default(TaskAwaiter<bool>);
							num = -1;
							int_0 = -1;
						}
						awaiter.GetResult();
						DKBox.Show(string.Format(Class16.smethod_0(1648932366), TextStorage.Msg(Class16.smethod_0(1649196089)), list_0.Count), TextStorage.Msg(Class16.smethod_0(1649020587)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						list_0 = null;
					}
					catch (Exception ex)
					{
						SentryHelper.CaptureException(ex, Class16.smethod_0(1649196117));
						DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649196148)) + Class16.smethod_0(1648908709) + ex.Message, TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					finally
					{
						if (num < 0)
						{
							pCKEditorForm.method_28(bool_1: true);
						}
					}
					end_IL_0039:;
				}
				finally
				{
					if (num < 0 && folderBrowserDialog_0 != null)
					{
						((IDisposable)folderBrowserDialog_0).Dispose();
					}
				}
				folderBrowserDialog_0 = null;
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

	[StructLayout(LayoutKind.Auto)]
	private struct Struct104 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		public PCKEditorForm pckeditorForm_0;

		private TaskAwaiter<bool> taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PCKEditorForm pCKEditorForm = pckeditorForm_0;
			try
			{
				if (num == 0)
				{
					goto IL_0040;
				}
				if (pCKEditorForm.pckarchiveManager_0 != null && pCKEditorForm.pckarchiveManager_0.IsLoaded)
				{
					pCKEditorForm.cancellationTokenSource_0 = new CancellationTokenSource();
					pCKEditorForm.method_28(bool_1: false);
					goto IL_0040;
				}
				goto end_IL_000e;
				IL_0040:
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num != 0)
					{
						awaiter = pCKEditorForm.pckarchiveManager_0.DefragAsync(pCKEditorForm.cancellationTokenSource_0.Token).GetAwaiter();
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
						taskAwaiter_0 = default(TaskAwaiter<bool>);
						num = -1;
						int_0 = -1;
					}
					if (awaiter.GetResult())
					{
						pCKEditorForm.method_7();
						pCKEditorForm.method_8();
						DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649196848)), TextStorage.Msg(Class16.smethod_0(1649020587)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				catch (Exception ex)
				{
					SentryHelper.CaptureException(ex, Class16.smethod_0(1649196874));
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649196918), Class16.smethod_0(1649196941)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				finally
				{
					if (num < 0)
					{
						pCKEditorForm.method_28(bool_1: true);
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

	private sealed class Class343
	{
		public string string_0;

		public Color color_0;

		public string string_1;

		internal void method_0(object sender, PaintEventArgs e)
		{
			Button button = (Button)sender;
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			SolidBrush solidBrush = new SolidBrush(button.BackColor);
			try
			{
				e.Graphics.FillRectangle(solidBrush, button.ClientRectangle);
			}
			finally
			{
				((IDisposable)solidBrush).Dispose();
			}
			if (button.ClientRectangle.Contains(button.PointToClient(Cursor.Position)) && button.Enabled)
			{
				Color color = (TDark.IsDarkMode ? Color.FromArgb(60, 60, 60) : Color.FromArgb(220, 225, 235));
				SolidBrush solidBrush2 = new SolidBrush(color);
				try
				{
					e.Graphics.FillRectangle(solidBrush2, button.ClientRectangle);
				}
				finally
				{
					((IDisposable)solidBrush2).Dispose();
				}
			}
			Font font = new Font(Class16.smethod_0(1649196708), 18f);
			try
			{
				SizeF sizeF = e.Graphics.MeasureString(string_0, font);
				float x = ((float)button.Width - sizeF.Width) / 2f;
				Color color2 = (TDark.IsDarkMode ? color_0 : SystemColors.ControlText);
				using SolidBrush brush = new SolidBrush(button.Enabled ? color2 : SystemColors.GrayText);
				e.Graphics.DrawString(string_0, font, brush, x, 6f);
			}
			finally
			{
				((IDisposable)font).Dispose();
			}
			float emSize = ((string_1.Length > 10) ? 7.5f : 9f);
			Font font2 = new Font(Class16.smethod_0(1648942905), emSize);
			try
			{
				SizeF sizeF2 = e.Graphics.MeasureString(string_1, font2);
				float x2 = ((float)button.Width - sizeF2.Width) / 2f;
				float y = (float)button.Height - sizeF2.Height - 4f;
				using SolidBrush brush2 = new SolidBrush(button.Enabled ? button.ForeColor : Color.Gray);
				e.Graphics.DrawString(string_1, font2, brush2, x2, y);
			}
			finally
			{
				((IDisposable)font2).Dispose();
			}
		}
	}

	[Serializable]
	private sealed class Class344
	{
		public static readonly Class344 class344_0 = new Class344();

		public static DataGridViewDataErrorEventHandler dataGridViewDataErrorEventHandler_0;

		public static Func<string, string> func_0;

		public static Func<Class340, string> func_1;

		public static Func<DataGridViewRow, bool> func_2;

		internal void method_0(object sender, DataGridViewDataErrorEventArgs e)
		{
			e.ThrowException = false;
		}

		internal string method_1(string string_0)
		{
			return string_0;
		}

		internal string method_2(Class340 class340_0)
		{
			return class340_0.method_2();
		}

		internal bool method_3(DataGridViewRow dataGridViewRow_0)
		{
			return dataGridViewRow_0.Index > 0;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct105 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		public PCKEditorForm pckeditorForm_0;

		public DragEventArgs dragEventArgs_0;

		private TaskAwaiter taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			PCKEditorForm pCKEditorForm = pckeditorForm_0;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = taskAwaiter_0;
					taskAwaiter_0 = default(TaskAwaiter);
					num = -1;
					int_0 = -1;
					goto IL_009f;
				}
				if (pCKEditorForm.pckarchiveManager_0 != null && pCKEditorForm.pckarchiveManager_0.IsLoaded)
				{
					string[] array = (string[])dragEventArgs_0.Data.GetData(DataFormats.FileDrop);
					if (array != null && array.Length != 0)
					{
						awaiter = pCKEditorForm.method_17(array, null).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							int_0 = 0;
							taskAwaiter_0 = awaiter;
							asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_009f;
					}
				}
				goto end_IL_000e;
				IL_009f:
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

	private sealed class Class345
	{
		public string string_0;

		public Color color_0;

		public string string_1;

		internal void method_0(object sender, PaintEventArgs e)
		{
			Button button = (Button)sender;
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			SolidBrush solidBrush = new SolidBrush(button.BackColor);
			try
			{
				e.Graphics.FillRectangle(solidBrush, button.ClientRectangle);
			}
			finally
			{
				((IDisposable)solidBrush).Dispose();
			}
			if (button.ClientRectangle.Contains(button.PointToClient(Cursor.Position)) && button.Enabled)
			{
				Color color = (TDark.IsDarkMode ? Color.FromArgb(60, 60, 60) : Color.FromArgb(220, 225, 235));
				SolidBrush solidBrush2 = new SolidBrush(color);
				try
				{
					e.Graphics.FillRectangle(solidBrush2, button.ClientRectangle);
				}
				finally
				{
					((IDisposable)solidBrush2).Dispose();
				}
			}
			Font font = new Font(Class16.smethod_0(1649196708), 18f);
			try
			{
				SizeF sizeF = e.Graphics.MeasureString(string_0, font);
				float x = ((float)button.Width - sizeF.Width) / 2f;
				float y = 6f;
				Color color2 = (TDark.IsDarkMode ? color_0 : SystemColors.ControlText);
				using SolidBrush brush = new SolidBrush(button.Enabled ? color2 : SystemColors.GrayText);
				e.Graphics.DrawString(string_0, font, brush, x, y);
			}
			finally
			{
				((IDisposable)font).Dispose();
			}
			float emSize = ((string_1.Length > 10) ? 7.5f : 9f);
			Font font2 = new Font(Class16.smethod_0(1648942905), emSize);
			try
			{
				SizeF sizeF2 = e.Graphics.MeasureString(string_1, font2);
				float x2 = ((float)button.Width - sizeF2.Width) / 2f;
				float y2 = (float)button.Height - sizeF2.Height - 4f;
				using SolidBrush brush2 = new SolidBrush(button.Enabled ? button.ForeColor : Color.Gray);
				e.Graphics.DrawString(string_1, font2, brush2, x2, y2);
			}
			finally
			{
				((IDisposable)font2).Dispose();
			}
		}
	}

	private static readonly Color color_0 = Color.FromArgb(30, 30, 30);

	private static readonly Color color_1 = Color.FromArgb(45, 45, 48);

	private static readonly Color color_2 = Color.FromArgb(60, 60, 60);

	private static readonly Color color_3 = Color.FromArgb(70, 70, 71);

	private static readonly Color color_4 = Color.FromArgb(255, 255, 255);

	private static readonly Color color_5 = Color.FromArgb(180, 180, 180);

	private static readonly Color color_6 = Color.FromArgb(0, 120, 212);

	private static readonly Color color_7 = Color.FromArgb(50, 205, 50);

	private static readonly Color color_8 = Color.FromArgb(255, 165, 0);

	private static readonly Color color_9 = Color.FromArgb(255, 215, 0);

	private PCKArchiveManager pckarchiveManager_0;

	private string string_0 = Class16.smethod_0(1648927580);

	private bool bool_0;

	private CancellationTokenSource cancellationTokenSource_0;

	private Dictionary<string, HashSet<string>> dictionary_0 = new Dictionary<string, HashSet<string>>();

	private Dictionary<string, List<Class340>> dictionary_1 = new Dictionary<string, List<Class340>>();

	private static Bitmap bitmap_0;

	private static Bitmap bitmap_1;

	private IContainer icontainer_0;

	private Panel panel_0;

	private Panel panel_1;

	private Panel panel_2;

	private Panel panel_3;

	private Button button_0;

	private Button button_1;

	private Button button_2;

	private Button button_3;

	private Button button_4;

	private Button button_5;

	private Panel panel_4;

	private Button button_6;

	private TextBox textBox_0;

	private Button button_7;

	private TextBox textBox_1;

	private Label label_0;

	private Panel panel_5;

	private Button button_8;

	private Label label_1;

	private Panel panel_6;

	private Label label_2;

	private Label label_3;

	private ProgressBar progressBar_0;

	private Label label_4;

	private DataGridView dataGridView_0;

	private DataGridViewImageColumn dataGridViewImageColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private TextBox textBox_2;

	private int int_0 = -1;

	private EventHandler<string> eventHandler_0;

	private Button button_9;

	private Button button_10;

	private Panel panel_7;

	public event EventHandler<string> OpenedNewFile
	{
		[CompilerGenerated]
		add
		{
			EventHandler<string> eventHandler = eventHandler_0;
			EventHandler<string> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<string> value2 = (EventHandler<string>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<string> eventHandler = eventHandler_0;
			EventHandler<string> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<string> value2 = (EventHandler<string>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public PCKEditorForm()
	{
		method_4();
		method_32();
		TDark.StoreOriginalColors(this);
		TDark.ApplyThemeToForm(this);
		TextStorage.TEXTS.SetFormLanguage(this);
		base.Activated += PCKEditorForm_Activated;
		method_1();
		method_2();
		method_0();
		dataGridView_0.DataError += Class344.class344_0.method_0;
		dataGridView_0.CellFormatting += dataGridView_0_CellFormatting;
		dataGridView_0.CellPainting += dataGridView_0_CellPainting;
	}

	public PCKEditorForm(string filePath)
		: this()
	{
		if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
		{
			method_3(filePath);
		}
	}

	private void method_0()
	{
		textBox_0.Text = Class16.smethod_0(1649196200);
		textBox_0.ForeColor = (TDark.IsDarkMode ? color_5 : Color.FromArgb(140, 140, 140));
		textBox_0.GotFocus += textBox_0_GotFocus;
		textBox_0.LostFocus += textBox_0_LostFocus;
	}

	private void method_1()
	{
		if (TDark.IsDarkMode)
		{
			dataGridView_0.DefaultCellStyle = new DataGridViewCellStyle
			{
				BackColor = color_0,
				ForeColor = color_4,
				SelectionBackColor = color_6,
				SelectionForeColor = color_4,
				Padding = new Padding(2)
			};
			dataGridView_0.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
			{
				BackColor = Color.FromArgb(35, 35, 35),
				ForeColor = color_4,
				SelectionBackColor = color_6,
				SelectionForeColor = color_4
			};
			dataGridView_0.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
			{
				BackColor = Color.FromArgb(45, 45, 48),
				ForeColor = Color.FromArgb(220, 220, 220),
				Alignment = DataGridViewContentAlignment.MiddleLeft,
				Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular),
				Padding = new Padding(4, 0, 0, 0)
			};
			dataGridView_0.ColumnHeadersHeight = 26;
			dataGridView_0.RowTemplate.Height = 22;
			dataGridViewTextBoxColumn_2.DefaultCellStyle = new DataGridViewCellStyle
			{
				Alignment = DataGridViewContentAlignment.MiddleRight
			};
			dataGridViewTextBoxColumn_3.DefaultCellStyle = new DataGridViewCellStyle
			{
				Alignment = DataGridViewContentAlignment.MiddleRight
			};
		}
	}

	private void method_2()
	{
		foreach (Control control in panel_0.Controls)
		{
			if (control is Button { Tag: string tag } button)
			{
				string[] array = tag.Split('|');
				if (array.Length >= 3)
				{
					Class345 @class = new Class345();
					@class.string_0 = array[0];
					@class.string_1 = array[1];
					@class.color_0 = Color.FromName(array[2]);
					button.Paint += @class.method_0;
				}
			}
		}
	}

	private void method_3(string string_1)
	{
		try
		{
			pckarchiveManager_0?.Dispose();
			pckarchiveManager_0 = new PCKArchiveManager();
			pckarchiveManager_0.OnProgress += method_11;
			if (pckarchiveManager_0.Open(string_1))
			{
				Text = Class16.smethod_0(1649196243) + System.IO.Path.GetFileName(string_1);
				label_4.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649196271), Class16.smethod_0(1649196280)), System.IO.Path.GetFileName(string_1));
				method_27(bool_1: true);
				method_7();
				string_0 = Class16.smethod_0(1648927580);
				method_8();
				method_34(string_1);
			}
			else
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649196298)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649196320));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649196352), Class16.smethod_0(1649014988)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void dataGridView_0_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		Class342 @class = new Class342();
		@class.pckeditorForm_0 = this;
		if (e.ColumnIndex == dataGridViewImageColumn_0.Index && e.Value is Image image)
		{
			try
			{
				_ = image.Width;
			}
			catch
			{
				Image value = smethod_4();
				e.Value = value;
				@class.int_0 = e.RowIndex;
				@class.int_1 = dataGridViewImageColumn_0.Index;
				BeginInvoke(new Action(@class.method_0));
			}
		}
	}

	private void dataGridView_0_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
	{
		if (e.RowIndex < 0 || e.ColumnIndex != dataGridViewImageColumn_0.Index)
		{
			return;
		}
		DataGridViewCell dataGridViewCell = dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex];
		if (!(dataGridViewCell.Value is Image image))
		{
			return;
		}
		try
		{
			_ = image.Width;
		}
		catch
		{
			dataGridViewCell.Value = smethod_4();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		if (disposing)
		{
			pckarchiveManager_0?.Dispose();
			bitmap_0?.Dispose();
			bitmap_0 = null;
			bitmap_1?.Dispose();
			bitmap_1 = null;
		}
		base.Dispose(disposing);
	}

	private void method_4()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		new ComponentResourceManager(typeof(PCKEditorForm));
		panel_0 = new Panel();
		panel_3 = new Panel();
		panel_2 = new Panel();
		panel_1 = new Panel();
		button_0 = new Button();
		button_1 = new Button();
		button_2 = new Button();
		button_3 = new Button();
		button_4 = new Button();
		button_5 = new Button();
		panel_4 = new Panel();
		button_6 = new Button();
		textBox_0 = new TextBox();
		button_7 = new Button();
		textBox_1 = new TextBox();
		label_0 = new Label();
		panel_5 = new Panel();
		button_8 = new Button();
		label_1 = new Label();
		panel_6 = new Panel();
		label_2 = new Label();
		label_3 = new Label();
		progressBar_0 = new ProgressBar();
		label_4 = new Label();
		dataGridView_0 = new DataGridView();
		dataGridViewImageColumn_0 = new DataGridViewImageColumn();
		dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		panel_0.SuspendLayout();
		panel_4.SuspendLayout();
		panel_5.SuspendLayout();
		panel_6.SuspendLayout();
		((ISupportInitialize)dataGridView_0).BeginInit();
		SuspendLayout();
		panel_0.BackColor = SystemColors.Control;
		panel_0.Controls.Add(panel_3);
		panel_0.Controls.Add(panel_2);
		panel_0.Controls.Add(panel_1);
		panel_0.Controls.Add(button_0);
		panel_0.Controls.Add(button_1);
		panel_0.Controls.Add(button_2);
		panel_0.Controls.Add(button_3);
		panel_0.Controls.Add(button_4);
		panel_0.Controls.Add(button_5);
		panel_0.Dock = DockStyle.Top;
		panel_0.Location = new Point(0, 0);
		panel_0.Name = Class16.smethod_0(1649196389);
		panel_0.Padding = new Padding(4);
		panel_0.Size = new Size(843, 61);
		panel_0.TabIndex = 0;
		panel_3.BackColor = SystemColors.ControlDark;
		panel_3.Location = new Point(357, 9);
		panel_3.Name = Class16.smethod_0(1649196400);
		panel_3.Size = new Size(1, 43);
		panel_3.TabIndex = 12;
		panel_2.BackColor = SystemColors.ControlDark;
		panel_2.Location = new Point(154, 9);
		panel_2.Name = Class16.smethod_0(1649196424);
		panel_2.Size = new Size(1, 43);
		panel_2.TabIndex = 11;
		panel_1.BackColor = SystemColors.ControlDark;
		panel_1.Location = new Point(81, 9);
		panel_1.Name = Class16.smethod_0(1649196448);
		panel_1.Size = new Size(1, 43);
		panel_1.TabIndex = 10;
		button_0.BackColor = SystemColors.Control;
		button_0.Cursor = Cursors.Hand;
		button_0.Enabled = false;
		button_0.FlatAppearance.BorderColor = SystemColors.ControlDark;
		button_0.FlatAppearance.BorderSize = 0;
		button_0.FlatAppearance.MouseOverBackColor = SystemColors.ControlLight;
		button_0.FlatStyle = FlatStyle.Flat;
		button_0.ForeColor = SystemColors.ControlText;
		button_0.Location = new Point(439, 4);
		button_0.Name = Class16.smethod_0(1648995798);
		button_0.Size = new Size(56, 52);
		button_0.TabIndex = 5;
		button_0.Tag = Class16.smethod_0(1649196472);
		button_0.UseVisualStyleBackColor = false;
		button_0.Click += button_0_Click;
		button_1.BackColor = SystemColors.Control;
		button_1.Cursor = Cursors.Hand;
		button_1.FlatAppearance.BorderColor = SystemColors.ControlDark;
		button_1.FlatAppearance.BorderSize = 0;
		button_1.FlatAppearance.MouseOverBackColor = SystemColors.ControlLight;
		button_1.FlatStyle = FlatStyle.Flat;
		button_1.ForeColor = SystemColors.ControlText;
		button_1.Location = new Point(364, 4);
		button_1.Name = Class16.smethod_0(1649196515);
		button_1.Size = new Size(69, 52);
		button_1.TabIndex = 4;
		button_1.Tag = Class16.smethod_0(1649196542);
		button_1.UseVisualStyleBackColor = false;
		button_1.Click += button_1_Click;
		button_2.BackColor = SystemColors.Control;
		button_2.Cursor = Cursors.Hand;
		button_2.Enabled = false;
		button_2.FlatAppearance.BorderColor = SystemColors.ControlDark;
		button_2.FlatAppearance.BorderSize = 0;
		button_2.FlatAppearance.MouseOverBackColor = SystemColors.ControlLight;
		button_2.FlatStyle = FlatStyle.Flat;
		button_2.ForeColor = SystemColors.ControlText;
		button_2.Location = new Point(236, 4);
		button_2.Name = Class16.smethod_0(1649195547);
		button_2.Size = new Size(116, 52);
		button_2.TabIndex = 3;
		button_2.Tag = Class16.smethod_0(1649195575);
		button_2.UseVisualStyleBackColor = false;
		button_2.Click += button_2_Click;
		button_3.BackColor = SystemColors.Control;
		button_3.Cursor = Cursors.Hand;
		button_3.Enabled = false;
		button_3.FlatAppearance.BorderColor = SystemColors.ControlDark;
		button_3.FlatAppearance.BorderSize = 0;
		button_3.FlatAppearance.MouseOverBackColor = SystemColors.ControlLight;
		button_3.FlatStyle = FlatStyle.Flat;
		button_3.ForeColor = SystemColors.ControlText;
		button_3.Location = new Point(161, 4);
		button_3.Name = Class16.smethod_0(1649195634);
		button_3.Size = new Size(69, 52);
		button_3.TabIndex = 2;
		button_3.Tag = Class16.smethod_0(1649195650);
		button_3.UseVisualStyleBackColor = false;
		button_3.Click += button_3_Click;
		button_4.BackColor = SystemColors.Control;
		button_4.Cursor = Cursors.Hand;
		button_4.Enabled = false;
		button_4.FlatAppearance.BorderColor = SystemColors.ControlDark;
		button_4.FlatAppearance.BorderSize = 0;
		button_4.FlatAppearance.MouseOverBackColor = SystemColors.ControlLight;
		button_4.FlatStyle = FlatStyle.Flat;
		button_4.ForeColor = SystemColors.ControlText;
		button_4.Location = new Point(88, 4);
		button_4.Name = Class16.smethod_0(1649195699);
		button_4.Size = new Size(60, 52);
		button_4.TabIndex = 1;
		button_4.Tag = Class16.smethod_0(1649195713);
		button_4.UseVisualStyleBackColor = false;
		button_4.Click += button_4_Click;
		button_5.BackColor = SystemColors.Control;
		button_5.Cursor = Cursors.Hand;
		button_5.FlatAppearance.BorderColor = SystemColors.ControlDark;
		button_5.FlatAppearance.BorderSize = 0;
		button_5.FlatAppearance.MouseOverBackColor = SystemColors.ControlLight;
		button_5.FlatStyle = FlatStyle.Flat;
		button_5.ForeColor = SystemColors.ControlText;
		button_5.Location = new Point(7, 4);
		button_5.Name = Class16.smethod_0(1649195764);
		button_5.Size = new Size(69, 52);
		button_5.TabIndex = 0;
		button_5.Tag = Class16.smethod_0(1649195770);
		button_5.UseVisualStyleBackColor = false;
		button_5.Click += button_5_Click;
		panel_4.BackColor = Color.FromArgb(232, 240, 249);
		panel_4.Controls.Add(button_6);
		panel_4.Controls.Add(textBox_0);
		panel_4.Controls.Add(button_7);
		panel_4.Controls.Add(textBox_1);
		panel_4.Controls.Add(label_0);
		panel_4.Dock = DockStyle.Top;
		panel_4.Location = new Point(0, 61);
		panel_4.Name = Class16.smethod_0(1649195823);
		panel_4.Padding = new Padding(13, 9, 13, 9);
		panel_4.Size = new Size(843, 38);
		panel_4.TabIndex = 1;
		button_6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_6.BackColor = Color.White;
		button_6.FlatAppearance.BorderColor = Color.FromArgb(200, 212, 230);
		button_6.FlatStyle = FlatStyle.Flat;
		button_6.Font = new Font(Class16.smethod_0(1649196708), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		button_6.ForeColor = Color.FromArgb(32, 32, 32);
		button_6.Location = new Point(603, 7);
		button_6.Margin = new Padding(0);
		button_6.Name = Class16.smethod_0(1649195839);
		button_6.Size = new Size(24, 24);
		button_6.TabIndex = 3;
		button_6.Text = Class16.smethod_0(1649195851);
		button_6.UseVisualStyleBackColor = false;
		textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		textBox_0.BackColor = Color.White;
		textBox_0.BorderStyle = BorderStyle.FixedSingle;
		textBox_0.ForeColor = Color.FromArgb(48, 48, 48);
		textBox_0.Location = new Point(630, 8);
		textBox_0.Name = Class16.smethod_0(1648995997);
		textBox_0.Size = new Size(200, 20);
		textBox_0.TabIndex = 4;
		textBox_0.TextChanged += textBox_0_TextChanged;
		textBox_0.KeyDown += textBox_0_KeyDown;
		button_7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_7.BackColor = Color.White;
		button_7.FlatAppearance.BorderColor = Color.FromArgb(200, 212, 230);
		button_7.FlatStyle = FlatStyle.Flat;
		button_7.Font = new Font(Class16.smethod_0(1649196708), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		button_7.ForeColor = Color.FromArgb(32, 32, 32);
		button_7.Location = new Point(572, 7);
		button_7.Name = Class16.smethod_0(1649195870);
		button_7.Size = new Size(28, 24);
		button_7.TabIndex = 2;
		button_7.Text = Class16.smethod_0(1649195884);
		button_7.UseVisualStyleBackColor = false;
		button_7.Click += button_7_Click;
		textBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_1.BackColor = Color.White;
		textBox_1.BorderStyle = BorderStyle.FixedSingle;
		textBox_1.ForeColor = Color.FromArgb(32, 32, 32);
		textBox_1.Location = new Point(64, 9);
		textBox_1.Name = Class16.smethod_0(1649195895);
		textBox_1.Size = new Size(527, 20);
		textBox_1.TabIndex = 1;
		textBox_1.KeyDown += textBox_1_KeyDown;
		label_0.AutoSize = true;
		label_0.ForeColor = Color.FromArgb(32, 32, 32);
		label_0.Location = new Point(10, 12);
		label_0.Name = Class16.smethod_0(1648893046);
		label_0.Size = new Size(51, 13);
		label_0.TabIndex = 0;
		label_0.Text = Class16.smethod_0(1649195909);
		panel_5.BackColor = Color.FromArgb(232, 240, 249);
		panel_5.Controls.Add(button_8);
		panel_5.Controls.Add(label_1);
		panel_5.Dock = DockStyle.Top;
		panel_5.Location = new Point(0, 99);
		panel_5.Name = Class16.smethod_0(1649195926);
		panel_5.Padding = new Padding(13, 4, 13, 4);
		panel_5.Size = new Size(843, 28);
		panel_5.TabIndex = 2;
		panel_5.Visible = false;
		button_8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_8.BackColor = Color.FromArgb(232, 240, 249);
		button_8.FlatAppearance.BorderColor = Color.FromArgb(200, 212, 230);
		button_8.FlatStyle = FlatStyle.Flat;
		button_8.ForeColor = Color.FromArgb(32, 32, 32);
		button_8.Location = new Point(745, 3);
		button_8.Name = Class16.smethod_0(1649195951);
		button_8.Size = new Size(86, 21);
		button_8.TabIndex = 1;
		button_8.Text = Class16.smethod_0(1649195972);
		button_8.UseVisualStyleBackColor = false;
		button_8.Click += button_8_Click;
		label_1.AutoSize = true;
		label_1.ForeColor = Color.FromArgb(86, 156, 214);
		label_1.Location = new Point(10, 8);
		label_1.Name = Class16.smethod_0(1649195991);
		label_1.Size = new Size(0, 13);
		label_1.TabIndex = 0;
		panel_6.BackColor = Color.FromArgb(232, 240, 249);
		panel_6.Controls.Add(label_2);
		panel_6.Controls.Add(label_3);
		panel_6.Controls.Add(progressBar_0);
		panel_6.Controls.Add(label_4);
		panel_6.Dock = DockStyle.Bottom;
		panel_6.Location = new Point(0, 554);
		panel_6.Name = Class16.smethod_0(1649196014);
		panel_6.Size = new Size(843, 19);
		panel_6.TabIndex = 3;
		label_2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		label_2.AutoSize = true;
		label_2.ForeColor = Color.FromArgb(64, 64, 64);
		label_2.Location = new Point(729, 3);
		label_2.Name = Class16.smethod_0(1648998884);
		label_2.Size = new Size(42, 13);
		label_2.TabIndex = 3;
		label_2.Text = Class16.smethod_0(1649196024);
		label_3.AutoSize = true;
		label_3.ForeColor = Color.FromArgb(64, 64, 64);
		label_3.Location = new Point(471, 3);
		label_3.Name = Class16.smethod_0(1649195023);
		label_3.Size = new Size(21, 13);
		label_3.TabIndex = 2;
		label_3.Text = Class16.smethod_0(1648919583);
		label_3.Visible = false;
		progressBar_0.Location = new Point(214, 3);
		progressBar_0.Name = Class16.smethod_0(1648993093);
		progressBar_0.Size = new Size(252, 14);
		progressBar_0.TabIndex = 1;
		progressBar_0.Visible = false;
		label_4.AutoSize = true;
		label_4.Font = new Font(Class16.smethod_0(1648942905), 9f);
		label_4.ForeColor = Color.FromArgb(32, 32, 32);
		label_4.Location = new Point(7, 3);
		label_4.Name = Class16.smethod_0(1648916149);
		label_4.Size = new Size(74, 15);
		label_4.TabIndex = 0;
		label_4.Text = Class16.smethod_0(1649195045);
		dataGridView_0.AllowDrop = true;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.AllowUserToResizeRows = false;
		dataGridViewCellStyle.BackColor = Color.FromArgb(245, 245, 248);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridView_0.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
		dataGridView_0.BackgroundColor = SystemColors.Window;
		dataGridView_0.BorderStyle = BorderStyle.None;
		dataGridView_0.CellBorderStyle = DataGridViewCellBorderStyle.None;
		dataGridView_0.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(240, 244, 250);
		dataGridViewCellStyle2.Font = new Font(Class16.smethod_0(1648942905), 8f);
		dataGridViewCellStyle2.ForeColor = Color.FromArgb(32, 32, 32);
		dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(214, 228, 247);
		dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(32, 32, 32);
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dataGridView_0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dataGridView_0.ColumnHeadersHeight = 26;
		dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		dataGridView_0.Columns.AddRange(dataGridViewImageColumn_0, dataGridViewTextBoxColumn_0, dataGridViewTextBoxColumn_1, dataGridViewTextBoxColumn_2, dataGridViewTextBoxColumn_3);
		dataGridView_0.Cursor = Cursors.Hand;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle3.BackColor = SystemColors.Window;
		dataGridViewCellStyle3.Font = new Font(Class16.smethod_0(1648942905), 8.5f);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
		dataGridView_0.DefaultCellStyle = dataGridViewCellStyle3;
		dataGridView_0.Dock = DockStyle.Fill;
		dataGridView_0.EnableHeadersVisualStyles = false;
		dataGridView_0.GridColor = SystemColors.InactiveBorder;
		dataGridView_0.Location = new Point(0, 127);
		dataGridView_0.Name = Class16.smethod_0(1649195064);
		dataGridView_0.ReadOnly = true;
		dataGridView_0.RowHeadersVisible = false;
		dataGridViewCellStyle4.BackColor = SystemColors.Window;
		dataGridViewCellStyle4.Font = new Font(Class16.smethod_0(1648942905), 8.5f);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridView_0.RowsDefaultCellStyle = dataGridViewCellStyle4;
		dataGridView_0.RowTemplate.Height = 24;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dataGridView_0.Size = new Size(843, 427);
		dataGridView_0.TabIndex = 4;
		dataGridView_0.CellDoubleClick += dataGridView_0_CellDoubleClick;
		dataGridView_0.DragDrop += dataGridView_0_DragDrop;
		dataGridView_0.DragEnter += dataGridView_0_DragEnter;
		dataGridView_0.MouseClick += dataGridView_0_MouseClick;
		dataGridViewImageColumn_0.HeaderText = string.Empty;
		dataGridViewImageColumn_0.ImageLayout = DataGridViewImageCellLayout.Zoom;
		dataGridViewImageColumn_0.Name = Class16.smethod_0(1649195087);
		dataGridViewImageColumn_0.ReadOnly = true;
		dataGridViewImageColumn_0.Resizable = DataGridViewTriState.False;
		dataGridViewImageColumn_0.Width = 30;
		dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1648936731);
		dataGridViewTextBoxColumn_0.MinimumWidth = 200;
		dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1649195101);
		dataGridViewTextBoxColumn_0.ReadOnly = true;
		dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1648936875);
		dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1649195107);
		dataGridViewTextBoxColumn_1.ReadOnly = true;
		dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1648980967);
		dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1649195121);
		dataGridViewTextBoxColumn_2.ReadOnly = true;
		dataGridViewTextBoxColumn_3.HeaderText = Class16.smethod_0(1649195143);
		dataGridViewTextBoxColumn_3.Name = Class16.smethod_0(1649195152);
		dataGridViewTextBoxColumn_3.ReadOnly = true;
		AllowDrop = true;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.ClientSize = new Size(843, 573);
		base.Controls.Add(dataGridView_0);
		base.Controls.Add(panel_6);
		base.Controls.Add(panel_5);
		base.Controls.Add(panel_4);
		base.Controls.Add(panel_0);
		ForeColor = Color.FromArgb(32, 32, 32);
		base.Icon = Resources.pckmodule_1;
		MinimumSize = new Size(688, 439);
		base.Name = Class16.smethod_0(1649195180);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649195192);
		base.FormClosing += PCKEditorForm_FormClosing;
		base.DragDrop += PCKEditorForm_DragDrop;
		base.DragEnter += PCKEditorForm_DragEnter;
		panel_0.ResumeLayout(performLayout: false);
		panel_4.ResumeLayout(performLayout: false);
		panel_4.PerformLayout();
		panel_5.ResumeLayout(performLayout: false);
		panel_5.PerformLayout();
		panel_6.ResumeLayout(performLayout: false);
		panel_6.PerformLayout();
		((ISupportInitialize)dataGridView_0).EndInit();
		ResumeLayout(performLayout: false);
	}

	private bool method_5()
	{
		if (!base.IsDisposed && !base.Disposing && dataGridView_0 != null && !dataGridView_0.IsDisposed)
		{
			return dataGridView_0.Columns.Count > 0;
		}
		return false;
	}

	private bool method_6()
	{
		if (!base.IsDisposed && !base.Disposing && base.IsHandleCreated && dataGridView_0 != null)
		{
			return !dataGridView_0.IsDisposed;
		}
		return false;
	}

	private void method_7()
	{
		dictionary_0.Clear();
		dictionary_1.Clear();
		if (pckarchiveManager_0?.Pck?.Pck == null)
		{
			return;
		}
		PCK.PCK_FILE_TABLE_ENTRY[] fileTable = pckarchiveManager_0.Pck.Pck.FileTable;
		if (fileTable == null)
		{
			return;
		}
		for (int i = 0; i < fileTable.Length; i++)
		{
			PCK.PCK_FILE_TABLE_ENTRY pCK_FILE_TABLE_ENTRY = fileTable[i];
			string filePath = pCK_FILE_TABLE_ENTRY.FilePath;
			if (string.IsNullOrEmpty(filePath))
			{
				continue;
			}
			filePath = filePath.Replace('/', '\\');
			if (!filePath.StartsWith(Class16.smethod_0(1648927580)))
			{
				filePath = Class16.smethod_0(1648927580) + filePath;
			}
			string[] array = filePath.Split(new char[1] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length == 0)
			{
				continue;
			}
			string text = Class16.smethod_0(1648927580);
			for (int j = 0; j < array.Length - 1; j++)
			{
				if (!dictionary_0.ContainsKey(text))
				{
					dictionary_0[text] = new HashSet<string>();
				}
				dictionary_0[text].Add(array[j]);
				text = text + array[j] + Class16.smethod_0(1648927580);
			}
			string text2 = Class16.smethod_0(1648927580) + string.Join(Class16.smethod_0(1648927580), array.Take(array.Length - 1));
			text2 = ((array.Length != 1) ? (text2 + Class16.smethod_0(1648927580)) : Class16.smethod_0(1648927580));
			if (!dictionary_1.ContainsKey(text2))
			{
				dictionary_1[text2] = new List<Class340>();
			}
			List<Class340> list = dictionary_1[text2];
			Class340 @class = new Class340();
			@class.method_1(filePath);
			@class.method_3(array.Last());
			@class.method_5(pCK_FILE_TABLE_ENTRY.OriginalSize);
			@class.method_7(pCK_FILE_TABLE_ENTRY.CompressedSize);
			@class.method_9(i);
			list.Add(@class);
		}
		method_29();
	}

	private void method_8()
	{
		if (!method_5())
		{
			return;
		}
		dataGridView_0.SuspendLayout();
		try
		{
			dataGridView_0.Rows.Clear();
			dataGridView_0.Rows.Add(smethod_2(), Class16.smethod_0(1648924410), string.Empty, string.Empty, string.Empty);
			if (dictionary_0.ContainsKey(string_0))
			{
				foreach (string item in dictionary_0[string_0].OrderBy(Class344.class344_0.method_1))
				{
					dataGridView_0.Rows.Add(smethod_2(), item, Class16.smethod_0(1649195209), string.Empty, string.Empty);
				}
			}
			if (dictionary_1.ContainsKey(string_0))
			{
				foreach (Class340 item2 in dictionary_1[string_0].OrderBy(Class344.class344_0.method_2))
				{
					string text = smethod_5(item2.method_2());
					dataGridView_0.Rows.Add(smethod_4(), item2.method_2(), text, smethod_6(item2.method_4()), smethod_6(item2.method_6()));
				}
			}
			if (textBox_1 != null && !textBox_1.IsDisposed)
			{
				textBox_1.Text = string_0;
			}
		}
		finally
		{
			if (method_5())
			{
				dataGridView_0.ResumeLayout();
			}
		}
	}

	private void method_9(string string_1)
	{
		if (!string.IsNullOrEmpty(string_1) && !(string_1 == Class16.smethod_0(1649196200)))
		{
			if (!method_5())
			{
				return;
			}
			bool_0 = true;
			panel_5.Visible = true;
			dataGridView_0.SuspendLayout();
			try
			{
				dataGridView_0.Rows.Clear();
				List<(string, string, string, uint, uint)> list = new List<(string, string, string, uint, uint)>();
				foreach (KeyValuePair<string, List<Class340>> item in dictionary_1)
				{
					foreach (Class340 item2 in item.Value)
					{
						if (item2.method_2().IndexOf(string_1, StringComparison.OrdinalIgnoreCase) >= 0)
						{
							list.Add((item2.method_0(), item2.method_0(), smethod_5(item2.method_2()), item2.method_4(), item2.method_6()));
						}
					}
				}
				foreach (KeyValuePair<string, HashSet<string>> item3 in dictionary_0)
				{
					foreach (string item4 in item3.Value)
					{
						if (item4.IndexOf(string_1, StringComparison.OrdinalIgnoreCase) >= 0)
						{
							string text = item3.Key + item4;
							list.Add((text, text, Class16.smethod_0(1649195209), 0u, 0u));
						}
					}
				}
				label_1.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649195230), Class16.smethod_0(1649195251)), list.Count, string_1);
				foreach (var item5 in list.Take(1000))
				{
					Image image = ((item5.Item3 == Class16.smethod_0(1649195209)) ? smethod_2() : smethod_4());
					dataGridView_0.Rows.Add(image, item5.Item2, item5.Item3, (item5.Item4 != 0) ? smethod_6(item5.Item4) : string.Empty, (item5.Item5 != 0) ? smethod_6(item5.Item5) : string.Empty);
				}
				return;
			}
			finally
			{
				if (method_5())
				{
					dataGridView_0.ResumeLayout();
				}
			}
		}
		method_10();
	}

	private void method_10()
	{
		bool_0 = false;
		panel_5.Visible = false;
		if (textBox_0.Text != Class16.smethod_0(1649196200))
		{
			textBox_0.Text = Class16.smethod_0(1649196200);
			textBox_0.ForeColor = color_5;
		}
		method_8();
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		try
		{
			openFileDialog.Filter = Class16.smethod_0(1649195295);
			openFileDialog.Title = TextStorage.Msg(Class16.smethod_0(1649195325));
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				method_3(openFileDialog.FileName);
			}
		}
		finally
		{
			((IDisposable)openFileDialog).Dispose();
		}
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		if (pckarchiveManager_0 == null || !pckarchiveManager_0.IsLoaded || !CommonStorage.License.IsValid())
		{
			return;
		}
		try
		{
			if (pckarchiveManager_0.Save())
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649195338)), TextStorage.Msg(Class16.smethod_0(1649020587)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649195361)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649195391));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649195417), Class16.smethod_0(1649195440)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private async void button_3_Click(object sender, EventArgs e)
	{
		if (pckarchiveManager_0 == null || !pckarchiveManager_0.IsLoaded)
		{
			return;
		}
		cancellationTokenSource_0 = new CancellationTokenSource();
		method_28(bool_1: false);
		try
		{
			if (await pckarchiveManager_0.DefragAsync(cancellationTokenSource_0.Token))
			{
				method_7();
				method_8();
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649196848)), TextStorage.Msg(Class16.smethod_0(1649020587)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649196874));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649196918), Class16.smethod_0(1649196941)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
			method_28(bool_1: true);
		}
	}

	private async void button_2_Click(object sender, EventArgs e)
	{
		if (pckarchiveManager_0 == null || !pckarchiveManager_0.IsLoaded)
		{
			return;
		}
		DialogResult dialogResult = DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649196965)), TextStorage.Msg(Class16.smethod_0(1649196987)), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (dialogResult != DialogResult.Yes)
		{
			return;
		}
		cancellationTokenSource_0 = new CancellationTokenSource();
		method_28(bool_1: false);
		try
		{
			if (await pckarchiveManager_0.FullDefragAsync(cancellationTokenSource_0.Token))
			{
				method_7();
				method_8();
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649196848)), TextStorage.Msg(Class16.smethod_0(1649020587)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649197023));
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649196039)) + Class16.smethod_0(1648908709) + ex.Message, TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
			method_28(bool_1: true);
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		try
		{
			saveFileDialog.Filter = Class16.smethod_0(1649195295);
			saveFileDialog.Title = TextStorage.Msg(Class16.smethod_0(1649195464));
			if (saveFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			try
			{
				pckarchiveManager_0?.Dispose();
				pckarchiveManager_0 = new PCKArchiveManager();
				pckarchiveManager_0.OnProgress += method_11;
				DialogResult dialogResult = DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649195495)), TextStorage.Msg(Class16.smethod_0(1649195507)), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				ArchiveVersion version = ((dialogResult == DialogResult.Yes) ? ArchiveVersion.V3 : ArchiveVersion.V2);
				if (pckarchiveManager_0.CreateNew(saveFileDialog.FileName, version))
				{
					Text = Class16.smethod_0(1649196243) + System.IO.Path.GetFileName(saveFileDialog.FileName);
					label_4.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649190416), Class16.smethod_0(1649190434)), System.IO.Path.GetFileName(saveFileDialog.FileName));
					method_27(bool_1: true);
					method_7();
					string_0 = Class16.smethod_0(1648927580);
					method_8();
					DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649190461)), TextStorage.Msg(Class16.smethod_0(1649020587)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649190475));
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649190514)) + Class16.smethod_0(1648908709) + ex.Message, TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		finally
		{
			((IDisposable)saveFileDialog).Dispose();
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		PCKArchiveManager pCKArchiveManager = pckarchiveManager_0;
		if (pCKArchiveManager != null && pCKArchiveManager.HasUnsavedChanges)
		{
			switch (DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649190537)), TextStorage.Msg(Class16.smethod_0(1649002823)), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
			{
			case DialogResult.Cancel:
				return;
			case DialogResult.Yes:
				pckarchiveManager_0.Save();
				break;
			}
		}
		pckarchiveManager_0?.Close();
		pckarchiveManager_0 = null;
		method_27(bool_1: false);
		if (method_5())
		{
			dataGridView_0.Rows.Clear();
		}
		dictionary_0.Clear();
		dictionary_1.Clear();
		Text = Class16.smethod_0(1649039596);
		label_4.Text = TextStorage.Msg(Class16.smethod_0(1649190561), Class16.smethod_0(1649195045));
		label_2.Text = TextStorage.Msg(Class16.smethod_0(1649190579));
	}

	private void button_7_Click(object sender, EventArgs e)
	{
		if (bool_0)
		{
			method_10();
		}
		string_0 = Class16.smethod_0(1648927580);
		method_8();
	}

	private void button_8_Click(object sender, EventArgs e)
	{
		method_10();
	}

	private void textBox_1_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			string text = textBox_1.Text.Replace('/', '\\');
			if (!text.StartsWith(Class16.smethod_0(1648927580)))
			{
				text = Class16.smethod_0(1648927580) + text;
			}
			if (!text.EndsWith(Class16.smethod_0(1648927580)))
			{
				text += Class16.smethod_0(1648927580);
			}
			if (dictionary_0.ContainsKey(text) || dictionary_1.ContainsKey(text) || text == Class16.smethod_0(1648927580))
			{
				string_0 = text;
				method_8();
			}
			e.SuppressKeyPress = true;
		}
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		string text = textBox_0.Text;
		if (text != Class16.smethod_0(1649196200) && !string.IsNullOrEmpty(text))
		{
			method_9(text);
		}
	}

	private void textBox_0_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			method_10();
			e.SuppressKeyPress = true;
		}
	}

	private void dataGridView_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex < 0 || bool_0)
		{
			return;
		}
		DataGridViewRow dataGridViewRow = dataGridView_0.Rows[e.RowIndex];
		string text = dataGridViewRow.Cells[1].Value?.ToString();
		string text2 = dataGridViewRow.Cells[2].Value?.ToString();
		if (e.RowIndex == 0)
		{
			if (string_0 != Class16.smethod_0(1648927580))
			{
				string[] array = string_0.TrimEnd('\\').Split(new char[1] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length > 1)
				{
					string_0 = Class16.smethod_0(1648927580) + string.Join(Class16.smethod_0(1648927580), array.Take(array.Length - 1)) + Class16.smethod_0(1648927580);
				}
				else
				{
					string_0 = Class16.smethod_0(1648927580);
				}
				method_8();
			}
		}
		else if (text2 == Class16.smethod_0(1649195209))
		{
			string_0 = string_0 + text + Class16.smethod_0(1648927580);
			method_8();
		}
	}

	private void dataGridView_0_MouseClick(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			method_13(e.Location);
		}
	}

	private void dataGridView_0_DragEnter(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			e.Effect = DragDropEffects.Copy;
		}
		else
		{
			e.Effect = DragDropEffects.None;
		}
	}

	private async void dataGridView_0_DragDrop(object sender, DragEventArgs e)
	{
		if (pckarchiveManager_0 != null && pckarchiveManager_0.IsLoaded)
		{
			string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (array != null && array.Length != 0)
			{
				await method_17(array, null);
			}
		}
	}

	private void PCKEditorForm_DragEnter(object sender, DragEventArgs e)
	{
		if (!e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			return;
		}
		string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
		if (array == null || array.Length == 0)
		{
			return;
		}
		string text = System.IO.Path.GetExtension(array[0]).ToLower();
		if (text == Class16.smethod_0(1648909411))
		{
			e.Effect = DragDropEffects.Copy;
			return;
		}
		PCKArchiveManager pCKArchiveManager = pckarchiveManager_0;
		if (pCKArchiveManager != null && pCKArchiveManager.IsLoaded)
		{
			e.Effect = DragDropEffects.Copy;
		}
		else
		{
			e.Effect = DragDropEffects.None;
		}
	}

	private async void PCKEditorForm_DragDrop(object sender, DragEventArgs e)
	{
		string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
		if (array != null && array.Length != 0)
		{
			string text = System.IO.Path.GetExtension(array[0]).ToLower();
			if (text == Class16.smethod_0(1648909411))
			{
				method_3(array[0]);
			}
			else if (pckarchiveManager_0?.IsLoaded ?? false)
			{
				await method_17(array, null);
			}
		}
	}

	private void PCKEditorForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		PCKArchiveManager pCKArchiveManager = pckarchiveManager_0;
		if (pCKArchiveManager != null && pCKArchiveManager.HasUnsavedChanges)
		{
			switch (DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649190537)), TextStorage.Msg(Class16.smethod_0(1649002823)), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
			{
			case DialogResult.Cancel:
				e.Cancel = true;
				break;
			case DialogResult.Yes:
				pckarchiveManager_0.Save();
				break;
			}
		}
	}

	private void method_11(object sender, PckOperationProgressEventArgs e)
	{
		Class341 @class = new Class341();
		@class.pckeditorForm_0 = this;
		@class.pckOperationProgressEventArgs_0 = e;
		if (!method_6())
		{
			return;
		}
		if (base.InvokeRequired)
		{
			try
			{
				BeginInvoke(new Action(@class.method_0));
				return;
			}
			catch (ObjectDisposedException)
			{
				return;
			}
			catch (InvalidOperationException)
			{
				return;
			}
		}
		method_12(@class.pckOperationProgressEventArgs_0);
	}

	private void method_12(PckOperationProgressEventArgs pckOperationProgressEventArgs_0)
	{
		if (method_6() && progressBar_0 != null && !progressBar_0.IsDisposed && label_3 != null && !label_3.IsDisposed && label_4 != null && !label_4.IsDisposed)
		{
			progressBar_0.Visible = true;
			label_3.Visible = true;
			progressBar_0.Maximum = Math.Max(1, pckOperationProgressEventArgs_0.TotalCount);
			progressBar_0.Value = Math.Min(pckOperationProgressEventArgs_0.CurrentIndex, pckOperationProgressEventArgs_0.TotalCount);
			label_3.Text = string.Format(Class16.smethod_0(1649190606), pckOperationProgressEventArgs_0.ProgressPercentage);
			label_4.Text = pckOperationProgressEventArgs_0.StatusMessage;
			if (pckOperationProgressEventArgs_0.CurrentIndex >= pckOperationProgressEventArgs_0.TotalCount)
			{
				progressBar_0.Visible = false;
				label_3.Visible = false;
			}
		}
	}

	private void method_13(Point point_0)
	{
		ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
		if (TDark.IsDarkMode)
		{
			contextMenuStrip.BackColor = color_1;
			contextMenuStrip.ForeColor = color_4;
			contextMenuStrip.Renderer = new Class337();
		}
		bool flag = dataGridView_0.SelectedRows.Count > 0 && dataGridView_0.SelectedRows.Cast<DataGridViewRow>().Any(Class344.class344_0.method_3);
		ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649190620)));
		toolStripMenuItem.Click += method_36;
		contextMenuStrip.Items.Add(toolStripMenuItem);
		ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649190644)));
		toolStripMenuItem2.Click += method_37;
		contextMenuStrip.Items.Add(toolStripMenuItem2);
		contextMenuStrip.Items.Add(new ToolStripSeparator());
		ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649190669)));
		toolStripMenuItem3.Enabled = flag;
		toolStripMenuItem3.Click += method_38;
		contextMenuStrip.Items.Add(toolStripMenuItem3);
		ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649190683), Class16.smethod_0(1649190717)));
		toolStripMenuItem4.Enabled = pckarchiveManager_0?.IsLoaded ?? false;
		toolStripMenuItem4.Click += method_39;
		contextMenuStrip.Items.Add(toolStripMenuItem4);
		ToolStripMenuItem toolStripMenuItem5 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649190735)));
		toolStripMenuItem5.Enabled = flag;
		toolStripMenuItem5.Click += method_40;
		contextMenuStrip.Items.Add(toolStripMenuItem5);
		ToolStripMenuItem toolStripMenuItem6 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649190759)));
		toolStripMenuItem6.Enabled = flag && dataGridView_0.SelectedRows.Count == 1 && !bool_0;
		toolStripMenuItem6.Click += method_41;
		contextMenuStrip.Items.Add(toolStripMenuItem6);
		contextMenuStrip.Items.Add(new ToolStripSeparator());
		ToolStripMenuItem toolStripMenuItem7 = new ToolStripMenuItem(TextStorage.Msg(Class16.smethod_0(1649190780)));
		toolStripMenuItem7.Enabled = flag;
		toolStripMenuItem7.Click += method_42;
		contextMenuStrip.Items.Add(toolStripMenuItem7);
		contextMenuStrip.Show(dataGridView_0, point_0);
	}

	private async Task method_14()
	{
		if (pckarchiveManager_0 == null || !pckarchiveManager_0.IsLoaded)
		{
			return;
		}
		using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
		folderBrowserDialog.Description = TextStorage.Msg(Class16.smethod_0(1649196059));
		if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		method_28(bool_1: false);
		try
		{
			cancellationTokenSource_0 = new CancellationTokenSource();
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, List<Class340>> item in dictionary_1)
			{
				foreach (Class340 item2 in item.Value)
				{
					list.Add(item2.method_0().TrimStart('\\'));
				}
			}
			await pckarchiveManager_0.ExtractFilesAsync(list, folderBrowserDialog.SelectedPath, cancellationTokenSource_0.Token);
			DKBox.Show(string.Format(Class16.smethod_0(1648932366), TextStorage.Msg(Class16.smethod_0(1649196089)), list.Count), TextStorage.Msg(Class16.smethod_0(1649020587)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649196117));
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649196148)) + Class16.smethod_0(1648908709) + ex.Message, TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
			method_28(bool_1: true);
		}
	}

	private async Task method_15()
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Multiselect = true;
		openFileDialog.Title = TextStorage.Msg(Class16.smethod_0(1649196721));
		openFileDialog.Filter = Class16.smethod_0(1649137838);
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			await method_17(openFileDialog.FileNames, null);
		}
	}

	private async Task method_16()
	{
		using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
		folderBrowserDialog.Description = TextStorage.Msg(Class16.smethod_0(1649196824));
		if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
		{
			string[] files = Directory.GetFiles(folderBrowserDialog.SelectedPath, Class16.smethod_0(1648941528), SearchOption.AllDirectories);
			await method_17(files, folderBrowserDialog.SelectedPath);
		}
	}

	private async Task method_17(string[] string_1, string string_2)
	{
		Class338 @class = new Class338
		{
			string_0 = string_1,
			pckeditorForm_0 = this,
			string_1 = string_2
		};
		if (pckarchiveManager_0 == null || !pckarchiveManager_0.IsLoaded)
		{
			return;
		}
		method_28(bool_1: false);
		try
		{
			cancellationTokenSource_0 = new CancellationTokenSource();
			@class.int_0 = 0;
			@class.int_1 = @class.string_0.Length;
			await Task.Run((Action)@class.method_0);
			method_7();
			method_8();
			DKBox.Show(string.Format(Class16.smethod_0(1648889430), @class.int_0, TextStorage.Msg(Class16.smethod_0(1649196744))), TextStorage.Msg(Class16.smethod_0(1649020587)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649196774));
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649196812)) + Class16.smethod_0(1648908709) + ex.Message, TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
			method_28(bool_1: true);
		}
	}

	private async Task method_18()
	{
		using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
		folderBrowserDialog.Description = TextStorage.Msg(Class16.smethod_0(1649196059));
		if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		method_28(bool_1: false);
		try
		{
			List<string> list = method_26();
			cancellationTokenSource_0 = new CancellationTokenSource();
			await pckarchiveManager_0.ExtractFilesAsync(list, folderBrowserDialog.SelectedPath, cancellationTokenSource_0.Token);
			DKBox.Show(string.Format(Class16.smethod_0(1648932366), TextStorage.Msg(Class16.smethod_0(1649196089)), list.Count), TextStorage.Msg(Class16.smethod_0(1649020587)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649196172));
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649196148)) + Class16.smethod_0(1648908709) + ex.Message, TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
			method_28(bool_1: true);
		}
	}

	private void method_19()
	{
		List<string> list = method_26();
		if (list.Count > 0)
		{
			Clipboard.SetText(string.Join(Environment.NewLine, list));
		}
	}

	private void method_20()
	{
		if (dataGridView_0.SelectedRows.Count != 1)
		{
			return;
		}
		DataGridViewRow dataGridViewRow = dataGridView_0.SelectedRows[0];
		if (dataGridViewRow.Index <= 0)
		{
			return;
		}
		int_0 = dataGridViewRow.Index;
		Rectangle cellDisplayRectangle = dataGridView_0.GetCellDisplayRectangle(dataGridViewTextBoxColumn_0.Index, dataGridViewRow.Index, cutOverflow: true);
		object value = dataGridViewRow.Cells[dataGridViewTextBoxColumn_0.Index].Value;
		object obj;
		if (value == null)
		{
			obj = null;
		}
		else
		{
			obj = value.ToString();
			if (obj != null)
			{
				goto IL_008a;
			}
		}
		obj = string.Empty;
		goto IL_008a;
		IL_008a:
		string text = (string)obj;
		textBox_2 = new TextBox
		{
			Text = text,
			Location = new Point(cellDisplayRectangle.Left, cellDisplayRectangle.Top),
			Size = new Size(cellDisplayRectangle.Width, cellDisplayRectangle.Height),
			Font = dataGridView_0.Font,
			BorderStyle = BorderStyle.FixedSingle,
			BackColor = (TDark.IsDarkMode ? color_0 : SystemColors.Window),
			ForeColor = (TDark.IsDarkMode ? color_4 : SystemColors.WindowText)
		};
		textBox_2.KeyDown += textBox_2_KeyDown;
		textBox_2.LostFocus += textBox_2_LostFocus;
		dataGridView_0.Controls.Add(textBox_2);
		textBox_2.BringToFront();
		textBox_2.Focus();
		textBox_2.SelectAll();
	}

	private void textBox_2_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			e.SuppressKeyPress = true;
			method_21();
		}
		else if (e.KeyCode == Keys.Escape)
		{
			e.SuppressKeyPress = true;
			method_22();
		}
	}

	private void textBox_2_LostFocus(object sender, EventArgs e)
	{
		method_21();
	}

	private void method_21()
	{
		if (textBox_2 == null || int_0 < 0)
		{
			return;
		}
		string text = textBox_2.Text.Trim();
		int index = int_0;
		string text2 = dataGridView_0.Rows[index].Cells[dataGridViewTextBoxColumn_0.Index].Value?.ToString();
		string text3 = dataGridView_0.Rows[index].Cells[dataGridViewTextBoxColumn_1.Index].Value?.ToString();
		method_23();
		if (!string.IsNullOrEmpty(text) && !(text == text2) && pckarchiveManager_0 != null && pckarchiveManager_0.IsLoaded)
		{
			string text4 = (string_0 + text2).TrimStart('\\');
			string text5 = (string_0 + text).TrimStart('\\');
			if ((!(text3 == Class16.smethod_0(1649195209))) ? pckarchiveManager_0.RenameFile(text4, text5) : pckarchiveManager_0.RenameFolder(text4, text5))
			{
				method_7();
				method_8();
			}
			else
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649190793), Class16.smethod_0(1649190817)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
	}

	private void method_22()
	{
		method_23();
	}

	private void method_23()
	{
		if (textBox_2 != null)
		{
			textBox_2.KeyDown -= textBox_2_KeyDown;
			textBox_2.LostFocus -= textBox_2_LostFocus;
			dataGridView_0.Controls.Remove(textBox_2);
			textBox_2.Dispose();
			textBox_2 = null;
			int_0 = -1;
		}
	}

	private void method_24()
	{
		method_20();
	}

	private void method_25()
	{
		List<string> list = method_26();
		if (list.Count != 0)
		{
			DialogResult dialogResult = DKBox.Show(string.Format(Class16.smethod_0(1648932366), TextStorage.Msg(Class16.smethod_0(1649190846)), list.Count), TextStorage.Msg(Class16.smethod_0(1649190871)), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
			if (dialogResult == DialogResult.Yes)
			{
				int num = pckarchiveManager_0.RemoveFiles(list);
				method_7();
				method_8();
				DKBox.Show(string.Format(Class16.smethod_0(1648932366), TextStorage.Msg(Class16.smethod_0(1649190902)), num), TextStorage.Msg(Class16.smethod_0(1649020587)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	}

	private List<string> method_26()
	{
		List<string> list = new List<string>();
		foreach (DataGridViewRow selectedRow in dataGridView_0.SelectedRows)
		{
			if (selectedRow.Index <= 0 && !bool_0)
			{
				continue;
			}
			string text = selectedRow.Cells[1].Value?.ToString();
			string text2 = selectedRow.Cells[2].Value?.ToString();
			if (string.IsNullOrEmpty(text))
			{
				continue;
			}
			if (bool_0)
			{
				list.Add(text.TrimStart('\\'));
				continue;
			}
			string item = (string_0 + text).TrimStart('\\');
			list.Add(item);
			if (text2 == Class16.smethod_0(1649195209))
			{
				string text3 = string_0 + text + Class16.smethod_0(1648927580);
				List<string> filesInDirectory = pckarchiveManager_0.GetFilesInDirectory(text3.TrimStart('\\'));
				list.AddRange(filesInDirectory);
			}
		}
		return list.Distinct().ToList();
	}

	private void method_27(bool bool_1)
	{
		button_4.Enabled = bool_1;
		button_3.Enabled = bool_1;
		button_2.Enabled = bool_1;
		button_0.Enabled = bool_1;
		if (button_9 != null)
		{
			button_9.Enabled = bool_1;
		}
	}

	private void method_28(bool bool_1)
	{
		button_5.Enabled = bool_1;
		button_4.Enabled = bool_1 && (pckarchiveManager_0?.IsLoaded ?? false);
		button_3.Enabled = bool_1 && (pckarchiveManager_0?.IsLoaded ?? false);
		button_2.Enabled = bool_1 && (pckarchiveManager_0?.IsLoaded ?? false);
		button_1.Enabled = bool_1;
		button_0.Enabled = bool_1 && (pckarchiveManager_0?.IsLoaded ?? false);
		if (bool_1)
		{
			progressBar_0.Visible = false;
			label_3.Visible = false;
			label_4.Text = TextStorage.Msg(Class16.smethod_0(1649189888), Class16.smethod_0(1649195045));
		}
	}

	private void method_29()
	{
		int num = pckarchiveManager_0?.FileCount ?? 0;
		label_2.Text = ((num == 0) ? TextStorage.Msg(Class16.smethod_0(1649190579)) : string.Format(Class16.smethod_0(1649189916), num));
	}

	private static bool smethod_0(Bitmap bitmap_2)
	{
		try
		{
			_ = bitmap_2.Width;
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static Bitmap smethod_1()
	{
		if (bitmap_0 == null || !smethod_0(bitmap_0))
		{
			bitmap_0 = new Bitmap(Resources.folder, 16, 16);
		}
		return bitmap_0;
	}

	private static Image smethod_2()
	{
		return new Bitmap(Resources.folder, 16, 16);
	}

	private static Bitmap smethod_3()
	{
		if (bitmap_1 == null || !smethod_0(bitmap_1))
		{
			bitmap_1 = new Bitmap(Resources.file, 16, 16);
		}
		return bitmap_1;
	}

	private static Image smethod_4()
	{
		return new Bitmap(Resources.file, 16, 16);
	}

	private static string smethod_5(string string_1)
	{
		string text = System.IO.Path.GetExtension(string_1).ToLower();
		if (text != null)
		{
			int length = text.Length;
			if (length != 4)
			{
				if (length == 5 && text == Class16.smethod_0(1649090227))
				{
					goto IL_0238;
				}
			}
			else
			{
				switch (text[1])
				{
				case 'b':
					break;
				case 'c':
					if (text == Class16.smethod_0(1649143702))
					{
						goto IL_0152;
					}
					goto IL_0288;
				case 'd':
					goto IL_00e3;
				case 'e':
					if (text == Class16.smethod_0(1648906325))
					{
						return Class16.smethod_0(1649008172);
					}
					goto IL_0288;
				case 'g':
					if (text == Class16.smethod_0(1649119451))
					{
						return Class16.smethod_0(1649190019);
					}
					goto IL_0288;
				case 'i':
					if (text == Class16.smethod_0(1649189970))
					{
						goto IL_0152;
					}
					goto IL_0288;
				case 'j':
					goto IL_015d;
				case 'l':
					goto IL_0177;
				case 'm':
					if (text == Class16.smethod_0(1649189956))
					{
						goto IL_0260;
					}
					goto IL_0288;
				case 'o':
					if (text == Class16.smethod_0(1649189967))
					{
						goto IL_0260;
					}
					goto IL_0288;
				case 'p':
					goto IL_01e0;
				case 's':
					if (text == Class16.smethod_0(1648906306))
					{
						return Class16.smethod_0(1649190012);
					}
					goto IL_0288;
				case 't':
					goto IL_0214;
				case 'w':
					if (text == Class16.smethod_0(1649189937))
					{
						goto IL_0260;
					}
					goto IL_0288;
				case 'x':
					if (text == Class16.smethod_0(1649189989))
					{
						return Class16.smethod_0(1649190068);
					}
					goto IL_0288;
				default:
					goto IL_0288;
					IL_0152:
					return Class16.smethod_0(1649190034);
					IL_0260:
					return Class16.smethod_0(1649189992);
				}
				if (text == Class16.smethod_0(1649008314))
				{
					goto IL_0238;
				}
			}
		}
		goto IL_0288;
		IL_01e0:
		if (text == Class16.smethod_0(1649008311))
		{
			goto IL_0238;
		}
		goto IL_0288;
		IL_0238:
		return Class16.smethod_0(1649056363);
		IL_0177:
		if (text == Class16.smethod_0(1649189934))
		{
			goto IL_0243;
		}
		if (text == Class16.smethod_0(1648904996))
		{
			return Class16.smethod_0(1649190055);
		}
		goto IL_0288;
		IL_015d:
		if (text == Class16.smethod_0(1649008300))
		{
			goto IL_0238;
		}
		goto IL_0288;
		IL_00e3:
		if (text == Class16.smethod_0(1648904847))
		{
			goto IL_0238;
		}
		goto IL_0288;
		IL_0243:
		return Class16.smethod_0(1649023959);
		IL_0214:
		if (text == Class16.smethod_0(1648997294))
		{
			goto IL_0243;
		}
		if (text == Class16.smethod_0(1648904836))
		{
			goto IL_0238;
		}
		goto IL_0288;
		IL_0288:
		if (text.Length <= 1)
		{
			return Class16.smethod_0(1648931458);
		}
		return text.Substring(1).ToUpper();
	}

	private static string smethod_6(long long_0)
	{
		if (long_0 <= 0L)
		{
			return Class16.smethod_0(1649190078);
		}
		string[] array = new string[5]
		{
			Class16.smethod_0(1648915795),
			Class16.smethod_0(1649190080),
			Class16.smethod_0(1649190089),
			Class16.smethod_0(1649190098),
			Class16.smethod_0(1649190107)
		};
		int num = (int)Math.Floor(Math.Log(long_0) / Math.Log(1024.0));
		if (num >= array.Length)
		{
			num = array.Length - 1;
		}
		return string.Format(Class16.smethod_0(1649190124), (double)long_0 / Math.Pow(1024.0, num), array[num]);
	}

	private void method_30()
	{
		if (pckarchiveManager_0 == null || !pckarchiveManager_0.IsLoaded)
		{
			return;
		}
		(int, int, int) archiveKeys = pckarchiveManager_0.GetArchiveKeys();
		Form form = new Form();
		try
		{
			Class336 @class = new Class336();
			form.Text = TextStorage.Msg(Class16.smethod_0(1649190141), Class16.smethod_0(1649190154));
			form.Size = new Size(400, 240);
			form.StartPosition = FormStartPosition.CenterParent;
			form.FormBorderStyle = FormBorderStyle.FixedDialog;
			form.MaximizeBox = false;
			form.MinimizeBox = false;
			if (TDark.IsDarkMode)
			{
				form.BackColor = color_1;
				form.ForeColor = color_4;
			}
			Label label = new Label
			{
				Text = Class16.smethod_0(1649190183),
				Location = new Point(15, 20),
				AutoSize = true
			};
			@class.textBox_0 = new TextBox
			{
				Text = archiveKeys.Item1.ToString(),
				Location = new Point(120, 17),
				Width = 240
			};
			Label label2 = new Label
			{
				Text = Class16.smethod_0(1649190196),
				Location = new Point(15, 52),
				AutoSize = true
			};
			@class.textBox_1 = new TextBox
			{
				Text = archiveKeys.Item2.ToString(),
				Location = new Point(120, 49),
				Width = 240
			};
			Label label3 = new Label
			{
				Text = Class16.smethod_0(1649190201),
				Location = new Point(15, 84),
				AutoSize = true
			};
			@class.textBox_2 = new TextBox
			{
				Text = archiveKeys.Item3.ToString(),
				Location = new Point(120, 81),
				Width = 240
			};
			Label label4 = new Label
			{
				Text = TextStorage.Msg(Class16.smethod_0(1649190216), Class16.smethod_0(1649190233)),
				Location = new Point(15, 120),
				AutoSize = true
			};
			@class.comboBox_0 = new ComboBox
			{
				Location = new Point(120, 117),
				Width = 240,
				DropDownStyle = ComboBoxStyle.DropDownList
			};
			ComboBox.ObjectCollection items = @class.comboBox_0.Items;
			object[] items2 = new string[5]
			{
				Class16.smethod_0(1649190255),
				Class16.smethod_0(1649190270),
				Class16.smethod_0(1648994682),
				Class16.smethod_0(1649190284),
				Class16.smethod_0(1649190294)
			};
			items.AddRange(items2);
			@class.comboBox_0.SelectedIndex = 0;
			@class.comboBox_0.SelectedIndexChanged += @class.method_0;
			Button button = new Button
			{
				Text = TextStorage.Msg(Class16.smethod_0(1649190297), Class16.smethod_0(1648938905)),
				DialogResult = DialogResult.OK,
				Location = new Point(195, 160),
				Size = new Size(80, 30)
			};
			Button button2 = new Button
			{
				Text = TextStorage.Msg(Class16.smethod_0(1649005070), Class16.smethod_0(1648941799)),
				DialogResult = DialogResult.Cancel,
				Location = new Point(280, 160),
				Size = new Size(80, 30)
			};
			if (TDark.IsDarkMode)
			{
				Control[] array = new Control[3] { @class.textBox_0, @class.textBox_1, @class.textBox_2 };
				foreach (Control control in array)
				{
					control.BackColor = color_0;
					control.ForeColor = color_4;
				}
				@class.comboBox_0.BackColor = color_0;
				@class.comboBox_0.ForeColor = color_4;
				button.BackColor = color_6;
				button.ForeColor = color_4;
				button.FlatStyle = FlatStyle.Flat;
				button2.BackColor = color_2;
				button2.ForeColor = color_4;
				button2.FlatStyle = FlatStyle.Flat;
			}
			form.Controls.AddRange(new Control[10] { label, @class.textBox_0, label2, @class.textBox_1, label3, @class.textBox_2, label4, @class.comboBox_0, button, button2 });
			form.AcceptButton = button;
			form.CancelButton = button2;
			TDark.StoreOriginalColors(form);
			TDark.ApplyThemeToForm(form);
			if (form.ShowDialog(this) == DialogResult.OK)
			{
				if (int.TryParse(@class.textBox_0.Text, out var result) && int.TryParse(@class.textBox_1.Text, out var result2) && int.TryParse(@class.textBox_2.Text, out var result3))
				{
					pckarchiveManager_0.SetArchiveKeys(result, result2, result3);
					DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649190313), Class16.smethod_0(1649190336)), TextStorage.Msg(Class16.smethod_0(1649190371), Class16.smethod_0(1649141664)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649190397), Class16.smethod_0(1649189396)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}
		finally
		{
			((IDisposable)form).Dispose();
		}
	}

	private void method_31()
	{
		if (pckarchiveManager_0 == null)
		{
			return;
		}
		using Form form = new Form();
		form.Text = TextStorage.Msg(Class16.smethod_0(1649189422), Class16.smethod_0(1649189453));
		form.Size = new Size(350, 180);
		form.StartPosition = FormStartPosition.CenterParent;
		form.FormBorderStyle = FormBorderStyle.FixedDialog;
		form.MaximizeBox = false;
		form.MinimizeBox = false;
		if (TDark.IsDarkMode)
		{
			form.BackColor = color_1;
			form.ForeColor = color_4;
		}
		Label label = new Label
		{
			Text = TextStorage.Msg(Class16.smethod_0(1649189472), Class16.smethod_0(1649189508)),
			Location = new Point(15, 20),
			AutoSize = true
		};
		ComboBox comboBox = new ComboBox
		{
			Location = new Point(15, 45),
			Width = 300,
			DropDownStyle = ComboBoxStyle.DropDownList
		};
		ComboBox.ObjectCollection items = comboBox.Items;
		object[] items2 = new string[10]
		{
			Class16.smethod_0(1649189533),
			Class16.smethod_0(1649189548),
			Class16.smethod_0(1649189571),
			Class16.smethod_0(1649189597),
			Class16.smethod_0(1649189615),
			Class16.smethod_0(1649189625),
			Class16.smethod_0(1649189643),
			Class16.smethod_0(1649189669),
			Class16.smethod_0(1649189687),
			Class16.smethod_0(1649189697)
		};
		items.AddRange(items2);
		comboBox.SelectedIndex = Math.Max(0, Math.Min(9, pckarchiveManager_0.CompressionLevel));
		Button button = new Button
		{
			Text = TextStorage.Msg(Class16.smethod_0(1649190297), Class16.smethod_0(1648938905)),
			DialogResult = DialogResult.OK,
			Location = new Point(150, 100),
			Size = new Size(80, 30)
		};
		Button button2 = new Button
		{
			Text = TextStorage.Msg(Class16.smethod_0(1649005070), Class16.smethod_0(1648941799)),
			DialogResult = DialogResult.Cancel,
			Location = new Point(235, 100),
			Size = new Size(80, 30)
		};
		if (TDark.IsDarkMode)
		{
			comboBox.BackColor = color_0;
			comboBox.ForeColor = color_4;
			button.BackColor = color_6;
			button.ForeColor = color_4;
			button.FlatStyle = FlatStyle.Flat;
			button2.BackColor = color_2;
			button2.ForeColor = color_4;
			button2.FlatStyle = FlatStyle.Flat;
		}
		form.Controls.AddRange(new Control[4] { label, comboBox, button, button2 });
		form.AcceptButton = button;
		form.CancelButton = button2;
		TDark.StoreOriginalColors(form);
		TDark.ApplyThemeToForm(form);
		if (form.ShowDialog(this) == DialogResult.OK)
		{
			pckarchiveManager_0.CompressionLevel = comboBox.SelectedIndex;
		}
	}

	private void method_32()
	{
		int num = button_0.Right + 6;
		panel_7 = new Panel
		{
			BackColor = SystemColors.ControlDark,
			Location = new Point(num, 9),
			Size = new Size(1, 43),
			Name = Class16.smethod_0(1649189732)
		};
		num += 7;
		button_9 = new Button
		{
			BackColor = SystemColors.Control,
			Cursor = Cursors.Hand,
			Enabled = false,
			FlatStyle = FlatStyle.Flat,
			ForeColor = SystemColors.ControlText,
			Location = new Point(num, 4),
			Size = new Size(60, 52),
			TabIndex = 10,
			Tag = Class16.smethod_0(1649189756),
			Name = Class16.smethod_0(1649189779),
			UseVisualStyleBackColor = false
		};
		button_9.FlatAppearance.BorderSize = 0;
		button_9.FlatAppearance.BorderColor = SystemColors.ControlDark;
		button_9.FlatAppearance.MouseOverBackColor = SystemColors.ControlLight;
		button_9.Click += button_9_Click;
		num += 66;
		button_10 = new Button
		{
			BackColor = SystemColors.Control,
			Cursor = Cursors.Hand,
			FlatStyle = FlatStyle.Flat,
			ForeColor = SystemColors.ControlText,
			Location = new Point(num, 4),
			Size = new Size(80, 52),
			TabIndex = 11,
			Tag = Class16.smethod_0(1649189806),
			Name = Class16.smethod_0(1649189853),
			UseVisualStyleBackColor = false
		};
		button_10.FlatAppearance.BorderSize = 0;
		button_10.FlatAppearance.BorderColor = SystemColors.ControlDark;
		button_10.FlatAppearance.MouseOverBackColor = SystemColors.ControlLight;
		button_10.Click += button_10_Click;
		panel_0.Controls.Add(button_10);
		panel_0.Controls.Add(button_9);
		panel_0.Controls.Add(panel_7);
		method_33();
	}

	private void method_33()
	{
		Button[] array = new Button[2] { button_9, button_10 };
		foreach (Button button in array)
		{
			if (button?.Tag is string text)
			{
				string[] array2 = text.Split('|');
				if (array2.Length >= 3)
				{
					Class343 @class = new Class343();
					@class.string_0 = array2[0];
					@class.string_1 = array2[1];
					@class.color_0 = Color.FromName(array2[2]);
					button.Paint += @class.method_0;
				}
			}
		}
	}

	private void method_34(string string_1)
	{
		eventHandler_0?.Invoke(this, string_1);
	}

	private void PCKEditorForm_Activated(object sender, EventArgs e)
	{
		method_35();
	}

	private void method_35()
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_PCKEditor != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this);
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_PCKEditor = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}

	private void textBox_0_GotFocus(object sender, EventArgs e)
	{
		if (textBox_0.Text == Class16.smethod_0(1649196200))
		{
			textBox_0.Text = string.Empty;
			textBox_0.ForeColor = (TDark.IsDarkMode ? color_4 : SystemColors.WindowText);
		}
	}

	private void textBox_0_LostFocus(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(textBox_0.Text))
		{
			textBox_0.Text = Class16.smethod_0(1649196200);
			textBox_0.ForeColor = (TDark.IsDarkMode ? color_5 : Color.FromArgb(140, 140, 140));
		}
	}

	private async void method_36(object sender, EventArgs e)
	{
		await method_15();
	}

	private async void method_37(object sender, EventArgs e)
	{
		await method_16();
	}

	private async void method_38(object sender, EventArgs e)
	{
		await method_18();
	}

	private async void method_39(object sender, EventArgs e)
	{
		await method_14();
	}

	private void method_40(object sender, EventArgs e)
	{
		method_19();
	}

	private void method_41(object sender, EventArgs e)
	{
		method_20();
	}

	private void method_42(object sender, EventArgs e)
	{
		method_25();
	}

	private void button_9_Click(object sender, EventArgs e)
	{
		method_30();
	}

	private void button_10_Click(object sender, EventArgs e)
	{
		method_31();
	}
}
