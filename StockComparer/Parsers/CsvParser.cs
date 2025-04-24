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
            items.Add(new Item
            {
                Id = csv.GetField("Id"),
                Price = csv.GetField<double>("Price"),
                Stock = csv.GetField<double>("Stock")
            });
        }

        return items;
    }
}