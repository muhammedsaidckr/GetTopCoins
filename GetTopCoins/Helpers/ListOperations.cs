using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetTopCoins.Binance;
using GetTopCoins.Models;

namespace GetTopCoins.Helpers
{
    public static class ListOperations
    {
        public static List<Symbol> changeList;

        public static async Task<List<Symbol>> GetSymbolChangeList(List<string> symbols)
        {
            var change = new Symbol();
            var binanceApi = new BinanceApi();
            var changeList = new List<Symbol>();
            foreach (var symbol in symbols)
            {
                change = await binanceApi.CalculateChange(symbol);
                changeList.Add(change);
            }

            return GetSortedChangeList(changeList);
        }

        public static List<Symbol> GetSortedChangeList(List<Symbol> symbols)
        {
            return symbols.OrderBy(s => s.change).ToList();
        }
    }
}
