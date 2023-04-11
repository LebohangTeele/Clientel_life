
using DB_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UI_Web.Models;

namespace UI_Web.Controllers
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
            //Using seassions for customer 
            HttpContext.Session.SetString("ClientID", "1");
            
            List<Coffee> CofeeList = new List<Coffee>();
            //using (var httpClient = new HttpClient())
            //{
            //    using (var responsse = httpClient.GetAsync("https://localhost:44381/" + "api/Coffee/GetAll").Result)
            //    {
            //        CofeeList = responsse.Content.ReadAsAsync<List<Coffee>>().Result;
            //    }
            //}
            CofeeList.Add(new Coffee { CofID = 1, Price = 20, CofName = "capacino", CofDiscription = "is an espresso-based coffee drink and is traditionally prepared with steamed milk foam", ImageURL = "//upload.wikimedia.org/wikipedia/commons/thumb/c/c8/Cappuccino_at_Sightglass_Coffee.jpg/220px-Cappuccino_at_Sightglass_Coffee.jpg" });
            CofeeList.Add(new Coffee { CofID = 2, Price = 30, CofName = "Espresso", CofDiscription = "a coffee-brewing method of Italian origin,in which a small amount of nearly boiling water (about 90 °C or 190 °F)", ImageURL = "//upload.wikimedia.org/wikipedia/commons/thumb/a/a5/Tazzina_di_caff%C3%A8_a_Ventimiglia.jpg/220px-Tazzina_di_caff%C3%A8_a_Ventimiglia.jpg" });
            CofeeList.Add(new Coffee { CofID = 3, Price = 40, CofName = "mocha", CofDiscription = "A caffè mocha, also called mocaccino is a chocolate-flavoured warm beverage that is a variant of a caffè latte", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7e/Mocha_coffee.jpg/375px-Mocha_coffee.jpg" });

            ViewBag.product = CofeeList;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
