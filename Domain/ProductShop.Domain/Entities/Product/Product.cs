namespace ProductShop.Domain.Entities.Product
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public Uri ImgUri { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public Product(int id, string name, Uri imgUri, decimal price, string? description) : base(id)
        {
            Name = name;
            ImgUri = imgUri;
            Price = price;
            Description = description;
        }
    }
}