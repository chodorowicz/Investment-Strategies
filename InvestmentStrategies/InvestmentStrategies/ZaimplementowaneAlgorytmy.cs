﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AlgorytmyEwolucyjne1
{
    //struct Osobnik
    //{
    //    private int[] _chromosome;
    //    private int _result;
    //    public Osobnik(int n)
    //    {
    //        _chromosome = new int[n];        
    //    }
    //}
    class ZaimplementowaneAlgorytmy
    {
        public delegate int targetFunctionDelegate(int[] chromosome);
        static Random r = new Random();

        static double[] InitialProbabilityVector(int d)
        {
            double[] p = new double[d];
            for (int k = 0; k < d; k++)
                p[k] = 0.5;

            return p;
        }

        static int BinaryRandom(double p)
        {
            return (r.NextDouble() < p) ? 1 : 0;
        }

        static int[] RandomIndividual(double[] p)
        {
            int[] x = new int[p.Length];

            for (int k = 0; k < p.Length; k++)
                x[k] = BinaryRandom(p[k]);

            return x;
        }

        public static void CompactGeneticAlgorithm(targetFunctionDelegate F, double theta, int vectorLength, int iterationNumber)
        {

            int bestYetResult = 0;
            int[] bestYetVector;

            double[] p = InitialProbabilityVector(vectorLength);
            int[] x1 = RandomIndividual(p);
            int[] x2 = RandomIndividual(p);

            int x1Result = F(x1);
            int x2Result = F(x2);

            int[] betterX, worseX;
            int betterResult = 0;
            using (TextWriter tw = new StreamWriter("wynikiCGA.csv", false))
            {
                for (int i = 0; i < iterationNumber; i++)
                {
                    betterX = (x1Result <= x2Result) ? x2 : x1;
                    worseX = (x1Result <= x2Result) ? x1 : x2;
                    betterResult = (x1Result <= x2Result) ? x2Result : x1Result;
                    if (betterResult > bestYetResult)
                    {
                        bestYetVector = betterX;
                        bestYetResult = betterResult;
                    }


                    tw.WriteLine(String.Format("{0}\t{1}", i, x1Result));


                    for (int k = 0; k < vectorLength; k++)
                    {
                        if (betterX[k] == 1 && worseX[k] == 0)
                            p[k] += theta;
                        if (betterX[k] == 0 && worseX[k] == 1)
                            p[k] -= theta;
                    }

                    x1 = RandomIndividual(p);
                    x2 = RandomIndividual(p);

                    x1Result = F(x1);
                    x2Result = F(x2);
                }
            }
        }

        public static void SimpleGeneticAlgorithm(targetFunctionDelegate F, int populationCount, int M)
        {
            double[] p = InitialProbabilityVector(populationCount);
            int[][] population = new int[populationCount][];
            int[] results = new int[populationCount];
            for (int i = 0; i < populationCount; i++)
            {
                population[i] = RandomIndividual(p);
                results[i] = F(population[i]);
            }

            for (int i = 0; i < 1000; i++)
            {
                //BlockSelection(population, M);
                //UniformCrossover(population);
            }
        
        }

        private static void UniformCrossover(int[][] population)
        {
            throw new NotImplementedException();
        }

        private static void BlockSelection(int[][] population, int M)
        {
            throw new NotImplementedException();
        }




        //SIMPLIFIED-SIMPLE-GENETIC-ALGORITHM(F,N,M)
        //1 P   RANDOM-POPULATION(N);
        //2 POPULATION-EVALUATION(P, F);
        //3 while not TERMINATION-CONDITION(P)
        //4 do
        //5 BLOCK-SELECTION(P,M);
        //6 UNIFORM-CROSSOVER(P);
        //7 POPULATION-EVALUATION(P, F);
    }
}
