using ProductShop.Domain.Entities.Product;

namespace ProductShop.Persistence.Abstractions.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<IEnumerable<Product>> GetAllProductsPagedAsync(int page, int pageSize, string? searchBy, string? orderBy, string? sortBy);
    }
}
