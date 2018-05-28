using Muzarium.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzarium.Model
{
    public class Museums : NotifiableObject
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

        private string address;
        public string Address
        {
            get { return this.address; }
            set { this.address = value; base.OnPropertyChanged(); }
        }

        private string phone;
        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; base.OnPropertyChanged(); }
        }

        private string pictureSrc;
        public string PictureSrc
        {
            get { return this.pictureSrc; }
            set { this.pictureSrc = value; base.OnPropertyChanged(); }
        }

        private string webSite;
        public string WebSite
        {
            get { return this.webSite; }
            set { this.webSite = value; base.OnPropertyChanged(); }
        }

        private string login;
        public string Login
        {
            get { return this.login; }
            set { this.login = value; base.OnPropertyChanged(); }
        }

        private string password;
        public string Password
        {
            get { return this.password; }
            set { this.password = value; base.OnPropertyChanged(); }
        }

        private float latitude;
        public float Latitude
        {
            get { return this.latitude; }
            set { this.latitude = value; base.OnPropertyChanged(); }
        }

        private float longitude;
        public float Longitude
        {
            get { return this.longitude; }
            set { this.longitude = value; base.OnPropertyChanged(); }
        }

        private float radius;
        public float Radius
        {
            get { return this.radius; }
            set { this.radius = value; base.OnPropertyChanged(); }
        }

        private int cityId;
        public int CityId
        {
            get { return this.cityId; }
            set { this.cityId = value; base.OnPropertyChanged(); }
        }

    }
}
