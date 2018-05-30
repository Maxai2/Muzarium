using Muzarium.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Muzarium.Interface
{
    public interface ILoginWindowViewModel
    {
        ICommand LoginCommand { get; }
        ICommand RegisterCommand { get; }

        Museums museum { get; }

        ILoginWindow View { get; }
    }
}
