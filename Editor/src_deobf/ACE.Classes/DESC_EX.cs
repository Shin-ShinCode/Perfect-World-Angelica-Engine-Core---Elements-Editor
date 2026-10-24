using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ACE.RSGlobal;

namespace ACE.Classes;

public class DESC_EX
{
	public string head;

	public string body;

	public string creator;

	public string suite;

	public string desc;

	public string proc;

	public string props;

	public string refs;

	public string errors;

	public string duplicates;

	public string watemark;

	public List<string> Refines;

	public bool bOnlyRefines;

	public ITEMPOS HighlightItem;

	public bool bBuild;

	public DESC_EX([MarshalAs(UnmanagedType.U1)] bool bBuild)
	{
		this.bBuild = bBuild;
		Refines = new List<string>();
	}

	public DESC_EX()
	{
	}

	public void AddRefinedProp(string Prop)
	{
		Refines?.Add(Prop);
		GC.KeepAlive(this);
	}

	public int GetLineCount()
	{
		int num = global::ACE.RSGlobal.RSGlobal.CountWords(head, Class16.smethod_0(1648908417));
		num = global::ACE.RSGlobal.RSGlobal.CountWords(body, Class16.smethod_0(1648908417)) + num;
		num = global::ACE.RSGlobal.RSGlobal.CountWords(creator, Class16.smethod_0(1648908417)) + num;
		num = global::ACE.RSGlobal.RSGlobal.CountWords(suite, Class16.smethod_0(1648908417)) + num;
		num = global::ACE.RSGlobal.RSGlobal.CountWords(desc, Class16.smethod_0(1648908417)) + num;
		num = global::ACE.RSGlobal.RSGlobal.CountWords(proc, Class16.smethod_0(1648908417)) + num;
		num = global::ACE.RSGlobal.RSGlobal.CountWords(props, Class16.smethod_0(1648908417)) + num;
		num = global::ACE.RSGlobal.RSGlobal.CountWords(refs, Class16.smethod_0(1648908417)) + num;
		num = global::ACE.RSGlobal.RSGlobal.CountWords(errors, Class16.smethod_0(1648908417)) + num;
		num = global::ACE.RSGlobal.RSGlobal.CountWords(duplicates, Class16.smethod_0(1648908417)) + num;
		num = global::ACE.RSGlobal.RSGlobal.CountWords(watemark, Class16.smethod_0(1648908417)) + num;
		GC.KeepAlive(this);
		return num;
	}
}
