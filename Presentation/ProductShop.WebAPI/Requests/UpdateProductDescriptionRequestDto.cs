using System.ComponentModel.DataAnnotations;

namespace ProductShop.WebAPI.Requests
{
    /// <summary>
    /// Dto for Updating product request
    /// </summary>
    public class UpdateProductDescriptionRequestDto
    {
        /// <summary>
        /// New description for product
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
