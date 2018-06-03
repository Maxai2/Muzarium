using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzarium.Interface
{
    public interface IMainWindowViewModel
    {
        IMainWindow View { get; }
        bool? ShowDialog();
    }
}
