using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentStrategies
{
    public class SMA
    {
        public static double[] calculate(List<Dictionary<string, double>> stockData, int period)
        {
            double[] SMAData = new double[stockData.Count()];

            for (int i = 0; i < period; i++)
            {
                SMAData[period - 1] += stockData[i]["close"];
            }
            SMAData[period-1] /= period;

            for (int i = period; i < stockData.Count(); i++)
            {
                SMAData[i] = SMAData[i - 1] - (stockData[i - period]["close"] / period)
                    + (stockData[i]["close"] / period);
            }

            return SMAData;
        }

        public static double[] calculate(double[] data, int period)
        {
            double[] SMAData = new double[data.Count()];

            for (int i = 0; i < period; i++)
            {
                SMAData[period - 1] += data[i];
            }
            SMAData[period - 1] /= period;

            for (int i = period; i < data.Count(); i++)
            {
                SMAData[i] = SMAData[i - 1] - (data[i - period] / period)
                    + (data[i] / period);
            }

            return SMAData;
        }
    }
}
