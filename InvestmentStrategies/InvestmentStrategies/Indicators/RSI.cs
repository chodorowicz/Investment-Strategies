using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentStrategies
{
    public class RSI
    {
        public double[] avgGains;
        public double[] avgLosses;
        public double[] data;
        public Indicators indicators;
        public int daysCount;

        public RSI(Indicators indicators, int daysCount)
        {
            this.daysCount  = daysCount;
            this.indicators = indicators;
            this.avgGains = new double[this.indicators.stockData.Count];
            this.avgLosses = new double[this.indicators.stockData.Count];
            this.data = new double[this.indicators.stockData.Count];

            this.calculate();
        }

        private void calculate()
        {
            double valueChange;
            double totalGain = 0;
            double totalLoss = 0;
            int    currentDay = 1;

            for (int i = 1; i < daysCount; i++) // calculate for days 1 to daysCount
            {
                valueChange = indicators.valueChange_Close(i);

                if (valueChange > 0)
                {
                    totalGain += valueChange;
                }
                else
                {
                    totalLoss += -valueChange;
                }
                //Console.WriteLine("day {0}: {1}, {2}, {3}", daysCount, valueChange, totalGain, totalLoss);
                currentDay = i;
            }

            
            //avgGains[currentDay] = totalGain / daysCount;
            //avgLosses[currentDay] = totalLoss / daysCount;
            Console.WriteLine("{0} / {1}", totalGain, currentDay);
            Console.WriteLine("Gains {0}", avgGains[currentDay]);
            Console.WriteLine("Loses {0}", avgLosses[currentDay]);

            double RS;
            Console.WriteLine(indicators.stockData.Count);
            for (int i = currentDay + 1; i < indicators.stockData.Count; i++)
            {
                valueChange = indicators.valueChange_Close(i);
                if (valueChange > 0)
                {
                    avgGains[i] = (avgGains[i - 1] * (daysCount - 1) + valueChange) / daysCount;
                    avgLosses[i] = (avgLosses[i - 1] * (daysCount - 1) + 0) / daysCount;
                }
                else if (valueChange < 0)
                {
                    avgLosses[i] = (avgLosses[i - 1] * (daysCount - 1) - valueChange) / daysCount;
                    avgGains[i] = (avgGains[i - 1] * (daysCount - 1) - 0) / daysCount;
                }
                else
                {
                    avgGains[i] = (avgGains[i - 1] * (daysCount - 1) - 0) / daysCount;
                    avgLosses[i] = (avgLosses[i - 1] * (daysCount - 1) + 0) / daysCount;
                }

                if (avgLosses[i] == 0.0)
                {
                    data[i] = 100; // by definition
                }
                else
                {
                    RS = avgGains[i] / avgLosses[i];
                    data[i] = 100 - (100 / (1 + RS));
                }
            }
            //Console.WriteLine("Gains {0}", avgGains[daysCount+1]);
            //Console.WriteLine("Loses {0}", avgLosses[daysCount+1]);
            //Console.WriteLine(daysCount);
            //Console.ReadLine();
        }

    }
}
