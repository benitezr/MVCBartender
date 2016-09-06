using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AppContext
    {
        public List<Drink> Drinks { get; set; }
        public List<Order> Orders { get; set; }
    }
}