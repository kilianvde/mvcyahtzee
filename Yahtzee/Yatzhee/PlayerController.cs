using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzhee
{
    public class PlayerController
    {
        public PlayerModel playerModel;
        public ScoreboardModel scoreboardModel;
        public PlayerView view;
        static Random rnd = new Random();
        protected Yahtzee yahtzee;

        public PlayerView getView()
        {
            return view;

        }

        public PlayerController()
        {
            playerModel = new PlayerModel();
        }

        public void SwitchPlayer()
        {
            if (playerModel.PlayerOneActive)
            {
                playerModel.PlayerOneActive = false;
            }
            else
            {
                playerModel.PlayerOneActive = true;
            }
        }

        public int chooseRandomPlayer(int i)
        {
            int randomPlayer = rnd.Next(0, i);
            return randomPlayer;


        }
    }
}
