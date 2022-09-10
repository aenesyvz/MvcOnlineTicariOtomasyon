using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        Context context = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            // var value = context.Products.ToList();
            cs.products = context.Products.Where(x => x.Id == 2).ToList();
            cs.details = context.Details.Where(y => y.Id == 2).ToList();
            return View(cs);
        }
    }
}