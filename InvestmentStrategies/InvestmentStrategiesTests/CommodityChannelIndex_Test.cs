using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InvestmentStrategies;

namespace InvestmentStrategiesTests
{
    /// <summary>
    /// Summary description for CommodityChannelIndex_Test
    /// </summary>
    [TestClass]
    public class CommodityChannelIndex_Test
    {
        private static readonly string pathToTestData = "../../../InvestmentStrategiesTests/data-test/testDataCCI.txt";
        private static readonly double delta = 0.001;
        private Indicators indicators;
        private CommodityChannelIndex CCI;
        private int daysCount;

        public CommodityChannelIndex_Test()
        {
            this.daysCount = 30;
            this.indicators = new InvestmentStrategies.Indicators();
            this.indicators.readData(pathToTestData);
            this.CCI = new CommodityChannelIndex(indicators, daysCount);
        }

        [TestMethod]
        public void CommodityChannelIndex_General()
        {
            Assert.AreEqual(2.0, CCI.typicalPrice[29]);
            Console.WriteLine(CCI.typicalPrice[30]);
            //Console.WriteLine(CCI.indicators.stockData[30]["high"]);
            //Console.WriteLine(CCI.indicators.stockData[30]["low"]);
            //Console.WriteLine(CCI.indicators.stockData[30]["close"]);
            Assert.AreEqual(3.0, CCI.typicalPrice[30]);
            Assert.AreEqual(1.5, CCI.SMATP[29], "value");
            Assert.AreEqual(0.5, CCI.meanAbsoluteDeviationData[29]);
        }
    }
}
