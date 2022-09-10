using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
using PagedList;
using PagedList.Mvc;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context context = new Context();
        public ActionResult Index(int page = 1)
        {
            var values = context.Categories.ToList().ToPagedList(page,10);
            return View(values);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var category = context.Categories.Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCategory(int id)
        {
            var category = context.Categories.Find(id);
            return View("GetCategory", category);
        }
        public ActionResult UpdateCategory(Category category)
        {
            var value = context.Categories.Find(category.Id);
            value.CategoryName = category.CategoryName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Try()
        {
            Class2 cs = new Class2();
            cs.Categories = new SelectList(context.Categories, "Id", "CategoryName");
            cs.Products = new SelectList(context.Products, "Id", "ProductName");
            return View(cs);
        }
        public ActionResult Try2(int p)
        {
            var value = (from x in context.Products
                         join y in context.Categories on x.Category.Id equals y.Id
                         where x.Category.Id == p
                         select new
                         {
                             Text = x.ProductName,
                             Value = x.Id.ToString()
                         }).ToList();
            return Json(value, JsonRequestBehavior.AllowGet);
        }
    }
}