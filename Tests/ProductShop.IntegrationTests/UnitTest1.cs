using System.Net;
using Azure.Core;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductShop.Application.Requests.Products.Queries;
using ProductShop.Domain.Entities.Product;
using ProductShop.Persistence.Abstractions.DataContexts;
using ProductShop.Persistence.Abstractions.Repositories;
using ProductShop.Persistence.DataContexts;
using ProductShop.WebAPI;
using Xunit;

namespace ProductShop.IntegrationTests
{
    public class UnitTest1 : IClassFixture<TestWebApplicationFactory>
    {
        protected readonly ShopDbContext Context;
        protected readonly IProductRepository ProductRepository;
        private readonly HttpClient _client;

        public UnitTest1(TestWebApplicationFactory factory)
        {
            var scope = factory.Services.CreateScope();
            Context = scope.ServiceProvider.GetRequiredService<ShopDbContext>();
            ProductRepository = scope.ServiceProvider.GetRequiredService<IProductRepository>();
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions());
        }

        [Fact]
        public async Task Test1()
        {
            // Arrange

            // Act 
            
            // Assert

            Utilities.ReSeedData(Context);
            var response = await Utilities.MakeApiCallAsync(_client, "api/v1/Products/GetAll", HttpMethod.Get, "");
        }
    }
}