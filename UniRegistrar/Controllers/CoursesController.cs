using Microsoft.AspNetCore.Mvc;
using UniRegistrar.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
      ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "DepartmentName");
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

    public ActionResult Edit(int id)
    {
      ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "DepartmentName");
      Course thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
      return View(thisCourse);
    }

    [HttpPost]
    public ActionResult Edit(Course course)
    {
      _db.Entry(course).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = course.CourseId});
    }

    public ActionResult Delete(int id)
    {
      Course thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
      return View(thisCourse);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Course thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
      _db.Courses.Remove(thisCourse);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}