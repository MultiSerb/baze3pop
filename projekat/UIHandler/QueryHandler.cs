using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.DTO.Zadatak3;
using Zadatak.DTO.Zadatak4;
using Zadatak.DTO.Zadatak6;
using Zadatak.Model;
using Zadatak.Service;

namespace Zadatak.UIHandler
{
    public class QueryHandler
    {
        static readonly QueryService queryService = new QueryService();

        public void HandleQueryMenu()
        {
            string unos = "";
            do
            {
                Console.WriteLine("\n1 - Zadatak 3. Tekst:\n" +
                    "Implementirati izveštaj koji će za uneti IDSA (identifikaciona oznaka skakaonice) prikazati" +
                    " sve skokove koji su vršeni na skakaonici sa tim IDSA.\nNakon liste skokova, " +
                    "prikazati i broj različitih skakača koji su izvodili te skokove.");
                Console.WriteLine("2 - Zadatak 4. Tekst:\nImplementirati izveštaj koji će prikazati podatke o svakoj državi. " +
                    "\nZa svaku državu treba prikazati i sve skokove koje su skakači iz te države izvodili na" +
                    "skakaonicama iz te iste države.");
                Console.WriteLine("3 - Zadatak 6. Tekst: \n Implementirati izveštaj koji će za unete granice dužine skakaonice (minimalna i maksimalna dužina) prikazati sve " +
                    "skakaonice čija je dužina između zadatih granica. Za svaku od ovih skakaonica prikazati" +
                    " i naziv države u kojoj se skakaonica nalazi.");


                Console.WriteLine("X - izlaz\n");

                unos = Console.ReadLine();
                switch (unos)
                {
                    case "1":
                        Zadatak3();
                        break;
                    case "2":
                        Zadatak4();
                        break;
                    case "3":
                        Zadatak6();
                        break;
                }
            } while (!unos.ToLower().Equals("x"));
        }

        private void Zadatak6()
        {
            int lb = 0;
            string read;
            do
            {
                Console.WriteLine("Unesite donju granicu: ");
                read = Console.ReadLine();
            } while (!int.TryParse(read, out lb));

            int hb = 0;
            do
            {
                Console.WriteLine("Unesite gornju granicu: ");
                read = Console.ReadLine();
            } while (!int.TryParse(read, out hb));

            if (lb > hb)
            {
                Console.WriteLine("Donja granica mora biti manja od gornje granice");
                return;
            }
            List<Zadatak6DTO> zadatak6 = queryService.GetZadatak6(lb, hb);
            if (zadatak6.Count != 0)
            {
                Console.WriteLine(Skakaonica.GetHeader() + string.Format("{0,-30}", "NAZIV DRZAVE"));
                foreach (Zadatak6DTO z in zadatak6)
                    Console.WriteLine(z.skakaonica + string.Format("{0,-30}", z.drzava.NazivD));
            }
            else
                Console.WriteLine("Ne postoje takve skakaonice");
        }

        private void Zadatak4()
        {
            List<Zadatak4DTO> zadatak4 = queryService.GetZadatak4();
            if(zadatak4.Count != 0)
                foreach (Zadatak4DTO zad in zadatak4)
                {
                    Console.WriteLine(Drzava.GetHeader());
                    Console.WriteLine(zad.Drzava);

                    if (zad.Skokovi.Count != 0)
                    {
                        Console.WriteLine("\t" + Skok.GetHeader());
                        foreach (Skok skok in zad.Skokovi)
                            Console.WriteLine("\t" + skok);
                    }
                    else
                        Console.WriteLine("\tNema skakaca koji zadovoljavaju uslove pretrage");
                    Console.WriteLine("\n");
                }
            else
                Console.WriteLine("Nemamo drzave");
        }

        private void Zadatak3()
        {
            Console.WriteLine("Unesite ID skakaonice: ");
            string id = Console.ReadLine();

            Zadatak3DTO dto = queryService.GetZadatak3(id);
            if (dto.Skokovi.Count != 0)
            {
                Console.WriteLine("---------------------------------------------------------------SKOKOVI ZA " + id + "---------------------------------------------------------------");
                Console.WriteLine(Skok.GetHeader());
                foreach (Skok skok in dto.Skokovi)
                {
                    Console.WriteLine(skok);
                }
                Console.WriteLine("Broj razlicitih skakaca: " + dto.BrojRazlicitihSkakaca);
                Console.WriteLine("\n");
            }
            else
                Console.WriteLine("Ne postoje skokovi za ovu skakaonicu");
        }
    }
}
