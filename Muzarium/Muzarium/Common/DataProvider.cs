using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Autofac;
using System.Data.Common;
using Muzarium.View;
using Muzarium.Interface;
using Muzarium.ViewModel;

namespace Muzarium.Common
{
    public class DataProvider
    {
        private static DataProvider instance;

        public IContainer Container { get; private set; }
        ContainerBuilder builder;
        //-------------------------------------------------------------------------------
        public static DataProvider GetInstance()
        {
            if (instance == null)
                instance = new DataProvider();
            return instance;
        }
        //-------------------------------------------------------------------------------
        public ConnectionStringSettings AcademyConnection()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionToDBAcademic"];
        }
        //-------------------------------------------------------------------------------
        public ConnectionStringSettings HomeConnection()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionToDBHome"];
        }
        //-------------------------------------------------------------------------------
        private DataProvider()
        {
            builder = new ContainerBuilder();

            builder.RegisterType<LoginWindow>().As<ILoginWindow>();
            builder.RegisterType<LoginWindowViewModel>().As<ILoginWindowViewModel>();

            Container = builder.Build();
        }
        //-------------------------------------------------------------------------------
        public DbParameter GetParameter(string ParameterName, object Value, DbProviderFactory factory)
        {
            DbParameter parameter = factory.CreateParameter();
            parameter.ParameterName = ParameterName;
            parameter.Value = Value;

            return parameter;
        }
        //-------------------------------------------------------------------------------
        public int GetNewId(string tableName, DbConnection connection)
        {
            try
            {
                DbCommand command = connection.CreateCommand();

                command.CommandText = $"SELECT MAX(Id) + 1 FROM {tableName}";

                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch (DbException)
            {
                return -1;
            }
        }
    }
}
