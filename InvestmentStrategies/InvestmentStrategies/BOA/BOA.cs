using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentStrategies.BOA
{
    class BOA
    {
        #region Private Member Variables

        private int populationSize;
        private int chromosomeLength;
        private int iterationsNumber;

        #endregion

        #region Constructors

        public BOA(int popS, int chrL, int iterNum)
        {
            this.populationSize = popS;
            this.chromosomeLength = chrL;
            this.iterationsNumber = iterNum;
        }

        public BOA(int popS, int chrL) : this(popS, chrL, 0)
        {
        }

        #endregion

        public int[] BayesianOptimisationAlgorithm()
        {
            int iteration = 0;
            //Generujemy losową populację
            int[][] population = Population.CreateRandomPopulation(this.populationSize, this.chromosomeLength);
            //Obliczamy dla niej prawdopodobieństwa (wektor prawdopodobieństw dla zmiennych z sieci Bayesowskiej
            BayesianNetwork network = new BayesianNetwork();
            double[] probabilities = network.EvaluatePopulationProbabilities(population);
            network.CreateNetwork(population, probabilities);

            return population[0];
        }

    }
}
