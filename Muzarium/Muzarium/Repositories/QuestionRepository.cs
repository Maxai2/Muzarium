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
        private ConnectionStringSettings constr = DataProvider.GetInstance().AcademyConnection();



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

        public IList<Questions> GetQuestions(int id)
        {
            throw new NotImplementedException();
        }

        public Questions UpdateQuestion(int id, Questions question)
        {
            throw new NotImplementedException();
        }
    }
}
