using TeamSuperHero.Models.DataBaseModels;

namespace TeamSuperHero.Services.Interfaces
{
	public interface ISuperHeroServices
	{
		ICollection<SuperHero> GetHeroes();
		SuperHero GetSuperHero(int id);
		bool CreateHero(SuperHero superHero);
		bool UpdateHero(SuperHero superHero);
		bool DeleteHero(int id);
		bool Save();
		bool TeamExists(int id);
	}
}

