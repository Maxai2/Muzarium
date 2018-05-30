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

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public Museums museum { get; set; }
    }
}
