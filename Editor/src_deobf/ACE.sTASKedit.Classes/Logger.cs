using System;
using System.IO;

namespace ACE.sTASKedit.Classes;

public static class Logger
{
	private static readonly object object_0 = new object();

	private static readonly string string_0 = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Class16.smethod_0(1649260381));

	public static void Log(string message, string className = "", string methodName = "")
	{
		lock (object_0)
		{
			string text = DateTime.Now.ToString(Class16.smethod_0(1649260397));
			string text2 = Class16.smethod_0(1648924364) + text + Class16.smethod_0(1648924347) + className + Class16.smethod_0(1649008377) + methodName + Class16.smethod_0(1648942627) + message;
			File.AppendAllText(string_0, text2 + Environment.NewLine);
		}
	}
}
