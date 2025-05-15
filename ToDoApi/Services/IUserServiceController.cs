

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CredentialManagement;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace ToDoApi.Services
{
   
    public interface IUserService
    {
        string Login(string username, string password);
    }

    public class UserService : IUserService
    {

        public UserService()
        {
            var cred = new Credential
            {
                Target = "MyPasswordService",
                Username = "admin",
                Password = "pass1234$$",
                Type = CredentialType.Generic,
                PersistanceType = PersistanceType.LocalComputer,


            };

            cred.Save();
        }

        public string Login(string username, string password)
        {
            var cred = new Credential
            {
                Target = "MyPasswordService"
            };

            if (cred.Load())
            {
                var isAuthSuccess = cred.Username == username && cred.Password == password;

                //Create a JWT Token
                var token = GenerateJwt(username);
                return token;
            }

            throw new UnauthorizedAccessException();

        }

        public string GenerateJwt(string username)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("lhds4545nklnk6ljlk45654kj6l54j654nm,n,mn4b54564565nm,n"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim("Permission","user.create")
            };


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
