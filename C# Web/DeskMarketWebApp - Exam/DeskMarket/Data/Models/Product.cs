using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using static DeskMarket.Common.ErrorMessages.ProductErrorMessages;
using static DeskMarket.Common.ValidationConstants.ProductValidationConstants;

namespace DeskMarket.Data.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = NameRequired)]
    [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameLengthError)]
    public string ProductName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = DescriptionRequired)]
    [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = DescriptionLengthError)]
    public string Description { get; set; } = string.Empty;
    
    [Required(ErrorMessage = PriceRequired)]
    [Range(PriceMinValue, PriceMaxValue, ErrorMessage = PriceRangeError)]
    [Column(TypeName = "decimal(6,2)")]
    public decimal Price { get; set; }
    
    public string? ImageUrl { get; set; }
    
    [Required]
    public string SellerId { get; set; } = string.Empty;
    [ForeignKey(nameof(SellerId))]
    public IdentityUser Seller { get; set; }
    
    [Required(ErrorMessage = AddedDateRequired)]
    [DisplayFormat(DataFormatString = DateFormat)] //??
    public DateTime AddedOn { get; set; }
    
    [Required(ErrorMessage = CategoryRequired)]
    public int CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }
    
    public bool IsDeleted { get; set; } = false;
    
    public ICollection<ProductClient> ProductsClients { get; set; } = new List<ProductClient>();
}