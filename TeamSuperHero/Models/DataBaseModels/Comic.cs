using System.ComponentModel.DataAnnotations;

namespace TeamSuperHero.Models.DataBaseModels
{
	public class Comic
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Team> Team { get; set; }
    }
}

