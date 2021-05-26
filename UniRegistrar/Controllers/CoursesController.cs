using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UniRegistrar.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UniRegistrar.Controllers
{
  public class CoursesController: Controller
  {
    private readonly UniRegistrarContext _db;

    public CoursesController(UniRegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      IEnumerable<Course> sortedCourses = _db.Courses.OrderBy(course => course.CourseNumber);
      return View(sortedCourses.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Course course)
    {
      _db.Courses.Add(course);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Course thisCourse = _db.Courses
        .Include(course => course.JoinEntities)
        .ThenInclude(join => join.Student)
        .FirstOrDefault(course => course.CourseId == id);
      return View(thisCourse);
    }
  }
}