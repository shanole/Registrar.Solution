using Microsoft.AspNetCore.Mvc;
using UniRegistrar.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft .EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniRegistrar.Controllers
{
  public class StudentsController : Controller
  {

    private readonly UniRegistrarContext _db;

    public StudentsController(UniRegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      IEnumerable<Student> sortedStudents = _db.Students.OrderBy(student => student.StudentName);
      return View(sortedStudents.ToList());
    }
    public ActionResult Create()
    {
      // List<Course> courseList= _db.Courses.ToList();
      // ViewBag.CourseList = courseList;
      ViewBag.CourseId = new MultiSelectList(_db.Courses, "CourseId", "CourseName");
      return View();
    }
  }
}