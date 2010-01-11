using System;
using System.Collections;
using System.Globalization;
using System.IO;

namespace InvestmentStrategies
{
    class Indicators
    {
        public ArrayList stockData;

        public void readData(string path)
        {
            CultureInfo Invc = CultureInfo.InvariantCulture;
            ArrayList results = new ArrayList();
            int numRows = 300;

            using (StreamReader objReader = new StreamReader("../../stock-data/BZWBK.txt"))
            {
                string strLineText;
                objReader.ReadLine(); // omitting first line with table headers
                
                int i = 0; // line iterator
                while ( ((strLineText = objReader.ReadLine()) != null) && (i <= numRows))
                {
                    String[] tempStrings = strLineText.Split(',');
                    Double[] floatsArray = new Double[5];
                    
                    floatsArray[0] = Double.Parse(tempStrings[2], Invc); // Open
                    floatsArray[1] = Double.Parse(tempStrings[3], Invc); // High
                    floatsArray[2] = Double.Parse(tempStrings[4], Invc); // Low
                    floatsArray[3] = Double.Parse(tempStrings[5], Invc); // Close
                    floatsArray[4] = Double.Parse(tempStrings[6], Invc); // Volume

                    results.Add(floatsArray);
                    i++;
                }
            }
 
            this.stockData = results;
        }

        public void indRSI(int days)
        {
            // Relative Strength Index
            int firstPeriod = 30;

            if (days > 30)
            {
                days = 30;
            }
            for (int i = 0; i <= firstPeriod; i++)
            {
                //this.stockData[]
            }

            float[] avgGains;
            float[] avgLoses;


        }
    }
}
