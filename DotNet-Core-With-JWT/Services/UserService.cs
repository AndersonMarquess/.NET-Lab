using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using jwtnetcore31.Helpers;
using jwtnetcore31.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace jwtnetcore31.Services {
    public class UserService : IUserService {

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings) {
            _appSettings = appSettings.Value;
        }

        private List<User> GetMockUsers() {
            return new List<User> {
                new User { Id = 1, Username = "A", Email = "A@EMAIL.COM", Password = "A"},
                new User { Id = 2, Username = "B", Email = "B@EMAIL.COM", Password = "B"},
                new User { Id = 3, Username = "C", Email = "C@EMAIL.COM", Password = "C"}
            };
        }

        public IEnumerable<User> GetAll() {
            return GetMockUsers().WithoutPassword();
        }

        public User Authenticate(string username, string password) {
            var user = GetMockUsers().FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));
            if (user == null) {
                return null;
            }

            user.Token = GenerateJwtToken(user);
            return user.WithoutPassword();
        }

        private string GenerateJwtToken(User user) {
            var secret = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var signature = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature);
            var claims = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, user.Id.ToString()) });
            var expireDate = DateTime.UtcNow.AddDays(1);

            var tokenDescription = new SecurityTokenDescriptor{
                Subject = claims,
                Expires = expireDate,
                SigningCredentials = signature
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}