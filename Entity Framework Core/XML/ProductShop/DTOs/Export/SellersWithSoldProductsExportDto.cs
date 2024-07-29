using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("User")]
public class SellersWithSoldProductsExportDto
{
    [XmlElement("firstName")]
    public string FirstName { get; set; }
    
    [XmlElement("lastName")]
    public string LastName { get; set; }
    
    [XmlArray("soldProducts")]
    public SoldProductsExportDto[] SoldProducts { get; set; }
}