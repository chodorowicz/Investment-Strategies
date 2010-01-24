using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentStrategies
{
    public class MFI : AbstractIndicator, IIndicator
    {
        public Indicators indicators;
        public int period;
        public double[] typicalPrice;
        public double[] rawMoneyFlow;
        public double[] positiveMoneyFlow;
        public double[] negativeMoneyFlow;


        public MFI(Indicators indicators, int period)
        {
            this.period = period;
            this.indicators = indicators;
            this.data = new double[this.indicators.stockData.Count];
            this.typicalPrice = new double[this.indicators.stockData.Count];
            this.rawMoneyFlow = new double[this.indicators.stockData.Count];
            this.positiveMoneyFlow = new double[this.indicators.stockData.Count];
            this.negativeMoneyFlow = new double[this.indicators.stockData.Count];

            this.calculate();
        }

        public double decide(int day)
        {
            if (data[day] > 80) return -1.0;      // overbought, sell!
            else if (data[day] < 20) return 1.0;  // oversold, buy!    
            else return 0.0;                      // no decision      
        }

        private void calculate()
        {
            double positive;
            double negative;
            double moneyRatio;

            for (int i = 0; i < indicators.stockData.Count; i++)
            {
                typicalPrice[i] = (indicators.stockData[i]["high"]
                                    + indicators.stockData[i]["low"]
                                    + indicators.stockData[i]["close"]) / 3;
                rawMoneyFlow[i] = typicalPrice[i] * indicators.stockData[i]["volume"];
            }

            for (int i = period; i < indicators.stockData.Count(); i++)
            {
                positiveMoneyFlow[i] = 0.0;
                negativeMoneyFlow[i] = 0.0;
                for (int j = i - period + 1; j <= period; j++)
                {
                    if (typicalPrice[j] > typicalPrice[j - 1])
                        positiveMoneyFlow[i] += rawMoneyFlow[j];
                    else if (typicalPrice[j] < typicalPrice[j - 1])
                        negativeMoneyFlow[i] += rawMoneyFlow[j];
                }
                if (negativeMoneyFlow[i] != 0.0)
                {
                    moneyRatio = positiveMoneyFlow[i] / negativeMoneyFlow[i];
                    data[i] = 100 - (100 / (1 + moneyRatio));
                }
                
            }


        }
    }
}
