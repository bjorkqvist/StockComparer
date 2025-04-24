using System.Globalization;
using ClosedXML.Excel;
using StockComparer.Models;

namespace StockComparer.Parsers;

public static class ExcelParser
{
    public static List<Item> Read(string path)
    {
        using var workbook = new XLWorkbook(path);
        var worksheet = workbook.Worksheet(1);
        var header = worksheet.Row(1).Cells().ToDictionary(
            c => c.GetValue<string>()?.Trim() ?? string.Empty,
            c => c.Address.ColumnNumber
        );
        var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Skip header

        return rows.Select(row =>
        {
            string id = row.Cell(header["Kod"]).GetValue<string>();

            string priceStr = row.Cell(header["Enh.pris (moms)"]).GetString();
            string stockStr = row.Cell(header["Totalt lager"]).GetString();

            double price = double.TryParse(priceStr, NumberStyles.Any, CultureInfo.InvariantCulture, out var p) ? p : -1;
            double stock = double.TryParse(stockStr, NumberStyles.Any, CultureInfo.InvariantCulture, out var s) ? s : -1;

            return new Item
            {
                Id = id,
                Price = price,
                Stock = stock
            };
        })
        .Where(item => item.Id != "0") // discard items with ID "0"
        .ToList();
    }
}