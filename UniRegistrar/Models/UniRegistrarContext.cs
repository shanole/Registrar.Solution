using Microsoft.EntityFrameworkCore;

namespace UniRegistrar.Models
{
  public class UniRegistrarContext : DbContext
  {
    public virtual DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<CourseStudent> CourseStudent {get; set; }

    public UniRegistrarContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}

//each DbSet we've included will become a table in our database. CategoryItem DbSet will represent the join table