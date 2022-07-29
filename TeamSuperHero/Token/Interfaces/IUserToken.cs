using TeamSuperHero.Models.DataBaseModels;

namespace TeamSuperHero.Token.Interfaces
{
	public interface IUserToken
	{
		string CreateToken(User user);
	}
}

