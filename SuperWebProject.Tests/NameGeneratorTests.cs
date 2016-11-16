using System.Threading.Tasks;
using Nancy;
using Nancy.Testing;
using netcoretalk.Features.Home;
using Xunit;

namespace SuperWebProject.Tests
{
    public class NameGeneratorTests
    {
        [Fact]
        public void NameShouldNotBeNumber()
        {
            var subject = new NameGenerator();
            var result = subject.GetName();

            Assert.NotEqual("1", result);
        }

        [Fact]
        public async Task IndexShouldBeOk()
        {
            var browser = new Browser(with => {
                with.Dependency<NameGenerator>();
                with.Module<HomeModule>();
            });

            var result = await browser.Get("/", ctx=>
            {
                ctx.Accept("application/json");
            });

            var body = result.Body.DeserializeJson<string>();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}