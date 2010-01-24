using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentStrategies
{
    public class StochasticOscillator : AbstractIndicator, IIndicator
    {
        public Indicators indicators;
        public int period;
        public int movingAveragePeriod;
        public double[] averageData;

        public StochasticOscillator(Indicators indicators, int period, int movingAveragePeriod)
        {
            this.period = period;
            this.indicators = indicators;
            this.movingAveragePeriod = movingAveragePeriod;
            this.data = new double[this.indicators.stockData.Count];
            this.averageData = new double[this.indicators.stockData.Count];

            this.calculate();
        }

        public double decide(int day)
        {
            if (averageData[day] > 80)       return -1.0; // sell
            else if (averageData[day] < 20)  return  1.0; // buy
            else                             return  1.0; // no decision              

        }

        private void calculate()
        {
            double recentClose, lowestLow, highestHigh;

            for (int i = period-1; i < indicators.stockData.Count; i++)
            {
                recentClose = indicators.stockData[i]["close"];
                lowestLow = indicators.stockData[i - period + 1]["low"];
                highestHigh = indicators.stockData[i - period + 1]["high"];

                for (int j = i - period + 2; j <= i; j++)
                {
                    if (indicators.stockData[j]["low"] < lowestLow)
                        lowestLow = indicators.stockData[j]["low"];
                }

                for (int j = i - period + 2; j <= i; j++)
                {
                    if (indicators.stockData[j]["high"] > highestHigh)
                        highestHigh = indicators.stockData[j]["high"];
                }

                if ((highestHigh - lowestLow) == 0.0) data[i] = 100;
                else data[i] = 100 * ((recentClose - lowestLow) / (highestHigh - lowestLow));
            }

            for (int i = movingAveragePeriod - 1; i < indicators.stockData.Count; i++)
            {
                for (int j = i - movingAveragePeriod + 1; j <= i; j++)
                {
                    averageData[i] += data[j];
                }
                averageData[i] /= movingAveragePeriod;
            }

        }
    }
}
