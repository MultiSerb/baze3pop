using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Model;

namespace Zadatak.DAO
{
    public interface ISkokDAO : ICRUDDAO<Skok, string>
    {
        List<Skok> GetJumpsFromIdSA(string id);
        int GetNumOfDistJumpersFromJumps(List<Skok> skokovi);
        List<Skok> GetJumpsFromIdSAAndIdSC(List<string> idSA, List<int> idSC);
        int UpdateBVetar(string id, double bvetar);
        double SumPoints(string id);
        int GetIdSCFromIdSK(string id);
    }
}
