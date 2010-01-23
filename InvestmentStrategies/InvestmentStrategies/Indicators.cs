using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Collections.Generic;

namespace InvestmentStrategies
{
    public interface IIndicator
    {
        double decide(int day);
    }

    public abstract class AbstractIndicator
    {
        public double[] data;
        
        public void printData()
        {
            for (int i = 0; i < data.Length; i++) Console.WriteLine(data[i]);
        }
    }


    public class Indicators
    {
        public List<Dictionary<string, double>> stockData;
        public List<Dictionary<string, List<double>>> ind__;
        public List<IIndicator> indicators;

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
            indicators = new List<IIndicator>();
            indicators.Add(new RSI(this, 30));
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
