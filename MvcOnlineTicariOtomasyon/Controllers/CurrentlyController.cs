using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CurrentlyController : Controller
    {
        // GET: Currently
        Context context = new Context();
        public ActionResult Index()
        {
            var currentlies = context.Currentlies.Where(x=>x.Status == true).ToList(); 
            return View(currentlies);
        }
        [HttpGet]
        public ActionResult AddCurrently()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCurrently(Currently currently)
        {
            currently.Status = true;
            context.Currentlies.Add(currently);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCurrently(int id)
        {
            var currently = context.Currentlies.Find(id);
            currently.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCurrently(int id)
        {
            var currently = context.Currentlies.Find(id);
            return View("GetCurrently", currently);
        }
        public ActionResult UpdateCurrently(Currently currently)
        {
            var value = context.Currentlies.Find(currently.Id);
            value.FirstName = currently.FirstName;
            value.LastName = currently.LastName;
            value.Mail = currently.Mail;
            value.City = currently.City;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CurrentlySale(int id)
        {
            var value = context.SaleMovements.Where(x => x.CurrentlyId == id).ToList();
            var currently = context.Currentlies.Where(x => x.Id == id).Select(y => y.FirstName + " " + y.LastName).FirstOrDefault();
            ViewBag.valueCurrently = currently;
            return View(value);
        }
    }
}