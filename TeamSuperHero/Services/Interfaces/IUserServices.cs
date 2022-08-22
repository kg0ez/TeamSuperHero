using TeamSuperHero.Dto;
using TeamSuperHero.Models.DataBaseModels;

namespace TeamSuperHero.Services.Interfaces
{
	public interface IUserServices
	{
		bool Create(UserDto request);
		User GetLogin(UserDto request);
		void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
		bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
		bool Save();
	}
}

