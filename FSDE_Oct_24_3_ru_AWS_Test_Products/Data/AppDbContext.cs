using FSDE_Oct_24_3_ru_AWS_Test_Products.Models;
using Microsoft.EntityFrameworkCore;

namespace FSDE_Oct_24_3_ru_AWS_Test_Products.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) 
        : base(options)
    {}
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(
            entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Price).HasColumnType("decimal(10, 2)");
            });
        modelBuilder.Entity<Product>()
            .Property(p=> p.IsDiscountActive).HasDefaultValue(false);

        modelBuilder.Entity<Product>()
            .HasIndex(p => new { p.IsDiscountActive , p.DiscountStart, p.DiscountEnd})
            .HasDatabaseName("Products_IsDiscount_DiscountStart_DiscountEnd");
        modelBuilder.Entity<Product>().HasData(

    new Product
    {
        Id = 1,
        Name = "iPhone 15 Pro",
        Category = "Electronics",
        Description = "Latest Apple smartphone with A17 Pro chip",
        Price = 1299.99m,
        ImageUrl = null,
        CreatedAt = new DateTime(2024, 10, 10, 0, 0, 0, DateTimeKind.Utc)
    },

    new Product
    {
        Id = 2,
        Name = "Samsung Galaxy S24",
        Category = "Electronics",
        Description = "Flagship Android smartphone by Samsung",
        Price = 1099.50m,
        ImageUrl = null,
        CreatedAt = new DateTime(2024, 9, 5, 0, 0, 0, DateTimeKind.Utc)
    },

    new Product
    {
        Id = 3,
        Name = "Dell XPS 15",
        Category = "Computers",
        Description = "Powerful laptop for developers and designers",
        Price = 1899.99m,
        ImageUrl = null,
        CreatedAt = new DateTime(2024, 8, 15, 0, 0, 0, DateTimeKind.Utc)
    },

    new Product
    {
        Id = 4,
        Name = "Logitech MX Master 3S",
        Category = "Accessories",
        Description = "Premium wireless productivity mouse",
        Price = 99.99m,
        ImageUrl = null,
        CreatedAt = new DateTime(2024, 7, 20, 0, 0, 0, DateTimeKind.Utc)
    },

    new Product
    {
        Id = 5,
        Name = "Mechanical Keyboard K8",
        Category = "Accessories",
        Description = "RGB mechanical keyboard for gaming and work",
        Price = 120.00m,
        ImageUrl = null,
        CreatedAt = new DateTime(2024, 6, 10, 0, 0, 0, DateTimeKind.Utc)
    },

    new Product
    {
        Id = 6,
        Name = "Sony WH-1000XM5",
        Category = "Audio",
        Description = "Noise cancelling premium headphones",
        Price = 399.99m,
        ImageUrl = null,
        CreatedAt = new DateTime(2024, 5, 12, 0, 0, 0, DateTimeKind.Utc)
    },

    new Product
    {
        Id = 7,
        Name = "Apple Watch Series 9",
        Category = "Wearables",
        Description = "Smartwatch with health tracking features",
        Price = 499.00m,
        ImageUrl = null,
        CreatedAt = new DateTime(2024, 4, 18, 0, 0, 0, DateTimeKind.Utc)
    },

    new Product
    {
        Id = 8,
        Name = "GoPro Hero 12",
        Category = "Cameras",
        Description = "Action camera for adventures and blogging",
        Price = 450.75m,
        ImageUrl = null,
        CreatedAt = new DateTime(2024, 3, 11, 0, 0, 0, DateTimeKind.Utc)
    },

    new Product
    {
        Id = 9,
        Name = "PlayStation 5",
        Category = "Gaming",
        Description = "Next-gen gaming console by Sony",
        Price = 699.99m,
        ImageUrl = null,
        CreatedAt = new DateTime(2024, 2, 22, 0, 0, 0, DateTimeKind.Utc)
    },

    new Product
    {
        Id = 10,
        Name = "Amazon Kindle Paperwhite",
        Category = "Books",
        Description = "Portable e-book reader with backlight",
        Price = 159.99m,
        ImageUrl = null,
        CreatedAt = new DateTime(2024, 1, 30, 0, 0, 0, DateTimeKind.Utc)
    }

);
    }
}
