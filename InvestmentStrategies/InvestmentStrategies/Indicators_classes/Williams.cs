using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentStrategies
{

    class Williams : AbstractIndicator
    {
        public Indicators indicators;
        public int period, movingAveragePeriod;
        public double[] averageData;


        public Williams(Indicators indicators, int period, int movingAveragePeriod)
        {
            this.period = period;
            this.indicators = indicators;
            this.movingAveragePeriod = movingAveragePeriod;
            this.data = new double[this.indicators.stockData.Count];
            this.averageData = new double[this.indicators.stockData.Count];

            this.calculate();
        }

        public override double decide(int day)
        {
            if (averageData[day] < -80) return 1.0;        // buy
            else if (averageData[day] > -20) return -1.0;   // sell 
            else return 0.0;             // no decision  
        }

        private void calculate() 
        {
            double lowestLow, highestHigh, recentClose;
            for (int i = period - 1; i < indicators.stockData.Count; i++)
            {

                lowestLow = AbstractIndicator.lowestLow(period, i, indicators.stockData);
                highestHigh = AbstractIndicator.highestHigh(period, i, indicators.stockData);
                recentClose = indicators.stockData[i]["close"];

                if ((highestHigh - lowestLow) == 0.0) data[i] = 0;
                else data[i] = (highestHigh - recentClose) / (highestHigh - lowestLow) - 100;

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
