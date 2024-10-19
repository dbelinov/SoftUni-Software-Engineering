using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace DeskMarket.Data.Models;

[PrimaryKey(nameof(ProductId), nameof(ClientId))]
public class ProductClient
{
    [Required]
    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; }

    [Required] 
    public string ClientId { get; set; } = string.Empty;
    [ForeignKey(nameof(ClientId))]
    public IdentityUser Client { get; set; }
}