using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos;

[XmlType("Property")]
public class PropertyImportDto
{
    [Required]
    [MinLength(16)]
    [MaxLength(20)]
    [XmlElement("PropertyIdentifier")]
    public string PropertyIdentifier { get; set; }
    
    [Required]
    [Range(0, int.MaxValue)]
    [XmlElement("Area")]
    public int Area { get; set; }
    
    [MinLength(5)]
    [MaxLength(500)]
    [XmlElement("Details")]
    public string Details { get; set; }
    
    [Required]
    [MinLength(5)]
    [MaxLength(200)]
    [XmlElement("Address")]
    public string Address { get; set; }
    
    [Required]
    [XmlElement("DateOfAcquisition")]
    public string DateOfAcquisition { get; set; }
}