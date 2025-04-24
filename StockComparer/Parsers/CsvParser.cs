using System.Globalization;
using CsvHelper;
using StockComparer.Models;

namespace StockComparer.Parsers;

public static class CsvParser
{
    public static List<Item> Read(string path)
    {
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var items = new List<Item>();
        csv.Read();
        csv.ReadHeader();

        while (csv.Read())
        {
            var id = csv.GetField("variants - Sku");

            var priceStr = csv.GetField("variants - Price");
            var stockStr = csv.GetField("variants - StockQuantity");

            double price = double.TryParse(priceStr, NumberStyles.Any, CultureInfo.InvariantCulture, out var p) ? p : -1;
            double stock = double.TryParse(stockStr, NumberStyles.Any, CultureInfo.InvariantCulture, out var s) ? s : -1;

            items.Add(new Item
            {
                Id = id,
                Price = price,
                Stock = stock
            });
        }

        return items;
    }
}