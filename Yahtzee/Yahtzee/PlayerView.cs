//K
using System.Windows.Forms;

namespace Yahtzee
{
    public partial class PlayerView : UserControl
    {
        private PlayerController plrCtrl;

        //Always define parameter vars with prefix 'p' for housekeepi,ng
        public PlayerView(PlayerController pPlrCtrl)
        {
            InitializeComponent();
            plrCtrl = pPlrCtrl;
        }
    }
}
