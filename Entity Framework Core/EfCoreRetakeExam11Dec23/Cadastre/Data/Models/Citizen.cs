using System.ComponentModel.DataAnnotations;
using Cadastre.Data.Enumerations;

namespace Cadastre.Data.Models;

public class Citizen
{
    public Citizen()
    {
        PropertiesCitizens = new List<PropertyCitizen>();
    }
    
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string LastName { get; set; }
    
    [Required]
    public DateTime BirthDate { get; set; }
    
    [Required]
    public MaritalStatus MaritalStatus { get; set; }
    public ICollection<PropertyCitizen> PropertiesCitizens { get; set; }
}