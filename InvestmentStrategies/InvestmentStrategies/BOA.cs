using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentStrategies
{
    class BOA
    {
        private int populationSize;
        private int chromosomeLength;

        public BOA(int popS, int chrL)
        {
            this.populationSize = popS;
            this.chromosomeLength = chrL;
        }

        public int[] BayesianOptimisationAlgorithm()
        {
            int[][] population = new int[this.populationSize][];

            for(int i = 0; i < populationSize; i++)
                for(int j = 0; j < chromosomeLength; j++)
                {
                    population[i] = (CommonFunctions.RandomIndividual(CommonFunctions.InitialProbabilityVector(chromosomeLength));
                }


            return population[0];
        }

    }
}
