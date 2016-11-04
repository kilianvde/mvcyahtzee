using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzhee
{
  public class TeerlingController
  {
    //member die de view opvangt
    TeerlingView view;
    public TeerlingModel model;
    static Random rnd = new Random();

    public TeerlingController()
    {
      //maak nieuwe instantie aan van view
      view = new TeerlingView(this);
      model = new TeerlingModel();
    }

    //methode die de view van de teerling returnt
    public TeerlingView getView()
    {
      return view;

    }

    public void cheatButtonVisibility()
    {
      view.cheatButtonVisibility();
    }

    public int Werp()
    {
      int randomTeerlingNummer = rnd.Next(1, 7);
      model.AantalOgen = randomTeerlingNummer;
      return randomTeerlingNummer;
    }

    public void Fixated()
    {
      if (model.ColorIsRed)
      {
        model.ColorIsRed = false;
      }
      else
      {
        model.ColorIsRed = true;
      }
    }

    public void UpdateUI()
    {
      int nieuwAantalOgen = model.AantalOgen;

      model.TeerlingLabelText = nieuwAantalOgen.ToString();
      view.UpdateUI(nieuwAantalOgen);
    }
  }
}
