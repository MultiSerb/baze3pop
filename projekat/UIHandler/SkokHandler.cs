using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.DTO.Zadatak5;
using Zadatak.Service;

namespace Zadatak.UIHandler
{
    public class SkokHandler
    {
        static readonly SkokService skokService = new SkokService();

        public void HandleMenu()
        {
            String answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite opciju:");
                Console.WriteLine("1 - Promena bodova za vetar");
                Console.WriteLine("X - Izlaz");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        Update();
                        break;

                }

            } while (!answer.ToUpper().Equals("X"));
        }

        private void Update()
        {
            Console.WriteLine("Unesite id skoka: ");
            string id = Console.ReadLine();
            
            double bodovi = 0;
            string read;
            do
            {
                Console.WriteLine("Unesite bodove za vetar: ");
                read = Console.ReadLine();
            } while (!double.TryParse(read, out bodovi));

            Zadatak5DTO zadatak5 = skokService.UpdateBVetar(id, bodovi);
            if(zadatak5 != null)
            {
                Console.WriteLine("Bodovi za skok " + id + " su promenjeni");
                if(zadatak5.uneto)
                    Console.WriteLine("Skakac sa IDem {0} je podigao svoj rekord sa {1} na {2}"
                        , zadatak5.id, zadatak5.oldPoints, zadatak5.newPoints);
            }
            else
            {
                Console.WriteLine("Nije azurirano nijedno polje");
            }
        }
    }
}
