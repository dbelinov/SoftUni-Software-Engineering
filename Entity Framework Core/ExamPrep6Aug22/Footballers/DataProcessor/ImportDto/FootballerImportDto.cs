using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto;

[XmlType("Footballer")]
public class FootballerImportDto
{
    [Required]
    [MinLength(2)]
    [MaxLength(40)]
    [XmlElement("Name")]
    public string Name { get; set; }
    
    [Required]
    [XmlElement("ContractStartDate")]
    public string ContractStartDate { get; set; }
    
    [Required]
    [XmlElement("ContractEndDate")]
    public string ContractEndDate { get; set; }
    
    [Required]
    [Range(0, 4)]
    [XmlElement("BestSkillType")]
    public int BestSkillType { get; set; }
    
    [Required]
    [Range(0, 3)]
    [XmlElement("PositionType")]
    public int PositionType { get; set; }
}