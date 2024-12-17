using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Match = DAL.Entities.Match;

namespace DAL.Provider
{
    internal class MatchProvider
    {
        private readonly AppDbContext _context;

        public MatchProvider(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Match match)
        {
            _context.Matches.Add(match);
            _context.SaveChanges();
        }

        public void Update(Match match)
        {
            _context.Matches.Update(match);

            _context.SaveChanges();
        }

        public void Delete(Match match)
        {
            _context.Remove(match);
        }

        public Match Get(int id)
        {
            return _context.Matches.First(x => x.Id == id);
        }

        public List<Match> GetAll()
        {
            return _context.Matches.ToList();
        }
    }
}
