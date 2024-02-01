using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak.Model
{
    public class Skakaonica
    {
        public Skakaonica(string idSA, string nazivSA, int duzinaSA, string tipSA, string idD)
        {
            IdSA = idSA;
            NazivSA = nazivSA;
            DuzinaSA = duzinaSA;
            TipSA = tipSA;
            IdD = idD;
        }
        public Skakaonica()
        {

        }
        public string IdSA { get; set; }
        public string NazivSA { get; set; }
        public int DuzinaSA { get; set; }
        public string TipSA { get; set; }
        public string IdD { get; set; }

        public static string GetHeader()
        {
            return string.Format("{0,-20} {1,-40} {2,-40} {3,-15} {4,-10}", "ID SKAKAONICE",
                "NAZIV SKAKAONICE", "DUZINA SKAKAONICE", "TIP SKAKAONICE", "ID DRZAVE");
        }

        public override string ToString()
        {
            return string.Format("{0,-20} {1,-40} {2,-40} {3,-15} {4,-10}", IdSA, NazivSA, DuzinaSA,
                TipSA, IdD);
        }
    }
}
