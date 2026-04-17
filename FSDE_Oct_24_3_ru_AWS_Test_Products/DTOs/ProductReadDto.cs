namespace FSDE_Oct_24_3_ru_AWS_Test_Products.DTOs;

public class ProductReadDto
{
    public int Id { get; set; }   
    public string Name { get; set; } = string.Empty;    
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }
}
