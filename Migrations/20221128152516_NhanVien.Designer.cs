﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BaiTapLonNhom23.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221128152516_NhanVien")]
    partial class NhanVien
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("BaiTapLon_Nhom23.Models.ChucVu", b =>
                {
                    b.Property<string>("MaChuVu")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenChucVu")
                        .HasColumnType("TEXT");

                    b.HasKey("MaChuVu");

                    b.ToTable("ChucVu");
                });

            modelBuilder.Entity("BaiTapLon_Nhom23.Models.NhanVien", b =>
                {
                    b.Property<string>("MaID")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaChucVu")
                        .HasColumnType("TEXT");

                    b.Property<string>("NgaySinh")
                        .HasColumnType("TEXT");

                    b.Property<string>("QueQuan")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SĐT")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ten")
                        .HasColumnType("TEXT");

                    b.HasKey("MaID");

                    b.HasIndex("MaChucVu");

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("BaiTapLon_Nhom23.Models.NhanVien", b =>
                {
                    b.HasOne("BaiTapLon_Nhom23.Models.ChucVu", "ChucVu")
                        .WithMany()
                        .HasForeignKey("MaChucVu");

                    b.Navigation("ChucVu");
                });
#pragma warning restore 612, 618
        }
    }
}
