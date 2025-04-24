using StockComparer.Models;

namespace StockComparer;

public static class Comparer
{
    public static List<Item> FindDifferences(List<Item> csvItems, List<Item> excelItems)
    {
        return csvItems.Where(csvItem =>
            !excelItems.Any(excelItem =>
                excelItem.Id == csvItem.Id &&
                excelItem.Price == csvItem.Price &&
                excelItem.Stock == csvItem.Stock)).ToList();
    }
}