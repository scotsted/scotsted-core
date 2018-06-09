using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ScotstedWebApplication.Controllers
{
    public class CurrenciesController : Controller
    {
        public IActionResult Index()
        {
            //var url = Url.Action("View2", "Currencies", new { code = "GBP" });
            var url = Url.RouteUrl("view_currency", new { code = "GBP" });
            return Content($"The URL is {url}");
        }

        public IActionResult View2(string code)
        {
            return View();
        }

        //public IActionResult View2()
        //{
        //    return View();
        //}

        public IActionResult RedirectingToAnActionMethod()
        {
            return RedirectToAction("View2", "Currencies", new { id = 5 });
        }

        public IActionResult RedirectingToARoute()
        {
            return RedirectToRoute("view_currency", new { code = "GBP" });
        }

        public IActionResult RedirectingToAnActionInTheSameController()
        {
            return RedirectToAction("Index");
        }

    }
}