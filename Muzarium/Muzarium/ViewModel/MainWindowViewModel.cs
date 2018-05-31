using Muzarium.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzarium.ViewModel
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        public MainWindowViewModel(IMainWindow View)
        {
            this.View = View;
        }

        public IMainWindow View { get; private set; }
    }
}
