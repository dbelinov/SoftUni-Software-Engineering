using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("User")]
public class UsersProductsExportDto
{
    [XmlElement("firstName")]
    public string FirstName { get; set; }
    
    [XmlElement("lastName")]
    public string LastName { get; set; }
    
    [XmlElement("age")]
    public int? Age { get; set; }
    
    [XmlArray("SoldProducts")]
    public ProductsExportDto[] SoldProducts { get; set; }
}