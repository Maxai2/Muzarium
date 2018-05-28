using Muzarium.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzarium.Model
{
    public class Cities : NotifiableObject
    {
        private int id;
        public int Id
        {
            get { return this.id; }
            set { this.id = value; base.OnPropertyChanged(); }
        }

        private string cityName;
        public string CityName
        {
            get { return this.cityName; }
            set { this.cityName = value; base.OnPropertyChanged(); }
        }

    }
}
