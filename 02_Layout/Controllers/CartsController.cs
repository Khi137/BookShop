using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _02_Layout.Areas.Admin.Models;
using _02_Layout.Data;
using Microsoft.AspNetCore.Http;

namespace _02_Layout.Controllers
{
    public class CartsController : Controller
    {
        private readonly _02_LayoutContext _context;

        public CartsController(_02_LayoutContext context)
        {
            _context = context;
        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                ViewBag.Username = null;
            }
            else
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
            }

            
            var _02_LayoutContext = _context.Carts.Include(c => c.Accounts).Include(c => c.Products).Where(c=>c.Accounts.UserName==HttpContext.Session.GetString("Username"));
            ViewBag.Total = _02_LayoutContext.Sum(c => c.Quality * c.Products.Price);
            return View(await _02_LayoutContext.ToListAsync());
        }

        // GET: Carts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carts = await _context.Carts
                .Include(c => c.Accounts)
                .Include(c => c.Products)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carts == null)
            {
                return NotFound();
            }

            return View(carts);
        }

        // GET: Carts/Create
        public IActionResult Create()
        {
            ViewData["AccountsID"] = new SelectList(_context.Accounts, "Id", "FullName");
            ViewData["ProductsID"] = new SelectList(_context.Products, "Id", "ProductName");
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccountsID,ProductsID,Quality")] Carts carts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountsID"] = new SelectList(_context.Accounts, "Id", "Id", carts.AccountsID);
            ViewData["ProductsID"] = new SelectList(_context.Products, "Id", "Id", carts.ProductsID);
            return View(carts);
        }

        // GET: Carts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carts = await _context.Carts.FindAsync(id);
            if (carts == null)
            {
                return NotFound();
            }
            ViewData["AccountsID"] = new SelectList(_context.Accounts, "Id", "Id", carts.AccountsID);
            ViewData["ProductsID"] = new SelectList(_context.Products, "Id", "Id", carts.ProductsID);
            return View(carts);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AccountsID,ProductsID,Quality")] Carts carts)
        {
            if (id != carts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartsExists(carts.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountsID"] = new SelectList(_context.Accounts, "Id", "FullName", carts.AccountsID);
            ViewData["ProductsID"] = new SelectList(_context.Products, "Id", "ProductName", carts.ProductsID);
            return View(carts);
        }

        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carts = await _context.Carts
                .Include(c => c.Accounts)
                .Include(c => c.Products)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carts == null)
            {
                return NotFound();
            }

            return View(carts);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carts = await _context.Carts.FindAsync(id);
            _context.Carts.Remove(carts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartsExists(int id)
        {
            return _context.Carts.Any(e => e.Id == id);
        }
        public IActionResult Pay()
        {

            if (HttpContext.Session.GetString("Username") == null)
            {
                ViewBag.Username = null;
            }
            else
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
            }
            String username = ViewBag.Username;
            ViewBag.Account = _context.Accounts.Where(a => a.UserName == username).FirstOrDefault(m=>m.UserName==username);
            ViewBag.CartsTotal = _context.Carts.Include(c => c.Products).Include(c=>c.Accounts).Where(c=>c.Accounts.UserName==username).Sum(c=>c.Quality*c.Products.Price);
            ViewBag.Adress= HttpContext.Session.GetString("Adress");
            ViewBag.AccountsId = HttpContext.Session.GetInt32("Id");
            ViewBag.PhoneNumber = HttpContext.Session.GetString("PhoneNumber");
            return View();
        }

        [HttpPost]
        public IActionResult Pay([Bind("AdressOrder,PhoneOrder")] Invoices invoice)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                ViewBag.Username = null;
            }
            else
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
            }
            String username = ViewBag.Username;
            if (!checkInven(username))
            {
                ViewBag.ErrorMessage = "Có sản phẩm đã hết hàng. Vui lòng kiểm tra lại";
                return View();
            }

            //Hoá Đơn
            invoice.Status = true;
            DateTime now = DateTime.Now;
            invoice.AccountsID = _context.Accounts.FirstOrDefault(a => a.UserName == username).Id;
            invoice.BuyDate = now;
            invoice.Total = _context.Carts.Include(c => c.Products).Include(c => c.Accounts).Where(c => c.Accounts.UserName == username).Sum(c => c.Quality * c.Products.Price);
            _context.Add(invoice);
            _context.SaveChanges();


            //Chi tiết  hoá đơn
            List<Carts> carts = _context.Carts.Include(c => c.Products).Include(c => c.Accounts).Where(c => c.Accounts.UserName == username).ToList();
            foreach(Carts c in carts)
            {
                InvoiceDetails invoiceDetails = new InvoiceDetails();
                invoiceDetails.InvoicesID = invoice.Id;
                invoiceDetails.ProductsID = c.ProductsID;
                invoiceDetails.Quality = c.Quality;
                invoiceDetails.Total = c.Products.Price;
                
                _context.Add(invoiceDetails);
            }
            _context.SaveChanges();

            //Trừ số lượng tồn kho và xoá giỏ hàng
            foreach(Carts c in carts)
            {
                c.Products.Inventory -= c.Quality;
                _context.Carts.Remove(c);
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private bool checkInven(String username)
        {
            List<Carts> carts = _context.Carts.Include(c => c.Products).Include(c => c.Accounts)
                .Where(c => c.Accounts.UserName == username).ToList();
            foreach(Carts c in carts)
            {
                if(c.Products.Inventory<c.Quality)
                {
                    return false;
                }    
            }
            return true;
        }
        //AddCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int SoLuong, int id)
        {
            int Id = (int)HttpContext.Session.GetInt32("Id");
            var carts = _context.Carts.FirstOrDefault(c => c.ProductsID == id && c.AccountsID== id);
            if(carts == null)
            {
               
                carts = new Carts()
                {
                    AccountsID = Id,
                    ProductsID = id,
                    Quality = SoLuong,
                };
                _context.Carts.Add(carts);
                await _context.SaveChangesAsync();
            }
            else
            {
                carts.Quality += SoLuong;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
