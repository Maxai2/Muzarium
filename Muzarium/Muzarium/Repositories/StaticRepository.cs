using Muzarium.Common;
using Muzarium.Interface;
using Muzarium.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzarium.Repositories
{
    public class StaticRepository : IStaticRepository
    {
        private string _connectionString;
        private DbProviderFactory _factory;
        private DbConnection _connection;
        private DataProvider instance = DataProvider.GetInstance();

        private ConnectionStringSettings constr = DataProvider.GetInstance().AcademyConnection();

        public List<Quests> quests;
        //-------------------------------------------------------------------------------
        public StaticRepository()
        {
            _connectionString = constr.ConnectionString;
            _factory = DbProviderFactories.GetFactory(constr.ProviderName);
        }
        //-------------------------------------------------------------------------------
        public bool OpenConnection()
        {
            try
            {
                _connection = _factory.CreateConnection();
                _connection.ConnectionString = _connectionString;
                _connection.Open();

                return true;
            }
            catch (DbException)
            {
                return false;
            }
        }
        //-------------------------------------------------------------------------------
        public void CloseConnection()
        {
            if (_connection != null)
                _connection.Close();
        }
        //-------------------------------------------------------------------------------
        public Statics AddStatic(Statics @static)
        {
            try
            {
                DbCommand command = _factory.CreateCommand();

                command.CommandText = "INSERT INTO Prizes (PrizeName, PictureSrc) VALUES (@PrizeName, @PictureSrc)";

                command.Parameters.Add(instance.GetParameter("PrizeName", prize.PrizeName, _factory));
                command.Parameters.Add(instance.GetParameter("PictureSrc", prize.PictureSrc, _factory));

                command.ExecuteNonQuery();

                prize.Id = instance.GetNewId("Prizes", _connection);
                prizes.Add(prize);
                return prize;
            }
            catch (DbException)
            {
                return null;
            }
        }
        //-------------------------------------------------------------------------------
        public Statics GetStaticById(int id)
        {
            try
            {
                DbCommand command = _factory.CreateCommand();
                command.CommandText = "SELECT * FROM Prizes WHERE Id = @id";

                command.Parameters.Add(instance.GetParameter("id", id, _factory));

                DbDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Prizes prize = new Prizes();

                    prize.Id = Convert.ToInt32(reader["Id"]);
                    prize.PictureSrc = Convert.ToString(reader["PictureSrc"]);
                    prize.PrizeName = Convert.ToString(reader["PrizeName"]);

                    return prize;
                }

                return null;
            }
            catch (DbException)
            {
                return null;
            }
        }
        //-------------------------------------------------------------------------------
        public List<Statics> GetStatics()
        {
            try
            {
                DbCommand command = _factory.CreateCommand();

                command.CommandText = "SELECT * FROM Prizes";

                DbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Prizes prize = new Prizes();

                    prize.Id = Convert.ToInt32(reader["Id"]);
                    prize.PictureSrc = Convert.ToString(reader["PictureSrc"]);
                    prize.PrizeName = Convert.ToString(reader["PrizeName"]);

                    prizes.Add(prize);
                }

                return prizes;
            }
            catch (DbException)
            {
                return null;
            }
        }
        //-------------------------------------------------------------------------------
        public Statics UpdateStatic(int id, Statics @static)
        {
            try
            {
                DbCommand command = _factory.CreateCommand();
                command.CommandText = "UPDATE Prizes SET PictureSrc = @PictureSrc, PrizeName = @PrizeName";

                command.Parameters.Add(instance.GetParameter("PictureSrc", prize.PictureSrc, _factory));
                command.Parameters.Add(instance.GetParameter("PrizeName", prize.PrizeName, _factory));

                command.ExecuteNonQuery();

                prizes[i].PictureSrc = prize.PictureSrc;
                prizes[i].PrizeName = prize.PrizeName;

                return prize;
            }
            catch (DbException)
            {
                return null;
            }
        }
    }
}
