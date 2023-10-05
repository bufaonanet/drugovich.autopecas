using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using drugovich.autopecas.application.Contracts.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace drugovich.autopecas.infrastructure.Auth;

public class AuthService  : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly SymmetricSecurityKey _securityKey;
    private readonly JwtSecurityTokenHandler _tokenHandler;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
        _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        _tokenHandler = new JwtSecurityTokenHandler();
    }

    public string GenerateJwtToken(string email, string nivelAcesso)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(nivelAcesso))
        {
            throw new ArgumentException("Email e nivelAcesso não podem ser vazios!");
        }
        
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        
        var credentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);
        
        var claims = new List<Claim>
        {
            new Claim("userName", email),
            new Claim(ClaimTypes.Role, nivelAcesso)
        };
        
        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials,
            claims: claims);

        return _tokenHandler.WriteToken(token);
        
    }
}