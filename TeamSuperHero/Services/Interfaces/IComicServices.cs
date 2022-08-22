using TeamSuperHero.Models.DataBaseModels;

namespace TeamSuperHero.Services.Interfaces
{
	public interface IComicServices
	{
		ICollection<Comic> GetComics();
		Comic GetComic(int id);
		bool CreateComic(Comic comic);
		bool UpdateComic(Comic comic);
		bool DeleteComic(int id);
		bool Save();
		bool ComicExists(int id);
	}
}

