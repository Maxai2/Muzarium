using Muzarium.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzarium.Interface
{
    public interface IQuestionRepository
    {
        IList<Questions> GetQuestions(int id);
        Questions AddQuestion(Questions question);
        Questions UpdateQuestion(int id, Questions question);
        bool DeleteQuestion(int id);
        void DeleteAllQustion(int id);
    }
}
