using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private static AppContext db = new AppContext()
        {
            Drinks = new List<Drink>()
            {
                new Drink()
                {
                    DrinkID = 1,
                    Name = "cocktail1",
                    Price = 6
                },
                new Drink()
                {
                    DrinkID = 2,
                    Name = "cocktail2",
                    Price = 6.50M
                },
                new Drink()
                {
                    DrinkID = 3,
                    Name = "cocktail3",
                    Price = 5.50M
                }
            },

            Orders = new List<Order>()
        };

        private static List<Order> tempOrders = new List<Order>();

        public ActionResult Index()
        {
            return View(db.Drinks);
        }

        [HttpGet]
        public ActionResult CreateOrder()
        {
            return View(db.Drinks);
        }

        [HttpPost]
        public ActionResult CreateOrder(int id)
        {
            var order = new Order()
            {
                OrderID = tempOrders.Count + 1,
                DrinkID = id,
                Drink = db.Drinks.FirstOrDefault(x => x.DrinkID == id)
            };
            tempOrders.Add(order);
            return RedirectToAction("ViewOrder", new { id = order.OrderID });
        }

        public ActionResult ViewOrder(int? id)
        {
            if (id == null) { return View("Error"); }
            var order = tempOrders.FirstOrDefault(x => x.OrderID == id);
            if (order == null) { return View("Error"); }      
            return View(order);
        }

        public ActionResult OrderQueue()
        {
            return View();
        }

        public ActionResult QueueList(int? id)
        {
            if (id == null) { return PartialView(tempOrders); }
            var order = tempOrders.First(x => x.OrderID == id);
            tempOrders.Remove(order);
            order.OrderID = db.Orders.Count + 1;
            db.Orders.Add(order);          
            return PartialView(tempOrders);
        }

        [HttpGet]
        public ActionResult EditOrder(int? id)
        {
            if (id == null) { return View("Error"); }
            var order = tempOrders.FirstOrDefault(x => x.OrderID == id);
            if (order == null) { return View("Error"); }
            EditVM model = new EditVM()
            {
                Order = order,
                Drinks = db.Drinks
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditOrder(Order orderEdit)
        {
            var order = tempOrders.First(x => x.OrderID == orderEdit.OrderID);
            order.Drink = db.Drinks.First(x => x.DrinkID == orderEdit.DrinkID);
            order.DrinkID = orderEdit.DrinkID;
            return RedirectToAction("ViewOrder", new { id = order.OrderID });
        }
    }
}