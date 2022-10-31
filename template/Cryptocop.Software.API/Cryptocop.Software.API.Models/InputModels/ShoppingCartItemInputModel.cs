using System.ComponentModel.DataAnnotations;

namespace Cryptocop.Software.API.Models.InputModels
{
    public class ShoppingCartItemInputModel
    {
        [Required]
        public string ProductIdentifier { get; set; }
        [Required]
        [Range(0.01,1)]
        public float? Quantity { get; set; }
    }
}