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
    public partial class PlayerView : UserControl
    {

        private PlayerController controller;

        

        public PlayerView(PlayerController c)
        {
            InitializeComponent();
            controller = c;
        }


        public PlayerView()
        {
            InitializeComponent();
        }

        
    }
}
