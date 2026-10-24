using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ACE.UIEdit;

internal static class XmlSyntaxHighlighter
{
	private static readonly Color color_0 = Color.FromArgb(86, 156, 214);

	private static readonly Color color_1 = Color.FromArgb(156, 220, 254);

	private static readonly Color color_2 = Color.FromArgb(206, 145, 120);

	private static readonly Color color_3 = Color.FromArgb(106, 153, 85);

	private static readonly Color color_4 = Color.FromArgb(128, 128, 128);

	private static readonly Color color_5 = Color.FromArgb(212, 212, 212);

	private static readonly Color color_6 = Color.FromArgb(83, 32, 32);

	private static readonly Color color_7 = Color.FromArgb(30, 30, 30);

	private static readonly Regex regex_0 = new Regex(Class16.smethod_0(1649271426), RegexOptions.Compiled);

	private static readonly Regex regex_1 = new Regex(Class16.smethod_0(1649271448), RegexOptions.Compiled);

	private static readonly Regex regex_2 = new Regex(Class16.smethod_0(1649271487), RegexOptions.Compiled);

	private static readonly Regex regex_3 = new Regex(Class16.smethod_0(1649271508), RegexOptions.Compiled);

	private static readonly Regex regex_4 = new Regex(Class16.smethod_0(1649271523), RegexOptions.Compiled);

	private static readonly Regex regex_5 = new Regex(Class16.smethod_0(1649271541), RegexOptions.Compiled);

	public static void Highlight(RichTextBox rtb, int errorLine = 0)
	{
		if (rtb == null || rtb.IsDisposed || !rtb.IsHandleCreated)
		{
			return;
		}
		string text = rtb.Text;
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		if (text.Length > 120000)
		{
			smethod_0(rtb, text, errorLine);
			return;
		}
		int selectionStart = rtb.SelectionStart;
		int selectionLength = rtb.SelectionLength;
		SendMessage(rtb.Handle, 11, IntPtr.Zero, IntPtr.Zero);
		try
		{
			rtb.SelectAll();
			rtb.SelectionColor = color_5;
			rtb.SelectionBackColor = color_7;
			foreach (Match item in regex_0.Matches(text))
			{
				rtb.Select(item.Index, item.Length);
				rtb.SelectionColor = color_3;
			}
			foreach (Match item2 in regex_1.Matches(text))
			{
				rtb.Select(item2.Index, item2.Length);
				rtb.SelectionColor = color_4;
			}
			foreach (Match item3 in regex_2.Matches(text))
			{
				rtb.Select(item3.Index, item3.Length);
				rtb.SelectionColor = color_4;
			}
			foreach (Match item4 in regex_3.Matches(text))
			{
				if (!smethod_2(text, item4.Index))
				{
					rtb.Select(item4.Index, item4.Length);
					rtb.SelectionColor = color_0;
				}
			}
			foreach (Match item5 in regex_4.Matches(text))
			{
				if (!smethod_2(text, item5.Index))
				{
					rtb.Select(item5.Index, item5.Length);
					rtb.SelectionColor = color_0;
				}
			}
			foreach (Match item6 in regex_5.Matches(text))
			{
				if (!smethod_2(text, item6.Index))
				{
					Group obj = item6.Groups[1];
					rtb.Select(obj.Index, obj.Length);
					rtb.SelectionColor = color_1;
					Group obj2 = item6.Groups[2];
					rtb.Select(obj2.Index, obj2.Length);
					rtb.SelectionColor = color_2;
				}
			}
			if (errorLine > 0)
			{
				smethod_1(rtb, text, errorLine, color_6);
			}
		}
		catch
		{
		}
		finally
		{
			rtb.Select(selectionStart, selectionLength);
			SendMessage(rtb.Handle, 11, (IntPtr)1, IntPtr.Zero);
			rtb.Invalidate();
		}
	}

	private static void smethod_0(RichTextBox richTextBox_0, string string_0, int int_0)
	{
		if (int_0 <= 0)
		{
			return;
		}
		int selectionStart = richTextBox_0.SelectionStart;
		int selectionLength = richTextBox_0.SelectionLength;
		SendMessage(richTextBox_0.Handle, 11, IntPtr.Zero, IntPtr.Zero);
		try
		{
			smethod_1(richTextBox_0, string_0, int_0, color_6);
		}
		finally
		{
			richTextBox_0.Select(selectionStart, selectionLength);
			SendMessage(richTextBox_0.Handle, 11, (IntPtr)1, IntPtr.Zero);
			richTextBox_0.Invalidate();
		}
	}

	private static void smethod_1(RichTextBox richTextBox_0, string string_0, int int_0, Color color_8)
	{
		int num = int_0 - 1;
		if (num < 0 || num >= richTextBox_0.Lines.Length)
		{
			return;
		}
		int firstCharIndexFromLine = richTextBox_0.GetFirstCharIndexFromLine(num);
		if (firstCharIndexFromLine >= 0)
		{
			int length = richTextBox_0.Lines[num].Length;
			if (length > 0)
			{
				richTextBox_0.Select(firstCharIndexFromLine, length);
				richTextBox_0.SelectionBackColor = color_8;
			}
		}
	}

	private static bool smethod_2(string string_0, int int_0)
	{
		int num = Math.Max(0, int_0 - 2000);
		string text = string_0.Substring(num, int_0 - num);
		int num2 = text.LastIndexOf(Class16.smethod_0(1649271577), StringComparison.Ordinal);
		if (num2 >= 0)
		{
			int num3 = text.IndexOf(Class16.smethod_0(1649271596), num2, StringComparison.Ordinal);
			if (num3 < 0)
			{
				return true;
			}
		}
		int num4 = text.LastIndexOf(Class16.smethod_0(1649271606), StringComparison.Ordinal);
		if (num4 >= 0)
		{
			int num5 = text.IndexOf(Class16.smethod_0(1649271622), num4, StringComparison.Ordinal);
			if (num5 < 0)
			{
				return true;
			}
		}
		return false;
	}

	[DllImport("user32.dll")]
	private static extern IntPtr SendMessage(IntPtr intptr_0, int int_0, IntPtr intptr_1, IntPtr intptr_2);
}
