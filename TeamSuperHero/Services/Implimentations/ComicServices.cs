using Microsoft.EntityFrameworkCore;
using TeamSuperHero.Models.Data;
using TeamSuperHero.Models.DataBaseModels;
using TeamSuperHero.Services.Interfaces;

namespace TeamSuperHero.Services.Implimentations
{
	public class ComicServices: IComicServices
	{
        private readonly ApplicationContext _db;

        public ComicServices(ApplicationContext context)=>
            _db = context;

        public bool CreateComic(Comic comic)
        {
            _db.Comics.Add(comic);
            return Save();
        }

        public bool DeleteComic(int id)
        {
            var comic = _db.Comics.FirstOrDefault(c => c.Id == id);
            if (comic==null)
                return false;
            _db.Comics.Remove(comic);
            return Save();
        }

        public ICollection<Comic> GetComics()=>
            _db.Comics.AsNoTracking().ToList();

        public Comic GetComic(int id)=>
            _db.Comics.AsNoTracking().FirstOrDefault(c => c.Id == id);

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateComic(Comic comic)
        {
            _db.Update(comic);
            return Save();
        }

        public bool ComicExists(int id)=>
            _db.Comics.Any(p => p.Id == id);
    }
}

