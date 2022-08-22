using Microsoft.AspNetCore.Mvc;
using TeamSuperHero.Dto;
using TeamSuperHero.Models.DataBaseModels;
using TeamSuperHero.Services.Interfaces;
using TeamSuperHero.Token.Interfaces;

namespace TeamSuperHero.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IUserToken _token;

        public UserController(IUserServices userServices,IUserToken token)
        {
            _userServices = userServices;
            _token = token;
        }

        [HttpPost("register")]
        public ActionResult<User> Register(UserDto request)=>
            _userServices.Create(request)? Ok("User has been created"):BadRequest("User not created");

        [HttpPost("login")]
        public ActionResult<string> Login(UserDto request)
        {
            User user = _userServices.GetLogin(request);
            if (user==null)
                return BadRequest("User not found.");

            if (!_userServices.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                return BadRequest("Wrong password.");

            string token = CreateToken(user);

            return Ok(token);
        }

        private string CreateToken(User user)
        {
            var jwt = _token.CreateToken(user);
            return jwt;
        } 
    }
}

