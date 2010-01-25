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
            
            //Indicators indicators = new Indicators();
            //indicators.readData("../../data-stock/BZWBK.txt");
            //indicators.testReadData(1);
            //RSI rsi = new RSI(indicators, 30);
            //BOA.BOA boa = new InvestmentStrategies.BOA.BOA(20, 20);
            //boa.BayesianOptimisationAlgorithm();

            Indicators indicators = new Indicators();
            indicators.readData("../../data-stock/BZWBK.txt");
            indicators.calculateIndicators();
            Console.WriteLine(indicators.indicators[0].decide(50));
            indicators.indicators[0].printDecisions(50);
            Console.ReadLine();
            //StochasticOscillator SO = new StochasticOscillator(indicators, 30, 3);

        }
    }
}
