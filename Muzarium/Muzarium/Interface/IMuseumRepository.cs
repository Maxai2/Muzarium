using Muzarium.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzarium.Interface
{
    public interface IMuseumRepository
    {
        void GetMuseumById(int id);
        void UpdateMuseum(int i, Museums museum);
        Museums AddMuseum(Museums museum);
        void GetMuseums();
    }
}
