using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _02_Layout.Areas.Admin.Models;
using _02_Layout.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace _02_Layout.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly _02_LayoutContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;
        public ProductsController(_02_LayoutContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnviroment = webHostEnvironment;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var _02_LayoutContext = _context.Products.Include(p => p.ProductTypes);
            return View(await _02_LayoutContext.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.ProductTypes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["ProductTypesID"] = new SelectList(_context.ProductTypes, "Id", "ProductTypeName");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,Author,PublicDate,Description,Pages,Price,Inventory,ProductTypesID,ImageFile,Status")] Products products)
        {
            if (ModelState.IsValid)
            {
                _context.Add(products);
                await _context.SaveChangesAsync();
                //Upload ảnh
                if (products.ImageFile != null)
                {
                    var fileName = products.Id.ToString() + Path.GetExtension(products.ImageFile.FileName);
                    var uploadPath = Path.Combine(_webHostEnviroment.WebRootPath, "img", "product");
                    var filePath = Path.Combine(uploadPath, fileName);
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        products.ImageFile.CopyTo(fs);
                        fs.Flush();
                    }
                    products.Image = fileName;
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductTypesID"] = new SelectList(_context.ProductTypes, "Id", "Id", products.ProductTypesID);
            return View(products);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            ViewData["ProductTypesID"] = new SelectList(_context.ProductTypes, "Id", "ProductTypeName", products.ProductTypesID);
            return View(products);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,Author,PublicDate,Description,Pages,Price,Inventory,ProductTypesID,Image,ImageFile,Status")] Products products)
        {
            if (id != products.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Xoá ảnh cũ
                    if (products.ImageFile != null)
                    {
                        var fileToDelete = Path.Combine(_webHostEnviroment.WebRootPath, "img", "product", products.Image);
                        FileInfo file = new FileInfo(fileToDelete);
                        file.Delete();
                    }

                    //Upload ảnh
                    if (products.ImageFile != null)
                    {
                        var fileName = products.Id.ToString() + Path.GetExtension(products.ImageFile.FileName);
                        var uploadPath = Path.Combine(_webHostEnviroment.WebRootPath, "img", "product");
                        var filePath = Path.Combine(uploadPath, fileName);
                        using (FileStream fs = System.IO.File.Create(filePath))
                        {
                            products.ImageFile.CopyTo(fs);
                            fs.Flush();
                        }
                        products.Image = fileName;
                    }

                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.Id))
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
            ViewData["ProductTypesID"] = new SelectList(_context.ProductTypes, "Id", "Id", products.ProductTypesID);
            return View(products);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.ProductTypes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }
        public IActionResult Search( string name, string author, int miniprice = 0, int maxprice = int.MaxValue, int productTypesId = 1)
        {
            ViewData["ProductTypesID"] = new SelectList(_context.ProductTypes, "Id", "ProductName");

            if (name == null) name = "";
            if (author == null) author = "";

            var products = _context.Products.Include(a => a.ProductTypes)
                                          
                                            .Where(a => a.ProductName.Contains(name))
                                            .Where(a => a.Author.Contains(author))
                                            .Where(a => a.ProductTypesID == productTypesId)
                                            .Where(a => a.Price >= miniprice && a.Price <= maxprice).ToList();
            return View("Index", products);
        }
        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
