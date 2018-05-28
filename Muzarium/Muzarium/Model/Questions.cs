using Muzarium.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzarium.Model
{
    public class Questions : NotifiableObject
    {
        private int id;
        public int Id
        {
            get { return this.id; }
            set { this.id = value; base.OnPropertyChanged(); } 
        }

        private string description;
        public string Description
        {
            get { return this.description; }
            set { this.description = value; base.OnPropertyChanged(); }
        }

        private string pictureSrc;
        public string PictureSrc
        {
            get { return this.pictureSrc; }
            set { this.pictureSrc = value; base.OnPropertyChanged(); }
        }

        private int points;
        public int Points
        {
            get { return this.points; }
            set { this.points = value; base.OnPropertyChanged(); }
        }

        private string hint;
        public string Hint
        {
            get { return this.hint; }
            set { this.hint = value; base.OnPropertyChanged(); }
        }

        private int questionType;
        public int QuestionType
        {
            get { return this.questionType; }
            set { this.questionType = value; base.OnPropertyChanged(); }
        }

        private int questId;
        public int QuestId
        {
            get { return this.questId; }
            set { this.questId = value; base.OnPropertyChanged(); }
        }


    }
}
