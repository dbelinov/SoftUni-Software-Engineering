using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto;

[XmlType("Despatcher")]
public class DespatcherImportDto
{
    [Required]
    [MinLength(2)]
    [MaxLength(40)]
    [XmlElement("Name")]
    public string Name { get; set; }
    
    [Required]
    [XmlElement("Position")]
    public string Position { get; set; }
    
    [XmlArray("Trucks")]
    public TruckImportDto[] Trucks { get; set; }
}