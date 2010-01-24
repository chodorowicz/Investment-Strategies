using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InvestmentStrategies;


namespace InvestmentStrategiesTests.Indicators.lib
{
    /// <summary>
    /// Summary description for SMA_Test
    /// </summary>
    [TestClass]
    public class SMA_Test
    {
        private static readonly string pathToTestData = "../../../InvestmentStrategiesTests/data-test/EMA.txt";
        private static readonly double delta = 0.001;
        private InvestmentStrategies.Indicators indicators;

        public SMA_Test()
        {
            indicators = new InvestmentStrategies.Indicators();
            this.indicators.readData(pathToTestData);
        }


        [TestMethod]
        public void SMA_Test_General()
        {
            double[] sMA = SMA.calculate(indicators.stockData, 10);
            Assert.AreEqual(59.439, sMA[9], delta);
            Assert.AreEqual(59.121, sMA[10], delta);
        }
    }
}
