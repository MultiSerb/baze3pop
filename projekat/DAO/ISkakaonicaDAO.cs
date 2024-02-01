using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Model;

namespace Zadatak.DAO
{
    public interface ISkakaonicaDAO : ICRUDDAO<Skakaonica, string>
    {
        List<string> GetIdSAFromIdD(string id);
        List<Skakaonica> GetSkakaonicaBetween(int lowerBoundry, int higherBoundry);
    }
}
