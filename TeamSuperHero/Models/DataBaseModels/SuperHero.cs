using System.ComponentModel.DataAnnotations;

namespace TeamSuperHero.Models.DataBaseModels
{
	public class SuperHero
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }

		public int TeamId { get; set; }
		public Team Team { get; set; }
	}
}

