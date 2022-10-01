using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieRate.Core.Interfaces;
using MovieRate.Core.Models;
using MovieRate.Infrastructure.Helpers;

namespace MovieRate.Infrastructure.Services;

public class TokenService : ITokenService
{
    private readonly JWT _jwt;
    private readonly SymmetricSecurityKey _key;
    private readonly UserManager<User> _userManager;

    public TokenService(IOptions<JWT> jwt, UserManager<User> userManager)
    {
        _userManager = userManager;
        _jwt = jwt.Value;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key!));
    }
    public string CreateToken(User user)
    {
        var roles = _userManager.GetRolesAsync(user).Result;
        var roleClaims = roles.Select(role => new Claim("role", role)).ToList();
        var claims = new []
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.GivenName, user.FirstName),
        }.Union(roleClaims);

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(_jwt.DurationInDays),
            SigningCredentials = creds,
            Issuer = _jwt.Issuer
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}