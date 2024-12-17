using DAL.Entities;
using DAL.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PlayerService
    {

        private readonly PlayerProvider _playerP;

        public PlayerService()
        {
            var context = new AppDbContext();
            _playerP = new PlayerProvider(context);
        }

        public void AddPlayer(Player player)
        {
            _playerP.Add(player);
        }

        public void UpdatePlayer(Player player)
        {
            _playerP.Update(player);
        }

        public void DeletePlayer(Player player)
        {
            _playerP.Delete(player);
        }

        public Player GetPlayer(int id)
        {
            return _playerP.Get(id);
        }

        public List<Player> GetAllPlayers()
        {
            return _playerP.GetAll(); 
        }

    }
}
