using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace ACE.sTASKedit.Classes;

internal class Lists
{
	public static List<int> monster_npc_minelists = new List<int>(new int[3] { 38, 57, 79 });

	public static ArrayList VersionsColors = new ArrayList(new Color[10]
	{
		Color.Black,
		Color.Gray,
		Color.Red,
		Color.DarkGreen,
		SystemColors.HotTrack,
		Color.Maroon,
		Color.MediumPurple,
		Color.Purple,
		Color.Violet,
		Color.Yellow
	});
}
