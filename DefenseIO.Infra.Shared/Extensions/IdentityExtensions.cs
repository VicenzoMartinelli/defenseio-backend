using DefenseIO.Infra.Shared.Notifications;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace DefenseIO.Infra.Shared.Extensions
{
  public static class IdentityExtensions
  {
    public static IEnumerable<Notification> ExtractNotificationsFromIdentityErrors(this IEnumerable<IdentityError> errors)
    {
      return errors.Select(x => new Notification(string.Empty, x.Code, string.Empty, x.Description)).Distinct();
    }
  }
}
