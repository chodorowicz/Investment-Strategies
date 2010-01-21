using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InvestmentStrategies.BOA;

namespace InvestmentStrategies
{
    class ObjectiveFunction
    {
        internal double CountPerformanceRatio(int[] individual)
        {
            double result = 0.0;

            #region Przypadkowe wartości na potrzeby chwilowych testów, zastąpić prawdziwymi wartościami!

            result = Randoms.Instance.RandDouble;
            
            #endregion


            return result;
        }
    }
}
