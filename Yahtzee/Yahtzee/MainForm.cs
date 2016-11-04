/*
 * 
 * BASE MAIN CODE
 * 
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Yahtzee
{
    public partial class MainForm : Form
    {
        public int aantalTeerlingen = 5;
        public int aantalSoortenScores = 7;
        public int aantalSpelers = 2;
        public int aantalCheats = 2;
        Panel[] playerPanels = new Panel[2];
        public List<TeerlingController> teerlingenControl = new List<TeerlingController>();
        public List<ScoreboardController> scoreboardControl = new List<ScoreboardController>();
        List<PlayerController> playerControl = new List<PlayerController>();
        List<CheatsController> cheatsControl = new List<CheatsController>();
        public ScoreboardView scoreboardView = new ScoreboardView();
        TeerlingView teerlingView = new TeerlingView();

        PlayerView playerview = new PlayerView();
        List<PlayerView>  players = new List<PlayerView>();
        List<Label> playerLabels = new List<Label>();
        List<CheatsView> cheatsViewList = new List<CheatsView>();
        CheatsView cheatsview = new CheatsView();


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < aantalSoortenScores; i++)
            {
                ScoreboardController tijdelijkeScore = new ScoreboardController();
                scoreboardControl.Add(tijdelijkeScore);
                cheatsview.addController(tijdelijkeScore);
            }

            for (int i = 0; i < aantalSpelers; i++)
            {
                PlayerController tijdelijkeplayer = new PlayerController();
                playerControl.Add(tijdelijkeplayer);
            }

            TeerlingenTonen();

            //CREATE PANELS AND INIT
            playerPanels[0] = pnlSpeler1;
            playerPanels[1] = pnlSpeler2;

            ToonCheats();

            for (int i = 0; i < aantalSpelers; i++)
            {
                scoreboardView = scoreboardControl[i].getView();

                addLabelPlayer(i);
                addTotaallbl(i);

                Label[] player1Labels = new Label[5];

                for (int j = 0; j < aantalSoortenScores; j++)
                {
                    addButton(i, j);
                    addLabel(i, j);
                }
                playerPanels[i].Controls.Add(scoreboardView);
                playerview.Controls.Add(playerPanels[i]);
                Controls.Add(playerview);
            }
            Controls.Add(playerview);

            if (playerControl[0].chooseRandomPlayer(aantalSpelers) == 0)
            {
                playerControl[0].plrModel.IsPlayerOneActive = false;
                changePlayer();
            }
            else
            {
                playerControl[0].plrModel.IsPlayerOneActive = true;
                changePlayer();
            }
        }
        void Onb2Click(object sender, EventArgs e)
        {
            scoreboardView.OnClick(sender, e);
            ChangePlayerOnClick(sender, e);
            scoreboardControl[0].ResetAantalWorpen();


            teerlingView.ResetTeerlingenOnSwitch();

            for (int i = 0; i < aantalTeerlingen; i++)
            {
                teerlingenControl[i].Werp();
                teerlingenControl[i].UpdateUI();
            }
        }

        void addLabel(int i, int j)
        {
            Label lbl = new Label();
            lbl.Name = "lblScore" + (i + 1) + (j + 1);
            lbl.Text = "0";
            lbl.Width = 80;
            lbl.Height = 30;
            lbl.Location = new Point(120, 60 + j * lbl.Height);
            scoreboardView.Controls.Add(lbl);
        }

        void addButton(int i, int j)
        {
            Button btn = new Button();
            btn.Width = 100;
            btn.Height = 30;
            btn.Location = new Point(0, 50 + j * btn.Height);
            btn.Name = "btnName" + (i + 1) + (j + 1);
            btn.Click += new EventHandler(Onb2Click);
            scoreboardView.UpdateScoreboardNames(j, btn);
            scoreboardView.Controls.Add(btn);
        }

        void addTotaallbl(int i)
        {
            Label lbl = new Label();
            lbl.Name = "lblTotalScore" + (i + 1);
            lbl.Text = "0";
            lbl.Width = 150;
            lbl.Height = 25;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Location = new Point(110, 10);
            scoreboardView.Controls.Add(lbl);
        }



        void addLabelPlayer(int i)
        {
            Label label = new Label();
            label.Name = "playerLabel" + (i + 1);
            label.Text = "player" + (i + 1);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Location = new Point(playerPanels[i].Top - 10, 10);
            playerLabels.Add(label);
            scoreboardView.Controls.Add(label);
        }
        static Label lblScore = null;
        public static Label LblScore
        {
            get { return lblScore; }
            set { lblScore = value; }
        }

        public void UpdateTotaalScore()
        {
            MainForm formYahtzee = Globals.formYahtzee;
            string targetLabel;
            for (int i = 0; i < 2; i++)
            {
                int totalScore = 0;
                for (int j = 0; j < 6; j++)
                {
                    targetLabel = "lblScore" + (i + 1) + (j + 1);
                    Control[] labels = formYahtzee.Controls.Find(targetLabel, true);
                    if (labels.Length == 1)
                    {
                        lblScore = (Label)labels[0];
                    }
                    else
                    {
                        MessageBox.Show("oops kapot");
                    }
                    totalScore += Int32.Parse(lblScore.Text);
                }

                targetLabel = "lblTotalScore" + (i + 1);
                Control[] labels2 = formYahtzee.Controls.Find(targetLabel, true);
                if (labels2.Length == 1)
                {
                    lblScore = (Label)labels2[0];
                }
                else
                {
                    MessageBox.Show("oops kpaot");
                }

                scoreboardControl[i].model.TotalScore = totalScore;
                lblScore.Text = scoreboardControl[i].model.TotalScore.ToString();
            }

        }

        public void updateTotalLabelScore(int i, int totalScore)
        {

            MainForm formYahtzee = Globals.formYahtzee;
            string targetLabel;
            targetLabel = "lblTotalScore" + (i + 1);
            Control[] labels2 = formYahtzee.Controls.Find(targetLabel, true);
            if (labels2.Length == 1)
            {
                lblScore = (Label)labels2[0];
            }

            lblScore.Text = totalScore.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (scoreboardControl[0].model.Score < 3)
            {
                for (int i = 0; i < aantalTeerlingen; i++)
                {
                    if (!teerlingenControl[i].model.ColorIsRed)
                    {
                        teerlingenControl[i].Werp();

                        teerlingenControl[i].UpdateUI();
                    }
                }
                scoreboardControl[0].UpdateAantalWorpen();
            }
        }

        private void ChangePlayerOnClick(object sender, EventArgs e)
        {
            changePlayer();
        }

        void changePlayer()
        {
            if (playerControl[0].plrModel.IsPlayerOneActive)
            {
                playerPanels[1].Enabled = true;
                playerPanels[0].Enabled = false;
                cheatsViewList[0].Enabled = false;
                cheatsViewList[1].Enabled = true;
                playerControl[0].SwitchPlayer();
                playerLabels[0].BackColor = Color.LightGray;
                playerLabels[1].BackColor = Color.LightGreen;
            }
            else
            {
                playerPanels[1].Enabled = false;
                playerPanels[0].Enabled = true;
                cheatsViewList[0].Enabled = true;
                cheatsViewList[1].Enabled = false;
                playerControl[0].SwitchPlayer();
                playerLabels[1].BackColor = Color.LightGray;
                playerLabels[0].BackColor = Color.LightGreen;
            }
        }

        void TeerlingenTonen()
        {
            for (int i = 0; i < aantalTeerlingen; i++)
            {
                //instantie van teerlingcontroller
                TeerlingController tijdelijkeTeerling = new TeerlingController();
                teerlingenControl.Add(tijdelijkeTeerling);
                cheatsview.AddTeerling(tijdelijkeTeerling);
                teerlingView.AddTeerling(tijdelijkeTeerling);
            }

            for (int i = 0; i < aantalTeerlingen; i++)
            {
                TeerlingView teerlingView = teerlingenControl[i].getView();
                int horizontalPosition;
                horizontalPosition = i * teerlingView.Width;

                teerlingView.Location = new System.Drawing.Point(horizontalPosition, 0);

                pnlDobbelstenen.Controls.Add(teerlingView);
                Controls.Add(pnlDobbelstenen);
                teerlingenControl[i].Werp();
                teerlingenControl[i].UpdateUI();
            }
        }

        public void extraTeerlingTonen()
        {
            TeerlingController tijdelijkeTeerling = new TeerlingController();
            teerlingenControl.Add(tijdelijkeTeerling);
            cheatsview.AddTeerling(tijdelijkeTeerling);
            teerlingView.AddTeerling(tijdelijkeTeerling);


            TeerlingView teerlingView = teerlingenControl[0].getView();
            int horizontalPosition, verticalPosition;
            horizontalPosition = 0 * teerlingView.Width;
            verticalPosition = 1 * teerlingView.Width;

            teerlingView.Location = new System.Drawing.Point(horizontalPosition, verticalPosition);

            pnlDobbelstenen.Controls.Add(teerlingView);
            Controls.Add(pnlDobbelstenen);
            teerlingenControl[0].Werp();
            teerlingenControl[0].UpdateUI();
        }

        void ToonCheats()
        {
            for (int i = 0; i < aantalCheats; i++)
            {
                CheatsController tijdelijkeController = new CheatsController();
                cheatsControl.Add(tijdelijkeController);
            }

            for (int i = 0; i < aantalCheats; i++)
            {
                CheatsView cheatsview = cheatsControl[i].GetViewCheats();

                int horizontalPosition;
                horizontalPosition = i * cheatsview.Width;
                cheatsview.Location = new Point(horizontalPosition, playerPanels[i].Bottom);
                cheatsview.Name = "cheatsview" + i;
                cheatsViewList.Add(cheatsview);
                Controls.Add(cheatsview);
            }
        }
    }
}
