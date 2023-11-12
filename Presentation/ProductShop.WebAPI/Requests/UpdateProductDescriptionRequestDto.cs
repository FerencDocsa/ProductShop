using System.ComponentModel.DataAnnotations;

namespace ProductShop.WebAPI.Requests
{
    public class UpdateProductDescriptionRequestDto
    {
        [Required] 
        [StringLength(200)] 
        public string Description { get; set; } = string.Empty;
    }
}
