using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.Classes;

internal static class SshIntegration
{
	private sealed class Class88 : IEnumerable, IEnumerable<string>, IEnumerator<string>, IEnumerator, IDisposable
	{
		private int int_0;

		private string string_0;

		private int int_1;

		private string string_1;

		public string string_2;

		private string string_3;

		string IEnumerator<string>.Current
		{
			[DebuggerHidden]
			get
			{
				return string_0;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return string_0;
			}
		}

		[DebuggerHidden]
		public Class88(int int_2)
		{
			int_0 = int_2;
			int_1 = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			string_3 = null;
			int_0 = -2;
		}

		private bool MoveNext()
		{
			string folderPath;
			switch (int_0)
			{
			default:
				return false;
			case 0:
			{
				int_0 = -1;
				string value = smethod_1(string_1);
				if (!string.IsNullOrWhiteSpace(value))
				{
					string_0 = value;
					int_0 = 1;
					return true;
				}
				goto IL_0051;
			}
			case 1:
				int_0 = -1;
				goto IL_0051;
			case 2:
				int_0 = -1;
				goto IL_0096;
			case 3:
				{
					int_0 = -1;
					break;
				}
				IL_0096:
				folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
				if (!string.IsNullOrWhiteSpace(folderPath) && !string.Equals(folderPath, string_3, StringComparison.OrdinalIgnoreCase))
				{
					string_0 = System.IO.Path.Combine(folderPath, Class16.smethod_0(1648901938));
					int_0 = 3;
					return true;
				}
				break;
				IL_0051:
				string_3 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
				if (!string.IsNullOrWhiteSpace(string_3))
				{
					string_0 = System.IO.Path.Combine(string_3, Class16.smethod_0(1648901938));
					int_0 = 2;
					return true;
				}
				goto IL_0096;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			Class88 @class;
			if (int_0 == -2 && int_1 == Environment.CurrentManagedThreadId)
			{
				int_0 = 0;
				@class = this;
			}
			else
			{
				@class = new Class88(0);
			}
			@class.string_1 = string_2;
			return @class;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<string>)this).GetEnumerator();
		}
	}

	public const string DefaultRestartCommand = "sh /pw/restart_gs.sh";

	public static string GetUserDataDirectory()
	{
		return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Class16.smethod_0(1648898197), Class16.smethod_0(1648898209), Class16.smethod_0(1648901958));
	}

	public static string GetUserCommandPath(string fileName)
	{
		return System.IO.Path.Combine(GetUserDataDirectory(), fileName);
	}

	public static void EnsureUserCommandTemplates(SettingsClass defaultProfile, string startupPath)
	{
		string userDataDirectory = GetUserDataDirectory();
		Directory.CreateDirectory(userDataDirectory);
		string userCommandPath = GetUserCommandPath(Class16.smethod_0(1648901960));
		string userCommandPath2 = GetUserCommandPath(Class16.smethod_0(1648901989));
		if (defaultProfile == null || !defaultProfile.GetSetting(Class16.smethod_0(1648902006), Default: false))
		{
			string path = System.IO.Path.Combine(startupPath ?? string.Empty, Class16.smethod_0(1648901958));
			string string_ = smethod_2(System.IO.Path.Combine(path, Class16.smethod_0(1648901960)), Class16.smethod_0(1648902039));
			string string_2 = smethod_2(System.IO.Path.Combine(path, Class16.smethod_0(1648901989)), string.Empty);
			smethod_4(userCommandPath, string_);
			smethod_4(userCommandPath2, string_2);
			defaultProfile?.SaveSetting(defaultProfile.DefaultSection, Class16.smethod_0(1648902006), true);
		}
		else
		{
			smethod_3(userCommandPath, Class16.smethod_0(1648902039));
			smethod_3(userCommandPath2, string.Empty);
		}
	}

	public static string LoadCommandTemplate(string path, string fallback)
	{
		return smethod_2(path, fallback);
	}

	public static void SaveCommandTemplate(string path, string contents)
	{
		if (string.IsNullOrWhiteSpace(path))
		{
			throw new ArgumentException(Class16.smethod_0(1648902058), Class16.smethod_0(1648902110));
		}
		string directoryName = System.IO.Path.GetDirectoryName(path);
		if (!string.IsNullOrWhiteSpace(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
		File.WriteAllText(path, contents ?? string.Empty);
	}

	public static string ResolveExecutablePath(string configuredToolsDirectory, string executableName)
	{
		if (string.IsNullOrWhiteSpace(executableName))
		{
			return null;
		}
		foreach (string item in smethod_0(configuredToolsDirectory))
		{
			string text = System.IO.Path.Combine(item, executableName);
			if (File.Exists(text))
			{
				return text;
			}
		}
		return null;
	}

	private static IEnumerable<string> smethod_0(string string_0)
	{
		return new Class88(-2)
		{
			string_2 = string_0
		};
	}

	private static string smethod_1(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return null;
		}
		return string_0.Trim().Trim('"');
	}

	private static string smethod_2(string string_0, string string_1)
	{
		if (!string.IsNullOrWhiteSpace(string_0) && File.Exists(string_0))
		{
			string text = File.ReadAllText(string_0);
			if (text != null)
			{
				return text;
			}
		}
		return string_1 ?? string.Empty;
	}

	private static void smethod_3(string string_0, string string_1)
	{
		if (!File.Exists(string_0))
		{
			SaveCommandTemplate(string_0, string_1);
		}
	}

	private static void smethod_4(string string_0, string string_1)
	{
		if (File.Exists(string_0))
		{
			string value = File.ReadAllText(string_0);
			if (!string.IsNullOrWhiteSpace(value))
			{
				return;
			}
		}
		SaveCommandTemplate(string_0, string_1);
	}
}
