using DAL.Entities;
using DAL.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MatchService
    {

        private readonly MatchProvider _matchP;

        public MatchService()
        {
            var context = new AppDbContext();
            _matchP = new MatchProvider(context);
        }

        public void AddMatch(Match match)
        {
            _matchP.Add(match);
        }

        public void Updatematch(Match match)
        {
            _matchP.Update(match);
        }

        public void DeleteMatch(Match match)
        {
            _matchP.Delete(match);
        }

        public Match GetMatch(int id)
        {
            return _matchP.Get(id);
        }

        public List<Match> GetAllMatches()
        {
            return _matchP.GetAll(); 
        }

    }
}
