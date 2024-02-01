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
    public class SkakaonicaDAOImpl : ISkakaonicaDAO
    {
        public int Count()
        {
            string query = "select count(*) from skakaonica";
            using (IDbConnection connection = ConnectionUtil.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    return Convert.ToInt32(command.ExecuteScalar()); // execute scalar samo prvi element prvog reda 
                }
            }
        }

        public int Delete(Skakaonica entity)
        {
            return DeleteById(entity.IdSA);
        }

        public int DeleteAll()
        {
            string query = "delete from skakaonica";
            using (IDbConnection connection = ConnectionUtil.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare(); //execute reader cita redom iz tabele

                    return command.ExecuteNonQuery();// cuva,brise i operacije sa bazom
                }
            }
        }

        public int DeleteById(string id)
        {
            string query = "delete from skakaonica where idsa = :id";
            using (IDbConnection connection = ConnectionUtil.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.String, 6);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "id", id);

                    return command.ExecuteNonQuery();
                }
            }
        }

        public bool ExistsById(string id)
        {
            string query = "select * from skakaonica where idsa = :id";
            using (IDbConnection connection = ConnectionUtil.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.String, 6);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "id", id);

                    return command.ExecuteScalar() != null;
                }
            }
        }

        public IEnumerable<Skakaonica> FindAll()
        {
            List<Skakaonica> ret = new List<Skakaonica>();
            string query = "select * from skakaonica";
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
                            ret.Add(new Skakaonica(r.GetString(0), r.GetString(1), r.IsDBNull(2) ? 0 : r.GetInt32(2),
                                r.IsDBNull(3) ? "" : r.GetString(3), r.GetString(4)));
                    }
                }
            }
            return ret;
        }

        public IEnumerable<Skakaonica> FindAllById(IEnumerable<string> ids)
        {
            List<Skakaonica> ret = new List<Skakaonica>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select * from skakaonica where idsa in(");
            foreach (string id in ids)
                sb.Append(":id" + id + ",");
            
            sb.Remove(sb.Length - 1, 1);//sklanja zadnji zarez
            sb.Append(")");

            using (IDbConnection connection = ConnectionUtil.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sb.ToString();
                    foreach (string id in ids)
                        ParameterUtil.AddParameter(command, "id" + id, DbType.String, 6);
                    command.Prepare();
                    foreach (string id in ids)
                        ParameterUtil.SetParameterValue(command, "id" + id, id);

                    using (IDataReader r = command.ExecuteReader())
                    {
                        while (r.Read())
                            ret.Add(new Skakaonica(r.GetString(0), r.GetString(1), r.IsDBNull(2) ? 0 : r.GetInt32(2),
                                r.IsDBNull(3) ? "" : r.GetString(3), r.GetString(4)));
                    }
                }
            }
            return ret;
        }

        public Skakaonica FindById(string id)
        {
            string query = "select * from skakaonica where idsa = :id";

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
                        if (r.Read())
                            return new Skakaonica(r.GetString(0), r.GetString(1), r.IsDBNull(2) ? 0 : r.GetInt32(2),
                                r.IsDBNull(3) ? "" : r.GetString(3), r.GetString(4));
                        else
                            return null;
                    }
                }
            }
        }

        public int Save(Skakaonica entity)
        {
            using (IDbConnection connection = ConnectionUtil.GetConnection())
            {
                connection.Open();
                return Save(entity, connection);
            }
        }

        public int SaveAll(IEnumerable<Skakaonica> entities)
        {
            using (IDbConnection connection = ConnectionUtil.GetConnection())
            {
                connection.Open();
                IDbTransaction transaction = connection.BeginTransaction(); // transakcije nad bazom se rade 
                int saved = 0;                                               //kada imamo vise sekvencijalnih
                                                                        //podataka koji se unose u bazu 
                                                                        //i ako jedan bude los,svi se vracaju 
                                                                        //pre transakcije
                foreach (Skakaonica skakaonica in entities)
                    saved += Save(skakaonica, connection);
                transaction.Commit(); //transkacija se prekida

                return saved;
            }
        }

        int Save(Skakaonica skakaonica, IDbConnection connection)
        {
            string insert = "insert into skakaonica (nazivsa, duzinasa, tipsa, idd, idsa) " +
                "values(:nazivsa, :duzinasa, :tipsa, :idd, :idsa)";
            string update = "update skakaonica set nazivsa = :nazivsa, duzinasa = :duzinasa," +
                "tipsa = :tipsa, idd = :idd where idsa = :idsa";

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = ExistsById(skakaonica.IdSA, connection) ? update : insert;

                ParameterUtil.AddParameter(command, "nazivsa", DbType.String, 35);
                ParameterUtil.AddParameter(command, "duzinasa", DbType.Int32);
                ParameterUtil.AddParameter(command, "tipsa", DbType.String, 10);
                ParameterUtil.AddParameter(command, "idd", DbType.String, 3);
                ParameterUtil.AddParameter(command, "idsa", DbType.String, 6);
                command.Prepare();

                ParameterUtil.SetParameterValue(command, "nazivsa", skakaonica.NazivSA);
                ParameterUtil.SetParameterValue(command, "duzinasa", skakaonica.DuzinaSA);
                ParameterUtil.SetParameterValue(command, "tipsa", skakaonica.TipSA);
                ParameterUtil.SetParameterValue(command, "idd", skakaonica.IdD);
                ParameterUtil.SetParameterValue(command, "idsa", skakaonica.IdSA);

                return command.ExecuteNonQuery();
            }
        }

        bool ExistsById(string id, IDbConnection connection)
        {
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = "select * from skakaonica where idsa = :id";
                ParameterUtil.AddParameter(command, "id", DbType.String, 6);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "id", id);

                return command.ExecuteScalar() != null;
            }
        }

        public List<string> GetIdSAFromIdD(string id)
        {
            List<string> ret = new List<string>();
            string query = "select idsa from skakaonica where idd = :id";

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
                            ret.Add(r.GetString(0));
                    }
                }
            }
            return ret;
        }

        public List<Skakaonica> GetSkakaonicaBetween(int lowerBoundry, int higherBoundry)
        {
            List<Skakaonica> ret = new List<Skakaonica>();
            using (IDbConnection connection = ConnectionUtil.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "select * from skakaonica where duzinasa " +
                        "between :lb and :hb";
                    ParameterUtil.AddParameter(command, "lb", DbType.Int32);
                    ParameterUtil.AddParameter(command, "hb", DbType.Int32);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "lb", lowerBoundry);
                    ParameterUtil.SetParameterValue(command, "hb", higherBoundry);

                    using (IDataReader r = command.ExecuteReader())
                    {
                        while (r.Read())
                            ret.Add(new Skakaonica(r.GetString(0), r.GetString(1), r.GetInt32(2),
                                r.IsDBNull(3) ? "" : r.GetString(3) , r.GetString(4)));
                    }
                }
            }
            return ret;
        }
    }
}
