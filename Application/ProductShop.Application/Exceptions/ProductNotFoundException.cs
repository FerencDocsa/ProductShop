using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Application.Exceptions
{
    public sealed class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(int productId) 
            : base($"Product with ID {productId} was not found") { }
    }
}
