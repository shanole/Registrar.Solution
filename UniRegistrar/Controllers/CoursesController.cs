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
  }
}