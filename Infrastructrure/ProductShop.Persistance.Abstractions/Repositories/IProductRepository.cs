using ProductShop.Domain.Entities.Product;

namespace ProductShop.Persistence.Abstractions.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken cancellationToken);

        Task<IEnumerable<Product>> GetAllProductsPagedAsync(int page, int pageSize, string? searchBy, string? orderBy, string? sortBy, CancellationToken cancellationToken);
    }
}
