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
            Console.WriteLine("Welcome to the CSV and Excel comparer version [0.1]!");
            var csvPath = "data.csv";
            var excelPath = "data.xlsx";

            var csvItems = CsvParser.Read(csvPath);
            var excelItems = ExcelParser.Read(excelPath);

            Comparer.Compare(csvItems, excelItems);
        }
    }
}
