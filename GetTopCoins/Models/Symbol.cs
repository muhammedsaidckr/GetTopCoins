using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTopCoins.Models
{
    public class Symbol
    {
        public string symbol { get; set; }

        public decimal priceSevenDaysAgo { get; set; }
        public decimal currentPrice { get; set; }
        public decimal change { get; set;  }
    }
}
