using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Model;

namespace Zadatak.DTO.Zadatak4
{
    public class Zadatak4DTO
    {
        public Zadatak4DTO()
        {

        }

        public Zadatak4DTO(Drzava drzava, List<Skok> skokovi)
        {
            Drzava = drzava;
            Skokovi = skokovi;
        }

        public Drzava Drzava { get; set; }
        public List<Skok> Skokovi { get; set; }

    }
}
