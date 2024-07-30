using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor.ImportDto;

public class SellersImportDto
{
    [Required]
    [MinLength(5)]
    [MaxLength(20)]
    public string Name { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(30)]
    public string Address { get; set; }

    [Required]
    public string Country { get; set; }

    [Required]
    [RegularExpression(@"www\.[A-Za-z0-9-]+\.com")]
    public string Website  {get; set; }

    [JsonProperty("Boardgames")]
    public int[] BoardgamesIds { get; set; }
}