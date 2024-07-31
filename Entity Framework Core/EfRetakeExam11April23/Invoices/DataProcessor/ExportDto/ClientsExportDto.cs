using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto;

[XmlType("Client")]
public class ClientsExportDto
{
    [XmlAttribute("InvoicesCount")]
    public int InvoicesCount { get; set; }
    
    [XmlElement("ClientName")]
    public string ClientName { get; set; }
    
    [XmlElement("VatNumber")]
    public string VatNumber { get; set; }
    
    [XmlArray("Invoices")]
    public InvoicesExportDto[] Invoices { get; set; }
}