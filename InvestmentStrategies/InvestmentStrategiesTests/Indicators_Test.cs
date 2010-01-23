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
        public void Indicators_General()
        {
      
        }
    }
}
