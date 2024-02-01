using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak.Model
{
    public class Skok
    {
        public Skok(string idSK, int idSC, string idSA, double bDuzina, double bStil, double bVetar)
        {
            IdSK = idSK;
            IdSC = idSC;
            IdSA = idSA;
            BDuzina = bDuzina;
            BStil = bStil;
            BVetar = bVetar;
        }
        public Skok()
        {

        }
        public string IdSK { get; set; }
        public int IdSC { get; set; }
        public string IdSA { get; set; }
        public double BDuzina { get; set; }
        public double BStil { get; set; }
        public double BVetar { get; set; }

        public override string ToString()
        {
            return string.Format("{0,-20} {1,-40} {2,-20} {3,-20} {4,-20} {5,-20}",
                IdSK, IdSC, IdSA, BDuzina, BStil, BVetar);
        }

        public static string GetHeader()
        {
            return string.Format("{0,-20} {1,-40} {2,-20} {3,-20} {4,-20} {5,-20}", "ID SKOKA",
                "ID SKAKACA", "ID SKAKAONICE", "BODOVI DUZINA", "BODOVI STIL", "BODOVI VETAR");
        }
    }
}
