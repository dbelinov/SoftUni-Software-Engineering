using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto;

[XmlType("Creator")]
public class CreatorsImportDto
{
    [Required]
    [MinLength(2)]
    [MaxLength(7)]
    [XmlElement("FirstName")]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(7)]
    [XmlElement("LastName")]
    public string LastName { get; set; }
    
    [XmlArray("Boardgames")]
    public BoardgamesImportDto[] Boardgames { get; set; }
}