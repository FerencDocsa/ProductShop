namespace ProductShop.Application.Exceptions
{
    public sealed class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(int productId) 
            : base($"Product with ID {productId} was not found") { }
    }
}
