using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzhee
{
  public class TeerlingModel
  {
    private int aantalOgen;
    private bool colorIsRed = false;


    private string teerlingLabelText = "";

    public string TeerlingLabelText
    {
      get { return teerlingLabelText; }
      set { teerlingLabelText = value; }
    }

    public int AantalOgen
    {
      get { return aantalOgen; }
      set { aantalOgen = value; }
    }

    public bool ColorIsRed
    {
      get { return colorIsRed; }
      set { colorIsRed = value; }
    }
  }
}
