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
        void GetQuestions(int QuestId);
        Questions AddQuestion(Questions question);
        void UpdateQuestion(int i, Questions question);
        bool DeleteQuestion(int id);
    }
}
