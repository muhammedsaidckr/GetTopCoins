using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using GetTopCoins.Models;

namespace GetTopCoins.Excel
{
    public class TopCoinsWorkbook : ITopCoinsWorkbook
    {
        private readonly XLWorkbook _workbook;
        private IXLWorksheet _worksheet;
        private int _currentRow = 1;
        private int _column = 1;

        private List<string> _headerValues = new List<string>()
            { "Symbol", "Inital Price", "Final Price", "Change Rate" };

        public TopCoinsWorkbook(XLWorkbook workbook, IXLWorksheet worksheet, string? worksheetName = "Top Coins")
        {
            _workbook = workbook;
            _worksheet = worksheet;
        }

        public XLWorkbook CreateWorkbookWithData(List<Symbol> data)
        {
            // Create new worksheet
            CreateWorksheet("Top Coins", data);

            return _workbook;
        }

        private void CreateWorksheet(string name, List<Symbol> data)
        {
            PrintXlHeaderValues();

            foreach (var symbol in data)
            {
                var xlRowData = CreateXlRowData(symbol);
                PrintBodyValues(xlRowData);
            }
        }

        private void PrintXlHeaderValues()
        {
            foreach (var headerValue in _headerValues)
            {
                _worksheet.Cell(_currentRow, _column++).Value = headerValue;
            }

            _currentRow++;
        }

        private void PrintBodyValues(XLRowData row)
        {
            _column = 1;

            _worksheet.Cell(_currentRow, _column++).Value = row.symbol;
            _worksheet.Cell(_currentRow, _column++).Value = row.initialPrice;
            _worksheet.Cell(_currentRow, _column++).Value = row.finalPrice;
            _worksheet.Cell(_currentRow++, _column++).Value = row.changeRate;
        }

        private static XLRowData CreateXlRowData(Symbol symbol)
        {
            return new XLRowData()
            {
                symbol = symbol.symbol,
                initialPrice = symbol.priceSevenDaysAgo,
                finalPrice = symbol.currentPrice,
                changeRate = $"{Math.Round((symbol.change * 100), 2)}%"
            };
        }
    }
}
