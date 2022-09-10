using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context context = new Context();
        public ActionResult Index(string p)
        {
            var products = from x in context.Products select x;
            if (!string.IsNullOrEmpty(p))
            {
                products = products.Where(x => x.ProductName.Contains(p));
            }
            return View(products.ToList());
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> value = (from x in context.Categories.ToList() select new SelectListItem
            {
                Text=x.CategoryName,
                Value=x.Id.ToString()
            }).ToList();
            ViewBag.valueCategory = value;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id)
        {
            var product = context.Products.Find(id);
            product.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetProduct(int id)
        {
            var product = context.Products.Find(id);

            List<SelectListItem> value = (from x in context.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.Id.ToString()
                                          }).ToList();
            ViewBag.valueCategory = value;
            return View("GetProduct", product);
        }
        public ActionResult UpdateProduct(Product product)
        {
            var value = context.Products.Find(product.Id);
            value.ProductName = product.ProductName;
            value.CategoryId = product.CategoryId;
            value.Brand = product.Brand;
            value.PurchasePrice = product.PurchasePrice;
            value.SalePrice = product.SalePrice;
            value.UnitsInStock = product.UnitsInStock;
            value.ProductImage = product.ProductImage;
            value.Status = product.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult ProductList()
        {
            var value = context.Products.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult MakeSale(int id)
        {
            List<SelectListItem> value = (from x in context.Staffs.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.FirstName + " " + x.LastName,
                                              Value = x.Id.ToString()
                                          }).ToList() ;
            ViewBag.valueStaff = value;
            var value2 = context.Products.Find(id);
            ViewBag.valueId = value2.Id;
            ViewBag.valuePrice = value2.SalePrice;
            return View();
        }
        [HttpPost]
        public ActionResult MakeSale(SaleMovement saleMovement)
        {
            saleMovement.SaleDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SaleMovements.Add(saleMovement);
            context.SaveChanges();
            return RedirectToAction("Index","Sale");
        }
    }
}