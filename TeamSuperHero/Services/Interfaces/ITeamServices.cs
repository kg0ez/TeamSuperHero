using TeamSuperHero.Models.DataBaseModels;

namespace TeamSuperHero.Services.Interfaces
{
	public interface ITeamServices
	{
		ICollection<Team> GetTeams();
		Team GetTeam(int id);
		bool CreateTeam(Team team);
		bool UpdateTeam(Team team);
		bool DeleteTeam(int id);
		bool Save();
		bool TeamExists(int id);
	}
}

