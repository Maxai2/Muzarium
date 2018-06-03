using Autofac;
using Muzarium.Common;
using Muzarium.Interface;
using Muzarium.Model;
using System.Windows.Input;

namespace Muzarium.ViewModel
{
    public class LoginWindowViewModel : ILoginWindowViewModel
    {
        public LoginWindowViewModel(ILoginWindow View)
        {
            this.View = View;
        }
        public ILoginWindow View { get; private set; }

        private ICommand loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand is null)
                {
                    loginCommand = new RelayCommand(
                        (param) =>
                        {
                            var loginW = DataProvider.GetInstance().Container.Resolve<IMainWindowViewModel>();
                            loginW.ShowDialog();
                        }, null);
                }
                return loginCommand;
            }
        }


        public ICommand RegisterCommand { get; set; }
        public Museums museum { get; set; }
    }
}
