using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        Context context = new Context();
        public ActionResult Index()
        {
            var staffs = context.Staffs.ToList();
            return View(staffs);
        }
        [HttpGet]
        public ActionResult AddStaff()
        {
            List<SelectListItem> value = (from x in context.Departments.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmentName,
                                              Value = x.Id.ToString()
                                          }).ToList();
            ViewBag.departments = value;
            return View();
        }
        [HttpPost]
        public ActionResult AddStaff(Staff staff)
        {
            if(Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string way = "~/Image/" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(way));
                staff.Image = "/Image/" + fileName + way;
            }
            context.Staffs.Add(staff);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetStaff(int id)
        {
            List<SelectListItem> departments = (from x in context.Departments.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.DepartmentName,
                                                    Value = x.Id.ToString()
                                                }
                                                ).ToList();
            var staff = context.Staffs.Find(id);
            ViewBag.valueDepartments = departments;
            return View("GetStaff",staff);
        }
        public ActionResult UpdateStaff(Staff staff)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string way = "~/Image/" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(way));
                staff.Image = "/Image/" + fileName + way;
            }
            var value = context.Staffs.Find(staff.Id);
            value.FirstName = staff.FirstName;
            value.LastName = staff.LastName;
            value.Image = staff.Image;
            value.DepartmentId = staff.DepartmentId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult StaffList()
        {
            var query = context.Staffs.ToList();
            return View(query);
        }
    }
}