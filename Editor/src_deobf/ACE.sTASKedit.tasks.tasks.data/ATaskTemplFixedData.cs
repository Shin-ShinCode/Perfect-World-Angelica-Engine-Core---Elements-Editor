using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class ATaskTemplFixedData
{
	private AWARD_CARRIER_HP_SCALE award_CARRIER_HP_SCALE_0 = new AWARD_CARRIER_HP_SCALE();

	private AWARD_CARRIER_HP_SCALE award_CARRIER_HP_SCALE_1 = new AWARD_CARRIER_HP_SCALE();

	private AWARD_DATA award_DATA_0 = new AWARD_DATA();

	private AWARD_DATA award_DATA_1 = new AWARD_DATA();

	private AWARD_ITEMS_SCALE award_ITEMS_SCALE_0 = new AWARD_ITEMS_SCALE();

	private AWARD_ITEMS_SCALE award_ITEMS_SCALE_1 = new AWARD_ITEMS_SCALE();

	private AWARD_MONSTERS_SUMMONED award_MONSTERS_SUMMONED_0 = new AWARD_MONSTERS_SUMMONED();

	private AWARD_RATIO_SCALE award_RATIO_SCALE_0 = new AWARD_RATIO_SCALE();

	private AWARD_RATIO_SCALE award_RATIO_SCALE_1 = new AWARD_RATIO_SCALE();

	private AWARD_RATIO_SCALE award_RATIO_SCALE_2 = new AWARD_RATIO_SCALE();

	private AWARD_RATIO_SCALE award_RATIO_SCALE_3 = new AWARD_RATIO_SCALE();

	private AWARD_VAR_SCALE award_VAR_SCALE_0 = new AWARD_VAR_SCALE();

	private AWARD_VAR_SCALE award_VAR_SCALE_1 = new AWARD_VAR_SCALE();

	private COMPARE_KEY_VALUE compare_KEY_VALUE_0 = new COMPARE_KEY_VALUE();

	private COMPARE_KEY_VALUE compare_KEY_VALUE_1 = new COMPARE_KEY_VALUE();

	private COMPARE_KEY_VALUE compare_KEY_VALUE_2 = new COMPARE_KEY_VALUE();

	private COMPARE_KEY_VALUE compare_KEY_VALUE_3 = new COMPARE_KEY_VALUE();

	private COMPARE_KEY_VALUE compare_KEY_VALUE_4 = new COMPARE_KEY_VALUE();

	private COMPARE_KEY_VALUE compare_KEY_VALUE_5 = new COMPARE_KEY_VALUE();

	private COMPARE_KEY_VALUE compare_KEY_VALUE_6 = new COMPARE_KEY_VALUE();

	private COMPARE_KEY_VALUE compare_KEY_VALUE_7 = new COMPARE_KEY_VALUE();

	private COMPARE_KEY_VALUE compare_KEY_VALUE_8 = new COMPARE_KEY_VALUE();

	private COMPARE_KEY_VALUE compare_KEY_VALUE_9 = new COMPARE_KEY_VALUE();

	private COMPARE_KEY_VALUE compare_KEY_VALUE_10 = new COMPARE_KEY_VALUE();

	private COMPARE_KEY_VALUE compare_KEY_VALUE_11 = new COMPARE_KEY_VALUE();

	private COMPARE_KEY_VALUE compare_KEY_VALUE_12 = new COMPARE_KEY_VALUE();

	private COMPARE_KEY_VALUE compare_KEY_VALUE_13 = new COMPARE_KEY_VALUE();

	private COMPARE_KEY_VALUE compare_KEY_VALUE_14 = new COMPARE_KEY_VALUE();

	private COMPARE_KEY_VALUE compare_KEY_VALUE_15 = new COMPARE_KEY_VALUE();

	private HOME_ITEM_WANTED[] home_ITEM_WANTED_0 = new HOME_ITEM_WANTED[0];

	private ITEM_WANTED[] item_WANTED_0 = new ITEM_WANTED[0];

	private ITEM_WANTED[] item_WANTED_1 = new ITEM_WANTED[0];

	private ITEM_WANTED[] item_WANTED_2 = new ITEM_WANTED[0];

	private ITEM_WANTED[] item_WANTED_3 = new ITEM_WANTED[0];

	private ITEM_WANTED[] item_WANTED_4 = new ITEM_WANTED[0];

	private MONSTERS_CONTRIB[] monsters_CONTRIB_0 = new MONSTERS_CONTRIB[0];

	private MONSTER_WANTED[] monster_WANTED_0 = new MONSTER_WANTED[0];

	private MONSTER_WANTED[] monster_WANTED_1 = new MONSTER_WANTED[0];

	private PLAYER_WANTED[] player_WANTED_0 = new PLAYER_WANTED[0];

	private SPECIAL_PARAMETERS special_PARAMETERS_0 = new SPECIAL_PARAMETERS();

	private TASK_EXPRESSION[][] task_EXPRESSION_0 = new TASK_EXPRESSION[0][];

	private TASK_EXPRESSION[][] task_EXPRESSION_1 = new TASK_EXPRESSION[0][];

	private TASK_EXPRESSION[][] task_EXPRESSION_2 = new TASK_EXPRESSION[0][];

	private TASK_EXPRESSION[][] task_EXPRESSION_3 = new TASK_EXPRESSION[0][];

	private TEAM_MEM_WANTED[] team_MEM_WANTED_0 = new TEAM_MEM_WANTED[0];

	private TSMNPCServices[] tsmnpcservices_0 = new TSMNPCServices[0];

	private TSMTargetTask[] tsmtargetTask_0 = new TSMTargetTask[0];

	private TaskEventData[] taskEventData_0 = new TaskEventData[0];

	private TaskEventData[] taskEventData_1 = new TaskEventData[0];

	private TaskEventData[] taskEventData_2 = new TaskEventData[0];

	private Task_Region[] task_Region_0 = new Task_Region[0];

	private Task_Region[] task_Region_1 = new Task_Region[0];

	private Task_Region[] task_Region_2 = new Task_Region[0];

	private Task_Region[] task_Region_3 = new Task_Region[0];

	private Task_Region[] task_Region_4 = new Task_Region[0];

	private Task_Region[] task_Region_5 = new Task_Region[0];

	private VAGUE_PROMPT_INFO[] vague_PROMPT_INFO_0 = new VAGUE_PROMPT_INFO[0];

	private ZONE_VERT zone_VERT_0 = new ZONE_VERT();

	private ZONE_VERT zone_VERT_1 = new ZONE_VERT();

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	private bool bool_14;

	private bool bool_15;

	private bool bool_16 = true;

	private bool bool_17 = true;

	private bool bool_18 = true;

	private bool bool_19;

	private bool bool_20;

	private bool bool_21;

	private bool bool_22;

	private bool bool_23;

	private bool bool_24;

	private bool bool_25;

	private bool bool_26;

	private bool bool_27;

	private bool bool_28;

	private bool bool_29;

	private bool bool_30;

	private bool bool_31;

	private bool bool_32;

	private bool bool_33;

	private bool bool_34;

	private bool bool_35 = true;

	private bool bool_36;

	private bool bool_37;

	private bool bool_38;

	private bool bool_39;

	private bool bool_40;

	private bool bool_41;

	private bool bool_42;

	private bool bool_43;

	private bool bool_44;

	private bool bool_45;

	private bool bool_46;

	private bool bool_47;

	private bool bool_48;

	private bool bool_49;

	private bool bool_50;

	private bool bool_51;

	private bool bool_52;

	private bool bool_53;

	private bool bool_54;

	private bool bool_55;

	private bool bool_56 = true;

	private bool bool_57 = true;

	private bool bool_58 = true;

	private bool bool_59;

	private bool bool_60;

	private bool bool_61;

	private bool bool_62;

	private bool bool_63;

	private bool bool_64;

	private bool bool_65;

	private bool bool_66;

	private bool bool_67;

	private bool bool_68;

	private bool bool_69;

	private bool bool_70;

	private bool bool_71;

	private bool bool_72;

	private bool bool_73;

	private bool bool_74;

	private bool bool_75;

	private bool bool_76;

	private bool bool_77;

	private bool bool_78;

	private bool bool_79;

	private bool bool_80;

	private bool bool_81;

	private bool bool_82;

	private bool bool_83;

	private bool bool_84;

	private bool bool_85;

	private bool bool_86 = true;

	private bool bool_87;

	private bool bool_88;

	private bool bool_89;

	private bool bool_90;

	private bool bool_91;

	private bool bool_92;

	private bool bool_93;

	private bool bool_94;

	private bool bool_95;

	private bool bool_96;

	private bool bool_97;

	private bool bool_98;

	private bool bool_99;

	private bool bool_100;

	private bool bool_101;

	private bool bool_102;

	private bool bool_103;

	private bool bool_104;

	private bool bool_105;

	private bool bool_106;

	private bool bool_107;

	private bool bool_108;

	private bool bool_109;

	private bool bool_110;

	private bool bool_111;

	private bool bool_112;

	private bool bool_113;

	private bool bool_114;

	private bool bool_115;

	private bool bool_116;

	private bool bool_117;

	private bool bool_118;

	private bool bool_119;

	private bool bool_120 = true;

	private bool bool_121 = true;

	private bool bool_122;

	private bool bool_123 = true;

	private bool bool_124 = true;

	private bool bool_125;

	private bool bool_126;

	private bool bool_127;

	private bool bool_128 = true;

	private bool bool_129 = true;

	private bool bool_130 = true;

	private bool bool_131 = true;

	private bool bool_132 = true;

	private bool bool_133 = true;

	private bool bool_134 = true;

	private bool bool_135 = true;

	private bool bool_136 = true;

	private bool bool_137 = true;

	private bool bool_138;

	private bool bool_139;

	private bool bool_140;

	private bool bool_141;

	private bool bool_142;

	private bool bool_143;

	private bool bool_144 = true;

	private bool bool_145 = true;

	private bool bool_146 = true;

	private bool bool_147 = true;

	private bool bool_148 = true;

	private bool bool_149 = true;

	private bool bool_150 = true;

	private bool bool_151 = true;

	private bool bool_152 = true;

	private bool bool_153;

	private bool bool_154;

	private bool bool_155 = true;

	private bool bool_156 = true;

	private bool bool_157 = true;

	private bool bool_158 = true;

	private bool bool_159 = true;

	private bool bool_160;

	private bool bool_161;

	private bool bool_162;

	private bool bool_163;

	private bool bool_164 = true;

	private bool bool_165;

	private bool bool_166;

	private bool bool_167;

	private bool bool_168;

	private bool bool_169;

	private bool bool_170 = true;

	private bool bool_171;

	private bool bool_172;

	private bool bool_173;

	private bool bool_174;

	private bool bool_175;

	private bool bool_176;

	private bool bool_177;

	private bool bool_178;

	private bool bool_179 = true;

	private bool bool_180;

	private bool bool_181;

	private bool bool_182;

	private bool bool_183;

	private bool bool_184;

	private bool bool_185;

	private bool bool_186;

	private bool bool_187;

	private bool bool_188;

	private bool bool_189;

	private bool bool_190;

	private bool bool_191;

	private bool bool_192;

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

	private byte byte_4;

	private byte byte_5;

	private byte byte_6;

	private byte byte_7;

	private byte byte_8;

	private byte byte_9 = byte.MaxValue;

	private byte byte_10;

	private byte byte_11 = 1;

	private byte byte_12 = 1;

	private byte byte_13 = 1;

	private byte[] byte_14 = new byte[20];

	private byte[] byte_15 = new byte[0];

	private byte[] byte_16 = new byte[0];

	private byte[] byte_17 = new byte[0];

	private byte[] byte_18 = new byte[24];

	private char[][] char_0 = new char[0][];

	private char[][] char_1 = new char[0][];

	private char[][] char_2 = new char[0][];

	private char[][] char_3 = new char[0][];

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	private float float_6;

	private float float_7;

	private float float_8;

	private float float_9;

	private float float_10;

	private float float_11;

	private float float_12;

	private float float_13;

	private float float_14;

	private float float_15;

	private float float_16;

	private float float_17;

	private float float_18;

	private float float_19;

	private float float_20;

	private float float_21;

	private float float_22;

	private float float_23;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9;

	private int int_10;

	private int int_11;

	private int int_12;

	private int int_13;

	private int int_14;

	private int int_15;

	private int int_16;

	private int int_17;

	private int int_18;

	private int int_19;

	private int int_20;

	private int int_21;

	private int int_22;

	public int m_ID;

	private int int_23;

	private int int_24;

	private int int_25;

	private int int_26;

	private int int_27;

	private int int_28;

	private int int_29;

	private int int_30;

	private int int_31;

	private int int_32;

	private int int_33;

	private int int_34;

	private int int_35;

	private int int_36;

	private int int_37;

	private int int_38;

	private int int_39;

	private int int_40;

	private int int_41;

	private int int_42;

	private int int_43;

	private int int_44;

	private int int_45;

	private int int_46;

	private int int_47;

	private int int_48;

	private int int_49;

	private int int_50;

	private int int_51;

	private int int_52;

	private int int_53;

	private int int_54;

	private int int_55;

	private int int_56;

	private int int_57;

	private int int_58;

	private int int_59;

	private int int_60;

	private int int_61;

	private int int_62;

	private int int_63 = -1;

	private int int_64;

	private int int_65;

	private int int_66;

	private int int_67;

	private int int_68 = -1;

	private int int_69;

	private int int_70;

	private int int_71;

	private int int_72;

	private int int_73;

	private int int_74;

	private int int_75;

	private int int_76;

	private int int_77;

	private int int_78;

	private int int_79;

	private int int_80;

	private int int_81;

	private int int_82;

	private int int_83;

	private int int_84;

	private int int_85;

	private int int_86;

	private int int_87;

	private int int_88;

	private int int_89 = 6;

	private int int_90;

	private int int_91;

	private int int_92;

	private int int_93;

	private int int_94;

	private int int_95;

	private int int_96;

	private int int_97;

	private int int_98;

	private int int_99;

	private int int_100;

	private int int_101;

	private int int_102;

	private int int_103;

	private int int_104 = 1;

	private int int_105;

	private int int_106;

	private int int_107;

	private int int_108;

	private int int_109;

	private int int_110;

	private int int_111;

	private int int_112;

	private int int_113;

	private int int_114;

	private int int_115;

	private int int_116;

	private int int_117;

	private int int_118;

	private int int_119;

	private int int_120;

	private int int_121;

	private int int_122;

	private int int_123;

	private int int_124;

	private int int_125;

	private int int_126;

	private int int_127;

	private int int_128;

	private int int_129;

	private int int_130;

	private int int_131;

	private int int_132;

	private int int_133;

	private int int_134;

	private int int_135;

	private int int_136;

	private int int_137;

	private int int_138;

	private int int_139;

	private int int_140 = 1;

	private int int_141;

	private int int_142;

	private int int_143;

	private int int_144;

	private int int_145;

	private int int_146;

	private int int_147;

	private int int_148;

	private int int_149;

	private int int_150;

	private int int_151;

	private int int_152;

	private int int_153;

	private int int_154;

	private int int_155;

	private int int_156;

	private int int_157;

	private int int_158;

	private int int_159;

	private int int_160;

	private int int_161;

	private int int_162;

	private int int_163;

	private int int_164;

	private int int_165;

	private int int_166;

	private int int_167;

	private int int_168;

	private int int_169;

	private int int_170;

	private int int_171;

	private int int_172;

	private int int_173;

	private int int_174;

	private int int_175;

	private int int_176;

	private int int_177;

	private int int_178;

	private int int_179;

	private int int_180;

	private int int_181;

	private int int_182;

	private int int_183;

	private int int_184;

	private int int_185;

	private int int_186;

	private int int_187;

	private int int_188;

	private int int_189;

	private int int_190;

	private int int_191;

	private int int_192;

	private int int_193;

	private int int_194;

	private int int_195;

	private int int_196;

	private int int_197;

	private int int_198;

	private int int_199;

	private int int_200;

	private int int_201;

	private int int_202;

	private int int_203;

	private int int_204;

	private int int_205;

	private int int_206;

	private int int_207;

	private int int_208;

	private int int_209;

	private int int_210;

	private int int_211;

	private int int_212;

	private int int_213;

	private int int_214;

	private int int_215;

	private int int_216;

	private int int_217;

	private int int_218;

	private int int_219;

	private int int_220;

	private int int_221;

	private int int_222;

	private int int_223;

	private int[] int_224 = new int[18];

	private int[] int_225 = new int[0];

	private int[] int_226 = new int[2];

	private int[] int_227 = new int[4];

	private int[] int_228 = new int[0];

	private int[] int_229 = new int[0];

	private int[] int_230 = new int[0];

	private int[] int_231 = new int[0];

	private int[] int_232 = new int[0];

	private int[] int_233 = new int[0];

	private int[] int_234 = new int[0];

	private int[] int_235 = new int[0];

	private int[] int_236 = new int[0];

	private int[] int_237 = new int[20];

	private int[] int_238 = new int[20];

	private int[] int_239 = new int[20];

	private short short_0;

	private short short_1;

	private short short_2;

	private short short_3;

	private short short_4;

	private short short_5;

	private short short_6;

	private short short_7 = 1;

	private short[] short_8 = new short[30];

	public short[] m_pszSignature = new short[0];

	public short[] m_szName = new short[30];

	private short[] short_9 = new short[20];

	private short[] short_10 = new short[20];

	private short[] short_11 = new short[20];

	private short[] short_12 = new short[20];

	private short[][] short_13 = new short[0][];

	private short[][] short_14 = new short[0][];

	private short[][] short_15 = new short[0][];

	private task_tm task_tm_0 = new task_tm();

	private task_tm task_tm_1 = new task_tm();

	private task_tm task_tm_2 = new task_tm();

	private task_tm task_tm_3 = new task_tm();

	private task_tm[] task_tm_4 = new task_tm[0];

	private task_tm[] task_tm_5 = new task_tm[0];

	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	private uint uint_4;

	private uint uint_5;

	private uint uint_6;

	private uint uint_7;

	private uint uint_8;

	private uint uint_9;

	private uint uint_10;

	private uint uint_11;

	private uint uint_12;

	private uint uint_13;

	private uint uint_14;

	private uint uint_15;

	private uint uint_16;

	private uint uint_17;

	private uint uint_18;

	private uint uint_19;

	private uint uint_20;

	private int int_240;

	private int int_241;

	private int int_242;

	public AWARD_CARRIER_HP_SCALE AwByCarrierHp_F
	{
		[CompilerGenerated]
		get
		{
			return award_CARRIER_HP_SCALE_0;
		}
		[CompilerGenerated]
		set
		{
			award_CARRIER_HP_SCALE_0 = value;
		}
	}

	public AWARD_CARRIER_HP_SCALE AwByCarrierHp_S
	{
		[CompilerGenerated]
		get
		{
			return award_CARRIER_HP_SCALE_1;
		}
		[CompilerGenerated]
		set
		{
			award_CARRIER_HP_SCALE_1 = value;
		}
	}

	public AWARD_DATA m_Award_F
	{
		[CompilerGenerated]
		get
		{
			return award_DATA_0;
		}
		[CompilerGenerated]
		set
		{
			award_DATA_0 = value;
		}
	}

	public AWARD_DATA m_Award_S
	{
		[CompilerGenerated]
		get
		{
			return award_DATA_1;
		}
		[CompilerGenerated]
		set
		{
			award_DATA_1 = value;
		}
	}

	public AWARD_ITEMS_SCALE m_AwByItems_F
	{
		[CompilerGenerated]
		get
		{
			return award_ITEMS_SCALE_0;
		}
		[CompilerGenerated]
		set
		{
			award_ITEMS_SCALE_0 = value;
		}
	}

	public AWARD_ITEMS_SCALE m_AwByItems_S
	{
		[CompilerGenerated]
		get
		{
			return award_ITEMS_SCALE_1;
		}
		[CompilerGenerated]
		set
		{
			award_ITEMS_SCALE_1 = value;
		}
	}

	public AWARD_MONSTERS_SUMMONED PropMonsterSummoned
	{
		[CompilerGenerated]
		get
		{
			return award_MONSTERS_SUMMONED_0;
		}
		[CompilerGenerated]
		set
		{
			award_MONSTERS_SUMMONED_0 = value;
		}
	}

	public AWARD_RATIO_SCALE AwByTaskEventRatio_F
	{
		[CompilerGenerated]
		get
		{
			return award_RATIO_SCALE_0;
		}
		[CompilerGenerated]
		set
		{
			award_RATIO_SCALE_0 = value;
		}
	}

	public AWARD_RATIO_SCALE AwByTaskEventRatio_S
	{
		[CompilerGenerated]
		get
		{
			return award_RATIO_SCALE_1;
		}
		[CompilerGenerated]
		set
		{
			award_RATIO_SCALE_1 = value;
		}
	}

	public AWARD_RATIO_SCALE m_AwByRatio_F
	{
		[CompilerGenerated]
		get
		{
			return award_RATIO_SCALE_2;
		}
		[CompilerGenerated]
		set
		{
			award_RATIO_SCALE_2 = value;
		}
	}

	public AWARD_RATIO_SCALE m_AwByRatio_S
	{
		[CompilerGenerated]
		get
		{
			return award_RATIO_SCALE_3;
		}
		[CompilerGenerated]
		set
		{
			award_RATIO_SCALE_3 = value;
		}
	}

	public AWARD_VAR_SCALE AwByVar_F
	{
		[CompilerGenerated]
		get
		{
			return award_VAR_SCALE_0;
		}
		[CompilerGenerated]
		set
		{
			award_VAR_SCALE_0 = value;
		}
	}

	public AWARD_VAR_SCALE AwByVar_S
	{
		[CompilerGenerated]
		get
		{
			return award_VAR_SCALE_1;
		}
		[CompilerGenerated]
		set
		{
			award_VAR_SCALE_1 = value;
		}
	}

	public COMPARE_KEY_VALUE m_Fin1HistoryKeyValue
	{
		[CompilerGenerated]
		get
		{
			return compare_KEY_VALUE_0;
		}
		[CompilerGenerated]
		set
		{
			compare_KEY_VALUE_0 = value;
		}
	}

	public COMPARE_KEY_VALUE m_Fin1KeyValue
	{
		[CompilerGenerated]
		get
		{
			return compare_KEY_VALUE_1;
		}
		[CompilerGenerated]
		set
		{
			compare_KEY_VALUE_1 = value;
		}
	}

	public COMPARE_KEY_VALUE m_Fin1PersonKeyValue
	{
		[CompilerGenerated]
		get
		{
			return compare_KEY_VALUE_2;
		}
		[CompilerGenerated]
		set
		{
			compare_KEY_VALUE_2 = value;
		}
	}

	public COMPARE_KEY_VALUE m_Fin2HistoryKeyValue
	{
		[CompilerGenerated]
		get
		{
			return compare_KEY_VALUE_3;
		}
		[CompilerGenerated]
		set
		{
			compare_KEY_VALUE_3 = value;
		}
	}

	public COMPARE_KEY_VALUE m_Fin2KeyValue
	{
		[CompilerGenerated]
		get
		{
			return compare_KEY_VALUE_4;
		}
		[CompilerGenerated]
		set
		{
			compare_KEY_VALUE_4 = value;
		}
	}

	public COMPARE_KEY_VALUE m_Fin2PersonKeyValue
	{
		[CompilerGenerated]
		get
		{
			return compare_KEY_VALUE_5;
		}
		[CompilerGenerated]
		set
		{
			compare_KEY_VALUE_5 = value;
		}
	}

	public COMPARE_KEY_VALUE m_Prem1HistoryKeyValue
	{
		[CompilerGenerated]
		get
		{
			return compare_KEY_VALUE_6;
		}
		[CompilerGenerated]
		set
		{
			compare_KEY_VALUE_6 = value;
		}
	}

	public COMPARE_KEY_VALUE m_Prem1KeyValue
	{
		[CompilerGenerated]
		get
		{
			return compare_KEY_VALUE_7;
		}
		[CompilerGenerated]
		set
		{
			compare_KEY_VALUE_7 = value;
		}
	}

	public COMPARE_KEY_VALUE m_Prem1PersonKeyValue
	{
		[CompilerGenerated]
		get
		{
			return compare_KEY_VALUE_8;
		}
		[CompilerGenerated]
		set
		{
			compare_KEY_VALUE_8 = value;
		}
	}

	public COMPARE_KEY_VALUE m_Prem2HistoryKeyValue
	{
		[CompilerGenerated]
		get
		{
			return compare_KEY_VALUE_9;
		}
		[CompilerGenerated]
		set
		{
			compare_KEY_VALUE_9 = value;
		}
	}

	public COMPARE_KEY_VALUE m_Prem2KeyValue
	{
		[CompilerGenerated]
		get
		{
			return compare_KEY_VALUE_10;
		}
		[CompilerGenerated]
		set
		{
			compare_KEY_VALUE_10 = value;
		}
	}

	public COMPARE_KEY_VALUE m_Prem2PersonKeyValue
	{
		[CompilerGenerated]
		get
		{
			return compare_KEY_VALUE_11;
		}
		[CompilerGenerated]
		set
		{
			compare_KEY_VALUE_11 = value;
		}
	}

	public COMPARE_KEY_VALUE m_Prop1KeyValue
	{
		[CompilerGenerated]
		get
		{
			return compare_KEY_VALUE_12;
		}
		[CompilerGenerated]
		set
		{
			compare_KEY_VALUE_12 = value;
		}
	}

	public COMPARE_KEY_VALUE m_Prop1KeyValue_personal
	{
		[CompilerGenerated]
		get
		{
			return compare_KEY_VALUE_13;
		}
		[CompilerGenerated]
		set
		{
			compare_KEY_VALUE_13 = value;
		}
	}

	public COMPARE_KEY_VALUE m_Prop2KeyValue
	{
		[CompilerGenerated]
		get
		{
			return compare_KEY_VALUE_14;
		}
		[CompilerGenerated]
		set
		{
			compare_KEY_VALUE_14 = value;
		}
	}

	public COMPARE_KEY_VALUE m_Prop2KeyValue_personal
	{
		[CompilerGenerated]
		get
		{
			return compare_KEY_VALUE_15;
		}
		[CompilerGenerated]
		set
		{
			compare_KEY_VALUE_15 = value;
		}
	}

	public HOME_ITEM_WANTED[] m_HomeItemsWanted
	{
		[CompilerGenerated]
		get
		{
			return home_ITEM_WANTED_0;
		}
		[CompilerGenerated]
		set
		{
			home_ITEM_WANTED_0 = value;
		}
	}

	public ITEM_WANTED[] m_GivenItems
	{
		[CompilerGenerated]
		get
		{
			return item_WANTED_0;
		}
		[CompilerGenerated]
		set
		{
			item_WANTED_0 = value;
		}
	}

	public ITEM_WANTED[] m_ItemsWanted
	{
		[CompilerGenerated]
		get
		{
			return item_WANTED_1;
		}
		[CompilerGenerated]
		set
		{
			item_WANTED_1 = value;
		}
	}

	public ITEM_WANTED[] m_PremItems
	{
		[CompilerGenerated]
		get
		{
			return item_WANTED_2;
		}
		[CompilerGenerated]
		set
		{
			item_WANTED_2 = value;
		}
	}

	public ITEM_WANTED[] m_pChangeSceneRemoveItemRegionNum
	{
		[CompilerGenerated]
		get
		{
			return item_WANTED_3;
		}
		[CompilerGenerated]
		set
		{
			item_WANTED_3 = value;
		}
	}

	public ITEM_WANTED[] m_pSubmitItemWanted
	{
		[CompilerGenerated]
		get
		{
			return item_WANTED_4;
		}
		[CompilerGenerated]
		set
		{
			item_WANTED_4 = value;
		}
	}

	public MONSTERS_CONTRIB[] m_MonstersContrib
	{
		[CompilerGenerated]
		get
		{
			return monsters_CONTRIB_0;
		}
		[CompilerGenerated]
		set
		{
			monsters_CONTRIB_0 = value;
		}
	}

	public MONSTER_WANTED[] m_MonsterUnwanted
	{
		[CompilerGenerated]
		get
		{
			return monster_WANTED_0;
		}
		[CompilerGenerated]
		set
		{
			monster_WANTED_0 = value;
		}
	}

	public MONSTER_WANTED[] m_MonsterWanted
	{
		[CompilerGenerated]
		get
		{
			return monster_WANTED_1;
		}
		[CompilerGenerated]
		set
		{
			monster_WANTED_1 = value;
		}
	}

	public PLAYER_WANTED[] m_PlayerWanted
	{
		[CompilerGenerated]
		get
		{
			return player_WANTED_0;
		}
		[CompilerGenerated]
		set
		{
			player_WANTED_0 = value;
		}
	}

	public SPECIAL_PARAMETERS SpecialParameters
	{
		[CompilerGenerated]
		get
		{
			return special_PARAMETERS_0;
		}
		[CompilerGenerated]
		set
		{
			special_PARAMETERS_0 = value;
		}
	}

	public TASK_EXPRESSION[][] HistoryExpArr
	{
		[CompilerGenerated]
		get
		{
			return task_EXPRESSION_0;
		}
		[CompilerGenerated]
		set
		{
			task_EXPRESSION_0 = value;
		}
	}

	public TASK_EXPRESSION[][] PersonExpArr
	{
		[CompilerGenerated]
		get
		{
			return task_EXPRESSION_1;
		}
		[CompilerGenerated]
		set
		{
			task_EXPRESSION_1 = value;
		}
	}

	public TASK_EXPRESSION[][] m_pExpArr
	{
		[CompilerGenerated]
		get
		{
			return task_EXPRESSION_2;
		}
		[CompilerGenerated]
		set
		{
			task_EXPRESSION_2 = value;
		}
	}

	public TASK_EXPRESSION[][] m_pPQExpArr
	{
		[CompilerGenerated]
		get
		{
			return task_EXPRESSION_3;
		}
		[CompilerGenerated]
		set
		{
			task_EXPRESSION_3 = value;
		}
	}

	public TEAM_MEM_WANTED[] m_TeamMemsWanted
	{
		[CompilerGenerated]
		get
		{
			return team_MEM_WANTED_0;
		}
		[CompilerGenerated]
		set
		{
			team_MEM_WANTED_0 = value;
		}
	}

	public TSMNPCServices[] m_pTSMNPCServices
	{
		[CompilerGenerated]
		get
		{
			return tsmnpcservices_0;
		}
		[CompilerGenerated]
		set
		{
			tsmnpcservices_0 = value;
		}
	}

	public TSMTargetTask[] m_pTSMTargetTask
	{
		[CompilerGenerated]
		get
		{
			return tsmtargetTask_0;
		}
		[CompilerGenerated]
		set
		{
			tsmtargetTask_0 = value;
		}
	}

	public TaskEventData[] TaskEventMineData
	{
		[CompilerGenerated]
		get
		{
			return taskEventData_0;
		}
		[CompilerGenerated]
		set
		{
			taskEventData_0 = value;
		}
	}

	public TaskEventData[] TaskEventMonsterData
	{
		[CompilerGenerated]
		get
		{
			return taskEventData_1;
		}
		[CompilerGenerated]
		set
		{
			taskEventData_1 = value;
		}
	}

	public TaskEventData[] TaskEventTaskData
	{
		[CompilerGenerated]
		get
		{
			return taskEventData_2;
		}
		[CompilerGenerated]
		set
		{
			taskEventData_2 = value;
		}
	}

	public Task_Region[] m_pChangeSceneRemoveNum
	{
		[CompilerGenerated]
		get
		{
			return task_Region_0;
		}
		[CompilerGenerated]
		set
		{
			task_Region_0 = value;
		}
	}

	public Task_Region[] m_pDelvRegion
	{
		[CompilerGenerated]
		get
		{
			return task_Region_1;
		}
		[CompilerGenerated]
		set
		{
			task_Region_1 = value;
		}
	}

	public Task_Region[] m_pEnterRegion
	{
		[CompilerGenerated]
		get
		{
			return task_Region_2;
		}
		[CompilerGenerated]
		set
		{
			task_Region_2 = value;
		}
	}

	public Task_Region[] m_pLeaveRegion
	{
		[CompilerGenerated]
		get
		{
			return task_Region_3;
		}
		[CompilerGenerated]
		set
		{
			task_Region_3 = value;
		}
	}

	public Task_Region[] m_pLeaveSite
	{
		[CompilerGenerated]
		get
		{
			return task_Region_4;
		}
		[CompilerGenerated]
		set
		{
			task_Region_4 = value;
		}
	}

	public Task_Region[] m_pReachSite
	{
		[CompilerGenerated]
		get
		{
			return task_Region_5;
		}
		[CompilerGenerated]
		set
		{
			task_Region_5 = value;
		}
	}

	public VAGUE_PROMPT_INFO[] m_pVaguePromptInfo
	{
		[CompilerGenerated]
		get
		{
			return vague_PROMPT_INFO_0;
		}
		[CompilerGenerated]
		set
		{
			vague_PROMPT_INFO_0 = value;
		}
	}

	public ZONE_VERT m_TransPt
	{
		[CompilerGenerated]
		get
		{
			return zone_VERT_0;
		}
		[CompilerGenerated]
		set
		{
			zone_VERT_0 = value;
		}
	}

	public ZONE_VERT m_TreasureStartZone
	{
		[CompilerGenerated]
		get
		{
			return zone_VERT_1;
		}
		[CompilerGenerated]
		set
		{
			zone_VERT_1 = value;
		}
	}

	public bool m_bPremPersonNeedComp
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public bool m_bAbsFail
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public bool m_bAbsTime
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public bool m_bAccountTaskLimit
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	public bool m_bAllFail
	{
		[CompilerGenerated]
		get
		{
			return bool_4;
		}
		[CompilerGenerated]
		set
		{
			bool_4 = value;
		}
	}

	public bool m_bAllSucc
	{
		[CompilerGenerated]
		get
		{
			return bool_5;
		}
		[CompilerGenerated]
		set
		{
			bool_5 = value;
		}
	}

	public bool m_bAllowBatchAward
	{
		[CompilerGenerated]
		get
		{
			return bool_6;
		}
		[CompilerGenerated]
		set
		{
			bool_6 = value;
		}
	}

	public bool m_bAutoDeliver
	{
		[CompilerGenerated]
		get
		{
			return bool_7;
		}
		[CompilerGenerated]
		set
		{
			bool_7 = value;
		}
	}

	public bool m_bAutoDeliverHighPriority
	{
		[CompilerGenerated]
		get
		{
			return bool_8;
		}
		[CompilerGenerated]
		set
		{
			bool_8 = value;
		}
	}

	public bool m_bAvailFrequency
	{
		[CompilerGenerated]
		get
		{
			return bool_9;
		}
		[CompilerGenerated]
		set
		{
			bool_9 = value;
		}
	}

	public bool m_bFailIconStateID
	{
		[CompilerGenerated]
		get
		{
			return bool_10;
		}
		[CompilerGenerated]
		set
		{
			bool_10 = value;
		}
	}

	public bool m_bMethodTotalItemsWanted
	{
		[CompilerGenerated]
		get
		{
			return bool_11;
		}
		[CompilerGenerated]
		set
		{
			bool_11 = value;
		}
	}

	public bool m_bPremTotalItemsWanted
	{
		[CompilerGenerated]
		get
		{
			return bool_12;
		}
		[CompilerGenerated]
		set
		{
			bool_12 = value;
		}
	}

	public bool m_bBecomeMentor
	{
		[CompilerGenerated]
		get
		{
			return bool_13;
		}
		[CompilerGenerated]
		set
		{
			bool_13 = value;
		}
	}

	public bool m_bBindedRecaller
	{
		[CompilerGenerated]
		get
		{
			return bool_14;
		}
		[CompilerGenerated]
		set
		{
			bool_14 = value;
		}
	}

	public bool m_bCanAwardOnCarrier
	{
		[CompilerGenerated]
		get
		{
			return bool_15;
		}
		[CompilerGenerated]
		set
		{
			bool_15 = value;
		}
	}

	public bool m_bCanGiveUp
	{
		[CompilerGenerated]
		get
		{
			return bool_16;
		}
		[CompilerGenerated]
		set
		{
			bool_16 = value;
		}
	}

	public bool m_bCanRedo
	{
		[CompilerGenerated]
		get
		{
			return bool_17;
		}
		[CompilerGenerated]
		set
		{
			bool_17 = value;
		}
	}

	public bool m_bCanRedoAfterFailure
	{
		[CompilerGenerated]
		get
		{
			return bool_18;
		}
		[CompilerGenerated]
		set
		{
			bool_18 = value;
		}
	}

	public bool m_bCanSeekOut
	{
		[CompilerGenerated]
		get
		{
			return bool_19;
		}
		[CompilerGenerated]
		set
		{
			bool_19 = value;
		}
	}

	public bool m_bCapFail
	{
		[CompilerGenerated]
		get
		{
			return bool_20;
		}
		[CompilerGenerated]
		set
		{
			bool_20 = value;
		}
	}

	public bool m_bCapSucc
	{
		[CompilerGenerated]
		get
		{
			return bool_21;
		}
		[CompilerGenerated]
		set
		{
			bool_21 = value;
		}
	}

	public bool m_bChangePQRanking
	{
		[CompilerGenerated]
		get
		{
			return bool_22;
		}
		[CompilerGenerated]
		set
		{
			bool_22 = value;
		}
	}

	public bool m_bCharTime
	{
		[CompilerGenerated]
		get
		{
			return bool_23;
		}
		[CompilerGenerated]
		set
		{
			bool_23 = value;
		}
	}

	public bool m_bCheckExp
	{
		[CompilerGenerated]
		get
		{
			return bool_24;
		}
		[CompilerGenerated]
		set
		{
			bool_24 = value;
		}
	}

	public bool m_bCheckFactionMember
	{
		[CompilerGenerated]
		get
		{
			return bool_25;
		}
		[CompilerGenerated]
		set
		{
			bool_25 = value;
		}
	}

	public bool m_bCheckInventorySize
	{
		[CompilerGenerated]
		get
		{
			return bool_26;
		}
		[CompilerGenerated]
		set
		{
			bool_26 = value;
		}
	}

	public bool m_bCheckLieMoLevel
	{
		[CompilerGenerated]
		get
		{
			return bool_27;
		}
		[CompilerGenerated]
		set
		{
			bool_27 = value;
		}
	}

	public bool m_bCheckPanguEquip
	{
		[CompilerGenerated]
		get
		{
			return bool_28;
		}
		[CompilerGenerated]
		set
		{
			bool_28 = value;
		}
	}

	public bool m_bCheckRealmExp
	{
		[CompilerGenerated]
		get
		{
			return bool_29;
		}
		[CompilerGenerated]
		set
		{
			bool_29 = value;
		}
	}

	public bool m_bCheckStorageSize
	{
		[CompilerGenerated]
		get
		{
			return bool_30;
		}
		[CompilerGenerated]
		set
		{
			bool_30 = value;
		}
	}

	public bool m_bCheckTeammate
	{
		[CompilerGenerated]
		get
		{
			return bool_31;
		}
		[CompilerGenerated]
		set
		{
			bool_31 = value;
		}
	}

	public bool m_bCheckTradeTime
	{
		[CompilerGenerated]
		get
		{
			return bool_32;
		}
		[CompilerGenerated]
		set
		{
			bool_32 = value;
		}
	}

	public bool m_bCheckYuMoLevel
	{
		[CompilerGenerated]
		get
		{
			return bool_33;
		}
		[CompilerGenerated]
		set
		{
			bool_33 = value;
		}
	}

	public bool m_bChooseOne
	{
		[CompilerGenerated]
		get
		{
			return bool_34;
		}
		[CompilerGenerated]
		set
		{
			bool_34 = value;
		}
	}

	public bool m_bClearAcquired
	{
		[CompilerGenerated]
		get
		{
			return bool_35;
		}
		[CompilerGenerated]
		set
		{
			bool_35 = value;
		}
	}

	public bool m_bClearAsGiveUp
	{
		[CompilerGenerated]
		get
		{
			return bool_36;
		}
		[CompilerGenerated]
		set
		{
			bool_36 = value;
		}
	}

	public bool m_bClearContrib
	{
		[CompilerGenerated]
		get
		{
			return bool_37;
		}
		[CompilerGenerated]
		set
		{
			bool_37 = value;
		}
	}

	public bool m_bCntByMemPos
	{
		[CompilerGenerated]
		get
		{
			return bool_38;
		}
		[CompilerGenerated]
		set
		{
			bool_38 = value;
		}
	}

	public bool m_bCompareItemAndInventory
	{
		[CompilerGenerated]
		get
		{
			return bool_39;
		}
		[CompilerGenerated]
		set
		{
			bool_39 = value;
		}
	}

	public bool m_bCoupleOnly
	{
		[CompilerGenerated]
		get
		{
			return bool_40;
		}
		[CompilerGenerated]
		set
		{
			bool_40 = value;
		}
	}

	public bool m_bCrossServer
	{
		[CompilerGenerated]
		get
		{
			return bool_41;
		}
		[CompilerGenerated]
		set
		{
			bool_41 = value;
		}
	}

	public bool m_bDeathTrig
	{
		[CompilerGenerated]
		get
		{
			return bool_42;
		}
		[CompilerGenerated]
		set
		{
			bool_42 = value;
		}
	}

	public bool m_bDeliverByUI
	{
		[CompilerGenerated]
		get
		{
			return bool_43;
		}
		[CompilerGenerated]
		set
		{
			bool_43 = value;
		}
	}

	public bool m_bDeliverInHostHome
	{
		[CompilerGenerated]
		get
		{
			return bool_44;
		}
		[CompilerGenerated]
		set
		{
			bool_44 = value;
		}
	}

	public bool m_bDeliverySkill
	{
		[CompilerGenerated]
		get
		{
			return bool_45;
		}
		[CompilerGenerated]
		set
		{
			bool_45 = value;
		}
	}

	public bool m_bDelvInZone
	{
		[CompilerGenerated]
		get
		{
			return bool_46;
		}
		[CompilerGenerated]
		set
		{
			bool_46 = value;
		}
	}

	public bool m_bDiscardedTask
	{
		[CompilerGenerated]
		get
		{
			return bool_47;
		}
		[CompilerGenerated]
		set
		{
			bool_47 = value;
		}
	}

	public bool m_bDismAsSelfFail
	{
		[CompilerGenerated]
		get
		{
			return bool_48;
		}
		[CompilerGenerated]
		set
		{
			bool_48 = value;
		}
	}

	public bool m_bDisplayInExclusiveUI
	{
		[CompilerGenerated]
		get
		{
			return bool_49;
		}
		[CompilerGenerated]
		set
		{
			bool_49 = value;
		}
	}

	public bool m_bDisplayInTitleTaskUI
	{
		[CompilerGenerated]
		get
		{
			return bool_50;
		}
		[CompilerGenerated]
		set
		{
			bool_50 = value;
		}
	}

	public bool m_bDistinguishedOcc
	{
		[CompilerGenerated]
		get
		{
			return bool_51;
		}
		[CompilerGenerated]
		set
		{
			bool_51 = value;
		}
	}

	public bool m_bDoNotShowGfx
	{
		[CompilerGenerated]
		get
		{
			return bool_52;
		}
		[CompilerGenerated]
		set
		{
			bool_52 = value;
		}
	}

	public bool m_bEnterRegionFail
	{
		[CompilerGenerated]
		get
		{
			return bool_53;
		}
		[CompilerGenerated]
		set
		{
			bool_53 = value;
		}
	}

	public bool m_bExeChildInOrder
	{
		[CompilerGenerated]
		get
		{
			return bool_54;
		}
		[CompilerGenerated]
		set
		{
			bool_54 = value;
		}
	}

	public bool m_bFailAsPlayerDie
	{
		[CompilerGenerated]
		get
		{
			return bool_55;
		}
		[CompilerGenerated]
		set
		{
			bool_55 = value;
		}
	}

	public bool m_bFinHistoryNeedComp
	{
		[CompilerGenerated]
		get
		{
			return bool_56;
		}
		[CompilerGenerated]
		set
		{
			bool_56 = value;
		}
	}

	public bool m_bFinNeedComp
	{
		[CompilerGenerated]
		get
		{
			return bool_57;
		}
		[CompilerGenerated]
		set
		{
			bool_57 = value;
		}
	}

	public bool m_bFinPersonNeedComp
	{
		[CompilerGenerated]
		get
		{
			return bool_58;
		}
		[CompilerGenerated]
		set
		{
			bool_58 = value;
		}
	}

	public bool m_bFinishInHostHome
	{
		[CompilerGenerated]
		get
		{
			return bool_59;
		}
		[CompilerGenerated]
		set
		{
			bool_59 = value;
		}
	}

	public bool m_bGM
	{
		[CompilerGenerated]
		get
		{
			return bool_60;
		}
		[CompilerGenerated]
		set
		{
			bool_60 = value;
		}
	}

	public bool m_bHasSign
	{
		[CompilerGenerated]
		get
		{
			return bool_61;
		}
		[CompilerGenerated]
		set
		{
			bool_61 = value;
		}
	}

	public bool m_bHidden
	{
		[CompilerGenerated]
		get
		{
			return bool_62;
		}
		[CompilerGenerated]
		set
		{
			bool_62 = value;
		}
	}

	public bool m_bHideOtherPlayer
	{
		[CompilerGenerated]
		get
		{
			return bool_63;
		}
		[CompilerGenerated]
		set
		{
			bool_63 = value;
		}
	}

	public bool m_bHistoryVarTask
	{
		[CompilerGenerated]
		get
		{
			return bool_64;
		}
		[CompilerGenerated]
		set
		{
			bool_64 = value;
		}
	}

	public bool m_bHomeTask
	{
		[CompilerGenerated]
		get
		{
			return bool_65;
		}
		[CompilerGenerated]
		set
		{
			bool_65 = value;
		}
	}

	public bool m_bIsLibraryTask
	{
		[CompilerGenerated]
		get
		{
			return bool_66;
		}
		[CompilerGenerated]
		set
		{
			bool_66 = value;
		}
	}

	public bool m_bIsUniqueStorageTask
	{
		[CompilerGenerated]
		get
		{
			return bool_67;
		}
		[CompilerGenerated]
		set
		{
			bool_67 = value;
		}
	}

	public bool m_bItemNotTakeOff
	{
		[CompilerGenerated]
		get
		{
			return bool_68;
		}
		[CompilerGenerated]
		set
		{
			bool_68 = value;
		}
	}

	public bool m_bKeyTask
	{
		[CompilerGenerated]
		get
		{
			return bool_69;
		}
		[CompilerGenerated]
		set
		{
			bool_69 = value;
		}
	}

	public bool m_bLeaveFactionFail
	{
		[CompilerGenerated]
		get
		{
			return bool_70;
		}
		[CompilerGenerated]
		set
		{
			bool_70 = value;
		}
	}

	public bool m_bLeaveForceFail
	{
		[CompilerGenerated]
		get
		{
			return bool_71;
		}
		[CompilerGenerated]
		set
		{
			bool_71 = value;
		}
	}

	public bool m_bLeaveRegionFail
	{
		[CompilerGenerated]
		get
		{
			return bool_72;
		}
		[CompilerGenerated]
		set
		{
			bool_72 = value;
		}
	}

	public bool m_bMarriage
	{
		[CompilerGenerated]
		get
		{
			return bool_73;
		}
		[CompilerGenerated]
		set
		{
			bool_73 = value;
		}
	}

	public bool m_bMethodItemsRandOne
	{
		[CompilerGenerated]
		get
		{
			return bool_74;
		}
		[CompilerGenerated]
		set
		{
			bool_74 = value;
		}
	}

	public bool m_bMonsterTotalCount
	{
		[CompilerGenerated]
		get
		{
			return bool_75;
		}
		[CompilerGenerated]
		set
		{
			bool_75 = value;
		}
	}

	public bool m_bMultiNpcTalk
	{
		[CompilerGenerated]
		get
		{
			return bool_76;
		}
		[CompilerGenerated]
		set
		{
			bool_76 = value;
		}
	}

	public bool m_bNeedRecord
	{
		[CompilerGenerated]
		get
		{
			return bool_77;
		}
		[CompilerGenerated]
		set
		{
			bool_77 = value;
		}
	}

	public bool m_bNextTimeFail
	{
		[CompilerGenerated]
		get
		{
			return bool_78;
		}
		[CompilerGenerated]
		set
		{
			bool_78 = value;
		}
	}

	public bool m_bNoCheckTitleGot
	{
		[CompilerGenerated]
		get
		{
			return bool_79;
		}
		[CompilerGenerated]
		set
		{
			bool_79 = value;
		}
	}

	public bool m_bNotClearItemWhenFailed
	{
		[CompilerGenerated]
		get
		{
			return bool_80;
		}
		[CompilerGenerated]
		set
		{
			bool_80 = value;
		}
	}

	public bool m_bNotIncCntWhenFailed
	{
		[CompilerGenerated]
		get
		{
			return bool_81;
		}
		[CompilerGenerated]
		set
		{
			bool_81 = value;
		}
	}

	public bool m_bNotOpenWithItem
	{
		[CompilerGenerated]
		get
		{
			return bool_82;
		}
		[CompilerGenerated]
		set
		{
			bool_82 = value;
		}
	}

	public bool m_bOfflineFail
	{
		[CompilerGenerated]
		get
		{
			return bool_83;
		}
		[CompilerGenerated]
		set
		{
			bool_83 = value;
		}
	}

	public bool m_bPQSubTask
	{
		[CompilerGenerated]
		get
		{
			return bool_84;
		}
		[CompilerGenerated]
		set
		{
			bool_84 = value;
		}
	}

	public bool m_bPQTask
	{
		[CompilerGenerated]
		get
		{
			return bool_85;
		}
		[CompilerGenerated]
		set
		{
			bool_85 = value;
		}
	}

	public bool m_bParentAlsoFail
	{
		[CompilerGenerated]
		get
		{
			return bool_86;
		}
		[CompilerGenerated]
		set
		{
			bool_86 = value;
		}
	}

	public bool m_bParentAlsoSucc
	{
		[CompilerGenerated]
		get
		{
			return bool_87;
		}
		[CompilerGenerated]
		set
		{
			bool_87 = value;
		}
	}

	public bool m_bPremCheckForce
	{
		[CompilerGenerated]
		get
		{
			return bool_88;
		}
		[CompilerGenerated]
		set
		{
			bool_88 = value;
		}
	}

	public bool m_bPremCheckPanguLevel
	{
		[CompilerGenerated]
		get
		{
			return bool_89;
		}
		[CompilerGenerated]
		set
		{
			bool_89 = value;
		}
	}

	public bool m_bPremCheckRealmExpFull
	{
		[CompilerGenerated]
		get
		{
			return bool_90;
		}
		[CompilerGenerated]
		set
		{
			bool_90 = value;
		}
	}

	public bool m_bPremCheckRealmLevel
	{
		[CompilerGenerated]
		get
		{
			return bool_91;
		}
		[CompilerGenerated]
		set
		{
			bool_91 = value;
		}
	}

	public bool m_bPremCheckReincarnation
	{
		[CompilerGenerated]
		get
		{
			return bool_92;
		}
		[CompilerGenerated]
		set
		{
			bool_92 = value;
		}
	}

	public bool m_bPremFaction
	{
		[CompilerGenerated]
		get
		{
			return bool_93;
		}
		[CompilerGenerated]
		set
		{
			bool_93 = value;
		}
	}

	public bool m_bPremHistoryNeedComp
	{
		[CompilerGenerated]
		get
		{
			return bool_94;
		}
		[CompilerGenerated]
		set
		{
			bool_94 = value;
		}
	}

	public bool m_bPremHomeStorageTask
	{
		[CompilerGenerated]
		get
		{
			return bool_95;
		}
		[CompilerGenerated]
		set
		{
			bool_95 = value;
		}
	}

	public bool m_bPremIsKing
	{
		[CompilerGenerated]
		get
		{
			return bool_96;
		}
		[CompilerGenerated]
		set
		{
			bool_96 = value;
		}
	}

	public bool m_bPremItemsAnyOne
	{
		[CompilerGenerated]
		get
		{
			return bool_97;
		}
		[CompilerGenerated]
		set
		{
			bool_97 = value;
		}
	}

	public bool m_bPremNeedComp
	{
		[CompilerGenerated]
		get
		{
			return bool_98;
		}
		[CompilerGenerated]
		set
		{
			bool_98 = value;
		}
	}

	public bool m_bPremNoHome
	{
		[CompilerGenerated]
		get
		{
			return bool_99;
		}
		[CompilerGenerated]
		set
		{
			bool_99 = value;
		}
	}

	public bool m_bPremNotInTeam
	{
		[CompilerGenerated]
		get
		{
			return bool_100;
		}
		[CompilerGenerated]
		set
		{
			bool_100 = value;
		}
	}

	public bool m_bPremReachArenaWinCount
	{
		[CompilerGenerated]
		get
		{
			return bool_101;
		}
		[CompilerGenerated]
		set
		{
			bool_101 = value;
		}
	}

	public bool m_bPremiseWeddingOwner
	{
		[CompilerGenerated]
		get
		{
			return bool_102;
		}
		[CompilerGenerated]
		set
		{
			bool_102 = value;
		}
	}

	public bool m_bPremise_Spouse
	{
		[CompilerGenerated]
		get
		{
			return bool_103;
		}
		[CompilerGenerated]
		set
		{
			bool_103 = value;
		}
	}

	public bool m_bPropNeedComp
	{
		[CompilerGenerated]
		get
		{
			return bool_104;
		}
		[CompilerGenerated]
		set
		{
			bool_104 = value;
		}
	}

	public bool m_bPropNeedComp_personal
	{
		[CompilerGenerated]
		get
		{
			return bool_105;
		}
		[CompilerGenerated]
		set
		{
			bool_105 = value;
		}
	}

	public bool m_bRandOne
	{
		[CompilerGenerated]
		get
		{
			return bool_106;
		}
		[CompilerGenerated]
		set
		{
			bool_106 = value;
		}
	}

	public bool m_bRankPre
	{
		[CompilerGenerated]
		get
		{
			return bool_107;
		}
		[CompilerGenerated]
		set
		{
			bool_107 = value;
		}
	}

	public bool m_bRcvByTeam
	{
		[CompilerGenerated]
		get
		{
			return bool_108;
		}
		[CompilerGenerated]
		set
		{
			bool_108 = value;
		}
	}

	public bool m_bRcvChckMem
	{
		[CompilerGenerated]
		get
		{
			return bool_109;
		}
		[CompilerGenerated]
		set
		{
			bool_109 = value;
		}
	}

	public bool m_bReadyToNotifyServer
	{
		[CompilerGenerated]
		get
		{
			return bool_110;
		}
		[CompilerGenerated]
		set
		{
			bool_110 = value;
		}
	}

	public bool m_bRecordDeliverTime
	{
		[CompilerGenerated]
		get
		{
			return bool_111;
		}
		[CompilerGenerated]
		set
		{
			bool_111 = value;
		}
	}

	public bool m_bRecordFnshCnt
	{
		[CompilerGenerated]
		get
		{
			return bool_112;
		}
		[CompilerGenerated]
		set
		{
			bool_112 = value;
		}
	}

	public bool m_bRecordReset
	{
		[CompilerGenerated]
		get
		{
			return bool_113;
		}
		[CompilerGenerated]
		set
		{
			bool_113 = value;
		}
	}

	public bool m_bReturnCampPower
	{
		[CompilerGenerated]
		get
		{
			return bool_114;
		}
		[CompilerGenerated]
		set
		{
			bool_114 = value;
		}
	}

	public bool m_bRoleTaskLimit
	{
		[CompilerGenerated]
		get
		{
			return bool_115;
		}
		[CompilerGenerated]
		set
		{
			bool_115 = value;
		}
	}

	public bool m_bSharedAchieved
	{
		[CompilerGenerated]
		get
		{
			return bool_116;
		}
		[CompilerGenerated]
		set
		{
			bool_116 = value;
		}
	}

	public bool m_bSharedTask
	{
		[CompilerGenerated]
		get
		{
			return bool_117;
		}
		[CompilerGenerated]
		set
		{
			bool_117 = value;
		}
	}

	public bool m_bShieldUser
	{
		[CompilerGenerated]
		get
		{
			return bool_118;
		}
		[CompilerGenerated]
		set
		{
			bool_118 = value;
		}
	}

	public bool m_bShowAchievementSeriesId
	{
		[CompilerGenerated]
		get
		{
			return bool_119;
		}
		[CompilerGenerated]
		set
		{
			bool_119 = value;
		}
	}

	public bool m_bShowByCharTime
	{
		[CompilerGenerated]
		get
		{
			return bool_120;
		}
		[CompilerGenerated]
		set
		{
			bool_120 = value;
		}
	}

	public bool m_bShowByDeposit
	{
		[CompilerGenerated]
		get
		{
			return bool_121;
		}
		[CompilerGenerated]
		set
		{
			bool_121 = value;
		}
	}

	public bool m_bShowByExpNotFull
	{
		[CompilerGenerated]
		get
		{
			return bool_122;
		}
		[CompilerGenerated]
		set
		{
			bool_122 = value;
		}
	}

	public bool m_bShowByFaction
	{
		[CompilerGenerated]
		get
		{
			return bool_123;
		}
		[CompilerGenerated]
		set
		{
			bool_123 = value;
		}
	}

	public bool m_bShowByFactionContrib
	{
		[CompilerGenerated]
		get
		{
			return bool_124;
		}
		[CompilerGenerated]
		set
		{
			bool_124 = value;
		}
	}

	public bool m_bShowByFactionMoney
	{
		[CompilerGenerated]
		get
		{
			return bool_125;
		}
		[CompilerGenerated]
		set
		{
			bool_125 = value;
		}
	}

	public bool m_bShowByFactionPersonScore
	{
		[CompilerGenerated]
		get
		{
			return bool_126;
		}
		[CompilerGenerated]
		set
		{
			bool_126 = value;
		}
	}

	public bool m_bShowByFactionScore
	{
		[CompilerGenerated]
		get
		{
			return bool_127;
		}
		[CompilerGenerated]
		set
		{
			bool_127 = value;
		}
	}

	public bool m_bShowByForce
	{
		[CompilerGenerated]
		get
		{
			return bool_128;
		}
		[CompilerGenerated]
		set
		{
			bool_128 = value;
		}
	}

	public bool m_bShowByForceActivityLevel
	{
		[CompilerGenerated]
		get
		{
			return bool_129;
		}
		[CompilerGenerated]
		set
		{
			bool_129 = value;
		}
	}

	public bool m_bShowByForceContribution
	{
		[CompilerGenerated]
		get
		{
			return bool_130;
		}
		[CompilerGenerated]
		set
		{
			bool_130 = value;
		}
	}

	public bool m_bShowByForceExp
	{
		[CompilerGenerated]
		get
		{
			return bool_131;
		}
		[CompilerGenerated]
		set
		{
			bool_131 = value;
		}
	}

	public bool m_bShowByForceReputation
	{
		[CompilerGenerated]
		get
		{
			return bool_132;
		}
		[CompilerGenerated]
		set
		{
			bool_132 = value;
		}
	}

	public bool m_bShowByForceSP
	{
		[CompilerGenerated]
		get
		{
			return bool_133;
		}
		[CompilerGenerated]
		set
		{
			bool_133 = value;
		}
	}

	public bool m_bShowByGender
	{
		[CompilerGenerated]
		get
		{
			return bool_134;
		}
		[CompilerGenerated]
		set
		{
			bool_134 = value;
		}
	}

	public bool m_bShowByGeneralCard
	{
		[CompilerGenerated]
		get
		{
			return bool_135;
		}
		[CompilerGenerated]
		set
		{
			bool_135 = value;
		}
	}

	public bool m_bShowByGeneralCardRank
	{
		[CompilerGenerated]
		get
		{
			return bool_136;
		}
		[CompilerGenerated]
		set
		{
			bool_136 = value;
		}
	}

	public bool m_bShowByHistoryStage
	{
		[CompilerGenerated]
		get
		{
			return bool_137;
		}
		[CompilerGenerated]
		set
		{
			bool_137 = value;
		}
	}

	public bool m_bShowByHomeFactoryLevel
	{
		[CompilerGenerated]
		get
		{
			return bool_138;
		}
		[CompilerGenerated]
		set
		{
			bool_138 = value;
		}
	}

	public bool m_bShowByHomeFlourish
	{
		[CompilerGenerated]
		get
		{
			return bool_139;
		}
		[CompilerGenerated]
		set
		{
			bool_139 = value;
		}
	}

	public bool m_bShowByHomeLevel
	{
		[CompilerGenerated]
		get
		{
			return bool_140;
		}
		[CompilerGenerated]
		set
		{
			bool_140 = value;
		}
	}

	public bool m_bShowByHomeResourceLevel
	{
		[CompilerGenerated]
		get
		{
			return bool_141;
		}
		[CompilerGenerated]
		set
		{
			bool_141 = value;
		}
	}

	public bool m_bShowByHomeStorageTask
	{
		[CompilerGenerated]
		get
		{
			return bool_142;
		}
		[CompilerGenerated]
		set
		{
			bool_142 = value;
		}
	}

	public bool m_bShowByIconStateID
	{
		[CompilerGenerated]
		get
		{
			return bool_143;
		}
		[CompilerGenerated]
		set
		{
			bool_143 = value;
		}
	}

	public bool m_bShowByItems
	{
		[CompilerGenerated]
		get
		{
			return bool_144;
		}
		[CompilerGenerated]
		set
		{
			bool_144 = value;
		}
	}

	public bool m_bShowByKing
	{
		[CompilerGenerated]
		get
		{
			return bool_145;
		}
		[CompilerGenerated]
		set
		{
			bool_145 = value;
		}
	}

	public bool m_bShowByLev
	{
		[CompilerGenerated]
		get
		{
			return bool_146;
		}
		[CompilerGenerated]
		set
		{
			bool_146 = value;
		}
	}

	public bool m_bShowByNeedRecordTasksNum
	{
		[CompilerGenerated]
		get
		{
			return bool_147;
		}
		[CompilerGenerated]
		set
		{
			bool_147 = value;
		}
	}

	public bool m_bShowByNotInTeam
	{
		[CompilerGenerated]
		get
		{
			return bool_148;
		}
		[CompilerGenerated]
		set
		{
			bool_148 = value;
		}
	}

	public bool m_bShowByOccup
	{
		[CompilerGenerated]
		get
		{
			return bool_149;
		}
		[CompilerGenerated]
		set
		{
			bool_149 = value;
		}
	}

	public bool m_bShowByPeriod
	{
		[CompilerGenerated]
		get
		{
			return bool_150;
		}
		[CompilerGenerated]
		set
		{
			bool_150 = value;
		}
	}

	public bool m_bShowByPreTask
	{
		[CompilerGenerated]
		get
		{
			return bool_151;
		}
		[CompilerGenerated]
		set
		{
			bool_151 = value;
		}
	}

	public bool m_bShowByRMB
	{
		[CompilerGenerated]
		get
		{
			return bool_152;
		}
		[CompilerGenerated]
		set
		{
			bool_152 = value;
		}
	}

	public bool m_bShowByReachArenaWinCount
	{
		[CompilerGenerated]
		get
		{
			return bool_153;
		}
		[CompilerGenerated]
		set
		{
			bool_153 = value;
		}
	}

	public bool m_bShowByRealmExpNotFull
	{
		[CompilerGenerated]
		get
		{
			return bool_154;
		}
		[CompilerGenerated]
		set
		{
			bool_154 = value;
		}
	}

	public bool m_bShowByRealmLevel
	{
		[CompilerGenerated]
		get
		{
			return bool_155;
		}
		[CompilerGenerated]
		set
		{
			bool_155 = value;
		}
	}

	public bool m_bShowByReincarnation
	{
		[CompilerGenerated]
		get
		{
			return bool_156;
		}
		[CompilerGenerated]
		set
		{
			bool_156 = value;
		}
	}

	public bool m_bShowByRepu
	{
		[CompilerGenerated]
		get
		{
			return bool_157;
		}
		[CompilerGenerated]
		set
		{
			bool_157 = value;
		}
	}

	public bool m_bShowBySpouse
	{
		[CompilerGenerated]
		get
		{
			return bool_158;
		}
		[CompilerGenerated]
		set
		{
			bool_158 = value;
		}
	}

	public bool m_bShowByTeam
	{
		[CompilerGenerated]
		get
		{
			return bool_159;
		}
		[CompilerGenerated]
		set
		{
			bool_159 = value;
		}
	}

	public bool m_bShowByTitle
	{
		[CompilerGenerated]
		get
		{
			return bool_160;
		}
		[CompilerGenerated]
		set
		{
			bool_160 = value;
		}
	}

	public bool m_bShowByTradeTime
	{
		[CompilerGenerated]
		get
		{
			return bool_161;
		}
		[CompilerGenerated]
		set
		{
			bool_161 = value;
		}
	}

	public bool m_bShowByTransformed
	{
		[CompilerGenerated]
		get
		{
			return bool_162;
		}
		[CompilerGenerated]
		set
		{
			bool_162 = value;
		}
	}

	public bool m_bShowByVIPLevel
	{
		[CompilerGenerated]
		get
		{
			return bool_163;
		}
		[CompilerGenerated]
		set
		{
			bool_163 = value;
		}
	}

	public bool m_bShowByWeddingOwner
	{
		[CompilerGenerated]
		get
		{
			return bool_164;
		}
		[CompilerGenerated]
		set
		{
			bool_164 = value;
		}
	}

	public bool m_bShowCamp
	{
		[CompilerGenerated]
		get
		{
			return bool_165;
		}
		[CompilerGenerated]
		set
		{
			bool_165 = value;
		}
	}

	public bool m_bShowCampPower
	{
		[CompilerGenerated]
		get
		{
			return bool_166;
		}
		[CompilerGenerated]
		set
		{
			bool_166 = value;
		}
	}

	public bool m_bShowCoupleIntimacy
	{
		[CompilerGenerated]
		get
		{
			return bool_167;
		}
		[CompilerGenerated]
		set
		{
			bool_167 = value;
		}
	}

	public bool m_bShowDailyActivityPremise
	{
		[CompilerGenerated]
		get
		{
			return bool_168;
		}
		[CompilerGenerated]
		set
		{
			bool_168 = value;
		}
	}

	public bool m_bShowDeposit2
	{
		[CompilerGenerated]
		get
		{
			return bool_169;
		}
		[CompilerGenerated]
		set
		{
			bool_169 = value;
		}
	}

	public bool m_bShowDirection
	{
		[CompilerGenerated]
		get
		{
			return bool_170;
		}
		[CompilerGenerated]
		set
		{
			bool_170 = value;
		}
	}

	public bool m_bShowExploreIcon
	{
		[CompilerGenerated]
		get
		{
			return bool_171;
		}
		[CompilerGenerated]
		set
		{
			bool_171 = value;
		}
	}

	public bool m_bShowGfxFinished
	{
		[CompilerGenerated]
		get
		{
			return bool_172;
		}
		[CompilerGenerated]
		set
		{
			bool_172 = value;
		}
	}

	public bool m_bShowMentorMorality
	{
		[CompilerGenerated]
		get
		{
			return bool_173;
		}
		[CompilerGenerated]
		set
		{
			bool_173 = value;
		}
	}

	public bool m_bShowMentorStudentValue
	{
		[CompilerGenerated]
		get
		{
			return bool_174;
		}
		[CompilerGenerated]
		set
		{
			bool_174 = value;
		}
	}

	public bool m_bShowMethod
	{
		[CompilerGenerated]
		get
		{
			return bool_175;
		}
		[CompilerGenerated]
		set
		{
			bool_175 = value;
		}
	}

	public bool m_bShowNeedFriendPoint
	{
		[CompilerGenerated]
		get
		{
			return bool_176;
		}
		[CompilerGenerated]
		set
		{
			bool_176 = value;
		}
	}

	public bool m_bShowPackSizePremise
	{
		[CompilerGenerated]
		get
		{
			return bool_177;
		}
		[CompilerGenerated]
		set
		{
			bool_177 = value;
		}
	}

	public bool m_bShowPanguEquipPremise
	{
		[CompilerGenerated]
		get
		{
			return bool_178;
		}
		[CompilerGenerated]
		set
		{
			bool_178 = value;
		}
	}

	public bool m_bShowPrompt
	{
		[CompilerGenerated]
		get
		{
			return bool_179;
		}
		[CompilerGenerated]
		set
		{
			bool_179 = value;
		}
	}

	public bool m_bShowPropertyPremis
	{
		[CompilerGenerated]
		get
		{
			return bool_180;
		}
		[CompilerGenerated]
		set
		{
			bool_180 = value;
		}
	}

	public bool m_bSkillTask
	{
		[CompilerGenerated]
		get
		{
			return bool_181;
		}
		[CompilerGenerated]
		set
		{
			bool_181 = value;
		}
	}

	public bool m_bSpecialLogic
	{
		[CompilerGenerated]
		get
		{
			return bool_182;
		}
		[CompilerGenerated]
		set
		{
			bool_182 = value;
		}
	}

	public bool m_bSwitchSceneFail
	{
		[CompilerGenerated]
		get
		{
			return bool_183;
		}
		[CompilerGenerated]
		set
		{
			bool_183 = value;
		}
	}

	public bool m_bTeamHaveRecaller
	{
		[CompilerGenerated]
		get
		{
			return bool_184;
		}
		[CompilerGenerated]
		set
		{
			bool_184 = value;
		}
	}

	public bool m_bTeamwork
	{
		[CompilerGenerated]
		get
		{
			return bool_185;
		}
		[CompilerGenerated]
		set
		{
			bool_185 = value;
		}
	}

	public bool m_bTowerTask
	{
		[CompilerGenerated]
		get
		{
			return bool_186;
		}
		[CompilerGenerated]
		set
		{
			bool_186 = value;
		}
	}

	public bool m_bTransTo
	{
		[CompilerGenerated]
		get
		{
			return bool_187;
		}
		[CompilerGenerated]
		set
		{
			bool_187 = value;
		}
	}

	public bool m_bTrigCtrl
	{
		[CompilerGenerated]
		get
		{
			return bool_188;
		}
		[CompilerGenerated]
		set
		{
			bool_188 = value;
		}
	}

	public bool m_bUsedInTokenShop
	{
		[CompilerGenerated]
		get
		{
			return bool_189;
		}
		[CompilerGenerated]
		set
		{
			bool_189 = value;
		}
	}

	public bool m_bVaguePromptingMode
	{
		[CompilerGenerated]
		get
		{
			return bool_190;
		}
		[CompilerGenerated]
		set
		{
			bool_190 = value;
		}
	}

	public bool m_bWarTaskAward
	{
		[CompilerGenerated]
		get
		{
			return bool_191;
		}
		[CompilerGenerated]
		set
		{
			bool_191 = value;
		}
	}

	public bool m_bWriteSpecialLog
	{
		[CompilerGenerated]
		get
		{
			return bool_192;
		}
		[CompilerGenerated]
		set
		{
			bool_192 = value;
		}
	}

	public byte m_DynTaskType
	{
		[CompilerGenerated]
		get
		{
			return byte_0;
		}
		[CompilerGenerated]
		set
		{
			byte_0 = value;
		}
	}

	public byte m_cEffectiveGameServer
	{
		[CompilerGenerated]
		get
		{
			return byte_1;
		}
		[CompilerGenerated]
		set
		{
			byte_1 = value;
		}
	}

	public byte m_cPremInventorySizeMax
	{
		[CompilerGenerated]
		get
		{
			return byte_2;
		}
		[CompilerGenerated]
		set
		{
			byte_2 = value;
		}
	}

	public byte m_cPremInventorySizeMin
	{
		[CompilerGenerated]
		get
		{
			return byte_3;
		}
		[CompilerGenerated]
		set
		{
			byte_3 = value;
		}
	}

	public byte m_cPremStorageSizeMax
	{
		[CompilerGenerated]
		get
		{
			return byte_4;
		}
		[CompilerGenerated]
		set
		{
			byte_4 = value;
		}
	}

	public byte m_cPremStorageSizeMin
	{
		[CompilerGenerated]
		get
		{
			return byte_5;
		}
		[CompilerGenerated]
		set
		{
			byte_5 = value;
		}
	}

	public byte m_iNeededTasksLeastNum
	{
		[CompilerGenerated]
		get
		{
			return byte_6;
		}
		[CompilerGenerated]
		set
		{
			byte_6 = value;
		}
	}

	public byte m_iSlotMachineType
	{
		[CompilerGenerated]
		get
		{
			return byte_7;
		}
		[CompilerGenerated]
		set
		{
			byte_7 = value;
		}
	}

	public byte m_iTinyGameType
	{
		[CompilerGenerated]
		get
		{
			return byte_8;
		}
		[CompilerGenerated]
		set
		{
			byte_8 = value;
		}
	}

	public byte m_ucPremiseTransformedForm
	{
		[CompilerGenerated]
		get
		{
			return byte_9;
		}
		[CompilerGenerated]
		set
		{
			byte_9 = value;
		}
	}

	public byte m_ucTransformedForm
	{
		[CompilerGenerated]
		get
		{
			return byte_10;
		}
		[CompilerGenerated]
		set
		{
			byte_10 = value;
		}
	}

	public byte m_ucZoneSide
	{
		[CompilerGenerated]
		get
		{
			return byte_11;
		}
		[CompilerGenerated]
		set
		{
			byte_11 = value;
		}
	}

	public byte m_ucZonesNumX
	{
		[CompilerGenerated]
		get
		{
			return byte_12;
		}
		[CompilerGenerated]
		set
		{
			byte_12 = value;
		}
	}

	public byte m_ucZonesNumZ
	{
		[CompilerGenerated]
		get
		{
			return byte_13;
		}
		[CompilerGenerated]
		set
		{
			byte_13 = value;
		}
	}

	public byte[] CombinedSwitches
	{
		[CompilerGenerated]
		get
		{
			return byte_14;
		}
		[CompilerGenerated]
		set
		{
			byte_14 = value;
		}
	}

	public byte[] m_pbChangeType
	{
		[CompilerGenerated]
		get
		{
			return byte_15;
		}
		[CompilerGenerated]
		set
		{
			byte_15 = value;
		}
	}

	public byte[] m_pbHistoryChangeType
	{
		[CompilerGenerated]
		get
		{
			return byte_16;
		}
		[CompilerGenerated]
		set
		{
			byte_16 = value;
		}
	}

	public byte[] m_pbPersonChangeType
	{
		[CompilerGenerated]
		get
		{
			return byte_17;
		}
		[CompilerGenerated]
		set
		{
			byte_17 = value;
		}
	}

	public byte[] m_tmType
	{
		[CompilerGenerated]
		get
		{
			return byte_18;
		}
		[CompilerGenerated]
		set
		{
			byte_18 = value;
		}
	}

	public char[][] HistoryExp
	{
		[CompilerGenerated]
		get
		{
			return char_0;
		}
		[CompilerGenerated]
		set
		{
			char_0 = value;
		}
	}

	public char[][] PersonExp
	{
		[CompilerGenerated]
		get
		{
			return char_1;
		}
		[CompilerGenerated]
		set
		{
			char_1 = value;
		}
	}

	public char[][] m_pszExp
	{
		[CompilerGenerated]
		get
		{
			return char_2;
		}
		[CompilerGenerated]
		set
		{
			char_2 = value;
		}
	}

	public char[][] m_pszPQExp
	{
		[CompilerGenerated]
		get
		{
			return char_3;
		}
		[CompilerGenerated]
		set
		{
			char_3 = value;
		}
	}

	public float camera_pos_x
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	public float camera_pos_y
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
		[CompilerGenerated]
		set
		{
			float_1 = value;
		}
	}

	public float camera_pos_z
	{
		[CompilerGenerated]
		get
		{
			return float_2;
		}
		[CompilerGenerated]
		set
		{
			float_2 = value;
		}
	}

	public float camera_quat_a
	{
		[CompilerGenerated]
		get
		{
			return float_3;
		}
		[CompilerGenerated]
		set
		{
			float_3 = value;
		}
	}

	public float camera_quat_x
	{
		[CompilerGenerated]
		get
		{
			return float_4;
		}
		[CompilerGenerated]
		set
		{
			float_4 = value;
		}
	}

	public float camera_quat_y
	{
		[CompilerGenerated]
		get
		{
			return float_5;
		}
		[CompilerGenerated]
		set
		{
			float_5 = value;
		}
	}

	public float camera_quat_z
	{
		[CompilerGenerated]
		get
		{
			return float_6;
		}
		[CompilerGenerated]
		set
		{
			float_6 = value;
		}
	}

	public float camera_rotate_angle
	{
		[CompilerGenerated]
		get
		{
			return float_7;
		}
		[CompilerGenerated]
		set
		{
			float_7 = value;
		}
	}

	public float camera_take_seconds
	{
		[CompilerGenerated]
		get
		{
			return float_8;
		}
		[CompilerGenerated]
		set
		{
			float_8 = value;
		}
	}

	public float camera_target_pos_x
	{
		[CompilerGenerated]
		get
		{
			return float_9;
		}
		[CompilerGenerated]
		set
		{
			float_9 = value;
		}
	}

	public float camera_target_pos_y
	{
		[CompilerGenerated]
		get
		{
			return float_10;
		}
		[CompilerGenerated]
		set
		{
			float_10 = value;
		}
	}

	public float camera_target_pos_z
	{
		[CompilerGenerated]
		get
		{
			return float_11;
		}
		[CompilerGenerated]
		set
		{
			float_11 = value;
		}
	}

	public float camera_target_quat_a
	{
		[CompilerGenerated]
		get
		{
			return float_12;
		}
		[CompilerGenerated]
		set
		{
			float_12 = value;
		}
	}

	public float camera_target_quat_x
	{
		[CompilerGenerated]
		get
		{
			return float_13;
		}
		[CompilerGenerated]
		set
		{
			float_13 = value;
		}
	}

	public float camera_target_quat_y
	{
		[CompilerGenerated]
		get
		{
			return float_14;
		}
		[CompilerGenerated]
		set
		{
			float_14 = value;
		}
	}

	public float camera_target_quat_z
	{
		[CompilerGenerated]
		get
		{
			return float_15;
		}
		[CompilerGenerated]
		set
		{
			float_15 = value;
		}
	}

	public float m_fCntMemDist
	{
		[CompilerGenerated]
		get
		{
			return float_16;
		}
		[CompilerGenerated]
		set
		{
			float_16 = value;
		}
	}

	public float m_fLibraryTasksProbability
	{
		[CompilerGenerated]
		get
		{
			return float_17;
		}
		[CompilerGenerated]
		set
		{
			float_17 = value;
		}
	}

	public float m_fRcvMemDist
	{
		[CompilerGenerated]
		get
		{
			return float_18;
		}
		[CompilerGenerated]
		set
		{
			float_18 = value;
		}
	}

	public float m_fSuccDist
	{
		[CompilerGenerated]
		get
		{
			return float_19;
		}
		[CompilerGenerated]
		set
		{
			float_19 = value;
		}
	}

	public float m_fTeammateDist
	{
		[CompilerGenerated]
		get
		{
			return float_20;
		}
		[CompilerGenerated]
		set
		{
			float_20 = value;
		}
	}

	public float m_fVaguePromptRadius
	{
		[CompilerGenerated]
		get
		{
			return float_21;
		}
		[CompilerGenerated]
		set
		{
			float_21 = value;
		}
	}

	public float m_fVaguePromptX
	{
		[CompilerGenerated]
		get
		{
			return float_22;
		}
		[CompilerGenerated]
		set
		{
			float_22 = value;
		}
	}

	public float m_fVaguePromptY
	{
		[CompilerGenerated]
		get
		{
			return float_23;
		}
		[CompilerGenerated]
		set
		{
			float_23 = value;
		}
	}

	public int m_iCameraMovementID
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int AwByCarrierHp_FPointer
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public int AwByCarrierHp_SPointer
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public int AwByTaskEventRatio_FPointer
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	public int AwByTaskEventRatio_SPointer
	{
		[CompilerGenerated]
		get
		{
			return int_4;
		}
		[CompilerGenerated]
		set
		{
			int_4 = value;
		}
	}

	public int AwByVar_FPointer
	{
		[CompilerGenerated]
		get
		{
			return int_5;
		}
		[CompilerGenerated]
		set
		{
			int_5 = value;
		}
	}

	public int AwByVar_SPointer
	{
		[CompilerGenerated]
		get
		{
			return int_6;
		}
		[CompilerGenerated]
		set
		{
			int_6 = value;
		}
	}

	public int SpecialParametersPointer
	{
		[CompilerGenerated]
		get
		{
			return int_7;
		}
		[CompilerGenerated]
		set
		{
			int_7 = value;
		}
	}

	public int TMIconStateDescID
	{
		[CompilerGenerated]
		get
		{
			return int_8;
		}
		[CompilerGenerated]
		set
		{
			int_8 = value;
		}
	}

	public int TaskEventMineDataPointer
	{
		[CompilerGenerated]
		get
		{
			return int_9;
		}
		[CompilerGenerated]
		set
		{
			int_9 = value;
		}
	}

	public int TaskEventMonsterDataPointer
	{
		[CompilerGenerated]
		get
		{
			return int_10;
		}
		[CompilerGenerated]
		set
		{
			int_10 = value;
		}
	}

	public int TaskEventTaskDataPointer
	{
		[CompilerGenerated]
		get
		{
			return int_11;
		}
		[CompilerGenerated]
		set
		{
			int_11 = value;
		}
	}

	public int TransformedDescID
	{
		[CompilerGenerated]
		get
		{
			return int_12;
		}
		[CompilerGenerated]
		set
		{
			int_12 = value;
		}
	}

	public int camera_rotate_axis
	{
		[CompilerGenerated]
		get
		{
			return int_13;
		}
		[CompilerGenerated]
		set
		{
			int_13 = value;
		}
	}

	public int m_AwByItems_FPointer
	{
		[CompilerGenerated]
		get
		{
			return int_14;
		}
		[CompilerGenerated]
		set
		{
			int_14 = value;
		}
	}

	public int m_AwByItems_SPointer
	{
		[CompilerGenerated]
		get
		{
			return int_15;
		}
		[CompilerGenerated]
		set
		{
			int_15 = value;
		}
	}

	public int m_AwByRatio_FPointer
	{
		[CompilerGenerated]
		get
		{
			return int_16;
		}
		[CompilerGenerated]
		set
		{
			int_16 = value;
		}
	}

	public int m_AwByRatio_SPointer
	{
		[CompilerGenerated]
		get
		{
			return int_17;
		}
		[CompilerGenerated]
		set
		{
			int_17 = value;
		}
	}

	public int m_Award_FPointer
	{
		[CompilerGenerated]
		get
		{
			return int_18;
		}
		[CompilerGenerated]
		set
		{
			int_18 = value;
		}
	}

	public int m_Award_SPointer
	{
		[CompilerGenerated]
		get
		{
			return int_19;
		}
		[CompilerGenerated]
		set
		{
			int_19 = value;
		}
	}

	public int m_GivenItemsPointer
	{
		[CompilerGenerated]
		get
		{
			return int_20;
		}
		[CompilerGenerated]
		set
		{
			int_20 = value;
		}
	}

	public int m_HintConfigId
	{
		[CompilerGenerated]
		get
		{
			return int_21;
		}
		[CompilerGenerated]
		set
		{
			int_21 = value;
		}
	}

	public int m_HomeItemsWantedPointer
	{
		[CompilerGenerated]
		get
		{
			return int_22;
		}
		[CompilerGenerated]
		set
		{
			int_22 = value;
		}
	}

	public int m_ItemsWantedPointer
	{
		[CompilerGenerated]
		get
		{
			return int_23;
		}
		[CompilerGenerated]
		set
		{
			int_23 = value;
		}
	}

	public int m_MonsterWantedPointer
	{
		[CompilerGenerated]
		get
		{
			return int_24;
		}
		[CompilerGenerated]
		set
		{
			int_24 = value;
		}
	}

	public int m_MonstersContribPointer
	{
		[CompilerGenerated]
		get
		{
			return int_25;
		}
		[CompilerGenerated]
		set
		{
			int_25 = value;
		}
	}

	public int m_PlayerWantedPointer
	{
		[CompilerGenerated]
		get
		{
			return int_26;
		}
		[CompilerGenerated]
		set
		{
			int_26 = value;
		}
	}

	public int m_PremItemsPointer
	{
		[CompilerGenerated]
		get
		{
			return int_27;
		}
		[CompilerGenerated]
		set
		{
			int_27 = value;
		}
	}

	public int m_PremTitlesPointer
	{
		[CompilerGenerated]
		get
		{
			return int_28;
		}
		[CompilerGenerated]
		set
		{
			int_28 = value;
		}
	}

	public int m_TaskEventType
	{
		[CompilerGenerated]
		get
		{
			return int_29;
		}
		[CompilerGenerated]
		set
		{
			int_29 = value;
		}
	}

	public int m_TeamMemsWantedPointer
	{
		[CompilerGenerated]
		get
		{
			return int_30;
		}
		[CompilerGenerated]
		set
		{
			int_30 = value;
		}
	}

	public int m_bPremCheckMaxHistoryLevel
	{
		[CompilerGenerated]
		get
		{
			return int_31;
		}
		[CompilerGenerated]
		set
		{
			int_31 = value;
		}
	}

	public int m_chatGroupId
	{
		[CompilerGenerated]
		get
		{
			return int_32;
		}
		[CompilerGenerated]
		set
		{
			int_32 = value;
		}
	}

	public int m_enumFinishType
	{
		[CompilerGenerated]
		get
		{
			return int_33;
		}
		[CompilerGenerated]
		set
		{
			int_33 = value;
		}
	}

	public int m_enumMethod
	{
		[CompilerGenerated]
		get
		{
			return int_34;
		}
		[CompilerGenerated]
		set
		{
			int_34 = value;
		}
	}

	public int m_iAchievementSeriesId
	{
		[CompilerGenerated]
		get
		{
			return int_35;
		}
		[CompilerGenerated]
		set
		{
			int_35 = value;
		}
	}

	public int m_iCamp
	{
		[CompilerGenerated]
		get
		{
			return int_36;
		}
		[CompilerGenerated]
		set
		{
			int_36 = value;
		}
	}

	public int m_iCampPower
	{
		[CompilerGenerated]
		get
		{
			return int_37;
		}
		[CompilerGenerated]
		set
		{
			int_37 = value;
		}
	}

	public int m_iCharEndTime
	{
		[CompilerGenerated]
		get
		{
			return int_38;
		}
		[CompilerGenerated]
		set
		{
			int_38 = value;
		}
	}

	public int m_iCharStartTime
	{
		[CompilerGenerated]
		get
		{
			return int_39;
		}
		[CompilerGenerated]
		set
		{
			int_39 = value;
		}
	}

	public int m_iDeliveredSkillID
	{
		[CompilerGenerated]
		get
		{
			return int_40;
		}
		[CompilerGenerated]
		set
		{
			int_40 = value;
		}
	}

	public int m_iDeliveredSkillLevel
	{
		[CompilerGenerated]
		get
		{
			return int_41;
		}
		[CompilerGenerated]
		set
		{
			int_41 = value;
		}
	}

	public int m_iFactionContribWanted
	{
		[CompilerGenerated]
		get
		{
			return int_42;
		}
		[CompilerGenerated]
		set
		{
			int_42 = value;
		}
	}

	public int m_iFactionExpContribWanted
	{
		[CompilerGenerated]
		get
		{
			return int_43;
		}
		[CompilerGenerated]
		set
		{
			int_43 = value;
		}
	}

	public int m_iFactionMember
	{
		[CompilerGenerated]
		get
		{
			return int_44;
		}
		[CompilerGenerated]
		set
		{
			int_44 = value;
		}
	}

	public int m_iGfxType
	{
		[CompilerGenerated]
		get
		{
			return int_45;
		}
		[CompilerGenerated]
		set
		{
			int_45 = value;
		}
	}

	public int m_iGuessStringID
	{
		[CompilerGenerated]
		get
		{
			return int_46;
		}
		[CompilerGenerated]
		set
		{
			int_46 = value;
		}
	}

	public int m_iHideOtherPlayerTime
	{
		[CompilerGenerated]
		get
		{
			return int_47;
		}
		[CompilerGenerated]
		set
		{
			int_47 = value;
		}
	}

	public int m_iHintConfig
	{
		[CompilerGenerated]
		get
		{
			return int_48;
		}
		[CompilerGenerated]
		set
		{
			int_48 = value;
		}
	}

	public int m_iKeyWordIndex
	{
		[CompilerGenerated]
		get
		{
			return int_49;
		}
		[CompilerGenerated]
		set
		{
			int_49 = value;
		}
	}

	public int m_iMaskDisableIcon
	{
		[CompilerGenerated]
		get
		{
			return int_50;
		}
		[CompilerGenerated]
		set
		{
			int_50 = value;
		}
	}

	public int m_iNeedFriendPoint
	{
		[CompilerGenerated]
		get
		{
			return int_51;
		}
		[CompilerGenerated]
		set
		{
			int_51 = value;
		}
	}

	public int m_iPanguEquipLevel
	{
		[CompilerGenerated]
		get
		{
			return int_52;
		}
		[CompilerGenerated]
		set
		{
			int_52 = value;
		}
	}

	public int m_iPanguEquipQuality
	{
		[CompilerGenerated]
		get
		{
			return int_53;
		}
		[CompilerGenerated]
		set
		{
			int_53 = value;
		}
	}

	public int m_iPanguEquipSlot
	{
		[CompilerGenerated]
		get
		{
			return int_54;
		}
		[CompilerGenerated]
		set
		{
			int_54 = value;
		}
	}

	public int m_iPanguEquipYear
	{
		[CompilerGenerated]
		get
		{
			return int_55;
		}
		[CompilerGenerated]
		set
		{
			int_55 = value;
		}
	}

	public int m_iPremArenaWinCount
	{
		[CompilerGenerated]
		get
		{
			return int_56;
		}
		[CompilerGenerated]
		set
		{
			int_56 = value;
		}
	}

	public int m_iPremCoupleIntimacy
	{
		[CompilerGenerated]
		get
		{
			return int_57;
		}
		[CompilerGenerated]
		set
		{
			int_57 = value;
		}
	}

	public int m_iPremDailyActivityValue
	{
		[CompilerGenerated]
		get
		{
			return int_58;
		}
		[CompilerGenerated]
		set
		{
			int_58 = value;
		}
	}

	public int m_iPremFactionMoney
	{
		[CompilerGenerated]
		get
		{
			return int_59;
		}
		[CompilerGenerated]
		set
		{
			int_59 = value;
		}
	}

	public int m_iPremFactionPersonScore
	{
		[CompilerGenerated]
		get
		{
			return int_60;
		}
		[CompilerGenerated]
		set
		{
			int_60 = value;
		}
	}

	public int m_iPremFactionScore
	{
		[CompilerGenerated]
		get
		{
			return int_61;
		}
		[CompilerGenerated]
		set
		{
			int_61 = value;
		}
	}

	public int m_iPremForce
	{
		[CompilerGenerated]
		get
		{
			return int_62;
		}
		[CompilerGenerated]
		set
		{
			int_62 = value;
		}
	}

	public int m_iPremForceActivityLevel
	{
		[CompilerGenerated]
		get
		{
			return int_63;
		}
		[CompilerGenerated]
		set
		{
			int_63 = value;
		}
	}

	public int m_iPremForceContribution
	{
		[CompilerGenerated]
		get
		{
			return int_64;
		}
		[CompilerGenerated]
		set
		{
			int_64 = value;
		}
	}

	public int m_iPremForceExp
	{
		[CompilerGenerated]
		get
		{
			return int_65;
		}
		[CompilerGenerated]
		set
		{
			int_65 = value;
		}
	}

	public int m_iPremForceReputation
	{
		[CompilerGenerated]
		get
		{
			return int_66;
		}
		[CompilerGenerated]
		set
		{
			int_66 = value;
		}
	}

	public int m_iPremForceSP
	{
		[CompilerGenerated]
		get
		{
			return int_67;
		}
		[CompilerGenerated]
		set
		{
			int_67 = value;
		}
	}

	public int m_iPremGeneralCardRank
	{
		[CompilerGenerated]
		get
		{
			return int_68;
		}
		[CompilerGenerated]
		set
		{
			int_68 = value;
		}
	}

	public int m_iPremHomeFactoryLevelMax
	{
		[CompilerGenerated]
		get
		{
			return int_69;
		}
		[CompilerGenerated]
		set
		{
			int_69 = value;
		}
	}

	public int m_iPremHomeFactoryLevelMin
	{
		[CompilerGenerated]
		get
		{
			return int_70;
		}
		[CompilerGenerated]
		set
		{
			int_70 = value;
		}
	}

	public int m_iPremHomeFactoryLevelType
	{
		[CompilerGenerated]
		get
		{
			return int_71;
		}
		[CompilerGenerated]
		set
		{
			int_71 = value;
		}
	}

	public int m_iPremHomeFlourishMax
	{
		[CompilerGenerated]
		get
		{
			return int_72;
		}
		[CompilerGenerated]
		set
		{
			int_72 = value;
		}
	}

	public int m_iPremHomeFlourishMin
	{
		[CompilerGenerated]
		get
		{
			return int_73;
		}
		[CompilerGenerated]
		set
		{
			int_73 = value;
		}
	}

	public int m_iPremHomeLevelMax
	{
		[CompilerGenerated]
		get
		{
			return int_74;
		}
		[CompilerGenerated]
		set
		{
			int_74 = value;
		}
	}

	public int m_iPremHomeLevelMin
	{
		[CompilerGenerated]
		get
		{
			return int_75;
		}
		[CompilerGenerated]
		set
		{
			int_75 = value;
		}
	}

	public int m_iPremHomeResourceLevelMax
	{
		[CompilerGenerated]
		get
		{
			return int_76;
		}
		[CompilerGenerated]
		set
		{
			int_76 = value;
		}
	}

	public int m_iPremHomeResourceLevelMin
	{
		[CompilerGenerated]
		get
		{
			return int_77;
		}
		[CompilerGenerated]
		set
		{
			int_77 = value;
		}
	}

	public int m_iPremHomeResourceLevelType
	{
		[CompilerGenerated]
		get
		{
			return int_78;
		}
		[CompilerGenerated]
		set
		{
			int_78 = value;
		}
	}

	public int m_iPremLieMoLevelMax
	{
		[CompilerGenerated]
		get
		{
			return int_79;
		}
		[CompilerGenerated]
		set
		{
			int_79 = value;
		}
	}

	public int m_iPremLieMoLevelMin
	{
		[CompilerGenerated]
		get
		{
			return int_80;
		}
		[CompilerGenerated]
		set
		{
			int_80 = value;
		}
	}

	public int m_iPremMentorMorality
	{
		[CompilerGenerated]
		get
		{
			return int_81;
		}
		[CompilerGenerated]
		set
		{
			int_81 = value;
		}
	}

	public int m_iPremMentorStudentValue
	{
		[CompilerGenerated]
		get
		{
			return int_82;
		}
		[CompilerGenerated]
		set
		{
			int_82 = value;
		}
	}

	public int m_iPremNeedRecordTasksNum
	{
		[CompilerGenerated]
		get
		{
			return int_83;
		}
		[CompilerGenerated]
		set
		{
			int_83 = value;
		}
	}

	public int m_iPremTitleNumRequired
	{
		[CompilerGenerated]
		get
		{
			return int_84;
		}
		[CompilerGenerated]
		set
		{
			int_84 = value;
		}
	}

	public int m_iPremTitleNumTotal
	{
		[CompilerGenerated]
		get
		{
			return int_85;
		}
		[CompilerGenerated]
		set
		{
			int_85 = value;
		}
	}

	public int m_iPremYuMoLevelMax
	{
		[CompilerGenerated]
		get
		{
			return int_86;
		}
		[CompilerGenerated]
		set
		{
			int_86 = value;
		}
	}

	public int m_iPremYuMoLevelMin
	{
		[CompilerGenerated]
		get
		{
			return int_87;
		}
		[CompilerGenerated]
		set
		{
			int_87 = value;
		}
	}

	public int m_iPremiseFactionContrib
	{
		[CompilerGenerated]
		get
		{
			return int_88;
		}
		[CompilerGenerated]
		set
		{
			int_88 = value;
		}
	}

	public int m_iPremise_FactionRole
	{
		[CompilerGenerated]
		get
		{
			return int_89;
		}
		[CompilerGenerated]
		set
		{
			int_89 = value;
		}
	}

	public int m_iRankGradeMax
	{
		[CompilerGenerated]
		get
		{
			return int_90;
		}
		[CompilerGenerated]
		set
		{
			int_90 = value;
		}
	}

	public int m_iRankGradeMin
	{
		[CompilerGenerated]
		get
		{
			return int_91;
		}
		[CompilerGenerated]
		set
		{
			int_91 = value;
		}
	}

	public int m_iRankType
	{
		[CompilerGenerated]
		get
		{
			return int_92;
		}
		[CompilerGenerated]
		set
		{
			int_92 = value;
		}
	}

	public int m_iTriggerEvent
	{
		[CompilerGenerated]
		get
		{
			return int_93;
		}
		[CompilerGenerated]
		set
		{
			int_93 = value;
		}
	}

	public int m_iVIPLevelMax
	{
		[CompilerGenerated]
		get
		{
			return int_94;
		}
		[CompilerGenerated]
		set
		{
			int_94 = value;
		}
	}

	public int m_iVIPLevelMin
	{
		[CompilerGenerated]
		get
		{
			return int_95;
		}
		[CompilerGenerated]
		set
		{
			int_95 = value;
		}
	}

	public int m_ulFailIconStateID
	{
		[CompilerGenerated]
		get
		{
			return int_96;
		}
		[CompilerGenerated]
		set
		{
			int_96 = value;
		}
	}

	public int m_iVerifyStateLayer
	{
		[CompilerGenerated]
		get
		{
			return int_97;
		}
		[CompilerGenerated]
		set
		{
			int_97 = value;
		}
	}

	public int m_iWorldContribution
	{
		[CompilerGenerated]
		get
		{
			return int_98;
		}
		[CompilerGenerated]
		set
		{
			int_98 = value;
		}
	}

	public int m_lAvailFrequency
	{
		[CompilerGenerated]
		get
		{
			return int_99;
		}
		[CompilerGenerated]
		set
		{
			int_99 = value;
		}
	}

	public int m_lFrequencyNum
	{
		[CompilerGenerated]
		get
		{
			return int_100;
		}
		[CompilerGenerated]
		set
		{
			int_100 = value;
		}
	}

	public int m_lGlobalKeyForAwardVar
	{
		[CompilerGenerated]
		get
		{
			return int_101;
		}
		[CompilerGenerated]
		set
		{
			int_101 = value;
		}
	}

	public int m_lHistoryKeyForAwardVar
	{
		[CompilerGenerated]
		get
		{
			return int_102;
		}
		[CompilerGenerated]
		set
		{
			int_102 = value;
		}
	}

	public int m_lMonsCtrl
	{
		[CompilerGenerated]
		get
		{
			return int_103;
		}
		[CompilerGenerated]
		set
		{
			int_103 = value;
		}
	}

	public int m_lPeriodLimit
	{
		[CompilerGenerated]
		get
		{
			return int_104;
		}
		[CompilerGenerated]
		set
		{
			int_104 = value;
		}
	}

	public int m_lPersonKeyForAwardVar
	{
		[CompilerGenerated]
		get
		{
			return int_105;
		}
		[CompilerGenerated]
		set
		{
			int_105 = value;
		}
	}

	public int m_lPremise_RepuMax
	{
		[CompilerGenerated]
		get
		{
			return int_106;
		}
		[CompilerGenerated]
		set
		{
			int_106 = value;
		}
	}

	public int m_lPremise_Reputation
	{
		[CompilerGenerated]
		get
		{
			return int_107;
		}
		[CompilerGenerated]
		set
		{
			int_107 = value;
		}
	}

	public int m_nFinExp1AndOrExp2
	{
		[CompilerGenerated]
		get
		{
			return int_108;
		}
		[CompilerGenerated]
		set
		{
			int_108 = value;
		}
	}

	public int m_nFinHistoryExp1AndOrExp2
	{
		[CompilerGenerated]
		get
		{
			return int_109;
		}
		[CompilerGenerated]
		set
		{
			int_109 = value;
		}
	}

	public int m_nFinPersonExp1AndOrExp2
	{
		[CompilerGenerated]
		get
		{
			return int_110;
		}
		[CompilerGenerated]
		set
		{
			int_110 = value;
		}
	}

	public int m_nPremExp1AndOrExp2
	{
		[CompilerGenerated]
		get
		{
			return int_111;
		}
		[CompilerGenerated]
		set
		{
			int_111 = value;
		}
	}

	public int m_nPremHistoryExp1AndOrExp2
	{
		[CompilerGenerated]
		get
		{
			return int_112;
		}
		[CompilerGenerated]
		set
		{
			int_112 = value;
		}
	}

	public int m_nPremPersonExp1AndOrExp2
	{
		[CompilerGenerated]
		get
		{
			return int_113;
		}
		[CompilerGenerated]
		set
		{
			int_113 = value;
		}
	}

	public int m_nPropExp1AndOrExp2
	{
		[CompilerGenerated]
		get
		{
			return int_114;
		}
		[CompilerGenerated]
		set
		{
			int_114 = value;
		}
	}

	public int m_nPropExp1AndOrExp2_personal
	{
		[CompilerGenerated]
		get
		{
			return int_115;
		}
		[CompilerGenerated]
		set
		{
			int_115 = value;
		}
	}

	public int m_pDelvRegionPointer
	{
		[CompilerGenerated]
		get
		{
			return int_116;
		}
		[CompilerGenerated]
		set
		{
			int_116 = value;
		}
	}

	public int m_pEnterRegionPointer
	{
		[CompilerGenerated]
		get
		{
			return int_117;
		}
		[CompilerGenerated]
		set
		{
			int_117 = value;
		}
	}

	public int m_pExpArrPointer
	{
		[CompilerGenerated]
		get
		{
			return int_118;
		}
		[CompilerGenerated]
		set
		{
			int_118 = value;
		}
	}

	public int m_pLeaveRegionPointer
	{
		[CompilerGenerated]
		get
		{
			return int_119;
		}
		[CompilerGenerated]
		set
		{
			int_119 = value;
		}
	}

	public int m_pLeaveSitePointer
	{
		[CompilerGenerated]
		get
		{
			return int_120;
		}
		[CompilerGenerated]
		set
		{
			int_120 = value;
		}
	}

	public int m_pPQExpArrPointer
	{
		[CompilerGenerated]
		get
		{
			return int_121;
		}
		[CompilerGenerated]
		set
		{
			int_121 = value;
		}
	}

	public int m_pReachSitePointer
	{
		[CompilerGenerated]
		get
		{
			return int_122;
		}
		[CompilerGenerated]
		set
		{
			int_122 = value;
		}
	}

	public int m_pTaskCharPointer
	{
		[CompilerGenerated]
		get
		{
			return int_123;
		}
		[CompilerGenerated]
		set
		{
			int_123 = value;
		}
	}

	public int m_pszExpPointer
	{
		[CompilerGenerated]
		get
		{
			return int_124;
		}
		[CompilerGenerated]
		set
		{
			int_124 = value;
		}
	}

	public int m_pszPQExpPointer
	{
		[CompilerGenerated]
		get
		{
			return int_125;
		}
		[CompilerGenerated]
		set
		{
			int_125 = value;
		}
	}

	public int m_pszSignaturePointer
	{
		[CompilerGenerated]
		get
		{
			return int_126;
		}
		[CompilerGenerated]
		set
		{
			int_126 = value;
		}
	}

	public int m_tmEndPointer
	{
		[CompilerGenerated]
		get
		{
			return int_127;
		}
		[CompilerGenerated]
		set
		{
			int_127 = value;
		}
	}

	public int m_tmStartPointer
	{
		[CompilerGenerated]
		get
		{
			return int_128;
		}
		[CompilerGenerated]
		set
		{
			int_128 = value;
		}
	}

	public int m_uiEmotion
	{
		[CompilerGenerated]
		get
		{
			return int_129;
		}
		[CompilerGenerated]
		set
		{
			int_129 = value;
		}
	}

	public int m_ulAccountTaskLimitCnt
	{
		[CompilerGenerated]
		get
		{
			return int_130;
		}
		[CompilerGenerated]
		set
		{
			int_130 = value;
		}
	}

	public int m_ulAwardNPC
	{
		[CompilerGenerated]
		get
		{
			return int_131;
		}
		[CompilerGenerated]
		set
		{
			int_131 = value;
		}
	}

	public int m_ulAwardType_F
	{
		[CompilerGenerated]
		get
		{
			return int_132;
		}
		[CompilerGenerated]
		set
		{
			int_132 = value;
		}
	}

	public int m_ulAwardType_S
	{
		[CompilerGenerated]
		get
		{
			return int_133;
		}
		[CompilerGenerated]
		set
		{
			int_133 = value;
		}
	}

	public int m_ulBindOnCarrierId
	{
		[CompilerGenerated]
		get
		{
			return int_134;
		}
		[CompilerGenerated]
		set
		{
			int_134 = value;
		}
	}

	public int m_ulChangeHistoryKeyCnt
	{
		[CompilerGenerated]
		get
		{
			return int_135;
		}
		[CompilerGenerated]
		set
		{
			int_135 = value;
		}
	}

	public int m_ulChangeKeyCnt
	{
		[CompilerGenerated]
		get
		{
			return int_136;
		}
		[CompilerGenerated]
		set
		{
			int_136 = value;
		}
	}

	public int m_ulChangePersonKeyCnt
	{
		[CompilerGenerated]
		get
		{
			return int_137;
		}
		[CompilerGenerated]
		set
		{
			int_137 = value;
		}
	}

	public int m_ulCharTimeGreaterThan
	{
		[CompilerGenerated]
		get
		{
			return int_138;
		}
		[CompilerGenerated]
		set
		{
			int_138 = value;
		}
	}

	public int m_ulCoTaskCond
	{
		[CompilerGenerated]
		get
		{
			return int_139;
		}
		[CompilerGenerated]
		set
		{
			int_139 = value;
		}
	}

	public int m_ulCrossServerId
	{
		[CompilerGenerated]
		get
		{
			return int_140;
		}
		[CompilerGenerated]
		set
		{
			int_140 = value;
		}
	}

	public int m_ulDelvNPC
	{
		[CompilerGenerated]
		get
		{
			return int_141;
		}
		[CompilerGenerated]
		set
		{
			int_141 = value;
		}
	}

	public int m_ulDelvRegionCnt
	{
		[CompilerGenerated]
		get
		{
			return int_142;
		}
		[CompilerGenerated]
		set
		{
			int_142 = value;
		}
	}

	public int m_ulDelvWorld
	{
		[CompilerGenerated]
		get
		{
			return int_143;
		}
		[CompilerGenerated]
		set
		{
			int_143 = value;
		}
	}

	public int m_ulEnterRegionCnt
	{
		[CompilerGenerated]
		get
		{
			return int_144;
		}
		[CompilerGenerated]
		set
		{
			int_144 = value;
		}
	}

	public int m_ulEnterRegionWorld
	{
		[CompilerGenerated]
		get
		{
			return int_145;
		}
		[CompilerGenerated]
		set
		{
			int_145 = value;
		}
	}

	public int m_ulExpCnt
	{
		[CompilerGenerated]
		get
		{
			return int_146;
		}
		[CompilerGenerated]
		set
		{
			int_146 = value;
		}
	}

	public int m_ulFirstChild
	{
		[CompilerGenerated]
		get
		{
			return int_147;
		}
		[CompilerGenerated]
		set
		{
			int_147 = value;
		}
	}

	public int m_ulGender
	{
		[CompilerGenerated]
		get
		{
			return int_148;
		}
		[CompilerGenerated]
		set
		{
			int_148 = value;
		}
	}

	public int m_ulGivenCmnCount
	{
		[CompilerGenerated]
		get
		{
			return int_149;
		}
		[CompilerGenerated]
		set
		{
			int_149 = value;
		}
	}

	public int m_ulGivenItems
	{
		[CompilerGenerated]
		get
		{
			return int_150;
		}
		[CompilerGenerated]
		set
		{
			int_150 = value;
		}
	}

	public int m_ulGivenTskCount
	{
		[CompilerGenerated]
		get
		{
			return int_151;
		}
		[CompilerGenerated]
		set
		{
			int_151 = value;
		}
	}

	public int m_ulGoldWanted2
	{
		[CompilerGenerated]
		get
		{
			return int_152;
		}
		[CompilerGenerated]
		set
		{
			int_152 = value;
		}
	}

	public int m_ulGoldWanted
	{
		[CompilerGenerated]
		get
		{
			return int_153;
		}
		[CompilerGenerated]
		set
		{
			int_153 = value;
		}
	}

	public int m_ulGrowthTarget
	{
		[CompilerGenerated]
		get
		{
			return int_154;
		}
		[CompilerGenerated]
		set
		{
			int_154 = value;
		}
	}

	public int m_ulHistoryExpCnt
	{
		[CompilerGenerated]
		get
		{
			return int_155;
		}
		[CompilerGenerated]
		set
		{
			int_155 = value;
		}
	}

	public int m_ulHistoryTaskCharCnt
	{
		[CompilerGenerated]
		get
		{
			return int_156;
		}
		[CompilerGenerated]
		set
		{
			int_156 = value;
		}
	}

	public int m_ulHomeItemsWanted
	{
		[CompilerGenerated]
		get
		{
			return int_157;
		}
		[CompilerGenerated]
		set
		{
			int_157 = value;
		}
	}

	public int m_ulIconStateIDForAwardVar
	{
		[CompilerGenerated]
		get
		{
			return int_158;
		}
		[CompilerGenerated]
		set
		{
			int_158 = value;
		}
	}

	public int m_ulInventorySlotNum
	{
		[CompilerGenerated]
		get
		{
			return int_159;
		}
		[CompilerGenerated]
		set
		{
			int_159 = value;
		}
	}

	public int m_ulItemsWanted
	{
		[CompilerGenerated]
		get
		{
			return int_160;
		}
		[CompilerGenerated]
		set
		{
			int_160 = value;
		}
	}

	public int m_ulLeaveRegionCnt
	{
		[CompilerGenerated]
		get
		{
			return int_161;
		}
		[CompilerGenerated]
		set
		{
			int_161 = value;
		}
	}

	public int m_ulLeaveRegionWorld
	{
		[CompilerGenerated]
		get
		{
			return int_162;
		}
		[CompilerGenerated]
		set
		{
			int_162 = value;
		}
	}

	public int m_ulLeaveSiteCnt
	{
		[CompilerGenerated]
		get
		{
			return int_163;
		}
		[CompilerGenerated]
		set
		{
			int_163 = value;
		}
	}

	public int m_ulLeaveSiteId
	{
		[CompilerGenerated]
		get
		{
			return int_164;
		}
		[CompilerGenerated]
		set
		{
			int_164 = value;
		}
	}

	public int m_ulMaxReceiver
	{
		[CompilerGenerated]
		get
		{
			return int_165;
		}
		[CompilerGenerated]
		set
		{
			int_165 = value;
		}
	}

	public int m_ulMonsterContribCnt
	{
		[CompilerGenerated]
		get
		{
			return int_166;
		}
		[CompilerGenerated]
		set
		{
			int_166 = value;
		}
	}

	public int m_ulMonsterWanted
	{
		[CompilerGenerated]
		get
		{
			return int_167;
		}
		[CompilerGenerated]
		set
		{
			int_167 = value;
		}
	}

	public int m_ulMutexTaskCount
	{
		[CompilerGenerated]
		get
		{
			return int_168;
		}
		[CompilerGenerated]
		set
		{
			int_168 = value;
		}
	}

	public int m_ulNPCDestSite
	{
		[CompilerGenerated]
		get
		{
			return int_169;
		}
		[CompilerGenerated]
		set
		{
			int_169 = value;
		}
	}

	public int m_ulNPCMoving
	{
		[CompilerGenerated]
		get
		{
			return int_170;
		}
		[CompilerGenerated]
		set
		{
			int_170 = value;
		}
	}

	public int m_ulNPCToProtect
	{
		[CompilerGenerated]
		get
		{
			return int_171;
		}
		[CompilerGenerated]
		set
		{
			int_171 = value;
		}
	}

	public int m_ulNeededTaskCount
	{
		[CompilerGenerated]
		get
		{
			return int_172;
		}
		[CompilerGenerated]
		set
		{
			int_172 = value;
		}
	}

	public int m_ulNextSibling
	{
		[CompilerGenerated]
		get
		{
			return int_173;
		}
		[CompilerGenerated]
		set
		{
			int_173 = value;
		}
	}

	public int m_ulOccupations
	{
		[CompilerGenerated]
		get
		{
			return int_174;
		}
		[CompilerGenerated]
		set
		{
			int_174 = value;
		}
	}

	public int m_ulPQExpCnt
	{
		[CompilerGenerated]
		get
		{
			return int_175;
		}
		[CompilerGenerated]
		set
		{
			int_175 = value;
		}
	}

	public int m_ulParent
	{
		[CompilerGenerated]
		get
		{
			return int_176;
		}
		[CompilerGenerated]
		set
		{
			int_176 = value;
		}
	}

	public int m_ulPersonExpCnt
	{
		[CompilerGenerated]
		get
		{
			return int_177;
		}
		[CompilerGenerated]
		set
		{
			int_177 = value;
		}
	}

	public int m_ulPersonTaskCharCnt
	{
		[CompilerGenerated]
		get
		{
			return int_178;
		}
		[CompilerGenerated]
		set
		{
			int_178 = value;
		}
	}

	public int m_ulPlayerWanted
	{
		[CompilerGenerated]
		get
		{
			return int_179;
		}
		[CompilerGenerated]
		set
		{
			int_179 = value;
		}
	}

	public int m_ulPremDeposit2
	{
		[CompilerGenerated]
		get
		{
			return int_180;
		}
		[CompilerGenerated]
		set
		{
			int_180 = value;
		}
	}

	public int m_ulPremGeneralCardCount
	{
		[CompilerGenerated]
		get
		{
			return int_181;
		}
		[CompilerGenerated]
		set
		{
			int_181 = value;
		}
	}

	public int m_ulPremGeneralCardRankCount
	{
		[CompilerGenerated]
		get
		{
			return int_182;
		}
		[CompilerGenerated]
		set
		{
			int_182 = value;
		}
	}

	public int m_ulPremIconStateID
	{
		[CompilerGenerated]
		get
		{
			return int_183;
		}
		[CompilerGenerated]
		set
		{
			int_183 = value;
		}
	}

	public int m_ulPremItems
	{
		[CompilerGenerated]
		get
		{
			return int_184;
		}
		[CompilerGenerated]
		set
		{
			int_184 = value;
		}
	}

	public int m_ulPremRMBMax
	{
		[CompilerGenerated]
		get
		{
			return int_185;
		}
		[CompilerGenerated]
		set
		{
			int_185 = value;
		}
	}

	public int m_ulPremRMBMin
	{
		[CompilerGenerated]
		get
		{
			return int_186;
		}
		[CompilerGenerated]
		set
		{
			int_186 = value;
		}
	}

	public int m_ulPremRealmLevelMax
	{
		[CompilerGenerated]
		get
		{
			return int_187;
		}
		[CompilerGenerated]
		set
		{
			int_187 = value;
		}
	}

	public int m_ulPremRealmLevelMin
	{
		[CompilerGenerated]
		get
		{
			return int_188;
		}
		[CompilerGenerated]
		set
		{
			int_188 = value;
		}
	}

	public int m_ulPremReincarnationMax
	{
		[CompilerGenerated]
		get
		{
			return int_189;
		}
		[CompilerGenerated]
		set
		{
			int_189 = value;
		}
	}

	public int m_ulPremReincarnationMin
	{
		[CompilerGenerated]
		get
		{
			return int_190;
		}
		[CompilerGenerated]
		set
		{
			int_190 = value;
		}
	}

	public int m_ulPremise_Cotask
	{
		[CompilerGenerated]
		get
		{
			return int_191;
		}
		[CompilerGenerated]
		set
		{
			int_191 = value;
		}
	}

	public int m_ulPremise_Deposit
	{
		[CompilerGenerated]
		get
		{
			return int_192;
		}
		[CompilerGenerated]
		set
		{
			int_192 = value;
		}
	}

	public int m_ulPremise_Faction
	{
		[CompilerGenerated]
		get
		{
			return int_193;
		}
		[CompilerGenerated]
		set
		{
			int_193 = value;
		}
	}

	public int m_ulPremise_Lev_Max
	{
		[CompilerGenerated]
		get
		{
			return int_194;
		}
		[CompilerGenerated]
		set
		{
			int_194 = value;
		}
	}

	public int m_ulPremise_Lev_Min
	{
		[CompilerGenerated]
		get
		{
			return int_195;
		}
		[CompilerGenerated]
		set
		{
			int_195 = value;
		}
	}

	public int m_ulPremise_Period
	{
		[CompilerGenerated]
		get
		{
			return int_196;
		}
		[CompilerGenerated]
		set
		{
			int_196 = value;
		}
	}

	public int m_ulPremise_Task_Count
	{
		[CompilerGenerated]
		get
		{
			return int_197;
		}
		[CompilerGenerated]
		set
		{
			int_197 = value;
		}
	}

	public int m_ulPremise_Task_Least_Num
	{
		[CompilerGenerated]
		get
		{
			return int_198;
		}
		[CompilerGenerated]
		set
		{
			int_198 = value;
		}
	}

	public int m_ulPrevSibling
	{
		[CompilerGenerated]
		get
		{
			return int_199;
		}
		[CompilerGenerated]
		set
		{
			int_199 = value;
		}
	}

	public int m_ulPropSummonedMonsters
	{
		[CompilerGenerated]
		get
		{
			return int_200;
		}
		[CompilerGenerated]
		set
		{
			int_200 = value;
		}
	}

	public int m_ulProtectTimeLen
	{
		[CompilerGenerated]
		get
		{
			return int_201;
		}
		[CompilerGenerated]
		set
		{
			int_201 = value;
		}
	}

	public int m_ulReachLevel
	{
		[CompilerGenerated]
		get
		{
			return int_202;
		}
		[CompilerGenerated]
		set
		{
			int_202 = value;
		}
	}

	public int m_ulReachRealmLevel
	{
		[CompilerGenerated]
		get
		{
			return int_203;
		}
		[CompilerGenerated]
		set
		{
			int_203 = value;
		}
	}

	public int m_ulReachReincarnationCount
	{
		[CompilerGenerated]
		get
		{
			return int_204;
		}
		[CompilerGenerated]
		set
		{
			int_204 = value;
		}
	}

	public int m_ulReachSiteCnt
	{
		[CompilerGenerated]
		get
		{
			return int_205;
		}
		[CompilerGenerated]
		set
		{
			int_205 = value;
		}
	}

	public int m_ulReachSiteId
	{
		[CompilerGenerated]
		get
		{
			return int_206;
		}
		[CompilerGenerated]
		set
		{
			int_206 = value;
		}
	}

	public int m_ulSpecialAward
	{
		[CompilerGenerated]
		get
		{
			return int_207;
		}
		[CompilerGenerated]
		set
		{
			int_207 = value;
		}
	}

	public int m_ulSuitableLevel
	{
		[CompilerGenerated]
		get
		{
			return int_208;
		}
		[CompilerGenerated]
		set
		{
			int_208 = value;
		}
	}

	public int m_ulTMHomeLevelType
	{
		[CompilerGenerated]
		get
		{
			return int_209;
		}
		[CompilerGenerated]
		set
		{
			int_209 = value;
		}
	}

	public int m_ulTMIconStateID
	{
		[CompilerGenerated]
		get
		{
			return int_210;
		}
		[CompilerGenerated]
		set
		{
			int_210 = value;
		}
	}

	public int m_ulTMReachArenaCount
	{
		[CompilerGenerated]
		get
		{
			return int_211;
		}
		[CompilerGenerated]
		set
		{
			int_211 = value;
		}
	}

	public int m_ulTMReachArenaWinCount
	{
		[CompilerGenerated]
		get
		{
			return int_212;
		}
		[CompilerGenerated]
		set
		{
			int_212 = value;
		}
	}

	public int m_ulTMReachHomeFlourish
	{
		[CompilerGenerated]
		get
		{
			return int_213;
		}
		[CompilerGenerated]
		set
		{
			int_213 = value;
		}
	}

	public int m_ulTMReachHomeLevel
	{
		[CompilerGenerated]
		get
		{
			return int_214;
		}
		[CompilerGenerated]
		set
		{
			int_214 = value;
		}
	}

	public int m_ulTaskCharCnt
	{
		[CompilerGenerated]
		get
		{
			return int_215;
		}
		[CompilerGenerated]
		set
		{
			int_215 = value;
		}
	}

	public int m_ulTeamMemsWanted
	{
		[CompilerGenerated]
		get
		{
			return int_216;
		}
		[CompilerGenerated]
		set
		{
			int_216 = value;
		}
	}

	public int m_ulTimeLimit
	{
		[CompilerGenerated]
		get
		{
			return int_217;
		}
		[CompilerGenerated]
		set
		{
			int_217 = value;
		}
	}

	public int m_ulTimetable
	{
		[CompilerGenerated]
		get
		{
			return int_218;
		}
		[CompilerGenerated]
		set
		{
			int_218 = value;
		}
	}

	public int m_ulTransWldId
	{
		[CompilerGenerated]
		get
		{
			return int_219;
		}
		[CompilerGenerated]
		set
		{
			int_219 = value;
		}
	}

	public int m_ulType
	{
		[CompilerGenerated]
		get
		{
			return int_220;
		}
		[CompilerGenerated]
		set
		{
			int_220 = value;
		}
	}

	public int m_ulVerifyStateLayerID
	{
		[CompilerGenerated]
		get
		{
			return int_221;
		}
		[CompilerGenerated]
		set
		{
			int_221 = value;
		}
	}

	public int m_ulWaitTime
	{
		[CompilerGenerated]
		get
		{
			return int_222;
		}
		[CompilerGenerated]
		set
		{
			int_222 = value;
		}
	}

	public int x_SpecialParametersCount
	{
		[CompilerGenerated]
		get
		{
			return int_223;
		}
		[CompilerGenerated]
		set
		{
			int_223 = value;
		}
	}

	public int[] m_Occupations
	{
		[CompilerGenerated]
		get
		{
			return int_224;
		}
		[CompilerGenerated]
		set
		{
			int_224 = value;
		}
	}

	public int[] m_PremTitles
	{
		[CompilerGenerated]
		get
		{
			return int_225;
		}
		[CompilerGenerated]
		set
		{
			int_225 = value;
		}
	}

	public int[] m_iPremHistoryStageIndex
	{
		[CompilerGenerated]
		get
		{
			return int_226;
		}
		[CompilerGenerated]
		set
		{
			int_226 = value;
		}
	}

	public int[] m_lSkillLev
	{
		[CompilerGenerated]
		get
		{
			return int_227;
		}
		[CompilerGenerated]
		set
		{
			int_227 = value;
		}
	}

	public int[] m_plChangeKey
	{
		[CompilerGenerated]
		get
		{
			return int_228;
		}
		[CompilerGenerated]
		set
		{
			int_228 = value;
		}
	}

	public int[] m_plChangeKeyValue2
	{
		[CompilerGenerated]
		get
		{
			return int_229;
		}
		[CompilerGenerated]
		set
		{
			int_229 = value;
		}
	}

	public int[] m_plChangeKeyValue
	{
		[CompilerGenerated]
		get
		{
			return int_230;
		}
		[CompilerGenerated]
		set
		{
			int_230 = value;
		}
	}

	public int[] m_plHistoryChangeKey
	{
		[CompilerGenerated]
		get
		{
			return int_231;
		}
		[CompilerGenerated]
		set
		{
			int_231 = value;
		}
	}

	public int[] m_plHistoryChangeKeyValue2
	{
		[CompilerGenerated]
		get
		{
			return int_232;
		}
		[CompilerGenerated]
		set
		{
			int_232 = value;
		}
	}

	public int[] m_plHistoryChangeKeyValue
	{
		[CompilerGenerated]
		get
		{
			return int_233;
		}
		[CompilerGenerated]
		set
		{
			int_233 = value;
		}
	}

	public int[] m_plPersonChangeKey
	{
		[CompilerGenerated]
		get
		{
			return int_234;
		}
		[CompilerGenerated]
		set
		{
			int_234 = value;
		}
	}

	public int[] m_plPersonChangeKeyValue2
	{
		[CompilerGenerated]
		get
		{
			return int_235;
		}
		[CompilerGenerated]
		set
		{
			int_235 = value;
		}
	}

	public int[] m_plPersonChangeKeyValue
	{
		[CompilerGenerated]
		get
		{
			return int_236;
		}
		[CompilerGenerated]
		set
		{
			int_236 = value;
		}
	}

	public int[] m_ulMutexTasks
	{
		[CompilerGenerated]
		get
		{
			return int_237;
		}
		[CompilerGenerated]
		set
		{
			int_237 = value;
		}
	}

	public int[] m_ulNeededTasks
	{
		[CompilerGenerated]
		get
		{
			return int_238;
		}
		[CompilerGenerated]
		set
		{
			int_238 = value;
		}
	}

	public int[] m_ulPremise_Tasks
	{
		[CompilerGenerated]
		get
		{
			return int_239;
		}
		[CompilerGenerated]
		set
		{
			int_239 = value;
		}
	}

	public short m_FactionPersonScore
	{
		[CompilerGenerated]
		get
		{
			return short_0;
		}
		[CompilerGenerated]
		set
		{
			short_0 = value;
		}
	}

	public short m_usIDSpace
	{
		[CompilerGenerated]
		get
		{
			return short_1;
		}
		[CompilerGenerated]
		set
		{
			short_1 = value;
		}
	}

	public short m_usPremise_Cotask_Space
	{
		[CompilerGenerated]
		get
		{
			return short_2;
		}
		[CompilerGenerated]
		set
		{
			short_2 = value;
		}
	}

	public short m_usTaskEventMineCount
	{
		[CompilerGenerated]
		get
		{
			return short_3;
		}
		[CompilerGenerated]
		set
		{
			short_3 = value;
		}
	}

	public short m_usTaskEventMonsterCount
	{
		[CompilerGenerated]
		get
		{
			return short_4;
		}
		[CompilerGenerated]
		set
		{
			short_4 = value;
		}
	}

	public short m_usTaskEventTaskCount
	{
		[CompilerGenerated]
		get
		{
			return short_5;
		}
		[CompilerGenerated]
		set
		{
			short_5 = value;
		}
	}

	public short m_usTaskEventTimeOrScore
	{
		[CompilerGenerated]
		get
		{
			return short_6;
		}
		[CompilerGenerated]
		set
		{
			short_6 = value;
		}
	}

	public short m_usZoneMapID
	{
		[CompilerGenerated]
		get
		{
			return short_7;
		}
		[CompilerGenerated]
		set
		{
			short_7 = value;
		}
	}

	public short[] m_TaskEventName
	{
		[CompilerGenerated]
		get
		{
			return short_8;
		}
		[CompilerGenerated]
		set
		{
			short_8 = value;
		}
	}

	public short[] m_szShowDialogName
	{
		[CompilerGenerated]
		get
		{
			return short_9;
		}
		[CompilerGenerated]
		set
		{
			short_9 = value;
		}
	}

	public short[] m_usMutexTasksSpace
	{
		[CompilerGenerated]
		get
		{
			return short_10;
		}
		[CompilerGenerated]
		set
		{
			short_10 = value;
		}
	}

	public short[] m_usNeededTasksSpace
	{
		[CompilerGenerated]
		get
		{
			return short_11;
		}
		[CompilerGenerated]
		set
		{
			short_11 = value;
		}
	}

	public short[] m_usPremise_Tasks_Space
	{
		[CompilerGenerated]
		get
		{
			return short_12;
		}
		[CompilerGenerated]
		set
		{
			short_12 = value;
		}
	}

	public short[][] HistoryTaskChar
	{
		[CompilerGenerated]
		get
		{
			return short_13;
		}
		[CompilerGenerated]
		set
		{
			short_13 = value;
		}
	}

	public short[][] PersonTaskChar
	{
		[CompilerGenerated]
		get
		{
			return short_14;
		}
		[CompilerGenerated]
		set
		{
			short_14 = value;
		}
	}

	public short[][] m_pTaskChar
	{
		[CompilerGenerated]
		get
		{
			return short_15;
		}
		[CompilerGenerated]
		set
		{
			short_15 = value;
		}
	}

	public task_tm m_tmAbsFailTime
	{
		[CompilerGenerated]
		get
		{
			return task_tm_0;
		}
		[CompilerGenerated]
		set
		{
			task_tm_0 = value;
		}
	}

	public task_tm m_tmAvailFrequency
	{
		[CompilerGenerated]
		get
		{
			return task_tm_1;
		}
		[CompilerGenerated]
		set
		{
			task_tm_1 = value;
		}
	}

	public task_tm m_tmCharEndTime
	{
		[CompilerGenerated]
		get
		{
			return task_tm_2;
		}
		[CompilerGenerated]
		set
		{
			task_tm_2 = value;
		}
	}

	public task_tm m_tmNextFailTime
	{
		[CompilerGenerated]
		get
		{
			return task_tm_3;
		}
		[CompilerGenerated]
		set
		{
			task_tm_3 = value;
		}
	}

	public task_tm[] m_tmEnd
	{
		[CompilerGenerated]
		get
		{
			return task_tm_4;
		}
		[CompilerGenerated]
		set
		{
			task_tm_4 = value;
		}
	}

	public task_tm[] m_tmStart
	{
		[CompilerGenerated]
		get
		{
			return task_tm_5;
		}
		[CompilerGenerated]
		set
		{
			task_tm_5 = value;
		}
	}

	public uint m_uSpecialMethodNpcServicesCount
	{
		[CompilerGenerated]
		get
		{
			return uint_0;
		}
		[CompilerGenerated]
		set
		{
			uint_0 = value;
		}
	}

	public uint m_uSpecialMethodNpcServicesLeastLeastCount
	{
		[CompilerGenerated]
		get
		{
			return uint_1;
		}
		[CompilerGenerated]
		set
		{
			uint_1 = value;
		}
	}

	public uint m_uSpecialMethodParm1
	{
		[CompilerGenerated]
		get
		{
			return uint_2;
		}
		[CompilerGenerated]
		set
		{
			uint_2 = value;
		}
	}

	public uint m_uSpecialMethodParm2
	{
		[CompilerGenerated]
		get
		{
			return uint_3;
		}
		[CompilerGenerated]
		set
		{
			uint_3 = value;
		}
	}

	public uint m_uSpecialMethodParm3
	{
		[CompilerGenerated]
		get
		{
			return uint_4;
		}
		[CompilerGenerated]
		set
		{
			uint_4 = value;
		}
	}

	public uint m_uSpecialMethodTargetTaskCount
	{
		[CompilerGenerated]
		get
		{
			return uint_5;
		}
		[CompilerGenerated]
		set
		{
			uint_5 = value;
		}
	}

	public uint m_uSpecialMethodTargetTaskLeastCount
	{
		[CompilerGenerated]
		get
		{
			return uint_6;
		}
		[CompilerGenerated]
		set
		{
			uint_6 = value;
		}
	}

	public uint m_uSpecialMethodType
	{
		[CompilerGenerated]
		get
		{
			return uint_7;
		}
		[CompilerGenerated]
		set
		{
			uint_7 = value;
		}
	}

	public uint m_ulChangeSceneRemoveItemRegionNum
	{
		[CompilerGenerated]
		get
		{
			return uint_8;
		}
		[CompilerGenerated]
		set
		{
			uint_8 = value;
		}
	}

	public uint m_ulChangeSceneRemoveNum
	{
		[CompilerGenerated]
		get
		{
			return uint_9;
		}
		[CompilerGenerated]
		set
		{
			uint_9 = value;
		}
	}

	public uint m_ulDailyActivityValue
	{
		[CompilerGenerated]
		get
		{
			return uint_10;
		}
		[CompilerGenerated]
		set
		{
			uint_10 = value;
		}
	}

	public uint m_ulGivenDongluCmnCount
	{
		[CompilerGenerated]
		get
		{
			return uint_11;
		}
		[CompilerGenerated]
		set
		{
			uint_11 = value;
		}
	}

	public uint m_ulGivenRelicCount
	{
		[CompilerGenerated]
		get
		{
			return uint_12;
		}
		[CompilerGenerated]
		set
		{
			uint_12 = value;
		}
	}

	public uint m_ulMonsterShapeID
	{
		[CompilerGenerated]
		get
		{
			return uint_13;
		}
		[CompilerGenerated]
		set
		{
			uint_13 = value;
		}
	}

	public uint m_ulMonsterUnwanted
	{
		[CompilerGenerated]
		get
		{
			return uint_14;
		}
		[CompilerGenerated]
		set
		{
			uint_14 = value;
		}
	}

	public uint m_ulPremPanguLevelMax
	{
		[CompilerGenerated]
		get
		{
			return uint_15;
		}
		[CompilerGenerated]
		set
		{
			uint_15 = value;
		}
	}

	public uint m_ulPremPanguLevelMin
	{
		[CompilerGenerated]
		get
		{
			return uint_16;
		}
		[CompilerGenerated]
		set
		{
			uint_16 = value;
		}
	}

	public uint m_ulPremPanguLevelYear
	{
		[CompilerGenerated]
		get
		{
			return uint_17;
		}
		[CompilerGenerated]
		set
		{
			uint_17 = value;
		}
	}

	public uint m_ulSubmitItemWantedNum
	{
		[CompilerGenerated]
		get
		{
			return uint_18;
		}
		[CompilerGenerated]
		set
		{
			uint_18 = value;
		}
	}

	public uint m_ulTransmitPointID
	{
		[CompilerGenerated]
		get
		{
			return uint_19;
		}
		[CompilerGenerated]
		set
		{
			uint_19 = value;
		}
	}

	public uint m_ulVaguePromptNumbers
	{
		[CompilerGenerated]
		get
		{
			return uint_20;
		}
		[CompilerGenerated]
		set
		{
			uint_20 = value;
		}
	}

	public int m_plChangeKeyPointer
	{
		[CompilerGenerated]
		get
		{
			return int_240;
		}
		[CompilerGenerated]
		set
		{
			int_240 = value;
		}
	}

	public int m_plChangeKeyValuePointer
	{
		[CompilerGenerated]
		get
		{
			return int_241;
		}
		[CompilerGenerated]
		set
		{
			int_241 = value;
		}
	}

	public int m_pbChangeTypePointer
	{
		[CompilerGenerated]
		get
		{
			return int_242;
		}
		[CompilerGenerated]
		set
		{
			int_242 = value;
		}
	}

	public string Name
	{
		get
		{
			return tasksConvert.decrypt(m_ID, m_szName);
		}
		set
		{
			m_szName = tasksConvert.encrypt(m_ID, value, 30, appendZero: false);
		}
	}

	public string Signature
	{
		get
		{
			return tasksConvert.decrypt(m_ID, m_pszSignature);
		}
		set
		{
			m_pszSignature = tasksConvert.encrypt(m_ID, value, 30, appendZero: false);
		}
	}

	public void logic_read_task_data_struct(int version, BinaryReader br)
	{
		List<Action<int, BinaryReader>> list = new List<Action<int, BinaryReader>>
		{
			method_0, method_1, method_2, method_3, method_4, method_5, method_6, method_7, method_8, method_9,
			method_10, method_11, method_12, method_13, method_14, method_15, method_16, method_17, method_18, method_19,
			method_20, method_21, method_22, method_23, method_24, method_25, method_26, method_27, method_28, method_29,
			method_30, method_31, method_32, method_33, method_34, method_35, method_36, method_37, method_38, method_39,
			method_57, method_40, method_41, method_42, method_44, method_45, method_46, method_47, method_48, method_49,
			method_50, method_51, method_52, method_53, method_54, method_55, method_56, method_58
		};
		foreach (Action<int, BinaryReader> item in list)
		{
			item(version, br);
		}
	}

	private void method_0(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 153)
		{
			m_usIDSpace = binaryReader_0.ReadInt16();
		}
		m_ID = binaryReader_0.ReadInt32();
		m_szName = GlobalFunctions.ReadNameChars(30, binaryReader_0);
		if (int_243 < 135)
		{
			m_bHasSign = binaryReader_0.ReadBoolean();
		}
		if (int_243 < 176)
		{
			m_pszSignaturePointer = binaryReader_0.ReadInt32();
		}
		m_ulType = binaryReader_0.ReadInt32();
		m_ulTimeLimit = binaryReader_0.ReadInt32();
	}

	private void method_1(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 68)
		{
			if (int_243 < 135)
			{
				m_bOfflineFail = binaryReader_0.ReadBoolean();
			}
			m_bAbsFail = binaryReader_0.ReadBoolean();
			task_tm.Read(int_243, binaryReader_0, m_tmAbsFailTime);
			if (int_243 >= 175)
			{
				m_bNextTimeFail = binaryReader_0.ReadBoolean();
				task_tm.Read(int_243, binaryReader_0, m_tmNextFailTime);
			}
			if (int_243 < 135)
			{
				m_bItemNotTakeOff = binaryReader_0.ReadBoolean();
			}
		}
		if (int_243 >= 52 && int_243 < 135)
		{
			m_bAbsTime = binaryReader_0.ReadBoolean();
		}
		m_ulTimetable = binaryReader_0.ReadInt32();
		if (int_243 >= 52)
		{
			int maxTimetableSize = GlobalFunctions.GetMaxTimetableSize(int_243);
			for (int i = 0; i < maxTimetableSize; i++)
			{
				m_tmType[i] = binaryReader_0.ReadByte();
			}
		}
		if (int_243 < 176)
		{
			m_tmStartPointer = binaryReader_0.ReadInt32();
			m_tmEndPointer = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 52)
		{
			m_lAvailFrequency = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 191)
		{
			m_lFrequencyNum = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 85)
		{
			m_lPeriodLimit = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 175)
		{
			m_bAvailFrequency = binaryReader_0.ReadBoolean();
			task_tm.Read(int_243, binaryReader_0, m_tmAvailFrequency);
		}
	}

	private void method_2(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 < 135)
		{
			m_bChooseOne = binaryReader_0.ReadBoolean();
			m_bRandOne = binaryReader_0.ReadBoolean();
			m_bExeChildInOrder = binaryReader_0.ReadBoolean();
			m_bParentAlsoFail = binaryReader_0.ReadBoolean();
			m_bParentAlsoSucc = binaryReader_0.ReadBoolean();
			m_bCanGiveUp = binaryReader_0.ReadBoolean();
			m_bCanRedo = binaryReader_0.ReadBoolean();
			m_bCanRedoAfterFailure = binaryReader_0.ReadBoolean();
			m_bClearAsGiveUp = binaryReader_0.ReadBoolean();
			m_bNeedRecord = binaryReader_0.ReadBoolean();
			m_bFailAsPlayerDie = binaryReader_0.ReadBoolean();
		}
		m_ulMaxReceiver = binaryReader_0.ReadInt32();
		if (int_243 < 135)
		{
			m_bDelvInZone = binaryReader_0.ReadBoolean();
		}
		m_ulDelvWorld = binaryReader_0.ReadInt32();
	}

	private void method_3(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 80)
		{
			m_ulDelvRegionCnt = binaryReader_0.ReadInt32();
			if (int_243 < 176)
			{
				m_pDelvRegionPointer = binaryReader_0.ReadInt32();
			}
		}
		else
		{
			m_ulDelvRegionCnt = 1;
			m_pDelvRegion = new Task_Region[m_ulDelvRegionCnt];
			m_pDelvRegion[0] = new Task_Region();
			Task_Region.Read(int_243, binaryReader_0, m_pDelvRegion[0]);
			m_pDelvRegion[0].MapID = m_ulDelvWorld;
		}
	}

	private void method_4(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 68)
		{
			if (int_243 < 135)
			{
				m_bEnterRegionFail = binaryReader_0.ReadBoolean();
			}
			m_ulEnterRegionWorld = binaryReader_0.ReadInt32();
			if (int_243 >= 80)
			{
				m_ulEnterRegionCnt = binaryReader_0.ReadInt32();
				if (int_243 < 176)
				{
					m_pEnterRegionPointer = binaryReader_0.ReadInt32();
				}
			}
			else
			{
				m_ulEnterRegionCnt = 1;
				m_pEnterRegion = new Task_Region[m_ulEnterRegionCnt];
				m_pEnterRegion[0] = new Task_Region();
				Task_Region.Read(int_243, binaryReader_0, m_pEnterRegion[0]);
				m_pEnterRegion[0].MapID = m_ulEnterRegionWorld;
			}
		}
		else
		{
			m_pEnterRegion = new Task_Region[0];
		}
	}

	private void method_5(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 68)
		{
			if (int_243 < 135)
			{
				m_bLeaveRegionFail = binaryReader_0.ReadBoolean();
			}
			m_ulLeaveRegionWorld = binaryReader_0.ReadInt32();
			if (int_243 >= 80)
			{
				m_ulLeaveRegionCnt = binaryReader_0.ReadInt32();
				if (int_243 < 176)
				{
					m_pLeaveRegionPointer = binaryReader_0.ReadInt32();
				}
			}
			else
			{
				m_ulLeaveRegionCnt = 1;
				m_pLeaveRegion = new Task_Region[m_ulLeaveRegionCnt];
				m_pLeaveRegion[0] = new Task_Region();
				Task_Region.Read(int_243, binaryReader_0, m_pLeaveRegion[0]);
				m_pLeaveRegion[0].MapID = m_ulLeaveRegionWorld;
			}
		}
		else
		{
			m_pLeaveRegion = new Task_Region[0];
		}
	}

	private void method_6(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 97 && int_243 < 135)
		{
			m_bLeaveForceFail = binaryReader_0.ReadBoolean();
		}
		if (int_243 < 135)
		{
			m_bTransTo = binaryReader_0.ReadBoolean();
		}
		m_ulTransWldId = binaryReader_0.ReadInt32();
		ZONE_VERT.Read(int_243, binaryReader_0, m_TransPt);
		if (int_243 >= 52)
		{
			m_lMonsCtrl = binaryReader_0.ReadInt32();
			if (int_243 < 135)
			{
				m_bTrigCtrl = binaryReader_0.ReadBoolean();
			}
		}
	}

	private void method_7(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 < 135)
		{
			m_bAutoDeliver = binaryReader_0.ReadBoolean();
			if (int_243 >= 84)
			{
				m_bDisplayInExclusiveUI = binaryReader_0.ReadBoolean();
			}
			if (int_243 >= 89)
			{
				m_bReadyToNotifyServer = binaryReader_0.ReadBoolean();
			}
			if (int_243 >= 116)
			{
				m_bUsedInTokenShop = binaryReader_0.ReadBoolean();
			}
			m_bDeathTrig = binaryReader_0.ReadBoolean();
			m_bClearAcquired = binaryReader_0.ReadBoolean();
		}
		m_ulSuitableLevel = binaryReader_0.ReadInt32();
		if (int_243 < 135)
		{
			m_bShowPrompt = binaryReader_0.ReadBoolean();
			m_bKeyTask = binaryReader_0.ReadBoolean();
		}
		m_ulDelvNPC = binaryReader_0.ReadInt32();
		m_ulAwardNPC = binaryReader_0.ReadInt32();
	}

	private void method_8(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 < 135)
		{
			m_bSkillTask = binaryReader_0.ReadBoolean();
			if (int_243 >= 52)
			{
				m_bCanSeekOut = binaryReader_0.ReadBoolean();
				m_bShowDirection = binaryReader_0.ReadBoolean();
			}
			if (int_243 >= 55)
			{
				m_bMarriage = binaryReader_0.ReadBoolean();
			}
		}
	}

	private void method_9(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 59)
		{
			m_ulChangeKeyCnt = binaryReader_0.ReadInt32();
			if (int_243 < 176)
			{
				m_plChangeKeyPointer = binaryReader_0.ReadInt32();
				m_plChangeKeyValuePointer = binaryReader_0.ReadInt32();
				m_pbChangeTypePointer = binaryReader_0.ReadInt32();
			}
		}
		if (int_243 >= 178)
		{
			m_ulChangePersonKeyCnt = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 185)
		{
			m_ulChangeHistoryKeyCnt = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 63 && int_243 < 135)
		{
			m_bSwitchSceneFail = binaryReader_0.ReadBoolean();
			m_bHidden = binaryReader_0.ReadBoolean();
		}
		if (int_243 >= 78)
		{
			if (int_243 < 135)
			{
				m_bDeliverySkill = binaryReader_0.ReadBoolean();
			}
			m_iDeliveredSkillID = binaryReader_0.ReadInt32();
			m_iDeliveredSkillLevel = binaryReader_0.ReadInt32();
			if (int_243 < 135)
			{
				m_bShowGfxFinished = binaryReader_0.ReadBoolean();
			}
		}
		if (int_243 >= 79 && int_243 < 135)
		{
			m_bChangePQRanking = binaryReader_0.ReadBoolean();
		}
		if (int_243 >= 81)
		{
			if (int_243 < 135)
			{
				m_bCompareItemAndInventory = binaryReader_0.ReadBoolean();
			}
			m_ulInventorySlotNum = binaryReader_0.ReadInt32();
		}
	}

	private void method_10(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 < 135)
		{
			if (int_243 >= 123)
			{
				m_bTowerTask = binaryReader_0.ReadBoolean();
			}
			if (int_243 >= 126)
			{
				m_bHomeTask = binaryReader_0.ReadBoolean();
			}
			if (int_243 >= 128)
			{
				m_bDeliverInHostHome = binaryReader_0.ReadBoolean();
				m_bFinishInHostHome = binaryReader_0.ReadBoolean();
			}
		}
	}

	private void method_11(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 75)
		{
			if (int_243 < 135)
			{
				m_bPQTask = binaryReader_0.ReadBoolean();
			}
			m_ulPQExpCnt = binaryReader_0.ReadInt32();
			if (int_243 < 176)
			{
				m_pszPQExpPointer = binaryReader_0.ReadInt32();
				m_pPQExpArrPointer = binaryReader_0.ReadInt32();
			}
			if (int_243 < 135)
			{
				m_bPQSubTask = binaryReader_0.ReadBoolean();
				m_bClearContrib = binaryReader_0.ReadBoolean();
			}
			m_ulMonsterContribCnt = binaryReader_0.ReadInt32();
			if (int_243 < 176)
			{
				m_MonstersContribPointer = binaryReader_0.ReadInt32();
			}
		}
	}

	private void method_12(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 91)
		{
			m_iPremNeedRecordTasksNum = binaryReader_0.ReadInt32();
			if (int_243 < 135)
			{
				m_bShowByNeedRecordTasksNum = binaryReader_0.ReadBoolean();
			}
		}
		if (int_243 >= 87)
		{
			m_iPremiseFactionContrib = binaryReader_0.ReadInt32();
			if (int_243 < 135)
			{
				m_bShowByFactionContrib = binaryReader_0.ReadBoolean();
			}
		}
		if (int_243 < 135)
		{
			if (int_243 >= 75)
			{
				m_bAccountTaskLimit = binaryReader_0.ReadBoolean();
			}
			if (int_243 >= 115)
			{
				m_bRoleTaskLimit = binaryReader_0.ReadBoolean();
			}
		}
		if (int_243 >= 75)
		{
			m_ulAccountTaskLimitCnt = binaryReader_0.ReadInt32();
		}
	}

	private void method_13(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 < 135)
		{
			if (int_243 >= 105)
			{
				m_bLeaveFactionFail = binaryReader_0.ReadBoolean();
			}
			if (int_243 >= 111)
			{
				m_bNotIncCntWhenFailed = binaryReader_0.ReadBoolean();
			}
			if (int_243 >= 108)
			{
				m_bNotClearItemWhenFailed = binaryReader_0.ReadBoolean();
			}
			if (int_243 >= 110)
			{
				m_bDisplayInTitleTaskUI = binaryReader_0.ReadBoolean();
			}
		}
		if (int_243 >= 146)
		{
			m_iFactionMember = binaryReader_0.ReadInt32();
		}
	}

	private void method_14(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 161)
		{
			m_ulCrossServerId = binaryReader_0.ReadInt32();
			m_ulIconStateIDForAwardVar = binaryReader_0.ReadInt32();
			m_lGlobalKeyForAwardVar = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 178)
		{
			m_lPersonKeyForAwardVar = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 185)
		{
			m_lHistoryKeyForAwardVar = binaryReader_0.ReadInt32();
		}
	}

	private void method_15(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 175)
		{
			m_bPropNeedComp = binaryReader_0.ReadBoolean();
			m_nPropExp1AndOrExp2 = binaryReader_0.ReadInt32();
			COMPARE_KEY_VALUE.Read(int_243, binaryReader_0, m_Prop1KeyValue);
			COMPARE_KEY_VALUE.Read(int_243, binaryReader_0, m_Prop2KeyValue);
		}
		if (int_243 >= 189)
		{
			m_bPropNeedComp_personal = binaryReader_0.ReadBoolean();
			m_nPropExp1AndOrExp2_personal = binaryReader_0.ReadInt32();
			COMPARE_KEY_VALUE.Read(int_243, binaryReader_0, m_Prop1KeyValue_personal);
			COMPARE_KEY_VALUE.Read(int_243, binaryReader_0, m_Prop2KeyValue_personal);
		}
	}

	private void method_16(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 180)
		{
			m_iHideOtherPlayerTime = binaryReader_0.ReadInt32();
			m_ulPropSummonedMonsters = binaryReader_0.ReadInt32();
			if (int_243 < 182)
			{
				AWARD_MONSTERS_SUMMONED.Read2(int_243, binaryReader_0, PropMonsterSummoned);
			}
		}
		if (int_243 >= 181)
		{
			m_iGfxType = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 198)
		{
			m_fVaguePromptRadius = binaryReader_0.ReadSingle();
			m_fVaguePromptX = binaryReader_0.ReadSingle();
			m_fVaguePromptY = binaryReader_0.ReadSingle();
			if (int_243 >= 215)
			{
				m_ulVaguePromptNumbers = binaryReader_0.ReadUInt32();
			}
		}
		if (int_243 >= 240)
		{
			m_iCameraMovementID = binaryReader_0.ReadInt32();
		}
	}

	private void method_17(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 96)
		{
			m_ucPremiseTransformedForm = binaryReader_0.ReadByte();
			if (int_243 < 135)
			{
				m_bShowByTransformed = binaryReader_0.ReadBoolean();
			}
		}
		m_ulPremise_Lev_Min = binaryReader_0.ReadInt32();
		m_ulPremise_Lev_Max = binaryReader_0.ReadInt32();
		if (int_243 >= 113)
		{
			m_bPremCheckMaxHistoryLevel = binaryReader_0.ReadInt32();
		}
		if (int_243 < 135)
		{
			m_bShowByLev = binaryReader_0.ReadBoolean();
		}
		if (int_243 >= 113)
		{
			if (int_243 < 135)
			{
				m_bPremCheckReincarnation = binaryReader_0.ReadBoolean();
			}
			m_ulPremReincarnationMin = binaryReader_0.ReadInt32();
			m_ulPremReincarnationMax = binaryReader_0.ReadInt32();
			if (int_243 < 135)
			{
				m_bShowByReincarnation = binaryReader_0.ReadBoolean();
				m_bPremCheckRealmLevel = binaryReader_0.ReadBoolean();
			}
			m_ulPremRealmLevelMin = binaryReader_0.ReadInt32();
			m_ulPremRealmLevelMax = binaryReader_0.ReadInt32();
			if (int_243 < 135)
			{
				m_bPremCheckRealmExpFull = binaryReader_0.ReadBoolean();
				m_bShowByRealmLevel = binaryReader_0.ReadBoolean();
			}
		}
	}

	private void method_18(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 227)
		{
			m_ulChangeSceneRemoveItemRegionNum = binaryReader_0.ReadUInt32();
			m_ulChangeSceneRemoveNum = binaryReader_0.ReadUInt32();
		}
		m_ulPremItems = binaryReader_0.ReadInt32();
		if (int_243 < 176)
		{
			m_PremItemsPointer = binaryReader_0.ReadInt32();
		}
		if (int_243 < 135)
		{
			m_bShowByItems = binaryReader_0.ReadBoolean();
			if (int_243 >= 98)
			{
				m_bPremItemsAnyOne = binaryReader_0.ReadBoolean();
			}
		}
		m_ulGivenItems = binaryReader_0.ReadInt32();
		m_ulGivenCmnCount = binaryReader_0.ReadInt32();
		m_ulGivenTskCount = binaryReader_0.ReadInt32();
		if (int_243 >= 215)
		{
			m_ulGivenRelicCount = binaryReader_0.ReadUInt32();
			m_ulGivenDongluCmnCount = binaryReader_0.ReadUInt32();
		}
		if (int_243 < 176)
		{
			m_GivenItemsPointer = binaryReader_0.ReadInt32();
		}
	}

	private void method_19(int int_243, BinaryReader binaryReader_0)
	{
		m_ulPremise_Deposit = binaryReader_0.ReadInt32();
		if (int_243 < 135)
		{
			m_bShowByDeposit = binaryReader_0.ReadBoolean();
		}
		m_lPremise_Reputation = binaryReader_0.ReadInt32();
		if (int_243 >= 53)
		{
			m_lPremise_RepuMax = binaryReader_0.ReadInt32();
		}
		if (int_243 < 135)
		{
			m_bShowByRepu = binaryReader_0.ReadBoolean();
		}
	}

	private void method_20(int int_243, BinaryReader binaryReader_0)
	{
		m_ulPremise_Task_Count = binaryReader_0.ReadInt32();
		int maxPremTaskCount = GlobalFunctions.GetMaxPremTaskCount(int_243);
		for (int i = 0; i < maxPremTaskCount; i++)
		{
			m_ulPremise_Tasks[i] = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 153)
		{
			for (int j = 0; j < maxPremTaskCount; j++)
			{
				m_usPremise_Tasks_Space[j] = binaryReader_0.ReadInt16();
			}
		}
		if (int_243 < 135)
		{
			m_bShowByPreTask = binaryReader_0.ReadBoolean();
		}
		if (int_243 >= 90)
		{
			m_ulPremise_Task_Least_Num = binaryReader_0.ReadInt32();
		}
		m_ulPremise_Period = binaryReader_0.ReadInt32();
		if (int_243 < 135)
		{
			m_bShowByPeriod = binaryReader_0.ReadBoolean();
		}
	}

	private void method_21(int int_243, BinaryReader binaryReader_0)
	{
		m_ulPremise_Faction = binaryReader_0.ReadInt32();
		if (int_243 >= 93)
		{
			m_iPremise_FactionRole = binaryReader_0.ReadInt32();
		}
		if (int_243 < 135)
		{
			m_bShowByFaction = binaryReader_0.ReadBoolean();
		}
		m_ulGender = binaryReader_0.ReadInt32();
		if (int_243 < 135)
		{
			m_bShowByGender = binaryReader_0.ReadBoolean();
		}
		m_ulOccupations = binaryReader_0.ReadInt32();
		int maxOccupations = GlobalFunctions.GetMaxOccupations(int_243);
		for (int i = 0; i < maxOccupations; i++)
		{
			m_Occupations[i] = binaryReader_0.ReadInt32();
		}
		if (int_243 < 135)
		{
			m_bShowByOccup = binaryReader_0.ReadBoolean();
			m_bPremise_Spouse = binaryReader_0.ReadBoolean();
			m_bShowBySpouse = binaryReader_0.ReadBoolean();
			if (int_243 >= 102)
			{
				m_bPremiseWeddingOwner = binaryReader_0.ReadBoolean();
				m_bShowByWeddingOwner = binaryReader_0.ReadBoolean();
			}
		}
	}

	private void method_22(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 < 135)
		{
			if (int_243 >= 52)
			{
				m_bGM = binaryReader_0.ReadBoolean();
			}
			if (int_243 >= 68)
			{
				m_bShieldUser = binaryReader_0.ReadBoolean();
			}
		}
		if (int_243 >= 75)
		{
			if (int_243 < 135)
			{
				m_bShowByRMB = binaryReader_0.ReadBoolean();
			}
			m_ulPremRMBMin = binaryReader_0.ReadInt32();
			m_ulPremRMBMax = binaryReader_0.ReadInt32();
			if (int_243 < 135)
			{
				m_bCharTime = binaryReader_0.ReadBoolean();
				m_bShowByCharTime = binaryReader_0.ReadBoolean();
			}
			m_iCharStartTime = binaryReader_0.ReadInt32();
			m_iCharEndTime = binaryReader_0.ReadInt32();
			task_tm.Read(int_243, binaryReader_0, m_tmCharEndTime);
			m_ulCharTimeGreaterThan = binaryReader_0.ReadInt32();
		}
	}

	private void method_23(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 153)
		{
			m_usPremise_Cotask_Space = binaryReader_0.ReadInt16();
		}
		m_ulPremise_Cotask = binaryReader_0.ReadInt32();
		m_ulCoTaskCond = binaryReader_0.ReadInt32();
		m_ulMutexTaskCount = binaryReader_0.ReadInt32();
		int maxMutexTasks = GlobalFunctions.GetMaxMutexTasks(int_243);
		if (int_243 >= 153)
		{
			for (int i = 0; i < maxMutexTasks; i++)
			{
				m_usMutexTasksSpace[i] = binaryReader_0.ReadInt16();
			}
		}
		for (int j = 0; j < maxMutexTasks; j++)
		{
			m_ulMutexTasks[j] = binaryReader_0.ReadInt32();
		}
		for (int k = 0; k < m_lSkillLev.Length; k++)
		{
			m_lSkillLev[k] = binaryReader_0.ReadInt32();
		}
		m_DynTaskType = binaryReader_0.ReadByte();
		m_ulSpecialAward = binaryReader_0.ReadInt32();
	}

	private void method_24(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 < 135)
		{
			m_bTeamwork = binaryReader_0.ReadBoolean();
			m_bRcvByTeam = binaryReader_0.ReadBoolean();
			m_bSharedTask = binaryReader_0.ReadBoolean();
			m_bSharedAchieved = binaryReader_0.ReadBoolean();
			m_bCheckTeammate = binaryReader_0.ReadBoolean();
		}
		m_fTeammateDist = binaryReader_0.ReadSingle();
		if (int_243 < 135)
		{
			m_bAllFail = binaryReader_0.ReadBoolean();
			m_bCapFail = binaryReader_0.ReadBoolean();
			m_bCapSucc = binaryReader_0.ReadBoolean();
		}
		m_fSuccDist = binaryReader_0.ReadSingle();
		if (int_243 < 135)
		{
			m_bDismAsSelfFail = binaryReader_0.ReadBoolean();
			m_bRcvChckMem = binaryReader_0.ReadBoolean();
		}
	}

	private void method_25(int int_243, BinaryReader binaryReader_0)
	{
		m_fRcvMemDist = binaryReader_0.ReadSingle();
		if (int_243 < 135)
		{
			m_bCntByMemPos = binaryReader_0.ReadBoolean();
		}
		m_fCntMemDist = binaryReader_0.ReadSingle();
		if (int_243 < 135)
		{
			if (int_243 >= 68)
			{
				m_bAllSucc = binaryReader_0.ReadBoolean();
			}
			if (int_243 >= 75)
			{
				m_bCoupleOnly = binaryReader_0.ReadBoolean();
			}
			if (int_243 >= 86)
			{
				m_bDistinguishedOcc = binaryReader_0.ReadBoolean();
			}
		}
		m_ulTeamMemsWanted = binaryReader_0.ReadInt32();
		if (int_243 < 176)
		{
			m_TeamMemsWantedPointer = binaryReader_0.ReadInt32();
		}
		if (int_243 < 135)
		{
			m_bShowByTeam = binaryReader_0.ReadBoolean();
		}
	}

	private void method_26(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 59)
		{
			if (int_243 < 135)
			{
				m_bPremNeedComp = binaryReader_0.ReadBoolean();
			}
			m_nPremExp1AndOrExp2 = binaryReader_0.ReadInt32();
			COMPARE_KEY_VALUE.Read(int_243, binaryReader_0, m_Prem1KeyValue);
			COMPARE_KEY_VALUE.Read(int_243, binaryReader_0, m_Prem2KeyValue);
		}
		if (int_243 >= 178)
		{
			m_nPremPersonExp1AndOrExp2 = binaryReader_0.ReadInt32();
			COMPARE_KEY_VALUE.Read(int_243, binaryReader_0, m_Prem1PersonKeyValue);
			COMPARE_KEY_VALUE.Read(int_243, binaryReader_0, m_Prem2PersonKeyValue);
		}
		if (int_243 >= 185)
		{
			m_nPremHistoryExp1AndOrExp2 = binaryReader_0.ReadInt32();
			COMPARE_KEY_VALUE.Read(int_243, binaryReader_0, m_Prem1HistoryKeyValue);
			COMPARE_KEY_VALUE.Read(int_243, binaryReader_0, m_Prem2HistoryKeyValue);
		}
	}

	private void method_27(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 97)
		{
			if (int_243 < 135)
			{
				m_bPremCheckForce = binaryReader_0.ReadBoolean();
			}
			m_iPremForce = binaryReader_0.ReadInt32();
			if (int_243 < 135)
			{
				m_bShowByForce = binaryReader_0.ReadBoolean();
			}
			m_iPremForceReputation = binaryReader_0.ReadInt32();
			if (int_243 < 135)
			{
				m_bShowByForceReputation = binaryReader_0.ReadBoolean();
			}
			m_iPremForceContribution = binaryReader_0.ReadInt32();
			if (int_243 < 135)
			{
				m_bShowByForceContribution = binaryReader_0.ReadBoolean();
			}
			m_iPremForceExp = binaryReader_0.ReadInt32();
			if (int_243 < 135)
			{
				m_bShowByForceExp = binaryReader_0.ReadBoolean();
			}
			m_iPremForceSP = binaryReader_0.ReadInt32();
			if (int_243 < 135)
			{
				m_bShowByForceSP = binaryReader_0.ReadBoolean();
			}
		}
		if (int_243 >= 99)
		{
			m_iPremForceActivityLevel = binaryReader_0.ReadInt32();
			if (int_243 < 135)
			{
				m_bShowByForceActivityLevel = binaryReader_0.ReadBoolean();
			}
		}
		if (int_243 < 135)
		{
			if (int_243 >= 106)
			{
				m_bPremIsKing = binaryReader_0.ReadBoolean();
				m_bShowByKing = binaryReader_0.ReadBoolean();
			}
			if (int_243 >= 107)
			{
				m_bPremNotInTeam = binaryReader_0.ReadBoolean();
				m_bShowByNotInTeam = binaryReader_0.ReadBoolean();
			}
		}
	}

	private void method_28(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 109)
		{
			m_iPremTitleNumTotal = binaryReader_0.ReadInt32();
			m_iPremTitleNumRequired = binaryReader_0.ReadInt32();
			if (int_243 < 176)
			{
				m_PremTitlesPointer = binaryReader_0.ReadInt32();
			}
			if (int_243 < 135)
			{
				m_bShowByTitle = binaryReader_0.ReadBoolean();
			}
		}
		if (int_243 >= 112)
		{
			for (int i = 0; i < m_iPremHistoryStageIndex.Length; i++)
			{
				m_iPremHistoryStageIndex[i] = binaryReader_0.ReadInt32();
			}
		}
		if (int_243 < 135 && int_243 >= 118)
		{
			m_bShowByHistoryStage = binaryReader_0.ReadBoolean();
		}
		if (int_243 >= 114)
		{
			m_ulPremGeneralCardCount = binaryReader_0.ReadInt32();
			if (int_243 < 135)
			{
				m_bShowByGeneralCard = binaryReader_0.ReadBoolean();
			}
		}
		if (int_243 >= 117)
		{
			m_iPremGeneralCardRank = binaryReader_0.ReadInt32();
			m_ulPremGeneralCardRankCount = binaryReader_0.ReadInt32();
			if (int_243 < 135)
			{
				m_bShowByGeneralCardRank = binaryReader_0.ReadBoolean();
			}
		}
		if (int_243 >= 122)
		{
			m_ulPremIconStateID = binaryReader_0.ReadInt32();
			if (int_243 < 135)
			{
				m_bShowByIconStateID = binaryReader_0.ReadBoolean();
			}
		}
		if (int_243 >= 236)
		{
			m_ulFailIconStateID = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 125)
		{
			m_iVIPLevelMin = binaryReader_0.ReadInt32();
			m_iVIPLevelMax = binaryReader_0.ReadInt32();
			if (int_243 < 135)
			{
				m_bShowByVIPLevel = binaryReader_0.ReadBoolean();
			}
		}
	}

	private void method_29(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 129 && int_243 < 135)
		{
			m_bPremNoHome = binaryReader_0.ReadBoolean();
		}
		if (int_243 >= 126)
		{
			m_iPremHomeLevelMin = binaryReader_0.ReadInt32();
			m_iPremHomeLevelMax = binaryReader_0.ReadInt32();
			if (int_243 < 135)
			{
				m_bShowByHomeLevel = binaryReader_0.ReadBoolean();
			}
			m_iPremHomeResourceLevelType = binaryReader_0.ReadInt32();
			m_iPremHomeResourceLevelMin = binaryReader_0.ReadInt32();
			m_iPremHomeResourceLevelMax = binaryReader_0.ReadInt32();
			if (int_243 < 135)
			{
				m_bShowByHomeResourceLevel = binaryReader_0.ReadBoolean();
			}
			m_iPremHomeFactoryLevelType = binaryReader_0.ReadInt32();
			m_iPremHomeFactoryLevelMin = binaryReader_0.ReadInt32();
			m_iPremHomeFactoryLevelMax = binaryReader_0.ReadInt32();
			if (int_243 < 135)
			{
				m_bShowByHomeFactoryLevel = binaryReader_0.ReadBoolean();
			}
			m_iPremHomeFlourishMin = binaryReader_0.ReadInt32();
			m_iPremHomeFlourishMax = binaryReader_0.ReadInt32();
			if (int_243 < 135)
			{
				m_bShowByHomeFlourish = binaryReader_0.ReadBoolean();
				m_bPremHomeStorageTask = binaryReader_0.ReadBoolean();
				m_bShowByHomeStorageTask = binaryReader_0.ReadBoolean();
			}
		}
	}

	private void method_30(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 137)
		{
			m_iPremArenaWinCount = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 146)
		{
			m_iPremFactionScore = binaryReader_0.ReadInt32();
			m_iPremFactionMoney = binaryReader_0.ReadInt32();
			m_iPremFactionPersonScore = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 153)
		{
			m_iPremMentorMorality = binaryReader_0.ReadInt32();
			m_iPremMentorStudentValue = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 156)
		{
			m_iPremCoupleIntimacy = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 158)
		{
			m_ulPremDeposit2 = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 161)
		{
			m_ulNeededTaskCount = binaryReader_0.ReadInt32();
			int maxNeededTasks = GlobalFunctions.GetMaxNeededTasks(int_243);
			for (int i = 0; i < maxNeededTasks; i++)
			{
				m_usNeededTasksSpace[i] = binaryReader_0.ReadInt16();
			}
			for (int j = 0; j < maxNeededTasks; j++)
			{
				m_ulNeededTasks[j] = binaryReader_0.ReadInt32();
			}
			m_iNeededTasksLeastNum = binaryReader_0.ReadByte();
		}
		if (int_243 >= 167)
		{
			m_iCamp = binaryReader_0.ReadInt32();
			m_iCampPower = binaryReader_0.ReadInt32();
			m_iNeedFriendPoint = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 175)
		{
			m_iRankType = binaryReader_0.ReadInt32();
			m_iRankGradeMin = binaryReader_0.ReadInt32();
			m_iRankGradeMax = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 198)
		{
			m_ulPremPanguLevelMin = binaryReader_0.ReadUInt32();
			m_ulPremPanguLevelMax = binaryReader_0.ReadUInt32();
			if (int_243 >= 215)
			{
				m_ulPremPanguLevelYear = binaryReader_0.ReadUInt32();
			}
			m_iAchievementSeriesId = binaryReader_0.ReadInt32();
			if (int_243 >= 215)
			{
				m_iPanguEquipYear = binaryReader_0.ReadInt32();
				m_iPanguEquipSlot = binaryReader_0.ReadInt32();
				m_iPanguEquipQuality = binaryReader_0.ReadInt32();
				m_iPanguEquipLevel = binaryReader_0.ReadInt32();
			}
			if (int_243 >= 218)
			{
				m_cPremInventorySizeMin = binaryReader_0.ReadByte();
				m_cPremInventorySizeMax = binaryReader_0.ReadByte();
				m_cPremStorageSizeMin = binaryReader_0.ReadByte();
				m_cPremStorageSizeMax = binaryReader_0.ReadByte();
			}
			if (int_243 >= 223)
			{
				m_iPremLieMoLevelMin = binaryReader_0.ReadInt32();
				m_iPremLieMoLevelMax = binaryReader_0.ReadInt32();
				m_iPremYuMoLevelMin = binaryReader_0.ReadInt32();
				m_iPremYuMoLevelMax = binaryReader_0.ReadInt32();
				m_cEffectiveGameServer = binaryReader_0.ReadByte();
			}
			if (int_243 >= 229)
			{
				m_iPremDailyActivityValue = binaryReader_0.ReadInt32();
			}
		}
	}

	private void method_31(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 195)
		{
			m_ulMonsterUnwanted = binaryReader_0.ReadUInt32();
		}
		m_enumMethod = binaryReader_0.ReadInt32();
		m_enumFinishType = binaryReader_0.ReadInt32();
		if (int_243 >= 103)
		{
			m_ulPlayerWanted = binaryReader_0.ReadInt32();
			if (int_243 < 176)
			{
				m_PlayerWantedPointer = binaryReader_0.ReadInt32();
			}
		}
		m_ulMonsterWanted = binaryReader_0.ReadInt32();
		if (int_243 < 176)
		{
			m_MonsterWantedPointer = binaryReader_0.ReadInt32();
		}
		m_ulItemsWanted = binaryReader_0.ReadInt32();
		if (int_243 < 176)
		{
			m_ItemsWantedPointer = binaryReader_0.ReadInt32();
		}
		m_ulGoldWanted = binaryReader_0.ReadInt32();
		if (int_243 >= 88)
		{
			m_iFactionContribWanted = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 89)
		{
			m_iFactionExpContribWanted = binaryReader_0.ReadInt32();
		}
	}

	private void method_32(int int_243, BinaryReader binaryReader_0)
	{
		m_ulNPCToProtect = binaryReader_0.ReadInt32();
		m_ulProtectTimeLen = binaryReader_0.ReadInt32();
		m_ulNPCMoving = binaryReader_0.ReadInt32();
		m_ulNPCDestSite = binaryReader_0.ReadInt32();
	}

	private void method_33(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 80)
		{
			if (int_243 < 176)
			{
				m_pReachSitePointer = binaryReader_0.ReadInt32();
			}
			m_ulReachSiteCnt = binaryReader_0.ReadInt32();
			m_ulReachSiteId = binaryReader_0.ReadInt32();
		}
		else
		{
			m_ulReachSiteCnt = 1;
			m_pReachSite = new Task_Region[m_ulReachSiteCnt];
			m_pReachSite[0] = new Task_Region();
			Task_Region.Read(int_243, binaryReader_0, m_pReachSite[0]);
			m_ulReachSiteId = binaryReader_0.ReadInt32();
			m_pReachSite[0].MapID = m_ulReachSiteId;
		}
		m_ulWaitTime = binaryReader_0.ReadInt32();
		if (int_243 >= 94)
		{
			ZONE_VERT.Read(int_243, binaryReader_0, m_TreasureStartZone);
			m_ucZonesNumX = binaryReader_0.ReadByte();
			m_ucZonesNumZ = binaryReader_0.ReadByte();
			m_ucZoneSide = binaryReader_0.ReadByte();
		}
		if (int_243 >= 137)
		{
			m_usZoneMapID = binaryReader_0.ReadInt16();
		}
		if (int_243 >= 69)
		{
			if (int_243 >= 80)
			{
				if (int_243 < 176)
				{
					m_pLeaveSitePointer = binaryReader_0.ReadInt32();
				}
				m_ulLeaveSiteCnt = binaryReader_0.ReadInt32();
				m_ulLeaveSiteId = binaryReader_0.ReadInt32();
			}
			else
			{
				m_ulLeaveSiteCnt = 1;
				m_pLeaveSite = new Task_Region[m_ulLeaveSiteCnt];
				m_pLeaveSite[0] = new Task_Region();
				Task_Region.Read(int_243, binaryReader_0, m_pLeaveSite[0]);
				m_ulLeaveSiteId = binaryReader_0.ReadInt32();
				m_pLeaveSite[0].MapID = m_ulLeaveSiteId;
			}
		}
		else
		{
			m_pLeaveSite = new Task_Region[0];
		}
	}

	private void method_34(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 59)
		{
			if (int_243 < 135)
			{
				m_bFinNeedComp = binaryReader_0.ReadBoolean();
			}
			m_nFinExp1AndOrExp2 = binaryReader_0.ReadInt32();
			COMPARE_KEY_VALUE.Read(int_243, binaryReader_0, m_Fin1KeyValue);
			COMPARE_KEY_VALUE.Read(int_243, binaryReader_0, m_Fin2KeyValue);
		}
		if (int_243 >= 178)
		{
			m_nFinPersonExp1AndOrExp2 = binaryReader_0.ReadInt32();
			COMPARE_KEY_VALUE.Read(int_243, binaryReader_0, m_Fin1PersonKeyValue);
			COMPARE_KEY_VALUE.Read(int_243, binaryReader_0, m_Fin2PersonKeyValue);
		}
		if (int_243 >= 185)
		{
			m_nFinHistoryExp1AndOrExp2 = binaryReader_0.ReadInt32();
			COMPARE_KEY_VALUE.Read(int_243, binaryReader_0, m_Fin1HistoryKeyValue);
			COMPARE_KEY_VALUE.Read(int_243, binaryReader_0, m_Fin2HistoryKeyValue);
		}
	}

	private void method_35(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 63)
		{
			m_ulExpCnt = binaryReader_0.ReadInt32();
			if (int_243 < 176)
			{
				m_pszExpPointer = binaryReader_0.ReadInt32();
				m_pExpArrPointer = binaryReader_0.ReadInt32();
			}
		}
		if (int_243 >= 178)
		{
			m_ulPersonExpCnt = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 185)
		{
			m_ulHistoryExpCnt = binaryReader_0.ReadInt32();
		}
	}

	private void method_36(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 63)
		{
			m_ulTaskCharCnt = binaryReader_0.ReadInt32();
			if (int_243 < 176)
			{
				m_pTaskCharPointer = binaryReader_0.ReadInt32();
			}
		}
		if (int_243 >= 178)
		{
			m_ulPersonTaskCharCnt = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 185)
		{
			m_ulHistoryTaskCharCnt = binaryReader_0.ReadInt32();
		}
	}

	private void method_37(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 104)
		{
			m_ucTransformedForm = binaryReader_0.ReadByte();
		}
		if (int_243 >= 215)
		{
			m_ulMonsterShapeID = binaryReader_0.ReadUInt32();
		}
		if (int_243 >= 156 && int_243 < 175)
		{
			TransformedDescID = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 113)
		{
			m_ulReachLevel = binaryReader_0.ReadInt32();
			m_ulReachReincarnationCount = binaryReader_0.ReadInt32();
			m_ulReachRealmLevel = binaryReader_0.ReadInt32();
			m_uiEmotion = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 153)
		{
			m_ulGrowthTarget = binaryReader_0.ReadInt32();
		}
	}

	private void method_38(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 223)
		{
			m_uSpecialMethodType = binaryReader_0.ReadUInt32();
			m_uSpecialMethodParm1 = binaryReader_0.ReadUInt32();
			m_uSpecialMethodParm2 = binaryReader_0.ReadUInt32();
			m_uSpecialMethodParm3 = binaryReader_0.ReadUInt32();
			m_uSpecialMethodNpcServicesCount = binaryReader_0.ReadUInt32();
			m_uSpecialMethodNpcServicesLeastLeastCount = binaryReader_0.ReadUInt32();
			m_uSpecialMethodTargetTaskCount = binaryReader_0.ReadUInt32();
			m_uSpecialMethodTargetTaskLeastCount = binaryReader_0.ReadUInt32();
		}
	}

	private void method_39(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 122)
		{
			m_ulTMIconStateID = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 156 && int_243 < 175)
		{
			TMIconStateDescID = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 127)
		{
			m_ulTMHomeLevelType = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 126)
		{
			m_ulTMReachHomeLevel = binaryReader_0.ReadInt32();
			m_ulTMReachHomeFlourish = binaryReader_0.ReadInt32();
			m_ulHomeItemsWanted = binaryReader_0.ReadInt32();
			if (int_243 < 176)
			{
				m_HomeItemsWantedPointer = binaryReader_0.ReadInt32();
			}
		}
		if (int_243 >= 135)
		{
			m_ulBindOnCarrierId = binaryReader_0.ReadInt32();
			if (int_243 >= 140)
			{
				m_ulTMReachArenaCount = binaryReader_0.ReadInt16();
			}
			else
			{
				m_ulTMReachArenaCount = binaryReader_0.ReadInt32();
			}
		}
		if (int_243 >= 137)
		{
			if (int_243 >= 140)
			{
				m_ulTMReachArenaWinCount = binaryReader_0.ReadInt16();
			}
			else
			{
				m_ulTMReachArenaWinCount = binaryReader_0.ReadInt32();
			}
		}
		if (int_243 >= 215)
		{
			m_ulTransmitPointID = binaryReader_0.ReadUInt32();
		}
		if (int_243 >= 156)
		{
			m_szShowDialogName = GlobalFunctions.ReadNameChars(20, binaryReader_0);
		}
		if (int_243 >= 167)
		{
			m_iTriggerEvent = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 175)
		{
			m_iVerifyStateLayer = binaryReader_0.ReadInt32();
			m_ulVerifyStateLayerID = binaryReader_0.ReadInt32();
			m_iKeyWordIndex = binaryReader_0.ReadInt32();
		}
	}

	private void method_40(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 194)
		{
			camera_pos_x = binaryReader_0.ReadSingle();
			camera_pos_y = binaryReader_0.ReadSingle();
			camera_pos_z = binaryReader_0.ReadSingle();
			camera_quat_x = binaryReader_0.ReadSingle();
			camera_quat_y = binaryReader_0.ReadSingle();
			camera_quat_z = binaryReader_0.ReadSingle();
			camera_quat_a = binaryReader_0.ReadSingle();
			camera_target_pos_x = binaryReader_0.ReadSingle();
			camera_target_pos_y = binaryReader_0.ReadSingle();
			camera_target_pos_z = binaryReader_0.ReadSingle();
			camera_target_quat_x = binaryReader_0.ReadSingle();
			camera_target_quat_y = binaryReader_0.ReadSingle();
			camera_target_quat_z = binaryReader_0.ReadSingle();
			camera_target_quat_a = binaryReader_0.ReadSingle();
			camera_rotate_axis = binaryReader_0.ReadInt32();
			camera_rotate_angle = binaryReader_0.ReadSingle();
			camera_take_seconds = binaryReader_0.ReadSingle();
		}
		if (int_243 >= 215)
		{
			m_ulSubmitItemWantedNum = binaryReader_0.ReadUInt32();
		}
		if (int_243 >= 228)
		{
			m_ulDailyActivityValue = binaryReader_0.ReadUInt32();
		}
	}

	private void method_41(int int_243, BinaryReader binaryReader_0)
	{
		m_ulAwardType_S = binaryReader_0.ReadInt32();
		m_ulAwardType_F = binaryReader_0.ReadInt32();
		if (int_243 < 176)
		{
			m_Award_SPointer = binaryReader_0.ReadInt32();
			m_Award_FPointer = binaryReader_0.ReadInt32();
			m_AwByRatio_SPointer = binaryReader_0.ReadInt32();
			m_AwByRatio_FPointer = binaryReader_0.ReadInt32();
			m_AwByItems_SPointer = binaryReader_0.ReadInt32();
			m_AwByItems_FPointer = binaryReader_0.ReadInt32();
			if (int_243 >= 140)
			{
				AwByTaskEventRatio_SPointer = binaryReader_0.ReadInt32();
				AwByTaskEventRatio_FPointer = binaryReader_0.ReadInt32();
			}
			if (int_243 >= 146)
			{
				AwByCarrierHp_SPointer = binaryReader_0.ReadInt32();
				AwByCarrierHp_FPointer = binaryReader_0.ReadInt32();
			}
			if (int_243 >= 161)
			{
				AwByVar_SPointer = binaryReader_0.ReadInt32();
				AwByVar_FPointer = binaryReader_0.ReadInt32();
			}
		}
		m_ulParent = binaryReader_0.ReadInt32();
		m_ulPrevSibling = binaryReader_0.ReadInt32();
		m_ulNextSibling = binaryReader_0.ReadInt32();
		m_ulFirstChild = binaryReader_0.ReadInt32();
		if (int_243 >= 83)
		{
			if (int_243 < 135)
			{
				m_bIsLibraryTask = binaryReader_0.ReadBoolean();
			}
			m_fLibraryTasksProbability = binaryReader_0.ReadSingle();
		}
		if (int_243 >= 95 && int_243 < 135)
		{
			m_bIsUniqueStorageTask = binaryReader_0.ReadBoolean();
		}
		if (int_243 >= 119)
		{
			m_iWorldContribution = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 215)
		{
			m_iMaskDisableIcon = binaryReader_0.ReadInt32();
		}
	}

	private void method_42(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 135)
		{
			CombinedSwitches = binaryReader_0.ReadBytes(GlobalFunctions.GetCombinedSwitches(int_243));
			method_43(int_243);
		}
	}

	private void method_43(int int_243)
	{
		if (int_243 >= 135)
		{
			m_bShowByTransformed = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 0);
			m_bShowByLev = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 1);
			m_bPremCheckReincarnation = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 2);
			m_bShowByReincarnation = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 3);
			m_bPremCheckRealmLevel = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 4);
			m_bPremCheckRealmExpFull = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 5);
			if (int_243 >= 232)
			{
				m_bCheckTradeTime = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 6);
				m_bShowByTradeTime = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 7);
			}
			m_bShowByRealmLevel = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 8);
			m_bShowByItems = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 9);
			m_bPremItemsAnyOne = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 10);
			if (int_243 >= 215)
			{
				m_bMethodItemsRandOne = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 11);
			}
			m_bNotOpenWithItem = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 12);
			m_bShowByDeposit = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 13);
			m_bShowByRepu = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 14);
			m_bShowByPreTask = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 15);
			m_bShowByPeriod = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 16);
			m_bShowByFaction = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 17);
			m_bShowByGender = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 18);
			m_bShowByOccup = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 19);
			m_bPremise_Spouse = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 20);
			m_bShowBySpouse = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 21);
			m_bPremiseWeddingOwner = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 22);
			m_bShowByWeddingOwner = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 23);
			m_bGM = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 24);
			m_bShieldUser = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 25);
			m_bShowByRMB = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 26);
			m_bCharTime = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 27);
			m_bShowByCharTime = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 28);
			m_bTeamwork = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 29);
			m_bRcvByTeam = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 30);
			m_bSharedTask = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 31);
			m_bSharedAchieved = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 32);
			m_bCheckTeammate = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 33);
			m_bAllFail = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 34);
			m_bCapFail = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 35);
			m_bCapSucc = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 36);
			m_bDismAsSelfFail = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 37);
			m_bRcvChckMem = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 38);
			m_bCntByMemPos = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 39);
			m_bAllSucc = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 40);
			m_bCoupleOnly = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 41);
			m_bDistinguishedOcc = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 42);
			m_bShowByTeam = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 43);
			m_bPremNeedComp = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 44);
			if (int_243 >= 178)
			{
				m_bPremPersonNeedComp = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 45);
			}
			if (int_243 >= 185)
			{
				m_bPremHistoryNeedComp = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 46);
			}
			m_bPremCheckForce = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 47);
			m_bShowByForce = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 48);
			m_bShowByForceReputation = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 49);
			m_bShowByForceContribution = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 50);
			m_bShowByForceExp = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 51);
			m_bShowByForceSP = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 52);
			m_bShowByForceActivityLevel = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 53);
			m_bPremIsKing = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 54);
			m_bShowByKing = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 55);
			m_bPremNotInTeam = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 56);
			m_bShowByNotInTeam = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 57);
			m_bShowByTitle = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 58);
			m_bShowByHistoryStage = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 59);
			m_bShowByGeneralCard = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 60);
			m_bShowByGeneralCardRank = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 61);
			m_bShowByIconStateID = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 62);
			m_bShowByVIPLevel = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 63);
			m_bPremNoHome = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 64);
			m_bShowByHomeLevel = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 65);
			m_bShowByHomeResourceLevel = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 66);
			m_bShowByHomeFactoryLevel = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 67);
			m_bShowByHomeFlourish = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 68);
			m_bPremHomeStorageTask = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 69);
			m_bShowByHomeStorageTask = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 70);
			m_bMonsterTotalCount = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 71);
			if (int_243 >= 195)
			{
				m_bDoNotShowGfx = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 72);
			}
			m_bFinNeedComp = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 73);
			if (int_243 >= 178)
			{
				m_bFinPersonNeedComp = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 74);
			}
			if (int_243 >= 185)
			{
				m_bFinHistoryNeedComp = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 75);
			}
			m_bIsLibraryTask = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 76);
			m_bIsUniqueStorageTask = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 77);
			m_bHasSign = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 78);
			m_bOfflineFail = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 79);
			m_bItemNotTakeOff = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 80);
			m_bAbsTime = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 81);
			if (int_243 >= 180)
			{
				m_bMultiNpcTalk = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 82);
			}
			m_bChooseOne = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 83);
			m_bRandOne = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 84);
			m_bExeChildInOrder = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 85);
			m_bParentAlsoFail = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 86);
			m_bParentAlsoSucc = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 87);
			m_bCanGiveUp = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 88);
			m_bCanRedo = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 89);
			m_bCanRedoAfterFailure = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 90);
			m_bClearAsGiveUp = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 91);
			m_bNeedRecord = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 92);
			m_bFailAsPlayerDie = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 93);
			m_bDelvInZone = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 94);
			m_bEnterRegionFail = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 95);
			m_bLeaveRegionFail = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 96);
			m_bLeaveForceFail = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 97);
			m_bTransTo = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 98);
			m_bTrigCtrl = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 99);
			m_bAutoDeliver = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 100);
			if (int_243 >= 240)
			{
				m_bAutoDeliverHighPriority = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 101);
			}
			m_bDisplayInExclusiveUI = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 102);
			m_bReadyToNotifyServer = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 103);
			m_bUsedInTokenShop = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 104);
			m_bDeathTrig = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 105);
			m_bClearAcquired = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 106);
			m_bShowPrompt = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 107);
			m_bKeyTask = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 108);
			m_bSkillTask = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 109);
			m_bCanSeekOut = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 110);
			m_bShowDirection = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 111);
			m_bMarriage = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 112);
			m_bSwitchSceneFail = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 113);
			m_bHidden = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 114);
			m_bDeliverySkill = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 115);
			m_bShowGfxFinished = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 116);
			m_bChangePQRanking = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 117);
			m_bCompareItemAndInventory = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 118);
			m_bTowerTask = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 119);
			m_bHomeTask = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 120);
			m_bDeliverInHostHome = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 121);
			m_bFinishInHostHome = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 122);
			m_bPQTask = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 123);
			m_bPQSubTask = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 124);
			m_bClearContrib = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 125);
			m_bShowByNeedRecordTasksNum = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 126);
			m_bShowByFactionContrib = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 127);
			m_bAccountTaskLimit = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 128);
			m_bRoleTaskLimit = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 129);
			m_bLeaveFactionFail = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 130);
			m_bNotIncCntWhenFailed = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 131);
			m_bNotClearItemWhenFailed = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 132);
			m_bDisplayInTitleTaskUI = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 133);
			m_bCanAwardOnCarrier = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 134);
			if (int_243 >= 137)
			{
				m_bPremReachArenaWinCount = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 135);
				m_bShowByReachArenaWinCount = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 136);
			}
			if (int_243 >= 140)
			{
				m_bWriteSpecialLog = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 137);
			}
			if (int_243 >= 146)
			{
				m_bShowByFactionScore = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 138);
				m_bShowByFactionMoney = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 139);
				m_bShowByFactionPersonScore = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 140);
				m_bCheckFactionMember = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 141);
				m_bPremFaction = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 142);
				m_bSpecialLogic = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 143);
			}
			if (int_243 >= 153)
			{
				m_bBecomeMentor = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 144);
				m_bShowMentorMorality = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 145);
				m_bShowMentorStudentValue = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 146);
				m_bDiscardedTask = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 147);
				m_bNoCheckTitleGot = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 148);
			}
			if (int_243 >= 156)
			{
				m_bShowCoupleIntimacy = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 149);
			}
			if (int_243 >= 158)
			{
				m_bShowDeposit2 = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 150);
			}
			if (int_243 >= 194)
			{
				m_bCrossServer = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 151);
			}
			if (int_243 >= 163)
			{
				m_bRecordFnshCnt = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 152);
			}
			if (int_243 >= 198)
			{
				m_bRecordReset = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 153);
			}
			if (int_243 >= 167)
			{
				m_bShowCamp = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 154);
				m_bShowCampPower = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 155);
				m_bReturnCampPower = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 156);
				m_bTeamHaveRecaller = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 157);
				m_bBindedRecaller = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 158);
				m_bShowNeedFriendPoint = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 159);
			}
			if (int_243 >= 175)
			{
				m_bHistoryVarTask = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 160);
				m_bRankPre = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 161);
				m_bDeliverByUI = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 162);
			}
			if (int_243 >= 177)
			{
				m_bWarTaskAward = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 163);
			}
			if (int_243 >= 180)
			{
				m_bHideOtherPlayer = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 164);
			}
			if (int_243 >= 187)
			{
				m_bRecordDeliverTime = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 165);
			}
			if (int_243 >= 194)
			{
				m_bShowMethod = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 166);
			}
			if (int_243 >= 198)
			{
				m_bPremCheckPanguLevel = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 167);
				m_bShowAchievementSeriesId = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 168);
				m_bVaguePromptingMode = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 169);
			}
			if (int_243 >= 215)
			{
				m_bCheckPanguEquip = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 170);
				m_bShowPanguEquipPremise = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 171);
				m_bShowExploreIcon = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 172);
			}
			if (int_243 >= 234)
			{
				m_bShowByExpNotFull = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 173);
			}
			if (int_243 >= 218)
			{
				m_bCheckInventorySize = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 174);
				m_bCheckStorageSize = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 175);
				m_bShowPackSizePremise = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 176);
			}
			if (int_243 >= 234)
			{
				m_bShowByRealmExpNotFull = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 177);
				m_bAllowBatchAward = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 178);
			}
			if (int_243 >= 223)
			{
				m_bCheckExp = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 179);
				m_bCheckRealmExp = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 180);
				m_bShowPropertyPremis = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 181);
				m_bCheckLieMoLevel = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 182);
				m_bCheckYuMoLevel = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 183);
			}
			if (int_243 >= 229)
			{
				m_bShowDailyActivityPremise = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 184);
			}
			if (int_243 >= 236)
			{
				m_bFailIconStateID = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 185);
			}
			if (int_243 >= 238)
			{
				m_bPremTotalItemsWanted = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 186);
				m_bMethodTotalItemsWanted = GlobalFunctions.ChckPrm(int_243, CombinedSwitches, 187);
			}
		}
	}

	private void method_44(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 == 139)
		{
			m_bWriteSpecialLog = binaryReader_0.ReadBoolean();
		}
		if (int_243 >= 146)
		{
			x_SpecialParametersCount = binaryReader_0.ReadInt32();
			if (int_243 < 176)
			{
				SpecialParametersPointer = binaryReader_0.ReadInt32();
			}
		}
		if (m_bHasSign)
		{
			m_pszSignature = GlobalFunctions.ReadNameChars(30, binaryReader_0);
		}
	}

	private void method_45(int int_243, BinaryReader binaryReader_0)
	{
		m_tmStart = new task_tm[m_ulTimetable];
		m_tmEnd = new task_tm[m_ulTimetable];
		for (int i = 0; i < m_ulTimetable; i++)
		{
			m_tmStart[i] = new task_tm();
			task_tm.Read(int_243, binaryReader_0, m_tmStart[i]);
			m_tmEnd[i] = new task_tm();
			task_tm.Read(int_243, binaryReader_0, m_tmEnd[i]);
		}
	}

	private void method_46(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 59)
		{
			m_plChangeKey = new int[m_ulChangeKeyCnt];
			m_plChangeKeyValue = new int[m_ulChangeKeyCnt];
			m_plChangeKeyValue2 = new int[m_ulChangeKeyCnt];
			m_pbChangeType = new byte[m_ulChangeKeyCnt];
			for (int i = 0; i < m_ulChangeKeyCnt; i++)
			{
				m_plChangeKey[i] = binaryReader_0.ReadInt32();
				m_plChangeKeyValue[i] = binaryReader_0.ReadInt32();
				if (int_243 >= 215)
				{
					m_plChangeKeyValue2[i] = binaryReader_0.ReadInt32();
				}
				else
				{
					m_plChangeKeyValue2[i] = 0;
				}
				m_pbChangeType[i] = binaryReader_0.ReadByte();
			}
		}
		if (int_243 >= 178)
		{
			m_plPersonChangeKey = new int[m_ulChangePersonKeyCnt];
			m_plPersonChangeKeyValue = new int[m_ulChangePersonKeyCnt];
			m_plPersonChangeKeyValue2 = new int[m_ulChangePersonKeyCnt];
			m_pbPersonChangeType = new byte[m_ulChangePersonKeyCnt];
			for (int j = 0; j < m_ulChangePersonKeyCnt; j++)
			{
				m_plPersonChangeKey[j] = binaryReader_0.ReadInt32();
				m_plPersonChangeKeyValue[j] = binaryReader_0.ReadInt32();
				if (int_243 >= 215)
				{
					m_plPersonChangeKeyValue2[j] = binaryReader_0.ReadInt32();
				}
				else
				{
					m_plPersonChangeKeyValue2[j] = 0;
				}
				m_pbPersonChangeType[j] = binaryReader_0.ReadByte();
			}
		}
		if (int_243 < 185)
		{
			return;
		}
		m_plHistoryChangeKey = new int[m_ulChangeHistoryKeyCnt];
		m_plHistoryChangeKeyValue = new int[m_ulChangeHistoryKeyCnt];
		m_plHistoryChangeKeyValue2 = new int[m_ulChangeHistoryKeyCnt];
		m_pbHistoryChangeType = new byte[m_ulChangeHistoryKeyCnt];
		for (int k = 0; k < m_ulChangeHistoryKeyCnt; k++)
		{
			m_plHistoryChangeKey[k] = binaryReader_0.ReadInt32();
			m_plHistoryChangeKeyValue[k] = binaryReader_0.ReadInt32();
			if (int_243 >= 215)
			{
				m_plHistoryChangeKeyValue2[k] = binaryReader_0.ReadInt32();
			}
			else
			{
				m_plHistoryChangeKeyValue2[k] = 0;
			}
			m_pbHistoryChangeType[k] = binaryReader_0.ReadByte();
		}
	}

	private void method_47(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 75)
		{
			m_pszPQExp = new char[m_ulPQExpCnt][];
			m_pPQExpArr = new TASK_EXPRESSION[m_ulPQExpCnt][];
			for (int i = 0; i < m_ulPQExpCnt; i++)
			{
				m_pszPQExp[i] = GlobalFunctions.ReadChars(64, binaryReader_0);
				m_pPQExpArr[i] = new TASK_EXPRESSION[64];
				for (int j = 0; j < m_pPQExpArr[i].Length; j++)
				{
					m_pPQExpArr[i][j] = new TASK_EXPRESSION();
					TASK_EXPRESSION.Read(int_243, binaryReader_0, m_pPQExpArr[i][j]);
				}
			}
			m_MonstersContrib = new MONSTERS_CONTRIB[m_ulMonsterContribCnt];
			for (int k = 0; k < m_ulMonsterContribCnt; k++)
			{
				m_MonstersContrib[k] = new MONSTERS_CONTRIB();
				MONSTERS_CONTRIB.Read(int_243, binaryReader_0, m_MonstersContrib[k]);
			}
		}
		if (int_243 >= 182)
		{
			PropMonsterSummoned.m_ulMonsterNum = m_ulPropSummonedMonsters;
			AWARD_MONSTERS_SUMMONED.Read3(int_243, binaryReader_0, PropMonsterSummoned);
		}
	}

	private void method_48(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 80)
		{
			m_pDelvRegion = new Task_Region[m_ulDelvRegionCnt];
			for (int i = 0; i < m_ulDelvRegionCnt; i++)
			{
				m_pDelvRegion[i] = new Task_Region();
				Task_Region.Read(int_243, binaryReader_0, m_pDelvRegion[i]);
				if (int_243 < 157)
				{
					m_pDelvRegion[i].MapID = m_ulDelvWorld;
				}
			}
			m_pEnterRegion = new Task_Region[m_ulEnterRegionCnt];
			for (int j = 0; j < m_ulEnterRegionCnt; j++)
			{
				m_pEnterRegion[j] = new Task_Region();
				Task_Region.Read(int_243, binaryReader_0, m_pEnterRegion[j]);
				if (int_243 < 157)
				{
					m_pEnterRegion[j].MapID = m_ulEnterRegionWorld;
				}
			}
			m_pLeaveRegion = new Task_Region[m_ulLeaveRegionCnt];
			for (int k = 0; k < m_ulLeaveRegionCnt; k++)
			{
				m_pLeaveRegion[k] = new Task_Region();
				Task_Region.Read(int_243, binaryReader_0, m_pLeaveRegion[k]);
				if (int_243 < 157)
				{
					m_pLeaveRegion[k].MapID = m_ulLeaveRegionWorld;
				}
			}
		}
		if (int_243 >= 215)
		{
			m_pVaguePromptInfo = new VAGUE_PROMPT_INFO[m_ulVaguePromptNumbers];
			for (int l = 0; l < m_ulVaguePromptNumbers; l++)
			{
				m_pVaguePromptInfo[l] = new VAGUE_PROMPT_INFO();
				VAGUE_PROMPT_INFO.Read(int_243, binaryReader_0, m_pVaguePromptInfo[l]);
			}
		}
	}

	private void method_49(int int_243, BinaryReader binaryReader_0)
	{
		m_PremItems = new ITEM_WANTED[m_ulPremItems];
		for (int i = 0; i < m_ulPremItems; i++)
		{
			m_PremItems[i] = new ITEM_WANTED();
			ITEM_WANTED.Read(int_243, binaryReader_0, m_PremItems[i]);
		}
		m_GivenItems = new ITEM_WANTED[m_ulGivenItems];
		for (int j = 0; j < m_ulGivenItems; j++)
		{
			m_GivenItems[j] = new ITEM_WANTED();
			ITEM_WANTED.Read(int_243, binaryReader_0, m_GivenItems[j]);
		}
		m_TeamMemsWanted = new TEAM_MEM_WANTED[m_ulTeamMemsWanted];
		for (int k = 0; k < m_ulTeamMemsWanted; k++)
		{
			m_TeamMemsWanted[k] = new TEAM_MEM_WANTED();
			TEAM_MEM_WANTED.Read(int_243, binaryReader_0, m_TeamMemsWanted[k]);
		}
		if (int_243 >= 109)
		{
			m_PremTitles = new int[m_iPremTitleNumTotal];
			for (int l = 0; l < m_iPremTitleNumTotal; l++)
			{
				m_PremTitles[l] = binaryReader_0.ReadInt32();
			}
		}
		if (int_243 >= 227)
		{
			m_pChangeSceneRemoveItemRegionNum = new ITEM_WANTED[m_ulChangeSceneRemoveItemRegionNum];
			for (int m = 0; m < m_ulChangeSceneRemoveItemRegionNum; m++)
			{
				m_pChangeSceneRemoveItemRegionNum[m] = new ITEM_WANTED();
				ITEM_WANTED.Read(int_243, binaryReader_0, m_pChangeSceneRemoveItemRegionNum[m]);
			}
			m_pChangeSceneRemoveNum = new Task_Region[m_ulChangeSceneRemoveNum];
			for (int n = 0; n < m_ulChangeSceneRemoveNum; n++)
			{
				m_pChangeSceneRemoveNum[n] = new Task_Region();
				Task_Region.Read(int_243, binaryReader_0, m_pChangeSceneRemoveNum[n]);
			}
		}
	}

	private void method_50(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 195)
		{
			m_MonsterUnwanted = new MONSTER_WANTED[m_ulMonsterUnwanted];
			for (int i = 0; i < m_ulMonsterUnwanted; i++)
			{
				m_MonsterUnwanted[i] = new MONSTER_WANTED();
				MONSTER_WANTED.Read(int_243, binaryReader_0, m_MonsterUnwanted[i]);
			}
		}
		m_MonsterWanted = new MONSTER_WANTED[m_ulMonsterWanted];
		for (int j = 0; j < m_ulMonsterWanted; j++)
		{
			m_MonsterWanted[j] = new MONSTER_WANTED();
			MONSTER_WANTED.Read(int_243, binaryReader_0, m_MonsterWanted[j]);
		}
		if (int_243 >= 103)
		{
			m_PlayerWanted = new PLAYER_WANTED[m_ulPlayerWanted];
			for (int k = 0; k < m_ulPlayerWanted; k++)
			{
				m_PlayerWanted[k] = new PLAYER_WANTED();
				PLAYER_WANTED.Read(int_243, binaryReader_0, m_PlayerWanted[k]);
			}
		}
		m_ItemsWanted = new ITEM_WANTED[m_ulItemsWanted];
		for (int l = 0; l < m_ulItemsWanted; l++)
		{
			m_ItemsWanted[l] = new ITEM_WANTED();
			ITEM_WANTED.Read(int_243, binaryReader_0, m_ItemsWanted[l]);
		}
	}

	private void method_51(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 215)
		{
			m_pSubmitItemWanted = new ITEM_WANTED[m_ulSubmitItemWantedNum];
			for (int i = 0; i < m_ulSubmitItemWantedNum; i++)
			{
				m_pSubmitItemWanted[i] = new ITEM_WANTED();
				ITEM_WANTED.Read(int_243, binaryReader_0, m_pSubmitItemWanted[i]);
			}
		}
		if (int_243 >= 223)
		{
			m_pTSMNPCServices = new TSMNPCServices[m_uSpecialMethodNpcServicesCount];
			for (int j = 0; j < m_uSpecialMethodNpcServicesCount; j++)
			{
				m_pTSMNPCServices[j] = new TSMNPCServices();
				TSMNPCServices.Read(int_243, binaryReader_0, m_pTSMNPCServices[j]);
			}
			m_pTSMTargetTask = new TSMTargetTask[m_uSpecialMethodTargetTaskCount];
			for (int k = 0; k < m_uSpecialMethodTargetTaskCount; k++)
			{
				m_pTSMTargetTask[k] = new TSMTargetTask();
				TSMTargetTask.Read(int_243, binaryReader_0, m_pTSMTargetTask[k]);
			}
		}
	}

	private void method_52(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 63)
		{
			m_pszExp = new char[m_ulExpCnt][];
			m_pExpArr = new TASK_EXPRESSION[m_ulExpCnt][];
			for (int i = 0; i < m_ulExpCnt; i++)
			{
				m_pszExp[i] = GlobalFunctions.ReadChars(64, binaryReader_0);
				m_pExpArr[i] = new TASK_EXPRESSION[64];
				for (int j = 0; j < m_pExpArr[i].Length; j++)
				{
					m_pExpArr[i][j] = new TASK_EXPRESSION();
					TASK_EXPRESSION.Read(int_243, binaryReader_0, m_pExpArr[i][j]);
				}
			}
			m_pTaskChar = new short[m_ulTaskCharCnt][];
			for (int k = 0; k < m_ulTaskCharCnt; k++)
			{
				m_pTaskChar[k] = GlobalFunctions.ReadNameChars(64, binaryReader_0);
			}
		}
		if (int_243 >= 178)
		{
			PersonExp = new char[m_ulPersonExpCnt][];
			PersonExpArr = new TASK_EXPRESSION[m_ulPersonExpCnt][];
			for (int l = 0; l < m_ulPersonExpCnt; l++)
			{
				PersonExp[l] = GlobalFunctions.ReadChars(64, binaryReader_0);
				PersonExpArr[l] = new TASK_EXPRESSION[64];
				for (int m = 0; m < PersonExpArr[l].Length; m++)
				{
					PersonExpArr[l][m] = new TASK_EXPRESSION();
					TASK_EXPRESSION.Read(int_243, binaryReader_0, PersonExpArr[l][m]);
				}
			}
			PersonTaskChar = new short[m_ulPersonTaskCharCnt][];
			for (int n = 0; n < m_ulPersonTaskCharCnt; n++)
			{
				PersonTaskChar[n] = GlobalFunctions.ReadNameChars(64, binaryReader_0);
			}
		}
		if (int_243 < 185)
		{
			return;
		}
		HistoryExp = new char[m_ulHistoryExpCnt][];
		HistoryExpArr = new TASK_EXPRESSION[m_ulHistoryExpCnt][];
		for (int num = 0; num < m_ulHistoryExpCnt; num++)
		{
			HistoryExp[num] = GlobalFunctions.ReadChars(64, binaryReader_0);
			HistoryExpArr[num] = new TASK_EXPRESSION[64];
			for (int num2 = 0; num2 < HistoryExpArr[num].Length; num2++)
			{
				HistoryExpArr[num][num2] = new TASK_EXPRESSION();
				TASK_EXPRESSION.Read(int_243, binaryReader_0, HistoryExpArr[num][num2]);
			}
		}
		HistoryTaskChar = new short[m_ulHistoryTaskCharCnt][];
		for (int num3 = 0; num3 < m_ulHistoryTaskCharCnt; num3++)
		{
			HistoryTaskChar[num3] = GlobalFunctions.ReadNameChars(64, binaryReader_0);
		}
	}

	private void method_53(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 < 80)
		{
			return;
		}
		m_pReachSite = new Task_Region[m_ulReachSiteCnt];
		for (int i = 0; i < m_ulReachSiteCnt; i++)
		{
			m_pReachSite[i] = new Task_Region();
			Task_Region.Read(int_243, binaryReader_0, m_pReachSite[i]);
			if (int_243 < 157)
			{
				m_pReachSite[i].MapID = m_ulReachSiteId;
			}
		}
		m_pLeaveSite = new Task_Region[m_ulLeaveSiteCnt];
		for (int j = 0; j < m_ulLeaveSiteCnt; j++)
		{
			m_pLeaveSite[j] = new Task_Region();
			Task_Region.Read(int_243, binaryReader_0, m_pLeaveSite[j]);
			if (int_243 < 157)
			{
				m_pLeaveSite[j].MapID = m_ulLeaveSiteId;
			}
		}
	}

	private void method_54(int int_243, BinaryReader binaryReader_0)
	{
	}

	private void method_55(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 126)
		{
			m_HomeItemsWanted = new HOME_ITEM_WANTED[m_ulHomeItemsWanted];
			for (int i = 0; i < m_ulHomeItemsWanted; i++)
			{
				m_HomeItemsWanted[i] = new HOME_ITEM_WANTED();
				HOME_ITEM_WANTED.Read(int_243, binaryReader_0, m_HomeItemsWanted[i]);
			}
		}
	}

	private void method_56(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 140)
		{
			TaskEventMonsterData = new TaskEventData[m_usTaskEventMonsterCount];
			for (int i = 0; i < m_usTaskEventMonsterCount; i++)
			{
				TaskEventMonsterData[i] = new TaskEventData();
				TaskEventData.Read(int_243, binaryReader_0, TaskEventMonsterData[i]);
			}
			TaskEventMineData = new TaskEventData[m_usTaskEventMineCount];
			for (int j = 0; j < m_usTaskEventMineCount; j++)
			{
				TaskEventMineData[j] = new TaskEventData();
				TaskEventData.Read(int_243, binaryReader_0, TaskEventMineData[j]);
			}
			TaskEventTaskData = new TaskEventData[m_usTaskEventTaskCount];
			for (int k = 0; k < m_usTaskEventTaskCount; k++)
			{
				TaskEventTaskData[k] = new TaskEventData();
				TaskEventData.Read(int_243, binaryReader_0, TaskEventTaskData[k]);
			}
		}
	}

	private void method_57(int int_243, BinaryReader binaryReader_0)
	{
		if (int_243 >= 140)
		{
			m_TaskEventName = GlobalFunctions.ReadNameChars(30, binaryReader_0);
			m_TaskEventType = binaryReader_0.ReadInt32();
			m_usTaskEventTimeOrScore = binaryReader_0.ReadInt16();
			m_usTaskEventMonsterCount = binaryReader_0.ReadInt16();
			if (int_243 < 176)
			{
				TaskEventMonsterDataPointer = binaryReader_0.ReadInt32();
			}
			m_usTaskEventMineCount = binaryReader_0.ReadInt16();
			if (int_243 < 176)
			{
				TaskEventMineDataPointer = binaryReader_0.ReadInt32();
			}
			m_usTaskEventTaskCount = binaryReader_0.ReadInt16();
			if (int_243 < 176)
			{
				TaskEventTaskDataPointer = binaryReader_0.ReadInt32();
			}
		}
		if (int_243 >= 146)
		{
			m_FactionPersonScore = binaryReader_0.ReadInt16();
		}
		if (int_243 >= 153)
		{
			m_iTinyGameType = binaryReader_0.ReadByte();
		}
		if (int_243 >= 215)
		{
			m_iSlotMachineType = binaryReader_0.ReadByte();
		}
		if (int_243 >= 158)
		{
			m_ulGoldWanted2 = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 185)
		{
			m_chatGroupId = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 219)
		{
			m_HintConfigId = binaryReader_0.ReadInt32();
		}
		if (int_243 >= 188)
		{
			m_iGuessStringID = binaryReader_0.ReadInt32();
		}
	}

	private void method_58(int int_243, BinaryReader binaryReader_0)
	{
		AWARD_DATA.Read(int_243, binaryReader_0, m_Award_S);
		AWARD_DATA.Read(int_243, binaryReader_0, m_Award_F);
		AWARD_RATIO_SCALE.Read(int_243, binaryReader_0, m_AwByRatio_S);
		AWARD_RATIO_SCALE.Read(int_243, binaryReader_0, m_AwByRatio_F);
		AWARD_ITEMS_SCALE.Read(int_243, binaryReader_0, m_AwByItems_S);
		AWARD_ITEMS_SCALE.Read(int_243, binaryReader_0, m_AwByItems_F);
		if (int_243 >= 140)
		{
			AWARD_RATIO_SCALE.Read(int_243, binaryReader_0, AwByTaskEventRatio_S);
			AWARD_RATIO_SCALE.Read(int_243, binaryReader_0, AwByTaskEventRatio_F);
		}
		if (int_243 >= 146)
		{
			AWARD_CARRIER_HP_SCALE.Read(int_243, binaryReader_0, AwByCarrierHp_S);
			AWARD_CARRIER_HP_SCALE.Read(int_243, binaryReader_0, AwByCarrierHp_F);
		}
		if (int_243 >= 161)
		{
			AWARD_VAR_SCALE.Read(int_243, binaryReader_0, AwByVar_S);
			AWARD_VAR_SCALE.Read(int_243, binaryReader_0, AwByVar_F);
		}
		if (int_243 >= 146)
		{
			SPECIAL_PARAMETERS.Read(int_243, binaryReader_0, x_SpecialParametersCount, SpecialParameters, m_ID);
		}
	}

	public void logic_write_task_data_struct(int version, BinaryWriter bw)
	{
		List<Action<int, BinaryWriter>> list = new List<Action<int, BinaryWriter>>
		{
			method_59, method_60, method_61, method_62, method_63, method_64, method_65, method_66, method_67, method_68,
			method_69, method_70, method_71, method_72, method_73, method_74, method_75, method_76, method_77, method_78,
			method_79, method_80, method_115, method_81, method_82, method_83, method_84, method_85, method_86, method_87,
			method_88, method_89, method_90, method_91, method_92, method_93, method_94, method_95, method_96, method_97,
			method_116, method_98, method_99, method_100, method_101, method_102, method_103, method_104, method_105, method_106,
			method_107, method_108, method_109, method_110, method_111, method_112, method_113, method_114
		};
		foreach (Action<int, BinaryWriter> item in list)
		{
			item(version, bw);
		}
	}

	private void method_59(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 153)
		{
			binaryWriter_0.Write(m_usIDSpace);
		}
		binaryWriter_0.Write(m_ID);
		GlobalFunctions.WriteNameChars(binaryWriter_0, m_szName);
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bHasSign);
		}
		if (int_243 < 176)
		{
			binaryWriter_0.Write(m_pszSignaturePointer);
		}
		binaryWriter_0.Write(m_ulType);
		binaryWriter_0.Write(m_ulTimeLimit);
	}

	private void method_60(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 68)
		{
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bOfflineFail);
			}
			binaryWriter_0.Write(m_bAbsFail);
			task_tm.Write(int_243, binaryWriter_0, m_tmAbsFailTime);
			if (int_243 >= 175)
			{
				binaryWriter_0.Write(m_bNextTimeFail);
				task_tm.Write(int_243, binaryWriter_0, m_tmNextFailTime);
			}
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bItemNotTakeOff);
			}
		}
		if (int_243 >= 52 && int_243 < 135)
		{
			binaryWriter_0.Write(m_bAbsTime);
		}
		int maxTimetableSize = GlobalFunctions.GetMaxTimetableSize(int_243);
		if (m_ulTimetable > maxTimetableSize)
		{
			binaryWriter_0.Write(maxTimetableSize);
		}
		else
		{
			binaryWriter_0.Write(m_ulTimetable);
		}
		if (int_243 >= 52)
		{
			for (int i = 0; i < maxTimetableSize; i++)
			{
				binaryWriter_0.Write(m_tmType[i]);
			}
		}
		if (int_243 < 176)
		{
			binaryWriter_0.Write(m_tmStartPointer);
			binaryWriter_0.Write(m_tmEndPointer);
		}
		if (int_243 >= 52)
		{
			binaryWriter_0.Write(m_lAvailFrequency);
		}
		if (int_243 >= 191)
		{
			binaryWriter_0.Write(m_lFrequencyNum);
		}
		if (int_243 >= 85)
		{
			binaryWriter_0.Write(m_lPeriodLimit);
		}
		if (int_243 >= 175)
		{
			binaryWriter_0.Write(m_bAvailFrequency);
			task_tm.Write(int_243, binaryWriter_0, m_tmAvailFrequency);
		}
	}

	private void method_61(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bChooseOne);
			binaryWriter_0.Write(m_bRandOne);
			binaryWriter_0.Write(m_bExeChildInOrder);
			binaryWriter_0.Write(m_bParentAlsoFail);
			binaryWriter_0.Write(m_bParentAlsoSucc);
			binaryWriter_0.Write(m_bCanGiveUp);
			binaryWriter_0.Write(m_bCanRedo);
			binaryWriter_0.Write(m_bCanRedoAfterFailure);
			binaryWriter_0.Write(m_bClearAsGiveUp);
			binaryWriter_0.Write(m_bNeedRecord);
			binaryWriter_0.Write(m_bFailAsPlayerDie);
		}
		binaryWriter_0.Write(m_ulMaxReceiver);
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bDelvInZone);
		}
		binaryWriter_0.Write(m_ulDelvWorld);
	}

	private void method_62(int int_243, BinaryWriter binaryWriter_0)
	{
		int maxTaskRegion = GlobalFunctions.GetMaxTaskRegion(int_243);
		if (int_243 >= 80)
		{
			if (m_ulDelvRegionCnt > maxTaskRegion)
			{
				binaryWriter_0.Write(maxTaskRegion);
			}
			else
			{
				binaryWriter_0.Write(m_ulDelvRegionCnt);
			}
			if (int_243 < 176)
			{
				binaryWriter_0.Write(m_pDelvRegionPointer);
			}
		}
		else if (m_pDelvRegion.Length != 0)
		{
			Task_Region.Write(int_243, binaryWriter_0, m_pDelvRegion[0]);
		}
		else
		{
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
		}
	}

	private void method_63(int int_243, BinaryWriter binaryWriter_0)
	{
		int maxTaskRegion = GlobalFunctions.GetMaxTaskRegion(int_243);
		if (int_243 < 68)
		{
			return;
		}
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bEnterRegionFail);
		}
		binaryWriter_0.Write(m_ulEnterRegionWorld);
		if (int_243 >= 80)
		{
			if (m_ulEnterRegionCnt > maxTaskRegion)
			{
				binaryWriter_0.Write(maxTaskRegion);
			}
			else
			{
				binaryWriter_0.Write(m_ulEnterRegionCnt);
			}
			if (int_243 < 176)
			{
				binaryWriter_0.Write(m_pEnterRegionPointer);
			}
		}
		else if (m_pEnterRegion.Length != 0)
		{
			Task_Region.Write(int_243, binaryWriter_0, m_pEnterRegion[0]);
		}
		else
		{
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
		}
	}

	private void method_64(int int_243, BinaryWriter binaryWriter_0)
	{
		int maxTaskRegion = GlobalFunctions.GetMaxTaskRegion(int_243);
		if (int_243 < 68)
		{
			return;
		}
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bLeaveRegionFail);
		}
		binaryWriter_0.Write(m_ulLeaveRegionWorld);
		if (int_243 >= 80)
		{
			if (m_ulLeaveRegionCnt > maxTaskRegion)
			{
				binaryWriter_0.Write(maxTaskRegion);
			}
			else
			{
				binaryWriter_0.Write(m_ulLeaveRegionCnt);
			}
			if (int_243 < 176)
			{
				binaryWriter_0.Write(m_pLeaveRegionPointer);
			}
		}
		else if (m_pLeaveRegion.Length != 0)
		{
			Task_Region.Write(int_243, binaryWriter_0, m_pLeaveRegion[0]);
		}
		else
		{
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
		}
	}

	private void method_65(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 97 && int_243 < 135)
		{
			binaryWriter_0.Write(m_bLeaveForceFail);
		}
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bTransTo);
		}
		binaryWriter_0.Write(m_ulTransWldId);
		ZONE_VERT.Write(int_243, binaryWriter_0, m_TransPt);
		if (int_243 >= 52)
		{
			binaryWriter_0.Write(m_lMonsCtrl);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bTrigCtrl);
			}
		}
	}

	private void method_66(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bAutoDeliver);
			if (int_243 >= 84)
			{
				binaryWriter_0.Write(m_bDisplayInExclusiveUI);
			}
			if (int_243 >= 89)
			{
				binaryWriter_0.Write(m_bReadyToNotifyServer);
			}
			if (int_243 >= 116)
			{
				binaryWriter_0.Write(m_bUsedInTokenShop);
			}
			binaryWriter_0.Write(m_bDeathTrig);
			binaryWriter_0.Write(m_bClearAcquired);
		}
		binaryWriter_0.Write(m_ulSuitableLevel);
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bShowPrompt);
			binaryWriter_0.Write(m_bKeyTask);
		}
		binaryWriter_0.Write(m_ulDelvNPC);
		binaryWriter_0.Write(m_ulAwardNPC);
	}

	private void method_67(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bSkillTask);
			if (int_243 >= 52)
			{
				binaryWriter_0.Write(m_bCanSeekOut);
				binaryWriter_0.Write(m_bShowDirection);
			}
			if (int_243 >= 55)
			{
				binaryWriter_0.Write(m_bMarriage);
			}
		}
	}

	private void method_68(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 59)
		{
			binaryWriter_0.Write(m_ulChangeKeyCnt);
			if (int_243 < 176)
			{
				binaryWriter_0.Write(m_plChangeKeyPointer);
				binaryWriter_0.Write(m_plChangeKeyValuePointer);
				binaryWriter_0.Write(m_pbChangeTypePointer);
			}
		}
		if (int_243 >= 178)
		{
			binaryWriter_0.Write(m_ulChangePersonKeyCnt);
		}
		if (int_243 >= 185)
		{
			binaryWriter_0.Write(m_ulChangeHistoryKeyCnt);
		}
		if (int_243 >= 63 && int_243 < 135)
		{
			binaryWriter_0.Write(m_bSwitchSceneFail);
			binaryWriter_0.Write(m_bHidden);
		}
		if (int_243 >= 78)
		{
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bDeliverySkill);
			}
			binaryWriter_0.Write(m_iDeliveredSkillID);
			binaryWriter_0.Write(m_iDeliveredSkillLevel);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bShowGfxFinished);
			}
		}
		if (int_243 >= 79 && int_243 < 135)
		{
			binaryWriter_0.Write(m_bChangePQRanking);
		}
		if (int_243 >= 81)
		{
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bCompareItemAndInventory);
			}
			binaryWriter_0.Write(m_ulInventorySlotNum);
		}
	}

	private void method_69(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 < 135)
		{
			if (int_243 >= 123)
			{
				binaryWriter_0.Write(m_bTowerTask);
			}
			if (int_243 >= 126)
			{
				binaryWriter_0.Write(m_bHomeTask);
			}
			if (int_243 >= 128)
			{
				binaryWriter_0.Write(m_bDeliverInHostHome);
				binaryWriter_0.Write(m_bFinishInHostHome);
			}
		}
	}

	private void method_70(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 75)
		{
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bPQTask);
			}
			binaryWriter_0.Write(m_ulPQExpCnt);
			if (int_243 < 176)
			{
				binaryWriter_0.Write(m_pszPQExpPointer);
				binaryWriter_0.Write(m_pPQExpArrPointer);
			}
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bPQSubTask);
				binaryWriter_0.Write(m_bClearContrib);
			}
			binaryWriter_0.Write(m_ulMonsterContribCnt);
			if (int_243 < 176)
			{
				binaryWriter_0.Write(m_MonstersContribPointer);
			}
		}
	}

	private void method_71(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 91)
		{
			binaryWriter_0.Write(m_iPremNeedRecordTasksNum);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bShowByNeedRecordTasksNum);
			}
		}
		if (int_243 >= 87)
		{
			binaryWriter_0.Write(m_iPremiseFactionContrib);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bShowByFactionContrib);
			}
		}
		if (int_243 < 135)
		{
			if (int_243 >= 75)
			{
				binaryWriter_0.Write(m_bAccountTaskLimit);
			}
			if (int_243 >= 115)
			{
				binaryWriter_0.Write(m_bRoleTaskLimit);
			}
		}
		if (int_243 >= 75)
		{
			binaryWriter_0.Write(m_ulAccountTaskLimitCnt);
		}
	}

	private void method_72(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 < 135)
		{
			if (int_243 >= 105)
			{
				binaryWriter_0.Write(m_bLeaveFactionFail);
			}
			if (int_243 >= 111)
			{
				binaryWriter_0.Write(m_bNotIncCntWhenFailed);
			}
			if (int_243 >= 108)
			{
				binaryWriter_0.Write(m_bNotClearItemWhenFailed);
			}
			if (int_243 >= 110)
			{
				binaryWriter_0.Write(m_bDisplayInTitleTaskUI);
			}
		}
		if (int_243 >= 146)
		{
			binaryWriter_0.Write(m_iFactionMember);
		}
	}

	private void method_73(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 161)
		{
			binaryWriter_0.Write(m_ulCrossServerId);
			binaryWriter_0.Write(m_ulIconStateIDForAwardVar);
			binaryWriter_0.Write(m_lGlobalKeyForAwardVar);
		}
		if (int_243 >= 178)
		{
			binaryWriter_0.Write(m_lPersonKeyForAwardVar);
		}
		if (int_243 >= 185)
		{
			binaryWriter_0.Write(m_lHistoryKeyForAwardVar);
		}
	}

	private void method_74(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 175)
		{
			binaryWriter_0.Write(m_bPropNeedComp);
			binaryWriter_0.Write(m_nPropExp1AndOrExp2);
			COMPARE_KEY_VALUE.Write(int_243, binaryWriter_0, m_Prop1KeyValue);
			COMPARE_KEY_VALUE.Write(int_243, binaryWriter_0, m_Prop2KeyValue);
		}
		if (int_243 >= 189)
		{
			binaryWriter_0.Write(m_bPropNeedComp_personal);
			binaryWriter_0.Write(m_nPropExp1AndOrExp2_personal);
			COMPARE_KEY_VALUE.Write(int_243, binaryWriter_0, m_Prop1KeyValue_personal);
			COMPARE_KEY_VALUE.Write(int_243, binaryWriter_0, m_Prop2KeyValue_personal);
		}
	}

	private void method_75(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 180)
		{
			binaryWriter_0.Write(m_iHideOtherPlayerTime);
			binaryWriter_0.Write(m_ulPropSummonedMonsters);
			if (int_243 < 182)
			{
				AWARD_MONSTERS_SUMMONED.Write2(int_243, binaryWriter_0, PropMonsterSummoned);
			}
		}
		if (int_243 >= 181)
		{
			binaryWriter_0.Write(m_iGfxType);
		}
		if (int_243 >= 198)
		{
			binaryWriter_0.Write(m_fVaguePromptRadius);
			binaryWriter_0.Write(m_fVaguePromptX);
			binaryWriter_0.Write(m_fVaguePromptY);
			if (int_243 >= 215)
			{
				binaryWriter_0.Write(m_ulVaguePromptNumbers);
			}
		}
		if (int_243 >= 240)
		{
			binaryWriter_0.Write(m_iCameraMovementID);
		}
	}

	private void method_76(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 96)
		{
			binaryWriter_0.Write(m_ucPremiseTransformedForm);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bShowByTransformed);
			}
		}
		binaryWriter_0.Write(m_ulPremise_Lev_Min);
		binaryWriter_0.Write(m_ulPremise_Lev_Max);
		if (int_243 >= 113)
		{
			binaryWriter_0.Write(m_bPremCheckMaxHistoryLevel);
		}
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bShowByLev);
		}
		if (int_243 >= 113)
		{
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bPremCheckReincarnation);
			}
			binaryWriter_0.Write(m_ulPremReincarnationMin);
			binaryWriter_0.Write(m_ulPremReincarnationMax);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bShowByReincarnation);
				binaryWriter_0.Write(m_bPremCheckRealmLevel);
			}
			binaryWriter_0.Write(m_ulPremRealmLevelMin);
			binaryWriter_0.Write(m_ulPremRealmLevelMax);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bPremCheckRealmExpFull);
				binaryWriter_0.Write(m_bShowByRealmLevel);
			}
		}
	}

	private void method_77(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 227)
		{
			binaryWriter_0.Write(m_ulChangeSceneRemoveItemRegionNum);
			binaryWriter_0.Write(m_ulChangeSceneRemoveNum);
		}
		binaryWriter_0.Write(m_ulPremItems);
		if (int_243 < 176)
		{
			binaryWriter_0.Write(m_PremItemsPointer);
		}
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bShowByItems);
			if (int_243 >= 98)
			{
				binaryWriter_0.Write(m_bPremItemsAnyOne);
			}
		}
		binaryWriter_0.Write(m_ulGivenItems);
		binaryWriter_0.Write(m_ulGivenCmnCount);
		binaryWriter_0.Write(m_ulGivenTskCount);
		if (int_243 >= 215)
		{
			binaryWriter_0.Write(m_ulGivenRelicCount);
			binaryWriter_0.Write(m_ulGivenDongluCmnCount);
		}
		if (int_243 < 176)
		{
			binaryWriter_0.Write(m_GivenItemsPointer);
		}
	}

	private void method_78(int int_243, BinaryWriter binaryWriter_0)
	{
		binaryWriter_0.Write(m_ulPremise_Deposit);
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bShowByDeposit);
		}
		binaryWriter_0.Write(m_lPremise_Reputation);
		if (int_243 >= 53)
		{
			binaryWriter_0.Write(m_lPremise_RepuMax);
		}
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bShowByRepu);
		}
	}

	private void method_79(int int_243, BinaryWriter binaryWriter_0)
	{
		int maxPremTaskCount = GlobalFunctions.GetMaxPremTaskCount(int_243);
		if (int_243 < 90)
		{
			for (int i = maxPremTaskCount; i < m_ulPremise_Tasks.Length; i++)
			{
				if (m_ulPremise_Tasks[i] > 0)
				{
					m_ulPremise_Task_Count--;
				}
			}
		}
		binaryWriter_0.Write(m_ulPremise_Task_Count);
		for (int j = 0; j < maxPremTaskCount; j++)
		{
			binaryWriter_0.Write(m_ulPremise_Tasks[j]);
		}
		if (int_243 >= 153)
		{
			for (int k = 0; k < maxPremTaskCount; k++)
			{
				binaryWriter_0.Write(m_usPremise_Tasks_Space[k]);
			}
		}
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bShowByPreTask);
		}
		if (int_243 >= 90)
		{
			binaryWriter_0.Write(m_ulPremise_Task_Least_Num);
		}
		binaryWriter_0.Write(m_ulPremise_Period);
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bShowByPeriod);
		}
	}

	private void method_80(int int_243, BinaryWriter binaryWriter_0)
	{
		binaryWriter_0.Write(m_ulPremise_Faction);
		if (int_243 >= 93)
		{
			binaryWriter_0.Write(m_iPremise_FactionRole);
		}
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bShowByFaction);
		}
		binaryWriter_0.Write(m_ulGender);
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bShowByGender);
		}
		int maxOccupations = GlobalFunctions.GetMaxOccupations(int_243);
		for (int i = maxOccupations; i < m_Occupations.Length; i++)
		{
			if (m_Occupations[i] > 0)
			{
				m_ulOccupations--;
			}
		}
		binaryWriter_0.Write(m_ulOccupations);
		for (int j = 0; j < maxOccupations; j++)
		{
			binaryWriter_0.Write(m_Occupations[j]);
		}
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bShowByOccup);
			binaryWriter_0.Write(m_bPremise_Spouse);
			binaryWriter_0.Write(m_bShowBySpouse);
			if (int_243 >= 102)
			{
				binaryWriter_0.Write(m_bPremiseWeddingOwner);
				binaryWriter_0.Write(m_bShowByWeddingOwner);
			}
		}
	}

	private void method_81(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 153)
		{
			binaryWriter_0.Write(m_usPremise_Cotask_Space);
		}
		binaryWriter_0.Write(m_ulPremise_Cotask);
		binaryWriter_0.Write(m_ulCoTaskCond);
		binaryWriter_0.Write(m_ulMutexTaskCount);
		int maxMutexTasks = GlobalFunctions.GetMaxMutexTasks(int_243);
		if (int_243 >= 153)
		{
			for (int i = 0; i < maxMutexTasks; i++)
			{
				binaryWriter_0.Write(m_usMutexTasksSpace[i]);
			}
		}
		for (int j = 0; j < maxMutexTasks; j++)
		{
			binaryWriter_0.Write(m_ulMutexTasks[j]);
		}
		for (int k = 0; k < m_lSkillLev.Length; k++)
		{
			binaryWriter_0.Write(m_lSkillLev[k]);
		}
		binaryWriter_0.Write(m_DynTaskType);
		binaryWriter_0.Write(m_ulSpecialAward);
	}

	private void method_82(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bTeamwork);
			binaryWriter_0.Write(m_bRcvByTeam);
			binaryWriter_0.Write(m_bSharedTask);
			binaryWriter_0.Write(m_bSharedAchieved);
			binaryWriter_0.Write(m_bCheckTeammate);
		}
		binaryWriter_0.Write(m_fTeammateDist);
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bAllFail);
			binaryWriter_0.Write(m_bCapFail);
			binaryWriter_0.Write(m_bCapSucc);
		}
		binaryWriter_0.Write(m_fSuccDist);
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bDismAsSelfFail);
			binaryWriter_0.Write(m_bRcvChckMem);
		}
	}

	private void method_83(int int_243, BinaryWriter binaryWriter_0)
	{
		binaryWriter_0.Write(m_fRcvMemDist);
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bCntByMemPos);
		}
		binaryWriter_0.Write(m_fCntMemDist);
		if (int_243 < 135)
		{
			if (int_243 >= 68)
			{
				binaryWriter_0.Write(m_bAllSucc);
			}
			if (int_243 >= 75)
			{
				binaryWriter_0.Write(m_bCoupleOnly);
			}
			if (int_243 >= 86)
			{
				binaryWriter_0.Write(m_bDistinguishedOcc);
			}
		}
		if (m_bTeamwork)
		{
			binaryWriter_0.Write(m_ulTeamMemsWanted);
		}
		else
		{
			binaryWriter_0.Write(0);
		}
		if (int_243 < 176)
		{
			binaryWriter_0.Write(m_TeamMemsWantedPointer);
		}
		if (int_243 < 135)
		{
			binaryWriter_0.Write(m_bShowByTeam);
		}
	}

	private void method_84(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 59)
		{
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bPremNeedComp);
			}
			binaryWriter_0.Write(m_nPremExp1AndOrExp2);
			COMPARE_KEY_VALUE.Write(int_243, binaryWriter_0, m_Prem1KeyValue);
			COMPARE_KEY_VALUE.Write(int_243, binaryWriter_0, m_Prem2KeyValue);
		}
		if (int_243 >= 178)
		{
			binaryWriter_0.Write(m_nPremPersonExp1AndOrExp2);
			COMPARE_KEY_VALUE.Write(int_243, binaryWriter_0, m_Prem1PersonKeyValue);
			COMPARE_KEY_VALUE.Write(int_243, binaryWriter_0, m_Prem2PersonKeyValue);
		}
		if (int_243 >= 185)
		{
			binaryWriter_0.Write(m_nPremHistoryExp1AndOrExp2);
			COMPARE_KEY_VALUE.Write(int_243, binaryWriter_0, m_Prem1HistoryKeyValue);
			COMPARE_KEY_VALUE.Write(int_243, binaryWriter_0, m_Prem2HistoryKeyValue);
		}
	}

	private void method_85(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 97)
		{
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bPremCheckForce);
			}
			binaryWriter_0.Write(m_iPremForce);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bShowByForce);
			}
			binaryWriter_0.Write(m_iPremForceReputation);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bShowByForceReputation);
			}
			binaryWriter_0.Write(m_iPremForceContribution);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bShowByForceContribution);
			}
			binaryWriter_0.Write(m_iPremForceExp);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bShowByForceExp);
			}
			binaryWriter_0.Write(m_iPremForceSP);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bShowByForceSP);
			}
		}
		if (int_243 >= 99)
		{
			binaryWriter_0.Write(m_iPremForceActivityLevel);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bShowByForceActivityLevel);
			}
		}
		if (int_243 < 135)
		{
			if (int_243 >= 106)
			{
				binaryWriter_0.Write(m_bPremIsKing);
				binaryWriter_0.Write(m_bShowByKing);
			}
			if (int_243 >= 107)
			{
				binaryWriter_0.Write(m_bPremNotInTeam);
				binaryWriter_0.Write(m_bShowByNotInTeam);
			}
		}
	}

	private void method_86(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 109)
		{
			binaryWriter_0.Write(m_iPremTitleNumTotal);
			binaryWriter_0.Write(m_iPremTitleNumRequired);
			if (int_243 < 176)
			{
				binaryWriter_0.Write(m_PremTitlesPointer);
			}
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bShowByTitle);
			}
		}
		if (int_243 >= 112)
		{
			for (int i = 0; i < m_iPremHistoryStageIndex.Length; i++)
			{
				binaryWriter_0.Write(m_iPremHistoryStageIndex[i]);
			}
		}
		if (int_243 < 135 && int_243 >= 118)
		{
			binaryWriter_0.Write(m_bShowByHistoryStage);
		}
		if (int_243 >= 114)
		{
			binaryWriter_0.Write(m_ulPremGeneralCardCount);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bShowByGeneralCard);
			}
		}
		if (int_243 >= 117)
		{
			binaryWriter_0.Write(m_iPremGeneralCardRank);
			binaryWriter_0.Write(m_ulPremGeneralCardRankCount);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bShowByGeneralCardRank);
			}
		}
		if (int_243 >= 122)
		{
			binaryWriter_0.Write(m_ulPremIconStateID);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bShowByIconStateID);
			}
		}
		if (int_243 >= 236)
		{
			binaryWriter_0.Write(m_ulFailIconStateID);
		}
		if (int_243 >= 125)
		{
			binaryWriter_0.Write(m_iVIPLevelMin);
			binaryWriter_0.Write(m_iVIPLevelMax);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bShowByVIPLevel);
			}
		}
	}

	private void method_87(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 129 && int_243 < 135)
		{
			binaryWriter_0.Write(m_bPremNoHome);
		}
		if (int_243 >= 126)
		{
			binaryWriter_0.Write(m_iPremHomeLevelMin);
			binaryWriter_0.Write(m_iPremHomeLevelMax);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bShowByHomeLevel);
			}
			binaryWriter_0.Write(m_iPremHomeResourceLevelType);
			binaryWriter_0.Write(m_iPremHomeResourceLevelMin);
			binaryWriter_0.Write(m_iPremHomeResourceLevelMax);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bShowByHomeResourceLevel);
			}
			binaryWriter_0.Write(m_iPremHomeFactoryLevelType);
			binaryWriter_0.Write(m_iPremHomeFactoryLevelMin);
			binaryWriter_0.Write(m_iPremHomeFactoryLevelMax);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bShowByHomeFactoryLevel);
			}
			binaryWriter_0.Write(m_iPremHomeFlourishMin);
			binaryWriter_0.Write(m_iPremHomeFlourishMax);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bShowByHomeFlourish);
				binaryWriter_0.Write(m_bPremHomeStorageTask);
				binaryWriter_0.Write(m_bShowByHomeStorageTask);
			}
		}
	}

	private void method_88(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 137)
		{
			binaryWriter_0.Write(m_iPremArenaWinCount);
		}
		if (int_243 >= 146)
		{
			binaryWriter_0.Write(m_iPremFactionScore);
			binaryWriter_0.Write(m_iPremFactionMoney);
			binaryWriter_0.Write(m_iPremFactionPersonScore);
		}
		if (int_243 >= 153)
		{
			binaryWriter_0.Write(m_iPremMentorMorality);
			binaryWriter_0.Write(m_iPremMentorStudentValue);
		}
		if (int_243 >= 156)
		{
			binaryWriter_0.Write(m_iPremCoupleIntimacy);
		}
		if (int_243 >= 158)
		{
			binaryWriter_0.Write(m_ulPremDeposit2);
		}
		if (int_243 >= 161)
		{
			binaryWriter_0.Write(m_ulNeededTaskCount);
			int maxNeededTasks = GlobalFunctions.GetMaxNeededTasks(int_243);
			for (int i = 0; i < maxNeededTasks; i++)
			{
				binaryWriter_0.Write(m_usNeededTasksSpace[i]);
			}
			for (int j = 0; j < maxNeededTasks; j++)
			{
				binaryWriter_0.Write(m_ulNeededTasks[j]);
			}
			binaryWriter_0.Write(m_iNeededTasksLeastNum);
		}
		if (int_243 >= 167)
		{
			binaryWriter_0.Write(m_iCamp);
			binaryWriter_0.Write(m_iCampPower);
			binaryWriter_0.Write(m_iNeedFriendPoint);
		}
		if (int_243 >= 175)
		{
			binaryWriter_0.Write(m_iRankType);
			binaryWriter_0.Write(m_iRankGradeMin);
			binaryWriter_0.Write(m_iRankGradeMax);
		}
		if (int_243 >= 198)
		{
			binaryWriter_0.Write(m_ulPremPanguLevelMin);
			binaryWriter_0.Write(m_ulPremPanguLevelMax);
			if (int_243 >= 215)
			{
				binaryWriter_0.Write(m_ulPremPanguLevelYear);
			}
			binaryWriter_0.Write(m_iAchievementSeriesId);
			if (int_243 >= 215)
			{
				binaryWriter_0.Write(m_iPanguEquipYear);
				binaryWriter_0.Write(m_iPanguEquipSlot);
				binaryWriter_0.Write(m_iPanguEquipQuality);
				binaryWriter_0.Write(m_iPanguEquipLevel);
			}
			if (int_243 >= 218)
			{
				binaryWriter_0.Write(m_cPremInventorySizeMin);
				binaryWriter_0.Write(m_cPremInventorySizeMax);
				binaryWriter_0.Write(m_cPremStorageSizeMin);
				binaryWriter_0.Write(m_cPremStorageSizeMax);
			}
			if (int_243 >= 223)
			{
				binaryWriter_0.Write(m_iPremLieMoLevelMin);
				binaryWriter_0.Write(m_iPremLieMoLevelMax);
				binaryWriter_0.Write(m_iPremYuMoLevelMin);
				binaryWriter_0.Write(m_iPremYuMoLevelMax);
				binaryWriter_0.Write(m_cEffectiveGameServer);
			}
			if (int_243 >= 229)
			{
				binaryWriter_0.Write(m_iPremDailyActivityValue);
			}
		}
	}

	private void method_89(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 195)
		{
			binaryWriter_0.Write(m_ulMonsterUnwanted);
		}
		binaryWriter_0.Write(m_enumMethod);
		binaryWriter_0.Write(m_enumFinishType);
		int maxPlayerWanted = GlobalFunctions.GetMaxPlayerWanted(int_243);
		if (int_243 >= 103)
		{
			if (m_ulPlayerWanted > maxPlayerWanted)
			{
				binaryWriter_0.Write(maxPlayerWanted);
			}
			else
			{
				binaryWriter_0.Write(m_ulPlayerWanted);
			}
			if (int_243 < 176)
			{
				binaryWriter_0.Write(m_PlayerWantedPointer);
			}
		}
		int maxMonsterWanted = GlobalFunctions.GetMaxMonsterWanted(int_243);
		if (m_ulMonsterWanted > maxMonsterWanted)
		{
			binaryWriter_0.Write(maxMonsterWanted);
		}
		else
		{
			binaryWriter_0.Write(m_ulMonsterWanted);
		}
		if (int_243 < 176)
		{
			binaryWriter_0.Write(m_MonsterWantedPointer);
		}
		binaryWriter_0.Write(m_ulItemsWanted);
		if (int_243 < 176)
		{
			binaryWriter_0.Write(m_ItemsWantedPointer);
		}
		binaryWriter_0.Write(m_ulGoldWanted);
		if (int_243 >= 88)
		{
			binaryWriter_0.Write(m_iFactionContribWanted);
		}
		if (int_243 >= 89)
		{
			binaryWriter_0.Write(m_iFactionExpContribWanted);
		}
	}

	private void method_90(int int_243, BinaryWriter binaryWriter_0)
	{
		binaryWriter_0.Write(m_ulNPCToProtect);
		binaryWriter_0.Write(m_ulProtectTimeLen);
		binaryWriter_0.Write(m_ulNPCMoving);
		binaryWriter_0.Write(m_ulNPCDestSite);
	}

	private void method_91(int int_243, BinaryWriter binaryWriter_0)
	{
		int maxTaskRegion = GlobalFunctions.GetMaxTaskRegion(int_243);
		if (int_243 >= 80)
		{
			if (int_243 < 176)
			{
				binaryWriter_0.Write(m_pReachSitePointer);
			}
			if (m_ulReachSiteCnt > maxTaskRegion)
			{
				binaryWriter_0.Write(maxTaskRegion);
			}
			else
			{
				binaryWriter_0.Write(m_ulReachSiteCnt);
			}
		}
		else if (m_pReachSite.Length != 0)
		{
			Task_Region.Write(int_243, binaryWriter_0, m_pReachSite[0]);
		}
		else
		{
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
		}
		binaryWriter_0.Write(m_ulReachSiteId);
		binaryWriter_0.Write(m_ulWaitTime);
		if (int_243 >= 94)
		{
			ZONE_VERT.Write(int_243, binaryWriter_0, m_TreasureStartZone);
			binaryWriter_0.Write(m_ucZonesNumX);
			binaryWriter_0.Write(m_ucZonesNumZ);
			binaryWriter_0.Write(m_ucZoneSide);
		}
		if (int_243 >= 137)
		{
			binaryWriter_0.Write(m_usZoneMapID);
		}
		int maxTaskRegion2 = GlobalFunctions.GetMaxTaskRegion(int_243);
		if (int_243 < 69)
		{
			return;
		}
		if (int_243 >= 80)
		{
			if (int_243 < 176)
			{
				binaryWriter_0.Write(m_pLeaveSitePointer);
			}
			if (m_ulLeaveSiteCnt > maxTaskRegion2)
			{
				binaryWriter_0.Write(maxTaskRegion2);
			}
			else
			{
				binaryWriter_0.Write(m_ulLeaveSiteCnt);
			}
		}
		else if (m_pLeaveSite.Length != 0)
		{
			Task_Region.Write(int_243, binaryWriter_0, m_pLeaveSite[0]);
		}
		else
		{
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
			binaryWriter_0.Write(0);
		}
		binaryWriter_0.Write(m_ulLeaveSiteId);
	}

	private void method_92(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 59)
		{
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bFinNeedComp);
			}
			binaryWriter_0.Write(m_nFinExp1AndOrExp2);
			COMPARE_KEY_VALUE.Write(int_243, binaryWriter_0, m_Fin1KeyValue);
			COMPARE_KEY_VALUE.Write(int_243, binaryWriter_0, m_Fin2KeyValue);
		}
		if (int_243 >= 178)
		{
			binaryWriter_0.Write(m_nFinPersonExp1AndOrExp2);
			COMPARE_KEY_VALUE.Write(int_243, binaryWriter_0, m_Fin1PersonKeyValue);
			COMPARE_KEY_VALUE.Write(int_243, binaryWriter_0, m_Fin2PersonKeyValue);
		}
		if (int_243 >= 185)
		{
			binaryWriter_0.Write(m_nFinHistoryExp1AndOrExp2);
			COMPARE_KEY_VALUE.Write(int_243, binaryWriter_0, m_Fin1HistoryKeyValue);
			COMPARE_KEY_VALUE.Write(int_243, binaryWriter_0, m_Fin2HistoryKeyValue);
		}
	}

	private void method_93(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 63)
		{
			binaryWriter_0.Write(m_ulExpCnt);
			if (int_243 < 176)
			{
				binaryWriter_0.Write(m_pszExpPointer);
				binaryWriter_0.Write(m_pExpArrPointer);
			}
		}
		if (int_243 >= 178)
		{
			binaryWriter_0.Write(m_ulPersonExpCnt);
		}
		if (int_243 >= 185)
		{
			binaryWriter_0.Write(m_ulHistoryExpCnt);
		}
	}

	private void method_94(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 63)
		{
			binaryWriter_0.Write(m_ulTaskCharCnt);
			if (int_243 < 176)
			{
				binaryWriter_0.Write(m_pTaskCharPointer);
			}
		}
		if (int_243 >= 178)
		{
			binaryWriter_0.Write(m_ulPersonTaskCharCnt);
		}
		if (int_243 >= 185)
		{
			binaryWriter_0.Write(m_ulHistoryTaskCharCnt);
		}
	}

	private void method_95(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 104)
		{
			binaryWriter_0.Write(m_ucTransformedForm);
		}
		if (int_243 >= 215)
		{
			binaryWriter_0.Write(m_ulMonsterShapeID);
		}
		if (int_243 >= 156 && int_243 < 175)
		{
			binaryWriter_0.Write(TransformedDescID);
		}
		if (int_243 >= 113)
		{
			binaryWriter_0.Write(m_ulReachLevel);
			binaryWriter_0.Write(m_ulReachReincarnationCount);
			binaryWriter_0.Write(m_ulReachRealmLevel);
			binaryWriter_0.Write(m_uiEmotion);
		}
		if (int_243 >= 153)
		{
			binaryWriter_0.Write(m_ulGrowthTarget);
		}
	}

	private void method_96(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 223)
		{
			binaryWriter_0.Write(m_uSpecialMethodType);
			binaryWriter_0.Write(m_uSpecialMethodParm1);
			binaryWriter_0.Write(m_uSpecialMethodParm2);
			binaryWriter_0.Write(m_uSpecialMethodParm3);
			binaryWriter_0.Write(m_uSpecialMethodNpcServicesCount);
			binaryWriter_0.Write(m_uSpecialMethodNpcServicesLeastLeastCount);
			binaryWriter_0.Write(m_uSpecialMethodTargetTaskCount);
			binaryWriter_0.Write(m_uSpecialMethodTargetTaskLeastCount);
		}
	}

	private void method_97(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 122)
		{
			binaryWriter_0.Write(m_ulTMIconStateID);
		}
		if (int_243 >= 156 && int_243 < 175)
		{
			binaryWriter_0.Write(TMIconStateDescID);
		}
		if (int_243 >= 127)
		{
			binaryWriter_0.Write(m_ulTMHomeLevelType);
		}
		if (int_243 >= 126)
		{
			binaryWriter_0.Write(m_ulTMReachHomeLevel);
			binaryWriter_0.Write(m_ulTMReachHomeFlourish);
			binaryWriter_0.Write(m_ulHomeItemsWanted);
			if (int_243 < 176)
			{
				binaryWriter_0.Write(m_HomeItemsWantedPointer);
			}
		}
		if (int_243 >= 135)
		{
			binaryWriter_0.Write(m_ulBindOnCarrierId);
			if (int_243 >= 140)
			{
				binaryWriter_0.Write(Convert.ToInt16(m_ulTMReachArenaCount));
			}
			else
			{
				binaryWriter_0.Write(m_ulTMReachArenaCount);
			}
		}
		if (int_243 >= 137)
		{
			if (int_243 >= 140)
			{
				binaryWriter_0.Write(Convert.ToInt16(m_ulTMReachArenaWinCount));
			}
			else
			{
				binaryWriter_0.Write(m_ulTMReachArenaWinCount);
			}
		}
		if (int_243 >= 215)
		{
			binaryWriter_0.Write(m_ulTransmitPointID);
		}
		if (int_243 >= 156)
		{
			GlobalFunctions.WriteNameChars(binaryWriter_0, m_szShowDialogName);
		}
		if (int_243 >= 167)
		{
			binaryWriter_0.Write(m_iTriggerEvent);
		}
		if (int_243 >= 175)
		{
			binaryWriter_0.Write(m_iVerifyStateLayer);
			binaryWriter_0.Write(m_ulVerifyStateLayerID);
			binaryWriter_0.Write(m_iKeyWordIndex);
		}
	}

	private void method_98(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 194)
		{
			binaryWriter_0.Write(camera_pos_x);
			binaryWriter_0.Write(camera_pos_y);
			binaryWriter_0.Write(camera_pos_z);
			binaryWriter_0.Write(camera_quat_x);
			binaryWriter_0.Write(camera_quat_y);
			binaryWriter_0.Write(camera_quat_z);
			binaryWriter_0.Write(camera_quat_a);
			binaryWriter_0.Write(camera_target_pos_x);
			binaryWriter_0.Write(camera_target_pos_y);
			binaryWriter_0.Write(camera_target_pos_z);
			binaryWriter_0.Write(camera_target_quat_x);
			binaryWriter_0.Write(camera_target_quat_y);
			binaryWriter_0.Write(camera_target_quat_z);
			binaryWriter_0.Write(camera_target_quat_a);
			binaryWriter_0.Write(camera_rotate_axis);
			binaryWriter_0.Write(camera_rotate_angle);
			binaryWriter_0.Write(camera_take_seconds);
		}
		if (int_243 >= 215)
		{
			binaryWriter_0.Write(m_ulSubmitItemWantedNum);
		}
		if (int_243 >= 228)
		{
			binaryWriter_0.Write(m_ulDailyActivityValue);
		}
	}

	private void method_99(int int_243, BinaryWriter binaryWriter_0)
	{
		binaryWriter_0.Write(m_ulAwardType_S);
		binaryWriter_0.Write(m_ulAwardType_F);
		if (int_243 < 176)
		{
			binaryWriter_0.Write(m_Award_SPointer);
			binaryWriter_0.Write(m_Award_FPointer);
			binaryWriter_0.Write(m_AwByRatio_SPointer);
			binaryWriter_0.Write(m_AwByRatio_FPointer);
			binaryWriter_0.Write(m_AwByItems_SPointer);
			binaryWriter_0.Write(m_AwByItems_FPointer);
			if (int_243 >= 140)
			{
				binaryWriter_0.Write(AwByTaskEventRatio_SPointer);
				binaryWriter_0.Write(AwByTaskEventRatio_FPointer);
			}
			if (int_243 >= 146)
			{
				binaryWriter_0.Write(AwByCarrierHp_SPointer);
				binaryWriter_0.Write(AwByCarrierHp_FPointer);
			}
			if (int_243 >= 161)
			{
				binaryWriter_0.Write(AwByVar_SPointer);
				binaryWriter_0.Write(AwByVar_FPointer);
			}
		}
		binaryWriter_0.Write(m_ulParent);
		binaryWriter_0.Write(m_ulPrevSibling);
		binaryWriter_0.Write(m_ulNextSibling);
		binaryWriter_0.Write(m_ulFirstChild);
		if (int_243 >= 83)
		{
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bIsLibraryTask);
			}
			binaryWriter_0.Write(m_fLibraryTasksProbability);
		}
		if (int_243 >= 95 && int_243 < 135)
		{
			binaryWriter_0.Write(m_bIsUniqueStorageTask);
		}
		if (int_243 >= 119)
		{
			binaryWriter_0.Write(m_iWorldContribution);
		}
		if (int_243 >= 215)
		{
			binaryWriter_0.Write(m_iMaskDisableIcon);
		}
	}

	private void method_100(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 135)
		{
			byte[] array = new byte[GlobalFunctions.GetCombinedSwitches(int_243)];
			GlobalFunctions.SetParam(int_243, array, 0, m_bShowByTransformed);
			GlobalFunctions.SetParam(int_243, array, 1, m_bShowByLev);
			GlobalFunctions.SetParam(int_243, array, 2, m_bPremCheckReincarnation);
			GlobalFunctions.SetParam(int_243, array, 3, m_bShowByReincarnation);
			GlobalFunctions.SetParam(int_243, array, 4, m_bPremCheckRealmLevel);
			GlobalFunctions.SetParam(int_243, array, 5, m_bPremCheckRealmExpFull);
			if (int_243 >= 232)
			{
				GlobalFunctions.SetParam(int_243, array, 6, m_bCheckTradeTime);
				GlobalFunctions.SetParam(int_243, array, 7, m_bShowByTradeTime);
			}
			GlobalFunctions.SetParam(int_243, array, 8, m_bShowByRealmLevel);
			GlobalFunctions.SetParam(int_243, array, 9, m_bShowByItems);
			GlobalFunctions.SetParam(int_243, array, 10, m_bPremItemsAnyOne);
			if (int_243 >= 215)
			{
				GlobalFunctions.SetParam(int_243, array, 11, m_bMethodItemsRandOne);
			}
			GlobalFunctions.SetParam(int_243, array, 12, m_bNotOpenWithItem);
			GlobalFunctions.SetParam(int_243, array, 13, m_bShowByDeposit);
			GlobalFunctions.SetParam(int_243, array, 14, m_bShowByRepu);
			GlobalFunctions.SetParam(int_243, array, 15, m_bShowByPreTask);
			GlobalFunctions.SetParam(int_243, array, 16, m_bShowByPeriod);
			GlobalFunctions.SetParam(int_243, array, 17, m_bShowByFaction);
			GlobalFunctions.SetParam(int_243, array, 18, m_bShowByGender);
			GlobalFunctions.SetParam(int_243, array, 19, m_bShowByOccup);
			GlobalFunctions.SetParam(int_243, array, 20, m_bPremise_Spouse);
			GlobalFunctions.SetParam(int_243, array, 21, m_bShowBySpouse);
			GlobalFunctions.SetParam(int_243, array, 22, m_bPremiseWeddingOwner);
			GlobalFunctions.SetParam(int_243, array, 23, m_bShowByWeddingOwner);
			GlobalFunctions.SetParam(int_243, array, 24, m_bGM);
			GlobalFunctions.SetParam(int_243, array, 25, m_bShieldUser);
			GlobalFunctions.SetParam(int_243, array, 26, m_bShowByRMB);
			GlobalFunctions.SetParam(int_243, array, 27, m_bCharTime);
			GlobalFunctions.SetParam(int_243, array, 28, m_bShowByCharTime);
			GlobalFunctions.SetParam(int_243, array, 29, m_bTeamwork);
			GlobalFunctions.SetParam(int_243, array, 30, m_bRcvByTeam);
			GlobalFunctions.SetParam(int_243, array, 31, m_bSharedTask);
			GlobalFunctions.SetParam(int_243, array, 32, m_bSharedAchieved);
			GlobalFunctions.SetParam(int_243, array, 33, m_bCheckTeammate);
			GlobalFunctions.SetParam(int_243, array, 34, m_bAllFail);
			GlobalFunctions.SetParam(int_243, array, 35, m_bCapFail);
			GlobalFunctions.SetParam(int_243, array, 36, m_bCapSucc);
			GlobalFunctions.SetParam(int_243, array, 37, m_bDismAsSelfFail);
			GlobalFunctions.SetParam(int_243, array, 38, m_bRcvChckMem);
			GlobalFunctions.SetParam(int_243, array, 39, m_bCntByMemPos);
			GlobalFunctions.SetParam(int_243, array, 40, m_bAllSucc);
			GlobalFunctions.SetParam(int_243, array, 41, m_bCoupleOnly);
			GlobalFunctions.SetParam(int_243, array, 42, m_bDistinguishedOcc);
			GlobalFunctions.SetParam(int_243, array, 43, m_bShowByTeam);
			GlobalFunctions.SetParam(int_243, array, 44, m_bPremNeedComp);
			if (int_243 >= 178)
			{
				GlobalFunctions.SetParam(int_243, array, 45, m_bPremPersonNeedComp);
			}
			if (int_243 >= 185)
			{
				GlobalFunctions.SetParam(int_243, array, 46, m_bPremHistoryNeedComp);
			}
			GlobalFunctions.SetParam(int_243, array, 47, m_bPremCheckForce);
			GlobalFunctions.SetParam(int_243, array, 48, m_bShowByForce);
			GlobalFunctions.SetParam(int_243, array, 49, m_bShowByForceReputation);
			GlobalFunctions.SetParam(int_243, array, 50, m_bShowByForceContribution);
			GlobalFunctions.SetParam(int_243, array, 51, m_bShowByForceExp);
			GlobalFunctions.SetParam(int_243, array, 52, m_bShowByForceSP);
			GlobalFunctions.SetParam(int_243, array, 53, m_bShowByForceActivityLevel);
			GlobalFunctions.SetParam(int_243, array, 54, m_bPremIsKing);
			GlobalFunctions.SetParam(int_243, array, 55, m_bShowByKing);
			GlobalFunctions.SetParam(int_243, array, 56, m_bPremNotInTeam);
			GlobalFunctions.SetParam(int_243, array, 57, m_bShowByNotInTeam);
			GlobalFunctions.SetParam(int_243, array, 58, m_bShowByTitle);
			GlobalFunctions.SetParam(int_243, array, 59, m_bShowByHistoryStage);
			GlobalFunctions.SetParam(int_243, array, 60, m_bShowByGeneralCard);
			GlobalFunctions.SetParam(int_243, array, 61, m_bShowByGeneralCardRank);
			GlobalFunctions.SetParam(int_243, array, 62, m_bShowByIconStateID);
			GlobalFunctions.SetParam(int_243, array, 63, m_bShowByVIPLevel);
			GlobalFunctions.SetParam(int_243, array, 64, m_bPremNoHome);
			GlobalFunctions.SetParam(int_243, array, 65, m_bShowByHomeLevel);
			GlobalFunctions.SetParam(int_243, array, 66, m_bShowByHomeResourceLevel);
			GlobalFunctions.SetParam(int_243, array, 67, m_bShowByHomeFactoryLevel);
			GlobalFunctions.SetParam(int_243, array, 68, m_bShowByHomeFlourish);
			GlobalFunctions.SetParam(int_243, array, 69, m_bPremHomeStorageTask);
			GlobalFunctions.SetParam(int_243, array, 70, m_bShowByHomeStorageTask);
			GlobalFunctions.SetParam(int_243, array, 71, m_bMonsterTotalCount);
			if (int_243 >= 195)
			{
				GlobalFunctions.SetParam(int_243, array, 72, m_bDoNotShowGfx);
			}
			GlobalFunctions.SetParam(int_243, array, 73, m_bFinNeedComp);
			if (int_243 >= 178)
			{
				GlobalFunctions.SetParam(int_243, array, 74, m_bFinPersonNeedComp);
			}
			if (int_243 >= 185)
			{
				GlobalFunctions.SetParam(int_243, array, 75, m_bFinHistoryNeedComp);
			}
			GlobalFunctions.SetParam(int_243, array, 76, m_bIsLibraryTask);
			GlobalFunctions.SetParam(int_243, array, 77, m_bIsUniqueStorageTask);
			GlobalFunctions.SetParam(int_243, array, 78, m_bHasSign);
			GlobalFunctions.SetParam(int_243, array, 79, m_bOfflineFail);
			GlobalFunctions.SetParam(int_243, array, 80, m_bItemNotTakeOff);
			GlobalFunctions.SetParam(int_243, array, 81, m_bAbsTime);
			if (int_243 >= 180)
			{
				GlobalFunctions.SetParam(int_243, array, 82, m_bMultiNpcTalk);
			}
			GlobalFunctions.SetParam(int_243, array, 83, m_bChooseOne);
			GlobalFunctions.SetParam(int_243, array, 84, m_bRandOne);
			GlobalFunctions.SetParam(int_243, array, 85, m_bExeChildInOrder);
			GlobalFunctions.SetParam(int_243, array, 86, m_bParentAlsoFail);
			GlobalFunctions.SetParam(int_243, array, 87, m_bParentAlsoSucc);
			GlobalFunctions.SetParam(int_243, array, 88, m_bCanGiveUp);
			GlobalFunctions.SetParam(int_243, array, 89, m_bCanRedo);
			GlobalFunctions.SetParam(int_243, array, 90, m_bCanRedoAfterFailure);
			GlobalFunctions.SetParam(int_243, array, 91, m_bClearAsGiveUp);
			GlobalFunctions.SetParam(int_243, array, 92, m_bNeedRecord);
			GlobalFunctions.SetParam(int_243, array, 93, m_bFailAsPlayerDie);
			GlobalFunctions.SetParam(int_243, array, 94, m_bDelvInZone);
			GlobalFunctions.SetParam(int_243, array, 95, m_bEnterRegionFail);
			GlobalFunctions.SetParam(int_243, array, 96, m_bLeaveRegionFail);
			GlobalFunctions.SetParam(int_243, array, 97, m_bLeaveForceFail);
			GlobalFunctions.SetParam(int_243, array, 98, m_bTransTo);
			GlobalFunctions.SetParam(int_243, array, 99, m_bTrigCtrl);
			GlobalFunctions.SetParam(int_243, array, 100, m_bAutoDeliver);
			if (int_243 >= 240)
			{
				GlobalFunctions.SetParam(int_243, array, 101, m_bAutoDeliverHighPriority);
			}
			GlobalFunctions.SetParam(int_243, array, 102, m_bDisplayInExclusiveUI);
			GlobalFunctions.SetParam(int_243, array, 103, m_bReadyToNotifyServer);
			GlobalFunctions.SetParam(int_243, array, 104, m_bUsedInTokenShop);
			GlobalFunctions.SetParam(int_243, array, 105, m_bDeathTrig);
			GlobalFunctions.SetParam(int_243, array, 106, m_bClearAcquired);
			GlobalFunctions.SetParam(int_243, array, 107, m_bShowPrompt);
			GlobalFunctions.SetParam(int_243, array, 108, m_bKeyTask);
			GlobalFunctions.SetParam(int_243, array, 109, m_bSkillTask);
			GlobalFunctions.SetParam(int_243, array, 110, m_bCanSeekOut);
			GlobalFunctions.SetParam(int_243, array, 111, m_bShowDirection);
			GlobalFunctions.SetParam(int_243, array, 112, m_bMarriage);
			GlobalFunctions.SetParam(int_243, array, 113, m_bSwitchSceneFail);
			GlobalFunctions.SetParam(int_243, array, 114, m_bHidden);
			GlobalFunctions.SetParam(int_243, array, 115, m_bDeliverySkill);
			GlobalFunctions.SetParam(int_243, array, 116, m_bShowGfxFinished);
			GlobalFunctions.SetParam(int_243, array, 117, m_bChangePQRanking);
			GlobalFunctions.SetParam(int_243, array, 118, m_bCompareItemAndInventory);
			GlobalFunctions.SetParam(int_243, array, 119, m_bTowerTask);
			GlobalFunctions.SetParam(int_243, array, 120, m_bHomeTask);
			GlobalFunctions.SetParam(int_243, array, 121, m_bDeliverInHostHome);
			GlobalFunctions.SetParam(int_243, array, 122, m_bFinishInHostHome);
			GlobalFunctions.SetParam(int_243, array, 123, m_bPQTask);
			GlobalFunctions.SetParam(int_243, array, 124, m_bPQSubTask);
			GlobalFunctions.SetParam(int_243, array, 125, m_bClearContrib);
			GlobalFunctions.SetParam(int_243, array, 126, m_bShowByNeedRecordTasksNum);
			GlobalFunctions.SetParam(int_243, array, 127, m_bShowByFactionContrib);
			GlobalFunctions.SetParam(int_243, array, 128, m_bAccountTaskLimit);
			GlobalFunctions.SetParam(int_243, array, 129, m_bRoleTaskLimit);
			GlobalFunctions.SetParam(int_243, array, 130, m_bLeaveFactionFail);
			GlobalFunctions.SetParam(int_243, array, 131, m_bNotIncCntWhenFailed);
			GlobalFunctions.SetParam(int_243, array, 132, m_bNotClearItemWhenFailed);
			GlobalFunctions.SetParam(int_243, array, 133, m_bDisplayInTitleTaskUI);
			GlobalFunctions.SetParam(int_243, array, 134, m_bCanAwardOnCarrier);
			if (int_243 >= 137)
			{
				GlobalFunctions.SetParam(int_243, array, 135, m_bPremReachArenaWinCount);
				GlobalFunctions.SetParam(int_243, array, 136, m_bShowByReachArenaWinCount);
			}
			if (int_243 >= 140)
			{
				GlobalFunctions.SetParam(int_243, array, 137, m_bWriteSpecialLog);
			}
			if (int_243 >= 146)
			{
				GlobalFunctions.SetParam(int_243, array, 138, m_bShowByFactionScore);
				GlobalFunctions.SetParam(int_243, array, 139, m_bShowByFactionMoney);
				GlobalFunctions.SetParam(int_243, array, 140, m_bShowByFactionPersonScore);
				GlobalFunctions.SetParam(int_243, array, 141, m_bCheckFactionMember);
				GlobalFunctions.SetParam(int_243, array, 142, m_bPremFaction);
				GlobalFunctions.SetParam(int_243, array, 143, m_bSpecialLogic);
			}
			if (int_243 >= 153)
			{
				GlobalFunctions.SetParam(int_243, array, 144, m_bBecomeMentor);
				GlobalFunctions.SetParam(int_243, array, 145, m_bShowMentorMorality);
				GlobalFunctions.SetParam(int_243, array, 146, m_bShowMentorStudentValue);
				GlobalFunctions.SetParam(int_243, array, 147, m_bDiscardedTask);
				GlobalFunctions.SetParam(int_243, array, 148, m_bNoCheckTitleGot);
			}
			if (int_243 >= 156)
			{
				GlobalFunctions.SetParam(int_243, array, 149, m_bShowCoupleIntimacy);
			}
			if (int_243 >= 158)
			{
				GlobalFunctions.SetParam(int_243, array, 150, m_bShowDeposit2);
			}
			if (int_243 >= 194)
			{
				GlobalFunctions.SetParam(int_243, array, 151, m_bCrossServer);
			}
			if (int_243 >= 163)
			{
				GlobalFunctions.SetParam(int_243, array, 152, m_bRecordFnshCnt);
			}
			if (int_243 >= 198)
			{
				GlobalFunctions.SetParam(int_243, array, 153, m_bRecordReset);
			}
			if (int_243 >= 167)
			{
				GlobalFunctions.SetParam(int_243, array, 154, m_bShowCamp);
				GlobalFunctions.SetParam(int_243, array, 155, m_bShowCampPower);
				GlobalFunctions.SetParam(int_243, array, 156, m_bReturnCampPower);
				GlobalFunctions.SetParam(int_243, array, 157, m_bTeamHaveRecaller);
				GlobalFunctions.SetParam(int_243, array, 158, m_bBindedRecaller);
				GlobalFunctions.SetParam(int_243, array, 159, m_bShowNeedFriendPoint);
			}
			if (int_243 >= 175)
			{
				GlobalFunctions.SetParam(int_243, array, 160, m_bHistoryVarTask);
				GlobalFunctions.SetParam(int_243, array, 161, m_bRankPre);
				GlobalFunctions.SetParam(int_243, array, 162, m_bDeliverByUI);
			}
			if (int_243 >= 177)
			{
				GlobalFunctions.SetParam(int_243, array, 163, m_bWarTaskAward);
			}
			if (int_243 >= 180)
			{
				GlobalFunctions.SetParam(int_243, array, 164, m_bHideOtherPlayer);
			}
			if (int_243 >= 187)
			{
				GlobalFunctions.SetParam(int_243, array, 165, m_bRecordDeliverTime);
			}
			if (int_243 >= 194)
			{
				GlobalFunctions.SetParam(int_243, array, 166, m_bShowMethod);
			}
			if (int_243 >= 198)
			{
				GlobalFunctions.SetParam(int_243, array, 167, m_bPremCheckPanguLevel);
				GlobalFunctions.SetParam(int_243, array, 168, m_bShowAchievementSeriesId);
				GlobalFunctions.SetParam(int_243, array, 169, m_bVaguePromptingMode);
			}
			if (int_243 >= 215)
			{
				GlobalFunctions.SetParam(int_243, array, 170, m_bCheckPanguEquip);
				GlobalFunctions.SetParam(int_243, array, 171, m_bShowPanguEquipPremise);
				GlobalFunctions.SetParam(int_243, array, 172, m_bShowExploreIcon);
			}
			if (int_243 >= 234)
			{
				GlobalFunctions.SetParam(int_243, array, 173, m_bShowByExpNotFull);
			}
			if (int_243 >= 218)
			{
				GlobalFunctions.SetParam(int_243, array, 174, m_bCheckInventorySize);
				GlobalFunctions.SetParam(int_243, array, 175, m_bCheckStorageSize);
				GlobalFunctions.SetParam(int_243, array, 176, m_bShowPackSizePremise);
			}
			if (int_243 >= 234)
			{
				GlobalFunctions.SetParam(int_243, array, 177, m_bShowByRealmExpNotFull);
				GlobalFunctions.SetParam(int_243, array, 178, m_bAllowBatchAward);
			}
			if (int_243 >= 223)
			{
				GlobalFunctions.SetParam(int_243, array, 179, m_bCheckExp);
				GlobalFunctions.SetParam(int_243, array, 180, m_bCheckRealmExp);
				GlobalFunctions.SetParam(int_243, array, 181, m_bShowPropertyPremis);
				GlobalFunctions.SetParam(int_243, array, 182, m_bCheckLieMoLevel);
				GlobalFunctions.SetParam(int_243, array, 183, m_bCheckYuMoLevel);
			}
			if (int_243 >= 229)
			{
				GlobalFunctions.SetParam(int_243, array, 184, m_bShowDailyActivityPremise);
			}
			if (int_243 >= 236)
			{
				GlobalFunctions.SetParam(int_243, array, 185, m_bFailIconStateID);
			}
			if (int_243 >= 238)
			{
				GlobalFunctions.SetParam(int_243, array, 186, m_bPremTotalItemsWanted);
				GlobalFunctions.SetParam(int_243, array, 187, m_bMethodTotalItemsWanted);
			}
			binaryWriter_0.Write(array);
		}
	}

	private void method_101(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 == 139)
		{
			binaryWriter_0.Write(m_bWriteSpecialLog);
		}
		if (int_243 >= 146)
		{
			int num = 0;
			for (int i = 0; i < SpecialParameters.ParameterTypes.Length; i++)
			{
				if (SPECIAL_PARAMETERS.CheckParameter(int_243, SpecialParameters.ParameterTypes[i]))
				{
					num++;
				}
			}
			binaryWriter_0.Write(num);
			if (int_243 < 176)
			{
				binaryWriter_0.Write(SpecialParametersPointer);
			}
		}
		if (m_bHasSign)
		{
			GlobalFunctions.WriteNameChars(binaryWriter_0, m_pszSignature);
		}
	}

	private void method_102(int int_243, BinaryWriter binaryWriter_0)
	{
		int maxTimetableSize = GlobalFunctions.GetMaxTimetableSize(int_243);
		for (int i = 0; i < m_ulTimetable && i < maxTimetableSize; i++)
		{
			task_tm.Write(int_243, binaryWriter_0, m_tmStart[i]);
			task_tm.Write(int_243, binaryWriter_0, m_tmEnd[i]);
		}
	}

	private void method_103(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 59)
		{
			for (int i = 0; i < m_ulChangeKeyCnt; i++)
			{
				binaryWriter_0.Write(m_plChangeKey[i]);
				binaryWriter_0.Write(m_plChangeKeyValue[i]);
				if (int_243 >= 215)
				{
					binaryWriter_0.Write(m_plChangeKeyValue2[i]);
				}
				binaryWriter_0.Write(m_pbChangeType[i]);
			}
		}
		if (int_243 >= 178)
		{
			for (int j = 0; j < m_ulChangePersonKeyCnt; j++)
			{
				binaryWriter_0.Write(m_plPersonChangeKey[j]);
				binaryWriter_0.Write(m_plPersonChangeKeyValue[j]);
				if (int_243 >= 215)
				{
					binaryWriter_0.Write(m_plPersonChangeKeyValue2[j]);
				}
				binaryWriter_0.Write(m_pbPersonChangeType[j]);
			}
		}
		if (int_243 < 185)
		{
			return;
		}
		for (int k = 0; k < m_ulChangeHistoryKeyCnt; k++)
		{
			binaryWriter_0.Write(m_plHistoryChangeKey[k]);
			binaryWriter_0.Write(m_plHistoryChangeKeyValue[k]);
			if (int_243 >= 215)
			{
				binaryWriter_0.Write(m_plHistoryChangeKeyValue2[k]);
			}
			binaryWriter_0.Write(m_pbHistoryChangeType[k]);
		}
	}

	private void method_104(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 75)
		{
			for (int i = 0; i < m_ulPQExpCnt; i++)
			{
				GlobalFunctions.WriteChars(binaryWriter_0, m_pszPQExp[i]);
				for (int j = 0; j < m_pPQExpArr[i].Length; j++)
				{
					TASK_EXPRESSION.Write(int_243, binaryWriter_0, m_pPQExpArr[i][j]);
				}
			}
			for (int k = 0; k < m_ulMonsterContribCnt; k++)
			{
				MONSTERS_CONTRIB.Write(int_243, binaryWriter_0, m_MonstersContrib[k]);
			}
		}
		if (int_243 >= 182 && m_ulPropSummonedMonsters > 0)
		{
			AWARD_MONSTERS_SUMMONED.Write3(int_243, binaryWriter_0, PropMonsterSummoned);
		}
	}

	private void method_105(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 80)
		{
			int maxTaskRegion = GlobalFunctions.GetMaxTaskRegion(int_243);
			for (int i = 0; i < m_ulDelvRegionCnt && i < maxTaskRegion; i++)
			{
				Task_Region.Write(int_243, binaryWriter_0, m_pDelvRegion[i]);
			}
			int maxTaskRegion2 = GlobalFunctions.GetMaxTaskRegion(int_243);
			for (int j = 0; j < m_ulEnterRegionCnt && j < maxTaskRegion2; j++)
			{
				Task_Region.Write(int_243, binaryWriter_0, m_pEnterRegion[j]);
			}
			int maxTaskRegion3 = GlobalFunctions.GetMaxTaskRegion(int_243);
			for (int k = 0; k < m_ulLeaveRegionCnt && k < maxTaskRegion3; k++)
			{
				Task_Region.Write(int_243, binaryWriter_0, m_pLeaveRegion[k]);
			}
		}
		if (int_243 >= 215)
		{
			for (int l = 0; l < m_ulVaguePromptNumbers; l++)
			{
				VAGUE_PROMPT_INFO.Write(int_243, binaryWriter_0, m_pVaguePromptInfo[l]);
			}
		}
	}

	private void method_106(int int_243, BinaryWriter binaryWriter_0)
	{
		for (int i = 0; i < m_ulPremItems; i++)
		{
			ITEM_WANTED.Write(int_243, binaryWriter_0, m_PremItems[i]);
		}
		for (int j = 0; j < m_ulGivenItems; j++)
		{
			ITEM_WANTED.Write(int_243, binaryWriter_0, m_GivenItems[j]);
		}
		for (int k = 0; k < m_ulTeamMemsWanted; k++)
		{
			TEAM_MEM_WANTED.Write(int_243, binaryWriter_0, m_TeamMemsWanted[k]);
		}
		if (int_243 >= 109)
		{
			for (int l = 0; l < m_iPremTitleNumTotal; l++)
			{
				binaryWriter_0.Write(m_PremTitles[l]);
			}
		}
		if (int_243 >= 227)
		{
			for (int m = 0; m < m_ulChangeSceneRemoveItemRegionNum; m++)
			{
				ITEM_WANTED.Write(int_243, binaryWriter_0, m_pChangeSceneRemoveItemRegionNum[m]);
			}
			for (int n = 0; n < m_ulChangeSceneRemoveNum; n++)
			{
				Task_Region.Write(int_243, binaryWriter_0, m_pChangeSceneRemoveNum[n]);
			}
		}
	}

	private void method_107(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 195)
		{
			for (int i = 0; i < GlobalFunctions.GetMaxMonsterUnwanted(int_243, m_ulMonsterUnwanted); i++)
			{
				MONSTER_WANTED.Write(int_243, binaryWriter_0, m_MonsterUnwanted[i]);
			}
		}
		int maxMonsterWanted = GlobalFunctions.GetMaxMonsterWanted(int_243);
		for (int j = 0; j < m_ulMonsterWanted && j < maxMonsterWanted; j++)
		{
			MONSTER_WANTED.Write(int_243, binaryWriter_0, m_MonsterWanted[j]);
		}
		if (int_243 >= 103)
		{
			int maxPlayerWanted = GlobalFunctions.GetMaxPlayerWanted(int_243);
			for (int k = 0; k < m_ulPlayerWanted && k < maxPlayerWanted; k++)
			{
				PLAYER_WANTED.Write(int_243, binaryWriter_0, m_PlayerWanted[k]);
			}
		}
		for (int l = 0; l < m_ulItemsWanted; l++)
		{
			ITEM_WANTED.Write(int_243, binaryWriter_0, m_ItemsWanted[l]);
		}
	}

	private void method_108(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 215)
		{
			for (int i = 0; i < m_ulSubmitItemWantedNum; i++)
			{
				ITEM_WANTED.Write(int_243, binaryWriter_0, m_pSubmitItemWanted[i]);
			}
		}
		if (int_243 >= 223)
		{
			for (int j = 0; j < m_uSpecialMethodNpcServicesCount; j++)
			{
				TSMNPCServices.Write(int_243, binaryWriter_0, m_pTSMNPCServices[j]);
			}
			for (int k = 0; k < m_uSpecialMethodTargetTaskCount; k++)
			{
				TSMTargetTask.Write(int_243, binaryWriter_0, m_pTSMTargetTask[k]);
			}
		}
	}

	private void method_109(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 63)
		{
			for (int i = 0; i < m_ulExpCnt; i++)
			{
				GlobalFunctions.WriteChars(binaryWriter_0, m_pszExp[i]);
				for (int j = 0; j < m_pExpArr[i].Length; j++)
				{
					TASK_EXPRESSION.Write(int_243, binaryWriter_0, m_pExpArr[i][j]);
				}
			}
			for (int k = 0; k < m_ulTaskCharCnt; k++)
			{
				GlobalFunctions.WriteNameChars(binaryWriter_0, m_pTaskChar[k]);
			}
		}
		if (int_243 >= 178)
		{
			for (int l = 0; l < m_ulPersonExpCnt; l++)
			{
				GlobalFunctions.WriteChars(binaryWriter_0, PersonExp[l]);
				for (int m = 0; m < PersonExpArr[l].Length; m++)
				{
					TASK_EXPRESSION.Write(int_243, binaryWriter_0, PersonExpArr[l][m]);
				}
			}
			for (int n = 0; n < m_ulPersonTaskCharCnt; n++)
			{
				GlobalFunctions.WriteNameChars(binaryWriter_0, PersonTaskChar[n]);
			}
		}
		if (int_243 < 185)
		{
			return;
		}
		for (int num = 0; num < m_ulHistoryExpCnt; num++)
		{
			GlobalFunctions.WriteChars(binaryWriter_0, HistoryExp[num]);
			for (int num2 = 0; num2 < HistoryExpArr[num].Length; num2++)
			{
				TASK_EXPRESSION.Write(int_243, binaryWriter_0, HistoryExpArr[num][num2]);
			}
		}
		for (int num3 = 0; num3 < m_ulHistoryTaskCharCnt; num3++)
		{
			GlobalFunctions.WriteNameChars(binaryWriter_0, HistoryTaskChar[num3]);
		}
	}

	private void method_110(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 80)
		{
			int maxTaskRegion = GlobalFunctions.GetMaxTaskRegion(int_243);
			for (int i = 0; i < m_ulReachSiteCnt && i < maxTaskRegion; i++)
			{
				Task_Region.Write(int_243, binaryWriter_0, m_pReachSite[i]);
			}
			int maxTaskRegion2 = GlobalFunctions.GetMaxTaskRegion(int_243);
			for (int j = 0; j < m_ulLeaveSiteCnt && j < maxTaskRegion2; j++)
			{
				Task_Region.Write(int_243, binaryWriter_0, m_pLeaveSite[j]);
			}
		}
	}

	private void method_111(int int_243, BinaryWriter binaryWriter_0)
	{
	}

	private void method_112(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 126)
		{
			for (int i = 0; i < m_ulHomeItemsWanted; i++)
			{
				HOME_ITEM_WANTED.Write(int_243, binaryWriter_0, m_HomeItemsWanted[i]);
			}
		}
	}

	private void method_113(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 140)
		{
			for (int i = 0; i < m_usTaskEventMonsterCount; i++)
			{
				TaskEventData.Write(int_243, binaryWriter_0, TaskEventMonsterData[i]);
			}
			for (int j = 0; j < m_usTaskEventMineCount; j++)
			{
				TaskEventData.Write(int_243, binaryWriter_0, TaskEventMineData[j]);
			}
			for (int k = 0; k < m_usTaskEventTaskCount; k++)
			{
				TaskEventData.Write(int_243, binaryWriter_0, TaskEventTaskData[k]);
			}
		}
	}

	private void method_114(int int_243, BinaryWriter binaryWriter_0)
	{
		AWARD_DATA.Write(int_243, binaryWriter_0, m_Award_S);
		AWARD_DATA.Write(int_243, binaryWriter_0, m_Award_F);
		AWARD_RATIO_SCALE.Write(int_243, binaryWriter_0, m_AwByRatio_S);
		AWARD_RATIO_SCALE.Write(int_243, binaryWriter_0, m_AwByRatio_F);
		AWARD_ITEMS_SCALE.Write(int_243, binaryWriter_0, m_AwByItems_S);
		AWARD_ITEMS_SCALE.Write(int_243, binaryWriter_0, m_AwByItems_F);
		if (int_243 >= 140)
		{
			AWARD_RATIO_SCALE.Write(int_243, binaryWriter_0, AwByTaskEventRatio_S);
			AWARD_RATIO_SCALE.Write(int_243, binaryWriter_0, AwByTaskEventRatio_F);
		}
		if (int_243 >= 146)
		{
			AWARD_CARRIER_HP_SCALE.Write(int_243, binaryWriter_0, AwByCarrierHp_S);
			AWARD_CARRIER_HP_SCALE.Write(int_243, binaryWriter_0, AwByCarrierHp_F);
		}
		if (int_243 >= 161)
		{
			AWARD_VAR_SCALE.Write(int_243, binaryWriter_0, AwByVar_S);
			AWARD_VAR_SCALE.Write(int_243, binaryWriter_0, AwByVar_F);
		}
		if (int_243 >= 146)
		{
			SPECIAL_PARAMETERS.Write(int_243, binaryWriter_0, x_SpecialParametersCount, SpecialParameters, m_ID);
		}
	}

	private void method_115(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 < 135)
		{
			if (int_243 >= 52)
			{
				binaryWriter_0.Write(m_bGM);
			}
			if (int_243 >= 68)
			{
				binaryWriter_0.Write(m_bShieldUser);
			}
		}
		if (int_243 >= 75)
		{
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bShowByRMB);
			}
			binaryWriter_0.Write(m_ulPremRMBMin);
			binaryWriter_0.Write(m_ulPremRMBMax);
			if (int_243 < 135)
			{
				binaryWriter_0.Write(m_bCharTime);
				binaryWriter_0.Write(m_bShowByCharTime);
			}
			binaryWriter_0.Write(m_iCharStartTime);
			binaryWriter_0.Write(m_iCharEndTime);
			task_tm.Write(int_243, binaryWriter_0, m_tmCharEndTime);
			binaryWriter_0.Write(m_ulCharTimeGreaterThan);
		}
	}

	private void method_116(int int_243, BinaryWriter binaryWriter_0)
	{
		if (int_243 >= 140)
		{
			GlobalFunctions.WriteNameChars(binaryWriter_0, m_TaskEventName);
			binaryWriter_0.Write(m_TaskEventType);
			binaryWriter_0.Write(m_usTaskEventTimeOrScore);
			binaryWriter_0.Write(m_usTaskEventMonsterCount);
			if (int_243 < 176)
			{
				binaryWriter_0.Write(TaskEventMonsterDataPointer);
			}
			binaryWriter_0.Write(m_usTaskEventMineCount);
			if (int_243 < 176)
			{
				binaryWriter_0.Write(TaskEventMineDataPointer);
			}
			binaryWriter_0.Write(m_usTaskEventTaskCount);
			if (int_243 < 176)
			{
				binaryWriter_0.Write(TaskEventTaskDataPointer);
			}
		}
		if (int_243 >= 146)
		{
			binaryWriter_0.Write(m_FactionPersonScore);
		}
		if (int_243 >= 153)
		{
			binaryWriter_0.Write(m_iTinyGameType);
		}
		if (int_243 >= 215)
		{
			binaryWriter_0.Write(m_iSlotMachineType);
		}
		if (int_243 >= 158)
		{
			binaryWriter_0.Write(m_ulGoldWanted2);
		}
		if (int_243 >= 185)
		{
			binaryWriter_0.Write(m_chatGroupId);
		}
		if (int_243 >= 219)
		{
			binaryWriter_0.Write(m_HintConfigId);
		}
		if (int_243 >= 188)
		{
			binaryWriter_0.Write(m_iGuessStringID);
		}
	}
}
