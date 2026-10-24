using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ACE.Classes.Localization;
using ACE.NpcGen;
using ACE.RSGlobal;
using ACE.Settings;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sentry;

namespace ACE.Classes;

public class TextStorage
{
	public static TextStorage TEXTS;

	public LANGUAGES Languages;

	public LANG_INFO Lang;

	public int LangIndex;

	public IDictionary<int, string[][]> Texts;

	public IDictionary<string, FormTexts> Forms;

	public Dictionary<string, string> Properties;

	public ToolTip toolTip;

	public string LastErrorText;

	public string CurrentLocaleCode = Class16.smethod_0(1648931959);

	public bool DontShowExceptions;

	private static readonly object object_0 = new object();

	private static readonly HashSet<string> hashSet_0 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

	public static HashSet<int> SkipMessages = new HashSet<int>(new int[15]
	{
		255, 256, 590, 591, 592, 599, 601, 602, 603, 604,
		606, 607, 608, 609, 610
	});

	public static HashSet<int> ShowedMessages = new HashSet<int>();

	public HashSet<string> SavedControls;

	public bool bSaveOnlyTranslated;

	public TextStorage(int LangIndex)
	{
		Languages = new LANGUAGES();
		Texts = new Dictionary<int, string[][]>();
		SetLanguage(LangIndex);
		method_2();
		Forms = new Dictionary<string, FormTexts>();
	}

	public int SafeLangIndex(int str_id, int LangIndex)
	{
		if (Texts != null && Texts.TryGetValue(str_id, out var value) && value != null && value.Length != 0)
		{
			if (LangIndex >= 0 && LangIndex < (nint)value.LongLength)
			{
				GC.KeepAlive(this);
				return LangIndex;
			}
			return (value.LongLength > 1L) ? 1 : 0;
		}
		GC.KeepAlive(this);
		return 0;
	}

	public void LoadProperties(string FileName)
	{
		using StreamReader streamReader = File.OpenText(FileName);
		Dictionary<string, string> dictionary = Properties ?? new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		string text = streamReader.ReadLine();
		if (text != null && global::ACE.RSGlobal.RSGlobal.IsUIntFast(text))
		{
			if (Properties == null)
			{
				dictionary = new Dictionary<string, string>(global::ACE.RSGlobal.RSGlobal.UIntParseFast(text), StringComparer.OrdinalIgnoreCase);
			}
		}
		else if (text != null && !string.IsNullOrWhiteSpace(text) && text[0] != '#')
		{
			method_0(text, dictionary);
		}
		for (string text2 = streamReader.ReadLine(); text2 != null; text2 = streamReader.ReadLine())
		{
			if (!string.IsNullOrWhiteSpace(text2) && text2[0] != '#')
			{
				method_0(text2, dictionary);
			}
		}
		Properties = dictionary;
		GC.KeepAlive(this);
	}

	private void method_0(string string_0, Dictionary<string, string> dictionary_0)
	{
		string[] array = string_0.Split(';');
		if (array.Length == 0)
		{
			return;
		}
		string key = array[0];
		string value;
		if (array.LongLength <= 1L)
		{
			value = string.Empty;
		}
		else
		{
			int num = method_1(array);
			if (num < 1)
			{
				if (dictionary_0.ContainsKey(key))
				{
					return;
				}
				value = array[Math.Min(array.Length - 1, 1)];
			}
			else
			{
				value = ((num < array.Length) ? array[num] : array[Math.Min(array.Length - 1, 1)]);
			}
		}
		dictionary_0[key] = value;
	}

	private int method_1(string[] string_0)
	{
		if (string_0 != null && string_0.Length > 1)
		{
			string text = CurrentLocaleCode;
			if (string.IsNullOrWhiteSpace(text))
			{
				text = Lang?.Code;
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				text = Lang?.Prefix;
			}
			string string_1 = smethod_1(text);
			bool bool_ = string_0.Length > 1 && smethod_4(string_0[1]);
			int num = smethod_0(string_1, string_0.Length, bool_);
			if (num >= 1 && num < string_0.Length)
			{
				return num;
			}
			int num2 = LangIndex + 1;
			if (num2 >= 1 && num2 < string_0.Length)
			{
				return num2;
			}
			return Math.Min(string_0.Length - 1, Math.Max(1, num));
		}
		return -1;
	}

	private static int smethod_0(string string_0, int int_0, bool bool_0)
	{
		if (int_0 <= 1)
		{
			return -1;
		}
		if (bool_0)
		{
			if (!(string_0 == Class16.smethod_0(1648932072)))
			{
				if (!(string_0 == Class16.smethod_0(1648931959)))
				{
					if (!(string_0 == Class16.smethod_0(1648931984)))
					{
						if (!(string_0 == Class16.smethod_0(1648932004)))
						{
							if (!(string_0 == Class16.smethod_0(1648932134)))
							{
								if (!(string_0 == Class16.smethod_0(1648932143)))
								{
									return 1;
								}
								return (int_0 > 6) ? 6 : 5;
							}
							return 5;
						}
						return 4;
					}
					return 3;
				}
				return 2;
			}
			return 1;
		}
		if (!(string_0 == Class16.smethod_0(1648932072)))
		{
			if (!(string_0 == Class16.smethod_0(1648931959)))
			{
				if (!(string_0 == Class16.smethod_0(1648931984)))
				{
					if (!(string_0 == Class16.smethod_0(1648932004)))
					{
						if (!(string_0 == Class16.smethod_0(1648932134)))
						{
							if (!(string_0 == Class16.smethod_0(1648932143)))
							{
								return 1;
							}
							return (int_0 > 6) ? 6 : 5;
						}
						return 4;
					}
					return 3;
				}
				return 2;
			}
			return 1;
		}
		return -1;
	}

	private static string smethod_1(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return Class16.smethod_0(1648931959);
		}
		string text = string_0.Trim();
		if (!text.Equals(Class16.smethod_0(1648932099), StringComparison.OrdinalIgnoreCase) && !text.Equals(Class16.smethod_0(1648932090), StringComparison.OrdinalIgnoreCase))
		{
			if (!text.Equals(Class16.smethod_0(1648932125), StringComparison.OrdinalIgnoreCase) && !text.Equals(Class16.smethod_0(1648932116), StringComparison.OrdinalIgnoreCase))
			{
				if (text.Equals(Class16.smethod_0(1648932081), StringComparison.OrdinalIgnoreCase))
				{
					return Class16.smethod_0(1648931984);
				}
				return text;
			}
			return Class16.smethod_0(1648932004);
		}
		return Class16.smethod_0(1648931984);
	}

	public FormTexts LoadFormTexts(string FormName)
	{
		FormTexts result = method_4(FormName);
		GC.KeepAlive(this);
		return result;
	}

	public int GetNumberOfIndices(int str_id)
	{
		if (LocalizationBridge.TryGetLegacyMessageKeys(str_id, out var keys) && keys != null)
		{
			GC.KeepAlive(this);
			return keys.Length;
		}
		if (Texts != null && Texts.TryGetValue(str_id, out var value) && value != null && value.Length != 0)
		{
			int num = SafeLangIndex(str_id, LangIndex);
			if (num >= 0 && num < value.Length && value[num] != null)
			{
				GC.KeepAlive(this);
				return value[num].Length;
			}
			GC.KeepAlive(this);
			return 0;
		}
		GC.KeepAlive(this);
		return 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsTitleExist(int id)
	{
		return GetNumberOfIndices(id) > 1;
	}

	public DialogResult ShowInfoMessage(int id, params object[] vars)
	{
		return ShowMessage(id, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, vars);
	}

	public DialogResult ShowInfoMessage(int id)
	{
		return ShowMessage(id, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, null);
	}

	public DialogResult ShowErrorMessage(int id, params object[] vars)
	{
		return ShowMessage(id, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
	}

	public DialogResult ShowErrorMessage(int id)
	{
		return ShowMessage(id, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, string.Empty);
	}

	public DialogResult ShowQuestionMessage(int id, params object[] vars)
	{
		return ShowMessage(id, MessageBoxButtons.YesNo, MessageBoxIcon.Question, vars);
	}

	public DialogResult ShowQuestionMessage(int id)
	{
		return ShowMessage(id, MessageBoxButtons.YesNo, MessageBoxIcon.Question, string.Empty);
	}

	public DialogResult ShowYesNoCancelMessage(int id, params object[] vars)
	{
		return ShowMessage(id, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, vars);
	}

	public DialogResult ShowRetryCancelMessage(int id, params object[] vars)
	{
		return ShowMessage(id, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, vars);
	}

	public DialogResult ShowRetryCancelMessage(int id)
	{
		return ShowMessage(id, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, null);
	}

	public DialogResult ShowMessage(int id, MessageBoxButtons buttons, MessageBoxIcon icon, params object[] vars)
	{
		if (SkipMessages.Contains(id) && ShowedMessages.Contains(id))
		{
			GC.KeepAlive(this);
			return DialogResult.OK;
		}
		string text = GetText(ResolveLegacyMessageKey(id, 0), vars);
		if (text == null)
		{
			method_6(string.Format(Class16.smethod_0(1648895214), CurrentLocaleCode, id), string.Format(Class16.smethod_0(1648895247), id, CurrentLocaleCode), Class16.smethod_0(1648895305));
			return DialogResult.None;
		}
		string text2 = ((GetNumberOfIndices(id) <= 1) ? (icon switch
		{
			MessageBoxIcon.Asterisk => GetText(ResolveLegacyMessageKey(0, 0), null), 
			MessageBoxIcon.Exclamation => GetText(ResolveLegacyMessageKey(0, 1), null), 
			MessageBoxIcon.Question => GetText(ResolveLegacyMessageKey(0, 2), null), 
			_ => Class16.smethod_0(1648898209), 
		}) : GetText(ResolveLegacyMessageKey(id, 1), null));
		string caption = text2;
		text = text.Trim();
		if (icon == MessageBoxIcon.Exclamation)
		{
			if (id != 5)
			{
				text += string.Format(Class16.smethod_0(1648895338), id);
			}
			LastErrorText = text;
			if (DontShowExceptions)
			{
				return DialogResult.OK;
			}
		}
		if (!ShowedMessages.Contains(id))
		{
			ShowedMessages.Add(id);
		}
		DialogResult result = DKBox.Show(text, caption, buttons, icon);
		GC.KeepAlive(this);
		return result;
	}

	public DialogResult ShowMessage(int id, MessageBoxButtons buttons, MessageBoxIcon icon)
	{
		return ShowMessage(id, buttons, icon, null);
	}

	public void ShowLastError()
	{
		if (!string.IsNullOrEmpty(LastErrorText))
		{
			string text = GetText(ResolveLegacyMessageKey(0, 1), null);
			DKBox.Show(LastErrorText, text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		LastErrorText = null;
	}

	public void SaveFormTextsToFile(Form form, ToolTip toolTip, [MarshalAs(UnmanagedType.U1)] bool bSaveOnlyTranslated)
	{
		this.toolTip = toolTip;
		this.bSaveOnlyTranslated = bSaveOnlyTranslated;
		FormTexts formTexts = LoadFormTexts(form.Name);
		MemoryStream memoryStream = new MemoryStream();
		try
		{
			MemoryStream memoryStream2 = new MemoryStream();
			try
			{
				StreamWriter streamWriter = new StreamWriter(memoryStream, Encoding.UTF8, 1024, leaveOpen: true);
				try
				{
					StreamWriter streamWriter2 = new StreamWriter(memoryStream2, Encoding.UTF8, 1024, leaveOpen: true);
					try
					{
						if (bSaveOnlyTranslated)
						{
							if (formTexts != null)
							{
								foreach (KeyValuePair<string, string[]> control2 in formTexts.Controls)
								{
									ValueType valueType = control2;
									string[] value = ((KeyValuePair<string, string[]>)(object)valueType).Value;
									int num = value.Length;
									if (num > 0)
									{
										if (num >= 2)
										{
											value[1] = global::ACE.RSGlobal.RSGlobal.ToTitleCase(value[1]);
										}
										string separator = Class16.smethod_0(1648898262);
										string text = Class16.smethod_0(1648898262);
										streamWriter.WriteLine(string.Concat(((KeyValuePair<string, string[]>)(object)valueType).Key + text, string.Join(separator, value)));
									}
									else
									{
										streamWriter.WriteLine(((KeyValuePair<string, string[]>)(object)valueType).Key);
									}
								}
							}
						}
						else
						{
							SavedControls = new HashSet<string>();
							WriteControlText(formTexts, streamWriter, form.Name, form.Text);
							if (form.MainMenuStrip != null)
							{
								SaveContextMenuText(formTexts, form.MainMenuStrip, streamWriter, streamWriter2);
							}
							foreach (Control control3 in form.Controls)
							{
								SaveControlText(formTexts, control3, streamWriter, streamWriter2);
							}
						}
						streamWriter.Flush();
						streamWriter2.Flush();
						Dictionary<string, string> dictionary_ = method_7(memoryStream);
						Dictionary<string, string> dictionary_2 = method_7(memoryStream2);
						method_8(form.Name, dictionary_, dictionary_2);
						LocalizationBridge.Reload();
						GC.KeepAlive(this);
					}
					finally
					{
						((IDisposable)streamWriter2).Dispose();
					}
				}
				finally
				{
					((IDisposable)streamWriter).Dispose();
				}
			}
			finally
			{
				((IDisposable)memoryStream2).Dispose();
			}
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	public void SaveFormTextsToFile(Form form, ToolTip toolTip)
	{
		SaveFormTextsToFile(form, toolTip, bSaveOnlyTranslated: false);
	}

	public void WriteControlText(FormTexts ft, StreamWriter sw_controls, string Name, string ruText)
	{
		if (string.IsNullOrWhiteSpace(Name))
		{
			GC.KeepAlive(this);
			return;
		}
		if (SavedControls.Contains(Name))
		{
			GC.KeepAlive(this);
			return;
		}
		if (ft != null && ft.Controls.ContainsKey(Name))
		{
			string[] array = ft.Controls[Name];
			int num = array.Length;
			if (num > 0)
			{
				if (num >= 2)
				{
					array[1] = global::ACE.RSGlobal.RSGlobal.ToTitleCase(array[1]);
				}
				string separator = Class16.smethod_0(1648898262);
				sw_controls.WriteLine(string.Concat(Name + Class16.smethod_0(1648898262), string.Join(separator, array)));
			}
			else
			{
				sw_controls.WriteLine(Name);
			}
		}
		else if (!bSaveOnlyTranslated && !string.IsNullOrWhiteSpace(ruText) && ruText.Length > 2 && !global::ACE.RSGlobal.RSGlobal.IsNumber(ruText) && !Name.StartsWith(Class16.smethod_0(1648895364)) && Name != ruText)
		{
			string text = ParseControlName(Name);
			sw_controls.WriteLine(string.Concat(str1: (text == null) ? string.Empty : (Class16.smethod_0(1648898262) + text), str0: string.Concat(Name + Class16.smethod_0(1648898262), ruText)));
		}
		SavedControls.Add(Name);
		GC.KeepAlive(this);
	}

	public void SaveControlText(FormTexts ft, Control control, StreamWriter sw_controls, StreamWriter sw_tooltips)
	{
		string text = control.GetType().ToString();
		int num = ((!(text == Class16.smethod_0(1648895374)) && !(text == Class16.smethod_0(1648895412)) && !(text == Class16.smethod_0(1648895447)) && !(text == Class16.smethod_0(1648895480)) && !(text == Class16.smethod_0(1648894495))) ? 1 : 0);
		bool flag;
		if (flag = (byte)num != 0)
		{
			WriteControlText(ft, sw_controls, control.Name, control.Text);
			if (ft == null && control.Name != null)
			{
				ToolTip toolTip = this.toolTip;
				if (toolTip != null && toolTip.GetToolTip(control).Length > 2)
				{
					string newValue = Class16.smethod_0(1648903412);
					string oldValue = Class16.smethod_0(1648924428);
					ToolTip toolTip2 = this.toolTip;
					string text2 = Class16.smethod_0(1648898262);
					sw_tooltips.WriteLine(string.Concat(control.Name + text2, toolTip2.GetToolTip(control).Replace(oldValue, newValue)));
				}
			}
		}
		if (control.ContextMenuStrip != null)
		{
			SaveContextMenuText(ft, control.ContextMenuStrip, sw_controls, sw_tooltips);
		}
		if (!flag)
		{
			GC.KeepAlive(this);
			return;
		}
		if (control.Controls.Count > 0)
		{
			foreach (Control control2 in control.Controls)
			{
				SaveControlText(ft, control2, sw_controls, sw_tooltips);
			}
		}
		if (control is ToolStrip menustrip)
		{
			SaveContextMenuText(ft, menustrip, sw_controls, sw_tooltips);
		}
		else if (!(text == Class16.smethod_0(1648894532)) && !(text == Class16.smethod_0(1648894560)))
		{
			if (text == Class16.smethod_0(1648894586) || text == Class16.smethod_0(1648894626))
			{
				foreach (DataGridViewColumn column in ((DataGridView)control).Columns)
				{
					WriteControlText(ft, sw_controls, column.Name, column.HeaderText);
				}
			}
		}
		else
		{
			foreach (ColumnHeader column2 in ((ListView)control).Columns)
			{
				if (column2.Tag != null)
				{
					WriteControlText(ft, sw_controls, column2.Tag.ToString(), column2.Text);
				}
			}
		}
		GC.KeepAlive(this);
	}

	public void SaveContextMenuText(FormTexts ft, ToolStripItem item, StreamWriter sw_controls, StreamWriter sw_tooltips)
	{
		string text = item.GetType().ToString();
		if (text == Class16.smethod_0(1648894656))
		{
			GC.KeepAlive(this);
			return;
		}
		WriteControlText(ft, sw_controls, item.Name, item.Text);
		ToolStripItemCollection toolStripItemCollection = null;
		if (!(text == Class16.smethod_0(1648894710)))
		{
			if (!(text == Class16.smethod_0(1648894747)))
			{
				if (text == Class16.smethod_0(1648894806))
				{
					toolStripItemCollection = ((ToolStripSplitButton)item).DropDownItems;
				}
			}
			else
			{
				toolStripItemCollection = ((ToolStripDropDownButton)item).DropDownItems;
			}
		}
		else
		{
			toolStripItemCollection = ((ToolStripMenuItem)item).DropDownItems;
		}
		if (toolStripItemCollection != null && toolStripItemCollection.Count != 0)
		{
			foreach (ToolStripItem item2 in toolStripItemCollection)
			{
				SaveContextMenuText(ft, item2, sw_controls, sw_tooltips);
			}
		}
		GC.KeepAlive(this);
	}

	public void SaveContextMenuText(FormTexts ft, ToolStrip menustrip, StreamWriter sw_controls, StreamWriter sw_tooltips)
	{
		foreach (ToolStripItem item in menustrip.Items)
		{
			SaveContextMenuText(ft, item, sw_controls, sw_tooltips);
		}
		GC.KeepAlive(this);
	}

	public void SetFormLanguage(Form form, ToolTip toolTip)
	{
		if (form == null) throw new ArgumentNullException(nameof(form));
		this.toolTip = toolTip;
        try
        {
		FormTexts formTexts = LoadFormTexts(form.Name);
		foreach (Control control in form.Controls)
		{
			SetControlText(formTexts, control);
		}
		if (formTexts != null && formTexts.Controls.ContainsKey(form.Name))
		{
			string[] array = formTexts.Controls[form.Name];
			int langIndex = LangIndex;
			int num = langIndex;
			num = ((langIndex < (nint)array.LongLength) ? num : 0);
			form.Text = array[num];
		}
		if (form.ContextMenuStrip != null)
		{
			SetContextMenuText(formTexts, form.ContextMenuStrip);
		}
		if (LangIndex == 2 || LangIndex == 3) SimplifiedChineseForms.Apply(form, toolTip, LangIndex == 2 ? "cn" : "pt-BR");
		GC.KeepAlive(this);
        }
        finally { this.toolTip = null; }
	}

	public void SetFormLanguage(Form form)
	{
		SetFormLanguage(form, null);
	}

	public void SetControlText(FormTexts ft, Control control)
	{
		string text = control.GetType().ToString();
		bool flag = !string.IsNullOrWhiteSpace(control.Text) && smethod_2(control.Text);
		bool flag2 = false;
		if (toolTip != null && ft != null && ft.ToolTips != null && ft.ToolTips.ContainsKey(control.Name))
		{
			string[] array = ft.ToolTips[control.Name];
			int langIndex = LangIndex;
			if ((nint)array.LongLength - 1 >= langIndex)
			{
				toolTip.SetToolTip(control, array[langIndex]);
				flag2 = !string.IsNullOrWhiteSpace(array[langIndex]);
			}
		}
		if (control.ContextMenuStrip != null)
		{
			SetContextMenuText(ft, control.ContextMenuStrip);
		}
		int result3;
		if (!(text == Class16.smethod_0(1648894854)))
		{
			int result2;
			if (!(text == Class16.smethod_0(1648894882)))
			{
				int result;
				if (!(text == Class16.smethod_0(1648894925)))
				{
					if (!(text == Class16.smethod_0(1648895374)) && !(text == Class16.smethod_0(1648894967)))
					{
						if (control.Text != null)
						{
							string elementText = GetElementText(ft, control.Name, control.Text);
							if (flag && elementText != null)
							{
								control.Text = elementText;
							}
							else if (toolTip != null && !flag2)
							{
								string elementText2 = GetElementText(ft, control.Name, string.Empty);
								if (!string.IsNullOrWhiteSpace(elementText2))
								{
									toolTip.SetToolTip(control, elementText2);
								}
							}
						}
						if (control.Controls.Count != 0)
						{
							foreach (Control control2 in control.Controls)
							{
								SetControlText(ft, control2);
							}
						}
						if (control is ToolStrip { Items: var items })
						{
							if (items.Count != 0)
							{
								foreach (ToolStripItem item in items)
								{
									SetToolStripText(ft, item);
								}
							}
						}
						else if (!(text == Class16.smethod_0(1648894532)) && !(text == Class16.smethod_0(1648894560)))
						{
							if (text == Class16.smethod_0(1648894586) || text == Class16.smethod_0(1648894626))
							{
								foreach (DataGridViewColumn column in ((DataGridView)control).Columns)
								{
									column.HeaderText = GetElementText(ft, column.Name, column.HeaderText);
								}
							}
						}
						else
						{
							foreach (ColumnHeader column2 in ((ListView)control).Columns)
							{
								if (column2.Tag != null)
								{
									column2.Text = GetElementText(ft, column2.Tag.ToString(), column2.Text);
								}
							}
						}
						GC.KeepAlive(this);
					}
					else
					{
						GC.KeepAlive(this);
					}
				}
				else if (ft != null && ft.Controls.ContainsKey(control.Name) && int.TryParse(ft.Controls[control.Name][0], out result))
				{
					SetCheckedListBoxTexts((CheckedListBox)control, result);
				}
			}
			else if (ft != null && ft.Controls.ContainsKey(control.Name) && int.TryParse(ft.Controls[control.Name][0], out result2))
			{
				SetListBoxTexts((ListBox)control, result2);
			}
		}
		else if (ft != null && ft.Controls.ContainsKey(control.Name) && int.TryParse(ft.Controls[control.Name][0], out result3))
		{
			SetComboBoxTexts((ComboBox)control, result3);
		}
	}

	private static bool smethod_2(string string_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < string_0.Length)
			{
				char c = string_0[num];
				if (char.IsLetter(c))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public string GetElementText(FormTexts ft, string ElementName, string OldText)
	{
		if (!(ElementName == Class16.smethod_0(1648893977)) && !(ElementName == Class16.smethod_0(1648893992)) && !(ElementName == Class16.smethod_0(1648894014)) && !(ElementName == Class16.smethod_0(1648894024)))
		{
			string result = OldText;
			if (ft != null && ft.Controls.ContainsKey(ElementName))
			{
				string[] array = ft.Controls[ElementName];
				int langIndex = LangIndex;
				int num = array.Length;
				langIndex = ((langIndex >= num) ? 1 : langIndex);
				if (langIndex < num && array[langIndex] != string.Empty)
				{
					result = array[langIndex];
				}
			}
			GC.KeepAlive(this);
			return result;
		}
		GC.KeepAlive(this);
		return null;
	}

	public void SetContextMenuText(FormTexts ft, ContextMenuStrip menustrip)
	{
		foreach (ToolStripItem item in menustrip.Items)
		{
			SetToolStripText(ft, item);
		}
		GC.KeepAlive(this);
	}

	public static string ParseControlName(string name)
	{
		string text = ((name.Length <= 2) ? name : name.Substring(0, 3));
		string prop;
		if (text != null)
		{
			int length = text.Length;
			if (length == 3)
			{
				switch (text[1])
				{
				case 'b':
					if (!(text == Class16.smethod_0(1648894084)))
					{
						break;
					}
					goto IL_0145;
				case 'a':
					if (!(text == Class16.smethod_0(1648894096)))
					{
						break;
					}
					goto IL_0145;
				case 'x':
					if (!(text == Class16.smethod_0(1648894054)))
					{
						break;
					}
					goto IL_0145;
				case 'h':
					if (!(text == Class16.smethod_0(1648894056)))
					{
						break;
					}
					goto IL_0145;
				case 'l':
					if (!(text == Class16.smethod_0(1648930015)))
					{
						break;
					}
					goto IL_0145;
				case 'm':
					if (!(text == Class16.smethod_0(1648894044)))
					{
						break;
					}
					goto IL_0145;
				case 'n':
					if (!(text == Class16.smethod_0(1648894066)))
					{
						break;
					}
					goto IL_0145;
				case 'p':
					if (!(text == Class16.smethod_0(1648894094)))
					{
						break;
					}
					goto IL_0145;
				case 'r':
					{
						if (!(text == Class16.smethod_0(1648894106)))
						{
							break;
						}
						goto IL_0145;
					}
					IL_0145:
					prop = name.Substring(3);
					goto IL_0169;
				}
			}
		}
		if (text.StartsWith(Class16.smethod_0(1648894124)))
		{
			prop = name.Substring(2);
			goto IL_0169;
		}
		return null;
		IL_0169:
		return global::ACE.RSGlobal.RSGlobal.ConvertTitleCasedPropToNormalEnglish(prop);
	}

	public void SetComboBoxTexts(ToolStripComboBox combobox, int str_id)
	{
		int selectedIndex = combobox.SelectedIndex;
		combobox.Items.Clear();
		string[] textsByPrefix = GetTextsByPrefix(Class16.smethod_0(1648908609) + str_id);
		if (textsByPrefix != null)
		{
			ComboBox.ObjectCollection items = combobox.Items;
			object[] items2 = textsByPrefix;
			items.AddRange(items2);
		}
		if (selectedIndex >= 0 && selectedIndex < combobox.Items.Count)
		{
			combobox.SelectedIndex = selectedIndex;
		}
		else if (combobox.Items.Count > 0)
		{
			combobox.SelectedIndex = 0;
		}
		GC.KeepAlive(this);
	}

	public void SetComboBoxTexts(ComboBox combobox, int str_id)
	{
		int selectedIndex = combobox.SelectedIndex;
		string[] textsByPrefix = GetTextsByPrefix(Class16.smethod_0(1648908609) + str_id);
		if (textsByPrefix == null)
		{
			GC.KeepAlive(this);
			return;
		}
		combobox.Items.Clear();
		ComboBox.ObjectCollection items = combobox.Items;
		object[] items2 = textsByPrefix;
		items.AddRange(items2);
		if (selectedIndex >= 0 && selectedIndex < combobox.Items.Count)
		{
			combobox.SelectedIndex = selectedIndex;
		}
		else if (combobox.Items.Count > 0)
		{
			combobox.SelectedIndex = 0;
		}
		GC.KeepAlive(this);
	}

	public void SetListBoxTexts(ListBox listBox, int str_id)
	{
		int selectedIndex = listBox.SelectedIndex;
		string[] textsByPrefix = GetTextsByPrefix(Class16.smethod_0(1648908609) + str_id);
		if (textsByPrefix == null)
		{
			GC.KeepAlive(this);
			return;
		}
		listBox.Items.Clear();
		ListBox.ObjectCollection items = listBox.Items;
		object[] items2 = textsByPrefix;
		items.AddRange(items2);
		if (selectedIndex >= 0 && selectedIndex < listBox.Items.Count)
		{
			listBox.SelectedIndex = selectedIndex;
		}
		GC.KeepAlive(this);
	}

	public void SetCheckedListBoxTexts(CheckedListBox listBox, int str_id)
	{
		int selectedIndex = listBox.SelectedIndex;
		string[] textsByPrefix = GetTextsByPrefix(Class16.smethod_0(1648908609) + str_id);
		if (textsByPrefix == null)
		{
			GC.KeepAlive(this);
			return;
		}
		listBox.Items.Clear();
		CheckedListBox.ObjectCollection items = listBox.Items;
		object[] items2 = textsByPrefix;
		items.AddRange(items2);
		if (selectedIndex >= 0 && selectedIndex < listBox.Items.Count)
		{
			listBox.SelectedIndex = selectedIndex;
		}
		GC.KeepAlive(this);
	}

	public void SetLanguage(int LangIndex)
	{
		LocaleInfo localeInfo;
		object obj;
		if (Languages != null && Languages.Count != 0)
		{
			int num = LangIndex;
			if (num < 0 || num >= Languages.Count)
			{
				num = Math.Max(0, Math.Min(Languages.Count - 1, num));
			}
			this.LangIndex = num;
			LANG_INFO.CurrentLang = (Lang = Languages.Languages[num]);
			localeInfo = LocalizationBridge.ResolveLocale(num, Lang?.Prefix);
			if (localeInfo == null)
			{
				obj = null;
			}
			else
			{
				obj = localeInfo.Code;
				if (obj != null)
				{
					goto IL_009f;
				}
			}
			obj = Class16.smethod_0(1648931959);
			goto IL_009f;
		}
		this.LangIndex = 0;
		Lang = new LANG_INFO
		{
			Index = 0,
			Prefix = Class16.smethod_0(1648931959),
			Code = Class16.smethod_0(1648931959),
			Name = Class16.smethod_0(1648899236)
		};
		LANG_INFO.CurrentLang = Lang;
		CurrentLocaleCode = Class16.smethod_0(1648931959);
		return;
		IL_009f:
		CurrentLocaleCode = (string)obj;
		if (Lang != null && localeInfo != null)
		{
			Lang.Code = localeInfo.Code;
		}
		method_5();
		GC.KeepAlive(this);
	}

	public void ThrowEcxeptionT(int id, params object[] vars)
	{
		string text = GetText(ResolveLegacyMessageKey(id, 0), vars);
		if (text != null)
		{
			text = text.Trim();
			text += string.Format(Class16.smethod_0(1648895338), id);
		}
		else
		{
			text = string.Format(Class16.smethod_0(1648894133), id);
		}
		ApplicationException ex = new ApplicationException(text);
		ex.Data[Class16.smethod_0(1648894199)] = id;
		throw ex;
	}

	public void ThrowEcxeptionT(int id)
	{
		ThrowEcxeptionT(id, null);
	}

	public void ShowHandeledException(Exception exception_0, int id, params object[] vars)
	{
		SentryHelper.CaptureException(exception_0, Class16.smethod_0(1648894208));
		string text;
		if (id > -1)
		{
			text = GetText(ResolveLegacyMessageKey(id, 0), vars);
			string key = Class16.smethod_0(1648894248);
			exception_0.Data.Add(key, text);
		}
		else
		{
			text = exception_0.Message;
		}
		text += string.Format(Class16.smethod_0(1648895338), id);
		if (DontShowExceptions)
		{
			LastErrorText = text;
		}
		else
		{
			DKBox.Show(exception_0.Message, Class16.smethod_0(1648924056), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		GC.KeepAlive(this);
	}

	public string GetLocalization(string propName)
	{
		string value = null;
		Dictionary<string, string> properties = Properties;
		if (properties != null && properties.TryGetValue(propName, out value))
		{
			value = value.Replace(Class16.smethod_0(1648903412), Class16.smethod_0(1648941987));
		}
		else
		{
			method_6(Class16.smethod_0(1648894270) + CurrentLocaleCode + Class16.smethod_0(1648905535) + propName, Class16.smethod_0(1648894294) + propName + Class16.smethod_0(1648894315) + CurrentLocaleCode + Class16.smethod_0(1648894358), Class16.smethod_0(1648894366));
			value = propName;
		}
		GC.KeepAlive(this);
		return value;
	}

	public static string Msg(string key, string fallback = null)
	{
		try
		{
			TextStorage tEXTS = TEXTS;
			object obj;
			if (tEXTS == null)
			{
				obj = null;
			}
			else
			{
				obj = tEXTS.CurrentLocaleCode;
				if (obj != null)
				{
					goto IL_001f;
				}
			}
			obj = Class16.smethod_0(1648931959);
			goto IL_001f;
			IL_001f:
			string localeCode = (string)obj;
			if (LocalizationBridge.TryGetMessage(localeCode, key, out var value))
			{
				return value;
			}
		}
		catch
		{
		}
		return fallback ?? key;
	}

	private bool method_2()
	{
		string legacyPrefix = null;
		if (Languages?.Languages != null && LangIndex >= 0 && LangIndex < Languages.Count)
		{
			legacyPrefix = Languages.Languages[LangIndex].Prefix;
		}
		CurrentLocaleCode = LocalizationBridge.ResolveLocaleCode(LangIndex, legacyPrefix);
		string path = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648899196));
		return Directory.Exists(path);
	}

	private bool method_3(int int_0, int int_1, object[] object_1, out string string_0)
	{
		string_0 = null;
		if (string.IsNullOrWhiteSpace(CurrentLocaleCode))
		{
			CurrentLocaleCode = LocalizationBridge.ResolveLocaleCode(LangIndex);
		}
		if (!LocalizationBridge.TryGetLegacyMessageKey(int_0, int_1, out var key))
		{
			return false;
		}
		if (!LocalizationBridge.TryGetMessage(CurrentLocaleCode, key, out var value))
		{
			return false;
		}
		string_0 = smethod_3(value, object_1);
		return !string.IsNullOrWhiteSpace(string_0);
	}

	private FormTexts method_4(string string_0)
	{
		if (string.IsNullOrWhiteSpace(CurrentLocaleCode))
		{
			CurrentLocaleCode = LocalizationBridge.ResolveLocaleCode(LangIndex);
		}
		return LocalizationBridge.GetFormTexts(CurrentLocaleCode, LangIndex, Languages?.Count ?? 6, string_0);
	}

	private void method_5()
	{
		if (string.IsNullOrWhiteSpace(CurrentLocaleCode))
		{
			CurrentLocaleCode = LocalizationBridge.ResolveLocaleCode(LangIndex);
		}
		Dictionary<string, string> properties = LocalizationBridge.GetProperties(CurrentLocaleCode);
		if (properties != null && properties.Count > 0)
		{
			Properties = new Dictionary<string, string>(properties, StringComparer.OrdinalIgnoreCase);
		}
	}

	private static string smethod_3(string string_0, object[] object_1)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return string_0;
		}
		string_0 = string_0.Replace(Class16.smethod_0(1648903412), Class16.smethod_0(1648924428));
		if (object_1 != null && object_1.Length != 0 && object_1[0] != null)
		{
			string text;
			string oldValue;
			object obj2;
			for (int i = 0; i < object_1.Length; string_0 = text.Replace(oldValue, (string)obj2), i++)
			{
				object obj = object_1[i];
				text = string_0;
				oldValue = Class16.smethod_0(1648938114) + (i + 1);
				if (obj == null)
				{
					obj2 = null;
				}
				else
				{
					obj2 = obj.ToString();
					if (obj2 != null)
					{
						continue;
					}
				}
				obj2 = string.Empty;
			}
		}
		if (string_0.Contains(Class16.smethod_0(1648905543)))
		{
			string_0 = Regex.Replace(string_0, Class16.smethod_0(1648894392), string.Empty);
		}
		return string_0;
	}

	public string GetText(string key, params object[] vars)
	{
		if (string.IsNullOrWhiteSpace(CurrentLocaleCode))
		{
			CurrentLocaleCode = LocalizationBridge.ResolveLocaleCode(LangIndex);
		}
		if (string.IsNullOrWhiteSpace(key))
		{
			method_6(Class16.smethod_0(1648894412) + CurrentLocaleCode, Class16.smethod_0(1648894431) + CurrentLocaleCode + Class16.smethod_0(1648894358), Class16.smethod_0(1648897544));
			return null;
		}
		bool flag;
		string value;
		try
		{
			flag = LocalizationBridge.TryGetMessage(CurrentLocaleCode, key, out value);
		}
		catch (Exception ex)
		{
			method_6(Class16.smethod_0(1648897582) + CurrentLocaleCode + Class16.smethod_0(1648905535) + key, Class16.smethod_0(1648897606) + key + Class16.smethod_0(1648897640) + CurrentLocaleCode + Class16.smethod_0(1648927638) + ex.Message, Class16.smethod_0(1648897668));
			flag = false;
			value = null;
		}
		if (!flag)
		{
			method_6(Class16.smethod_0(1648897702) + CurrentLocaleCode + Class16.smethod_0(1648905535) + key, Class16.smethod_0(1648897713) + key + Class16.smethod_0(1648894315) + CurrentLocaleCode + Class16.smethod_0(1648894358), Class16.smethod_0(1648897544));
			if (key.StartsWith(Class16.smethod_0(1648908609), StringComparison.OrdinalIgnoreCase))
			{
				return key;
			}
			return null;
		}
		return smethod_3(value, vars);
	}

	public string[] GetTextsByPrefix(string keyPrefix)
	{
		if (string.IsNullOrWhiteSpace(keyPrefix))
		{
			return null;
		}
		List<string> list = new List<string>();
		if (smethod_6(keyPrefix, out var int_) && LocalizationBridge.TryGetLegacyMessageKeys(int_, out var keys))
		{
			for (int i = 0; i < keys.Length; i++)
			{
				list.Add(GetText(keys[i]) ?? string.Empty);
			}
			if (list.Count != 0)
			{
				return list.ToArray();
			}
			return null;
		}
		if (smethod_6(keyPrefix, out var _))
		{
			return null;
		}
		int num = 0;
		for (int j = 0; j < 64; j++)
		{
			string key = keyPrefix + Class16.smethod_0(1648928036) + j;
			string text = GetText(key);
			if (text == null)
			{
				num++;
				if (num >= 3 && list.Count > 0)
				{
					break;
				}
			}
			else
			{
				num = 0;
				list.Add(text);
			}
		}
		if (list.Count != 0)
		{
			return list.ToArray();
		}
		return null;
	}

	public string ResolveLegacyMessageKey(int strId, int index)
	{
		if (LocalizationBridge.TryGetLegacyMessageKey(strId, index, out var key) && !string.IsNullOrWhiteSpace(key))
		{
			return key;
		}
		string text = Class16.smethod_0(1648908609) + strId + Class16.smethod_0(1648928036) + Math.Max(0, index);
		string localeCode = (string.IsNullOrWhiteSpace(CurrentLocaleCode) ? Class16.smethod_0(1648931959) : CurrentLocaleCode);
		if (!LocalizationBridge.TryGetMessage(localeCode, text, out var value) && !LocalizationBridge.TryGetMessage(Class16.smethod_0(1648931959), text, out value))
		{
			method_6(string.Format(Class16.smethod_0(1648897737), strId, index), string.Format(Class16.smethod_0(1648897770), strId, index), Class16.smethod_0(1648897835));
			return text;
		}
		return text;
	}

	private void method_6(string string_0, string string_1, string string_2)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return;
		}
		lock (object_0)
		{
			if (!hashSet_0.Add(string_0))
			{
				return;
			}
		}
		try
		{
			SentryHelper.CaptureMessage(string_1, (SentryLevel)2, string_2);
		}
		catch
		{
		}
	}

	private static bool smethod_4(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < string_0.Length)
			{
				char c = string_0[num];
				if ((c >= 'Ѐ' && c <= 'ӿ') || (c >= 'Ԁ' && c <= 'ԯ'))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public void LoadTexts(string FileName, [MarshalAs(UnmanagedType.U1)] bool bCheckExistence, [MarshalAs(UnmanagedType.U1)] bool bCheckLangCount)
	{
		LoadTextsFromCSV(File.OpenText(FileName), bCheckExistence, bCheckLangCount, FileName);
		GC.KeepAlive(this);
	}

	public void LoadTextsFromCSV(StreamReader sr, [MarshalAs(UnmanagedType.U1)] bool bCheckExistence, [MarshalAs(UnmanagedType.U1)] bool bCheckLangCount, string FileCaption)
	{
		int num = 1;
		int num2 = 0;
		int num3 = -1;
		int num4 = 0;
		string text = sr.ReadLine();
		if (text != null)
		{
			do
			{
				if (!string.IsNullOrWhiteSpace(text) && text[0] != '#')
				{
					string text2 = text;
					int num5 = text.IndexOf(';');
					if (num5 > 0)
					{
						text2 = text.Substring(0, num5);
					}
					if (global::ACE.RSGlobal.RSGlobal.IsUIntFast(text2))
					{
						if (bCheckLangCount && num3 > -1 && (nint)Texts[num3].LongLength < Languages.Count && Texts.ContainsKey(91))
						{
							ShowMessage(91, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, FileCaption, num3, num, text);
						}
						num3 = global::ACE.RSGlobal.RSGlobal.UIntParseFast(text2);
						num2 = num;
						if (bCheckExistence && Texts.ContainsKey(num3))
						{
							num++;
							goto IL_0020;
						}
						Texts.Add(num3, new string[2][]);
					}
					else if (num3 >= 0)
					{
						int num6 = num - num2 - 1;
						if (string.IsNullOrEmpty(text))
						{
							goto IL_0020;
						}
						if (Texts.ContainsKey(num3))
						{
							string[][] array = Texts[num3];
							if ((nint)array.LongLength < num6 + 1)
							{
								Array.Resize(ref array, num6 + 1);
							}
							char[] separator = new char[1] { ';' };
							array[num6] = text.Split(separator);
							Texts[num3] = array;
							int num7 = array[num6].Length;
							if (num6 == 0)
							{
								num4 = num7;
							}
							else if (num4 != num7 && Texts.ContainsKey(90))
							{
								ShowMessage(90, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, FileCaption, num3, num, text);
							}
						}
					}
				}
				num++;
				goto IL_0020;
				IL_0020:
				text = sr.ReadLine();
			}
			while (text != null);
		}
		sr.Close();
		GC.KeepAlive(this);
	}

	private Dictionary<string, string> method_7(MemoryStream memoryStream_0)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		memoryStream_0.Position = 0L;
		StreamReader streamReader = new StreamReader(memoryStream_0, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, 1024, leaveOpen: true);
		try
		{
			string text;
			while ((text = streamReader.ReadLine()) != null)
			{
				if (string.IsNullOrWhiteSpace(text) || text[0] == '#' || text[0] == '/')
				{
					continue;
				}
				string[] array = text.Split(';');
				if (array.Length < 2)
				{
					continue;
				}
				string text2 = array[0].Trim();
				if (!string.IsNullOrWhiteSpace(text2))
				{
					string text3 = string.Empty;
					int num = LangIndex + 1;
					if (num >= 1 && num < array.Length && !string.IsNullOrWhiteSpace(array[num]))
					{
						text3 = array[num];
					}
					else if (array.Length > 1)
					{
						text3 = array[1];
					}
					dictionary[text2] = text3 ?? string.Empty;
				}
			}
			return dictionary;
		}
		finally
		{
			((IDisposable)streamReader).Dispose();
		}
	}

	private void method_8(string string_0, Dictionary<string, string> dictionary_0, Dictionary<string, string> dictionary_1)
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		string text = (string.IsNullOrWhiteSpace(CurrentLocaleCode) ? LocalizationBridge.ResolveLocaleCode(LangIndex, Lang?.Prefix) : CurrentLocaleCode);
		string text2 = smethod_5(string_0);
		string path = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648899207), Class16.smethod_0(1648899196), text, Class16.smethod_0(1648899118), text2 + Class16.smethod_0(1648899122));
		Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));
		JObject val = new JObject
		{
			[Class16.smethod_0(1648899080)] = (JToken)((dictionary_0 != null) ? ((object)JObject.FromObject((object)dictionary_0)) : ((object)new JObject())),
			[Class16.smethod_0(1648899103)] = (JToken)((dictionary_1 != null) ? ((object)JObject.FromObject((object)dictionary_1)) : ((object)new JObject()))
		};
		File.WriteAllText(path, ((JToken)val).ToString((Formatting)1), Encoding.UTF8);
	}

	private static string smethod_5(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return Class16.smethod_0(1648923968);
		}
		string input = string_0.Trim();
		input = Regex.Replace(input, Class16.smethod_0(1648899147), Class16.smethod_0(1648905543));
		return Regex.Replace(input, Class16.smethod_0(1648899178), Class16.smethod_0(1648923968));
	}

	public void SetToolStripText(FormTexts ft, ToolStripItem item)
	{
		string text = item.GetType().ToString();
		if (text == Class16.smethod_0(1648894656))
		{
			GC.KeepAlive(this);
			return;
		}
		string elementText = GetElementText(ft, item.Name, item.Text);
		if (elementText != null)
		{
			item.Text = elementText;
		}
		if (ft != null && ft.ToolTips != null && ft.ToolTips.ContainsKey(item.Name))
		{
			string[] array = ft.ToolTips[item.Name];
			int langIndex = LangIndex;
			if ((nint)array.LongLength - 1 >= langIndex)
			{
				item.ToolTipText = array[langIndex];
			}
			else
			{
				item.ToolTipText = item.Text;
			}
		}
		else
		{
			item.ToolTipText = item.Text;
		}
		if (text == Class16.smethod_0(1648897878) && ft != null && ft.Controls.ContainsKey(item.Name) && int.TryParse(ft.Controls[item.Name][0], out var result))
		{
			SetComboBoxTexts((ToolStripComboBox)item, result);
		}
		ToolStripItemCollection toolStripItemCollection = null;
		if (!(text == Class16.smethod_0(1648894710)))
		{
			if (!(text == Class16.smethod_0(1648894747)))
			{
				if (text == Class16.smethod_0(1648894806))
				{
					toolStripItemCollection = ((ToolStripSplitButton)item).DropDownItems;
				}
			}
			else
			{
				toolStripItemCollection = ((ToolStripDropDownButton)item).DropDownItems;
			}
		}
		else
		{
			toolStripItemCollection = ((ToolStripMenuItem)item).DropDownItems;
		}
		if (toolStripItemCollection != null && toolStripItemCollection.Count != 0)
		{
			foreach (ToolStripItem item2 in toolStripItemCollection)
			{
				SetToolStripText(ft, item2);
			}
		}
		GC.KeepAlive(this);
	}

	private static bool smethod_6(string string_0, out int int_0)
	{
		int_0 = 0;
		if (!string_0.StartsWith(Class16.smethod_0(1648908609), StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		string text = string_0.Substring(11);
		int num = text.IndexOf('.');
		if (num >= 0)
		{
			text = text.Substring(0, num);
		}
		return int.TryParse(text, out int_0);
	}
}
