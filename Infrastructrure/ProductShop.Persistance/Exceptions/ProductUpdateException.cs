namespace ProductShop.Persistence.Exceptions
{
    public class ProductUpdateException : Exception
    {
        public ProductUpdateException(int productId) 
            : base($"There was an error when trying to update Product with ID {productId}") 
        { }
    }

}
