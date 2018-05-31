using Muzarium.Common;
using Muzarium.Interface;
using Muzarium.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzarium.Repositories
{
    public class MuseumRepository : IMuseumRepository
    {
        private string _connectionString;
        private DbProviderFactory _factory;
        private DbConnection _connection;
        private ConnectionStringSettings constr = DataProvider.GetInstance().AcademyConnection();

        private DataProvider instance = DataProvider.GetInstance();

        public List<Museums> museums;
        public Museums museum;
        //-------------------------------------------------------------------------------
        public MuseumRepository()
        {
            _connectionString = constr.ConnectionString;
            _factory = DbProviderFactories.GetFactory(constr.ProviderName);
        }
        //-------------------------------------------------------------------------------
        public bool OpenConnection()
        {
            try
            {
                _connection = _factory.CreateConnection();
                _connection.ConnectionString = _connectionString;
                _connection.Open();
                return true;
            }
            catch (DbException)
            {
                return false;
            }
        }
        //-------------------------------------------------------------------------------
        public void CloseConnection()
        {
            if (_connection != null)
                _connection.Close();
        }
        //-------------------------------------------------------------------------------
        public Museums GetMuseumById(int id)
        {
            try
            {
                DbCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM Museums WHERE Id = @id";

                command.Parameters.Add(instance.GetParameter("id", id, _factory));

                DbDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    museum.Title = Convert.ToString(reader["Title"]);
                    museum.Description = Convert.ToString(reader["Description"]);
                    museum.Address = Convert.ToString(reader["Address"]);
                    museum.Phone = Convert.ToString(reader["Phone"]);
                    museum.PictureSrc = Convert.ToString(reader["PictureSrc"]);
                    museum.WebSite = Convert.ToString(reader["WebSite"]);
                    museum.Login = Convert.ToString(reader["Login"]);
                    museum.Password = Convert.ToString(reader["Password"]);
                    museum.Latitude = Convert.ToSingle(reader["Latitude"]);
                    museum.Longitude = Convert.ToSingle(reader["Longitude"]);
                    museum.Radius = Convert.ToSingle(reader["Radius"]);
                    museum.CityId = Convert.ToInt32(reader["CityId"]);
                }
            }
            catch (DbException)
            {
                throw;
            }
        }
        //-------------------------------------------------------------------------------
        public void UpdateMuseum(int i, Museums museum)
        {
            try
            {
                DbCommand command = _factory.CreateCommand();

                command.CommandText = "UPDATE Museums SET Title = @Title, [Description] = @Description, [Address] = @Address, Phone = @Phone, PictureSrc = @PictureSrc, WebSite = @WebSite, [Login] = @Login, [Password] = @Password, Latitude = @Latitude, Longitude = @Longitude, Radius = @Radius, CityId = @CityId";

                command.Parameters.Add(instance.GetParameter("Title", museum.Title, _factory));
                command.Parameters.Add(instance.GetParameter("Description", museum.Description, _factory));
                command.Parameters.Add(instance.GetParameter("Address", museum.Address, _factory));
                command.Parameters.Add(instance.GetParameter("Phone", museum.Phone, _factory));
                command.Parameters.Add(instance.GetParameter("PictureSrc", museum.PictureSrc, _factory));
                command.Parameters.Add(instance.GetParameter("WebSite", museum.WebSite, _factory));
                command.Parameters.Add(instance.GetParameter("Login", museum.Login, _factory));
                command.Parameters.Add(instance.GetParameter("Password", museum.Password, _factory));
                command.Parameters.Add(instance.GetParameter("Latitude", museum.Latitude, _factory));
                command.Parameters.Add(instance.GetParameter("Longitude", museum.Longitude, _factory));
                command.Parameters.Add(instance.GetParameter("Radius", museum.Radius, _factory));
                command.Parameters.Add(instance.GetParameter("CityId", museum.CityId, _factory));

                command.ExecuteNonQuery();

                museums[i].Address = museum.Address;
                museums[i].CityId = museum.CityId;
                museums[i].Description = museum.Description;
                museums[i].Latitude = museum.Latitude;
                museums[i].Login = museum.Login;
                museums[i].Longitude = museum.Longitude;
                museums[i].Password = museum.Password;
                museums[i].Phone = museum.Phone;
                museums[i].PictureSrc = museum.PictureSrc;
                museums[i].Radius = museum.Radius;
                museums[i].Title = museum.Title;
                museums[i].WebSite = museum.WebSite;

            }
            catch (DbException)
            {
                throw;
            }
        }
        //-------------------------------------------------------------------------------
        public Museums AddMuseum(Museums museum)
        {
            try
            {
                DbCommand command = _factory.CreateCommand();

                command.CommandText = "INSERT INTO Museums ([Address], CityId, [Description], Latitude, [Login], Longitude, [Password], Phone, PictureSrc, Radius, Title, WebSite) VALUES(@Address, @CityId, @Description, @Latitude, @Login, @Longitude, @Password, @Phone, @PictureSrc, @Radius, @Title, @WebSite)";

                command.Parameters.Add(instance.GetParameter("Address", museum.Address, _factory));
                command.Parameters.Add(instance.GetParameter("CityId", museum.CityId, _factory));
                command.Parameters.Add(instance.GetParameter("Description", museum.Description, _factory));
                command.Parameters.Add(instance.GetParameter("Latitude", museum.Latitude, _factory));
                command.Parameters.Add(instance.GetParameter("Login", museum.Login, _factory));
                command.Parameters.Add(instance.GetParameter("Longitude", museum.Longitude, _factory));
                command.Parameters.Add(instance.GetParameter("Password", museum.Password, _factory));
                command.Parameters.Add(instance.GetParameter("Phone", museum.Phone, _factory));
                command.Parameters.Add(instance.GetParameter("PictureSrc", museum.PictureSrc, _factory));
                command.Parameters.Add(instance.GetParameter("Radius", museum.Radius, _factory));
                command.Parameters.Add(instance.GetParameter("Title", museum.Title, _factory));
                command.Parameters.Add(instance.GetParameter("WebSite", museum.WebSite, _factory));

                command.ExecuteNonQuery();

                museum.Id = instance.GetNewId("Museums", _connection);
                museums.Add(museum);
                return museum;
            }
            catch (DbException)
            {
                return null;
            }
        }
        //-------------------------------------------------------------------------------
        public void GetMuseums()
        {
            try
            {
                DbCommand command = _factory.CreateCommand();

                command.CommandText = "SELECT * FROM Museums";

                DbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Museums museum = new Museums();

                    museum.Address = Convert.ToString(reader["Address"]);
                    museum.CityId = Convert.ToInt32(reader["CityId"]);
                    museum.Description = Convert.ToString(reader["Description"]);
                    museum.Id = Convert.ToInt32(reader["Id"]);
                    museum.Latitude = Convert.ToSingle(reader["Latitude"]);
                    museum.Login = Convert.ToString(reader["Login"]);
                    museum.Longitude = Convert.ToSingle(reader["Longitude"]);
                    museum.Password = Convert.ToString(reader["Password"]);
                    museum.Phone = Convert.ToString(reader["Phone"]);
                    museum.PictureSrc = Convert.ToString(reader["PictureSrc"]);
                    museum.Radius = Convert.ToSingle(reader["Radius"]);
                    museum.Title = Convert.ToString(reader["Title"]);
                    museum.WebSite = Convert.ToString(reader["WebSite"]);

                    museums.Add(museum);
                }

                reader.Close();
            }
            catch (DbException)
            {
                throw;
            }
        }
    }
}
