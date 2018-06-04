using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ScotstedWebApplication.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult View2()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
