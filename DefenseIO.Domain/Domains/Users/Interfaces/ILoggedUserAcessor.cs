using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace DefenseIO.Domain.Domains.Users.Interfaces
{
  public interface ILoggedUserAcessor
  {
    Guid UserId { get; }
    UserType Type { get; }
    string Name { get; }
    string Email { get; }
    IEnumerable<Claim> Claims { get; }
  }
}
