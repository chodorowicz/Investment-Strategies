using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InvestmentStrategies;

namespace InvestmentStrategiesTests.Indicators_Tests
{
    /// <summary>
    /// Summary description for MFI_Test
    /// </summary>
    [TestClass]
    public class MFI_Test
    {
        private static readonly string pathToTestData = "../../../InvestmentStrategiesTests/data-test/data-test.txt";
        private static readonly double delta = 0.001;
        private InvestmentStrategies.Indicators indicators;

        public MFI_Test()
        {
            indicators = new InvestmentStrategies.Indicators();
            this.indicators.readData(pathToTestData);
        }


        [TestMethod]
        public void MFI_Test_General()
        {
            MFI mfi = new MFI(indicators, 20);
            Assert.AreEqual(10.0, mfi.rawMoneyFlow[10], delta);
            Assert.AreEqual(2 * 10.0, mfi.positiveMoneyFlow[20], delta);
            Assert.AreEqual(0.0, mfi.negativeMoneyFlow[20], delta);
        }
    }
}
