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
    public class MauController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MauController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mau
        public async Task<IActionResult> Index()
        {
              return _context.Mau != null ? 
                          View(await _context.Mau.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Mau'  is null.");
        }

        // GET: Mau/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Mau == null)
            {
                return NotFound();
            }

            var mau = await _context.Mau
                .FirstOrDefaultAsync(m => m.MaMau == id);
            if (mau == null)
            {
                return NotFound();
            }

            return View(mau);
        }

        // GET: Mau/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mau/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaMau,TenMau")] Mau mau)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mau);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mau);
        }

        // GET: Mau/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Mau == null)
            {
                return NotFound();
            }

            var mau = await _context.Mau.FindAsync(id);
            if (mau == null)
            {
                return NotFound();
            }
            return View(mau);
        }

        // POST: Mau/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaMau,TenMau")] Mau mau)
        {
            if (id != mau.MaMau)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mau);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MauExists(mau.MaMau))
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
            return View(mau);
        }

        // GET: Mau/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Mau == null)
            {
                return NotFound();
            }

            var mau = await _context.Mau
                .FirstOrDefaultAsync(m => m.MaMau == id);
            if (mau == null)
            {
                return NotFound();
            }

            return View(mau);
        }

        // POST: Mau/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Mau == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Mau'  is null.");
            }
            var mau = await _context.Mau.FindAsync(id);
            if (mau != null)
            {
                _context.Mau.Remove(mau);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MauExists(string id)
        {
          return (_context.Mau?.Any(e => e.MaMau == id)).GetValueOrDefault();
        }
    }
}
