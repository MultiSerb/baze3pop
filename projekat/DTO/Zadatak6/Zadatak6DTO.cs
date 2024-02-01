using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Model;

namespace Zadatak.DTO.Zadatak6
{
    public class Zadatak6DTO
    {
        public Zadatak6DTO(Skakaonica skakaonica, Drzava drzava)
        {
            this.skakaonica = skakaonica;
            this.drzava = drzava;
        }

        public Skakaonica skakaonica { get; set; }
        public Drzava drzava { get; set; }
    }
}
