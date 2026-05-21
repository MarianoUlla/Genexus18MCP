using System;
using System.Collections;
using Microsoft.Build.Framework;

namespace GxMcp.Worker.Helpers
{
    // v2.6.6 Stream D — IBuildEngine adapter used to invoke GeneXus MSBuild
    // tasks (SpecifyOneOnly, IdeWebBuildAndDeploy) in-process against the
    // worker's already-open KB. Logging events are forwarded to a sink
    // delegate so the BuildService line parser (HandleLine) keeps producing
    // phase / error / warning telemetry exactly as it did from MSBuild.exe.
    //
    // BuildProjectFile is a no-op: GeneXus tasks don't actually invoke
    // sub-projects, so a true return is safe.
    public sealed class InProcessBuildEngine : IBuildEngine
    {
        // Sink signature mirrors BuildService.HandleLine(status, line, isError).
        // The runner closes over its own BuildTaskStatus so this engine only
        // needs (string line, bool isError).
        private readonly Action<string, bool> _sink;

        public InProcessBuildEngine(Action<string, bool> sink)
        {
            _sink = sink ?? ((l, e) => { });
        }

        public bool ContinueOnError => true;
        public int LineNumberOfTaskNode => 0;
        public int ColumnNumberOfTaskNode => 0;
        public string ProjectFileOfTaskNode => string.Empty;

        public bool BuildProjectFile(string projectFileName, string[] targetNames, IDictionary globalProperties, IDictionary targetOutputs)
        {
            return true;
        }

        public void LogCustomEvent(CustomBuildEventArgs e)
        {
            try { if (e != null && !string.IsNullOrEmpty(e.Message)) _sink(e.Message, false); } catch { }
        }

        public void LogErrorEvent(BuildErrorEventArgs e)
        {
            try
            {
                if (e == null) return;
                // Re-emit in a shape close to what MSBuild.exe writes so the existing
                // _rxError ("error CODE:" or "error :") catches it. Prefer the supplied
                // code+message if both are present.
                string line;
                if (!string.IsNullOrEmpty(e.Code))
                    line = "error " + e.Code + ": " + e.Message;
                else
                    line = "error : " + e.Message;
                _sink(line, true);
            }
            catch { }
        }

        public void LogMessageEvent(BuildMessageEventArgs e)
        {
            try { if (e != null && !string.IsNullOrEmpty(e.Message)) _sink(e.Message, false); } catch { }
        }

        public void LogWarningEvent(BuildWarningEventArgs e)
        {
            try
            {
                if (e == null) return;
                string line;
                if (!string.IsNullOrEmpty(e.Code))
                    line = "warning " + e.Code + ": " + e.Message;
                else
                    line = "warning : " + e.Message;
                _sink(line, false);
            }
            catch { }
        }
    }
}
