using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using passcode.Models;
using Microsoft.AspNetCore.Http;


namespace passcode.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("")]
        public IActionResult Index()
        {

            if(HttpContext.Session.GetInt32("Count") == null)
            {
                HttpContext.Session.SetInt32("Count", 1);
            }
            
            else 
            {
                int? Count = HttpContext.Session.GetInt32("Count");
                Count++;
                HttpContext.Session.SetInt32("Count", (int)Count);
            }

            Random rand = new Random();
            int number = rand.Next(0,10);
            ViewBag.RandNum = number;
            ViewBag.Count = HttpContext.Session.GetInt32("Count");

            return View();
        }




        [HttpGet("clear")]
        public IActionResult Clear()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.SetInt32("Count", 1);
            ViewBag.Count = HttpContext.Session.GetInt32("Count");

            Random rand = new Random();
            int number = rand.Next(0,10);
            ViewBag.RandNum = number;

            return View("Index");
        }
    }
}
