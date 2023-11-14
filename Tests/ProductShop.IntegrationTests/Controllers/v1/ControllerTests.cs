using ProductShop.IntegrationTests.Products;
using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using ProductShop.Domain.Entities.Product;
using Xunit;
using ProductShop.WebAPI.Requests;

namespace ProductShop.IntegrationTests.Controllers.v1
{
    public class ControllerTests : ControllersTestBase
    {
        private const string V1_API_PRODUCTS_URL = "api/v1/Products";

        public ControllerTests(TestWebApplicationFactory factory) : base(factory)
        { }

        [Fact]
        public async Task GetProductById_ProductExists_ReturnsProduct()
        {
            // Arrange
            Utilities.ReSeedData(Context);
            var productId = 1;

            // Act
            var response = await Utilities.MakeApiCallAsync(_client, $"{V1_API_PRODUCTS_URL}/{productId}", HttpMethod.Get, "");
            var result = await response.Content.ReadFromJsonAsync<Product>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().NotBeNull();
            result.Id.Should().Be(productId);
        }

        [Fact]
        public async Task GetProductById_ProductMotExists_ReturnsNotFound()
        {
            // Arrange
            Utilities.ReSeedData(Context);
            var productId = 11;

            // Act
            var response = await Utilities.MakeApiCallAsync(_client, $"{V1_API_PRODUCTS_URL}/{productId}", HttpMethod.Get, "");
            var result = await response.Content.ReadFromJsonAsync<Product>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetAllProducts_ProductsExists_ReturnsProducts()
        {
            // Arrange
            Utilities.ReSeedData(Context);
            var productId = 11;

            // Act
            var response = await Utilities.MakeApiCallAsync(_client, $"{V1_API_PRODUCTS_URL}/GetAll", HttpMethod.Get, "");
            var result = await response.Content.ReadFromJsonAsync<List<Product>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Count.Should().Be(10);
        }

        [Fact]
        public async Task UpdateProduct_ValidDescription_ReturnsNoContent()
        {
            // Arrange
            Utilities.ReSeedData(Context);
            var productId = 1;
            var newDescription = "new description";
            var request = new UpdateProductDescriptionRequestDto { Description = newDescription };

            // Act
            var response = await Utilities.MakeApiCallAsync(_client, $"{V1_API_PRODUCTS_URL}/{productId}", HttpMethod.Put, request);
            
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task UpdateProduct_EmptyDescription_ReturnsBadRequest()
        {
            // Arrange
            Utilities.ReSeedData(Context);
            var productId = 1;
            var newDescription = "";
            var request = new UpdateProductDescriptionRequestDto { Description = newDescription };

            // Act
            var response = await Utilities.MakeApiCallAsync(_client, $"{V1_API_PRODUCTS_URL}/{productId}", HttpMethod.Put, request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
