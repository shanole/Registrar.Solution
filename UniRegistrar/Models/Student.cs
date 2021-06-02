using System.Collections.Generic;
using System;

namespace UniRegistrar.Models
{
  public class Student
  {
    public Student()
    {
      this.JoinEntities = new HashSet<CourseStudent>();
    }

    public int StudentId { get; set; }
    public string StudentName { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public virtual ICollection<CourseStudent> JoinEntities { get; }
    public virtual Department Department  { get; set; }

    public int DepartmentId { get; set; }
  }
}
