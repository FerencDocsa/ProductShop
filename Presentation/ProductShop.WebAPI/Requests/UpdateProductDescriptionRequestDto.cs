using System.ComponentModel.DataAnnotations;

namespace ProductShop.WebAPI.Requests
{
    /// <summary>
    /// Dto for Updating product request
    /// </summary>
    public class UpdateProductDescriptionRequestDto
    {
        [Required (ErrorMessage = "Description cannot be empty")]
        [StringLength(200, ErrorMessage = "The maximum length of description is 200 characters")]
        public string Description { get; set; } = string.Empty;
    }
}
