using Microsoft.IdentityModel.Tokens;
using ScoreYourPointApi.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ScoreYourPoint.Infra.Utils.JWT
{
    public static class JwtManager
    {
        public static string Authenticate(this User user)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.ASCII.GetBytes(JwtSettings.Secret);

            Claim claimAdmin1 = new(ClaimTypes.NameIdentifier, user.Id.ToString());
            Claim claimAdmin3 = new(ClaimTypes.Email, user.Email);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new List<Claim>
                {
                    claimAdmin1,
                    claimAdmin3,
                }),
                Expires = DateTime.UtcNow.AddHours(JwtSettings.Expires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };


            var securitytoken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securitytoken);

            return token;
        }
    }
    public static class JwtSettings
    {
        public static string Secret = "f82tv8jzljgiymv852q6bn5udah9u6wq8ftyf7vz";

        public static int Expires = 2;
    }
}
