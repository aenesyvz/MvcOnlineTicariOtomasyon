using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        Context context = new Context();
        public ActionResult Index()
        {
            var list = context.Bill.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult AddBill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBill(Bill bill)
        {
            context.Bill.Add(bill);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetBill(int id)
        {
            var bill = context.Bill.Find(id);
            return View("GetBill", bill);
        }
        public ActionResult UpdateBill(Bill bill)
        {
            var value = context.Bill.Find(bill.Id);
            value.SerialNumber = bill.SerialNumber;
            value.SequenceNumber = bill.SequenceNumber;
            value.TaxAdministration = bill.TaxAdministration;
            value.BillDate = bill.BillDate;
            value.BillTime = bill.BillTime;
            value.Submitter = bill.Submitter;
            value.DeliveryArea = bill.DeliveryArea;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DetailBill(int id)
        {
            var value = context.BillPens.Where(x => x.BillId == id).ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult NewPen()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewPen(BillPen billPen)
        {
            context.BillPens.Add(billPen);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DinamicBill()
        {
            Class3 cs = new Class3();
            cs.value1 = context.Bill.ToList();
            cs.value2 = context.BillPens.ToList();
            return View(cs);
        }
        public ActionResult SaveBill(string SerialNumber,string SequenceNumber,DateTime BillDate,string TaxAdministration,string BillTime,string DeliveryArea,string Submitter,string Total,BillPen[] pens)
        {
            Bill bill = new Bill();
            bill.SerialNumber = SerialNumber;
            bill.SequenceNumber = SequenceNumber;
            bill.BillDate = BillDate;
            bill.BillTime = BillTime;
            bill.DeliveryArea = DeliveryArea;
            bill.Submitter = Submitter;
            bill.TaxAdministration = TaxAdministration;
            bill.Total = decimal.Parse(Total);
            context.Bill.Add(bill);
            foreach(var x in pens)
            {
                BillPen pen = new BillPen();
                pen.Statement = x.Statement;
                pen.UnitPrice = x.UnitPrice;
                pen.Total = x.Total;
                pen.Amount = x.Amount;
                pen.BillId = x.Id;
                context.BillPens.Add(pen);
            }
            context.SaveChanges();
            return Json("İşlem başarılı", JsonRequestBehavior.AllowGet);
        }
      
    }
}