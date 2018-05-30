using Muzarium.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using Muzarium.Interface;

namespace Muzarium
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        DataProvider provider = DataProvider.GetInstance();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var viewModel = provider.Container.Resolve<ILoginWindowViewModel>();
            var mainView = viewModel.View;
            this.MainWindow = mainView as Window;
            this.MainWindow.Show();
        }
    }
}
