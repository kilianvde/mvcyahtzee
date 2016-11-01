//?
using System;

namespace Yahtzee
{
    public class PlayerModel
    {
        private bool isPlayerOneActive = true;

        public bool IsPlayerOneActive
        {
            get { return isPlayerOneActive; }
            set { isPlayerOneActive = value; }
        }
    }
}