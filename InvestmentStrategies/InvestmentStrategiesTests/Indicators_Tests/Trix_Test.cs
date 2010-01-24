using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InvestmentStrategies;

namespace InvestmentStrategiesTests.Indicators_Tests
{
    /// <summary>
    /// Summary description for Trix_Test
    /// </summary>
    [TestClass]
    public class Trix_Test
    {
        private static readonly string pathToTestData = "../../../InvestmentStrategiesTests/data-test/EMA.txt";
        private static readonly double delta = 0.001;
        private InvestmentStrategies.Indicators indicators;

        public Trix_Test()
        {
            indicators = new InvestmentStrategies.Indicators();
            this.indicators.readData(pathToTestData);
        }



        [TestMethod]
        public void Trix_Test_General()
        {
            double ema_prev = 59.439;
            double value1 = ((indicators.stockData[10]["close"] - ema_prev) * 0.181818) + ema_prev;
            TRIX trix = new TRIX(indicators, 10);
            Assert.AreEqual(value1, trix.data[10], delta);

            //Console.WriteLine("---- {0} --- {1}", trix.data[10], value1);
            //trix.printData();
        }
    }
}
