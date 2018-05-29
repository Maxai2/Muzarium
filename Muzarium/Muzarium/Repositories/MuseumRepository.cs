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

        public List<Museums> museums;

        public MuseumRepository()
        {
            _connectionString = constr.ConnectionString;
            _factory = DbProviderFactories.GetFactory(constr.ProviderName);
        }

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

        public void CloseConnection()
        {
            if (_connection != null)
                _connection.Close();
        }

        public Museums GetMuseumById(int id)
        {
            try
            {
                DbCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM Museums WHERE Id = @id";

                DbParameter parameter = _factory.CreateParameter();
                parameter.ParameterName = "id";
                parameter.Value = id;
                command.Parameters.Add(parameter);

                DbDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Museums museum = new Museums();

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

                    return museum;
                }

                return null;
            }
            catch (DbException)
            {
                return null;
            }
        }

        public Museums UpdateMuseum(int id, Museums museum)
        {
            throw new NotImplementedException();
        }

        public Museums AddMuseum(Museums museum)
        {
            throw new NotImplementedException();
        }
    }
}
