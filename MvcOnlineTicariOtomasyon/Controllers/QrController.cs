using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class QrController : Controller
    {
        // GET: Qr
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string id)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator createCode = new QRCodeGenerator();
                QRCodeGenerator.QRCode code = createCode.CreateQrCode(id, QRCodeGenerator.ECCLevel.Q);
                using(Bitmap picture = code.GetGraphic(10))
                {
                    picture.Save(ms, ImageFormat.Png);
                    ViewBag.codeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    }
}