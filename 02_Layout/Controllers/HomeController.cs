using _02_Layout.Data;
using _02_Layout.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _02_Layout.Controllers
{
    public class HomeController : Controller
    {
        private readonly _02_LayoutContext _context;

        public HomeController(_02_LayoutContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if(HttpContext.Session.GetString("Username")==null)
            {
                ViewBag.Username = null;
            }
            else
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
            }    
            
   

            var _02_LayoutContext = _context.Products.Include(p => p.ProductTypes);
            var listads = _context.Ads.Where(q => q.Status == true);
            ViewBag.Image = listads.ToList();
            
            return View(await _02_LayoutContext.OrderByDescending(x => x.Id).Take(6).ToListAsync());

        }
        public IActionResult Product()
        {
            return View();
        }
        public IActionResult WhyUs()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                ViewBag.Username = null;
            }
            else
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
            }
            return View();
        }
        public IActionResult About()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                ViewBag.Username = null;
            }
            else
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
            }
            return View();
        }
        public IActionResult Testimonial()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                ViewBag.Username = null;
            }
            else
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
            }
            return View();
        }
        public IActionResult Cart()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                ViewBag.Username = null;
            }
            else
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
            }
            return View();
        }
        public IActionResult MyAccount()
        {
            return View();
        }
        public IActionResult ProductDetail()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {

            bool result = _context.Accounts.Where(a => a.UserName == Username && a.Password == Password).Count() > 0;
            var account = _context.Accounts.FirstOrDefault(a => a.UserName == Username && a.Password == Password);
            if (result)
            {
                var admin = _context.Accounts.Where(a => a.IsAdmin == true && a.Password == Password && a.UserName == Username).Count() > 0;
                HttpContext.Session.SetString("Username", Username);
                HttpContext.Session.SetInt32("Id", account.Id);
                HttpContext.Session.SetString("PhoneNumber", account.PhoneNumber);
                HttpContext.Session.SetString("Adress", account.Adress);
                if(admin)
                {
                    return RedirectToAction("Products", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                
            }
            else
            {
                ViewBag.ErrorMessage = "Đăng nhập thất bại";
                return View();
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult AdsPartial()
        {
            return PartialView();
        }
    }
}
