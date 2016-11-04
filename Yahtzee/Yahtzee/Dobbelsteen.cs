namespace Yahtzee
{
    public class Dobbelsteen
    {
        const int maxOgen = 6;
        private int ogen = 0;
        public int AantalOgen() { return ogen; }
        private bool locked = false;
        public bool IsLocked() { return locked; }
        
        public bool Werp(int n)
        {
            if (n > maxOgen) { return false; }
            else { ogen = n; return true; }
        }
    }
}
