using DefenseIO.Domain.Domains.Users;
using DefenseIO.Domain.Domains.Users.ViewModels;
using DefenseIO.Infra.ApiConfig.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DefenseIO.Services.Identity.Services
{
  public class AuthenticationService
  {
    private readonly IOptions<ValidationTokenConfig> _tokenConfigsOptions;
    public AuthenticationService(
        IOptions<ValidationTokenConfig> tokenConfigsOptions)
    {
      _tokenConfigsOptions = tokenConfigsOptions;
    }

    public async Task<TokenViewModel> GenerateToken(User user)
    {
      var options = _tokenConfigsOptions.Value;
      var identityClaims = new ClaimsIdentity();

      identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Email, user.Email));
      identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
      identityClaims.AddClaim(new Claim(ClaimTypes.Email, user.Email));
      identityClaims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

      var dataCriacao = DateTime.UtcNow;
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(options.Secret);
      var dataExpiracao = dataCriacao.AddHours(options.Hours);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = identityClaims,
        Issuer = options.Audience,
        Expires = dataExpiracao,
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };

      return new TokenViewModel
      {
        AccessToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)),
        Exp = dataExpiracao,
        CreatedAt = dataCriacao
      };
    }
  }
}
