using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ACE.PWMap;

internal sealed class PwMapDebugLogger : IDisposable
{
	private readonly StringBuilder stringBuilder_0;

	private readonly Stopwatch stopwatch_0;

	private readonly Stopwatch stopwatch_1;

	private readonly string string_0;

	private string string_1;

	private bool bool_0;

	private PwMapDebugLogger(string string_2)
	{
		string_0 = string_2;
		stringBuilder_0 = new StringBuilder(65536);
		stopwatch_0 = Stopwatch.StartNew();
		stopwatch_1 = new Stopwatch();
	}

	public static PwMapDebugLogger Create(string mapName)
	{
		return new PwMapDebugLogger(null);
	}

	private bool method_0()
	{
		return false;
	}

	private void method_1(string string_2)
	{
		if (method_0())
		{
			stringBuilder_0.AppendLine(Class16.smethod_0(1649093370));
			stringBuilder_0.AppendLine(Class16.smethod_0(1649093435) + string_2);
			stringBuilder_0.AppendLine(string.Format(Class16.smethod_0(1649093498), DateTime.Now));
			stringBuilder_0.AppendLine(string.Format(Class16.smethod_0(1649093551), Process.GetCurrentProcess().Id, Environment.Version));
			stringBuilder_0.AppendLine(string.Format(Class16.smethod_0(1649093583), GC.GetTotalMemory(forceFullCollection: false) / 1048576L));
			stringBuilder_0.AppendLine(Class16.smethod_0(1649093370));
			stringBuilder_0.AppendLine();
		}
	}

	public void BeginPhase(string phaseName)
	{
		if (method_0())
		{
			string_1 = phaseName;
			stopwatch_1.Restart();
			stringBuilder_0.AppendLine(Class16.smethod_0(1649093608) + phaseName);
			stringBuilder_0.AppendLine(string.Format(Class16.smethod_0(1649092621), DateTime.Now, stopwatch_0.Elapsed.TotalSeconds));
		}
	}

	public void EndPhase()
	{
		if (method_0())
		{
			stopwatch_1.Stop();
			long num = GC.GetTotalMemory(forceFullCollection: false) / 1048576L;
			stringBuilder_0.AppendLine(string.Format(Class16.smethod_0(1649092732), stopwatch_1.Elapsed.TotalMilliseconds, num));
			stringBuilder_0.AppendLine(Class16.smethod_0(1649092809) + string_1);
			stringBuilder_0.AppendLine();
			string_1 = null;
			Flush();
		}
	}

	public void Log(string message)
	{
		if (method_0())
		{
			stringBuilder_0.AppendLine(Class16.smethod_0(1649092834) + message);
		}
	}

	public void LogDetail(string message)
	{
		if (method_0())
		{
			stringBuilder_0.AppendLine(Class16.smethod_0(1649092849) + message);
		}
	}

	public void LogWarning(string message)
	{
		if (method_0())
		{
			stringBuilder_0.AppendLine(Class16.smethod_0(1649092876) + message);
		}
	}

	public void LogError(string message, Exception ex = null)
	{
		if (!method_0())
		{
			return;
		}
		stringBuilder_0.AppendLine(Class16.smethod_0(1649092905) + message);
		if (ex == null)
		{
			return;
		}
		stringBuilder_0.AppendLine(Class16.smethod_0(1649092938) + ex.GetType().Name + Class16.smethod_0(1648908709) + ex.Message);
		if (ex.StackTrace != null)
		{
			string[] array = ex.StackTrace.Split('\n');
			int num = Math.Min(5, array.Length);
			for (int i = 0; i < num; i++)
			{
				stringBuilder_0.AppendLine(Class16.smethod_0(1649092979) + array[i].Trim());
			}
		}
	}

	public void LogSeparator(string label = null)
	{
		if (method_0())
		{
			if (string.IsNullOrWhiteSpace(label))
			{
				stringBuilder_0.AppendLine(Class16.smethod_0(1649093002));
			}
			else
			{
				stringBuilder_0.AppendLine(Class16.smethod_0(1649093033) + label + Class16.smethod_0(1649093062));
			}
		}
	}

	public void LogDiscovery(PwMapFileLayout layout)
	{
		if (method_0() && layout != null)
		{
			Log(Class16.smethod_0(1649093115) + (layout.MapRootPath ?? Class16.smethod_0(1649047701)));
			Log(Class16.smethod_0(1649088011) + (layout.MapName ?? Class16.smethod_0(1649047701)));
			Log(string.Format(Class16.smethod_0(1649088027), layout.HasMapRoot));
			LogSeparator(Class16.smethod_0(1649088049));
			LogDetail(Class16.smethod_0(1649088078) + (string.IsNullOrWhiteSpace(layout.RegionFile) ? Class16.smethod_0(1649088100) : layout.RegionFile));
			LogDetail(Class16.smethod_0(1649088116) + (string.IsNullOrWhiteSpace(layout.PrecinctFile) ? Class16.smethod_0(1649088100) : layout.PrecinctFile));
			LogDetail(Class16.smethod_0(1649088130) + (string.IsNullOrWhiteSpace(layout.PathDataFile) ? Class16.smethod_0(1649088100) : layout.PathDataFile));
			LogDetail(Class16.smethod_0(1649088152) + (string.IsNullOrWhiteSpace(layout.DynamicObjectsFile) ? Class16.smethod_0(1649088100) : layout.DynamicObjectsFile));
			LogDetail(Class16.smethod_0(1649088182) + (string.IsNullOrWhiteSpace(layout.Domain2File) ? Class16.smethod_0(1649088100) : layout.Domain2File));
			LogDetail(Class16.smethod_0(1649088204) + (string.IsNullOrWhiteSpace(layout.WorldFile) ? Class16.smethod_0(1649088100) : layout.WorldFile));
			LogDetail(Class16.smethod_0(1649088218) + (string.IsNullOrWhiteSpace(layout.Trn2File) ? Class16.smethod_0(1649088100) : layout.Trn2File));
			LogDetail(Class16.smethod_0(1649088240) + (string.IsNullOrWhiteSpace(layout.EcwldFile) ? Class16.smethod_0(1649088100) : layout.EcwldFile));
			LogDetail(Class16.smethod_0(1649088270) + (string.IsNullOrWhiteSpace(layout.EcbsdFile) ? Class16.smethod_0(1649088100) : layout.EcbsdFile));
			LogDetail(Class16.smethod_0(1649088292) + (string.IsNullOrWhiteSpace(layout.LitmodelsFolder) ? Class16.smethod_0(1649088306) : layout.LitmodelsFolder));
			LogDetail(Class16.smethod_0(1649088334) + (string.IsNullOrWhiteSpace(layout.BsdataFolder) ? Class16.smethod_0(1649088100) : layout.BsdataFolder));
			LogDetail(string.Format(Class16.smethod_0(1649088356), layout.TextureFiles?.Count ?? 0));
		}
	}

	public void LogTerrainInfo(PwMapTrn2File trn2)
	{
		if (method_0() && trn2 != null)
		{
			Log(string.Format(Class16.smethod_0(1649088379), trn2.SectorsWide, trn2.SectorsHigh, trn2.TotalSectors));
			Log(string.Format(Class16.smethod_0(1649088416), trn2.Width, trn2.Height));
			Log(string.Format(Class16.smethod_0(1649088456), trn2.DdsFiles?.Count ?? 0));
		}
	}

	public void LogResolverResult(string strategy, int totalModels, int totalSectors)
	{
		if (method_0())
		{
			Log(Class16.smethod_0(1649088485) + strategy);
			Log(string.Format(Class16.smethod_0(1649088511), totalModels));
			Log(string.Format(Class16.smethod_0(1649087518), totalSectors));
		}
	}

	public void LogModelEntry(int index, string path, int meshCount, int totalVertices, bool fromPck)
	{
		if (method_0())
		{
			string text = (fromPck ? Class16.smethod_0(1649087552) : Class16.smethod_0(1649087549));
			LogDetail(string.Format(Class16.smethod_0(1649087562), index, text, meshCount, totalVertices, path));
		}
	}

	public void LogModelSkipped(int index, string path, string reason)
	{
		if (method_0())
		{
			LogDetail(string.Format(Class16.smethod_0(1649087610), index, reason, path));
		}
	}

	public void LogModelSummary(int loaded, int skipped, int solidVerts, int wireVerts, int texturedBatches)
	{
		if (method_0())
		{
			LogSeparator(Class16.smethod_0(1649087641));
			Log(string.Format(Class16.smethod_0(1649087664), loaded, skipped));
			Log(string.Format(Class16.smethod_0(1649087697), solidVerts, wireVerts));
			Log(string.Format(Class16.smethod_0(1649087758), texturedBatches));
		}
	}

	public void LogGfxSummary(int ecwldGfx, int ornamentGfx, int resolved, int fallbackMarkers)
	{
		if (method_0())
		{
			LogSeparator(Class16.smethod_0(1649087778));
			Log(string.Format(Class16.smethod_0(1649087804), ecwldGfx));
			Log(string.Format(Class16.smethod_0(1649087825), ornamentGfx));
			Log(string.Format(Class16.smethod_0(1649087857), resolved));
			Log(string.Format(Class16.smethod_0(1649087890), fallbackMarkers));
		}
	}

	public void LogGfxEntry(int index, string relativePath, string resolvedPath, int elementCount, float size, bool loaded)
	{
		if (method_0())
		{
			string text = (loaded ? Class16.smethod_0(1648938905) : Class16.smethod_0(1649087926));
			LogDetail(string.Format(Class16.smethod_0(1649087929), index, text, elementCount, size, relativePath));
			if (!string.IsNullOrEmpty(resolvedPath) && !string.Equals(resolvedPath, relativePath, StringComparison.OrdinalIgnoreCase))
			{
				LogDetail(Class16.smethod_0(1649087989) + resolvedPath);
			}
		}
	}

	public void LogGfxLoadError(int index, string relativePath, string error)
	{
		if (method_0())
		{
			LogDetail(string.Format(Class16.smethod_0(1649086989), index, error, relativePath));
		}
	}

	public void LogFloraSummary(int treeTypes, int treeInstances, int withTexture, int fallback)
	{
		if (method_0())
		{
			LogSeparator(Class16.smethod_0(1649087021));
			Log(string.Format(Class16.smethod_0(1649087033), treeTypes, treeInstances));
			Log(string.Format(Class16.smethod_0(1649087072), withTexture, fallback));
		}
	}

	public void LogWaterSummary(int bsdataFiles, int waterBlocks, int vertices)
	{
		if (method_0())
		{
			LogSeparator(Class16.smethod_0(1649087112));
			Log(string.Format(Class16.smethod_0(1649087140), bsdataFiles, waterBlocks));
			Log(string.Format(Class16.smethod_0(1649087176), vertices));
		}
	}

	public void LogLightSummary(int count)
	{
		if (method_0())
		{
			LogSeparator(Class16.smethod_0(1649087207));
			Log(string.Format(Class16.smethod_0(1649087219), count));
		}
	}

	public void LogFinalSummary(int litObjs, int waterObjs, int floraObjs, int gfxObjs, int lightObjs)
	{
		if (method_0())
		{
			stringBuilder_0.AppendLine();
			stringBuilder_0.AppendLine(Class16.smethod_0(1649093370));
			stringBuilder_0.AppendLine(Class16.smethod_0(1649087252));
			stringBuilder_0.AppendLine(string.Format(Class16.smethod_0(1649087277), stopwatch_0.Elapsed.TotalSeconds));
			stringBuilder_0.AppendLine(string.Format(Class16.smethod_0(1649093583), GC.GetTotalMemory(forceFullCollection: false) / 1048576L));
			stringBuilder_0.AppendLine(Class16.smethod_0(1649087297));
			stringBuilder_0.AppendLine(string.Format(Class16.smethod_0(1649087334), litObjs));
			stringBuilder_0.AppendLine(string.Format(Class16.smethod_0(1649087365), waterObjs));
			stringBuilder_0.AppendLine(string.Format(Class16.smethod_0(1649087396), floraObjs));
			stringBuilder_0.AppendLine(string.Format(Class16.smethod_0(1649087419), gfxObjs));
			stringBuilder_0.AppendLine(string.Format(Class16.smethod_0(1649087450), lightObjs));
			stringBuilder_0.AppendLine(Class16.smethod_0(1649093370));
		}
	}

	public void Flush()
	{
		if (method_0() && !string.IsNullOrWhiteSpace(string_0))
		{
			try
			{
				File.WriteAllText(string_0, stringBuilder_0.ToString(), Encoding.UTF8);
			}
			catch (Exception)
			{
			}
		}
	}

	public void Dispose()
	{
		if (!bool_0)
		{
			bool_0 = true;
			stopwatch_0.Stop();
			Flush();
		}
	}
}
