using ClosedXML.Excel;
using StockComparer.Models;

namespace CsvExcelComparer;

public static class ExcelParser
{
    public static List<Item> Read(string path)
    {
        using var workbook = new XLWorkbook(path);
        var worksheet = workbook.Worksheet(1);
        var header = worksheet.Row(1).Cells().ToDictionary(c => c.GetValue<string>(), c => c.Address.ColumnNumber);
        var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Skip header

        return rows.Select(row => new Item
        {
            Id = row.Cell(header["Id"]).GetValue<string>(),
            Price = row.Cell(header["Price"]).GetValue<double>(),
            Stock = row.Cell(header["Stock"]).GetValue<double>()
        }).ToList();
    }
}