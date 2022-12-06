using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiTapLon_Nhom23.Models;
using BaiTapLon_Nhom23.Models.Process;

namespace BaiTapLon_Nhom23.Controllers
{
    public class QuanAoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private StringProcess strPro = new StringProcess();


        public QuanAoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuanAo
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.QuanAo.Include(q => q.Mau).Include(q => q.Size);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: QuanAo/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.QuanAo == null)
            {
                return NotFound();
            }

            var quanAo = await _context.QuanAo
                .Include(q => q.Mau)
                .Include(q => q.Size)
                .FirstOrDefaultAsync(m => m.IDSp == id);
            if (quanAo == null)
            {
                return NotFound();
            }

            return View(quanAo);
        }

        // GET: QuanAo/Create
        public IActionResult Create()
        {
            ViewData["MaMau"] = new SelectList(_context.Mau, "MaMau", "TenMau");
            ViewData["MaSize"] = new SelectList(_context.Size, "MaSize", "TenSize");
            var newquanao = "QA001";
            var countquanao = _context.QuanAo.Count();
            if (countquanao > 0)
            {
                var IDSp = _context.QuanAo.OrderByDescending(m => m.IDSp).First().IDSp;
                newquanao = strPro.AutoGenerateCode(IDSp);
            }
            ViewBag.newID = newquanao;
            return View();
        }

        // POST: QuanAo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDSp,TenSp,ThuongHieu,GiaTien,SoLuong,MaSize,MaMau")] QuanAo quanAo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanAo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaMau"] = new SelectList(_context.Mau, "MaMau", "TenMau", quanAo.MaMau);
            ViewData["MaSize"] = new SelectList(_context.Size, "MaSize", "TenSize", quanAo.MaSize);
            return View(quanAo);
        }

        // GET: QuanAo/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.QuanAo == null)
            {
                return NotFound();
            }

            var quanAo = await _context.QuanAo.FindAsync(id);
            if (quanAo == null)
            {
                return NotFound();
            }
            ViewData["MaMau"] = new SelectList(_context.Mau, "MaMau", "TenMau", quanAo.MaMau);
            ViewData["MaSize"] = new SelectList(_context.Size, "MaSize", "TenSize", quanAo.MaSize);
            return View(quanAo);
        }

        // POST: QuanAo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IDSp,TenSp,ThuongHieu,GiaTien,SoLuong,MaSize,MaMau")] QuanAo quanAo)
        {
            if (id != quanAo.IDSp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanAo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanAoExists(quanAo.IDSp))
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
            ViewData["MaMau"] = new SelectList(_context.Mau, "MaMau", "TenMau", quanAo.MaMau);
            ViewData["MaSize"] = new SelectList(_context.Size, "MaSize", "TenSize", quanAo.MaSize);
            return View(quanAo);
        }

        // GET: QuanAo/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.QuanAo == null)
            {
                return NotFound();
            }

            var quanAo = await _context.QuanAo
                .Include(q => q.Mau)
                .Include(q => q.Size)
                .FirstOrDefaultAsync(m => m.IDSp == id);
            if (quanAo == null)
            {
                return NotFound();
            }

            return View(quanAo);
        }

        // POST: QuanAo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.QuanAo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.QuanAo'  is null.");
            }
            var quanAo = await _context.QuanAo.FindAsync(id);
            if (quanAo != null)
            {
                _context.QuanAo.Remove(quanAo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanAoExists(string id)
        {
          return (_context.QuanAo?.Any(e => e.IDSp == id)).GetValueOrDefault();
        }
    }
}
