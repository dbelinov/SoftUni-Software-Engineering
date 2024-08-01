using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos;

[XmlType("District")]
public class DistrictImportDto
{
    [Required]
    [XmlAttribute("Region")]
    public string Region { get; set; }
    
    [Required]
    [MinLength(2)]
    [MaxLength(80)]
    [XmlElement("Name")]
    public string Name { get; set; }
    
    [Required]
    [MinLength(8)]
    [MaxLength(8)]
    [RegularExpression(@"[A-Z]{2}\-[0-9]{5}")]
    [XmlElement("PostalCode")]
    public string PostalCode { get; set; }
    
    [XmlArray("Properties")]
    public PropertyImportDto[] Properties { get; set; }
}