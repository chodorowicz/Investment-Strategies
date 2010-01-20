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
            indicators.readData("../../data-stock/BZWBK.txt");
            //indicators.testReadData(1);
            RSI rsi = new RSI(indicators, 30);
            

        }
    }
}
