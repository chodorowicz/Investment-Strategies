using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentStrategies
{
    // Exponential Moving Average (EMA)
    public class EMA
    {
        public static double[] calculate(List<Dictionary<string, double>> stockData, double[] SMA, int period)
        {
            double[] EMA = new double[stockData.Count()];
            double percentage = (2.0 / (period + 1.0) );
            EMA[period-1] = SMA[period-1]; // take SMA as for the first EMA value

            for (int i = period; i < stockData.Count(); i++)
            {
                EMA[i] = ((stockData[i]["close"] - EMA[i - 1]) * percentage) + EMA[i - 1];
            }
            return EMA;
        }
    }
}
