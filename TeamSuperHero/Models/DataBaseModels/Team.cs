using System.ComponentModel.DataAnnotations;

namespace TeamSuperHero.Models.DataBaseModels
{
	public class Team
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }

		public int ComicId { get; set; }
		public Comic Comic { get; set; }

		public List<SuperHero> SuperHeroes { get; set; }
	}
}

