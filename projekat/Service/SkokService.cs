using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.DAO;
using Zadatak.DAO.Impl;
using Zadatak.DTO.Zadatak5;

namespace Zadatak.Service
{
    public class SkokService
    {
        private static readonly ISkokDAO skokDAO = new SkokDAOImpl();
        private static readonly ISkakacDAO skakacDAO = new SkakacDAOImpl();

        public Zadatak5DTO UpdateBVetar(string id, double bvetar)
        {
            Zadatak5DTO ret = null;
            int res = skokDAO.UpdateBVetar(id, bvetar);
            if (res != 0)
            {
                ret = new Zadatak5DTO(0, 0, 0, false);
                double newPoints = skokDAO.SumPoints(id);
                int skakacId = skokDAO.GetIdSCFromIdSK(id);
                double oldPoints = skakacDAO.GetPointsById(skakacId);
                if (newPoints > oldPoints)
                    if (skakacDAO.UpdatePbSC(skakacId, newPoints) != 0)
                        ret = new Zadatak5DTO(newPoints, oldPoints, skakacId, true);
            }
            return ret;
        }
    }
}
