// Copyright (c) 2013 Matt Laver
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
namespace YahooEasyQuote
{
	using System.Collections.Generic;

	/// <summary>
	/// Yahoo finance implementation
	/// </summary>
	internal class YahooFinance : IStockRepository
    {
        IYahooService _yahooService;

        public YahooFinance(IYahooService yahooService)
        {
           _yahooService = yahooService;
        }

		/// <summary>
		/// Gets a single stock quote.
		/// </summary>
		/// <returns>The quote.</returns>
		/// <param name="symbol">Symbol.</param>
		public StockQuote GetQuote(string symbol)
		{
			return _yahooService.GetRequest(symbol);
		}

		/// <summary>
		/// Gets the quotes.
		/// </summary>
		/// <returns>The quotes.</returns>
		/// <param name="symbols">Symbols.</param>
		public IEnumerable<StockQuote> GetQuotes(string[] symbols)
		{
			return _yahooService.GetRequests(symbols);
		}
    }
}