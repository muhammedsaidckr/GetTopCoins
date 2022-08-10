using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTopCoins.Models
{
    public class XLRowData
    {
        public string symbol { get; set; }
        public decimal initialPrice { get; set; }
        public decimal finalPrice { get; set; }
        public string changeRate { get; set; }
    }
}
