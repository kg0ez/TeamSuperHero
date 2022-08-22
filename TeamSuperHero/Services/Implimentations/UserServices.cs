using System.Security.Cryptography;
using AutoMapper;
using TeamSuperHero.Dto;
using TeamSuperHero.Models.Data;
using TeamSuperHero.Models.DataBaseModels;
using TeamSuperHero.Services.Interfaces;

namespace TeamSuperHero.Services.Implimentations
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationContext _db;
        private readonly IMapper _mapper;

        public UserServices(ApplicationContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public bool Create(UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            _db.Users.Add(_mapper.Map<User>(request));
            return Save();
        }

        public User GetLogin(UserDto request) =>
            _db.Users.FirstOrDefault(u => u.Username == request.Username);

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}

