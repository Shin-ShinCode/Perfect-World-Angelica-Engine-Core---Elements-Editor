using System;
using System.Globalization;
using System.Text;

namespace ACE.Classes;

internal static class TextSearchHelper
{
	private static readonly CompareInfo compareInfo_0 = CultureInfo.InvariantCulture.CompareInfo;

	public static bool Contains(string source, string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return true;
		}
		if (string.IsNullOrEmpty(source))
		{
			return false;
		}
		return compareInfo_0.IndexOf(Normalize(source), Normalize(value), CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) >= 0;
	}

	public static bool Equals(string left, string right)
	{
		if (left != null && right != null)
		{
			return compareInfo_0.Compare(Normalize(left), Normalize(right), CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0;
		}
		return string.Equals(left, right, StringComparison.Ordinal);
	}

	public static string Normalize(string value)
	{
		if (!string.IsNullOrEmpty(value))
		{
			return value.Normalize(NormalizationForm.FormKC);
		}
		return string.Empty;
	}
}
