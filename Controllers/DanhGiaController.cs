using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiTapLon_Nhom23.Models;

namespace BaiTapLon_Nhom23.Controllers
{
    public class DanhGiaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DanhGiaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DanhGia
        public async Task<IActionResult> Index()
        {
              return _context.DanhGia != null ? 
                          View(await _context.DanhGia.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DanhGia'  is null.");
        }

        // GET: DanhGia/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DanhGia == null)
            {
                return NotFound();
            }

            var danhGia = await _context.DanhGia
                .FirstOrDefaultAsync(m => m.IDSp == id);
            if (danhGia == null)
            {
                return NotFound();
            }

            return View(danhGia);
        }

        // GET: DanhGia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DanhGia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDSp,TenSp,GopY,DiemDanhGia")] DanhGia danhGia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhGia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhGia);
        }

        // GET: DanhGia/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DanhGia == null)
            {
                return NotFound();
            }

            var danhGia = await _context.DanhGia.FindAsync(id);
            if (danhGia == null)
            {
                return NotFound();
            }
            return View(danhGia);
        }

        // POST: DanhGia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IDSp,TenSp,GopY,DiemDanhGia")] DanhGia danhGia)
        {
            if (id != danhGia.IDSp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhGia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhGiaExists(danhGia.IDSp))
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
            return View(danhGia);
        }

        // GET: DanhGia/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DanhGia == null)
            {
                return NotFound();
            }

            var danhGia = await _context.DanhGia
                .FirstOrDefaultAsync(m => m.IDSp == id);
            if (danhGia == null)
            {
                return NotFound();
            }

            return View(danhGia);
        }

        // POST: DanhGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DanhGia == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DanhGia'  is null.");
            }
            var danhGia = await _context.DanhGia.FindAsync(id);
            if (danhGia != null)
            {
                _context.DanhGia.Remove(danhGia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhGiaExists(string id)
        {
          return (_context.DanhGia?.Any(e => e.IDSp == id)).GetValueOrDefault();
        }
    }
}
