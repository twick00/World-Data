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
        [HttpPost("/delete/{country}")]
        public IActionResult Delete(string country)
        {
            WorldData.DeleteCountry(country);
            WorldData.GetAll();
            return RedirectToAction("Index");
        }

        [HttpGet("/newcountry")]
        public IActionResult NewCountry()
        {
            return View("newcountry");
        }

        [HttpPost("/newcountry")]
        public IActionResult PostNewCountry()
        {
            WorldData.BuildCountry(Request.Form["country-code"], Request.Form["country-name"], Request.Form["country-region"], Request.Form["country-local-name"]);
            
            return RedirectToAction("Index");
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
