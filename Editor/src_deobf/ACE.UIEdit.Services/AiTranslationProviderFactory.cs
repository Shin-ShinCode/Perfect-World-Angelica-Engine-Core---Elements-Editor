using System;
using System.Collections.Generic;
using System.Linq;

namespace ACE.UIEdit.Services;

internal static class AiTranslationProviderFactory
{
	private sealed class Class364
	{
		public string string_0;

		internal bool method_0(IAiTranslationProvider iaiTranslationProvider_0)
		{
			return string.Equals(iaiTranslationProvider_0.ProviderId, string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private static readonly IReadOnlyList<IAiTranslationProvider> ireadOnlyList_0 = new List<IAiTranslationProvider>
	{
		new OpenAiTranslationProvider()
	};

	public static IReadOnlyList<IAiTranslationProvider> GetProviders()
	{
		return ireadOnlyList_0;
	}

	public static IAiTranslationProvider GetById(string providerId)
	{
		Class364 @class = new Class364();
		@class.string_0 = providerId;
		IAiTranslationProvider aiTranslationProvider = ireadOnlyList_0.FirstOrDefault(@class.method_0);
		if (aiTranslationProvider == null)
		{
			throw new InvalidOperationException(Class16.smethod_0(1649150402) + @class.string_0);
		}
		return aiTranslationProvider;
	}
}
