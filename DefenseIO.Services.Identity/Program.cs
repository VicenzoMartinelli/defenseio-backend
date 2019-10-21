using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DefenseIO.Services.Identity
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args)
    {
      var isIisExpress = System.Diagnostics.Process.GetCurrentProcess().ProcessName.Equals("iisexpress");

      return WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>();
    }
  }
}
