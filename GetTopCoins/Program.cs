using ClosedXML.Excel;
using GetTopCoins.Data;
using GetTopCoins.Excel;
using GetTopCoins.Helpers;

var symbolList = await ListOperations.GetSymbolChangeList(Symbols.symbols);

var workbook = new XLWorkbook();
var worksheet = workbook.Worksheets.Add("Top Coins");

var xlWorkbook = new TopCoinsWorkbook(workbook, worksheet);

workbook = xlWorkbook.CreateWorkbookWithData(symbolList);
Console.WriteLine("Saving topcoins");
workbook.SaveAs("topcoins.xlsx");
Console.WriteLine("Saved");
Console.ReadLine();