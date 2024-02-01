using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Connection;
using Zadatak.Model;
using Zadatak.Util;

namespace Zadatak.DAO.Impl
{
    public class DrzavaDAOImpl : IDrzavaDAO
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Delete(Drzava entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Drzava> FindAll()
        {
            List<Drzava> ret = new List<Drzava>();
            string query = "select * from drzava";
            using (IDbConnection connection = ConnectionUtil.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    using (IDataReader r = command.ExecuteReader())
                    {
                        while (r.Read())
                            ret.Add(new Drzava(r.GetString(0), r.GetString(1)));
                    }
                }
            }

            return ret;
        }

        public IEnumerable<Drzava> FindAllById(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        public Drzava FindById(string id)
        {
            using (IDbConnection connection = ConnectionUtil.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "select * from drzava where idd = :id";
                    ParameterUtil.AddParameter(command, "id", DbType.String, 3);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "id", id);

                    using (IDataReader r = command.ExecuteReader())
                    {
                        if (r.Read())
                            return new Drzava(r.GetString(0), r.GetString(1));
                        else
                            return null;
                    }
                }
            }
        }

        public int Save(Drzava entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<Drzava> entities)
        {
            throw new NotImplementedException();
        }
    }
}
