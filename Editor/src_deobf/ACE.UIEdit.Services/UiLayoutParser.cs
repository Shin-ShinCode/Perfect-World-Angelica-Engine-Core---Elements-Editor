#nullable enable annotations
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using ACE.UIEdit.Models;

namespace ACE.UIEdit.Services;

internal sealed class UiLayoutParser
{
	private sealed class Class365
	{
		public UiControlModel uiControlModel_0;

		internal bool method_0(string string_0)
		{
			return !string.Equals(string_0, uiControlModel_0.PrimaryImagePath, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class366
	{
		public string string_0;

		internal bool method_0(XmlNode xmlNode_0)
		{
			if (xmlNode_0.NodeType == XmlNodeType.Element)
			{
				return string.Equals(xmlNode_0.Name, string_0, StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}
	}

	private sealed class Class367 : IEnumerable, IEnumerator, IDisposable, IEnumerable<XmlNode>, IEnumerator<XmlNode>
	{
		private int int_0;

		private XmlNode xmlNode_0;

		private int int_1;

		private XmlNode xmlNode_1;

		public XmlNode xmlNode_2;

		private IEnumerator ienumerator_0;

		private XmlNode xmlNode_3;

		private IEnumerator<XmlNode> ienumerator_1;

		XmlNode IEnumerator<XmlNode>.Current
		{
			[DebuggerHidden]
			get
			{
				return xmlNode_0;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return xmlNode_0;
			}
		}

		[DebuggerHidden]
		public Class367(int int_2)
		{
			int_0 = int_2;
			int_1 = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = int_0;
			if ((uint)(num - -4) <= 1u || (uint)(num - 1) <= 1u)
			{
				try
				{
					if (num == -4 || num == 2)
					{
						try
						{
						}
						finally
						{
							method_1();
						}
					}
				}
				finally
				{
					method_0();
				}
			}
			ienumerator_0 = null;
			xmlNode_3 = null;
			ienumerator_1 = null;
			int_0 = -2;
		}

		private bool MoveNext()
		{
			try
			{
				XmlNode current;
				switch (int_0)
				{
				default:
					return false;
				case 0:
					int_0 = -1;
					ienumerator_0 = xmlNode_1.ChildNodes.GetEnumerator();
					int_0 = -3;
					goto IL_0097;
				case 1:
					int_0 = -3;
					goto IL_00b3;
				case 2:
					{
						int_0 = -4;
						goto IL_00d1;
					}
					IL_0097:
					do
					{
						if (ienumerator_0.MoveNext())
						{
							xmlNode_3 = (XmlNode)ienumerator_0.Current;
							continue;
						}
						method_0();
						ienumerator_0 = null;
						return false;
					}
					while (xmlNode_3.NodeType != XmlNodeType.Element);
					if (smethod_1(xmlNode_3))
					{
						xmlNode_0 = xmlNode_3;
						int_0 = 1;
						return true;
					}
					goto IL_00b3;
					IL_00b3:
					ienumerator_1 = smethod_0(xmlNode_3).GetEnumerator();
					int_0 = -4;
					goto IL_00d1;
					IL_00d1:
					if (!ienumerator_1.MoveNext())
					{
						method_1();
						ienumerator_1 = null;
						xmlNode_3 = null;
						goto IL_0097;
					}
					current = ienumerator_1.Current;
					xmlNode_0 = current;
					int_0 = 2;
					return true;
				}
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void method_0()
		{
			int_0 = -1;
			if (ienumerator_0 is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}

		private void method_1()
		{
			int_0 = -3;
			if (ienumerator_1 != null)
			{
				ienumerator_1.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<XmlNode> IEnumerable<XmlNode>.GetEnumerator()
		{
			Class367 @class;
			if (int_0 == -2 && int_1 == Environment.CurrentManagedThreadId)
			{
				int_0 = 0;
				@class = this;
			}
			else
			{
				@class = new Class367(0);
			}
			@class.xmlNode_1 = xmlNode_2;
			return @class;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<XmlNode>)this).GetEnumerator();
		}
	}

	[Serializable]
	private sealed class Class368
	{
		public static readonly Class368 class368_0 = new Class368();

		public static Func<XmlNode, bool> func_0;

		public static Func<XmlNode, bool> func_1;

		public static Func<XmlNode, bool> func_2;

		public static Func<XmlNode, string> func_3;

		public static Func<string, bool> func_4;

		public static Func<XmlNode, bool> func_5;

		public static MatchEvaluator matchEvaluator_0;

		public static MatchEvaluator matchEvaluator_1;

		internal bool method_0(XmlNode xmlNode_0)
		{
			return xmlNode_0.NodeType == XmlNodeType.Element;
		}

		internal bool method_1(XmlNode xmlNode_0)
		{
			return xmlNode_0.NodeType == XmlNodeType.Element;
		}

		internal bool method_2(XmlNode xmlNode_0)
		{
			return xmlNode_0.NodeType == XmlNodeType.Element;
		}

		internal string method_3(XmlNode xmlNode_0)
		{
			XmlAttributeCollection attributes = xmlNode_0.Attributes;
			object obj;
			if (attributes == null)
			{
				obj = null;
			}
			else
			{
				XmlAttribute xmlAttribute = attributes[Class16.smethod_0(1648936731)];
				if (xmlAttribute == null)
				{
					obj = null;
				}
				else
				{
					obj = xmlAttribute.Value;
					if (obj != null)
					{
						goto IL_0031;
					}
				}
			}
			obj = string.Empty;
			goto IL_0031;
			IL_0031:
			return (string)obj;
		}

		internal bool method_4(string string_0)
		{
			return string_0.Length > 0;
		}

		internal bool method_5(XmlNode xmlNode_0)
		{
			if (xmlNode_0.NodeType == XmlNodeType.Element)
			{
				return string.Equals(xmlNode_0.Name, Class16.smethod_0(1649276694), StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}

		internal string method_6(Match match_0)
		{
			string value = match_0.Groups[1].Value;
			string value2 = match_0.Groups[2].Value;
			string value3 = match_0.Groups[3].Value;
			string text = value3.Replace(Class16.smethod_0(1648936470), Class16.smethod_0(1649276709));
			if (!string.Equals(value3, text, StringComparison.Ordinal))
			{
				return value + value2 + text + value2;
			}
			return match_0.Value;
		}

		internal string method_7(Match match_0)
		{
			string value = match_0.Groups[1].Value;
			string value2 = match_0.Groups[2].Value;
			string value3 = match_0.Groups[3].Value;
			string text = value3.Replace(Class16.smethod_0(1649276709), Class16.smethod_0(1648936470));
			if (!string.Equals(value3, text, StringComparison.Ordinal))
			{
				return value + value2 + text + value2;
			}
			return match_0.Value;
		}
	}

	private static readonly Regex regex_0 = new Regex(Class16.smethod_0(1649276712), RegexOptions.Compiled | RegexOptions.Singleline);

	public bool TryParse(string xmlText, string currentFileDirectory, string surfacesPath, out UiDialogModel dialog, out XmlException? xmlError)
	{
		dialog = new UiDialogModel();
		xmlError = null;
		if (string.IsNullOrWhiteSpace(xmlText))
		{
			xmlError = new XmlException(Class16.smethod_0(1649276757), null, 1, 1);
			return false;
		}
		string xml = smethod_17(xmlText);
		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			XmlElement documentElement = xmlDocument.DocumentElement;
			if (documentElement == null)
			{
				xmlError = new XmlException(Class16.smethod_0(1649276769), null, 1, 1);
				return false;
			}
			dialog.Name = documentElement.GetAttribute(Class16.smethod_0(1648936731));
			if (dialog.Name.Length == 0)
			{
				dialog.Name = documentElement.Name;
			}
			dialog.Width = smethod_13(documentElement.GetAttribute(Class16.smethod_0(1649055454)), 800);
			dialog.Height = smethod_13(documentElement.GetAttribute(Class16.smethod_0(1649055458)), 600);
			dialog.BackgroundImagePath = smethod_9(documentElement, currentFileDirectory, surfacesPath);
			int num = 0;
			foreach (XmlNode item in smethod_0(documentElement))
			{
				UiControlModel uiControlModel = smethod_6(item, currentFileDirectory, surfacesPath);
				if (uiControlModel != null)
				{
					uiControlModel.Layer = num++;
					dialog.Controls.Add(uiControlModel);
				}
			}
			return true;
		}
		catch (XmlException ex)
		{
			xmlError = ex;
			return false;
		}
	}

	public string? UpdateControlBounds(string xmlText, UiControlModel control)
	{
		return UpdateControlModel(xmlText, control);
	}

	public string? UpdateControlModel(string xmlText, UiControlModel control)
	{
		try
		{
			string xml = smethod_17(xmlText);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			XmlElement documentElement = xmlDocument.DocumentElement;
			if (documentElement == null)
			{
				return null;
			}
			XmlNode xmlNode = smethod_2(documentElement, control);
			if (xmlNode == null)
			{
				return null;
			}
			smethod_15(xmlDocument, xmlNode, Class16.smethod_0(1649137079), control.Int32_0.ToString(CultureInfo.InvariantCulture));
			smethod_15(xmlDocument, xmlNode, Class16.smethod_0(1649047684), control.Int32_1.ToString(CultureInfo.InvariantCulture));
			smethod_15(xmlDocument, xmlNode, Class16.smethod_0(1649055454), Math.Max(1, control.Width).ToString(CultureInfo.InvariantCulture));
			smethod_15(xmlDocument, xmlNode, Class16.smethod_0(1649055458), Math.Max(1, control.Height).ToString(CultureInfo.InvariantCulture));
			if (!string.IsNullOrWhiteSpace(control.Color) || xmlNode.Attributes?[Class16.smethod_0(1649085884)] != null)
			{
				smethod_15(xmlDocument, xmlNode, Class16.smethod_0(1649085884), control.Color ?? string.Empty);
			}
			smethod_16(xmlDocument, xmlNode, Class16.smethod_0(1649023959), control.Text);
			smethod_16(xmlDocument, xmlNode, Class16.smethod_0(1649276804), control.Hint);
			if (string.Equals(control.XmlNodeName, Class16.smethod_0(1649276815), StringComparison.OrdinalIgnoreCase))
			{
				smethod_15(xmlDocument, xmlNode, Class16.smethod_0(1649023959), control.Text ?? string.Empty);
			}
			bool flag = Regex.IsMatch(xmlText ?? string.Empty, Class16.smethod_0(1649276818), RegexOptions.IgnoreCase);
			XmlWriterSettings settings = new XmlWriterSettings
			{
				OmitXmlDeclaration = !flag,
				Indent = true,
				IndentChars = Class16.smethod_0(1648904383),
				NewLineHandling = NewLineHandling.Replace,
				NewLineChars = Class16.smethod_0(1648924428)
			};
			StringBuilder stringBuilder = new StringBuilder();
			using (XmlWriter w = XmlWriter.Create(new StringWriter(stringBuilder), settings))
			{
				xmlDocument.Save(w);
			}
			return smethod_19(stringBuilder.ToString());
		}
		catch
		{
			return null;
		}
	}

	public string? RemoveControl(string xmlText, UiControlModel control)
	{
		try
		{
			string xml = smethod_17(xmlText);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			XmlElement documentElement = xmlDocument.DocumentElement;
			if (documentElement == null)
			{
				return null;
			}
			XmlNode xmlNode = smethod_2(documentElement, control);
			if (xmlNode?.ParentNode == null)
			{
				return null;
			}
			xmlNode.ParentNode.RemoveChild(xmlNode);
			return smethod_5(xmlDocument, xmlText);
		}
		catch
		{
			return null;
		}
	}

	public string? DuplicateControl(string xmlText, UiControlModel control, int offsetX, int offsetY)
	{
		try
		{
			string xml = smethod_17(xmlText);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			XmlElement documentElement = xmlDocument.DocumentElement;
			if (documentElement == null)
			{
				return null;
			}
			XmlNode xmlNode = smethod_2(documentElement, control);
			if (xmlNode?.ParentNode == null)
			{
				return null;
			}
			XmlNode xmlNode2 = xmlNode.CloneNode(deep: true);
			XmlAttribute xmlAttribute = xmlNode2.Attributes?[Class16.smethod_0(1648936731)];
			if (xmlAttribute != null)
			{
				xmlAttribute.Value = smethod_3(documentElement, xmlAttribute.Value);
			}
			smethod_4(xmlNode2, offsetX, offsetY);
			xmlNode.ParentNode.InsertAfter(xmlNode2, xmlNode);
			return smethod_5(xmlDocument, xmlText);
		}
		catch
		{
			return null;
		}
	}

	public string? ExportControlXml(string xmlText, UiControlModel control)
	{
		try
		{
			string xml = smethod_17(xmlText);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			XmlElement documentElement = xmlDocument.DocumentElement;
			if (documentElement == null)
			{
				return null;
			}
			return smethod_2(documentElement, control)?.OuterXml;
		}
		catch
		{
			return null;
		}
	}

	public string? InsertControlXml(string xmlText, string controlXml, int targetX, int targetY)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(controlXml))
			{
				return null;
			}
			string xml = smethod_17(xmlText);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			XmlElement documentElement = xmlDocument.DocumentElement;
			if (documentElement == null)
			{
				return null;
			}
			XmlDocument xmlDocument2 = new XmlDocument();
			xmlDocument2.LoadXml(Class16.smethod_0(1649276835) + controlXml + Class16.smethod_0(1649276848));
			XmlNode xmlNode = xmlDocument2.DocumentElement?.ChildNodes.Cast<XmlNode>().FirstOrDefault(Class368.class368_0.method_0);
			if (xmlNode == null)
			{
				return null;
			}
			XmlNode xmlNode2 = xmlDocument.ImportNode(xmlNode, deep: true);
			XmlAttribute xmlAttribute = xmlNode2.Attributes?[Class16.smethod_0(1648936731)];
			if (xmlAttribute != null && xmlAttribute.Value.Length > 0)
			{
				xmlAttribute.Value = smethod_3(documentElement, xmlAttribute.Value);
			}
			int num = smethod_13(xmlNode2.Attributes?[Class16.smethod_0(1649137079)]?.Value, 0);
			int num2 = smethod_13(xmlNode2.Attributes?[Class16.smethod_0(1649047684)]?.Value, 0);
			smethod_4(xmlNode2, targetX - num, targetY - num2);
			documentElement.AppendChild(xmlNode2);
			return smethod_5(xmlDocument, xmlText);
		}
		catch
		{
			return null;
		}
	}

	public string? MoveControlLayer(string xmlText, UiControlModel control, int delta)
	{
		try
		{
			string xml = smethod_17(xmlText);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			XmlElement documentElement = xmlDocument.DocumentElement;
			if (documentElement == null)
			{
				return null;
			}
			XmlNode xmlNode = smethod_2(documentElement, control);
			if (xmlNode?.ParentNode == null)
			{
				return null;
			}
			List<XmlNode> list = xmlNode.ParentNode.ChildNodes.Cast<XmlNode>().Where(Class368.class368_0.method_1).ToList();
			int num = list.IndexOf(xmlNode);
			if (num < 0)
			{
				return null;
			}
			int num2 = delta switch
			{
				int.MaxValue => list.Count - 1, 
				int.MinValue => 0, 
				_ => Math.Min(list.Count - 1, Math.Max(0, num + delta)), 
			};
			if (num2 == num)
			{
				return xmlText;
			}
			XmlNode parentNode = xmlNode.ParentNode;
			parentNode.RemoveChild(xmlNode);
			List<XmlNode> list2 = parentNode.ChildNodes.Cast<XmlNode>().Where(Class368.class368_0.method_2).ToList();
			if (num2 >= list2.Count)
			{
				parentNode.AppendChild(xmlNode);
			}
			else
			{
				parentNode.InsertBefore(xmlNode, list2[num2]);
			}
			return smethod_5(xmlDocument, xmlText);
		}
		catch
		{
			return null;
		}
	}

	public string? FormatXml(string xmlText)
	{
		try
		{
			string xml = smethod_17(xmlText);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			bool flag = Regex.IsMatch(xmlText ?? string.Empty, Class16.smethod_0(1649276818), RegexOptions.IgnoreCase);
			XmlWriterSettings settings = new XmlWriterSettings
			{
				OmitXmlDeclaration = !flag,
				Indent = true,
				IndentChars = Class16.smethod_0(1648904383),
				NewLineHandling = NewLineHandling.Replace,
				NewLineChars = Class16.smethod_0(1648924428)
			};
			StringBuilder stringBuilder = new StringBuilder();
			using (XmlWriter w = XmlWriter.Create(new StringWriter(stringBuilder), settings))
			{
				xmlDocument.Save(w);
			}
			return smethod_19(stringBuilder.ToString());
		}
		catch
		{
			return null;
		}
	}

	private static IEnumerable<XmlNode> smethod_0(XmlNode xmlNode_0)
	{
		return new Class367(-2)
		{
			xmlNode_2 = xmlNode_0
		};
	}

	private static bool smethod_1(XmlNode xmlNode_0)
	{
		if (xmlNode_0.NodeType != XmlNodeType.Element)
		{
			return false;
		}
		XmlAttributeCollection attributes = xmlNode_0.Attributes;
		object obj;
		if (attributes == null)
		{
			obj = null;
		}
		else
		{
			XmlAttribute xmlAttribute = attributes[Class16.smethod_0(1648936731)];
			if (xmlAttribute == null)
			{
				obj = null;
			}
			else
			{
				obj = xmlAttribute.Value;
				if (obj != null)
				{
					goto IL_003c;
				}
			}
		}
		obj = string.Empty;
		goto IL_003c;
		IL_003c:
		string text = (string)obj;
		if (text.Length == 0)
		{
			return false;
		}
		if (!string.Equals(xmlNode_0.Name, Class16.smethod_0(1649276870), StringComparison.OrdinalIgnoreCase) && !string.Equals(xmlNode_0.Name, Class16.smethod_0(1649276873), StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		return false;
	}

	private static XmlNode? smethod_2(XmlNode xmlNode_0, UiControlModel uiControlModel_0)
	{
		foreach (XmlNode childNode in xmlNode_0.ChildNodes)
		{
			if (childNode.NodeType == XmlNodeType.Element)
			{
				if (string.Equals(childNode.Name, uiControlModel_0.XmlNodeName, StringComparison.OrdinalIgnoreCase) && string.Equals(childNode.Attributes?[Class16.smethod_0(1648936731)]?.Value, uiControlModel_0.Name, StringComparison.OrdinalIgnoreCase))
				{
					return childNode;
				}
				XmlNode xmlNode2 = smethod_2(childNode, uiControlModel_0);
				if (xmlNode2 != null)
				{
					return xmlNode2;
				}
			}
		}
		return null;
	}

	private static string smethod_3(XmlElement xmlElement_0, string string_0)
	{
		XmlNodeList xmlNodeList = xmlElement_0.SelectNodes(Class16.smethod_0(1649276888));
		object obj;
		if (xmlNodeList == null)
		{
			obj = null;
		}
		else
		{
			obj = xmlNodeList.Cast<XmlNode>().Select(Class368.class368_0.method_3).Where(Class368.class368_0.method_4)
				.ToHashSet(StringComparer.OrdinalIgnoreCase);
			if (obj != null)
			{
				goto IL_007c;
			}
		}
		obj = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		goto IL_007c;
		IL_007c:
		HashSet<string> hashSet = (HashSet<string>)obj;
		if (!hashSet.Contains(string_0))
		{
			return string_0;
		}
		string text = (string_0.EndsWith(Class16.smethod_0(1649276905), StringComparison.OrdinalIgnoreCase) ? string_0 : (string_0 + Class16.smethod_0(1649276905)));
		int num = 1;
		string text2 = text;
		while (hashSet.Contains(text2))
		{
			num++;
			text2 = string.Format(Class16.smethod_0(1649276925), text, num);
		}
		return text2;
	}

	private static void smethod_4(XmlNode xmlNode_0, int int_0, int int_1)
	{
		int num = smethod_13(xmlNode_0.Attributes?[Class16.smethod_0(1649137079)]?.Value, 0);
		int num2 = smethod_13(xmlNode_0.Attributes?[Class16.smethod_0(1649047684)]?.Value, 0);
		smethod_15(xmlNode_0.OwnerDocument, xmlNode_0, Class16.smethod_0(1649137079), Math.Max(0, num + int_0).ToString(CultureInfo.InvariantCulture));
		smethod_15(xmlNode_0.OwnerDocument, xmlNode_0, Class16.smethod_0(1649047684), Math.Max(0, num2 + int_1).ToString(CultureInfo.InvariantCulture));
	}

	private static string smethod_5(XmlDocument xmlDocument_0, string string_0)
	{
		bool flag = Regex.IsMatch(string_0 ?? string.Empty, Class16.smethod_0(1649276818), RegexOptions.IgnoreCase);
		XmlWriterSettings settings = new XmlWriterSettings
		{
			OmitXmlDeclaration = !flag,
			Indent = true,
			IndentChars = Class16.smethod_0(1648904383),
			NewLineHandling = NewLineHandling.Replace,
			NewLineChars = Class16.smethod_0(1648924428)
		};
		StringBuilder stringBuilder = new StringBuilder();
		using (XmlWriter w = XmlWriter.Create(new StringWriter(stringBuilder), settings))
		{
			xmlDocument_0.Save(w);
		}
		return smethod_19(stringBuilder.ToString());
	}

	private static UiControlModel? smethod_6(XmlNode xmlNode_0, string string_0, string string_1)
	{
		XmlAttributeCollection attributes = xmlNode_0.Attributes;
		object obj;
		if (attributes == null)
		{
			obj = null;
		}
		else
		{
			XmlAttribute xmlAttribute = attributes[Class16.smethod_0(1648936731)];
			if (xmlAttribute == null)
			{
				obj = null;
			}
			else
			{
				obj = xmlAttribute.Value;
				if (obj != null)
				{
					goto IL_0031;
				}
			}
		}
		obj = string.Empty;
		goto IL_0031;
		IL_02c7:
		object obj2;
		object obj3;
		((UiControlModel)obj2).Color = (string)obj3;
		UiControlType uiControlType;
		((UiControlModel)obj2).Type = uiControlType;
		UiControlModel uiControlModel = (UiControlModel)obj2;
		if (xmlNode_0.ChildNodes != null)
		{
			foreach (XmlNode childNode in xmlNode_0.ChildNodes)
			{
				if (childNode.NodeType != XmlNodeType.Element)
				{
					continue;
				}
				object obj4;
				if (string.Equals(childNode.Name, Class16.smethod_0(1649023959), StringComparison.OrdinalIgnoreCase))
				{
					XmlAttributeCollection attributes2 = childNode.Attributes;
					if (attributes2 == null)
					{
						obj4 = null;
					}
					else
					{
						XmlAttribute xmlAttribute2 = attributes2[Class16.smethod_0(1649275971)];
						if (xmlAttribute2 == null)
						{
							obj4 = null;
						}
						else
						{
							obj4 = xmlAttribute2.Value;
							if (obj4 != null)
							{
								goto IL_035a;
							}
						}
					}
					obj4 = uiControlModel.Text;
					goto IL_035a;
				}
				object obj5;
				if (string.Equals(childNode.Name, Class16.smethod_0(1649276804), StringComparison.OrdinalIgnoreCase))
				{
					XmlAttributeCollection attributes3 = childNode.Attributes;
					if (attributes3 == null)
					{
						obj5 = null;
					}
					else
					{
						XmlAttribute xmlAttribute3 = attributes3[Class16.smethod_0(1649275971)];
						if (xmlAttribute3 == null)
						{
							obj5 = null;
						}
						else
						{
							obj5 = xmlAttribute3.Value;
							if (obj5 != null)
							{
								goto IL_0558;
							}
						}
					}
					obj5 = uiControlModel.Hint;
					goto IL_0558;
				}
				if (string.Equals(childNode.Name, Class16.smethod_0(1649276694), StringComparison.OrdinalIgnoreCase))
				{
					smethod_7(childNode, string_0, string_1, uiControlModel);
				}
				continue;
				IL_0558:
				uiControlModel.Hint = (string)obj5;
				continue;
				IL_0506:
				object obj6;
				uiControlModel.OutlineColor = (string)obj6;
				continue;
				IL_035a:
				uiControlModel.Text = (string)obj4;
				uiControlModel.Align = smethod_13(childNode.Attributes?[Class16.smethod_0(1649275906)]?.Value, uiControlModel.Align);
				XmlAttributeCollection attributes4 = childNode.Attributes;
				object obj7;
				if (attributes4 == null)
				{
					obj7 = null;
				}
				else
				{
					XmlAttribute xmlAttribute4 = attributes4[Class16.smethod_0(1649085884)];
					if (xmlAttribute4 == null)
					{
						obj7 = null;
					}
					else
					{
						obj7 = xmlAttribute4.Value;
						if (obj7 != null)
						{
							goto IL_0423;
						}
					}
				}
				XmlAttributeCollection attributes5 = childNode.Attributes;
				if (attributes5 == null)
				{
					obj7 = null;
				}
				else
				{
					XmlAttribute xmlAttribute5 = attributes5[Class16.smethod_0(1649275984)];
					if (xmlAttribute5 == null)
					{
						obj7 = null;
					}
					else
					{
						obj7 = xmlAttribute5.Value;
						if (obj7 != null)
						{
							goto IL_0423;
						}
					}
				}
				XmlAttributeCollection attributes6 = childNode.Attributes;
				if (attributes6 == null)
				{
					obj7 = null;
				}
				else
				{
					XmlAttribute xmlAttribute6 = attributes6[Class16.smethod_0(1649276013)];
					if (xmlAttribute6 == null)
					{
						obj7 = null;
					}
					else
					{
						obj7 = xmlAttribute6.Value;
						if (obj7 != null)
						{
							goto IL_0423;
						}
					}
				}
				obj7 = uiControlModel.Color;
				goto IL_0423;
				IL_0423:
				uiControlModel.Color = (string)obj7;
				uiControlModel.FontSize = smethod_13(childNode.Attributes?[Class16.smethod_0(1649276026)]?.Value, uiControlModel.FontSize);
				uiControlModel.Bold = smethod_14(childNode.Attributes?[Class16.smethod_0(1649276041)]?.Value, uiControlModel.Bold);
				uiControlModel.Outline = smethod_14(childNode.Attributes?[Class16.smethod_0(1649276060)]?.Value, uiControlModel.Outline);
				XmlAttributeCollection attributes7 = childNode.Attributes;
				if (attributes7 == null)
				{
					obj6 = null;
				}
				else
				{
					XmlAttribute xmlAttribute7 = attributes7[Class16.smethod_0(1649276066)];
					if (xmlAttribute7 == null)
					{
						obj6 = null;
					}
					else
					{
						obj6 = xmlAttribute7.Value;
						if (obj6 != null)
						{
							goto IL_0506;
						}
					}
				}
				obj6 = uiControlModel.OutlineColor;
				goto IL_0506;
			}
		}
		object obj8;
		if (uiControlModel.Type == UiControlType.Edit && string.IsNullOrWhiteSpace(uiControlModel.Text))
		{
			XmlAttributeCollection attributes8 = xmlNode_0.Attributes;
			if (attributes8 == null)
			{
				obj8 = null;
			}
			else
			{
				XmlAttribute xmlAttribute8 = attributes8[Class16.smethod_0(1649023959)];
				if (xmlAttribute8 == null)
				{
					obj8 = null;
				}
				else
				{
					obj8 = xmlAttribute8.Value;
					if (obj8 != null)
					{
						goto IL_05eb;
					}
				}
			}
			obj8 = string.Empty;
			goto IL_05eb;
		}
		goto IL_05f0;
		IL_05eb:
		uiControlModel.Text = (string)obj8;
		goto IL_05f0;
		IL_05f0:
		return uiControlModel;
		IL_0290:
		object obj9;
		((UiControlModel)obj2).DialogFile = (string)obj9;
		XmlAttributeCollection attributes9 = xmlNode_0.Attributes;
		if (attributes9 == null)
		{
			obj3 = null;
		}
		else
		{
			XmlAttribute xmlAttribute9 = attributes9[Class16.smethod_0(1649085884)];
			if (xmlAttribute9 == null)
			{
				obj3 = null;
			}
			else
			{
				obj3 = xmlAttribute9.Value;
				if (obj3 != null)
				{
					goto IL_02c7;
				}
			}
		}
		obj3 = string.Empty;
		goto IL_02c7;
		IL_0031:
		string text = (string)obj;
		if (text.Length == 0)
		{
			return null;
		}
		bool hasExplicitWidth = xmlNode_0.Attributes?[Class16.smethod_0(1649055454)] != null;
		bool hasExplicitHeight = xmlNode_0.Attributes?[Class16.smethod_0(1649055458)] != null;
		uiControlType = smethod_11(xmlNode_0.Name);
		int num = smethod_13(xmlNode_0.Attributes?[Class16.smethod_0(1649055454)]?.Value, 0);
		int num2 = smethod_13(xmlNode_0.Attributes?[Class16.smethod_0(1649055458)]?.Value, 0);
		if (num <= 0 || num2 <= 0)
		{
			var (num3, num4) = smethod_12(uiControlType);
			if (num <= 0)
			{
				num = num3;
			}
			if (num2 <= 0)
			{
				num2 = num4;
			}
		}
		obj2 = new UiControlModel
		{
			XmlNodeName = xmlNode_0.Name,
			Name = text,
			Int32_0 = smethod_13(xmlNode_0.Attributes?[Class16.smethod_0(1649137079)]?.Value, 0),
			Int32_1 = smethod_13(xmlNode_0.Attributes?[Class16.smethod_0(1649047684)]?.Value, 0),
			Width = Math.Max(1, num),
			Height = Math.Max(1, num2),
			HasExplicitWidth = hasExplicitWidth,
			HasExplicitHeight = hasExplicitHeight,
			Align = smethod_13(xmlNode_0.Attributes?[Class16.smethod_0(1649275906)]?.Value, 0),
			TextOffsetX = smethod_13(xmlNode_0.Attributes?[Class16.smethod_0(1649275926)]?.Value, 0),
			TextOffsetY = smethod_13(xmlNode_0.Attributes?[Class16.smethod_0(1649275936)]?.Value, 0)
		};
		XmlAttributeCollection attributes10 = xmlNode_0.Attributes;
		if (attributes10 == null)
		{
			obj9 = null;
		}
		else
		{
			XmlAttribute xmlAttribute10 = attributes10[Class16.smethod_0(1649275954)];
			if (xmlAttribute10 == null)
			{
				obj9 = null;
			}
			else
			{
				obj9 = xmlAttribute10.Value;
				if (obj9 != null)
				{
					goto IL_0290;
				}
			}
		}
		obj9 = string.Empty;
		goto IL_0290;
	}

	private static void smethod_7(XmlNode xmlNode_0, string string_0, string string_1, UiControlModel uiControlModel_0)
	{
		Class365 @class = new Class365();
		@class.uiControlModel_0 = uiControlModel_0;
		Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		List<string> list = new List<string>();
		foreach (XmlNode childNode in xmlNode_0.ChildNodes)
		{
			XmlAttributeCollection attributes = childNode.Attributes;
			object obj;
			if (attributes == null)
			{
				obj = null;
			}
			else
			{
				XmlAttribute xmlAttribute = attributes[Class16.smethod_0(1649276093)];
				if (xmlAttribute == null)
				{
					obj = null;
				}
				else
				{
					obj = xmlAttribute.Value;
					if (obj != null)
					{
						goto IL_0071;
					}
				}
			}
			obj = string.Empty;
			goto IL_0071;
			IL_0071:
			string text = (string)obj;
			if (text.Length != 0)
			{
				string text2 = smethod_10(text, string_0, string_1);
				string key = childNode.Name ?? string.Empty;
				if (!dictionary.ContainsKey(key))
				{
					dictionary[key] = text2;
				}
				list.Add(text2);
			}
		}
		@class.uiControlModel_0.PrimaryImagePath = smethod_8(@class.uiControlModel_0.Type, dictionary);
		if (@class.uiControlModel_0.PrimaryImagePath.Length == 0 && list.Count > 0 && @class.uiControlModel_0.Type != UiControlType.SubDialog)
		{
			@class.uiControlModel_0.PrimaryImagePath = list[0];
		}
		List<string> list2 = list.Where(@class.method_0).ToList();
		if (list2.Count > 0)
		{
			@class.uiControlModel_0.SecondaryImagePath = list2[0];
		}
		if (list2.Count > 1)
		{
			@class.uiControlModel_0.TertiaryImagePath = list2[1];
		}
	}

	private static string smethod_8(UiControlType uiControlType_0, Dictionary<string, string> dictionary_0)
	{
		string[] array = uiControlType_0 switch
		{
			UiControlType.SubDialog => new string[1] { Class16.smethod_0(1649276127) }, 
			UiControlType.Radio => new string[3]
			{
				Class16.smethod_0(1649276136),
				Class16.smethod_0(1649276155),
				Class16.smethod_0(1649276127)
			}, 
			UiControlType.Check => new string[3]
			{
				Class16.smethod_0(1649276136),
				Class16.smethod_0(1649276155),
				Class16.smethod_0(1649276127)
			}, 
			UiControlType.StillImageButton => new string[2]
			{
				Class16.smethod_0(1649276108),
				Class16.smethod_0(1649276127)
			}, 
			_ => new string[4]
			{
				Class16.smethod_0(1649276127),
				Class16.smethod_0(1649276155),
				Class16.smethod_0(1649276136),
				Class16.smethod_0(1649276108)
			}, 
		};
		int num = 0;
		string value;
		while (true)
		{
			if (num < array.Length)
			{
				string key = array[num];
				if (dictionary_0.TryGetValue(key, out value) && !string.IsNullOrWhiteSpace(value))
				{
					break;
				}
				num++;
				continue;
			}
			return string.Empty;
		}
		return value;
	}

	private static string smethod_9(XmlElement xmlElement_0, string string_0, string string_1)
	{
		XmlNode xmlNode = xmlElement_0.ChildNodes.Cast<XmlNode>().FirstOrDefault(Class368.class368_0.method_5);
		if (xmlNode == null)
		{
			return string.Empty;
		}
		foreach (XmlNode childNode in xmlNode.ChildNodes)
		{
			if (childNode.NodeType != XmlNodeType.Element)
			{
				continue;
			}
			XmlAttributeCollection attributes = childNode.Attributes;
			object obj;
			if (attributes == null)
			{
				obj = null;
			}
			else
			{
				XmlAttribute xmlAttribute = attributes[Class16.smethod_0(1649276093)];
				if (xmlAttribute == null)
				{
					obj = null;
				}
				else
				{
					obj = xmlAttribute.Value;
					if (obj != null)
					{
						goto IL_008e;
					}
				}
			}
			obj = string.Empty;
			goto IL_008e;
			IL_008e:
			string text = (string)obj;
			if (text.Length != 0)
			{
				return smethod_10(text, string_0, string_1);
			}
		}
		return string.Empty;
	}

	private static string smethod_10(string string_0, string string_1, string string_2)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return string.Empty;
		}
		string text = string_0.Replace('/', '\\').Trim();
		if (System.IO.Path.IsPathRooted(text))
		{
			return text;
		}
		string text2 = text.TrimStart('\\');
		if (!string.IsNullOrEmpty(string_2) && string_2.EndsWith(Class16.smethod_0(1648909411), StringComparison.OrdinalIgnoreCase))
		{
			return text2;
		}
		string text3 = System.IO.Path.Combine(string_1 ?? string.Empty, text2);
		if (File.Exists(text3))
		{
			return text3;
		}
		string text4 = System.IO.Path.Combine(string_2 ?? string.Empty, text2);
		if (File.Exists(text4))
		{
			return text4;
		}
		if (text4.Length <= 0)
		{
			return text3;
		}
		return text4;
	}

	private static UiControlType smethod_11(string string_0)
	{
		string text = string_0.ToUpperInvariant();
		if (text != null)
		{
			switch (text.Length)
			{
			case 4:
				switch (text[0])
				{
				case 'T':
					if (text == Class16.smethod_0(1649276284))
					{
						return UiControlType.Text;
					}
					break;
				case 'L':
					if (text == Class16.smethod_0(1649276295))
					{
						return UiControlType.List;
					}
					break;
				case 'E':
					if (text == Class16.smethod_0(1649276815))
					{
						return UiControlType.Edit;
					}
					break;
				}
				break;
			case 5:
				switch (text[2])
				{
				case 'M':
					if (text == Class16.smethod_0(1649276241))
					{
						return UiControlType.Combo;
					}
					break;
				case 'B':
					if (text == Class16.smethod_0(1649276237))
					{
						return UiControlType.Label;
					}
					break;
				case 'D':
					if (text == Class16.smethod_0(1649276213))
					{
						return UiControlType.Radio;
					}
					break;
				case 'E':
					if (text == Class16.smethod_0(1649276217))
					{
						return UiControlType.Check;
					}
					break;
				}
				break;
			case 6:
				if (text == Class16.smethod_0(1649276192))
				{
					return UiControlType.Scroll;
				}
				break;
			case 8:
				if (text == Class16.smethod_0(1649276314))
				{
					return UiControlType.Progress;
				}
				break;
			case 9:
				if (text == Class16.smethod_0(1649276298))
				{
					return UiControlType.SubDialog;
				}
				break;
			case 12:
				if (text == Class16.smethod_0(1649276181))
				{
					return UiControlType.ImagePicture;
				}
				break;
			case 16:
				if (text == Class16.smethod_0(1649276261))
				{
					return UiControlType.StillImageButton;
				}
				break;
			}
		}
		return UiControlType.Unknown;
	}

	private static (int, int) smethod_12(UiControlType uiControlType_0)
	{
		return uiControlType_0 switch
		{
			UiControlType.Radio => (46, 40), 
			UiControlType.Check => (22, 22), 
			UiControlType.StillImageButton => (110, 26), 
			UiControlType.Label => (180, 22), 
			UiControlType.Text => (180, 22), 
			UiControlType.Edit => (140, 24), 
			UiControlType.List => (160, 100), 
			UiControlType.Combo => (120, 22), 
			UiControlType.SubDialog => (180, 120), 
			_ => (1, 1), 
		};
	}

	private static int smethod_13(string? string_0, int int_0)
	{
		if (string_0 == null)
		{
			return int_0;
		}
		if (int.TryParse(string_0, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
		{
			return result;
		}
		if (double.TryParse(string_0, NumberStyles.Float, CultureInfo.InvariantCulture, out var result2))
		{
			return (int)Math.Round(result2, MidpointRounding.AwayFromZero);
		}
		return int_0;
	}

	private static bool smethod_14(string? string_0, bool bool_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return bool_0;
		}
		if (bool.TryParse(string_0, out var result))
		{
			return result;
		}
		if (int.TryParse(string_0, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result2))
		{
			return result2 != 0;
		}
		return bool_0;
	}

	private static void smethod_15(XmlDocument xmlDocument_0, XmlNode xmlNode_0, string string_0, string string_1)
	{
		XmlAttribute xmlAttribute = xmlNode_0.Attributes?[string_0];
		if (xmlAttribute == null)
		{
			xmlAttribute = xmlDocument_0.CreateAttribute(string_0);
			xmlNode_0.Attributes?.Append(xmlAttribute);
		}
		xmlAttribute.Value = string_1;
	}

	private static void smethod_16(XmlDocument xmlDocument_0, XmlNode xmlNode_0, string string_0, string? string_1)
	{
		Class366 @class = new Class366();
		@class.string_0 = string_0;
		XmlNode xmlNode = xmlNode_0.ChildNodes.Cast<XmlNode>().FirstOrDefault(@class.method_0);
		if (xmlNode == null)
		{
			if (string.IsNullOrWhiteSpace(string_1))
			{
				return;
			}
			xmlNode = xmlDocument_0.CreateElement(@class.string_0);
			xmlNode_0.AppendChild(xmlNode);
		}
		smethod_15(xmlDocument_0, xmlNode, Class16.smethod_0(1649275971), string_1 ?? string.Empty);
	}

	private static string smethod_17(string string_0)
	{
		string input = string_0.TrimStart('\ufeff', '\u200b', '\u200e', '\u200f', ' ', '\t', '\r', '\n');
		input = Regex.Replace(input, Class16.smethod_0(1649276329), string.Empty);
		input = smethod_18(input);
		if (!input.StartsWith(Class16.smethod_0(1649276368), StringComparison.OrdinalIgnoreCase))
		{
			input = Class16.smethod_0(1649276388) + input;
		}
		return input;
	}

	private static string smethod_18(string string_0)
	{
		return regex_0.Replace(string_0, Class368.class368_0.method_6);
	}

	private static string smethod_19(string string_0)
	{
		return regex_0.Replace(string_0, Class368.class368_0.method_7);
	}
}
