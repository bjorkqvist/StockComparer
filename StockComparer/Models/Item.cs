namespace StockComparer.Models;

public record Item
{
    public string Id { get; set; }
    public double Price { get; set; }
    public double Stock { get; set; }
}