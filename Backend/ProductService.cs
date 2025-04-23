public class ProductService
{
    public IEnumerable<Product> GetProducts()
    {
    return new Product[]
    {
        new() { Id = 1, Name = "Laptop", Price = 1200.50, Stock = 25 ,Category = new Category { Id = 1, Name = "Electronics" } },
        new() { Id = 2, Name = "Headphones", Price = 50.00, Stock = 100, Category = new Category{ Id = 102, Name = "Accessories" } },
    };
    }
}

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