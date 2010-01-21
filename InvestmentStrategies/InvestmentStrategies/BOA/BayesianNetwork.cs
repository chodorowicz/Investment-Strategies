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
        private double[] probabilities;
        private Graph<int> networkGraph = new Graph<int>();
        private double k2Metric;

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
            this.probabilities = probabilities;
            for (int i = 0; i < population.Length; i++)
            {
                GraphNode<int> newNode = new GraphNode<int>(i);
                newNode.Probability = probabilities[i];
                networkGraph.AddNode(newNode);
            }
            k2Metric = CountK2();            
        }

        internal void TestTheAlgorithms(int n)
        {
            int iterations = Randoms.Instance.RandIntMax(n);
            int tempFrom, tempTo;
            for (int i = 0; i < iterations; i++)
            {
                tempFrom = Randoms.Instance.RandIntMax(n - 1);
                tempTo = Randoms.Instance.RandIntMax(n - 1);
                while (tempFrom == tempTo)
                {
                    tempTo = Randoms.Instance.RandIntMax(n - 1);
                }
                GraphNode<int> v0 = (GraphNode<int>)this.networkGraph.Nodes.FindByValue(tempFrom);
                GraphNode<int> v1 = (GraphNode<int>)this.networkGraph.Nodes.FindByValue(tempTo);

                if (v1.Parents.Count < 2 && !v0.Neighbors.Contains(v1))
                {
                    
                    networkGraph.AddDirectedEdge(v0, v1);
                }
            }

            WriteNetworkElements();
            bool result = IsCyclic();
            WriteNetworkElements();
            
        }
        internal void WriteNetworkElements()
        {
            StringBuilder sb = new StringBuilder();
            foreach (GraphNode<int> node in networkGraph.Nodes)
            {
                sb.Append("Wierzchołek nr:" + node.Value + "\n");
                sb.Append("\tSąsiedzi:\n");
                foreach (GraphNode<int> neighbor in node.Neighbors)
                {
                    sb.Append("\t\t" + neighbor.Value + "\n");
                }
                sb.Append("\tRodzice:\n");
                foreach (GraphNode<int> parent in node.Parents)
                {
                    sb.Append("\t\t" + parent.Value + "\n");
                }
            }
            Console.WriteLine(sb.ToString());        
        }


        internal void NetworkGrow()
        {
            GraphNode<int> bestFrom = null;
            GraphNode<int> bestTo = null;
            double bestMetricYet = Double.MinValue;
            double tempMetric = Double.MinValue;
            foreach (GraphNode<int> v0 in networkGraph.Nodes)
            {
                foreach (GraphNode<int> v1 in networkGraph.Nodes)
                {
                    if (!v1.Parents.Contains(v1) && !v0.Parents.Contains(v1))
                    {
                        if (CanAddEdge(v0, v1))
                        {
                            //networkGraph.AddDirectedEdge(v0, v1);
                            tempMetric = CountK2();
                            if (tempMetric > bestMetricYet)
                            {
                                bestFrom = v0;
                                bestTo = v1;
                                bestMetricYet = tempMetric;
                            }
                            networkGraph.RemoveDirectedEdge(v0, v1);
                        }
                    }
                }
            }

            k2Metric = bestMetricYet;
            networkGraph.AddDirectedEdge(bestFrom, bestTo);
            WriteNetworkElements();

        }
        private bool CanAddEdge(GraphNode<int> v0, GraphNode<int> v1)
        {
            if (v1.Parents.Count < 2)
            {
                networkGraph.AddDirectedEdge(v0, v1);
                if (IsCyclic())
                {
                    networkGraph.RemoveDirectedEdge(v0, v1);
                    return false;
                }
                else
                    return true;
            }
            else
                return false;
        }
        internal bool DFSHasCycles(GraphNode<int> actualNode, GraphNode<int> mainNode)
        {
            if(actualNode.Neighbors.Contains(mainNode))
                return true;
            foreach (GraphNode<int> n in actualNode.Neighbors)
                if (DFSHasCycles(n, mainNode))
                    return true;

            return false;
        }
        
        internal bool IsCyclic()
        {
            bool result = false;
            Graph<int> temp = networkGraph;
            foreach (GraphNode<int> node in temp.Nodes)
            {
                foreach (GraphNode<int> neighbor in node.Neighbors)
                { 
                    //if(!visited.Contains(neighbor))
                    if (DFSHasCycles(neighbor, node))
                        return true;
#warning PRawdopodobnie można tu usuwać takie wierzchołki, dla których już wiemy, że nie ma cyklu.                        
                }
            
            }

            return result;
        }

        private double CountK2()
        {
            double result = 0.0;

            return result;
        }
    }
}
