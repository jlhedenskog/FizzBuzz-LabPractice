using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FizzBuzz_LabPractice.Models;
using System.Text;

namespace FizzBuzz_LabPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Solve()
        {
            ViewData["FizzBuzzOutput"] = new string[0];
            return View();
        }

        [HttpPost]
        public IActionResult Solve(int userNum1, int userNum2)
        {
            var output = "";

            for (var i = 1; i <= 100; i++)
            {

                var fizzBug = i % userNum1;
                var buzzBug = i % userNum2;
                
                if (fizzBug == 0 && buzzBug == 0)
                {
                    output += "FizzBuzz "; 
                }
                else if (fizzBug == 0)
                {
                    output += "Fizz ";
                }
                else if (buzzBug == 0)
                {
                    output += "Buzz ";
                }
                else
                {
                    output += i + " ";
                }
            }

            ViewData["FizzBuzzOutput"] = output.Split(" ");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
