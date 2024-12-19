using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Provider
{
    internal class PlayerProvider
    {
        private readonly AppDbContext _context;

        public PlayerProvider(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        public void Update(Player player)
        {
            _context.Players.Update(player);

            _context.SaveChanges();
        }

        public void Delete(Player player)
        {
            _context.Remove(player);
        }

        public Player Get(int id)
        {
            return _context.Players.First(x => x.Id == id);
        }

        public List<Player> GetAll()
        {
            return _context.Players.ToList();
        }
    }
}
