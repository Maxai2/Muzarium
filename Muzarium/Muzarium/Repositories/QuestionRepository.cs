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
    public class QuestionRepository : IQuestionRepository
    {
        private string _connectionString;
        private DbProviderFactory _factory;
        private DbConnection _connection;
        private ConnectionStringSettings constr = DataProvider.GetInstance().AcademyConnection();

        public List<Questions> questions;

        public QuestionRepository()
        {
            _connectionString = constr.ConnectionString;
            _factory = DbProviderFactories.GetFactory(constr.ProviderName);
        }

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

        public void CloseConnection()
        {
            if (_connection != null)
                _connection.Close();
        }

        public List<Questions> GetQuestions(int id)
        {
            try
            {
                DbCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM Questions JOIN Quests ON Questions.QuestId = Quest.Id WHERE Quest.Id = @id";

                DbParameter parameter = _factory.CreateParameter();
                parameter.ParameterName = "id";
                parameter.Value = id;
                command.Parameters.Add(parameter);

                DbDataReader reader = command.ExecuteReader();
                List<Questions> questions = new List<Questions>();

                while (reader.Read())
                {
                    Questions question = new Questions();

                    question.Description = Convert.ToString(reader["Description"]);
                    question.PictureSrc = Convert.ToString(reader["PictureSrc"]);
                    question.Points = Convert.ToInt32(reader["Points"]);
                    question.Hint = Convert.ToString(reader["Hint"]);
                    question.QuestionType = Convert.ToInt32(reader["QuestionType"]);
                    question.QuestId = Convert.ToInt32(reader["QuestId"]);

                    questions.Add(question);
                }

                reader.Close();
                return questions;
            }
            catch (DbException)
            {
                return null;
            }
        }

        public Questions AddQuestion(Questions question)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllQustion(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteQuestion(int id)
        {
            throw new NotImplementedException();
        }


        public Questions UpdateQuestion(int id, Questions question)
        {
            throw new NotImplementedException();
        }
    }
}
