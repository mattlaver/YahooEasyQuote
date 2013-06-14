YahooEasyQuote
==============

Get a single quote:

  YahooQuote yahooEasyQuote = new YahooQuote();
  StockQuote stockQuote = yahooEasyQuote.GetQuote("BT-A.L");
	Console.WriteLine("{0} {1}", stockQuote.Symbol, stockQuote.LastTrade);

Get multiple quotes:

  string[] stocks = new string[3] {"4228.L", "AAL.L", "ABF.L"};
  StockQuote stockQuotes = yahooEasyQuote.GetQuotes(stocks);
	foreach (StockQuote stock in stockQuotes)
	{
	    Console.WriteLine("{0} {1}", stock.Symbol, stock.LastTrade);
	}
