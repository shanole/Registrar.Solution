using Microsoft.AspNetCore.Mvc;
using UniRegistrar.Models;
using System.Collections.Generic;
using System.Linq;


namespace UniRegistrar.Controllers
{
  public class HomeController : Controller
  {
    private readonly UniRegistrarContext _db;

    public HomeController(UniRegistrarContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      // IEnumerable<Student> sortedStudents = _db.Students.OrderBy(student => student.StudentName);
      // ViewBag.StudentObj = sortedStudents.ToList();
      ViewBag.StudentObj = new List<Student>(_db.Students.OrderBy(student => student.StudentName));

      IEnumerable<Course> sortedCourses = _db.Courses.OrderBy(course => course.CourseName);
      ViewBag.CourseObj = sortedCourses.ToList();
      return View();
    }
  }
}