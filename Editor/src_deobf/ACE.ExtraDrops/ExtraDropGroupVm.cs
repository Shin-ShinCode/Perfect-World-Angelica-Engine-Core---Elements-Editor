using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using ACE.Classes;

namespace ACE.ExtraDrops;

public sealed class ExtraDropGroupVm : INotifyPropertyChanged
{
	[Serializable]
	private sealed class Class137
	{
		public static readonly Class137 class137_0 = new Class137();

		public static Func<ExtraDropMonsterVm, int> func_0;

		public static Func<ExtraDropItemVm, decimal> func_1;

		public static Func<ExtraDropItemVm, bool> func_2;

		public static Func<ExtraDropItemVm, decimal> func_3;

		internal int method_0(ExtraDropMonsterVm extraDropMonsterVm_0)
		{
			return extraDropMonsterVm_0?.Id ?? 0;
		}

		internal decimal method_1(ExtraDropItemVm extraDropItemVm_0)
		{
			return extraDropItemVm_0?.ProbabilityPercent ?? 0m;
		}

		internal bool method_2(ExtraDropItemVm extraDropItemVm_0)
		{
			if (extraDropItemVm_0 != null)
			{
				return extraDropItemVm_0.Id > 0;
			}
			return false;
		}

		internal decimal method_3(ExtraDropItemVm extraDropItemVm_0)
		{
			return extraDropItemVm_0.ProbabilityPercent;
		}
	}

	private string string_0 = string.Empty;

	private EDT_TYPE edt_TYPE_0 = EDT_TYPE.Addon;

	private decimal decimal_0;

	private decimal decimal_1;

	private decimal decimal_2;

	private decimal decimal_3;

	private decimal decimal_4;

	private decimal decimal_5;

	private decimal decimal_6;

	private decimal decimal_7;

	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	private readonly BindingList<ExtraDropMonsterVm> bindingList_0 = new BindingList<ExtraDropMonsterVm>();

	private readonly BindingList<ExtraDropItemVm> bindingList_1 = new BindingList<ExtraDropItemVm>();

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			if (value == null)
			{
				value = string.Empty;
			}
			if (!(string_0 == value))
			{
				string_0 = value;
				method_1(Class16.smethod_0(1648936731));
			}
		}
	}

	public EDT_TYPE Type
	{
		get
		{
			return edt_TYPE_0;
		}
		set
		{
			if (!edt_TYPE_0.Equals(value))
			{
				edt_TYPE_0 = value;
				method_1(Class16.smethod_0(1648936875));
			}
		}
	}

	public decimal Drop0Percent
	{
		get
		{
			return decimal_0;
		}
		set
		{
			method_0(ref decimal_0, value, Class16.smethod_0(1649077876));
		}
	}

	public decimal Drop1Percent
	{
		get
		{
			return decimal_1;
		}
		set
		{
			method_0(ref decimal_1, value, Class16.smethod_0(1649077895));
		}
	}

	public decimal Drop2Percent
	{
		get
		{
			return decimal_2;
		}
		set
		{
			method_0(ref decimal_2, value, Class16.smethod_0(1649077906));
		}
	}

	public decimal Drop3Percent
	{
		get
		{
			return decimal_3;
		}
		set
		{
			method_0(ref decimal_3, value, Class16.smethod_0(1649077933));
		}
	}

	public decimal Drop4Percent
	{
		get
		{
			return decimal_4;
		}
		set
		{
			method_0(ref decimal_4, value, Class16.smethod_0(1649077944));
		}
	}

	public decimal Drop5Percent
	{
		get
		{
			return decimal_5;
		}
		set
		{
			method_0(ref decimal_5, value, Class16.smethod_0(1649077963));
		}
	}

	public decimal Drop6Percent
	{
		get
		{
			return decimal_6;
		}
		set
		{
			method_0(ref decimal_6, value, Class16.smethod_0(1649077990));
		}
	}

	public decimal Drop7Percent
	{
		get
		{
			return decimal_7;
		}
		set
		{
			method_0(ref decimal_7, value, Class16.smethod_0(1649078001));
		}
	}

	public decimal DropSumPercent => decimal_0 + decimal_1 + decimal_2 + decimal_3 + decimal_4 + decimal_5 + decimal_6 + decimal_7;

	public BindingList<ExtraDropMonsterVm> Monsters
	{
		[CompilerGenerated]
		get
		{
			return bindingList_0;
		}
	}

	public BindingList<ExtraDropItemVm> Items
	{
		[CompilerGenerated]
		get
		{
			return bindingList_1;
		}
	}

	public decimal ItemsSumPercent => ((IEnumerable<ExtraDropItemVm>)Items).Sum((Func<ExtraDropItemVm, decimal>)Class137.class137_0.method_1);

	public event PropertyChangedEventHandler PropertyChanged
	{
		[CompilerGenerated]
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public EXTRADROPTABLE ToTable()
	{
		EXTRADROPTABLE eXTRADROPTABLE = EXTRADROPTABLE.CreateEmpty(Name ?? string.Empty);
		eXTRADROPTABLE.type = Type;
		eXTRADROPTABLE.id_monsters = Monsters.Select(Class137.class137_0.method_0).ToList();
		eXTRADROPTABLE.MonsterCount = eXTRADROPTABLE.id_monsters.Count;
		eXTRADROPTABLE.drop_items = new DROP_ITEMS[256];
		for (int i = 0; i < 256; i++)
		{
			if (i < Items.Count && Items[i] != null)
			{
				eXTRADROPTABLE.drop_items[i].id = Items[i].Id;
				eXTRADROPTABLE.drop_items[i].probability = (float)(smethod_0(Items[i].ProbabilityPercent) / 100m);
			}
			else
			{
				eXTRADROPTABLE.drop_items[i].id = 0;
				eXTRADROPTABLE.drop_items[i].probability = 0f;
			}
		}
		eXTRADROPTABLE.drop_num_probability = new float[8];
		eXTRADROPTABLE.drop_num_probability[0] = (float)(smethod_0(Drop0Percent) / 100m);
		eXTRADROPTABLE.drop_num_probability[1] = (float)(smethod_0(Drop1Percent) / 100m);
		eXTRADROPTABLE.drop_num_probability[2] = (float)(smethod_0(Drop2Percent) / 100m);
		eXTRADROPTABLE.drop_num_probability[3] = (float)(smethod_0(Drop3Percent) / 100m);
		eXTRADROPTABLE.drop_num_probability[4] = (float)(smethod_0(Drop4Percent) / 100m);
		eXTRADROPTABLE.drop_num_probability[5] = (float)(smethod_0(Drop5Percent) / 100m);
		eXTRADROPTABLE.drop_num_probability[6] = (float)(smethod_0(Drop6Percent) / 100m);
		eXTRADROPTABLE.drop_num_probability[7] = (float)(smethod_0(Drop7Percent) / 100m);
		eXTRADROPTABLE.ValidateAndFix();
		return eXTRADROPTABLE;
	}

	private void method_0(ref decimal decimal_8, decimal decimal_9, string string_1)
	{
		decimal_9 = smethod_0(decimal_9);
		if (!(decimal_8 == decimal_9))
		{
			decimal_8 = decimal_9;
			method_1(string_1);
			method_1(Class16.smethod_0(1649071774));
		}
	}

	private static decimal smethod_0(decimal decimal_8)
	{
		if (decimal_8 < 0m)
		{
			return 0m;
		}
		if (decimal_8 > 100m)
		{
			return 100m;
		}
		return decimal_8;
	}

	private void method_1(string string_1)
	{
		propertyChangedEventHandler_0?.Invoke(this, new PropertyChangedEventArgs(string_1));
	}

	public void NormalizeDropProbabilities()
	{
		decimal dropSumPercent = DropSumPercent;
		if (dropSumPercent <= 0m)
		{
			Drop0Percent = 100m;
			Drop1Percent = 0m;
			Drop2Percent = 0m;
			Drop3Percent = 0m;
			Drop4Percent = 0m;
			Drop5Percent = 0m;
			Drop6Percent = 0m;
			Drop7Percent = 0m;
			return;
		}
		decimal[] array = new decimal[8] { decimal_0, decimal_1, decimal_2, decimal_3, decimal_4, decimal_5, decimal_6, decimal_7 };
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = array[i] / dropSumPercent * 100m;
			array[i] = Math.Round(array[i], 6, MidpointRounding.AwayFromZero);
		}
		Drop0Percent = array[0];
		Drop1Percent = array[1];
		Drop2Percent = array[2];
		Drop3Percent = array[3];
		Drop4Percent = array[4];
		Drop5Percent = array[5];
		Drop6Percent = array[6];
		Drop7Percent = array[7];
	}

	public void NormalizeItemProbabilities()
	{
		for (int i = 0; i < Items.Count; i++)
		{
			ExtraDropItemVm extraDropItemVm = Items[i];
			if (extraDropItemVm != null && extraDropItemVm.Id <= 0)
			{
				extraDropItemVm.ProbabilityPercent = 0m;
			}
		}
		List<ExtraDropItemVm> list = Items.Where(Class137.class137_0.method_2).ToList();
		if (list.Count == 0)
		{
			return;
		}
		decimal num = ((IEnumerable<ExtraDropItemVm>)list).Sum((Func<ExtraDropItemVm, decimal>)Class137.class137_0.method_3);
		decimal[] array = new decimal[list.Count];
		if (num <= 0m)
		{
			decimal d = 100m / (decimal)list.Count;
			for (int j = 0; j < list.Count; j++)
			{
				array[j] = Math.Round(d, 6, MidpointRounding.AwayFromZero);
			}
		}
		else
		{
			for (int k = 0; k < list.Count; k++)
			{
				decimal d2 = list[k].ProbabilityPercent / num * 100m;
				array[k] = Math.Round(d2, 6, MidpointRounding.AwayFromZero);
			}
		}
		decimal num2 = 100m - array.Sum();
		array[array.Length - 1] = Math.Round(array[array.Length - 1] + num2, 6, MidpointRounding.AwayFromZero);
		if (array[array.Length - 1] < 0m)
		{
			array[array.Length - 1] = default(decimal);
		}
		if (array[array.Length - 1] > 100m)
		{
			array[array.Length - 1] = 100m;
		}
		for (int l = 0; l < list.Count; l++)
		{
			list[l].ProbabilityPercent = array[l];
		}
	}

	public static ExtraDropGroupVm FromTable(EXTRADROPTABLE extradroptable_0)
	{
		ExtraDropGroupVm extraDropGroupVm = new ExtraDropGroupVm();
		if (extradroptable_0 == null)
		{
			extraDropGroupVm.Name = string.Empty;
			extraDropGroupVm.Type = EDT_TYPE.Addon;
			extraDropGroupVm.Drop0Percent = 100m;
			return extraDropGroupVm;
		}
		extraDropGroupVm.Name = extradroptable_0.Name ?? string.Empty;
		extraDropGroupVm.Type = extradroptable_0.type;
		float[] drop_num_probability = extradroptable_0.drop_num_probability;
		if (drop_num_probability != null && drop_num_probability.Length >= 8)
		{
			extraDropGroupVm.Drop0Percent = smethod_0((decimal)drop_num_probability[0] * 100m);
			extraDropGroupVm.Drop1Percent = smethod_0((decimal)drop_num_probability[1] * 100m);
			extraDropGroupVm.Drop2Percent = smethod_0((decimal)drop_num_probability[2] * 100m);
			extraDropGroupVm.Drop3Percent = smethod_0((decimal)drop_num_probability[3] * 100m);
			extraDropGroupVm.Drop4Percent = smethod_0((decimal)drop_num_probability[4] * 100m);
			extraDropGroupVm.Drop5Percent = smethod_0((decimal)drop_num_probability[5] * 100m);
			extraDropGroupVm.Drop6Percent = smethod_0((decimal)drop_num_probability[6] * 100m);
			extraDropGroupVm.Drop7Percent = smethod_0((decimal)drop_num_probability[7] * 100m);
		}
		else
		{
			extraDropGroupVm.Drop0Percent = 100m;
		}
		if (extradroptable_0.id_monsters != null)
		{
			for (int i = 0; i < extradroptable_0.id_monsters.Count; i++)
			{
				extraDropGroupVm.Monsters.Add(new ExtraDropMonsterVm(extradroptable_0.id_monsters[i]));
			}
		}
		if (extradroptable_0.drop_items != null)
		{
			for (int j = 0; j < extradroptable_0.drop_items.Length; j++)
			{
				int id = extradroptable_0.drop_items[j].id;
				if (id > 0)
				{
					extraDropGroupVm.Items.Add(new ExtraDropItemVm(id, smethod_0((decimal)extradroptable_0.drop_items[j].probability * 100m)));
				}
			}
		}
		return extraDropGroupVm;
	}
}
