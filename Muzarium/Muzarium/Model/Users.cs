using Muzarium.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzarium.Model
{
    public class Users : NotifiableObject
    {
        private int id;
        public int Id
        {
            get { return this.id; }
            set { this.id = value; base.OnPropertyChanged(); }
        }

        private string firstName;
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; base.OnPropertyChanged(); }
        }

        private string lastName;
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; base.OnPropertyChanged(); }
        }

        private DateTime birthDate;
        public DateTime BirthDate
        {
            get { return this.birthDate; }
            set { this.birthDate = value; base.OnPropertyChanged(); }
        }


    }
}
