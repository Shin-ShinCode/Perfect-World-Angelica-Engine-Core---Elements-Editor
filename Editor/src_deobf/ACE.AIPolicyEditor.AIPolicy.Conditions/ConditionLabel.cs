using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.AIPolicyEditor.AIPolicy.Conditions;

internal class ConditionLabel : Label
{
	private static readonly ToolTip toolTip_0 = new ToolTip();

	private readonly ContextMenuStrip contextMenuStrip_0;

	private readonly ToolStripItem toolStripItem_0;

	private readonly ToolStripItem toolStripItem_1;

	private readonly ToolStripItem toolStripItem_2;

	private Condition condition_0;

	private Condition condition_1;

	private ConditionBranchSide conditionBranchSide_0;

	private bool bool_0;

	public Condition cond
	{
		[CompilerGenerated]
		get
		{
			return condition_0;
		}
		[CompilerGenerated]
		set
		{
			condition_0 = value;
		}
	}

	public Condition ParentCondition
	{
		[CompilerGenerated]
		get
		{
			return condition_1;
		}
		[CompilerGenerated]
		set
		{
			condition_1 = value;
		}
	}

	public ConditionBranchSide BranchSide
	{
		[CompilerGenerated]
		get
		{
			return conditionBranchSide_0;
		}
		[CompilerGenerated]
		set
		{
			conditionBranchSide_0 = value;
		}
	}

	public bool IsEmphasized
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public ConditionLabel(Condition cond)
	{
		this.cond = cond;
		AutoSize = true;
		base.AutoEllipsis = true;
		base.Margin = new Padding(4);
		Cursor = Cursors.Hand;
		base.Padding = new Padding(10, 5, 10, 5);
		contextMenuStrip_0 = new ContextMenuStrip
		{
			ShowImageMargin = false
		};
		contextMenuStrip_0.Opening += contextMenuStrip_0_Opening;
		toolStripItem_0 = contextMenuStrip_0.Items.Add(TextStorage.Msg(Class16.smethod_0(1648941848), Class16.smethod_0(1648941865)), null, method_0);
		toolStripItem_1 = contextMenuStrip_0.Items.Add(TextStorage.Msg(Class16.smethod_0(1648941875), Class16.smethod_0(1648941902)), null, method_1);
		toolStripItem_2 = contextMenuStrip_0.Items.Add(TextStorage.Msg(Class16.smethod_0(1648941906), Class16.smethod_0(1648941934)), null, method_2);
		ContextMenuStrip = contextMenuStrip_0;
		toolTip_0.SetToolTip(this, TextStorage.Msg(Class16.smethod_0(1648941936), Class16.smethod_0(1648941972)) + Class16.smethod_0(1648941987) + TextStorage.Msg(Class16.smethod_0(1648941995), Class16.smethod_0(1648942031)));
	}

	private void contextMenuStrip_0_Opening(object sender, CancelEventArgs e)
	{
		bool flag = cond != null;
		toolStripItem_0.Enabled = flag;
		toolStripItem_1.Enabled = flag;
		toolStripItem_2.Enabled = flag;
		e.Cancel = !flag;
	}

	private static void smethod_0(Condition condition_2, Condition condition_3, Condition condition_4)
	{
		condition_2.ID = 7;
		condition_2.Type = 1;
		condition_2.Value = Array.Empty<object>();
		condition_2.ConditionLeft = condition_3;
		condition_2.ConditionRight = condition_4;
		(condition_2.SubNodeL, condition_2.SubNodeR) = Conditions.GetSubNodeByType(1);
	}

	private void method_0(object sender, EventArgs e)
	{
		if (cond != null)
		{
			smethod_0(cond, (Condition)cond.Clone(), Conditions.CreateEmpty());
			method_4();
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		if (cond != null)
		{
			Condition condition = (Condition)cond.Clone();
			smethod_0(cond, condition, (Condition)condition.Clone());
			method_4();
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		ConditionControl conditionControl = method_3();
		if (conditionControl != null && cond != null)
		{
			if (ParentCondition == null)
			{
				cond.CopyFrom(Conditions.CreateEmpty());
			}
			else
			{
				Condition condition = BranchSide switch
				{
					ConditionBranchSide.Right => ParentCondition.ConditionLeft, 
					ConditionBranchSide.Left => ParentCondition.ConditionRight, 
					_ => null, 
				};
				ParentCondition.CopyFrom(condition ?? Conditions.CreateEmpty());
			}
			conditionControl.Reload();
		}
	}

	private ConditionControl method_3()
	{
		Control control = base.Parent;
		ConditionControl conditionControl;
		while (true)
		{
			if (control != null)
			{
				conditionControl = control as ConditionControl;
				if (conditionControl != null)
				{
					break;
				}
				control = control.Parent;
				continue;
			}
			return null;
		}
		return conditionControl;
	}

	private void method_4()
	{
		method_3()?.Reload();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			toolTip_0.SetToolTip(this, null);
			if (contextMenuStrip_0 != null)
			{
				contextMenuStrip_0.Opening -= contextMenuStrip_0_Opening;
				contextMenuStrip_0.Dispose();
			}
		}
		base.Dispose(disposing);
	}
}
