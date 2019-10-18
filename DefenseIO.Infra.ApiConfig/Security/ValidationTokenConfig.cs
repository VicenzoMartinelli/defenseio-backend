namespace DefenseIO.Infra.ApiConfig.Security
{
  public class ValidationTokenConfig
  {
    public string Secret { get; set; }
    public int Hours { get; set; }
    public string Audience { get; set; }
  }
}
