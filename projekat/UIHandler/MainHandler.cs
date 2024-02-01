using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak.UIHandler
{
    public class MainHandler
    {
        SkakaonicaHandler skakaonicaHandler = new SkakaonicaHandler();
        QueryHandler queryHandler = new QueryHandler();
        SkokHandler skokHandler = new SkokHandler();
        public void HandleMainMenu()
        {
            string answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite opciju:");
                Console.WriteLine("1 - Rukovanje skakaonicama");
                Console.WriteLine("2 - Azuriranje skokova");
                Console.WriteLine("3 - Upiti");
                Console.WriteLine("X - Izlazak iz programa");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        skakaonicaHandler.HandleMenu();
                        break;
                    case "2":
                        skokHandler.HandleMenu();
                        break;
                    case "3":
                        queryHandler.HandleQueryMenu();
                        break;
                }

            } while (!answer.ToUpper().Equals("X"));
        }
    }
}

