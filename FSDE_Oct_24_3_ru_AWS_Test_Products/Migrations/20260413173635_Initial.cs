using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FSDE_Oct_24_3_ru_AWS_Test_Products.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Electronics", new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Latest Apple smartphone with A17 Pro chip", null, "iPhone 15 Pro", 1299.99m },
                    { 2, "Electronics", new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Flagship Android smartphone by Samsung", null, "Samsung Galaxy S24", 1099.50m },
                    { 3, "Computers", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Powerful laptop for developers and designers", null, "Dell XPS 15", 1899.99m },
                    { 4, "Accessories", new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Premium wireless productivity mouse", null, "Logitech MX Master 3S", 99.99m },
                    { 5, "Accessories", new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc), "RGB mechanical keyboard for gaming and work", null, "Mechanical Keyboard K8", 120.00m },
                    { 6, "Audio", new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Noise cancelling premium headphones", null, "Sony WH-1000XM5", 399.99m },
                    { 7, "Wearables", new DateTime(2024, 4, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Smartwatch with health tracking features", null, "Apple Watch Series 9", 499.00m },
                    { 8, "Cameras", new DateTime(2024, 3, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Action camera for adventures and blogging", null, "GoPro Hero 12", 450.75m },
                    { 9, "Gaming", new DateTime(2024, 2, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Next-gen gaming console by Sony", null, "PlayStation 5", 699.99m },
                    { 10, "Books", new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Portable e-book reader with backlight", null, "Amazon Kindle Paperwhite", 159.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
