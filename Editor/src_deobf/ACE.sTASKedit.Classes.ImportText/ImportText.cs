using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACE.Classes;
using ACE.sTASKedit.Classes.GlobalProgramData;
using ACE.sTASKedit.tasks;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Classes.ImportText;

internal class ImportText
{
	private sealed class Class397
	{
		public ToolStripProgressBar toolStripProgressBar_0;

		internal void method_0(int int_0)
		{
			ToolStripProgressBar progressBar = toolStripProgressBar_0;
			int? value = int_0;
			ToolStripProgressBarSafe.TrySet(progressBar, null, value);
		}
	}

	private sealed class Class398
	{
		public bool bool_0;

		public BinaryReader binaryReader_0;

		public TASK_PACK_HEADER task_PACK_HEADER_0;

		public int[] int_0;

		public int int_1;

		public IProgress<int> iprogress_0;

		internal void method_0(int int_2)
		{
			byte[] buffer = null;
			lock (binaryReader_0)
			{
				binaryReader_0.BaseStream.Seek(int_0[int_2], SeekOrigin.Begin);
				int num = (int)((int_2 < int_0.Length - 1) ? int_0[int_2 + 1] : binaryReader_0.BaseStream.Length) - int_0[int_2];
				if (num < 0)
				{
					throw new InvalidDataException(Class16.smethod_0(1649263422));
				}
				buffer = binaryReader_0.ReadBytes(num);
			}
			MemoryStream memoryStream = new MemoryStream(buffer);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					ATaskTempl aTaskTempl = new ATaskTempl(task_PACK_HEADER_0.version, binaryReader);
					for (int i = 0; i < GProD.Tasks.Length; i++)
					{
						if (GProD.Tasks[i].m_ID == aTaskTempl.m_ID && GProD.Tasks[i].m_usIDSpace == aTaskTempl.m_usIDSpace)
						{
							smethod_1(GProD.Tasks[i], aTaskTempl, bool_0, task_PACK_HEADER_0.version, -1, -1);
							smethod_0(GProD.Tasks[i], aTaskTempl, bool_0, task_PACK_HEADER_0.version, -1, -1);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)binaryReader).Dispose();
				}
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
			Interlocked.Increment(ref int_1);
			if (int_1 % 100 == 0)
			{
				iprogress_0.Report(int_1 / 2);
				Application.DoEvents();
			}
		}
	}

	public static void logic_ImportTextFromOtherTask(MultiSelectTreeView treeView_tasks, ref ToolStripStatusLabel toolStripStatusLabel_Message, ToolStripProgressBar toolStripProgressBar_Progress, Cursor Cursor, int fromLanguageIndex = -1, int toLanguageIndex = -1)
	{
		Class397 @class = new Class397();
		@class.toolStripProgressBar_0 = toolStripProgressBar_Progress;
		OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Filter = Class16.smethod_0(1649263461)
		};
		if (openFileDialog.ShowDialog() != DialogResult.OK || !File.Exists(openFileDialog.FileName))
		{
			return;
		}
		Class398 class2 = new Class398();
		toolStripStatusLabel_Message.Text = GProD.TX(514);
		class2.bool_0 = false;
		if (DKBox.Show(GProD.TX(482), string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			class2.bool_0 = true;
		}
		try
		{
			_ = Cursors.WaitCursor;
			treeView_tasks.BeginBulkUpdate();
			FileStream fileStream = File.OpenRead(openFileDialog.FileName);
			class2.binaryReader_0 = new BinaryReader(fileStream);
			class2.task_PACK_HEADER_0 = new TASK_PACK_HEADER(class2.binaryReader_0);
			if (class2.task_PACK_HEADER_0.version >= 223)
			{
				class2.binaryReader_0.ReadUInt32();
			}
			if (class2.task_PACK_HEADER_0.magic != -1819966623 && class2.task_PACK_HEADER_0.magic != 0)
			{
				class2.binaryReader_0.Close();
				fileStream.Close();
				treeView_tasks.EndBulkUpdate();
				_ = Cursors.Default;
				DKBox.Show(GProD.TX(491), string.Empty);
				toolStripStatusLabel_Message.Text = GProD.TX(499);
				return;
			}
			if (!GlobalData.Versions.Contains(class2.task_PACK_HEADER_0.version))
			{
				class2.binaryReader_0.Close();
				fileStream.Close();
				treeView_tasks.EndBulkUpdate();
				_ = Cursors.Default;
				DKBox.Show(GProD.TX(470) + class2.task_PACK_HEADER_0.version, string.Empty);
				toolStripStatusLabel_Message.Text = GProD.TX(499);
				return;
			}
			if (class2.task_PACK_HEADER_0.version > GlobalData.GetMaxAllowedTaskVersion())
			{
				class2.binaryReader_0.Close();
				fileStream.Close();
				treeView_tasks.EndBulkUpdate();
				_ = Cursors.Default;
				DKBox.Show(string.Format(Class16.smethod_0(1649263494), class2.task_PACK_HEADER_0.version, GlobalData.GetMaxAllowedTaskVersion()), string.Empty);
				toolStripStatusLabel_Message.Text = GProD.TX(499);
				return;
			}
			ToolStripProgressBarSafe.TrySet(@class.toolStripProgressBar_0, GProD.Tasks.Length, 0);
			class2.int_0 = new int[class2.task_PACK_HEADER_0.item_count];
			for (int i = 0; i < class2.task_PACK_HEADER_0.item_count; i++)
			{
				class2.int_0[i] = class2.binaryReader_0.ReadInt32();
			}
			class2.iprogress_0 = new Progress<int>(@class.method_0);
			bool flag = fromLanguageIndex >= 0 && toLanguageIndex >= 0;
			class2.int_1 = 0;
			if (flag)
			{
				if (!TranslationService.TryInitializeOpenAiTranslator(out var errorMessage))
				{
					throw new InvalidOperationException(errorMessage);
				}
				for (int j = 0; j < class2.task_PACK_HEADER_0.item_count; j++)
				{
					class2.binaryReader_0.BaseStream.Seek(class2.int_0[j], SeekOrigin.Begin);
					int num = (int)((j < class2.int_0.Length - 1) ? class2.int_0[j + 1] : class2.binaryReader_0.BaseStream.Length) - class2.int_0[j];
					if (num >= 0)
					{
						byte[] buffer = class2.binaryReader_0.ReadBytes(num);
						MemoryStream memoryStream = new MemoryStream(buffer);
						try
						{
							BinaryReader binaryReader = new BinaryReader(memoryStream);
							try
							{
								ATaskTempl aTaskTempl = new ATaskTempl(class2.task_PACK_HEADER_0.version, binaryReader);
								for (int k = 0; k < GProD.Tasks.Length; k++)
								{
									if (GProD.Tasks[k].m_ID == aTaskTempl.m_ID && GProD.Tasks[k].m_usIDSpace == aTaskTempl.m_usIDSpace)
									{
										smethod_1(GProD.Tasks[k], aTaskTempl, class2.bool_0, class2.task_PACK_HEADER_0.version, fromLanguageIndex, toLanguageIndex);
										smethod_0(GProD.Tasks[k], aTaskTempl, class2.bool_0, class2.task_PACK_HEADER_0.version, fromLanguageIndex, toLanguageIndex);
										break;
									}
								}
							}
							finally
							{
								((IDisposable)binaryReader).Dispose();
							}
						}
						finally
						{
							((IDisposable)memoryStream).Dispose();
						}
						class2.int_1++;
						if (class2.int_1 % 25 == 0)
						{
							class2.iprogress_0.Report(class2.int_1 / 2);
							Application.DoEvents();
						}
						continue;
					}
					throw new InvalidDataException(Class16.smethod_0(1649263422));
				}
			}
			else
			{
				Parallel.For(0, class2.task_PACK_HEADER_0.item_count, class2.method_0);
			}
			class2.binaryReader_0.Close();
			fileStream.Close();
			for (int l = 0; l < GProD.Tasks.Length; l++)
			{
				smethod_17(GProD.Tasks[l], treeView_tasks.Nodes[l]);
				if (l % 100 == 0)
				{
					class2.iprogress_0.Report(GProD.Tasks.Length / 2 + l / 2);
					Application.DoEvents();
				}
			}
			treeView_tasks.EndBulkUpdate();
			ToolStripProgressBarSafe.Reset(@class.toolStripProgressBar_0);
			_ = Cursors.Default;
			toolStripStatusLabel_Message.Text = GProD.TX(499);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649263593));
			_ = ex.InnerException;
			treeView_tasks.EndBulkUpdate();
			_ = Cursors.Default;
			DKBox.Show(string.Format(GProD.TX(475), ex.Message), string.Empty);
		}
	}

	private static void smethod_0(ATaskTempl ataskTempl_0, ATaskTempl ataskTempl_1, bool bool_0, int int_0, int int_1, int int_2)
	{
		for (int i = 0; i < ataskTempl_1.m_nSubCount; i++)
		{
			for (int j = 0; j < ataskTempl_0.m_nSubCount; j++)
			{
				if (ataskTempl_0.pSub[j].m_ID == ataskTempl_1.pSub[i].m_ID)
				{
					smethod_1(ataskTempl_0.pSub[j], ataskTempl_1.pSub[i], bool_0, int_0, int_1, int_2);
					break;
				}
			}
			if (i < ataskTempl_0.m_nSubCount)
			{
				smethod_0(ataskTempl_0.pSub[i], ataskTempl_1.pSub[i], bool_0, int_0, int_1, int_2);
			}
		}
	}

	private static void smethod_1(ATaskTempl ataskTempl_0, ATaskTempl ataskTempl_1, bool bool_0, int int_0, int int_1, int int_2)
	{
		bool flag = int_1 >= 0 && int_2 >= 0;
		string text = ataskTempl_1.Name;
		if (flag)
		{
			text = TranslationService.TranslateTaskField(text, int_1, int_2, 30);
		}
		ataskTempl_0.Name = text;
		string text2 = ataskTempl_1.Signature;
		if (flag)
		{
			text2 = TranslationService.TranslateTaskField(text2, int_1, int_2, 30);
		}
		if (!bool_0)
		{
			if (ataskTempl_1.m_bHasSign)
			{
				ataskTempl_0.m_bHasSign = true;
				ataskTempl_0.Signature = text2;
			}
		}
		else if (ataskTempl_0.m_bHasSign && ataskTempl_1.m_bHasSign)
		{
			ataskTempl_0.Signature = text2;
		}
		if (int_0 >= 63)
		{
			for (int i = 0; i < ataskTempl_0.m_ulTaskCharCnt && i < ataskTempl_1.m_ulTaskCharCnt; i++)
			{
				ataskTempl_0.m_pTaskChar[i] = smethod_2(ataskTempl_1.m_pTaskChar[i], int_1, int_2);
			}
		}
		if (int_0 >= 178)
		{
			for (int j = 0; j < ataskTempl_0.m_ulPersonTaskCharCnt && j < ataskTempl_1.m_ulPersonTaskCharCnt; j++)
			{
				ataskTempl_0.PersonTaskChar[j] = smethod_2(ataskTempl_1.PersonTaskChar[j], int_1, int_2);
			}
		}
		if (int_0 >= 185)
		{
			for (int k = 0; k < ataskTempl_0.m_ulHistoryTaskCharCnt && k < ataskTempl_1.m_ulHistoryTaskCharCnt; k++)
			{
				ataskTempl_0.HistoryTaskChar[k] = smethod_2(ataskTempl_1.HistoryTaskChar[k], int_1, int_2);
			}
		}
		if (int_0 >= 140)
		{
			string text3 = tasksConvert.ShortsToUnicodeString(ataskTempl_1.m_TaskEventName);
			if (flag)
			{
				text3 = TranslationService.TranslateTaskField(text3, int_1, int_2, 30);
			}
			short[] taskEventName = tasksConvert.UnicodeStringToShorts(text3 ?? string.Empty, 30);
			if (!bool_0)
			{
				if (tasksConvert.ShortsToUnicodeString(ataskTempl_0.m_TaskEventName) != string.Empty && tasksConvert.ShortsToUnicodeString(ataskTempl_1.m_TaskEventName) != string.Empty)
				{
					ataskTempl_0.m_TaskEventName = taskEventName;
				}
			}
			else
			{
				ataskTempl_0.m_TaskEventName = taskEventName;
			}
		}
		smethod_4(ataskTempl_0.m_Award_S, ataskTempl_1.m_Award_S, int_1, int_2);
		smethod_4(ataskTempl_0.m_Award_F, ataskTempl_1.m_Award_F, int_1, int_2);
		if (!bool_0)
		{
			if (ataskTempl_0.m_pwstrDescript.Length != 0 && ataskTempl_1.m_pwstrDescript.Length != 0)
			{
				ataskTempl_0.Descript = (flag ? TranslationService.TranslateTaskField(ataskTempl_1.Descript, int_1, int_2, 0) : ataskTempl_1.Descript);
			}
			if (ataskTempl_0.m_pwstrOkText.Length != 0 && ataskTempl_1.m_pwstrOkText.Length != 0)
			{
				ataskTempl_0.OkText = (flag ? TranslationService.TranslateTaskField(ataskTempl_1.OkText, int_1, int_2, 0) : ataskTempl_1.OkText);
			}
			if (ataskTempl_0.m_pwstrNoText.Length != 0 && ataskTempl_1.m_pwstrNoText.Length != 0)
			{
				ataskTempl_0.NoText = (flag ? TranslationService.TranslateTaskField(ataskTempl_1.NoText, int_1, int_2, 0) : ataskTempl_1.NoText);
			}
			if (ataskTempl_0.m_pwstrTribute.Length != 0 && ataskTempl_1.m_pwstrTribute.Length != 0)
			{
				ataskTempl_0.Tribute = (flag ? TranslationService.TranslateTaskField(ataskTempl_1.Tribute, int_1, int_2, 0) : ataskTempl_1.Tribute);
			}
		}
		else
		{
			ataskTempl_0.Descript = (flag ? TranslationService.TranslateTaskField(ataskTempl_1.Descript, int_1, int_2, 0) : ataskTempl_1.Descript);
			ataskTempl_0.OkText = (flag ? TranslationService.TranslateTaskField(ataskTempl_1.OkText, int_1, int_2, 0) : ataskTempl_1.OkText);
			ataskTempl_0.NoText = (flag ? TranslationService.TranslateTaskField(ataskTempl_1.NoText, int_1, int_2, 0) : ataskTempl_1.NoText);
			ataskTempl_0.Tribute = (flag ? TranslationService.TranslateTaskField(ataskTempl_1.Tribute, int_1, int_2, 0) : ataskTempl_1.Tribute);
		}
		smethod_5(ataskTempl_0.m_DelvTaskTalk, ataskTempl_1.m_DelvTaskTalk, int_1, int_2);
		smethod_5(ataskTempl_0.m_UnqualifiedTaskTalk, ataskTempl_1.m_UnqualifiedTaskTalk, int_1, int_2);
		smethod_5(ataskTempl_0.m_DelvItemTalk, ataskTempl_1.m_DelvItemTalk, int_1, int_2);
		smethod_5(ataskTempl_0.m_ExeTalk, ataskTempl_1.m_ExeTalk, int_1, int_2);
		smethod_5(ataskTempl_0.m_AwardTalk, ataskTempl_1.m_AwardTalk, int_1, int_2);
	}

	private static short[] smethod_2(short[] short_0, int int_0, int int_1)
	{
		return smethod_3(short_0, int_0, int_1, 64);
	}

	private static short[] smethod_3(short[] short_0, int int_0, int int_1, int int_2)
	{
		if (short_0 == null)
		{
			return null;
		}
		if (int_0 < 0 || int_1 < 0)
		{
			return short_0;
		}
		string value = tasksConvert.ShortsToUnicodeString(short_0);
		if (string.IsNullOrWhiteSpace(value))
		{
			return short_0;
		}
		string text = TranslationService.TranslateTaskField(value, int_0, int_1, int_2);
		return tasksConvert.UnicodeStringToShorts(text ?? string.Empty, int_2);
	}

	private static void smethod_4(AWARD_DATA award_DATA_0, AWARD_DATA award_DATA_1, int int_0, int int_1)
	{
		if (award_DATA_0?.AwardRandomDialogGroupData?.TextGroups != null && award_DATA_1?.AwardRandomDialogGroupData?.TextGroups != null)
		{
			int num = Math.Min(award_DATA_0.AwardRandomDialogGroupData.TextGroups.Count, award_DATA_1.AwardRandomDialogGroupData.TextGroups.Count);
			for (int i = 0; i < num; i++)
			{
				award_DATA_0.AwardRandomDialogGroupData.TextGroups[i] = smethod_3(award_DATA_1.AwardRandomDialogGroupData.TextGroups[i], int_0, int_1, 100);
			}
		}
	}

	private static void smethod_5(talk_proc talk_proc_0, talk_proc talk_proc_1, int int_0, int int_1)
	{
		bool flag = int_0 >= 0 && int_1 >= 0;
		if (talk_proc_0 == null || talk_proc_1 == null)
		{
			return;
		}
		talk_proc_0.DialogText = (flag ? TranslationService.TranslateTaskField(talk_proc_1.DialogText, int_0, int_1, 64) : talk_proc_1.DialogText);
		for (int i = 0; i < talk_proc_1.num_window; i++)
		{
			for (int j = 0; j < talk_proc_0.num_window; j++)
			{
				if (talk_proc_0.windows[j].id == talk_proc_1.windows[i].id)
				{
					string talktext = talk_proc_1.windows[i].talktext;
					talk_proc_0.windows[j].talktext = (flag ? TranslationService.TranslateTaskField(talktext, int_0, int_1, 0) : talktext);
					for (int k = 0; k < talk_proc_0.windows[j].num_option && k < talk_proc_1.windows[i].num_option; k++)
					{
						string optiontext = talk_proc_1.windows[i].options[k].optiontext;
						talk_proc_0.windows[j].options[k].optiontext = (flag ? TranslationService.TranslateTaskField(optiontext, int_0, int_1, 64) : optiontext);
					}
				}
			}
		}
	}

	public static void logic_ExportTaskTextsToTxt(TreeView treeView_tasks, ref ToolStripStatusLabel toolStripStatusLabel_Message, ToolStripProgressBar toolStripProgressBar_Progress)
	{
		if (GProD.Tasks != null && GProD.Tasks.Length != 0)
		{
			using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
			{
				folderBrowserDialog.Description = TextStorage.Msg(Class16.smethod_0(1649262617), Class16.smethod_0(1649262669));
				if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
				{
					string selectedPath = folderBrowserDialog.SelectedPath;
					toolStripStatusLabel_Message.Text = TextStorage.Msg(Class16.smethod_0(1649262715));
					try
					{
						ToolStripProgressBarSafe.TrySet(toolStripProgressBar_Progress, GProD.Tasks.Length, 0);
						for (int i = 0; i < GProD.Tasks.Length; i++)
						{
							ATaskTempl aTaskTempl = GProD.Tasks[i];
							if (aTaskTempl != null)
							{
								smethod_6(aTaskTempl, selectedPath);
								smethod_7(aTaskTempl, selectedPath);
							}
							int? value = i + 1;
							ToolStripProgressBarSafe.TrySet(toolStripProgressBar_Progress, null, value);
							Application.DoEvents();
						}
						ToolStripProgressBarSafe.Reset(toolStripProgressBar_Progress);
						toolStripStatusLabel_Message.Text = TextStorage.Msg(Class16.smethod_0(1649262737));
						DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649262773), Class16.smethod_0(1649262817)), selectedPath), Class16.smethod_0(1649262864), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					catch (Exception ex)
					{
						SentryHelper.CaptureException(ex, Class16.smethod_0(1649263593));
						ToolStripProgressBarSafe.Reset(toolStripProgressBar_Progress);
						toolStripStatusLabel_Message.Text = TextStorage.Msg(Class16.smethod_0(1649262895));
						DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649262912), Class16.smethod_0(1649262958)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
				}
				return;
			}
		}
		DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649263610)), Class16.smethod_0(1648943018), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	private static void smethod_6(ATaskTempl ataskTempl_0, string string_0)
	{
		string path = System.IO.Path.Combine(string_0, string.Format(Class16.smethod_0(1649262991), ataskTempl_0.m_ID));
		StreamWriter streamWriter = new StreamWriter(path, append: false, Encoding.UTF8);
		try
		{
			streamWriter.WriteLine(string.Format(Class16.smethod_0(1649263005), ataskTempl_0.m_ID));
			streamWriter.WriteLine(Class16.smethod_0(1649263020) + ataskTempl_0.Name);
			streamWriter.WriteLine(Class16.smethod_0(1649263036) + ataskTempl_0.Descript);
			streamWriter.WriteLine(Class16.smethod_0(1649263051) + ataskTempl_0.OkText);
			streamWriter.WriteLine(Class16.smethod_0(1649263072) + ataskTempl_0.NoText);
			streamWriter.WriteLine(Class16.smethod_0(1649263101) + ataskTempl_0.Tribute);
			smethod_8(streamWriter, Class16.smethod_0(1649266187), ataskTempl_0.m_DelvTaskTalk, ataskTempl_0.m_ID);
			smethod_8(streamWriter, Class16.smethod_0(1649266208), ataskTempl_0.m_UnqualifiedTaskTalk, ataskTempl_0.m_ID);
			smethod_8(streamWriter, Class16.smethod_0(1649266244), ataskTempl_0.m_DelvItemTalk, ataskTempl_0.m_ID);
			smethod_8(streamWriter, Class16.smethod_0(1649266257), ataskTempl_0.m_ExeTalk, ataskTempl_0.m_ID);
			smethod_8(streamWriter, Class16.smethod_0(1649266273), ataskTempl_0.m_AwardTalk, ataskTempl_0.m_ID);
		}
		finally
		{
			((IDisposable)streamWriter).Dispose();
		}
	}

	private static void smethod_7(ATaskTempl ataskTempl_0, string string_0)
	{
		if (ataskTempl_0.pSub == null || ataskTempl_0.pSub.Length == 0)
		{
			return;
		}
		for (int i = 0; i < ataskTempl_0.pSub.Length; i++)
		{
			if (ataskTempl_0.pSub[i] != null)
			{
				smethod_6(ataskTempl_0.pSub[i], string_0);
				smethod_7(ataskTempl_0.pSub[i], string_0);
			}
		}
	}

	private static void smethod_8(StreamWriter streamWriter_0, string string_0, talk_proc talk_proc_0, int int_0)
	{
		if (talk_proc_0 == null)
		{
			return;
		}
		streamWriter_0.WriteLine(string_0 + Class16.smethod_0(1649266291) + talk_proc_0.DialogText);
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
			streamWriter_0.WriteLine(string.Format(Class16.smethod_0(1649266318), string_0, i, window2.talktext));
			if (window2.options == null)
			{
				continue;
			}
			for (int j = 0; j < window2.options.Length; j++)
			{
				option option2 = window2.options[j];
				if (option2 != null)
				{
					streamWriter_0.WriteLine(string.Format(Class16.smethod_0(1649266345), string_0, i, j, option2.optiontext));
				}
			}
		}
	}

	public static void logic_ImportTaskTextsFromTxt(MultiSelectTreeView treeView_tasks, ref ToolStripStatusLabel toolStripStatusLabel_Message, ToolStripProgressBar toolStripProgressBar_Progress, int fromLanguageIndex = -1, int toLanguageIndex = -1)
	{
		if (GProD.Tasks != null && GProD.Tasks.Length != 0)
		{
			using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
			{
				folderBrowserDialog.Description = TextStorage.Msg(Class16.smethod_0(1649266425), Class16.smethod_0(1649266474));
				if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
				{
					string selectedPath = folderBrowserDialog.SelectedPath;
					toolStripStatusLabel_Message.Text = TextStorage.Msg(Class16.smethod_0(1649266529));
					try
					{
						string[] files = Directory.GetFiles(selectedPath, Class16.smethod_0(1649266559));
						if (files.Length == 0)
						{
							DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649266563)), Class16.smethod_0(1648943018), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						else
						{
							ToolStripProgressBarSafe.TrySet(toolStripProgressBar_Progress, files.Length, 0);
							int num = 0;
							if (fromLanguageIndex >= 0 && toLanguageIndex >= 0 && !TranslationService.TryInitializeOpenAiTranslator(out var errorMessage))
							{
								throw new InvalidOperationException(errorMessage);
							}
							string[] array = files;
							foreach (string text in array)
							{
								string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(text);
								if (int.TryParse(fileNameWithoutExtension, out var result))
								{
									ATaskTempl aTaskTempl = smethod_9(result);
									if (aTaskTempl != null)
									{
										smethod_10(aTaskTempl, text, fromLanguageIndex, toLanguageIndex);
										num++;
									}
								}
								ToolStripProgressBarSafe.Increment(toolStripProgressBar_Progress);
								Application.DoEvents();
							}
							treeView_tasks.BeginBulkUpdate();
							for (int j = 0; j < GProD.Tasks.Length; j++)
							{
								smethod_15(GProD.Tasks[j], treeView_tasks.Nodes[j]);
							}
							treeView_tasks.EndBulkUpdate();
							ToolStripProgressBarSafe.Reset(toolStripProgressBar_Progress);
							toolStripStatusLabel_Message.Text = TextStorage.Msg(Class16.smethod_0(1649266596));
							DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649266616), Class16.smethod_0(1649266675)), num, files.Length), Class16.smethod_0(1649265715), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						return;
					}
					catch (Exception ex)
					{
						SentryHelper.CaptureException(ex, Class16.smethod_0(1649265738));
						ToolStripProgressBarSafe.Reset(toolStripProgressBar_Progress);
						toolStripStatusLabel_Message.Text = TextStorage.Msg(Class16.smethod_0(1649265783));
						DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649265800), Class16.smethod_0(1649265846)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
				}
				return;
			}
		}
		DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649266394)), Class16.smethod_0(1648943018), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	private static ATaskTempl smethod_9(int int_0)
	{
		int num = 0;
		ATaskTempl aTaskTempl2;
		while (true)
		{
			if (num < GProD.Tasks.Length)
			{
				ATaskTempl aTaskTempl = GProD.Tasks[num];
				if (aTaskTempl == null || aTaskTempl.m_ID != int_0)
				{
					aTaskTempl2 = smethod_16(aTaskTempl, int_0);
					if (aTaskTempl2 != null)
					{
						break;
					}
					num++;
					continue;
				}
				return aTaskTempl;
			}
			return null;
		}
		return aTaskTempl2;
	}

	private static void smethod_10(ATaskTempl ataskTempl_0, string string_0, int int_0, int int_1)
	{
		string[] array = File.ReadAllLines(string_0, Encoding.UTF8);
		Dictionary<string, Dictionary<string, string>> dictionary_ = new Dictionary<string, Dictionary<string, string>>();
		bool flag = int_0 >= 0 && int_1 >= 0;
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (string.IsNullOrWhiteSpace(text) || !text.Contains(Class16.smethod_0(1648908627)))
			{
				continue;
			}
			string[] array3 = text.Split(new char[1] { '=' }, 2);
			if (array3.Length != 2)
			{
				continue;
			}
			string text2 = array3[0].Trim();
			string text3 = array3[1];
			if (!(text2 == Class16.smethod_0(1649265879)))
			{
				if (!(text2 == Class16.smethod_0(1649265894)))
				{
					if (!(text2 == Class16.smethod_0(1649265916)))
					{
						if (!(text2 == Class16.smethod_0(1649265928)))
						{
							if (!(text2 == Class16.smethod_0(1649265956)))
							{
								if (text2.Contains(Class16.smethod_0(1648928036)))
								{
									smethod_11(text2, text3, dictionary_);
								}
							}
							else
							{
								ataskTempl_0.Tribute = (flag ? TranslationService.TranslateTaskField(text3, int_0, int_1, 0) : text3);
							}
						}
						else
						{
							ataskTempl_0.NoText = (flag ? TranslationService.TranslateTaskField(text3, int_0, int_1, 0) : text3);
						}
					}
					else
					{
						ataskTempl_0.OkText = (flag ? TranslationService.TranslateTaskField(text3, int_0, int_1, 0) : text3);
					}
				}
				else
				{
					ataskTempl_0.Descript = (flag ? TranslationService.TranslateTaskField(text3, int_0, int_1, 0) : text3);
				}
			}
			else
			{
				ataskTempl_0.Name = (flag ? TranslationService.TranslateTaskField(text3, int_0, int_1, 30) : text3);
			}
		}
		smethod_12(ataskTempl_0, dictionary_, int_0, int_1);
	}

	private static void smethod_11(string string_0, string string_1, Dictionary<string, Dictionary<string, string>> dictionary_0)
	{
		string[] array = string_0.Split('.');
		if (array.Length >= 2)
		{
			string key = array[0];
			if (!dictionary_0.ContainsKey(key))
			{
				dictionary_0[key] = new Dictionary<string, string>();
			}
			string key2 = string.Join(Class16.smethod_0(1648928036), array.Skip(1));
			dictionary_0[key][key2] = string_1;
		}
	}

	private static void smethod_12(ATaskTempl ataskTempl_0, Dictionary<string, Dictionary<string, string>> dictionary_0, int int_0, int int_1)
	{
		foreach (KeyValuePair<string, Dictionary<string, string>> item in dictionary_0)
		{
			string key = item.Key;
			Dictionary<string, string> value = item.Value;
			talk_proc talk_proc2 = smethod_13(ataskTempl_0, key);
			if (talk_proc2 != null)
			{
				smethod_14(talk_proc2, value, ataskTempl_0.m_ID, int_0, int_1);
			}
		}
	}

	private static talk_proc smethod_13(ATaskTempl ataskTempl_0, string string_0)
	{
		if (!(string_0 == Class16.smethod_0(1649266187)))
		{
			if (!(string_0 == Class16.smethod_0(1649266208)))
			{
				if (!(string_0 == Class16.smethod_0(1649266244)))
				{
					if (!(string_0 == Class16.smethod_0(1649266257)))
					{
						if (!(string_0 == Class16.smethod_0(1649266273)))
						{
							return null;
						}
						return ataskTempl_0.m_AwardTalk;
					}
					return ataskTempl_0.m_ExeTalk;
				}
				return ataskTempl_0.m_DelvItemTalk;
			}
			return ataskTempl_0.m_UnqualifiedTaskTalk;
		}
		return ataskTempl_0.m_DelvTaskTalk;
	}

	private static void smethod_14(talk_proc talk_proc_0, Dictionary<string, string> dictionary_0, int int_0, int int_1, int int_2)
	{
		bool flag = int_1 >= 0 && int_2 >= 0;
		talk_proc_0.crypt_key = int_0;
		foreach (KeyValuePair<string, string> item in dictionary_0)
		{
			string key = item.Key;
			string value = item.Value;
			if (key == Class16.smethod_0(1649265969))
			{
				talk_proc_0.DialogText = (flag ? TranslationService.TranslateTaskField(value, int_1, int_2, 64) : value);
			}
			else
			{
				if (!key.StartsWith(Class16.smethod_0(1649265986)) || !key.Contains(Class16.smethod_0(1649269599)))
				{
					continue;
				}
				Match match = Regex.Match(key, Class16.smethod_0(1649266000));
				if (!match.Success)
				{
					continue;
				}
				int num = int.Parse(match.Groups[1].Value);
				string value2 = match.Groups[2].Value;
				if (talk_proc_0.windows == null || num >= talk_proc_0.windows.Length)
				{
					continue;
				}
				window window2 = talk_proc_0.windows[num];
				window2.crypt_key = int_0;
				if (value2 == Class16.smethod_0(1649266036))
				{
					window2.talktext = (flag ? TranslationService.TranslateTaskField(value, int_1, int_2, 0) : value);
				}
				else
				{
					if (!value2.StartsWith(Class16.smethod_0(1649266043)) || !value2.Contains(Class16.smethod_0(1649266057)))
					{
						continue;
					}
					Match match2 = Regex.Match(value2, Class16.smethod_0(1649266084));
					if (match2.Success)
					{
						int num2 = int.Parse(match2.Groups[1].Value);
						if (window2.options != null && num2 < window2.options.Length)
						{
							option option2 = window2.options[num2];
							option2.crypt_key = int_0;
							option2.optiontext = (flag ? TranslationService.TranslateTaskField(value, int_1, int_2, 64) : value);
						}
					}
				}
			}
		}
	}

	private static void smethod_15(ATaskTempl ataskTempl_0, TreeNode treeNode_0)
	{
		if (ataskTempl_0 == null || treeNode_0 == null)
		{
			return;
		}
		GlobalFunctions.UpdateNode(treeNode_0, ataskTempl_0, 0, GProD.imageList2.Images.Count - 2, GProD.imageList2.Images.Count - 1);
		if (ataskTempl_0.pSub != null && ataskTempl_0.pSub.Length != 0)
		{
			for (int i = 0; i < ataskTempl_0.pSub.Length && i < treeNode_0.Nodes.Count; i++)
			{
				smethod_15(ataskTempl_0.pSub[i], treeNode_0.Nodes[i]);
			}
		}
	}

	private static ATaskTempl smethod_16(ATaskTempl ataskTempl_0, int int_0)
	{
		if (ataskTempl_0?.pSub != null)
		{
			for (int i = 0; i < ataskTempl_0.pSub.Length; i++)
			{
				ATaskTempl aTaskTempl = ataskTempl_0.pSub[i];
				if (aTaskTempl != null)
				{
					if (aTaskTempl.m_ID == int_0)
					{
						return aTaskTempl;
					}
					ATaskTempl aTaskTempl2 = smethod_16(aTaskTempl, int_0);
					if (aTaskTempl2 != null)
					{
						return aTaskTempl2;
					}
				}
			}
		}
		return null;
	}

	[CompilerGenerated]
	internal static void smethod_17(ATaskTempl Task, TreeNode Node)
	{
		GlobalFunctions.UpdateNode(Node, Task, 0, GProD.imageList2.Images.Count - 2, GProD.imageList2.Images.Count - 1);
		if (Task.pSub.Length != 0)
		{
			for (int i = 0; i < Task.pSub.Length; i++)
			{
				smethod_17(Task.pSub[i], Node.Nodes[i]);
			}
		}
	}
}
