using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InvestmentStrategies;


namespace InvestmentStrategiesTests
{
    /// <summary>
    /// Summary description for EMA_Test
    /// </summary>
    [TestClass]
    public class EMA_Test
    {
        private static readonly string pathToTestData = "../../../InvestmentStrategiesTests/data-test/EMA.txt";
        private static readonly double delta = 0.001;
        private Indicators indicators;

        public EMA_Test()
        {
            indicators = new Indicators();
            this.indicators.readData(pathToTestData);

        }

        [TestMethod]
        public void EMA_Test_General()
        {
            double[] SMA = new double[]{0,1,2,3,4,5,6,7,8,59.439};
            Assert.AreEqual(59.439, SMA[9]);
            Console.WriteLine(SMA[9]);
            double[] ema = EMA.calculate(indicators.stockData,SMA, 10);
            Assert.AreEqual(59.023, ema[10], delta);

        }
    }
}
