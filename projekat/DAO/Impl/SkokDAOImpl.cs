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
    public class SkokDAOImpl : ISkokDAO
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Delete(Skok entity)
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

        public IEnumerable<Skok> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skok> FindAllById(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        public Skok FindById(string id)
        {
            throw new NotImplementedException();
        }

        public int GetIdSCFromIdSK(string id)
        {
            string query = "select idsc from skok where idsk = :id";

            using (IDbConnection connection = ConnectionUtil.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.String, 4);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "id", id);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public List<Skok> GetJumpsFromIdSA(string id)
        {
            List<Skok> ret = new List<Skok>();
            string query = "select * from skok where idsa = :id";
            using (IDbConnection connection = ConnectionUtil.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.String, 6);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "id", id);

                    using (IDataReader r = command.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            ret.Add(new Skok(r.GetString(0), r.IsDBNull(1) ? 0 : r.GetInt32(1), r.IsDBNull(2) ? "" : r.GetString(2),
                                r.IsDBNull(3) ? 0 : r.GetDouble(3), r.IsDBNull(4) ? 0 : r.GetDouble(4),
                                r.IsDBNull(5) ? 0 : r.GetDouble(5)));
                        }
                    }
                }
            }
            return ret;
        }

        public List<Skok> GetJumpsFromIdSAAndIdSC(List<string> idSA, List<int> idSC)
        {
            List<Skok> ret = new List<Skok>();
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from skok where idsa in(");
            int i = 0;
            foreach (string id in idSA)
                sb.Append(":id" + i++ + ",");
            
            sb.Remove(sb.Length - 1, 1);
            sb.Append(") and idsc in(");
            foreach (int id in idSC)
                sb.Append(":id" + i++ + ",");
            sb.Remove(sb.Length - 1, 1);
            sb.Append(")");
            using (IDbConnection connection = ConnectionUtil.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sb.ToString();
                    i = 0;
                    foreach (string id in idSA)
                        ParameterUtil.AddParameter(command, "id" + i++, DbType.String, 6);
                    foreach (int id in idSC)
                        ParameterUtil.AddParameter(command, "id" + i++, DbType.Int32);
                    command.Prepare();
                    i = 0;
                    foreach (string id in idSA)
                        ParameterUtil.SetParameterValue(command, "id" + i++, id);
                    foreach (int id in idSC)
                        ParameterUtil.SetParameterValue(command, "id" + i++, id);

                    using (IDataReader r = command.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            ret.Add(new Skok(r.GetString(0), r.IsDBNull(1) ? 0 : r.GetInt32(1), r.IsDBNull(2) ? "" : r.GetString(2),
                                r.IsDBNull(3) ? 0 : r.GetDouble(3), r.IsDBNull(4) ? 0 : r.GetDouble(4),
                                r.IsDBNull(5) ? 0 : r.GetDouble(5)));
                        }
                    }
                }
            }
            return ret;
        }

        public int GetNumOfDistJumpersFromJumps(List<Skok> skokovi)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select count(distinct idsc) from skok where idsk in(");
            foreach (Skok skok in skokovi)
                sb.Append(":id" + skok.IdSK + ",");
            sb.Remove(sb.Length - 1, 1);
            sb.Append(")");
            using (IDbConnection connection = ConnectionUtil.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sb.ToString();
                    foreach (Skok skok in skokovi)
                        ParameterUtil.AddParameter(command, "id" + skok.IdSK, DbType.String, 4);
                    command.Prepare();
                    foreach (Skok skok in skokovi)
                        ParameterUtil.SetParameterValue(command, "id" + skok.IdSK, skok.IdSK);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public int Save(Skok entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<Skok> entities)
        {
            throw new NotImplementedException();
        }

        public double SumPoints(string id)
        {
            string query = "select bduzina + bstil + bvetar from skok where idsk = :id";

            using (IDbConnection connection = ConnectionUtil.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.String, 4);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "id", id);

                    return Convert.ToDouble(command.ExecuteScalar());
                }
            }
        }
        public int UpdateBVetar(string id, double bvetar)
        {
            string update = "update skok set bvetar = :bvetar where idsk = :id";
            using (IDbConnection connection = ConnectionUtil.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = update;
                    ParameterUtil.AddParameter(command, "bvetar", DbType.Double);
                    ParameterUtil.AddParameter(command, "id", DbType.String, 4);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "bvetar", bvetar);
                    ParameterUtil.SetParameterValue(command, "id", id);

                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
