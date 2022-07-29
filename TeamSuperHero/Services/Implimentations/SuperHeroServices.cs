using Microsoft.EntityFrameworkCore;
using TeamSuperHero.Models.Data;
using TeamSuperHero.Models.DataBaseModels;
using TeamSuperHero.Services.Interfaces;

namespace TeamSuperHero.Services.Implimentations
{
	public class SuperHeroServices: ISuperHeroServices
	{
        private readonly ApplicationContext _db;

        public SuperHeroServices(ApplicationContext context) =>
            _db = context;

        public bool CreateHero(SuperHero superHero)
        {
            _db.superHeroes.Add(superHero);
            return Save();
        }

        public bool DeleteHero(int id)
        {
            var hero = _db.superHeroes.FirstOrDefault(c => c.Id == id);
            if (hero == null)
                return false;
            _db.superHeroes.Remove(hero);
            return Save();
        }

        public ICollection<SuperHero> GetHeroes()=>
            _db.superHeroes.AsNoTracking().ToList();

        public SuperHero GetSuperHero(int id)=>
            _db.superHeroes.AsNoTracking().FirstOrDefault(c => c.Id == id);

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool TeamExists(int id)=>
            _db.superHeroes.Any(p => p.Id == id);

        public bool UpdateHero(SuperHero superHero)
        {
            _db.Update(superHero);
            return Save();
        }
    }
}

