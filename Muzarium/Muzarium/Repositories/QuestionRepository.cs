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
using System.Windows;

namespace Muzarium.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private string _connectionString;
        private DbProviderFactory _factory;
        private DbConnection _connection;
        private DataProvider instance = DataProvider.GetInstance();

        private ConnectionStringSettings constr = DataProvider.GetInstance().AcademyConnection();

        public List<Questions> questions;
        //-------------------------------------------------------------------------------
        public QuestionRepository()
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
        public void GetQuestions(int QuestId)
        {
            try
            {
                DbCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM Questions JOIN Quests ON Questions.QuestId = Quest.Id WHERE Quest.Id = @id";

                DbParameter parameter = _factory.CreateParameter();
                parameter.ParameterName = "id";
                parameter.Value = QuestId;
                command.Parameters.Add(parameter);

                DbDataReader reader = command.ExecuteReader();

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
            }
            catch (DbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //-------------------------------------------------------------------------------
        public Questions AddQuestion(Questions question)
        {
            try
            {
                DbCommand command = _connection.CreateCommand();
                command.CommandText = "INSERT INTO Questions(Description, PictureSrc, Points, Hint, QuestionType, QuestId) VALUES (@Description, @PictureSrc, @Points, @Hint, @QuestionType, @QuestId)";

                command.Parameters.Add(instance.GetParameter("Description", question.Description, _factory));
                command.Parameters.Add(instance.GetParameter("PictureSrc", question.PictureSrc, _factory));
                command.Parameters.Add(instance.GetParameter("Points", question.Points, _factory));
                command.Parameters.Add(instance.GetParameter("Hint", question.Hint, _factory));
                command.Parameters.Add(instance.GetParameter("QuestionType", question.QuestionType, _factory));
                command.Parameters.Add(instance.GetParameter("QuestId", question.QuestId, _factory));

                command.ExecuteNonQuery();

                question.Id = instance.GetNewId("Questions", _connection);
                questions.Add(question);
                return question;
            }
            catch (DbException)
            {
                return null;
            }
        }
        //-------------------------------------------------------------------------------
        public bool DeleteQuestion(int id)
        {
            throw new NotImplementedException();
        }
        //-------------------------------------------------------------------------------
        public void UpdateQuestion(int i, Questions question)
        {
            try
            {
                DbCommand command = _factory.CreateCommand();
                command.CommandText = "UPDATE Questions SET Description = @Description, PictureSrc = @PictureSrc, Points = @Points, Hint = @Hint, QuestionType = @QuestionType, QuestId = @QuestId";

                command.Parameters.Add(instance.GetParameter("Description", question.Description, _factory));
                command.Parameters.Add(instance.GetParameter("PictureSrc", question.PictureSrc, _factory));
                command.Parameters.Add(instance.GetParameter("Points", question.Points, _factory));
                command.Parameters.Add(instance.GetParameter("Hint", question.Hint, _factory));
                command.Parameters.Add(instance.GetParameter("QuestionType", question.QuestionType, _factory));
                command.Parameters.Add(instance.GetParameter("QuestId", question.QuestId, _factory));

                command.ExecuteNonQuery();

                questions[i].Description = question.Description;
                questions[i].Hint = question.Hint;
                questions[i].PictureSrc = question.PictureSrc;
                questions[i].Points = question.Points;
                questions[i].QuestId = question.QuestId;
                questions[i].QuestionType = question.QuestionType;

            }
            catch (DbException)
            {
                throw;
            }
        }
    }
}
