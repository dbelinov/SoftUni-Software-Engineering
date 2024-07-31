using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos;

[XmlType("Pharmacy")]
public class PharmacyImportDto
{
    [Required]
    [MinLength(2)]
    [MaxLength(50)]
    [XmlElement("Name")]
    public string Name { get; set; }
    
    [Required]
    [MinLength(14)]
    [MaxLength(14)]
    [RegularExpression(@"\([0-9]{3}\) [0-9]{3}\-[0-9]{4}")]
    [XmlElement("PhoneNumber")]
    public string PhoneNumber { get; set; }
    
    [Required]
    [XmlAttribute("non-stop")]
    public string IsNonStop { get; set; }

    [XmlArray("Medicines")]
    public MedicineImportDto[] Medicines { get; set; }
}