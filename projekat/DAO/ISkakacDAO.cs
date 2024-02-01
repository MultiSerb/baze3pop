using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Model;

namespace Zadatak.DAO
{
    public interface ISkakacDAO : ICRUDDAO<Skakac, int>
    {
        List<int> GetIdSCFromIdD(string id);
        double GetPointsById(int id);
        int UpdatePbSC(int id, double points);
    }
}
