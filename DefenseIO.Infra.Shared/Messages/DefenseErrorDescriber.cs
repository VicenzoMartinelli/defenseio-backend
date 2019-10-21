using Microsoft.AspNetCore.Identity;

namespace DefenseIO.Infra.Shared.Messages
{
  public class DefenseErrorDescriber : IdentityErrorDescriber
  {
    public override IdentityError DefaultError()
    {
      return new IdentityError()
      {
        Code = nameof(Messages.InternalError),
        Description = Messages.InternalError
      };
    }

    public override IdentityError ConcurrencyFailure()
    {
      return DefaultError();
    }

    public override IdentityError DuplicateEmail(string email)
    {
      return new IdentityError()
      {
        Code = nameof(Messages.ExistsWithSameEmail),
        Description = Messages.ExistsWithSameEmail
      };
    }

    public override IdentityError PasswordMismatch()
    {
      return new IdentityError()
      {
        Code = nameof(Messages.InvalidCredentials),
        Description = Messages.InvalidCredentials
      };
    }

    public override IdentityError PasswordTooShort(int length)
    {
      return new IdentityError()
      {
        Code = nameof(Messages.InvalidPassword),
        Description = Messages.InvalidPassword
      };
    }

    public override IdentityError PasswordRequiresNonAlphanumeric()
    {
      return new IdentityError()
      {
        Code = nameof(Messages.InvalidPassword),
        Description = Messages.InvalidPassword
      };
    }

    public override IdentityError PasswordRequiresDigit()
    {
      return new IdentityError()
      {
        Code = nameof(Messages.InvalidPassword),
        Description = Messages.InvalidPassword,
      };
    }

    public override IdentityError DuplicateUserName(string userName)
    {
      return new IdentityError()
      {
        Code = nameof(Messages.ExistsWithSameIdentifier),
        Description = Messages.ExistsWithSameIdentifier,
      };
    }

    public override IdentityError LoginAlreadyAssociated()
    {
      return DuplicateEmail(string.Empty);
    }

    public override IdentityError InvalidUserName(string userName)
    {
      return InvalidEmail(userName);
    }

    public override IdentityError InvalidEmail(string email)
    {
      return new IdentityError()
      {
        Code = nameof(Messages.InvalidEmail),
        Description = Messages.InvalidEmail
      };
    }

    public override IdentityError InvalidToken()
    {
      return new IdentityError()
      {
        Code = nameof(Messages.InvalidToken),
        Description = Messages.InvalidToken
      };
    }

    public override IdentityError RecoveryCodeRedemptionFailed()
    {
      return new IdentityError()
      {
        Code = nameof(Messages.InvalidToken),
        Description = Messages.InvalidToken
      };
    }
  }
}
