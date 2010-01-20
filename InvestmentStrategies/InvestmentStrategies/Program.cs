using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentStrategies
{
    class Program
    {
        static void Main(string[] args)
        {
            Indicators indicators = new Indicators();
            indicators.readData("dummy");
            //indicators.testReadData(1);
            indicators.indRSI(30);
            

        }
    }
}
