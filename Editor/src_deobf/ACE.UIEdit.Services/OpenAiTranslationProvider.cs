using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ACE.UIEdit.Services;

internal sealed class OpenAiTranslationProvider : IAiTranslationProvider
{
	[StructLayout(LayoutKind.Auto)]
	private struct Struct114 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder<string> asyncTaskMethodBuilder_0;

		public string string_0;

		public JObject jobject_0;

		public CancellationToken cancellationToken_0;

		private HttpRequestMessage httpRequestMessage_0;

		private HttpResponseMessage httpResponseMessage_0;

		private ConfiguredTaskAwaitable<HttpResponseMessage>.ConfiguredTaskAwaiter configuredTaskAwaiter_0;

		private ConfiguredTaskAwaitable<string>.ConfiguredTaskAwaiter configuredTaskAwaiter_1;

		private void MoveNext()
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Expected O, but got Unknown
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Expected O, but got Unknown
			int num = int_0;
			string result3;
			try
			{
				if ((uint)num > 1u)
				{
					httpRequestMessage_0 = new HttpRequestMessage(HttpMethod.Post, Class16.smethod_0(1649150434));
				}
				try
				{
					ConfiguredTaskAwaitable<HttpResponseMessage>.ConfiguredTaskAwaiter awaiter;
					if (num != 0)
					{
						if (num == 1)
						{
							goto IL_00e5;
						}
						httpRequestMessage_0.Headers.Authorization = new AuthenticationHeaderValue(Class16.smethod_0(1648890489), string_0);
						httpRequestMessage_0.Content = (HttpContent)new StringContent(((JToken)jobject_0).ToString((Formatting)0), Encoding.UTF8, Class16.smethod_0(1648896995));
						awaiter = ((HttpMessageInvoker)httpClient_0).SendAsync(httpRequestMessage_0, cancellationToken_0).ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							int_0 = 0;
							configuredTaskAwaiter_0 = awaiter;
							asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
					}
					else
					{
						awaiter = configuredTaskAwaiter_0;
						configuredTaskAwaiter_0 = default(ConfiguredTaskAwaitable<HttpResponseMessage>.ConfiguredTaskAwaiter);
						num = -1;
						int_0 = -1;
					}
					HttpResponseMessage result = awaiter.GetResult();
					httpResponseMessage_0 = result;
					goto IL_00e5;
					IL_00e5:
					try
					{
						ConfiguredTaskAwaitable<string>.ConfiguredTaskAwaiter awaiter2;
						if (num != 1)
						{
							awaiter2 = httpResponseMessage_0.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = 1;
								int_0 = 1;
								configuredTaskAwaiter_1 = awaiter2;
								asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
								return;
							}
						}
						else
						{
							awaiter2 = configuredTaskAwaiter_1;
							configuredTaskAwaiter_1 = default(ConfiguredTaskAwaitable<string>.ConfiguredTaskAwaiter);
							num = -1;
							int_0 = -1;
						}
						string result2 = awaiter2.GetResult();
						string text = result2;
						if (!httpResponseMessage_0.IsSuccessStatusCode)
						{
							throw new InvalidOperationException(string.Format(Class16.smethod_0(1649276435), (int)httpResponseMessage_0.StatusCode, text));
						}
						JObject val = JObject.Parse(text);
						JToken obj = val[Class16.smethod_0(1648890262)];
						object obj2;
						if (obj == null)
						{
							obj2 = null;
						}
						else
						{
							JToken obj3 = obj[(object)0];
							if (obj3 == null)
							{
								obj2 = null;
							}
							else
							{
								JToken obj4 = obj3[(object)Class16.smethod_0(1648894248)];
								obj2 = ((obj4 == null) ? null : ((object)obj4[(object)Class16.smethod_0(1648890400)])?.ToString());
							}
						}
						string text2 = (string)obj2;
						if (string.IsNullOrWhiteSpace(text2))
						{
							throw new InvalidOperationException(Class16.smethod_0(1649276478));
						}
						result3 = text2.Trim();
					}
					finally
					{
						if (num < 0 && httpResponseMessage_0 != null)
						{
							((IDisposable)httpResponseMessage_0).Dispose();
						}
					}
				}
				finally
				{
					if (num < 0 && httpRequestMessage_0 != null)
					{
						((IDisposable)httpRequestMessage_0).Dispose();
					}
				}
			}
			catch (Exception exception)
			{
				int_0 = -2;
				httpRequestMessage_0 = null;
				httpResponseMessage_0 = null;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			httpRequestMessage_0 = null;
			httpResponseMessage_0 = null;
			asyncTaskMethodBuilder_0.SetResult(result3);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private static readonly HttpClient httpClient_0 = smethod_1();

	public string ProviderId => Class16.smethod_0(1649150061);

	public string DisplayName => Class16.smethod_0(1649276516);

	public Task<string> TranslateAsync(string sourceText, string sourceLanguageCode, string targetLanguageCode, string apiKey, string model, CancellationToken cancellationToken)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		if (string.IsNullOrWhiteSpace(sourceText))
		{
			return Task.FromResult(string.Empty);
		}
		if (string.Equals(sourceLanguageCode, targetLanguageCode, StringComparison.OrdinalIgnoreCase))
		{
			return Task.FromResult(sourceText);
		}
		if (string.IsNullOrWhiteSpace(apiKey))
		{
			throw new InvalidOperationException(Class16.smethod_0(1649150762));
		}
		string text = (string.IsNullOrWhiteSpace(model) ? Class16.smethod_0(1648896900) : model.Trim());
		string text2 = UiTranslatableTextExtractor.ResolveLanguageName(sourceLanguageCode);
		string text3 = UiTranslatableTextExtractor.ResolveLanguageName(targetLanguageCode);
		JObject val = new JObject();
		val[Class16.smethod_0(1648891370)] = (text);
		val[Class16.smethod_0(1648891390)] = (0.0);
		string text4 = Class16.smethod_0(1648900060);
		JArray val2 = new JArray();
		val2.Add((JToken)new JObject
		{
			[Class16.smethod_0(1648890376)] = (Class16.smethod_0(1648890387)),
			[Class16.smethod_0(1648890400)] = (Class16.smethod_0(1649276521))
		});
		JObject val3 = new JObject();
		val3[Class16.smethod_0(1648890376)] = (Class16.smethod_0(1648890422));
		val3[Class16.smethod_0(1648890400)] = (Class16.smethod_0(1648890425) + text2 + Class16.smethod_0(1648899468) + sourceLanguageCode + Class16.smethod_0(1649276626) + text3 + Class16.smethod_0(1648899468) + targetLanguageCode + Class16.smethod_0(1648890474) + sourceText);
		val2.Add((JToken)(object)val3);
		val[text4] = (JToken)(object)val2;
		JObject jobject_ = val;
		return smethod_0(jobject_, apiKey.Trim(), cancellationToken);
	}

	private static async Task<string> smethod_0(JObject jobject_0, string string_0, CancellationToken cancellationToken_0)
	{
		HttpRequestMessage val = new HttpRequestMessage(HttpMethod.Post, Class16.smethod_0(1649150434));
		try
		{
			val.Headers.Authorization = new AuthenticationHeaderValue(Class16.smethod_0(1648890489), string_0);
			val.Content = (HttpContent)new StringContent(((JToken)jobject_0).ToString((Formatting)0), Encoding.UTF8, Class16.smethod_0(1648896995));
			HttpResponseMessage val2 = await ((HttpMessageInvoker)httpClient_0).SendAsync(val, cancellationToken_0).ConfigureAwait(continueOnCapturedContext: false);
			try
			{
				string text = await val2.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
				if (!val2.IsSuccessStatusCode)
				{
					throw new InvalidOperationException(string.Format(Class16.smethod_0(1649276435), (int)val2.StatusCode, text));
				}
				JObject val3 = JObject.Parse(text);
				JToken obj = val3[Class16.smethod_0(1648890262)];
				object obj2;
				if (obj == null)
				{
					obj2 = null;
				}
				else
				{
					JToken obj3 = obj[(object)0];
					if (obj3 == null)
					{
						obj2 = null;
					}
					else
					{
						JToken obj4 = obj3[(object)Class16.smethod_0(1648894248)];
						obj2 = ((obj4 == null) ? null : ((object)obj4[(object)Class16.smethod_0(1648890400)])?.ToString());
					}
				}
				string text2 = (string)obj2;
				if (string.IsNullOrWhiteSpace(text2))
				{
					throw new InvalidOperationException(Class16.smethod_0(1649276478));
				}
				return text2.Trim();
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private static HttpClient smethod_1()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		HttpClient val = new HttpClient();
		val.Timeout = TimeSpan.FromSeconds(60.0);
		return val;
	}
}
