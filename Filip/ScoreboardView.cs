using System;
using System.Windows.Forms;

namespace Yahtzee
{
    public partial class ScoreboardView : UserControl
    {
        private ScoreboardController controller;

        ScoreboardModel model = new ScoreboardModel();

        public ScoreboardView() { }
        public ScoreboardView(ScoreboardController c)
        {
            InitializeComponent();
            controller = c;
        }
        public void UpdateScoreboard()
        {
        }

        public void UpdateScoreboardNames(int i, Button btn)
        {
            string scoreName = controller.model.ScoreNameAmounts[i];
            btn.Text = scoreName;
        }

        public void OnClick(object sender, EventArgs e)
        {

            Button clickedButton = (Button)sender;
            MainForm formYahtzee = Globals.formYahtzee;
            Label lblScore = null;

            int aantal = 0;
            int btnScoreWaarde = (clickedButton.Name[clickedButton.Name.Length - 1] - 48);      //ASCII code voor 1 is 49(dus -48)

            Boolean yahtzeeWorp = true; 
            int yahtzeeWorpWaarde = 0;

            clickedButton.Enabled = false;

            for (int i = 0; i < formYahtzee.aantalTeerlingen; i++)
            {
                if (formYahtzee.teerlingenControl[i].model.AantalOgen == btnScoreWaarde)
                {
                    aantal++;
                }

                if (i == 0) 
                {
                    yahtzeeWorpWaarde = formYahtzee.teerlingenControl[i].model.AantalOgen;
                }
                else
                {
                    if (formYahtzee.teerlingenControl[i].model.AantalOgen != yahtzeeWorpWaarde) { yahtzeeWorp = false; }
                }

            }
            if (yahtzeeWorp && (btnScoreWaarde == 7))
            {
                MessageBox.Show("Yahtzee");
            }

            string targetLabel = clickedButton.Name.Replace("btnName", "lblScore");
            Control[] labels = formYahtzee.Controls.Find(targetLabel, true);
            if (labels.Length == 1)
            {
                lblScore = (Label)labels[0];                                             
            }
            else
            {
                MessageBox.Show("kapot");
            }

            lblScore.Text = (aantal * btnScoreWaarde).ToString();
            if (yahtzeeWorp && (btnScoreWaarde == 7)) { lblScore.Text = "50"; }
            formYahtzee.UpdateTotaalScore();
        }

        public void NameBtn()
        {
            string arrNamen = model.ScoreNameAmounts[5];

            foreach (int i in arrNamen)
            {
                arrNamen = model.ScoreNameAmounts[i];
            }
        }
    }
}
