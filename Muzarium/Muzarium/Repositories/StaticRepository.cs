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

        public List<Statics> statics;
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

                command.CommandText = "INSERT INTO Statics (UserId, QuestId, IsCompleted, Points, Duration, [DateTime], PrizeId) VALUES (@UserId, @QuestId, @IsCompleted, @Points, @Duration, @DateTime, @PrizeId)";

                command.Parameters.Add(instance.GetParameter("UserId", @static.UserId, _factory));
                command.Parameters.Add(instance.GetParameter("QuestId", @static.QuestId, _factory));
                command.Parameters.Add(instance.GetParameter("IsCompleted", @static.IsCompleted, _factory));
                command.Parameters.Add(instance.GetParameter("Points", @static.Points, _factory));
                command.Parameters.Add(instance.GetParameter("Duration", @static.Duration, _factory));
                command.Parameters.Add(instance.GetParameter("DateTime", @static.DateTime, _factory));
                command.Parameters.Add(instance.GetParameter("PrizeId", @static.PrizeId, _factory));

                command.ExecuteNonQuery();

                @static.Id = instance.GetNewId("Statics", _connection);
                statics.Add(@static);
                return @static;
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
                command.CommandText = "SELECT * FROM Statics WHERE Id = @id";

                command.Parameters.Add(instance.GetParameter("id", id, _factory));

                DbDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Statics @static = new Statics();

                    @static.DateTime = Convert.ToDateTime(reader["DateTime"]);
                    @static.Duration = Convert.ToDateTime(reader["Duration"]);
                    @static.Id = Convert.ToInt32(reader["Id"]);
                    @static.IsCompleted = Convert.ToBoolean(reader["IsCompleted"]);
                    @static.Points = Convert.ToInt32(reader["Points"]);
                    @static.PrizeId = Convert.ToInt32(reader["PrizeId"]);
                    @static.QuestId = Convert.ToInt32(reader["QuestId"]);
                    @static.UserId = Convert.ToInt32(reader["UserId"]);

                    return @static;
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

                command.CommandText = "SELECT * FROM Statics";

                DbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Statics @static = new Statics();

                    @static.DateTime = Convert.ToDateTime(reader["DateTime"]);
                    @static.Duration = Convert.ToDateTime(reader["Duration"]);
                    @static.Id = Convert.ToInt32(reader["Id"]);
                    @static.IsCompleted = Convert.ToBoolean(reader["IsCompleted"]);
                    @static.Points = Convert.ToInt32(reader["Points"]);
                    @static.PrizeId = Convert.ToInt32(reader["PrizeId"]);
                    @static.QuestId = Convert.ToInt32(reader["QuestId"]);
                    @static.UserId = Convert.ToInt32(reader["UserId"]);

                    statics.Add(@static);
                }

                return statics;
            }
            catch (DbException)
            {
                return null;
            }
        }
        //-------------------------------------------------------------------------------
        public Statics UpdateStatic(int i, Statics @static)
        {
            try
            {
                DbCommand command = _factory.CreateCommand();
                command.CommandText = "UPDATE Statics SET UserId = @UserId, QuestId = @QuestId, IsCompleted = @IsCompleted, Points = @Points, Duration = @Duration, [DateTime] = @DateTime, PrizeId = @PrizeId";

                command.Parameters.Add(instance.GetParameter("UserId", @static.UserId, _factory));
                command.Parameters.Add(instance.GetParameter("QuestId", @static.QuestId, _factory));
                command.Parameters.Add(instance.GetParameter("IsCompleted", @static.IsCompleted, _factory));
                command.Parameters.Add(instance.GetParameter("Points", @static.Points, _factory));
                command.Parameters.Add(instance.GetParameter("Duration", @static.Duration, _factory));
                command.Parameters.Add(instance.GetParameter("DateTime", @static.DateTime, _factory));
                command.Parameters.Add(instance.GetParameter("PrizeId", @static.PrizeId, _factory));

                command.ExecuteNonQuery();

                statics[i].DateTime = @static.DateTime;
                statics[i].Duration = @static.Duration;
                statics[i].IsCompleted = @static.IsCompleted;
                statics[i].Points = @static.Points;
                statics[i].PrizeId = @static.PrizeId;
                statics[i].QuestId = @static.QuestId;
                statics[i].UserId = @static.UserId;

                return @static;
            }
            catch (DbException)
            {
                return null;
            }
        }
    }
}