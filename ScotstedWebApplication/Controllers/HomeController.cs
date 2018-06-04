using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScotstedWebApplication.Models;
using ScotstedWebApplication.Services;

namespace ScotstedWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private SearchService _searchService;

        public HomeController()
        {
            this._searchService = new SearchService();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string Index2()
        {
            return "Hello world!";
        }

        public IActionResult Search(SearchModel searchModel)
        {
            if (ModelState.IsValid)
            {
                var viewModel = _searchService.Search(searchModel);
                return View(viewModel);
            }
            return Redirect("/");
        }

    }
}
