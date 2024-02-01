using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.DAO;
using Zadatak.DAO.Impl;
using Zadatak.Model;

namespace Zadatak.Service
{
    public class SkakaonicaService
    {
        private static readonly ISkakaonicaDAO skakaonicaDAO = new SkakaonicaDAOImpl();

        public int Count()
        {
            return skakaonicaDAO.Count();
        }

        public int Delete(Skakaonica entity)
        {
            return skakaonicaDAO.Delete(entity);
        }

        public int DeleteAll()
        {
            return skakaonicaDAO.DeleteAll();
        }

        public int DeleteById(string id)
        {
            return skakaonicaDAO.DeleteById(id);
        }

        public bool ExistsById(string id)
        {
            return skakaonicaDAO.ExistsById(id);
        }

        public List<Skakaonica> FindAll()
        {
            return skakaonicaDAO.FindAll().ToList();
        }

        public List<Skakaonica> FindAllById(IEnumerable<string> ids)
        {
            return skakaonicaDAO.FindAllById(ids).ToList();
        }

        public Skakaonica FindById(string id)
        {
            return skakaonicaDAO.FindById(id);
        }

        public int Save(Skakaonica entity)
        {
            return skakaonicaDAO.Save(entity);
        }

        public int SaveAll(IEnumerable<Skakaonica> entities)
        {
            return skakaonicaDAO.SaveAll(entities);
        }
    }
}
