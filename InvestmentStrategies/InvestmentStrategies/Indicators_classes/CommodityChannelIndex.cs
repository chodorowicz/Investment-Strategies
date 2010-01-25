using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentStrategies
{
    public class CommodityChannelIndex : AbstractIndicator
    {
        public Indicators indicators;
        public int period;
        public int movingAveragePeriod;
        public double[] typicalPrice;
        public double[] SMATP; // Simple Moving Average of the Typical Price
        public double[] meanAbsoluteDeviationData;


        public CommodityChannelIndex(Indicators indicators, int period) 
        {
            this.period = period;
            this.indicators = indicators;
            this.data = new double[this.indicators.stockData.Count];
            this.SMATP = new double[this.indicators.stockData.Count];
            this.typicalPrice = new double[this.indicators.stockData.Count];
            this.meanAbsoluteDeviationData = new double[this.indicators.stockData.Count];

            this.calculate();
        }


        public override double decide(int day)
        {
            if (data[day] > 100) return 1.0;        // buy
            else if (data[day] < -100) return -1.0; // sell 
            else return 0.0;                        // no decision  
        }



        private void calculate() 
        {
            for (int i = 0; i < indicators.stockData.Count; i++)
            {

                typicalPrice[i] = (indicators.stockData[i]["high"]
                                    + indicators.stockData[i]["low"]
                                    + indicators.stockData[i]["close"]) / 3;
            }

            
            for (int i = 0; i < period; i++)
            {
                SMATP[period-1] += typicalPrice[i];
            }
            SMATP[period - 1] /= period;
            meanAbsoluteDeviationData[period-1] = AbstractIndicator.meanAbsoluteDeviation(
                                                            typicalPrice, period, period-1, SMATP[period-1]);


            for (int i = period; i < indicators.stockData.Count; i++)
            {
                SMATP[i] = SMATP[i - 1] - (typicalPrice[i - period] / period) + (typicalPrice[i] / period);

                meanAbsoluteDeviationData[i] = AbstractIndicator.meanAbsoluteDeviation(
                                                typicalPrice, period, i, SMATP[i]);

                this.data[i] = (typicalPrice[i] - SMATP[i]) / (0.015 * meanAbsoluteDeviationData[i]);
            }


        }

    }
}
