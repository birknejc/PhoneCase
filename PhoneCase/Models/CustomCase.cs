using System.ComponentModel.DataAnnotations;
using PhoneCase.ModelVal;

namespace PhoneCase.Models
{
    public class CustomCase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Brand is required")]
        [MaxLength(25, ErrorMessage = "Brand should not exceed 25 characters")]
        [BrandVal(new string[] { "Apple", "Samsung", "Razor", "TheAlmightyMotorola" })]
        public string Brand { get; set; } = "";

        [Required(ErrorMessage = "Model is required")]
        [MaxLength(25, ErrorMessage = "Model should not exceed 25 characters")]
        public string Model { get; set; } = "";

        [Required(ErrorMessage = "Material is required")]
        [MaxLength(30, ErrorMessage = "Material cannot exceed 30 characters")]
        [MaterialVal(new string[] { "Carbon Fiber", "Metal", "Titanium", "Plastic", "Sheet Metal", "Clam Shell", "Faux Animal Fur", "Apples" })]
        public string Material { get; set; } = "";

        [Required(ErrorMessage = "Price is required")]
        [Range(1, 850, ErrorMessage = "Price must be between 1 and 850")]
        public decimal? Cost { get; set; } = null;

        [Required(ErrorMessage = "Trim color is required")]
        [MaxLength(30, ErrorMessage = "Trim color should not exceed 30 characters")]
        public string TrimColor { get; set; } = "";

        [Required(ErrorMessage = "Accent color is required")]
        [MaxLength(30, ErrorMessage = "Accent color should not exceed 30 characters")]
        [ColorVal(new string[] { "Blue", "Pink", "Yellow", "Green", "Greener", "Yellowish", "Blueberry" })]
        public string AccentColor { get; set; } = "";
    }
}

