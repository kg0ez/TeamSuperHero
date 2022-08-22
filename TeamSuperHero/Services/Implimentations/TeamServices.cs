using Microsoft.EntityFrameworkCore;
using TeamSuperHero.Models.Data;
using TeamSuperHero.Models.DataBaseModels;
using TeamSuperHero.Services.Interfaces;

namespace TeamSuperHero.Services.Implimentations
{
	public class TeamServices: ITeamServices
	{
		private readonly ApplicationContext _db;

		public TeamServices(ApplicationContext context)=>
			_db = context;

        public bool CreateTeam(Team team)
        {
            _db.Teams.Add(team);
            return Save();
        }

        public bool DeleteTeam(int id)
        {
            var team = _db.Teams.FirstOrDefault(c => c.Id == id);
            if (team == null)
                return false;
            _db.Teams.Remove(team);
            return Save();
        }

        public Team GetTeam(int id)=>
            _db.Teams.AsNoTracking().FirstOrDefault(c => c.Id == id);

        public ICollection<Team> GetTeams()=>
            _db.Teams.AsNoTracking().ToList();

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool TeamExists(int id)=>
            _db.Teams.Any(p => p.Id == id);

        public bool UpdateTeam(Team team)
        {
            _db.Update(team);
            return Save();
        }
    }
}

