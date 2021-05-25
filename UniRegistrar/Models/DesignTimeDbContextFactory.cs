using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace UniRegistrar.Models
{
  public class UniRegistrarContextFactory : IDesignTimeDbContextFactory<UniRegistrarContext>
  {

    UniRegistrarContext IDesignTimeDbContextFactory<UniRegistrarContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<UniRegistrarContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new UniRegistrarContext(builder.Options);
    }
  }
}