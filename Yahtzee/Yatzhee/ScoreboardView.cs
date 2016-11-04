using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Yatzhee
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

        private void label1_Click(object sender, EventArgs e)
        {
            
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
            Yahtzee formYahtzee = Globals.formYahtzee;
            Label lblScore = null;

            int aantal = 0;
            int btnScoreWaarde = (clickedButton.Name[clickedButton.Name.Length - 1] - 48);      //ASCII code voor 1 is 49(dus -48)
            //string btnYahtzeeName = clickedButton.Name.ToString();

            Boolean yahtzeeWorp = true;    //  wordt op false gezet zodra er een dobbelsteen verschillend is
            int yahtzeeWorpWaarde = 0;

            clickedButton.Enabled = false;

            for (int i = 0; i < formYahtzee.mAantalTeerlingen; i++)
            {
                if (formYahtzee.mTeerlingenControl[i].model.AantalOgen == btnScoreWaarde)
                {
                    aantal++;
                }

                if (i == 0)    // eerste dobbelsteen
                {
                    yahtzeeWorpWaarde = formYahtzee.mTeerlingenControl[i].model.AantalOgen;
                }
                else
                {
                    if (formYahtzee.mTeerlingenControl[i].model.AantalOgen != yahtzeeWorpWaarde) { yahtzeeWorp = false; }
                }

            }
            if (yahtzeeWorp && (btnScoreWaarde == 7))
            {
                MessageBox.Show("Yahtzee");
            }


            //string targetLabel = "lblScore" + suffix;
            string targetLabel = clickedButton.Name.Replace("btnName", "lblScore");
            Control[] labels = formYahtzee.Controls.Find(targetLabel, true);
            if (labels.Length == 1)
            {
                lblScore = (Label)labels[0];                                             //   formYahtzee.updateScores( player1Scores ,  player2Scores)
            }
            else
            {
                MessageBox.Show("werkt niet");
            }


            lblScore.Text = (aantal * btnScoreWaarde).ToString();
            if (yahtzeeWorp && (btnScoreWaarde == 7)) { lblScore.Text = "50"; }
            formYahtzee.UpdateTotaalScore();

            //MessageBox.Show(""+ btnScoreWaarde);
        }

        public void telDobbelstenen(int n)
        {
            //int aantal =  Yahtzee
            
        }

        public void NameBtn()   //waarde opvragen van buttons(namen)
        {
            string arrNamen = model.ScoreNameAmounts[5];


            foreach (int i in arrNamen)
            {

                //nameButton = btnName.Text;
                arrNamen = model.ScoreNameAmounts[i];
            }  
        }

        private void ScoreboardView_Load(object sender, EventArgs e)
        {

        }

        

    }
}
