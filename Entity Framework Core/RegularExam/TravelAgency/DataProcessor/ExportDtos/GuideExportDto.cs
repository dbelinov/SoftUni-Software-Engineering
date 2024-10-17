using System.Xml.Serialization;

namespace TravelAgency.DataProcessor.ExportDtos;

[XmlType("Guide")]
public class GuideExportDto
{
    [XmlElement("FullName")]
    public string FullName { get; set; }
    
    [XmlArray("TourPackages")]
    public TourPackageExportDto[] TourPackages { get; set; }
}