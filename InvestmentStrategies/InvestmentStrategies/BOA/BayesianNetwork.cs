using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentStrategies.BOA
{
    class BayesianNetwork
    {
        private int populationSize;
        private int chromosomeLenght;
        private Graph<int> networkGraph = new Graph<int>();

        internal double[] EvaluatePopulationProbabilities(int[][] population)
        {
            populationSize = population.Length;
            if (populationSize > 0)
            {
                chromosomeLenght = population[0].Length;
                double[] probabilityVector = new double[chromosomeLenght];

                for (int j = 0; j < chromosomeLenght; j++) 
                {
                    for (int i = 0; i < populationSize; i++)
                        probabilityVector[j] += population[i][j];
                    probabilityVector[j] /= populationSize;
                }

                return probabilityVector;
            }
            else
                throw new ArgumentOutOfRangeException("By obliczyć wektor prawdopodobieństw, populacja musi zawierać jakiegoś osobnika");
        }

        internal void CreateNetwork(int[][] population, double[] probabilities)
        {
            
        }
    }
}
