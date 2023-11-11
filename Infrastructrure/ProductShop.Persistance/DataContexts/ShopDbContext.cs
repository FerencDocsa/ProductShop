using Microsoft.EntityFrameworkCore;
using ProductShop.Domain.Entities.Product;
using ProductShop.Persistance.Abstractions.DataContexts;
using ProductShop.Persistence.Extensions;

namespace ProductShop.Persistence.DataContexts
{
    public class ShopDbContext : DbContext, IShopDbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        #region Entities

        public DbSet<Product> Products => Set<Product>();

        #endregion

        /// <summary>
        /// Applies all configurations of type IEntityTypeConfiguration from current assembly and seeds data
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopDbContext).Assembly).Seed();
        }
    }
}
