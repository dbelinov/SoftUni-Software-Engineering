using System.ComponentModel.DataAnnotations;

namespace Cadastre.DataProcessor.ImportDtos;

public class CitizenImportDto
{
    [Required]
    [MinLength(2)]
    [MaxLength(30)]
    public string FirstName { get; set; }
    
    [Required]
    [MinLength(2)]
    [MaxLength(30)]
    public string LastName { get; set; }
    
    [Required]
    public string BirthDate { get; set; }
    
    [Required]
    public string MaritalStatus { get; set; }
    
    public int[] Properties { get; set; }
}