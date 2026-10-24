using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.Classes;
using Sentry;

namespace ACE.sTASKedit.tasks.tasks.data;

public class ATaskTempl : ATaskTemplFixedData
{
	private bool bool_193;

	private short[] short_16 = new short[0];

	private short[] short_17 = new short[0];

	private short[] short_18 = new short[0];

	private short[] short_19 = new short[0];

	private talk_proc talk_proc_0 = new talk_proc();

	private talk_proc talk_proc_1 = new talk_proc();

	private talk_proc talk_proc_2 = new talk_proc();

	private talk_proc talk_proc_3 = new talk_proc();

	private talk_proc talk_proc_4 = new talk_proc();

	private int int_243;

	private ATaskTempl[] ataskTempl_0 = new ATaskTempl[0];

	private static readonly object object_0 = new object();

	private static readonly HashSet<string> hashSet_0 = new HashSet<string>();

	public bool IsDuplicateId
	{
		[CompilerGenerated]
		get
		{
			return bool_193;
		}
		[CompilerGenerated]
		set
		{
			bool_193 = value;
		}
	}

	public short[] m_pwstrDescript
	{
		[CompilerGenerated]
		get
		{
			return short_16;
		}
		[CompilerGenerated]
		set
		{
			short_16 = value;
		}
	}

	public short[] m_pwstrOkText
	{
		[CompilerGenerated]
		get
		{
			return short_17;
		}
		[CompilerGenerated]
		set
		{
			short_17 = value;
		}
	}

	public short[] m_pwstrNoText
	{
		[CompilerGenerated]
		get
		{
			return short_18;
		}
		[CompilerGenerated]
		set
		{
			short_18 = value;
		}
	}

	public short[] m_pwstrTribute
	{
		[CompilerGenerated]
		get
		{
			return short_19;
		}
		[CompilerGenerated]
		set
		{
			short_19 = value;
		}
	}

	public talk_proc m_DelvTaskTalk
	{
		[CompilerGenerated]
		get
		{
			return talk_proc_0;
		}
		[CompilerGenerated]
		set
		{
			talk_proc_0 = value;
		}
	}

	public talk_proc m_UnqualifiedTaskTalk
	{
		[CompilerGenerated]
		get
		{
			return talk_proc_1;
		}
		[CompilerGenerated]
		set
		{
			talk_proc_1 = value;
		}
	}

	public talk_proc m_DelvItemTalk
	{
		[CompilerGenerated]
		get
		{
			return talk_proc_2;
		}
		[CompilerGenerated]
		set
		{
			talk_proc_2 = value;
		}
	}

	public talk_proc m_ExeTalk
	{
		[CompilerGenerated]
		get
		{
			return talk_proc_3;
		}
		[CompilerGenerated]
		set
		{
			talk_proc_3 = value;
		}
	}

	public talk_proc m_AwardTalk
	{
		[CompilerGenerated]
		get
		{
			return talk_proc_4;
		}
		[CompilerGenerated]
		set
		{
			talk_proc_4 = value;
		}
	}

	public int m_nSubCount
	{
		[CompilerGenerated]
		get
		{
			return int_243;
		}
		[CompilerGenerated]
		set
		{
			int_243 = value;
		}
	}

	public ATaskTempl[] pSub
	{
		[CompilerGenerated]
		get
		{
			return ataskTempl_0;
		}
		[CompilerGenerated]
		set
		{
			ataskTempl_0 = value;
		}
	}

	public int ID
	{
		get
		{
			return m_ID;
		}
		set
		{
			string name = base.Name;
			string signature = base.Signature;
			string descript = Descript;
			string okText = OkText;
			string noText = NoText;
			string tribute = Tribute;
			m_ID = value;
			base.Name = name;
			base.Signature = signature;
			Descript = descript;
			OkText = okText;
			NoText = noText;
			Tribute = tribute;
			method_117(m_DelvTaskTalk, value);
			method_117(m_UnqualifiedTaskTalk, value);
			method_117(m_DelvItemTalk, value);
			method_117(m_ExeTalk, value);
			method_117(m_AwardTalk, value);
		}
	}

	public string Descript
	{
		get
		{
			return tasksConvert.decrypt(m_ID, m_pwstrDescript);
		}
		set
		{
			value = value.TrimEnd(default(char));
			m_pwstrDescript = tasksConvert.encrypt(m_ID, value, value.Length, appendZero: false);
		}
	}

	public string OkText
	{
		get
		{
			return tasksConvert.decrypt(m_ID, m_pwstrOkText);
		}
		set
		{
			value = value.TrimEnd(default(char));
			m_pwstrOkText = tasksConvert.encrypt(m_ID, value, value.Length, appendZero: false);
		}
	}

	public string NoText
	{
		get
		{
			return tasksConvert.decrypt(m_ID, m_pwstrNoText);
		}
		set
		{
			value = value.TrimEnd(default(char));
			m_pwstrNoText = tasksConvert.encrypt(m_ID, value, value.Length, appendZero: false);
		}
	}

	public string Tribute
	{
		get
		{
			return tasksConvert.decrypt(m_ID, m_pwstrTribute);
		}
		set
		{
			value = value.TrimEnd(default(char));
			m_pwstrTribute = tasksConvert.encrypt(m_ID, value, value.Length, appendZero: false);
		}
	}

	public ATaskTempl()
	{
	}

	public ATaskTempl(int version, BinaryReader BinaryStream, int BaseStreamPosition = -1, TreeNodeCollection Nodes = null, int GMIconIndex = 12, int DisabledIconIndex = 13)
	{
		method_120(version, BinaryStream, BaseStreamPosition, Nodes, GMIconIndex, DisabledIconIndex);
	}

	private void method_117(talk_proc talk_proc_5, int int_244)
	{
		string dialogText = talk_proc_5.DialogText;
		talk_proc_5.crypt_key = int_244;
		talk_proc_5.DialogText = dialogText;
		for (int i = 0; i < talk_proc_5.windows.Length; i++)
		{
			string talktext = talk_proc_5.windows[i].talktext;
			talk_proc_5.windows[i].crypt_key = int_244;
			talk_proc_5.windows[i].talktext = talktext;
			for (int j = 0; j < talk_proc_5.windows[i].options.Length; j++)
			{
				string optiontext = talk_proc_5.windows[i].options[j].optiontext;
				talk_proc_5.windows[i].options[j].crypt_key = int_244;
				talk_proc_5.windows[i].options[j].optiontext = optiontext;
			}
		}
	}

	private bool method_118()
	{
		try
		{
			if (m_ID <= 0)
			{
				return false;
			}
			if (m_pwstrDescript != null && m_pwstrOkText != null && m_pwstrNoText != null && m_pwstrTribute != null)
			{
				if (m_DelvTaskTalk != null && m_UnqualifiedTaskTalk != null && m_DelvItemTalk != null && m_ExeTalk != null && m_AwardTalk != null)
				{
					if (m_nSubCount < 0)
					{
						return false;
					}
					if (pSub == null)
					{
						return false;
					}
					if (m_nSubCount != pSub.Length)
					{
						return false;
					}
					int num = 0;
					while (true)
					{
						if (num < m_nSubCount)
						{
							if (pSub[num] != null)
							{
								if (!pSub[num].method_118())
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
					return false;
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649402888));
			return false;
		}
	}

	private bool method_119(BinaryReader binaryReader_0)
	{
		try
		{
			if (binaryReader_0.BaseStream.Position >= binaryReader_0.BaseStream.Length)
			{
				return false;
			}
			if (m_ID <= 0)
			{
				return false;
			}
			if (m_nSubCount >= 0 && m_nSubCount <= 1000)
			{
				long num = binaryReader_0.BaseStream.Length - binaryReader_0.BaseStream.Position;
				if (m_nSubCount > 0 && num < m_nSubCount * 50)
				{
					return false;
				}
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649402939));
			return false;
		}
	}

	public ATaskTempl Clone(int version = -1)
	{
		if (version == -1)
		{
			version = GlobalData.version;
		}
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		BinaryReader binaryReader = new BinaryReader(memoryStream);
		Write(9999, binaryWriter);
		ATaskTempl result = new ATaskTempl(9999, binaryReader, 0);
		binaryWriter.Close();
		binaryReader.Close();
		memoryStream.Close();
		return result;
	}

	public void AddNode(TreeNodeCollection nodes, int GMIconIndex = 12, int DisabledIconIndex = 13)
	{
		if (nodes != null)
		{
			nodes.Add(string.Empty);
			GlobalFunctions.UpdateNode(nodes[nodes.Count - 1], this, 0, GMIconIndex, DisabledIconIndex);
		}
	}

	private static void smethod_0(string string_0, string string_1, string string_2, SentryLevel sentryLevel_0)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
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
		SentryHelper.CaptureMessage(string_1, sentryLevel_0, string_2);
	}

	private void method_120(int int_244, BinaryReader binaryReader_0, int int_245, TreeNodeCollection treeNodeCollection_0, int int_246, int int_247)
	{
		try
		{
			if (int_245 > -1)
			{
				binaryReader_0.BaseStream.Position = int_245;
			}
			logic_read_task_data_struct(int_244, binaryReader_0);
			if (!method_119(binaryReader_0))
			{
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649402985), Class16.smethod_0(1649403045)), m_ID), Class16.smethod_0(1648990038), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				throw new InvalidDataException(string.Format(Class16.smethod_0(1649403045), m_ID));
			}
			m_pwstrDescript = GlobalFunctions.ReadChars_pwstr(binaryReader_0);
			m_pwstrOkText = GlobalFunctions.ReadChars_pwstr(binaryReader_0);
			m_pwstrNoText = GlobalFunctions.ReadChars_pwstr(binaryReader_0);
			m_pwstrTribute = GlobalFunctions.ReadChars_pwstr(binaryReader_0);
			if (m_pwstrDescript != null && m_pwstrOkText != null && m_pwstrNoText != null && m_pwstrTribute != null)
			{
				talk_proc.Read(int_244, binaryReader_0, m_ID, m_DelvTaskTalk);
				talk_proc.Read(int_244, binaryReader_0, m_ID, m_UnqualifiedTaskTalk);
				talk_proc.Read(int_244, binaryReader_0, m_ID, m_DelvItemTalk);
				talk_proc.Read(int_244, binaryReader_0, m_ID, m_ExeTalk);
				talk_proc.Read(int_244, binaryReader_0, m_ID, m_AwardTalk);
				if (m_DelvTaskTalk != null && m_UnqualifiedTaskTalk != null && m_DelvItemTalk != null && m_ExeTalk != null && m_AwardTalk != null)
				{
					AddNode(treeNodeCollection_0, int_246, int_247);
					if (m_ID > GlobalData.NewID)
					{
						GlobalData.NewID = m_ID;
					}
					m_nSubCount = binaryReader_0.ReadInt32();
					if (m_nSubCount >= 0 && m_nSubCount <= 1000)
					{
						pSub = new ATaskTempl[m_nSubCount];
						for (int i = 0; i < m_nSubCount; i++)
						{
							try
							{
								if (treeNodeCollection_0 != null)
								{
									pSub[i] = new ATaskTempl(int_244, binaryReader_0, (int)binaryReader_0.BaseStream.Position, treeNodeCollection_0[treeNodeCollection_0.Count - 1].Nodes);
								}
								else
								{
									pSub[i] = new ATaskTempl(int_244, binaryReader_0, (int)binaryReader_0.BaseStream.Position);
								}
								if (pSub[i] == null)
								{
									DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649402432), Class16.smethod_0(1649402475)), i, m_ID), Class16.smethod_0(1649403208), MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}
							}
							catch (EndOfStreamException)
							{
								break;
							}
							catch (Exception ex2)
							{
								SentryHelper.CaptureException(ex2, Class16.smethod_0(1649402533));
								DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649402567), Class16.smethod_0(1649402614)), i, m_ID, ex2.Message), Class16.smethod_0(1649403208), MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
						if (!method_118())
						{
							DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649402659), Class16.smethod_0(1649402713)), m_ID), Class16.smethod_0(1648990038), MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						return;
					}
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649403353), Class16.smethod_0(1649402376)), m_nSubCount, m_ID), Class16.smethod_0(1648990038), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					throw new InvalidDataException(string.Format(Class16.smethod_0(1649402376), m_nSubCount, m_ID));
				}
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649403225), Class16.smethod_0(1649403272)), m_ID), Class16.smethod_0(1649403334), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				throw new InvalidDataException(string.Format(Class16.smethod_0(1649403272), m_ID));
			}
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649403127), Class16.smethod_0(1649403160)), m_ID), Class16.smethod_0(1649403208), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			throw new InvalidDataException(string.Format(Class16.smethod_0(1649403160), m_ID));
		}
		catch (EndOfStreamException)
		{
			smethod_0(string.Format(Class16.smethod_0(1649402813), m_ID), string.Format(Class16.smethod_0(1649402863), m_ID), Class16.smethod_0(1649401906), (SentryLevel)2);
		}
		catch (OverflowException)
		{
			smethod_0(string.Format(Class16.smethod_0(1649401952), m_ID), string.Format(Class16.smethod_0(1649402007), m_ID), Class16.smethod_0(1649402073), (SentryLevel)2);
		}
		catch (OutOfMemoryException)
		{
			smethod_0(string.Format(Class16.smethod_0(1649402124), m_ID), string.Format(Class16.smethod_0(1649402174), m_ID), Class16.smethod_0(1649402243), (SentryLevel)2);
		}
		catch (InvalidDataException)
		{
			smethod_0(string.Format(Class16.smethod_0(1649402289), m_ID), string.Format(Class16.smethod_0(1649402339), m_ID), Class16.smethod_0(1649405492), (SentryLevel)((m_ID <= 0) ? 1 : 2));
		}
		catch (Exception ex7)
		{
			SentryHelper.CaptureException(ex7, Class16.smethod_0(1649402533));
		}
	}

	private void method_121(string string_0, talk_proc talk_proc_5, int int_244)
	{
		for (int i = 0; i < talk_proc_5.windows.Length; i++)
		{
			window window2 = talk_proc_5.windows[i];
			for (int j = 0; j < window2.options.Length; j++)
			{
				_ = window2.options[j];
			}
		}
	}

	public void Write(int version, BinaryWriter binaryWriter_0, bool bSaveSubQuests = true)
	{
		try
		{
			if (!method_118())
			{
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649405530), Class16.smethod_0(1649405589)), m_ID), Class16.smethod_0(1648990038), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			if (binaryWriter_0 == null || !binaryWriter_0.BaseStream.CanWrite)
			{
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649405662), Class16.smethod_0(1649405711)), m_ID), Class16.smethod_0(1649405755), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			long position = binaryWriter_0.BaseStream.Position;
			try
			{
				logic_write_task_data_struct(version, binaryWriter_0);
				GlobalFunctions.WriteChars_pwstr(binaryWriter_0, m_pwstrDescript);
				GlobalFunctions.WriteChars_pwstr(binaryWriter_0, m_pwstrOkText);
				GlobalFunctions.WriteChars_pwstr(binaryWriter_0, m_pwstrNoText);
				GlobalFunctions.WriteChars_pwstr(binaryWriter_0, m_pwstrTribute);
				talk_proc.Write(version, binaryWriter_0, m_DelvTaskTalk);
				talk_proc.Write(version, binaryWriter_0, m_UnqualifiedTaskTalk);
				talk_proc.Write(version, binaryWriter_0, m_DelvItemTalk);
				talk_proc.Write(version, binaryWriter_0, m_ExeTalk);
				talk_proc.Write(version, binaryWriter_0, m_AwardTalk);
				if (bSaveSubQuests)
				{
					if (m_nSubCount != pSub.Length)
					{
						DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649405781), Class16.smethod_0(1649405828)), m_ID, m_nSubCount, pSub.Length), Class16.smethod_0(1649405916), MessageBoxButtons.OK, MessageBoxIcon.Hand);
						throw new InvalidDataException(string.Format(Class16.smethod_0(1649405828), m_ID, m_nSubCount, pSub.Length));
					}
					binaryWriter_0.Write(m_nSubCount);
					for (int i = 0; i < m_nSubCount; i++)
					{
						if (pSub != null && pSub.Length == m_nSubCount)
						{
							try
							{
								pSub[i].Write(version, binaryWriter_0);
							}
							catch (Exception ex)
							{
								SentryHelper.CaptureException(ex, Class16.smethod_0(1649405101));
								DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649405128), Class16.smethod_0(1649405182)), i, m_ID, ex.Message), Class16.smethod_0(1649405755), MessageBoxButtons.OK, MessageBoxIcon.Hand);
								throw new InvalidDataException(string.Format(Class16.smethod_0(1649405182), i, m_ID, ex.Message), ex);
							}
							continue;
						}
						string format = TextStorage.Msg(Class16.smethod_0(1649405942), Class16.smethod_0(1649404964));
						object arg = m_ID;
						ATaskTempl[] array = pSub;
						DKBox.Show(string.Format(format, arg, (array != null) ? array.Length : 0, m_nSubCount), Class16.smethod_0(1649405070), MessageBoxButtons.OK, MessageBoxIcon.Hand);
						string format2 = Class16.smethod_0(1649404964);
						object arg2 = m_ID;
						ATaskTempl[] array2 = pSub;
						throw new InvalidDataException(string.Format(format2, arg2, (array2 != null) ? array2.Length : 0, m_nSubCount));
					}
				}
				else
				{
					binaryWriter_0.Write(0);
				}
				binaryWriter_0.Flush();
			}
			catch (Exception ex2)
			{
				SentryHelper.CaptureException(ex2, Class16.smethod_0(1649405101));
				try
				{
					if (binaryWriter_0.BaseStream.CanSeek)
					{
						binaryWriter_0.BaseStream.Position = position;
						binaryWriter_0.BaseStream.SetLength(position);
					}
				}
				catch
				{
				}
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649405226), Class16.smethod_0(1649405271)), m_ID, ex2.Message), Class16.smethod_0(1649003931), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				throw new InvalidDataException(string.Format(Class16.smethod_0(1649405271), m_ID, ex2.Message), ex2);
			}
		}
		catch (Exception ex3)
		{
			SentryHelper.CaptureException(ex3, Class16.smethod_0(1649405101));
			string text = string.Format(Class16.smethod_0(1649405299), m_ID, ex3.Message);
			DKBox.Show(text, Class16.smethod_0(1649405359), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			throw new InvalidDataException(text, ex3);
		}
	}
}
