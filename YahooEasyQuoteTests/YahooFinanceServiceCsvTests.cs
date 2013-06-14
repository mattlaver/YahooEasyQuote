// --------------------------------------------------------------------------------------------------------------------
// <copyright file="YahooFinanceServiceCsvTests.cs" company="http://tufnelltech.blogspot.co.uk/">
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
namespace YahooEasyQuoteTests
{
    using System;
    using Moq;
    using NUnit.Framework;
    using YahooEasyQuote;

    /// <summary>
    /// Yahoo finance service csv tests.
    /// </summary>
    [TestFixture]
    public class YahooFinanceServiceCsvTests
    {    
        /// <summary>
        /// The StockQuote produced from the mock
        /// </summary>
		private StockQuote _stockQuoteMock;

        [TestFixtureSetUp] 
        public void TestFixtureSetUp() 
        {
            var mock = new Mock<IHttpWebService>();
            string mockResponse	= "312.50,312.30,312.40,\"BT-A.L\"\r\n";
            mock.Setup(f => f.GetHttpRequest(It.IsAny<string>())).Returns(mockResponse);
            var yahooFinanceServiceMock = new YahooFinanceServiceCsv(mock.Object); 
            this._stockQuoteMock = yahooFinanceServiceMock.GetQuote("BT-A.L");
        }

        [Test]
        public void Test_Ask()
        { 
            Assert.AreEqual(312.50, this._stockQuoteMock.Ask);
        }

        [Test]
        public void Test_Bid()
        { 
            Assert.AreEqual(312.30, this._stockQuoteMock.Bid);       
        }

		[Test]
		public void Test_LastTrade()
		{ 
			Assert.AreEqual(312.40, this._stockQuoteMock.LastTrade);       
		}

        [Test]
        public void Test_Symbol()
        { 
            Assert.AreEqual("\"BT-A.L\"", this._stockQuoteMock.Symbol);
        }
    }
}