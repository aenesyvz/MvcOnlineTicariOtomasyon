using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        // GET: Department
        Context context = new Context();
        public ActionResult Index()
        {
            var departmens = context.Departments.ToList();
            return View(departmens);
        }
        [HttpGet]
        [Authorize(Roles ="A")]
        public ActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
   
        public ActionResult AddDepartment(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
     
        public ActionResult DeleteDepartment(int id)
        {
            var department = context.Departments.Find(id);
            department.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetDepartment(int id)
        {
            var department = context.Departments.Find(id);
            return View("GetDepartment", department);
        }
        public ActionResult UpdateDepartment(Department department)
        {
            var value = context.Departments.Find(department.Id);
            value.DepartmentName = department.DepartmentName;
            value.Status = department.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DetailDepartment(int id)
        {
            var staffs = context.Staffs.Where(x => x.DepartmentId == id).ToList();
            var department = context.Departments.Where(x => x.Id == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.valueDepartment = department;
            return View(staffs);
        }
        public ActionResult DepartmentStaffSales(int id)
        {
            var staffSale = context.SaleMovements.Where(x => x.StaffId == id).ToList();
            var staff = context.Staffs.Where(x => x.Id == id).Select(y=>y.FirstName + " " + y.LastName).FirstOrDefault();
            ViewBag.valueStaff = staff;
            return View(staffSale);
        }
    }
}