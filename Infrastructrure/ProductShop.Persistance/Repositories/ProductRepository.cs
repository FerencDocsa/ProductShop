using Microsoft.EntityFrameworkCore;
using ProductShop.Domain.Entities.Product;
using ProductShop.Persistance.Abstractions.DataContexts;
using ProductShop.Persistence.Abstractions.Repositories;

namespace ProductShop.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IShopDbContext _context;

        public ProductRepository(IShopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> GetAllProductsPagedAsync(int page, int pageSize)
        {
            var products = await _context
                .Products
                .Skip((page - 1) * pageSize)
                .Take(pageSize).
                ToListAsync();

            return products;
        }
    }
}
