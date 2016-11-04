using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Yatzhee
{
  public partial class Yahtzee : Form
  {
    public Yahtzee()
    {
      InitializeComponent();
    }

    public int mAantalTeerlingen = 5;
    public int mAantalSoortenScores = 7;
    public int mAantalSpelers = 2;
    public int mAantalCheats = 2;
    Panel[] mPlayerPanels = new Panel[2];
    public List<TeerlingController> mTeerlingenControl = new List<TeerlingController>();
    public List<ScoreboardController> mScoreboardControl = new List<ScoreboardController>();
    List<PlayerController> mPlayerControl = new List<PlayerController>();
    public ScoreboardView mScoreboardView = new ScoreboardView();
    TeerlingView mTeerlingView = new TeerlingView();

    PlayerView mPlayerview = new PlayerView();
    List<PlayerView> mPlayers = new List<PlayerView>();
    List<Label> mPlayerLabels = new List<Label>();

    private void Yahtzee_Load(object sender, EventArgs e)
    {
      

      for (int i = 0; i < mAantalSoortenScores; i++)
      {
        //instantie van ScoreboardController
        ScoreboardController tijdelijkeScore = new ScoreboardController();
        mScoreboardControl.Add(tijdelijkeScore);
            }

      for (int i = 0; i < mAantalSpelers; i++)
      {
        //instantie van playercontroller
        PlayerController tijdelijkeplayer = new PlayerController();
        mPlayerControl.Add(tijdelijkeplayer);
      }

      //teerlingen tonen
      TeerlingenTonen();

      //Aanmaken player + scorebord
      mPlayerPanels[0] = panel1;
      mPlayerPanels[1] = panel2;

      for (int i = 0; i < mAantalSpelers; i++)
      {
        mScoreboardView = mScoreboardControl[i].getView();

        addLabelPlayer(i);
        addTotaallbl(i);

        // array om labels bij te houden, zodat we ze niet altijd moeten zoeken met Find
        Label[] player1Labels = new Label[5];

        for (int j = 0; j < mAantalSoortenScores; j++)
        {
          addButton(i, j);
          addLabel(i, j);
        }
        mPlayerPanels[i].Controls.Add(mScoreboardView);
        mPlayerview.Controls.Add(mPlayerPanels[i]);
        Controls.Add(mPlayerview);
      }
      Controls.Add(mPlayerview);

      if (mPlayerControl[0].chooseRandomPlayer(mAantalSpelers) == 0)
      {
        mPlayerControl[0].playerModel.PlayerOneActive = false;
        changePlayer();
      }
      else
      {
        mPlayerControl[0].playerModel.PlayerOneActive = true;
        changePlayer();
      }

    }

        void Onb2Click(object sender, EventArgs e)
        {
            mScoreboardView.OnClick(sender, e);
            ChangePlayerOnClick(sender, e);
            mScoreboardControl[0].ResetAantalWorpen();


            mTeerlingView.ResetTeerlingenOnSwitch();

            for (int i = 0; i < mAantalTeerlingen; i++)
            {
                mTeerlingenControl[i].Werp();
                mTeerlingenControl[i].UpdateUI();
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
      mScoreboardView.Controls.Add(lbl);
    }

    void addButton(int i, int j)
    {
      Button btn = new Button();
      btn.Width = 100;
      btn.Height = 30;
      btn.Location = new Point(0, 50 + j * btn.Height);
      btn.Name = "btnName" + (i + 1) + (j + 1);
      btn.Click += new EventHandler(Onb2Click);
      mScoreboardView.UpdateScoreboardNames(j, btn);
      mScoreboardView.Controls.Add(btn);
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
      mScoreboardView.Controls.Add(lbl);
    }



    void addLabelPlayer(int i)
    {
      Label label = new Label();
      label.Name = "playerLabel" + (i + 1);
      label.Text = "player" + (i + 1);
      label.TextAlign = ContentAlignment.MiddleCenter;
      label.Location = new Point(mPlayerPanels[i].Top - 10, 10);
      mPlayerLabels.Add(label);
      mScoreboardView.Controls.Add(label);
    }
        static Label lblScore = null;
        public static Label LblScore
        {
            get { return lblScore; }
            set { lblScore = value; }
        }

        public void UpdateTotaalScore()
        {
            Yahtzee formYahtzee = Globals.formYahtzee;
            //Label lblScore = null;
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
                        lblScore = (Label)labels[0];                                             //   formYahtzee.updateScores( player1Scores ,  player2Scores)
                    }
                    else
                    {
                        MessageBox.Show("werkt niet");
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
                    MessageBox.Show("werkt niet");
                }

                mScoreboardControl[i].model.TotalScore = totalScore;
                lblScore.Text = mScoreboardControl[i].model.TotalScore.ToString();
            }

        }

        public void updateTotalLabelScore(int i, int totalScore)
        {

            Yahtzee formYahtzee = Globals.formYahtzee;
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
      if (mScoreboardControl[0].model.Score < 3)
      {
        for (int i = 0; i < mAantalTeerlingen; i++)
        {
          if (!mTeerlingenControl[i].model.ColorIsRed)
          {
            mTeerlingenControl[i].Werp();

            mTeerlingenControl[i].UpdateUI();
          }
        }
        mScoreboardControl[0].UpdateAantalWorpen();
      }
    }

    private void ChangePlayerOnClick(object sender, EventArgs e)
    {
      changePlayer();
    }

    void changePlayer()
    {
      if (mPlayerControl[0].playerModel.PlayerOneActive)
      {

        mPlayerPanels[1].Enabled = true;
        mPlayerPanels[0].Enabled = false;
        mPlayerControl[0].SwitchPlayer();
        mPlayerLabels[0].BackColor = Color.LightGray;
        mPlayerLabels[1].BackColor = Color.LightGreen;
      }
      else
      {
        mPlayerPanels[1].Enabled = false;
        mPlayerPanels[0].Enabled = true;
        mPlayerControl[0].SwitchPlayer();
        mPlayerLabels[1].BackColor = Color.LightGray;
        mPlayerLabels[0].BackColor = Color.LightGreen;
      }
    }

    void TeerlingenTonen()
    {
      for (int i = 0; i < mAantalTeerlingen; i++)
      {
        //instantie van teerlingcontroller
        TeerlingController tijdelijkeTeerling = new TeerlingController();
        mTeerlingenControl.Add(tijdelijkeTeerling);
                mTeerlingView.AddTeerling(tijdelijkeTeerling);
      }

      for (int i = 0; i < mAantalTeerlingen; i++)
      {
        TeerlingView teerlingView = mTeerlingenControl[i].getView();
        int horizontalPosition;
        horizontalPosition = i * teerlingView.Width;

        teerlingView.Location = new System.Drawing.Point(horizontalPosition, 0);

        panel3.Controls.Add(teerlingView);
        Controls.Add(panel3);
        mTeerlingenControl[i].Werp();
        mTeerlingenControl[i].UpdateUI();
      }
    }

        public void extraTeerlingTonen()
        {
            TeerlingController tijdelijkeTeerling = new TeerlingController();
            mTeerlingenControl.Add(tijdelijkeTeerling);
            mTeerlingView.AddTeerling(tijdelijkeTeerling);

            TeerlingView teerlingView = mTeerlingenControl[0].getView();
            int horizontalPosition, verticalPosition;
            horizontalPosition = 0 * teerlingView.Width;
            verticalPosition = 1 * teerlingView.Width;

            teerlingView.Location = new System.Drawing.Point(horizontalPosition, verticalPosition);

            panel3.Controls.Add(teerlingView);
            Controls.Add(panel3);
            mTeerlingenControl[0].Werp();
            mTeerlingenControl[0].UpdateUI();
        }
  }
}
