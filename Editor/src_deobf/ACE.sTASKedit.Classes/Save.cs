using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Windows.Forms;
using ACE.Classes;
using ACE.sTASKedit.Classes.GlobalProgramData;
using ACE.sTASKedit.tasks;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Classes;

internal class Save
{
	private static bool bool_0;

	private static bool smethod_0()
	{
		try
		{
			if (GProD.Tasks == null)
			{
				return false;
			}
			if (GProD.Tasks.Length == 0)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < GProD.Tasks.Length)
				{
					ATaskTempl aTaskTempl = GProD.Tasks[num];
					if (aTaskTempl != null)
					{
						if (aTaskTempl.ID > 0)
						{
							if (aTaskTempl.m_pwstrDescript == null || aTaskTempl.m_pwstrOkText == null || aTaskTempl.m_pwstrNoText == null || aTaskTempl.m_pwstrTribute == null)
							{
								break;
							}
							if (aTaskTempl.m_DelvTaskTalk != null && aTaskTempl.m_UnqualifiedTaskTalk != null && aTaskTempl.m_DelvItemTalk != null && aTaskTempl.m_ExeTalk != null && aTaskTempl.m_AwardTalk != null)
							{
								if (aTaskTempl.m_nSubCount >= 0 && aTaskTempl.pSub != null && aTaskTempl.pSub.Length == aTaskTempl.m_nSubCount)
								{
									try
									{
										// TODO(recovered): original used `ldtoken`/GetMethodFromHandle to fetch a method
										// reference that ILSpy could not decode (LdMemberToken). Stubbed to null so the
										// code takes the sub-task recursion path below (the non-reflective default).
										MethodInfo methodInfo = null;
										if (methodInfo != null)
										{
											if (!(bool)methodInfo.Invoke(aTaskTempl, null))
											{
												return false;
											}
										}
										else if (aTaskTempl.m_nSubCount > 0)
										{
											for (int i = 0; i < aTaskTempl.m_nSubCount; i++)
											{
												if (aTaskTempl.pSub[i] != null)
												{
													if (aTaskTempl.pSub[i].ID <= 0)
													{
														return false;
													}
													continue;
												}
												return false;
											}
										}
									}
									catch (Exception ex)
									{
										SentryHelper.CaptureException(ex, Class16.smethod_0(1649255606));
										return false;
									}
									num++;
									continue;
								}
								return false;
							}
							return false;
						}
						return false;
					}
					return false;
				}
				return true;
			}
			return false;
		}
		catch (Exception ex2)
		{
			SentryHelper.CaptureException(ex2, Class16.smethod_0(1649255606));
			return false;
		}
	}

	private static bool smethod_1(string string_0, out string string_1)
	{
		string_1 = null;
		try
		{
			FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
			try
			{
			}
			finally
			{
				((IDisposable)fileStream).Dispose();
			}
			return true;
		}
		catch (IOException ex)
		{
			string_1 = ex.Message;
			return false;
		}
		catch (UnauthorizedAccessException ex2)
		{
			string_1 = ex2.Message;
			return false;
		}
		catch (Exception ex3)
		{
			SentryHelper.CaptureException(ex3, Class16.smethod_0(1649255644));
			string_1 = ex3.Message;
			return false;
		}
	}

	private static void WriteTasksToTemporaryFile(string temporaryFileName, int version, ATaskTempl[] tasks, ToolStripProgressBar progressBar)
	{
		int taskCount = tasks.Length;
		int[] taskOffsets = new int[taskCount];
		using (FileStream stream = new FileStream(temporaryFileName, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None))
		using (BinaryWriter writer = new BinaryWriter(stream))
		{
			writer.Write(-1819966623);
			writer.Write(version);
			writer.Write(taskCount);
			if (version >= 223)
			{
				writer.Write(GlobalData.data_size);
			}

			long offsetTablePosition = stream.Position;
			for (int i = 0; i < taskCount; i++)
			{
				writer.Write(0);
			}

			ToolStripProgressBarSafe.TrySet(progressBar, taskCount, 0);
			for (int i = 0; i < taskCount; i++)
			{
				if (stream.Position > int.MaxValue)
				{
					throw new InvalidDataException("O arquivo de tarefas excede o limite de offsets suportado pelo formato.");
				}
				taskOffsets[i] = (int)stream.Position;
				try
				{
					tasks[i].Write(version, writer);
				}
				catch (Exception ex)
				{
					throw new InvalidDataException(string.Format("Falha ao serializar a tarefa de índice {0} (ID {1}).", i, tasks[i].ID), ex);
				}
				ToolStripProgressBarSafe.Increment(progressBar);
			}

			long endPosition = stream.Position;
			stream.Position = offsetTablePosition;
			for (int i = 0; i < taskOffsets.Length; i++)
			{
				writer.Write(taskOffsets[i]);
			}
			stream.Position = endPosition;
			writer.Flush();
			stream.Flush(true);
		}
	}

	private static void ValidateTasksFile(string fileName, int expectedVersion, ATaskTempl[] expectedTasks)
	{
		int expectedTaskCount = expectedTasks.Length;
		using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
		using (BinaryReader reader = new BinaryReader(stream))
		{
			int expectedHeaderSize = expectedVersion >= 223 ? 16 : 12;
			if (stream.Length < expectedHeaderSize + (long)expectedTaskCount * 4)
			{
				throw new InvalidDataException("O arquivo temporário de tarefas está incompleto.");
			}
			if (reader.ReadInt32() != -1819966623 || reader.ReadInt32() != expectedVersion || reader.ReadInt32() != expectedTaskCount)
			{
				throw new InvalidDataException("O cabeçalho do arquivo temporário de tarefas não corresponde aos dados gravados.");
			}
			if (expectedVersion >= 223 && reader.ReadInt32() != GlobalData.data_size)
			{
				throw new InvalidDataException("O tamanho de dados no cabeçalho do arquivo temporário está inconsistente.");
			}

			long minimumRecordOffset = expectedHeaderSize + (long)expectedTaskCount * 4;
			int previousOffset = -1;
			for (int i = 0; i < expectedTaskCount; i++)
			{
				int offset = reader.ReadInt32();
				if (offset < minimumRecordOffset || offset >= stream.Length || offset <= previousOffset)
				{
					throw new InvalidDataException(string.Format("O offset da tarefa de índice {0} está inválido.", i));
				}
				previousOffset = offset;
			}
		}

		TasksFile parsedTasks = new TasksFile(fileName, loadParallel: false, skipBrokenTasks: false);
		if (parsedTasks.Header.version != expectedVersion || parsedTasks.Tasks.Count != expectedTaskCount)
		{
			throw new InvalidDataException("A reabertura do arquivo temporário de tarefas retornou versão ou quantidade diferente da esperada.");
		}
		for (int i = 0; i < expectedTaskCount; i++)
		{
			if (parsedTasks.Tasks[i] == null || parsedTasks.Tasks[i].ID != expectedTasks[i].ID)
			{
				throw new InvalidDataException(string.Format("O ID da tarefa de índice {0} mudou durante a validação do arquivo temporário.", i));
			}
		}
	}

	private static void ReplaceTasksFile(string temporaryFileName, string destinationFileName)
	{
		if (File.Exists(destinationFileName))
		{
			File.Replace(temporaryFileName, destinationFileName, null);
		}
		else
		{
			File.Move(temporaryFileName, destinationFileName);
		}
	}

	public static void logic_SaveTasks(ref ToolStripStatusLabel toolStripStatusLabel_Message, ref ToolStripProgressBar toolStripProgressBar_Progress, Cursor Cursor, string fileName, int version, bool makeBackup)
	{
		toolStripStatusLabel_Message.Text = GProD.TX(501);
		if (bool_0)
		{
			string text = GProD.TX(520) ?? Class16.smethod_0(1649255665);
			DKBox.Show(text, Class16.smethod_0(1649255740), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			toolStripStatusLabel_Message.Text = text;
			return;
		}
		bool_0 = true;
		if (!smethod_0())
		{
			_ = Cursors.Default;
			ToolStripProgressBarSafe.Reset(toolStripProgressBar_Progress);
			string text2 = GProD.TX(493) ?? Class16.smethod_0(1649255757);
			DKBox.Show(text2, Class16.smethod_0(1648990038), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			string text3 = GProD.TX(494) ?? Class16.smethod_0(1649255815);
			toolStripStatusLabel_Message.Text = text3;
			bool_0 = false;
			return;
		}
		string temporaryFileName = null;
		try
		{
			if (string.IsNullOrWhiteSpace(fileName))
			{
				throw new ArgumentException("O caminho do arquivo de tarefas não foi informado.", "fileName");
			}
			if (File.Exists(fileName) && !smethod_1(fileName, out var string_))
			{
				_ = Cursors.Default;
				ToolStripProgressBarSafe.Reset(toolStripProgressBar_Progress);
				string text5 = GProD.TX(521) ?? Class16.smethod_0(1649255853);
				if (!string.IsNullOrEmpty(string_))
				{
					text5 = text5 + Environment.NewLine + Environment.NewLine + string_;
				}
				DKBox.Show(text5, Class16.smethod_0(1649255740), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				toolStripStatusLabel_Message.Text = GProD.TX(522) ?? Class16.smethod_0(1649255907);
				return;
			}
			_ = Cursors.WaitCursor;
			if (makeBackup && File.Exists(fileName))
			{
				if (TASKS.CStorage != null)
				{
					string backupFileName = TASKS.CStorage.CreateBackup(fileName);
					if (string.IsNullOrEmpty(backupFileName) || !File.Exists(backupFileName))
					{
						throw new IOException("O backup solicitado não foi criado.");
					}
				}
				else
				{
					throw new IOException("O serviço de backup não está disponível.");
				}
			}
			string fullFileName = System.IO.Path.GetFullPath(fileName);
			string directoryName = System.IO.Path.GetDirectoryName(fullFileName);
			temporaryFileName = System.IO.Path.Combine(directoryName, System.IO.Path.GetFileName(fullFileName) + "." + Guid.NewGuid().ToString("N") + ".tmp");
			ATaskTempl[] tasks = GProD.Tasks;
			WriteTasksToTemporaryFile(temporaryFileName, version, tasks, toolStripProgressBar_Progress);
			ValidateTasksFile(temporaryFileName, version, tasks);
			ReplaceTasksFile(temporaryFileName, fullFileName);
			temporaryFileName = null;
			ToolStripProgressBarSafe.Reset(toolStripProgressBar_Progress);
			_ = Cursors.Default;
			toolStripStatusLabel_Message.Text = GProD.TX(499);
		}
		catch (Exception ex7)
		{
			SentryHelper.CaptureException(ex7, Class16.smethod_0(1649254925));
			_ = Cursors.Default;
			ToolStripProgressBarSafe.Reset(toolStripProgressBar_Progress);
			try
			{
				if (!string.IsNullOrEmpty(temporaryFileName) && File.Exists(temporaryFileName))
				{
					File.Delete(temporaryFileName);
				}
			}
			catch (Exception cleanupException)
			{
				SentryHelper.CaptureException(cleanupException, Class16.smethod_0(1649254925));
			}
			string text6 = string.Format(GProD.TX(492) ?? Class16.smethod_0(1649255411), ex7.Message);
			DKBox.Show(text6, Class16.smethod_0(1649003931), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			toolStripStatusLabel_Message.Text = TextStorage.Msg(Class16.smethod_0(1649254409));
		}
		finally
		{
			bool_0 = false;
		}
	}
}
