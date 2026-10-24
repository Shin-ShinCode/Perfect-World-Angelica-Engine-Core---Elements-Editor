using System.Threading;
using System.Threading.Tasks;

namespace ACE.UIEdit.Services;

internal interface IAiTranslationProvider
{
	string ProviderId { get; }

	string DisplayName { get; }

	Task<string> TranslateAsync(string sourceText, string sourceLanguageCode, string targetLanguageCode, string apiKey, string model, CancellationToken cancellationToken);
}
