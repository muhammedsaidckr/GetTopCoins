using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binance.Net.Clients;
using Binance.Net.Enums;
using Binance.Net.Interfaces;
using Binance.Net.Objects;
using Binance.Net.Objects.Models.Spot;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using GetTopCoins.Helpers;
using GetTopCoins.Models;

namespace GetTopCoins.Binance
{
    public class BinanceApi : IBinanceApi
    {
        private readonly BinanceClient _binanceClient;
        public BinanceApi()
        {
            _binanceClient = new BinanceClient(new BinanceClientOptions()
            {
                ApiCredentials = new ApiCredentials(BinanceSettings.apiKey, BinanceSettings.secretKey),
            });
        }

        public async Task<decimal> GetHistoricalPriceAsync(string symbol)
        {
            var lowPrice = 0.0M;
            try
            {
                var klines = await _binanceClient.SpotApi.ExchangeData.GetKlinesAsync(symbol, KlineInterval.OneDay,
                    DateTime.UtcNow.AddDays(-7), DateTime.UtcNow.AddDays(-6));
                if (klines.Success)
                {
                    lowPrice = klines.Data.ToList().First()!.LowPrice;
                }
            }
            catch
            {
                lowPrice = 0;
            }

            return lowPrice;

        }

        public async Task<decimal> GetCurrentAveragePriceAsync(string symbol)
        {
            try
            {
                var avgPrices = await _binanceClient.SpotApi.ExchangeData.GetCurrentAvgPriceAsync(symbol);

                return avgPrices.Success ? avgPrices.Data.Price : 0.0M;
            }
            catch
            {
                return 0.0M; // TODO: Handle exception
            }
        }

        public async Task<Symbol> CalculateChange(string symbol)
        {
            var change = 0.0M;
            var priceSevenDaysAgo = await GetHistoricalPriceAsync(symbol);
            var currentPrice = await GetCurrentAveragePriceAsync(symbol);
            if (priceSevenDaysAgo > 0 && currentPrice > 0)
            {
                change = (currentPrice - priceSevenDaysAgo) / priceSevenDaysAgo;
            }
                
            return new Symbol()
            {
                symbol = symbol,
                priceSevenDaysAgo = priceSevenDaysAgo,
                currentPrice = currentPrice,
                change = change,
            };
        }
    }
}
