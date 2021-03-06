// --------------------------------------------------------------------------------------------------------------------
// <copyright file="YahooEasyQuote.cs" company="http://tufnelltech.blogspot.co.uk/">
//   Copyright (c) 2013 Matt Laver
// </copyright>
// <license>
//   The MIT License (MIT)
//
//   Permission is hereby granted, free of charge, to any person obtaining a copy
//   of this software and associated documentation files (the "Software"), to deal
//   in the Software without restriction, including without limitation the rights
//   to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//   copies of the Software, and to permit persons to whom the Software is
//   furnished to do so, subject to the following conditions:
//
//   The above copyright notice and this permission notice shall be included in
//   all copies or substantial portions of the Software.
//
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//   FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//   AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//   LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//   OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//   THE SOFTWARE.
// </license>
// --------------------------------------------------------------------------------------------------------------------
namespace YahooEasyQuote
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Yahoo easy quote library
    /// </summary>
    public class YahooQuote
    {
        /// <summary>
        /// The _yahoo finance.
        /// </summary>
        private IYahooFinanceService _yahooFinanceService;

        /// <summary>
        /// Initializes a new instance of the <see cref="YahooEasyQuote.YahooEasyQuote"/> class.
        /// </summary>
        public YahooQuote()
        {
            this._yahooFinanceService = new YahooFinanceServiceCsv(new HttpWebService());
        }

        /// <summary>
        /// Gets the quote.
        /// </summary>
        /// <returns>The quote.</returns>
        /// <param name="symbol">Symbol string</param>
        public StockQuote GetQuote(string symbol)
        {
            return this._yahooFinanceService.GetQuote(symbol);
        }

        /// <summary>
        /// Gets the quotes.
        /// </summary>
        /// <returns>The quotes.</returns>
        /// <param name="symbols">Symbols array</param>
        public IEnumerable<StockQuote> GetQuotes(string[] symbols)
        {
            return this._yahooFinanceService.GetQuotes(symbols);
        }		                                       
    }
}