using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Model;

namespace Zadatak.DTO.Zadatak5
{
    public class Zadatak5DTO
    {
        public double newPoints { get; set; }
        public double oldPoints { get; set; }
        public int id { get; set; }
        public bool uneto { get; set; }
        public Zadatak5DTO()
        {

        }

        public Zadatak5DTO(double newPoints, double oldPoints, int id, bool uneto)
        {
            this.newPoints = newPoints;
            this.oldPoints = oldPoints;
            this.id = id;
            this.uneto = uneto;
        }
    }
}
