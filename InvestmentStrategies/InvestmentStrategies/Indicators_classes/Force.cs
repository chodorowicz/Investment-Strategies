using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentStrategies
{
    public class Force : AbstractIndicator
    {
        public Indicators indicators;
        public int period;
        public double[] simpleForce;

        public Force(Indicators indicators, int period)
        {
            this.period = period;
            this.indicators = indicators;
            this.data = new double[this.indicators.stockData.Count];
            this.simpleForce = new double[this.indicators.stockData.Count];

            this.calculate();
        }

        public override double decide(int day)
        {
            if (data[day] > 0 && data[day - 1] < 0) return 1.0;        // buy
            else if (data[day] < 0 && data[day - 1] > 0) return 0.0;   // sell 
            else return 0.0;             // no decision  
        }

        private void calculate()
        {
            for (int i = 1; i < indicators.stockData.Count(); i++)
            {
                simpleForce[i] = (indicators.stockData[i]["close"] - indicators.stockData[i-1]["close"])
                    * indicators.stockData[i]["volume"];
            }
            double[] sma = SMA.calculate(simpleForce, period);
            data = EMA.calculate(simpleForce, sma, period);
        }

    }
}
