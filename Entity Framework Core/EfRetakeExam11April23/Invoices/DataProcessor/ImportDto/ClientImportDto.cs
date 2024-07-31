using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto;

[XmlType("Client")]
public class ClientImportDto
{
    [Required]
    [MinLength(10)]
    [MaxLength(25)]
    [XmlElement("Name")]
    public string Name { get; set; }
    
    [Required]
    [MinLength(10)]
    [MaxLength(15)]
    [XmlElement("NumberVat")]
    public string NumberVat { get; set; }
    
    [XmlArray("Addresses")]
    public AddressImportDto[] Addresses { get; set; }
}