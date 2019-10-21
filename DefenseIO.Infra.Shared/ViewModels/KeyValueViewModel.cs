namespace DefenseIO.Infra.Shared.ViewModels
{
  public class KeyValueViewModel
  {
    public string Key { get; set; }
    public object Value { get; set; }

    public KeyValueViewModel()
    {
    }

    public KeyValueViewModel(string key, object value)
    {
      Key = key;
      Value = value;
    }
  }
}
