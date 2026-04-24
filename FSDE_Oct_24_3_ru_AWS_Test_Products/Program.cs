using Amazon.Runtime;
using Amazon.S3;
using FSDE_Oct_24_3_ru_AWS_Test_Products.Data;
using FSDE_Oct_24_3_ru_AWS_Test_Products.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(
    options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStorageService, S3StorageService>();

builder.Services.AddSingleton<IAmazonS3>(
    _ =>
    {
        var awsSection = builder.Configuration.GetSection("AWS");

        var settings = awsSection.Get<AwsSettings>();

        var region = Amazon.RegionEndpoint.GetBySystemName(settings!.Region);

        if(!string.IsNullOrWhiteSpace(settings.AccessKey) && !string.IsNullOrWhiteSpace(settings.SecretKey))
        {
            var credentials = new BasicAWSCredentials(settings.AccessKey, settings.SecretKey);
            return new AmazonS3Client(credentials, region);
        }
        return new AmazonS3Client(region);
    }
    );

builder.Services.AddCors(
    options =>
{
    options.AddPolicy("ReactApp", policy =>
    {
        policy.WithOrigins("http://mogudaproducts.s3-website.eu-north-1.amazonaws.com", "http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ReactApp");


app.UseAuthorization();

app.MapControllers();


app.Run();
