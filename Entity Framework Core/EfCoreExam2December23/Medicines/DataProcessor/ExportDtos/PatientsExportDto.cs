using System.Xml.Serialization;

namespace Medicines.DataProcessor.ExportDtos;

[XmlType("Patient")]
public class PatientsExportDto
{
    [XmlAttribute("Gender")]
    public string Gender { get; set; }
    
    [XmlElement("Name")]
    public string Name { get; set; }
    
    [XmlElement("AgeGroup")]
    public string AgeGroup { get; set; }
    
    [XmlArray("Medicines")]
    public MedicinesExportDto[] Medicines { get; set; }
}