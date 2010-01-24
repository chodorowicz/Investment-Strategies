using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InvestmentStrategies;

namespace InvestmentStrategiesTests
{
    [TestClass]
    public class RSI_Test
    {
        private static readonly string pathToTestData = "../../../InvestmentStrategiesTests/data-test/data-test.txt";
        private static readonly double delta = 0.001;
        private InvestmentStrategies.Indicators indicators;
        private RSI rsii;
        private int daysCount;

        public RSI_Test()
        {
            this.daysCount = 30;
            this.indicators = new InvestmentStrategies.Indicators();
            this.indicators.readData(pathToTestData);
            this.rsii = new RSI(indicators, daysCount);
        }

        [TestMethod]
        public void RSI_Test_General()
        {
            // czy dobrze liczy średnią wzrostów i spadków dla początkowego okresu
            Assert.AreEqual(2.0 / daysCount, rsii.avgGains[29], delta);
            Assert.AreEqual(1.0 / daysCount, rsii.avgLosses[29], delta);

            //kolejny dzień, bez wzrostu i spadku
            Assert.AreEqual( (rsii.avgGains[29] * 29 + 0) / 30, rsii.avgGains[30], delta);
            Assert.AreEqual( (rsii.avgLosses[29] * 29 + 0) / 30, rsii.avgLosses[30], delta);

            // dzień 31, wzrost o 1
            Assert.AreEqual( (rsii.avgGains[30] * 29 + 1) / 30, rsii.avgGains[31], delta);
            Assert.AreEqual( (rsii.avgLosses[30] * 29 + 0) / 30, rsii.avgLosses[31], delta);

            // liczenie RSI dla dnia 30
            Assert.AreEqual(100 - (100 / (1 + rsii.avgGains[30] / rsii.avgLosses[30])), rsii.data[30], delta);

            rsii.printData();
        }
    }
}
