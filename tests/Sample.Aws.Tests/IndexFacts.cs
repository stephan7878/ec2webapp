using AngleSharp;
using AngleSharp.Dom;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Sample.Aws.Tests
{
    public class IndexFacts : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public IndexFacts(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact(DisplayName = "Get index")]
        public async Task Get_index()
        {
            HttpClient client = _factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("/index");
            string result = await response.Content.ReadAsStringAsync();
            
            // Parse HTML string with AngleSharp
            IBrowsingContext context = BrowsingContext.New();
            IDocument document = await context.OpenAsync(r => r.Content(result));
            IElement p = document.QuerySelector("p");

            Assert.Equal($"Server name: {System.Environment.MachineName}", p.TextContent);
        }
    }
}
