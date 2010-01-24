using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InvestmentStrategies;

namespace InvestmentStrategiesTests
{
    /// <summary>
    /// Summary description for StochasticOscillator_Test
    /// </summary>
    [TestClass]
    public class StochasticOscillator_Test
    {
        private static readonly string pathToTestData = "../../../InvestmentStrategiesTests/data-test/data-test.txt";
        private static readonly double delta = 0.001;
        private InvestmentStrategies.Indicators indicators;
        private StochasticOscillator SO;
        private int period;
        private int movingAveragePeriod;

        public StochasticOscillator_Test()
        {
            this.period = 30;
            this.movingAveragePeriod = 3;
            this.indicators = new InvestmentStrategies.Indicators();
            this.indicators.readData(pathToTestData);
            this.SO = new StochasticOscillator(indicators, period, movingAveragePeriod);
        }

        [TestMethod]
        public void StochasticOscillator_Test_General()
        {
            Assert.AreEqual(100 * (2.0 - 1.0) / (3.0 - 1.0),
                            SO.data[29]);

            Assert.AreEqual((SO.data[29] + SO.data[30] + SO.data[31]) / 3,
                            SO.averageData[31]);

            SO.printData();
        }
    }
}
