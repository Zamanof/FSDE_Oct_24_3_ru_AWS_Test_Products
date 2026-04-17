using FSDE_Oct_24_3_ru_AWS_Test_Products.Data;
using FSDE_Oct_24_3_ru_AWS_Test_Products.DTOs;
using FSDE_Oct_24_3_ru_AWS_Test_Products.Models;
using FSDE_Oct_24_3_ru_AWS_Test_Products.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FSDE_Oct_24_3_ru_AWS_Test_Products.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IStorageService _storage;

    public ProductsController(AppDbContext context, IStorageService storage)
    {
        _context = context;
        _storage = storage;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetProducts()
    {
        var products = await _context.Products
                                     .OrderByDescending(p => p.CreatedAt)
                                     .Select(p => MapToReadDto(p))
                                     .ToListAsync();
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductReadDto>> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
            return NotFound("Product not found");

        return Ok(MapToReadDto(product));
    }

    [HttpPost]
    public async Task<ActionResult<ProductReadDto>> CreateProduct([FromForm] ProductCreateDto dto)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var product = new Product
        {
            Name = dto.Name,
            Category = dto.Category,
            Price = dto.Price,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow
        };
        if (dto.Image != null)
        {
            var imageUrl = await _storage.UploadFileAsync(dto.Image);
            product.ImageUrl = imageUrl;
        }

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, MapToReadDto(product));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ProductReadDto>> UpdateProduct(int id, [FromForm] ProductUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var product = await _context.Products.FindAsync(id);
        if (product == null)
            return NotFound("Product not found");

        product.Name = dto.Name;
        product.Category = dto.Category;
        product.Price = dto.Price;
        product.Description = dto.Description;
        if (dto.Image != null)
        {
            if (!string.IsNullOrEmpty(product.ImageUrl))
                await _storage.DeleteFileByUrlAsync(product.ImageUrl);
            
            var imageUrl = await _storage.UploadFileAsync(dto.Image);
            product.ImageUrl = imageUrl;
        }

        await _context.SaveChangesAsync();
        return Ok(MapToReadDto(product));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
            return NotFound("Product not found");

        if (!string.IsNullOrEmpty(product.ImageUrl))
            await _storage.DeleteFileByUrlAsync(product.ImageUrl);

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }

    private static ProductReadDto MapToReadDto(Product p)
    {
        return new ProductReadDto
        {
            Id = p.Id,
            Name = p.Name,
            Category = p.Category,
            Price = p.Price,
            Description = p.Description,
            ImageUrl = p.ImageUrl,
            CreatedAt = p.CreatedAt
        };
    }
}
