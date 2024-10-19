using System.ComponentModel.DataAnnotations;
using static DeskMarket.Common.ValidationConstants.CategoryValidationConstants;

namespace DeskMarket.Data.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
    public string Name { get; set; } = string.Empty;
    
    public ICollection<Product> Products { get; set; } = new List<Product>();
}