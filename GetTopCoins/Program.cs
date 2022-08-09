// See https://aka.ms/new-console-template for more information

using GetTopCoins.Helpers;

var symbols = new List<string>() {
    "1INCHBTC", "1INCHUSDT", "AAVEBTC"
};

var symbolList = await ListOperations.GetSymbolChangeList(symbols);

foreach (var symbol in symbolList)
{
    Console.WriteLine($"{symbol.symbol} - {symbol.priceSevenDaysAgo} - {symbol.currentPrice} - {Math.Round((symbol.change * 100), 2)}%");
}

Console.ReadLine();