using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ACE.FastImageSelector;

public class Debounce : IDisposable
{
	private readonly Action action_0;

	private readonly Timer timer_0;

	private long long_0;

	private long long_1;

	private bool bool_0;

	public bool IsScheduled
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
	}

	public Debounce(Action action, int interval)
	{
		action_0 = action;
		timer_0 = new Timer
		{
			Interval = interval
		};
		timer_0.Tick += timer_0_Tick;
	}

	private void method_0(bool bool_1)
	{
		bool_0 = bool_1;
	}

	public void CancelSchedule()
	{
		long_0++;
		long_1 = long_0;
		method_0(bool_1: false);
		timer_0.Stop();
	}

	public void Launch()
	{
		long_1 = ++long_0;
		method_0(bool_1: true);
		timer_0.Stop();
		timer_0.Start();
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		timer_0.Stop();
		if (long_0 == long_1)
		{
			action_0();
			method_0(bool_1: false);
		}
	}

	public void Dispose()
	{
		timer_0.Stop();
		timer_0.Tick -= timer_0_Tick;
		timer_0.Dispose();
	}
}
