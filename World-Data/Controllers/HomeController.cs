using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using World_Data.Models;

namespace World_Data.Controllers
{
    public class HomeController : Controller
    {
        WorldData allData = new WorldData{};
        public IActionResult Index()
        {
            WorldData.GetAll();
            return View("index", WorldData.GetCountryList());
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
            return View();
        }
    }
}
