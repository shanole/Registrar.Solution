using Microsoft.AspNetCore.Mvc;
using UniRegistrar.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniRegistrar.Controllers
{
 public class DepartmentsController : Controller
 {
   private readonly UniRegistrarContext _db;
   public DepartmentsController(UniRegistrarContext db)
   {
     _db = db;
   } 
   public ActionResult Index()
   {
     IEnumerable<Department> departments = _db.Departments.OrderBy(department => department.DepartmentName);
     return View(departments.ToList());
   }

   public ActionResult Create()
   {
     return View();
   }

   [HttpPost]
   public ActionResult Create(Department department)
   {
     _db.Departments.Add(department);
     _db.SaveChanges();
     return RedirectToAction("Index");
   }

   public ActionResult Details(int id)
   {
     var thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
     return View(thisDepartment);
   }
   public ActionResult Edit(int id)
   {
     var thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
     return View(thisDepartment);
   }
   [HttpPost]
   public ActionResult Edit(Department department)
   {
    _db.Entry(department).State = EntityState.Modified;
    _db.SaveChanges();
    return RedirectToAction("Details", new {id = department.DepartmentId});
   }
   public ActionResult Delete(int id)
   {
      var thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
     return View(thisDepartment); 
   }
   [HttpPost, ActionName("Delete")]
   public ActionResult DeleteConfirmed(int id)
   {
     Department thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
     _db.Departments.Remove(thisDepartment);
     _db.SaveChanges();
     return RedirectToAction("Index");
   }
 } 
}