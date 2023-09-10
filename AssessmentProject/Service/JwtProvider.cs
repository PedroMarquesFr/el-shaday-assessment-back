using AssessmentProject.Controllers.Shared;
using AssessmentProject.Models;
using AssessmentProject.secrets;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AssessmentProject.Service
{
    public class JwtProvider : IJwtProvider
    {
        public string Generate(Person person)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = AddClaims(person),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.Secret)), SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddHours(8)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        private static ClaimsIdentity AddClaims(Person person)
        {
            var claims = new ClaimsIdentity();
            var userRole = (ERoles)person.RoleId == ERoles.Admin ? "Admin" : "User";

            claims.AddClaim(new Claim(ClaimTypes.Role, userRole));

            return claims;
        }
    }
}
