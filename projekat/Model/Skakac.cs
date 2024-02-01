using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak.Model
{
    public class Skakac
    {
        public int IdSC { get; set; }
        public string ImeSC { get; set; }
        public string PrzSC { get; set; }
        public string IdD { get; set; }
        public int Titule { get; set; }
        public double PbSC { get; set; }
        public Skakac()
        {

        }

        public Skakac(int idSC, string imeSC, string przSC, string idD, int titule, double pbSC)
        {
            IdSC = idSC;
            ImeSC = imeSC;
            PrzSC = przSC;
            IdD = idD;
            Titule = titule;
            PbSC = pbSC;
        }
    }
}
