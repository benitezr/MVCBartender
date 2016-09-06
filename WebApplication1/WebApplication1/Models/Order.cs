using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int DrinkID { get; set; }

        public Drink Drink { get; set; }
    }
}