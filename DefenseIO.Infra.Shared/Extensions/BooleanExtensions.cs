namespace DefenseIO.Infra.Shared.Extensions
{
  public static class BooleanExtensions
  {
    public static bool AsBool(this byte value) => value == 1;
    public static bool AsBool(this short value) => value == 1;
    public static byte AsByte(this bool value) => (byte)(value ? 1 : 0);
  }
}
