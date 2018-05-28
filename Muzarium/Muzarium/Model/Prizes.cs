using Muzarium.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzarium.Model
{
    public class Prizes : NotifiableObject
    {
        private int id;
        public int Id
        {
            get { return this.id; }
            set { this.id = value; base.OnPropertyChanged(); }
        }

        private string prizeName;
        public string PrizeName
        {
            get { return this.prizeName; }
            set { this.prizeName = value; base.OnPropertyChanged(); }
        }

        private string pictureSrc;
        public string PictureSrc    
        {
            get { return this.pictureSrc; }
            set { this.pictureSrc = value; base.OnPropertyChanged(); }
        }


    }
}
