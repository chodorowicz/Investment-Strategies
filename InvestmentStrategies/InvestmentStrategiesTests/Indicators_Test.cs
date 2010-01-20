using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InvestmentStrategies;

namespace InvestmentStrategiesTests
{
    [TestClass]
    public class Indicators_Test
    {
        private static readonly string pathToTestData = "../../../InvestmentStrategiesTests/data-test/data-test.txt";

        public Indicators_Test()
        {
            Indicators indicators = new InvestmentStrategies.Indicators();
            indicators.readData(pathToTestData);
        }

        [TestMethod]
        public void indRSI_Test()
        {
           Assert.AreEqual("a", "a",
                "dummy test");

        }
    }
}
