using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Model;

namespace Zadatak.DTO.Zadatak3
{
    public class Zadatak3DTO
    {

        public Zadatak3DTO()
        {

        }

        public Zadatak3DTO(List<Skok> skokovi, int brojRazlicitihSkakaca)
        {
            Skokovi = skokovi;
            BrojRazlicitihSkakaca = brojRazlicitihSkakaca;
        }

        public List<Skok> Skokovi { get; set; }
        public int BrojRazlicitihSkakaca { get; set; }
    }
}
