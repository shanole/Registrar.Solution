using Microsoft.AspNetCore.Mvc;
using UniRegistrar.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
      ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "DepartmentName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Student student)
    {
      _db.Students.Add(student);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisStudent = _db.Students
      .Include(student => student.JoinEntities)
      .ThenInclude(join => join.Course)
      .FirstOrDefault(student => student.StudentId == id);
      return View(thisStudent);
    }
    public ActionResult Edit(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
      ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "DepartmentName");
      return View(thisStudent);
    }
    [HttpPost]
    public ActionResult Edit(Student student)
    {
      _db.Entry(student).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = student.StudentId });
    }

    public ActionResult AddCourse(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseName");
      return View(thisStudent);
    }

    [HttpPost]
    public ActionResult AddCourse(Student student, int CourseId)
    {
      if (CourseId != 0)
      {
        if (_db.CourseStudent.Any(join => join.CourseId == CourseId && join.StudentId == student.StudentId) == false)
        {
          _db.CourseStudent.Add(new CourseStudent() { CourseId = CourseId, StudentId = student.StudentId });
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = student.StudentId });
    }

    public ActionResult Delete(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
      return View(thisStudent);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
      _db.Students.Remove(thisStudent);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteCourse(int joinId)
    {
      var joinEntry = _db.CourseStudent.FirstOrDefault(entry => entry.CourseStudentId == joinId);
      _db.CourseStudent.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = joinEntry.StudentId });
    }
  }
}