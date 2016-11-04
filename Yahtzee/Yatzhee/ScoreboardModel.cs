using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzhee
{
    public class ScoreboardModel
    {
        const int aantalDobbelstenen = 5;
        Dobbelsteen[] dobbelstenen = new Dobbelsteen[aantalDobbelstenen];
        private int ogen = 0;
        
        string[] mScoreNamen = { "Aantal Worpen :", "Score :", "Highscore :" };
        string[] mScoreNameAmounts = { "een", "twee", "drie", "vier", "vijf", "zes", "yahtzee" };

        private static int aantalWorpen;
        private int score;

        private int totalscore = 0;

        public int TotalScore
        {
            get { return totalscore; }
            set { totalscore = value; }
        }

        public int AantalOgen() { return ogen; }

        public int TelOgen(int n)        {                    //  gevonden= TelOgen(3);
            int aantal = 0;
            for (int i = 0; i < aantalDobbelstenen; i++)
            {
                if (dobbelstenen[i].AantalOgen() == n) { aantal++; }
            }
                return aantal;
        }

             
        public string[] ScoreNameAmounts
        {
            get { return mScoreNameAmounts; }
        }




        public string[] ScoreNamen
        {
            get { return mScoreNamen; }
        }

        public static int Aantalworpen
        {
            get { return aantalWorpen; }
            set { aantalWorpen = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

    }
}
