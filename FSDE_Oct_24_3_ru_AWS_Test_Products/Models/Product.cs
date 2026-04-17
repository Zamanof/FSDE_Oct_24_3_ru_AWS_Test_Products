using System.ComponentModel.DataAnnotations;

namespace FSDE_Oct_24_3_ru_AWS_Test_Products.Models;

public class Product
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    public string Category { get; set; } = string.Empty;
    [Range(0.01, 100000)]
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
