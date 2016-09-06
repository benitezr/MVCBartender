using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EditVM
    {
        public Order Order { get; set; }
        public List<Drink> Drinks { get; set; }
    }
}