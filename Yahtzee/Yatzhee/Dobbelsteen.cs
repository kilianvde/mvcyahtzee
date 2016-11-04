using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzhee
{
    public class Dobbelsteen
    {
        const int maxOgen = 6;
        private int ogen = 0;
        private bool locked = false;
        public int AantalOgen() { return ogen; }
        public bool IsLocked() { return locked; }
        public bool Werp(int n)
        {
            if (n > maxOgen) { return false; }
            else { ogen = n; return true; }                     //  if dobbelsteen[3].Werp(4)  then {}  else { MessageBox ("foutieve worp";}
        }
    }
}
