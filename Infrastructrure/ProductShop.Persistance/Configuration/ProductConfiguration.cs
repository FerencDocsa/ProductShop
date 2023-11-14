using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductShop.Domain.Entities.Product;

namespace ProductShop.Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(c => c.Id);

            builder.Property(product => product.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(product => product.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(product => product.ImgUri)
                .IsRequired();

            builder.Property(product => product.Price)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(product => product.Description)
                .HasMaxLength(200);
        }
    }


}
