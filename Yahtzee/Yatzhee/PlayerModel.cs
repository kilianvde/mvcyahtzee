using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzhee
{
    public class PlayerModel
    {
        private bool mPlayerOneActive = true;

        public bool PlayerOneActive
        {
            get { return mPlayerOneActive; }
            set { mPlayerOneActive = value; }
        }
    }
}
