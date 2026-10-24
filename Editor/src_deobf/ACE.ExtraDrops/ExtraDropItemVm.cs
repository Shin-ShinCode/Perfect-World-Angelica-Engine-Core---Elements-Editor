using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ACE.ExtraDrops;

public sealed class ExtraDropItemVm : INotifyPropertyChanged
{
	private int int_0;

	private decimal decimal_0;

	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	public int Id
	{
		get
		{
			return int_0;
		}
		set
		{
			if (int_0 != value)
			{
				int_0 = value;
				propertyChangedEventHandler_0?.Invoke(this, new PropertyChangedEventArgs(Class16.smethod_0(1649077794)));
			}
		}
	}

	public decimal ProbabilityPercent
	{
		get
		{
			return decimal_0;
		}
		set
		{
			decimal num = value;
			if (num < 0m)
			{
				num = default(decimal);
			}
			if (num > 100m)
			{
				num = 100m;
			}
			if (!(decimal_0 == num))
			{
				decimal_0 = num;
				propertyChangedEventHandler_0?.Invoke(this, new PropertyChangedEventArgs(Class16.smethod_0(1649077803)));
			}
		}
	}

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

	public ExtraDropItemVm()
	{
	}

	public ExtraDropItemVm(int id, decimal probabilityPercent)
	{
		int_0 = id;
		ProbabilityPercent = probabilityPercent;
	}
}
