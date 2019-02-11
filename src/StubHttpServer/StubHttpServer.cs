using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace StubHttpServer
{
    public class StubHttpServer : IDisposable
    {
        private Process _process;

        public StubHttpServer()
        {
            
        }
        
        public async Task<StubHttpServer> StartAsync(string port = "8181")
        {
            var exe = GetExecutable(); 
            var processInfo = new ProcessStartInfo
            {
                FileName = exe
            };
            _process = new Process
            {
                StartInfo = processInfo,
            };

            _process.Start();
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            return this;
        }

        public void Dispose()
        {
            if (_process?.HasExited == false)
                _process.Kill();
        }

        private static string GetExecutable()
        {
            if (EnvironmentContext.IsMac())
                return @"./toxiproxy-server-2.1.3.darwin-amd64";
            if (EnvironmentContext.IsLinux())
                return @"./toxiproxy-server-2.1.3.linux-amd64";

            return @"./toxiproxy-server-2.1.3.windows-amd64.exe";
        }
    }
}