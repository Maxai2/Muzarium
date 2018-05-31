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
    public class QuestRepository : IQuestRepository
    {
        private string _connectionString;
        private DbProviderFactory _factory;
        private DbConnection _connection;
        private DataProvider instance = DataProvider.GetInstance();

        private ConnectionStringSettings constr = DataProvider.GetInstance().AcademyConnection();

        public List<Quests> quests;
        //-------------------------------------------------------------------------------
        public QuestRepository()
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
        public Quests AddQuest(Quests quest)
        {
            try
            {
                DbCommand command = _connection.CreateCommand();
                command.CommandText = "INSERT INTO Quests(Title, Description, Difficult, PictureSrc, Points, MuseumId, PrizesId) VALUES (@Title, @Description, @Difficult, @PictureSrc, @Points, @MuseumId, @PrizesId)";

                command.Parameters.Add(instance.GetParameter("Title", quest.Title, _factory));
                command.Parameters.Add(instance.GetParameter("Description", quest.Description, _factory));
                command.Parameters.Add(instance.GetParameter("Difficult", quest.Difficult, _factory));
                command.Parameters.Add(instance.GetParameter("PictureSrc", quest.PictureSrc, _factory));
                command.Parameters.Add(instance.GetParameter("Points", quest.Points, _factory));
                command.Parameters.Add(instance.GetParameter("MuseumId", quest.MuseumId, _factory));
                command.Parameters.Add(instance.GetParameter("PrizesId", quest.PrizesId, _factory));

                command.ExecuteNonQuery();

                quest.Id = instance.GetNewId("Quests", _connection);
                quests.Add(quest);
                return quest;
            }
            catch (DbException)
            {
                return null;
            }
        }
        //-------------------------------------------------------------------------------
        public bool DeleteAllQuests()
        {
            throw new NotImplementedException();
        }
        //-------------------------------------------------------------------------------
        public bool DeleteQuest(int id)
        {
            try
            {
                DbCommand command = _factory.CreateCommand();
                command.CommandText = "DELETE FROM Quests WHERE Id = @id";

                command.Parameters.Add(instance.GetParameter("id", id, _factory));

                command.ExecuteNonQuery();

                var item = quests.FirstOrDefault(i => i.Id == id);
                quests.Remove(item);

                return true;
            }
            catch (DbException)
            {
                return false;
            }
        }
        //-------------------------------------------------------------------------------
        public Quests GetQuestById(int id)
        {
            //try
            //{
            //    DbCommand command = _factory.CreateCommand();

            //    command.CommandText = "SELECT * FROM Quest WHERE Id = @id";

            //    command.Parameters.Add(instance.GetParameter("id", id, _factory));

            //    DbDataReader reader = command.ExecuteReader();


            //}
            //catch (DbException)
            //{

            //    throw;
            //}
            throw new NotImplementedException();
        }
        //-------------------------------------------------------------------------------
        public List<Quests> GetQuests()
        {
            throw new NotImplementedException();
        }
        //-------------------------------------------------------------------------------
        public Quests UpdateQuestById(int id, Quests quest)
        {
            throw new NotImplementedException();
        }
    }
}
