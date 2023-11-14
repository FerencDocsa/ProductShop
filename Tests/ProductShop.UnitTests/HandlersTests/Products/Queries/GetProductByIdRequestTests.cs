using FluentAssertions;
using Moq;
using ProductShop.Application.Exceptions;
using ProductShop.Application.Requests.Products.Queries;
using ProductShop.Domain.Entities.Product;
using Xunit;

namespace ProductShop.UnitTests.HandlersTests.Products.Queries
{
    public class GetProductByIdRequestTests : ProductTestBase
    {
        [Fact]
        public async Task Handle_ProductExists_ReturnsProduct()
        {
            // Arrange
            var request = new GetProductByIdRequest { Id = 1 };
            var handler = new GetProductByIdRequestHandler(_productRepositoryMock.Object);

            _productRepositoryMock.Setup(
                    x => x.GetByIdAsync(
                        It.IsAny<int>(),
                        It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Product(1, "Test", new Uri("http://test/com"), 100, "some description"));

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(1);
        }

        [Fact]
        public void Handle_ProductDontExist_ThrowsProductNotFoundException()
        {
            // Arrange
            var request = new GetProductByIdRequest { Id = 1 };
            var handler = new GetProductByIdRequestHandler(_productRepositoryMock.Object);

            // Act
            Func<Task> act = () => Task.FromResult(handler.Handle(request, default));

            // Assert 
            act.Should().ThrowAsync<ProductNotFoundException>();
        }
    }
}