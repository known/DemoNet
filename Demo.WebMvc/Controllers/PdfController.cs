using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.WebMvc.Controllers
{
    public class PdfController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}