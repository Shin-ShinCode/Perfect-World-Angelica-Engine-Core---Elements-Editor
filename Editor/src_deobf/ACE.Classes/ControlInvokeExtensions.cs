using System;
using System.Threading;
using System.Windows.Forms;

namespace ACE.Classes;

internal static class ControlInvokeExtensions
{
	private sealed class Class58
	{
		public Control control_0;

		public Action action_0;

		internal void method_0()
		{
			if (!control_0.IsDisposed && !control_0.Disposing)
			{
				action_0();
			}
		}
	}

	private sealed class Class59<T>
	{
		public Action<T> action_0;

		public T gparam_0;

		internal void method_0()
		{
			action_0(gparam_0);
		}
	}

	private sealed class Class60
	{
		public Form form_0;

		internal void method_0()
		{
			if (!form_0.IsDisposed && !form_0.Disposing)
			{
				form_0.Close();
			}
		}
	}

	public static bool InvokeSafe(this Control control, Action action)
	{
		return smethod_0(control, action, bool_0: false);
	}

	public static bool BeginInvokeSafe(this Control control, Action action)
	{
		return smethod_0(control, action, bool_0: true);
	}

	public static bool BeginInvokeSafe<T>(this Control control, Action<T> action, T arg)
	{
		Class59<T> @class = new Class59<T>();
		@class.action_0 = action;
		@class.gparam_0 = arg;
		if (@class.action_0 == null)
		{
			return false;
		}
		return control.BeginInvokeSafe(@class.method_0);
	}

	public static bool CloseSafe(this Form form)
	{
		Class60 @class = new Class60();
		@class.form_0 = form;
		if (@class.form_0 != null && !@class.form_0.IsDisposed && !@class.form_0.Disposing)
		{
			if (@class.form_0.BeginInvokeSafe(@class.method_0))
			{
				return true;
			}
			if (SynchronizationContext.Current is WindowsFormsSynchronizationContext)
			{
				@class.form_0.Close();
				return true;
			}
			try
			{
				@class.form_0.Dispose();
				return true;
			}
			catch (ObjectDisposedException)
			{
				return false;
			}
		}
		return false;
	}

	private static bool smethod_0(Control control_0, Action action_0, bool bool_0)
	{
		Class58 @class = new Class58();
		@class.control_0 = control_0;
		@class.action_0 = action_0;
		if (@class.control_0 != null && @class.action_0 != null && !@class.control_0.IsDisposed && !@class.control_0.Disposing)
		{
			if (!@class.control_0.IsHandleCreated)
			{
				if (SynchronizationContext.Current is WindowsFormsSynchronizationContext)
				{
					@class.action_0();
					return true;
				}
				return false;
			}
			if (!@class.control_0.InvokeRequired)
			{
				@class.action_0();
				return true;
			}
			MethodInvoker method = @class.method_0;
			try
			{
				if (bool_0)
				{
					@class.control_0.BeginInvoke(method);
				}
				else
				{
					@class.control_0.Invoke(method);
				}
				return true;
			}
			catch (ObjectDisposedException)
			{
				return false;
			}
			catch (InvalidOperationException)
			{
				return false;
			}
		}
		return false;
	}
}
