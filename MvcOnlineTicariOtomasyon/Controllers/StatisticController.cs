using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        Context context = new Context();
        public ActionResult Index()
        {
            var value1 = context.Currentlies.Count().ToString();
            ViewBag.d1 = value1;
            var value2 = context.Products.Count().ToString();
            ViewBag.d2 = value2;
            var value3 = context.Staffs.Count().ToString();
            ViewBag.d3 = value3;
            var value4 = context.Categories.Count().ToString();
            ViewBag.d4 = value4;
            var value5 = context.Products.Sum(x=>x.UnitsInStock).ToString();
            ViewBag.d5 = value5;
            var value6 = (from x in context.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.d6 = value6;
            var value7 = context.Products.Count(x=>x.UnitsInStock <= 20).ToString();
            ViewBag.d7 = value7;
            var value8 = (from x in context.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = value8;
            var value9 = (from x in context.Products orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = value9;
            var value10 = context.Products.Count(x => x.ProductName == "Buzdolabı").ToString();
            ViewBag.d10 = value10;
            var value11 = context.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.d11 = value11;
            var value12 = context.Products.GroupBy(x => x.Brand).OrderByDescending(y => y.Count()).Select(z=>z.Key).FirstOrDefault();
            ViewBag.d12 = value12;
            var value13 = context.Products.Where(q=>q.Id == context.SaleMovements.GroupBy(x=>x.ProductId).OrderByDescending(y=>y.Count()).Select(z=>z.Key).FirstOrDefault()).Select(t=>t.ProductName).FirstOrDefault();
            ViewBag.d13 = value13;
            var value14 = context.SaleMovements.Sum(x=>x.Total).ToString();
            ViewBag.d14 = value14;
            DateTime today = DateTime.Today;
            var value15 = context.SaleMovements.Count(x=>x.SaleDate == today).ToString();
            ViewBag.d15 = value15;
            var value16 = context.SaleMovements.Where(x => x.SaleDate == today).Sum(y=>(decimal?)y.Total).ToString();
            ViewBag.d16 = value16;
            return View();
        }
        public ActionResult EasyTables()
        {
            var value = from x in context.Currentlies
                        group x by x.City into y
                        select new GroupClass
                        {
                            City = y.Key,
                            Total = y.Count()
                        };
            return View(value.ToList());
        }
        public PartialViewResult Partial()
        {
            var query = from x in context.Staffs
                        group x by x.Department.DepartmentName into y
                        select new Group2
                        {
                            Id = y.Key,
                            Total = y.Count()
                        };
            return PartialView(query.ToList());
        }
        public PartialViewResult Partial2()
        {
            var query = context.Currentlies.ToList();
                       
            return PartialView(query);
        }
        public PartialViewResult Partial3()
        {
            var query = context.Products.ToList();

            return PartialView(query);
        }
        public PartialViewResult Partial4()
        {
            var query = from x in context.Products
                        group x by x.Brand into y
                        select new Group3
                        {
                            Brand = y.Key,
                            Total = y.Count()
                        };

            return PartialView(query.ToList());
        }
    }
}