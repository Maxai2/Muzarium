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
        Museums GetMuseumById(int id);
        Museums UpdateMuseum(int id, Museums museum);
        Museums AddMuseum(Museums museum);
    }
}
