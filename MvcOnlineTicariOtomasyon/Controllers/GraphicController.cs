using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GraphicController : Controller
    {
        // GET: Graphic
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var drawGraphic = new Chart(600, 400);
            drawGraphic.AddTitle("Kategori - Ürün sayısı").AddLegend("Stok")
                .AddSeries("Değerler", xValue: new[] {"A" }, yValues: new[] { 20}).Write();
            return File(drawGraphic.ToWebImage().GetBytes(), "image/jpg");
           
        }
        public ActionResult Index3()
        {
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();
            var result = context.Products.ToList();
            result.ToList().ForEach(x => xValue.Add(x.ProductName));
            result.ToList().ForEach(y => yValue.Add(y.UnitsInStock));
            var graphic = new Chart(width: 500, height: 500)
                .AddTitle("Stoklar")
                .AddSeries(chartType: "Pie", name: "Stok", xValue: xValue, yValues: yValue);
            return File(graphic.ToWebImage().GetBytes(), "image/jpg");
        }
        public ActionResult Index4()
        {
            
            return View();
        }
        public ActionResult VisualizeProductResult()
        {

            return Json(ProductList(),JsonRequestBehavior.AllowGet);
        }
        public List<Chart1> ProductList()
        {
            List<Chart1> chart = new List<Chart1>();
            chart.Add(new Chart1()
            {

            });
            chart.Add(new Chart1()
            {

            });
            return chart;
        }
        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeProductResult2()
        {
            return Json(ProductList2(), JsonRequestBehavior.AllowGet);
        }
        public List<Chart2> ProductList2()
        {
            List<Chart2> chart = new List<Chart2>();
            using(var context = new Context())
            {
                chart = context.Products.Select(x => new Chart2
                {
                    ProductName = x.ProductName,
                    UnitsInStock = x.UnitsInStock
                }).ToList();
            }
            
            return chart;
        }
        public ActionResult Index6()
        {
            return View();
        }
    }
}