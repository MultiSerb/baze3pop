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
    public class SkakacDAOImpl : ISkakacDAO
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Delete(Skakac entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skakac> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skakac> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Skakac FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<int> GetIdSCFromIdD(string id)
        {
            string query = "select idsc from skakac where idd = :id";
            List<int> ret = new List<int>();
            using (IDbConnection connection = ConnectionUtil.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.String, 3);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "id", id);

                    using (IDataReader r = command.ExecuteReader())
                    {
                        while (r.Read())
                            ret.Add(r.GetInt32(0));
                    }
                }
            }
            return ret;
        }

        public double GetPointsById(int id)
        {
            string query = "select pbsc from skakac where idsc = :id";
            using (IDbConnection connection = ConnectionUtil.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "id", id);

                    return Convert.ToDouble(command.ExecuteScalar());
                }
            }
        }

        public int Save(Skakac entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<Skakac> entities)
        {
            throw new NotImplementedException();
        }

        public int UpdatePbSC(int id, double points)
        {
            string query = "update skakac set pbsc = :pbsc where idsc = :id";
            using (IDbConnection connection = ConnectionUtil.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "pbsc", DbType.Double);
                    ParameterUtil.AddParameter(command, "id", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "pbsc", points);
                    ParameterUtil.SetParameterValue(command, "id", id);

                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
