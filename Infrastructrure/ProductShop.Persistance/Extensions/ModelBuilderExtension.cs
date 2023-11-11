using Microsoft.EntityFrameworkCore;
using ProductShop.Domain.Entities.Product;

namespace ProductShop.Persistence.Extensions
{
    internal static class ModelBuilderExtension
    {
        /// <summary>
        /// Extension method for ModelBuilder that allows to seed data directly to entity
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <returns></returns>
        public static ModelBuilder Seed(this ModelBuilder modelBuilder)
        {
            var products = new List<Product>
            {
                new(1, "Acer Aspire 3 ",
                    new Uri("https://image.alza.cz/products/NC027p0u0/NC027p0u0.jpg?width=500&height=500"), 6999,
                    "Intel Celeron N4500 Jasper Lake"),
                new(2, "iPhone 14 ", new Uri("https://image.alza.cz/products/RI041b1/RI041b1.jpg?width=500&height=500"),
                    18990, "128GB"),
                new(3, "Apple 20W USB-C",
                    new Uri("https://image.alza.cz/products/RI012i1b48/RI012i1b48.jpg?width=500&height=500"), 589,
                    "20W Charger"),
                new(4, "LEGO Technic",
                    new Uri("https://image.alza.cz/products/LO42141/LO42141.jpg?width=500&height=500"), 3119,
                    "Závodní auto McLaren Formule 1")
            };

            modelBuilder.Entity<Product>().HasData(products);
            return modelBuilder;
        }
    }
}
