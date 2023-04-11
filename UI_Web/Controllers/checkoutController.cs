
using DB_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UI_Web.Helper;
using UI_Web.Models;

namespace UI_Web.Controllers
{
    public class checkoutController : Controller
    {
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            return View();
        }
        public bool SaveOrder(Order model)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync("" + "Order/Insert", content);
            return true;

        }
        public bool SaveCustomerpoints(CustomerPoint model)
        {
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync("" + "Order/Insert", content);
            return true;

        }
        [HttpPost]
        public ViewResult Index(int id)
        {
            if (HttpContext.Session.GetString("JwToken") == null)
            {
                ViewBag.Message1 = "Invoice Has been saved to the database already";
                ViewBag.Message2 = null;
                return View();
            }
            Random _r = new Random();
            int rand = _r.Next(1, 10000);
            string yearPrefix = DateTime.Now.Year + "-";
            yearPrefix = yearPrefix.Substring(2);
            string OrderNumber = "ORD" + yearPrefix + rand;
            Order myorder = new Order();

            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            var date = DateTime.Now;
            foreach (var item in cart)
            {
                myorder = new Order
                {
                    Orderdate = DateTime.Now,
                    Quantity = item.Quantity,
                    Totalprice = item.Product.Price,
                    CofID = item.Product.CofID,
                    CusID = Convert.ToInt32(HttpContext.Session.GetString("ClientID")),
                    OrderNumber = OrderNumber,
                };
                SaveOrder(myorder);
            }
            
            foreach (var item in cart)
            {
                for (int i = 0; i < item.Quantity; i++)
                {
                    CustomerPoint customerPoints = new CustomerPoint
                    {
                        OrderNumber = OrderNumber,
                        ProID = 1,
                        Points = 10,
                    };
                    SaveCustomerpoints(customerPoints);
                }
                
            }

            SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            HttpContext.Session.Clear();
            return View();
        }
    }

}
