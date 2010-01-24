using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InvestmentStrategies;

namespace InvestmentStrategiesTests
{
    /// <summary>
    /// Summary description for Indicators_Test
    /// </summary>
    [TestClass]
    public class Indicators_Test
    {
        private static readonly string pathToTestData = "../../../InvestmentStrategiesTests/data-test/data-test.txt";
        private static readonly double delta = 0.001;
        private Indicators indicators;
        private RSI rsii;
        private int daysCount;

        public Indicators_Test()
        {
            this.daysCount = 30;
            this.indicators = new InvestmentStrategies.Indicators();
            this.indicators.readData(pathToTestData);
            this.rsii = new RSI(indicators, daysCount);
        }


        [TestMethod]
        public void Indicators_sumArray()
        {
            double[] data = new double[] {1,0,3,0,0,3,2,1};
            Assert.AreEqual(AbstractIndicator.sumArray(data, 0, 1), 1);
            Assert.AreEqual(AbstractIndicator.sumArray(data, 0, 7), 10);
            Assert.AreNotEqual(AbstractIndicator.sumArray(data, 0, 5), 11);
        }

        [TestMethod]
        public void Indicators_meanAbsoluteDeviation()
        {
            double[] data = new double[] { 2, 2, 1, 1, 1, 1, 2, 1 };
            Assert.AreEqual(AbstractIndicator.meanAbsoluteDeviation(data, 4, 5, 2.0), 1);
            Assert.AreEqual(AbstractIndicator.meanAbsoluteDeviation(data, 2, 2, 1.5), 0.5);
            Assert.AreNotEqual(AbstractIndicator.meanAbsoluteDeviation(data, 5, 5, 2.0), 1);
        }
    }
}
