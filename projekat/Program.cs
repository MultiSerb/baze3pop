using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.UIHandler;

namespace Zadatak
{
    class Program
    {
        static readonly MainHandler mainHandler = new MainHandler();
        static void Main(string[] args)
        {
            mainHandler.HandleMainMenu();
        }
    }
}
