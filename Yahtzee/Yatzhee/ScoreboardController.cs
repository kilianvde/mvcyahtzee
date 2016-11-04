using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzhee
{
    public class ScoreboardController
    {
        ScoreboardView view;
        
        public ScoreboardModel model;

        public ScoreboardView getView()
        {
            return view;

        }

        public void ResetAantalWorpen()
        {
          model.Score = 0;
        }

        public ScoreboardController()
        {
            //maak nieuwe instantie aan van view
            view = new ScoreboardView(this);
            
            model = new ScoreboardModel();
        }

        public void UpdateScore()
        {

        }

        public int TelAantalOgen(int n)
        {
            int aantal = 0;
            //   tel aantal keer dat n voorkomt en stop dat in aantal
            return aantal;
        }


        public void UpdateAantalWorpen()
        {
            int newScore = model.Score += 1;
            ScoreboardModel.Aantalworpen = newScore;
            view.UpdateScoreboard();
        }
    }
}
