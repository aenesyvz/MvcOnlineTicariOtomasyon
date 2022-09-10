using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Classes;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Currently currently)
        {
            context.Currentlies.Add(currently);
            context.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult Partial2()
        {
            return View();
        }
        [HttpPost]
        public  ActionResult Partial2(Currently currently)
        {
            var query = context.Currentlies.FirstOrDefault(x => x.Mail == currently.Mail && x.Password == currently.Password);
            if(query != null)
            {
                FormsAuthentication.SetAuthCookie(query.Mail, false);
                Session["Mail"] = query.Mail.ToString();
                return RedirectToAction("Index", "CurrentlyPanel");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
          
        }
        [HttpGet]
        public ActionResult Partial3()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Partial3(Admin admin)
        {
            var query = context.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (query != null)
            {
                FormsAuthentication.SetAuthCookie(query.UserName, false);
                Session["UserName"] = query.UserName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
    }
}