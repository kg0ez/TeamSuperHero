using AutoMapper;
using TeamSuperHero.Dto;
using TeamSuperHero.Models.DataBaseModels;

namespace TeamSuperHero.Helper
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			CreateMap<Comic, ComicDto>();
			CreateMap<ComicDto, Comic>();
			CreateMap<Team, TeamDto>();
			CreateMap<TeamDto, Team>();
			CreateMap<SuperHeroDto, SuperHero>();
			CreateMap<SuperHero, SuperHeroDto>();
			CreateMap<User, UserDto>();
			CreateMap<UserDto, User>();
		}
	}
}

