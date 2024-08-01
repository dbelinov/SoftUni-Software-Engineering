using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto;

[XmlType("Truck")]
public class TruckImportDto
{
    [Required]
    [MinLength(8)]
    [MaxLength(8)]
    [RegularExpression(@"[A-Z]{2}[0-9]{4}[A-Z]{2}")]
    [XmlElement("RegistrationNumber")]
    public string RegistrationNumber { get; set; }
    
    [Required]
    [MinLength(17)]
    [MaxLength(17)]
    [XmlElement("VinNumber")]
    public string VinNumber { get; set; }
    
    [Required]
    [Range(950, 1420)]
    [XmlElement("TankCapacity")]
    public int TankCapacity { get; set; }
    
    [Required]
    [Range(5000, 29000)]
    [XmlElement("CargoCapacity")]
    public int CargoCapacity { get; set; }
    
    [Required]
    [Range(0, 3)]
    [XmlElement("CategoryType")]
    public int CategoryType { get; set; }
    
    [Required]
    [Range(0, 4)]
    [XmlElement("MakeType")]
    public int MakeType { get; set; }
}