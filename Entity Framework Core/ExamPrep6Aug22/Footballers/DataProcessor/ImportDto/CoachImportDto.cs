using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto;

[XmlType("Coach")]
public class CoachImportDto
{
    [Required]
    [MinLength(2)]
    [MaxLength(40)]
    [XmlElement("Name")]
    public string Name { get; set; }
    
    [Required]
    [XmlElement("Nationality")]
    public string Nationality { get; set; }
    
    [XmlArray("Footballers")]
    public FootballerImportDto[] Footballers { get; set; }
}