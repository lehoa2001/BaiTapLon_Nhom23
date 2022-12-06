using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapLonNhom23.Migrations
{
    /// <inheritdoc />
    public partial class DanhSachQuanAo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhSachQuanAo",
                columns: table => new
                {
                    IDSp = table.Column<string>(type: "TEXT", nullable: false),
                    TenSp = table.Column<string>(type: "TEXT", nullable: true),
                    ThuongHieu = table.Column<string>(type: "TEXT", nullable: true),
                    GiaTien = table.Column<string>(type: "TEXT", nullable: true),
                    MaSize = table.Column<string>(type: "TEXT", nullable: true),
                    MauSac = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSachQuanAo", x => x.IDSp);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DanhSachQuanAo");
        }
    }
}
