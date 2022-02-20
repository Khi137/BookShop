using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _02_Layout.Areas.Admin.Models;
using _02_Layout.Data;

namespace _02_Layout.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InvoiceDetailsController : Controller
    {
        private readonly _02_LayoutContext _context;

        public InvoiceDetailsController(_02_LayoutContext context)
        {
            _context = context;
        }

        // GET: Admin/InvoiceDetails
        public async Task<IActionResult> Index()
        {
            var _02_LayoutContext = _context.InvoiceDetails.Include(i => i.Invoices).Include(i => i.Products);
            return View(await _02_LayoutContext.ToListAsync());
        }

        // GET: Admin/InvoiceDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceDetails = await _context.InvoiceDetails
                .Include(i => i.Invoices)
                .Include(i => i.Products)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceDetails == null)
            {
                return NotFound();
            }

            return View(invoiceDetails);
        }

        // GET: Admin/InvoiceDetails/Create
        public IActionResult Create()
        {
            ViewData["InvoicesID"] = new SelectList(_context.Invoices, "Id", "Id");
            ViewData["ProductsID"] = new SelectList(_context.Products, "Id", "Author");
            return View();
        }

        // POST: Admin/InvoiceDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InvoicesID,ProductsID,Quality,Total")] InvoiceDetails invoiceDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoiceDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InvoicesID"] = new SelectList(_context.Invoices, "Id", "Id", invoiceDetails.InvoicesID);
            ViewData["ProductsID"] = new SelectList(_context.Products, "Id", "Author", invoiceDetails.ProductsID);
            return View(invoiceDetails);
        }

        // GET: Admin/InvoiceDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceDetails = await _context.InvoiceDetails.FindAsync(id);
            if (invoiceDetails == null)
            {
                return NotFound();
            }
            ViewData["InvoicesID"] = new SelectList(_context.Invoices, "Id", "Id", invoiceDetails.InvoicesID);
            ViewData["ProductsID"] = new SelectList(_context.Products, "Id", "Author", invoiceDetails.ProductsID);
            return View(invoiceDetails);
        }

        // POST: Admin/InvoiceDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InvoicesID,ProductsID,Quality,Total")] InvoiceDetails invoiceDetails)
        {
            if (id != invoiceDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoiceDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceDetailsExists(invoiceDetails.Id))
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
            ViewData["InvoicesID"] = new SelectList(_context.Invoices, "Id", "Id", invoiceDetails.InvoicesID);
            ViewData["ProductsID"] = new SelectList(_context.Products, "Id", "Author", invoiceDetails.ProductsID);
            return View(invoiceDetails);
        }

        // GET: Admin/InvoiceDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceDetails = await _context.InvoiceDetails
                .Include(i => i.Invoices)
                .Include(i => i.Products)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceDetails == null)
            {
                return NotFound();
            }

            return View(invoiceDetails);
        }

        // POST: Admin/InvoiceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoiceDetails = await _context.InvoiceDetails.FindAsync(id);
            _context.InvoiceDetails.Remove(invoiceDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceDetailsExists(int id)
        {
            return _context.InvoiceDetails.Any(e => e.Id == id);
        }
    }
}
