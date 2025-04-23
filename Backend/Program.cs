var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:5105")  // allow any origin (for development purposes only- suggested by GitHub Copilot)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Configure JSON serialization to use PascalCase globally (Suggested by GitHub Copilot)
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null; // Use PascalCase
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Addsingleton<ProductService>(); // Register ProductService as a singleton (Suggested by GitHub Copilot)

var app = builder.Build();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors();

app.MapControllers();

app.MapGet("/api/products", () =>
{
    productService.GetProducts(); // Use the ProductService to get products (Suggested by GitHub Copilot)
});

app.Run();