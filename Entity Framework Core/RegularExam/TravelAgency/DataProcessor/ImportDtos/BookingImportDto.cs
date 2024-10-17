using System.ComponentModel.DataAnnotations;

namespace TravelAgency.DataProcessor.ImportDtos;

public class BookingImportDto
{
    [Required]
    public string BookingDate { get; set; }
    
    [Required]
    [MinLength(4)]
    [MaxLength(60)]
    public string CustomerName { get; set; }
    
    [Required]
    [MinLength(2)]
    [MaxLength(40)]
    public string TourPackageName { get; set; }
}