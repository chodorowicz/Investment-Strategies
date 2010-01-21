using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentStrategies.BOA
{
    public class Randoms
    {
        static Randoms _instance;
        private static Random rand;
        
        Randoms()
        {
            rand = new Random();
        }

        public static Randoms Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Randoms();
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        public double RandDouble
        {
            get
            {
                return rand.NextDouble();
            }
        }

        public int RandInt
        {
            get
            {
                return rand.Next();
            }
        }

        public int RandIntMax(int max)
        { 
            return rand.Next(max);
        }

        public int RandIntMinMax(int min, int max)
        {
            return rand.Next(min, max);
        }

        public void RandBytes(byte[] buffer)
        {
            rand.NextBytes(buffer);
        }

        /// <summary>
        /// Returns binary value, depending on a given value
        /// </summary>
        /// <param name="p">Value to compare with randomly generated number</param>
        /// <returns>1 if p > randomly generated number, 0 otherwise</returns>
        public int BinaryRandom(double p)
        {
            return (Randoms.Instance.RandDouble < p) ? 1 : 0;
        }
    }
}
