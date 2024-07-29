using System.Xml.Serialization;

namespace ProductShop.DTOs.Import;

[XmlType("Category")]
public class CategoriesImportDto
{
    [XmlElement("name")]
    public string Name { get; set; }
}