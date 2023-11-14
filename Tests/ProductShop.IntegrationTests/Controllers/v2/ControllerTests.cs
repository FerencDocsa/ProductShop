using ProductShop.Domain.Entities.Product;
using ProductShop.IntegrationTests.Products;
using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Xunit;

namespace ProductShop.IntegrationTests.Controllers.v2
{
    public class ControllerTests : ControllersTestBase
    {
        private const string V2_API_PRODUCTS_URL = "api/v2/Products";
        
        public ControllerTests(TestWebApplicationFactory factory) : base(factory) { }


        [Fact]
        public async Task GellAllProductsPaginated_WithValidRequest_ReturnsProducts()
        {
            // Arrange
            Utilities.ReSeedData(Context);

            // Act
            var response = await Utilities.MakeApiCallAsync(_client, $"{V2_API_PRODUCTS_URL}", HttpMethod.Get, "");
            var result = await response.Content.ReadFromJsonAsync<List<Product>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Count().Should().Be(10);
        }

        [Fact]
        public async Task GellAllProductsPaginated_WithDefinedPaging_ReturnsProducts()
        {
            // Arrange
            Utilities.ReSeedData(Context);
            var page = 1;
            var pageSize = 5;

            // Act
            var response = await Utilities.MakeApiCallAsync(_client, $"{V2_API_PRODUCTS_URL}?page={page}&pageSize={pageSize}", HttpMethod.Get, "");
            var result = await response.Content.ReadFromJsonAsync<List<Product>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Count().Should().Be(5);
        }

        [Fact]
        public async Task GellAllProductsPaginated_SortByName_ReturnsProducts()
        {
            // Arrange
            Utilities.ReSeedData(Context);
            var page = 1;
            var pageSize = 5;

            // Act
            var response = await Utilities.MakeApiCallAsync(_client, $"{V2_API_PRODUCTS_URL}?page={page}&pageSize={pageSize}&searchBy=Test10", HttpMethod.Get, "");
            var result = await response.Content.ReadFromJsonAsync<List<Product>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Count().Should().Be(1);
        }

    }
}
