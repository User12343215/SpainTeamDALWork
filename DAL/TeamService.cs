using DAL.Entities;
using DAL.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TeamService
    {

        private readonly TeamProvider _teamP;

        public TeamService()
        {
            var context = new AppDbContext();
            _teamP = new TeamProvider(context);
        }

        public void AddTeam(Team team)
        {
            _teamP.Add(team);
        }

        public void UpdateTeam(Team team)
        {
            _teamP.Update(team);
        }

        public void DeleteTeam(Team team)
        {
            _teamP.Delete(team);
        }

        public Team GetTeam(int id)
        {
            return _teamP.Get(id);
        }

        public List<Team> GetAllTeams()
        {
            return _teamP.GetAll(); 
        }

    }
}
