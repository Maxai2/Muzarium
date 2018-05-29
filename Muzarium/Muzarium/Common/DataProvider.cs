using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Autofac;
using System.Data.Common;

namespace Muzarium.Common
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static IContainer Container { get; private set; }
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
