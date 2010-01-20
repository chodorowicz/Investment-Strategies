using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentStrategies
{
    class Population
    {
        /// <summary>
        /// Creates Random Population
        /// </summary>
        /// <param name="populationSize">Integer value - Size of the population</param>
        /// <param name="chromosomeLength">Integer value - Lenght of the chromosome for an individual</param>
        /// <returns>Randomly generated population - int[][]</returns>
        internal static int[][] CreateRandomPopulation(int populationSize, int chromosomeLength)
        {
            int[][] population = new int[populationSize][];

            for (int i = 0; i < populationSize; i++)
                population[i] = (RandomIndividual(CommonFunctions.InitialProbabilityVector(chromosomeLength)));


            return population;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int[] RandomIndividual(double[] p)
        {
            int[] x = new int[p.Length];

            for (int k = 0; k < p.Length; k++)
                x[k] = CommonFunctions.BinaryRandom(p[k]);

            return x;
        }
    }
}
