using Muzarium.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzarium.Interface
{
    public interface IQuestRepository
    {
        List<Quests> GetQuests();
        Quests GetQuestById(int id);
        Quests UpdateQuestById(int id, Quests quest);
        Quests AddQuest(Quests quest);
        bool DeleteQuest(int id);
        bool DeleteAllQuests();
    }
}
