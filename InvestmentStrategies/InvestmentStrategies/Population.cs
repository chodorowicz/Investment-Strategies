using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InvestmentStrategies.BOA;

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
                x[k] = Randoms.Instance.BinaryRandom(p[k]);

            return x;
        }

        /// <summary>
        /// Performs Selection by tournament mode
        /// </summary>
        /// <param name="parents">Selected parents individuals</param>
        /// <param name="population">Population to select parents from</param>
        /// <param name="howMany">How many should we pick</param>
        internal static void Selection(out int[][] parents, int[][] population, int howMany)
        {
            ObjectiveFunction objective = new ObjectiveFunction();
            double maxResult = Double.MinValue;
            int maxIndividual = Int32.MinValue;

            double tempResult;
            int tempIndividual;
            
            parents = new int[howMany][];
            for(int i = 0; i < parents.Length; i++)
                parents[i] = new int[population[i].Length];

            for (int i = 0; i < howMany; i++)
            {
                tempIndividual = Randoms.Instance.RandIntMax(population.Length);
                tempResult = objective.CountPerformanceRatio(population[tempIndividual]);
                if (tempResult > maxResult)
                {                    
                    maxResult = tempResult;
                    maxIndividual = tempIndividual; // po co mi to?
                }
                parents[i] = population[maxIndividual];                
            }
        }
    }
}
