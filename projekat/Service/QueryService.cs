using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.DAO;
using Zadatak.DAO.Impl;
using Zadatak.DTO.Zadatak3;
using Zadatak.DTO.Zadatak4;
using Zadatak.DTO.Zadatak6;
using Zadatak.Model;

namespace Zadatak.Service
{
    public class QueryService
    {
        static readonly ISkokDAO skokDAO = new SkokDAOImpl();
        static readonly IDrzavaDAO drzavaDAO = new DrzavaDAOImpl();
        static readonly ISkakacDAO skakacDAO = new SkakacDAOImpl();
        static readonly ISkakaonicaDAO skakaonicaDAO = new SkakaonicaDAOImpl();

        //Zadatak 3
        public Zadatak3DTO GetZadatak3(string idSA)
        {
            Zadatak3DTO ret = new Zadatak3DTO();
            //svi skokovi
            ret.Skokovi = skokDAO.GetJumpsFromIdSA(idSA);
            //razliciti skakaci
            if(ret.Skokovi.Count != 0)
                ret.BrojRazlicitihSkakaca = skokDAO.GetNumOfDistJumpersFromJumps(ret.Skokovi);
            return ret;
        }

        //Zadatak 4
        public List<Zadatak4DTO> GetZadatak4()
        {
            List<Zadatak4DTO> ret = new List<Zadatak4DTO>();
            foreach (Drzava drzava in drzavaDAO.FindAll())
            {
                List<int> skakaci = skakacDAO.GetIdSCFromIdD(drzava.IdD);
                List<string> skakaonice = skakaonicaDAO.GetIdSAFromIdD(drzava.IdD);

                List<Skok> skokovi = new List<Skok>();
                if (skakaci.Count != 0 && skakaonice.Count != 0)
                    skokovi = skokDAO.GetJumpsFromIdSAAndIdSC(skakaonice, skakaci);

                ret.Add(new Zadatak4DTO(drzava, skokovi));
            }

            return ret;
        }

        //Zadatak 6
        public List<Zadatak6DTO> GetZadatak6(int lb, int hb)
        {
            List<Zadatak6DTO> ret = new List<Zadatak6DTO>();
            List<Skakaonica> skakaonice = skakaonicaDAO.GetSkakaonicaBetween(lb, hb);
            foreach (Skakaonica s in skakaonice)
                ret.Add(new Zadatak6DTO(s, drzavaDAO.FindById(s.IdD)));
            return ret;
        }
    }
}
