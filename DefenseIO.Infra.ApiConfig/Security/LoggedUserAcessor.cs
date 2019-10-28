using DefenseIO.Domain.Domains.Users;
using DefenseIO.Domain.Domains.Users.Interfaces;
using DefenseIO.Infra.Shared.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace DefenseIO.Infra.ApiConfig.Security
{
  public class LoggedUserAcessor : ILoggedUserAcessor
  {
    private readonly IHttpContextAccessor _accessor;
    private readonly ClaimsPrincipal _userClaims;
    private Guid _userId = Guid.Empty;
    private UserType _type = (UserType)999;
    private string _name = null;
    private string _email = null;

    public LoggedUserAcessor(
        IHttpContextAccessor accessor
    )
    {
      _accessor = accessor;
      _userClaims = _accessor.HttpContext.User;
      _userId = Guid.Empty;
    }
    public Guid UserId => _userId = _userId.Equals(Guid.Empty) ?
                                            Guid.Parse(Claims.Single(x => x.Type.Equals(ClaimTypes.NameIdentifier)).Value) : _userId;

    public UserType Type => _type = (int)_type == 999 ? Claims.Single(x => x.Type.Equals(CustomClaims.UserTypeClaim)).Value.FromNumericString<UserType>() : _type;

    public string Name => _name = !_name.IsPresent() ? Claims.Single(x => x.Type.Equals(JwtRegisteredClaimNames.UniqueName)).Value : _name;

    public string Email => _email = !_email.IsPresent() ? Claims.Single(x => x.Type.Equals(ClaimTypes.Email)).Value : _email;

    public IEnumerable<Claim> Claims => _userClaims.Claims;
  }
}
