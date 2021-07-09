using Xunit;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using API;
using Microsoft.AspNetCore.Mvc.Testing;
using AspNetCore.Http.Extensions;
using System;
using API.Contracts;

namespace API.Test.ServerTests
{
    public class DeleteTests
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public DeleteTests()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        /*[Fact]
        public async Task Delete_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            var body = new ProductCreateModel
            {
                ProductName = "Product",
                Price = 20.00,
                Description = "test test test",
                Category = "test",
                Image = "image url here"
            };

            await client.PostAsJsonAsync("api/product",body);


            // act
            var httpResponse = await client.DeleteAsync("api/product/1");

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }*/
    }
}