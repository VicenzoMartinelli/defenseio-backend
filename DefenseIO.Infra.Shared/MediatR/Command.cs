using DefenseIO.Infra.Shared.ViewModels;
using MediatR;

namespace DefenseIO.Infra.Shared.MediatR
{
  public class Command<T> : IRequest<CommandResult<T>>
  { }
}
