using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestTask.Domain.Entities;

namespace TestTask.Application.Implementations.Services;

public static class JwtTokenHelper
{
	public static string GenerateToken(User user, JwtOptions jwtOptions)
	{
		var expiredDate = DateTime.UtcNow.AddHours(1);
		var claims = new List<Claim>()
		{
			new Claim(JwtRegisteredClaimNames.Email, user.Email),
			new Claim(JwtRegisteredClaimNames.Sub, user.Id.Value.ToString()),
			new Claim(JwtRegisteredClaimNames.Exp, expiredDate.ToString())
		};

		var signingCredentials = new SigningCredentials(
			new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
			SecurityAlgorithms.HmacSha256
			);

		var token = new JwtSecurityToken(
			jwtOptions.Issuer,
			jwtOptions.Audience,
			claims,
			null,
			expiredDate,
			signingCredentials
			);

		string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

		return tokenValue;
	}
}

public class JwtOptions
{
	public required string Audience { get; init; }

	public required string Issuer { get; init; }

	public required string SecretKey { get; init; }
}