using System;
using System.Windows.Forms;

namespace ACE.Classes;

internal static class ToolStripProgressBarSafe
{
	public static bool Reset(ToolStripProgressBar progressBar)
	{
		int? value = 0;
		return TrySet(progressBar, null, value);
	}

	public static bool Increment(ToolStripProgressBar progressBar, int delta = 1)
	{
		if (!smethod_0(progressBar))
		{
			return false;
		}
		try
		{
			int value = progressBar.Value + delta;
			int? value2 = value;
			return TrySet(progressBar, null, value2);
		}
		catch (ArgumentOutOfRangeException)
		{
			return false;
		}
		catch (InvalidOperationException)
		{
			return false;
		}
		catch (NullReferenceException)
		{
			return false;
		}
	}

	public static bool TrySet(ToolStripProgressBar progressBar, int? maximum = null, int? value = null, ProgressBarStyle? style = null)
	{
		if (!smethod_0(progressBar))
		{
			return false;
		}
		try
		{
			if (style.HasValue && progressBar.Style != style.Value)
			{
				progressBar.Style = style.Value;
			}
			if (maximum.HasValue)
			{
				int num = Math.Max(1, maximum.Value);
				if (progressBar.Maximum != num)
				{
					progressBar.Maximum = num;
				}
				if (progressBar.Value > progressBar.Maximum)
				{
					progressBar.Value = progressBar.Maximum;
				}
			}
			if (value.HasValue)
			{
				int value2 = Math.Min(progressBar.Maximum, Math.Max(progressBar.Minimum, value.Value));
				progressBar.Value = value2;
			}
			return true;
		}
		catch (ArgumentOutOfRangeException)
		{
			return false;
		}
		catch (ObjectDisposedException)
		{
			return false;
		}
		catch (InvalidOperationException)
		{
			return false;
		}
		catch (NullReferenceException)
		{
			return false;
		}
	}

	private static bool smethod_0(ToolStripProgressBar toolStripProgressBar_0)
	{
		if (toolStripProgressBar_0 == null)
		{
			return false;
		}
		try
		{
			ToolStrip owner = toolStripProgressBar_0.Owner;
			if (owner != null && (owner.IsDisposed || owner.Disposing))
			{
				return false;
			}
			ProgressBar progressBar = toolStripProgressBar_0.ProgressBar;
			if (progressBar != null && !progressBar.IsDisposed && !progressBar.Disposing)
			{
				return true;
			}
			return false;
		}
		catch (NullReferenceException)
		{
			return false;
		}
		catch (ObjectDisposedException)
		{
			return false;
		}
	}
}
