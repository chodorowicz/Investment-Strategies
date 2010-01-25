using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Collections.Generic;

namespace InvestmentStrategies
{
    public abstract class AbstractIndicator
    {
        public double[] data;
        public abstract double decide(int day);
        
        public static double sumArray(double[] dataArray, int begin, int end)
        {
            double sum = 0;
            for (int i = begin; i <= end; i++) { sum += dataArray[i]; }
            return sum;
        }

        // http://en.wikipedia.org/wiki/Mean_absolute_deviation
        public static double meanAbsoluteDeviation(double[] dataArray, int n, int offset, double centralTendency)
        {
            double sum = 0;
            for (int i = offset - n + 1; i <= offset; i++)
            {
                sum += Math.Abs(centralTendency - dataArray[i]);
            }
            sum /= n;
            return sum;
        }



        public void printDecisions(int startDay) {
            for (int i = startDay; i < data.Length; i++)
            {
                Console.WriteLine(this.decide(i));
            }
        }

        public void printData()
        {
            for (int i = 0; i < data.Length; i++) Console.WriteLine(data[i]);
        }

        public void print(double[] dataToPrint)
        {
            for (int i = 0; i < dataToPrint.Length; i++) Console.WriteLine(dataToPrint[i]);
        }
    }


    public class Indicators
    {
        public List<Dictionary<string, double>> stockData;
        public List<Dictionary<string, List<double>>> ind__;
        public List<AbstractIndicator> indicators;

        public void readData(string path)
        {
            CultureInfo Invc = CultureInfo.InvariantCulture;
            List<Dictionary<string, double>> results = new List<Dictionary<string, double>>();
            int numRows = 300;

            using (StreamReader objReader = new StreamReader(path))
            {
                string strLineText;
                objReader.ReadLine(); // omitting first line with table headers
                
                int i = 0; // line iterator
                while ( ((strLineText = objReader.ReadLine()) != null) && (i <= numRows))
                {
                    String[] tempStrings = strLineText.Split(',');
                    double[] doublesArray = new double[5];
                    Dictionary<string, double> dict = new Dictionary<string, double>();

                    //dict.Add("date",   double.Parse(tempStrings[1], Invc));
                    dict.Add("open",   double.Parse(tempStrings[2], Invc));
                    dict.Add("high",   double.Parse(tempStrings[3], Invc));
                    dict.Add("low",    double.Parse(tempStrings[4], Invc));
                    dict.Add("close",  double.Parse(tempStrings[5], Invc));
                    dict.Add("volume", double.Parse(tempStrings[6], Invc));

                    results.Add(dict);
                    i++;
                }
            }
 
            this.stockData = results;
            this.calculateIndicators();
        }

        public void calculateIndicators()
        {
            indicators = new List<AbstractIndicator>();

            for( int i = 10; i <= 30; i++)
            {
                indicators.Add(new RSI(this, i));
            }

            for (int i = 10; i <= 30; i++)
            {
                indicators.Add(new StochasticOscillator(this, i, 3));
                indicators.Add(new StochasticOscillator(this, i, 5));
                indicators.Add(new StochasticOscillator(this, i, 7));
            }

            for (int i = 10; i <= 30; i++)
            {
                indicators.Add(new CommodityChannelIndex(this, i));
            }

            for (int i = 10; i <= 30; i++)
            {
                indicators.Add(new TRIX(this, i));
            }

            for (int i = 10; i <= 30; i++)
            {
                indicators.Add(new Force(this, i));
            }

            for (int i = 10; i <= 30; i++)
            {
                indicators.Add(new MFI(this, i));
            }


            Console.WriteLine(indicators.Count);
        }



        public double valueChange_Close(int day)
        {
            double valueChange = this.stockData[day]["close"] - this.stockData[day - 1]["close"];
            return valueChange;
        }

        public void testReadData(int row)
        {
            
            ICollection<string> keysCollection = this.stockData[row].Keys;
            foreach (string str in keysCollection)
            {
                Console.WriteLine("{0} : {1}", str, this.stockData[row][str]);
            }
            Console.ReadLine();
        }

      
    }
}
