using JWT_Application.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace JWT_Application.Implementetion.Jwt_Web_Token
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _configuration;

        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string JwtWebToken(BookingDto request)
        {

            var authClaims = new List<Claim>
            {
                    new Claim(ClaimTypes.Name, request.UserName),
                    new Claim(ClaimTypes.NameIdentifier, request.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Email, request.Name),
                    new Claim("Id", request.Id)
            };

            //create signing key
               var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddYears(2),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );


            var tokenResponse = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenResponse;


        }


    }
}
