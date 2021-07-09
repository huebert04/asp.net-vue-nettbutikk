using Xunit;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using API;

namespace API.Test.ServerTests
{
    public class GetTests
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public GetTests()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [Fact]
        public async Task Get_OnRoot_ShouldReturn_OKStatusCode()
        {
            //arrange
            var client = _factory.CreateClient();
            //act
            var httpResponse = await client.GetAsync("api/product");
            //assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task Get_WithId_ShouldReturn_NotFound()
        {
            var client = _factory.CreateClient();

            var httpResponse = await client.GetAsync("api/product/1");

            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}