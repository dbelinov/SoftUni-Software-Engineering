using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TravelAgency.DataProcessor.ImportDtos;

[XmlType("Customer")]
public class CustomerImportDto
{
    [Required]
    [MinLength(13)]
    [MaxLength(13)]
    [RegularExpression(@"\+[0-9]{12}")]
    [XmlAttribute("phoneNumber")]
    public string PhoneNumber { get; set; }
    
    [Required]
    [MinLength(4)]
    [MaxLength(60)]
    [XmlElement("FullName")]
    public string FullName { get; set; }
    
    [Required]
    [MinLength(6)]
    [MaxLength(50)]
    [XmlElement("Email")]
    public string Email { get; set; }
}