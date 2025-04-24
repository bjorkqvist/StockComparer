using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using StockComparer;
using StockComparer.Parsers;

namespace CsvExcelComparer
{
    class Program
    {
        static void Main(string[] args)
        {
            var csvPath = "data.csv";
            var excelPath = "data.xlsx";

            var csvItems = CsvParser.Read(csvPath);
            var excelItems = ExcelParser.Read(excelPath);

            var differences = Comparer.FindDifferences(csvItems, excelItems);

            Console.WriteLine("Items found in CSV but not in Excel:");
            foreach (var item in differences)
            {
                Console.WriteLine($"{item.Id}, {item.Price}, {item.Stock}");
            }
        }
    }
}
