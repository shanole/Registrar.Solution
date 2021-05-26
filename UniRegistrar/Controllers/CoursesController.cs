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
      List<Course> model = _db.Courses.ToList();
      return View(model);
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
  }
}