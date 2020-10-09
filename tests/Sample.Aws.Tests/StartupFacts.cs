using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace Sample.Aws.Tests
{
    public class StartupFacts
    {
        [Fact(DisplayName = "When injecting Configuration into Startup")]
        public void When_injecting_configuration()
        {
            var configurationMock = Mock.Of<IConfiguration>();
            var sut = new Startup(configurationMock);
            Assert.Equal(configurationMock, sut.Configuration);
        }
    }
}
