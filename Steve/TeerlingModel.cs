namespace Yahtzee
{
    public class TeerlingModel
    {
        private int aantalOgen;
        private bool colorIsRed = false;
        private string teerlingLabelText = "";

        public bool ColorIsRed
        {
            get { return colorIsRed; }
            set { colorIsRed = value; }
        }

        public int AantalOgen
        {
            get { return aantalOgen; }
            set { aantalOgen = value; }
        }

        public string TeerlingLabelText
        {
            get { return teerlingLabelText; }
            set { teerlingLabelText = value; }
        }
    }
}
