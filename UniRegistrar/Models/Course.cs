using System.Collections.Generic;

namespace UniRegistrar.Models
{
  public class Course
  {

    public Course()
    {
      this.JoinEntities = new HashSet<CourseStudent>();
    }

    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public string CourseNumber {get; set; }

    public string CourseDescription { get; set; }

    public virtual ICollection<CourseStudent> JoinEntities { get; set; }  // many-to-many
    public virtual Department Department  { get; set; }  //one-to-many
    public int DepartmentId { get; set; }
  }
}

