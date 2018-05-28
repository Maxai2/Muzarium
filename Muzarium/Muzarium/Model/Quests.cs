using Muzarium.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzarium.Model
{
    public class Quests : NotifiableObject
    {
        private int id;
        public int Id
        {
            get { return this.id; }
            set { this.id = value; base.OnPropertyChanged(); }
        }

        private string title;
        public string Title
        {
            get { return this.title; }
            set { this.title = value; base.OnPropertyChanged(); }
        }

        private string description;
        public string Description
        {
            get { return this.description; }
            set { this.description = value; base.OnPropertyChanged(); }
        }

        private int difficult;
        public int Difficult
        {
            get { return this.difficult; }
            set { this.difficult = value; base.OnPropertyChanged(); }
        }

        private string pictureSrc;
        public string PictureSrc
        {
            get { return pictureSrc; }
            set { pictureSrc = value; base.OnPropertyChanged(); }
        }

        private int points;
        public int Points
        {
            get { return this.points; }
            set { this.points = value; base.OnPropertyChanged(); }
        }

        private int museumId;
        public int MuseumId
        {
            get { return this.museumId; }
            set { this.museumId = value; base.OnPropertyChanged(); }
        }

        private int prizesId;
        public int PrizesId
        {
            get { return this.prizesId; }
            set { this.prizesId = value; base.OnPropertyChanged(); }
        }


    }
}
