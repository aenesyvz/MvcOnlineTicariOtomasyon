using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        Context context = new Context();
        public ActionResult Index(string p)
        {
            var values = from x in context.CargoDetails select x;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(x => x.Code.Contains(p));
            }
            return View(values.ToList());
        }
        [HttpGet]
        public ActionResult AddCargo()
        {
            Random random = new Random();
            string[] characters = { "A", "B", "C", "D" };
            int c1, c2, c3;
            c1 = random.Next(0, 4);
            c2 = random.Next(0, 4);
            c3 = random.Next(0, 4);
            int s1, s2, s3;
            s1 = random.Next(100, 1000);
            s2 = random.Next(10, 99);
            s3 = random.Next(10, 99);
            string code = s1.ToString() + characters[c1] + s2.ToString() + characters[c2] + s3.ToString() + characters[c3];
            ViewBag.code = code;
            return View();
        }
        [HttpPost]
        public ActionResult AddCargo(CargoDetail cargoDetail)
        {
            context.CargoDetails.Add(cargoDetail);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CargoTracking(string id)
        {
            var cargo = context.CargoTrackings.Where(x => x.TrackingCode == id).ToList();
           
            return View(cargo);
        }
    }
}