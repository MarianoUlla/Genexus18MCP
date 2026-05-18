using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace GxMcp.Gateway.Tests
{
    public class ConfigurationParsingTests
    {
        [Fact]
        public void ParseConfig_LegacyKbPath_MigratesToKbsAndDefaultKb()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), "gxmcp-gw-tests-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(tempDir);
            string configPath = Path.Combine(tempDir, "config.json");
            try
            {
                var json = @"{
  ""Environment"": {
    ""KBPath"": ""C:/KBs/LegacyDemo""
  }
}";
                File.WriteAllText(configPath, json);

                var cfg = ParseConfig(configPath);

                Assert.NotNull(cfg.Environment);
                Assert.NotNull(cfg.Environment!.KBs);
                var single = Assert.Single(cfg.Environment.KBs);
                Assert.Equal("legacydemo", single.Alias);
                Assert.Equal("C:/KBs/LegacyDemo", single.Path);
                Assert.Equal("legacydemo", cfg.Environment.DefaultKb);
            }
            finally
            {
                TryDeleteDirectory(tempDir);
            }
        }

        [Fact]
        public void ParseConfig_AppliesEnvOverrides_AndPromotesActiveKb()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), "gxmcp-gw-tests-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(tempDir);
            string configPath = Path.Combine(tempDir, "config.json");
            string? oldPort = Environment.GetEnvironmentVariable("GX_MCP_PORT");
            string? oldStdio = Environment.GetEnvironmentVariable("GX_MCP_STDIO");
            try
            {
                var json = @"{
  ""Server"": {
    ""HttpPort"": 5000,
    ""McpStdio"": true
  },
  ""Environment"": {
    ""DefaultKb"": """",
    ""ActiveKb"": ""from_cli"",
    ""KBs"": {
      ""from_cli"": ""C:/KBs/FromCli""
    }
  }
}";
                File.WriteAllText(configPath, json);

                Environment.SetEnvironmentVariable("GX_MCP_PORT", "7711");
                Environment.SetEnvironmentVariable("GX_MCP_STDIO", "false");
                var cfg = ParseConfig(configPath);

                Assert.NotNull(cfg.Server);
                Assert.Equal(7711, cfg.Server!.HttpPort);
                Assert.False(cfg.Server.McpStdio);

                Assert.NotNull(cfg.Environment);
                Assert.Equal("from_cli", cfg.Environment!.DefaultKb);
                var single = Assert.Single(cfg.Environment.KBs);
                Assert.Equal("from_cli", single.Alias);
                Assert.Equal("C:/KBs/FromCli", single.Path);
            }
            finally
            {
                Environment.SetEnvironmentVariable("GX_MCP_PORT", oldPort);
                Environment.SetEnvironmentVariable("GX_MCP_STDIO", oldStdio);
                TryDeleteDirectory(tempDir);
            }
        }

        private static Configuration ParseConfig(string path)
        {
            var method = typeof(Configuration).GetMethod("ParseConfig", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);

            try
            {
                var cfg = method!.Invoke(null, new object[] { path }) as Configuration;
                Assert.NotNull(cfg);
                return cfg!;
            }
            catch (TargetInvocationException ex) when (ex.InnerException != null)
            {
                throw ex.InnerException;
            }
        }

        private static void TryDeleteDirectory(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
            }
            catch
            {
            }
        }
    }
}
