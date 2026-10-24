using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.sTASKedit.Classes.Extensions;
using ACE.sTASKedit.Classes.GlobalProgramData;
using ACE.sTASKedit.tasks;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Classes.ExtendedSearch;

internal class ExtendedSearch
{
	// TODO(recovered): bumped private->internal (cascade from Struct117 becoming internal).
	internal sealed class Class394
	{
		private List<long> list_0;

		private ArrayList arrayList_0;

		private ArrayList arrayList_1;

		private ArrayList arrayList_2;

		private ArrayList arrayList_3;

		private bool bool_0;

		private bool bool_1;

		public List<long> method_0()
		{
			return list_0;
		}

		public void method_1(List<long> list_1)
		{
			list_0 = list_1;
		}

		public ArrayList method_2()
		{
			return arrayList_0;
		}

		public void method_3(ArrayList arrayList_4)
		{
			arrayList_0 = arrayList_4;
		}

		public ArrayList method_4()
		{
			return arrayList_1;
		}

		public void method_5(ArrayList arrayList_4)
		{
			arrayList_1 = arrayList_4;
		}

		public ArrayList method_6()
		{
			return arrayList_2;
		}

		public void method_7(ArrayList arrayList_4)
		{
			arrayList_2 = arrayList_4;
		}

		public ArrayList method_8()
		{
			return arrayList_3;
		}

		public void method_9(ArrayList arrayList_4)
		{
			arrayList_3 = arrayList_4;
		}

		public bool method_10()
		{
			return bool_0;
		}

		public void method_11(bool bool_2)
		{
			bool_0 = bool_2;
		}

		public bool method_12()
		{
			return bool_1;
		}

		public void method_13(bool bool_2)
		{
			bool_1 = bool_2;
		}
	}

	[Serializable]
	private sealed class Class395
	{
		public static readonly Class395 class395_0 = new Class395();

		public static Func<int, string> func_0;

		public static Func<int, string> func_1;

		internal string method_0(int int_0)
		{
			return GProD.TX(int_0, appendsymbols: true);
		}

		internal string method_1(int int_0)
		{
			return GProD.TX(int_0);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	// TODO(recovered): bumped private->internal to match the ref-param method that exposes it.
	internal struct Struct117
	{
		public string string_0;

		public Class394 class394_0;
	}

	private sealed class Class396
	{
		public List<string> list_0;

		internal void method_0(string string_0)
		{
			if (!list_0.Contains(string_0))
			{
				list_0.Add(string_0);
			}
		}
	}

	private static readonly int[] int_0 = new int[6] { 5000, 5001, 5002, 5003, 5004, 5005 };

	private static readonly int[] int_1 = new int[8] { 5104, 8010, 5011, 5012, 5013, 5014, 5015, 5016 };

	private static readonly int[] int_2 = new int[131]
	{
		1011, 1012, 8009, 1037, 1045, 1048, 1049, 1058, 1059, 1063,
		1073, 1075, 1079, 1084, 1086, 1087, 1091, 1092, 1095, 1096,
		1103, 1104, 1105, 1107, 1108, 1112, 1113, 1116, 1118, 1148,
		1149, 1152, 1153, 1155, 1156, 1157, 1159, 1160, 1161, 1162,
		1163, 1164, 1170, 1174, 1177, 1179, 1190, 1192, 1194, 1196,
		1198, 1200, 1206, 1209, 1210, 1212, 1214, 1215, 1217, 1219,
		1220, 1222, 1223, 1226, 1227, 1229, 1230, 1231, 1233, 1234,
		1238, 1239, 1243, 1244, 1245, 1246, 1247, 1248, 1249, 1251,
		1265, 1266, 1267, 1268, 1269, 1270, 1271, 1272, 1273, 1281,
		1282, 1283, 1287, 1289, 1290, 1298, 1300, 1302, 1304, 1314,
		1316, 1319, 1320, 1321, 1322, 1324, 1325, 1327, 1329, 1334,
		1341, 1344, 1346, 1358, 1359, 1363, 1364, 1365, 1381, 1382,
		1395, 1397, 1800, 1801, 1802, 1805, 1809, 1810, 1811, 1812,
		1813
	};

	private static readonly int[] int_3 = new int[206]
	{
		1100, 1101, 1106, 1109, 1111, 1114, 1115, 1117, 1119, 1120,
		1121, 1122, 1123, 1124, 1125, 1126, 1127, 1128, 1129, 1130,
		1131, 1132, 1133, 1134, 1140, 1141, 1142, 1143, 1144, 1145,
		1146, 1147, 1150, 1151, 1165, 1166, 1167, 1168, 1169, 1171,
		1172, 1173, 1175, 1176, 1178, 1180, 1181, 1182, 1184, 1185,
		1189, 1191, 1193, 1195, 1197, 1199, 1201, 1202, 1203, 1204,
		1205, 1208, 1211, 1213, 1216, 1218, 1221, 1224, 1228, 1232,
		1235, 1236, 1237, 1277, 1278, 1279, 1280, 1284, 1285, 1294,
		1296, 1297, 1299, 1301, 1303, 1311, 1312, 1313, 1315, 1317,
		1323, 1328, 1336, 1337, 1338, 1340, 1342, 1343, 1345, 1347,
		1349, 1351, 1352, 1356, 1357, 1366, 1369, 1373, 1379, 1380,
		1385, 1389, 1396, 1398, 1002, 1006, 1007, 1009, 1010, 1013,
		1014, 1015, 1016, 1017, 1018, 1019, 1020, 1021, 1022, 1023,
		1031, 1038, 1039, 1040, 1041, 1042, 1043, 1044, 1046, 1047,
		1050, 1051, 1052, 1053, 1055, 1056, 1057, 1060, 1061, 1062,
		1064, 1065, 1066, 1067, 1068, 1070, 1071, 1074, 1076, 1077,
		1078, 1080, 1081, 1082, 1083, 1085, 1088, 1089, 1090, 1093,
		1094, 1097, 1098, 1259, 1604, 1606, 1608, 5028, 5050, 8011,
		8012, 1513, 4358, 4359, 4360, 4361, 4362, 4363, 4364, 4365,
		4370, 4371, 4372, 4374, 4375, 4376, 4377, 4378, 4383, 4384,
		4386, 4387, 4388, 4390, 4391, 4397
	};

	private static readonly int[] int_4 = new int[46]
	{
		1024, 1186, 1260, 1275, 1276, 1295, 1330, 1331, 1332, 1353,
		1368, 1370, 1374, 1384, 1386, 1390, 1399, 1605, 1607, 4369,
		4380, 4381, 4382, 4385, 4389, 4392, 4393, 4394, 4395, 4396,
		4398, 4399, 4400, 4401, 4402, 4403, 4404, 4405, 4406, 4407,
		4408, 4409, 4410, 4411, 4412, 4413
	};

	private static readonly int[] int_5 = new int[12]
	{
		1415, 1433, 1434, 1435, 1436, 1446, 1447, 1449, 1465, 1484,
		1485, 1513
	};

	private static readonly int[] int_6 = new int[64]
	{
		1412, 1413, 1414, 1416, 1417, 1418, 1419, 1420, 1421, 1422,
		1423, 1424, 1425, 1426, 1427, 1432, 1437, 1438, 1448, 1450,
		1451, 1452, 1453, 1454, 1455, 1456, 1457, 1458, 1459, 1460,
		1466, 1467, 1471, 1472, 1473, 1474, 1475, 1477, 1478, 1479,
		1480, 1481, 1482, 1483, 1486, 1487, 1493, 1494, 1495, 1496,
		1498, 1499, 1500, 1501, 1502, 1503, 1505, 1506, 1507, 1508,
		1509, 1510, 1511, 1512
	};

	private static readonly int[] int_7 = new int[3] { 1709, 1716, 1719 };

	private static readonly int[] int_8 = new int[3] { 1710, 1714, 1718 };

	private static readonly int[] int_9 = new int[8] { 1001, 1003, 1326, 1288, 1700, 1701, 1702, 1703 };

	private static readonly int[] int_10 = new int[12]
	{
		3510, 3511, 3512, 3513, 3514, 3515, 3516, 3517, 3518, 3519,
		3520, 3521
	};

	private static readonly int[] int_11 = new int[5] { 1704, 1705, 1706, 1707, 1708 };

	private static void smethod_0(ref DataGridView dataGridView_0, ATaskTempl ataskTempl_0, int int_12, int int_13, List<long> list_0, ArrayList arrayList_0, ArrayList arrayList_1, ArrayList arrayList_2, ArrayList arrayList_3, string string_0, string string_1)
	{
		switch (int_13)
		{
		case 1:
		{
			bool flag = Convert.ToBoolean(Convert.ToDouble(string_1));
			for (int num3 = 0; num3 < list_0.Count; num3++)
			{
				switch ((int)list_0[num3])
				{
				case 1277:
					if (smethod_6(int_12, ataskTempl_0.m_bPremNoHome, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1277), mConvert.BS(ataskTempl_0.m_bPremNoHome));
					}
					break;
				case 1278:
					if (smethod_6(int_12, ataskTempl_0.m_bCanAwardOnCarrier, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1278), mConvert.BS(ataskTempl_0.m_bCanAwardOnCarrier));
					}
					break;
				case 1279:
					if (smethod_6(int_12, ataskTempl_0.m_bNotOpenWithItem, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1279), mConvert.BS(ataskTempl_0.m_bNotOpenWithItem));
					}
					break;
				case 1280:
					if (smethod_6(int_12, ataskTempl_0.m_bMonsterTotalCount, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1280), mConvert.BS(ataskTempl_0.m_bMonsterTotalCount));
					}
					break;
				case 1284:
					if (smethod_6(int_12, ataskTempl_0.m_bPremReachArenaWinCount, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1284), mConvert.BS(ataskTempl_0.m_bPremReachArenaWinCount));
					}
					break;
				case 1285:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByReachArenaWinCount, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1285), mConvert.BS(ataskTempl_0.m_bShowByReachArenaWinCount));
					}
					break;
				case 1002:
					if (smethod_6(int_12, ataskTempl_0.m_bHasSign, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1002), mConvert.BS(ataskTempl_0.m_bHasSign));
					}
					break;
				case 1006:
					if (smethod_6(int_12, ataskTempl_0.m_bOfflineFail, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1006), mConvert.BS(ataskTempl_0.m_bOfflineFail));
					}
					break;
				case 1007:
					if (smethod_6(int_12, ataskTempl_0.m_bAbsFail, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1007), mConvert.BS(ataskTempl_0.m_bAbsFail));
					}
					break;
				case 1009:
					if (smethod_6(int_12, ataskTempl_0.m_bItemNotTakeOff, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1009), mConvert.BS(ataskTempl_0.m_bItemNotTakeOff));
					}
					break;
				case 1010:
					if (smethod_6(int_12, ataskTempl_0.m_bAbsTime, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1010), mConvert.BS(ataskTempl_0.m_bAbsTime));
					}
					break;
				case 1013:
					if (smethod_6(int_12, ataskTempl_0.m_bChooseOne, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1013), mConvert.BS(ataskTempl_0.m_bChooseOne));
					}
					break;
				case 1014:
					if (smethod_6(int_12, ataskTempl_0.m_bRandOne, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1014), mConvert.BS(ataskTempl_0.m_bRandOne));
					}
					break;
				case 1015:
					if (smethod_6(int_12, ataskTempl_0.m_bExeChildInOrder, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1015), mConvert.BS(ataskTempl_0.m_bExeChildInOrder));
					}
					break;
				case 1016:
					if (smethod_6(int_12, ataskTempl_0.m_bParentAlsoFail, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1016), mConvert.BS(ataskTempl_0.m_bParentAlsoFail));
					}
					break;
				case 1017:
					if (smethod_6(int_12, ataskTempl_0.m_bParentAlsoSucc, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1017), mConvert.BS(ataskTempl_0.m_bParentAlsoSucc));
					}
					break;
				case 1018:
					if (smethod_6(int_12, ataskTempl_0.m_bCanGiveUp, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1018), mConvert.BS(ataskTempl_0.m_bCanGiveUp));
					}
					break;
				case 1019:
					if (smethod_6(int_12, ataskTempl_0.m_bCanRedo, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1019), mConvert.BS(ataskTempl_0.m_bCanRedo));
					}
					break;
				case 1020:
					if (smethod_6(int_12, ataskTempl_0.m_bCanRedoAfterFailure, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1020), mConvert.BS(ataskTempl_0.m_bCanRedoAfterFailure));
					}
					break;
				case 1021:
					if (smethod_6(int_12, ataskTempl_0.m_bClearAsGiveUp, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1021), mConvert.BS(ataskTempl_0.m_bClearAsGiveUp));
					}
					break;
				case 1022:
					if (smethod_6(int_12, ataskTempl_0.m_bNeedRecord, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1022), mConvert.BS(ataskTempl_0.m_bNeedRecord));
					}
					break;
				case 1023:
					if (smethod_6(int_12, ataskTempl_0.m_bFailAsPlayerDie, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1023), mConvert.BS(ataskTempl_0.m_bFailAsPlayerDie));
					}
					break;
				case 1031:
					if (smethod_6(int_12, ataskTempl_0.m_bLeaveForceFail, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1031), mConvert.BS(ataskTempl_0.m_bLeaveForceFail));
					}
					break;
				case 1038:
					if (smethod_6(int_12, ataskTempl_0.m_bTrigCtrl, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1038), mConvert.BS(ataskTempl_0.m_bTrigCtrl));
					}
					break;
				case 1039:
					if (smethod_6(int_12, ataskTempl_0.m_bAutoDeliver, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1039), mConvert.BS(ataskTempl_0.m_bAutoDeliver));
					}
					break;
				case 1040:
					if (smethod_6(int_12, ataskTempl_0.m_bDisplayInExclusiveUI, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1040), mConvert.BS(ataskTempl_0.m_bDisplayInExclusiveUI));
					}
					break;
				case 1041:
					if (smethod_6(int_12, ataskTempl_0.m_bReadyToNotifyServer, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1041), mConvert.BS(ataskTempl_0.m_bReadyToNotifyServer));
					}
					break;
				case 1042:
					if (smethod_6(int_12, ataskTempl_0.m_bUsedInTokenShop, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1042), mConvert.BS(ataskTempl_0.m_bUsedInTokenShop));
					}
					break;
				case 1043:
					if (smethod_6(int_12, ataskTempl_0.m_bDeathTrig, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1043), mConvert.BS(ataskTempl_0.m_bDeathTrig));
					}
					break;
				case 1044:
					if (smethod_6(int_12, ataskTempl_0.m_bClearAcquired, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1044), mConvert.BS(ataskTempl_0.m_bClearAcquired));
					}
					break;
				case 1046:
					if (smethod_6(int_12, ataskTempl_0.m_bShowPrompt, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1046), mConvert.BS(ataskTempl_0.m_bShowPrompt));
					}
					break;
				case 1047:
					if (smethod_6(int_12, ataskTempl_0.m_bKeyTask, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1047), mConvert.BS(ataskTempl_0.m_bKeyTask));
					}
					break;
				case 1050:
					if (smethod_6(int_12, ataskTempl_0.m_bSkillTask, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1050), mConvert.BS(ataskTempl_0.m_bSkillTask));
					}
					break;
				case 1051:
					if (smethod_6(int_12, ataskTempl_0.m_bCanSeekOut, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1051), mConvert.BS(ataskTempl_0.m_bCanSeekOut));
					}
					break;
				case 1052:
					if (smethod_6(int_12, ataskTempl_0.m_bShowDirection, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1052), mConvert.BS(ataskTempl_0.m_bShowDirection));
					}
					break;
				case 1053:
					if (smethod_6(int_12, ataskTempl_0.m_bMarriage, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1053), mConvert.BS(ataskTempl_0.m_bMarriage));
					}
					break;
				case 1055:
					if (smethod_6(int_12, ataskTempl_0.m_bSwitchSceneFail, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1055), mConvert.BS(ataskTempl_0.m_bSwitchSceneFail));
					}
					break;
				case 1056:
					if (smethod_6(int_12, ataskTempl_0.m_bHidden, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1056), mConvert.BS(ataskTempl_0.m_bHidden));
					}
					break;
				case 1057:
					if (smethod_6(int_12, ataskTempl_0.m_bDeliverySkill, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1057), mConvert.BS(ataskTempl_0.m_bDeliverySkill));
					}
					break;
				case 1060:
					if (smethod_6(int_12, ataskTempl_0.m_bShowGfxFinished, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1060), mConvert.BS(ataskTempl_0.m_bShowGfxFinished));
					}
					break;
				case 1061:
					if (smethod_6(int_12, ataskTempl_0.m_bChangePQRanking, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1061), mConvert.BS(ataskTempl_0.m_bChangePQRanking));
					}
					break;
				case 1062:
					if (smethod_6(int_12, ataskTempl_0.m_bCompareItemAndInventory, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1062), mConvert.BS(ataskTempl_0.m_bCompareItemAndInventory));
					}
					break;
				case 1064:
					if (smethod_6(int_12, ataskTempl_0.m_bTowerTask, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1064), mConvert.BS(ataskTempl_0.m_bTowerTask));
					}
					break;
				case 1065:
					if (smethod_6(int_12, ataskTempl_0.m_bHomeTask, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1065), mConvert.BS(ataskTempl_0.m_bHomeTask));
					}
					break;
				case 1066:
					if (smethod_6(int_12, ataskTempl_0.m_bDeliverInHostHome, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1066), mConvert.BS(ataskTempl_0.m_bDeliverInHostHome));
					}
					break;
				case 1067:
					if (smethod_6(int_12, ataskTempl_0.m_bFinishInHostHome, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1067), mConvert.BS(ataskTempl_0.m_bFinishInHostHome));
					}
					break;
				case 1068:
					if (smethod_6(int_12, ataskTempl_0.m_bPQTask, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1068), mConvert.BS(ataskTempl_0.m_bPQTask));
					}
					break;
				case 1070:
					if (smethod_6(int_12, ataskTempl_0.m_bPQSubTask, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1070), mConvert.BS(ataskTempl_0.m_bPQSubTask));
					}
					break;
				case 1071:
					if (smethod_6(int_12, ataskTempl_0.m_bClearContrib, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1071), mConvert.BS(ataskTempl_0.m_bClearContrib));
					}
					break;
				case 1074:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByNeedRecordTasksNum, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1074), mConvert.BS(ataskTempl_0.m_bShowByNeedRecordTasksNum));
					}
					break;
				case 1076:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByFactionContrib, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1076), mConvert.BS(ataskTempl_0.m_bShowByFactionContrib));
					}
					break;
				case 1077:
					if (smethod_6(int_12, ataskTempl_0.m_bAccountTaskLimit, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1077), mConvert.BS(ataskTempl_0.m_bAccountTaskLimit));
					}
					break;
				case 1078:
					if (smethod_6(int_12, ataskTempl_0.m_bRoleTaskLimit, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1078), mConvert.BS(ataskTempl_0.m_bRoleTaskLimit));
					}
					break;
				case 1080:
					if (smethod_6(int_12, ataskTempl_0.m_bLeaveFactionFail, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1080), mConvert.BS(ataskTempl_0.m_bLeaveFactionFail));
					}
					break;
				case 1081:
					if (smethod_6(int_12, ataskTempl_0.m_bNotIncCntWhenFailed, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1081), mConvert.BS(ataskTempl_0.m_bNotIncCntWhenFailed));
					}
					break;
				case 1082:
					if (smethod_6(int_12, ataskTempl_0.m_bNotClearItemWhenFailed, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1082), mConvert.BS(ataskTempl_0.m_bNotClearItemWhenFailed));
					}
					break;
				case 1083:
					if (smethod_6(int_12, ataskTempl_0.m_bDisplayInTitleTaskUI, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1083), mConvert.BS(ataskTempl_0.m_bDisplayInTitleTaskUI));
					}
					break;
				case 1085:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByTransformed, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1085), mConvert.BS(ataskTempl_0.m_bShowByTransformed));
					}
					break;
				case 1088:
					if (smethod_6(int_12, Convert.ToBoolean(ataskTempl_0.m_bPremCheckMaxHistoryLevel), flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1088), mConvert.BS(Convert.ToBoolean(ataskTempl_0.m_bPremCheckMaxHistoryLevel)));
					}
					break;
				case 1089:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByLev, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1089), mConvert.BS(ataskTempl_0.m_bShowByLev));
					}
					break;
				case 1090:
					if (smethod_6(int_12, ataskTempl_0.m_bPremCheckReincarnation, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1090), mConvert.BS(ataskTempl_0.m_bPremCheckReincarnation));
					}
					break;
				case 1093:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByReincarnation, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1093), mConvert.BS(ataskTempl_0.m_bShowByReincarnation));
					}
					break;
				case 1094:
					if (smethod_6(int_12, ataskTempl_0.m_bPremCheckRealmLevel, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1094), mConvert.BS(ataskTempl_0.m_bPremCheckRealmLevel));
					}
					break;
				case 1097:
					if (smethod_6(int_12, ataskTempl_0.m_bPremCheckRealmExpFull, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1097), mConvert.BS(ataskTempl_0.m_bPremCheckRealmExpFull));
					}
					break;
				case 1098:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByRealmLevel, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1098), mConvert.BS(ataskTempl_0.m_bShowByRealmLevel));
					}
					break;
				case 1100:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByItems, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1100), mConvert.BS(ataskTempl_0.m_bShowByItems));
					}
					break;
				case 1101:
					if (smethod_6(int_12, ataskTempl_0.m_bPremItemsAnyOne, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1101), mConvert.BS(ataskTempl_0.m_bPremItemsAnyOne));
					}
					break;
				case 1106:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByDeposit, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1106), mConvert.BS(ataskTempl_0.m_bShowByDeposit));
					}
					break;
				case 1109:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByRepu, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1109), mConvert.BS(ataskTempl_0.m_bShowByRepu));
					}
					break;
				case 1111:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByPreTask, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1111), mConvert.BS(ataskTempl_0.m_bShowByPreTask));
					}
					break;
				case 1114:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByPeriod, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1114), mConvert.BS(ataskTempl_0.m_bShowByPeriod));
					}
					break;
				case 1115:
					if (smethod_6(int_12, Convert.ToBoolean(ataskTempl_0.m_ulPremise_Faction), flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1115), mConvert.BS(Convert.ToBoolean(ataskTempl_0.m_ulPremise_Faction)));
					}
					break;
				case 1117:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByFaction, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1117), mConvert.BS(ataskTempl_0.m_bShowByFaction));
					}
					break;
				case 1119:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByGender, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1119), mConvert.BS(ataskTempl_0.m_bShowByGender));
					}
					break;
				case 1120:
					if (smethod_9(int_12, flag, ataskTempl_0, 0))
					{
						if (int_12 == 1)
						{
							flag = !flag;
						}
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1120), mConvert.BS(flag));
					}
					break;
				case 1121:
					if (smethod_9(int_12, flag, ataskTempl_0, 1))
					{
						if (int_12 == 1)
						{
							flag = !flag;
						}
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1121), mConvert.BS(flag));
					}
					break;
				case 1122:
					if (smethod_9(int_12, flag, ataskTempl_0, 2))
					{
						if (int_12 == 1)
						{
							flag = !flag;
						}
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1122), mConvert.BS(flag));
					}
					break;
				case 1123:
					if (smethod_9(int_12, flag, ataskTempl_0, 3))
					{
						if (int_12 == 1)
						{
							flag = !flag;
						}
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1123), mConvert.BS(flag));
					}
					break;
				case 1124:
					if (smethod_9(int_12, flag, ataskTempl_0, 4))
					{
						if (int_12 == 1)
						{
							flag = !flag;
						}
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1124), mConvert.BS(flag));
					}
					break;
				case 1125:
					if (smethod_9(int_12, flag, ataskTempl_0, 5))
					{
						if (int_12 == 1)
						{
							flag = !flag;
						}
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1125), mConvert.BS(flag));
					}
					break;
				case 1126:
					if (smethod_9(int_12, flag, ataskTempl_0, 6))
					{
						if (int_12 == 1)
						{
							flag = !flag;
						}
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1126), mConvert.BS(flag));
					}
					break;
				case 1127:
					if (smethod_9(int_12, flag, ataskTempl_0, 7))
					{
						if (int_12 == 1)
						{
							flag = !flag;
						}
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1127), mConvert.BS(flag));
					}
					break;
				case 1128:
					if (smethod_9(int_12, flag, ataskTempl_0, 8))
					{
						if (int_12 == 1)
						{
							flag = !flag;
						}
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1128), mConvert.BS(flag));
					}
					break;
				case 1129:
					if (smethod_9(int_12, flag, ataskTempl_0, 9))
					{
						if (int_12 == 1)
						{
							flag = !flag;
						}
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1129), mConvert.BS(flag));
					}
					break;
				case 1130:
					if (smethod_9(int_12, flag, ataskTempl_0, 10))
					{
						if (int_12 == 1)
						{
							flag = !flag;
						}
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1130), mConvert.BS(flag));
					}
					break;
				case 1131:
					if (smethod_9(int_12, flag, ataskTempl_0, 11))
					{
						if (int_12 == 1)
						{
							flag = !flag;
						}
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1131), mConvert.BS(flag));
					}
					break;
				case 1132:
					if (smethod_9(int_12, flag, ataskTempl_0, 12))
					{
						if (int_12 == 1)
						{
							flag = !flag;
						}
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1132), mConvert.BS(flag));
					}
					break;
				case 1133:
					if (smethod_9(int_12, flag, ataskTempl_0, 13))
					{
						if (int_12 == 1)
						{
							flag = !flag;
						}
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1133), mConvert.BS(flag));
					}
					break;
				case 1134:
					if (smethod_9(int_12, flag, ataskTempl_0, 14))
					{
						if (int_12 == 1)
						{
							flag = !flag;
						}
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1134), mConvert.BS(flag));
					}
					break;
				case 1135:
					if (smethod_9(int_12, flag, ataskTempl_0, 15))
					{
						if (int_12 == 1)
						{
							flag = !flag;
						}
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1135), mConvert.BS(flag));
					}
					break;
				case 1136:
					if (smethod_9(int_12, flag, ataskTempl_0, 16))
					{
						if (int_12 == 1)
						{
							flag = !flag;
						}
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1136), mConvert.BS(flag));
					}
					break;
				case 1140:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByOccup, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1140), mConvert.BS(ataskTempl_0.m_bShowByOccup));
					}
					break;
				case 1141:
					if (smethod_6(int_12, ataskTempl_0.m_bPremise_Spouse, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1141), mConvert.BS(ataskTempl_0.m_bPremise_Spouse));
					}
					break;
				case 1142:
					if (smethod_6(int_12, ataskTempl_0.m_bShowBySpouse, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1142), mConvert.BS(ataskTempl_0.m_bShowBySpouse));
					}
					break;
				case 1143:
					if (smethod_6(int_12, ataskTempl_0.m_bPremiseWeddingOwner, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1143), mConvert.BS(ataskTempl_0.m_bPremiseWeddingOwner));
					}
					break;
				case 1144:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByWeddingOwner, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1144), mConvert.BS(ataskTempl_0.m_bShowByWeddingOwner));
					}
					break;
				case 1145:
					if (smethod_6(int_12, ataskTempl_0.m_bGM, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1145), mConvert.BS(ataskTempl_0.m_bGM));
					}
					break;
				case 1146:
					if (smethod_6(int_12, ataskTempl_0.m_bShieldUser, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1146), mConvert.BS(ataskTempl_0.m_bShieldUser));
					}
					break;
				case 1147:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByRMB, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1147), mConvert.BS(ataskTempl_0.m_bShowByRMB));
					}
					break;
				case 1150:
					if (smethod_6(int_12, ataskTempl_0.m_bCharTime, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1150), mConvert.BS(ataskTempl_0.m_bCharTime));
					}
					break;
				case 1151:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByCharTime, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1151), mConvert.BS(ataskTempl_0.m_bShowByCharTime));
					}
					break;
				case 1165:
					if (smethod_6(int_12, ataskTempl_0.m_bTeamwork, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1165), mConvert.BS(ataskTempl_0.m_bTeamwork));
					}
					break;
				case 1166:
					if (smethod_6(int_12, ataskTempl_0.m_bRcvByTeam, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1166), mConvert.BS(ataskTempl_0.m_bRcvByTeam));
					}
					break;
				case 1167:
					if (smethod_6(int_12, ataskTempl_0.m_bSharedTask, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1167), mConvert.BS(ataskTempl_0.m_bSharedTask));
					}
					break;
				case 1168:
					if (smethod_6(int_12, ataskTempl_0.m_bSharedAchieved, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1168), mConvert.BS(ataskTempl_0.m_bSharedAchieved));
					}
					break;
				case 1169:
					if (smethod_6(int_12, ataskTempl_0.m_bCheckTeammate, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1169), mConvert.BS(ataskTempl_0.m_bCheckTeammate));
					}
					break;
				case 1171:
					if (smethod_6(int_12, ataskTempl_0.m_bAllFail, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1171), mConvert.BS(ataskTempl_0.m_bAllFail));
					}
					break;
				case 1172:
					if (smethod_6(int_12, ataskTempl_0.m_bCapFail, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1172), mConvert.BS(ataskTempl_0.m_bCapFail));
					}
					break;
				case 1173:
					if (smethod_6(int_12, ataskTempl_0.m_bCapSucc, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1173), mConvert.BS(ataskTempl_0.m_bCapSucc));
					}
					break;
				case 1175:
					if (smethod_6(int_12, ataskTempl_0.m_bDismAsSelfFail, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1175), mConvert.BS(ataskTempl_0.m_bDismAsSelfFail));
					}
					break;
				case 1176:
					if (smethod_6(int_12, ataskTempl_0.m_bRcvChckMem, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1176), mConvert.BS(ataskTempl_0.m_bRcvChckMem));
					}
					break;
				case 1178:
					if (smethod_6(int_12, ataskTempl_0.m_bCntByMemPos, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1178), mConvert.BS(ataskTempl_0.m_bCntByMemPos));
					}
					break;
				case 1180:
					if (smethod_6(int_12, ataskTempl_0.m_bAllSucc, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1180), mConvert.BS(ataskTempl_0.m_bAllSucc));
					}
					break;
				case 1181:
					if (smethod_6(int_12, ataskTempl_0.m_bCoupleOnly, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1181), mConvert.BS(ataskTempl_0.m_bCoupleOnly));
					}
					break;
				case 1182:
					if (smethod_6(int_12, ataskTempl_0.m_bDistinguishedOcc, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1182), mConvert.BS(ataskTempl_0.m_bDistinguishedOcc));
					}
					break;
				case 1184:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByTeam, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1184), mConvert.BS(ataskTempl_0.m_bShowByTeam));
					}
					break;
				case 1185:
					if (smethod_6(int_12, ataskTempl_0.m_bPremNeedComp, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1185), mConvert.BS(ataskTempl_0.m_bPremNeedComp));
					}
					break;
				case 1189:
					if (smethod_6(int_12, ataskTempl_0.m_bPremCheckForce, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1189), mConvert.BS(ataskTempl_0.m_bPremCheckForce));
					}
					break;
				case 1191:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByForce, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1191), mConvert.BS(ataskTempl_0.m_bShowByForce));
					}
					break;
				case 1193:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByForceReputation, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1193), mConvert.BS(ataskTempl_0.m_bShowByForceReputation));
					}
					break;
				case 1195:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByForceContribution, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1195), mConvert.BS(ataskTempl_0.m_bShowByForceContribution));
					}
					break;
				case 1197:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByForceExp, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1197), mConvert.BS(ataskTempl_0.m_bShowByForceExp));
					}
					break;
				case 1199:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByForceSP, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1199), mConvert.BS(ataskTempl_0.m_bShowByForceSP));
					}
					break;
				case 1201:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByForceActivityLevel, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1201), mConvert.BS(ataskTempl_0.m_bShowByForceActivityLevel));
					}
					break;
				case 1202:
					if (smethod_6(int_12, ataskTempl_0.m_bPremIsKing, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1202), mConvert.BS(ataskTempl_0.m_bPremIsKing));
					}
					break;
				case 1203:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByKing, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1203), mConvert.BS(ataskTempl_0.m_bShowByKing));
					}
					break;
				case 1204:
					if (smethod_6(int_12, ataskTempl_0.m_bPremNotInTeam, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1204), mConvert.BS(ataskTempl_0.m_bPremNotInTeam));
					}
					break;
				case 1205:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByNotInTeam, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1205), mConvert.BS(ataskTempl_0.m_bShowByNotInTeam));
					}
					break;
				case 1208:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByTitle, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1208), mConvert.BS(ataskTempl_0.m_bShowByTitle));
					}
					break;
				case 1211:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByHistoryStage, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1211), mConvert.BS(ataskTempl_0.m_bShowByHistoryStage));
					}
					break;
				case 1213:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByGeneralCard, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1213), mConvert.BS(ataskTempl_0.m_bShowByGeneralCard));
					}
					break;
				case 1216:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByGeneralCardRank, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1216), mConvert.BS(ataskTempl_0.m_bShowByGeneralCardRank));
					}
					break;
				case 1218:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByIconStateID, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1218), mConvert.BS(ataskTempl_0.m_bShowByIconStateID));
					}
					break;
				case 1221:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByVIPLevel, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1221), mConvert.BS(ataskTempl_0.m_bShowByVIPLevel));
					}
					break;
				case 1224:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByHomeLevel, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1224), mConvert.BS(ataskTempl_0.m_bShowByHomeLevel));
					}
					break;
				case 1228:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByHomeResourceLevel, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1228), mConvert.BS(ataskTempl_0.m_bShowByHomeResourceLevel));
					}
					break;
				case 1232:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByHomeFactoryLevel, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1232), mConvert.BS(ataskTempl_0.m_bShowByHomeFactoryLevel));
					}
					break;
				case 1235:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByHomeFlourish, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1235), mConvert.BS(ataskTempl_0.m_bShowByHomeFlourish));
					}
					break;
				case 1236:
					if (smethod_6(int_12, ataskTempl_0.m_bPremHomeStorageTask, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1236), mConvert.BS(ataskTempl_0.m_bPremHomeStorageTask));
					}
					break;
				case 1237:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByHomeStorageTask, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1237), mConvert.BS(ataskTempl_0.m_bShowByHomeStorageTask));
					}
					break;
				case 1259:
					if (smethod_6(int_12, ataskTempl_0.m_bFinNeedComp, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1259), mConvert.BS(ataskTempl_0.m_bFinNeedComp));
					}
					break;
				case 1311:
					if (smethod_6(int_12, ataskTempl_0.m_bDiscardedTask, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1311), mConvert.BS(ataskTempl_0.m_bDiscardedTask));
					}
					break;
				case 1312:
					if (smethod_6(int_12, ataskTempl_0.m_bNoCheckTitleGot, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1312), mConvert.BS(ataskTempl_0.m_bNoCheckTitleGot));
					}
					break;
				case 1313:
					if (smethod_6(int_12, ataskTempl_0.m_bBecomeMentor, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1313), mConvert.BS(ataskTempl_0.m_bBecomeMentor));
					}
					break;
				case 1315:
					if (smethod_6(int_12, ataskTempl_0.m_bShowMentorMorality, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1315), mConvert.BS(ataskTempl_0.m_bShowMentorMorality));
					}
					break;
				case 1317:
					if (smethod_6(int_12, ataskTempl_0.m_bShowMentorStudentValue, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1317), mConvert.BS(ataskTempl_0.m_bShowMentorStudentValue));
					}
					break;
				case 1294:
					if (smethod_6(int_12, ataskTempl_0.m_bCheckFactionMember, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1294), mConvert.BS(ataskTempl_0.m_bCheckFactionMember));
					}
					break;
				case 1296:
					if (smethod_6(int_12, ataskTempl_0.m_bSpecialLogic, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1296), mConvert.BS(ataskTempl_0.m_bSpecialLogic));
					}
					break;
				case 1297:
					if (smethod_6(int_12, ataskTempl_0.m_bPremFaction, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1297), mConvert.BS(ataskTempl_0.m_bPremFaction));
					}
					break;
				case 1299:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByFactionScore, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1299), mConvert.BS(ataskTempl_0.m_bShowByFactionScore));
					}
					break;
				case 1301:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByFactionMoney, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1301), mConvert.BS(ataskTempl_0.m_bShowByFactionMoney));
					}
					break;
				case 1303:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByFactionPersonScore, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1303), mConvert.BS(ataskTempl_0.m_bShowByFactionPersonScore));
					}
					break;
				case 1328:
					if (smethod_6(int_12, ataskTempl_0.m_bShowDeposit2, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1328), mConvert.BS(ataskTempl_0.m_bShowDeposit2));
					}
					break;
				case 1323:
					if (smethod_6(int_12, ataskTempl_0.m_bShowCoupleIntimacy, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1323), mConvert.BS(ataskTempl_0.m_bShowCoupleIntimacy));
					}
					break;
				case 1366:
					if (smethod_6(int_12, ataskTempl_0.m_bWarTaskAward, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1366), mConvert.BS(ataskTempl_0.m_bWarTaskAward));
					}
					break;
				case 1336:
					if (smethod_6(int_12, ataskTempl_0.m_bRecordFnshCnt, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1336), mConvert.BS(ataskTempl_0.m_bRecordFnshCnt));
					}
					break;
				case 1337:
					if (smethod_6(int_12, ataskTempl_0.m_bTeamHaveRecaller, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1337), mConvert.BS(ataskTempl_0.m_bTeamHaveRecaller));
					}
					break;
				case 1338:
					if (smethod_6(int_12, ataskTempl_0.m_bBindedRecaller, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1338), mConvert.BS(ataskTempl_0.m_bBindedRecaller));
					}
					break;
				case 1340:
					if (smethod_6(int_12, ataskTempl_0.m_bShowCamp, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1340), mConvert.BS(ataskTempl_0.m_bShowCamp));
					}
					break;
				case 1342:
					if (smethod_6(int_12, ataskTempl_0.m_bShowCampPower, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1342), mConvert.BS(ataskTempl_0.m_bShowCampPower));
					}
					break;
				case 1343:
					if (smethod_6(int_12, ataskTempl_0.m_bReturnCampPower, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1343), mConvert.BS(ataskTempl_0.m_bReturnCampPower));
					}
					break;
				case 1345:
					if (smethod_6(int_12, ataskTempl_0.m_bShowNeedFriendPoint, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1345), mConvert.BS(ataskTempl_0.m_bShowNeedFriendPoint));
					}
					break;
				case 1347:
					if (smethod_6(int_12, ataskTempl_0.m_bNextTimeFail, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1347), mConvert.BS(ataskTempl_0.m_bNextTimeFail));
					}
					break;
				case 1349:
					if (smethod_6(int_12, ataskTempl_0.m_bAvailFrequency, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1349), mConvert.BS(ataskTempl_0.m_bAvailFrequency));
					}
					break;
				case 1351:
					if (smethod_6(int_12, ataskTempl_0.m_bHistoryVarTask, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1351), mConvert.BS(ataskTempl_0.m_bHistoryVarTask));
					}
					break;
				case 1352:
					if (smethod_6(int_12, ataskTempl_0.m_bPropNeedComp, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1352), mConvert.BS(ataskTempl_0.m_bPropNeedComp));
					}
					break;
				case 1356:
					if (smethod_6(int_12, ataskTempl_0.m_bDeliverByUI, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1356), mConvert.BS(ataskTempl_0.m_bDeliverByUI));
					}
					break;
				case 1357:
					if (smethod_6(int_12, ataskTempl_0.m_bRankPre, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1357), mConvert.BS(ataskTempl_0.m_bRankPre));
					}
					break;
				case 1373:
					if (smethod_6(int_12, ataskTempl_0.m_bFinPersonNeedComp, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1373), mConvert.BS(ataskTempl_0.m_bFinPersonNeedComp));
					}
					break;
				case 1369:
					if (smethod_6(int_12, ataskTempl_0.m_bPremHistoryNeedComp, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1369), mConvert.BS(ataskTempl_0.m_bPremHistoryNeedComp));
					}
					break;
				case 1380:
					if (smethod_6(int_12, ataskTempl_0.m_bHideOtherPlayer, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1380), mConvert.BS(ataskTempl_0.m_bHideOtherPlayer));
					}
					break;
				case 1379:
					if (smethod_6(int_12, ataskTempl_0.m_bMultiNpcTalk, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1379), mConvert.BS(ataskTempl_0.m_bMultiNpcTalk));
					}
					break;
				case 1389:
					if (smethod_6(int_12, ataskTempl_0.m_bFinHistoryNeedComp, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1389), mConvert.BS(ataskTempl_0.m_bFinHistoryNeedComp));
					}
					break;
				case 1385:
					if (smethod_6(int_12, ataskTempl_0.m_bPremPersonNeedComp, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1385), mConvert.BS(ataskTempl_0.m_bPremPersonNeedComp));
					}
					break;
				case 1604:
					if (smethod_6(int_12, ataskTempl_0.m_bIsLibraryTask, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1604), mConvert.BS(ataskTempl_0.m_bIsLibraryTask));
					}
					break;
				case 1606:
					if (smethod_6(int_12, ataskTempl_0.m_bIsUniqueStorageTask, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1606), mConvert.BS(ataskTempl_0.m_bIsUniqueStorageTask));
					}
					break;
				case 1608:
					if (smethod_6(int_12, ataskTempl_0.m_bWriteSpecialLog, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1608), mConvert.BS(ataskTempl_0.m_bWriteSpecialLog));
					}
					break;
				case 1398:
					if (smethod_6(int_12, ataskTempl_0.m_bPropNeedComp_personal, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1398), mConvert.BS(ataskTempl_0.m_bPropNeedComp_personal));
					}
					break;
				case 1396:
					if (smethod_6(int_12, ataskTempl_0.m_bRecordDeliverTime, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1396), mConvert.BS(ataskTempl_0.m_bRecordDeliverTime));
					}
					break;
				case 8011:
					if (smethod_6(int_12, ataskTempl_0.m_bShowMethod, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(8011), mConvert.BS(ataskTempl_0.m_bShowMethod));
					}
					break;
				case 4358:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByExpNotFull, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4358), mConvert.BS(ataskTempl_0.m_bShowByExpNotFull));
					}
					break;
				case 4359:
					if (smethod_6(int_12, ataskTempl_0.m_bShowPackSizePremise, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4359), mConvert.BS(ataskTempl_0.m_bShowPackSizePremise));
					}
					break;
				case 4360:
					if (smethod_6(int_12, ataskTempl_0.m_bVaguePromptingMode, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4360), mConvert.BS(ataskTempl_0.m_bVaguePromptingMode));
					}
					break;
				case 4361:
					if (smethod_6(int_12, ataskTempl_0.m_bShowPropertyPremis, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4361), mConvert.BS(ataskTempl_0.m_bShowPropertyPremis));
					}
					break;
				case 4362:
					if (smethod_6(int_12, ataskTempl_0.m_bShowPanguEquipPremise, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4362), mConvert.BS(ataskTempl_0.m_bShowPanguEquipPremise));
					}
					break;
				case 4363:
					if (smethod_6(int_12, ataskTempl_0.m_bShowExploreIcon, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4363), mConvert.BS(ataskTempl_0.m_bShowExploreIcon));
					}
					break;
				case 4364:
					if (smethod_6(int_12, ataskTempl_0.m_bShowDailyActivityPremise, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4364), mConvert.BS(ataskTempl_0.m_bShowDailyActivityPremise));
					}
					break;
				case 4365:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByTradeTime, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4365), mConvert.BS(ataskTempl_0.m_bShowByTradeTime));
					}
					break;
				case 4370:
					if (smethod_6(int_12, ataskTempl_0.m_bShowAchievementSeriesId, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4370), mConvert.BS(ataskTempl_0.m_bShowAchievementSeriesId));
					}
					break;
				case 4371:
					if (smethod_6(int_12, ataskTempl_0.m_bRecordReset, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4371), mConvert.BS(ataskTempl_0.m_bRecordReset));
					}
					break;
				case 4372:
					if (smethod_6(int_12, ataskTempl_0.m_bPremCheckPanguLevel, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4372), mConvert.BS(ataskTempl_0.m_bPremCheckPanguLevel));
					}
					break;
				case 4374:
					if (smethod_6(int_12, ataskTempl_0.m_bCheckYuMoLevel, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4374), mConvert.BS(ataskTempl_0.m_bCheckYuMoLevel));
					}
					break;
				case 4375:
					if (smethod_6(int_12, ataskTempl_0.m_bCheckTradeTime, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4375), mConvert.BS(ataskTempl_0.m_bCheckTradeTime));
					}
					break;
				case 4376:
					if (smethod_6(int_12, ataskTempl_0.m_bCheckStorageSize, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4376), mConvert.BS(ataskTempl_0.m_bCheckStorageSize));
					}
					break;
				case 4377:
					if (smethod_6(int_12, ataskTempl_0.m_bCheckRealmExp, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4377), mConvert.BS(ataskTempl_0.m_bCheckRealmExp));
					}
					break;
				case 4378:
					if (smethod_6(int_12, ataskTempl_0.m_bCheckPanguEquip, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4378), mConvert.BS(ataskTempl_0.m_bCheckPanguEquip));
					}
					break;
				case 4383:
					if (smethod_6(int_12, ataskTempl_0.m_bCheckLieMoLevel, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4383), mConvert.BS(ataskTempl_0.m_bCheckLieMoLevel));
					}
					break;
				case 4384:
					if (smethod_6(int_12, ataskTempl_0.m_bCheckInventorySize, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4384), mConvert.BS(ataskTempl_0.m_bCheckInventorySize));
					}
					break;
				case 4386:
					if (smethod_6(int_12, ataskTempl_0.m_bFailIconStateID, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4386), mConvert.BS(ataskTempl_0.m_bFailIconStateID));
					}
					break;
				case 4387:
					if (smethod_6(int_12, ataskTempl_0.m_bAllowBatchAward, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4387), mConvert.BS(ataskTempl_0.m_bAllowBatchAward));
					}
					break;
				case 4388:
					if (smethod_6(int_12, ataskTempl_0.m_bDoNotShowGfx, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4388), mConvert.BS(ataskTempl_0.m_bDoNotShowGfx));
					}
					break;
				case 4390:
					if (smethod_6(int_12, ataskTempl_0.m_bMethodItemsRandOne, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4373), mConvert.BS(ataskTempl_0.m_bMethodItemsRandOne));
					}
					break;
				case 4391:
					if (smethod_6(int_12, ataskTempl_0.m_bCheckExp, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4391), mConvert.BS(ataskTempl_0.m_bCheckExp));
					}
					break;
				case 4397:
					if (smethod_6(int_12, ataskTempl_0.m_bShowByRealmExpNotFull, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4397), mConvert.BS(ataskTempl_0.m_bShowByRealmExpNotFull));
					}
					break;
				case 10995028:
				{
					for (int num12 = 0; num12 < ataskTempl_0.m_PremItems.Length; num12++)
					{
						if (smethod_6(int_12, ataskTempl_0.m_PremItems[num12].m_bCommonItem, flag))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1099, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5028), mConvert.BS(ataskTempl_0.m_PremItems[num12].m_bCommonItem));
						}
					}
					break;
				}
				case 8012:
					if (smethod_6(int_12, ataskTempl_0.m_bCrossServer, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(8012), mConvert.BS(ataskTempl_0.m_bCrossServer));
					}
					break;
				case 12405050:
				{
					for (int num11 = 0; num11 < ataskTempl_0.m_PlayerWanted.Length; num11++)
					{
						if (smethod_6(int_12, ataskTempl_0.m_PlayerWanted[num11].m_bDropCmnItem, flag))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5050), mConvert.BS(ataskTempl_0.m_PlayerWanted[num11].m_bDropCmnItem));
						}
					}
					break;
				}
				case 11025028:
				{
					for (int num10 = 0; num10 < ataskTempl_0.m_GivenItems.Length; num10++)
					{
						if (smethod_6(int_12, ataskTempl_0.m_GivenItems[num10].m_bCommonItem, flag))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1102, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5028), mConvert.BS(ataskTempl_0.m_GivenItems[num10].m_bCommonItem));
						}
					}
					break;
				}
				case 12415063:
				{
					for (int num9 = 0; num9 < ataskTempl_0.m_MonsterWanted.Length; num9++)
					{
						if (smethod_6(int_12, ataskTempl_0.m_MonsterWanted[num9].m_bKillerLev != 0, flag))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1241, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5063), mConvert.BS(ataskTempl_0.m_MonsterWanted[num9].m_bKillerLev != 0));
						}
					}
					break;
				}
				case 12415061:
				{
					for (int num8 = 0; num8 < ataskTempl_0.m_MonsterWanted.Length; num8++)
					{
						if (smethod_6(int_12, ataskTempl_0.m_MonsterWanted[num8].m_bDropCmnItem, flag))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1241, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5061), mConvert.BS(ataskTempl_0.m_MonsterWanted[num8].m_bDropCmnItem));
						}
					}
					break;
				}
				case 12405087:
				{
					for (int num7 = 0; num7 < ataskTempl_0.m_PlayerWanted.Length; num7++)
					{
						if (smethod_6(int_12, ataskTempl_0.m_PlayerWanted[num7].m_Requirements.ModelCheck, flag))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5087), mConvert.BS(ataskTempl_0.m_PlayerWanted[num7].m_Requirements.ModelCheck));
						}
					}
					break;
				}
				case 22415061:
				{
					for (int num6 = 0; num6 < ataskTempl_0.m_MonsterUnwanted.Length; num6++)
					{
						if (smethod_6(int_12, ataskTempl_0.m_MonsterUnwanted[num6].m_bDropCmnItem, flag))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(22410, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5061), mConvert.BS(ataskTempl_0.m_MonsterUnwanted[num6].m_bDropCmnItem));
						}
					}
					break;
				}
				case 12425028:
				{
					for (int num5 = 0; num5 < ataskTempl_0.m_ItemsWanted.Length; num5++)
					{
						if (smethod_6(int_12, ataskTempl_0.m_ItemsWanted[num5].m_bCommonItem, flag))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1242, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5028), mConvert.BS(ataskTempl_0.m_ItemsWanted[num5].m_bCommonItem));
						}
					}
					break;
				}
				case 60741025:
					if (smethod_6(int_12, ataskTempl_0.m_bDelvInZone, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6074, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1025), mConvert.BS(ataskTempl_0.m_bDelvInZone));
					}
					break;
				case 22415063:
				{
					for (int num4 = 0; num4 < ataskTempl_0.m_MonsterUnwanted.Length; num4++)
					{
						if (smethod_6(int_12, ataskTempl_0.m_MonsterUnwanted[num4].m_bKillerLev != 0, flag))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(22410, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5063), mConvert.BS(ataskTempl_0.m_MonsterUnwanted[num4].m_bKillerLev != 0));
						}
					}
					break;
				}
				case 60761029:
					if (smethod_6(int_12, ataskTempl_0.m_bLeaveRegionFail, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6075, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1029), mConvert.BS(ataskTempl_0.m_bLeaveRegionFail));
					}
					break;
				case 60751027:
					if (smethod_6(int_12, ataskTempl_0.m_bEnterRegionFail, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6075, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1027), mConvert.BS(ataskTempl_0.m_bEnterRegionFail));
					}
					break;
				case 61871444:
					if (smethod_6(int_12, ataskTempl_0.PropMonsterSummoned.m_bDeathDisappear, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1444), mConvert.BS(ataskTempl_0.PropMonsterSummoned.m_bDeathDisappear));
					}
					break;
				case 61871442:
					if (smethod_6(int_12, ataskTempl_0.PropMonsterSummoned.m_bRandChoose, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1442), mConvert.BS(ataskTempl_0.PropMonsterSummoned.m_bRandChoose));
					}
					break;
				case 60771032:
					if (smethod_6(int_12, ataskTempl_0.m_bTransTo, flag))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1032), mConvert.BS(ataskTempl_0.m_bTransTo));
					}
					break;
				}
			}
			break;
		}
		case 2:
		{
			double double_ = Convert.ToDouble(string_1);
			for (int num13 = 0; num13 < list_0.Count; num13++)
			{
				long num14 = list_0[num13];
				if (num14 <= 12745068L)
				{
					if (num14 <= 1607L)
					{
						if (num14 <= 1096L)
						{
							if (num14 <= 1037L)
							{
								switch (num14)
								{
								case 1005L:
									if (smethod_7(int_12, ataskTempl_0.m_ulTimeLimit, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1005), mConvert.SecondsToString(ataskTempl_0.m_ulTimeLimit));
									}
									break;
								case 1004L:
									if (smethod_7(int_12, ataskTempl_0.m_ulType, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1004), ataskTempl_0.m_ulType.ToString());
									}
									break;
								case 1000L:
									if (smethod_7(int_12, ataskTempl_0.m_ID, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1000), ataskTempl_0.m_ID.ToString());
									}
									break;
								case 1012L:
									if (smethod_7(int_12, ataskTempl_0.m_lPeriodLimit, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1012), mConvert.Int32ToString(ataskTempl_0.m_lPeriodLimit));
									}
									break;
								case 1011L:
									if (smethod_7(int_12, ataskTempl_0.m_lAvailFrequency, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1011), ataskTempl_0.m_lAvailFrequency.ToString());
									}
									break;
								case 1037L:
									if (smethod_7(int_12, ataskTempl_0.m_lMonsCtrl, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1037), ataskTempl_0.m_lMonsCtrl.ToString());
									}
									break;
								case 1024L:
									if (smethod_7(int_12, ataskTempl_0.m_ulMaxReceiver, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1024), mConvert.Int32ToString(ataskTempl_0.m_ulMaxReceiver));
									}
									break;
								}
							}
							else if (num14 <= 1063L)
							{
								if (num14 <= 1058L)
								{
									long num15 = num14 - 1045L;
									if ((ulong)num15 <= 4uL)
									{
										switch ((int)num15)
										{
										case 0:
											if (smethod_7(int_12, ataskTempl_0.m_ulSuitableLevel, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1045), ataskTempl_0.m_ulSuitableLevel.ToString());
											}
											continue;
										case 3:
											if (smethod_7(int_12, ataskTempl_0.m_ulDelvNPC, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1048), ataskTempl_0.m_ulDelvNPC.ToString());
											}
											continue;
										case 4:
											if (smethod_7(int_12, ataskTempl_0.m_ulAwardNPC, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1049), ataskTempl_0.m_ulAwardNPC.ToString());
											}
											continue;
										case 1:
										case 2:
											continue;
										}
									}
									if (num14 == 1058L && smethod_7(int_12, ataskTempl_0.m_iDeliveredSkillID, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1058), ataskTempl_0.m_iDeliveredSkillID.ToString());
									}
									continue;
								}
								switch (num14)
								{
								case 1063L:
									if (smethod_7(int_12, ataskTempl_0.m_ulInventorySlotNum, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1063), mConvert.Int32ToString(ataskTempl_0.m_ulInventorySlotNum));
									}
									break;
								case 1059L:
									if (smethod_7(int_12, ataskTempl_0.m_iDeliveredSkillLevel, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1059), ataskTempl_0.m_iDeliveredSkillLevel.ToString());
									}
									break;
								}
							}
							else if (num14 <= 1075L)
							{
								switch (num14)
								{
								case 1075L:
									if (smethod_7(int_12, ataskTempl_0.m_iPremiseFactionContrib, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1075), mConvert.Int32ToString(ataskTempl_0.m_iPremiseFactionContrib));
									}
									break;
								case 1073L:
									if (smethod_7(int_12, ataskTempl_0.m_iPremNeedRecordTasksNum, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1073), mConvert.Int32ToString(ataskTempl_0.m_iPremNeedRecordTasksNum));
									}
									break;
								}
							}
							else if (num14 != 1079L)
							{
								long num16 = num14 - 1084L;
								if ((ulong)num16 > 12uL)
								{
									continue;
								}
								switch ((int)num16)
								{
								case 0:
									if (smethod_7(int_12, (int)ataskTempl_0.m_ucPremiseTransformedForm, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1084), ataskTempl_0.m_ucPremiseTransformedForm.ToString());
									}
									break;
								case 2:
									if (smethod_7(int_12, ataskTempl_0.m_ulPremise_Lev_Min, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1086), ataskTempl_0.m_ulPremise_Lev_Min.ToString());
									}
									break;
								case 3:
									if (smethod_7(int_12, ataskTempl_0.m_ulPremise_Lev_Max, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1087), ataskTempl_0.m_ulPremise_Lev_Max.ToString());
									}
									break;
								case 7:
									if (smethod_7(int_12, ataskTempl_0.m_ulPremReincarnationMin, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1091), ataskTempl_0.m_ulPremReincarnationMin.ToString());
									}
									break;
								case 8:
									if (smethod_7(int_12, ataskTempl_0.m_ulPremReincarnationMax, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1092), ataskTempl_0.m_ulPremReincarnationMax.ToString());
									}
									break;
								case 11:
									if (smethod_7(int_12, ataskTempl_0.m_ulPremRealmLevelMin, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1095), ataskTempl_0.m_ulPremRealmLevelMin.ToString());
									}
									break;
								case 12:
									if (smethod_7(int_12, ataskTempl_0.m_ulPremRealmLevelMax, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1096), ataskTempl_0.m_ulPremRealmLevelMax.ToString());
									}
									break;
								}
							}
							else if (smethod_7(int_12, ataskTempl_0.m_ulAccountTaskLimitCnt, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1079), mConvert.Int32ToString(ataskTempl_0.m_ulAccountTaskLimitCnt));
							}
							continue;
						}
						if (num14 <= 1344L)
						{
							if (num14 <= 1290L)
							{
								long num17 = num14 - 1103L;
								if ((ulong)num17 <= 15uL)
								{
									switch ((int)num17)
									{
									case 0:
										if (smethod_7(int_12, ataskTempl_0.m_ulGivenCmnCount, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1103), ataskTempl_0.m_ulGivenCmnCount.ToString());
										}
										continue;
									case 1:
										if (smethod_7(int_12, ataskTempl_0.m_ulGivenTskCount, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1104), ataskTempl_0.m_ulGivenTskCount.ToString());
										}
										continue;
									case 2:
										if (smethod_7(int_12, ataskTempl_0.m_ulPremise_Deposit, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1105), mConvert.Int32ToString(ataskTempl_0.m_ulPremise_Deposit));
										}
										continue;
									case 4:
										if (smethod_7(int_12, ataskTempl_0.m_lPremise_Reputation, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1107), mConvert.Int32ToString(ataskTempl_0.m_lPremise_Reputation));
										}
										continue;
									case 5:
										if (smethod_7(int_12, ataskTempl_0.m_lPremise_RepuMax, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1108), mConvert.Int32ToString(ataskTempl_0.m_lPremise_RepuMax));
										}
										continue;
									case 9:
										if (smethod_7(int_12, ataskTempl_0.m_ulPremise_Task_Least_Num, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1112), ataskTempl_0.m_ulPremise_Task_Least_Num.ToString());
										}
										continue;
									case 10:
										if (smethod_7(int_12, ataskTempl_0.m_ulPremise_Period, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1113), ataskTempl_0.m_ulPremise_Period.ToString());
										}
										continue;
									case 13:
										if (smethod_7(int_12, ataskTempl_0.m_iPremise_FactionRole, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1116), ataskTempl_0.m_iPremise_FactionRole.ToString());
										}
										continue;
									case 15:
										if (smethod_7(int_12, ataskTempl_0.m_ulGender, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1118), ataskTempl_0.m_ulGender.ToString());
										}
										continue;
									case 3:
									case 6:
									case 7:
									case 8:
									case 11:
									case 12:
									case 14:
										continue;
									}
								}
								long num18 = num14 - 1148L;
								if ((ulong)num18 <= 31uL)
								{
									switch ((int)num18)
									{
									case 0:
										if (smethod_7(int_12, ataskTempl_0.m_ulPremRMBMin, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1148), mConvert.Int32ToSilver(ataskTempl_0.m_ulPremRMBMin));
										}
										continue;
									case 1:
										if (smethod_7(int_12, ataskTempl_0.m_ulPremRMBMax, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1149), mConvert.Int32ToSilver(ataskTempl_0.m_ulPremRMBMax));
										}
										continue;
									case 4:
										if (smethod_7(int_12, ataskTempl_0.m_iCharStartTime, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1152), ataskTempl_0.m_iCharStartTime.ToString());
										}
										continue;
									case 5:
										if (smethod_7(int_12, ataskTempl_0.m_iCharEndTime, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1153), ataskTempl_0.m_iCharEndTime.ToString());
										}
										continue;
									case 7:
										if (smethod_7(int_12, ataskTempl_0.m_ulCharTimeGreaterThan, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1155), ataskTempl_0.m_ulCharTimeGreaterThan.ToString());
										}
										continue;
									case 8:
										if (smethod_7(int_12, ataskTempl_0.m_ulPremise_Cotask, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1156), ataskTempl_0.m_ulPremise_Cotask.ToString());
										}
										continue;
									case 9:
										if (smethod_7(int_12, ataskTempl_0.m_ulCoTaskCond, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1157), ataskTempl_0.m_ulCoTaskCond.ToString());
										}
										continue;
									case 11:
										if (smethod_7(int_12, ataskTempl_0.m_lSkillLev[0], double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1159), ataskTempl_0.m_lSkillLev[0].ToString());
										}
										continue;
									case 12:
										if (smethod_7(int_12, ataskTempl_0.m_lSkillLev[1], double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1160), ataskTempl_0.m_lSkillLev[1].ToString());
										}
										continue;
									case 13:
										if (smethod_7(int_12, ataskTempl_0.m_lSkillLev[2], double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1161), ataskTempl_0.m_lSkillLev[2].ToString());
										}
										continue;
									case 14:
										if (smethod_7(int_12, ataskTempl_0.m_lSkillLev[3], double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1162), ataskTempl_0.m_lSkillLev[3].ToString());
										}
										continue;
									case 15:
										if (smethod_7(int_12, (int)ataskTempl_0.m_DynTaskType, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1163), ataskTempl_0.m_DynTaskType.ToString());
										}
										continue;
									case 16:
										if (smethod_7(int_12, ataskTempl_0.m_ulSpecialAward, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1164), ataskTempl_0.m_ulSpecialAward.ToString());
										}
										continue;
									case 22:
										if (smethod_7(int_12, ataskTempl_0.m_fTeammateDist, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1170), ataskTempl_0.m_fTeammateDist.ToString(Class16.smethod_0(1648964192)));
										}
										continue;
									case 26:
										if (smethod_7(int_12, ataskTempl_0.m_fSuccDist, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1174), ataskTempl_0.m_fSuccDist.ToString(Class16.smethod_0(1648964192)));
										}
										continue;
									case 29:
										if (smethod_7(int_12, ataskTempl_0.m_fRcvMemDist, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1177), ataskTempl_0.m_fRcvMemDist.ToString(Class16.smethod_0(1648964192)));
										}
										continue;
									case 31:
										if (smethod_7(int_12, ataskTempl_0.m_fCntMemDist, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1179), ataskTempl_0.m_fCntMemDist.ToString(Class16.smethod_0(1648964192)));
										}
										continue;
									case 2:
									case 3:
									case 6:
									case 10:
									case 17:
									case 18:
									case 19:
									case 20:
									case 21:
									case 23:
									case 24:
									case 25:
									case 27:
									case 28:
									case 30:
										continue;
									}
								}
								long num19 = num14 - 1186L;
								if ((ulong)num19 > 104uL)
								{
									continue;
								}
								switch ((int)num19)
								{
								case 0:
									if (smethod_7(int_12, ataskTempl_0.m_nPremExp1AndOrExp2, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1186), ataskTempl_0.m_nPremExp1AndOrExp2.ToString());
									}
									break;
								case 4:
									if (smethod_7(int_12, ataskTempl_0.m_iPremForce, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1190), ataskTempl_0.m_iPremForce.ToString());
									}
									break;
								case 6:
									if (smethod_7(int_12, ataskTempl_0.m_iPremForceReputation, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1192), mConvert.Int32ToString(ataskTempl_0.m_iPremForceReputation));
									}
									break;
								case 8:
									if (smethod_7(int_12, ataskTempl_0.m_iPremForceContribution, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1194), mConvert.Int32ToString(ataskTempl_0.m_iPremForceContribution));
									}
									break;
								case 10:
									if (smethod_7(int_12, ataskTempl_0.m_iPremForceExp, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1196), mConvert.Int32ToString(ataskTempl_0.m_iPremForceExp));
									}
									break;
								case 12:
									if (smethod_7(int_12, ataskTempl_0.m_iPremForceSP, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1198), mConvert.Int32ToString(ataskTempl_0.m_iPremForceSP));
									}
									break;
								case 14:
									if (smethod_7(int_12, ataskTempl_0.m_iPremForceActivityLevel, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1200), ataskTempl_0.m_iPremForceActivityLevel.ToString());
									}
									break;
								case 20:
									if (smethod_7(int_12, ataskTempl_0.m_iPremTitleNumRequired, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1206), mConvert.Int32ToString(ataskTempl_0.m_iPremTitleNumRequired));
									}
									break;
								case 23:
									if (smethod_7(int_12, ataskTempl_0.m_iPremHistoryStageIndex[0], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1209), ataskTempl_0.m_iPremHistoryStageIndex[0].ToString());
									}
									break;
								case 24:
									if (smethod_7(int_12, ataskTempl_0.m_iPremHistoryStageIndex[1], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1210), ataskTempl_0.m_iPremHistoryStageIndex[1].ToString());
									}
									break;
								case 26:
									if (smethod_7(int_12, ataskTempl_0.m_ulPremGeneralCardCount, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1212), mConvert.Int32ToString(ataskTempl_0.m_ulPremGeneralCardCount));
									}
									break;
								case 28:
									if (smethod_7(int_12, ataskTempl_0.m_iPremGeneralCardRank, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1214), ataskTempl_0.m_iPremGeneralCardRank.ToString());
									}
									break;
								case 29:
									if (smethod_7(int_12, ataskTempl_0.m_ulPremGeneralCardRankCount, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1215), mConvert.Int32ToString(ataskTempl_0.m_ulPremGeneralCardRankCount));
									}
									break;
								case 31:
									if (smethod_7(int_12, ataskTempl_0.m_ulPremIconStateID, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1217), ataskTempl_0.m_ulPremIconStateID.ToString());
									}
									break;
								case 33:
									if (smethod_7(int_12, ataskTempl_0.m_iVIPLevelMin, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1219), ataskTempl_0.m_iVIPLevelMin.ToString());
									}
									break;
								case 34:
									if (smethod_7(int_12, ataskTempl_0.m_iVIPLevelMax, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1220), ataskTempl_0.m_iVIPLevelMax.ToString());
									}
									break;
								case 36:
									if (smethod_7(int_12, ataskTempl_0.m_iPremHomeLevelMin, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1222), ataskTempl_0.m_iPremHomeLevelMin.ToString());
									}
									break;
								case 37:
									if (smethod_7(int_12, ataskTempl_0.m_iPremHomeLevelMax, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1223), ataskTempl_0.m_iPremHomeLevelMax.ToString());
									}
									break;
								case 40:
									if (smethod_7(int_12, ataskTempl_0.m_iPremHomeResourceLevelMin, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1226), ataskTempl_0.m_iPremHomeResourceLevelMin.ToString());
									}
									break;
								case 41:
									if (smethod_7(int_12, ataskTempl_0.m_iPremHomeResourceLevelMax, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1227), ataskTempl_0.m_iPremHomeResourceLevelMax.ToString());
									}
									break;
								case 43:
									if (smethod_7(int_12, ataskTempl_0.m_iPremHomeFactoryLevelType, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1229), ataskTempl_0.m_iPremHomeFactoryLevelType.ToString());
									}
									break;
								case 44:
									if (smethod_7(int_12, ataskTempl_0.m_iPremHomeFactoryLevelMin, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1230), ataskTempl_0.m_iPremHomeFactoryLevelMin.ToString());
									}
									break;
								case 45:
									if (smethod_7(int_12, ataskTempl_0.m_iPremHomeFactoryLevelMax, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1231), ataskTempl_0.m_iPremHomeFactoryLevelMax.ToString());
									}
									break;
								case 47:
									if (smethod_7(int_12, ataskTempl_0.m_iPremHomeFlourishMin, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1233), mConvert.Int32ToString(ataskTempl_0.m_iPremHomeFlourishMin));
									}
									break;
								case 48:
									if (smethod_7(int_12, ataskTempl_0.m_iPremHomeFlourishMax, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1234), mConvert.Int32ToString(ataskTempl_0.m_iPremHomeFlourishMax));
									}
									break;
								case 52:
									if (smethod_7(int_12, ataskTempl_0.m_enumMethod, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1238), ataskTempl_0.m_enumMethod.ToString());
									}
									break;
								case 53:
									if (smethod_7(int_12, ataskTempl_0.m_enumFinishType, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1239), ataskTempl_0.m_enumFinishType.ToString());
									}
									break;
								case 57:
									if (smethod_7(int_12, ataskTempl_0.m_ulGoldWanted, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1243), mConvert.Int32ToString(ataskTempl_0.m_ulGoldWanted));
									}
									break;
								case 58:
									if (smethod_7(int_12, ataskTempl_0.m_iFactionContribWanted, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1244), mConvert.Int32ToString(ataskTempl_0.m_iFactionContribWanted));
									}
									break;
								case 59:
									if (smethod_7(int_12, ataskTempl_0.m_iFactionExpContribWanted, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1245), mConvert.Int32ToString(ataskTempl_0.m_iFactionExpContribWanted));
									}
									break;
								case 60:
									if (smethod_7(int_12, ataskTempl_0.m_ulNPCToProtect, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1246), ataskTempl_0.m_ulNPCToProtect.ToString());
									}
									break;
								case 61:
									if (smethod_7(int_12, ataskTempl_0.m_ulProtectTimeLen, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1247), mConvert.SecondsToString(ataskTempl_0.m_ulProtectTimeLen));
									}
									break;
								case 62:
									if (smethod_7(int_12, ataskTempl_0.m_ulNPCMoving, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1248), ataskTempl_0.m_ulNPCMoving.ToString());
									}
									break;
								case 63:
									if (smethod_7(int_12, ataskTempl_0.m_ulNPCDestSite, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1249), ataskTempl_0.m_ulNPCDestSite.ToString());
									}
									break;
								case 65:
									if (smethod_7(int_12, ataskTempl_0.m_ulWaitTime, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1251), mConvert.SecondsToString(ataskTempl_0.m_ulWaitTime));
									}
									break;
								case 74:
									if (smethod_7(int_12, ataskTempl_0.m_nFinExp1AndOrExp2, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1260), ataskTempl_0.m_nFinExp1AndOrExp2.ToString());
									}
									break;
								case 79:
									if (smethod_7(int_12, (int)ataskTempl_0.m_ucTransformedForm, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1265), ataskTempl_0.m_ucTransformedForm.ToString());
									}
									break;
								case 80:
									if (smethod_7(int_12, ataskTempl_0.m_ulReachLevel, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1266), ataskTempl_0.m_ulReachLevel.ToString());
									}
									break;
								case 81:
									if (smethod_7(int_12, ataskTempl_0.m_ulReachReincarnationCount, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1267), ataskTempl_0.m_ulReachReincarnationCount.ToString());
									}
									break;
								case 82:
									if (smethod_7(int_12, ataskTempl_0.m_ulReachRealmLevel, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1268), ataskTempl_0.m_ulReachRealmLevel.ToString());
									}
									break;
								case 83:
									if (smethod_7(int_12, ataskTempl_0.m_uiEmotion, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1269), ataskTempl_0.m_uiEmotion.ToString());
									}
									break;
								case 84:
									if (smethod_7(int_12, ataskTempl_0.m_ulTMIconStateID, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1270), ataskTempl_0.m_ulTMIconStateID.ToString());
									}
									break;
								case 85:
									if (smethod_7(int_12, ataskTempl_0.m_ulTMHomeLevelType, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1271), ataskTempl_0.m_ulTMHomeLevelType.ToString());
									}
									break;
								case 86:
									if (smethod_7(int_12, ataskTempl_0.m_ulTMReachHomeLevel, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1272), ataskTempl_0.m_ulTMReachHomeLevel.ToString());
									}
									break;
								case 87:
									if (smethod_7(int_12, ataskTempl_0.m_ulTMReachHomeFlourish, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1273), mConvert.Int32ToString(ataskTempl_0.m_ulTMReachHomeFlourish));
									}
									break;
								case 89:
									if (smethod_7(int_12, ataskTempl_0.m_ulAwardType_S, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1275), ataskTempl_0.m_ulAwardType_S.ToString());
									}
									break;
								case 90:
									if (smethod_7(int_12, ataskTempl_0.m_ulAwardType_F, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1276), ataskTempl_0.m_ulAwardType_F.ToString());
									}
									break;
								case 95:
									if (smethod_7(int_12, ataskTempl_0.m_ulBindOnCarrierId, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1281), ataskTempl_0.m_ulBindOnCarrierId.ToString());
									}
									break;
								case 96:
									if (smethod_7(int_12, ataskTempl_0.m_ulTMReachArenaCount, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1282), mConvert.Int32ToString(ataskTempl_0.m_ulTMReachArenaCount));
									}
									break;
								case 97:
									if (smethod_7(int_12, ataskTempl_0.m_iPremArenaWinCount, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1283), mConvert.Int32ToString(ataskTempl_0.m_iPremArenaWinCount));
									}
									break;
								case 101:
									if (smethod_7(int_12, ataskTempl_0.m_ulTMReachArenaWinCount, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1287), mConvert.Int32ToString(ataskTempl_0.m_ulTMReachArenaWinCount));
									}
									break;
								case 103:
									if (smethod_7(int_12, ataskTempl_0.m_TaskEventType, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1289), ataskTempl_0.m_TaskEventType.ToString());
									}
									break;
								case 104:
									if (smethod_7(int_12, ataskTempl_0.m_usTaskEventTimeOrScore, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1290), mConvert.Int32ToString(ataskTempl_0.m_usTaskEventTimeOrScore));
									}
									break;
								}
								continue;
							}
							if (num14 <= 1334L)
							{
								if (num14 != 1295L)
								{
									long num20 = num14 - 1298L;
									if ((ulong)num20 > 36uL)
									{
										continue;
									}
									switch ((int)num20)
									{
									case 0:
										if (smethod_7(int_12, ataskTempl_0.m_iPremFactionScore, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1298), mConvert.Int32ToString(ataskTempl_0.m_iPremFactionScore));
										}
										break;
									case 2:
										if (smethod_7(int_12, ataskTempl_0.m_iPremFactionMoney, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1300), mConvert.Int32ToString(ataskTempl_0.m_iPremFactionMoney));
										}
										break;
									case 4:
										if (smethod_7(int_12, ataskTempl_0.m_iPremFactionPersonScore, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1302), mConvert.Int32ToString(ataskTempl_0.m_iPremFactionPersonScore));
										}
										break;
									case 6:
										if (smethod_7(int_12, ataskTempl_0.m_FactionPersonScore, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1304), mConvert.Int32ToString(ataskTempl_0.m_FactionPersonScore));
										}
										break;
									case 16:
										if (smethod_7(int_12, ataskTempl_0.m_iPremMentorMorality, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1314), mConvert.Int32ToString(ataskTempl_0.m_iPremMentorMorality));
										}
										break;
									case 18:
										if (smethod_7(int_12, ataskTempl_0.m_iPremMentorStudentValue, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1316), mConvert.Int32ToString(ataskTempl_0.m_iPremMentorStudentValue));
										}
										break;
									case 20:
										if (smethod_7(int_12, ataskTempl_0.m_usIDSpace, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1318), ataskTempl_0.m_usIDSpace.ToString());
										}
										break;
									case 21:
										if (smethod_7(int_12, ataskTempl_0.m_usPremise_Cotask_Space, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1319), ataskTempl_0.m_usPremise_Cotask_Space.ToString());
										}
										break;
									case 22:
										if (smethod_7(int_12, ataskTempl_0.m_ulGrowthTarget, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1320), ((uint)ataskTempl_0.m_ulGrowthTarget).ToString());
										}
										break;
									case 23:
										if (smethod_7(int_12, (int)ataskTempl_0.m_iTinyGameType, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1321), ataskTempl_0.m_iTinyGameType.ToString());
										}
										break;
									case 24:
										if (smethod_7(int_12, ataskTempl_0.m_iPremCoupleIntimacy, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1322), mConvert.Int32ToString(ataskTempl_0.m_iPremCoupleIntimacy));
										}
										break;
									case 26:
										if (smethod_7(int_12, ataskTempl_0.TransformedDescID, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1324), ataskTempl_0.TransformedDescID.ToString());
										}
										break;
									case 27:
										if (smethod_7(int_12, ataskTempl_0.TMIconStateDescID, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1325), ataskTempl_0.TMIconStateDescID.ToString());
										}
										break;
									case 29:
										if (smethod_7(int_12, ataskTempl_0.m_ulPremDeposit2, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1327), mConvert.Int32ToString(ataskTempl_0.m_ulPremDeposit2));
										}
										break;
									case 31:
										if (smethod_7(int_12, ataskTempl_0.m_ulGoldWanted2, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1329), mConvert.Int32ToString(ataskTempl_0.m_ulGoldWanted2));
										}
										break;
									case 32:
										if (smethod_7(int_12, ataskTempl_0.m_ulCrossServerId, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1330), ataskTempl_0.m_ulCrossServerId.ToString());
										}
										break;
									case 33:
										if (smethod_7(int_12, ataskTempl_0.m_ulIconStateIDForAwardVar, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1331), ataskTempl_0.m_ulIconStateIDForAwardVar.ToString());
										}
										break;
									case 34:
										if (smethod_7(int_12, ataskTempl_0.m_lGlobalKeyForAwardVar, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1332), ataskTempl_0.m_lGlobalKeyForAwardVar.ToString());
										}
										break;
									case 36:
										if (smethod_7(int_12, (int)ataskTempl_0.m_iNeededTasksLeastNum, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1334), ataskTempl_0.m_iNeededTasksLeastNum.ToString());
										}
										break;
									}
								}
								else if (smethod_7(int_12, ataskTempl_0.m_iFactionMember, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1295), ataskTempl_0.m_iFactionMember.ToString());
								}
								continue;
							}
							switch (num14)
							{
							case 1344L:
								if (smethod_7(int_12, ataskTempl_0.m_iNeedFriendPoint, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1344), mConvert.Int32ToString(ataskTempl_0.m_iNeedFriendPoint));
								}
								break;
							case 1341L:
								if (smethod_7(int_12, ataskTempl_0.m_iCampPower, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1341), mConvert.Int32ToString(ataskTempl_0.m_iCampPower));
								}
								break;
							}
							continue;
						}
						if (num14 <= 1374L)
						{
							if (num14 <= 1353L)
							{
								switch (num14)
								{
								case 1353L:
									if (smethod_7(int_12, ataskTempl_0.m_nPropExp1AndOrExp2, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1353), ataskTempl_0.m_nPropExp1AndOrExp2.ToString());
									}
									break;
								case 1346L:
									if (smethod_7(int_12, ataskTempl_0.m_iTriggerEvent, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1346), ataskTempl_0.m_iTriggerEvent.ToString());
									}
									break;
								}
								continue;
							}
							long num21 = num14 - 1358L;
							if ((ulong)num21 <= 12uL)
							{
								switch ((int)num21)
								{
								case 0:
									if (smethod_7(int_12, ataskTempl_0.m_iRankType, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1358), ataskTempl_0.m_iRankType.ToString());
									}
									continue;
								case 1:
									if (smethod_7(int_12, ataskTempl_0.m_iRankGradeMin, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1359), ataskTempl_0.m_iRankGradeMin.ToString());
									}
									continue;
								case 5:
									if (smethod_7(int_12, ataskTempl_0.m_iVerifyStateLayer, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1363), ataskTempl_0.m_iVerifyStateLayer.ToString());
									}
									continue;
								case 6:
									if (smethod_7(int_12, ataskTempl_0.m_ulVerifyStateLayerID, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1364), ataskTempl_0.m_ulVerifyStateLayerID.ToString());
									}
									continue;
								case 7:
									if (smethod_7(int_12, ataskTempl_0.m_iKeyWordIndex, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1365), ataskTempl_0.m_iKeyWordIndex.ToString());
									}
									continue;
								case 10:
									if (smethod_7(int_12, ataskTempl_0.m_lPersonKeyForAwardVar, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1368), ataskTempl_0.m_lPersonKeyForAwardVar.ToString());
									}
									continue;
								case 12:
									if (smethod_7(int_12, ataskTempl_0.m_nPremPersonExp1AndOrExp2, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1370), ataskTempl_0.m_nPremPersonExp1AndOrExp2.ToString());
									}
									continue;
								case 2:
								case 3:
								case 4:
								case 8:
								case 9:
								case 11:
									continue;
								}
							}
							if (num14 == 1374L && smethod_7(int_12, ataskTempl_0.m_nFinPersonExp1AndOrExp2, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1374), ataskTempl_0.m_nFinPersonExp1AndOrExp2.ToString());
							}
							continue;
						}
						if (num14 <= 1390L)
						{
							long num22 = num14 - 1381L;
							if ((ulong)num22 <= 5uL)
							{
								switch ((int)num22)
								{
								case 0:
									if (smethod_7(int_12, ataskTempl_0.m_iHideOtherPlayerTime, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1381), mConvert.SecondsToString(ataskTempl_0.m_iHideOtherPlayerTime));
									}
									continue;
								case 1:
									if (smethod_7(int_12, ataskTempl_0.m_iGfxType, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1382), ataskTempl_0.m_iGfxType.ToString());
									}
									continue;
								case 3:
									if (smethod_7(int_12, ataskTempl_0.m_lHistoryKeyForAwardVar, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1384), ataskTempl_0.m_lHistoryKeyForAwardVar.ToString());
									}
									continue;
								case 5:
									if (smethod_7(int_12, ataskTempl_0.m_nPremHistoryExp1AndOrExp2, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1386), ataskTempl_0.m_nPremHistoryExp1AndOrExp2.ToString());
									}
									continue;
								case 2:
								case 4:
									continue;
								}
							}
							if (num14 == 1390L && smethod_7(int_12, ataskTempl_0.m_nFinHistoryExp1AndOrExp2, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1390), ataskTempl_0.m_nFinHistoryExp1AndOrExp2.ToString());
							}
							continue;
						}
						long num23 = num14 - 1395L;
						if ((ulong)num23 <= 4uL)
						{
							switch ((int)num23)
							{
							case 0:
								if (smethod_7(int_12, ataskTempl_0.m_chatGroupId, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1395), ataskTempl_0.m_chatGroupId.ToString());
								}
								continue;
							case 2:
								if (smethod_7(int_12, ataskTempl_0.m_iGuessStringID, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1397), ataskTempl_0.m_iGuessStringID.ToString());
								}
								continue;
							case 4:
								if (smethod_7(int_12, ataskTempl_0.m_nPropExp1AndOrExp2_personal, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1399), ataskTempl_0.m_nPropExp1AndOrExp2_personal.ToString());
								}
								continue;
							case 1:
							case 3:
								continue;
							}
						}
						long num24 = num14 - 1600L;
						if ((ulong)num24 > 7uL)
						{
							continue;
						}
						switch ((int)num24)
						{
						case 0:
							if (smethod_7(int_12, ataskTempl_0.m_ulParent, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1600), ataskTempl_0.m_ulParent.ToString());
							}
							break;
						case 1:
							if (smethod_7(int_12, ataskTempl_0.m_ulPrevSibling, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1601), ataskTempl_0.m_ulPrevSibling.ToString());
							}
							break;
						case 2:
							if (smethod_7(int_12, ataskTempl_0.m_ulNextSibling, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1602), ataskTempl_0.m_ulNextSibling.ToString());
							}
							break;
						case 3:
							if (smethod_7(int_12, ataskTempl_0.m_ulFirstChild, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1603), ataskTempl_0.m_ulFirstChild.ToString());
							}
							break;
						case 5:
							if (smethod_7(int_12, ataskTempl_0.m_fLibraryTasksProbability, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1605), ataskTempl_0.m_fLibraryTasksProbability.ToString(GProD.ProbValueFormat));
							}
							break;
						case 7:
							if (smethod_7(int_12, ataskTempl_0.m_iWorldContribution, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1607), mConvert.Int32ToString(ataskTempl_0.m_iWorldContribution));
							}
							break;
						}
						continue;
					}
					if (num14 <= 11585101L)
					{
						if (num14 <= 10695021L)
						{
							if (num14 <= 8009L)
							{
								long num25 = num14 - 1800L;
								if ((ulong)num25 <= 13uL)
								{
									switch ((int)num25)
									{
									case 0:
										if (smethod_7(int_12, ataskTempl_0.SpecialParameters.FailWhenGetOffCarrier, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1800), ataskTempl_0.SpecialParameters.FailWhenGetOffCarrier.ToString());
										}
										continue;
									case 1:
										if (smethod_7(int_12, ataskTempl_0.SpecialParameters.TimeWhenRideCarrier, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1801), ataskTempl_0.SpecialParameters.TimeWhenRideCarrier.ToString());
										}
										continue;
									case 2:
										if (smethod_7(int_12, ataskTempl_0.SpecialParameters.UseItemTimes, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1802), mConvert.Int32ToString(ataskTempl_0.SpecialParameters.UseItemTimes));
										}
										continue;
									case 5:
										if (smethod_7(int_12, ataskTempl_0.SpecialParameters.CompleteTaskTimes, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1805), mConvert.Int32ToString(ataskTempl_0.SpecialParameters.CompleteTaskTimes));
										}
										continue;
									case 9:
										if (smethod_7(int_12, ataskTempl_0.SpecialParameters.Parameter9, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1809), ataskTempl_0.SpecialParameters.Parameter9.ToString());
										}
										continue;
									case 10:
										if (smethod_7(int_12, ataskTempl_0.SpecialParameters.GetOffCarrierID, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1810), ataskTempl_0.SpecialParameters.GetOffCarrierID.ToString());
										}
										continue;
									case 11:
										if (smethod_7(int_12, ataskTempl_0.SpecialParameters.RideCarrierID, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1811), ataskTempl_0.SpecialParameters.RideCarrierID.ToString());
										}
										continue;
									case 12:
										if (smethod_7(int_12, ataskTempl_0.SpecialParameters.need_story_book_collection, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1812), ataskTempl_0.SpecialParameters.need_story_book_collection.ToString());
										}
										continue;
									case 13:
										if (smethod_7(int_12, ataskTempl_0.SpecialParameters.story_book_collection_count, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1813), mConvert.Int32ToString(ataskTempl_0.SpecialParameters.story_book_collection_count));
										}
										continue;
									case 3:
									case 4:
									case 6:
									case 7:
									case 8:
										continue;
									}
								}
								long num26 = num14 - 4369L;
								if ((ulong)num26 <= 44uL)
								{
									switch ((int)num26)
									{
									case 0:
										if (smethod_7(int_12, ataskTempl_0.m_HintConfigId, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4369), ataskTempl_0.m_HintConfigId.ToString());
										}
										continue;
									case 11:
										if (smethod_7(int_12, (int)ataskTempl_0.m_cEffectiveGameServer, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4380), ataskTempl_0.m_cEffectiveGameServer.ToString());
										}
										continue;
									case 12:
										if (smethod_7(int_12, (int)ataskTempl_0.m_cPremInventorySizeMax, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4381), ataskTempl_0.m_cPremInventorySizeMax.ToString());
										}
										continue;
									case 13:
										if (smethod_7(int_12, (int)ataskTempl_0.m_cPremInventorySizeMin, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4382), ataskTempl_0.m_cPremInventorySizeMin.ToString());
										}
										continue;
									case 16:
										if (smethod_7(int_12, (int)ataskTempl_0.m_cPremStorageSizeMax, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4385), ataskTempl_0.m_cPremStorageSizeMax.ToString());
										}
										continue;
									case 20:
										if (smethod_7(int_12, (int)ataskTempl_0.m_cPremStorageSizeMin, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4389), ataskTempl_0.m_cPremStorageSizeMin.ToString());
										}
										continue;
									case 23:
										if (smethod_7(int_12, ataskTempl_0.m_iAchievementSeriesId, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4392), ataskTempl_0.m_iAchievementSeriesId.ToString());
										}
										continue;
									case 24:
										if (smethod_7(int_12, ataskTempl_0.m_iPanguEquipLevel, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4393), ataskTempl_0.m_iPanguEquipLevel.ToString());
										}
										continue;
									case 25:
										if (smethod_7(int_12, ataskTempl_0.m_iPanguEquipQuality, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4394), ataskTempl_0.m_iPanguEquipQuality.ToString());
										}
										continue;
									case 26:
										if (smethod_7(int_12, ataskTempl_0.m_iPanguEquipSlot, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4395), ataskTempl_0.m_iPanguEquipSlot.ToString());
										}
										continue;
									case 27:
										if (smethod_7(int_12, ataskTempl_0.m_iPanguEquipYear, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4396), ataskTempl_0.m_iPanguEquipYear.ToString());
										}
										continue;
									case 29:
										if (smethod_7(int_12, ataskTempl_0.m_iPremYuMoLevelMax, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4398), ataskTempl_0.m_iPremYuMoLevelMax.ToString());
										}
										continue;
									case 30:
										if (smethod_7(int_12, ataskTempl_0.m_iPremYuMoLevelMin, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4399), ataskTempl_0.m_iPremYuMoLevelMin.ToString());
										}
										continue;
									case 31:
										if (smethod_7(int_12, (int)ataskTempl_0.m_iSlotMachineType, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4400), ataskTempl_0.m_iSlotMachineType.ToString());
										}
										continue;
									case 32:
										if (smethod_7(int_12, ataskTempl_0.m_uSpecialMethodNpcServicesLeastLeastCount, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4401), ataskTempl_0.m_uSpecialMethodNpcServicesLeastLeastCount.ToString());
										}
										continue;
									case 33:
										if (smethod_7(int_12, ataskTempl_0.m_uSpecialMethodParm1, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4402), ataskTempl_0.m_uSpecialMethodParm1.ToString());
										}
										continue;
									case 34:
										if (smethod_7(int_12, ataskTempl_0.m_uSpecialMethodParm2, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4403), ataskTempl_0.m_uSpecialMethodParm2.ToString());
										}
										continue;
									case 35:
										if (smethod_7(int_12, ataskTempl_0.m_uSpecialMethodParm3, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4404), ataskTempl_0.m_uSpecialMethodParm3.ToString());
										}
										continue;
									case 36:
										if (smethod_7(int_12, ataskTempl_0.m_uSpecialMethodTargetTaskLeastCount, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4405), ataskTempl_0.m_uSpecialMethodTargetTaskLeastCount.ToString());
										}
										continue;
									case 37:
										if (smethod_7(int_12, ataskTempl_0.m_uSpecialMethodType, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4406), ataskTempl_0.m_uSpecialMethodType.ToString());
										}
										continue;
									case 38:
										if (smethod_7(int_12, ataskTempl_0.m_ulFailIconStateID, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4407), ataskTempl_0.m_ulFailIconStateID.ToString());
										}
										continue;
									case 39:
										if (smethod_7(int_12, ataskTempl_0.m_ulGivenDongluCmnCount, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4408), ataskTempl_0.m_ulGivenDongluCmnCount.ToString());
										}
										continue;
									case 40:
										if (smethod_7(int_12, ataskTempl_0.m_ulGivenRelicCount, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4409), ataskTempl_0.m_ulGivenRelicCount.ToString());
										}
										continue;
									case 41:
										if (smethod_7(int_12, ataskTempl_0.m_ulMonsterShapeID, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4410), ataskTempl_0.m_ulMonsterShapeID.ToString());
										}
										continue;
									case 42:
										if (smethod_7(int_12, ataskTempl_0.m_ulPremPanguLevelMax, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4411), ataskTempl_0.m_ulPremPanguLevelMax.ToString());
										}
										continue;
									case 43:
										if (smethod_7(int_12, ataskTempl_0.m_ulPremPanguLevelMin, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4412), ataskTempl_0.m_ulPremPanguLevelMin.ToString());
										}
										continue;
									case 44:
										if (smethod_7(int_12, ataskTempl_0.m_ulPremPanguLevelYear, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(4413), ataskTempl_0.m_ulPremPanguLevelYear.ToString());
										}
										continue;
									case 1:
									case 2:
									case 3:
									case 4:
									case 5:
									case 6:
									case 7:
									case 8:
									case 9:
									case 10:
									case 14:
									case 15:
									case 17:
									case 18:
									case 19:
									case 21:
									case 22:
									case 28:
										continue;
									}
								}
								if (num14 == 8009L && smethod_7(int_12, ataskTempl_0.m_lFrequencyNum, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(8009), mConvert.Int32ToString(ataskTempl_0.m_lFrequencyNum));
								}
								continue;
							}
							if (num14 <= 10085005L)
							{
								long num27 = num14 - 5648891L;
								if ((ulong)num27 <= 16uL)
								{
									switch ((int)num27)
									{
									case 0:
										if (smethod_7(int_12, ataskTempl_0.camera_pos_x, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, Class16.smethod_0(1649264260), ataskTempl_0.camera_pos_x.ToString());
										}
										continue;
									case 1:
										if (smethod_7(int_12, ataskTempl_0.camera_pos_y, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, Class16.smethod_0(1649264285), ataskTempl_0.camera_pos_y.ToString());
										}
										continue;
									case 2:
										if (smethod_7(int_12, ataskTempl_0.camera_pos_z, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, Class16.smethod_0(1649264310), ataskTempl_0.camera_pos_z.ToString());
										}
										continue;
									case 3:
										if (smethod_7(int_12, ataskTempl_0.camera_quat_x, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, Class16.smethod_0(1649264335), ataskTempl_0.camera_quat_x.ToString());
										}
										continue;
									case 4:
										if (smethod_7(int_12, ataskTempl_0.camera_quat_y, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, Class16.smethod_0(1649264353), ataskTempl_0.camera_quat_y.ToString());
										}
										continue;
									case 5:
										if (smethod_7(int_12, ataskTempl_0.camera_quat_z, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, Class16.smethod_0(1649264379), ataskTempl_0.camera_quat_z.ToString());
										}
										continue;
									case 6:
										if (smethod_7(int_12, ataskTempl_0.camera_quat_a, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, Class16.smethod_0(1649264413), ataskTempl_0.camera_quat_a.ToString());
										}
										continue;
									case 7:
										if (smethod_7(int_12, ataskTempl_0.camera_target_pos_x, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, Class16.smethod_0(1649264439), ataskTempl_0.camera_target_pos_x.ToString());
										}
										continue;
									case 8:
										if (smethod_7(int_12, ataskTempl_0.camera_target_pos_y, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, Class16.smethod_0(1649264457), ataskTempl_0.camera_target_pos_y.ToString());
										}
										continue;
									case 9:
										if (smethod_7(int_12, ataskTempl_0.camera_target_pos_z, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, Class16.smethod_0(1649264483), ataskTempl_0.camera_target_pos_z.ToString());
										}
										continue;
									case 10:
										if (smethod_7(int_12, ataskTempl_0.camera_target_quat_x, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, Class16.smethod_0(1649264517), ataskTempl_0.camera_target_quat_x.ToString());
										}
										continue;
									case 11:
										if (smethod_7(int_12, ataskTempl_0.camera_target_quat_y, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, Class16.smethod_0(1649264536), ataskTempl_0.camera_target_quat_y.ToString());
										}
										continue;
									case 12:
										if (smethod_7(int_12, ataskTempl_0.camera_target_quat_z, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, Class16.smethod_0(1649264563), ataskTempl_0.camera_target_quat_z.ToString());
										}
										continue;
									case 13:
										if (smethod_7(int_12, ataskTempl_0.camera_target_quat_a, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, Class16.smethod_0(1649264598), ataskTempl_0.camera_target_quat_a.ToString());
										}
										continue;
									case 14:
										if (smethod_7(int_12, ataskTempl_0.camera_rotate_angle, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, Class16.smethod_0(1649264617), ataskTempl_0.camera_rotate_angle.ToString());
										}
										continue;
									case 15:
										if (smethod_7(int_12, ataskTempl_0.camera_take_seconds, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, Class16.smethod_0(1649263619), ataskTempl_0.camera_take_seconds.ToString());
										}
										continue;
									case 16:
										if (smethod_7(int_12, ataskTempl_0.camera_rotate_axis, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, Class16.smethod_0(1649263653), ataskTempl_0.camera_rotate_axis.ToString());
										}
										continue;
									}
								}
								long num28 = num14 - 10085000L;
								if ((ulong)num28 > 5uL)
								{
									continue;
								}
								switch ((int)num28)
								{
								case 0:
									if (smethod_7(int_12, ataskTempl_0.m_tmAbsFailTime.year, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1008, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5000), ataskTempl_0.m_tmAbsFailTime.year.ToString());
									}
									break;
								case 1:
									if (smethod_7(int_12, ataskTempl_0.m_tmAbsFailTime.month, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1008, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5001), ataskTempl_0.m_tmAbsFailTime.month.ToString());
									}
									break;
								case 2:
									if (smethod_7(int_12, ataskTempl_0.m_tmAbsFailTime.day, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1008, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5002), ataskTempl_0.m_tmAbsFailTime.day.ToString());
									}
									break;
								case 3:
									if (smethod_7(int_12, ataskTempl_0.m_tmAbsFailTime.hour, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1008, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5003), ataskTempl_0.m_tmAbsFailTime.hour.ToString());
									}
									break;
								case 4:
									if (smethod_7(int_12, ataskTempl_0.m_tmAbsFailTime.min, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1008, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5004), ataskTempl_0.m_tmAbsFailTime.min.ToString());
									}
									break;
								case 5:
									if (smethod_7(int_12, ataskTempl_0.m_tmAbsFailTime.wday, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1008, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5005), ataskTempl_0.m_tmAbsFailTime.wday.ToString());
									}
									break;
								}
								continue;
							}
							long num29 = num14 - 10545017L;
							if ((ulong)num29 <= 2uL)
							{
								switch ((int)num29)
								{
								case 0:
								{
									for (int num31 = 0; num31 < ataskTempl_0.m_plChangeKey.Length; num31++)
									{
										if (smethod_7(int_12, ataskTempl_0.m_plChangeKey[num31], double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1054, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5017), ataskTempl_0.m_plChangeKey[num31].ToString());
										}
									}
									continue;
								}
								case 1:
								{
									for (int num32 = 0; num32 < ataskTempl_0.m_plChangeKeyValue.Length; num32++)
									{
										if (smethod_7(int_12, ataskTempl_0.m_plChangeKeyValue[num32], double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1054, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5018), ataskTempl_0.m_plChangeKeyValue[num32].ToString());
										}
									}
									continue;
								}
								case 2:
								{
									for (int num30 = 0; num30 < ataskTempl_0.m_pbChangeType.Length; num30++)
									{
										if (smethod_7(int_12, Convert.ToInt32(ataskTempl_0.m_pbChangeType[num30]), double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1054, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5019), Convert.ToInt32(ataskTempl_0.m_pbChangeType[num30]).ToString());
										}
									}
									continue;
								}
								}
							}
							if (num14 != 10695021L)
							{
								continue;
							}
							for (int num33 = 0; num33 < ataskTempl_0.m_pPQExpArr.Length; num33++)
							{
								for (int num34 = 0; num34 < 64; num34++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pPQExpArr[num33][num34].type, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1069, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5021) + (num34 + 1), ataskTempl_0.m_pPQExpArr[num33][num34].type.ToString());
									}
								}
							}
							continue;
						}
						if (num14 <= 11025031L)
						{
							if (num14 <= 10725026L)
							{
								if (num14 != 10695022L)
								{
									long num35 = num14 - 10725023L;
									if ((ulong)num35 > 3uL)
									{
										continue;
									}
									switch ((int)num35)
									{
									case 0:
									{
										for (int num39 = 0; num39 < ataskTempl_0.m_MonstersContrib.Length; num39++)
										{
											if (smethod_7(int_12, ataskTempl_0.m_MonstersContrib[num39].m_ulMonsterTemplId, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1072, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5023), ataskTempl_0.m_MonstersContrib[num39].m_ulMonsterTemplId.ToString());
											}
										}
										break;
									}
									case 1:
									{
										for (int num37 = 0; num37 < ataskTempl_0.m_MonstersContrib.Length; num37++)
										{
											if (smethod_7(int_12, ataskTempl_0.m_MonstersContrib[num37].m_iWholeContrib, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1072, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5024), mConvert.Int32ToString(ataskTempl_0.m_MonstersContrib[num37].m_iWholeContrib));
											}
										}
										break;
									}
									case 2:
									{
										for (int num38 = 0; num38 < ataskTempl_0.m_MonstersContrib.Length; num38++)
										{
											if (smethod_7(int_12, ataskTempl_0.m_MonstersContrib[num38].m_iShareContrib, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1072, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5025), mConvert.Int32ToString(ataskTempl_0.m_MonstersContrib[num38].m_iShareContrib));
											}
										}
										break;
									}
									case 3:
									{
										for (int num36 = 0; num36 < ataskTempl_0.m_MonstersContrib.Length; num36++)
										{
											if (smethod_7(int_12, ataskTempl_0.m_MonstersContrib[num36].m_iPersonalWholeContrib, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1072, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5026), mConvert.Int32ToString(ataskTempl_0.m_MonstersContrib[num36].m_iPersonalWholeContrib));
											}
										}
										break;
									}
									}
									continue;
								}
								for (int num40 = 0; num40 < ataskTempl_0.m_pPQExpArr.Length; num40++)
								{
									for (int num41 = 0; num41 < 64; num41++)
									{
										if (smethod_7(int_12, ataskTempl_0.m_pPQExpArr[num40][num41].value, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1069, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5022) + (num41 + 1), ataskTempl_0.m_pPQExpArr[num40][num41].value.ToString());
										}
									}
								}
								continue;
							}
							long num42 = num14 - 10995027L;
							if ((ulong)num42 <= 4uL)
							{
								switch ((int)num42)
								{
								case 0:
								{
									for (int num46 = 0; num46 < ataskTempl_0.m_PremItems.Length; num46++)
									{
										if (smethod_7(int_12, ataskTempl_0.m_PremItems[num46].m_ulItemTemplId, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1099, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5027), ataskTempl_0.m_PremItems[num46].m_ulItemTemplId.ToString());
										}
									}
									continue;
								}
								case 2:
								{
									for (int num44 = 0; num44 < ataskTempl_0.m_PremItems.Length; num44++)
									{
										if (smethod_7(int_12, ataskTempl_0.m_PremItems[num44].m_ulItemNum, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1099, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5029), mConvert.Int32ToString(ataskTempl_0.m_PremItems[num44].m_ulItemNum));
										}
									}
									continue;
								}
								case 3:
								{
									for (int num45 = 0; num45 < ataskTempl_0.m_PremItems.Length; num45++)
									{
										if (smethod_7(int_12, ataskTempl_0.m_PremItems[num45].m_fProb, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1099, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5030), ataskTempl_0.m_PremItems[num45].m_fProb.ToString(GProD.ProbValueFormat));
										}
									}
									continue;
								}
								case 4:
								{
									for (int num43 = 0; num43 < ataskTempl_0.m_PremItems.Length; num43++)
									{
										if (smethod_7(int_12, (uint)ataskTempl_0.m_PremItems[num43].m_lPeriod, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1099, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5031), mConvert.SecondsToString(ataskTempl_0.m_PremItems[num43].m_lPeriod));
										}
									}
									continue;
								}
								case 1:
									continue;
								}
							}
							long num47 = num14 - 11025027L;
							if ((ulong)num47 > 4uL)
							{
								continue;
							}
							switch ((int)num47)
							{
							case 0:
							{
								for (int num51 = 0; num51 < ataskTempl_0.m_GivenItems.Length; num51++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_GivenItems[num51].m_ulItemTemplId, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1102, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5027), ataskTempl_0.m_GivenItems[num51].m_ulItemTemplId.ToString());
									}
								}
								break;
							}
							case 2:
							{
								for (int num49 = 0; num49 < ataskTempl_0.m_GivenItems.Length; num49++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_GivenItems[num49].m_ulItemNum, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1102, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5029), mConvert.Int32ToString(ataskTempl_0.m_GivenItems[num49].m_ulItemNum));
									}
								}
								break;
							}
							case 3:
							{
								for (int num50 = 0; num50 < ataskTempl_0.m_GivenItems.Length; num50++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_GivenItems[num50].m_fProb, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1102, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5030), ataskTempl_0.m_GivenItems[num50].m_fProb.ToString(GProD.ProbValueFormat));
									}
								}
								break;
							}
							case 4:
							{
								for (int num48 = 0; num48 < ataskTempl_0.m_GivenItems.Length; num48++)
								{
									if (smethod_7(int_12, (uint)ataskTempl_0.m_GivenItems[num48].m_lPeriod, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1102, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5031), mConvert.SecondsToString(ataskTempl_0.m_GivenItems[num48].m_lPeriod, 1));
									}
								}
								break;
							}
							}
							continue;
						}
						if (num14 <= 11105102L)
						{
							switch (num14)
							{
							case 11105102L:
							{
								for (int num53 = 0; num53 < ataskTempl_0.m_ulPremise_Tasks.Length; num53++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_ulPremise_Tasks[num53], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1110, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5102), ataskTempl_0.m_ulPremise_Tasks[num53].ToString());
									}
								}
								break;
							}
							case 11105101L:
							{
								for (int num52 = 0; num52 < ataskTempl_0.m_usPremise_Tasks_Space.Length; num52++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_usPremise_Tasks_Space[num52], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1110, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5101), ataskTempl_0.m_usPremise_Tasks_Space[num52].ToString());
									}
								}
								break;
							}
							}
							continue;
						}
						long num54 = num14 - 11545000L;
						if ((ulong)num54 <= 5uL)
						{
							switch ((int)num54)
							{
							case 0:
								if (smethod_7(int_12, ataskTempl_0.m_tmCharEndTime.year, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1154, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5000), ataskTempl_0.m_tmCharEndTime.year.ToString());
								}
								continue;
							case 1:
								if (smethod_7(int_12, ataskTempl_0.m_tmCharEndTime.month, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1154, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5001), ataskTempl_0.m_tmCharEndTime.month.ToString());
								}
								continue;
							case 2:
								if (smethod_7(int_12, ataskTempl_0.m_tmCharEndTime.day, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1154, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5002), ataskTempl_0.m_tmCharEndTime.day.ToString());
								}
								continue;
							case 3:
								if (smethod_7(int_12, ataskTempl_0.m_tmCharEndTime.hour, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1154, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5003), ataskTempl_0.m_tmCharEndTime.hour.ToString());
								}
								continue;
							case 4:
								if (smethod_7(int_12, ataskTempl_0.m_tmCharEndTime.min, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1154, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5004), ataskTempl_0.m_tmCharEndTime.min.ToString());
								}
								continue;
							case 5:
								if (smethod_7(int_12, ataskTempl_0.m_tmCharEndTime.wday, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1154, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5005), ataskTempl_0.m_tmCharEndTime.wday.ToString());
								}
								continue;
							}
						}
						if (num14 != 11585101L)
						{
							continue;
						}
						for (int num55 = 0; num55 < ataskTempl_0.m_usMutexTasksSpace.Length; num55++)
						{
							if (smethod_7(int_12, ataskTempl_0.m_usMutexTasksSpace[num55], double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1158, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5101), ataskTempl_0.m_usMutexTasksSpace[num55].ToString());
							}
						}
						continue;
					}
					if (num14 <= 12405056L)
					{
						if (num14 <= 11835103L)
						{
							if (num14 != 11585102L)
							{
								long num56 = num14 - 11835032L;
								if ((ulong)num56 <= 8uL)
								{
									switch ((int)num56)
									{
									case 0:
									{
										for (int num58 = 0; num58 < ataskTempl_0.m_TeamMemsWanted.Length; num58++)
										{
											if (smethod_7(int_12, ataskTempl_0.m_TeamMemsWanted[num58].m_ulLevelMin, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1183, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5032), ataskTempl_0.m_TeamMemsWanted[num58].m_ulLevelMin.ToString());
											}
										}
										continue;
									}
									case 1:
									{
										for (int num62 = 0; num62 < ataskTempl_0.m_TeamMemsWanted.Length; num62++)
										{
											if (smethod_7(int_12, ataskTempl_0.m_TeamMemsWanted[num62].m_ulLevelMax, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1183, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5033), ataskTempl_0.m_TeamMemsWanted[num62].m_ulLevelMax.ToString());
											}
										}
										continue;
									}
									case 2:
									{
										for (int num64 = 0; num64 < ataskTempl_0.m_TeamMemsWanted.Length; num64++)
										{
											if (smethod_7(int_12, ataskTempl_0.m_TeamMemsWanted[num64].m_ulRace, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1183, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5034), ataskTempl_0.m_TeamMemsWanted[num64].m_ulRace.ToString());
											}
										}
										continue;
									}
									case 3:
									{
										for (int num60 = 0; num60 < ataskTempl_0.m_TeamMemsWanted.Length; num60++)
										{
											if (smethod_7(int_12, ataskTempl_0.m_TeamMemsWanted[num60].m_ulOccupation, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1183, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5035), ataskTempl_0.m_TeamMemsWanted[num60].m_ulOccupation.ToString());
											}
										}
										continue;
									}
									case 4:
									{
										for (int num65 = 0; num65 < ataskTempl_0.m_TeamMemsWanted.Length; num65++)
										{
											if (smethod_7(int_12, ataskTempl_0.m_TeamMemsWanted[num65].m_ulGender, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1183, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5036), ataskTempl_0.m_TeamMemsWanted[num65].m_ulGender.ToString());
											}
										}
										continue;
									}
									case 5:
									{
										for (int num63 = 0; num63 < ataskTempl_0.m_TeamMemsWanted.Length; num63++)
										{
											if (smethod_7(int_12, ataskTempl_0.m_TeamMemsWanted[num63].m_ulMinCount, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1183, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5037), ataskTempl_0.m_TeamMemsWanted[num63].m_ulMinCount.ToString());
											}
										}
										continue;
									}
									case 6:
									{
										for (int num61 = 0; num61 < ataskTempl_0.m_TeamMemsWanted.Length; num61++)
										{
											if (smethod_7(int_12, ataskTempl_0.m_TeamMemsWanted[num61].m_ulMaxCount, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1183, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5038), ataskTempl_0.m_TeamMemsWanted[num61].m_ulMaxCount.ToString());
											}
										}
										continue;
									}
									case 7:
									{
										for (int num59 = 0; num59 < ataskTempl_0.m_TeamMemsWanted.Length; num59++)
										{
											if (smethod_7(int_12, ataskTempl_0.m_TeamMemsWanted[num59].m_ulTask, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1183, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5039), ataskTempl_0.m_TeamMemsWanted[num59].m_ulTask.ToString());
											}
										}
										continue;
									}
									case 8:
									{
										for (int num57 = 0; num57 < ataskTempl_0.m_TeamMemsWanted.Length; num57++)
										{
											if (smethod_7(int_12, ataskTempl_0.m_TeamMemsWanted[num57].m_iForce, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1183, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5040), ataskTempl_0.m_TeamMemsWanted[num57].m_iForce.ToString());
											}
										}
										continue;
									}
									}
								}
								if (num14 != 11835103L)
								{
									continue;
								}
								for (int num66 = 0; num66 < ataskTempl_0.m_TeamMemsWanted.Length; num66++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_TeamMemsWanted[num66].TeamMemTaskSpace, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1183, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5103), ataskTempl_0.m_TeamMemsWanted[num66].TeamMemTaskSpace.ToString());
									}
								}
								continue;
							}
							for (int num67 = 0; num67 < ataskTempl_0.m_ulMutexTasks.Length; num67++)
							{
								if (smethod_7(int_12, ataskTempl_0.m_ulMutexTasks[num67], double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1158, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5102), ataskTempl_0.m_ulMutexTasks[num67].ToString());
								}
							}
							continue;
						}
						if (num14 <= 11885045L)
						{
							long num68 = num14 - 11875041L;
							if ((ulong)num68 <= 4uL)
							{
								switch ((int)num68)
								{
								case 0:
									if (smethod_7(int_12, ataskTempl_0.m_Prem1KeyValue.nLeftType, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041), ataskTempl_0.m_Prem1KeyValue.nLeftType.ToString());
									}
									continue;
								case 1:
									if (smethod_7(int_12, ataskTempl_0.m_Prem1KeyValue.lLeftNum, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042), ataskTempl_0.m_Prem1KeyValue.lLeftNum.ToString());
									}
									continue;
								case 2:
									if (smethod_7(int_12, ataskTempl_0.m_Prem1KeyValue.nCompOper, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043), ataskTempl_0.m_Prem1KeyValue.nCompOper.ToString());
									}
									continue;
								case 3:
									if (smethod_7(int_12, ataskTempl_0.m_Prem1KeyValue.nRightType, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044), ataskTempl_0.m_Prem1KeyValue.nRightType.ToString());
									}
									continue;
								case 4:
									if (smethod_7(int_12, ataskTempl_0.m_Prem1KeyValue.lRightNum, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045), ataskTempl_0.m_Prem1KeyValue.lRightNum.ToString());
									}
									continue;
								}
							}
							long num69 = num14 - 11885041L;
							if ((ulong)num69 > 4uL)
							{
								continue;
							}
							switch ((int)num69)
							{
							case 0:
								if (smethod_7(int_12, ataskTempl_0.m_Prem2KeyValue.nLeftType, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1188, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041), ataskTempl_0.m_Prem2KeyValue.nLeftType.ToString());
								}
								break;
							case 1:
								if (smethod_7(int_12, ataskTempl_0.m_Prem2KeyValue.lLeftNum, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1188, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042), ataskTempl_0.m_Prem2KeyValue.lLeftNum.ToString());
								}
								break;
							case 2:
								if (smethod_7(int_12, ataskTempl_0.m_Prem2KeyValue.nCompOper, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1188, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043), ataskTempl_0.m_Prem2KeyValue.nCompOper.ToString());
								}
								break;
							case 3:
								if (smethod_7(int_12, ataskTempl_0.m_Prem2KeyValue.nRightType, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1188, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044), ataskTempl_0.m_Prem2KeyValue.nRightType.ToString());
								}
								break;
							case 4:
								if (smethod_7(int_12, ataskTempl_0.m_Prem2KeyValue.lRightNum, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1188, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045), ataskTempl_0.m_Prem2KeyValue.lRightNum.ToString());
								}
								break;
							}
							continue;
						}
						if (num14 != 12075046L)
						{
							long num70 = num14 - 12405047L;
							if ((ulong)num70 > 9uL)
							{
								continue;
							}
							switch ((int)num70)
							{
							case 0:
							{
								for (int num72 = 0; num72 < ataskTempl_0.m_PlayerWanted.Length; num72++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_PlayerWanted[num72].m_ulPlayerNum, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5047), mConvert.Int32ToString(ataskTempl_0.m_PlayerWanted[num72].m_ulPlayerNum));
									}
								}
								break;
							}
							case 1:
							{
								for (int num76 = 0; num76 < ataskTempl_0.m_PlayerWanted.Length; num76++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_PlayerWanted[num76].m_ulDropItemId, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5048), ataskTempl_0.m_PlayerWanted[num76].m_ulDropItemId.ToString());
									}
								}
								break;
							}
							case 2:
							{
								for (int num78 = 0; num78 < ataskTempl_0.m_PlayerWanted.Length; num78++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_PlayerWanted[num78].m_ulDropItemCount, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5049), mConvert.Int32ToString(ataskTempl_0.m_PlayerWanted[num78].m_ulDropItemCount));
									}
								}
								break;
							}
							case 4:
							{
								for (int num74 = 0; num74 < ataskTempl_0.m_PlayerWanted.Length; num74++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_PlayerWanted[num74].m_fDropProb, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5051), ataskTempl_0.m_PlayerWanted[num74].m_fDropProb.ToString(GProD.ProbValueFormat));
									}
								}
								break;
							}
							case 5:
							{
								for (int num79 = 0; num79 < ataskTempl_0.m_PlayerWanted.Length; num79++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_PlayerWanted[num79].m_Requirements.m_ulOccupations, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5052), ataskTempl_0.m_PlayerWanted[num79].m_Requirements.m_ulOccupations.ToString());
									}
								}
								break;
							}
							case 6:
							{
								for (int num77 = 0; num77 < ataskTempl_0.m_PlayerWanted.Length; num77++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_PlayerWanted[num77].m_Requirements.m_iMinLevel, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5053), ataskTempl_0.m_PlayerWanted[num77].m_Requirements.m_iMinLevel.ToString());
									}
								}
								break;
							}
							case 7:
							{
								for (int num75 = 0; num75 < ataskTempl_0.m_PlayerWanted.Length; num75++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_PlayerWanted[num75].m_Requirements.m_iMaxLevel, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5054), ataskTempl_0.m_PlayerWanted[num75].m_Requirements.m_iMaxLevel.ToString());
									}
								}
								break;
							}
							case 8:
							{
								for (int num73 = 0; num73 < ataskTempl_0.m_PlayerWanted.Length; num73++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_PlayerWanted[num73].m_Requirements.m_iGender, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5055), ataskTempl_0.m_PlayerWanted[num73].m_Requirements.m_iGender.ToString());
									}
								}
								break;
							}
							case 9:
							{
								for (int num71 = 0; num71 < ataskTempl_0.m_PlayerWanted.Length; num71++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_PlayerWanted[num71].m_Requirements.m_iForce, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5056), ataskTempl_0.m_PlayerWanted[num71].m_Requirements.m_iForce.ToString());
									}
								}
								break;
							}
							}
							continue;
						}
						for (int num80 = 0; num80 < ataskTempl_0.m_PremTitles.Length; num80++)
						{
							if (smethod_7(int_12, ataskTempl_0.m_PremTitles[num80], double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1207, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5046), ataskTempl_0.m_PremTitles[num80].ToString());
							}
						}
						continue;
					}
					if (num14 <= 12615045L)
					{
						if (num14 <= 12415065L)
						{
							long num81 = num14 - 12405088L;
							if ((ulong)num81 <= 2uL)
							{
								switch ((int)num81)
								{
								case 0:
								{
									for (int num83 = 0; num83 < ataskTempl_0.m_PlayerWanted.Length; num83++)
									{
										if (smethod_7(int_12, (int)ataskTempl_0.m_PlayerWanted[num83].m_Requirements.ModelType[0], double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5088), ataskTempl_0.m_PlayerWanted[num83].m_Requirements.ModelType[0].ToString());
										}
									}
									continue;
								}
								case 1:
								{
									for (int num84 = 0; num84 < ataskTempl_0.m_PlayerWanted.Length; num84++)
									{
										if (smethod_7(int_12, (int)ataskTempl_0.m_PlayerWanted[num84].m_Requirements.ModelType[1], double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5089), ataskTempl_0.m_PlayerWanted[num84].m_Requirements.ModelType[1].ToString());
										}
									}
									continue;
								}
								case 2:
								{
									for (int num82 = 0; num82 < ataskTempl_0.m_PlayerWanted.Length; num82++)
									{
										if (smethod_7(int_12, (int)ataskTempl_0.m_PlayerWanted[num82].m_Requirements.ModelType[2], double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5090), ataskTempl_0.m_PlayerWanted[num82].m_Requirements.ModelType[2].ToString());
										}
									}
									continue;
								}
								}
							}
							long num85 = num14 - 12415057L;
							if ((ulong)num85 > 8uL)
							{
								continue;
							}
							switch ((int)num85)
							{
							case 0:
							{
								for (int num91 = 0; num91 < ataskTempl_0.m_MonsterWanted.Length; num91++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_MonsterWanted[num91].m_ulMonsterTemplId, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1241, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5057), ataskTempl_0.m_MonsterWanted[num91].m_ulMonsterTemplId.ToString());
									}
								}
								break;
							}
							case 1:
							{
								for (int num87 = 0; num87 < ataskTempl_0.m_MonsterWanted.Length; num87++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_MonsterWanted[num87].m_ulMonsterNum, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1241, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5058), mConvert.Int32ToString(ataskTempl_0.m_MonsterWanted[num87].m_ulMonsterNum));
									}
								}
								break;
							}
							case 2:
							{
								for (int num89 = 0; num89 < ataskTempl_0.m_MonsterWanted.Length; num89++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_MonsterWanted[num89].m_ulDropItemId, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1241, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5059), ataskTempl_0.m_MonsterWanted[num89].m_ulDropItemId.ToString());
									}
								}
								break;
							}
							case 3:
							{
								for (int num92 = 0; num92 < ataskTempl_0.m_MonsterWanted.Length; num92++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_MonsterWanted[num92].m_ulDropItemCount, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1241, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5060), mConvert.Int32ToString(ataskTempl_0.m_MonsterWanted[num92].m_ulDropItemCount));
									}
								}
								break;
							}
							case 5:
							{
								for (int num90 = 0; num90 < ataskTempl_0.m_MonsterWanted.Length; num90++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_MonsterWanted[num90].m_fDropProb, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1241, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5062), ataskTempl_0.m_MonsterWanted[num90].m_fDropProb.ToString(GProD.ProbValueFormat));
									}
								}
								break;
							}
							case 7:
							{
								for (int num88 = 0; num88 < ataskTempl_0.m_MonsterWanted.Length; num88++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_MonsterWanted[num88].m_iDPH, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1241, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5064), ataskTempl_0.m_MonsterWanted[num88].m_iDPH.ToString());
									}
								}
								break;
							}
							case 8:
							{
								for (int num86 = 0; num86 < ataskTempl_0.m_MonsterWanted.Length; num86++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_MonsterWanted[num86].m_iDPS, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1241, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5065), ataskTempl_0.m_MonsterWanted[num86].m_iDPS.ToString());
									}
								}
								break;
							}
							}
							continue;
						}
						long num93 = num14 - 12425027L;
						if ((ulong)num93 <= 4uL)
						{
							switch ((int)num93)
							{
							case 0:
							{
								for (int num97 = 0; num97 < ataskTempl_0.m_ItemsWanted.Length; num97++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_ItemsWanted[num97].m_ulItemTemplId, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1242, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5027), ataskTempl_0.m_ItemsWanted[num97].m_ulItemTemplId.ToString());
									}
								}
								continue;
							}
							case 2:
							{
								for (int num95 = 0; num95 < ataskTempl_0.m_ItemsWanted.Length; num95++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_ItemsWanted[num95].m_ulItemNum, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1242, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5029), mConvert.Int32ToString(ataskTempl_0.m_ItemsWanted[num95].m_ulItemNum));
									}
								}
								continue;
							}
							case 3:
							{
								for (int num96 = 0; num96 < ataskTempl_0.m_ItemsWanted.Length; num96++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_ItemsWanted[num96].m_fProb, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1242, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5030), ataskTempl_0.m_ItemsWanted[num96].m_fProb.ToString(GProD.ProbValueFormat));
									}
								}
								continue;
							}
							case 4:
							{
								for (int num94 = 0; num94 < ataskTempl_0.m_ItemsWanted.Length; num94++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_ItemsWanted[num94].m_lPeriod, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1242, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5031), mConvert.SecondsToString(ataskTempl_0.m_ItemsWanted[num94].m_lPeriod));
									}
								}
								continue;
							}
							case 1:
								continue;
							}
						}
						long num98 = num14 - 12615041L;
						if ((ulong)num98 > 4uL)
						{
							continue;
						}
						switch ((int)num98)
						{
						case 0:
							if (smethod_7(int_12, ataskTempl_0.m_Fin1KeyValue.nLeftType, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1261, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041), ataskTempl_0.m_Fin1KeyValue.nLeftType.ToString());
							}
							break;
						case 1:
							if (smethod_7(int_12, ataskTempl_0.m_Fin1KeyValue.lLeftNum, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1261, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042), ataskTempl_0.m_Fin1KeyValue.lLeftNum.ToString());
							}
							break;
						case 2:
							if (smethod_7(int_12, ataskTempl_0.m_Fin1KeyValue.nCompOper, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1261, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043), ataskTempl_0.m_Fin1KeyValue.nCompOper.ToString());
							}
							break;
						case 3:
							if (smethod_7(int_12, ataskTempl_0.m_Fin1KeyValue.nRightType, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1261, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044), ataskTempl_0.m_Fin1KeyValue.nRightType.ToString());
							}
							break;
						case 4:
							if (smethod_7(int_12, ataskTempl_0.m_Fin1KeyValue.lRightNum, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1261, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045), ataskTempl_0.m_Fin1KeyValue.lRightNum.ToString());
							}
							break;
						}
						continue;
					}
					if (num14 <= 12635021L)
					{
						long num99 = num14 - 12625041L;
						if ((ulong)num99 <= 4uL)
						{
							switch ((int)num99)
							{
							case 0:
								if (smethod_7(int_12, ataskTempl_0.m_Fin2KeyValue.nLeftType, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1262, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041), ataskTempl_0.m_Fin2KeyValue.nLeftType.ToString());
								}
								continue;
							case 1:
								if (smethod_7(int_12, ataskTempl_0.m_Fin2KeyValue.lLeftNum, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1262, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042), ataskTempl_0.m_Fin2KeyValue.lLeftNum.ToString());
								}
								continue;
							case 2:
								if (smethod_7(int_12, ataskTempl_0.m_Fin2KeyValue.nCompOper, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1262, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043), ataskTempl_0.m_Fin2KeyValue.nCompOper.ToString());
								}
								continue;
							case 3:
								if (smethod_7(int_12, ataskTempl_0.m_Fin2KeyValue.nRightType, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1262, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044), ataskTempl_0.m_Fin2KeyValue.nRightType.ToString());
								}
								continue;
							case 4:
								if (smethod_7(int_12, ataskTempl_0.m_Fin2KeyValue.lRightNum, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1262, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045), ataskTempl_0.m_Fin2KeyValue.lRightNum.ToString());
								}
								continue;
							}
						}
						if (num14 != 12635021L)
						{
							continue;
						}
						for (int num100 = 0; num100 < ataskTempl_0.m_pExpArr.Length; num100++)
						{
							for (int num101 = 0; num101 < 64; num101++)
							{
								if (smethod_7(int_12, ataskTempl_0.m_pExpArr[num100][num101].type, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1263, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5021) + (num101 + 1), ataskTempl_0.m_pExpArr[num100][num101].type.ToString());
								}
							}
						}
						continue;
					}
					switch (num14)
					{
					case 12745068L:
					{
						for (int num104 = 0; num104 < ataskTempl_0.m_HomeItemsWanted.Length; num104++)
						{
							if (smethod_7(int_12, ataskTempl_0.m_HomeItemsWanted[num104].m_ulHomeItemTid, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1274, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5068), ataskTempl_0.m_HomeItemsWanted[num104].m_ulHomeItemTid.ToString());
							}
						}
						break;
					}
					case 12635022L:
					{
						for (int num102 = 0; num102 < ataskTempl_0.m_pExpArr.Length; num102++)
						{
							for (int num103 = 0; num103 < 64; num103++)
							{
								if (smethod_7(int_12, ataskTempl_0.m_pExpArr[num102][num103].value, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1263, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5022) + (num103 + 1), ataskTempl_0.m_pExpArr[num102][num103].value.ToString());
								}
							}
						}
						break;
					}
					}
					continue;
				}
				if (num14 <= 18085100L)
				{
					if (num14 <= 13715045L)
					{
						if (num14 <= 12935096L)
						{
							switch (num14)
							{
							case 12915092L:
							{
								for (int num110 = 0; num110 < ataskTempl_0.TaskEventMonsterData.Length; num110++)
								{
									if (smethod_7(int_12, ataskTempl_0.TaskEventMonsterData[num110].Value, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1291, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5092), ataskTempl_0.TaskEventMonsterData[num110].Value.ToString());
									}
								}
								break;
							}
							case 12915091L:
							{
								for (int num106 = 0; num106 < ataskTempl_0.TaskEventMonsterData.Length; num106++)
								{
									if (smethod_7(int_12, ataskTempl_0.TaskEventMonsterData[num106].Id, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1291, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5091), ataskTempl_0.TaskEventMonsterData[num106].Id.ToString());
									}
								}
								break;
							}
							case 12745069L:
							{
								for (int num108 = 0; num108 < ataskTempl_0.m_HomeItemsWanted.Length; num108++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_HomeItemsWanted[num108].m_ulHomeItemCount, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1274, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5069), mConvert.Int32ToString(ataskTempl_0.m_HomeItemsWanted[num108].m_ulHomeItemCount));
									}
								}
								break;
							}
							case 12925094L:
							{
								for (int num111 = 0; num111 < ataskTempl_0.TaskEventMineData.Length; num111++)
								{
									if (smethod_7(int_12, ataskTempl_0.TaskEventMineData[num111].Value, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1292, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5094), ataskTempl_0.TaskEventMineData[num111].Value.ToString());
									}
								}
								break;
							}
							case 12925093L:
							{
								for (int num109 = 0; num109 < ataskTempl_0.TaskEventMineData.Length; num109++)
								{
									if (smethod_7(int_12, ataskTempl_0.TaskEventMineData[num109].Id, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1292, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5093), ataskTempl_0.TaskEventMineData[num109].Id.ToString());
									}
								}
								break;
							}
							case 12935096L:
							{
								for (int num107 = 0; num107 < ataskTempl_0.TaskEventTaskData.Length; num107++)
								{
									if (smethod_7(int_12, ataskTempl_0.TaskEventTaskData[num107].Value, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1293, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5096), ataskTempl_0.TaskEventTaskData[num107].Value.ToString());
									}
								}
								break;
							}
							case 12935095L:
							{
								for (int num105 = 0; num105 < ataskTempl_0.TaskEventTaskData.Length; num105++)
								{
									if (smethod_7(int_12, ataskTempl_0.TaskEventTaskData[num105].Id, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1293, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5095), ataskTempl_0.TaskEventTaskData[num105].Id.ToString());
									}
								}
								break;
							}
							}
							continue;
						}
						if (num14 <= 13505005L)
						{
							if (num14 <= 13335102L)
							{
								switch (num14)
								{
								case 13335102L:
								{
									for (int num113 = 0; num113 < ataskTempl_0.m_ulNeededTasks.Length; num113++)
									{
										if (smethod_7(int_12, ataskTempl_0.m_ulNeededTasks[num113], double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1333, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5102), ataskTempl_0.m_ulNeededTasks[num113].ToString());
										}
									}
									break;
								}
								case 13335101L:
								{
									for (int num112 = 0; num112 < ataskTempl_0.m_usNeededTasksSpace.Length; num112++)
									{
										if (smethod_7(int_12, ataskTempl_0.m_usNeededTasksSpace[num112], double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1333, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5101), ataskTempl_0.m_usNeededTasksSpace[num112].ToString());
										}
									}
									break;
								}
								}
								continue;
							}
							long num114 = num14 - 13485000L;
							if ((ulong)num114 <= 5uL)
							{
								switch ((int)num114)
								{
								case 0:
									if (smethod_7(int_12, ataskTempl_0.m_tmNextFailTime.year, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1348, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5000), ataskTempl_0.m_tmNextFailTime.year.ToString());
									}
									continue;
								case 1:
									if (smethod_7(int_12, ataskTempl_0.m_tmNextFailTime.month, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1348, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5001), ataskTempl_0.m_tmNextFailTime.month.ToString());
									}
									continue;
								case 2:
									if (smethod_7(int_12, ataskTempl_0.m_tmNextFailTime.day, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1348, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5002), ataskTempl_0.m_tmNextFailTime.day.ToString());
									}
									continue;
								case 3:
									if (smethod_7(int_12, ataskTempl_0.m_tmNextFailTime.hour, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1348, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5003), ataskTempl_0.m_tmNextFailTime.hour.ToString());
									}
									continue;
								case 4:
									if (smethod_7(int_12, ataskTempl_0.m_tmNextFailTime.min, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1348, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5004), ataskTempl_0.m_tmNextFailTime.min.ToString());
									}
									continue;
								case 5:
									if (smethod_7(int_12, ataskTempl_0.m_tmNextFailTime.wday, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1348, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5005), ataskTempl_0.m_tmNextFailTime.wday.ToString());
									}
									continue;
								}
							}
							long num115 = num14 - 13505000L;
							if ((ulong)num115 > 5uL)
							{
								continue;
							}
							switch ((int)num115)
							{
							case 0:
								if (smethod_7(int_12, ataskTempl_0.m_tmAvailFrequency.year, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1350, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5000), ataskTempl_0.m_tmAvailFrequency.year.ToString());
								}
								break;
							case 1:
								if (smethod_7(int_12, ataskTempl_0.m_tmAvailFrequency.month, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1350, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5001), ataskTempl_0.m_tmAvailFrequency.month.ToString());
								}
								break;
							case 2:
								if (smethod_7(int_12, ataskTempl_0.m_tmAvailFrequency.day, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1350, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5002), ataskTempl_0.m_tmAvailFrequency.day.ToString());
								}
								break;
							case 3:
								if (smethod_7(int_12, ataskTempl_0.m_tmAvailFrequency.hour, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1350, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5003), ataskTempl_0.m_tmAvailFrequency.hour.ToString());
								}
								break;
							case 4:
								if (smethod_7(int_12, ataskTempl_0.m_tmAvailFrequency.min, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1350, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5004), ataskTempl_0.m_tmAvailFrequency.min.ToString());
								}
								break;
							case 5:
								if (smethod_7(int_12, ataskTempl_0.m_tmAvailFrequency.wday, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1350, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5005), ataskTempl_0.m_tmAvailFrequency.wday.ToString());
								}
								break;
							}
							continue;
						}
						if (num14 <= 13555045L)
						{
							long num116 = num14 - 13545041L;
							if ((ulong)num116 <= 4uL)
							{
								switch ((int)num116)
								{
								case 0:
									if (smethod_7(int_12, ataskTempl_0.m_Prop1KeyValue.nLeftType, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1354, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041), ataskTempl_0.m_Prop1KeyValue.nLeftType.ToString());
									}
									continue;
								case 1:
									if (smethod_7(int_12, ataskTempl_0.m_Prop1KeyValue.lLeftNum, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1354, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042), ataskTempl_0.m_Prop1KeyValue.lLeftNum.ToString());
									}
									continue;
								case 2:
									if (smethod_7(int_12, ataskTempl_0.m_Prop1KeyValue.nCompOper, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1354, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043), ataskTempl_0.m_Prop1KeyValue.nCompOper.ToString());
									}
									continue;
								case 3:
									if (smethod_7(int_12, ataskTempl_0.m_Prop1KeyValue.nRightType, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1354, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044), ataskTempl_0.m_Prop1KeyValue.nRightType.ToString());
									}
									continue;
								case 4:
									if (smethod_7(int_12, ataskTempl_0.m_Prop1KeyValue.lRightNum, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1354, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045), ataskTempl_0.m_Prop1KeyValue.lRightNum.ToString());
									}
									continue;
								}
							}
							long num117 = num14 - 13555041L;
							if ((ulong)num117 > 4uL)
							{
								continue;
							}
							switch ((int)num117)
							{
							case 0:
								if (smethod_7(int_12, ataskTempl_0.m_Prop2KeyValue.nLeftType, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1355, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041), ataskTempl_0.m_Prop2KeyValue.nLeftType.ToString());
								}
								break;
							case 1:
								if (smethod_7(int_12, ataskTempl_0.m_Prop2KeyValue.lLeftNum, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1355, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042), ataskTempl_0.m_Prop2KeyValue.lLeftNum.ToString());
								}
								break;
							case 2:
								if (smethod_7(int_12, ataskTempl_0.m_Prop2KeyValue.nCompOper, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1355, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043), ataskTempl_0.m_Prop2KeyValue.nCompOper.ToString());
								}
								break;
							case 3:
								if (smethod_7(int_12, ataskTempl_0.m_Prop2KeyValue.nRightType, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1355, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044), ataskTempl_0.m_Prop2KeyValue.nRightType.ToString());
								}
								break;
							case 4:
								if (smethod_7(int_12, ataskTempl_0.m_Prop2KeyValue.lRightNum, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1355, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045), ataskTempl_0.m_Prop2KeyValue.lRightNum.ToString());
								}
								break;
							}
							continue;
						}
						long num118 = num14 - 13675107L;
						if ((ulong)num118 <= 2uL)
						{
							switch ((int)num118)
							{
							case 0:
							{
								for (int num120 = 0; num120 < ataskTempl_0.m_plPersonChangeKey.Length; num120++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_plPersonChangeKey[num120], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1367, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5107), ataskTempl_0.m_plPersonChangeKey[num120].ToString());
									}
								}
								continue;
							}
							case 1:
							{
								for (int num121 = 0; num121 < ataskTempl_0.m_plPersonChangeKeyValue.Length; num121++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_plPersonChangeKeyValue[num121], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1367, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5108), ataskTempl_0.m_plPersonChangeKeyValue[num121].ToString());
									}
								}
								continue;
							}
							case 2:
							{
								for (int num119 = 0; num119 < ataskTempl_0.m_pbPersonChangeType.Length; num119++)
								{
									if (smethod_7(int_12, Convert.ToInt32(ataskTempl_0.m_pbPersonChangeType[num119]), double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1367, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5109), Convert.ToInt32(ataskTempl_0.m_pbPersonChangeType[num119]).ToString());
									}
								}
								continue;
							}
							}
						}
						long num122 = num14 - 13715041L;
						if ((ulong)num122 > 4uL)
						{
							continue;
						}
						switch ((int)num122)
						{
						case 0:
							if (smethod_7(int_12, ataskTempl_0.m_Prem1PersonKeyValue.nLeftType, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1371, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041), ataskTempl_0.m_Prem1PersonKeyValue.nLeftType.ToString());
							}
							break;
						case 1:
							if (smethod_7(int_12, ataskTempl_0.m_Prem1PersonKeyValue.lLeftNum, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1371, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042), ataskTempl_0.m_Prem1PersonKeyValue.lLeftNum.ToString());
							}
							break;
						case 2:
							if (smethod_7(int_12, ataskTempl_0.m_Prem1PersonKeyValue.nCompOper, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1371, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043), ataskTempl_0.m_Prem1PersonKeyValue.nCompOper.ToString());
							}
							break;
						case 3:
							if (smethod_7(int_12, ataskTempl_0.m_Prem1PersonKeyValue.nRightType, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1371, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044), ataskTempl_0.m_Prem1PersonKeyValue.nRightType.ToString());
							}
							break;
						case 4:
							if (smethod_7(int_12, ataskTempl_0.m_Prem1PersonKeyValue.lRightNum, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1371, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045), ataskTempl_0.m_Prem1PersonKeyValue.lRightNum.ToString());
							}
							break;
						}
						continue;
					}
					if (num14 <= 13875045L)
					{
						if (num14 <= 13765045L)
						{
							long num123 = num14 - 13725041L;
							if ((ulong)num123 <= 4uL)
							{
								switch ((int)num123)
								{
								case 0:
									if (smethod_7(int_12, ataskTempl_0.m_Prem2PersonKeyValue.nLeftType, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1372, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041), ataskTempl_0.m_Prem2PersonKeyValue.nLeftType.ToString());
									}
									continue;
								case 1:
									if (smethod_7(int_12, ataskTempl_0.m_Prem2PersonKeyValue.lLeftNum, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1372, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042), ataskTempl_0.m_Prem2PersonKeyValue.lLeftNum.ToString());
									}
									continue;
								case 2:
									if (smethod_7(int_12, ataskTempl_0.m_Prem2PersonKeyValue.nCompOper, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1372, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043), ataskTempl_0.m_Prem2PersonKeyValue.nCompOper.ToString());
									}
									continue;
								case 3:
									if (smethod_7(int_12, ataskTempl_0.m_Prem2PersonKeyValue.nRightType, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1372, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044), ataskTempl_0.m_Prem2PersonKeyValue.nRightType.ToString());
									}
									continue;
								case 4:
									if (smethod_7(int_12, ataskTempl_0.m_Prem2PersonKeyValue.lRightNum, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1372, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045), ataskTempl_0.m_Prem2PersonKeyValue.lRightNum.ToString());
									}
									continue;
								}
							}
							long num124 = num14 - 13755041L;
							if ((ulong)num124 <= 4uL)
							{
								switch ((int)num124)
								{
								case 0:
									if (smethod_7(int_12, ataskTempl_0.m_Fin1PersonKeyValue.nLeftType, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1375, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041), ataskTempl_0.m_Fin1PersonKeyValue.nLeftType.ToString());
									}
									continue;
								case 1:
									if (smethod_7(int_12, ataskTempl_0.m_Fin1PersonKeyValue.lLeftNum, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1375, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042), ataskTempl_0.m_Fin1PersonKeyValue.lLeftNum.ToString());
									}
									continue;
								case 2:
									if (smethod_7(int_12, ataskTempl_0.m_Fin1PersonKeyValue.nCompOper, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1375, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043), ataskTempl_0.m_Fin1PersonKeyValue.nCompOper.ToString());
									}
									continue;
								case 3:
									if (smethod_7(int_12, ataskTempl_0.m_Fin1PersonKeyValue.nRightType, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1375, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044), ataskTempl_0.m_Fin1PersonKeyValue.nRightType.ToString());
									}
									continue;
								case 4:
									if (smethod_7(int_12, ataskTempl_0.m_Fin1PersonKeyValue.lRightNum, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1375, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045), ataskTempl_0.m_Fin1PersonKeyValue.lRightNum.ToString());
									}
									continue;
								}
							}
							long num125 = num14 - 13765041L;
							if ((ulong)num125 > 4uL)
							{
								continue;
							}
							switch ((int)num125)
							{
							case 0:
								if (smethod_7(int_12, ataskTempl_0.m_Fin2PersonKeyValue.nLeftType, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1262, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041), ataskTempl_0.m_Fin2PersonKeyValue.nLeftType.ToString());
								}
								break;
							case 1:
								if (smethod_7(int_12, ataskTempl_0.m_Fin2PersonKeyValue.lLeftNum, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1262, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042), ataskTempl_0.m_Fin2PersonKeyValue.lLeftNum.ToString());
								}
								break;
							case 2:
								if (smethod_7(int_12, ataskTempl_0.m_Fin2PersonKeyValue.nCompOper, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1262, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043), ataskTempl_0.m_Fin2PersonKeyValue.nCompOper.ToString());
								}
								break;
							case 3:
								if (smethod_7(int_12, ataskTempl_0.m_Fin2PersonKeyValue.nRightType, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1262, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044), ataskTempl_0.m_Fin2PersonKeyValue.nRightType.ToString());
								}
								break;
							case 4:
								if (smethod_7(int_12, ataskTempl_0.m_Fin2PersonKeyValue.lRightNum, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1262, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045), ataskTempl_0.m_Fin2PersonKeyValue.lRightNum.ToString());
								}
								break;
							}
							continue;
						}
						if (num14 <= 13775022L)
						{
							switch (num14)
							{
							case 13775022L:
							{
								for (int num128 = 0; num128 < ataskTempl_0.PersonExpArr.Length; num128++)
								{
									for (int num129 = 0; num129 < 64; num129++)
									{
										if (smethod_7(int_12, ataskTempl_0.PersonExpArr[num128][num129].value, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1377, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5022) + (num129 + 1), ataskTempl_0.PersonExpArr[num128][num129].value.ToString());
										}
									}
								}
								break;
							}
							case 13775021L:
							{
								for (int num126 = 0; num126 < ataskTempl_0.PersonExpArr.Length; num126++)
								{
									for (int num127 = 0; num127 < 64; num127++)
									{
										if (smethod_7(int_12, ataskTempl_0.PersonExpArr[num126][num127].type, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1377, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5021) + (num127 + 1), ataskTempl_0.PersonExpArr[num126][num127].type.ToString());
										}
									}
								}
								break;
							}
							}
							continue;
						}
						long num130 = num14 - 13835081L;
						if ((ulong)num130 <= 2uL)
						{
							switch ((int)num130)
							{
							case 0:
							{
								for (int num132 = 0; num132 < ataskTempl_0.m_plHistoryChangeKey.Length; num132++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_plHistoryChangeKey[num132], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1383, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5081), ataskTempl_0.m_plHistoryChangeKey[num132].ToString());
									}
								}
								continue;
							}
							case 1:
							{
								for (int num133 = 0; num133 < ataskTempl_0.m_plHistoryChangeKeyValue.Length; num133++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_plHistoryChangeKeyValue[num133], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1383, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5082), ataskTempl_0.m_plHistoryChangeKeyValue[num133].ToString());
									}
								}
								continue;
							}
							case 2:
							{
								for (int num131 = 0; num131 < ataskTempl_0.m_pbHistoryChangeType.Length; num131++)
								{
									if (smethod_7(int_12, Convert.ToInt32(ataskTempl_0.m_pbHistoryChangeType[num131]), double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1383, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5083), Convert.ToInt32(ataskTempl_0.m_pbHistoryChangeType[num131]).ToString());
									}
								}
								continue;
							}
							}
						}
						long num134 = num14 - 13875041L;
						if ((ulong)num134 > 4uL)
						{
							continue;
						}
						switch ((int)num134)
						{
						case 0:
							if (smethod_7(int_12, ataskTempl_0.m_Prem1HistoryKeyValue.nLeftType, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1387, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041), ataskTempl_0.m_Prem1HistoryKeyValue.nLeftType.ToString());
							}
							break;
						case 1:
							if (smethod_7(int_12, ataskTempl_0.m_Prem1HistoryKeyValue.lLeftNum, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1387, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042), ataskTempl_0.m_Prem1HistoryKeyValue.lLeftNum.ToString());
							}
							break;
						case 2:
							if (smethod_7(int_12, ataskTempl_0.m_Prem1HistoryKeyValue.nCompOper, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1387, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043), ataskTempl_0.m_Prem1HistoryKeyValue.nCompOper.ToString());
							}
							break;
						case 3:
							if (smethod_7(int_12, ataskTempl_0.m_Prem1HistoryKeyValue.nRightType, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1387, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044), ataskTempl_0.m_Prem1HistoryKeyValue.nRightType.ToString());
							}
							break;
						case 4:
							if (smethod_7(int_12, ataskTempl_0.m_Prem1HistoryKeyValue.lRightNum, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1387, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045), ataskTempl_0.m_Prem1HistoryKeyValue.lRightNum.ToString());
							}
							break;
						}
						continue;
					}
					if (num14 <= 13935021L)
					{
						if (num14 <= 13915045L)
						{
							long num135 = num14 - 13885041L;
							if ((ulong)num135 <= 4uL)
							{
								switch ((int)num135)
								{
								case 0:
									if (smethod_7(int_12, ataskTempl_0.m_Prem2HistoryKeyValue.nLeftType, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1388, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041), ataskTempl_0.m_Prem2HistoryKeyValue.nLeftType.ToString());
									}
									continue;
								case 1:
									if (smethod_7(int_12, ataskTempl_0.m_Prem2HistoryKeyValue.lLeftNum, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1388, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042), ataskTempl_0.m_Prem2HistoryKeyValue.lLeftNum.ToString());
									}
									continue;
								case 2:
									if (smethod_7(int_12, ataskTempl_0.m_Prem2HistoryKeyValue.nCompOper, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1388, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043), ataskTempl_0.m_Prem2HistoryKeyValue.nCompOper.ToString());
									}
									continue;
								case 3:
									if (smethod_7(int_12, ataskTempl_0.m_Prem2HistoryKeyValue.nRightType, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1388, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044), ataskTempl_0.m_Prem2HistoryKeyValue.nRightType.ToString());
									}
									continue;
								case 4:
									if (smethod_7(int_12, ataskTempl_0.m_Prem2HistoryKeyValue.lRightNum, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1388, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045), ataskTempl_0.m_Prem2HistoryKeyValue.lRightNum.ToString());
									}
									continue;
								}
							}
							long num136 = num14 - 13915041L;
							if ((ulong)num136 > 4uL)
							{
								continue;
							}
							switch ((int)num136)
							{
							case 0:
								if (smethod_7(int_12, ataskTempl_0.m_Fin1HistoryKeyValue.nLeftType, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1391, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041), ataskTempl_0.m_Fin1HistoryKeyValue.nLeftType.ToString());
								}
								break;
							case 1:
								if (smethod_7(int_12, ataskTempl_0.m_Fin1HistoryKeyValue.lLeftNum, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1391, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042), ataskTempl_0.m_Fin1HistoryKeyValue.lLeftNum.ToString());
								}
								break;
							case 2:
								if (smethod_7(int_12, ataskTempl_0.m_Fin1HistoryKeyValue.nCompOper, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1391, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043), ataskTempl_0.m_Fin1HistoryKeyValue.nCompOper.ToString());
								}
								break;
							case 3:
								if (smethod_7(int_12, ataskTempl_0.m_Fin1HistoryKeyValue.nRightType, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1391, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044), ataskTempl_0.m_Fin1HistoryKeyValue.nRightType.ToString());
								}
								break;
							case 4:
								if (smethod_7(int_12, ataskTempl_0.m_Fin1HistoryKeyValue.lRightNum, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1391, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045), ataskTempl_0.m_Fin1HistoryKeyValue.lRightNum.ToString());
								}
								break;
							}
							continue;
						}
						long num137 = num14 - 13925041L;
						if ((ulong)num137 <= 4uL)
						{
							switch ((int)num137)
							{
							case 0:
								if (smethod_7(int_12, ataskTempl_0.m_Fin2HistoryKeyValue.nLeftType, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1392, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041), ataskTempl_0.m_Fin2HistoryKeyValue.nLeftType.ToString());
								}
								continue;
							case 1:
								if (smethod_7(int_12, ataskTempl_0.m_Fin2HistoryKeyValue.lLeftNum, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1392, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042), ataskTempl_0.m_Fin2HistoryKeyValue.lLeftNum.ToString());
								}
								continue;
							case 2:
								if (smethod_7(int_12, ataskTempl_0.m_Fin2HistoryKeyValue.nCompOper, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1392, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043), ataskTempl_0.m_Fin2HistoryKeyValue.nCompOper.ToString());
								}
								continue;
							case 3:
								if (smethod_7(int_12, ataskTempl_0.m_Fin2HistoryKeyValue.nRightType, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1392, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044), ataskTempl_0.m_Fin2HistoryKeyValue.nRightType.ToString());
								}
								continue;
							case 4:
								if (smethod_7(int_12, ataskTempl_0.m_Fin2HistoryKeyValue.lRightNum, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1392, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045), ataskTempl_0.m_Fin2HistoryKeyValue.lRightNum.ToString());
								}
								continue;
							}
						}
						if (num14 != 13935021L)
						{
							continue;
						}
						for (int num138 = 0; num138 < ataskTempl_0.HistoryExpArr.Length; num138++)
						{
							for (int num139 = 0; num139 < 64; num139++)
							{
								if (smethod_7(int_12, ataskTempl_0.HistoryExpArr[num138][num139].type, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1393, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5021) + (num139 + 1), ataskTempl_0.HistoryExpArr[num138][num139].type.ToString());
								}
							}
						}
						continue;
					}
					if (num14 <= 14455074L)
					{
						if (num14 != 13935022L)
						{
							long num140 = num14 - 14455071L;
							if ((ulong)num140 > 3uL)
							{
								continue;
							}
							switch ((int)num140)
							{
							case 0:
							{
								for (int num144 = 0; num144 < ataskTempl_0.m_ulPropSummonedMonsters; num144++)
								{
									if (smethod_7(int_12, ataskTempl_0.PropMonsterSummoned.m_Monsters[num144].m_ulMonsterTemplId, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1445, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5071), ataskTempl_0.PropMonsterSummoned.m_Monsters[num144].m_ulMonsterTemplId.ToString());
									}
								}
								break;
							}
							case 1:
							{
								for (int num142 = 0; num142 < ataskTempl_0.m_ulPropSummonedMonsters; num142++)
								{
									if (smethod_7(int_12, ataskTempl_0.PropMonsterSummoned.m_Monsters[num142].m_ulMonsterNum, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1445, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5072), mConvert.Int32ToString(ataskTempl_0.PropMonsterSummoned.m_Monsters[num142].m_ulMonsterNum));
									}
								}
								break;
							}
							case 2:
							{
								for (int num143 = 0; num143 < ataskTempl_0.m_ulPropSummonedMonsters; num143++)
								{
									if (smethod_7(int_12, ataskTempl_0.PropMonsterSummoned.m_Monsters[num143].m_fSummonProb, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1445, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5073), ataskTempl_0.PropMonsterSummoned.m_Monsters[num143].m_fSummonProb.ToString(GProD.ProbValueFormat));
									}
								}
								break;
							}
							case 3:
							{
								for (int num141 = 0; num141 < ataskTempl_0.m_ulPropSummonedMonsters; num141++)
								{
									if (smethod_7(int_12, ataskTempl_0.PropMonsterSummoned.m_Monsters[num141].m_lPeriod, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1445, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5074), mConvert.SecondsToString(ataskTempl_0.PropMonsterSummoned.m_Monsters[num141].m_lPeriod));
									}
								}
								break;
							}
							}
							continue;
						}
						for (int num145 = 0; num145 < ataskTempl_0.HistoryExpArr.Length; num145++)
						{
							for (int num146 = 0; num146 < 64; num146++)
							{
								if (smethod_7(int_12, ataskTempl_0.HistoryExpArr[num145][num146].value, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1393, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5022) + (num146 + 1), ataskTempl_0.HistoryExpArr[num145][num146].value.ToString());
								}
							}
						}
						continue;
					}
					switch (num14)
					{
					case 18085100L:
					{
						for (int num148 = 0; num148 < ataskTempl_0.SpecialParameters.CompleteTaskIDs.Length; num148++)
						{
							if (smethod_7(int_12, ataskTempl_0.SpecialParameters.CompleteTaskIDs[num148], double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1808, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5100), ataskTempl_0.SpecialParameters.CompleteTaskIDs[num148].ToString());
							}
						}
						break;
					}
					case 18045099L:
					{
						for (int num147 = 0; num147 < ataskTempl_0.SpecialParameters.UseItemIDs.Length; num147++)
						{
							if (smethod_7(int_12, ataskTempl_0.SpecialParameters.UseItemIDs[num147], double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1804, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5099), ataskTempl_0.SpecialParameters.UseItemIDs[num147].ToString());
							}
						}
						break;
					}
					}
					continue;
				}
				if (num14 <= 60765016L)
				{
					if (num14 <= 60745016L)
					{
						if (num14 <= 60715010L)
						{
							if (num14 != 18085101L)
							{
								long num149 = num14 - 22415057L;
								if ((ulong)num149 <= 8uL)
								{
									switch ((int)num149)
									{
									case 0:
									{
										for (int num155 = 0; num155 < ataskTempl_0.m_MonsterUnwanted.Length; num155++)
										{
											if (smethod_7(int_12, ataskTempl_0.m_MonsterUnwanted[num155].m_ulMonsterTemplId, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(22410, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5057), ataskTempl_0.m_MonsterUnwanted[num155].m_ulMonsterTemplId.ToString());
											}
										}
										continue;
									}
									case 1:
									{
										for (int num151 = 0; num151 < ataskTempl_0.m_MonsterUnwanted.Length; num151++)
										{
											if (smethod_7(int_12, ataskTempl_0.m_MonsterUnwanted[num151].m_ulMonsterNum, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(22410, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5058), mConvert.Int32ToString(ataskTempl_0.m_MonsterUnwanted[num151].m_ulMonsterNum));
											}
										}
										continue;
									}
									case 2:
									{
										for (int num153 = 0; num153 < ataskTempl_0.m_MonsterUnwanted.Length; num153++)
										{
											if (smethod_7(int_12, ataskTempl_0.m_MonsterUnwanted[num153].m_ulDropItemId, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(22410, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5059), ataskTempl_0.m_MonsterUnwanted[num153].m_ulDropItemId.ToString());
											}
										}
										continue;
									}
									case 3:
									{
										for (int num156 = 0; num156 < ataskTempl_0.m_MonsterUnwanted.Length; num156++)
										{
											if (smethod_7(int_12, ataskTempl_0.m_MonsterUnwanted[num156].m_ulDropItemCount, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(22410, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5060), mConvert.Int32ToString(ataskTempl_0.m_MonsterUnwanted[num156].m_ulDropItemCount));
											}
										}
										continue;
									}
									case 5:
									{
										for (int num154 = 0; num154 < ataskTempl_0.m_MonsterUnwanted.Length; num154++)
										{
											if (smethod_7(int_12, ataskTempl_0.m_MonsterUnwanted[num154].m_fDropProb, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(22410, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5062), ataskTempl_0.m_MonsterUnwanted[num154].m_fDropProb.ToString(GProD.ProbValueFormat));
											}
										}
										continue;
									}
									case 7:
									{
										for (int num152 = 0; num152 < ataskTempl_0.m_MonsterUnwanted.Length; num152++)
										{
											if (smethod_7(int_12, ataskTempl_0.m_MonsterUnwanted[num152].m_iDPH, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(22410, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5064), ataskTempl_0.m_MonsterUnwanted[num152].m_iDPH.ToString());
											}
										}
										continue;
									}
									case 8:
									{
										for (int num150 = 0; num150 < ataskTempl_0.m_MonsterUnwanted.Length; num150++)
										{
											if (smethod_7(int_12, ataskTempl_0.m_MonsterUnwanted[num150].m_iDPS, double_))
											{
												smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(22410, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5065), ataskTempl_0.m_MonsterUnwanted[num150].m_iDPS.ToString());
											}
										}
										continue;
									}
									case 4:
									case 6:
										continue;
									}
								}
								if (num14 != 60715010L)
								{
									continue;
								}
								for (int num157 = 0; num157 < ataskTempl_0.m_tmType.Length; num157++)
								{
									if (smethod_7(int_12, (int)ataskTempl_0.m_tmType[num157], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6071, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5010), ataskTempl_0.m_tmType[num157].ToString());
									}
								}
								continue;
							}
							for (int num158 = 0; num158 < ataskTempl_0.SpecialParameters.CompleteTaskIDsSpace.Length; num158++)
							{
								if (smethod_7(int_12, ataskTempl_0.SpecialParameters.CompleteTaskIDsSpace[num158], double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1808, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5101), ataskTempl_0.SpecialParameters.CompleteTaskIDsSpace[num158].ToString());
								}
							}
						}
						else if (num14 <= 60735005L)
						{
							long num159 = num14 - 60725000L;
							if ((ulong)num159 <= 5uL)
							{
								switch ((int)num159)
								{
								case 0:
								{
									for (int num163 = 0; num163 < ataskTempl_0.m_tmStart.Length; num163++)
									{
										if (smethod_7(int_12, ataskTempl_0.m_tmStart[num163].year, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6072, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5000), ataskTempl_0.m_tmStart[num163].year.ToString());
										}
									}
									continue;
								}
								case 1:
								{
									for (int num165 = 0; num165 < ataskTempl_0.m_tmStart.Length; num165++)
									{
										if (smethod_7(int_12, ataskTempl_0.m_tmStart[num165].month, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6072, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5001), ataskTempl_0.m_tmStart[num165].month.ToString());
										}
									}
									continue;
								}
								case 2:
								{
									for (int num161 = 0; num161 < ataskTempl_0.m_tmStart.Length; num161++)
									{
										if (smethod_7(int_12, ataskTempl_0.m_tmStart[num161].day, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6072, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5002), ataskTempl_0.m_tmStart[num161].day.ToString());
										}
									}
									continue;
								}
								case 3:
								{
									for (int num164 = 0; num164 < ataskTempl_0.m_tmStart.Length; num164++)
									{
										if (smethod_7(int_12, ataskTempl_0.m_tmStart[num164].hour, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6072, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5003), ataskTempl_0.m_tmStart[num164].hour.ToString());
										}
									}
									continue;
								}
								case 4:
								{
									for (int num162 = 0; num162 < ataskTempl_0.m_tmStart.Length; num162++)
									{
										if (smethod_7(int_12, ataskTempl_0.m_tmStart[num162].min, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6072, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5004), ataskTempl_0.m_tmStart[num162].min.ToString());
										}
									}
									continue;
								}
								case 5:
								{
									for (int num160 = 0; num160 < ataskTempl_0.m_tmStart.Length; num160++)
									{
										if (smethod_7(int_12, ataskTempl_0.m_tmStart[num160].wday, double_))
										{
											smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6072, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5005), ataskTempl_0.m_tmStart[num160].wday.ToString());
										}
									}
									continue;
								}
								}
							}
							long num166 = num14 - 60735000L;
							if ((ulong)num166 > 5uL)
							{
								continue;
							}
							switch ((int)num166)
							{
							case 0:
							{
								for (int num170 = 0; num170 < ataskTempl_0.m_tmEnd.Length; num170++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_tmEnd[num170].year, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6073, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5000), ataskTempl_0.m_tmEnd[num170].year.ToString());
									}
								}
								break;
							}
							case 1:
							{
								for (int num172 = 0; num172 < ataskTempl_0.m_tmEnd.Length; num172++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_tmEnd[num172].month, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6073, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5001), ataskTempl_0.m_tmEnd[num172].month.ToString());
									}
								}
								break;
							}
							case 2:
							{
								for (int num168 = 0; num168 < ataskTempl_0.m_tmEnd.Length; num168++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_tmEnd[num168].day, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6073, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5002), ataskTempl_0.m_tmEnd[num168].day.ToString());
									}
								}
								break;
							}
							case 3:
							{
								for (int num171 = 0; num171 < ataskTempl_0.m_tmEnd.Length; num171++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_tmEnd[num171].hour, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6073, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5003), ataskTempl_0.m_tmEnd[num171].hour.ToString());
									}
								}
								break;
							}
							case 4:
							{
								for (int num169 = 0; num169 < ataskTempl_0.m_tmEnd.Length; num169++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_tmEnd[num169].min, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6073, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5004), ataskTempl_0.m_tmEnd[num169].min.ToString());
									}
								}
								break;
							}
							case 5:
							{
								for (int num167 = 0; num167 < ataskTempl_0.m_tmEnd.Length; num167++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_tmEnd[num167].wday, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6073, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5005), ataskTempl_0.m_tmEnd[num167].wday.ToString());
									}
								}
								break;
							}
							}
						}
						else if (num14 != 60741026L)
						{
							long num173 = num14 - 60745011L;
							if ((ulong)num173 > 5uL)
							{
								continue;
							}
							switch ((int)num173)
							{
							case 0:
							{
								for (int num177 = 0; num177 < ataskTempl_0.m_pDelvRegion.Length; num177++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pDelvRegion[num177].zvMin.Single_0[0], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6074, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5011), ataskTempl_0.m_pDelvRegion[num177].zvMin.Single_0[0].ToString(Class16.smethod_0(1648964192)));
									}
								}
								break;
							}
							case 1:
							{
								for (int num179 = 0; num179 < ataskTempl_0.m_pDelvRegion.Length; num179++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pDelvRegion[num179].zvMin.Single_0[1], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6074, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5012), ataskTempl_0.m_pDelvRegion[num179].zvMin.Single_0[1].ToString(Class16.smethod_0(1648964192)));
									}
								}
								break;
							}
							case 2:
							{
								for (int num175 = 0; num175 < ataskTempl_0.m_pDelvRegion.Length; num175++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pDelvRegion[num175].zvMin.Single_0[2], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6074, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5013), ataskTempl_0.m_pDelvRegion[num175].zvMin.Single_0[2].ToString(Class16.smethod_0(1648964192)));
									}
								}
								break;
							}
							case 3:
							{
								for (int num178 = 0; num178 < ataskTempl_0.m_pDelvRegion.Length; num178++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pDelvRegion[num178].zvMax.Single_0[0], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6074, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5014), ataskTempl_0.m_pDelvRegion[num178].zvMax.Single_0[0].ToString(Class16.smethod_0(1648964192)));
									}
								}
								break;
							}
							case 4:
							{
								for (int num176 = 0; num176 < ataskTempl_0.m_pDelvRegion.Length; num176++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pDelvRegion[num176].zvMax.Single_0[1], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6074, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5015), ataskTempl_0.m_pDelvRegion[num176].zvMax.Single_0[1].ToString(Class16.smethod_0(1648964192)));
									}
								}
								break;
							}
							case 5:
							{
								for (int num174 = 0; num174 < ataskTempl_0.m_pDelvRegion.Length; num174++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pDelvRegion[num174].zvMax.Single_0[2], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6074, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5016), ataskTempl_0.m_pDelvRegion[num174].zvMax.Single_0[2].ToString(Class16.smethod_0(1648964192)));
									}
								}
								break;
							}
							}
						}
						else if (smethod_7(int_12, ataskTempl_0.m_ulDelvWorld, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6074, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1026), ataskTempl_0.m_ulDelvWorld.ToString());
						}
					}
					else if (num14 <= 60755016L)
					{
						if (num14 <= 60745556L)
						{
							switch (num14)
							{
							case 60745556L:
							{
								for (int num181 = 0; num181 < ataskTempl_0.m_pDelvRegion.Length; num181++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pDelvRegion[num181].RegionID, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6074, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(8010), ataskTempl_0.m_pDelvRegion[num181].RegionID.ToString());
									}
								}
								break;
							}
							case 60745104L:
							{
								for (int num180 = 0; num180 < ataskTempl_0.m_pDelvRegion.Length; num180++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pDelvRegion[num180].MapID, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6074, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5104), ataskTempl_0.m_pDelvRegion[num180].MapID.ToString());
									}
								}
								break;
							}
							}
						}
						else if (num14 != 60751028L)
						{
							long num182 = num14 - 60755011L;
							if ((ulong)num182 > 5uL)
							{
								continue;
							}
							switch ((int)num182)
							{
							case 0:
							{
								for (int num186 = 0; num186 < ataskTempl_0.m_pEnterRegion.Length; num186++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pEnterRegion[num186].zvMin.Single_0[0], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6075, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5011), ataskTempl_0.m_pEnterRegion[num186].zvMin.Single_0[0].ToString(Class16.smethod_0(1648964192)));
									}
								}
								break;
							}
							case 1:
							{
								for (int num188 = 0; num188 < ataskTempl_0.m_pEnterRegion.Length; num188++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pEnterRegion[num188].zvMin.Single_0[1], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6075, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5012), ataskTempl_0.m_pEnterRegion[num188].zvMin.Single_0[1].ToString(Class16.smethod_0(1648964192)));
									}
								}
								break;
							}
							case 2:
							{
								for (int num184 = 0; num184 < ataskTempl_0.m_pEnterRegion.Length; num184++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pEnterRegion[num184].zvMin.Single_0[2], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6075, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5013), ataskTempl_0.m_pEnterRegion[num184].zvMin.Single_0[2].ToString(Class16.smethod_0(1648964192)));
									}
								}
								break;
							}
							case 3:
							{
								for (int num187 = 0; num187 < ataskTempl_0.m_pEnterRegion.Length; num187++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pEnterRegion[num187].zvMax.Single_0[0], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6075, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5014), ataskTempl_0.m_pEnterRegion[num187].zvMax.Single_0[0].ToString(Class16.smethod_0(1648964192)));
									}
								}
								break;
							}
							case 4:
							{
								for (int num185 = 0; num185 < ataskTempl_0.m_pEnterRegion.Length; num185++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pEnterRegion[num185].zvMax.Single_0[1], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6075, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5015), ataskTempl_0.m_pEnterRegion[num185].zvMax.Single_0[1].ToString(Class16.smethod_0(1648964192)));
									}
								}
								break;
							}
							case 5:
							{
								for (int num183 = 0; num183 < ataskTempl_0.m_pEnterRegion.Length; num183++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pEnterRegion[num183].zvMax.Single_0[2], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6075, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5016), ataskTempl_0.m_pEnterRegion[num183].zvMax.Single_0[2].ToString(Class16.smethod_0(1648964192)));
									}
								}
								break;
							}
							}
						}
						else if (smethod_7(int_12, ataskTempl_0.m_ulEnterRegionWorld, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6075, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1028), ataskTempl_0.m_ulEnterRegionWorld.ToString());
						}
					}
					else if (num14 <= 60755556L)
					{
						switch (num14)
						{
						case 60755556L:
						{
							for (int num190 = 0; num190 < ataskTempl_0.m_pEnterRegion.Length; num190++)
							{
								if (smethod_7(int_12, ataskTempl_0.m_pEnterRegion[num190].RegionID, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6075, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(8010), ataskTempl_0.m_pEnterRegion[num190].RegionID.ToString());
								}
							}
							break;
						}
						case 60755104L:
						{
							for (int num189 = 0; num189 < ataskTempl_0.m_pEnterRegion.Length; num189++)
							{
								if (smethod_7(int_12, ataskTempl_0.m_pEnterRegion[num189].MapID, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6075, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5104), ataskTempl_0.m_pEnterRegion[num189].MapID.ToString());
								}
							}
							break;
						}
						}
					}
					else if (num14 != 60761030L)
					{
						long num191 = num14 - 60765011L;
						if ((ulong)num191 > 5uL)
						{
							continue;
						}
						switch ((int)num191)
						{
						case 0:
						{
							for (int num195 = 0; num195 < ataskTempl_0.m_pLeaveRegion.Length; num195++)
							{
								if (smethod_7(int_12, ataskTempl_0.m_pLeaveRegion[num195].zvMin.Single_0[0], double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6076, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5011), ataskTempl_0.m_pLeaveRegion[num195].zvMin.Single_0[0].ToString(Class16.smethod_0(1648964192)));
								}
							}
							break;
						}
						case 1:
						{
							for (int num197 = 0; num197 < ataskTempl_0.m_pLeaveRegion.Length; num197++)
							{
								if (smethod_7(int_12, ataskTempl_0.m_pLeaveRegion[num197].zvMin.Single_0[1], double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6076, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5012), ataskTempl_0.m_pLeaveRegion[num197].zvMin.Single_0[1].ToString(Class16.smethod_0(1648964192)));
								}
							}
							break;
						}
						case 2:
						{
							for (int num193 = 0; num193 < ataskTempl_0.m_pLeaveRegion.Length; num193++)
							{
								if (smethod_7(int_12, ataskTempl_0.m_pLeaveRegion[num193].zvMin.Single_0[2], double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6076, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5013), ataskTempl_0.m_pLeaveRegion[num193].zvMin.Single_0[2].ToString(Class16.smethod_0(1648964192)));
								}
							}
							break;
						}
						case 3:
						{
							for (int num196 = 0; num196 < ataskTempl_0.m_pLeaveRegion.Length; num196++)
							{
								if (smethod_7(int_12, ataskTempl_0.m_pLeaveRegion[num196].zvMax.Single_0[0], double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6076, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5014), ataskTempl_0.m_pLeaveRegion[num196].zvMax.Single_0[0].ToString(Class16.smethod_0(1648964192)));
								}
							}
							break;
						}
						case 4:
						{
							for (int num194 = 0; num194 < ataskTempl_0.m_pLeaveRegion.Length; num194++)
							{
								if (smethod_7(int_12, ataskTempl_0.m_pLeaveRegion[num194].zvMax.Single_0[1], double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6076, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5015), ataskTempl_0.m_pLeaveRegion[num194].zvMax.Single_0[1].ToString(Class16.smethod_0(1648964192)));
								}
							}
							break;
						}
						case 5:
						{
							for (int num192 = 0; num192 < ataskTempl_0.m_pLeaveRegion.Length; num192++)
							{
								if (smethod_7(int_12, ataskTempl_0.m_pLeaveRegion[num192].zvMax.Single_0[2], double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6076, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5016), ataskTempl_0.m_pLeaveRegion[num192].zvMax.Single_0[2].ToString(Class16.smethod_0(1648964192)));
								}
							}
							break;
						}
						}
					}
					else if (smethod_7(int_12, ataskTempl_0.m_ulLeaveRegionWorld, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6076, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1030), ataskTempl_0.m_ulLeaveRegionWorld.ToString());
					}
					continue;
				}
				if (num14 <= 60791257L)
				{
					if (num14 <= 60781250L)
					{
						if (num14 <= 60765556L)
						{
							switch (num14)
							{
							case 60765556L:
							{
								for (int num199 = 0; num199 < ataskTempl_0.m_pLeaveRegion.Length; num199++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pLeaveRegion[num199].RegionID, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6076, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(8010), ataskTempl_0.m_pLeaveRegion[num199].RegionID.ToString());
									}
								}
								break;
							}
							case 60765104L:
							{
								for (int num198 = 0; num198 < ataskTempl_0.m_pLeaveRegion.Length; num198++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pLeaveRegion[num198].MapID, double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6076, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5104), ataskTempl_0.m_pLeaveRegion[num198].MapID.ToString());
									}
								}
								break;
							}
							}
							continue;
						}
						long num200 = num14 - 60771033L;
						if ((ulong)num200 <= 3uL)
						{
							switch ((int)num200)
							{
							case 0:
								if (smethod_7(int_12, ataskTempl_0.m_ulTransWldId, double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1033), ataskTempl_0.m_ulTransWldId.ToString());
								}
								continue;
							case 1:
								if (smethod_7(int_12, ataskTempl_0.m_TransPt.Single_0[0], double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1649263678), ataskTempl_0.m_TransPt.Single_0[0].ToString(Class16.smethod_0(1648964192)));
								}
								continue;
							case 2:
								if (smethod_7(int_12, ataskTempl_0.m_TransPt.Single_0[1], double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1649263680), ataskTempl_0.m_TransPt.Single_0[1].ToString(Class16.smethod_0(1648964192)));
								}
								continue;
							case 3:
								if (smethod_7(int_12, ataskTempl_0.m_TransPt.Single_0[2], double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1649263690), ataskTempl_0.m_TransPt.Single_0[2].ToString(Class16.smethod_0(1648964192)));
								}
								continue;
							}
						}
						if (num14 == 60781250L && smethod_7(int_12, ataskTempl_0.m_ulReachSiteId, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6078, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1250), ataskTempl_0.m_ulReachSiteId.ToString());
						}
						continue;
					}
					if (num14 <= 60785104L)
					{
						long num201 = num14 - 60785011L;
						if ((ulong)num201 <= 5uL)
						{
							switch ((int)num201)
							{
							case 0:
							{
								for (int num205 = 0; num205 < ataskTempl_0.m_pReachSite.Length; num205++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pReachSite[num205].zvMin.Single_0[0], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6078, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5011), ataskTempl_0.m_pReachSite[num205].zvMin.Single_0[0].ToString(Class16.smethod_0(1648964192)));
									}
								}
								continue;
							}
							case 1:
							{
								for (int num207 = 0; num207 < ataskTempl_0.m_pReachSite.Length; num207++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pReachSite[num207].zvMin.Single_0[1], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6078, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5012), ataskTempl_0.m_pReachSite[num207].zvMin.Single_0[1].ToString(Class16.smethod_0(1648964192)));
									}
								}
								continue;
							}
							case 2:
							{
								for (int num203 = 0; num203 < ataskTempl_0.m_pReachSite.Length; num203++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pReachSite[num203].zvMin.Single_0[2], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6078, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5013), ataskTempl_0.m_pReachSite[num203].zvMin.Single_0[2].ToString(Class16.smethod_0(1648964192)));
									}
								}
								continue;
							}
							case 3:
							{
								for (int num206 = 0; num206 < ataskTempl_0.m_pReachSite.Length; num206++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pReachSite[num206].zvMax.Single_0[0], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6078, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5014), ataskTempl_0.m_pReachSite[num206].zvMax.Single_0[0].ToString(Class16.smethod_0(1648964192)));
									}
								}
								continue;
							}
							case 4:
							{
								for (int num204 = 0; num204 < ataskTempl_0.m_pReachSite.Length; num204++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pReachSite[num204].zvMax.Single_0[1], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6078, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5015), ataskTempl_0.m_pReachSite[num204].zvMax.Single_0[1].ToString(Class16.smethod_0(1648964192)));
									}
								}
								continue;
							}
							case 5:
							{
								for (int num202 = 0; num202 < ataskTempl_0.m_pReachSite.Length; num202++)
								{
									if (smethod_7(int_12, ataskTempl_0.m_pReachSite[num202].zvMax.Single_0[2], double_))
									{
										smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6078, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5016), ataskTempl_0.m_pReachSite[num202].zvMax.Single_0[2].ToString(Class16.smethod_0(1648964192)));
									}
								}
								continue;
							}
							}
						}
						if (num14 != 60785104L)
						{
							continue;
						}
						for (int num208 = 0; num208 < ataskTempl_0.m_pReachSite.Length; num208++)
						{
							if (smethod_7(int_12, ataskTempl_0.m_pReachSite[num208].MapID, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6078, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5104), ataskTempl_0.m_pReachSite[num208].MapID.ToString());
							}
						}
						continue;
					}
					if (num14 != 60785556L)
					{
						long num209 = num14 - 60791252L;
						if ((ulong)num209 > 5uL)
						{
							continue;
						}
						switch ((int)num209)
						{
						case 0:
							if (smethod_7(int_12, ataskTempl_0.m_TreasureStartZone.Single_0[0], double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6079, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1252), ataskTempl_0.m_TreasureStartZone.Single_0[0].ToString(Class16.smethod_0(1648964192)));
							}
							break;
						case 1:
							if (smethod_7(int_12, ataskTempl_0.m_TreasureStartZone.Single_0[1], double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6079, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1253), ataskTempl_0.m_TreasureStartZone.Single_0[1].ToString(Class16.smethod_0(1648964192)));
							}
							break;
						case 2:
							if (smethod_7(int_12, ataskTempl_0.m_TreasureStartZone.Single_0[2], double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6079, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1254), ataskTempl_0.m_TreasureStartZone.Single_0[2].ToString(Class16.smethod_0(1648964192)));
							}
							break;
						case 3:
							if (smethod_7(int_12, (int)ataskTempl_0.m_ucZonesNumX, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6079, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1255), ataskTempl_0.m_ucZonesNumX.ToString());
							}
							break;
						case 4:
							if (smethod_7(int_12, (int)ataskTempl_0.m_ucZonesNumZ, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6079, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1256), ataskTempl_0.m_ucZonesNumZ.ToString());
							}
							break;
						case 5:
							if (smethod_7(int_12, (int)ataskTempl_0.m_ucZoneSide, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6079, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1257), ataskTempl_0.m_ucZoneSide.ToString());
							}
							break;
						}
						continue;
					}
					for (int num210 = 0; num210 < ataskTempl_0.m_pReachSite.Length; num210++)
					{
						if (smethod_7(int_12, ataskTempl_0.m_pReachSite[num210].RegionID, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6078, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(8010), ataskTempl_0.m_pReachSite[num210].RegionID.ToString());
						}
					}
					continue;
				}
				if (num14 <= 60805104L)
				{
					if (num14 <= 60801258L)
					{
						switch (num14)
						{
						case 60801258L:
							if (smethod_7(int_12, ataskTempl_0.m_ulLeaveSiteId, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6080, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1258), ataskTempl_0.m_ulLeaveSiteId.ToString());
							}
							break;
						case 60791286L:
							if (smethod_7(int_12, ataskTempl_0.m_usZoneMapID, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6079, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1286), ataskTempl_0.m_usZoneMapID.ToString());
							}
							break;
						}
						continue;
					}
					long num211 = num14 - 60805011L;
					if ((ulong)num211 <= 5uL)
					{
						switch ((int)num211)
						{
						case 0:
						{
							for (int num215 = 0; num215 < ataskTempl_0.m_pLeaveSite.Length; num215++)
							{
								if (smethod_7(int_12, ataskTempl_0.m_pLeaveSite[num215].zvMin.Single_0[0], double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6080, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5011), ataskTempl_0.m_pLeaveSite[num215].zvMin.Single_0[0].ToString(Class16.smethod_0(1648964192)));
								}
							}
							continue;
						}
						case 1:
						{
							for (int num217 = 0; num217 < ataskTempl_0.m_pLeaveSite.Length; num217++)
							{
								if (smethod_7(int_12, ataskTempl_0.m_pLeaveSite[num217].zvMin.Single_0[1], double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6080, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5012), ataskTempl_0.m_pLeaveSite[num217].zvMin.Single_0[1].ToString(Class16.smethod_0(1648964192)));
								}
							}
							continue;
						}
						case 2:
						{
							for (int num213 = 0; num213 < ataskTempl_0.m_pLeaveSite.Length; num213++)
							{
								if (smethod_7(int_12, ataskTempl_0.m_pLeaveSite[num213].zvMin.Single_0[2], double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6080, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5013), ataskTempl_0.m_pLeaveSite[num213].zvMin.Single_0[2].ToString(Class16.smethod_0(1648964192)));
								}
							}
							continue;
						}
						case 3:
						{
							for (int num216 = 0; num216 < ataskTempl_0.m_pLeaveSite.Length; num216++)
							{
								if (smethod_7(int_12, ataskTempl_0.m_pLeaveSite[num216].zvMax.Single_0[0], double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6080, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5014), ataskTempl_0.m_pLeaveSite[num216].zvMax.Single_0[0].ToString(Class16.smethod_0(1648964192)));
								}
							}
							continue;
						}
						case 4:
						{
							for (int num214 = 0; num214 < ataskTempl_0.m_pLeaveSite.Length; num214++)
							{
								if (smethod_7(int_12, ataskTempl_0.m_pLeaveSite[num214].zvMax.Single_0[1], double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6080, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5015), ataskTempl_0.m_pLeaveSite[num214].zvMax.Single_0[1].ToString(Class16.smethod_0(1648964192)));
								}
							}
							continue;
						}
						case 5:
						{
							for (int num212 = 0; num212 < ataskTempl_0.m_pLeaveSite.Length; num212++)
							{
								if (smethod_7(int_12, ataskTempl_0.m_pLeaveSite[num212].zvMax.Single_0[2], double_))
								{
									smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6080, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5016), ataskTempl_0.m_pLeaveSite[num212].zvMax.Single_0[2].ToString(Class16.smethod_0(1648964192)));
								}
							}
							continue;
						}
						}
					}
					if (num14 != 60805104L)
					{
						continue;
					}
					for (int num218 = 0; num218 < ataskTempl_0.m_pLeaveSite.Length; num218++)
					{
						if (smethod_7(int_12, ataskTempl_0.m_pLeaveSite[num218].MapID, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6080, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5104), ataskTempl_0.m_pLeaveSite[num218].MapID.ToString());
						}
					}
					continue;
				}
				if (num14 <= 61871443L)
				{
					switch (num14)
					{
					case 61871443L:
						if (smethod_7(int_12, ataskTempl_0.PropMonsterSummoned.m_ulSummonRadius, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1443), mConvert.Int32ToString(ataskTempl_0.PropMonsterSummoned.m_ulSummonRadius));
						}
						break;
					case 60805556L:
					{
						for (int num219 = 0; num219 < ataskTempl_0.m_pLeaveSite.Length; num219++)
						{
							if (smethod_7(int_12, ataskTempl_0.m_pLeaveSite[num219].RegionID, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(6080, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(8010), ataskTempl_0.m_pLeaveSite[num219].RegionID.ToString());
							}
						}
						break;
					}
					}
					continue;
				}
				long num220 = num14 - 214005041L;
				if ((ulong)num220 <= 4uL)
				{
					switch ((int)num220)
					{
					case 0:
						if (smethod_7(int_12, ataskTempl_0.m_Prop1KeyValue_personal.nLeftType, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(21400, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041), ataskTempl_0.m_Prop1KeyValue_personal.nLeftType.ToString());
						}
						continue;
					case 1:
						if (smethod_7(int_12, ataskTempl_0.m_Prop1KeyValue_personal.lLeftNum, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(21400, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042), ataskTempl_0.m_Prop1KeyValue_personal.lLeftNum.ToString());
						}
						continue;
					case 2:
						if (smethod_7(int_12, ataskTempl_0.m_Prop1KeyValue_personal.nCompOper, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(21400, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043), ataskTempl_0.m_Prop1KeyValue_personal.nCompOper.ToString());
						}
						continue;
					case 3:
						if (smethod_7(int_12, ataskTempl_0.m_Prop1KeyValue_personal.nRightType, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(21400, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044), ataskTempl_0.m_Prop1KeyValue_personal.nRightType.ToString());
						}
						continue;
					case 4:
						if (smethod_7(int_12, ataskTempl_0.m_Prop1KeyValue_personal.lRightNum, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(21400, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045), ataskTempl_0.m_Prop1KeyValue_personal.lRightNum.ToString());
						}
						continue;
					}
				}
				long num221 = num14 - 214015041L;
				if ((ulong)num221 > 4uL)
				{
					continue;
				}
				switch ((int)num221)
				{
				case 0:
					if (smethod_7(int_12, ataskTempl_0.m_Prop2KeyValue_personal.nLeftType, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(21401, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5041), ataskTempl_0.m_Prop2KeyValue_personal.nLeftType.ToString());
					}
					break;
				case 1:
					if (smethod_7(int_12, ataskTempl_0.m_Prop2KeyValue_personal.lLeftNum, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(21401, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5042), ataskTempl_0.m_Prop2KeyValue_personal.lLeftNum.ToString());
					}
					break;
				case 2:
					if (smethod_7(int_12, ataskTempl_0.m_Prop2KeyValue_personal.nCompOper, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(21401, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5043), ataskTempl_0.m_Prop2KeyValue_personal.nCompOper.ToString());
					}
					break;
				case 3:
					if (smethod_7(int_12, ataskTempl_0.m_Prop2KeyValue_personal.nRightType, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(21401, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5044), ataskTempl_0.m_Prop2KeyValue_personal.nRightType.ToString());
					}
					break;
				case 4:
					if (smethod_7(int_12, ataskTempl_0.m_Prop2KeyValue_personal.lRightNum, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(21401, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5045), ataskTempl_0.m_Prop2KeyValue_personal.lRightNum.ToString());
					}
					break;
				}
			}
			break;
		}
		case 3:
		{
			string string_2 = string_1.ToString();
			for (int i = 0; i < list_0.Count; i++)
			{
				switch ((int)list_0[i])
				{
				case 1288:
					if (smethod_8(int_12, tasksConvert.ShortsToUnicodeString(ataskTempl_0.m_TaskEventName), string_2))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1288), tasksConvert.ShortsToUnicodeString(ataskTempl_0.m_TaskEventName));
					}
					break;
				case 1003:
					if (smethod_8(int_12, ataskTempl_0.Signature, string_2))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1003), ataskTempl_0.Signature);
					}
					break;
				case 1001:
					if (smethod_8(int_12, ataskTempl_0.Name, string_2))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1001), ataskTempl_0.Name);
					}
					break;
				case 10695020:
				{
					for (int k = 0; k < ataskTempl_0.m_pszPQExp.Length; k++)
					{
						if (smethod_8(int_12, tasksConvert.CharsToString(ataskTempl_0.m_pszPQExp[k]), string_2))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1069, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5020), tasksConvert.CharsToString(ataskTempl_0.m_pszPQExp[k]));
						}
					}
					break;
				}
				case 1700:
					if (smethod_8(int_12, ataskTempl_0.Descript, string_2))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1700), ataskTempl_0.Descript);
					}
					break;
				case 1701:
					if (smethod_8(int_12, ataskTempl_0.Tribute, string_2))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1701), ataskTempl_0.Tribute);
					}
					break;
				case 1702:
					if (smethod_8(int_12, ataskTempl_0.OkText, string_2))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1702), ataskTempl_0.OkText);
					}
					break;
				case 1703:
					if (smethod_8(int_12, ataskTempl_0.NoText, string_2))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1703), ataskTempl_0.NoText);
					}
					break;
				case 1326:
					if (smethod_8(int_12, tasksConvert.ShortsToGbkString(ataskTempl_0.m_szShowDialogName), string_2))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1326), tasksConvert.ShortsToGbkString(ataskTempl_0.m_szShowDialogName));
					}
					break;
				case 13775110:
				{
					for (int num2 = 0; num2 < ataskTempl_0.PersonExp.Length; num2++)
					{
						if (smethod_8(int_12, tasksConvert.CharsToString(ataskTempl_0.PersonExp[num2]), string_2))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1377, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5110), tasksConvert.CharsToString(ataskTempl_0.PersonExp[num2]));
						}
					}
					break;
				}
				case 12645067:
				{
					for (int num = 0; num < ataskTempl_0.m_pTaskChar.Length; num++)
					{
						if (smethod_8(int_12, tasksConvert.ShortsToUnicodeString(ataskTempl_0.m_pTaskChar[num]), string_2))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1264, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5067), tasksConvert.ShortsToUnicodeString(ataskTempl_0.m_pTaskChar[num]));
						}
					}
					break;
				}
				case 12635066:
				{
					for (int n = 0; n < ataskTempl_0.m_pszExp.Length; n++)
					{
						if (smethod_8(int_12, tasksConvert.CharsToString(ataskTempl_0.m_pszExp[n]), string_2))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1263, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5066), tasksConvert.CharsToString(ataskTempl_0.m_pszExp[n]));
						}
					}
					break;
				}
				case 13945113:
				{
					for (int m = 0; m < ataskTempl_0.HistoryTaskChar.Length; m++)
					{
						if (smethod_8(int_12, tasksConvert.ShortsToUnicodeString(ataskTempl_0.HistoryTaskChar[m]), string_2))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1394, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5113), tasksConvert.ShortsToUnicodeString(ataskTempl_0.HistoryTaskChar[m]));
						}
					}
					break;
				}
				case 13935112:
				{
					for (int l = 0; l < ataskTempl_0.HistoryExp.Length; l++)
					{
						if (smethod_8(int_12, tasksConvert.CharsToString(ataskTempl_0.HistoryExp[l]), string_2))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1393, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5112), tasksConvert.CharsToString(ataskTempl_0.HistoryExp[l]));
						}
					}
					break;
				}
				case 13785111:
				{
					for (int j = 0; j < ataskTempl_0.PersonTaskChar.Length; j++)
					{
						if (smethod_8(int_12, tasksConvert.ShortsToUnicodeString(ataskTempl_0.PersonTaskChar[j]), string_2))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1378, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5111), tasksConvert.ShortsToUnicodeString(ataskTempl_0.PersonTaskChar[j]));
						}
					}
					break;
				}
				}
			}
			break;
		}
		}
		if (arrayList_1.Count > 0)
		{
			for (int num222 = 0; num222 < arrayList_0.Count; num222++)
			{
				switch ((int)arrayList_0[num222])
				{
				case 3510:
					smethod_1(ref dataGridView_0, ataskTempl_0, ataskTempl_0.m_Award_S, int_12, int_13, arrayList_1, string_0, string_1, GProD.TX(3510) + Class16.smethod_0(1648908709));
					break;
				case 3511:
					smethod_1(ref dataGridView_0, ataskTempl_0, ataskTempl_0.m_Award_F, int_12, int_13, arrayList_1, string_0, string_1, GProD.TX(3511) + Class16.smethod_0(1648908709));
					break;
				case 3512:
				{
					for (int num226 = 0; num226 < ataskTempl_0.m_AwByRatio_S.m_Awards.Length; num226++)
					{
						smethod_1(ref dataGridView_0, ataskTempl_0, ataskTempl_0.m_AwByRatio_S.m_Awards[num226], int_12, int_13, arrayList_1, string_0, string_1, GProD.TX(3512) + Class16.smethod_0(1648942211) + (num226 + 1) + Class16.smethod_0(1648908709));
					}
					break;
				}
				case 3513:
				{
					for (int num231 = 0; num231 < ataskTempl_0.m_AwByRatio_F.m_Awards.Length; num231++)
					{
						smethod_1(ref dataGridView_0, ataskTempl_0, ataskTempl_0.m_AwByRatio_F.m_Awards[num231], int_12, int_13, arrayList_1, string_0, string_1, GProD.TX(3513) + Class16.smethod_0(1648942211) + (num231 + 1) + Class16.smethod_0(1648908709));
					}
					break;
				}
				case 3514:
				{
					for (int num228 = 0; num228 < ataskTempl_0.m_AwByItems_S.m_Awards.Length; num228++)
					{
						smethod_1(ref dataGridView_0, ataskTempl_0, ataskTempl_0.m_AwByItems_S.m_Awards[num228], int_12, int_13, arrayList_1, string_0, string_1, GProD.TX(3514) + Class16.smethod_0(1648942211) + (num228 + 1) + Class16.smethod_0(1648908709));
					}
					break;
				}
				case 3515:
				{
					for (int num224 = 0; num224 < ataskTempl_0.m_AwByItems_F.m_Awards.Length; num224++)
					{
						smethod_1(ref dataGridView_0, ataskTempl_0, ataskTempl_0.m_AwByItems_F.m_Awards[num224], int_12, int_13, arrayList_1, string_0, string_1, GProD.TX(3515) + Class16.smethod_0(1648942211) + (num224 + 1) + Class16.smethod_0(1648908709));
					}
					break;
				}
				case 3516:
				{
					for (int num232 = 0; num232 < ataskTempl_0.AwByTaskEventRatio_S.m_Awards.Length; num232++)
					{
						smethod_1(ref dataGridView_0, ataskTempl_0, ataskTempl_0.AwByTaskEventRatio_S.m_Awards[num232], int_12, int_13, arrayList_1, string_0, string_1, GProD.TX(3516) + Class16.smethod_0(1648942211) + (num232 + 1) + Class16.smethod_0(1648908709));
					}
					break;
				}
				case 3517:
				{
					for (int num230 = 0; num230 < ataskTempl_0.AwByTaskEventRatio_F.m_Awards.Length; num230++)
					{
						smethod_1(ref dataGridView_0, ataskTempl_0, ataskTempl_0.AwByTaskEventRatio_F.m_Awards[num230], int_12, int_13, arrayList_1, string_0, string_1, GProD.TX(3517) + Class16.smethod_0(1648942211) + (num230 + 1) + Class16.smethod_0(1648908709));
					}
					break;
				}
				case 3518:
				{
					for (int num229 = 0; num229 < ataskTempl_0.AwByCarrierHp_S.m_Awards.Length; num229++)
					{
						smethod_1(ref dataGridView_0, ataskTempl_0, ataskTempl_0.AwByCarrierHp_S.m_Awards[num229], int_12, int_13, arrayList_1, string_0, string_1, GProD.TX(3518) + Class16.smethod_0(1648942211) + (num229 + 1) + Class16.smethod_0(1648908709));
					}
					break;
				}
				case 3519:
				{
					for (int num227 = 0; num227 < ataskTempl_0.AwByCarrierHp_F.m_Awards.Length; num227++)
					{
						smethod_1(ref dataGridView_0, ataskTempl_0, ataskTempl_0.AwByCarrierHp_F.m_Awards[num227], int_12, int_13, arrayList_1, string_0, string_1, GProD.TX(3519) + Class16.smethod_0(1648942211) + (num227 + 1) + Class16.smethod_0(1648908709));
					}
					break;
				}
				case 3520:
				{
					for (int num225 = 0; num225 < ataskTempl_0.AwByVar_S.m_Awards.Length; num225++)
					{
						smethod_1(ref dataGridView_0, ataskTempl_0, ataskTempl_0.AwByVar_S.m_Awards[num225], int_12, int_13, arrayList_1, string_0, string_1, GProD.TX(3520) + Class16.smethod_0(1648942211) + (num225 + 1) + Class16.smethod_0(1648908709));
					}
					break;
				}
				case 3521:
				{
					for (int num223 = 0; num223 < ataskTempl_0.AwByVar_F.m_Awards.Length; num223++)
					{
						smethod_1(ref dataGridView_0, ataskTempl_0, ataskTempl_0.AwByVar_F.m_Awards[num223], int_12, int_13, arrayList_1, string_0, string_1, GProD.TX(3521) + Class16.smethod_0(1648942211) + (num223 + 1) + Class16.smethod_0(1648908709));
					}
					break;
				}
				}
			}
		}
		if (arrayList_3.Count <= 0)
		{
			return;
		}
		for (int num233 = 0; num233 < arrayList_2.Count; num233++)
		{
			switch ((int)arrayList_2[num233])
			{
			case 1704:
				smethod_2(ref dataGridView_0, ataskTempl_0, ataskTempl_0.m_DelvTaskTalk, int_12, int_13, arrayList_3, string_0, string_1, GProD.TX(1704) + Class16.smethod_0(1648908709));
				break;
			case 1705:
				smethod_2(ref dataGridView_0, ataskTempl_0, ataskTempl_0.m_UnqualifiedTaskTalk, int_12, int_13, arrayList_3, string_0, string_1, GProD.TX(1705) + Class16.smethod_0(1648908709));
				break;
			case 1706:
				smethod_2(ref dataGridView_0, ataskTempl_0, ataskTempl_0.m_DelvItemTalk, int_12, int_13, arrayList_3, string_0, string_1, GProD.TX(1706) + Class16.smethod_0(1648908709));
				break;
			case 1707:
				smethod_2(ref dataGridView_0, ataskTempl_0, ataskTempl_0.m_ExeTalk, int_12, int_13, arrayList_3, string_0, string_1, GProD.TX(1707) + Class16.smethod_0(1648908709));
				break;
			case 1708:
				smethod_2(ref dataGridView_0, ataskTempl_0, ataskTempl_0.m_AwardTalk, int_12, int_13, arrayList_3, string_0, string_1, GProD.TX(1708) + Class16.smethod_0(1648908709));
				break;
			}
		}
	}

	private static void smethod_1(ref DataGridView dataGridView_0, ATaskTempl ataskTempl_0, AWARD_DATA award_DATA_0, int int_12, int int_13, ArrayList arrayList_0, string string_0, string string_1, string string_2)
	{
		switch (int_13)
		{
		case 1:
		{
			bool bool_ = Convert.ToBoolean(Convert.ToDouble(string_1));
			for (int l = 0; l < arrayList_0.Count; l++)
			{
				switch ((int)arrayList_0[l])
				{
				case 1446:
					if (smethod_6(int_12, award_DATA_0.m_bAwardDeath, bool_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1446), mConvert.BS(award_DATA_0.m_bAwardDeath));
					}
					break;
				case 1447:
					if (smethod_6(int_12, award_DATA_0.m_bAwardDeathWithLoss, bool_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1447), mConvert.BS(award_DATA_0.m_bAwardDeathWithLoss));
					}
					break;
				case 1449:
					if (smethod_6(int_12, award_DATA_0.m_bAwardSkill, bool_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1449), mConvert.BS(award_DATA_0.m_bAwardSkill));
					}
					break;
				case 1433:
					if (smethod_6(int_12, award_DATA_0.m_bTrigCtrl, bool_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1433), mConvert.BS(award_DATA_0.m_bTrigCtrl));
					}
					break;
				case 1434:
					if (smethod_6(int_12, award_DATA_0.m_bUseLevCo, bool_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1434), mConvert.BS(award_DATA_0.m_bUseLevCo));
					}
					break;
				case 1435:
					if (smethod_6(int_12, award_DATA_0.m_bDivorce, bool_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1435), mConvert.BS(award_DATA_0.m_bDivorce));
					}
					break;
				case 1436:
					if (smethod_6(int_12, award_DATA_0.m_bSendMsg, bool_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1436), mConvert.BS(award_DATA_0.m_bSendMsg));
					}
					break;
				case 1415:
					if (smethod_6(int_12, award_DATA_0.m_bExpandRealmLevelMax, bool_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1415), mConvert.BS(award_DATA_0.m_bExpandRealmLevelMax));
					}
					break;
				case 1484:
					if (smethod_6(int_12, award_DATA_0.m_bCreateHome, bool_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1484), mConvert.BS(award_DATA_0.m_bCreateHome));
					}
					break;
				case 1465:
					if (smethod_6(int_12, award_DATA_0.m_bMulti, bool_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1465), mConvert.BS(award_DATA_0.m_bMulti));
					}
					break;
				case 1513:
					if (smethod_6(int_12, award_DATA_0.m_iAwardRedBookKey, bool_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1513), mConvert.BS(award_DATA_0.m_iAwardRedBookKey));
					}
					break;
				case 1485:
					if (smethod_6(int_12, award_DATA_0.m_bLeaveCarrier, bool_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1485), mConvert.BS(award_DATA_0.m_bLeaveCarrier));
					}
					break;
				case 14625077:
				{
					for (int num2 = 0; num2 < award_DATA_0.m_PQRankingAward.m_RankingAward.Length; num2++)
					{
						if (smethod_6(int_12, award_DATA_0.m_PQRankingAward.m_RankingAward[num2].m_bCommonItem, bool_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1462, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5077), mConvert.BS(award_DATA_0.m_PQRankingAward.m_RankingAward[num2].m_bCommonItem));
						}
					}
					break;
				}
				case 14415028:
				{
					for (int n = 0; n < award_DATA_0.m_CandItems.Length; n++)
					{
						for (int num = 0; num < award_DATA_0.m_CandItems[n].m_AwardItems.Length; num++)
						{
							if (smethod_6(int_12, award_DATA_0.m_CandItems[n].m_AwardItems[num].m_bCommonItem, bool_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1439, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1441, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5028), mConvert.BS(award_DATA_0.m_CandItems[n].m_AwardItems[num].m_bCommonItem));
							}
						}
					}
					break;
				}
				case 14391440:
				{
					for (int m = 0; m < award_DATA_0.m_CandItems.Length; m++)
					{
						if (smethod_6(int_12, award_DATA_0.m_CandItems[m].m_bRandChoose, bool_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1439, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1440), mConvert.BS(award_DATA_0.m_CandItems[m].m_bRandChoose));
						}
					}
					break;
				}
				case 60811444:
					if (smethod_6(int_12, award_DATA_0.m_SummonedMonsters.m_bDeathDisappear, bool_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1444), mConvert.BS(award_DATA_0.m_SummonedMonsters.m_bDeathDisappear));
					}
					break;
				case 60811442:
					if (smethod_6(int_12, award_DATA_0.m_SummonedMonsters.m_bRandChoose, bool_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1442), mConvert.BS(award_DATA_0.m_SummonedMonsters.m_bRandChoose));
					}
					break;
				case 61251489:
					if (smethod_6(int_12, award_DATA_0.m_bSubmitRankScore, bool_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6125, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1489), mConvert.BS(award_DATA_0.m_bSubmitRankScore));
					}
					break;
				case 60821461:
					if (smethod_6(int_12, award_DATA_0.m_PQRankingAward.m_bAwardByProf, bool_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1461), mConvert.BS(award_DATA_0.m_PQRankingAward.m_bAwardByProf));
					}
					break;
				}
			}
			break;
		}
		case 2:
		{
			double double_ = Convert.ToDouble(string_1);
			for (int num3 = 0; num3 < arrayList_0.Count; num3++)
			{
				switch ((int)arrayList_0[num3])
				{
				case 5648908:
					if (smethod_7(int_12, award_DATA_0.m_uiGroupNum, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + Class16.smethod_0(1649263708), mConvert.Int32ToString(award_DATA_0.m_uiGroupNum));
					}
					break;
				case 1412:
					if (smethod_7(int_12, award_DATA_0.m_ulGoldNum, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1412), mConvert.Int32ToString(award_DATA_0.m_ulGoldNum));
					}
					break;
				case 1413:
					if (smethod_7(int_12, award_DATA_0.m_ulExp, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1413), mConvert.Int32ToString(award_DATA_0.m_ulExp));
					}
					break;
				case 1414:
					if (smethod_7(int_12, award_DATA_0.m_ulRealmExp, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1414), mConvert.Int32ToString(award_DATA_0.m_ulRealmExp));
					}
					break;
				case 1416:
					if (smethod_7(int_12, award_DATA_0.m_ulNewTask, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1416), award_DATA_0.m_ulNewTask.ToString());
					}
					break;
				case 1417:
					if (smethod_7(int_12, award_DATA_0.m_ulSP, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1417), mConvert.Int32ToString(award_DATA_0.m_ulSP));
					}
					break;
				case 1418:
					if (smethod_7(int_12, award_DATA_0.m_lReputation, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1418), mConvert.Int32ToString(award_DATA_0.m_lReputation));
					}
					break;
				case 1419:
					if (smethod_7(int_12, award_DATA_0.m_ulNewPeriod, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1419), award_DATA_0.m_ulNewPeriod.ToString());
					}
					break;
				case 1420:
					if (smethod_7(int_12, award_DATA_0.m_ulNewRelayStation, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1420), award_DATA_0.m_ulNewRelayStation.ToString());
					}
					break;
				case 1421:
					if (smethod_7(int_12, award_DATA_0.m_ulStorehouseSize, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1421), mConvert.Int32ToString(award_DATA_0.m_ulStorehouseSize));
					}
					break;
				case 1422:
					if (smethod_7(int_12, award_DATA_0.m_ulStorehouseSize2, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1422), mConvert.Int32ToString(award_DATA_0.m_ulStorehouseSize2));
					}
					break;
				case 1423:
					if (smethod_7(int_12, award_DATA_0.m_ulStorehouseSize3, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1423), mConvert.Int32ToString(award_DATA_0.m_ulStorehouseSize3));
					}
					break;
				case 1424:
					if (smethod_7(int_12, award_DATA_0.m_ulStorehouseSize4, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1424), mConvert.Int32ToString(award_DATA_0.m_ulStorehouseSize4));
					}
					break;
				case 1425:
					if (smethod_7(int_12, award_DATA_0.m_lInventorySize, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1425), mConvert.Int32ToString(award_DATA_0.m_lInventorySize));
					}
					break;
				case 1426:
					if (smethod_7(int_12, award_DATA_0.m_ulPetInventorySize, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1426), mConvert.Int32ToString(award_DATA_0.m_ulPetInventorySize));
					}
					break;
				case 1427:
					if (smethod_7(int_12, award_DATA_0.m_ulFuryULimit, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1427), mConvert.Int32ToString(award_DATA_0.m_ulFuryULimit));
					}
					break;
				case 1432:
					if (smethod_7(int_12, award_DATA_0.m_lMonsCtrl, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1432), award_DATA_0.m_lMonsCtrl.ToString());
					}
					break;
				case 1437:
					if (smethod_7(int_12, award_DATA_0.m_nMsgChannel, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1437), award_DATA_0.m_nMsgChannel.ToString());
					}
					break;
				case 1438:
					if (smethod_7(int_12, award_DATA_0.m_ulCandItems, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1438), award_DATA_0.m_ulCandItems.ToString());
					}
					break;
				case 1448:
					if (smethod_7(int_12, award_DATA_0.m_ulDividend, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1448), mConvert.Int32ToSilver(award_DATA_0.m_ulDividend));
					}
					break;
				case 1450:
					if (smethod_7(int_12, award_DATA_0.m_iAwardSkillID, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1450), award_DATA_0.m_iAwardSkillID.ToString());
					}
					break;
				case 1451:
					if (smethod_7(int_12, award_DATA_0.m_iAwardSkillLevel, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1451), award_DATA_0.m_iAwardSkillLevel.ToString());
					}
					break;
				case 1452:
					if (smethod_7(int_12, award_DATA_0.m_iSoloTowerChallengeScore, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1452), mConvert.Int32ToString(award_DATA_0.m_iSoloTowerChallengeScore));
					}
					break;
				case 1453:
					if (smethod_7(int_12, award_DATA_0.m_ulSpecifyContribTaskID, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1453), award_DATA_0.m_ulSpecifyContribTaskID.ToString());
					}
					break;
				case 1454:
					if (smethod_7(int_12, award_DATA_0.m_ulSpecifyContribSubTaskID, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1454), award_DATA_0.m_ulSpecifyContribSubTaskID.ToString());
					}
					break;
				case 1455:
					if (smethod_7(int_12, award_DATA_0.m_ulSpecifyContrib, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1455), mConvert.Int32ToString(award_DATA_0.m_ulSpecifyContrib));
					}
					break;
				case 1456:
					if (smethod_7(int_12, award_DATA_0.m_ulContrib, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1456), mConvert.Int32ToString(award_DATA_0.m_ulContrib));
					}
					break;
				case 1457:
					if (smethod_7(int_12, award_DATA_0.m_ulRandContrib, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1457), mConvert.Int32ToString(award_DATA_0.m_ulRandContrib));
					}
					break;
				case 1458:
					if (smethod_7(int_12, award_DATA_0.m_ulLowestcontrib, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1458), mConvert.Int32ToString(award_DATA_0.m_ulLowestcontrib));
					}
					break;
				case 1459:
					if (smethod_7(int_12, award_DATA_0.m_iFactionContrib, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1459), mConvert.Int32ToString(award_DATA_0.m_iFactionContrib));
					}
					break;
				case 1460:
					if (smethod_7(int_12, award_DATA_0.m_iFactionExpContrib, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1460), mConvert.Int32ToString(award_DATA_0.m_iFactionExpContrib));
					}
					break;
				case 1466:
					if (smethod_7(int_12, award_DATA_0.m_nNumType, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1466), award_DATA_0.m_nNumType.ToString());
					}
					break;
				case 1467:
					if (smethod_7(int_12, award_DATA_0.m_lNum, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1467), mConvert.Int32ToString(award_DATA_0.m_lNum));
					}
					break;
				case 1471:
					if (smethod_7(int_12, award_DATA_0.m_iForceContribution, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1471), mConvert.Int32ToString(award_DATA_0.m_iForceContribution));
					}
					break;
				case 1472:
					if (smethod_7(int_12, award_DATA_0.m_iForceReputation, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1472), mConvert.Int32ToString(award_DATA_0.m_iForceReputation));
					}
					break;
				case 1473:
					if (smethod_7(int_12, award_DATA_0.m_iForceActivity, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1473), mConvert.Int32ToString(award_DATA_0.m_iForceActivity));
					}
					break;
				case 1474:
					if (smethod_7(int_12, award_DATA_0.m_iForceSetRepu, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1474), mConvert.Int32ToString(award_DATA_0.m_iForceSetRepu));
					}
					break;
				case 1475:
					if (smethod_7(int_12, award_DATA_0.m_iTaskLimit, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1475), mConvert.Int32ToString(award_DATA_0.m_iTaskLimit));
					}
					break;
				case 1477:
					if (smethod_7(int_12, award_DATA_0.m_iLeaderShip, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1477), mConvert.Int32ToString(award_DATA_0.m_iLeaderShip));
					}
					break;
				case 1478:
					if (smethod_7(int_12, award_DATA_0.m_iWorldContribution, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1478), mConvert.Int32ToString(award_DATA_0.m_iWorldContribution));
					}
					break;
				case 1479:
					if (smethod_7(int_12, award_DATA_0.m_iHomeResource[0], double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1479), mConvert.Int32ToString(award_DATA_0.m_iHomeResource[0]));
					}
					break;
				case 1480:
					if (smethod_7(int_12, award_DATA_0.m_iHomeResource[1], double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1480), mConvert.Int32ToString(award_DATA_0.m_iHomeResource[1]));
					}
					break;
				case 1481:
					if (smethod_7(int_12, award_DATA_0.m_iHomeResource[2], double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1481), mConvert.Int32ToString(award_DATA_0.m_iHomeResource[2]));
					}
					break;
				case 1482:
					if (smethod_7(int_12, award_DATA_0.m_iHomeResource[3], double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1482), mConvert.Int32ToString(award_DATA_0.m_iHomeResource[3]));
					}
					break;
				case 1483:
					if (smethod_7(int_12, award_DATA_0.m_iHomeResource[4], double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1483), mConvert.Int32ToString(award_DATA_0.m_iHomeResource[4]));
					}
					break;
				case 1486:
					if (smethod_7(int_12, award_DATA_0.m_faction_money, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1486), mConvert.Int32ToString(award_DATA_0.m_faction_money));
					}
					break;
				case 1487:
					if (smethod_7(int_12, award_DATA_0.m_faction_person_score, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1487), mConvert.Int32ToString(award_DATA_0.m_faction_person_score));
					}
					break;
				case 1493:
					if (smethod_7(int_12, award_DATA_0.NewTaskSpace, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1493), award_DATA_0.NewTaskSpace.ToString());
					}
					break;
				case 1494:
					if (smethod_7(int_12, award_DATA_0.m_iOpenSystem, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1494), mConvert.Int32ToString(award_DATA_0.m_iOpenSystem));
					}
					break;
				case 1495:
					if (smethod_7(int_12, award_DATA_0.m_iMentorStudentValue, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1495), mConvert.Int32ToString(award_DATA_0.m_iMentorStudentValue));
					}
					break;
				case 1496:
					if (smethod_7(int_12, award_DATA_0.m_iCoupleIntimacy, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1496), mConvert.Int32ToString(award_DATA_0.m_iCoupleIntimacy));
					}
					break;
				case 1498:
					if (smethod_7(int_12, award_DATA_0.m_ulRedBookExp, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1498), mConvert.Int32ToString(award_DATA_0.m_ulRedBookExp));
					}
					break;
				case 1499:
					if (smethod_7(int_12, award_DATA_0.m_iCampScore, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1499), mConvert.Int32ToString(award_DATA_0.m_iCampScore));
					}
					break;
				case 1500:
					if (smethod_7(int_12, award_DATA_0.m_iCrossServerMoney, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1500), mConvert.Int32ToString(award_DATA_0.m_iCrossServerMoney));
					}
					break;
				case 1501:
					if (smethod_7(int_12, award_DATA_0.m_iInviterAwardItem, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1501), award_DATA_0.m_iInviterAwardItem.ToString());
					}
					break;
				case 1502:
					if (smethod_7(int_12, award_DATA_0.m_iRewardFriendPoint, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1502), mConvert.Int32ToString(award_DATA_0.m_iRewardFriendPoint));
					}
					break;
				case 1503:
					if (smethod_7(int_12, award_DATA_0.m_iInviterAwardNum, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1503), mConvert.Int32ToString(award_DATA_0.m_iInviterAwardNum));
					}
					break;
				case 1505:
					if (smethod_7(int_12, award_DATA_0.m_iPerceptionVal, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1505), mConvert.Int32ToString(award_DATA_0.m_iPerceptionVal));
					}
					break;
				case 1506:
					if (smethod_7(int_12, award_DATA_0.m_iAwardRedBookKeyCount, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1506), award_DATA_0.m_iAwardRedBookKeyCount.ToString());
					}
					break;
				case 1507:
					if (smethod_7(int_12, award_DATA_0.m_iAwardRedBookKeyType, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1507), award_DATA_0.m_iAwardRedBookKeyType.ToString());
					}
					break;
				case 1508:
					if (smethod_7(int_12, award_DATA_0.m_ulPanguExp, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1508), award_DATA_0.m_ulPanguExp.ToString());
					}
					break;
				case 1509:
					if (smethod_7(int_12, award_DATA_0.m_ulPanguExpYear, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1509), award_DATA_0.m_ulPanguExpYear.ToString());
					}
					break;
				case 1510:
					if (smethod_7(int_12, award_DATA_0.m_iFactionAwardConfig, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1510), award_DATA_0.m_iFactionAwardConfig.ToString());
					}
					break;
				case 1511:
					if (smethod_7(int_12, award_DATA_0.m_iNewPlayerEvent, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1511), award_DATA_0.m_iNewPlayerEvent.ToString());
					}
					break;
				case 1512:
					if (smethod_7(int_12, (int)award_DATA_0.m_bRepairShentongSearchBug, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1512), award_DATA_0.m_bRepairShentongSearchBug.ToString());
					}
					break;
				case 14455071:
				{
					for (int num38 = 0; num38 < award_DATA_0.m_SummonedMonsters.m_Monsters.Length; num38++)
					{
						if (smethod_7(int_12, award_DATA_0.m_SummonedMonsters.m_Monsters[num38].m_ulMonsterTemplId, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1445, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5071), award_DATA_0.m_SummonedMonsters.m_Monsters[num38].m_ulMonsterTemplId.ToString());
						}
					}
					break;
				}
				case 14455072:
				{
					for (int num37 = 0; num37 < award_DATA_0.m_SummonedMonsters.m_Monsters.Length; num37++)
					{
						if (smethod_7(int_12, award_DATA_0.m_SummonedMonsters.m_Monsters[num37].m_ulMonsterNum, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1445, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5072), mConvert.Int32ToString(award_DATA_0.m_SummonedMonsters.m_Monsters[num37].m_ulMonsterNum));
						}
					}
					break;
				}
				case 14455073:
				{
					for (int num36 = 0; num36 < award_DATA_0.m_SummonedMonsters.m_Monsters.Length; num36++)
					{
						if (smethod_7(int_12, award_DATA_0.m_SummonedMonsters.m_Monsters[num36].m_fSummonProb, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1445, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5073), award_DATA_0.m_SummonedMonsters.m_Monsters[num36].m_fSummonProb.ToString(GProD.ProbValueFormat));
						}
					}
					break;
				}
				case 14455074:
				{
					for (int num35 = 0; num35 < award_DATA_0.m_SummonedMonsters.m_Monsters.Length; num35++)
					{
						if (smethod_7(int_12, award_DATA_0.m_SummonedMonsters.m_Monsters[num35].m_lPeriod, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1445, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5074), mConvert.SecondsToString(award_DATA_0.m_SummonedMonsters.m_Monsters[num35].m_lPeriod));
						}
					}
					break;
				}
				case 14415027:
				{
					for (int num33 = 0; num33 < award_DATA_0.m_CandItems.Length; num33++)
					{
						for (int num34 = 0; num34 < award_DATA_0.m_CandItems[num33].m_AwardItems.Length; num34++)
						{
							if (smethod_7(int_12, award_DATA_0.m_CandItems[num33].m_AwardItems[num34].m_ulItemTemplId, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1439, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1441, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5027), award_DATA_0.m_CandItems[num33].m_AwardItems[num34].m_ulItemTemplId.ToString());
							}
						}
					}
					break;
				}
				case 14415029:
				{
					for (int num31 = 0; num31 < award_DATA_0.m_CandItems.Length; num31++)
					{
						for (int num32 = 0; num32 < award_DATA_0.m_CandItems[num31].m_AwardItems.Length; num32++)
						{
							if (smethod_7(int_12, award_DATA_0.m_CandItems[num31].m_AwardItems[num32].m_ulItemNum, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1439, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1441, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5029), mConvert.Int32ToString(award_DATA_0.m_CandItems[num31].m_AwardItems[num32].m_ulItemNum));
							}
						}
					}
					break;
				}
				case 14415030:
				{
					for (int num29 = 0; num29 < award_DATA_0.m_CandItems.Length; num29++)
					{
						for (int num30 = 0; num30 < award_DATA_0.m_CandItems[num29].m_AwardItems.Length; num30++)
						{
							if (smethod_7(int_12, award_DATA_0.m_CandItems[num29].m_AwardItems[num30].m_fProb, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1439, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1441, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5030), award_DATA_0.m_CandItems[num29].m_AwardItems[num30].m_fProb.ToString(GProD.ProbValueFormat));
							}
						}
					}
					break;
				}
				case 14415031:
				{
					for (int num27 = 0; num27 < award_DATA_0.m_CandItems.Length; num27++)
					{
						for (int num28 = 0; num28 < award_DATA_0.m_CandItems[num27].m_AwardItems.Length; num28++)
						{
							if (smethod_7(int_12, (uint)award_DATA_0.m_CandItems[num27].m_AwardItems[num28].m_lPeriod, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1439, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1441, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5031), mConvert.SecondsToString(award_DATA_0.m_CandItems[num27].m_AwardItems[num28].m_lPeriod, 1));
							}
						}
					}
					break;
				}
				case 5648909:
					if (smethod_7(int_12, award_DATA_0.m_uiNumPerGroup, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + Class16.smethod_0(1649263730), mConvert.Int32ToString(award_DATA_0.m_uiNumPerGroup));
					}
					break;
				case 14635017:
				{
					for (int num26 = 0; num26 < award_DATA_0.m_plChangeKey.Length; num26++)
					{
						if (smethod_7(int_12, award_DATA_0.m_plChangeKey[num26], double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1463, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5017), award_DATA_0.m_plChangeKey[num26].ToString());
						}
					}
					break;
				}
				case 14635018:
				{
					for (int num25 = 0; num25 < award_DATA_0.m_plChangeKeyValue.Length; num25++)
					{
						if (smethod_7(int_12, award_DATA_0.m_plChangeKeyValue[num25], double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1463, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5018), award_DATA_0.m_plChangeKeyValue[num25].ToString());
						}
					}
					break;
				}
				case 14635019:
				{
					for (int num24 = 0; num24 < award_DATA_0.m_pbChangeType.Length; num24++)
					{
						if (smethod_7(int_12, Convert.ToInt32(award_DATA_0.m_pbChangeType[num24]), double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1463, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5019), Convert.ToInt32(award_DATA_0.m_pbChangeType[num24]).ToString());
						}
					}
					break;
				}
				case 14625075:
				{
					for (int num23 = 0; num23 < award_DATA_0.m_PQRankingAward.m_RankingAward.Length; num23++)
					{
						if (smethod_7(int_12, award_DATA_0.m_PQRankingAward.m_RankingAward[num23].m_iRankingStart, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1462, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5075), mConvert.Int32ToString(award_DATA_0.m_PQRankingAward.m_RankingAward[num23].m_iRankingStart));
						}
					}
					break;
				}
				case 14625076:
				{
					for (int num22 = 0; num22 < award_DATA_0.m_PQRankingAward.m_RankingAward.Length; num22++)
					{
						if (smethod_7(int_12, award_DATA_0.m_PQRankingAward.m_RankingAward[num22].m_iRankingEnd, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1462, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5076), mConvert.Int32ToString(award_DATA_0.m_PQRankingAward.m_RankingAward[num22].m_iRankingEnd));
						}
					}
					break;
				}
				case 14625078:
				{
					for (int num21 = 0; num21 < award_DATA_0.m_PQRankingAward.m_RankingAward.Length; num21++)
					{
						if (smethod_7(int_12, award_DATA_0.m_PQRankingAward.m_RankingAward[num21].m_ulAwardItemId, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1462, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5078), award_DATA_0.m_PQRankingAward.m_RankingAward[num21].m_ulAwardItemId.ToString());
						}
					}
					break;
				}
				case 14625079:
				{
					for (int num20 = 0; num20 < award_DATA_0.m_PQRankingAward.m_RankingAward.Length; num20++)
					{
						if (smethod_7(int_12, award_DATA_0.m_PQRankingAward.m_RankingAward[num20].m_ulAwardItemNum, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1462, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5079), mConvert.Int32ToString(award_DATA_0.m_PQRankingAward.m_RankingAward[num20].m_ulAwardItemNum));
						}
					}
					break;
				}
				case 14625080:
				{
					for (int num19 = 0; num19 < award_DATA_0.m_PQRankingAward.m_RankingAward.Length; num19++)
					{
						if (smethod_7(int_12, (uint)award_DATA_0.m_PQRankingAward.m_RankingAward[num19].m_lPeriod, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1462, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5080), mConvert.SecondsToString(award_DATA_0.m_PQRankingAward.m_RankingAward[num19].m_lPeriod, 1));
						}
					}
					break;
				}
				case 14695021:
				{
					for (int num17 = 0; num17 < award_DATA_0.m_pExpArr.Length; num17++)
					{
						for (int num18 = 0; num18 < 64; num18++)
						{
							if (smethod_7(int_12, award_DATA_0.m_pExpArr[num17][num18].type, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1469, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5021) + (num18 + 1), award_DATA_0.m_pExpArr[num17][num18].type.ToString());
							}
						}
					}
					break;
				}
				case 14685084:
				{
					for (int num16 = 0; num16 < award_DATA_0.m_plDisplayKey.Length; num16++)
					{
						if (smethod_7(int_12, award_DATA_0.m_plDisplayKey[num16], double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1468, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5084), award_DATA_0.m_plDisplayKey[num16].ToString());
						}
					}
					break;
				}
				case 14645081:
				{
					for (int num15 = 0; num15 < award_DATA_0.m_plHistoryChangeKey.Length; num15++)
					{
						if (smethod_7(int_12, award_DATA_0.m_plHistoryChangeKey[num15], double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1464, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5081), award_DATA_0.m_plHistoryChangeKey[num15].ToString());
						}
					}
					break;
				}
				case 14645082:
				{
					for (int num14 = 0; num14 < award_DATA_0.m_plHistoryChangeKeyValue.Length; num14++)
					{
						if (smethod_7(int_12, award_DATA_0.m_plHistoryChangeKeyValue[num14], double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1464, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5082), award_DATA_0.m_plHistoryChangeKeyValue[num14].ToString());
						}
					}
					break;
				}
				case 14645083:
				{
					for (int num13 = 0; num13 < award_DATA_0.m_pbHistoryChangeType.Length; num13++)
					{
						if (smethod_7(int_12, Convert.ToInt32(award_DATA_0.m_pbHistoryChangeType[num13]), double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1464, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5083), Convert.ToInt32(award_DATA_0.m_pbHistoryChangeType[num13]).ToString());
						}
					}
					break;
				}
				case 14765085:
				{
					for (int num12 = 0; num12 < award_DATA_0.m_pTitleAward.Length; num12++)
					{
						if (smethod_7(int_12, award_DATA_0.m_pTitleAward[num12].m_ulTitleID, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1476, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5085), award_DATA_0.m_pTitleAward[num12].m_ulTitleID.ToString());
						}
					}
					break;
				}
				case 14695022:
				{
					for (int num10 = 0; num10 < award_DATA_0.m_pExpArr.Length; num10++)
					{
						for (int num11 = 0; num11 < 64; num11++)
						{
							if (smethod_7(int_12, award_DATA_0.m_pExpArr[num10][num11].value, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1469, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5022) + (num11 + 1), award_DATA_0.m_pExpArr[num10][num11].value.ToString());
							}
						}
					}
					break;
				}
				case 14885098:
				{
					for (int num9 = 0; num9 < award_DATA_0.AwardFactionTargetData.Length; num9++)
					{
						if (smethod_7(int_12, award_DATA_0.AwardFactionTargetData[num9].FactionNum, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1488, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5098), mConvert.Int32ToString(award_DATA_0.AwardFactionTargetData[num9].FactionNum));
						}
					}
					break;
				}
				case 14885097:
				{
					for (int num8 = 0; num8 < award_DATA_0.AwardFactionTargetData.Length; num8++)
					{
						if (smethod_7(int_12, award_DATA_0.AwardFactionTargetData[num8].FactionTargetId, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1488, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5097), award_DATA_0.AwardFactionTargetData[num8].FactionTargetId.ToString());
						}
					}
					break;
				}
				case 14765086:
				{
					for (int num7 = 0; num7 < award_DATA_0.m_pTitleAward.Length; num7++)
					{
						if (smethod_7(int_12, (uint)award_DATA_0.m_pTitleAward[num7].m_lPeriod, double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1476, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5086), mConvert.SecondsToString(award_DATA_0.m_pTitleAward[num7].m_lPeriod, 1));
						}
					}
					break;
				}
				case 60771428:
					if (smethod_7(int_12, award_DATA_0.m_ulTransWldId, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1428), award_DATA_0.m_ulTransWldId.ToString());
					}
					break;
				case 60771429:
					if (smethod_7(int_12, award_DATA_0.m_TransPt.Single_0[0], double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1649263772), award_DATA_0.m_TransPt.Single_0[0].ToString(Class16.smethod_0(1648964192)));
					}
					break;
				case 60771430:
					if (smethod_7(int_12, award_DATA_0.m_TransPt.Single_0[1], double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1649263781), award_DATA_0.m_TransPt.Single_0[1].ToString(Class16.smethod_0(1648964192)));
					}
					break;
				case 60771431:
					if (smethod_7(int_12, award_DATA_0.m_TransPt.Single_0[2], double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1649263790), award_DATA_0.m_TransPt.Single_0[2].ToString(Class16.smethod_0(1648964192)));
					}
					break;
				case 15045107:
				{
					for (int num6 = 0; num6 < award_DATA_0.PersonChangeKey.Length; num6++)
					{
						if (smethod_7(int_12, award_DATA_0.PersonChangeKey[num6], double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1504, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5107), award_DATA_0.PersonChangeKey[num6].ToString());
						}
					}
					break;
				}
				case 15045108:
				{
					for (int num5 = 0; num5 < award_DATA_0.PersonChangeKeyValue.Length; num5++)
					{
						if (smethod_7(int_12, award_DATA_0.PersonChangeKeyValue[num5], double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1504, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5108), award_DATA_0.PersonChangeKeyValue[num5].ToString());
						}
					}
					break;
				}
				case 15045109:
				{
					for (int num4 = 0; num4 < award_DATA_0.PersonChangeType.Length; num4++)
					{
						if (smethod_7(int_12, Convert.ToInt32(award_DATA_0.PersonChangeType[num4]), double_))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1504, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5109), Convert.ToInt32(award_DATA_0.PersonChangeType[num4]).ToString());
						}
					}
					break;
				}
				case 61251490:
					if (smethod_7(int_12, award_DATA_0.submit_rank.m_iSubmitType, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6125, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1490), award_DATA_0.submit_rank.m_iSubmitType.ToString());
					}
					break;
				case 61251491:
					if (smethod_7(int_12, award_DATA_0.submit_rank.m_iRankID, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6125, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1491), award_DATA_0.submit_rank.m_iRankID.ToString());
					}
					break;
				case 61251492:
					if (smethod_7(int_12, award_DATA_0.submit_rank.m_iTempRankID, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6125, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1492), mConvert.Int32ToString(award_DATA_0.submit_rank.m_iTempRankID));
					}
					break;
				case 60811443:
					if (smethod_7(int_12, award_DATA_0.m_SummonedMonsters.m_ulSummonRadius, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1443), mConvert.Int32ToString(award_DATA_0.m_SummonedMonsters.m_ulSummonRadius));
					}
					break;
				case 60771497:
					if (smethod_7(int_12, award_DATA_0.m_ulCrossServerWldId, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1497), award_DATA_0.m_ulCrossServerWldId.ToString());
					}
					break;
				}
			}
			break;
		}
		case 3:
		{
			string string_3 = string_1.ToString();
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				switch ((int)arrayList_0[i])
				{
				case 14705067:
				{
					for (int k = 0; k < award_DATA_0.m_pTaskChar.Length; k++)
					{
						if (smethod_8(int_12, tasksConvert.ShortsToGbkString(award_DATA_0.m_pTaskChar[k]), string_3))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1470, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5067), tasksConvert.ShortsToGbkString(award_DATA_0.m_pTaskChar[k]));
						}
					}
					break;
				}
				case 14695066:
				{
					for (int j = 0; j < award_DATA_0.m_pExpArr.Length; j++)
					{
						if (smethod_8(int_12, tasksConvert.CharsToString(award_DATA_0.m_pszExp[j]), string_3))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1469, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5066), tasksConvert.CharsToString(award_DATA_0.m_pszExp[j]));
						}
					}
					break;
				}
				}
			}
			break;
		}
		}
	}

	private static void smethod_2(ref DataGridView dataGridView_0, ATaskTempl ataskTempl_0, talk_proc talk_proc_0, int int_12, int int_13, ArrayList arrayList_0, string string_0, string string_1, string string_2)
	{
		switch (int_13)
		{
		case 2:
		{
			double double_ = Convert.ToDouble(string_1);
			for (int m = 0; m < arrayList_0.Count; m++)
			{
				switch ((int)arrayList_0[m])
				{
				case 1719:
				{
					for (int n = 0; n < talk_proc_0.windows.Length; n++)
					{
						for (int num = 0; num < talk_proc_0.windows[n].options.Length; num++)
						{
							if (smethod_7(int_12, talk_proc_0.windows[n].options[num].id, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1711, appendsymbols: true) + Class16.smethod_0(1648942211) + (n + 1) + Class16.smethod_0(1648908709) + GProD.TX(1715) + Class16.smethod_0(1648942211) + (num + 1) + Class16.smethod_0(1648908709) + GProD.TX(1719), talk_proc_0.windows[n].options[num].id.ToString());
							}
						}
					}
					break;
				}
				case 1716:
				{
					for (int num2 = 0; num2 < talk_proc_0.windows.Length; num2++)
					{
						for (int num3 = 0; num3 < talk_proc_0.windows[num2].options.Length; num3++)
						{
							if (smethod_7(int_12, talk_proc_0.windows[num2].options[num3].param, double_))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1711, appendsymbols: true) + Class16.smethod_0(1648942211) + (num2 + 1) + Class16.smethod_0(1648908709) + GProD.TX(1715) + Class16.smethod_0(1648942211) + (num3 + 1) + Class16.smethod_0(1648908709) + GProD.TX(1716), talk_proc_0.windows[num2].options[num3].param.ToString());
							}
						}
					}
					break;
				}
				case 1709:
					if (smethod_7(int_12, talk_proc_0.id_talk, double_))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1709), talk_proc_0.id_talk.ToString());
					}
					break;
				}
			}
			break;
		}
		case 3:
		{
			string string_3 = string_1.ToString();
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				switch ((int)arrayList_0[i])
				{
				case 1718:
				{
					for (int j = 0; j < talk_proc_0.windows.Length; j++)
					{
						for (int k = 0; k < talk_proc_0.windows[j].options.Length; k++)
						{
							if (smethod_8(int_12, talk_proc_0.windows[j].options[k].optiontext, string_3))
							{
								smethod_5(ref dataGridView_0, ataskTempl_0, GProD.TX(1704, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1711) + Class16.smethod_0(1648942211) + (j + 1) + Class16.smethod_0(1648908709) + GProD.TX(1715) + Class16.smethod_0(1648942211) + (k + 1) + Class16.smethod_0(1648908709) + GProD.TX(1718), talk_proc_0.windows[j].options[k].optiontext);
							}
						}
					}
					break;
				}
				case 1714:
				{
					for (int l = 0; l < talk_proc_0.windows.Length; l++)
					{
						if (smethod_8(int_12, talk_proc_0.windows[l].talktext, string_3))
						{
							smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1711) + Class16.smethod_0(1648942211) + (l + 1) + Class16.smethod_0(1648908709) + GProD.TX(1714), talk_proc_0.windows[l].talktext);
						}
					}
					break;
				}
				case 1710:
					if (smethod_8(int_12, talk_proc_0.DialogText, string_3))
					{
						smethod_5(ref dataGridView_0, ataskTempl_0, string_2 + GProD.TX(1710), talk_proc_0.DialogText);
					}
					break;
				}
			}
			break;
		}
		}
	}

	private static string smethod_3(string string_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return string.Empty;
		}
		return string_0.Replace('\u00a0', ' ').Replace('?', ' ').ToLowerInvariant();
	}

	private static void smethod_4(ref DataGridView dataGridView_0, ATaskTempl ataskTempl_0, int int_12, int int_13, List<long> list_0, ArrayList arrayList_0, ArrayList arrayList_1, ArrayList arrayList_2, ArrayList arrayList_3, string string_0, string string_1)
	{
		for (int i = 0; i < ataskTempl_0.m_nSubCount; i++)
		{
			smethod_0(ref dataGridView_0, ataskTempl_0.pSub[i], int_12, int_13, list_0, arrayList_0, arrayList_1, arrayList_2, arrayList_3, string_0, string_1);
			if (ataskTempl_0.pSub[i].m_nSubCount > 0)
			{
				smethod_4(ref dataGridView_0, ataskTempl_0.pSub[i], int_12, int_13, list_0, arrayList_0, arrayList_1, arrayList_2, arrayList_3, string_0, string_1);
			}
		}
	}

	private static void smethod_5(ref DataGridView dataGridView_0, ATaskTempl ataskTempl_0, string string_0, string string_1)
	{
		object[] values = new object[6]
		{
			ataskTempl_0.m_usIDSpace.ToString(),
			ataskTempl_0.m_ID.ToString(),
			ACE.sTASKedit.Classes.Extensions.Extensions.GetIcon(ataskTempl_0),
			GlobalFunctions.ColorClean(ataskTempl_0.Name),
			string_0,
			string_1
		};
		dataGridView_0.Rows.Add(values);
		dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].HeaderCell.Value = dataGridView_0.Rows.Count.ToString();
		dataGridView_0.Rows[dataGridView_0.Rows.Count - 1].Cells[3].Style.ForeColor = ACE.sTASKedit.Classes.Extensions.Extensions.GetColor(ataskTempl_0);
	}

	private static bool smethod_6(int int_12, bool bool_0, bool bool_1)
	{
		bool result = false;
		switch (int_12)
		{
		case 0:
			if (bool_0 == bool_1)
			{
				result = true;
			}
			break;
		case 1:
			if (bool_0 != bool_1)
			{
				return true;
			}
			break;
		}
		return result;
	}

	private static bool smethod_7(int int_12, double double_0, double double_1)
	{
		return int_12 switch
		{
			0 => double_0 == double_1, 
			1 => double_0 != double_1, 
			3 => double_0 > double_1, 
			4 => double_0 < double_1, 
			_ => false, 
		};
	}

	private static bool smethod_8(int int_12, string string_0, string string_1)
	{
		bool result = false;
		switch (int_12)
		{
		case 0:
			if (TextSearchHelper.Equals(string_0, string_1))
			{
				return true;
			}
			break;
		case 1:
			if (!TextSearchHelper.Equals(string_0, string_1))
			{
				return true;
			}
			break;
		case 2:
			if (TextSearchHelper.Contains(string_0, string_1))
			{
				return true;
			}
			break;
		}
		return result;
	}

	private static bool smethod_9(int int_12, bool bool_0, ATaskTemplFixedData ataskTemplFixedData_0, int int_13)
	{
		bool result = false;
		switch (int_12)
		{
		case 0:
			if (bool_0)
			{
				if (ataskTemplFixedData_0.m_ulOccupations <= 0)
				{
					break;
				}
				for (int k = 0; k < ataskTemplFixedData_0.m_Occupations.Length && k < ataskTemplFixedData_0.m_ulOccupations; k++)
				{
					if (ataskTemplFixedData_0.m_Occupations[k] == int_13)
					{
						return true;
					}
				}
				break;
			}
			if (ataskTemplFixedData_0.m_ulOccupations > 0)
			{
				result = true;
				for (int l = 0; l < ataskTemplFixedData_0.m_Occupations.Length && l < ataskTemplFixedData_0.m_ulOccupations; l++)
				{
					if (ataskTemplFixedData_0.m_Occupations[l] == int_13)
					{
						return false;
					}
				}
				break;
			}
			return true;
		case 1:
			if (bool_0)
			{
				if (ataskTemplFixedData_0.m_ulOccupations <= 0)
				{
					return true;
				}
				result = true;
				for (int i = 0; i < ataskTemplFixedData_0.m_Occupations.Length && i < ataskTemplFixedData_0.m_ulOccupations; i++)
				{
					if (ataskTemplFixedData_0.m_Occupations[i] == int_13)
					{
						return false;
					}
				}
			}
			else
			{
				if (ataskTemplFixedData_0.m_ulOccupations <= 0)
				{
					break;
				}
				for (int j = 0; j < ataskTemplFixedData_0.m_Occupations.Length && j < ataskTemplFixedData_0.m_ulOccupations; j++)
				{
					if (ataskTemplFixedData_0.m_Occupations[j] == int_13)
					{
						return true;
					}
				}
			}
			break;
		}
		return result;
	}

	public static List<string> CreateParametersTable(int parametertype, string string_0)
	{
		Class396 @class = new Class396();
		@class.list_0 = new List<string>();
		ArrayList arrayList_ = smethod_10(string_0);
		ArrayList arrayList_2 = smethod_11(string_0);
		switch (parametertype)
		{
		case 1:
			smethod_12(string_0, @class.method_0, arrayList_);
			break;
		case 2:
			smethod_15(string_0, @class.method_0, arrayList_, arrayList_2);
			break;
		case 3:
			smethod_22(string_0, @class.method_0, arrayList_, arrayList_2);
			break;
		}
		return @class.list_0;
	}

	private static ArrayList smethod_10(string string_0)
	{
		ArrayList arrayList = new ArrayList { string.Empty };
		int[] array = int_10;
		foreach (int key in array)
		{
			if (smethod_3(string_0).Contains(smethod_3(GProD.TX(key))))
			{
				arrayList.Add(GProD.TX(key, appendsymbols: true) + Class16.smethod_0(1648942211));
			}
		}
		if (arrayList.Count == 1 && arrayList[0].ToString() == string.Empty)
		{
			int[] array2 = int_10;
			foreach (int key2 in array2)
			{
				arrayList.Add(GProD.TX(key2, appendsymbols: true) + Class16.smethod_0(1648942211));
			}
		}
		return arrayList;
	}

	private static ArrayList smethod_11(string string_0)
	{
		ArrayList arrayList = new ArrayList { string.Empty };
		int[] array = int_11;
		foreach (int key in array)
		{
			if (smethod_3(string_0).Contains(smethod_3(GProD.TX(key))))
			{
				arrayList.Add(GProD.TX(key, appendsymbols: true) + Class16.smethod_0(1648942211));
			}
		}
		if (arrayList.Count == 1 && arrayList[0].ToString() == string.Empty)
		{
			int[] array2 = int_11;
			foreach (int key2 in array2)
			{
				arrayList.Add(GProD.TX(key2, appendsymbols: true) + Class16.smethod_0(1648942211));
			}
		}
		return arrayList;
	}

	private static void smethod_12(string string_0, Action<string> action_0, ArrayList arrayList_0)
	{
		(int, int?)[] array = new(int, int?)[15]
		{
			(6074, 1025),
			(6075, 1027),
			(6076, 1029),
			(1031, null),
			(6077, 1032),
			(6187, 1442),
			(6187, 1444),
			(1099, 5028),
			(1102, 5028),
			(1240, 5050),
			(1240, 5087),
			(1241, 5061),
			(1241, 5063),
			(1280, null),
			(1242, 5028)
		};
		(int, int?)[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			(int, int?) tuple = array2[i];
			int item = tuple.Item1;
			int? item2 = tuple.Item2;
			string text = (item2.HasValue ? (GProD.TX(item, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(item2.Value, appendsymbols: true)) : GProD.TX(item, appendsymbols: true));
			if (smethod_24(text, string_0))
			{
				action_0(text);
			}
		}
		smethod_23(int_3.Concat(int_2).ToArray(), string_0, action_0, string.Empty);
		smethod_13(string_0, action_0, arrayList_0);
	}

	private static void smethod_13(string string_0, Action<string> action_0, ArrayList arrayList_0)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			string text = arrayList_0[i].ToString();
			smethod_23(int_5, string_0, action_0, text);
			smethod_14(text, string_0, action_0);
		}
	}

	private static void smethod_14(string string_0, string string_1, Action<string> action_0)
	{
		(int[], int[])[] array = new(int[], int[])[7]
		{
			(new int[1] { 1439 }, new int[1] { 1440 }),
			(new int[2] { 1439, 1441 }, new int[1] { 5028 }),
			(new int[1] { 6081 }, new int[1] { 1442 }),
			(new int[1] { 6081 }, new int[1] { 1444 }),
			(new int[1] { 6082 }, new int[1] { 1461 }),
			(new int[2] { 6082, 1462 }, new int[1] { 5077 }),
			(new int[1] { 6125 }, new int[1] { 1489 })
		};
		(int[], int[])[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			(int[], int[]) tuple = array2[i];
			int[] item = tuple.Item1;
			int[] item2 = tuple.Item2;
			string text = string.Join(Class16.smethod_0(1648942211), item.Select(Class395.class395_0.method_0));
			string text2 = string.Join(Class16.smethod_0(1648942211), item2.Select(Class395.class395_0.method_1));
			string text3 = string_0 + text + Class16.smethod_0(1648942211) + text2;
			if (smethod_24(text3, string_1))
			{
				action_0(text3);
			}
		}
	}

	private static void smethod_15(string string_0, Action<string> action_0, ArrayList arrayList_0, ArrayList arrayList_1)
	{
		smethod_16(string_0, action_0);
		smethod_17(string_0, action_0);
		smethod_18(string_0, action_0);
		smethod_19(string_0, action_0, arrayList_0);
		smethod_21(string_0, action_0, arrayList_1);
	}

	private static void smethod_16(string string_0, Action<string> action_0)
	{
		int[] array = new int[6] { 1008, 1348, 6072, 6073, 1350, 1154 };
		int[] array2 = array;
		foreach (int key in array2)
		{
			int[] array3 = int_0;
			foreach (int key2 in array3)
			{
				string text = GProD.TX(key, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(key2);
				if (smethod_24(text, string_0))
				{
					action_0(text);
				}
			}
		}
	}

	private static void smethod_17(string string_0, Action<string> action_0)
	{
		smethod_23(int_2.Concat(int_4).ToArray(), string_0, action_0, string.Empty);
	}

	private static void smethod_18(string string_0, Action<string> action_0)
	{
		int[] array = new int[6] { 6074, 6075, 6076, 6078, 6079, 6080 };
		int[] array2 = array;
		foreach (int key in array2)
		{
			int[] array3 = int_1;
			foreach (int key2 in array3)
			{
				string text = GProD.TX(key, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(key2);
				if (smethod_24(text, string_0))
				{
					action_0(text);
				}
			}
		}
	}

	private static void smethod_19(string string_0, Action<string> action_0, ArrayList arrayList_0)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			string text = arrayList_0[i].ToString();
			smethod_23(int_6, string_0, action_0, text);
			smethod_20(text, string_0, action_0);
		}
	}

	private static void smethod_20(string string_0, string string_1, Action<string> action_0)
	{
		int[] array = new int[2] { 1428, 1497 };
		int[] array2 = array;
		foreach (int key in array2)
		{
			string text = string_0 + GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(key);
			if (smethod_24(text, string_1))
			{
				action_0(text);
			}
		}
		string[] array3 = new string[3]
		{
			Class16.smethod_0(1649263678),
			Class16.smethod_0(1649263680),
			Class16.smethod_0(1649263690)
		};
		string[] array4 = array3;
		foreach (string text2 in array4)
		{
			string text3 = string_0 + GProD.TX(6077, appendsymbols: true) + text2;
			if (smethod_24(text3, string_1))
			{
				action_0(text3);
			}
		}
		int[] array5 = new int[4] { 5027, 5029, 5030, 5031 };
		int[] array6 = array5;
		foreach (int key2 in array6)
		{
			string text4 = string_0 + GProD.TX(1439, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1441, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(key2);
			if (smethod_24(text4, string_1))
			{
				action_0(text4);
			}
		}
		string text5 = string_0 + GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1443);
		if (smethod_24(text5, string_1))
		{
			action_0(text5);
		}
		int[] array7 = new int[4] { 5071, 5072, 5073, 5074 };
		int[] array8 = array7;
		foreach (int key3 in array8)
		{
			string text6 = string_0 + GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1445, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(key3);
			if (smethod_24(text6, string_1))
			{
				action_0(text6);
			}
		}
		int[] array9 = new int[5] { 5075, 5076, 5078, 5079, 5080 };
		int[] array10 = array9;
		foreach (int key4 in array10)
		{
			string text7 = string_0 + GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1462, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(key4);
			if (smethod_24(text7, string_1))
			{
				action_0(text7);
			}
		}
		int[] array11 = new int[3] { 5017, 5018, 5019 };
		int[] array12 = array11;
		foreach (int key5 in array12)
		{
			string text8 = string_0 + GProD.TX(1463, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(key5);
			if (smethod_24(text8, string_1))
			{
				action_0(text8);
			}
		}
		int[] array13 = new int[3] { 5107, 5108, 5109 };
		int[] array14 = array13;
		foreach (int key6 in array14)
		{
			string text9 = string_0 + GProD.TX(1504, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(key6);
			if (smethod_24(text9, string_1))
			{
				action_0(text9);
			}
		}
		int[] array15 = new int[3] { 5081, 5082, 5083 };
		int[] array16 = array15;
		foreach (int key7 in array16)
		{
			string text10 = string_0 + GProD.TX(1464, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(key7);
			if (smethod_24(text10, string_1))
			{
				action_0(text10);
			}
		}
		string text11 = string_0 + GProD.TX(1468, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5084);
		if (smethod_24(text11, string_1))
		{
			action_0(text11);
		}
		string text12 = string_0 + GProD.TX(1469, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5021);
		if (smethod_24(text12, string_1))
		{
			action_0(text12);
		}
		string text13 = string_0 + GProD.TX(1469, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5022);
		if (smethod_24(text13, string_1))
		{
			action_0(text13);
		}
		int[] array17 = new int[2] { 5085, 5086 };
		int[] array18 = array17;
		foreach (int key8 in array18)
		{
			string text14 = string_0 + GProD.TX(1476, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(key8);
			if (smethod_24(text14, string_1))
			{
				action_0(text14);
			}
		}
		int[] array19 = new int[2] { 5097, 5098 };
		int[] array20 = array19;
		foreach (int key9 in array20)
		{
			string text15 = string_0 + GProD.TX(1488, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(key9);
			if (smethod_24(text15, string_1))
			{
				action_0(text15);
			}
		}
		int[] array21 = new int[3] { 1490, 1491, 1492 };
		int[] array22 = array21;
		foreach (int key10 in array22)
		{
			string text16 = string_0 + GProD.TX(6125, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(key10);
			if (smethod_24(text16, string_1))
			{
				action_0(text16);
			}
		}
		string text17 = string_0 + Class16.smethod_0(1649263708);
		if (smethod_24(text17, string_1))
		{
			action_0(text17);
		}
		string text18 = string_0 + Class16.smethod_0(1649263730);
		if (smethod_24(text18, string_1))
		{
			action_0(text18);
		}
	}

	private static void smethod_21(string string_0, Action<string> action_0, ArrayList arrayList_0)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			string text = arrayList_0[i].ToString();
			smethod_23(int_7, string_0, action_0, text);
			string text2 = text + GProD.TX(1715, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1719);
			if (smethod_24(text2, string_0))
			{
				action_0(text2);
			}
		}
	}

	private static void smethod_22(string string_0, Action<string> action_0, ArrayList arrayList_0, ArrayList arrayList_1)
	{
		smethod_23(int_9, string_0, action_0, string.Empty);
		(int, int)[] array = new(int, int)[7]
		{
			(1069, 5020),
			(1263, 5066),
			(1377, 5110),
			(1393, 5112),
			(1264, 5067),
			(1378, 5111),
			(1394, 5113)
		};
		(int, int)[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			(int, int) tuple = array2[i];
			int item = tuple.Item1;
			int item2 = tuple.Item2;
			string text = GProD.TX(item, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(item2);
			if (smethod_24(text, string_0))
			{
				action_0(text);
			}
		}
		for (int j = 0; j < arrayList_0.Count; j++)
		{
			string text2 = arrayList_0[j].ToString();
			(int, int)[] array3 = new(int, int)[2]
			{
				(1469, 5066),
				(1470, 5067)
			};
			(int, int)[] array4 = array3;
			for (int k = 0; k < array4.Length; k++)
			{
				(int, int) tuple2 = array4[k];
				int item3 = tuple2.Item1;
				int item4 = tuple2.Item2;
				string text3 = text2 + GProD.TX(item3, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(item4);
				if (smethod_24(text3, string_0))
				{
					action_0(text3);
				}
			}
		}
		for (int l = 0; l < arrayList_1.Count; l++)
		{
			string string_1 = arrayList_1[l].ToString();
			smethod_23(int_8, string_0, action_0, string_1);
		}
	}

	private static void smethod_23(int[] int_12, string string_0, Action<string> action_0, string string_1)
	{
		foreach (int key in int_12)
		{
			string string_2 = string_1 + GProD.TX(key, appendsymbols: true);
			if (smethod_24(string_2, string_0))
			{
				action_0(string_1 + GProD.TX(key));
			}
		}
	}

	private static bool smethod_24(string string_0, string string_1)
	{
		return smethod_3(string_0).Contains(smethod_3(string_1));
	}

	public static void Search(ref ToolStripProgressBar toolStripProgressBar_Progress, ref DataGridView dataGridView_ExtendedSearchResult, ATaskTempl[] tasks, int comparetype, int parametertype, string parametername, string parametervalue)
	{
		smethod_25(toolStripProgressBar_Progress, tasks.Length);
		Class394 @class = new Class394();
		@class.method_1(new List<long>());
		@class.method_3(new ArrayList());
		@class.method_5(new ArrayList());
		@class.method_7(new ArrayList());
		@class.method_9(new ArrayList());
		Class394 class394_ = @class;
		smethod_26(parametername, class394_);
		smethod_27(parametername, class394_);
		smethod_28(parametertype, parametername, class394_);
		smethod_49(tasks, dataGridView_ExtendedSearchResult, toolStripProgressBar_Progress, comparetype, parametertype, parametername, parametervalue, class394_);
		toolStripProgressBar_Progress.Value = 0;
	}

	private static void smethod_25(ToolStripProgressBar toolStripProgressBar_0, int int_12)
	{
		ToolStripProgressBarSafe.TrySet(toolStripProgressBar_0, int_12, 0);
	}

	private static void smethod_26(string string_0, Class394 class394_0)
	{
		int[] array = int_10;
		foreach (int num in array)
		{
			if (string_0.Contains(GProD.TX(num).ToLower()))
			{
				class394_0.method_6().Add(num);
			}
		}
		if (class394_0.method_6().Count == 0)
		{
			class394_0.method_11(bool_2: true);
			int[] array2 = int_10;
			foreach (int num2 in array2)
			{
				class394_0.method_6().Add(num2);
			}
		}
	}

	private static void smethod_27(string string_0, Class394 class394_0)
	{
		bool flag = false;
		int[] array = int_11;
		foreach (int num in array)
		{
			if (string_0.Contains(GProD.TX(num).ToLower()))
			{
				class394_0.method_8().Add(num);
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			class394_0.method_13(bool_2: true);
			int[] array2 = int_11;
			foreach (int num2 in array2)
			{
				class394_0.method_8().Add(num2);
			}
		}
	}

	private static void smethod_28(int int_12, string string_0, Class394 class394_0)
	{
		switch (int_12)
		{
		case 1:
			smethod_29(string_0, class394_0);
			break;
		case 2:
			smethod_30(string_0, class394_0);
			break;
		case 3:
			smethod_31(string_0, class394_0);
			break;
		}
	}

	private static void smethod_29(string string_0, Class394 class394_0)
	{
		Dictionary<string, long> dictionary_ = new Dictionary<string, long>
		{
			{
				GProD.TX(1099, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5028),
				10995028L
			},
			{
				GProD.TX(6074, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1025, appendsymbols: true),
				60741025L
			},
			{
				GProD.TX(6075, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1027, appendsymbols: true),
				60751027L
			},
			{
				GProD.TX(6076, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1029, appendsymbols: true),
				60761029L
			},
			{
				GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1032, appendsymbols: true),
				60771032L
			},
			{
				GProD.TX(6187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1442),
				61871442L
			},
			{
				GProD.TX(6187, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1444),
				61871444L
			},
			{
				GProD.TX(1102, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5028),
				11025028L
			}
		};
		smethod_32(string_0, dictionary_, class394_0.method_0());
		int[] int_ = int_3.Concat(int_2).ToArray();
		smethod_33(string_0, int_, class394_0.method_0());
		smethod_34(string_0, class394_0);
		smethod_35(string_0, class394_0);
	}

	private static void smethod_30(string string_0, Class394 class394_0)
	{
		smethod_36(string_0, class394_0);
		smethod_37(string_0, class394_0);
		smethod_38(string_0, class394_0);
		smethod_39(string_0, class394_0);
		smethod_42(string_0, class394_0);
	}

	private static void smethod_31(string string_0, Class394 class394_0)
	{
		smethod_33(string_0, int_9, class394_0.method_0());
		Dictionary<string, long> dictionary_ = new Dictionary<string, long>
		{
			{
				GProD.TX(1069, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5020),
				10695020L
			},
			{
				GProD.TX(1263, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5066),
				12635066L
			},
			{
				GProD.TX(1377, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5110),
				13775110L
			},
			{
				GProD.TX(1393, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5112),
				13935112L
			},
			{
				GProD.TX(1264, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5067),
				12645067L
			},
			{
				GProD.TX(1394, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5113),
				13945113L
			}
		};
		smethod_32(string_0, dictionary_, class394_0.method_0());
		smethod_41(string_0, class394_0);
		smethod_44(string_0, class394_0);
	}

	private static void smethod_32(string string_0, Dictionary<string, long> dictionary_0, List<long> list_0)
	{
		foreach (KeyValuePair<string, long> item in dictionary_0)
		{
			if (smethod_24(item.Key, string_0))
			{
				list_0.Add(item.Value);
			}
		}
	}

	private static void smethod_33(string string_0, int[] int_12, List<long> list_0)
	{
		foreach (int num in int_12)
		{
			if (smethod_24(GProD.TX(num, appendsymbols: true), string_0))
			{
				list_0.Add(num);
			}
		}
	}

	private static void smethod_34(string string_0, Class394 class394_0)
	{
		Dictionary<string, long> dictionary_ = new Dictionary<string, long>
		{
			{
				GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5050),
				12405050L
			},
			{
				GProD.TX(1240, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5087),
				12405087L
			},
			{
				GProD.TX(1241, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5061),
				12415061L
			},
			{
				GProD.TX(22410, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5061),
				22415061L
			},
			{
				GProD.TX(1241, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5063),
				12415063L
			},
			{
				GProD.TX(22410, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5063),
				22415063L
			},
			{
				GProD.TX(1242, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5028),
				12425028L
			}
		};
		smethod_32(string_0, dictionary_, class394_0.method_0());
	}

	private static void smethod_35(string string_0, Class394 class394_0)
	{
		smethod_45(string_0, class394_0, int_5);
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		dictionary.Add(GProD.TX(1439, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1440, appendsymbols: true), 14391440);
		dictionary.Add(GProD.TX(1439, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1441, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5028), 14415028);
		dictionary.Add(GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1442), 60811442);
		dictionary.Add(GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1444), 60811444);
		dictionary.Add(GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1461, appendsymbols: true), 60821461);
		dictionary.Add(GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1462, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5077), 14625077);
		dictionary.Add(GProD.TX(6125, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1489, appendsymbols: true), 61251489);
		Dictionary<string, int> dictionary_ = dictionary;
		smethod_46(string_0, class394_0, dictionary_);
	}

	private static void smethod_36(string string_0, Class394 class394_0)
	{
		(int[], int[])[] array = new(int[], int[])[5]
		{
			(new int[6] { 1008, 1348, 6072, 6073, 1350, 1154 }, int_0),
			(new int[5] { 6074, 6075, 6076, 6078, 6080 }, new int[6] { 5011, 5012, 5013, 5014, 5015, 5016 }),
			(new int[2] { 1054, 1463 }, new int[3] { 5017, 5018, 5019 }),
			(new int[2] { 1367, 1504 }, new int[3] { 5107, 5108, 5109 }),
			(new int[2] { 1383, 1464 }, new int[3] { 5081, 5082, 5083 })
		};
		(int[], int[])[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			(int[], int[]) tuple = array2[i];
			int[] item = tuple.Item1;
			int[] item2 = tuple.Item2;
			int[] array3 = item;
			foreach (int num in array3)
			{
				int[] array4 = item2;
				foreach (int num2 in array4)
				{
					if (smethod_24(GProD.TX(num, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(num2), string_0))
					{
						class394_0.method_0().Add(long.Parse(string.Format(Class16.smethod_0(1649276925), num, num2)));
					}
				}
			}
		}
	}

	private static void smethod_37(string string_0, Class394 class394_0)
	{
		int[] int_ = int_2.Concat(int_4).ToArray();
		smethod_33(string_0, int_, class394_0.method_0());
	}

	private static void smethod_38(string string_0, Class394 class394_0)
	{
		Dictionary<string, long> dictionary_ = new Dictionary<string, long>
		{
			{
				Class16.smethod_0(1649264260),
				5648891L
			},
			{
				Class16.smethod_0(1649264285),
				5648892L
			},
			{
				Class16.smethod_0(1649264310),
				5648893L
			},
			{
				Class16.smethod_0(1649264335),
				5648894L
			},
			{
				Class16.smethod_0(1649264353),
				5648895L
			},
			{
				Class16.smethod_0(1649264379),
				5648896L
			},
			{
				Class16.smethod_0(1649264413),
				5648897L
			},
			{
				Class16.smethod_0(1649264439),
				5648898L
			},
			{
				Class16.smethod_0(1649264457),
				5648899L
			},
			{
				Class16.smethod_0(1649264483),
				5648900L
			},
			{
				Class16.smethod_0(1649264517),
				5648901L
			},
			{
				Class16.smethod_0(1649264536),
				5648902L
			},
			{
				Class16.smethod_0(1649264563),
				5648903L
			},
			{
				Class16.smethod_0(1649264598),
				5648904L
			},
			{
				Class16.smethod_0(1649264617),
				5648905L
			},
			{
				Class16.smethod_0(1649263619),
				5648906L
			},
			{
				Class16.smethod_0(1649263653),
				5648907L
			}
		};
		smethod_32(string_0, dictionary_, class394_0.method_0());
	}

	private static void smethod_39(string string_0, Class394 class394_0)
	{
		smethod_45(string_0, class394_0, int_6);
		Dictionary<string, int> dictionary_ = new Dictionary<string, int>
		{
			{
				Class16.smethod_0(1649263708),
				5648908
			},
			{
				Class16.smethod_0(1649263730),
				5648909
			}
		};
		smethod_46(string_0, class394_0, dictionary_);
		smethod_40(string_0, class394_0);
	}

	private static void smethod_40(string string_0, Class394 class394_0)
	{
		Struct117 A_ = default(Struct117);
		A_.string_0 = string_0;
		A_.class394_0 = class394_0;
		if (!A_.class394_0.method_10() && A_.class394_0.method_6().Count <= 0)
		{
			return;
		}
		foreach (int item in A_.class394_0.method_6())
		{
			string text = GProD.TX(item, appendsymbols: true) + Class16.smethod_0(1648942211);
			smethod_50(text + GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1428, appendsymbols: true), 60771428, ref A_);
			smethod_50(text + GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1497, appendsymbols: true), 60771497, ref A_);
			smethod_50(text + GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1649263678), 60771429, ref A_);
			smethod_50(text + GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1649263680), 60771430, ref A_);
			smethod_50(text + GProD.TX(6077, appendsymbols: true) + Class16.smethod_0(1649263690), 60771431, ref A_);
			smethod_50(text + GProD.TX(1439, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1441, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5027), 14415027, ref A_);
			smethod_50(text + GProD.TX(1439, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1441, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5029), 14415029, ref A_);
			smethod_50(text + GProD.TX(1439, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1441, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5030), 14415030, ref A_);
			smethod_50(text + GProD.TX(1439, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1441, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5031), 14415031, ref A_);
			smethod_50(text + GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1443, appendsymbols: true), 60811443, ref A_);
			smethod_50(text + GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1445, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5071), 14455071, ref A_);
			smethod_50(text + GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1445, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5072), 14455072, ref A_);
			smethod_50(text + GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1445, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5073), 14455073, ref A_);
			smethod_50(text + GProD.TX(6081, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1445, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5074), 14455074, ref A_);
			smethod_50(text + GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1462, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5075), 14625075, ref A_);
			smethod_50(text + GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1462, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5076), 14625076, ref A_);
			smethod_50(text + GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1462, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5078), 14625078, ref A_);
			smethod_50(text + GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1462, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5079), 14625079, ref A_);
			smethod_50(text + GProD.TX(6082, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1462, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5080), 14625080, ref A_);
			smethod_50(text + GProD.TX(1463, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5017), 14635017, ref A_);
			smethod_50(text + GProD.TX(1463, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5018), 14635018, ref A_);
			smethod_50(text + GProD.TX(1463, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5019), 14635019, ref A_);
			smethod_50(text + GProD.TX(1504, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5107), 15045107, ref A_);
			smethod_50(text + GProD.TX(1504, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5108), 15045108, ref A_);
			smethod_50(text + GProD.TX(1504, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5109), 15045109, ref A_);
			smethod_50(text + GProD.TX(1464, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5081), 14645081, ref A_);
			smethod_50(text + GProD.TX(1464, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5082), 14645082, ref A_);
			smethod_50(text + GProD.TX(1464, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5083), 14645083, ref A_);
			smethod_50(text + GProD.TX(1468, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5084), 14685084, ref A_);
			smethod_50(text + GProD.TX(1469, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5021), 14695021, ref A_);
			smethod_50(text + GProD.TX(1469, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5022), 14695022, ref A_);
			smethod_50(text + GProD.TX(1476, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5085), 14765085, ref A_);
			smethod_50(text + GProD.TX(1476, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5086), 14765086, ref A_);
			smethod_50(text + GProD.TX(1488, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5097), 14885097, ref A_);
			smethod_50(text + GProD.TX(1488, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(5098), 14885098, ref A_);
			smethod_50(text + GProD.TX(6125, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1490, appendsymbols: true), 61251490, ref A_);
			smethod_50(text + GProD.TX(6125, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1491, appendsymbols: true), 61251491, ref A_);
			smethod_50(text + GProD.TX(6125, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1492, appendsymbols: true), 61251492, ref A_);
		}
	}

	private static void smethod_41(string string_0, Class394 class394_0)
	{
		smethod_47(string_0, class394_0, 1469, 5066, 14695066);
		smethod_47(string_0, class394_0, 1470, 5067, 14705067);
	}

	private static void smethod_42(string string_0, Class394 class394_0)
	{
		smethod_48(string_0, class394_0, int_7);
		smethod_43(string_0, class394_0);
	}

	private static void smethod_43(string string_0, Class394 class394_0)
	{
		if (!class394_0.method_12() && class394_0.method_8().Count <= 0)
		{
			return;
		}
		foreach (int item in class394_0.method_8())
		{
			if (smethod_24(GProD.TX(item, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1715, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(1719, appendsymbols: true), string_0))
			{
				class394_0.method_4().Add(1719);
			}
		}
	}

	private static void smethod_44(string string_0, Class394 class394_0)
	{
		smethod_48(string_0, class394_0, int_8);
	}

	private static void smethod_45(string string_0, Class394 class394_0, int[] int_12)
	{
		if (!class394_0.method_10() && class394_0.method_6().Count <= 0)
		{
			return;
		}
		foreach (int num in int_12)
		{
			foreach (int item in class394_0.method_6())
			{
				if (smethod_24(GProD.TX(item, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(num, appendsymbols: true), string_0))
				{
					class394_0.method_2().Add(num);
					break;
				}
			}
		}
	}

	private static void smethod_46(string string_0, Class394 class394_0, Dictionary<string, int> dictionary_0)
	{
		if (!class394_0.method_10() && class394_0.method_6().Count <= 0)
		{
			return;
		}
		foreach (KeyValuePair<string, int> item in dictionary_0)
		{
			foreach (int item2 in class394_0.method_6())
			{
				if (smethod_24(GProD.TX(item2, appendsymbols: true) + Class16.smethod_0(1648942211) + item.Key, string_0))
				{
					class394_0.method_2().Add(item.Value);
					break;
				}
			}
		}
	}

	private static void smethod_47(string string_0, Class394 class394_0, int int_12, int int_13, int int_14)
	{
		if (!class394_0.method_10() && class394_0.method_6().Count <= 0)
		{
			return;
		}
		foreach (int item in class394_0.method_6())
		{
			if (smethod_24(GProD.TX(item, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(int_12, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(int_13), string_0))
			{
				class394_0.method_2().Add(int_14);
				break;
			}
		}
	}

	private static void smethod_48(string string_0, Class394 class394_0, int[] int_12)
	{
		if (!class394_0.method_12() && class394_0.method_8().Count <= 0)
		{
			return;
		}
		foreach (int num in int_12)
		{
			foreach (int item in class394_0.method_8())
			{
				if (smethod_24(GProD.TX(item, appendsymbols: true) + Class16.smethod_0(1648942211) + GProD.TX(num, appendsymbols: true), string_0))
				{
					class394_0.method_4().Add(num);
					break;
				}
			}
		}
	}

	private static void smethod_49(ATaskTempl[] ataskTempl_0, DataGridView dataGridView_0, ToolStripProgressBar toolStripProgressBar_0, int int_12, int int_13, string string_0, string string_1, Class394 class394_0)
	{
		ToolStripProgressBarSafe.TrySet(toolStripProgressBar_0, ataskTempl_0.Length, 0);
		for (int i = 0; i < ataskTempl_0.Length; i++)
		{
			smethod_0(ref dataGridView_0, ataskTempl_0[i], int_12, int_13, class394_0.method_0(), class394_0.method_6(), class394_0.method_2(), class394_0.method_8(), class394_0.method_4(), string_0, string_1);
			if (ataskTempl_0[i].m_nSubCount > 0)
			{
				smethod_4(ref dataGridView_0, ataskTempl_0[i], int_12, int_13, class394_0.method_0(), class394_0.method_6(), class394_0.method_2(), class394_0.method_8(), class394_0.method_4(), string_0, string_1);
			}
			ToolStripProgressBarSafe.Increment(toolStripProgressBar_0);
		}
	}

	[CompilerGenerated]
	internal static void smethod_50(string text, int id, ref Struct117 A_2)
	{
		if (smethod_24(text, A_2.string_0))
		{
			A_2.class394_0.method_2().Add(id);
		}
	}
}
