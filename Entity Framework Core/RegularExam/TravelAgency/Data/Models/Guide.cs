using System.ComponentModel.DataAnnotations;
using TravelAgency.Data.Models.Enums;

namespace TravelAgency.Data.Models;

public class Guide
{
    public Guide()
    {
        TourPackagesGuides = new List<TourPackageGuide>();
    }
    
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(60)]
    public string FullName { get; set; }
    
    [Required]
    public Language Language { get; set; }
    
    public ICollection<TourPackageGuide> TourPackagesGuides { get; set; }
}