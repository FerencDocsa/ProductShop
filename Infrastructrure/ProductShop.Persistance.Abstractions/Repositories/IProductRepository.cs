using ProductShop.Domain.Entities.Product;

namespace ProductShop.Persistence.Abstractions.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// Get product by ID
        /// </summary>
        /// <param name="id">ID of product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Product if found or null</returns>
        Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Get all products from database
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Enumerable of products</returns>
        Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Get paginated result of all products meeting provided params 
        /// </summary>
        /// <param name="page">Page of result</param>
        /// <param name="pageSize">Page size of result</param>
        /// <param name="searchBy">Search criteria (e.g. what we search for)</param>
        /// <param name="orderBy">Order by criteria (which column are we ordering by)</param>
        /// <param name="sortBy">Sort order for results (asc or desc)</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Enumerable of products</returns>
        Task<IEnumerable<Product>> GetAllProductsPagedAsync(int page, int pageSize, string? searchBy, string? orderBy, string? sortBy, CancellationToken cancellationToken);

        /// <summary>
        /// Updates description of provided Product entity
        /// </summary>
        /// <param name="product">Product to update</param>
        /// <param name="description">New description</param>
        void UpdateProductDescriptionAsync(Product product, string description);
    }
}
