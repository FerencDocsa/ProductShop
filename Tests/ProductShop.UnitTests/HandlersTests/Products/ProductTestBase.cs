using Moq;
using ProductShop.Domain.Entities.Product;
using ProductShop.Persistence.Abstractions.Repositories;

namespace ProductShop.UnitTests.HandlersTests.Products
{
    public class ProductTestBase
    {
        public readonly Mock<IProductRepository> _productRepositoryMock;

        public ProductTestBase()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
        }

        public IEnumerable<Product> GetTestProducts()
        {
            return new List<Product>()
            {
                new(1, "Test1", new Uri("http://test/com"), 100, "test1"),
                new(2, "Test2", new Uri("http://test/com"), 100, "test1"),
                new(3, "Test3", new Uri("http://test/com"), 100, "test1"),
                new(4, "Test4", new Uri("http://test/com"), 100, "test1"),
                new(5, "Test5", new Uri("http://test/com"), 100, "test1"),
                new(6, "Test6", new Uri("http://test/com"), 100, "test1"),
                new(7, "Test7", new Uri("http://test/com"), 100, "test1"),
                new(8, "Test8", new Uri("http://test/com"), 100, "test1"),
                new(9, "Test9", new Uri("http://test/com"), 100, "test1"),
                new(10, "Test10", new Uri("http://test/com"), 100, "test1"),
            };
        }
    }
}
