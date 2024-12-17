using MamunTutorial.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MamunTutorial.Services
{
    public class IjwtService
    {
        private readonly IConfiguration _configuration;
        private DateTime expiration;

        /*public JwtService(IConfiguration configuration) {
        
            _configuration = configuration;
        
        }*/
        /*AuthenticationResponse CreateJwtToken(Applicationuser user) {

         DateTime expiration=   DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:EXPIRATION_MINUTES"]));
            Claim[] claims = new Claim[] {
            new Claim(JwtRegisteredClaimNames.Sub,user.Id.Tostring()),

            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString(),

            new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.Now.ToString(),

            new Claim(ClaimTypes.NameIdentifier,user.Email),

            new Claim(ClaimTypes.NameIdentifier,Name.PersonName)
            };

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken tokeGenerator = new JwtSecurityToken(

                _configuration["Jwt:Isuuer"],
                _configuration["Jwt:Isuuer"],
                claims,
                 expires: expiration,
                 signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler tokenHandler= new JwtSecurityTokenHandler();
          
            string token = tokenHandler.WriteToken(tokeGenerator);

            return new AuthenticationResponse() { Token = token, Email = user.Email,
                PersonName = user.Name, Expiration = expiration
            };

        }*/

    }
}
