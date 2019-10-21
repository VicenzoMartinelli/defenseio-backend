using Microsoft.EntityFrameworkCore;

namespace DefenseIO.Services.Report.Data.Contexts
{
  public class ReportContext : DbContext
  {

    public ReportContext(DbContextOptions<ReportContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
  }
}
