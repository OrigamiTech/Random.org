using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Random.org
{
    public class IntegerGenerator
    {
        private List<int> ints = new List<int>();
        private int index = 0;
        private const int
            NUM_MIN = 1,
            NUM_MAX = 10000,
            MIN = -1000000000,
            MAX = 1000000000,
            COL_MAX = 1000000000,
            COL_DEFAULT = 1,
            BASE_DEFAULT = 10;
        public IntegerGenerator()
        { Init(NUM_MAX, MIN, MAX, COL_DEFAULT, BASE_DEFAULT); }
        public IntegerGenerator(int num)
        { Init(num, MIN, MAX, COL_DEFAULT, BASE_DEFAULT); }
        public IntegerGenerator(int num, int min)
        { Init(num, min, MAX, COL_DEFAULT, BASE_DEFAULT); }
        public IntegerGenerator(int num, int min, int max)
        { Init(num, min, max, COL_DEFAULT, BASE_DEFAULT); }
        public IntegerGenerator(int num, int min, int max, int col)
        { Init(num, min, max, col, BASE_DEFAULT); }
        public IntegerGenerator(int num, int min, int max, int col, int inbase)
        { Init(num, min, max, col, inbase); }
        private void Init(int num, int min, int max, int col, int inbase)
        {
            if (num >= NUM_MIN && num <= NUM_MAX)
                if (min >= MIN)
                    if (max <= MAX)
                        if (max > min)
                            if (col > 0 && col <= COL_MAX)
                                if (inbase == 2 || inbase == 8 || inbase == 10 || inbase == 16)
                                {
                                    string toParse = WebInterface.GetWebPage("http://www.random.org/integers/?num=" + num.ToString() + "&min=" + min.ToString() + "&max=" + max.ToString() + "&col=" + col.ToString() + "&base=" + inbase.ToString() + "&format=plain&rnd=new");
                                    foreach (string s in Regex.Split(toParse, @"\D"))
                                        try { ints.Add(Convert.ToInt32(s, inbase)); }
                                        catch { }
                                }
                                else
                                    throw new Exception("The base must be 2, 8, 10, or 16.");
                            else
                                throw new Exception("The column count must be between 1 and 1000000000.");
                        else
                            throw new Exception("The random number upper bound must be greater than the lower bound.");
                    else
                        throw new Exception("The random number upper bound must be between -1000000000 and 1000000000.");
                else
                    throw new Exception("The random number lower bound must be between -1000000000 and 1000000000.");
            else
                throw new Exception("The number of random numbers to generate must be between 1 and 10000.");
        }
        public int Get()
        {
            index++;
            index %= ints.Count;
            return ints[index];
        }
    }
}