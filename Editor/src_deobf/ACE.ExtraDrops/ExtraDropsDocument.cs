using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ACE.ExtraDrops;

public sealed class ExtraDropsDocument
{
	private readonly BindingList<ExtraDropGroupVm> bindingList_0;

	public BindingList<ExtraDropGroupVm> Groups
	{
		[CompilerGenerated]
		get
		{
			return bindingList_0;
		}
	}

	public ExtraDropsDocument(IEnumerable<ExtraDropGroupVm> groups)
	{
		object obj;
		if (groups == null)
		{
			obj = null;
		}
		else
		{
			obj = groups.ToList();
			if (obj != null)
			{
				goto IL_001c;
			}
		}
		obj = new List<ExtraDropGroupVm>();
		goto IL_001c;
		IL_001c:
		bindingList_0 = new BindingList<ExtraDropGroupVm>((IList<ExtraDropGroupVm>)obj);
	}

	public static ExtraDropsDocument FromExtraDrops(EXTRA_DROPS extra)
	{
		List<ExtraDropGroupVm> list = new List<ExtraDropGroupVm>();
		if (extra?.Tables != null)
		{
			for (int i = 0; i < extra.Tables.Count; i++)
			{
				EXTRADROPTABLE extradroptable_ = extra.Tables[i];
				list.Add(ExtraDropGroupVm.FromTable(extradroptable_));
			}
		}
		return new ExtraDropsDocument(list);
	}

	public void ApplyTo(EXTRA_DROPS extra)
	{
		if (extra == null)
		{
			throw new ArgumentNullException(Class16.smethod_0(1649071787));
		}
		if (extra.Tables == null)
		{
			extra.Tables = new List<EXTRADROPTABLE>();
		}
		extra.Tables.Clear();
		for (int i = 0; i < Groups.Count; i++)
		{
			ExtraDropGroupVm extraDropGroupVm = Groups[i];
			if (extraDropGroupVm != null)
			{
				extra.Tables.Add(extraDropGroupVm.ToTable());
			}
		}
		extra.TableCount = extra.Tables.Count;
		extra.FileChanged = true;
	}
}
