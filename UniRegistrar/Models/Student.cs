using System.Collections.Generic;

namespace UniRegistrar.Models
{
  public class Student
  {
    public Student()
    {
      this.joinEntities = new HashSet<CourseStudent>();
    }

    public int StudentId { get; set; }
    public string StudentName { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public virtual ICollection<CourseStudent> JoinEntities { get; }

  }

}
