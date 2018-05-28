using Muzarium.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzarium.Model
{
    public class Answers : NotifiableObject
    {
        private int id;
        public int Id
        {
            get { return this.id; }
            set { this.id = value; base.OnPropertyChanged(); }
        }

        private string answer;
        public string Answer
        {
            get { return this.answer; }
            set { this.answer = value; base.OnPropertyChanged(); }
        }

        private bool isRight;
        public bool IsRight
        {
            get { return this.isRight; }
            set { this.isRight = value; base.OnPropertyChanged(); }
        }

        private int questionId;
        public int QuestionId
        {
            get { return this.questionId; }
            set { this.questionId = value; base.OnPropertyChanged(); }
        }

    }
}
