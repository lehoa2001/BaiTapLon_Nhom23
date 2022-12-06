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
    public class DanhSachQuanAoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ExcelProcess _excelProcess = new ExcelProcess();

        public DanhSachQuanAoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DanhSachQuanAo
        public async Task<IActionResult> Index()
        {
              return _context.DanhSachQuanAo != null ? 
                          View(await _context.DanhSachQuanAo.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DanhSachQuanAo'  is null.");
        }

        // GET: DanhSachQuanAo/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DanhSachQuanAo == null)
            {
                return NotFound();
            }

            var danhSachQuanAo = await _context.DanhSachQuanAo
                .FirstOrDefaultAsync(m => m.IDSp == id);
            if (danhSachQuanAo == null)
            {
                return NotFound();
            }

            return View(danhSachQuanAo);
        }

        // GET: DanhSachQuanAo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DanhSachQuanAo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDSp,TenSp,ThuongHieu,GiaTien,MaSize,MauSac")] DanhSachQuanAo danhSachQuanAo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhSachQuanAo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhSachQuanAo);
        }

        // GET: DanhSachQuanAo/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DanhSachQuanAo == null)
            {
                return NotFound();
            }

            var danhSachQuanAo = await _context.DanhSachQuanAo.FindAsync(id);
            if (danhSachQuanAo == null)
            {
                return NotFound();
            }
            return View(danhSachQuanAo);
        }

        // POST: DanhSachQuanAo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IDSp,TenSp,ThuongHieu,GiaTien,MaSize,MauSac")] DanhSachQuanAo danhSachQuanAo)
        {
            if (id != danhSachQuanAo.IDSp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhSachQuanAo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhSachQuanAoExists(danhSachQuanAo.IDSp))
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
            return View(danhSachQuanAo);
        }

        // GET: DanhSachQuanAo/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DanhSachQuanAo == null)
            {
                return NotFound();
            }

            var danhSachQuanAo = await _context.DanhSachQuanAo
                .FirstOrDefaultAsync(m => m.IDSp == id);
            if (danhSachQuanAo == null)
            {
                return NotFound();
            }

            return View(danhSachQuanAo);
        }

        // POST: DanhSachQuanAo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DanhSachQuanAo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DanhSachQuanAo'  is null.");
            }
            var danhSachQuanAo = await _context.DanhSachQuanAo.FindAsync(id);
            if (danhSachQuanAo != null)
            {
                _context.DanhSachQuanAo.Remove(danhSachQuanAo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhSachQuanAoExists(string id)
        {
          return (_context.DanhSachQuanAo?.Any(e => e.IDSp == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    var FileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excel", FileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to sever
                        await file.CopyToAsync(stream);
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            var std = new DanhSachQuanAo();

                            std.IDSp = dt.Rows[i][0].ToString();
                            std.TenSp = dt.Rows[i][1].ToString();
                            std.ThuongHieu = dt.Rows[i][2].ToString();
                            std.GiaTien = dt.Rows[i][3].ToString();
                            std.MaSize = dt.Rows[i][4].ToString();
                            std.MauSac = dt.Rows[i][5].ToString();

                            _context.DanhSachQuanAo.Add(std);
                        }
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
        }
    }
}
