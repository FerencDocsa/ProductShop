namespace ProductShop.Domain.Entities.Product
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }

        public Uri ImgUri { get; private set; }

        public decimal Price { get; private set; }

        public string? Description { get; private set; }

        public Product(int id, string name, Uri imgUri, decimal price, string? description) : base(id)
        {
            Name = name;
            ImgUri = imgUri;
            Price = price;
            Description = description;
        }

        public void Update(string name, Uri imgUri, decimal price, string? description)
        {
            Name = name;
            ImgUri = imgUri;
            Price = price;
            Description = description;
        }
    }
}