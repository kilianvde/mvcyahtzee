using System;
using System.Windows.Forms;

namespace Yahtzee
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
            Globals.formYahtzee = new MainForm(); 
            Application.Run(Globals.formYahtzee);
        }
    }
    public static class Globals
    {
        public static MainForm formYahtzee;
    }
}
