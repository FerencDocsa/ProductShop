using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ProductShop.Application.Requests.v1.Products.Commands
{
    public class UpdateProductDescriptionRequest : IRequest
    {
        [Required]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Uri ImgUri { get; set; }

        public string Description { get; set; }
    }
}
