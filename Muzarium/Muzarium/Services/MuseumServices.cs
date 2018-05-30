using Muzarium.Common;
using Muzarium.Interface;
using Muzarium.Model;
using System;
using System.Collections.Generic;
using Autofac;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzarium.Services
{
    public class MuseumServices : IMuseumServices
    {
        private readonly IMuseumRepository museumRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly IPrizeRepository prizeRepository;
        private readonly IStaticRepository staticRepository;
        private DataProvider instance = DataProvider.GetInstance();

        public IEnumerable<Prizes> GetMuseumPrizes(int id)
        {
            return prizeRepository.GetPrizeById(id) as IEnumerable<Prizes>;
        }

        public IEnumerable<Quests> GetMuseumQuest(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Statics> GetMuseumStatics(int id)
        {
            throw new NotImplementedException();
        }

        public Museums InfoAboutMuseum(int id)
        {
            throw new NotImplementedException();
        }
    }
}
