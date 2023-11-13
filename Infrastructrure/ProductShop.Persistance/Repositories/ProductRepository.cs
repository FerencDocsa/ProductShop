using System.Linq.Expressions;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using ProductShop.Domain.Entities.Product;
using ProductShop.Persistence.Abstractions.DataContexts;
using ProductShop.Persistence.Abstractions.Repositories;
using ProductShop.Persistence.Exceptions;

namespace ProductShop.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IShopDbContext _context;

        public ProductRepository(IShopDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            return product;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            var products = await _context.Products.AsNoTracking().ToListAsync(cancellationToken);
            return products;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Product>> GetAllProductsPagedAsync(int page, int pageSize, string? searchBy, string? orderBy, string? sortBy, CancellationToken cancellationToken)
        {
            var productQuery = _context.Products.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchBy))
            {
                productQuery = productQuery.Where(c =>
                    c.Name.Contains(searchBy) ||
                    (c.Description != null && string.IsNullOrWhiteSpace(c.Description) && c.Description.Contains(searchBy)));
            }

            var sortingProperty = GetSortingProperty(sortBy);
            productQuery = orderBy?.ToLower() == "desc" ? productQuery.OrderByDescending(sortingProperty) : productQuery.OrderBy(sortingProperty);

            var products = await productQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize).
                ToListAsync(cancellationToken);

            return products;
        }

        public void UpdateProductDescriptionAsync(Product product, string description)
        {
            product.UpdateDescription(description);
            try
            {
                _context.Products.Update(product);
                _context.SaveChangesAsync();
            }
            catch
            {
                throw new ProductUpdateException(product.Id);
            }
        }

        private static Expression<Func<Product, object>> GetSortingProperty(string? sortBy)
        {
            return sortBy?.ToLower() switch
            {
                "Name" => product => product.Name,
                "Price" => product => product.Price,
                _ => product => product.Id
            };
        }
    }
}
