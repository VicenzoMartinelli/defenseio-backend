namespace DefenseIO.Infra.Shared.ViewModels
{
  public class CommandResult<T>
  {
    public bool IsSuccess { get; set; }
    public T Body { get; set; }

    public CommandResult<T> ReturningSuccess()
    {
      IsSuccess = true;

      return this;
    }
    public CommandResult<T> ReturningSuccess(T obj)
    {
      Body = obj;
      IsSuccess = true;
      return this;
    }
  }
}
