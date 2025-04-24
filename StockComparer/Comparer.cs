using StockComparer.Models;

namespace StockComparer;

public static class Comparer
{
    public static void Compare(List<Item> csvItems, List<Item> excelItems, double priceTolerance = 0.01)
    {
        var excelMap = excelItems.ToDictionary(x => x.Id, x => x);

        // 1. IDs in CSV but not in Excel
        var onlyInCsv = csvItems.Where(c => !excelMap.ContainsKey(c.Id)).Select(c => c.Id).ToList();
        Console.WriteLine("1. IDs in CSV but not in Excel:");
        foreach (var id in onlyInCsv)
        {
            Console.WriteLine(id);
        }
        //
        // // 2. Price difference
        // Console.WriteLine("\n2. Price differences:");
        // foreach (var csvItem in csvItems)
        // {
        //     if (excelMap.TryGetValue(csvItem.Id, out var excelItem))
        //     {
        //         if (Math.Abs(csvItem.Price - excelItem.Price) > priceTolerance)
        //         {
        //             Console.WriteLine($"{csvItem.Id}: CSV Price = {csvItem.Price}, Excel Price = {excelItem.Price}");
        //         }
        //     }
        // }
        //
        // // 3. Stock difference
        // Console.WriteLine("\n3. Stock differences:");
        // foreach (var csvItem in csvItems)
        // {
        //     if (excelMap.TryGetValue(csvItem.Id, out var excelItem))
        //     {
        //         if (csvItem.Stock != excelItem.Stock)
        //         {
        //             Console.WriteLine($"{csvItem.Id}: CSV Stock = {csvItem.Stock}, Excel Stock = {excelItem.Stock}");
        //         }
        //     }
        // }
    }
}