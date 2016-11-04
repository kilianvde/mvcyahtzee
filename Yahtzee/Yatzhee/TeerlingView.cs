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
  public partial class TeerlingView : UserControl
  {
        private TeerlingController controller;
        static public List<TeerlingController> mTeerlingControl = new List<TeerlingController>();
        static public List<PictureBox> listOfPicturesBoxes = new List<PictureBox>();
        public TeerlingView(TeerlingController c)
        {
            InitializeComponent();
            controller = c;

        }

        public TeerlingView()
        {

        }

        public void AddTeerling(TeerlingController c)
        {
            mTeerlingControl.Add(c);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!controller.model.ColorIsRed)
            {
                controller.Werp();
                controller.UpdateUI();

            }
        }

        private void TeerlingView_Load(object sender, EventArgs e)
        {
            btnWerpTeerling.Visible = false;

        }

        public void UpdateUI(int i)
        {
            switch (i)
            {
                case 1:
                    TeerlingBox.Image = Properties.Resources.dice1;
                    break;
                case 2:
                    TeerlingBox.Image = Properties.Resources.dice2;
                    break;
                case 3:
                    TeerlingBox.Image = Properties.Resources.dice3;
                    break;
                case 4:
                    TeerlingBox.Image = Properties.Resources.dice4;
                    break;
                case 5:
                    TeerlingBox.Image = Properties.Resources.dice5;
                    break;
                case 6:
                    TeerlingBox.Image = Properties.Resources.dice6;
                    break;
                default:
                    break;
            }

        }

        public void ResetTeerlingenOnSwitch()
        {

            for (int i = 0; i < listOfPicturesBoxes.Count; i++)
            {
                listOfPicturesBoxes[i].BackColor = Color.White;
                
            }
            for (int i = 0; i < mTeerlingControl.Count; i++)
            {
                mTeerlingControl[i].model.ColorIsRed = false;
            }
        }


        private void changeColor()
        {
            if (controller.model.ColorIsRed)
            {
                TeerlingBox.BackColor = Color.White;
                controller.Fixated();
            }
            else
            {
                TeerlingBox.BackColor = Color.Red;
                controller.Fixated();
            }
        }

        private void TeerlingBox_Click(object sender, EventArgs e)
        {
            changeColor();
            listOfPicturesBoxes.Add((PictureBox)sender);
        }

        private void btnWerpTeerling_Click(object sender, EventArgs e)
        {
            if (controller.model.ColorIsRed)
            {
                return;
            }
            else
            {
                controller.Werp();
                controller.UpdateUI();
            }
        }

        public void cheatButtonVisibility()
        {
            btnWerpTeerling.Visible = true;
        }
    }
}
