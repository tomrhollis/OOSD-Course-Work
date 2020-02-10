using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Products()
        {
            List<Product> products = new HalloweenEntities().Products.ToList();
            
            return View(products);
        }

        public ActionResult Details(string id)
        {
            Product p = new HalloweenEntities().Products.Where(prod => prod.ProductID == id).Single();
            return View(p);
        }

    }
}