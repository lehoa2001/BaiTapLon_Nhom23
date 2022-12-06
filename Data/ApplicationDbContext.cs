using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BaiTapLon_Nhom23.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BaiTapLon_Nhom23.Models.NhanVien> NhanVien { get; set; } = default!;

        public DbSet<BaiTapLon_Nhom23.Models.ChucVu> ChucVu { get; set; } = default!;

        public DbSet<BaiTapLon_Nhom23.Models.Size> Size { get; set; } = default!;

        public DbSet<BaiTapLon_Nhom23.Models.Mau> Mau { get; set; } = default!;

        public DbSet<BaiTapLon_Nhom23.Models.QuanAo> QuanAo { get; set; } = default!;

        public DbSet<BaiTapLon_Nhom23.Models.KhachHang> KhachHang { get; set; } = default!;

        public DbSet<BaiTapLon_Nhom23.Models.DanhGia> DanhGia { get; set; } = default!;

        public DbSet<BaiTapLon_Nhom23.Models.HoaDon> HoaDon { get; set; } = default!;

        public DbSet<BaiTapLon_Nhom23.Models.DanhSachQuanAo> DanhSachQuanAo { get; set; } = default!;
    }
