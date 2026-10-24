using System;
using System.Threading;

namespace ACE.Classes.ACE;

public class Debouncer : IDisposable
{
	private readonly Action action_0;

	private readonly TimeSpan timeSpan_0;

	private readonly object object_0 = new object();

	private readonly Timer timer_0;

	private bool bool_0;

	private DateTime dateTime_0;

	public Debouncer(Action action, TimeSpan delay)
	{
		action_0 = action ?? throw new ArgumentNullException(Class16.smethod_0(1648908105));
		timeSpan_0 = delay;
		timer_0 = new Timer(method_0, null, Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
	}

	public void Schedule()
	{
		lock (object_0)
		{
			if (!bool_0)
			{
				DateTime utcNow = DateTime.UtcNow;
				if (!(utcNow - dateTime_0 < TimeSpan.FromMilliseconds(50.0)))
				{
					dateTime_0 = utcNow;
					timer_0.Change(timeSpan_0, Timeout.InfiniteTimeSpan);
				}
			}
		}
	}

	private void method_0(object object_1)
	{
		bool flag;
		lock (object_0)
		{
			flag = !bool_0;
		}
		if (!flag)
		{
			return;
		}
		try
		{
			action_0();
		}
		catch
		{
		}
	}

	public void Dispose()
	{
		lock (object_0)
		{
			if (!bool_0)
			{
				bool_0 = true;
				timer_0?.Dispose();
			}
		}
	}
}
