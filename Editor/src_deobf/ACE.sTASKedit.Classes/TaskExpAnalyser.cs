using System;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Classes;

internal class TaskExpAnalyser
{
	private int int_0;

	public char[] sentence;

	public TASK_EXPRESSION[] exp_arr;

	public bool Analyse(char[] szSentence)
	{
		int_0 = 0;
		sentence = szSentence;
		exp_arr = new TASK_EXPRESSION[0];
		return method_0();
	}

	private bool method_0()
	{
		if (!method_1())
		{
			return false;
		}
		while (true)
		{
			if (sentence[int_0] == '+' || sentence[int_0] == '-')
			{
				TASK_EXPRESSION tASK_EXPRESSION = new TASK_EXPRESSION();
				tASK_EXPRESSION.type = 2;
				tASK_EXPRESSION.value = (int)sentence[int_0++];
				if (!method_1())
				{
					break;
				}
				exp_arr = method_3(exp_arr, tASK_EXPRESSION);
				continue;
			}
			return true;
		}
		return false;
	}

	private bool method_1()
	{
		if (!method_2())
		{
			return false;
		}
		while (true)
		{
			if (sentence[int_0] == '*' || sentence[int_0] == '/')
			{
				TASK_EXPRESSION tASK_EXPRESSION = new TASK_EXPRESSION();
				tASK_EXPRESSION.type = 2;
				tASK_EXPRESSION.value = (int)sentence[int_0++];
				if (!method_2())
				{
					break;
				}
				exp_arr = method_3(exp_arr, tASK_EXPRESSION);
				continue;
			}
			return true;
		}
		return false;
	}

	private bool method_2()
	{
		if (sentence[int_0] == '(')
		{
			int_0++;
			if (!method_0())
			{
				return false;
			}
			if (sentence[int_0++] != ')')
			{
				return false;
			}
			return true;
		}
		bool flag = false;
		if (sentence[int_0] == '$')
		{
			int_0++;
			flag = true;
		}
		if (sentence[int_0] != '-' && !char.IsDigit(sentence[int_0]))
		{
			return false;
		}
		TASK_EXPRESSION tASK_EXPRESSION = new TASK_EXPRESSION();
		tASK_EXPRESSION.type = ((!flag) ? 1 : 0);
		tASK_EXPRESSION.value = method_4(sentence, ref int_0);
		exp_arr = method_3(exp_arr, tASK_EXPRESSION);
		return true;
	}

	private TASK_EXPRESSION[] method_3(TASK_EXPRESSION[] task_EXPRESSION_0, TASK_EXPRESSION task_EXPRESSION_1)
	{
		TASK_EXPRESSION[] array = new TASK_EXPRESSION[task_EXPRESSION_0.Length + 1];
		for (int i = 0; i < task_EXPRESSION_0.Length; i++)
		{
			array[i] = new TASK_EXPRESSION();
			array[i].type = task_EXPRESSION_0[i].type;
			array[i].value = task_EXPRESSION_0[i].value;
		}
		array[task_EXPRESSION_0.Length] = new TASK_EXPRESSION();
		array[task_EXPRESSION_0.Length].type = task_EXPRESSION_1.type;
		array[task_EXPRESSION_0.Length].value = task_EXPRESSION_1.value;
		return array;
	}

	private float method_4(char[] char_0, ref int int_1)
	{
		string text = string.Empty;
		if (char_0[int_1] == '-')
		{
			text += char_0[int_1];
			int_1++;
		}
		while (char_0[int_1] != '-' && char_0[int_1] != '+' && char_0[int_1] != '*' && char_0[int_1] != '/' && char_0[int_1] != '(' && char_0[int_1] != ')' && char_0[int_1] != 0)
		{
			text = ((char_0[int_1] == '.') ? (text + Class16.smethod_0(1648928028)) : (text + char_0[int_1]));
			int_1++;
		}
		return Convert.ToSingle(text);
	}
}
