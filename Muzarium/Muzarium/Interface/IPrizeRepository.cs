using Muzarium.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzarium.Interface
{
    public interface IPrizeRepository
    {
        List<Prizes> GetPrizes();
        Prizes GetPrizeById(int id);
        Prizes UpdatePrize(int id, Prizes prize);
        Prizes AddPrize(Prizes prize);
        bool DeletePrize(int id);
        bool DeleteAllPrizes();
    }
}
