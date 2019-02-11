using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace StubHttpServer.Tests
{
    public class DemoTest : IDisposable, IAsyncLifetime
    {
        private readonly StubHttpServer _server;

        public DemoTest()
        {
            _server = new StubHttpServer();
        }
        
        [Fact]
        public void Test1()
        {
            var client = new HttpClient("");
        }

        public void Dispose()
        {
            _server?.Dispose();
        }

        public async Task InitializeAsync()
        {
            await _server.StartAsync();
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}