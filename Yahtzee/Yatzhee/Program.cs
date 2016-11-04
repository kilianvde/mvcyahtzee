using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yatzhee
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Globals.formYahtzee = new Yahtzee();    //nieuw
            Application.Run(Globals.formYahtzee);   //extra globals om overal aan te kunnen
        }
    }

    public static class Globals     //nieuw
    {
      public static Yahtzee formYahtzee;
    }
}
