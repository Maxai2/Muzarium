using Muzarium.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzarium.Interface
{
    public interface IStaticRepository
    {
        IList<Statics> GetStatics();
        Statics GetStaticById(int id);
        Statics AddStatic(Statics @static);
        Statics UpdateStatic(int id, Statics @static);
    }
}
