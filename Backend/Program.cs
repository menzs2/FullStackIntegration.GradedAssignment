var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin() // Replace with your frontend URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Configure JSON serialization to use PascalCase globally
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null; // Use PascalCase
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseCors();

app.MapControllers();

app.MapGet("/api/products", () =>
{
    return new Product[]
    {
        new() { Id = 1, Name = "Laptop", Price = 1200.50, Stock = 25 ,Category = new Category { Id = 1, Name = "Electronics" } },
            new() { Id = 2, Name = "Headphones", Price = 50.00, Stock = 100, Category = new Category{ Id = 102, Name = "Accessories" } },
    };
});

app.Run();

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }

    public Category Category { get; set; }
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
}