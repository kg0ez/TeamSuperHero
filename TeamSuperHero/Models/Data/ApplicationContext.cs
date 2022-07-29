using Microsoft.EntityFrameworkCore;
using TeamSuperHero.Models.DataBaseModels;

namespace TeamSuperHero.Models.Data
{
	public class ApplicationContext:DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)=>
			Database.EnsureCreated();

		public DbSet<Comic> Comics { get; set; } = null!;
		public DbSet<SuperHero> superHeroes { get; set; } = null!;
		public DbSet<Team> Teams { get; set; } = null!;
		public DbSet<User> Users { get; set; } = null!;
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Comic>()
				.HasMany(c => c.Team)
				.WithOne(t => t.Comic)
				.OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<Team>()
				.HasMany(c => c.SuperHeroes)
				.WithOne(t => t.Team)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}

