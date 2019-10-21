using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace DefenseIO.Infra.Shared.Notifications
{
  public class NotificationContext
  {
    private readonly List<Notification> _notifications;
    public IReadOnlyCollection<Notification> Notificacoes => _notifications;
    public virtual bool PossuiNotificacoes => _notifications.Any();

    public static readonly string[] SIZE_VALIDATORS = {
            "MaxLenth", "MinLength", "LessThan", "GreaterThan", "LessThanOrEqualTo", "GreaterThanOrEqualTo"
        };

    public NotificationContext()
    {
      _notifications = new List<Notification>();
    }

    public void Unauthorized(string code, string description)
    {
      PushNotification(string.Empty, code, string.Empty, description, 401);
    }

    public void Forbidden(string code, string description)
    {
      PushNotification(string.Empty, code, string.Empty, description, 403);
    }

    public void NotFound(string code, string description)
    {
      PushNotification(string.Empty, code, string.Empty, description, 404);
    }

    public void BadRequest(string code, string description)
    {
      PushNotification(string.Empty, code, string.Empty, description, 400);
    }

    public void BadRequest(string campo, string code, string description)
    {
      PushNotification(campo, code, string.Empty, description, 400);
    }

    public void BadRequest(IEnumerable<Notification> notificacoes)
    {
      PushNotifications(notificacoes);
    }

    public void BadRequest(IReadOnlyCollection<Notification> notificacoes)
    {
      PushNotifications(notificacoes);
    }

    public void BadRequest(IList<Notification> notificacoes)
    {
      PushNotifications(notificacoes);
    }

    public void BadRequest(ICollection<Notification> notificacoes)
    {
      PushNotifications(notificacoes);
    }

    public void BadRequest(ValidationResult validationResult)
    {
      PushNotifications(validationResult);
    }

    private void PushNotification(string campo, string code, string valor, string description, int status = 0)
    {
      _notifications.Add(new Notification(campo, code, valor, description, status));
    }

    public void PushNotifications(IEnumerable<Notification> notificacoes)
    {
      _notifications.AddRange(notificacoes);
    }

    private void PushNotifications(IReadOnlyCollection<Notification> notificacoes)
    {
      _notifications.AddRange(notificacoes);
    }

    private void PushNotifications(IList<Notification> notificacoes)
    {
      _notifications.AddRange(notificacoes);
    }

    private void PushNotifications(ICollection<Notification> notificacoes)
    {
      _notifications.AddRange(notificacoes);
    }

    private void PushNotifications(ValidationResult validationResult)
    {
      var valor = string.Empty;

      validationResult.Errors.ToList().ForEach(error =>
      {
        var valores = error
            .FormattedMessagePlaceholderValues
            .Where(v => SIZE_VALIDATORS.Contains(v.Key))
            .ToList();

        if (valores.Count > 0)
        {
          valor = valores.Select(v => v.Value.ToString()).First();
        }
        else
        {
          valor = string.Empty;
        }

        PushNotification(error.PropertyName, error.ErrorCode, valor, error.ErrorMessage);
      });
    }

    public virtual IEnumerable<Notification> GetNotifications()
    {
      return _notifications;
    }
  }
}
