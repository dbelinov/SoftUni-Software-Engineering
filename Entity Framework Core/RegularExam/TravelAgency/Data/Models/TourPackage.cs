using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Data.Models;

public class TourPackage
{
    public TourPackage()
    {
        Bookings = new List<Booking>();
        TourPackagesGuides = new List<TourPackageGuide>();
    }
    
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(40)]
    public string PackageName { get; set; }
    
    [MaxLength(200)]
    public string Description { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    public ICollection<Booking> Bookings { get; set; }
    
    public ICollection<TourPackageGuide> TourPackagesGuides { get; set; }
}