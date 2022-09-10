using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        Context context = new Context();
        public ActionResult Index()
        {
            var sales = context.SaleMovements.ToList();
            return View(sales);
        }
        [HttpGet]
        public ActionResult AddSale()
        {
            List<SelectListItem> products = (from x in context.Products.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.ProductName,
                                                 Value = x.Id.ToString()
                                             }).ToList();
            ViewBag.valueproduct = products;
            List<SelectListItem> currentlies = (from y in context.Currentlies.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = y.FirstName + " " + y.LastName,
                                                 Value = y.Id.ToString()
                                             }).ToList();
            ViewBag.valuecurrently = currentlies;
            List<SelectListItem> staffs = (from z in context.Staffs.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = z.FirstName + " " + z.LastName,
                                                    Value = z.Id.ToString()
                                                }).ToList();
            ViewBag.valuestaff = staffs;
            return View();
        }
        [HttpPost]
        public ActionResult AddSale(SaleMovement sale)
        {
            sale.SaleDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SaleMovements.Add(sale);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetSale(int id)
        {
            List<SelectListItem> products = (from x in context.Products.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.ProductName,
                                                 Value = x.Id.ToString()
                                             }).ToList();
            ViewBag.valueproduct = products;
            List<SelectListItem> currentlies = (from y in context.Currentlies.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = y.FirstName + " " + y.LastName,
                                                    Value = y.Id.ToString()
                                                }).ToList();
            ViewBag.valuecurrently = currentlies;
            List<SelectListItem> staffs = (from z in context.Staffs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = z.FirstName + " " + z.LastName,
                                               Value = z.Id.ToString()
                                           }).ToList();
            ViewBag.valuestaff = staffs;
            var sale = context.SaleMovements.Find(id);
            return View("GetSale", sale);
        }
        public ActionResult UpdateSale(SaleMovement sale)
        {
            var value = context.SaleMovements.Find(sale.Id);
            value.ProductId = sale.ProductId;
            value.CurrentlyId = sale.CurrentlyId;
            value.StaffId = value.StaffId;
            value.Amount = sale.Amount;
            value.UnitPrice = sale.UnitPrice;
            value.Total = sale.Total;
            value.SaleDate = sale.SaleDate;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SaleDetail(int id)
        {
            var value = context.SaleMovements.Where(x => x.Id == id).ToList();
            return View(value);
        }
    }
}