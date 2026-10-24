using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Classes.Localization;
using ACE.sTASKedit.Classes.Extensions;
using ACE.sTASKedit.Classes.GlobalProgramData;
using ACE.sTASKedit.MainEditor;
using ACE.sTASKedit.tasks;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Classes.LoadFiles;

public class LoadFiles
{
	private sealed class Class399
	{
		public Exception exception_0;

		public int int_0;

		public Class402 class402_0;

		internal void method_0(int int_1, ParallelLoopState parallelLoopState_0)
		{
			if (exception_0 != null)
			{
				parallelLoopState_0.Stop();
				return;
			}
			if (!smethod_0(class402_0.int_0, int_1, class402_0.long_0, class402_0.int_1, out var int_2, out var int_3))
			{
				if (!class402_0.class400_0.bool_0)
				{
					Interlocked.CompareExchange(ref exception_0, new InvalidDataException(TextStorage.TEXTS.GetText("ui.tasks.invalid_record_index", int_1)), null);
					parallelLoopState_0.Stop();
				}
				Interlocked.Increment(ref int_0);
				return;
			}
			byte[] array;
			lock (class402_0.binaryReader_0)
			{
				class402_0.binaryReader_0.BaseStream.Seek(int_2, SeekOrigin.Begin);
				array = class402_0.binaryReader_0.ReadBytes(int_3);
			}
			if (array.Length != int_3)
			{
				if (!class402_0.class400_0.bool_0)
				{
					Interlocked.CompareExchange(ref exception_0, new EndOfStreamException(string.Format(Class16.smethod_0(1649265168), int_1)), null);
					parallelLoopState_0.Stop();
				}
				Interlocked.Increment(ref int_0);
				return;
			}
			MemoryStream memoryStream = new MemoryStream(array);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					if (class402_0.class400_0.bool_0)
					{
						try
						{
							GProD.Tasks[int_1] = new ATaskTempl(class402_0.task_PACK_HEADER_0.version, binaryReader);
						}
						catch (Exception ex)
						{
							SentryHelper.CaptureException(ex, Class16.smethod_0(1649265249));
							if (GProD.Debug)
							{
								ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(Class16.smethod_0(1649265275) + int_1);
							}
						}
					}
					else
					{
						try
						{
							GProD.Tasks[int_1] = new ATaskTempl(class402_0.task_PACK_HEADER_0.version, binaryReader);
						}
						catch (Exception value)
						{
							Interlocked.CompareExchange(ref exception_0, value, null);
							parallelLoopState_0.Stop();
							return;
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
			int num = Interlocked.Increment(ref int_0);
			if (num % 100 == 0)
			{
				class402_0.iprogress_0.Report(num / 2);
			}
		}
	}

	private sealed class Class400
	{
		public ACE.sTASKedit.MainEditor.MainEditor mainEditor_0;

		public bool bool_0;

		internal void method_0(int int_0)
		{
			ToolStripProgressBar toolStripProgressBar_Progress = mainEditor_0.toolStripProgressBar_Progress;
			int? value = int_0;
			ToolStripProgressBarSafe.TrySet(toolStripProgressBar_Progress, null, value);
		}
	}

	[Serializable]
	private sealed class Class401
	{
		public static readonly Class401 class401_0 = new Class401();

		public static Func<ATaskTempl, bool> func_0;

		internal bool method_0(ATaskTempl ataskTempl_0)
		{
			return ataskTempl_0 != null;
		}
	}

	private sealed class Class402
	{
		public BinaryReader binaryReader_0;

		public TASK_PACK_HEADER task_PACK_HEADER_0;

		public int[] int_0;

		public long long_0;

		public int int_1;

		public IProgress<int> iprogress_0;

		public List<ATaskTempl> list_0;

		public Class400 class400_0;

		internal void method_0(ATaskTempl ataskTempl_0)
		{
			if (ataskTempl_0 == null)
			{
				return;
			}
			list_0.Add(ataskTempl_0);
			if (ataskTempl_0.pSub != null && ataskTempl_0.pSub.Length != 0)
			{
				for (int i = 0; i < ataskTempl_0.pSub.Length; i++)
				{
					method_0(ataskTempl_0.pSub[i]);
				}
			}
		}
	}

	private static bool smethod_0(int[] int_0, int int_1, long long_0, int int_2, out int int_3, out int int_4)
	{
		int_3 = 0;
		int_4 = 0;
		if (int_0 != null && int_1 >= 0 && int_1 < int_0.Length)
		{
			int_3 = int_0[int_1];
			int num = (int)((int_1 < int_0.Length - 1) ? int_0[int_1 + 1] : long_0);
			if (int_3 >= int_2 && int_3 <= long_0 && num >= int_3 && num <= long_0)
			{
				int_4 = num - int_3;
				return int_4 >= 0;
			}
			return false;
		}
		return false;
	}

	private static void smethod_1(int[] int_0, long long_0, int int_1)
	{
		int num = 0;
		while (true)
		{
			if (num < int_0.Length)
			{
				if (!smethod_0(int_0, num, long_0, int_1, out var _, out var _))
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		throw new InvalidDataException(TextStorage.TEXTS.GetText("ui.tasks.invalid_record_index", num));
	}

	public static void LoadTasks(ACE.sTASKedit.MainEditor.MainEditor MainWindow, string FileName, int TaskIdSpace, int TaskId, Cursor Cursor, bool parallel = true, bool skipBrokenTasks = false)
	{
		Class400 @class = new Class400();
		@class.mainEditor_0 = MainWindow;
		@class.bool_0 = skipBrokenTasks;
		if (string.IsNullOrWhiteSpace(Settings.Fields.FilesPath.TasksPath) || !File.Exists(FileName) || @class.mainEditor_0 == null || @class.mainEditor_0.IsDisposed)
		{
			return;
		}
		@class.mainEditor_0.toolStripStatusLabel_Message.Text = GProD.TX(500);
		try
		{
			Class402 class2 = new Class402();
			class2.class400_0 = @class;
			_ = Cursors.WaitCursor;
			FileStream fileStream = File.OpenRead(FileName);
			class2.binaryReader_0 = new BinaryReader(fileStream);
			class2.task_PACK_HEADER_0 = new TASK_PACK_HEADER(class2.binaryReader_0);
			if (class2.task_PACK_HEADER_0.magic != -1819966623 && class2.task_PACK_HEADER_0.magic != 0)
			{
				class2.binaryReader_0.Close();
				fileStream.Close();
				_ = Cursors.Default;
				DKBox.Show(GProD.TX(491), string.Empty);
				class2.class400_0.mainEditor_0.toolStripStatusLabel_Message.Text = GProD.TX(499);
				return;
			}
			if (!GlobalData.Versions.Contains(class2.task_PACK_HEADER_0.version))
			{
				class2.binaryReader_0.Close();
				fileStream.Close();
				_ = Cursors.Default;
				DKBox.Show(GProD.TX(470) + class2.task_PACK_HEADER_0.version, string.Empty);
				class2.class400_0.mainEditor_0.toolStripStatusLabel_Message.Text = GProD.TX(499);
				return;
			}
			if (class2.task_PACK_HEADER_0.version > GlobalData.GetMaxAllowedTaskVersion())
			{
				class2.binaryReader_0.Close();
				fileStream.Close();
				_ = Cursors.Default;
				DKBox.Show(TextStorage.TEXTS.GetText("ui.tasks.unsupported_future_version", class2.task_PACK_HEADER_0.version, GlobalData.GetMaxAllowedTaskVersion()), string.Empty);
				class2.class400_0.mainEditor_0.toolStripStatusLabel_Message.Text = GProD.TX(499);
				return;
			}
			class2.class400_0.mainEditor_0.dataGridView_ExtendedSearchResult.Rows.Clear();
			ACE.sTASKedit.MainEditor.MainEditor.LoadedTask = false;
			GlobalData.NewID = 0;
			GlobalData.version = class2.task_PACK_HEADER_0.version;
			if (class2.task_PACK_HEADER_0.version >= 223)
			{
				GlobalData.data_size = class2.binaryReader_0.ReadInt32();
			}
			ToolStripProgressBarSafe.TrySet(class2.class400_0.mainEditor_0.toolStripProgressBar_Progress, class2.task_PACK_HEADER_0.item_count, 0);
			class2.int_0 = new int[class2.task_PACK_HEADER_0.item_count];
			for (int i = 0; i < class2.task_PACK_HEADER_0.item_count; i++)
			{
				class2.int_0[i] = class2.binaryReader_0.ReadInt32();
			}
			class2.long_0 = class2.binaryReader_0.BaseStream.Length;
			class2.int_1 = (int)class2.binaryReader_0.BaseStream.Position;
			if (!class2.class400_0.bool_0)
			{
				smethod_1(class2.int_0, class2.long_0, class2.int_1);
			}
			GProD.Tasks = new ATaskTempl[class2.task_PACK_HEADER_0.item_count];
			class2.iprogress_0 = new Progress<int>(class2.class400_0.method_0);
			if (parallel)
			{
				Class399 class3 = new Class399();
				class3.class402_0 = class2;
				class3.int_0 = 0;
				class3.exception_0 = null;
				Parallel.For(0, class3.class402_0.task_PACK_HEADER_0.item_count, class3.method_0);
				if (class3.exception_0 != null)
				{
					throw class3.exception_0;
				}
			}
			else
			{
				for (int j = 0; j < class2.task_PACK_HEADER_0.item_count; j++)
				{
					if (!smethod_0(class2.int_0, j, class2.long_0, class2.int_1, out var int_, out var _))
					{
						if (!class2.class400_0.bool_0)
						{
								throw new InvalidDataException(TextStorage.TEXTS.GetText("ui.tasks.invalid_record_index", j));
						}
						continue;
					}
					if (class2.class400_0.bool_0)
					{
						try
						{
							GProD.Tasks[j] = new ATaskTempl(class2.task_PACK_HEADER_0.version, class2.binaryReader_0, int_);
						}
						catch (Exception ex)
						{
							SentryHelper.CaptureException(ex, Class16.smethod_0(1649265249));
							if (GProD.Debug)
							{
								ACE.sTASKedit.Classes.Extensions.Extensions.WriteLog(Class16.smethod_0(1649265275) + j);
							}
						}
					}
					else
					{
						GProD.Tasks[j] = new ATaskTempl(class2.task_PACK_HEADER_0.version, class2.binaryReader_0, int_);
					}
					if (j % 100 == 0)
					{
						class2.iprogress_0.Report(j / 2);
						Application.DoEvents();
					}
				}
			}
			class2.binaryReader_0.Close();
			fileStream.Close();
			if (class2.class400_0.bool_0)
			{
				GProD.Tasks = GProD.Tasks.Where(Class401.class401_0.method_0).ToArray();
			}
			class2.list_0 = new List<ATaskTempl>(GProD.Tasks.Length);
			for (int k = 0; k < GProD.Tasks.Length; k++)
			{
				class2.method_0(GProD.Tasks[k]);
			}
			Dictionary<string, List<ATaskTempl>> dictionary = new Dictionary<string, List<ATaskTempl>>();
			for (int l = 0; l < class2.list_0.Count; l++)
			{
				ATaskTempl aTaskTempl = class2.list_0[l];
				string key = aTaskTempl.m_usIDSpace + Class16.smethod_0(1648924402) + aTaskTempl.m_ID;
				if (!dictionary.TryGetValue(key, out var value))
				{
					value = (dictionary[key] = new List<ATaskTempl>());
				}
				value.Add(aTaskTempl);
			}
			List<string> list2 = new List<string>();
			bool usePortugueseFallback = TextStorage.TEXTS != null
				&& !string.IsNullOrWhiteSpace(TextStorage.TEXTS.CurrentLocaleCode)
				&& TextStorage.TEXTS.CurrentLocaleCode.StartsWith("pt", StringComparison.OrdinalIgnoreCase);
			foreach (KeyValuePair<string, List<ATaskTempl>> item in dictionary)
			{
				if (item.Value.Count > 1)
				{
					for (int m = 0; m < item.Value.Count; m++)
					{
						item.Value[m].IsDuplicateId = true;
					}
					string entry = TextStorage.TEXTS.GetText("ui.tasks.duplicate_ids.entry", item.Value[0].m_ID, item.Value[0].m_usIDSpace, item.Value.Count);
					if (string.IsNullOrWhiteSpace(entry))
					{
						entry = usePortugueseFallback
							? string.Format("- ID {0}, espaço {1} ({2} ocorrências)", item.Value[0].m_ID, item.Value[0].m_usIDSpace, item.Value.Count)
							: string.Format("- ID {0}, space {1} ({2} occurrences)", item.Value[0].m_ID, item.Value[0].m_usIDSpace, item.Value.Count);
					}
					list2.Add(entry);
				}
			}
			if (list2.Count > 0)
			{
				string text = TextStorage.TEXTS.GetText("ui.tasks.duplicate_ids.warning");
				if (string.IsNullOrWhiteSpace(text))
				{
					text = usePortugueseFallback
						? "Aviso: foram encontradas tarefas com o mesmo ID e espaço."
						: "Warning: tasks were found with the same ID and space.";
				}
				int num = Math.Min(10, list2.Count);
				for (int n = 0; n < num; n++)
				{
					text += Environment.NewLine + list2[n];
				}
				if (list2.Count > num)
				{
					string more = TextStorage.TEXTS.GetText("ui.tasks.duplicate_ids.more", list2.Count - num);
					if (string.IsNullOrWhiteSpace(more))
					{
						more = usePortugueseFallback
							? string.Format("... e mais {0} grupo(s) duplicado(s).", list2.Count - num)
							: string.Format("... and {0} more duplicate group(s).", list2.Count - num);
					}
					text += Environment.NewLine + more;
				}
				string guidanceQuestion = TextStorage.TEXTS.GetText("ui.tasks.duplicate_ids.ask_guidance");
				if (string.IsNullOrWhiteSpace(guidanceQuestion))
				{
					guidanceQuestion = usePortugueseFallback
						? Environment.NewLine + Environment.NewLine + "Deseja ver orientações para corrigir? Sim: abrir instruções. Não: continuar sem alterar os dados."
						: Environment.NewLine + Environment.NewLine + "Would you like correction guidance? Yes: open instructions. No: continue without changing data.";
				}
				text += guidanceQuestion;
				string title = TextStorage.TEXTS.GetText("ui.tasks.duplicate_ids.title");
				if (string.IsNullOrWhiteSpace(title))
				{
					title = usePortugueseFallback ? "IDs de tarefas duplicados" : "Duplicate task IDs";
				}
				string yesText = TextStorage.TEXTS.GetText("ui.tasks.duplicate_ids.button_yes");
				string noText = TextStorage.TEXTS.GetText("ui.tasks.duplicate_ids.button_no");
				if (string.IsNullOrWhiteSpace(yesText)) yesText = usePortugueseFallback ? "Sim" : "Yes";
				if (string.IsNullOrWhiteSpace(noText)) noText = usePortugueseFallback ? "Não" : "No";
				if (DKBox.ShowYesNo(text, title, MessageBoxIcon.Exclamation, yesText, noText) == DialogResult.Yes)
				{
					string guidanceTitle = TextStorage.TEXTS.GetText("ui.tasks.duplicate_ids.guidance_title");
					string guidance = TextStorage.TEXTS.GetText("ui.tasks.duplicate_ids.guidance");
					if (string.IsNullOrWhiteSpace(guidanceTitle)) guidanceTitle = usePortugueseFallback ? "Como resolver IDs duplicados" : "How to resolve duplicate IDs";
					if (string.IsNullOrWhiteSpace(guidance))
					{
						guidance = usePortugueseFallback
							? "Faça uma cópia de segurança, pesquise o ID e compare as tarefas marcadas em vermelho/negrito. Se ambas precisarem existir, atribua um ID livre a uma delas e atualize as referências correspondentes. O Editor não corrige automaticamente porque não consegue determinar qual tarefa cada referência pretendia usar. Nenhum dado foi alterado por este aviso."
							: "Make a backup, search for the ID, and compare the tasks marked in red/bold. If both tasks must exist, assign an unused ID to one and update the matching references. The editor cannot fix this automatically because it cannot determine which task each reference was meant to use. This warning did not change any data.";
					}
					DKBox.Show(guidance, guidanceTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			class2.class400_0.mainEditor_0.comboBox_m_ulType_Filling();
			class2.class400_0.mainEditor_0.treeView_tasks.BeginBulkUpdate();
			class2.class400_0.mainEditor_0.treeView_tasks.Nodes.Clear();
			for (int num2 = 0; num2 < GProD.Tasks.Length; num2++)
			{
				ATaskTempl aTaskTempl2 = GProD.Tasks[num2];
				aTaskTempl2.AddNode(class2.class400_0.mainEditor_0.treeView_tasks.Nodes, GProD.imageList2.Images.Count - 2, GProD.imageList2.Images.Count - 1);
				if (aTaskTempl2.pSub.Length != 0)
				{
					smethod_2(aTaskTempl2.pSub, class2.class400_0.mainEditor_0.treeView_tasks.Nodes[num2].Nodes, GProD.imageList2.Images.Count - 2, GProD.imageList2.Images.Count - 1);
				}
				if (num2 % 100 == 0)
				{
					class2.iprogress_0.Report(GProD.Tasks.Length / 2 + num2 / 2);
					Application.DoEvents();
				}
			}
			class2.class400_0.mainEditor_0.treeView_tasks.EndBulkUpdate();
			ACE.sTASKedit.MainEditor.MainEditor.LoadedTask = true;
			if (ACE.sTASKedit.MainEditor.MainEditor.LoadedTask && ACE.sTASKedit.MainEditor.MainEditor.LoadedElements)
			{
				class2.class400_0.mainEditor_0.Text = string.Format(GProD.TX(471), Class16.smethod_0(1648942211) + FileName + Class16.smethod_0(1649140960) + Settings.Fields.FilesPath.ElementsPath);
			}
			else
			{
				class2.class400_0.mainEditor_0.Text = string.Format(GProD.TX(471), Class16.smethod_0(1648942211) + FileName);
			}
			class2.class400_0.mainEditor_0.GoToTask(TaskIdSpace.ToString(), TaskId.ToString());
			ToolStripProgressBar toolStripProgressBar_Progress = class2.class400_0.mainEditor_0.toolStripProgressBar_Progress;
			int? value2 = 0;
			ToolStripProgressBarSafe.TrySet(toolStripProgressBar_Progress, null, value2);
			_ = Cursors.Default;
			if (TaskId <= 0 && class2.class400_0.mainEditor_0.treeView_tasks.Nodes.Count > 0)
			{
				class2.class400_0.mainEditor_0.treeView_tasks.SelectedNode = class2.class400_0.mainEditor_0.treeView_tasks.Nodes[0];
			}
			class2.class400_0.mainEditor_0.listBox_Talks.SelectedIndex = 0;
			if (Settings.Fields.EnableAutoDetectNewID)
			{
				class2.class400_0.mainEditor_0.numericUpDown_NewID.Value = GlobalData.NewID + 1;
			}
			class2.class400_0.mainEditor_0.numericUpDown_m_ulPremise_Task_Least_Num.Maximum = GlobalFunctions.GetMaxPremTaskCount(class2.task_PACK_HEADER_0.version);
			class2.class400_0.mainEditor_0.numericUpDown_Award_m_ulCandItems.Maximum = GlobalFunctions.GetMaxAwardCandidates(class2.task_PACK_HEADER_0.version);
			class2.class400_0.mainEditor_0.toolStripStatusLabel_TaskCount.Text = GProD.TX(479) + GProD.Tasks.Length;
			class2.class400_0.mainEditor_0.toolStripStatusLabel_TaskVersion.Text = GProD.TX(480) + class2.task_PACK_HEADER_0.version;
			class2.class400_0.mainEditor_0.toolStripStatusLabel_Message.Text = GProD.TX(499);
			class2.class400_0.mainEditor_0.UpdateVersionDisplay();
			class2.class400_0.mainEditor_0.ShowTaskVersionCompatibilityNotice();
		}
		catch (Exception ex2)
		{
			SentryHelper.CaptureException(ex2, Class16.smethod_0(1649265437));
			@class.mainEditor_0.treeView_tasks.EndBulkUpdate();
			_ = Cursors.Default;
			string errorDetail = string.IsNullOrWhiteSpace(ex2.Message) ? ex2.GetType().FullName : ex2.GetType().Name + ": " + ex2.Message;
			string errorMessage;
			try
			{
				errorMessage = string.Format(GProD.TX(475), errorDetail);
			}
			catch (FormatException)
			{
				errorMessage = string.Empty;
			}
			if (string.IsNullOrWhiteSpace(errorMessage))
			{
				errorMessage = "Não foi possível carregar o arquivo de tarefas."
					+ Environment.NewLine + "Arquivo: " + FileName
					+ Environment.NewLine + "Detalhe: " + errorDetail;
			}
			else if (!errorMessage.Contains(errorDetail))
			{
				errorMessage += Environment.NewLine + errorDetail;
			}
			DKBox.Show(errorMessage, string.Empty);
		}
	}

	public static void LoadInstanceList()
	{
		GProD.SelectWorldIdWindow_SelectedItemIndex = 0;
		string prefixOrCode = ACE.sTASKedit.MainEditor.MainEditor.LangTags[Settings.Fields.Language];
		string text = LocalizationBridge.ResolveLocaleCodeFromLegacyPrefix(prefixOrCode);
		try
		{
			if (LocalizationBridge.TryGetStaskeditDictionary(text, Class16.smethod_0(1648899764), out var values) && values.Count > 0)
			{
				GProD.InstanceList = values;
				return;
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649265453));
		}
		try
		{
			if (!text.Equals(Class16.smethod_0(1648931959), StringComparison.OrdinalIgnoreCase) && LocalizationBridge.TryGetStaskeditDictionary(Class16.smethod_0(1648931959), Class16.smethod_0(1648899764), out var values2) && values2.Count > 0)
			{
				GProD.InstanceList = values2;
				return;
			}
		}
		catch (Exception ex2)
		{
			SentryHelper.CaptureException(ex2, Class16.smethod_0(1649265483));
		}
		DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649265535), Class16.smethod_0(1649265586)), text), string.Empty);
	}

	public static void LoadParameterList(ref Dictionary<int, int> List, string FileName)
	{
		List = new Dictionary<int, int>();
		if (File.Exists(Application.StartupPath + Class16.smethod_0(1649074749) + FileName))
		{
			StreamReader streamReader = new StreamReader(Application.StartupPath + Class16.smethod_0(1649074749) + FileName, Encoding.Unicode);
			try
			{
				char[] separator = new char[1] { '\t' };
				while (!streamReader.EndOfStream)
				{
					string text = streamReader.ReadLine();
					if (text.Contains(Class16.smethod_0(1648904383)) && text != string.Empty && !text.StartsWith(Class16.smethod_0(1648904229)) && !text.StartsWith(Class16.smethod_0(1648929947)))
					{
						string[] array = text.Split(separator);
						List.Add(Convert.ToInt32(array[0]), Convert.ToInt32(array[1]));
					}
				}
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649265661));
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649264671)) + Class16.smethod_0(1648941987) + ex.Message, string.Empty);
			}
			streamReader.Close();
		}
		else
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649264702)) + Class16.smethod_0(1648942211) + FileName, string.Empty);
		}
	}

	public static void LoadOffsetsList(ref ComboBox comboBox_ClientVersion)
	{
		GProD.clientOffsets = new ArrayList();
		if (File.Exists(Application.StartupPath + Class16.smethod_0(1649264721)))
		{
			try
			{
				StreamReader streamReader = new StreamReader(Application.StartupPath + Class16.smethod_0(1649264721), Encoding.Unicode);
				char[] separator = new char[1] { ' ' };
				while (!streamReader.EndOfStream)
				{
					string text = streamReader.ReadLine();
					if (text.StartsWith(Class16.smethod_0(1649114298)))
					{
						comboBox_ClientVersion.Items.Add(text.Substring(5));
						Offset offset = new Offset();
						string[] array = streamReader.ReadLine().Split(separator);
						offset.BaseChain = new int[array.Length];
						for (int i = 0; i < array.Length; i++)
						{
							offset.BaseChain[i] = int.Parse(array[i], NumberStyles.HexNumber);
						}
						offset.DirX = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
						offset.DirY = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
						offset.DirZ = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
						offset.PosX = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
						offset.PosY = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
						offset.PosZ = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber);
						GProD.clientOffsets.Add(offset);
					}
				}
				streamReader.Close();
				if (comboBox_ClientVersion.Items.Count > 0)
				{
					comboBox_ClientVersion.SelectedIndex = 0;
				}
				return;
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649264756));
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649264788)) + Class16.smethod_0(1648941987) + ex.Message, string.Empty);
				return;
			}
		}
		DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649264822)), string.Empty);
	}

	public static void LoadLocalizationText()
	{
		string prefixOrCode = ACE.sTASKedit.MainEditor.MainEditor.LangTags[Settings.Fields.Language];
		string text = LocalizationBridge.ResolveLocaleCodeFromLegacyPrefix(prefixOrCode);
		try
		{
			if (LocalizationBridge.TryGetStaskeditDictionary(text, Class16.smethod_0(1649264852), out var values) && values.Count > 0)
			{
				GProD.LocalizationText = values;
				return;
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649264859));
		}
		try
		{
			if (!text.Equals(Class16.smethod_0(1648931959), StringComparison.OrdinalIgnoreCase) && LocalizationBridge.TryGetStaskeditDictionary(Class16.smethod_0(1648931959), Class16.smethod_0(1649264852), out var values2) && values2.Count > 0)
			{
				GProD.LocalizationText = values2;
				return;
			}
		}
		catch (Exception ex2)
		{
			SentryHelper.CaptureException(ex2, Class16.smethod_0(1649264909));
		}
		DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649264957), Class16.smethod_0(1649265008)), text), string.Empty);
	}

	public static void LoadImageLists(ref TreeView treeView_tasks)
	{
		try
		{
			GProD.imageList1 = LoadImageList(Class16.smethod_0(1649265075));
			GProD.imageList2 = LoadImageList(Class16.smethod_0(1649265103));
			treeView_tasks.ImageList = GProD.imageList2;
			treeView_tasks.ImageIndex = 0;
			treeView_tasks.SelectedImageIndex = 0;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649265115));
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649265146), Class16.smethod_0(1649260060)) + ex.Message + Class16.smethod_0(1648941447), string.Empty);
		}
	}

	public static ImageList GetTaskTreeImageList()
	{
		try
		{
			if (GProD.imageList2 != null && GProD.imageList2.Images.Count > 0)
			{
				return GProD.imageList2;
			}
			if (GProD.ConfigINI == null)
			{
				string configPath = Application.StartupPath + Class16.smethod_0(1649260238);
				if (!File.Exists(configPath))
				{
					return null;
				}
				LoadINI();
			}
			if (GProD.ConfigINI == null)
			{
				return null;
			}
			GProD.imageList2 = LoadImageList(Class16.smethod_0(1649265103));
			return GProD.imageList2;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649265115));
			return null;
		}
	}

	public static ImageList LoadImageList(string Section)
	{
		ImageList imageList = new ImageList();
		imageList.ImageSize = new Size(16, 16);
		imageList.ColorDepth = ColorDepth.Depth32Bit;
		if (GProD.ConfigINI.KeyExists(Class16.smethod_0(1649260077), Section))
		{
			if (!int.TryParse(GProD.ConfigINI.Read(Section, Class16.smethod_0(1649260077)), out int num))
			{
				num = 0;
			}
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < 2; j++)
				{
					if (GProD.ConfigINI.KeyExists(string.Format(Class16.smethod_0(1649260093), i, j), Section))
					{
						string text = Class16.smethod_0(1648927580) + GProD.ConfigINI.Read(Section, string.Format(Class16.smethod_0(1649260093), i, j));
						if (File.Exists(Application.StartupPath + text))
						{
							imageList.Images.Add(Image.FromFile(Application.StartupPath + text));
						}
						else
						{
							DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649260106), Class16.smethod_0(1649260060)) + text + Class16.smethod_0(1648941447), string.Empty);
						}
					}
				}
			}
			if (GProD.ConfigINI.KeyExists(string.Format(Class16.smethod_0(1649260142)), Section))
			{
				string text2 = Class16.smethod_0(1648927580) + GProD.ConfigINI.Read(Section, string.Format(Class16.smethod_0(1649260142)));
				if (File.Exists(Application.StartupPath + text2))
				{
					imageList.Images.Add(Image.FromFile(Application.StartupPath + text2));
				}
				else
				{
					DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649260159), Class16.smethod_0(1649260060)) + text2 + Class16.smethod_0(1648941447), string.Empty);
				}
			}
			if (GProD.ConfigINI.KeyExists(string.Format(Class16.smethod_0(1649260179)), Section))
			{
				string text3 = Class16.smethod_0(1648927580) + GProD.ConfigINI.Read(Section, string.Format(Class16.smethod_0(1649260179)));
				if (File.Exists(Application.StartupPath + text3))
				{
					imageList.Images.Add(Image.FromFile(Application.StartupPath + text3));
				}
				else
				{
					DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649260202), Class16.smethod_0(1649260060)) + text3 + Class16.smethod_0(1648941447), string.Empty);
				}
			}
		}
		return imageList;
	}

	public static void LoadINI()
	{
		GProD.ConfigINI = new IniFile(Application.StartupPath + Class16.smethod_0(1649260238));
		if (GProD.ConfigINI.KeyExists(Class16.smethod_0(1649260256), Class16.smethod_0(1649089262)))
		{
			GlobalData.version = int.Parse(GProD.ConfigINI.Read(Class16.smethod_0(1649089262), Class16.smethod_0(1649260256)));
		}
		if (GProD.ConfigINI.KeyExists(Class16.smethod_0(1649260281), Class16.smethod_0(1649089262)))
		{
			GProD.ElementIconWidth = int.Parse(GProD.ConfigINI.Read(Class16.smethod_0(1649089262), Class16.smethod_0(1649260281)));
		}
		if (GProD.ConfigINI.KeyExists(Class16.smethod_0(1649260304), Class16.smethod_0(1649089262)))
		{
			GProD.ElementIconHeight = int.Parse(GProD.ConfigINI.Read(Class16.smethod_0(1649089262), Class16.smethod_0(1649260304)));
		}
		if (GProD.ConfigINI.KeyExists(Class16.smethod_0(1649260328), Class16.smethod_0(1649260355)))
		{
			TaskToolTip.MaxSaveVersionForACE = int.Parse(GProD.ConfigINI.Read(Class16.smethod_0(1649260355), Class16.smethod_0(1649260328)));
		}
	}

	[CompilerGenerated]
	internal static void smethod_2(ATaskTempl[] tasks, TreeNodeCollection nodes, int GMIconIndex, int DisabledIconIndex)
	{
		for (int i = 0; i < tasks.Length; i++)
		{
			tasks[i].AddNode(nodes, GMIconIndex, DisabledIconIndex);
			if (tasks[i].pSub.Length != 0)
			{
				smethod_2(tasks[i].pSub, nodes[i].Nodes, GMIconIndex, DisabledIconIndex);
			}
		}
	}
}
