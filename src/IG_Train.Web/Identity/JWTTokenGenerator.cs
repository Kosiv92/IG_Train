using IG_Train.Application.Identity;
using IG_Train.Web.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace IG_Train.Web.Identity
{
    public class JWTTokenGenerator : ITokenGenerator
    {
        private readonly ITokenConfiguration _tokenConfiguration;

        public JWTTokenGenerator(IOptions<JWTTokenConfiguration> jwtTokenConfiguration)
        {
            _tokenConfiguration = jwtTokenConfiguration.Value;
        }

        public string Generate()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var sectoken = new JwtSecurityToken(_tokenConfiguration.Issuer,
              _tokenConfiguration.Issuer,
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(sectoken);

            return token;
        }
    }
}
