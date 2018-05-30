using Muzarium.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzarium.Interface
{
    public interface IMuseumServices
    {
        Museums InfoAboutMuseum(int id);
        IEnumerable<Quests> GetMuseumQuest(int id);
        IEnumerable<Prizes> GetMuseumPrizes(int id);
        IEnumerable<Statics> GetMuseumStatics(int id);
    }
}
