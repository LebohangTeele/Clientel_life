
using DB_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_Web.Models
{
    public class CartItem
    {
        public Coffee Product
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }
    }
}
