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
            BOA.BOA boa = new InvestmentStrategies.BOA.BOA(20, 20);
            boa.BayesianOptimisationAlgorithm();

        }
    }
}
