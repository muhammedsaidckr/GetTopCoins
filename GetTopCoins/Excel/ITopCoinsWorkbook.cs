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
    public interface ITopCoinsWorkbook
    {
        XLWorkbook CreateWorkbookWithData(List<Symbol> data);
    }
}
