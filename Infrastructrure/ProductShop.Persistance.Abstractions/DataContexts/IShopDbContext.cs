using Microsoft.EntityFrameworkCore;
using ProductShop.Domain.Entities.Product;

namespace ProductShop.Persistence.Abstractions.DataContexts
{
    public interface IShopDbContext
    {
        DbSet<Product> Products { get; }

        public Task SaveChangesAsync();
    }
}
