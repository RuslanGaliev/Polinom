using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinom
{
    //a separate summand
    public class Summand 
    {
        public int coef;
        public int degX;
        public int degY;
        public int degZ;
        public int[] degs = new int[3];
        
        public Summand(int coef, int degX, int degY, int degZ)
        {
            this.coef = coef;
            degs[0] = degX;
            degs[1] = degY;
            degs[2] = degZ;
        }

        public int SummandValue(int x, int y, int z)
        {
            int sum = 0;
            sum += Pow(x, degs[0]) * Pow(y, degs[1]) * Pow(z, degs[2]);
            return sum;
        }

        public static int Pow(int n, int deg)
        {
            int s = 1;
            for (int i = 0; i < deg; i++)            
                s *= n;            
            return s;
        }

        public char[] vars = new char[] { 'x', 'y', 'z' };

        public override string ToString()
        {
            StringBuilder summand = new StringBuilder();

            if (coef == 0)
            {
                return "";
            }

            else if (Math.Abs(coef) > 1)
            {
                summand.Append(coef);
            }

            for (int i = 0; i < degs.Length; i++)
            {
                if (degs[i] != 0)
                {
                    summand.Append(vars[i]);

                    if (Math.Abs(degs[i]) > 1)
                    {
                        summand.Append('^').Append(degs[i]);
                    }
                }
            }

            return summand.ToString();
        }
    }
}
