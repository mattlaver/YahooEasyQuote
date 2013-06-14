using System;
using YahooEasyQuote;

namespace SimpleExample
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine("Get a single quote");
			YahooQuote yahooEasyQuote = new YahooQuote();
			var stockQuote = yahooEasyQuote.GetQuote("BT-A.L");
			Console.WriteLine("{0} {1}", stockQuote.Symbol, stockQuote.LastTrade);

			Console.WriteLine("Get multiple quotes");
			string[] stocks = new string[3] {"4228.L", "AAL.L", "ABF.L"};
			var stockQuotes = yahooEasyQuote.GetQuotes(stocks);
			foreach (StockQuote stock in stockQuotes)
			{
				Console.WriteLine("{0} {1}", stock.Symbol, stock.LastTrade);
			}

			Console.ReadLine ();
		}
	}
}
