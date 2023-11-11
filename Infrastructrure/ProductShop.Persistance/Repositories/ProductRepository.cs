using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductShop.Domain.Entities.Product;
using ProductShop.Persistance.Abstractions.DataContexts;
using ProductShop.Persistence.Abstractions.Repositories;
using ProductShop.Persistence.DataContexts;

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
    }
}
