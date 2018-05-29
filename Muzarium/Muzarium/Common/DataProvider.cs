using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Autofac;

namespace Muzarium.Common
{
    public class DataProvider
    {
        private static DataProvider instance;
        ContainerBuilder builder;

        public static DataProvider GetInstance()
        {
            if (instance == null)
                instance = new DataProvider();
            return instance;
        }

        public ConnectionStringSettings AcademyConnection()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionToDBAcademic"];
        }

        public ConnectionStringSettings HomeConnection()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionToDBHome"];
        }

        private DataProvider()
        {
            builder = new ContainerBuilder();

        }


    }
}
