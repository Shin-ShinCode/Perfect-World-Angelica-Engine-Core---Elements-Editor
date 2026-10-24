using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.AIPolicyEditor.AIPolicy.Conditions;

public class ConditionControl : UserControl
{
	[Serializable]
	private sealed class Class20
	{
		public static readonly Class20 class20_0 = new Class20();

		public static Func<object, string> func_0;

		internal string method_0(object object_0)
		{
			object obj;
			if (object_0 == null)
			{
				obj = null;
			}
			else
			{
				obj = object_0.ToString();
				if (obj != null)
				{
					goto IL_0015;
				}
			}
			obj = string.Empty;
			goto IL_0015;
			IL_0015:
			return (string)obj;
		}
	}

	public bool IsCentral;

	private Condition condition_0;

	private IContainer icontainer_0;

	private Panel panel_0;

	private FlowLayoutPanel flowLayoutPanel_0;

	public Condition Cond
	{
		get
		{
			return condition_0;
		}
		set
		{
			if (condition_0 != value)
			{
				condition_0 = value;
				Reload();
			}
		}
	}

	public ConditionControl()
	{
		method_6();
		flowLayoutPanel_0.BackColor = smethod_6();
		flowLayoutPanel_0.Padding = new Padding(4);
		flowLayoutPanel_0.WrapContents = true;
		flowLayoutPanel_0.FlowDirection = FlowDirection.LeftToRight;
	}

	private static Color smethod_0()
	{
		if (!TDark.IsDarkMode)
		{
			return Color.FromArgb(180, 195, 215);
		}
		return Color.FromArgb(70, 70, 70);
	}

	private static Color smethod_1()
	{
		if (!TDark.IsDarkMode)
		{
			return Color.FromArgb(100, 150, 200);
		}
		return Color.FromArgb(50, 100, 140);
	}

	private static Color smethod_2()
	{
		if (!TDark.IsDarkMode)
		{
			return Color.FromArgb(136, 170, 210);
		}
		return Color.FromArgb(78, 98, 122);
	}

	private static Color smethod_3()
	{
		if (!TDark.IsDarkMode)
		{
			return Color.FromArgb(86, 136, 196);
		}
		return Color.FromArgb(70, 130, 170);
	}

	private static Color smethod_4()
	{
		if (!TDark.IsDarkMode)
		{
			return Color.FromArgb(32, 32, 32);
		}
		return Color.White;
	}

	private static Color smethod_5()
	{
		if (!TDark.IsDarkMode)
		{
			return Color.FromArgb(0, 74, 148);
		}
		return Color.FromArgb(220, 240, 255);
	}

	private static Color smethod_6()
	{
		if (!TDark.IsDarkMode)
		{
			return Color.FromArgb(230, 235, 242);
		}
		return Color.FromArgb(45, 45, 45);
	}

	private static Color smethod_7()
	{
		if (!TDark.IsDarkMode)
		{
			return Color.FromArgb(215, 222, 232);
		}
		return Color.FromArgb(60, 60, 60);
	}

	public void Reload()
	{
		flowLayoutPanel_0.SuspendLayout();
		for (int num = flowLayoutPanel_0.Controls.Count - 1; num >= 0; num--)
		{
			Control control = flowLayoutPanel_0.Controls[num];
			flowLayoutPanel_0.Controls.RemoveAt(num);
			control.Dispose();
		}
		if (Cond != null)
		{
			method_0(Cond, null, ConditionBranchSide.None, flowLayoutPanel_0, IsCentral, bool_1: true, new HashSet<Condition>());
		}
		flowLayoutPanel_0.ResumeLayout(performLayout: true);
	}

	private void method_0(Condition condition_1, Condition condition_2, ConditionBranchSide conditionBranchSide_0, Control control_0, bool bool_0, bool bool_1, HashSet<Condition> hashSet_0)
	{
		if (condition_1 == null)
		{
			control_0.Controls.Add(method_1(Class16.smethod_0(1648942867)));
			return;
		}
		if (!hashSet_0.Add(condition_1))
		{
			control_0.Controls.Add(method_1(Class16.smethod_0(1648942875)));
			return;
		}
		bool flag;
		if (flag = condition_1.Type == 1 && !bool_1)
		{
			control_0.Controls.Add(method_1(Class16.smethod_0(1648942889)));
		}
		if (condition_1.Type == 1)
		{
			Condition condition = condition_1;
			if (condition.ConditionLeft == null)
			{
				condition.ConditionLeft = Conditions.CreateEmpty();
			}
			if (Conditions.IsNonCentral(condition_1.ConditionLeft.ID))
			{
				control_0.Controls.Add(method_2(condition_1.ConditionLeft, bool_0: false, condition_1, ConditionBranchSide.Left));
			}
			else
			{
				method_0(condition_1.ConditionLeft, condition_1, ConditionBranchSide.Left, control_0, bool_0: false, bool_1: false, hashSet_0);
			}
		}
		control_0.Controls.Add(method_2(condition_1, bool_0, condition_2, conditionBranchSide_0));
		if (condition_1.Type <= 2)
		{
			Condition condition = condition_1;
			if (condition.ConditionRight == null)
			{
				condition.ConditionRight = Conditions.CreateEmpty();
			}
			if (Conditions.IsNonCentral(condition_1.ConditionRight.ID))
			{
				control_0.Controls.Add(method_2(condition_1.ConditionRight, bool_0: false, condition_1, ConditionBranchSide.Right));
			}
			else
			{
				method_0(condition_1.ConditionRight, condition_1, ConditionBranchSide.Right, control_0, bool_0: false, bool_1: false, hashSet_0);
			}
		}
		if (flag)
		{
			control_0.Controls.Add(method_1(Class16.smethod_0(1648942897)));
		}
		hashSet_0.Remove(condition_1);
	}

	private Control method_1(string string_0)
	{
		return new Label
		{
			Text = string_0,
			AutoSize = true,
			Font = new Font(Class16.smethod_0(1648942905), 12f, FontStyle.Bold),
			ForeColor = (TDark.IsDarkMode ? Color.LightGray : Color.Gray),
			Margin = new Padding(0, 9, 0, 9),
			Padding = new Padding(0),
			TextAlign = ContentAlignment.MiddleCenter
		};
	}

	private Control method_2(Condition condition_1, bool bool_0, Condition condition_2, ConditionBranchSide conditionBranchSide_0)
	{
		string text = smethod_8(condition_1);
		ConditionLabel conditionLabel = new ConditionLabel(condition_1)
		{
			Text = text,
			Font = new Font(Class16.smethod_0(1648942905), 9.5f, FontStyle.Bold),
			ForeColor = smethod_4(),
			BackColor = (bool_0 ? smethod_1() : smethod_0()),
			ParentCondition = condition_2,
			BranchSide = conditionBranchSide_0,
			IsEmphasized = bool_0,
			MaximumSize = new Size(Math.Max(220, panel_0.ClientSize.Width - 32), 0)
		};
		conditionLabel.MouseEnter += method_3;
		conditionLabel.MouseLeave += method_4;
		conditionLabel.MouseUp += method_5;
		return conditionLabel;
	}

	private static string smethod_8(Condition condition_1)
	{
		string name = Conditions.GetName(condition_1.ID);
		if (condition_1.Value != null && condition_1.Value.Length != 0)
		{
			string text = string.Join(Class16.smethod_0(1648942920), condition_1.Value.Select(Class20.class20_0.method_0));
			return name + Class16.smethod_0(1648942889) + text + Class16.smethod_0(1648942897);
		}
		return name;
	}

	private void method_3(object sender, EventArgs e)
	{
		if (sender is ConditionLabel conditionLabel)
		{
			conditionLabel.ForeColor = smethod_5();
			conditionLabel.BackColor = (conditionLabel.IsEmphasized ? smethod_3() : smethod_2());
		}
		flowLayoutPanel_0.BackColor = smethod_7();
	}

	private void method_4(object sender, EventArgs e)
	{
		if (sender is ConditionLabel conditionLabel)
		{
			conditionLabel.ForeColor = smethod_4();
			conditionLabel.BackColor = (conditionLabel.IsEmphasized ? smethod_1() : smethod_0());
		}
		flowLayoutPanel_0.BackColor = smethod_6();
	}

	private void method_5(object sender, MouseEventArgs e)
	{
		if (e.Button != MouseButtons.Left || !(sender is ConditionLabel { cond: not null } conditionLabel))
		{
			return;
		}
		ConditionEditForm conditionEditForm = new ConditionEditForm(conditionLabel.cond);
		try
		{
			if (conditionEditForm.ShowDialog(FindForm()) == DialogResult.OK)
			{
				Reload();
			}
		}
		finally
		{
			((IDisposable)conditionEditForm).Dispose();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_6()
	{
		panel_0 = new Panel();
		flowLayoutPanel_0 = new FlowLayoutPanel();
		panel_0.SuspendLayout();
		SuspendLayout();
		panel_0.AutoScroll = true;
		panel_0.BackColor = Color.Transparent;
		panel_0.Controls.Add(flowLayoutPanel_0);
		panel_0.Dock = DockStyle.Fill;
		panel_0.ForeColor = SystemColors.ControlText;
		panel_0.Location = new Point(4, 4);
		panel_0.Margin = new Padding(0);
		panel_0.Name = Class16.smethod_0(1648942929);
		panel_0.Size = new Size(592, 36);
		panel_0.TabIndex = 0;
		flowLayoutPanel_0.AutoSize = true;
		flowLayoutPanel_0.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		flowLayoutPanel_0.BackColor = SystemColors.Control;
		flowLayoutPanel_0.Dock = DockStyle.Fill;
		flowLayoutPanel_0.Location = new Point(0, 0);
		flowLayoutPanel_0.Margin = new Padding(0);
		flowLayoutPanel_0.MinimumSize = new Size(600, 36);
		flowLayoutPanel_0.Name = Class16.smethod_0(1648942947);
		flowLayoutPanel_0.Size = new Size(600, 36);
		flowLayoutPanel_0.TabIndex = 0;
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		AutoSize = true;
		base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		BackColor = Color.Transparent;
		base.Controls.Add(panel_0);
		Font = new Font(Class16.smethod_0(1648942905), 9f);
		MinimumSize = new Size(600, 44);
		base.Name = Class16.smethod_0(1648942963);
		base.Padding = new Padding(4);
		base.Size = new Size(600, 44);
		panel_0.ResumeLayout(performLayout: false);
		panel_0.PerformLayout();
		ResumeLayout(performLayout: false);
	}
}
