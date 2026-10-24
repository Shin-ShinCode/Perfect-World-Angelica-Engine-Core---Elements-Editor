using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.Classes;

public class FileBasedUndoManager : IDisposable
{
	private sealed class Class72
	{
		public Func<byte[]> func_0;

		public FileBasedUndoManager fileBasedUndoManager_0;

		public Action<byte[]> action_0;

		internal void method_0(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.Z && !e.Shift && fileBasedUndoManager_0.CanUndo)
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
				byte[] currentState = func_0();
				byte[] array = fileBasedUndoManager_0.Undo(currentState);
				if (array != null)
				{
					action_0(array);
				}
			}
			else if (e.Control && (e.KeyCode == Keys.Y || (e.KeyCode == Keys.Z && e.Shift)) && fileBasedUndoManager_0.CanRedo)
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
				byte[] currentState2 = func_0();
				byte[] array2 = fileBasedUndoManager_0.Redo(currentState2);
				if (array2 != null)
				{
					action_0(array2);
				}
			}
		}
	}

	private readonly Stack<string> stack_0 = new Stack<string>();

	private readonly Stack<string> stack_1 = new Stack<string>();

	private readonly int int_0;

	private readonly string string_0;

	private long long_0;

	private Action action_0;

	private bool bool_0;
    private readonly List<Action> detachHandlers = new List<Action>();
    private void ThrowIfDisposed()
    {
        if (bool_0) throw new ObjectDisposedException(nameof(FileBasedUndoManager));
    }

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	public bool CanUndo => stack_0.Count > 0;

	public bool CanRedo => stack_1.Count > 0;

	public int UndoCount => stack_0.Count;

	public int RedoCount => stack_1.Count;

	public FileBasedUndoManager(string editorId, int maxHistory = 50)
	{
		if (maxHistory < 1) throw new ArgumentOutOfRangeException(nameof(maxHistory));
		int_0 = maxHistory;
		string_0 = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "AngelicaCore", "Undo", Guid.NewGuid().ToString("N"));
		Directory.CreateDirectory(string_0);
		method_1();
	}

	public void SetStateChangedCallback(Action callback)
	{
		action_0 = callback;
	}

	public void PushUndo(byte[] snapshotData)
	{
        ThrowIfDisposed();
		if (snapshotData == null || snapshotData.Length == 0)
		{
			return;
		}
		string item = method_0(snapshotData);
		if (stack_0.Count >= int_0)
		{
			string[] array = stack_0.ToArray();
			stack_0.Clear();
			smethod_1(array[array.Length - 1]);
			for (int num = array.Length - 2; num >= 0; num--)
			{
				stack_0.Push(array[num]);
			}
		}
		while (stack_1.Count > 0)
		{
			smethod_1(stack_1.Pop());
		}
		stack_0.Push(item);
		action_0?.Invoke();
	}

	public byte[] Undo(byte[] currentState)
    {
        ThrowIfDisposed();
        if (stack_0.Count == 0) return null;
        // Read and persist first: an I/O failure must not consume either history.
        string path = stack_0.Peek();
        byte[] result = smethod_0(path);
        if (currentState != null) stack_1.Push(method_0(currentState));
        stack_0.Pop();
        smethod_1(path);
        action_0?.Invoke();
        return result;
    }

	public byte[] Redo(byte[] currentState)
    {
        ThrowIfDisposed();
        if (stack_1.Count == 0) return null;
        // Read and persist first: an I/O failure must not consume either history.
        string path = stack_1.Peek();
        byte[] result = smethod_0(path);
        if (currentState != null) stack_0.Push(method_0(currentState));
        stack_1.Pop();
        smethod_1(path);
        action_0?.Invoke();
        return result;
    }

	public void Clear()
	{
		while (stack_0.Count > 0)
		{
			smethod_1(stack_0.Pop());
		}
		while (stack_1.Count > 0)
		{
			smethod_1(stack_1.Pop());
		}
		action_0?.Invoke();
	}

	private string method_0(byte[] data)
    {
        string path = System.IO.Path.Combine(string_0, Interlocked.Increment(ref long_0) + ".undo");
        try
        {
            using (var file = new FileStream(path, FileMode.CreateNew, FileAccess.Write, FileShare.None))
            {
                using (var header = new BinaryWriter(file, Encoding.UTF8, true))
                {
                    header.Write(0x31445541); // AUD1: explicit format, never guess raw/compressed.
                    header.Write(data.Length);
                }
                using (var zip = new DeflateStream(file, CompressionLevel.Fastest, true))
                    zip.Write(data, 0, data.Length);
            }
            return path;
        }
        catch { smethod_1(path); throw; }
    }

	private static byte[] smethod_0(string path)
    {
        using (var file = File.OpenRead(path))
        using (var header = new BinaryReader(file, Encoding.UTF8, true))
        {
            if (header.ReadInt32() != 0x31445541) throw new InvalidDataException("Invalid undo snapshot.");
            int length = header.ReadInt32();
            if (length < 0) throw new InvalidDataException("Invalid undo snapshot length.");
            byte[] data = new byte[length];
            using (var zip = new DeflateStream(file, CompressionMode.Decompress, true))
            {
                int offset = 0;
                while (offset < length)
                {
                    int read = zip.Read(data, offset, Math.Min(81920, length - offset));
                    if (read == 0) throw new EndOfStreamException("Truncated undo snapshot.");
                    offset += read;
                }
                if (zip.ReadByte() != -1) throw new InvalidDataException("Invalid undo snapshot length.");
            }
            return data;
        }
    }

	private static void smethod_1(string string_1)
	{
		try
		{
			if (string_1 != null && File.Exists(string_1))
			{
				File.Delete(string_1);
			}
		}
		catch
		{
		}
	}

	private void method_1()
	{
		try
		{
			if (Directory.Exists(string_0))
			{
				string[] files = Directory.GetFiles(string_0, Class16.smethod_0(1648902972));
				foreach (string string_ in files)
				{
					smethod_1(string_);
				}
			}
		}
		catch
		{
		}
	}

	public void Dispose()
	{
		if (bool_0)
		{
			return;
		}
		bool_0 = true;
        foreach (var detach in detachHandlers) detach();
        detachHandlers.Clear();
        action_0 = null;
        toolStripButton_0 = null;
        toolStripButton_1 = null;
		Clear();
		try
		{
			if (Directory.Exists(string_0) && Directory.GetFiles(string_0).Length == 0 && Directory.GetDirectories(string_0).Length == 0)
			{
				Directory.Delete(string_0);
			}
		}
		catch
		{
		}
	}

	public void AttachToToolStrip(ToolStrip strip, EventHandler undoHandler, EventHandler redoHandler)
	{
		if (strip != null)
		{
			if (strip.Items[Class16.smethod_0(1648903445)] is ToolStripButton toolStripButton && strip.Items[Class16.smethod_0(1648903458)] is ToolStripButton toolStripButton2)
			{
				toolStripButton_0 = toolStripButton;
				toolStripButton_1 = toolStripButton2;
				action_0 = (Action)Delegate.Remove(action_0, new Action(method_2));
				action_0 = (Action)Delegate.Combine(action_0, new Action(method_2));
				method_2();
				return;
			}
			ToolStripButton toolStripButton3 = new ToolStripButton
			{
				Text = Class16.smethod_0(1648903487),
				ToolTipText = Class16.smethod_0(1648933841),
				DisplayStyle = ToolStripItemDisplayStyle.Image,
				Image = Resources.GShopEditor_PW_mbUndo,
				ImageTransparentColor = Color.Magenta,
				Enabled = false,
				Name = Class16.smethod_0(1648903445)
			};
			ToolStripButton toolStripButton4 = new ToolStripButton
			{
				Text = Class16.smethod_0(1648903490),
				ToolTipText = Class16.smethod_0(1648933869),
				DisplayStyle = ToolStripItemDisplayStyle.Image,
				Image = Resources.GShopEditor_PW_mbRedo,
				ImageTransparentColor = Color.Magenta,
				Enabled = false,
				Name = Class16.smethod_0(1648903458)
			};
			toolStripButton3.Click += undoHandler;
			toolStripButton4.Click += redoHandler;
            detachHandlers.Add(() => { toolStripButton3.Click -= undoHandler; toolStripButton4.Click -= redoHandler; });
			strip.Items.Insert(0, new ToolStripSeparator());
			strip.Items.Insert(0, toolStripButton4);
			strip.Items.Insert(0, toolStripButton3);
			toolStripButton_0 = toolStripButton3;
			toolStripButton_1 = toolStripButton4;
			action_0 = (Action)Delegate.Remove(action_0, new Action(method_2));
			action_0 = (Action)Delegate.Combine(action_0, new Action(method_2));
			method_2();
		}
	}

	private void method_2()
	{
		if (toolStripButton_0 != null)
		{
			toolStripButton_0.Enabled = CanUndo;
		}
		if (toolStripButton_1 != null)
		{
			toolStripButton_1.Enabled = CanRedo;
		}
	}

	public void AttachKeyboardShortcuts(Form form, Func<byte[]> captureState, Action<byte[]> restoreState)
	{
		Class72 @class = new Class72();
		@class.func_0 = captureState;
		@class.fileBasedUndoManager_0 = this;
		@class.action_0 = restoreState;
		form.KeyPreview = true;
		form.KeyDown += @class.method_0;
        detachHandlers.Add(() => form.KeyDown -= @class.method_0);
	}
}
