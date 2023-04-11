using DB_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_Web.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            List<Customer> cus = new List<Customer>();
            List<CustomerPoint> cuspoint = new List<CustomerPoint>();
            cus.Add(new Customer { CusID = 1, CusName = "Sam", CusSurname = "smith" });
            cuspoint.Add(new CustomerPoint {ProPointsID = 1, ProID = 1, Points = 20,OrderNumber ="order123",CusID = 1,RedeemedDate = null });
            cuspoint.Add(new CustomerPoint { ProPointsID = 2, ProID = 1, Points = 20, OrderNumber = "order123", CusID = 1, RedeemedDate = null });
            var sum2 = cuspoint.Where(p => p.RedeemedDate == null).Sum(p => p.Points);

           

            return View();
        }
    }
}
