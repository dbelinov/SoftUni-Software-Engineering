using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto;

[XmlType("Despatcher")]
public class DespatcherExportDto
{
    [XmlAttribute("TrucksCount")]
    public int TrucksCount { get; set; }
    
    [XmlElement("DespatcherName")]
    public string DespatcherName { get; set; }
    
    [XmlArray("Trucks")]
    public TruckExportDto[] Trucks { get; set; }
}