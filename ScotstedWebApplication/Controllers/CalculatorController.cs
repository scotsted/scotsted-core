using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ScotstedWebApplication.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Square(int value)
        {
            var result = value * value;
            var viewModel = new ResultViewModel
            {
                Result = result
            };
            return View(viewModel);
        }
    }
}
