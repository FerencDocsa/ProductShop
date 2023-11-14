using Moq;
using ProductShop.Domain.Entities.Product;
using FluentAssertions;
using Xunit;
using ProductShop.Application.Requests.Products.Commands;
using ProductShop.Application.Exceptions;

namespace ProductShop.UnitTests.HandlersTests.Products.Commands
{
    public class UpdateProductDescriptionRequestTests : ProductTestBase
    {
        [Fact]
        public void Handle_ProductExists_ShouldNotThrowException()
        {
            // Arrange
            var product = new Product(1, "Test", new Uri("http://test.com"), 100, "new description");
            var request = new UpdateProductDescriptionRequest { ProductId = product.Id, Description = product.Description ?? string.Empty };
            var handler = new UpdateProductDescriptionRequestHandler( _productRepositoryMock.Object);

            _productRepositoryMock.Setup(
                    x => x.GetByIdAsync(
                        It.IsAny<int>(),
                        It.IsAny<CancellationToken>()))
                .ReturnsAsync(product);

            _productRepositoryMock.Setup(
                x => x.UpdateProductDescriptionAsync(It.IsAny<Product>(), It.IsAny<string>()));
            // Act
            Func<Task> act = () => Task.FromResult(handler.Handle(request, default));

            // Assert
            act.Should().NotThrowAsync();
        }

        [Fact]
        public void Handle_ProductDontExists_ShouldThrowProductNotFoundException()
        {
            // Arrange
            var product = new Product(1, "Test", new Uri("http://test.com"), 100, "new description");
            var request = new UpdateProductDescriptionRequest { ProductId = product.Id, Description = product.Description ?? string.Empty };
            var handler = new UpdateProductDescriptionRequestHandler(_productRepositoryMock.Object);

            _productRepositoryMock.Setup(
                x => x.UpdateProductDescriptionAsync(It.IsAny<Product>(), It.IsAny<string>()));
            // Act
            Func<Task> act = () => Task.FromResult(handler.Handle(request, default));

            // Assert
            act.Should().ThrowAsync<ProductNotFoundException>();
        }
    }
}