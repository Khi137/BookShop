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
    public class AdsController : Controller
    {
        private readonly _02_LayoutContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;
        public AdsController(_02_LayoutContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnviroment = webHostEnvironment;
        }

        // GET: Admin/Ads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ads.ToListAsync());
        }

        // GET: Admin/Ads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ads = await _context.Ads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ads == null)
            {
                return NotFound();
            }

            return View(ads);
        }

        // GET: Admin/Ads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Ads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,ImageFile,Status")] Ads ads)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ads);
                await _context.SaveChangesAsync();
                //Upload ảnh
                if (ads.ImageFile != null)
                {
                    var fileName = ads.Id.ToString() + Path.GetExtension(ads.ImageFile.FileName);
                    var uploadPath = Path.Combine(_webHostEnviroment.WebRootPath, "img", "ads");
                    var filePath = Path.Combine(uploadPath, fileName);
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        ads.ImageFile.CopyTo(fs);
                        fs.Flush();
                    }
                    ads.Image = fileName;
                    _context.Update(ads);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ads);
        }

        // GET: Admin/Ads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ads = await _context.Ads.FindAsync(id);
            if (ads == null)
            {
                return NotFound();
            }
            return View(ads);
        }

        // POST: Admin/Ads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,ImageFile,Status")] Ads ads)
        {
            if (id != ads.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {//Xoá ảnh cũ
                    if (ads.ImageFile != null)
                    {
                        var fileToDelete = Path.Combine(_webHostEnviroment.WebRootPath, "img", "ads", ads.Image);
                        FileInfo file = new FileInfo(fileToDelete);
                        file.Delete();
                    }

                    //Upload ảnh
                    if (ads.ImageFile != null)
                    {
                        var fileName = ads.Id.ToString() + Path.GetExtension(ads.ImageFile.FileName);
                        var uploadPath = Path.Combine(_webHostEnviroment.WebRootPath, "img", "ads");
                        var filePath = Path.Combine(uploadPath, fileName);
                        using (FileStream fs = System.IO.File.Create(filePath))
                        {
                            ads.ImageFile.CopyTo(fs);
                            fs.Flush();
                        }
                        ads.Image = fileName;
                    }
                    _context.Update(ads);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdsExists(ads.Id))
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
            return View(ads);
        }

        // GET: Admin/Ads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ads = await _context.Ads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ads == null)
            {
                return NotFound();
            }

            return View(ads);
        }

        // POST: Admin/Ads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ads = await _context.Ads.FindAsync(id);
            _context.Ads.Remove(ads);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdsExists(int id)
        {
            return _context.Ads.Any(e => e.Id == id);
        }
    }
}
