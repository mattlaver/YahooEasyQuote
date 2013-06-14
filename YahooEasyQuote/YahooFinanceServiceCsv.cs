// --------------------------------------------------------------------------------------------------------------------
// <copyright file="YahooFinanceServiceCsv.cs" company="http://tufnelltech.blogspot.co.uk/">
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
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    
    /// <summary>
    /// Yahoo service csv.
    /// </summary>
    public class YahooFinanceServiceCsv : YahooFinanceServiceBase
    {
        /// <summary>
        /// The _options.
        /// </summary>
        private const string _options = "abl1s";

        /// <summary>
        /// Initializes a new instance of the <see cref="YahooEasyQuote.YahooFinanceServiceCsv"/> class.
        /// </summary>
        /// <param name="httpWebService">Http web service.</param>
        public YahooFinanceServiceCsv(IHttpWebService httpWebService) : base(httpWebService)
        {
        }

        /// <summary>
        /// Gets the request.
        /// </summary>
        /// <returns>The request.</returns>
        /// <param name="symbol">Symbol string</param>
        public override StockQuote GetQuote(string symbol)
        {
           return this.GetQuotes(symbol).FirstOrDefault();
        }

        /// <summary> 
        /// Gets a collection of stock quotes.
        /// </summary>
        /// <returns>The request.</returns>
        /// <param name="symbols">Symbols array</param>
        public override IEnumerable<StockQuote> GetQuotes(string[] symbols)
        {
            string symbolString = string.Join("+", symbols.Select(x => x.ToString()).ToArray());
            return this.GetQuotes(symbolString);
        }

        /// <summary>
        /// Maps the CSV to stock quotes.
        /// </summary>
        /// <returns>The CSV to stock quotes.</returns>
        /// <param name="csvQuotes">Csv quotes.</param>
        private IEnumerable<StockQuote> MapCSVToStockQuotes(string[] csvQuotes)
        {
            return csvQuotes
                .Select(x => x.Split(','))
                .Select(x => new StockQuote
                    {
                        Ask = double.Parse(x[0]),
                        Bid = double.Parse(x[1]),
						LastTrade = double.Parse(x[2]),
                        Symbol = Regex.Replace(x[3], @"\r\n?|\n", string.Empty)
                    });
        }

        /// <summary>
        /// Gets the http request.
        /// </summary>
        /// <returns>The http request.</returns>
        /// <param name="request">Request string</param>
        private string[] GetHttpRequestCSV(string request)
        {
            string response = GetHttpRequest(request);
            return response.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Gets the quotes.
        /// </summary>
        /// <returns>The quotes.</returns>
        /// <param name="symbols">Symbols string</param>
        private IEnumerable<StockQuote> GetQuotes(string symbols)
        {
            string request = string.Format("http://finance.yahoo.com/d/quotes.csv?s={0}&f={1}", symbols, _options);
            string[] response = this.GetHttpRequestCSV(request);
            return this.MapCSVToStockQuotes(response);
        }     
    }
}