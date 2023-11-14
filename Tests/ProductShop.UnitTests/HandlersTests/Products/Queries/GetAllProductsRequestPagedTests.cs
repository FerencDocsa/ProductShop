using FluentAssertions;
using Moq;
using ProductShop.Application.Requests.Products.Queries;
using ProductShop.Domain.Entities.Product;
using Xunit;

namespace ProductShop.UnitTests.HandlersTests.Products.Queries
{
    public class GetAllProductsRequestPagedTests : ProductTestBase
    {
        [Fact]
        public async Task Handle_ShouldReturnProducts_WhenRequestIsValid()
        {
            // Arrange
            var handler = new GetAllProductsRequestPagedHandler(_productRepositoryMock.Object);
            var request = new GetAllProductsRequestPaged(1, 10, "search", "Name", "asc");
            _productRepositoryMock.Setup(repo => repo.GetAllProductsPagedAsync(
                    request.Page, request.PageSize, request.SearchBy, request.OrderBy, request.SortBy, default))
                .ReturnsAsync(GetTestProducts());

            // Act
            var result = (await handler.Handle(request, default)).ToList();

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(10);
            result.Should().BeEquivalentTo(GetTestProducts());
        }

        [Fact]
        public async Task Handle_ShouldReturnEmptyList_WhenNoProductsFound()
        {
            // Arrange
            var handler = new GetAllProductsRequestPagedHandler(_productRepositoryMock.Object);
            var request = new GetAllProductsRequestPaged(1, 10, "search", "Name", "asc");
            
            _productRepositoryMock.Setup(repo => repo.GetAllProductsPagedAsync(
                    request.Page, request.PageSize, request.SearchBy, request.OrderBy, request.SortBy, default))
                .ReturnsAsync(new List<Product>());

            // Act
            var result = (await handler.Handle(request, default)).ToList();

            // Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(0);
            result.Should().BeEmpty();
        }
    }
}
