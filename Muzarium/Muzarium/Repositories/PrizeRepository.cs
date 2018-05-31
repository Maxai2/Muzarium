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
    public class PrizeRepository : IPrizeRepository
    {
        private string _connectionString;
        private DbProviderFactory _factory;
        private DbConnection _connection;
        private ConnectionStringSettings constr = DataProvider.GetInstance().AcademyConnection();

        private DataProvider instance = DataProvider.GetInstance();

        public List<Prizes> prizes;
        //-------------------------------------------------------------------------------
        public PrizeRepository()
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
        public Prizes AddPrize(Prizes prize)
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
        public bool DeletePrize(int id)
        {
            try
            {
                DbCommand command = _factory.CreateCommand();
                command.CommandText = "DELETE FROM Prizes WHERE Id = @id";

                command.Parameters.Add(instance.GetParameter("id", id, _factory));

                command.ExecuteNonQuery();

                var item = prizes.FirstOrDefault(i => i.Id == id);
                prizes.Remove(item);

                return true;
            }
            catch (DbException)
            {
                return false;
            }
        }
        //-------------------------------------------------------------------------------
        public Prizes GetPrizeById(int id)
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
        public List<Prizes> GetPrizes()
        {
            throw new NotImplementedException();
        }
        //-------------------------------------------------------------------------------
        public Prizes UpdatePrize(int id, Prizes prize)
        {
            throw new NotImplementedException();
        }
    }
}
