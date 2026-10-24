using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Xml;
using ACE.Classes;
using Sentry;

namespace ACE.License;

public static class LicenseCredentials
{
	[Serializable]
	public class SavedCredentials
	{
		public int Version { get; set; } = 2;

		public string Email { get; set; }

		public string ProtectedPassword { get; set; }

		public string EncryptedPassword { get; set; }

		public string IV { get; set; }

		public DateTime SavedAt { get; set; }
	}

	private static readonly string string_0 = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Class16.smethod_0(1648898132), Class16.smethod_0(1649047811));

	private static readonly object object_0 = new object();

	private static readonly byte[] byte_0 = Encoding.UTF8.GetBytes(Class16.smethod_0(1649047833));

	private static readonly byte[] byte_1 = Encoding.UTF8.GetBytes(Class16.smethod_0(1649047872));

	public static bool SaveCredentials(string email, string password)
	{
		if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
		{
			try
			{
				string directoryName = System.IO.Path.GetDirectoryName(string_0);
				if (!string.IsNullOrEmpty(directoryName) && !Directory.Exists(directoryName))
				{
					Directory.CreateDirectory(directoryName);
				}
				byte[] bytes = Encoding.UTF8.GetBytes(password);
				byte[] array = ProtectedData.Protect(bytes, byte_0, DataProtectionScope.CurrentUser);
				smethod_7(bytes);
				SavedCredentials savedCredentials_ = new SavedCredentials
				{
					Version = 2,
					Email = email.Trim(),
					ProtectedPassword = Convert.ToBase64String(array),
					EncryptedPassword = null,
					IV = null,
					SavedAt = DateTime.UtcNow
				};
				smethod_7(array);
				lock (object_0)
				{
					IOException ex = null;
					for (int i = 0; i < 3; i++)
					{
						string text = string_0 + Class16.smethod_0(1648928036) + Guid.NewGuid().ToString(Class16.smethod_0(1648930778)) + Class16.smethod_0(1648930786);
						try
						{
							FileStream fileStream = new FileStream(text, FileMode.Create, FileAccess.Write, FileShare.None);
							try
							{
								smethod_0(fileStream, savedCredentials_);
								fileStream.Flush(flushToDisk: true);
							}
							finally
							{
								((IDisposable)fileStream).Dispose();
							}
							if (File.Exists(string_0))
							{
								File.Replace(text, string_0, null, ignoreMetadataErrors: true);
							}
							else
							{
								File.Move(text, string_0);
							}
							return true;
						}
						catch (IOException ex2) when (smethod_5(ex2) && i + 1 < 3)
						{
							ex = ex2;
							Thread.Sleep(150);
						}
						catch (IOException ex3) when (smethod_5(ex3))
						{
							ex = ex3;
							break;
						}
						finally
						{
							smethod_6(text);
						}
					}
					if (ex != null)
					{
						SentryHelper.CaptureMessage(Class16.smethod_0(1649047907) + ex.Message, (SentryLevel)2, Class16.smethod_0(1649047962));
					}
				}
				return false;
			}
			catch (Exception ex4)
			{
				SentryHelper.CaptureException(ex4, Class16.smethod_0(1649048010));
				return false;
			}
		}
		return false;
	}

	public static bool TryLoadCredentials(out string email, out string password)
	{
		email = null;
		password = null;
		if (!File.Exists(string_0))
		{
			return false;
		}
		try
		{
			SavedCredentials savedCredentials_ = null;
			bool flag = false;
			bool flag2 = false;
			lock (object_0)
			{
				if (!File.Exists(string_0))
				{
					return false;
				}
				IOException ex = null;
				for (int i = 0; i < 3; i++)
				{
					try
					{
						FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
						try
						{
							if (!smethod_1(fileStream, out savedCredentials_))
							{
								flag = true;
							}
						}
						finally
						{
							((IDisposable)fileStream).Dispose();
						}
						flag2 = true;
					}
					catch (IOException ex2) when (smethod_5(ex2) && i + 1 < 3)
					{
						ex = ex2;
						Thread.Sleep(150);
						continue;
					}
					catch (IOException ex3) when (smethod_5(ex3))
					{
						ex = ex3;
					}
					break;
				}
				if (!flag2)
				{
					if (ex != null)
					{
						SentryHelper.CaptureMessage(Class16.smethod_0(1649048051) + ex.Message, (SentryLevel)2, Class16.smethod_0(1649043000));
					}
					return false;
				}
			}
			if (flag)
			{
				ClearCredentials();
				return false;
			}
			if (savedCredentials_ != null && !string.IsNullOrWhiteSpace(savedCredentials_.Email) && (!string.IsNullOrWhiteSpace(savedCredentials_.ProtectedPassword) || (!string.IsNullOrWhiteSpace(savedCredentials_.EncryptedPassword) && !string.IsNullOrWhiteSpace(savedCredentials_.IV))))
			{
				bool flag3;
				if (!(flag3 = smethod_2(savedCredentials_.ProtectedPassword, out var string_)) && (flag3 = smethod_3(savedCredentials_, out string_)))
				{
					SaveCredentials(savedCredentials_.Email, string_);
				}
				if (flag3 && !string.IsNullOrWhiteSpace(string_))
				{
					email = savedCredentials_.Email;
					password = string_;
					return true;
				}
				return false;
			}
			ClearCredentials();
			return false;
		}
		catch (IOException ex4) when (smethod_5(ex4))
		{
			SentryHelper.CaptureMessage(Class16.smethod_0(1649048051) + ex4.Message, (SentryLevel)2, Class16.smethod_0(1649043000));
			return false;
		}
		catch (Exception ex5)
		{
			SentryHelper.CaptureException(ex5, Class16.smethod_0(1649043051));
			ClearCredentials();
			return false;
		}
	}

	public static void ClearCredentials()
	{
		try
		{
			lock (object_0)
			{
				if (!File.Exists(string_0))
				{
					return;
				}
				IOException ex = null;
				for (int i = 0; i < 3; i++)
				{
					try
					{
						try
						{
							long length = new FileInfo(string_0).Length;
							if (length > 0L && length <= 2147483647L)
							{
								byte[] array = new byte[(int)length];
								using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
								{
									randomNumberGenerator.GetBytes(array);
								}
								FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Write, FileShare.None);
								try
								{
									fileStream.Write(array, 0, array.Length);
									fileStream.Flush(flushToDisk: true);
								}
								finally
								{
									((IDisposable)fileStream).Dispose();
								}
								smethod_7(array);
							}
						}
						catch
						{
						}
						File.Delete(string_0);
						return;
					}
					catch (IOException ex2) when (smethod_5(ex2) && i + 1 < 3)
					{
						ex = ex2;
						Thread.Sleep(150);
					}
					catch (IOException ex3) when (smethod_5(ex3))
					{
						ex = ex3;
						break;
					}
				}
				if (ex != null)
				{
					SentryHelper.CaptureMessage(Class16.smethod_0(1649043103) + ex.Message, (SentryLevel)2, Class16.smethod_0(1649043173));
				}
			}
		}
		catch (Exception ex4)
		{
			SentryHelper.CaptureException(ex4, Class16.smethod_0(1649043222));
		}
	}

	public static bool HasSavedCredentials()
	{
		return File.Exists(string_0);
	}

	private static void smethod_0(Stream stream_0, SavedCredentials savedCredentials_0)
	{
		StreamWriter streamWriter = new StreamWriter(stream_0, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false), 1024, leaveOpen: true);
		try
		{
			streamWriter.Write(Class16.smethod_0(1649043256));
			streamWriter.WriteLine();
			streamWriter.Flush();
		}
		finally
		{
			((IDisposable)streamWriter).Dispose();
		}
		XmlWriterSettings settings = new XmlWriterSettings
		{
			Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false),
			OmitXmlDeclaration = true,
			Indent = true,
			IndentChars = Class16.smethod_0(1649043292),
			NewLineChars = Environment.NewLine,
			NewLineHandling = NewLineHandling.Replace,
			CloseOutput = false
		};
		using XmlWriter xmlWriter = XmlWriter.Create(stream_0, settings);
		xmlWriter.WriteStartElement(Class16.smethod_0(1649043301));
		xmlWriter.WriteAttributeString(Class16.smethod_0(1649043324), Class16.smethod_0(1649043328), null, Class16.smethod_0(1649043338));
		xmlWriter.WriteAttributeString(Class16.smethod_0(1649043324), Class16.smethod_0(1649043377), null, Class16.smethod_0(1649043387));
		xmlWriter.WriteElementString(Class16.smethod_0(1648942674), savedCredentials_0.Version.ToString(CultureInfo.InvariantCulture));
		xmlWriter.WriteElementString(Class16.smethod_0(1649045679), savedCredentials_0.Email ?? string.Empty);
		if (!string.IsNullOrWhiteSpace(savedCredentials_0.ProtectedPassword))
		{
			xmlWriter.WriteElementString(Class16.smethod_0(1649043435), savedCredentials_0.ProtectedPassword);
		}
		if (!string.IsNullOrWhiteSpace(savedCredentials_0.EncryptedPassword))
		{
			xmlWriter.WriteElementString(Class16.smethod_0(1649042435), savedCredentials_0.EncryptedPassword);
		}
		if (!string.IsNullOrWhiteSpace(savedCredentials_0.IV))
		{
			xmlWriter.WriteElementString(Class16.smethod_0(1649042459), savedCredentials_0.IV);
		}
		if (savedCredentials_0.SavedAt != default(DateTime))
		{
			xmlWriter.WriteElementString(Class16.smethod_0(1649042476), savedCredentials_0.SavedAt.ToUniversalTime().ToString(Class16.smethod_0(1649042482), CultureInfo.InvariantCulture));
		}
		xmlWriter.WriteEndElement();
		xmlWriter.Flush();
	}

	private static bool smethod_1(Stream stream_0, out SavedCredentials savedCredentials_0)
	{
		savedCredentials_0 = null;
		try
		{
			XmlReaderSettings settings = new XmlReaderSettings
			{
				DtdProcessing = DtdProcessing.Prohibit,
				XmlResolver = null,
				MaxCharactersFromEntities = 1024L
			};
			using XmlReader xmlReader = XmlReader.Create(stream_0, settings);
			xmlReader.MoveToContent();
			if (xmlReader.NodeType == XmlNodeType.Element && string.Equals(xmlReader.LocalName, Class16.smethod_0(1649043301), StringComparison.Ordinal))
			{
				savedCredentials_0 = new SavedCredentials();
				if (xmlReader.IsEmptyElement)
				{
					return true;
				}
				int depth = xmlReader.Depth;
				while (true)
				{
					if (xmlReader.Read())
					{
						if (xmlReader.NodeType != XmlNodeType.EndElement || xmlReader.Depth != depth || !string.Equals(xmlReader.LocalName, Class16.smethod_0(1649043301), StringComparison.Ordinal))
						{
							if (xmlReader.NodeType != XmlNodeType.Element || xmlReader.Depth != depth + 1)
							{
								continue;
							}
							string localName = xmlReader.LocalName;
							string text = xmlReader.ReadElementContentAsString();
							int result2;
							if (!(localName == Class16.smethod_0(1648942674)))
							{
								if (!(localName == Class16.smethod_0(1649045679)))
								{
									if (!(localName == Class16.smethod_0(1649043435)))
									{
										if (!(localName == Class16.smethod_0(1649042435)))
										{
											if (!(localName == Class16.smethod_0(1649042459)))
											{
												if (localName == Class16.smethod_0(1649042476) && DateTime.TryParse(text, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var result))
												{
													savedCredentials_0.SavedAt = ((result.Kind == DateTimeKind.Utc) ? result : result.ToUniversalTime());
												}
											}
											else
											{
												savedCredentials_0.IV = text;
											}
										}
										else
										{
											savedCredentials_0.EncryptedPassword = text;
										}
									}
									else
									{
										savedCredentials_0.ProtectedPassword = text;
									}
								}
								else
								{
									savedCredentials_0.Email = text;
								}
							}
							else if (int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out result2))
							{
								savedCredentials_0.Version = result2;
							}
							if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Depth == depth && string.Equals(xmlReader.LocalName, Class16.smethod_0(1649043301), StringComparison.Ordinal))
							{
								break;
							}
							continue;
						}
						return true;
					}
					return false;
				}
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649042490));
			savedCredentials_0 = null;
			return false;
		}
	}

	private static bool smethod_2(string string_1, out string string_2)
	{
		string_2 = null;
		if (string.IsNullOrWhiteSpace(string_1))
		{
			return false;
		}
		byte[] array = null;
		byte[] array2 = null;
		try
		{
			array = Convert.FromBase64String(string_1);
			array2 = ProtectedData.Unprotect(array, byte_0, DataProtectionScope.CurrentUser);
			string_2 = Encoding.UTF8.GetString(array2);
			return !string.IsNullOrWhiteSpace(string_2);
		}
		catch
		{
			return false;
		}
		finally
		{
			if (array != null && array.Length != 0)
			{
				smethod_7(array);
			}
			if (array2 != null && array2.Length != 0)
			{
				smethod_7(array2);
			}
		}
	}

	private static bool smethod_3(SavedCredentials savedCredentials_0, out string string_1)
	{
		string_1 = null;
		if (savedCredentials_0 != null && !string.IsNullOrWhiteSpace(savedCredentials_0.EncryptedPassword) && !string.IsNullOrWhiteSpace(savedCredentials_0.IV))
		{
			byte[] array = null;
			byte[] array2 = null;
			byte[] array3 = null;
			byte[] array4 = null;
			try
			{
				array = smethod_4();
				array2 = Convert.FromBase64String(savedCredentials_0.IV);
				array3 = Convert.FromBase64String(savedCredentials_0.EncryptedPassword);
				using Aes aes = Aes.Create();
				aes.Key = array;
				aes.IV = array2;
				using (ICryptoTransform transform = aes.CreateDecryptor())
				{
					MemoryStream memoryStream = new MemoryStream(array3);
					try
					{
						CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
						try
						{
							MemoryStream memoryStream2 = new MemoryStream();
							try
							{
								cryptoStream.CopyTo(memoryStream2);
								array4 = memoryStream2.ToArray();
							}
							finally
							{
								((IDisposable)memoryStream2).Dispose();
							}
						}
						finally
						{
							((IDisposable)cryptoStream).Dispose();
						}
					}
					finally
					{
						((IDisposable)memoryStream).Dispose();
					}
				}
				string_1 = Encoding.UTF8.GetString(array4);
				return !string.IsNullOrWhiteSpace(string_1);
			}
			catch
			{
				return false;
			}
			finally
			{
				if (array != null && array.Length != 0)
				{
					smethod_7(array);
				}
				if (array2 != null && array2.Length != 0)
				{
					smethod_7(array2);
				}
				if (array3 != null && array3.Length != 0)
				{
					smethod_7(array3);
				}
				if (array4 != null && array4.Length != 0)
				{
					smethod_7(array4);
				}
			}
		}
		return false;
	}

	private static byte[] smethod_4()
	{
		string s = Environment.MachineName + Class16.smethod_0(1648905535) + Environment.UserName + Class16.smethod_0(1649042537);
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		try
		{
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(bytes, byte_1, 10000, HashAlgorithmName.SHA256);
			try
			{
				return rfc2898DeriveBytes.GetBytes(32);
			}
			finally
			{
				((IDisposable)rfc2898DeriveBytes).Dispose();
			}
		}
		finally
		{
			smethod_7(bytes);
		}
	}

	private static bool smethod_5(IOException ioexception_0)
	{
		int num = ioexception_0.HResult & 0xFFFF;
		if (num != 32)
		{
			return num == 33;
		}
		return true;
	}

	private static void smethod_6(string string_1)
	{
		try
		{
			if (!string.IsNullOrWhiteSpace(string_1) && File.Exists(string_1))
			{
				File.Delete(string_1);
			}
		}
		catch
		{
		}
	}

	private static void smethod_7(byte[] byte_2)
	{
		if (byte_2 != null && byte_2.Length != 0)
		{
			Array.Clear(byte_2, 0, byte_2.Length);
		}
	}
}
