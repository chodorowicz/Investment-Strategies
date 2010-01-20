using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Collections.Generic;

namespace InvestmentStrategies
{
    class Indicators
    {
        public List<Dictionary<string, float>> stockData;

        public void readData(string path)
        {
            CultureInfo Invc = CultureInfo.InvariantCulture;
            List<Dictionary<string, float>> results = new List<Dictionary<string, float>>();
            int numRows = 300;

            using (StreamReader objReader = new StreamReader("../../stock-data/BZWBK.txt"))
            {
                string strLineText;
                objReader.ReadLine(); // omitting first line with table headers
                
                int i = 0; // line iterator
                while ( ((strLineText = objReader.ReadLine()) != null) && (i <= numRows))
                {
                    String[] tempStrings = strLineText.Split(',');
                    float[] floatsArray = new float[5];
                    Dictionary<string, float> dict = new Dictionary<string, float>();

                    //dict.Add("date",   float.Parse(tempStrings[1], Invc));
                    dict.Add("open",   float.Parse(tempStrings[2], Invc));
                    dict.Add("high",   float.Parse(tempStrings[3], Invc));
                    dict.Add("low",    float.Parse(tempStrings[4], Invc));
                    dict.Add("close",  float.Parse(tempStrings[5], Invc));
                    dict.Add("volume", float.Parse(tempStrings[6], Invc));

                    results.Add(dict);
                    i++;
                }
            }
 
            this.stockData = results;
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

        public void indRSI(int days)
        {
            // Relative Strength Index
            int firstPeriod = 30;
            float valueChange;
            float totalGain = 0;
            float totalLoss = 0;
            int daysCount = 0;
            float[] avgGains = new float[this.stockData.Count];
            float[] avgLoses = new float[this.stockData.Count];

            if (days > 30)
            {
                days = 30;
            }
            for (int i = 1; i <= firstPeriod; i++)
            {
                valueChange = this.stockData[i]["close"] - this.stockData[i - 1]["close"];
                if (valueChange > 0)
                {
                    // wzrost wartości
                    totalGain += valueChange;
                }
                else
                {
                    totalLoss += -valueChange;
                }
                //this.stockData[]
                Console.WriteLine("{0}, {1}, {2}", valueChange, totalGain, totalLoss);
                daysCount++;
            }
            avgGains[daysCount] = totalGain / daysCount;
            avgLoses[daysCount] = totalLoss / daysCount;
            Console.WriteLine("Gains {0}", avgGains[daysCount]);
            Console.WriteLine("Loses {0}", avgLoses[daysCount]);
            Console.WriteLine(daysCount);



            Console.ReadLine();

        }
    }
}
