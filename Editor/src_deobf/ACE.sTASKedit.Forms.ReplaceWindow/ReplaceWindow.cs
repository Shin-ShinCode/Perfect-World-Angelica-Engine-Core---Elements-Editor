using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;
using ACE.sTASKedit.Classes.Extensions;
using ACE.sTASKedit.Classes.GlobalProgramData;
using ACE.sTASKedit.MainEditor;
using ACE.sTASKedit.tasks;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Forms.ReplaceWindow;

public class ReplaceWindow : Form
{
	private ACE.sTASKedit.MainEditor.MainEditor mainEditor_0;

	private TreeNodeCollection treeNodeCollection_0;

	private string[] string_0;

	private string[] string_1;

	private int int_0;

	private IContainer icontainer_0;

	private TextBox textBox_0;

	private Button button_0;

	private RadioButton radioButton_0;

	private RadioButton radioButton_1;

	private ComboBox comboBox_0;

	private TextBox textBox_1;

	private ComboBox comboBox_1;

	private RadioButton radioButton_2;

	private RadioButton radioButton_3;

	private CheckBox checkBox_0;

	private RadioButton radioButton_4;

	private RadioButton radioButton_5;

	private Button button_1;

	private Label label_0;

	private Label label_1;

	private Label label_2;

	private Label label_3;

	private CheckBox checkBox_1;

	private CheckBox checkBox_2;

	private CheckBox checkBox_3;

	private CheckBox checkBox_4;

	private ComboBox comboBox_2;

	private ComboBox comboBox_3;

	private CheckBox checkBox_5;

	private CheckBox checkBox_6;

	private CheckBox checkBox_7;

	private CheckBox checkBox_8;

	private CheckBox checkBox_9;

	private CheckBox checkBox_10;

	private CheckBox checkBox_11;

	private CheckBox checkBox_12;

	private ArrayList arrayList_0 = new ArrayList(new object[1124]
	{
		401,
		GProD.TX(1318),
		0,
		GProD.TX(1004),
		1,
		GProD.TX(1005),
		2,
		GProD.TX(1006),
		3,
		GProD.TX(1007),
		4,
		GProD.TX(1008, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5000),
		5,
		GProD.TX(1008, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5001),
		6,
		GProD.TX(1008, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5002),
		7,
		GProD.TX(1008, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5003),
		8,
		GProD.TX(1008, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5004),
		9,
		GProD.TX(1008, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5005),
		446,
		GProD.TX(1347),
		447,
		GProD.TX(1348, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5000),
		448,
		GProD.TX(1348, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5001),
		449,
		GProD.TX(1348, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5002),
		450,
		GProD.TX(1348, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5003),
		451,
		GProD.TX(1348, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5004),
		452,
		GProD.TX(1348, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5005),
		10,
		GProD.TX(1009),
		11,
		GProD.TX(1010),
		12,
		GProD.TX(6071, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5010),
		13,
		GProD.TX(6072, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5000),
		14,
		GProD.TX(6072, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5001),
		15,
		GProD.TX(6072, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5002),
		16,
		GProD.TX(6072, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5003),
		17,
		GProD.TX(6072, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5004),
		18,
		GProD.TX(6072, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5005),
		19,
		GProD.TX(6073, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5000),
		20,
		GProD.TX(6073, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5001),
		21,
		GProD.TX(6073, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5002),
		22,
		GProD.TX(6073, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5003),
		23,
		GProD.TX(6073, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5004),
		24,
		GProD.TX(6073, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5005),
		25,
		GProD.TX(1011),
		26,
		GProD.TX(1012),
		453,
		GProD.TX(1349),
		454,
		GProD.TX(1350, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5000),
		455,
		GProD.TX(1350, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5001),
		456,
		GProD.TX(1350, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5002),
		457,
		GProD.TX(1350, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5003),
		458,
		GProD.TX(1350, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5004),
		459,
		GProD.TX(1350, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5005),
		512,
		GProD.TX(1379),
		27,
		GProD.TX(1013),
		28,
		GProD.TX(1014),
		29,
		GProD.TX(1015),
		30,
		GProD.TX(1016),
		31,
		GProD.TX(1017),
		32,
		GProD.TX(1018),
		33,
		GProD.TX(1019),
		34,
		GProD.TX(1020),
		35,
		GProD.TX(1021),
		36,
		GProD.TX(1022),
		37,
		GProD.TX(1023),
		38,
		GProD.TX(1024),
		39,
		GProD.TX(6074, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1025),
		40,
		GProD.TX(6074, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1026),
		420,
		GProD.TX(6074, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5104),
		41,
		GProD.TX(6074, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5011),
		42,
		GProD.TX(6074, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5012),
		43,
		GProD.TX(6074, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5013),
		44,
		GProD.TX(6074, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5014),
		45,
		GProD.TX(6074, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5015),
		46,
		GProD.TX(6074, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5016),
		47,
		GProD.TX(6075, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1027),
		48,
		GProD.TX(6075, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1028),
		421,
		GProD.TX(6075, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5104),
		49,
		GProD.TX(6075, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5011),
		50,
		GProD.TX(6075, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5012),
		51,
		GProD.TX(6075, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5013),
		52,
		GProD.TX(6075, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5014),
		53,
		GProD.TX(6075, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5015),
		54,
		GProD.TX(6075, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5016),
		55,
		GProD.TX(6076, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1029),
		56,
		GProD.TX(6076, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1030),
		422,
		GProD.TX(6076, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5104),
		57,
		GProD.TX(6076, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5011),
		58,
		GProD.TX(6076, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5012),
		59,
		GProD.TX(6076, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5013),
		60,
		GProD.TX(6076, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5014),
		61,
		GProD.TX(6076, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5015),
		62,
		GProD.TX(6076, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5016),
		63,
		GProD.TX(1031),
		64,
		GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1032),
		65,
		GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1033),
		66,
		GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1649263772),
		67,
		GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1649263781),
		68,
		GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1649263790),
		69,
		GProD.TX(1037),
		70,
		GProD.TX(1038),
		71,
		GProD.TX(1039),
		72,
		GProD.TX(1040),
		73,
		GProD.TX(1041),
		74,
		GProD.TX(1042),
		75,
		GProD.TX(1043),
		76,
		GProD.TX(1044),
		77,
		GProD.TX(1045),
		78,
		GProD.TX(1046),
		79,
		GProD.TX(1047),
		80,
		GProD.TX(1048),
		81,
		GProD.TX(1049),
		82,
		GProD.TX(1050),
		83,
		GProD.TX(1051),
		84,
		GProD.TX(1052),
		85,
		GProD.TX(1053),
		86,
		GProD.TX(1054, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5017),
		87,
		GProD.TX(1054, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5018),
		88,
		GProD.TX(1054, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5019),
		484,
		GProD.TX(1367, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5107),
		485,
		GProD.TX(1367, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5108),
		486,
		GProD.TX(1367, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5109),
		523,
		GProD.TX(1383, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5081),
		524,
		GProD.TX(1383, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5082),
		525,
		GProD.TX(1383, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5083),
		89,
		GProD.TX(1055),
		90,
		GProD.TX(1056),
		91,
		GProD.TX(1057),
		92,
		GProD.TX(1058),
		93,
		GProD.TX(1059),
		94,
		GProD.TX(1060),
		522,
		GProD.TX(1382),
		95,
		GProD.TX(1061),
		96,
		GProD.TX(1062),
		97,
		GProD.TX(1063),
		98,
		GProD.TX(1064),
		99,
		GProD.TX(1065),
		100,
		GProD.TX(1066),
		101,
		GProD.TX(1067),
		102,
		GProD.TX(1068),
		103,
		GProD.TX(1070),
		104,
		GProD.TX(1071),
		105,
		GProD.TX(1072, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5023),
		106,
		GProD.TX(1072, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5024),
		107,
		GProD.TX(1072, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5025),
		108,
		GProD.TX(1072, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5026),
		109,
		GProD.TX(1073),
		110,
		GProD.TX(1074),
		111,
		GProD.TX(1075),
		112,
		GProD.TX(1076),
		113,
		GProD.TX(1077),
		114,
		GProD.TX(1078),
		115,
		GProD.TX(1079),
		116,
		GProD.TX(1080),
		117,
		GProD.TX(1081),
		118,
		GProD.TX(1082),
		119,
		GProD.TX(1083),
		552,
		GProD.TX(1396),
		371,
		GProD.TX(1278),
		390,
		GProD.TX(1294),
		391,
		GProD.TX(1295),
		392,
		GProD.TX(1296),
		402,
		GProD.TX(1311),
		403,
		GProD.TX(1312),
		428,
		GProD.TX(1330),
		429,
		GProD.TX(1331),
		430,
		GProD.TX(1332),
		487,
		GProD.TX(1368),
		526,
		GProD.TX(1384),
		435,
		GProD.TX(1336),
		436,
		GProD.TX(1337),
		437,
		GProD.TX(1338),
		460,
		GProD.TX(1351),
		461,
		GProD.TX(1352),
		462,
		GProD.TX(1353),
		463,
		GProD.TX(1354, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041),
		464,
		GProD.TX(1354, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042),
		465,
		GProD.TX(1354, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043),
		466,
		GProD.TX(1354, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044),
		467,
		GProD.TX(1354, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045),
		468,
		GProD.TX(1355, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041),
		469,
		GProD.TX(1355, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042),
		470,
		GProD.TX(1355, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043),
		471,
		GProD.TX(1355, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044),
		472,
		GProD.TX(1355, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045),
		554,
		GProD.TX(1398),
		555,
		GProD.TX(1399),
		556,
		GProD.TX(21400, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041),
		557,
		GProD.TX(21400, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042),
		558,
		GProD.TX(21400, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043),
		559,
		GProD.TX(21400, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044),
		560,
		GProD.TX(21400, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045),
		561,
		GProD.TX(21401, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041),
		562,
		GProD.TX(21401, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042),
		563,
		GProD.TX(21401, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043),
		564,
		GProD.TX(21401, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044),
		565,
		GProD.TX(21401, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045),
		473,
		GProD.TX(1356),
		483,
		GProD.TX(1366),
		513,
		GProD.TX(1380),
		514,
		GProD.TX(1381),
		515,
		GProD.TX(6187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1442),
		516,
		GProD.TX(6187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1443),
		517,
		GProD.TX(6187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1444),
		518,
		GProD.TX(6187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1445, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5071),
		519,
		GProD.TX(6187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1445, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5072),
		520,
		GProD.TX(6187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1445, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5073),
		521,
		GProD.TX(6187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1445, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5074),
		120,
		GProD.TX(1084),
		121,
		GProD.TX(1085),
		122,
		GProD.TX(1086),
		123,
		GProD.TX(1087),
		124,
		GProD.TX(1088),
		125,
		GProD.TX(1089),
		126,
		GProD.TX(1090),
		127,
		GProD.TX(1091),
		128,
		GProD.TX(1092),
		129,
		GProD.TX(1093),
		130,
		GProD.TX(1094),
		131,
		GProD.TX(1095),
		132,
		GProD.TX(1096),
		133,
		GProD.TX(1097),
		134,
		GProD.TX(1098),
		135,
		GProD.TX(1099, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5027),
		136,
		GProD.TX(1099, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5028),
		137,
		GProD.TX(1099, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5029),
		138,
		GProD.TX(1099, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5030),
		139,
		GProD.TX(1099, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5031),
		140,
		GProD.TX(1100),
		141,
		GProD.TX(1101),
		372,
		GProD.TX(1279),
		142,
		GProD.TX(1102, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5027),
		143,
		GProD.TX(1102, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5028),
		144,
		GProD.TX(1102, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5029),
		145,
		GProD.TX(1102, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5030),
		146,
		GProD.TX(1102, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5031),
		147,
		GProD.TX(1105),
		148,
		GProD.TX(1106),
		149,
		GProD.TX(1107),
		150,
		GProD.TX(1108),
		151,
		GProD.TX(1109),
		404,
		GProD.TX(1110, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5101),
		152,
		GProD.TX(1110, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5102),
		153,
		GProD.TX(1111),
		154,
		GProD.TX(1112),
		155,
		GProD.TX(1113),
		156,
		GProD.TX(1114),
		157,
		GProD.TX(1115),
		158,
		GProD.TX(1116),
		159,
		GProD.TX(1117),
		160,
		GProD.TX(1118),
		161,
		GProD.TX(1119),
		162,
		GProD.TX(1140),
		163,
		GProD.TX(1141),
		164,
		GProD.TX(1142),
		165,
		GProD.TX(1143),
		166,
		GProD.TX(1144),
		167,
		GProD.TX(1145),
		168,
		GProD.TX(1146),
		169,
		GProD.TX(1147),
		170,
		GProD.TX(1148),
		171,
		GProD.TX(1149),
		172,
		GProD.TX(1150),
		173,
		GProD.TX(1151),
		174,
		GProD.TX(1152),
		175,
		GProD.TX(1153),
		176,
		GProD.TX(1154, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5000),
		177,
		GProD.TX(1154, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5001),
		178,
		GProD.TX(1154, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5002),
		179,
		GProD.TX(1154, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5003),
		180,
		GProD.TX(1154, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5004),
		181,
		GProD.TX(1154, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5005),
		182,
		GProD.TX(1155),
		405,
		GProD.TX(1319),
		183,
		GProD.TX(1156),
		184,
		GProD.TX(1157),
		406,
		GProD.TX(1158, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5101),
		185,
		GProD.TX(1158, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5102),
		186,
		GProD.TX(1159),
		187,
		GProD.TX(1160),
		188,
		GProD.TX(1161),
		189,
		GProD.TX(1162),
		190,
		GProD.TX(1163),
		191,
		GProD.TX(1164),
		192,
		GProD.TX(1165),
		193,
		GProD.TX(1166),
		194,
		GProD.TX(1167),
		195,
		GProD.TX(1168),
		196,
		GProD.TX(1169),
		197,
		GProD.TX(1170),
		198,
		GProD.TX(1171),
		199,
		GProD.TX(1172),
		200,
		GProD.TX(1173),
		201,
		GProD.TX(1174),
		202,
		GProD.TX(1175),
		203,
		GProD.TX(1176),
		204,
		GProD.TX(1177),
		205,
		GProD.TX(1178),
		206,
		GProD.TX(1179),
		207,
		GProD.TX(1180),
		208,
		GProD.TX(1181),
		209,
		GProD.TX(1182),
		210,
		GProD.TX(1183, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5032),
		211,
		GProD.TX(1183, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5033),
		212,
		GProD.TX(1183, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5034),
		213,
		GProD.TX(1183, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5035),
		214,
		GProD.TX(1183, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5036),
		215,
		GProD.TX(1183, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5037),
		216,
		GProD.TX(1183, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5038),
		407,
		GProD.TX(1183, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5103),
		217,
		GProD.TX(1183, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5039),
		218,
		GProD.TX(1183, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5040),
		219,
		GProD.TX(1184),
		220,
		GProD.TX(1185),
		221,
		GProD.TX(1186),
		222,
		GProD.TX(1187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041),
		223,
		GProD.TX(1187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042),
		224,
		GProD.TX(1187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043),
		225,
		GProD.TX(1187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044),
		226,
		GProD.TX(1187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045),
		227,
		GProD.TX(1188, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041),
		228,
		GProD.TX(1188, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042),
		229,
		GProD.TX(1188, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043),
		230,
		GProD.TX(1188, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044),
		231,
		GProD.TX(1188, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045),
		488,
		GProD.TX(1369),
		489,
		GProD.TX(1370),
		490,
		GProD.TX(1371, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041),
		491,
		GProD.TX(1371, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042),
		492,
		GProD.TX(1371, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043),
		493,
		GProD.TX(1371, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044),
		494,
		GProD.TX(1371, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045),
		495,
		GProD.TX(1372, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041),
		496,
		GProD.TX(1372, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042),
		497,
		GProD.TX(1372, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043),
		498,
		GProD.TX(1372, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044),
		499,
		GProD.TX(1372, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045),
		527,
		GProD.TX(1385),
		528,
		GProD.TX(1386),
		529,
		GProD.TX(1387, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041),
		530,
		GProD.TX(1387, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042),
		531,
		GProD.TX(1387, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043),
		532,
		GProD.TX(1387, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044),
		533,
		GProD.TX(1387, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045),
		534,
		GProD.TX(1388, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041),
		535,
		GProD.TX(1388, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042),
		536,
		GProD.TX(1388, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043),
		537,
		GProD.TX(1388, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044),
		538,
		GProD.TX(1388, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045),
		232,
		GProD.TX(1189),
		233,
		GProD.TX(1190),
		234,
		GProD.TX(1191),
		235,
		GProD.TX(1192),
		236,
		GProD.TX(1193),
		237,
		GProD.TX(1194),
		238,
		GProD.TX(1195),
		239,
		GProD.TX(1196),
		240,
		GProD.TX(1197),
		241,
		GProD.TX(1198),
		242,
		GProD.TX(1199),
		243,
		GProD.TX(1200),
		244,
		GProD.TX(1201),
		245,
		GProD.TX(1202),
		246,
		GProD.TX(1203),
		247,
		GProD.TX(1204),
		248,
		GProD.TX(1205),
		249,
		GProD.TX(1206),
		250,
		GProD.TX(1207, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5046),
		251,
		GProD.TX(1208),
		252,
		GProD.TX(1209),
		253,
		GProD.TX(1210),
		254,
		GProD.TX(1211),
		255,
		GProD.TX(1212),
		256,
		GProD.TX(1213),
		257,
		GProD.TX(1214),
		258,
		GProD.TX(1215),
		259,
		GProD.TX(1216),
		260,
		GProD.TX(1217),
		261,
		GProD.TX(1218),
		262,
		GProD.TX(1219),
		263,
		GProD.TX(1220),
		264,
		GProD.TX(1221),
		265,
		GProD.TX(1277),
		266,
		GProD.TX(1222),
		267,
		GProD.TX(1223),
		268,
		GProD.TX(1224),
		269,
		GProD.TX(1225),
		270,
		GProD.TX(1226),
		271,
		GProD.TX(1227),
		272,
		GProD.TX(1228),
		273,
		GProD.TX(1229),
		274,
		GProD.TX(1230),
		275,
		GProD.TX(1231),
		276,
		GProD.TX(1232),
		277,
		GProD.TX(1233),
		278,
		GProD.TX(1234),
		279,
		GProD.TX(1235),
		280,
		GProD.TX(1236),
		281,
		GProD.TX(1237),
		376,
		GProD.TX(1283),
		377,
		GProD.TX(1284),
		378,
		GProD.TX(1285),
		393,
		GProD.TX(1297),
		394,
		GProD.TX(1298),
		395,
		GProD.TX(1299),
		396,
		GProD.TX(1300),
		397,
		GProD.TX(1301),
		398,
		GProD.TX(1302),
		399,
		GProD.TX(1303),
		408,
		GProD.TX(1313),
		409,
		GProD.TX(1314),
		410,
		GProD.TX(1315),
		411,
		GProD.TX(1316),
		412,
		GProD.TX(1317),
		413,
		GProD.TX(1322),
		414,
		GProD.TX(1323),
		425,
		GProD.TX(1327),
		426,
		GProD.TX(1328),
		431,
		GProD.TX(1333, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5101),
		432,
		GProD.TX(1333, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5102),
		433,
		GProD.TX(1334),
		438,
		GProD.TX(1339),
		439,
		GProD.TX(1340),
		440,
		GProD.TX(1341),
		441,
		GProD.TX(1342),
		442,
		GProD.TX(1343),
		443,
		GProD.TX(1344),
		444,
		GProD.TX(1345),
		474,
		GProD.TX(1357),
		475,
		GProD.TX(1358),
		476,
		GProD.TX(1359),
		477,
		GProD.TX(1360),
		478,
		GProD.TX(1361),
		479,
		GProD.TX(1362),
		282,
		GProD.TX(1238),
		283,
		GProD.TX(1239),
		284,
		GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5047),
		285,
		GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5048),
		286,
		GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5049),
		287,
		GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5050),
		288,
		GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5051),
		289,
		GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5052),
		290,
		GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5053),
		291,
		GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5054),
		292,
		GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5055),
		293,
		GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5056),
		294,
		GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5087),
		295,
		GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5088),
		296,
		GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5088),
		297,
		GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5088),
		298,
		GProD.TX(1241, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5057),
		299,
		GProD.TX(1241, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5058),
		300,
		GProD.TX(1241, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5059),
		301,
		GProD.TX(1241, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5060),
		302,
		GProD.TX(1241, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5061),
		303,
		GProD.TX(1241, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5062),
		304,
		GProD.TX(1241, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5063),
		305,
		GProD.TX(1241, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5064),
		306,
		GProD.TX(1241, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5065),
		373,
		GProD.TX(1280),
		307,
		GProD.TX(1242, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5027),
		308,
		GProD.TX(1242, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5028),
		309,
		GProD.TX(1242, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5029),
		310,
		GProD.TX(1242, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5030),
		311,
		GProD.TX(1242, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5031),
		312,
		GProD.TX(1243),
		313,
		GProD.TX(1244),
		314,
		GProD.TX(1245),
		315,
		GProD.TX(1246),
		316,
		GProD.TX(1247),
		317,
		GProD.TX(1248),
		318,
		GProD.TX(1249),
		319,
		GProD.TX(6078, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1250),
		423,
		GProD.TX(6078, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5104),
		320,
		GProD.TX(6078, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5011),
		321,
		GProD.TX(6078, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5012),
		322,
		GProD.TX(6078, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5013),
		323,
		GProD.TX(6078, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5014),
		324,
		GProD.TX(6078, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5015),
		325,
		GProD.TX(6078, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5016),
		326,
		GProD.TX(1251),
		327,
		GProD.TX(6079, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1252),
		328,
		GProD.TX(6079, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1253),
		329,
		GProD.TX(6079, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1254),
		330,
		GProD.TX(6079, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1255),
		331,
		GProD.TX(6079, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1256),
		332,
		GProD.TX(6079, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1257),
		379,
		GProD.TX(6079, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1286),
		333,
		GProD.TX(6080, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1258),
		424,
		GProD.TX(6080, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5104),
		334,
		GProD.TX(6080, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5011),
		335,
		GProD.TX(6080, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5012),
		336,
		GProD.TX(6080, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5013),
		337,
		GProD.TX(6080, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5014),
		338,
		GProD.TX(6080, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5015),
		339,
		GProD.TX(6080, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5016),
		340,
		GProD.TX(1259),
		341,
		GProD.TX(1260),
		342,
		GProD.TX(1261, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041),
		343,
		GProD.TX(1261, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042),
		344,
		GProD.TX(1261, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043),
		345,
		GProD.TX(1261, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044),
		346,
		GProD.TX(1261, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045),
		347,
		GProD.TX(1262, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041),
		348,
		GProD.TX(1262, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042),
		349,
		GProD.TX(1262, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043),
		350,
		GProD.TX(1262, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044),
		351,
		GProD.TX(1262, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045),
		500,
		GProD.TX(1373),
		501,
		GProD.TX(1374),
		502,
		GProD.TX(1375, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041),
		503,
		GProD.TX(1375, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042),
		504,
		GProD.TX(1375, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043),
		505,
		GProD.TX(1375, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044),
		506,
		GProD.TX(1375, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045),
		507,
		GProD.TX(1376, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041),
		508,
		GProD.TX(1376, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042),
		509,
		GProD.TX(1376, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043),
		510,
		GProD.TX(1376, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044),
		511,
		GProD.TX(1376, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045),
		539,
		GProD.TX(1389),
		540,
		GProD.TX(1390),
		541,
		GProD.TX(1391, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041),
		542,
		GProD.TX(1391, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042),
		543,
		GProD.TX(1391, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043),
		544,
		GProD.TX(1391, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044),
		545,
		GProD.TX(1391, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045),
		546,
		GProD.TX(1392, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041),
		547,
		GProD.TX(1392, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042),
		548,
		GProD.TX(1392, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043),
		549,
		GProD.TX(1392, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044),
		550,
		GProD.TX(1392, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045),
		352,
		GProD.TX(1265),
		415,
		GProD.TX(1324),
		353,
		GProD.TX(1266),
		354,
		GProD.TX(1267),
		355,
		GProD.TX(1268),
		356,
		GProD.TX(1269),
		357,
		GProD.TX(1270),
		417,
		GProD.TX(1325),
		358,
		GProD.TX(1271),
		359,
		GProD.TX(1272),
		360,
		GProD.TX(1273),
		361,
		GProD.TX(1274, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5068),
		362,
		GProD.TX(1274, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5069),
		374,
		GProD.TX(1281),
		375,
		GProD.TX(1282),
		380,
		GProD.TX(1287),
		445,
		GProD.TX(1346),
		480,
		GProD.TX(1363),
		481,
		GProD.TX(1364),
		482,
		GProD.TX(1365),
		382,
		GProD.TX(1289),
		383,
		GProD.TX(1290),
		384,
		GProD.TX(1291, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5091),
		385,
		GProD.TX(1291, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5092),
		386,
		GProD.TX(1292, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5093),
		387,
		GProD.TX(1292, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5094),
		418,
		GProD.TX(1293, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5101),
		388,
		GProD.TX(1293, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5095),
		389,
		GProD.TX(1293, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5096),
		400,
		GProD.TX(1304),
		419,
		GProD.TX(1321),
		427,
		GProD.TX(1329),
		551,
		GProD.TX(1395),
		553,
		GProD.TX(1397),
		367,
		GProD.TX(1604),
		368,
		GProD.TX(1605),
		369,
		GProD.TX(1606),
		370,
		GProD.TX(1607),
		381,
		GProD.TX(1608),
		566,
		Class16.smethod_0(1649252853),
		567,
		Class16.smethod_0(1649247745)
	});

	private ArrayList arrayList_1 = new ArrayList(new object[224]
	{
		0,
		GProD.TX(1275),
		1,
		GProD.TX(1276),
		2,
		GProD.TX(1412),
		3,
		GProD.TX(1413),
		4,
		GProD.TX(1414),
		5,
		GProD.TX(1415),
		97,
		GProD.TX(1493),
		6,
		GProD.TX(1416),
		7,
		GProD.TX(1417),
		8,
		GProD.TX(1418),
		9,
		GProD.TX(1419),
		10,
		GProD.TX(1420),
		11,
		GProD.TX(1421),
		12,
		GProD.TX(1422),
		13,
		GProD.TX(1423),
		14,
		GProD.TX(1424),
		15,
		GProD.TX(1425),
		16,
		GProD.TX(1426),
		17,
		GProD.TX(1427),
		18,
		GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1428),
		101,
		GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1497),
		19,
		GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1649263772),
		20,
		GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1649263781),
		21,
		GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1649263790),
		22,
		GProD.TX(1432),
		23,
		GProD.TX(1433),
		24,
		GProD.TX(1434),
		25,
		GProD.TX(1435),
		26,
		GProD.TX(1436),
		27,
		GProD.TX(1437),
		28,
		GProD.TX(1439, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1440),
		29,
		GProD.TX(1439, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1441, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5027),
		30,
		GProD.TX(1439, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1441, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5028),
		31,
		GProD.TX(1439, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1441, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5029),
		32,
		GProD.TX(1439, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1441, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5030),
		33,
		GProD.TX(1439, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1441, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5031),
		34,
		GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1442),
		35,
		GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1443),
		36,
		GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1444),
		37,
		GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1445, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5071),
		38,
		GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1445, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5072),
		39,
		GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1445, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5073),
		40,
		GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1445, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5074),
		41,
		GProD.TX(1446),
		42,
		GProD.TX(1447),
		43,
		GProD.TX(1448),
		44,
		GProD.TX(1449),
		45,
		GProD.TX(1450),
		46,
		GProD.TX(1451),
		47,
		GProD.TX(1452),
		98,
		GProD.TX(1494),
		48,
		GProD.TX(1453),
		49,
		GProD.TX(1454),
		50,
		GProD.TX(1455),
		51,
		GProD.TX(1456),
		52,
		GProD.TX(1457),
		53,
		GProD.TX(1458),
		54,
		GProD.TX(1459),
		55,
		GProD.TX(1460),
		56,
		GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1461),
		57,
		GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1462, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5075),
		58,
		GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1462, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5076),
		59,
		GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1462, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5077),
		60,
		GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1462, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5078),
		61,
		GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1462, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5079),
		62,
		GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1462, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5080),
		63,
		GProD.TX(1463, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5017),
		64,
		GProD.TX(1463, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5018),
		65,
		GProD.TX(1463, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5019),
		108,
		GProD.TX(1504, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5107),
		109,
		GProD.TX(1504, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5108),
		110,
		GProD.TX(1504, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5109),
		66,
		GProD.TX(1464, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5081),
		67,
		GProD.TX(1464, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5082),
		68,
		GProD.TX(1464, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5083),
		69,
		GProD.TX(1465),
		70,
		GProD.TX(1466),
		71,
		GProD.TX(1467),
		72,
		GProD.TX(1468),
		73,
		GProD.TX(1471),
		74,
		GProD.TX(1472),
		75,
		GProD.TX(1473),
		76,
		GProD.TX(1474),
		77,
		GProD.TX(1475),
		78,
		GProD.TX(1476, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5085),
		79,
		GProD.TX(1476, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5086),
		80,
		GProD.TX(1477),
		81,
		GProD.TX(1478),
		82,
		GProD.TX(1479),
		83,
		GProD.TX(1480),
		84,
		GProD.TX(1481),
		85,
		GProD.TX(1482),
		86,
		GProD.TX(1483),
		87,
		GProD.TX(1484),
		88,
		GProD.TX(1485),
		89,
		GProD.TX(1486),
		90,
		GProD.TX(1487),
		91,
		GProD.TX(1488, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5097),
		92,
		GProD.TX(1488, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5098),
		93,
		GProD.TX(6125, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1489),
		94,
		GProD.TX(6125, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1490),
		95,
		GProD.TX(6125, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1491),
		96,
		GProD.TX(6125, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1492),
		99,
		GProD.TX(1495),
		100,
		GProD.TX(1496),
		102,
		GProD.TX(1498),
		103,
		GProD.TX(1499),
		104,
		GProD.TX(1500),
		105,
		GProD.TX(1501),
		106,
		GProD.TX(1502),
		107,
		GProD.TX(1503),
		111,
		GProD.TX(1505)
	});

	public ReplaceWindow(ACE.sTASKedit.MainEditor.MainEditor MainWindow, TreeNodeCollection Nodes)
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		mainEditor_0 = MainWindow;
		treeNodeCollection_0 = Nodes;
		SetLocalization();
		comboBox_Parameters_SetItems();
		comboBox_0.SelectedIndex = 0;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_0()
	{
		new ComponentResourceManager(typeof(ReplaceWindow));
		textBox_0 = new TextBox();
		button_0 = new Button();
		radioButton_0 = new RadioButton();
		radioButton_1 = new RadioButton();
		comboBox_0 = new ComboBox();
		textBox_1 = new TextBox();
		comboBox_1 = new ComboBox();
		radioButton_2 = new RadioButton();
		radioButton_3 = new RadioButton();
		checkBox_0 = new CheckBox();
		radioButton_4 = new RadioButton();
		radioButton_5 = new RadioButton();
		button_1 = new Button();
		label_0 = new Label();
		label_1 = new Label();
		label_2 = new Label();
		label_3 = new Label();
		comboBox_2 = new ComboBox();
		comboBox_3 = new ComboBox();
		checkBox_1 = new CheckBox();
		checkBox_2 = new CheckBox();
		checkBox_3 = new CheckBox();
		checkBox_4 = new CheckBox();
		checkBox_5 = new CheckBox();
		checkBox_6 = new CheckBox();
		checkBox_7 = new CheckBox();
		checkBox_8 = new CheckBox();
		checkBox_9 = new CheckBox();
		checkBox_10 = new CheckBox();
		checkBox_11 = new CheckBox();
		checkBox_12 = new CheckBox();
		SuspendLayout();
		textBox_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		textBox_0.Location = new Point(112, 272);
		textBox_0.Name = Class16.smethod_0(1649252636);
		textBox_0.Size = new Size(410, 20);
		textBox_0.TabIndex = 0;
		button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_0.Location = new Point(11, 324);
		button_0.Name = Class16.smethod_0(1649262453);
		button_0.Size = new Size(249, 23);
		button_0.TabIndex = 1;
		button_0.Text = Class16.smethod_0(1648999325);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		radioButton_0.AutoCheck = false;
		radioButton_0.AutoSize = true;
		radioButton_0.Location = new Point(12, 10);
		radioButton_0.Name = Class16.smethod_0(1649258827);
		radioButton_0.Size = new Size(36, 17);
		radioButton_0.TabIndex = 2;
		radioButton_0.TabStop = true;
		radioButton_0.Text = Class16.smethod_0(1648973883);
		radioButton_0.UseVisualStyleBackColor = true;
		radioButton_0.Click += radioButton_0_Click;
		radioButton_1.AutoCheck = false;
		radioButton_1.AutoSize = true;
		radioButton_1.Checked = true;
		radioButton_1.Location = new Point(274, 10);
		radioButton_1.Name = Class16.smethod_0(1649258865);
		radioButton_1.Size = new Size(61, 17);
		radioButton_1.TabIndex = 3;
		radioButton_1.Text = Class16.smethod_0(1649253096);
		radioButton_1.UseVisualStyleBackColor = true;
		radioButton_1.Click += radioButton_1_Click;
		comboBox_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Items.AddRange(new object[5]
		{
			Class16.smethod_0(1649247763),
			Class16.smethod_0(1649247781),
			Class16.smethod_0(1649247784),
			Class16.smethod_0(1649247804),
			Class16.smethod_0(1649247811)
		});
		comboBox_0.Location = new Point(112, 246);
		comboBox_0.Name = Class16.smethod_0(1649247824);
		comboBox_0.Size = new Size(410, 21);
		comboBox_0.TabIndex = 4;
		textBox_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		textBox_1.Location = new Point(112, 297);
		textBox_1.Name = Class16.smethod_0(1649252676);
		textBox_1.Size = new Size(410, 20);
		textBox_1.TabIndex = 5;
		comboBox_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_1.FormattingEnabled = true;
		comboBox_1.Location = new Point(112, 220);
		comboBox_1.Name = Class16.smethod_0(1649247851);
		comboBox_1.Size = new Size(410, 21);
		comboBox_1.TabIndex = 6;
		comboBox_1.SelectedIndexChanged += comboBox_1_SelectedIndexChanged;
		radioButton_2.AutoCheck = false;
		radioButton_2.AutoSize = true;
		radioButton_2.Checked = true;
		radioButton_2.Location = new Point(12, 33);
		radioButton_2.Name = Class16.smethod_0(1649253117);
		radioButton_2.Size = new Size(96, 17);
		radioButton_2.TabIndex = 7;
		radioButton_2.Text = Class16.smethod_0(1649253139);
		radioButton_2.UseVisualStyleBackColor = true;
		radioButton_2.Click += radioButton_2_Click;
		radioButton_3.AutoCheck = false;
		radioButton_3.AutoSize = true;
		radioButton_3.Location = new Point(274, 33);
		radioButton_3.Name = Class16.smethod_0(1649253167);
		radioButton_3.Size = new Size(114, 17);
		radioButton_3.TabIndex = 8;
		radioButton_3.Text = Class16.smethod_0(1649253193);
		radioButton_3.UseVisualStyleBackColor = true;
		radioButton_3.Click += radioButton_3_Click;
		checkBox_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		checkBox_0.CheckAlign = ContentAlignment.MiddleRight;
		checkBox_0.Location = new Point(7, 275);
		checkBox_0.Name = Class16.smethod_0(1649247885);
		checkBox_0.Size = new Size(119, 17);
		checkBox_0.TabIndex = 9;
		checkBox_0.Text = Class16.smethod_0(1648981711);
		checkBox_0.UseVisualStyleBackColor = true;
		radioButton_4.AutoCheck = false;
		radioButton_4.AutoSize = true;
		radioButton_4.Checked = true;
		radioButton_4.Location = new Point(12, 56);
		radioButton_4.Name = Class16.smethod_0(1649247909);
		radioButton_4.Size = new Size(72, 17);
		radioButton_4.TabIndex = 10;
		radioButton_4.TabStop = true;
		radioButton_4.Text = Class16.smethod_0(1649050557);
		radioButton_4.UseVisualStyleBackColor = true;
		radioButton_4.Click += radioButton_4_Click;
		radioButton_5.AutoCheck = false;
		radioButton_5.AutoSize = true;
		radioButton_5.Location = new Point(274, 56);
		radioButton_5.Name = Class16.smethod_0(1649247930);
		radioButton_5.Size = new Size(60, 17);
		radioButton_5.TabIndex = 11;
		radioButton_5.TabStop = true;
		radioButton_5.Text = Class16.smethod_0(1649247955);
		radioButton_5.UseVisualStyleBackColor = true;
		radioButton_5.Click += radioButton_5_Click;
		button_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_1.Location = new Point(274, 324);
		button_1.Name = Class16.smethod_0(1649262492);
		button_1.Size = new Size(249, 23);
		button_1.TabIndex = 16;
		button_1.Text = Class16.smethod_0(1648941799);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		label_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_0.AutoSize = true;
		label_0.Location = new Point(9, 224);
		label_0.Name = Class16.smethod_0(1648919238);
		label_0.Size = new Size(58, 13);
		label_0.TabIndex = 17;
		label_0.Text = Class16.smethod_0(1649247968);
		label_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_1.AutoSize = true;
		label_1.Location = new Point(9, 250);
		label_1.Name = Class16.smethod_0(1648912083);
		label_1.Size = new Size(34, 13);
		label_1.TabIndex = 18;
		label_1.Text = Class16.smethod_0(1649014090);
		label_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_2.AutoSize = true;
		label_2.Location = new Point(9, 276);
		label_2.Name = Class16.smethod_0(1648912145);
		label_2.Size = new Size(56, 13);
		label_2.TabIndex = 19;
		label_2.Text = Class16.smethod_0(1649252611);
		label_3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_3.AutoSize = true;
		label_3.Location = new Point(9, 301);
		label_3.Name = Class16.smethod_0(1648912200);
		label_3.Size = new Size(62, 13);
		label_3.TabIndex = 20;
		label_3.Text = Class16.smethod_0(1649252651);
		comboBox_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		comboBox_2.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_2.FormattingEnabled = true;
		comboBox_2.Location = new Point(112, 272);
		comboBox_2.Name = Class16.smethod_0(1649247985);
		comboBox_2.Size = new Size(410, 21);
		comboBox_2.TabIndex = 21;
		comboBox_3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		comboBox_3.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_3.FormattingEnabled = true;
		comboBox_3.Location = new Point(112, 297);
		comboBox_3.Name = Class16.smethod_0(1649248009);
		comboBox_3.Size = new Size(410, 21);
		comboBox_3.TabIndex = 22;
		checkBox_1.AutoSize = true;
		checkBox_1.Checked = true;
		checkBox_1.CheckState = CheckState.Checked;
		checkBox_1.Location = new Point(12, 79);
		checkBox_1.Name = Class16.smethod_0(1649248033);
		checkBox_1.Size = new Size(83, 17);
		checkBox_1.TabIndex = 23;
		checkBox_1.Text = Class16.smethod_0(1649261792);
		checkBox_1.UseVisualStyleBackColor = true;
		checkBox_2.AutoSize = true;
		checkBox_2.Location = new Point(274, 79);
		checkBox_2.Name = Class16.smethod_0(1649248058);
		checkBox_2.Size = new Size(82, 17);
		checkBox_2.TabIndex = 24;
		checkBox_2.Text = Class16.smethod_0(1649261808);
		checkBox_2.UseVisualStyleBackColor = true;
		checkBox_3.AutoSize = true;
		checkBox_3.Location = new Point(12, 102);
		checkBox_3.Name = Class16.smethod_0(1649248083);
		checkBox_3.Size = new Size(105, 17);
		checkBox_3.TabIndex = 25;
		checkBox_3.Text = Class16.smethod_0(1649248112);
		checkBox_3.UseVisualStyleBackColor = true;
		checkBox_4.AutoSize = true;
		checkBox_4.Location = new Point(274, 102);
		checkBox_4.Name = Class16.smethod_0(1649248140);
		checkBox_4.Size = new Size(104, 17);
		checkBox_4.TabIndex = 26;
		checkBox_4.Text = Class16.smethod_0(1649248161);
		checkBox_4.UseVisualStyleBackColor = true;
		checkBox_5.AutoSize = true;
		checkBox_5.Location = new Point(12, 125);
		checkBox_5.Name = Class16.smethod_0(1649248189);
		checkBox_5.Size = new Size(105, 17);
		checkBox_5.TabIndex = 27;
		checkBox_5.Text = Class16.smethod_0(1649248210);
		checkBox_5.UseVisualStyleBackColor = true;
		checkBox_6.AutoSize = true;
		checkBox_6.Location = new Point(274, 125);
		checkBox_6.Name = Class16.smethod_0(1649248238);
		checkBox_6.Size = new Size(104, 17);
		checkBox_6.TabIndex = 28;
		checkBox_6.Text = Class16.smethod_0(1649247235);
		checkBox_6.UseVisualStyleBackColor = true;
		checkBox_7.AutoSize = true;
		checkBox_7.Location = new Point(12, 148);
		checkBox_7.Name = Class16.smethod_0(1649247263);
		checkBox_7.Size = new Size(143, 17);
		checkBox_7.TabIndex = 29;
		checkBox_7.Text = Class16.smethod_0(1649247291);
		checkBox_7.UseVisualStyleBackColor = true;
		checkBox_8.AutoSize = true;
		checkBox_8.Location = new Point(274, 148);
		checkBox_8.Name = Class16.smethod_0(1649247326);
		checkBox_8.Size = new Size(142, 17);
		checkBox_8.TabIndex = 30;
		checkBox_8.Text = Class16.smethod_0(1649247354);
		checkBox_8.UseVisualStyleBackColor = true;
		checkBox_9.AutoSize = true;
		checkBox_9.Location = new Point(12, 171);
		checkBox_9.Name = Class16.smethod_0(1649247389);
		checkBox_9.Size = new Size(119, 17);
		checkBox_9.TabIndex = 31;
		checkBox_9.Text = Class16.smethod_0(1649247420);
		checkBox_9.UseVisualStyleBackColor = true;
		checkBox_10.AutoSize = true;
		checkBox_10.Location = new Point(274, 171);
		checkBox_10.Name = Class16.smethod_0(1649247445);
		checkBox_10.Size = new Size(118, 17);
		checkBox_10.TabIndex = 32;
		checkBox_10.Text = Class16.smethod_0(1649247476);
		checkBox_10.UseVisualStyleBackColor = true;
		checkBox_11.AutoSize = true;
		checkBox_11.Location = new Point(12, 194);
		checkBox_11.Name = Class16.smethod_0(1649247501);
		checkBox_11.Size = new Size(88, 17);
		checkBox_11.TabIndex = 33;
		checkBox_11.Text = Class16.smethod_0(1649247526);
		checkBox_11.UseVisualStyleBackColor = true;
		checkBox_12.AutoSize = true;
		checkBox_12.Location = new Point(274, 194);
		checkBox_12.Name = Class16.smethod_0(1649247536);
		checkBox_12.Size = new Size(87, 17);
		checkBox_12.TabIndex = 34;
		checkBox_12.Text = Class16.smethod_0(1649247561);
		checkBox_12.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = SystemColors.Window;
		base.ClientSize = new Size(534, 358);
		base.Controls.Add(checkBox_12);
		base.Controls.Add(checkBox_11);
		base.Controls.Add(checkBox_10);
		base.Controls.Add(checkBox_9);
		base.Controls.Add(checkBox_8);
		base.Controls.Add(checkBox_7);
		base.Controls.Add(checkBox_6);
		base.Controls.Add(checkBox_5);
		base.Controls.Add(checkBox_4);
		base.Controls.Add(checkBox_3);
		base.Controls.Add(checkBox_2);
		base.Controls.Add(checkBox_1);
		base.Controls.Add(comboBox_3);
		base.Controls.Add(comboBox_2);
		base.Controls.Add(label_3);
		base.Controls.Add(label_2);
		base.Controls.Add(label_1);
		base.Controls.Add(label_0);
		base.Controls.Add(button_1);
		base.Controls.Add(radioButton_5);
		base.Controls.Add(radioButton_4);
		base.Controls.Add(checkBox_0);
		base.Controls.Add(radioButton_3);
		base.Controls.Add(radioButton_2);
		base.Controls.Add(comboBox_1);
		base.Controls.Add(textBox_1);
		base.Controls.Add(comboBox_0);
		base.Controls.Add(radioButton_1);
		base.Controls.Add(radioButton_0);
		base.Controls.Add(button_0);
		base.Controls.Add(textBox_0);
		base.Icon = Resources.edit;
		base.MaximizeBox = false;
		MaximumSize = new Size(550, 397);
		base.MinimizeBox = false;
		MinimumSize = new Size(550, 397);
		base.Name = Class16.smethod_0(1648964180);
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1648964180);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void radioButton_0_Click(object sender, EventArgs e)
	{
		if (!radioButton_0.Checked)
		{
			radioButton_0.Checked = true;
			radioButton_1.Checked = false;
		}
	}

	private void radioButton_1_Click(object sender, EventArgs e)
	{
		if (!radioButton_1.Checked)
		{
			radioButton_1.Checked = true;
			radioButton_0.Checked = false;
		}
	}

	private void radioButton_2_Click(object sender, EventArgs e)
	{
		if (!radioButton_2.Checked)
		{
			radioButton_2.Checked = true;
			radioButton_3.Checked = false;
		}
	}

	private void radioButton_3_Click(object sender, EventArgs e)
	{
		if (!radioButton_3.Checked)
		{
			radioButton_3.Checked = true;
			radioButton_2.Checked = false;
		}
	}

	private void radioButton_4_Click(object sender, EventArgs e)
	{
		if (!radioButton_4.Checked)
		{
			radioButton_4.Checked = true;
			radioButton_5.Checked = false;
			comboBox_Parameters_SetItems();
		}
	}

	private void radioButton_5_Click(object sender, EventArgs e)
	{
		if (!radioButton_5.Checked)
		{
			radioButton_5.Checked = true;
			radioButton_4.Checked = false;
			comboBox_Parameters_SetItems();
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (GProD.Tasks != null && treeNodeCollection_0 != null && treeNodeCollection_0.Count == GProD.Tasks.Length)
		{
			mainEditor_0.treeView_tasks.BeginBulkUpdate();
			for (int i = 0; i < GProD.Tasks.Length; i++)
			{
				method_1(GProD.Tasks[i], treeNodeCollection_0[i]);
			}
			mainEditor_0.treeView_tasks.EndBulkUpdate();
			mainEditor_0.logic_select_task(null, null);
		}
	}

	public static bool RB(bool CurrentValue, bool NewValue)
	{
		return NewValue;
	}

	public static byte ReplaceByte(byte CurrentValue, string stOldValue, string stNewValue, bool SetNewValue, int ReplaceType)
	{
		byte result = CurrentValue;
		try
		{
			byte b = 0;
			float num = 0f;
			if (stOldValue != string.Empty)
			{
				b = Convert.ToByte(stOldValue);
			}
			if (stNewValue != string.Empty)
			{
				num = Convert.ToSingle(stNewValue);
			}
			if (SetNewValue)
			{
				switch (ReplaceType)
				{
				case 0:
					result = Convert.ToByte(num);
					break;
				case 1:
					result = Convert.ToByte((float)(int)CurrentValue + num);
					break;
				case 2:
					result = Convert.ToByte((float)(int)CurrentValue - num);
					break;
				case 3:
					result = Convert.ToByte((float)(int)CurrentValue * num);
					break;
				case 4:
					result = Convert.ToByte((float)(int)CurrentValue / num);
					break;
				}
			}
			else if (CurrentValue == b)
			{
				switch (ReplaceType)
				{
				case 0:
					result = Convert.ToByte(num);
					break;
				case 1:
					result = Convert.ToByte((float)(int)CurrentValue + num);
					break;
				case 2:
					result = Convert.ToByte((float)(int)CurrentValue - num);
					break;
				case 3:
					result = Convert.ToByte((float)(int)CurrentValue * num);
					break;
				case 4:
					result = Convert.ToByte((float)(int)CurrentValue / num);
					break;
				}
			}
		}
		catch
		{
			DKBox.Show(GProD.TX(403), string.Empty);
		}
		return result;
	}

	public static byte ReplaceByteCombo(byte CurrentValue, string stOldValue, string stNewValue, bool SetNewValue, int ReplaceType)
	{
		byte result = CurrentValue;
		byte b = 0;
		float value = 0f;
		if (stOldValue != string.Empty)
		{
			b = Convert.ToByte(stOldValue);
		}
		if (stNewValue != string.Empty)
		{
			value = Convert.ToSingle(stNewValue);
		}
		if (SetNewValue)
		{
			result = Convert.ToByte(value);
		}
		else if (CurrentValue == b)
		{
			result = Convert.ToByte(value);
		}
		return result;
	}

	public static short ReplaceShort(short CurrentValue, string stOldValue, string stNewValue, bool SetNewValue, int ReplaceType)
	{
		short result = CurrentValue;
		try
		{
			short num = 0;
			float num2 = 0f;
			if (stOldValue != string.Empty)
			{
				num = Convert.ToInt16(stOldValue);
			}
			if (stNewValue != string.Empty)
			{
				num2 = Convert.ToSingle(stNewValue);
			}
			if (SetNewValue)
			{
				switch (ReplaceType)
				{
				case 0:
					result = Convert.ToInt16(num2);
					break;
				case 1:
					result = Convert.ToInt16((float)CurrentValue + num2);
					break;
				case 2:
					result = Convert.ToInt16((float)CurrentValue - num2);
					break;
				case 3:
					result = Convert.ToInt16((float)CurrentValue * num2);
					break;
				case 4:
					result = Convert.ToInt16((float)CurrentValue / num2);
					break;
				}
			}
			else if (CurrentValue == num)
			{
				switch (ReplaceType)
				{
				case 0:
					result = Convert.ToInt16(num2);
					break;
				case 1:
					result = Convert.ToInt16((float)CurrentValue + num2);
					break;
				case 2:
					result = Convert.ToInt16((float)CurrentValue - num2);
					break;
				case 3:
					result = Convert.ToInt16((float)CurrentValue * num2);
					break;
				case 4:
					result = Convert.ToInt16((float)CurrentValue / num2);
					break;
				}
			}
		}
		catch
		{
			DKBox.Show(GProD.TX(403), string.Empty);
		}
		return result;
	}

	public static short ReplaceShortCombo(short CurrentValue, string stOldValue, string stNewValue, bool SetNewValue, int ReplaceType)
	{
		short result = CurrentValue;
		int num = 0;
		float value = 0f;
		if (stOldValue != string.Empty)
		{
			num = Convert.ToInt16(stOldValue);
		}
		if (stNewValue != string.Empty)
		{
			value = Convert.ToSingle(stNewValue);
		}
		if (SetNewValue)
		{
			result = Convert.ToInt16(value);
		}
		else if (CurrentValue == num)
		{
			result = Convert.ToInt16(value);
		}
		return result;
	}

	public static int RI(int CurrentValue, string stOldValue, string stNewValue, bool SetNewValue, int ReplaceType)
	{
		int result = CurrentValue;
		try
		{
			int num = 0;
			float num2 = 0f;
			if (stOldValue != string.Empty)
			{
				num = Convert.ToInt32(stOldValue);
			}
			if (stNewValue != string.Empty)
			{
				num2 = Convert.ToSingle(stNewValue);
			}
			if (SetNewValue)
			{
				switch (ReplaceType)
				{
				case 0:
					result = Convert.ToInt32(num2);
					break;
				case 1:
					result = Convert.ToInt32((float)CurrentValue + num2);
					break;
				case 2:
					result = Convert.ToInt32((float)CurrentValue - num2);
					break;
				case 3:
					result = Convert.ToInt32((float)CurrentValue * num2);
					break;
				case 4:
					result = Convert.ToInt32((float)CurrentValue / num2);
					break;
				}
			}
			else if (CurrentValue == num)
			{
				switch (ReplaceType)
				{
				case 0:
					result = Convert.ToInt32(num2);
					break;
				case 1:
					result = Convert.ToInt32((float)CurrentValue + num2);
					break;
				case 2:
					result = Convert.ToInt32((float)CurrentValue - num2);
					break;
				case 3:
					result = Convert.ToInt32((float)CurrentValue * num2);
					break;
				case 4:
					result = Convert.ToInt32((float)CurrentValue / num2);
					break;
				}
			}
		}
		catch
		{
			DKBox.Show(GProD.TX(403), string.Empty);
		}
		return result;
	}

	public static int RIC(int CurrentValue, string stOldValue, string stNewValue, bool SetNewValue, int ReplaceType)
	{
		int result = CurrentValue;
		int num = 0;
		float value = 0f;
		if (stOldValue != string.Empty)
		{
			num = Convert.ToInt32(stOldValue);
		}
		if (stNewValue != string.Empty)
		{
			value = Convert.ToSingle(stNewValue);
		}
		if (SetNewValue)
		{
			result = Convert.ToInt32(value);
		}
		else if (CurrentValue == num)
		{
			result = Convert.ToInt32(value);
		}
		return result;
	}

	public static float ReplaceFloat(float CurrentValue, string stOldValue, string stNewValue, bool SetNewValue, int ReplaceType)
	{
		float result = CurrentValue;
		try
		{
			float num = 0f;
			float num2 = 0f;
			if (stOldValue != string.Empty)
			{
				num = Convert.ToSingle(stOldValue);
			}
			if (stNewValue != string.Empty)
			{
				num2 = Convert.ToSingle(stNewValue);
			}
			if (SetNewValue)
			{
				switch (ReplaceType)
				{
				case 0:
					result = num2;
					break;
				case 1:
					result = CurrentValue + num2;
					break;
				case 2:
					result = CurrentValue - num2;
					break;
				case 3:
					result = CurrentValue * num2;
					break;
				case 4:
					result = CurrentValue / num2;
					break;
				}
			}
			else if (CurrentValue == num)
			{
				switch (ReplaceType)
				{
				case 0:
					result = num2;
					break;
				case 1:
					result = CurrentValue + num2;
					break;
				case 2:
					result = CurrentValue - num2;
					break;
				case 3:
					result = CurrentValue * num2;
					break;
				case 4:
					result = CurrentValue / num2;
					break;
				}
			}
		}
		catch
		{
			DKBox.Show(GProD.TX(403), string.Empty);
		}
		return result;
	}

	private void method_1(ATaskTempl ataskTempl_0, TreeNode treeNode_0)
	{
		string stOldValue = textBox_0.Text;
		string stNewValue = textBox_1.Text;
		bool flag = true;
		if (radioButton_1.Checked && !treeNode_0.Checked)
		{
			flag = false;
		}
		if (flag)
		{
			if (radioButton_4.Checked)
			{
				switch (int_0)
				{
				case 5241:
				{
					for (int num104 = 0; num104 < ataskTempl_0.m_plHistoryChangeKeyValue2.Length; num104++)
					{
						ataskTempl_0.m_plHistoryChangeKeyValue2[num104] = RI(ataskTempl_0.m_plHistoryChangeKeyValue2[num104], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 4851:
				{
					for (int num96 = 0; num96 < ataskTempl_0.m_plPersonChangeKeyValue2.Length; num96++)
					{
						ataskTempl_0.m_plPersonChangeKeyValue2[num96] = RI(ataskTempl_0.m_plPersonChangeKeyValue2[num96], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 0:
					if (comboBox_2.SelectedIndex < 13)
					{
						stOldValue = comboBox_2.SelectedIndex.ToString();
					}
					else
					{
						switch (comboBox_2.SelectedIndex)
						{
						case 13:
							stOldValue = 100.ToString();
							break;
						case 14:
							stOldValue = 101.ToString();
							break;
						case 15:
							stOldValue = 102.ToString();
							break;
						case 16:
							stOldValue = 103.ToString();
							break;
						case 17:
							stOldValue = 104.ToString();
							break;
						case 18:
							stOldValue = 105.ToString();
							break;
						case 19:
							stOldValue = 106.ToString();
							break;
						case 20:
							stOldValue = 107.ToString();
							break;
						case 21:
							stOldValue = 108.ToString();
							break;
						case 22:
							stOldValue = 109.ToString();
							break;
						case 23:
							stOldValue = 110.ToString();
							break;
						}
					}
					if (comboBox_3.SelectedIndex < 13)
					{
						stNewValue = comboBox_3.SelectedIndex.ToString();
					}
					else
					{
						switch (comboBox_3.SelectedIndex)
						{
						case 13:
							stNewValue = 100.ToString();
							break;
						case 14:
							stNewValue = 101.ToString();
							break;
						case 15:
							stNewValue = 102.ToString();
							break;
						case 16:
							stNewValue = 103.ToString();
							break;
						case 17:
							stNewValue = 104.ToString();
							break;
						case 18:
							stNewValue = 105.ToString();
							break;
						case 19:
							stNewValue = 106.ToString();
							break;
						case 20:
							stNewValue = 107.ToString();
							break;
						case 21:
							stNewValue = 108.ToString();
							break;
						case 22:
							stNewValue = 109.ToString();
							break;
						case 23:
							stNewValue = 110.ToString();
							break;
						}
					}
					ataskTempl_0.m_ulType = RIC(ataskTempl_0.m_ulType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					GlobalFunctions.UpdateNode(treeNode_0, ataskTempl_0, 1, GProD.imageList2.Images.Count - 2, GProD.imageList2.Images.Count - 1);
					mainEditor_0.textBox_m_szName.ForeColor = treeNode_0.ForeColor;
					break;
				case 1:
					ataskTempl_0.m_ulTimeLimit = RI(ataskTempl_0.m_ulTimeLimit, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 2:
					ataskTempl_0.m_bOfflineFail = RB(ataskTempl_0.m_bOfflineFail, checkBox_0.Checked);
					break;
				case 3:
					ataskTempl_0.m_bAbsFail = RB(ataskTempl_0.m_bAbsFail, checkBox_0.Checked);
					break;
				case 4:
					ataskTempl_0.m_tmAbsFailTime.year = RI(ataskTempl_0.m_tmAbsFailTime.year, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 5:
					ataskTempl_0.m_tmAbsFailTime.month = RI(ataskTempl_0.m_tmAbsFailTime.month, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 6:
					ataskTempl_0.m_tmAbsFailTime.day = RI(ataskTempl_0.m_tmAbsFailTime.day, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 7:
					ataskTempl_0.m_tmAbsFailTime.hour = RI(ataskTempl_0.m_tmAbsFailTime.hour, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 8:
					ataskTempl_0.m_tmAbsFailTime.min = RI(ataskTempl_0.m_tmAbsFailTime.min, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 9:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_tmAbsFailTime.wday = RIC(ataskTempl_0.m_tmAbsFailTime.wday, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 10:
					ataskTempl_0.m_bItemNotTakeOff = RB(ataskTempl_0.m_bItemNotTakeOff, checkBox_0.Checked);
					break;
				case 11:
					ataskTempl_0.m_bAbsTime = RB(ataskTempl_0.m_bAbsTime, checkBox_0.Checked);
					break;
				case 12:
				{
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					for (int num100 = 0; num100 < ataskTempl_0.m_tmType.Length; num100++)
					{
						ataskTempl_0.m_tmType[num100] = ReplaceByteCombo(ataskTempl_0.m_tmType[num100], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 13:
				{
					for (int num92 = 0; num92 < ataskTempl_0.m_tmStart.Length; num92++)
					{
						ataskTempl_0.m_tmStart[num92].year = RI(ataskTempl_0.m_tmStart[num92].year, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 14:
				{
					for (int num83 = 0; num83 < ataskTempl_0.m_tmStart.Length; num83++)
					{
						ataskTempl_0.m_tmStart[num83].month = RI(ataskTempl_0.m_tmStart[num83].month, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 15:
				{
					for (int num76 = 0; num76 < ataskTempl_0.m_tmStart.Length; num76++)
					{
						ataskTempl_0.m_tmStart[num76].day = RI(ataskTempl_0.m_tmStart[num76].day, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 16:
				{
					for (int num69 = 0; num69 < ataskTempl_0.m_tmStart.Length; num69++)
					{
						ataskTempl_0.m_tmStart[num69].hour = RI(ataskTempl_0.m_tmStart[num69].hour, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 17:
				{
					for (int num60 = 0; num60 < ataskTempl_0.m_tmStart.Length; num60++)
					{
						ataskTempl_0.m_tmStart[num60].min = RI(ataskTempl_0.m_tmStart[num60].min, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 18:
				{
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					for (int num53 = 0; num53 < ataskTempl_0.m_tmStart.Length; num53++)
					{
						ataskTempl_0.m_tmStart[num53].wday = RIC(ataskTempl_0.m_tmStart[num53].wday, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 19:
				{
					for (int num46 = 0; num46 < ataskTempl_0.m_tmEnd.Length; num46++)
					{
						ataskTempl_0.m_tmEnd[num46].year = RI(ataskTempl_0.m_tmEnd[num46].year, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 20:
				{
					for (int num16 = 0; num16 < ataskTempl_0.m_tmEnd.Length; num16++)
					{
						ataskTempl_0.m_tmEnd[num16].month = RI(ataskTempl_0.m_tmEnd[num16].month, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 21:
				{
					for (int num9 = 0; num9 < ataskTempl_0.m_tmEnd.Length; num9++)
					{
						ataskTempl_0.m_tmEnd[num9].day = RI(ataskTempl_0.m_tmEnd[num9].day, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 22:
				{
					for (int num125 = 0; num125 < ataskTempl_0.m_tmEnd.Length; num125++)
					{
						ataskTempl_0.m_tmEnd[num125].hour = RI(ataskTempl_0.m_tmEnd[num125].hour, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 23:
				{
					for (int num122 = 0; num122 < ataskTempl_0.m_tmEnd.Length; num122++)
					{
						ataskTempl_0.m_tmEnd[num122].min = RI(ataskTempl_0.m_tmEnd[num122].min, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 24:
				{
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					for (int num119 = 0; num119 < ataskTempl_0.m_tmEnd.Length; num119++)
					{
						ataskTempl_0.m_tmEnd[num119].wday = RIC(ataskTempl_0.m_tmEnd[num119].wday, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 25:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_lAvailFrequency = RIC(ataskTempl_0.m_lAvailFrequency, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 26:
					ataskTempl_0.m_lPeriodLimit = RI(ataskTempl_0.m_lPeriodLimit, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 27:
					ataskTempl_0.m_bChooseOne = RB(ataskTempl_0.m_bChooseOne, checkBox_0.Checked);
					break;
				case 28:
					ataskTempl_0.m_bRandOne = RB(ataskTempl_0.m_bRandOne, checkBox_0.Checked);
					break;
				case 29:
					ataskTempl_0.m_bExeChildInOrder = RB(ataskTempl_0.m_bExeChildInOrder, checkBox_0.Checked);
					break;
				case 30:
					ataskTempl_0.m_bParentAlsoFail = RB(ataskTempl_0.m_bParentAlsoFail, checkBox_0.Checked);
					break;
				case 31:
					ataskTempl_0.m_bParentAlsoSucc = RB(ataskTempl_0.m_bParentAlsoSucc, checkBox_0.Checked);
					break;
				case 32:
					ataskTempl_0.m_bCanGiveUp = RB(ataskTempl_0.m_bCanGiveUp, checkBox_0.Checked);
					break;
				case 33:
					ataskTempl_0.m_bCanRedo = RB(ataskTempl_0.m_bCanRedo, checkBox_0.Checked);
					break;
				case 34:
					ataskTempl_0.m_bCanRedoAfterFailure = RB(ataskTempl_0.m_bCanRedoAfterFailure, checkBox_0.Checked);
					break;
				case 35:
					ataskTempl_0.m_bClearAsGiveUp = RB(ataskTempl_0.m_bClearAsGiveUp, checkBox_0.Checked);
					break;
				case 36:
					ataskTempl_0.m_bNeedRecord = RB(ataskTempl_0.m_bNeedRecord, checkBox_0.Checked);
					break;
				case 37:
					ataskTempl_0.m_bFailAsPlayerDie = RB(ataskTempl_0.m_bFailAsPlayerDie, checkBox_0.Checked);
					break;
				case 38:
					ataskTempl_0.m_ulMaxReceiver = RI(ataskTempl_0.m_ulMaxReceiver, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 39:
					ataskTempl_0.m_bDelvInZone = RB(ataskTempl_0.m_bDelvInZone, checkBox_0.Checked);
					break;
				case 40:
					ataskTempl_0.m_ulDelvWorld = RI(ataskTempl_0.m_ulDelvWorld, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 41:
				{
					for (int num106 = 0; num106 < ataskTempl_0.m_pDelvRegion.Length; num106++)
					{
						ataskTempl_0.m_pDelvRegion[num106].zvMin.Single_0[0] = ReplaceFloat(ataskTempl_0.m_pDelvRegion[num106].zvMin.Single_0[0], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 42:
				{
					for (int num102 = 0; num102 < ataskTempl_0.m_pDelvRegion.Length; num102++)
					{
						ataskTempl_0.m_pDelvRegion[num102].zvMin.Single_0[1] = ReplaceFloat(ataskTempl_0.m_pDelvRegion[num102].zvMin.Single_0[1], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 43:
				{
					for (int num98 = 0; num98 < ataskTempl_0.m_pDelvRegion.Length; num98++)
					{
						ataskTempl_0.m_pDelvRegion[num98].zvMin.Single_0[2] = ReplaceFloat(ataskTempl_0.m_pDelvRegion[num98].zvMin.Single_0[2], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 44:
				{
					for (int num94 = 0; num94 < ataskTempl_0.m_pDelvRegion.Length; num94++)
					{
						ataskTempl_0.m_pDelvRegion[num94].zvMax.Single_0[0] = ReplaceFloat(ataskTempl_0.m_pDelvRegion[num94].zvMax.Single_0[0], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 45:
				{
					for (int num90 = 0; num90 < ataskTempl_0.m_pDelvRegion.Length; num90++)
					{
						ataskTempl_0.m_pDelvRegion[num90].zvMax.Single_0[1] = ReplaceFloat(ataskTempl_0.m_pDelvRegion[num90].zvMax.Single_0[1], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 46:
				{
					for (int num87 = 0; num87 < ataskTempl_0.m_pDelvRegion.Length; num87++)
					{
						ataskTempl_0.m_pDelvRegion[num87].zvMax.Single_0[2] = ReplaceFloat(ataskTempl_0.m_pDelvRegion[num87].zvMax.Single_0[2], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 47:
					ataskTempl_0.m_bEnterRegionFail = RB(ataskTempl_0.m_bEnterRegionFail, checkBox_0.Checked);
					break;
				case 48:
					ataskTempl_0.m_ulEnterRegionWorld = RI(ataskTempl_0.m_ulEnterRegionWorld, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 49:
				{
					for (int num81 = 0; num81 < ataskTempl_0.m_pEnterRegion.Length; num81++)
					{
						ataskTempl_0.m_pEnterRegion[num81].zvMin.Single_0[0] = ReplaceFloat(ataskTempl_0.m_pEnterRegion[num81].zvMin.Single_0[0], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 50:
				{
					for (int num78 = 0; num78 < ataskTempl_0.m_pEnterRegion.Length; num78++)
					{
						ataskTempl_0.m_pEnterRegion[num78].zvMin.Single_0[1] = ReplaceFloat(ataskTempl_0.m_pEnterRegion[num78].zvMin.Single_0[1], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 51:
				{
					for (int num74 = 0; num74 < ataskTempl_0.m_pEnterRegion.Length; num74++)
					{
						ataskTempl_0.m_pEnterRegion[num74].zvMin.Single_0[2] = ReplaceFloat(ataskTempl_0.m_pEnterRegion[num74].zvMin.Single_0[2], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 52:
				{
					for (int num71 = 0; num71 < ataskTempl_0.m_pEnterRegion.Length; num71++)
					{
						ataskTempl_0.m_pEnterRegion[num71].zvMax.Single_0[0] = ReplaceFloat(ataskTempl_0.m_pEnterRegion[num71].zvMax.Single_0[0], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 53:
				{
					for (int num67 = 0; num67 < ataskTempl_0.m_pEnterRegion.Length; num67++)
					{
						ataskTempl_0.m_pEnterRegion[num67].zvMax.Single_0[1] = ReplaceFloat(ataskTempl_0.m_pEnterRegion[num67].zvMax.Single_0[1], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 54:
				{
					for (int num64 = 0; num64 < ataskTempl_0.m_pEnterRegion.Length; num64++)
					{
						ataskTempl_0.m_pEnterRegion[num64].zvMax.Single_0[2] = ReplaceFloat(ataskTempl_0.m_pEnterRegion[num64].zvMax.Single_0[2], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 55:
					ataskTempl_0.m_bLeaveRegionFail = RB(ataskTempl_0.m_bLeaveRegionFail, checkBox_0.Checked);
					break;
				case 56:
					ataskTempl_0.m_ulLeaveRegionWorld = RI(ataskTempl_0.m_ulLeaveRegionWorld, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 57:
				{
					for (int num58 = 0; num58 < ataskTempl_0.m_pLeaveRegion.Length; num58++)
					{
						ataskTempl_0.m_pLeaveRegion[num58].zvMin.Single_0[0] = ReplaceFloat(ataskTempl_0.m_pLeaveRegion[num58].zvMin.Single_0[0], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 58:
				{
					for (int num55 = 0; num55 < ataskTempl_0.m_pLeaveRegion.Length; num55++)
					{
						ataskTempl_0.m_pLeaveRegion[num55].zvMin.Single_0[1] = ReplaceFloat(ataskTempl_0.m_pLeaveRegion[num55].zvMin.Single_0[1], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 59:
				{
					for (int num51 = 0; num51 < ataskTempl_0.m_pLeaveRegion.Length; num51++)
					{
						ataskTempl_0.m_pLeaveRegion[num51].zvMin.Single_0[2] = ReplaceFloat(ataskTempl_0.m_pLeaveRegion[num51].zvMin.Single_0[2], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 60:
				{
					for (int num48 = 0; num48 < ataskTempl_0.m_pLeaveRegion.Length; num48++)
					{
						ataskTempl_0.m_pLeaveRegion[num48].zvMax.Single_0[0] = ReplaceFloat(ataskTempl_0.m_pLeaveRegion[num48].zvMax.Single_0[0], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 61:
				{
					for (int num44 = 0; num44 < ataskTempl_0.m_pLeaveRegion.Length; num44++)
					{
						ataskTempl_0.m_pLeaveRegion[num44].zvMax.Single_0[1] = ReplaceFloat(ataskTempl_0.m_pLeaveRegion[num44].zvMax.Single_0[1], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 62:
				{
					for (int num41 = 0; num41 < ataskTempl_0.m_pLeaveRegion.Length; num41++)
					{
						ataskTempl_0.m_pLeaveRegion[num41].zvMax.Single_0[2] = ReplaceFloat(ataskTempl_0.m_pLeaveRegion[num41].zvMax.Single_0[2], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 63:
					ataskTempl_0.m_bLeaveForceFail = RB(ataskTempl_0.m_bLeaveForceFail, checkBox_0.Checked);
					break;
				case 64:
					ataskTempl_0.m_bTransTo = RB(ataskTempl_0.m_bTransTo, checkBox_0.Checked);
					break;
				case 65:
					ataskTempl_0.m_ulTransWldId = RI(ataskTempl_0.m_ulTransWldId, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 66:
					ataskTempl_0.m_TransPt.Single_0[0] = ReplaceFloat(ataskTempl_0.m_TransPt.Single_0[0], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 67:
					ataskTempl_0.m_TransPt.Single_0[1] = ReplaceFloat(ataskTempl_0.m_TransPt.Single_0[1], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 68:
					ataskTempl_0.m_TransPt.Single_0[2] = ReplaceFloat(ataskTempl_0.m_TransPt.Single_0[2], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 69:
					ataskTempl_0.m_lMonsCtrl = RI(ataskTempl_0.m_lMonsCtrl, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 70:
					ataskTempl_0.m_bTrigCtrl = RB(ataskTempl_0.m_bTrigCtrl, checkBox_0.Checked);
					break;
				case 71:
					ataskTempl_0.m_bAutoDeliver = RB(ataskTempl_0.m_bAutoDeliver, checkBox_0.Checked);
					break;
				case 72:
					ataskTempl_0.m_bDisplayInExclusiveUI = RB(ataskTempl_0.m_bDisplayInExclusiveUI, checkBox_0.Checked);
					break;
				case 73:
					ataskTempl_0.m_bReadyToNotifyServer = RB(ataskTempl_0.m_bReadyToNotifyServer, checkBox_0.Checked);
					break;
				case 74:
					ataskTempl_0.m_bUsedInTokenShop = RB(ataskTempl_0.m_bUsedInTokenShop, checkBox_0.Checked);
					break;
				case 75:
					ataskTempl_0.m_bDeathTrig = RB(ataskTempl_0.m_bDeathTrig, checkBox_0.Checked);
					break;
				case 76:
					ataskTempl_0.m_bClearAcquired = RB(ataskTempl_0.m_bClearAcquired, checkBox_0.Checked);
					break;
				case 77:
					ataskTempl_0.m_ulSuitableLevel = RI(ataskTempl_0.m_ulSuitableLevel, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 78:
					ataskTempl_0.m_bShowPrompt = RB(ataskTempl_0.m_bShowPrompt, checkBox_0.Checked);
					break;
				case 79:
					ataskTempl_0.m_bKeyTask = RB(ataskTempl_0.m_bKeyTask, checkBox_0.Checked);
					GlobalFunctions.UpdateNode(treeNode_0, ataskTempl_0, 1, GProD.imageList2.Images.Count - 2, GProD.imageList2.Images.Count - 1);
					mainEditor_0.textBox_m_szName.ForeColor = treeNode_0.ForeColor;
					break;
				case 80:
					ataskTempl_0.m_ulDelvNPC = RI(ataskTempl_0.m_ulDelvNPC, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 81:
					ataskTempl_0.m_ulAwardNPC = RI(ataskTempl_0.m_ulAwardNPC, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 82:
					ataskTempl_0.m_bSkillTask = RB(ataskTempl_0.m_bSkillTask, checkBox_0.Checked);
					break;
				case 83:
					ataskTempl_0.m_bCanSeekOut = RB(ataskTempl_0.m_bCanSeekOut, checkBox_0.Checked);
					break;
				case 84:
					ataskTempl_0.m_bShowDirection = RB(ataskTempl_0.m_bShowDirection, checkBox_0.Checked);
					break;
				case 85:
					ataskTempl_0.m_bMarriage = RB(ataskTempl_0.m_bMarriage, checkBox_0.Checked);
					break;
				case 86:
				{
					for (int num14 = 0; num14 < ataskTempl_0.m_plChangeKey.Length; num14++)
					{
						ataskTempl_0.m_plChangeKey[num14] = RI(ataskTempl_0.m_plChangeKey[num14], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 87:
				{
					for (int num11 = 0; num11 < ataskTempl_0.m_plChangeKeyValue.Length; num11++)
					{
						ataskTempl_0.m_plChangeKeyValue[num11] = RI(ataskTempl_0.m_plChangeKeyValue[num11], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 88:
				{
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					for (int num7 = 0; num7 < ataskTempl_0.m_pbChangeType.Length; num7++)
					{
						ataskTempl_0.m_pbChangeType[num7] = Convert.ToByte(ReplaceByteCombo(Convert.ToByte(ataskTempl_0.m_pbChangeType[num7]), stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex));
					}
					break;
				}
				case 89:
					ataskTempl_0.m_bSwitchSceneFail = RB(ataskTempl_0.m_bSwitchSceneFail, checkBox_0.Checked);
					break;
				case 90:
					ataskTempl_0.m_bHidden = RB(ataskTempl_0.m_bHidden, checkBox_0.Checked);
					break;
				case 91:
					ataskTempl_0.m_bDeliverySkill = RB(ataskTempl_0.m_bDeliverySkill, checkBox_0.Checked);
					break;
				case 92:
					ataskTempl_0.m_iDeliveredSkillID = RI(ataskTempl_0.m_iDeliveredSkillID, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 93:
					ataskTempl_0.m_iDeliveredSkillLevel = RI(ataskTempl_0.m_iDeliveredSkillLevel, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 94:
					ataskTempl_0.m_bShowGfxFinished = RB(ataskTempl_0.m_bShowGfxFinished, checkBox_0.Checked);
					break;
				case 95:
					ataskTempl_0.m_bChangePQRanking = RB(ataskTempl_0.m_bChangePQRanking, checkBox_0.Checked);
					break;
				case 96:
					ataskTempl_0.m_bCompareItemAndInventory = RB(ataskTempl_0.m_bCompareItemAndInventory, checkBox_0.Checked);
					break;
				case 97:
					ataskTempl_0.m_ulInventorySlotNum = RI(ataskTempl_0.m_ulInventorySlotNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 98:
					ataskTempl_0.m_bTowerTask = RB(ataskTempl_0.m_bTowerTask, checkBox_0.Checked);
					break;
				case 99:
					ataskTempl_0.m_bHomeTask = RB(ataskTempl_0.m_bHomeTask, checkBox_0.Checked);
					break;
				case 100:
					ataskTempl_0.m_bDeliverInHostHome = RB(ataskTempl_0.m_bDeliverInHostHome, checkBox_0.Checked);
					break;
				case 101:
					ataskTempl_0.m_bFinishInHostHome = RB(ataskTempl_0.m_bFinishInHostHome, checkBox_0.Checked);
					break;
				case 102:
					ataskTempl_0.m_bPQTask = RB(ataskTempl_0.m_bPQTask, checkBox_0.Checked);
					break;
				case 103:
					ataskTempl_0.m_bPQSubTask = RB(ataskTempl_0.m_bPQSubTask, checkBox_0.Checked);
					break;
				case 104:
					ataskTempl_0.m_bClearContrib = RB(ataskTempl_0.m_bClearContrib, checkBox_0.Checked);
					break;
				case 105:
				{
					for (int num126 = 0; num126 < ataskTempl_0.m_MonstersContrib.Length; num126++)
					{
						ataskTempl_0.m_MonstersContrib[num126].m_ulMonsterTemplId = RI(ataskTempl_0.m_MonstersContrib[num126].m_ulMonsterTemplId, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 106:
				{
					for (int num124 = 0; num124 < ataskTempl_0.m_MonstersContrib.Length; num124++)
					{
						ataskTempl_0.m_MonstersContrib[num124].m_iWholeContrib = RI(ataskTempl_0.m_MonstersContrib[num124].m_iWholeContrib, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 107:
				{
					for (int num123 = 0; num123 < ataskTempl_0.m_MonstersContrib.Length; num123++)
					{
						ataskTempl_0.m_MonstersContrib[num123].m_iShareContrib = RI(ataskTempl_0.m_MonstersContrib[num123].m_iShareContrib, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 108:
				{
					for (int num121 = 0; num121 < ataskTempl_0.m_MonstersContrib.Length; num121++)
					{
						ataskTempl_0.m_MonstersContrib[num121].m_iPersonalWholeContrib = RI(ataskTempl_0.m_MonstersContrib[num121].m_iPersonalWholeContrib, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 109:
					ataskTempl_0.m_iPremNeedRecordTasksNum = RI(ataskTempl_0.m_iPremNeedRecordTasksNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 110:
					ataskTempl_0.m_bShowByNeedRecordTasksNum = RB(ataskTempl_0.m_bShowByNeedRecordTasksNum, checkBox_0.Checked);
					break;
				case 111:
					ataskTempl_0.m_iPremiseFactionContrib = RI(ataskTempl_0.m_iPremiseFactionContrib, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 112:
					ataskTempl_0.m_bShowByFactionContrib = RB(ataskTempl_0.m_bShowByFactionContrib, checkBox_0.Checked);
					break;
				case 113:
					ataskTempl_0.m_bAccountTaskLimit = RB(ataskTempl_0.m_bAccountTaskLimit, checkBox_0.Checked);
					break;
				case 114:
					ataskTempl_0.m_bRoleTaskLimit = RB(ataskTempl_0.m_bRoleTaskLimit, checkBox_0.Checked);
					break;
				case 115:
					ataskTempl_0.m_ulAccountTaskLimitCnt = RI(ataskTempl_0.m_ulAccountTaskLimitCnt, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 116:
					ataskTempl_0.m_bLeaveFactionFail = RB(ataskTempl_0.m_bLeaveFactionFail, checkBox_0.Checked);
					break;
				case 117:
					ataskTempl_0.m_bNotIncCntWhenFailed = RB(ataskTempl_0.m_bNotIncCntWhenFailed, checkBox_0.Checked);
					break;
				case 118:
					ataskTempl_0.m_bNotClearItemWhenFailed = RB(ataskTempl_0.m_bNotClearItemWhenFailed, checkBox_0.Checked);
					break;
				case 119:
					ataskTempl_0.m_bDisplayInTitleTaskUI = RB(ataskTempl_0.m_bDisplayInTitleTaskUI, checkBox_0.Checked);
					break;
				case 120:
					ataskTempl_0.m_ucPremiseTransformedForm = ReplaceByte(ataskTempl_0.m_ucPremiseTransformedForm, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 121:
					ataskTempl_0.m_bShowByTransformed = RB(ataskTempl_0.m_bShowByTransformed, checkBox_0.Checked);
					break;
				case 122:
					ataskTempl_0.m_ulPremise_Lev_Min = RI(ataskTempl_0.m_ulPremise_Lev_Min, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 123:
					ataskTempl_0.m_ulPremise_Lev_Max = RI(ataskTempl_0.m_ulPremise_Lev_Max, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 124:
					ataskTempl_0.m_bPremCheckMaxHistoryLevel = Convert.ToInt32(RB(Convert.ToBoolean(ataskTempl_0.m_bPremCheckMaxHistoryLevel), checkBox_0.Checked));
					break;
				case 125:
					ataskTempl_0.m_bShowByLev = RB(ataskTempl_0.m_bShowByLev, checkBox_0.Checked);
					break;
				case 126:
					ataskTempl_0.m_bPremCheckReincarnation = RB(ataskTempl_0.m_bPremCheckReincarnation, checkBox_0.Checked);
					break;
				case 127:
					ataskTempl_0.m_ulPremReincarnationMin = RI(ataskTempl_0.m_ulPremReincarnationMin, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 128:
					ataskTempl_0.m_ulPremReincarnationMax = RI(ataskTempl_0.m_ulPremReincarnationMax, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 129:
					ataskTempl_0.m_bShowByReincarnation = RB(ataskTempl_0.m_bShowByReincarnation, checkBox_0.Checked);
					break;
				case 130:
					ataskTempl_0.m_bPremCheckRealmLevel = RB(ataskTempl_0.m_bPremCheckRealmLevel, checkBox_0.Checked);
					break;
				case 131:
					ataskTempl_0.m_ulPremRealmLevelMin = RI(ataskTempl_0.m_ulPremRealmLevelMin, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 132:
					ataskTempl_0.m_ulPremRealmLevelMax = RI(ataskTempl_0.m_ulPremRealmLevelMax, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 133:
					ataskTempl_0.m_bPremCheckRealmExpFull = RB(ataskTempl_0.m_bPremCheckRealmExpFull, checkBox_0.Checked);
					break;
				case 134:
					ataskTempl_0.m_bShowByRealmLevel = RB(ataskTempl_0.m_bShowByRealmLevel, checkBox_0.Checked);
					break;
				case 135:
				{
					for (int num120 = 0; num120 < ataskTempl_0.m_PremItems.Length; num120++)
					{
						ataskTempl_0.m_PremItems[num120].m_ulItemTemplId = RI(ataskTempl_0.m_PremItems[num120].m_ulItemTemplId, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 136:
				{
					for (int num118 = 0; num118 < ataskTempl_0.m_PremItems.Length; num118++)
					{
						ataskTempl_0.m_PremItems[num118].m_bCommonItem = RB(ataskTempl_0.m_PremItems[num118].m_bCommonItem, checkBox_0.Checked);
					}
					break;
				}
				case 137:
				{
					for (int num117 = 0; num117 < ataskTempl_0.m_PremItems.Length; num117++)
					{
						ataskTempl_0.m_PremItems[num117].m_ulItemNum = RI(ataskTempl_0.m_PremItems[num117].m_ulItemNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 138:
				{
					for (int num116 = 0; num116 < ataskTempl_0.m_PremItems.Length; num116++)
					{
						ataskTempl_0.m_PremItems[num116].m_fProb = ReplaceFloat(ataskTempl_0.m_PremItems[num116].m_fProb, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 139:
				{
					for (int num115 = 0; num115 < ataskTempl_0.m_PremItems.Length; num115++)
					{
						ataskTempl_0.m_PremItems[num115].m_lPeriod = RI(ataskTempl_0.m_PremItems[num115].m_lPeriod, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 140:
					ataskTempl_0.m_bShowByItems = RB(ataskTempl_0.m_bShowByItems, checkBox_0.Checked);
					break;
				case 141:
					ataskTempl_0.m_bPremItemsAnyOne = RB(ataskTempl_0.m_bPremItemsAnyOne, checkBox_0.Checked);
					break;
				case 142:
				{
					for (int num114 = 0; num114 < ataskTempl_0.m_GivenItems.Length; num114++)
					{
						ataskTempl_0.m_GivenItems[num114].m_ulItemTemplId = RI(ataskTempl_0.m_GivenItems[num114].m_ulItemTemplId, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 143:
				{
					for (int num113 = 0; num113 < ataskTempl_0.m_GivenItems.Length; num113++)
					{
						ataskTempl_0.m_GivenItems[num113].m_bCommonItem = RB(ataskTempl_0.m_GivenItems[num113].m_bCommonItem, checkBox_0.Checked);
					}
					break;
				}
				case 144:
				{
					for (int num112 = 0; num112 < ataskTempl_0.m_GivenItems.Length; num112++)
					{
						ataskTempl_0.m_GivenItems[num112].m_ulItemNum = RI(ataskTempl_0.m_GivenItems[num112].m_ulItemNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 145:
				{
					for (int num111 = 0; num111 < ataskTempl_0.m_GivenItems.Length; num111++)
					{
						ataskTempl_0.m_GivenItems[num111].m_fProb = ReplaceFloat(ataskTempl_0.m_GivenItems[num111].m_fProb, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 146:
				{
					for (int num110 = 0; num110 < ataskTempl_0.m_GivenItems.Length; num110++)
					{
						ataskTempl_0.m_GivenItems[num110].m_lPeriod = RI(ataskTempl_0.m_GivenItems[num110].m_lPeriod, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 147:
					ataskTempl_0.m_ulPremise_Deposit = RI(ataskTempl_0.m_ulPremise_Deposit, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 148:
					ataskTempl_0.m_bShowByDeposit = RB(ataskTempl_0.m_bShowByDeposit, checkBox_0.Checked);
					break;
				case 149:
					ataskTempl_0.m_lPremise_Reputation = RI(ataskTempl_0.m_lPremise_Reputation, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 150:
					ataskTempl_0.m_lPremise_RepuMax = RI(ataskTempl_0.m_lPremise_RepuMax, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 151:
					ataskTempl_0.m_bShowByRepu = RB(ataskTempl_0.m_bShowByRepu, checkBox_0.Checked);
					break;
				case 152:
				{
					for (int num109 = 0; num109 < ataskTempl_0.m_ulPremise_Task_Count; num109++)
					{
						ataskTempl_0.m_ulPremise_Tasks[num109] = RI(ataskTempl_0.m_ulPremise_Tasks[num109], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 153:
					ataskTempl_0.m_bShowByPreTask = RB(ataskTempl_0.m_bShowByPreTask, checkBox_0.Checked);
					break;
				case 154:
					ataskTempl_0.m_ulPremise_Task_Least_Num = RI(ataskTempl_0.m_ulPremise_Task_Least_Num, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 155:
					if (comboBox_2.SelectedIndex < 9)
					{
						stOldValue = comboBox_2.SelectedIndex.ToString();
					}
					else
					{
						switch (comboBox_2.SelectedIndex)
						{
						case 9:
							stOldValue = 20.ToString();
							break;
						case 10:
							stOldValue = 30.ToString();
							break;
						case 11:
							stOldValue = 21.ToString();
							break;
						case 12:
							stOldValue = 31.ToString();
							break;
						case 13:
							stOldValue = 22.ToString();
							break;
						case 14:
							stOldValue = 32.ToString();
							break;
						case 15:
							stOldValue = 40.ToString();
							break;
						case 16:
							stOldValue = 41.ToString();
							break;
						}
					}
					if (comboBox_3.SelectedIndex < 9)
					{
						stNewValue = comboBox_3.SelectedIndex.ToString();
					}
					else
					{
						switch (comboBox_3.SelectedIndex)
						{
						case 9:
							stNewValue = 20.ToString();
							break;
						case 10:
							stNewValue = 30.ToString();
							break;
						case 11:
							stNewValue = 21.ToString();
							break;
						case 12:
							stNewValue = 31.ToString();
							break;
						case 13:
							stNewValue = 22.ToString();
							break;
						case 14:
							stNewValue = 32.ToString();
							break;
						case 15:
							stNewValue = 40.ToString();
							break;
						case 16:
							stNewValue = 41.ToString();
							break;
						}
					}
					ataskTempl_0.m_ulPremise_Period = RIC(ataskTempl_0.m_ulPremise_Period, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 156:
					ataskTempl_0.m_bShowByPeriod = RB(ataskTempl_0.m_bShowByPeriod, checkBox_0.Checked);
					break;
				case 157:
					ataskTempl_0.m_ulPremise_Faction = Convert.ToInt32(RB(Convert.ToBoolean(ataskTempl_0.m_ulPremise_Faction), checkBox_0.Checked));
					break;
				case 158:
					stOldValue = (6 - comboBox_2.SelectedIndex).ToString();
					stNewValue = (6 - comboBox_3.SelectedIndex).ToString();
					ataskTempl_0.m_iPremise_FactionRole = RIC(ataskTempl_0.m_iPremise_FactionRole, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 159:
					ataskTempl_0.m_bShowByFaction = RB(ataskTempl_0.m_bShowByFaction, checkBox_0.Checked);
					break;
				case 160:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_ulGender = RIC(ataskTempl_0.m_ulGender, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 161:
					ataskTempl_0.m_bShowByGender = RB(ataskTempl_0.m_bShowByGender, checkBox_0.Checked);
					break;
				case 162:
					ataskTempl_0.m_bShowByOccup = RB(ataskTempl_0.m_bShowByOccup, checkBox_0.Checked);
					break;
				case 163:
					ataskTempl_0.m_bPremise_Spouse = RB(ataskTempl_0.m_bPremise_Spouse, checkBox_0.Checked);
					break;
				case 164:
					ataskTempl_0.m_bShowBySpouse = RB(ataskTempl_0.m_bShowBySpouse, checkBox_0.Checked);
					break;
				case 165:
					ataskTempl_0.m_bPremiseWeddingOwner = RB(ataskTempl_0.m_bPremiseWeddingOwner, checkBox_0.Checked);
					break;
				case 166:
					ataskTempl_0.m_bShowByWeddingOwner = RB(ataskTempl_0.m_bShowByWeddingOwner, checkBox_0.Checked);
					break;
				case 167:
					ataskTempl_0.m_bGM = RB(ataskTempl_0.m_bGM, checkBox_0.Checked);
					GlobalFunctions.UpdateNode(treeNode_0, ataskTempl_0, 1, GProD.imageList2.Images.Count - 2, GProD.imageList2.Images.Count - 1);
					mainEditor_0.textBox_m_szName.ForeColor = treeNode_0.ForeColor;
					break;
				case 168:
					ataskTempl_0.m_bShieldUser = RB(ataskTempl_0.m_bShieldUser, checkBox_0.Checked);
					break;
				case 169:
					ataskTempl_0.m_bShowByRMB = RB(ataskTempl_0.m_bShowByRMB, checkBox_0.Checked);
					break;
				case 170:
					ataskTempl_0.m_ulPremRMBMin = RI(ataskTempl_0.m_ulPremRMBMin, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 171:
					ataskTempl_0.m_ulPremRMBMax = RI(ataskTempl_0.m_ulPremRMBMax, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 172:
					ataskTempl_0.m_bCharTime = RB(ataskTempl_0.m_bCharTime, checkBox_0.Checked);
					break;
				case 173:
					ataskTempl_0.m_bShowByCharTime = RB(ataskTempl_0.m_bShowByCharTime, checkBox_0.Checked);
					break;
				case 174:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_iCharStartTime = RIC(ataskTempl_0.m_iCharStartTime, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 175:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_iCharEndTime = RIC(ataskTempl_0.m_iCharEndTime, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 176:
					ataskTempl_0.m_tmCharEndTime.year = RI(ataskTempl_0.m_tmCharEndTime.year, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 177:
					ataskTempl_0.m_tmCharEndTime.month = RI(ataskTempl_0.m_tmCharEndTime.month, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 178:
					ataskTempl_0.m_tmCharEndTime.day = RI(ataskTempl_0.m_tmCharEndTime.day, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 179:
					ataskTempl_0.m_tmCharEndTime.hour = RI(ataskTempl_0.m_tmCharEndTime.hour, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 180:
					ataskTempl_0.m_tmCharEndTime.min = RI(ataskTempl_0.m_tmCharEndTime.min, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 181:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_tmCharEndTime.wday = RIC(ataskTempl_0.m_tmCharEndTime.wday, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 182:
					ataskTempl_0.m_ulCharTimeGreaterThan = RI(ataskTempl_0.m_ulCharTimeGreaterThan, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 183:
					ataskTempl_0.m_ulPremise_Cotask = RI(ataskTempl_0.m_ulPremise_Cotask, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 184:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_ulCoTaskCond = RIC(ataskTempl_0.m_ulCoTaskCond, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 185:
				{
					for (int num108 = 0; num108 < ataskTempl_0.m_ulMutexTaskCount; num108++)
					{
						ataskTempl_0.m_ulMutexTasks[num108] = RI(ataskTempl_0.m_ulMutexTasks[num108], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 186:
					ataskTempl_0.m_lSkillLev[0] = RI(ataskTempl_0.m_lSkillLev[0], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 187:
					ataskTempl_0.m_lSkillLev[1] = RI(ataskTempl_0.m_lSkillLev[1], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 188:
					ataskTempl_0.m_lSkillLev[2] = RI(ataskTempl_0.m_lSkillLev[2], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 189:
					ataskTempl_0.m_lSkillLev[3] = RI(ataskTempl_0.m_lSkillLev[3], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 190:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_DynTaskType = ReplaceByteCombo(ataskTempl_0.m_DynTaskType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 191:
					ataskTempl_0.m_ulSpecialAward = RI(ataskTempl_0.m_ulSpecialAward, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 192:
					ataskTempl_0.m_bTeamwork = RB(ataskTempl_0.m_bTeamwork, checkBox_0.Checked);
					break;
				case 193:
					ataskTempl_0.m_bRcvByTeam = RB(ataskTempl_0.m_bRcvByTeam, checkBox_0.Checked);
					break;
				case 194:
					ataskTempl_0.m_bSharedTask = RB(ataskTempl_0.m_bSharedTask, checkBox_0.Checked);
					break;
				case 195:
					ataskTempl_0.m_bSharedAchieved = RB(ataskTempl_0.m_bSharedAchieved, checkBox_0.Checked);
					break;
				case 196:
					ataskTempl_0.m_bCheckTeammate = RB(ataskTempl_0.m_bCheckTeammate, checkBox_0.Checked);
					break;
				case 197:
					ataskTempl_0.m_fTeammateDist = ReplaceFloat(ataskTempl_0.m_fTeammateDist, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 198:
					ataskTempl_0.m_bAllFail = RB(ataskTempl_0.m_bAllFail, checkBox_0.Checked);
					break;
				case 199:
					ataskTempl_0.m_bCapFail = RB(ataskTempl_0.m_bCapFail, checkBox_0.Checked);
					break;
				case 200:
					ataskTempl_0.m_bCapSucc = RB(ataskTempl_0.m_bCapSucc, checkBox_0.Checked);
					break;
				case 201:
					ataskTempl_0.m_fSuccDist = ReplaceFloat(ataskTempl_0.m_fSuccDist, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 202:
					ataskTempl_0.m_bDismAsSelfFail = RB(ataskTempl_0.m_bDismAsSelfFail, checkBox_0.Checked);
					break;
				case 203:
					ataskTempl_0.m_bRcvChckMem = RB(ataskTempl_0.m_bRcvChckMem, checkBox_0.Checked);
					break;
				case 204:
					ataskTempl_0.m_fRcvMemDist = ReplaceFloat(ataskTempl_0.m_fRcvMemDist, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 205:
					ataskTempl_0.m_bCntByMemPos = RB(ataskTempl_0.m_bCntByMemPos, checkBox_0.Checked);
					break;
				case 206:
					ataskTempl_0.m_fCntMemDist = ReplaceFloat(ataskTempl_0.m_fCntMemDist, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 207:
					ataskTempl_0.m_bAllSucc = RB(ataskTempl_0.m_bAllSucc, checkBox_0.Checked);
					break;
				case 208:
					ataskTempl_0.m_bCoupleOnly = RB(ataskTempl_0.m_bCoupleOnly, checkBox_0.Checked);
					break;
				case 209:
					ataskTempl_0.m_bDistinguishedOcc = RB(ataskTempl_0.m_bDistinguishedOcc, checkBox_0.Checked);
					break;
				case 210:
				{
					for (int num107 = 0; num107 < ataskTempl_0.m_TeamMemsWanted.Length; num107++)
					{
						ataskTempl_0.m_TeamMemsWanted[num107].m_ulLevelMin = RI(ataskTempl_0.m_TeamMemsWanted[num107].m_ulLevelMin, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 211:
				{
					for (int num105 = 0; num105 < ataskTempl_0.m_TeamMemsWanted.Length; num105++)
					{
						ataskTempl_0.m_TeamMemsWanted[num105].m_ulLevelMax = RI(ataskTempl_0.m_TeamMemsWanted[num105].m_ulLevelMax, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 212:
				{
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					for (int num103 = 0; num103 < ataskTempl_0.m_TeamMemsWanted.Length; num103++)
					{
						ataskTempl_0.m_TeamMemsWanted[num103].m_ulRace = RIC(ataskTempl_0.m_TeamMemsWanted[num103].m_ulRace, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 213:
				{
					stOldValue = (comboBox_2.SelectedIndex - 1).ToString();
					stNewValue = (comboBox_3.SelectedIndex - 1).ToString();
					for (int num101 = 0; num101 < ataskTempl_0.m_TeamMemsWanted.Length; num101++)
					{
						ataskTempl_0.m_TeamMemsWanted[num101].m_ulOccupation = RIC(ataskTempl_0.m_TeamMemsWanted[num101].m_ulOccupation, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 214:
				{
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					for (int num99 = 0; num99 < ataskTempl_0.m_TeamMemsWanted.Length; num99++)
					{
						ataskTempl_0.m_TeamMemsWanted[num99].m_ulGender = RIC(ataskTempl_0.m_TeamMemsWanted[num99].m_ulGender, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 215:
				{
					for (int num97 = 0; num97 < ataskTempl_0.m_TeamMemsWanted.Length; num97++)
					{
						ataskTempl_0.m_TeamMemsWanted[num97].m_ulMinCount = RI(ataskTempl_0.m_TeamMemsWanted[num97].m_ulMinCount, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 216:
				{
					for (int num95 = 0; num95 < ataskTempl_0.m_TeamMemsWanted.Length; num95++)
					{
						ataskTempl_0.m_TeamMemsWanted[num95].m_ulMaxCount = RI(ataskTempl_0.m_TeamMemsWanted[num95].m_ulMaxCount, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 217:
				{
					for (int num93 = 0; num93 < ataskTempl_0.m_TeamMemsWanted.Length; num93++)
					{
						ataskTempl_0.m_TeamMemsWanted[num93].m_ulTask = RI(ataskTempl_0.m_TeamMemsWanted[num93].m_ulTask, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 218:
				{
					for (int num91 = 0; num91 < ataskTempl_0.m_TeamMemsWanted.Length; num91++)
					{
						ataskTempl_0.m_TeamMemsWanted[num91].m_iForce = RIC(ataskTempl_0.m_TeamMemsWanted[num91].m_iForce, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 219:
					ataskTempl_0.m_bShowByTeam = RB(ataskTempl_0.m_bShowByTeam, checkBox_0.Checked);
					break;
				case 220:
					ataskTempl_0.m_bPremNeedComp = RB(ataskTempl_0.m_bPremNeedComp, checkBox_0.Checked);
					break;
				case 221:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_nPremExp1AndOrExp2 = RIC(ataskTempl_0.m_nPremExp1AndOrExp2, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 222:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prem1KeyValue.nLeftType = RIC(ataskTempl_0.m_Prem1KeyValue.nLeftType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 223:
					ataskTempl_0.m_Prem1KeyValue.lLeftNum = RI(ataskTempl_0.m_Prem1KeyValue.lLeftNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 224:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prem1KeyValue.nCompOper = RIC(ataskTempl_0.m_Prem1KeyValue.nCompOper, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 225:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prem1KeyValue.nRightType = RIC(ataskTempl_0.m_Prem1KeyValue.nRightType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 226:
					ataskTempl_0.m_Prem1KeyValue.lRightNum = RI(ataskTempl_0.m_Prem1KeyValue.lRightNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 227:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prem2KeyValue.nLeftType = RIC(ataskTempl_0.m_Prem2KeyValue.nLeftType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 228:
					ataskTempl_0.m_Prem2KeyValue.lLeftNum = RI(ataskTempl_0.m_Prem2KeyValue.lLeftNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 229:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prem2KeyValue.nCompOper = RIC(ataskTempl_0.m_Prem2KeyValue.nCompOper, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 230:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prem2KeyValue.nRightType = RIC(ataskTempl_0.m_Prem2KeyValue.nRightType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 231:
					ataskTempl_0.m_Prem2KeyValue.lRightNum = RI(ataskTempl_0.m_Prem2KeyValue.lRightNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 232:
					ataskTempl_0.m_bPremCheckForce = RB(ataskTempl_0.m_bPremCheckForce, checkBox_0.Checked);
					break;
				case 233:
					ataskTempl_0.m_iPremForce = RI(ataskTempl_0.m_iPremForce, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 234:
					ataskTempl_0.m_bShowByForce = RB(ataskTempl_0.m_bShowByForce, checkBox_0.Checked);
					break;
				case 235:
					ataskTempl_0.m_iPremForceReputation = RI(ataskTempl_0.m_iPremForceReputation, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 236:
					ataskTempl_0.m_bShowByForceReputation = RB(ataskTempl_0.m_bShowByForceReputation, checkBox_0.Checked);
					break;
				case 237:
					ataskTempl_0.m_iPremForceContribution = RI(ataskTempl_0.m_iPremForceContribution, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 238:
					ataskTempl_0.m_bShowByForceContribution = RB(ataskTempl_0.m_bShowByForceContribution, checkBox_0.Checked);
					break;
				case 239:
					ataskTempl_0.m_iPremForceExp = RI(ataskTempl_0.m_iPremForceExp, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 240:
					ataskTempl_0.m_bShowByForceExp = RB(ataskTempl_0.m_bShowByForceExp, checkBox_0.Checked);
					break;
				case 241:
					ataskTempl_0.m_iPremForceSP = RI(ataskTempl_0.m_iPremForceSP, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 242:
					ataskTempl_0.m_bShowByForceSP = RB(ataskTempl_0.m_bShowByForceSP, checkBox_0.Checked);
					break;
				case 243:
					ataskTempl_0.m_iPremForceActivityLevel = RI(ataskTempl_0.m_iPremForceActivityLevel, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 244:
					ataskTempl_0.m_bShowByForceActivityLevel = RB(ataskTempl_0.m_bShowByForceActivityLevel, checkBox_0.Checked);
					break;
				case 245:
					ataskTempl_0.m_bPremIsKing = RB(ataskTempl_0.m_bPremIsKing, checkBox_0.Checked);
					break;
				case 246:
					ataskTempl_0.m_bShowByKing = RB(ataskTempl_0.m_bShowByKing, checkBox_0.Checked);
					break;
				case 247:
					ataskTempl_0.m_bPremNotInTeam = RB(ataskTempl_0.m_bPremNotInTeam, checkBox_0.Checked);
					break;
				case 248:
					ataskTempl_0.m_bShowByNotInTeam = RB(ataskTempl_0.m_bShowByNotInTeam, checkBox_0.Checked);
					break;
				case 249:
					ataskTempl_0.m_iPremTitleNumRequired = RI(ataskTempl_0.m_iPremTitleNumRequired, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 250:
				{
					for (int num89 = 0; num89 < ataskTempl_0.m_PremTitles.Length; num89++)
					{
						ataskTempl_0.m_PremTitles[num89] = RI(ataskTempl_0.m_PremTitles[num89], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 251:
					ataskTempl_0.m_bShowByTitle = RB(ataskTempl_0.m_bShowByTitle, checkBox_0.Checked);
					break;
				case 252:
					ataskTempl_0.m_iPremHistoryStageIndex[0] = RI(ataskTempl_0.m_iPremHistoryStageIndex[0], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 253:
					ataskTempl_0.m_iPremHistoryStageIndex[1] = RI(ataskTempl_0.m_iPremHistoryStageIndex[1], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 254:
					ataskTempl_0.m_bShowByHistoryStage = RB(ataskTempl_0.m_bShowByHistoryStage, checkBox_0.Checked);
					break;
				case 255:
					ataskTempl_0.m_ulPremGeneralCardCount = RI(ataskTempl_0.m_ulPremGeneralCardCount, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 256:
					ataskTempl_0.m_bShowByGeneralCard = RB(ataskTempl_0.m_bShowByGeneralCard, checkBox_0.Checked);
					break;
				case 257:
					stOldValue = (comboBox_2.SelectedIndex - 1).ToString();
					stNewValue = (comboBox_3.SelectedIndex - 1).ToString();
					ataskTempl_0.m_iPremGeneralCardRank = RIC(ataskTempl_0.m_iPremGeneralCardRank, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 258:
					ataskTempl_0.m_ulPremGeneralCardRankCount = RI(ataskTempl_0.m_ulPremGeneralCardRankCount, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 259:
					ataskTempl_0.m_bShowByGeneralCardRank = RB(ataskTempl_0.m_bShowByGeneralCardRank, checkBox_0.Checked);
					break;
				case 260:
					ataskTempl_0.m_ulPremIconStateID = RI(ataskTempl_0.m_ulPremIconStateID, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 261:
					ataskTempl_0.m_bShowByIconStateID = RB(ataskTempl_0.m_bShowByIconStateID, checkBox_0.Checked);
					break;
				case 262:
					ataskTempl_0.m_iVIPLevelMin = RI(ataskTempl_0.m_iVIPLevelMin, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 263:
					ataskTempl_0.m_iVIPLevelMax = RI(ataskTempl_0.m_iVIPLevelMax, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 264:
					ataskTempl_0.m_bShowByVIPLevel = RB(ataskTempl_0.m_bShowByVIPLevel, checkBox_0.Checked);
					break;
				case 265:
					ataskTempl_0.m_bPremNoHome = RB(ataskTempl_0.m_bPremNoHome, checkBox_0.Checked);
					break;
				case 266:
					ataskTempl_0.m_iPremHomeLevelMin = RI(ataskTempl_0.m_iPremHomeLevelMin, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 267:
					ataskTempl_0.m_iPremHomeLevelMax = RI(ataskTempl_0.m_iPremHomeLevelMax, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 268:
					ataskTempl_0.m_bShowByHomeLevel = RB(ataskTempl_0.m_bShowByHomeLevel, checkBox_0.Checked);
					break;
				case 270:
					ataskTempl_0.m_iPremHomeResourceLevelMin = RI(ataskTempl_0.m_iPremHomeResourceLevelMin, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 271:
					ataskTempl_0.m_iPremHomeResourceLevelMax = RI(ataskTempl_0.m_iPremHomeResourceLevelMax, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 272:
					ataskTempl_0.m_bShowByHomeResourceLevel = RB(ataskTempl_0.m_bShowByHomeResourceLevel, checkBox_0.Checked);
					break;
				case 273:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_iPremHomeFactoryLevelType = RIC(ataskTempl_0.m_iPremHomeFactoryLevelType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 274:
					ataskTempl_0.m_iPremHomeFactoryLevelMin = RI(ataskTempl_0.m_iPremHomeFactoryLevelMin, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 275:
					ataskTempl_0.m_iPremHomeFactoryLevelMax = RI(ataskTempl_0.m_iPremHomeFactoryLevelMax, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 276:
					ataskTempl_0.m_bShowByHomeFactoryLevel = RB(ataskTempl_0.m_bShowByHomeFactoryLevel, checkBox_0.Checked);
					break;
				case 277:
					ataskTempl_0.m_iPremHomeFlourishMin = RI(ataskTempl_0.m_iPremHomeFlourishMin, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 278:
					ataskTempl_0.m_iPremHomeFlourishMax = RI(ataskTempl_0.m_iPremHomeFlourishMax, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 279:
					ataskTempl_0.m_bShowByHomeFlourish = RB(ataskTempl_0.m_bShowByHomeFlourish, checkBox_0.Checked);
					break;
				case 280:
					ataskTempl_0.m_bPremHomeStorageTask = RB(ataskTempl_0.m_bPremHomeStorageTask, checkBox_0.Checked);
					break;
				case 281:
					ataskTempl_0.m_bShowByHomeStorageTask = RB(ataskTempl_0.m_bShowByHomeStorageTask, checkBox_0.Checked);
					break;
				case 282:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_enumMethod = RIC(ataskTempl_0.m_enumMethod, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 283:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_enumFinishType = RIC(ataskTempl_0.m_enumFinishType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 284:
				{
					for (int num88 = 0; num88 < ataskTempl_0.m_PlayerWanted.Length; num88++)
					{
						ataskTempl_0.m_PlayerWanted[num88].m_ulPlayerNum = RI(ataskTempl_0.m_PlayerWanted[num88].m_ulPlayerNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 285:
				{
					for (int num86 = 0; num86 < ataskTempl_0.m_PlayerWanted.Length; num86++)
					{
						ataskTempl_0.m_PlayerWanted[num86].m_ulDropItemId = RI(ataskTempl_0.m_PlayerWanted[num86].m_ulDropItemId, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 286:
				{
					for (int num85 = 0; num85 < ataskTempl_0.m_PlayerWanted.Length; num85++)
					{
						ataskTempl_0.m_PlayerWanted[num85].m_ulDropItemCount = RI(ataskTempl_0.m_PlayerWanted[num85].m_ulDropItemCount, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 287:
				{
					for (int num84 = 0; num84 < ataskTempl_0.m_PlayerWanted.Length; num84++)
					{
						ataskTempl_0.m_PlayerWanted[num84].m_bDropCmnItem = RB(ataskTempl_0.m_PlayerWanted[num84].m_bDropCmnItem, checkBox_0.Checked);
					}
					break;
				}
				case 288:
				{
					for (int num82 = 0; num82 < ataskTempl_0.m_PlayerWanted.Length; num82++)
					{
						ataskTempl_0.m_PlayerWanted[num82].m_fDropProb = ReplaceFloat(ataskTempl_0.m_PlayerWanted[num82].m_fDropProb, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 289:
				{
					for (int num80 = 0; num80 < ataskTempl_0.m_PlayerWanted.Length; num80++)
					{
						ataskTempl_0.m_PlayerWanted[num80].m_Requirements.m_ulOccupations = RI(ataskTempl_0.m_PlayerWanted[num80].m_Requirements.m_ulOccupations, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 290:
				{
					for (int num79 = 0; num79 < ataskTempl_0.m_PlayerWanted.Length; num79++)
					{
						ataskTempl_0.m_PlayerWanted[num79].m_Requirements.m_iMinLevel = RI(ataskTempl_0.m_PlayerWanted[num79].m_Requirements.m_iMinLevel, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 291:
				{
					for (int num77 = 0; num77 < ataskTempl_0.m_PlayerWanted.Length; num77++)
					{
						ataskTempl_0.m_PlayerWanted[num77].m_Requirements.m_iMaxLevel = RI(ataskTempl_0.m_PlayerWanted[num77].m_Requirements.m_iMaxLevel, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 292:
				{
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					for (int num75 = 0; num75 < ataskTempl_0.m_PlayerWanted.Length; num75++)
					{
						ataskTempl_0.m_PlayerWanted[num75].m_Requirements.m_iGender = RIC(ataskTempl_0.m_PlayerWanted[num75].m_Requirements.m_iGender, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 293:
				{
					for (int num73 = 0; num73 < ataskTempl_0.m_PlayerWanted.Length; num73++)
					{
						ataskTempl_0.m_PlayerWanted[num73].m_Requirements.m_iForce = RI(ataskTempl_0.m_PlayerWanted[num73].m_Requirements.m_iForce, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 294:
				{
					for (int num72 = 0; num72 < ataskTempl_0.m_PlayerWanted.Length; num72++)
					{
						ataskTempl_0.m_PlayerWanted[num72].m_Requirements.ModelCheck = RB(ataskTempl_0.m_PlayerWanted[num72].m_Requirements.ModelCheck, checkBox_0.Checked);
					}
					break;
				}
				case 295:
				{
					for (int num70 = 0; num70 < ataskTempl_0.m_PlayerWanted.Length; num70++)
					{
						ataskTempl_0.m_PlayerWanted[num70].m_Requirements.ModelType[0] = ReplaceByte(ataskTempl_0.m_PlayerWanted[num70].m_Requirements.ModelType[0], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 296:
				{
					for (int num68 = 0; num68 < ataskTempl_0.m_PlayerWanted.Length; num68++)
					{
						ataskTempl_0.m_PlayerWanted[num68].m_Requirements.ModelType[1] = ReplaceByte(ataskTempl_0.m_PlayerWanted[num68].m_Requirements.ModelType[1], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 297:
				{
					for (int num66 = 0; num66 < ataskTempl_0.m_PlayerWanted.Length; num66++)
					{
						ataskTempl_0.m_PlayerWanted[num66].m_Requirements.ModelType[2] = ReplaceByte(ataskTempl_0.m_PlayerWanted[num66].m_Requirements.ModelType[2], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 298:
				{
					for (int num65 = 0; num65 < ataskTempl_0.m_MonsterWanted.Length; num65++)
					{
						ataskTempl_0.m_MonsterWanted[num65].m_ulMonsterTemplId = RI(ataskTempl_0.m_MonsterWanted[num65].m_ulMonsterTemplId, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 299:
				{
					for (int num63 = 0; num63 < ataskTempl_0.m_MonsterWanted.Length; num63++)
					{
						ataskTempl_0.m_MonsterWanted[num63].m_ulMonsterNum = RI(ataskTempl_0.m_MonsterWanted[num63].m_ulMonsterNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 300:
				{
					for (int num62 = 0; num62 < ataskTempl_0.m_MonsterWanted.Length; num62++)
					{
						ataskTempl_0.m_MonsterWanted[num62].m_ulDropItemId = RI(ataskTempl_0.m_MonsterWanted[num62].m_ulDropItemId, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 301:
				{
					for (int num61 = 0; num61 < ataskTempl_0.m_MonsterWanted.Length; num61++)
					{
						ataskTempl_0.m_MonsterWanted[num61].m_ulDropItemCount = RI(ataskTempl_0.m_MonsterWanted[num61].m_ulDropItemCount, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 302:
				{
					for (int num59 = 0; num59 < ataskTempl_0.m_MonsterWanted.Length; num59++)
					{
						ataskTempl_0.m_MonsterWanted[num59].m_bDropCmnItem = RB(ataskTempl_0.m_MonsterWanted[num59].m_bDropCmnItem, checkBox_0.Checked);
					}
					break;
				}
				case 303:
				{
					for (int num57 = 0; num57 < ataskTempl_0.m_MonsterWanted.Length; num57++)
					{
						ataskTempl_0.m_MonsterWanted[num57].m_fDropProb = ReplaceFloat(ataskTempl_0.m_MonsterWanted[num57].m_fDropProb, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 304:
				{
					for (int num56 = 0; num56 < ataskTempl_0.m_MonsterWanted.Length; num56++)
					{
						ataskTempl_0.m_MonsterWanted[num56].m_bKillerLev = ReplaceByte(ataskTempl_0.m_MonsterWanted[num56].m_bKillerLev, ataskTempl_0.m_MonsterWanted[num56].m_bKillerLev.ToString(), checkBox_0.Checked ? Class16.smethod_0(1648934925) : Class16.smethod_0(1648924112), SetNewValue: true, 0);
					}
					break;
				}
				case 305:
				{
					for (int num54 = 0; num54 < ataskTempl_0.m_MonsterWanted.Length; num54++)
					{
						ataskTempl_0.m_MonsterWanted[num54].m_iDPH = RI(ataskTempl_0.m_MonsterWanted[num54].m_iDPH, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 306:
				{
					for (int num52 = 0; num52 < ataskTempl_0.m_MonsterWanted.Length; num52++)
					{
						ataskTempl_0.m_MonsterWanted[num52].m_iDPS = RI(ataskTempl_0.m_MonsterWanted[num52].m_iDPS, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 307:
				{
					for (int num50 = 0; num50 < ataskTempl_0.m_ItemsWanted.Length; num50++)
					{
						ataskTempl_0.m_ItemsWanted[num50].m_ulItemTemplId = RI(ataskTempl_0.m_ItemsWanted[num50].m_ulItemTemplId, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 308:
				{
					for (int num49 = 0; num49 < ataskTempl_0.m_MonsterWanted.Length; num49++)
					{
						ataskTempl_0.m_ItemsWanted[num49].m_bCommonItem = RB(ataskTempl_0.m_ItemsWanted[num49].m_bCommonItem, checkBox_0.Checked);
					}
					break;
				}
				case 309:
				{
					for (int num47 = 0; num47 < ataskTempl_0.m_ItemsWanted.Length; num47++)
					{
						ataskTempl_0.m_ItemsWanted[num47].m_ulItemNum = RI(ataskTempl_0.m_ItemsWanted[num47].m_ulItemNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 310:
				{
					for (int num45 = 0; num45 < ataskTempl_0.m_ItemsWanted.Length; num45++)
					{
						ataskTempl_0.m_ItemsWanted[num45].m_fProb = ReplaceFloat(ataskTempl_0.m_ItemsWanted[num45].m_fProb, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 311:
				{
					for (int num43 = 0; num43 < ataskTempl_0.m_ItemsWanted.Length; num43++)
					{
						ataskTempl_0.m_ItemsWanted[num43].m_lPeriod = RI(ataskTempl_0.m_ItemsWanted[num43].m_lPeriod, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 312:
					ataskTempl_0.m_ulGoldWanted = RI(ataskTempl_0.m_ulGoldWanted, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 313:
					ataskTempl_0.m_iFactionContribWanted = RI(ataskTempl_0.m_iFactionContribWanted, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 314:
					ataskTempl_0.m_iFactionExpContribWanted = RI(ataskTempl_0.m_iFactionExpContribWanted, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 315:
					ataskTempl_0.m_ulNPCToProtect = RI(ataskTempl_0.m_ulNPCToProtect, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 316:
					ataskTempl_0.m_ulProtectTimeLen = RI(ataskTempl_0.m_ulProtectTimeLen, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 317:
					ataskTempl_0.m_ulNPCMoving = RI(ataskTempl_0.m_ulNPCMoving, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 318:
					ataskTempl_0.m_ulNPCDestSite = RI(ataskTempl_0.m_ulNPCDestSite, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 319:
					ataskTempl_0.m_ulReachSiteId = RI(ataskTempl_0.m_ulReachSiteId, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 320:
				{
					for (int num42 = 0; num42 < ataskTempl_0.m_pReachSite.Length; num42++)
					{
						ataskTempl_0.m_pReachSite[num42].zvMin.Single_0[0] = ReplaceFloat(ataskTempl_0.m_pReachSite[num42].zvMin.Single_0[0], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 321:
				{
					for (int num40 = 0; num40 < ataskTempl_0.m_pReachSite.Length; num40++)
					{
						ataskTempl_0.m_pReachSite[num40].zvMin.Single_0[1] = ReplaceFloat(ataskTempl_0.m_pReachSite[num40].zvMin.Single_0[1], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 322:
				{
					for (int num39 = 0; num39 < ataskTempl_0.m_pDelvRegion.Length; num39++)
					{
						ataskTempl_0.m_pReachSite[num39].zvMin.Single_0[2] = ReplaceFloat(ataskTempl_0.m_pReachSite[num39].zvMin.Single_0[2], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 323:
				{
					for (int num38 = 0; num38 < ataskTempl_0.m_pReachSite.Length; num38++)
					{
						ataskTempl_0.m_pReachSite[num38].zvMax.Single_0[0] = ReplaceFloat(ataskTempl_0.m_pReachSite[num38].zvMax.Single_0[0], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 324:
				{
					for (int num37 = 0; num37 < ataskTempl_0.m_pReachSite.Length; num37++)
					{
						ataskTempl_0.m_pReachSite[num37].zvMax.Single_0[1] = ReplaceFloat(ataskTempl_0.m_pReachSite[num37].zvMax.Single_0[1], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 325:
				{
					for (int num36 = 0; num36 < ataskTempl_0.m_pReachSite.Length; num36++)
					{
						ataskTempl_0.m_pReachSite[num36].zvMax.Single_0[2] = ReplaceFloat(ataskTempl_0.m_pReachSite[num36].zvMax.Single_0[2], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 326:
					ataskTempl_0.m_ulWaitTime = RI(ataskTempl_0.m_ulWaitTime, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 327:
					ataskTempl_0.m_TreasureStartZone.Single_0[0] = ReplaceFloat(ataskTempl_0.m_TreasureStartZone.Single_0[0], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 328:
					ataskTempl_0.m_TreasureStartZone.Single_0[1] = ReplaceFloat(ataskTempl_0.m_TreasureStartZone.Single_0[1], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 329:
					ataskTempl_0.m_TreasureStartZone.Single_0[2] = ReplaceFloat(ataskTempl_0.m_TreasureStartZone.Single_0[2], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 330:
					ataskTempl_0.m_ucZonesNumX = ReplaceByte(ataskTempl_0.m_ucZonesNumX, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 331:
					ataskTempl_0.m_ucZonesNumZ = ReplaceByte(ataskTempl_0.m_ucZonesNumZ, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 332:
					ataskTempl_0.m_ucZoneSide = ReplaceByte(ataskTempl_0.m_ucZoneSide, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 333:
					ataskTempl_0.m_ulLeaveSiteId = RI(ataskTempl_0.m_ulLeaveSiteId, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 334:
				{
					for (int num35 = 0; num35 < ataskTempl_0.m_pLeaveSite.Length; num35++)
					{
						ataskTempl_0.m_pLeaveSite[num35].zvMin.Single_0[0] = ReplaceFloat(ataskTempl_0.m_pLeaveSite[num35].zvMin.Single_0[0], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 335:
				{
					for (int num34 = 0; num34 < ataskTempl_0.m_pLeaveSite.Length; num34++)
					{
						ataskTempl_0.m_pLeaveSite[num34].zvMin.Single_0[1] = ReplaceFloat(ataskTempl_0.m_pLeaveSite[num34].zvMin.Single_0[1], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 336:
				{
					for (int num33 = 0; num33 < ataskTempl_0.m_pDelvRegion.Length; num33++)
					{
						ataskTempl_0.m_pLeaveSite[num33].zvMin.Single_0[2] = ReplaceFloat(ataskTempl_0.m_pLeaveSite[num33].zvMin.Single_0[2], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 337:
				{
					for (int num32 = 0; num32 < ataskTempl_0.m_pLeaveSite.Length; num32++)
					{
						ataskTempl_0.m_pLeaveSite[num32].zvMax.Single_0[0] = ReplaceFloat(ataskTempl_0.m_pLeaveSite[num32].zvMax.Single_0[0], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 338:
				{
					for (int num31 = 0; num31 < ataskTempl_0.m_pLeaveSite.Length; num31++)
					{
						ataskTempl_0.m_pLeaveSite[num31].zvMax.Single_0[1] = ReplaceFloat(ataskTempl_0.m_pLeaveSite[num31].zvMax.Single_0[1], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 339:
				{
					for (int num30 = 0; num30 < ataskTempl_0.m_pLeaveSite.Length; num30++)
					{
						ataskTempl_0.m_pLeaveSite[num30].zvMax.Single_0[2] = ReplaceFloat(ataskTempl_0.m_pLeaveSite[num30].zvMax.Single_0[2], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 340:
					ataskTempl_0.m_bFinNeedComp = RB(ataskTempl_0.m_bFinNeedComp, checkBox_0.Checked);
					break;
				case 341:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_nFinExp1AndOrExp2 = RIC(ataskTempl_0.m_nFinExp1AndOrExp2, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 342:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Fin1KeyValue.nLeftType = RIC(ataskTempl_0.m_Fin1KeyValue.nLeftType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 343:
					ataskTempl_0.m_Fin1KeyValue.lLeftNum = RI(ataskTempl_0.m_Fin1KeyValue.lLeftNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 344:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Fin1KeyValue.nCompOper = RIC(ataskTempl_0.m_Fin1KeyValue.nCompOper, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 345:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Fin1KeyValue.nRightType = RIC(ataskTempl_0.m_Fin1KeyValue.nRightType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 346:
					ataskTempl_0.m_Fin1KeyValue.lRightNum = RI(ataskTempl_0.m_Fin1KeyValue.lRightNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 347:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Fin2KeyValue.nLeftType = RIC(ataskTempl_0.m_Fin2KeyValue.nLeftType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 348:
					ataskTempl_0.m_Fin2KeyValue.lLeftNum = RI(ataskTempl_0.m_Fin2KeyValue.lLeftNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 349:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Fin2KeyValue.nCompOper = RIC(ataskTempl_0.m_Fin2KeyValue.nCompOper, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 350:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Fin2KeyValue.nRightType = RIC(ataskTempl_0.m_Fin2KeyValue.nRightType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 351:
					ataskTempl_0.m_Fin2KeyValue.lRightNum = RI(ataskTempl_0.m_Fin2KeyValue.lRightNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 352:
					ataskTempl_0.m_ucTransformedForm = ReplaceByte(ataskTempl_0.m_ucTransformedForm, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 353:
					ataskTempl_0.m_ulReachLevel = RI(ataskTempl_0.m_ulReachLevel, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 354:
					ataskTempl_0.m_ulReachReincarnationCount = RI(ataskTempl_0.m_ulReachReincarnationCount, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 355:
					ataskTempl_0.m_ulReachRealmLevel = RI(ataskTempl_0.m_ulReachRealmLevel, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 356:
					stOldValue = Extensions.GetDictionaryElementKeyByIndex(GProD.emotionslist, comboBox_2.SelectedIndex).ToString();
					stNewValue = Extensions.GetDictionaryElementKeyByIndex(GProD.emotionslist, comboBox_3.SelectedIndex).ToString();
					ataskTempl_0.m_uiEmotion = RIC(ataskTempl_0.m_uiEmotion, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 357:
					ataskTempl_0.m_ulTMIconStateID = RI(ataskTempl_0.m_ulTMIconStateID, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 358:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_ulTMHomeLevelType = RIC(ataskTempl_0.m_ulTMHomeLevelType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 359:
					ataskTempl_0.m_ulTMReachHomeLevel = RI(ataskTempl_0.m_ulTMReachHomeLevel, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 360:
					ataskTempl_0.m_ulTMReachHomeFlourish = RI(ataskTempl_0.m_ulTMReachHomeFlourish, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 361:
				{
					for (int num29 = 0; num29 < ataskTempl_0.m_HomeItemsWanted.Length; num29++)
					{
						ataskTempl_0.m_HomeItemsWanted[num29].m_ulHomeItemTid = RI(ataskTempl_0.m_HomeItemsWanted[num29].m_ulHomeItemTid, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 362:
				{
					for (int num28 = 0; num28 < ataskTempl_0.m_HomeItemsWanted.Length; num28++)
					{
						ataskTempl_0.m_HomeItemsWanted[num28].m_ulHomeItemCount = RI(ataskTempl_0.m_HomeItemsWanted[num28].m_ulHomeItemCount, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 363:
					ataskTempl_0.m_ulParent = RI(ataskTempl_0.m_ulParent, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 364:
					ataskTempl_0.m_ulPrevSibling = RI(ataskTempl_0.m_ulPrevSibling, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 365:
					ataskTempl_0.m_ulNextSibling = RI(ataskTempl_0.m_ulNextSibling, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 366:
					ataskTempl_0.m_ulFirstChild = RI(ataskTempl_0.m_ulFirstChild, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 367:
					ataskTempl_0.m_bIsLibraryTask = RB(ataskTempl_0.m_bIsLibraryTask, checkBox_0.Checked);
					break;
				case 368:
					ataskTempl_0.m_fLibraryTasksProbability = ReplaceFloat(ataskTempl_0.m_fLibraryTasksProbability, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 369:
					ataskTempl_0.m_bIsUniqueStorageTask = RB(ataskTempl_0.m_bIsUniqueStorageTask, checkBox_0.Checked);
					break;
				case 370:
					ataskTempl_0.m_iWorldContribution = RI(ataskTempl_0.m_iWorldContribution, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 371:
					ataskTempl_0.m_bCanAwardOnCarrier = RB(ataskTempl_0.m_bCanAwardOnCarrier, checkBox_0.Checked);
					break;
				case 372:
					ataskTempl_0.m_bNotOpenWithItem = RB(ataskTempl_0.m_bNotOpenWithItem, checkBox_0.Checked);
					break;
				case 373:
					ataskTempl_0.m_bMonsterTotalCount = RB(ataskTempl_0.m_bMonsterTotalCount, checkBox_0.Checked);
					break;
				case 374:
					ataskTempl_0.m_ulBindOnCarrierId = RI(ataskTempl_0.m_ulBindOnCarrierId, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 375:
					ataskTempl_0.m_ulTMReachArenaCount = RI(ataskTempl_0.m_ulTMReachArenaCount, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 376:
					ataskTempl_0.m_iPremArenaWinCount = RI(ataskTempl_0.m_iPremArenaWinCount, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 377:
					ataskTempl_0.m_bPremReachArenaWinCount = RB(ataskTempl_0.m_bPremReachArenaWinCount, checkBox_0.Checked);
					break;
				case 378:
					ataskTempl_0.m_bShowByReachArenaWinCount = RB(ataskTempl_0.m_bShowByReachArenaWinCount, checkBox_0.Checked);
					break;
				case 379:
					ataskTempl_0.m_usZoneMapID = ReplaceShort(ataskTempl_0.m_usZoneMapID, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 380:
					ataskTempl_0.m_ulTMReachArenaWinCount = RI(ataskTempl_0.m_ulTMReachArenaWinCount, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 381:
					ataskTempl_0.m_bWriteSpecialLog = RB(ataskTempl_0.m_bWriteSpecialLog, checkBox_0.Checked);
					break;
				case 382:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_TaskEventType = RIC(ataskTempl_0.m_TaskEventType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 383:
					ataskTempl_0.m_usTaskEventTimeOrScore = Convert.ToInt16(RI(ataskTempl_0.m_usTaskEventTimeOrScore, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex));
					break;
				case 384:
				{
					for (int num27 = 0; num27 < ataskTempl_0.TaskEventMonsterData.Length; num27++)
					{
						ataskTempl_0.TaskEventMonsterData[num27].Id = RI(ataskTempl_0.TaskEventMonsterData[num27].Id, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 385:
				{
					for (int num26 = 0; num26 < ataskTempl_0.TaskEventMonsterData.Length; num26++)
					{
						ataskTempl_0.TaskEventMonsterData[num26].Value = ReplaceFloat(ataskTempl_0.TaskEventMonsterData[num26].Value, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 386:
				{
					for (int num25 = 0; num25 < ataskTempl_0.TaskEventMineData.Length; num25++)
					{
						ataskTempl_0.TaskEventMineData[num25].Id = RI(ataskTempl_0.TaskEventMineData[num25].Id, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 387:
				{
					for (int num24 = 0; num24 < ataskTempl_0.TaskEventMineData.Length; num24++)
					{
						ataskTempl_0.TaskEventMineData[num24].Value = ReplaceFloat(ataskTempl_0.TaskEventMineData[num24].Value, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 388:
				{
					for (int num23 = 0; num23 < ataskTempl_0.TaskEventTaskData.Length; num23++)
					{
						ataskTempl_0.TaskEventTaskData[num23].Id = RI(ataskTempl_0.TaskEventTaskData[num23].Id, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 389:
				{
					for (int num22 = 0; num22 < ataskTempl_0.TaskEventTaskData.Length; num22++)
					{
						ataskTempl_0.TaskEventTaskData[num22].Value = ReplaceFloat(ataskTempl_0.TaskEventTaskData[num22].Value, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 390:
					ataskTempl_0.m_bCheckFactionMember = RB(ataskTempl_0.m_bCheckFactionMember, checkBox_0.Checked);
					break;
				case 391:
					ataskTempl_0.m_iFactionMember = RI(ataskTempl_0.m_iFactionMember, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 392:
					ataskTempl_0.m_bSpecialLogic = RB(ataskTempl_0.m_bSpecialLogic, checkBox_0.Checked);
					break;
				case 393:
					ataskTempl_0.m_bPremFaction = RB(ataskTempl_0.m_bPremFaction, checkBox_0.Checked);
					break;
				case 394:
					ataskTempl_0.m_iPremFactionScore = RI(ataskTempl_0.m_iPremFactionScore, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 395:
					ataskTempl_0.m_bShowByFactionScore = RB(ataskTempl_0.m_bShowByFactionScore, checkBox_0.Checked);
					break;
				case 396:
					ataskTempl_0.m_iPremFactionMoney = RI(ataskTempl_0.m_iPremFactionMoney, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 397:
					ataskTempl_0.m_bShowByFactionMoney = RB(ataskTempl_0.m_bShowByFactionMoney, checkBox_0.Checked);
					break;
				case 398:
					ataskTempl_0.m_iPremFactionPersonScore = RI(ataskTempl_0.m_iPremFactionPersonScore, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 399:
					ataskTempl_0.m_bShowByFactionPersonScore = RB(ataskTempl_0.m_bShowByFactionPersonScore, checkBox_0.Checked);
					break;
				case 400:
					ataskTempl_0.m_FactionPersonScore = Convert.ToInt16(RI(ataskTempl_0.m_FactionPersonScore, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex));
					break;
				case 401:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_usIDSpace = ReplaceShortCombo(ataskTempl_0.m_usIDSpace, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 402:
					ataskTempl_0.m_bDiscardedTask = RB(ataskTempl_0.m_bDiscardedTask, checkBox_0.Checked);
					GlobalFunctions.UpdateNode(treeNode_0, ataskTempl_0, 1, GProD.imageList2.Images.Count - 2, GProD.imageList2.Images.Count - 1);
					mainEditor_0.textBox_m_szName.ForeColor = treeNode_0.ForeColor;
					break;
				case 403:
					ataskTempl_0.m_bNoCheckTitleGot = RB(ataskTempl_0.m_bNoCheckTitleGot, checkBox_0.Checked);
					break;
				case 404:
				{
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					for (int num21 = 0; num21 < ataskTempl_0.m_ulPremise_Task_Count; num21++)
					{
						ataskTempl_0.m_usPremise_Tasks_Space[num21] = ReplaceShortCombo(ataskTempl_0.m_usPremise_Tasks_Space[num21], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 405:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_usPremise_Cotask_Space = ReplaceShortCombo(ataskTempl_0.m_usPremise_Cotask_Space, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 406:
				{
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					for (int num20 = 0; num20 < ataskTempl_0.m_ulMutexTaskCount; num20++)
					{
						ataskTempl_0.m_usMutexTasksSpace[num20] = ReplaceShortCombo(ataskTempl_0.m_usMutexTasksSpace[num20], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 407:
				{
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					for (int num19 = 0; num19 < ataskTempl_0.m_TeamMemsWanted.Length; num19++)
					{
						ataskTempl_0.m_TeamMemsWanted[num19].TeamMemTaskSpace = ReplaceShortCombo(ataskTempl_0.m_TeamMemsWanted[num19].TeamMemTaskSpace, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 408:
					ataskTempl_0.m_bBecomeMentor = RB(ataskTempl_0.m_bBecomeMentor, checkBox_0.Checked);
					break;
				case 409:
					ataskTempl_0.m_iPremMentorMorality = RI(ataskTempl_0.m_iPremMentorMorality, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 410:
					ataskTempl_0.m_bShowMentorMorality = RB(ataskTempl_0.m_bShowMentorMorality, checkBox_0.Checked);
					break;
				case 411:
					ataskTempl_0.m_iPremMentorStudentValue = RI(ataskTempl_0.m_iPremMentorStudentValue, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 412:
					ataskTempl_0.m_bShowMentorStudentValue = RB(ataskTempl_0.m_bShowMentorStudentValue, checkBox_0.Checked);
					break;
				case 413:
					ataskTempl_0.m_iPremCoupleIntimacy = RI(ataskTempl_0.m_iPremCoupleIntimacy, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 414:
					ataskTempl_0.m_bShowCoupleIntimacy = RB(ataskTempl_0.m_bShowCoupleIntimacy, checkBox_0.Checked);
					break;
				case 415:
					ataskTempl_0.TransformedDescID = RI(ataskTempl_0.TransformedDescID, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 417:
					ataskTempl_0.TMIconStateDescID = RI(ataskTempl_0.TMIconStateDescID, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 418:
				{
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					for (int num18 = 0; num18 < ataskTempl_0.TaskEventTaskData.Length; num18++)
					{
						ataskTempl_0.TaskEventTaskData[num18].IdSpace = ReplaceShortCombo(ataskTempl_0.TaskEventTaskData[num18].IdSpace, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 419:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_iTinyGameType = ReplaceByteCombo(ataskTempl_0.m_iTinyGameType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 420:
				{
					for (int num17 = 0; num17 < ataskTempl_0.m_pDelvRegion.Length; num17++)
					{
						ataskTempl_0.m_pDelvRegion[num17].MapID = RI(ataskTempl_0.m_pDelvRegion[num17].MapID, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 421:
				{
					for (int num15 = 0; num15 < ataskTempl_0.m_pEnterRegion.Length; num15++)
					{
						ataskTempl_0.m_pEnterRegion[num15].MapID = RI(ataskTempl_0.m_pEnterRegion[num15].MapID, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 422:
				{
					for (int num13 = 0; num13 < ataskTempl_0.m_pLeaveRegion.Length; num13++)
					{
						ataskTempl_0.m_pLeaveRegion[num13].MapID = RI(ataskTempl_0.m_pLeaveRegion[num13].MapID, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 423:
				{
					for (int num12 = 0; num12 < ataskTempl_0.m_pReachSite.Length; num12++)
					{
						ataskTempl_0.m_pReachSite[num12].MapID = RI(ataskTempl_0.m_pReachSite[num12].MapID, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 424:
				{
					for (int num10 = 0; num10 < ataskTempl_0.m_pLeaveSite.Length; num10++)
					{
						ataskTempl_0.m_pLeaveSite[num10].MapID = RI(ataskTempl_0.m_pLeaveSite[num10].MapID, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 425:
					ataskTempl_0.m_ulPremDeposit2 = RI(ataskTempl_0.m_ulPremDeposit2, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 426:
					ataskTempl_0.m_bShowDeposit2 = RB(ataskTempl_0.m_bShowDeposit2, checkBox_0.Checked);
					break;
				case 427:
					ataskTempl_0.m_ulGoldWanted2 = RI(ataskTempl_0.m_ulGoldWanted2, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 428:
					ataskTempl_0.m_ulCrossServerId = RI(ataskTempl_0.m_ulCrossServerId, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 429:
					ataskTempl_0.m_ulIconStateIDForAwardVar = RI(ataskTempl_0.m_ulIconStateIDForAwardVar, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 430:
					ataskTempl_0.m_lGlobalKeyForAwardVar = RI(ataskTempl_0.m_lGlobalKeyForAwardVar, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 431:
				{
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					for (int num8 = 0; num8 < ataskTempl_0.m_ulNeededTaskCount; num8++)
					{
						ataskTempl_0.m_usNeededTasksSpace[num8] = ReplaceShortCombo(ataskTempl_0.m_usNeededTasksSpace[num8], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 432:
				{
					for (int num6 = 0; num6 < ataskTempl_0.m_ulNeededTaskCount; num6++)
					{
						ataskTempl_0.m_ulNeededTasks[num6] = RI(ataskTempl_0.m_ulNeededTasks[num6], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 433:
					ataskTempl_0.m_iNeededTasksLeastNum = ReplaceByte(ataskTempl_0.m_iNeededTasksLeastNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 435:
					ataskTempl_0.m_bRecordFnshCnt = RB(ataskTempl_0.m_bRecordFnshCnt, checkBox_0.Checked);
					break;
				case 436:
					ataskTempl_0.m_bTeamHaveRecaller = RB(ataskTempl_0.m_bTeamHaveRecaller, checkBox_0.Checked);
					break;
				case 437:
					ataskTempl_0.m_bBindedRecaller = RB(ataskTempl_0.m_bBindedRecaller, checkBox_0.Checked);
					break;
				case 438:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_iCamp = RIC(ataskTempl_0.m_iCamp, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 439:
					ataskTempl_0.m_bShowCamp = RB(ataskTempl_0.m_bShowCamp, checkBox_0.Checked);
					break;
				case 440:
					ataskTempl_0.m_iCampPower = RI(ataskTempl_0.m_iCampPower, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 441:
					ataskTempl_0.m_bShowCampPower = RB(ataskTempl_0.m_bShowCampPower, checkBox_0.Checked);
					break;
				case 442:
					ataskTempl_0.m_bReturnCampPower = RB(ataskTempl_0.m_bReturnCampPower, checkBox_0.Checked);
					break;
				case 443:
					ataskTempl_0.m_iNeedFriendPoint = RI(ataskTempl_0.m_iNeedFriendPoint, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 444:
					ataskTempl_0.m_bShowNeedFriendPoint = RB(ataskTempl_0.m_bShowNeedFriendPoint, checkBox_0.Checked);
					break;
				case 445:
					ataskTempl_0.m_iTriggerEvent = RI(ataskTempl_0.m_iTriggerEvent, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 446:
					ataskTempl_0.m_bNextTimeFail = RB(ataskTempl_0.m_bNextTimeFail, checkBox_0.Checked);
					break;
				case 447:
					ataskTempl_0.m_tmNextFailTime.year = RI(ataskTempl_0.m_tmNextFailTime.year, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 448:
					ataskTempl_0.m_tmNextFailTime.month = RI(ataskTempl_0.m_tmNextFailTime.month, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 449:
					ataskTempl_0.m_tmNextFailTime.day = RI(ataskTempl_0.m_tmNextFailTime.day, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 450:
					ataskTempl_0.m_tmNextFailTime.hour = RI(ataskTempl_0.m_tmNextFailTime.hour, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 451:
					ataskTempl_0.m_tmNextFailTime.min = RI(ataskTempl_0.m_tmNextFailTime.min, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 452:
					stOldValue = (comboBox_2.SelectedIndex - 1).ToString();
					stNewValue = (comboBox_3.SelectedIndex - 1).ToString();
					ataskTempl_0.m_tmNextFailTime.wday = RIC(ataskTempl_0.m_tmNextFailTime.wday, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 453:
					ataskTempl_0.m_bAvailFrequency = RB(ataskTempl_0.m_bAvailFrequency, checkBox_0.Checked);
					break;
				case 454:
					ataskTempl_0.m_tmAvailFrequency.year = RI(ataskTempl_0.m_tmAvailFrequency.year, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 455:
					ataskTempl_0.m_tmAvailFrequency.month = RI(ataskTempl_0.m_tmAvailFrequency.month, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 456:
					ataskTempl_0.m_tmAvailFrequency.day = RI(ataskTempl_0.m_tmAvailFrequency.day, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 457:
					ataskTempl_0.m_tmAvailFrequency.hour = RI(ataskTempl_0.m_tmAvailFrequency.hour, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 458:
					ataskTempl_0.m_tmAvailFrequency.min = RI(ataskTempl_0.m_tmAvailFrequency.min, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 459:
					stOldValue = (comboBox_2.SelectedIndex - 1).ToString();
					stNewValue = (comboBox_3.SelectedIndex - 1).ToString();
					ataskTempl_0.m_tmAvailFrequency.wday = RIC(ataskTempl_0.m_tmAvailFrequency.wday, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 460:
					ataskTempl_0.m_bHistoryVarTask = RB(ataskTempl_0.m_bHistoryVarTask, checkBox_0.Checked);
					break;
				case 461:
					ataskTempl_0.m_bPropNeedComp = RB(ataskTempl_0.m_bPropNeedComp, checkBox_0.Checked);
					break;
				case 462:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_nPropExp1AndOrExp2 = RIC(ataskTempl_0.m_nPropExp1AndOrExp2, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 463:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prop1KeyValue.nLeftType = RIC(ataskTempl_0.m_Prop1KeyValue.nLeftType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 464:
					ataskTempl_0.m_Prop1KeyValue.lLeftNum = RI(ataskTempl_0.m_Prop1KeyValue.lLeftNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 465:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prop1KeyValue.nCompOper = RIC(ataskTempl_0.m_Prop1KeyValue.nCompOper, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 466:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prop1KeyValue.nRightType = RIC(ataskTempl_0.m_Prop1KeyValue.nRightType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 467:
					ataskTempl_0.m_Prop1KeyValue.lRightNum = RI(ataskTempl_0.m_Prop1KeyValue.lRightNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 468:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prop2KeyValue.nLeftType = RIC(ataskTempl_0.m_Prop2KeyValue.nLeftType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 469:
					ataskTempl_0.m_Prop2KeyValue.lLeftNum = RI(ataskTempl_0.m_Prop2KeyValue.lLeftNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 470:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prop2KeyValue.nCompOper = RIC(ataskTempl_0.m_Prop2KeyValue.nCompOper, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 471:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prop2KeyValue.nRightType = RIC(ataskTempl_0.m_Prop2KeyValue.nRightType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 472:
					ataskTempl_0.m_Prop2KeyValue.lRightNum = RI(ataskTempl_0.m_Prop2KeyValue.lRightNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 473:
					ataskTempl_0.m_bDeliverByUI = RB(ataskTempl_0.m_bDeliverByUI, checkBox_0.Checked);
					break;
				case 474:
					ataskTempl_0.m_bRankPre = RB(ataskTempl_0.m_bRankPre, checkBox_0.Checked);
					break;
				case 475:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_iRankType = RIC(ataskTempl_0.m_iRankType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 476:
					ataskTempl_0.m_iRankGradeMin = RI(ataskTempl_0.m_iRankGradeMin, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 477:
					ataskTempl_0.m_iRankGradeMax = RI(ataskTempl_0.m_iRankGradeMax, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 480:
					ataskTempl_0.m_iVerifyStateLayer = RI(ataskTempl_0.m_iVerifyStateLayer, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 481:
					ataskTempl_0.m_ulVerifyStateLayerID = RI(ataskTempl_0.m_ulVerifyStateLayerID, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 482:
					ataskTempl_0.m_iKeyWordIndex = RI(ataskTempl_0.m_iKeyWordIndex, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 483:
					ataskTempl_0.m_bWarTaskAward = RB(ataskTempl_0.m_bWarTaskAward, checkBox_0.Checked);
					break;
				case 484:
				{
					for (int num5 = 0; num5 < ataskTempl_0.m_plPersonChangeKey.Length; num5++)
					{
						ataskTempl_0.m_plPersonChangeKey[num5] = RI(ataskTempl_0.m_plPersonChangeKey[num5], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 485:
				{
					for (int num4 = 0; num4 < ataskTempl_0.m_plPersonChangeKeyValue.Length; num4++)
					{
						ataskTempl_0.m_plPersonChangeKeyValue[num4] = RI(ataskTempl_0.m_plPersonChangeKeyValue[num4], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 486:
				{
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					for (int num3 = 0; num3 < ataskTempl_0.m_pbPersonChangeType.Length; num3++)
					{
						ataskTempl_0.m_pbPersonChangeType[num3] = Convert.ToByte(ReplaceByteCombo(Convert.ToByte(ataskTempl_0.m_pbPersonChangeType[num3]), stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex));
					}
					break;
				}
				case 487:
					ataskTempl_0.m_lPersonKeyForAwardVar = RI(ataskTempl_0.m_lPersonKeyForAwardVar, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 488:
					ataskTempl_0.m_bPremPersonNeedComp = RB(ataskTempl_0.m_bPremPersonNeedComp, checkBox_0.Checked);
					break;
				case 489:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_nPremPersonExp1AndOrExp2 = RIC(ataskTempl_0.m_nPremPersonExp1AndOrExp2, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 490:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prem1PersonKeyValue.nLeftType = RIC(ataskTempl_0.m_Prem1PersonKeyValue.nLeftType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 491:
					ataskTempl_0.m_Prem1PersonKeyValue.lLeftNum = RI(ataskTempl_0.m_Prem1PersonKeyValue.lLeftNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 492:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prem1PersonKeyValue.nCompOper = RIC(ataskTempl_0.m_Prem1PersonKeyValue.nCompOper, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 493:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prem1PersonKeyValue.nRightType = RIC(ataskTempl_0.m_Prem1PersonKeyValue.nRightType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 494:
					ataskTempl_0.m_Prem1PersonKeyValue.lRightNum = RI(ataskTempl_0.m_Prem1PersonKeyValue.lRightNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 495:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prem2PersonKeyValue.nLeftType = RIC(ataskTempl_0.m_Prem2PersonKeyValue.nLeftType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 496:
					ataskTempl_0.m_Prem2PersonKeyValue.lLeftNum = RI(ataskTempl_0.m_Prem2PersonKeyValue.lLeftNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 497:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prem2PersonKeyValue.nCompOper = RIC(ataskTempl_0.m_Prem2PersonKeyValue.nCompOper, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 498:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prem2PersonKeyValue.nRightType = RIC(ataskTempl_0.m_Prem2PersonKeyValue.nRightType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 499:
					ataskTempl_0.m_Prem2PersonKeyValue.lRightNum = RI(ataskTempl_0.m_Prem2PersonKeyValue.lRightNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 500:
					ataskTempl_0.m_bFinPersonNeedComp = RB(ataskTempl_0.m_bFinPersonNeedComp, checkBox_0.Checked);
					break;
				case 501:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_nFinPersonExp1AndOrExp2 = RIC(ataskTempl_0.m_nFinPersonExp1AndOrExp2, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 502:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Fin1PersonKeyValue.nLeftType = RIC(ataskTempl_0.m_Fin1PersonKeyValue.nLeftType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 503:
					ataskTempl_0.m_Fin1PersonKeyValue.lLeftNum = RI(ataskTempl_0.m_Fin1PersonKeyValue.lLeftNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 504:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Fin1PersonKeyValue.nCompOper = RIC(ataskTempl_0.m_Fin1PersonKeyValue.nCompOper, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 505:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Fin1PersonKeyValue.nRightType = RIC(ataskTempl_0.m_Fin1PersonKeyValue.nRightType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 506:
					ataskTempl_0.m_Fin1PersonKeyValue.lRightNum = RI(ataskTempl_0.m_Fin1PersonKeyValue.lRightNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 507:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Fin2PersonKeyValue.nLeftType = RIC(ataskTempl_0.m_Fin2PersonKeyValue.nLeftType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 508:
					ataskTempl_0.m_Fin2PersonKeyValue.lLeftNum = RI(ataskTempl_0.m_Fin2PersonKeyValue.lLeftNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 509:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Fin2PersonKeyValue.nCompOper = RIC(ataskTempl_0.m_Fin2PersonKeyValue.nCompOper, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 510:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Fin2PersonKeyValue.nRightType = RIC(ataskTempl_0.m_Fin2PersonKeyValue.nRightType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 511:
					ataskTempl_0.m_Fin2PersonKeyValue.lRightNum = RI(ataskTempl_0.m_Fin2PersonKeyValue.lRightNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 512:
					ataskTempl_0.m_bMultiNpcTalk = RB(ataskTempl_0.m_bMultiNpcTalk, checkBox_0.Checked);
					break;
				case 513:
					ataskTempl_0.m_bHideOtherPlayer = RB(ataskTempl_0.m_bHideOtherPlayer, checkBox_0.Checked);
					break;
				case 514:
					ataskTempl_0.m_iHideOtherPlayerTime = RI(ataskTempl_0.m_iHideOtherPlayerTime, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 515:
					ataskTempl_0.PropMonsterSummoned.m_bRandChoose = RB(ataskTempl_0.PropMonsterSummoned.m_bRandChoose, checkBox_0.Checked);
					break;
				case 516:
					ataskTempl_0.PropMonsterSummoned.m_ulSummonRadius = RI(ataskTempl_0.PropMonsterSummoned.m_ulSummonRadius, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 517:
					ataskTempl_0.PropMonsterSummoned.m_bDeathDisappear = RB(ataskTempl_0.PropMonsterSummoned.m_bDeathDisappear, checkBox_0.Checked);
					break;
				case 518:
				{
					for (int num2 = 0; num2 < ataskTempl_0.m_ulPropSummonedMonsters; num2++)
					{
						ataskTempl_0.PropMonsterSummoned.m_Monsters[num2].m_ulMonsterTemplId = RI(ataskTempl_0.PropMonsterSummoned.m_Monsters[num2].m_ulMonsterTemplId, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 519:
				{
					for (int num = 0; num < ataskTempl_0.m_ulPropSummonedMonsters; num++)
					{
						ataskTempl_0.PropMonsterSummoned.m_Monsters[num].m_ulMonsterNum = RI(ataskTempl_0.PropMonsterSummoned.m_Monsters[num].m_ulMonsterNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 520:
				{
					for (int n = 0; n < ataskTempl_0.m_ulPropSummonedMonsters; n++)
					{
						ataskTempl_0.PropMonsterSummoned.m_Monsters[n].m_fSummonProb = ReplaceFloat(ataskTempl_0.PropMonsterSummoned.m_Monsters[n].m_fSummonProb, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 521:
				{
					for (int m = 0; m < ataskTempl_0.m_ulPropSummonedMonsters; m++)
					{
						ataskTempl_0.PropMonsterSummoned.m_Monsters[m].m_lPeriod = RI(ataskTempl_0.PropMonsterSummoned.m_Monsters[m].m_lPeriod, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 522:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_iGfxType = RIC(ataskTempl_0.m_iGfxType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 523:
				{
					for (int l = 0; l < ataskTempl_0.m_plHistoryChangeKey.Length; l++)
					{
						ataskTempl_0.m_plHistoryChangeKey[l] = RI(ataskTempl_0.m_plHistoryChangeKey[l], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 524:
				{
					for (int k = 0; k < ataskTempl_0.m_plHistoryChangeKeyValue.Length; k++)
					{
						ataskTempl_0.m_plHistoryChangeKeyValue[k] = RI(ataskTempl_0.m_plHistoryChangeKeyValue[k], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				case 525:
				{
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					for (int j = 0; j < ataskTempl_0.m_pbHistoryChangeType.Length; j++)
					{
						ataskTempl_0.m_pbHistoryChangeType[j] = Convert.ToByte(ReplaceByteCombo(Convert.ToByte(ataskTempl_0.m_pbHistoryChangeType[j]), stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex));
					}
					break;
				}
				case 526:
					ataskTempl_0.m_lHistoryKeyForAwardVar = RI(ataskTempl_0.m_lHistoryKeyForAwardVar, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 527:
					ataskTempl_0.m_bPremHistoryNeedComp = RB(ataskTempl_0.m_bPremHistoryNeedComp, checkBox_0.Checked);
					break;
				case 528:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_nPremHistoryExp1AndOrExp2 = RIC(ataskTempl_0.m_nPremHistoryExp1AndOrExp2, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 529:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prem1HistoryKeyValue.nLeftType = RIC(ataskTempl_0.m_Prem1HistoryKeyValue.nLeftType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 530:
					ataskTempl_0.m_Prem1HistoryKeyValue.lLeftNum = RI(ataskTempl_0.m_Prem1HistoryKeyValue.lLeftNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 531:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prem1HistoryKeyValue.nCompOper = RIC(ataskTempl_0.m_Prem1HistoryKeyValue.nCompOper, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 532:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prem1HistoryKeyValue.nRightType = RIC(ataskTempl_0.m_Prem1HistoryKeyValue.nRightType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 533:
					ataskTempl_0.m_Prem1HistoryKeyValue.lRightNum = RI(ataskTempl_0.m_Prem1HistoryKeyValue.lRightNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 534:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prem2HistoryKeyValue.nLeftType = RIC(ataskTempl_0.m_Prem2HistoryKeyValue.nLeftType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 535:
					ataskTempl_0.m_Prem2HistoryKeyValue.lLeftNum = RI(ataskTempl_0.m_Prem2HistoryKeyValue.lLeftNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 536:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prem2HistoryKeyValue.nCompOper = RIC(ataskTempl_0.m_Prem2HistoryKeyValue.nCompOper, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 537:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prem2HistoryKeyValue.nRightType = RIC(ataskTempl_0.m_Prem2HistoryKeyValue.nRightType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 538:
					ataskTempl_0.m_Prem2HistoryKeyValue.lRightNum = RI(ataskTempl_0.m_Prem2HistoryKeyValue.lRightNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 539:
					ataskTempl_0.m_bFinHistoryNeedComp = RB(ataskTempl_0.m_bFinHistoryNeedComp, checkBox_0.Checked);
					break;
				case 540:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_nFinHistoryExp1AndOrExp2 = RIC(ataskTempl_0.m_nFinHistoryExp1AndOrExp2, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 541:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Fin1HistoryKeyValue.nLeftType = RIC(ataskTempl_0.m_Fin1HistoryKeyValue.nLeftType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 542:
					ataskTempl_0.m_Fin1HistoryKeyValue.lLeftNum = RI(ataskTempl_0.m_Fin1HistoryKeyValue.lLeftNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 543:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Fin1HistoryKeyValue.nCompOper = RIC(ataskTempl_0.m_Fin1HistoryKeyValue.nCompOper, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 544:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Fin1HistoryKeyValue.nRightType = RIC(ataskTempl_0.m_Fin1HistoryKeyValue.nRightType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 545:
					ataskTempl_0.m_Fin1HistoryKeyValue.lRightNum = RI(ataskTempl_0.m_Fin1HistoryKeyValue.lRightNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 546:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Fin2HistoryKeyValue.nLeftType = RIC(ataskTempl_0.m_Fin2HistoryKeyValue.nLeftType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 547:
					ataskTempl_0.m_Fin2HistoryKeyValue.lLeftNum = RI(ataskTempl_0.m_Fin2HistoryKeyValue.lLeftNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 548:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Fin2HistoryKeyValue.nCompOper = RIC(ataskTempl_0.m_Fin2HistoryKeyValue.nCompOper, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 549:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Fin2HistoryKeyValue.nRightType = RIC(ataskTempl_0.m_Fin2HistoryKeyValue.nRightType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 550:
					ataskTempl_0.m_Fin2HistoryKeyValue.lRightNum = RI(ataskTempl_0.m_Fin2HistoryKeyValue.lRightNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 551:
					ataskTempl_0.m_chatGroupId = RI(ataskTempl_0.m_chatGroupId, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 552:
					ataskTempl_0.m_bRecordDeliverTime = RB(ataskTempl_0.m_bRecordDeliverTime, checkBox_0.Checked);
					break;
				case 553:
					ataskTempl_0.m_iGuessStringID = RI(ataskTempl_0.m_iGuessStringID, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 554:
					ataskTempl_0.m_bPropNeedComp_personal = RB(ataskTempl_0.m_bPropNeedComp_personal, checkBox_0.Checked);
					break;
				case 555:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_nPropExp1AndOrExp2_personal = RIC(ataskTempl_0.m_nPropExp1AndOrExp2_personal, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 556:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prop1KeyValue_personal.nLeftType = RIC(ataskTempl_0.m_Prop1KeyValue_personal.nLeftType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 557:
					ataskTempl_0.m_Prop1KeyValue_personal.lLeftNum = RI(ataskTempl_0.m_Prop1KeyValue_personal.lLeftNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 558:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prop1KeyValue_personal.nCompOper = RIC(ataskTempl_0.m_Prop1KeyValue_personal.nCompOper, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 559:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prop1KeyValue_personal.nRightType = RIC(ataskTempl_0.m_Prop1KeyValue_personal.nRightType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 560:
					ataskTempl_0.m_Prop1KeyValue_personal.lRightNum = RI(ataskTempl_0.m_Prop1KeyValue_personal.lRightNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 561:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prop2KeyValue_personal.nLeftType = RIC(ataskTempl_0.m_Prop2KeyValue_personal.nLeftType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 562:
					ataskTempl_0.m_Prop2KeyValue_personal.lLeftNum = RI(ataskTempl_0.m_Prop2KeyValue_personal.lLeftNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 563:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prop2KeyValue_personal.nCompOper = RIC(ataskTempl_0.m_Prop2KeyValue_personal.nCompOper, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 564:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_Prop2KeyValue_personal.nRightType = RIC(ataskTempl_0.m_Prop2KeyValue_personal.nRightType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 565:
					ataskTempl_0.m_Prop2KeyValue_personal.lRightNum = RI(ataskTempl_0.m_Prop2KeyValue_personal.lRightNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 566:
					ataskTempl_0.m_lFrequencyNum = RI(ataskTempl_0.m_lFrequencyNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 567:
					ataskTempl_0.m_bShowMethod = RB(ataskTempl_0.m_bShowMethod, checkBox_0.Checked);
					break;
				case 871:
				{
					for (int i = 0; i < ataskTempl_0.m_plChangeKeyValue2.Length; i++)
					{
						ataskTempl_0.m_plChangeKeyValue2[i] = RI(ataskTempl_0.m_plChangeKeyValue2[i], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					}
					break;
				}
				}
			}
			else if (comboBox_1.SelectedIndex < 2)
			{
				switch (int_0)
				{
				case 1:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_ulAwardType_F = RIC(ataskTempl_0.m_ulAwardType_F, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				case 0:
					stOldValue = comboBox_2.SelectedIndex.ToString();
					stNewValue = comboBox_3.SelectedIndex.ToString();
					ataskTempl_0.m_ulAwardType_S = RIC(ataskTempl_0.m_ulAwardType_S, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
					break;
				}
			}
			else
			{
				if (checkBox_1.Checked)
				{
					method_2(ataskTempl_0.m_Award_S);
				}
				if (checkBox_2.Checked)
				{
					method_2(ataskTempl_0.m_Award_F);
				}
				if (checkBox_3.Checked)
				{
					for (int num127 = 0; num127 < ataskTempl_0.m_AwByRatio_S.m_Awards.Length; num127++)
					{
						method_2(ataskTempl_0.m_AwByRatio_S.m_Awards[num127]);
					}
				}
				if (checkBox_4.Checked)
				{
					for (int num128 = 0; num128 < ataskTempl_0.m_AwByRatio_F.m_Awards.Length; num128++)
					{
						method_2(ataskTempl_0.m_AwByRatio_F.m_Awards[num128]);
					}
				}
				if (checkBox_5.Checked)
				{
					for (int num129 = 0; num129 < ataskTempl_0.m_AwByItems_S.m_Awards.Length; num129++)
					{
						method_2(ataskTempl_0.m_AwByItems_S.m_Awards[num129]);
					}
				}
				if (checkBox_6.Checked)
				{
					for (int num130 = 0; num130 < ataskTempl_0.m_AwByItems_F.m_Awards.Length; num130++)
					{
						method_2(ataskTempl_0.m_AwByItems_F.m_Awards[num130]);
					}
				}
				if (checkBox_7.Checked)
				{
					for (int num131 = 0; num131 < ataskTempl_0.AwByTaskEventRatio_S.m_Awards.Length; num131++)
					{
						method_2(ataskTempl_0.AwByTaskEventRatio_S.m_Awards[num131]);
					}
				}
				if (checkBox_8.Checked)
				{
					for (int num132 = 0; num132 < ataskTempl_0.AwByTaskEventRatio_F.m_Awards.Length; num132++)
					{
						method_2(ataskTempl_0.AwByTaskEventRatio_F.m_Awards[num132]);
					}
				}
				if (checkBox_9.Checked)
				{
					for (int num133 = 0; num133 < ataskTempl_0.AwByCarrierHp_S.m_Awards.Length; num133++)
					{
						method_2(ataskTempl_0.AwByCarrierHp_S.m_Awards[num133]);
					}
				}
				if (checkBox_10.Checked)
				{
					for (int num134 = 0; num134 < ataskTempl_0.AwByCarrierHp_F.m_Awards.Length; num134++)
					{
						method_2(ataskTempl_0.AwByCarrierHp_F.m_Awards[num134]);
					}
				}
				if (checkBox_11.Checked)
				{
					for (int num135 = 0; num135 < ataskTempl_0.AwByVar_S.m_Awards.Length; num135++)
					{
						method_2(ataskTempl_0.AwByVar_S.m_Awards[num135]);
					}
				}
				if (checkBox_12.Checked)
				{
					for (int num136 = 0; num136 < ataskTempl_0.AwByVar_F.m_Awards.Length; num136++)
					{
						method_2(ataskTempl_0.AwByVar_F.m_Awards[num136]);
					}
				}
			}
		}
		for (int num137 = 0; num137 < ataskTempl_0.pSub.Length; num137++)
		{
			method_1(ataskTempl_0.pSub[num137], treeNode_0.Nodes[num137]);
		}
	}

	private void method_2(AWARD_DATA award_DATA_0)
	{
		string stOldValue = textBox_0.Text;
		string stNewValue = textBox_1.Text;
		switch (int_0)
		{
		case 641:
		{
			for (int num30 = 0; num30 < award_DATA_0.m_plChangeKeyValue2.Length; num30++)
			{
				award_DATA_0.m_plChangeKeyValue2[num30] = RI(award_DATA_0.m_plChangeKeyValue2[num30], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 2:
			award_DATA_0.m_ulGoldNum = RI(award_DATA_0.m_ulGoldNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 3:
			award_DATA_0.m_ulExp = RI(award_DATA_0.m_ulExp, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 4:
			award_DATA_0.m_ulRealmExp = RI(award_DATA_0.m_ulRealmExp, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 5:
			award_DATA_0.m_bExpandRealmLevelMax = RB(award_DATA_0.m_bExpandRealmLevelMax, checkBox_0.Checked);
			break;
		case 6:
			award_DATA_0.m_ulNewTask = RI(award_DATA_0.m_ulNewTask, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 7:
			award_DATA_0.m_ulSP = RI(award_DATA_0.m_ulSP, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 8:
			award_DATA_0.m_lReputation = RI(award_DATA_0.m_lReputation, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 9:
			if (comboBox_2.SelectedIndex < 9)
			{
				stOldValue = comboBox_2.SelectedIndex.ToString();
			}
			else
			{
				switch (comboBox_2.SelectedIndex)
				{
				case 9:
					stOldValue = 20.ToString();
					break;
				case 10:
					stOldValue = 30.ToString();
					break;
				case 11:
					stOldValue = 21.ToString();
					break;
				case 12:
					stOldValue = 31.ToString();
					break;
				case 13:
					stOldValue = 22.ToString();
					break;
				case 14:
					stOldValue = 32.ToString();
					break;
				case 15:
					stOldValue = 40.ToString();
					break;
				case 16:
					stOldValue = 41.ToString();
					break;
				}
			}
			if (comboBox_3.SelectedIndex < 9)
			{
				stNewValue = comboBox_3.SelectedIndex.ToString();
			}
			else
			{
				switch (comboBox_3.SelectedIndex)
				{
				case 9:
					stNewValue = 20.ToString();
					break;
				case 10:
					stNewValue = 30.ToString();
					break;
				case 11:
					stNewValue = 21.ToString();
					break;
				case 12:
					stNewValue = 31.ToString();
					break;
				case 13:
					stNewValue = 22.ToString();
					break;
				case 14:
					stNewValue = 32.ToString();
					break;
				case 15:
					stNewValue = 40.ToString();
					break;
				case 16:
					stNewValue = 41.ToString();
					break;
				}
			}
			award_DATA_0.m_ulNewPeriod = RIC(award_DATA_0.m_ulNewPeriod, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 10:
			award_DATA_0.m_ulNewRelayStation = RI(award_DATA_0.m_ulNewRelayStation, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 11:
			award_DATA_0.m_ulStorehouseSize = RI(award_DATA_0.m_ulStorehouseSize, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 12:
			award_DATA_0.m_ulStorehouseSize2 = RI(award_DATA_0.m_ulStorehouseSize2, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 13:
			award_DATA_0.m_ulStorehouseSize3 = RI(award_DATA_0.m_ulStorehouseSize3, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 14:
			award_DATA_0.m_ulStorehouseSize4 = RI(award_DATA_0.m_ulStorehouseSize4, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 15:
			award_DATA_0.m_lInventorySize = RI(award_DATA_0.m_lInventorySize, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 16:
			award_DATA_0.m_ulPetInventorySize = RI(award_DATA_0.m_ulPetInventorySize, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 17:
			award_DATA_0.m_ulFuryULimit = RI(award_DATA_0.m_ulFuryULimit, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 18:
			award_DATA_0.m_ulTransWldId = RI(award_DATA_0.m_ulTransWldId, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 19:
			award_DATA_0.m_TransPt.Single_0[0] = ReplaceFloat(award_DATA_0.m_TransPt.Single_0[0], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 20:
			award_DATA_0.m_TransPt.Single_0[1] = ReplaceFloat(award_DATA_0.m_TransPt.Single_0[1], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 21:
			award_DATA_0.m_TransPt.Single_0[2] = ReplaceFloat(award_DATA_0.m_TransPt.Single_0[2], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 22:
			award_DATA_0.m_lMonsCtrl = RI(award_DATA_0.m_lMonsCtrl, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 23:
			award_DATA_0.m_bTrigCtrl = RB(award_DATA_0.m_bTrigCtrl, checkBox_0.Checked);
			break;
		case 24:
			award_DATA_0.m_bUseLevCo = RB(award_DATA_0.m_bUseLevCo, checkBox_0.Checked);
			break;
		case 25:
			award_DATA_0.m_bDivorce = RB(award_DATA_0.m_bDivorce, checkBox_0.Checked);
			break;
		case 26:
			award_DATA_0.m_bSendMsg = RB(award_DATA_0.m_bSendMsg, checkBox_0.Checked);
			break;
		case 27:
			stOldValue = comboBox_2.SelectedIndex.ToString();
			stNewValue = comboBox_3.SelectedIndex.ToString();
			award_DATA_0.m_nMsgChannel = RIC(award_DATA_0.m_nMsgChannel, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 28:
		{
			for (int num = 0; num < award_DATA_0.m_CandItems.Length; num++)
			{
				award_DATA_0.m_CandItems[num].m_bRandChoose = RB(award_DATA_0.m_CandItems[num].m_bRandChoose, checkBox_0.Checked);
			}
			break;
		}
		case 29:
		{
			for (int k = 0; k < award_DATA_0.m_CandItems.Length; k++)
			{
				for (int l = 0; l < award_DATA_0.m_CandItems[k].m_AwardItems.Length; l++)
				{
					award_DATA_0.m_CandItems[k].m_AwardItems[l].m_ulItemTemplId = RI(award_DATA_0.m_CandItems[k].m_AwardItems[l].m_ulItemTemplId, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
				}
			}
			break;
		}
		case 30:
		{
			for (int num31 = 0; num31 < award_DATA_0.m_CandItems.Length; num31++)
			{
				for (int num32 = 0; num32 < award_DATA_0.m_CandItems[num31].m_AwardItems.Length; num32++)
				{
					award_DATA_0.m_CandItems[num31].m_AwardItems[num32].m_bCommonItem = RB(award_DATA_0.m_CandItems[num31].m_AwardItems[num32].m_bCommonItem, checkBox_0.Checked);
				}
			}
			break;
		}
		case 31:
		{
			for (int num28 = 0; num28 < award_DATA_0.m_CandItems.Length; num28++)
			{
				for (int num29 = 0; num29 < award_DATA_0.m_CandItems[num28].m_AwardItems.Length; num29++)
				{
					award_DATA_0.m_CandItems[num28].m_AwardItems[num29].m_ulItemNum = RI(award_DATA_0.m_CandItems[num28].m_AwardItems[num29].m_ulItemNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
				}
			}
			break;
		}
		case 32:
		{
			for (int num26 = 0; num26 < award_DATA_0.m_CandItems.Length; num26++)
			{
				for (int num27 = 0; num27 < award_DATA_0.m_CandItems[num26].m_AwardItems.Length; num27++)
				{
					award_DATA_0.m_CandItems[num26].m_AwardItems[num27].m_fProb = ReplaceFloat(award_DATA_0.m_CandItems[num26].m_AwardItems[num27].m_fProb, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
				}
			}
			break;
		}
		case 33:
		{
			for (int num24 = 0; num24 < award_DATA_0.m_CandItems.Length; num24++)
			{
				for (int num25 = 0; num25 < award_DATA_0.m_CandItems[num24].m_AwardItems.Length; num25++)
				{
					award_DATA_0.m_CandItems[num24].m_AwardItems[num25].m_lPeriod = RI(award_DATA_0.m_CandItems[num24].m_AwardItems[num25].m_lPeriod, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
				}
			}
			break;
		}
		case 34:
			award_DATA_0.m_SummonedMonsters.m_bRandChoose = RB(award_DATA_0.m_SummonedMonsters.m_bRandChoose, checkBox_0.Checked);
			break;
		case 35:
			award_DATA_0.m_SummonedMonsters.m_ulSummonRadius = RI(award_DATA_0.m_SummonedMonsters.m_ulSummonRadius, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 36:
			award_DATA_0.m_SummonedMonsters.m_bDeathDisappear = RB(award_DATA_0.m_SummonedMonsters.m_bDeathDisappear, checkBox_0.Checked);
			break;
		case 37:
		{
			for (int num23 = 0; num23 < award_DATA_0.m_SummonedMonsters.m_Monsters.Length; num23++)
			{
				award_DATA_0.m_SummonedMonsters.m_Monsters[num23].m_ulMonsterTemplId = RI(award_DATA_0.m_SummonedMonsters.m_Monsters[num23].m_ulMonsterTemplId, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 38:
		{
			for (int num22 = 0; num22 < award_DATA_0.m_SummonedMonsters.m_Monsters.Length; num22++)
			{
				award_DATA_0.m_SummonedMonsters.m_Monsters[num22].m_ulMonsterNum = RI(award_DATA_0.m_SummonedMonsters.m_Monsters[num22].m_ulMonsterNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 39:
		{
			for (int num21 = 0; num21 < award_DATA_0.m_SummonedMonsters.m_Monsters.Length; num21++)
			{
				award_DATA_0.m_SummonedMonsters.m_Monsters[num21].m_fSummonProb = ReplaceFloat(award_DATA_0.m_SummonedMonsters.m_Monsters[num21].m_fSummonProb, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 40:
		{
			for (int num20 = 0; num20 < award_DATA_0.m_SummonedMonsters.m_Monsters.Length; num20++)
			{
				award_DATA_0.m_SummonedMonsters.m_Monsters[num20].m_lPeriod = RI(award_DATA_0.m_SummonedMonsters.m_Monsters[num20].m_lPeriod, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 41:
			award_DATA_0.m_bAwardDeath = RB(award_DATA_0.m_bAwardDeath, checkBox_0.Checked);
			break;
		case 42:
			award_DATA_0.m_bAwardDeathWithLoss = RB(award_DATA_0.m_bAwardDeathWithLoss, checkBox_0.Checked);
			break;
		case 43:
			award_DATA_0.m_ulDividend = RI(award_DATA_0.m_ulDividend, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 44:
			award_DATA_0.m_bAwardSkill = RB(award_DATA_0.m_bAwardSkill, checkBox_0.Checked);
			break;
		case 45:
			award_DATA_0.m_iAwardSkillID = RI(award_DATA_0.m_iAwardSkillID, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 46:
			award_DATA_0.m_iAwardSkillLevel = RI(award_DATA_0.m_iAwardSkillLevel, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 47:
			award_DATA_0.m_iSoloTowerChallengeScore = RI(award_DATA_0.m_iSoloTowerChallengeScore, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 48:
			award_DATA_0.m_ulSpecifyContribTaskID = RI(award_DATA_0.m_ulSpecifyContribTaskID, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 49:
			award_DATA_0.m_ulSpecifyContribSubTaskID = RI(award_DATA_0.m_ulSpecifyContribSubTaskID, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 50:
			award_DATA_0.m_ulSpecifyContrib = RI(award_DATA_0.m_ulSpecifyContrib, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 51:
			award_DATA_0.m_ulContrib = RI(award_DATA_0.m_ulContrib, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 52:
			award_DATA_0.m_ulRandContrib = RI(award_DATA_0.m_ulRandContrib, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 53:
			award_DATA_0.m_ulLowestcontrib = RI(award_DATA_0.m_ulLowestcontrib, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 54:
			award_DATA_0.m_iFactionContrib = RI(award_DATA_0.m_iFactionContrib, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 55:
			award_DATA_0.m_iFactionExpContrib = RI(award_DATA_0.m_iFactionExpContrib, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 56:
			award_DATA_0.m_PQRankingAward.m_bAwardByProf = RB(award_DATA_0.m_PQRankingAward.m_bAwardByProf, checkBox_0.Checked);
			break;
		case 57:
		{
			for (int num19 = 0; num19 < award_DATA_0.m_PQRankingAward.m_RankingAward.Length; num19++)
			{
				award_DATA_0.m_PQRankingAward.m_RankingAward[num19].m_iRankingStart = RI(award_DATA_0.m_PQRankingAward.m_RankingAward[num19].m_iRankingStart, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 58:
		{
			for (int num18 = 0; num18 < award_DATA_0.m_PQRankingAward.m_RankingAward.Length; num18++)
			{
				award_DATA_0.m_PQRankingAward.m_RankingAward[num18].m_iRankingEnd = RI(award_DATA_0.m_PQRankingAward.m_RankingAward[num18].m_iRankingEnd, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 59:
		{
			for (int num17 = 0; num17 < award_DATA_0.m_PQRankingAward.m_RankingAward.Length; num17++)
			{
				award_DATA_0.m_PQRankingAward.m_RankingAward[num17].m_bCommonItem = RB(award_DATA_0.m_PQRankingAward.m_RankingAward[num17].m_bCommonItem, checkBox_0.Checked);
			}
			break;
		}
		case 60:
		{
			for (int num16 = 0; num16 < award_DATA_0.m_PQRankingAward.m_RankingAward.Length; num16++)
			{
				award_DATA_0.m_PQRankingAward.m_RankingAward[num16].m_ulAwardItemId = RI(award_DATA_0.m_PQRankingAward.m_RankingAward[num16].m_ulAwardItemId, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 61:
		{
			for (int num15 = 0; num15 < award_DATA_0.m_PQRankingAward.m_RankingAward.Length; num15++)
			{
				award_DATA_0.m_PQRankingAward.m_RankingAward[num15].m_ulAwardItemNum = RI(award_DATA_0.m_PQRankingAward.m_RankingAward[num15].m_ulAwardItemNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 62:
		{
			for (int num14 = 0; num14 < award_DATA_0.m_PQRankingAward.m_RankingAward.Length; num14++)
			{
				award_DATA_0.m_PQRankingAward.m_RankingAward[num14].m_lPeriod = RI(award_DATA_0.m_PQRankingAward.m_RankingAward[num14].m_lPeriod, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 63:
		{
			for (int num13 = 0; num13 < award_DATA_0.m_plChangeKey.Length; num13++)
			{
				award_DATA_0.m_plChangeKey[num13] = RI(award_DATA_0.m_plChangeKey[num13], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 64:
		{
			for (int num12 = 0; num12 < award_DATA_0.m_plChangeKeyValue.Length; num12++)
			{
				award_DATA_0.m_plChangeKeyValue[num12] = RI(award_DATA_0.m_plChangeKeyValue[num12], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 65:
		{
			stOldValue = comboBox_2.SelectedIndex.ToString();
			stNewValue = comboBox_3.SelectedIndex.ToString();
			for (int num11 = 0; num11 < award_DATA_0.m_pbChangeType.Length; num11++)
			{
				award_DATA_0.m_pbChangeType[num11] = Convert.ToByte(ReplaceByteCombo(Convert.ToByte(award_DATA_0.m_pbChangeType[num11]), stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex));
			}
			break;
		}
		case 66:
		{
			for (int num10 = 0; num10 < award_DATA_0.m_plHistoryChangeKey.Length; num10++)
			{
				award_DATA_0.m_plHistoryChangeKey[num10] = RI(award_DATA_0.m_plHistoryChangeKey[num10], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 67:
		{
			for (int num9 = 0; num9 < award_DATA_0.m_plHistoryChangeKeyValue.Length; num9++)
			{
				award_DATA_0.m_plHistoryChangeKeyValue[num9] = RI(award_DATA_0.m_plHistoryChangeKeyValue[num9], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 68:
		{
			for (int num8 = 0; num8 < award_DATA_0.m_pbHistoryChangeType.Length; num8++)
			{
				award_DATA_0.m_pbHistoryChangeType[num8] = Convert.ToByte(ReplaceByte(Convert.ToByte(award_DATA_0.m_pbHistoryChangeType[num8]), stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex));
			}
			break;
		}
		case 69:
			award_DATA_0.m_bMulti = RB(award_DATA_0.m_bMulti, checkBox_0.Checked);
			break;
		case 70:
			stOldValue = comboBox_2.SelectedIndex.ToString();
			stNewValue = comboBox_3.SelectedIndex.ToString();
			award_DATA_0.m_nNumType = RIC(award_DATA_0.m_nNumType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 71:
			award_DATA_0.m_lNum = RI(award_DATA_0.m_lNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 72:
		{
			for (int num7 = 0; num7 < award_DATA_0.m_plDisplayKey.Length; num7++)
			{
				award_DATA_0.m_plDisplayKey[num7] = RI(award_DATA_0.m_plDisplayKey[num7], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 73:
			award_DATA_0.m_iForceContribution = RI(award_DATA_0.m_iForceContribution, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 74:
			award_DATA_0.m_iForceReputation = RI(award_DATA_0.m_iForceReputation, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 75:
			award_DATA_0.m_iForceActivity = RI(award_DATA_0.m_iForceActivity, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 76:
			award_DATA_0.m_iForceSetRepu = RI(award_DATA_0.m_iForceSetRepu, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 77:
			award_DATA_0.m_iTaskLimit = RI(award_DATA_0.m_iTaskLimit, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 78:
		{
			for (int num6 = 0; num6 < award_DATA_0.m_pTitleAward.Length; num6++)
			{
				award_DATA_0.m_pTitleAward[num6].m_ulTitleID = RI(award_DATA_0.m_pTitleAward[num6].m_ulTitleID, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 79:
		{
			for (int num5 = 0; num5 < award_DATA_0.m_pTitleAward.Length; num5++)
			{
				award_DATA_0.m_pTitleAward[num5].m_lPeriod = RI(award_DATA_0.m_pTitleAward[num5].m_lPeriod, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 80:
			award_DATA_0.m_iLeaderShip = RI(award_DATA_0.m_iLeaderShip, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 81:
			award_DATA_0.m_iWorldContribution = RI(award_DATA_0.m_iWorldContribution, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 82:
			award_DATA_0.m_iHomeResource[0] = RI(award_DATA_0.m_iHomeResource[0], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 83:
			award_DATA_0.m_iHomeResource[1] = RI(award_DATA_0.m_iHomeResource[1], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 84:
			award_DATA_0.m_iHomeResource[2] = RI(award_DATA_0.m_iHomeResource[2], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 85:
			award_DATA_0.m_iHomeResource[3] = RI(award_DATA_0.m_iHomeResource[3], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 86:
			award_DATA_0.m_iHomeResource[4] = RI(award_DATA_0.m_iHomeResource[4], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 87:
			award_DATA_0.m_bCreateHome = RB(award_DATA_0.m_bCreateHome, checkBox_0.Checked);
			break;
		case 88:
			award_DATA_0.m_bLeaveCarrier = RB(award_DATA_0.m_bLeaveCarrier, checkBox_0.Checked);
			break;
		case 89:
			award_DATA_0.m_faction_money = RI(award_DATA_0.m_faction_money, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 90:
			award_DATA_0.m_faction_person_score = RI(award_DATA_0.m_faction_person_score, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 91:
		{
			for (int num4 = 0; num4 < award_DATA_0.AwardFactionTargetData.Length; num4++)
			{
				award_DATA_0.AwardFactionTargetData[num4].FactionTargetId = RI(award_DATA_0.AwardFactionTargetData[num4].FactionTargetId, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 92:
		{
			for (int num3 = 0; num3 < award_DATA_0.AwardFactionTargetData.Length; num3++)
			{
				award_DATA_0.AwardFactionTargetData[num3].FactionNum = RI(award_DATA_0.AwardFactionTargetData[num3].FactionNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 93:
			award_DATA_0.m_bSubmitRankScore = RB(award_DATA_0.m_bSubmitRankScore, checkBox_0.Checked);
			break;
		case 94:
			stOldValue = comboBox_2.SelectedIndex.ToString();
			stNewValue = comboBox_3.SelectedIndex.ToString();
			award_DATA_0.submit_rank.m_iSubmitType = RIC(award_DATA_0.submit_rank.m_iSubmitType, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 95:
			stOldValue = (comboBox_2.SelectedIndex - 1).ToString();
			stNewValue = (comboBox_3.SelectedIndex - 1).ToString();
			award_DATA_0.submit_rank.m_iRankID = RIC(award_DATA_0.submit_rank.m_iRankID, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 96:
			award_DATA_0.submit_rank.m_iTempRankID = RI(award_DATA_0.submit_rank.m_iTempRankID, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 97:
			stOldValue = comboBox_2.SelectedIndex.ToString();
			stNewValue = comboBox_3.SelectedIndex.ToString();
			award_DATA_0.NewTaskSpace = RIC(award_DATA_0.NewTaskSpace, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 98:
			stOldValue = comboBox_2.SelectedIndex.ToString();
			stNewValue = comboBox_3.SelectedIndex.ToString();
			award_DATA_0.m_iOpenSystem = RIC(award_DATA_0.m_iOpenSystem, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 99:
			award_DATA_0.m_iMentorStudentValue = RI(award_DATA_0.m_iMentorStudentValue, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 100:
			award_DATA_0.m_iCoupleIntimacy = RI(award_DATA_0.m_iCoupleIntimacy, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 101:
			award_DATA_0.m_ulCrossServerWldId = RI(award_DATA_0.m_ulCrossServerWldId, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 102:
			award_DATA_0.m_ulRedBookExp = RI(award_DATA_0.m_ulRedBookExp, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 103:
			award_DATA_0.m_iCampScore = RI(award_DATA_0.m_iCampScore, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 104:
			award_DATA_0.m_iCrossServerMoney = RI(award_DATA_0.m_iCrossServerMoney, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 105:
			award_DATA_0.m_iInviterAwardItem = RI(award_DATA_0.m_iInviterAwardItem, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 106:
			award_DATA_0.m_iRewardFriendPoint = RI(award_DATA_0.m_iRewardFriendPoint, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 107:
			award_DATA_0.m_iInviterAwardNum = RI(award_DATA_0.m_iInviterAwardNum, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 108:
		{
			for (int num2 = 0; num2 < award_DATA_0.PersonChangeKey.Length; num2++)
			{
				award_DATA_0.PersonChangeKey[num2] = RI(award_DATA_0.PersonChangeKey[num2], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 109:
		{
			for (int n = 0; n < award_DATA_0.PersonChangeKeyValue.Length; n++)
			{
				award_DATA_0.PersonChangeKeyValue[n] = RI(award_DATA_0.PersonChangeKeyValue[n], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 110:
		{
			stOldValue = comboBox_2.SelectedIndex.ToString();
			stNewValue = comboBox_3.SelectedIndex.ToString();
			for (int m = 0; m < award_DATA_0.m_pbChangeType.Length; m++)
			{
				award_DATA_0.PersonChangeType[m] = Convert.ToByte(ReplaceByteCombo(Convert.ToByte(award_DATA_0.PersonChangeType[m]), stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex));
			}
			break;
		}
		case 111:
			award_DATA_0.m_iPerceptionVal = RI(award_DATA_0.m_iPerceptionVal, stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			break;
		case 1091:
		{
			for (int j = 0; j < award_DATA_0.PersonChangeKeyValue2.Length; j++)
			{
				award_DATA_0.PersonChangeKeyValue2[j] = RI(award_DATA_0.PersonChangeKeyValue2[j], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		case 671:
		{
			for (int i = 0; i < award_DATA_0.m_plHistoryChangeKeyValue2.Length; i++)
			{
				award_DATA_0.m_plHistoryChangeKeyValue2[i] = RI(award_DATA_0.m_plHistoryChangeKeyValue2[i], stOldValue, stNewValue, radioButton_2.Checked, comboBox_0.SelectedIndex);
			}
			break;
		}
		}
	}

	public void comboBox_Parameters_SetItems()
	{
		comboBox_1.Items.Clear();
		if (radioButton_4.Checked)
		{
			for (int i = 1; i < arrayList_0.Count; i += 2)
			{
				comboBox_1.Items.Add(arrayList_0[i]);
			}
		}
		else
		{
			for (int j = 1; j < arrayList_1.Count; j += 2)
			{
				comboBox_1.Items.Add(arrayList_1[j]);
			}
		}
		comboBox_1.SelectedIndex = 0;
	}

	private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (radioButton_4.Checked)
		{
			int_0 = (int)arrayList_0[comboBox_1.SelectedIndex * 2];
			if (int_0 != 2 && int_0 != 3 && int_0 != 10 && int_0 != 11 && int_0 != 27 && int_0 != 28 && int_0 != 29 && int_0 != 30 && int_0 != 31 && int_0 != 32 && int_0 != 33 && int_0 != 34 && int_0 != 35 && int_0 != 36 && int_0 != 37 && int_0 != 39 && int_0 != 47 && int_0 != 55 && int_0 != 63 && int_0 != 64 && int_0 != 70 && int_0 != 71 && int_0 != 72 && int_0 != 73 && int_0 != 74 && int_0 != 75 && int_0 != 76 && int_0 != 78 && int_0 != 79 && int_0 != 82 && int_0 != 83 && int_0 != 84 && int_0 != 85 && int_0 != 89 && int_0 != 90 && int_0 != 91 && int_0 != 94 && int_0 != 95 && int_0 != 96 && int_0 != 98 && int_0 != 99 && int_0 != 100 && int_0 != 101 && int_0 != 102 && int_0 != 103 && int_0 != 104 && int_0 != 110 && int_0 != 112 && int_0 != 113 && int_0 != 114 && int_0 != 116 && int_0 != 117 && int_0 != 118 && int_0 != 119 && int_0 != 121 && int_0 != 124 && int_0 != 125 && int_0 != 126 && int_0 != 129 && int_0 != 130 && int_0 != 133 && int_0 != 134 && int_0 != 136 && int_0 != 140 && int_0 != 141 && int_0 != 143 && int_0 != 148 && int_0 != 151 && int_0 != 153 && int_0 != 156 && int_0 != 157 && int_0 != 159 && int_0 != 161 && int_0 != 162 && int_0 != 163 && int_0 != 164 && int_0 != 165 && int_0 != 166 && int_0 != 167 && int_0 != 168 && int_0 != 169 && int_0 != 172 && int_0 != 173 && int_0 != 192 && int_0 != 193 && int_0 != 194 && int_0 != 195 && int_0 != 196 && int_0 != 198 && int_0 != 199 && int_0 != 200 && int_0 != 202 && int_0 != 203 && int_0 != 205 && int_0 != 207 && int_0 != 208 && int_0 != 209 && int_0 != 219 && int_0 != 220 && int_0 != 232 && int_0 != 234 && int_0 != 236 && int_0 != 238 && int_0 != 240 && int_0 != 242 && int_0 != 244 && int_0 != 245 && int_0 != 246 && int_0 != 247 && int_0 != 248 && int_0 != 251 && int_0 != 254 && int_0 != 256 && int_0 != 259 && int_0 != 261 && int_0 != 264 && int_0 != 265 && int_0 != 268 && int_0 != 272 && int_0 != 276 && int_0 != 279 && int_0 != 280 && int_0 != 281 && int_0 != 287 && int_0 != 294 && int_0 != 302 && int_0 != 304 && int_0 != 308 && int_0 != 340 && int_0 != 367 && int_0 != 369 && int_0 != 371 && int_0 != 372 && int_0 != 373 && int_0 != 377 && int_0 != 378 && int_0 != 381 && int_0 != 390 && int_0 != 392 && int_0 != 393 && int_0 != 395 && int_0 != 397 && int_0 != 399 && int_0 != 402 && int_0 != 403 && int_0 != 408 && int_0 != 410 && int_0 != 412 && int_0 != 414 && int_0 != 426 && int_0 != 435 && int_0 != 436 && int_0 != 437 && int_0 != 439 && int_0 != 441 && int_0 != 442 && int_0 != 444 && int_0 != 446 && int_0 != 453 && int_0 != 460 && int_0 != 461 && int_0 != 473 && int_0 != 474 && int_0 != 483 && int_0 != 488 && int_0 != 500 && int_0 != 512 && int_0 != 513 && int_0 != 515 && int_0 != 517 && int_0 != 527 && int_0 != 539 && int_0 != 554 && int_0 != 552 && int_0 != 567)
			{
				if (int_0 != 0 && int_0 != 9 && int_0 != 12 && int_0 != 18 && int_0 != 24 && int_0 != 25 && int_0 != 88 && int_0 != 155 && int_0 != 158 && int_0 != 160 && int_0 != 174 && int_0 != 175 && int_0 != 181 && int_0 != 184 && int_0 != 190 && int_0 != 212 && int_0 != 213 && int_0 != 214 && int_0 != 221 && int_0 != 222 && int_0 != 224 && int_0 != 225 && int_0 != 227 && int_0 != 229 && int_0 != 230 && int_0 != 257 && int_0 != 269 && int_0 != 273 && int_0 != 282 && int_0 != 283 && int_0 != 292 && int_0 != 341 && int_0 != 342 && int_0 != 344 && int_0 != 345 && int_0 != 347 && int_0 != 349 && int_0 != 350 && int_0 != 356 && int_0 != 358 && int_0 != 382 && int_0 != 401 && int_0 != 404 && int_0 != 405 && int_0 != 406 && int_0 != 407 && int_0 != 418 && int_0 != 419 && int_0 != 428 && int_0 != 431 && int_0 != 438 && int_0 != 452 && int_0 != 459 && int_0 != 462 && int_0 != 463 && int_0 != 465 && int_0 != 466 && int_0 != 468 && int_0 != 470 && int_0 != 471 && int_0 != 475 && int_0 != 486 && int_0 != 489 && int_0 != 490 && int_0 != 492 && int_0 != 493 && int_0 != 495 && int_0 != 497 && int_0 != 498 && int_0 != 501 && int_0 != 502 && int_0 != 504 && int_0 != 505 && int_0 != 507 && int_0 != 509 && int_0 != 510 && int_0 != 522 && int_0 != 525 && int_0 != 528 && int_0 != 529 && int_0 != 531 && int_0 != 532 && int_0 != 534 && int_0 != 536 && int_0 != 537 && int_0 != 540 && int_0 != 541 && int_0 != 543 && int_0 != 544 && int_0 != 546 && int_0 != 548 && int_0 != 549 && int_0 != 555 && int_0 != 556 && int_0 != 558 && int_0 != 559 && int_0 != 561 && int_0 != 563 && int_0 != 564)
				{
					checkBox_0.Visible = false;
					label_2.Visible = true;
					textBox_0.Visible = true;
					label_3.Visible = true;
					textBox_1.Visible = true;
					comboBox_2.Visible = false;
					comboBox_3.Visible = false;
					return;
				}
				checkBox_0.Visible = false;
				label_2.Visible = true;
				textBox_0.Visible = false;
				label_3.Visible = true;
				textBox_1.Visible = false;
				comboBox_2.Visible = true;
				comboBox_3.Visible = true;
				if (int_0 == 233)
				{
					comboBox_2.DropDownStyle = ComboBoxStyle.DropDown;
					comboBox_3.DropDownStyle = ComboBoxStyle.DropDown;
				}
				else
				{
					comboBox_2.DropDownStyle = ComboBoxStyle.DropDownList;
					comboBox_3.DropDownStyle = ComboBoxStyle.DropDownList;
				}
				if (int_0 == 0)
				{
					int num = 0;
					if (GlobalData.version >= 156)
					{
						num = 50;
					}
					string_0 = new string[29]
					{
						GProD.TX(2000 + num),
						GProD.TX(2001 + num),
						GProD.TX(2002 + num),
						GProD.TX(2003 + num),
						GProD.TX(2004 + num),
						GProD.TX(2005 + num),
						GProD.TX(2006 + num),
						GProD.TX(2007 + num),
						GProD.TX(2008 + num),
						GProD.TX(2009 + num),
						GProD.TX(2010 + num),
						GProD.TX(2011 + num),
						GProD.TX(2012 + num),
						GProD.TX(2013 + num),
						GProD.TX(2014 + num),
						GProD.TX(2015 + num),
						GProD.TX(2016 + num),
						GProD.TX(2017 + num),
						GProD.TX(2018 + num),
						GProD.TX(2019 + num),
						GProD.TX(2020 + num),
						GProD.TX(2021 + num),
						GProD.TX(2022 + num),
						GProD.TX(2023 + num),
						GProD.TX(2024 + num),
						GProD.TX(2025 + num),
						GProD.TX(2026 + num),
						GProD.TX(9050 + num),
						GProD.TX(9051 + num)
					};
				}
				else if (int_0 != 9 && int_0 != 18 && int_0 != 24 && int_0 != 181)
				{
					if (int_0 == 12)
					{
						string_0 = new string[4]
						{
							GProD.TX(2200),
							GProD.TX(2201),
							GProD.TX(2202),
							GProD.TX(2203)
						};
					}
					else if (int_0 == 25)
					{
						string_0 = new string[5]
						{
							GProD.TX(2300),
							GProD.TX(2301),
							GProD.TX(2302),
							GProD.TX(2303),
							GProD.TX(2304)
						};
					}
					else if (int_0 != 88 && int_0 != 486 && int_0 != 525)
					{
						if (int_0 == 522)
						{
							string_0 = new string[GProD.gfxtypeslist.Count];
							Dictionary<int, int>.ValueCollection values = GProD.gfxtypeslist.Values;
							for (int i = 0; i < string_0.Length; i++)
							{
								string_0[i] = GProD.TX(values.ElementAt(i));
							}
						}
						else if (int_0 == 428)
						{
							string_0 = new string[2]
							{
								GProD.TX(2310),
								GProD.TX(2311)
							};
						}
						else if (int_0 == 155)
						{
							string_0 = new string[17]
							{
								GProD.TX(2400),
								GProD.TX(2401),
								GProD.TX(2402),
								GProD.TX(2403),
								GProD.TX(2404),
								GProD.TX(2405),
								GProD.TX(2406),
								GProD.TX(2407),
								GProD.TX(2408),
								GProD.TX(2420),
								GProD.TX(2430),
								GProD.TX(2421),
								GProD.TX(2431),
								GProD.TX(2422),
								GProD.TX(2432),
								GProD.TX(2440),
								GProD.TX(2441)
							};
						}
						else if (int_0 == 158)
						{
							string_0 = new string[5]
							{
								GProD.TX(2450),
								GProD.TX(2451),
								GProD.TX(2452),
								GProD.TX(2453),
								GProD.TX(2454)
							};
						}
						else if (int_0 != 160 && int_0 != 214 && int_0 != 292)
						{
							if (int_0 == 174)
							{
								string_0 = new string[2]
								{
									GProD.TX(3880),
									GProD.TX(3881)
								};
							}
							else if (int_0 == 175)
							{
								string_0 = new string[2]
								{
									GProD.TX(3890),
									GProD.TX(3891)
								};
							}
							else if (int_0 == 184)
							{
								string_0 = new string[2]
								{
									GProD.TX(3900),
									GProD.TX(3901)
								};
							}
							else if (int_0 == 190)
							{
								string_0 = new string[4]
								{
									GProD.TX(2463),
									GProD.TX(2464),
									GProD.TX(2465),
									GProD.TX(2466)
								};
							}
							else if (int_0 == 212)
							{
								string_0 = new string[7]
								{
									GProD.TX(2470),
									GProD.TX(2471),
									GProD.TX(2472),
									GProD.TX(2473),
									GProD.TX(2474),
									GProD.TX(2475),
									GProD.TX(2476)
								};
							}
							else if (int_0 == 213)
							{
								string_0 = new string[16]
								{
									GProD.TX(2480),
									GProD.TX(2481),
									GProD.TX(2482),
									GProD.TX(2483),
									GProD.TX(2484),
									GProD.TX(2485),
									GProD.TX(2486),
									GProD.TX(2487),
									GProD.TX(2488),
									GProD.TX(2489),
									GProD.TX(2490),
									GProD.TX(2491),
									GProD.TX(2492),
									GProD.TX(2493),
									GProD.TX(2494),
									GProD.TX(2495)
								};
							}
							else if (int_0 != 221 && int_0 != 341 && int_0 != 462 && int_0 != 489 && int_0 != 501 && int_0 != 528 && int_0 != 540 && int_0 != 555)
							{
								if (int_0 != 222 && int_0 != 225 && int_0 != 227 && int_0 != 230 && int_0 != 342 && int_0 != 345 && int_0 != 347 && int_0 != 350 && int_0 != 463 && int_0 != 466 && int_0 != 468 && int_0 != 471 && int_0 != 490 && int_0 != 493 && int_0 != 495 && int_0 != 498 && int_0 != 502 && int_0 != 505 && int_0 != 507 && int_0 != 510 && int_0 != 529 && int_0 != 532 && int_0 != 534 && int_0 != 537 && int_0 != 541 && int_0 != 544 && int_0 != 546 && int_0 != 549 && int_0 != 556 && int_0 != 559 && int_0 != 561 && int_0 != 564)
								{
									if (int_0 != 224 && int_0 != 229 && int_0 != 344 && int_0 != 349 && int_0 != 465 && int_0 != 470 && int_0 != 492 && int_0 != 497 && int_0 != 504 && int_0 != 509 && int_0 != 531 && int_0 != 536 && int_0 != 543 && int_0 != 548 && int_0 != 558 && int_0 != 563)
									{
										if (int_0 == 257)
										{
											string_0 = new string[6]
											{
												GProD.TX(2540),
												GProD.TX(2541),
												GProD.TX(2542),
												GProD.TX(2543),
												GProD.TX(2544),
												GProD.TX(2545)
											};
										}
										else if (int_0 == 269)
										{
											string_0 = new string[6]
											{
												GProD.TX(2550),
												GProD.TX(2551),
												GProD.TX(2552),
												GProD.TX(2553),
												GProD.TX(2554),
												GProD.TX(2555)
											};
										}
										else if (int_0 == 273)
										{
											string_0 = new string[5]
											{
												GProD.TX(2560),
												GProD.TX(2561),
												GProD.TX(2562),
												GProD.TX(2563),
												GProD.TX(2564)
											};
										}
										else if (int_0 == 282)
										{
											string_0 = new string[43]
											{
												GProD.TX(2570),
												GProD.TX(2571),
												GProD.TX(2572),
												GProD.TX(2573),
												GProD.TX(2574),
												GProD.TX(2575),
												GProD.TX(2576),
												GProD.TX(2577),
												GProD.TX(2578),
												GProD.TX(2579),
												GProD.TX(2580),
												GProD.TX(2581),
												GProD.TX(2582),
												GProD.TX(2583),
												GProD.TX(2584),
												GProD.TX(2585),
												GProD.TX(2586),
												GProD.TX(2587),
												GProD.TX(2588),
												GProD.TX(2589),
												GProD.TX(2590),
												GProD.TX(2591),
												GProD.TX(2592),
												GProD.TX(2593),
												GProD.TX(2594),
												GProD.TX(2595),
												GProD.TX(2596),
												GProD.TX(2597),
												GProD.TX(2598),
												GProD.TX(2599),
												GProD.TX(2600),
												GProD.TX(2601),
												GProD.TX(2602),
												GProD.TX(2603),
												GProD.TX(2604),
												GProD.TX(2605),
												GProD.TX(2606),
												GProD.TX(2607),
												GProD.TX(9102),
												GProD.TX(9103),
												GProD.TX(9104),
												GProD.TX(9105),
												GProD.TX(9106)
											};
										}
										else if (int_0 == 283)
										{
											string_0 = new string[6]
											{
												GProD.TX(2610),
												GProD.TX(2611),
												GProD.TX(2612),
												GProD.TX(2613),
												GProD.TX(2614),
												GProD.TX(2615)
											};
										}
										else if (int_0 == 356)
										{
											string_0 = new string[GProD.emotionslist.Count];
											Dictionary<int, int>.ValueCollection values2 = GProD.emotionslist.Values;
											for (int j = 0; j < string_0.Length; j++)
											{
												string_0[j] = GProD.TX(values2.ElementAt(j));
											}
										}
										else if (int_0 == 358)
										{
											string_0 = new string[9]
											{
												GProD.TX(2900),
												GProD.TX(2901),
												GProD.TX(2902),
												GProD.TX(2903),
												GProD.TX(2904),
												GProD.TX(2905),
												GProD.TX(2906),
												GProD.TX(2907),
												GProD.TX(2908)
											};
										}
										else if (int_0 == 382)
										{
											string_0 = new string[3]
											{
												GProD.TX(3500),
												GProD.TX(3501),
												GProD.TX(3502)
											};
										}
										else if (int_0 != 401 && int_0 != 405)
										{
											if (int_0 != 404 && int_0 != 406 && int_0 != 407 && int_0 != 418 && int_0 != 431)
											{
												if (int_0 == 419)
												{
													string_0 = new string[6]
													{
														GProD.TX(3860),
														GProD.TX(3861),
														GProD.TX(3862),
														GProD.TX(3863),
														GProD.TX(3864),
														GProD.TX(3865)
													};
												}
												else if (int_0 == 438)
												{
													string_0 = new string[10]
													{
														GProD.TX(3910),
														GProD.TX(3911),
														GProD.TX(3912),
														GProD.TX(3913),
														GProD.TX(3914),
														GProD.TX(3915),
														GProD.TX(3916),
														GProD.TX(3917),
														GProD.TX(3918),
														GProD.TX(3919)
													};
												}
												else if (int_0 != 452 && int_0 != 459)
												{
													if (int_0 == 475)
													{
														string_0 = new string[10]
														{
															GProD.TX(3920),
															GProD.TX(3921),
															GProD.TX(3922),
															GProD.TX(3923),
															GProD.TX(3924),
															GProD.TX(3925),
															GProD.TX(3926),
															GProD.TX(3927),
															GProD.TX(3928),
															GProD.TX(3929)
														};
													}
												}
												else
												{
													string_0 = new string[9]
													{
														GProD.TX(2099),
														GProD.TX(2100),
														GProD.TX(2101),
														GProD.TX(2102),
														GProD.TX(2103),
														GProD.TX(2104),
														GProD.TX(2105),
														GProD.TX(2106),
														GProD.TX(2107)
													};
												}
											}
											else
											{
												string_0 = new string[2]
												{
													GProD.TX(3850),
													GProD.TX(3851)
												};
											}
										}
										else
										{
											string_0 = new string[2]
											{
												GProD.TX(3840),
												GProD.TX(3841)
											};
										}
									}
									else
									{
										string_0 = new string[4]
										{
											GProD.TX(2520),
											GProD.TX(2521),
											GProD.TX(2522),
											GProD.TX(2523)
										};
									}
								}
								else
								{
									string_0 = new string[2]
									{
										GProD.TX(2510),
										GProD.TX(2511)
									};
								}
							}
							else
							{
								string_0 = new string[2]
								{
									GProD.TX(3140),
									GProD.TX(3141)
								};
							}
						}
						else
						{
							string_0 = new string[3]
							{
								GProD.TX(2460),
								GProD.TX(2461),
								GProD.TX(2462)
							};
						}
					}
					else
					{
						string_0 = new string[4]
						{
							GProD.TX(2620),
							GProD.TX(2621),
							GProD.TX(2622),
							GProD.TX(2623)
						};
					}
				}
				else
				{
					string_0 = new string[8]
					{
						GProD.TX(2100),
						GProD.TX(2101),
						GProD.TX(2102),
						GProD.TX(2103),
						GProD.TX(2104),
						GProD.TX(2105),
						GProD.TX(2106),
						GProD.TX(2107)
					};
				}
				string_1 = new string[string_0.Length];
				string_0.CopyTo(string_1, 0);
				comboBox_2.DataSource = string_0;
				comboBox_3.DataSource = string_1;
			}
			else
			{
				checkBox_0.Visible = true;
				label_2.Visible = false;
				textBox_0.Visible = false;
				label_3.Visible = false;
				textBox_1.Visible = false;
				comboBox_2.Visible = false;
				comboBox_3.Visible = false;
			}
			return;
		}
		int_0 = (int)arrayList_1[comboBox_1.SelectedIndex * 2];
		if (int_0 != 5 && int_0 != 23 && int_0 != 24 && int_0 != 25 && int_0 != 26 && int_0 != 28 && int_0 != 30 && int_0 != 34 && int_0 != 36 && int_0 != 41 && int_0 != 42 && int_0 != 44 && int_0 != 56 && int_0 != 59 && int_0 != 69 && int_0 != 87 && int_0 != 88 && int_0 != 93 && int_0 != 566)
		{
			if (int_0 != 0 && int_0 != 1 && int_0 != 9 && int_0 != 27 && int_0 != 65 && int_0 != 68 && int_0 != 70 && int_0 != 94 && int_0 != 95 && int_0 != 97 && int_0 != 98 && int_0 != 110)
			{
				checkBox_0.Visible = false;
				label_2.Visible = true;
				textBox_0.Visible = true;
				label_3.Visible = true;
				textBox_1.Visible = true;
				comboBox_2.Visible = false;
				comboBox_3.Visible = false;
				return;
			}
			checkBox_0.Visible = false;
			label_2.Visible = true;
			textBox_0.Visible = false;
			label_3.Visible = true;
			textBox_1.Visible = false;
			comboBox_2.Visible = true;
			comboBox_3.Visible = true;
			if (int_0 != 0 && int_0 != 1)
			{
				if (int_0 == 9)
				{
					string_0 = new string[17]
					{
						GProD.TX(2399),
						GProD.TX(2401),
						GProD.TX(2402),
						GProD.TX(2403),
						GProD.TX(2404),
						GProD.TX(2405),
						GProD.TX(2406),
						GProD.TX(2407),
						GProD.TX(2408),
						GProD.TX(2420),
						GProD.TX(2430),
						GProD.TX(2421),
						GProD.TX(2431),
						GProD.TX(2422),
						GProD.TX(2432),
						GProD.TX(2440),
						GProD.TX(2441)
					};
				}
				else if (int_0 == 27)
				{
					string_0 = new string[16]
					{
						GProD.TX(2930),
						GProD.TX(2931),
						GProD.TX(2932),
						GProD.TX(2933),
						GProD.TX(2934),
						GProD.TX(2935),
						GProD.TX(2936),
						GProD.TX(2937),
						GProD.TX(2938),
						GProD.TX(2939),
						GProD.TX(2940),
						GProD.TX(2941),
						GProD.TX(2942),
						GProD.TX(2943),
						GProD.TX(2944),
						GProD.TX(2945)
					};
				}
				else if (int_0 != 65 && int_0 != 68 && int_0 != 110)
				{
					if (int_0 == 70)
					{
						string_0 = new string[2]
						{
							GProD.TX(3530),
							GProD.TX(3531)
						};
					}
					else if (int_0 == 94)
					{
						string_0 = new string[3]
						{
							GProD.TX(3540),
							GProD.TX(3541),
							GProD.TX(3542)
						};
					}
					else if (int_0 == 95)
					{
						string_0 = new string[5]
						{
							GProD.TX(3550),
							GProD.TX(3551),
							GProD.TX(3552),
							GProD.TX(3553),
							GProD.TX(3554)
						};
					}
					else if (int_0 == 97)
					{
						string_0 = new string[2]
						{
							GProD.TX(3840),
							GProD.TX(3841)
						};
					}
					else if (int_0 == 98)
					{
						string_0 = new string[3]
						{
							GProD.TX(3870),
							GProD.TX(3871),
							GProD.TX(3872)
						};
					}
				}
				else
				{
					string_0 = new string[4]
					{
						GProD.TX(2620),
						GProD.TX(2621),
						GProD.TX(2622),
						GProD.TX(2623)
					};
				}
			}
			else
			{
				string_0 = new string[7]
				{
					GProD.TX(2920),
					GProD.TX(2921),
					GProD.TX(2922),
					GProD.TX(2923),
					GProD.TX(2924),
					GProD.TX(2925),
					GProD.TX(2926)
				};
			}
			string_1 = new string[string_0.Length];
			string_0.CopyTo(string_1, 0);
			comboBox_2.DataSource = string_0;
			comboBox_3.DataSource = string_1;
		}
		else
		{
			checkBox_0.Visible = true;
			label_2.Visible = false;
			textBox_0.Visible = false;
			label_3.Visible = false;
			textBox_1.Visible = false;
			comboBox_2.Visible = false;
			comboBox_3.Visible = false;
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		Close();
	}

	public void SetLocalization()
	{
		Dictionary<Control, int> dictionary = new Dictionary<Control, int>
		{
			{ radioButton_0, 6056 },
			{ radioButton_1, 6057 },
			{ radioButton_2, 6058 },
			{ radioButton_3, 6059 },
			{ radioButton_4, 6060 },
			{ radioButton_5, 6061 },
			{ checkBox_1, 6062 },
			{ checkBox_2, 6063 },
			{ checkBox_3, 6064 },
			{ checkBox_4, 6065 },
			{ checkBox_5, 6108 },
			{ checkBox_6, 6109 },
			{ checkBox_7, 6110 },
			{ checkBox_8, 6111 },
			{ checkBox_9, 6126 },
			{ checkBox_10, 6127 },
			{ checkBox_11, 6146 },
			{ checkBox_12, 6147 },
			{ label_0, 6066 },
			{ label_1, 6067 },
			{ label_2, 6068 },
			{ label_3, 6069 },
			{ checkBox_0, 6069 },
			{ button_0, 6070 },
			{ button_1, 6002 }
		};
		foreach (KeyValuePair<Control, int> item in dictionary)
		{
			item.Key.Text = GProD.TX(item.Value);
		}
		comboBox_0.Items.Clear();
		comboBox_0.Items.AddRange(new object[5]
		{
			GProD.TX(3150),
			GProD.TX(3151),
			GProD.TX(3152),
			GProD.TX(3153),
			GProD.TX(3154)
		});
		Text = GProD.TX(6055);
	}
}
