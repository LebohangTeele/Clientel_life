
using DB_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UI_Web.Helper;
using UI_Web.Models;

namespace UI_Web.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            return View();
        }
        private int isExist(string id)
        {
            int newid = Convert.ToInt32(id);
            List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.CofID.Equals(newid))
                {
                    return i;
                }
            }
            return -1;
        }
        public Coffee find(string id)
        {
            //var httpClient = new HttpClient();
            List<Coffee> ProductList = new List<Coffee>();
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("JwToken"));
            // HttpResponseMessage response = httpClient.GetAsync(https://localhost:44381/ + "api/Coffee/Get?id=" + id.ToString()).Result;
            // ProductList = response.Content.ReadAsAsync<List<Coffee>>().Result;
            ProductList.Add(new Coffee { CofID = 1, Price = 20, CofName = "capacino", CofDiscription = "is an espresso-based coffee drink and is traditionally prepared with steamed milk foam", ImageURL = "//upload.wikimedia.org/wikipedia/commons/thumb/c/c8/Cappuccino_at_Sightglass_Coffee.jpg/220px-Cappuccino_at_Sightglass_Coffee.jpg" });
            ProductList.Add(new Coffee { CofID = 2, Price = 30, CofName = "Espresso", CofDiscription = "a coffee-brewing method of Italian origin,in which a small amount of nearly boiling water (about 90 °C or 190 °F)", ImageURL = "//upload.wikimedia.org/wikipedia/commons/thumb/a/a5/Tazzina_di_caff%C3%A8_a_Ventimiglia.jpg/220px-Tazzina_di_caff%C3%A8_a_Ventimiglia.jpg" });
            ProductList.Add(new Coffee { CofID = 3, Price = 40, CofName = "mocha", CofDiscription = "A caffè mocha, also called mocaccino is a chocolate-flavoured warm beverage that is a variant of a caffè latte", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7e/Mocha_coffee.jpg/375px-Mocha_coffee.jpg" });

            int myid = Convert.ToInt32(id);
            var prod = ProductList.Where(a => a.CofID == myid).FirstOrDefault();
            return prod;
        }

        public IActionResult Buy(string id)
        {
            //ProductModel product = new ProductModel();
            if (SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart") == null)
            {
                List<CartItem> cart = new List<CartItem>();
                cart.Add(new CartItem { Product = find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartItem { Product = find(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Remove(string id)
        {
            List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
    }
}
