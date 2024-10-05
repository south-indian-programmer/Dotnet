using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTGenerator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
			var token = GenerateJwtToken();
			Console.WriteLine(token);
			ValidateJwtToken(token);
		}
		static string GenerateJwtToken()
		{
			SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_secure_and_awesome_secret_key"));
			SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var claims = new List<Claim>(){
					new Claim("sub", "xxx"),
					new Claim("name", "yyy"),
					new Claim("aud", "zzzz"),
					new Claim("email", "person@mail.com"),
				};

			var jwtToken = new JwtSecurityToken(
				signingCredentials: credentials,
				audience: "programmers",
				claims: claims,
				expires: DateTime.Now.AddMinutes(30),
				issuer: "kuppu");
			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
			string token = handler.WriteToken(jwtToken);
			return token;
		}
		static void ValidateJwtToken(string token)
		{
			try
			{
				TokenValidationParameters parameters = new TokenValidationParameters()
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = "kuppu",
					ValidAudience = "programmers",// change here something to throw error for invalid token
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_secure_and_awesome_secret_key"))
				};
				var tokenHandler = new JwtSecurityTokenHandler();
				tokenHandler.ValidateToken(token, parameters, out SecurityToken validatedToken);

				Console.WriteLine(validatedToken.Issuer);
				Console.WriteLine(validatedToken.Id);
				Console.WriteLine(validatedToken.ValidTo);
				Console.WriteLine(validatedToken.SigningKey);
			}
			catch (Exception e)
			{
                Console.WriteLine(e.Message);
            }
		}
	}
}
