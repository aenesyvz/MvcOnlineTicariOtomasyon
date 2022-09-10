using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        Context context = new Context();
        public ActionResult Index()
        {
            var query1 = context.Currentlies.Count().ToString();
            ViewBag.d1 = query1;
            var query2 = context.Products.Count().ToString();
            ViewBag.d2 = query2;
            var query3 = context.Categories.Count().ToString();
            ViewBag.d3 = query3;
            var query4 = context.Currentlies.Distinct().Count().ToString();
            ViewBag.d4 = query4;
            var query5 = context.toDos.ToList();
          
            return View(query5);
        }
    }
}