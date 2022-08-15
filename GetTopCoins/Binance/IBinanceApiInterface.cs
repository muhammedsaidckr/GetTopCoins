using Binance.Net.Interfaces;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binance.Net.Objects.Models.Spot;
using GetTopCoins.Models;

namespace GetTopCoins.Binance
{
    public interface IBinanceApi
    {
        Task<decimal> GetHistoricalPriceAsync(string symbol);

        Task<decimal> GetLastPriceAsync(string symbol);

        Task<Symbol> CalculateChange(string symbol);
    }
}
