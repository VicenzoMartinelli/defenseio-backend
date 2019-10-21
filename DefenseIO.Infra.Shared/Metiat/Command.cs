using DefenseIO.Infra.Shared.ViewModels;
using MediatR;

namespace DefenseIO.Infra.Shared.Metiat
{
  public class Command<T> : IRequest<CommandResult<T>>
  { }
}
