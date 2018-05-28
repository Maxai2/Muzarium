using Muzarium.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzarium.Model
{
    public class Statics : NotifiableObject
    {
        private int id;
        public int Id
        {
            get { return this.id; }
            set { this.id = value; base.OnPropertyChanged(); }
        }

        private int userId;
        public int UserId
        {
            get { return this.userId; }
            set { this.userId = value; base.OnPropertyChanged(); }
        }

        private int questId;
        public int QuestId
        {
            get { return this.questId; }
            set { this.questId = value; base.OnPropertyChanged(); }
        }

        private bool isCompleted;
        public bool IsCompleted
        {
            get { return this.isCompleted; }
            set { this.isCompleted = value; base.OnPropertyChanged(); }
        }

        private int points;
        public int Points
        {
            get { return this.points; }
            set { this.points = value; base.OnPropertyChanged(); }
        }

        private DateTime duration;
        public DateTime Duration
        {
            get { return this.duration; }
            set { this.duration = value; base.OnPropertyChanged(); }
        }

        private DateTime myVar;
        public DateTime MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        private int prize;
        public int Prize
        {
            get { return prize; }
            set { prize = value; base.OnPropertyChanged(); }
        }



    }
}
