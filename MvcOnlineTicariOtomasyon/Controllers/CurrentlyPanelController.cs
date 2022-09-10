using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Classes;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CurrentlyPanelController : Controller
    {
        // GET: CurrentlyPanel
        Context context = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["Mail"];
            var value = context.Messages.Where(x => x.Receiver == mail).ToList();
            ViewBag.email = mail;
            var mailId = context.Currentlies.Where(x => x.Mail == mail).Select(y => y.Id).FirstOrDefault();
            ViewBag.mailId = mailId;
            var totalSale = context.SaleMovements.Where(x => x.CurrentlyId == mailId).Count();
            ViewBag.totalSale = totalSale;
            var sum = context.SaleMovements.Where(x => x.CurrentlyId == mailId).Sum(y =>(decimal?)y.Total);
            ViewBag.sum = sum;
            var totalProduct = context.SaleMovements.Where(x => x.CurrentlyId == mailId).Sum(y =>(int?)y.Amount);
            ViewBag.totalProduct = totalProduct;
            var firstNameLastName = context.Currentlies.Where(x => x.Mail == mail).Select(y => y.FirstName + " " + y.LastName).FirstOrDefault();
            ViewBag.firstNameLastName = firstNameLastName;
           
            return View(value);
        }
        public ActionResult Orders()
        {
            var mail = (string)Session["Mail"];
            var id = context.Currentlies.Where(x => x.Mail == mail.ToString()).Select(y => y.Id).FirstOrDefault();
            var orders = context.SaleMovements.Where(x => x.CurrentlyId == id).ToList();
            return View(orders);
        }
        public ActionResult MessageList()
        {
            var mail = (string)Session["Mail"];
            var messages = context.Messages.Where(x=>x.Receiver == mail).OrderByDescending(y=>y.Id).ToList();
            var gelen = context.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = gelen;
            var giden = context.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = giden;
            return View(messages);
        }
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["Mail"];
            var messages = context.Messages.Where(x => x.Sender == mail).OrderByDescending(y=>y.Id).ToList();
            var giden = context.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = giden;
            var gelen = context.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = gelen;
            return View(messages);
        }
        public ActionResult MessageDetail(int id)
        {
            var query = context.Messages.Where(x => x.Id == id).ToList();
            var mail = (string)Session["Mail"];
            var messages = context.Messages.Where(x => x.Sender == mail).ToList();
            var giden = context.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = giden;
            var gelen = context.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = gelen;
            return View(query);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            var mail = (string)Session["Mail"];
            var messages = context.Messages.Where(x => x.Sender == mail).ToList();
            var giden = context.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = giden;
            var gelen = context.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = gelen;
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            var mail = (string)Session["Mail"];
            message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.Sender = mail;
            context.Messages.Add(message);
            context.SaveChanges();
            return View();
        }
        public ActionResult CargoTracking(string p)
        {
            var values = from x in context.CargoDetails select x;
          
                values = values.Where(x => x.Code.Contains(p));
            
            return View(values.ToList());
        }
        public ActionResult CargoDetails(string id)
        {
            var cargo = context.CargoTrackings.Where(x => x.TrackingCode == id).ToList();

            return View(cargo);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult Partial1()
        {
            var mail = (string)Session["Mail"];
            var id = context.Currentlies.Where(x => x.Mail == mail).Select(y => y.Id).FirstOrDefault();
            var currently = context.Currentlies.Find(id);
            return PartialView("Partial1",currently);
        }
        public PartialViewResult Partial2()
        {
            var value = context.Messages.Where(x => x.Sender == "Admin").ToList();
            return PartialView(value);
        }
        public ActionResult UpdateInformation(Currently currently)
        {
            var value = context.Currentlies.Find(currently.Id);
            value.FirstName = currently.FirstName;
            value.LastName = currently.LastName;
            value.Password = currently.Password;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}