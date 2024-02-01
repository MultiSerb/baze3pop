using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Model;
using Zadatak.Service;

namespace Zadatak.UIHandler
{
    public class SkakaonicaHandler
    {
        private static readonly SkakaonicaService skakaonicaService = new SkakaonicaService();

        public void HandleMenu()
        {
            String answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite opciju za rad nad skakaonicama:");
                Console.WriteLine("1 - Prikaz svih");
                Console.WriteLine("2 - Prikaz po identifikatoru");
                Console.WriteLine("3 - Unos jedne skakaonice");
                Console.WriteLine("4 - Unos vise skakaonica");
                Console.WriteLine("5 - Izmena po identifikatoru");
                Console.WriteLine("6 - Brisanje po identifikatoru");
                Console.WriteLine("X - Izlazak iz rukovanja skakaonicama");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        ShowAll();
                        break;
                    case "2":
                        ShowById();
                        break;
                    case "3":
                        HandleSingleInsert();
                        break;
                    case "4":
                        HandleMultipleInserts();
                        break;
                    case "5":
                        HandleUpdate();
                        break;
                    case "6":
                        HandleDelete();
                        break;

                }

            } while (!answer.ToUpper().Equals("X"));
        }

        private void HandleDelete()
        {
            Console.WriteLine("ID skakaonice: ");
            string id = Console.ReadLine();
            try
            {
                int deleted = skakaonicaService.DeleteById(id);
                if(deleted != 0)
                    Console.WriteLine("Skakaonica sa šifrom {0} uspešno obrisana", id);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        bool losUnos(string s)
        {
            return s != "normalna" && s != "srednja" && s != "velika";
        }
        private void HandleUpdate()
        {
            Console.WriteLine("ID skakaonice: ");
            string id = Console.ReadLine();

            try
            {
                if (!skakaonicaService.ExistsById(id))
                {
                    Console.WriteLine("Ne postoji taj id");
                    return;
                }

                Console.WriteLine("Naziv skakaonice: ");
                string naziv = Console.ReadLine();

                
                int duzina = 0; 
                string read;
                do
                {
                    Console.WriteLine("Duzina skakaonice (broj): ");
                    read = Console.ReadLine();
                } while (!int.TryParse(read, out duzina));
                

                string tip;
                do
                {
                    Console.WriteLine("Tip skakaonice (normalna, srednja, velika): ");
                    tip = Console.ReadLine();
                } while (losUnos(tip));

                Console.WriteLine("ID drzave: ");
                string idd = Console.ReadLine();

                int updated = skakaonicaService.Save(new Skakaonica(id, naziv, duzina, tip, idd));
                if (updated != 0)
                    Console.WriteLine("Skakaonica \"{0}\" uspešno izmenjena.", naziv);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void HandleMultipleInserts()
        {
            List<Skakaonica> skakaonice = new List<Skakaonica>();
            string unos = "";
            do
            {
                Console.WriteLine("ID skakaonice: ");
                string id = Console.ReadLine();

                Console.WriteLine("Naziv skakaonice: ");
                string naziv = Console.ReadLine();

                int duzina = 0;
                string read;
                do
                {
                    Console.WriteLine("Duzina skakaonice (broj): ");
                    read = Console.ReadLine();
                } while (!int.TryParse(read, out duzina));

                string tip;
                do
                {
                    Console.WriteLine("Tip skakaonice (normalna, srednja, velika): ");
                    tip = Console.ReadLine();
                } while (losUnos(tip));
                Console.WriteLine("ID drzave: ");
                string idd = Console.ReadLine();

                skakaonice.Add(new Skakaonica(id, naziv, duzina, tip, idd));

                Console.WriteLine("Unesi još jednu skakaonicu? (ENTER za potvrdu, X za odustanak)");
                unos = Console.ReadLine();
            } while (!unos.ToLower().Equals("x"));

            try
            {
                int inserted = skakaonicaService.SaveAll(skakaonice);
                Console.WriteLine("Uspešno uneto {0} skakaonica.", inserted);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void HandleSingleInsert()
        {
            Console.WriteLine("ID skakaonice: ");
            string id = Console.ReadLine();

            Console.WriteLine("Naziv skakaonice: ");
            string naziv = Console.ReadLine();

            int duzina = 0;
            string read;
            do
            {
                Console.WriteLine("Duzina skakaonice (broj): ");
                read = Console.ReadLine();
            } while (!int.TryParse(read, out duzina));

            string tip;
            do
            {
                Console.WriteLine("Tip skakaonice (normalna, srednja, velika): ");
                tip = Console.ReadLine();
            } while (losUnos(tip));

            Console.WriteLine("ID drzave: ");
            string idd = Console.ReadLine();

            try
            {
                int inserted = skakaonicaService.Save(new Skakaonica(id, naziv, duzina, tip, idd));
                if (inserted != 0)
                    Console.WriteLine("Skakaonica \"{0}\" uspešno uneta.", naziv);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ShowById()
        {
            Console.WriteLine("ID skakaonice: ");
            string id = Console.ReadLine();

            try
            {
                Skakaonica skakaonica = skakaonicaService.FindById(id);
                Console.WriteLine(Skakaonica.GetHeader());
                Console.WriteLine(skakaonica);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ShowAll()
        {
            Console.WriteLine(Skakaonica.GetHeader());
            try
            {
                foreach (Skakaonica skakaonica in skakaonicaService.FindAll())
                    Console.WriteLine(skakaonica);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
