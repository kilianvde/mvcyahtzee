//aLL done ? , no ?
using System;

namespace Yahtzee
{
    public class PlayerController
    {
        public ScoreboardModel scoreboardModel;
        public PlayerView view;
        public PlayerModel plrModel;
        
        private static Random rnd = new Random();
        protected MainForm yahtzee;

        public PlayerView getView()
        {
            return view;

        }

        public PlayerController()
        {
            plrModel = new PlayerModel();
        }

        public int chooseRandomPlayer(int i)
        {
            int randomPlayer = rnd.Next(0, i);
            return randomPlayer;
        }

        public void SwitchPlayer()
        {
            if (plrModel.IsPlayerOneActive)
            {
                plrModel.IsPlayerOneActive = false;
            }
            else
            {
                plrModel.IsPlayerOneActive = true;
            }
        }
    }
}
