using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto;

[XmlType("Creator")]
public class CreatorsExportDto
{
    [XmlElement("CreatorName")]
    public string Name { get; set; }
    
    [XmlAttribute("BoardgamesCount")]
    public int BoardgamesCount { get; set; }
    
    [XmlArray("Boardgames")]
    public BoardgamesExportDto[] Boardgames { get; set; }
}