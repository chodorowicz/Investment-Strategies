using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InvestmentStrategies;

namespace InvestmentStrategiesTests.Indicators_Tests
{
    /// <summary>
    /// Summary description for Force_Test
    /// </summary>
    [TestClass]
    public class Force_Test
    {

        private static readonly string pathToTestData = "../../../InvestmentStrategiesTests/data-test/EMA.txt";
        private static readonly double delta = 0.001;
        private InvestmentStrategies.Indicators indicators;

        public Force_Test()
        {
            indicators = new InvestmentStrategies.Indicators();
            this.indicators.readData(pathToTestData);
        }


        [TestMethod]
        public void TestMethod1()
        {
            Force force = new Force(indicators, 10);
            Console.WriteLine(force.simpleForce[1]);
            force.printData();
        }
    }
}
