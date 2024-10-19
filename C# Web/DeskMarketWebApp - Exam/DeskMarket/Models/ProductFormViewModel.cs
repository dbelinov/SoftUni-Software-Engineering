using DeskMarket.Data.Models;
using System.ComponentModel.DataAnnotations;
using static DeskMarket.Common.ErrorMessages.ProductErrorMessages;
using static DeskMarket.Common.ValidationConstants.ProductValidationConstants;

namespace DeskMarket.Models;

public class ProductFormViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = NameRequired)]
    [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameLengthError)]
    public string ProductName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = PriceRequired)]
    [Range(PriceMinValue, PriceMaxValue, ErrorMessage = PriceRangeError)]
    public decimal Price { get; set; }
    
    [Required(ErrorMessage = DescriptionRequired)]
    [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = DescriptionLengthError)]
    public string Description { get; set; } = string.Empty;
    
    public string? ImageUrl { get; set; }
    
    [Required(ErrorMessage = AddedDateRequired)]
    public string AddedOn { get; set; } = string.Empty;
    
    [Required(ErrorMessage = CategoryRequired)]
    public int CategoryId { get; set; }

    public string SellerId { get; set; } = string.Empty;
    
    public ICollection<Category> Categories { get; set; } = new List<Category>();
}