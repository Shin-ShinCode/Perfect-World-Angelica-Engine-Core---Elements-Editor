using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACE.Classes;
using ACE.sTASKedit.tasks;
using ACE.sTASKedit.tasks.tasks.data;
using Sentry;

namespace ACE.sTASKedit.Classes;

public class TranslationService
{
	[StructLayout(LayoutKind.Auto)]
	private struct Struct118 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder<string> asyncTaskMethodBuilder_0;

		public string string_0;

		public string string_1;

		public string string_2;

		private TaskAwaiter<string> taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			string result2;
			try
			{
				TaskAwaiter<string> awaiter;
				if (num != 0)
				{
					Class406 @class = new Class406();
					@class.string_0 = string_0;
					@class.string_1 = string_1;
					@class.string_2 = string_2;
					awaiter = Task.Run((Func<string>)@class.method_0).GetAwaiter();
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
					taskAwaiter_0 = default(TaskAwaiter<string>);
					num = -1;
					int_0 = -1;
				}
				string result = awaiter.GetResult();
				result2 = result;
			}
			catch (Exception exception)
			{
				int_0 = -2;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			asyncTaskMethodBuilder_0.SetResult(result2);
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

	private sealed class Class405
	{
		public string string_0;

		public string string_1;

		internal bool method_0(string string_2)
		{
			return string.Equals(string_2, string_0, StringComparison.OrdinalIgnoreCase);
		}

		internal bool method_1(string string_2)
		{
			return string.Equals(string_2, string_1, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class406
	{
		public string string_0;

		public string string_1;

		public string string_2;

		internal string method_0()
		{
			return Translate(string_0, string_1, string_2);
		}
	}

	private sealed class Class407
	{
		public string string_0;

		internal bool method_0(LanguageInfo languageInfo_0)
		{
			return string.Equals(languageInfo_0.Code, string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct119 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder<(bool, string)> asyncTaskMethodBuilder_0;

		private TaskAwaiter<(bool, string)> taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			(bool, string) result2;
			try
			{
				TaskAwaiter<(bool, string)> awaiter;
				if (num != 0)
				{
					awaiter = Task.Run((Func<(bool, string)>)Class408.class408_0.method_1).GetAwaiter();
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
					taskAwaiter_0 = default(TaskAwaiter<(bool, string)>);
					num = -1;
					int_0 = -1;
				}
				(bool, string) result = awaiter.GetResult();
				result2 = result;
			}
			catch (Exception exception)
			{
				int_0 = -2;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			asyncTaskMethodBuilder_0.SetResult(result2);
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

	[Serializable]
	private sealed class Class408
	{
		public static readonly Class408 class408_0 = new Class408();

		public static Func<LanguageInfo, bool> func_0;

		public static Func<(bool, string)> func_1;

		public static Func<LanguageInfo, LanguageInfo> func_2;

		internal bool method_0(LanguageInfo languageInfo_0)
		{
			return !string.Equals(languageInfo_0.Code, Class16.smethod_0(1648897915), StringComparison.OrdinalIgnoreCase);
		}

		internal (bool, string) method_1()
		{
			try
			{
				if (!TryInitializeOpenAiTranslator(out var errorMessage))
				{
					return (false, errorMessage);
				}
				string targetLanguageCode = Settings.Fields?.TranslationSettings?.TargetLanguage;
				if (!TryResolveLanguagePair(Class16.smethod_0(1648897915), targetLanguageCode, out var fromLanguageIndex, out var toLanguageIndex, out var errorMessage2))
				{
					return (false, errorMessage2);
				}
				string text = Class16.smethod_0(1649257231);
				string text2 = TranslateTaskField(text, fromLanguageIndex, toLanguageIndex, 0);
				if (text2 != text && !string.IsNullOrWhiteSpace(text2))
				{
					return (true, Class16.smethod_0(1649257234) + text + Class16.smethod_0(1649257311) + text2 + Class16.smethod_0(1648894358));
				}
				return (false, Class16.smethod_0(1649257320) + text + Class16.smethod_0(1649257388) + text2 + Class16.smethod_0(1648894358));
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649257406));
				return (false, Class16.smethod_0(1649257443) + ex.Message);
			}
		}

		internal LanguageInfo method_2(LanguageInfo languageInfo_0)
		{
			return new LanguageInfo(languageInfo_0.Code, languageInfo_0.Name);
		}
	}

	private static readonly List<LanguageInfo> list_0 = new List<LanguageInfo>
	{
		new LanguageInfo(Class16.smethod_0(1648897915), Class16.smethod_0(1648897251)),
		new LanguageInfo(Class16.smethod_0(1649156964), Class16.smethod_0(1648891546)),
		new LanguageInfo(Class16.smethod_0(1648932116), Class16.smethod_0(1648896720)),
		new LanguageInfo(Class16.smethod_0(1648931959), Class16.smethod_0(1648899236)),
		new LanguageInfo(Class16.smethod_0(1648897214), Class16.smethod_0(1648896795)),
		new LanguageInfo(Class16.smethod_0(1648932072), Class16.smethod_0(1648896752)),
		new LanguageInfo(Class16.smethod_0(1648932081), Class16.smethod_0(1648897312)),
		new LanguageInfo(Class16.smethod_0(1649256454), Class16.smethod_0(1648897339)),
		new LanguageInfo(Class16.smethod_0(1648898024), Class16.smethod_0(1648897433)),
		new LanguageInfo(Class16.smethod_0(1648898033), Class16.smethod_0(1648897454)),
		new LanguageInfo(Class16.smethod_0(1648897073), Class16.smethod_0(1648896550)),
		new LanguageInfo(Class16.smethod_0(1648897082), Class16.smethod_0(1648896564)),
		new LanguageInfo(Class16.smethod_0(1648897124), Class16.smethod_0(1648896615)),
		new LanguageInfo(Class16.smethod_0(1648897233), Class16.smethod_0(1648896834)),
		new LanguageInfo(Class16.smethod_0(1648907710), Class16.smethod_0(1648896848))
	};

	public static async Task<string> TranslateAsync(string text, string sourceLanguage, string targetLanguage)
	{
		Class406 @class = new Class406();
		@class.string_0 = text;
		@class.string_1 = sourceLanguage;
		@class.string_2 = targetLanguage;
		return await Task.Run((Func<string>)@class.method_0);
	}

	public static string Translate(string text, string sourceLanguage, string targetLanguage)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		try
		{
			if (!TryInitializeOpenAiTranslator(out var errorMessage))
			{
				throw new InvalidOperationException(errorMessage);
			}
			if (!TryResolveLanguagePair(sourceLanguage, targetLanguage, out var fromLanguageIndex, out var toLanguageIndex, out var errorMessage2))
			{
				throw new InvalidOperationException(errorMessage2);
			}
			return TranslateTaskField(text, fromLanguageIndex, toLanguageIndex, 0);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649256463));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649256490), Class16.smethod_0(1649149963)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return text;
		}
	}

	public static bool TryInitializeOpenAiTranslator(out string errorMessage)
	{
		errorMessage = null;
		try
		{
			string text = CommonStorage.AParams?.OpenAIApiKey;
			if (string.IsNullOrWhiteSpace(text))
			{
				errorMessage = Class16.smethod_0(1649256532);
				return false;
			}
			UniversalTranslator.OpenAIApiKey = text.Trim();
			UniversalTranslator.OpenAIBaseUrl = CommonStorage.AParams?.OpenAIBaseUrl;
			UniversalTranslator.SwitchTranslator(useOpenAi: true);
			if (!UniversalTranslator.Init())
			{
				errorMessage = Class16.smethod_0(1649256605);
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649256704));
			errorMessage = ex.Message;
			return false;
		}
	}

	public static bool PromptTargetLanguage(IWin32Window owner, string title, out string targetLanguageCode)
	{
		Class407 @class = new Class407();
		targetLanguageCode = null;
		List<LanguageInfo> list = GetSupportedLanguages().Where(Class408.class408_0.method_0).ToList();
		if (list.Count == 0)
		{
			return false;
		}
		@class.string_0 = smethod_0(Settings.Fields?.TranslationSettings?.TargetLanguage);
		Form form = new Form();
		try
		{
			Label label = new Label();
			try
			{
				ComboBox comboBox = new ComboBox();
				try
				{
					Button button = new Button();
					try
					{
						Button button2 = new Button();
						try
						{
							form.Text = (string.IsNullOrWhiteSpace(title) ? Class16.smethod_0(1649256767) : title);
							form.FormBorderStyle = FormBorderStyle.FixedDialog;
							form.StartPosition = FormStartPosition.CenterParent;
							form.MinimizeBox = false;
							form.MaximizeBox = false;
							form.ShowInTaskbar = false;
							form.ClientSize = new Size(460, 170);
							label.AutoSize = false;
							label.Location = new Point(12, 12);
							label.Size = new Size(436, 44);
							label.Text = TextStorage.Msg(Class16.smethod_0(1649256796));
							comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
							comboBox.Location = new Point(15, 70);
							comboBox.Size = new Size(433, 24);
							foreach (LanguageInfo item in list)
							{
								comboBox.Items.Add(item);
							}
							int num = list.FindIndex(@class.method_0);
							comboBox.SelectedIndex = ((num >= 0) ? num : 0);
							button.Text = TextStorage.Msg(Class16.smethod_0(1649190297), Class16.smethod_0(1648938905));
							button.Size = new Size(90, 28);
							button.Location = new Point(262, 122);
							button.DialogResult = DialogResult.OK;
							button2.Text = TextStorage.Msg(Class16.smethod_0(1649005070), Class16.smethod_0(1648941799));
							button2.Size = new Size(90, 28);
							button2.Location = new Point(358, 122);
							button2.DialogResult = DialogResult.Cancel;
							form.AcceptButton = button;
							form.CancelButton = button2;
							form.Controls.Add(label);
							form.Controls.Add(comboBox);
							form.Controls.Add(button);
							form.Controls.Add(button2);
							TDark.StoreOriginalColors(form);
							TDark.ApplyThemeToForm(form);
							if (form.ShowDialog(owner) != DialogResult.OK)
							{
								return false;
							}
							if (!(comboBox.SelectedItem is LanguageInfo languageInfo))
							{
								return false;
							}
							targetLanguageCode = smethod_0(languageInfo.Code);
							if (Settings.Fields?.TranslationSettings != null)
							{
								Settings.Fields.TranslationSettings.SourceLanguage = Class16.smethod_0(1648897915);
								Settings.Fields.TranslationSettings.TargetLanguage = targetLanguageCode;
								Settings.WriteXml();
							}
							return true;
						}
						finally
						{
							((IDisposable)button2).Dispose();
						}
					}
					finally
					{
						((IDisposable)button).Dispose();
					}
				}
				finally
				{
					((IDisposable)comboBox).Dispose();
				}
			}
			finally
			{
				((IDisposable)label).Dispose();
			}
		}
		finally
		{
			((IDisposable)form).Dispose();
		}
	}

	public static bool TryResolveLanguagePair(string sourceLanguageCode, string targetLanguageCode, out int fromLanguageIndex, out int toLanguageIndex, out string errorMessage)
	{
		Class405 @class = new Class405();
		fromLanguageIndex = -1;
		toLanguageIndex = -1;
		errorMessage = null;
		@class.string_0 = smethod_1(string.IsNullOrWhiteSpace(sourceLanguageCode) ? Class16.smethod_0(1648897915) : sourceLanguageCode);
		@class.string_1 = smethod_1(smethod_0(targetLanguageCode));
		if (string.Equals(@class.string_1, Class16.smethod_0(1648897915), StringComparison.OrdinalIgnoreCase))
		{
			errorMessage = Class16.smethod_0(1649256831);
			return false;
		}
		string[] languagesCodes = UniversalTranslator.GetLanguagesCodes();
		fromLanguageIndex = Array.FindIndex(languagesCodes, @class.method_0);
		if (fromLanguageIndex < 0)
		{
			errorMessage = Class16.smethod_0(1649256911) + sourceLanguageCode + Class16.smethod_0(1649256935);
			return false;
		}
		toLanguageIndex = Array.FindIndex(languagesCodes, @class.method_1);
		if (toLanguageIndex < 0)
		{
			errorMessage = Class16.smethod_0(1649251858) + targetLanguageCode + Class16.smethod_0(1649256935);
			return false;
		}
		return true;
	}

	public static string TranslateTaskField(string value, int fromIndex, int toIndex, int maxFieldChars)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return value;
		}
		if (fromIndex >= 0 && toIndex >= 0)
		{
			return UniversalTranslator.Translate(value, fromIndex, toIndex, maxFieldChars);
		}
		return value;
	}

	public static void TranslateTaskTexts(ATaskTempl task, int fromIndex, int toIndex, bool includeSubTasks)
	{
		if (task == null)
		{
			return;
		}
		if (!TryInitializeOpenAiTranslator(out var errorMessage))
		{
			SentryHelper.CaptureMessage(errorMessage, (SentryLevel)2, Class16.smethod_0(1649251882));
			return;
		}
		smethod_2(task, fromIndex, toIndex);
		if (includeSubTasks && task.pSub != null)
		{
			for (int i = 0; i < task.pSub.Length; i++)
			{
				TranslateTaskTexts(task.pSub[i], fromIndex, toIndex, includeSubTasks: true);
			}
		}
	}

	public static async Task<(bool success, string message)> TestConnectionAsync()
	{
		return await Task.Run((Func<(bool, string)>)Class408.class408_0.method_1);
	}

	public static List<LanguageInfo> GetSupportedLanguages()
	{
		return list_0.Select(Class408.class408_0.method_2).ToList();
	}

	private static string smethod_0(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return Class16.smethod_0(1649156964);
		}
		string text = string_0.Trim().ToLowerInvariant();
		if (text == Class16.smethod_0(1649251937))
		{
			return Class16.smethod_0(1649156964);
		}
		return text;
	}

	private static string smethod_1(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return Class16.smethod_0(1648897915);
		}
		string text = string_0.Trim().ToLowerInvariant();
		if (text != null)
		{
			switch (text.Length)
			{
			case 2:
				switch (text[1])
				{
				case 't':
					if (text == Class16.smethod_0(1649256454))
					{
						return Class16.smethod_0(1648897974);
					}
					break;
				case 'h':
					if (text == Class16.smethod_0(1648932081))
					{
						return Class16.smethod_0(1648897953);
					}
					break;
				}
				break;
			case 4:
				if (text == Class16.smethod_0(1648897915))
				{
					return Class16.smethod_0(1648897915);
				}
				break;
			case 5:
				switch (text[3])
				{
				case 't':
					if (!(text == Class16.smethod_0(1649251961)))
					{
						if (text == Class16.smethod_0(1649251981))
						{
							return Class16.smethod_0(1648897974);
						}
						break;
					}
					return Class16.smethod_0(1648897974);
				case 'c':
					if (!(text == Class16.smethod_0(1649156944)))
					{
						if (text == Class16.smethod_0(1649251957))
						{
							return Class16.smethod_0(1648897953);
						}
						break;
					}
					return Class16.smethod_0(1648897953);
				case 'b':
					if (!(text == Class16.smethod_0(1649156964)))
					{
						if (text == Class16.smethod_0(1649251937))
						{
							return Class16.smethod_0(1648932116);
						}
						break;
					}
					return Class16.smethod_0(1648932116);
				}
				break;
			case 7:
				switch (text[6])
				{
				case 't':
					if (text == Class16.smethod_0(1649252007))
					{
						return Class16.smethod_0(1648897974);
					}
					break;
				case 's':
					if (text == Class16.smethod_0(1649251985))
					{
						return Class16.smethod_0(1648897953);
					}
					break;
				}
				break;
			}
		}
		return string_0.Trim();
	}

	private static void smethod_2(ATaskTempl ataskTempl_0, int int_0, int int_1)
	{
		ataskTempl_0.Name = TranslateTaskField(ataskTempl_0.Name, int_0, int_1, 30);
		if (ataskTempl_0.m_bHasSign)
		{
			ataskTempl_0.Signature = TranslateTaskField(ataskTempl_0.Signature, int_0, int_1, 30);
		}
		ataskTempl_0.Descript = TranslateTaskField(ataskTempl_0.Descript, int_0, int_1, 0);
		ataskTempl_0.OkText = TranslateTaskField(ataskTempl_0.OkText, int_0, int_1, 0);
		ataskTempl_0.NoText = TranslateTaskField(ataskTempl_0.NoText, int_0, int_1, 0);
		ataskTempl_0.Tribute = TranslateTaskField(ataskTempl_0.Tribute, int_0, int_1, 0);
		smethod_3(ataskTempl_0, int_0, int_1);
		smethod_4(ataskTempl_0.m_pTaskChar, int_0, int_1);
		smethod_4(ataskTempl_0.PersonTaskChar, int_0, int_1);
		smethod_4(ataskTempl_0.HistoryTaskChar, int_0, int_1);
		smethod_5(ataskTempl_0.m_Award_S, int_0, int_1);
		smethod_5(ataskTempl_0.m_Award_F, int_0, int_1);
		smethod_6(ataskTempl_0.m_DelvTaskTalk, int_0, int_1);
		smethod_6(ataskTempl_0.m_UnqualifiedTaskTalk, int_0, int_1);
		smethod_6(ataskTempl_0.m_DelvItemTalk, int_0, int_1);
		smethod_6(ataskTempl_0.m_ExeTalk, int_0, int_1);
		smethod_6(ataskTempl_0.m_AwardTalk, int_0, int_1);
	}

	private static void smethod_3(ATaskTempl ataskTempl_0, int int_0, int int_1)
	{
		if (ataskTempl_0 != null && ataskTempl_0.m_TaskEventName != null && ataskTempl_0.m_TaskEventName.Length != 0)
		{
			string value = tasksConvert.ShortsToUnicodeString(ataskTempl_0.m_TaskEventName);
			if (!string.IsNullOrWhiteSpace(value))
			{
				string text = TranslateTaskField(value, int_0, int_1, 30);
				ataskTempl_0.m_TaskEventName = tasksConvert.UnicodeStringToShorts(text, 30);
			}
		}
	}

	private static void smethod_4(short[][] short_0, int int_0, int int_1)
	{
		if (short_0 == null || short_0.Length == 0)
		{
			return;
		}
		for (int i = 0; i < short_0.Length; i++)
		{
			short[] array = short_0[i];
			if (array != null && array.Length != 0)
			{
				string value = tasksConvert.ShortsToUnicodeString(array);
				if (!string.IsNullOrWhiteSpace(value))
				{
					string text = TranslateTaskField(value, int_0, int_1, 64);
					short_0[i] = tasksConvert.UnicodeStringToShorts(text, 64);
				}
			}
		}
	}

	private static void smethod_5(AWARD_DATA award_DATA_0, int int_0, int int_1)
	{
		if (award_DATA_0?.AwardRandomDialogGroupData?.TextGroups == null || award_DATA_0.AwardRandomDialogGroupData.TextGroups.Count == 0)
		{
			return;
		}
		List<short[]> textGroups = award_DATA_0.AwardRandomDialogGroupData.TextGroups;
		for (int i = 0; i < textGroups.Count; i++)
		{
			short[] array = textGroups[i];
			if (array != null && array.Length != 0)
			{
				string value = tasksConvert.ShortsToUnicodeString(array);
				if (!string.IsNullOrWhiteSpace(value))
				{
					string text = TranslateTaskField(value, int_0, int_1, 100);
					textGroups[i] = tasksConvert.UnicodeStringToShorts(text, 100);
				}
			}
		}
	}

	private static void smethod_6(talk_proc talk_proc_0, int int_0, int int_1)
	{
		if (talk_proc_0 == null)
		{
			return;
		}
		talk_proc_0.DialogText = TranslateTaskField(talk_proc_0.DialogText, int_0, int_1, 64);
		if (talk_proc_0.windows == null)
		{
			return;
		}
		for (int i = 0; i < talk_proc_0.windows.Length; i++)
		{
			window window2 = talk_proc_0.windows[i];
			if (window2 == null)
			{
				continue;
			}
			window2.talktext = TranslateTaskField(window2.talktext, int_0, int_1, 0);
			if (window2.options == null)
			{
				continue;
			}
			for (int j = 0; j < window2.options.Length; j++)
			{
				option option2 = window2.options[j];
				if (option2 != null)
				{
					option2.optiontext = TranslateTaskField(option2.optiontext, int_0, int_1, 64);
				}
			}
		}
	}
}
