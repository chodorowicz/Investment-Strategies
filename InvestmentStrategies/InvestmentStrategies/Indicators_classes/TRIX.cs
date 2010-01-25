using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentStrategies
{
    public class TRIX : AbstractIndicator
    {
        public Indicators indicators;
        public int period;

        public TRIX(Indicators indicators, int period)
        {
            this.period = period;
            this.indicators = indicators;
            this.data = new double[this.indicators.stockData.Count];

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
            double[] sMA = SMA.calculate(indicators.stockData, period);
            data = EMA.calculate(indicators.stockData, sMA, period);
            data = EMA.calculate(indicators.stockData, data, period);
            data = EMA.calculate(indicators.stockData, data, period);
        }
    }
}
